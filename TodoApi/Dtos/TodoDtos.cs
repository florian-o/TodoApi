using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Dtos
{
    public class TodoDtos
    {
        public int id { get; set; }
        public string todoName { get; set; }
        public bool todoStatus { get; set; } = false;
        public string description { get; set; }
        public bool isModif { get; set; } = false;
        public string image { get; set; }
        public DateTime todoDay { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
