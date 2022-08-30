Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Public Class FrmEstadisticasLPorp
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "TitulosPorPais"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            DgvDatos.DataSource = DS.Tables(0)

            Conexion.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim AD As New StreamWriter("EstadisticasPorPais.CSV", False, Encoding.Default)

            AD.Write("Nombre del pais")
            AD.Write(";")
            AD.WriteLine("Cantidad de Libros")
            AD.WriteLine("")

            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "TitulosPorPais"

            DR = Comando.ExecuteReader
            DgvDatos.DataSource = ""

            While DR.Read
                AD.Write(DR("Nombre"))
                AD.Write(";")
                AD.WriteLine(DR("CantidadLibro"))
            End While
            Conexion.Close()
            AD.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        DialogoImpresora.ShowDialog()
        DocumentoImprimir.PrinterSettings = DialogoImpresora.PrinterSettings
        DocumentoImprimir.Print()
    End Sub

    Private Sub DocumentoImprimir_PrintPage(sender As Object, e As PrintPageEventArgs) Handles DocumentoImprimir.PrintPage
        Dim LetraTitulo As New Font("Arial", 16)
        Dim LetraTituloColumna As New Font("Arial", 12)
        Dim LetraTexto As New Font("Arial", 10)

        Dim fila As Integer = 110
        Dim titulo As String = "Estadisticas de libros de :  "

        e.Graphics.DrawString(titulo, LetraTitulo, Brushes.Black, 80, 40)
        e.Graphics.DrawString("IdPais", LetraTituloColumna, Brushes.Black, 240, 80)
        e.Graphics.DrawString("Nombre", LetraTituloColumna, Brushes.Black, 340, 80)

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        DR = Comando.ExecuteReader

        If DR.HasRows Then
            While DR.Read
                e.Graphics.DrawString(DR("IdPais"), LetraTexto, Brushes.Black, 250, fila)
                e.Graphics.DrawString(DR("Titulo"), LetraTexto, Brushes.Black, 350, fila)
                fila = fila + 15
            End While
        End If
        Conexion.Close()

    End Sub
End Class