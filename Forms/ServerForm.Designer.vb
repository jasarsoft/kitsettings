<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textBoxAddress = New System.Windows.Forms.TextBox()
        Me.labelAddress = New System.Windows.Forms.Label()
        Me.labelName = New System.Windows.Forms.Label()
        Me.textBoxName = New System.Windows.Forms.TextBox()
        Me.textBoxComment = New System.Windows.Forms.TextBox()
        Me.labelComment = New System.Windows.Forms.Label()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textBoxAddress
        '
        Me.textBoxAddress.Location = New System.Drawing.Point(128, 22)
        Me.textBoxAddress.Name = "textBoxAddress"
        Me.textBoxAddress.Size = New System.Drawing.Size(220, 22)
        Me.textBoxAddress.TabIndex = 0
        '
        'labelAddress
        '
        Me.labelAddress.Location = New System.Drawing.Point(12, 22)
        Me.labelAddress.Name = "labelAddress"
        Me.labelAddress.Size = New System.Drawing.Size(110, 22)
        Me.labelAddress.TabIndex = 3
        Me.labelAddress.Text = "IP Address:"
        Me.labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelName
        '
        Me.labelName.Location = New System.Drawing.Point(12, 50)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(110, 22)
        Me.labelName.TabIndex = 4
        Me.labelName.Text = "Server Name:"
        Me.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textBoxName
        '
        Me.textBoxName.Location = New System.Drawing.Point(128, 50)
        Me.textBoxName.Name = "textBoxName"
        Me.textBoxName.Size = New System.Drawing.Size(220, 22)
        Me.textBoxName.TabIndex = 5
        '
        'textBoxComment
        '
        Me.textBoxComment.Location = New System.Drawing.Point(128, 78)
        Me.textBoxComment.Name = "textBoxComment"
        Me.textBoxComment.Size = New System.Drawing.Size(220, 22)
        Me.textBoxComment.TabIndex = 6
        '
        'labelComment
        '
        Me.labelComment.Location = New System.Drawing.Point(12, 78)
        Me.labelComment.Name = "labelComment"
        Me.labelComment.Size = New System.Drawing.Size(110, 22)
        Me.labelComment.TabIndex = 7
        Me.labelComment.Text = "Optional Comment:"
        Me.labelComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonSave
        '
        Me.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buttonSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(12, 115)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(250, 40)
        Me.buttonSave.TabIndex = 29
        Me.buttonSave.Text = " SERVER"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ButtonClose.Location = New System.Drawing.Point(268, 115)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(80, 40)
        Me.ButtonClose.TabIndex = 30
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ServerForm
        '
        Me.AcceptButton = Me.buttonSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonClose
        Me.ClientSize = New System.Drawing.Size(360, 167)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.labelComment)
        Me.Controls.Add(Me.textBoxComment)
        Me.Controls.Add(Me.textBoxName)
        Me.Controls.Add(Me.labelName)
        Me.Controls.Add(Me.labelAddress)
        Me.Controls.Add(Me.textBoxAddress)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServerForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kitserver 6 Settings | Server"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textBoxAddress As System.Windows.Forms.TextBox
    Friend WithEvents labelAddress As System.Windows.Forms.Label
    Friend WithEvents labelName As System.Windows.Forms.Label
    Friend WithEvents textBoxName As System.Windows.Forms.TextBox
    Friend WithEvents textBoxComment As System.Windows.Forms.TextBox
    Friend WithEvents labelComment As System.Windows.Forms.Label
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
End Class