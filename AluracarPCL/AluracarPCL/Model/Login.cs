using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluracarPCL.Model
{
    public class Login
    {
        public Login(string usuario, string senha)
        {
            Email = usuario;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
