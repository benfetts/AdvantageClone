Namespace Database.Entities

    <Table("JOB_TRAFFIC_DET_PREDS")>
    Public Class JobComponentTaskPredecessor
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            SequenceNumber
            PredecessorSequenceNumber

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID", Order:=0)>
        Public Property ID() As Integer
        <Required>
        <Column("JOB_NUMBER")>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        Public Property JobComponentNumber() As Short
        <Required>
        <Column("SEQ_NBR")>
        Public Property SequenceNumber() As Short
        <Required>
        <Column("PREDECESSOR_SEQ_NBR")>
        Public Property PredecessorSequenceNumber() As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
