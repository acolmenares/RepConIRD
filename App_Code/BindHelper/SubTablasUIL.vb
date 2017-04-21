Imports System.Collections.Generic

Namespace BindHelper
    
    Partial Public NotInheritable Class SubTablasUIL
        
        Private Shared Sub Bind(ByVal control As ListControl, ByVal Lista As List(Of SubTablasBRL), Optional ByVal firstItem As ListItem = Nothing)
            control.DataSource = Lista
            control.DataValueField = "ID"
            control.DataTextField = "Descripcion"
            control.DataBind()
            If Not firstItem Is Nothing  Then
                control.Items.Insert(0, firstItem)
            End If
        End Sub
        
        Public Shared Function BindToListControl(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBRL)
            Dim Lista As List(Of SubTablasBRL)
            Lista = SubTablasBRL.CargarTodos()
            Bind(control, Lista, firstItem)
            Return Lista
        End Function
        
        Public Shared Function BindToListControlPorId_Tabla(ByVal control As ListControl, ByVal Id_Tabla As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Tabla(Id_Tabla)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Padre(ByVal control As ListControl, ByVal Id_Tabla As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_Padre(Id_Tabla)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_TablaPadre(ByVal control As ListControl, ByVal Id_Tabla As Int32, ByVal Id_Padre As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_TablaPadre(Id_Tabla, Id_Padre)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorGruposLibres(ByVal control As ListControl, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorGruposLIbres
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorId_Regional(ByVal control As ListControl, ByVal Id_Regional As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorId_regional(Id_Regional)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

        Public Shared Function BindToListControlPorGruposSinAsignar(ByVal control As ListControl, ByVal Id_Lugar_Entrega As Int32, Optional ByVal firstItem As ListItem = Nothing) As List(Of SubTablasBrl)
            Dim Lista As List(Of SubTablasBrl)
            Lista = SubTablasBrl.CargarPorGruposSinAsignar(Id_Lugar_Entrega)
            Bind(control, Lista, firstItem)
            Return Lista
        End Function

    End Class




End Namespace


