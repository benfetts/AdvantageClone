Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateDrillDownDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RowDataRow As System.Data.DataRow = Nothing
        Private _ColumnDataRow As System.Data.DataRow = Nothing
        Private _ReportPostPeriodCode As String = ""
        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement
        Private _GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
        Private _ReportPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _OfficePresetsDataTable As System.Data.DataTable = Nothing
        Private _DepartmentTeamPresetsDataTable As System.Data.DataTable = Nothing
        Private _StartingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _EndingPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _EndingYear As Integer = 0
        Private _StartingYear As Integer = 0
        Private WithEvents _GridViewAccountTransactionDetails As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _DataOption As DataOptions = DataOptions.EndingBalance
        Private _DataCalculation As DataCalculations = DataCalculations.YearToDate
        Private _OfficeCode As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal RowDataRow As System.Data.DataRow, ByVal ColumnDataRow As System.Data.DataRow, ByVal ReportPostPeriodCode As String, ByVal ReportType As ReportTypes, _
                        ByVal OfficePresetsDataTable As System.Data.DataTable, ByVal DepartmentTeamPresetsDataTable As System.Data.DataTable)

            ' This call is required by the designer.
            InitializeComponent()

            _RowDataRow = RowDataRow
            _ColumnDataRow = ColumnDataRow
            _ReportPostPeriodCode = ReportPostPeriodCode
            _ReportType = ReportType
            _OfficePresetsDataTable = OfficePresetsDataTable
            _DepartmentTeamPresetsDataTable = DepartmentTeamPresetsDataTable

        End Sub
        Private Sub LoadDetailViews()

            'objects
            Dim AccountTransactionDetailsGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing

            DataGridViewForm_DrillDown.CurrentView.BeginUpdate()

            _GridViewAccountTransactionDetails = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewForm_DrillDown.GridControl.LevelTree.Nodes.Add("AccountTransactionDetails", _GridViewAccountTransactionDetails)

            _GridViewAccountTransactionDetails.LevelIndent = 1
            _GridViewAccountTransactionDetails.ChildGridLevelName = "AccountTransactionDetails"
            _GridViewAccountTransactionDetails.GridControl = DataGridViewForm_DrillDown.GridControl
            _GridViewAccountTransactionDetails.Name = "_GridViewAccountTransactionDetails"
            _GridViewAccountTransactionDetails.Session = Me.Session
            _GridViewAccountTransactionDetails.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            _GridViewAccountTransactionDetails.OptionsView.ShowViewCaption = False
            _GridViewAccountTransactionDetails.OptionsView.ShowFooter = False
            _GridViewAccountTransactionDetails.OptionsDetail.ShowDetailTabs = False
            _GridViewAccountTransactionDetails.ViewCaption = "Transaction Details"

            DataGridViewForm_DrillDown.OptionsDetail.ShowDetailTabs = False

            DataGridViewForm_DrillDown.CurrentView.EndUpdate()

        End Sub
        Private Function LoadDataForRow(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.DataTable

            'objects
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            If _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual Then

                If _DataOption = DataOptions.PeriodChange Then

					SQLString = "SELECT " &
									"[AccountCode] = GLED.GLETCODE, " &
									"[AccountDescription] = GLA.GLADESC, " &
									"[TransactionID] = GLED.GLETXACT, " &
									"[Source] = GLEH.GLEHSOURCE, " &
									"[Description] = ISNULL(GLSR.GLSRDESC, ''), " &
									"[EnteredDate] = GLEH.GLEHENTDATE " &
								"FROM  " &
									"[dbo].[GLENTTRL] AS GLED INNER JOIN " &
									"[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT LEFT OUTER JOIN " &
									"[dbo].[GLSOURCE] AS GLSR ON GLSR.GLSRCODE = GLEH.GLEHSOURCE INNER JOIN " &
									"[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
									"[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
									"[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
								"WHERE  " &
									"GLED.GLETCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
									"GLEH.GLEHPP >= '" & _StartingPostPeriod.Code & "' AND " &
									"GLEH.GLEHPP <= '" & _EndingPostPeriod.Code & "'"

				Else

                    If _DataCalculation = DataCalculations.YearToDate Then

						SQLString = "SELECT " &
										"[AccountCode] = GLED.GLETCODE, " &
										"[AccountDescription] = GLA.GLADESC, " &
										"[TransactionID] = GLED.GLETXACT, " &
										"[Source] = GLEH.GLEHSOURCE, " &
										"[Description] = ISNULL(GLSR.GLSRDESC, ''), " &
										"[EnteredDate] = GLEH.GLEHENTDATE " &
									"FROM  " &
										"[dbo].[GLENTTRL] AS GLED INNER JOIN " &
										"[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT LEFT OUTER JOIN " &
										"[dbo].[GLSOURCE] AS GLSR ON GLSR.GLSRCODE = GLEH.GLEHSOURCE INNER JOIN " &
										"[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
										"[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
										"[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
									"WHERE  " &
										"GLED.GLETCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
										"GLEH.GLEHPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

					ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

						SQLString = "SELECT " &
										"[AccountCode] = GLED.GLETCODE, " &
										"[AccountDescription] = GLA.GLADESC, " &
										"[TransactionID] = GLED.GLETXACT, " &
										"[Source] = GLEH.GLEHSOURCE, " &
										"[Description] = ISNULL(GLSR.GLSRDESC, ''), " &
										"[EnteredDate] = GLEH.GLEHENTDATE " &
									"FROM  " &
										"[dbo].[GLENTTRL] AS GLED INNER JOIN " &
										"[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT LEFT OUTER JOIN " &
										"[dbo].[GLSOURCE] AS GLSR ON GLSR.GLSRCODE = GLEH.GLEHSOURCE INNER JOIN " &
										"[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
										"[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
										"[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
									"WHERE  " &
										"GLED.GLETCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
										"GLEH.GLEHPP >= '" & _StartingPostPeriod.Code & "' AND " &
										"GLEH.GLEHPP <= '" & _EndingPostPeriod.Code & "'"

					Else

						SQLString = "SELECT " &
										"[AccountCode] = GLED.GLETCODE, " &
										"[AccountDescription] = GLA.GLADESC, " &
										"[TransactionID] = GLED.GLETXACT, " &
										"[Source] = GLEH.GLEHSOURCE, " &
										"[Description] = ISNULL(GLSR.GLSRDESC, ''), " &
										"[EnteredDate] = GLEH.GLEHENTDATE " &
									"FROM  " &
										"[dbo].[GLENTTRL] AS GLED INNER JOIN " &
										"[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT LEFT OUTER JOIN " &
										"[dbo].[GLSOURCE] AS GLSR ON GLSR.GLSRCODE = GLEH.GLEHSOURCE INNER JOIN " &
										"[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
										"[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
										"[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
									"WHERE  " &
										"GLED.GLETCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
										"GLEH.GLEHPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

					End If

                End If

            ElseIf _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget1 Then

                If _DataOption = DataOptions.PeriodChange Then

                    SQLString = "SELECT " &
                                    "[AccountCode] = GLS.GLSCODE, " &
                                    "[AccountDescription] = GLA.GLADESC, " &
                                    "[PostPeriodCode] = GLS.GLSPP, " &
                                    "[Budget 1] = CAST(GLS.GLSBUDGET AS decimal(18,2)) " &
                                "FROM  " &
                                    "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                    "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                    "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                Else

                    If _DataCalculation = DataCalculations.YearToDate Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 1] = CAST(GLS.GLSBUDGET AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

                    ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 1] = CAST(GLS.GLSBUDGET AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                        "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                        "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                    Else

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 1] = CAST(GLS.GLSBUDGET AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

                    End If

                End If

            ElseIf _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget2 Then

                If _DataOption = DataOptions.PeriodChange Then

                    SQLString = "SELECT " &
                                    "[AccountCode] = GLS.GLSCODE, " &
                                    "[AccountDescription] = GLA.GLADESC, " &
                                    "[PostPeriodCode] = GLS.GLSPP, " &
                                    "[Budget 2] = CAST(GLS.GLSBUD2 AS decimal(18,2)) " &
                                "FROM  " &
                                    "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                    "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                    "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                Else

                    If _DataCalculation = DataCalculations.YearToDate Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 2] = CAST(GLS.GLSBUD2 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

                    ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 2] = CAST(GLS.GLSBUD2 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                        "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                        "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                    Else

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 2] = CAST(GLS.GLSBUD2 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

                    End If

                End If

            ElseIf _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget3 Then

                If _DataOption = DataOptions.PeriodChange Then

                    SQLString = "SELECT " &
                                    "[AccountCode] = GLS.GLSCODE, " &
                                    "[AccountDescription] = GLA.GLADESC, " &
                                    "[PostPeriodCode] = GLS.GLSPP, " &
                                    "[Budget 3] = CAST(GLS.GLSBUD3 AS decimal(18,2)) " &
                                "FROM  " &
                                    "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                    "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                    "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                Else

                    If _DataCalculation = DataCalculations.YearToDate Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 3] = CAST(GLS.GLSBUD3 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

                    ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 3] = CAST(GLS.GLSBUD3 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                        "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                        "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                    Else

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 3] = CAST(GLS.GLSBUD3 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

                    End If

                End If

            ElseIf _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Budget4 Then

                If _DataOption = DataOptions.PeriodChange Then

                    SQLString = "SELECT " &
                                    "[AccountCode] = GLS.GLSCODE, " &
                                    "[AccountDescription] = GLA.GLADESC, " &
                                    "[PostPeriodCode] = GLS.GLSPP, " &
                                    "[Budget 4] = CAST(GLS.GLSBUD4 AS decimal(18,2)) " &
                                "FROM  " &
                                    "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                    "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                    "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                Else

                    If _DataCalculation = DataCalculations.YearToDate Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 4] = CAST(GLS.GLSBUD4 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

                    ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 4] = CAST(GLS.GLSBUD4 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND " &
                                        "GLS.GLSPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                        "GLS.GLSPP <= '" & _EndingPostPeriod.Code & "'"

                    Else

                        SQLString = "SELECT " &
                                        "[AccountCode] = GLS.GLSCODE, " &
                                        "[AccountDescription] = GLA.GLADESC, " &
                                        "[PostPeriodCode] = GLS.GLSPP, " &
                                        "[Budget 4] = CAST(GLS.GLSBUD4 AS decimal(18,2)) " &
                                    "FROM  " &
                                        "[dbo].[GLSUMMARY] AS GLS INNER JOIN " &
                                        "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLS.GLSCODE LEFT OUTER JOIN " &
                                        "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                        "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                    "WHERE  " &
                                        "GLS.GLSCODE IN ('" & Join(_GLACoreList.Select(Function(ECore) ECore.Code).ToArray, "', '") & "') AND  " &
                                        "GLS.GLSPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

                    End If

                End If

            End If

            If String.IsNullOrEmpty(_OfficeCode) = False Then

                SQLString = SQLString & String.Format(_SQLOfficeCodeWhereClauseExtension, _ColumnDataRow(ColumnFields.OfficeCode.ToString))

            End If

            SQLConnection = New System.Data.SqlClient.SqlConnection(DbContext.Database.Connection.ConnectionString)

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.Fill(DataTable)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

			If _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual Then

				For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow).ToList

					DataRow("Description") = DataRow("Description") & " - " & CDate(DataRow("EnteredDate")).ToShortDateString

				Next

			End If

			LoadDataForRow = DataTable

        End Function
        Private Function LoadDataForTransaction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountCode As String, ByVal TransactionID As Integer) As System.Data.DataTable

            'objects
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            If _DataOption = DataOptions.PeriodChange Then

                SQLString = "SELECT " &
                                "[SequenceNumber] = GLED.GLETSEQ, " &
                                "[CreatedBy] = GLEH.GLEHUSER, " &
                                "[PostPeriodCode] = GLEH.GLEHPP, " &
                                "[TransactionDate] = GLEH.GLEHENTDATE, " &
                                "[AccountCode] = GLED.GLETCODE,  " &
                                "[AccountDescription] = GLA.GLADESC,  " &
                                "[Credit] = CASE WHEN GLED.GLETAMT < 0 THEN GLED.GLETAMT ELSE 0 END,  " &
                                "[Debit] = CASE WHEN GLED.GLETAMT > 0 THEN GLED.GLETAMT ELSE 0 END, " &
                                "[ClientCode] = GLED.CL_CODE, " &
                                "[DivisionCode] = GLED.DIV_CODE, " &
                                "[ProductCode] = GLED.PRD_CODE, " &
                                "[Reference] = GLED.GLETREM " &
                            "FROM  " &
                                "[dbo].[GLENTTRL] AS GLED INNER JOIN " &
                                "[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT INNER JOIN " &
                                "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
                                "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                            "WHERE  " &
                                "GLED.GLETCODE = '" & AccountCode & "' AND " &
                                "GLED.GLETXACT = " & TransactionID & "  AND  " &
                                "GLEH.GLEHPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                "GLEH.GLEHPP <= '" & _EndingPostPeriod.Code & "'"

            Else

                If _DataCalculation = DataCalculations.YearToDate Then

                    SQLString = "SELECT " &
                                    "[SequenceNumber] = GLED.GLETSEQ, " &
                                    "[CreatedBy] = GLEH.GLEHUSER, " &
                                    "[PostPeriodCode] = GLEH.GLEHPP, " &
                                    "[TransactionDate] = GLEH.GLEHENTDATE, " &
                                    "[AccountCode] = GLED.GLETCODE,  " &
                                    "[AccountDescription] = GLA.GLADESC,  " &
                                    "[Credit] = CASE WHEN GLED.GLETAMT < 0 THEN GLED.GLETAMT ELSE 0 END,  " &
                                    "[Debit] = CASE WHEN GLED.GLETAMT > 0 THEN GLED.GLETAMT ELSE 0 END, " &
                                    "[ClientCode] = GLED.CL_CODE, " &
                                    "[DivisionCode] = GLED.DIV_CODE, " &
                                    "[ProductCode] = GLED.PRD_CODE, " &
                                    "[Reference] = GLED.GLETREM " &
                                "FROM  " &
                                    "[dbo].[GLENTTRL] AS GLED INNER JOIN " &
                                    "[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLED.GLETCODE = '" & AccountCode & "' AND " &
                                    "GLED.GLETXACT = " & TransactionID & "  AND  " &
                                    "GLEH.GLEHPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & ")"

                ElseIf _DataCalculation = DataCalculations.SelectedPeriod Then

                    SQLString = "SELECT " &
                                    "[SequenceNumber] = GLED.GLETSEQ, " &
                                    "[CreatedBy] = GLEH.GLEHUSER, " &
                                    "[PostPeriodCode] = GLEH.GLEHPP, " &
                                    "[TransactionDate] = GLEH.GLEHENTDATE, " &
                                    "[AccountCode] = GLED.GLETCODE,  " &
                                    "[AccountDescription] = GLA.GLADESC,  " &
                                    "[Credit] = CASE WHEN GLED.GLETAMT < 0 THEN GLED.GLETAMT ELSE 0 END,  " &
                                    "[Debit] = CASE WHEN GLED.GLETAMT > 0 THEN GLED.GLETAMT ELSE 0 END, " &
                                    "[ClientCode] = GLED.CL_CODE, " &
                                    "[DivisionCode] = GLED.DIV_CODE, " &
                                    "[ProductCode] = GLED.PRD_CODE, " &
                                    "[Reference] = GLED.GLETREM " &
                                "FROM  " &
                                    "[dbo].[GLENTTRL] AS GLED INNER JOIN " &
                                    "[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLED.GLETCODE = '" & AccountCode & "' AND " &
                                    "GLED.GLETXACT = " & TransactionID & "  AND  " &
                                    "GLEH.GLEHPP >= '" & _StartingPostPeriod.Code & "' AND " &
                                    "GLEH.GLEHPP <= '" & _EndingPostPeriod.Code & "'"

                Else

                    SQLString = "SELECT " &
                                    "[SequenceNumber] = GLED.GLETSEQ, " &
                                    "[CreatedBy] = GLEH.GLEHUSER, " &
                                    "[PostPeriodCode] = GLEH.GLEHPP, " &
                                    "[TransactionDate] = GLEH.GLEHENTDATE, " &
                                    "[AccountCode] = GLED.GLETCODE,  " &
                                    "[AccountDescription] = GLA.GLADESC,  " &
                                    "[Credit] = CASE WHEN GLED.GLETAMT < 0 THEN GLED.GLETAMT ELSE 0 END,  " &
                                    "[Debit] = CASE WHEN GLED.GLETAMT > 0 THEN GLED.GLETAMT ELSE 0 END, " &
                                    "[ClientCode] = GLED.CL_CODE, " &
                                    "[DivisionCode] = GLED.DIV_CODE, " &
                                    "[ProductCode] = GLED.PRD_CODE, " &
                                    "[Reference] = GLED.GLETREM " &
                                "FROM  " &
                                    "[dbo].[GLENTTRL] AS GLED INNER JOIN " &
                                    "[dbo].[GLENTHDR] AS GLEH ON GLEH.GLEHXACT = GLED.GLETXACT INNER JOIN " &
                                    "[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLED.GLETCODE LEFT OUTER JOIN  " &
                                    "[dbo].[GLOXREF] AS GLO ON GLO.GLOXGLOFFICE = GLA.GLAOFFICE LEFT OUTER JOIN " &
                                    "[dbo].[OFFICE] AS O ON O.OFFICE_CODE = GLO.GLOXOFFICE " &
                                "WHERE  " &
                                    "GLED.GLETCODE = '" & AccountCode & "' AND " &
                                    "GLED.GLETXACT = " & TransactionID & "  AND  " &
                                    "GLEH.GLEHPP IN (SELECT DISTINCT PPPERIOD FROM dbo.POSTPERIOD WHERE (PPGLYEAR < " & CInt(_EndingPostPeriod.Year) & ") OR (PPGLYEAR = " & CInt(_EndingPostPeriod.Year) & " AND PPGLMONTH <= " & CInt(_EndingPostPeriod.Month.GetValueOrDefault(0)) & "))"

                End If

            End If

            SQLConnection = New System.Data.SqlClient.SqlConnection(DbContext.Database.Connection.ConnectionString)

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.Fill(DataTable)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

            LoadDataForTransaction = DataTable

        End Function
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal RowDataRow As System.Data.DataRow, ByVal ColumnDataRow As System.Data.DataRow, ByVal ReportPostPeriodCode As String, ByVal ReportType As ReportTypes,
                                              ByVal OfficePresetsDataTable As System.Data.DataTable, ByVal DepartmentTeamPresetsDataTable As System.Data.DataTable) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateDrillDownDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateDrillDownDialog = Nothing

            GLReportTemplateDrillDownDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateDrillDownDialog(RowDataRow, ColumnDataRow, ReportPostPeriodCode, ReportType, OfficePresetsDataTable, DepartmentTeamPresetsDataTable)

            ShowFormDialog = GLReportTemplateDrillDownDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateDrillDownDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim AccountGroupList As Generic.List(Of AdvantageFramework.Database.Entities.AccountGroup) = Nothing
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            ButtonItemActions_Print.Image = My.Resources.PrintImage

            DataGridViewForm_DrillDown.OptionsView.ShowFooter = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                If _ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual Then

                    DataGridViewForm_DrillDown.OptionsDetail.EnableMasterViewMode = True
                    LoadDetailViews()

                Else

                    DataGridViewForm_DrillDown.OptionsDetail.EnableMasterViewMode = False

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                    Try

                        _ReportPostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = _ReportPostPeriodCode)

                    Catch ex As Exception
                        _ReportPostPeriod = Nothing
                    End Try

                    If _ReportPostPeriod IsNot Nothing Then

                        EmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).Include("Office").Include("Office.GeneralLedgerOfficeCrossReferences").ToList

                        If _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountType Then

                            _GLACoreList = FilterGLAsByPresets(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.Type = _RowDataRow(RowFields.AccountType.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                        ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountGroup Then

                            _GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                            AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, _RowDataRow(RowFields.AccountGroupCode.ToString))

                            If AccountGroup IsNot Nothing Then

                                For Each AccountGroupDetail In AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, AccountGroup.Code).ToList

                                    If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                                        If AccountGroup.Type = 1 Then

                                            Try

                                                GLACore = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).SingleOrDefault(Function(Entity) Entity.Code = AccountGroupDetail.GLACode)

                                            Catch ex As Exception
                                                GLACore = Nothing
                                            End Try

                                            If GLACore IsNot Nothing Then

                                                _GLACoreList.Add(GLACore)

                                            End If

                                        ElseIf AccountGroup.Type = 2 Then

                                            _GLACoreList.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.BaseCode = AccountGroupDetail.GLACode))

                                        End If

                                    End If

                                    If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                                        If AccountGroup.Type = 1 Then

                                            _GLACoreList.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo))

                                        ElseIf AccountGroup.Type = 2 Then

                                            _GLACoreList.AddRange(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(Entity) Entity.BaseCode >= AccountGroupDetail.GLACodeFrom AndAlso Entity.BaseCode <= AccountGroupDetail.GLACodeTo))

                                        End If

                                    End If

                                Next

                                _GLACoreList = FilterGLAsByPresets(_GLACoreList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            End If

                        ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Account Then

                            _GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                            Try

                                GLACore = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).SingleOrDefault(Function(Entity) Entity.Code = _RowDataRow(RowFields.GLACode.ToString))

                            Catch ex As Exception
                                GLACore = Nothing
                            End Try

                            If GLACore IsNot Nothing AndAlso AllowGLAccount(GLACore, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList) Then

                                _GLACoreList.Add(GLACore)

                            End If

                        ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.AccountRange Then

                            If _RowDataRow(RowFields.UseBaseAccountCodes.ToString) Then

                                _GLACoreList = FilterGLAsByPresets(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(ECore) ECore.BaseCode >= _RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.BaseCode <= _RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            Else

                                _GLACoreList = FilterGLAsByPresets(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(ECore) ECore.Code >= _RowDataRow(RowFields.GLACodeRangeStart.ToString) AndAlso ECore.Code <= _RowDataRow(RowFields.GLACodeRangeTo.ToString)).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                            End If

                        ElseIf _RowDataRow(RowFields.LinkType.ToString) = LinkTypes.Wildcard Then

                            _GLACoreList = FilterGLAsByPresets(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).Where(Function(ECore) ECore.Code.Contains(_RowDataRow(RowFields.Wildcard.ToString))).ToList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, EmployeeOfficeList)

                        End If

                        _DataOption = _RowDataRow(RowFields.DataOption.ToString)
                        _DataCalculation = _RowDataRow(RowFields.DataCalculation.ToString)
                        _OfficeCode = If(IsDBNull(_ColumnDataRow(ColumnFields.OfficeCode.ToString)), "", _ColumnDataRow(ColumnFields.OfficeCode.ToString))

                        If _ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) Then

                            _DataOption = _ColumnDataRow(ColumnFields.DataOption.ToString)
                            _DataCalculation = _ColumnDataRow(ColumnFields.DataCalculation.ToString)

                        End If

                        LoadStartAndEndingPostPeriods(_RowDataRow, _ColumnDataRow, _ReportPostPeriod, _DataOption, PostPeriods, _StartingPostPeriod, _EndingPostPeriod)

                        If _StartingPostPeriod IsNot Nothing AndAlso _EndingPostPeriod IsNot Nothing Then

                            If _StartingPostPeriod.Code = _EndingPostPeriod.Code Then

                                If _StartingPostPeriod.Code > _ReportPostPeriod.Code Then

                                    _GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                                End If

                            Else

                                If _StartingPostPeriod.Code > _ReportPostPeriod.Code Then

                                    _GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                                ElseIf _EndingPostPeriod.Code > _ReportPostPeriod.Code Then

                                    _EndingPostPeriod = _ReportPostPeriod

                                End If

                            End If

                        End If

                        DataGridViewForm_DrillDown.DataSource = LoadDataForRow(DbContext)

						DataGridViewForm_DrillDown.MakeColumnNotVisible("EnteredDate")

						DataGridViewForm_DrillDown.CurrentView.BestFitColumns()

                    End If

                    DbContext.Database.Connection.Close()

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            DataGridViewForm_DrillDown.Print(Me.DefaultLookAndFeel.LookAndFeel, "Drill Down")

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_DrillDown.MasterRowEmptyEvent

            e.IsEmpty = If(_ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual, False, True)

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_DrillDown.MasterRowGetChildListEvent

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = LoadDataForTransaction(DbContext, DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "AccountCode"), DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "TransactionID"))

                e.ChildList = BindingSource

            End Using

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_DrillDown.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_DrillDown.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "AccountTransactionDetails"

            End Select

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_DrillDown.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_DrillDown.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                'Try

                '    BaseView.Columns("Code").Visible = False

                'Catch ex As Exception

                'End Try

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_DrillDown_MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewForm_DrillDown.MasterRowGetLevelDefaultViewEvent

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewAccountTransactionDetails

            End Select

        End Sub

#End Region

#End Region

    End Class

End Namespace
