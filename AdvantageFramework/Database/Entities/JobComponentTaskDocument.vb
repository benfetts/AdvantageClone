Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.JOB_TRAFFIC_DET_DOCS")>
    Public Class JobComponentTaskDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DocumentID
            JobNumber
            JobComponentNumber
            SequenceNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _DocumentID As Integer = 0
        Private _JobNumber As Integer = 0
        Private _JobComponentNumber As Short = 0
        Private _SequenceNumber As Short = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROWID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int"),
		System.ComponentModel.DisplayName("Document ID"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DocumentID() As Integer
			Get
				DocumentID = _DocumentID
			End Get
			Set(ByVal value As Integer)
				_DocumentID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DbType:="int"),
		System.ComponentModel.DisplayName("Job Number"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobComponentNumber", DbType:="smallint"), _
        System.ComponentModel.DisplayName("Job Component Number"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")> _
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SEQ_NBR", Storage:="_SequenceNumber", DbType:="smallint"), _
        System.ComponentModel.DisplayName("Sequence Number"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")> _
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As Short)
                _SequenceNumber = value
            End Set
        End Property
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace