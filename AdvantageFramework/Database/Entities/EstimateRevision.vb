Namespace Database.Entities

	<Table("ESTIMATE_REV")>
	Public Class EstimateRevision
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EstimateNumber
			EstimateComponentNumber
			EstimateQuoteNumber
			Number
			Comment
			VersionNumber
			RevisionNumber
			SquenceNumber
			JobQuantity
			EstimateRevisionDetails
			EstimateApprovals

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ESTIMATE_NUMBER", Order:=0)>
        Public Property EstimateNumber() As Integer
		<Key>
		<Required>
        <Column("EST_COMPONENT_NBR", Order:=1)>
        Public Property EstimateComponentNumber() As Short
		<Key>
		<Required>
        <Column("EST_QUOTE_NBR", Order:=2)>
        Public Property EstimateQuoteNumber() As Short
		<Key>
		<Required>
		<Column("EST_REV_NBR", Order:=3)>
		Public Property Number() As Short
		<Column("EST_REV_COMMENT")>
		Public Property Comment() As String
		<Column("SPEC_VER")>
		Public Property VersionNumber() As Nullable(Of Integer)
		<Column("SPEC_REV")>
		Public Property RevisionNumber() As Nullable(Of Integer)
		<Column("SPEC_QTY_SEQ_NBR")>
		Public Property SquenceNumber() As Nullable(Of Integer)
		<Column("JOB_QTY")>
		Public Property JobQuantity() As Nullable(Of Integer)

        Public Overridable Property EstimateRevisionDetails As ICollection(Of Database.Entities.EstimateRevisionDetail)
        Public Overridable Property EstimateApprovals As ICollection(Of Database.Views.EstimateApproval)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber

        End Function

#End Region

	End Class

End Namespace
