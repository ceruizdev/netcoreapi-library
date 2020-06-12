using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Authentication
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; } = "bearer";
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
