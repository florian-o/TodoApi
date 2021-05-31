using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace TodoApi.Dtos
{
    public class AuthUserDtos
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Todo.Core.Domain.Todo> userTodos { get; set; }
        public string token { get; set; }
      
        
    }
}
