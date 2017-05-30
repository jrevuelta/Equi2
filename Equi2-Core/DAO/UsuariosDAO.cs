using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.DAO
{
    class UsuariosDAO
    {
        private Configuracion conf;

        public UsuariosDAO()
        {
            conf = new Configuracion();
        }

        // Recuperar usuario
        public UsuarioVO recuperarUsuario (int idUsuario)
        {
            UsuarioVO usuario = null;
            // TODO: Recuperar un usuario por su identificador
            return usuario;
        }

        public List<UsuarioVO> obtenerTodosUsuarios()
        {
            List<UsuarioVO> listaDeUsuarios = null;
            // TODO Obtener todos los usuarios.
            return listaDeUsuarios;
        }

        /// <summary>
        /// Obtiene un Objeto UsuarioVO mediante su nombre de usuario
        /// </summary>
        /// <param name="nombre"> String con el nombre de usuario o login</param>
        /// <returns>UsuarioVO - Contiene la información de un usuario. Si no existe el usuario devuelve NULL</returns>
        public UsuarioVO recuperarUsuarioPorLogin(string nombre)
        {
            UsuarioVO usuario = null;

            String sql = "Select id_usuario,usuario,password,borrado from usuarios where usuario='" + nombre + "' and borrado = false";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(conf, 4, sql);

            foreach (object o in resultado)
            {
                usuario = new UsuarioVO();
                object[] array = (object[])o;
                usuario.usuario = (string)array[1];
                usuario.password = (string)array[2];
            }

            return usuario;

        }
    }
}
