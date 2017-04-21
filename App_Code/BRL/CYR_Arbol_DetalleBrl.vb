Imports ingNovar.Utilidades2
Imports System.Data
Imports System.Collections.Generic

Partial Public Class CYR_Arbol_DetalleBrl

    Private _Id As Int32
    Private _Id_CYR_Arbol As Int32
    Private _Id_CYR_Parametro As Int32
    Private _Orden As Int32
    Private _Activo As Boolean


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

    Public Event Id_CYR_ParametroChanging(ByVal Value As Int32)
    Public Event Id_CYR_ParametroChanged()


    Public Property Id_CYR_Parametro() As Int32
        Get
            Return Me._Id_CYR_Parametro
        End Get
        Set(ByVal Value As Int32)
            If _Id_CYR_Parametro <> Value Then
                RaiseEvent Id_CYR_ParametroChanging(Value)
                Me._Id_CYR_Parametro = Value
                RaiseEvent Id_CYR_ParametroChanged()
            End If
        End Set
    End Property

    Public Event OrdenChanging(ByVal Value As Int32)
    Public Event OrdenChanged()

    Public Property Orden() As Int32
        Get
            Return Me._Orden
        End Get
        Set(ByVal Value As Int32)
            If _Orden <> Value Then
                RaiseEvent OrdenChanging(Value)
                Me._Orden = Value
                RaiseEvent OrdenChanged()
            End If
        End Set
    End Property

    Public Event ActivoChanging(ByVal Value As Boolean)
    Public Event ActivoChanged()


    Public Property Activo() As Boolean
        Get
            Return Me._Activo
        End Get
        Set(ByVal Value As Boolean)
            If _Activo <> Value Then
                RaiseEvent ActivoChanging(Value)
                Me._Activo = Value
                RaiseEvent ActivoChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property CYR_Arbol() As CYR_ArbolBrl
        Get
            Return CYR_ArbolBrl.CargarPorID(Id_CYR_Arbol)
        End Get
    End Property

    Public ReadOnly Property CYR_Parametros() As CYR_ParametrosBrl
        Get
            Return CYR_ParametrosBrl.CargarPorID(Id_CYR_Parametro)
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
            Me.ID = CYR_Arbol_DetalleDAL.Insertar(Id_CYR_Arbol, Id_CYR_Parametro, Orden, Activo)
            RaiseEvent Inserted()
        Else
            RaiseEvent Updating()
            CYR_Arbol_DetalleDAL.Actualizar(ID, Id_CYR_Arbol, Id_CYR_Parametro, Orden, Activo)
            RaiseEvent Updated()
        End If

        RaiseEvent Saved()

    End Sub

    Public Sub Eliminar()
        Dim totalHijos As Long = 0
        If Me.ID <> Nothing Then

            RaiseEvent Deleting()
            If totalHijos > 0 Then Throw New Exception("No se puede eliminar el registro porque existen datos que dependen de él.")
            CYR_Arbol_DetalleDAL.Eliminar(Me.ID)

            RaiseEvent Deleted()

        End If
    End Sub

    Private Shared Function asignarValoresALasPropiedades(ByVal fila As DataRow) As CYR_Arbol_DetalleBrl

        Dim objCYR_Arbol_Detalle As New CYR_Arbol_DetalleBrl

        With objCYR_Arbol_Detalle
            .ID = fila("Id")
            .Id_CYR_Arbol = isDBNullToNothing(fila("Id_CYR_Arbol"))
            .Id_CYR_Parametro = isDBNullToNothing(fila("Id_CYR_Parametro"))
            .Orden = isDBNullToNothing(fila("Orden"))
            .Activo = isDBNullToNothing(fila("Activo"))

        End With

        Return objCYR_Arbol_Detalle

    End Function

    Public Shared Event LoadingCYR_Arbol_DetalleList(ByVal LoadType As String)
    Public Shared Event LoadedCYR_Arbol_DetalleList(ByVal target As List(Of CYR_Arbol_DetalleBrl), ByVal LoadType As String)

    Public Shared Function CargarTodos() As List(Of CYR_Arbol_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of CYR_Arbol_DetalleBrl)

        RaiseEvent LoadingCYR_Arbol_DetalleList("CargarTodos")

        dsDatos = CYR_Arbol_DetalleDAL.CargarTodos()

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedCYR_Arbol_DetalleList(lista, "CargarTodos")

        Return lista

    End Function

    Public Shared Event LoadingPorId(ByVal id As Int32)
    Public Shared Event LoadedPorId(ByVal target As CYR_Arbol_DetalleBrl)

    Public Shared Function CargarPorID(ByVal ID As Int32) As CYR_Arbol_DetalleBrl

        Dim dsDatos As System.Data.DataSet
        Dim objCYR_Arbol_Detalle As CYR_Arbol_DetalleBrl = Nothing

        dsDatos = CYR_Arbol_DetalleDAL.CargarPorID(ID)

        If dsDatos.Tables(0).Rows.Count <> 0 Then objCYR_Arbol_Detalle = asignarValoresALasPropiedades(dsDatos.Tables(0).Rows(0))

        Return objCYR_Arbol_Detalle

    End Function

    Public Shared Function CargarPorId_CYR_Arbol(ByVal Id_CYR_Arbol As Int32) As List(Of CYR_Arbol_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of CYR_Arbol_DetalleBrl)

        RaiseEvent LoadingCYR_Arbol_DetalleList("CargarPorId_CYR_Arbol")

        dsDatos = CYR_Arbol_DetalleDAL.CargarPorId_CYR_Arbol(Id_CYR_Arbol)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedCYR_Arbol_DetalleList(lista, "CargarPorId_CYR_Arbol")

        Return lista

    End Function

    Public Shared Function CargarPorId_CYR_Parametro(ByVal Id_CYR_Parametro As Int32) As List(Of CYR_Arbol_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of CYR_Arbol_DetalleBrl)

        RaiseEvent LoadingCYR_Arbol_DetalleList("CargarPorId_CYR_Parametro")

        dsDatos = CYR_Arbol_DetalleDAL.CargarPorId_CYR_Parametro(Id_CYR_Parametro)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        RaiseEvent LoadedCYR_Arbol_DetalleList(lista, "CargarPorId_CYR_Parametro")

        Return lista

    End Function

    Public Shared Function CargarPorId_CYR_Parametro_Arbol(ByVal Id_CYR_Parametro As Int32, ByVal Id_CYR_Arbol As Int32) As List(Of CYR_Arbol_DetalleBrl)

        Dim dsDatos As System.Data.DataSet
        Dim lista As New List(Of CYR_Arbol_DetalleBrl)

        dsDatos = CYR_Arbol_DetalleDAL.CargarPorId_CYR_Parametro_Arbol(Id_CYR_Parametro, Id_CYR_Arbol)

        For Each fila As DataRow In dsDatos.Tables(0).Rows
            lista.Add(asignarValoresALasPropiedades(fila))
        Next

        Return lista

    End Function

End Class


