<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalleEntrevista.aspx.cs" Inherits="Chilis.detalleEntrevista" %>
<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <link href="css/cssFormulario.css" rel="stylesheet" type="text/css" />
    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem Text="Franquicia" Value="Franquicia">
                    <asp:MenuItem Text="Seleccion Franquicia" Value="Seleccion Franquicia">
                        <asp:MenuItem Text="Actualizar Candidato" Value="Actualizar Candidato">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/actualizarsol.aspx" 
                            Text="Actualizar Solicitud Franquicia" Value="Actualizar Solicitud Franquicia">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/buscarSolEntrevista.aspx" 
                            Text="Actualizar Entrevista Candidato" Value="Actualizar Entrevista Candidato">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Implementacion Franquicia" Value="Actualizar Local">
                        <asp:MenuItem Text="Actualizar Solicitud Inicio de Implementacion" 
                            Value="Actualizar Solicitud Inicio de Implementacion"></asp:MenuItem>
                        <asp:MenuItem Text="Actualizar Tramites Municipales" 
                            Value="Actualizar Tramites Municipales"></asp:MenuItem>
                        <asp:MenuItem Text="Actualizar Local" Value="Actualizar Local"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Calidad" Value="Calidad"></asp:MenuItem>
                <asp:MenuItem Text="Adquisiciones" Value="Adquisiciones"></asp:MenuItem>
                <asp:MenuItem Text="Gestion Gerencial" Value="Gestion Gerencial"></asp:MenuItem>
                <asp:MenuItem Text="Eventos" Value="Eventos"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
     <div style="position: absolute; top: 53px; left: 386px;">
        <asp:Label ID="Label1" runat="server" Text="VER ENTREVISTA" 
             CssClass="Titulos"></asp:Label>
    </div>
     <div style="position: absolute; top: 140px; left: 90px;">
    <asp:Label ID="Label2" runat="server" Text="Nro. Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
      <div style="position: absolute; top: 182px; left: 90px;">
    <asp:Label ID="Label5" runat="server" Text="Candidato :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
       <div style="position: absolute; top: 98px; left: 87px;">
    <asp:Label ID="Label4" runat="server" Text="Fecha de Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
         <div style="position: absolute; top: 137px; left: 469px;">
    <asp:Label ID="Label6" runat="server" Text="Fecha Entrevista:" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 137px; left: 210px; width: 165px;">
        <asp:Label ID="LBLNROSOLICITUD" runat="server" CssClass="Etiquetas" ></asp:Label>
    </div>
    <div style="position: absolute; top: 180px; left: 210px; width: 215px;">
         <asp:Label ID="LBLCANDIDATO" runat="server" CssClass="Etiquetas" ></asp:Label>
    </div>
   
    <div style="position: absolute; top: 95px; left: 210px; width: 178px;">
        <asp:Label ID="LBLFECHASOLICITUD" runat="server" CssClass="Etiquetas" ></asp:Label>
    </div>
    
      <div style="position: absolute; top: 133px; left: 600px; width: 199px;">
       <asp:Label ID="LBLFECHAENTREVISTA" runat="server" CssClass="Etiquetas" ></asp:Label>
    </div>
    <div style="position: absolute; top: 270px; left: 88px; width: 789px; height: 192px;">
       <asp:GridView ID="gvlistado" runat="server" AutoGenerateColumns="False">
         <Columns>
             <asp:BoundField HeaderText="Nro" DataField="numeroOrden" />
             <asp:BoundField HeaderText="Criterio"  DataField="descripcion"/>
             <asp:TemplateField HeaderText="Descripcion">
                 <ItemTemplate>
                     <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"strvalor") %>' ReadOnly="true"></asp:TextBox>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <HeaderStyle CssClass="Cabecera" />
         <RowStyle CssClass="Cuerpo" />
    </asp:GridView>
    </div>
   
      <cc1:MsgBox ID="MsgBox1" runat="server" />
    <asp:HiddenField ID="hdnCategoria" runat="server" />
      <div style="position: absolute; top: 94px; left: 602px; width: 219px;">
       <asp:Label ID="LBLENTREVISTADOR" runat="server" CssClass="Etiquetas" ></asp:Label>
    </div>
         <div style="position: absolute; top: 95px; left: 486px;">
    <asp:Label ID="Label7" runat="server" Text="Entrevistador:" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
 
        <div style="position: absolute; top: 610px; left: 404px; width: 141px;">
        <asp:Button ID="Button3" runat="server" Text="Regresar" Width="132px" 
            onclick="btnRegresar_Click" CssClass="Botones" />
    </div>
    
     
      <div style="position: absolute; top: 247px; left: 87px;">
    <asp:Label ID="Label8" runat="server" Text="Ficha de entrevista:" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 487px; left: 92px;">
    <asp:Label ID="Label3" runat="server" Text="Comentario:" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
     <div style="position: absolute; top: 521px; left: 93px; height: 64px; width: 777px;">
        <asp:TextBox ID="txtcomentario" runat="server" Height="54px" 
            TextMode="MultiLine" Width="762px" ReadOnly="True"></asp:TextBox>
    </div>
    <asp:HiddenField ID="hdnCodSol" runat="server" />
      <asp:HiddenField ID="hdnFlag" runat="server" />
    </form>
</body>
</html>
