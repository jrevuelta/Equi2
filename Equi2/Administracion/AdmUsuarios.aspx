<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmUsuarios.aspx.cs" Inherits="Equi2.Administracion.AdmUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administración de usuarios</title>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway"/>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/dataTables.jqueryui.min.css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <script type="text/javascript" src="../js/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.min.js"></script>

<style>
html,body,h1,h2,h3,h4,h5 {font-family: "Raleway", sans-serif}
</style>
</head>
<body class ="w3-light-gray">
    
        <!-- Top container -->
        <div class="w3-bar w3-top w3-brown w3-large" style="z-index: 4">
            <button class="w3-bar-item w3-button w3-hide-large w3-hover-none w3-hover-text-light-grey" onclick="w3_open();"><i class="fa fa-bars"></i>Menu</button>
            <span class ="w3-bar-item w3-center">Equi2 - Administración usuarios</span>
            <span class="w3-bar-item w3-right">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="w3-bar-item w3-button w3-right" NavigateUrl="~/Index.aspx" ToolTip="Cerrar sesión"><i class="fa fa-sign-in"></i></asp:HyperLink>
            </span>
        </div>

        <!-- Sidebar/menu -->
<nav class="w3-sidebar w3-collapse w3-white w3-animate-left" style="z-index:3;width:300px;" id="mySidebar">
    <br/>
  <div class="w3-container w3-row">
    <div class="w3-col s4">
     
    </div>
    <div class="w3-col s8 w3-bar">
        <asp:Label ID="lblNombreUsuario" runat="server" Text="---"></asp:Label><br />
     <!-- Botón de configuración del usuario -->
      <a href="#" class="w3-bar-item w3-button"><i class="fa fa-cog"></i></a>

    </div>
  </div>
  <hr/>
  <div class="w3-container">
    <h5>Menú</h5>
  </div>
  <div class="w3-bar-block">
    <a href="#" class="w3-bar-item w3-button w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black" onclick="w3_close()" title="close menu"><i class="fa fa-remove fa-fw"></i>  Cerrar Menú</a>
      <a href="Index.aspx" class="w3-bar-item w3-button w3-padding"><i class="fa fa-home fa-fw"></i>  Inicio</a>
      <a href="AdmUsuarios.aspx" class="w3-bar-item w3-button w3-padding w3-blue"><i class="fa fa-users fa-fw"></i>  Usuarios</a>
    <br/><br/>
  </div>
</nav>
        
<!-- Overlay effect when opening sidebar on small screens -->
<div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

   <form id="form1" runat="server">     
<!-- !PAGE CONTENT! -->
<div class="w3-main" style="margin-left:300px;margin-top:55px;">
    
    <div id="pnlUsuario" class ="w3-modal">
        <div class="w3-modal-content">
            <header class="w3-container w3-teal">
                <span onclick="cerrarPanelALtaEdicion()" class="w3-closebtn w3-xlarge w3-right">&times;</span>
                <h2>Alta / Modificación de usuario:</h2>
            </header>
            <div class="w3-container">
                <div class ="w3-row">
                    <div class="w3-col s2">Id. Usuario:</div>
                    <div class="w3-col s10"><input type ="text" readonly="true" id="txtIdUsuario" value="-Nuevo-"/></div>
                </div>
                <div class ="w3-row">
                    <div class="w3-col s2">Usuario:</div>
                    <div class="w3-col s10"><input type="text" id="txtUsuario" value="--"/></div>
                </div>
                <div class ="w3-row">
                    <div class="w3-col s2">Contraseña:</div>
                    <div class="w3-col s10"><input type="password" id="txtContrasena" value=""/></div>
                </div>
                <div class ="w3-row">
                    <div class="w3-col s2">E-Mail:</div>
                    <div class="w3-col s10"><input type="text" id="txtEmail" value="--"/> </div>
                </div>
                 <div class ="w3-row">
                    <div class="w3-col s2">Teléfono:</div>
                    <div class="w3-col s10"><input type="text" id="txtTelefono" value="--"/> </div>
                </div>
                <div class ="w3-row">
                    <div class="w3-col s2">Admin</div>
                    <div class="w3-col s10"><input type="checkbox" id="chkAdmin"/></div>
                </div>
                 <div class ="w3-row">
                    <div class="w3-col s2"><p>Borrado</p></div>
                    <div class="w3-col s10"><p><input type="checkbox" id="chkBorrado"/></p></div>
                </div>

            </div>
            <footer class="w3-container w3-teal w3-center">
                <button class="w3-button w3-green" onclick="guardarDatos()">Guardar</button>
                <button type="button" class="w3-button w3-red" onclick="cerrarPanelALtaEdicion()">Cancelar</button>
                
            </footer>
        </div>

    </div>

        <div class="w3-padding">
            <div class="w3-card-4  w3-round-medium">
            <header class="w3-container w3-blue-gray">
             <h3>Listado de usuarios:</h3>
            </header>
            <div class="w3-container">
                <asp:Table ID="tblUsuarios" CssClass="display" runat="server"></asp:Table>
                
            </div>
                <footer class="w3-container">
                    <button type ="button" class="w3-button w3-block w3-blue-gray w3-right" onclick="document.getElementById('pnlUsuario').style.display = 'block';">Nuevo</button>
                </footer>
            
            </div>
        </div>
        
        
    </div>
    
  

    </form>



<script>
    function guardarDatos () {
        
        var id = $('#txtIdUsuario').val();
        if (isNaN(id)){
            id = 0;
        }

        var parametros = {       
            idUsuario : id,
            usuario : $('#txtUsuario').val(),
            contrasena :  $('#txtContrasena').val(),
            email : $('#txtEmail').val(),
            telefono :$('#txtTelefono').val(),
            admin :document.getElementById("chkAdmin").checked,
            borrado : document.getElementById("chkBorrado").checked
        };
        
        $.ajax({
            type: "POST",
            url: "AdmUsuarios.aspx/AltaModificacionUsuarios",
            data: JSON.stringify(parametros),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
               
                if (data.d == "0") {
                    alert("Los datos no se han guardado");
                }
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });

      
    }

    /*
    Cierra el panel de edicion y limpia los campos
    */
    function cerrarPanelALtaEdicion() {
        $('#txtIdUsuario').val("");
        $('#txtUsuario').val("");
        $('#txtEmail').val("");
        $('#txtTelefono').val("");
        $('#txtContrasena').val("");
        document.getElementById("chkAdmin").checked = false;
        document.getElementById("chkBorrado").checked = false;
        document.getElementById('pnlUsuario').style.display = 'none';
    }

    $(document).ready(function () {
        // Inicializa la tabla de usuarios cuando el documento cargue
        var tablaUsuarios = $('#tblUsuarios').DataTable({ "order": [[0, "asc"]] });

        var filaSeleccionada;
        
        $('#tblUsuarios tbody').on('click', 'tr', function () {
            tablaUsuarios.$('tr.selected').removeClass('selected');
            $(this).toggleClass('selected');
            document.getElementById('pnlUsuario').style.display = 'block';
            var datos = tablaUsuarios.row(this).data();
            filaSeleccionada = tablaUsuarios.row(this).index;
            // TODO: poner la informacion en los inputs como en el ejemplo
            // los datos numéricos van con "val()" y las cadenas con "html()"
            $('#txtIdUsuario').val(datos[0]);
            $('#txtUsuario').val(datos[1]);
            $('#txtEmail').val(datos[2]);
            $('#txtTelefono').val(datos[3]);         
            document.getElementById("chkAdmin").checked = (datos[4] == "Si");
            document.getElementById("chkBorrado").checked = (datos[5] == "Si");   
        })
    });
// Get the Sidebar
var mySidebar = document.getElementById("mySidebar");

// Get the DIV with overlay effect
var overlayBg = document.getElementById("myOverlay");

// Toggle between showing and hiding the sidebar, and add overlay effect
function w3_open() {
    if (mySidebar.style.display === 'block') {
        mySidebar.style.display = 'none';
        overlayBg.style.display = "none";
    } else {
        mySidebar.style.display = 'block';
        overlayBg.style.display = "block";
    }
}

// Close the sidebar with the close button
function w3_close() {
    mySidebar.style.display = "none";
    overlayBg.style.display = "none";
}
</script>
</body>
</html>
