Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.JOB_COMPONENT_DOCUMENTS")>
    Public Class JobComponentDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            JobComponentNumber
            JobNumber
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _JobComponentNumber As System.Nullable(Of Long) = 0
        Private _JobNumber As Long = 0

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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NUMBER", Storage:="_JobComponentNumber", DBType:="smallint"), _
        System.ComponentModel.DisplayName("JobComponentNumber")> _
        Public Property JobComponentNumber() As System.Nullable(Of Long)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("JobNumber")> _
        Public Property JobNumber() As Long
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Long)
                _JobNumber = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace