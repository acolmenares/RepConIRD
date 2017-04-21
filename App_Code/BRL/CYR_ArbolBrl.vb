Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic
Imports SeguridadUsuarios

Partial Public Class CYR_ArbolBrl

    Private _Id As Int32
    Private _Descripcion As String
    Private _Id_Padre As Int32
    Private objListCYR_Arbol_Procesos As List(Of CYR_Arbol_ProcesosBrl)
    Private objListCYR_Arbol_Detalle As List(Of CYR_Arbol_DetalleBrl)


	Public Event Creating()
    Public Event Created()
    
    Public Sub New()
        RaiseEvent Creating()
        'Adicionar código al costructor aquí
        
        RaiseEvent Created()        
    End Sub

    Public Event IDChanging(ByVal Value As Int32)
    Public Event IDChanged()
	
    Public Property ID() As Int32
        Get
            Return Me._Id
        End Get
        Set(ByVal Value As Int32)
            If _Id <> Value Then
                RaiseEvent IDChanging(Value)
                Me._Id = Value
                RaiseEvent IDChanged()
            End If
        End Set
    End Property

    Public Event DescripcionChanging(ByVal Value As String)
    Public Event DescripcionChanged()
	
    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Set(ByVal Value As String)
            If _Descripcion <> Value Then
                RaiseEvent DescripcionChanging(Value)
                Me._Descripcion = Value
                RaiseEvent DescripcionChanged()
            End If
        End Set
    End Property

    Public Event Id_PadreChanging(ByVal Value As Int32)
    Public Event Id_PadreChanged()
	
    Public Property Id_Padre() As Int32
        Get
            Return Me._Id_Padre
        End Get
        Set(ByVal Value As Int32)
            If _Id_Padre <> Value Then
                RaiseEvent Id_PadreChanging(Value)
                Me._Id_Padre = Value
                RaiseEvent Id_PadreChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property CYR_Arbol() As CYR_ArbolBrl
        Get
            Return CYR_ArbolBrl.CargarPorID(Id_Padre)
        End Get
    End Property

    Public Property CYR_Arbol_Procesos() As List(Of CYR_Arbol_ProcesosBrl)
        Get
            If (Me.objListCYR_Arbol_Procesos Is Nothing) Then
                objListCYR_Arbol_Procesos = CYR_Arbol_ProcesosBrl.CargarPorId_CYR_Arbol(Me.ID)
            End If
            Return Me.objListCYR_Arbol_Procesos
        End Get
        Set(ByVal Value As List(Of CYR_Arbol_ProcesosBrl))
            Me.objListCYR_Arbol_Procesos = Value
        End Set
    End Property

    Public Property CYR_Arbol_Detalle() As List(Of CYR_Arbol_DetalleBrl)
        Get
            If (Me.objListCYR_Arbol_Detalle Is Nothing) Then
                objListCYR_Arbol_Detalle = CYR_Arbol_DetalleBrl.CargarPorId_CYR_Arbol(Me.ID)
            End If
            Return Me.objListCYR_Arbol_Detalle
        End Get
        Set(ByVal Value As List(Of CYR_Arbol_DetalleBrl))
            Me.objListCYR_Arbol_Detalle = Value
        End Set
    End Property

    Public Event Saving()
    Public Event Saved()

    Public Event Inserting()
    Public Event Inserted()

    Public Event Updating()
    Public Event Updated()

    Public Event Deleting()
    Public Event Deleted()

    Public Sub Guardar()
        RaiseEvent Saving()
        If (Me.ID = Nothing) Then
            RaiseEvent Inserting()
            Me.ID = CYR_ArbolDAL.Insertar(Descripcion, Id_Padre)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            CYR_ArbolDAL.Actualizar(ID, Descripcion, Id_Padre)
            RaiseEvent Updated()
        End If
        If Not objListCYR_Arbol_Procesos Is Nothing Then
            For Each fila As CYR_Arbol_ProcesosBrl In objListCYR_Arbol_Procesos
                fila.Id_CYR_Arbol = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        If Not objListCYR_Arbol_Detalle Is Nothing Then
            For Each fila As CYR_Arbol_DetalleBrl In objListCYR_Arbol_Detalle
                fila.Id_CYR_Arbol = Me.ID
                Try
                    fila.Guardar()
                Catch ex As Exception
                End Try
            Next
        End If

        RaiseEvent Saved()

    End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            
            totalHijos += CYR_Arbol_Procesos.Count
            totalHijos += CYR_Arbol_Detalle.Count

            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			CYR_ArbolDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As CYR_ArbolBrl

        Dim objCYR_Arbol As New CYR_ArbolBrl

        With objCYR_Arbol
            .ID = fila("Id")
            .Descripcion = isDBNullToNothing(fila("Descripcion"))
            .Id_Padre = isDBNullToNothing(fila("Id_Padre"))

        End With

        Return objCYR_Arbol

    End Function
	
	Public Shared Event LoadingCYR_ArbolList(ByVal LoadType As String)
	Public Shared Event LoadedCYR_ArbolList(target As List(Of CYR_ArbolBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of CYR_ArbolBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_ArbolBrl)
	
		RaiseEvent LoadingCYR_ArbolList("CargarTodos")
	
		dsDatos = CYR_ArbolDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_ArbolList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As CYR_ArbolBrl)

	Public Shared Function CargarPorID(ID As Int32) As CYR_ArbolBrl

		Dim dsDatos As System.Data.DataSet
		Dim objCYR_Arbol As CYR_ArbolBrl = Nothing 
        dsDatos = CYR_ArbolDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objCYR_Arbol = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objCYR_Arbol
        
    End Function

	Public Shared Function CargarPorId_Padre(ByVal Id_Padre As Int32) As List(Of CYR_ArbolBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_ArbolBrl)
	
        dsDatos = CYR_ArbolDAL.CargarPorId_Padre(Id_Padre)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        Return lista
        
	End Function



End Class


