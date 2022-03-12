Imports MySql.Data.MySqlClient
Public Class Form1
    Dim cn As New MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim tabel As New DataTable
    Private Sub koneksinya()
        cn.ConnectionString = "server=localhost;user=root;password=;database=coba;allow user variables=true"
    End Sub

    Private Sub DesainDGV()
        Dim SQL As String
        SQL = "SELECT * FROM tb_coba ORDER BY kode ASC;"
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = SQL
        da.SelectCommand = cmd
        tabel.Clear()
        da.Fill(tabel)

        With DGV
            .DataSource = tabel
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False

            .Columns(0).Width = 90
            .Columns(1).Width = 100
            .Columns(2).Width = 150
            .Columns(3).Width = 150

            .Columns(0).HeaderText = "Kode"
            .Columns(1).HeaderText = "Nama"
            .Columns(2).HeaderText = "Jenis Kelamin"
            .Columns(3).HeaderText = "Tanggal Lahir"

            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

            .AlternatingRowsDefaultCellStyle.BackColor = Color.Silver
        End With
        cn.Close()

        txt_kode.Clear()
        txt_nama.Clear()
        cmb_jk.Text = ""
        dtp_tgl_lahir.Value = Now
        txt_kode.Focus()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksinya()
        DesainDGV()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQL As String
        Try
            If Len(txt_kode.Text) = 0 Then
                MsgBox("Kode Masih Kosong !")
                txt_kode.Focus()
            ElseIf Len(cmb_jk.Text) = 0 Then
                MsgBox("Combo Jenis Kelamin Masih Kosong !")
                cmb_jk.Focus()
            Else
                SQL = "INSERT INTO tb_coba(kode,nama,jenis_kelamin,tgl_lahir) "
                SQL += "VALUES('" & Trim(txt_kode.Text) & "','" & Trim(txt_nama.Text) & "',"
                SQL += "'" & Trim(cmb_jk.Text) & "','" & dtp_tgl_lahir.Text & "');"

                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
                cn.Close()
                DesainDGV()
            End If
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
            cn.Close()
        End Try
    End Sub

    Private Sub DGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) _
        Handles DGV.CellMouseClick
        txt_kode.Text = DGV.CurrentRow.Cells(0).Value
        txt_nama.Text = DGV.CurrentRow.Cells(1).Value
        cmb_jk.Text = DGV.CurrentRow.Cells(2).Value
        dtp_tgl_lahir.Text = DGV.CurrentRow.Cells(3).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SQL As String
        Try
            If Len(txt_kode.Text) = 0 Then
                MsgBox("Kode Masih Kosong !")
                txt_kode.Focus()
            ElseIf Len(cmb_jk.Text) = 0 Then
                MsgBox("Combo Jenis Kelamin Masih Kosong !")
                cmb_jk.Focus()
            Else
                SQL = "UPDATE tb_coba SET "
                SQL += "nama='" & Trim(txt_nama.Text) & "',"
                SQL += "jenis_kelamin='" & Trim(cmb_jk.Text) & "',"
                SQL += "tgl_lahir='" & dtp_tgl_lahir.Text & "';"

                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
                cn.Close()
                DesainDGV()
            End If
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SQL As String
        Try
            If Len(txt_kode.Text) = 0 Then
                MsgBox("Kode Masih Kosong !")
                txt_kode.Focus()
            ElseIf Len(cmb_jk.Text) = 0 Then
                MsgBox("Combo Jenis Kelamin Masih Kosong !")
                cmb_jk.Focus()
            Else
                If MsgBox("Yakin Hapus Data ini ?", MsgBoxStyle.YesNo, "Konfirmasi") _
                    = MsgBoxResult.Yes Then
                    SQL = "DELETE FROM tb_coba WHERE kode =  '" & Trim(txt_kode.Text) & "'"
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText = SQL
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If
                DesainDGV()
            End If
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
            cn.Close()
        End Try
    End Sub
End Class