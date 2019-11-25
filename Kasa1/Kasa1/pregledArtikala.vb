Imports System.Data.SqlClient
Public Class pregledArtikala

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PictureBox5_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox5.MouseMove
        PictureBox5.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub PictureBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseMove
        PictureBox6.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        table.Controls.Clear()

        pocetna.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
        pocetna.Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub pregledArtikala_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Kartikli As New SqlCommand("SELECT * FROM roba", baza.Konekcija)
        Dim Aartikli As New SqlDataAdapter(Kartikli)
        Dim Tartikli As New DataTable()


        Dim brojacOpreme As Integer = 0
        Try
            baza.Konekcija.Open()
            Aartikli.Fill(Tartikli)
            brojacOpreme = Tartikli.Rows.Count

            For i = 0 To brojacOpreme
                Dim L2 As Label = New Label
                With L2
                    .Text = Tartikli.Rows(i)(0)           'kolicina izvucena u label
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = True
                    .Font = New Font("Microsoft Sans Serif", 15)
                    .BackColor = Color.Transparent
                    .Anchor = AnchorStyles.Bottom And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
                    '.Dock = DockStyle.Fill
                    table.Controls.Add(L2, 0, i)
                End With
                Dim L As Label = New Label
                With L
                    .AutoSize = True
                    .Text = Tartikli.Rows(i)(1)         'naziv artikla izvucen u label
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = True
                    .Anchor = AnchorStyles.Bottom And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
                    .BackColor = Color.Transparent
                    .Font = New Font("Microsoft Sans Serif", 15)
                    table.Controls.Add(L, 1, i)
                End With

                Dim L1 As Label = New Label
                With L1
                    .Text = Tartikli.Rows(i)(2)           'kolicina izvucena u label
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = True
                    .Font = New Font("Microsoft Sans Serif", 15)
                    .BackColor = Color.Transparent
                    .Anchor = AnchorStyles.Bottom And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
                    '.Dock = DockStyle.Fill
                    table.Controls.Add(L1, 2, i)
                End With

                'Dim L2 As Label = New Label
                'With L2
                '    Dim jjj As Double
                '    jjj = oprema_table.Rows(i)(4)
                '    .Text = jjj.ToString("N2")
                '    .TextAlign = ContentAlignment.MiddleCenter 'cijena izvucena u label
                '    .Visible = True
                '    .Font = New Font("Microsoft Sans Serif", 9)
                '    '.Dock = DockStyle.Fill
                '    table.Controls.Add(L2, 2, i)
                'End With

                'Dim t As TextBox = New TextBox
                'With t
                '    .Text = "0"
                '    .Name = "t" + i.ToString
                '    .Visible = True
                '    .Size = New Size(35, 2)
                '    .Font = New Font("Microsoft Sans Serif", 9) 'tectbox u koji se unosi kolicina koju zelimo kupiti
                '    '.Dock = DockStyle.Fill
                '    table.Controls.Add(t, 3, i)
                'End With

                'Dim L3 As Label = New Label
                'With L3
                '    .Text = ""
                '    .Name = "L3" + i.ToString
                '    .TextAlign = ContentAlignment.MiddleLeft 'label u koji se ispisuje rezultat mnozenja cijene i kolicine
                '    .Visible = True
                '    .Font = New Font("Microsoft Sans Serif", 9)
                '    '.Dock = DockStyle.Fill
                '    table.Controls.Add(L3, 4, i)
                'End With
            Next
        Catch ex As Exception

        Finally
            baza.Konekcija.Close()


        End Try
    End Sub

    Private Sub table_Paint(sender As Object, e As PaintEventArgs) Handles table.Paint

    End Sub

    Private Sub table_CellPaint(sender As Object, e As TableLayoutCellPaintEventArgs) Handles table.CellPaint
        e.Graphics.DrawLine(Pens.Orange, e.CellBounds.Location, New Point(e.CellBounds.Right, e.CellBounds.Top))
    End Sub
End Class