using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Todo.Core.Domain
{
    public class ApplicationUser :IdentityUser
    {
       
        public string Fullname { get; set; }
        public DateTime Datebirth { get; set; }

       public virtual Address Address { get; set; }    
    
        [JsonIgnore]
        public List<Todo> Todos { get; set; }
    }
}
