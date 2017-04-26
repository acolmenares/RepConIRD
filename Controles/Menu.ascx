<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Menu.ascx.vb" Inherits="Controles_Menu" %>

<telerik:RadMenu ID="Menu_Principal" Runat="server" Skin="Silk" 
    style="text-align: left" ResolvedRenderMode="Classic" >
    <Items>
        <telerik:RadMenuItem runat="server" Text="Inicio" NavigateUrl="~/Webforms/Principal.aspx" />

        <telerik:RadMenuItem runat="server" IsSeparator="True" Text="Root RadMenuItem10">
        </telerik:RadMenuItem>
        
        <telerik:RadMenuItem runat="server" Text="Monitoereo" Value= "SIIRD"  NavigateUrl="~/Webforms/ConsultasSIIRD.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" Text="SAF" Value= "SAFIRD"  NavigateUrl="~/Webforms/ProgramacionList.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" Text="SAG" Value= "SAGIRD"  NavigateUrl="~/Webforms/ProgramacionList.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" Text="Web Service" Value= "WEBSERVICE"  NavigateUrl="~/Webforms/ProgramacionList.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" IsSeparator="True" Text="Root RadMenuItem10">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" NavigateUrl="~/Login.aspx" Text="Cerrar Sesion">
        </telerik:RadMenuItem>

    </Items>
</telerik:RadMenu>