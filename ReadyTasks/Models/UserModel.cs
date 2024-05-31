using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string from_Google { get; set; }
    }
}
