Namespace Database.Classes

    <Serializable()>
    Public Class EstimateTask

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            EstimateFunctionCode
            DefaultRole
            EmployeeCode
            EmployeeName
            EstimateRevisionRate
            EstimateRevisionExtendedAmount
            ExtendedMarkupAmount
            ExtendedContingency
            IncludeCPU
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxCommissionOnly
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            ExtendedMarkupContingency
            FunctionType
            EstimatePhaseDescription
            FunctionHeadingID
            FunctionConsolidation
            FunctionConsolodationDescription
            EmployeeTitle
            TaskCode
            TaskDescription
            TaskOrder
            DaysToComplete
            HoursAllowed
            IsMilestone
            DefaultStatus
            FunctionDescription
            EstimateFunctionComment
            EstimateRevisionSuppliedByCode
            EstimateRevisionQuantity
            TaxCode
            EstimateRevisionCommissionPercent
            LineTotal
            EstimateRevisionContingencyPercent
            TaxCommission
            TaxReslae
            ExtendedNonresaleTax
            ExtendedStateContingency
            ExtendedCountyContingency
            ExtendedCityContingency
            ExtendedNonresaleContingency
            LineTotalContingency
            EstimateCPMFlag
            EstimateFunctionType
            EstimateCommissionFlag
            EstimateTaxFlag
            EstimateNonbillFlag
            FeeTime
            EmployeeTitleID
            EstimatePhaseID
            FunctionHeadingDescription
            FunctionHeadingSequence
            SalesTaxStatePercent
            SalesTaxCountyPercent
            SalesTaxCityPercent
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultRole() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionExtendedAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IncludeCPU() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxStatePercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommissionOnly() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateResale() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyResale() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityResale() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionType() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimatePhaseDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionConsolidation() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionConsolodationDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitle() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TaskCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TaskDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskOrder() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DaysToComplete() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HoursAllowed() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsMilestone() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultStatus() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionComment() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionSuppliedByCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionQuantity() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionCommissionPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotal() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionContingencyPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommission() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxReslae() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedNonresaleTax() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedNonresaleContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotalContingency() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateCPMFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionType() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateCommissionFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateTaxFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateNonbillFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FeeTime() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimatePhaseID() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingSequence() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxStatePercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxCountyPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxCityPercent() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FunctionCode.ToString

        End Function

#End Region

    End Class

End Namespace
