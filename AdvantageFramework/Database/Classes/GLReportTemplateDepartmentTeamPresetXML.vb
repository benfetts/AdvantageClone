Namespace Database.Classes

	Public Class GLReportTemplateDepartmentTeamPresetXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			DepartmentTeamCode
			CreatedByUserCode
			CreatedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property DepartmentTeamCode() As String
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset)

			Me.ID = GLReportTemplateDepartmentTeamPreset.ID
			Me.GLReportTemplateID = GLReportTemplateDepartmentTeamPreset.GLReportTemplateID
			Me.DepartmentTeamCode = GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode
			Me.CreatedByUserCode = GLReportTemplateDepartmentTeamPreset.CreatedByUserCode
			Me.CreatedDate = GLReportTemplateDepartmentTeamPreset.CreatedDate

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplateDepartmentTeamPreset

			'objects
			Dim GLReportTemplateDepartmentTeamPreset As Database.Entities.GLReportTemplateDepartmentTeamPreset = Nothing

			GLReportTemplateDepartmentTeamPreset = New Database.Entities.GLReportTemplateDepartmentTeamPreset

			GLReportTemplateDepartmentTeamPreset.ID = Me.ID
			GLReportTemplateDepartmentTeamPreset.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode = Me.DepartmentTeamCode
			GLReportTemplateDepartmentTeamPreset.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplateDepartmentTeamPreset.CreatedDate = Me.CreatedDate

			CreateEntity = GLReportTemplateDepartmentTeamPreset

		End Function

#End Region

	End Class

End Namespace
