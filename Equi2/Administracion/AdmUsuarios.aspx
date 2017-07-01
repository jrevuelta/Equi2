﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmUsuarios.aspx.cs" Inherits="Equi2.Administracion.AdmUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administración de usuarios</title>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway"/>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
<style>
html,body,h1,h2,h3,h4,h5 {font-family: "Raleway", sans-serif}
</style>
</head>
<body class ="w3-light-gray">
    
        <!-- Top container -->
        <div class="w3-bar w3-top w3-black w3-large" style="z-index: 4">
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
    <p>Contenido administracion de usuarios</p>
    </div>

    </form>



    <script>
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
