using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class User
    {
        public int id_user { get; set; }
        public string Username { get; set; }
        public Boolean estado { get; set; }

    }

    public class UserLogIn
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
