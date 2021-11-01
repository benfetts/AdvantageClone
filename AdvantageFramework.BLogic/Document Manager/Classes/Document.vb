Namespace DocumentManager.Classes

    <Serializable()>
    Public Class Document

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FileType
            ID
            DocumentLevelName
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
            DocumentLevel
            DocumentLabels
            InvoiceDate
        End Enum

#End Region

#Region " Variables "

        Private _Document As AdvantageFramework.Database.Entities.Document = Nothing
        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentLevelName As String = Nothing
        Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
        Private _DocumentLabels As Generic.List(Of AdvantageFramework.Database.Entities.Label) = Nothing
        Private _InvoiceDocument As AdvantageFramework.DocumentManager.Classes.InvoiceDocument = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, CustomColumnCaption:=" ")>
        Public ReadOnly Property FileType() As AdvantageFramework.FileSystem.FileTypes
            Get
                FileType = AdvantageFramework.FileSystem.GetFileType(Me.FileName, Me.MIMEType)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _Document.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True, CustomColumnCaption:="Document Level")>
        Public ReadOnly Property DocumentLevelName() As String
            Get
                DocumentLevelName = _DocumentLevelName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=True)>
        Public ReadOnly Property FileName() As String
            Get
                FileName = _Document.FileName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property FileSystemFileName() As String
            Get
                FileSystemFileName = _Document.FileSystemFileName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property MIMEType() As String
            Get
                MIMEType = _Document.MIMEType
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Document.Description
            End Get
            Set(value As String)
                _Document.Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Keywords() As String
            Get
                Keywords = _Document.Keywords
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Type", PropertyType:=BaseClasses.Methods.PropertyTypes.DocumentType)>
        Public Property DocumentTypeID() As Nullable(Of Integer)
            Get
                DocumentTypeID = _Document.DocumentTypeID
            End Get
            Set(value As Nullable(Of Integer))
                _Document.DocumentTypeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property FileSize() As Integer
            Get
                FileSize = _Document.FileSize
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Uploaded By")>
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _Document.UserCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public ReadOnly Property UploadedDate() As Date
            Get
                UploadedDate = _Document.UploadedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsPrivate() As Nullable(Of Integer)
            Get
                IsPrivate = _Document.IsPrivate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="ProofHQ Url", DefaultColumnType:=BaseClasses.DefaultColumnTypes.HyperLink)>
        Public ReadOnly Property ProofHQUrl() As String
            Get
                ProofHQUrl = _Document.ProofHQUrl
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="ProofHQ File ID", ShowColumnInGrid:=False)>
        Public ReadOnly Property ProofHQFileID() As Nullable(Of Integer)
            Get
                ProofHQFileID = _Document.ProofHQFileID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentLevel() As AdvantageFramework.Database.Entities.DocumentLevel
            Get
                DocumentLevel = _DocumentLevel
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentLevelSetting() As AdvantageFramework.Database.Classes.DocumentLevelSetting
            Get
                DocumentLevelSetting = _DocumentLevelSetting
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentLabels() As Generic.List(Of AdvantageFramework.Database.Entities.Label)
            Get
                DocumentLabels = _DocumentLabels
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property InvoiceDate() As Nullable(Of Date)
            Get

                If _InvoiceDocument IsNot Nothing Then

                    InvoiceDate = _InvoiceDocument.InvoiceDate

                Else

                    InvoiceDate = Nothing

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Document As AdvantageFramework.Database.Entities.Document, ByVal Labels As Generic.List(Of AdvantageFramework.Database.Entities.Label),
                       ByVal DocumentLabels As Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument))

            _Document = Document

            Dim LabelIds() As Long

            LabelIds = (From Entity In DocumentLabels
                        Where Entity.DocumentID = Document.ID
                        Select Entity.LabelID).ToArray

            _DocumentLabels = (From Entity In Labels
                               Where LabelIds.Contains(Entity.ID)
                               Select Entity).ToList()

        End Sub
        Public Sub New(ByVal Document As AdvantageFramework.Database.Entities.Document, ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel)

            _Document = Document
            _DocumentLevel = DocumentLevel

            _DocumentLevelName = (From DL In AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.DocumentLevel), False, True)
                                  Where DL.Item("Value") = DocumentLevel
                                  Select DL.Item("Name")).FirstOrDefault

        End Sub
        Public Sub New(Document As AdvantageFramework.Database.Entities.Document, DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, InvoiceDocument As AdvantageFramework.DocumentManager.Classes.InvoiceDocument)

            _Document = Document
            _DocumentLevel = DocumentLevel
            _InvoiceDocument = InvoiceDocument

            _DocumentLevelName = (From DL In AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.DocumentLevel), False, True)
                                  Where DL.Item("Value") = DocumentLevel
                                  Select DL.Item("Name")).FirstOrDefault

        End Sub
        Public Sub New(ByVal Document As AdvantageFramework.Database.Entities.Document, ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, _
                       ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting)

            _Document = Document
            _DocumentLevel = DocumentLevel

            _DocumentLevelName = (From DL In AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.DocumentLevel), False, True) _
                                  Where DL.Item("Value") = DocumentLevel _
                                  Select DL.Item("Name")).FirstOrDefault

            _DocumentLevelSetting = DocumentLevelSetting

        End Sub
        Public Function GetDocumentEntity() As AdvantageFramework.Database.Entities.Document

            GetDocumentEntity = _Document

        End Function

#End Region

    End Class

End Namespace

