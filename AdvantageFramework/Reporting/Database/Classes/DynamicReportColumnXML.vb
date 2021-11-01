Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DynamicReportColumnXML

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
			Width
			SortIndex
			GroupIndex
			VisibleIndex
			TemplateDetailID
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
		Public Property Width() As Integer
		Public Property SortIndex() As Integer
		Public Property GroupIndex() As Integer
		Public Property VisibleIndex() As Integer
		Public Property TemplateDetailID() As Nullable(Of Integer)

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(DynamicReportColumn As Database.Entities.DynamicReportColumn)

			Me.ID = DynamicReportColumn.ID
			Me.DynamicReportID = DynamicReportColumn.DynamicReportID
			Me.FieldName = DynamicReportColumn.FieldName
			Me.HeaderText = DynamicReportColumn.HeaderText
			Me.IsVisible = DynamicReportColumn.IsVisible
			Me.SortOrder = DynamicReportColumn.SortOrder
			Me.Width = DynamicReportColumn.Width
			Me.SortIndex = DynamicReportColumn.SortIndex
			Me.GroupIndex = DynamicReportColumn.GroupIndex
			Me.VisibleIndex = DynamicReportColumn.VisibleIndex
			Me.TemplateDetailID = DynamicReportColumn.TemplateDetailID

		End Sub
		Public Function CreateEntity() As Database.Entities.DynamicReportColumn

			'objects
			Dim DynamicReportColumn As Database.Entities.DynamicReportColumn = Nothing

			DynamicReportColumn = New Database.Entities.DynamicReportColumn

			DynamicReportColumn.ID = Me.ID
			DynamicReportColumn.DynamicReportID = Me.DynamicReportID
			DynamicReportColumn.FieldName = Me.FieldName
			DynamicReportColumn.HeaderText = Me.HeaderText
			DynamicReportColumn.IsVisible = Me.IsVisible
			DynamicReportColumn.SortOrder = Me.SortOrder
			DynamicReportColumn.Width = Me.Width
			DynamicReportColumn.SortIndex = Me.SortIndex
			DynamicReportColumn.GroupIndex = Me.GroupIndex
			DynamicReportColumn.VisibleIndex = Me.VisibleIndex
			DynamicReportColumn.TemplateDetailID = Me.TemplateDetailID

			CreateEntity = DynamicReportColumn

		End Function

#End Region

	End Class

End Namespace
