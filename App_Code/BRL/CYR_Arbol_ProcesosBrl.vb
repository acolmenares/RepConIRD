Imports ingNovar.Utilidades2
Imports System.Data
Imports Telerik.Web.UI


Partial Public Class CYR_Arbol_ProcesosBrl

    Private _Id As Int32
    Private _Id_CYR_Arbol As Int32
    Private _Id_Tipo_Consulta As Int32
    Private _Descripcion As String


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


    Public Event Id_CYR_ArbolChanging(ByVal Value As Int32)
    Public Event Id_CYR_ArbolChanged()
	
	''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Id_CYR_Arbol() As Int32
        Get
            Return Me._Id_CYR_Arbol
        End Get
        Set(ByVal Value As Int32)
            If _Id_CYR_Arbol <> Value Then
                RaiseEvent Id_CYR_ArbolChanging(Value)
				Me._Id_CYR_Arbol = Value
                RaiseEvent Id_CYR_ArbolChanged()
            End If
        End Set
    End Property


    Public Event Id_Tipo_ConsultaChanging(ByVal Value As Int32)
    Public Event Id_Tipo_ConsultaChanged()
	
	''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Id_Tipo_Consulta() As Int32
        Get
            Return Me._Id_Tipo_Consulta
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tipo_Consulta <> Value Then
                RaiseEvent Id_Tipo_ConsultaChanging(Value)
				Me._Id_Tipo_Consulta = Value
                RaiseEvent Id_Tipo_ConsultaChanged()
            End If
        End Set
    End Property


    Public Event DescripcionChanging(ByVal Value As String)
    Public Event DescripcionChanged()
	
	''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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



	''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Readonly Property CYR_Arbol() As CYR_ArbolBrl
        Get
            Return CYR_ArbolBrl.CargarPorID(Id_CYR_Arbol)
        End Get
    End Property



	''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Readonly Property SubTablas() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo_Consulta)
        End Get
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
			Me.ID = CYR_Arbol_ProcesosDAL.Insertar(Id_CYR_Arbol, Id_Tipo_Consulta, Descripcion)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
			CYR_Arbol_ProcesosDAL.Actualizar(ID, Id_CYR_Arbol, Id_Tipo_Consulta, Descripcion)
            RaiseEvent Updated()			
		End If   


        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            
            
            
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			CYR_Arbol_ProcesosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub
	
	''' <summary>
    ''' Conviernte un datarow en un objeto del tipo especificado
    ''' </summary>
    ''' <param name="fila"></param>
    ''' <returns>Un objeto con los valores del datarow</returns>
    ''' <remarks></remarks>
    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As CYR_Arbol_ProcesosBrl
		
		Dim objCYR_Arbol_Procesos As New CYR_Arbol_ProcesosBrl
		
		With objCYR_Arbol_Procesos
			.ID = fila("Id")
			.Id_CYR_Arbol = isDBNullToNothing(fila("Id_CYR_Arbol"))
			.Id_Tipo_Consulta = isDBNullToNothing(fila("Id_Tipo_Consulta"))
			.Descripcion = isDBNullToNothing(fila("Descripcion"))

		End With
		
		Return objCYR_Arbol_Procesos
		
    End Function
	
	Public Shared Event LoadingCYR_Arbol_ProcesosList(ByVal LoadType As String)
	Public Shared Event LoadedCYR_Arbol_ProcesosList(target As List(Of CYR_Arbol_ProcesosBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of CYR_Arbol_ProcesosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_Arbol_ProcesosBrl)
	
		RaiseEvent LoadingCYR_Arbol_ProcesosList("CargarTodos")
	
		dsDatos = CYR_Arbol_ProcesosDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_Arbol_ProcesosList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As CYR_Arbol_ProcesosBrl)

	Public Shared Function CargarPorID(ID As Int32) As CYR_Arbol_ProcesosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objCYR_Arbol_Procesos As CYR_Arbol_ProcesosBrl = Nothing 
		
        dsDatos = CYR_Arbol_ProcesosDAL.CargarPorID(ID)
        If dsDatos.Tables(0).Rows.Count <> 0 Then objCYR_Arbol_Procesos = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))
        Return objCYR_Arbol_Procesos
        
    End Function

	Public Shared Function CargarPorId_CYR_Arbol(ByVal Id_CYR_Arbol As Int32) As List(Of CYR_Arbol_ProcesosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_Arbol_ProcesosBrl)
	
		RaiseEvent LoadingCYR_Arbol_ProcesosList("CargarPorId_CYR_Arbol")
		
		dsDatos = CYR_Arbol_ProcesosDAL.CargarPorId_CYR_Arbol(Id_CYR_Arbol)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_Arbol_ProcesosList(lista, "CargarPorId_CYR_Arbol")
        
        Return lista
        
	End Function



	Public Shared Function CargarPorId_Tipo_Consulta(ByVal Id_Tipo_Consulta As Int32) As List(Of CYR_Arbol_ProcesosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_Arbol_ProcesosBrl)
	
		RaiseEvent LoadingCYR_Arbol_ProcesosList("CargarPorId_Tipo_Consulta")
		
		dsDatos = CYR_Arbol_ProcesosDAL.CargarPorId_Tipo_Consulta(Id_Tipo_Consulta)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_Arbol_ProcesosList(lista, "CargarPorId_Tipo_Consulta")
        
        Return lista
        
	End Function



End Class


