Namespace Employee.Presentation

    Public Class ExpenseReportSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LastSearchedEmployeeCode As String = Nothing
        Private _LastSearchedMonth As String = Nothing
        Private _LastSearchedYear As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadEmployeeVendors()

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Classes.Employee) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Employees = (From Employee In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(Me.Session, DbContext, SecurityDbContext, True)
                                     Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial, Employee.TerminationDate}).ToList _
                                     .Select(Function(e) New AdvantageFramework.Database.Classes.Employee With {.Code = e.Code,
                                                                                                                .Name = e.FirstName & " " & If(e.MiddleInitial <> "", e.MiddleInitial & ". ", "") & e.LastName,
                                                                                                                .Terminated = e.TerminationDate.HasValue}).ToList

                        SearchableComboBoxSearch_Employees.DataSource = Employees
                            SearchableComboBoxSearch_Employees.SelectedValue = Me.Session.User.EmployeeCode
                        SearchableComboBoxSearch_Employees.Enabled = True

                    End Using

            End Using

            If Me.FormShown = False Then

                SearchableComboBoxSearch_Employees.ActiveFilterString = "[Terminated] = False"

            End If

                If Employees Is Nothing OrElse Employees.Count = 0 Then

                    ButtonItemActions_Add.Enabled = False

                ElseIf Employees.Count = 1 Then

                    _LastSearchedEmployeeCode = Employees.FirstOrDefault.Code
                    _LastSearchedYear = ComboBoxSearch_Year.GetSelectedValue
                    _LastSearchedMonth = ComboBoxSearch_Month.GetSelectedValue
                    SearchableComboBoxSearch_Employees.SelectedValue = _LastSearchedEmployeeCode

                ElseIf (From Emp In Employees
                        Where Emp.Code = Me.Session.User.EmployeeCode
                        Select Emp).Any Then

                    _LastSearchedEmployeeCode = Me.Session.User.EmployeeCode
                _LastSearchedYear = ComboBoxSearch_Year.GetSelectedValue
                _LastSearchedMonth = ComboBoxSearch_Month.GetSelectedValue
                SearchableComboBoxSearch_Employees.SelectedValue = _LastSearchedEmployeeCode

            End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReport) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            If String.IsNullOrEmpty(_LastSearchedEmployeeCode) = False AndAlso
               String.IsNullOrEmpty(_LastSearchedMonth) = False AndAlso
               String.IsNullOrEmpty(_LastSearchedYear) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    StartDate = New Date(_LastSearchedYear, _LastSearchedMonth, 1)
                    EndDate = New Date(_LastSearchedYear, _LastSearchedMonth, System.DateTime.DaysInMonth(_LastSearchedYear, _LastSearchedMonth))

                    Try

                        ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                             Where Entity.EmployeeCode = _LastSearchedEmployeeCode AndAlso
                                                   Entity.InvoiceDate >= StartDate AndAlso
                                                   Entity.InvoiceDate <= EndDate
                                             Select Entity).ToList _
                                            .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList

                    Catch ex As Exception
                        ExpenseReportList = New Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReport)
                    End Try

                    If ExpenseReportList IsNot Nothing AndAlso ExpenseReportList.Count > 0 Then

                        DataGridViewLeftSection_ExpenseReports.DataSource = ExpenseReportList.OrderByDescending(Function(ExpReport) ExpReport.InvoiceNumber)

                    Else

                        DataGridViewLeftSection_ExpenseReports.DataSource = ExpenseReportList

                    End If

                    DataGridViewLeftSection_ExpenseReports.CurrentView.BestFitColumns()

                End Using

            Else

                DataGridViewLeftSection_ExpenseReports.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReport))

            End If

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                ExpenseReportControlRightSection_ExpenseReport.ClearControl()

                ExpenseReportControlRightSection_ExpenseReport.Enabled = DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow

                If ExpenseReportControlRightSection_ExpenseReport.Enabled Then

                    ExpenseReportControlRightSection_ExpenseReport.Enabled = ExpenseReportControlRightSection_ExpenseReport.LoadControl(DataGridViewLeftSection_ExpenseReports.GetFirstSelectedRowBookmarkValue, SearchableComboBoxSearch_Employees.GetSelectedValue, False)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Function IsSelectedEmployeeTerminated() As Boolean

            'objects
            Dim IsTerminated As Boolean = False

            Try

                If SearchableComboBoxSearch_Employees.HasASelectedValue Then

                    For RowHandle = 0 To SearchableComboBoxSearch_Employees.Properties.View.RowCount - 1

                        If SearchableComboBoxSearch_Employees.GetSelectedRowCellValue(AdvantageFramework.Database.Classes.Employee.Properties.Code.ToString) = SearchableComboBoxSearch_Employees.GetSelectedValue Then

                            IsTerminated = CBool(SearchableComboBoxSearch_Employees.GetSelectedRowCellValue(AdvantageFramework.Database.Classes.Employee.Properties.Terminated.ToString))

                            Exit For

                        End If

                    Next

                End If

            Catch ex As Exception
                IsTerminated = False
            Finally
                IsSelectedEmployeeTerminated = IsTerminated
            End Try

        End Function
        Private Sub EnableOrDisableActions()

            'objects
            Dim CanUnSubmit As Boolean = False
            Dim IsOpen As Boolean = False

            ExpenseReportControlRightSection_ExpenseReport.Enabled = (DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow AndAlso Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Items.Visible = ExpenseReportControlRightSection_ExpenseReport.LineItemsTabSelected
            RibbonBarOptions_Receipts.Visible = ExpenseReportControlRightSection_ExpenseReport.ReceiptsTabSelected
            RibbonBarOptions_Filter.Visible = ExpenseReportControlRightSection_ExpenseReport.ReceiptsTabSelected

            If ExpenseReportControlRightSection_ExpenseReport.Enabled Then

                If IsSelectedEmployeeTerminated() Then

                    ButtonItemActions_Delete.Enabled = False
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Copy.Enabled = False
                    ButtonItemActions_Submit.Enabled = False
                    ButtonItemActions_Unsubmit.Enabled = False
                    ButtonItemActions_Print.Enabled = DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow

                    ButtonItemItems_Export.Enabled = ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasRows
                    ButtonItemItems_Cancel.Enabled = False
                    ButtonItemItems_Delete.Enabled = False
                    ButtonItemItems_Copy.Enabled = False
                    ButtonItemItems_Documents.Enabled = False

                    ButtonItemReceipts_Delete.Enabled = False
                    ButtonItemReceipts_Download.Enabled = ExpenseReportControlRightSection_ExpenseReport.DocumentManagerControl.HasASelectedDocument
                    ButtonItemReceipts_Upload.Enabled = False

                Else

                    If ExpenseReportControlRightSection_ExpenseReport.Status = ExpenseReports.ExpenseReportStatus.Open Then

                        IsOpen = True

                    ElseIf ExpenseReportControlRightSection_ExpenseReport.Status = ExpenseReports.ExpenseReportStatus.Pending OrElse
                           ExpenseReportControlRightSection_ExpenseReport.Status = ExpenseReports.ExpenseReportStatus.PendingApproval OrElse
                           ExpenseReportControlRightSection_ExpenseReport.Status = ExpenseReports.ExpenseReportStatus.DeniedByApprover OrElse
                           ExpenseReportControlRightSection_ExpenseReport.Status = ExpenseReports.ExpenseReportStatus.DeniedByAccounting Then

                        CanUnSubmit = True

                    End If

                    ButtonItemActions_Delete.Enabled = IsOpen
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Copy.Enabled = DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow
                    ButtonItemActions_Submit.Enabled = DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow AndAlso ExpenseReportControlRightSection_ExpenseReport.HasExpenseReportItems AndAlso IsOpen
                    ButtonItemActions_Unsubmit.Enabled = CanUnSubmit
                    ButtonItemActions_Print.Enabled = DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow

                    ButtonItemItems_Export.Enabled = ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasRows
                    ButtonItemItems_Cancel.Enabled = ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.CurrentView.IsNewItemRow(ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.CurrentView.FocusedRowHandle)
                    ButtonItemItems_Delete.Enabled = (IsOpen AndAlso ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasOnlyOneSelectedRow(True) AndAlso ExpenseReportControlRightSection_ExpenseReport.UserCanDeleteSelectedLineItem)
                    ButtonItemItems_Copy.Enabled = (IsOpen AndAlso ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasASelectedRow AndAlso ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.CurrentView.IsNewItemRow(ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.CurrentView.FocusedRowHandle) = False)
                    ButtonItemItems_Documents.Enabled = (IsOpen AndAlso ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasOnlyOneSelectedRow(True) AndAlso ExpenseReportControlRightSection_ExpenseReport.HasAccessToDocuments)

                    ButtonItemReceipts_Delete.Enabled = (IsOpen AndAlso ExpenseReportControlRightSection_ExpenseReport.DocumentManagerControl.HasASelectedDocument)
                    ButtonItemReceipts_Download.Enabled = ExpenseReportControlRightSection_ExpenseReport.DocumentManagerControl.HasASelectedDocument
                    ButtonItemReceipts_Upload.Enabled = ExpenseReportControlRightSection_ExpenseReport.DocumentManagerControl.CanUpload AndAlso IsOpen

                End If

            Else

                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Submit.Enabled = False
                ButtonItemActions_Unsubmit.Enabled = False
                ButtonItemActions_Print.Enabled = False

                ButtonItemItems_Export.Enabled = False
                ButtonItemItems_Cancel.Enabled = False
                ButtonItemItems_Delete.Enabled = False
                ButtonItemItems_Copy.Enabled = False
                ButtonItemItems_Documents.Enabled = False

                ButtonItemReceipts_Delete.Enabled = False
                ButtonItemReceipts_Download.Enabled = False
                ButtonItemReceipts_Upload.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator AndAlso Not ExpenseReportControlRightSection_ExpenseReport.LineItemsDataGridView.HasAnyInvalidRows

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = ExpenseReportControlRightSection_ExpenseReport.Save(False, "")

                        Catch ex As Exception
                            'AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            IsOkay = True

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub Search()

            If CheckForUnsavedChanges() Then

                Me.ClearChanged()

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                _LastSearchedEmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue
                _LastSearchedYear = ComboBoxSearch_Year.GetSelectedValue
                _LastSearchedMonth = ComboBoxSearch_Month.GetSelectedValue

                LoadGrid()

                ExpenseReportControlRightSection_ExpenseReport.ClearControl()
                ExpenseReportControlRightSection_ExpenseReport.Enabled = False
                DataGridViewLeftSection_ExpenseReports.FocusToFindPanel(True)

                Me.ClearChanged()

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub SetSearchFieldsByInvoiceNumber(ByVal InvoiceNumber As Integer, ByRef SearchValuesChanged As Boolean)

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

            End Using

            If ExpenseReport IsNot Nothing Then

                If ExpenseReport.EmployeeCode <> SearchableComboBoxSearch_Employees.GetSelectedValue OrElse
                   ExpenseReport.InvoiceDate.Value.Year <> CInt(ComboBoxSearch_Year.GetSelectedValue) OrElse
                   ExpenseReport.InvoiceDate.Value.Month <> CInt(ComboBoxSearch_Month.GetSelectedValue) Then

                    SearchableComboBoxSearch_Employees.SelectedValue = ExpenseReport.EmployeeCode
                    ComboBoxSearch_Month.SelectedValue = CLng(ExpenseReport.InvoiceDate.Value.Month)
                    ComboBoxSearch_Year.SelectedValue = CInt(ExpenseReport.InvoiceDate.Value.Year)

                    SearchValuesChanged = True

                    Search()

                End If

            End If

        End Sub
        Private Sub FilterDocuments()

            'objects
            Dim DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing

            If ButtonItemFilter_SelectedLineItem.Checked Then

                DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument

            ElseIf ButtonItemFilter_All.Checked Then

                DocumentSubLevel = Database.Entities.DocumentSubLevel.Default

            End If

            ExpenseReportControlRightSection_ExpenseReport.FilterDocuments(DocumentSubLevel)

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ExpenseReportSetupForm As AdvantageFramework.Employee.Presentation.ExpenseReportSetupForm = Nothing

            ExpenseReportSetupForm = New AdvantageFramework.Employee.Presentation.ExpenseReportSetupForm()

            ExpenseReportSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseReportSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Years As Generic.List(Of Integer) = Nothing
            Dim StartYear As Integer = Nothing
            Dim EndYear As Integer = Nothing
            Dim StartMonth As Integer = Nothing
            Dim EndMonth As Integer = Nothing

            ButtonItemActions_Import.SecurityEnabled = AdvantageFramework.Security.CanUserCustom1InModule(Me.Session, Security.Modules.Employee_ExpenseReports)

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Submit.Image = AdvantageFramework.My.Resources.ExpenseReportLock
            ButtonItemActions_Unsubmit.Image = AdvantageFramework.My.Resources.ExpenseReportUnlock
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_ViewReceipts.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.ExpenseReportSearch

            ButtonItemItems_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemItems_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemItems_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemItems_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemItems_Documents.Image = AdvantageFramework.My.Resources.DocumentManagerImage

            ButtonItemReceipts_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemReceipts_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemReceipts_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemReceiptsUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon

			ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            DataGridViewLeftSection_ExpenseReports.MultiSelect = False

            SearchableComboBoxSearch_Employees.ByPassUserEntryChanged = True
            SearchableComboBoxSearch_Employees.BringToFront()

            Years = New Generic.List(Of Integer)

            AdvantageFramework.ExpenseReports.LoadAvailableDateRange(StartMonth, StartYear, EndMonth, EndYear)

            While StartYear <= EndYear

                Years.Add(StartYear)

                StartYear = StartYear + 1

            End While

            ComboBoxSearch_Year.ByPassUserEntryChanged = True
            ComboBoxSearch_Year.DataSource = Years
            ComboBoxSearch_Year.SelectedValue = CInt(System.DateTime.Today.Year)

            ComboBoxSearch_Month.ByPassUserEntryChanged = True
            ComboBoxSearch_Month.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxSearch_Month.SelectedValue = CLng(System.DateTime.Today.Month)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemReceipts_Upload.SubItems.Remove(ButtonItemReceiptsUpload_EmailLink)
					ButtonItemReceipts_Upload.SplitButton = False

				End If

			End Using

			Try

                LoadEmployeeVendors()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            ButtonItemFilter_All.Checked = True
            ButtonItemFilter_SelectedLineItem.Checked = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ExpenseReportSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ExpenseReportSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ExpenseReportSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ExpenseReports.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "   Ribbonbar Buttons "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim ContinueAdd As Boolean = True
            Dim InvoiceNumber As String = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim SearchValuesChanged As Boolean = False

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If SearchableComboBoxSearch_Employees.HasASelectedValue Then

                    Try

                        If CBool(SearchableComboBoxSearch_Employees.GetSelectedRowCellValue(AdvantageFramework.Database.Classes.Employee.Properties.Terminated.ToString)) = False Then

                            EmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue

                        End If

                    Catch ex As Exception

                    End Try

                End If

                If AdvantageFramework.Employee.Presentation.ExpenseReportEditDialog.ShowFormDialog(InvoiceNumber, EmployeeCode, False) = Windows.Forms.DialogResult.OK Then

                    SetSearchFieldsByInvoiceNumber(InvoiceNumber, SearchValuesChanged)

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        If SearchValuesChanged = False Then

                            LoadGrid()

                        End If

                        DataGridViewLeftSection_ExpenseReports.SelectRow(InvoiceNumber)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_ExpenseReports.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemItems_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemItems_Export.Click

            ExpenseReportControlRightSection_ExpenseReport.ExportLineItems()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim InvoiceNumber As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim ContinueCopy As Boolean = True
            Dim SearchValuesChanged As Boolean = False

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    EmployeeCode = SearchableComboBoxSearch_Employees.GetSelectedValue
                    InvoiceNumber = DataGridViewLeftSection_ExpenseReports.CurrentView.GetRowCellValue(DataGridViewLeftSection_ExpenseReports.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ExpenseReport.Properties.InvoiceNumber.ToString)

                    If AdvantageFramework.Employee.Presentation.ExpenseReportEditDialog.ShowFormDialog(InvoiceNumber, EmployeeCode, True) = Windows.Forms.DialogResult.OK Then

                        SetSearchFieldsByInvoiceNumber(InvoiceNumber, SearchValuesChanged)

                        Me.FormAction = WinForm.Presentation.FormActions.Adding

                        Try

                            If SearchValuesChanged = False Then

                                LoadGrid()

                            End If

                            DataGridViewLeftSection_ExpenseReports.SelectRow(InvoiceNumber)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_ExpenseReports.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim FailedControl As Object = Nothing
            Dim ParentControl As Object = Nothing

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If ExpenseReportControlRightSection_ExpenseReport.Save(False, ErrorMessage) Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_ExpenseReports.FocusToFindPanel(False)

                        DataGridViewLeftSection_ExpenseReports.CurrentView.GridViewSelectionChanged()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                    If FailedControl IsNot Nothing Then

                        ExpenseReportControlRightSection_ExpenseReport.SetFocusOnFailedControl(FailedControl)

                    End If

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an expense report to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_ExpenseReports.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If ExpenseReportControlRightSection_ExpenseReport.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_ExpenseReports.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an expense report to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Submit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Submit.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Submit As Boolean = True
            Dim SavedAndSubmitted As Boolean = False

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If ExpenseReportControlRightSection_ExpenseReport.Save(Submit, ErrorMessage) Then

                            SavedAndSubmitted = Submit

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                    If ErrorMessage <> "" Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" OrElse SavedAndSubmitted Then

                        DataGridViewLeftSection_ExpenseReports.FocusToFindPanel(False)

                        DataGridViewLeftSection_ExpenseReports.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an expense report to submit.")

            End If

        End Sub
        Private Sub ButtonItemActions_Unsubmit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Unsubmit.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If ExpenseReportControlRightSection_ExpenseReport.UnSubmit() Then

                            Me.ClearChanged()

                            LoadGrid()

                            LoadSelectedItemDetails()

                            EnableOrDisableActions()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_ExpenseReports.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an expense report.")

            End If


        End Sub
        Private Sub ButtonItemItems_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemItems_Copy.Click

            ExpenseReportControlRightSection_ExpenseReport.CopySelectedExpenseItems()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemItems_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemItems_Cancel.Click

            ExpenseReportControlRightSection_ExpenseReport.CancelLineItemsNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemItems_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemItems_Delete.Click

            ExpenseReportControlRightSection_ExpenseReport.DeleteSelectedExpenseReportItem()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemReceipts_Upload_Click(sender As Object, e As System.EventArgs) Handles ButtonItemReceipts_Upload.Click

			ExpenseReportControlRightSection_ExpenseReport.UploadReceipt()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemReceiptsUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemReceiptsUpload_EmailLink.Click

			ExpenseReportControlRightSection_ExpenseReport.SendReceiptASPUploadEmail()

		End Sub
		Private Sub ButtonItemSearch_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            Search()

        End Sub
        Private Sub ButtonItemReceipts_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemReceipts_Delete.Click

            ExpenseReportControlRightSection_ExpenseReport.DeleteSelectedExpenseReportDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Import.Click

            AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.ExpenseReport)

        End Sub
        Private Sub ButtonItemReceipts_Download_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemReceipts_Download.Click

            ExpenseReportControlRightSection_ExpenseReport.DocumentManagerControl.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        'Private Sub ComboBoxSearch_Employees_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBoxSearch_Employees.SelectionChangeCommitted

        '    ButtonItemSearch_Search.Enabled = ComboBoxSearch_Employees.HasASelectedValue

        'End Sub
        Private Sub SearchableComboBoxSearch_Employees_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSearch_Employees.EditValueChanged

            ButtonItemSearch_Search.Enabled = SearchableComboBoxSearch_Employees.HasASelectedValue

            Try

                ButtonItemActions_Add.Enabled = Not CBool(SearchableComboBoxSearch_Employees.GetSelectedRowCellValue(AdvantageFramework.Database.Classes.Employee.Properties.Terminated.ToString))

            Catch ex As Exception
                ButtonItemActions_Add.Enabled = True
            End Try

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim InvoiceNumber As Integer = Nothing
            Dim PrintApproverName As Boolean = False
            Dim ExcludeEmployeeSignature As Boolean = False
            Dim IncludeReceipts As Boolean = False
            Dim Datasouce As Object = Nothing

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Employee.Presentation.ExpenseReportPrintOptionsDialog.ShowFormDialog(PrintApproverName, ExcludeEmployeeSignature, IncludeReceipts) = Windows.Forms.DialogResult.OK Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        InvoiceNumber = CInt(DataGridViewLeftSection_ExpenseReports.GetFirstSelectedRowBookmarkValue)

                        Datasouce = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                     Where Entity.InvoiceNumber = InvoiceNumber
                                     Select Entity).ToList

                        ParameterList.Add("DataSource", Datasouce)
                        ParameterList.Add("PrintApproverName", PrintApproverName)
                        ParameterList.Add("ExcludeEmployeeSignature", ExcludeEmployeeSignature)
                        ParameterList.Add("IncludeReceipts", IncludeReceipts)
                        ParameterList.Add("IncludeReport", True)

                        If AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.EmployeeExpenseReport, ParameterList, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then



                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ViewReceipts_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_ViewReceipts.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim InvoiceNumber As Integer = Nothing
            Dim PrintApproverName As Boolean = False
            Dim ExcludeEmployeeSignature As Boolean = False
            Dim IncludeReceipts As Boolean = False
            Dim Datasouce As Object = Nothing

            If DataGridViewLeftSection_ExpenseReports.HasOnlyOneSelectedRow Then



                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ParameterList = New Generic.Dictionary(Of String, Object)

                    InvoiceNumber = CInt(DataGridViewLeftSection_ExpenseReports.GetFirstSelectedRowBookmarkValue)

                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                 Where Entity.InvoiceNumber = InvoiceNumber
                                 Select Entity).ToList

                    ParameterList.Add("DataSource", Datasouce)
                    ParameterList.Add("PrintApproverName", PrintApproverName)
                    ParameterList.Add("ExcludeEmployeeSignature", ExcludeEmployeeSignature)
                    ParameterList.Add("IncludeReceipts", True)
                    ParameterList.Add("IncludeReport", False)

                    If AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.EmployeeExpenseReport, ParameterList, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then



                    End If

                End Using



            End If

        End Sub
        Private Sub ButtonItemItems_Documents_Click(sender As Object, e As EventArgs) Handles ButtonItemItems_Documents.Click

            ExpenseReportControlRightSection_ExpenseReport.LoadExpenseDetailDocuments()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFilter_SelectedLineItem.Checked = Not ButtonItemFilter_All.Checked

                FilterDocuments()

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFilter_LineItems_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFilter_All.Checked = Not ButtonItemFilter_SelectedLineItem.Checked

                FilterDocuments()

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#Region "   Expense Control Events "

        Private Sub ExpenseReportControlRightSection_ExpenseReport_ExpenseDetailAddedEvent() Handles ExpenseReportControlRightSection_ExpenseReport.ExpenseDetailAddedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_ExpenseDetailInitNewRowEvent() Handles ExpenseReportControlRightSection_ExpenseReport.ExpenseDetailInitNewRowEvent

            ButtonItemItems_Cancel.Enabled = True
            ButtonItemItems_Copy.Enabled = False
            ButtonItemItems_Delete.Enabled = False
            ButtonItemItems_Export.Enabled = False

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_ExpenseDetailNewRowCanceledEvent() Handles ExpenseReportControlRightSection_ExpenseReport.ExpenseDetailNewRowCanceledEvent

            EnableOrDisableActions()

            ButtonItemItems_Cancel.Enabled = False

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_ExpenseHeaderInformationChangedEvent(ReportDate As Date?, Description As String) Handles ExpenseReportControlRightSection_ExpenseReport.ExpenseHeaderInformationChangedEvent

            'objects
            Dim FocusedRowHandle As Integer = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Classes.ExpenseReport = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                FocusedRowHandle = DataGridViewLeftSection_ExpenseReports.CurrentView.FocusedRowHandle

                Try

                    ExpenseReport = DataGridViewLeftSection_ExpenseReports.CurrentView.GetRow(FocusedRowHandle)

                    If ExpenseReport IsNot Nothing Then

                        ExpenseReport.InvoiceDate = ReportDate
                        ExpenseReport.Description = Description

                    End If

                Catch ex As Exception

                End Try

                DataGridViewLeftSection_ExpenseReports.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_ExpenseTotalsChangedEvent() Handles ExpenseReportControlRightSection_ExpenseReport.ExpenseTotalsChangedEvent

            'objects
            Dim FocusedRowHandle As Integer = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Classes.ExpenseReport = Nothing

            FocusedRowHandle = DataGridViewLeftSection_ExpenseReports.CurrentView.FocusedRowHandle

            Try

                ExpenseReport = DataGridViewLeftSection_ExpenseReports.CurrentView.GetRow(FocusedRowHandle)

                If ExpenseReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.ExpenseReports.LoadExpenseReportTotals(DbContext, ExpenseReport)

                    End Using

                End If

            Catch ex As Exception

            End Try

            DataGridViewLeftSection_ExpenseReports.CurrentView.RefreshData()

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_FilteredDocumentsEvent(DocumentSubLevel As Database.Entities.DocumentSubLevel) Handles ExpenseReportControlRightSection_ExpenseReport.FilteredDocumentsEvent

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing

            If DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                ButtonItemFilter_All.Checked = False
                ButtonItemFilter_SelectedLineItem.Checked = True

            Else

                ButtonItemFilter_All.Checked = True
                ButtonItemFilter_SelectedLineItem.Checked = False

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_LineItemsSelectionChangedEvent() Handles ExpenseReportControlRightSection_ExpenseReport.LineItemsSelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ExpenseReportControlRightSection_ExpenseReport_SelectedTabChanged() Handles ExpenseReportControlRightSection_ExpenseReport.SelectedTabChanged

            EnableOrDisableActions()

        End Sub

#End Region

#Region "   Grids "

        Private Sub DataGridViewLeftSection_ExpenseReports_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_ExpenseReports.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ExpenseReports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_ExpenseReports.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
