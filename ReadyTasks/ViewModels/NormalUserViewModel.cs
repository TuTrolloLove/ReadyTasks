using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.ViewModels
{
    public class NormalUserViewModel : ViewModelBase
    {
        private INormalUserRepository _normalUserRepository;
        public NormalUserViewModel()
        {
            _normalUserRepository = new NormalUserRepository();
        }
        public void AddNormalUser(int userId, int cod_users)
        {
            _normalUserRepository.addNormalUser(userId, cod_users);
        }
    }
}
