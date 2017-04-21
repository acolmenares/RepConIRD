Imports Microsoft.ApplicationBlocks.Data
Imports ingNovar.Utilidades2

Public Class CYR_Arbol_ProcesosDAL

    Public Shared Function Insertar(ByVal Id_CYR_Arbol As Int32, ByVal Id_Tipo_Consulta As Int32, ByVal Descripcion As String) As Int32
        Return SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_Arbol_ProcesosInsertar", isNothingToDBNull(Id_CYR_Arbol), isNothingToDBNull(Id_Tipo_Consulta), isNothingToDBNull(Descripcion))
    End Function

    Public Shared Sub Actualizar(ByVal Id As Int32, ByVal Id_CYR_Arbol As Int32, ByVal Id_Tipo_Consulta As Int32, ByVal Descripcion As String)
        SqlHelper.ExecuteNonQuery(strCadenaConexion, "dbo.CYR_Arbol_ProcesosActualizar", Id, isNothingToDBNull(Id_CYR_Arbol), isNothingToDBNull(Id_Tipo_Consulta), isNothingToDBNull(Descripcion))
    End Sub

    Public Shared Sub Eliminar(ByVal Id As Int32)
        SqlHelper.ExecuteScalar(strCadenaConexion, "dbo.CYR_Arbol_ProcesosEliminar", Id)
    End Sub

    Public Shared Function CargarTodos() As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_ProcesosConsultarTodos")
    End Function

    Public Shared Function CargarPorID(ByVal Id As Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_ProcesosConsultarPorID", Id)
    End Function
    
    Public Shared Function CargarPorId_CYR_Arbol(ByVal Id_CYR_Arbol As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_ProcesosConsultarPorId_CYR_Arbol", Id_CYR_Arbol)
    End Function


    Public Shared Function CargarPorId_Tipo_Consulta(ByVal Id_Tipo_Consulta As System.Int32) As System.Data.DataSet
        Return SqlHelper.ExecuteDataset(strCadenaConexion, "dbo.CYR_Arbol_ProcesosConsultarPorId_Tipo_Consulta", Id_Tipo_Consulta)
    End Function



End Class

