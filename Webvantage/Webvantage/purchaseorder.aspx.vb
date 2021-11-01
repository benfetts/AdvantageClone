Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals
Imports Telerik.Web.UI
Imports System.Drawing
Imports AdvantageFramework.AlertSystem.Classes

Partial Public Class purchaseorder
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "

    Private Enum GridItemCommands
        ItemDetails
        DeleteItem
        CopyItem
        APInfo
    End Enum

    Private Enum PageModes
        [New]
        Read
        Edit
        Copy
    End Enum

    Private Enum ModifyPOGridControls
        TextBoxClientCode
        TextBoxDivisionCode
        TextBoxProductCode
        RadNumericTextBoxJobNumber
        RadNumericTextBoxComponent
        RadComboBoxFunction

    End Enum

#End Region

#Region " Variables "

    Private _PONumber As Integer = Nothing
    Private _POFooterComments As String = ""
    Private _CanUserEdit As Boolean = True
    Private _CanUserInsert As Boolean = True
    Private _CanUserPrint As Boolean = False
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
    Private _PurchaseOrderDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing

#End Region

#Region " Properties "

    Private Property PageMode As PageModes
        Get
            Try

                PageMode = ViewState("PO_PageMode")

            Catch ex As Exception
                PageMode = PageModes.Read
            End Try
        End Get
        Set(value As PageModes)
            ViewState("PO_PageMode") = value
        End Set
    End Property
    Private Property AllowGLAccountSelection As Boolean
        Get
            Try

                If ViewState.Keys.OfType(Of String).Contains("PO_AllowGLAccountSelection") = False Then

                    ViewState("PO_AllowGLAccountSelection") = CheckAllowGLSelection()

                End If

                AllowGLAccountSelection = ViewState("PO_AllowGLAccountSelection")

            Catch ex As Exception
                AllowGLAccountSelection = False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("PO_AllowGLAccountSelection") = value
        End Set
    End Property
    Private Property LimitPOSelectionOffice As Boolean
        Get
            Try

                If ViewState.Keys.OfType(Of String).Contains("PO_LimitPOSelectionOffice") = False Then

                    ViewState("PO_LimitPOSelectionOffice") = CheckAllowGLSelection()

                End If

                LimitPOSelectionOffice = ViewState("PO_LimitPOSelectionOffice")

            Catch ex As Exception
                LimitPOSelectionOffice = False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("PO_LimitPOSelectionOffice") = value
        End Set
    End Property
    Private Property GeneralLedgerAccounts As IEnumerable
        Get
            Try

                GeneralLedgerAccounts = ViewState("PO_GL_Accounts")

            Catch ex As Exception
                GeneralLedgerAccounts = Nothing
            End Try
        End Get
        Set(value As IEnumerable)
            ViewState("PO_GL_Accounts") = value
        End Set
    End Property
    Private ReadOnly Property PurchaseOrderDetailsList(ByVal LoadEstimateAndBudgetData As Boolean) As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)
        Get

            Try

                If Me.PageMode <> PageModes.New Then

                    If _PurchaseOrderDetailsList Is Nothing Then

                        _PurchaseOrderDetailsList = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(Me.DbContext, Me.PurchaseOrder.Number).ToList

                        If Me.PageMode = PageModes.Copy Then

                            _PurchaseOrderDetailsList = _PurchaseOrderDetailsList.Where(Function(item) item.LockedByJobComp.GetValueOrDefault(False) = False).ToList

                        End If

                    End If

                    If LoadEstimateAndBudgetData Then

                        For Each PurchaseOrderDetail In _PurchaseOrderDetailsList

                            AdvantageFramework.PurchaseOrders.LoadPODetailEstimateInformation(Me.DbContext, PurchaseOrderDetail)

                            If Me.AllowGLAccountSelection Then

                                AdvantageFramework.PurchaseOrders.LoadPOBudgetComparisons(Me.DbContext, Me.PurchaseOrder.Date, PurchaseOrderDetail)

                            End If

                        Next

                    End If

                Else

                    _PurchaseOrderDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)

                End If

            Catch ex As Exception
                _PurchaseOrderDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)
            End Try
            Return _PurchaseOrderDetailsList
        End Get
    End Property
    Private Property POLocked As Boolean
        Get
            Try

                Return CBool(ViewState("POLocked"))

            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("POLocked") = value
        End Set
    End Property
    Private Property AllowRevision As Boolean
        Get
            Try

                Return CBool(ViewState("AllowRevision"))

            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("AllowRevision") = value
        End Set
    End Property
    Private Property HasApprovals As Boolean
        Get
            Try

                Return CBool(ViewState("HasApprovals"))

            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("HasApprovals") = value
        End Set
    End Property
    Private Property AllowCancelApproval As Boolean
        Get
            Try

                Return CBool(ViewState("AllowCancelApproval"))

            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("AllowCancelApproval") = value
        End Set
    End Property
    Private Property AllowPrint As Boolean
        Get

            If AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders) Then

                Try

                    Return CBool(ViewState("AllowPrint"))

                Catch ex As Exception
                    Return False
                End Try

            Else

                Return False

            End If

        End Get
        Set(value As Boolean)
            ViewState("AllowPrint") = value
        End Set
    End Property
    Private ReadOnly Property CanVoid As Boolean
        Get

            'objects
            Dim Allow As Boolean = True

            If Me.PurchaseOrder.IsVoid.GetValueOrDefault(0) = 0 Then

                If Me.HasItemsAttachedToAP Then

                    Allow = False

                End If

                If Allow Then

                    If Me.PurchaseOrder.ApprovalFlag.HasValue Then

                        If Me.PurchaseOrder.ApprovalFlag.Value = AdvantageFramework.PurchaseOrders.ApprovalStatus.Pending OrElse Me.PurchaseOrder.ApprovalFlag.Value = AdvantageFramework.PurchaseOrders.ApprovalStatus.Denied Then

                            Allow = False

                        End If

                    End If

                End If

            Else

                Allow = False

            End If

            CanVoid = Allow

        End Get
    End Property
    Private ReadOnly Property PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder
        Get

            If _PurchaseOrder Is Nothing Then

                _PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(Me.DbContext, _PONumber)

                Me.HasApprovals = AdvantageFramework.Database.Procedures.POApproval.LoadByPurchaseOrderNumber(Me.DbContext, _PONumber).Any

            End If

            Return _PurchaseOrder

        End Get
    End Property
    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then

                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property HasItemsAttachedToAP As Boolean
        Get
            Return Me.PurchaseOrderDetailsList(False).Any(Function(item) item.IsAttachedToAP.GetValueOrDefault(False) = True)
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadPurchaseOrder(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        If PurchaseOrder IsNot Nothing Then

            LoadPurchaseOrderInfo(PurchaseOrder)

        End If

    End Sub
    Private Sub LoadPurchaseOrderInfo(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        If PurchaseOrder IsNot Nothing Then

            Me.TextBoxDescription.Text = PurchaseOrder.Description

            If Not (Me.PageMode = PageModes.Copy) Then

                Me.TextBoxEmployeeCode.Text = PurchaseOrder.EmployeeCode
                Me.RadDatePickerPODate.DbSelectedDate = PurchaseOrder.Date
                Me.RadDatePickerDueDate.DbSelectedDate = PurchaseOrder.DueDate
                Me.CheckBoxWorkComplete.Checked = CBool(PurchaseOrder.IsWorkComplete.GetValueOrDefault(0))
                Me.LabelModifiedBy.Text = PurchaseOrder.ModifiedByUserCode

                If PurchaseOrder.ModifiedDate.HasValue Then

                    Me.LabelModifiedDate.Text = PurchaseOrder.ModifiedDate.Value.ToShortDateString

                Else

                    Me.LabelModifiedDate.Text = ""

                End If

            Else

                Me.LabelModifiedBy.Text = ""
                Me.LabelModifiedDate.Text = ""
                Me.TextBoxEmployeeCode.Text = _Session.User.EmployeeCode
                Me.RadDatePickerPODate.DbSelectedDate = cEmployee.TimeZoneToday
                Me.RadDatePickerDueDate.DbSelectedDate = cEmployee.TimeZoneToday
                Me.CheckBoxWorkComplete.Checked = False

            End If

            LoadIssuedByEmployeeDetails()

            RadGridPODetails.MasterTableView.GetColumnSafe("GridBoundColumnGeneralLedgerCode").Visible = Me.AllowGLAccountSelection

            Me.TextBoxVendorCode.Text = PurchaseOrder.VendorCode

            LoadIssuedToVendorDetails()

            If String.IsNullOrEmpty(PurchaseOrder.VendorContactCode) = False Then

                Me.TextBoxVendorContactCode.Text = PurchaseOrder.VendorContactCode

            Else

                Me.TextBoxVendorContactCode.Text = Nothing

            End If

            LoadSelectedVendorContactDetails()

            Me.RadTextBox_POInstructions.Text = PurchaseOrder.MainInstruction
            Me.RadTextBox_ShippingInstructions.Text = PurchaseOrder.DeliveryInstruction

            Select Case AdvantageFramework.PurchaseOrders.GetFooterType(PurchaseOrder.Footer)

                Case AdvantageFramework.PurchaseOrders.FooterTypes.AgencyDefined

                    ListItemAgency.Selected = True

                Case AdvantageFramework.PurchaseOrders.FooterTypes.StandardComment

                    ListItemStandard.Selected = True

                Case AdvantageFramework.PurchaseOrders.FooterTypes.Custom

                    ListItemCustom.Selected = True

            End Select

            LoadFooterComments()

        End If

    End Sub
    Private Sub LoadIssuedByEmployeeDetails()

        'objects
        Dim EmployeeLimit As Object = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim IssuedByEmployee As AdvantageFramework.Database.Views.Employee = Nothing

        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, _Session.User.EmployeeCode)

        If Employee IsNot Nothing Then

            Me.AllowGLAccountSelection = CBool(Employee.AllowPOGLSelection.GetValueOrDefault(0))
            Me.LimitPOSelectionOffice = CBool(Employee.LimitPOGLSelectionOffice.GetValueOrDefault(0))

            If Me.TextBoxEmployeeCode.Text <> "" Then

                If Me.TextBoxEmployeeCode.Text.Trim <> _Session.User.EmployeeCode Then

                    IssuedByEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, Me.TextBoxEmployeeCode.Text.Trim)

                Else

                    IssuedByEmployee = Employee

                End If

                If IssuedByEmployee IsNot Nothing Then

                    Me.RadNumericTextBoxPOLimit.Value = IssuedByEmployee.PurchaseOrderLimit
                    Me.TextBoxEmployeeName.Text = IssuedByEmployee.ToString

                Else

                    Me.RadNumericTextBoxPOLimit.Value = Nothing
                    Me.TextBoxEmployeeName.Text = Nothing

                End If

            End If

        End If

        HiddenFieldAllowGLAccountSelection.Value = Me.AllowGLAccountSelection.ToString
        HiddenFieldLimitPOSelectionOffice.Value = Me.LimitPOSelectionOffice.ToString

    End Sub
    Private Sub LoadIssuedToVendorDetails()

        'objects
        Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Dim DefaultVendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

        If Me.TextBoxVendorCode.Text <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Me.TextBoxVendorCode.Text.Trim)

                If Vendor IsNot Nothing Then

                    AdvantageFramework.PurchaseOrders.LoadVendorPayToInformation(DbContext, Vendor, TextBoxVendorName.Text, "", LabelPayTo.Text, TextBoxAddress1.Text, TextBoxAddress2.Text, "",
                                                                                 TextBoxCity.Text, TextBoxCounty.Text, TextBoxState.Text, TextBoxZip.Text, TextBoxCountry.Text, "", "", "", "")

                    Me.TextBoxVendorContactCode.Text = Vendor.DefaultVendorContactCode

                End If

            End Using

        End If

    End Sub
    Private Sub LoadSelectedVendorContactDetails()

        'objects
        Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
        Dim Code As String = Nothing
        Dim Name As String = Nothing
        Dim Email As String = Nothing

        If Me.TextBoxVendorCode.Text <> "" AndAlso Me.TextBoxVendorContactCode.Text <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, Me.TextBoxVendorCode.Text.Trim, Me.TextBoxVendorContactCode.Text.Trim)

                If VendorContact IsNot Nothing Then

                    Code = VendorContact.Code
                    Name = VendorContact.FirstName & " " & If(VendorContact.MiddleInitial <> "", VendorContact.MiddleInitial & ". ", "") & VendorContact.LastName
                    Email = VendorContact.Email

                End If

            End Using

        End If

        TextBoxVendorContactCode.Text = Code
        TextBoxVendorContactName.Text = Name
        TextBoxVendorContactEmail.Text = Email

    End Sub
    Private Sub LoadEntity(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        'objects
        Dim FooterType As AdvantageFramework.PurchaseOrders.FooterTypes = AdvantageFramework.PurchaseOrders.FooterTypes.Custom
        Dim Limit As Decimal = Nothing
        Dim POTotal As Decimal = Nothing

        If PurchaseOrder IsNot Nothing Then

            PurchaseOrder.Description = Me.TextBoxDescription.Text.Trim

            PurchaseOrder.Revision = Me.RadNumericTextBoxRevision.Value

            If Me.RadDatePickerPODate.SelectedDate.HasValue Then

                PurchaseOrder.Date = Me.RadDatePickerPODate.SelectedDate.Value

            Else

                PurchaseOrder.Date = Nothing

            End If

            If Me.RadDatePickerDueDate.SelectedDate.HasValue Then

                PurchaseOrder.DueDate = Me.RadDatePickerDueDate.SelectedDate.Value

            Else

                PurchaseOrder.DueDate = Nothing

            End If

            PurchaseOrder.VendorContactCode = Me.TextBoxVendorContactCode.Text.Trim

            If Me.CheckBoxWorkComplete.Checked Then

                PurchaseOrder.IsWorkComplete = 1

            Else

                PurchaseOrder.IsWorkComplete = 0

            End If

            PurchaseOrder.DeliveryInstruction = RadTextBox_ShippingInstructions.Text
            PurchaseOrder.MainInstruction = RadTextBox_POInstructions.Text

            If ListItemAgency.Selected Then

                FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.AgencyDefined

            ElseIf ListItemStandard.Selected Then

                FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.StandardComment

            ElseIf ListItemCustom.Selected Then

                FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.Custom

            End If

            PurchaseOrder.Footer = AdvantageFramework.PurchaseOrders.SetFooterText(FooterType, RadTextBox_FooterComments.Text)

            PurchaseOrder.ExceedFlag = 0

            If Me.RadNumericTextBoxPOLimit.Value.HasValue Then

                Try

                    POTotal = CDec(Me.RadNumericTextBoxPOTotal.Value.GetValueOrDefault(0))

                Catch ex As Exception
                    POTotal = 0
                End Try

                Try

                    Limit = CDec(Me.RadNumericTextBoxPOLimit.Value.GetValueOrDefault(0))

                Catch ex As Exception
                    Limit = 0
                End Try

                If POTotal > Limit Then

                    PurchaseOrder.ExceedFlag = 1

                End If

            End If

        End If

    End Sub
    Private Sub EnableOrDisableActions()

        Me.TextBoxVendorContactEmail.Enabled = False

        If Me.POLocked Then

            Me.Purchaseordernav1.Allow_Void = Me.CanVoid
            Me.Purchaseordernav1.Allow_Revision_Increment = False
            EnableOrDisableNewLine(False)
            Me.TextBoxDescription.Enabled = False
            Me.TextBoxVendorCode.Enabled = False
            Me.TextBoxVendorContactCode.Enabled = False
            Me.CheckBoxWorkComplete.Enabled = False
            Me.RadTextBox_FooterComments.Enabled = False
            Me.RadTextBox_POInstructions.Enabled = _CanUserEdit
            Me.RadTextBox_ShippingInstructions.Enabled = _CanUserEdit
            Me.RadDatePickerPODate.Enabled = _CanUserEdit
            Me.RadDatePickerDueDate.Enabled = _CanUserEdit
            RadToolBarButtonDelete.Visible = False
            RadToolBarButtonAdd.Visible = False
            RadToolBarButtonCopy.Visible = False
            RadToolBarButtonCopyFrom.Visible = False
            'Me.CheckBoxCompleteEntirePO.Enabled = False

        Else

            If _CanUserInsert = False Then

                EnableOrDisableNewLine(False)
                RadToolBarButtonAdd.Visible = False
                RadToolBarButtonCopy.Visible = False
                RadToolBarButtonCopyFrom.Visible = False

            End If

            If _CanUserEdit = False Then

                Me.TextBoxDescription.Enabled = False
                Me.TextBoxVendorCode.Enabled = False
                Me.TextBoxVendorContactCode.Enabled = False
                Me.RadDatePickerPODate.Enabled = False
                Me.RadDatePickerDueDate.Enabled = False
                Me.CheckBoxWorkComplete.Enabled = False
                Me.RadTextBox_POInstructions.Enabled = False
                Me.RadTextBox_ShippingInstructions.Enabled = False
                Me.RadTextBox_FooterComments.Enabled = False
                RadToolBarButtonAdd.Visible = False
                RadToolBarButtonCopy.Visible = False
                RadToolBarButtonCopyFrom.Visible = False
                RadToolBarButtonDelete.Visible = False
                'Me.CheckBoxCompleteEntirePO.Enabled = False
                Purchaseordernav1.Allow_MarkComplete = False

            End If

        End If

        Purchaseordernav1.Allow_CancelApproval = Me.AllowCancelApproval

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

                    PurchaseOrder.CreatedDate = cEmployee.TimeZoneToday
                    PurchaseOrder.UserCode = _Session.UserCode

                    PurchaseOrder.EmployeeCode = Me.TextBoxEmployeeCode.Text.Trim
                    PurchaseOrder.VendorCode = Me.TextBoxVendorCode.Text.Trim

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

                    PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

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
        Dim WebvantageHeaderMessage As String = ""

        Try

            If PurchaseOrder IsNot Nothing Then

                AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(Me.DbContext, PurchaseOrder, DisplayPONumber, Me.AllowPrint, Me.AllowCancelApproval, Me.AllowRevision, Me.POLocked, HeaderMessage, WebvantageHeaderMessage)

                Me.TextBoxPODisplayNumber.Text = DisplayPONumber
                Me.RadNumericTextBoxRevision.Value = PurchaseOrder.Revision.GetValueOrDefault(0)
                If PurchaseOrder.IsComplete IsNot Nothing Then
                    Me.Purchaseordernav1.MarkComplete = PurchaseOrder.IsComplete
                    If PurchaseOrder.IsComplete = 1 Then
                        Me.Purchaseordernav1.Allow_Save = False
                    Else
                        Me.Purchaseordernav1.Allow_Save = True
                    End If
                Else
                    Me.Purchaseordernav1.MarkComplete = False
                End If

                Me.TextBoxMessage.Text = HeaderMessage

                Me.TextBoxEmployeeCode.Enabled = False
                Me.TextBoxEmployeeName.Enabled = False
                Me.TextBoxVendorCode.Enabled = False
                Me.TextBoxVendorName.Enabled = False

                If Not [String].IsNullOrWhiteSpace(WebvantageHeaderMessage) Then

                    LabelApproval.Text = WebvantageHeaderMessage
                    LabelApproval.Visible = True

                Else

                    LabelApproval.Text = ""
                    LabelApproval.Visible = False

                End If

                If PurchaseOrder.IsVoid.GetValueOrDefault(0) = 1 Then
                    lbl_voidflag.Visible = True
                Else
                    lbl_voidflag.Visible = False
                End If

                If PurchaseOrder.ApprovalFlag.HasValue Then

                    If PurchaseOrder.ApprovalFlag = AdvantageFramework.PurchaseOrders.ApprovalStatus.Denied Then

                        lbl_voidflag.Visible = False

                    End If

                End If

                Purchaseordernav1.Allow_Print = Me.AllowPrint

                LoadPurchaseOrder(PurchaseOrder)

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

                Me.TextBoxPODisplayNumber.Text = "(New)"
                Me.RadNumericTextBoxRevision.Value = 0
                Me.TextBoxMessage.Text = ""

                Me.TextBoxEmployeeCode.Enabled = Not AdvantageFramework.PurchaseOrders.LimitPOToCurrentEmployee(_Session)
                Me.TextBoxEmployeeName.Enabled = False
                Me.TextBoxVendorCode.Enabled = True
                Me.TextBoxVendorName.Enabled = False

                LoadPurchaseOrder(PurchaseOrder)

            Else

                SetupComplete = False

            End If

            Me.AllowPrint = False
            Me.AllowCancelApproval = False
            Me.AllowRevision = False
            Me.POLocked = False

            Me.Purchaseordernav1.Allow_Copy = False
            Me.Purchaseordernav1.Allow_Revision_Increment = False
            Me.Purchaseordernav1.Allow_Void = False
            Me.Purchaseordernav1.Allow_Print = False
            Me.Purchaseordernav1.Allow_Refresh = False
            'Me.Purchaseordernav1.Allow_Bookmark = False
            EnableOrDisableNewLine(False)

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

            Me.TextBoxPODisplayNumber.Text = "(New)"
            Me.RadNumericTextBoxRevision.Value = 0
            Me.TextBoxMessage.Text = ""

            TextBoxDescription.Focus()

            Me.TextBoxEmployeeCode.Text = _Session.User.EmployeeCode
            Me.TextBoxEmployeeCode.Enabled = Not AdvantageFramework.PurchaseOrders.LimitPOToCurrentEmployee(_Session)
            Me.RadDatePickerPODate.DbSelectedDate = cEmployee.TimeZoneToday
            Me.RadDatePickerDueDate.DbSelectedDate = Nothing

            Me.AllowPrint = False
            Me.AllowCancelApproval = False
            Me.AllowRevision = False
            Me.POLocked = False

            Me.Purchaseordernav1.Allow_Copy = False
            Me.Purchaseordernav1.Allow_Revision_Increment = False
            Me.Purchaseordernav1.Allow_Void = False
            Me.Purchaseordernav1.Allow_Print = False
            Me.Purchaseordernav1.Allow_Refresh = False
            'Me.Purchaseordernav1.Allow_Bookmark = False

            Me.CollapsablePanel_Details.Visible = False

            LoadIssuedByEmployeeDetails()

            EnableOrDisableNewLine(False)

        Catch ex As Exception
            SetupComplete = False
        Finally
            SetupNewPurchaseOrder = SetupComplete
        End Try

    End Function
    Private Sub CalculatePOTotal()

        Dim Total As Decimal = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


            Try

                Total = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, _PONumber)
                         Select Entity.ExtendedAmount).Sum

            Catch ex As Exception
                Total = 0
            End Try

        End Using

        RadNumericTextBoxPOTotal.Value = Total
        Me.AddJavascriptToPage("$find('" & RadNumericTextBoxPOTotal.ClientID & "').set_value(" & Total & ");")

    End Sub
    Private Function Save(Optional ByVal print As Boolean = False) As Boolean

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False
        Dim ExceedMessage As String = ""
        Dim CancelSave As Boolean = False

        If Me.PageMode <> PageModes.Copy Then

            If _CanUserEdit Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PurchaseOrder = Me.FillObject(False)

                        If PurchaseOrder IsNot Nothing Then

                            If [String].IsNullOrEmpty(PurchaseOrder.PurchaseOrderApprovalRuleCode) Then

                                If PurchaseOrder.ExceedFlag.GetValueOrDefault(0) = 1 Then

                                    CancelSave = True
                                    ErrorMessage = "The PO total exceeds the limit ($" & RadNumericTextBoxPOLimit.Value.GetValueOrDefault(0).ToString("f2") & ") for selected employee."

                                End If

                            End If

                            If CancelSave = False Then

                                If print = False Then
                                    PurchaseOrder.ModifiedDate = cEmployee.TimeZoneToday
                                End If

                                If AdvantageFramework.Database.Procedures.PurchaseOrder.Update(DbContext, PurchaseOrder, print) Then

                                    ExceedMessage = SavePODetailsGrid()

                                    Saved = True

                                    If PurchaseOrder.ModifiedByUserCode IsNot Nothing Then
                                        LabelModifiedBy.Text = PurchaseOrder.ModifiedByUserCode
                                    End If
                                    If PurchaseOrder.ModifiedDate IsNot Nothing Then
                                        LabelModifiedDate.Text = PurchaseOrder.ModifiedDate.Value.ToShortDateString
                                    End If

                                End If

                            End If

                        End If

                    End Using

                    If Not [String].IsNullOrWhiteSpace(ExceedMessage) Then

                        Me.ShowMessage(ExceedMessage)

                    Else


                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                End Try

                If Not [String].IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.ShowMessage(ErrorMessage)

                End If

            End If

        End If
        'If Saved = True Then

        '    Me.RefreshPO()

        'End If

        Save = Saved

    End Function
    Public Function Insert(ByRef PONumber As Integer) As Boolean

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = Nothing
        Dim Inserted As Boolean = False
        Dim POApprovalCode As String = Nothing
        Dim PurchaseOrderDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing

        If _CanUserInsert Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrder = Me.FillObject(True)

                    If PurchaseOrder IsNot Nothing Then

                        PurchaseOrder.DbContext = DbContext

                        PurchaseOrder.Number = Nothing

                        If AdvantageFramework.PurchaseOrders.ValidatePurchaseOrderWithOfficeLimits(_Session, DbContext, PurchaseOrder, ErrorMessage) Then

                            PurchaseOrder.CreatedDate = cEmployee.TimeZoneToday
                            Inserted = AdvantageFramework.Database.Procedures.PurchaseOrder.Insert(DbContext, PurchaseOrder)

                        End If

                        If Inserted Then

                            If Me.PageMode = PageModes.Copy Then

                                PurchaseOrderDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail)(String.Format("EXEC [dbo].[advsp_load_po_details] {0}", _PONumber)).ToList

                                For Each PurchaseOrderDetail In PurchaseOrderDetailList

                                    If PurchaseOrderDetail IsNot Nothing AndAlso PurchaseOrderDetail.LockedByJobComp.GetValueOrDefault(False) = False Then

                                        GridEditableItem = RadGridPODetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridEditableItem).Where(Function(gei) gei.GetDataKeyValue("LineNumber") = PurchaseOrderDetail.LineNumber).SingleOrDefault

                                        FillPODetailEntity(GridEditableItem, PurchaseOrderDetail)

                                        AdvantageFramework.PurchaseOrders.CopyPurchaseOrderDetail(DbContext, PurchaseOrderDetail, PurchaseOrder.Number)

                                    End If

                                Next

                            End If

                            PONumber = PurchaseOrder.Number

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
                Inserted = False
            End Try

            If ErrorMessage <> "" Then

                Me.ShowMessage(ErrorMessage)

            End If

        End If

        Insert = Inserted

    End Function
    Private Function Revise() As Boolean

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

                            Me.RadNumericTextBoxRevision.Value = PurchaseOrder.Revision.GetValueOrDefault(0)

                        End If

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to revise the purchase order. Please contact software support."
            End Try

        End If

        Revise = Revised

    End Function
    Private Sub LoadFooterComments()

        'objects
        Dim FooterComments As String = ""
        Dim FooterType As AdvantageFramework.PurchaseOrders.FooterTypes = Nothing
        Dim VendorCode As String = ""
        Dim TextBoxEnabled As Boolean = False

        If ListItemAgency.Selected Then

            FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.AgencyDefined

        ElseIf ListItemStandard.Selected Then

            FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.StandardComment

            VendorCode = TextBoxVendorCode.Text

        ElseIf ListItemCustom.Selected Then

            FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.Custom

            TextBoxEnabled = True

        End If

        FooterComments = AdvantageFramework.PurchaseOrders.GetDisplayFooterTextByFooterType(Me.DbContext, FooterType, _PONumber, VendorCode)

        RadTextBox_FooterComments.Text = FooterComments
        RadTextBox_FooterComments.Enabled = TextBoxEnabled

    End Sub
    Private Function GetFooterComments() As String

        'objects
        Dim FooterComments As String = Nothing

        Select Case RadioButtonList_FooterComments.SelectedValue

            Case "Agency"

                FooterComments = "Agency Defined"

            Case "Standard"

                FooterComments = "Standard Comment"

            Case Else

                If String.IsNullOrEmpty(RadTextBox_FooterComments.Text) = False Then

                    FooterComments = RadTextBox_FooterComments.Text

                End If

        End Select

        GetFooterComments = FooterComments

    End Function
    Private Function CheckApprovalRuleCode() As Boolean

        'objects
        Dim Approve As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim EmployeeRule As String = Nothing
        Dim DepartmentRule As String = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.TextBoxEmployeeCode.Text.Trim)

            If Employee IsNot Nothing Then

                EmployeeRule = Employee.PurchaseOrderApprovalRuleCode

                If Employee.DepartmentTeam IsNot Nothing Then

                    DepartmentRule = Employee.DepartmentTeam.PurchaseOrderApprovalRuleCode

                End If

            End If

            If String.IsNullOrEmpty(EmployeeRule) AndAlso String.IsNullOrEmpty(DepartmentRule) Then

                Approve = True

            End If

        End Using

        CheckApprovalRuleCode = Approve

    End Function
    Private Function CheckAllowGLSelection() As Boolean

        'objects
        Dim Allow As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.TextBoxEmployeeCode.Text.Trim)

            If Employee IsNot Nothing Then

                Allow = CBool(Employee.AllowPOGLSelection.GetValueOrDefault(0))

            End If

        End Using

        CheckAllowGLSelection = Allow

    End Function
    Private Sub SetLookups()

        If Me.PageMode = PageModes.New OrElse Me.PageMode = PageModes.Copy Then

            If Not AdvantageFramework.PurchaseOrders.LimitPOToCurrentEmployee(_Session) Then

                Me.TextBoxEmployeeCode.Attributes.Add("adv-lookup", "Employee")

            End If

            Me.TextBoxVendorCode.Attributes.Add("adv-lookup", "Vendor")

        Else

            Me.TextBoxVendorCode.Enabled = False
            Me.TextBoxEmployeeCode.Enabled = False

        End If

        If Me.POLocked = False AndAlso _CanUserEdit = True Then

            Me.TextBoxVendorContactCode.Attributes.Add("adv-lookup", "VendorContact")

        End If

    End Sub
    Private Sub SetEmployeeLimit()

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim Limit As Decimal? = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.TextBoxEmployeeCode.Text.Trim)

            If Employee IsNot Nothing Then

                Limit = Employee.PurchaseOrderLimit

            End If

        End Using

        RadNumericTextBoxPOLimit.Value = Limit

    End Sub
    Private Function GetApprovalRuleCode() As String

        'objects
        Dim ApprovalCode As String = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.TextBoxEmployeeCode.Text.Trim)

                If Employee IsNot Nothing Then

                    If String.IsNullOrEmpty(Employee.PurchaseOrderApprovalRuleCode) = False Then

                        ApprovalCode = Employee.PurchaseOrderApprovalRuleCode

                    ElseIf Employee.DepartmentTeam IsNot Nothing Then

                        ApprovalCode = Employee.DepartmentTeam.PurchaseOrderApprovalRuleCode

                    End If

                End If

            End Using

        Catch ex As Exception
            ApprovalCode = ""
        Finally
            GetApprovalRuleCode = ApprovalCode
        End Try

    End Function
    Private Sub CheckUserRights(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        Try

            _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
            _CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
            _CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

            Dim POMaintenance As Integer = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

            If _CanUserPrint = False Then

                Me.Purchaseordernav1.Allow_Print = False

            Else
                'If _PurchaseOrder.IsVoid.GetValueOrDefault(0) = 1 Then
                '    Me.Purchaseordernav1.Allow_Print = False
                'Else
                '    Me.Purchaseordernav1.Allow_Print = True
                'End If
                Me.Purchaseordernav1.Allow_Print = Me.AllowPrint

            End If

            If _CanUserInsert = False Then

                Me.Purchaseordernav1.Allow_New = False
                'EnableOrDisableNewLine(False)

            Else

                Me.Purchaseordernav1.Allow_New = True
                'EnableOrDisableNewLine(True)

            End If

            If _CanUserEdit = False Then

                If Me.PageMode = PageModes.New And PurchaseOrder.IsComplete = 0 Then
                    Me.Purchaseordernav1.Allow_Save = True
                Else
                    Me.Purchaseordernav1.Allow_Save = False
                End If
                Me.Purchaseordernav1.Allow_Void = False
                'Me.CheckBoxCompleteEntirePO.Enabled = False
                Purchaseordernav1.Allow_MarkComplete = False

            Else

                If PurchaseOrder.IsComplete = 0 Then
                    Me.Purchaseordernav1.Allow_Save = True
                End If
                If Me.POLocked = False Then
                    Me.Purchaseordernav1.Allow_Void = Me.CanVoid
                End If

            End If

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.FinanceAccounting_Housekeeping_POMaintenance.ToString, _Session.UserCode) = False Then
                    'Me.CheckBoxCompleteEntirePO.Enabled = False
                    Purchaseordernav1.Allow_MarkComplete = False
                End If

            End Using

        Catch ex As Exception
        End Try
    End Sub
    Private Sub MarkPurchaseOrderPrinted()

        Try

            If Me.PurchaseOrder IsNot Nothing Then

                Me.PurchaseOrder.IsPrinted = 1

                AdvantageFramework.Database.Procedures.PurchaseOrder.Update(Me.DbContext, Me.PurchaseOrder, True)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ViewAPDetails(ByVal GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim LineNumber As Integer = Nothing

        If Save() Then

            If GridDataItem IsNot Nothing Then

                LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber"))

                StringBuilder = New System.Text.StringBuilder

                With StringBuilder

                    .Append("PurchaseOrderAPDetails.aspx?po_number=")
                    .Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
                    .Append("&line_number=") 'reference to PO number.
                    .Append(LineNumber.ToString)

                End With

                Me.OpenWindow("", StringBuilder.ToString())

            Else

                Me.ShowMessage("Please select an item.")

            End If

        End If

    End Sub
    Private Function CopyGridItem(ByVal GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim Copied As Boolean = False
        Dim NewLineNumber As Integer = Nothing
        Dim LineNumber As Integer = Nothing

        Try

            If GridDataItem IsNot Nothing Then

                LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber"))

                Copied = AdvantageFramework.PurchaseOrders.CopyPurchaseOrderDetail(Me.DbContext, _PONumber, LineNumber, _PONumber, NewLineNumber)

            Else

                Me.ShowMessage("Please select an item to copy.")

            End If

        Catch ex As Exception
            Copied = False
        Finally
            CopyGridItem = Copied
        End Try

    End Function
    Private Function DeleteGridItem(ByVal GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim Deleted As Boolean = False
        Dim LineNumber As Integer = Nothing


        Try

            If GridDataItem IsNot Nothing Then

                LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber"))

                Deleted = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Delete(Me.DbContext, _PONumber, LineNumber)

                If Deleted Then

                    CalculatePOTotal()

                End If

            Else

                Me.ShowMessage("Please select an item to delete.")

            End If

        Catch ex As Exception
            Deleted = False
        Finally
            DeleteGridItem = Deleted
        End Try

    End Function
    Private Sub ViewItemDetails(ByVal GridDataItem As Telerik.Web.UI.GridDataItem)

        Dim Approve As Boolean = False
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim LineNumber As Integer = Nothing

        If Save() Then

            If GridDataItem IsNot Nothing Then

                LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber"))

                Approve = CheckApprovalRuleCode()
                StringBuilder = New System.Text.StringBuilder

                With StringBuilder

                    .Append("purchaseorder_dtl.aspx?po_number=")
                    .Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
                    .Append("&line_number=") 'reference to PO number.
                    .Append(LineNumber.ToString)
                    .Append("&pagemode=edit")

                    If Approve = False Then

                        .Append("&approve=1")

                    End If

                    If Request.QueryString("Fromjj") = "jjpo" Then

                        .Append("&Fromjj=jjpo")

                    End If

                End With

                Me.OpenWindow("", StringBuilder.ToString())

            Else

                Me.ShowMessage("Please select an item.")

            End If

        End If

    End Sub
    Private Function SavePODetailsGrid() As String

        'objects
        Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim PODetailEntity As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
        Dim OriginalJobNumber As Integer? = Nothing
        Dim OriginalCompNumber As Short? = Nothing
        Dim OriginalGLAccount As String = Nothing
        Dim Message As String = ""
        Dim SaveMessage As String = ""
        Dim IsValid As Boolean = True

        PurchaseOrderDetails = Me.PurchaseOrderDetailsList(False)

        For Each GridDataItem In RadGridPODetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            OriginalJobNumber = Nothing
            OriginalCompNumber = Nothing
            OriginalGLAccount = Nothing

            If GridDataItem.IsInEditMode = True Then

                Try

                    PurchaseOrderDetail = PurchaseOrderDetails.Where(Function(PODtl) PODtl.LineNumber = CInt(GridDataItem.GetDataKeyValue("LineNumber"))).SingleOrDefault

                Catch ex As Exception
                    PurchaseOrderDetail = Nothing
                End Try

                If PurchaseOrderDetail IsNot Nothing Then

                    OriginalJobNumber = PurchaseOrderDetail.JobNumber
                    OriginalCompNumber = PurchaseOrderDetail.JobComponentNumber
                    OriginalGLAccount = PurchaseOrderDetail.GeneralLedgerCode

                    If PurchaseOrderDetail.LockedByJobComp.GetValueOrDefault(False) = False Then

                        FillPODetailEntity(GridDataItem, PurchaseOrderDetail)

                    End If

                End If

            End If

            If PurchaseOrderDetail IsNot Nothing Then

                IsValid = True

                PurchaseOrderDetail.DbContext = Me.DbContext

                If (PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue = False) Then
                    IsValid = False

                    Message = "Component is required."

                End If

                If (PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue AndAlso (OriginalJobNumber.GetValueOrDefault(0) <> PurchaseOrderDetail.JobNumber OrElse OriginalCompNumber.GetValueOrDefault(0) <> PurchaseOrderDetail.JobComponentNumber)) OrElse
                    OriginalGLAccount <> PurchaseOrderDetail.GeneralLedgerCode Then

                    IsValid = AdvantageFramework.PurchaseOrders.ValidatePurchaseOrderDetailWithOfficeLimits(_Session, DbContext, PurchaseOrderDetail, Message)

                End If

                If IsValid Then

                    Message = PurchaseOrderDetail.ValidateEntity(IsValid)

                    If IsValid Then

                        AdvantageFramework.PurchaseOrders.UpdatePODetail(Me.DbContext, PurchaseOrderDetail, Message)

                    End If

                End If

            End If

            If Not [String].IsNullOrWhiteSpace(Message) Then

                If Not [String].IsNullOrWhiteSpace(SaveMessage) Then

                    SaveMessage &= vbNewLine

                End If

                SaveMessage &= Message

                Message = ""

            End If

        Next

        RadGridPODetails.DataSource = Nothing
        RadGridPODetails.Rebind()

        Return SaveMessage

    End Function
    Private Sub HandleItemCommand(ByVal GridDataItem As Telerik.Web.UI.GridDataItem, ByVal Command As String)

        'objects
        Dim Rebind As Boolean = False

        Select Case Command

            Case Me.GridItemCommands.ItemDetails.ToString

                ViewItemDetails(GridDataItem)

            Case Me.GridItemCommands.DeleteItem.ToString

                For Each SelectedItem In RadGridPODetails.MasterTableView.GetSelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If DeleteGridItem(SelectedItem) Then

                        Rebind = True

                    End If

                Next

                CalculatePOTotal()

            Case Me.GridItemCommands.CopyItem.ToString

                For Each SelectedItem In RadGridPODetails.MasterTableView.GetSelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If CopyGridItem(GridDataItem) Then

                        Rebind = True

                    End If

                Next

                CalculatePOTotal()

            Case Me.GridItemCommands.APInfo.ToString

                ViewAPDetails(GridDataItem)

        End Select

        If Rebind Then

            _PurchaseOrderDetailsList = Nothing
            RadGridPODetails.Rebind()

            If Me.PageMode = PageModes.Edit OrElse Me.PageMode = PageModes.Read Then

                SetupExistingPurchaseOrder(Me.PurchaseOrder) ' fixes toolbar not refreshing after items changed

            End If

        End If

    End Sub
    Private Sub AddNewLinesFromExistingPO()

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If _PONumber > 0 Then

            QueryString = New AdvantageFramework.Web.QueryString

            With QueryString

                .Page = "PurchaseOrder_CopyWizard.aspx"
                .PurchaseOrderNumber = _PONumber

                Me.OpenWindow(QueryString, IsModal:=True)

            End With

        End If

    End Sub
    Private Sub EnableOrDisableNewLine(ByVal Enabled As Boolean)

        HideOrShowRadToolBarButton(RadToolBarButtonAdd, Enabled)
        HideOrShowRadToolBarButton(RadToolBarButtonCopy, Enabled)
        HideOrShowRadToolBarButton(RadToolBarButtonCopyFrom, Enabled)

    End Sub
    Private Sub HideOrShowRadToolBarButton(ByVal RadToolBarButton As Telerik.Web.UI.RadToolBarButton, ByVal Visible As Boolean)

        'objects
        Dim Index As Integer = Nothing

        If RadToolBarButton IsNot Nothing Then

            Index = RadToolBarButton.Index

            If Index > 0 Then

                If TypeOf RadToolBarButton.ToolBar.Items(Index - 1) Is Telerik.Web.UI.RadToolBarButton Then

                    If TryCast(RadToolBarButton.ToolBar.Items(Index - 1), Telerik.Web.UI.RadToolBarButton).IsSeparator Then

                        If TypeOf RadToolBarButton.ToolBar.Items(Index + 1) Is Telerik.Web.UI.RadToolBarButton Then

                            If TryCast(RadToolBarButton.ToolBar.Items(Index + 1), Telerik.Web.UI.RadToolBarButton).IsSeparator Then

                                TryCast(RadToolBarButton.ToolBar.Items(Index - 1), Telerik.Web.UI.RadToolBarButton).Visible = Visible

                            End If

                        End If

                    End If

                End If

            End If

            RadToolBarButton.Visible = Visible

        End If

    End Sub
    Private Sub FillPODetailEntity(ByVal GridEditableItem As Telerik.Web.UI.GridEditableItem, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

        'objects
        Dim Hashtable As System.Collections.Hashtable = Nothing
        Dim CommissionPercent As Decimal? = Nothing

        If PurchaseOrderDetail IsNot Nothing Then

            Hashtable = New System.Collections.Hashtable

            RadGridPODetails.MasterTableView.ExtractValuesFromItem(Hashtable, GridEditableItem)

            For Each DictionaryEntry In Hashtable.OfType(Of System.Collections.DictionaryEntry)()

                If DictionaryEntry.Key = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString Then

                    If DictionaryEntry.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(DictionaryEntry.Value.ToString) Then

                        Try

                            CommissionPercent = CDec(DictionaryEntry.Value)

                        Catch ex As Exception

                        End Try

                    End If

                End If

                PurchaseOrderDetail.SetPropertyValue(DictionaryEntry.Key, DictionaryEntry.Value)

            Next

            PurchaseOrderDetail.SetPropertyValue(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString, CommissionPercent)

            If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                PurchaseOrderDetail.JobComponentID = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(Me.DbContext, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber).ID

            End If

        End If

    End Sub
    Private Function FindGridColumnInput(ByVal GridEditableItem As Telerik.Web.UI.GridEditableItem, ByVal GridColumn As Telerik.Web.UI.GridColumn) As System.Web.UI.WebControls.WebControl

        'objects
        Dim InputControl As System.Web.UI.WebControls.WebControl = Nothing
        Dim ControlType As System.Type = Nothing

        If GridColumn IsNot Nothing AndAlso GridColumn.IsEditable Then

            If TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                ControlType = GetType(System.Web.UI.WebControls.TextBox)

            ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridNumericColumn Then

                ControlType = GetType(Telerik.Web.UI.RadNumericTextBox)

            Else

                ControlType = GetType(System.Web.UI.WebControls.WebControl)

            End If

            Try

                InputControl = (From Item In GridEditableItem(GridColumn).Controls.OfType(Of System.Web.UI.WebControls.WebControl)()
                                Where Item.GetType = ControlType
                                Select Item).FirstOrDefault

            Catch ex As Exception

            End Try

        End If

        FindGridColumnInput = InputControl

    End Function
    Private Sub SetupGridColumns()

        'objects
        Dim DataField As String = Nothing
        Dim EntityDataField As String = Nothing
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        For Each GridColumn In RadGridPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

            If TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                DataField = TryCast(GridColumn, Telerik.Web.UI.GridBoundColumn).DataField

            ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridTemplateColumn Then

                DataField = TryCast(GridColumn, Telerik.Web.UI.GridTemplateColumn).DataField

            End If

            If String.IsNullOrWhiteSpace(DataField) = False Then

                Try

                    If DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                        EntityDataField = AdvantageFramework.Database.Entities.PurchaseOrderDetail.Properties.GLACode.ToString

                    Else

                        EntityDataField = DataField

                    End If

                    If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Database.Entities.PurchaseOrderDetail.Properties), False).Any(Function(Name) Name = EntityDataField) = True Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.PurchaseOrderDetail), EntityDataField)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Client), AdvantageFramework.Database.Entities.Client.Properties.Code.ToString)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Division), AdvantageFramework.Database.Entities.Division.Properties.Code.ToString)

                    ElseIf EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString Then

                        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.Product), AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)

                    Else

                        PropertyDescriptor = Nothing

                    End If

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

            End If

            If TypeOf GridColumn Is Telerik.Web.UI.GridNumericColumn Then

                With DirectCast(GridColumn, Telerik.Web.UI.GridNumericColumn)

                    .ItemStyle.Width = Unit.Pixel(80)
                    .HeaderStyle.Width = Unit.Pixel(80)
                    .ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    .AllowRounding = True
                    .NumericType = Telerik.Web.UI.NumericType.Number

                    If PropertyDescriptor IsNot Nothing Then

                        .DecimalDigits = CInt(AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor))

                    Else

                        .DecimalDigits = 2

                    End If

                    If EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                        EntityDataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString Then

                        .DataFormatString = "{0:F0}"

                    Else

                        .DataFormatString = "{0:N" & .DecimalDigits.ToString & "}"

                    End If

                End With

            ElseIf TypeOf GridColumn Is Telerik.Web.UI.GridBoundColumn Then

                If GridColumn.IsEditable = True Then

                    With TryCast(GridColumn, Telerik.Web.UI.GridBoundColumn)

                        If PropertyDescriptor IsNot Nothing Then

                            .MaxLength = CInt(AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor))

                        End If

                    End With

                End If

            End If

        Next

    End Sub

#Region " Old But Ok "

    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)

        Me.UpdateToolTip(args.Value, args.UpdatePanel)

    End Sub
    Private Sub UpdateToolTip(ByVal ArgumentValue As String, ByVal panel As UpdatePanel)

        Dim Control As System.Web.UI.Control = Page.LoadControl("purchaseorder_Approval_Tooltip.ascx")

        panel.ContentTemplateContainer.Controls.Add(Control)

        Dim Tooltip As purchaseorder_Approval_Tooltip = DirectCast(Control, purchaseorder_Approval_Tooltip)

        With Tooltip

            .PONumber = ArgumentValue

        End With

    End Sub
    Private Function NavNeedsApprovalAndApprove(Optional ByVal print As Boolean = False) As Boolean

        'objects
        Dim NeedsApproval As Boolean = False
        Dim rulecode As String = ""

        If NavSetHeader(print) = True Then

            If NeedsApprovalAndApprove(_PONumber, Me.TextBoxPODisplayNumber.Text, TextBoxEmployeeCode.Text, rulecode) = True Then

                NeedsApproval = True
                Session("POAmount") = RadNumericTextBoxPOTotal.Value.GetValueOrDefault(0).ToString
                Me.OpenWindow("Purchase Order Approval", "purchaseorder_approval.aspx?PONum=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&rulecode=" & rulecode & "&state=" & Me.TextBoxPODisplayNumber.Text, 150, 450)

            End If

        End If

        NavNeedsApprovalAndApprove = NeedsApproval

    End Function
    Public Shared Function NeedsApprovalAndApprove(ByVal PurchaseOrderNumber As String, ByVal POPad As String, ByVal EmployeeCode As String, ByRef RuleCode As String) As Boolean

        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(HttpContext.Current.Session("ConnString"))
        POHeader.Select_POHeader(PurchaseOrderNumber, "")

        If (POPad = "" OrElse POPad = "(Pending)" OrElse POPad = "(Incomplete)" OrElse POPad = "(Denied)") And POHeader.Exceed = 1 Then

            Dim PO As New wPurchaseOrder.cPurchaseOrder(HttpContext.Current.Session("ConnString"))
            Dim oEmp As New cEmployee(HttpContext.Current.Session("ConnString"))
            Dim dept As String
            Dim deptApproval As String = ""
            Dim empApproval As String = ""
            Dim delete As Integer

            If POPad = "(Denied)" Then

                'delete = PODtl.DeletePOApproval(Int32.Parse(PO_NUMBER.Text.Trim))
                'If delete = 1 Then
                '    Me.ShowMessage(""Delete Failed."
                'End If
                'POHeader.Void_PO_Undo(Int32.Parse(PO_NUMBER.Text.Trim))

            End If

            dept = oEmp.GetDept(EmployeeCode)
            empApproval = PO.GetPOApprRuleCodebyEmp(EmployeeCode)

            If dept <> "" Then

                deptApproval = PO.GetPOApprRuleCodebyDept(dept)

            End If

            If empApproval <> "" Then

                RuleCode = empApproval

            Else

                RuleCode = deptApproval

            End If

            Return True

        Else

            Return False

        End If

    End Function
    Private Function NavSetHeader(Optional ByVal print As Boolean = False) As Boolean

        'objects
        Dim HasDetails As Boolean = False

        Save(print)

        If Me.PageMode = PageModes.Copy Then

            Me.PageMode = PageModes.Edit

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            HasDetails = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, _PONumber)
                          Select Entity).Any

        End Using

        If HasDetails = False Then

            Me.ShowMessage("You must select a purchase order with detail to print.")

        End If

        NavSetHeader = HasDetails

    End Function
    Private Sub AddNewPOLineFromEstimate()

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        StringBuilder = New System.Text.StringBuilder

        StringBuilder.Append("purchaseorder_dtl_add.aspx?po_number=")
        StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))

        If Request.QueryString("Fromjj") = "jjpo" Then

            StringBuilder.Append("&Fromjj=jjpo")

        End If

        Me.OpenWindow("", StringBuilder.ToString())
        StringBuilder = Nothing

    End Sub
    Private Sub RedirectPONewLine()

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        StringBuilder = New System.Text.StringBuilder

        StringBuilder.Append("purchaseorder_dtl.aspx?po_number=")
        StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
        StringBuilder.Append("&line_number=-1")
        StringBuilder.Append("&pagemode=new")

        If CheckApprovalRuleCode() = False Then

            StringBuilder.Append("&approve=1")

        End If

        If Request.QueryString("Fromjj") = "jjpo" Then

            StringBuilder.Append("&Fromjj=jjpo")

        End If

        Me.OpenWindow("", StringBuilder.ToString())

    End Sub

#End Region

#Region " Page Methods "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        HiddenFieldSecMod.Value = AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

        Try

            If Not Request.QueryString("po_number") Is Nothing Then

                _PONumber = CInt(AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number")))

            End If

        Catch ex As Exception
            _PONumber = Nothing
        End Try

        SetupGridColumns()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim AllowGLAccountSelection As Boolean = False
        Dim ContentPageData As AdvantageFramework.Web.Classes.ContentPageData = Nothing

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
        'Me.Purchaseordernav1.EnableBookmarks = Me.EnableBookmarks

        If Not Request.QueryString("pagemode") Is Nothing Then

            Select Case Request.QueryString("pagemode").ToUpper

                Case PageModes.Copy.ToString.ToUpper

                    Me.PageMode = PageModes.Copy

                Case PageModes.Edit.ToString.ToUpper

                    Me.PageMode = PageModes.Edit

                Case PageModes.New.ToString.ToUpper

                    Me.PageMode = PageModes.New

                Case PageModes.Read.ToString.ToUpper

                    Me.PageMode = PageModes.Read

                Case Else

                    Me.PageMode = PageModes.Read

            End Select

        End If

        If Not Page.IsPostBack Then

            Me.AllowPrint = True 'default to true

            If Not Session("POAlertSentApprovals") Is Nothing Then

                If Session("POAlertSentApprovals") = True Then

                    Me.ShowMessage("Approval Alerts sent.")
                    Session("POAlertSentApprovals") = False
                    _PONumber = Session("PONumberApproval")
                    Session("PONumberApproval") = ""

                End If

            End If

            Select Case Me.PageMode

                Case PageModes.Read, PageModes.Edit

                    If Me.PurchaseOrder IsNot Nothing Then

                        SetupExistingPurchaseOrder(Me.PurchaseOrder)

                    End If

                Case PageModes.Copy

                    If Me.PurchaseOrder IsNot Nothing Then

                        SetupCopyPurchaseOrder(Me.PurchaseOrder)

                    End If

                Case PageModes.New

                    SetupNewPurchaseOrder()

            End Select

            SetLookups()

            Purchaseordernav1.ControlCausesValidation = False

            Purchaseordernav1.SetEstimatePopupWindow(_PONumber.ToString)

            Me.LabelApproval.ToolTip = _PONumber.ToString

            If Request.QueryString("Fromjj") = "jjpo" Then

                Purchaseordernav1.Allow_List = False
                Purchaseordernav1.Allow_Copy = False
                Purchaseordernav1.Allow_Send = False
                Purchaseordernav1.Allow_New = False

            End If

            ContentPageData = New AdvantageFramework.Web.Classes.ContentPageData

            If ContentPageData.Load() = True Then

                ContentPageData.PurchaseOrderNumber = _PONumber
                ContentPageData.PurchaseOrderCallingPageMode = Me.PageMode.ToString.ToLower
                ContentPageData.PurchaseOrderEmployeeCode = TextBoxEmployeeCode.Text.Trim()

                ContentPageData.Save()

            End If

            With Me.RadToolTipManagerPO.TargetControls

                .Clear()
                .Add(Me.LabelApproval.ClientID, _PONumber.ToString, True)

            End With

            Me.EnableOrDisableActions()

        Else

            Select Case Me.EventArgument

                Case "Refresh"

                    If Session("POApproval") IsNot Nothing AndAlso Session("POApproval") = True Then
                        Session("POAlertSentApprovals") = True

                        Session("POApproval") = False

                        If Request.QueryString("Fromjj") = "jjpo" Then

                            MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(Session("PONumberApproval")) & "&pagemode=edit&Fromjj=jjpo")
                            Exit Sub

                        Else

                            MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(Session("PONumberApproval")) & "&pagemode=edit")
                            Exit Sub

                        End If
                    Else

                        RadGridPODetails.Rebind()

                        Select Case Me.PageMode
                            Case PageModes.Read, PageModes.Edit

                                If Me.PurchaseOrder IsNot Nothing Then

                                    SetupExistingPurchaseOrder(Me.PurchaseOrder)

                                End If

                        End Select

                    End If

            End Select

        End If

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridPODetails)

        Dim DisplayPONumber As String = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            DisplayPONumber = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDisplayNumber(DbContext, _PONumber)
        End Using

        If Me.PageMode = PageModes.New Then

        ElseIf Me.PurchaseOrder IsNot Nothing AndAlso Request.QueryString("bm") <> "1" Then
            Me.PageTitle = "PO " + DisplayPONumber + " - " + Me.PurchaseOrder.Description
        End If

        Me.CheckUserRights(Me.PurchaseOrder)

    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        'objects
        Dim NextItem As Telerik.Web.UI.RadToolBarButton = Nothing

        For Each RadToolBarButton In RadToolBarDetails.Items.OfType(Of Telerik.Web.UI.RadToolBarButton).Where(Function(Btn) Btn.IsSeparator = False).ToList

            Try

                NextItem = RadToolBarDetails.Items(RadToolBarButton.Index + 1)

            Catch ex As Exception
                NextItem = Nothing
            End Try

            If NextItem.IsSeparator Then

                NextItem.Visible = RadToolBarButton.Visible

            End If

        Next

        UpdateLineItemCompleteCheckBoxes()

    End Sub
    Private Sub Page_Unload1(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadioButtonList_FooterComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList_FooterComments.SelectedIndexChanged

        LoadFooterComments()

    End Sub
    Private Sub RadGridPODetails_InsertCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridPODetails.InsertCommand

        'objects
        Dim PurchaseOrderDetailClass As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim IsValid As Boolean = True
        Dim ErrorMessage As String = Nothing

        PurchaseOrderDetailClass = New AdvantageFramework.Database.Classes.PurchaseOrderDetail

        PurchaseOrderDetailClass.PONumber = _PONumber

        PurchaseOrderDetailClass.DbContext = Me.DbContext

        FillPODetailEntity(e.Item, PurchaseOrderDetailClass)

        ErrorMessage = PurchaseOrderDetailClass.ValidateEntity(IsValid)

        If IsValid Then

            If AdvantageFramework.PurchaseOrders.InsertPODetail(_Session, Me.DbContext, PurchaseOrderDetailClass, ErrorMessage) Then

                _PurchaseOrderDetailsList = Nothing
                CalculatePOTotal()

                SetupExistingPurchaseOrder(Me.PurchaseOrder)

            Else

                e.Canceled = True

            End If

        Else

            e.Canceled = True

            If [String].IsNullOrWhiteSpace(ErrorMessage) Then

                ErrorMessage = "Error adding purchase order line!"

            End If

        End If

        If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RadGridPODetails_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridPODetails.ItemCommand

        'objects
        Dim SelectedItem As Telerik.Web.UI.GridDataItem = Nothing

        If e.CommandName = "CopyFrom" Then

            AddNewLinesFromExistingPO()

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            SelectedItem = RadGridPODetails.MasterTableView.GetSelectedItems.FirstOrDefault

            If SelectedItem IsNot Nothing Then

                HandleItemCommand(SelectedItem, e.CommandName)

            End If

        End If

    End Sub
    Private Sub RadGridPODetails_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridPODetails.ItemCreated

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            If e.Item.ItemType = GridItemType.EditItem Then

                GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                For Each GridNumericColumn In RadGridPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn).Where(Function(GridCol) GridCol.Visible = True AndAlso GridCol.IsEditable = True)

                    RadNumericTextBox = GridDataItem(GridNumericColumn.UniqueName).Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox).FirstOrDefault

                    If RadNumericTextBox IsNot Nothing Then

                        RadNumericTextBox.Width = GridNumericColumn.ItemStyle.Width
                        RadNumericTextBox.NumberFormat.DecimalDigits = GridNumericColumn.DecimalDigits
                        RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
                        RadNumericTextBox.EnabledStyle.HorizontalAlign = HorizontalAlign.Right
                        RadNumericTextBox.IncrementSettings.InterceptMouseWheel = False

                        If GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedMarkupAmount.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineTotal.ToString Then

                            RadNumericTextBox.Enabled = False
                            RadNumericTextBox.ReadOnly = True

                        ElseIf GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobNumber.ToString OrElse
                               GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentNumber.ToString Then

                            RadNumericTextBox.Attributes.Add("adv-lookup", GridNumericColumn.DataField.Replace("Number", ""))
                            RadNumericTextBox.NumberFormat.GroupSeparator = ""

                        End If

                        If GridNumericColumn.DecimalDigits = 0 Then

                            RadNumericTextBox.ClientEvents.OnKeyPress = "RadNumericTextBoxPreventDecimal"

                        End If

                        If GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Quantity.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Rate.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedAmount.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedMarkupAmount.ToString OrElse
                           GridNumericColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineTotal.ToString Then

                            RadNumericTextBox.Attributes.Add("adv-calc", GridNumericColumn.DataField)

                        End If

                    End If

                Next

                For Each GridBoundColumn In RadGridPODetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).Where(Function(GridCol) GridCol.Visible = True AndAlso GridCol.IsEditable = True)

                    TextBox = GridDataItem(GridBoundColumn.UniqueName).Controls.OfType(Of System.Web.UI.WebControls.TextBox).FirstOrDefault

                    If TextBox IsNot Nothing Then

                        TextBox.MaxLength = GridBoundColumn.MaxLength

                        If GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DetailDescription.ToString OrElse
                            GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.Instructions.ToString OrElse
                            GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString Then

                            TextBox.TextMode = TextBoxMode.MultiLine

                        ElseIf GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionCode.ToString OrElse
                               GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                            TextBox.Width = Unit.Pixel(90)

                            TextBox.Attributes.Add("adv-lookup", GridBoundColumn.DataField.Replace("Code", ""))

                            If GridBoundColumn.DataField = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.GeneralLedgerCode.ToString Then

                                TextBox.Attributes("adv-lookup") = TextBox.Attributes("adv-lookup") & "Account"

                            End If

                        End If

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub RadGridPODetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridPODetails.ItemDataBound

        'objects
        Dim HiddenFieldMenuOptions As System.Web.UI.WebControls.HiddenField = Nothing
        Dim MenuOptions As Generic.Dictionary(Of String, Short) = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim HiddenTextBoxCPM As System.Web.UI.WebControls.TextBox = Nothing
        Dim CheckBoxLineItemComplete As System.Web.UI.WebControls.CheckBox = Nothing

        If e.Item.ItemType = GridItemType.Item OrElse e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.EditItem Then

            Try

                If TypeOf e.Item.DataItem Is AdvantageFramework.Database.Classes.PurchaseOrderDetail Then

                    PurchaseOrderDetail = DirectCast(e.Item.DataItem, AdvantageFramework.Database.Classes.PurchaseOrderDetail)

                End If

            Catch ex As Exception
                PurchaseOrderDetail = Nothing
            End Try

            If PurchaseOrderDetail IsNot Nothing Then

                HiddenFieldMenuOptions = TryCast(e.Item.FindControl("HiddenFieldMenuOptions"), System.Web.UI.WebControls.HiddenField)

                MenuOptions = AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(GridItemCommands), False).ToDictionary(Of String, Short)(Function(Key) Key, Function(Key) CShort(1))

                If Me.PageMode <> PageModes.Copy Then

                    If Me.HasApprovals = True Then

                        Select Case Me.PurchaseOrder.ApprovalFlag

                            Case 0

                                'all options

                            Case 1

                                MenuOptions(Me.GridItemCommands.DeleteItem.ToString) = 0
                                MenuOptions(Me.GridItemCommands.CopyItem.ToString) = 0

                            Case 2

                                MenuOptions(Me.GridItemCommands.DeleteItem.ToString) = 0
                                MenuOptions(Me.GridItemCommands.CopyItem.ToString) = 0

                            Case 3

                        End Select

                    End If

                    If PurchaseOrderDetail.LockedByJobComp.GetValueOrDefault(False) = True Then

                        MenuOptions(Me.GridItemCommands.CopyItem.ToString) = 0

                    End If

                    If Me.PurchaseOrder.IsVoid.GetValueOrDefault(0) = 1 Then

                        MenuOptions(Me.GridItemCommands.DeleteItem.ToString) = 0
                        MenuOptions(Me.GridItemCommands.CopyItem.ToString) = 0

                    End If

                Else

                    MenuOptions(Me.GridItemCommands.ItemDetails.ToString) = 0
                    MenuOptions(Me.GridItemCommands.DeleteItem.ToString) = 0
                    MenuOptions(Me.GridItemCommands.CopyItem.ToString) = 0
                    MenuOptions(Me.GridItemCommands.APInfo.ToString) = 0

                End If

                If PurchaseOrderDetail.IsAttachedToAP.GetValueOrDefault(False) = False Then

                    MenuOptions(Me.GridItemCommands.APInfo.ToString) = 0

                Else

                    MenuOptions(Me.GridItemCommands.DeleteItem.ToString) = 0

                End If

                HiddenFieldMenuOptions.Value = [String].Join("|", MenuOptions.Select(Function(Dict) Dict.Key & "=" & Dict.Value.ToString).ToArray)

                HiddenTextBoxCPM = e.Item.FindControl("HiddenTextBoxCPM")

                If HiddenTextBoxCPM IsNot Nothing Then

                    HiddenTextBoxCPM.Text = PurchaseOrderDetail.UseCPM.GetValueOrDefault(False).ToString

                End If

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _CanUserEdit = False OrElse AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.FinanceAccounting_Housekeeping_POMaintenance.ToString, _Session.UserCode) = False Then

                        CheckBoxLineItemComplete = e.Item.FindControl("CheckBoxLineItemComplete")

                        CheckBoxLineItemComplete.Enabled = False

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub RadGridPODetails_ItemInserted(sender As Object, e As GridInsertedEventArgs) Handles RadGridPODetails.ItemInserted

        e.KeepInInsertMode = True

    End Sub
    Private Sub RadGridPODetails_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridPODetails.NeedDataSource

        Dim CanInsert As Boolean = True

        If Me.POLocked = True OrElse _CanUserInsert = False Then

            CanInsert = False

        ElseIf Me.PageMode = PageModes.Copy OrElse Me.PageMode = PageModes.New Then

            CanInsert = False

        Else

            If Me.PurchaseOrder IsNot Nothing Then

                If Me.PurchaseOrder.ApprovalFlag.HasValue Then

                    If Me.PurchaseOrder.ApprovalFlag.GetValueOrDefault(0) <> AdvantageFramework.PurchaseOrders.ApprovalStatus.Denied Then

                        CanInsert = False

                    End If

                End If

            End If

        End If

        RadGridPODetails.MasterTableView.IsItemInserted = CanInsert

        Me.RadGridPODetails.DataSource = Me.PurchaseOrderDetailsList(True)

        CalculatePOTotal()

    End Sub

    Private Sub UpdateLineItemCompleteCheckBoxes()
        Dim CheckBoxLineItemComplete As System.Web.UI.WebControls.CheckBox = Nothing

        If Me.POLocked Then
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridPODetails.MasterTableView.Items

                CheckBoxLineItemComplete = CType(gridDataItem.FindControl("CheckBoxLineItemComplete"), System.Web.UI.WebControls.CheckBox)

                CheckBoxLineItemComplete.Enabled = False

            Next
        End If
    End Sub


    Private Sub RadGridPODetails_PreRender(sender As Object, e As EventArgs) Handles RadGridPODetails.PreRender

        'objects
        Dim Rebind As Boolean = False
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim CanEdit As Boolean = True

        For Each Item In RadGridPODetails.MasterTableView.Items

            CanEdit = True

            If TypeOf Item Is Telerik.Web.UI.GridEditableItem Then

                GridEditableItem = CType(Item, Telerik.Web.UI.GridDataItem)

                If GridEditableItem.Edit = False Then

                    PurchaseOrderDetail = TryCast(GridEditableItem.DataItem, AdvantageFramework.Database.Classes.PurchaseOrderDetail)

                    If PurchaseOrderDetail IsNot Nothing Then

                        If Me.POLocked = True OrElse _CanUserEdit = False Then

                            CanEdit = False

                        ElseIf PurchaseOrderDetail.LockedByJobComp.GetValueOrDefault(False) = True Then

                            CanEdit = False

                        End If

                        If CanEdit Then

                            GridEditableItem.Edit = True

                            Rebind = True

                        End If

                    End If

                End If

            End If



        Next

        If Rebind Then

            RadGridPODetails.Rebind()

        End If

    End Sub
    Private Sub Purchaseordernav1_PO_CancelApproval_Clicked() Handles Purchaseordernav1.PO_CancelApproval_Clicked

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

        Try

            If (Me.TextBoxPODisplayNumber.Text = "(Pending)" Or Me.LabelApproval.Text = "Approved") Then

                PurchaseOrder = Me.FillObject(False)

                If PurchaseOrder IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.PurchaseOrders.CancelApproval(DbContext, PurchaseOrder.Number) = False Then

                            Me.ShowMessage("Delete failed.")

                        End If

                    End Using

                End If

                If Request.QueryString("Fromjj") = "jjpo" Then

                    MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit&Fromjj=jjpo")
                    Exit Sub

                Else

                    MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit")
                    Exit Sub

                End If

            End If

        Catch ex As Exception
            Me.ShowMessage("There was a problem canceling approval for the purchase order. Please contact software support.")
        End Try

    End Sub
    Private Sub Purchaseordernav1_PO_Bookmark_Clicked() Handles Purchaseordernav1.PO_Bookmark_Clicked

        'objects
        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ErrorMessage As String = ""

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        QueryString.Add("bm", "1")

        Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

        With Bookmark

            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
            .UserCode = Session("UserCode")
            .Name = "PO " & Me.TextBoxPODisplayNumber.Text & " - " & Me.TextBoxDescription.Text
            .PageURL = "purchaseorder.aspx" & QueryString.ToString()

        End With

        BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)

        If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        Else

            Me.RefreshBookmarksDesktopObject()

        End If

    End Sub
    Private Sub Purchaseordernav1_PO_Copy_Clicked() Handles Purchaseordernav1.PO_Copy_Clicked

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        If Save() Then

            StringBuilder = New System.Text.StringBuilder

            StringBuilder.Append("purchaseorder.aspx?po_number=")

            StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            StringBuilder.Append("&pagemode=copy")

            Me.OpenWindow("", StringBuilder.ToString())

        End If

    End Sub
    Private Sub Purchaseordernav1_PO_List_Clicked() Handles Purchaseordernav1.PO_List_Clicked

        If Save() Then

            Me.RefreshCaller("purchaseorderlist.aspx")

        End If

    End Sub
    Private Sub Purchaseordernav1_PO_New_Clicked() Handles Purchaseordernav1.PO_New_Clicked

        'objects
        Dim ContinueNew As Boolean = True

        Select Case Me.PageMode

            Case PageModes.New

                ContinueNew = True

            Case PageModes.Edit

                ContinueNew = Save()

            Case PageModes.Copy

                ContinueNew = True

        End Select

        If ContinueNew Then

            Me.OpenWindow("Purchase Order", [String].Format("purchaseorder.aspx?pagemode={0}", Me.PageModes.New.ToString.ToLower))

        End If

    End Sub
    Private Sub PurchaseOrderNav1_PrintClicked() Handles Purchaseordernav1.PrintClicked

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If NavNeedsApprovalAndApprove(True) = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Page = "PurchaseOrder_Print.aspx"

            QueryString.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            QueryString.Add("callingpagemode", Me.PageMode.ToString.ToLower)

            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then

                QueryString.Add("Fromjj", "jjpo")

            End If

            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

            Me.OpenPrintSendSilently(QueryString)

            MarkPurchaseOrderPrinted()

            SetupExistingPurchaseOrder(Me.PurchaseOrder)

        End If

    End Sub
    Private Sub PurchaseOrderNav1_SendAlertClicked() Handles Purchaseordernav1.SendAlertClicked

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If NavNeedsApprovalAndApprove(True) = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Page = "PurchaseOrder_Print.aspx"

            QueryString.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            QueryString.Add("callingpagemode", Me.PageMode.ToString.ToLower)
            QueryString.Add("content", "1")

            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then

                QueryString.Add("FromJJ", "jjpo")

            End If

            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

            Me.OpenPrintSendSilently(QueryString)

        End If
    End Sub
    Private Sub PurchaseOrderNav1_SendEmailClicked() Handles Purchaseordernav1.SendEmailClicked

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If NavNeedsApprovalAndApprove(True) = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Page = "PurchaseOrder_Print.aspx"

            QueryString.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            QueryString.Add("callingpagemode", Me.PageMode.ToString.ToLower)
            QueryString.Add("content", "1")

            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then

                QueryString.Add("Fromjj", "jjpo")

            End If

            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

            Me.OpenPrintSendSilently(QueryString)

        End If
    End Sub
    Private Sub PurchaseOrderNav1_PrintSendOptionsClicked() Handles Purchaseordernav1.PrintSendOptionsClicked

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If NavNeedsApprovalAndApprove(True) = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Page = "PurchaseOrder_Print.aspx"

            QueryString.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            QueryString.Add("callingpagemode", Me.PageMode.ToString.ToLower)

            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then

                QueryString.Add("Fromjj", "jjpo")

            End If

            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

            Me.OpenWindow(QueryString, "Options")

        End If

    End Sub
    Private Sub Purchaseordernav1_PO_Refresh_Clicked() Handles Purchaseordernav1.PO_Refresh_Clicked

        Me.RefreshPO()

    End Sub
    Private Sub RefreshPO()

        Dim Qs As New AdvantageFramework.Web.QueryString

        Qs.Page = "purchaseorder.aspx"

        Qs.PurchaseOrderNumber = _PONumber
        Qs.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
        Qs.Add("pagemode", Me.PageMode.ToString.ToLower)

        If Request.QueryString("Fromjj") = "jjpo" Then

            Qs.Add("Fromjj", "jjpo")

        End If

        Qs.Go(False, True)

    End Sub
    Private Sub Purchaseordernav1_PO_Revision_Clicked() Handles Purchaseordernav1.PO_Revision_Clicked

        Revise()

    End Sub
    Private Sub Purchaseordernav1_PO_Save_Clicked() Handles Purchaseordernav1.PO_Save_Clicked

        'objects
        Dim PONumber As Integer = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        Select Case Me.PageMode

            Case PageModes.New

                If Insert(PONumber) Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.Append("purchaseorder.aspx?po_number=")

                    StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(PONumber.ToString))
                    StringBuilder.Append("&pagemode=edit")

                    Me.OpenWindow("PO " & Me.TextBoxPODisplayNumber.Text & " - " & Me.TextBoxDescription.Text, StringBuilder.ToString())

                    Me.CloseThisWindow()


                End If

            Case PageModes.Edit

                Save()

            Case PageModes.Copy

                Me.RadGridPODetails.AllowPaging = False
                Me.RadGridPODetails.Rebind()

                If Insert(PONumber) Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.Append("purchaseorder.aspx?po_number=")

                    StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(PONumber.ToString))
                    StringBuilder.Append("&pagemode=edit")

                    Me.OpenWindow("PO " & Me.TextBoxPODisplayNumber.Text & " - " & Me.TextBoxDescription.Text, StringBuilder.ToString())

                    Me.CloseThisWindow()

                End If

        End Select

    End Sub
    Private Sub Purchaseordernav1_PO_Void_Clicked() Handles Purchaseordernav1.PO_Void_Clicked

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim CheckBoxAP As System.Web.UI.WebControls.CheckBox = Nothing
        Dim Count As Integer = 0
        Dim Voided As Boolean = False
        Dim ErrorMessage As String = Nothing

        Save()

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridPODetails.MasterTableView.Items

            CheckBoxAP = CType(gridDataItem.FindControl("CheckBoxAP"), System.Web.UI.WebControls.CheckBox)

            If CheckBoxAP.Checked Then

                Me.ShowMessage("PO cannot be voided because invoices have been applied.")
                Exit Sub

            End If

        Next

        Try

            PurchaseOrder = Me.FillObject(False)

            If PurchaseOrder IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Voided = AdvantageFramework.PurchaseOrders.Void(DbContext, PurchaseOrder)

                End Using

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to void the purchase order. Please contact software support."
        End Try

        If Not [String].IsNullOrWhiteSpace(ErrorMessage) Then

            Me.ShowMessage(ErrorMessage)

        End If

        If Voided Then

            If Request.QueryString("Fromjj") = "jjpo" Then

                Me.CloseThisWindow()

            Else

                Me.CloseThisWindowAndRefreshCaller("purchaseorderlist.aspx", False)

            End If

        End If

    End Sub
    Private Sub Purchaseordernav1_SendAssignmentClicked() Handles Purchaseordernav1.SendAssignmentClicked

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If NavNeedsApprovalAndApprove(True) = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Page = "PurchaseOrder_Print.aspx"
            QueryString.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString))
            QueryString.Add("callingpagemode", Me.PageMode.ToString.ToLower)
            QueryString.Add("content", "1")

            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then

                QueryString.Add("FromJJ", "jjpo")

            End If

            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

            Me.OpenPrintSendSilently(QueryString)

        End If

    End Sub
    Private Sub Purchaseordernav1_AlertsClicked() Handles Purchaseordernav1.AlertsClicked

        If IsNumeric(TextBoxPODisplayNumber.Text.Trim()) = True Then

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "Alert_List.aspx"
            qs.PurchaseOrderNumber = TextBoxPODisplayNumber.Text.Trim()
            qs.Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.PurchaseOrder)

            Me.OpenWindow(qs)

        End If

    End Sub
    Private Sub RadContextMenuGridItem_ItemClick(sender As Object, e As RadMenuEventArgs) Handles RadContextMenuGridItem.ItemClick

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        GridDataItem = RadGridPODetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem).Where(Function(GDI) GDI.ItemIndexHierarchical = HiddenFieldSelectedRow.Value).SingleOrDefault

        If GridDataItem IsNot Nothing Then

            HandleItemCommand(GridDataItem, e.Item.Value)

        End If

    End Sub
    Protected Sub RadComboBoxFunction_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim TextBoxGeneralLedger As System.Web.UI.WebControls.TextBox = Nothing
        Dim OfficeCode As String = Nothing
        Dim GLACode As String = Nothing
        Dim CPMFlag As Boolean = False
        Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
        Dim CommissionPercent As Decimal? = Nothing
        Dim Rate As Decimal? = Nothing
        Dim divCPM As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing

        RadComboBox = TryCast(sender, Telerik.Web.UI.RadComboBox)

        GridDataItem = RadComboBox.Parent.Parent

        PurchaseOrderDetail = New AdvantageFramework.Database.Classes.PurchaseOrderDetail

        FillPODetailEntity(GridDataItem, PurchaseOrderDetail)

        TextBoxGeneralLedger = TryCast(FindGridColumnInput(GridDataItem, RadGridPODetails.MasterTableView.GetColumnSafe("GridBoundColumnGeneralLedgerCode")), System.Web.UI.WebControls.TextBox)

        If String.IsNullOrWhiteSpace(PurchaseOrderDetail.FunctionCode) = False Then

            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(Me.DbContext, PurchaseOrderDetail.FunctionCode)

            If [Function] IsNot Nothing Then

                If Me.AllowGLAccountSelection Then

                    If PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) <= 0 Then

                        If String.IsNullOrWhiteSpace([Function].OverheadGLACode) = False Then

                            If Me.LimitPOSelectionOffice Then

                                OfficeCode = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, _Session.User.EmployeeCode).OfficeCode

                                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                                    If (From Item In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByOfficeCode(Me.DbContext, OfficeCode)
                                        Where Item.Code = [Function].OverheadGLACode AndAlso
                                              Item.PurchaseOrder = 1
                                        Select Item).Any Then

                                        GLACode = [Function].OverheadGLACode

                                    End If

                                End If

                            Else

                                GLACode = [Function].OverheadGLACode

                            End If

                        End If

                    End If

                End If

                CPMFlag = CBool([Function].CPMFlag.GetValueOrDefault(0))

                If PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    BillingRate = AdvantageFramework.PurchaseOrders.LoadBillingRate(Me.DbContext, e.Value, PurchaseOrderDetail.ClientCode, PurchaseOrderDetail.DivisionCode, PurchaseOrderDetail.ProductCode, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then

                            CommissionPercent = BillingRate.COMM
                            Rate = BillingRate.BILLING_RATE

                            'set some values!
                            GridDataItem("GridNumericColumnCommissionPercent").Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox).First.Value = CommissionPercent
                            GridDataItem("GridNumericColumnCommissionRate").Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox).First.Value = Rate

                        End If

                    End If

                End If

            End If

        End If

        TextBoxGeneralLedger.Text = GLACode

        divCPM = GridDataItem.FindControl("divCPM")

        If divCPM IsNot Nothing Then

            If CPMFlag = True Then

                divCPM.Style(System.Web.UI.HtmlTextWriterStyle.Display) = "block"

            Else

                divCPM.Style(System.Web.UI.HtmlTextWriterStyle.Display) = "none"

            End If

        End If

    End Sub
    Private Sub ButtonAddItem_Click(sender As Object, e As EventArgs) Handles ButtonAddItem.Click

        If Save() Then

            RedirectPONewLine()

        End If

    End Sub
    Private Sub ButtonAddItemsFromEstimate_Click(sender As Object, e As EventArgs) Handles ButtonAddItemsFromEstimate.Click

        If Save() Then

            AddNewPOLineFromEstimate()

        End If

    End Sub
    Private Sub RadToolBarDetails_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarDetails.ButtonClick

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(GridItemCommands), False).Any(Function(Command) Command = e.Item.Value) Then

            Try

                GridDataItem = RadGridPODetails.MasterTableView.GetSelectedItems.FirstOrDefault

            Catch ex As Exception
                GridDataItem = Nothing
            End Try

            HandleItemCommand(GridDataItem, e.Item.Value)

        Else

            If e.Item.Value = "CopyFrom" Then

                AddNewLinesFromExistingPO()

            End If

        End If

    End Sub

    Private Sub PurchaseOrderNav1_MarkComplete() Handles Purchaseordernav1.MarkCompleteClicked

        'Objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim CompleteEntirePO As CheckBox = Nothing
        Dim Message As String = Nothing
        Dim PONumber As Integer = 0
        Dim POComplete As Integer = 0

        If _PONumber > 0 Then

            PONumber = _PONumber

        Else

            Me.ShowMessage("There was a problem updating the PO Complete Flag for this PO. Please contact software support.")
            Exit Sub

        End If

        POComplete = 1
        Message = "The Purchase Order has successfully been marked for completion."

        Try

            PurchaseOrder = Me.FillObject(False)

            If PurchaseOrder IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.PurchaseOrders.UpdatePOCompleteFlag(DbContext, PONumber, POComplete) = False Then

                        Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

                    Else

                        Me.ShowMessage(Message)

                        If POComplete = 1 Then
                            Purchaseordernav1.MarkComplete = True
                        Else
                            Purchaseordernav1.MarkComplete = False
                        End If

                    End If

                End Using

            End If

        Catch ex As Exception

            Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

        End Try

        'RadGridPODetails.DataSource = Nothing
        'RadGridPODetails.Rebind()

        Me.RefreshPO()

    End Sub
    Private Sub PurchaseOrderNav1_MarkNotComplete() Handles Purchaseordernav1.MarkNotCompleteClicked

        'Objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim CompleteEntirePO As CheckBox = Nothing
        Dim Message As String = Nothing
        Dim PONumber As Integer = 0
        Dim POComplete As Integer = 0

        If _PONumber > 0 Then

            PONumber = _PONumber

        Else

            Me.ShowMessage("There was a problem updating the PO Complete Flag for this PO. Please contact software support.")
            Exit Sub

        End If

        POComplete = 0
        Message = "The Purchase Order has successfully been un-marked for completion."

        Try

            PurchaseOrder = Me.FillObject(False)

            If PurchaseOrder IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.PurchaseOrders.UpdatePOCompleteFlag(DbContext, PONumber, POComplete) = False Then

                        Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

                    Else

                        Me.ShowMessage(Message)

                        If POComplete = 1 Then
                            Purchaseordernav1.MarkComplete = True
                        Else
                            Purchaseordernav1.MarkComplete = False
                        End If

                    End If

                End Using

            End If

        Catch ex As Exception

            Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

        End Try

        'RadGridPODetails.DataSource = Nothing
        'RadGridPODetails.Rebind()

        Me.RefreshPO()

    End Sub


    'Protected Sub CheckBoxCompleteEntirePO_CheckedChanged(sender As Object, e As EventArgs)

    '    'Objects
    '    Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
    '    Dim CompleteEntirePO As CheckBox = Nothing
    '    Dim Message As String = Nothing
    '    Dim PONumber As Integer = 0
    '    Dim POComplete As Integer = 0

    '    If TextBoxPODisplayNumber.Text.Length > 0 Then

    '        PONumber = CType(TextBoxPODisplayNumber.Text, Integer)

    '    Else

    '        Me.ShowMessage("There was a problem updating the PO Complete Flag for this PO. Please contact software support.")
    '        Exit Sub

    '    End If

    '    CheckBoxCompleteEntirePO = CType(sender, CheckBox)

    '    If CheckBoxCompleteEntirePO.Checked Then

    '        POComplete = 1
    '        Message = "The Purchase Order has successfully been marked for completion."

    '    Else

    '        POComplete = 0
    '        Message = "The Purchase Order has successfully been un-marked for completion."

    '    End If


    '    Try

    '        PurchaseOrder = Me.FillObject(False)

    '        If PurchaseOrder IsNot Nothing Then

    '            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                If AdvantageFramework.PurchaseOrders.UpdatePOCompleteFlag(DbContext, PONumber, POComplete) = False Then

    '                    Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

    '                Else

    '                    Me.ShowMessage(Message)

    '                    'If POComplete = 1 Then
    '                    '    Purchaseordernav1.MarkComplete = True
    '                    'Else
    '                    '    Purchaseordernav1.MarkComplete = False
    '                    'End If

    '                End If

    '            End Using

    '        End If

    '    Catch ex As Exception

    '        Me.ShowMessage("There was a problem updating the PO Complete flag for this PO. Please contact software support.")

    '    End Try

    '    'RadGridPODetails.DataSource = Nothing
    '    'RadGridPODetails.Rebind()

    '    Me.RefreshPO()

    'End Sub
    Protected Sub CheckBoxLineItemComplete_CheckedChanged(sender As Object, e As EventArgs)

        'Objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim CompleteLineItem As CheckBox = Nothing
        Dim Message As String = Nothing
        Dim PONumber As Integer = 0
        Dim LineNumber As Integer = 0
        Dim POComplete As Integer = 0

        CompleteLineItem = CType(sender, CheckBox)

        If TextBoxPODisplayNumber.Text.Length > 0 Then

            PONumber = CType(TextBoxPODisplayNumber.Text, Integer)

        Else

            Me.ShowMessage("There was a problem updating the PO Line Item for this PO. Please contact software support.")
            Exit Sub

        End If

        LineNumber = CType(CompleteLineItem.Attributes("LineNumber"), Integer)


        If CompleteLineItem.Checked Then

            POComplete = 1
            Message = "The Purchase Order line item been marked for completion."

        Else

            POComplete = 0
            Message = "The Purchase Order line item has successfully been un-marked for completion."

        End If

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.PurchaseOrders.UpdatePOLineItemCompleteFlag(DbContext, TextBoxPODisplayNumber.Text, LineNumber, POComplete) = False Then

                    Me.ShowMessage("There was a problem updating the PO Line Item for this PO. Please contact software support.")

                Else

                    Me.ShowMessage(Message)

                End If

            End Using

        Catch ex As Exception

            Me.ShowMessage("There was a problem updating the PO Line Item for this PO. Please contact software support.")

        End Try

        'RadGridPODetails.DataSource = Nothing
        'RadGridPODetails.Rebind()
        Me.RefreshPO()

    End Sub

#End Region

#End Region

End Class
