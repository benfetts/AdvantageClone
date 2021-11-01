Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeGenerationWizardDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Offset As Integer = 0
        Private _JobComponentServiceFeeContractList As Dictionary(Of Integer, Date()) = Nothing
        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedClientCodes As String()
            Get
                SelectedClientCodes = DataGridViewSelectClients_Clients.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray()
            End Get
        End Property
        Private ReadOnly Property SelectedFunctionCodes As String()
            Get
                SelectedFunctionCodes = DataGridViewSelectFunctions_Functions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray()
            End Get
        End Property
        Private ReadOnly Property SelectedServiceFeeTypeIDs As Integer()
            Get
                SelectedServiceFeeTypeIDs = DataGridViewSelectFeeTypes_FeeTypes.GetAllSelectedRowsCellValues(0).OfType(Of Integer).ToArray
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            DataGridViewSelectClients_Clients.MultiSelect = True
            DataGridViewSelectFeeTypes_FeeTypes.MultiSelect = True
            DataGridViewSelectFunctions_Functions.MultiSelect = True

            DataGridViewSelectClients_Clients.ShowSelectDeselectAllButtons = True
            DataGridViewSelectFeeTypes_FeeTypes.ShowSelectDeselectAllButtons = True
            DataGridViewSelectFunctions_Functions.ShowSelectDeselectAllButtons = True

            DateTimePickerSetDateRange_From.SetRequired(True)
            DateTimePickerSetDateRange_To.SetRequired(True)

        End Sub
        Private Sub LoadPage(ByVal Page As DevExpress.XtraWizard.WizardPage)

            If Page Is Nothing Then

                For Each Page In WizardControlForm_Wizard.Pages

                    Page.Tag = False

                Next

                Page = WizardPageWizard_SelectClients

            End If

            If Page.Tag = False OrElse Page Is WizardPageWizard_Review Then

                If Page Is WizardPageWizard_SelectClients Then

                    LoadSelectClientsPage()

                ElseIf Page Is WizardPageWizard_SelectFeeTypes Then

                    LoadSelectFeeTypesPage()

                ElseIf Page Is WizardPageWizard_SelectFunctions Then

                    LoadSelectFunctionsPage()

                ElseIf Page Is WizardPageWizard_Review Then

                    LoadReviewPage()

                End If

                Page.Tag = True

            End If

        End Sub
        Private Sub LoadSelectClientsPage()

            'objects
            Dim ClientCodes As String() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCodes = (From Entity In LoadContracts(DbContext)
                                   Select Entity.ClientCode).Distinct.ToArray

                    DataGridViewSelectClients_Clients.ItemDescription = "Active Client(s)"

                    DataGridViewSelectClients_Clients.DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                                   Where Entity.IsActive = 1 AndAlso
                                                                         ClientCodes.Contains(Entity.Code)
                                                                   Select Entity

                    DataGridViewSelectClients_Clients.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectFeeTypesPage()

            'objects
            Dim ServiceFeeTypes As Generic.List(Of AdvantageFramework.Database.Entities.ServiceFeeType) = Nothing
            Dim ServiceFeeTypeIDs As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ServiceFeeTypeIDs = (From Entity In LoadContracts(DbContext, Me.SelectedClientCodes)
                                     Select Entity.ServiceFeeTypeID.GetValueOrDefault(-1)).Distinct.ToArray

                ServiceFeeTypes = (From Entity In AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext)
                                   Where ServiceFeeTypeIDs.Contains(Entity.ID)
                                   Select Entity).ToList

                If ServiceFeeTypeIDs.Contains(-1) Then

                    ServiceFeeTypes.Add(New AdvantageFramework.Database.Entities.ServiceFeeType() With {.ID = -1, .Code = "", .Description = "[None]", .IsInactive = False})

                End If

                DataGridViewSelectFeeTypes_FeeTypes.ItemDescription = "Active Service Fee Type(s)"

                DataGridViewSelectFeeTypes_FeeTypes.DataSource = ServiceFeeTypes.OrderBy(Function(Fee) Fee.Code).ToList

                DataGridViewSelectFeeTypes_FeeTypes.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectFunctionsPage()

            Dim FunctionCodes As String() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                FunctionCodes = (From Entity In LoadContracts(DbContext, Me.SelectedClientCodes, Me.SelectedServiceFeeTypeIDs)
                                 Select Entity.FunctionCode).Distinct.ToArray

                DataGridViewSelectFunctions_Functions.ItemDescription = "Active Function(s)"

                DataGridViewSelectFunctions_Functions.DataSource = From Entity In AdvantageFramework.Database.Procedures.FunctionView.LoadAllActive(DbContext)
                                                                   Where Entity.Type = "I" AndAlso
                                                                         FunctionCodes.Contains(Entity.Code)
                                                                   Select Entity

                DataGridViewSelectFunctions_Functions.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadReviewPage()

            'objects
            Dim TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim Clients As Generic.List(Of String) = Nothing
            Dim Functions As Generic.List(Of String) = Nothing
            Dim FeeTypes As Generic.List(Of String) = Nothing
            Dim FeeType As String = Nothing

            Clients = New Generic.List(Of String)

            For Each SelectedRowHandle In DataGridViewSelectClients_Clients.CurrentView.GetSelectedRows

                Clients.Add(DataGridViewSelectClients_Clients.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.Client.Properties.Code.ToString) & " - " &
                            DataGridViewSelectClients_Clients.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.Client.Properties.Name.ToString))

            Next

            Functions = New Generic.List(Of String)

            For Each SelectedRowHandle In DataGridViewSelectFunctions_Functions.CurrentView.GetSelectedRows

                Functions.Add(DataGridViewSelectFunctions_Functions.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.Function.Properties.Code.ToString) & " - " &
                              DataGridViewSelectFunctions_Functions.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.Function.Properties.Description.ToString))

            Next

            FeeTypes = New Generic.List(Of String)

            For Each SelectedRowHandle In DataGridViewSelectFeeTypes_FeeTypes.CurrentView.GetSelectedRows

                FeeType = Nothing

                If DataGridViewSelectFeeTypes_FeeTypes.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.ServiceFeeType.Properties.Code.ToString) <> "" Then

                    FeeType = DataGridViewSelectFeeTypes_FeeTypes.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.ServiceFeeType.Properties.Code.ToString) & " - "

                    FeeType &= DataGridViewSelectFeeTypes_FeeTypes.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.ServiceFeeType.Properties.Description.ToString)

                    FeeTypes.Add(FeeType)

                End If

            Next

            LabelReview_DateRange.Text = String.Format("From {0} to {1}", DateTimePickerSetDateRange_From.Value.ToShortDateString, DateTimePickerSetDateRange_To.Value.ToShortDateString)

            TreeListControlReview_ClientsFunctionsServiceFeeTypes.Nodes.Clear()
            TreeListControlReview_ClientsFunctionsServiceFeeTypes.Columns.Clear()

            TreeListControlReview_ClientsFunctionsServiceFeeTypes.BeginUpdate()

            TreeListControlReview_ClientsFunctionsServiceFeeTypes.OptionsView.ShowColumns = False

            TreeListColumn = TreeListControlReview_ClientsFunctionsServiceFeeTypes.Columns.AddField("Code")

            TreeListColumn.Visible = True

            TreeListNode = AddNode(Nothing, Clients.Count.ToString & " Client(s)")

            For Each ClientCode In Clients

                AddNode(TreeListNode, ClientCode)

            Next

            TreeListNode = AddNode(Nothing, FeeTypes.Count.ToString & " Service Fee Type(s)")

            For Each FeeTypeCode In FeeTypes

                AddNode(TreeListNode, FeeTypeCode)

            Next

            TreeListNode = AddNode(Nothing, Functions.Count.ToString & " Function(s)")

            For Each FunctionCode In Functions

                AddNode(TreeListNode, FunctionCode)

            Next

            TreeListControlReview_ClientsFunctionsServiceFeeTypes.EndUpdate()

        End Sub
        Private Function AddNode(ByVal ParentTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal NodeText As String) As DevExpress.XtraTreeList.Nodes.TreeListNode

            'objects
            Dim TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            Try

                If ParentTreeListNode Is Nothing Then

                    TreeListNode = TreeListControlReview_ClientsFunctionsServiceFeeTypes.AppendNode(Nothing, ParentTreeListNode)

                Else

                    TreeListNode = ParentTreeListNode.Nodes.Add()

                End If

                If TreeListNode IsNot Nothing Then

                    TreeListNode.Item("Code") = NodeText

                End If

            Catch ex As Exception
                TreeListNode = Nothing
            Finally
                AddNode = TreeListNode
            End Try

        End Function
        Private Sub GeneratingFeeProgressUpdate(ByVal ProgressValue As Integer)

            _BackgroundWorker.ReportProgress(ProgressValue)
            _BackgroundWorker.ReportProgress(ProgressValue + _Offset, "Overall")

        End Sub
        Private Sub SetupGeneratingFeeProgress(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

            ProgressBarGeneratingFees_FeeProgress.SetMinimum(MinValue)
            ProgressBarGeneratingFees_FeeProgress.SetMaximum(MaxValue)
            ProgressBarGeneratingFees_FeeProgress.SetValue(Value)

        End Sub
        Private Function LoadContracts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       Optional ByVal ClientCodes As String() = Nothing,
                                       Optional ByVal ServiceFeeTypeIDs As Integer() = Nothing,
                                       Optional ByVal FunctionCodes As String() = Nothing) As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

            'objects
            Dim JobComponentServiceFeeContracts As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing

            Try

                JobComponentServiceFeeContracts = AdvantageFramework.IncomeOnly.LoadContracts(DbContext)

                If ClientCodes IsNot Nothing Then

                    JobComponentServiceFeeContracts = (From Entity In JobComponentServiceFeeContracts
                                                       Where ClientCodes.Contains(Entity.ClientCode)
                                                       Select Entity).ToList

                End If

                If FunctionCodes IsNot Nothing Then

                    JobComponentServiceFeeContracts = (From Entity In JobComponentServiceFeeContracts
                                                       Where FunctionCodes.Contains(Entity.FunctionCode)
                                                       Select Entity).ToList

                End If

                If ServiceFeeTypeIDs IsNot Nothing Then

                    JobComponentServiceFeeContracts = (From Entity In JobComponentServiceFeeContracts
                                                       Where ServiceFeeTypeIDs.Contains(Entity.ServiceFeeTypeID.GetValueOrDefault(-1))
                                                       Select Entity).ToList

                End If

            Catch ex As Exception
                JobComponentServiceFeeContracts = Nothing
            Finally
                LoadContracts = JobComponentServiceFeeContracts
            End Try

        End Function
        Private Function SearchForContracts() As Boolean

            'objects
            Dim ContractsFound As Boolean = False
            Dim SearchForEmptyServiceFeeTypes As Boolean = False
            Dim SelectedFeeTypes As Integer() = Nothing
            Dim SelectedFunctions As String() = Nothing
            Dim SelectedClients As String() = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim InvoiceDates As Generic.List(Of Date) = Nothing
            Dim JobComponentServiceFeeContracts As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing

            Me.ShowWaitForm("Searching for contracts...")

            Try

                StartDate = DateTimePickerSetDateRange_From.Value
                EndDate = DateTimePickerSetDateRange_To.Value

                _JobComponentServiceFeeContractList = New Dictionary(Of Integer, Date())

                _JobComponentServiceFeeContractList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        JobComponentServiceFeeContracts = (From Entity In LoadContracts(DbContext, Me.SelectedClientCodes, Me.SelectedServiceFeeTypeIDs, Me.SelectedFunctionCodes)
                                                           Where Entity.MissingRecords > 0 AndAlso
                                                                 StartDate <= Entity.FeeEndDate AndAlso
                                                                 EndDate >= Entity.FeeStartDate
                                                           Select Entity).ToList

                    Catch ex As Exception
                        JobComponentServiceFeeContracts = Nothing
                    End Try

                    If JobComponentServiceFeeContracts IsNot Nothing AndAlso JobComponentServiceFeeContracts.Count > 0 Then

                        InvoiceDates = New List(Of Date)

                        For Each JobComponentServiceFeeContract In JobComponentServiceFeeContracts

                            InvoiceDates.Clear()

                            For Each ServiceFee In (From Entity In AdvantageFramework.IncomeOnly.LoadServiceFeeContractFees(DbContext, JobComponentServiceFeeContract.ID, True)
                                                    Where Entity.Created = False AndAlso
                                                          Entity.InvoiceDate >= StartDate AndAlso
                                                          Entity.InvoiceDate <= EndDate
                                                    Select Entity).ToList

                                InvoiceDates.Add(ServiceFee.InvoiceDate)

                            Next

                            If InvoiceDates IsNot Nothing AndAlso InvoiceDates.Count > 0 Then

                                _JobComponentServiceFeeContractList.Add(JobComponentServiceFeeContract.ID, InvoiceDates.ToArray)

                            End If

                        Next

                    End If

                End Using

                If _JobComponentServiceFeeContractList IsNot Nothing AndAlso _JobComponentServiceFeeContractList.Count > 0 Then

                    ContractsFound = True

                End If

            Catch ex As Exception
                ContractsFound = False
            Finally
                Me.CloseWaitForm()
                SearchForContracts = ContractsFound
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeGenerationWizardDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeGenerationWizardDialog = Nothing

            ServiceFeeGenerationWizardDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeGenerationWizardDialog()

            ShowFormDialog = ServiceFeeGenerationWizardDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeGenerationWizardDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.IncomeOnly.GeneratingFeeProgressUpdateEvent, AddressOf GeneratingFeeProgressUpdate
            RemoveHandler AdvantageFramework.IncomeOnly.SetupGeneratingFeeProgressEvent, AddressOf SetupGeneratingFeeProgress

        End Sub
        Private Sub ServiceFeeGenerationWizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            Me.ByPassUserEntryChanged = True

            LoadPage(WizardPageWizard_SelectClients)

            AddHandler AdvantageFramework.IncomeOnly.GeneratingFeeProgressUpdateEvent, AddressOf GeneratingFeeProgressUpdate
            AddHandler AdvantageFramework.IncomeOnly.SetupGeneratingFeeProgressEvent, AddressOf SetupGeneratingFeeProgress

            DateTimePickerSetDateRange_From.ValueObject = Nothing
            DateTimePickerSetDateRange_To.ValueObject = Nothing

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the Service Fee Generation wizard.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewSelectClients_Clients_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectClients_Clients.DataSourceChangedEvent

            DataGridViewSelectClients_Clients.HideOrShowColumn(AdvantageFramework.Database.Entities.Client.Properties.IsNewBusiness.ToString, False)
            DataGridViewSelectClients_Clients.MakeIsInactiveColumnNotVisible()

        End Sub
        Private Sub DataGridViewSelectFeeTypes_FeeTypes_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectFeeTypes_FeeTypes.DataSourceChangedEvent

            DataGridViewSelectFeeTypes_FeeTypes.MakeIsInactiveColumnNotVisible()

        End Sub
        Private Sub DataGridViewSelectFunctions_Functions_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectFunctions_Functions.DataSourceChangedEvent

            DataGridViewSelectFunctions_Functions.MakeIsInactiveColumnNotVisible()

        End Sub
        Private Sub DataGridViewSelectClients_Clients_RowDoubleClickEvent() Handles DataGridViewSelectClients_Clients.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub DataGridViewSelectFeeTypes_FeeTypes_RowDoubleClickEvent() Handles DataGridViewSelectFeeTypes_FeeTypes.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub DataGridViewSelectFunctions_Functions_RowDoubleClickEvent() Handles DataGridViewSelectFunctions_Functions.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            'objects
            Dim Close As Boolean = True

            If Close Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_NextClick(sender As Object, e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            Dim CanContinue As Boolean = True
            Dim Message As String = ""

            If e.Page Is WizardPageWizard_SelectClients Then

                If DataGridViewSelectClients_Clients.HasASelectedRow = False Then

                    CanContinue = False
                    Message = "Please select atleast one Client to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_SelectFeeTypes Then

                If DataGridViewSelectFeeTypes_FeeTypes.HasASelectedRow = False Then

                    CanContinue = False
                    Message = "Please select atleast one Fee Type to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_SelectFunctions Then

                If DataGridViewSelectFunctions_Functions.HasASelectedRow = False Then

                    CanContinue = False
                    Message = "Please select atleast one Function to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_SetDateRange Then

                If Me.Validator = False Then

                    CanContinue = False

                End If

            End If

            If String.IsNullOrWhiteSpace(Message) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(sender As Object, e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            If e.Page Is WizardPageWizard_GeneratingFees Then

                WizardPageWizard_GeneratingFees.AllowNext = False

                _BackgroundWorker = New System.ComponentModel.BackgroundWorker

                _BackgroundWorker.WorkerReportsProgress = True

                _BackgroundWorker.RunWorkerAsync()

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanging(sender As Object, e As DevExpress.XtraWizard.WizardPageChangingEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanging

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                e.Page.Tag = False

                If TypeOf e.Page Is DevExpress.XtraWizard.WizardPage Then

                    If e.Page Is WizardPageWizard_GeneratingFees Then

                        If Not SearchForContracts() Then

                            e.Cancel = True

                            AdvantageFramework.Navigation.ShowMessageBox("No service fee contracts with missing fees were found.")

                        End If

                    End If

                    If e.Cancel = False Then

                        LoadPage(e.Page)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectClients_Clients_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectClients_Clients.ShowingEditorEvent

            e.Cancel = True

        End Sub
        Private Sub _BackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            'objects
            Dim Generated As Boolean = False
            Dim TotalCreated As Integer = 0
            Dim JobComponentServiceFeeContractID As Integer = Nothing
            Dim InvoiceDates As Date() = Nothing

            Try

                If _JobComponentServiceFeeContractList IsNot Nothing AndAlso _JobComponentServiceFeeContractList.Count > 0 Then

                    ProgressBarGeneratingFees_OverallProgress.SetMinimum(0)
                    ProgressBarGeneratingFees_OverallProgress.SetMaximum(_JobComponentServiceFeeContractList.Select(Function(SvcContract) SvcContract.Value.Count).Sum)
                    ProgressBarGeneratingFees_OverallProgress.SetValue(0)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each KeyValue In _JobComponentServiceFeeContractList

                            JobComponentServiceFeeContractID = KeyValue.Key
                            InvoiceDates = KeyValue.Value

                            _BackgroundWorker.ReportProgress(0, String.Format("Generating {0} fee(s)...", InvoiceDates.Count))

                            AdvantageFramework.IncomeOnly.CreateFromServiceFee(Me.Session, JobComponentServiceFeeContractID, InvoiceDates, TotalCreated)

                            _Offset = TotalCreated

                        Next

                        Generated = True 'executed w/o errors

                    End Using

                End If

            Catch ex As Exception
                Generated = False
                TotalCreated = 0
            End Try

            e.Cancel = Not Generated
            e.Result = TotalCreated

        End Sub
        Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

            If e.UserState = "Overall" Then

                ProgressBarGeneratingFees_OverallProgress.Value = e.ProgressPercentage

            Else

                ProgressBarGeneratingFees_FeeProgress.Value = e.ProgressPercentage

                If e.UserState IsNot Nothing AndAlso TypeOf e.UserState Is String Then

                    LabelGeneratingFees_GeneratingFees.Text = e.UserState

                End If

            End If

        End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            'objects
            Dim ImportTemplateID As Integer = Nothing
            Dim Imported As Boolean = False
            Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
            Dim GeneratingStatus As String = ""

            If e.Cancelled Then

                GeneratingStatus = "Generating Fee(s) Failed... Click Next to continue..."

            Else

                If CInt(e.Result) > 0 Then

                    GeneratingStatus = "Generating Fee(s) Completed... Click Next to continue..."

                Else

                    GeneratingStatus = "No Service Fee(s) could be generated from the current criteria... Click Next to continue..."

                End If

            End If

            LabelGeneratingFees_GeneratingFees.Text = GeneratingStatus

            WizardPageWizard_GeneratingFees.AllowNext = True

        End Sub
        Private Sub ButtonSetDateRange_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetDateRange_YTD.Click

			DateTimePickerSetDateRange_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerSetDateRange_To.Value = Now

        End Sub
        Private Sub ButtonSetDateRange_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetDateRange_MTD.Click

			DateTimePickerSetDateRange_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerSetDateRange_To.Value = Now

        End Sub
        Private Sub ButtonSetDateRange_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetDateRange_1Year.Click

            DateTimePickerSetDateRange_From.Value = Now.AddYears(-1)
            DateTimePickerSetDateRange_To.Value = Now

        End Sub
        Private Sub ButtonSetDateRange_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSetDateRange_2Years.Click

            DateTimePickerSetDateRange_From.Value = Now.AddYears(-2)
            DateTimePickerSetDateRange_To.Value = Now

        End Sub
        Private Sub TreeListControlReview_ClientsFunctionsServiceFeeTypes_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles TreeListControlReview_ClientsFunctionsServiceFeeTypes.NodeCellStyle

            If e.Node.Level = 0 Then

                e.Appearance.Font = New Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
