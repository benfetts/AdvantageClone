Namespace Desktop.Presentation

    Public Class DynamicReportDrillDownDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Reporting.DynamicReports.Alerts
        Private _DynamicReportDrillDownParameter As AdvantageFramework.Reporting.Interfaces.IDynamicReportDrillDownParameter = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal DynamicReportDrillDownParameter As AdvantageFramework.Reporting.Interfaces.IDynamicReportDrillDownParameter)

            ' This call is required by the designer.
            InitializeComponent()

            _DynamicReport = DynamicReport
            _DynamicReportDrillDownParameter = DynamicReportDrillDownParameter

        End Sub
        Private Sub LoadGrid()

            Dim CashReportDetails As Generic.List(Of AdvantageFramework.Database.Classes.CashAnalysisDetailReport) = Nothing
            Dim CashParameters As AdvantageFramework.Reporting.Classes.CashAnalysisDrillDownParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _DynamicReport = Reporting.DynamicReports.CashAnalysis Then

                        CashParameters = _DynamicReportDrillDownParameter

                        CashReportDetails = AdvantageFramework.Reporting.LoadCashAnalysisDataDetail(DbContext, CashParameters.StartingPostPeriodCode, CashParameters.EndingPostPeriodCode, CashParameters.ClientCode, CashParameters.ColumnName)

                        DataGridViewForm_DrillDownItems.DataSource = CashReportDetails

                    End If

                End Using

            Catch ex As Exception

            End Try

            DataGridViewForm_DrillDownItems.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal DynamicReportDrillDownParameter As AdvantageFramework.Reporting.Interfaces.IDynamicReportDrillDownParameter) As System.Windows.Forms.DialogResult

            'objects
            Dim DynamicReportDrillDownDialog As AdvantageFramework.Desktop.Presentation.DynamicReportDrillDownDialog = Nothing

            DynamicReportDrillDownDialog = New AdvantageFramework.Desktop.Presentation.DynamicReportDrillDownDialog(DynamicReport, DynamicReportDrillDownParameter)

            ShowFormDialog = DynamicReportDrillDownDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DynamicReportDrillDownDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects

            ButtonItemActions_Print.Image = My.Resources.PrintImage

            DataGridViewForm_DrillDownItems.OptionsView.ShowFooter = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            DataGridViewForm_DrillDownItems.Print(Me.DefaultLookAndFeel.LookAndFeel, "Drill Down")

        End Sub

#End Region

#End Region

    End Class

End Namespace
