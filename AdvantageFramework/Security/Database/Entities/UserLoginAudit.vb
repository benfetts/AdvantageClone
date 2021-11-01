Namespace Security.Database.Entities

    <Table("SEC_USER_LOGIN_AUDIT")>
    Public Class UserLoginAudit
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            IPAddress
            ApplicationID
            LoginDateTime
            LogoutDateTime
            Successful
            FailureReason
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("SEC_USER_LOGIN_AUDIT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("USER_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <Required>
        <Column("IP_ADDRESS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IPAddress() As String
        <Required>
        <Column("SEC_APPLICATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationID() As Integer
        <Required>
        <Column("LOGIN_DATETIME", TypeName:="datetime2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LoginDateTime() As DateTime
        <Required>
        <Column("LOGOUT_DATETIME", TypeName:="datetime2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LogoutDateTime() As DateTime
        <Required>
        <Column("SUCCESSFUL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Successful() As Boolean
        <Required>
        <Column("FAILURE_REASON", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FailureReason() As String

        Public Overridable Property Application As Database.Entities.Application

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
