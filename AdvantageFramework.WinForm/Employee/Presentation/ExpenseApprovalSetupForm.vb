Namespace Employee.Presentation

    Public Class ExpenseApprovalSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _GridViewExpenseReportDetails As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _HasAccessToDocuments As Boolean = False

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
            Dim Approved As Boolean = False
            Dim Pending As Boolean = False
            Dim Denied As Boolean = False
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim EmployeeCode As String = Nothing

            Approved = CheckBoxSearch_Approved.Checked
            Denied = CheckBoxSearch_Denied.Checked
            Pending = CheckBoxSearch_Pending.Checked
            EndDate = DateTimePickerSearch_EndDate.Value
            StartDate = DateTimePickerSearch_StartDate.Value
            EmployeeCode = SearchableComboBoxForm_Employee.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If String.IsNullOrWhiteSpace(EmployeeCode) Then

                    DataGridViewForm_ExpenseReports.DataSource = AdvantageFramework.Database.Procedures.ExpenseSummary.LoadForSupervisorApproval(DbContext, Me.Session.User.EmployeeCode, Pending, Denied, Approved, StartDate, EndDate).ToList

                Else

                    DataGridViewForm_ExpenseReports.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ExpenseSummary.LoadForSupervisorApproval(DbContext, Me.Session.User.EmployeeCode, Pending, Denied, Approved, StartDate, EndDate)
                                                                  Where Entity.EmployeeCode = EmployeeCode
                                                                  Select Entity).ToList
                End If


            End Using

            DataGridViewForm_ExpenseReports.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadEmployeeVendors()

            'objects
            Dim EmployeeVendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeVendorCodes As String() = Nothing
            Dim LimitedEmployees As String() = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    LimitedEmployees = (From Employee In AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)
                                        Select Employee.EmployeeCode).ToArray

                Catch ex As Exception
                    LimitedEmployees = Nothing
                End Try

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeVendorCodes = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadEmployeeVendors(DbContext)
                                       Where Entity.ActiveFlag = 1
                                       Select Entity.Code).ToArray

                Try

                    If LimitedEmployees.Any Then

                        Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                     Where EmployeeVendorCodes.Contains(Employee.EmployeeVendorCode) AndAlso
                                           LimitedEmployees.Contains(Employee.Code)
                                     Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                    .Select(Function(e) New AdvantageFramework.Database.Views.Employee With {.Code = e.Code,
                                                                                                             .FirstName = e.FirstName,
                                                                                                             .LastName = e.LastName,
                                                                                                             .MiddleInitial = e.MiddleInitial}).ToList

                    Else

                        Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                     Where EmployeeVendorCodes.Contains(Employee.EmployeeVendorCode)
                                     Select New With {Employee.Code, Employee.FirstName, Employee.LastName, Employee.MiddleInitial}).ToList _
                                    .Select(Function(e) New AdvantageFramework.Database.Views.Employee With {.Code = e.Code,
                                                                                                             .FirstName = e.FirstName,
                                                                                                             .LastName = e.LastName,
                                                                                                             .MiddleInitial = e.MiddleInitial}).ToList

                    End If

                    SearchableComboBoxForm_Employee.DataSource = Employees
                    SearchableComboBoxForm_Employee.Enabled = True


                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If DateTimePickerSearch_EndDate.ValueObject IsNot Nothing AndAlso DateTimePickerSearch_StartDate.ValueObject IsNot Nothing AndAlso
               (CheckBoxSearch_Approved.Checked OrElse CheckBoxSearch_Denied.Checked OrElse CheckBoxSearch_Pending.Checked) Then

                ButtonItemSearch_Search.Enabled = True

            Else

                ButtonItemSearch_Search.Enabled = False

            End If

            ButtonItemStatus_Approved.Enabled = DataGridViewForm_ExpenseReports.HasASelectedRow AndAlso HasAnySelectedPendingApprovalInAccountingExpenseReports() = False
            ButtonItemStatus_Denied.Enabled = DataGridViewForm_ExpenseReports.HasASelectedRow AndAlso HasAnySelectedPendingApprovalInAccountingExpenseReports() = False
            ButtonItemStatus_Pending.Enabled = DataGridViewForm_ExpenseReports.HasASelectedRow AndAlso HasAnySelectedPendingApprovalInAccountingExpenseReports() = False

        End Sub
        Private Sub UpdateApprovedFlag(ByVal ApprovedFlag As AdvantageFramework.ExpenseReports.ApprovedFlag)

            'Objects
            Dim ExpenseSummaryList As Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary) = Nothing

            For Each ExpenseSummary In DataGridViewForm_ExpenseReports.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.ExpenseSummary)()

                If IsPendingApprovalInAccounting(ExpenseSummary) = False Then

                    ExpenseSummary.IsApproved = ApprovedFlag

                End If

            Next

            DataGridViewForm_ExpenseReports.SetUserEntryChanged()

            DataGridViewForm_ExpenseReports.CurrentView.RefreshData()

        End Sub
        Private Function LoadDetailLevel(ByVal RowHandle As Integer,
                                         ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As IEnumerable

            Dim ExpenseReportItems As IEnumerable = Nothing
            Dim InvoiceNumber As Integer = Nothing

            Try

                InvoiceNumber = GridView.GetRowCellValue(RowHandle, "InvoiceNumber")

            Catch ex As Exception
                InvoiceNumber = Nothing
            End Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExpenseReportItems = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False).ToList _
                                     .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReportItem(Entity, Me.Session.User.EmployeeCode, DbContext)).ToList

            End Using

            LoadDetailLevel = ExpenseReportItems

        End Function
        Private Sub LoadDetailViews()

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewForm_ExpenseReports.CurrentView.BeginUpdate()

            _GridViewExpenseReportDetails = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewForm_ExpenseReports.GridControl.LevelTree.Nodes.Add("ExpenseItems", _GridViewExpenseReportDetails)

            _GridViewExpenseReportDetails.LevelIndent = 1

            _GridViewExpenseReportDetails.ChildGridLevelName = "ExpenseItems"
            _GridViewExpenseReportDetails.GridControl = DataGridViewForm_ExpenseReports.GridControl
            _GridViewExpenseReportDetails.Name = "_GridViewExpenseReportDetails"

            _GridViewExpenseReportDetails.Session = Me.Session

            _GridViewExpenseReportDetails.ControlType = WinForm.Presentation.Controls.DataGridView.Type.EditableGrid

            _GridViewExpenseReportDetails.ObjectType = GetType(AdvantageFramework.Database.Classes.ExpenseReportItem)

            _GridViewExpenseReportDetails.OptionsDetail.ShowDetailTabs = False
            _GridViewExpenseReportDetails.OptionsSelection.MultiSelect = False
            _GridViewExpenseReportDetails.OptionsView.ShowViewCaption = False

            _GridViewExpenseReportDetails.CreateColumnsBasedOnObjectType(True)

            _GridViewExpenseReportDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewExpenseReportDetails.OptionsView.ShowFooter = False

            For Each GridColumn In _GridViewExpenseReportDetails.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                Try

                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Classes.ExpenseReportItem)).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = GridColumn.FieldName).SingleOrDefault

                    If PropertyDescriptor IsNot Nothing Then

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PayableAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.VisibleIndex = _GridViewExpenseReportDetails.Columns("Amount").VisibleIndex + 1

                        Else

                            GridColumn.Visible = EntityAttribute.ShowColumnInGrid

                        End If

                    Else

                        GridColumn.Visible = False

                    End If

                Catch ex As Exception
                    GridColumn.Visible = False
                End Try

                If GridColumn.Visible = False Then

                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.ShowInExpressionEditor = False

                End If

                If GridColumn.ColumnEdit IsNot Nothing Then

                    GridColumn.ColumnEdit.ReadOnly = True

                End If

                GridColumn.OptionsColumn.AllowEdit = False

            Next

            DataGridViewForm_ExpenseReports.CurrentView.EndUpdate()

        End Sub
        Private Function IsPendingApprovalInAccounting(ByVal RowHandle As Integer) As Boolean

            'objects
            Dim ExpenseSummary As AdvantageFramework.Database.Views.ExpenseSummary = Nothing

            Try

                ExpenseSummary = DirectCast(DataGridViewForm_ExpenseReports.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Views.ExpenseSummary)

            Catch ex As Exception

            End Try

            IsPendingApprovalInAccounting = IsPendingApprovalInAccounting(ExpenseSummary)

        End Function
        Private Function IsPendingApprovalInAccounting(ByVal ExpenseSummary As AdvantageFramework.Database.Views.ExpenseSummary) As Boolean

            'objects
            Dim PendingApprovalInAccounting As Boolean = False

            If ExpenseSummary IsNot Nothing Then

                If ExpenseSummary.Status.GetValueOrDefault(0) = 4 Then

                    PendingApprovalInAccounting = True

                End If

            End If

            IsPendingApprovalInAccounting = PendingApprovalInAccounting

        End Function
        Private Function HasAnySelectedPendingApprovalInAccountingExpenseReports() As Boolean

            'objects
            Dim Selected As Boolean = False

            Try

                Selected = (From Entity In DataGridViewForm_ExpenseReports.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.ExpenseSummary)()
                            Where IsPendingApprovalInAccounting(Entity) = True
                            Select Entity).Any

            Catch ex As Exception
                Selected = False
            Finally
                HasAnySelectedPendingApprovalInAccountingExpenseReports = Selected
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ExpenseApprovalSetupForm As Presentation.ExpenseApprovalSetupForm = Nothing

            ExpenseApprovalSetupForm = New Presentation.ExpenseApprovalSetupForm()

            ExpenseApprovalSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseApprovalSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Collapse.Image = AdvantageFramework.My.Resources.CollapseDetails
            ButtonItemActions_Expand.Image = AdvantageFramework.My.Resources.ExpandDetails

            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.ExpenseReportSearch

            ButtonItemStatus_Denied.Image = AdvantageFramework.My.Resources.ExpenseReportDenied
            ButtonItemStatus_Approved.Image = AdvantageFramework.My.Resources.ExpenseReportApproved
            ButtonItemStatus_Pending.Image = AdvantageFramework.My.Resources.ExpenseReportPending

            CheckBoxSearch_Approved.ByPassUserEntryChanged = True
            CheckBoxSearch_Denied.ByPassUserEntryChanged = True
            CheckBoxSearch_Pending.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Employee.ByPassUserEntryChanged = True
            DateTimePickerSearch_EndDate.ByPassUserEntryChanged = True
            DateTimePickerSearch_StartDate.ByPassUserEntryChanged = True

            SearchableComboBoxViewForm_Employee.IsInGridLookupEditControl = True

            DateTimePickerSearch_EndDate.ReadOnly = True
            DateTimePickerSearch_StartDate.ReadOnly = True

            DateTimePickerSearch_EndDate.ReadOnly = False
            DateTimePickerSearch_StartDate.ReadOnly = False

            DateTimePickerSearch_StartDate.ValueObject = DateSerial(System.DateTime.Today.Year, System.DateTime.Today.Month, 1)
            DateTimePickerSearch_EndDate.ValueObject = DateSerial(System.DateTime.Today.Year, System.DateTime.Today.Month + 1, 0)

            CheckBoxSearch_Approved.BackColor = Drawing.Color.White
            CheckBoxSearch_Denied.BackColor = Drawing.Color.White
            CheckBoxSearch_Pending.BackColor = Drawing.Color.White

            CheckBoxSearch_Denied.Checked = True
            CheckBoxSearch_Pending.Checked = True

            _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts)

            LoadEmployeeVendors()

            LoadDetailViews()

            DataGridViewForm_ExpenseReports.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary))

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ExpenseApprovalSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ExpenseApprovalSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_ExpenseReports.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ExpenseSummaryList As Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary) = Nothing
            Dim Saved As Boolean = True
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_ExpenseReports.HasRows Then

                DataGridViewForm_ExpenseReports.CurrentView.CloseEditorForUpdating()

                ExpenseSummaryList = DataGridViewForm_ExpenseReports.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.ExpenseSummary)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ExpenseSummary In ExpenseSummaryList

                            If AdvantageFramework.Database.Procedures.ExpenseSummary.Update(DbContext, ExpenseSummary, Me.Session.User.EmployeeCode) = False Then

                                ErrorMessage = "One or more records failed to save."
                                Saved = False

                            End If

                        Next

                    End Using

                Catch ex As Exception
                    ErrorMessage = "There was a problem saving. Please contact software support."
                    Saved = False
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                Me.CloseWaitForm()

                If Saved Then

                    LoadGrid()

                Else

                    If String.IsNullOrEmpty(ErrorMessage) = False Then

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_ExpenseReports.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.IsApproved.ToString Then

                If IsPendingApprovalInAccounting(DataGridViewForm_ExpenseReports.CurrentView.GetRowHandle(e.ListSourceRowIndex)) Then

                    e.DisplayText = "Pending Approval in Accounting"

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowGetRelationDisplayCaptionEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            Try

                BaseView = DataGridViewForm_ExpenseReports.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            Catch ex As Exception
                BaseView = Nothing
            End Try

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Expense Report Item(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Expense Report Item(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_RowDoubleClickEvent() Handles DataGridViewForm_ExpenseReports.RowDoubleClickEvent

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If _HasAccessToDocuments Then

                If DataGridViewForm_ExpenseReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.DocumentCount.ToString Then

                    If DataGridViewForm_ExpenseReports.CurrentView.FocusedValue > 0 Then

                        DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts)

                        DocumentLevelSetting.ExpenseReportInvoiceNumber = DataGridViewForm_ExpenseReports.CurrentView.GetRowCellValue(DataGridViewForm_ExpenseReports.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ExpenseSummary.Properties.InvoiceNumber.ToString)

                        AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm.ShowFormDialog(Database.Entities.DocumentLevel.ExpenseReceipts, DocumentLevelSetting, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default, False, True, False)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_ExpenseReports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            LoadGrid()

        End Sub
        Private Sub CheckBoxSearch_Approved_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSearch_Approved.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxSearch_Denied_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSearch_Denied.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxSearch_Pending_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSearch_Pending.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_ExpenseReports.ShowingEditorEvent

            If DataGridViewForm_ExpenseReports.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Views.ExpenseSummary.Properties.ApproverNotes.ToString AndAlso _
                DataGridViewForm_ExpenseReports.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Views.ExpenseSummary.Properties.IsApproved.ToString AndAlso _
                DataGridViewForm_ExpenseReports.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Views.ExpenseSummary.Properties.DetailDescription.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_ExpenseReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.IsApproved.ToString Then

                e.Cancel = IsPendingApprovalInAccounting(DataGridViewForm_ExpenseReports.CurrentView.FocusedRowHandle)

            End If

        End Sub
        Private Sub ButtonItemActions_Expand_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Expand.Click

            Try

                DataGridViewForm_ExpenseReports.CurrentView.BeginUpdate()

                For RowHandle = 0 To DataGridViewForm_ExpenseReports.CurrentView.RowCount - 1

                    DataGridViewForm_ExpenseReports.CurrentView.ExpandMasterRow(RowHandle)

                Next

            Catch ex As Exception

            Finally
                DataGridViewForm_ExpenseReports.CurrentView.EndUpdate()
            End Try

        End Sub
        Private Sub ButtonItemActions_Collapse_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Collapse.Click

            Try

                DataGridViewForm_ExpenseReports.CurrentView.BeginUpdate()

                DataGridViewForm_ExpenseReports.CurrentView.CollapseAllDetails()

            Catch ex As Exception

            Finally
                DataGridViewForm_ExpenseReports.CurrentView.EndUpdate()
            End Try

        End Sub
        Private Sub ButtonItemStatus_Approved_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemStatus_Approved.Click

            UpdateApprovedFlag(ExpenseReports.ApprovedFlag.Approved)

        End Sub
        Private Sub ButtonItemStatus_Denied_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemStatus_Denied.Click

            UpdateApprovedFlag(ExpenseReports.ApprovedFlag.Denied)

        End Sub
        Private Sub ButtonItemStatus_Pending_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemStatus_Pending.Click

            UpdateApprovedFlag(ExpenseReports.ApprovedFlag.Pending)

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            Try

                BaseView = DataGridViewForm_ExpenseReports.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            Catch ex As Exception
                BaseView = Nothing
            End Try

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "ExpenseItems" Then

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowGetChildListEvent

            e.ChildList = LoadDetailLevel(e.RowHandle, DataGridViewForm_ExpenseReports.CurrentView)

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_ExpenseReports.MasterRowGetRelationNameEvent

            If e.RelationIndex = 0 Then

                e.RelationName = "ExpenseItems"

            End If

        End Sub
        Private Sub _GridViewExpenseReportDetails_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles _GridViewExpenseReportDetails.RowClick

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing

            If _HasAccessToDocuments Then

                If e.Clicks = 2 Then

                    GridView = DataGridViewForm_ExpenseReports.CurrentView.GetDetailView(DataGridViewForm_ExpenseReports.CurrentView.FocusedRowHandle, 0)

                    If GridView IsNot Nothing Then

                        If GridView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.HasDocuments.ToString Then

                            If GridView.FocusedValue = True Then

                                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                                DocumentLevelSetting.ExpenseReportInvoiceNumber = GridView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.InvoiceNumber.ToString)
                                DocumentLevelSetting.ExpenseDetailID = GridView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ID.ToString)

                                AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm.ShowFormDialog(Database.Entities.DocumentLevel.ExpenseReceipts, DocumentLevelSetting, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.ExpenseDetailDocument, False, True, False)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
