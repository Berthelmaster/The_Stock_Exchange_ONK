using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserController.DTO
{
    public class LoginDto
    {
        LoginDto()
        {

        }

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
