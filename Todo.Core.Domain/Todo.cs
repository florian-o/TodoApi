using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Domain
{
   public class Todo
    {
        public int idTodo { get; set; }
        public string todoName { get; set; }
        public bool todoStatus { get; set; } = false;
        public string description { get; set; }
        public bool isModif { get; set; } = false;
        public string image { get; set; }
        public DateTime todoDay { get; set; }
        public DateTime updatedAt { get; set; }
        public ApplicationUser User { get; set; }
        public string userId { get; set; }

    }
}
