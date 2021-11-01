Namespace Database.Classes

	Public Class GLReportTemplatePctOfRowColumnRelationXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			GLReportTemplateColumnID
			RowIndex
			PctOfRowIndex
			CreatedByUserCode
			CreatedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property GLReportTemplateColumnID() As Integer
		Public Property RowIndex() As Integer
		Public Property PctOfRowIndex() As Nullable(Of Integer)
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation)

			Me.ID = GLReportTemplatePctOfRowColumnRelation.ID
			Me.GLReportTemplateID = GLReportTemplatePctOfRowColumnRelation.GLReportTemplateID
			Me.GLReportTemplateColumnID = GLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID
			Me.RowIndex = GLReportTemplatePctOfRowColumnRelation.RowIndex
			Me.PctOfRowIndex = GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex
			Me.CreatedByUserCode = GLReportTemplatePctOfRowColumnRelation.CreatedByUserCode
			Me.CreatedDate = GLReportTemplatePctOfRowColumnRelation.CreatedDate

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplatePctOfRowColumnRelation

			'objects
			Dim GLReportTemplatePctOfRowColumnRelation As Database.Entities.GLReportTemplatePctOfRowColumnRelation = Nothing

			GLReportTemplatePctOfRowColumnRelation = New Database.Entities.GLReportTemplatePctOfRowColumnRelation

			GLReportTemplatePctOfRowColumnRelation.ID = Me.ID
			GLReportTemplatePctOfRowColumnRelation.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID = Me.GLReportTemplateColumnID
			GLReportTemplatePctOfRowColumnRelation.RowIndex = Me.RowIndex
			GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex = Me.PctOfRowIndex
			GLReportTemplatePctOfRowColumnRelation.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplatePctOfRowColumnRelation.CreatedDate = Me.CreatedDate

			CreateEntity = GLReportTemplatePctOfRowColumnRelation

		End Function

#End Region

	End Class

End Namespace
