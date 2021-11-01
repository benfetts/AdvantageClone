Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderDetailCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PONumber As Integer = Nothing
        Private _EmployeeCode As String = ""
        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PONumber As Integer
            Get
                PONumber = _PONumber
            End Get
        End Property
        Private ReadOnly Property EmployeeCode As Integer
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PONumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _PONumber = PONumber

        End Sub
        Private Sub LoadPage(ByVal Page As DevExpress.XtraWizard.WizardPage)

            If Page Is WizardPageWizard_SelectPO Then

                LoadSelectPOPage()

            ElseIf Page Is WizardPageWizard_SelectDetails Then

                LoadSelectPODetailsPage()

            ElseIf Page Is WizardPageWizard_UpdateJobInfo Then

                LoadUpdatePODetailsPage()

            End If

        End Sub
        Private Sub LoadSelectPOPage()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectPO_PurchaseOrders.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(DbContext, Me.Session.UserCode, False, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                                                                  Where Entity.Number <> _PONumber
                                                                  Select Entity)

                DataGridViewSelectPO_PurchaseOrders.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectPODetailsPage()

            'objects
            Dim PONumber As Integer = Nothing

            If DataGridViewSelectPO_PurchaseOrders.HasOnlyOneSelectedRow Then

                PONumber = CInt(DataGridViewSelectPO_PurchaseOrders.GetFirstSelectedRowBookmarkValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewSelectPODetails_Details.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC [dbo].[advsp_load_po_details] {0}", PONumber)).ToList

                End Using

                DataGridViewSelectPODetails_Details.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadUpdatePODetailsPage()

            'objects
            Dim PurchaseOrderDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)
            Dim AllowedProcessControlNumbers As Integer() = {1, 3, 4, 8, 9}
            Dim ClearJob As Boolean = False

            If DataGridViewSelectPODetails_Details.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PurchaseOrderDetailList = DataGridViewSelectPODetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail).ToList

                    For Each PurchaseOrderDetail In PurchaseOrderDetailList

                        ClearJob = False

                        If CheckBoxSelectDetails_ExcludeJobAndComponent.Checked Then

                            ClearJob = True

                        ElseIf PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                            If (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                Where Entity.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                                      Entity.Number = PurchaseOrderDetail.JobComponentNumber AndAlso
                                      AllowedProcessControlNumbers.Contains(Entity.JobProcessNumber)
                                Select Entity).Any = False Then

                                ClearJob = True

                            End If

                        End If

                        If ClearJob Then

                            PurchaseOrderDetail.ClientCode = Nothing
                            PurchaseOrderDetail.ClientName = Nothing
                            PurchaseOrderDetail.DivisionCode = Nothing
                            PurchaseOrderDetail.DivisionName = Nothing
                            PurchaseOrderDetail.ProductCode = Nothing
                            PurchaseOrderDetail.ProductDescription = Nothing
                            PurchaseOrderDetail.JobNumber = Nothing
                            PurchaseOrderDetail.JobDescription = Nothing
                            PurchaseOrderDetail.JobComponentNumber = Nothing
                            PurchaseOrderDetail.JobComponentID = Nothing
                            PurchaseOrderDetail.JobComponentDescription = Nothing

                        End If

                    Next

                End Using

                DataGridViewUpdateJobInfo_Details.DataSource = PurchaseOrderDetailList
                DataGridViewUpdateJobInfo_Details.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Function LoadEmployeeAccess() As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)

            Dim EmployeeUserCodes As String() = Nothing
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            If _EmployeeCode IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, _EmployeeCode)
                                             Select Entity.UserCode).ToArray

                    Catch ex As Exception
                        EmployeeUserCodes = Nothing
                    End Try

                    If EmployeeUserCodes IsNot Nothing Then

                        Try

                            UserClientDivisionProductAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext).ToList

                            UserClientDivisionProductAccessList = (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
                                                                   Where EmployeeUserCodes.Contains(Entity.UserCode)
                                                                   Select Entity).ToList

                        Catch ex As Exception
                            UserClientDivisionProductAccessList = Nothing
                        End Try

                    End If

                End Using

            End If

            LoadEmployeeAccess = UserClientDivisionProductAccessList

        End Function
        Private Sub CopyItems()

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            If _PONumber > 0 Then

                DataGridViewUpdateJobInfo_Details.CurrentView.CloseEditorForUpdating()

                DataGridViewUpdateJobInfo_Details.CurrentView.ValidateAllRows()

                If DataGridViewUpdateJobInfo_Details.HasAnyInvalidRows Then

                    AdvantageFramework.Navigation.ShowMessageBox("Please fix invalid row(s).")

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each PurchaseOrderDetailToCopy In DataGridViewUpdateJobInfo_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()

                            PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                            PurchaseOrderDetail.DbContext = DbContext
                            PurchaseOrderDetail.PurchaseOrderNumber = _PONumber
                            PurchaseOrderDetail.Description = PurchaseOrderDetailToCopy.DetailDescription
                            PurchaseOrderDetail.LineDescription = PurchaseOrderDetailToCopy.LineDescription
                            PurchaseOrderDetail.Instructions = PurchaseOrderDetailToCopy.Instructions
                            PurchaseOrderDetail.Quantity = PurchaseOrderDetailToCopy.Quantity
                            PurchaseOrderDetail.Rate = PurchaseOrderDetailToCopy.Rate
                            PurchaseOrderDetail.ExtendedAmount = PurchaseOrderDetailToCopy.ExtendedAmount
                            PurchaseOrderDetail.TaxPercent = PurchaseOrderDetailToCopy.TaxPercent
                            PurchaseOrderDetail.JobNumber = PurchaseOrderDetailToCopy.JobNumber
                            PurchaseOrderDetail.JobComponentNumber = PurchaseOrderDetailToCopy.JobComponentNumber
                            PurchaseOrderDetail.FunctionCode = PurchaseOrderDetailToCopy.FunctionCode
                            PurchaseOrderDetail.CommissionPercent = PurchaseOrderDetailToCopy.CommissionPercent
                            PurchaseOrderDetail.ExtendedMarkupAmount = PurchaseOrderDetailToCopy.ExtendedMarkupAmount
                            PurchaseOrderDetail.GLACode = PurchaseOrderDetailToCopy.GeneralLedgerCode

                            AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

                        Next

                    End Using

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PONumber As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderDetailCopyDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderDetailCopyDialog = Nothing

            PurchaseOrderDetailCopyDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderDetailCopyDialog(PONumber)

            ShowFormDialog = PurchaseOrderDetailCopyDialog.ShowDialog()

            PONumber = PurchaseOrderDetailCopyDialog.PONumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderDetailCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Loaded As Boolean = True

            DataGridViewSelectPO_PurchaseOrders.MultiSelect = False
            DataGridViewSelectPODetails_Details.MultiSelect = True
            DataGridViewUpdateJobInfo_Details.MultiSelect = True
            DataGridViewUpdateJobInfo_Details.AutoFilterLookupColumns = True

            If _PONumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                    If PurchaseOrder IsNot Nothing Then

                        _EmployeeCode = PurchaseOrder.EmployeeCode

                        LoadPage(WizardPageWizard_SelectPO)

                    Else

                        Loaded = False

                    End If

                End Using

            Else

                Loaded = False

            End If

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the purchase order.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewSelectPODetails_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectPODetails_Details.DataSourceChangedEvent

            If DataGridViewSelectPODetails_Details.Columns.Count > 0 Then

                If DataGridViewSelectPODetails_Details.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString) IsNot Nothing Then

                    DataGridViewSelectPODetails_Details.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                End If

                If DataGridViewSelectPODetails_Details.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString) IsNot Nothing Then

                    DataGridViewSelectPODetails_Details.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                End If

            End If

            If DataGridViewSelectPODetails_Details.HasRows Then

                If (From Entity In DataGridViewSelectPODetails_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                    Where Entity.JobNumber.HasValue = True
                    Select Entity).Any Then

                    PanelSelectDetails_Bottom.Visible = True

                Else

                    PanelSelectDetails_Bottom.Visible = False

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectPODetails_Details_RowDoubleClickEvent() Handles DataGridViewSelectPODetails_Details.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub DataGridViewSelectPODetails_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectPODetails_Details.ShowingEditorEvent

            e.Cancel = True

        End Sub
        Private Sub DataGridViewSelectPODetails_Details_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectPODetails_Details.ShownEditorEvent

            DataGridViewSelectPODetails_Details.CurrentView.CloseEditor()

        End Sub
        Private Sub DataGridViewUpdateJobInfo_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewUpdateJobInfo_Details.QueryPopupNeedDatasourceEvent

            'objects
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim ExcludedJobProcessControlNumbers As Integer() = Nothing
            Dim JobComponentJobNumbers As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

                If FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                    OverrideDefaultDatasource = True

                    JobNumber = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString)
                    ClientCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)

                    If JobNumber IsNot Nothing Then

                        Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)
                                     Where Entity.JobNumber = JobNumber AndAlso
                                           ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False
                                     Select Entity

                    Else

                        UserClientDivisionProductAccessList = LoadEmployeeAccess()

                        JobComponentJobNumbers = (From JC In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)
                                                  Where ExcludedJobProcessControlNumbers.Contains(JC.JobProcessNumber) = False
                                                  Select [JN] = JC.JobNumber).Distinct.ToArray

                        If UserClientDivisionProductAccessList.Any Then

                            JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).ToList
                                          Where Job.IsOpen = 1 AndAlso
                                                UserClientDivisionProductAccessList.Any(Function(UsrAccess) UsrAccess.ClientCode = Job.ClientCode AndAlso
                                                                                                            UsrAccess.DivisionCode = Job.DivisionCode AndAlso
                                                                                                            UsrAccess.ProductCode = Job.ProductCode) AndAlso
                                                JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                                Job.ClientCode = If(ClientCode Is Nothing, Job.ClientCode, ClientCode) AndAlso
                                                Job.DivisionCode = If(DivisionCode Is Nothing, Job.DivisionCode, DivisionCode) AndAlso
                                                Job.ProductCode = If(ProductCode Is Nothing, Job.ProductCode, ProductCode)
                                          Select Job.Number).ToArray

                        Else

                            JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext)
                                          Where Job.IsOpen = 1 AndAlso
                                                JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                                Job.ClientCode = If(ClientCode Is Nothing, Job.ClientCode, ClientCode) AndAlso
                                                Job.DivisionCode = If(DivisionCode Is Nothing, Job.DivisionCode, DivisionCode) AndAlso
                                                Job.ProductCode = If(ProductCode Is Nothing, Job.ProductCode, ProductCode)
                                          Select Job.Number).ToArray

                        End If

                        Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)
                                     Where JobNumbers.Contains(Entity.JobNumber) AndAlso
                                           ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False
                                     Select Entity

                    End If

                ElseIf FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString Then

                    OverrideDefaultDatasource = True

                    ClientCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewUpdateJobInfo_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)

                    UserClientDivisionProductAccessList = LoadEmployeeAccess()

                    JobComponentJobNumbers = (From JC In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)
                                              Where ExcludedJobProcessControlNumbers.Contains(JC.JobProcessNumber) = False
                                              Select [JN] = JC.JobNumber).Distinct.ToArray

                    If UserClientDivisionProductAccessList.Any Then

                        Datasource = From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).ToList
                                     Where Job.IsOpen = 1 AndAlso
                                           UserClientDivisionProductAccessList _
                                           .Any(Function(UsrAccess) UsrAccess.ClientCode = Job.ClientCode AndAlso
                                                                    UsrAccess.DivisionCode = Job.DivisionCode AndAlso
                                                                    UsrAccess.ProductCode = Job.ProductCode) AndAlso
                                            JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                            Job.ClientCode = If(ClientCode Is Nothing, Job.ClientCode, ClientCode) AndAlso
                                            Job.DivisionCode = If(DivisionCode Is Nothing, Job.DivisionCode, DivisionCode) AndAlso
                                            Job.ProductCode = If(ProductCode Is Nothing, Job.ProductCode, ProductCode)
                                     Select Job

                    Else

                        Datasource = From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext)
                                     Where Job.IsOpen = 1 AndAlso
                                           JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                           Job.ClientCode = If(ClientCode Is Nothing, Job.ClientCode, ClientCode) AndAlso
                                           Job.DivisionCode = If(DivisionCode Is Nothing, Job.DivisionCode, DivisionCode) AndAlso
                                           Job.ProductCode = If(ProductCode Is Nothing, Job.ProductCode, ProductCode)
                                     Select Job

                    End If

                End If

                If OverrideDefaultDatasource AndAlso Datasource IsNot Nothing Then

                    Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                End If

            End Using

        End Sub
        Private Sub DataGridViewUpdateJobInfo_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewUpdateJobInfo_Details.ShowingEditorEvent

            'objects
            Dim FieldName As String = Nothing

            FieldName = DataGridViewUpdateJobInfo_Details.CurrentView.FocusedColumn.FieldName

            If FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                e.Cancel = False

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewUpdateJobInfo_Details_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewUpdateJobInfo_Details.ShownEditorEvent

            'objects
            Dim FieldName As String = Nothing
            Dim CloseEditor As Boolean = False

            FieldName = DataGridViewUpdateJobInfo_Details.CurrentView.FocusedColumn.FieldName

            If FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                CloseEditor = False

            Else

                CloseEditor = True

            End If

            If CloseEditor Then

                DataGridViewUpdateJobInfo_Details.CurrentView.CloseEditor()

            End If

        End Sub
        Private Sub DataGridViewSelectPO_PurchaseOrders_RowDoubleClickEvent() Handles DataGridViewSelectPO_PurchaseOrders.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub WizardControlForm_Wizard_NextClick(sender As Object, e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            Dim CanContinue As Boolean = True
            Dim Message As String = ""

            If e.Page Is WizardPageWizard_SelectPO Then

                If DataGridViewSelectPO_PurchaseOrders.HasOnlyOneSelectedRow = False Then

                    CanContinue = False
                    Message = "Please select a Purchase Order to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_SelectDetails Then

                If DataGridViewSelectPODetails_Details.HasASelectedRow = False Then

                    CanContinue = False
                    Message = "Please select at lease one Purchase Order detail to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_UpdateJobInfo Then

                DataGridViewUpdateJobInfo_Details.CurrentView.CloseEditorForUpdating()
                DataGridViewUpdateJobInfo_Details.ValidateAllRows()

                If DataGridViewUpdateJobInfo_Details.HasRows = False Then

                    CanContinue = False
                    Message = "Please select at lease one Purchase Order detail to continue."

                ElseIf DataGridViewUpdateJobInfo_Details.HasAnyInvalidRows = True Then

                    CanContinue = False
                    Message = "Please fix invalid row(s)."

                End If

            End If

            If String.IsNullOrWhiteSpace(Message) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(sender As Object, e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If e.Page Is WizardPageWizard_CopyingPage Then

                    WizardPageWizard_CopyingPage.AllowNext = False

                    _BackgroundWorker = New System.ComponentModel.BackgroundWorker

                    _BackgroundWorker.WorkerReportsProgress = True
                    _BackgroundWorker.RunWorkerAsync()

                End If

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanging(sender As Object, e As DevExpress.XtraWizard.WizardPageChangingEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanging

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If TypeOf e.Page Is DevExpress.XtraWizard.WizardPage Then

                    LoadPage(e.Page)

                End If

            End If

        End Sub
        Private Sub _BackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim PurchaseOrderDetailToCopy As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim PurchaseOrderDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
            Dim FailedCounter As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrderDetailList = DataGridViewUpdateJobInfo_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)().ToList

                For I = 1 To PurchaseOrderDetailList.Count

                    PurchaseOrderDetailToCopy = PurchaseOrderDetailList(I - 1)

                    PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                    PurchaseOrderDetail.DbContext = DbContext
                    PurchaseOrderDetail.PurchaseOrderNumber = _PONumber
                    PurchaseOrderDetail.Description = PurchaseOrderDetailToCopy.DetailDescription
                    PurchaseOrderDetail.LineDescription = PurchaseOrderDetailToCopy.LineDescription
                    PurchaseOrderDetail.Instructions = PurchaseOrderDetailToCopy.Instructions
                    PurchaseOrderDetail.Quantity = PurchaseOrderDetailToCopy.Quantity
                    PurchaseOrderDetail.Rate = PurchaseOrderDetailToCopy.Rate
                    PurchaseOrderDetail.ExtendedAmount = PurchaseOrderDetailToCopy.ExtendedAmount
                    PurchaseOrderDetail.TaxPercent = PurchaseOrderDetailToCopy.TaxPercent
                    PurchaseOrderDetail.JobNumber = PurchaseOrderDetailToCopy.JobNumber
                    PurchaseOrderDetail.JobComponentNumber = PurchaseOrderDetailToCopy.JobComponentNumber
                    PurchaseOrderDetail.FunctionCode = PurchaseOrderDetailToCopy.FunctionCode
                    PurchaseOrderDetail.CommissionPercent = PurchaseOrderDetailToCopy.CommissionPercent
                    PurchaseOrderDetail.ExtendedMarkupAmount = PurchaseOrderDetailToCopy.ExtendedMarkupAmount
                    PurchaseOrderDetail.GLACode = PurchaseOrderDetailToCopy.GeneralLedgerCode

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail) = False Then

                        FailedCounter = FailedCounter + 1

                    End If

                    _BackgroundWorker.ReportProgress((I / PurchaseOrderDetailList.Count) * 100)

                Next

            End Using

            If FailedCounter = PurchaseOrderDetailList.Count Then

                e.Cancel = True
                e.Result = FailedCounter

            Else

                e.Cancel = False
                e.Result = FailedCounter

            End If

        End Sub
        Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

            ProgressBarCopyingPage_Progress.Value = e.ProgressPercentage

        End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            'objects
            Dim CopyStatus As String = ""
            Dim FailedCounter As Integer = 0

            If e.Cancelled Then

                CopyStatus = "Copying detail(s) Failed... Click Finish to continue..."

            Else

                FailedCounter = CInt(e.Result)

                If FailedCounter > 0 Then

                    CopyStatus = "Copying detail(s) Completed but with errors... Click Finish to continue..."

                Else

                    CopyStatus = "Copying detail(s) Completed... Click Finish to continue..."

                End If

            End If

            LabelCopyingPage_OverallCopyStatus.Text = CopyStatus

            WizardPageWizard_CopyingPage.AllowNext = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
