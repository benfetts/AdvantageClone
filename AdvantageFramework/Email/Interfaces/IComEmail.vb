Namespace Email.Interfaces

	<System.Runtime.InteropServices.ComVisible(True),
	System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsDual),
	System.Runtime.InteropServices.Guid("DF1F9719-DAA8-40D3-B56C-DDEB022A9CDE")>
	Public Interface IComEmail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<System.Runtime.InteropServices.ComVisible(True)>
		Property ServerName As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property DatabaseName As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property UseWindowsAuthentication As Boolean
		<System.Runtime.InteropServices.ComVisible(True)>
		Property UserName As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Password As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property [To] As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Cc As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Bcc As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Subject As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Body As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property Priority As Integer
		<System.Runtime.InteropServices.ComVisible(True)>
		ReadOnly Property Attachments As String()
		<System.Runtime.InteropServices.ComVisible(True)>
		Property ErrorMessage As String
		<System.Runtime.InteropServices.ComVisible(True)>
		Property SendingEmailStatus As Integer

#End Region

#Region " Methods "

		Function Send() As Boolean
		Sub AddAttachment(ByVal FileName As String)

#End Region

	End Interface

End Namespace

