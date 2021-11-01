Namespace GeneralLedger.Maintenance.Presentation

    Public Class CreateChartOfAccountWizardDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OfficeSegmentFormat As String = Nothing
        Private _DepartmentSegmentFormat As String = Nothing
        Private _OtherSegmentFormat As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadDefaults()

            Dim SegmentFormat As String = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCodeList As Generic.List(Of String) = Nothing
            Dim GeneralLedgerOfficeCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferenceCodeList As Generic.List(Of String) = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) = Nothing
            Dim OtherCodeList As Generic.List(Of String) = Nothing
            Dim GLAOtherCodeList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxSelectTemplate_Template.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GLTemplate.Load(DbContext)
                                                              Select Entity.Name).Distinct.ToList

                If AdvantageFramework.GeneralLedger.GeneralLedgerConfigRequiresSegment(Me.Session, Database.Entities.GeneralLedgerConfigSegmentType.Office, SegmentFormat) Then

                    WizardPageWizard_SelectOfficesPage.Visible = True
                    _OfficeSegmentFormat = SegmentFormat

                Else

                    WizardPageWizard_SelectOfficesPage.Visible = False

                End If

                If AdvantageFramework.GeneralLedger.GeneralLedgerConfigRequiresSegment(Me.Session, Database.Entities.GeneralLedgerConfigSegmentType.Department, SegmentFormat) Then

                    WizardPageWizard_SelectDepartmentsPage.Visible = True
                    _DepartmentSegmentFormat = SegmentFormat

                Else

                    WizardPageWizard_SelectDepartmentsPage.Visible = False

                End If

                If AdvantageFramework.GeneralLedger.GeneralLedgerConfigRequiresSegment(Me.Session, Database.Entities.GeneralLedgerConfigSegmentType.Other, SegmentFormat) Then

                    WizardPageWizard_SelectOthersPage.Visible = True
                    _OtherSegmentFormat = SegmentFormat

                Else

                    WizardPageWizard_SelectOthersPage.Visible = False

                End If

                'office segment
                If Me.Session.HasLimitedOfficeCodes Then

                    GeneralLedgerOfficeCrossReferenceCodeList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                                                 Select Entity.GeneralLedgerOfficeCrossReferenceCode).ToList.
                                                                                            Where(Function(GeneralLedgerOfficeCrossReferenceCode) Me.Session.AccessibleGLOfficeCodes.Contains(GeneralLedgerOfficeCrossReferenceCode)).Distinct.ToList

                Else

                    GeneralLedgerOfficeCrossReferenceCodeList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                                                 Select Entity.GeneralLedgerOfficeCrossReferenceCode).Distinct.ToList

                End If

                GeneralLedgerOfficeCrossReferenceList = New Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)

                GeneralLedgerOfficeCrossReferenceList.AddRange(From Code In GeneralLedgerOfficeCrossReferenceCodeList
                                                               Select New AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference(DbContext, Code))

                DataGridViewSelectOffices_GLOffices.DataSource = GeneralLedgerOfficeCrossReferenceList

                DataGridViewSelectOffices_GLOffices.CurrentView.BestFitColumns()
                DataGridViewSelectOffices_GLOffices.SetBookmarkColumnIndex(1)

                DataGridViewSelectOffices_GLOffices.Columns(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.Code.ToString).OptionsColumn.ReadOnly = False
                DataGridViewSelectOffices_GLOffices.Columns(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString).Visible = False

                'department segment
                GeneralLedgerDepartmentTeamCrossReferenceCodeList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                                                     Select Entity.DepartmentCode).Distinct.ToList

                GeneralLedgerDepartmentTeamCrossReferenceList = New Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)

                GeneralLedgerDepartmentTeamCrossReferenceList.AddRange(From Code In GeneralLedgerDepartmentTeamCrossReferenceCodeList
                                                                       Select New AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference(DbContext, Code))

                DataGridViewSelectDepartments_GLDepartments.DataSource = GeneralLedgerDepartmentTeamCrossReferenceList

                DataGridViewSelectDepartments_GLDepartments.CurrentView.BestFitColumns()
                DataGridViewSelectDepartments_GLDepartments.SetBookmarkColumnIndex(1)

                DataGridViewSelectDepartments_GLDepartments.Columns(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.Code.ToString).OptionsColumn.ReadOnly = False
                DataGridViewSelectDepartments_GLDepartments.Columns(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString).Visible = False

                'other segment
                OtherCodeList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                 Where Entity.OtherCode IsNot Nothing
                                 Select Entity.OtherCode).Distinct.ToList

                GLAOtherCodeList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode)

                GLAOtherCodeList.AddRange(From Code In OtherCodeList
                                          Select New AdvantageFramework.GeneralLedger.Classes.GLAOtherCode(Code))

                DataGridViewSelectOthers_Others.DataSource = GLAOtherCodeList

                DataGridViewSelectOthers_Others.CurrentView.BestFitColumns()
                DataGridViewSelectOthers_Others.SetBookmarkColumnIndex(0)

            End Using

        End Sub
        Private Function BuildOfficeDepartmentOtherList(ByVal GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference),
                                                        ByVal GeneralLedgerDepartmentTeamCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference),
                                                        ByVal GLAOtherCodes As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode)) As IEnumerable(Of Object)

            Dim ReturnList As IEnumerable(Of Object) = Nothing

            If GeneralLedgerOfficeCrossReferences IsNot Nothing AndAlso GeneralLedgerDepartmentTeamCrossReferences IsNot Nothing AndAlso GLAOtherCodes IsNot Nothing Then

                ReturnList = (From Office In GeneralLedgerOfficeCrossReferences
                              From Department In GeneralLedgerDepartmentTeamCrossReferences
                              From Other In GLAOtherCodes
                              Select New With {.OfficeCode = Office.Code,
                                               .DepartmentCode = Department.Code,
                                               .OtherCode = Other.Code}).ToList

            ElseIf GeneralLedgerOfficeCrossReferences IsNot Nothing AndAlso GeneralLedgerDepartmentTeamCrossReferences IsNot Nothing Then

                ReturnList = (From Office In GeneralLedgerOfficeCrossReferences
                              From Department In GeneralLedgerDepartmentTeamCrossReferences
                              Select New With {.OfficeCode = Office.Code,
                                               .DepartmentCode = Department.Code,
                                               .OtherCode = Nothing}).ToList

            ElseIf GeneralLedgerOfficeCrossReferences IsNot Nothing AndAlso GLAOtherCodes IsNot Nothing Then

                ReturnList = (From Office In GeneralLedgerOfficeCrossReferences
                              From Other In GLAOtherCodes
                              Select New With {.OfficeCode = Office.Code,
                                               .DepartmentCode = Nothing,
                                               .OtherCode = Other.Code}).ToList

            ElseIf GeneralLedgerDepartmentTeamCrossReferences IsNot Nothing AndAlso GLAOtherCodes IsNot Nothing Then

                ReturnList = (From Department In GeneralLedgerDepartmentTeamCrossReferences
                              From Other In GLAOtherCodes
                              Select New With {.OfficeCode = Nothing,
                                               .DepartmentCode = Department.Code,
                                               .OtherCode = Other.Code}).ToList

            ElseIf GeneralLedgerOfficeCrossReferences IsNot Nothing Then

                ReturnList = (From Office In GeneralLedgerOfficeCrossReferences
                              Select New With {.OfficeCode = Office.Code,
                                               .DepartmentCode = Nothing,
                                               .OtherCode = Nothing}).ToList

            ElseIf GeneralLedgerDepartmentTeamCrossReferences IsNot Nothing Then

                ReturnList = (From Department In GeneralLedgerDepartmentTeamCrossReferences
                              Select New With {.OfficeCode = Nothing,
                                               .DepartmentCode = Department.Code,
                                               .OtherCode = Nothing}).ToList

            ElseIf GLAOtherCodes IsNot Nothing Then

                ReturnList = (From Other In GLAOtherCodes
                              Select New With {.OfficeCode = Nothing,
                                               .DepartmentCode = Nothing,
                                               .OtherCode = Other.Code}).ToList

            End If

            BuildOfficeDepartmentOtherList = ReturnList

        End Function
        Private Sub LoadBaseRanges()

            Dim GLTypeList As Generic.List(Of String) = Nothing
            Dim BaseCodes As Generic.List(Of String) = Nothing
            Dim BaseCodesReverse As Generic.List(Of String) = Nothing

            GLTypeList = New Generic.List(Of String)

            For Each CheckBox In GroupBoxSelectAccountTypes_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If CheckBox.Checked Then

                    GLTypeList.Add(CheckBox.Tag.ToString)

                End If

            Next

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BaseCodes = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session)
                             Where GLTypeList.Contains(GL.Type)
                             Select GL.BaseCode).Distinct.ToList

                BaseCodes.Sort()
                ComboBoxSelectRange_BaseRangeFrom.DataSource = BaseCodes

                BaseCodesReverse = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session)
                                    Where GLTypeList.Contains(GL.Type)
                                    Select GL.BaseCode).Distinct.ToList

                BaseCodesReverse.Sort()
                BaseCodesReverse.Reverse()
                ComboBoxSelectRange_BaseRangeTo.DataSource = BaseCodesReverse

            End Using

            ComboBoxSelectRange_BaseRangeFrom.SelectedValue = Nothing
            ComboBoxSelectRange_BaseRangeTo.SelectedValue = Nothing

        End Sub
        Private Sub LoadChartOfAccountsForCreation()

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim ChartOfAccountList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) = Nothing
            Dim GLTemplateList As Generic.List(Of AdvantageFramework.Database.Entities.GLTemplate) = Nothing
            Dim TemplateName As String = Nothing
            Dim AccountTypes As Generic.List(Of Integer) = Nothing
            Dim ExistingGLCodes As Generic.List(Of String) = Nothing
            Dim GeneralLedgerAccountList As IEnumerable(Of Object) = Nothing
            Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferences As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) = Nothing
            Dim GLAOtherCodes As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode) = Nothing
            Dim OfficeDeparmentOtherList As IEnumerable(Of Object) = Nothing
            Dim BaseCodeStart As String = Nothing
            Dim BaseCodeEnd As String = Nothing
            Dim DistinctGLCodes As Generic.List(Of String) = Nothing
            Dim DistinctChartOfAccountList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) = Nothing

            AccountTypes = New Generic.List(Of Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

            End Using

            For Each CheckBox In GroupBoxSelectAccountTypes_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox).ToList

                If CheckBox.Checked Then

                    AccountTypes.Add(CheckBox.Tag)

                End If

            Next

            ChartOfAccountList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)
            DistinctChartOfAccountList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)

            If WizardPageWizard_SelectOfficesPage.Visible Then

                GeneralLedgerOfficeCrossReferences = DataGridViewSelectOffices_GLOffices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)().ToList

            End If

            If WizardPageWizard_SelectDepartmentsPage.Visible Then

                GeneralLedgerDepartmentTeamCrossReferences = DataGridViewSelectDepartments_GLDepartments.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)().ToList

            End If

            If WizardPageWizard_SelectOthersPage.Visible Then

                GLAOtherCodes = DataGridViewSelectOthers_Others.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode)().ToList

            End If

            OfficeDeparmentOtherList = BuildOfficeDepartmentOtherList(GeneralLedgerOfficeCrossReferences, GeneralLedgerDepartmentTeamCrossReferences, GLAOtherCodes)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExistingGLCodes = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext)
                                   Select GL.Code).ToList

                If RadioButtonSelectSource_UsingTemplate.Checked Then

                    TemplateName = ComboBoxSelectTemplate_Template.GetSelectedValue

                    GLTemplateList = (From Entity In AdvantageFramework.Database.Procedures.GLTemplate.Load(DbContext).ToList
                                      Where Entity.Name = TemplateName AndAlso
                                            AccountTypes.Contains(Entity.Type)
                                      Select Entity).ToList

                    For Each GLTemplate In GLTemplateList

                        If OfficeDeparmentOtherList IsNot Nothing Then

                            For Each OfficeDeparmentOther In OfficeDeparmentOtherList

                                ChartOfAccountList.Add(New AdvantageFramework.GeneralLedger.Classes.ChartOfAccount(GLTemplate, OfficeDeparmentOther.OfficeCode, OfficeDeparmentOther.DepartmentCode, OfficeDeparmentOther.OtherCode, Session.UserCode, GeneralLedgerConfig))

                            Next

                        End If

                    Next

                Else

                    BaseCodeStart = DirectCast(ComboBoxSelectRange_BaseRangeFrom.GetSelectedValue, String)
                    BaseCodeEnd = DirectCast(ComboBoxSelectRange_BaseRangeTo.GetSelectedValue, String)

                    GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                                Where AccountTypes.Contains(Entity.Type) AndAlso
                                                      Entity.BaseCode >= BaseCodeStart AndAlso
                                                      Entity.BaseCode <= BaseCodeEnd AndAlso
                                                      Entity.Active = "A"
                                                Select New With {.BaseCode = Entity.BaseCode,
                                                                 .Description = Entity.Description,
                                                                 .BalanceType = Entity.BalanceType,
                                                                 .CDPRequired = Entity.CDPRequired,
                                                                 .Type = Entity.Type,
                                                                 .PurchaseOrder = Entity.PurchaseOrder,
                                                                 .Payroll = Entity.Payroll}).Distinct.ToList

                    For Each GeneralLedgerAccount In GeneralLedgerAccountList

                        If OfficeDeparmentOtherList IsNot Nothing Then

                            For Each OfficeDeparmentOther In OfficeDeparmentOtherList

                                ChartOfAccountList.Add(New AdvantageFramework.GeneralLedger.Classes.ChartOfAccount(GeneralLedgerAccount, OfficeDeparmentOther.OfficeCode, OfficeDeparmentOther.DepartmentCode, OfficeDeparmentOther.OtherCode, Session.UserCode, GeneralLedgerConfig))

                            Next

                        End If

                    Next

                End If

                ChartOfAccountList = ChartOfAccountList.Where(Function(E) ExistingGLCodes.Contains(E.Code) = False).ToList

                For Each DistinctCode In (From Chart In ChartOfAccountList Select Chart.Code).Distinct

                    DistinctChartOfAccountList.Add(ChartOfAccountList.Where(Function(COA) COA.Code = DistinctCode).FirstOrDefault)

                Next

                DataGridViewFinalizeChartOfAccountCreation_COAs.DataSource = DistinctChartOfAccountList

                OrderColumnsBasedOnConfiguration(GeneralLedgerConfig, Me.DataGridViewFinalizeChartOfAccountCreation_COAs, 1)

                DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub SaveChartOfAccounts()

            Dim ChartOfAccountList As IEnumerable(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) = Nothing
            Dim ProgressBarValue As Integer = 0
            Dim OverallStatus As String = ""
            Dim FailedOnce As Boolean = False

            Try

                ChartOfAccountList = DataGridViewFinalizeChartOfAccountCreation_COAs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)().ToList

                ProgressBarAddingPage_OverallProgress.Minimum = 0
                ProgressBarAddingPage_OverallProgress.Maximum = ChartOfAccountList.Count

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ChartOfAccount In ChartOfAccountList

                        ChartOfAccount.GeneralLedgerAccount.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Insert(DbContext, ChartOfAccount.GeneralLedgerAccount) = False Then

                            FailedOnce = True
                            DbContext.GeneralLedgerAccounts.Remove(ChartOfAccount.GeneralLedgerAccount)

                        End If

                        ProgressBarValue += 1

                        ProgressBarAddingPage_OverallProgress.Value = ProgressBarValue

                    Next

                End Using

            Catch ex As Exception
                OverallStatus = "Adding Charts of Accounts Failed... Click Next to continue..."
            End Try

            If FailedOnce Then

                OverallStatus = "Adding Charts of Accounts Completed but with errors... Click Next to continue..."

            Else

                OverallStatus = "Adding Charts of Accounts Completed... Click Next to continue..."

            End If

            LabelAddingPage_OverallStatus.Text = OverallStatus

            WizardPageWizard_AddingPage.AllowNext = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowWizardDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim CreateChartOfAccountWizardDialog As AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreateChartOfAccountWizardDialog = Nothing

            CreateChartOfAccountWizardDialog = New AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreateChartOfAccountWizardDialog()

            ShowWizardDialog = CreateChartOfAccountWizardDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CreateChartOfAccountWizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            WizardControlForm_Wizard.Image = AdvantageFramework.My.Resources.AdvantageLogoImage

            ComboBoxSelectTemplate_Template.SetPropertySettings(AdvantageFramework.Database.Entities.GLTemplate.Properties.Name)

            Me.RadioButtonSelectSource_UsingTemplate.Checked = True

            DataGridViewSelectOffices_GLOffices.UseEmbeddedNavigator = True
            DataGridViewSelectOffices_GLOffices.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DataGridViewSelectOffices_GLOffices.CurrentView.OptionsSelection.MultiSelect = True
            DataGridViewSelectOffices_GLOffices.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True

            DataGridViewSelectDepartments_GLDepartments.UseEmbeddedNavigator = True
            DataGridViewSelectDepartments_GLDepartments.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DataGridViewSelectDepartments_GLDepartments.CurrentView.OptionsSelection.MultiSelect = True
            DataGridViewSelectDepartments_GLDepartments.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True

            DataGridViewSelectOthers_Others.UseEmbeddedNavigator = True
            DataGridViewSelectOthers_Others.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DataGridViewSelectOthers_Others.CurrentView.OptionsSelection.MultiSelect = True
            DataGridViewSelectOthers_Others.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True

            DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.OptionsSelection.MultiSelect = True
            DataGridViewFinalizeChartOfAccountCreation_COAs.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True
            DataGridViewFinalizeChartOfAccountCreation_COAs.ShowSelectDeselectAllButtons = True

            DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.ObjectType = GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)

            LoadDefaults()

            Me.ByPassUserEntryChanged = True

        End Sub
        Private Sub CreateChartOfAccountWizardDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.ViewCaption = "Chart of Account(s) Chosen for Creation"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub WizardControlForm_Wizard_NextClick(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            'objects
            Dim CanContinue As Boolean = True

            If e.Page Is WizardPageWizard_SelectSourcePage Then

                If RadioButtonSelectSource_UsingTemplate.Checked = False Then

                    WizardPageWizard_SelectTemplatePage.Visible = False
                    WizardPageWizard_SelectRangePage.Visible = True

                Else

                    WizardPageWizard_SelectTemplatePage.Visible = True
                    WizardPageWizard_SelectRangePage.Visible = False

                End If

            ElseIf e.Page Is WizardPageWizard_SelectTemplatePage Then

                If ComboBoxSelectTemplate_Template.HasASelectedValue = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select a template.")

                End If

            ElseIf e.Page Is WizardPageWizard_SelectAccountTypesPage Then

                If Me.GroupBoxSelectAccountTypes_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Where(Function(Control) Control.Checked = True).Any = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one account type to continue.")

                End If

            ElseIf e.Page Is WizardPageWizard_SelectRangePage Then

                If ComboBoxSelectRange_BaseRangeFrom.HasASelectedValue = False OrElse ComboBoxSelectRange_BaseRangeTo.HasASelectedValue = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select both from and to range.")

                ElseIf ComboBoxSelectRange_BaseRangeFrom.GetSelectedValue > ComboBoxSelectRange_BaseRangeTo.GetSelectedValue Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("From range must be less than to range.")

                End If

            ElseIf e.Page Is WizardPageWizard_SelectOfficesPage Then

                If Me.DataGridViewSelectOffices_GLOffices.HasASelectedRow = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one office to continue.")

                End If

            ElseIf e.Page Is WizardPageWizard_SelectDepartmentsPage Then

                If Me.DataGridViewSelectDepartments_GLDepartments.HasASelectedRow = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one department to continue.")

                End If

            ElseIf e.Page Is WizardPageWizard_SelectOthersPage Then

                If Me.DataGridViewSelectOthers_Others.HasASelectedRow = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one other to continue.")

                End If

            ElseIf e.Page Is WizardPageWizard_FinalizeChartOfAccountCreationPage Then

                DataGridViewFinalizeChartOfAccountCreation_COAs.CurrentView.CloseEditorForUpdating()

                If DataGridViewFinalizeChartOfAccountCreation_COAs.HasRows = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Nothing to create, cannot continue.")

                Else

                    DataGridViewFinalizeChartOfAccountCreation_COAs.ValidateAllRows()

                    If DataGridViewFinalizeChartOfAccountCreation_COAs.HasAnyInvalidRows Then

                        CanContinue = False
                        AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.")

                    End If

                End If

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_PrevClick(sender As Object, e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.PrevClick

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If e.Page Is WizardPageWizard_SelectTemplatePage Then

                    ComboBoxSelectTemplate_Template.SetRequired(True)

                ElseIf e.Page Is WizardPageWizard_SelectRangePage Then

                    ComboBoxSelectRange_BaseRangeFrom.SetRequired(True)
                    ComboBoxSelectRange_BaseRangeTo.SetRequired(True)

                    LoadBaseRanges()

                ElseIf e.Page Is WizardPageWizard_FinalizeChartOfAccountCreationPage Then

                    LoadChartOfAccountsForCreation()

                ElseIf e.Page Is WizardPageWizard_AddingPage Then

                    WizardPageWizard_AddingPage.AllowNext = False

                    SaveChartOfAccounts()

                End If

            End If

        End Sub
        Private Sub DataGridViewFinalizeChartOfAccountCreation_COAs_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewFinalizeChartOfAccountCreation_COAs.CellValueChangedEvent

            DataGridView_GeneralLedgerAccounts_CellValueChanged(DataGridViewFinalizeChartOfAccountCreation_COAs, e)

        End Sub
        Private Sub DataGridViewFinalizeChartOfAccountCreation_COAs_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewFinalizeChartOfAccountCreation_COAs.QueryPopupNeedDatasourceEvent

            DataGridView_GeneralLedgerAccounts_QueryPopupNeedDatasourceEvent(FieldName, OverrideDefaultDatasource, Datasource, Me.Session)

        End Sub
        Private Sub DataGridViewFinalizeChartOfAccountCreation_COAs_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewFinalizeChartOfAccountCreation_COAs.ShowingEditorEvent

            DataGridView_GeneralLedgerAccounts_ShowingEditorEvent(DataGridViewFinalizeChartOfAccountCreation_COAs, sender, e, Session)

        End Sub
        Private Sub DataGridViewSelectOffices_GLOffices_AddNewRowEvent(RowObject As Object) Handles DataGridViewSelectOffices_GLOffices.AddNewRowEvent

            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference Then

                GeneralLedgerOfficeCrossReference = RowObject

                GeneralLedgerOfficeCrossReference.AddedForChartOfAccountWizard = True

            End If

        End Sub
        Private Sub DataGridViewSelectOffices_GLOffices_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewSelectOffices_GLOffices.BeforeAddNewRowEvent

            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference Then

                GeneralLedgerOfficeCrossReference = RowObject
                GeneralLedgerOfficeCrossReference.Code = AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(GeneralLedgerOfficeCrossReference.Code)

                If GeneralLedgerOfficeCrossReference.Code IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference.Code.Length <> _OfficeSegmentFormat.Length Then

                    AdvantageFramework.WinForm.MessageBox.Show("Office Segment does not match format '" & _OfficeSegmentFormat & "'.")
                    Cancel = True

                ElseIf DataGridViewSelectOffices_GLOffices.GetAllRowsBookmarkValues.OfType(Of String).Contains(GeneralLedgerOfficeCrossReference.Code) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Office Segment already exists in grid.")
                    Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectOffices_GLOffices_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewSelectOffices_GLOffices.CustomColumnDisplayTextEvent

            If (DataGridViewSelectOffices_GLOffices.CurrentView.GetRowHandle(e.ListSourceRowIndex) = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = "DX$CheckboxSelectorColumn") Then

                e.DisplayText = ""

            End If

        End Sub
        Private Sub DataGridViewSelectOffices_GLOffices_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSelectOffices_GLOffices.EmbeddedNavigatorButtonClick

            Dim GeneralLedgerOfficeCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) = Nothing

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSelectOffices_GLOffices.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        GeneralLedgerOfficeCrossReferenceList = DataGridViewSelectOffices_GLOffices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference)().ToList

                        For Each GeneralLedgerOfficeCrossReference In GeneralLedgerOfficeCrossReferenceList

                            If GeneralLedgerOfficeCrossReference.AddedForChartOfAccountWizard Then

                                DataGridViewSelectOffices_GLOffices.CurrentView.DeleteFromDataSource(GeneralLedgerOfficeCrossReference)

                            End If

                        Next

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSelectOffices_GLOffices_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectOffices_GLOffices.ShowingEditorEvent

            If DataGridViewSelectOffices_GLOffices.IsNewItemRow(DataGridViewSelectOffices_GLOffices.CurrentView.FocusedRowHandle) = False Then

                e.Cancel = True

            ElseIf DataGridViewSelectOffices_GLOffices.IsNewItemRow(DataGridViewSelectOffices_GLOffices.CurrentView.FocusedRowHandle) = True AndAlso _
                    DataGridViewSelectOffices_GLOffices.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.Code.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSelectDepartments_GLDepartments_AddNewRowEvent(RowObject As Object) Handles DataGridViewSelectDepartments_GLDepartments.AddNewRowEvent

            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference Then

                GeneralLedgerDepartmentTeamCrossReference = RowObject

                GeneralLedgerDepartmentTeamCrossReference.AddedForChartOfAccountWizard = True

            End If

        End Sub
        Private Sub DataGridViewSelectDepartments_GLDepartments_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewSelectDepartments_GLDepartments.BeforeAddNewRowEvent

            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference Then

                GeneralLedgerDepartmentTeamCrossReference = RowObject
                GeneralLedgerDepartmentTeamCrossReference.Code = AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(GeneralLedgerDepartmentTeamCrossReference.Code)

                If GeneralLedgerDepartmentTeamCrossReference.Code IsNot Nothing AndAlso GeneralLedgerDepartmentTeamCrossReference.Code.Length <> _DepartmentSegmentFormat.Length Then

                    AdvantageFramework.WinForm.MessageBox.Show("Department Segment does not match format '" & _DepartmentSegmentFormat & "'")
                    Cancel = True

                ElseIf DataGridViewSelectDepartments_GLDepartments.GetAllRowsBookmarkValues.OfType(Of String).Contains(GeneralLedgerDepartmentTeamCrossReference.Code) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Department Segment already exists in grid.")
                    Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectDepartments_GLDepartments_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewSelectDepartments_GLDepartments.CustomColumnDisplayTextEvent

            If (DataGridViewSelectDepartments_GLDepartments.CurrentView.GetRowHandle(e.ListSourceRowIndex) = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = "DX$CheckboxSelectorColumn") Then

                e.DisplayText = ""

            End If

        End Sub
        Private Sub DataGridViewSelectDepartments_GLDepartments_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSelectDepartments_GLDepartments.EmbeddedNavigatorButtonClick

            Dim GeneralLedgerDepartmentTeamCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) = Nothing

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSelectDepartments_GLDepartments.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        GeneralLedgerDepartmentTeamCrossReferenceList = DataGridViewSelectDepartments_GLDepartments.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference)().ToList

                        For Each GeneralLedgerDepartmentTeamCrossReference In GeneralLedgerDepartmentTeamCrossReferenceList

                            If GeneralLedgerDepartmentTeamCrossReference.AddedForChartOfAccountWizard Then

                                DataGridViewSelectDepartments_GLDepartments.CurrentView.DeleteFromDataSource(GeneralLedgerDepartmentTeamCrossReference)

                            End If

                        Next

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSelectDepartments_GLDepartments_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectDepartments_GLDepartments.ShowingEditorEvent

            If DataGridViewSelectDepartments_GLDepartments.IsNewItemRow(DataGridViewSelectDepartments_GLDepartments.CurrentView.FocusedRowHandle) = False Then

                e.Cancel = True

            ElseIf DataGridViewSelectDepartments_GLDepartments.IsNewItemRow(DataGridViewSelectDepartments_GLDepartments.CurrentView.FocusedRowHandle) = True AndAlso _
                    DataGridViewSelectDepartments_GLDepartments.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.Code.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSelectOthers_Others_AddNewRowEvent(RowObject As Object) Handles DataGridViewSelectOthers_Others.AddNewRowEvent

            Dim GLAOtherCode As AdvantageFramework.GeneralLedger.Classes.GLAOtherCode = Nothing

            If TypeOf RowObject Is AdvantageFramework.GeneralLedger.Classes.GLAOtherCode Then

                GLAOtherCode = RowObject

                GLAOtherCode.AddedForChartOfAccountWizard = True

            End If

        End Sub
        Private Sub DataGridViewSelectOthers_Others_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewSelectOthers_Others.BeforeAddNewRowEvent

            Dim GLAOtherCode As AdvantageFramework.GeneralLedger.Classes.GLAOtherCode = Nothing

            If TypeOf RowObject Is AdvantageFramework.GeneralLedger.Classes.GLAOtherCode Then

                GLAOtherCode = RowObject
                GLAOtherCode.Code = AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(GLAOtherCode.Code)

                If GLAOtherCode.Code IsNot Nothing AndAlso GLAOtherCode.Code.Length <> _OtherSegmentFormat.Length Then

                    AdvantageFramework.WinForm.MessageBox.Show("Other Segment does not match format '" & _OtherSegmentFormat & "'.")
                    Cancel = True

                ElseIf DataGridViewSelectOthers_Others.GetAllRowsBookmarkValues.OfType(Of String).Contains(GLAOtherCode.Code) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Other Segment already exists in grid.")
                    Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectOthers_Others_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewSelectOthers_Others.CustomColumnDisplayTextEvent

            If (DataGridViewSelectOthers_Others.CurrentView.GetRowHandle(e.ListSourceRowIndex) = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = "DX$CheckboxSelectorColumn") Then

                e.DisplayText = ""

            End If

        End Sub
        Private Sub DataGridViewSelectOthers_Others_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSelectOthers_Others.EmbeddedNavigatorButtonClick

            Dim GLAOtherCodeList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode) = Nothing

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSelectOthers_Others.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        GLAOtherCodeList = DataGridViewSelectOthers_Others.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.GLAOtherCode)().ToList

                        For Each GLAOtherCode In GLAOtherCodeList

                            If GLAOtherCode.AddedForChartOfAccountWizard Then

                                DataGridViewSelectOthers_Others.CurrentView.DeleteFromDataSource(GLAOtherCode)

                            End If

                        Next

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSelectOthers_Others_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectOthers_Others.ShowingEditorEvent

            If DataGridViewSelectOthers_Others.IsNewItemRow(DataGridViewSelectOthers_Others.CurrentView.FocusedRowHandle) = False Then

                e.Cancel = True

            ElseIf DataGridViewSelectOthers_Others.IsNewItemRow(DataGridViewSelectOthers_Others.CurrentView.FocusedRowHandle) = True AndAlso _
                    DataGridViewSelectOthers_Others.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.GeneralLedger.Classes.GLAOtherCode.Properties.Code.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ButtonSelectAccountTypes_SelectAll_Click(sender As Object, e As EventArgs) Handles ButtonSelectAccountTypes_SelectAll.Click

            For Each CheckBox In GroupBoxSelectAccountTypes_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox).ToList

                CheckBox.Checked = True

            Next

        End Sub
        Private Sub ButtonSelectAccountTypes_DeselectAll_Click(sender As Object, e As EventArgs) Handles ButtonSelectAccountTypes_DeselectAll.Click

            For Each CheckBox In GroupBoxSelectAccountTypes_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox).ToList

                CheckBox.Checked = False

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace
