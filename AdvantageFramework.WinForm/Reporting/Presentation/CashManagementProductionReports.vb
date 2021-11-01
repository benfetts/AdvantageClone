Namespace Reporting.Presentation

    Public Class CashManagementProductionReports

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary
        Private _Report As AdvantageFramework.Reporting.ReportTypes = ReportTypes.JobDetailAnalysisV1Summary
        Private _IsUserDefinedReport As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property Report As AdvantageFramework.Reporting.ReportTypes
            Get
                Report = _Report
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal IsUserDefinedReport As Boolean, ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _IsUserDefinedReport = IsUserDefinedReport
            _AdvancedReportWriterReport = AdvancedReportWriterReport

        End Sub
        Private Sub LoadCampaigns()

            Dim ClientCodesList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If RadioButtonSelectCampaigns_AllCampaigns.Checked = False Then

                        If CDPChooserControl_Production.RadioButtonControl_AllClients.Checked = True OrElse CDPChooserControl_Production.DataGridViewControl_Clients.HasASelectedRow = False Then

                            DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode)
                                                                 Where (Entity.IsClosed Is Nothing OrElse
                                                                        Entity.IsClosed = 0)
                                                                 Select [ID] = Entity.ID,
                                                                        [Code] = Entity.CampaignCode,
                                                                        [Description] = Entity.CampaignName).ToList

                        Else

                            If CDPChooserControl_Production.RadioButtonControl_ChooseClients.Checked Then

                                SelectedCodeList = CDPChooserControl_Production.ClientCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode) = True AndAlso
                                                                               (Entity.IsClosed Is Nothing OrElse
                                                                                Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                [Code] = Entity.CampaignCode,
                                                                                [Description] = Entity.CampaignName).ToList
                                End If

                            ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Checked Then

                                SelectedCodeList = CDPChooserControl_Production.DivisionCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True AndAlso
                                                                               (Entity.IsClosed Is Nothing OrElse
                                                                                Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                [Code] = Entity.CampaignCode,
                                                                                [Description] = Entity.CampaignName).ToList
                                End If

                            ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                                SelectedCodeList = CDPChooserControl_Production.ProductCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True AndAlso
                                                                               (Entity.IsClosed Is Nothing OrElse
                                                                               Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                [Code] = Entity.CampaignCode,
                                                                                [Description] = Entity.CampaignName).ToList
                                End If

                            End If

                        End If

                    Else

                        DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode)
                                                             Where (Entity.IsClosed Is Nothing OrElse
                                                                                       Entity.IsClosed = 0)
                                                             Select [ID] = Entity.ID,
                                                                    [Code] = Entity.CampaignCode,
                                                                    [Description] = Entity.CampaignName).ToList
                    End If

                    DataGridView_Campaigns.CurrentView.BestFitColumns()

                    'DataGridViewSelectCampaigns_Campaigns.MakeColumnNotVisible("ID")

                End Using

            End Using

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridView_Campaigns.Enabled = (RadioButtonSelectCampaigns_ChooseCampaigns.Checked)
            DataGridViewSelectOffices_Offices.Enabled = (RadioButtonSelectOffices_ChooseOffices.Checked)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Report As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object),
                                              ByVal IsUserDefinedReport As Boolean, Optional ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary) As Windows.Forms.DialogResult

            'objects
            Dim CashManagementProductionReports As AdvantageFramework.Reporting.Presentation.CashManagementProductionReports = Nothing

            CashManagementProductionReports = New AdvantageFramework.Reporting.Presentation.CashManagementProductionReports(IsUserDefinedReport, AdvancedReportWriterReport)

            ShowFormDialog = CashManagementProductionReports.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Report = CashManagementProductionReports.Report
                ParameterDictionary = CashManagementProductionReports.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobDetailInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CDPChooserControl_Production.LoadControl(_ParameterDictionary)
            AEChooserControl_Production.LoadControl(_ParameterDictionary)
            JobTypeChooserControl1.LoadControl(_ParameterDictionary)

        End Sub
        Private Sub JobDetailInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim SelectedIDs As Generic.List(Of Integer) = Nothing
            Dim FunctionCodes As Generic.List(Of String) = Nothing

            CDPChooserControl_Production.ForceResize()
            AEChooserControl_Production.ForceResize()
            JobTypeChooserControl1.ForceResize()

            If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString) AndAlso
                    IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString)) = False AndAlso
                    DirectCast(_ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString), Generic.List(Of Integer)).Count > 0 Then

                RadioButtonSelectCampaigns_ChooseCampaigns.Checked = True

                SelectedIDs = DirectCast(_ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString), Generic.List(Of Integer))

                DataGridView_Campaigns.CurrentView.BeginSelection()

                DataGridView_Campaigns.CurrentView.ClearSelection()

                For Each RowHandlesAndDataBoundItem In DataGridView_Campaigns.GetAllRowsRowHandlesAndDataBoundItems

                    If SelectedIDs.Contains(RowHandlesAndDataBoundItem.Value.ID) Then

                        DataGridView_Campaigns.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                        DataGridView_Campaigns.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridView_Campaigns.CurrentView.EndSelection()

            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                FunctionCodes = AdvantageFramework.Agency.LoadJobDetailFeesFunctionCodes(DataContext)

            End Using

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim OOPFunctionsList As Generic.List(Of String) = Nothing

            If Me.Validator Then

                If _IsUserDefinedReport Then

                Else

                    If RadioButtonForm_Summary.Checked And RadioButtonControl_Net.Checked Then

                        If CheckBoxForm_IncludeNonbillable.Checked Then
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNetIncludeNonbillableCost
                        Else
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNet
                        End If

                    ElseIf RadioButtonForm_Summary.Checked And RadioButtonControl_Gross.Checked Then

                        If CheckBoxForm_IncludeNonbillable.Checked Then
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGrossIncludeNonbillableCost
                        Else
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGross
                        End If

                    ElseIf RadioButtonFormDetail.Checked And RadioButtonControl_Net.Checked Then

                        If CheckBoxForm_IncludeNonbillable.Checked Then
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNetIncludeNonbillableCost
                        Else
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNet
                        End If

                    ElseIf RadioButtonFormDetail.Checked And RadioButtonControl_Gross.Checked Then

                        If CheckBoxForm_IncludeNonbillable.Checked Then
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGrossIncludeNonbillableCost
                        Else
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGross
                        End If

                    End If


                End If

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                '_ParameterDictionary = JobDetailControl1.ParameterDictionary

                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.IncludeClosed.ToString) = IIf(CheckBox_IncludeClosedJobs.Checked, 0, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.IncludeNonBillable.ToString) = IIf(CheckBoxForm_IncludeNonbillable.Checked, 1, 0)

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedOffices.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedDivisions.ToString) = CDPChooserControl_Production.DivisionCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedProducts.ToString) = CDPChooserControl_Production.ProductCodeList

                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedAccountExecutives.ToString) = AEChooserControl_Production.AccountExecutiveCodeList

                'If RadioButtonSelectCampaigns_AllCampaigns.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString) = DataGridView_Campaigns.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                'End If

                '_ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString) = JobTypeChooserControl1.JobTypeCodeList


                If _IsUserDefinedReport Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Report, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonSelectCampaigns_AllCampaigns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_AllCampaigns.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonSelectCampaigns_ChooseCampaigns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_ChooseCampaigns.CheckedChanged

            EnableOrDisableActions()

            LoadCampaigns()

        End Sub

        Private Sub RadioButtonSelectOOPFunctions_AllOOPFunctions_CheckedChanged(sender As Object, e As EventArgs)

            EnableOrDisableActions()

        End Sub

        Private Sub RadioButtonSelectOOPFunctions_ChooseOOPFunctions_CheckedChanged(sender As Object, e As EventArgs)

            EnableOrDisableActions()

        End Sub

        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            EnableOrDisableActions()

        End Sub

        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            EnableOrDisableActions()

            LoadOffices()

        End Sub

        Private Sub CheckBoxForm_IncludeClosedJobs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_IncludeNonbillable.CheckedChanged

        End Sub

#End Region

#End Region

    End Class

End Namespace