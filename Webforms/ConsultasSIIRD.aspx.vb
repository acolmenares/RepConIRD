Imports System.Web
Imports Telerik.Web.UI
Imports System.Collections.Generic
Imports ingNovar.Utilidades2
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient


Partial Class Webforms_ConsultasSIIRD
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.IsPostBack Then Exit Sub

        If Session("IdUsuario") Is Nothing Then
            Session.RemoveAll()
            Response.Redirect("../login.aspx")
            Exit Sub
        End If

        Dim lblidUsuario As Label
        lblidUsuario = Master.FindControl("lblidusuario")
        lblidUsuario.Text = Session("IdUsuario")

        Dim LblNombreUsuario As Label
        LblNombreUsuario = Master.FindControl("LblNombreUsuario")
        LblNombreUsuario.Text = Session("NombreUsuario")

        Dim Lbl_regional As Label
        Lbl_regional = Master.FindControl("Lbl_regional")
        Lbl_regional.Text = Session("NombreRegional")

        Dim Lbl_usuario As Label
        Lbl_usuario = Master.FindControl("Lbl_usuario")
        Lbl_usuario.Text = Session("LoginUsuario")

        Dim Lbl_perfil As Label
        Lbl_perfil = Master.FindControl("Lbl_perfil")
        Lbl_perfil.Text = Session("NombrePerfil")


        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_Regional, 72, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_LugarEntrega, 73, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_TipoEntrega, 77, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_TipoDeclaracion, 76, New System.Web.UI.WebControls.ListItem("Seleccione", 0))

        ddl_regional_SelectedIndexChanged(Nothing, Nothing)

        'Dim ListDeclaracionAsignacion As List(Of DeclaracionBrl) = Session("ListDeclaracionAsignacion")

        ''si no hay una variable de sesión con la lista.
        'If ListDeclaracionAsignacion Is Nothing Or Request.QueryString.Item("Refrescar") = 1 Then
        '    ListDeclaracionAsignacion = DeclaracionBrl.CargarPorId_Regional(0)
        '    Session("ListDeclaracionAsignacion") = ListDeclaracionAsignacion
        'End If

        'Rg_Listado.DataSource = Session("ListDeclaracionAsignacion")
        'Rg_Listado.DataBind()

        BindToDataSet(Rtv_Arbol, 1) '  1 significa SIIRD


    End Sub

    Private Shared Sub BindToDataSet(ByVal treeView As RadTreeView, ByVal ID_Modulo As Int32)

        Dim NivelesList As List(Of CYR_ArbolBrl) = CYR_ArbolBrl.CargarTodos ' Modulo
        treeView.DataTextField = "Descripcion"
        treeView.DataFieldID = "Id"
        treeView.DataFieldParentID = "Id_Padre"
        treeView.DataValueField = "Id"

        treeView.DataSource = NivelesList
        treeView.DataBind()
    End Sub

    Protected Sub ddl_regional_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_Regional.SelectedIndexChanged
        If ddl_Regional.SelectedValue > 0 Then
            BindHelper.SubTablasUIL.BindToListControlPorId_TablaPadre(ddl_LugarEntrega, 73, ddl_Regional.SelectedValue, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        Else
            BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(ddl_LugarEntrega, 73, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        End If
        ddl_LugarEntrega_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub ddl_LugarEntrega_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_LugarEntrega.SelectedIndexChanged
        If ddl_LugarEntrega.SelectedValue > 0 Then
            BindHelper.SubTablasUIL.BindToListControlPorId_TablaPadre(Lst_Grupos, 26, ddl_LugarEntrega.SelectedValue, New System.Web.UI.WebControls.ListItem("Seleccione", 0))
        Else
            BindHelper.SubTablasUIL.BindToListControlPorId_Tabla(Lst_Grupos, 26)
        End If
    End Sub

    Protected Sub Rtv_Arbol_NodeClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles Rtv_Arbol.NodeClick
        Dim nodeEdited As RadTreeNode = e.Node
        If nodeEdited.Value > 0 Then
            Dim lbltemporal As New Label
            Dim objvariant As New Object

            Dim ListDetalles As New List(Of CYR_Arbol_DetalleBrl)
            Dim ListParametros As List(Of CYR_ParametrosBrl) = CYR_ParametrosBrl.CargarTodos
            For Each fila As CYR_ParametrosBrl In ListParametros
                lbltemporal = sender.Parent.Parent.FindControl(fila.Nombre_Label)

                'objvariant = e.Node.Parent.Parent.Parent.Parent.Parent.FindControl(fila.Nombre_Componente)
                objvariant = sender.Parent.Parent.FindControl(fila.Nombre_Componente)
                ListDetalles = CYR_Arbol_DetalleBrl.CargarPorId_CYR_Parametro_Arbol(fila.ID, nodeEdited.Value)
                If ListDetalles.Count = 0 Then
                    ' No existe este parametro para esta consulta
                    lbltemporal.ForeColor = Drawing.Color.Silver
                    objvariant.Enabled = False
                    Select Case fila.Id_Tipo
                        Case Is = 1
                            objvariant.Dbselecteddate = Nothing
                        Case Is = 2
                            objvariant.text = ""
                        Case Is = 3
                            objvariant.SelectedValue = 0
                        Case Is = 4
                            objvariant.ClearSelection()
                        Case Is = 5
                            objvariant.checked = False
                    End Select
                Else
                    ' Si existe dentro de los parametros
                    lbltemporal.ForeColor = Drawing.Color.Navy
                    objvariant.Enabled = True


                End If
            Next

        End If
 


    End Sub

    Protected Sub rdb_Conteo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_Conteo.Click
        ' Proceso para buscar el reporte de conteo

        Dim objarbol As CYR_ArbolBrl = CYR_ArbolBrl.CargarPorID(Rtv_Arbol.SelectedNode.Value)
        FilterHelper.FilterHelper(objarbol.CYR_Arbol_Procesos, "Id_Tipo_Consulta", 1) '  1 significa conteo
        If objarbol.CYR_Arbol_Procesos.Count = 1 Then
            ' existe el procedimiento

            Dim lbltemporal As New Label
            Dim objvariant As New Object


            Dim ds As New DataSet
            Dim cnn As New System.Data.SqlClient.SqlConnection(strCadenaConexion)
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandText = objarbol.CYR_Arbol_Procesos.Item(0).Descripcion

            For Each fila As CYR_Arbol_DetalleBrl In objarbol.CYR_Arbol_Detalle
                If fila.Activo Then
                    lbltemporal = sender.Parent.Parent.Parent.Parent.FindControl(fila.CYR_Parametros.Nombre_Label)
                    objvariant = sender.Parent.Parent.Parent.Parent.Findcontrol(fila.CYR_Parametros.Nombre_Componente)
                    Select Case fila.CYR_Parametros.Id_Tipo
                        Case Is = 1
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 11).Value = isNothingToDBNull(objvariant.Dbselecteddate)
                        Case Is = 2
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 100).Value = isNothingToDBNull(objvariant.text)
                        Case Is = 3
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.Int, 20).Value = isNothingToDBNull(objvariant.SelectedValue)
                        Case Is = 4
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 400).Value = isNothingToDBNull(Grupos())
                        Case Is = 5
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.Bit, 10).Value = isNothingToDBNull(objvariant.checked)
                    End Select


                End If
            Next

            cmd.CommandTimeout = TiempoConexion

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            cnn.Close()

            Session("DsConteo") = ds
            Rg_Conteo.DataSource = Session("DsConteo")
            Rg_Conteo.DataBind()

        Else
            Dim wcadena As String = "No existe asociado un control de procedimiento o hay demasiados relacionados.  Por favor contacte al área de IT para su mejora!!! "
            MsgBox(wcadena, vbExclamation, "NO EXISTE PROCESO")
            Exit Sub

        End If


    End Sub

    Public Function Grupos() As String
        Dim wcadena As String = "("

        For Each item As ListItem In Me.Lst_grupos.Items
            If item.Selected Then
                If item.Value <> "0" Then
                    If wcadena <> "(" Then wcadena = wcadena + ","
                    wcadena = wcadena + item.Value.ToString
                End If
            End If
        Next
        wcadena = wcadena + ")"
        If wcadena = "()" Then wcadena = ""
        Return wcadena
    End Function

    Protected Sub Rg_Conteo_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Conteo.NeedDataSource
        Rg_Conteo.DataSource = Session("DsConteo")
    End Sub

    Protected Sub rdb_Listado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_Listado.Click
        ' Proceso para buscar el reporte de conteo

        Dim objarbol As CYR_ArbolBrl = CYR_ArbolBrl.CargarPorID(Rtv_Arbol.SelectedNode.Value)
        FilterHelper.FilterHelper(objarbol.CYR_Arbol_Procesos, "Id_Tipo_Consulta", 2) '  2 significa Listado General
        If objarbol.CYR_Arbol_Procesos.Count = 1 Then
            ' existe el procedimiento

            Dim lbltemporal As New Label
            Dim objvariant As New Object


            Dim ds As New DataSet
            Dim cnn As New System.Data.SqlClient.SqlConnection(strCadenaConexion)
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandText = objarbol.CYR_Arbol_Procesos.Item(0).Descripcion

            For Each fila As CYR_Arbol_DetalleBrl In objarbol.CYR_Arbol_Detalle
                If fila.Activo Then
                    lbltemporal = sender.Parent.Parent.Parent.Parent.FindControl(fila.CYR_Parametros.Nombre_Label)
                    objvariant = sender.Parent.Parent.Parent.Parent.Findcontrol(fila.CYR_Parametros.Nombre_Componente)
                    Select Case fila.CYR_Parametros.Id_Tipo
                        Case Is = 1
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 11).Value = isNothingToDBNull(objvariant.Dbselecteddate)
                        Case Is = 2
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 100).Value = isNothingToDBNull(objvariant.text)
                        Case Is = 3
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.Int, 20).Value = isNothingToDBNull(objvariant.SelectedValue)
                        Case Is = 4
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.NVarChar, 400).Value = isNothingToDBNull(Grupos())
                        Case Is = 5
                            cmd.Parameters.Add(fila.CYR_Parametros.Nombre_Parametro.Trim, Data.SqlDbType.Bit, 10).Value = isNothingToDBNull(objvariant.checked)
                    End Select


                End If
            Next

            cmd.CommandTimeout = TiempoConexion

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            cnn.Close()

            Session("DsListadoGeneral") = ds
            Rg_Listado.DataSource = Session("DsListadoGeneral")
            Rg_Listado.DataBind()

        Else
            Dim wcadena As String = "No existe asociado un control de procedimiento o hay demasiados relacionados.  Por favor contacte al área de IT para su mejora!!! "
            MsgBox(wcadena, vbExclamation, "NO EXISTE PROCESO")
            Exit Sub

        End If

    End Sub

    Protected Sub Rg_Listado_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_Listado.NeedDataSource
        Rg_Listado.DataSource = Session("DsListadoGeneral")
    End Sub
End Class
