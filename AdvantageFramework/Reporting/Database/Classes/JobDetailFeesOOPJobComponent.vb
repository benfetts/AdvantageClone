Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobDetailFeesOOPJobComponent

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            UserCode
            JobCreateDate
            JobDescription
            JobDateOpened
            Comment
            ClientReference
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            JobOpen
            JobComponent
            ComponentBudget
            AccountExecutiveCode
            AccountExecutive
            Manager
            DueDate
            StartDate
            Status
            GutPercentComplete
            DepartmentTeamCode
            DepartmentTeam
            JobProcessControl
            ComponentDescription
            EstimateNumber
            EstimateComponentNumber
            ClientPO
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            FiscalPeriodDescription
            JobTypeCode
            JobTypeDescription
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            FeeEstimate
            OOPEstimate
            EstimateTotal
            BillableFeeTotal
            BillableOOPTotal
            BillableTotal
            BillableFeeVariance
            BillableOOPVariance
            BillableVariance
            PercentOfTotalEstimate
            FeeBilled
            OOPBilled
            BilledTotal
            AdvanceBilledBalance
            FeeUnbilled
            OOPUnbilled
            UnbilledTotal
            NonBillableFee
            NonBillableOOP
            BillableAndNonBillableFeeTotal
            BillableAndNonBillableVariance
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        Public Property JobNumber() As Nullable(Of Integer)
        Public Property JobComponentNumber() As Nullable(Of Short)
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientDescription() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionDescription() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        Public Property CampaignID As Nullable(Of Integer)
        <MaxLength(6)>
        Public Property CampaignCode As String
        <MaxLength(40)>
        Public Property CampaignName As String
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(30)>
        Public Property SalesClassDescription As String
        <MaxLength(100)>
        Public Property UserCode As String
        Public Property JobCreateDate As Nullable(Of Date)
        <MaxLength(60)>
        Public Property JobDescription As String
        Public Property JobDateOpened As Nullable(Of Date)
        Public Property Comment As String
        <MaxLength(30)>
        Public Property ClientReference As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable5 As String
        <MaxLength(3)>
        Public Property JobOpen As String
        <MaxLength(20)>
        Public Property JobComponent As String
        Public Property ComponentBudget As Nullable(Of Decimal)
        <MaxLength(6)>
        Public Property AccountExecutiveCode As String
        <MaxLength(100)>
        Public Property AccountExecutive As String
        <MaxLength(100)>
        Public Property Manager As String
        Public Property DueDate As Nullable(Of Date)
        Public Property StartDate As Nullable(Of Date)
        <MaxLength(30)>
        Public Property Status As String
        Public Property GutPercentComplete As Nullable(Of Decimal)
        <MaxLength(4)>
        Public Property DepartmentTeamCode As String
        <MaxLength(30)>
        Public Property DepartmentTeam As String
        <MaxLength(40)>
        Public Property JobProcessControl As String
        <MaxLength(60)>
        Public Property ComponentDescription As String
        Public Property EstimateNumber As Nullable(Of Integer)
        Public Property EstimateComponentNumber As Nullable(Of Short)
        <MaxLength(40)>
        Public Property ClientPO As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable5 As String
        <MaxLength(30)>
        Public Property FiscalPeriodDescription As String
        Public Property JobTypeCode As String
        Public Property JobTypeDescription As String
        <MaxLength(50)>
        Public Property ProductUDF1 As String
        <MaxLength(50)>
        Public Property ProductUDF2 As String
        <MaxLength(50)>
        Public Property ProductUDF3 As String
        <MaxLength(50)>
        Public Property ProductUDF4 As String
        Public Property FeeEstimate As Nullable(Of Decimal)
        Public Property OOPEstimate As Nullable(Of Decimal)
        Public Property EstimateTotal As Nullable(Of Decimal)
        Public Property BillableFeeTotal As Nullable(Of Decimal)
        Public Property BillableOOPTotal As Nullable(Of Decimal)
        Public Property BillableTotal As Nullable(Of Decimal)
        Public Property BillableFeeVariance As Nullable(Of Decimal)
        Public Property BillableOOPVariance As Nullable(Of Decimal)
        Public Property BillableVariance As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PercentOfTotalEstimate As Nullable(Of Decimal)
        Public Property FeeBilled As Nullable(Of Decimal)
        Public Property OOPBilled As Nullable(Of Decimal)
        Public Property BilledTotal As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Advance Billed Total")>
        Public Property AdvanceBilledBalance As Nullable(Of Decimal)
        Public Property FeeUnbilled As Nullable(Of Decimal)
        Public Property OOPUnbilled As Nullable(Of Decimal)
        Public Property UnbilledTotal As Nullable(Of Decimal)
        Public Property NonBillableFee As Nullable(Of Decimal)
        Public Property NonBillableOOP As Nullable(Of Decimal)
        Public Property BillableAndNonBillableFeeTotal As Nullable(Of Decimal)
        Public Property BillableAndNonBillableVariance As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
