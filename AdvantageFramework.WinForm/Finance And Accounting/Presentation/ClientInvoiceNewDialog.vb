Namespace FinanceAndAccounting.Presentation

    Public Class ClientInvoiceNewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BatchDate As Date = Nothing
        Private _ClientCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BatchDate As Date, ByVal ClientCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _BatchDate = BatchDate
            _ClientCode = ClientCode

            For Each SearchableComboBox In Me.PanelForm_Form.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)()

                SearchableComboBox.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Next

            For Each SearchableComboBox In Me.GroupBoxForm_AccountCodes.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)()

                SearchableComboBox.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Next

            For Each NumericInput In Me.GroupBoxPanel_Amounts.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.NumericInput)()

                NumericInput.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Next

        End Sub
        Private Sub LoadAccountReceivableEntity(ByVal AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable)

            If AccountReceivable IsNot Nothing Then

                AccountReceivable.Type = "IN"

                AccountReceivable.ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
                AccountReceivable.DivisionCode = SearchableComboBoxForm_Division.GetSelectedValue
                AccountReceivable.ProductCode = SearchableComboBoxForm_Product.GetSelectedValue
                AccountReceivable.OfficeCode = SearchableComboBoxForm_Office.GetSelectedValue

                AccountReceivable.Description = TextBoxForm_Description.GetText

                AccountReceivable.SalesClassCode = SearchableComboBoxForm_SalesClass.GetSelectedValue
                AccountReceivable.PostPeriodCode = SearchableComboBoxForm_PostPeriod.GetSelectedValue
                AccountReceivable.RecordType = SearchableComboBoxForm_RecordType.GetSelectedValue
                AccountReceivable.InvoiceDate = DateTimePickerForm_InvoiceDate.Value
                AccountReceivable.InvoiceAmount = NumericInputForm_InvoiceAmount.EditValue

                AccountReceivable.GLACodeAR = SearchableComboBoxGroup_ARGLACode.GetSelectedValue
                AccountReceivable.GLACodeSales = SearchableComboBoxGroup_SalesGLACode.GetSelectedValue
                AccountReceivable.CostOfSalesGLACode = SearchableComboBoxGroup_COSGLACode.GetSelectedValue
                AccountReceivable.GLACodeOffset = SearchableComboBoxGroup_OffsetGLACode.GetSelectedValue
                AccountReceivable.GLACodeState = SearchableComboBoxGroup_StateTaxGLACode.GetSelectedValue
                AccountReceivable.GLACodeCounty = SearchableComboBoxGroup_CountyTaxGLACode.GetSelectedValue
                AccountReceivable.GLACodeCity = SearchableComboBoxGroup_CityTaxGLACode.GetSelectedValue

                AccountReceivable.SaleAmount = NumericInputDisbursedTo_Sales.GetValue
                AccountReceivable.CostOfSalesAmount = NumericInputDisbursedTo_COS.GetValue
                AccountReceivable.OffsetAmount = AccountReceivable.CostOfSalesAmount
                AccountReceivable.StateAmount = NumericInputDisbursedTo_State.GetValue
                AccountReceivable.CountyAmount = NumericInputDisbursedTo_County.GetValue
                AccountReceivable.CityAmount = NumericInputDisbursedTo_City.GetValue
                AccountReceivable.CommissionAmount = NumericInputDisbursedTo_GrossProfit.GetValue

                AccountReceivable.EmployeeTime = 0
                AccountReceivable.IOAmount = 0
                AccountReceivable.IsManualInvoice = 1
                AccountReceivable.UserCode = Me.Session.UserCode
                AccountReceivable.CreateDate = Now.ToShortDateString
                AccountReceivable.AdvanceAmount = 0

                If AccountReceivable.RecordType = "P" Then

                    AccountReceivable.InvoiceType = 1

                Else

                    AccountReceivable.InvoiceType = 2

                End If

            End If

        End Sub
        Private Function Insert(ByVal AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable) As Boolean

            Dim ContinueInsert As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsBalanced As Integer = 0
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim Remark As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.AccountPayable.IsDateOutsidePostPeriod(DbContext, AccountReceivable.InvoiceDate, AccountReceivable.PostPeriodCode) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("The invoice date is outside of normal range based on the posting period selected, are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                        ContinueInsert = False
                        DateTimePickerForm_InvoiceDate.Focus()

                    End If

                End If

                If ContinueInsert Then

                    Try

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        AccountReceivable.DbContext = DbContext

                        AdvantageFramework.AccountReceivable.CreateARGeneralLedgerEntries(DbContext, "MI", AccountReceivable, _BatchDate, False)

                        If AdvantageFramework.Database.Procedures.AccountReceivable.Insert(DbContext, AccountReceivable) = False Then

                            Throw New Exception("Insert to ACCT REC failed.")

                        End If

                        GeneralLedger = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedger).Where(Function(GL) GL.Transaction = AccountReceivable.GLTransaction).SingleOrDefault

                        Remark = "Office:" & AccountReceivable.OfficeCode & " " & IIf(AccountReceivable.RecordType = "P", "Prod", "Media") & " Manual Inv:" &
                            AccountReceivable.InvoiceNumber & " - " & AccountReceivable.Description & "  Client:" & AccountReceivable.ClientCode & "-" & AccountReceivable.DivisionCode & "-" & AccountReceivable.ProductCode

                        GeneralLedger.Description = Mid(Remark, 1, 100)

                        DbContext.UpdateObject(GeneralLedger)

                        GeneralLedgerDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail).Where(Function(GLD) GLD.GLTransaction = AccountReceivable.GLTransaction).ToList

                        For Each GeneralLedgerDetail In GeneralLedgerDetails

                            GeneralLedgerDetail.Remark = Mid(Remark, 1, 150)

                            DbContext.UpdateObject(GeneralLedgerDetail)

                        Next

                        DbContext.SaveChanges()

                        IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ar_invoice_balanced] {0},{1},'{2}',{3}", AccountReceivable.InvoiceNumber, AccountReceivable.SequenceNumber, AccountReceivable.Type, AccountReceivable.GLTransaction)).FirstOrDefault

                        If IsBalanced = 1 Then

                            DbTransaction.Commit()
                            Inserted = True

                            AdvantageFramework.WinForm.MessageBox.Show("Invoice '" & AccountReceivable.InvoiceNumber & "' has been added.")

                        Else

                            Throw New Exception("Cannot save.  AR out of balance.")

                        End If
                    Catch ex As Exception

                        DbTransaction.Rollback()
                        ErrorMessage = "Failed trying to save data to the database.  Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message

                        Throw ex

                    Finally

                        If DbContext.Database.Connection.State = ConnectionState.Open Then

                            DbContext.Database.Connection.Close()

                        End If

                    End Try

                End If

            End Using

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Private Sub SetDefaultGeneralLedgerAccounts()

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing

            If FormAction <> WinForm.Presentation.FormActions.Clearing AndAlso SearchableComboBoxForm_Product.HasASelectedValue Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue)

                    If Product IsNot Nothing Then

                        If NumericInputDisbursedTo_State.EditValue <> 0 Then

                            SearchableComboBoxGroup_StateTaxGLACode.SelectedValue = Product.Office.StateTaxGLACode

                        End If

                        If NumericInputDisbursedTo_County.EditValue <> 0 Then

                            SearchableComboBoxGroup_CountyTaxGLACode.SelectedValue = Product.Office.CountyTaxGLACode

                        End If

                        If NumericInputDisbursedTo_City.EditValue <> 0 Then

                            SearchableComboBoxGroup_CityTaxGLACode.SelectedValue = Product.Office.CityTaxGLACode

                        End If

                        SearchableComboBoxGroup_ARGLACode.SelectedValue = Product.Office.AccountsReceivableGLACode

                        If SearchableComboBoxForm_SalesClass.HasASelectedValue Then

                            OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, SearchableComboBoxForm_SalesClass.GetSelectedValue, SearchableComboBoxForm_Office.GetSelectedValue)

                        End If

                        If SearchableComboBoxForm_RecordType.SelectedValue = "P" Then

                            If OfficeSalesClassAccount IsNot Nothing AndAlso OfficeSalesClassAccount.ProductionSalesGLACode IsNot Nothing Then

                                SearchableComboBoxGroup_SalesGLACode.SelectedValue = OfficeSalesClassAccount.ProductionSalesGLACode

                                If NumericInputDisbursedTo_COS.EditValue <> 0 Then

                                    SearchableComboBoxGroup_COSGLACode.SelectedValue = OfficeSalesClassAccount.ProductionCostOfSalesGLACode

                                End If

                            Else

                                SearchableComboBoxGroup_SalesGLACode.SelectedValue = Product.Office.ProductionSalesGLACode

                                If NumericInputDisbursedTo_COS.EditValue <> 0 Then

                                    SearchableComboBoxGroup_COSGLACode.SelectedValue = Product.Office.ProductionCostOfSalesGLACode

                                End If

                            End If

                        Else

                            If OfficeSalesClassAccount IsNot Nothing AndAlso OfficeSalesClassAccount.MediaSalesGLACode IsNot Nothing Then

                                SearchableComboBoxGroup_SalesGLACode.SelectedValue = OfficeSalesClassAccount.MediaSalesGLACode

                                If NumericInputDisbursedTo_COS.EditValue <> 0 Then

                                    SearchableComboBoxGroup_COSGLACode.SelectedValue = OfficeSalesClassAccount.MediaCostOfSalesGLACode

                                End If

                            Else

                                SearchableComboBoxGroup_SalesGLACode.SelectedValue = Product.Office.MediaSalesGLACode

                                If NumericInputDisbursedTo_COS.EditValue <> 0 Then

                                    SearchableComboBoxGroup_COSGLACode.SelectedValue = Product.Office.MediaCostOfSalesGLACode

                                End If

                            End If

                        End If

                        Me.ValidateControl(SearchableComboBoxGroup_StateTaxGLACode)
                        Me.ValidateControl(SearchableComboBoxGroup_CountyTaxGLACode)
                        Me.ValidateControl(SearchableComboBoxGroup_CityTaxGLACode)
                        Me.ValidateControl(SearchableComboBoxGroup_ARGLACode)
                        Me.ValidateControl(SearchableComboBoxGroup_SalesGLACode)
                        Me.ValidateControl(SearchableComboBoxGroup_COSGLACode)

                    End If

                End Using

            End If

        End Sub
        Private Sub CalculateSalesAndGrossProfit()

            NumericInputDisbursedTo_Sales.EditValue = NumericInputForm_InvoiceAmount.EditValue - (NumericInputDisbursedTo_State.EditValue + NumericInputDisbursedTo_County.EditValue + NumericInputDisbursedTo_City.EditValue)

            NumericInputDisbursedTo_GrossProfit.EditValue = NumericInputDisbursedTo_Sales.EditValue - NumericInputDisbursedTo_COS.EditValue

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BatchDate As Date, ByVal ClientCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientInvoiceNewDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceNewDialog = Nothing

            ClientInvoiceNewDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceNewDialog(BatchDate, ClientCode)

            ShowFormDialog = ClientInvoiceNewDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientInvoiceNewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_PrintCurrentBatch.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintLastInvoice.Image = AdvantageFramework.My.Resources.PrintImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.AccountReceivable)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                DbContext.Database.Connection.Open()

                SearchableComboBoxForm_Client.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.ClientCode)
                SearchableComboBoxForm_Client.SetRequired(True)

                SearchableComboBoxForm_Division.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.DivisionCode)
                SearchableComboBoxForm_Division.SetRequired(True)

                SearchableComboBoxForm_Product.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.ProductCode)
                SearchableComboBoxForm_Product.SetRequired(True)

                SearchableComboBoxForm_Office.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.OfficeCode)

                TextBoxForm_Description.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.Description)

                SearchableComboBoxForm_SalesClass.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SalesClassCode)
                SearchableComboBoxForm_PostPeriod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.PostPeriodCode)
                SearchableComboBoxForm_PostPeriod.SetRequired(True)

                SearchableComboBoxForm_RecordType.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.RecordType)
                SearchableComboBoxForm_RecordType.SetRequired(True)

                DateTimePickerForm_InvoiceDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.InvoiceDate)
                DateTimePickerForm_InvoiceDate.SetRequired(True)
                DateTimePickerForm_InvoiceDate.Value = Nothing

                NumericInputForm_InvoiceAmount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SaleAmount)
                NumericInputForm_InvoiceAmount.Properties.MinValue = NumericInputForm_InvoiceAmount.Properties.MaxValue * -1
                NumericInputForm_InvoiceAmount.SetRequired(True)

                SearchableComboBoxGroup_ARGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeAR)
                SearchableComboBoxGroup_ARGLACode.SetRequired(True)

                SearchableComboBoxGroup_SalesGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeSales)
                SearchableComboBoxGroup_SalesGLACode.SetRequired(True)

                SearchableComboBoxGroup_COSGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.CostOfSalesGLACode)
                SearchableComboBoxGroup_OffsetGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeOffset)
                SearchableComboBoxGroup_StateTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeState)
                SearchableComboBoxGroup_CountyTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeCounty)
                SearchableComboBoxGroup_CityTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.GLACodeCity)

                NumericInputDisbursedTo_Sales.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SaleAmount)
                NumericInputDisbursedTo_COS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.OffsetAmount)
                NumericInputDisbursedTo_State.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.StateAmount)
                NumericInputDisbursedTo_County.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.CountyAmount)
                NumericInputDisbursedTo_City.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountReceivable.Properties.CityAmount)

                NumericInputDisbursedTo_Sales.Properties.MinValue = NumericInputDisbursedTo_Sales.Properties.MaxValue * -1
                NumericInputDisbursedTo_COS.Properties.MinValue = NumericInputDisbursedTo_COS.Properties.MaxValue * -1
                NumericInputDisbursedTo_State.Properties.MinValue = NumericInputDisbursedTo_State.Properties.MaxValue * -1
                NumericInputDisbursedTo_County.Properties.MinValue = NumericInputDisbursedTo_County.Properties.MaxValue * -1
                NumericInputDisbursedTo_City.Properties.MinValue = NumericInputDisbursedTo_City.Properties.MaxValue * -1

                ClientCodes = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, Me.Session)
                               Select Entity.Code).ToArray

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SearchableComboBoxForm_Client.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                Where ClientCodes.Contains(Client.Code) AndAlso
                                                                      Client.IsActive = 1
                                                                Select Client).ToList

                End Using

                SearchableComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Session).Where(Function(Office) Office.IsInactive Is Nothing OrElse Office.IsInactive = 0).ToList

                SearchableComboBoxForm_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

                If PostPeriod IsNot Nothing Then

                    SearchableComboBoxForm_PostPeriod.SelectedValue = PostPeriod.Code

                End If

                SearchableComboBoxForm_RecordType.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountReceivableRecordType))
                                                                Select Entity.Code,
                                                                           [Description] = Entity.Description).ToList

                SearchableComboBoxForm_RecordType.SelectedValue = "P"

                GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session).ToList

                SearchableComboBoxGroup_ARGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_SalesGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_COSGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_OffsetGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_StateTaxGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_CountyTaxGLACode.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGroup_CityTaxGLACode.DataSource = GeneralLedgerAccounts

            End Using

        End Sub
        Private Sub ClientInvoiceNewDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            SearchableComboBoxForm_Client.SelectedValue = _ClientCode

            If SearchableComboBoxForm_Client.HasASelectedValue Then

                SearchableComboBoxForm_Division.Focus()

            End If

            SetDefaultGeneralLedgerAccounts()

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim Save As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim IsValid As Boolean = True

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    AccountReceivable = New AdvantageFramework.Database.Entities.AccountReceivable

                    LoadAccountReceivableEntity(AccountReceivable)

                    ErrorMessage = AccountReceivable.ValidateEntity(IsValid)

                    If IsValid Then

                        If Insert(AccountReceivable) Then

                            SearchableComboBoxForm_SalesClass.SelectedValue = Nothing
                            TextBoxForm_Description.Text = Nothing

                            Me.DateTimePickerForm_InvoiceDate.Value = Nothing
                            Me.NumericInputForm_InvoiceAmount.EditValue = 0

                            SearchableComboBoxGroup_COSGLACode.SelectedValue = Nothing
                            SearchableComboBoxGroup_OffsetGLACode.SelectedValue = Nothing
                            SearchableComboBoxGroup_StateTaxGLACode.SelectedValue = Nothing
                            SearchableComboBoxGroup_CountyTaxGLACode.SelectedValue = Nothing
                            SearchableComboBoxGroup_CityTaxGLACode.SelectedValue = Nothing

                            Me.NumericInputDisbursedTo_COS.EditValue = 0
                            Me.NumericInputDisbursedTo_State.EditValue = 0
                            Me.NumericInputDisbursedTo_County.EditValue = 0
                            Me.NumericInputDisbursedTo_City.EditValue = 0

                            SearchableComboBoxForm_Division.Focus()

                            Me.ClearChanged()

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_PrintCurrentBatch_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintCurrentBatch.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientInvoiceBatchReportList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport) = Nothing
            Dim ReportRange As String = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterFromDate = New SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
            SqlParameterToDate = New SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
            SqlParameterIsBatch = New SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SqlParameterUserCode.Value = Me.Session.UserCode
                SqlParameterFromDate.Value = _BatchDate
                SqlParameterToDate.Value = System.DBNull.Value
                SqlParameterIsBatch.Value = 1

                ClientInvoiceBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)("exec advsp_clientinvoice_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch).ToList()

                If ClientInvoiceBatchReportList.Count > 0 Then

                    ReportRange = "Batch: " & _BatchDate

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    ParameterDictionary.Add("DataSource", ClientInvoiceBatchReportList)
                    ParameterDictionary.Add("ForUser", Me.Session.UserCode)
                    ParameterDictionary.Add("ReportRange", ReportRange)

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchDetailReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Nothing to print.")

                End If

            End Using

        End Sub
        Private Sub ButtonItemActions_PrintLastInvoice_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintLastInvoice.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientInvoiceBatchReportList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport) = Nothing
            Dim ClientInvoiceBatchReport As AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport = Nothing
            Dim ReportRange As String = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterFromDate = New SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
            SqlParameterToDate = New SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
            SqlParameterIsBatch = New SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SqlParameterUserCode.Value = Me.Session.UserCode
                SqlParameterFromDate.Value = _BatchDate
                SqlParameterToDate.Value = System.DBNull.Value
                SqlParameterIsBatch.Value = 1

                ClientInvoiceBatchReportList = New Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)

                ClientInvoiceBatchReport = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)("exec advsp_clientinvoice_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch) _
                        .ToList.OrderByDescending(Function(Invoice) Invoice.InvoiceNumber).FirstOrDefault

                If ClientInvoiceBatchReport IsNot Nothing Then

                    ClientInvoiceBatchReportList.Add(ClientInvoiceBatchReport)

                    ReportRange = "Invoice: " & ClientInvoiceBatchReport.InvoiceNumber

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    ParameterDictionary.Add("DataSource", ClientInvoiceBatchReportList)
                    ParameterDictionary.Add("ForUser", Me.Session.UserCode)
                    ParameterDictionary.Add("ReportRange", ReportRange)

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchDetailReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Nothing to print.")

                End If

            End Using

        End Sub
        Private Sub SearchableComboBoxForm_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Client.EditValueChanged

            Dim ClientCode As String = Nothing
            Dim DivisionCodes As IEnumerable(Of String) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing

            If SearchableComboBoxForm_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxForm_Client.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DivisionCodes = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadWithOfficeLimits(DbContext, Me.Session)
                                         Where Entity.ClientCode = ClientCode
                                         Select Entity.Code).ToArray

                        DivisionList = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                        Where Entity.ClientCode = ClientCode AndAlso
                                              Entity.IsActive = 1 AndAlso
                                              DivisionCodes.Contains(Entity.Code)
                                        Select Entity).ToList

                        SearchableComboBoxForm_Division.DataSource = DivisionList

                    End Using

                End Using

                SearchableComboBoxForm_Product.SelectedValue = Nothing

                If DivisionList.Count = 1 Then

                    SearchableComboBoxForm_Division.SelectedValue = DivisionList(0).Code

                Else

                    SearchableComboBoxForm_Division.SelectedValue = Nothing

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Division.EditValueChanged

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            If SearchableComboBoxForm_Division.HasASelectedValue Then

                ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
                DivisionCode = SearchableComboBoxForm_Division.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ProductList = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False)
                                       Where Entity.ClientCode = ClientCode AndAlso
                                             Entity.DivisionCode = DivisionCode AndAlso
                                             Entity.IsActive = 1
                                       Select Entity).ToList

                        SearchableComboBoxForm_Product.DataSource = ProductList

                    End Using

                End Using

                If ProductList.Count = 1 Then

                    SearchableComboBoxForm_Product.SelectedValue = ProductList(0).Code

                Else

                    SearchableComboBoxForm_Product.SelectedValue = Nothing

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Product.EditValueChanged

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            SearchableComboBoxGroup_OffsetGLACode.SelectedValue = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue)

                If Product IsNot Nothing Then

                    SearchableComboBoxForm_Office.SelectedValue = Product.OfficeCode

                End If

            End Using

            SetDefaultGeneralLedgerAccounts()

        End Sub
        Private Sub SearchableComboBoxForm_RecordType_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_RecordType.EditValueChanged

            Me.FormAction = WinForm.Presentation.FormActions.Clearing

            SearchableComboBoxForm_SalesClass.SelectedValue = Nothing

            SearchableComboBoxForm_SalesClass.DataSource = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.None

            SetDefaultGeneralLedgerAccounts()

        End Sub
        Private Sub SearchableComboBoxForm_SalesClass_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_SalesClass.EditValueChanged

            SetDefaultGeneralLedgerAccounts()

        End Sub
        Private Sub SearchableComboBoxForm_SalesClass_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxForm_SalesClass.QueryPopupNeedDataSource

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If SearchableComboBoxForm_RecordType.GetSelectedValue = "P" Then

                    SearchableComboBoxForm_SalesClass.DataSource = (From SC In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                                                    Where SC.SalesClassTypeCode Is Nothing OrElse
                                                                          SC.SalesClassTypeCode = "P"
                                                                    Select SC).ToList

                ElseIf SearchableComboBoxForm_RecordType.GetSelectedValue = "M" Then

                    SearchableComboBoxForm_SalesClass.DataSource = (From SC In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                                                    Where SC.SalesClassTypeCode Is Nothing OrElse
                                                                          SC.SalesClassTypeCode <> "P"
                                                                    Select SC).ToList

                End If

            End Using

            DataSourceSet = True

        End Sub
        Private Sub NumericInputForm_InvoiceAmount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_InvoiceAmount.EditValueChanged

            CalculateSalesAndGrossProfit()

        End Sub
        Private Sub NumericInputDisbursedTo_COS_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputDisbursedTo_COS.EditValueChanged

            If NumericInputDisbursedTo_COS.EditValue <> 0 Then

                SearchableComboBoxGroup_COSGLACode.SetRequired(True)
                SearchableComboBoxGroup_OffsetGLACode.SetRequired(True)

                SetDefaultGeneralLedgerAccounts()

            Else

                SearchableComboBoxGroup_COSGLACode.SetRequired(False)
                SearchableComboBoxGroup_OffsetGLACode.SetRequired(False)

            End If

            CalculateSalesAndGrossProfit()

        End Sub
        Private Sub NumericInputDisbursedTo_State_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputDisbursedTo_State.EditValueChanged

            If NumericInputDisbursedTo_State.EditValue <> 0 Then

                SearchableComboBoxGroup_StateTaxGLACode.SetRequired(True)

                SetDefaultGeneralLedgerAccounts()

            Else

                SearchableComboBoxGroup_StateTaxGLACode.SetRequired(False)

            End If

            CalculateSalesAndGrossProfit()

        End Sub
        Private Sub NumericInputDisbursedTo_County_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputDisbursedTo_County.EditValueChanged

            If NumericInputDisbursedTo_County.EditValue <> 0 Then

                SearchableComboBoxGroup_CountyTaxGLACode.SetRequired(True)

                SetDefaultGeneralLedgerAccounts()

            Else

                SearchableComboBoxGroup_CountyTaxGLACode.SetRequired(False)

            End If

            CalculateSalesAndGrossProfit()

        End Sub
        Private Sub NumericInputDisbursedTo_City_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputDisbursedTo_City.EditValueChanged

            If NumericInputDisbursedTo_City.EditValue <> 0 Then

                SearchableComboBoxGroup_CityTaxGLACode.SetRequired(True)

                SetDefaultGeneralLedgerAccounts()

            Else

                SearchableComboBoxGroup_CityTaxGLACode.SetRequired(False)

            End If

            CalculateSalesAndGrossProfit()

        End Sub
        Private Sub DateTimePickerForm_InvoiceDate_Leave(sender As Object, e As EventArgs) Handles DateTimePickerForm_InvoiceDate.Leave

            If DateTimePickerForm_InvoiceDate.Value = #12:00:00 AM# Then

                DateTimePickerForm_InvoiceDate.Value = Now.ToShortDateString

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
