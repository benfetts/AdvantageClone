Public Class AdvantageLicenseKeyImportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Advantage_Database_Update

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageLicenseKeyImport_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub AdvantageLicenseKeyImport_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        AdvantageFramework.Security.Presentation.LicenseKeyImportForm.ShowForm()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
