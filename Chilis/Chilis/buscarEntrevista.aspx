<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscarEntrevista.aspx.cs" Inherits="Chilis.buscarEntrevista1" %>
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
     <div style="position: absolute; top: 53px; left: 386px;">
        <asp:Label ID="Label1" runat="server" Text="BUSCAR ENTREVISTA " 
             CssClass="Titulos"></asp:Label>
    </div>
     <div style="position: absolute; top: 95px; left: 113px;">
    <asp:Label ID="Label2" runat="server" Text="Nro. Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
      
       <div style="position: absolute; top: 136px; left: 77px;">
    <asp:Label ID="Label4" runat="server" Text="Fecha Entrevista De :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
         <div style="position: absolute; top: 183px; left: 82px;">
    <asp:Label ID="Label6" runat="server" Text="Estado de Solicitud :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 179px; left: 215px; width: 188px;">
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="Combos">
            <asp:ListItem>APROBADA</asp:ListItem>
            <asp:ListItem>RECHAZADA</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div style="position: absolute; top: 141px; left: 427px;">
    <asp:Label ID="Label3" runat="server" Text="Fecha de Entrevista Hasta :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
    <div style="position: absolute; top: 92px; left: 585px; width: 217px;">
         <asp:TextBox ID="txtCandidato" runat="server" Width="210px" 
            CssClass="CajasDeTexto"></asp:TextBox>
    </div>
    <div style="position: absolute; top: 93px; left: 213px; width: 199px;">
        <asp:TextBox ID="txtNroSolicitud" runat="server" Width="193px"></asp:TextBox>
    </div>
    <div style="position: absolute; top: 179px; left: 709px; width: 141px;">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="132px" 
            onclick="btnBuscar_Click" CssClass="Botones" />
    </div>
      <div style="position: absolute; top: 136px; left: 586px; width: 169px;">
          <asp:TextBox ID="txtFechaFin" runat="server" Width="129px"></asp:TextBox>
    </div>
    <div style="position: absolute; top: 179px; left: 709px; width: 141px;">
        <asp:Button ID="Button4" runat="server" Text="Buscar" Width="132px" 
            onclick="btnBuscar_Click" CssClass="Botones" />
    </div>
    <div style="position: absolute; top: 262px; left: 97px; width: 789px; height: 215px;">
    <asp:GridView ID="gvlistado" runat="server" AutoGenerateColumns="False">
         <Columns>
             <asp:TemplateField HeaderText="Solicitud">
                 <ItemTemplate>
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/lupa.png" OnClick="imgBtnVer_Click" />
                  <asp:Label ID="lblSolicitud" runat="server" visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"SolCodSolicitud") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField HeaderText="Fecha Entrevista"  DataField="SolStrFechaEntrevista"/>
             <asp:BoundField HeaderText="Nro Solicitud" DataField="SolCodigo" />
             <asp:BoundField HeaderText="Candidato"  DataField="SolNombre"/>
             <asp:BoundField HeaderText="Estado"  DataField="SolEstados"/>
         </Columns>
         <HeaderStyle CssClass="Cabecera" />
         <RowStyle CssClass="Cuerpo" />
    </asp:GridView>
   
    </div>
   
      <cc1:MsgBox ID="MsgBox1" runat="server" />
    <asp:HiddenField ID="hdnCategoria" runat="server" />
     
    <div style="position: absolute; top: 135px; left: 215px; width: 188px;">
        <asp:TextBox ID="txtFechaInicio" runat="server" Width="129px"></asp:TextBox>
    </div>
     
         <div style="position: absolute; top: 95px; left: 478px;">
    <asp:Label ID="Label7" runat="server" Text="Candidato :" 
             CssClass="EtiquetasImportantes"></asp:Label>
    </div>
     
    <div style="position: absolute; top: 489px; left: 460px; width: 194px;">
        <asp:Button ID="btnRegresar" runat="server" Text="REGRESAR" Width="125px" 
             CssClass="Botones" onclick="btnRegresar_Click" />
    </div>
     
    </form>
</body>
</html>
