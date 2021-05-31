using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Infrastructures.Configuration
{
   public class ApplicationSettings
    {
        public string JWt_Secret { get; set; }
        public string Client_Url { get; set; }
    }
}
