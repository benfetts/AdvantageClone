Namespace WinForm.Presentation.Controls

    Public Class ExpenseReportControl

        Public Event SelectedTabChanged()
        Public Event LineItemsSelectionChangedEvent()
        Public Event ExpenseTotalsChangedEvent()
        Public Event ExpenseHeaderInformationChangedEvent(ByVal ReportDate As Nullable(Of Date), ByVal Description As String)
        Public Event ExpenseDetailAddedEvent()
        Public Event ExpenseDetailInitNewRowEvent()
        Public Event ExpenseDetailNewRowCanceledEvent()
        Public Event FilteredDocumentsEvent(ByVal DocumentSubLevel As Database.Entities.DocumentSubLevel)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _Status As AdvantageFramework.ExpenseReports.ExpenseReportStatus = ExpenseReports.ExpenseReportStatus.Open
        Private _ClosedForEditing As Boolean = False
        Private _UserCDPAccess As Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)) = Nothing
        Private _Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
        Private _Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
        Private _Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
        Private _Jobs As Generic.List(Of AdvantageFramework.Database.Core.Job) = Nothing
        Private _JobComponents As Generic.List(Of AdvantageFramework.Database.Core.JobComponent) = Nothing
        Private _Saving As Boolean = False
        Private _HasExpenseReportItems As Boolean = False
        Private _NewItemInitializing As Boolean = False
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default
        Private _HasAccessToDocuments As Boolean = False
        Private _SubItemImageCheckEditControl_Blank As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl = Nothing
        Private _DefaultPaymentType As Short? = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property LineItemsTabSelected As Boolean
            Get
                LineItemsTabSelected = If(TabControlControl_ExpenseReportDetails.SelectedTab Is TabItemExpenseReportDetails_LineItemsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property ReceiptsTabSelected As Boolean
            Get
                ReceiptsTabSelected = If(TabControlControl_ExpenseReportDetails.SelectedTab Is TabItemExpenseReportDetails_ReceiptsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property LineItemsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                LineItemsDataGridView = DataGridViewLineItems_LineItems
            End Get
        End Property
        Public ReadOnly Property Status As AdvantageFramework.ExpenseReports.ExpenseReportStatus
            Get
                Status = _Status
            End Get
        End Property
        Public ReadOnly Property DocumentManagerControl As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManagerControl = DocumentManagerControlReceipts_Receipts
            End Get
        End Property
        Public ReadOnly Property BillableExpenseItemsTotal As Nullable(Of Decimal)
            Get

                Try

                    BillableExpenseItemsTotal = (From Entity In DataGridViewLineItems_LineItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList
                                                 Where Entity.NonBillable = False
                                                 Select Entity.Amount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    BillableExpenseItemsTotal = Nothing
                End Try

            End Get
        End Property
        Public ReadOnly Property NonBillableExpenseItemsTotal As Nullable(Of Decimal)
            Get

                Try

                    NonBillableExpenseItemsTotal = (From Entity In DataGridViewLineItems_LineItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList
                                                    Where Entity.NonBillable = True
                                                    Select Entity.Amount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    NonBillableExpenseItemsTotal = Nothing
                End Try

            End Get
        End Property
        Public ReadOnly Property ExpenseItemsTotal As Nullable(Of Decimal)
            Get

                Try

                    ExpenseItemsTotal = (From Entity In DataGridViewLineItems_LineItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList
                                         Select Entity.Amount.GetValueOrDefault(0)).Sum

                Catch ex As Exception
                    ExpenseItemsTotal = Nothing
                End Try

            End Get
        End Property
        Public ReadOnly Property HasExpenseReportItems As Boolean
            Get

                If TabItemExpenseReportDetails_LineItemsTab.Tag = True Then

                    HasExpenseReportItems = DataGridViewLineItems_LineItems.HasRows

                Else

                    HasExpenseReportItems = _HasExpenseReportItems

                End If

            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property UserCanDeleteSelectedLineItem As Boolean
            Get

                Dim CanDelete = True

                If DataGridViewLineItems_LineItems.HasOnlyOneSelectedRow Then

                    If DirectCast(DataGridViewLineItems_LineItems.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.ExpenseReportItem).IsImported Then

                        If DirectCast(DataGridViewLineItems_LineItems.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.ExpenseReportItem).CreatedBy.ToUpper = _Session.UserCode.ToUpper Then

                            CanDelete = True

                        Else

                            CanDelete = Not AdvantageFramework.Security.CanUserCustom2InModule(_Session, Security.Modules.Employee_ExpenseReports)

                        End If

                    End If

                End If

                UserCanDeleteSelectedLineItem = CanDelete

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            'objects
            Dim DefaultPaymentType As String = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                _UserCDPAccess = New Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess))

                                _Clients = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)
                                _Divisions = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                                _Products = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                                _Jobs = AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext)
                                _JobComponents = AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)

                                DataGridViewLineItems_LineItems.AutoFilterLookupColumns = True
                                DataGridViewLineItems_LineItems.AutoloadRepositoryDatasource = True
                                'ComboBoxGeneral_Employee.AutoSelectSingleItemDatasource = True

                                DateTimePickerGeneral_CreatedDate.Enabled = False
                                DateTimePickerGeneral_CreatedDate.ReadOnly = True

                                SearchableComboBoxGeneral_Employee.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

                                TabItemExpenseReportDetails_PaymentHistoryTab.Visible = False

                                TextBoxGeneral_InvoiceNumber.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.InvoiceNumber)
                                SearchableComboBoxGeneral_Employee.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.EmployeeCode)
                                ComboBoxGeneral_Status.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.Status)
                                TextBoxGeneral_Description.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.Description)
                                TextBoxGeneral_Details.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.Details)
                                DateTimePickerGeneral_ReportDate.SetPropertySettings(AdvantageFramework.Database.Entities.ExpenseReport.Properties.InvoiceDate, "Report Date")

                                ComboBoxGeneral_Status.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.ExpenseReports.ExpenseReportStatus)).ToList

                                Try

                                    SearchableComboBoxGeneral_Employee.DataSource = AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, True)

                                Catch ex As Exception

                                End Try

                                PictureBoxGeneral_StatusInformation.Image = AdvantageFramework.My.Resources.InformationImage
                                PictureBoxGeneral_StatusInformation.MaximumSize = New System.Drawing.Size(20, 20)
                                PictureBoxGeneral_StatusInformation.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
                                PictureBoxGeneral_StatusInformation.Visible = False

                                _SubItemImageCheckEditControl_Blank = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageCheckBox(True, SubItemImageCheckEditControl.Type.ImageWhenChecked,
                                                                                                                                                  GetType(AdvantageFramework.Database.Classes.ExpenseReportItem),
                                                                                                                                                  AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.NonBillable.ToString)

                                _SubItemImageCheckEditControl_Blank.PictureChecked = Nothing

                                DataGridViewLineItems_LineItems.GridControl.RepositoryItems.Add(_SubItemImageCheckEditControl_Blank)

                                DefaultPaymentType = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "EXPENSE_REPORT")
                                                      Where Item.Name = "DefaultPaymentType"
                                                      Select Item.Value).SingleOrDefault

                                If Not String.IsNullOrWhiteSpace(DefaultPaymentType) AndAlso IsNumeric(DefaultPaymentType) Then

                                    _DefaultPaymentType = CShort(DefaultPaymentType)

                                End If

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadExpenseReportEntity(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

            If ExpenseReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport.EmployeeCode = SearchableComboBoxGeneral_Employee.GetSelectedValue

                    Try

                        ExpenseReport.VendorCode = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode).EmployeeVendorCode

                    Catch ex As Exception
                        ExpenseReport.VendorCode = Nothing
                    End Try

                    If DateTimePickerGeneral_ReportDate.ValueObject IsNot Nothing Then

                        ExpenseReport.InvoiceDate = DateTimePickerGeneral_ReportDate.ValueObject

                    Else

                        ExpenseReport.InvoiceDate = Nothing

                    End If

                    ExpenseReport.Description = TextBoxGeneral_Description.Text
                    ExpenseReport.Details = TextBoxGeneral_Details.Text

                End Using

            End If

        End Sub
        Private Sub LoadExpenseReportDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            If _InvoiceNumber IsNot Nothing Then

                ExpenseReport = GetExpenseReport()

                If ExpenseReport IsNot Nothing Then

                    If TabItem Is Nothing Then

                        For Each TabItem In TabControlControl_ExpenseReportDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            TabItem.Tag = False

                        Next

                        TabItem = TabControlControl_ExpenseReportDetails.SelectedTab

                    End If

                    If TabItem.Tag = False Then

                        If TabItem Is TabItemExpenseReportDetails_GeneralTab OrElse
                           TabItemExpenseReportDetails_GeneralTab.Tag = False Then

                            LoadGeneralTab(ExpenseReport)

                        End If

                        If TabItem Is TabItemExpenseReportDetails_LineItemsTab Then

                            LoadLineItemsTab(ExpenseReport)

                        End If

                        If TabItem Is TabItemExpenseReportDetails_ReceiptsTab Then

                            LoadReceiptsTab(ExpenseReport)

                        End If

                        If TabItem Is TabItemExpenseReportDetails_PaymentHistoryTab Then

                            LoadPaymentHistoryTab(ExpenseReport)

                        End If

                    ElseIf TabItem Is TabItemExpenseReportDetails_ReceiptsTab Then

                        If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                            FilterDocuments(Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If ExpenseReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy Then

                        TextBoxGeneral_InvoiceNumber.Text = "TBD"
                        ComboBoxGeneral_Status.SelectedValue = CLng(0)
                        DateTimePickerGeneral_ReportDate.ValueObject = System.DateTime.Today

                    Else

                        TextBoxGeneral_InvoiceNumber.Text = ExpenseReport.InvoiceNumber
                        DateTimePickerGeneral_ReportDate.ValueObject = ExpenseReport.InvoiceDate

                    End If

                    ComboBoxGeneral_Status.SelectedValue = CLng(_Status)

                    TextBoxGeneral_Description.Text = ExpenseReport.Description
                    TextBoxGeneral_Details.Text = ExpenseReport.Details

                    DateTimePickerGeneral_CreatedDate.ValueObject = ExpenseReport.CreatedDate

                    If ExpenseReport.EmployeeCode IsNot Nothing Then

                        Try

                            SearchableComboBoxGeneral_Employee.SelectedValue = ExpenseReport.EmployeeCode

                        Catch ex As Exception
                            SearchableComboBoxGeneral_Employee.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxGeneral_Employee.HasASelectedValue = False Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                            If Employee IsNot Nothing Then

                                SearchableComboBoxGeneral_Employee.AddComboItemToExistingDataSource(Employee.ToString & "*", Employee.Code, False)

                                Try

                                    SearchableComboBoxGeneral_Employee.SelectedValue = ExpenseReport.EmployeeCode

                                Catch ex As Exception
                                    SearchableComboBoxGeneral_Employee.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxGeneral_Employee.SelectedValue = Nothing

                    End If

                End Using

                TabItemExpenseReportDetails_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadLineItemsTab(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

            If ExpenseReport IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                LoadExpenseReportDetailsGrid()

                TabItemExpenseReportDetails_LineItemsTab.Tag = True

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadReceiptsTab(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

            If ExpenseReport IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                LoadExpenseReportDocuments()

                TabItemExpenseReportDetails_ReceiptsTab.Tag = True

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadPaymentHistoryTab(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

            If ExpenseReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewPaymentHistory_Payments.DataSource = AdvantageFramework.Database.Procedures.InvoiceDetailsComplexType.Load(DbContext, ExpenseReport.EmployeeCode, ExpenseReport.InvoiceNumber).ToList
                    DataGridViewPaymentHistory_Payments.CurrentView.BestFitColumns()

                End Using

                TabItemExpenseReportDetails_PaymentHistoryTab.Tag = True

            End If

        End Sub
        Private Sub LoadExpenseReportDetailsGrid()

            'objects
            Dim ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing
            Dim EmployeeCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _InvoiceNumber IsNot Nothing Then

                    EmployeeCode = SearchableComboBoxGeneral_Employee.GetSelectedValue

                    ExpenseReportDetails = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False).ToList

                    If ExpenseReportDetails IsNot Nothing AndAlso ExpenseReportDetails.Count > 0 Then

                        DataGridViewLineItems_LineItems.DataSource = ExpenseReportDetails.Select(Function(ExpenseReportDetail) New AdvantageFramework.Database.Classes.ExpenseReportItem(ExpenseReportDetail, EmployeeCode, DbContext)).OrderBy(Function(ExpDtl) ExpDtl.LineNumber).ThenBy(Function(ExpDtl) ExpDtl.ItemDate).ToList

                    Else

                        DataGridViewLineItems_LineItems.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem)

                    End If

                    LoadGridRepositoryItems()

                    CalculateExpenseItems()

                    DataGridViewLineItems_LineItems.CurrentView.BestFitColumns()

                End If

            End Using

        End Sub
        Private Sub LoadGridRepositoryItems()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            For Each GridColumn In DataGridViewLineItems_LineItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible Then

                    If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        Try

                            SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                        Catch ex As Exception
                            SubItemGridLookUpEditControl = Nothing
                        End Try

                        If SubItemGridLookUpEditControl IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Select Case GridColumn.FieldName

                                    Case Database.Classes.ExpenseReportItem.Properties.ClientCode.ToString

                                        SubItemGridLookUpEditControl.DataSource = _Clients

                                    Case Database.Classes.ExpenseReportItem.Properties.DivisionCode.ToString

                                        SubItemGridLookUpEditControl.DataSource = _Divisions

                                    Case Database.Classes.ExpenseReportItem.Properties.ProductCode.ToString

                                        SubItemGridLookUpEditControl.DataSource = _Products

                                    Case Database.Classes.ExpenseReportItem.Properties.JobNumber.ToString

                                        SubItemGridLookUpEditControl.DataSource = _Jobs

                                    Case Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString

                                        SubItemGridLookUpEditControl.DataSource = _JobComponents

                                End Select

                            End Using

                        End If

                    End If

                End If

            Next

        End Sub
        Private Sub LoadExpenseReportDocuments()

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            If _InvoiceNumber IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy = False Then

                        DocumentManagerControlReceipts_Receipts.ClearControl()

                        Try

                            If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                                DocumentLevelSettings = (From Entity In DataGridViewLineItems_LineItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList
                                                         Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument) _
                                                                        With {.ExpenseReportInvoiceNumber = _InvoiceNumber,
                                                                              .ExpenseDetailID = Entity.ID}).ToList

                            End If

                        Catch ex As Exception
                            DocumentLevelSettings = Nothing
                        End Try

                        If DocumentLevelSettings Is Nothing OrElse DocumentLevelSettings.Count = 0 Then

                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts) With {.ExpenseReportInvoiceNumber = _InvoiceNumber})

                        End If

                        DocumentManagerControlReceipts_Receipts.Enabled = DocumentManagerControlReceipts_Receipts.LoadControl(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, DocumentLevelSettings,
                                                                                                                              Presentation.Controls.DocumentManagerControl.Type.Default, _DocumentSubLevel)

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadBillingRate(ByVal RowHandle As Integer)

            ' objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim Rate As Nullable(Of Decimal) = Nothing
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing
            Dim EmployeeCode As String = ""
            Dim NonBillable As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ExpenseReportItem = DataGridViewLineItems_LineItems.CurrentView.GetRow(RowHandle)

                Catch ex As Exception
                    ExpenseReportItem = Nothing
                End Try

                If ExpenseReportItem IsNot Nothing Then

                    Try

                        BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRateByItem(DbContext, ExpenseReportItem)

                        If BillingRate IsNot Nothing Then

                            Rate = BillingRate.BILLING_RATE
                            NonBillable = CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0))

                        End If

                    Catch ex As Exception
                        Rate = Nothing
                    End Try

                End If

                DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Rate.ToString, Rate)
                DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.NonBillable.ToString, NonBillable)

            End Using

        End Sub
        Private Sub CalculateExpenseItems()

            Dim TotalAmount As Decimal = Nothing
            Dim TotalCreditCard As Decimal = Nothing
            Dim TotalDue As Decimal = Nothing
            Dim ExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem) = Nothing

            Try

                ExpenseReportItems = DataGridViewLineItems_LineItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList

                AdvantageFramework.ExpenseReports.CalculateExpenseReportDetailsTotals(ExpenseReportItems, TotalAmount, TotalCreditCard, TotalDue)

            Catch ex As Exception

            End Try

            LabelLineItems_LessCorporateCreditCard.Text = TotalCreditCard.ToString("C2")
            LabelLineItems_TotalDue.Text = TotalDue.ToString("C2")
            LabelLineItems_TotalExpenses.Text = TotalAmount.ToString("C2")

            RaiseEvent ExpenseTotalsChangedEvent()

        End Sub
        Private Sub EnableOrDisableActions()

            'TabControlPanelGeneralTab_General.Enabled = Not _ClosedForEditing

            SearchableComboBoxGeneral_Employee.Enabled = Not _ClosedForEditing

            TextBoxGeneral_Description.ReadOnly = _ClosedForEditing
            TextBoxGeneral_Description.Enabled = Not _ClosedForEditing

            TextBoxGeneral_Details.ReadOnly = _ClosedForEditing
            TextBoxGeneral_Details.Enabled = Not _ClosedForEditing

            DateTimePickerGeneral_CreatedDate.Enabled = False
            DateTimePickerGeneral_CreatedDate.ReadOnly = True

            DateTimePickerGeneral_ReportDate.Enabled = Not _ClosedForEditing
            DateTimePickerGeneral_ReportDate.ReadOnly = _ClosedForEditing

            DataGridViewLineItems_LineItems.NewItemRowPosition = If(_ClosedForEditing OrElse _IsCopy, DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top)

        End Sub
        Private Function SaveExpenseItemsGrid() As Boolean

            'objects
            Dim ExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem) = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim Saved As Boolean = True
            Dim Valid As Boolean = True
            Dim ErrorText As String = ""

            _Saving = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewLineItems_LineItems.CurrentView.CloseEditorForUpdating()

                Try

                    ExpenseReportItems = DataGridViewLineItems_LineItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList

                Catch ex As Exception
                    ExpenseReportItems = Nothing
                End Try

                For Each ExpenseReportItem In ExpenseReportItems

                    ExpenseReportDetail = ExpenseReportItem.GetExpenseReportDetail(DbContext)
                    ExpenseReportDetail.DbContext = DbContext

                    ErrorText = ExpenseReportDetail.ValidateEntity(Valid)

                    If Valid Then

                        Try

                            DbContext.UpdateObject(ExpenseReportDetail)

                        Catch ex As Exception

                        End Try

                    Else

                        Saved = False
                        Exit For

                    End If

                Next

                If Valid Then

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception
                        Saved = False
                    End Try

                End If

            End Using

            _Saving = False

            SaveExpenseItemsGrid = Saved

        End Function
        Private Function LoadEmployeeAccess(ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)

            Dim EmployeeUserCodes As String() = Nothing
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            If EmployeeCode IsNot Nothing Then

                If _UserCDPAccess.ContainsKey(EmployeeCode) Then

                    UserClientDivisionProductAccessList = _UserCDPAccess(EmployeeCode)

                Else

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
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

                        _UserCDPAccess(EmployeeCode) = UserClientDivisionProductAccessList

                    End Using

                End If

            End If

            LoadEmployeeAccess = UserClientDivisionProductAccessList

        End Function
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.ExpenseReport

            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Try

                If IsNew Then

                    ExpenseReport = New AdvantageFramework.Database.Entities.ExpenseReport

                    LoadExpenseReportEntity(ExpenseReport)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                        If ExpenseReport IsNot Nothing Then

                            LoadExpenseReportEntity(ExpenseReport)

                        End If

                    End Using

                End If

            Catch ex As Exception
                ExpenseReport = Nothing
            End Try

            FillObject = ExpenseReport

        End Function
        Private Sub RefreshLineItemsDocumentIndicator()

            'objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For RowHandle = 0 To DataGridViewLineItems_LineItems.CurrentView.RowCount - 1

                    Try

                        ExpenseReportItem = DataGridViewLineItems_LineItems.CurrentView.GetRow(RowHandle)

                    Catch ex As Exception
                        ExpenseReportItem = Nothing
                    End Try

                    If ExpenseReportItem IsNot Nothing Then

                        Try

                            ExpenseReportItem.HasDocuments = If(AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByExpenseDetailID(DbContext, ExpenseReportItem.ID).Count > 0, True, False)

                        Catch ex As Exception
                            ExpenseReportItem.HasDocuments = False
                        End Try

                    End If

                    DataGridViewLineItems_LineItems.CurrentView.RefreshRowCell(RowHandle, DataGridViewLineItems_LineItems.Columns(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.HasDocuments.ToString))

                Next

            End Using

        End Sub

#Region "  Public "

        Public Function UnSubmit() As Boolean

            'Objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ErrorMessage As String = ""
            Dim UnSubmitted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport = Me.FillObject(False)

                    If ExpenseReport IsNot Nothing Then

                        UnSubmitted = AdvantageFramework.ExpenseReports.UnSubmitExpenseReport(DbContext, ExpenseReport, ErrorMessage)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to unsubmit. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            UnSubmit = UnSubmitted

        End Function
        Public Function Save(ByRef Submit As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IncludeReceiptsInEmailAndAlert As Boolean = False
            Dim SupervisorCode As String = Nothing
            Dim Cancel As Boolean = False
            Dim Saved As Boolean = False
            Dim Submitted As Boolean = False
            Dim SubmitErrorText As String = ""
            Dim HasAnyInvalidRows As Boolean = False
            Dim SubmitDirectToAP As Boolean = False

            _Saving = True

            Try

                DataGridViewLineItems_LineItems.CurrentView.CloseEditorForUpdating()

                DataGridViewLineItems_LineItems.ValidateAllRows()

                If DataGridViewLineItems_LineItems.HasAnyInvalidRows = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ExpenseReport = Me.FillObject(False)

                        If ExpenseReport IsNot Nothing Then

                            If ExpenseReport.InvoiceDate.HasValue AndAlso
                               (ExpenseReport.InvoiceDate < AdvantageFramework.ExpenseReports.LoadMinimumReportDate() OrElse
                                ExpenseReport.InvoiceDate > AdvantageFramework.ExpenseReports.LoadMaximumReportDate()) AndAlso
                                AdvantageFramework.Navigation.ShowMessageBox("The report date is outside of the acceptable date range. You will not be able to access this expense report. Are you sure you want to continue? ", MessageBox.MessageBoxButtons.OKCancel) = MessageBox.DialogResults.Cancel Then


                            Else

                                If Submit Then

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SearchableComboBoxGeneral_Employee.GetSelectedValue)

                                    If CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) = True Then

                                        If String.IsNullOrWhiteSpace(ExpenseReport.SubmittedTo) Then

                                            If AdvantageFramework.Employee.Presentation.ExpenseReportSubmitDialog.ShowFormDialog(Employee.Code, ExpenseReport.SubmittedTo, IncludeReceiptsInEmailAndAlert) <> Windows.Forms.DialogResult.OK Then

                                                Cancel = True

                                            End If

                                        Else

                                            SubmitDirectToAP = True

                                        End If

                                    End If

                                End If

                                If Cancel = False Then

                                    If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) AndAlso SaveExpenseItemsGrid() Then

                                        AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                                        Saved = True

                                        Try

                                            LoadExpenseReportDetailsGrid()

                                            If Submit Then

                                                Submitted = AdvantageFramework.ExpenseReports.SubmitExpenseReport(_Session, ExpenseReport, Employee, IncludeReceiptsInEmailAndAlert, ErrorMessage, SubmitDirectToAP:=SubmitDirectToAP)

                                            End If

                                        Catch ex As Exception

                                        End Try

                                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                                    End If

                                End If

                            End If

                        End If

                    End Using

                Else

                    ErrorMessage = "Please fix invalid rows."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            _Saving = False

            Submit = Submitted

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport = Me.FillObject(False)

                    If ExpenseReport IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.ExpenseReport.Delete(DbContext, ExpenseReport) Then

                            Deleted = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ExpenseReportInvoiceNumber As Integer) As Boolean

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim ExpenseReportDetailCopy As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim NewExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim ContinueInsert As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport = Me.FillObject(True)

                    If ExpenseReport IsNot Nothing Then

                        If ExpenseReport.InvoiceDate.HasValue AndAlso
                           (ExpenseReport.InvoiceDate < AdvantageFramework.ExpenseReports.LoadMinimumReportDate() OrElse
                            ExpenseReport.InvoiceDate > AdvantageFramework.ExpenseReports.LoadMaximumReportDate()) AndAlso
                            AdvantageFramework.Navigation.ShowMessageBox("The report date is outside of the acceptable date range. You will not be able to access this expense report. Are you sure you want to continue? ", MessageBox.MessageBoxButtons.OKCancel) = MessageBox.DialogResults.Cancel Then

                            Inserted = False

                        Else

                            ExpenseReport.DbContext = DbContext

                            ExpenseReport.Status = CInt(0)
                            ExpenseReport.IsSubmitted = CShort(0)
                            ExpenseReport.IsApproved = CShort(0)

                            If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) Then

                                Inserted = True

                                ExpenseReportInvoiceNumber = ExpenseReport.InvoiceNumber

                                If _IsCopy Then

                                    Try

                                        ExpenseReportDetails = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False).ToList

                                    Catch ex As Exception
                                        ExpenseReportDetails = Nothing
                                    End Try

                                    For Each ExpenseReportDetail In ExpenseReportDetails

                                        ExpenseReportDetailCopy = New AdvantageFramework.Database.Entities.ExpenseReportDetail

                                        ExpenseReportDetailCopy = ExpenseReportDetail.DuplicateEntity()

                                        ExpenseReportDetailCopy.DbContext = DbContext
                                        ExpenseReportDetailCopy.InvoiceNumber = ExpenseReport.InvoiceNumber
                                        ExpenseReportDetailCopy.ItemDate = System.DateTime.Today

                                        AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseReportDetailCopy)

                                    Next

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal InvoiceNumber As String, Optional ByVal EmployeeCode As String = Nothing, Optional ByVal IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim ShowSubmittedInformation As Boolean = False
            Dim SubmittedTo As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ApprovedBy As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim SuperTooltipInfo As DevComponents.DotNetBar.SuperTooltipInfo = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim DetailStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing
            Dim TooltipInfo As String = Nothing

            _InvoiceNumber = InvoiceNumber
            _EmployeeCode = EmployeeCode
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _InvoiceNumber <> "" AndAlso _IsCopy = False Then

                    ExpenseReport = GetExpenseReport()

                    If ExpenseReport IsNot Nothing Then

                        _Status = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)

                        Select Case _Status

                            Case ExpenseReports.ExpenseReportStatus.Open, ExpenseReports.ExpenseReportStatus.Pending

                                If _Status = ExpenseReports.ExpenseReportStatus.Pending Then

                                    ShowSubmittedInformation = True

                                End If

                                DataGridViewLineItems_LineItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                            Case Else

                                ShowSubmittedInformation = True
                                DataGridViewLineItems_LineItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                        End Select

                        If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode).TerminationDate.HasValue Then

                            DataGridViewLineItems_LineItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                            _ClosedForEditing = True

                        ElseIf _Status = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                            _ClosedForEditing = False

                        Else

                            _ClosedForEditing = True

                        End If

                        If ShowSubmittedInformation Then

                            TooltipInfo = AdvantageFramework.ExpenseReports.LoadStatusTooltip(DbContext, ExpenseReport)

                            If Not String.IsNullOrWhiteSpace(TooltipInfo) Then

                                SuperTooltipInfo = New DevComponents.DotNetBar.SuperTooltipInfo
                                SuperTooltipInfo.HeaderText = "Information"
                                SuperTooltipInfo.BodyText = TooltipInfo
                                SuperTooltip.SetSuperTooltip(PictureBoxGeneral_StatusInformation, SuperTooltipInfo)

                                PictureBoxGeneral_StatusInformation.Visible = True

                            End If

                        End If

                        TabItemExpenseReportDetails_PaymentHistoryTab.Visible = AdvantageFramework.ExpenseReports.HasExpenseReportBeenPaid(DbContext, ExpenseReport.EmployeeCode, ExpenseReport.InvoiceNumber)

                        SearchableComboBoxGeneral_Employee.Enabled = False
                        'SearchableComboBoxGeneral_Employee.ReadOnly = True
                        ComboBoxGeneral_Status.Enabled = False
                        ComboBoxGeneral_Status.ReadOnly = True

                        LoadExpenseReportDetails(Nothing)

                        If TabControlPanelLineItemsTab_LineItems Is TabControlControl_ExpenseReportDetails.SelectedTab Then

                            _HasExpenseReportItems = DataGridViewLineItems_LineItems.HasRows

                        Else

                            _HasExpenseReportItems = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False)
                                                      Select Entity).Any

                        End If

                        TabItemExpenseReportDetails_ReceiptsTab.Visible = _HasAccessToDocuments

                    Else

                        Loaded = False

                    End If

                ElseIf _InvoiceNumber <> "" AndAlso _IsCopy = True Then

                    ExpenseReport = GetExpenseReport()

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxGeneral_Employee.DataSource = AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, False)

                    End Using

                    If ExpenseReport IsNot Nothing Then

                        _Status = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open
                        _ClosedForEditing = False
                        DataGridViewLineItems_LineItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                        TextBoxGeneral_InvoiceNumber.Text = "TBD"
                        TabItemExpenseReportDetails_PaymentHistoryTab.Visible = False
                        TabItemExpenseReportDetails_ReceiptsTab.Visible = False
                        ComboBoxGeneral_Status.Enabled = False
                        ComboBoxGeneral_Status.ReadOnly = True

                        LoadExpenseReportDetails(Nothing)

                        DateTimePickerGeneral_CreatedDate.Value = System.DateTime.Now

                        If SearchableComboBoxGeneral_Employee.HasASelectedValue = False Then

                            SearchableComboBoxGeneral_Employee.Select()

                        ElseIf DateTimePickerGeneral_ReportDate.Enabled Then

                            DateTimePickerGeneral_ReportDate.Select()

                        Else

                            TextBoxGeneral_Description.Select()

                        End If

                    Else

                        Loaded = False

                    End If

                Else

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxGeneral_Employee.DataSource = AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, False)

                    End Using

                    If _EmployeeCode <> "" Then

                        SearchableComboBoxGeneral_Employee.SelectedValue = _EmployeeCode

                    End If

                    _Status = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open
                    _ClosedForEditing = False
                    ComboBoxGeneral_Status.Enabled = False
                    ComboBoxGeneral_Status.ReadOnly = True
                    DateTimePickerGeneral_ReportDate.Value = System.DateTime.Today
                    DateTimePickerGeneral_CreatedDate.Value = System.DateTime.Now
                    TabItemExpenseReportDetails_LineItemsTab.Visible = False
                    TabItemExpenseReportDetails_PaymentHistoryTab.Visible = False
                    TabItemExpenseReportDetails_ReceiptsTab.Visible = False
                    TextBoxGeneral_InvoiceNumber.ReadOnly = True
                    TextBoxGeneral_InvoiceNumber.Text = "TBD"

                    If SearchableComboBoxGeneral_Employee.HasASelectedValue = False Then

                        SearchableComboBoxGeneral_Employee.Select()

                    ElseIf DateTimePickerGeneral_ReportDate.Enabled Then

                        DateTimePickerGeneral_ReportDate.Select()

                    Else

                        TextBoxGeneral_Description.Select()

                    End If

                End If

            End Using

            EnableOrDisableActions()
            CalculateExpenseItems()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function GetExpenseReport() As AdvantageFramework.Database.Entities.ExpenseReport

            ' objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ExpenseReport = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext).ToList
                                     Where Entity.InvoiceNumber = _InvoiceNumber
                                     Select Entity).SingleOrDefault

                Catch ex As Exception
                    ExpenseReport = Nothing
                End Try

            End Using

            GetExpenseReport = ExpenseReport

        End Function
        Public Sub ClearControl()

            TextBoxGeneral_InvoiceNumber.Text = ""
            TextBoxGeneral_Details.Text = ""
            TextBoxGeneral_Description.Text = ""
            SearchableComboBoxGeneral_Employee.SelectedValue = Nothing
            ComboBoxGeneral_Status.SelectedIndex = -1
            DateTimePickerGeneral_ReportDate.ValueObject = Nothing
            DateTimePickerGeneral_CreatedDate.ValueObject = Nothing
            DataGridViewLineItems_LineItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem))
            DocumentManagerControlReceipts_Receipts.ClearControl()
            DataGridViewPaymentHistory_Payments.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.InvoiceDetails))
            TabItemExpenseReportDetails_LineItemsTab.Visible = True
            TabItemExpenseReportDetails_ReceiptsTab.Visible = _HasAccessToDocuments
            LabelLineItems_LessCorporateCreditCard.Text = ""
            LabelLineItems_TotalDue.Text = ""
            LabelLineItems_TotalExpenses.Text = ""
            PictureBoxGeneral_StatusInformation.Visible = False
            SuperTooltip.SetSuperTooltip(PictureBoxGeneral_StatusInformation, Nothing)

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CancelLineItemsNewItemRow()

            DataGridViewLineItems_LineItems.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedExpenseReportItem()

            'objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing

            If DataGridViewLineItems_LineItems.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            ExpenseReportItem = DataGridViewLineItems_LineItems.GetFirstSelectedRowDataBoundItem

                        Catch ex As Exception
                            ExpenseReportItem = Nothing
                        End Try

                        If ExpenseReportItem IsNot Nothing Then

                            ExpenseReportDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, ExpenseReportItem.ID)

                            If ExpenseReportDetail IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Delete(DbContext, ExpenseReportDetail) Then

                                    LoadExpenseReportDetailsGrid()

                                End If

                            End If

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Public Sub DeleteSelectedExpenseReportDocument()

            DocumentManagerControlReceipts_Receipts.DeleteSelectedDocument()

        End Sub
        Public Sub ExportLineItems()

            'objects
            Dim Form As AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm = Nothing

            Try

                Form = Me.FindForm

            Catch ex As Exception
                Form = Nothing
            End Try

            If Form IsNot Nothing Then

                If DataGridViewLineItems_LineItems.HasRows Then

                    DataGridViewLineItems_LineItems.CurrentView.CloseEditorForUpdating()
                    DataGridViewLineItems_LineItems.Print(Form.DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End If

            End If

        End Sub
		Public Sub UploadReceipt()

			If Me.Status = ExpenseReports.ExpenseReportStatus.Open Then

				If DocumentManagerControlReceipts_Receipts.UploadNewDocument("Invoice Number: " & _InvoiceNumber) Then

					RefreshLineItemsDocumentIndicator()

				End If

			End If

		End Sub
		Public Sub SendReceiptASPUploadEmail()

			If Me.Status = ExpenseReports.ExpenseReportStatus.Open Then

				DocumentManagerControlReceipts_Receipts.SendASPUploadEmail("Invoice Number: " & _InvoiceNumber)

			End If

		End Sub
		Public Sub SetFocusOnFailedControl(ByVal FailedControl As Object)

            'objects
            Dim ParentControl As Object = Nothing

            If FailedControl IsNot Nothing Then

                ParentControl = FailedControl.Parent

                While ParentControl IsNot Nothing

                    Try

                        If TypeOf ParentControl Is DevComponents.DotNetBar.TabControlPanel Then

                            ParentControl = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).TabItem
                            Exit While

                        Else
                            ParentControl = ParentControl.Parent
                        End If

                    Catch ex As Exception

                        ParentControl = Nothing
                        Exit While

                    End Try

                End While

                If ParentControl IsNot Nothing Then

                    TabControlControl_ExpenseReportDetails.SelectedTab = ParentControl

                    FailedControl.Select()

                End If

            End If

        End Sub
        Public Sub CopySelectedExpenseItems()

            'objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing
            Dim NewExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim InvoiceNumber As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If SaveExpenseItemsGrid() Then

                    For Each ExpenseReportItem In DataGridViewLineItems_LineItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ExpenseReportItem).ToList

                        NewExpenseReportDetail = New AdvantageFramework.Database.Entities.ExpenseReportDetail

                        Try

                            NewExpenseReportDetail = ExpenseReportItem.GetExpenseReportDetail(DbContext).DuplicateEntity()

                        Catch ex As Exception
                            NewExpenseReportDetail = Nothing
                        End Try

                        If NewExpenseReportDetail IsNot Nothing Then

                            NewExpenseReportDetail.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, NewExpenseReportDetail)

                        End If

                    Next

                    LoadExpenseReportDetailsGrid()

                End If

            End Using

        End Sub
        Public Sub LoadExpenseDetailDocuments()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If DataGridViewLineItems_LineItems.HasASelectedRow AndAlso _HasAccessToDocuments Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument) _
                                            With {.ExpenseDetailID = DataGridViewLineItems_LineItems.GetFirstSelectedRowBookmarkValue,
                                                  .ExpenseReportInvoiceNumber = _InvoiceNumber}

                AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm.ShowFormDialog(Database.Entities.DocumentLevel.ExpenseReceipts, DocumentLevelSetting, Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                RefreshLineItemsDocumentIndicator()

                TabItemExpenseReportDetails_ReceiptsTab.Tag = False

            End If

        End Sub
        Public Sub FilterDocuments(ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel)

            _DocumentSubLevel = DocumentSubLevel

            LoadExpenseReportDocuments()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ExpenseReportControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_ExpenseReportDetails_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_ExpenseReportDetails.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

                LoadExpenseReportDetails(e.NewTab)

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

            If _Saving = False Then

                RaiseEvent SelectedTabChanged()

            End If

        End Sub

#Region "   Details Tab "

        Private Sub DateTimePickerGeneral_ReportDate_ValueObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerGeneral_ReportDate.ValueObjectChanged

            RaiseEvent ExpenseHeaderInformationChangedEvent(DateTimePickerGeneral_ReportDate.ValueObject, TextBoxGeneral_Description.Text)

        End Sub
        Private Sub TextBoxGeneral_Description_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxGeneral_Description.TextChanged

            RaiseEvent ExpenseHeaderInformationChangedEvent(DateTimePickerGeneral_ReportDate.ValueObject, TextBoxGeneral_Description.Text)

        End Sub

#End Region

#Region "  Line Items Tab "

        Private Sub DataGridViewLineItems_LineItems_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewLineItems_LineItems.AddNewRowEvent

            'objects
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ExpenseReportItem Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CType(RowObject, AdvantageFramework.Database.Classes.ExpenseReportItem).SetNonBillableFlag(DbContext)

                    ExpenseReportDetail = DirectCast(RowObject, AdvantageFramework.Database.Classes.ExpenseReportItem).GetExpenseReportDetail(DbContext)

                    If ExpenseReportDetail.IsEntityBeingAdded() Then

                        ExpenseReportDetail.DbContext = DbContext

                        Try

                            ExpenseReportDetail.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReportDetail.InvoiceNumber, False)
                                                              Where Entity.InvoiceNumber = ExpenseReportDetail.InvoiceNumber
                                                              Select Entity.LineNumber).Max + 1

                        Catch ex As Exception
                            ExpenseReportDetail.LineNumber = 1
                        End Try

                        ExpenseReportDetail.CreatedBy = _Session.UserCode

                        If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseReportDetail) Then

                            AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "EXPENSE_REPORT")
                                      Where Item.Name = "DefaultPaymentType"
                                      Select Item).SingleOrDefault

                            If AppVar Is Nothing Then

                                AppVar = New Database.Entities.AppVars

                                With AppVar

                                    .Application = "EXPENSE_REPORT"
                                    .Name = "DefaultPaymentType"
                                    .Value = ExpenseReportDetail.PaymentType.GetValueOrDefault(0)
                                    .Group = 0
                                    .Type = "Number"
                                    .UserCode = _Session.UserCode

                                End With

                                If AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar) Then

                                    _DefaultPaymentType = ExpenseReportDetail.PaymentType

                                End If

                            Else

                                AppVar.Value = ExpenseReportDetail.PaymentType.GetValueOrDefault(0)

                                If AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar) Then

                                    _DefaultPaymentType = ExpenseReportDetail.PaymentType

                                End If

                            End If

                        End If

                        SaveExpenseItemsGrid()

                        LoadExpenseReportDetailsGrid()

                        CalculateExpenseItems()

                        DataGridViewLineItems_LineItems.CancelNewItemRow()

                        DataGridViewLineItems_LineItems.GridViewSelectionChanged()

                        RaiseEvent ExpenseDetailAddedEvent()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewLineItems_LineItems.CellValueChangedEvent

            'Objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing
            Dim Quantity As Object = Nothing
            Dim Rate As Object = Nothing
            Dim Amount As Object = Nothing

            If DataGridViewLineItems_LineItems.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                Try

                    ExpenseReportItem = DataGridViewLineItems_LineItems.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    ExpenseReportItem = Nothing
                End Try

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.CreditCardFlag.ToString OrElse
                       e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString Then

                    CalculateExpenseItems()

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Rate.ToString Then

                    If e.Value Is Nothing OrElse CDec(e.Value) = 0 Then

                        Quantity = Nothing
                        Rate = Nothing
                        Amount = ExpenseReportItem.Amount

                    Else

                        Quantity = ExpenseReportItem.Quantity
                        Rate = e.Value
                        Amount = ExpenseReportItem.Amount

                    End If

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(Quantity, Rate, Amount, BillingSystem.QtyRateAmount.Rate)

                    If Quantity IsNot Nothing Then

                        ExpenseReportItem.Quantity = CInt(Quantity)

                    Else

                        ExpenseReportItem.Quantity = Nothing

                    End If

                    If Rate IsNot Nothing Then

                        ExpenseReportItem.Rate = CDec(Rate)

                    Else

                        ExpenseReportItem.Rate = Nothing

                    End If

                    ExpenseReportItem.Amount = CDec(Amount)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Quantity.ToString Then

                    If e.Value Is Nothing OrElse CDec(e.Value) = 0 Then

                        Quantity = Nothing
                        Rate = Nothing
                        Amount = ExpenseReportItem.Amount

                    Else

                        Quantity = e.Value
                        Rate = ExpenseReportItem.Rate
                        Amount = ExpenseReportItem.Amount

                    End If

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(Quantity, Rate, Amount, BillingSystem.QtyRateAmount.Quantity)

                    If Quantity IsNot Nothing Then

                        ExpenseReportItem.Quantity = CInt(Quantity)

                    Else

                        ExpenseReportItem.Quantity = Nothing

                    End If

                    If Rate IsNot Nothing Then

                        ExpenseReportItem.Rate = CDec(Rate)

                    Else

                        ExpenseReportItem.Rate = Nothing

                    End If

                    ExpenseReportItem.Amount = CDec(Amount)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Amount.ToString Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(ExpenseReportItem.Quantity, ExpenseReportItem.Rate, e.Value, BillingSystem.QtyRateAmount.Amount)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.FunctionCode.ToString Then

                    LoadBillingRate(e.RowHandle)

                End If

                If ExpenseReportItem IsNot Nothing Then

                    ExpenseReportItem.ModifiedBy = _Session.UserCode
                    ExpenseReportItem.ModifiedDate = System.DateTime.Now

                End If

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewLineItems_LineItems.CustomRowCellEditEvent

            'objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing
            Dim JobNumber As Integer? = Nothing

            If DataGridViewLineItems_LineItems.CurrentView.IsRowLoaded(e.RowHandle) = True Then

                Try

                    JobNumber = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobNumber.ToString)

                Catch ex As Exception
                    JobNumber = Nothing
                End Try

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.NonBillable.ToString Then

                    If JobNumber.GetValueOrDefault(0) = 0 Then

                        e.RepositoryItem = _SubItemImageCheckEditControl_Blank

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewLineItems_LineItems.InitNewRowEvent

            _NewItemInitializing = True

            DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.InvoiceNumber.ToString, _InvoiceNumber)

            If _DefaultPaymentType.HasValue Then

                DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString, _DefaultPaymentType)

            End If

            RaiseEvent ExpenseDetailInitNewRowEvent()

            _NewItemInitializing = False

        End Sub
        Private Sub DataGridViewLineItems_LineItems_NewItemRowCanceledEvent() Handles DataGridViewLineItems_LineItems.NewItemRowCanceledEvent

            RaiseEvent ExpenseDetailNewRowCanceledEvent()

        End Sub
        Private Sub DataGridViewLineItems_LineItems_NewItemRowCellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewLineItems_LineItems.NewItemRowCellValueChangedEvent

            'objects
            Dim ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem = Nothing

            Try

                ExpenseReportItem = DataGridViewLineItems_LineItems.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                ExpenseReportItem = Nothing
            End Try

            If e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.FunctionCode.ToString Then

                LoadBillingRate(e.RowHandle)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Quantity.ToString Then

                If ExpenseReportItem IsNot Nothing Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(e.Value, ExpenseReportItem.Rate, ExpenseReportItem.Amount, BillingSystem.QtyRateAmount.Quantity)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Rate.ToString Then

                If ExpenseReportItem IsNot Nothing Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(ExpenseReportItem.Quantity, e.Value, ExpenseReportItem.Amount, BillingSystem.QtyRateAmount.Rate)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Amount.ToString Then

                If ExpenseReportItem IsNot Nothing Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(ExpenseReportItem.Quantity, ExpenseReportItem.Rate, e.Value, BillingSystem.QtyRateAmount.Amount)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ClientCode.ToString Then

                LoadBillingRate(e.RowHandle)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.DivisionCode.ToString Then

                LoadBillingRate(e.RowHandle)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ProductCode.ToString Then

                LoadBillingRate(e.RowHandle)

            End If

            If _NewItemInitializing = False Then

                If e.Column.FieldName <> AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ItemDate.ToString Then

                    If DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ItemDate.ToString) Is Nothing Then

                        DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ItemDate.ToString, System.DateTime.Today)

                    End If

                End If

                If e.Column.FieldName <> AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString Then

                    If DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString) Is Nothing Then

                        DataGridViewLineItems_LineItems.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString, AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_QueryPopupNeedDatasourceEvent(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewLineItems_LineItems.QueryPopupNeedDatasourceEvent

            'objects
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim EmployeeUserCodes As String() = Nothing
            Dim EmployeeCode As String = Nothing
            Dim UniqueKeyValues As String() = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentID As String = Nothing
            Dim JobComponent As AdvantageFramework.Database.Core.JobComponent = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim ExcludedJobProcessControlNumbers As Integer() = Nothing
            Dim JobComponentJobNumbers As Integer() = Nothing
            Dim AllowedProcessControlNumbers As Integer() = {1, 3, 4, 8, 9, 13}

            If SearchableComboBoxGeneral_Employee.HasASelectedValue Then

                EmployeeCode = SearchableComboBoxGeneral_Employee.GetSelectedValue

                UserClientDivisionProductAccessList = LoadEmployeeAccess(EmployeeCode)

                ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case FieldName

                        Case AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString

                            OverrideDefaultDatasource = True

                            JobNumber = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobNumber.ToString)
                            ClientCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ClientCode.ToString)
                            DivisionCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.DivisionCode.ToString)
                            ProductCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ProductCode.ToString)

                            Datasource = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, False, AllowedProcessControlNumbers)

                        Case AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobNumber.ToString

                            OverrideDefaultDatasource = True

                            ClientCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ClientCode.ToString)
                            DivisionCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.DivisionCode.ToString)
                            ProductCode = DataGridViewLineItems_LineItems.CurrentView.GetRowCellValue(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ProductCode.ToString)

                            Datasource = From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, Nothing, False, AllowedProcessControlNumbers)
                                         Join JobView In AdvantageFramework.Database.Procedures.JobView.Load(DbContext) On Item.JobNumber Equals JobView.JobNumber
                                         Group By [JN] = Item.JobNumber Into G = Group
                                         Select G.First.JobView

                        Case Else

                            OverrideDefaultDatasource = False

                    End Select

                    If OverrideDefaultDatasource AndAlso Datasource IsNot Nothing Then

                        Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_RepositoryDataSourceLoading(ByVal FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewLineItems_LineItems.RepositoryDataSourceLoading

            Select Case FieldName

                Case AdvantageFramework.Database.Classes.ExpenseItemImport.Properties.ClientCode.ToString,
                     AdvantageFramework.Database.Classes.ExpenseItemImport.Properties.DivisionCode.ToString,
                     AdvantageFramework.Database.Classes.ExpenseItemImport.Properties.ProductCode.ToString,
                     AdvantageFramework.Database.Classes.ExpenseItemImport.Properties.JobNumber.ToString,
                     AdvantageFramework.Database.Classes.ExpenseItemImport.Properties.JobComponentNumber.ToString

                    Cancel = True

            End Select

        End Sub
        Private Sub DataGridViewLineItems_LineItems_RowDoubleClickEvent() Handles DataGridViewLineItems_LineItems.RowDoubleClickEvent

            If _HasAccessToDocuments Then

                FilterDocuments(Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                RaiseEvent FilteredDocumentsEvent(Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                TabControlControl_ExpenseReportDetails.SelectedTab = TabItemExpenseReportDetails_ReceiptsTab

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLineItems_LineItems.SelectionChangedEvent

            If _Saving = False Then

                RaiseEvent LineItemsSelectionChangedEvent()

            End If

        End Sub
        Private Sub DataGridViewLineItems_LineItems_ShowingEditorEvent(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DataGridViewLineItems_LineItems.ShowingEditorEvent

            'objects
            Dim CanModify As Boolean = False

            If DataGridViewLineItems_LineItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.NonBillable.ToString OrElse
               DataGridViewLineItems_LineItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.HasDocuments.ToString Then

                e.Cancel = True

            ElseIf DataGridViewLineItems_LineItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Quantity.ToString OrElse
                    DataGridViewLineItems_LineItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Rate.ToString OrElse
                    DataGridViewLineItems_LineItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Amount.ToString Then

                If (_ClosedForEditing OrElse _IsCopy) Then

                    e.Cancel = True

                ElseIf DirectCast(DataGridViewLineItems_LineItems.CurrentView.GetRow(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.ExpenseReportItem).IsImported Then

                    If DirectCast(DataGridViewLineItems_LineItems.CurrentView.GetRow(DataGridViewLineItems_LineItems.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.ExpenseReportItem).CreatedBy.ToUpper = _Session.UserCode.ToUpper Then

                        CanModify = True

                    Else

                        CanModify = Not AdvantageFramework.Security.CanUserCustom2InModule(_Session, Security.Modules.Employee_ExpenseReports)

                    End If

                    e.Cancel = Not CanModify

                End If

            Else

                e.Cancel = (_ClosedForEditing OrElse _IsCopy)

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
