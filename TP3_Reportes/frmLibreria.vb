Public Class frmLibreria


    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        FrmAcercaDe.Show()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LibrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosToolStripMenuItem.Click
        FrmListasLibros.Show()
    End Sub

    Private Sub AutoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoresToolStripMenuItem.Click
        FrmListasAutor.Show()
    End Sub

    Private Sub IdiomasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdiomasToolStripMenuItem.Click
        FrmListasIdioma.Show()
    End Sub

    Private Sub PaisesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaisesToolStripMenuItem.Click
        FrmListasPais.Show()
    End Sub

    Private Sub OLibrosDeUnPaísToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OLibrosDeUnPaísToolStripMenuItem.Click
        frmConsultaPais.Show
    End Sub

    Private Sub LibrosDeUnAutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosDeUnAutorToolStripMenuItem.Click
        frmConsultaAutor.Show()
    End Sub

    Private Sub LibrosDeUnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosDeUnToolStripMenuItem.Click
        frmConsultaIdioma.Show
    End Sub

    Private Sub LibrosDeUnPaísToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosDeUnPaísToolStripMenuItem.Click
        FrmEstadisticasLPorP.Show()
    End Sub

    Private Sub LibrosDeUnAutorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LibrosDeUnAutorToolStripMenuItem1.Click
        FrmEstadisticasLPorA.Show()
    End Sub

    Private Sub LibrosDeUnIdiomaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibrosDeUnIdiomaToolStripMenuItem.Click
        FrmEstadisticasLPorI.Show()
    End Sub

    Private Sub LibroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibroToolStripMenuItem.Click
        FrmAgregarLibro.Show()
    End Sub

    Private Sub PaísToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaísToolStripMenuItem.Click
        FrmAgregarPais.Show()
    End Sub

    Private Sub AutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorToolStripMenuItem.Click
        FrmAgregarAutor.Show()
    End Sub

    Private Sub IdiomaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IdiomaToolStripMenuItem1.Click
        FrmAgregarIdioma.Show()
    End Sub

    Private Sub LibroToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LibroToolStripMenuItem1.Click
        FrmModificarLibro.Show()
    End Sub

    Private Sub PaísToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PaísToolStripMenuItem1.Click
        FrmModificarPais.Show()
    End Sub

    Private Sub AutorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutorToolStripMenuItem1.Click
        FrmModificarAutor.Show()
    End Sub

    Private Sub IdiomaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdiomaToolStripMenuItem.Click
        FrmModificarIdioma.Show()
    End Sub

End Class