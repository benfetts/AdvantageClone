Namespace Billing.Presentation

    Public Class TransferAllItemsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
        Private _AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
        Private _IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
        Private _MultipleJobsSelected As Boolean = False
        Private _ShowTransferFunctionTo As Boolean = False
        Private _BillingCommandCenterID As Integer = Nothing
        Private _BillingUser As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem),
                        ByVal AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem),
                        ByVal IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem),
                        ByVal ShowTransferFunctionTo As Boolean, ByVal MultipleJobsSelected As Boolean, ByVal BillingCommandCenterID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _EmployeeTimeItemList = EmployeeTimeItemList
            _AccountPayableProductionItemList = AccountPayableProductionItemList
            _IncomeOnlyItemList = IncomeOnlyItemList

            _MultipleJobsSelected = MultipleJobsSelected
            _ShowTransferFunctionTo = ShowTransferFunctionTo
            _BillingCommandCenterID = BillingCommandCenterID

            SearchableComboBoxTransferTo_Job.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_JobComponent.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_Function.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            SearchableComboBoxTransferTo_GLAccount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxTransferTo_PostPeriod.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

        End Sub
        Private Function TransferAllItems(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Transferred As Boolean = False
            Dim TransferEmployeeTimeBillingRate As AdvantageFramework.BillingCommandCenter.TransferEmployeeTimeBillingRate = BillingCommandCenter.TransferEmployeeTimeBillingRate.RecalculateFromHierarchy
            Dim TransferMarkupPercent As AdvantageFramework.BillingCommandCenter.TransferMarkupPercent = BillingCommandCenter.TransferMarkupPercent.RecalculateFromHierarchy
            Dim FunctionCode As String = Nothing
            Dim AgencyInvoiceTaxFlag As Boolean = False
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If RadioButtonTime_TransferAsIs.Checked Then

                TransferEmployeeTimeBillingRate = AdvantageFramework.BillingCommandCenter.TransferEmployeeTimeBillingRate.TransferAsIs

            End If

            If RadioButtonMarkup_TransferAsIs.Checked Then

                TransferMarkupPercent = AdvantageFramework.BillingCommandCenter.TransferMarkupPercent.TransferAsIs

            End If

            If SearchableComboBoxTransferTo_Function.Visible AndAlso SearchableComboBoxTransferTo_Function.HasASelectedValue Then

                FunctionCode = SearchableComboBoxTransferTo_Function.GetSelectedValue

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue)

                If JobComponent IsNot Nothing AndAlso JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 1 Then

                    AdvantageFramework.WinForm.MessageBox.Show("Cannot transfer to a job that is reconciled and not billed.")
                    SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing
                    SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

                Else

                    Try

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        Me.ShowWaitForm("Processing...")

                        AgencyInvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        If _EmployeeTimeItemList IsNot Nothing Then

                            For Each EmployeeTimeItem In _EmployeeTimeItemList

                                AdvantageFramework.BillingCommandCenter.TransferEmployeeTime(DbContext, _BillingCommandCenterID, EmployeeTimeItem, SearchableComboBoxTransferTo_Client.GetSelectedValue, SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                                                                             SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, FunctionCode, AgencyInvoiceTaxFlag, TransferEmployeeTimeBillingRate, TransferMarkupPercent, TransferToTaskCode:=SearchableComboBoxTransferTo_Task.GetSelectedValue)

                            Next

                        End If

                        If _AccountPayableProductionItemList IsNot Nothing Then

                            For Each VendorAccountPayableProduction In _AccountPayableProductionItemList

                                AdvantageFramework.BillingCommandCenter.TransferAP(Session, DbContext, _BillingCommandCenterID, VendorAccountPayableProduction, SearchableComboBoxTransferTo_Client.GetSelectedValue, SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                                                                   SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, FunctionCode,
                                                                                   SearchableComboBoxTransferTo_GLAccount.GetSelectedValue, SearchableComboBoxTransferTo_PostPeriod.GetSelectedValue, AgencyInvoiceTaxFlag, TransferMarkupPercent)

                            Next

                        End If

                        If _IncomeOnlyItemList IsNot Nothing Then

                            For Each IncomeOnlyItem In _IncomeOnlyItemList

                                AdvantageFramework.BillingCommandCenter.TransferIncomeOnly(DbContext, _BillingCommandCenterID, IncomeOnlyItem, SearchableComboBoxTransferTo_Client.GetSelectedValue, SearchableComboBoxTransferTo_Division.GetSelectedValue, SearchableComboBoxTransferTo_Product.GetSelectedValue,
                                                                                           SearchableComboBoxTransferTo_Job.GetSelectedValue, SearchableComboBoxTransferTo_JobComponent.GetSelectedValue, FunctionCode, AgencyInvoiceTaxFlag, TransferMarkupPercent)

                            Next

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET ADJUSTMENTS = 1 WHERE BILLING_USER = '{0}'", DbContext.UserCode))

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_LOG SET CL_CODE = RTRIM(CL_CODE), DIV_CODE = RTRIM(DIV_CODE), PRD_CODE = RTRIM(PRD_CODE) WHERE JOB_NUMBER = {0}", JobComponent.JobNumber))

                        DbTransaction.Commit()

                        Transferred = True

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message
                    Finally

                        If DbContext.Database.Connection.State = ConnectionState.Open Then

                            DbContext.Database.Connection.Close()

                        End If

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        Me.CloseWaitForm()

                    End Try

                End If

            End Using

            TransferAllItems = Transferred

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeTimeItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem),
                                              ByVal AccountPayableProductionItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem),
                                              ByVal IncomeOnlyItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem),
                                              ByVal ShowTransferFunctionTo As Boolean, ByVal MultipleJobsSelected As Boolean, ByVal BillingCommandCenterID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim TransferAllItemsDialog As AdvantageFramework.Billing.Presentation.TransferAllItemsDialog = Nothing

            TransferAllItemsDialog = New AdvantageFramework.Billing.Presentation.TransferAllItemsDialog(EmployeeTimeItemList, AccountPayableProductionItemList, IncomeOnlyItemList, ShowTransferFunctionTo, MultipleJobsSelected, BillingCommandCenterID)

            ShowFormDialog = TransferAllItemsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TransferAllItemsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim AllActiveAPPostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim CurrentAPPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            SearchableComboBoxTransferTo_Job.SetRequired(True)
            SearchableComboBoxTransferTo_JobComponent.SetRequired(True)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        _BillingUser = BillingCommandCenter.BillingUser

                    End If

                End Using

                If _MultipleJobsSelected Then

                    SearchableComboBoxTransferFrom_Job.Text = "Multi"
                    SearchableComboBoxTransferFrom_JobComponent.Text = "Multi"

                Else

                    If _EmployeeTimeItemList IsNot Nothing AndAlso _EmployeeTimeItemList.Count > 0 Then

                        JobNumber = _EmployeeTimeItemList.First.JobNumber
                        JobComponentNumber = _EmployeeTimeItemList.First.JobComponentNumber

                    ElseIf _AccountPayableProductionItemList IsNot Nothing AndAlso _AccountPayableProductionItemList.Count > 0 Then

                        JobNumber = _AccountPayableProductionItemList.First.JobNumber
                        JobComponentNumber = _AccountPayableProductionItemList.First.JobComponentNumber

                    ElseIf _IncomeOnlyItemList IsNot Nothing AndAlso _IncomeOnlyItemList.Count > 0 Then

                        JobNumber = _IncomeOnlyItemList.First.JobNumber
                        JobComponentNumber = _IncomeOnlyItemList.First.JobComponentNumber

                    End If

                    SearchableComboBoxTransferFrom_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                    SearchableComboBoxTransferFrom_Job.SelectedValue = JobNumber

                    SearchableComboBoxTransferFrom_JobComponent.DataSource = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)
                    SearchableComboBoxTransferFrom_JobComponent.SelectedValue = JobComponentNumber

                End If

                SearchableComboBoxTransferTo_Client.DataSource = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

                If _AccountPayableProductionItemList IsNot Nothing AndAlso _AccountPayableProductionItemList.Count > 0 Then

                    AllActiveAPPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext).ToList
                    SearchableComboBoxTransferTo_PostPeriod.DataSource = AllActiveAPPostPeriods

                    CurrentAPPostPeriod = AllActiveAPPostPeriods.Where(Function(PP) PP.APStatus = "C").FirstOrDefault

                    If CurrentAPPostPeriod IsNot Nothing Then

                        SearchableComboBoxTransferTo_PostPeriod.SelectedValue = CurrentAPPostPeriod.Code

                    End If

                    SearchableComboBoxTransferTo_GLAccount.SetRequired(True)
                    SearchableComboBoxTransferTo_PostPeriod.SetRequired(True)

                Else

                    GroupBoxForm_APSpecific.Enabled = False

                End If

                If _EmployeeTimeItemList Is Nothing OrElse _EmployeeTimeItemList.Count = 0 Then

                    GroupBoxForm_EmployeeTimeBillingRate.Enabled = False

                End If

                If _ShowTransferFunctionTo AndAlso Not _MultipleJobsSelected Then

                    LabelTransferTo_Function.Visible = True
                    SearchableComboBoxTransferTo_Function.Visible = True

                    If _EmployeeTimeItemList IsNot Nothing AndAlso _EmployeeTimeItemList.Count > 0 Then

                        SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "E" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0))
                        SearchableComboBoxTransferTo_Function.SelectedValue = _EmployeeTimeItemList.FirstOrDefault.FunctionCode

                        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TS_TASK_ONLY.ToString)

                            If Setting IsNot Nothing Then

                                LabelTransferTo_TaskCode.Visible = CBool(Setting.Value)
                                SearchableComboBoxTransferTo_Task.Visible = CBool(Setting.Value)

                                If CBool(Setting.Value) Then

                                    SearchableComboBoxTransferTo_Task.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext).ToList
                                    SearchableComboBoxTransferTo_Task.SelectedValue = Nothing
                                    SearchableComboBoxTransferTo_Task.Properties.ReadOnly = False

                                End If

                            End If

                        End Using

                    ElseIf _AccountPayableProductionItemList IsNot Nothing AndAlso _AccountPayableProductionItemList.Count > 0 Then

                        SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "V" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0))
                        SearchableComboBoxTransferTo_Function.SelectedValue = _AccountPayableProductionItemList.FirstOrDefault.FunctionCode

                    ElseIf _IncomeOnlyItemList IsNot Nothing AndAlso _IncomeOnlyItemList.Count > 0 Then

                        SearchableComboBoxTransferTo_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).Where(Function(Entity) Entity.Type = "I" AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0))
                        SearchableComboBoxTransferTo_Function.SelectedValue = _IncomeOnlyItemList.FirstOrDefault.FunctionCode

                    End If

                    SearchableComboBoxTransferTo_Function.SetRequired(True)

                Else

                    LabelTransferTo_Function.Visible = False
                    SearchableComboBoxTransferTo_Function.Visible = False

                End If

            End Using

            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If TransferAllItems(ErrorMessage) Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

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
        Private Sub SearchableComboBoxTransferTo_JobComponent_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_JobComponent.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If SearchableComboBoxTransferTo_Job.HasASelectedValue AndAlso SearchableComboBoxTransferTo_JobComponent.HasASelectedValue Then

                JobNumber = SearchableComboBoxTransferTo_Job.GetSelectedValue()
                JobComponentNumber = SearchableComboBoxTransferTo_JobComponent.GetSelectedValue()

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        If _AccountPayableProductionItemList IsNot Nothing Then

                            SearchableComboBoxTransferTo_GLAccount.DataSource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, JobComponent.Job.OfficeCode, Session)
                            SearchableComboBoxTransferTo_GLAccount.SelectedValue = Nothing
                            SearchableComboBoxTransferTo_GLAccount.Properties.ReadOnly = False

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_JobComponent_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_JobComponent.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Database.Entities.JobComponent.Properties.JobNumber.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Database.Entities.JobComponent.Properties.JobNumber.ToString).Visible = False
                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.OptionsFind.FindFilterColumns = AdvantageFramework.Database.Entities.JobComponent.Properties.Number.ToString

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_JobComponent_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_JobComponent.QueryPopupNeedDataSource

            'objects
            Dim JobNumber As Integer = 0

            If SearchableComboBoxTransferTo_Job.HasASelectedValue Then

                JobNumber = SearchableComboBoxTransferTo_Job.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_JobComponent.DataSource = (From JC In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                                            Where JC.JobNumber = JobNumber AndAlso
                                                                                  (JC.IsAdvanceBilling Is Nothing OrElse JC.IsAdvanceBilling = 0 OrElse JC.IsAdvanceBilling = 2) AndAlso
                                                                                  (JC.BillingUserCode Is Nothing OrElse JC.BillingUserCode = _BillingUser)
                                                                            Select JC).ToList

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Division.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product) = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Client.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Division.HasASelectedValue Then

                ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue.ToString.Trim
                DivisionCode = SearchableComboBoxTransferTo_Division.GetSelectedValue.ToString.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Products = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                Select Entity).ToList

                    SearchableComboBoxTransferTo_Product.DataSource = Products

                    If Products.Count = 1 Then

                        SearchableComboBoxTransferTo_Product.SelectedValue = Products(0).Code.Trim

                    Else

                        SearchableComboBoxTransferTo_Product.SelectedValue = Nothing

                    End If

                End Using

            Else

                SearchableComboBoxTransferTo_Product.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Division_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Division.QueryPopupNeedDataSource

            If SearchableComboBoxTransferTo_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, SearchableComboBoxTransferTo_Client.GetSelectedValue).ToList

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Product.EditValueChanged

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Product.EditValue Is Nothing Then

                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Product_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Product.QueryPopupNeedDataSource

            If SearchableComboBoxTransferTo_Client.HasASelectedValue AndAlso SearchableComboBoxTransferTo_Division.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxTransferTo_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, SearchableComboBoxTransferTo_Client.SelectedValue, SearchableComboBoxTransferTo_Division.SelectedValue)

                End Using

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Job.EditValueChanged

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            If SearchableComboBoxTransferTo_Job.HasASelectedValue Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, SearchableComboBoxTransferTo_Job.GetSelectedValue)

                    If Job IsNot Nothing Then

                        JobComponents = Job.JobComponents.Where(Function(Entity) Entity.JobProcessNumber <> 6 AndAlso Entity.JobProcessNumber <> 12 AndAlso
                                                    (Entity.IsAdvanceBilling Is Nothing OrElse Entity.IsAdvanceBilling = 0 OrElse Entity.IsAdvanceBilling = 2) AndAlso
                                                    (Entity.BillingUserCode Is Nothing OrElse Entity.BillingUserCode = _BillingUser)).ToList

                        SearchableComboBoxTransferTo_JobComponent.DataSource = JobComponents

                        If JobComponents.Count = 1 Then

                            SearchableComboBoxTransferTo_JobComponent.SelectedValue = JobComponents(0).Number

                        End If

                        SearchableComboBoxTransferTo_Client.SelectedValue = Job.ClientCode.Trim
                        SearchableComboBoxTransferTo_Division.SelectedValue = Job.DivisionCode.Trim
                        SearchableComboBoxTransferTo_Product.SelectedValue = Job.ProductCode.Trim

                    End If

                End Using

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles SearchableComboBoxTransferTo_Job.MouseDown

            SearchableComboBoxTransferTo_Job.DataSource = Nothing

        End Sub
        Private Sub SearchableComboBoxTransferTo_Job_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxTransferTo_Job.QueryPopupNeedDataSource

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue
            DivisionCode = SearchableComboBoxTransferTo_Division.GetSelectedValue
            ProductCode = SearchableComboBoxTransferTo_Product.GetSelectedValue

            SearchableComboBoxTransferTo_Job.DataSource = AdvantageFramework.Billing.Presentation.GetTransferToJobList(Session, _BillingUser, ClientCode, DivisionCode, ProductCode)

        End Sub
        Private Sub SearchableComboBoxTransferTo_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxTransferTo_Client.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division) = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.LoadingSelectedItem Then

                SearchableComboBoxTransferTo_Job.DataSource = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing

                SearchableComboBoxTransferTo_JobComponent.DataSource = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing

            End If

            If SearchableComboBoxTransferTo_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxTransferTo_Client.GetSelectedValue.ToString.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Divisions = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode)
                                 Select Entity).ToList

                    SearchableComboBoxTransferTo_Division.DataSource = Divisions

                    If Divisions.Count = 1 Then

                        SearchableComboBoxTransferTo_Division.SelectedValue = Divisions(0).Code.Trim

                    Else

                        SearchableComboBoxTransferTo_Division.SelectedValue = Nothing

                    End If

                End Using

            Else

                SearchableComboBoxTransferTo_Division.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Product.SelectedValue = Nothing
                SearchableComboBoxTransferTo_Job.SelectedValue = Nothing
                SearchableComboBoxTransferTo_JobComponent.SelectedValue = Nothing

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace