Namespace Database.Classes

	Public Class GLReportTemplateRowRelationXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			GLReportTemplateRowID
			RelatedRowIndex
			CreatedByUserCode
			CreatedDate
			Order
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property GLReportTemplateRowID() As Integer
		Public Property RelatedRowIndex() As Integer
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date
		Public Property Order() As Integer

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation)

			Me.ID = GLReportTemplateRowRelation.ID
			Me.GLReportTemplateID = GLReportTemplateRowRelation.GLReportTemplateID
			Me.GLReportTemplateRowID = GLReportTemplateRowRelation.GLReportTemplateRowID
			Me.RelatedRowIndex = GLReportTemplateRowRelation.RelatedRowIndex
			Me.CreatedByUserCode = GLReportTemplateRowRelation.CreatedByUserCode
			Me.CreatedDate = GLReportTemplateRowRelation.CreatedDate
			Me.Order = GLReportTemplateRowRelation.Order

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplateRowRelation

			'objects
			Dim GLReportTemplateRowRelation As Database.Entities.GLReportTemplateRowRelation = Nothing

			GLReportTemplateRowRelation = New Database.Entities.GLReportTemplateRowRelation

			GLReportTemplateRowRelation.ID = Me.ID
			GLReportTemplateRowRelation.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplateRowRelation.GLReportTemplateRowID = Me.GLReportTemplateRowID
			GLReportTemplateRowRelation.RelatedRowIndex = Me.RelatedRowIndex
			GLReportTemplateRowRelation.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplateRowRelation.CreatedDate = Me.CreatedDate
			GLReportTemplateRowRelation.Order = Me.Order

			CreateEntity = GLReportTemplateRowRelation

		End Function

#End Region

	End Class

End Namespace
