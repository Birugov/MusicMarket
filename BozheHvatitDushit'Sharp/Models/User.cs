using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushit_Sharp.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userMail { get; set; }
        public string Address { get; set; }
        public Purchase purchase { get; set; }

    }
}
