Imports System.Configuration.ConfigurationManager

Public Module Conexiones

    Public strCadenaConexion As String = AppSettings("BDIRD")
    Public StrConectaUsr As String = AppSettings("BDIRD")
    Public strCadenaLB As String = AppSettings("BDPRMLINEABASE")
    Public TiempoConexion As String = AppSettings("TiempoConexion")
    Public strPaginaError As String = AppSettings("PaginaError")
End Module