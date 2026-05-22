using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginService
    {

        Dictionary<string, string> usuarios = new Dictionary<string, string>
        {
            { "candela", "britos" },
            { "matias", "franco" },
            { "pablo", "cruz" },
        };

        public Usuario Login(string username, string password)
        {
            if (usuarios.ContainsKey(username) && usuarios[username] == password)
            {
                return new Usuario { Username = username };
            }
            else
            {
                return null;
            }
        }
    }
}
