Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class CYR_ArbolDAL

    Public Shared Function Insertar(ByVal Descripcion As String, ByVal Id_Padre As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_ArbolInsertar", isNothingToDBNull(Descripcion), isNothingToDBNull(Id_Padre))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Descripcion As String, ByVal Id_Padre As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.CYR_ArbolActualizar", Id, isNothingToDBNull(Descripcion), isNothingToDBNull(Id_Padre))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_ArbolEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ArbolConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ArbolConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Padre(ByVal Id_Padre As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ArbolConsultarPorId_Padre", Id_Padre)
    End Function



End Class

