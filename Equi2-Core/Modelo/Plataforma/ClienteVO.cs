using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equi2_Core.Modelo.Plataforma
{
    class ClienteVO
    {
        int idCliente;
        List<VeterinarioVO> listaVeterinarios;
        DatosEmpresaVO datosEmpresa;
        ClienteTipoVO clienteTipo;
        string clienteNombre;
        string clienteDireccion;
        string clienteLocalidad;
        ProvinciaVO clienteProvincia;
        string clienteNif;
        string clienteTelefono;
        string clienteTelefMovil;
        string clienteFax;
        string clienteMail;
        string facturaNombre;
        string facturaDireccion;
        string facturaLocalidad;
        ProvinciaVO facturaProvincia;
        string facturaCP;
        string facturaTelefono;
        string facturaFax;
        string facturaMail;
        string facturaNIF;
        IrpfVO facturaIRPF;
        IvaVO facturaIVA;
        string contacto;
        string personaContacto;
        string ttelefonoContacto;
        string observaciones;

    }
}
