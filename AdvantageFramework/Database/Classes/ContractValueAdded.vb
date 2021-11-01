Namespace Database.Classes

    <Serializable()>
    Public Class ContractValueAdded
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContractValueAdded
            Description
            Comment
            Amount
            HasDocument
            IsDocumentAURL
            DocumentURL
        End Enum

#End Region

#Region " Variables "

        Private _ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing
        Private _HasDocument As Boolean = False
        Private _IsDocumentAURL As Boolean = False
        Private _DocumentURL As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.ContractValueAdded)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded
            Get
                ContractValueAdded = _ContractValueAdded
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID As Integer
            Get
                ID = _ContractValueAdded.ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Short Description")>
        Public Property Description As String
            Get
                Description = _ContractValueAdded.Description
            End Get
            Set(ByVal value As String)
                _ContractValueAdded.Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comment As String
            Get
                Comment = _ContractValueAdded.Comment
            End Get
            Set(ByVal value As String)
                _ContractValueAdded.Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Amount As Nullable(Of Decimal)
            Get
                Amount = _ContractValueAdded.Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ContractValueAdded.Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property HasDocument As Boolean
            Get
                HasDocument = _HasDocument
            End Get
            Set(ByVal value As Boolean)
                _HasDocument = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsDocumentAURL As Boolean
            Get
                IsDocumentAURL = _IsDocumentAURL
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DocumentURL As String
            Get
                DocumentURL = _DocumentURL
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ContractValueAdded = New AdvantageFramework.Database.Entities.ContractValueAdded

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded)

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            _ContractValueAdded = ContractValueAdded

            If ContractValueAdded.DocumentID IsNot Nothing Then

                _HasDocument = True

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, ContractValueAdded.DocumentID)

                If Document IsNot Nothing Then

                    If Document.FileType = FileSystem.FileTypes.URL Then

                        _IsDocumentAURL = True

                        _DocumentURL = Document.FileSystemFileName

                    End If

                End If

            Else

                _HasDocument = False

            End If

        End Sub

#End Region

    End Class

End Namespace
