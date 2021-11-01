Namespace Database.Entities

    <Table("FUNCTIONS")>
    Public Class [Function]
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Type
            IsInactive
            DepartmentTeamCode
            NonBillableClientGLACode
            OverheadGLACode
            FunctionHeadingID
            LineConsolidation
            CPMFlag
            FunctionOrder
            CommissionFlag
            TaxFlag
            TaxCommissionFlag
            TaxCommissionOnlyFlag
            NonBillableFlag
            EmployeeExpenseFlag
            BillingRate
            FeeFlag
            FeeReconcile
            VATTaxCode
            Tasks
            EmployeeNonTasks
            EstimateRevisionDetails
            BillingRateDetails
            DepartmentTeam
            JobComponentTasks
            Vendors
            NonBillableGeneralLedgerAccount
            OverheadGeneralLedgerAccount
            FunctionHeading
            EmployeeTimeDetails
            Employees
            OfficeFunctionAccounts
            OfficeSalesClassFunctionAccounts
            AccountPayableProduction
            PurchaseOrderDetails
            EmployeeTimesheetFunctions
            IncomeOnlys
            JobServiceFees

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(30)>
        <Column("FNC_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(1)>
        <Column("FNC_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Type() As String
        <Column("FNC_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Department / Team", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
        <MaxLength(30)>
        <Column("NONBILL_CLI_GLACCT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable Client Account", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property NonBillableClientGLACode() As String
        <MaxLength(30)>
        <Column("OVERHEAD_GLACCT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Overhead Account", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property OverheadGLACode() As String
        <Column("FNC_HEADING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Heading Description", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionHeadingID)>
        Public Property FunctionHeadingID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("FNC_CONSOLIDATION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Consolidation Code", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
        Public Property LineConsolidation() As String
        <Column("FNC_CPM_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="CPM", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property CPMFlag() As Nullable(Of Short)
        <Column("FNC_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999)>
        Public Property FunctionOrder() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("FNC_COMM_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Commissionable")>
        Public Property CommissionFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("FNC_TAX_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Taxable")>
        Public Property TaxFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("TAX_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission")>
        Public Property TaxCommissionFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission Only")>
        Public Property TaxCommissionOnlyFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("FNC_NONBILL_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable")>
        Public Property NonBillableFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Column("EX_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Expense", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property EmployeeExpenseFlag() As Nullable(Of Short)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 3)>
        <Column("FNC_BILLING_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property BillingRate() As Nullable(Of Decimal)
        <Column("FNC_FEE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property FeeFlag() As Nullable(Of Short)
        <Column("FNC_FEE_RECONCILE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property FeeReconcile() As Nullable(Of Short)
        <MaxLength(20)>
        <Column("VAT_TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="VAT Tax Code")>
        Public Property VATTaxCode() As String

        Public Overridable Property Tasks As ICollection(Of Database.Entities.Task)
        Public Overridable Property EmployeeNonTasks As ICollection(Of Database.Entities.EmployeeNonTask)
        Public Overridable Property EstimateRevisionDetails As ICollection(Of Database.Entities.EstimateRevisionDetail)
        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property JobComponentTasks As ICollection(Of Database.Entities.JobComponentTask)
        Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)
        <ForeignKey("NonBillableClientGLACode")>
        Public Overridable Property NonBillableGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("OverheadGLACode")>
        Public Overridable Property OverheadGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property FunctionHeading As Database.Entities.FunctionHeading
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property Employees As ICollection(Of Database.Views.Employee)
        Public Overridable Property OfficeFunctionAccounts As ICollection(Of Database.Entities.OfficeFunctionAccount)
        Public Overridable Property OfficeSalesClassFunctionAccounts As ICollection(Of Database.Entities.OfficeSalesClassFunctionAccount)
        Public Overridable Property AccountPayableProduction As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property PurchaseOrderDetails As ICollection(Of Database.Entities.PurchaseOrderDetail)
        Public Overridable Property EmployeeTimesheetFunctions As ICollection(Of Database.Entities.EmployeeTimesheetFunction)
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)
        Public Overridable Property JobServiceFees As ICollection(Of Database.Entities.JobServiceFee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Function.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() = False AndAlso IsValid = False AndAlso Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                        ErrorText = ""
                        IsValid = True

                    End If

            End Select

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Function.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Functions
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique function code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
