Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DynamicReportXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Type
			Description
			CreatedByUserCode
			CreatedDate
			AllowCellMerge
			AutoSizeColumnsWhenPrinting
			PrintHeader
			PrintFooter
			PrintGroupFooter
			PrintSelectedRowsOnly
			PrintFilterInformation
			ShowViewCaption
			ShowGroupByBox
			ShowAutoFilterRow
			UpdatedByUserCode
			UpdatedDate
			ActiveFilter
			UserDefinedReportCategoryID
			DashboardLayout
			TemplateCode
			DynamicReportSummaryItems
			DynamicReportColumns
			UserDefinedReportCategory
			DynamicReportUnboundColumns
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property Type() As Integer
		Public Property Description() As String
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date
		Public Property AllowCellMerge() As Boolean
		Public Property AutoSizeColumnsWhenPrinting() As Boolean
		Public Property PrintHeader() As Boolean
		Public Property PrintFooter() As Boolean
		Public Property PrintGroupFooter() As Boolean
		Public Property PrintSelectedRowsOnly() As Boolean
		Public Property PrintFilterInformation() As Boolean
		Public Property ShowViewCaption() As Boolean
		Public Property ShowGroupByBox() As Boolean
		Public Property ShowAutoFilterRow() As Boolean
		Public Property UpdatedByUserCode() As String
		Public Property UpdatedDate() As Date
		Public Property ActiveFilter() As String
		Public Property UserDefinedReportCategoryID() As Nullable(Of Integer)
		Public Property DashboardLayout() As String
		Public Property TemplateCode() As String

		Public Property DynamicReportSummaryItems() As List(Of Database.Classes.DynamicReportSummaryItemXML)
		Public Property DynamicReportColumns() As List(Of Database.Classes.DynamicReportColumnXML)
		Public Property DynamicReportUnboundColumns() As List(Of Database.Classes.DynamicReportUnboundColumnXML)

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(DynamicReport As Database.Entities.DynamicReport)

			Me.ID = DynamicReport.ID
			Me.Type = DynamicReport.Type
			Me.Description = DynamicReport.Description
			Me.CreatedByUserCode = DynamicReport.CreatedByUserCode
			Me.CreatedDate = DynamicReport.CreatedDate
			Me.AllowCellMerge = DynamicReport.AllowCellMerge
			Me.AutoSizeColumnsWhenPrinting = DynamicReport.AutoSizeColumnsWhenPrinting
			Me.PrintHeader = DynamicReport.PrintHeader
			Me.PrintFooter = DynamicReport.PrintFooter
			Me.PrintGroupFooter = DynamicReport.PrintGroupFooter
			Me.PrintSelectedRowsOnly = DynamicReport.PrintSelectedRowsOnly
			Me.PrintFilterInformation = DynamicReport.PrintFilterInformation
			Me.ShowViewCaption = DynamicReport.ShowViewCaption
			Me.ShowGroupByBox = DynamicReport.ShowGroupByBox
			Me.ShowAutoFilterRow = DynamicReport.ShowAutoFilterRow
			Me.UpdatedByUserCode = DynamicReport.UpdatedByUserCode
			Me.UpdatedDate = DynamicReport.UpdatedDate
			Me.ActiveFilter = DynamicReport.ActiveFilter
            Me.UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

            If DynamicReport.DashboardLayout Is Nothing Then

                Me.DashboardLayout = String.Empty

            Else

                Me.DashboardLayout = Convert.ToBase64String(DynamicReport.DashboardLayout)

            End If

            Me.TemplateCode = DynamicReport.TemplateCode

			If DynamicReport.DynamicReportSummaryItems IsNot Nothing Then

				Me.DynamicReportSummaryItems = DynamicReport.DynamicReportSummaryItems.Select(Function(Entity) New Database.Classes.DynamicReportSummaryItemXML(Entity)).ToList

			Else

				Me.DynamicReportSummaryItems = New Generic.List(Of Database.Classes.DynamicReportSummaryItemXML)

			End If

			If DynamicReport.DynamicReportColumns IsNot Nothing Then

				Me.DynamicReportColumns = DynamicReport.DynamicReportColumns.Select(Function(Entity) New Database.Classes.DynamicReportColumnXML(Entity)).ToList

			Else

				Me.DynamicReportColumns = New Generic.List(Of Database.Classes.DynamicReportColumnXML)

			End If

			If DynamicReport.DynamicReportUnboundColumns IsNot Nothing Then

				Me.DynamicReportUnboundColumns = DynamicReport.DynamicReportUnboundColumns.Select(Function(Entity) New Database.Classes.DynamicReportUnboundColumnXML(Entity)).ToList

			Else

				Me.DynamicReportUnboundColumns = New Generic.List(Of Database.Classes.DynamicReportUnboundColumnXML)

			End If

		End Sub
		Public Function CreateEntity() As Database.Entities.DynamicReport

			'objects
			Dim DynamicReport As Database.Entities.DynamicReport = Nothing

			DynamicReport = New Database.Entities.DynamicReport

			DynamicReport.ID = Me.ID
			DynamicReport.Type = Me.Type
			DynamicReport.Description = Me.Description
			DynamicReport.CreatedByUserCode = Me.CreatedByUserCode
			DynamicReport.CreatedDate = Me.CreatedDate
			DynamicReport.AllowCellMerge = Me.AllowCellMerge
			DynamicReport.AutoSizeColumnsWhenPrinting = Me.AutoSizeColumnsWhenPrinting
			DynamicReport.PrintHeader = Me.PrintHeader
			DynamicReport.PrintFooter = Me.PrintFooter
			DynamicReport.PrintGroupFooter = Me.PrintGroupFooter
			DynamicReport.PrintSelectedRowsOnly = Me.PrintSelectedRowsOnly
			DynamicReport.PrintFilterInformation = Me.PrintFilterInformation
			DynamicReport.ShowViewCaption = Me.ShowViewCaption
			DynamicReport.ShowGroupByBox = Me.ShowGroupByBox
			DynamicReport.ShowAutoFilterRow = Me.ShowAutoFilterRow
			DynamicReport.UpdatedByUserCode = Me.UpdatedByUserCode
			DynamicReport.UpdatedDate = Me.UpdatedDate
			DynamicReport.ActiveFilter = Me.ActiveFilter
			DynamicReport.UserDefinedReportCategoryID = Me.UserDefinedReportCategoryID
			DynamicReport.DashboardLayout = Convert.FromBase64String(Me.DashboardLayout)
			DynamicReport.TemplateCode = Me.TemplateCode

			If Me.DynamicReportSummaryItems IsNot Nothing Then

				DynamicReport.DynamicReportSummaryItems = Me.DynamicReportSummaryItems.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.DynamicReportColumns IsNot Nothing Then

				DynamicReport.DynamicReportColumns = Me.DynamicReportColumns.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.DynamicReportUnboundColumns IsNot Nothing Then

				DynamicReport.DynamicReportUnboundColumns = Me.DynamicReportUnboundColumns.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			CreateEntity = DynamicReport

		End Function

#End Region

	End Class

End Namespace
