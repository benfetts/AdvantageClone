Imports Webvantage.cGlobals

Partial Public Class purchaseorder_alert
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Page.IsPostBack Then
            If Not Request.QueryString("alert_funct") Is Nothing Then
                Me.lbl_alert_funct.Text = Request.QueryString("alert_funct")
            End If
            If Not Request.QueryString("ref_id") Is Nothing Then
                Me.lbl_RefID.Text = Request.QueryString("ref_id").Trim
            End If

            Select Case Me.lbl_alert_funct.Text.Trim
                Case "email_po"
                    Me.Purchaseorder_base_info1.PO_Number = Int32.Parse(Me.lbl_RefID.Text.Trim)
                    Me.Purchaseorder_base_info1.RetrievePOHeader()
                    Me.PopulateEmailSubject()
                    RetrieveVendorContactEmailList()
            End Select

            PopulatePickLists()

        End If
    End Sub
    Sub PopulatePickLists()
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim dr As Data.SqlClient.SqlDataReader

        dr = POHeader.GetPO_Locations(1, Session("Empcode"))
        Me.dl_LocationID.DataSource = dr
        Me.dl_LocationID.DataBind()

        Me.dl_LocationID.Items.Add(New Telerik.Web.UI.RadComboBoxItem("None", ""))
        Me.dl_LocationID.SelectedIndex = 0

        LoadPriority()

        'Template for future use to handle multiple versions of PO report.. append to report name.
        dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Standard", ""))
        Me.dl_Template.SelectedIndex = 0

    End Sub
    Private Sub LoadPriority()
        'Me.PriorityDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("None"), CStr("0")))
        'Me.PriorityDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("High"), CStr("1")))
        'Me.PriorityDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Medium"), CStr("2")))
        'Me.PriorityDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Low"), CStr("3")))

        'Me.PriorityDropDownList.SelectedIndex = 0
        Dim a As New cAlerts()
        a.LoadPrioritiesComboBox(Me.PriorityDropDownList)
    End Sub

    Sub PopulateEmailSubject()
        Dim sb1 As New System.Text.StringBuilder
        sb1.Append("Purchase Order ")
        sb1.Append(Me.Purchaseorder_base_info1.PO_Number.ToString())
        sb1.Append(" for ")
        sb1.Append(Me.Purchaseorder_base_info1.Issue_To_Vendor_Name.Trim)
        sb1.Append(". (See attachment.)")

        Me.txtSubject.Text = sb1.ToString

        sb1 = Nothing
    End Sub
    Sub RetrieveVendorContactEmailList()
        Dim ds As DataSet
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        ds = POHeader.Get_PO_Vendor_EmailDS(1, Int32.Parse(Me.lbl_RefID.Text.Trim), "")

        Dim main_node As Telerik.Web.UI.RadTreeNode = Me.CreateNode("Vendor Contacts", True, "")
        main_node.Value = "node1"
        Me.RadTreeViewContacts.Nodes.Add(main_node)
        main_node.Expanded = True
        main_node.Checkable = False

        Dim gRow As DataRow
        For Each gRow In ds.Tables(0).Rows
            Dim node As Telerik.Web.UI.RadTreeNode = Me.CreateNode(gRow(5).ToString(), True, "")
            node.Value = gRow(6).ToString
            If node.Value.Trim = "" Then
                node.Enabled = False
            Else
                If gRow(7).ToString.Trim = "1" Then 'automatically select default contract from po header...
                    node.Checked = True
                End If
            End If
            main_node.Nodes.Add(node)
        Next

    End Sub
    Sub CheckUncheckAll(ByVal Ck As Boolean)
        Dim node As Telerik.Web.UI.RadTreeNode

        For Each node In Me.RadTreeViewContacts.Nodes(0).Nodes
            If Ck = True Then
                If node.Enabled = True Then
                    node.Checked = True
                End If
            Else
                node.Checked = False
            End If
        Next

    End Sub
    Sub AddCustomEmail()
        Dim main_node As Telerik.Web.UI.RadTreeNode

        main_node = Me.RadTreeViewContacts.Nodes.FindNodeByValue("node1")

        Dim txtbox As System.Web.UI.WebControls.TextBox
        txtbox = CType(Me.RadToolbarPOAlert.FindItemByValue("RadToolBarButtonEmail").FindControl("txtRTBEmail"), TextBox)

        Dim node As Telerik.Web.UI.RadTreeNode = Me.CreateNode(txtbox.Text.Trim, True, "")
        node.Value = txtbox.Text.Trim
        node.ImageUrl = "images/unread.gif"
        node.Checked = True

        main_node.Nodes.Add(node)

        Me.lbl_msg.Text = ""

    End Sub
    Private Function CreateNode(ByVal NodeText As String, ByVal expanded As Boolean, ByVal id As String) As Telerik.Web.UI.RadTreeNode
        Dim node As New Telerik.Web.UI.RadTreeNode(NodeText.Trim)
        node.Expanded = expanded
        Return node
    End Function

    Sub RemoveCustomEmail()
        Dim node As Telerik.Web.UI.RadTreeNode
        node = Me.RadTreeViewContacts.SelectedNode
        If Not node Is Nothing Then
            node.Remove()
        End If
    End Sub

    Protected Sub but_SendYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but_SendYes.Click
        Dim sbBody As New System.Text.StringBuilder
        Dim sFileName As String

        Me.lbl_msg.Text = ""

        If Me.RadTreeViewContacts.CheckedNodes.Count = 0 Then
            Me.lbl_msg.Text = "At least one Email Recipient must be checked before sending."
            Exit Sub
        End If

        sFileName = Me.OutputReportFile

        If sFileName.Trim <> "" Then
            ProcessEmails(sFileName.Trim)
        End If

    End Sub
    Sub ProcessEmails(ByVal sFileName As String)
        Dim oWebServices As cWebServices = New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
        Dim sbBody As New System.Text.StringBuilder
        Dim Sent_Count As Integer = 0
        Dim node As Telerik.Web.UI.RadTreeNode
        Dim send_result As Boolean

        Me.lbl_msg.Text = ""

        sbBody.Append("Purchase Order ")
        sbBody.Append(Me.Purchaseorder_base_info1.PO_Number.ToString())
        sbBody.Append(" attached in ")
        sbBody.Append(Me.dl_Template.SelectedItem.Text)
        sbBody.Append(" format.")
        sbBody.Append(vbCrLf)

        sbBody.Append(Me.Radeditor1.Html.Trim)

        Try
            For Each node In Me.RadTreeViewContacts.CheckedNodes
                send_result = oWebServices.SendEmail(sFileName.Trim, node.Value.Trim, Me.txtSubject.Text.Trim, sbBody.ToString.Trim)
                If send_result = True Then
                    Sent_Count = Sent_Count + 1
                Else
                    'Me.lbl_msg.Text = oWebServices.getErrMsg()
                    'Me.ShowMessage(oWebServices.getErrMsg)
                End If
            Next
            lbl_msg.Text = "Email Sent."
            Me.but_SendYes.Text = "Send Again"
            Me.CheckForAsyncMessage()
        Catch ex As Exception
            lbl_msg.Text = ex.Message.ToString
        End Try

        sbBody = Nothing

        Try
            My.Computer.FileSystem.DeleteFile(sFileName.Trim)
        Catch ex As Exception
            'do nothing
        End Try
        Try
            Kill(sFileName.Trim)
        Catch ex As Exception
            'do nothing
        End Try

    End Sub
    Function OutputReportFile() As String
        Dim sb1 As New System.Text.StringBuilder 'build filename
        Dim sbTime As New System.Text.StringBuilder 'unique timestamp for filename..
        Dim sbReportName As New System.Text.StringBuilder

        sbTime.Append("__")
        sbTime.Append(Now.Year.ToString())
        sbTime.Append(Now.Month.ToString())
        sbTime.Append(Now.Day.ToString())
        sbTime.Append(Now.Hour.ToString())
        sbTime.Append(Now.Minute.ToString())
        sbTime.Append(Now.Millisecond.ToString())

        sb1.Append(Request.PhysicalApplicationPath.Trim)
        sb1.Append("TEMP\")

        sb1.Append("Purchase_Order_")
        'sb1.Append(Me.Purchaseorder_base_info1.Issue_To_Vendor_Code.Trim)
        'sb1.Append("__")
        sb1.Append(Me.Purchaseorder_base_info1.PO_Number.ToString.PadLeft(8, "0"))
        sb1.Append("_")
        sb1.Append(sbTime.ToString())

        Select Case Me.Reporttype1.strReportSelect
            Case 1
                sb1.Append(".PDF")
            Case 2
                sb1.Append(".XLS")
            Case 4
                sb1.Append(".TXT")
            Case 5
                sb1.Append(".TIFF")
        End Select

        sbReportName.Append("purchaseorder")
        sbReportName.Append(Me.dl_Template.SelectedValue.Trim)

        Dim rpt As New popReportViewer

        Try
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), Me.Purchaseorder_base_info1.PO_Number.ToString(), "", "", "", "", Int32.Parse(Me.Reporttype1.strReportSelect), "")
            Return sb1.ToString
        Catch ex As Exception
            Me.lbl_msg.Text = ex.Message.Trim
            Return ""
        End Try

    End Function

    Private Sub RadToolbarPOAlert_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarPOAlert.ButtonClick
        Select Case e.Item.Value
            Case "Add_Email"
                Dim txtbox As System.Web.UI.WebControls.TextBox
                txtbox = CType(Me.RadToolbarPOAlert.FindItemByValue("RadToolBarButtonEmail").FindControl("txtRTBEmail"), TextBox)

                If txtbox.Text.Trim = "" Then
                    txtbox.Focus()
                    Me.lbl_msg.Text = "Enter an email address, then click Add Email."
                    Exit Sub
                End If

                Me.AddCustomEmail()
                txtbox.Text = ""
            Case "Delete_Email"
                Me.RemoveCustomEmail()
            Case "Check_All"
                Me.CheckUncheckAll(True) 'check all
            Case "UnCheck_All"
                Me.CheckUncheckAll(False) 'uncheck all
        End Select
    End Sub

    Protected Sub dl_LocationID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dl_LocationID.SelectedIndexChanged

    End Sub

    Private Sub btnRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecipients.Click
        Dim strURL As String = "LookUp_EmailRecipients.aspx?fna=0&opener=" & Me.PageFilename()
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=900,height=500,scrollbars=no,resizable=no,menubar=no,maximazable=no')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'Page.RegisterStartupScript("newpage", strBuilder.ToString())
        Me.OpenLookUp(strURL)
    End Sub

    Private Sub btnGroups_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGroups.Click

    End Sub

End Class
