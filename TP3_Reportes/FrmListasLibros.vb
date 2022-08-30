Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Public Class FrmListasLibros
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Libro"

            DR = Comando.ExecuteReader
            DgvLibros.Rows.Clear()

            If DR.HasRows Then
                Do While DR.Read
                    DgvLibros.Rows.Add(DR("IdLibro"), DR("Titulo"))
                Loop
            End If

            Conexion.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim AD As New StreamWriter("ListadoDeLibros.CSV", False, Encoding.Default)

            AD.Write("IdLibro")
            AD.Write(";")
            AD.WriteLine("Titulo")

            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Libro"

            DR = Comando.ExecuteReader
            DgvLibros.Rows.Clear()

            While DR.Read
                AD.Write(DR("IdLibro"))
                AD.Write(";")
                AD.WriteLine(DR("Titulo"))
            End While
            Conexion.Close()
            AD.Close()
            MessageBox.Show("Exportado con éxito")
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
        Dim titulo As String = "Lista de Libros"
        e.Graphics.DrawString(titulo, LetraTitulo, Brushes.Black, 80, 40)
        e.Graphics.DrawString("IdLibro", LetraTituloColumna, Brushes.Black, 240, 80)
        e.Graphics.DrawString("Titulo", LetraTituloColumna, Brushes.Black, 340, 80)

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        DR = Comando.ExecuteReader

        If DR.HasRows Then
            While DR.Read
                e.Graphics.DrawString(DR("IdLibro"), LetraTexto, Brushes.Black, 250, fila)
                e.Graphics.DrawString(DR("Titulo"), LetraTexto, Brushes.Black, 350, fila)
                fila = fila + 15
            End While
        End If
        Conexion.Close()
    End Sub


End Class
