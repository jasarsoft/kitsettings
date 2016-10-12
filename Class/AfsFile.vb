Public Class AfsFile

    Private Structure FileName
        'Text File
        Public Const AFS_0_TEXT As String = "0_text.afs"
        Public Const AFS_E_TEXT As String = "e_text.afs" 'English
        Public Const AFS_F_TEXT As String = "f_text.afs" 'French
        Public Const AFS_G_TEXT As String = "g_text.afs" 'German
        Public Const AFS_I_TEXT As String = "i_text.afs" 'Italian
        Public Const AFS_P_TEXT As String = "p_text.afs" 'Polish
        Public Const AFS_S_TEXT As String = "s_text.afs" 'Spanish
        ' Sound File
        Public Const AFS_0_SOUND As String = "0_sound.afs"
        Public Const AFS_E_SOUND As String = "e_sound.afs" 'English
        Public Const AFS_F_SOUND As String = "f_sound.afs" 'French
        Public Const AFS_G_SOUND As String = "g_sound.afs" 'German
        Public Const AFS_I_SOUND As String = "i_sound.afs" 'Italian
        Public Const AFS_P_SOUND As String = "p_sound.afs" 'Polish
        Public Const AFS_S_SOUND As String = "s_sound.afs" 'Spanish
    End Structure

    Protected ReadOnly Property Afs0sound As String
        Get
            Return FileName.AFS_0_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsEsound As String
        Get
            Return FileName.AFS_E_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsFsound As String
        Get
            Return FileName.AFS_F_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsGsound As String
        Get
            Return FileName.AFS_G_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsIsound As String
        Get
            Return FileName.AFS_G_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsPsound As String
        Get
            Return FileName.AFS_P_SOUND
        End Get
    End Property

    Protected ReadOnly Property AfsSsound As String
        Get
            Return FileName.AFS_S_SOUND
        End Get
    End Property

    Protected ReadOnly Property Afs0text As String
        Get
            Return FileName.AFS_0_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsEtext As String
        Get
            Return FileName.AFS_E_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsFtext As String
        Get
            Return FileName.AFS_F_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsGtext As String
        Get
            Return FileName.AFS_G_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsItext As String
        Get
            Return FileName.AFS_I_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsPtext As String
        Get
            Return FileName.AFS_P_TEXT
        End Get
    End Property

    Protected ReadOnly Property AfsStext As String
        Get
            Return FileName.AFS_S_TEXT
        End Get
    End Property

End Class
