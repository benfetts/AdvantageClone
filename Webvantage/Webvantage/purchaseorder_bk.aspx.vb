Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals
Imports Telerik.Web.UI
Imports System.Drawing

Partial Public Class purchaseorder_bk
    Inherits Webvantage.BaseChildPage
    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Me.PageTitle = "Purchase Order"

        Me.Purchaseordernav1.EnableBookmarks = Me.EnableBookmarks

        If Not Request.QueryString("po_number") Is Nothing Then
            PO_NUMBER.Text = AdvantageFramework.StringUtilities.RijndaelSimpleDecryptPO(Request.QueryString("po_number"))
        End If
        If Not Request.QueryString("pagemode") Is Nothing Then
            lbl_pagemode.Text = Request.QueryString("pagemode")
        End If
        If Not Page.IsPostBack Then

            If Not Session("POAlertSentApprovals") Is Nothing Then
                If Session("POAlertSentApprovals") = True Then
                    Me.ShowError("Approval Alerts sent.")
                    Session("POAlertSentApprovals") = False
                    PO_NUMBER.Text = Session("PONumberApproval")
                    Session("PONumberApproval") = ""
                End If
            End If
            Select Case lbl_pagemode.Text.Trim
                Case "read"
                    RetrievePOData()
                    Purchaseordernav1.Allow_Void = False
                    Purchaseordernav1.Allow_Revision_Increment = False
                    Purchaseordernav1.Allow_New = False
                    CheckFlags_POApproval()
                Case "edit"
                    RetrievePOData()
                    Lock_Issue_Info() 'lock issue to vendor/ issuer info...
                    Purchaseordernav1.Allow_New = True
                    Me.PO_DESCRIPTION.Focus()
                    CheckFlags_POApproval()
                    Me.UpdatePOHeader()
                Case "copy"
                    RetrievePOData()
                    UnLock_Issue_Info()
                    Purchaseordernav1.Allow_New_Line = False
                    Purchaseordernav1.Allow_Copy = False
                    Purchaseordernav1.Allow_Void = False
                    Purchaseordernav1.Allow_Print = False
                    Purchaseordernav1.Allow_Estimate_View = False
                    Purchaseordernav1.Allow_Revision_Increment = False
                    Purchaseordernav1.Allow_Send = False
                    Purchaseordernav1.Allow_New = False
                    Purchaseordernav1.Allow_Comments = False
                    Purchaseordernav1.Allow_CancelApproval = False
                    Me.PO_DESCRIPTION.Focus()
                    CheckFlags_POApproval()
                    Me.UpdatePOHeader()
                    If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
                        Me.EMP_CODE.Text = Session("EmpCode")
                        Me.EMP_CODE.ReadOnly = True
                    End If
                Case "new"
                    img_postat.ImageUrl = "images/add2.png"
                    PO_NUMBER.Text = "(New)"
                    PO_PAD.Text = "(New)"
                    Me.RadDatePickerPO_DATE.SelectedDate = String.Format("{0:d}", Now)

                    Purchaseordernav1.Allow_New_Line = False
                    Purchaseordernav1.Allow_Copy = False
                    Purchaseordernav1.Allow_Void = False
                    Purchaseordernav1.Allow_Print = False
                    Purchaseordernav1.Allow_Estimate_View = False
                    Purchaseordernav1.Allow_Revision_Increment = False
                    Purchaseordernav1.Allow_Send = False
                    RetrieveSessionEmployee()
                    Purchaseordernav1.Allow_New = False
                    Purchaseordernav1.Allow_Comments = False
                    Purchaseordernav1.Allow_CancelApproval = False
                    Me.PO_DESCRIPTION.Focus()
                    If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
                        Me.EMP_CODE.Text = Session("EmpCode")
                        Me.EMP_CODE.ReadOnly = True
                    End If
            End Select
            SetLookups() 'for popup lookups            

            Purchaseordernav1.ControlCausesValidation = False

            Purchaseordernav1.SetEstimatePopupWindow(PO_NUMBER.Text.Trim)

            With Me.RadToolTipManagerPO.TargetControls
                .Clear()
                .Add(Me.lbl_Approval.ClientID, PO_NUMBER.Text, True)
            End With

            If Request.QueryString("Fromjj") = "jjpo" Then
                Purchaseordernav1.Allow_List = False
                Purchaseordernav1.Allow_Copy = False
                Purchaseordernav1.Allow_Send = False
                Purchaseordernav1.Allow_New = False
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    Session("POAlertSentApprovals") = True
                    If Request.QueryString("Fromjj") = "jjpo" Then
                        MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(Session("PONumberApproval")) & "&pagemode=edit&Fromjj=jjpo")
                        Exit Sub
                    Else
                        MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(Session("PONumberApproval")) & "&pagemode=edit")
                        Exit Sub
                    End If

            End Select
        End If
        Me.CheckUserRights()
    End Sub

    Sub RetrievePOData()
        Dim err As Integer


        err = LoadPurchaseOrderHeader()

        If err <> 0 Then  'handle fatal error if PO header can't be opened (conflict with Advantage client software)..
            LockPage()
            Me.Purchaseordernav1.Allow_Void = False
            Me.Purchaseordernav1.Allow_Revision_Increment = False
            Me.Purchaseordernav1.Allow_Estimate_View = False
            Me.Purchaseordernav1.Allow_Copy = False
            'Me.Purchaseordernav1.Allow_Print_Options = False
            Me.Purchaseordernav1.Allow_Print = False
            Me.Purchaseordernav1.Allow_Send = False
            'Me.Purchaseorder_memo_nav1.Visible = False

            Me.PO_PAD.Text = Me.PO_NUMBER.Text.Trim
            Me.ShowError("Problem Opening this Order.  May be in use.")
        End If


        LoadPurchaseOrderDetail()
    End Sub
    Sub LockPage()
        Dim dgc As DataGridColumn

        Purchaseordernav1.Allow_Void = False
        Purchaseordernav1.Allow_Revision_Increment = False
        Purchaseordernav1.Allow_Save = False
        'butSave.Enabled = False
        Me.PO_DESCRIPTION.ReadOnly = True
        Me.RadDatePickerPO_DATE.Enabled = True
        Me.RadDatePickerPO_DUE_DATE.Enabled = True
        Me.EMP_CODE.ReadOnly = True
        Me.PO_WORK_COMPLETE.Enabled = False
        Me.VN_CODE.ReadOnly = True
        Me.VC_CODE.ReadOnly = True
        Me.hl_issuer.Enabled = False
        Me.hl_vendor.Enabled = False
        Me.lbtn_issue_by.Enabled = False

        Me.Purchaseordernav1.Allow_New_Line = False
        'Me.Purchaseorder_memo_nav1.Detail_Add_Button_Enabled = False
        Me.lbtn_set_contact.Visible = False
        'Me.img_lock.Visible = True
        Me.lbl_pagemode.Text = "read"

    End Sub
    Sub Lock_Issue_Info()
        Me.lbtn_issue_by.Visible = False
        Me.EMP_CODE.ReadOnly = True
        Me.ISSUED_BY_EMP.ReadOnly = True
        Me.VN_CODE.ReadOnly = True
        Me.VN_NAME.ReadOnly = True
        'Me.VC_CODE.ReadOnly = True
        Me.hl_issuer.Enabled = False
        Me.hl_vendor.Enabled = False
        'Me.hlContacts.Enabled = False
    End Sub
    Sub UnLock_Issue_Info()
        Me.lbtn_issue_by.Visible = False
        Me.EMP_CODE.ReadOnly = False
        Me.ISSUED_BY_EMP.ReadOnly = False
        Me.VN_CODE.ReadOnly = False
        Me.VN_NAME.ReadOnly = False
        Me.VC_CODE.ReadOnly = False
        Me.hl_issuer.Enabled = True
        Me.hl_vendor.Enabled = True
        Me.hlContacts.Enabled = True
    End Sub
    Sub LoadPurchaseOrderDetail()
        Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim dr_PO_Detail As SqlDataReader
    End Sub
    Sub SetLookups()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        'issue to and issuer info. selection only available on a new order.
        If Me.lbl_pagemode.Text.Trim = "new" Or Me.lbl_pagemode.Text.Trim = "copy" Then
            If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
                Me.hl_issuer.Attributes.Add("onclick", "")
            Else
                Me.hl_issuer.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=purchaseorder&type=po_issuer_active&control=" & Me.EMP_CODE.ClientID & "&control2=" & Me.ISSUED_BY_EMP.ClientID & "&control3=" & Me.PO_LIMIT.ClientID & "');return false;")
            End If
            Me.hl_vendor.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=purchaseorder&type=vendor_and_contact&control=" & Me.VN_CODE.ClientID & "&control2=" & Me.VN_NAME.ClientID & "&control3=" & Me.ADDRESS1.ClientID & "&control4=" & Me.ADDRESS2.ClientID & "&control5=" & Me.CITYSTATEZIP.ClientID & "&control6=" & Me.VC_CODE.ClientID & "&control7=" & Me.VC_NAME.ClientID & "&control8=" & Me.VC_EMAIL.ClientID & "&control9=" & Me.ADDRESS3.ClientID & "');return false;")
        Else
            Me.hl_vendor.Enabled = False
            Me.hl_issuer.Enabled = False
        End If
        Me.hlContacts.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=purchaseorder&type=vendor_contacts&str=' + document.forms[0].ctl00_ContentPlaceHolderMain_VN_CODE.value + '&control=" & Me.VC_CODE.ClientID & "&control2=" & Me.VC_NAME.ClientID & "&control3=" & Me.VC_EMAIL.ClientID & "');return false;")
    End Sub
    Function LoadPurchaseOrderHeader() As Integer
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim usercode, username, spolimit As String

        Try
            POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")
            Try
                If IsDate(POHeader.PO_Date) = True Then
                    Me.RadDatePickerPO_DATE.SelectedDate = LoGlo.FormatDate(POHeader.PO_Date)
                End If
            Catch ex As Exception
            End Try
            PO_PAD.Text = POHeader.PO_Pad.Trim
            VN_CODE.Text = POHeader.Vendor_Code.Trim
            EMP_CODE.Text = POHeader.Issue_By_Emp_Code.Trim
            PO_DESCRIPTION.Text = POHeader.PO_Description.Trim
            ISSUED_BY_EMP.Text = POHeader.Issue_By_Emp_Name.Trim
            VN_NAME.Text = POHeader.Vendor_Name.Trim
            Try
                If IsDate(POHeader.PO_Due_Date) = True Then
                    Me.RadDatePickerPO_DUE_DATE.SelectedDate = LoGlo.FormatDate(POHeader.PO_Due_Date)
                End If
            Catch ex As Exception
            End Try
            ADDRESS1.Text = POHeader.Vendor_Address1.Trim
            ADDRESS2.Text = POHeader.Vendor_Address2.Trim
            ADDRESS3.Text = POHeader.Vendor_Address3.Trim
            CITYSTATEZIP.Text = POHeader.Vendor_CityStateZip.Trim
            VC_CODE.Text = POHeader.Vendor_Contact_Code.Trim
            VC_NAME.Text = POHeader.Vendor_Contact_Name.Trim
            VC_EMAIL.Text = POHeader.Vendor_Contact_Email.Trim
            PO_TOTAL.Text = String.Format("{0:#,##0.00}", CDbl(POHeader.PO_Total))
            lbl_Rev.Text = POHeader.PO_Revision.ToString
            Label_ModifiedBy.Text = POHeader.ModifiedBy
            Try
                Label_ModifiedDate.Text = POHeader.ModifiedDate
            Catch ex As Exception
                Label_ModifiedDate.Text = ""
            End Try

            If POHeader.PO_Work_Complete = True Then
                PO_WORK_COMPLETE.Checked = True
            End If

            'Pull max PO limit based on empcode of issuer... This info is not recorded on the Purchase Order.
            PO_LIMIT.Text = (POHeader.Get_PO_Emp_Limit(1, EMP_CODE.Text.Trim, usercode, username)).ToString.Trim
            If CDec(PO_LIMIT.Text) < 0 Then
                Me.PO_LIMIT.Text = ""
            Else
                Me.PO_LIMIT.Text = String.Format("{0:#,##0.00}", CDbl(PO_LIMIT.Text))
            End If

            If POHeader.PO_Voided = True Then
                If POHeader.PO_Approval_Flag = 3 Then
                    lbl_voidflag.Visible = False
                Else
                    lbl_voidflag.Visible = True
                    Purchaseordernav1.Allow_Void = False
                    Purchaseordernav1.Allow_Revision_Increment = False
                    Purchaseordernav1.Allow_Send = False
                    Purchaseordernav1.Allow_Print = False
                    'Purchaseordernav1.Allow_Comments = False
                    'Purchaseordernav1.Allow_Estimate_View = False
                    LockPage()
                End If
            End If

            If POHeader.PO_Complete = True Then
                'lbl_msg.ForeColor = Color.Red
                'lbl_msg.Text = "Purchase Order is Completed and Cannot be Edited."
                lbl_completeflag.Visible = True
                lbl_cbe.Visible = True
                LockPage()
                Purchaseordernav1.Allow_Void = False
            End If

            Return 0
        Catch ex As Exception
            Return 1
        End Try

    End Function

    Sub RetrieveIssuerMaxPOLimit()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim usercode, username As String

        'Pull max PO limit based on empcode of issuer...
        Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, EMP_CODE.Text.Trim, usercode, username)
        If polimit = -1.0 Then
            PO_LIMIT.Text = ""
        Else
            PO_LIMIT.Text = String.Format("{0:#,##0.00}", polimit)
        End If
        'PO_LIMIT.Text = String.Format("{0:#,##0.00}", POHeader.Get_PO_Emp_Limit(1, EMP_CODE.Text.Trim, usercode, username))

    End Sub
    Sub GetPOVendorDefaultContact()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim scode As String
        Dim sname As String
        Dim semail As String
        POHeader.Get_PO_Vendor_Primary_Contact(VN_CODE.Text.Trim, scode, sname, semail)
        VC_CODE.Text = scode.Trim
        VC_NAME.Text = sname.Trim
        VC_EMAIL.Text = semail.Trim
    End Sub
    Private Sub CheckFlags_POApproval()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dsPO As SqlDataReader
        Dim dsPOAppr As SqlDataReader
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""
        Dim PONum As Integer = 0
        Try
            If IsNumeric(PO_NUMBER.Text.Trim()) = False Then

                PO_NUMBER.Text = AdvantageFramework.StringUtilities.RijndaelSimpleDecryptPO(PO_NUMBER.Text.Trim())
            End If
        Catch ex As Exception
        End Try
        POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")
        dsPOAppr = PO.GetPOApprovals(Int32.Parse(PO_NUMBER.Text.Trim))
        If dsPOAppr.HasRows Then
            If POHeader.PO_Approval_Flag = 0 Then
                Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                Me.Purchaseordernav1.Allow_Print = True
                Me.lbl_Approval.Text = ""
                Me.Purchaseordernav1.Allow_CancelApproval = False
            End If
            If POHeader.PO_Approval_Flag = 1 Then
                Me.PO_PAD.Text = "(Pending)"
                Me.Purchaseordernav1.Allow_Print = False
                Me.lbl_Approval.Visible = True
                Me.lbl_Approval.Text = "Pending"
                Me.Purchaseordernav1.Allow_CancelApproval = True
                Me.LockPage()
            End If
            If POHeader.PO_Approval_Flag = 2 Then
                Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                Me.Purchaseordernav1.Allow_Print = True
                Me.lbl_Approval.Visible = True
                Me.lbl_Approval.Text = "Approved"
                Me.Purchaseordernav1.Allow_New_Line = False
                Me.Purchaseordernav1.Allow_Revision_Increment = False
                Me.Purchaseordernav1.Allow_CancelApproval = True
            End If
            If POHeader.PO_Approval_Flag = 3 Then
                Me.PO_PAD.Text = "(Denied)"
                Me.Purchaseordernav1.Allow_Print = True
                Me.lbl_Approval.Visible = True
                Me.lbl_Approval.Text = "Denied"
                Me.Purchaseordernav1.Allow_CancelApproval = False
            End If
        Else
            dsPO = PODtl.LoadAll_PO_Detail_List(1, Int32.Parse(PO_NUMBER.Text.Trim), "", "")
            If PO.GetPOReqdExtAmount_Flg() Then
                If dsPO.HasRows = False Or Me.PO_TOTAL.Text = "" Or Me.PO_TOTAL.Text = "0.00" Then
                    Me.PO_PAD.Text = "(Incomplete)"
                    Me.Purchaseordernav1.Allow_Print = False
                    Me.Purchaseordernav1.Allow_CancelApproval = False
                Else
                    If POHeader.PO_Appr_Rule_Code <> "" Then
                        If Me.PO_LIMIT.Text = "" Then
                            Me.PO_PAD.Text = "(Incomplete)"
                            Me.Purchaseordernav1.Allow_CancelApproval = False
                        Else
                            If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                Me.PO_PAD.Text = "(Incomplete)"
                                Me.Purchaseordernav1.Allow_CancelApproval = False
                            ElseIf POHeader.Exceed = 0 And POHeader.PO_Printed = 1 Then
                                Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                                Me.Purchaseordernav1.Allow_Print = True
                                Me.Purchaseordernav1.Allow_CancelApproval = False
                            ElseIf POHeader.Exceed = 1 Then
                                Me.PO_PAD.Text = "(Incomplete)"
                                Me.Purchaseordernav1.Allow_CancelApproval = False
                            End If
                        End If
                    Else
                        Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                        Me.Purchaseordernav1.Allow_Print = True
                        Me.Purchaseordernav1.Allow_CancelApproval = False
                    End If
                End If
            Else
                If POHeader.PO_Appr_Rule_Code <> "" Then
                    If Me.PO_LIMIT.Text = "" Then
                        Me.PO_PAD.Text = "(Incomplete)"
                        Me.Purchaseordernav1.Allow_CancelApproval = False
                    Else
                        If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                            Me.PO_PAD.Text = "(Incomplete)"
                            Me.Purchaseordernav1.Allow_CancelApproval = False
                        ElseIf POHeader.Exceed = 0 And POHeader.PO_Printed = 1 Then
                            Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                            Me.Purchaseordernav1.Allow_Print = True
                            Me.Purchaseordernav1.Allow_CancelApproval = False
                        ElseIf POHeader.Exceed = 1 Then
                            Me.PO_PAD.Text = "(Incomplete)"
                            Me.Purchaseordernav1.Allow_CancelApproval = False
                        End If
                    End If
                Else
                    Me.PO_PAD.Text = POHeader.PO_Pad.Trim
                    Me.Purchaseordernav1.Allow_Print = True
                    Me.Purchaseordernav1.Allow_CancelApproval = False
                End If

            End If
        End If
        If POHeader.PO_Voided = True And POHeader.PO_Approval_Flag <> 3 Then
            Purchaseordernav1.Allow_Print = False
        End If
    End Sub
    Private Function checkApprovalCode()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""

        dept = oEmp.GetDept(EMP_CODE.Text)
        empApproval = PO.GetPOApprRuleCodebyEmp(EMP_CODE.Text)
        If dept <> "" Then
            deptApproval = PO.GetPOApprRuleCodebyDept(dept)
        End If
        If empApproval = "" And deptApproval = "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function getApprovalCode()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""

        dept = oEmp.GetDept(EMP_CODE.Text)
        empApproval = PO.GetPOApprRuleCodebyEmp(EMP_CODE.Text)
        If dept <> "" Then
            deptApproval = PO.GetPOApprRuleCodebyDept(dept)
        End If
        If empApproval <> "" Then
            Return empApproval
        ElseIf deptApproval <> "" Then
            Return deptApproval
        Else
            Return ""
        End If
    End Function

    Private Sub Purchaseordernav1_PO_CancelApproval_Clicked() Handles Purchaseordernav1.PO_CancelApproval_Clicked
        Try
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim delete As Integer
            Dim sec As New cSecurity(Session("ConnString"))
            If (Me.PO_PAD.Text = "(Pending)" Or Me.lbl_Approval.Text = "Approved") Then
                delete = PODtl.DeletePOApproval(Int32.Parse(PO_NUMBER.Text.Trim))
                If delete = 1 Then
                    Me.ShowError("Delete Failed.")
                End If
            End If

            If Request.QueryString("Fromjj") = "jjpo" Then
                MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim) & "&pagemode=edit&Fromjj=jjpo")
                Exit Sub
            Else
                MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim) & "&pagemode=edit")
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Purchaseordernav1_PO_Bookmark_Clicked() Handles Purchaseordernav1.PO_Bookmark_Clicked

        Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
        Dim qs As New AdvantageFramework.Web.QueryString()

        qs = qs.FromCurrent()

        With b

            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
            .UserCode = Session("UserCode")
            .Name = "PO: " & PO_PAD.Text
            .PageURL = "purchaseorder.aspx" & qs.ToString()

        End With

        Dim s As String = ""
        If BmMethods.SaveBookmark(b, s) = False Then
            Me.ShowError(s)
        Else
            Me.RefreshBookmarksDesktopObject()
        End If

    End Sub


    Private Sub Purchaseordernav1_PO_Comments_Clicked() Handles Purchaseordernav1.PO_Comments_Clicked
        UpdatePOHeader()
        DirectToMemoPage("po_main_instruct")
    End Sub
    Private Sub Purchaseordernav1_PO_Copy_Clicked() Handles Purchaseordernav1.PO_Copy_Clicked
        UpdatePOHeader()
        Dim sb1 As New System.Text.StringBuilder
        sb1.Append("purchaseorder_copy.aspx?ponumber=")

        sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
        sb1.Append("&callingpage=purchaseorder")
        sb1.Append("&rc=")
        sb1.Append(Me.getApprovalCode())
        Me.OpenWindow("", sb1.ToString())
        sb1 = Nothing
    End Sub

    Private Sub Purchaseordernav1_PO_Estimate_Clicked() Handles Purchaseordernav1.PO_Estimate_Clicked
        'Server.Transfer("purchaseorder_estimates.aspx?ponumber=" + PO_NUMBER.Text.Trim)
        Dim strURL As String

        UpdatePOHeader()
        strURL = "purchaseorder_funct_summ.aspx?calledfrom=custom&po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim())
        Me.OpenWindow("", strURL, 570, 830)
    End Sub

    Private Sub Purchaseordernav1_PO_List_Clicked() Handles Purchaseordernav1.PO_List_Clicked
        UpdatePOHeader()
        Me.RefreshCaller("purchaseorderlist.aspx")
    End Sub

    Private Sub EMP_CODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EMP_CODE.TextChanged
        Dim cEmp As New Webvantage.cEmployee(Session("ConnString"))
        ISSUED_BY_EMP.Text = cEmp.GetName(EMP_CODE.Text.Trim)
    End Sub

    Protected Sub lbtn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_refresh.Click
        Dim cEmp As New Webvantage.cEmployee(Session("ConnString"))
        ISSUED_BY_EMP.Text = cEmp.GetName(EMP_CODE.Text.Trim)
    End Sub
    Sub InsertPOHeader()
        Dim tDueDate As Object
        Dim tPODate As DateTime
        Dim sNewPONum As String
        Dim sError As String
        Dim error_count As Integer
        Dim work_complete As Int16
        Dim session_user As String = ""
        Dim ts As TimeSpan
        Dim strError As String = ""

        If Not String.IsNullOrEmpty(Session("UserCode")) Then
            session_user = Session("UserCode")
        End If


        If Me.PO_DESCRIPTION.Text = "" Or Me.EMP_CODE.Text = "" Or Me.VN_CODE.Text = "" Then
            If Me.PO_DESCRIPTION.Text = "" Then
                strError &= "Purchase Order Description is Required.\n"
                'Exit Sub
            End If
            If Me.EMP_CODE.Text = "" Then
                strError &= "Issued By (Employee Code) is Required.\n"
                'Exit Sub
            End If
            If Me.VN_CODE.Text = "" Then
                strError &= "Issued To (Vendor Code) is Required.\n"
                'Exit Sub
            End If
            If strError <> "" Then
                Me.ShowError(strError)
                Exit Sub
            End If
        End If


        If MiscFN.ValidDate(Me.RadDatePickerPO_DUE_DATE, True) = False Then
            Me.ShowError("Invalid Due Date")
            Exit Sub
        End If
        If MiscFN.ValidDate(Me.RadDatePickerPO_DATE, True) = False Then
            Me.ShowError("Invalid Order Date")
            Exit Sub
        End If
        Try
            tPODate = CDate(Me.RadDatePickerPO_DATE.SelectedDate)
        Catch
            tPODate = cGlobals.wvCDate(Me.RadDatePickerPO_DATE.SelectedDate)
        End Try

        If Me.RadDatePickerPO_DUE_DATE.SelectedDate = Nothing Then
            tDueDate = System.DBNull.Value
        Else
            If Me.RadDatePickerPO_DUE_DATE.SelectedDate.HasValue = True Then
                tDueDate = cGlobals.wvCDate(Me.RadDatePickerPO_DUE_DATE.SelectedDate)
                'Check's that PO due date is higher than or same as PO date        
                ts = (CType(tDueDate.subtract(tPODate), TimeSpan))
                If ts.TotalDays < 0 Then
                    Me.ShowError("Invalid Due Date")
                    Exit Sub
                End If
            End If
        End If

        If PO_WORK_COMPLETE.Checked = True Then
            work_complete = 1
        Else
            work_complete = 0
        End If

        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim sec As New cSecurity(Session("ConnString"))

        'check for database integrity errors before save.
        error_count = POHeader.ValidatePOHeader(EMP_CODE.Text.Trim, VN_CODE.Text.Trim, VC_CODE.Text.Trim, sError)
        If error_count <> 0 Then
            Me.ShowError(sError.Trim)
            Exit Sub
        End If

        Try
            sNewPONum = POHeader.Insert_POHeader(session_user.Trim, VN_CODE.Text.Trim, VC_CODE.Text.Trim, EMP_CODE.Text.Trim, _
             tPODate, tDueDate, PO_DESCRIPTION.Text.Trim, 0, 0, work_complete, getApprovalCode()).ToString

            MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(sNewPONum.Trim) & "&pagemode=edit")
            Exit Sub
        Catch ex As Exception
            Me.ShowError(ex.Message.ToString)
        End Try


    End Sub
    Sub UpdatePOHeader()
        Dim tDueDate As Date = Nothing
        Dim tPODate As Date = Nothing
        Dim sError As String
        Dim error_count As Integer
        Dim work_complete As Int16
        Dim session_user As String
        Dim exceed_flag As Integer
        Dim ts As TimeSpan
        Dim strError As String = ""


        If Not String.IsNullOrEmpty(Session("UserCode")) Then
            session_user = Session("UserCode")
        End If


        If Me.PO_DESCRIPTION.Text = "" Or Me.EMP_CODE.Text = "" Or Me.VN_CODE.Text = "" Then
            If Me.PO_DESCRIPTION.Text = "" Then
                strError &= "Purchase Order Description is Required.\n"
                'Exit Sub
            End If
            If Me.EMP_CODE.Text = "" Then
                strError &= "Issued By (Employee Code) is Required.\n"
                'Exit Sub
            End If
            If Me.VN_CODE.Text = "" Then
                strError &= "Issued To (Vendor Code) is Required.\n"
                'Exit Sub
            End If
            If strError <> "" Then
                Me.ShowError(strError)
                Exit Sub
            End If
        End If



        If MiscFN.ValidDate(Me.RadDatePickerPO_DUE_DATE, True) = False Then
            Me.ShowError("Invalid Due Date")
            Exit Sub
        Else
            If Not Me.RadDatePickerPO_DUE_DATE.SelectedDate Is Nothing Then
                tDueDate = Me.RadDatePickerPO_DUE_DATE.SelectedDate
            End If
        End If
        If MiscFN.ValidDate(Me.RadDatePickerPO_DATE, False) = False Then
            Me.ShowError("Invalid Order Date")
            Exit Sub
        Else
            If Not Me.RadDatePickerPO_DATE.SelectedDate Is Nothing Then
                tPODate = Me.RadDatePickerPO_DATE.SelectedDate
            End If
        End If

        'If Not Me.RadDatePickerPO_DUE_DATE.SelectedDate Is Nothing Then
        '    If MiscFN.ValidDateRange(Me.RadDatePickerPO_DATE, Me.RadDatePickerPO_DUE_DATE) = False Then
        '        Me.ShowError("Invalid date range")
        '        Exit Sub
        '    End If
        'End If

        If PO_WORK_COMPLETE.Checked = True Then
            work_complete = 1
        Else
            work_complete = 0
        End If

        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        'check for database integrity errors before save.
        error_count = POHeader.ValidatePOHeader(EMP_CODE.Text.Trim, VN_CODE.Text.Trim, VC_CODE.Text.Trim, sError)
        If error_count <> 0 Then
            Me.ShowError(sError)
            Exit Sub
        End If

        If Me.PO_LIMIT.Text <> "" Then
            If CDec(Me.PO_LIMIT.Text) < CDec(Me.PO_TOTAL.Text) Then
                exceed_flag = 1
            Else
                exceed_flag = 0
            End If
        End If
        'Dim complete As Integer
        'POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")
        'If POHeader.PO_Complete = True Then
        '    complete = 1
        'Else
        '    complete = 0
        'End If

        Try
            POHeader.Update_POHeader(Int32.Parse(PO_NUMBER.Text.Trim), session_user.Trim, VN_CODE.Text.Trim, VC_CODE.Text.Trim, EMP_CODE.Text.Trim, _
             tPODate, tDueDate, PO_DESCRIPTION.Text.Trim, 0, 0, work_complete, exceed_flag)
            LoadPurchaseOrderHeader()
            CheckFlags_POApproval()
            'If Me.lbl_pagemode.Text = "copy" Then
            '    Server.Transfer("purchaseorder.aspx?po_number=" & Int32.Parse(PO_NUMBER.Text.Trim) & "&pagemode=copy")
            'End If

        Catch ex As Exception
            Me.ShowError(ex.Message.ToString())
        End Try
    End Sub



    Protected Sub lbtn_set_contact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_set_contact.Click
        GetPOVendorDefaultContact()
    End Sub

    Sub RedirectPONewLine()
        Dim approve As Boolean = Me.checkApprovalCode
        Dim sb1 As New System.Text.StringBuilder
        Dim sec As New cSecurity(Session("ConnString"))
        sb1.Append("purchaseorder_dtl.aspx?po_number=")

        sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
        sb1.Append("&line_number=-1")
        sb1.Append("&pagemode=new")
        If approve = False Then
            sb1.Append("&approve=1")
        End If
        If Request.QueryString("Fromjj") = "jjpo" Then
            sb1.Append("&Fromjj=jjpo")
        End If
        Me.OpenWindow("", sb1.ToString())
        sb1 = Nothing
    End Sub

    Private Sub Purchaseordernav1_PO_New_Clicked() Handles Purchaseordernav1.PO_New_Clicked
        Select Case lbl_pagemode.Text.Trim
            Case "new"
                InsertPOHeader()
            Case "edit"
                UpdatePOHeader()
            Case "copy"
                UpdatePOHeader()
        End Select
        Me.OpenWindow("", "purchaseorder.aspx?pagemode=new")
    End Sub

    Private Sub Purchaseordernav1_PO_New_Row_Clicked() Handles Purchaseordernav1.PO_New_Row_Clicked

        UpdatePOHeader()
        RedirectPONewLine()

    End Sub

    Private Function NavSetHeader() As Boolean

        UpdatePOHeader()

        If Me.lbl_pagemode.Text = "copy" Then

            Me.lbl_pagemode.Text = "edit"

        End If

        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim dsPO As SqlDataReader
        Dim sec As New cSecurity(Session("ConnString"))

        POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")
        dsPO = PODtl.LoadAll_PO_Detail_List(1, Int32.Parse(PO_NUMBER.Text.Trim), "", "")

        If dsPO.HasRows = False Then

            Me.ShowError("You must select a purchase order with detail to print.")
            Return False

        Else

            Return True

        End If

    End Function
    Private Function NavNeedsApprovalAndApprove() As Boolean

        If NavSetHeader() = True Then

            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")

            If (Me.PO_PAD.Text = "" Or Me.PO_PAD.Text = "(Pending)" Or Me.PO_PAD.Text = "(Incomplete)" Or _
                        Me.PO_PAD.Text = "(Denied)") And POHeader.Exceed = 1 Then
                Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                Dim oEmp As New cEmployee(Session("ConnString"))
                Dim dept As String
                Dim deptApproval As String = ""
                Dim empApproval As String = ""
                Dim rulecode As String = ""
                Dim delete As Integer

                If Me.PO_PAD.Text = "(Denied)" Then

                    'delete = PODtl.DeletePOApproval(Int32.Parse(PO_NUMBER.Text.Trim))
                    'If delete = 1 Then
                    '    Me.ShowError(""Delete Failed."
                    'End If
                    'POHeader.Void_PO_Undo(Int32.Parse(PO_NUMBER.Text.Trim))

                End If

                dept = oEmp.GetDept(EMP_CODE.Text)
                empApproval = PO.GetPOApprRuleCodebyEmp(EMP_CODE.Text)

                If dept <> "" Then

                    deptApproval = PO.GetPOApprRuleCodebyDept(dept)

                End If

                If empApproval <> "" Then

                    rulecode = empApproval

                Else

                    rulecode = deptApproval

                End If

                Session("POAmount") = Me.PO_TOTAL.Text

                Me.OpenWindow("Purchase Order Approval", "purchaseorder_approval.aspx?PONum=" & Me.PO_NUMBER.Text & "&rulecode=" & rulecode & "&state=" & Me.PO_PAD.Text, 150, 450)

                Return True

            Else

                Return False

            End If

        Else

            Return False

        End If
    End Function
    Private Sub Purchaseordernav1_PO_Print_Clicked() 'Handles Purchaseordernav1.PO_Print_Clicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim sb1 As New System.Text.StringBuilder
            sb1.Append("PurchaseOrder_Print.aspx?po_number=")

            sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
            sb1.Append("&callingpagemode=")
            sb1.Append(lbl_pagemode.Text.Trim)
            If Request.QueryString("Fromjj") = "jjpo" Then
                sb1.Append("&Fromjj=jjpo")
            End If
            Me.OpenWindow("", sb1.ToString())
            sb1 = Nothing

        End If

    End Sub

    Private Sub PurchaseOrderNav1_PrintClicked() Handles Purchaseordernav1.PrintClicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "PurchaseOrder_Print.aspx"

            qs.Add("po_number", AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
            qs.Add("callingpagemode", lbl_pagemode.Text.Trim())
            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then qs.Add("Fromjj", "jjpo")
            qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

            Me.OpenPrintSendSilently(qs)

        End If

    End Sub
    Private Sub PurchaseOrderNav1_SendAlertClicked() Handles Purchaseordernav1.SendAlertClicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "PurchaseOrder_Print.aspx"

            qs.Add("po_number", AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim()))
            qs.Add("callingpagemode", lbl_pagemode.Text.Trim())
            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then qs.Add("FromJJ", "jjpo")
            qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

            Me.OpenPrintSendSilently(qs)

        End If
    End Sub
    Private Sub PurchaseOrderNav1_SendEmailClicked() Handles Purchaseordernav1.SendEmailClicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "PurchaseOrder_Print.aspx"

            qs.Add("po_number", AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
            qs.Add("callingpagemode", lbl_pagemode.Text.Trim())
            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then qs.Add("Fromjj", "jjpo")
            qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

            Me.OpenPrintSendSilently(qs)

        End If
    End Sub
    Private Sub PurchaseOrderNav1_PrintSendOptionsClicked() Handles Purchaseordernav1.PrintSendOptionsClicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "PurchaseOrder_Print.aspx"

            qs.Add("po_number", AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
            qs.Add("callingpagemode", lbl_pagemode.Text.Trim())
            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then qs.Add("Fromjj", "jjpo")
            qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

            Me.OpenWindow(qs)

        End If

    End Sub

    ' ''Private Sub Purchaseordernav1_PO_Print_Options_Clicked() Handles Purchaseordernav1.PO_Print_Options_Clicked

    ' ''    UpdatePOHeader()
    ' ''    If Me.lbl_pagemode.Text = "copy" Then
    ' ''        Me.lbl_pagemode.Text = "edit"
    ' ''    End If
    ' ''    Dim sb1 As New System.Text.StringBuilder
    ' ''    Dim sec As New cSecurity(Session("ConnString"))
    ' ''    sb1.Append("PurchaseOrder_Print.aspx?po_number=")

    ' ''    sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
    ' ''    sb1.Append("&callingpagemode=")
    ' ''    sb1.Append(lbl_pagemode.Text.Trim)
    ' ''    If Request.QueryString("Fromjj") = "jjpo" Then
    ' ''        sb1.Append("&Fromjj=jjpo")
    ' ''    End If
    ' ''    'Server.Transfer(sb1.ToString())
    ' ''    Me.OpenWindow("", sb1.ToString())
    ' ''    sb1 = Nothing

    ' ''End Sub

    Private Sub Purchaseordernav1_PO_Refresh_Clicked() Handles Purchaseordernav1.PO_Refresh_Clicked
        If Me.lbl_pagemode.Text = "copy" Then
            Me.lbl_pagemode.Text = "edit"
        End If
        Dim sb As New System.Text.StringBuilder
        Dim sec As New cSecurity(Session("ConnString"))
        sb.Append("purchaseorder.aspx?po_number=")

        sb.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
        sb.Append("&pagemode=")
        sb.Append(lbl_pagemode.Text.Trim)
        If Request.QueryString("Fromjj") = "jjpo" Then
            sb.Append("&Fromjj=jjpo")
        End If
        Response.Redirect(sb.ToString())
        sb = Nothing
    End Sub

    Private Sub Purchaseordernav1_PO_Revision_Clicked() Handles Purchaseordernav1.PO_Revision_Clicked
        UpdatePOHeader()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim newnum As Int16

        newnum = POHeader.Increment_PO_Revision(1, Int32.Parse(PO_NUMBER.Text.Trim))
        lbl_Rev.Text = newnum.ToString

    End Sub

    Private Sub Purchaseordernav1_PO_Save_Clicked() Handles Purchaseordernav1.PO_Save_Clicked
        Select Case lbl_pagemode.Text.Trim
            Case "new"
                InsertPOHeader()
            Case "edit"
                UpdatePOHeader()

                Try

                    Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Session("ConnString"), Session("UserCode"))

                        If AdvantageFramework.Database.Procedures.PurchaseOrder.SetPOModified(ObjectContext, Int32.Parse(PO_NUMBER.Text.Trim)) Then

                            Label_ModifiedBy.Text = Session("UserCode")
                            Label_ModifiedDate.Text = System.DateTime.Today

                        End If

                    End Using

                Catch ex As Exception

                End Try

            Case "copy"
                UpdatePOHeader()

                If Me.lbl_pagemode.Text = "copy" Then
                    MiscFN.ResponseRedirect("purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(Int32.Parse(PO_NUMBER.Text.Trim)) & "&pagemode=edit")
                    Exit Sub
                End If
        End Select
    End Sub
    Private Sub Purchaseordernav1_PO_Void_Clicked() Handles Purchaseordernav1.PO_Void_Clicked
        UpdatePOHeader()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim chk As CheckBox
        Dim count As Integer = 0
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.radGridPO.MasterTableView.Items
            chk = CType(gridDataItem("colAP").FindControl("ckAP"), CheckBox)
            If chk.Checked Then
                count += 1
            End If
        Next
        If count > 0 Then
            Me.ShowError("PO cannot be voided because invoices have been applied.")
            Exit Sub
        Else
            POHeader.Void_PO(Int32.Parse(PO_NUMBER.Text.Trim), Session("UserCode"))
        End If

        If Request.QueryString("Fromjj") = "jjpo" Then
            'Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
            'With sbScript
            '    .Append("<script type=""text/javascript"">")
            '    .Append("window.close();</script>")
            'End With
            'Try
            '    If Not Page.IsStartupScriptRegistered("POHidePopups") Then
            '        Dim str As String = sbScript.ToString
            '        Page.RegisterStartupScript("POHidePopups", str)
            '    End If
            'Catch ex As Exception
            '    Me.ShowError("Error! " & ex.Message.ToString())
            'End Try
            Me.CloseThisWindow()
        Else
            'Server.Transfer("purchaseorderlist.aspx")
            Me.CloseThisWindowAndRefreshCaller("purchaseorderlist.aspx", False)
        End If
    End Sub

    Sub DirectToMemoPage(ByVal update_column As String)
        If Me.lbl_pagemode.Text = "copy" Then
            Me.lbl_pagemode.Text = "edit"
        End If
        Dim sb1 As New System.Text.StringBuilder

        sb1.Append("purchaseorder_memos.aspx?po_number=")
        sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
        sb1.Append("&update_column=")
        sb1.Append(update_column.Trim)
        sb1.Append("&pagemode=")
        sb1.Append(lbl_pagemode.Text.Trim)
        If Request.QueryString("Fromjj") = "jjpo" Then
            sb1.Append("&Fromjj=jjpo")
        End If

        'Server.Transfer(sb1.ToString())
        Me.OpenWindow("", sb1.ToString())

        sb1 = Nothing

    End Sub

    Protected Sub lbtn_issue_by_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_issue_by.Click
        RetrieveSessionEmployee()
    End Sub
    Sub RetrieveSessionEmployee()
        ' retrieve logged employee and set empcode as PO Issuer.
        Dim usercode, username As String
        EMP_CODE.Text = Session("Empcode")
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        POHeader.Get_PO_Emp_Limit(1, EMP_CODE.Text.Trim, usercode, username)
        Dim cEmp As New Webvantage.cEmployee(Session("ConnString"))
        ISSUED_BY_EMP.Text = cEmp.GetName(EMP_CODE.Text.Trim)
        RetrieveIssuerMaxPOLimit()
    End Sub

    Private Sub radGridPO_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridPO.DeleteCommand
        Select Case e.CommandName
            Case "Update"
                Dim lab As Label
                lab = e.Item.FindControl("lblLineNumber")
                Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                PODetail.DeletePODetail(Int32.Parse(PO_NUMBER.Text.Trim), Int32.Parse(lab.Text))
                e.Item.Edit = False
                'LoadPurchaseOrderDetail()
                PO_TOTAL.Text = String.Format("{0:F3}", PODetail.GetPOTotal(Int32.Parse(PO_NUMBER.Text.Trim)))
                Me.radGridPO.Rebind()
            Case "Cancel"
                e.Item.Edit = False
                'LoadPurchaseOrderDetail()
        End Select
    End Sub

    Private Sub radGridPO_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridPO.ItemCommand
        Select Case e.CommandName
            Case "Select"
                UpdatePOHeader()
                Dim approve As Boolean = Me.checkApprovalCode
                Dim sb1 As New System.Text.StringBuilder
                Dim lab As Label

                lab = e.Item.FindControl("lblLineNumber")
                sb1.Append("purchaseorder_dtl.aspx?po_number=")
                sb1.Append(AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim))
                sb1.Append("&line_number=") 'reference to PO number.
                sb1.Append(lab.Text)
                sb1.Append("&pagemode=edit")
                If approve = False Then
                    sb1.Append("&approve=1")
                End If
                If Request.QueryString("Fromjj") = "jjpo" Then
                    sb1.Append("&Fromjj=jjpo")
                End If
                Me.OpenWindow("", sb1.ToString())
            Case "Edit"
                e.Item.Edit = True
                'LoadPurchaseOrderDetail()
            Case "Update"
                Dim lab As Label
                lab = e.Item.FindControl("lblLineNumber")
                Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                PODetail.DeletePODetail(Int32.Parse(PO_NUMBER.Text.Trim), Int32.Parse(lab.Text))
                e.Item.Edit = False
                'LoadPurchaseOrderDetail()
                PO_TOTAL.Text = String.Format("{0:F3}", PODetail.GetPOTotal(Int32.Parse(PO_NUMBER.Text.Trim)))
            Case "Cancel"
                e.Item.Edit = False
                'LoadPurchaseOrderDetail()
        End Select
    End Sub

    Private Sub radGridPO_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridPO.ItemDataBound
        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim glselect As Integer
        glselect = PODtl.GetPOGLAccountSelection(Me.EMP_CODE.Text)
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                Dim dr As SqlDataReader
                Dim lab As Label
                Dim lab2 As Label
                Dim lab3 As Label
                Dim lab4 As Label
                Dim lab5 As Label
                Dim lab6 As Label
                lab = e.Item.FindControl("lblJobNumber")
                lab2 = e.Item.FindControl("lblCompNumber")
                lab3 = e.Item.FindControl("lblFunctionCode")
                If lab.Text <> "" And lab2.Text <> "" Then
                    dr = PODtl.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(1, CInt(lab.Text), CInt(lab2.Text), lab3.Text)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            lab4 = e.Item.FindControl("lblPOUsed")
                            lab5 = e.Item.FindControl("lblBalance")
                            lab6 = e.Item.FindControl("lblEstimate")
                            lab4.Text = String.Format("{0:#,##0.00}", dr("PO_EXIST_AMT"))
                            lab5.Text = String.Format("{0:#,##0.00}", dr("BALANCE"))
                            lab6.Text = String.Format("{0:#,##0.00}", dr("EST_REV_EXT_AMT"))
                        Loop
                    End If
                    dr.Close()
                End If
                If lab.Text <> "" Then
                    lab.Text = lab.Text.PadLeft(6, "0")
                End If
                If lab2.Text <> "" Then
                    lab2.Text = lab2.Text.PadLeft(2, "0")
                End If
                lab.Text = lab.Text & "-" & lab2.Text
                Dim imagebutDetail As ImageButton
                imagebutDetail = e.Item.FindControl("ibtn_po")
                Dim imagebutDelete As ImageButton
                imagebutDelete = e.Item.FindControl("sel_del_edit")
                Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

                Dim oEmp As New cEmployee(Session("ConnString"))
                Dim dsPO As SqlDataReader
                Dim dsPOAppr As SqlDataReader
                Dim usercode As String = ""
                Dim username As String = ""
                POHeader.Select_POHeader(Int32.Parse(PO_NUMBER.Text), "")
                dsPOAppr = PO.GetPOApprovals(Int32.Parse(PO_NUMBER.Text))
                Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
                If dsPOAppr.HasRows Then
                    If POHeader.PO_Approval_Flag = 0 Then
                        'printImage.Visible = True
                    End If
                    If POHeader.PO_Approval_Flag = 1 Then
                        imagebutDetail.Visible = False
                        imagebutDelete.Visible = False
                    End If
                    If POHeader.PO_Approval_Flag = 2 Then
                        'imagebutDetail.Visible = False
                        imagebutDelete.Visible = False
                    End If
                    If POHeader.PO_Approval_Flag = 3 Then
                        'printImage.Visible = False
                        'labelPONum.Text = "(Denied)"
                    End If
                End If
                If POHeader.PO_Voided = True Then
                    imagebutDelete.Visible = False
                End If
                lab = e.Item.FindControl("lblGLAccount")
                If glselect <> 1 Then
                    e.Item.Cells(10).Visible = False
                Else
                    Dim drBC As SqlDataReader
                    drBC = POHeader.GetPOBudgetComparisons(LoGlo.FormatDate(POHeader.PO_Date), lab.Text)
                    lab4 = e.Item.FindControl("lblPOUsed")
                    lab5 = e.Item.FindControl("lblBalance")
                    lab6 = e.Item.FindControl("lblEstimate")
                    If drBC.HasRows = True Then
                        Do While drBC.Read
                            lab4.Text = String.Format("{0:#,##0.00}", drBC("POUsed"))
                            lab5.Text = String.Format("{0:#,##0.00}", drBC("Balance"))
                            lab6.Text = String.Format("{0:#,##0.00}", drBC("Budget"))
                        Loop
                        drBC.Close()
                    End If
                End If
                lab = e.Item.FindControl("lblPORate")
                If lab.Text = "0.000" Then
                    lab.Text = ""
                End If
                lab = e.Item.FindControl("lblExtendedAmount")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblPORate")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblMarkupAmount")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblLineTotal")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If

            Case Telerik.Web.UI.GridItemType.Header
                If glselect <> 1 Then
                    e.Item.Cells(10).Visible = False
                End If
        End Select
    End Sub

    Private Sub radGridPO_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridPO.NeedDataSource
        Dim dr_PO_Detail2 As SqlDataReader
        Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        If lbl_pagemode.Text <> "new" Then
            dr_PO_Detail2 = PODetail.LoadAll_PO_Detail_List(1, Int32.Parse(PO_NUMBER.Text.Trim), "", "")
        End If
        Me.radGridPO.DataSource = dr_PO_Detail2
    End Sub


    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub

    Private Sub UpdateToolTip(ByVal ArgumentValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As Control = Page.LoadControl("purchaseorder_Approval_Tooltip.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As purchaseorder_Approval_Tooltip = DirectCast(ctrl, purchaseorder_Approval_Tooltip)
        With t
            .PONumber = ArgumentValue
        End With
    End Sub

    Private Sub LbPONumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbPONumber.Click
        If Request.QueryString("Fromjj") = "jjpo" Then
            Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
            With sbScript
                .Append("<script type=""text/javascript"">")
                .Append("window.close();</script>")
            End With
            Try
                If Not Page.IsStartupScriptRegistered("POHidePopups") Then
                    Dim str As String = sbScript.ToString
                    Page.RegisterStartupScript("POHidePopups", str)
                End If
            Catch ex As Exception
                Me.ShowError("Error! " & ex.Message.ToString())
            End Try
        Else
            Server.Transfer("purchaseorderlist.aspx")
        End If
    End Sub

    Private Sub Page_PreInit1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'If Request.QueryString("Fromjj") = "jjpo" Then
        '    Me.Page.MasterPageFile = "ApplicationMaster.Master"
        'End If
    End Sub

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
                Me.Purchaseordernav1.Allow_Print = False
            End If
            If secInsert = "N" Then
                Me.Purchaseordernav1.Allow_New = False
                Me.Purchaseordernav1.Allow_New_Line = False
            End If
            If secEdit = "N" Then
                Me.Purchaseordernav1.Allow_Save = False
                Me.Purchaseordernav1.Allow_Void = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Purchaseordernav1_SendAssignmentClicked() Handles Purchaseordernav1.SendAssignmentClicked

        If NavNeedsApprovalAndApprove() = False Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "PurchaseOrder_Print.aspx"

            qs.Add("po_number", AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PO_NUMBER.Text.Trim()))
            qs.Add("callingpagemode", lbl_pagemode.Text.Trim())
            If Not Request.QueryString("Fromjj") Is Nothing AndAlso Request.QueryString("Fromjj") = "jjpo" Then qs.Add("FromJJ", "jjpo")
            qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

            Me.OpenPrintSendSilently(qs)

        End If

    End Sub

End Class