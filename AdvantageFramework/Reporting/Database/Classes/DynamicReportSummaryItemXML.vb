Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DynamicReportSummaryItemXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			DynamicReportID
			SummaryItemType
			FieldName
			OnFooter
			DisplayFormat
			ColumnName
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property DynamicReportID() As Integer
		Public Property SummaryItemType() As Integer
		Public Property FieldName() As String
		Public Property OnFooter() As Boolean
		Public Property DisplayFormat() As String
		Public Property ColumnName() As String

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(DynamicReportSummaryItem As Database.Entities.DynamicReportSummaryItem)

			Me.ID = DynamicReportSummaryItem.ID
			Me.DynamicReportID = DynamicReportSummaryItem.DynamicReportID
			Me.SummaryItemType = DynamicReportSummaryItem.SummaryItemType
			Me.FieldName = DynamicReportSummaryItem.FieldName
			Me.OnFooter = DynamicReportSummaryItem.OnFooter
			Me.DisplayFormat = DynamicReportSummaryItem.DisplayFormat
			Me.ColumnName = DynamicReportSummaryItem.ColumnName

		End Sub
		Public Function CreateEntity() As Database.Entities.DynamicReportSummaryItem

			'objects
			Dim DynamicReportSummaryItem As Database.Entities.DynamicReportSummaryItem = Nothing

			DynamicReportSummaryItem = New Database.Entities.DynamicReportSummaryItem

			DynamicReportSummaryItem.ID = Me.ID
			DynamicReportSummaryItem.DynamicReportID = Me.DynamicReportID
			DynamicReportSummaryItem.SummaryItemType = Me.SummaryItemType
			DynamicReportSummaryItem.FieldName = Me.FieldName
			DynamicReportSummaryItem.OnFooter = Me.OnFooter
			DynamicReportSummaryItem.DisplayFormat = Me.DisplayFormat
			DynamicReportSummaryItem.ColumnName = Me.ColumnName

			CreateEntity = DynamicReportSummaryItem

		End Function

#End Region

	End Class

End Namespace
