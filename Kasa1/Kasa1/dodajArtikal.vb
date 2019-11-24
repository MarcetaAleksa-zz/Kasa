Public Class dodajArtikal
    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        pocetna.Panel1.BackColor = Color.Orange
        pocetna.Enabled = True
        pocetna.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

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
    Private Sub UR_Name_TextBox1_Leave(sender As Object, e As EventArgs) Handles UR_Name_TextBox1.Leave
        If (UR_Name_TextBox1.Text = "") Then
            UR_Name_TextBox1.Text = "Unesi naziv proizvoda ovde"
            UR_Name_TextBox1.ForeColor = Color.White
        End If
    End Sub
    Private Sub UR_Name_TextBox1_Enter(sender As Object, e As EventArgs) Handles UR_Name_TextBox1.Enter
        If (UR_Name_TextBox1.Text = "Unesi naziv proizvoda ovde") Then
            UR_Name_TextBox1.Text = ""
            UR_Name_TextBox1.ForeColor = Color.White
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

    Private Sub dodajArtikal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Select()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            baza.Dadapter.Fill(baza.Dtabela)
            baza.Konekcija.Open()
            If baza.Dtabela.Rows.Count = 0 Then

                baza.Dartikli.CommandText = "Insert into dbo.roba (ID, Naziv, Kolicina) VALUES(" & UR_Name_TextBox2.Text & ", '" & UR_Name_TextBox1.Text & "', " & UR_Name_TextBox.Text & ")"
                baza.Dartikli.ExecuteNonQuery()

            Else

                baza.Dartikli.CommandText = "UPDATE roba set kolicina = kolicina +  " & UR_Name_TextBox.Text & "where ID = " & UR_Name_TextBox2.Text & ""
                baza.Dartikli.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            baza.Konekcija.Close()
        End Try
    End Sub
End Class