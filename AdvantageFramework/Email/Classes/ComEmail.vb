Namespace Email.Classes

	<System.Runtime.InteropServices.ComVisible(True),
	System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None),
	System.Runtime.InteropServices.ProgId("AdvantageFramework.Email.Classes.ComEmail"),
	System.Runtime.InteropServices.Guid("375C17DF-3920-4083-8018-3512DC8DB609")>
	Public Class ComEmail
		Implements Interfaces.IComEmail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _AttachmentList As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "

		Public ReadOnly Property Attachments As String() Implements Interfaces.IComEmail.Attachments
			Get
				Return _AttachmentList.ToArray
			End Get
		End Property
		Public Property Bcc As String Implements Interfaces.IComEmail.Bcc
		Public Property Body As String Implements Interfaces.IComEmail.Body
		Public Property Cc As String Implements Interfaces.IComEmail.Cc
		Public Property DatabaseName As String Implements Interfaces.IComEmail.DatabaseName
		Public Property ErrorMessage As String Implements Interfaces.IComEmail.ErrorMessage
		Public Property Password As String Implements Interfaces.IComEmail.Password
		Public Property Priority As Integer Implements Interfaces.IComEmail.Priority
		Public Property SendingEmailStatus As Integer Implements Interfaces.IComEmail.SendingEmailStatus
		Public Property ServerName As String Implements Interfaces.IComEmail.ServerName
		Public Property Subject As String Implements Interfaces.IComEmail.Subject
		Public Property [To] As String Implements Interfaces.IComEmail.To
		Public Property UserName As String Implements Interfaces.IComEmail.UserName
		Public Property UseWindowsAuthentication As Boolean Implements Interfaces.IComEmail.UseWindowsAuthentication

#End Region

#Region " Methods "

		Public Function Send() As Boolean Implements Interfaces.IComEmail.Send

			'objects
			Dim EmailSent As Boolean = False
			Dim ConnectionString As String = ""

			Me.ErrorMessage = ""

			Try

				If AdvantageFramework.Database.ValidateServerAndDatabase(Me.ServerName, Me.DatabaseName, Me.UseWindowsAuthentication, Me.UserName, Me.Password, AdvantageFramework.Security.Application.Advantage.ToString, True, Me.ErrorMessage) Then

					ConnectionString = AdvantageFramework.Database.CreateConnectionString(Me.ServerName, Me.DatabaseName, Me.UseWindowsAuthentication, Me.UserName, Me.Password, AdvantageFramework.Security.Application.Advantage.ToString)

					If AdvantageFramework.Database.TestConnectionString(ConnectionString, Me.ErrorMessage) Then

						If Me.UseWindowsAuthentication Then

							If Me.UserName.Contains("\") Then

								Me.UserName = Me.UserName.Substring(Me.UserName.IndexOf("\") + 1)

							End If

						End If

						Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, Me.UserName)

							EmailSent = AdvantageFramework.Email.Send(DbContext, Me.[To], Me.Cc, Me.Bcc, Me.Subject, Me.Body, Me.Priority, Me.Attachments.ToArray, Me.SendingEmailStatus, Me.ErrorMessage)

						End Using

					End If

				End If

			Catch ex As Exception
				EmailSent = False
			End Try

			If Not EmailSent Then

				If String.IsNullOrWhiteSpace(Me.ErrorMessage) Then

					Me.ErrorMessage = "There was a problem sending the email."

				End If

			End If

			Return EmailSent

		End Function
		Public Sub AddAttachment(ByVal FileName As String) Implements Interfaces.IComEmail.AddAttachment

			Try

				If _AttachmentList IsNot Nothing Then

					_AttachmentList = New List(Of String)

				End If

				_AttachmentList.Add(FileName)

			Catch ex As Exception

			End Try

		End Sub
		Public Sub New()

			MyBase.New()

			_AttachmentList = New List(Of String)
			Me.Priority = 0 ' MailBee.Mime.MailPriority.None

		End Sub

#End Region

	End Class


End Namespace


