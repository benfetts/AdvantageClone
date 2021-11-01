Namespace Database.Views

    <Table("WV_ALERTATTACHMENTLIST")>
    Public Class AlertAttachmentView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AttachmentID
            AlertID
            RealFileName
            AddedDate
            UserName
            MimeType
            EmailSent
            RepositoryFilename
            DocumentID
            FileSize
            Description
            UserCode
            IsPrivate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AttachmentID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AttachmentID() As Integer
        <Key>
        <Required>
        <Column("AlertID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Integer
        <MaxLength(100)>
        <Column("RealFileName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RealFileName() As String
        <Required>
        <Column("AddedDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AddedDate() As Date
        <MaxLength(61)>
        <Column("UserName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserName() As String
        <Required>
        <MaxLength(255)>
        <Column("MimeType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MimeType() As String
        <Required>
        <Column("EMAILSENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailSent() As Boolean
        <Required>
        <MaxLength(200)>
        <Column("REPOSITORY_FILENAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RepositoryFilename() As String
        <Required>
        <Column("DOCUMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DocumentID() As Integer
        <Required>
        <Column("FILE_SIZE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FileSize() As Integer
        <MaxLength(200)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <Required>
        <Column("PRIVATE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsPrivate() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AttachmentID.ToString

        End Function

#End Region

    End Class

End Namespace
