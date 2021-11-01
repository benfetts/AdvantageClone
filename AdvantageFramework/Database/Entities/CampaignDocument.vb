Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.CAMPAIGN_DOCUMENTS")>
    Public Class CampaignDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            CampaignID
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _CampaignID As System.Nullable(Of Long) = 0

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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CMP_IDENTIFIER", Storage:="_CampaignID", DBType:="int"), _
        System.ComponentModel.DisplayName("CampaignID")> _
        Public Property CampaignID() As System.Nullable(Of Long)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _CampaignID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace