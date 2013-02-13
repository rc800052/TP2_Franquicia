<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="actualizarsol.aspx.cs" Inherits="Chilis.actualizarsol" %>

<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/cssFormulario.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
    <div style="position: absolute; top: 52px; left: 33px;">
        <asp:Label ID="Label1" runat="server" Text="ACTUALIZAR SOLICITUD" 
            CssClass="Titulos"></asp:Label>
    </div>
     <div style="position: absolute; top: 97px; left: 91px;">
    <asp:Label ID="Label2" runat="server" Text="Tipo de Busqueda" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 95px; left: 218px; width: 199px;">
        <asp:DropDownList ID="ddlTipo" runat="server" Width="186px" CssClass="Combos">
            <asp:ListItem>SELECCIONE</asp:ListItem>
            <asp:ListItem>DNI</asp:ListItem>
            <asp:ListItem>RUC</asp:ListItem>
            <asp:ListItem>NOMBRES</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div style="position: absolute; top: 95px; left: 436px; width: 281px;">
        <asp:TextBox ID="txtBuscar" runat="server" Width="265px" 
            CssClass="CajasDeTexto"></asp:TextBox>
    </div>
    <div style="position: absolute; top: 93px; left: 728px; width: 141px;">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="132px" 
            onclick="btnBuscar_Click" CssClass="Botones" />
    </div>
    <div style="position: absolute; top: 179px; left: 92px; width: 789px; height: 329px;">
     <asp:GridView ID="gvlistado" runat="server" AutoGenerateColumns="False">
         <Columns>
             <%--<asp:TemplateField HeaderText="Candidato">
                 <ItemTemplate>
                     <asp:ImageButton ID="imgBtnEditar" runat="server" Height="22px" 
                         ImageUrl="~/img/editar.png" Width="20px" />
                     <asp:ImageButton ID="imgBtnCerrar" runat="server" Height="22px" 
                         ImageUrl="~/img/btn_cerrar.gif" Width="19px" />
                 </ItemTemplate>
             </asp:TemplateField>--%>
             <asp:BoundField HeaderText="Nombres" DataField="nombre" />
             <asp:BoundField HeaderText="Documento" DataField="numeroDocumento" />
             <asp:BoundField HeaderText="Tipo" DataField="tipoDocumento" />
             <asp:TemplateField HeaderText="Solicitud">
                 <ItemTemplate>
                     <asp:HyperLink ID="HyperLink1" runat="server"  text="Nueva Solicitud" NavigateUrl='<%#"detallesol.aspx?id=" + DataBinder.Eval(Container.DataItem,"FQ_Candidato_ID") + "&fl=N" %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server"  text="VerSolicitudes" NavigateUrl='<%#"consultasol.aspx?id=" + DataBinder.Eval(Container.DataItem,"FQ_Candidato_ID") %>'></asp:HyperLink>
                    <%-- <asp:LinkButton ID="LinkButton1" runat="server" text="Nueva Solicitud" NavigateUrl="detallesol.aspx?id=1">
                     </asp:LinkButton>
                     <asp:Button ID="btnNuevaSolicitud" runat="server" Text="Nueva Solicitud"  OnClick="NuevaSolicitud_Click" />
                     <asp:Button ID="btnVerSol" runat="server" Text="VerSolicitudes"  OnClick="VerSolicitudes_Click"/>--%>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <HeaderStyle CssClass="Cabecera" />
         <RowStyle CssClass="Cuerpo" />
    </asp:GridView>
    </div>
    <div style="position: absolute; top: 544px; left: 326px;">
        <asp:Button ID="btnNuevoCandidato" runat="server" Text="Actualizar Candidato" 
            onclick="btnNuevoCandidato_Click" CssClass="Botones" />
    </div>
    <div style="position: absolute; top: 544px; left: 563px; width: 149px;">
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" Width="137px" 
            CssClass="Botones" />
    </div>
    <div style="position: absolute; top: 195px; left: 894px;">
        <asp:Button ID="btnExportar" runat="server" Text="Exportar Excel" 
            onclick="btnExportar_Click" CssClass="Botones" />
    </div>
    <cc1:MsgBox ID="MsgBox1" runat="server" />
    </form>
</body>
</html>
