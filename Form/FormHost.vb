Public Class FormHost
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
        Server.Edit = False
        Server.Form = New FormServer()
        Server.Form.textBoxAddress.Text = "127.0.0.1"
        Server.Form.textBoxName.Text = "localhost"
        Server.Form.textBoxComment.Text = "default"
        Server.Form.Show()
        Me.Enabled = False
    End Sub

    Private Sub FormHost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.listViewHost.Items.Clear()
        Me.buttonEdit.Enabled = False
        Me.buttonDelete.Enabled = False
    End Sub

    Private Sub ListViewHost_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewHost.SelectedIndexChanged
        If Me.listViewHost.SelectedItems.Count Then
            Me.buttonEdit.Enabled = True
            Me.buttonDelete.Enabled = True
        Else
            Me.buttonEdit.Enabled = False
            Me.buttonDelete.Enabled = False
        End If
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        Me.listViewHost.Items.Remove(Me.listViewHost.SelectedItems.Item(0))
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles buttonEdit.Click
        Server.Edit = True
        Server.Form = New FormServer()
        Server.Form.textBoxAddress.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).Text
        Server.Form.textBoxName.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).SubItems(1).Text
        Server.Form.textBoxComment.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).SubItems(2).Text
        Server.Form.Show()
        Me.Enabled = False
    End Sub
End Class