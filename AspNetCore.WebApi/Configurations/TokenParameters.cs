using AspNetCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WebApi.Configurations
{
    public class TokenParameters : ITokenParameters
    {
        public string Username { get ; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
    }
}
