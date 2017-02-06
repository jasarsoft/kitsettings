Public NotInheritable Class AboutForm

    ''' <summary>Private Application About Variable</summary>
    Private about As About

    ''' <summary>
    ''' Default Form Constructor
    ''' </summary>
    ''' <remarks>The constructor must contain a procedure InitializeComponent()</remarks>
    Public Sub New()
        ' Initialization Form Componenets
        Call InitializeComponent()

        ' Initialization About Class
        about = New About()
    End Sub

    ''' <summary>
    ''' Main Form Load Procedure
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting information about the application
        Me.labelNameData.Text = about.Title
        Me.labelVersionData.Text = about.Version
        Me.labelDeveloperData.Text = about.Developer
        Me.labelLicenseData.Text = about.License
        Me.labelWebsiteData.Text = about.Website
        Me.labelDescriptionData.Text = about.Description
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

    Private Sub LabelWebsiteData_Click(sender As Object, e As EventArgs) Handles labelWebsiteData.Click
        Process.Start(about.Website)
    End Sub
End Class