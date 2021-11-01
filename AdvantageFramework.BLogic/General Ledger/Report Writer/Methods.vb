Namespace GeneralLedger.ReportWriter

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "

        Public Const _SQLActualDataPull As String = "SELECT SUM(ISNULL(CAST((GLS.GLSCREDIT + GLS.GLSDEBIT) AS decimal(18,2)), 0)) FROM [dbo].[GLSUMMARY] AS GLS INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN [dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE "
        Public Const _SQLBudget1DataPull As String = "SELECT SUM(ISNULL(CAST(GLS.GLSBUDGET AS decimal(18,2)), 0)) FROM [dbo].[GLSUMMARY] AS GLS INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN [dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE "
        Public Const _SQLBudget2DataPull As String = "SELECT SUM(ISNULL(CAST(GLS.GLSBUD2 AS decimal(18,2)), 0)) FROM [dbo].[GLSUMMARY] AS GLS INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN [dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE "
        Public Const _SQLBudget3DataPull As String = "SELECT SUM(ISNULL(CAST(GLS.GLSBUD3 AS decimal(18,2)), 0)) FROM [dbo].[GLSUMMARY] AS GLS INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN [dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE "
        Public Const _SQLBudget4DataPull As String = "SELECT SUM(ISNULL(CAST(GLS.GLSBUD4 AS decimal(18,2)), 0)) FROM [dbo].[GLSUMMARY] AS GLS INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN [dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE "

        Public Const _SQLYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = {1} AND PPGLMONTH <= {2}) "
        Public Const _SQLSelectedPeriodWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP >= '{1}' AND GLSPP <= '{2}' "
        Public Const _SQLWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH <= {2})) "

        'Public Const _SQLEndingBalanceYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = {1} AND PPGLMONTH <= {2}) "
        'Public Const _SQLBeginningBalanceYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = {1} AND PPGLMONTH < {2}) "
        'Public Const _SQLPeriodChangeYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = {1} AND PPGLMONTH <= {2}) "

        'Public Const _SQLEndingBalanceWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH <= {2})) "
        'Public Const _SQLBeginningBalanceWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH < {2})) "
        'Public Const _SQLPeriodChangeWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH <= {2})) "

        'Public Const _SQLBalanceSheetYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH <= {2})) "
        'Public Const _SQLIncomeStatementYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = {1} AND PPGLMONTH <= {2}) "
        'Public Const _SQLOtherYTDWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < {1}) OR (PPGLYEAR = {1} AND PPGLMONTH <= {2})) "

        'Public Const _SQLBalanceSheetWhereClause As String = "WHERE GLSCODE IN ('{0}') AND (GLSPP < '{1}01' OR GLSPP = '{2}')"
        'Public Const _SQLIncomeStatementWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP >= '{1}' AND GLSPP <= '{2}' "
        'Public Const _SQLOtherWhereClause As String = "WHERE GLSCODE IN ('{0}') AND GLSPP >= '{1}' AND GLSPP <= '{2}' "

        Public Const _SQLOfficeCodeWhereClauseExtension As String = " AND O.OFFICE_CODE = '{0}' "

#End Region

#Region " Enum "

        Public Enum DashboardFields
            ID
            Code
            Description
            Account
            AccountType
            PostPeriodCode
            Year
            Month
            MonthName
            Quarter
            DepartmentTeamCode
            DepartmentTeamDescription
            DepartmentTeam
            OfficeCode
            OfficeName
            Office
            Credit
            Debit
            Total
            Quantity
            Budget1
            Budget2
            Budget3
        End Enum

        Public Enum StatementFields
            ID
            RowID
            Sort
            Description
        End Enum

        Public Enum PercentOfRowColumnFields
            ID
            ColumnName
            ColumnID
            RowID
            RowIndex
            RowDescription
            PercentOfRowID
            PercentOfRowIndex
            PercentOfRowDescription
        End Enum

        Public Enum RelatedRowFields
            ID
            RowID
            RelatedRowID
            RelatedRowIndex
            RelatedRowDescription
            RelatedRowOrder
        End Enum

        Public Enum ColumnFields
            ID
            Name
            Description
            Type
            DataType
            PreviousYears
            PeriodOption
            IsVisible
            UnderlineColumnHeader
            Expression
            UseCurrencyFormat
            NumberOfDecimalPlaces
            Column1Name
            Column2Name
            PctOfRowColumnName
            ColumnIndex
            OfficeCode
            GLReportTemplateColumnID
            OverrideRowDataOptionsAndCalculations
            DataCalculation
            DataOption
        End Enum

        Public Enum RowFields
            ID
            GLReportTemplateRowID
            Description
            RowIndex
            Type
            BalanceType
            DisplayType
            TotalType
            LinkType
            AccountType
            AccountGroupCode
            GLACode
            UseBaseAccountCodes
            GLACodeRangeStart
            GLACodeRangeTo
            Wildcard
            IndentSpaces
            UnderlineAmount
            IsBold
			UseCurrencyFormat
			NumberOfDecimalPlaces
			SuppressIfAllZeros
            RollUp
            DataCalculation
            DataOption
			DoubleUnderlineAmount
			IsVisible
		End Enum

        Public Enum DepartmentTeamPresetFields
            ID
            Code
            Description
            GLAReferenceCode
            GLReportTemplatePresetDepartmentTeamID
        End Enum

        Public Enum OfficePresetFields
            ID
            Code
            Name
            GLAReferenceCode
            GLReportTemplatePresetOfficeID
        End Enum

        Public Enum ReportTypes
            IncomeStatement
            BalanceSheet
            Other
        End Enum

        Public Enum ColumnTypes
            Data = 1
            Blank = 2
            Expression = 3
            Variance = 4
            PercentVariance = 5
            PercentOfRow = 6
        End Enum

        Public Enum ColumnDataTypes
            Actual = 1
            Budget1 = 2
            Budget2 = 3
            Budget3 = 4
            Budget4 = 5
        End Enum

        Public Enum LinkTypes
            AccountType = 1
            AccountGroup = 2
            Account = 3
            AccountRange = 4
            Wildcard = 5
        End Enum

        Public Enum DisplayTypes
            Description = 1
            FullAccount = 2
            AccountCode = 3
            AccountDescription = 4
        End Enum

        Public Enum BalanceTypes
            Credit = 1
            Debit = 2
        End Enum

        Public Enum AccountTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Current Asset")>
            CurrentAsset = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Current Liability")>
            CurrentLiability = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("20", "Equity")>
            Equity = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "Expense - COS")>
            ExpenseCOS = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("14", "Expense - Operating")>
            ExpenseOperating = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "Expense - Other")>
            ExpenseOther = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("16", "Expense - Taxes")>
            ExpenseTaxes = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Fixed Asset")>
            FixedAsset = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Income")>
            Income = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Income - Other")>
            IncomeOther = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Non-Current Liability")>
            NonCurrentLiability = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Non-Current Asset")>
            NonCurrentAsset = 1
        End Enum

        Public Enum RowTypes
            Account = 1
            Total = 2
            Other = 3
        End Enum

        Public Enum TotalTypes
            Adding = 1
            Subtracting = 2
            Dividing = 3
        End Enum

        Public Enum PeriodOptions
            Month = 0
            Month1 = 1
            Month2 = 2
            Month3 = 3
            Month4 = 4
            Month5 = 5
            Month6 = 6
            Month7 = 7
            Month8 = 8
            Month9 = 9
            Month10 = 10
            Month11 = 11
            Month12 = 12
            Quarter1 = 14
            Quarter2 = 15
            Quarter3 = 16
            Quarter4 = 17
            Year = 18
        End Enum

        Public Enum DataCalculations
            YearToDate = 1
            SelectedPeriod = 2
            All = 3
        End Enum

        Public Enum DataOptions
            EndingBalance = 1
            BeginningBalance = 2
            PeriodChange = 3
        End Enum

        Public Enum SortRowsByOptions As Integer
            AccountCode = 1
            BaseAccountCode = 2
            AccountDescription = 3
        End Enum

        Public Enum StandardGeneralLedgerReports
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Detail by Account Code - Portrait")>
            DetailByAccountPortrait = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Detail by Account Code - Landscape")>
            DetailByAccountLandscape = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Trial Balance")>
            TrialBalance = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadStartingPostPeriodForReport(ByVal RowsDataTable As System.Data.DataTable, ByVal ColumnsDataTable As System.Data.DataTable, _
                                                        ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod, _
                                                        ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)) As AdvantageFramework.Database.Entities.PostPeriod

            'objects
            Dim DataOption As DataOptions = DataOptions.EndingBalance
            Dim DataCalculation As DataCalculations = DataCalculations.YearToDate
            Dim StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim HasAnAllDataCalculation As Boolean = False

            HasAnAllDataCalculation = ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = True AndAlso DR(ColumnFields.DataCalculation.ToString) = DataCalculations.All)

            If HasAnAllDataCalculation = False Then

                HasAnAllDataCalculation = RowsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(RowFields.DataCalculation.ToString) = DataCalculations.All)

            End If

            If HasAnAllDataCalculation = False Then

                For Each RowDataRow In RowsDataTable.Select("1=1", RowFields.RowIndex.ToString)

                    DataOption = RowDataRow(RowFields.DataOption.ToString)
                    DataCalculation = RowDataRow(RowFields.DataCalculation.ToString)

                    For Each ColumnDataRow In ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                        If ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) Then

                            DataOption = ColumnDataRow(ColumnFields.DataOption.ToString)
                            DataCalculation = ColumnDataRow(ColumnFields.DataCalculation.ToString)

                        End If

                        LoadStartAndEndingPostPeriods(RowDataRow, ColumnDataRow, ReportPostPeriod, DataOption, PostPeriods, StartingPostPeriod, Nothing)

                        If PostPeriod Is Nothing Then

                            PostPeriod = StartingPostPeriod

                        Else

                            If PostPeriod IsNot Nothing AndAlso StartingPostPeriod IsNot Nothing Then

                                If StartingPostPeriod.Year < PostPeriod.Year OrElse (StartingPostPeriod.Year = PostPeriod.Year AndAlso StartingPostPeriod.Month.GetValueOrDefault(0) < PostPeriod.Month.GetValueOrDefault(0)) Then

                                    PostPeriod = StartingPostPeriod

                                End If

                        End If

                        End If

                    Next

                Next

            Else

                PostPeriod = PostPeriods.FirstOrDefault

            End If

            LoadStartingPostPeriodForReport = PostPeriod

        End Function
        Public Sub LoadStartAndEndingPostPeriods(ByVal RowDataRow As System.Data.DataRow, ByVal ColumnDataRow As System.Data.DataRow, _
                                                 ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod, _
                                                 ByVal DataOption As DataOptions, _
                                                 ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod), _
                                                 ByRef StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod, _
                                                 ByRef EndingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod)

            'objects
            Dim EndingYear As Integer = 0
            Dim StartingYear As Integer = 0
            Dim PeriodOption As PeriodOptions = PeriodOptions.Month
            Dim StartingPostPeriodMonth As Integer = 0
            Dim EndingPostPeriodMonth As Integer = 0

            Try

                If ColumnDataRow(ColumnFields.PreviousYears.ToString) > 0 OrElse ColumnDataRow(ColumnFields.PeriodOption.ToString) <> PeriodOptions.Month Then

                    EndingYear = CInt(ReportPostPeriod.Year)

                    EndingYear -= ColumnDataRow(ColumnFields.PreviousYears.ToString)
                    StartingYear = EndingYear

                    PeriodOption = ColumnDataRow(ColumnFields.PeriodOption.ToString)

                    Select Case PeriodOption

                        Case PeriodOptions.Month

                            StartingPostPeriodMonth = CInt(ReportPostPeriod.Month.GetValueOrDefault(0))
                            EndingPostPeriodMonth = CInt(ReportPostPeriod.Month.GetValueOrDefault(0))

                        Case PeriodOptions.Month1

                            StartingPostPeriodMonth = 1
                            EndingPostPeriodMonth = 1

                        Case PeriodOptions.Month2

                            StartingPostPeriodMonth = 2
                            EndingPostPeriodMonth = 2

                        Case PeriodOptions.Month3

                            StartingPostPeriodMonth = 3
                            EndingPostPeriodMonth = 3

                        Case PeriodOptions.Month4

                            StartingPostPeriodMonth = 4
                            EndingPostPeriodMonth = 4

                        Case PeriodOptions.Month5

                            StartingPostPeriodMonth = 5
                            EndingPostPeriodMonth = 5

                        Case PeriodOptions.Month6

                            StartingPostPeriodMonth = 6
                            EndingPostPeriodMonth = 6

                        Case PeriodOptions.Month7

                            StartingPostPeriodMonth = 7
                            EndingPostPeriodMonth = 7

                        Case PeriodOptions.Month8

                            StartingPostPeriodMonth = 8
                            EndingPostPeriodMonth = 8

                        Case PeriodOptions.Month9

                            StartingPostPeriodMonth = 9
                            EndingPostPeriodMonth = 9

                        Case PeriodOptions.Month10

                            StartingPostPeriodMonth = 10
                            EndingPostPeriodMonth = 10

                        Case PeriodOptions.Month11

                            StartingPostPeriodMonth = 11
                            EndingPostPeriodMonth = 11

                        Case PeriodOptions.Month12

                            StartingPostPeriodMonth = 12
                            EndingPostPeriodMonth = 12

                        Case PeriodOptions.Quarter1

                            StartingPostPeriodMonth = 1
                            EndingPostPeriodMonth = 3

                        Case PeriodOptions.Quarter2

                            StartingPostPeriodMonth = 4
                            EndingPostPeriodMonth = 6

                        Case PeriodOptions.Quarter3

                            StartingPostPeriodMonth = 7
                            EndingPostPeriodMonth = 9

                        Case PeriodOptions.Quarter4

                            StartingPostPeriodMonth = 10
                            EndingPostPeriodMonth = 12

                        Case PeriodOptions.Year

                            StartingPostPeriodMonth = 1
                            EndingPostPeriodMonth = 12

                    End Select

                    If DataOption = DataOptions.BeginningBalance Then

                        Select Case PeriodOption

                            Case PeriodOptions.Month, PeriodOptions.Month1, PeriodOptions.Month2,
                                 PeriodOptions.Month3, PeriodOptions.Month4, PeriodOptions.Month5,
                                 PeriodOptions.Month6, PeriodOptions.Month7, PeriodOptions.Month8,
                                 PeriodOptions.Month9, PeriodOptions.Month10, PeriodOptions.Month11,
                                 PeriodOptions.Month12

                                If StartingPostPeriodMonth = 1 Then

                                    StartingPostPeriodMonth = 12
                                    StartingYear -= 1

                                Else

                                    StartingPostPeriodMonth -= 1

                                End If

                                If EndingPostPeriodMonth = 1 Then

                                    EndingPostPeriodMonth = 12
                                    EndingYear -= 1

                                Else

                                    EndingPostPeriodMonth -= 1

                                End If

                            Case PeriodOptions.Quarter1

                                StartingYear -= 1
                                EndingYear -= 1

                                StartingPostPeriodMonth = 10
                                EndingPostPeriodMonth = 12

                            Case PeriodOptions.Quarter2

                                StartingPostPeriodMonth = 1
                                EndingPostPeriodMonth = 3

                            Case PeriodOptions.Quarter3

                                StartingPostPeriodMonth = 4
                                EndingPostPeriodMonth = 6

                            Case PeriodOptions.Quarter4

                                StartingPostPeriodMonth = 7
                                EndingPostPeriodMonth = 9

                            Case PeriodOptions.Year

                                StartingYear -= 1
                                EndingYear -= 1

                        End Select

                    End If

                    Try

                        StartingPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Month = CShort(StartingPostPeriodMonth) AndAlso Entity.Year = StartingYear.ToString)

                    Catch ex As Exception
                        StartingPostPeriod = Nothing
                    End Try

                    Try

                        EndingPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Month = CShort(EndingPostPeriodMonth) AndAlso Entity.Year = EndingYear.ToString)

                    Catch ex As Exception
                        EndingPostPeriod = Nothing
                    End Try

                Else

                    If DataOption = DataOptions.BeginningBalance Then

                        EndingYear = CInt(ReportPostPeriod.Year)

                        StartingYear = EndingYear

                        StartingPostPeriodMonth = CInt(ReportPostPeriod.Month.GetValueOrDefault(0))
                        EndingPostPeriodMonth = CInt(ReportPostPeriod.Month.GetValueOrDefault(0))

                        If StartingPostPeriodMonth = 1 Then

                            StartingPostPeriodMonth = 12
                            StartingYear -= 1

                        Else

                            StartingPostPeriodMonth -= 1

                        End If

                        If EndingPostPeriodMonth = 1 Then

                            EndingPostPeriodMonth = 12
                            EndingYear -= 1

                        Else

                            EndingPostPeriodMonth -= 1

                        End If

                        Try

                            StartingPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Month = CShort(StartingPostPeriodMonth) AndAlso Entity.Year = StartingYear.ToString)

                        Catch ex As Exception
                            StartingPostPeriod = Nothing
                        End Try

                        Try

                            EndingPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Month = CShort(EndingPostPeriodMonth) AndAlso Entity.Year = EndingYear.ToString)

                        Catch ex As Exception
                            EndingPostPeriod = Nothing
                        End Try

                    Else

                        StartingPostPeriod = ReportPostPeriod
                        EndingPostPeriod = ReportPostPeriod

                    End If

                End If

                If DataOption = DataOptions.PeriodChange Then

                    StartingPostPeriod = EndingPostPeriod
                    EndingPostPeriod = ReportPostPeriod

                End If

            Catch ex As Exception
                StartingPostPeriod = Nothing
                EndingPostPeriod = Nothing
            End Try

        End Sub
        Public Function CopyGLReportTemplateColumn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByVal GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim NewGLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn = Nothing
            Dim NewGLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation = Nothing

            NewGLReportTemplateColumn = New AdvantageFramework.Database.Entities.GLReportTemplateColumn

            NewGLReportTemplateColumn.GLReportTemplateID = GLReportTemplateID
            NewGLReportTemplateColumn.Description = GLReportTemplateColumn.Description
            NewGLReportTemplateColumn.Name = GLReportTemplateColumn.Name
            NewGLReportTemplateColumn.ColumnIndex = GLReportTemplateColumn.ColumnIndex
            NewGLReportTemplateColumn.Type = GLReportTemplateColumn.Type
            NewGLReportTemplateColumn.DataType = GLReportTemplateColumn.DataType
            NewGLReportTemplateColumn.PreviousYears = GLReportTemplateColumn.PreviousYears
            NewGLReportTemplateColumn.PeriodOption = GLReportTemplateColumn.PeriodOption
            NewGLReportTemplateColumn.IsVisible = GLReportTemplateColumn.IsVisible
            NewGLReportTemplateColumn.Expression = GLReportTemplateColumn.Expression
            NewGLReportTemplateColumn.UnderlineColumnHeaders = GLReportTemplateColumn.UnderlineColumnHeaders
            NewGLReportTemplateColumn.UseCurrencyFormat = GLReportTemplateColumn.UseCurrencyFormat
            NewGLReportTemplateColumn.NumberOfDecimalPlaces = GLReportTemplateColumn.NumberOfDecimalPlaces
            NewGLReportTemplateColumn.Column1Name = GLReportTemplateColumn.Column1Name
            NewGLReportTemplateColumn.Column2Name = GLReportTemplateColumn.Column2Name
            NewGLReportTemplateColumn.PctOfRowColumnName = GLReportTemplateColumn.PctOfRowColumnName
            NewGLReportTemplateColumn.OfficeCode = GLReportTemplateColumn.OfficeCode
            NewGLReportTemplateColumn.OverrideDataOptions = GLReportTemplateColumn.OverrideDataOptions
            NewGLReportTemplateColumn.DataOption = GLReportTemplateColumn.DataOption
            NewGLReportTemplateColumn.DataCalculation = GLReportTemplateColumn.DataCalculation

            If AdvantageFramework.Database.Procedures.GLReportTemplateColumn.Insert(DbContext, NewGLReportTemplateColumn) Then

                For Each GLReportTemplatePctOfRowColumnRelation In AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.LoadByGLReportTemplateColumnID(DbContext, GLReportTemplateColumn.ID).ToList

                    NewGLReportTemplatePctOfRowColumnRelation = New AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation

                    NewGLReportTemplatePctOfRowColumnRelation.GLReportTemplateID = GLReportTemplateID
                    NewGLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID = NewGLReportTemplateColumn.ID
                    NewGLReportTemplatePctOfRowColumnRelation.RowIndex = GLReportTemplatePctOfRowColumnRelation.RowIndex
                    NewGLReportTemplatePctOfRowColumnRelation.PctOfRowIndex = GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex

                    If AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.Insert(DbContext, NewGLReportTemplatePctOfRowColumnRelation) = False Then

                        Copied = False
                        Exit For

                    End If

                Next

            Else

                Copied = False

            End If

            CopyGLReportTemplateColumn = Copied

        End Function
        Public Function CopyGLReportTemplateRow(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByVal GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim NewGLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow = Nothing
            Dim NewGLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation = Nothing

            NewGLReportTemplateRow = New AdvantageFramework.Database.Entities.GLReportTemplateRow

            NewGLReportTemplateRow.GLReportTemplateID = GLReportTemplateID
            NewGLReportTemplateRow.Description = GLReportTemplateRow.Description
            NewGLReportTemplateRow.BalanceType = GLReportTemplateRow.BalanceType
            NewGLReportTemplateRow.DisplayType = GLReportTemplateRow.DisplayType
            NewGLReportTemplateRow.LinkType = GLReportTemplateRow.LinkType
            NewGLReportTemplateRow.AccountType = GLReportTemplateRow.AccountType
            NewGLReportTemplateRow.GLACode = GLReportTemplateRow.GLACode
            NewGLReportTemplateRow.GLACodeRangeStart = GLReportTemplateRow.GLACodeRangeStart
            NewGLReportTemplateRow.GLACodeRangeTo = GLReportTemplateRow.GLACodeRangeTo
            NewGLReportTemplateRow.Wildcard = GLReportTemplateRow.Wildcard
            NewGLReportTemplateRow.AccountGroupCode = GLReportTemplateRow.AccountGroupCode
            NewGLReportTemplateRow.RowIndex = GLReportTemplateRow.RowIndex
            NewGLReportTemplateRow.Type = GLReportTemplateRow.Type
            NewGLReportTemplateRow.TotalType = GLReportTemplateRow.TotalType
            NewGLReportTemplateRow.UseBaseAccountCodes = GLReportTemplateRow.UseBaseAccountCodes
            NewGLReportTemplateRow.IndentSpaces = GLReportTemplateRow.IndentSpaces
            NewGLReportTemplateRow.UnderlineAmount = GLReportTemplateRow.UnderlineAmount
            NewGLReportTemplateRow.DoubleUnderlineAmount = GLReportTemplateRow.DoubleUnderlineAmount
            NewGLReportTemplateRow.IsBold = GLReportTemplateRow.IsBold
            NewGLReportTemplateRow.UseCurrencyFormat = GLReportTemplateRow.UseCurrencyFormat
            NewGLReportTemplateRow.SuppressIfAllZeros = GLReportTemplateRow.SuppressIfAllZeros
            NewGLReportTemplateRow.NumberOfDecimalPlaces = GLReportTemplateRow.NumberOfDecimalPlaces
            NewGLReportTemplateRow.RollUp = GLReportTemplateRow.RollUp
            NewGLReportTemplateRow.DataOption = GLReportTemplateRow.DataOption
			NewGLReportTemplateRow.DataCalculation = GLReportTemplateRow.DataCalculation
			NewGLReportTemplateRow.IsVisible = GLReportTemplateRow.IsVisible

			If AdvantageFramework.Database.Procedures.GLReportTemplateRow.Insert(DbContext, NewGLReportTemplateRow) Then

                For Each GLReportTemplateRowRelation In AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.LoadByGLReportTemplateRowID(DbContext, GLReportTemplateRow.ID).ToList

                    NewGLReportTemplateRowRelation = New AdvantageFramework.Database.Entities.GLReportTemplateRowRelation

                    NewGLReportTemplateRowRelation.GLReportTemplateID = GLReportTemplateID
                    NewGLReportTemplateRowRelation.GLReportTemplateRowID = NewGLReportTemplateRow.ID
                    NewGLReportTemplateRowRelation.RelatedRowIndex = GLReportTemplateRowRelation.RelatedRowIndex
                    NewGLReportTemplateRowRelation.Order = GLReportTemplateRowRelation.Order

                    If AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.Insert(DbContext, NewGLReportTemplateRowRelation) = False Then

                        Copied = False
                        Exit For

                    End If

                Next

            Else

                Copied = False

            End If

            CopyGLReportTemplateRow = Copied

        End Function
        Public Function CopyGLReportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal GLReportTemplateID As Integer, ByRef NewGLReportTemplateID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim NewGLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim NewGLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset = Nothing
            Dim NewGLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, GLReportTemplateID)

                If GLReportTemplate IsNot Nothing Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        NewGLReportTemplate = New AdvantageFramework.Database.Entities.GLReportTemplate

                        NewGLReportTemplate.Description = GLReportTemplate.Description
                        NewGLReportTemplate.DashboardLayout = GLReportTemplate.DashboardLayout
                        NewGLReportTemplate.PostPeriodCode = GLReportTemplate.PostPeriodCode
                        NewGLReportTemplate.ReportType = GLReportTemplate.ReportType
                        NewGLReportTemplate.GLReportUserDefReportID = GLReportTemplate.GLReportUserDefReportID
                        NewGLReportTemplate.PrintColumnHeadingsOnEveryPage = GLReportTemplate.PrintColumnHeadingsOnEveryPage
                        NewGLReportTemplate.SortRowsBy = GLReportTemplate.SortRowsBy

                        If AdvantageFramework.Database.Procedures.GLReportTemplate.Insert(DbContext, NewGLReportTemplate) Then

                            Copied = True
                            '
                            '======================================================
                            '
                            '======================================================
                            '
                            For Each GLReportTemplateColumn In AdvantageFramework.Database.Procedures.GLReportTemplateColumn.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                If CopyGLReportTemplateColumn(DbContext, NewGLReportTemplate.ID, GLReportTemplateColumn) = False Then

                                    Copied = False
                                    Exit For

                                End If

                            Next
                            '
                            '======================================================
                            '
                            '======================================================
                            '
                            If Copied Then

                                For Each GLReportTemplateRow In AdvantageFramework.Database.Procedures.GLReportTemplateRow.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                    If CopyGLReportTemplateRow(DbContext, NewGLReportTemplate.ID, GLReportTemplateRow) = False Then

                                        Copied = False
                                        Exit For

                                    End If

                                Next

                            End If
                            '
                            '======================================================
                            '
                            '======================================================
                            '
                            If Copied Then

                                For Each GLReportTemplateDepartmentTeamPreset In AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                    NewGLReportTemplateDepartmentTeamPreset = New AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset

                                    NewGLReportTemplateDepartmentTeamPreset.GLReportTemplateID = NewGLReportTemplate.ID
                                    NewGLReportTemplateDepartmentTeamPreset.DepartmentTeamCode = GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode

                                    If AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Insert(DbContext, NewGLReportTemplateDepartmentTeamPreset) = False Then

                                        Copied = False
                                        Exit For

                                    End If

                                Next

                            End If
                            '
                            '======================================================
                            '
                            '======================================================
                            '
                            If Copied Then

                                For Each GLReportTemplateOfficePreset In AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                    NewGLReportTemplateOfficePreset = New AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset

                                    NewGLReportTemplateOfficePreset.GLReportTemplateID = NewGLReportTemplate.ID
                                    NewGLReportTemplateOfficePreset.OfficeCode = GLReportTemplateOfficePreset.OfficeCode

                                    If AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Insert(DbContext, NewGLReportTemplateOfficePreset) = False Then

                                        Copied = False
                                        Exit For

                                    End If

                                Next

                            End If

                        End If

                    Catch ex As Exception
                        Copied = False
                    End Try

                    If Copied Then

                        Try

                            DbTransaction.Commit()

                            NewGLReportTemplateID = NewGLReportTemplate.ID

                        Catch ex As Exception
                            Copied = False
                        End Try

                    Else

                        DbTransaction.Rollback()

                    End If

                    DbContext.Database.Connection.Close()

                End If

            End Using

            CopyGLReportTemplate = Copied

        End Function
        Public Function AllowGLAccount(ByVal GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount, ByVal DepartmentTeamPresetsDataTable As System.Data.DataTable,
                                       ByVal OfficePresetsDataTable As System.Data.DataTable, ByVal EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice)) As Boolean

            'objects
            Dim Allowed As Boolean = False

            If EmployeeOfficeList.Count = 0 OrElse EmployeeOfficeList.SelectMany(Function(Entity) Entity.Office.GeneralLedgerOfficeCrossReferences).Any(Function(GLOCR) GLOCR.Code = GLACore.GeneralLedgerOfficeCrossReferenceCode) Then

                If (DepartmentTeamPresetsDataTable.Rows.Count = 0 OrElse DepartmentTeamPresetsDataTable.Select(DepartmentTeamPresetFields.GLAReferenceCode.ToString & " = '" & GLACore.DepartmentCode & "'").Any) AndAlso
                        (OfficePresetsDataTable.Rows.Count = 0 OrElse OfficePresetsDataTable.Select(OfficePresetFields.GLAReferenceCode.ToString & " = '" & GLACore.GeneralLedgerOfficeCrossReferenceCode & "'").Any) Then

                    Allowed = True

                End If

            End If

            AllowGLAccount = Allowed

        End Function
        Public Function FilterGLAsByPresets(ByVal GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount), ByVal DepartmentTeamPresetsDataTable As System.Data.DataTable,
                                            ByVal OfficePresetsDataTable As System.Data.DataTable, ByVal EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice)) As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            For Each GLACore In GLACoreList.ToList

                If AllowGLAccount(GLACore, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList) = False Then

                    GLACoreList.Remove(GLACore)

                End If

            Next

            FilterGLAsByPresets = GLACoreList

        End Function
        Public Function GetDashboardSQLString(ByVal RowDataRow As System.Data.DataRow, ByVal ReportType As ReportTypes) As String

            'objects
            Dim SQLString As String = ""

            If ReportType = ReportTypes.BalanceSheet OrElse ReportType = ReportTypes.Other Then

                SQLString = "SELECT " &
                            "	[ID] = NEWID(), " &
                            "	[RowDescription] = '{0}', " &
                            "	[Code] = GLA.GLACODE, " &
                            "	[Description] = GLA.GLADESC, " &
                            "	[Account] = GLA.GLACODE + ' - ' + GLA.GLADESC, " &
                            "	[AccountType] = 'General Ledger Account', " &
                            "	[PostPeriodCode] = PP.PPPERIOD, " &
                            "	[Year] = CASE WHEN ISNUMERIC(PP.PPGLYEAR) = 1 THEN CAST(PP.PPGLYEAR AS int) ELSE CAST(0 AS int) END, " &
                            "	[Month] = CASE WHEN PP.PPGLMONTH < 13 AND PP.PPGLMONTH IS NOT NULL THEN CAST(PP.PPGLMONTH AS int) ELSE CAST(0 AS int) END, " &
                            "	[MonthName] = PP.PPDESC, " &
                            "	[Quarter] = CASE WHEN PP.PPGLMONTH < 4 THEN 1 WHEN PP.PPGLMONTH < 7 THEN 2 WHEN PP.PPGLMONTH < 10 THEN 3 WHEN PP.PPGLMONTH < 13 THEN 4 ELSE 0 END, " &
                            "	[Date] = CASE WHEN (PP.PPGLMONTH < 13 AND PP.PPGLMONTH IS NOT NULL) AND ISNUMERIC(PP.PPGLYEAR) = 1 THEN CAST(CAST(PP.PPGLMONTH AS varchar(2)) + '/01/' + CAST(PP.PPGLYEAR AS varchar(4)) AS smalldatetime) ELSE NULL END, " &
                            "	[DepartmentTeamCode] = DT.DP_TM_CODE, " &
                            "	[DepartmentTeamDescription] = DT.DP_TM_DESC, " &
                            "	[DepartmentTeam] = CASE WHEN DT.DP_TM_CODE IS NULL THEN NULL ELSE DT.DP_TM_CODE + ' - ' + DT.DP_TM_DESC END, " &
                            "	[OfficeCode] = O.OFFICE_CODE, " &
                            "	[OfficeName] = O.OFFICE_NAME, " &
                            "	[Office] = CASE WHEN O.OFFICE_CODE IS NULL THEN NULL ELSE O.OFFICE_CODE + ' - ' + O.OFFICE_NAME END, " &
                            "	[Credit] = CAST(ISNULL(GLS.GLSCREDIT, 0) AS decimal(18,2)), " &
                            "	[Debit] = CAST(ISNULL(GLS.GLSDEBIT, 0) AS decimal(18,2)), " &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Total] = CAST((ISNULL(GLS.GLSCREDIT, 0) + ISNULL(GLS.GLSDEBIT, 0)) * -1 AS decimal(18,2)), ", "	[Total] = CAST((ISNULL(GLS.GLSCREDIT, 0) + ISNULL(GLS.GLSDEBIT, 0)) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget1] = CAST(ISNULL(GLS.GLSBUDGET, 0) * -1 AS decimal(18,2)), ", "	[Budget1] = CAST(ISNULL(GLS.GLSBUDGET, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget2] = CAST(ISNULL(GLS.GLSBUD2, 0) * -1 AS decimal(18,2)), ", "	[Budget2] = CAST(ISNULL(GLS.GLSBUD2, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget3] = CAST(ISNULL(GLS.GLSBUD3, 0) * -1 AS decimal(18,2)), ", "	[Budget3] = CAST(ISNULL(GLS.GLSBUD3, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget4] = CAST(ISNULL(GLS.GLSBUD4, 0) * -1 AS decimal(18,2)) ", "	[Budget4] = CAST(ISNULL(GLS.GLSBUD4, 0) AS decimal(18,2)) ") &
                            "FROM " &
                            "	[dbo].[GLACCOUNT] AS GLA CROSS JOIN " &
                            "	[dbo].[POSTPERIOD] AS PP LEFT OUTER JOIN " &
                            "	[dbo].[GLSUMMARY] AS GLS ON GLS.GLSPP = PP.PPPERIOD AND " &
                            "								GLS.GLSCODE = GLA.GLACODE LEFT OUTER JOIN  " &
                            "	[dbo].[GLDXREF] AS GLD ON GLD.GLDXDEPT = GLA.GLADEPT LEFT OUTER JOIN " &
                            "	[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = GLD.GLDXDEPT LEFT OUTER JOIN " &
                            "	[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                            "	[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                            "WHERE  " &
                            "	GLA.GLACODE IN ({1}) AND " &
                            "   GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < '{2}') OR (PPGLYEAR = '{2}' AND PPGLMONTH <= '{3}')) "

            Else

                SQLString = "SELECT " &
                            "	[ID] = NEWID(), " &
                            "	[RowDescription] = '{0}', " &
                            "	[Code] = GLA.GLACODE, " &
                            "	[Description] = GLA.GLADESC, " &
                            "	[Account] = GLA.GLACODE + ' - ' + GLA.GLADESC, " &
                            "	[AccountType] = 'General Ledger Account', " &
                            "	[PostPeriodCode] = PP.PPPERIOD, " &
                            "	[Year] = CASE WHEN ISNUMERIC(PP.PPGLYEAR) = 1 THEN CAST(PP.PPGLYEAR AS int) ELSE CAST(0 AS int) END, " &
                            "	[Month] = CASE WHEN PP.PPGLMONTH < 13 AND PP.PPGLMONTH IS NOT NULL THEN CAST(PP.PPGLMONTH AS int) ELSE CAST(0 AS int) END, " &
                            "	[MonthName] = PP.PPDESC, " &
                            "	[Quarter] = CASE WHEN PP.PPGLMONTH < 4 THEN 1 WHEN PP.PPGLMONTH < 7 THEN 2 WHEN PP.PPGLMONTH < 10 THEN 3 WHEN PP.PPGLMONTH < 13 THEN 4 ELSE 0 END, " &
                            "	[Date] = CASE WHEN (PP.PPGLMONTH < 13 AND PP.PPGLMONTH IS NOT NULL) AND ISNUMERIC(PP.PPGLYEAR) = 1 THEN CAST(CAST(PP.PPGLMONTH AS varchar(2)) + '/01/' + CAST(PP.PPGLYEAR AS varchar(4)) AS smalldatetime) ELSE NULL END, " &
                            "	[DepartmentTeamCode] = DT.DP_TM_CODE, " &
                            "	[DepartmentTeamDescription] = DT.DP_TM_DESC, " &
                            "	[DepartmentTeam] = CASE WHEN DT.DP_TM_CODE IS NULL THEN NULL ELSE DT.DP_TM_CODE + ' - ' + DT.DP_TM_DESC END, " &
                            "	[OfficeCode] = O.OFFICE_CODE, " &
                            "	[OfficeName] = O.OFFICE_NAME, " &
                            "	[Office] = CASE WHEN O.OFFICE_CODE IS NULL THEN NULL ELSE O.OFFICE_CODE + ' - ' + O.OFFICE_NAME END, " &
                            "	[Credit] = CAST(ISNULL(GLS.GLSCREDIT, 0) AS decimal(18,2)), " &
                            "	[Debit] = CAST(ISNULL(GLS.GLSDEBIT, 0) AS decimal(18,2)), " &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Total] = CAST((ISNULL(GLS.GLSCREDIT, 0) + ISNULL(GLS.GLSDEBIT, 0)) * -1 AS decimal(18,2)), ", "	[Total] = CAST((ISNULL(GLS.GLSCREDIT, 0) + ISNULL(GLS.GLSDEBIT, 0)) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget1] = CAST(ISNULL(GLS.GLSBUDGET, 0) * -1 AS decimal(18,2)), ", "	[Budget1] = CAST(ISNULL(GLS.GLSBUDGET, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget2] = CAST(ISNULL(GLS.GLSBUD2, 0) * -1 AS decimal(18,2)), ", "	[Budget2] = CAST(ISNULL(GLS.GLSBUD2, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget3] = CAST(ISNULL(GLS.GLSBUD3, 0) * -1 AS decimal(18,2)), ", "	[Budget3] = CAST(ISNULL(GLS.GLSBUD3, 0) AS decimal(18,2)), ") &
                            If(RowDataRow IsNot Nothing AndAlso RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit, "	[Budget4] = CAST(ISNULL(GLS.GLSBUD4, 0) * -1 AS decimal(18,2)) ", "	[Budget4] = CAST(ISNULL(GLS.GLSBUD4, 0) AS decimal(18,2)) ") &
                            "FROM " &
                            "	[dbo].[GLACCOUNT] AS GLA CROSS JOIN " &
                            "	[dbo].[POSTPERIOD] AS PP LEFT OUTER JOIN " &
                            "	[dbo].[GLSUMMARY] AS GLS ON GLS.GLSPP = PP.PPPERIOD AND " &
                            "								GLS.GLSCODE = GLA.GLACODE LEFT OUTER JOIN  " &
                            "	[dbo].[GLDXREF] AS GLD ON GLD.GLDXDEPT = GLA.GLADEPT LEFT OUTER JOIN " &
                            "	[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = GLD.GLDXDEPT LEFT OUTER JOIN " &
                            "	[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                            "	[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                            "WHERE  " &
                            "	GLA.GLACODE IN ({1}) AND " &
                            "   GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = '{2}' AND PPGLMONTH <= '{3}') "

            End If

            GetDashboardSQLString = SQLString

        End Function
        Public Function BuildExpresionEditorDataTable(ByVal ColumnsDataTable As System.Data.DataTable) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing

            DataTable = New System.Data.DataTable

            For Each ColumnDataRow In ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(ColumnFields.Type.ToString) = ColumnTypes.Data).OrderBy(Function(DR) DR(ColumnFields.ColumnIndex.ToString)).ToList

                DataColumn = DataTable.Columns.Add(ColumnDataRow(ColumnFields.Name.ToString), GetType(Decimal))
                DataColumn.AllowDBNull = True
                DataColumn.DefaultValue = System.DBNull.Value

                DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", True)

            Next

            BuildExpresionEditorDataTable = DataTable

        End Function
        Public Function BuildDashboardDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportType As ReportTypes) As System.Data.DataTable

            'objects
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            SQLString = GetDashboardSQLString(Nothing, ReportType)

            SQLString = String.Format(SQLString, "", "''", "", "")

            SQLConnection = New System.Data.SqlClient.SqlConnection(DbContext.Database.Connection.ConnectionString)

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.FillSchema(DataTable, SchemaType.Source)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

            Try

                DataTable.Columns("RowDescription").MaxLength = -1

            Catch ex As Exception

            End Try

            Try

                DataTable.Columns("AccountType").MaxLength = -1

            Catch ex As Exception

            End Try

            BuildDashboardDataTable = DataTable

        End Function
        Public Function BuildStatementDataTable(ByVal ColumnsDataTable As System.Data.DataTable) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim ShowInExpressionEditor As Boolean = False

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add(StatementFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", False)
            DataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = DataTable.Columns.Add(StatementFields.RowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = -2
            DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", False)

            DataColumn = DataTable.Columns.Add(StatementFields.Sort.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0
            DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", False)

            DataColumn = DataTable.Columns.Add(StatementFields.Description.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""
            DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", False)

            For Each ColumnDataRow In ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                DataColumn = DataTable.Columns.Add(ColumnDataRow(ColumnFields.Name.ToString), GetType(Decimal))
                DataColumn.AllowDBNull = True
                DataColumn.DefaultValue = System.DBNull.Value

                If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data Then

                    ShowInExpressionEditor = True

                Else

                    ShowInExpressionEditor = False

                End If

                DataColumn.ExtendedProperties.Add("ShowInExpressionEditor", ShowInExpressionEditor)

            Next

            For Each ColumnDataRow In ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                DataColumn = Nothing

                Try

                    If DataTable.Columns.Contains(ColumnDataRow(ColumnFields.Name.ToString)) Then

                        DataColumn = DataTable.Columns(ColumnDataRow(ColumnFields.Name.ToString))

                    End If

                Catch ex As Exception
                    DataColumn = Nothing
                End Try

                If DataColumn IsNot Nothing Then

                    If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Variance OrElse ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                        If DataTable.Columns.Contains(ColumnDataRow(ColumnFields.Column1Name.ToString)) AndAlso DataTable.Columns.Contains(ColumnDataRow(ColumnFields.Column2Name.ToString)) Then

                            If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Variance Then

                                DataColumn.Expression = "[" & ColumnDataRow(ColumnFields.Column1Name.ToString) & "] - [" & ColumnDataRow(ColumnFields.Column2Name.ToString) & "]"

                            ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                                DataColumn.Expression = "IIF([" & ColumnDataRow(ColumnFields.Column2Name.ToString) & "] = 0, 0, ([" & ColumnDataRow(ColumnFields.Column1Name.ToString) & "] - [" & ColumnDataRow(ColumnFields.Column2Name.ToString) & "])/[" & ColumnDataRow(ColumnFields.Column2Name.ToString) & "])"

                            End If

                        End If

                    ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Expression Then

                        Try

                            DataColumn.Expression = ColumnDataRow(ColumnFields.Expression.ToString)

                        Catch ex As Exception
                            ColumnDataRow.RowError = "Invalid Expression"
                        End Try

                    End If

                End If

            Next

            BuildStatementDataTable = DataTable

        End Function
        Public Sub BuildRowsDataTable(ByRef RowsDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            RowsDataTable = New System.Data.DataTable

            DataColumn = RowsDataTable.Columns.Add(RowFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            RowsDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            RowsDataTable.Columns.Add(RowFields.GLReportTemplateRowID.ToString, GetType(Integer))

            DataColumn = RowsDataTable.Columns.Add(RowFields.Description.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

			DataColumn = RowsDataTable.Columns.Add(RowFields.IsVisible.ToString, GetType(Boolean))
			DataColumn.AllowDBNull = False
			DataColumn.DefaultValue = True

			DataColumn = RowsDataTable.Columns.Add(RowFields.BalanceType.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = CInt(BalanceTypes.Credit)

            DataColumn = RowsDataTable.Columns.Add(RowFields.DisplayType.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = CInt(DisplayTypes.Description)

            RowsDataTable.Columns.Add(RowFields.LinkType.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = RowsDataTable.Columns.Add(RowFields.RowIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            RowsDataTable.Columns.Add(RowFields.AccountType.ToString, GetType(Integer))
            RowsDataTable.Columns.Add(RowFields.AccountGroupCode.ToString, GetType(String))
            RowsDataTable.Columns.Add(RowFields.GLACode.ToString, GetType(String))
            RowsDataTable.Columns.Add(RowFields.GLACodeRangeStart.ToString, GetType(String))
            RowsDataTable.Columns.Add(RowFields.GLACodeRangeTo.ToString, GetType(String))
            RowsDataTable.Columns.Add(RowFields.Wildcard.ToString, GetType(String))

            DataColumn = RowsDataTable.Columns.Add(RowFields.Type.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = CInt(RowTypes.Account)

            DataColumn = RowsDataTable.Columns.Add(RowFields.TotalType.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = RowsDataTable.Columns.Add(RowFields.UseBaseAccountCodes.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

            DataColumn = RowsDataTable.Columns.Add(RowFields.IndentSpaces.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = RowsDataTable.Columns.Add(RowFields.UnderlineAmount.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

            DataColumn = RowsDataTable.Columns.Add(RowFields.IsBold.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

			DataColumn = RowsDataTable.Columns.Add(RowFields.UseCurrencyFormat.ToString, GetType(Boolean))
			DataColumn.AllowDBNull = False
			DataColumn.DefaultValue = False

			DataColumn = RowsDataTable.Columns.Add(RowFields.NumberOfDecimalPlaces.ToString, GetType(Integer))
			DataColumn.AllowDBNull = False
			DataColumn.DefaultValue = 0

			DataColumn = RowsDataTable.Columns.Add(RowFields.SuppressIfAllZeros.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

            DataColumn = RowsDataTable.Columns.Add(RowFields.RollUp.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

            DataColumn = RowsDataTable.Columns.Add(RowFields.DataCalculation.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

            DataColumn = RowsDataTable.Columns.Add(RowFields.DataOption.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

            DataColumn = RowsDataTable.Columns.Add(RowFields.DoubleUnderlineAmount.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = False

        End Sub
        Public Sub BuildColumnsDataTable(ByRef ColumnsDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            ColumnsDataTable = New System.Data.DataTable

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            ColumnsDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Name.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Description.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Type.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.DataType.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.GLReportTemplateColumnID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.PeriodOption.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.PreviousYears.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.IsVisible.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = True

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.UnderlineColumnHeader.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = False

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Expression.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = ""

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.UseCurrencyFormat.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = False

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.NumberOfDecimalPlaces.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Column1Name.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.Column2Name.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.PctOfRowColumnName.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.ColumnIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.OfficeCode.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString, GetType(Boolean))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = False

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.DataCalculation.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

            DataColumn = ColumnsDataTable.Columns.Add(ColumnFields.DataOption.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 1

        End Sub
        Public Sub BuildRelatedRowsDataTable(ByRef RelatedRowsDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            RelatedRowsDataTable = New System.Data.DataTable

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            RelatedRowsDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.RowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.RelatedRowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.RelatedRowIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.RelatedRowDescription.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = RelatedRowsDataTable.Columns.Add(RelatedRowFields.RelatedRowOrder.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

        End Sub
        Public Sub BuildOfficePresetsDataTable(ByRef OfficePresetsDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            OfficePresetsDataTable = New System.Data.DataTable

            DataColumn = OfficePresetsDataTable.Columns.Add(OfficePresetFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            OfficePresetsDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = OfficePresetsDataTable.Columns.Add(OfficePresetFields.Code.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = OfficePresetsDataTable.Columns.Add(OfficePresetFields.Name.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = OfficePresetsDataTable.Columns.Add(OfficePresetFields.GLAReferenceCode.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = ""

            DataColumn = OfficePresetsDataTable.Columns.Add(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

        End Sub
        Public Sub BuildDepartmentTeamPresetsDataTable(ByRef DepartmentTeamPresetsDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            DepartmentTeamPresetsDataTable = New System.Data.DataTable

            DataColumn = DepartmentTeamPresetsDataTable.Columns.Add(DepartmentTeamPresetFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            DepartmentTeamPresetsDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = DepartmentTeamPresetsDataTable.Columns.Add(DepartmentTeamPresetFields.Code.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = DepartmentTeamPresetsDataTable.Columns.Add(DepartmentTeamPresetFields.Description.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = DepartmentTeamPresetsDataTable.Columns.Add(DepartmentTeamPresetFields.GLAReferenceCode.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = ""

            DataColumn = DepartmentTeamPresetsDataTable.Columns.Add(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = 0

        End Sub
        Public Sub BuildPercentOfRowColumnDataTable(ByRef PercentOfRowColumnDataTable As System.Data.DataTable)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            PercentOfRowColumnDataTable = New System.Data.DataTable

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            PercentOfRowColumnDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.ColumnName.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.ColumnID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.RowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.RowIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = 0

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.RowDescription.ToString, GetType(String))
            DataColumn.AllowDBNull = False
            DataColumn.DefaultValue = ""

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.PercentOfRowID.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.PercentOfRowIndex.ToString, GetType(Integer))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

            DataColumn = PercentOfRowColumnDataTable.Columns.Add(PercentOfRowColumnFields.PercentOfRowDescription.ToString, GetType(String))
            DataColumn.AllowDBNull = True
            DataColumn.DefaultValue = System.DBNull.Value

        End Sub
        Public Sub LoadRowsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef RowsDataTable As System.Data.DataTable)

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplateRow In AdvantageFramework.Database.Procedures.GLReportTemplateRow.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).OrderBy(Function(Entity) Entity.RowIndex).ToList

                RowDataRow = RowsDataTable.NewRow

                RowDataRow(RowFields.GLReportTemplateRowID.ToString) = GLReportTemplateRow.ID
                RowDataRow(RowFields.Description.ToString) = GLReportTemplateRow.Description
                RowDataRow(RowFields.RowIndex.ToString) = GLReportTemplateRow.RowIndex
                RowDataRow(RowFields.Type.ToString) = GLReportTemplateRow.Type
                RowDataRow(RowFields.BalanceType.ToString) = GLReportTemplateRow.BalanceType
                RowDataRow(RowFields.DisplayType.ToString) = GLReportTemplateRow.DisplayType
                RowDataRow(RowFields.TotalType.ToString) = GLReportTemplateRow.TotalType
                RowDataRow(RowFields.LinkType.ToString) = GLReportTemplateRow.LinkType
                RowDataRow(RowFields.AccountType.ToString) = GLReportTemplateRow.AccountType.GetValueOrDefault(0)
                RowDataRow(RowFields.AccountGroupCode.ToString) = GLReportTemplateRow.AccountGroupCode
                RowDataRow(RowFields.GLACode.ToString) = GLReportTemplateRow.GLACode
                RowDataRow(RowFields.UseBaseAccountCodes.ToString) = GLReportTemplateRow.UseBaseAccountCodes
                RowDataRow(RowFields.GLACodeRangeStart.ToString) = GLReportTemplateRow.GLACodeRangeStart
                RowDataRow(RowFields.GLACodeRangeTo.ToString) = GLReportTemplateRow.GLACodeRangeTo
                RowDataRow(RowFields.Wildcard.ToString) = GLReportTemplateRow.Wildcard
                RowDataRow(RowFields.IndentSpaces.ToString) = GLReportTemplateRow.IndentSpaces
                RowDataRow(RowFields.UnderlineAmount.ToString) = GLReportTemplateRow.UnderlineAmount
                RowDataRow(RowFields.DoubleUnderlineAmount.ToString) = GLReportTemplateRow.DoubleUnderlineAmount
                RowDataRow(RowFields.IsBold.ToString) = GLReportTemplateRow.IsBold
				RowDataRow(RowFields.UseCurrencyFormat.ToString) = GLReportTemplateRow.UseCurrencyFormat
				RowDataRow(RowFields.NumberOfDecimalPlaces.ToString) = GLReportTemplateRow.NumberOfDecimalPlaces
				RowDataRow(RowFields.SuppressIfAllZeros.ToString) = GLReportTemplateRow.SuppressIfAllZeros
                RowDataRow(RowFields.RollUp.ToString) = GLReportTemplateRow.RollUp
                RowDataRow(RowFields.DataOption.ToString) = GLReportTemplateRow.DataOption
				RowDataRow(RowFields.DataCalculation.ToString) = GLReportTemplateRow.DataCalculation
				RowDataRow(RowFields.IsVisible.ToString) = GLReportTemplateRow.IsVisible

				RowsDataTable.Rows.Add(RowDataRow)

            Next

        End Sub
        Public Sub LoadColumnsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef ColumnsDataTable As System.Data.DataTable)

            'objects
            Dim ColumnDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplateColumn In AdvantageFramework.Database.Procedures.GLReportTemplateColumn.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).OrderBy(Function(Entity) Entity.ColumnIndex).ToList

                ColumnDataRow = ColumnsDataTable.NewRow

                ColumnDataRow(ColumnFields.Name.ToString) = GLReportTemplateColumn.Name
                ColumnDataRow(ColumnFields.Description.ToString) = GLReportTemplateColumn.Description
                ColumnDataRow(ColumnFields.Type.ToString) = GLReportTemplateColumn.Type
                ColumnDataRow(ColumnFields.DataType.ToString) = GLReportTemplateColumn.DataType
                ColumnDataRow(ColumnFields.PeriodOption.ToString) = GLReportTemplateColumn.PeriodOption
                ColumnDataRow(ColumnFields.PreviousYears.ToString) = GLReportTemplateColumn.PreviousYears
                ColumnDataRow(ColumnFields.IsVisible.ToString) = GLReportTemplateColumn.IsVisible
                ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString) = GLReportTemplateColumn.UnderlineColumnHeaders
                ColumnDataRow(ColumnFields.Expression.ToString) = GLReportTemplateColumn.Expression
                ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString) = GLReportTemplateColumn.UseCurrencyFormat
                ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString) = GLReportTemplateColumn.NumberOfDecimalPlaces
                ColumnDataRow(ColumnFields.Column1Name.ToString) = GLReportTemplateColumn.Column1Name
                ColumnDataRow(ColumnFields.Column2Name.ToString) = GLReportTemplateColumn.Column2Name
                ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString) = GLReportTemplateColumn.PctOfRowColumnName
                ColumnDataRow(ColumnFields.ColumnIndex.ToString) = GLReportTemplateColumn.ColumnIndex
                ColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString) = GLReportTemplateColumn.ID
                ColumnDataRow(ColumnFields.OfficeCode.ToString) = GLReportTemplateColumn.OfficeCode
                ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = GLReportTemplateColumn.OverrideDataOptions
                ColumnDataRow(ColumnFields.DataOption.ToString) = GLReportTemplateColumn.DataOption
                ColumnDataRow(ColumnFields.DataCalculation.ToString) = GLReportTemplateColumn.DataCalculation

                ColumnsDataTable.Rows.Add(ColumnDataRow)

            Next

        End Sub
        Public Sub LoadRelatedRowsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef RelatedRowsDataTable As System.Data.DataTable, ByRef RowsDataTable As System.Data.DataTable)

            'objects
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim NewRelatedRowDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplateRowRelation In AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).ToList

                Try

                    RowDataRow = RowsDataTable.Select(RowFields.GLReportTemplateRowID.ToString & " = " & GLReportTemplateRowRelation.GLReportTemplateRowID).SingleOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                Try

                    RelatedRowDataRow = RowsDataTable.Select(RowFields.RowIndex.ToString & " = " & GLReportTemplateRowRelation.RelatedRowIndex).SingleOrDefault

                Catch ex As Exception
                    RelatedRowDataRow = Nothing
                End Try

                If RowDataRow IsNot Nothing AndAlso RelatedRowDataRow IsNot Nothing Then

                    NewRelatedRowDataRow = RelatedRowsDataTable.NewRow

                    NewRelatedRowDataRow(RelatedRowFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowID.ToString) = RelatedRowDataRow(RowFields.ID.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowDescription.ToString) = RelatedRowDataRow(RowFields.Description.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowIndex.ToString) = RelatedRowDataRow(RowFields.RowIndex.ToString)
                    NewRelatedRowDataRow(RelatedRowFields.RelatedRowOrder) = GLReportTemplateRowRelation.Order

                    RelatedRowsDataTable.Rows.Add(NewRelatedRowDataRow)

                End If

            Next

        End Sub
        Public Sub LoadOfficePresetsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef OfficePresetsDataTable As System.Data.DataTable)

            'objects
            Dim OfficePresetDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplateOfficePreset In AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).Include("Office").ToList

                OfficePresetDataRow = OfficePresetsDataTable.Rows.Add()

                OfficePresetDataRow(OfficePresetFields.Code.ToString) = GLReportTemplateOfficePreset.Office.Code
                OfficePresetDataRow(OfficePresetFields.Name.ToString) = GLReportTemplateOfficePreset.Office.Name
                OfficePresetDataRow(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString) = GLReportTemplateOfficePreset.ID

                Try

                    OfficePresetDataRow(OfficePresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLOXGLOFFICE FROM dbo.GLOXREF WHERE GLOXOFFICE = '{0}'", OfficePresetDataRow(OfficePresetFields.Code.ToString))).FirstOrDefault

                Catch ex As Exception
                    OfficePresetDataRow(OfficePresetFields.GLAReferenceCode.ToString) = ""
                End Try

            Next

        End Sub
        Public Sub LoadDepartmentTeamPresetsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef DepartmentTeamPresetsDataTable As System.Data.DataTable)

            'objects
            Dim DepartmentTeamPresetDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplateDepartmentTeamPreset In AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).Include("DepartmentTeam").ToList

                DepartmentTeamPresetDataRow = DepartmentTeamPresetsDataTable.Rows.Add()

                DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.Code.ToString) = GLReportTemplateDepartmentTeamPreset.DepartmentTeam.Code
                DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.Description.ToString) = GLReportTemplateDepartmentTeamPreset.DepartmentTeam.Description
                DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString) = GLReportTemplateDepartmentTeamPreset.ID

                Try

                    DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GLDXGLDEPT FROM dbo.GLDXREF WHERE GLDXDEPT = '{0}'", DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.Code.ToString))).FirstOrDefault

                Catch ex As Exception
                    DepartmentTeamPresetDataRow(DepartmentTeamPresetFields.GLAReferenceCode.ToString) = ""
                End Try

            Next

        End Sub
        Public Sub LoadPercentOfRowColumnDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer, ByRef PercentOfRowColumnDataTable As System.Data.DataTable, ByRef RowsDataTable As System.Data.DataTable, ByRef ColumnsDataTable As System.Data.DataTable)

            'objects
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing

            For Each GLReportTemplatePctOfRowColumnRelation In AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.LoadByGLReportTemplateID(DbContext, GLReportTemplateID).ToList

                Try

                    ColumnDataRow = ColumnsDataTable.Select(ColumnFields.GLReportTemplateColumnID.ToString & " = " & GLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID).SingleOrDefault

                Catch ex As Exception
                    ColumnDataRow = Nothing
                End Try

                Try

                    RowDataRow = RowsDataTable.Select(RowFields.RowIndex.ToString & " = " & GLReportTemplatePctOfRowColumnRelation.RowIndex).SingleOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                Try

                    RelatedRowDataRow = RowsDataTable.Select(RowFields.RowIndex.ToString & " = " & GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex.GetValueOrDefault(-1)).SingleOrDefault

                Catch ex As Exception
                    RelatedRowDataRow = Nothing
                End Try

                If ColumnDataRow IsNot Nothing AndAlso RowDataRow IsNot Nothing Then

                    PercentOfRowColumnDataRow = PercentOfRowColumnDataTable.NewRow

                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnName.ToString) = ColumnDataRow(ColumnFields.Name.ToString)
                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.ColumnID.ToString) = ColumnDataRow(ColumnFields.ID.ToString)
                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)
                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowDescription.ToString) = RowDataRow(RowFields.Description.ToString)

                    If RelatedRowDataRow IsNot Nothing Then

                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) = RelatedRowDataRow(RowFields.ID.ToString)
                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowIndex.ToString) = RelatedRowDataRow(RowFields.RowIndex.ToString)
                        PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowDescription.ToString) = RelatedRowDataRow(RowFields.Description.ToString)

                    End If

                    PercentOfRowColumnDataTable.Rows.Add(PercentOfRowColumnDataRow)

                End If

            Next

        End Sub
        Public Sub BuildTemplateDataTables(ByVal Session As AdvantageFramework.Security.Session, ByVal GLReportTemplateID As Integer,
                                           ByRef ReportPostPeriodCode As String, ByRef ReportType As ReportTypes, ByRef GLReportUserDefReportID As Integer,
                                           ByRef PrintColumnHeadingsOnEveryPage As Boolean, ByRef SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions,
                                           ByRef DashboardLayout As Byte(), ByRef RowsDataTable As System.Data.DataTable,
                                           ByRef ColumnsDataTable As System.Data.DataTable, ByRef RelatedRowsDataTable As System.Data.DataTable,
                                           ByRef OfficePresetsDataTable As System.Data.DataTable, ByRef DepartmentTeamPresetsDataTable As System.Data.DataTable,
                                           ByRef PercentOfRowColumnDataTable As System.Data.DataTable, ByRef CurrencyCode As String, ByRef CurrencyRate As Nullable(Of Decimal))

            'objects
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildRowsDataTable(RowsDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildColumnsDataTable(ColumnsDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildRelatedRowsDataTable(RelatedRowsDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildOfficePresetsDataTable(OfficePresetsDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildDepartmentTeamPresetsDataTable(DepartmentTeamPresetsDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            BuildPercentOfRowColumnDataTable(PercentOfRowColumnDataTable)

            '
            '===============================================================================================
            '===============================================================================================
            '

            If GLReportTemplateID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, GLReportTemplateID)

                    If GLReportTemplate IsNot Nothing Then

                        ReportPostPeriodCode = GLReportTemplate.PostPeriodCode
                        ReportType = GLReportTemplate.ReportType
                        GLReportUserDefReportID = GLReportTemplate.GLReportUserDefReportID.GetValueOrDefault(0)
                        PrintColumnHeadingsOnEveryPage = GLReportTemplate.PrintColumnHeadingsOnEveryPage
                        SortRowsBy = GLReportTemplate.SortRowsBy
                        DashboardLayout = GLReportTemplate.DashboardLayout
                        CurrencyCode = GLReportTemplate.CurrencyCode
                        CurrencyRate = GLReportTemplate.CurrencyRate

                        LoadRowsDataTable(DbContext, GLReportTemplateID, RowsDataTable)

                        LoadColumnsDataTable(DbContext, GLReportTemplateID, ColumnsDataTable)

                        LoadPercentOfRowColumnDataTable(DbContext, GLReportTemplateID, PercentOfRowColumnDataTable, RowsDataTable, ColumnsDataTable)

                        LoadRelatedRowsDataTable(DbContext, GLReportTemplateID, RelatedRowsDataTable, RowsDataTable)

                        LoadDepartmentTeamPresetsDataTable(DbContext, GLReportTemplateID, DepartmentTeamPresetsDataTable)

                        LoadOfficePresetsDataTable(DbContext, GLReportTemplateID, OfficePresetsDataTable)

                    End If

                End Using

            End If

        End Sub
        Public Function LoadDashboardLayout(Session As AdvantageFramework.Security.Session, GLReportTemplateID As Integer) As Byte()

            Dim DashboardLayout As Byte() = Nothing
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing

            If GLReportTemplateID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, GLReportTemplateID)

                    If GLReportTemplate IsNot Nothing Then

                        DashboardLayout = GLReportTemplate.DashboardLayout

                    End If

                End Using

            End If

            LoadDashboardLayout = DashboardLayout

        End Function
        Public Sub LoadGeneralLedgerDetailByAccountReportSettings(ByVal Session As AdvantageFramework.Security.Session, ByVal IsUserDefinedReport As Boolean, ByRef IncludeOffices As Boolean, ByRef IncludeDepartments As Boolean, ByRef IncludeOthers As Boolean, ByRef IncludeBases As Boolean, ByRef IncludeAccountTypes As Boolean)

            'Objects
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    IncludeBases = IsUsingSegmentType(GeneralLedgerConfig, 1)
                    IncludeOffices = IsUsingSegmentType(GeneralLedgerConfig, 2)
                    IncludeDepartments = IsUsingSegmentType(GeneralLedgerConfig, 3)
                    IncludeOthers = IsUsingSegmentType(GeneralLedgerConfig, 4)

                End If

            End Using

            If IsUserDefinedReport Then

                IncludeBases = False
                IncludeOthers = False
                IncludeAccountTypes = False

            Else

                IncludeAccountTypes = True

            End If

        End Sub
        Private Function IsUsingSegmentType(ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig, ByVal SegmentType As Long) As Boolean

            'objects
            Dim UsingSegment As Boolean = False

            If GeneralLedgerConfig.Segment1Type.GetValueOrDefault(-1) = SegmentType Then

                If Not String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment1Format) Then

                    UsingSegment = True

                End If

            ElseIf GeneralLedgerConfig.Segment2Type.GetValueOrDefault(-1) = SegmentType Then

                If Not String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment2Format) Then

                    UsingSegment = True

                End If

            ElseIf GeneralLedgerConfig.Segment3Type.GetValueOrDefault(-1) = SegmentType Then

                If Not String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment3Format) Then

                    UsingSegment = True

                End If

            ElseIf GeneralLedgerConfig.Segment4Type.GetValueOrDefault(-1) = SegmentType Then

                If Not String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment4Format) Then

                    UsingSegment = True

                End If

            End If

            Return UsingSegment

        End Function

#End Region

    End Module

End Namespace

