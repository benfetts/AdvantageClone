Namespace Billing.Presentation

    Public Class BillingCommandCenterForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _HasJobsSelected As Boolean = False
        Private _HasOrdersSelected As Boolean = False
        Private _IsMultiCurrencyEnabled As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadUserBatches()

            Dim UserBatches As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.UserBatch) = Nothing

            UserBatches = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.UserBatch)

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                UserBatches.AddRange(From BCC In AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByUser(BCCDbContext, BCCDbContext.UserCode).ToList
                                     Select New AdvantageFramework.BillingCommandCenter.Classes.UserBatch(BCC))

                DataGridViewLeftSection_UserBatches.DataSource = UserBatches

            End Using

            DataGridViewLeftSection_UserBatches.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub LoadBillingCommandCenter(ByVal BillingCommandCenterID As Integer)

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            For Each RadioButtonControl In GroupBoxProduction_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                RadioButtonControl.Checked = False

            Next

            SearchableComboBoxProduction_BillingApprovalBatch.SelectedValue = Nothing
            DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = Nothing
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = Nothing
            ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = Nothing

            CheckBoxCutoff_LockRecords.Checked = False

            DateTimePickerMediaType_DateFrom.ValueObject = DateSerial(Now.Year, Now.Month, 1)
            DateTimePickerMediaType_DateTo.ValueObject = DateSerial(Now.Year, Now.Month + 1, 0)

            DateTimePickerJobMedia_DateFrom.ValueObject = Nothing
            DateTimePickerJobMedia_DateTo.ValueObject = Nothing

            ComboBoxMediaBroadcast_MonthFrom.SelectedValue = CLng(Now.Month)
            ComboBoxMediaBroadcast_MonthTo.SelectedValue = CLng(Now.Month)

            NumericInputMediaBroadcast_YearFrom.EditValue = Now.Year
            NumericInputMediaBroadcast_YearTo.EditValue = Now.Year

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ComboBoxProductionCutoffs_APPostingPeriod.RemoveAddedItemsFromDataSource()
                    ComboBoxProductionCutoffs_APPostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(PP) PP.Code).ToList

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                        BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_bcc_in_use {0}, 1, 0", BillingCommandCenterID))

                        If BillingCommandCenter.IsProduction.GetValueOrDefault(False) = True Then

                            If BillingCommandCenter.BillingApprovalBatchID IsNot Nothing Then

                                SearchableComboBoxProduction_BillingApprovalBatch.SelectedValue = BillingCommandCenter.BillingApprovalBatchID
                                SearchableComboBoxProduction_BillingApprovalBatch.Enabled = True

                            Else

                                SearchableComboBoxProduction_BillingApprovalBatch.Enabled = False

                            End If

                            For Each RadioButtonControl In GroupBoxProduction_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                                If RadioButtonControl.Tag = BillingCommandCenter.ProductionSelectBy.GetValueOrDefault(0) Then

                                    RadioButtonControl.Checked = True
                                    GroupBoxProduction_SelectBy.Tag = RadioButtonControl.Tag
                                    Exit For

                                End If

                            Next

                            For Each RadioButtonControl In GroupBoxProduction_TypeOfJob.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                                If RadioButtonControl.Tag = BillingCommandCenter.ProductionJobType.GetValueOrDefault(1) Then

                                    RadioButtonControl.Checked = True
                                    Exit For

                                End If

                            Next

                            For Each RadioButtonControl In GroupBoxProduction_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                                If RadioButtonControl.Tag = BillingCommandCenter.ProductionSelectionOption.GetValueOrDefault(1) Then

                                    RadioButtonControl.Checked = True
                                    Exit For

                                End If

                            Next

                            CheckBoxCutoff_LockRecords.Checked = BillingCommandCenter.IsProductionSelectionLocked

                        Else

                            SearchableComboBoxProduction_BillingApprovalBatch.Enabled = True
                            RadioButtonProductionSelectBy_AllEligibleJobs.Checked = True
                            RadioButtonProductionTypeOfJob_All.Checked = True
                            RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Checked = True

                        End If

                        DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = If(BillingCommandCenter.EmployeeTimeDateCutoff Is Nothing, Nothing, BillingCommandCenter.EmployeeTimeDateCutoff)
                        DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = If(BillingCommandCenter.IncomeOnlyDateCutoff Is Nothing, Nothing, BillingCommandCenter.IncomeOnlyDateCutoff)

                        If BillingCommandCenter.APPostPeriodCodeCutoff IsNot Nothing Then

                            ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = BillingCommandCenter.APPostPeriodCodeCutoff

                            If ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue Is Nothing AndAlso BillingCommandCenter.APPostPeriodCodeCutoff IsNot Nothing Then

                                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, BillingCommandCenter.APPostPeriodCodeCutoff)

                                If PostPeriod IsNot Nothing Then

                                    ComboBoxProductionCutoffs_APPostingPeriod.AddComboItemToExistingDataSource(PostPeriod.ToString, PostPeriod.Code, True)

                                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = BillingCommandCenter.APPostPeriodCodeCutoff

                                End If

                            End If

                        Else

                            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

                            If PostPeriod IsNot Nothing Then

                                ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = PostPeriod.Code

                            End If

                        End If

                        CheckBoxProduction_IncludeJobDateToBill.Checked = BillingCommandCenter.ProductionIncludeJobMediaBillDates

                        If BillingCommandCenter.ProductionJobMediaBillDateFrom.HasValue Then

                            DateTimePickerProductionJobMedia_DateFrom.ValueObject = BillingCommandCenter.ProductionJobMediaBillDateFrom.Value

                        End If

                        If BillingCommandCenter.ProductionJobMediaBillDateTo.HasValue Then

                            DateTimePickerProductionJobMedia_DateTo.ValueObject = BillingCommandCenter.ProductionJobMediaBillDateTo.Value

                        End If

                        LoadProductionSelection()

                        _HasJobsSelected = CBool(BCCDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.JOB_COMPONENT WHERE BCC_ID = {0}", BillingCommandCenter.ID)).FirstOrDefault)

                        If BillingCommandCenter.IsMedia.GetValueOrDefault(False) = True Then

                            If BillingCommandCenter.DateCuttoffToUseFlag.GetValueOrDefault(0) <> 0 Then

                                ComboBoxMedia_SelectBy.SelectedValue = BillingCommandCenter.DateCuttoffToUseFlag

                            End If

                            CheckBoxMediaType_Newspaper.Checked = BillingCommandCenter.IsNewspaper.GetValueOrDefault(False)
                            CheckBoxMediaType_Magazine.Checked = BillingCommandCenter.IsMagazine.GetValueOrDefault(False)
                            CheckBoxMediaType_OutOfHome.Checked = BillingCommandCenter.IsOutOfHome.GetValueOrDefault(False)
                            CheckBoxMediaType_Internet.Checked = BillingCommandCenter.IsInternet.GetValueOrDefault(False)
                            CheckBoxMediaType_RadioDaily.Checked = BillingCommandCenter.IsRadioDaily.GetValueOrDefault(False)
                            CheckBoxMediaType_TelevisionDaily.Checked = BillingCommandCenter.IsTelevisionDaily.GetValueOrDefault(False)

                            If BillingCommandCenter.MediaStartDate.HasValue Then

                                DateTimePickerMediaType_DateFrom.ValueObject = BillingCommandCenter.MediaStartDate.Value

                            End If

                            If BillingCommandCenter.MediaEndDate.HasValue Then

                                DateTimePickerMediaType_DateTo.ValueObject = BillingCommandCenter.MediaEndDate.Value

                            End If

                            CheckBoxMediaBroadcast_Radio.Checked = BillingCommandCenter.IsRadioMonthly.GetValueOrDefault(False)
                            CheckBoxMediaBroadcast_Television.Checked = BillingCommandCenter.IsTelevisionMonthly.GetValueOrDefault(False)

                            If BillingCommandCenter.MediaBroadcastMonthStart.HasValue Then

                                ComboBoxMediaBroadcast_MonthFrom.SelectedValue = CLng(BillingCommandCenter.MediaBroadcastMonthStart.Value.Month)

                            End If

                            If BillingCommandCenter.MediaBroadcastMonthEnd.HasValue Then

                                ComboBoxMediaBroadcast_MonthTo.SelectedValue = CLng(BillingCommandCenter.MediaBroadcastMonthEnd.Value.Month)

                            End If

                            NumericInputMediaBroadcast_YearFrom.EditValue = If(BillingCommandCenter.MediaBroadcastMonthStart.HasValue, BillingCommandCenter.MediaBroadcastMonthStart.Value.Year, Nothing)
                            NumericInputMediaBroadcast_YearTo.EditValue = If(BillingCommandCenter.MediaBroadcastMonthEnd.HasValue, BillingCommandCenter.MediaBroadcastMonthEnd.Value.Year, Nothing)

                            For Each RadioButtonControl In GroupBoxMedia_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                                If RadioButtonControl.Tag = BillingCommandCenter.MediaSelectBy.GetValueOrDefault(0) Then

                                    RadioButtonControl.Checked = True
                                    RadioButtonControl.Focus()
                                    Exit For

                                End If

                            Next

                            If BillingCommandCenter.JobMediaBillDateFrom.HasValue Then

                                DateTimePickerJobMedia_DateFrom.ValueObject = BillingCommandCenter.JobMediaBillDateFrom.Value

                            End If

                            If BillingCommandCenter.JobMediaBillDateTo.HasValue Then

                                DateTimePickerJobMedia_DateTo.ValueObject = BillingCommandCenter.JobMediaBillDateTo.Value

                            End If

                            CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked = CBool(BillingCommandCenter.IncludeUnbilledOrdersOnly.GetValueOrDefault(0))
                            CheckBoxMedia_IncludeSpots.Checked = BillingCommandCenter.IncludeZeroSpots.GetValueOrDefault(False)
                            'CheckBoxMedia_IncludeLegacyBroadcast.Checked = BillingCommandCenter.IncludeLegacy

                        Else

                            If BillingCommandCenter.DateCuttoffToUseFlag.GetValueOrDefault(0) <> 0 Then

                                ComboBoxMedia_SelectBy.SelectedValue = BillingCommandCenter.DateCuttoffToUseFlag

                            End If

                            RadioButtonMediaSelectBy_AllEligibleOrders.Checked = True

                            SetMediaCheckboxes(False)

                        End If

                        LoadMediaSelection()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The batch you are attempting to load no longer exists.")

                    End If

                End Using

            End Using

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub AddBatch(ByVal ShowDialog As Boolean)

            Dim BillingCommandCenterID As Integer = 0
            Dim ErrorMessage As String = ""

            If ShowDialog AndAlso AdvantageFramework.Billing.Presentation.BillingCommandCenterBatchEditDialog.ShowFormDialog(BillingCommandCenterID) = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Adding

                LoadUserBatches()

                For RowHandle = 0 To DataGridViewLeftSection_UserBatches.CurrentView.RowCount - 1

                    If DirectCast(DataGridViewLeftSection_UserBatches.DataSource, System.Windows.Forms.BindingSource).Item(DataGridViewLeftSection_UserBatches.CurrentView.GetDataSourceRowIndex(RowHandle)).ID = BillingCommandCenterID Then

                        DataGridViewLeftSection_UserBatches.CurrentView.FocusedRowHandle = RowHandle

                        LoadBillingCommandCenter(BillingCommandCenterID)

                    End If

                Next

                Me.FormAction = WinForm.Presentation.FormActions.None

            ElseIf Not ShowDialog Then

                Using BCCDbContext = New AdvantageFramework.BillingCommandCenter.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.BillingCommandCenter.CreateNewBatch(BCCDbContext, Me.Session.UserCode, Nothing, ErrorMessage)

                    If ErrorMessage = "" Then

                        LoadUserBatches()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End Using

            End If

        End Sub
        Private Sub ClearTabControl()

            Me.FormAction = WinForm.Presentation.FormActions.Clearing

            CheckBoxProduction_IncludeFinishedBatches.Checked = False
            SearchableComboBoxProduction_BillingApprovalBatch.SelectedValue = Nothing

            DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = Nothing
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = Nothing
            ComboBoxProductionCutoffs_APPostingPeriod.SelectedItem = Nothing

            DateTimePickerMediaType_DateFrom.ValueObject = Nothing
            DateTimePickerMediaType_DateTo.ValueObject = Nothing

            ComboBoxMediaBroadcast_MonthFrom.SelectedValue = Nothing
            ComboBoxMediaBroadcast_MonthTo.SelectedValue = Nothing

            NumericInputMediaBroadcast_YearFrom.Value = Nothing
            NumericInputMediaBroadcast_YearTo.Value = Nothing

            DateTimePickerJobMedia_DateFrom.ValueObject = Nothing
            DateTimePickerJobMedia_DateTo.ValueObject = Nothing

            SetMediaCheckboxes(False)

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub SetMediaCheckboxes(ByVal Checked As Boolean)

            CheckBoxMediaType_Internet.Checked = Checked
            CheckBoxMediaType_Magazine.Checked = Checked
            CheckBoxMediaType_Newspaper.Checked = Checked
            CheckBoxMediaType_OutOfHome.Checked = Checked
            CheckBoxMediaType_RadioDaily.Checked = Checked
            CheckBoxMediaType_TelevisionDaily.Checked = Checked

            CheckBoxMediaBroadcast_Radio.Checked = Checked
            CheckBoxMediaBroadcast_Television.Checked = Checked

        End Sub
        Private Function ProductionHasSelection() As Boolean

            Dim HasSelection As Boolean = False

            If RadioButtonProductionSelectBy_AccountExecutive.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByAccountExecutive).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_BillingApproval.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_Campaign.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_Client.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClient).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_ClientDivision.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_ClientDivisionProduct.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_Job.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_JobComponent.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_SalesClass.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            ElseIf RadioButtonProductionSelectBy_ClientBiller.Checked AndAlso
                    DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientBiller).Where(Function(Entity) Entity.IsSelected = 1).Any Then

                HasSelection = True

            End If

            ProductionHasSelection = HasSelection

        End Function
        Private Function Save() As Boolean

            'objects
            Dim AllowContinue As Boolean = True
            Dim BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
            Dim ErrorMessage As String = ""
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim IsValid As Boolean = True
            Dim Saved As Boolean = False
            Dim JobComponentsMarked As Integer = Nothing
            Dim OrderLinesMarked As Integer = Nothing
            Dim BroadcastOrdersMarked As Integer = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    If TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab Then

                        If Not RadioButtonProductionSelectBy_AllEligibleJobs.Checked AndAlso ProductionHasSelection() = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("No selections made.")
                            AllowContinue = False

                        End If

                    ElseIf TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_MediaSelectionTab Then

                        If Not GroupBoxMedia_SelectBy.Enabled Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select at least one media type.")
                            AllowContinue = False

                        ElseIf Not RadioButtonMediaSelectBy_AllEligibleOrders.Checked AndAlso
                                DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable).Where(Function(MSA) MSA.IsSelected = True).Any = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("No selections made.")
                            AllowContinue = False

                        End If

                    End If

                    If AllowContinue Then

                        Me.ShowWaitForm("Saving...")

                        Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

                            If BillingCommandCenter IsNot Nothing Then

                                LoadBillingCommandCenterEntity(BillingCommandCenter)

                                BillingCommandCenter.DbContext = BCCDbContext

                                ErrorMessage = BillingCommandCenter.ValidateEntity(IsValid)

                                If IsValid Then

                                    Try

                                        BCCDbContext.Database.Connection.Open()

                                        DbTransaction = BCCDbContext.Database.BeginTransaction

                                        If TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab Then

                                            SaveProductionSelections(BCCDbContext, BillingCommandCenter)

                                            JobComponentsMarked = BCCDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.JOB_COMPONENT (NOLOCK) WHERE BCC_ID = {0}", BillingCommandCenter.ID)).FirstOrDefault

                                        ElseIf TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_MediaSelectionTab Then

                                            SaveMediaSelections(BCCDbContext, BillingCommandCenter)

                                            OrderLinesMarked = BCCDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.BCC_ORDER_LINE (NOLOCK) WHERE BCC_ID = {0}", BillingCommandCenter.ID)).FirstOrDefault

                                            BroadcastOrdersMarked = BCCDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.BCC_ORDER_BRDCAST (NOLOCK) WHERE BCC_ID = {0}", BillingCommandCenter.ID)).FirstOrDefault

                                        End If

                                        If JobComponentsMarked = 0 AndAlso OrderLinesMarked = 0 AndAlso BroadcastOrdersMarked = 0 Then

                                            AdvantageFramework.WinForm.MessageBox.Show("Selection does not include any qualifying detail.  Please adjust your selection or criteria and try again.")

                                        Else

                                            AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Update(BCCDbContext, BillingCommandCenter)

                                            AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, False)

                                            BCCDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET COOP_SAVED = 1 WHERE BILLING_USER = '{0}'", BillingCommandCenter.BillingUser))

                                            DbTransaction.Commit()

                                            Saved = True

                                        End If

                                        If Saved Then

                                            If OrderLinesMarked <> 0 OrElse BroadcastOrdersMarked <> 0 Then

                                                SaveLastMediaDateToUse()

                                            End If

                                            LoadBillingCommandCenter(BillingCommandCenter.ID)

                                        End If

                                    Catch ex As Exception
                                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                        ErrorMessage += vbCrLf & ex.Message
                                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                                    Finally

                                        If BCCDbContext.Database.Connection.State = ConnectionState.Open Then

                                            BCCDbContext.Database.Connection.Close()

                                        End If

                                    End Try

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The billing command center item you are trying to save does not exist.")

                            End If

                        End Using

                        Me.CloseWaitForm()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a batch to save.")

            End If

            Save = Saved

        End Function
        Private Sub LoadProductionSelection()

            'objects
            Dim BillApprovalBatchID As Nullable(Of Integer) = Nothing
            Dim BillingCommandCenterID As Integer = Nothing
            Dim BillingUser As String = Nothing
            Dim MediaDateFrom As Nullable(Of Date) = Nothing
            Dim MediaDateTo As Nullable(Of Date) = Nothing

            If SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue Then

                BillApprovalBatchID = SearchableComboBoxProduction_BillingApprovalBatch.GetSelectedValue

            End If

            BillingCommandCenterID = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)
            BillingUser = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(1)

            If CheckBoxProduction_IncludeJobDateToBill.Checked Then

                MediaDateFrom = DateTimePickerProductionJobMedia_DateFrom.GetValue
                MediaDateTo = DateTimePickerProductionJobMedia_DateTo.GetValue

            End If

            Me.ShowWaitForm("Loading...")

            DataGridViewProduction_Selections.ClearGridCustomization()
            DataGridViewProduction_Selections.ShowSelectDeselectAllButtons = True

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If RadioButtonProductionSelectBy_AllEligibleJobs.Checked Then

                    DataGridViewProduction_Selections.DataSource = Nothing
                    DataGridViewProduction_Selections.ShowSelectDeselectAllButtons = False

                ElseIf RadioButtonProductionSelectBy_BillingApproval.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByBillingApproval(BCCDbContext, BillingCommandCenterID, BillApprovalBatchID, CheckBoxProduction_IncludeFinishedBatches.Checked, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_AccountExecutive.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByAccountExecutive(BCCDbContext, BillingCommandCenterID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_Client.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByClient(BCCDbContext, BillingCommandCenterID, BillApprovalBatchID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_ClientDivision.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByClientDivision(BCCDbContext, BillingCommandCenterID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_ClientDivisionProduct.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByClientDivisionProduct(BCCDbContext, BillingCommandCenterID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_Campaign.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByCampaign(BCCDbContext, BillingCommandCenterID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_SalesClass.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionBySalesClass(BCCDbContext, BillingCommandCenterID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_Job.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByJob(BCCDbContext, BillingCommandCenterID, BillApprovalBatchID, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_JobComponent.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByJobComponent(BCCDbContext, BillingCommandCenterID, BillApprovalBatchID, BillingUser, MediaDateFrom, MediaDateTo)

                ElseIf RadioButtonProductionSelectBy_ClientBiller.Checked Then

                    DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetProductionSelectionByClientBiller(BCCDbContext, BillingCommandCenterID, BillApprovalBatchID, BillingUser, MediaDateFrom, MediaDateTo)

                End If

                DataGridViewProduction_Selections.CurrentView.ViewCaption = DataGridViewProduction_Selections.CurrentView.RowCount & " Available Production Selection(s)"

                If Not RadioButtonProductionSelectBy_AllEligibleJobs.Checked Then

                    ToggleProductionColumnVisibility()

                End If

            End Using

            Me.CloseWaitForm()

        End Sub
        Private Function GetMediaSelectBy() As Short

            Dim MediaSelectBy As Short = Nothing

            If RadioButtonMediaSelectBy_AllEligibleOrders.Checked Then

                MediaSelectBy = 0

            ElseIf RadioButtonMediaSelectBy_Campaign.Checked Then

                MediaSelectBy = 1

            ElseIf RadioButtonMediaSelectBy_Client.Checked Then

                MediaSelectBy = 2

            ElseIf RadioButtonMediaSelectBy_ClientDivision.Checked Then

                MediaSelectBy = 3

            ElseIf RadioButtonMediaSelectBy_ClientDivisionProduct.Checked Then

                MediaSelectBy = 4

            ElseIf RadioButtonMediaSelectBy_ClientPO.Checked Then

                MediaSelectBy = 6

            ElseIf RadioButtonMediaSelectBy_LineNumber.Checked Then

                MediaSelectBy = 8

            ElseIf RadioButtonMediaSelectBy_Market.Checked Then

                MediaSelectBy = 7

            ElseIf RadioButtonMediaSelectBy_OrderNumber.Checked Then

                MediaSelectBy = 5

            ElseIf RadioButtonMediaSelectBy_ClientBiller.Checked Then

                MediaSelectBy = 9

            End If

            GetMediaSelectBy = MediaSelectBy

        End Function
        Private Sub LoadMediaSelection()

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim MediaSelectionAvailableList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable) = Nothing
            Dim MediaBroadcastMonthStart As Nullable(Of Date) = Nothing
            Dim MediaBroadcastMonthEnd As Nullable(Of Date) = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.Modifying Then

                Me.ShowWaitForm("Loading...")

                DataGridViewMedia_Selections.ClearGridCustomization()

                If Not RadioButtonMediaSelectBy_AllEligibleOrders.Checked Then

                    DataGridViewMedia_Selections.ShowSelectDeselectAllButtons = True

                    If CheckBoxMediaType_Newspaper.Checked OrElse CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_RadioDaily.Checked OrElse
                            CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                        Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

                            If BillingCommandCenter IsNot Nothing Then

                                If CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                                    MediaBroadcastMonthStart = DateSerial(NumericInputMediaBroadcast_YearFrom.GetValue, ComboBoxMediaBroadcast_MonthFrom.GetSelectedValue, 1)
                                    MediaBroadcastMonthEnd = DateSerial(NumericInputMediaBroadcast_YearTo.GetValue, ComboBoxMediaBroadcast_MonthTo.GetSelectedValue, 1)

                                End If

                                MediaSelectionAvailableList = AdvantageFramework.BillingCommandCenter.GetMediaSelectionAvailable(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, GetMediaSelectBy,
                                    CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                    ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                    CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                    CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                    DateTimePickerMediaType_DateFrom.GetValue, DateTimePickerMediaType_DateTo.GetValue, MediaBroadcastMonthStart, MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue)

                                DataGridViewMedia_Selections.DataSource = MediaSelectionAvailableList

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The billing command center item you are trying to save does not exist.")

                            End If

                            ToggleMediaColumnVisibility()

                        End Using

                    Else

                        DataGridViewMedia_Selections.ClearDatasource()

                    End If

                    DataGridViewMedia_Selections.CurrentView.BestFitColumns()

                Else

                    DataGridViewMedia_Selections.ShowSelectDeselectAllButtons = False

                End If

                DataGridViewMedia_Selections.CurrentView.ViewCaption = DataGridViewMedia_Selections.CurrentView.RowCount & " Available Media Selection(s)"

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadSelectedBatch()

            ClearTabControl()

            If DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                DataGridViewLeftSection_UserBatches.OptionsView.ShowIndicator = True

                LoadBillingCommandCenter(DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

            End If

            Me.ClearChanged()

        End Sub
        Private Function IsMediaTypeChecked() As Boolean

            'objects
            Dim MediaTypeIsChecked As Boolean = False

            For Each CheckBox In GroupBoxMedia_Types.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If CheckBox.Checked Then

                    MediaTypeIsChecked = True
                    Exit For

                End If

            Next

            IsMediaTypeChecked = MediaTypeIsChecked

        End Function
        Private Sub EnableOrDisableActions()

            'objects
            Dim MediaTypeIsChecked As Boolean = False
            Dim SelectMediaByJobMediaDateToBill As Boolean = False

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ClearValidations()

                TabControlForm_BillingCommandCenter.Enabled = Me.FormShown AndAlso DataGridViewLeftSection_UserBatches.OptionsView.ShowIndicator AndAlso DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow

                MediaTypeIsChecked = IsMediaTypeChecked()

                RibbonBarMergeContainerForm_Options.SuspendLayout()

                DateTimePickerProductionCutoffs_EmployeeTimeDate.SetRequired(TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab)
                DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.SetRequired(TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab)
                ComboBoxProductionCutoffs_APPostingPeriod.SetRequired(TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab)

                DateTimePickerMediaType_DateFrom.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso MediaTypeIsChecked)
                DateTimePickerMediaType_DateTo.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso MediaTypeIsChecked)

                ComboBoxMediaBroadcast_MonthFrom.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
                ComboBoxMediaBroadcast_MonthTo.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
                NumericInputMediaBroadcast_YearFrom.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
                NumericInputMediaBroadcast_YearTo.SetRequired(ComboBoxMedia_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))

                If ComboBoxMedia_SelectBy.SelectedValue = 3 Then

                    SelectMediaByJobMediaDateToBill = True

                End If

                DateTimePickerJobMedia_DateFrom.SetRequired(TabControlForm_BillingCommandCenter.SelectedTab.Equals(TabItemBillingCommandCenter_MediaSelectionTab) AndAlso SelectMediaByJobMediaDateToBill)
                DateTimePickerJobMedia_DateTo.SetRequired(TabControlForm_BillingCommandCenter.SelectedTab.Equals(TabItemBillingCommandCenter_MediaSelectionTab) AndAlso SelectMediaByJobMediaDateToBill)

                If TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab Then

                    ButtonItemActions_Save.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso Me.CheckUserEntryChangedSetting

                    DateTimePickerProductionCutoffs_EmployeeTimeDate.ReadOnly = SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ReadOnly = SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    ComboBoxProductionCutoffs_APPostingPeriod.ReadOnly = SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue

                    RadioButtonProductionSelectBy_AccountExecutive.Enabled = Not SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    RadioButtonProductionSelectBy_Campaign.Enabled = Not SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    RadioButtonProductionSelectBy_ClientDivision.Enabled = Not SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    RadioButtonProductionSelectBy_ClientDivisionProduct.Enabled = Not SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue
                    RadioButtonProductionSelectBy_SalesClass.Enabled = Not SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue

                    DateTimePickerProductionJobMedia_DateFrom.Enabled = CheckBoxProduction_IncludeJobDateToBill.Checked
                    DateTimePickerProductionJobMedia_DateFrom.SetRequired(CheckBoxProduction_IncludeJobDateToBill.Checked)

                    DateTimePickerProductionJobMedia_DateTo.Enabled = CheckBoxProduction_IncludeJobDateToBill.Checked
                    DateTimePickerProductionJobMedia_DateTo.SetRequired(CheckBoxProduction_IncludeJobDateToBill.Checked)

                ElseIf TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_MediaSelectionTab Then

                    ButtonItemActions_Save.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso Me.CheckUserEntryChangedSetting

                    CheckBoxMedia_IncludeSpots.AutoCheck = CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaType_TelevisionDaily.Checked OrElse
                        CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked

                    'CheckBoxMedia_IncludeLegacyBroadcast.AutoCheck = CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked

                    GroupBoxMedia_JobMediaDateToBillDateRange.Enabled = SelectMediaByJobMediaDateToBill

                    DateTimePickerMediaType_DateFrom.Enabled = Not SelectMediaByJobMediaDateToBill
                    DateTimePickerMediaType_DateTo.Enabled = Not SelectMediaByJobMediaDateToBill
                    ComboBoxMediaBroadcast_MonthFrom.Enabled = Not SelectMediaByJobMediaDateToBill
                    ComboBoxMediaBroadcast_MonthTo.Enabled = Not SelectMediaByJobMediaDateToBill
                    NumericInputMediaBroadcast_YearFrom.Enabled = Not SelectMediaByJobMediaDateToBill
                    NumericInputMediaBroadcast_YearTo.Enabled = Not SelectMediaByJobMediaDateToBill

                End If

                ButtonItemActions_Delete.Enabled = TabControlForm_BillingCommandCenter.Enabled

                ButtonItemView_ProductionReview.Visible = TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_ProductionSelectionTab
                ButtonItemView_ProductionReview.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _HasJobsSelected

                ButtonItemView_MediaReview.Visible = TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_MediaSelectionTab
                ButtonItemView_MediaReview.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso Not Me.CheckUserEntryChangedSetting AndAlso (IsMediaTypeChecked() OrElse CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked)

                ButtonItemProcessInvoices_Process.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed = False
                ButtonItemProcessInvoices_CoopSplits.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.HasCoopJobs AndAlso _BillingStatus.IsAssigned.GetValueOrDefault(0) = 0
                ButtonItemProcessInvoices_Draft.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsPrinted = 0
                ButtonItemProcessInvoices_Print.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1

                If TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsAssigned = 1 Then

                    ButtonItemProcessInvoices_Assign.Enabled = True
                    ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceAssignedImage

                    TabControlPanelProductionSelection_Details.Enabled = False
                    TabControlPanelMediaSelection_Details.Enabled = False

                    ButtonItemActions_Delete.Enabled = False
                    ButtonItemProcessInvoices_Draft.Enabled = False

                Else

                    ButtonItemProcessInvoices_Assign.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0
                    ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage

                    TabControlPanelProductionSelection_Details.Enabled = True
                    TabControlPanelMediaSelection_Details.Enabled = True

                    ButtonItemActions_Delete.Enabled = True

                End If

                ButtonItemProcessInvoices_Currency.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0

                ButtonItemProcessInvoices_Finish.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1
                ButtonItemProcessInvoices_FinishDelete.Enabled = TabControlForm_BillingCommandCenter.Enabled AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1

                ButtonItemView_OtherUserSelections.Enabled = TabControlForm_BillingCommandCenter.Enabled

                NumericInputProductionSelectBy_JobNumber.Visible = RadioButtonProductionSelectBy_Job.Checked OrElse RadioButtonProductionSelectBy_JobComponent.Checked

                NumericInputMediaSelectBy_OrderNumber.Visible = RadioButtonMediaSelectBy_OrderNumber.Checked OrElse RadioButtonMediaSelectBy_LineNumber.Checked

                If Me.FormShown Then

                    RibbonBarOptions_View.ResetCachedContentSize()

                    RibbonBarOptions_View.Refresh()

                    RibbonBarOptions_View.Width = RibbonBarOptions_View.GetAutoSizeWidth

                    RibbonBarOptions_View.Refresh()

                End If

                RibbonBarMergeContainerForm_Options.ResumeLayout()

                EnableDisableMediaGroup()

            End If

        End Sub
        Private Function GetProductionSelectionOption() As Integer

            'objects
            Dim SelectionOption As Integer = 0

            For Each RadioButtonControl In GroupBoxProduction_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    SelectionOption = CInt(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            GetProductionSelectionOption = SelectionOption

        End Function
        Private Function GetProductionTypeOfJob() As Integer

            'objects
            Dim TypeOfJob As Integer = 0

            For Each RadioButtonControl In GroupBoxProduction_TypeOfJob.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    TypeOfJob = CInt(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            GetProductionTypeOfJob = TypeOfJob

        End Function
        Private Sub SaveLastMediaDateToUse()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.BCCLastMediaDateToUse.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso ComboBoxMedia_SelectBy.HasASelectedValue Then

                    UserSetting.StringValue = ComboBoxMedia_SelectBy.GetSelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing AndAlso ComboBoxMedia_SelectBy.HasASelectedValue Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.BCCLastMediaDateToUse.ToString, ComboBoxMedia_SelectBy.GetSelectedValue, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SaveMediaSelections(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                        ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter)

            'objects
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim Clients As IEnumerable(Of String) = Nothing
            Dim ClientDivisions As IEnumerable(Of String) = Nothing
            Dim ClientDivisionProducts As IEnumerable(Of String) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
            Dim ClientPOs As IEnumerable(Of String) = Nothing
            Dim Markets As IEnumerable(Of String) = Nothing
            Dim ClientBillers As IEnumerable(Of String) = Nothing

            AdvantageFramework.BillingCommandCenter.DeleteMediaSelection(Session, BillingCommandCenter.ID, BillingCommandCenter.BillingUser)

            For Each RadioButtonControl In GroupBoxMedia_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    Select Case CInt(RadioButtonControl.Tag)

                        Case 0 'all eligible orders

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 0, Nothing, Nothing,
                                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 1 'campaign

                            CampaignIDs = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.CampaignID.Value).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 1, CampaignIDs, Nothing,
                                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 2 'client

                            Clients = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.ClientCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 2, Nothing, Clients,
                                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 3 'client/division

                            ClientDivisions = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.ClientCode + "|" + MSA.DivisionCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 3, Nothing, Nothing,
                                ClientDivisions, Nothing, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 4 'client/division/product

                            ClientDivisionProducts = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.ClientCode + "|" + MSA.DivisionCode + "|" + MSA.ProductCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 4, Nothing, Nothing,
                                Nothing, ClientDivisionProducts, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 5 'order number

                            OrderNumbers = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.OrderNumber.Value).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 5, Nothing, Nothing,
                                Nothing, Nothing, OrderNumbers, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 6 'client PO

                            ClientPOs = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.ClientCode + "|" + MSA.DivisionCode + "|" + MSA.ProductCode + "|" + MSA.ClientPO).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 6, Nothing, Nothing,
                                Nothing, Nothing, Nothing, Nothing, ClientPOs, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 7 'market

                            Markets = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.MarketCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 7, Nothing, Nothing,
                                Nothing, Nothing, Nothing, Nothing, Nothing, Markets, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 8 'line number

                            OrderNumberLineNumbers = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.OrderNumber.ToString + "|" + MSA.LineNumber.ToString).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 8, Nothing, Nothing,
                                Nothing, Nothing, Nothing, OrderNumberLineNumbers, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, Nothing)

                        Case 9 'client Biller

                            ClientBillers = DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)().Where(Function(MSA) MSA.IsSelected = True).Select(Function(MSA) MSA.BillerEmployeeCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateMediaSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 9, Nothing, Nothing,
                                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, CheckBoxMedia_IncludeSpots.Checked,
                                ComboBoxMedia_SelectBy.SelectedValue, CheckBoxMediaType_Newspaper.Checked, CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked,
                                CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaBroadcast_Radio.Checked, CheckBoxMediaType_RadioDaily.Checked, CheckBoxMediaBroadcast_Radio.Checked,
                                CheckBoxMediaType_TelevisionDaily.Checked OrElse CheckBoxMediaBroadcast_Television.Checked, CheckBoxMediaType_TelevisionDaily.Checked, CheckBoxMediaBroadcast_Television.Checked,
                                BillingCommandCenter.MediaStartDate, BillingCommandCenter.MediaEndDate, BillingCommandCenter.MediaBroadcastMonthStart, BillingCommandCenter.MediaBroadcastMonthEnd, CheckBoxMedia_IncludeLegacyBroadcast.Checked, DateTimePickerJobMedia_DateFrom.GetValue, DateTimePickerJobMedia_DateTo.GetValue, ClientBillers)

                    End Select

                    Exit For

                End If

            Next

        End Sub
        Private Sub SaveProductionSelections(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                             ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter)

            'objects
            Dim Clients As IEnumerable(Of String) = Nothing
            Dim ClientDivisions As IEnumerable(Of String) = Nothing
            Dim ClientDivisionProducts As IEnumerable(Of String) = Nothing
            Dim BillingApprovalHeaderIDs As IEnumerable(Of Integer) = Nothing
            Dim AccountExecutives As IEnumerable(Of String) = Nothing
            Dim SalesClasses As IEnumerable(Of String) = Nothing
            Dim Campaigns As IEnumerable(Of Integer) = Nothing
            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
            Dim JobComponentRowIDs As IEnumerable(Of Integer) = Nothing
            Dim SelectionOption As Integer = Nothing
            Dim TypeOfJob As Integer = Nothing
            Dim BatchID As Integer = 0
            Dim BillerEmployeeCodes As IEnumerable(Of String) = Nothing

            SelectionOption = GetProductionSelectionOption()

            TypeOfJob = GetProductionTypeOfJob()

            If SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue Then

                BatchID = SearchableComboBoxProduction_BillingApprovalBatch.GetSelectedValue

            End If

            BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_delete_billing_cmd_center_prod '{0}', 0", BillingCommandCenter.BillingUser))

            BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.W_AR_FUNCTION WHERE BILLING_USER = '{0}'", BillingCommandCenter.BillingUser))

            For Each RadioButtonControl In GroupBoxProduction_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    Select Case CInt(RadioButtonControl.Tag)

                        Case 0 'all

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 0, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 2 'client

                            Clients = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClient)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.ClientCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 2, Clients, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 3 'client/division

                            ClientDivisions = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 3, Nothing, ClientDivisions, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 4 'client/division/product

                            ClientDivisionProducts = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode + "|" + Entity.ProductCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 4, Nothing, Nothing, ClientDivisionProducts, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 5 'campaign

                            Campaigns = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.CampaignID).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 5, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Campaigns, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 6 'job

                            JobNumbers = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.JobNumber).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 6, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, JobNumbers, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 7 'job/component

                            JobComponentRowIDs = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.ID).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 7, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, JobComponentRowIDs, BatchID, Nothing, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 8 'billing approval

                            BillingApprovalHeaderIDs = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.BillingApprovalHeaderID).Distinct.ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 8, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, BillingApprovalHeaderIDs, Nothing, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 9 'sales class

                            SalesClasses = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.SalesClassCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 9, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, SalesClasses, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 10 'acct exec

                            AccountExecutives = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByAccountExecutive)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.EmployeeCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 10, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, AccountExecutives, TypeOfJob, Nothing, Nothing, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                        Case 11 'client Biller

                            BillerEmployeeCodes = DataGridViewProduction_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientBiller)().Where(Function(Entity) Entity.IsSelected = 1).Select(Function(Entity) Entity.BillerEmployeeCode).ToList

                            AdvantageFramework.BillingCommandCenter.UpdateProductionSelection(BCCDbContext, BillingCommandCenter.ID, BillingCommandCenter.BillingUser, 11, Nothing, Nothing, Nothing, SelectionOption,
                                DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue, DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue,
                                ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue, Nothing, Nothing, Nothing, BatchID, Nothing, Nothing, TypeOfJob, Nothing, BillerEmployeeCodes, DateTimePickerProductionJobMedia_DateFrom.GetValue, DateTimePickerProductionJobMedia_DateTo.GetValue)

                    End Select

                    Exit For

                End If

            Next

            BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_bcc_clear_billing_user {0}, '{1}', 1, 0, 0", BillingCommandCenter.ID, BillingCommandCenter.BillingUser))

        End Sub
        Private Sub SetMediaToEligibleOrders()

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                RadioButtonMediaSelectBy_AllEligibleOrders.Checked = True

                DataGridViewMedia_Selections.ClearGridCustomization()

                DataGridViewMedia_Selections.CurrentView.ViewCaption = DataGridViewMedia_Selections.CurrentView.RowCount & " Available Media Selection(s)"

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub LoadBillingCommandCenterEntity(ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter)

            If BillingCommandCenter IsNot Nothing Then

                BillingCommandCenter.ID = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)

                BillingCommandCenter.EmployeeTimeDateCutoff = DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue
                BillingCommandCenter.IncomeOnlyDateCutoff = DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue
                BillingCommandCenter.APPostPeriodCodeCutoff = ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue

                BillingCommandCenter.IsProductionSelectionLocked = CheckBoxCutoff_LockRecords.Checked

                If BillingCommandCenter.EmployeeTimeDateCutoff.HasValue AndAlso BillingCommandCenter.IncomeOnlyDateCutoff.HasValue AndAlso BillingCommandCenter.APPostPeriodCodeCutoff IsNot Nothing Then

                    BillingCommandCenter.IsProduction = True

                End If

                If SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue Then

                    BillingCommandCenter.BillingApprovalBatchID = SearchableComboBoxProduction_BillingApprovalBatch.GetSelectedValue

                Else

                    BillingCommandCenter.BillingApprovalBatchID = Nothing

                End If

                For Each RadioButtonControl In GroupBoxProduction_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        BillingCommandCenter.ProductionSelectBy = CShort(RadioButtonControl.Tag)
                        Exit For

                    End If

                Next

                For Each RadioButtonControl In GroupBoxProduction_TypeOfJob.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        BillingCommandCenter.ProductionJobType = CShort(RadioButtonControl.Tag)
                        Exit For

                    End If

                Next

                For Each RadioButtonControl In GroupBoxProduction_Include.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        BillingCommandCenter.ProductionSelectionOption = CShort(RadioButtonControl.Tag)
                        Exit For

                    End If

                Next

                BillingCommandCenter.ProductionIncludeJobMediaBillDates = CheckBoxProduction_IncludeJobDateToBill.Checked

                BillingCommandCenter.ProductionJobMediaBillDateFrom = DateTimePickerProductionJobMedia_DateFrom.GetValue
                BillingCommandCenter.ProductionJobMediaBillDateTo = DateTimePickerProductionJobMedia_DateTo.GetValue

                If GroupBoxMedia_SelectBy.Enabled Then

                    BillingCommandCenter.IsMedia = True

                    BillingCommandCenter.DateCuttoffToUseFlag = CShort(ComboBoxMedia_SelectBy.GetSelectedValue)

                    For Each RadioButtonControl In GroupBoxMedia_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                        If RadioButtonControl.Checked Then

                            BillingCommandCenter.MediaSelectBy = CShort(RadioButtonControl.Tag)
                            Exit For

                        End If

                    Next

                    BillingCommandCenter.IsNewspaper = CheckBoxMediaType_Newspaper.Checked
                    BillingCommandCenter.IsMagazine = CheckBoxMediaType_Magazine.Checked
                    BillingCommandCenter.IsOutOfHome = CheckBoxMediaType_OutOfHome.Checked
                    BillingCommandCenter.IsInternet = CheckBoxMediaType_Internet.Checked
                    BillingCommandCenter.IsRadioDaily = CheckBoxMediaType_RadioDaily.Checked
                    BillingCommandCenter.IsTelevisionDaily = CheckBoxMediaType_TelevisionDaily.Checked

                    BillingCommandCenter.MediaStartDate = DateTimePickerMediaType_DateFrom.GetValue

                    BillingCommandCenter.MediaEndDate = DateTimePickerMediaType_DateTo.GetValue

                    BillingCommandCenter.IsRadioMonthly = CheckBoxMediaBroadcast_Radio.Checked
                    BillingCommandCenter.IsTelevisionMonthly = CheckBoxMediaBroadcast_Television.Checked

                    If CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                        BillingCommandCenter.MediaBroadcastMonthStart = DateSerial(NumericInputMediaBroadcast_YearFrom.GetValue, ComboBoxMediaBroadcast_MonthFrom.GetSelectedValue, 1)
                        BillingCommandCenter.MediaBroadcastMonthEnd = DateSerial(NumericInputMediaBroadcast_YearTo.GetValue, ComboBoxMediaBroadcast_MonthTo.GetSelectedValue, 1)

                    Else

                        BillingCommandCenter.MediaBroadcastMonthStart = Nothing
                        BillingCommandCenter.MediaBroadcastMonthEnd = Nothing

                    End If

                    BillingCommandCenter.IsRadio = BillingCommandCenter.IsRadioDaily OrElse BillingCommandCenter.IsRadioMonthly
                    BillingCommandCenter.IsTelevision = BillingCommandCenter.IsTelevisionDaily OrElse BillingCommandCenter.IsTelevisionMonthly

                    BillingCommandCenter.IncludeUnbilledOrdersOnly = If(CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked, 1, 0)
                    BillingCommandCenter.IncludeZeroSpots = CheckBoxMedia_IncludeSpots.Checked
                    BillingCommandCenter.IncludeLegacy = False 'CheckBoxMedia_IncludeLegacyBroadcast.Checked

                    BillingCommandCenter.DateCuttoffToUseFlag = CShort(ComboBoxMedia_SelectBy.GetSelectedValue)

                    BillingCommandCenter.JobMediaBillDateFrom = DateTimePickerJobMedia_DateFrom.GetValue
                    BillingCommandCenter.JobMediaBillDateTo = DateTimePickerJobMedia_DateTo.GetValue

                Else

                    BillingCommandCenter.DateCuttoffToUseFlag = 0

                End If

            End If

        End Sub
        Private Sub EnableDisableMediaGroup()

            CheckBoxMedia_IncludeUnbilledOrdersOnly.ByPassUserEntryChanged = True

            If IsMediaTypeChecked() OrElse CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                If GroupBoxMedia_SelectBy.Enabled = False Then

                    CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked = True
                    GroupBoxMedia_SelectBy.Enabled = True

                End If

            Else

                GroupBoxMedia_SelectBy.Enabled = False
                CheckBoxMedia_IncludeUnbilledOrdersOnly.Checked = False

            End If

            CheckBoxMedia_IncludeUnbilledOrdersOnly.ByPassUserEntryChanged = False

        End Sub
        Private Sub ToggleProductionColumnVisibility()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim IsVisible As Boolean = False

            IsVisible = ButtonItemView_ShowDescriptions.Checked

            For Each GridColumn In DataGridViewProduction_Selections.Columns

                If RadioButtonProductionSelectBy_ClientDivision.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision.Properties.ClientName.ToString AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonProductionSelectBy_ClientDivisionProduct.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct.Properties.DivisionName.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonProductionSelectBy_BillingApproval.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval.Properties.ComponentDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval.Properties.BatchDescription.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonProductionSelectBy_SalesClass.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass), GridColumn.FieldName) Then

                        'If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.ComplexTypes.ProductionSelectionBySalesClass.Properties.SalesClassDescription.ToString) AndAlso _
                        '        Not IsVisible Then

                        '    GridColumn.VisibleIndex = -1
                        '    GridColumn.Visible = False

                        'Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                        'End If

                    End If

                ElseIf RadioButtonProductionSelectBy_Campaign.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign.Properties.ProductDescription.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonProductionSelectBy_Job.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.CampaignName.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonProductionSelectBy_JobComponent.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob.Properties.CampaignName.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                End If

            Next

            DataGridViewProduction_Selections.CurrentView.OptionsCustomization.AllowSort = True

            DataGridViewProduction_Selections.CurrentView.BestFitColumns()

        End Sub
        Private Sub ToggleMediaColumnVisibility()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim IsVisible As Boolean = False

            IsVisible = ButtonItemView_ShowDescriptions.Checked

            For Each GridColumn In DataGridViewMedia_Selections.Columns

                If RadioButtonMediaSelectBy_Client.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_ClientDivision.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_ClientDivisionProduct.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_ClientPO.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_Market.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_Campaign.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString) AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MediaFrom.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.OrderDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_OrderNumber.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.LineNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_LineNumber.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientName.ToString AndAlso
                                Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientPO.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.MarketDescription.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                ElseIf RadioButtonMediaSelectBy_ClientBiller.Checked Then

                    If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable), GridColumn.FieldName) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.IsSelected.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.BillerEmployeeCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.ClientBiller.ToString Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    End If

                End If

            Next

            DataGridViewMedia_Selections.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim BillingCommandCenterForm As AdvantageFramework.Billing.Presentation.BillingCommandCenterForm = Nothing

            BillingCommandCenterForm = New AdvantageFramework.Billing.Presentation.BillingCommandCenterForm()

            BillingCommandCenterForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler RadioButtonProductionSelectBy_AllEligibleJobs.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_AccountExecutive.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_BillingApproval.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_Job.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_JobComponent.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_SalesClass.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonProductionSelectBy_ClientBiller.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx

            RemoveHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            RemoveHandler CheckBoxMediaBroadcast_Radio.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaBroadcast_Television.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx

            RemoveHandler RadioButtonMediaSelectBy_AllEligibleOrders.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_ClientPO.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_LineNumber.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_Market.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_OrderNumber.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonMediaSelectBy_ClientBiller.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx

        End Sub
        Private Sub BillingCommandCenterForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            If Me.Enabled AndAlso DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxProduction_BillingApprovalBatch.DataSource = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch)(String.Format("exec advsp_bcc_select_billing_approval_batches {0}", If(CheckBoxProduction_IncludeFinishedBatches.Checked, 1, 0))).ToList

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

                    If BillingCommandCenter IsNot Nothing Then

                        LoadBillingCommandCenter(BillingCommandCenter.ID)

                        _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                        EnableOrDisableActions()

                    Else

                        LoadUserBatches()

                        If Not DataGridViewLeftSection_UserBatches.HasRows Then

                            AddBatch(False)

                        End If

                        EnableOrDisableActions()

                    End If

                End Using

            End If

        End Sub
        Private Sub BillingCommandCenterForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_bcc_in_use {0}, 0, 0", DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)))

                End Using

            End If

        End Sub
        Private Sub BillingCommandCenterForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim BillingCommandCenterAgencySetting As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterAgencySetting = Nothing
            Dim SuperTooltipInfo As DevComponents.DotNetBar.SuperTooltipInfo = Nothing

            SuperTooltipInfo = New DevComponents.DotNetBar.SuperTooltipInfo

            SuperTooltipInfo.BodyText = "Check to limit records to ones that existed at the time of selection/save.  Uncheck to include new records added after selection/save that meet date cutoff criteria.  Saving re-selects all qualifying records."
            SuperTooltip.SetSuperTooltip(CheckBoxCutoff_LockRecords, SuperTooltipInfo)

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            ButtonItemView_ProductionReview.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemView_MediaReview.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemProcessInvoices_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemProcessInvoices_CoopSplits.Image = AdvantageFramework.My.Resources.InvoiceCoopImage
            ButtonItemProcessInvoices_Currency.Image = AdvantageFramework.My.Resources.CurrencyDollarImage
            ButtonItemProcessInvoices_Draft.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage
            ButtonItemProcessInvoices_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Finish.Image = AdvantageFramework.My.Resources.FinishImage
            ButtonItemProcessInvoices_FinishDelete.Image = AdvantageFramework.My.Resources.FinishDeleteImage

            ButtonItemView_MyBatches.Image = AdvantageFramework.My.Resources.EmployeeImage
            ButtonItemView_OtherUserSelections.Image = AdvantageFramework.My.Resources.DepartmentTeamImage
            ButtonItemView_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            AddHandler RadioButtonProductionSelectBy_AllEligibleJobs.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_AccountExecutive.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_BillingApproval.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_Job.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_JobComponent.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_SalesClass.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx
            AddHandler RadioButtonProductionSelectBy_ClientBiller.CheckedChangedEx, AddressOf RadioButtonProductionSelectBy_CheckedChangedEx

            RadioButtonProductionSelectBy_AccountExecutive.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_BillingApproval.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_Campaign.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_Client.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_ClientDivision.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_ClientDivisionProduct.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_Job.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_JobComponent.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_SalesClass.ByPassUserEntryChanged = True
            RadioButtonProductionSelectBy_ClientBiller.ByPassUserEntryChanged = True

            CheckBoxCutoff_LockRecords.ByPassUserEntryChanged = True

            AddHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            AddHandler CheckBoxMediaBroadcast_Radio.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaBroadcast_Television.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx

            AddHandler RadioButtonMediaSelectBy_AllEligibleOrders.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_ClientPO.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_LineNumber.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_Market.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_OrderNumber.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx
            AddHandler RadioButtonMediaSelectBy_ClientBiller.CheckedChangedEx, AddressOf RadioButtonMediaSelectBy_CheckedChangedEx

            RadioButtonMediaSelectBy_Campaign.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_Client.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_ClientDivision.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_ClientDivisionProduct.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_ClientPO.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_LineNumber.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_Market.ByPassUserEntryChanged = True
            RadioButtonMediaSelectBy_OrderNumber.ByPassUserEntryChanged = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            CheckBoxProduction_IncludeFinishedBatches.ByPassUserEntryChanged = True

            DateTimePickerProductionCutoffs_EmployeeTimeDate.DisplayName = "Employee Time Cutoff Date"
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisplayName = "Income Only Cutoff Date "
            ComboBoxProductionCutoffs_APPostingPeriod.DisplayName = "AP Posting Period Cutoff"
            ComboBoxProductionCutoffs_APPostingPeriod.DropDownHeight = ComboBoxProductionCutoffs_APPostingPeriod.ItemHeight * 10

            ComboBoxMediaBroadcast_MonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
            ComboBoxMediaBroadcast_MonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            NumericInputProductionSelectBy_JobNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            NumericInputMediaSelectBy_OrderNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            NumericInputMediaBroadcast_YearFrom.Properties.MinValue = 1980
            NumericInputMediaBroadcast_YearFrom.Properties.MaxValue = 2078
            NumericInputMediaBroadcast_YearFrom.Properties.MaxLength = 4
            NumericInputMediaBroadcast_YearFrom.SetPropertySettings(DisplayName:="Year From")
            NumericInputMediaBroadcast_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            NumericInputMediaBroadcast_YearTo.Properties.MinValue = 1980
            NumericInputMediaBroadcast_YearTo.Properties.MaxValue = 2078
            NumericInputMediaBroadcast_YearTo.Properties.MaxLength = 4
            NumericInputMediaBroadcast_YearTo.SetPropertySettings(DisplayName:="Year To")
            NumericInputMediaBroadcast_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            DataGridViewProduction_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewProduction_Selections.ControlType = WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            DataGridViewProduction_Selections.ByPassUserEntryChanged = True
            DataGridViewProduction_Selections.MultiSelect = False

            DataGridViewMedia_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewMedia_Selections.ControlType = WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            DataGridViewMedia_Selections.ByPassUserEntryChanged = True
            DataGridViewMedia_Selections.MultiSelect = False

            ComboBoxMedia_SelectBy.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.BillingCommandCenter.MediaDateToUse), False)
            ComboBoxMedia_SelectBy.SetRequired(True)

            DateTimePickerProductionJobMedia_DateFrom.ValueObject = Nothing
            DateTimePickerProductionJobMedia_DateTo.ValueObject = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SearchableComboBoxProduction_BillingApprovalBatch.DataSource = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch)(String.Format("exec advsp_bcc_select_billing_approval_batches {0}", 0)).ToList

                BillingCommandCenterAgencySetting = (From Entity In BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterAgencySetting)(String.Format("exec dbo.advsp_get_bcc_agy_settings"))
                                                     Where Entity.Code = "BCC_DEF_WINDOW"
                                                     Select Entity).FirstOrDefault

                If BillingCommandCenterAgencySetting IsNot Nothing AndAlso BillingCommandCenterAgencySetting.Value = "Media Selection" Then

                    TabControlForm_BillingCommandCenter.SelectedTab = TabItemBillingCommandCenter_MediaSelectionTab

                Else

                    TabControlForm_BillingCommandCenter.SelectedTab = TabItemBillingCommandCenter_ProductionSelectionTab

                End If

            End Using

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

            End Using

            ButtonItemProcessInvoices_Currency.Visible = _IsMultiCurrencyEnabled

            Try

                LoadUserBatches()

            Catch ex As Exception

            End Try

            ExpandableSplitterControlForm_LeftRight.Expanded = False

            NumericInputProductionSelectBy_JobNumber.EditValue = Nothing
            NumericInputMediaSelectBy_OrderNumber.EditValue = Nothing
            NumericInputMediaBroadcast_YearFrom.EditValue = Nothing
            NumericInputMediaBroadcast_YearTo.EditValue = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            ClearTabControl()

            CheckBoxMedia_IncludeLegacyBroadcast.Checked = False
            CheckBoxMedia_IncludeLegacyBroadcast.Visible = False

            Me.ClearChanged()

        End Sub
        Private Sub BillingCommandCenterForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If DataGridViewLeftSection_UserBatches.CurrentView.RowCount = 0 Then

                AddBatch(False)

            Else

                LoadSelectedBatch()

                If DataGridViewLeftSection_UserBatches.CurrentView.RowCount > 1 Then

                    ButtonItemView_MyBatches.Checked = True

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub BillingCommandCenterForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            If CheckForUnsavedChanges() Then

                Me.ClearChanged()

                AddBatch(True)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim BillingCommandCenterID As Integer = 0
            Dim BillingUser As String = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim Message As String = Nothing
            Dim ContinueDelete As Boolean = True

            If DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                BillingCommandCenterID = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)

                BillingUser = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(1)

                If BillingUser IsNot Nothing Then

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                            If BillingCommandCenter IsNot Nothing Then

                                If AdvantageFramework.BillingCommandCenter.OkayToDeleteBatch(BCCDbContext, DataContext, BillingCommandCenterID, BillingUser, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(2), Message) Then

                                    If Message IsNot Nothing AndAlso AdvantageFramework.WinForm.MessageBox.Show(Message,
                                                        AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, , Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.No Then

                                        ContinueDelete = False

                                    End If

                                    If ContinueDelete Then

                                        Me.FormAction = WinForm.Presentation.FormActions.Deleting

                                        Me.ShowWaitForm("Deleting...")

                                        AdvantageFramework.BillingCommandCenter.DeleteMediaSelection(Session, BillingCommandCenterID, BillingUser)

                                        AdvantageFramework.BillingCommandCenter.DeleteProductionSelection(Session, BillingCommandCenterID, BillingUser)

                                        If AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Delete(BCCDbContext, BillingCommandCenterID) Then

                                            DataGridViewProduction_Selections.ClearDatasource()

                                            DataGridViewMedia_Selections.ClearDatasource()

                                        Else

                                            AdvantageFramework.WinForm.MessageBox.Show("Failed to delete batch.")

                                        End If

                                        Me.FormAction = WinForm.Presentation.FormActions.None

                                        LoadUserBatches()

                                        If Not DataGridViewLeftSection_UserBatches.HasRows Then

                                            AddBatch(False)

                                        End If

                                        EnableOrDisableActions()

                                        Me.CloseWaitForm()

                                    End If

                                End If

                            End If

                        End Using

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Edit.Click

            Dim BillingCommandCenterID As Integer = 0
            Dim BatchName As String = Nothing

            If DataGridViewLeftSection_UserBatches.HasASelectedRow Then

                BillingCommandCenterID = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)
                BatchName = DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(2)

                If AdvantageFramework.Billing.Presentation.BillingCommandCenterBatchEditDialog.ShowFormDialog(BillingCommandCenterID, BatchName) = Windows.Forms.DialogResult.OK Then

                    DataGridViewLeftSection_UserBatches.CurrentView.SetRowCellValue(DataGridViewLeftSection_UserBatches.CurrentView.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.UserBatch.Properties.BatchName.ToString, BatchName)
                    'DataGridViewLeftSection_UserBatches.CurrentView.RefreshRow(DataGridViewLeftSection_UserBatches.CurrentView.FocusedRowHandle)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If Save() Then

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemMediaTypes_CheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaTypes_CheckAll.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying

            SetMediaCheckboxes(True)

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMediaTypes_UncheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaTypes_UncheckAll.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying

            SetMediaCheckboxes(False)

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessInvoices_Assign_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Assign.Click

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            If AdvantageFramework.Billing.Presentation.OkayToAssignInvoices(Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0), _BillingStatus, BillingCommandCenter) Then

                Me.ShowWaitForm()

                AdvantageFramework.Billing.Presentation.AssignInvoices(Me.Session, BillingCommandCenter, _BillingStatus)

                Me.CloseWaitForm()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessInvoices_CoopSplits_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_CoopSplits.Click

            Dim UserBatch As AdvantageFramework.BillingCommandCenter.Classes.UserBatch = Nothing

            UserBatch = DirectCast(DataGridViewLeftSection_UserBatches.CurrentView.GetRow(DataGridViewLeftSection_UserBatches.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.UserBatch)

            AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionCoopDialog.ShowDialog(UserBatch.BillingUser, UserBatch.ID)

        End Sub
        Private Sub ButtonItemProcessInvoices_Currency_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Currency.Click

            Dim UserBatch As AdvantageFramework.BillingCommandCenter.Classes.UserBatch = Nothing

            UserBatch = DirectCast(DataGridViewLeftSection_UserBatches.CurrentView.GetRow(DataGridViewLeftSection_UserBatches.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.UserBatch)

            AdvantageFramework.Billing.Presentation.BillingCommandCenterCurrencyDialog.ShowDialog(UserBatch.BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Draft_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Draft.Click

            AdvantageFramework.Billing.Presentation.DraftInvoices(Me, Me.Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(1))

        End Sub
        Private Sub ButtonItemProcessInvoices_Finish_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Finish.Click

            If AdvantageFramework.Billing.Presentation.FinishBatch(Me.Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)) Then

                LoadUserBatches()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_FinishDelete_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_FinishDelete.Click

            If AdvantageFramework.Billing.Presentation.FinishDeleteBatch(Me.Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)) Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

                LoadUserBatches()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                DataGridViewLeftSection_UserBatches.GridViewSelectionChanged()

                If Not DataGridViewLeftSection_UserBatches.HasRows Then

                    AddBatch(False)

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Print.Click

            AdvantageFramework.Billing.Presentation.PrintInvoices(Me, Me.Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(1))

        End Sub
        Private Sub ButtonItemProcessInvoices_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Process.Click

            AdvantageFramework.Billing.Presentation.ProcessInvoices(Me.Session, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0), _BillingStatus, False)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemView_MediaReview_Click(sender As Object, e As EventArgs) Handles ButtonItemView_MediaReview.Click

            If Me.Validator Then

                AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaReviewDialog.ShowForm(Me, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

            End If

        End Sub
        Private Sub ButtonItemView_MyBatches_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_MyBatches.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_MyBatches.Checked Then

                ExpandableSplitterControlForm_LeftRight.Expanded = True

            Else

                ExpandableSplitterControlForm_LeftRight.Expanded = False

            End If

        End Sub
        Private Sub ButtonItemView_OtherUserSelections_Click(sender As Object, e As EventArgs) Handles ButtonItemView_OtherUserSelections.Click

            'objects
            Dim OtherUsersProductionSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersProductionSelection) = Nothing
            Dim OtherUsersMediaSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersMediaSelection) = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                OtherUsersProductionSelections = AdvantageFramework.BillingCommandCenter.GetOtherUsersProductionSelection(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)).ToList

                OtherUsersMediaSelections = AdvantageFramework.BillingCommandCenter.GetOtherUsersMediaSelection(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)).ToList

            End Using

            If OtherUsersProductionSelections.Count = 0 AndAlso OtherUsersMediaSelections.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("There are no selections for other users.")

            Else

                AdvantageFramework.Billing.Presentation.BillingCommandCenterOtherUsersSelectionsDialog.ShowFormDialog(OtherUsersProductionSelections, OtherUsersMediaSelections, (Me.TabControlForm_BillingCommandCenter.SelectedTab Is TabItemBillingCommandCenter_MediaSelectionTab),
                                                                                                                      DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

            End If

        End Sub
        Private Sub ButtonItemView_ProductionReview_Click(sender As Object, e As EventArgs) Handles ButtonItemView_ProductionReview.Click

            'objects
            Dim JobCount As Integer = 0

            If Me.Validator Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobCount = AdvantageFramework.BillingCommandCenter.GetProductionJob(BCCDbContext, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)).Count

                End Using

                If JobCount = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("No items met your criteria.  Please try again.")

                Else

                    AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionReviewDialog.ShowForm(Me, DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

                End If

            End If

        End Sub
        Private Sub ButtonItemView_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowDescriptions.CheckedChanged

            If TabItemBillingCommandCenter_ProductionSelectionTab.IsSelected Then

                ToggleProductionColumnVisibility()

            ElseIf TabItemBillingCommandCenter_MediaSelectionTab.IsSelected Then

                ToggleMediaColumnVisibility()

            End If

        End Sub
        Private Sub CheckBoxCutoff_LockRecords_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxCutoff_LockRecords.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso Not ButtonItemActions_Save.Enabled Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING_CMD_CENTER SET PROD_LOCK_SELECTION = {0} WHERE BCC_ID = {1}", If(e.NewChecked.Checked, 1, 0), DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0)))

                End Using

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxMediaType_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormAction <> WinForm.Presentation.FormActions.Loading Then

                SetMediaToEligibleOrders()

                EnableDisableMediaGroup()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxMediaBroadcast_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormAction <> WinForm.Presentation.FormActions.Loading Then

                SetMediaToEligibleOrders()

                If Not (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked) Then

                    Me.ClearValidations()

                End If

                If CheckBoxMediaType_RadioDaily.Checked = False AndAlso CheckBoxMediaType_TelevisionDaily.Checked = False AndAlso
                        CheckBoxMediaBroadcast_Radio.Checked = False AndAlso CheckBoxMediaBroadcast_Television.Checked = False Then

                    CheckBoxMedia_IncludeSpots.Checked = False

                End If

                'If CheckBoxMediaBroadcast_Radio.Checked = False AndAlso CheckBoxMediaBroadcast_Television.Checked = False Then

                '    CheckBoxMedia_IncludeLegacyBroadcast.Checked = False

                'End If

                EnableDisableMediaGroup()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxProduction_IncludeFinishedBatches_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxProduction_IncludeFinishedBatches.CheckedChangedEx

            SearchableComboBoxProduction_BillingApprovalBatch.SelectedValue = Nothing
            SearchableComboBoxProduction_BillingApprovalBatch.DataSource = Nothing

            If RadioButtonProductionSelectBy_BillingApproval.Checked Then

                LoadProductionSelection()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_UserBatches_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_UserBatches.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_UserBatches_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_UserBatches.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedBatch()

            End If

        End Sub
        Private Sub DataGridViewMedia_Selections_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewMedia_Selections.CellValueChangingEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                DataGridViewMedia_Selections.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewMedia_Selections_DeselectAllEvent() Handles DataGridViewMedia_Selections.DeselectAllEvent

            For Each MediaSelectionAvailable In DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable).ToList

                MediaSelectionAvailable.IsSelected = False

            Next

            DataGridViewMedia_Selections.CurrentView.RefreshData()
            DataGridViewMedia_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewMedia_Selections_SelectAllEvent() Handles DataGridViewMedia_Selections.SelectAllEvent

            For Each MediaSelectionAvailable In DataGridViewMedia_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable).ToList

                MediaSelectionAvailable.IsSelected = True

            Next

            DataGridViewMedia_Selections.CurrentView.RefreshData()
            DataGridViewMedia_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewMedia_Selections_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewMedia_Selections.ShowingEditorEvent

            If DataGridViewMedia_Selections.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable.Properties.IsSelected.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewProduction_Selections_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewProduction_Selections.CellValueChangingEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                DataGridViewProduction_Selections.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewProduction_Selections_DeselectAllEvent() Handles DataGridViewProduction_Selections.DeselectAllEvent

            For Each ProductionSelectionItem In DataGridViewProduction_Selections.GetAllRowsDataBoundItems()

                ProductionSelectionItem.IsSelected = 0

            Next

            DataGridViewProduction_Selections.CurrentView.RefreshData()
            DataGridViewProduction_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewProduction_Selections_SelectAllEvent() Handles DataGridViewProduction_Selections.SelectAllEvent

            For Each ProductionSelectionItem In DataGridViewProduction_Selections.GetAllRowsDataBoundItems()

                ProductionSelectionItem.IsSelected = 1

            Next

            DataGridViewProduction_Selections.CurrentView.RefreshData()
            DataGridViewProduction_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewProduction_Selections_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewProduction_Selections.ShowingEditorEvent

            If DataGridViewProduction_Selections.CurrentView.FocusedColumn.FieldName <> "IsSelected" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerMediaType_DateTo_Leave(sender As Object, e As EventArgs) Handles DateTimePickerMediaType_DateTo.Leave

            If DateTimePickerMediaType_DateTo.ValueObject Is Nothing Then

                DateTimePickerMediaType_DateTo.Value = Now.ToShortDateString

            End If

        End Sub
        Private Sub DateTimePickerProductionCutoffs_EmployeeTimeDate_Leave(sender As Object, e As EventArgs) Handles DateTimePickerProductionCutoffs_EmployeeTimeDate.Leave

            If DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject Is Nothing Then

                DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = Now.ToShortDateString

            End If

        End Sub
        Private Sub DateTimePickerProductionCutoffs_IncomeOnlyTimeDate_Leave(sender As Object, e As EventArgs) Handles DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Leave

            If DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject Is Nothing Then

                DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = Now.ToShortDateString

            End If

        End Sub
        Private Sub NumericInputMediaBroadcast_YearFrom_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputMediaBroadcast_YearFrom.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                e.NewValue = Nothing
                e.Cancel = True

            End If

        End Sub
        Private Sub NumericInputMediaBroadcast_YearTo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputMediaBroadcast_YearTo.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                e.NewValue = Nothing
                e.Cancel = True

            End If

        End Sub
        Private Sub NumericInputMediaSelectBy_OrderNumber_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputMediaSelectBy_OrderNumber.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                System.Windows.Forms.SendKeys.Send("^{DELETE}")

            End If

        End Sub
        Private Sub NumericInputMediaSelectBy_OrderNumber_Leave(sender As Object, e As EventArgs) Handles NumericInputMediaSelectBy_OrderNumber.Leave

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim MediaSelectionAvailable As AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable = Nothing
            Dim OrderNumberFound As Boolean = False

            If NumericInputMediaSelectBy_OrderNumber.EditValue IsNot Nothing Then

                If RadioButtonMediaSelectBy_OrderNumber.Checked OrElse RadioButtonMediaSelectBy_LineNumber.Checked Then

                    OrderNumber = NumericInputMediaSelectBy_OrderNumber.EditValue

                    For Each RowHandlesAndDataBoundItem In DataGridViewMedia_Selections.GetAllRowsRowHandlesAndDataBoundItems

                        Try

                            MediaSelectionAvailable = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            MediaSelectionAvailable = Nothing
                        End Try

                        If MediaSelectionAvailable IsNot Nothing AndAlso MediaSelectionAvailable.OrderNumber = OrderNumber Then

                            MediaSelectionAvailable.IsSelected = 1
                            DataGridViewMedia_Selections.CurrentView.MakeRowVisible(RowHandlesAndDataBoundItem.Key)
                            OrderNumberFound = True

                        End If

                    Next

                    DataGridViewMedia_Selections.CurrentView.RefreshData()

                End If

                NumericInputMediaSelectBy_OrderNumber.EditValue = Nothing
                NumericInputMediaSelectBy_OrderNumber.Focus()

                If Not OrderNumberFound Then

                    AdvantageFramework.WinForm.MessageBox.Show("Order number '" & OrderNumber & "' is either locked or otherwise unavailable.")

                End If

            End If

        End Sub
        Private Sub NumericInputProductionSelectBy_JobNumber_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputProductionSelectBy_JobNumber.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                System.Windows.Forms.SendKeys.Send("^{DELETE}")

            End If

        End Sub
        Private Sub NumericInputProductionSelectBy_JobNumber_Leave(sender As Object, e As EventArgs) Handles NumericInputProductionSelectBy_JobNumber.Leave

            'objects
            Dim JobNumber As Integer = Nothing
            Dim ProductionSelectionByJob As AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob = Nothing
            Dim ProductionSelectionByJobComponent As AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent = Nothing
            Dim JobNumberFound As Boolean = False

            If NumericInputProductionSelectBy_JobNumber.EditValue IsNot Nothing AndAlso (RadioButtonProductionSelectBy_Job.Checked OrElse RadioButtonProductionSelectBy_JobComponent.Checked) Then

                JobNumber = NumericInputProductionSelectBy_JobNumber.EditValue

                If RadioButtonProductionSelectBy_Job.Checked Then

                    For Each RowHandlesAndDataBoundItem In DataGridViewProduction_Selections.GetAllRowsRowHandlesAndDataBoundItems

                        Try

                            ProductionSelectionByJob = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            ProductionSelectionByJob = Nothing
                        End Try

                        If ProductionSelectionByJob IsNot Nothing AndAlso ProductionSelectionByJob.JobNumber = JobNumber Then

                            ProductionSelectionByJob.IsSelected = 1
                            DataGridViewProduction_Selections.CurrentView.MakeRowVisible(RowHandlesAndDataBoundItem.Key)
                            JobNumberFound = True

                        End If

                    Next

                ElseIf RadioButtonProductionSelectBy_JobComponent.Checked Then

                    For Each RowHandlesAndDataBoundItem In DataGridViewProduction_Selections.GetAllRowsRowHandlesAndDataBoundItems

                        Try

                            ProductionSelectionByJobComponent = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            ProductionSelectionByJobComponent = Nothing
                        End Try

                        If ProductionSelectionByJobComponent IsNot Nothing AndAlso ProductionSelectionByJobComponent.JobNumber = JobNumber Then

                            ProductionSelectionByJobComponent.IsSelected = 1
                            DataGridViewProduction_Selections.CurrentView.MakeRowVisible(RowHandlesAndDataBoundItem.Key)
                            JobNumberFound = True

                        End If

                    Next

                End If

                DataGridViewProduction_Selections.CurrentView.RefreshData()

                NumericInputProductionSelectBy_JobNumber.EditValue = Nothing
                NumericInputProductionSelectBy_JobNumber.Focus()

                If Not JobNumberFound Then

                    AdvantageFramework.WinForm.MessageBox.Show("Job number '" & JobNumber & "' is either locked or otherwise unavailable.")

                End If

            End If

        End Sub
        Private Sub RadioButtonMediaSelectBy_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                LoadMediaSelection()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonProductionSelectBy_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso e.NewChecked.Checked Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                LoadProductionSelection()

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxProduction_BillingApprovalBatch_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxProduction_BillingApprovalBatch.EditValueChanged

            'objects
            Dim BillingApprovalBatch As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingApprovalBatch = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If SearchableComboBoxProduction_BillingApprovalBatch.HasASelectedValue Then

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingApprovalBatch = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingApprovalBatch.LoadByID(BCCDbContext, SearchableComboBoxProduction_BillingApprovalBatch.GetSelectedValue)

                        If BillingApprovalBatch IsNot Nothing Then

                            ComboBoxProductionCutoffs_APPostingPeriod.RemoveAddedItemsFromDataSource()

                            DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = BillingApprovalBatch.DateCutoff
                            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = BillingApprovalBatch.DateCutoff
                            ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = BillingApprovalBatch.CutoffPostPeriodCode

                            If ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue Is Nothing AndAlso BillingApprovalBatch.CutoffPostPeriodCode IsNot Nothing Then

                                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, BillingApprovalBatch.CutoffPostPeriodCode)

                                End Using

                                If PostPeriod IsNot Nothing Then

                                    ComboBoxProductionCutoffs_APPostingPeriod.AddComboItemToExistingDataSource(PostPeriod.ToString, PostPeriod.Code, True)

                                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = BillingApprovalBatch.CutoffPostPeriodCode

                                End If

                            End If

                            Select Case BillingApprovalBatch.SelectionOption

                                Case 0

                                    RadioButtonProductionInclude_OpenJobs.Checked = True

                                Case 1

                                    RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Checked = True

                                Case 2

                                    RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Checked = True

                            End Select

                            RadioButtonProductionSelectBy_AllEligibleJobs.Checked = True

                            Me.Validator()

                        End If

                    End Using

                End If

                LoadProductionSelection()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxProduction_BillingApprovalBatch_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProduction_BillingApprovalBatch.QueryPopupNeedDataSource

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SearchableComboBoxProduction_BillingApprovalBatch.DataSource = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch)(String.Format("exec advsp_bcc_select_billing_approval_batches {0}", If(CheckBoxProduction_IncludeFinishedBatches.Checked, 1, 0))).ToList

            End Using

        End Sub
        Private Sub TabControlForm_BillingCommandCenter_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_BillingCommandCenter.SelectedTabChanged

            RibbonBarMergeContainerForm_Options.SuspendLayout()

            RibbonBarOptions_MediaTypes.Visible = (e.NewTab Is TabItemBillingCommandCenter_MediaSelectionTab)

            RibbonBarMergeContainerForm_Options.ResumeLayout()

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_BillingCommandCenter_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_BillingCommandCenter.SelectedTabChanging

            If Me.FormShown AndAlso e.OldTab IsNot Nothing Then

                If e.OldTab Is TabItemBillingCommandCenter_MediaSelectionTab AndAlso AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelMediaSelection_Details) OrElse
                   e.OldTab Is TabItemBillingCommandCenter_ProductionSelectionTab AndAlso AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelProductionSelection_Details) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        e.Cancel = Not Save()

                    ElseIf DataGridViewLeftSection_UserBatches.HasOnlyOneSelectedRow Then

                        LoadBillingCommandCenter(DataGridViewLeftSection_UserBatches.GetFirstSelectedRowBookmarkValue(0))

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxMedia_SelectBy_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMedia_SelectBy.SelectedValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub ComboBoxMediaBroadcast_MonthFrom_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaBroadcast_MonthFrom.SelectedValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub ComboBoxMediaBroadcast_MonthTo_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaBroadcast_MonthTo.SelectedValueChanged

            SetMediaToEligibleOrders()

        End Sub

        Private Sub NumericInputMediaBroadcast_YearFrom_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputMediaBroadcast_YearFrom.ValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub NumericInputMediaBroadcast_YearTo_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputMediaBroadcast_YearTo.ValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub DateTimePickerMediaType_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerMediaType_DateFrom.ValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub DateTimePickerMediaType_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerMediaType_DateTo.ValueChanged

            SetMediaToEligibleOrders()

        End Sub
        Private Sub CheckBoxMedia_IncludeSpots_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxMedia_IncludeSpots.CheckedChangedEx

            SetMediaToEligibleOrders()

        End Sub
        Private Sub CheckBoxMedia_IncludeUnbilledOrdersOnly_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxMedia_IncludeUnbilledOrdersOnly.CheckedChangedEx

            SetMediaToEligibleOrders()

        End Sub
        Private Sub DateTimePickerJobMedia_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJobMedia_DateFrom.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso DateTimePickerJobMedia_DateFrom.ValueObject IsNot Nothing Then

                If DateTimePickerJobMedia_DateFrom.ValueObject IsNot Nothing AndAlso (DateTimePickerJobMedia_DateTo.ValueObject Is Nothing OrElse DateTimePickerJobMedia_DateFrom.GetValue > DateTimePickerJobMedia_DateTo.GetValue) Then

                    DateTimePickerJobMedia_DateTo.Value = DateAdd(DateInterval.Day, 6, DateTimePickerJobMedia_DateFrom.Value)

                End If

            End If

            SetMediaToEligibleOrders()

        End Sub
        Private Sub DateTimePickerJobMedia_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJobMedia_DateTo.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso DateTimePickerJobMedia_DateTo.ValueObject IsNot Nothing Then

                If DateTimePickerJobMedia_DateTo.ValueObject IsNot Nothing AndAlso (DateTimePickerJobMedia_DateFrom.ValueObject Is Nothing OrElse DateTimePickerJobMedia_DateTo.GetValue < DateTimePickerJobMedia_DateFrom.GetValue) Then

                    DateTimePickerJobMedia_DateFrom.Value = DateAdd(DateInterval.Day, -6, DateTimePickerJobMedia_DateTo.Value)

                End If

            End If

            SetMediaToEligibleOrders()

        End Sub
        Private Sub CheckBoxProduction_IncludeJobDateToBill_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxProduction_IncludeJobDateToBill.CheckedChangedEx

            If e.NewChecked.Checked = False Then

                DateTimePickerProductionJobMedia_DateFrom.ValueObject = Nothing
                DateTimePickerProductionJobMedia_DateTo.ValueObject = Nothing

            End If

            RadioButtonProductionSelectBy_AllEligibleJobs.Checked = True

            EnableOrDisableActions()

        End Sub
        Private Sub DateTimePickerProductionJobMedia_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerProductionJobMedia_DateFrom.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerProductionJobMedia_DateFrom.ValueObject IsNot Nothing AndAlso (DateTimePickerProductionJobMedia_DateTo.ValueObject Is Nothing OrElse DateTimePickerProductionJobMedia_DateFrom.GetValue > DateTimePickerProductionJobMedia_DateTo.GetValue) Then

                    DateTimePickerProductionJobMedia_DateTo.Value = DateAdd(DateInterval.Day, 6, DateTimePickerProductionJobMedia_DateFrom.Value)

                End If

                RadioButtonProductionSelectBy_AllEligibleJobs.Checked = True

            End If

        End Sub
        Private Sub DateTimePickerProductionJobMedia_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerProductionJobMedia_DateTo.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerProductionJobMedia_DateTo.ValueObject IsNot Nothing AndAlso (DateTimePickerProductionJobMedia_DateFrom.ValueObject Is Nothing OrElse DateTimePickerProductionJobMedia_DateTo.GetValue < DateTimePickerProductionJobMedia_DateFrom.GetValue) Then

                    DateTimePickerProductionJobMedia_DateFrom.Value = DateAdd(DateInterval.Day, -6, DateTimePickerProductionJobMedia_DateTo.Value)

                End If

                RadioButtonProductionSelectBy_AllEligibleJobs.Checked = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
