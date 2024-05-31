using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.Repositories
{
    interface INormalUserRepository
    {
        public void addNormalUser(int normalUserId, int userId);
        public int findMaxId1();
        public bool deleteNormalUser(int userId);
    }
}
