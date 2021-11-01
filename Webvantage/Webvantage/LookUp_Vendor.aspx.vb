Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class LookUp_Vendor
    Inherits Webvantage.BaseLookupPage

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

    Public CurrForm As String = String.Empty
    Public CurrType As String = String.Empty
    Public CurrStr As String = ""
    Public CurrCat As String = ""
    Public ControlsToSet As String = ""
    Public OpenerRadWindowName As String = ""

    Private Sub Page_PreInit2(sender As Object, e As EventArgs) Handles Me.PreInit

        Me.SetLookupGrid(Me.RadGridLookup)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try
        Try
            CurrForm = Request.QueryString("form")
            CurrType = Request.QueryString("type")
            CurrStr = Request.QueryString("str")
            CurrCat = Request.QueryString("cat")
        Catch ex As Exception
        End Try

        Dim sec As New cSecurity(Session("ConnString"))
        If Not Page.IsPostBack Then
            If Not Session("ConnString") Is Nothing And Session("ConnString") <> "" Then


                Dim vc As String = sec.GetVendorContactSecurity(Session("UserCode"))
                If vc = "N" Or CurrType <> "vendor_contacts" Then
                    Me.DivAddEdit.Visible = False
                End If
                If Me.DivAddEdit.Visible = True Then
                    imgbtnAdd.Attributes.Add("onclick", "OpenRadWindow('Vendor Contact','VendorQuote_Contacts.aspx?from=popvc&type=New&VnCode=" & CurrStr & "', 'PopLookupVC','screenX=150,left=150,screenY=150,top=150,width=500,height=450,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
                End If
            End If
        End If

    End Sub

    Function GetMarkupPercent() As String
        Dim PODtl As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim oJob As Job = New Job(CStr(Session("ConnString")))
        Dim cl, div, prd, fnc As String
        Dim job, comp As Integer
        Dim markup As Decimal

        fnc = Me.txtCode.Value
        If Request.QueryString("job") <> "" Then
            job = CInt(Request.QueryString("job"))
            comp = CInt(Request.QueryString("jobcomp"))
        Else
            job = 0
            comp = 0
        End If

        If job = 0 Or comp = 0 Then
            markup = 0
        Else
            oJob.GetJob(job, comp)
            markup = PODtl.GetBillRateMarkup("", fnc, oJob.CL_CODE.Trim, oJob.DIV_CODE.Trim, oJob.PRD_CODE.Trim, job, comp)
        End If

        Return CStr(markup)

    End Function

    Function SetupSendBackValueScripts() As String
        Dim sbScript As New System.Text.StringBuilder
        Dim cnt As Integer = Request.QueryString.Keys.Count + 1
        Dim ix As Integer = 0
        Dim return_val_count As Integer = 1
        Dim sb2 As New System.Text.StringBuilder

        'sbScript.Append("<script type=""text/javascript"">")

        sbScript.Append("CallingWindowContent.document.getElementById('")
        sbScript.Append(Request.QueryString("control"))
        sbScript.Append("').value='")
        sbScript.Append(Me.txtCode.Value)
        sbScript.Append("';")
        Try
            If Me.CurrType.Trim <> "vendor_functions" Then
                For ix = 0 To cnt Step 1
                    If Not Request.QueryString("control" & ix.ToString()) Is Nothing Then

                        If return_val_count = 1 Then
                            sb2.Append("")
                        Else
                            sb2.Append(return_val_count.ToString())
                        End If

                        sbScript.Append(" CallingWindowContent.document.getElementById('")
                        sbScript.Append(Request.QueryString("control" & ix.ToString()))
                        sbScript.Append("').value='")
                        If return_val_count = 1 Then
                            sbScript.Append(Me.txtValue.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 2 Then
                            sbScript.Append(Me.txtValue2.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 3 Then
                            sbScript.Append(Me.txtValue3.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 4 Then
                            sbScript.Append(Me.txtValue4.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 5 Then
                            sbScript.Append(Me.txtValue5.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 6 Then
                            sbScript.Append(Me.txtValue6.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 7 Then
                            sbScript.Append(Me.txtValue7.Value.Replace("'", "\'"))
                        ElseIf return_val_count = 8 Then
                            sbScript.Append(Me.txtValue8.Value.Replace("'", "\'"))
                        Else
                            sbScript.Append(Me.txtValue.Value.Replace("'", "\'"))
                        End If
                        sbScript.Append("';")

                        return_val_count = return_val_count + 1

                        sb2.Length = 0
                    End If
                Next


            Else
                Dim PODtl As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                Dim iqty As Integer
                Dim sfunct_desc As String
                Dim cpmflg As Boolean = False
                Dim cpmqty As Integer
                Dim funct_total, rate, cpmtotal As Decimal
                Dim glacode, gladesc As String
                Dim strA() As String

                strA = Me.SelectedText.Split("-")
                sbScript.Append(" CallingWindowContent.document.getElementById('")
                sbScript.Append(Request.QueryString("control2"))
                sbScript.Append("').value='" & strA(1).Trim & "';")

                PODtl.GetFunctionInfo(Me.SelectedValue(), Int32.Parse(Session("PONumberPODetail")), iqty, sfunct_desc, cpmflg, cpmqty, funct_total, glacode, gladesc)
                sbScript.Append(" CallingWindowContent.document.getElementById('")
                sbScript.Append(Request.QueryString("control3"))
                If cpmflg = True Then
                    sbScript.Append("').value='CPM';")
                Else
                    sbScript.Append("').value='';")
                End If

                If PODtl.GetPOGLAccountSelection(Request.QueryString("empcode")) = 1 Then
                    sbScript.Append(" CallingWindowContent.document.getElementById('")
                    sbScript.Append(Request.QueryString("control4"))
                    sbScript.Append("').value='" & txtValue3.Value & "';")
                    sbScript.Append(" CallingWindowContent.document.getElementById('")
                    sbScript.Append(Request.QueryString("control5"))
                    sbScript.Append("').value='" & txtValue4.Value & "';")
                End If

                Dim markup As String
                markup = GetMarkupPercent()
                sbScript.Append(" CallingWindowContent.document.getElementById('")
                sbScript.Append(Request.QueryString("control6"))
                sbScript.Append("').value=" & markup)
                sbScript.Append(";")


                Dim mrkup As String
                mrkup = "''"

                sbScript.Append(" CallingWindowContent.document.getElementById('")
                sbScript.Append(Request.QueryString("control7"))
                sbScript.Append("').value=" & mrkup)
                sbScript.Append(";")

            End If
            sb2 = Nothing

            'sbScript.Append(" window.close();</script>")

            'If Not Page.IsStartupScriptRegistered("PO_Sendback") Then
            '    Page.RegisterStartupScript("PO_Sendback", sbScript.ToString())
            'End If

            If CurrForm = "purchaseorder_search" Then
                sbScript.Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")
            End If


            Dim str As String = sbScript.ToString
            Return str

            sbScript = Nothing

        Catch ex As Exception

        End Try

    End Function

    Private Sub SelectItem()

        Dim dt As DataTable
        Dim drow As DataRow
        Dim ix, mx As Integer
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim PODtl As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim oV As New cValidations(Session("ConnString"))

        Me.txtCode.Value = Me.SelectedValue()

        dt = POHeader.GetCustomPickList_DTable(Me.CurrType.Trim, If(CurrStr IsNot Nothing, CurrStr.Trim, ""), "", Session("UserCode"))

        mx = dt.Rows.Count - 1

        For ix = 0 To mx Step 1

            drow = dt.Rows(ix)

            If drow(0).ToString.Trim = Me.txtCode.Value.Trim Then

                If Me.CurrType.Trim = "vendor_contacts" Then

                    Me.txtValue.Value = drow(1).ToString

                Else

                    Me.txtValue.Value = drow(9).ToString

                End If
                If drow(2).ToString() = "-1.00" Then
                    Me.txtValue2.Value = ""
                Else
                    Me.txtValue2.Value = drow(2).ToString
                End If
                Me.txtValue3.Value = drow(3).ToString
                Me.txtValue4.Value = drow(4).ToString
                Me.txtValue5.Value = drow(5).ToString
                Me.txtValue6.Value = drow(6).ToString
                Me.txtValue7.Value = drow(7).ToString
                Me.txtValue8.Value = drow(8).ToString
                Exit For
            End If
        Next
        If Request.QueryString("empcode") <> "" Then
            If PODtl.GetPOGLAccountSelection(Request.QueryString("empcode")) <> 1 Then
                Me.txtValue3.Value = ""
                Me.txtValue4.Value = ""
            End If
        End If

        If Me.CurrType.Trim = "vendor_functions" And Me.txtValue3.Value <> "" Then
            Dim job As String = Request.QueryString("job")
            If job <> "" Then
                If IsNumeric(job) = True Then
                    Me.txtValue3.Value = ""
                    Me.txtValue4.Value = ""
                End If
            End If
            If oV.ValidateGlaCode(Me.txtValue3.Value) = False Then
                Me.txtValue3.Value = ""
                Me.txtValue4.Value = ""
            End If
            If PODtl.CheckPOGLLimitOffice(Request.QueryString("empcode"), Me.txtValue3.Value) = False Then
                Me.txtValue3.Value = ""
                Me.txtValue4.Value = ""
            End If
        End If

        ''Me.ControlsToSet = SetupSendBackValueScripts()
        ''Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

        Me.ControlsToSet = SetupSendBackValueScripts()
        Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

        Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

    End Sub

    Protected Sub btn_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Select.Click

        Me.SelectItem()

    End Sub

    Private Sub imgbtnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnEdit.Click
        Try
            If Me.SelectedValue() = "" Then

                Me.ShowMessage("Please select a contact to edit.")
                Exit Sub

            End If

            Dim strScript As String = ""
            strScript = "VendorQuote_Contacts.aspx?from=popvc&type=Edit&VnCode=" & CurrStr & "&Contact=" & Me.SelectedValue()
            'Me.OpenLookUp(strScript)

            Me.OpenWindow("", strScript)

        Catch ex As Exception
        End Try
    End Sub

    Private Function SelectedValue() As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridLookup.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.GetDataKeyValue("CODE1")
            End If
        Next
    End Function

    Private Function SelectedText() As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridLookup.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.Item("GridBoundColumnVALUE").Text
            End If
        Next
    End Function

    'Private Sub RadGridLookup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridLookup.SelectedIndexChanged
    '    Me.SelectItem()
    'End Sub

    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)
        Try

            Dim oGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            MyBase.RaisePostBackEvent(sourceControl, eventArgument)
            If sourceControl Is RadGridLookup AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") > -1) Then
                oGridDataItem = RadGridLookup.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True
                    Me.SelectItem()
                End If
            End If
            If sourceControl Is RadGridLookup AndAlso (eventArgument.IndexOf("IndexOfRowClicked") > -1) Then
                oGridDataItem = RadGridLookup.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True
                End If
            End If

        Catch ex As Exception

            If ex.Message.ToString().Contains("Invalid attempt to call FieldCount when reader is closed") = True Then

                Me.ShowMessage("You cannot search the data before the data is loaded")

            Else

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End If

            Me.CloseThisWindow()

        End Try
    End Sub

    Private Sub RadGridLookup_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridLookup.ItemCommand
        Select Case e.CommandName
            Case "Filter"
                Try
                    Dim filteringItem As GridFilteringItem = DirectCast(RadGridLookup.MasterTableView.GetItems(GridItemType.FilteringItem)(0), GridFilteringItem)
                    Dim box As System.Web.UI.WebControls.TextBox = TryCast(filteringItem("GridBoundColumnDescription").Controls(0), TextBox)
                    Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "justfocus", "SetCursorToTextEnd('" & box.ClientID & "');", True)
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub RadGridLookup_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridLookup.NeedDataSource

        Dim dt As DataTable
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        If String.IsNullOrWhiteSpace(CurrStr) Then

            CurrStr = ""

        End If

        dt = POHeader.GetCustomPickList_DTable(Me.CurrType.Trim, CurrStr.Trim, "", Session("UserCode"))
        Me.RadGridLookup.DataSource = dt

    End Sub

    Private Sub RadGridLookup_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridLookup.PreRender
        Try
            If Not Me.IsPostBack And Not Me.IsCallback Then
                Dim filteringItem As GridFilteringItem = DirectCast(RadGridLookup.MasterTableView.GetItems(GridItemType.FilteringItem)(0), GridFilteringItem)
                Dim box As System.Web.UI.WebControls.TextBox = TryCast(filteringItem("GridBoundColumnDescription").Controls(0), TextBox)
                Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "justfocus", "SetCursorToTextEnd('" & box.ClientID & "');", True)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
