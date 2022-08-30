Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class FrmAgregarAutor
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Autor"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            Dim tabla As DataTable = DS.Tables(0)
            Dim fila As DataRow = tabla.NewRow()
            fila("Nombre") = TxtNombre.Text
            tabla.Rows.Add(fila)

            Dim ComandoParaGrabar As New OleDbCommandBuilder(Adaptador)
            Adaptador.Update(DS)

            Conexion.Close()
            MessageBox.Show("Datos grabados")
            TxtNombre.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub
End Class