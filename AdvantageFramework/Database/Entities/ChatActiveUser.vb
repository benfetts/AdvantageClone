Namespace Database.Entities

    Public Class ChatActiveUser
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            ContextUserIdentityName
            ConnectionId
            GUID
            UserCode
            EmployeeCode
            EmployeeFullName
            ConnectionString
            EmployeePicture
            IsTempSaved
            DoNotDisturb

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        Public Property ContextUserIdentityName As String = ""
        Public Property ConnectionId As String = ""
        Public Property GUID As String = ""
        Public Property UserCode As String
        Public Property EmployeeCode As String
        Public Property EmployeeFullName As String
        Public Property ConnectionString As String = ""
        Public Property EmployeePicture As Byte()
        Public Property IsTempSaved As Boolean = False
        Public Property DoNotDisturb As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
