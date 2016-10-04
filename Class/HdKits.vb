Public NotInheritable Class HdKits
    Inherits ConfigurationFile

    Private _hdKits As Boolean

    Private Structure Info
        Public Const fileName As String = "kserv"
        Public Const titleName As String = "Kitserver"
    End Structure

    Private Structure Parameter
        Public Const hdKits As String = "HD-kits.enabled"
    End Structure

    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property

    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property

    Public Property HdKits
        Get
            Return _hdKits
        End Get
        Set(value)
            _hdKits = value
        End Set
    End Property

    Public Sub New()
        DefaultValue()
    End Sub

    Private Sub DefaultValue()
        _hdKits = True
    End Sub

    Private Function GenerateData() As String
        Dim dataText As String

        dataText = Parameter.hdKits & " = " & MyBase.ConvertEnable(_hdKits) & Environment.NewLine & Environment.NewLine
        dataText += "# mini-kits model map." & Environment.NewLine
        dataText += "# Needed only for correct display of mini-kits, but doesn't affect the in-game kits." & Environment.NewLine
        dataText += "# Note: the map might be incomplete, so feel free to add the model numbers to correct groups, if you notice that a mini-kit for certain model is rendered incorrectly." & Environment.NewLine & Environment.NewLine
        dataText += "mini-kits.narrow-backs = [8]" & Environment.NewLine
        dataText += "mini-kits.wide-backs = [0,1,2,3,4,9,10,11,12,13,14,15,17,24,26,34,36,37,38,39,44,51,55,57,59,60,62,64,77,78,80,86,87,88,93,94,100,101,102,103,104,105,106,107,114]" & Environment.NewLine
        dataText += "mini-kits.squashed-with-logo = [18,19,20,21,49,54,61,68,69,70,74,91,115,116,117,118,124,125,126,127,128,129,132,134,137,138,139,140,146,147,148]" & Environment.NewLine & Environment.NewLine
        dataText += "# any other other model is assumed to be 'squashed-without-logo' (meaning the new PES6 model with squashed shirt, but no logo in the bottom-right area of the texture.)" & Environment.NewLine
        dataText += "# Some examples: 31,71,84,etc."

        Return dataText
    End Function

    Public Overloads Function ExistFile() As Boolean

        If MyBase.ExistFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function DeleteFile() As Boolean

        If MyBase.DeleteFile(FileName, TitleName) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function CreateFile() As Boolean

        If MyBase.CreateFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function WriteFile() As Boolean

        If MyBase.WriteFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID11 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return False
    End Function

    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        readValue = ReadFile(FileName, Parameter.hdKits)

        If IsNumeric(readValue) Then
            _hdKits = ConvertValue(readValue)
            Return True
        Else
            Dim tmpText As String
            Dim msgResult As DialogResult
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID10 & Environment.NewLine & msgText.ID01

            msgResult = MessageBox.Show(tmpText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msgResult = DialogResult.Yes Then
                If CreateFile() Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function

End Class
