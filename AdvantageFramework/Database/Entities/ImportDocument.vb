Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.IMPORT_DOCUMENTS")>
    Public Class ImportDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            ImportID
            ImportTemplateID
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _ImportID As Long = 0
        Private _ImportTemplateID As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int", IsPrimaryKey:=True),
        System.ComponentModel.DisplayName("DocumentID")>
        Public Property DocumentID() As Long
            Get
                DocumentID = _DocumentID
            End Get
            Set(ByVal value As Long)
                _DocumentID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ID", Storage:="_ImportID", DbType:="int"),
        System.ComponentModel.DisplayName("AccountPayableID")>
        Public Property ImportID() As Long
            Get
                ImportID = _ImportID
            End Get
            Set(ByVal value As Long)
                _ImportID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TEMPLATE_ID", Storage:="_ImportTemplateID", DbType:="int"),
        System.ComponentModel.DisplayName("ImportTemplateID")>
        Public Property ImportTemplateID() As Long
            Get
                ImportTemplateID = _ImportTemplateID
            End Get
            Set(ByVal value As Long)
                _ImportTemplateID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace