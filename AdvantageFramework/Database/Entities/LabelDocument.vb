Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.LABEL_DOCUMENT")>
    Public Class LabelDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            LabelID
            DocumentID
        End Enum

#End Region

#Region " Variables "

        Private _LabelID As Long = 0
        Private _DocumentID As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LABEL_ID", Storage:="_LabelID", DbType:="int"),
    System.ComponentModel.DisplayName("LabelID")>
        Public Property LabelID() As Long
            Get
                LabelID = _LabelID
            End Get
            Set(ByVal value As Long)
                _LabelID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int"),
    System.ComponentModel.DisplayName("DocumentID")>
        Public Property DocumentID() As Long
            Get
                DocumentID = _DocumentID
            End Get
            Set(ByVal value As Long)
                _DocumentID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

