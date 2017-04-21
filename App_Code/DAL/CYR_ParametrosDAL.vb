Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class CYR_ParametrosDAL

    Public Shared Function Insertar(ByVal Nombre_Label As String, ByVal Nombre_Componente As String, ByVal Id_Tipo As Int32) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_ParametrosInsertar", isNothingToDBNull(Nombre_Label), isNothingToDBNull(Nombre_Componente), isNothingToDBNull(Id_Tipo))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Nombre_Label As String, ByVal Nombre_Componente As String, ByVal Id_Tipo As Int32)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.CYR_ParametrosActualizar", Id, isNothingToDBNull(Nombre_Label), isNothingToDBNull(Nombre_Componente), isNothingToDBNull(Id_Tipo))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_ParametrosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ParametrosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ParametrosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_Tipo(ByVal Id_Tipo As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_ParametrosConsultarPorId_Tipo", Id_Tipo)
    End Function



End Class

