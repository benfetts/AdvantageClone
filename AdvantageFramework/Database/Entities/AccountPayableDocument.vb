Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AP_DOCUMENTS")>
    Public Class AccountPayableDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            AccountPayableID
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _AccountPayableID As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("DocumentID")> _
        Public Property DocumentID() As Long
            Get
                DocumentID = _DocumentID
            End Get
            Set(ByVal value As Long)
                _DocumentID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AP_ID", Storage:="_AccountPayableID", DBType:="int"), _
        System.ComponentModel.DisplayName("AccountPayableID")> _
        Public Property AccountPayableID() As Long
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(ByVal value As Long)
                _AccountPayableID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace