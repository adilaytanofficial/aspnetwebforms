using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Project.Model
{
    public class User
    {

        private int id;
        private String name;
        private String surname;
        private String email;
        private String password;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}