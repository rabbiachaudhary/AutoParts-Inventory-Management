using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    internal class credentialsBL
    {
        public string Username;
        public string Password;
        public string Role;

        public credentialsBL(string user,string pass,string role) 
        {
            Username=user;
            Password=pass;
            Role=role;

        }

        public Views.Login Login
        {
            get => default;
            set
            {
            }
        }
    }
}
