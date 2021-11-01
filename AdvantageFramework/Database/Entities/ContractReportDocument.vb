Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.CONTRACT_REPORT_DOCUMENTS")>
    Public Class ContractReportDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ContractReportID
            DocumentID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _ContractReportID As Long = 0
        Private _DocumentID As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTRACT_REPORT_DOCUMENTS_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTRACT_REPORT_ID", Storage:="_ContractReportID", DBType:="int"), _
        System.ComponentModel.DisplayName("ContractReportID")> _
        Public Property ContractReportID() As Long
            Get
                ContractReportID = _ContractReportID
            End Get
            Set(ByVal value As Long)
                _ContractReportID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DBType:="int"), _
        System.ComponentModel.DisplayName("DocumentID")> _
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
