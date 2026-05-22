using System.Collections.Generic;

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

        public void Login(string username, string password)
        {
            if (usuarios.ContainsKey(username) && usuarios[username] == password)
            {
                Usuario usuario = new Usuario { Username = username };
                SessionManager.Login(usuario);
            }
        }
    }
}
