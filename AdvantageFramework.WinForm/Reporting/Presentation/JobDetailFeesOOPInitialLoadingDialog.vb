Namespace Reporting.Presentation

    Public Class JobDetailFeesOOPInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

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
        Private Sub LoadFunctions()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridView_OOPFunctions.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "I")
                DataGridView_OOPFunctions.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridView_Campaigns.Enabled = (RadioButtonSelectCampaigns_ChooseCampaigns.Checked)
            DataGridView_OOPFunctions.Enabled = (RadioButtonSelectOOPFunctions_ChooseOOPFunctions.Checked)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim JobDetailFeesOOPInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.JobDetailFeesOOPInitialLoadingDialog = Nothing

            JobDetailFeesOOPInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.JobDetailFeesOOPInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = JobDetailFeesOOPInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = JobDetailFeesOOPInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobDetailInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            JobDetailControl1.LoadControl(_ParameterDictionary)
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

            If FunctionCodes IsNot Nothing AndAlso FunctionCodes.Count > 0 Then

                RadioButtonSelectOOPFunctions_ChooseOOPFunctions.Checked = True

                If DataGridView_OOPFunctions.CurrentView.RowCount > 0 Then

                    DataGridView_OOPFunctions.CurrentView.BeginSelection()

                    DataGridView_OOPFunctions.CurrentView.ClearSelection()

                    For Each RowHandlesAndDataBoundItem In DataGridView_OOPFunctions.GetAllRowsRowHandlesAndDataBoundItems

                        If FunctionCodes.Contains(RowHandlesAndDataBoundItem.Value.Code) Then

                            DataGridView_OOPFunctions.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                            DataGridView_OOPFunctions.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                        End If

                    Next

                    DataGridView_OOPFunctions.CurrentView.EndSelection()

                End If

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim OOPFunctionsList As Generic.List(Of String) = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary = JobDetailControl1.ParameterDictionary

                _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedDivisions.ToString) = CDPChooserControl_Production.DivisionCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedProducts.ToString) = CDPChooserControl_Production.ProductCodeList

                _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedAccountExecutives.ToString) = AEChooserControl_Production.AccountExecutiveCodeList

                If RadioButtonSelectCampaigns_AllCampaigns.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedCampaigns.ToString) = DataGridView_Campaigns.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString) = JobTypeChooserControl1.JobTypeCodeList

                If RadioButtonSelectOOPFunctions_AllOOPFunctions.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedOOPFunctions.ToString) = Nothing

                Else

                    OOPFunctionsList = DataGridView_OOPFunctions.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedOOPFunctions.ToString) = OOPFunctionsList

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.Agency.SaveJobDetailFeesFunctionCodes(DataContext, OOPFunctionsList)

                    End Using

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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

        Private Sub RadioButtonSelectOOPFunctions_AllOOPFunctions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectOOPFunctions_AllOOPFunctions.CheckedChanged

            EnableOrDisableActions()

        End Sub

        Private Sub RadioButtonSelectOOPFunctions_ChooseOOPFunctions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectOOPFunctions_ChooseOOPFunctions.CheckedChanged

            EnableOrDisableActions()

            LoadFunctions()

        End Sub

#End Region

#End Region

    End Class

End Namespace