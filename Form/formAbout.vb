Public NotInheritable Class FormAbout

    ''' <summary>Private Application About Variable</summary>
    Private appAbout As About

    ''' <summary>
    ''' Default Form Constructor
    ''' </summary>
    ''' <remarks>The constructor must contain a procedure InitializeComponent()</remarks>
    Public Sub New()
        ' Initialization Form Componenets
        Call InitializeComponent()

        ' Initialization About Class
        appAbout = New About()
    End Sub

    ''' <summary>
    ''' Main Form Load Procedure
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting information about the application
        Me.labelNameData.Text = appAbout.Title
        Me.labelVersionData.Text = appAbout.Version
        Me.labelDeveloperData.Text = appAbout.Developer
        Me.labelLicenseData.Text = appAbout.License
        Me.labelWebsiteData.Text = appAbout.Website
        Me.labelDescriptionData.Text = appAbout.Description
    End Sub

    ''' <summary>
    ''' Button 'Close' Click Procedure
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles buttonClose.Click
        'Close About form
        Call Me.Close()
        'Me.Dispose()
    End Sub
End Class