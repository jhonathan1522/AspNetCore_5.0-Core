using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Entities.DTO_S
{
    public class UserLoginResponseDto
    {
        public string Token { get; set; }

        public bool Login { get; set; }

        public List<string> Errors { get; set; }
    }
}
