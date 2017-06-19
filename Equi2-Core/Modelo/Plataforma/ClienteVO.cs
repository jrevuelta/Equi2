using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.Modelo.Plataforma
{
    public class ClienteVO
    {
        public int idCliente;
        public VeterinarioVO veterinario;
        public DatosEmpresaVO datosEmpresa;
        public ClienteTipoVO clienteTipo;
        public string clienteNombre;
        public string clienteDireccion;
        public string clienteLocalidad;
        public ProvinciaVO clienteProvincia;
        public string clienteCP;
        public string clienteNif;
        public string clienteTelefono;
        public string clienteTelefMovil;
        public string clienteFax;
        public string clienteMail;
        public string facturaNombre;
        public string facturaDireccion;
        public string facturaLocalidad;
        public ProvinciaVO facturaProvincia;
        public string facturaCP;
        public string facturaTelefono;
        public string facturaFax;
        public string facturaMail;
        public string facturaNIF;
        public IrpfVO facturaIRPF;
        public IvaVO facturaIVA;
        public string contacto;
        public string personaContacto;
        public string telefonoContacto;
        public string observaciones;

    }
}
