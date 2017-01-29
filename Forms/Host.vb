Namespace Forms
    Public Class Host

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

        Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
            Modules.Server.Edit = False
            Modules.Server.Form = New Forms.Server()
            Modules.Server.Form.textBoxAddress.Text = "127.0.0.1"
            Modules.Server.Form.textBoxName.Text = "localhost"
            Modules.Server.Form.textBoxComment.Text = "default"
            Modules.Server.Form.Show()
            Me.Enabled = False
        End Sub

        Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles buttonEdit.Click
            Modules.Server.Edit = True
            Modules.Server.Form = New Forms.Server()
            Modules.Server.Form.textBoxAddress.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).Text
            Modules.Server.Form.textBoxName.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).SubItems(1).Text
            Modules.Server.Form.textBoxComment.Text = Me.listViewHost.Items.Item(Me.listViewHost.Items.IndexOf(Me.listViewHost.SelectedItems.Item(0))).SubItems(2).Text
            Modules.Server.Form.Show()
            Me.Enabled = False
        End Sub

        Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
            Me.listViewHost.Items.Remove(Me.listViewHost.SelectedItems.Item(0))
        End Sub

        Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click

        End Sub
    End Class
End Namespace
