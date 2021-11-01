Namespace Security.Classes

    <Serializable()>
    Public Class UserWithLicenseKeyInfo

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            UserName
            IsInactive
            EmployeeCode
            EmployeeName
            IsPowerUser
            IsWVOnlyUser
            IsMediaToolUser
            MediaToolUserSetting
            IsEmployeeTerminated
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
        End Enum

#End Region

#Region " Variables "

        Private _MediaToolUserCheck As Boolean = False
        Private _IsMediaToolUser As Boolean = False

#End Region

#Region " Properties "

        Public Property ID() As Integer
        Public Property UserCode() As String
        Public Property UserName() As String
        Public Property Inactive() As Boolean
        Public Property EmployeeCode() As String
        Public Property EmployeeName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Terminated")>
        Public Property IsEmployeeTerminated() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Power User")>
        Public Property IsPowerUser As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="WV Only User")>
        Public Property IsWVOnlyUser As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Media Tools User")>
        Public ReadOnly Property IsMediaToolUser As Boolean
            Get

                If _MediaToolUserCheck = False Then

                    _IsMediaToolUser = AdvantageFramework.Security.IsMediaToolUser(Me.UserCode, Me.MediaToolUserSetting)

                    _MediaToolUserCheck = True

                End If

                IsMediaToolUser = _IsMediaToolUser

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaToolUserSetting() As String
        Public Property OfficeCode() As String
        Public Property OfficeName() As String
        Public Property DepartmentCode() As String
        Public Property DepartmentName() As String

#End Region

#Region " Methods "

        Public Sub ResetMediaToolUserCheck()

            _MediaToolUserCheck = False

        End Sub

#End Region

    End Class

End Namespace
