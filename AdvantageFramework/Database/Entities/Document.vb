Namespace Database.Entities

	<Table("DOCUMENTS")>
	Public Class Document
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			FileName
			FileSystemFileName
			MIMEType
			Description
			Keywords
			UploadedDate
			UserCode
			FileSize
			IsPrivate
			DocumentTypeID
			ProofHQUrl
            ProofHQFileID
            Thumbnail
            DocumentComments
			ExecutiveDesktopDocuments
			AgencyDesktopDocument
			OfficeDocument
			JobComponent
			Job
			Product
			ExpenseReportDocuments
			DocumentType
			ExpenseDetailDocuments
			ContractDocuments
			ContractValueAdded
			AccountReceivableDocuments

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <NotMapped>
        Public ReadOnly Property FileType() As AdvantageFramework.FileSystem.FileTypes
            Get
                FileType = AdvantageFramework.FileSystem.GetFileType(Me.FileName, Me.MIMEType)
            End Get
        End Property
        <Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("DOCUMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property ID() As Integer
        <MaxLength(300)>
        <Column("FILENAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True)>
		Public Property FileName() As String
		<Required>
		<MaxLength(200)>
		<Column("REPOSITORY_FILENAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property FileSystemFileName() As String
		<Required>
		<MaxLength(255)>
		<Column("MIME_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property MIMEType() As String
		<MaxLength(200)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(255)>
		<Column("KEYWORDS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Keywords() As String
		<Required>
		<Column("UPLOADED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UploadedDate() As Date
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Uploaded By")>
		Public Property UserCode() As String
		<Required>
		<Column("FILE_SIZE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileSize() As Integer
		<Column("PRIVATE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsPrivate() As Nullable(Of Integer)
		<Column("DOCUMENT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Type")>
		Public Property DocumentTypeID() As Nullable(Of Integer)
		<Column("PROOFHQ_URL", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="ProofHQ Url", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.HyperLink)>
		Public Property ProofHQUrl() As String
		<Column("PROOFHQ_FILEID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProofHQFileID() As Nullable(Of Integer)
        <Column("THUMBNAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thumbnail() As Byte()
        <Column("VERSION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VersionNumber() As Nullable(Of Integer)

        Public Overridable Property DocumentComments As ICollection(Of Database.Entities.DocumentComment)
        Public Overridable Property ExpenseReportDocuments As ICollection(Of Database.Entities.ExpenseReportDocument)
        Public Overridable Property DocumentType As Database.Entities.DocumentType
        Public Overridable Property ExpenseDetailDocuments As ICollection(Of Database.Entities.ExpenseDetailDocument)
        Public Overridable Property ContractDocuments As ICollection(Of Database.Entities.ContractDocument)
        Public Overridable Property ContractValueAdded As ICollection(Of Database.Entities.ContractValueAdded)
        Public Overridable Property AccountReceivableDocuments As ICollection(Of Database.Entities.AccountReceivableDocument)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
