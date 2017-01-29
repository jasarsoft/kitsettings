Public Class FormServer

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        If Server.Edit Then
            Host.Form.listViewHost.Items.Item(Host.Form.listViewHost.Items.IndexOf(Host.Form.listViewHost.SelectedItems.Item(0))).Text = Server.Form.textBoxAddress.Text
            Host.Form.listViewHost.Items.Item(Host.Form.listViewHost.Items.IndexOf(Host.Form.listViewHost.SelectedItems.Item(0))).SubItems(1).Text = Server.Form.textBoxName.Text
            Host.Form.listViewHost.Items.Item(Host.Form.listViewHost.Items.IndexOf(Host.Form.listViewHost.SelectedItems.Item(0))).SubItems(2).Text = Server.Form.textBoxComment.Text
        Else
            Dim item As New ListViewItem()
            item.Checked = True
            item.Text = Server.Form.textBoxAddress.Text
            item.SubItems.Add(Server.Form.textBoxName.Text)
            item.SubItems.Add(Server.Form.textBoxComment.Text)
            Host.Form.listViewHost.Items.Add(item)
        End If
        Me.Close()
        Host.Form.Enabled = True
        Host.Form.listViewHost.Focus()
    End Sub

End Class