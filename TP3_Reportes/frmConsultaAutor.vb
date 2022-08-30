Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Public Class frmConsultaAutor
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Try
            Dim NombreIdioma As String = ""
            Dim NombrePais As String = ""
            Dim cantidad As Integer = 0
            Dim Total As Decimal = 0

            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Libro"

            DR = Comando.ExecuteReader
            DgvDatos.Rows.Clear()

            If DR.HasRows Then

                Do While DR.Read
                    If DR("IdAutor") = CmbAutores.SelectedValue And DR("Cantidad") > 0 Then
                        Total = DR("Cantidad") * DR("Precio")
                        NombrePais = BuscarPais(DR("IdPais"))
                        NombreIdioma = BuscarIdioma(DR("IdIdioma"))
                        DgvDatos.Rows.Add(DR("Titulo"), DR("Año"), NombrePais, NombreIdioma, DR("Cantidad"), DR("Precio"), Total)
                        cantidad = cantidad + 1
                    End If
                Loop
            End If
            Conexion.Close()
            LblCantidad.Text = cantidad
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim AD As New StreamWriter("ConsultaDeLibrosPorAutor.CSV", False, Encoding.Default)
            Dim cantidad As Integer = 0
            Dim NombreIdioma As String = ""
            Dim NombrePais As String = ""
            Dim total As Decimal = 0

            AD.Write("Autor:")
            AD.Write(";")
            AD.WriteLine(CmbAutores.Text)
            AD.WriteLine("Titulo;Año;Pais;Idioma;Cantidad;Precio;Total")
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Libro"

            DR = Comando.ExecuteReader
            DgvDatos.Rows.Clear()

            While DR.Read
                If DR("IdAutor") = CmbAutores.SelectedValue Then
                    total = DR("Cantidad") * DR("Precio")
                    NombrePais = BuscarPais(DR("IdPais"))
                    NombreIdioma = BuscarIdioma(DR("IdIdioma"))
                    AD.Write(DR("Titulo"))
                    AD.Write(";")
                    AD.Write(DR("Año"))
                    AD.Write(";")
                    AD.Write(NombrePais)
                    AD.Write(";")
                    AD.Write(NombreIdioma)
                    AD.Write(";")
                    AD.Write(DR("Cantidad"))
                    AD.Write(";")
                    AD.Write(FormatCurrency(DR("Precio")))
                    AD.Write(";")
                    AD.Write(FormatCurrency(total))
                    cantidad = cantidad + 1
                End If
            End While
            AD.WriteLine(";")
            AD.WriteLine(";;Cantidad de libros del autor: ;" & cantidad)
            Conexion.Close()
            AD.Close()
            LblCantidad.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub
    Private Sub FrmConsultaLibrosAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Autor"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            CmbAutores.DataSource = DS.Tables(0)
            CmbAutores.ValueMember = "IdAutor"
            CmbAutores.DisplayMember = "Nombre"

            Conexion.Close()
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
        Dim LetraTexto As New Font("Arial", 8)
        Dim cantidad As Integer = 0
        Dim fila As Integer = 100
        Dim titulo As String = "Escrito por el autor :  " & CmbAutores.Text
        Dim NombrePais = ""
        Dim NombreIdioma = ""
        Dim total As Decimal = 0

        e.Graphics.DrawString(titulo, LetraTitulo, Brushes.Black, 80, 40)
        e.Graphics.DrawString("Nombre", LetraTituloColumna, Brushes.Black, 50, 70)
        e.Graphics.DrawString("Año", LetraTituloColumna, Brushes.Black, 300, 70)
        e.Graphics.DrawString("País", LetraTituloColumna, Brushes.Black, 450, 70)
        e.Graphics.DrawString("Idioma", LetraTituloColumna, Brushes.Black, 580, 70)
        e.Graphics.DrawString("Cantidad", LetraTituloColumna, Brushes.Black, 655, 70)
        e.Graphics.DrawString("Precio", LetraTituloColumna, Brushes.Black, 740, 70)
        e.Graphics.DrawString("Total", LetraTituloColumna, Brushes.Black, 810, 70)

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        DR = Comando.ExecuteReader
        If DR.HasRows Then
            Do While DR.Read
                If DR("IdAutor") = CmbAutores.SelectedValue Then
                    total = DR("Cantidad") * DR("Precio")
                    NombrePais = BuscarPais(DR("IdPais"))
                    NombreIdioma = BuscarIdioma(DR("IdIdioma"))
                    e.Graphics.DrawString(DR("Titulo"), LetraTexto, Brushes.Black, 50, fila)
                    e.Graphics.DrawString(DR("Año"), LetraTexto, Brushes.Black, 300, fila)
                    e.Graphics.DrawString(NombrePais, LetraTexto, Brushes.Black, 450, fila)
                    e.Graphics.DrawString(NombreIdioma, LetraTexto, Brushes.Black, 590, fila)
                    e.Graphics.DrawString(DR("Cantidad"), LetraTexto, Brushes.Black, 650, fila)
                    e.Graphics.DrawString(FormatCurrency(DR("Precio")), LetraTexto, Brushes.Black, 740, fila)
                    e.Graphics.DrawString(FormatCurrency(total), LetraTexto, Brushes.Black, 810, fila)
                    cantidad = cantidad + 1
                    fila = fila + 15
                End If
            Loop
        End If
        Conexion.Close()
        e.Graphics.DrawString("Cantidad de libros", LetraTituloColumna, Brushes.Black, 50, 800)
        e.Graphics.DrawString(cantidad, LetraTexto, Brushes.Black, 120, 810)
    End Sub
End Class