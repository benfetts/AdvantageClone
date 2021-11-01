Namespace Billing.Presentation

    Public Class AdjustTimeSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _SearchingByEmployee As Boolean = False
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ShowTaskCode As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim ClientCode As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Short? = Nothing
            Dim DateFrom As Date? = Nothing
            Dim DateTo As Date? = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DateFrom = DateTimePickerDates_From.ValueObject
                DateTo = DateTimePickerDates_To.ValueObject

                If ButtonItemSearchFilter_ByEmployee.Checked = True Then

                    EmployeeCode = CStr(SearchableComboBoxSearch_ClientOrEmployee.GetSelectedValue)

                Else

                    ClientCode = CStr(SearchableComboBoxSearch_ClientOrEmployee.GetSelectedValue)
                    JobNumber = SearchableComboBoxSearch_Job.GetSelectedValue
                    JobComponentNumber = SearchableComboBoxSearch_JobComp.GetSelectedValue

                End If

                Try

                    DataGridViewMain_TimeRecords.DataSource = (From Entity In AdvantageFramework.Database.Procedures.NonbilledEmployeeTimeComplexType.Load(DbContext, Session.UserCode, EmployeeCode, JobNumber, JobComponentNumber, DateFrom, DateTo, ButtonItemSearchFilter_ByJob.Checked, ClientCode, CheckBoxItemSearch_IncludeBilledTime.Checked)
                                                               Select New AdvantageFramework.Database.Classes.NonbilledEmployeeTime(Entity)).ToList

                Catch ex As Exception
                    DataGridViewMain_TimeRecords.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime)
                End Try

            End Using

            RefreshColumnOrderAndVisibility()

            DataGridViewMain_TimeRecords.CurrentView.BestFitColumns()

            If DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString) IsNot Nothing Then

                DataGridViewMain_TimeRecords.CurrentView.FocusedColumn = DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString)

            End If

        End Sub
        Private Sub SetupSearch()

            Try

                SearchableComboBoxSearch_ClientOrEmployee.SelectedValue = Nothing
                SearchableComboBoxSearch_Job.SelectedValue = Nothing
                SearchableComboBoxSearch_JobComp.SelectedValue = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If ButtonItemSearchFilter_ByEmployee.Checked Then

                            SearchableComboBoxSearch_ClientOrEmployee.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
                            LabelItemMain_ClientOrEmployee.Text = "Employee:"
                            ControlContainerItemMain_Job.Visible = False
                            LabelItemMain_Job.Visible = False
                            ControlContainerItemMain_JobComp.Visible = False
                            LabelItemMain_JobComp.Visible = False
                            CheckBoxItemSearch_IncludeBilledTime.Visible = True

                            SearchableComboBoxSearch_ClientOrEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                        ElseIf ButtonItemSearchFilter_ByJob.Checked Then

                            SearchableComboBoxSearch_ClientOrEmployee.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Client
                            SearchableComboBoxSearch_Job.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Job
                            SearchableComboBoxSearch_JobComp.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
                            LabelItemMain_ClientOrEmployee.Text = "Client:"
                            ControlContainerItemMain_Job.Visible = True
                            LabelItemMain_Job.Visible = True
                            ControlContainerItemMain_JobComp.Visible = True
                            LabelItemMain_JobComp.Visible = True
                            CheckBoxItemSearch_IncludeBilledTime.Visible = True

                            SearchableComboBoxSearch_JobComp.Enabled = False

                            SearchableComboBoxSearch_ClientOrEmployee.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                            SearchableComboBoxSearch_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)

                        End If

                    End Using

                End Using

            Catch ex As Exception

            End Try

            RibbonBarOptions_Search.Refresh()

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim NonbilledJobTimeRecordSelected As Boolean = False
            Dim NonbilledEmployeeTimes As Generic.List(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime) = Nothing

            If DataGridViewMain_TimeRecords.HasASelectedRow Then

                NonbilledEmployeeTimes = DataGridViewMain_TimeRecords.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime).ToList

                Try

                    NonbilledJobTimeRecordSelected = (From Entity In NonbilledEmployeeTimes
                                                      Where Entity.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.EmployeeTimeFlags.Unbilled
                                                      Select Entity).Any

                Catch ex As Exception
                    NonbilledJobTimeRecordSelected = False
                End Try

            End If

            ButtonItemActions_Export.Enabled = DataGridViewMain_TimeRecords.HasRows
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_FeeTime.Enabled = NonbilledJobTimeRecordSelected
            ButtonItemActions_MarkBillable.Enabled = NonbilledJobTimeRecordSelected
            ButtonItemActions_MarkNonBillable.Enabled = NonbilledJobTimeRecordSelected
            ButtonItemActions_UpdateRate.Enabled = NonbilledJobTimeRecordSelected
            ButtonItemActions_DeptTeam.Enabled = _SearchingByEmployee AndAlso DataGridViewMain_TimeRecords.HasASelectedRow
            ButtonItemActions_EmployeeTitle.Enabled = _SearchingByEmployee AndAlso DataGridViewMain_TimeRecords.HasASelectedRow AndAlso NonbilledJobTimeRecordSelected

        End Sub
        Private Function ModifyFeeTime(ByVal NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime, ByVal FeeTime As AdvantageFramework.Database.Entities.FeeTimes) As Boolean

            'objects
            Dim Modified As Boolean = False

            If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                If NonbilledEmployeeTime.FeeTimeFlag <> FeeTime Then

                    NonbilledEmployeeTime.FeeTimeFlag = FeeTime

                    Modified = True

                End If

                If FeeTime <> Database.Entities.FeeTimes.No Then

                    NonbilledEmployeeTime.EmployeeNonBillableFlag = CShort(1)

                    Modified = True

                End If

            End If

            ModifyFeeTime = Modified

        End Function
        Private Function ModifyBillable(ByVal NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime, ByVal NonBillable As Boolean) As Boolean

            'objects
            Dim Modified As Boolean = False

            If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                If NonBillable Then

                    If NonbilledEmployeeTime.EmployeeNonBillableFlag <> CShort(1) Then

                        NonbilledEmployeeTime.EmployeeNonBillableFlag = CShort(1)
                        Modified = True

                    End If

                Else

                    If NonbilledEmployeeTime.EmployeeNonBillableFlag <> CShort(0) Then

                        NonbilledEmployeeTime.EmployeeNonBillableFlag = CShort(0)
                        Modified = True

                    End If

                    If NonbilledEmployeeTime.FeeTimeFlag <> AdvantageFramework.Database.Entities.FeeTimes.No Then

                        NonbilledEmployeeTime.FeeTimeFlag = AdvantageFramework.Database.Entities.FeeTimes.No
                        Modified = True

                    End If

                End If

            End If

            ModifyBillable = Modified

        End Function
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim Message As String = ""

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save(Message)

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox(Message, WinForm.MessageBox.MessageBoxButtons.OK)

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save(ByRef ResultMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim NonbilledEmployeeTimes As Generic.List(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime) = Nothing

            DataGridViewMain_TimeRecords.CurrentView.CloseEditorForUpdating()

            Try

                NonbilledEmployeeTimes = DataGridViewMain_TimeRecords.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime)().ToList

            Catch ex As Exception
                NonbilledEmployeeTimes = Nothing
            End Try

            If NonbilledEmployeeTimes IsNot Nothing AndAlso NonbilledEmployeeTimes.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        For Each NonbilledEmployeeTime In NonbilledEmployeeTimes

                            If AdvantageFramework.Database.Procedures.NonbilledEmployeeTimeComplexType.Update(DbContext, NonbilledEmployeeTime) = False Then

                                Saved = False

                            End If

                        Next

                        DbContext.SaveChanges()

                        If Saved Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception
                        Saved = False
                    End Try

                    DbContext.Database.Connection.Close()

                End Using

                If Saved Then

                    ResultMessage = "Updated Successfully!"

                Else

                    ResultMessage = "One or more records failed to update!"

                End If

            End If

            Save = Saved

        End Function
        Private Function CalculateResale(ByVal ExtendedAmount As Decimal, ByVal MarkupAmount As Decimal, ByVal TaxPercent As Decimal) As Decimal

            'objects
            Dim ResaleAmount As Decimal = Nothing

            Try

                ResaleAmount = Math.Round((ExtendedAmount + MarkupAmount) * (TaxPercent / 100), 2, MidpointRounding.AwayFromZero)

            Catch ex As Exception
                ResaleAmount = 0
            Finally
                CalculateResale = ResaleAmount
            End Try

        End Function
        Private Sub RefreshColumnOrderAndVisibility()

            'objects
            Dim ColumnVisibleIndex As Integer = Nothing

            ColumnVisibleIndex = 1

            DataGridViewMain_TimeRecords.CurrentView.BeginUpdate()

            For Each GridColumn In DataGridViewMain_TimeRecords.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTimeFlag.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeDate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTitleID.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ClientCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ClientName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DivisionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DivisionName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ProductCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ProductDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobComponentNumber.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobComponentDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FunctionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FunctionDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.Assignment.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TaskCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeHours.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TotalBill.ToString, ColumnVisibleIndex)

            DataGridViewMain_TimeRecords.CurrentView.EndUpdate()

            DataGridViewMain_TimeRecords.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer)

            'objects
            Dim Visible As Boolean = False
            Dim ShowMarkupTaxFlagsBreakDownColumns As Boolean = Nothing

            If DataGridViewMain_TimeRecords.CurrentView.Columns(FieldName) IsNot Nothing Then

                Select Case FieldName

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamDescription.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ClientName.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DivisionName.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ProductDescription.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobDescription.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobComponentDescription.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FunctionDescription.ToString

                        Visible = ButtonItemActions_ShowDescriptions.Checked

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTimeFlag.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeName.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeDate.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ClientCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DivisionCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.ProductCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobNumber.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.JobComponentNumber.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FunctionCode.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeHours.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TotalBill.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTitleID.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.Assignment.ToString

                        Visible = True

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TaskCode.ToString

                        Visible = _ShowTaskCode

                    Case Else

                        Visible = False

                End Select

                DataGridViewMain_TimeRecords.CurrentView.Columns(FieldName).Visible = Visible

                If DataGridViewMain_TimeRecords.CurrentView.Columns(FieldName).Visible Then

                    DataGridViewMain_TimeRecords.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdjustTimeSetupForm As AdvantageFramework.Billing.Presentation.AdjustTimeSetupForm = Nothing

            AdjustTimeSetupForm = New AdvantageFramework.Billing.Presentation.AdjustTimeSetupForm()

            AdjustTimeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdjustTimeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewMain_TimeRecords.ItemDescription = "Employee Time Record(s)"

            DataGridViewMain_TimeRecords.ShowSelectDeselectAllButtons = True
            DataGridViewMain_TimeRecords.SetBookmarkColumnIndex(-1)
            DataGridViewMain_TimeRecords.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime))

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TS_TASK_ONLY.ToString)

                If Setting IsNot Nothing Then

                    _ShowTaskCode = CBool(Setting.Value)

                End If

            End Using

            RefreshColumnOrderAndVisibility()

            SearchableComboBoxSearch_Job.ByPassUserEntryChanged = True
            SearchableComboBoxSearch_ClientOrEmployee.ByPassUserEntryChanged = True

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_FeeTime.Image = AdvantageFramework.My.Resources.MaintenanceImage
            ButtonItemActions_MarkNonBillable.Image = AdvantageFramework.My.Resources.NonBillableImage
            ButtonItemActions_MarkBillable.Image = AdvantageFramework.My.Resources.BillableImage
            ButtonItemActions_UpdateRate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemActions_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage
            ButtonItemActions_DeptTeam.Image = AdvantageFramework.My.Resources.DepartmentTeamImage
            ButtonItemDeptTeam_FromList.Icon = AdvantageFramework.My.Resources.DepartmentTeamListIcon
            ButtonItemDeptTeam_FromHRHistory.Icon = AdvantageFramework.My.Resources.EmployeeInfoIcon
            ButtonItemActions_EmployeeTitle.Image = AdvantageFramework.My.Resources.EmployeeTitleImage
            ButtonItemEmployeeTitle_FromList.Icon = AdvantageFramework.My.Resources.EmployeeTitleIcon
            ButtonItemEmployeeTitle_FromHRHistory.Icon = AdvantageFramework.My.Resources.EmployeeInfoIcon

            ButtonItemActions_FeeTime.ImageFixedSize = New System.Drawing.Size(32, 32)

            ButtonItemSearchFilter_ByJob.Icon = AdvantageFramework.My.Resources.JobJacketIcon
            ButtonItemSearchFilter_ByEmployee.Icon = AdvantageFramework.My.Resources.EmployeeIcon

            ButtonItemActions_ShowDescriptions.Checked = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInAdjustTime)

            ButtonItemActions_Export.SecurityEnabled = AdvantageFramework.Security.CanUserPrintInModule(Me.Session, Security.Modules.Billing_AdjustTime)

            SearchableComboBoxSearch_ClientOrEmployee.BringToFront()
            SearchableComboBoxSearch_Job.BringToFront()
            DateTimePickerDates_From.BringToFront()
            DateTimePickerDates_To.BringToFront()

            DateTimePickerDates_To.ByPassUserEntryChanged = True
            DateTimePickerDates_From.ByPassUserEntryChanged = True

            DateTimePickerDates_From.ValueObject = System.DateTime.Today.AddDays(-89) '90 days back including today
            DateTimePickerDates_To.ValueObject = System.DateTime.Today

            DataGridViewMain_TimeRecords.MultiSelect = True
            DataGridViewMain_TimeRecords.OptionsPrint.AutoWidth = False

            _RepositoryItemCheckEdit_Blank = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            _RepositoryItemCheckEdit_Blank.DisplayValueChecked = " "
            _RepositoryItemCheckEdit_Blank.DisplayValueUnchecked = " "
            _RepositoryItemCheckEdit_Blank.DisplayValueGrayed = " "
            _RepositoryItemCheckEdit_Blank.ExportMode = Nothing
            _RepositoryItemCheckEdit_Blank.PictureChecked = Nothing
            _RepositoryItemCheckEdit_Blank.PictureGrayed = Nothing
            _RepositoryItemCheckEdit_Blank.PictureUnchecked = Nothing
            _RepositoryItemCheckEdit_Blank.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
            _RepositoryItemCheckEdit_Blank.ValueUnchecked = CShort(0)
            _RepositoryItemCheckEdit_Blank.ValueChecked = CShort(1)
            _RepositoryItemCheckEdit_Blank.ValueGrayed = Nothing
            _RepositoryItemCheckEdit_Blank.ReadOnly = True
            _RepositoryItemCheckEdit_Blank.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewMain_TimeRecords.GridControl.ToolTipController = _ToolTipController

            SetupSearch()
            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub AdjustTimeSetupForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSearch_Search_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            'objects
            If DateTimePickerDates_From.ValueObject IsNot Nothing AndAlso DateTimePickerDates_To.ValueObject IsNot Nothing Then

                If CheckForUnsavedChanges() Then

                    Me.ShowWaitForm()

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    LoadGrid()

                    _SearchingByEmployee = ButtonItemSearchFilter_ByEmployee.Checked

                    Me.ClearChanged()

                    EnableOrDisableActions()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select a date range.")

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Message As String = ""

            Me.FormAction = WinForm.Presentation.FormActions.Saving

            Try

                DataGridViewMain_TimeRecords.CurrentView.CloseEditorForUpdating()

                If DataGridViewMain_TimeRecords.HasAnyInvalidRows = False Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        If Save(Message) = True Then

                            LoadGrid()

                            Me.ClearChanged()

                            EnableOrDisableActions()

                        End If

                    End If

                Else

                    Message = "Please fix invalid row(s)."

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            If Message <> "" Then

                AdvantageFramework.Navigation.ShowMessageBox(Message)

            End If

        End Sub
        Private Sub ButtonItemSearchFilter_ByEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearchFilter_ByEmployee.CheckedChanged

            If ButtonItemSearchFilter_ByEmployee.Checked AndAlso Me.FormShown Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                Me.ShowWaitForm()

                Try

                    SetupSearch()
                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemSearchFilter_ByJob_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearchFilter_ByJob.CheckedChanged

            If ButtonItemSearchFilter_ByJob.Checked AndAlso Me.FormShown Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                Me.ShowWaitForm()

                Try

                    SetupSearch()
                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub SearchableComboBoxSearch_ClientOrEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSearch_ClientOrEmployee.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing

            If ButtonItemSearchFilter_ByJob.Checked = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If SearchableComboBoxSearch_ClientOrEmployee.HasASelectedValue Then

                            ClientCode = SearchableComboBoxSearch_ClientOrEmployee.GetSelectedValue.ToString

                            SearchableComboBoxSearch_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                      Where Entity.ClientCode = ClientCode
                                                                      Select Entity

                        Else

                            SearchableComboBoxSearch_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)

                        End If

                        SearchableComboBoxSearch_Job.EditValue = Nothing
                        SearchableComboBoxSearch_JobComp.EditValue = Nothing

                    End Using

                End Using

            End If

        End Sub
        Private Sub SearchableComboBoxSearch_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSearch_Job.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            If ButtonItemSearchFilter_ByJob.Checked = True Then

                If SearchableComboBoxSearch_Job.HasASelectedValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobNumber = CInt(SearchableComboBoxSearch_Job.GetSelectedValue)

                        SearchableComboBoxSearch_JobComp.Enabled = True

                        JobComponents = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                                         Where Entity.JobNumber = JobNumber AndAlso
                                               (Entity.JobProcessControl Is Nothing OrElse
                                                Entity.JobProcessControl = 1 OrElse
                                                Entity.JobProcessControl = 3 OrElse
                                                Entity.JobProcessControl = 4 OrElse
                                                Entity.JobProcessControl = 5 OrElse
                                                Entity.JobProcessControl = 7 OrElse
                                                Entity.JobProcessControl = 8 OrElse
                                                Entity.JobProcessControl = 9 OrElse
                                                Entity.JobProcessControl = 10 OrElse
                                                Entity.JobProcessControl = 11)
                                         Select Entity).ToList

                        SearchableComboBoxSearch_JobComp.DataSource = JobComponents

                        SearchableComboBoxSearch_JobComp.EditValue = Nothing

                    End Using

                    If JobComponents IsNot Nothing AndAlso JobComponents.Count = 1 Then

                        SearchableComboBoxSearch_JobComp.EditValue = JobComponents(0).JobComponentNumber

                    End If

                Else

                    SearchableComboBoxSearch_JobComp.DataSource = Nothing
                    SearchableComboBoxSearch_JobComp.Enabled = False
                    SearchableComboBoxSearch_JobComp.EditValue = Nothing

                End If

            End If

        End Sub
        Private Sub ButtonItemFeeTime_No_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_No.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyFeeTime(NonbilledEmployeeTime, AdvantageFramework.Database.Entities.FeeTimes.No) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstFee_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstFee.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyFeeTime(NonbilledEmployeeTime, AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstFee) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstCommissionM_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstCommissionM.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyFeeTime(NonbilledEmployeeTime, AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstCommissionM) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemFeeTime_TimeAgainstCommissionP_Click(sender As Object, e As EventArgs) Handles ButtonItemFeeTime_TimeAgainstCommissionP.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyFeeTime(NonbilledEmployeeTime, AdvantageFramework.Database.Entities.FeeTimes.TimeAgainstCommissionP) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemActions_MarkBillable_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_MarkBillable.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyBillable(NonbilledEmployeeTime, False) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemActions_MarkNonBillable_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_MarkNonBillable.Click

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    NonbilledEmployeeTime = Nothing
                End Try

                If NonbilledEmployeeTime IsNot Nothing Then

                    If ModifyBillable(NonbilledEmployeeTime, True) Then

                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    End If

                End If

            Next

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewMain_TimeRecords_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewMain_TimeRecords.CellValueChangedEvent

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing
            Dim DepartmentDescription As String = Nothing

            Try

                NonbilledEmployeeTime = DataGridViewMain_TimeRecords.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                NonbilledEmployeeTime = Nothing
            End Try

            If NonbilledEmployeeTime IsNot Nothing Then

                Select Case e.Column.FieldName

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString

                        If ModifyFeeTime(NonbilledEmployeeTime, CShort(e.Value)) Then

                            DataGridViewMain_TimeRecords.AddToModifiedRows(e.RowHandle)

                        End If

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString

                        If ModifyBillable(NonbilledEmployeeTime, CBool(e.Value)) Then

                            DataGridViewMain_TimeRecords.AddToModifiedRows(e.RowHandle)

                        End If

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString

                        Try

                            NonbilledEmployeeTime.TotalBill = Math.Round(CDec(e.Value) * NonbilledEmployeeTime.EmployeeHours, 2, MidpointRounding.AwayFromZero)

                        Catch ex As Exception
                            NonbilledEmployeeTime.TotalBill = 0
                        End Try

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamCode.ToString

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Try

                                DepartmentDescription = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, e.Value).Description

                            Catch ex As Exception

                            End Try

                            NonbilledEmployeeTime.DepartmentTeamDescription = DepartmentDescription

                        End Using

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                End Select

            End If

        End Sub
        Private Sub DataGridViewMain_TimeRecords_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewMain_TimeRecords.CustomRowCellEditEvent

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            Try

                NonbilledEmployeeTime = DirectCast(DataGridViewMain_TimeRecords.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.NonbilledEmployeeTime)

            Catch ex As Exception
                NonbilledEmployeeTime = Nothing
            End Try

            If NonbilledEmployeeTime IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString Then

                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                        e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                End If

                If e.Column.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString Then

                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                        e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                End If

                If e.Column.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTitleID.ToString Then

                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                        e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewMain_TimeRecords_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewMain_TimeRecords.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewMain_TimeRecords_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewMain_TimeRecords.ShowingEditorEvent

            'objects
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            Try

                NonbilledEmployeeTime = DirectCast(DataGridViewMain_TimeRecords.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.NonbilledEmployeeTime)

            Catch ex As Exception
                NonbilledEmployeeTime = Nothing
            End Try

            If NonbilledEmployeeTime IsNot Nothing Then

                Select Case DataGridViewMain_TimeRecords.CurrentView.FocusedColumn.FieldName

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString,
                         AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString

                        e.Cancel = (NonbilledEmployeeTime.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled)

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamCode.ToString

                        e.Cancel = Not _SearchingByEmployee

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTitleID.ToString

                        If _SearchingByEmployee = False Then

                            e.Cancel = True

                        ElseIf NonbilledEmployeeTime.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                            e.Cancel = True

                        Else

                            e.Cancel = False

                        End If

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TaskCode.ToString

                        e.Cancel = Not _ShowTaskCode

                    Case AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.Assignment.ToString

                        If NonbilledEmployeeTime.JobNumber.HasValue = False OrElse NonbilledEmployeeTime.JobComponentNumber.HasValue = False Then

                            e.Cancel = True

                        End If

                    Case Else

                        e.Cancel = True

                End Select

                If e.Cancel Then

                    If DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TaskCode.ToString) IsNot Nothing Then

                        DataGridViewMain_TimeRecords.CurrentView.FocusedColumn = DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.TaskCode.ToString)

                    ElseIf DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString) IsNot Nothing Then

                        DataGridViewMain_TimeRecords.CurrentView.FocusedColumn = DataGridViewMain_TimeRecords.CurrentView.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateRate_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_UpdateRate.Click

            'objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim PreTaxTotal As Decimal = 0
            Dim ExtendedStateResale As Decimal = 0
            Dim ExtendedCityResale As Decimal = 0
            Dim ExtendedCountyResale As Decimal = 0
            Dim TaxCityPercent As Decimal = Nothing
            Dim TaxCountyPercent As Decimal = Nothing
            Dim TaxStatePercent As Decimal = Nothing
            Dim TaxCode As String = Nothing
            Dim TaxResale As Short? = Nothing

            Me.ShowWaitForm()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    Try

                        NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        NonbilledEmployeeTime = Nothing
                    End Try

                    If NonbilledEmployeeTime IsNot Nothing AndAlso NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                        BillingRateLevel = Nothing
                        BillingRate = Nothing
                        SalesTax = Nothing
                        ExtendedStateResale = Nothing
                        ExtendedCityResale = Nothing
                        ExtendedCountyResale = Nothing
                        TaxCityPercent = Nothing
                        TaxCountyPercent = Nothing
                        TaxStatePercent = Nothing
                        TaxCode = Nothing
                        TaxResale = Nothing

                        Try

                            BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, NonbilledEmployeeTime.FunctionCode, NonbilledEmployeeTime.ClientCode, NonbilledEmployeeTime.DivisionCode,
                                                                                            NonbilledEmployeeTime.ProductCode, NonbilledEmployeeTime.JobNumber, NonbilledEmployeeTime.JobComponentNumber,
                                                                                            NonbilledEmployeeTime.SalesClassCode, NonbilledEmployeeTime.EmployeeCode, NonbilledEmployeeTime.EmployeeDate)

                        Catch ex As Exception
                            BillingRate = Nothing
                        End Try

                        If BillingRate IsNot Nothing Then

                            NonbilledEmployeeTime.BillingRate = BillingRate.BILLING_RATE
                            NonbilledEmployeeTime.EmployeeNonBillableFlag = BillingRate.NOBILL_FLAG
                            NonbilledEmployeeTime.FeeTimeFlag = BillingRate.FEE_TIME_FLAG
                            NonbilledEmployeeTime.TaxCommission = BillingRate.TAX_COMM
                            NonbilledEmployeeTime.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY
                            NonbilledEmployeeTime.EmployeeCommissionPercent = BillingRate.COMM

                            PreTaxTotal = Math.Round(NonbilledEmployeeTime.BillingRate.GetValueOrDefault(0) * NonbilledEmployeeTime.EmployeeHours, 2, MidpointRounding.AwayFromZero)

                            NonbilledEmployeeTime.TotalBill = PreTaxTotal

                            If BillingRate.RATE_LEVEL = 9999 Then

                                NonbilledEmployeeTime.EmployeeRateFrom = "Approved Estimate"

                            Else

                                Try

                                    If BillingRate.RATE_LEVEL.HasValue Then

                                        BillingRateLevel = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext)
                                                            Where Entity.Number = BillingRate.RATE_LEVEL
                                                            Select Entity).FirstOrDefault

                                    End If

                                Catch ex As Exception
                                    BillingRateLevel = Nothing
                                End Try

                                If BillingRateLevel IsNot Nothing Then

                                    NonbilledEmployeeTime.EmployeeRateFrom = BillingRateLevel.Description

                                End If

                            End If

                            If BillingRate.COMM.GetValueOrDefault(0) = 0 Then

                                NonbilledEmployeeTime.ExtendedMarkupAmount = 0

                            Else

                                NonbilledEmployeeTime.ExtendedMarkupAmount = Math.Round(PreTaxTotal * (BillingRate.COMM.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

                            End If

                            If String.IsNullOrEmpty(BillingRate.TAX_CODE) = False Then

                                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, BillingRate.TAX_CODE)

                                If SalesTax IsNot Nothing Then

                                    TaxResale = SalesTax.Resale
                                    TaxCode = SalesTax.TaxCode
                                    TaxCityPercent = SalesTax.CityPercent
                                    TaxCountyPercent = SalesTax.CountyPercent
                                    TaxStatePercent = SalesTax.StatePercent

                                End If

                                If NonbilledEmployeeTime.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                                    ExtendedStateResale = CalculateResale(0, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxStatePercent)
                                    ExtendedCityResale = CalculateResale(0, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxCityPercent)
                                    ExtendedCountyResale = CalculateResale(0, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxCountyPercent)

                                ElseIf NonbilledEmployeeTime.TaxCommission.GetValueOrDefault(0) = 1 Then

                                    ExtendedStateResale = CalculateResale(PreTaxTotal, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxStatePercent)
                                    ExtendedCityResale = CalculateResale(PreTaxTotal, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxCityPercent)
                                    ExtendedCountyResale = CalculateResale(PreTaxTotal, NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0), TaxCountyPercent)

                                Else

                                    ExtendedStateResale = CalculateResale(PreTaxTotal, 0, TaxStatePercent)
                                    ExtendedCityResale = CalculateResale(PreTaxTotal, 0, TaxCityPercent)
                                    ExtendedCountyResale = CalculateResale(PreTaxTotal, 0, TaxCountyPercent)

                                End If

                            Else

                                ExtendedStateResale = CalculateResale(PreTaxTotal, 0, TaxStatePercent)
                                ExtendedCityResale = CalculateResale(PreTaxTotal, 0, TaxCityPercent)
                                ExtendedCountyResale = CalculateResale(PreTaxTotal, 0, TaxCountyPercent)

                            End If

                            NonbilledEmployeeTime.TaxCode = TaxCode
                            NonbilledEmployeeTime.TaxResale = TaxResale

                            NonbilledEmployeeTime.TaxCityPercent = TaxCityPercent
                            NonbilledEmployeeTime.TaxCountyPercent = TaxCountyPercent
                            NonbilledEmployeeTime.TaxStatePercent = TaxStatePercent

                            NonbilledEmployeeTime.ExtendedStateResale = ExtendedStateResale
                            NonbilledEmployeeTime.ExtendedCityResale = ExtendedCityResale
                            NonbilledEmployeeTime.ExtendedCountyResale = ExtendedCountyResale

                            NonbilledEmployeeTime.SetPropertyAutomaticallyChanged(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString, True)
                            NonbilledEmployeeTime.SetPropertyAutomaticallyChanged(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeNonBillableFlag.ToString, True)

                            'NonbilledEmployeeTime.AdjusterComments = "Updated on " & System.DateTime.Today.ToString & " by user " & Me.Session.UserCode

                            NonbilledEmployeeTime.LineTotal = Math.Round(PreTaxTotal +
                                                                         NonbilledEmployeeTime.ExtendedMarkupAmount.GetValueOrDefault(0) +
                                                                         NonbilledEmployeeTime.ExtendedCityResale.GetValueOrDefault(0) +
                                                                         NonbilledEmployeeTime.ExtendedCountyResale.GetValueOrDefault(0) +
                                                                         NonbilledEmployeeTime.ExtendedStateResale.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                            DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                        End If

                    End If

                Next

            End Using

            Me.CloseWaitForm()

            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

            DataGridViewMain_TimeRecords.SetUserEntryChanged()

        End Sub
        Private Sub ButtonItemActions_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDescriptions.CheckedChanged

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                RefreshColumnOrderAndVisibility()

                AdvantageFramework.Security.SaveUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInAdjustTime, ButtonItemActions_ShowDescriptions.Checked)

            End If

        End Sub
        Private Sub ButtonItemDeptTeam_FromList_Click(sender As Object, e As EventArgs) Handles ButtonItemDeptTeam_FromList.Click

            'objects
            Dim SelectedObjects As IEnumerable = Nothing
            Dim Department As Object = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            If _SearchingByEmployee = True Then

                If DataGridViewMain_TimeRecords.HasASelectedRow Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Department, True, True, SelectedObjects, False, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then

                        Me.ShowWaitForm()

                        Try

                            Department = (From Entity In SelectedObjects
                                          Select Entity).FirstOrDefault

                        Catch ex As Exception
                            Department = Nothing
                        End Try

                        If Department IsNot Nothing Then

                            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                                Try

                                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                                Catch ex As Exception
                                    NonbilledEmployeeTime = Nothing
                                End Try

                                If NonbilledEmployeeTime IsNot Nothing Then

                                    If NonbilledEmployeeTime.DepartmentTeamCode <> Department.Code Then

                                        NonbilledEmployeeTime.DepartmentTeamCode = Department.Code
                                        NonbilledEmployeeTime.DepartmentTeamDescription = Department.Description

                                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                                    End If

                                End If

                            Next

                            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                            DataGridViewMain_TimeRecords.SetUserEntryChanged()

                        End If

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDeptTeam_FromHRHistory_Click(sender As Object, e As EventArgs) Handles ButtonItemDeptTeam_FromHRHistory.Click

            'objects
            Dim EmployeeCodes() As String = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing
            Dim EmployeeRateHistories As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            If _SearchingByEmployee = True Then

                If DataGridViewMain_TimeRecords.HasASelectedRow Then

                    Me.ShowWaitForm()

                    EmployeeCodes = DataGridViewMain_TimeRecords.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime).ToList.Select(Function(Entity) Entity.EmployeeCode).Distinct.ToArray

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            EmployeeRateHistories = (From Entity In AdvantageFramework.Database.Procedures.EmployeeRateHistory.Load(DbContext).Include("DepartmentTeam")
                                                     Where EmployeeCodes.Contains(Entity.EmployeeCode) = True
                                                     Select Entity).ToList

                        End Using

                    Catch ex As Exception
                        EmployeeRateHistories = Nothing
                    End Try

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Employees = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("DepartmentTeam")
                                         Where EmployeeCodes.Contains(Entity.Code) = True
                                         Select Entity).ToList

                        End Using

                    Catch ex As Exception
                        Employees = Nothing
                    End Try

                    If EmployeeRateHistories IsNot Nothing AndAlso Employees IsNot Nothing Then

                        For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                            Try

                                NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                NonbilledEmployeeTime = Nothing
                            End Try

                            If NonbilledEmployeeTime IsNot Nothing Then

                                EmployeeRateHistory = Nothing
                                Employee = Nothing

                                Try

                                    Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = NonbilledEmployeeTime.EmployeeCode)

                                Catch ex As Exception
                                    Employee = Nothing
                                End Try

                                If Employee IsNot Nothing Then

                                    Try

                                        EmployeeRateHistory = EmployeeRateHistories.SingleOrDefault(Function(Entity) Entity.EmployeeCode = NonbilledEmployeeTime.EmployeeCode AndAlso NonbilledEmployeeTime.EmployeeDate >= Entity.StartDate AndAlso NonbilledEmployeeTime.EmployeeDate <= Entity.EndDate)

                                    Catch ex As Exception
                                        EmployeeRateHistory = Nothing
                                    End Try

                                    If EmployeeRateHistory IsNot Nothing Then

                                        If NonbilledEmployeeTime.DepartmentTeamCode <> EmployeeRateHistory.DepartmentTeamCode Then

                                            NonbilledEmployeeTime.DepartmentTeamCode = EmployeeRateHistory.DepartmentTeamCode
                                            NonbilledEmployeeTime.DepartmentTeamDescription = EmployeeRateHistory.DepartmentTeam.Description

                                        End If

                                    Else

                                        NonbilledEmployeeTime.DepartmentTeamCode = Employee.DepartmentTeamCode
                                        NonbilledEmployeeTime.DepartmentTeamDescription = Employee.DepartmentTeam.Description

                                    End If

                                    DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                                End If

                            End If

                        Next

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                        DataGridViewMain_TimeRecords.SetUserEntryChanged()

                    End If

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemEmployeeTitle_FromList_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTitle_FromList.Click

            'objects
            Dim SelectedObjects As IEnumerable = Nothing
            Dim EmployeeTitle As Object = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            If _SearchingByEmployee = True Then

                If DataGridViewMain_TimeRecords.HasASelectedRow AndAlso (From Entity In DataGridViewMain_TimeRecords.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime).ToList
                                                                         Where Entity.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTime.EmployeeTimeFlags.Indirect
                                                                         Select Entity).Any Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.EmployeeTitle, True, True, SelectedObjects, False, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then

                        Me.ShowWaitForm()

                        Try

                            EmployeeTitle = (From Entity In SelectedObjects
                                             Select Entity).FirstOrDefault

                        Catch ex As Exception
                            EmployeeTitle = Nothing
                        End Try

                        If EmployeeTitle IsNot Nothing Then

                            For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                                Try

                                    NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                                Catch ex As Exception
                                    NonbilledEmployeeTime = Nothing
                                End Try

                                If NonbilledEmployeeTime IsNot Nothing Then

                                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                                        If NonbilledEmployeeTime.EmployeeTitleID <> EmployeeTitle.ID Then

                                            NonbilledEmployeeTime.EmployeeTitleID = EmployeeTitle.ID

                                            DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                                        End If

                                    End If

                                End If

                            Next

                            DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                            DataGridViewMain_TimeRecords.SetUserEntryChanged()

                        End If

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemEmployeeTitle_FromHRHistory_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployeeTitle_FromHRHistory.Click

            'objects
            Dim EmployeeCodes() As String = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing
            Dim EmployeeRateHistories As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            If _SearchingByEmployee = True Then

                If DataGridViewMain_TimeRecords.HasASelectedRow AndAlso (From Entity In DataGridViewMain_TimeRecords.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime).ToList
                                                                         Where Entity.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTime.EmployeeTimeFlags.Indirect
                                                                         Select Entity).Any Then

                    Me.ShowWaitForm()

                    EmployeeCodes = DataGridViewMain_TimeRecords.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTime).ToList.Select(Function(Entity) Entity.EmployeeCode).Distinct.ToArray

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            EmployeeRateHistories = (From Entity In AdvantageFramework.Database.Procedures.EmployeeRateHistory.Load(DbContext)
                                                     Where EmployeeCodes.Contains(Entity.EmployeeCode) = True
                                                     Select Entity).ToList

                        End Using

                    Catch ex As Exception
                        EmployeeRateHistories = Nothing
                    End Try

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Employees = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                         Where EmployeeCodes.Contains(Entity.Code) = True
                                         Select Entity).ToList

                        End Using

                    Catch ex As Exception
                        Employees = Nothing
                    End Try

                    If EmployeeRateHistories IsNot Nothing AndAlso Employees IsNot Nothing Then

                        For Each RowHandlesAndDataBoundItem In DataGridViewMain_TimeRecords.GetAllSelectedRowsRowHandlesAndDataBoundItems

                            Try

                                NonbilledEmployeeTime = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                NonbilledEmployeeTime = Nothing
                            End Try

                            If NonbilledEmployeeTime IsNot Nothing Then

                                If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                                    EmployeeRateHistory = Nothing
                                    Employee = Nothing

                                    Try

                                        Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = NonbilledEmployeeTime.EmployeeCode)

                                    Catch ex As Exception
                                        Employee = Nothing
                                    End Try

                                    If Employee IsNot Nothing Then

                                        Try

                                            EmployeeRateHistory = EmployeeRateHistories.SingleOrDefault(Function(Entity) Entity.EmployeeCode = NonbilledEmployeeTime.EmployeeCode AndAlso NonbilledEmployeeTime.EmployeeDate >= Entity.StartDate AndAlso NonbilledEmployeeTime.EmployeeDate <= Entity.EndDate)

                                        Catch ex As Exception
                                            EmployeeRateHistory = Nothing
                                        End Try

                                        If EmployeeRateHistory IsNot Nothing Then

                                            If NonbilledEmployeeTime.EmployeeTitleID <> EmployeeRateHistory.EmployeeTitleID Then

                                                NonbilledEmployeeTime.EmployeeTitleID = EmployeeRateHistory.EmployeeTitleID

                                            End If

                                        Else

                                            NonbilledEmployeeTime.EmployeeTitleID = Employee.EmployeeTitleID

                                        End If

                                        DataGridViewMain_TimeRecords.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                                    End If

                                End If

                            End If

                        Next

                        DataGridViewMain_TimeRecords.CurrentView.RefreshData()

                        DataGridViewMain_TimeRecords.SetUserEntryChanged()

                    End If

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxSearch_JobComp_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxSearch_JobComp.QueryPopUp

            If SearchableComboBoxSearch_JobComp.Properties.View.Columns("JobNumber") IsNot Nothing Then

                SearchableComboBoxSearch_JobComp.Properties.View.Columns("JobNumber").Visible = False

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox = Nothing

            DataGridViewForm_Export.ItemDescription = DataGridViewMain_TimeRecords.ItemDescription
            DataGridViewForm_Export.DataSource = DirectCast(DataGridViewMain_TimeRecords.DataSource, System.Windows.Forms.BindingSource).DataSource
            DataGridViewForm_Export.CurrentView.BestFitColumns()

            Try

                SubItemImageComboBox = DataGridViewForm_Export.Columns(AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.Properties.EmployeeTimeFlag.ToString).ColumnEdit

                If SubItemImageComboBox IsNot Nothing Then

                    SubItemImageComboBox.SmallImages = Nothing
                    SubItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far

                End If

            Catch ex As Exception

            End Try

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim SuperToolTip As DevExpress.Utils.SuperToolTip = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime = Nothing

            If e.SelectedControl Is DataGridViewMain_TimeRecords.GridControl Then

                Try

                    GridView = CType(DataGridViewMain_TimeRecords.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column IsNot Nothing AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTimeFlag.ToString Then

                            Try

                                NonbilledEmployeeTime = DataGridViewMain_TimeRecords.CurrentView.GetRow(GridHitInfo.RowHandle)

                            Catch ex As Exception
                                NonbilledEmployeeTime = Nothing
                            End Try

                            If NonbilledEmployeeTime IsNot Nothing Then

                                Try

                                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle & "EmployeeTimeFlag", "Unbilled")

                                    ElseIf NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Billed Then

                                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle & "EmployeeTimeFlag", "Billed")

                                    ElseIf NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle & "EmployeeTimeFlag", "Indirect")

                                    ElseIf NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.SelectedForBilling Then

                                        ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle & "EmployeeTimeFlag", "Selected for Billing")

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub DataGridViewMain_TimeRecords_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewMain_TimeRecords.QueryPopupNeedDatasourceEvent

            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim JobComponentNumber As Nullable(Of Short) = Nothing

            If FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.Assignment.ToString Then

                JobNumber = DirectCast(DataGridViewMain_TimeRecords.CurrentView.GetRow(DataGridViewMain_TimeRecords.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.NonbilledEmployeeTime).JobNumber
                JobComponentNumber = DirectCast(DataGridViewMain_TimeRecords.CurrentView.GetRow(DataGridViewMain_TimeRecords.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.NonbilledEmployeeTime).JobComponentNumber

                If JobNumber.HasValue AndAlso JobComponentNumber.HasValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext)
                                      Where Entity.JobNumber = JobNumber.Value AndAlso
                                            Entity.JobComponentNumber = JobComponentNumber.Value AndAlso
                                            Entity.AlertTypeID = 6
                                      Select New With {.ID = Entity.ID,
                                                       .Description = Entity.Subject}).ToList

                    End Using

                    OverrideDefaultDatasource = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
