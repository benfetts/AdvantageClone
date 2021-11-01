Namespace Database.Entities

    <Table("GLCONFIG")>
    Public Class GeneralLedgerConfig
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FiscalYearStartMonth
            PostingPeriodFormat
            PostingPeriodYear
            Segment1Format
            Segment1Type
            Segment1Description
            Segment1After
            Segment2Format
            Segment2Type
            Segment2Description
            Segment2After
            Segment3Format
            Segment3Type
            Segment3Description
            Segment3After
            Segment4Format
            Segment4Type
            Segment4Description
            BudgetIncludeYearEnd
            BudgetLastYearActual
            BudgetLastYearVariance
            BudgetYTD
            BudgetEXT
            BudgetEXTVAR
            BudgetAssets
            BudgetLiabilities
            BudgetIncome
            BudgetExpense
            BudgetAssetsCurrent
            BudgetAssetsFixed
            BudgetLiabilitiesCurrent
            BudgetIncomeOther
            BudgetExpenseCOS
            BudgetExpenseOperating
            BudgetExpenseOther
            BudgetExpenseTaxes
            SuppressFinancialStatements
            UseControlAmounts
            CurrencySymbol
            UseComma
            DefaultCountry
            Use1000
            BudgetClient
            RPTHeading

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("FISCALMTH")>
        Public Property FiscalYearStartMonth() As Nullable(Of Short)

        <Column("PP_FORMAT")>
        Public Property PostingPeriodFormat() As Nullable(Of Short)

        <Column("PP_YEAR")>
        Public Property PostingPeriodYear() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT1_FORMAT", TypeName:="varchar")>
        Public Property Segment1Format() As String

        <Column("SEGMENT1_TYPE")>
        Public Property Segment1Type() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT1_DESC", TypeName:="varchar")>
        Public Property Segment1Description() As String

        <Column("SEGMENT1_AFTER")>
        Public Property Segment1After() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT2_FORMAT", TypeName:="varchar")>
        Public Property Segment2Format() As String

        <Column("SEGMENT2_TYPE")>
        Public Property Segment2Type() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT2_DESC", TypeName:="varchar")>
        Public Property Segment2Description() As String

        <Column("SEGMENT2_AFTER")>
        Public Property Segment2After() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT3_FORMAT", TypeName:="varchar")>
        Public Property Segment3Format() As String

        <Column("SEGMENT3_TYPE")>
        Public Property Segment3Type() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT3_DESC", TypeName:="varchar")>
        Public Property Segment3Description() As String

        <Column("SEGMENT3_AFTER")>
        Public Property Segment3After() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT4_FORMAT", TypeName:="varchar")>
        Public Property Segment4Format() As String

        <Column("SEGMENT4_TYPE")>
        Public Property Segment4Type() As Nullable(Of Short)

        <MaxLength(30)>
        <Column("SEGMENT4_DESC", TypeName:="varchar")>
        Public Property Segment4Description() As String

        <Column("BDGT_INCLUDE_YE")>
        Public Property BudgetIncludeYearEnd() As Nullable(Of Short)

        <Column("BDGT_LYACT_COL")>
        Public Property BudgetLastYearActual() As Nullable(Of Short)

        <Column("BDGT_LYVAR_COL")>
        Public Property BudgetLastYearVariance() As Nullable(Of Short)

        <Column("BDGT_YTD_COL")>
        Public Property BudgetYTD() As Nullable(Of Short)

        <Column("BDGT_EXT_COL")>
        Public Property BudgetEXT() As Nullable(Of Short)

        <Column("BDGT_EXTVAR_COL")>
        Public Property BudgetEXTVAR() As Nullable(Of Short)

        <Column("BUDGET_ASSETS")>
        Public Property BudgetAssets() As Nullable(Of Short)

        <Column("BUDGET_LIABILITIES")>
        Public Property BudgetLiabilities() As Nullable(Of Short)

        <Column("BUDGET_INCOME")>
        Public Property BudgetIncome() As Nullable(Of Short)

        <Column("BUDGET_EXPENSE")>
        Public Property BudgetExpense() As Nullable(Of Short)

        <Column("BUDGET_ASSETS_CUR")>
        Public Property BudgetAssetsCurrent() As Nullable(Of Short)

        <Column("BUDGET_ASSETS_FIX")>
        Public Property BudgetAssetsFixed() As Nullable(Of Short)

        <Column("BUDGET_LIAB_CUR")>
        Public Property BudgetLiabilitiesCurrent() As Nullable(Of Short)

        <Column("BUDGET_INCOME_OTH")>
        Public Property BudgetIncomeOther() As Nullable(Of Short)

        <Column("BUDGET_EXPENSE_COS")>
        Public Property BudgetExpenseCOS() As Nullable(Of Short)

        <Column("BUDGET_EXPENSE_OPE")>
        Public Property BudgetExpenseOperating() As Nullable(Of Short)

        <Column("BUDGET_EXPENSE_OTH")>
        Public Property BudgetExpenseOther() As Nullable(Of Short)

        <Column("BUDGET_EXPENSE_TAX")>
        Public Property BudgetExpenseTaxes() As Nullable(Of Short)

        <Column("SUPPRESS_FS")>
        Public Property SuppressFinancialStatements() As Nullable(Of Short)

        <Column("USE_CONTROL_AMT")>
        Public Property UseControlAmounts() As Nullable(Of Short)

        <MaxLength(4)>
        <Column("CURRENCY_SYMBOL", TypeName:="varchar")>
        Public Property CurrencySymbol() As String

        <Column("USE_COMMA")>
        Public Property UseComma() As Nullable(Of Short)

        <MaxLength(40)>
        <Column("DEFAULT_COUNTRY", TypeName:="varchar")>
        Public Property DefaultCountry() As String

        <Column("USE_1000")>
        Public Property Use1000() As Nullable(Of Short)

        <Column("BDGT_CL_BDGT_COL")>
        Public Property BudgetClient() As Nullable(Of Short)

        <MaxLength(100)>
        <Column("RPT_HEADING", TypeName:="varchar")>
        Public Property RPTHeading() As String

        <Key>
        <Required>
        <Column("ID")>
        Public Property ID() As Integer

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
