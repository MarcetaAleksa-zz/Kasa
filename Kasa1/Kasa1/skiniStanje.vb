Imports System.Data.SqlClient
Public Class skiniStanje
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
        pocetna.Close()
    End Sub
    Private Sub UR_Name_TextBox_Leave(sender As Object, e As EventArgs) Handles UR_Name_TextBox.Leave
        If (UR_Name_TextBox.Text = "") Then
            UR_Name_TextBox.Text = "Unesi kolicinu ovde"
            UR_Name_TextBox.ForeColor = Color.White
        End If
    End Sub
    Private Sub UR_Name_TextBox_Enter(sender As Object, e As EventArgs) Handles UR_Name_TextBox.Enter
        If (UR_Name_TextBox.Text = "Unesi kolicinu ovde") Then
            UR_Name_TextBox.Text = ""
            UR_Name_TextBox.ForeColor = Color.White
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If (TextBox1.Text = "") Then
            TextBox1.Text = "Unesi naziv proizvoda ovde"
            TextBox1.ForeColor = Color.White
        End If
    End Sub
    Private Sub UR_Name_TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If (TextBox1.Text = "Unesi naziv proizvoda ovde") Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.White
        End If
    End Sub
    Private Sub UR_Name_TextBox2_Leave(sender As Object, e As EventArgs) Handles UR_Name_TextBox2.Leave
        If (UR_Name_TextBox2.Text = "") Then
            UR_Name_TextBox2.Text = "Unesi sifru ovde"
            UR_Name_TextBox2.ForeColor = Color.White
        End If
    End Sub
    Private Sub UR_Name_TextBox2_Enter(sender As Object, e As EventArgs) Handles UR_Name_TextBox2.Enter
        If (UR_Name_TextBox2.Text = "Unesi sifru ovde") Then
            UR_Name_TextBox2.Text = ""
            UR_Name_TextBox2.ForeColor = Color.White
        End If
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim IzbrisiA As New SqlCommand("SELECT ID from roba where id = " & UR_Name_TextBox2.Text & "", baza.Konekcija)
        Dim IzbrisiAda As New SqlDataAdapter(IzbrisiA)
        Dim IzbrisiTab As New DataTable()
        Try
            IzbrisiAda.Fill(IzbrisiTab)
            baza.Konekcija.Open()
            If IzbrisiTab.Rows.Count = 0 Then

                MessageBox.Show("Trazeni artikal ne postoji.")
            Else

                IzbrisiA.CommandText = "UPDATE roba set kolicina = kolicina -  " & UR_Name_TextBox.Text & "where ID = " & UR_Name_TextBox2.Text & ""
                IzbrisiA.ExecuteNonQuery()
                MessageBox.Show("Uspjesno ste skinuli  kolicinu robe u vrijednosti od " + UR_Name_TextBox.Text + " sa stanja, koja se nalazi pod sifrom " + UR_Name_TextBox2.Text + ".")
                UR_Name_TextBox.Text = "Unesi kolicinu ovde"
                UR_Name_TextBox.ForeColor = Color.White
                UR_Name_TextBox2.Text = "Unesi sifru ovde"
                UR_Name_TextBox2.ForeColor = Color.White

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            baza.Konekcija.Close()
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim command As New SqlCommand("SELECT Naziv from roba where ID = " & UR_Name_TextBox2.Text & "", baza.Konekcija)
        Dim adapt As New SqlDataAdapter(command)

        Dim table As New DataTable()
        Try
            adapt.Fill(table)
        Catch ex As Exception

        End Try

        ' MessageBox.Show(table.Rows(0)(0))
        'TextBox1.Text = table.Rows(0)(0)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub UR_Name_TextBox2_TextChanged(sender As Object, e As EventArgs) Handles UR_Name_TextBox2.TextChanged
        Timer1.Start()
        Try
            Dim command As New SqlCommand("SELECT Naziv from roba where ID = " & UR_Name_TextBox2.Text & "", baza.Konekcija)
            Dim adapt As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapt.Fill(table)
            TextBox1.Text = table.Rows(0)(0)

        Catch ex As Exception

        End Try

        'TextBox1.Text = table.Rows(0)(0)



    End Sub
End Class