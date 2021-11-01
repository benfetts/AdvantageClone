Namespace DTO.GeneralLedger.Maintenance

    Public Class GeneralLedgerConfiguration
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Segment1Format
            Segment2Format
            Segment3Format
            Segment4Format
            Segment1Type
            Segment2Type
            Segment3Type
            Segment4Type
            Segment1Description
            Segment2Description
            Segment3Description
            Segment4Description
            Segment1After
            Segment2After
            Segment3After

            FiscalYearStartMonth
            PostingPeriodFormat
            PostingPeriodYear
            CurrencySymbol
            BudgetLastYearActual
            BudgetLastYearVariance
            BudgetIncludeYearEnd
            BudgetYTD
            BudgetEXT
            BudgetEXTVAR
            BudgetClient
            SuppressFinancialStatements
            UseControlAmounts

            BudgetAssetsCurrent
            BudgetAssets
            BudgetAssetsFixed
            BudgetLiabilitiesCurrent
            BudgetLiabilities
            BudgetIncome
            BudgetIncomeOther
            BudgetExpenseCOS
            BudgetExpenseOperating
            BudgetExpenseOther
            BudgetExpenseTaxes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <MaxLength(30)>
        Public Property Segment1Format() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <MaxLength(30)>
        Public Property Segment2Format() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <MaxLength(30)>
        Public Property Segment3Format() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <MaxLength(30)>
        Public Property Segment4Format() As String

        Public Property Segment1Type() As System.Nullable(Of Short)
        Public Property Segment2Type() As System.Nullable(Of Short)
        Public Property Segment3Type() As System.Nullable(Of Short)
        Public Property Segment4Type() As System.Nullable(Of Short)

        <MaxLength(30)>
        Public Property Segment1Description() As String
        <MaxLength(30)>
        Public Property Segment2Description() As String
        <MaxLength(30)>
        Public Property Segment3Description() As String
        <MaxLength(30)>
        Public Property Segment4Description() As String

        Public Property Segment1After() As System.Nullable(Of Short)
        Public Property Segment2After() As System.Nullable(Of Short)
        Public Property Segment3After() As System.Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FiscalYearStartMonth As Integer
        Public Property PostingPeriodFormat As System.Nullable(Of Short)
        Public Property PostingPeriodYear As System.Nullable(Of Short)
        <MaxLength(4)>
        Public Property CurrencySymbol As String
        Public Property BudgetLastYearActual As System.Nullable(Of Short)
        Public Property BudgetLastYearVariance As System.Nullable(Of Short)
        Public Property BudgetIncludeYearEnd As System.Nullable(Of Short)
        Public Property BudgetYTD As System.Nullable(Of Short)
        Public Property BudgetEXT As System.Nullable(Of Short)
        Public Property BudgetEXTVAR As System.Nullable(Of Short)
        Public Property BudgetClient As System.Nullable(Of Short)
        Public Property SuppressFinancialStatements As System.Nullable(Of Short)
        Public Property UseControlAmounts As System.Nullable(Of Short)
        Public Property BudgetAssetsCurrent As System.Nullable(Of Short)
        Public Property BudgetAssets As System.Nullable(Of Short)
        Public Property BudgetAssetsFixed As System.Nullable(Of Short)
        Public Property BudgetLiabilitiesCurrent As System.Nullable(Of Short)
        Public Property BudgetLiabilities As System.Nullable(Of Short)
        Public Property BudgetIncome As System.Nullable(Of Short)
        Public Property BudgetIncomeOther As System.Nullable(Of Short)
        Public Property BudgetExpenseCOS As System.Nullable(Of Short)
        Public Property BudgetExpenseOperating As System.Nullable(Of Short)
        Public Property BudgetExpenseOther As System.Nullable(Of Short)
        Public Property BudgetExpenseTaxes As System.Nullable(Of Short)

        Public ReadOnly Property DefaultFormat As String
            Get
                Dim Format As String = Nothing

                Format = Me.Segment1Format

                If Me.Segment1After > 0 Then

                    Format += If(Me.Segment1After = 1, "-", "") & If(Me.Segment1After = 2, ".", "")

                    Format += Me.Segment2Format

                Else

                    Format += Me.Segment2Format

                End If

                If Me.Segment2After > 0 Then

                    Format += If(Me.Segment2After = 1, "-", "") & If(Me.Segment2After = 2, ".", "")

                    Format += Me.Segment3Format

                Else

                    Format += Me.Segment3Format

                End If

                If Me.Segment3After > 0 Then

                    Format += If(Me.Segment3After = 1, "-", "") & If(Me.Segment3After = 2, ".", "")

                    Format += Me.Segment4Format

                Else

                    Format += Me.Segment4Format

                End If

                DefaultFormat = Format

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            'no rows 
            Me.Segment1Format = String.Empty
            Me.Segment2Format = String.Empty
            Me.Segment3Format = String.Empty
            Me.Segment4Format = String.Empty

            Me.Segment1Type = 1
            Me.Segment2Type = 2
            Me.Segment3Type = 3
            Me.Segment4Type = 4

            Me.Segment1Description = String.Empty
            Me.Segment2Description = String.Empty
            Me.Segment3Description = String.Empty
            Me.Segment4Description = String.Empty

            Me.Segment1After = 0
            Me.Segment2After = 0
            Me.Segment3After = 0

            Me.FiscalYearStartMonth = 1
            Me.PostingPeriodFormat = 1
            Me.PostingPeriodYear = 0
            Me.CurrencySymbol = "$"

            Me.BudgetLastYearActual = 2
            Me.BudgetLastYearVariance = 3
            Me.BudgetIncludeYearEnd = 0
            Me.BudgetYTD = 1
            Me.BudgetEXT = 4
            Me.BudgetEXTVAR = 5
            Me.BudgetClient = 6
            Me.SuppressFinancialStatements = 0
            Me.UseControlAmounts = 0

            Me.BudgetAssetsCurrent = 0
            Me.BudgetAssets = 0
            Me.BudgetAssetsFixed = 0
            Me.BudgetLiabilitiesCurrent = 0
            Me.BudgetLiabilities = 0

            Me.BudgetIncome = 1
            Me.BudgetIncomeOther = 1
            Me.BudgetExpenseCOS = 1
            Me.BudgetExpenseOperating = 1
            Me.BudgetExpenseOther = 1
            Me.BudgetExpenseTaxes = 1

        End Sub
        Public Sub New(GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig)

            Me.Segment1Format = GeneralLedgerConfig.Segment1Format
            Me.Segment2Format = GeneralLedgerConfig.Segment2Format
            Me.Segment3Format = GeneralLedgerConfig.Segment3Format
            Me.Segment4Format = GeneralLedgerConfig.Segment4Format

            Me.Segment1Type = GeneralLedgerConfig.Segment1Type
            Me.Segment2Type = GeneralLedgerConfig.Segment2Type
            Me.Segment3Type = GeneralLedgerConfig.Segment3Type
            Me.Segment4Type = GeneralLedgerConfig.Segment4Type

            Me.Segment1Description = GeneralLedgerConfig.Segment1Description
            Me.Segment2Description = GeneralLedgerConfig.Segment2Description
            Me.Segment3Description = GeneralLedgerConfig.Segment3Description
            Me.Segment4Description = GeneralLedgerConfig.Segment4Description

            Me.Segment1After = GeneralLedgerConfig.Segment1After
            Me.Segment2After = GeneralLedgerConfig.Segment2After
            Me.Segment3After = GeneralLedgerConfig.Segment3After

            Me.FiscalYearStartMonth = GeneralLedgerConfig.FiscalYearStartMonth
            Me.PostingPeriodFormat = GeneralLedgerConfig.PostingPeriodFormat
            Me.PostingPeriodYear = GeneralLedgerConfig.PostingPeriodYear
            Me.CurrencySymbol = GeneralLedgerConfig.CurrencySymbol

            Me.BudgetLastYearActual = GeneralLedgerConfig.BudgetLastYearActual
            Me.BudgetLastYearVariance = GeneralLedgerConfig.BudgetLastYearVariance
            Me.BudgetYTD = GeneralLedgerConfig.BudgetYTD
            Me.BudgetEXT = GeneralLedgerConfig.BudgetEXT
            Me.BudgetEXTVAR = GeneralLedgerConfig.BudgetEXTVAR
            Me.BudgetClient = GeneralLedgerConfig.BudgetClient

            Me.BudgetIncludeYearEnd = GeneralLedgerConfig.BudgetIncludeYearEnd
            Me.SuppressFinancialStatements = GeneralLedgerConfig.SuppressFinancialStatements
            Me.UseControlAmounts = GeneralLedgerConfig.UseControlAmounts

            Me.BudgetAssetsCurrent = GeneralLedgerConfig.BudgetAssetsCurrent
            Me.BudgetAssets = GeneralLedgerConfig.BudgetAssets
            Me.BudgetAssetsFixed = GeneralLedgerConfig.BudgetAssetsFixed
            Me.BudgetLiabilitiesCurrent = GeneralLedgerConfig.BudgetLiabilitiesCurrent
            Me.BudgetLiabilities = GeneralLedgerConfig.BudgetLiabilities

            Me.BudgetIncome = GeneralLedgerConfig.BudgetIncome
            Me.BudgetIncomeOther = GeneralLedgerConfig.BudgetIncomeOther
            Me.BudgetExpenseCOS = GeneralLedgerConfig.BudgetExpenseCOS
            Me.BudgetExpenseOperating = GeneralLedgerConfig.BudgetExpenseOperating
            Me.BudgetExpenseOther = GeneralLedgerConfig.BudgetExpenseOther
            Me.BudgetExpenseTaxes = GeneralLedgerConfig.BudgetExpenseTaxes

        End Sub
        Public Sub SaveToEntity(ByRef GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig)

            GeneralLedgerConfig.Segment1Format = Me.Segment1Format
            GeneralLedgerConfig.Segment2Format = Me.Segment2Format
            GeneralLedgerConfig.Segment3Format = Me.Segment3Format
            GeneralLedgerConfig.Segment4Format = Me.Segment4Format

            GeneralLedgerConfig.Segment1Type = Me.Segment1Type
            GeneralLedgerConfig.Segment2Type = Me.Segment2Type
            GeneralLedgerConfig.Segment3Type = Me.Segment3Type
            GeneralLedgerConfig.Segment4Type = Me.Segment4Type

            GeneralLedgerConfig.Segment1Description = Me.Segment1Description
            GeneralLedgerConfig.Segment2Description = Me.Segment2Description
            GeneralLedgerConfig.Segment3Description = Me.Segment3Description
            GeneralLedgerConfig.Segment4Description = Me.Segment4Description

            GeneralLedgerConfig.Segment1After = Me.Segment1After
            GeneralLedgerConfig.Segment2After = Me.Segment2After
            GeneralLedgerConfig.Segment3After = Me.Segment3After

            GeneralLedgerConfig.FiscalYearStartMonth = Me.FiscalYearStartMonth

            GeneralLedgerConfig.PostingPeriodFormat = Me.PostingPeriodFormat

            GeneralLedgerConfig.PostingPeriodYear = Me.PostingPeriodYear

            GeneralLedgerConfig.CurrencySymbol = Me.CurrencySymbol

            GeneralLedgerConfig.BudgetLastYearActual = Me.BudgetLastYearActual
            GeneralLedgerConfig.BudgetLastYearVariance = Me.BudgetLastYearVariance
            GeneralLedgerConfig.BudgetYTD = Me.BudgetYTD
            GeneralLedgerConfig.BudgetEXT = Me.BudgetEXT
            GeneralLedgerConfig.BudgetEXTVAR = Me.BudgetEXTVAR
            GeneralLedgerConfig.BudgetClient = Me.BudgetClient

            GeneralLedgerConfig.BudgetIncludeYearEnd = Me.BudgetIncludeYearEnd
            GeneralLedgerConfig.SuppressFinancialStatements = Me.SuppressFinancialStatements
            GeneralLedgerConfig.UseControlAmounts = Me.UseControlAmounts

            GeneralLedgerConfig.BudgetAssetsCurrent = Me.BudgetAssetsCurrent
            GeneralLedgerConfig.BudgetAssets = Me.BudgetAssets
            GeneralLedgerConfig.BudgetAssetsFixed = Me.BudgetAssetsFixed
            GeneralLedgerConfig.BudgetLiabilitiesCurrent = Me.BudgetLiabilitiesCurrent
            GeneralLedgerConfig.BudgetLiabilities = Me.BudgetLiabilities

            GeneralLedgerConfig.BudgetIncome = Me.BudgetIncome
            GeneralLedgerConfig.BudgetIncomeOther = Me.BudgetIncomeOther
            GeneralLedgerConfig.BudgetExpenseCOS = Me.BudgetExpenseCOS
            GeneralLedgerConfig.BudgetExpenseOperating = Me.BudgetExpenseOperating
            GeneralLedgerConfig.BudgetExpenseOther = Me.BudgetExpenseOther
            GeneralLedgerConfig.BudgetExpenseTaxes = Me.BudgetExpenseTaxes

        End Sub

#End Region

    End Class

End Namespace
