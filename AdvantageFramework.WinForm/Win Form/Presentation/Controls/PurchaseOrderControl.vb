Namespace WinForm.Presentation.Controls

    Public Class PurchaseOrderControl

        Public Event SelectedTabChangedEvent()
        Public Event NewItemRowOptionsEvent()
        Public Event SelectedDetailChangedEvent()
        Public Event NewPODetailEvent()
        Public Event DisplayNumberChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _PurchaseOrderNumber As Integer = Nothing
        Private _IsCopy As Boolean = False
        Private _CanUserPrint As Boolean = False
        Private _CanUserEdit As Boolean = False
        Private _CanUserInsert As Boolean = False
        Private _AllowPrint As Boolean = True
        Private _AllowCancelApproval As Boolean = False
        Private _AllowRevision As Boolean = True
        Private _POLocked As Boolean = False
        Private _GridViewPODetailsAPProduction As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _GridViewPODetailsAPGLDistribution As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _Estimating As Boolean = False
        Private _AllowGLAccountSelection As Boolean = False
        Private _LimitPOGLSelectionOffice As Boolean = False
        Private _UserCDPAccess As Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)) = Nothing
        Private _ApprovalFlag As Short? = Nothing
        Private _IsVoidedPO As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = TabControlControl_PODetails.SelectedTab
            End Get
        End Property
        Public ReadOnly Property DetailsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DetailsDataGridView = DataGridViewDetails_PODetails
            End Get
        End Property
        Public ReadOnly Property CanEstimate As Boolean
            Get

                'objects
                Dim Allowed As Boolean = False

                If DataGridViewDetails_PODetails.IsNewItemRow = True Then

                    If DataGridViewDetails_PODetails.CurrentView.GetRowCellValue(DataGridViewDetails_PODetails.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.PurchaseOrderDetail.Properties.JobNumber.ToString) IsNot Nothing Then

                        Allowed = True

                    End If

                End If

                CanEstimate = Allowed

            End Get
        End Property
        Public ReadOnly Property CanPrint As Boolean
            Get

                If _CanUserPrint Then

                    CanPrint = _AllowPrint

                Else

                    CanPrint = False

                End If

            End Get
        End Property
        Public ReadOnly Property CanSave As Boolean
            Get
                CanSave = _CanUserEdit
            End Get
        End Property
        Public ReadOnly Property CanCancelApproval As Boolean
            Get
                CanCancelApproval = _AllowCancelApproval
            End Get
        End Property
        Public ReadOnly Property CanDeleteSelectedItem As Boolean
            Get

                'objects
                Dim CanDelete As Boolean = False

                Try

                    If DataGridViewDetails_PODetails.HasASelectedRow Then

                        CanDelete = Not (From Entity In DataGridViewDetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                         Where Entity.CanDelete = False
                                         Select Entity).Any

                    End If

                Catch ex As Exception
                    CanDelete = False
                End Try

                CanDeleteSelectedItem = CanDelete

            End Get
        End Property
        Public ReadOnly Property POLocked As Boolean
            Get
                POLocked = _POLocked
            End Get
        End Property
        Public ReadOnly Property IsSelectedItemAttachedToAP As Boolean
            Get

                If DataGridViewDetails_PODetails.HasASelectedRow Then

                    Try

                        IsSelectedItemAttachedToAP = DirectCast(DataGridViewDetails_PODetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.PurchaseOrderDetail).IsAttachedToAP.GetValueOrDefault(False)

                    Catch ex As Exception
                        IsSelectedItemAttachedToAP = False
                    End Try

                Else

                    IsSelectedItemAttachedToAP = False

                End If

            End Get
        End Property
        Public ReadOnly Property CanCopySelectedItem As Boolean
            Get

                'objects
                Dim CanCopy As Boolean = False

                If DataGridViewDetails_PODetails.HasOnlyOneSelectedRow Then

                    If DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LockedByJobComp.ToString) = False Then

                        CanCopy = True

                    End If

                End If

                CanCopySelectedItem = CanCopy

            End Get
        End Property
        Public ReadOnly Property CanVoid As Boolean
            Get

                Dim AllowVoid As Boolean = True

                If Not _IsVoidedPO Then

                    If Me.DetailsDataGridView.HasRows AndAlso (From Entity In Me.DetailsDataGridView.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                                               Where Entity.IsAttachedToAP.GetValueOrDefault(False) = True
                                                               Select Entity).Any Then

                        AllowVoid = False

                    End If

                    If AllowVoid Then

                        If _ApprovalFlag.HasValue Then

                            If _ApprovalFlag.Value = AdvantageFramework.PurchaseOrders.ApprovalStatus.Pending OrElse _ApprovalFlag.Value = AdvantageFramework.PurchaseOrders.ApprovalStatus.Denied Then

                                AllowVoid = False

                            End If

                        End If

                    End If

                Else

                    AllowVoid = False

                End If

                CanVoid = AllowVoid

            End Get
        End Property
        Public Property DisplayPONumber As String
            Get
                Return TextBoxControl_PONumber.Text
            End Get
            Set(value As String)
                If value <> TextBoxControl_PONumber.Text Then
                    TextBoxControl_PONumber.Text = value
                    RaiseEvent DisplayNumberChangedEvent()
                End If
            End Set
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
                        _CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
                        _CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

                        NumericInputControl_POTotal.ByPassUserEntryChanged = True
                        NumericInputControl_EmployeeLimit.ByPassUserEntryChanged = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            _UserCDPAccess = New Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess))

                            DataGridViewDetails_PODetails.AutoFilterLookupColumns = True

                            TabControlControl_PODetails.SelectedTab = TabItemPODetails_DetailsTab

                            TextBoxControl_PONumber.Enabled = False
                            TextBoxControl_PONumber.ReadOnly = True
                            TextBoxControl_MessageDetails.ReadOnly = True
                            TextBoxControl_MessageDetails.BackColor = Drawing.Color.White
                            AddressControlControl_VendorAddress.ReadOnly = True
                            NumericInputControl_EmployeeLimit.Properties.ReadOnly = True
                            NumericInputControl_POTotal.Properties.ReadOnly = True
                            LabelGeneralInfo_ModifiedBy.Text = ""
                            LabelGeneralInfo_ModifiedDate.Text = ""
                            NumericInputControl_EmployeeLimit.Properties.Buttons.Clear()
                            NumericInputControl_POTotal.Properties.Buttons.Clear()

                            TextBoxControl_PONumber.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.Number)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.Description)
                            NumericInputControl_Revision.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.Revision)

                            SearchableComboBoxGeneralInfo_IssuedBy.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.EmployeeCode)
                            SearchableComboBoxGeneralInfo_IssuedTo.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.VendorCode)
                            DateTimePickerControl_DateIssued.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.Date)
                            DateTimePickerControl_DueDate.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.DueDate)
                            SearchableComboBoxGeneralInfo_VendorContact.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrder.Properties.VendorContactCode)
                            NumericInputControl_EmployeeLimit.SetPropertySettings(AdvantageFramework.Database.Views.Employee.Properties.PurchaseOrderLimit)

                        End Using

                        LoadDropDownDataSources()

                    End If

                    ExpandablePanelControl_General.HideControlsWhenCollapsed = False

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadPurchaseOrder(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            If PurchaseOrder IsNot Nothing Then

                LoadPurchaseOrderInfo(PurchaseOrder)
                LoadPurchaseOrderDetails(PurchaseOrder)

            End If

        End Sub
        Private Sub LoadPurchaseOrderInfo(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If PurchaseOrder IsNot Nothing Then

                TextBoxControl_Description.Text = PurchaseOrder.Description

                If _IsCopy = False Then

                    SearchableComboBoxGeneralInfo_IssuedBy.SelectedValue = PurchaseOrder.EmployeeCode
                    DateTimePickerControl_DateIssued.ValueObject = PurchaseOrder.Date
                    DateTimePickerControl_DueDate.ValueObject = PurchaseOrder.DueDate
                    CheckBoxControl_WorkComplete.Checked = CBool(PurchaseOrder.IsWorkComplete.GetValueOrDefault(0))
                    LabelGeneralInfo_ModifiedBy.Text = PurchaseOrder.ModifiedByUserCode

                    If PurchaseOrder.ModifiedDate.HasValue Then

                        LabelGeneralInfo_ModifiedDate.Text = PurchaseOrder.ModifiedDate.Value.ToShortDateString

                    End If

                Else

                    LabelGeneralInfo_ModifiedBy.Text = ""
                    LabelGeneralInfo_ModifiedDate.Text = ""
                    SearchableComboBoxGeneralInfo_IssuedBy.SelectedValue = _Session.User.EmployeeCode
                    DateTimePickerControl_DateIssued.ValueObject = System.DateTime.Today
                    DateTimePickerControl_DueDate.ValueObject = System.DateTime.Today
                    CheckBoxControl_WorkComplete.Checked = False

                End If

                LoadIssuedByEmployeeDetails()

                SearchableComboBoxGeneralInfo_IssuedTo.SelectedValue = PurchaseOrder.VendorCode

                If SearchableComboBoxGeneralInfo_IssuedTo.SelectedValue Is Nothing Then

                    If _IsCopy = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, PurchaseOrder.VendorCode)

                            If Vendor IsNot Nothing Then

                                SearchableComboBoxGeneralInfo_IssuedTo.AddComboItemToExistingDataSource(Vendor.ToString, Vendor.Code, True)
                                SearchableComboBoxGeneralInfo_IssuedTo.SelectedValue = Vendor.Code

                            End If

                        End Using

                    End If

                End If

                LoadIssuedToVendorDetails()

                If String.IsNullOrEmpty(PurchaseOrder.VendorContactCode) = False Then

                    SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = PurchaseOrder.VendorContactCode

                Else

                    SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = Nothing

                End If

                LoadSelectedVendorContactDetails()

                TextBoxPOInstructions_Instructions.Text = PurchaseOrder.MainInstruction
                TextBoxShippingInstructions_ShippingInstructions.Text = PurchaseOrder.DeliveryInstruction

                Select Case AdvantageFramework.PurchaseOrders.GetFooterType(PurchaseOrder.Footer)

                    Case PurchaseOrders.FooterTypes.AgencyDefined

                        RadioButtonControlFooter_UseAgencyDefined.Checked = True

                    Case PurchaseOrders.FooterTypes.StandardComment

                        RadioButtonControlFooter_UseStandardComment.Checked = True

                    Case PurchaseOrders.FooterTypes.Custom

                        RadioButtonControlFooter_UseCustom.Checked = True

                End Select

                LoadFooterComments()

            End If

        End Sub
        Private Sub LoadPurchaseOrderDetails(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If PurchaseOrder IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DataGridViewDetails_PODetails.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC [dbo].[advsp_load_po_details] {0}", PurchaseOrder.Number)).ToList

                    Catch ex As Exception

                    End Try

                    If DataGridViewDetails_PODetails.CurrentView.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString) IsNot Nothing Then

                        Try

                            DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString).OptionsColumn.AllowEdit = _AllowGLAccountSelection
                            DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString).Visible = _AllowGLAccountSelection

                            SubItemGridLookUpEditControl = DirectCast(DataGridViewDetails_PODetails.CurrentView.Columns("GeneralLedgerCode").ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                            SubItemGridLookUpEditControl.DataSource = AdvantageFramework.PurchaseOrders.LoadGeneralLedgerAccounts(DbContext, _Session)

                        Catch ex As Exception
                            SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)
                        End Try

                    End If

                    If DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString) IsNot Nothing Then

                        DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                    End If

                    If DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString) IsNot Nothing Then

                        DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                    End If

                    If DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.UseCPM.ToString) IsNot Nothing Then

                        DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.UseCPM.ToString).OptionsColumn.AllowEdit = False

                    End If

                    If DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsComplete.ToString) IsNot Nothing Then

                        DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsComplete.ToString).OptionsColumn.AllowEdit = False

                    End If

                    If DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString) IsNot Nothing Then

                        DataGridViewDetails_PODetails.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString).OptionsColumn.AllowEdit = False

                    End If

                End Using

                DataGridViewDetails_PODetails.CurrentView.BestFitColumns()

            End If

            CalculatePOTotal()

        End Sub
        Private Sub LoadIssuedByEmployeeDetails()

            'objects
            Dim EmployeeLimit As Object = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

            End Using

            If Employee IsNot Nothing Then

                _AllowGLAccountSelection = CBool(Employee.AllowPOGLSelection.GetValueOrDefault(0))
                _LimitPOGLSelectionOffice = CBool(Employee.LimitPOGLSelectionOffice.GetValueOrDefault(0))

            End If

            If SearchableComboBoxGeneralInfo_IssuedBy.HasASelectedValue Then

                If Employee.Code <> SearchableComboBoxGeneralInfo_IssuedBy.GetSelectedValue() Then

                    Employee = LoadPOEmployee()

                End If

                If Employee IsNot Nothing Then

                    EmployeeLimit = Employee.PurchaseOrderLimit

                Else

                    EmployeeLimit = Nothing

                End If

            End If

            NumericInputControl_EmployeeLimit.EditValue = EmployeeLimit

        End Sub
        Private Sub LoadIssuedToVendorDetails()

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorCode As String = Nothing
            Dim StandardFooterComment As String = Nothing

            SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = Nothing

            If SearchableComboBoxGeneralInfo_IssuedTo.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorCode = SearchableComboBoxGeneralInfo_IssuedTo.GetSelectedValue

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                    AdvantageFramework.PurchaseOrders.LoadVendorPayToInformation(DbContext, Vendor, "", "", TextBoxGeneralInfo_PayTo.Text, AddressControlControl_VendorAddress.Address, AddressControlControl_VendorAddress.Address2, "", AddressControlControl_VendorAddress.City,
                                                                                 AddressControlControl_VendorAddress.County, AddressControlControl_VendorAddress.State, AddressControlControl_VendorAddress.Zip, AddressControlControl_VendorAddress.Country, "", "", "", "")

                    If Vendor IsNot Nothing Then

                        SearchableComboBoxGeneralInfo_VendorContact.DataSource = From VendCont In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, Vendor.Code)
                                                                                 Where VendCont.IsInactive Is Nothing OrElse VendCont.IsInactive = 0
                                                                                 Select VendCont

                        If String.IsNullOrEmpty(Vendor.DefaultVendorContactCode) = False Then

                            SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = Vendor.DefaultVendorContactCode

                        End If

                    End If

                    StandardFooterComment = AdvantageFramework.PurchaseOrders.LoadStandardFooterComments(DbContext, VendorCode, False, _PurchaseOrderNumber)

                    If String.IsNullOrWhiteSpace(StandardFooterComment) = False Then

                        RadioButtonControlFooter_UseStandardComment.Checked = True
                        TextBoxFooterComments_FooterComments.Text = StandardFooterComment

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadSelectedVendorContactDetails()

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            TextBoxControl_EmailAddress.Text = Nothing

            If SearchableComboBoxGeneralInfo_IssuedTo.HasASelectedValue AndAlso SearchableComboBoxGeneralInfo_VendorContact.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, SearchableComboBoxGeneralInfo_IssuedTo.GetSelectedValue, SearchableComboBoxGeneralInfo_VendorContact.GetSelectedValue)

                    If VendorContact IsNot Nothing Then

                        TextBoxControl_EmailAddress.Text = VendorContact.Email

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadEntity(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            'objects
            Dim FooterType As AdvantageFramework.PurchaseOrders.FooterTypes = PurchaseOrders.FooterTypes.Custom

            If PurchaseOrder IsNot Nothing Then

                'PurchaseOrder.Number = CInt(TextBoxControl_PONumber.Text)
                PurchaseOrder.Description = TextBoxControl_Description.Text
                PurchaseOrder.EmployeeCode = SearchableComboBoxGeneralInfo_IssuedBy.GetSelectedValue
                PurchaseOrder.VendorCode = SearchableComboBoxGeneralInfo_IssuedTo.GetSelectedValue

                PurchaseOrder.Revision = NumericInputControl_Revision.GetValue

                If PurchaseOrder.Revision Is Nothing Then

                    PurchaseOrder.Revision = 0

                End If

                PurchaseOrder.Date = DateTimePickerControl_DateIssued.GetValue()
                PurchaseOrder.DueDate = DateTimePickerControl_DueDate.GetValue()
                PurchaseOrder.VendorContactCode = SearchableComboBoxGeneralInfo_VendorContact.GetSelectedValue
                PurchaseOrder.IsWorkComplete = CShort(CheckBoxControl_WorkComplete.CheckValue)
                PurchaseOrder.DeliveryInstruction = TextBoxShippingInstructions_ShippingInstructions.GetText
                PurchaseOrder.MainInstruction = TextBoxPOInstructions_Instructions.GetText

                If RadioButtonControlFooter_UseAgencyDefined.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.AgencyDefined

                ElseIf RadioButtonControlFooter_UseStandardComment.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.StandardComment

                ElseIf RadioButtonControlFooter_UseCustom.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.Custom

                End If

                PurchaseOrder.Footer = AdvantageFramework.PurchaseOrders.SetFooterText(FooterType, TextBoxFooterComments_FooterComments.Text)

                PurchaseOrder.ExceedFlag = 0

                If NumericInputControl_EmployeeLimit.EditValue IsNot Nothing Then

                    If If(NumericInputControl_POTotal.EditValue IsNot Nothing, NumericInputControl_POTotal.EditValue, 0) > NumericInputControl_EmployeeLimit.EditValue Then

                        PurchaseOrder.ExceedFlag = 1

                    End If

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            TextBoxControl_EmailAddress.Enabled = False

            TextBoxFooterComments_FooterComments.Enabled = RadioButtonControlFooter_UseCustom.Checked

            If _POLocked Then

                DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                TextBoxControl_Description.Enabled = False
                SearchableComboBoxGeneralInfo_IssuedTo.Enabled = False
                CheckBoxControl_WorkComplete.Enabled = False
                SearchableComboBoxGeneralInfo_VendorContact.Enabled = False
                TextBoxFooterComments_FooterComments.Enabled = False
                DateTimePickerControl_DateIssued.Enabled = False
                DateTimePickerControl_DueDate.Enabled = False

                RadioButtonControlFooter_UseCustom.Enabled = False
                RadioButtonControlFooter_UseAgencyDefined.Enabled = False
                RadioButtonControlFooter_UseStandardComment.Enabled = False

                TextBoxPOInstructions_Instructions.Enabled = _CanUserEdit
                TextBoxShippingInstructions_ShippingInstructions.Enabled = _CanUserEdit

            Else

                If _CanUserInsert = False Then

                    DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                End If

                If _CanUserEdit = False And _PurchaseOrderNumber > 0 Then

                    TextBoxControl_Description.Enabled = False
                    SearchableComboBoxGeneralInfo_IssuedTo.Enabled = False
                    DateTimePickerControl_DateIssued.Enabled = False
                    DateTimePickerControl_DueDate.Enabled = False
                    CheckBoxControl_WorkComplete.Enabled = False
                    SearchableComboBoxGeneralInfo_VendorContact.Enabled = False
                    TextBoxPOInstructions_Instructions.Enabled = False
                    TextBoxShippingInstructions_ShippingInstructions.Enabled = False
                    TextBoxFooterComments_FooterComments.Enabled = False

                    RadioButtonControlFooter_UseCustom.Enabled = False
                    RadioButtonControlFooter_UseAgencyDefined.Enabled = False
                    RadioButtonControlFooter_UseStandardComment.Enabled = False

                End If

            End If

        End Sub
        Private Sub SetPurchaseOrderTotal()

            'objects
            Dim PurchaseOrderTotal As Decimal = Nothing

            Try

                PurchaseOrderTotal = Nothing

            Catch ex As Exception
                PurchaseOrderTotal = Nothing
            Finally
                NumericInputControl_POTotal.EditValue = PurchaseOrderTotal
            End Try

        End Sub
        Private Function LoadNextPONumber() As Integer

            'objects
            Dim NextPONumber As Integer = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    NextPONumber = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrder.Load(DbContext)
                                    Select Entity.Number).Max + 1

                Catch ex As Exception
                    NextPONumber = 1
                End Try

            End Using

            LoadNextPONumber = NextPONumber

        End Function
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.PurchaseOrder

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrderApprovalRuleCode As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If IsNew Then

                        PurchaseOrder = New AdvantageFramework.Database.Entities.PurchaseOrder

                        PurchaseOrder.CreatedDate = System.DateTime.Now
                        PurchaseOrder.UserCode = _Session.UserCode

                        LoadEntity(PurchaseOrder)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                        If String.IsNullOrEmpty(Employee.PurchaseOrderApprovalRuleCode) = False Then

                            PurchaseOrderApprovalRuleCode = Employee.PurchaseOrderApprovalRuleCode

                        Else

                            Try

                                PurchaseOrderApprovalRuleCode = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, Employee.DepartmentTeamCode).PurchaseOrderApprovalRuleCode

                            Catch ex As Exception
                                PurchaseOrderApprovalRuleCode = Nothing
                            End Try

                        End If

                        PurchaseOrder.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode

                    Else

                        PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PurchaseOrderNumber)

                        If PurchaseOrder IsNot Nothing Then

                            LoadEntity(PurchaseOrder)

                        End If

                    End If

                End Using

            Catch ex As Exception
                PurchaseOrder = Nothing
            End Try

            FillObject = PurchaseOrder

        End Function
        Private Function SetupExistingPurchaseOrder(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            'objects
            Dim SetupComplete As Boolean = True
            Dim DisplayPONumber As String = ""
            Dim HeaderMessage As String = ""

            Try

                If PurchaseOrder IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(DbContext, PurchaseOrder, DisplayPONumber, _AllowPrint, _AllowCancelApproval, _AllowRevision, _POLocked, HeaderMessage)

                        TextBoxControl_PONumber.Text = DisplayPONumber
                        NumericInputControl_Revision.EditValue = PurchaseOrder.Revision

                        TextBoxControl_MessageDetails.Text = HeaderMessage

                        If PurchaseOrder.IsVoid.GetValueOrDefault(0) = 1 Then

                            _IsVoidedPO = True
                            Label_Void.Visible = True

                        Else

                            _IsVoidedPO = False
                            Label_Void.Visible = False

                        End If

                        _ApprovalFlag = PurchaseOrder.ApprovalFlag

                        If PurchaseOrder.ApprovalFlag.HasValue Then

                            Select Case PurchaseOrder.ApprovalFlag

                                Case AdvantageFramework.PurchaseOrders.ApprovalStatus.Denied

                                    DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    Label_Void.Visible = False

                                Case Else

                                    DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                            End Select

                        Else

                            DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                        End If

                        SearchableComboBoxGeneralInfo_IssuedBy.Enabled = False
                        SearchableComboBoxGeneralInfo_IssuedTo.Enabled = False
                        SearchableComboBoxGeneralInfo_VendorContact.Enabled = True

                        LoadPurchaseOrder(PurchaseOrder)

                    End Using

                Else

                    SetupComplete = False

                End If

            Catch ex As Exception
                SetupComplete = False
            Finally
                SetupExistingPurchaseOrder = SetupComplete
            End Try

        End Function
        Private Function SetupCopyPurchaseOrder(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

            'objects
            Dim SetupComplete As Boolean = True

            Try

                If PurchaseOrder IsNot Nothing Then

                    TextBoxControl_PONumber.Text = "(New)"
                    NumericInputControl_Revision.EditValue = 0
                    TextBoxControl_MessageDetails.Text = ""

                    SearchableComboBoxGeneralInfo_IssuedBy.SecurityEnabled = Not AdvantageFramework.PurchaseOrders.LimitPOToCurrentEmployee(_Session)
                    SearchableComboBoxGeneralInfo_IssuedTo.Enabled = True
                    SearchableComboBoxGeneralInfo_VendorContact.Enabled = True
                    DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                    LoadPurchaseOrder(PurchaseOrder)

                    If DataGridViewDetails_PODetails.HasRows Then

                        For Each PurchaseOrderDetail In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()

                            If PurchaseOrderDetail.LockedByJobComp = True Then

                                DataGridViewDetails_PODetails.CurrentView.DeleteFromDataSource(PurchaseOrderDetail)

                            End If

                        Next

                        DataGridViewDetails_PODetails.CurrentView.RefreshData()

                    End If

                Else

                    SetupComplete = False

                End If

                _AllowPrint = False
                _AllowCancelApproval = False
                _AllowRevision = False
                _POLocked = False

            Catch ex As Exception
                SetupComplete = False
            Finally
                SetupCopyPurchaseOrder = SetupComplete
            End Try

        End Function
        Private Function SetupNewPurchaseOrder()

            'objects
            Dim SetupComplete As Boolean = True

            Try

                TextBoxControl_PONumber.Text = "(New)"
                NumericInputControl_Revision.EditValue = 0
                TextBoxControl_MessageDetails.Text = ""

                Try

                    SearchableComboBoxGeneralInfo_IssuedBy.SelectedValue = _Session.User.EmployeeCode

                Catch ex As Exception

                End Try

                TabItemPODetails_DetailsTab.Visible = False
                SearchableComboBoxGeneralInfo_IssuedBy.SecurityEnabled = Not AdvantageFramework.PurchaseOrders.LimitPOToCurrentEmployee(_Session)
                SearchableComboBoxGeneralInfo_IssuedTo.Enabled = True
                SearchableComboBoxGeneralInfo_VendorContact.Enabled = True
                DataGridViewDetails_PODetails.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail))
                DataGridViewDetails_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                DateTimePickerControl_DateIssued.Value = System.DateTime.Today
                DateTimePickerControl_DueDate.ValueObject = Nothing
                RadioButtonControlFooter_UseAgencyDefined.Checked = True

                LoadFooterComments()

                _AllowPrint = False
                _AllowCancelApproval = False
                _AllowRevision = False
                _POLocked = False

            Catch ex As Exception
                SetupComplete = False
            Finally
                SetupNewPurchaseOrder = SetupComplete
            End Try

        End Function
        Private Sub CalculatePOTotal()

            'objects
            Dim Total As Decimal? = Nothing
            Dim PurchaseOrderDetails As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing

            Try

                PurchaseOrderDetails = (From Item In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)
                                        Where Item.ExtendedAmount.HasValue
                                        Select Item).ToList

                If PurchaseOrderDetails IsNot Nothing AndAlso PurchaseOrderDetails.Any Then

                    Total = PurchaseOrderDetails.Sum(Function(item) item.ExtendedAmount.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Total = Nothing
            End Try

            If Total.HasValue = True Then

                NumericInputControl_POTotal.EditValue = Total

            Else

                NumericInputControl_POTotal.EditValue = Nothing

            End If

        End Sub
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
        Private Sub LoadFooterComments()

            'objects
            Dim FooterComments As String = ""
            Dim FooterType As AdvantageFramework.PurchaseOrders.FooterTypes = Nothing
            Dim VendorCode As String = ""
            Dim TextBoxEnabled As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If RadioButtonControlFooter_UseAgencyDefined.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.AgencyDefined

                ElseIf RadioButtonControlFooter_UseStandardComment.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.StandardComment

                    VendorCode = SearchableComboBoxGeneralInfo_IssuedTo.GetSelectedValue

                ElseIf RadioButtonControlFooter_UseCustom.Checked Then

                    FooterType = PurchaseOrders.FooterTypes.Custom

                    TextBoxEnabled = True

                End If

                FooterComments = AdvantageFramework.PurchaseOrders.GetDisplayFooterTextByFooterType(DbContext, FooterType, _PurchaseOrderNumber, VendorCode)

            End Using

            TextBoxFooterComments_FooterComments.Text = FooterComments
            TextBoxFooterComments_FooterComments.Enabled = TextBoxEnabled

        End Sub
        Private Function LoadPOEmployee() As AdvantageFramework.Database.Views.Employee

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeCode As String = Nothing

            EmployeeCode = SearchableComboBoxGeneralInfo_IssuedBy.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            End Using

            LoadPOEmployee = Employee

        End Function
        Private Sub LoadPOBudgetComparisons(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            AdvantageFramework.PurchaseOrders.LoadPODetailEstimateInformation(DbContext, PurchaseOrderDetail)

            If _AllowGLAccountSelection Then

                AdvantageFramework.PurchaseOrders.LoadPOBudgetComparisons(DbContext, DateTimePickerControl_DateIssued.Value, PurchaseOrderDetail)

            End If

        End Sub
        Private Sub LoadPOBudgetComparisons(ByRef PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadPOBudgetComparisons(DbContext, PurchaseOrderDetail)

            End Using

        End Sub
        Private Sub CalculatePOUsedAndBalance(ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail, ByVal Difference As Decimal?)

            'objects
            Dim POUsed As Decimal = Nothing
            Dim Balance As Decimal = Nothing
            Dim PODetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim SetData As Boolean = False

            If PurchaseOrderDetail.EstimateBudgetNet.HasValue Then

                POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) + Difference.GetValueOrDefault(0)
                Balance = PurchaseOrderDetail.EstimateBudgetNet.GetValueOrDefault(0) - POUsed

                For RowHandle = 0 To DataGridViewDetails_PODetails.CurrentView.RowCount

                    SetData = False

                    Try

                        PODetail = DataGridViewDetails_PODetails.CurrentView.GetRow(RowHandle)

                    Catch ex As Exception

                    End Try

                    If PODetail IsNot Nothing Then

                        If PurchaseOrderDetail.JobNumber.HasValue Then

                            If PODetail.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                               PODetail.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber Then

                                SetData = True
                                PODetail.POUsed = POUsed
                                PODetail.BalanceNet = Balance

                            End If

                        ElseIf String.IsNullOrWhiteSpace(PurchaseOrderDetail.GeneralLedgerCode) = False Then

                            If PODetail.GeneralLedgerCode = PurchaseOrderDetail.GeneralLedgerCode Then

                                SetData = True

                            End If

                        End If

                        If SetData Then

                            DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString, POUsed)
                            DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString, Balance)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub HandleGLAAccountChanged(ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail, ByVal NewGLACode As String)

            'objects
            Dim POUsed As Decimal = Nothing
            Dim Balance As Decimal = Nothing
            Dim OldGLACode As String = Nothing
            Dim CurrentPOUsed As Decimal = Nothing
            Dim SavedPODetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim PODetailWithSameGLACode As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim PODetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            Try

                If _AllowGLAccountSelection Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OldGLACode = PurchaseOrderDetail.GeneralLedgerCode

                        PurchaseOrderDetail.GeneralLedgerCode = NewGLACode

                        If String.IsNullOrWhiteSpace(NewGLACode) = False Then

                            LoadPOBudgetComparisons(PurchaseOrderDetail)

                            SavedPODetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, PurchaseOrderDetail.PONumber, PurchaseOrderDetail.LineNumber)

                            If SavedPODetail IsNot Nothing Then

                                If SavedPODetail.GLACode <> NewGLACode Then

                                    Try

                                        PODetailWithSameGLACode = (From Entity In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                                                   Where Entity.GeneralLedgerCode = NewGLACode AndAlso
                                                                         Entity.EstimateBudgetNet.HasValue AndAlso
                                                                         Entity.LineNumber <> PurchaseOrderDetail.LineNumber
                                                                   Select Entity).FirstOrDefault

                                    Catch ex As Exception

                                    End Try

                                    If PODetailWithSameGLACode IsNot Nothing Then

                                        POUsed = PODetailWithSameGLACode.POUsed.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                                    Else

                                        POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                                    End If

                                ElseIf SavedPODetail.ExtendedAmount.GetValueOrDefault(0) <> PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) Then

                                    If SavedPODetail.ExtendedAmount.GetValueOrDefault(0) > PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) Then

                                        POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) - (SavedPODetail.ExtendedAmount.GetValueOrDefault(0) - PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))

                                    Else

                                        POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) + (PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) - SavedPODetail.ExtendedAmount.GetValueOrDefault(0))

                                    End If

                                Else

                                    POUsed = PurchaseOrderDetail.POUsed

                                End If

                                Balance = PurchaseOrderDetail.EstimateBudgetNet.GetValueOrDefault(0) - POUsed

                                PurchaseOrderDetail.POUsed = POUsed
                                PurchaseOrderDetail.BalanceNet = Balance

                            End If

                        Else

                            POUsed = Nothing
                            Balance = Nothing

                            PurchaseOrderDetail.EstimateBudgetNet = Nothing
                            PurchaseOrderDetail.POUsed = POUsed
                            PurchaseOrderDetail.BalanceNet = Balance

                        End If

                        For RowHandle = 0 To DataGridViewDetails_PODetails.CurrentView.RowCount - 1

                            PODetail = Nothing

                            Try

                                PODetail = DataGridViewDetails_PODetails.CurrentView.GetRow(RowHandle)

                            Catch ex As Exception
                                PODetail = Nothing
                            End Try

                            If PODetail IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PODetail.GeneralLedgerCode) = False Then

                                If PODetail.EstimateBudgetNet.HasValue Then

                                    If PODetail.GeneralLedgerCode = NewGLACode Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString, POUsed)
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString, Balance)

                                    ElseIf PODetail.GeneralLedgerCode = OldGLACode AndAlso String.IsNullOrWhiteSpace(OldGLACode) = False AndAlso PODetail.EstimateBudgetNet.HasValue Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString, PODetail.POUsed.GetValueOrDefault(0) - PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString, PODetail.BalanceNet.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))

                                    End If

                                End If

                            End If

                        Next

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub HandleEstimatePropertiesChanged(ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail, ByVal NewJobNumber As Integer?, ByVal NewJobComponentID As Integer?, ByVal NewFunctionCode As String)

            'objects
            Dim POUsed As Decimal = Nothing
            Dim Balance As Decimal = Nothing
            Dim OldJobNumber As Integer? = Nothing
            Dim OldJobComponentID As Integer? = Nothing
            Dim OldFunctionCode As String = Nothing
            Dim SavedPODetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim PODetailWithSameEstimateData As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim PODetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OldJobNumber = PurchaseOrderDetail.JobNumber
                    OldJobComponentID = PurchaseOrderDetail.JobComponentID
                    OldFunctionCode = PurchaseOrderDetail.FunctionCode

                    PurchaseOrderDetail.JobNumber = NewJobNumber

                    If NewJobComponentID <> PurchaseOrderDetail.JobComponentID Then

                        PurchaseOrderDetail.JobComponentNumber = Nothing

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, NewJobComponentID)

                        If JobComponent IsNot Nothing Then

                            PurchaseOrderDetail.JobComponentNumber = JobComponent.Number

                        End If

                    End If

                    PurchaseOrderDetail.JobComponentID = NewJobComponentID
                    PurchaseOrderDetail.FunctionCode = NewFunctionCode

                    LoadPOBudgetComparisons(PurchaseOrderDetail)

                    SavedPODetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, PurchaseOrderDetail.PONumber, PurchaseOrderDetail.LineNumber)

                    If SavedPODetail IsNot Nothing Then

                        If SavedPODetail.JobNumber <> NewJobNumber OrElse
                            SavedPODetail.JobComponentNumber <> JobComponent.Number OrElse
                            SavedPODetail.FunctionCode <> NewFunctionCode Then

                            Try

                                PODetailWithSameEstimateData = (From Entity In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                                                Where Entity.JobNumber = NewJobNumber AndAlso
                                                                      Entity.JobComponentID = NewJobComponentID AndAlso
                                                                      Entity.FunctionCode = NewFunctionCode AndAlso
                                                                      Entity.EstimateBudgetNet.HasValue AndAlso
                                                                      Entity.LineNumber <> PurchaseOrderDetail.LineNumber
                                                                Select Entity).FirstOrDefault

                            Catch ex As Exception

                            End Try

                            If PODetailWithSameEstimateData IsNot Nothing Then

                                POUsed = PODetailWithSameEstimateData.POUsed.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                            Else

                                POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                            End If

                        ElseIf SavedPODetail.ExtendedAmount.GetValueOrDefault(0) <> PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) Then

                            If SavedPODetail.ExtendedAmount.GetValueOrDefault(0) > PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) Then

                                POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) - (SavedPODetail.ExtendedAmount.GetValueOrDefault(0) - PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))

                            Else

                                POUsed = PurchaseOrderDetail.POUsed.GetValueOrDefault(0) + (PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) - SavedPODetail.ExtendedAmount.GetValueOrDefault(0))

                            End If

                        Else

                            POUsed = PurchaseOrderDetail.POUsed

                        End If

                        Balance = PurchaseOrderDetail.EstimateBudgetNet.GetValueOrDefault(0) - POUsed

                        PurchaseOrderDetail.POUsed = POUsed
                        PurchaseOrderDetail.BalanceNet = Balance

                        For RowHandle = 0 To DataGridViewDetails_PODetails.CurrentView.RowCount - 1

                            PODetail = Nothing

                            Try

                                PODetail = DataGridViewDetails_PODetails.CurrentView.GetRow(RowHandle)

                            Catch ex As Exception
                                PODetail = Nothing
                            End Try

                            If PODetail IsNot Nothing Then

                                If PODetail.EstimateBudgetNet.HasValue Then

                                    If PODetail.JobNumber = NewJobNumber AndAlso PODetail.JobComponentID = NewJobComponentID AndAlso PODetail.FunctionCode = NewFunctionCode Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString, POUsed)
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString, Balance)

                                    ElseIf PODetail.JobNumber = OldJobNumber AndAlso PODetail.JobComponentID = OldJobComponentID AndAlso
                                           PODetail.FunctionCode = OldFunctionCode AndAlso OldJobNumber.HasValue AndAlso OldJobComponentID.HasValue AndAlso PODetail.EstimateBudgetNet.HasValue Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString, PODetail.POUsed.GetValueOrDefault(0) - PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString, PODetail.BalanceNet.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0))

                                    End If

                                End If

                            End If

                        Next

                    End If

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SearchableComboBoxGeneralInfo_IssuedBy.DataSource = AdvantageFramework.PurchaseOrders.LoadEmployees(_Session, DbContext, SecurityDbContext)

                    SearchableComboBoxGeneralInfo_IssuedTo.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session)

                End Using

            End Using

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
            Dim RowHandles As Generic.Dictionary(Of String, Object) = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False
            Dim ExceedMessage As String = ""
            Dim CancelSave As Boolean = False
            Dim Message As String = ""
            Dim POTotal As Decimal = Nothing

            If _CanUserEdit Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PurchaseOrder = Me.FillObject(False)

                        If PurchaseOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(PurchaseOrder.PurchaseOrderApprovalRuleCode) Then

                                If PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 1 Then

                                    CancelSave = True
                                    ErrorMessage = "The PO total exceeds the limit ($" & NumericInputControl_EmployeeLimit.Value.ToString & ") for selected employee."

                                End If

                            End If

                            If CancelSave = False Then

                                If AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder) Then

                                    Saved = True

                                    DataGridViewDetails_PODetails.CurrentView.CloseEditorForUpdating()

                                    PurchaseOrderDetails = DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)().ToList

                                    For Each PurchaseOrderDetail In PurchaseOrderDetails

                                        Message = ""

                                        AdvantageFramework.PurchaseOrders.UpdatePODetail(DbContext, PurchaseOrderDetail, Message)

                                        If Message <> "" Then

                                            If ExceedMessage <> "" Then

                                                ExceedMessage &= vbNewLine & vbNewLine

                                            End If

                                            ExceedMessage &= Message

                                        End If

                                    Next

                                End If

                            End If

                        End If

                    End Using

                    If ExceedMessage <> "" Then

                        AdvantageFramework.Navigation.ShowMessageBox(ExceedMessage)

                    End If

                    If Not Saved Then

                        If ErrorMessage = "" Then

                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                End Try

                If ErrorMessage <> "" Then

                    Throw New System.Exception(ErrorMessage)

                End If

            End If

            Save = Saved

        End Function
        Public Function Void() As Boolean

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim ErrorMessage As String = ""
            Dim Voided As Boolean = False

            If _CanUserEdit Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PurchaseOrder = Me.FillObject(False)

                        If PurchaseOrder IsNot Nothing Then

                            Voided = AdvantageFramework.PurchaseOrders.Void(DbContext, PurchaseOrder)

                        End If

                    End Using

                Catch ex As Exception
                    ErrorMessage = "Failed trying to void the purchase order. Please contact software support."
                End Try

                If ErrorMessage <> "" Then

                    Throw New System.Exception(ErrorMessage)

                End If

            End If

            Void = Voided

        End Function
        Public Function DeleteSelectedItem() As Boolean

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim Deleted As Boolean = False
            Dim DisplayPONumber As String = ""

            If _CanUserEdit Then

                If DataGridViewDetails_PODetails.HasASelectedRow Then

                    DataGridViewDetails_PODetails.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each PurchaseOrderDetail In DataGridViewDetails_PODetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail).ToList

                                    If PurchaseOrderDetail IsNot Nothing AndAlso PurchaseOrderDetail.CanDelete.GetValueOrDefault(False) = True Then

                                        If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Delete(DbContext, PurchaseOrderDetail.PONumber, PurchaseOrderDetail.LineNumber) = True Then

                                            Deleted = True

                                            DataGridViewDetails_PODetails.CurrentView.DeleteFromDataSource(PurchaseOrderDetail)

                                        End If

                                    End If

                                Next

                                If DataGridViewDetails_PODetails.HasRows = False Then

                                    AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(DbContext, _PurchaseOrderNumber, Me.DisplayPONumber, _AllowPrint, _AllowCancelApproval, _AllowRevision, _POLocked, "")

                                End If

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            End If

            CalculatePOTotal()

            DeleteSelectedItem = Deleted

        End Function
        Public Sub Estimate(ByVal Automatic As Boolean)

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim EstimateRevisionDetail As AdvantageFramework.Database.Entities.EstimateRevisionDetail = Nothing
            Dim FocusedRowHandle As Integer = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim Quantity As Decimal = Nothing
            Dim Rate As Decimal = Nothing
            Dim ExtendedAmount As Decimal = Nothing
            Dim CommissionPercent As Decimal = Nothing
            Dim ExtendedMarkupAmount As Decimal = Nothing
            Dim FunctionCode As String = Nothing
            Dim FunctionDescription As String = Nothing
            Dim HasDetails As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim Estimated As Boolean = False

            If _Estimating = False Then

                _Estimating = True

                If DataGridViewDetails_PODetails.IsNewItemRow = True Then

                    FocusedRowHandle = DataGridViewDetails_PODetails.CurrentView.FocusedRowHandle

                    Try

                        PurchaseOrderDetail = DirectCast(DataGridViewDetails_PODetails.CurrentView.GetRow(FocusedRowHandle), AdvantageFramework.Database.Classes.PurchaseOrderDetail)

                    Catch ex As Exception
                        PurchaseOrderDetail = Nothing
                    End Try

                    If PurchaseOrderDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If PurchaseOrderDetail.JobComponentNumber.HasValue = False AndAlso PurchaseOrderDetail.JobComponentID.HasValue Then

                                Try

                                    PurchaseOrderDetail.JobComponentNumber = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, PurchaseOrderDetail.JobComponentID).Number

                                Catch ex As Exception
                                    PurchaseOrderDetail.JobComponentNumber = Nothing
                                End Try

                            End If

                            JobNumber = PurchaseOrderDetail.JobNumber.GetValueOrDefault(0)
                            JobComponentNumber = PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0)
                            FunctionCode = PurchaseOrderDetail.FunctionCode

                            EstimateRevisionDetail = AdvantageFramework.PurchaseOrders.EstimateItem(DbContext, JobNumber, JobComponentNumber, HasDetails, ErrorMessage, FunctionCode)

                            If Automatic Then

                                If EstimateRevisionDetail IsNot Nothing Then

                                    Estimated = True

                                    Quantity = CDec(EstimateRevisionDetail.Quantity)
                                    Rate = CDec(EstimateRevisionDetail.RateAmount)
                                    ExtendedAmount = CDec(EstimateRevisionDetail.ExtendedAmount)
                                    CommissionPercent = CDec(EstimateRevisionDetail.CommissionPercent)
                                    ExtendedMarkupAmount = CDec(EstimateRevisionDetail.MarkupAmount)
                                    FunctionCode = EstimateRevisionDetail.FunctionCode

                                End If

                            ElseIf HasDetails Then

                                If AdvantageFramework.ProjectManagement.Presentation.ExistingEstimateFunctionsDialog.ShowFormDialog(JobNumber, JobComponentNumber, Quantity, Rate, ExtendedAmount,
                                                                                                                                    CommissionPercent, ExtendedMarkupAmount, FunctionCode) = Windows.Forms.DialogResult.OK Then

                                    Estimated = True

                                End If

                            Else

                                Estimated = False

                                If String.IsNullOrEmpty(ErrorMessage) = False Then

                                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                                End If

                            End If

                            If Estimated Then

                                FunctionDescription = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode).Description

                                PurchaseOrderDetail.JobNumber = JobNumber
                                PurchaseOrderDetail.JobComponentNumber = JobComponentNumber
                                PurchaseOrderDetail.Quantity = Quantity
                                PurchaseOrderDetail.Rate = Rate
                                PurchaseOrderDetail.ExtendedAmount = ExtendedAmount
                                PurchaseOrderDetail.CommissionPercent = CommissionPercent
                                PurchaseOrderDetail.ExtendedMarkupAmount = ExtendedMarkupAmount
                                PurchaseOrderDetail.FunctionCode = FunctionCode
                                PurchaseOrderDetail.FunctionDescription = FunctionDescription

                                DataGridViewDetails_PODetails.CurrentView.RefreshRow(FocusedRowHandle)

                            End If

                        End Using

                    End If

                End If

                _Estimating = False

            End If

        End Sub
        Public Function Revise() As Boolean

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim ErrorMessage As String = ""
            Dim Revised As Boolean = False

            If _CanUserEdit Then

                Try

                    PurchaseOrder = Me.FillObject(False)

                    If PurchaseOrder IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.PurchaseOrders.Revise(DbContext, PurchaseOrder) Then

                                Revised = True

                                NumericInputControl_Revision.EditValue = PurchaseOrder.Revision

                            End If

                        End Using

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to revise the purchase order. Please contact software support."
                End Try

            End If

            Revise = Revised

        End Function
        Public Sub CheckSpelling()

            If TabControlControl_PODetails.SelectedTab Is TabItemPODetails_FooterCommentsTab Then

                TextBoxFooterComments_FooterComments.CheckSpelling()

            ElseIf TabControlControl_PODetails.SelectedTab Is TabItemPODetails_POInstructionsTab Then

                TextBoxPOInstructions_Instructions.CheckSpelling()

            ElseIf TabControlControl_PODetails.SelectedTab Is TabItemPODetails_ShippingInstructionsTab Then

                TextBoxShippingInstructions_ShippingInstructions.CheckSpelling()

            End If

        End Sub
        Public Function Insert(ByRef PONUmber As Integer) As Boolean

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim POApprovalCode As String = Nothing

            If _CanUserInsert Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PurchaseOrder = Me.FillObject(True)

                        If PurchaseOrder IsNot Nothing Then

                            PurchaseOrder.DbContext = DbContext

                            PurchaseOrder.Number = Nothing

                            Inserted = AdvantageFramework.Database.Procedures.PurchaseOrder.Insert(DbContext, PurchaseOrder)

                            If Inserted Then

                                If _IsCopy Then

                                    For Each RowsRowHandlesAndDataBoundItem In DataGridViewDetails_PODetails.GetAllRowsRowHandlesAndDataBoundItems

                                        Try

                                            PurchaseOrderDetail = RowsRowHandlesAndDataBoundItem.Value

                                        Catch ex As Exception
                                            PurchaseOrderDetail = Nothing
                                        End Try

                                        If PurchaseOrderDetail IsNot Nothing Then

                                            AdvantageFramework.PurchaseOrders.CopyPurchaseOrderDetail(DbContext, PurchaseOrderDetail, PurchaseOrder.Number)

                                        End If

                                    Next

                                End If

                                PONUmber = PurchaseOrder.Number

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ErrorMessage = "Failed trying to insert into the database. Please contact software support."
                End Try

                If ErrorMessage <> "" Then

                    Throw New System.Exception(ErrorMessage)

                End If

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal PurchaseOrderNumber As Integer, Optional ByVal IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Editable As Boolean = True
            Dim HeaderMessage As String = ""
            Dim DisplayPONumber As String = Nothing
            Dim Revision As Short = Nothing
            Dim TopPanelVisible As Boolean = False

            _PurchaseOrderNumber = PurchaseOrderNumber
            _IsCopy = IsCopy
            _ApprovalFlag = Nothing
            _IsVoidedPO = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _PurchaseOrderNumber <> Nothing Then

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PurchaseOrderNumber)

                    If PurchaseOrder IsNot Nothing AndAlso _IsCopy = False Then

                        Loaded = SetupExistingPurchaseOrder(PurchaseOrder)

                    ElseIf PurchaseOrder IsNot Nothing AndAlso _IsCopy = True Then

                        Loaded = SetupCopyPurchaseOrder(PurchaseOrder)

                    Else

                        Loaded = False

                    End If

                Else

                    Loaded = SetupNewPurchaseOrder()

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            TextBoxControl_PONumber.Text = Nothing
            TextBoxControl_Description.Text = Nothing
            NumericInputControl_Revision.EditValue = Nothing
            SearchableComboBoxGeneralInfo_IssuedBy.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_IssuedTo.SelectedValue = Nothing
            DateTimePickerControl_DateIssued.ValueObject = Nothing
            DateTimePickerControl_DueDate.ValueObject = Nothing
            CheckBoxControl_WorkComplete.Checked = False
            SearchableComboBoxGeneralInfo_VendorContact.SelectedValue = Nothing
            TextBoxControl_EmailAddress.Text = Nothing
            NumericInputControl_EmployeeLimit.EditValue = Nothing
            NumericInputControl_POTotal.EditValue = Nothing
            DataGridViewDetails_PODetails.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail))
            SearchableComboBoxGeneralInfo_VendorContact.DataSource = Nothing 'New Generic.List(Of AdvantageFramework.Database.Entities.VendorContact)
            AddressControlControl_VendorAddress.ClearControl()
            TextBoxFooterComments_FooterComments.Text = Nothing
            TextBoxPOInstructions_Instructions.Text = Nothing
            TextBoxShippingInstructions_ShippingInstructions.Text = Nothing
            TextBoxControl_MessageDetails.Text = Nothing
            LabelGeneralInfo_ModifiedBy.Text = Nothing
            LabelGeneralInfo_ModifiedDate.Text = Nothing

            TextBoxControl_Description.Enabled = True
            SearchableComboBoxGeneralInfo_IssuedTo.Enabled = True
            DateTimePickerControl_DateIssued.Enabled = True
            DateTimePickerControl_DueDate.Enabled = True
            CheckBoxControl_WorkComplete.Enabled = True
            SearchableComboBoxGeneralInfo_VendorContact.Enabled = True
            TextBoxControl_EmailAddress.Enabled = False
            TextBoxPOInstructions_Instructions.Enabled = True
            TextBoxShippingInstructions_ShippingInstructions.Enabled = True
            TextBoxFooterComments_FooterComments.Enabled = True
            RadioButtonControlFooter_UseAgencyDefined.Enabled = True
            RadioButtonControlFooter_UseCustom.Enabled = True
            RadioButtonControlFooter_UseStandardComment.Enabled = True

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function SubmitForApprovalOrPrint() As Boolean

            'objects
            Dim ErrorMessage As String = ""
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim DisplayPONumber As String = Nothing
            Dim SubmittedOrPrinted As Boolean = False
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If DataGridViewDetails_PODetails.HasRows = True Then

                        PurchaseOrder = Me.FillObject(False)

                        DisplayPONumber = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDisplayNumber(DbContext, PurchaseOrder.Number)

                        DisplayPONumber = DisplayPONumber.Replace(" ", "")

                        If PurchaseOrder.ApprovalFlag.HasValue = True AndAlso PurchaseOrder.ApprovalFlag = AdvantageFramework.PurchaseOrders.ApprovalStatus.Pending Then

                            ErrorMessage = "This purchase order is pending approval and cannot be printed."

                        ElseIf (DisplayPONumber = "" OrElse IsNumeric(DisplayPONumber) = False) AndAlso CBool(PurchaseOrder.ExceedFlag.GetValueOrDefault(0)) = True Then

                            If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSubmitDialog.ShowFormDialog(PurchaseOrder.Number) = Windows.Forms.DialogResult.OK Then

                                SubmittedOrPrinted = True

                            End If

                        Else

                            If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderReportsDialog.ShowFormDialog(False, ParameterDictionary, New Integer() {PurchaseOrder.Number}, Printed:=SubmittedOrPrinted) = Windows.Forms.DialogResult.OK Then

                                SubmittedOrPrinted = True

                            End If

                        End If

                    Else

                        ErrorMessage = "Please insert at least one line item."

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "There was a problem printing the purchase order. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New Exception(ErrorMessage)

            End If

            SubmitForApprovalOrPrint = SubmittedOrPrinted

        End Function
        Public Function CancelApproval() As Boolean

            'objects
            Dim ErrorMessage As String = ""
            Dim Canceled As Boolean = False
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrder = Me.FillObject(False)

                If PurchaseOrder IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Canceled = AdvantageFramework.PurchaseOrders.CancelApproval(DbContext, _PurchaseOrderNumber)

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem canceling approval for the purchase order. Please contact software support."
                Canceled = False
            Finally
                CancelApproval = Canceled
            End Try

        End Function
        Public Function CopySelectedItem()

            'objects
            Dim SelectedPurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim NewPurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim LineNumber As Short = Nothing
            Dim Copied As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                If DataGridViewDetails_PODetails.HasOnlyOneSelectedRow Then

                    SelectedPurchaseOrderDetail = DataGridViewDetails_PODetails.GetFirstSelectedRowDataBoundItem

                    If SelectedPurchaseOrderDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.PurchaseOrders.CopyPurchaseOrderDetail(DbContext, SelectedPurchaseOrderDetail, SelectedPurchaseOrderDetail.PONumber, LineNumber) Then

                                Copied = True

                                Try

                                    NewPurchaseOrderDetail = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC advsp_load_po_details {0}", SelectedPurchaseOrderDetail.PONumber)).ToList
                                                              Where Entity.LineNumber = LineNumber
                                                              Select Entity).SingleOrDefault

                                    DirectCast(DirectCast(DataGridViewDetails_PODetails.DataSource, System.Windows.Forms.BindingSource).DataSource, Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)).Add(NewPurchaseOrderDetail)

                                    DataGridViewDetails_PODetails.CurrentView.RefreshData()

                                Catch ex As Exception

                                End Try

                                CalculatePOTotal()

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem copying the selected item. Please contact software support."
            Finally

                CopySelectedItem = Copied

                If ErrorMessage <> "" Then

                    Throw New Exception(ErrorMessage)

                End If

            End Try

        End Function
        Public Function AutoGenerateItems()

            'objects
            Dim ErrorMessage As String = ""
            Dim Created As Boolean = False

            If _CanUserInsert Then

                Try

                    If AdvantageFramework.ProjectManagement.Presentation.POEstimateApprovalSelectionDialog.ShowFormDialog(_PurchaseOrderNumber) = Windows.Forms.DialogResult.OK Then

                        Created = True

                    End If

                Catch ex As Exception
                    ErrorMessage = "There was a problem creating items from the selected job & component. Please contact software support."
                End Try

                If ErrorMessage <> "" Then

                    Throw New Exception(ErrorMessage)

                End If

            End If

            AutoGenerateItems = Created

        End Function
        Public Sub ViewAPInfo()

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            If DataGridViewDetails_PODetails.HasOnlyOneSelectedRow Then

                PurchaseOrderDetail = DataGridViewDetails_PODetails.GetFirstSelectedRowDataBoundItem

                If PurchaseOrderDetail IsNot Nothing Then

                    If PurchaseOrderDetail.IsAttachedToAP.GetValueOrDefault(False) = True Then

                        AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderAPDetailDialog.ShowFormDialog(PurchaseOrderDetail.PONumber, PurchaseOrderDetail.LineNumber)

                    End If

                End If

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PurchaseOrderControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewDetails_PODetails_BeforeAddNewRowEvent(ByVal RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewDetails_PODetails.BeforeAddNewRowEvent

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim POTotal As Decimal = Nothing

            Dim Message As String = ""

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.PurchaseOrderDetail Then

                PurchaseOrderDetail = DirectCast(RowObject, AdvantageFramework.Database.Classes.PurchaseOrderDetail).GetPurchaseOrderDetail()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If PurchaseOrderDetail.IsEntityBeingAdded() Then

                        Cancel = Not AdvantageFramework.PurchaseOrders.ValidatePODetailEstimateApproval(DbContext, PurchaseOrderDetail, True, Message)

                        If Cancel = False Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SearchableComboBoxGeneralInfo_IssuedBy.GetSelectedValue.ToString)

                            If String.IsNullOrEmpty(Employee.PurchaseOrderApprovalRuleCode) AndAlso Employee.PurchaseOrderLimit.HasValue Then

                                Try

                                    POTotal = (From Entity In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                               Select Entity.ExtendedAmount.GetValueOrDefault(0)).Sum

                                Catch ex As Exception
                                    POTotal = Nothing
                                End Try

                                POTotal = POTotal + PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                                If POTotal > Employee.PurchaseOrderLimit.Value Then

                                    Message = "The PO total exceeds the limit ($" & Employee.PurchaseOrderLimit.Value.ToString & ") for selected employee."
                                    Cancel = True

                                End If

                            End If

                        End If

                        If String.IsNullOrEmpty(Message) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(Message, MessageBox.MessageBoxButtons.OK)

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_AddNewRowEvent(RowObject As Object) Handles DataGridViewDetails_PODetails.AddNewRowEvent

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.PurchaseOrderDetail Then

                Me.ShowWaitForm("Processing...")

                PurchaseOrderDetail = DirectCast(RowObject, AdvantageFramework.Database.Classes.PurchaseOrderDetail).GetPurchaseOrderDetail()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If PurchaseOrderDetail.IsEntityBeingAdded() Then

                        PurchaseOrderDetail.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

                        AdvantageFramework.PurchaseOrders.LoadPODetailEstimateInformation(DbContext, DirectCast(RowObject, AdvantageFramework.Database.Classes.PurchaseOrderDetail))

                        If _AllowGLAccountSelection Then

                            AdvantageFramework.PurchaseOrders.LoadPOBudgetComparisons(DbContext, DateTimePickerControl_DateIssued.Value, DirectCast(RowObject, AdvantageFramework.Database.Classes.PurchaseOrderDetail))

                        End If

                        AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(DbContext, _PurchaseOrderNumber, Me.DisplayPONumber, _AllowPrint, _AllowCancelApproval, _AllowRevision, _POLocked, "")

                        RaiseEvent NewPODetailEvent()

                    End If

                End Using

                RaiseEvent SelectedDetailChangedEvent()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDetails_PODetails.CellValueChangedEvent

            'objects
            Dim FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim OfficeCode As String = Nothing
            Dim GLACode As String = Nothing
            Dim CPMFlag As Boolean = False
            Dim JobNbr As String = Nothing
            Dim JobCompNbr As String = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim GlOfficeCode As String = Nothing

            Try

                PurchaseOrderDetail = DirectCast(DataGridViewDetails_PODetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Catch ex As Exception
                PurchaseOrderDetail = Nothing
            End Try

            If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Quantity.ToString OrElse
                e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString OrElse
                e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedAmount.ToString Then

                If PurchaseOrderDetail IsNot Nothing Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Quantity.ToString

                            FieldChanged = BillingSystem.QtyRateAmount.Quantity

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString

                            FieldChanged = BillingSystem.QtyRateAmount.Rate

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedAmount.ToString

                            FieldChanged = BillingSystem.QtyRateAmount.Amount

                    End Select

                    OldAmount = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(PurchaseOrderDetail.Quantity, PurchaseOrderDetail.Rate, PurchaseOrderDetail.ExtendedAmount, FieldChanged, 0, 3, 2, PurchaseOrderDetail.UseCPM.GetValueOrDefault(False))

                    If FieldChanged <> BillingSystem.QtyRateAmount.Amount Then

                        CalculatePOUsedAndBalance(PurchaseOrderDetail, PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) - OldAmount)

                    End If

                End If

                CalculatePOTotal()

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedMarkupAmount.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString Then

                CalculatePOTotal()

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString Then

                If e.Value IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Value)

                        If [Function] IsNot Nothing Then

                            If _AllowGLAccountSelection Then

                                If PurchaseOrderDetail IsNot Nothing AndAlso PurchaseOrderDetail.JobNumber.HasValue = False Then

                                    If String.IsNullOrEmpty([Function].OverheadGLACode) = False Then

                                        If (From Gl In AdvantageFramework.PurchaseOrders.LoadGeneralLedgerAccounts(DbContext, _Session)
                                            Where Gl.Code = [Function].OverheadGLACode
                                            Select Gl).Any Then

                                            GLACode = [Function].OverheadGLACode

                                        End If

                                    End If

                                End If

                            End If

                            CPMFlag = CBool([Function].CPMFlag.GetValueOrDefault(0))

                            If PurchaseOrderDetail IsNot Nothing Then

                                If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) > 0 Then

                                    JobNbr = CStr(PurchaseOrderDetail.JobNumber)

                                End If

                                If PurchaseOrderDetail.JobComponentNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                    JobCompNbr = CStr(PurchaseOrderDetail.JobComponentNumber)

                                End If

                                BillingRate = AdvantageFramework.PurchaseOrders.LoadBillingRate(DbContext, e.Value, PurchaseOrderDetail.ClientCode, PurchaseOrderDetail.DivisionCode, PurchaseOrderDetail.ProductCode, JobNbr, JobCompNbr)

                                If BillingRate IsNot Nothing Then

                                    If BillingRate.BILLING_RATE.HasValue Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString, If(BillingRate.COMM.HasValue, BillingRate.COMM.Value, Nothing))
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString, If(BillingRate.BILLING_RATE.HasValue, BillingRate.BILLING_RATE.Value, Nothing))

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End If

                DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString, GLACode)
                DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.UseCPM.ToString, CPMFlag)

                CalculatePOTotal()

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                If e.Value IsNot Nothing Then

                    HandleGLAAccountChanged(PurchaseOrderDetail, Nothing)

                    DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString, Nothing)

                End If

                If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                    If e.Value IsNot Nothing Then

                        If PurchaseOrderDetail IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) > 0 Then

                                    JobNbr = CStr(PurchaseOrderDetail.JobNumber)

                                End If

                                If PurchaseOrderDetail.JobComponentNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                    JobCompNbr = CStr(PurchaseOrderDetail.JobComponentNumber)

                                End If

                                BillingRate = AdvantageFramework.PurchaseOrders.LoadBillingRate(DbContext, PurchaseOrderDetail.FunctionCode, PurchaseOrderDetail.ClientCode, PurchaseOrderDetail.DivisionCode, PurchaseOrderDetail.ProductCode, JobNbr, JobCompNbr)

                                If BillingRate IsNot Nothing Then

                                    If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then

                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString, If(BillingRate.COMM.HasValue, BillingRate.COMM.Value, Nothing))
                                        DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString, If(BillingRate.BILLING_RATE.HasValue, BillingRate.BILLING_RATE.Value, Nothing))

                                    End If

                                    'Else

                                    '    DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString, Nothing)
                                    '    DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString, Nothing)

                                End If

                            End Using

                        End If

                    End If

                End If

                LoadPOBudgetComparisons(PurchaseOrderDetail)

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDetails_PODetails.CellValueChangingEvent

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim Difference As Decimal = Nothing
            Dim NewAmount As Decimal = Nothing
            Dim NewJobNumber As Nullable(Of Integer) = Nothing
            Dim NewJobComponentID As Nullable(Of Integer) = Nothing
            Dim SpinEdit As DevExpress.XtraEditors.SpinEdit = Nothing
            Dim CurrentExtendedAmount As Decimal = Nothing

            Try

                PurchaseOrderDetail = DataGridViewDetails_PODetails.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception

            End Try

            If PurchaseOrderDetail IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedAmount.ToString Then

                    Try

                        NewAmount = CDec(e.Value)

                    Catch ex As Exception

                    End Try

                    Dim RealVal As Object = Nothing

                    If TypeOf DataGridViewDetails_PODetails.CurrentView.ActiveEditor Is DevExpress.XtraEditors.SpinEdit Then

                        SpinEdit = CType(DataGridViewDetails_PODetails.CurrentView.ActiveEditor, DevExpress.XtraEditors.SpinEdit)

                        CurrentExtendedAmount = SpinEdit.EditValue

                    Else

                        CurrentExtendedAmount = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

                    End If

                    CalculatePOUsedAndBalance(PurchaseOrderDetail, NewAmount - CurrentExtendedAmount)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                    HandleGLAAccountChanged(PurchaseOrderDetail, e.Value)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString Then

                    NewJobNumber = If(IsNumeric(e.Value), CInt(e.Value), Nothing)

                    HandleEstimatePropertiesChanged(PurchaseOrderDetail, NewJobNumber, PurchaseOrderDetail.JobComponentID, PurchaseOrderDetail.FunctionCode)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                    NewJobComponentID = If(IsNumeric(e.Value), CInt(e.Value), Nothing)

                    HandleEstimatePropertiesChanged(PurchaseOrderDetail, PurchaseOrderDetail.JobNumber, NewJobComponentID, PurchaseOrderDetail.FunctionCode)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString Then

                    HandleEstimatePropertiesChanged(PurchaseOrderDetail, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentID, e.Value)

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewDetails_PODetails.CustomDrawCellEvent

            'objects
            Dim IsAttachedToAP As Boolean = Nothing

            If e.Column.VisibleIndex = 0 Then

                IsAttachedToAP = DataGridViewDetails_PODetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString)

                If IsAttachedToAP = False Then

                    DirectCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).CellButtonRect = System.Drawing.Rectangle.Empty

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_PODetails.DataSourceChangedEvent

            If DataGridViewDetails_PODetails.HasRows Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each PurchaseOrderDetail In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()

                        LoadPOBudgetComparisons(PurchaseOrderDetail)

                    Next

                End Using

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewDetails_PODetails.InitNewRowEvent

            'objects
            Dim LineNumber As Integer = Nothing

            If _CanUserInsert AndAlso _CanUserEdit Then

                Try

                    LineNumber = (From Entity In DataGridViewDetails_PODetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)()
                                  Select [NextLineNumber] = Entity.LineNumber).Max + 1

                Catch ex As Exception
                    LineNumber = 1
                End Try

                DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString, LineNumber)
                DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.PONumber.ToString, _PurchaseOrderNumber)
                DataGridViewDetails_PODetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CanDelete.ToString, True)

            Else

                DataGridViewDetails_PODetails.CancelNewItemRow()

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_NewItemRowCanceledEvent() Handles DataGridViewDetails_PODetails.NewItemRowCanceledEvent

            RaiseEvent SelectedDetailChangedEvent()

        End Sub
        Private Sub DataGridViewDetails_PODetails_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDetails_PODetails.NewItemRowCellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString Then

                RaiseEvent NewItemRowOptionsEvent()

                'Estimate(True)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString Then

                'Estimate(True)

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewDetails_PODetails.QueryPopupNeedDatasourceEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim AllowedProcessControlNumbers As Integer() = {1, 3, 4, 8, 9, 13}

            If SearchableComboBoxGeneralInfo_IssuedBy.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case FieldName

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentID.ToString

                            OverrideDefaultDatasource = True

                            JobNumber = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString)
                            ClientCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)
                            DivisionCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)
                            ProductCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)

                            Datasource = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, False, AllowedProcessControlNumbers)

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString

                            OverrideDefaultDatasource = True

                            ClientCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString)
                            DivisionCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString)
                            ProductCode = DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString)

                            Datasource = From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, Nothing, False, AllowedProcessControlNumbers)
                                         Join JobView In AdvantageFramework.Database.Procedures.JobView.Load(DbContext) On Item.JobNumber Equals JobView.JobNumber
                                         Group By [JN] = Item.JobNumber Into G = Group
                                         Select G.First.JobView

                        Case AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString

                            OverrideDefaultDatasource = True

                            Datasource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "V")

                        Case Else

                            OverrideDefaultDatasource = False

                    End Select

                    If OverrideDefaultDatasource AndAlso Datasource IsNot Nothing Then

                        Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_RepositoryDataSourceLoading(FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewDetails_PODetails.RepositoryDataSourceLoading

            If FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                Cancel = True

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_PODetails.RowCountChangedEvent

            CalculatePOTotal()

        End Sub
        Private Sub DataGridViewDetails_PODetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_PODetails.SelectionChangedEvent

            RaiseEvent SelectedDetailChangedEvent()

        End Sub
        Private Sub DataGridViewDetails_PODetails_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewDetails_PODetails.ShowingEditorEvent

            If _POLocked = True OrElse _CanUserEdit = False Then

                e.Cancel = True

            ElseIf DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LockedByJobComp.ToString) = True Then

                e.Cancel = True

            ElseIf DataGridViewDetails_PODetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                If DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString) IsNot Nothing OrElse
                    DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString) IsNot Nothing OrElse
                    DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString) IsNot Nothing OrElse
                    DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString) IsNot Nothing OrElse
                    DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString) IsNot Nothing Then

                    e.Cancel = True

                Else

                    e.Cancel = Not _AllowGLAccountSelection

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_PODetails_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_PODetails.ShownEditorEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If _POLocked = True OrElse _CanUserEdit = False Then

                DataGridViewDetails_PODetails.CurrentView.CloseEditor()

            ElseIf DataGridViewDetails_PODetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LockedByJobComp.ToString) = True Then

                DataGridViewDetails_PODetails.CurrentView.CloseEditor()

            Else

                If DataGridViewDetails_PODetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString Then

                    Try

                        GridColumn = DirectCast(DataGridViewDetails_PODetails.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("CPMFlag")

                        If GridColumn IsNot Nothing Then

                            GridColumn.Visible = True

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_IssuedBy_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_IssuedBy.EditValueChanged

            LoadIssuedByEmployeeDetails()

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_IssuedTo_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_IssuedTo.EditValueChanged

            LoadIssuedToVendorDetails()

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_VendorContact_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_VendorContact.EditValueChanged

            LoadSelectedVendorContactDetails()

        End Sub
        Private Sub TabControlControl_PODetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_PODetails.SelectedTabChanged

            RaiseEvent SelectedTabChangedEvent()

        End Sub
        Private Sub TextBoxControl_PONumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxControl_PONumber.TextChanged

            If String.IsNullOrEmpty(TextBoxControl_PONumber.Text) = False Then

                If IsNumeric(TextBoxControl_PONumber.Text) = True Then

                    If TextBoxControl_PONumber.Text.Length < 6 Then

                        TextBoxControl_PONumber.Text = AdvantageFramework.PurchaseOrders.FormatPurchaseOrderNumber(TextBoxControl_PONumber.Text)

                    End If

                End If

            End If

        End Sub
        'Private Sub TextBoxControl_Revision_TextChanged(sender As Object, e As EventArgs)

        '    If String.IsNullOrEmpty(TextBoxControl_Revision.Text) = False Then

        '        If IsNumeric(TextBoxControl_Revision.Text) = True Then

        '            If TextBoxControl_Revision.Text.Length < 3 Then

        '                TextBoxControl_Revision.Text = AdvantageFramework.PurchaseOrders.FormatPurchaseOrderRevisionNumber(TextBoxControl_Revision.Text)

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewDetails_PODetails_RowDoubleClickEvent() Handles DataGridViewDetails_PODetails.RowDoubleClickEvent

            ViewAPInfo()

        End Sub
        Private Sub RadioButtonControlFooter_UseAgencyDefined_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlFooter_UseAgencyDefined.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlFooter_UseAgencyDefined.Checked Then

                    LoadFooterComments()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlFooter_UseCustom_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlFooter_UseCustom.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlFooter_UseCustom.Checked Then

                    LoadFooterComments()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlFooter_UseStandardComment_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlFooter_UseStandardComment.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlFooter_UseStandardComment.Checked Then

                    LoadFooterComments()
                    EnableOrDisableActions()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
