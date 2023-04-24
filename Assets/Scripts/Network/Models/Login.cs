using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Network.Models
{
    internal class Login
    {
    }

    class LoginRequest
    {
        public string email { get; set; }
        public string code { get; set; }
    }

    class LoginResponse
    {
        public string message { get; set; }
        public string token { get; set; }
    }

    class GetCodeRequest
    {
        public string email { get; set; }
    }

    class GetCodeResponse
    {
        public int code { get; set;}
    }
}
