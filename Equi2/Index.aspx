<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Equi2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Equi2  Login</title>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" class="w3-container" runat="server">
    
        <h2 class="w3-center">Acceso a la plataforma</h2>
   
        <div class="">
            <asp:Panel ID="panelError" runat="server" CssClass="w3-panel w3-red w3-display-container" Visible="False">
                <span onclick="this.parentElement.style.display='none'"
                class="w3-button w3-red w3-large w3-display-topright">&times;</span>
               <h2><asp:Label ID="lblMensajeError" runat="server" Text="Label"></asp:Label></h2> 
            </asp:Panel>
        </div>
        <div class="w3-row w3-section">
            <div class="w3-rest">
                <label class="w3-text-blue"><b>Nombre de usuario:</b></label>
                <asp:TextBox ID="inpUsuario" CssClass="w3-input w3-border" runat="server"></asp:TextBox>
                <label class="w3-text-blue"><b>Contraseña:</b></label>
                <asp:TextBox ID="inpPassword" CssClass="w3-input w3-border" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="btnAceptar" CssClass="w3-button w3-block w3-section w3-blue w3-ripple w3-padding" runat="server" Text="Enviar" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
