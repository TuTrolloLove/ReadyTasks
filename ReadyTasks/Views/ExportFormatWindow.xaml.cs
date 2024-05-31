using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReadyTasks.Views
{

    public partial class ExportFormatWindow : Window
    {
        public string SelectedFormat { get; private set; }
        public ExportFormatWindow()
        {
            InitializeComponent();
            translate();
        }
        private void BtnCsv_Click(object sender, RoutedEventArgs e)
        {
            SelectedFormat = "CSV";
            DialogResult = true;
        }

        private void BtnTxt_Click(object sender, RoutedEventArgs e)
        {
            SelectedFormat = "TXT";
            DialogResult = true;
        }
        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                exportFormatWindowTitle.Title = Application.Current.Resources["ExportFormatWindowTitle"] as string;
                tbFormatQuestion.Text = Application.Current.Resources["ExportFormatWindowTextBlock"] as string;
            }
            else if (language.Equals("en"))
            {
                exportFormatWindowTitle.Title = Application.Current.Resources["EN_ExportFormatWindowTitle"] as string;
                tbFormatQuestion.Text = Application.Current.Resources["EN_ExportFormatWindowTextBlock"] as string;
            }
            else
            {
                exportFormatWindowTitle.Title = Application.Current.Resources["VA_ExportFormatWindowTitle"] as string;
                tbFormatQuestion.Text = Application.Current.Resources["VA_ExportFormatWindowTextBlock"] as string;
            }
        }
    }

}

