Namespace Security.Classes

    <Serializable()>
    Public Class ClientPortalUser

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserName
            LoweredUserName
            FullName
            Password
            LastLoginDate
            CreatedByUserCode
            CreatedDate
            IsLocked
            EmailAddress
            LoginsAttempted
            UnlockedDate
            MustChangePassword
            Theme
            ClientContactID
            DesktopTemplate
            WebID
            IsAdminUser
            ClientCode
            AlertGroupCode
            AgencyContactEmployeeCode
            TimeZoneID
            ConceptShareUserID
            ConceptSharePassword
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID() As Guid
        Public Property UserName() As String
        Public Property LoweredUserName() As String
        Public Property FullName() As String
        Public Property Password() As String
        Public Property LastLoginDate() As Nullable(Of Date)
        Public Property CreatedByUserCode() As String
        Public Property CreatedDate() As Nullable(Of Date)
        Public Property IsLocked() As Nullable(Of Boolean)
        Public Property EmailAddress() As String
        Public Property LoginsAttempted() As Short
        Public Property UnlockedDate() As Nullable(Of Date)
        Public Property MustChangePassword() As Boolean
        Public Property Theme() As String
        Public Property ClientContactID() As Integer
        Public Property DesktopTemplate() As Nullable(Of Integer)
        Public Property WebID() As String
        Public Property IsAdminUser() As Boolean
        Public Property ClientCode() As String
        Public Property AlertGroupCode() As String
        Public Property AgencyContactEmployeeCode() As String
        Public Property TimeZoneID() As String
        Public Property ConceptShareUserID() As Nullable(Of Integer)
        Public Property ConceptSharePassword() As String

#End Region

#Region " Methods "

        Public Sub New(ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser)

            Me.ID = ClientPortalUser.ID
            Me.UserName = ClientPortalUser.UserName
            Me.LoweredUserName = ClientPortalUser.LoweredUserName
            Me.FullName = ClientPortalUser.FullName
            Me.Password = ClientPortalUser.Password
            Me.LastLoginDate = ClientPortalUser.LastLoginDate
            Me.CreatedByUserCode = ClientPortalUser.CreatedByUserCode
            Me.CreatedDate = ClientPortalUser.CreatedDate
            Me.IsLocked = ClientPortalUser.IsLocked
            Me.EmailAddress = ClientPortalUser.EmailAddress
            Me.LoginsAttempted = ClientPortalUser.LoginsAttempted
            Me.UnlockedDate = ClientPortalUser.UnlockedDate
            Me.MustChangePassword = ClientPortalUser.MustChangePassword
            Me.Theme = ClientPortalUser.Theme
            Me.ClientContactID = ClientPortalUser.ClientContactID
            Me.DesktopTemplate = ClientPortalUser.DesktopTemplate
            Me.WebID = ClientPortalUser.WebID
            Me.IsAdminUser = ClientPortalUser.IsAdminUser
            Me.ClientCode = ClientPortalUser.ClientCode
            Me.AlertGroupCode = ClientPortalUser.AlertGroupCode
            Me.AgencyContactEmployeeCode = ClientPortalUser.AgencyContactEmployeeCode
            Me.TimeZoneID = ClientPortalUser.TimeZoneID
            Me.ConceptShareUserID = ClientPortalUser.ConceptShareUserID
            Me.ConceptSharePassword = ClientPortalUser.ConceptSharePassword

        End Sub

#End Region

    End Class

End Namespace