<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificacion.aspx.cs" Inherits="Chilis.notificacion" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/cssFormulario.css" rel="stylesheet" type="text/css" />
</head>
<body>
  
    <form id="form1" runat="server">
    <div style="position: absolute; top: 100px; left: 75px; width: 199px; height: 22px;" >
        <asp:Label ID="lblTitulo" runat="server" CssClass="EtiquetasImportantes"></asp:Label>
    </div>
 <div style="position: absolute; top: 53px; left: 386px;">
        <asp:Label ID="Label1" runat="server" Text="NOTIFICACION" 
             CssClass="Titulos"></asp:Label>
    </div>
     <div style="position: absolute; top: 236px; left: 74px; bottom: 183px;">
    <asp:Label ID="Label2" runat="server" Text="Candidato :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
      <div style="position: absolute; top: 315px; left: 78px;">
    <asp:Label ID="lblComentario" runat="server" ></asp:Label>
    </div>
       <div style="position: absolute; top: 145px; left: 73px;">
    <asp:Label ID="Label4" runat="server" Text=" Fecha de Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
         <div style="position: absolute; top: 142px; left: 503px;">
    <asp:Label ID="Label6" runat="server" Text="Entrevistador :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 144px; left: 212px; width: 199px;">
        <asp:Label ID="LBLFECHASOLICITUD" runat="server" ></asp:Label>
    </div>
    <div style="position: absolute; top: 198px; left: 476px;">
    <asp:Label ID="Label3" runat="server" Text="Fecha de Entrevista :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 142px; left: 626px; width: 176px;">
        <asp:Label ID="LBLENTREVISTADOR" runat="server" ></asp:Label>
    </div>
    <div style="position: absolute; top: 191px; left: 211px; width: 199px;">
        <asp:Label ID="LBLNROSOLICITUD" runat="server" ></asp:Label>
    </div>
    <div style="position: absolute; top: 419px; left: 420px; width: 141px;">
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="132px" 
            CssClass="Botones" onclick="btnAceptar_Click" />
    </div>
      <div style="position: absolute; top: 197px; left: 624px; width: 199px;">
          <asp:Label ID="LBLFECHAENTREVISTA" runat="server" ></asp:Label>
    </div>
     <div style="position: absolute; top: 233px; left: 211px; width: 199px;">
        <asp:Label ID="LBLCANDIDATO" runat="server" ></asp:Label>
    </div>
   
      <cc1:MsgBox ID="MsgBox1" runat="server" />
    <asp:HiddenField ID="hdnCategoria" runat="server" />
     <div style="position: absolute; top: 195px; left: 73px;">
    <asp:Label ID="Label7" runat="server" Text="Nro. Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <asp:HiddenField ID="hdnCodSol" runat="server" />
     <asp:HiddenField ID="hdnFlag" runat="server" />
    </form>
</body>
</html>
