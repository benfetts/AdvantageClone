Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class purchaseorder_gen_picklist
    Inherits Webvantage.BaseChildPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Page.IsPostBack Then
            If Not Request.QueryString("type") Is Nothing Then
                lbl_type.Text = Request.QueryString("type").Trim

                If Not Request.QueryString("str") Is Nothing Then
                    txtStr.Text = Request.QueryString("str").Trim
                End If

                LoadTypeOptions()
                LoadPickListItems()
                Me.txtLookup.Attributes.Add("onfocusin", " select();")
            End If

            If Not Request.QueryString("control") Is Nothing Then
                lbl_control.Text = Request.QueryString("control").Trim
            End If


            Me.txtLookup.Focus()

        End If
    End Sub

    Sub LoadTypeOptions()
        Select Case lbl_type.Text.Trim
            Case "vendor_list"
                lbl_type.Text = "vendor_all_active"
                CreateItems()
                rbl_options.SelectedIndex = rbl_options.Items.IndexOf(rbl_options.Items.FindByValue("vendor_all_active"))
            Case Else
                Dim li As New ListItem
                li.Value = "1"
                li.Text = "All - No Filter"
                rbl_options.Items.Add(li)
        End Select
        rbl_options.Items(0).Selected = True
    End Sub
    Sub CreateItems()
        CreateListItem("vendor_all_active", "All Active Vendors")
        CreateListItem("vendor_filter_recent", "All Active Vendors, Recently Used First")
    End Sub
    Sub CreateListItem(ByVal item_value As String, ByVal item_text As String)
        Dim li As New ListItem
        li.Value = item_value.Trim
        li.Text = item_text.Trim
        rbl_options.Items.Add(li)
    End Sub
    Sub LoadPickListItems()
        Dim dr As SqlDataReader
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        dr = POHeader.GetCustomPickList(lbl_type.Text.Trim, txtStr.Text.Trim, "")
        gv_list.DataSource = dr
        gv_list.DataBind()
    End Sub
    Protected Sub ibtn_refresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn_refresh.Click
        LoadPickListItems()
    End Sub
    Sub SetupSendBackScripts()
        Dim sbScript As New System.Text.StringBuilder
        Dim str2 As String

        sbScript.Append("<script type=""text/javascript"">")
        sbScript.Append("  function returnValue(){")
        sbScript.Append("opener.document.forms[0].")
        sbScript.Append(lbl_control.Text.Trim)
        sbScript.Append(".value=document.frmPicklist.txtCode.value;")
        str2 = SetupSendBackValueScripts()
        sbScript.Append(str2.Trim)
        sbScript.Append(" self.close();")
        sbScript.Append("}  </script>")

        Page.RegisterClientScriptBlock("Webvantage", sbScript.ToString())

    End Sub
    Function SetupSendBackValueScripts() As String
        Dim sbScript As New System.Text.StringBuilder
        Dim cnt As Integer = Request.QueryString.Keys.Count + 1
        Dim ix As Integer = 0
        Dim return_val_count As Integer = 1
        Dim sb2 As New System.Text.StringBuilder

        For ix = 0 To cnt Step 1
            If Not Request.QueryString("control" & ix.ToString()) Is Nothing Then

                If return_val_count = 1 Then
                    sb2.Append("")
                Else
                    sb2.Append(return_val_count.ToString())
                End If

                sbScript.Append(" opener.document.forms[0].")
                sbScript.Append(Request.QueryString("control" & ix.ToString()))
                sbScript.Append(".value=document.frmPicklist.txtValue")
                sbScript.Append(sb2.ToString())
                sbScript.Append(".value;")

                return_val_count = return_val_count + 1

                sb2.Length = 0
            End If
        Next

        sb2 = Nothing

        Return sbScript.ToString

    End Function

    Private Sub purchaseorder_gen_picklist_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        SetupSendBackScripts()
    End Sub

    Private Sub gv_list_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_list.RowDataBound
        Dim val As String
        Dim ibtn As System.Web.UI.WebControls.ImageButton

        If e.Row.RowType = DataControlRowType.DataRow Then
            val = DataBinder.Eval(e.Row.DataItem, "CODE1")
            If val.Trim = "" Then
                ibtn = e.Row.FindControl("select")
                ibtn.Visible = False
                e.Row.BackColor = Color.AliceBlue
            End If
        End If

    End Sub

    Private Sub gv_list_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_list.SelectedIndexChanged
        Dim data As DataKey = gv_list.DataKeys(gv_list.SelectedRow.RowIndex)
        txtCode.Text = data.Values("CODE1")
        txtValue.Text = data.Values("VALUE1")
        txtValue2.Text = data.Values("VALUE2")
        txtValue3.Text = data.Values("VALUE3")
        txtValue4.Text = data.Values("VALUE4")
        txtValue5.Text = data.Values("VALUE5")
        txtValue6.Text = data.Values("VALUE6")
        txtValue7.Text = data.Values("VALUE7")

        HideRowsAboveSelection(gv_list.SelectedRow.RowIndex)

        Dim lnkCod As System.Web.UI.WebControls.LinkButton = CType(gv_list.SelectedRow.FindControl("lbtn_select_code"), LinkButton)
        lnkCod.ForeColor = Color.White

        Dim lnkValue As System.Web.UI.WebControls.LinkButton = CType(gv_list.SelectedRow.FindControl("lbtn_select_value"), LinkButton)
        lnkValue.ForeColor = Color.White


    End Sub

    Private Sub rbl_options_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_options.SelectedIndexChanged
        lbl_type.Text = rbl_options.SelectedValue
        LoadPickListItems()
        txtLookup.Text = ""
    End Sub
    Sub FindGridText()
        Dim gvr As GridViewRow
        For Each gvr In gv_list.Rows

            If gvr.RowType = DataControlRowType.DataRow Then

                Dim hl As System.Web.UI.WebControls.LinkButton = CType(gvr.FindControl("lbtn_select_value"), LinkButton)

                If hl.Text.ToLower.Trim.Contains(txtLookup.Text.ToLower.Trim) Then
                    gvr.Visible = True
                Else
                    gvr.Visible = False
                End If
            End If
        Next

    End Sub

    Sub HideRowsAboveSelection(ByVal rindex As Integer)
        Dim gvr As GridViewRow
        For Each gvr In gv_list.Rows

            If gvr.RowType = DataControlRowType.DataRow Then
                If gvr.RowIndex < rindex Then
                    gvr.Visible = False
                End If
            End If
        Next
    End Sub

    Protected Sub ibtn_back_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn_back.Click
        UnHideAllRows()
    End Sub

    Protected Sub ibtn_search_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn_search.Click
        If txtLookup.Text.Trim = "" Then
            txtLookup.Text = "[Enter text to search for.]"
            txtLookup.Focus()
            Exit Sub
        End If
        FindGridText()
    End Sub
    Sub UnHideAllRows()
        Dim gvr As GridViewRow
        For Each gvr In gv_list.Rows

            If gvr.RowType = DataControlRowType.DataRow Then
                gvr.Visible = True
            End If
        Next
    End Sub

    Private Sub txtLookup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLookup.TextChanged
        FindGridText()
    End Sub

    Protected Sub lbtn_top_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_top.Click
        UnHideAllRows()
    End Sub

    Private Sub gv_list_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gv_list.SelectedIndexChanging
        Try
            If gv_list.SelectedRow.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = gv_list.SelectedRow

                Dim lnkCod As System.Web.UI.WebControls.LinkButton = CType(row.FindControl("lbtn_select_code"), LinkButton)
                lnkCod.ForeColor = Color.Blue

                Dim lnkValue As System.Web.UI.WebControls.LinkButton = CType(row.FindControl("lbtn_select_value"), LinkButton)
                lnkValue.ForeColor = Color.Blue

            End If
        Catch ex As Exception
        End Try

    End Sub
End Class