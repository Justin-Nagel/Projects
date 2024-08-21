using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PRG282.LogicLayer
{
    internal class User
    {
        string username, password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public User() { }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return $"{username}:{password}";
        }
    }
}
