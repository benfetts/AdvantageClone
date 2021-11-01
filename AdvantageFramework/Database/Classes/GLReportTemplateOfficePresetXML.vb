Namespace Database.Classes

	Public Class GLReportTemplateOfficePresetXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			OfficeCode
			CreatedByUserCode
			CreatedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property OfficeCode() As String
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset)

			Me.ID = GLReportTemplateOfficePreset.ID
			Me.GLReportTemplateID = GLReportTemplateOfficePreset.GLReportTemplateID
			Me.OfficeCode = GLReportTemplateOfficePreset.OfficeCode
			Me.CreatedByUserCode = GLReportTemplateOfficePreset.CreatedByUserCode
			Me.CreatedDate = GLReportTemplateOfficePreset.CreatedDate

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplateOfficePreset

			'objects
			Dim GLReportTemplateOfficePreset As Database.Entities.GLReportTemplateOfficePreset = Nothing

			GLReportTemplateOfficePreset = New Database.Entities.GLReportTemplateOfficePreset

			GLReportTemplateOfficePreset.ID = Me.ID
			GLReportTemplateOfficePreset.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplateOfficePreset.OfficeCode = Me.OfficeCode
			GLReportTemplateOfficePreset.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplateOfficePreset.CreatedDate = Me.CreatedDate

			CreateEntity = GLReportTemplateOfficePreset

		End Function

#End Region

	End Class

End Namespace
