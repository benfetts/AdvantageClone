Namespace WinForm.Presentation

	Public Class BrowserForm

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Types
			[Default]
			GoogleAuthorization
		End Enum

#End Region

#Region " Variables "

		Private _URL As String = ""
		Private _Type As Types = Types.Default
		Private _AuthorizationCode As String = ""

#End Region

#Region " Properties "

		Private ReadOnly Property AuthorizationCode As String
			Get
				AuthorizationCode = _AuthorizationCode
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(ByVal URL As String, ByVal Type As Types, ByVal AuthorizationCode As String)

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_URL = URL
			_Type = Type
			_AuthorizationCode = AuthorizationCode

		End Sub

#Region "  Show Form Methods "

		Public Shared Sub ShowForm(ByVal URL As String, Optional ByVal Type As Types = Types.Default, Optional ByVal AuthorizationCode As String = Nothing)

			'objects
			Dim BrowserForm As AdvantageFramework.WinForm.Presentation.BrowserForm = Nothing

			BrowserForm = New AdvantageFramework.WinForm.Presentation.BrowserForm(URL, Type, AuthorizationCode)

			BrowserForm.Show()

			AuthorizationCode = BrowserForm.AuthorizationCode

		End Sub
		Public Shared Function ShowFormDialog(ByVal URL As String, Optional ByVal Type As Types = Types.Default, Optional ByRef AuthorizationCode As String = Nothing) As System.Windows.Forms.DialogResult

			'objects
			Dim BrowserForm As AdvantageFramework.WinForm.Presentation.BrowserForm = Nothing

			BrowserForm = New AdvantageFramework.WinForm.Presentation.BrowserForm(URL, Type, AuthorizationCode)

			ShowFormDialog = BrowserForm.ShowDialog()

			AuthorizationCode = BrowserForm.AuthorizationCode

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub BrowserForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			Me.ShowUnsavedChangesOnFormClosing = False

			If AdvantageFramework.Registry.CheckHelpFileEmulation(True) Then

				AdvantageFramework.Registry.CheckHelpFileEmulation(False)

			End If

			WebBrowserForm_Browser.Navigate(_URL)

			Me.Text = "Advantage Browser"

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub WebBrowserForm_Browser_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles WebBrowserForm_Browser.DocumentComplete

			Select Case _Type

				Case Types.GoogleAuthorization

					DocumentComplete_GoogleAuthorization(e)

			End Select

		End Sub
		Private Sub WebBrowserForm_Browser_TitleChange(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent) Handles WebBrowserForm_Browser.TitleChange

			Me.Text = e.text

		End Sub

#Region " Google Authorization "

		Private Sub DocumentComplete_GoogleAuthorization(e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent)

			'objects
			Dim Response As String = Nothing
			Dim CloseDialog As Boolean = False

			If Me.Text <> "" Then

				Response = Me.Text

				If Response.Contains("Denied error") Then

					_AuthorizationCode = Nothing
					CloseDialog = True

				ElseIf Response.Contains("Success code") Then

					_AuthorizationCode = Response.Replace("Success code=", "")
					CloseDialog = True

				End If

				If CloseDialog Then

					If String.IsNullOrWhiteSpace(_AuthorizationCode) Then

						Me.DialogResult = Windows.Forms.DialogResult.Cancel

					Else

						Me.DialogResult = Windows.Forms.DialogResult.OK

					End If

					Me.Close()

				End If

			End If

		End Sub

#End Region

#End Region

#End Region

	End Class

End Namespace