Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Partial Public Class purchaseorderlist
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Private _POActionDataTable As DataTable = Nothing

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Find Purchase Order"
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        If Not Page.IsPostBack Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
            POpanel1.SetPanelControls()
            POpanel1.SetPickListItems()
            SelectTab()
            Me.POpanel1.TabIndex_Start = 1
            Me.POpanel1.Focus_PO_Field()
            'LoadPOList()
            If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
                Me.POpanel1.PO_Emp_Code = Session("EmpCode")
            End If
        End If
        Me.CheckUserRights()
    End Sub

    Sub LoadPOList()
        Dim dr As SqlDataReader
        Dim dt As New DataTable
        Dim totalrows As Integer
        Dim tIssueDate As DateTime
        Dim tIssueEndDate As DateTime
        Dim tDueDate As DateTime
        Dim printed As Integer
        Dim voided As Integer
        Dim closed As Integer

        If Me.POpanel1.PO_Issue_Date.Trim = "" Then
            tIssueDate = Nothing  'allow empty string to be passed for single date search..
        Else
            If cGlobals.wvIsDate(Me.POpanel1.PO_Issue_Date) = True Then
                If IsNumeric(Me.POpanel1.PO_Issue_Date.Trim) = True Then
                    tIssueDate = cGlobals.wvCDate(Me.POpanel1.PO_Issue_Date.Trim)
                Else
                    tIssueDate = cGlobals.wvCDate(Me.POpanel1.PO_Issue_Date.Trim)
                End If
            Else
                Exit Sub
            End If
        End If

        If Me.POpanel1.PO_Issue_End_Date.Trim = "" Then
            tIssueEndDate = Nothing  'allow empty string to be passed for single date search..
        Else
            If cGlobals.wvIsDate(Me.POpanel1.PO_Issue_End_Date) = True Then
                If IsNumeric(Me.POpanel1.PO_Issue_End_Date.Trim) = True Then
                    tIssueEndDate = cGlobals.wvCDate(Me.POpanel1.PO_Issue_End_Date.Trim)
                Else
                    tIssueEndDate = cGlobals.wvCDate(Me.POpanel1.PO_Issue_End_Date.Trim)
                End If
            Else
                Exit Sub
            End If
        End If

        'validate date range.
        If Me.POpanel1.PO_Issue_End_Date.Trim <> "" Then
            If cGlobals.wvCDate(Me.POpanel1.PO_Issue_End_Date.Trim) < cGlobals.wvCDate(Me.POpanel1.PO_Issue_Date.Trim) Then
                Me.ShowMessage("**Search Failed: Issued From Date must be less than Issued To Date.")
                Exit Sub
            End If
        End If

        'check due date format if entered...
        If Me.POpanel1.PO_Due_Date.Trim = "" Then
            tDueDate = Nothing
        Else
            If cGlobals.wvIsDate(Me.POpanel1.PO_Due_Date) = True Then
                If IsNumeric(Me.POpanel1.PO_Due_Date) = True Then
                    tDueDate = cGlobals.wvCDate(Me.POpanel1.PO_Due_Date)
                Else
                    tDueDate = cGlobals.wvCDate(Me.POpanel1.PO_Due_Date)
                End If
            Else
                Exit Sub
            End If
        End If

        If Me.POpanel1.PO_Printed = True Then
            printed = 1
        Else
            printed = 0
        End If
        If Me.POpanel1.PO_Voided = True Then
            voided = 1
        Else
            voided = 0
        End If
        If Me.POpanel1.PO_Closed = True Then
            closed = 1
        Else
            closed = 0
        End If

        Dim PO As wPurchaseOrder.cPurchaseOrder = New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        Try

            _POActionDataTable = PO.GetPOActions()

        Catch ex As Exception

        End Try

        Try
            If (POpanel1.PO_Number.ToString.IndexOf("Pending") > -1 Or _
                POpanel1.PO_Number.ToString.IndexOf("Denied") > -1 Or _
                POpanel1.PO_Number.ToString.IndexOf("Incomplete") > -1) And _
                (IsNumeric(POpanel1.PO_NumberHf) = True) Then
                dt = PO.LoadAll_POList(Int32.Parse(POpanel1.Filter_Options.Trim), POpanel1.PO_NumberHf, POpanel1.PO_Description,
                                        tIssueDate, tDueDate, POpanel1.PO_Emp_Code,
                                         POpanel1.PO_Vendor_Code, POpanel1.PO_Cient_Code, POpanel1.PO_Division_Code,
                                         POpanel1.PO_Product_Code, POpanel1.PO_Job_Number, tIssueEndDate, Me.POpanel1.PO_Job_Comp_Nbr.Trim,
                                         "", 0, 0, totalrows, POpanel1.PO_Request_Status, printed, POpanel1.PO_Approver_Code, voided, closed, Session("UserCode")).Tables(1)
            Else
                'If IsNumeric(POpanel1.PO_Number) = True Then
                dt = PO.LoadAll_POList(Int32.Parse(POpanel1.Filter_Options.Trim), POpanel1.PO_Number, POpanel1.PO_Description,
                                        tIssueDate, tDueDate, POpanel1.PO_Emp_Code,
                                         POpanel1.PO_Vendor_Code, POpanel1.PO_Cient_Code, POpanel1.PO_Division_Code,
                                         POpanel1.PO_Product_Code, POpanel1.PO_Job_Number, tIssueEndDate, Me.POpanel1.PO_Job_Comp_Nbr.Trim,
                                         "", 0, 0, totalrows, POpanel1.PO_Request_Status, printed, POpanel1.PO_Approver_Code, voided, closed, Session("UserCode")).Tables(1)
                'End If
            End If
            Try
                Me.RadGridPurchaseOrderSearch.DataSource = dt
                'Me.RadGridPurchaseOrderSearch.DataBind()
                Me.RadGridPurchaseOrderSearch.CurrentPageIndex = Me.CurrentGridPageIndex
                Me.RadGridPurchaseOrderSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridPurchaseOrderSearch.ID)

            Catch ex As Exception
            End Try

        Catch ex As Exception
            Dim sb1 As New System.Text.StringBuilder
            sb1.Append(ex.Message)
            Me.ShowMessage(sb1.ToString())
            sb1 = Nothing
        Finally
            PO = Nothing
        End Try

    End Sub

    Private Sub SelectTab(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try
            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    If CInt(Request.QueryString("Tab")) = 1 Then
                        Me.RadTabStripAR.Tabs(0).Selected = True
                    ElseIf CInt(Request.QueryString("Tab")) = 2 Then
                        Me.RadTabStripAR.Tabs(1).Selected = True
                    End If
                Else
                    Me.RadTabStripAR.Tabs(0).Selected = True
                End If
            Catch ex As Exception
                Me.ShowMessage("tab error")
            End Try
        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub POpanel1_Clear_Search_Clicked() Handles POpanel1.Clear_Search_Clicked
        Dim row As System.Web.UI.WebControls.GridViewRow
        Try
            'For Each row In Me.gvw_po.Rows
            '    If row.RowType = DataControlRowType.DataRow Then
            '        row.Visible = False
            '    End If
            'Next
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub POpanel1_Search_Clicked() Handles POpanel1.Search_Clicked
        If Me.POpanel1.PO_Number.Trim <> "" And POpanel1.Filter_Options.Trim <> "1" Then 'PO# exists in search, OR-Search not selected...
            If Me.POpanel1.PO_Number = "(Pending)" Or Me.POpanel1.PO_Number = "(Denied)" Or Me.POpanel1.PO_Number = "(Incomplete)" Then
                If IsNumeric(Me.POpanel1.PO_NumberHf.Trim) = True Then
                    FindSinglePO(Int32.Parse(Me.POpanel1.PO_NumberHf.Trim))
                End If
            Else
                If IsNumeric(Me.POpanel1.PO_Number.Trim) = True Then
                    FindSinglePO(Int32.Parse(Me.POpanel1.PO_Number.Trim))
                End If
            End If
        End If
        RadGridPurchaseOrderSearch.DataSource = Nothing
        RadGridPurchaseOrderSearch.Rebind()
        'LoadPOList()
    End Sub

    Sub FindSinglePO(ByVal ponum As Integer)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If (From Item In AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(DbContext, _Session.UserCode, False, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                Where Item.Number = ponum
                Select Item).Any Then

                DirectToPurchaseOrder(ponum.ToString(), False)

            Else

                Me.ShowMessage("Invalid PO Number")

            End If

        End Using

    End Sub

    Function ReturnListIcon(ByVal voided As Integer) As String
        If voided = 1 Then
            ReturnListIcon = "images/navigate_check_grayed.png"
        Else
            ReturnListIcon = "images/navigate_check.png"
        End If
    End Function

    Sub DirectToPurchaseOrder(ByVal strPONum As String, ByVal IsCopy As Boolean)
        Dim sb As New System.Text.StringBuilder

        sb.Append("purchaseorder.aspx?po_number=")
        sb.Append(AdvantageFramework.Security.Encryption.EncryptPO(strPONum.Trim))

        If IsCopy Then

            sb.Append("&pagemode=copy")

        Else

            sb.Append("&pagemode=edit")

        End If

        Dim str As String = sb.ToString
        Me.OpenWindow("", sb.ToString())
        sb = Nothing
    End Sub

    Private Sub RadToolBarPurchaseOrderList_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPurchaseOrderList.ButtonClick
        Select Case e.Item.Value
            Case "Search"
                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                If Me.POpanel1.PO_Number.Trim <> "" Then
                    Try
                        If Me.POpanel1.PO_Number = "(Pending)" Or Me.POpanel1.PO_Number = "(Denied)" Or Me.POpanel1.PO_Number = "(Incomplete)" Then
                            If myVal.ValidatePONumber(Me.POpanel1.PO_NumberHf.Trim) = True Then
                                FindSinglePO(Int32.Parse(Me.POpanel1.PO_NumberHf.Trim))
                            Else
                                Me.ShowMessage("Invalid PO Number")
                                Exit Sub
                            End If
                        Else
                            If myVal.ValidatePONumber(Me.POpanel1.PO_Number.Trim) = True Then
                                FindSinglePO(Int32.Parse(Me.POpanel1.PO_Number.Trim))
                            Else
                                Me.ShowMessage("Invalid PO Number")
                                Exit Sub
                            End If
                        End If
                    Catch OutOfRange As System.OverflowException
                        Me.ShowMessage("Invalid PO Number")
                        Exit Sub
                    Catch fex As System.FormatException
                        Me.ShowMessage("Invalid PO Number")
                        Exit Sub
                    Catch ex As Exception
                        Me.ShowMessage("Invalid PO Number")
                        Exit Sub
                    End Try
                End If

                If Me.POpanel1.PO_Job_Number.Trim <> "" Then
                    Try
                        If IsNumeric(Me.POpanel1.PO_Job_Number) = False Then
                            Me.ShowMessage("Invalid Job Number")
                            Exit Sub
                        Else
                            If myVal.ValidateJobPO(Me.POpanel1.PO_Job_Number) = False Then
                                Me.ShowMessage("Invalid Job Number")
                                Exit Sub
                            End If
                        End If
                    Catch OutOfRange As System.OverflowException
                        Me.ShowMessage("Invalid Job Number")
                        Exit Sub
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If
                If Me.POpanel1.PO_Job_Comp_Nbr.Trim <> "" And Me.POpanel1.PO_Job_Number.Trim <> "" Then
                    If IsNumeric(Me.POpanel1.PO_Job_Comp_Nbr.Trim) = False Then
                        Me.ShowMessage("Invalid Job Component Number")
                        Exit Sub
                    ElseIf IsNumeric(Me.POpanel1.PO_Job_Number) = True Then
                        If myVal.ValidateJobCompPO(Me.POpanel1.PO_Job_Number, Me.POpanel1.PO_Job_Comp_Nbr) = False Then
                            Me.ShowMessage("Invalid Job Component Number")
                            Exit Sub
                        End If
                    End If
                Else
                    If Me.POpanel1.PO_Job_Comp_Nbr.Trim <> "" And Me.POpanel1.PO_Job_Number.Trim = "" Then
                        Me.ShowMessage("Enter valid Job Number")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Due_Date.Trim <> "" Then
                    If wvIsDate(Me.POpanel1.PO_Due_Date) = False Then
                        Me.ShowMessage("Invalid Due Date")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Issue_Date.Trim <> "" Then
                    If wvIsDate(Me.POpanel1.PO_Issue_Date) = False Then
                        Me.ShowMessage("Invalid Issue From Date")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Issue_End_Date.Trim <> "" Then
                    If wvIsDate(Me.POpanel1.PO_Issue_End_Date) = False Then
                        Me.ShowMessage("Invalid Issue To Date")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Issue_End_Date.Trim <> "" And Me.POpanel1.PO_Issue_Date = "" Then
                    Me.ShowMessage("Please enter an Issue From Date")
                    Exit Sub
                End If

                If Me.POpanel1.PO_Cient_Code <> "" Then
                    If myVal.ValidateCDP(Me.POpanel1.PO_Cient_Code.Trim, "", "") = False Then
                        Me.ShowMessage("Invalid Client Code")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Division_Code <> "" Then
                    If myVal.ValidateDivision("", Me.POpanel1.PO_Division_Code.Trim, "") = False Then
                        Me.ShowMessage("Invalid Division Code")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Product_Code <> "" Then
                    If myVal.ValidateProduct("", "", Me.POpanel1.PO_Product_Code.Trim) = False Then
                        Me.ShowMessage("Invalid Product Code")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Vendor_Code <> "" Then
                    If myVal.ValidateVendor(Me.POpanel1.PO_Vendor_Code.Trim) = False Then
                        Me.ShowMessage("Invalid Vendor Code")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Emp_Code <> "" Then
                    If myVal.ValidateEmpCode(Me.POpanel1.PO_Emp_Code.Trim) = False Then
                        Me.ShowMessage("Invalid Issued By Code")
                        Exit Sub
                    End If
                End If

                If Me.POpanel1.PO_Approver_Code <> "" Then
                    If myVal.ValidatePOApprover(Me.POpanel1.PO_Approver_Code.Trim) = False Then
                        Me.ShowMessage("Invalid PO Approver")
                        Exit Sub
                    End If
                End If
                RadGridPurchaseOrderSearch.DataSource = Nothing
                RadGridPurchaseOrderSearch.Rebind()
            Case "Clear"
                POpanel1.ClearSearchCriteria()
                RadGridPurchaseOrderSearch.DataSource = Nothing
                RadGridPurchaseOrderSearch.Rebind()
            Case "New"
                Me.OpenWindow("", "purchaseorder.aspx?pagemode=new")
        End Select


    End Sub

    Private Sub RadGridPurchaseOrderSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridPurchaseOrderSearch.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridPurchaseOrderSearch.ID, Me.RadGridPurchaseOrderSearch.PageSize)
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Select", "Copy"
                Dim lab As System.Web.UI.WebControls.HiddenField
                lab = e.Item.FindControl("hfPONumber")

                If e.CommandName = "Copy" Then

                    Me.DirectToPurchaseOrder(lab.Value, True)

                Else
                    
                    Me.DirectToPurchaseOrder(lab.Value, False)

                End If
            Case "Print"
                Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                Dim sec As New cSecurity(Session("ConnString"))
                Dim dsPO As SqlDataReader
                Dim sb1 As New System.Text.StringBuilder
                Dim lab As System.Web.UI.WebControls.HiddenField
                lab = e.Item.FindControl("hfPONumber")
                POHeader.Select_POHeader(Int32.Parse(lab.Value), "")
                dsPO = PODtl.LoadAll_PO_Detail_List(1, Int32.Parse(lab.Value), "", "")
                If dsPO.HasRows = False Then
                    Me.ShowMessage("You must select a purchase order with detail to print.")
                    Exit Sub
                End If
                Session("CurrPOSearchddoptions") = Me.POpanel1.Filter_Options
                Session("CurrPOSearchDesc") = Me.POpanel1.PO_Description
                Session("CurrPOSearchJob") = Me.POpanel1.PO_Job_Number
                Session("CurrPOSearchComp") = Me.POpanel1.PO_Job_Comp_Nbr
                Session("CurrPOSearchClient") = Me.POpanel1.PO_Cient_Code
                Session("CurrPOSearchDivision") = Me.POpanel1.PO_Division_Code
                Session("CurrPOSearchProduct") = Me.POpanel1.PO_Product_Code
                Session("CurrPOSearchFromDate") = Me.POpanel1.PO_Issue_Date
                Session("CurrPOSearchToDate") = Me.POpanel1.PO_Issue_End_Date
                Session("CurrPOSearchDueDate") = Me.POpanel1.PO_Due_Date
                Session("CurrPOSearchVendor") = Me.POpanel1.PO_Vendor_Code
                Session("CurrPOSearchIssuedBy") = Me.POpanel1.PO_Emp_Code
                Session("CurrPOSearchApprover") = Me.POpanel1.PO_Approver_Code
                Session("CurrPOSearchPOStatus") = Me.POpanel1.PO_Request_Status
                Session("CurrPOSearchPrinted") = Me.POpanel1.PO_Printed

                sb1.Append("PurchaseOrder_Print.aspx?po_number=")

                sb1.Append(AdvantageFramework.Security.Encryption.EncryptPO(lab.Value))
                sb1.Append("&callingpagemode=edit&from=search")
                'sb1.Append(lbl_pagemode.Text.Trim)
                Me.OpenWindow("", sb1.ToString())

        End Select
    End Sub

    Private Sub RadGridPurchaseOrderSearch_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridPurchaseOrderSearch.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                Dim imgbtn As System.Web.UI.WebControls.ImageButton

                Dim label As System.Web.UI.WebControls.Label = e.Item.FindControl("lblPOStatus")
                If label.Text = "0" Then
                    label.Text = ""
                End If
                If label.Text = "1" Then
                    label.Text = "Pending"
                End If
                If label.Text = "2" Then
                    label.Text = "Approved"
                End If
                If label.Text = "3" Then
                    label.Text = "Denied"
                End If
                label = e.Item.FindControl("lblPODate")
                If label.Text <> "" And label.Text <> "&nbsp;" Then
                    label.Text = LoGlo.FormatDate(label.Text)
                Else
                    label.Text = "(?)"
                End If
                label = e.Item.FindControl("lblPODueDate")
                If label.Text <> "" And label.Text <> "&nbsp;" Then
                    label.Text = LoGlo.FormatDate(label.Text)
                Else
                    label.Text = "(?)"
                End If
                Dim PrintImageButton As Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonPrint")
                Dim PrintDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivPrint")
                Dim ponumber As Web.UI.WebControls.HiddenField = e.Item.FindControl("hfPONumber")
                Dim labelPONum As Web.UI.WebControls.Label = e.Item.FindControl("lblPONumber")
                Dim usercode As String = ""
                Dim username As String = ""

                labelPONum.Text = e.Item.DataItem("DISPLAY_PO_NUMBER")

                Dim ActionRow As DataRow = Nothing

                Try

                    ActionRow = (From Row In _POActionDataTable.Rows.OfType(Of System.Data.DataRow)
                                 Where Row("PONumber") = e.Item.DataItem("PO_NUMBER")
                                 Select Row).FirstOrDefault

                Catch ex As Exception

                End Try

                If ActionRow IsNot Nothing Then

                    If ActionRow("AllowPrint") = False Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(PrintDiv)

                    End If

                End If

                'imgbtn = e.Item.FindControl("ImgBtnPrint")
                If e.Item.DataItem("VOID_FLAG") = 1 Then

                    PrintImageButton.Visible = False
                Else

                    AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

                End If

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub RadGridPurchaseOrderSearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridPurchaseOrderSearch.NeedDataSource

        LoadPOList()

    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridPurchaseOrderSearch_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridPurchaseOrderSearch.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridPurchaseOrderSearch.Rebind()
    End Sub

    Private Function checkApprovalCode(ByVal empcode As String)
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""

        dept = oEmp.GetDept(empcode)
        empApproval = PO.GetPOApprRuleCodebyEmp(empcode)
        If dept <> "" Then
            deptApproval = PO.GetPOApprRuleCodebyDept(dept)
        End If
        If empApproval = "" And deptApproval = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String
            Dim custom1 As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders), "Y", "N")

            If secView = "N" Then
                'Me.Purchaseordernav1.Allow_Print = False
            End If
            If secInsert = "N" Then
                Me.RadToolBarPurchaseOrderList.Items.FindItemByValue("New").Enabled = False
            End If
            If secEdit = "N" Then
                'Me.Purchaseordernav1.Allow_Save = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridPurchaseOrderSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridPurchaseOrderSearch.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridPurchaseOrderSearch.ID, e.NewPageSize)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If Me.POpanel1.PO_Number.Trim <> "" Then
                Try
                    If Me.POpanel1.PO_Number = "(Pending)" Or Me.POpanel1.PO_Number = "(Denied)" Or Me.POpanel1.PO_Number = "(Incomplete)" Then
                        If myVal.ValidatePONumber(Me.POpanel1.PO_NumberHf.Trim) = True Then
                            FindSinglePO(Int32.Parse(Me.POpanel1.PO_NumberHf.Trim))
                        Else
                            Me.ShowMessage("Invalid PO Number")
                            Exit Sub
                        End If
                    Else
                        If myVal.ValidatePONumber(Me.POpanel1.PO_Number.Trim) = True Then
                            FindSinglePO(Int32.Parse(Me.POpanel1.PO_Number.Trim))
                        Else
                            Me.ShowMessage("Invalid PO Number")
                            Exit Sub
                        End If
                    End If
                Catch OutOfRange As System.OverflowException
                    Me.ShowMessage("Invalid PO Number")
                    Exit Sub
                Catch fex As System.FormatException
                    Me.ShowMessage("Invalid PO Number")
                    Exit Sub
                Catch ex As Exception
                    Me.ShowMessage("Invalid PO Number")
                    Exit Sub
                End Try
            End If

            If Me.POpanel1.PO_Job_Number.Trim <> "" Then
                Try
                    If IsNumeric(Me.POpanel1.PO_Job_Number) = False Then
                        Me.ShowMessage("Invalid Job Number")
                        Exit Sub
                    Else
                        If myVal.ValidateJobPO(Me.POpanel1.PO_Job_Number) = False Then
                            Me.ShowMessage("Invalid Job Number")
                            Exit Sub
                        End If
                    End If
                Catch OutOfRange As System.OverflowException
                    Me.ShowMessage("Invalid Job Number")
                    Exit Sub
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End If
            If Me.POpanel1.PO_Job_Comp_Nbr.Trim <> "" And Me.POpanel1.PO_Job_Number.Trim <> "" Then
                If IsNumeric(Me.POpanel1.PO_Job_Comp_Nbr.Trim) = False Then
                    Me.ShowMessage("Invalid Job Component Number")
                    Exit Sub
                ElseIf IsNumeric(Me.POpanel1.PO_Job_Number) = True Then
                    If myVal.ValidateJobCompPO(Me.POpanel1.PO_Job_Number, Me.POpanel1.PO_Job_Comp_Nbr) = False Then
                        Me.ShowMessage("Invalid Job Component Number")
                        Exit Sub
                    End If
                End If
            Else
                If Me.POpanel1.PO_Job_Comp_Nbr.Trim <> "" And Me.POpanel1.PO_Job_Number.Trim = "" Then
                    Me.ShowMessage("Enter valid Job Number")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Due_Date.Trim <> "" Then
                If wvIsDate(Me.POpanel1.PO_Due_Date) = False Then
                    Me.ShowMessage("Invalid Due Date")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Issue_Date.Trim <> "" Then
                If wvIsDate(Me.POpanel1.PO_Issue_Date) = False Then
                    Me.ShowMessage("Invalid Issue From Date")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Issue_End_Date.Trim <> "" Then
                If wvIsDate(Me.POpanel1.PO_Issue_End_Date) = False Then
                    Me.ShowMessage("Invalid Issue To Date")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Issue_End_Date.Trim <> "" And Me.POpanel1.PO_Issue_Date = "" Then
                Me.ShowMessage("Please enter an Issue From Date")
                Exit Sub
            End If

            If Me.POpanel1.PO_Cient_Code <> "" Then
                If myVal.ValidateCDP(Me.POpanel1.PO_Cient_Code.Trim, "", "") = False Then
                    Me.ShowMessage("Invalid Client Code")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Division_Code <> "" Then
                If myVal.ValidateDivision("", Me.POpanel1.PO_Division_Code.Trim, "") = False Then
                    Me.ShowMessage("Invalid Division Code")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Product_Code <> "" Then
                If myVal.ValidateProduct("", "", Me.POpanel1.PO_Product_Code.Trim) = False Then
                    Me.ShowMessage("Invalid Product Code")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Vendor_Code <> "" Then
                If myVal.ValidateVendor(Me.POpanel1.PO_Vendor_Code.Trim) = False Then
                    Me.ShowMessage("Invalid Vendor Code")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Emp_Code <> "" Then
                If myVal.ValidateEmpCode(Me.POpanel1.PO_Emp_Code.Trim) = False Then
                    Me.ShowMessage("Invalid Issued By Code")
                    Exit Sub
                End If
            End If

            If Me.POpanel1.PO_Approver_Code <> "" Then
                If myVal.ValidatePOApprover(Me.POpanel1.PO_Approver_Code.Trim) = False Then
                    Me.ShowMessage("Invalid PO Approver")
                    Exit Sub
                End If
            End If
            RadGridPurchaseOrderSearch.DataSource = Nothing
            RadGridPurchaseOrderSearch.Rebind()
        Catch ex As Exception

        End Try
    End Sub



End Class
