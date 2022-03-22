Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MonthEndProductionWIP

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDesc
            ClientPO
            ClientReference
            AccountExecutive
            Status
            StatusCode
            SalesClass
            SalesClassDescription
            JobCompOpenDate
            JobCompFirstUseDate
            JobStartDate
            JobDueDate
            JobCompCloseDate
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            VendorCode
            VendorName
            APInvoiceNumber
            EstimateNetAmount
            EstimateAmount
            EstimateHours
            EstimateHoursAmount
            APTotal
            APDebit
            APCredit
            APType
            APPaymentFlag
            APPartialFlag
            APPaymentRef
            EmpUnbilledHours
            EmpUnbilledAmount
            IncomeOnlyUnbilled
            DeferredSales
            DefSaleRecognized
            DeferredCost
            DeferredCostRecognized
            AdvanceAccruedLiab
            OpenPurchaseOrderAmount
            PostPeriod
            AgingPeriod
            Current
            ThirtyDays
            SixtyDays
            NinetyDays
            OneHundredTwentyDays
            Over120Days
            TotalAging
            WIPCode
            APVoucherWIPBalanceFlag
            JobCompAPWIPBalanceFlag
            JobCompAgingWIPFlag
            JobCompAPAgingWIPFlag
            JobCompTotalWIPNoAdvCostFlag
            JobCompAgingWIPALPOFlag
            JobCompTotalAdvFlag
            JobCompPurchaseOrderOnlyFlag
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property CDPSortCode() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String

        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String

        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property JobComponentDesc As String

        Public Property ClientPO As String
        Public Property ClientReference As String
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>

        Public Property AccountExecutive As String
        Public Property Status As String
        Public Property StatusCode As String
        Public Property SalesClass As String
        Public Property SalesClassDescription As String

        Public Property JobCompOpenDate As Nullable(Of Date)
        Public Property JobCompFirstUseDate As Nullable(Of Date)
        Public Property JobStartDate As Nullable(Of Date)
        Public Property JobDueDate As Nullable(Of Date)
        Public Property JobCompCloseDate As Nullable(Of Date)
        Public Property LabelFromUDFTable1 As String
        Public Property LabelFromUDFTable2 As String
        Public Property LabelFromUDFTable3 As String
        Public Property LabelFromUDFTable4 As String
        Public Property LabelFromUDFTable5 As String

        <MaxLength(6)>
        Public Property VendorCode As String
        <MaxLength(40)>
        Public Property VendorName As String

        Public Property APInvoiceNumber As String

        Public Property EstimateNetAmount As Nullable(Of Decimal)
        Public Property EstimateAmount As Nullable(Of Decimal)
        Public Property EstimateHours As Nullable(Of Decimal)
        Public Property EstimateHoursAmount As Nullable(Of Decimal)
        Public Property APTotal As Nullable(Of Decimal)
        Public Property APDebit As Nullable(Of Decimal)
        Public Property APCredit As Nullable(Of Decimal)

        Public Property APType As String
        Public Property APPaymentFlag As String
        Public Property APPartialFlag As String
        Public Property APPaymentRef As String

        Public Property EmpUnbilledHours As Nullable(Of Decimal)
        Public Property EmpUnbilledAmount As Nullable(Of Decimal)
        Public Property IncomeOnlyUnbilled As Nullable(Of Decimal)
        Public Property DeferredSales As Nullable(Of Decimal)
        Public Property DefSaleRecognized As Nullable(Of Decimal)
        Public Property DeferredCost As Nullable(Of Decimal)
        Public Property DeferredCostRecognized As Nullable(Of Decimal)
        Public Property AdvanceAccruedLiab As Nullable(Of Decimal)
        Public Property OpenPurchaseOrderAmount As Nullable(Of Decimal)

        Public Property PostPeriod As String
        Public Property AgingPeriod As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Current", ShowColumnInGrid:=False)>
        Public Property Current As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Current")>
        Public Property ThirtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Over 30 Days")>
        Public Property SixtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Over 60 Days")>
        Public Property NinetyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Over 90 Days")>
        Public Property OneHundredTwentyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Over 120 Days")>
        Public Property Over120Days As Nullable(Of Decimal)

        Public Property TotalAging As Nullable(Of Decimal)

        Public Property WIPCode As String
        Public Property APVoucherWIPBalanceFlag As Nullable(Of Byte)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Comp AP WIP Balance Flag", ShowColumnInGrid:=False)>
        Public Property JobCompAPWIPBalanceFlag As Nullable(Of Byte)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property JobCompAgingWIPFlag As Nullable(Of Byte)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property JobCompAPAgingWIPFlag As Nullable(Of Byte)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Comp Total WIP No Adv Cost Flag", ShowColumnInGrid:=False)>
        Public Property JobCompTotalWIPNoAdvCostFlag As Nullable(Of Byte)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Comp Total WIP AL PO Flag", ShowColumnInGrid:=False)>
        Public Property JobCompAgingWIPALPOFlag As Nullable(Of Byte)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Comp Total Adv Flag", ShowColumnInGrid:=False)>
        Public Property JobCompTotalAdvFlag As Nullable(Of Byte)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Job Comp PO Only Flag", ShowColumnInGrid:=False)>
        Public Property JobCompPurchaseOrderOnlyFlag As Nullable(Of Byte)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
