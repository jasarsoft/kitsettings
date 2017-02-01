<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HostForm
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
        Me.labelHost = New System.Windows.Forms.Label()
        Me.buttonAdd = New System.Windows.Forms.Button()
        Me.buttonEdit = New System.Windows.Forms.Button()
        Me.buttonDelete = New System.Windows.Forms.Button()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.listViewHost = New System.Windows.Forms.ListView()
        Me.ColumnAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnComment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'labelHost
        '
        Me.labelHost.Location = New System.Drawing.Point(12, 22)
        Me.labelHost.Name = "labelHost"
        Me.labelHost.Size = New System.Drawing.Size(476, 20)
        Me.labelHost.TabIndex = 2
        Me.labelHost.Text = "Active servers use only selected."
        Me.labelHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonAdd
        '
        Me.buttonAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonAdd.Location = New System.Drawing.Point(12, 209)
        Me.buttonAdd.Name = "buttonAdd"
        Me.buttonAdd.Size = New System.Drawing.Size(80, 40)
        Me.buttonAdd.TabIndex = 28
        Me.buttonAdd.Text = "Add"
        Me.buttonAdd.UseVisualStyleBackColor = True
        '
        'buttonEdit
        '
        Me.buttonEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonEdit.Location = New System.Drawing.Point(98, 209)
        Me.buttonEdit.Name = "buttonEdit"
        Me.buttonEdit.Size = New System.Drawing.Size(80, 40)
        Me.buttonEdit.TabIndex = 29
        Me.buttonEdit.Text = "Edit"
        Me.buttonEdit.UseVisualStyleBackColor = True
        '
        'buttonDelete
        '
        Me.buttonDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonDelete.Location = New System.Drawing.Point(184, 209)
        Me.buttonDelete.Name = "buttonDelete"
        Me.buttonDelete.Size = New System.Drawing.Size(80, 40)
        Me.buttonDelete.TabIndex = 30
        Me.buttonDelete.Text = "Delete"
        Me.buttonDelete.UseVisualStyleBackColor = True
        '
        'buttonSave
        '
        Me.buttonSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(270, 209)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(218, 40)
        Me.buttonSave.TabIndex = 31
        Me.buttonSave.Text = "SAVE HOST"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'listViewHost
        '
        Me.listViewHost.CheckBoxes = True
        Me.listViewHost.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnAddress, Me.ColumnName, Me.ColumnComment})
        Me.listViewHost.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listViewHost.Location = New System.Drawing.Point(12, 45)
        Me.listViewHost.Name = "listViewHost"
        Me.listViewHost.ShowGroups = False
        Me.listViewHost.Size = New System.Drawing.Size(476, 158)
        Me.listViewHost.TabIndex = 32
        Me.listViewHost.UseCompatibleStateImageBehavior = False
        Me.listViewHost.View = System.Windows.Forms.View.Details
        '
        'ColumnAddress
        '
        Me.ColumnAddress.Text = "IP Address"
        Me.ColumnAddress.Width = 110
        '
        'ColumnName
        '
        Me.ColumnName.Text = "Name"
        Me.ColumnName.Width = 190
        '
        'ColumnComment
        '
        Me.ColumnComment.Text = "Comment"
        Me.ColumnComment.Width = 170
        '
        'Host
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 261)
        Me.Controls.Add(Me.listViewHost)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.buttonDelete)
        Me.Controls.Add(Me.buttonEdit)
        Me.Controls.Add(Me.buttonAdd)
        Me.Controls.Add(Me.labelHost)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Host"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kitserver 6 Settings | Host"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labelHost As System.Windows.Forms.Label
    Friend WithEvents buttonAdd As System.Windows.Forms.Button
    Friend WithEvents buttonEdit As System.Windows.Forms.Button
    Friend WithEvents buttonDelete As System.Windows.Forms.Button
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents listViewHost As System.Windows.Forms.ListView
    Friend WithEvents ColumnAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnComment As System.Windows.Forms.ColumnHeader
End Class