Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class SetupFormDashboardDataSource
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MarketCode
			MarketDescription
			GoalQuantity
			GoalAmount
			Quantity
			Amount
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		Public Property MarketCode() As String
		<Required>
		Public Property MarketDescription() As String
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n2")>
        Public Property GRPGoal() As Decimal
        <Required>
		Public Property GoalAmount() As Decimal
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n2")>
        Public Property GRPEstimated() As Decimal
        <Required>
		Public Property Amount() As Decimal

#End Region

#Region " Methods "

		Public Sub New()

			Me.MarketCode = String.Empty
			Me.MarketDescription = String.Empty
            Me.GRPGoal = 0
            Me.GoalAmount = 0
            Me.GRPEstimated = 0
            Me.Amount = 0

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.MarketCode & " - " & Me.MarketDescription

		End Function

#End Region

	End Class

End Namespace
