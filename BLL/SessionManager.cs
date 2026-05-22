using System;
using BLL;

namespace Servicios
{
    public class SessionManager 
    {
        private static SessionManager _session;
        private static object _lock = new object();
        public Usuario usuario { get; private set; }
        public static SessionManager GetInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_session == null)
                    {
                        _session = new SessionManager();
                        return _session;
                    }
                    else
                    {
                        return _session;
                    }
                }
            }
        }

        public static void Login(Usuario usuario)
        {
            if (GetInstance.usuario != null)
            {
                throw new Exception("Ya existe una sesión iniciada");
            }

            GetInstance.usuario = usuario;
        }
        public static void Logout()
        {
            if (GetInstance.usuario == null)
            {
                throw new Exception("No hay sesión iniciada");
            }

            GetInstance.usuario = null;
        }
        private SessionManager()
        {
            usuario = null;
        }
    }
}