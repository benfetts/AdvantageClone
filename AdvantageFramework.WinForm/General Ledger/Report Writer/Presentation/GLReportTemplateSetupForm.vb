Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _RowsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _ColumnsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _RelatedRowsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _OfficePresetsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _DepartmentTeamPresetsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _PercentOfRowColumnDataTable As System.Data.DataTable = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _GLReportTemplateID As Integer = 0
        Private _ReportPostPeriodCode As String = ""
        Private _PrintColumnHeadingsOnEveryPage As Boolean = False
        Private _SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions = AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions.AccountCode
        Private _GLReportUserDefReportID As Integer = 0
        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement
        Private _OptionsAndPresetsChanged As Boolean = False
        'Private _DashboardDataTable As System.Data.DataTable = Nothing
        Private _RichEditDocumentServer As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Private _CurrencyCode As String = Nothing
		Private _ReciprocalExchangeRate As Nullable(Of Decimal) = Nothing
		Private _CurrencyCodeHome As String = Nothing
        Private _CurrencySymbol As String = Nothing
        Private _CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
        Private _HasCheckedCurrencyComparsion As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property GLReportTemplateID As Integer
            Get
                GLReportTemplateID = _GLReportTemplateID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal GLReportTemplateID As Integer, ByVal ReportType As ReportTypes)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GLReportTemplateID = GLReportTemplateID

        End Sub
        Private Sub LoadReportTemplate()

            'objects
            Dim StatementDataTable As System.Data.DataTable = Nothing
            Dim DashboardDataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim AccountGroupList As Generic.List(Of AdvantageFramework.Database.Entities.AccountGroup) = Nothing
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim TotalAmount As Decimal = 0
            Dim GLADescriptions As Generic.List(Of String) = Nothing
            Dim SubGLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim UserEntryChanged As Boolean = False
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim FullGLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim GLDatas As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLData) = Nothing
            Dim StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.ShowWaitForm("Calculating...")

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                Try

                    ReportPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = _ReportPostPeriodCode)

                Catch ex As Exception
                    ReportPostPeriod = Nothing
                End Try

				StatementDataTable = BuildStatementDataTable(_ColumnsDataTable)

				If ReportPostPeriod IsNot Nothing Then

                    UserEntryChanged = Me.UserEntryChanged

                    _CurrencyDetail = Nothing
                    _HasCheckedCurrencyComparsion = False

                    DashboardDataTable = BuildDashboardDataTable(DbContext, _ReportType)
                    '
                    '========================================
                    '========================================
                    '
                    DataRow = StatementDataTable.NewRow

                    DataRow(StatementFields.RowID.ToString) = -3
                    DataRow(StatementFields.Description.ToString) = ""

                    For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = System.DBNull.Value

                    Next

                    StatementDataTable.Rows.Add(DataRow)
                    '
                    '========================================
                    '========================================
                    '
                    DataRow = StatementDataTable.NewRow

                    DataRow(StatementFields.RowID.ToString) = -2
                    DataRow(StatementFields.Description.ToString) = "" 'If(Not String.IsNullOrWhiteSpace(_CurrencyCode), "Currency Code: " & _CurrencyCode, "")

                    For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = System.DBNull.Value

                    Next

                    StatementDataTable.Rows.Add(DataRow)
                    '
                    '========================================
                    '========================================
                    '
                    DataRow = StatementDataTable.NewRow

                    DataRow(StatementFields.RowID.ToString) = -1
                    DataRow(StatementFields.Description.ToString) = ""

                    For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = System.DBNull.Value

                    Next


                    StatementDataTable.Rows.Add(DataRow)
                    '
                    '========================================
                    '========================================
                    '
                    EmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).Include("Office").Include("Office.GeneralLedgerOfficeCrossReferences").ToList

                    If _RowsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(RowFields.Type.ToString) = CInt(RowTypes.Account) OrElse DR(RowFields.Type.ToString) = CInt(RowTypes.Total)) Then

                        FullGLACoreList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).ToList

                        StartingPostPeriod = LoadStartingPostPeriodForReport(_RowsDataTable, _ColumnsDataTable, ReportPostPeriod, PostPeriods)

                        Try

                            GLDatas = DbContext.Database.SqlQuery(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLData)(String.Format("SELECT " &
                                                                                                                                                        "[GLACode] = GLS.GLSCODE, " &
                                                                                                                                                        "[Actual] = CAST((GLS.GLSCREDIT + GLS.GLSDEBIT) AS decimal(18,2)), " &
                                                                                                                                                        "[Budget1] = CAST(GLS.GLSBUDGET  AS decimal(18,2)), " &
                                                                                                                                                        "[Budget2] = CAST(GLS.GLSBUD2  AS decimal(18,2)), " &
                                                                                                                                                        "[Budget3] = CAST(GLS.GLSBUD3  AS decimal(18,2)), " &
                                                                                                                                                        "[Budget4] = CAST(GLS.GLSBUD4  AS decimal(18,2)), " &
                                                                                                                                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                                                                                                                                        "[Year] = CASE WHEN ISNUMERIC(PP.PPGLYEAR) = 1 THEN CAST(PP.PPGLYEAR AS int) ELSE CAST(0 AS int) END, " &
                                                                                                                                                        "[Month] = CASE WHEN PP.PPGLMONTH < 13 AND PP.PPGLMONTH IS NOT NULL THEN CAST(PP.PPGLMONTH AS int) ELSE CAST(13 AS int) END, " &
                                                                                                                                                        "[OfficeCode] = O.OFFICE_CODE " &
                                                                                                                                                    "FROM " &
                                                                                                                                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                                                                                                                                        "[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = GLS.GLSPP INNER JOIN " &
                                                                                                                                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                                                                                                                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                                                                                                                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                                                                                                                                    "WHERE " &
                                                                                                                                                        "PP.PPGLYEAR >= {0} AND PP.PPGLYEAR <= {1}", StartingPostPeriod.Year, ReportPostPeriod.Year)).ToList

                        Catch ex As Exception

                        End Try

                    End If

                    For Each RowDataRow In _RowsDataTable.Select("1=1", RowFields.RowIndex.ToString)

                        GLADescriptions = New Generic.List(Of String)

                        If RowDataRow(RowFields.IsVisible.ToString) Then

                            If RowDataRow(RowFields.Type.ToString) = CInt(RowTypes.Account) Then

                                If RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountType Then

                                    GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(Entity) Entity.Type = RowDataRow(RowFields.AccountType.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                    If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.Description Then

                                        DataRow = StatementDataTable.NewRow

                                        DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                            DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                            If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                            End If

                                        Next

                                        If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                            StatementDataTable.Rows.Add(DataRow)

                                        End If

                                    Else

                                        If _SortRowsBy = SortRowsByOptions.BaseAccountCode Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.BaseCode).ToList

                                        ElseIf _SortRowsBy = SortRowsByOptions.AccountDescription Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Description).ToList

                                        Else

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Code).ToList

                                        End If

                                        For Each GLACore In GLACoreList

                                            If GLADescriptions.Contains(GLACore.Description) = False Then

                                                DataRow = StatementDataTable.NewRow

                                                DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                                DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                                If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.ToString, GLACore.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Code, GLACore.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Description, GLACore.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                End If

                                                If RowDataRow(RowFields.RollUp.ToString) Then

                                                    GLADescriptions.Add(GLACore.Description)

                                                    SubGLACoreList = GLACoreList.Where(Function(ECore) ECore.Description = GLACore.Description).ToList

                                                Else

                                                    SubGLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore})

                                                End If

                                                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, SubGLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                                    If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                                    End If

                                                Next

                                                If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                                    StatementDataTable.Rows.Add(DataRow)

                                                End If

                                            End If

                                        Next

                                    End If

                                    LoadDataForDashboard(DbContext, RowDataRow, GLACoreList, ReportPostPeriod, _ReportType, DashboardDataTable)

                                ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountGroup Then

                                    GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                                    AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, RowDataRow(RowFields.AccountGroupCode.ToString))

                                    If AccountGroup IsNot Nothing Then

                                        For Each AccountGroupDetail In AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, AccountGroup.Code).ToList

                                            If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                                                If AccountGroup.Type = 1 Then

                                                    Try

                                                        GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = AccountGroupDetail.GLACode)

                                                    Catch ex As Exception
                                                        GLACore = Nothing
                                                    End Try

                                                    If GLACore IsNot Nothing Then

                                                        GLACoreList.Add(GLACore)

                                                    End If

                                                ElseIf AccountGroup.Type = 2 Then

                                                    GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode = AccountGroupDetail.GLACode))

                                                End If

                                            End If

                                            If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                                                If AccountGroup.Type = 1 Then

                                                    GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo))

                                                ElseIf AccountGroup.Type = 2 Then

                                                    GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode >= AccountGroupDetail.GLACodeFrom AndAlso Entity.BaseCode <= AccountGroupDetail.GLACodeTo))

                                                End If

                                            End If

                                        Next

                                        GLACoreList = FilterGLAsByPresets(GLACoreList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                        If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.Description Then

                                            DataRow = StatementDataTable.NewRow

                                            DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                            DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                            DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                            For Each ColumnDataRow In _ColumnsDataTable.Select()

                                                DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                                If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                                End If

                                            Next

                                            If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                                StatementDataTable.Rows.Add(DataRow)

                                            End If

                                            'ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                            '    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(AccountGroup.ToString, AccountGroup.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                            'ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                            '    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(AccountGroup.Code, AccountGroup.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                            'ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                            '    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(AccountGroup.Description, AccountGroup.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        Else

                                            If _SortRowsBy = SortRowsByOptions.BaseAccountCode Then

                                                GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.BaseCode).ToList

                                            ElseIf _SortRowsBy = SortRowsByOptions.AccountDescription Then

                                                GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Description).ToList

                                            Else

                                                GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Code).ToList

                                            End If

                                            For Each GLACore In GLACoreList

                                                If GLADescriptions.Contains(GLACore.Description) = False Then

                                                    DataRow = StatementDataTable.NewRow

                                                    DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                                    DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                                    If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.ToString, GLACore.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                    ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Code, GLACore.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                    ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Description, GLACore.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                    End If

                                                    If RowDataRow(RowFields.RollUp.ToString) Then

                                                        GLADescriptions.Add(GLACore.Description)

                                                        SubGLACoreList = GLACoreList.Where(Function(ECore) ECore.Description = GLACore.Description).ToList

                                                    Else

                                                        SubGLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore})

                                                    End If

                                                    For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, SubGLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                                        If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                            DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                                        End If

                                                    Next

                                                    If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                                        StatementDataTable.Rows.Add(DataRow)

                                                    End If

                                                End If

                                            Next

                                        End If

                                        LoadDataForDashboard(DbContext, RowDataRow, GLACoreList, ReportPostPeriod, _ReportType, DashboardDataTable)

                                    End If

                                ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Account Then

                                    Try

                                        GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = RowDataRow(RowFields.GLACode.ToString))

                                    Catch ex As Exception
                                        GLACore = Nothing
                                    End Try

                                    If GLACore IsNot Nothing AndAlso AllowGLAccount(GLACore, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList) Then

                                        DataRow = StatementDataTable.NewRow

                                        DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                        If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.Description Then

                                            DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                            DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.ToString, GLACore.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                            DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Code, GLACore.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                            DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Description, GLACore.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        End If

                                        For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                            DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore}), RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                            If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                            End If

                                        Next

                                        If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                            StatementDataTable.Rows.Add(DataRow)

                                        End If

                                        LoadDataForDashboard(DbContext, RowDataRow, New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore}), ReportPostPeriod, _ReportType, DashboardDataTable)

                                    End If

                                ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountRange Then

                                    If RowDataRow(RowFields.UseBaseAccountCodes.ToString) Then

                                        GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.BaseCode >= RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.BaseCode <= RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                    Else

                                        GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.Code >= RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.Code <= RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                    End If

                                    If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.Description Then

                                        DataRow = StatementDataTable.NewRow

                                        DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                            DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                            If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                            End If

                                        Next

                                        If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                            StatementDataTable.Rows.Add(DataRow)

                                        End If

                                    Else

                                        If _SortRowsBy = SortRowsByOptions.BaseAccountCode Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.BaseCode).ToList

                                        ElseIf _SortRowsBy = SortRowsByOptions.AccountDescription Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Description).ToList

                                        Else

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Code).ToList

                                        End If

                                        For Each GLACore In GLACoreList

                                            If GLADescriptions.Contains(GLACore.Description) = False Then

                                                DataRow = StatementDataTable.NewRow

                                                DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                                DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                                If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.ToString, GLACore.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Code, GLACore.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Description, GLACore.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                End If

                                                If RowDataRow(RowFields.RollUp.ToString) Then

                                                    GLADescriptions.Add(GLACore.Description)

                                                    SubGLACoreList = GLACoreList.Where(Function(ECore) ECore.Description = GLACore.Description).ToList

                                                Else

                                                    SubGLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore})

                                                End If

                                                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, SubGLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                                    If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                                    End If

                                                Next

                                                If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                                    StatementDataTable.Rows.Add(DataRow)

                                                End If

                                            End If

                                        Next

                                    End If

                                    LoadDataForDashboard(DbContext, RowDataRow, GLACoreList, ReportPostPeriod, _ReportType, DashboardDataTable)

                                ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Wildcard Then

                                    GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.Code.Contains(RowDataRow(RowFields.Wildcard.ToString))).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                    If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.Description Then

                                        DataRow = StatementDataTable.NewRow

                                        DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                        DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                        DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                        For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                            DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                            If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                            End If

                                        Next

                                        If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                            StatementDataTable.Rows.Add(DataRow)

                                        End If

                                    Else

                                        If _SortRowsBy = SortRowsByOptions.BaseAccountCode Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.BaseCode).ToList

                                        ElseIf _SortRowsBy = SortRowsByOptions.AccountDescription Then

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Description).ToList

                                        Else

                                            GLACoreList = GLACoreList.OrderBy(Function(Entity) Entity.Code).ToList

                                        End If

                                        For Each GLACore In GLACoreList

                                            If GLADescriptions.Contains(GLACore.Description) = False Then

                                                DataRow = StatementDataTable.NewRow

                                                DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                                DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                                If RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.FullAccount Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.ToString, GLACore.ToString.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountCode Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Code, GLACore.Code.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                ElseIf RowDataRow(RowFields.DisplayType.ToString) = DisplayTypes.AccountDescription Then

                                                    DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(GLACore.Description, GLACore.Description.Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                                End If

                                                If RowDataRow(RowFields.RollUp.ToString) Then

                                                    GLADescriptions.Add(GLACore.Description)

                                                    SubGLACoreList = GLACoreList.Where(Function(ECore) ECore.Description = GLACore.Description).ToList

                                                Else

                                                    SubGLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore})

                                                End If

                                                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForAccounts(DbContext, SubGLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                                                    If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                                    End If

                                                Next

                                                If RowDataRow(RowFields.SuppressIfAllZeros.ToString) = False OrElse HasDataOnDataRow(DataRow) Then

                                                    StatementDataTable.Rows.Add(DataRow)

                                                End If

                                            End If

                                        Next

                                    End If

                                    LoadDataForDashboard(DbContext, RowDataRow, GLACoreList, ReportPostPeriod, _ReportType, DashboardDataTable)

                                End If

                            ElseIf RowDataRow(RowFields.Type.ToString) = CInt(RowTypes.Total) Then

                                DataRow = StatementDataTable.NewRow

                                DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = LoadDataForTotalRow(DbContext, StatementDataTable, RowDataRow, ColumnDataRow, ReportPostPeriod,
                                                                                                             _ReportType, EmployeeOfficeList, PostPeriods, FullGLACoreList, GLDatas)

                                    If RowDataRow(RowFields.BalanceType.ToString) = BalanceTypes.Credit Then

                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = DataRow(ColumnDataRow(ColumnFields.Name.ToString)) * -1

                                    End If

                                Next

                                StatementDataTable.Rows.Add(DataRow)

                            Else

                                DataRow = StatementDataTable.NewRow

                                DataRow(StatementFields.RowID.ToString) = RowDataRow(RowFields.ID.ToString)
                                DataRow(StatementFields.Sort.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                                DataRow(StatementFields.Description.ToString) = AdvantageFramework.StringUtilities.PadWithCharacter(RowDataRow(RowFields.Description.ToString), CStr(RowDataRow(RowFields.Description.ToString)).Length + RowDataRow(RowFields.IndentSpaces.ToString), " ", True, False)

                                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                                    DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = System.DBNull.Value

                                Next

                                StatementDataTable.Rows.Add(DataRow)

                            End If

                        End If

                    Next

                    For Each ColumnDataRow In _ColumnsDataTable.Select(ColumnFields.Type.ToString & " = " & ColumnTypes.PercentOfRow, ColumnFields.ColumnIndex.ToString)

                        For Each PercentOfRowColumnDataRow In _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & ColumnDataRow(ColumnFields.ID.ToString))

                            If IsDBNull(PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString)) = False Then

                                Try

                                    TotalAmount = StatementDataTable.Compute("Sum(" & ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString) & ")", StatementFields.RowID.ToString & " = " & PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString))

                                Catch ex As Exception
                                    TotalAmount = 0
                                End Try

                                For Each DataRow In StatementDataTable.Select(StatementFields.RowID.ToString & " = " & PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowID.ToString))

                                    Try

                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = (DataRow(ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString)) / TotalAmount)

                                    Catch ex As Exception
                                        DataRow(ColumnDataRow(ColumnFields.Name.ToString)) = 0
                                    End Try

                                Next

                            End If

                        Next

                    Next

                End If

                DataGridViewStatement_Statement.CurrentView.BeginUpdate()

                StatementDataTable.DefaultView.Sort = StatementFields.Sort.ToString

                StatementDataTable = StatementDataTable.DefaultView.ToTable

                DataGridViewStatement_Statement.ClearGridCustomization()

                DataGridViewStatement_Statement.DataSource = StatementDataTable

                If UserEntryChanged Then

                    DataGridViewStatement_Statement.SetUserEntryChanged()

                End If

                For Each GridColumn In DataGridViewStatement_Statement.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = StatementFields.Description.ToString Then

                        GridColumn.MinWidth = 250
                        GridColumn.Width = 250
                        GridColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                    Else

                        GridColumn.MinWidth = 150
                        GridColumn.Width = 150

                    End If

                    Try

                        ColumnDataRow = _ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & GridColumn.FieldName & "'").SingleOrDefault

                    Catch ex As Exception
                        ColumnDataRow = Nothing
                    End Try

                    If ColumnDataRow IsNot Nothing Then

                        GridColumn.Visible = ColumnDataRow(ColumnFields.IsVisible.ToString)

                    Else

                        GridColumn.Visible = True

                    End If

                Next

                DataGridViewStatement_Statement.MakeColumnNotVisible(StatementFields.ID.ToString)
                DataGridViewStatement_Statement.MakeColumnNotVisible(StatementFields.RowID.ToString)
                DataGridViewStatement_Statement.MakeColumnNotVisible(StatementFields.Sort.ToString)

                DataGridViewStatement_Statement.OptionsView.ShowIndicator = False
                DataGridViewStatement_Statement.CurrentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
                DataGridViewStatement_Statement.OptionsSelection.EnableAppearanceFocusedCell = False
                DataGridViewStatement_Statement.OptionsSelection.EnableAppearanceFocusedRow = False
                DataGridViewStatement_Statement.OptionsSelection.EnableAppearanceHideSelection = False
                DataGridViewStatement_Statement.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False
                DataGridViewStatement_Statement.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False
                DataGridViewStatement_Statement.OptionsView.ShowFooter = False
                DataGridViewStatement_Statement.OptionsView.ShowColumnHeaders = False
                DataGridViewStatement_Statement.OptionsView.ShowViewCaption = False
                DataGridViewStatement_Statement.AlwaysForceShowRowSelectionOnUserInput = False

                DataGridViewStatement_Statement.OptionsPrint.PrintVertLines = False
                DataGridViewStatement_Statement.OptionsPrint.PrintHorzLines = False
                DataGridViewStatement_Statement.OptionsPrint.PrintHeader = False
                DataGridViewStatement_Statement.OptionsPrint.PrintFooter = False

                DataGridViewStatement_Statement.CurrentView.EndUpdate()

                LabelItemCurrency_Code.Text = If(String.IsNullOrWhiteSpace(_CurrencyCode), _CurrencyCodeHome, _CurrencyCode)

                SetCurrencySymbol()

                If String.IsNullOrWhiteSpace(_CurrencyCode) OrElse (_CurrencyCode = _CurrencyCodeHome) Then

                    LabelItemCurrency_Rate.Text = Nothing

                Else

					LabelItemCurrency_Rate.Text = _ReciprocalExchangeRate.GetValueOrDefault(0)

				End If

                '_DashboardDataTable = DashboardDataTable

                LoadDashboard(StatementDataTable)

                DbContext.Database.Connection.Close()

            End Using

            Me.CloseWaitForm()

        End Sub
        Private Function LoadDataForAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                             ByVal RowDataRow As System.Data.DataRow, ByVal ColumnDataRow As System.Data.DataRow,
                                             ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                             ByVal ReportType As ReportTypes, ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                             ByVal GLDatas As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLData)) As Decimal

            'objects
            Dim Amount As Decimal = 0
            Dim StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim EndingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim SQLString As String = ""
            Dim DataOption As DataOptions = DataOptions.EndingBalance
            Dim DataCalculation As DataCalculations = DataCalculations.YearToDate
            Dim OfficeCode As String = ""
            Dim DoDatabaseQuery As Boolean = True
            Dim GLACodes() As String = Nothing

            If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data Then

                DataOption = RowDataRow(RowFields.DataOption.ToString)
                DataCalculation = RowDataRow(RowFields.DataCalculation.ToString)
                OfficeCode = If(IsDBNull(ColumnDataRow(ColumnFields.OfficeCode.ToString)), "", ColumnDataRow(ColumnFields.OfficeCode.ToString))

                If ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) Then

                    DataOption = ColumnDataRow(ColumnFields.DataOption.ToString)
                    DataCalculation = ColumnDataRow(ColumnFields.DataCalculation.ToString)

                End If

                LoadStartAndEndingPostPeriods(RowDataRow, ColumnDataRow, ReportPostPeriod, DataOption, PostPeriods, StartingPostPeriod, EndingPostPeriod)

                If StartingPostPeriod IsNot Nothing AndAlso EndingPostPeriod IsNot Nothing Then

                    If StartingPostPeriod.Code = EndingPostPeriod.Code Then

                        If StartingPostPeriod.Code > ReportPostPeriod.Code Then

                            DoDatabaseQuery = False

                        End If

                    Else

                        If StartingPostPeriod.Code > ReportPostPeriod.Code Then

                            DoDatabaseQuery = False

                        ElseIf EndingPostPeriod.Code > ReportPostPeriod.Code Then

                            EndingPostPeriod = ReportPostPeriod

                        End If

                    End If

                Else

                    DoDatabaseQuery = False

                End If

                If DoDatabaseQuery Then

                    GLACodes = GLACoreList.Select(Function(ECore) ECore.Code).ToArray

                    If String.IsNullOrWhiteSpace(_CurrencyCode) Then

                        _CurrencyCode = _CurrencyCodeHome

                    End If

                    'SQLString = BuildSQLString(GLACoreList, ColumnDataRow(ColumnFields.DataType.ToString), DataCalculation, StartingPostPeriod, EndingPostPeriod, OfficeCode)

                    Try

                        'Amount = DbContext.Database.SqlQuery(Of Decimal)(SQLString).FirstOrDefault

                        If ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual Then

                            If String.IsNullOrEmpty(OfficeCode) = False Then

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Actual).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Actual).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Actual).Sum

                                End If

                            Else

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))).Select(Function(Entity) Entity.Actual).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code).Select(Function(Entity) Entity.Actual).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))))).Select(Function(Entity) Entity.Actual).Sum

                                End If

                            End If

                        ElseIf ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget1 Then

                            If String.IsNullOrEmpty(OfficeCode) = False Then

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget1).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget1).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget1).Sum

                                End If

                            Else

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))).Select(Function(Entity) Entity.Budget1).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code).Select(Function(Entity) Entity.Budget1).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))))).Select(Function(Entity) Entity.Budget1).Sum

                                End If

                            End If

                        ElseIf ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget2 Then

                            If String.IsNullOrEmpty(OfficeCode) = False Then

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget2).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget2).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget2).Sum

                                End If

                            Else

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))).Select(Function(Entity) Entity.Budget2).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code).Select(Function(Entity) Entity.Budget2).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))))).Select(Function(Entity) Entity.Budget2).Sum

                                End If

                            End If

                        ElseIf ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget3 Then

                            If String.IsNullOrEmpty(OfficeCode) = False Then

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget3).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget3).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget3).Sum

                                End If

                            Else

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))).Select(Function(Entity) Entity.Budget3).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code).Select(Function(Entity) Entity.Budget3).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))))).Select(Function(Entity) Entity.Budget3).Sum

                                End If

                            End If

                        ElseIf ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget4 Then

                            If String.IsNullOrEmpty(OfficeCode) = False Then

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget4).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget4).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))) AndAlso Entity.OfficeCode = OfficeCode).Select(Function(Entity) Entity.Budget4).Sum

                                End If

                            Else

                                If DataCalculation = DataCalculations.YearToDate Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))).Select(Function(Entity) Entity.Budget4).Sum

                                ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso Entity.PostPeriodCode >= StartingPostPeriod.Code AndAlso Entity.PostPeriodCode <= EndingPostPeriod.Code).Select(Function(Entity) Entity.Budget4).Sum

                                ElseIf DataCalculation = DataCalculations.All Then

                                    Amount = GLDatas.Where(Function(Entity) GLACodes.Contains(Entity.GLACode) AndAlso (Entity.Year < CInt(EndingPostPeriod.Year) OrElse (Entity.Year = CInt(EndingPostPeriod.Year) AndAlso Entity.Month <= CInt(EndingPostPeriod.Month.GetValueOrDefault(0))))).Select(Function(Entity) Entity.Budget4).Sum

                                End If

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End If

            Amount = ConvertCurrency(DbContext, Amount)

            LoadDataForAccounts = Amount

        End Function
        Private Function BuildSQLString(ByVal GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount), ByVal ColumnDataType As ColumnDataTypes,
                                        ByVal DataCalculation As DataCalculations, ByVal StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                        ByVal EndingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod, ByVal OfficeCode As String) As String

            'objects
            Dim SQLString As String = ""

            If ColumnDataType = ColumnDataTypes.Actual Then

                SQLString = _SQLActualDataPull

            ElseIf ColumnDataType = ColumnDataTypes.Budget1 Then

                SQLString = _SQLBudget1DataPull

            ElseIf ColumnDataType = ColumnDataTypes.Budget2 Then

                SQLString = _SQLBudget2DataPull

            ElseIf ColumnDataType = ColumnDataTypes.Budget3 Then

                SQLString = _SQLBudget3DataPull

            ElseIf ColumnDataType = ColumnDataTypes.Budget4 Then

                SQLString = _SQLBudget4DataPull

            End If

            If DataCalculation = DataCalculations.YearToDate Then

                SQLString = SQLString & String.Format(_SQLYTDWhereClause, Join(GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '"), CInt(EndingPostPeriod.Year), CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))

            ElseIf DataCalculation = DataCalculations.SelectedPeriod Then

                SQLString = SQLString & String.Format(_SQLSelectedPeriodWhereClause, Join(GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '"), StartingPostPeriod.Code, EndingPostPeriod.Code)

            ElseIf DataCalculation = DataCalculations.All Then

                SQLString = SQLString & String.Format(_SQLWhereClause, Join(GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '"), CInt(EndingPostPeriod.Year), CInt(EndingPostPeriod.Month.GetValueOrDefault(0)))

            End If

            If String.IsNullOrEmpty(OfficeCode) = False Then

                SQLString = SQLString & String.Format(_SQLOfficeCodeWhereClauseExtension, OfficeCode)

            End If

            BuildSQLString = SQLString

        End Function
        Private Function LoadDataForTotalRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             StatementDataTable As System.Data.DataTable,
                                             ByVal TotalRowDataRow As System.Data.DataRow,
                                             ByVal ColumnDataRow As System.Data.DataRow, ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                             ByVal ReportType As ReportTypes, ByVal EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice),
                                             ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                             ByVal FullGLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                             ByVal GLDatas As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLData)) As Decimal

            'objects
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing
            Dim GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim AccountGroupList As Generic.List(Of AdvantageFramework.Database.Entities.AccountGroup) = Nothing
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim Amount As Decimal = 0
            Dim TotalAmount As Decimal = 0
            Dim StatementDataRow As System.Data.DataRow = Nothing

            For Each RelatedRowDataRow In _RelatedRowsDataTable.Select(RelatedRowFields.RowID.ToString & " = " & TotalRowDataRow(RowFields.ID.ToString))

                Amount = 0

                Try

                    RowDataRow = _RowsDataTable.Rows.Find(RelatedRowDataRow(RelatedRowFields.RelatedRowID.ToString))

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                If RowDataRow IsNot Nothing Then

                    If RowDataRow(RowFields.Type.ToString) = CInt(RowTypes.Account) Then

                        If RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountType Then

                            GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(Entity) Entity.Type = RowDataRow(RowFields.AccountType.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            Amount = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                        ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountGroup Then

                            GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                            AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, RowDataRow(RowFields.AccountGroupCode.ToString))

                            If AccountGroup IsNot Nothing Then

                                For Each AccountGroupDetail In AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, AccountGroup.Code).ToList

                                    If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                                        If AccountGroup.Type = 1 Then

                                            Try

                                                GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = AccountGroupDetail.GLACode)

                                            Catch ex As Exception
                                                GLACore = Nothing
                                            End Try

                                            If GLACore IsNot Nothing Then

                                                GLACoreList.Add(GLACore)

                                            End If

                                        ElseIf AccountGroup.Type = 2 Then

                                            GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode = AccountGroupDetail.GLACode))

                                        End If

                                    End If

                                    If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                                        If AccountGroup.Type = 1 Then

                                            GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo))

                                        ElseIf AccountGroup.Type = 2 Then

                                            GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode >= AccountGroupDetail.GLACodeFrom AndAlso Entity.BaseCode <= AccountGroupDetail.GLACodeTo))

                                        End If

                                    End If

                                Next

                                GLACoreList = FilterGLAsByPresets(GLACoreList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                                Amount = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                            End If

                        ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Account Then

                            Try

                                GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = RowDataRow(RowFields.GLACode.ToString))

                            Catch ex As Exception
                                GLACore = Nothing
                            End Try

                            If GLACore IsNot Nothing AndAlso AllowGLAccount(GLACore, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList) Then

                                Amount = LoadDataForAccounts(DbContext, New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)({GLACore}), RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                            End If

                        ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountRange Then

                            If RowDataRow(RowFields.UseBaseAccountCodes.ToString) Then

                                GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.BaseCode >= RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.BaseCode <= RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            Else

                                GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.Code >= RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.Code <= RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            End If

                            Amount = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                        ElseIf RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Wildcard Then

                            GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.Code.Contains(RowDataRow(RowFields.Wildcard.ToString))).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            Amount = LoadDataForAccounts(DbContext, GLACoreList, RowDataRow, ColumnDataRow, ReportPostPeriod, _ReportType, PostPeriods, GLDatas)

                        End If

                    ElseIf RowDataRow(RowFields.Type.ToString) = CInt(RowTypes.Total) Then

                        Amount = LoadDataForTotalRow(DbContext, StatementDataTable, RowDataRow, ColumnDataRow, ReportPostPeriod, ReportType, EmployeeOfficeList, PostPeriods, FullGLACoreList, GLDatas)

                    End If

                End If

                If TotalRowDataRow(RowFields.TotalType.ToString) = TotalTypes.Adding Then

                    TotalAmount += Amount

                ElseIf TotalRowDataRow(RowFields.TotalType.ToString) = TotalTypes.Subtracting Then

                    If TotalAmount <> 0 Then

                        TotalAmount -= Amount

                    Else

                        TotalAmount = Amount

                    End If

                ElseIf TotalRowDataRow(RowFields.TotalType.ToString) = TotalTypes.Dividing Then

                    If TotalAmount <> 0 Then

                        Try

                            TotalAmount = Amount / TotalAmount

                        Catch ex As Exception
                            TotalAmount = TotalAmount
                        End Try

                    Else

                        TotalAmount = Amount

                    End If

                End If

            Next

            LoadDataForTotalRow = TotalAmount

        End Function
        Private Sub LoadDataForDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RowDataRow As System.Data.DataRow,
                                         ByVal GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount),
                                         ByVal ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                         ByVal ReportType As ReportTypes, ByVal DashboardDataTable As System.Data.DataTable)

            'objects
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            SQLString = GetDashboardSQLString(RowDataRow, ReportType)

            SQLConnection = DbContext.Database.Connection

            SQLString = String.Format(SQLString, RowDataRow(RowFields.Description.ToString), "'" & Join(GLACoreList.Select(Function(ECore) ECore.Code).Distinct.ToArray, "', '") & "'", ReportPostPeriod.Year, ReportPostPeriod.Month.GetValueOrDefault(0))

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.Fill(DataTable)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

            Try

                DashboardDataTable.Merge(DataTable, True)

            Catch ex As Exception
                DashboardDataTable = DataTable
            End Try

        End Sub
        Private Function HasDataOnDataRow(ByVal DataRow As System.Data.DataRow) As Boolean

            'objects
            Dim HasData As Boolean = False

            If _ColumnsDataTable.Select().Any Then

                For Each ColumnDataRow In _ColumnsDataTable.Select("1=1", ColumnFields.ColumnIndex.ToString)

                    If IsNumeric(DataRow(ColumnDataRow(ColumnFields.Name.ToString))) AndAlso CDec(DataRow(ColumnDataRow(ColumnFields.Name.ToString))) <> 0 Then

                        HasData = True
                        Exit For

                    End If

                Next

            Else

                HasData = True

            End If

            HasDataOnDataRow = HasData

        End Function
        Private Function GetRowData(ByVal RowData As Object) As Object

            'objects
            Dim NewRowData As Object = Nothing

            If TypeOf RowData Is System.DBNull Then

                NewRowData = Nothing

            Else

                NewRowData = RowData

            End If

            GetRowData = NewRowData

        End Function
        Private Sub ReportTemplateChanged()

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                DataGridViewStatement_Statement.SetUserEntryChanged()

            End If

        End Sub
        Private Sub SaveTemplate()

            'objects
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow = Nothing
            Dim GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn = Nothing
            Dim GLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation = Nothing
            Dim GLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation = Nothing
            Dim GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset = Nothing
            Dim GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim GLReportTemplateRowsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateRow) = Nothing
            Dim GLReportTemplateColumnsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateColumn) = Nothing
            Dim GLReportTemplateRowRelationsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateRowRelation) = Nothing
            Dim GLReportTemplatePctOfRowColumnRelationsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation) = Nothing
            Dim GLReportTemplateDepartmentTeamPresetsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset) = Nothing
            Dim GLReportTemplateOfficePresetsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset) = Nothing
            Dim DashboardLayoutMemoryStream As System.IO.MemoryStream = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim PercentOfRowColumnRowDataRow As System.Data.DataRow = Nothing
            Dim RelatedRowDataRow As System.Data.DataRow = Nothing
            Dim RRDataRow As System.Data.DataRow = Nothing
            Dim PctColumnDataRow As System.Data.DataRow = Nothing
            Dim PctRowDataRow As System.Data.DataRow = Nothing
            Dim PctRelatedRowDataRow As System.Data.DataRow = Nothing
            Dim OfficeDataRow As System.Data.DataRow = Nothing
            Dim DepartmentTeamDataRow As System.Data.DataRow = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DashboardLayoutMemoryStream = New System.IO.MemoryStream

                        If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                            DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(DashboardLayoutMemoryStream)

                        End If

                        If _GLReportTemplateID = 0 Then

                            GLReportTemplate = New AdvantageFramework.Database.Entities.GLReportTemplate

                            GLReportTemplate.Description = TextBoxTemplateDetails_TemplateName.Text
                            GLReportTemplate.DashboardLayout = DashboardLayoutMemoryStream.GetBuffer
                            GLReportTemplate.PostPeriodCode = _ReportPostPeriodCode
                            GLReportTemplate.ReportType = _ReportType
                            GLReportTemplate.GLReportUserDefReportID = _GLReportUserDefReportID
                            GLReportTemplate.PrintColumnHeadingsOnEveryPage = _PrintColumnHeadingsOnEveryPage
                            GLReportTemplate.SortRowsBy = _SortRowsBy

                            If AdvantageFramework.Database.Procedures.GLReportTemplate.Insert(DbContext, GLReportTemplate) Then

                                Saved = True

                            End If

                        Else

                            GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, _GLReportTemplateID)

                            If GLReportTemplate IsNot Nothing Then

                                GLReportTemplate.Description = TextBoxTemplateDetails_TemplateName.Text
                                GLReportTemplate.DashboardLayout = DashboardLayoutMemoryStream.GetBuffer
                                GLReportTemplate.PostPeriodCode = _ReportPostPeriodCode
                                GLReportTemplate.ReportType = _ReportType
                                GLReportTemplate.GLReportUserDefReportID = _GLReportUserDefReportID
                                GLReportTemplate.PrintColumnHeadingsOnEveryPage = _PrintColumnHeadingsOnEveryPage
                                GLReportTemplate.SortRowsBy = _SortRowsBy

                                If _CurrencyCode <> _CurrencyCodeHome Then

                                    GLReportTemplate.CurrencyCode = _CurrencyCode
                                    GLReportTemplate.CurrencyRate = _ReciprocalExchangeRate

                                Else

                                    GLReportTemplate.CurrencyCode = Nothing
                                    GLReportTemplate.CurrencyRate = Nothing

                                End If

                                If AdvantageFramework.Database.Procedures.GLReportTemplate.Update(DbContext, GLReportTemplate) Then

                                    Saved = True

                                End If

                            Else

                                Throw New Exception("The GL Report Template you are trying do update does not exist.")

                            End If

                        End If

                        If Saved Then

                            GLReportTemplateColumnsList = AdvantageFramework.Database.Procedures.GLReportTemplateColumn.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                            For Each ColumnDataRow In _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                Try

                                    GLReportTemplateColumn = GLReportTemplateColumnsList.SingleOrDefault(Function(Entity) Entity.ID = ColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString))

                                Catch ex As Exception
                                    GLReportTemplateColumn = Nothing
                                End Try

                                If GLReportTemplateColumn Is Nothing Then

                                    GLReportTemplateColumn = New AdvantageFramework.Database.Entities.GLReportTemplateColumn

                                Else

                                    GLReportTemplateColumnsList.Remove(GLReportTemplateColumn)

                                End If

                                GLReportTemplateColumn.GLReportTemplateID = GLReportTemplate.ID

                                GLReportTemplateColumn.Name = GetRowData(ColumnDataRow(ColumnFields.Name.ToString))
                                GLReportTemplateColumn.Description = GetRowData(ColumnDataRow(ColumnFields.Description.ToString))
                                GLReportTemplateColumn.ColumnIndex = GetRowData(ColumnDataRow(ColumnFields.ColumnIndex.ToString))
                                GLReportTemplateColumn.Type = GetRowData(ColumnDataRow(ColumnFields.Type.ToString))
                                GLReportTemplateColumn.DataType = GetRowData(ColumnDataRow(ColumnFields.DataType.ToString))
                                GLReportTemplateColumn.PeriodOption = GetRowData(ColumnDataRow(ColumnFields.PeriodOption.ToString))
                                GLReportTemplateColumn.PreviousYears = GetRowData(ColumnDataRow(ColumnFields.PreviousYears.ToString))
                                GLReportTemplateColumn.IsVisible = GetRowData(ColumnDataRow(ColumnFields.IsVisible.ToString))
                                GLReportTemplateColumn.Expression = GetRowData(ColumnDataRow(ColumnFields.Expression.ToString))
                                GLReportTemplateColumn.UnderlineColumnHeaders = GetRowData(ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString))
                                GLReportTemplateColumn.UseCurrencyFormat = GetRowData(ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString))
                                GLReportTemplateColumn.NumberOfDecimalPlaces = GetRowData(ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString))
                                GLReportTemplateColumn.Column1Name = GetRowData(ColumnDataRow(ColumnFields.Column1Name.ToString))
                                GLReportTemplateColumn.Column2Name = GetRowData(ColumnDataRow(ColumnFields.Column2Name.ToString))
                                GLReportTemplateColumn.PctOfRowColumnName = GetRowData(ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString))
                                GLReportTemplateColumn.OfficeCode = GetRowData(ColumnDataRow(ColumnFields.OfficeCode.ToString))
                                GLReportTemplateColumn.OverrideDataOptions = GetRowData(ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString))
                                GLReportTemplateColumn.DataOption = GetRowData(ColumnDataRow(ColumnFields.DataOption.ToString))
                                GLReportTemplateColumn.DataCalculation = GetRowData(ColumnDataRow(ColumnFields.DataCalculation.ToString))

                                If GLReportTemplateColumn.IsEntityBeingAdded() Then

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateColumn.Insert(DbContext, GLReportTemplateColumn)

                                Else

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateColumn.Update(DbContext, GLReportTemplateColumn)

                                End If

                                If Saved Then

                                    ColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString) = GLReportTemplateColumn.ID

                                Else

                                    Saved = False
                                    Exit For

                                End If

                            Next

                            If Saved Then

                                For Each GLReportTemplateColumn In GLReportTemplateColumnsList

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateColumn.Delete(DbContext, GLReportTemplateColumn)

                                    If Saved = False Then

                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                GLReportTemplateRowsList = AdvantageFramework.Database.Procedures.GLReportTemplateRow.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                For Each RowDataRow In _RowsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    Try

                                        GLReportTemplateRow = GLReportTemplateRowsList.SingleOrDefault(Function(Entity) Entity.ID = RowDataRow(RowFields.GLReportTemplateRowID.ToString))

                                    Catch ex As Exception
                                        GLReportTemplateRow = Nothing
                                    End Try

                                    If GLReportTemplateRow Is Nothing Then

                                        GLReportTemplateRow = New AdvantageFramework.Database.Entities.GLReportTemplateRow

                                    Else

                                        GLReportTemplateRowsList.Remove(GLReportTemplateRow)

                                    End If

                                    GLReportTemplateRow.GLReportTemplateID = GLReportTemplate.ID

                                    GLReportTemplateRow.Description = If(GetRowData(RowDataRow(RowFields.Description.ToString)) = Nothing, "", GetRowData(RowDataRow(RowFields.Description.ToString)))
                                    GLReportTemplateRow.RowIndex = GetRowData(RowDataRow(RowFields.RowIndex.ToString))
                                    GLReportTemplateRow.Type = GetRowData(RowDataRow(RowFields.Type.ToString))
                                    GLReportTemplateRow.BalanceType = GetRowData(RowDataRow(RowFields.BalanceType.ToString))
                                    GLReportTemplateRow.DisplayType = GetRowData(RowDataRow(RowFields.DisplayType.ToString))
                                    GLReportTemplateRow.TotalType = GetRowData(RowDataRow(RowFields.TotalType.ToString))
                                    GLReportTemplateRow.LinkType = GetRowData(RowDataRow(RowFields.LinkType.ToString))
                                    GLReportTemplateRow.AccountType = GetRowData(RowDataRow(RowFields.AccountType.ToString))
                                    GLReportTemplateRow.AccountGroupCode = GetRowData(RowDataRow(RowFields.AccountGroupCode.ToString))
                                    GLReportTemplateRow.GLACode = GetRowData(RowDataRow(RowFields.GLACode.ToString))
                                    GLReportTemplateRow.UseBaseAccountCodes = GetRowData(RowDataRow(RowFields.UseBaseAccountCodes.ToString))
                                    GLReportTemplateRow.GLACodeRangeStart = GetRowData(RowDataRow(RowFields.GLACodeRangeStart.ToString))
                                    GLReportTemplateRow.GLACodeRangeTo = GetRowData(RowDataRow(RowFields.GLACodeRangeTo.ToString))
                                    GLReportTemplateRow.Wildcard = GetRowData(RowDataRow(RowFields.Wildcard.ToString))
                                    GLReportTemplateRow.IndentSpaces = GetRowData(RowDataRow(RowFields.IndentSpaces.ToString))
                                    GLReportTemplateRow.UnderlineAmount = GetRowData(RowDataRow(RowFields.UnderlineAmount.ToString))
                                    GLReportTemplateRow.DoubleUnderlineAmount = GetRowData(RowDataRow(RowFields.DoubleUnderlineAmount.ToString))
                                    GLReportTemplateRow.IsBold = GetRowData(RowDataRow(RowFields.IsBold.ToString))
									GLReportTemplateRow.UseCurrencyFormat = GetRowData(RowDataRow(RowFields.UseCurrencyFormat.ToString))
									GLReportTemplateRow.NumberOfDecimalPlaces = GetRowData(RowDataRow(RowFields.NumberOfDecimalPlaces.ToString))
									GLReportTemplateRow.SuppressIfAllZeros = GetRowData(RowDataRow(RowFields.SuppressIfAllZeros.ToString))
									GLReportTemplateRow.RollUp = GetRowData(RowDataRow(RowFields.RollUp.ToString))
                                    GLReportTemplateRow.DataOption = GetRowData(RowDataRow(RowFields.DataOption.ToString))
									GLReportTemplateRow.DataCalculation = GetRowData(RowDataRow(RowFields.DataCalculation.ToString))
									GLReportTemplateRow.IsVisible = GetRowData(RowDataRow(RowFields.IsVisible.ToString))

									If GLReportTemplateRow.IsEntityBeingAdded() Then

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplateRow.Insert(DbContext, GLReportTemplateRow)

                                    Else

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplateRow.Update(DbContext, GLReportTemplateRow)

                                    End If

                                    If Saved Then

                                        RowDataRow(RowFields.GLReportTemplateRowID.ToString) = GLReportTemplateRow.ID

                                    Else

                                        Saved = False
                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                For Each GLReportTemplateRow In GLReportTemplateRowsList

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateRow.Delete(DbContext, GLReportTemplateRow)

                                    If Saved = False Then

                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID)

                                For Each PercentOfRowColumnRowDataRow In _PercentOfRowColumnDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    GLReportTemplatePctOfRowColumnRelation = New AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation

                                    Try

                                        PctColumnDataRow = _ColumnsDataTable.Select(ColumnFields.ID.ToString & " = " & PercentOfRowColumnRowDataRow(PercentOfRowColumnFields.ColumnID.ToString)).SingleOrDefault

                                    Catch ex As Exception
                                        PctColumnDataRow = Nothing
                                    End Try

                                    If PctColumnDataRow IsNot Nothing AndAlso IsNumeric(PctColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString)) AndAlso CInt(PctColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString)) > 0 Then

                                        GLReportTemplatePctOfRowColumnRelation.GLReportTemplateID = GLReportTemplate.ID
                                        GLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID = GetRowData(PctColumnDataRow(ColumnFields.GLReportTemplateColumnID.ToString))
                                        GLReportTemplatePctOfRowColumnRelation.RowIndex = GetRowData(PercentOfRowColumnRowDataRow(PercentOfRowColumnFields.RowIndex.ToString))
                                        GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex = GetRowData(PercentOfRowColumnRowDataRow(PercentOfRowColumnFields.PercentOfRowIndex.ToString))

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.Insert(DbContext, GLReportTemplatePctOfRowColumnRelation)

                                        If Saved = False Then

                                            Exit For

                                        End If

                                    End If

                                Next

                            End If

                            If Saved Then

                                AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.DeleteByGLReportTemplateID(DbContext, GLReportTemplate.ID)

                                For Each RelatedRowDataRow In _RelatedRowsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    Try

                                        RRDataRow = _RowsDataTable.Select(RowFields.ID.ToString & " = " & RelatedRowDataRow(RelatedRowFields.RowID.ToString)).SingleOrDefault

                                    Catch ex As Exception
                                        RRDataRow = Nothing
                                    End Try

                                    If RRDataRow IsNot Nothing Then

                                        GLReportTemplateRowRelation = New AdvantageFramework.Database.Entities.GLReportTemplateRowRelation

                                        GLReportTemplateRowRelation.GLReportTemplateID = GLReportTemplate.ID
                                        GLReportTemplateRowRelation.GLReportTemplateRowID = RRDataRow(RowFields.GLReportTemplateRowID.ToString)
                                        GLReportTemplateRowRelation.RelatedRowIndex = RelatedRowDataRow(RelatedRowFields.RelatedRowIndex.ToString)
                                        GLReportTemplateRowRelation.Order = RelatedRowDataRow(RelatedRowFields.RelatedRowOrder.ToString)

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.Insert(DbContext, GLReportTemplateRowRelation)

                                        If Saved = False Then

                                            Exit For

                                        End If

                                    End If

                                Next

                            End If

                            If Saved Then

                                GLReportTemplateOfficePresetsList = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                For Each OfficeDataRow In _OfficePresetsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    Try

                                        GLReportTemplateOfficePreset = GLReportTemplateOfficePresetsList.SingleOrDefault(Function(Entity) Entity.ID = OfficeDataRow(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString))

                                    Catch ex As Exception
                                        GLReportTemplateOfficePreset = Nothing
                                    End Try

                                    If GLReportTemplateOfficePreset Is Nothing Then

                                        GLReportTemplateOfficePreset = New AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset

                                    Else

                                        GLReportTemplateOfficePresetsList.Remove(GLReportTemplateOfficePreset)

                                    End If

                                    GLReportTemplateOfficePreset.GLReportTemplateID = GLReportTemplate.ID

                                    GLReportTemplateOfficePreset.OfficeCode = OfficeDataRow(OfficePresetFields.Code.ToString)

                                    If GLReportTemplateOfficePreset.IsEntityBeingAdded() Then

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Insert(DbContext, GLReportTemplateOfficePreset)

                                    End If

                                    If Saved Then

                                        OfficeDataRow(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString) = GLReportTemplateOfficePreset.ID

                                    Else

                                        Saved = False
                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                For Each GLReportTemplateOfficePreset In GLReportTemplateOfficePresetsList

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Delete(DbContext, GLReportTemplateOfficePreset)

                                    If Saved = False Then

                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                GLReportTemplateDepartmentTeamPresetsList = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                                For Each DepartmentTeamDataRow In _DepartmentTeamPresetsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    Try

                                        GLReportTemplateDepartmentTeamPreset = GLReportTemplateDepartmentTeamPresetsList.SingleOrDefault(Function(Entity) Entity.ID = DepartmentTeamDataRow(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString))

                                    Catch ex As Exception
                                        GLReportTemplateDepartmentTeamPreset = Nothing
                                    End Try

                                    If GLReportTemplateDepartmentTeamPreset Is Nothing Then

                                        GLReportTemplateDepartmentTeamPreset = New AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset

                                    Else

                                        GLReportTemplateDepartmentTeamPresetsList.Remove(GLReportTemplateDepartmentTeamPreset)

                                    End If

                                    GLReportTemplateDepartmentTeamPreset.GLReportTemplateID = GLReportTemplate.ID

                                    GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode = DepartmentTeamDataRow(DepartmentTeamPresetFields.Code.ToString)

                                    If GLReportTemplateDepartmentTeamPreset.IsEntityBeingAdded() Then

                                        Saved = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Insert(DbContext, GLReportTemplateDepartmentTeamPreset)

                                    End If

                                    If Saved Then

                                        DepartmentTeamDataRow(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString) = GLReportTemplateDepartmentTeamPreset.ID

                                    Else

                                        Saved = False
                                        Exit For

                                    End If

                                Next

                            End If

                            If Saved Then

                                For Each GLReportTemplateDepartmentTeamPreset In GLReportTemplateDepartmentTeamPresetsList

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Delete(DbContext, GLReportTemplateDepartmentTeamPreset)

                                    If Saved = False Then

                                        Exit For

                                    End If

                                Next

                            End If

                        End If

                    Catch ex As Exception
                        Saved = False
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Try

                        If Saved Then

                            DbTransaction.Commit()

                            Me.ClearChanged()

                            _GLReportTemplateID = GLReportTemplate.ID

                            For Each MdiChild In Me.ParentForm.MdiChildren

                                If TypeOf MdiChild Is AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm Then

                                    DirectCast(MdiChild, AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm).RefreshForm()
                                    Exit For

                                End If

                            Next

                            EnableOrDisableActions()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception

                    End Try

                    DbContext.Database.Connection.Close()

                End Using

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Try

                Try

                    DashboardLayoutMemoryStream.Close()

                Catch ex As Exception

                End Try

                DashboardLayoutMemoryStream.Dispose()
                DashboardLayoutMemoryStream = Nothing

            Catch ex As Exception
                DashboardLayoutMemoryStream = Nothing
            End Try

        End Sub
        Private Sub LoadDashboard(ByVal DataSource As Object)

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Add(DataSource)

                Else

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0).Data = DataSource

                End If

                DashboardViewerDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Function GetLoadedDataSource() As Object

            'objects
            Dim DataSource As Object = Nothing

            If DataGridViewStatement_Statement.DataSource IsNot Nothing Then

                DataSource = DataGridViewStatement_Statement.DataSource

            Else

                DataSource = BuildStatementDataTable(_ColumnsDataTable)

            End If

            GetLoadedDataSource = DataSource

        End Function
        Private Function IsDoubleUnderlineCellEnabled(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal RowHandle As Integer) As Boolean

            'objects
            Dim ID As Integer = -1
            Dim RowID As Integer = -1
            Dim DoubleUnderlineAmountIsEnabled As Boolean = False
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim IsLastRowInRowGroup As Boolean = False
            Dim Document As DevExpress.XtraRichEdit.API.Native.Document = Nothing
            Dim CharacterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = Nothing
            Dim ColumnType As ColumnTypes = ColumnTypes.Data

            If GridView IsNot Nothing Then

                If GridColumn.FieldName <> StatementFields.Description.ToString Then

                    RowID = CType(GridView.GetRowCellValue(RowHandle, GridView.Columns(StatementFields.RowID.ToString)), Integer)

                    If RowID >= 0 Then

                        ID = CType(GridView.GetRowCellValue(RowHandle, GridView.Columns(StatementFields.ID.ToString)), Integer)

                        Try

                            If CType(CType(GridView.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Compute("MAX(" & StatementFields.ID.ToString & ")", StatementFields.RowID.ToString & " = " & RowID) = ID Then

                                IsLastRowInRowGroup = True

                            End If

                        Catch ex As Exception

                        End Try

                        If IsLastRowInRowGroup Then

                            Try

                                RowDataRow = _RowsDataTable.Select(RowFields.ID.ToString & " = " & RowID).FirstOrDefault

                            Catch ex As Exception
                                RowDataRow = Nothing
                            End Try

                            Try

                                ColumnDataRow = _ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & GridColumn.FieldName & "'").SingleOrDefault

                            Catch ex As Exception
                                ColumnDataRow = Nothing
                            End Try

                            If ColumnDataRow IsNot Nothing Then

                                ColumnType = ColumnDataRow(ColumnFields.Type.ToString)

                            End If

                            If RowDataRow IsNot Nothing Then

                                DoubleUnderlineAmountIsEnabled = RowDataRow(RowFields.DoubleUnderlineAmount.ToString)

                            End If

                            If DoubleUnderlineAmountIsEnabled Then

                                If ColumnType = ColumnTypes.PercentOfRow OrElse ColumnType = ColumnTypes.PercentVariance Then

                                    'DoubleUnderlineAmountIsEnabled = False

                                End If

                            End If

                        End If

                    End If

                End If

            End If

            IsDoubleUnderlineCellEnabled = DoubleUnderlineAmountIsEnabled

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            'ButtonItemActions_Delete.Enabled = (_GLReportTemplateID <> 0)

        End Sub
        Private Sub SaveOptionsAndPresets()

            'objects
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim GLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset = Nothing
            Dim GLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim GLReportTemplateDepartmentTeamPresetsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset) = Nothing
            Dim GLReportTemplateOfficePresetsList As Generic.List(Of AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset) = Nothing
            Dim OfficeDataRow As System.Data.DataRow = Nothing
            Dim DepartmentTeamDataRow As System.Data.DataRow = Nothing

            If _GLReportTemplateID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, _GLReportTemplateID)

                        If GLReportTemplate IsNot Nothing Then

                            GLReportTemplate.PostPeriodCode = _ReportPostPeriodCode
                            GLReportTemplate.GLReportUserDefReportID = _GLReportUserDefReportID
                            GLReportTemplate.PrintColumnHeadingsOnEveryPage = _PrintColumnHeadingsOnEveryPage
                            GLReportTemplate.SortRowsBy = _SortRowsBy

                            If _CurrencyCode <> _CurrencyCodeHome Then

                                GLReportTemplate.CurrencyCode = _CurrencyCode
                                GLReportTemplate.CurrencyRate = _ReciprocalExchangeRate

                            Else

                                GLReportTemplate.CurrencyCode = Nothing
                                GLReportTemplate.CurrencyRate = Nothing

                            End If

                            If AdvantageFramework.Database.Procedures.GLReportTemplate.Update(DbContext, GLReportTemplate) Then

                                Saved = True

                            End If

                        Else

                            Throw New Exception("The GL Report Template you are trying do update does not exist.")

                        End If

                        If Saved Then

                            GLReportTemplateOfficePresetsList = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                            For Each OfficeDataRow In _OfficePresetsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                Try

                                    GLReportTemplateOfficePreset = GLReportTemplateOfficePresetsList.SingleOrDefault(Function(Entity) Entity.ID = OfficeDataRow(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString))

                                Catch ex As Exception
                                    GLReportTemplateOfficePreset = Nothing
                                End Try

                                If GLReportTemplateOfficePreset Is Nothing Then

                                    GLReportTemplateOfficePreset = New AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset

                                Else

                                    GLReportTemplateOfficePresetsList.Remove(GLReportTemplateOfficePreset)

                                End If

                                GLReportTemplateOfficePreset.GLReportTemplateID = GLReportTemplate.ID

                                GLReportTemplateOfficePreset.OfficeCode = OfficeDataRow(OfficePresetFields.Code.ToString)

                                If GLReportTemplateOfficePreset.IsEntityBeingAdded() Then

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Insert(DbContext, GLReportTemplateOfficePreset)

                                End If

                                If Saved Then

                                    OfficeDataRow(OfficePresetFields.GLReportTemplatePresetOfficeID.ToString) = GLReportTemplateOfficePreset.ID

                                Else

                                    Saved = False
                                    Exit For

                                End If

                            Next

                        End If

                        If Saved Then

                            For Each GLReportTemplateOfficePreset In GLReportTemplateOfficePresetsList

                                Saved = AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Delete(DbContext, GLReportTemplateOfficePreset)

                                If Saved = False Then

                                    Exit For

                                End If

                            Next

                        End If

                        If Saved Then

                            GLReportTemplateDepartmentTeamPresetsList = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.LoadByGLReportTemplateID(DbContext, GLReportTemplate.ID).ToList

                            For Each DepartmentTeamDataRow In _DepartmentTeamPresetsDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                Try

                                    GLReportTemplateDepartmentTeamPreset = GLReportTemplateDepartmentTeamPresetsList.SingleOrDefault(Function(Entity) Entity.ID = DepartmentTeamDataRow(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString))

                                Catch ex As Exception
                                    GLReportTemplateDepartmentTeamPreset = Nothing
                                End Try

                                If GLReportTemplateDepartmentTeamPreset Is Nothing Then

                                    GLReportTemplateDepartmentTeamPreset = New AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset

                                Else

                                    GLReportTemplateDepartmentTeamPresetsList.Remove(GLReportTemplateDepartmentTeamPreset)

                                End If

                                GLReportTemplateDepartmentTeamPreset.GLReportTemplateID = GLReportTemplate.ID

                                GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode = DepartmentTeamDataRow(DepartmentTeamPresetFields.Code.ToString)

                                If GLReportTemplateDepartmentTeamPreset.IsEntityBeingAdded() Then

                                    Saved = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Insert(DbContext, GLReportTemplateDepartmentTeamPreset)

                                End If

                                If Saved Then

                                    DepartmentTeamDataRow(DepartmentTeamPresetFields.GLReportTemplatePresetDepartmentTeamID.ToString) = GLReportTemplateDepartmentTeamPreset.ID

                                Else

                                    Saved = False
                                    Exit For

                                End If

                            Next

                        End If

                        If Saved Then

                            For Each GLReportTemplateDepartmentTeamPreset In GLReportTemplateDepartmentTeamPresetsList

                                Saved = AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Delete(DbContext, GLReportTemplateDepartmentTeamPreset)

                                If Saved = False Then

                                    Exit For

                                End If

                            Next

                        End If

                    Catch ex As Exception
                        Saved = False
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Try

                        If Saved Then

                            DbTransaction.Commit()

                            EnableOrDisableActions()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception

                    End Try

                    DbContext.Database.Connection.Close()

                End Using

            End If

        End Sub
        Private Function ConvertCurrency(DbContext As AdvantageFramework.Database.DbContext, Amount As Decimal) As Decimal

            'objects
            Dim ConvertedAmount As Decimal = 0

            ConvertedAmount = Amount

            If _CurrencyDetail Is Nothing Then

                If _HasCheckedCurrencyComparsion = False Then

                    If String.IsNullOrWhiteSpace(_CurrencyCode) = False AndAlso String.IsNullOrWhiteSpace(_CurrencyCodeHome) = False Then

                        _CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, _CurrencyCode, _CurrencyCodeHome)

                        _HasCheckedCurrencyComparsion = True

                    End If

                End If

            End If

            If _CurrencyDetail IsNot Nothing Then

                ConvertedAmount = FormatNumber(Amount * _CurrencyDetail.ReciprocalExchangeRate, 2)

            End If

            ConvertCurrency = ConvertedAmount

        End Function
        Public Sub SetCurrencySymbol()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _CurrencySymbol = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT COALESCE(CURRENCY_SYMBOL,'$') FROM CURRENCY_CODES WHERE CURRENCY_CODE = '{0}'", _CurrencyCode)).FirstOrDefault

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(Optional ByVal GLReportTemplateID As Integer = 0, Optional ReportType As ReportTypes = ReportTypes.IncomeStatement)

            'objects
            Dim GLReportTemplateSetupForm As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm = Nothing

            GLReportTemplateSetupForm = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm(GLReportTemplateID, ReportType)

            GLReportTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing

            DataGridViewStatement_Statement.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False
            DataGridViewStatement_Statement.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False
            DataGridViewStatement_Statement.OptionsView.ShowFooter = False
            DataGridViewStatement_Statement.OptionsView.ShowColumnHeaders = False
            DataGridViewStatement_Statement.OptionsView.ShowViewCaption = False
            DataGridViewStatement_Statement.OptionsView.ShowIndicator = False
            DataGridViewStatement_Statement.AlwaysForceShowRowSelectionOnUserInput = False

            DataGridViewStatement_Statement.OptionsPrint.PrintVertLines = False
            DataGridViewStatement_Statement.OptionsPrint.PrintHorzLines = False
            DataGridViewStatement_Statement.OptionsPrint.PrintHeader = False
            DataGridViewStatement_Statement.OptionsPrint.PrintFooter = False

            DataGridViewStatement_Statement.CurrentView.FixedLineWidth = 1
            DataGridViewStatement_Statement.CurrentView.Appearance.FixedLine.BackColor = Drawing.Color.Transparent

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewStatement_Statement.GridControl.ToolTipController = _ToolTipController

            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_Save.Image = My.Resources.SaveImage
            'ButtonItemActions_Delete.Image = My.Resources.DeleteImage

            ButtonItemStatementType_IncomeStatement.Image = My.Resources.IncomeStatementImage
            ButtonItemStatementType_BalanceSheet.Image = My.Resources.BalanceSheetImage
            ButtonItemStatementType_Other.Image = My.Resources.OtherStatementImage
            ButtonItemTemplateDetails_OptionsAndPresets.Image = My.Resources.PostingPeriodImage

            ButtonItemTemplateRows_AddNew.Image = My.Resources.JobComponentAddImage
            ButtonItemTemplateRows_Manage.Image = My.Resources.RowImage

            ButtonItemTemplateColumns_AddNew.Image = My.Resources.ColumnAddImage
            ButtonItemTemplateColumns_Manage.Image = My.Resources.ColumnImage

            ButtonItemStatement_View.Image = My.Resources.PrintPreviewImage

            ButtonItemDashboard_Edit.Image = My.Resources.DynamicReportImage

            ButtonItemBudgetData_Refresh.Image = My.Resources.RefreshImage

            _RichEditDocumentServer = New DevExpress.XtraRichEdit.RichEditDocumentServer

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxTemplateDetails_TemplateName.SetPropertySettings(AdvantageFramework.Database.Entities.GLReportTemplate.Properties.Description, "Template Name")

                _CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                If String.IsNullOrWhiteSpace(_CurrencyCodeHome) Then

                    _CurrencyCodeHome = "USD"

                End If

                LabelItemCurrency_Code.Text = _CurrencyCodeHome

                SetCurrencySymbol()

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            If _GLReportTemplateID = 0 Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            Else

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, _GLReportTemplateID)

                    If GLReportTemplate IsNot Nothing Then

                        TextBoxTemplateDetails_TemplateName.Text = GLReportTemplate.Description
                        _ReportPostPeriodCode = GLReportTemplate.PostPeriodCode

                    End If

                End Using

            End If

            TabControlForm_Report.SelectedTab = TabItemReport_StatementTab

            BuildTemplateDataTables(Me.Session, _GLReportTemplateID, _ReportPostPeriodCode, _ReportType, _GLReportUserDefReportID, _PrintColumnHeadingsOnEveryPage, _SortRowsBy,
                                    Nothing, _RowsDataTable, _ColumnsDataTable, _RelatedRowsDataTable, _OfficePresetsDataTable, _DepartmentTeamPresetsDataTable,
                                    _PercentOfRowColumnDataTable, _CurrencyCode, _ReciprocalExchangeRate)

            If _ReportPostPeriodCode = "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        _ReportPostPeriodCode = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).ToList.Last.Code

                    Catch ex As Exception
                        _ReportPostPeriodCode = ""
                    End Try

                    If _ReportPostPeriodCode = "" Then

                        Try

                            _ReportPostPeriodCode = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).ToList.FirstOrDefault.Code

                        Catch ex As Exception
                            _ReportPostPeriodCode = ""
                        End Try

                    End If

                End Using

            End If

            If _GLReportTemplateID > 0 Then

                LoadReportTemplate()

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim DashboardLayout As Byte() = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim XMLText As String = Nothing
            Dim DashboardNodeStart As Integer = 0
            Dim XmlDocument As System.Xml.XmlDocument = Nothing
            Dim NewMemoryStream As System.IO.MemoryStream = Nothing

            DashboardLayout = LoadDashboardLayout(Me.Session, _GLReportTemplateID)

            If DashboardLayout IsNot Nothing AndAlso DashboardLayout.Length > 0 Then

                MemoryStream = New System.IO.MemoryStream(DashboardLayout)

                XMLText = System.Text.Encoding.UTF8.GetString(MemoryStream.ToArray)

                DashboardNodeStart = InStr(1, XMLText, "<Dashboard")

                If DashboardNodeStart > 1 Then

                    XMLText = Mid(XMLText, DashboardNodeStart)

                End If

                NewMemoryStream = New System.IO.MemoryStream

                XmlDocument = New System.Xml.XmlDocument()
                XmlDocument.LoadXml(XMLText)
                XmlDocument.Save(NewMemoryStream)
                NewMemoryStream.Position = 0

                DashboardViewerDashboard_Dashboard.LoadDashboard(NewMemoryStream)

            End If

            If _GLReportTemplateID = 0 Then

                If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSelectReportTypeDialog.ShowFormDialog(_ReportType) = Windows.Forms.DialogResult.Cancel Then

                    Me.Close()

                End If

            End If

            If _ReportType = ReportTypes.IncomeStatement Then

                ButtonItemStatementType_IncomeStatement.Checked = True
                ButtonItemStatementType_IncomeStatement.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Default

                ButtonItemStatementType_BalanceSheet.Checked = False
                ButtonItemStatementType_BalanceSheet.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

                ButtonItemStatementType_Other.Checked = False
                ButtonItemStatementType_Other.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

            ElseIf _ReportType = ReportTypes.BalanceSheet Then

                ButtonItemStatementType_IncomeStatement.Checked = False
                ButtonItemStatementType_IncomeStatement.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

                ButtonItemStatementType_BalanceSheet.Checked = True
                ButtonItemStatementType_BalanceSheet.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Default

                ButtonItemStatementType_Other.Checked = False
                ButtonItemStatementType_Other.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

            Else

                ButtonItemStatementType_IncomeStatement.Checked = False
                ButtonItemStatementType_IncomeStatement.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

                ButtonItemStatementType_BalanceSheet.Checked = False
                ButtonItemStatementType_BalanceSheet.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None

                ButtonItemStatementType_Other.Checked = True
                ButtonItemStatementType_Other.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Default

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub GLReportTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GLReportTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")
            Me.ShowWaitForm()

            Me.ShowWaitForm("Saving...")

            Try

                SaveTemplate()

            Catch ex As Exception

            End Try

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
            Me.CloseWaitForm()

            If _GLReportTemplateID = 0 Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            Else

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")
            Me.ShowWaitForm()

            Me.ShowWaitForm("Saving...")

            Try

                SaveTemplate()

            Catch ex As Exception

            End Try

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
            Me.CloseWaitForm()

        End Sub
        'Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs)

        '    'objects
        '    Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
        '    Dim Deleted As Boolean = False

        '    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this GL report template?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

        '        If _GLReportTemplateID <> 0 Then

        '            Me.FormAction = WinForm.Presentation.FormActions.Deleting
        '            Me.ShowWaitForm()

        '            Me.ShowWaitForm("Deleting...")

        '            Try

        '                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '                    GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, _GLReportTemplateID)

        '                    If GLReportTemplate IsNot Nothing Then

        '                        Deleted = AdvantageFramework.Database.Procedures.GLReportTemplate.Delete(DbContext, GLReportTemplate)

        '                    End If

        '                End Using

        '            Catch ex As Exception

        '            End Try

        '            Me.FormAction = WinForm.Presentation.FormActions.None
        '            Me.CloseWaitForm()

        '            If Deleted Then

        '                For Each MdiChild In Me.ParentForm.MdiChildren

        '                    If TypeOf MdiChild Is AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm Then

        '                        DirectCast(MdiChild, AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm).RefreshForm()

        '                    End If

        '                Next

        '                Me.Close()

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Sub ButtonItemTemplateRows_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplateRows_AddNew.Click

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowEditDialog.ShowFormDialog(_RowsDataTable, _RelatedRowsDataTable, Nothing, _ReportType) = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadReportTemplate()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemStatementType_ManageRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplateRows_Manage.Click

            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageRowsDialog.ShowFormDialog(_RowsDataTable, _RelatedRowsDataTable, _PercentOfRowColumnDataTable, _ReportType, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, _GLReportTemplateID)

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadReportTemplate()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemTemplateColumns_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplateColumns_AddNew.Click

            'objects
            Dim ReportType As ReportTypes = ReportTypes.IncomeStatement

            If ButtonItemStatementType_BalanceSheet.Checked Then

                ReportType = ReportTypes.BalanceSheet

            ElseIf ButtonItemStatementType_IncomeStatement.Checked Then

                ReportType = ReportTypes.IncomeStatement

            ElseIf ButtonItemStatementType_Other.Checked Then

                ReportType = ReportTypes.Other

            End If

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnEditDialog.ShowFormDialog(_ColumnsDataTable, _RowsDataTable, _PercentOfRowColumnDataTable, Nothing, ReportType) = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadReportTemplate()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemTemplateColumns_Manage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplateColumns_Manage.Click

            'objects
            Dim ReportType As ReportTypes = ReportTypes.IncomeStatement

            If ButtonItemStatementType_BalanceSheet.Checked Then

                ReportType = ReportTypes.BalanceSheet

            ElseIf ButtonItemStatementType_IncomeStatement.Checked Then

                ReportType = ReportTypes.IncomeStatement

            ElseIf ButtonItemStatementType_Other.Checked Then

                ReportType = ReportTypes.Other

            End If

            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageColumnsDialog.ShowFormDialog(_ColumnsDataTable, _RowsDataTable, _PercentOfRowColumnDataTable, ReportType)

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadReportTemplate()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub _RelatedRowsDataTable_RowChanged(sender As Object, e As DataRowChangeEventArgs) Handles _RelatedRowsDataTable.RowChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _RelatedRowsDataTable_RowDeleted(sender As Object, e As DataRowChangeEventArgs) Handles _RelatedRowsDataTable.RowDeleted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _RowsDataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles _RowsDataTable.TableNewRow

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _RowsDataTable_RowChanging(sender As Object, e As DataRowChangeEventArgs) Handles _RowsDataTable.RowChanging

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _RowsDataTable_RowDeleting(sender As Object, e As DataRowChangeEventArgs) Handles _RowsDataTable.RowDeleting

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _ColumnsDataTable_RowChanging(sender As Object, e As DataRowChangeEventArgs) Handles _ColumnsDataTable.RowChanging

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _ColumnsDataTable_RowDeleting(sender As Object, e As DataRowChangeEventArgs) Handles _ColumnsDataTable.RowDeleting

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ReportTemplateChanged()

            End If

        End Sub
        Private Sub _DepartmentTeamPresetsDataTable_RowChanged(sender As Object, e As DataRowChangeEventArgs) Handles _DepartmentTeamPresetsDataTable.RowChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                _OptionsAndPresetsChanged = True

            End If

        End Sub
        Private Sub _DepartmentTeamPresetsDataTable_RowDeleted(sender As Object, e As DataRowChangeEventArgs) Handles _DepartmentTeamPresetsDataTable.RowDeleted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                _OptionsAndPresetsChanged = True

            End If

        End Sub
        Private Sub _OfficePresetsDataTable_RowChanged(sender As Object, e As DataRowChangeEventArgs) Handles _OfficePresetsDataTable.RowChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                _OptionsAndPresetsChanged = True

            End If

        End Sub
        Private Sub _OfficePresetsDataTable_RowDeleted(sender As Object, e As DataRowChangeEventArgs) Handles _OfficePresetsDataTable.RowDeleted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                _OptionsAndPresetsChanged = True

            End If

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim XML As String = ""
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DashboardChanged As Boolean = False
            Dim DataTable As System.Data.DataTable = Nothing

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

            End If

            DashboardLayout = MemoryStream.ToArray

            Try

                Try

                    MemoryStream.Close()

                Catch ex As Exception

                End Try

                MemoryStream.Dispose()
                MemoryStream = Nothing

            Catch ex As Exception
                MemoryStream = Nothing
            End Try

            DataTable = DirectCast(DirectCast(DataGridViewStatement_Statement.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable)

            If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, DataTable, DashboardLayout, DashboardChanged) = Windows.Forms.DialogResult.OK Then

                If DashboardChanged Then

                    ReportTemplateChanged()

                    MemoryStream = New System.IO.MemoryStream

                    MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                    LoadDashboard(DataTable)

                    Try

                        Try

                            MemoryStream.Close()

                        Catch ex As Exception

                        End Try

                        MemoryStream.Dispose()
                        MemoryStream = Nothing

                    Catch ex As Exception
                        MemoryStream = Nothing
                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewStatement_Statement_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewStatement_Statement.CustomColumnDisplayTextEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm AndAlso
                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).IsAnyDialogFormOpen = False Then

                DataGridViewCustomColumnDisplayTextEvent(GridView, e, _RowsDataTable, _ColumnsDataTable, _PercentOfRowColumnDataTable, _CurrencySymbol)

                'If IsDoubleUnderlineCellEnabled(GridView, e.Column, e.RowHandle) Then

                '    _RichEditDocumentServer.Text = e.DisplayText

                '    e.DisplayText = _RichEditDocumentServer.RtfText

                'End If

            End If

        End Sub
        Private Sub DataGridViewStatement_Statement_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewStatement_Statement.RowCellStyleEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm AndAlso
                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).IsAnyDialogFormOpen = False Then

                DataGridViewRowCellStyleEvent(GridView, e, _RowsDataTable, _ColumnsDataTable, _PercentOfRowColumnDataTable)

            End If

        End Sub
        Private Sub ButtonItemStatement_View_Click(sender As Object, e As EventArgs) Handles ButtonItemStatement_View.Click

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim BaseGLReportTemplateHeader As AdvantageFramework.Reporting.Reports.GeneralLedger.ReportWriter.BaseGLReportTemplateReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim ImagesList As Generic.List(Of System.Drawing.Image) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim ReportHeaderData As AdvantageFramework.GeneralLedger.ReportWriter.Classes.ReportHeaderData = Nothing
            Dim ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim AgencyImportPath As String = ""
            Dim IsAgencyASP As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    ReportPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, _ReportPostPeriodCode)

                Catch ex As Exception
                    ReportPostPeriod = Nothing
                End Try

                GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, _GLReportUserDefReportID)

                If GLReportUserDefReport IsNot Nothing Then

                    BaseGLReportTemplateHeader = CreateUserDefinedReport(GLReportUserDefReport)

                Else

                    BaseGLReportTemplateHeader = New AdvantageFramework.Reporting.Reports.GeneralLedger.ReportWriter.BaseGLReportTemplateReport

                End If

            End Using

            If BaseGLReportTemplateHeader IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                    If IsAgencyASP Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                    End If

                End Using

                If IsAgencyASP Then

                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                        If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                            My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                        End If

                    End If

                    BaseGLReportTemplateHeader.LoadReport(DirectCast(DirectCast(DataGridViewStatement_Statement.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable), _RowsDataTable, _ColumnsDataTable, _PercentOfRowColumnDataTable, _PrintColumnHeadingsOnEveryPage)

                    ReportHeaderData = New AdvantageFramework.GeneralLedger.ReportWriter.Classes.ReportHeaderData(ReportPostPeriod, TextBoxTemplateDetails_TemplateName.Text, _OfficePresetsDataTable, _DepartmentTeamPresetsDataTable, LabelItemCurrency_Code.Text)

                    BaseGLReportTemplateHeader.DataSource = New Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.ReportHeaderData)({ReportHeaderData})

                    ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(BaseGLReportTemplateHeader)

					ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(TextBoxTemplateDetails_TemplateName.Text) & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
					ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                    ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), TextBoxTemplateDetails_TemplateName.Text))

                    'ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                    ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    ReportPrintTool.ShowRibbonPreviewDialog()

                Else

                    BaseGLReportTemplateHeader.LoadReport(DirectCast(DirectCast(DataGridViewStatement_Statement.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable), _RowsDataTable, _ColumnsDataTable, _PercentOfRowColumnDataTable, _PrintColumnHeadingsOnEveryPage)

                    ReportHeaderData = New AdvantageFramework.GeneralLedger.ReportWriter.Classes.ReportHeaderData(ReportPostPeriod, TextBoxTemplateDetails_TemplateName.Text, _OfficePresetsDataTable, _DepartmentTeamPresetsDataTable, LabelItemCurrency_Code.Text)

                    BaseGLReportTemplateHeader.DataSource = New Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.ReportHeaderData)({ReportHeaderData})

                    ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(BaseGLReportTemplateHeader)

                    ReportPrintTool.ShowRibbonPreviewDialog()

                End If

            Else

                ImagesList = New Generic.List(Of System.Drawing.Image)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ImageEntity In AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

                        MemoryStream = New System.IO.MemoryStream(ImageEntity.Bytes)

                        ImagesList.Add(System.Drawing.Image.FromStream(MemoryStream))

                        Try

                            MemoryStream.Close()
                            MemoryStream.Dispose()

                            MemoryStream = Nothing

                        Catch ex As Exception
                            MemoryStream = Nothing
                        End Try

                    Next

                End Using

                DataGridViewStatement_Statement.Print(Me.DefaultLookAndFeel.LookAndFeel, AdvantageFramework.FileSystem.CreateValidFileName(TextBoxTemplateDetails_TemplateName.Text), ImagesList.ToArray)

            End If

        End Sub
        Private Sub ButtonItemTemplateDetails_OptionsAndPresets_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplateDetails_OptionsAndPresets.Click

            'objects
            Dim PostPeriodCode As String = Nothing
            Dim GLReportUserDefReportID As Integer = 0
            Dim ReloadTemplate As Boolean = False
            Dim PrintColumnHeadingsOnEveryPage As Boolean = False
            Dim SortRowsBy As AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions = AdvantageFramework.GeneralLedger.ReportWriter.SortRowsByOptions.AccountCode
            Dim CurrencyCode As String = Nothing
            Dim ReciprocalExchangeRate As Nullable(Of Decimal) = Nothing

            PostPeriodCode = _ReportPostPeriodCode
            GLReportUserDefReportID = _GLReportUserDefReportID
            PrintColumnHeadingsOnEveryPage = _PrintColumnHeadingsOnEveryPage
            SortRowsBy = _SortRowsBy
            CurrencyCode = _CurrencyCode
			ReciprocalExchangeRate = _ReciprocalExchangeRate.GetValueOrDefault(0)

			_OptionsAndPresetsChanged = False

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplatePresetsDialog.ShowFormDialog(_OfficePresetsDataTable, _DepartmentTeamPresetsDataTable,
                                                                                                                       PostPeriodCode, GLReportUserDefReportID, PrintColumnHeadingsOnEveryPage, SortRowsBy, CurrencyCode, ReciprocalExchangeRate) = Windows.Forms.DialogResult.OK Then

                ReloadTemplate = _OptionsAndPresetsChanged

                If _OptionsAndPresetsChanged = False Then

                    If PostPeriodCode <> _ReportPostPeriodCode Then

                        _OptionsAndPresetsChanged = True
                        ReloadTemplate = True

                    End If

                End If

                _ReportPostPeriodCode = PostPeriodCode

                If _OptionsAndPresetsChanged = False Then

                    If GLReportUserDefReportID <> _GLReportUserDefReportID Then

                        _OptionsAndPresetsChanged = True

                    End If

                End If

                _GLReportUserDefReportID = GLReportUserDefReportID

                If _OptionsAndPresetsChanged = False Then

                    If PrintColumnHeadingsOnEveryPage <> _PrintColumnHeadingsOnEveryPage Then

                        _OptionsAndPresetsChanged = True

                    End If

                End If

                _PrintColumnHeadingsOnEveryPage = PrintColumnHeadingsOnEveryPage

                If _OptionsAndPresetsChanged = False Then

                    If SortRowsBy <> _SortRowsBy Then

                        _OptionsAndPresetsChanged = True
                        ReloadTemplate = True

                    End If

                End If

                _SortRowsBy = SortRowsBy

                If CurrencyCode <> _CurrencyCode Then

                    _OptionsAndPresetsChanged = True
                    ReloadTemplate = True

                End If

                _CurrencyCode = CurrencyCode

                SetCurrencySymbol()

                If ReciprocalExchangeRate <> _ReciprocalExchangeRate.GetValueOrDefault(0) Then

					_OptionsAndPresetsChanged = True
					ReloadTemplate = True

				End If

				_ReciprocalExchangeRate = ReciprocalExchangeRate

                If _OptionsAndPresetsChanged Then

                    ReportTemplateChanged()

                End If

            End If

            If _OptionsAndPresetsChanged Then

                SaveOptionsAndPresets()

            End If

            If ReloadTemplate Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadReportTemplate()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim SuperToolTip As DevExpress.Utils.SuperToolTip = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowID As Integer = 0
            Dim DataTable As System.Data.DataTable = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing

            If e.SelectedControl Is DataGridViewStatement_Statement.GridControl Then

                Try

                    GridView = CType(DataGridViewStatement_Statement.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell Then

                            Try

                                RowID = DataGridViewStatement_Statement.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, StatementFields.RowID.ToString)

                            Catch ex As Exception

                            End Try

                            If RowID > -1 Then

                                Try

                                    RowDataRow = _RowsDataTable.Rows.Find(RowID)

                                    ColumnDataRow = _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(ColumnFields.Name.ToString) = GridHitInfo.Column.FieldName)

                                Catch ex As Exception

                                End Try

                                If RowDataRow IsNot Nothing AndAlso ColumnDataRow IsNot Nothing Then

                                    If RowDataRow(RowFields.Type.ToString) = RowTypes.Account AndAlso ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data Then

                                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowID & ColumnDataRow(ColumnFields.Name.ToString), "Double Click to View Data")

                                    End If

                                End If

                            End If

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub DataGridViewStatement_Statement_RowCellDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles DataGridViewStatement_Statement.RowCellDoubleClickEvent

            'objects
            Dim RowID As Integer = -1
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing

            If DataGridViewStatement_Statement.CurrentView.IsDataRow(e.RowHandle) AndAlso e.Column IsNot Nothing Then

                Try

                    RowID = DataGridViewStatement_Statement.CurrentView.GetRowCellValue(e.RowHandle, StatementFields.RowID.ToString)

                Catch ex As Exception

                End Try

                If RowID > -1 Then

                    Try

                        RowDataRow = _RowsDataTable.Rows.Find(RowID)

                        ColumnDataRow = _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(ColumnFields.Name.ToString) = e.Column.FieldName)

                    Catch ex As Exception

                    End Try

                    If RowDataRow IsNot Nothing AndAlso ColumnDataRow IsNot Nothing Then

                        If RowDataRow(RowFields.Type.ToString) = RowTypes.Account AndAlso ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data Then

                            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateDrillDownDialog.ShowFormDialog(RowDataRow, ColumnDataRow, _ReportPostPeriodCode, _ReportType, _OfficePresetsDataTable, _DepartmentTeamPresetsDataTable)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemBudgetData_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemBudgetData_Refresh.Click

            'objects
            Dim ReloadTemplate As Boolean = False

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing
            Me.ShowWaitForm()
            Me.ShowWaitForm("Updating budget data...")

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[GLSUMMARY] SET GLSBUDGET = 0, GLSBUD2 = 0, GLSBUD3 = 0, GLSBUD4 = 0")

                    DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_gl_budget_data_update_all]")

                End Using

                AdvantageFramework.WinForm.MessageBox.Show("Budget data updated successfully!")

                ReloadTemplate = True

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show("Failed updating budget data.")
            End Try

            If ReloadTemplate Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadReportTemplate()

                Catch ex As Exception

                End Try

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewStatement_Statement_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewStatement_Statement.CustomDrawCellEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim Document As DevExpress.XtraRichEdit.API.Native.Document = Nothing
            Dim CharacterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = Nothing

            GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If IsDoubleUnderlineCellEnabled(GridView, e.Column, e.RowHandle) Then

                If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm AndAlso _
                        CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).IsAnyDialogFormOpen = False Then

                    'GridView.RowSeparatorHeight = 10

                    DataGridViewCustomColumnDisplayTextEvent(GridView, e.Column, e.RowHandle, e.CellValue, e.DisplayText, _RowsDataTable, _ColumnsDataTable, _PercentOfRowColumnDataTable, _CurrencySymbol)

                    _RichEditDocumentServer.Text = e.DisplayText

                    _RichEditDocumentServer.Document.SelectAll()

                    Document = _RichEditDocumentServer.Document

                    Document.BeginUpdate()

                    Document.SelectAll()

                    Document.Paragraphs(0).Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Right
                    Document.Paragraphs(0).OutlineLevel = 0
                    Document.Paragraphs(0).FirstLineIndentType = DevExpress.XtraRichEdit.API.Native.ParagraphFirstLineIndent.None
                    Document.Paragraphs(0).LeftIndent = 0
                    Document.Paragraphs(0).RightIndent = 0
                    Document.Paragraphs(0).LineSpacingType = DevExpress.XtraRichEdit.API.Native.ParagraphLineSpacing.Single
                    Document.Paragraphs(0).SpacingBefore = 0
                    Document.Paragraphs(0).SpacingAfter = 0

                    CharacterProperties = Document.BeginUpdateCharacters(Document.Selection)

                    CharacterProperties.FontSize = 8.25
                    CharacterProperties.FontName = "Tahoma"
                    CharacterProperties.Underline = DevExpress.XtraRichEdit.API.Native.UnderlineType.Double

                    Document.EndUpdateCharacters(CharacterProperties)

                    Document.EndUpdate()

                    e.DisplayText = _RichEditDocumentServer.RtfText

                End If

            End If

        End Sub
        Private Sub DataGridViewStatement_Statement_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewStatement_Statement.CustomRowCellEditEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RepositoryItemRichTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit = Nothing

            GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm AndAlso
                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).IsAnyDialogFormOpen = False Then

                If IsDoubleUnderlineCellEnabled(GridView, e.Column, e.RowHandle) Then

                    e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    RepositoryItemRichTextEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemRichText
                    RepositoryItemRichTextEdit.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf

                    e.RepositoryItem = RepositoryItemRichTextEdit

                End If

            End If

        End Sub
        Private Sub DashboardViewerDashboard_Dashboard_DataLoading(sender As Object, e As DevExpress.DashboardCommon.DataLoadingEventArgs) Handles DashboardViewerDashboard_Dashboard.DataLoading

            e.Data = GetLoadedDataSource()

        End Sub

#End Region

#End Region

    End Class

End Namespace
