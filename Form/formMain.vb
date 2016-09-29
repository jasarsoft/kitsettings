Public Class formMain

    Dim cameraZoomer As CameraZoomer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cameraZoomer = New CameraZoomer()
    End Sub




    Private Sub buttonPlay_Click(sender As Object, e As EventArgs) Handles buttonPlay.Click

#Const TEST_EXIST = True
#Const TEST_DELETE = True
#Const TEST_CREATE = True
#Const TEST_VALUE = True
#Const TEST_WRITE = True
#Const TEST_READ = True
#Const TEST_SHOW = True


#If TEST_EXIST Then
        If cameraZoomer.ExistFile() Then
            MessageBox.Show("The file exist!", "Test")
        Else
            MessageBox.Show("The file does not exist!", "Test")
        End If
#ElseIf TEST_DELETE Then
        If cameraZoomer.DeleteFile() Then
            MessageBox.Show("The file has been deleted!", "Test")
        Else
            MessageBox.Show("The file is not deleted!", "Test")
        End If
#ElseIf TEST_CREATE Then
        If cameraZoomer.CreateFile Then
            MessageBox.Show("The file is created!", "Test")
        Else
            MessageBox.Show("The file is not created!", "Test")
        End If
#ElseIf TEST_VALUE Then
        cameraZoomer.CameraZoom = 1000
        cameraZoomer.StadiumRoof = False
        cameraZoomer.StadiumClipping = False
#ElseIf TEST_WRITE Then
        If cameraZoomer.WriteFile() Then
            MessageBox.Show("The file is written!", "Test")
        Else
            MessageBox.Show("The file is not written!", "Test")
        End If
#ElseIf TEST_READ Then
        If cameraZoomer.ReadFile() Then
            MessageBox.Show("The file is read!", "Test")
        Else
            MessageBox.Show("The file is not read!", "Test")
        End If
#ElseIf TEST_SHOW Then
        MessageBox.Show(cameraZoomer.CameraZoom.ToString())
        MessageBox.Show(cameraZoomer.StadiumRoof.ToString())
        MessageBox.Show(cameraZoomer.StadiumClipping.ToString())
#End If

    End Sub
End Class
