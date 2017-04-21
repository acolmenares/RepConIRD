Imports ingNovar.Utilidades2
Imports System.Data
Imports Telerik.Web.UI


Partial Public Class CYR_ParametrosBrl

    Private _Id As Int32
    Private _Nombre_Label As String
    Private _Nombre_Componente As String
    Private _Id_Tipo As Int32
    Private _Nombre_Parametro As String
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


    Public Event Nombre_LabelChanging(ByVal Value As String)
    Public Event Nombre_LabelChanged()
	

    Public Property Nombre_Label() As String
        Get
            Return Me._Nombre_Label
        End Get
        Set(ByVal Value As String)
            If _Nombre_Label <> Value Then
                RaiseEvent Nombre_LabelChanging(Value)
				Me._Nombre_Label = Value
                RaiseEvent Nombre_LabelChanged()
            End If
        End Set
    End Property

    Public Event Nombre_ComponenteChanging(ByVal Value As String)
    Public Event Nombre_ComponenteChanged()
	
    Public Property Nombre_Componente() As String
        Get
            Return Me._Nombre_Componente
        End Get
        Set(ByVal Value As String)
            If _Nombre_Componente <> Value Then
                RaiseEvent Nombre_ComponenteChanging(Value)
                Me._Nombre_Componente = Value
                RaiseEvent Nombre_ComponenteChanged()
            End If
        End Set
    End Property

    Public Event Id_TipoChanging(ByVal Value As Int32)
    Public Event Id_TipoChanged()
	
    Public Property Id_Tipo() As Int32
        Get
            Return Me._Id_Tipo
        End Get
        Set(ByVal Value As Int32)
            If _Id_Tipo <> Value Then
                RaiseEvent Id_TipoChanging(Value)
                Me._Id_Tipo = Value
                RaiseEvent Id_TipoChanged()
            End If
        End Set
    End Property

    Public Event Nombre_ParametroChanging(ByVal Value As String)
    Public Event Nombre_ParametroChanged()

    Public Property Nombre_Parametro() As String
        Get
            Return Me._Nombre_Parametro
        End Get
        Set(ByVal Value As String)
            If _Nombre_Parametro <> Value Then
                RaiseEvent Nombre_ParametroChanging(Value)
                Me._Nombre_Parametro = Value
                RaiseEvent Nombre_ParametroChanged()
            End If
        End Set
    End Property


    Public Property CYR_Arbol_Detalle() As List(Of CYR_Arbol_DetalleBrl)
        Get
            If (Me.objListCYR_Arbol_Detalle Is Nothing) Then
                objListCYR_Arbol_Detalle = CYR_Arbol_DetalleBrl.CargarPorId_CYR_Parametro(Me.ID)
            End If
            Return Me.objListCYR_Arbol_Detalle
        End Get
        Set(ByVal Value As List(Of CYR_Arbol_DetalleBrl))
            Me.objListCYR_Arbol_Detalle = Value
        End Set
    End Property

    Public ReadOnly Property Tipo_Parametro() As SubTablasBrl
        Get
            Return SubTablasBrl.CargarPorID(Id_Tipo)
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
			Me.ID = CYR_ParametrosDAL.Insertar(Nombre_Label, Nombre_Componente, Id_Tipo)
            RaiseEvent Inserted()			
		Else
            RaiseEvent Updating()		
			CYR_ParametrosDAL.Actualizar(ID, Nombre_Label, Nombre_Componente, Id_Tipo)
            RaiseEvent Updated()			
		End If   
        If Not objListCYR_Arbol_Detalle Is Nothing Then
            For Each fila As CYR_Arbol_DetalleBrl In objListCYR_Arbol_Detalle
                fila.Id_CYR_Parametro = Me.ID
                Try
					fila.Guardar()
				Catch ex as Exception
				End Try
            Next
        End If

        RaiseEvent Saved()
        
	End Sub
	
	Public Sub Eliminar()
		Dim totalHijos As Long = 0
		If Me.ID <> Nothing Then 
			
            RaiseEvent Deleting()
            
            totalHijos += CYR_Arbol_Detalle.Count

            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            
			CYR_ParametrosDAL.Eliminar(Me.ID)
			
            RaiseEvent Deleted()
            
        End If
	End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As CYR_ParametrosBrl
		
		Dim objCYR_Parametros As New CYR_ParametrosBrl
		
		With objCYR_Parametros
			.ID = fila("Id")
			.Nombre_Label = isDBNullToNothing(fila("Nombre_Label"))
			.Nombre_Componente = isDBNullToNothing(fila("Nombre_Componente"))
            .Id_Tipo = isDBNullToNothing(fila("Id_Tipo"))
            .Nombre_Parametro = isDBNullToNothing(fila("Nombre_Parametro"))

		End With
		
		Return objCYR_Parametros
		
    End Function
	
	Public Shared Event LoadingCYR_ParametrosList(ByVal LoadType As String)
	Public Shared Event LoadedCYR_ParametrosList(target As List(Of CYR_ParametrosBrl), ByVal LoadType As String)
	
	Public Shared Function CargarTodos() As List(Of CYR_ParametrosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_ParametrosBrl)
	
		RaiseEvent LoadingCYR_ParametrosList("CargarTodos")
	
		dsDatos = CYR_ParametrosDAL.CargarTodos()

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_ParametrosList(lista, "CargarTodos")
        
        Return lista
        
    End Function

	Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As CYR_ParametrosBrl)

	Public Shared Function CargarPorID(ID As Int32) As CYR_ParametrosBrl

		Dim dsDatos As System.Data.DataSet
		Dim objCYR_Parametros As CYR_ParametrosBrl = Nothing 
		
        dsDatos = CYR_ParametrosDAL.CargarPorID(ID)
		
		If dsDatos.Tables(0).Rows.Count <> 0 Then objCYR_Parametros = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objCYR_Parametros
        
    End Function

	Public Shared Function CargarPorId_Tipo(ByVal Id_Tipo As Int32) As List(Of CYR_ParametrosBrl)

		Dim dsDatos As System.Data.DataSet
		Dim lista As New List(Of CYR_ParametrosBrl)
	
		RaiseEvent LoadingCYR_ParametrosList("CargarPorId_Tipo")
		
		dsDatos = CYR_ParametrosDAL.CargarPorId_Tipo(Id_Tipo)

        For Each fila as DataRow in dsDatos.Tables(0).Rows
			lista.Add(asignarValoresALasPropiedades(fila))
        Next
        
        RaiseEvent LoadedCYR_ParametrosList(lista, "CargarPorId_Tipo")
        
        Return lista
        
	End Function

End Class


