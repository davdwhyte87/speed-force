using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Network.Models
{
    internal class Signup
    {
    }


    class SignupRequest
    {
        public string email { get; set; }
        public string name { get; set; }
        public string user_type { get; set; }
    }

    class SignupResponse
    {
        public string message { get; set; }
    }
}
