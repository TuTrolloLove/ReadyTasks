using ReadyTasks.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReadyTasks.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public int getAllUsersCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select count(*) from [Users]";
                return (int)command.ExecuteScalar();
            }
        }
        public void AddGoogleUser(UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into [Users] (id, mail, from_google) values(@id,@mail,@from_Google)";
                command.Parameters.Add("@id", SqlDbType.Int).Value = user.id;
                command.Parameters.Add("@mail", SqlDbType.NVarChar).Value = user.mail;
                command.Parameters.Add("@from_Google", SqlDbType.NVarChar).Value = user.from_Google;
                command.ExecuteNonQuery();
            }
        }

        public void AddUser(UserModel user, NetworkCredential credential)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into [Users] values(@id,@mail,@password,'false')";
                command.Parameters.Add("@id", SqlDbType.Int).Value = user.id;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                command.Parameters.Add("@mail", SqlDbType.NVarChar).Value = user.mail;
                command.ExecuteNonQuery();
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where mail=@username and [password]=@password collate SQL_Latin1_General_CP1_CS_AS";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public bool Remove(int id)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "delete from [Users] where id=@id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public int findMaxId1()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select max(id)+1 from [Users]";
                return (int)command.ExecuteScalar();
            }
        }
        public UserModel GetByMail(string mail)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where mail=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = mail;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            id = (int)reader[0],
                            mail = reader[1].ToString(),
                            password = reader[2].ToString(),
                            from_Google = reader[3].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public int findIdByLogin(NetworkCredential credential)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                command.CommandText = "select id from [Users] where mail=@username and password=@password";
                return (int)command.ExecuteScalar();
            }
        }

        public int getUserIdGoogle(string mail)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = mail;
                command.CommandText = "select id from [Users] where mail=@username";
                Debug.WriteLine("Repositorio: " + (int)command.ExecuteScalar());
                return ((int)command.ExecuteScalar());
            }
        }

        public bool isAdmin(int userId)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Add("@id", SqlDbType.Int).Value = userId;
                command.CommandText = "select * from [Admins] where cod_users=@id";
                return command.ExecuteScalar() == null ? false : true;

            }
        }

        public List<string> GetByMailWithoutPassword(string mail)
        {
            List<string> userData = new List<string>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where mail=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = mail;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        userData.Add(reader[0].ToString());
                        userData.Add(reader[1].ToString());
                        userData.Add(reader[3].ToString());

                    }
                }
            }
            return userData;
        }

        public List<string> GetUserById(int id)
        {
            List<string> userData = new List<string>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        userData.Add(reader[0].ToString());
                        userData.Add(reader[1].ToString());
                        userData.Add(reader[3].ToString());

                    }
                }
            }
            return userData;
        }
    }
}
