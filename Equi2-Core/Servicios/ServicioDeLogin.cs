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

        /// <summary>
        /// Recupera un usuario por su Identificador
        /// </summary>
        /// <param name="idUsuario">int - Identificador del usuario</param>
        /// <returns>UsuarioVO - Contiene la información del usuario</returns>
        public UsuarioVO obtenerUsuarioPorID (int idUsuario)
        {
            UsuarioVO usuario = usuarioDAO.recuperarUsuario(idUsuario);
            return usuario;
        }

        /// <summary>
        /// Obtiene un usuario a traves de su nombre de usuario
        /// </summary>
        /// <param name="login">String - Nombre de usuario</param>
        /// <returns>UsuarioVO - Contiene la información de un usuario</returns>
        public UsuarioVO obtenerUsuarioPorLogin (string login)
        {
            UsuarioVO usuario = usuarioDAO.recuperarUsuarioPorLogin(login);
            return usuario;
        }

        /// <summary>
        /// Obtiene todos los usuarios de la base de datos
        /// </summary>
        /// <returns>List<UsuarioVO> listado de usuarios</returns>
        public List<UsuarioVO> obtenerTodosLosUsuarios()
        {
            List<UsuarioVO> listaDeUsuarios = usuarioDAO.obtenerTodosUsuarios();
            return listaDeUsuarios;
        }

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <param name="usuario">UsuarioVO - Contiene la información a guardar del usuario</param>
        /// <returns>int - Numero de registros afectados</returns>
        public int actualizarDatosDeUsusario (UsuarioVO usuario)
        {
            int retorno = usuarioDAO.actualizarDatosUsuario(usuario);
            return retorno;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos a partir de los datos pasados como parámetros
        /// </summary>
        /// <param name="usuario">UsuarioVO - Contiene la información de un usuario</param>
        /// <returns>int - Numero de usuarios creados</returns>
        public int crearNuevoUsuario (UsuarioVO usuario)
        {
            int retorno = usuarioDAO.altaUsuario(usuario);
            return retorno;
        }
    }
}
