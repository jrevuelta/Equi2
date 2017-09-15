using Equi2_Core.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.Modelo.VO
{
    public class UsuarioVO
    {
        public int idUsuario;
        public string usuario;
        public string password;
        public bool admin;
        public string email;
        public string telefono;
        public bool borrado;


        public string getBorrado()
        {
            if (borrado)
            {
                return "Si";
            }
            else
            {
                return "No";
            }
        }

        public string getAdmin()
        {
            if (admin)
            {
                return "Si";
            }
            else
            {
                return "No";
            }
        }

        public string getPasswordEncriptada()
        {
            return Encriptacion.Encriptar(password);
        }

        public void setPasswordDesEncriptada(string pwdEncriptada)
        {
            this.password = Encriptacion.DesEncriptar(pwdEncriptada);
        }
    }
}
