Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Public Class FrmAgregarLibro

    Private Sub btnGrabar_Click_1(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Libro"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            Dim tabla As DataTable = DS.Tables(0)
            Dim fila As DataRow = tabla.NewRow()
            fila("Titulo") = txtNombre.Text
            fila("IdAutor") = CmbAutor.SelectedValue
            fila("Año") = TxtAño.Text
            fila("IdPais") = CmbPais.SelectedValue
            fila("IdIdioma") = CmbIdioma.SelectedValue
            fila("Cantidad") = TxtCantidad.Text
            fila("Precio") = TxtPrecio.Text
            tabla.Rows.Add(fila)


            Dim ComandoParaGrabar As New OleDbCommandBuilder(Adaptador)
            Adaptador.Update(DS)

            Conexion.Close()
            MessageBox.Show("Datos grabados")
            txtNombre.Text = ""
            TxtAño.Text = ""
            TxtCantidad.Text = ""
            TxtPrecio.Text = ""
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub control()
        If TxtNombre.Text <> "" And TxtAño.Text <> "" And TxtCantidad.Text <> "" And TxtPrecio.Text <> "" Then
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub CargaAutor()
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Autor"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            CmbAutor.DataSource = DS.Tables(0)
            CmbAutor.ValueMember = "IdAutor"
            CmbAutor.DisplayMember = "Nombre"

            Conexion.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub


    Private Sub CargaIdioma()
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Idioma"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            CmbIdioma.DataSource = DS.Tables(0)
            CmbIdioma.ValueMember = "IdIdioma"
            CmbIdioma.DisplayMember = "Nombre"

            Conexion.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub CargaPais()
        Try
            Conexion.ConnectionString = CadenaDeConexion
            Conexion.Open()

            Comando.Connection = Conexion
            Comando.CommandType = CommandType.TableDirect
            Comando.CommandText = "Pais"

            Adaptador = New OleDbDataAdapter(Comando)
            DS = New DataSet
            Adaptador.Fill(DS)

            CmbPais.DataSource = DS.Tables(0)
            CmbPais.ValueMember = "IdPais"
            CmbPais.DisplayMember = "Nombre"

            Conexion.Close()
        Catch
            MessageBox.Show(ErrorToString)
        End Try
    End Sub

    Private Sub FrmAgregarLibro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaAutor()
        CargaIdioma()
        CargaPais()
    End Sub

    Private Sub TxtNombre_TextChanged(sender As Object, e As EventArgs) Handles TxtNombre.TextChanged
        control()
    End Sub

    Private Sub TxtAño_TextChanged(sender As Object, e As EventArgs) Handles TxtAño.TextChanged
        control()
    End Sub

    Private Sub TxtCantidad_TextChanged(sender As Object, e As EventArgs) Handles TxtCantidad.TextChanged
        control()
    End Sub

    Private Sub TxtPrecio_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecio.TextChanged
        control()
    End Sub
End Class