Namespace Forms
    Public Class Server

        Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
            If Modules.Server.Edit Then
                Modules.Host.Form.listViewHost.Items.Item(Modules.Host.Form.listViewHost.Items.IndexOf(Modules.Host.Form.listViewHost.SelectedItems.Item(0))).Text = Modules.Server.Form.textBoxAddress.Text
                Modules.Host.Form.listViewHost.Items.Item(Modules.Host.Form.listViewHost.Items.IndexOf(Modules.Host.Form.listViewHost.SelectedItems.Item(0))).SubItems(1).Text = Modules.Server.Form.textBoxName.Text
                Modules.Host.Form.listViewHost.Items.Item(Modules.Host.Form.listViewHost.Items.IndexOf(Modules.Host.Form.listViewHost.SelectedItems.Item(0))).SubItems(2).Text = Modules.Server.Form.textBoxComment.Text
            Else
                Dim item As New ListViewItem()
                item.Checked = True
                item.Text = Modules.Server.Form.textBoxAddress.Text
                item.SubItems.Add(Modules.Server.Form.textBoxName.Text)
                item.SubItems.Add(Modules.Server.Form.textBoxComment.Text)
                Modules.Host.Form.listViewHost.Items.Add(item)
            End If
            Me.Close()
            Modules.Host.Form.Enabled = True
            Modules.Host.Form.listViewHost.Focus()
        End Sub

        Private Sub Server_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            Modules.Host.Form.Enabled = True
        End Sub
    End Class
End Namespace
