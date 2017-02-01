Public Class ServerForm

    Public Sub New()
        ' Designer components
        InitializeComponent()
    End Sub


    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        'Me.DialogResult = Windows.Forms.DialogResult.OK 'setting in design mode
        Me.Close()
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        'Me.DialogResult = Windows.Forms.DialogResult.Cancel 'setting in design mode
        Me.Close()
    End Sub
End Class