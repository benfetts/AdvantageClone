Namespace Database.Entities

    <Table("ACCESS_EMAIL")>
    Public Class AccessEmail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            [To]
            CC
            BCC
            Subject
            IsBodyHTML
            Body
            AttachmentName
            Attachment
            AttachmentPath
            Processed
            ErrorMessage
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ACCESS_EMAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UserCode() As String
        <Required>
        <Column("EMAIL_TO", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property [TO]() As String
        <Required>
        <Column("CC", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CC() As String
        <Required>
        <Column("BCC", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BCC() As String
        <Required>
        <Column("SUBJECT", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Subject() As String
        <Required>
        <Column("IS_BODY_HTML")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsBodyHTML() As Boolean
        <Required>
        <Column("BODY", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Body() As String
        <Column("ATTACHMENT_NAME", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AttachmentName() As String
        <Column("ATTACHMENT", TypeName:="varbinary(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Attachment() As Byte()
        <Column("ATTACHMENT_PATH", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AttachmentPath() As String
        <Required>
        <Column("PROCESSED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Processed() As Boolean
        <Required>
        <Column("ERROR_MESSAGE", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ErrorMessage() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.UserCode

        End Function

#End Region

    End Class

End Namespace
