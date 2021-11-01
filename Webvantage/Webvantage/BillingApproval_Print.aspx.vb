Partial Public Class BillingApproval_Print
    Inherits Webvantage.BaseChildPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Print&nbsp;Billing Approval"

        If Not Me.IsPostBack Then
            FillLocationDropDown()
            FillTemplateDropDown()
            Me.rbCDPAddress.SelectedIndex = 0
            If Not Request.Cookies("BAPrintReportTitle") Is Nothing Then
                If Request.Cookies("BAPrintReportTitle")("Title") <> "" Then
                    Me.txtReportTitle.Text = Request.Cookies("BAPrintReportTitle")("Title")
                Else
                    Me.txtReportTitle.Text = "Billing Approval Report"
                End If
            Else
                Me.txtReportTitle.Text = "Billing Approval Report"
            End If
        Else

        End If
    End Sub

    Private Sub RadToolbarBillingApprovalPrint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApprovalPrint.ButtonClick
        Select Case e.Item.Value
            Case "Print"
                Try
                    Dim i As Integer
                    Dim countDiv As Integer = 0
                    Dim countPrd As Integer = 0
                    Dim div As String = ""
                    Dim prd As String = ""
                    Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim dsApproval As New DataSet
                    Dim dtApprovalHeader As New DataTable
                    Dim addressOption As String
                    dsApproval = b.GetApprovalDetails(CInt(Request.QueryString("AID")))
                    dtApprovalHeader = dsApproval.Tables(0)

                    If dsApproval.Tables(1).Rows.Count > 0 Then
                        For i = 0 To dsApproval.Tables(1).Rows.Count - 1
                            If div <> dsApproval.Tables(1).Rows(i)("DIV_CODE") Then
                                countDiv += 1
                                div = dsApproval.Tables(1).Rows(i)("DIV_CODE")
                            End If
                            If prd <> dsApproval.Tables(1).Rows(i)("PRD_CODE") Then
                                countPrd += 1
                                prd = dsApproval.Tables(1).Rows(i)("PRD_CODE")
                            End If
                        Next
                    End If

                    Session("BAClientPrint") = dtApprovalHeader.Rows(0)("CL_CODE")
                    Session("BAClientNamePrint") = dtApprovalHeader.Rows(0)("CL_NAME")
                    If Me.rbCDPAddress.SelectedValue = "Contact" Then
                        addressOption = Me.rbCDPAddress.SelectedValue
                    ElseIf countDiv > 1 Then
                        addressOption = "Client"
                    ElseIf countPrd > 1 Then
                        addressOption = "Division"
                        Session("BADivisionPrint") = dsApproval.Tables(1).Rows(0)("DIV_CODE")
                    Else
                        addressOption = Me.rbCDPAddress.SelectedValue
                        Session("BADivisionPrint") = dsApproval.Tables(1).Rows(0)("DIV_CODE")
                        Session("BAProductPrint") = dsApproval.Tables(1).Rows(0)("PRD_CODE")
                    End If

                    Dim strURL As New System.Text.StringBuilder
                    strURL.Append("popReportViewer.aspx?UserID=")
                    strURL.Append(CStr(Session("UserCode")))
                    strURL.Append("&aid=")
                    strURL.Append(Request.QueryString("AID"))
                    strURL.Append("&Type=1")
                    'strURL.Append(Me.txtReportTitle.Text)
                    strURL.Append("&Title=")
                    strURL.Append(Me.txtReportTitle.Text)
                    strURL.Append("&Report=" & Me.dl_Template.SelectedValue)
                    'strURL.Append(Me.dl_Template.SelectedValue.Trim)
                    strURL.Append("&option=")
                    strURL.Append(addressOption)
                    strURL.Append("&PrintDivName=")
                    strURL.Append(Me.cbDivisionName.Checked)
                    strURL.Append("&PrintPrdDesc=")
                    strURL.Append(Me.cbProductName.Checked)
                    strURL.Append("&PrintZero=")
                    strURL.Append(Me.cbPrintZeroLines.Checked)
                    strURL.Append("&cl=")
                    strURL.Append(dtApprovalHeader.Rows(0)("CL_CODE"))

                    Dim ar() As String
                    Try
                        If Me.dl_location.SelectedItem.Text = "[None]" Then
                            Session("BAPrintLocationPath") = ""
                            Session("BAPrintLocationID") = "None"
                        Else
                            ar = dl_location.SelectedValue.ToString.Split("|")
                            Session("BAPrintLocationPath") = ar(1)
                            Session("BAPrintLocationID") = ar(0)
                        End If
                    Catch ex As Exception
                        Session("BAPrintLocationPath") = ""
                    End Try

                    Response.Cookies("BAPrintReportTitle").Expires = Now.AddYears(1)
                    Response.Cookies("BAPrintReportTitle")("Title") = Me.txtReportTitle.Text

                    Response.Redirect(strURL.ToString())
                    strURL = Nothing
                Catch ex As Exception

                End Try
            Case "Back"
                MiscFN.ResponseRedirect("BillingApproval_Approval_Detail.aspx?BAID=" & Request.QueryString("BAID") & "&AID=" & Request.QueryString("AID"), False)
        End Select
    End Sub

    Private Sub FillLocationDropDown()
        Me.dl_location.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.dl_location.DataSource = oReports.GetLocationPO
        Me.dl_location.DataTextField = "ID"
        Me.dl_location.DataValueField = "LOGO_PATH"
        Me.dl_location.DataBind()
        Me.dl_location.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "None"))
    End Sub

    Private Sub FillTemplateDropDown()
        Me.dl_Template.Items.Clear()
        'Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("", 0))
        Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("000 - Default Report", "BillingApprovalReport"))
        Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("001 - Function Heading/Component", "BillingApproval"))
        Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("002 - Component/Function Heading", "BillingApproval2"))
        Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("003 - Job Only", "BillingApprovalJobOnly"))
        Me.dl_Template.Items.Add(New Telerik.Web.UI.RadComboBoxItem("004 - Campaign Component", "BillingApproval4"))
    End Sub
End Class