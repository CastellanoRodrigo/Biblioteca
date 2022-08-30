Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class FrmModificarLibro
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            txtCodigo.Text = BuscarLibro(txtCodigo.Text)

            Dim nombre As String = BuscarLibro(txtCodigo.Text)
            If nombre <> "" Then
                btnGuardar.Enabled = True
                txtCodigo.Enabled = True
                txtCodigo.Enabled = False
                txtCodigo.Text = nombre
            Else
                btnGuardar.Enabled = False
                txtCodigo.Text = False
                txtCodigo.Text = True
                MessageBox.Show("No se ha encontrado el código")
            End If
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim Dato As String = ""

            Dato = "update libro set Titulo = '" & txtCodigo.Text & "' where IdLibro =" & txtCodigo.Text
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()
            Comando.Connection = Conexion
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Dato
            Comando.ExecuteReader()
            Conexion.Close()
            MessageBox.Show("Dato Modificado")
            btnBuscar.Enabled = True
            txtCodigo.Enabled = True
            txtCodigo.Text = ""
            txtCodigo.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub


End Class