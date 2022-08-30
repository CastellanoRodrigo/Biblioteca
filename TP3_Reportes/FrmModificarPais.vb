Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class FrmModificarPais
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            TxtPais.Text = BuscarPais(TxtCodigoPais.Text)

            Dim nombre As String = BuscarPais(TxtCodigoPais.Text)
            If nombre <> "" Then
                btnGuardar.Enabled = True
                TxtPais.Enabled = True
                TxtCodigoPais.Enabled = False
                TxtPais.Text = nombre
            Else
                btnGuardar.Enabled = False
                TxtPais.Text = False
                TxtCodigoPais.Text = True
                MessageBox.Show("No se ha encontrado el código")
            End If
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim Dato As String = ""

            Dato = "update pais set Nombre = '" & TxtPais.Text & "' where IdPais =" & TxtCodigoPais.Text
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()
            Comando.Connection = Conexion
            Comando.CommandType = CommandType.Text
            Comando.CommandText = Dato
            Comando.ExecuteReader()
            Conexion.Close()
            MessageBox.Show("Dato Modificado")
            btnBuscar.Enabled = True
            TxtCodigoPais.Enabled = True
            TxtCodigoPais.Text = ""
            TxtPais.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub
End Class