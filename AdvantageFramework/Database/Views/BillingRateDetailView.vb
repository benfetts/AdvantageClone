Namespace Database.Views

    <Table("BILLING_RATE_VIEW")>
    Public Class BillingRateDetailView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Number
            Description
            ClientCode
            DivisionCode
            ProductCode
            SalesClassCode
            EmployeeTitleID
            EmployeeCode
            FunctionCode
            FunctionType
            EffectiveDate
            BillingRate
            IsNonBillable
            IsCommission
            TaxCommissionFlags
            IsTaxCommission
            IsTaxCommissionOnly
            TaxFlag
            TaxCode
            IsFeeTime
            IsInactive
            BillingRateLevelID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("BILLING_RATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("PRECEDENCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order")>
        Public Property Number() As Integer
        <MaxLength(254)>
        <Column("LEVEL_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <MaxLength(6)>
        <Column("SC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
        <Column("EMPLOYEE_TITLE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Title", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeTitleID)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode() As String
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
        <MaxLength(1)>
        <Column("FNC_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function Type")>
        Public Property FunctionType() As String
        <Column("EFFECTIVE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EffectiveDate() As Nullable(Of Date)
        <Column("BILLING_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingRate() As Nullable(Of Decimal)
        <Column("NOBILL_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable")>
        Public Property IsNonBillable() As Nullable(Of Short)
        <Column("COMMISSION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Markup Pct")>
        Public Property IsCommission() As Nullable(Of Decimal)
        <Column("TAX_COMM_FLAGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissionFlags() As Nullable(Of Short)
        <Column("TAX_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission")>
        Public Property IsTaxCommission() As Nullable(Of Short)
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Commission Only")>
        Public Property IsTaxCommissionOnly() As Nullable(Of Short)
        <Column("TAX_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxFlag() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode() As String
        <Column("FEE_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Fee Time")>
        Public Property IsFeeTime() As Nullable(Of Short)
        <Required>
        <Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Short
        <Required>
        <Column("BILL_RATE_PREC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BillingRateLevelID() As Short


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
