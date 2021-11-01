Namespace Security.Classes

    <Serializable()>
    Public Class User

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserCode
			EmployeeCode
            UserName
            CheckForUserAccess
			TimeHWND
			MenuHWND
            WebID
            'IsAdvanAdmin
            'IsSecurityAdmin
            'IsSysAdmin
            'IsServerAdmin
            Password
            SID
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property UserCode() As String
		Public Property EmployeeCode() As String
        Public Property UserName() As String
        Public Property CheckForUserAccess() As Boolean
        Public Property TimeHWND() As Nullable(Of Integer)
        Public Property MenuHWND() As Nullable(Of Integer)
        Public Property WebID() As String
        'Public Property IsAdvanAdmin() As Boolean
        'Public Property IsSecurityAdmin() As Boolean
        'Public Property IsSysAdmin() As Boolean
        'Public Property IsServerAdmin() As Boolean
        Public Property Password() As String
        Public Property SID() As String
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New(User As AdvantageFramework.Security.Database.Entities.User)

            If User IsNot Nothing Then

                Me.ID = User.ID
                Me.UserCode = User.UserCode
                Me.EmployeeCode = User.EmployeeCode
                Me.UserName = User.UserName
                Me.CheckForUserAccess = User.CheckForUserAccess
				Me.TimeHWND = User.TimeHWND
				Me.MenuHWND = User.MenuHWND
				Me.WebID = User.WebID
                'Me.IsAdvanAdmin = User.IsAdvanAdmin
                'Me.IsSecurityAdmin = User.IsSecurityAdmin
                'Me.IsSysAdmin = User.IsSysAdmin
                'Me.IsServerAdmin = User.IsServerAdmin
                Me.Password = User.Password
                Me.SID = User.SID
                Me.IsInactive = User.IsInactive

            End If

		End Sub

#End Region

	End Class

End Namespace