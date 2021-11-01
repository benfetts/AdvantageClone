Namespace Database.Entities

    <Table("EMP_TIME_DTL")>
    Public Class EmployeeTimeDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            JobNumber
            JobComponentNumber
            FunctionCode
            Hours
            BillableRate
            CostRate
            DepartmentTeamCode
            SalesTaxCode
            SalesTaxStatePercentage
            SalesTaxCountyPercentage
            SalesTaxCityPercentage
            SalesTaxResale
            TaxCommission
            TaxCommissionOnly
            CommissionPercentage
            IsNonBillable
            ARInvoiceNumber
            ARSequenceNumber
            ARType
            EnteredDate
            Comment
            IsBillOnHold
            UserCode
            BillingUserCode
            IsAdvancedBill
            TotalCostAmount
            TotalBilledAmount
            MarkupAmount
            StateResaleAmount
            CountyResaleAmount
            CityResaleAmount
            TotalAmount
            PostPeriodCode
            HasBeenEdited
            AdvancedBillID
            Notes
            FeeTimeType
            IsReconciled
            ReconciledDate
            ReconciledUserCode
            EmployeeTitleID
            AlternateCostRate
            AlternateCostAmount
            AdjusterComments
            EmployeeRateFrom
            TransferFromJobNumber
            TransferFromJobComponentNumber
            TransferFromFunctionCode
            TransferFromEmployeeTimeID
            TransferFromSequenceNumber
            TransferAdjustmentUserCode
            TransferAdjustmentDate
            BillingApprovalID
            BillingCommandCenterID
            TaskCode
            TaskCodeSequenceNumber
            AdjustmentUserCode
            AdjustmentDate
            AlertID
            DepartmentTeam
            EmployeeTime
            [Function]
            JobComponent
            SalesTax
            EmployeeTitle
            Task
            ProductCategoryCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ET_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeID() As Integer
        <Required>
        <Column("ET_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeDetailID() As Short
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Short
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 2)>
        <Column("EMP_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Decimal
        <Column("EMP_BILL_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        Public Property BillableRate() As Nullable(Of Decimal)
        <Column("EMP_COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        Public Property CostRate() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCode() As String
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxStatePercentage() As Nullable(Of Decimal)
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCountyPercentage() As Nullable(Of Decimal)
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCityPercentage() As Nullable(Of Decimal)
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxResale() As Nullable(Of Short)
        <Column("TAX_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommission() As Nullable(Of Short)
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
        <Column("EMP_COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercentage() As Nullable(Of Decimal)
        <Column("EMP_NON_BILL_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNonBillable() As Nullable(Of Short)
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <Column("DATE_ENTERED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnteredDate() As Nullable(Of Date)
		<Column("EMP_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<Column("BILL_HOLD_FLG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsBillOnHold() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(100)>
		<Column("BILLING_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingUserCode() As String
		<Column("AB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAdvancedBill() As Nullable(Of Short)
		<Column("TOTAL_COST")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalCostAmount() As Nullable(Of Decimal)
		<Column("TOTAL_BILL")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalBilledAmount() As Nullable(Of Decimal)
		<Column("EXT_MARKUP_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarkupAmount() As Nullable(Of Decimal)
		<Column("EXT_STATE_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StateResaleAmount() As Nullable(Of Decimal)
		<Column("EXT_COUNTY_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CountyResaleAmount() As Nullable(Of Decimal)
		<Column("EXT_CITY_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CityResaleAmount() As Nullable(Of Decimal)
		<Column("LINE_TOTAL")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalAmount() As Nullable(Of Decimal)
		<MaxLength(8)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Column("EDIT_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasBeenEdited() As Nullable(Of Short)
		<Column("AB_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdvancedBillID() As Nullable(Of Integer)
		<MaxLength(254)>
		<Column("EMP_NOTES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Notes() As String
		<Column("FEE_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FeeTimeType() As Nullable(Of Short)
		<Column("FEE_REC_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Nullable(Of Short)
		<Column("FEE_REC_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconciledDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("FEE_REC_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconciledUserCode() As String
		<Column("EMPLOYEE_TITLE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTitleID() As Nullable(Of Integer)
		<Column("ALT_COST_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateCostRate() As Nullable(Of Decimal)
		<Column("ALT_COST_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateCostAmount() As Nullable(Of Decimal)
		<Column("ADJ_COMMENTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjusterComments() As String
        <MaxLength(254)>
        <Column("EMP_RATE_FROM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeRateFrom() As String
        <Column("XFER_FROM_JOB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromJobNumber() As Nullable(Of Integer)
        <Column("XFER_FROM_JOB_COMP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromJobComponentNumber() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("XFER_FROM_FNC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromFunctionCode() As String
        <Column("XFER_FROM_ET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromEmployeeTimeID() As Nullable(Of Integer)
        <Column("XFER_FROM_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromSequenceNumber() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("XFER_ADJ_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustmentUserCode() As String
        <Column("XFER_ADJ_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustmentDate() As Nullable(Of Date)
        <Column("BA_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalID() As Nullable(Of Integer)
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <MaxLength(10)>
        <Column("TRF_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCode() As String
        <Column("TRF_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCodeSequenceNumber() As Nullable(Of Short)
        <Column("ADJ_USER", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjustmentUserCode() As String
        <Column("ADJ_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjustmentDate() As Nullable(Of Date)
        <Column("ALERT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Nullable(Of Integer)
        <MaxLength(10)>
        <Column("PROD_CAT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCategoryCode() As String

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property EmployeeTime As Database.Entities.EmployeeTime
        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        Public Overridable Property EmployeeTitle As Database.Entities.EmployeeTitle
        Public Overridable Property Task As Database.Entities.Task

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeID

        End Function
        Public Overrides Function DuplicateEntity() As AdvantageFramework.BaseClasses.Entity

            Dim Entity As Database.Entities.EmployeeTimeDetail = Nothing

            Entity = MyBase.DuplicateEntity()

            Entity.EmployeeTimeID = Me.EmployeeTimeID
            Entity.SequenceNumber = Me.SequenceNumber

            DuplicateEntity = Entity

        End Function
        'Public Function Copy() As AdvantageFramework.Database.Entities.EmployeeTimeDetail

        '    Dim EmployeeTimeDetailReversal As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing

        '    EmployeeTimeDetailReversal = New AdvantageFramework.Database.Entities.EmployeeTimeDetail

        '    With EmployeeTimeDetailReversal
        '        .EmployeeTimeID = Me.EmployeeTimeID
        '        .EmployeeTimeDetailID = Me.EmployeeTimeDetailID
        '        .SequenceNumber = Me.SequenceNumber
        '        .JobNumber = Me.JobNumber
        '        .JobComponentNumber = Me.JobComponentNumber
        '        .FunctionCode = Me.FunctionCode
        '        .Hours = Me.Hours
        '        .BillableRate = Me.BillableRate
        '        .CostRate = Me.CostRate
        '        .DepartmentTeamCode = Me.DepartmentTeamCode
        '        .SalesTaxCode = Me.SalesTaxCode
        '        .SalesTaxStatePercentage = Me.SalesTaxStatePercentage
        '        .SalesTaxCountyPercentage = Me.SalesTaxCountyPercentage
        '        .SalesTaxCityPercentage = Me.SalesTaxCityPercentage
        '        .SalesTaxResale = Me.SalesTaxResale
        '        .TaxCommission = Me.TaxCommission
        '        .TaxCommissionOnly = Me.TaxCommissionOnly
        '        .CommissionPercentage = Me.CommissionPercentage
        '        .IsNonBillable = Me.IsNonBillable
        '        .ARInvoiceNumber = Me.ARInvoiceNumber
        '        .ARSequenceNumber = Me.ARSequenceNumber
        '        .ARType = Me.ARType
        '        .EnteredDate = Me.EnteredDate
        '        .Comment = Me.Comment
        '        .IsBillOnHold = Me.IsBillOnHold
        '        .UserCode = Me.UserCode
        '        .BillingUserCode = Me.BillingUserCode
        '        .IsAdvancedBill = Me.IsAdvancedBill
        '        .TotalCostAmount = Me.TotalCostAmount
        '        .TotalBilledAmount = Me.TotalBilledAmount
        '        .MarkupAmount = Me.MarkupAmount
        '        .StateResaleAmount = Me.StateResaleAmount
        '        .CountyResaleAmount = Me.CountyResaleAmount
        '        .CityResaleAmount = Me.CityResaleAmount
        '        .TotalAmount = Me.TotalAmount
        '        .PostPeriodCode = Me.PostPeriodCode
        '        .HasBeenEdited = Me.HasBeenEdited
        '        .AdvancedBillID = Me.AdvancedBillID
        '        .Notes = Me.Notes
        '        .FeeTimeType = Me.FeeTimeType
        '        .IsReconciled = Me.IsReconciled
        '        .ReconciledDate = Me.ReconciledDate
        '        .ReconciledUserCode = Me.ReconciledUserCode
        '        .EmployeeTitleID = Me.EmployeeTitleID
        '        .AlternateCostRate = Me.AlternateCostRate
        '        .AlternateCostAmount = Me.AlternateCostAmount
        '        .AdjusterComments = Me.AdjusterComments
        '        .EmployeeRateFrom = Me.EmployeeRateFrom
        '        .TransferFromJobNumber = Me.TransferFromJobNumber
        '        .TransferFromJobComponentNumber = Me.TransferFromJobComponentNumber
        '        .TransferFromFunctionCode = Me.TransferFromFunctionCode
        '        .TransferFromEmployeeTimeID = Me.TransferFromEmployeeTimeID
        '        .TransferFromSequenceNumber = Me.TransferFromSequenceNumber
        '        .TransferAdjustmentUserCode = Me.TransferAdjustmentUserCode
        '        .TransferAdjustmentDate = Me.TransferAdjustmentDate
        '        .BillingApprovalID = Me.BillingApprovalID
        '        .BillingCommandCenterID = Me.BillingCommandCenterID
        '    End With

        '    Copy = EmployeeTimeDetailReversal

        'End Function

#End Region

    End Class

End Namespace
