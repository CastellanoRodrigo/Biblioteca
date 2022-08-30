
Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Module Datos_GLOBALES
    Public Conexion As New OleDbConnection
    Public Comando As New OleDbCommand
    Public Adaptador As New OleDbDataAdapter
    Public DR As OleDbDataReader
    Public DS As DataSet

    Public CadenaDeConexion As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=Libreria.mdb"
    Public Function BuscarIdioma(Cod As Integer) As String
        Dim nombre As String = ""
        Dim ConexionIdioma As New OleDb.OleDbConnection
        Dim ComandoIdioma As New OleDb.OleDbCommand
        Dim DRIdioma As OleDbDataReader

        ConexionIdioma.ConnectionString = CadenaDeConexion
        ConexionIdioma.Open()

        ComandoIdioma.Connection = ConexionIdioma
        ComandoIdioma.CommandType = CommandType.TableDirect
        ComandoIdioma.CommandText = "Idioma"

        DRIdioma = ComandoIdioma.ExecuteReader
        If DRIdioma.HasRows Then
            While DRIdioma.Read
                If DRIdioma("IdIdioma") = Cod Then
                    nombre = DRIdioma("Nombre")
                End If
            End While
        End If
        ConexionIdioma.Close()
        Return nombre
    End Function

    Public Function BuscarPais(Cod As Integer) As String
        Dim nombre As String = ""
        Dim ConexionPais As New OleDb.OleDbConnection
        Dim ComandoPais As New OleDb.OleDbCommand
        Dim DRPais As OleDbDataReader

        ConexionPais.ConnectionString = CadenaDeConexion
        ConexionPais.Open()

        ComandoPais.Connection = ConexionPais
        ComandoPais.CommandType = CommandType.TableDirect
        ComandoPais.CommandText = "Pais"

        DRPais = ComandoPais.ExecuteReader
        If DRPais.HasRows Then
            While DRPais.Read
                If DRPais("IdPais") = Cod Then
                    nombre = DRPais("Nombre")
                End If
            End While
        End If
        ConexionPais.Close()
        Return nombre
    End Function

    Public Function BuscarAutor(Cod As Integer) As String
        Dim nombre As String = ""
        Dim ConexionAutor As New OleDb.OleDbConnection
        Dim ComandoAutor As New OleDb.OleDbCommand
        Dim DRAutor As OleDbDataReader

        ConexionAutor.ConnectionString = CadenaDeConexion
        ConexionAutor.Open()

        ComandoAutor.Connection = ConexionAutor
        ComandoAutor.CommandType = CommandType.TableDirect
        ComandoAutor.CommandText = "Autor"

        DRAutor = ComandoAutor.ExecuteReader
        If DRAutor.HasRows Then
            While DRAutor.Read
                If DRAutor("IdAutor") = Cod Then
                    nombre = DRAutor("Nombre")
                End If
            End While
        End If
        ConexionAutor.Close()
        Return nombre
    End Function
    Dim prtDialog As New PrintDialog

    Public Function BuscarLibro(Cod As Integer) As String
        Dim nombre As String = ""
        Dim ConexionLibro As New OleDb.OleDbConnection
        Dim ComandoLibro As New OleDb.OleDbCommand
        Dim DRLibro As OleDbDataReader

        ConexionLibro.ConnectionString = CadenaDeConexion
        ConexionLibro.Open()

        ComandoLibro.Connection = ConexionLibro
        ComandoLibro.CommandType = CommandType.TableDirect
        ComandoLibro.CommandText = "Libro"

        DRLibro = ComandoLibro.ExecuteReader
        If DRLibro.HasRows Then
            While DRLibro.Read
                If DRLibro("IdLibro") = Cod Then
                    nombre = DRLibro("Titulo")
                End If
            End While
        End If
        ConexionLibro.Close()
        Return nombre
    End Function
End Module