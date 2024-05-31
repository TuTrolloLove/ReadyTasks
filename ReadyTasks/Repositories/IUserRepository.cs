using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.Models
{
    public interface IUserRepository
    {
        public int getAllUsersCount();
        bool AuthenticateUser(NetworkCredential credential);
        void AddGoogleUser(UserModel user);
        void AddUser(UserModel user, NetworkCredential credential);
        bool Remove(int id);
        UserModel GetByMail(string mail);
        List<String> GetByMailWithoutPassword(string mail);
        List<String> GetUserById(int id);
        int findIdByLogin(NetworkCredential credential);
        int findMaxId1();
        public int getUserIdGoogle(string mail);
        public bool isAdmin(int userId);
    }
}
