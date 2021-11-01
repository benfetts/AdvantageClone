Namespace Database.Classes

	Public Class GLReportTemplateRowXML

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			Description
			BalanceType
			DisplayType
			LinkType
			AccountType
			GLACode
			GLACodeRangeStart
			GLACodeRangeTo
			Wildcard
			AccountGroupCode
			RowIndex
			Type
			TotalType
			UseBaseAccountCodes
			IndentSpaces
			UnderlineAmount
			IsBold
			UseCurrencyFormat
			SuppressIfAllZeros
			NumberOfDecimalPlaces
			RollUp
			DataOption
			DataCalculation
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			DoubleUnderlineAmount
			IsVisible
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID() As Integer
		Public Property GLReportTemplateID() As Integer
		Public Property Description() As String
		Public Property BalanceType() As Integer
		Public Property DisplayType() As Integer
		Public Property LinkType() As Integer
		Public Property AccountType() As Nullable(Of Integer)
		Public Property GLACode() As String
		Public Property GLACodeRangeStart() As String
		Public Property GLACodeRangeTo() As String
		Public Property Wildcard() As String
		Public Property AccountGroupCode() As String
		Public Property RowIndex() As Integer
		Public Property Type() As Integer
		Public Property TotalType() As Integer
		Public Property UseBaseAccountCodes() As Boolean
		Public Property IndentSpaces() As Integer
		Public Property UnderlineAmount() As Boolean
		Public Property IsBold() As Boolean
		Public Property UseCurrencyFormat() As Boolean
		Public Property SuppressIfAllZeros() As Boolean
		Public Property NumberOfDecimalPlaces() As Integer
		Public Property RollUp() As Boolean
		Public Property DataOption() As Integer
		Public Property DataCalculation() As Integer
		Public Property CreatedByUserCode() As String
		Public Property CreatedDate() As Date
		Public Property ModifiedByUserCode() As String
		Public Property ModifiedDate() As Nullable(Of Date)
		Public Property DoubleUnderlineAmount() As Boolean
		Public Property IsVisible() As Boolean

#End Region

#Region " Methods "

		Public Sub New()

            Me.IsVisible = True

        End Sub
		Public Sub New(GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow)

			Me.ID = GLReportTemplateRow.ID
			Me.GLReportTemplateID = GLReportTemplateRow.GLReportTemplateID
			Me.Description = GLReportTemplateRow.Description
			Me.BalanceType = GLReportTemplateRow.BalanceType
			Me.DisplayType = GLReportTemplateRow.DisplayType
			Me.LinkType = GLReportTemplateRow.LinkType
			Me.AccountType = GLReportTemplateRow.AccountType
			Me.GLACode = GLReportTemplateRow.GLACode
			Me.GLACodeRangeStart = GLReportTemplateRow.GLACodeRangeStart
			Me.GLACodeRangeTo = GLReportTemplateRow.GLACodeRangeTo
			Me.Wildcard = GLReportTemplateRow.Wildcard
			Me.AccountGroupCode = GLReportTemplateRow.AccountGroupCode
			Me.RowIndex = GLReportTemplateRow.RowIndex
			Me.Type = GLReportTemplateRow.Type
			Me.TotalType = GLReportTemplateRow.TotalType
			Me.UseBaseAccountCodes = GLReportTemplateRow.UseBaseAccountCodes
			Me.IndentSpaces = GLReportTemplateRow.IndentSpaces
			Me.UnderlineAmount = GLReportTemplateRow.UnderlineAmount
			Me.IsBold = GLReportTemplateRow.IsBold
			Me.UseCurrencyFormat = GLReportTemplateRow.UseCurrencyFormat
			Me.SuppressIfAllZeros = GLReportTemplateRow.SuppressIfAllZeros
			Me.NumberOfDecimalPlaces = GLReportTemplateRow.NumberOfDecimalPlaces
			Me.RollUp = GLReportTemplateRow.RollUp
			Me.DataOption = GLReportTemplateRow.DataOption
			Me.DataCalculation = GLReportTemplateRow.DataCalculation
			Me.CreatedByUserCode = GLReportTemplateRow.CreatedByUserCode
			Me.CreatedDate = GLReportTemplateRow.CreatedDate
			Me.ModifiedByUserCode = GLReportTemplateRow.ModifiedByUserCode
			Me.ModifiedDate = GLReportTemplateRow.ModifiedDate
			Me.DoubleUnderlineAmount = GLReportTemplateRow.DoubleUnderlineAmount
			Me.IsVisible = GLReportTemplateRow.IsVisible

		End Sub
		Public Function CreateEntity() As Database.Entities.GLReportTemplateRow

			'objects
			Dim GLReportTemplateRow As Database.Entities.GLReportTemplateRow = Nothing

			GLReportTemplateRow = New Database.Entities.GLReportTemplateRow

			GLReportTemplateRow.ID = Me.ID
			GLReportTemplateRow.GLReportTemplateID = Me.GLReportTemplateID
			GLReportTemplateRow.Description = Me.Description
			GLReportTemplateRow.BalanceType = Me.BalanceType
			GLReportTemplateRow.DisplayType = Me.DisplayType
			GLReportTemplateRow.LinkType = Me.LinkType
			GLReportTemplateRow.AccountType = Me.AccountType
			GLReportTemplateRow.GLACode = Me.GLACode
			GLReportTemplateRow.GLACodeRangeStart = Me.GLACodeRangeStart
			GLReportTemplateRow.GLACodeRangeTo = Me.GLACodeRangeTo
			GLReportTemplateRow.Wildcard = Me.Wildcard
			GLReportTemplateRow.AccountGroupCode = Me.AccountGroupCode
			GLReportTemplateRow.RowIndex = Me.RowIndex
			GLReportTemplateRow.Type = Me.Type
			GLReportTemplateRow.TotalType = Me.TotalType
			GLReportTemplateRow.UseBaseAccountCodes = Me.UseBaseAccountCodes
			GLReportTemplateRow.IndentSpaces = Me.IndentSpaces
			GLReportTemplateRow.UnderlineAmount = Me.UnderlineAmount
			GLReportTemplateRow.IsBold = Me.IsBold
			GLReportTemplateRow.UseCurrencyFormat = Me.UseCurrencyFormat
			GLReportTemplateRow.SuppressIfAllZeros = Me.SuppressIfAllZeros
			GLReportTemplateRow.NumberOfDecimalPlaces = Me.NumberOfDecimalPlaces
			GLReportTemplateRow.RollUp = Me.RollUp
			GLReportTemplateRow.DataOption = Me.DataOption
			GLReportTemplateRow.DataCalculation = Me.DataCalculation
			GLReportTemplateRow.CreatedByUserCode = Me.CreatedByUserCode
			GLReportTemplateRow.CreatedDate = Me.CreatedDate
			GLReportTemplateRow.ModifiedByUserCode = Me.ModifiedByUserCode
			GLReportTemplateRow.ModifiedDate = Me.ModifiedDate
			GLReportTemplateRow.DoubleUnderlineAmount = Me.DoubleUnderlineAmount
			GLReportTemplateRow.IsVisible = Me.IsVisible

			CreateEntity = GLReportTemplateRow

		End Function

#End Region

	End Class

End Namespace
