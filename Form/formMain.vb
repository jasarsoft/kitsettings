Public Class formMain

    Dim cameraZoomer As CameraZoomer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cameraZoomer = New CameraZoomer()
    End Sub




    Private Sub buttonPlay_Click(sender As Object, e As EventArgs) Handles buttonPlay.Click

        cameraZoomer.ReadFile()
        MessageBox.Show(cameraZoomer.CameraZoomValue.ToString())
        MessageBox.Show(cameraZoomer.StadiumRoofEnable.ToString())
        MessageBox.Show(cameraZoomer.StadiumClippingEnable.ToString())

    End Sub
End Class
