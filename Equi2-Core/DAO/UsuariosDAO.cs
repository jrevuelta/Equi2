using Equi2.Utilidades;
using Equi2_Core.Modelo.VO;
using Equi2_Core.Utilidades;
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
            
            String sql = "Select usuario,contrasena,admin,email,telefono,id_usuario from usuarios where usuario='" + nombre + "' and borrado = false";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(conf, 6, sql);

            foreach (object o in resultado)
            {
                usuario = new UsuarioVO();
                object[] array = (object[])o;
                usuario.usuario = (string)array[0];
                string passDesencriptada = Encriptacion.DesEncriptar((string)array[1]);
                usuario.password = passDesencriptada;
                usuario.admin = (bool)array[2];
                usuario.email = array[3].ToString();// Utilizo toString() porque este campo puede ir a nulo
                usuario.telefono = array[4].ToString();
                usuario.idUsuario = (int)array[5];
            }
            return usuario;
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos Equi2
        /// </summary>
        /// <param name="usuario">UsuarioVO - contiene los datos de un usuario modificados</param>
        /// <returns>int - número de filas que se han actualizado</returns>
        public int actualizarDatosUsuario (UsuarioVO usuario)
        {
            int datosGuardados = 0;

            string sql = "update usuarios set  contrasena = '" + usuario.password + "', telefono = '"+usuario.telefono+"', email = '"+usuario.email+"' where id_usuario = " + usuario.idUsuario;
            datosGuardados = UtilidadesBaseDatos.insertRow(conf, sql);

            return datosGuardados;
        }
    }
}
