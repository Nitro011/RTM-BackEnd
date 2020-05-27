using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models
{
   public class Request
    {

        public bool status { get; set; }
        public string message { get; set; }

        public object data { get; set; }

    }
}
