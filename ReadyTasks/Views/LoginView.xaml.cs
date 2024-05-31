using ReadyTasks.ViewModels;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using ReadyTasks.Repositories;
using ReadyTasks.Models;

namespace ReadyTasks.Views
{

    public partial class LoginView : Window
    {
        public bool passwordHidden; // True = password is hidden, False = password is shown

        // client configuration
        const string clientID = "";
        const string clientSecret = "";
        const string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string tokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";
        const string userInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo";

        string emailGoogleUser;
        int idRegister;
        int idUserGoogle;

        private LoginViewModel _loginViewModel;

        public LoginView()
        {
            InitializeComponent();

            if (!File.Exists(@"./ID.txt"))
            {
                File.Create(@"./ID.txt").Close();
            }
            if (!File.Exists(@"./Language.txt"))
            {
                File.Create(@"./Language.txt").Close();
            }
            translate();
            _loginViewModel = new LoginViewModel();
        }


        public static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        private async void googleLoginClick(object sender, MouseButtonEventArgs e)
        {
            // Generates state and PKCE values.
            string state = randomDataBase64url(32);
            string code_verifier = randomDataBase64url(32);
            string code_challenge = base64urlencodeNoPadding(sha256(code_verifier));
            const string code_challenge_method = "S256";

            // Creates a redirect URI using an available port on the loopback address.
            string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort());
            output("redirect URI: " + redirectURI);

            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            output("Listening..");
            http.Start();

            // Creates the OAuth 2.0 authorization request.
            string authorizationRequest = string.Format("{0}?response_type=code&scope=openid%20profile%20email&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
                authorizationEndpoint,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                state,
                code_challenge,
                code_challenge_method);
            Debug.WriteLine(authorizationRequest);

            // Opens request in the browser.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = authorizationRequest,
                UseShellExecute = true
            });


            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Brings this app back to the foreground.
            this.Activate();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Console.WriteLine("HTTP server stopped.");
            });

            // Checks for errors.
            if (context.Request.QueryString.Get("error") != null)
            {
                output(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                output("Malformed authorization response. " + context.Request.QueryString);
                return;
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incoming_state != state)
            {
                output(String.Format("Received request with invalid state ({0})", incoming_state));
                return;
            }
            output("Authorization code: " + code);

            // Starts the code exchange at the Token Endpoint.
            performCodeExchange(code, code_verifier, redirectURI);
        }

        async void performCodeExchange(string code, string code_verifier, string redirectURI)
        {
            output("Exchanging code for tokens...");

            // builds the  request
            string tokenRequestURI = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
                );

            // sends the request
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            tokenRequest.ContentLength = _byteVersion.Length;
            Stream stream = tokenRequest.GetRequestStream();
            await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = await reader.ReadToEndAsync();
                    output(responseText);

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    string access_token = tokenEndpointDecoded["access_token"];
                    userinfoCall(access_token);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        output("HTTP: " + response.StatusCode);
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            output(responseText);
                        }
                    }

                }
            }
        }


        async void userinfoCall(string access_token)
        {
            output("Making API Call to Userinfo...");

            // builds the  request
            string userinfoRequestURI = "https://www.googleapis.com/oauth2/v3/userinfo";

            // sends the request
            HttpWebRequest userinfoRequest = (HttpWebRequest)WebRequest.Create(userinfoRequestURI);
            userinfoRequest.Method = "GET";
            userinfoRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            userinfoRequest.ContentType = "application/x-www-form-urlencoded";
            userinfoRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // gets the response
            WebResponse userinfoResponse = await userinfoRequest.GetResponseAsync();
            using (StreamReader userinfoResponseReader = new StreamReader(userinfoResponse.GetResponseStream()))
            {
                // reads response body
                string userinfoResponseText = await userinfoResponseReader.ReadToEndAsync();

                // parses the response body
                var userinfo = JsonConvert.DeserializeObject<dynamic>(userinfoResponseText);

                // gets the user's email
                emailGoogleUser = userinfo.email;

                // comprobe if the user exists
                UserRepository ur = new UserRepository();
                var user = ur.GetByMail(emailGoogleUser);
                if (user == null)
                {
                    UserModel newUser = new UserModel()
                    {

                        id = ur.findMaxId1(),
                        mail = emailGoogleUser,
                        from_Google = "true"
                    };
                    ur.AddGoogleUser(newUser);
                }
                // get the id of the user
                idUserGoogle = _loginViewModel.getUserIdGoogle(emailGoogleUser);
                string path = @"./ID.txt";
                // Set the Write property.
                File.SetAttributes(path, FileAttributes.Normal);
                File.WriteAllText(path, idUserGoogle.ToString());
                // Read Only
                File.SetAttributes(path, FileAttributes.ReadOnly);

                output($"User's email: {userinfo.email}");

                // Closes the response.
                userinfoResponse.Close();

                this.Close();

            }
        }

        public void output(string output)
        {
            Debug.WriteLine(output);
        }

        public static string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }

        public static byte[] sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        public static string base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            //File.Delete(@"./ID.txt");
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            // Minimize the window
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void Window_Closed(object sender, EventArgs e)
        {

            if (!File.Exists(@"./ID.txt"))
            {
                Application.Current.Shutdown();
            }

        }

        private void translate()
        {

            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                tbPassword.Text = Application.Current.Resources["LoginViewPasswordTextBlock"] as string;
                btnLogin.Content = Application.Current.Resources["LoginViewLoginButtonContent"] as string;
                btnLogin_Register.Content = Application.Current.Resources["LoginViewRegisterButtonContent"] as string;

            }
            else if (language.Equals("en"))
            {
                tbPassword.Text = Application.Current.Resources["EN_LoginViewPasswordTextBlock"] as string;
                btnLogin.Content = Application.Current.Resources["EN_LoginViewLoginButtonContent"] as string;
                btnLogin_Register.Content = Application.Current.Resources["EN_LoginViewRegisterButtonContent"] as string;

            }
            else
            {
                tbPassword.Text = Application.Current.Resources["VA_LoginViewPasswordTextBlock"] as string;
                btnLogin.Content = Application.Current.Resources["VA_LoginViewLoginButtonContent"] as string;
                btnLogin_Register.Content = Application.Current.Resources["VA_LoginViewRegisterButtonContent"] as string;

            }
        }
    }
}