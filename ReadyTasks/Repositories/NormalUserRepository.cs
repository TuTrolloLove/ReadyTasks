using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReadyTasks.Repositories
{
    public class NormalUserRepository : RepositoryBase, INormalUserRepository
    {
        public void addNormalUser(int normalUserId, int userId)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into [Normal_Users] values(@id,@cod_users)";
                command.Parameters.Add("@id", SqlDbType.Int).Value = normalUserId;
                command.Parameters.Add("@cod_users", SqlDbType.NVarChar).Value = userId;
                command.ExecuteNonQuery();
            }
        }
        public int findMaxId1()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select max(id)+1 from [Normal_Users]";
                if (command.ExecuteScalar() == DBNull.Value)
                {
                    return 1;
                }
                else
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool deleteNormalUser(int userId)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from [Normal_Users] where cod_users=@cod_users";
                command.Parameters.Add("@cod_users", SqlDbType.Int).Value = userId;
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
            }
        }
    }
}
