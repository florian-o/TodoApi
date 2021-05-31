using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Domain
{
    
    public class Address
    {
        [Key]
        public int Id { get; set; }        
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }

        public virtual ApplicationUser User { get; set; }
        [ForeignKey("ApplicationUser")]
        public string adresseId { get; set; }

      





    }
}
