Namespace Security.Database.Views

    <Table("V_SERVER_SQLUSER")>
    Public Class ServerSQLUser
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            ID
            SID
            Type
            TypeDescription
            IsDisabled
            CreatedDate
            ModifiedDate
            DefaultDatabaseName
            DefaultLanguageName
            CredentialID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(128)>
        <Column("name")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
        <Key>
        <Required>
        <Column("principal_id")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Column("sid")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SID() As Byte()
        <Required>
        <MaxLength(1)>
        <Column("type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
        <MaxLength(60)>
        <Column("type_desc")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TypeDescription() As String
        <Column("is_disabled")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDisabled() As Nullable(Of Boolean)
        <Required>
        <Column("create_date")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <Required>
        <Column("modify_date")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Date
        <MaxLength(128)>
        <Column("default_database_name")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultDatabaseName() As String
        <MaxLength(128)>
        <Column("default_language_name")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultLanguageName() As String
        <Column("credential_id")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CredentialID() As Nullable(Of Integer)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace
