<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
       <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
       <meta name="author" content="Ricardo Ortiz"/>
       <meta name="description" content="Operaciones y Monitoreo"/>
       <title>Acceso al Sistema de Consultas y Reportes de los Módulos de IRD</title>
       <link rel="stylesheet" type="text/css" media="all" href="Styles/main1.css"/>
       <link rel="stylesheet" type="text/css" media="all" href="colorschemes/colorscheme9/colorscheme.css"/>
       <link rel="stylesheet" type="text/css" media="all" href="Styles/style1.css"/>
       <script type="text/javascript" src="live_tinc.js"></script>
   </head>
<body>
    <form id="form1" runat="server">
        <div >
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <div id="container" >
                            <div id="header">
                                
                                <div id="key_visual"><img alt=""  src="Images/Captura.JPG" /></div>
                            </div>
                            <div id="main_container">
                                <table id="layout_table">
                                    <tr>
                                        <td id="right_column">
                                            <div id="sub_container1">
                                                <div id="main_nav_container">
                                                    <div id="sub_nav_container">
                                                        <img align="middle" alt="" src="Images/buscar.png" 
                                                            style="height: 119px; width: 129%" />
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td id="left_column">
                                            <div id="sub_container2" align="left" >
                                                <div id="slogan">Consultas Generales</div>
                                                <div class="content" id="content_container">
                                                    <table runat="server"  ID="tbl_principal"   style="width: 80%" cellpadding="0" cellspacing="0" align="left">
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="Label31" runat="server" Text="Acceso al Aplicativo" Width="90%"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 40%" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text="Usuario" Width="80%"></asp:Label>
                                                            </td>
                                                            <td style="width: 40%" align="center">
                                                                <telerik:RadTextBox ID="txt_login" runat="server" Width="80%" MaxLength="10" 
                                                                    LabelWidth="40%" Resize="None" Skin="Telerik"></telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 40%" align="center">
                                                                <asp:Label ID="Label2" runat="server" Text="Contraseña" Width="80%"></asp:Label>
                                                            </td>
                                                            <td style="width: 40%" align="center">
                                                                <telerik:RadTextBox ID="txt_contrasena" runat="server" Width="80%" 
                                                                    MaxLength="20" TextMode="Password" Skin="Telerik"></telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 40%" align="center">
                                                                <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Text="Usuario o Contraseña incorrecta"
                                                                    Width="94%" Visible="False"></asp:Label></td>
                                                            <td style="width: 40%" align="center">
                                                                <asp:Button ID="imgok" runat="server" Text="Ingresar" Width="100px" /></td>
                                                        </tr>
                                                    </table>                
                                                </div>
                                            </div>
                                            <div id="sub_container3" class="style2"><strong>NUEVA VERSION 4.09.13</strong></div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="footer_text">SIIRD , SAGIRD , SAFIRD, WEB Service</div>
                        </div>
                    </td>
                </tr>
            </table> 
        </div>
    </form>
</body>
</html>
