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


        public List<UsuarioVO> obtenerTodosUsuarios()
        {
            List<UsuarioVO> listaDeUsuarios = new List<UsuarioVO>();
            String sql = "Select usuario,contrasena,admin,email,telefono,id_usuario,borrado from usuarios";
            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(conf, 7, sql);
            UsuarioVO usuario = null;
            foreach (object[] o in resultado)
            {
                usuario = crearUsuario(o);
                listaDeUsuarios.Add(usuario);
            }

            return listaDeUsuarios;
        }

        // Recuperar usuario
        public UsuarioVO recuperarUsuario(int idUsuario)
        {
            UsuarioVO usuario = null;
            String sql = "Select usuario,contrasena,admin,email,telefono,id_usuario,borrado from usuarios where id_usuario=" + idUsuario;

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(conf, 7, sql);
            if (resultado.Count > 0)
            {
                usuario = crearUsuario((object[])resultado[0]);
            }
            return usuario;
        }


        /// <summary>
        /// Obtiene un Objeto UsuarioVO mediante su nombre de usuario
        /// </summary>
        /// <param name="nombre"> String con el nombre de usuario o login</param>
        /// <returns>UsuarioVO - Contiene la información de un usuario. Si no existe el usuario devuelve NULL</returns>
        public UsuarioVO recuperarUsuarioPorLogin(string nombre)
        {
            UsuarioVO usuario = null;
            String sql = "Select usuario,contrasena,admin,email,telefono,id_usuario,borrado from usuarios where usuario='" + nombre + "' and borrado = false";

            List<object> resultado = UtilidadesBaseDatos.consultaSelectListaMultiple(conf, 7, sql);
            if (resultado.Count > 0)
            {
                usuario = crearUsuario((object[])resultado[0]);
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

            string sql = "update usuarios set  contrasena = '" + usuario.getPasswordEncriptada() + "', telefono = '"+usuario.telefono+"', email = '"+usuario.email+ "', admin ="+usuario.admin+", borrado="+usuario.borrado+" where id_usuario = " + usuario.idUsuario;
            datosGuardados = UtilidadesBaseDatos.insertRow(conf, sql);

            return datosGuardados;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos de usuarios, la cual tiene que tener una base de
        /// datos asociada en una carpeta con el mismo nombre
        /// </summary>
        /// <param name="usuario">UsuarioVO - Contiene la información del usuario</param>
        /// <returns>int - Numero de registros creadaos</returns>
        public int altaUsuario(UsuarioVO usuario)
        {
            int datosGuardados = 0;

            string sql = "insert into usuarios (usuario,contrasena,borrado,admin,email,telefono) values ('" + usuario.usuario + "','" + usuario.getPasswordEncriptada() + "'," + usuario.borrado + "," + usuario.admin + ",'" + usuario.email + "','" + usuario.telefono + "')";
            datosGuardados = UtilidadesBaseDatos.insertRow(conf, sql);
            return datosGuardados;
        }

        /// <summary>
        /// Crea un objeto UsuarioVO a partir de la información del array
        /// </summary>
        /// <param name="array">object[] - contiene la información extraida de la base de datos</param>
        /// <returns>UsuarioVO - Contiene la infomación del usuario</returns>
        private UsuarioVO crearUsuario(object[] array)
        {
            UsuarioVO usuario = new UsuarioVO();
            usuario.usuario = (string)array[0];
            string passDesencriptada = Encriptacion.DesEncriptar((string)array[1]);
            usuario.password = passDesencriptada;
            usuario.admin = (bool)array[2];
            usuario.email = array[3].ToString();// Utilizo toString() porque este campo puede ir a nulo
            usuario.telefono = array[4].ToString();
            usuario.idUsuario = (int)array[5];
            usuario.borrado = (bool)array[6];
            return usuario;
        }
    }
}
