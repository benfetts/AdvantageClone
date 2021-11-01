Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeContractDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _ServiceFeeContractID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Integer = Nothing
        Private _ContractOrFeesAdded As Boolean = False
        Private _IsAdding As Boolean = False
        Private _IsCopy As Boolean = False
        Private _ChangesMade As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ServiceFeeContractID As Integer
            Get
                ServiceFeeContractID = _ServiceFeeContractID
            End Get
        End Property
        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Private ReadOnly Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        Private ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Private ReadOnly Property JobComponentNumber As Integer
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal IsAdding As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _IsAdding = IsAdding

        End Sub
        Private Sub New(ByVal ServiceFeeContractID As Integer, ByVal IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ServiceFeeContractID = ServiceFeeContractID
            _IsCopy = IsCopy

        End Sub
        Private Function CreateFees() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Created As Boolean = False
            Dim ServiceFeeInvoice As AdvantageFramework.Database.Entities.ServiceFeeInvoice = Nothing
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing
            Dim FunctionCode As String = Nothing
            Dim DateList As Generic.List(Of Date) = Nothing

            Try

                'If DataGridViewServiceFees_ServiceFees.HasASelectedRow Then

                '    DateList = New Generic.List(Of Date)

                '    For Each RowHandle In DataGridViewServiceFees_ServiceFees.CurrentView.GetSelectedRows

                '        DateList.Add(CDate(DataGridViewServiceFees_ServiceFees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ServiceFee.Properties.InvoiceDate.ToString)))

                '    Next

                '    Created = ServiceFeeContractControlForm_Contracts.SaveJobServiceFee(DateList.ToArray)

                'Else

                '    ErrorMessage = "Please select at least one service fee."

                'End If

            Catch ex As Exception
                Created = False
            Finally

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

                CreateFees = Created

            End Try

        End Function
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = Nothing

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = ServiceFeeContractControlForm_Contracts.Save(ErrorMessage)

                        Catch ex As Exception
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

            If IsOkay Then

                Me.ClearChanged()

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            SearchableComboBoxForm_Division.Enabled = SearchableComboBoxForm_Client.HasASelectedValue
            SearchableComboBoxForm_Product.Enabled = SearchableComboBoxForm_Division.HasASelectedValue AndAlso SearchableComboBoxForm_Client.HasASelectedValue

            If ServiceFeeContractControlForm_Contracts.Enabled Then

                If ButtonItemActions_Add.Visible Then

                    ButtonItemActions_Add.Enabled = ServiceFeeContractControlForm_Contracts.DetailsDataGridView.HasRows AndAlso Not ServiceFeeContractControlForm_Contracts.DetailsDataGridView.IsNewItemRow

                End If

                ButtonItemContracts_Delete.Enabled = ServiceFeeContractControlForm_Contracts.DetailsDataGridView.HasASelectedRow
                ButtonItemContracts_Cancel.Enabled = ServiceFeeContractControlForm_Contracts.DetailsDataGridView.IsNewItemRow
                ButtonItemContracts_Copy.Enabled = ServiceFeeContractControlForm_Contracts.DetailsDataGridView.HasOnlyOneSelectedRow

                ButtonItemServiceFees_View.Enabled = ServiceFeeContractControlForm_Contracts.CanViewOrGenerateFees
                ButtonItemServiceFees_Generate.Enabled = ServiceFeeContractControlForm_Contracts.CanViewOrGenerateFees

                SearchableComboBoxForm_ServiceFeeType.Enabled = True
                CheckBoxForm_ServiceFeeJob.Enabled = True

            Else

                ButtonItemActions_Add.Enabled = False

                ButtonItemContracts_Delete.Enabled = False
                ButtonItemContracts_Cancel.Enabled = False
                ButtonItemContracts_Copy.Enabled = False

                ButtonItemServiceFees_View.Enabled = False
                ButtonItemServiceFees_Generate.Enabled = False

                SearchableComboBoxForm_ServiceFeeType.Enabled = False
                CheckBoxForm_ServiceFeeJob.Enabled = False

            End If

        End Sub
        Private Sub LoadControl()

            Try

                ServiceFeeContractControlForm_Contracts.ClearControl()
                ServiceFeeContractControlForm_Contracts.Enabled = False

                If _ServiceFeeContractID > 0 Then

                    ServiceFeeContractControlForm_Contracts.Enabled = True
                    ServiceFeeContractControlForm_Contracts.LoadControl(_ServiceFeeContractID, IsCopy:=_IsCopy)

                ElseIf CdpJobCompFilterForm_Filter.JobNumber.GetValueOrDefault(0) > 0 AndAlso CdpJobCompFilterForm_Filter.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    ServiceFeeContractControlForm_Contracts.Enabled = True
                    ServiceFeeContractControlForm_Contracts.LoadControl(Nothing, CdpJobCompFilterForm_Filter.ClientCode, CdpJobCompFilterForm_Filter.DivisionCode, CdpJobCompFilterForm_Filter.ProductCode, CdpJobCompFilterForm_Filter.JobNumber, CdpJobCompFilterForm_Filter.JobComponentNumber, False, _IsAdding)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadSelectedJobComponent()

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ServiceFeeJob As Boolean = False
            Dim AccountExecutiveCode As String = Nothing
            Dim ServiceFeeType As Integer? = Nothing

            Try

                If CdpJobCompFilterForm_Filter.JobNumber.GetValueOrDefault(0) > 0 AndAlso CdpJobCompFilterForm_Filter.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, CdpJobCompFilterForm_Filter.JobNumber, CdpJobCompFilterForm_Filter.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            AccountExecutiveCode = JobComponent.AccountExecutiveEmployeeCode
                            ServiceFeeType = JobComponent.ServiceFeeTypeID
                            ServiceFeeJob = CBool(JobComponent.ServiceFeeFlag.GetValueOrDefault(0))

                        End If

                    End Using

                End If

            Catch ex As Exception
                AccountExecutiveCode = Nothing
                ServiceFeeType = Nothing
                ServiceFeeJob = False
            End Try

            SearchableComboBoxForm_AccountExecutive.SelectedValue = AccountExecutiveCode

            If ServiceFeeType.HasValue Then

                SearchableComboBoxForm_ServiceFeeType.SelectedValue = CInt(ServiceFeeType.Value)

            Else

                SearchableComboBoxForm_ServiceFeeType.SelectedValue = Nothing

            End If

            CheckBoxForm_ServiceFeeJob.Checked = ServiceFeeJob

        End Sub
        Private Sub LoadSelectedJob()

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            Try

                SearchableComboBoxForm_SalesClass.SelectedValue = Nothing
                SearchableComboBoxForm_Office.SelectedValue = Nothing
                SearchableComboBoxForm_AccountExecutive.SelectedValue = Nothing
                SearchableComboBoxForm_ServiceFeeType.SelectedValue = Nothing

                If CdpJobCompFilterForm_Filter.JobNumber.GetValueOrDefault(0) > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, CdpJobCompFilterForm_Filter.JobNumber)

                        If Job IsNot Nothing Then

                            SearchableComboBoxForm_SalesClass.SelectedValue = Job.SalesClassCode
                            SearchableComboBoxForm_Office.SelectedValue = Job.OfficeCode

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                              Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber As Integer = 0,
                                              Optional ByVal JobComponentNumber As Integer = 0, Optional ByVal IsAdding As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeContractDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog = Nothing

            ServiceFeeContractDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog(ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, IsAdding)

            ShowFormDialog = ServiceFeeContractDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(ByRef ServiceFeeContractID As Integer, ByVal IsCopy As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeContractDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog = Nothing

            ServiceFeeContractDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog(ServiceFeeContractID, IsCopy)

            ShowFormDialog = ServiceFeeContractDialog.ShowDialog()

            ServiceFeeContractID = ServiceFeeContractDialog.ServiceFeeContractID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeContractDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If _ContractOrFeesAdded OrElse _ChangesMade Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub ServiceFeeContractDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim JobNumbers As Integer() = Nothing
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim AllowAdd As Boolean = False
            Dim AllowUpdate As Boolean = False
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Short? = Nothing

            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage

            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemContracts_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemServiceFees_View.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemServiceFees_Generate.Image = AdvantageFramework.My.Resources.FlagAsServiceFeeImage

            ButtonItemActions_Add.SecurityEnabled = ServiceFeeContractControlForm_Contracts.SecurityAddAllowed
            ButtonItemContracts_Delete.SecurityEnabled = ServiceFeeContractControlForm_Contracts.SecurityUpdateAllowed
            ButtonItemContracts_Copy.SecurityEnabled = ServiceFeeContractControlForm_Contracts.SecurityAddAllowed
            ButtonItemServiceFees_Generate.SecurityEnabled = ServiceFeeContractControlForm_Contracts.SecurityGenerateFeesAllowed

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SearchableComboBoxForm_AccountExecutive.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                    SearchableComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session)
                    SearchableComboBoxForm_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext)
                    SearchableComboBoxForm_ServiceFeeType.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext)

                    If _ServiceFeeContractID > 0 Then

                        JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, _ServiceFeeContractID)

                        If JobServiceFee IsNot Nothing Then

                            JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber)

                            If JobComponentView IsNot Nothing Then

                                _ClientCode = JobComponentView.ClientCode
                                _DivisionCode = JobComponentView.DivisionCode
                                _ProductCode = JobComponentView.ProductCode
                                _JobNumber = JobComponentView.JobNumber
                                _JobComponentNumber = JobComponentView.JobComponentNumber

                            End If

                        End If

                    End If

                    SearchableComboBoxForm_Client.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_Division.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_Product.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_Job.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_Component.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_AccountExecutive.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_Office.ByPassUserEntryChanged = True
                    SearchableComboBoxForm_SalesClass.ByPassUserEntryChanged = True

                    SearchableComboBoxForm_ServiceFeeType.HideValueMemberColumn = True

                    SearchableComboBoxForm_Job.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
                    SearchableComboBoxForm_Component.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

                    SearchableComboBoxForm_AccountExecutive.Enabled = False
                    SearchableComboBoxForm_Office.Enabled = False
                    SearchableComboBoxForm_SalesClass.Enabled = False

                    SearchableComboBoxForm_Job.SetRequired(True)
                    SearchableComboBoxForm_Component.SetRequired(True)

                    CdpJobCompFilterForm_Filter.SetSession(Me.Session)
                    CdpJobCompFilterForm_Filter.ClientDisplayControl = SearchableComboBoxForm_Client
                    CdpJobCompFilterForm_Filter.DivisionDisplayControl = SearchableComboBoxForm_Division
                    CdpJobCompFilterForm_Filter.ProductDisplayControl = SearchableComboBoxForm_Product
                    CdpJobCompFilterForm_Filter.JobDisplayControl = SearchableComboBoxForm_Job
                    CdpJobCompFilterForm_Filter.JobComponentDisplayControl = SearchableComboBoxForm_Component

                    CdpJobCompFilterForm_Filter.ClientSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                               Where Entity.IsActive = 1
                                                               Select Entity

                    CdpJobCompFilterForm_Filter.DivisionSource = From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                                 Where Entity.IsActive = 1
                                                                 Select Entity

                    CdpJobCompFilterForm_Filter.ProductSource = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, True)

                    CdpJobCompFilterForm_Filter.JobSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, Me.Session.UserCode)

                    CdpJobCompFilterForm_Filter.JobComponentSource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, Me.Session.UserCode)

                    CdpJobCompFilterForm_Filter.InitializeDataControls()

                End Using

            End Using

            If _JobNumber > 0 Then

                JobNumber = _JobNumber

                If _JobComponentNumber > 0 Then

                    JobComponentNumber = _JobComponentNumber

                End If

            End If

            CdpJobCompFilterForm_Filter.SetInitialValues(_ClientCode, _DivisionCode, _ProductCode, JobNumber, JobComponentNumber)

            If _IsCopy = False Then

                SearchableComboBoxForm_Client.SecurityEnabled = String.IsNullOrWhiteSpace(_ClientCode)
                SearchableComboBoxForm_Division.SecurityEnabled = String.IsNullOrWhiteSpace(_DivisionCode)
                SearchableComboBoxForm_Product.SecurityEnabled = String.IsNullOrWhiteSpace(_ProductCode)
                SearchableComboBoxForm_Job.SecurityEnabled = Not _JobNumber > 0
                SearchableComboBoxForm_Component.SecurityEnabled = Not _JobComponentNumber > 0

                If _ServiceFeeContractID > 0 Then

                    ButtonItemActions_Save.Visible = True
                    ButtonItemActions_Add.Visible = False

                Else

                    ButtonItemActions_Save.Visible = False
                    ButtonItemActions_Add.Visible = True

                End If

                RibbonBarOptions_Contracts.Visible = True
                RibbonBarOptions_Fees.Visible = Not _IsAdding

            Else

                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Add.Visible = True
                RibbonBarOptions_Contracts.Visible = False
                RibbonBarOptions_Fees.Visible = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Actions)

            Try

                LoadSelectedJob()

            Catch ex As Exception

            End Try

            Try

                LoadSelectedJobComponent()

            Catch ex As Exception

            End Try

            Try

                LoadControl()

            Catch ex As Exception

            End Try

            ServiceFeeContractControlForm_Contracts.ShowAdditionalJobDataInGrid = False

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the Service Fee Generation wizard.")
                Me.Close()

            End If

        End Sub
        Private Sub ServiceFeeContractDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ServiceFeeContractDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ContinueSave As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, CdpJobCompFilterForm_Filter.JobNumber, CdpJobCompFilterForm_Filter.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            JobComponent.ServiceFeeFlag = If(CheckBoxForm_ServiceFeeJob.Checked, 1, 0)

                            If SearchableComboBoxForm_ServiceFeeType.HasASelectedValue Then

                                JobComponent.ServiceFeeTypeID = CInt(SearchableComboBoxForm_ServiceFeeType.GetSelectedValue)

                            Else

                                JobComponent.ServiceFeeTypeID = Nothing

                            End If

                            ContinueSave = AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                        End If

                    End Using

                    If ContinueSave Then

                        _ChangesMade = True

                        If ServiceFeeContractControlForm_Contracts.Save(ErrorMessage) Then

                            Me.ClearChanged()

                            'Me.DialogResult = Windows.Forms.DialogResult.OK
                            'Me.Close()

                        End If

                    Else

                        ErrorMessage = "There was a problem saving the job component."

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ContinueAdd As Boolean = False
            Dim ContractID As Integer = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, CdpJobCompFilterForm_Filter.JobNumber, CdpJobCompFilterForm_Filter.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            JobComponent.ServiceFeeFlag = If(CheckBoxForm_ServiceFeeJob.Checked, 1, 0)

                            If SearchableComboBoxForm_ServiceFeeType.HasASelectedValue Then

                                JobComponent.ServiceFeeTypeID = CInt(SearchableComboBoxForm_ServiceFeeType.GetSelectedValue)

                            Else

                                JobComponent.ServiceFeeTypeID = Nothing

                            End If

                            ContinueAdd = AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                        End If

                    End Using

                    If ContinueAdd Then

                        If _IsCopy Then

                            If ServiceFeeContractControlForm_Contracts.CopySelectedContract(ContractID, JobComponent.JobNumber, JobComponent.Number) Then

                                Me.ClearChanged()

                                _ServiceFeeContractID = ContractID

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        Else

                            If ServiceFeeContractControlForm_Contracts.Add() Then

                                Me.ClearChanged()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        End If

                    Else

                        If _IsCopy Then

                            ErrorMessage = "There was a problem copying the contract."

                        Else

                            ErrorMessage = "There was a problem adding the contract(s)."

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            'objects
            Dim ContinueDelete As Boolean = True

            If _IsAdding = False Then

                ContinueDelete = CheckForUnsavedChanges()

            End If

            If ContinueDelete Then

                ServiceFeeContractControlForm_Contracts.DeleteContract()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemServiceFees_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemServiceFees_Generate.Click

            If CheckForUnsavedChanges() Then

                ServiceFeeContractControlForm_Contracts.GenerateFees(True)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemServiceFees_View_Click(sender As Object, e As EventArgs) Handles ButtonItemServiceFees_View.Click

            If CheckForUnsavedChanges() Then

                ServiceFeeContractControlForm_Contracts.GenerateFees(False)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Cancel.Click

            ServiceFeeContractControlForm_Contracts.Cancel()

            EnableOrDisableActions()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ClientChangedEvent() Handles CdpJobCompFilterForm_Filter.ClientChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadControl()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ClientChangingEvent(ByRef Cancel As Boolean) Handles CdpJobCompFilterForm_Filter.ClientChangingEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_DivisionChangedEvent() Handles CdpJobCompFilterForm_Filter.DivisionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadControl()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_DivisionChangingEvent(ByRef Cancel As Boolean) Handles CdpJobCompFilterForm_Filter.DivisionChangingEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_JobChangingEvent(ByRef Cancel As Boolean) Handles CdpJobCompFilterForm_Filter.JobChangingEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ComponentChangingEvent(ByRef Cancel As Boolean) Handles CdpJobCompFilterForm_Filter.ComponentChangingEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ProductChangedEvent() Handles CdpJobCompFilterForm_Filter.ProductChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadControl()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ProductChangingEvent(ByRef Cancel As Boolean) Handles CdpJobCompFilterForm_Filter.ProductChangingEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_JobChangedEvent() Handles CdpJobCompFilterForm_Filter.JobChangedEvent

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    LoadSelectedJob()

                Catch ex As Exception

                End Try

                Try

                    LoadSelectedJobComponent()

                Catch ex As Exception

                End Try

                If _IsCopy = False Then

                    Try

                        LoadControl()

                    Catch ex As Exception

                    End Try

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CdpJobCompFilterForm_Filter_ComponentChangedEvent() Handles CdpJobCompFilterForm_Filter.ComponentChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    LoadSelectedJobComponent()

                Catch ex As Exception

                End Try

                If _IsCopy = False Then

                    Try

                        LoadControl()

                    Catch ex As Exception

                    End Try

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ServiceFeeContractControlForm_Contracts_ContractAddedEvent() Handles ServiceFeeContractControlForm_Contracts.ContractAddedEvent

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing

            SearchableComboBoxForm_Client.SecurityEnabled = False
            SearchableComboBoxForm_Division.SecurityEnabled = False
            SearchableComboBoxForm_Product.SecurityEnabled = False
            SearchableComboBoxForm_Job.SecurityEnabled = False
            SearchableComboBoxForm_Component.SecurityEnabled = False

            _ContractOrFeesAdded = True

            CheckBoxForm_ServiceFeeJob.Checked = True

        End Sub
        Private Sub ServiceFeeContractControlForm_Contracts_SelectedContractChanged() Handles ServiceFeeContractControlForm_Contracts.SelectedContractChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_ServiceFeeJob_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_ServiceFeeJob.CheckedChangedEx

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    JobNumber = CdpJobCompFilterForm_Filter.JobNumber
                    JobComponentNumber = CdpJobCompFilterForm_Filter.JobComponentNumber

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        JobComponent.ServiceFeeFlag = If(e.NewChecked.Checked, 1, 0)

                        AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click1(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            'objects
            Dim ContinueCopy As Boolean = True

            If _IsAdding = False Then

                ContinueCopy = CheckForUnsavedChanges()

            End If

            If ContinueCopy Then

                ServiceFeeContractControlForm_Contracts.CopySelectedContract()

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
