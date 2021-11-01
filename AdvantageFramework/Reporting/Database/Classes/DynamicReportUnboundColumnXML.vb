Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DynamicReportUnboundColumnXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			DynamicReportID
			FieldName
			HeaderText
			IsVisible
			SortOrder
			SortIndex
			GroupIndex
			Width
			VisibleIndex
			UnboundType
			Expression
			Format
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property DynamicReportID() As Integer
		Public Property FieldName() As String
		Public Property HeaderText() As String
		Public Property IsVisible() As Boolean
		Public Property SortOrder() As Integer
		Public Property SortIndex() As Integer
		Public Property GroupIndex() As Integer
		Public Property Width() As Integer
		Public Property VisibleIndex() As Integer
		Public Property UnboundType() As Integer
		Public Property Expression() As String
		Public Property Format() As String

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(DynamicReportUnboundColumn As Database.Entities.DynamicReportUnboundColumn)

			Me.ID = DynamicReportUnboundColumn.ID
			Me.DynamicReportID = DynamicReportUnboundColumn.DynamicReportID
			Me.FieldName = DynamicReportUnboundColumn.FieldName
			Me.HeaderText = DynamicReportUnboundColumn.HeaderText
			Me.IsVisible = DynamicReportUnboundColumn.IsVisible
			Me.SortOrder = DynamicReportUnboundColumn.SortOrder
			Me.SortIndex = DynamicReportUnboundColumn.SortIndex
			Me.GroupIndex = DynamicReportUnboundColumn.GroupIndex
			Me.Width = DynamicReportUnboundColumn.Width
			Me.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex
			Me.UnboundType = DynamicReportUnboundColumn.UnboundType
			Me.Expression = DynamicReportUnboundColumn.Expression
			Me.Format = DynamicReportUnboundColumn.Format

		End Sub
		Public Function CreateEntity() As Database.Entities.DynamicReportUnboundColumn

			'objects
			Dim DynamicReportUnboundColumn As Database.Entities.DynamicReportUnboundColumn = Nothing

			DynamicReportUnboundColumn = New Database.Entities.DynamicReportUnboundColumn

			DynamicReportUnboundColumn.ID = Me.ID
			DynamicReportUnboundColumn.DynamicReportID = Me.DynamicReportID
			DynamicReportUnboundColumn.FieldName = Me.FieldName
			DynamicReportUnboundColumn.HeaderText = Me.HeaderText
			DynamicReportUnboundColumn.IsVisible = Me.IsVisible
			DynamicReportUnboundColumn.SortOrder = Me.SortOrder
			DynamicReportUnboundColumn.SortIndex = Me.SortIndex
			DynamicReportUnboundColumn.GroupIndex = Me.GroupIndex
			DynamicReportUnboundColumn.Width = Me.Width
			DynamicReportUnboundColumn.VisibleIndex = Me.VisibleIndex
			DynamicReportUnboundColumn.UnboundType = Me.UnboundType
			DynamicReportUnboundColumn.Expression = Me.Expression
			DynamicReportUnboundColumn.Format = Me.Format

			CreateEntity = DynamicReportUnboundColumn

		End Function

#End Region

	End Class

End Namespace
