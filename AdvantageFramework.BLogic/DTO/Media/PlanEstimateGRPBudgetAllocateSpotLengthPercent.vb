Namespace DTO.Media

    Public Class PlanEstimateGRPBudgetAllocateSpotLengthPercent
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SpotLength
            Percent
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SpotLength As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=100, DisplayFormat:="n2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(5, 2)>
        Public Property Percent As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BudgetAmount As Decimal

#End Region

#Region " Methods "

        Public Sub New(SpotLength As Short, Percent As Decimal)

            Me.SpotLength = SpotLength
            Me.Percent = Percent
            Me.BudgetAmount = 0

        End Sub

#End Region

    End Class

End Namespace
