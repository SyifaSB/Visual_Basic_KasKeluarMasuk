Imports System.Data.Odbc
Public Class Form1
    Dim SaldoSekarang As String
    Sub TampilGrid()
        bukakoneksi()

        DA = New OdbcDataAdapter("Select * From tbl_kaskeluarmasuk", CONN)
        DS = New DataSet
        DA.Fill(DS, "tbl_kaskeluarmasuk")
        DataGridView1.DataSource = DS.Tables("tbl_kaskeluarmasuk")

        tutupkoneksi()
    End Sub
    Sub getSaldoUtama()
        bukakoneksi()
        CMD = New OdbcCommand("Select * From tbl_kaskeluarmasuk order by id desc limit 1", CONN)
        RD = CMD.ExecuteReader
        RD.Read()

        If RD.HasRows Then
            Label6.Text = "Rp 0"
        Else
            Label6.Text = RD.Item("SaldoUtama") = SaldoUtama = RD.Item("SaldoUtama")
        End If
        tutupkoneksi()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        MunculCombo()
        getSaldoUtama()
    End Sub

    Sub MunculCombo()
        ComboBox1.Items.Add("Masuk")
        ComboBox1.Items.Add("Keluar")
    End Sub

    Sub KosongkanData()
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox4.Text = " "
        TextBox5.Text = " "
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        Else
            If ComboBox1.Text = "Masuk" Then
                Dim saldoBaru As Integer
                Dim saldoMasuk As Integer = CInt(TextBox4.Text)
                Dim saldoTerakhir As Integer = CInt(SaldoSekarang)
                saldoBaru = saldoMasuk + saldoTerakhir

                bukakoneksi()
                Dim simpan As String = " insert into tbl_kaskeluarmasuk values ('" & TextBox1.Text & "','" & TextBox2.Text &
                    "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & saldoBaru & "','" & TextBox5.Text & "')"

                CMD = New OdbcCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                TampilGrid()
                KosongkanData()
                getSaldoUtama()
                tutupkoneksi()

            ElseIf ComboBox1.Text = "Keluar" Then
                Dim saldoBaru As Integer
                Dim saldoKeluar As Integer = CInt(TextBox4.Text)
                Dim saldoTerakhir As Integer = CInt(SaldoSekarang)
                saldoBaru = saldoTerakhir - saldoKeluar

                bukakoneksi()
                Dim simpan As String = " insert into tbl_kaskeluarmasuk values ('" & TextBox1.Text & "','" & TextBox2.Text &
                    "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & saldoBaru & "','" & TextBox5.Text & "')"

                CMD = New OdbcCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                TampilGrid()
                KosongkanData()
                getSaldoUtama()
                tutupkoneksi()


            End If

        End If
    End Sub

    Private Sub TextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 10
        If e.KeyChar = Chr(13) Then
            bukakoneksi()
            CMD = New OdbcCommand("Select * From tbl_kaskeluarmasuk WHERE id='" & TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                MsgBox("Id Tidak Ada, Silahkan coba lagi!")
                TextBox4.Focus()
            Else
                TextBox2.Text = RD.Item("nama")
                TextBox4.Text = RD.Item("jumlah")
                TextBox5.Text = RD.Item("keterangan")
                ComboBox1.Text = RD.Item("jenis")
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bukakoneksi()
        Dim edit As String = "update tbl_kaskeluarmasuk nama='" & TextBox2.Text & "', jumlah='" & TextBox4.Text & "', keterangan='" & TextBox5.Text & "', jenis='" & ComboBox1.Text & "' where id='" & TextBox1.Text & "'"

        CMD = New OdbcCommand(edit, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data berhasil di update")
        TampilGrid()
        KosongkanData()
        tutupkoneksi()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Silahkan pilih data yang akan dihapus dengan masukan Id lalu tekan ENTER")
        Else
            If MessageBox.Show("Yakin ingin menghapus data?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                bukakoneksi()
                Dim hapus As String = "delete From tbl_kaskeluarmasuk where id='" & TextBox1.Text & "'"
                CMD = New OdbcCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Diupdate")
                TampilGrid()
                KosongkanData()
                tutupkoneksi()
            End If
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub SaldoUtama_Click(sender As Object, e As EventArgs) Handles SaldoUtama.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
