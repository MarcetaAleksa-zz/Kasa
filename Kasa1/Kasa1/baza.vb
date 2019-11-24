Imports System.Data.SqlClient
Public Class baza
    Public Shared Konekcija As New SqlConnection("SERVER = napoleon\sqlexpress; Database = Kasa; Integrated Security = true")
    Public Shared Kartikli As New SqlCommand("SELECT * FROM roba", Konekcija)
    Public Shared Aartikli As New SqlDataAdapter(Kartikli)
    Public Shared Tartikli As New DataTable()
    Public Shared Dartikli As New SqlCommand("SELECT ID from roba where id = " & dodajArtikal.UR_Name_TextBox2.Text & "", Konekcija)
    Public Shared Dadapter As New SqlDataAdapter(Dartikli)
    Public Shared Dtabela As New DataTable()

End Class
