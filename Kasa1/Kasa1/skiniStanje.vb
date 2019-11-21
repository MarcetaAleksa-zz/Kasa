Public Class skiniStanje
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
        pocetna.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        pocetna.Show()
    End Sub
    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub PictureBox5_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox5.MouseMove
        PictureBox5.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub PictureBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseMove
        PictureBox6.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub skiniStanje_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Label1.Select()
    End Sub
End Class