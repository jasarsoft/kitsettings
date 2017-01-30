Namespace Forms
    Public Class Host
        Dim host As Classes.Host

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            host = New Classes.Host()
        End Sub

        Private Sub FormHost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.listViewHost.Items.Clear()
            Me.buttonEdit.Enabled = False
            Me.buttonDelete.Enabled = False

            If host.Valid() Then
                host.Read()
                For Each server As String In host.Servers
                    Dim temp As String
                    Dim item As New ListViewItem()

                    'Delete whitespace if exist [Special Case]
                    Call RemoveWhitespace(server)
                    If server.StartsWith("#") Then
                        item.Checked = False
                        server = server.Remove(0, 1)
                    Else
                        item.Checked = True
                    End If

                    Call RemoveWhitespace(server)
                    'Address
                    item.Text = server.Remove(server.IndexOf(" "))
                    'Name
                    temp = server.Remove(0, server.IndexOf(" ") + 1)
                    temp = temp.Remove(temp.IndexOf("#") - 1)
                    item.SubItems.Add(temp)
                    'Comment
                    item.SubItems.Add(server.Remove(0, server.IndexOf("#") + 1))

                    Me.listViewHost.Items.Add(item)
                Next
            End If

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
            Dim address As String
            Dim name As String
            Dim comment As String

            host.Servers.Clear()
            For index = 0 To Me.listViewHost.Items.Count - 1
                address = Me.listViewHost.Items.Item(index).Text
                name = Me.listViewHost.Items.Item(index).SubItems.Item(1).Text
                comment = Me.listViewHost.Items.Item(index).SubItems.Item(2).Text

                If Me.listViewHost.Items.Item(index).Checked Then
                    host.Servers.Add(address & " " & name & " #" & comment)
                Else
                    host.Servers.Add("#" & address & " " & name & " #" & comment)
                End If
            Next

            MessageBox.Show(host.Write().ToString())

        End Sub

        Private Sub Host_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            Me.listViewHost.Items.Clear()
        End Sub


        Private Sub RemoveWhitespace(ByRef text As String)
            While True
                If text.StartsWith(" ") Then
                    text = text.Remove(0, 1)
                Else
                    Exit While
                End If
            End While
        End Sub

    End Class
End Namespace
