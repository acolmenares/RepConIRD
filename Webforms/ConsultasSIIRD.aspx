<%@ Page Title="" Language="VB" MasterPageFile="~/Controles/MasterPage.master" AutoEventWireup="false" CodeFile="ConsultasSIIRD.aspx.vb" Inherits="Webforms_ConsultasSIIRD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>

    <asp:Panel ID="pnl_Principal" runat="server" Width ="100%">
        <table style="width:100%;">
            <tr>
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td  style="width: 20%" valign="top">
                    <telerik:RadTreeView ID="Rtv_Arbol" Runat="server" Skin="Office2010Blue" 
                        style="text-align: left" ResolvedRenderMode="Classic" 
                        LoadingMessage="Cargando ..." 
                        ToolTip="Seleccione el reporte que desea ejecutar ...">
                    </telerik:RadTreeView>
                </td>
                <td style="width: 80%">
                    <table style="width:100%;">
                        <tr>
                            <td class="style5" colspan="5">
                                <asp:Label ID="Label22" runat="server" 
                                    Text="SELECCION DE PARAMETROS PARA LA CONSULTA" 
                                    style="color: #FF0000; background-color: #FFFF00" Width="60%"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaAtencionInicial" runat="server" 
                                    Text="Fecha Atención Inicial"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 20%;">
                                <telerik:RadDatePicker ID="rdp_FechaAtencionInicial" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaAtencionFinal" runat="server" 
                                    Text="Fecha Atención Final"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaAtencionFinal" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="lbl_Grupos" runat="server" Text="Grupos"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaDeclaracionInicial" runat="server" 
                                    Text="Fecha Declaración Inicial"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaDeclaracionInicial" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaDeclaracionFinal" runat="server" 
                                    Text="Fecha Declaración Final"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaDeclaracionFinal" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td rowspan="7" style="width: 20%" valign="top">
                                <asp:ListBox ID="Lst_Grupos" runat="server" CssClass="drop01" Rows="15" 
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaDesplazamientoInicial" runat="server" 
                                    Text="Fecha Desplazamiento Inicial"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaDesplazamientoInicial" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaDesplazamientoFinal" runat="server" 
                                    Text="Fecha Desplazamiento Final"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaDesplazamientoFinal" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaRadicacionInicial" runat="server" 
                                    Text="Fecha Radicación Inicial"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaRadicacionInicial" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaRadicacionFinal" runat="server" 
                                    Text="Fecha Radicación Final"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaRadicacionFinal" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaEntregaInicial" runat="server" 
                                    Text="Fecha Entrega Inicial"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaEntregaInicial" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaEntregaFinal" runat="server" Text="Fecha Entrega Final"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaEntregaFinal" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_Regional" runat="server" Text="Regional"></asp:Label>
                            </td>
                            <td class="style4" style="width: 20%">
                                <asp:DropDownList ID="ddl_Regional" runat="server" CssClass="drop01" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_LugarEntrega" runat="server" Text="Lugar de Entrega"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:DropDownList ID="ddl_LugarEntrega" runat="server" CssClass="drop01" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_TipoEntrega" runat="server" Text="Tipo de Entrega"></asp:Label>
                            </td>
                            <td class="style4" style="width: 20%">
                                <asp:DropDownList ID="ddl_TipoEntrega" runat="server" CssClass="drop01">
                                </asp:DropDownList>
                            </td>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_FechaCorte" runat="server" Text="Fecha  Corte"></asp:Label>
                            </td>
                            <td class="style1" style="width: 20%">
                                <telerik:RadDatePicker ID="rdp_FechaCorte" runat="server" 
                                    Culture="Spanish (Colombia)" MinDate="" Skin="Telerik" 
                                    ToolTip="Seleccione Fecha ..." Width="100%">
                                    <Calendar Skin="Telerik" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        <FastNavigationSettings CancelButtonCaption="Cancelar" 
                                            DateIsOutOfRangeMessage="Fecha Fuera de Rango" TodayButtonCaption="Hoy">
                                        </FastNavigationSettings>
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" ToolTip="Abrir el Calendario" />
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MMMM/yyyy" 
                                        EmptyMessage="Fecha ...">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" style="width: 20%">
                                <asp:Label ID="lbl_Pendientes" runat="server" Text="Pendientes"></asp:Label>
                            </td>
                            <td class="style4" style="width: 20%">
                                <asp:CheckBox ID="chb_Pendientes" runat="server" />
                            </td>
                            <td style="width: 20%; text-align: left;">
                                <asp:Label ID="lbl_TipoDeclaracion" runat="server" Text="Tipo de Declaración"></asp:Label>
                            </td>
                            <td class="style4" style="width: 20%; text-align: left;">
                                <asp:DropDownList ID="ddl_TipoDeclaracion" runat="server" CssClass="drop01">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
                        ResolvedRenderMode="Classic" SelectedIndex="0" Skin="Windows7" 
                        MultiPageID="RadMultiPage1">
                        <Tabs>
                            <telerik:RadTab runat="server" Selected="True" Text="Conteo" SelectedIndex="0" >
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Listado General" SelectedIndex="1" >
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Gráfico" SelectedIndex="2" >
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Reportes" SelectedIndex="3" >
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Listado Detalle" SelectedIndex="4" >
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" ResolvedRenderMode="Classic" Width="100%" >
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                            <telerik:RadButton ID="rdb_Conteo" runat="server" Skin="Vista" 
                                Text="Procesar Busqueda de Conteo">
                            </telerik:RadButton>
                            <telerik:RadGrid ID="Rg_Conteo" runat="server" AllowSorting="True" PageSize="30" ResolvedRenderMode="Classic" 
                                ShowStatusBar="True" Skin="WebBlue" TabIndex="6" Width="100%" 
                                AllowPaging="True" ShowFooter="True" EnableHeaderContextMenu="True">
                                <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id"  
                                    NoDetailRecordsText="No hay información." NoMasterRecordsText="No hay información.">
                                    <Columns  >
                                    
                                        <%--<telerik:GridTemplateColumn DefaultInsertValue="" HeaderText="No." 
                                            UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:Label ID="lblno" runat="server" 
                                                    text="<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>" 
                                                    ToolTip="<%#Container.DataItem.Id%>" />
                                                <asp:Label ID="lblid" runat="Server" Text="<%#Container.DataItem.Id%>" 
                                                    Visible="False" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        
                                                                                
                                    </Columns>
                                    <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" 
                                        AddNewRecordText="" ExportToCsvText="Exportar a CSV" 
                                        ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF" 
                                        ExportToWordText="Exportar a Word" RefreshText="Actualizar" 
                                        ShowAddNewRecordButton="False" ShowExportToCsvButton="True" 
                                        ShowExportToExcelButton="True" ShowExportToPdfButton="True" 
                                        ShowExportToWordButton="True" CancelChangesText="Cancelar" 
                                        SaveChangesText="Salvar" />
                                    <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" 
                                        Mode="NumericPages" NextPagesToolTip="Próximas" NextPageToolTip="Próxima" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" 
                                        AlwaysVisible="True" />
                                </MasterTableView>
                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <ExportSettings ExportOnlyData="True" filename="Conteo" 
                                    HideStructureColumns="True" IgnorePaging="True" OpenInNewWindow="True">
                                    <Pdf PageWidth="">
                                    </Pdf>
                                </ExportSettings>
                                <SortingSettings SortedAscToolTip="Ordenar Ascendente" 
                                    SortedDescToolTip="Ordenar Descendente" 
                                    SortToolTip="Clic aqui para ordenar..." />
                                <PagerStyle Mode="NumericPages" AlwaysVisible="True" />
                            </telerik:RadGrid>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <telerik:RadButton ID="rdb_Listado" runat="server" Skin="Vista" 
                                Text="Procesar Búsqueda de Listado General">
                            </telerik:RadButton>
                            <telerik:RadGrid ID="Rg_Listado" runat="server" AllowPaging="True" 
                                AllowSorting="True" EnableHeaderContextMenu="True" PageSize="30" 
                                ResolvedRenderMode="Classic" ShowFooter="True" ShowStatusBar="True" 
                                Skin="WebBlue" TabIndex="6" Width="100%">
                                <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id" 
                                    NoDetailRecordsText="No hay información." 
                                    NoMasterRecordsText="No hay información.">
                                    <Columns>
                                        <%--<telerik:GridTemplateColumn DefaultInsertValue="" HeaderText="No." 
                                            UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:Label ID="lblno" runat="server" 
                                                    text="<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>" 
                                                    ToolTip="<%#Container.DataItem.Id%>" />
                                                <asp:Label ID="lblid" runat="Server" Text="<%#Container.DataItem.Id%>" 
                                                    Visible="False" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                    </Columns>
                                    <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" 
                                        AddNewRecordText="" CancelChangesText="Cancelar" 
                                        ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" 
                                        ExportToPdfText="Exportar a PDF" ExportToWordText="Exportar a Word" 
                                        RefreshText="Actualizar" SaveChangesText="Salvar" 
                                        ShowAddNewRecordButton="False" ShowExportToCsvButton="True" 
                                        ShowExportToExcelButton="True" ShowExportToPdfButton="True" 
                                        ShowExportToWordButton="True" />
                                    <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera" 
                                        LastPageToolTip="Ultima" Mode="NumericPages" NextPagesToolTip="Próximas" 
                                        NextPageToolTip="Próxima" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                                </MasterTableView>
                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <ExportSettings ExportOnlyData="True" filename="ListadoGeneral" 
                                    HideStructureColumns="True" IgnorePaging="True" OpenInNewWindow="True">
                                    <Pdf PageWidth="">
                                    </Pdf>
                                </ExportSettings>
                                <SortingSettings SortedAscToolTip="Ordenar Ascendente" 
                                    SortedDescToolTip="Ordenar Descendente" 
                                    SortToolTip="Clic aqui para ordenar..." />
                                <PagerStyle AlwaysVisible="True" Mode="NumericPages" />
                            </telerik:RadGrid>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView4" runat="server">
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView5" runat="server">
                            <telerik:RadGrid ID="Rg_Detalle" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" PageSize="20" ResolvedRenderMode="Classic" 
                                ShowStatusBar="True" Skin="WebBlue" TabIndex="6" Width="100%">
                                <MasterTableView AllowPaging="True" CommandItemDisplay="Top" DataKeyNames="Id" 
                                    NoDetailRecordsText="No hay información." 
                                    NoMasterRecordsText="No hay información.">
                                    <Columns>
                                        <telerik:GridTemplateColumn DefaultInsertValue="" HeaderText="No." 
                                            UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:Label ID="lblno1" runat="server" 
                                                    text="<%# ctype(CType(Container.Parent.Parent.Parent,RadGrid).DataSource,IList).IndexOf(Container.DataItem)+1 %>" 
                                                    ToolTip="<%#Container.DataItem.Id%>" />
                                                <asp:Label ID="lblid1" runat="Server" Text="<%#Container.DataItem.Id%>" 
                                                    Visible="False" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" Display="False" 
                                            HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:dd/MMM/yyyy}" 
                                            DataType="System.DateTime" HeaderText="Fecha " SortExpression="Fecha" 
                                            UniqueName="Fecha">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoEstado.Descripcion" HeaderText="Estado" 
                                            SortExpression="TipoEstado.Descripcion" UniqueName="TipoEstado.Descripcion">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ComoEstado.Descripcion" 
                                            HeaderText="Resultado" SortExpression="ComoEstado.Descripcion" 
                                            UniqueName="ComoEstado.Descripcion">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProgramaAsistio" HeaderText="Programa" 
                                            SortExpression="ProgramaAsistio" UniqueName="ProgramaAsistio">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AsistioEstado" HeaderText="Asistio" 
                                            SortExpression="AsistioEstado" UniqueName="AsistioEstado">
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <CommandItemSettings AddNewRecordImageUrl="~/Images/nothing.gif" 
                                        AddNewRecordText="" ExportToCsvText="Exportar a CSV" 
                                        ExportToExcelText="Exportar a Excel" ExportToPdfText="Exportar a PDF" 
                                        ExportToWordText="Exportar a Word" RefreshText="Actualizar" 
                                        ShowAddNewRecordButton="False" ShowExportToCsvButton="True" 
                                        ShowExportToExcelButton="True" ShowExportToPdfButton="True" 
                                        ShowExportToWordButton="True" />
                                    <PagerStyle FirstPageToolTip="Primera" LastPageToolTip="Ultima" 
                                        Mode="NumericPages" NextPagesToolTip="Próximas" NextPageToolTip="Próxima" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registros &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PrevPagesToolTip="Anteriores" PrevPageToolTip="Anterior" />
                                </MasterTableView>
                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <ExportSettings ExportOnlyData="True" filename="EstadosAsignacion" 
                                    HideStructureColumns="True" IgnorePaging="True" OpenInNewWindow="True">
                                    <Pdf PageWidth="">
                                    </Pdf>
                                </ExportSettings>
                                <SortingSettings SortedAscToolTip="Ordenar Ascendente" 
                                    SortedDescToolTip="Ordenar Descendente" 
                                    SortToolTip="Clic aqui para ordenar..." />
                                <PagerStyle Mode="NumericPages" />
                            </telerik:RadGrid>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    
    </asp:Panel>

</asp:Content>

