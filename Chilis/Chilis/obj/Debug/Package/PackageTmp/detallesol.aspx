<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detallesol.aspx.cs" Inherits="Chilis.detallesol" %>

<%@ Register Assembly="MsgBox" Namespace="MsgBox" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <style type="text/css">
        .style2
        {
            width: 196px;
        }
    </style>
  <link rel="stylesheet" type="text/css" href="css/cssFormulario.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="height: 126px; width: 1000px" >
    <tr>
    <td align="center">
        <asp:Label ID="lbltitulo" runat="server"  CssClass="Titulos"></asp:Label></td>
    </tr>
    <tr>
    <td>
     <table  border="1" cellpadding="0" cellspacing="0" class="Tabla" style="width: 97%;">
            <tr class="Celda">
                <td >
                    Nombre</td>
                <td colspan="4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="95%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Domicilio</td>
                <td colspan="4">
                    <asp:TextBox ID="txtDomicilio" runat="server"  Width="95%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Nacionalidad</td>
                <td colspan="2">
                    <asp:TextBox ID="txtNacionalidad" runat="server"  Width="94%" 
                        BackColor="#DFDFDF" ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Tipo de Documento</td>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="Combos" 
                        BackColor="#DFDFDF" ReadOnly="True" Enabled="False">
                        <asp:ListItem>DNI</asp:ListItem>
                        <asp:ListItem>RUC</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Telefono</td>
                <td colspan="2">
                    <asp:TextBox ID="txtTelefono" runat="server"  Width="97%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;Nº de Documento</td>
                <td>
                    <asp:TextBox ID="txtPasaporte" runat="server"  Width="45%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Email</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmail" runat="server"  Width="89%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Celular</td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server"  Width="97%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Pág. Web</td>
                <td colspan="2">
                    <asp:TextBox ID="txtWeb" runat="server"  Width="97%" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    CODIGO</td>
                <td colspan="2">
                    <asp:TextBox ID="txtcodigosol" runat="server" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    FECHA</td>
                <td>
                    <asp:TextBox ID="txtfechasol" runat="server" BackColor="#DFDFDF" 
                        ReadOnly="True" CssClass="CajasDeTexto"></asp:TextBox>
                &nbsp; (dd/mm/yyyy)</td>
            </tr>
            <tr class="Celda">
                <td>
                    RESUMEN</td>
                <td colspan="4">
                    <asp:TextBox ID="txtresumen" runat="server" Width="640px" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    DESCRIPCION</td>
                <td colspan="4">
                    <asp:TextBox ID="txtDescripcionSol" runat="server" TextMode="MultiLine" 
                        Width="638px" CssClass="CajasDeTextoMultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr class="Celda">
                <td colspan="5">
                    &nbsp;</td>
            </tr>
              <tr class="Celda">
                <td colspan="5">
                    ANEXO</td>
            </tr>
             <tr class="Celda">
                <td>
                    Anexo 1</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddltipo1" runat="server" CssClass="Combos">
                    </asp:DropDownList>
                    &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" CssClass="CajasDeTexto"/>
                 </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr class="Celda">
                <td>
                    Anexo 2</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddltipo2" runat="server" CssClass="Combos">
                    </asp:DropDownList>
                    &nbsp;<asp:FileUpload ID="FileUpload2" runat="server" CssClass="CajasDeTexto" />
                 </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr class="Celda">
                <td>
                    Anexo 3</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddltipo3" runat="server" CssClass="Combos">
                    </asp:DropDownList>
                    &nbsp;<asp:FileUpload ID="FileUpload3" runat="server"  CssClass="CajasDeTexto"/>
                 </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    REFERENCIAS LABORALES</td>
            </tr>
            <tr class="Celda">
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    TITULAR</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Empresa</td>
                <td colspan="3">
                    <asp:TextBox ID="txtEmpresaTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEmpresaTi" 
                        ErrorMessage="El campo Empresa es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Cargo</td>
                <td colspan="3">
                    <asp:TextBox ID="txtCargoTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCargoTi" 
                        ErrorMessage="El campo cargo es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Fecha Inicio</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTiempoServTi" runat="server"  Width="29%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTiempoServTi" 
                        ErrorMessage="El campo Fecha Inicio es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ControlToValidate="txtTiempoServTi" 
                        ErrorMessage="El campo fecha Inicio formato dd/mm/yyyy" MaximumValue="01/01/2020" 
                        MinimumValue="01/01/2000" Type="Date" ValidationGroup="BTN" Display="None"></asp:RangeValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="txtFechaFin" ControlToValidate="txtTiempoServTi" 
                        ErrorMessage="La fecha inicio debe ser menor a Fecha Fin" 
                        Operator="LessThan" Type="Date" ValidationGroup="BTN" Display="None"></asp:CompareValidator>
                &nbsp;(dd/mm/yyyy)</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Fecha Fin</td>
                <td colspan="3">
                    <asp:TextBox ID="txtFechaFin" runat="server" Width="161px" CssClass="CajasDeTexto"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                        ControlToValidate="txtFechaFin" 
                        ErrorMessage="El campo Fecha Fin es Obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtFechaFin" 
                        ErrorMessage="El campo fecha Fin formato dd/mm/yyyy" MaximumValue="01/01/2020" 
                        MinimumValue="01/01/2000" Type="Date" ValidationGroup="BTN" Display="None"></asp:RangeValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtTiempoServTi" ControlToValidate="txtFechaFin" 
                        ErrorMessage="La fecha Fin debe ser Mayor a la Fecha Inicio" 
                        Operator="GreaterThan" Type="Date" ValidationGroup="BTN" Display="None"></asp:CompareValidator>
                &nbsp; (dd/mm/yyyy)</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Sueldo</td>
                <td colspan="3">
                    <asp:TextBox ID="txtSueldoTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtSueldoTi" 
                        ErrorMessage="El campo Sueldo es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Dirección</td>
                <td colspan="3">
                    <asp:TextBox ID="txtDireccionTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtDireccionTi" 
                        ErrorMessage="El campo direccion es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    Teléfono</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTelefonoTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtTelefonoTi" 
                        ErrorMessage="El campo Telefono es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td>
                    E-mail</td>
                <td colspan="3">
                    <asp:TextBox ID="txtEmailTi" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="El formato del email es incorrecto" ControlToValidate="txtEmailTi" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="BTN" Display="None"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                        ControlToValidate="txtEmailTi" 
                        ErrorMessage="El campo Email es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    REFERENCIAS BANCARIAS</td>
            </tr>
            <tr class="Celda">
                <td>
                    Banco 1</td>
                <td colspan="2">
                    <asp:TextBox ID="txtBanco1" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtBanco1" 
                        ErrorMessage=" El campo Banco 1 es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    Tipo de Cuenta</td>
                <td>
                    <asp:TextBox ID="txtCuenta1" runat="server"  Width="80%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtCuenta1" 
                        ErrorMessage="El Campo de tipo de cuenta es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Sucursal</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSucursal1" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtSucursal1" 
                        ErrorMessage="El campo Sucursal es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    Sectorista</td>
                <td>
                    <asp:TextBox ID="txtSectorista1" runat="server"  Width="76%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtSectorista1" 
                        ErrorMessage="El campo sectorista es obligatorio" ValidationGroup="BTN" 
                        Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Banco 2</td>
                <td colspan="2">
                    <asp:TextBox ID="txtBanco2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Tipo de Cuenta</td>
                <td>
                    <asp:TextBox ID="txtCuenta2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Sucursal</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSucursal2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Sectorista</td>
                <td>
                    <asp:TextBox ID="txtSectorista2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    &nbsp; &nbsp; INFORMACION PATRIMONIAL ( en US$) &nbsp; </td>
            </tr>
            <tr class="Celda">
                <td>
                    Ctas. Bancarias</td>
                <td>
                    Acciones</td>
                <td>
                    Inmuebles</td>
                <td class="style2">
                    Vehículos</td>
                <td>
                    Otros</td>
            </tr>
            <tr class="Celda">
                <td>
                    <asp:TextBox ID="txtCtasBancarias" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" 
                        ControlToValidate="txtCtasBancarias" Display="None" 
                        ErrorMessage="Ctas Bancarias mayor a 0" MaximumValue="9999999" MinimumValue="1" 
                        Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtAcciones" runat="server"  Width="87%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator5" runat="server" 
                        ControlToValidate="txtAcciones" Display="None" 
                        ErrorMessage="Acciones mayor a 0" MaximumValue="9999999" MinimumValue="1" 
                        Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtInmuebles" runat="server"  Width="90%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator6" runat="server" 
                        ControlToValidate="txtVehiculos" Display="None" ErrorMessage="mayor a 1" 
                        MaximumValue="9999999" MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtVehiculos" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" 
                        ControlToValidate="txtVehiculos" Display="None" ErrorMessage="mayor a 1" 
                        MaximumValue="9999999" MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtOtros1" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator11" runat="server" 
                        ControlToValidate="txtOtros1" Display="None" ErrorMessage="Otros mayor a 0" 
                        MaximumValue="9999999" MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Hipotecas</td>
                <td>
                    Créditos</td>
                <td>
                    Préstamos</td>
                <td class="style2">
                    Ctas.Por Pagar</td>
                <td>
                    Otros</td>
            </tr>
            <tr class="Celda">
                <td>
                    <asp:TextBox ID="txtHipotecas" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator8" runat="server" 
                        ControlToValidate="txtHipotecas" Display="None" 
                        ErrorMessage="Hipotecas mayor a 0" MaximumValue="9999999" MinimumValue="1" 
                        Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCreditos" runat="server"  Width="87%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator7" runat="server" 
                        ControlToValidate="txtCreditos" Display="None" ErrorMessage="Credito mayor a 0" 
                        MaximumValue="9999999" MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPrestamos" runat="server"  Width="90%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator9" runat="server" 
                        ControlToValidate="txtPrestamos" Display="None" 
                        ErrorMessage="Prestamo mayor a 0 " MaximumValue="9999999" MinimumValue="1" 
                        Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtCtasPorPagar" runat="server"  Width="92%" Height="22px" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator10" runat="server" 
                        ControlToValidate="txtCtasPorPagar" Display="None" 
                        ErrorMessage="Ctas. Por Pagar mayor a 0" MaximumValue="9999999" 
                        MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtOtros2" runat="server"  Width="92%" CssClass="CajasDeTexto"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator12" runat="server" 
                        ControlToValidate="txtOtros2" Display="None" ErrorMessage="Otros mayor a 0" 
                        MaximumValue="9999999" MinimumValue="1" Type="Double" ValidationGroup="BTN"></asp:RangeValidator>
                </td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="Celda">
                <td colspan="5">
                    REFERENCIAS COMERCIALES</td>
            </tr>
            <tr class="Celda">
                <td>
                    Empresa 1</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmpresa1" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Dirección</td>
                <td>
                    <asp:TextBox ID="txtDireccion1" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
            <tr class="Celda">
                <td>
                    Empresa 2</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmpresa2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
                <td class="style2">
                    Dirección</td>
                <td>
                    <asp:TextBox ID="txtDireccion2" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                </td>
            </tr>
             <tr class="Celda">
                <td>
                    Empresa 3</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmpresa3" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                 </td>
                <td class="style2">
                    Dirección</td>
                <td>
                    <asp:TextBox ID="txtDireccion3" runat="server"  Width="97%" CssClass="CajasDeTexto"></asp:TextBox>
                 </td>
            </tr>
        </table>
    </td>
    </tr>
    </table>
       
    
    </div>
    <div style="position: absolute; top: 916px; left: 462px;">
        <asp:Button ID="btnGrabar" runat="server" Text="GRABAR" 
            onclick="btnGrabar_Click" ValidationGroup="BTN" CssClass="Botones" />
    </div>
     <div style="position: absolute; top: 917px; left: 588px;">
        <asp:Button ID="btnRegresar" runat="server" Text="REGRESAR" 
            onclick="btnRegresar_Click" CssClass="Botones"  />
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ValidationGroup="BTN" />
     <cc1:MsgBox ID="MsgBox1" runat="server" />
    <asp:HiddenField ID="hdnAccion" runat="server" />
    <asp:HiddenField ID="hdnCodSol" runat="server" />
    <asp:HiddenField ID="hdnCodContac" runat="server" />
    <asp:HiddenField ID="hdnRefLaboral" runat="server" />
    <asp:HiddenField ID="hdnRefBancaria1" runat="server" />
    <asp:HiddenField ID="hdnRefBancaria2" runat="server" />
    <asp:HiddenField ID="hdnInfPatPos" runat="server" />
    <asp:HiddenField ID="hdnInfPatNeg" runat="server" />
    <asp:HiddenField ID="hdnRefCom1" runat="server" />
    <asp:HiddenField ID="hdnRefCom2" runat="server" />
    <asp:HiddenField ID="hdnRefCom3" runat="server" />
    </form>
   
</body>
</html>
