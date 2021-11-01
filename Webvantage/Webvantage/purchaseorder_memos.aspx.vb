Imports Webvantage
Imports System.Drawing

Partial Public Class purchaseorder_memos
    Inherits Webvantage.BaseChildPage
    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Purchase Order Comments"
        'SelectTab()

        If Not Page.IsPostBack Then
            Me.RadTabStripAR.Tabs(0).Selected = True
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
            If Not Request.QueryString("pagemode") Is Nothing Then 'used only to set page to readonly. Cannot create record here.
                lbl_pagemode.Text = Request.QueryString("pagemode")
            End If
            If Not Request.QueryString("update_column") Is Nothing Then 'denotes what memo field to load / update.
                lbl_update_column.Text = Request.QueryString("update_column").Trim
            End If

            If Not Request.QueryString("po_number") Is Nothing Then
                Purchaseorder_base_info1.PO_Number = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number").Trim)
                Session("POMemoPONum") = Purchaseorder_base_info1.PO_Number.ToString
                Purchaseorder_base_info1.RetrievePOHeader()
            Else
                Purchaseorder_base_info1.PO_Number = Session("POMemoPONum")
                Purchaseorder_base_info1.RetrievePOHeader()
            End If
            'retrieve existing data...
            Select Case lbl_update_column.Text.Trim
                Case "po_main_instruct"
                    lbl_memo_selection.Text = "Purchase Order <b>Main Instructions</b>"
                    'Me.RadPanelbar1.Visible = True
                    GetPOMemo()
                Case "del_instruct"
                    lbl_memo_selection.Text = "Purchase Order <b>Delivery Instructions</b>"
                    'Me.RadPanelbar1.Visible = True
                    GetPOMemo()
                Case "po_footer"
                    lbl_memo_selection.Text = "Purchase Order <b>Footer Comments</b>"
                    'Me.RadPanelbar1.Visible = False
                    GetPOMemo()
            End Select

            'Purchaseorder_memo_nav1.Current_Tab = lbl_update_column.Text.Trim

            'SetupRadPanelBar()

            Select Case lbl_pagemode.Text
                Case "read"
                    LockPage()
                Case "edit"
                    If Purchaseorder_base_info1.PO_Complete = True Then
                        LockPage()
                    End If
                Case "new"
            End Select

        Else
            If lbl_update_column.Text = "po_footer" Then
                GetPOMemo()
            End If
        End If
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        POHeader.Select_POHeader(Int32.Parse(Session("POMemoPONum")), "")
        If POHeader.PO_Voided = True And POHeader.PO_Approval_Flag <> 3 Then
            LockPage()
        End If

        'Me.RadPanelbar1.Skin = Webvantage.MiscFN.SetRadPanelbarSkin
    End Sub
    Private Sub SelectTab(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try
            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    If CInt(Request.QueryString("Tab")) = 1 Then
                        Me.RadTabStripAR.Tabs(0).Selected = True
                        'lbl_direct_to.Text = "po_main_instruct"
                        lbl_update_column.Text = "po_main_instruct"
                        If Request.QueryString("Fromjj") = "jjpo" Then
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                        Else
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&po_number=" & Session("POMemoPONum") & "&"
                        End If

                    ElseIf CInt(Request.QueryString("Tab")) = 2 Then
                        Me.RadTabStripAR.Tabs(1).Selected = True
                        'lbl_direct_to.Text = "del_instruct"
                        lbl_update_column.Text = "del_instruct"
                        If Request.QueryString("Fromjj") = "jjpo" Then
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                        Else
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&po_number=" & Session("POMemoPONum") & "&"
                        End If

                    ElseIf CInt(Request.QueryString("Tab")) = 3 Then
                        Me.RadTabStripAR.Tabs(2).Selected = True
                        'lbl_direct_to.Text = "po_footer"
                        lbl_update_column.Text = "po_footer"
                        If Request.QueryString("Fromjj") = "jjpo" Then
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&Fromjj=jjpo&po_number=" & Session("POMemoPONum") & "&"
                        Else
                            Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&po_number=" & Session("POMemoPONum") & "&"
                            Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&po_number=" & Session("POMemoPONum") & "&"
                        End If

                    End If
                Else
                    Me.RadTabStripAR.Tabs(0).Selected = True
                    If Request.QueryString("Fromjj") = "jjpo" Then
                        Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1&Fromjj=jjpo" & "&"
                        Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2&Fromjj=jjpo" & "&"
                        Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3&Fromjj=jjpo" & "&"
                    Else
                        Me.RadTabStripAR.Tabs(0).NavigateUrl = "purchaseorder_memos.aspx?Tab=1" & "&"
                        Me.RadTabStripAR.Tabs(1).NavigateUrl = "purchaseorder_memos.aspx?Tab=2" & "&"
                        Me.RadTabStripAR.Tabs(2).NavigateUrl = "purchaseorder_memos.aspx?Tab=3" & "&"
                    End If
                    'lbl_direct_to.Text = "po_main_instruct"
                End If
            Catch ex As Exception
                Me.ShowMessage("tab error")
            End Try
        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub
    Sub LockPage()
        txt_memo.ReadOnly = True
        btn_save.Enabled = False
        Me.TS_Footer_Options.Visible = False
    End Sub
    'Sub SetupRadPanelBar()
    '   RadPanelbar1.Items(0).Items(0).Attributes.Add("onclick", "window.open('purchaseorder_memo_disp.aspx?memo_type=main_del_instruct&ref_id=" & Me.Purchaseorder_base_info1.PO_Number.ToString()& "&preselect_tab_id=0" & "&fn_code=photog" & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=350,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
    '  RadPanelbar1.Items(0).Items(1).Attributes.Add("onclick", "window.open('purchaseorder_memo_disp.aspx?memo_type=main_del_instruct&ref_id=" & Me.Purchaseorder_base_info1.PO_Number.ToString()& "&preselect_tab_id=1" & "&fn_code=photog" & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=350,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
    ' RadPanelbar1.Items(0).Items(2).Attributes.Add("onclick", "window.open('purchaseorder_memo_disp.aspx?memo_type=main_del_instruct&ref_id=" & Me.Purchaseorder_base_info1.PO_Number.ToString()& "&preselect_tab_id=2" & "&fn_code=photog" & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=350,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
    'RadPanelbar1.Items(0).Items(3).Attributes.Add("onclick", "window.open('purchaseorder_memo_disp.aspx?memo_type=main_del_instruct&ref_id=" & Me.Purchaseorder_base_info1.PO_Number.ToString()& "&preselect_tab_id=3" & "&fn_code=photog" & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=350,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
    'End Sub
    Sub CreateTabs(ByVal tab_function As String, ByVal Selected_Tab As Int16)

        If tab_function.Trim = "po_footer" Then
            Dim t1, t2 As New Telerik.Web.UI.RadTab
            Dim tabUseStandardCommentText As Telerik.Web.UI.RadTab = Nothing

            t1.Text = "Use Agency Defined Text"
            t1.Value = "current_footer"
            t2.Text = "Use Customized Text"

            tabUseStandardCommentText = New Telerik.Web.UI.RadTab

            tabUseStandardCommentText.Text = "Use Standard Comment Text"

            Me.TS_Footer_Options.Tabs.Add(t1)
            Me.TS_Footer_Options.Tabs.Add(tabUseStandardCommentText)
            Me.TS_Footer_Options.Tabs.Add(t2)

            If Me.TS_Footer_Options.Tabs.Count > 0 And (Selected_Tab <= TS_Footer_Options.Tabs.Count) Then
                Me.TS_Footer_Options.Tabs(Selected_Tab).Selected = True
                If tab_function.Trim = "po_footer" Then
                    Me.txt_memo.ReadOnly = True
                    Me.txt_memo.ForeColor = Color.Gray
                End If
            End If

        End If

    End Sub
    Sub GetPOMemo()

        'objects
        Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
        Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        POHeader.Select_PO_Memo(lbl_update_column.Text.Trim, Convert.ToInt32(Session("POMemoPONum")))
        POHeader.Select_POHeader(Convert.ToInt32(Session("POMemoPONum")), "")

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

        End Using

        Select Case lbl_update_column.Text.Trim
            Case "po_main_instruct"
                txt_memo.Text = POHeader.PO_Main_Instruct
            Case "del_instruct"
                txt_memo.Text = POHeader.Delivery_Instructions
            Case "po_footer"

                'If Not Page.IsPostBack Then
                '    txt_memo.Text = POHeader.PO_Footer
                'End If

                If Me.TS_Footer_Options.Tabs.Count = 0 Then

                    CreateTabs("po_footer", 0)

                    If POHeader.PO_Footer = Nothing Then

                        For Each oVendorComment In StandardCommentsList
                            If POHeader.Vendor_Code = oVendorComment.VendorCode Then
                                StandardComment = oVendorComment
                                Exit For
                            End If
                        Next

                        If StandardComment Is Nothing Then
                            For Each oVendorComment In StandardCommentsList
                                If oVendorComment.VendorCode = Nothing Then
                                    StandardComment = oVendorComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComment IsNot Nothing Then
                            Me.TS_Footer_Options.SelectedIndex = 1
                        Else
                            Me.TS_Footer_Options.SelectedIndex = 0
                        End If

                        'Me.TS_Footer_Options.SelectedIndex = 0

                    ElseIf POHeader.PO_Footer = "Standard Comment" Then
                        Me.TS_Footer_Options.SelectedIndex = 1
                    ElseIf POHeader.PO_Footer = "Agency Defined" Then
                        Me.TS_Footer_Options.SelectedIndex = 0
                    Else
                        Me.TS_Footer_Options.SelectedIndex = 2
                    End If

                    Me.current_tab.Value = Me.TS_Footer_Options.SelectedIndex.ToString

                    ChangeTabs()

                End If

                'If txt_memo.Text.Trim = "" Or (Me.confirm_clear_flg.Value.Trim = "1") Then
                '    'retrieve agency default here and lock.
                '    POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "")
                '    txt_memo.Text = POHeader.Default_Memo_Text.Trim
                '    Me.custom_mode.Value = "NO"
                '    If Me.TS_Footer_Options.Tabs.Count = 0 Then
                '        CreateTabs("po_footer", 0)
                '    End If
                '    txt_memo.ReadOnly = True
                '    Me.txt_memo.ForeColor = Color.Gray

                '    Me.current_tab.Value = "0"

                'Else
                '    If Me.TS_Footer_Options.Tabs.Count = 0 Then
                '        CreateTabs("po_footer", 1)
                '    End If
                '    txt_memo.ReadOnly = False
                '    Me.custom_mode.Value = "YES"
                '    Me.txt_memo.ForeColor = Color.Black
                '    Me.TS_Footer_Options.Attributes.Add("onclick", "getMessage()")
                '    Me.current_tab.Value = "1"
                'End If

        End Select

        'If Me.custom_mode.Value = "YES" Then
        '    Me.TS_Footer_Options.SelectedIndex = 2
        'End If

    End Sub
    Sub UpdatePOMemo()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        If Me.lbl_update_column.Text = "po_footer" Then
            If Me.custom_mode.Value.Trim = "NO" Then 'if po footer and no custom text specified, save as null...
                POHeader.UpdatePOMemo(lbl_update_column.Text.Trim, Purchaseorder_base_info1.PO_Number, "Agency Defined")
            ElseIf Me.custom_mode.Value.Trim = "STANDARD" Then
                POHeader.UpdatePOMemo(lbl_update_column.Text.Trim, Purchaseorder_base_info1.PO_Number, "Standard Comment")
            Else
                POHeader.UpdatePOMemo(lbl_update_column.Text.Trim, Purchaseorder_base_info1.PO_Number, txt_memo.Text.Trim)
            End If
        Else
            POHeader.UpdatePOMemo(lbl_update_column.Text.Trim, Purchaseorder_base_info1.PO_Number, txt_memo.Text.Trim)
        End If

        lbl_changestat.Text = "Unchanged"
    End Sub
    Protected Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        UpdatePOMemo()
    End Sub
    'Private Sub Purchaseorder_memo_nav1_PO_Clicked() Handles Purchaseorder_memo_nav1.PO_Clicked
    '    If lbl_changestat.Text.Trim = "Changed" Then
    '        pnl_confirm.Visible = True
    '        lbl_direct_to.Text = "po"
    '        Exit Sub
    '    End If

    '    DirectToPOPage()

    'End Sub
    Sub DirectToPOPage()
        Dim sb1 As New System.Text.StringBuilder

        sb1.Append("purchaseorder.aspx?po_number=")
        sb1.Append(AdvantageFramework.Security.Encryption.EncryptPO(Purchaseorder_base_info1.PO_Number.ToString()))
        sb1.Append("&pagemode=")
        sb1.Append(lbl_pagemode.Text.Trim)
        If Request.QueryString("Fromjj") = "jjpo" Then
            sb1.Append("&Fromjj=jjpo")
        End If
        Server.Transfer(sb1.ToString())

        sb1 = Nothing
    End Sub
    Sub DirectToMemoPage(ByVal update_column As String)
        Dim sb1 As New System.Text.StringBuilder
        sb1.Append("purchaseorder_memos.aspx?po_number=")
        sb1.Append(Purchaseorder_base_info1.PO_Number.ToString())
        sb1.Append("&update_column=")
        sb1.Append(update_column.Trim)
        sb1.Append("&pagemode=")
        sb1.Append(lbl_pagemode.Text.Trim)

        Server.Transfer(sb1.ToString())

        sb1 = Nothing

    End Sub

    'Private Sub Purchaseorder_memo_nav1_Main_Instruct_Clicked() Handles Purchaseorder_memo_nav1.Main_Instruct_Clicked
    '    If lbl_changestat.Text.Trim = "Changed" Then
    '        pnl_confirm.Visible = True
    '        lbl_direct_to.Text = "po_main_instruct"
    '        Exit Sub
    '    End If
    '    DirectToMemoPage("po_main_instruct")
    'End Sub
    'Private Sub Purchaseorder_memo_nav1_PO_Delivery_Clicked() Handles Purchaseorder_memo_nav1.PO_Delivery_Clicked
    '    If lbl_changestat.Text.Trim = "Changed" Then
    '        pnl_confirm.Visible = True
    '        lbl_direct_to.Text = "del_instruct"
    '        Exit Sub
    '    End If
    '    DirectToMemoPage("del_instruct")
    'End Sub
    'Private Sub Purchaseorder_memo_nav1_PO_Footer_Clicked() Handles Purchaseorder_memo_nav1.PO_Footer_Clicked
    '    If lbl_changestat.Text.Trim = "Changed" Then
    '        pnl_confirm.Visible = True
    '        lbl_direct_to.Text = "po_footer"
    '        Exit Sub
    '    End If
    '    DirectToMemoPage("po_footer")
    'End Sub

    Protected Sub lbtn_yes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_yes.Click
        UpdatePOMemo()
        Select Case lbl_direct_to.Text.Trim
            Case "po"
                DirectToPOPage()
            Case Else
                'DirectToMemoPage(lbl_direct_to.Text.Trim)
        End Select
    End Sub

    Protected Sub lbtn_no_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_no.Click
        pnl_confirm.Visible = False
        Select Case lbl_direct_to.Text.Trim
            Case "po"
                DirectToPOPage()
            Case Else
                'DirectToMemoPage(lbl_direct_to.Text.Trim)
        End Select
    End Sub

    Protected Sub butback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butback.Click
        If lbl_changestat.Text.Trim = "Changed" Then
            pnl_confirm.Visible = True
            lbl_direct_to.Text = "po"
            Exit Sub
        End If

        DirectToPOPage()
    End Sub
    Private Sub ChangeTabs()

        'objects
        Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

        POHeader.Select_PO_Memo(lbl_update_column.Text.Trim, Convert.ToInt32(Session("POMemoPONum")))
        POHeader.Select_POHeader(Convert.ToInt32(Session("POMemoPONum")), "")
        POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

        End Using

        Select Case CInt(Me.current_tab.Value)

            Case 0

                Me.txt_memo.ReadOnly = True
                Me.txt_memo.ForeColor = Color.Gray
                Me.custom_mode.Value = "NO"

                txt_memo.Text = POHeader.Default_Memo_Text.Trim

            Case 1

                Me.txt_memo.ReadOnly = True
                Me.txt_memo.ForeColor = Color.Gray
                Me.custom_mode.Value = "STANDARD"

                For Each oVendorComment In StandardCommentsList

                    If POHeader.Vendor_Code = oVendorComment.VendorCode Then

                        StandardComment = oVendorComment
                        Exit For

                    End If

                Next

                If StandardComment Is Nothing Then

                    For Each oVendorComment In StandardCommentsList

                        If oVendorComment.VendorCode = Nothing Then

                            StandardComment = oVendorComment
                            Exit For

                        End If

                    Next

                End If

                If StandardComment IsNot Nothing Then

                    Me.txt_memo.Text = StandardComment.Comment

                Else

                    txt_memo.Text = POHeader.Default_Memo_Text.Trim

                End If

            Case 2

                Me.txt_memo.ReadOnly = False
                Me.txt_memo.ForeColor = Color.Black
                Me.custom_mode.Value = "YES"

                If POHeader.PO_Footer = Nothing Then

                    txt_memo.Text = POHeader.Default_Memo_Text.Trim

                ElseIf POHeader.PO_Footer = "Standard Comment" Then

                    For Each oVendorComment In StandardCommentsList

                        If POHeader.Vendor_Code = oVendorComment.VendorCode Then

                            StandardComment = oVendorComment
                            Exit For

                        End If

                    Next

                    If StandardComment Is Nothing Then

                        For Each oVendorComment In StandardCommentsList

                            If oVendorComment.VendorCode = Nothing Then

                                StandardComment = oVendorComment
                                Exit For

                            End If

                        Next

                    End If

                    If StandardComment IsNot Nothing Then

                        Me.txt_memo.Text = StandardComment.Comment

                    Else

                        POHeader.Select_PO_Memo_Default("default_po_footer", 1, "", "", -1)
                        txt_memo.Text = POHeader.Default_Memo_Text.Trim

                    End If

                Else

                    txt_memo.Text = POHeader.PO_Footer

                End If

        End Select

    End Sub
    Private Sub TS_Footer_Options_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles TS_Footer_Options.TabClick

        Me.current_tab.Value = Me.TS_Footer_Options.SelectedTab.Index.ToString
        Me.confirm_clear_flg.Value = "0"

        ChangeTabs()

    End Sub
    Private Sub Page_PreInit1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'If Request.QueryString("Fromjj") = "jjpo" Then
        '    Me.Page.MasterPageFile = "ApplicationMaster.Master"
        'End If
    End Sub

    Private Sub RadTabStripAR_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripAR.TabClick
        Try
            UpdatePOMemo()
            Select Case e.Tab.Text
                Case "Main Instructions"
                    lbl_update_column.Text = "po_main_instruct"
                    Me.TS_Footer_Options.Visible = False
                    txt_memo.ReadOnly = False
                Case "Delivery Instructions"
                    lbl_update_column.Text = "del_instruct"
                    Me.TS_Footer_Options.Visible = False
                    txt_memo.ReadOnly = False
                Case "Footer Comments"
                    lbl_update_column.Text = "po_footer"
                    Me.TS_Footer_Options.Visible = True
                    Me.TS_Footer_Options.Tabs.Clear()
            End Select
            GetPOMemo()
        Catch ex As Exception

        End Try
    End Sub
End Class
