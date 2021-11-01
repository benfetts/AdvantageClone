Public Class AdvantageSecuritySetupForm

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
        _HasToLogIn = False

    End Sub
    Private Shadows Function LoadStartUpInformation(ByRef CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

        'objects
        Dim ServerName As String = ""
        Dim DatabaseName As String = ""
        Dim UseWindowsAuthentication As Boolean = False
        Dim UserName As String = ""
        Dim Password As String = ""
        Dim ErrorMessage As String = ""
        Dim IsLoggedIn As Boolean = False
        Dim ConnectionString As String = ""

        For Each CommandLine In CommandLineArgs

            If CommandLine.StartsWith("-s") Then

                ServerName = CommandLine.Replace("-s", "")

            ElseIf CommandLine.StartsWith("-d") Then

                DatabaseName = CommandLine.Replace("-d", "")

            ElseIf CommandLine.StartsWith("-n") Then

                UseWindowsAuthentication = True

            ElseIf CommandLine.StartsWith("-u") Then

                UserName = CommandLine.Replace("-u", "")

            ElseIf CommandLine.StartsWith("-p") Then

                Password = CommandLine.Replace("-p", "")

            ElseIf CommandLine.StartsWith("-r") Then

                _IsFromPowerBuilderMenu = True

            ElseIf CommandLine.StartsWith("-x") Then

                If CommandLine = "-xADVAN" Then

                    _InternalOnlyMode = True

                End If

            End If

        Next

        If UseWindowsAuthentication Then

            UserName = My.User.Name

        End If

        If DatabaseName = "" Then

            IsLoggedIn = False

        Else

            If LoginDialog.Login(_Application, Nothing, _Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, ErrorMessage) Then

                IsLoggedIn = True

            End If

        End If

        If IsLoggedIn = False Then

            If LoginDialog.ShowFormDialog(_Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName) = AdvantageFramework.WinForm.MessageBox.DialogResults.OK Then

                IsLoggedIn = True

            Else

                System.Windows.Forms.Application.Exit()

            End If

        End If

        LoadStartUpInformation = IsLoggedIn

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageSecuritySetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        LoadStartUpInformation(My.Application.CommandLineArgs)

    End Sub
    Private Sub AdvantageSecuritySetupForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        AdvantageFramework.Security.Presentation.AdvantageInternalSecuritySetupForm.ShowForm()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class