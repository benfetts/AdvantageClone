Namespace Database.Classes

	Public Class GLReportTemplateXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			DashboardLayout
			PostPeriodCode
			ReportType
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			GLReportUserDefReportID
			PrintColumnHeadingsOnEveryPage
			SortRowsBy
			CurrencyCode
			CurrencyRate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property Description() As String
		Public Property DashboardLayout() As Byte()
		Public Property PostPeriodCode() As String
		Public Property ReportType() As Integer
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date
		Public Property ModifiedByUserCode() As String
		Public Property ModifiedDate() As Nullable(Of Date)
		Public Property GLReportUserDefReportID() As Nullable(Of Integer)
		Public Property PrintColumnHeadingsOnEveryPage() As Boolean
		Public Property SortRowsBy() As Integer
		Public Property CurrencyCode() As String
		Public Property CurrencyRate() As Nullable(Of Decimal)

		Public Property GLReportTemplateColumns As List(Of Database.Classes.GLReportTemplateColumnXML)
		Public Property GLReportTemplateRows As List(Of Database.Classes.GLReportTemplateRowXML)
		Public Property GLReportTemplateRowRelations As List(Of Database.Classes.GLReportTemplateRowRelationXML)
		Public Property GLReportTemplateDepartmentTeamPresets As List(Of Database.Classes.GLReportTemplateDepartmentTeamPresetXML)
		Public Property GLReportTemplateOfficePresets As List(Of Database.Classes.GLReportTemplateOfficePresetXML)
		Public Property GLReportTemplatePctOfRowColumnRelations As List(Of Database.Classes.GLReportTemplatePctOfRowColumnRelationXML)

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplate As Database.Entities.GLReportTemplate)

			Me.ID = GLReportTemplate.ID
			Me.Description = GLReportTemplate.Description
			Me.DashboardLayout = GLReportTemplate.DashboardLayout
			Me.PostPeriodCode = GLReportTemplate.PostPeriodCode
			Me.ReportType = GLReportTemplate.ReportType
			Me.CreatedByUserCode = GLReportTemplate.CreatedByUserCode
			Me.CreatedDate = GLReportTemplate.CreatedDate
			Me.ModifiedByUserCode = GLReportTemplate.ModifiedByUserCode
			Me.ModifiedDate = GLReportTemplate.ModifiedDate
			Me.GLReportUserDefReportID = GLReportTemplate.GLReportUserDefReportID
			Me.PrintColumnHeadingsOnEveryPage = GLReportTemplate.PrintColumnHeadingsOnEveryPage
			Me.SortRowsBy = GLReportTemplate.SortRowsBy
			Me.CurrencyCode = GLReportTemplate.CurrencyCode
			Me.CurrencyRate = GLReportTemplate.CurrencyRate

			If GLReportTemplate.GLReportTemplateColumns IsNot Nothing Then

				Me.GLReportTemplateColumns = GLReportTemplate.GLReportTemplateColumns.Select(Function(Entity) New GLReportTemplateColumnXML(Entity)).ToList

			Else

				Me.GLReportTemplateColumns = New Generic.List(Of GLReportTemplateColumnXML)

			End If

			If GLReportTemplate.GLReportTemplateRows IsNot Nothing Then

				Me.GLReportTemplateRows = GLReportTemplate.GLReportTemplateRows.Select(Function(Entity) New GLReportTemplateRowXML(Entity)).ToList

			Else

				Me.GLReportTemplateRows = New Generic.List(Of GLReportTemplateRowXML)

			End If

			If GLReportTemplate.GLReportTemplateRowRelations IsNot Nothing Then

				Me.GLReportTemplateRowRelations = GLReportTemplate.GLReportTemplateRowRelations.Select(Function(Entity) New GLReportTemplateRowRelationXML(Entity)).ToList

			Else

				Me.GLReportTemplateRowRelations = New Generic.List(Of GLReportTemplateRowRelationXML)

			End If

			If GLReportTemplate.GLReportTemplateDepartmentTeamPresets IsNot Nothing Then

				Me.GLReportTemplateDepartmentTeamPresets = GLReportTemplate.GLReportTemplateDepartmentTeamPresets.Select(Function(Entity) New GLReportTemplateDepartmentTeamPresetXML(Entity)).ToList

			Else

				Me.GLReportTemplateDepartmentTeamPresets = New Generic.List(Of GLReportTemplateDepartmentTeamPresetXML)

			End If

			If GLReportTemplate.GLReportTemplateOfficePresets IsNot Nothing Then

				Me.GLReportTemplateOfficePresets = GLReportTemplate.GLReportTemplateOfficePresets.Select(Function(Entity) New GLReportTemplateOfficePresetXML(Entity)).ToList

			Else

				Me.GLReportTemplateOfficePresets = New Generic.List(Of GLReportTemplateOfficePresetXML)

			End If

			If GLReportTemplate.GLReportTemplatePctOfRowColumnRelations IsNot Nothing Then

				Me.GLReportTemplatePctOfRowColumnRelations = GLReportTemplate.GLReportTemplatePctOfRowColumnRelations.Select(Function(Entity) New GLReportTemplatePctOfRowColumnRelationXML(Entity)).ToList

			Else

				Me.GLReportTemplatePctOfRowColumnRelations = New Generic.List(Of GLReportTemplatePctOfRowColumnRelationXML)

			End If

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplate

			'objects
			Dim GLReportTemplate As Database.Entities.GLReportTemplate = Nothing

			GLReportTemplate = New Database.Entities.GLReportTemplate

			GLReportTemplate.ID = Me.ID
			GLReportTemplate.Description = Me.Description
			GLReportTemplate.DashboardLayout = Me.DashboardLayout
			GLReportTemplate.PostPeriodCode = Me.PostPeriodCode
			GLReportTemplate.ReportType = Me.ReportType
			GLReportTemplate.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplate.CreatedDate = Me.CreatedDate
			GLReportTemplate.ModifiedByUserCode = Me.ModifiedByUserCode
			GLReportTemplate.ModifiedDate = Me.ModifiedDate
			GLReportTemplate.GLReportUserDefReportID = Me.GLReportUserDefReportID
			GLReportTemplate.PrintColumnHeadingsOnEveryPage = Me.PrintColumnHeadingsOnEveryPage
			GLReportTemplate.SortRowsBy = Me.SortRowsBy
			GLReportTemplate.CurrencyCode = Me.CurrencyCode
			GLReportTemplate.CurrencyRate = Me.CurrencyRate

			If Me.GLReportTemplateColumns IsNot Nothing Then

				GLReportTemplate.GLReportTemplateColumns = Me.GLReportTemplateColumns.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.GLReportTemplateRows IsNot Nothing Then

				GLReportTemplate.GLReportTemplateRows = Me.GLReportTemplateRows.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.GLReportTemplateRowRelations IsNot Nothing Then

				GLReportTemplate.GLReportTemplateRowRelations = Me.GLReportTemplateRowRelations.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.GLReportTemplateDepartmentTeamPresets IsNot Nothing Then

				GLReportTemplate.GLReportTemplateDepartmentTeamPresets = Me.GLReportTemplateDepartmentTeamPresets.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.GLReportTemplateOfficePresets IsNot Nothing Then

				GLReportTemplate.GLReportTemplateOfficePresets = Me.GLReportTemplateOfficePresets.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			If Me.GLReportTemplatePctOfRowColumnRelations IsNot Nothing Then

				GLReportTemplate.GLReportTemplatePctOfRowColumnRelations = Me.GLReportTemplatePctOfRowColumnRelations.Select(Function(Entity) Entity.CreateEntity()).ToList

			End If

			CreateEntity = GLReportTemplate

		End Function

#End Region

	End Class

End Namespace
