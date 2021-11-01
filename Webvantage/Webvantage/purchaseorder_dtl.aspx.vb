Imports System.Drawing
Imports System.Data.SqlClient

Partial Public Class purchaseorder_dtl
    Inherits Webvantage.BaseChildPage

#Region " Enum "

    Private Enum PageModes
        Copy
        Read
        Edit
        [New]
    End Enum

#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
    Private _PONumber As Integer = Nothing
    Private _LineNumber As Integer = -1
    Private _AllowPrint As Boolean = False
    Private _AllowCancelApproval As Boolean = False
    Private _AllowRevision As Boolean = False
    Private _POLocked As Boolean = False

#End Region

#Region " Properties "

    Private ReadOnly Property PageMode As PageModes
        Get

            Dim Mode As PageModes = PageModes.Read

            If Not Request.QueryString("pagemode") Is Nothing Then

                Select Case Request.QueryString("pagemode").ToUpper

                    Case Me.PageModes.Copy.ToString.ToUpper

                        Mode = PageModes.Copy

                    Case PageModes.Edit.ToString.ToUpper

                        Mode = PageModes.Edit

                    Case PageModes.New.ToString.ToUpper

                        Mode = PageModes.New

                    Case PageModes.Read.ToString.ToUpper

                        Mode = PageModes.Read

                    Case Else

                        Mode = PageModes.Read

                End Select

            End If

            Return Mode

        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadPurchaseOrderInformation(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        'objects
        Dim DisplayPONumber As String = Nothing

        If PurchaseOrder IsNot Nothing Then

            AdvantageFramework.PurchaseOrders.LoadPurchaseOrderInformation(_DbContext, PurchaseOrder, DisplayPONumber, _AllowPrint, _AllowCancelApproval, _AllowRevision, _POLocked, "")

            TextBoxPODisplayNumber.Text = DisplayPONumber
            TextBoxDescription.Text = PurchaseOrder.Description
            TextBoxEmployeeCode.Text = PurchaseOrder.EmployeeCode

            With AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(_DbContext, PurchaseOrder.EmployeeCode)

                If .AllowPOGLSelection.GetValueOrDefault(0) = 0 Then

                    TextBoxGLAccountCode.Visible = False
                    TextBoxGLAccountDescription.Visible = False

                Else

                    TextBoxGLAccountCode.Visible = True
                    TextBoxGLAccountDescription.Visible = True

                End If

                TextBoxEmployeeName.Text = .ToString

            End With

            TextBoxVendorCode.Text = PurchaseOrder.VendorCode
            TextBoxVendorName.Text = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, PurchaseOrder.VendorCode).ToString

            If PurchaseOrder.Date.HasValue Then

                LabelDateIssued.Text = PurchaseOrder.Date.Value.ToShortDateString

            End If

            If PurchaseOrder.DueDate.HasValue Then

                LabelDueDate.Text = PurchaseOrder.DueDate.Value.ToShortDateString

            End If

            LabelPOTotal.Text = (From Item In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(_DbContext, PurchaseOrder.Number)
                                 Where Item.LineNumber > 0
                                 Select Item.ExtendedAmount).ToList.Sum(Function(Amt) Amt.GetValueOrDefault(0)).ToString("c2")

            If PurchaseOrder.IsComplete.GetValueOrDefault(0) = 1 Then

                Me.LabelPOValidationMessage.Text = "Purchase Order is Completed and Locked."

            End If

        End If

    End Sub
    Private Sub LoadPurchaseOrderDetailInformation(ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

        If PurchaseOrderDetail IsNot Nothing Then

            LabelLineNumber.Text = PurchaseOrderDetail.LineNumber
            TextBoxLineDescription.Text = PurchaseOrderDetail.LineDescription
            TextBoxDetailDescription.Text = PurchaseOrderDetail.DetailDescription
            TextBoxInstructions.Text = PurchaseOrderDetail.Instructions

            TextBoxClientCode.Text = PurchaseOrderDetail.ClientCode
            TextBoxClientName.Text = PurchaseOrderDetail.ClientName
            TextBoxDivisionCode.Text = PurchaseOrderDetail.DivisionCode
            TextBoxDivisionName.Text = PurchaseOrderDetail.DivisionName
            TextBoxProductCode.Text = PurchaseOrderDetail.ProductCode
            TextBoxProductName.Text = PurchaseOrderDetail.ProductDescription

            If PurchaseOrderDetail.JobNumber.HasValue Then

                TextBoxJobNumber.Text = PurchaseOrderDetail.JobNumber
                TextBoxJobDescription.Text = PurchaseOrderDetail.JobDescription

            Else

                TextBoxJobNumber.Text = ""
                TextBoxJobDescription.Text = ""

            End If

            If PurchaseOrderDetail.JobComponentNumber.HasValue Then

                TextBoxJobComponentNumber.Text = PurchaseOrderDetail.JobComponentNumber
                TextBoxJobComponentDescription.Text = PurchaseOrderDetail.JobComponentDescription

            Else

                TextBoxJobComponentNumber.Text = ""
                TextBoxJobComponentDescription.Text = ""

            End If

            TextBoxFunctionCode.Text = PurchaseOrderDetail.FunctionCode
            TextBoxFunctionDescription.Text = PurchaseOrderDetail.FunctionDescription
            divCPM.Style(System.Web.UI.HtmlTextWriterStyle.Display) = If(PurchaseOrderDetail.UseCPM.GetValueOrDefault(0) = 0, "none", "inline-block")

            If PurchaseOrderDetail.JobNumber.HasValue Then

                TextBoxGLAccountCode.Enabled = False

            End If

            If TextBoxGLAccountCode.Visible Then

                TextBoxGLAccountCode.Text = PurchaseOrderDetail.GeneralLedgerCode

                If Not [String].IsNullOrWhiteSpace(PurchaseOrderDetail.GeneralLedgerCode) Then

                    TextBoxGLAccountDescription.Text = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(_DbContext, PurchaseOrderDetail.GeneralLedgerCode).Description

                End If

            End If

            RadNumericTextBoxQuantity.Value = PurchaseOrderDetail.Quantity
            RadNumericTextBoxRate.Value = PurchaseOrderDetail.Rate
            RadNumericTextBoxExtendedAmount.Value = PurchaseOrderDetail.ExtendedAmount
            RadNumericTextBoxMarkupPercent.Value = PurchaseOrderDetail.CommissionPercent
            RadNumericTextBoxMarkupAmount.Value = PurchaseOrderDetail.ExtendedMarkupAmount
            CheckBoxAttachedToAP.Checked = PurchaseOrderDetail.IsAttachedToAP.GetValueOrDefault(False)

            If PurchaseOrderDetail.IsComplete.GetValueOrDefault(0) = 1 Then

                Me.LabelPOValidationMessage.Text = "Purchase Order Line is Completed and Locked."

            End If

        End If

    End Sub
    Private Sub FillPurchaseOrderDetailEntity(ByVal PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail)

        If PurchaseOrderDetail IsNot Nothing Then

            If Not [String].IsNullOrWhiteSpace(TextBoxLineDescription.Text) Then

                PurchaseOrderDetail.LineDescription = TextBoxLineDescription.Text

            Else

                PurchaseOrderDetail.LineDescription = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxDetailDescription.Text) Then

                PurchaseOrderDetail.DetailDescription = TextBoxDetailDescription.Text

            Else

                PurchaseOrderDetail.DetailDescription = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxInstructions.Text) Then

                PurchaseOrderDetail.Instructions = TextBoxInstructions.Text

            Else

                PurchaseOrderDetail.Instructions = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxClientCode.Text) Then

                PurchaseOrderDetail.ClientCode = TextBoxClientCode.Text

            Else

                PurchaseOrderDetail.ClientCode = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxDivisionCode.Text) Then

                PurchaseOrderDetail.DivisionCode = TextBoxDivisionCode.Text

            Else

                PurchaseOrderDetail.DivisionCode = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxProductCode.Text) Then

                PurchaseOrderDetail.ProductCode = TextBoxProductCode.Text

            Else

                PurchaseOrderDetail.ProductCode = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxJobNumber.Text) Then

                PurchaseOrderDetail.JobNumber = CInt(TextBoxJobNumber.Text)

            Else

                PurchaseOrderDetail.JobNumber = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxJobComponentNumber.Text) Then

                PurchaseOrderDetail.JobComponentNumber = CShort(TextBoxJobComponentNumber.Text)
                PurchaseOrderDetail.JobComponentID = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(_DbContext, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber).ID

            Else

                PurchaseOrderDetail.JobNumber = Nothing
                PurchaseOrderDetail.JobComponentID = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxFunctionCode.Text) Then

                PurchaseOrderDetail.FunctionCode = TextBoxFunctionCode.Text

            Else

                PurchaseOrderDetail.FunctionCode = Nothing

            End If

            If Not [String].IsNullOrWhiteSpace(TextBoxGLAccountCode.Text) Then

                PurchaseOrderDetail.GeneralLedgerCode = TextBoxGLAccountCode.Text

            Else

                PurchaseOrderDetail.GeneralLedgerCode = Nothing

            End If

            PurchaseOrderDetail.Quantity = RadNumericTextBoxQuantity.Value
            PurchaseOrderDetail.Rate = RadNumericTextBoxRate.Value
            PurchaseOrderDetail.ExtendedAmount = RadNumericTextBoxExtendedAmount.Value
            PurchaseOrderDetail.CommissionPercent = RadNumericTextBoxMarkupPercent.Value
            PurchaseOrderDetail.ExtendedMarkupAmount = RadNumericTextBoxMarkupAmount.Value
            PurchaseOrderDetail.LineTotal = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) + PurchaseOrderDetail.ExtendedMarkupAmount.GetValueOrDefault(0)

        End If

    End Sub
    Private Sub LoadControlSettings()

        If IsPOAmountRequired() Then

            Me.RadNumericTextBoxExtendedAmount.CssClass = "RequiredInput"

        Else

            Me.RadNumericTextBoxExtendedAmount.CssClass = ""

        End If

    End Sub
    Private Function IsPOAmountRequired() As Boolean

        Dim POAmountRequired As Boolean = False

        If AdvantageFramework.Database.Procedures.Agency.Load(_DbContext).POAmountRequired.GetValueOrDefault(0) = 1 Then

            POAmountRequired = True

        End If

        IsPOAmountRequired = POAmountRequired

    End Function
    Private Sub SetupPicklists()

        If _POLocked = False Then

            HyperLinkClient.Attributes.Add("adv-lookup", "Client")
            HyperLinkDivision.Attributes.Add("adv-lookup", "Division")
            HyperLinkProduct.Attributes.Add("adv-lookup", "Product")
            HyperLinkJob.Attributes.Add("adv-lookup", "Job")
            HyperLinkJobComponent.Attributes.Add("adv-lookup", "JobComponent")
            HyperLinkFunction.Attributes.Add("adv-lookup", "Function")
            HyperLinkGLAccount.Attributes.Add("adv-lookup", "GeneralLedgerAccount")

            TextBoxClientCode.Attributes.Add("adv-lookup", "Client")
            TextBoxDivisionCode.Attributes.Add("adv-lookup", "Division")
            TextBoxProductCode.Attributes.Add("adv-lookup", "Product")
            TextBoxJobNumber.Attributes.Add("adv-lookup", "Job")
            TextBoxJobComponentNumber.Attributes.Add("adv-lookup", "JobComponent")
            TextBoxFunctionCode.Attributes.Add("adv-lookup", "Function")
            TextBoxGLAccountCode.Attributes.Add("adv-lookup", "GeneralLedgerAccount")

            TextBoxClientName.Attributes.Add("adv-desc", "Client")
            TextBoxDivisionName.Attributes.Add("adv-desc", "Division")
            TextBoxProductName.Attributes.Add("adv-desc", "Product")
            TextBoxJobDescription.Attributes.Add("adv-desc", "Job")
            TextBoxJobComponentDescription.Attributes.Add("adv-desc", "JobComponent")
            TextBoxFunctionDescription.Attributes.Add("adv-desc", "Function")
            TextBoxGLAccountDescription.Attributes.Add("adv-desc", "GeneralLedgerAccount")

        End If

    End Sub
    Private Sub EnableOrDisableActions()

        If _POLocked Then

            Me.TextBoxLineDescription.ReadOnly = True
            Me.TextBoxDetailDescription.ReadOnly = True
            Me.TextBoxInstructions.ReadOnly = True
            Me.TextBoxClientCode.ReadOnly = True
            Me.TextBoxProductCode.ReadOnly = True
            Me.TextBoxDivisionCode.ReadOnly = True
            Me.TextBoxJobNumber.ReadOnly = True
            Me.TextBoxJobComponentNumber.ReadOnly = True
            Me.TextBoxFunctionCode.ReadOnly = True
            Me.RadNumericTextBoxQuantity.ReadOnly = True
            Me.RadNumericTextBoxRate.ReadOnly = True
            Me.RadNumericTextBoxExtendedAmount.ReadOnly = True
            Me.RadNumericTextBoxMarkupPercent.ReadOnly = True
            Me.RadNumericTextBoxMarkupAmount.ReadOnly = True

            Me.RadToolbarPurchseOrderDetail.FindItemByValue("Save").Enabled = False
            Me.RadToolbarPurchseOrderDetail.FindItemByValue("Refresh").Enabled = False

            Me.HyperLinkClient.Enabled = False
            Me.HyperLinkDivision.Enabled = False
            Me.HyperLinkProduct.Enabled = False
            Me.HyperLinkJob.Enabled = False
            Me.HyperLinkJobComponent.Enabled = False
            Me.HyperLinkFunction.Enabled = False

            Me.HyperLinkGLAccount.Enabled = False
            Me.TextBoxGLAccountCode.Enabled = False

        End If

    End Sub
    Private Function Save() As Boolean

        'objects
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True
        Dim URL As String = Nothing
        Dim Saved As Boolean = False
        Dim OriginalJobNumber As Integer? = Nothing
        Dim OriginalCompNumber As Short? = Nothing

        If _PONumber > 0 Then

            If _LineNumber > 0 Then

                PurchaseOrderDetail = (From Item In AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(_DbContext, _PONumber)
                                       Where Item.LineNumber = _LineNumber
                                       Select Item).SingleOrDefault

                OriginalJobNumber = PurchaseOrderDetail.JobNumber
                OriginalCompNumber = PurchaseOrderDetail.JobComponentNumber

            Else

                PurchaseOrderDetail = New AdvantageFramework.Database.Classes.PurchaseOrderDetail

                PurchaseOrderDetail.PONumber = _PONumber

            End If

            If PurchaseOrderDetail IsNot Nothing Then

                FillPurchaseOrderDetailEntity(PurchaseOrderDetail)

                PurchaseOrderDetail.DbContext = _DbContext

                If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue AndAlso (OriginalJobNumber.GetValueOrDefault(0) <> PurchaseOrderDetail.JobNumber OrElse OriginalCompNumber.GetValueOrDefault(0) <> PurchaseOrderDetail.JobComponentNumber) Then

                    IsValid = AdvantageFramework.PurchaseOrders.ValidatePurchaseOrderDetailWithOfficeLimits(_Session, _DbContext, PurchaseOrderDetail, ErrorMessage)

                End If

                If IsValid Then

                    ErrorMessage = PurchaseOrderDetail.ValidateEntity(IsValid)

                End If

                If IsValid Then

                    If _LineNumber > 0 Then

                        Saved = AdvantageFramework.PurchaseOrders.UpdatePODetail(_DbContext, PurchaseOrderDetail, ErrorMessage)

                    Else

                        Saved = AdvantageFramework.PurchaseOrders.InsertPODetail(_Session, _DbContext, PurchaseOrderDetail, ErrorMessage)

                    End If

                    If Not [String].IsNullOrWhiteSpace(ErrorMessage) Then

                        Me.ShowMessage(ErrorMessage)

                    End If

                    If Saved Then

                        If Request.QueryString("Fromjj") = "jjpo" Then

                            URL = "purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=" & Me.PageMode.ToString.ToLower & "&Fromjj=jjpo"

                        Else

                            URL = "purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit" ' & Me.PageMode.ToString.ToLower

                        End If

                        Me.CloseThisWindowAndRefreshCaller(URL)

                    End If

                Else

                    If [String].IsNullOrWhiteSpace(ErrorMessage) Then

                        ErrorMessage = "Error adding PO line!"

                    End If

                    Me.ShowMessage(ErrorMessage)

                End If

            End If

        End If

    End Function
    Private Sub CheckUserRights()

        'objects
        Dim secView As String
        Dim secEdit As String
        Dim secInsert As String

        Try

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")

            If secEdit = "N" Then

                If Me.PageMode = PageModes.New Then

                    Me.RadToolbarPurchseOrderDetail.Items.FindItemByValue("Save").Enabled = True

                Else

                    Me.RadToolbarPurchseOrderDetail.Items.FindItemByValue("Save").Enabled = False

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub OverrideSaveAndRedirect()

        If Me.PageMode = PageModes.Edit OrElse Me.PageMode = PageModes.New Then

            Save()

        End If

        RedirectToPOHeader()

    End Sub
    Private Sub RedirectToPOHeader()

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        StringBuilder = New System.Text.StringBuilder

        With StringBuilder

            .Append("purchaseorder.aspx?po_number=")
            .Append(AdvantageFramework.Security.Encryption.DecryptPO(_PONumber.ToString))
            .Append("&pagemode=")
            .Append(Me.PageMode.ToString.ToLower)

            If Request.QueryString("Fromjj") = "jjpo" Then

                .Append("&Fromjj=jjpo")

            End If

        End With

        Me.OpenWindow("", StringBuilder.ToString())

    End Sub
    Private Sub ShowEstimateInfoPanel()

        'objects
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing
        Dim FunctionCode As String = Nothing
        Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing

        If Not [String].IsNullOrWhiteSpace(TextBoxJobNumber.Text) AndAlso IsNumeric(TextBoxJobNumber.Text) AndAlso
           Not [String].IsNullOrWhiteSpace(TextBoxJobComponentNumber.Text) AndAlso IsNumeric(TextBoxJobComponentNumber.Text) Then

            JobNumber = CInt(TextBoxJobNumber.Text)
            JobComponentNumber = CShort(TextBoxJobComponentNumber.Text)

            If Not [String].IsNullOrWhiteSpace(TextBoxFunctionCode.Text) Then

                FunctionCode = TextBoxFunctionCode.Text

            End If

            Try

                EstimateApproval = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(_DbContext)
                                    Where Entity.JobNumber = JobNumber AndAlso
                                           Entity.JobComponentNumber = JobComponentNumber
                                    Select Entity).SingleOrDefault

            Catch ex As Exception
                EstimateApproval = Nothing
            End Try

            If String.IsNullOrWhiteSpace(FunctionCode) Then

                FunctionCode = ""

            End If

            If EstimateApproval IsNot Nothing Then

                RadGridEstimateInfo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(_DbContext)
                                                  Where Entity.EstimateNumber = EstimateApproval.EstimateNumber AndAlso
                                                        Entity.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber AndAlso
                                                        Entity.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber AndAlso
                                                        Entity.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber AndAlso
                                                        Entity.Function.Type = "V" AndAlso
                                                        (Entity.FunctionCode = FunctionCode OrElse
                                                         FunctionCode = "")
                                                  Select Entity).Select(Function(Item) New With {.FunctionCode = Item.FunctionCode,
                                                                                                 .Function = Item.Function.Description,
                                                                                                 .QuoteNumber = Item.EstimateQuoteNumber,
                                                                                                 .Rate = Item.RateAmount,
                                                                                                 .Quantity = Item.Quantity,
                                                                                                 .ExtendedAmount = Item.ExtendedAmount,
                                                                                                 .VendorCode = Item.VendorCode,
                                                                                                 .Vendor = "",
                                                                                                 .MarkupPercent = Item.CommissionPercent,
                                                                                                 .MarkupAmount = Item.MarkupAmount,
                                                                                                 .CountyTaxAmount = Item.CountyTaxAmount,
                                                                                                 .CityTaxAmount = Item.CityTaxAmount,
                                                                                                 .ContingencyAmount = Item.ContingencyAmount,
                                                                                                 .ContingencyMarkupAmount = Item.ContingencyMarkupAmount,
                                                                                                 .ContingencyStateAmount = Item.ContingencyStateAmount,
                                                                                                 .ContingencyCountyAmount = Item.ContingencyCountyAmount,
                                                                                                 .ContingencyCityAmount = Item.ContingencyCityAmount,
                                                                                                 .ContingencyNonResaleAmount = Item.ContingencyNonResaleAmount,
                                                                                                 .ContingencyLineTotalAmount = Item.ContingencyLineTotalAmount}).ToList

            Else

                RadGridEstimateInfo.DataSource = Nothing

            End If

            RadGridEstimateInfo.DataBind()

        End If

    End Sub

#Region " Page Methods "

    Private Sub purchaseorder_dtl_Init(sender As Object, e As EventArgs) Handles Me.Init

        HiddenFieldSecMod.Value = AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        If Not Request.QueryString("po_number") Is Nothing Then

            Try

                _PONumber = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number"))
                Session("PONumberPODetail") = _PONumber

            Catch ex As Exception
                _PONumber = Nothing
            End Try

        End If

        If Not Request.QueryString("line_number") Is Nothing Then

            Try

                _LineNumber = Request.QueryString("line_number")

            Catch ex As Exception
                _LineNumber = -1
            End Try

        End If

    End Sub
    Protected Sub purchaseorder_dtl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

        Me.LabelPOValidationMessage.Text = ""
        Me.LabelFunctionValidationMessage.Text = ""
        Me.LabelJobValidationMessage.Text = ""

        ' User has overridden Estimate Overage Warning, save and return to PO Header..
        If Not Request.QueryString("confirm_override_flg") Is Nothing Then

            If Request.QueryString("confirm_override_flg") = "1" Then

                Me.OverrideSaveAndRedirect()

            End If

        End If

        _PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, _PONumber)

        If Not Page.IsPostBack Then

            If _PurchaseOrder IsNot Nothing Then

                LoadPurchaseOrderInformation(_PurchaseOrder)

                If _LineNumber > 0 Then

                    PurchaseOrderDetail = (From Item In AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(_DbContext, _PurchaseOrder.Number)
                                           Where Item.LineNumber = _LineNumber
                                           Select Item).SingleOrDefault

                    If PurchaseOrderDetail IsNot Nothing Then

                        LoadPurchaseOrderDetailInformation(PurchaseOrderDetail)

                    End If

                End If

                Select Case Me.PageMode

                    Case PageModes.Edit

                        LoadControlSettings()

                        TextBoxLineDescription.Focus()

                        SetupPicklists()

                    Case PageModes.New

                        LoadControlSettings()

                        ulLineNumber.Visible = False

                        TextBoxLineDescription.Focus()

                        SetupPicklists()

                End Select

            End If

            EnableOrDisableActions()

        Else

            Select Case Request.Form("__EVENTARGUMENT")

                Case "SpecsDesc"

                    If Not Session("EstImportSpecText") Is Nothing Then

                        If Session("EstImportSpecText") <> "" Then

                            Me.TextBoxDetailDescription.Text = Session("EstImportSpecText")
                            Session("EstImportSpecText") = Nothing

                        End If

                    End If

                Case "SpecsInstruct"

                    If Not Session("EstImportSpecText") Is Nothing Then

                        If Session("EstImportSpecText") <> "" Then

                            Me.TextBoxInstructions.Text = Session("EstImportSpecText")
                            Session("EstImportSpecText") = Nothing

                        End If

                    End If

                Case "SpecsDescEst"

                    If Not Session("POEstimateComments") Is Nothing Then

                        If Session("POEstimateComments") <> "" Then

                            Me.TextBoxDetailDescription.Text = Session("POEstimateComments")
                            Session("POEstimateComments") = Nothing

                        End If

                    End If

                Case "SpecsInstructEst"

                    If Not Session("POEstimateComments") Is Nothing Then

                        If Session("POEstimateComments") <> "" Then

                            Me.TextBoxInstructions.Text = Session("POEstimateComments")
                            Session("POEstimateComments") = Nothing

                        End If

                    End If

            End Select

        End If

        CheckUserRights()

    End Sub
    Private Sub purchaseorder_dtl_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        Session("EstImportSpecTextDesc") = Nothing
        Session("EstImportSpecTextInst") = Nothing

    End Sub
    Private Sub purchaseorder_dtl_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            _DbContext.Dispose()

            _DbContext = Nothing

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Event Handlers "

    Private Sub RadToolbarPurchseOrderDetail_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarPurchseOrderDetail.ButtonClick

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim JobTypeCode As String = Nothing

        Select Case e.Item.Value

            Case "Save"

                Save()

            Case "Refresh"

                QueryString = New AdvantageFramework.Web.QueryString

                QueryString = QueryString.FromCurrent()

                QueryString.Page = "purchaseorder_dtl.aspx"

                MiscFN.ResponseRedirect(QueryString.ToString(True))

                Exit Sub

            Case "Vendor"

                QueryString = New AdvantageFramework.Web.QueryString

                If Not [String].IsNullOrWhiteSpace(TextBoxJobNumber.Text) AndAlso IsNumeric(TextBoxJobNumber.Text) AndAlso
                   Not [String].IsNullOrWhiteSpace(TextBoxJobComponentNumber.Text) AndAlso IsNumeric(TextBoxJobComponentNumber.Text) Then

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(_DbContext, CInt(TextBoxJobNumber.Text), CShort(TextBoxJobComponentNumber.Text))

                    If JobComponent IsNot Nothing Then

                        JobTypeCode = JobComponent.JobTypeCode

                    End If

                End If

                With QueryString

                    .Page = "purchaseorder_price.aspx"
                    .Add("vn_code", TextBoxVendorCode.Text)
                    .Add("job_type", JobTypeCode)
                    .Add("qty", RadNumericTextBoxQuantity.Text)
                    .Add("opener", Me.PageFilename)

                End With

                Me.OpenWindow("", QueryString.ToString(True))

        End Select
    End Sub
    Private Sub ImageButtonSpecsDetailDescription_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSpecsDetailDescription.Click

        'objects
        Dim URL As String = Nothing

        Try

            URL = [String].Format("Estimating_ImportSpecs.aspx?caller={0}&JobNum={1}&JobComp={2}&control={3}&PONum={4}&LineNum={5}",
                                  Me.PageFilename, Me.TextBoxJobNumber.Text, Me.TextBoxJobComponentNumber.Text, Me.TextBoxDetailDescription.ClientID, _PONumber, LabelLineNumber.Text)

            Me.OpenWindow("", URL, 520, 730)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImageButtonSpecsInstructions_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSpecsInstructions.Click

        'objects
        Dim URL As String

        Try

            URL = [String].Format("Estimating_ImportSpecs.aspx?caller={0}&JobNum={1}&JobComp={2}&control={3}&PONum={4}&LineNum={5}",
                                  Me.PageFilename, Me.TextBoxJobNumber.Text, Me.TextBoxJobComponentNumber.Text, Me.TextBoxInstructions.ClientID,
                                  _PONumber, LabelLineNumber.Text)

            Me.OpenWindow("", URL, 520, 730)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImageButtonEstimateDetailDescription_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonEstimateDetailDescription.Click

        'objects
        Dim URL As String

        Try

            URL = [String].Format("purchaseorder_memo_disp.aspx?memo_type=detail_instruct&control={0}&ref_id={1}&preselect_tab_id=0&str={2}&fn_code={3}&LineNum={4}&SeqNbr={5}",
                                  Me.TextBoxDetailDescription.ClientID, _PONumber, Me.TextBoxJobNumber.Text, Me.TextBoxFunctionCode.Text,
                                  LabelLineNumber.Text, Session("PODetailSeqNbr"))

            Me.OpenWindow("Purchase Order Job Estimate Comments", URL, 440, 660)
            'Me.OpenLookUp(URL)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImageButtonEstimateInstructions_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonEstimateInstructions.Click

        'objects
        Dim URL As String = Nothing

        Try

            URL = [String].Format("purchaseorder_memo_disp.aspx?memo_type=detail_instruct&control={0}&ref_id={1}&preselect_tab_id=0&str={2}&fn_code={3}&LineNum={4}&SeqNbr={5}",
                                  Me.TextBoxInstructions.ClientID, _PONumber, Me.TextBoxJobNumber.Text, Me.TextBoxFunctionCode.Text, LabelLineNumber.Text, Session("PODetailSeqNbr"))

            Me.OpenWindow("", URL, 440, 660)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButtonLoadEstimateData_Click(sender As Object, e As EventArgs) Handles RadButtonLoadEstimateData.Click

        ShowEstimateInfoPanel()

    End Sub
    Private Sub RadGridEstimateInfo_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstimateInfo.ItemDataBound

        'objects
        Dim VendorCode As String = Nothing
        Dim VendorName As String = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then

            Try

                VendorCode = e.Item.DataItem.VendorCode

            Catch ex As Exception
                VendorCode = Nothing
            End Try

            If Not [String].IsNullOrWhiteSpace(VendorCode) Then

                Try

                    VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, VendorCode).Name

                    TryCast(e.Item, Telerik.Web.UI.GridDataItem)("GridBoundColumnVendor").Text = VendorName

                Catch ex As Exception
                    VendorName = Nothing
                End Try

            End If

        End If

    End Sub

#End Region

#End Region

End Class
