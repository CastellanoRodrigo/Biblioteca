Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class FrmModificarIdioma
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            TxtNombre.Text = BuscarAutor(TxtCodigoAutor.Text)

            Dim nombre As String = BuscarAutor(TxtCodigoAutor.Text)
            If nombre <> "" Then
                btnGuardar.Enabled = True
                TxtNombre.Enabled = True
                TxtCodigoAutor.Enabled = False
                TxtNombre.Text = nombre
            Else
                btnGuardar.Enabled = False
                TxtNombre.Text = False
                TxtCodigoAutor.Text = True
                MessageBox.Show("No se ha encontrado el código")
            End If
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim Dato As String = ""

            Dato = "update Autor set Nombre = '" & TxtNombre.Text & "' where IdAutor =" & TxtCodigoAutor.Text
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()
            Comando.Connection = Conexion
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Dato
            Comando.ExecuteReader()
            Conexion.Close()
            MessageBox.Show("Dato Modificado")
            btnBuscar.Enabled = True
            TxtCodigoAutor.Enabled = True
            TxtCodigoAutor.Text = ""
            TxtNombre.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub
End Class