Namespace Navigation

    <HideModuleName()> _
    Public Module Methods

        Public Event ShowMessageEvent(ByVal Message As String)
        Public Event ShowMessageBoxEvent(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        Public Event ShowLoginEvent(ByVal Application As AdvantageFramework.Security.Application, ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, ByVal UpperCaseDatabaseAndUserName As Boolean, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        Public Event ShowChangePasswordEvent(ByVal ConnectionString As String, ByVal UserName As String, ByRef Password As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        Public Event ShowChangePasswordWithMessageEvent(ByVal ConnectionString As String, ByVal UserName As String, ByRef Password As String, ByVal Message As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        Public Event ClearNotificationAlertEvent()
        Public Event ShowReportViewerEvent(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
		Public Event ShowErrorEvent(Exception As Exception, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Menus
            NavigationWindow = 1
            QuickAccessToolbar = 2
            BubbleBar = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub ClearNotificationAlert()

            RaiseEvent ClearNotificationAlertEvent()

        End Sub
        Public Sub ShowMessage(Message As String)

            RaiseEvent ShowMessageEvent(Message)

        End Sub
        Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons = AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK, Optional ByVal Title As String = "") As AdvantageFramework.WinForm.MessageBox.DialogResults

            'objects
            Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

            RaiseEvent ShowMessageBoxEvent(Message, MessageBoxButtons, Title, DialogResult)

            ShowMessageBox = DialogResult

        End Function
        Public Function ShowLogin(ByVal Application As AdvantageFramework.Security.Application, ByRef DbContext As AdvantageFramework.Database.DbContext, _
                                  ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String, _
                                  ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String, _
                                  ByVal UpperCaseDatabaseAndUserName As Boolean) As AdvantageFramework.WinForm.MessageBox.DialogResults

            'objects
            Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

            RaiseEvent ShowLoginEvent(Application, DbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName, DialogResult)

            ShowLogin = DialogResult

        End Function
        Public Function ShowChangePassword(ByVal ConnectionString As String, ByVal UserName As String, ByRef Password As String) As AdvantageFramework.WinForm.MessageBox.DialogResults

            'objects
            Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

            RaiseEvent ShowChangePasswordEvent(ConnectionString, UserName, Password, DialogResult)

            ShowChangePassword = DialogResult

        End Function
        Public Function ShowChangePasswordWithMessage(ByVal ConnectionString As String, ByVal UserName As String, ByRef Password As String, ByVal Message As String) As AdvantageFramework.WinForm.MessageBox.DialogResults

            'objects
            Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

            RaiseEvent ShowChangePasswordWithMessageEvent(ConnectionString, UserName, Password, Message, DialogResult)

            ShowChangePasswordWithMessage = DialogResult

        End Function
        Public Function ShowReportViewer(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As AdvantageFramework.WinForm.MessageBox.DialogResults

			'objects
			Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

			RaiseEvent ShowReportViewerEvent(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To], DialogResult)

			ShowReportViewer = DialogResult

		End Function
		Public Function ShowError(Exception As Exception) As AdvantageFramework.WinForm.MessageBox.DialogResults

			'objects
			Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = AdvantageFramework.WinForm.MessageBox.DialogResults.OK

			RaiseEvent ShowErrorEvent(Exception, DialogResult)

			ShowError = DialogResult

		End Function

#End Region

	End Module

End Namespace
