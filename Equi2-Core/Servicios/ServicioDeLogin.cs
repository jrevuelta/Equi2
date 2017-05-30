using Equi2_Core.DAO;
using Equi2_Core.Modelo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.Servicios
{
    public class ServicioDeLogin
    {
        private UsuariosDAO usuarioDAO;

        public ServicioDeLogin()
        {
            usuarioDAO = new UsuariosDAO();
        }
        
        /// <summary>
        /// Comprueba si los parámetros de entrada se corresponden con los datos guardados en la base de datos
        /// </summary>
        /// <param name="login">String - nombre de usuario o login</param>
        /// <param name="password">String - contraseña</param>
        /// <returns>True si los datos son correctos. False si son incorrectos</returns>
        public bool esLoginCorrecto(string login, string password){
            bool correcto = false;

            UsuarioVO usuario = usuarioDAO.recuperarUsuarioPorLogin(login);

            correcto = usuario != null && usuario.usuario.Equals(login) && usuario.password.Equals(password);

            return correcto;
        }
    }
}
