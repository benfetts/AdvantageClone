Namespace Database.Classes

	Public Class GLReportTemplateColumnXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			Description
			Name
			ColumnIndex
			Type
			DataType
			PreviousYears
			PeriodOption
			IsVisible
			Expression
			UnderlineColumnHeaders
			UseCurrencyFormat
			NumberOfDecimalPlaces
			Column1Name
			Column2Name
			PctOfRowColumnName
			OfficeCode
			OverrideDataOptions
			DataOption
			DataCalculation
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property Description() As String
		Public Property Name() As String
		Public Property ColumnIndex() As Integer
		Public Property Type() As Integer
		Public Property DataType() As Integer
		Public Property PreviousYears() As Integer
		Public Property PeriodOption() As Integer
		Public Property IsVisible() As Boolean
		Public Property Expression() As String
		Public Property UnderlineColumnHeaders() As Boolean
		Public Property UseCurrencyFormat() As Boolean
		Public Property NumberOfDecimalPlaces() As Integer
		Public Property Column1Name() As String
		Public Property Column2Name() As String
		Public Property PctOfRowColumnName() As String
		Public Property OfficeCode() As String
		Public Property OverrideDataOptions() As Boolean
		Public Property DataOption() As Integer
		Public Property DataCalculation() As Integer
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date
		Public Property ModifiedByUserCode() As String
		Public Property ModifiedDate() As Nullable(Of Date)

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(GLReportTemplateColumn As Database.Entities.GLReportTemplateColumn)

			Me.ID = GLReportTemplateColumn.ID
			Me.GLReportTemplateID = GLReportTemplateColumn.GLReportTemplateID
			Me.Description = GLReportTemplateColumn.Description
			Me.Name = GLReportTemplateColumn.Name
			Me.ColumnIndex = GLReportTemplateColumn.ColumnIndex
			Me.Type = GLReportTemplateColumn.Type
			Me.DataType = GLReportTemplateColumn.DataType
			Me.PreviousYears = GLReportTemplateColumn.PreviousYears
			Me.PeriodOption = GLReportTemplateColumn.PeriodOption
			Me.IsVisible = GLReportTemplateColumn.IsVisible
			Me.Expression = GLReportTemplateColumn.Expression
			Me.UnderlineColumnHeaders = GLReportTemplateColumn.UnderlineColumnHeaders
			Me.UseCurrencyFormat = GLReportTemplateColumn.UseCurrencyFormat
			Me.NumberOfDecimalPlaces = GLReportTemplateColumn.NumberOfDecimalPlaces
			Me.Column1Name = GLReportTemplateColumn.Column1Name
			Me.Column2Name = GLReportTemplateColumn.Column2Name
			Me.PctOfRowColumnName = GLReportTemplateColumn.PctOfRowColumnName
			Me.OfficeCode = GLReportTemplateColumn.OfficeCode
			Me.OverrideDataOptions = GLReportTemplateColumn.OverrideDataOptions
			Me.DataOption = GLReportTemplateColumn.DataOption
			Me.DataCalculation = GLReportTemplateColumn.DataCalculation
			Me.CreatedByUserCode = GLReportTemplateColumn.CreatedByUserCode
			Me.CreatedDate = GLReportTemplateColumn.CreatedDate
			Me.ModifiedByUserCode = GLReportTemplateColumn.ModifiedByUserCode
			Me.ModifiedDate = GLReportTemplateColumn.ModifiedDate

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplateColumn

			'objects
			Dim GLReportTemplateColumn As Database.Entities.GLReportTemplateColumn = Nothing

			GLReportTemplateColumn = New Database.Entities.GLReportTemplateColumn

			GLReportTemplateColumn.ID = Me.ID
			GLReportTemplateColumn.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplateColumn.Description = Me.Description
			GLReportTemplateColumn.Name = Me.Name
			GLReportTemplateColumn.ColumnIndex = Me.ColumnIndex
			GLReportTemplateColumn.Type = Me.Type
			GLReportTemplateColumn.DataType = Me.DataType
			GLReportTemplateColumn.PreviousYears = Me.PreviousYears
			GLReportTemplateColumn.PeriodOption = Me.PeriodOption
			GLReportTemplateColumn.IsVisible = Me.IsVisible
			GLReportTemplateColumn.Expression = Me.Expression
			GLReportTemplateColumn.UnderlineColumnHeaders = Me.UnderlineColumnHeaders
			GLReportTemplateColumn.UseCurrencyFormat = Me.UseCurrencyFormat
			GLReportTemplateColumn.NumberOfDecimalPlaces = Me.NumberOfDecimalPlaces
			GLReportTemplateColumn.Column1Name = Me.Column1Name
			GLReportTemplateColumn.Column2Name = Me.Column2Name
			GLReportTemplateColumn.PctOfRowColumnName = Me.PctOfRowColumnName
			GLReportTemplateColumn.OfficeCode = Me.OfficeCode
			GLReportTemplateColumn.OverrideDataOptions = Me.OverrideDataOptions
			GLReportTemplateColumn.DataOption = Me.DataOption
			GLReportTemplateColumn.DataCalculation = Me.DataCalculation
			GLReportTemplateColumn.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplateColumn.CreatedDate = Me.CreatedDate
			GLReportTemplateColumn.ModifiedByUserCode = Me.ModifiedByUserCode
			GLReportTemplateColumn.ModifiedDate = Me.ModifiedDate

			CreateEntity = GLReportTemplateColumn

		End Function

#End Region

	End Class

End Namespace
