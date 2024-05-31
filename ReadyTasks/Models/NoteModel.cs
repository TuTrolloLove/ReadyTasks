using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.Models
{
   public class NoteModel
    {
        public int id { get; set; }
        public int id_users { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string priority { get; set; }
        public string completed { get; set; }

        public override string ToString()
        {
            return "id: " + id + " id_users: " + id_users + " title: " + title + " body: " + body + " priority: " + priority + " completed: " + completed;
        }
    }
}
