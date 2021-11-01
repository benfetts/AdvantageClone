Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet

Partial Public Class VendorQuote
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

#Region " Private vars: "
    Private EstNum As Integer
    Private EstCompNum As Integer
    Private QuoteNum As Integer
    Private RevNum As Integer
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private count As Integer = 0
    Private ReloadMe As Boolean = False
    Private SetPhase As Boolean = False
    Private del As Boolean = False
    Private mess As String
    Private reqNum As Integer
    Private email As Boolean = False
    Private IsNTAuth As Boolean = False
    Private spellobjects As String = ""
    Private rights As String
    Private rightsPrint As String
    Private tab As Integer = 0

#End Region

    Public Property DtQuoteFunctions() As DataTable
        Get
            Try
                Dim o As Object = Session("DT_EST_QUOTE_FNC")
                If o Is Nothing Then
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    'Return est.GetEstimateQuoteDetails(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuoteNum.Text, Me.RevNum, Me.ddPhase.SelectedValue)
                Else
                    Return CType(Session("DT_EST_QUOTE_FNC"), DataTable)
                End If
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As DataTable)
            Session("DT_EST_QUOTE_FNC") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.PageTitle = "Vendor Quote Request"
            Dim sec As New cSecurity(Session("ConnString"))

            If IsNumeric(Request.QueryString("EstNum")) Then
                EstNum = Request.QueryString("EstNum")
            Else
                'Me.TxtEstimate.Text = ""
            End If
            'End If
            'If IsNumeric(Me.TxtEstimateComponent.Text) Then
            '    EstCompNum = CType(Me.TxtEstimateComponent.Text, Integer)
            'Else
            If IsNumeric(Request.QueryString("EstComp")) Then
                EstCompNum = Request.QueryString("EstComp")
                'Me.TxtEstimateComponent.Text = EstCompNum
            Else
                'Me.TxtEstimateComponent.Text = ""
            End If
            'End If
            If IsNumeric(Request.QueryString("vendorreq")) Then
                reqNum = Request.QueryString("vendorreq")
            Else
                If IsNumeric(Me.hfVendorQteNum.Value) Then
                    reqNum = Me.hfVendorQteNum.Value
                End If
            End If

            If Not Page.IsPostBack Then
                'Me.LoadTabs()
                If Not Request.QueryString("PageMode") Is Nothing Then
                    If Request.QueryString("PageMode") = "Edit" Then

                    End If
                    If Request.QueryString("PageMode") = "new" Then
                        'Me.reqNum = Me.GenerateRFQ
                        Me.hfVendorQteNum.Value = Me.reqNum
                        Me.TxtRFQ.Text = Me.EstNum.ToString.PadLeft(6, "0") & "-" & Me.EstCompNum.ToString.PadLeft(2, "0") & "-" & Me.reqNum.ToString.PadLeft(2, "0")
                        Me.GetEstimateDesc()
                        'Me.SaveRfqHeader()
                    End If
                End If
                Me.LoadData()
                Me.TxtRFQDescription.Focus()

                If Request.QueryString("tab") = 0 Then
                    Me.RadTabStrip.SelectedIndex = 0
                    Me.pnlVersions.Visible = False
                    Me.pnlVendors.Visible = True
                ElseIf Request.QueryString("tab") = 1 Then
                    Me.RadTabStrip.SelectedIndex = 1
                    Me.pnlVersions.Visible = True
                    Me.pnlVendors.Visible = False
                End If

                Session("SpellObjectsVersions") = ""
                Session("SpellObjectsVendors") = ""
                Dim vc As String = sec.GetVendorContactSecurity(Session("UserCode"))
                If vc = "N" Then
                    Me.RadToolbarVendors.FindItemByValue("AddContact").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("EditContact").Enabled = False
                End If
            Else
                Me.CheckUserRights()
                Select Case Me.EventArgument.ToString().Replace("onclick#", "")
                    Case "Refresh"
                        Me.RadGridVersions.Rebind()
                        Me.RadGridVendors.Rebind()
                        Me.RadGridVendorReplies.Rebind()
                        Me.LoadData()
                    Case "HidePopups"

                    Case "Cancel"
                        Session("NewJSNew") = 0
                        Dim cScript As String
                        cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                        RegisterStartupScript("parentwindow2", cScript)
                        Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
                        With sbScript
                            .Append("<script type=""text/javascript"">")
                            .Append("window.close();</script>")
                        End With
                        Try
                            If Not Page.IsStartupScriptRegistered("JS") Then
                                Dim str As String = sbScript.ToString
                                Page.RegisterStartupScript("JS", str)
                            End If
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    Case "Print"
                        Try

                        Catch ex As Exception

                        End Try
                End Select
            End If
            Me.CheckUserRights()
        Catch ex As Exception
            'Me.ShowMessage("err pageload: " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim txt As System.Web.UI.WebControls.TextBox
            Dim chk As CheckBox
            Dim tab As Integer = 4
            Dim gtv As Telerik.Web.UI.GridTableView
            Dim gth As Telerik.Web.UI.GridTableView
            spellobjects = "new HtmlElementTextSource(document.getElementById('" & Me.TxtRFQDescription.ClientID & "'))" & Environment.NewLine & ","
            spellobjects &= "new HtmlElementTextSource(document.getElementById('" & Me.TxtDescriptionOfProject.ClientID & "'))" & Environment.NewLine & ","

            If Me.RadGridVendors.Visible = True Then
                spellobjects &= Session("SpellObjectsVendors")
            End If
            If Me.RadGridVersions.Visible = True Then
                spellobjects &= Session("SpellObjectsVersions")
                For i As Integer = 0 To Me.RadGridVersions.MasterTableView.Items.Count - 1
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVersions.MasterTableView.Items
                        txt = CType(gridDataItem("colVN_QTE_SPECS").FindControl("TxtVN_QTE_SPECS"), TextBox)
                        txt.TabIndex = tab + 1
                    Next
                    For j As Integer = 0 To Me.RadGridVersions.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                        gtv = CType(Me.RadGridVersions.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                        If gtv.Items.Count > 0 Then
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                                If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                    txt = CType(gridDataItem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox)
                                    spellobjects &= "new HtmlElementTextSource(document.getElementById('" & txt.ClientID & "'))" & Environment.NewLine & ","
                                    If rights = "N" Then
                                        txt.ReadOnly = True
                                    End If
                                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                                    chk.TabIndex = tab + 1
                                    txt.TabIndex = tab + 1
                                End If
                            Next
                        End If
                    Next
                Next
            End If
            If spellobjects.Length > 0 Then
                spellobjects = spellobjects.Substring(0, spellobjects.Length - 1)
            End If
            Session("TabVersionsRFQ") = Nothing
        Catch ex As Exception

        End Try
    End Sub

#Region " Controls: "

    Private Sub RadTabStrip_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip.TabClick
        Try
            Session("SpellObjectsVendors") = ""
            Session("SpellObjectsVersions") = ""
            Me.SaveGrid()
            If e.Tab.Value = 0 Then
                Me.pnlVendors.Visible = True
                Me.pnlVersions.Visible = False
                Me.CheckUserRights()
                Me.RadGridVendors.Rebind()
                Me.RadGridVendorReplies.Rebind()
            End If
            If e.Tab.Value = 1 Then
                Me.pnlVendors.Visible = False
                Me.pnlVersions.Visible = True
                Me.CheckUserRights()
                Me.RadGridVersions.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImgBtnComments_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnComments.Click
        Try
            Me.UpdateHeader()
            Me.SaveGrid()
            Dim version As Integer
            Dim revision As Integer
            Dim dt As DataTable
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            dt = est.GetEstimateData(EstNum, EstCompNum, 0, 0, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                    Me.JobNum = dt.Rows(0)("JOB_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.JobCompNum = dt.Rows(0)("JOB_COMPONENT_NBR")
                End If
            End If
            Dim StrCommentsURL As String = "VendorQuote_Comments.aspx?From=header&EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&reqNum=" & Me.reqNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum
            Me.OpenWindow("", StrCommentsURL, 600, 650, False, False)
            'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)
            Session("SpellObjectsVendors") = ""
            Session("SpellObjectsVersions") = ""
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " SubRoutines "

    Private Sub PageLoadJS(ByVal strJS As String)
        Dim strTmpJS As String = String.Empty
        strTmpJS = "<script type=""text/javascript"">function init() { " & strJS & " } window.onload = init;</script>"
        If Not Page.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then
            Page.RegisterStartupScript("JSAlert", strTmpJS)
        End If
    End Sub

    Private Function GetEmailAddressFromGroup(ByVal strEmailGroup As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim dr As SqlDataReader
            If strEmailGroup <> "" Then
                Dim arParams(1) As SqlParameter
                Dim paramEmailGroup As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 50)
                paramEmailGroup.Value = strEmailGroup
                arParams(0) = paramEmailGroup
                'use mConnString if moving to class instead of session
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", arParams)
            End If
            Return dr
        Catch ex As Exception
        End Try
    End Function

    Private Function GetYesNo(ByVal ThisShort As Short) As String
        If ThisShort = 1 Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function


    Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try

            Dim tab As Integer = 0
            Dim ThisDate As Date

            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    tab = CInt(Request.QueryString("Tab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
                Me.ShowMessage("err getting tab id from qs")
            End Try

            Me.RadTabStrip.Tabs.Clear()

            Dim PassIt As String = ""
            'If JobNum > 0 And JobCompNum > 0 Then
            '    PassIt = "&JobNo=" & JobNum.ToString() & "&JobComp=" & JobCompNum.ToString()
            'End If
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Vendors"
            newTab.Value = 0
            'newTab.NavigateUrl = "QuoteVsActualSummaryPopup.aspx?tab=0" & PassIt
            Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Versions"
            newTab.Value = 1
            'newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1" & PassIt
            Me.RadTabStrip.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.RadTabStrip.FindTabByValue(tab)
            selectTab.Selected = True



        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = oEstimate.GetRequestData(Me.EstNum, Me.EstCompNum, Me.reqNum, Session("UserCode"))
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.TxtRFQ.Text = ds.Tables(0).Rows(i)("ESTIMATE_NUMBER").ToString.PadLeft(6, "0") & "-" & ds.Tables(0).Rows(i)("EST_COMPONENT_NBR").ToString.PadLeft(2, "0") & "-" & ds.Tables(0).Rows(i)("VENDOR_QTE_NBR").ToString.PadLeft(2, "0")
                    If IsDBNull(ds.Tables(0).Rows(i)("VENDOR_QTE_DESC")) = False Then
                        Me.TxtRFQDescription.Text = ds.Tables(0).Rows(i)("VENDOR_QTE_DESC")
                    End If
                    If IsDBNull(ds.Tables(0).Rows(i)("VN_QTE_MEMO")) = False Then
                        Me.TxtDescriptionOfProject.Text = ds.Tables(0).Rows(i)("VN_QTE_MEMO")
                    End If
                    If IsDBNull(ds.Tables(0).Rows(i)("CREATE_DATE")) = False Then
                        Me.RadDatePickerRequestDate.SelectedDate = CType(ds.Tables(0).Rows(i)("CREATE_DATE"), Date)
                    Else
                        Me.RadDatePickerRequestDate.SelectedDate = cEmployee.TimeZoneToday
                    End If
                Next
            End If
            ds = oEstimate.GetRequestVendors(Me.EstNum, Me.EstCompNum, Me.reqNum, Session("UserCode"))
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If IsDBNull(ds.Tables(0).Rows(i)("DUE_DATE")) = False Then
                        Me.RadDatePickerDueDate.SelectedDate = CType(ds.Tables(0).Rows(i)("DUE_DATE"), Date)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveRfqHeader()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim val As New cValidations(Session("ConnString"))
            Dim save As Boolean
            Dim job As Integer
            Dim comp As Integer
            save = est.AddNewRequest(Me.EstNum, Me.EstCompNum, Me.reqNum, Me.TxtRFQDescription.Text, Me.TxtDescriptionOfProject.Text, Session("UserCode"), Now, Session("UserCode"))
            If save = True Then

            Else
                Me.ShowMessage("Save failed")
            End If
        Catch ex As Exception
            Me.ShowMessage("Save failed")
        End Try
    End Sub

    Private Sub UpdateHeader()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim val As New cValidations(Session("ConnString"))
            Dim save As Boolean

            If Me.TxtRFQDescription.Text = "" Then
                Me.ShowMessage("RFQ Description is required.")
                Exit Sub
            End If

            If MiscFN.ValidDate(Me.RadDatePickerRequestDate, True) = False Then
                Me.ShowMessage("Invalid Request Date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerDueDate, True) = False Then
                Me.ShowMessage("Invalid Due Date")
                Exit Sub
            End If

            save = est.UpdateRequest(Me.EstNum, Me.EstCompNum, Me.reqNum, Me.TxtRFQDescription.Text, Me.TxtDescriptionOfProject.Text, Me.RadDatePickerRequestDate.SelectedDate, Session("UserCode"))
            If save = True Then

            Else
                Me.ShowMessage("Update failed")
            End If
        Catch ex As Exception
            Me.ShowMessage("Update failed")
        End Try
    End Sub

    Private Sub SaveGrid(Optional ByVal RebindGrid As Boolean = True, Optional ByVal SaveUserRows As Boolean = True)
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim functioncode As String
            Dim functionnotes As String
            Dim quoteno As Integer
            Dim revno As Integer
            Dim specs As String
            Dim qty As Integer
            Dim vendorcode As String
            Dim vendorcontcode As String
            Dim replyrate As Decimal
            Dim replyamt As Decimal
            Dim replynotes As String
            Dim approved As Boolean
            Dim approvalnotes As String
            Dim approvedby As String
            Dim approveddate As String
            Dim submitted As String
            Dim replydate As String
            Dim duedate As String

            Dim gtv As Telerik.Web.UI.GridTableView

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVersions.MasterTableView.Items
                If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                    quoteno = gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")
                End If
                If IsNumeric(gridDataItem.GetDataKeyValue("EST_REV_NBR")) Then
                    revno = gridDataItem.GetDataKeyValue("EST_REV_NBR")
                End If
                specs = CType(gridDataItem("colVN_QTE_SPECS").FindControl("TxtVN_QTE_SPECS"), TextBox).Text
                est.UpdateRequestQuote(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, specs)
            Next
            For i As Integer = 0 To Me.RadGridVersions.MasterTableView.Items.Count - 1
                For j As Integer = 0 To Me.RadGridVersions.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                    gtv = CType(Me.RadGridVersions.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                    If gtv.Items.Count > 0 Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                            If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                quoteno = CInt(gtv.ParentItem.GetDataKeyValue("EST_QUOTE_NBR"))
                                revno = CInt(gtv.ParentItem.GetDataKeyValue("EST_REV_NBR"))
                                functioncode = gridDataItem.OwnerTableView.DataKeyValues(gridDataItem.ItemIndex)("EST_FNC_CODE")
                                functionnotes = CType(gridDataItem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox).Text
                                'qty = CType(CType(gridDataItem("colQTY").FindControl("TxtQTY"), TextBox).Text, Integer)
                                If functionnotes <> "" Then
                                    est.UpdateRequestFunction(Me.EstNum, Me.EstCompNum, Me.reqNum, functioncode, functionnotes)
                                End If
                                'est.UpdateRequestDetailQty(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, functioncode, qty)
                            End If
                        Next
                    End If
                Next
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                vendorcode = gridDataItem.GetDataKeyValue("VN_CODE")
                vendorcontcode = CType(gridDataItem("colVC_FNAME").FindControl("hfVN_CONT_CODE"), HiddenField).Value
                specs = CType(gridDataItem("colVN_NOTES").FindControl("TxtVN_NOTES"), TextBox).Text
                If wvIsDate(CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text) = True Then
                    submitted = CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text
                    submitted = wvCDate(submitted)
                ElseIf CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text <> "" And CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Submitted Date")
                    Exit Sub
                End If
                If wvIsDate(CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text) = True Then
                    replydate = CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text
                    replydate = wvCDate(replydate)
                ElseIf CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text <> "" And CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Replied Date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                    duedate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()
                End If
                est.UpdateRequestVendor(Me.EstNum, Me.EstCompNum, Me.reqNum, vendorcode, vendorcontcode, specs, submitted, replydate, duedate)
                submitted = ""
                replydate = ""
                duedate = ""
            Next
            For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorReplies.MasterTableView.Items
                quoteno = CInt(GridDataItem.GetDataKeyValue("EST_QUOTE_NBR"))
                revno = CInt(GridDataItem.GetDataKeyValue("EST_REV_NBR"))
                functioncode = GridDataItem.GetDataKeyValue("EST_FNC_CODE")
                vendorcode = GridDataItem.GetDataKeyValue("VN_CODE")
                If IsNumeric(DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text) Then
                    replyrate = CType(DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text, Decimal)
                ElseIf DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text <> "" And DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Reply Rate")
                    Exit Sub
                End If
                If IsNumeric(DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text) Then
                    replyamt = CType(DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text, Decimal)
                ElseIf DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text <> "" And DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Reply Amount")
                    Exit Sub
                End If
                replynotes = CType(GridDataItem("colREPLY_NOTES").FindControl("TxtREPLY_NOTES"), TextBox).Text
                approved = DirectCast(GridDataItem("colAPPROVED_FLAG").FindControl("cbAPPROVED_FLAG"), CheckBox).Checked
                approvalnotes = CType(GridDataItem("colAPPROVAL_NOTES").FindControl("TxtAPPROVAL_NOTES"), TextBox).Text
                approvedby = CType(GridDataItem("colAPPROVED_BY").FindControl("TxtAPPROVED_BY"), TextBox).Text
                If approved = True Then
                    approveddate = LoGlo.FormatDate(Now.Date.ToShortDateString)
                End If
                qty = CType(CType(GridDataItem("colQTY").FindControl("TxtQTY"), TextBox).Text, Integer)
                Try
                    est.UpdateRequestDetail(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, functioncode, vendorcode, replyrate, replyamt, replynotes, approved, approvalnotes, approvedby, approveddate, qty, Me.RadDatePickerRequestDate.SelectedDate)
                Catch ex As Exception

                End Try
                replyrate = 0
                replyamt = 0
                qty = 0
            Next
            Me.RadGridVersions.Rebind()
            Me.RadGridVendors.Rebind()
            Me.RadGridVendorReplies.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveGridNoRebind(Optional ByVal RebindGrid As Boolean = True, Optional ByVal SaveUserRows As Boolean = True)
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim functioncode As String
            Dim functionnotes As String
            Dim quoteno As Integer
            Dim revno As Integer
            Dim specs As String
            Dim qty As Integer
            Dim vendorcode As String
            Dim vendorcontcode As String
            Dim replyrate As Decimal
            Dim replyamt As Decimal
            Dim replynotes As String
            Dim approved As Boolean
            Dim approvalnotes As String
            Dim approvedby As String
            Dim approveddate As String
            Dim submitted As String
            Dim replydate As String
            Dim duedate As String

            Dim gtv As Telerik.Web.UI.GridTableView

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVersions.MasterTableView.Items
                If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                    quoteno = gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")
                End If
                If IsNumeric(gridDataItem.GetDataKeyValue("EST_REV_NBR")) Then
                    revno = gridDataItem.GetDataKeyValue("EST_REV_NBR")
                End If
                specs = CType(gridDataItem("colVN_QTE_SPECS").FindControl("TxtVN_QTE_SPECS"), TextBox).Text
                est.UpdateRequestQuote(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, specs)
            Next
            For i As Integer = 0 To Me.RadGridVersions.MasterTableView.Items.Count - 1
                For j As Integer = 0 To Me.RadGridVersions.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                    gtv = CType(Me.RadGridVersions.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                    If gtv.Items.Count > 0 Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                            If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                quoteno = CInt(gtv.ParentItem.Cells.Item(3).Text)
                                revno = CInt(gtv.ParentItem.Cells.Item(5).Text)
                                functioncode = gridDataItem.OwnerTableView.DataKeyValues(gridDataItem.ItemIndex)("EST_FNC_CODE")
                                functionnotes = CType(gridDataItem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox).Text
                                'qty = CType(CType(gridDataItem("colQTY").FindControl("TxtQTY"), TextBox).Text, Integer)
                                If functionnotes <> "" Then
                                    est.UpdateRequestFunction(Me.EstNum, Me.EstCompNum, Me.reqNum, functioncode, functionnotes)
                                End If
                                'est.UpdateRequestDetailQty(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, functioncode, qty)
                            End If
                        Next
                    End If
                Next
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                vendorcode = gridDataItem.GetDataKeyValue("VN_CODE")
                vendorcontcode = CType(gridDataItem("colVC_FNAME").FindControl("hfVN_CONT_CODE"), HiddenField).Value
                specs = CType(gridDataItem("colVN_NOTES").FindControl("TxtVN_NOTES"), TextBox).Text
                If wvIsDate(CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text) = True Then
                    submitted = CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text
                    submitted = wvCDate(submitted)
                ElseIf CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text <> "" And CType(gridDataItem("colDISPATCH_DATE").FindControl("TxtDISPATCH_DATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Submitted Date")
                    Exit Sub
                End If
                If wvIsDate(CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text) = True Then
                    replydate = CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text
                    replydate = wvCDate(replydate)
                ElseIf CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text <> "" And CType(gridDataItem("colREPLY_DATE").FindControl("TxtREPLY_DATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Replied Date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                    duedate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()
                End If
                est.UpdateRequestVendor(Me.EstNum, Me.EstCompNum, Me.reqNum, vendorcode, vendorcontcode, specs, submitted, replydate, duedate)
                submitted = ""
                replydate = ""
                duedate = ""
            Next
            For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorReplies.MasterTableView.Items
                quoteno = CInt(GridDataItem.Item("colEST_QUOTE_NBR").Text)
                revno = CInt(GridDataItem.Item("colEST_REV_NBR").Text)
                functioncode = GridDataItem.Item("colEST_FNC_CODE").Text
                vendorcode = GridDataItem.Item("colVN_CODE").Text
                If IsNumeric(DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text) Then
                    replyrate = CType(DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text, Decimal)
                ElseIf DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text <> "" And DirectCast(GridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Reply Rate")
                    Exit Sub
                End If
                If IsNumeric(DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text) Then
                    replyamt = CType(DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text, Decimal)
                ElseIf DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text <> "" And DirectCast(GridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text <> "&nbsp;" Then
                    Me.ShowMessage("Invalid Reply Amount")
                    Exit Sub
                End If
                replynotes = CType(GridDataItem("colREPLY_NOTES").FindControl("TxtREPLY_NOTES"), TextBox).Text
                approved = DirectCast(GridDataItem("colAPPROVED_FLAG").FindControl("cbAPPROVED_FLAG"), CheckBox).Checked
                approvalnotes = CType(GridDataItem("colAPPROVAL_NOTES").FindControl("TxtAPPROVAL_NOTES"), TextBox).Text
                approvedby = CType(GridDataItem("colAPPROVED_BY").FindControl("TxtAPPROVED_BY"), TextBox).Text
                If approved = True Then
                    approveddate = Now.Date.ToShortDateString
                End If
                qty = CType(CType(GridDataItem("colQTY").FindControl("TxtQTY"), TextBox).Text, Integer)
                Try
                    est.UpdateRequestDetail(Me.EstNum, Me.EstCompNum, Me.reqNum, quoteno, revno, functioncode, vendorcode, replyrate, replyamt, replynotes, approved, approvalnotes, approvedby, approveddate, qty, Me.RadDatePickerRequestDate.SelectedDate)
                Catch ex As Exception

                End Try
                replyrate = 0
                replyamt = 0
                qty = 0
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertEstQuote(ByVal functioncode As String, ByVal vendorcode As String, ByVal vendornotes As String, ByVal qty As Integer, ByVal rate As Decimal, ByVal amount As Decimal, ByVal quote As Integer, ByVal rev As Integer)
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))

            Dim suppliedby As String = ""
            Dim markuppct As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim markupamt As Decimal = 0.0
            Dim fnctype As String = ""
            Dim fnccpmflag As Integer
            Dim taxcomm As Integer
            Dim taxcommonly As Integer
            Dim fncnobillflag As Integer
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim taxstatepct As Decimal = 0.0
            Dim taxcountypct As Decimal = 0.0
            Dim taxcitypct As Decimal = 0.0
            Dim taxresale As Integer = 0
            Dim taxresalenbr As String = ""
            Dim extnonresaletax As Decimal = 0.0
            Dim extstateresale As Decimal = 0.0
            Dim extcountyresale As Decimal = 0.0
            Dim extcityresale As Decimal = 0.0
            Dim extstatenonresale As Decimal = 0.0
            Dim extcountynonresale As Decimal = 0.0
            Dim extcitynonresale As Decimal = 0.0
            Dim extstatemarkup As Decimal = 0.0
            Dim extcountymarkup As Decimal = 0.0
            Dim extcitymarkup As Decimal = 0.0
            Dim extmucont As Decimal = 0.0
            Dim extstatecont As Decimal = 0.0
            Dim extcountycont As Decimal = 0.0
            Dim extcitycont As Decimal = 0.0
            Dim extnrcont As Decimal = 0.0
            Dim linetotal As Decimal = 0.0
            Dim linetotalcont As Decimal = 0.0
            Dim taxcode As String = ""
            Dim estmarkuppct As Decimal = 0
            Dim jobmarkuppct As Decimal = 0
            Dim feetime As Integer = 0

            Dim client As String = ""
            Dim division As String = ""
            Dim product As String = ""
            Dim sc As String = ""
            Dim job As Integer = 0
            Dim jobcomp As Integer = 0

            Dim dr As SqlClient.SqlDataReader
            Dim max As Integer
            Dim sort As Integer
            dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, quote, rev)
            If dr.HasRows = True Then
                Do While dr.Read
                    client = dr("CL_CODE")
                    division = dr("DIV_CODE")
                    product = dr("PRD_CODE")
                    sc = dr("SC_CODE")
                    If IsDBNull(dr("JOB_NUMBER")) = False Then
                        job = dr("JOB_NUMBER")
                    End If
                    If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                        jobcomp = dr("JOB_COMPONENT_NBR")
                    End If
                    contpct = dr("PRD_CONT_PCT")
                    estmarkuppct = dr("EST_MARKUP_PCT")
                    jobmarkuppct = dr("JOB_MARKUP_PCT")
                Loop
            End If
            dr.Close()

            Dim dt As DataTable


            If functioncode = "" Then
                '"Function Code Required."
                Exit Sub
            Else
                markuppct = 0.0
                markupamt = 0.0
                taxcode = ""
                contamt = 0.0
                linetotalcont = 0.0
                linetotal = 0.0
                feetime = 0
                dt = est.GetDefaultFunctionData(functioncode, job, jobcomp, client, division, product, sc, vendorcode)
                If dt.Rows.Count > 0 Then
                    'If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
                    'rate = dt.Rows(0)("BILLING_RATE")
                    'End If
                    If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
                        fnctype = dt.Rows(0)("FNC_TYPE")
                    End If
                    If IsDBNull(dt.Rows(0)("NOBILL_FLAG")) = False Then
                        fncnobillflag = dt.Rows(0)("NOBILL_FLAG")
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_COMM")) = False Then
                        taxcomm = dt.Rows(0)("TAX_COMM")
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_COMM_ONLY")) = False Then
                        taxcommonly = dt.Rows(0)("TAX_COMM_ONLY")
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_CODE")) = False Then
                        taxcode = dt.Rows(0)("TAX_CODE")
                        fnctaxflag = 1
                    Else
                        taxcode = ""
                        fnctaxflag = 0
                    End If
                    taxstatepct = dt.Rows(0)("TAX_STATE_PERCENT")
                    taxcountypct = dt.Rows(0)("TAX_COUNTY_PERCENT")
                    taxcitypct = dt.Rows(0)("TAX_CITY_PERCENT")
                    If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                        taxresale = dt.Rows(0)("TAX_RESALE")
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_RESALE_NUMBER")) = False Then
                        taxresalenbr = dt.Rows(0)("TAX_RESALE_NUMBER")
                    End If
                    If IsDBNull(dt.Rows(0)("FEE_TIME_FLAG")) = False Then
                        feetime = dt.Rows(0)("FEE_TIME_FLAG")
                    End If
                    If IsDBNull(dt.Rows(0)("COMM")) = False Then
                        markuppct = dt.Rows(0)("COMM")
                        If markuppct = 0 Then
                            fnccommflag = 0
                        Else
                            fnccommflag = 1
                        End If
                    Else
                        fnccommflag = 1
                        markuppct = estmarkuppct
                    End If
                    'If rate > 0 Then
                    '    extamt = quantityhours * rate
                    'End If
                    If markuppct > 0 And amount Then
                        markupamt = amount * (markuppct / 100)
                        extmucont = markupamt * (contpct / 100)
                    Else
                        markupamt = 0.0
                    End If
                    If contpct > 0 Then
                        contamt = amount * (contpct / 100)
                        If markuppct > 0 Then
                            linetotalcont += (markupamt * (contpct / 100))
                        End If
                    End If
                    If taxresale = 1 Then
                        If taxcommonly <> 1 Then
                            extstateresale = amount * (taxstatepct / 100)
                            extcountyresale = amount * (taxcountypct / 100)
                            extcityresale = amount * (taxcitypct / 100)
                        End If
                        If taxcomm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxstatepct / 100)
                                extcountymarkup = markupamt * (taxcountypct / 100)
                                extcitymarkup = markupamt * (taxcitypct / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                        If contamt > 0 Then
                            If taxcomm = 1 And taxcommonly = 1 Then
                                extstatecont = extmucont * (taxstatepct / 100)
                                extcountycont = extmucont * (taxcountypct / 100)
                                extcitycont = extmucont * (taxcitypct / 100)
                            ElseIf taxcomm = 1 Then
                                extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                            Else
                                extstatecont = contamt * (taxstatepct / 100)
                                extcountycont = contamt * (taxcountypct / 100)
                                extcitycont = contamt * (taxcitypct / 100)
                            End If
                        End If
                    End If
                    If taxresale <> 1 Then
                        If fnctype = "V" Then
                            If taxcommonly <> 1 Then
                                extstatenonresale = amount * (taxstatepct / 100)
                                extcountynonresale = amount * (taxcountypct / 100)
                                extcitynonresale = amount * (taxcitypct / 100)
                                extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                            End If
                            If contamt > 0 Then
                                If taxcomm = 1 And taxcommonly = 1 Then
                                    extnrcont = extmucont * (taxstatepct / 100) + extmucont * (taxcountypct / 100) + extmucont * (taxcitypct / 100)
                                ElseIf taxcomm = 1 Then
                                    extnrcont = (contamt + extmucont) * (taxstatepct / 100) + contamt * (taxcountypct / 100) + contamt * (taxcitypct / 100)
                                End If
                            End If
                        ElseIf fnctype = "E" Or fnctype = "I" Then
                            If taxcommonly <> 1 Then
                                extstateresale = amount * (taxstatepct / 100)
                                extcountyresale = amount * (taxcountypct / 100)
                                extcityresale = amount * (taxcitypct / 100)
                            End If
                            If contamt > 0 Then
                                If taxcomm = "1" And taxcommonly = "1" Then
                                    extstatecont = extmucont * (taxstatepct / 100)
                                    extcountycont = extmucont * (taxcountypct / 100)
                                    extcitycont = extmucont * (taxcitypct / 100)
                                ElseIf taxcomm = "1" Then
                                    extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                    extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                    extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                                End If
                            End If
                        End If
                        If taxcomm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxstatepct / 100)
                                extcountymarkup = markupamt * (taxcountypct / 100)
                                extcitymarkup = markupamt * (taxcitypct / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                    End If
                End If
                dt = est.GetAddNewFunctionData(functioncode)
                If dt.Rows.Count > 0 Then
                    fnccpmflag = dt.Rows(0)("FNC_CPM_FLAG")
                End If
            End If

            linetotal = amount + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
            linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)
            'Save:
            Try
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                'straighten out the phaseID and description! (also on quick add)
                oEstimating.AddNewFunction(EstNum, EstCompNum, quote, rev, 0, functioncode, markuppct, contpct, qty,
                                            rate, vendorcode, vendornotes, amount, taxcode, "", markupamt,
                                            contamt, linetotal, 1, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly,
                                            taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale,
                                            extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime, 0)

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RadGridVersions_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridVersions.DetailTableDataBind
        Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim ds As DataSet
        Dim dataItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
        Dim QuoteNo As Integer = dataItem.GetDataKeyValue("EST_QUOTE_NBR")
        ds = oEstimate.GetRequestQuotes(Me.EstNum, Me.EstCompNum, Me.reqNum, QuoteNo, Session("UserCode"))
        e.DetailTableView.DataSource = ds.Tables(1)
    End Sub

    Private Sub RadGridVersions_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVersions.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim griddataitem As Telerik.Web.UI.GridDataItem
            griddataitem = e.Item
            Select Case e.CommandName
                Case "ShowComments"
                    Me.UpdateHeader()
                    Me.SaveGrid()
                    Dim version As Integer
                    Dim revision As Integer
                    Dim dr As SqlDataReader
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    QuoteNum = griddataitem.GetDataKeyValue("EST_QUOTE_NBR") 'CInt(e.Item.Cells(3).Text)
                    RevNum = griddataitem.GetDataKeyValue("EST_REV_NBR") 'CInt(e.Item.Cells(5).Text)
                    dr = est.GetEstimateQuoteInfo(EstNum, EstCompNum, QuoteNum, RevNum)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            version = dr("SPEC_VER")
                            revision = dr("SPEC_REV")
                            If IsDBNull(dr("JOB_NUMBER")) = False Then
                                Me.JobNum = dr("JOB_NUMBER")
                            End If
                            If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                                Me.JobCompNum = dr("JOB_COMPONENT_NBR")
                            End If
                        Loop
                    End If
                    Dim StrCommentsURL As String = "VendorQuote_Comments.aspx?From=quote&EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&reqNum=" & Me.reqNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.RevNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & version & "&SpecRev=" & revision
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)
                    Me.OpenWindow("", StrCommentsURL, 600, 650, False, False)
                Case "ShowCommentsFunction"
                    Me.UpdateHeader()
                    Me.SaveGrid()
                    Dim version As Integer
                    Dim revision As Integer
                    Dim func As String
                    Dim dr As SqlDataReader
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    QuoteNum = griddataitem.GetDataKeyValue("EST_QUOTE_NBR") 'CInt(e.Item.Cells(7).Text)
                    RevNum = griddataitem.GetDataKeyValue("EST_REV_NBR") 'CInt(e.Item.Cells(8).Text)
                    func = griddataitem.GetDataKeyValue("EST_FNC_CODE") 'e.Item.Cells(3).Text
                    dr = est.GetEstimateQuoteInfo(EstNum, EstCompNum, QuoteNum, RevNum)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            version = dr("SPEC_VER")
                            revision = dr("SPEC_REV")
                            If IsDBNull(dr("JOB_NUMBER")) = False Then
                                Me.JobNum = dr("JOB_NUMBER")
                            End If
                            If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                                Me.JobCompNum = dr("JOB_COMPONENT_NBR")
                            End If
                        Loop
                    End If
                    Dim StrCommentsURL As String = "VendorQuote_Comments.aspx?From=func&EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&reqNum=" & Me.reqNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.RevNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & version & "&SpecRev=" & revision & "&funccode=" & func
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)
                    Me.OpenWindow("", StrCommentsURL, 600, 650, False, False)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVersions_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVersions.ItemCreated
        Try
            'Dim chk As CheckBox
            'Dim txt As System.Web.UI.WebControls.TextBox
            'Dim tab As Integer = 4
            'If Session("TabVersionsRFQ") Is Nothing Then
            '    Session("TabVersionsRFQ") = tab
            'End If
            'If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
            '    'Dim gridhead As Telerik.Web.UI.GridHeaderItem = e.Item
            '    'If gridhead.HasChildItems = False Then
            '    '    chk = CType(gridhead("ColumnClientSelect").Controls(0), CheckBox)
            '    '    chk.TabIndex = Session("TabVersionsRFQ") + 1
            '    'End If
            'ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            '    Dim griditem As Telerik.Web.UI.GridDataItem = e.Item
            '    txt = CType(griditem("colVN_QTE_SPECS").FindControl("TxtVN_QTE_SPECS"), TextBox)
            '    txt.TabIndex = tab
            '    chk = CType(griditem("ColumnClientSelect").Controls(0), CheckBox)
            '    chk.TabIndex = tab
            '    txt = CType(griditem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox)
            '    txt.TabIndex = tab
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVersions_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVersions.ItemDataBound
        Try
            Dim chk As CheckBox
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim txt As System.Web.UI.WebControls.TextBox
                txt = e.Item.FindControl("TxtVN_QTE_SPECS")
                If txt.Text <> "" And txt.Text <> "&nbsp;" Then
                    Session("SpellObjectsVersions") &= "new HtmlElementTextSource(document.getElementById('" & txt.ClientID & "'))" & Environment.NewLine & ","
                End If

                'txt = e.Item.FindControl("TxtEST_FNC_COMMENT")
                'spellobjects &= "new HtmlElementTextSource(document.getElementById('" & txt.ClientID & "'))" & Environment.NewLine & ","
                If rights = "N" Then
                    txt.ReadOnly = True
                End If

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                Dim str As String = CurrentGridRow("EST_QUOTE_DESC").Text

                If str = "&nbsp;" Then
                    CurrentGridRow("EST_QUOTE_DESC").Text = "Quote " & CurrentGridRow.GetDataKeyValue("EST_QUOTE_NBR").ToString
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVersions_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVersions.NeedDataSource
        Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim ds As DataSet
        ds = oEstimate.GetRequestQuotes(Me.EstNum, Me.EstCompNum, Me.reqNum, 0, Session("UserCode"))
        Me.RadGridVersions.DataSource = ds.Tables(0)
        If ds.Tables(0).Rows.Count = 0 Then
            Me.RadToolbarVersions.Items(5).Enabled = False
            Me.RadToolbarVersions.Items(7).Enabled = False
        Else
            Me.RadToolbarVersions.Items(5).Enabled = True
            Me.RadToolbarVersions.Items(7).Enabled = True
        End If
    End Sub

    Private Sub RadGridVendors_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVendors.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Select Case e.CommandName
                'Case "SetClientContacts"
                '    Dim StrURL As String = "VendorQuote_Contacts.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum & "&VnCode=" & e.CommandArgument.ToString
                '    AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "ContactWindow", "Add Contact", StrURL, 590, 900, True)
                Case "ShowComments"
                    Me.UpdateHeader()
                    Me.SaveGrid()
                    Dim vendorcode As String
                    Dim dr As SqlDataReader
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    vendorcode = e.Item.Cells(6).Text

                    Dim StrCommentsURL As String = "VendorQuote_Comments.aspx?From=vendor&EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&reqNum=" & Me.reqNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.RevNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&vncode=" & vendorcode
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)
                    Me.OpenWindow("", StrCommentsURL, 600, 650, False, False)
                Case "ViewReport"
                    Try
                        Session("VendorsRFQVendors") = ""
                        Dim strJC As String = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&VendorQteNbr=" & Me.reqNum & "&Report=VendorQuoteRequest&Type=1&VendorCode=" & e.CommandArgument.ToString
                        'Dim strJCBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        'strJCBuilder2.Append("<script language='javascript'>")
                        'strJCBuilder2.Append("window.open('" & strJC & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        'strJCBuilder2.Append("</")
                        'strJCBuilder2.Append("script>")
                        'Page.RegisterStartupScript("RFQ", strJCBuilder2.ToString())
                        Response.Redirect(strJC)
                    Catch ex As Exception

                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendors_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVendors.ItemDataBound
        Try
            Dim txt As System.Web.UI.WebControls.TextBox
            Dim txt2 As System.Web.UI.WebControls.TextBox
            Dim txt3 As System.Web.UI.WebControls.TextBox
            Dim txt4 As System.Web.UI.WebControls.TextBox
            Dim txt5 As System.Web.UI.WebControls.TextBox
            Dim Lbl As System.Web.UI.WebControls.Label
            Dim lb As System.Web.UI.WebControls.LinkButton
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(3).Text
                Dim str2 As String = e.Item.Cells(4).Text
                Dim str3 As String = e.Item.Cells(5).Text
                Dim str4 As String = e.Item.Cells(6).Text  'vn cont code
                Dim str5 As String = e.Item.Cells(9).Text
                Dim str6 As String = e.Item.Cells(10).Text 'fname

                txt = CType(e.Item.FindControl("TxtVC_FNAME"), TextBox)
                Dim fname As String = txt.Text
                If e.Item.Cells(12).Text <> "" And e.Item.Cells(12).Text <> "&nbsp;" Then
                    txt.Text = e.Item.Cells(12).Text & ", " & fname
                End If
                If e.Item.Cells(11).Text <> "" And e.Item.Cells(11).Text <> "&nbsp;" Then
                    txt.Text = txt.Text & " " & e.Item.Cells(11).Text & "."
                End If
                txt5 = CType(e.Item.FindControl("TxtVC_ADDRESS1"), TextBox)
                If e.Item.Cells(16).Text <> "" And e.Item.Cells(16).Text <> "&nbsp;" Then
                    txt5.Text = txt5.Text & vbCrLf & e.Item.Cells(16).Text
                End If
                If e.Item.Cells(17).Text <> "" And e.Item.Cells(17).Text <> "&nbsp;" Then
                    txt5.Text = txt5.Text & ", " & e.Item.Cells(17).Text
                End If
                If e.Item.Cells(18).Text <> "" And e.Item.Cells(18).Text <> "&nbsp;" Then
                    txt5.Text = txt5.Text & " " & e.Item.Cells(18).Text
                End If

                txt2 = e.Item.FindControl("TxtDISPATCH_DATE")
                If txt2.Text <> "" And txt2.Text <> "&nbsp;" Then
                    txt2.Text = LoGlo.FormatDate(txt2.Text)
                End If
                txt3 = e.Item.FindControl("TxtREPLY_DATE")
                If txt3.Text <> "" And txt3.Text <> "&nbsp;" Then
                    txt3.Text = LoGlo.FormatDate(txt3.Text)
                End If

                Dim chk As CheckBox
                Dim chk2 As CheckBox
                chk = e.Item.FindControl("chkEmailClient")
                If e.Item.Cells(13).Text = "" Or e.Item.Cells(13).Text = "&nbsp;" Then
                    chk.Enabled = False
                Else
                    chk.Checked = True
                End If
                chk2 = e.Item.FindControl("chkPrintClient")
                'chk.Checked = True

                Dim imgbtn As System.Web.UI.WebControls.ImageButton
                Dim hf As System.Web.UI.WebControls.HiddenField
                hf = CType(e.Item.FindControl("hfVN_CONT_CODE"), HiddenField)
                imgbtn = e.Item.FindControl("ImgBtnClientContacts")
                imgbtn.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=purchaseorder&type=vendor_contacts&str=" & e.Item.Cells(6).Text & "&control2=" & txt.ClientID & "&control=" & hf.ClientID & "');return false;")

                txt4 = e.Item.FindControl("TxtVN_NOTES")
                If txt4.Text <> "" And txt4.Text <> "&nbsp;" Then
                    Session("SpellObjectsVendors") &= "new HtmlElementTextSource(document.getElementById('" & txt2.ClientID & "'))" & Environment.NewLine & ","
                End If

                lb = e.Item.FindControl("lbtnViewClient")
                If rightsPrint = "N" Then
                    chk2.Checked = False
                    chk2.Enabled = False
                    lb.Visible = False
                End If
                If rights = "N" Then
                    chk.Enabled = False
                    imgbtn.Visible = False
                    txt2.ReadOnly = True
                    txt3.ReadOnly = True
                    txt4.ReadOnly = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendors_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendors.NeedDataSource
        Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
        Me.RadGridVendors.DataSource = oEstimate.GetRequestVendors(Me.EstNum, Me.EstCompNum, Me.reqNum, Session("UserCode"))
    End Sub

    Private Sub RadGridVendorReplies_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVendorReplies.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim griddataitem As Telerik.Web.UI.GridDataItem
            griddataitem = e.Item
            Select Case e.CommandName
                Case "ShowComments"
                    Me.UpdateHeader()
                    Me.SaveGrid()
                    Dim vendorcode As String
                    Dim functioncode As String
                    Dim dr As SqlDataReader
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    QuoteNum = griddataitem.GetDataKeyValue("EST_QUOTE_NBR") 'CInt(e.Item.Cells(4).Text)
                    RevNum = griddataitem.GetDataKeyValue("EST_REV_NBR") 'CInt(e.Item.Cells(17).Text)
                    vendorcode = griddataitem.GetDataKeyValue("VN_CODE") 'e.Item.Cells(7).Text
                    functioncode = griddataitem.GetDataKeyValue("EST_FNC_CODE") 'e.Item.Cells(16).Text

                    Dim StrCommentsURL As String = "VendorQuote_Comments.aspx?From=vendorrep&EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&reqNum=" & Me.reqNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.RevNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&vncode=" & vendorcode & "&funccode=" & functioncode
                    Me.OpenWindow("", StrCommentsURL, 600, 650, False, True)
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendorReplies_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVendorReplies.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(3).Text
                Dim str2 As String = e.Item.Cells(4).Text
                Dim str3 As String = e.Item.Cells(5).Text
                Dim str4 As String = e.Item.Cells(6).Text
                Dim str5 As String = e.Item.Cells(7).Text
                Dim str6 As String = e.Item.Cells(8).Text

                If e.Item.Cells(11).Text <> "" And e.Item.Cells(11).Text <> "&nbsp;" Then
                    If e.Item.Cells(11).Text = "1" Then
                        e.Item.Cells(11).Text = "Yes"
                    Else
                        e.Item.Cells(11).Text = "&nbsp;"
                    End If
                End If

                Dim tb As System.Web.UI.WebControls.TextBox
                Dim tb2 As System.Web.UI.WebControls.TextBox
                Dim tb3 As System.Web.UI.WebControls.TextBox
                Dim tb4 As System.Web.UI.WebControls.TextBox
                Dim tb5 As System.Web.UI.WebControls.TextBox
                Dim tb6 As System.Web.UI.WebControls.TextBox
                Dim cb As CheckBox
                tb = e.Item.FindControl("TxtQTY")
                tb2 = e.Item.FindControl("TxtREPLY_RATE")
                tb3 = e.Item.FindControl("TxtREPLY_AMT")
                tb.Attributes.Add("onkeyup", "javascript:Multiply('" & tb.ClientID & "','" & tb2.ClientID & "','" & tb3.ClientID & "');")
                tb2.Attributes.Add("onkeyup", "javascript:Multiply('" & tb.ClientID & "','" & tb2.ClientID & "','" & tb3.ClientID & "');")
                tb3.Attributes.Add("onchange", "javascript:CalcRateOverrideEst('" & tb.ClientID & "','" & tb2.ClientID & "','" & tb3.ClientID & "');")

                tb.Text = String.Format("{0:#,##0}", CInt(tb.Text))
                tb2.Text = String.Format("{0:#,##0.0000}", CDec(tb2.Text))
                tb3.Text = String.Format("{0:#,##0.00}", CDec(tb3.Text))

                Dim txt As System.Web.UI.WebControls.TextBox
                txt = e.Item.FindControl("TxtREPLY_NOTES")
                If txt.Text <> "" And txt.Text <> "&nbsp;" Then
                    Session("SpellObjectsVendors") &= "new HtmlElementTextSource(document.getElementById('" & txt.ClientID & "'))" & Environment.NewLine & ","
                End If

                txt = e.Item.FindControl("TxtAPPROVAL_NOTES")
                If txt.Text <> "" And txt.Text <> "&nbsp;" Then
                    Session("SpellObjectsVendors") &= "new HtmlElementTextSource(document.getElementById('" & txt.ClientID & "'))" & Environment.NewLine & ","
                End If

                tb4 = e.Item.FindControl("TxtREPLY_NOTES")
                tb5 = e.Item.FindControl("TxtAPPROVED_BY")
                tb6 = e.Item.FindControl("TxtAPPROVAL_NOTES")
                cb = e.Item.FindControl("cbAPPROVED_FLAG")
                If rights = "N" Then
                    tb.ReadOnly = True
                    tb2.ReadOnly = True
                    tb3.ReadOnly = True
                    tb4.ReadOnly = True
                    tb5.ReadOnly = True
                    tb6.ReadOnly = True
                    cb.Enabled = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendorReplies_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendorReplies.NeedDataSource
        Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
        Me.RadGridVendorReplies.DataSource = oEstimate.GetRequestVendorReplies(Me.EstNum, Me.EstCompNum, Me.reqNum, Session("UserCode"))
    End Sub



#End Region

#Region " Functions "

    Private Function GenerateRFQ()
        Try
            Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim newRFQNum As Integer
            newRFQNum = oEstimate.GetRequestNumber(Me.EstNum, Me.EstCompNum, Session("UserCode"))
            Return newRFQNum
        Catch ex As Exception

        End Try
    End Function

    Private Function GetEstimateDesc()
        Try
            Dim oEstimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dt As DataTable
            dt = oEstimate.GetEstimateData(Me.EstNum, Me.EstCompNum, 0, 0, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                        Me.TxtRFQDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                    Else
                        Me.TxtRFQDescription.Text = ""
                    End If
                Next
            End If
            Return ""
        Catch ex As Exception

        End Try
    End Function

    Public Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Public Function SetEmailCheckBox(ByVal Value As Integer, ByVal Value1 As String) As Boolean
        Try
            If Value = 1 Then
                If Value1 = "" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Function OutputReportFileRFQ(Optional ByVal vendor As String = "") As String
        Dim sb1 As New System.Text.StringBuilder 'build filename
        Dim sbDate As New System.Text.StringBuilder 'unique timestamp for filename..
        Dim sbTime As New System.Text.StringBuilder
        Dim sbReportName As New System.Text.StringBuilder

        'sbTime.Append("__")
        sbDate.Append(Now.Year.ToString())
        sbDate.Append(Now.Month.ToString())
        sbDate.Append(Now.Day.ToString())
        sbTime.Append(Now.Hour.ToString())
        sbTime.Append(Now.Minute.ToString())
        sbTime.Append(Now.Second.ToString())

        sb1.Append(Request.PhysicalApplicationPath.Trim)
        sb1.Append("TEMP\")

        sb1.Append("RFQ_")
        sb1.Append(Request.QueryString("EstNum"))
        'If comp <> 0 Then
        sb1.Append("_")
        sb1.Append(Request.QueryString("EstComp"))
        'End If
        sb1.Append("_")
        sb1.Append(reqNum.ToString())
        sb1.Append("_")
        sb1.Append(sbDate.ToString())
        'sb1.Append("_")
        'sb1.Append(sbTime.ToString())

        sb1.Append(".PDF")

        sbReportName.Append(Request.QueryString("Report"))
        'sbReportName.Append(Me.dl_Template.SelectedValue.Trim)

        Session("VendorReqEstNum") = Request.QueryString("EstNum")
        Session("VendorReqEstComp") = Request.QueryString("EstComp")
        Session("VendorReqVenQte") = Request.QueryString("vendorreq")
        Session("VendorReqVenCode") = vendor

        Dim rpt As New popReportViewer

        Try
            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), "VendorQteRequest", "", "", "", "", "", 1, imgPath)
            Return sb1.ToString
        Catch ex As Exception
            'Me.lbl_msg.Text = ex.Message.Trim
            Return ""
        End Try

    End Function

    Sub ProcessEmails(ByVal sFileName As String, ByVal AlertID As Integer, Optional ByVal DocIdList As String = "", Optional ByVal vendoremail As String = "", Optional ByVal vendorccemail As String = "")
        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
        If IsNTAuth = True Then
            currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
            impersonationContext = currentWindowsIdentity.Impersonate()
        End If

        Dim URLwv As String
        Dim URLcp As String
        Dim csec As New cSecurity(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader
        dr = csec.getSettingsCP()
        If dr.HasRows = True Then
            Do While dr.Read
                URLwv = Request.Url.Scheme & "://" & dr.GetString(0)
                URLcp = Request.Url.Scheme & "://" & dr.GetString(1)
                'URLwv = Request.Url.Scheme & "://" & Request.Url.Host & "/" & dr.GetString(0)
                'URLcp = Request.Url.Scheme & "://" & Request.Url.Host & "/" & dr.GetString(1)
            Loop
            dr.Close()
        Else
            URLwv = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath
        End If

        Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
        Dim boolMisc As Boolean

        boolMisc = ws.GetSMPTSettingsByUser()
        If boolMisc = False Then
            'Me.lbl_msg.Text = ws.getErrMsg()
            Exit Sub
        End If

        Dim FromEmailAddress As String = ws.oSMTPSettings.SMTP_SENDER

        'If IsNTAuth = True Then
        '    impersonationContext.Undo()
        'End If

        Dim NowDate As Date = Now

        Dim i As Integer
        If FromEmailAddress = "" Then
            Me.ShowMessage("You do not have an email address in the database. No Email was sent.")
            Exit Sub
        End If

        Dim oWebServices As cWebServices = New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim sbBody As New System.Text.StringBuilder
        Dim Sent_Count As Integer = 0
        Dim node As Telerik.Web.UI.RadTreeNode
        Dim send_result As Boolean = True
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVarbody As String
        Dim taskVarsubject As String = ""

        'Me.lbl_msg.Text = ""
        Dim ds As DataSet
        Dim dsVendors As DataSet
        Dim vn As String
        dsVendors = est.GetRequestVendors(CInt(Request.QueryString("EstNum")), CInt(Request.QueryString("EstComp")), CInt(Request.QueryString("vendorreq")), Session("ConnString"))
        ds = est.GetRequestVendorReplies(CInt(Request.QueryString("EstNum")), CInt(Request.QueryString("EstComp")), CInt(Request.QueryString("vendorreq")), Session("ConnString"))
        sbBody.Append("RFQ - ")
        sbBody.Append(Request.QueryString("EstNum").PadLeft(6, "0"))
        sbBody.Append("-")
        sbBody.Append(Request.QueryString("EstComp").PadLeft(2, "0"))
        sbBody.Append("-")
        sbBody.Append(reqNum.ToString.PadLeft(2, "0"))
        sbBody.Append(" - attached in ")
        sbBody.Append("PDF")
        sbBody.Append(" format.")


        sbBody.Append("<br />")
        taskVarbody = otask.getAppVars(Session("UserCode"), "RequestPrint", "Body")
        If taskVarbody <> "" Then
            sbBody.Append(taskVarbody)
        End If

        taskVarsubject = otask.getAppVars(Session("UserCode"), "RequestPrint", "Subject")
        If taskVarsubject = "" Then
            taskVarsubject = "Request for Quote"
        End If
        'Dim docIds(0) As Integer
        'Dim ar() As String
        'ar = DocIdList.Split(",")
        'For g As Integer = 0 To ar.Length - 1
        '    If ar(g) <> "" Then
        '        docIds(g) = ar(g)
        '    End If
        'Next
        'sbBody.Append(Me.Radeditor1.Text.Trim)

        Try
            send_result = oWebServices.SendEmailNewNoDocs(sFileName.Trim, vendoremail & "," & vendorccemail, taskVarsubject, sbBody.ToString.Trim)
            If send_result = False Then
                Me.ShowMessage(oWebServices.getErrMsg)
            End If
        Catch ex As Exception
            'lbl_msg.Text = ex.Message.ToString
        End Try

        If IsNTAuth = True Then
            impersonationContext.Undo()
        End If

        sbBody = Nothing

        If send_result = False Then
            'lbl_msg.Text = ""
            email = False
            Exit Sub
        Else
            email = True
        End If

    End Sub

    ''TODO:  FIX!!!!!!!
    'Private Function WriteSpellScript(ByVal source_string As String) As String
    '    Dim sb As New System.Text.StringBuilder

    '    'With sb
    '    '    .Append("<script type=""text/javascript"">" & Environment.NewLine)
    '    '    .Append("/*<![CDATA[*/" & Environment.NewLine)

    '    '    .Append("function MultipleTextSource(sources)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("this.sources = sources;" & Environment.NewLine)
    '    '    .Append("" & Environment.NewLine)
    '    '    .Append("this.GetText = function()" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("var texts = [];" & Environment.NewLine)
    '    '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("texts[texts.length] = this.sources[i].getText();" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("return texts.join(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)
    '    '    .Append("this.SetText = function(text)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("var texts = text.split(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
    '    '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("this.sources[i].setText(texts[i]);" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)

    '    '    .Append("function startSpell()" & Environment.NewLine)
    '    '    .Append("{    " & Environment.NewLine)
    '    '    .Append("var sources = " & Environment.NewLine)
    '    '    .Append("[" & Environment.NewLine)
    '    '    .Append(source_string)
    '    '    .Append("];" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)
    '    '    .Append("var spell = GetRadSpell('" & spell1.ClientID & "');" & Environment.NewLine)
    '    '    .Append("spell.SetTextSource(new MultipleTextSource(sources));" & Environment.NewLine)
    '    '    .Append("spell.StartSpellCheck();" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("/*]]>*/" & Environment.NewLine)
    '    '    .Append("</script>" & Environment.NewLine)
    '    'End With
    '    Return sb.ToString
    'End Function

    'Private Sub startSpell()
    '    Dim textboxCount, idx As Integer
    '    Dim textboxID As String
    '    Dim spelID As String
    '    Dim sb As New System.Text.StringBuilder

    '    Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
    '    With sbScript
    '        .Append("<script type=""text/javascript"">startSpell();</script>")
    '    End With
    '    Try
    '        If Not Page.IsStartupScriptRegistered("CBSpell2") Then
    '            Dim str As String = sbScript.ToString
    '            Page.RegisterStartupScript("CBSpell2", str)
    '        End If
    '    Catch ex As Exception
    '        Me.ShowMessage("Error " & ex.Message.ToString())
    '    End Try

    'End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

            If secView = "N" Then
                rightsPrint = "N"
            End If
            If secEdit = "N" And secInsert = "N" Then
                Me.RadToolbarVendorQuote.FindItemByValue("Save").Enabled = False
                Me.RadToolbarVendorQuote.FindItemByValue("Setup").Enabled = False
                Me.RadToolbarVendorQuote.FindItemByValue("Submit").Enabled = False
                Me.TxtRFQDescription.ReadOnly = True
                Me.RadDatePickerRequestDate.Enabled = True
                Me.RadDatePickerDueDate.Enabled = True
                Me.TxtDescriptionOfProject.ReadOnly = True
                If Me.pnlVersions.Visible = True Then
                    Me.RadToolbarVersions.FindItemByValue("AddQuote").Enabled = False
                    Me.RadToolbarVersions.FindItemByValue("DeleteQuote").Enabled = False
                    Me.RadToolbarVersions.FindItemByValue("AddFunction").Enabled = False
                    Me.RadToolbarVersions.FindItemByValue("DeleteFunction").Enabled = False
                End If
                If Me.pnlVendors.Visible = True Then
                    Me.RadToolbarVendors.FindItemByValue("AddVendor").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("DeleteVendor").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("AddContact").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("EditContact").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("InsertEst").Enabled = False
                End If
                rights = "N"
            ElseIf secEdit = "Y" And secInsert = "N" Then
                If Me.pnlVersions.Visible = True Then
                    Me.RadToolbarVersions.FindItemByValue("AddQuote").Enabled = False
                    Me.RadToolbarVersions.FindItemByValue("AddFunction").Enabled = False
                End If
                If Me.pnlVendors.Visible = True Then
                    Me.RadToolbarVendors.FindItemByValue("AddVendor").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("AddContact").Enabled = False
                End If
            ElseIf secEdit = "N" And secInsert = "Y" Then
                Me.RadToolbarVendorQuote.FindItemByValue("Save").Enabled = False
                Me.TxtRFQDescription.ReadOnly = True
                Me.RadDatePickerRequestDate.Enabled = True
                Me.RadDatePickerDueDate.Enabled = True
                Me.TxtDescriptionOfProject.ReadOnly = True
                If Me.pnlVersions.Visible = True Then
                    Me.RadToolbarVersions.FindItemByValue("DeleteQuote").Enabled = False
                    Me.RadToolbarVersions.FindItemByValue("DeleteFunction").Enabled = False
                End If
                If Me.pnlVendors.Visible = True Then
                    Me.RadToolbarVendors.FindItemByValue("DeleteVendor").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("EditContact").Enabled = False
                    Me.RadToolbarVendors.FindItemByValue("InsertEst").Enabled = False
                End If
                rights = "N"

            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub ShowRFQMessage(ByVal venEmail As Boolean, ByVal venPrint As Boolean)
        Try
            If venEmail = True And venPrint = True Then
                Me.ShowMessage("All selected Vendor Quote Requests have been emailed and printed.")
            ElseIf venEmail = True And venPrint = False Then
                Me.ShowMessage("All selected Vendor Quote Requests have been emailed.")
            ElseIf venEmail = False And venPrint = True Then
                Me.ShowMessage("All selected Vendor Quote Requests have been printed.")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub RadToolbarVendorQuote_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarVendorQuote.ButtonClick
        Select Case e.Item.Value
            Case "Save"
                Try
                    Me.UpdateHeader()
                    Me.SaveGrid()

                    'Me.CloseThisWindow()
                Catch ex As Exception

                End Try
            Case "Setup"
                Try
                    Dim StrURL As String = "VendorQuote_PrintSetup.aspx?tab=" & Me.RadTabStrip.SelectedTab.Value & "&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetupWindow", "Email/Print Setup", StrURL, 640, 700, True)
                    Me.OpenWindow("Email/Print Setup", StrURL, 640, 700, False, True)
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                Catch ex As Exception

                End Try
            Case "Submit"
                Try
                    Me.UpdateHeader()
                    Me.SaveGridNoRebind()
                    Dim chk As CheckBox
                    Dim vendorsEmail As String = ""
                    Dim vendorsEmailAddress As String = ""
                    Dim vendorsPrint As String = ""
                    Dim count As Integer = 0
                    Dim approved As Boolean = False
                    Dim sFileName As String = ""
                    Dim taskVar As String
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim otask As cTasks = New cTasks(Session("ConnString"))
                    Dim emp As New cEmployee(Session("ConnString"))
                    Dim vendorccemail As String
                    Dim update As Boolean = False
                    Dim venEmail As Boolean = False
                    Dim venPrint As Boolean = False
                    'est.UpdateRequestVendorSubmit(EstNum, EstCompNum, reqNum, vn, Now.Date, Session("UserCode"))

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                        chk = CType(gridDataItem("colChkEmailClient").FindControl("chkEmailClient"), CheckBox)
                        If chk.Checked Then
                            vendorsEmail &= gridDataItem.GetDataKeyValue("VN_CODE") & ","
                            vendorsEmailAddress &= gridDataItem.GetDataKeyValue("EMAIL_ADDRESS") & ","
                            update = est.UpdateRequestVendorSubmit(EstNum, EstCompNum, reqNum, gridDataItem.GetDataKeyValue("VN_CODE"), Now.Date, Session("UserCode"))
                            count += 1
                        End If
                        chk = CType(gridDataItem("colChkPrintClient").FindControl("chkPrintClient"), CheckBox)
                        If chk.Checked Then
                            vendorsPrint &= gridDataItem.GetDataKeyValue("VN_CODE") & ","
                            If update <> True Then
                                update = est.UpdateRequestVendorSubmit(EstNum, EstCompNum, reqNum, gridDataItem.GetDataKeyValue("VN_CODE"), Now.Date, Session("UserCode"))
                            End If
                            count += 1
                        End If
                    Next
                    If count = 0 Then
                        Me.ShowMessage("No rows were selected.")
                    End If
                    taskVar = otask.getAppVars(Session("UserCode"), "RequestPrint", "CC")
                    If taskVar = "True" Then
                        vendorccemail = emp.GetEmail(Session("EmpCode"))
                    End If
                    If vendorsEmailAddress <> "" Then
                        Dim strvendor As String()
                        Dim stremail As String()
                        vendorsEmail = MiscFN.RemoveTrailingDelimiter(vendorsEmail, ",")
                        vendorsEmailAddress = MiscFN.RemoveTrailingDelimiter(vendorsEmailAddress, ",")
                        strvendor = vendorsEmail.Split(",")
                        stremail = vendorsEmailAddress.Split(",")
                        For i As Integer = 0 To strvendor.Length - 1
                            sFileName = Me.OutputReportFileRFQ(strvendor(i))
                            ProcessEmails(sFileName.Trim, 0, "", stremail(i), vendorccemail)
                        Next
                        venEmail = True
                    End If
                    If vendorsPrint <> "" Then
                        Session("VendorsRFQVendors") = vendorsPrint
                        Dim strJC As String = "popReportViewer.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&VendorQteNbr=" & Me.reqNum & "&Report=VendorQuoteRequest&Type=1"
                        Dim strJCBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        strJCBuilder2.Append("<script language='javascript'>")
                        strJCBuilder2.Append("window.open('" & strJC & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strJCBuilder2.Append("</")
                        strJCBuilder2.Append("script>")
                        Page.ClientScript.RegisterStartupScript(Me.GetType, "RFQ", strJCBuilder2.ToString())
                        'Response.Redirect(strJC)
                        venPrint = True
                    End If
                    Me.ShowRFQMessage(venEmail, venPrint)
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                    Me.RadGridVendors.Rebind()
                Catch ex As Exception

                End Try
            Case "Back"
                Me.SaveGrid()
                MiscFN.ResponseRedirect("Estimating.aspx?From=VenQte&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&newEst=edit")
                Exit Sub
                'Case "Spell"
                '    startSpell()
            Case "Send"
                Try
                    Dim chk As CheckBox
                    Dim vn As String = ""
                    Dim count As Integer = 0
                    Dim approved As Boolean = False
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            'If IsNumeric(gridDataItem.GetDataKeyValue("VN_CODE")) Then
                            vn = gridDataItem.GetDataKeyValue("VN_CODE")
                            'End If
                            count += 1
                        End If
                    Next

                    If count = 0 Then
                        Me.ShowMessage("No rows were selected for sending requests.")
                    End If
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    est.UpdateRequestVendorSubmit(EstNum, EstCompNum, reqNum, vn, Now.Date, Session("UserCode"))

                    'Dim strURL As String = "popsend.aspx?pagetype=rfq&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&VendorQteNbr=" & Me.reqNum & "&Report=VendorQteRequest&VendorCode=" & vn
                    Dim strURL As String = "Alert_New.aspx?send=1&caller=vendorquote&pagetype=rfq&e=" & Me.EstNum & "&ec=" & Me.EstCompNum & "&vqn=" & Me.reqNum & "&Report=VendorQteRequest&vc=" & vn & "&f=" & MiscFN.SourceApp_ToInt(Source_App.VendorQuote).ToString()
                    Me.OpenWindow("New Alert", strURL)

                Catch ex As Exception

                End Try

        End Select
    End Sub

    Private Sub RadToolbarVersions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarVersions.ButtonClick
        Select Case e.Item.Value
            Case "AddQuote"
                Try
                    Dim StrURL As String = "VendorQuote_Versions.aspx?tab=1&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuoteWindow1", "Add Quotes", StrURL, 590, 900, True)
                    Me.OpenWindow("Add Quotes", StrURL, 590, 900, False, True)
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                Catch ex As Exception

                End Try
            Case "DeleteQuote"
                Try
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim count As Integer = 0
                    Dim approved As Boolean = False
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVersions.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            If IsNumeric(gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")) Then
                                DelString &= gridDataItem.GetDataKeyValue("EST_QUOTE_NBR") & ","
                            End If
                            count += 1
                        End If
                    Next
                    'If approved = True Then
                    '    Me.ShowMessage("An approved quote cannot be deleted."))
                    'End If
                    If count = 0 Then
                        Me.ShowMessage("No rows were selected for deletion.")
                    End If
                    DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                    Dim DelSQL As String = ""
                    If EstNum > 0 And EstCompNum > 0 And DelString.Length > 0 Then
                        DelSQL = "DELETE FROM VENDOR_QTE_DTL WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND EST_QUOTE_NBR IN (" & DelString & ");DELETE FROM VENDOR_QTE_SPECS WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND EST_QUOTE_NBR IN (" & DelString & ");"
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()

                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If
                    Me.LoadData()
                    Session("SpellObjectsVersions") = ""
                    Session("SpellObjectsVendors") = ""
                    Me.RadGridVersions.Rebind()
                    'Me.DelQuote = True
                    'Me.ReloadMe = True
                Catch ex As Exception

                End Try
            Case "AddFunction"
                Try
                    Dim StrURL As String = "VendorQuote_Functions.aspx?tab=1&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuoteWindow2", "Add Functions", StrURL, 590, 900, True)
                    Me.OpenWindow("Add Functions", StrURL, 590, 900, False, True)
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                Catch ex As Exception

                End Try
            Case "DeleteFunction"
                Try
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim count As Integer = 0
                    Dim approved As Boolean = False
                    Dim gtv As Telerik.Web.UI.GridTableView
                    For i As Integer = 0 To Me.RadGridVersions.MasterTableView.Items.Count - 1
                        For j As Integer = 0 To Me.RadGridVersions.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                            gtv = CType(Me.RadGridVersions.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                            If gtv.Items.Count > 0 Then
                                For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                                    If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                        Dim str4 As String = gtv.ParentItem.Cells.Item(3).Text
                                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                                        If chk.Checked Then
                                            'If IsNumeric(gridDataItem.GetDataKeyValue("EST_FNC_CODE")) Then
                                            DelString &= "'" & gridDataItem.OwnerTableView.DataKeyValues(gridDataItem.ItemIndex)("EST_FNC_CODE") & "',"
                                            'End If
                                            count += 1
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                    'If approved = True Then
                    '    Me.ShowMessage("An approved quote cannot be deleted."))
                    'End If
                    If count = 0 Then
                        Me.ShowMessage("No rows were selected for deletion.")
                    End If
                    DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                    Dim DelSQL As String = ""
                    If EstNum > 0 And EstCompNum > 0 And DelString.Length > 0 Then
                        DelSQL = "DELETE FROM VENDOR_QTE_DTL WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND EST_FNC_CODE IN (" & DelString & ");DELETE FROM VENDOR_QTE_FNC WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND EST_FNC_CODE IN (" & DelString & ");"
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()

                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If
                    Me.LoadData()
                    Session("SpellObjectsVersions") = ""
                    Session("SpellObjectsVendors") = ""
                    Me.RadGridVersions.Rebind()
                    'Me.DelQuote = True
                    'Me.ReloadMe = True
                Catch ex As Exception

                End Try

        End Select
    End Sub

    Private Sub RadToolbarVendors_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarVendors.ButtonClick
        Select Case e.Item.Value
            Case "AddVendor"
                Try
                    Dim StrURL As String = "VendorQuote_Vendors.aspx?tab=0&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuoteWindow3", "Add Vendors", StrURL, 590, 900, True)
                    Me.OpenWindow("Add Vendors", StrURL, 590, 900, False, True)
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                Catch ex As Exception

                End Try
            Case "DeleteVendor"
                Try
                    Try
                        Dim chk As CheckBox
                        Dim DelString As String = ""
                        Dim count As Integer = 0
                        Dim approved As Boolean = False
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked Then
                                'If IsNumeric(gridDataItem.GetDataKeyValue("VN_CODE")) Then
                                DelString &= "'" & gridDataItem.GetDataKeyValue("VN_CODE") & "',"
                                'End If
                                count += 1
                            End If
                        Next
                        'If approved = True Then
                        '    Me.ShowMessage("An approved quote cannot be deleted."))
                        'End If
                        If count = 0 Then
                            Me.ShowMessage("No rows were selected for deletion.")
                        End If
                        DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                        Dim DelSQL As String = ""
                        If EstNum > 0 And EstCompNum > 0 And DelString.Length > 0 Then
                            DelSQL = "DELETE FROM VENDOR_QTE_DTL WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND VN_CODE IN (" & DelString & ");DELETE FROM VENDOR_QTE_VEN WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND VENDOR_QTE_NBR = " & reqNum & " AND VN_CODE IN (" & DelString & ");"
                            Using MyConn As New SqlConnection(Session("ConnString"))
                                MyConn.Open()
                                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                                Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                                Try
                                    MyCmd.ExecuteNonQuery()
                                    MyTrans.Commit()

                                Catch ex As Exception
                                    MyTrans.Rollback()
                                Finally
                                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                End Try
                            End Using
                        End If
                        Me.LoadData()
                        Session("SpellObjectsVersions") = ""
                        Session("SpellObjectsVendors") = ""
                        Me.RadGridVersions.Rebind()
                        Me.RadGridVendors.Rebind()
                        Me.RadGridVendorReplies.Rebind()
                        'Me.DelQuote = True
                        'Me.ReloadMe = True
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try
            Case "InsertEst"
                Try
                    Dim chk As CheckBox
                    Dim chk2 As CheckBox
                    Dim functioncode As String = ""
                    Dim vendorcode As String = ""
                    Dim vendornotes As String = ""
                    Dim qty As Integer = 0
                    Dim rate As Decimal = 0.0
                    Dim amount As Decimal = 0.0
                    Dim quote As Integer
                    Dim rev As Integer
                    Dim count As Integer
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorReplies.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        chk2 = CType(gridDataItem("colAPPROVED_FLAG").FindControl("cbAPPROVED_FLAG"), CheckBox)
                        If chk.Checked = True And chk2.Checked = True Then
                            'Set variables:
                            functioncode = gridDataItem.GetDataKeyValue("EST_FNC_CODE")
                            vendorcode = gridDataItem.GetDataKeyValue("VN_CODE")
                            quote = gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")
                            'rev = gridDataItem("colEST_REV_NBR").Text.Replace("&nbsp;", "")
                            rev = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, quote)
                            count += 1
                            Try
                                vendornotes = CType(gridDataItem("colREPLY_NOTES").FindControl("TxtREPLY_NOTES"), TextBox).Text
                            Catch ex As Exception
                                vendornotes = ""
                            End Try
                            Try
                                qty = CType(CType(gridDataItem("colQTY").FindControl("TxtQTY"), TextBox).Text, Integer)
                            Catch ex As Exception
                                qty = 0
                            End Try
                            Try
                                rate = CType(CType(gridDataItem("colREPLY_RATE").FindControl("TxtREPLY_RATE"), TextBox).Text, Decimal)
                            Catch ex As Exception
                                rate = 0
                            End Try
                            Try
                                amount = CType(CType(gridDataItem("colREPLY_AMT").FindControl("TxtREPLY_AMT"), TextBox).Text, Decimal)
                            Catch ex As Exception
                                amount = 0
                            End Try
                            Try
                                InsertEstQuote(functioncode, vendorcode, vendornotes, qty, rate, amount, quote, rev)
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                    If count = 0 Then
                        Me.ShowMessage("No approved rows were selected for insertion.")
                    Else
                        Me.ShowMessage("All selected rows have been inserted into Estimate/Quote.")
                    End If
                    Me.SaveGrid()
                    Session("SpellObjectsVendors") = ""
                    Session("SpellObjectsVersions") = ""
                    Me.RadGridVendorReplies.Rebind()
                Catch ex As Exception

                End Try
            Case "AddContact"
                Try
                    Dim chk As CheckBox
                    Dim vendorcode As String
                    Dim vendorcontact As String
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            vendorcode = gridDataItem("VN_CODE").Text.Replace("&nbsp;", "")
                            vendorcontact = CType(gridDataItem("colVC_FNAME").FindControl("hfVN_CONT_CODE"), HiddenField).Value
                            count += 1
                        End If
                    Next
                    If count = 0 Then
                        Me.ShowMessage("No Vendor row was selected.")
                        Exit Sub
                    End If
                    If count > 1 Then
                        Me.ShowMessage("Please select only one row when adding a Vendor Contact.")
                        Exit Sub
                    End If
                    Dim StrURL As String = "VendorQuote_Contacts.aspx?tab=0&type=New&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum & "&VnCode=" & vendorcode & "&Contact=" & vendorcontact
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "ContactWindow", "Add Contact", StrURL, 500, 500, True)
                    Me.OpenWindow("Add Contact", StrURL, 500, 500, False, True)
                Catch ex As Exception

                End Try
            Case "EditContact"
                Try
                    Dim chk As CheckBox
                    Dim vendorcode As String
                    Dim vendorcontact As String
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            vendorcode = gridDataItem("VN_CODE").Text.Replace("&nbsp;", "")
                            vendorcontact = CType(gridDataItem("colVC_FNAME").FindControl("hfVN_CONT_CODE"), HiddenField).Value
                            count += 1
                        End If
                    Next
                    If count = 0 Then
                        Me.ShowMessage("No vendor row was selected.")
                        Exit Sub
                    End If
                    If count > 1 Then
                        Me.ShowMessage("Please select only one row when editing a Vendor Contact.")
                        Exit Sub
                    End If
                    If vendorcontact = "" Then
                        Me.ShowMessage("Please select a Vendor Contact for editing.")
                        Exit Sub
                    End If
                    Dim StrURL As String = "VendorQuote_Contacts.aspx?tab=0&type=Edit&EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&reqNum=" & Me.reqNum & "&VnCode=" & vendorcode & "&Contact=" & vendorcontact
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "ContactWindow", "Edit Contact", StrURL, 500, 500, True)
                    Me.OpenWindow("Edit Contact", StrURL, 500, 500, False, True)
                Catch ex As Exception

                End Try

        End Select
    End Sub


End Class
