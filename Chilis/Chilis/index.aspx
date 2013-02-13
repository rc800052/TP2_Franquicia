<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Chilis.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
    </div>
    </form>
</body>
</html>
