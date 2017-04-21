Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class CYR_Arbol_DetalleDAL

    Public Shared Function Insertar(ByVal Id_CYR_Arbol As Int32, ByVal Id_CYR_Parametro As Int32, ByVal Orden As Int32, ByVal Activo As Boolean) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_Arbol_DetalleInsertar", isNothingToDBNull(Id_CYR_Arbol), isNothingToDBNull(Id_CYR_Parametro), isNothingToDBNull(Orden), isNothingToDBNull(Activo))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_CYR_Arbol As Int32, ByVal Id_CYR_Parametro As Int32, ByVal Orden As Int32, ByVal Activo As Boolean)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.CYR_Arbol_DetalleActualizar", Id, isNothingToDBNull(Id_CYR_Arbol), isNothingToDBNull(Id_CYR_Parametro), isNothingToDBNull(Orden), isNothingToDBNull(Activo))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_Arbol_DetalleEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_DetalleConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_DetalleConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_CYR_Arbol(ByVal Id_CYR_Arbol As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_DetalleConsultarPorId_CYR_Arbol", Id_CYR_Arbol)
    End Function

    Public Shared Function CargarPorId_CYR_Parametro(ByVal Id_CYR_Parametro As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_DetalleConsultarPorId_CYR_Parametro", Id_CYR_Parametro)
    End Function

    Public Shared Function CargarPorId_CYR_Parametro_Arbol(ByVal Id_CYR_Parametro As System.Int32, ByVal ID_CYR_Arbol As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_DetalleConsultarPorId_CYR_Parametro_Arbol", Id_CYR_Parametro, ID_CYR_Arbol)
    End Function

End Class

