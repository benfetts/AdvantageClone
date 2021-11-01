Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class BillingApproval_Approval_Detail
    Inherits Webvantage.BaseChildPage

    Private BatchID As Integer = 0
    Private ApprovalID As Integer = 0
    Private IsNew As Boolean = False
    Private DescriptionAsClientName As Boolean = True
    Private DtApprovals As New DataTable
    Private CanDeleteApproval As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApproval)

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridApprovalJobList)
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Schedule,
                                                                   UnityUC.UnityItem.Events,
                                                                   UnityUC.UnityItem.Versions,
                                                                   UnityUC.UnityItem.Specifications,
                                                                   UnityUC.UnityItem.Documents,
                                                                   UnityUC.UnityItem.AddTime,
                                                                   UnityUC.UnityItem.Stopwatch,
                                                                   UnityUC.UnityItem.CreativeBrief}

        'Try
        '    Session("BA_COMPONENT_DT") = Nothing
        'Catch ex As Exception
        'End Try
        Try
            Session("BA_APPROVAL_JC_GO_BACK") = Nothing
        Catch ex As Exception
        End Try
        Try
            Session("BillingApproval_Approval_JobComponent_Nav") = Nothing
        Catch ex As Exception
        End Try

        Try
            ApprovalID = CType(Request.QueryString("AID"), Integer)
        Catch ex As Exception
            ApprovalID = 0
        End Try
        If ApprovalID <= 0 Then
            IsNew = True
        Else
            IsNew = False
        End If

        'approval id getting lost when closing the component page causes a refresh, workaround:
        Try
            If IsNew = True Then
                If Not Session("BillinbApproval_Approval_Detail_New_Approval_Id") Is Nothing AndAlso IsNumeric(Session("BillinbApproval_Approval_Detail_New_Approval_Id")) = True Then
                    IsNew = False
                    ApprovalID = CType(Session("BillinbApproval_Approval_Detail_New_Approval_Id"), Integer)
                End If
            End If
        Catch ex As Exception
        End Try


        Try
            BatchID = CType(Request.QueryString("BAID"), Integer)
        Catch ex As Exception
            BatchID = 0
        End Try
        Me.HfBatchID.Value = BatchID.ToString()

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
            'get page settings
            Dim baD As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            dt = baD.GetPageSetting(cBillingApproval.BA_Page.Billing_Approval_Entry_Edit)
            For i As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i)("AGY_SETTINGS_CODE").ToString()
                    Case "BA_DESC_CL_NAME"
                        Me.DescriptionAsClientName = dt.Rows(i)("AGY_SETTINGS_VALUE")
                    Case "BA_OPT_INFO_SECT"
                        Me.CollapsablePanelOptional.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
                End Select
            Next

            Me.LoadApproval(Me.ApprovalID)
            Me.LoadLookups()
            Me.SetForm()
        Else

        End If

    End Sub

    Private Function ValidateBatchClient(ByVal ClientCode As String) As Boolean
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            Dim dt As New DataTable
            dt = d.GetClientsByBatchID(Me.BatchID)
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "CL_CODE = '" & ClientCode & "'"
            Dim dt1 As New DataTable
            dt1 = dv.ToTable()
            If dt1.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Overloads Function ValidateClientContact(ByVal ClientCode As String, ByVal ContactCode As String) As Integer
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            Dim dt As New DataTable
            dt = d.GetCDP_ClientContact(ClientCode)
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "code2 = '" & ContactCode & "'"
            Dim dt1 As New DataTable
            dt1 = dv.ToTable()
            If dt1.Rows.Count > 0 Then
                Return CType(dt1.Rows(0)("CDP_CONTACT_ID"), Integer)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Overloads Function ValidateClientContact(ByVal ClientCode As String, ByVal ContactCode As String, ByVal ContactDescription As String, ByVal ContactID As Integer) As Integer
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            Dim dt As New DataTable
            dt = d.GetCDP_ClientContact(ClientCode)
            Dim dv As DataView = New DataView(dt)
            If ContactID > 0 Then
                dv.RowFilter = "CDP_CONTACT_ID = " & ContactID.ToString()
            Else 'not sure it ever steps into this
                dv.RowFilter = "description = '" & ContactCode & " - " & ContactDescription & "'"
            End If

            Dim dt1 As New DataTable
            dt1 = dv.ToTable()
            If dt1.Rows.Count > 0 Then
                Return CType(dt1.Rows(0)("CDP_CONTACT_ID"), Integer)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub SetForm()
        If IsNew = True Then
            'Client lookup:
            Dim d As New cDropDowns(Session("ConnString"))
            Dim dt As New DataTable
            dt = d.GetClientsByBatchID(Me.BatchID)
            If dt.Rows.Count = 1 Then 'just set it because there's only one client and no lookup needed
                Try
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        Me.TxtClientCode.Text = dt.Rows(0)("CL_CODE").ToString()
                    Else
                        Me.TxtClientCode.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        Me.TxtClientDescription.Text = dt.Rows(0)("CL_NAME").ToString()
                    Else
                        Me.TxtClientDescription.Text = ""
                    End If
                Catch ex As Exception
                End Try
                Me.TxtClientCode.ReadOnly = True
                Me.HlClient.Attributes.Remove("onclick")
            ElseIf dt.Rows.Count = 0 Then 'no clients for this approval
                Me.LblMSG.Text = "There are no clients available for this batch."
                Me.TxtClientCode.ReadOnly = True
                Me.HlClient.Attributes.Remove("onclick")
            ElseIf dt.Rows.Count > 1 Then 'wire up lookup:
                Try
                    BatchID = CType(Request.QueryString("BAID"), Integer)
                Catch ex As Exception
                    BatchID = 0
                End Try
                Me.HfBatchID.Value = BatchID.ToString()
                Me.TxtClientCode.ReadOnly = False
                Me.HlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=badtl_client&type=badtl_client&client=&BAID=" & BatchID.ToString() & "&division=&product=&job=&cli_desc=" & Me.DescriptionAsClientName & "');return false;")
                'Me.HlClient.Attributes.Add("onclick", "ClearTB('" & Me.TxtClientCode.ClientID & "');ClearTB('" & Me.TxtClientDescription.ClientID & "');FocusTB('" & Me.TxtClientCode.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=badtl_client&type=badtl_client&client=&BAID=" & BatchID.ToString() & "&division=&product=&job=&cli_desc=" & Me.DescriptionAsClientName & "');return false;")
                'Me.TxtClientCode.Attributes.Add("onkeyup", "Javascript:ClearTB('" & Me.TxtClientDescription.ClientID & "');")
            End If
            Try
                If Me.TxtClientDescription.Text.Trim() <> "" Then 'And Me.TxtBA_CL_DESC.Text.Trim() = "" Then
                    Me.TxtBA_CL_DESC.Text = Me.TxtClientDescription.Text
                End If
            Catch ex As Exception
            End Try
            Try
                If MiscFN.ValidDate(Me.RadDatePickerDate) = False Then
                    Me.RadDatePickerDate.SelectedDate = cEmployee.TimeZoneToday
                End If
            Catch ex As Exception

            End Try
        Else 'LOADING AN EXISTING BATCH, CAN'T CHANGE CLIENT!
            Me.TxtClientCode.ReadOnly = True
            Me.HlClient.Attributes.Remove("onclick")
        End If
    End Sub

    Private Sub LoadLookups()
        'Me.HlClientContact.Attributes.Add("onclick", "ClearTB('" & Me.TxtClientContactCode.ClientID & "');ClearTB('" & Me.TxtClientContactDescription.ClientID & "');FocusTB('" & Me.TxtClientContactCode.ClientID & "');window.open('poplookup_contact.aspx?form=ba&control=dummy&type=contacts&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value);return false;")
        'Me.TxtClientContactCode.Attributes.Add("onkeyup", "Javascript:ClearTB('" & Me.TxtClientContactDescription.ClientID & "');")

        Me.HlClientContact.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?form=ba&control=dummy&type=contacts&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value);return false;")

        MiscFN.LimitTextbox(Me.TxtClientPO, 40)

    End Sub

    Private Sub LoadApproval(ByVal ThisApprovalID As Integer)
        If Me.ApprovalID > 0 Then
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsApproval As New DataSet
            Dim dtApprovalHeader As New DataTable

            dsApproval = b.GetApprovalDetails(ThisApprovalID)
            dtApprovalHeader = dsApproval.Tables(0)

            'Bind header controls:
            If dtApprovalHeader.Rows.Count > 0 Then
                If IsDBNull(dtApprovalHeader.Rows(0)("BA_ID")) = False Then
                    Me.LblApprovalID.Text = dtApprovalHeader.Rows(0)("BA_ID").ToString().PadLeft(6, "0")
                Else
                    Me.LblApprovalID.Text = "[New]"
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("BA_BATCH_ID")) = False Then
                    BatchID = CType(dtApprovalHeader.Rows(0)("BA_BATCH_ID"), Integer)
                    Me.LblBatchID.Text = dtApprovalHeader.Rows(0)("BA_BATCH_ID").ToString.PadLeft(6, "0")
                Else
                    BatchID = 0
                    Me.LblBatchID.Text = ""
                End If
                Me.HfBatchID.Value = BatchID.ToString()

                If IsDBNull(dtApprovalHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                    Me.LblBatchDescription.Text = dtApprovalHeader.Rows(0)("BA_BATCH_DESC").ToString()
                Else
                    Me.LblBatchDescription.Text = ""
                End If

                If IsDBNull(dtApprovalHeader.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientCode.Text = dtApprovalHeader.Rows(0)("CL_CODE").ToString()
                Else
                    Me.TxtClientCode.Text = ""
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientDescription.Text = dtApprovalHeader.Rows(0)("CL_NAME").ToString()
                Else
                    Me.TxtClientDescription.Text = ""
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("BA_CL_DESC")) = False Then
                    Me.TxtBA_CL_DESC.Text = dtApprovalHeader.Rows(0)("BA_CL_DESC").ToString()
                Else
                    Me.TxtBA_CL_DESC.Text = ""
                End If

                If IsDBNull(dtApprovalHeader.Rows(0)("BA_CL_DATE")) = False Then
                    Me.RadDatePickerDate.SelectedDate = CType(dtApprovalHeader.Rows(0)("BA_CL_DATE"), Date)
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("SENT_DATE")) = False Then
                    Me.RadDatePickerDateSent.SelectedDate = CType(dtApprovalHeader.Rows(0)("SENT_DATE"), Date)
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("APPR_DATE")) = False Then
                    Me.RadDatePickerDateApproved.SelectedDate = CType(dtApprovalHeader.Rows(0)("APPR_DATE"), Date)
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("CLIENT_PO")) = False Then
                    Me.TxtClientPO.Text = dtApprovalHeader.Rows(0)("CLIENT_PO").ToString()
                Else
                    Me.TxtClientPO.Text = ""
                End If

                If IsDBNull(dtApprovalHeader.Rows(0)("CONT_CODE")) = False Then
                    Me.TxtClientContactCode.Text = dtApprovalHeader.Rows(0)("CONT_CODE").ToString()
                Else
                    Me.TxtClientContactCode.Text = ""
                End If
                If IsDBNull(dtApprovalHeader.Rows(0)("CDP_CONTACT_FML_NAME")) = False Then
                    Me.TxtClientContactDescription.Text = dtApprovalHeader.Rows(0)("CDP_CONTACT_FML_NAME").ToString()
                Else
                    Me.TxtClientContactDescription.Text = ""
                End If

                Try
                    If IsDBNull(dtApprovalHeader.Rows(0)("APPROVED")) = False Then
                        Me.CanDeleteApproval = Not CType(dtApprovalHeader.Rows(0)("APPROVED"), Boolean)
                    End If
                Catch ex As Exception
                End Try

                Dim HasApprovals As Boolean = False
                Try
                    Dim i As Integer = 0
                    Try
                        If IsDBNull(dtApprovalHeader.Rows(0)("HAS_APPROVED")) = False Then
                            i = CType(dtApprovalHeader.Rows(0)("HAS_APPROVED"), Integer)
                        End If
                        If i > 0 Then
                            HasApprovals = True
                        End If
                    Catch ex As Exception
                        i = 0
                    End Try
                Catch ex As Exception
                End Try

                If Me.CanDeleteApproval = False Or HasApprovals = True Then
                    CType(Me.RadToolbarBillingApproval.FindItemByValue("Delete"), Telerik.Web.UI.RadToolBarButton).Enabled = False
                End If

            End If

            'for grid data:
            'Me.DtApprovals = dsApproval.Tables(1)
            'Me.BuildJobCompString(dsApproval.Tables(1))

        End If

    End Sub

    Private Sub RadGridApprovalJobList_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridApprovalJobList.DataBound
        ''If Me.CanDeleteApproval = False Then
        ''    MiscFN.SetToolbarButtonEnabled(Me.RadToolbarBillingApproval, 2, False) 'delete button
        ''End If
    End Sub

    Private Sub RadGridApprovalJobList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridApprovalJobList.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Select Case e.CommandName
            Case "ViewJobComponent"
                Dim ThisJob As Integer = 0
                Dim ThisComponent As Integer = 0
                Dim ThisIsLocked As Boolean = False
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridApprovalJobList.Items(index), Telerik.Web.UI.GridDataItem)

                Try
                    ThisJob = CurrentGridRow.GetDataKeyValue("JOB_NUMBER")
                Catch ex As Exception
                    ThisJob = 0
                End Try
                Try
                    ThisComponent = CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
                Catch ex As Exception
                    ThisComponent = 0
                End Try
                Try
                    ThisIsLocked = CType(CType(CurrentGridRow.FindControl("HfLocked"), HiddenField).Value, Boolean)
                Catch ex As Exception
                    ThisIsLocked = False
                End Try
                Dim status As String = ""
                Try
                    If CurrentGridRow.GetDataKeyValue("APPROVAL_STATUS").ToString() = "Pending" Then
                        status = "p"
                    Else
                        status = "a"
                    End If
                Catch ex As Exception

                End Try
                If Me.BatchID > 0 And Me.ApprovalID > 0 And ThisJob > 0 And ThisComponent > 0 Then
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    With qs
                        .Page = "BillingApproval_Approval_JobComponent.aspx"
                        .BillingApprovalBatchID = Me.BatchID
                        .BillingApprovalId = Me.ApprovalID.ToString()
                        .JobNumber = ThisJob
                        .JobComponentNumber = ThisComponent
                        .Add("L", ThisIsLocked.ToString())
                        .Add("status", status)
                    End With
                    Me.OpenWindow("", qs.ToString(True))
                End If

        End Select

    End Sub


    Private Sub RadGridApprovalJobList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridApprovalJobList.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then

            Try

                If CType(e.Item.DataItem("IS_LOCKED"), Boolean) = True Then

                    Dim LockedImage As WebControls.Image = CType(e.Item.FindControl("ImageLocked"), WebControls.Image)
                    Dim str As String = e.Item.DataItem("ADJUSTED_STATUS").ToString()

                    str = str.ToLower()

                    With LockedImage

                        .ToolTip = "This job component is " & str & "."
                        .AlternateText = "This job component is " & str & "."
                    End With

                Else

                    Dim LockedDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivLocked")
                    AdvantageFramework.Web.Presentation.Controls.DivHide(LockedDiv)

                End If

            Catch ex As Exception

            End Try

            If CanDeleteApproval = True Then
                Try
                    If e.Item.DataItem("BILL_APPR_ENTRY_EDIT_GROUPING") = "Approved" Then
                        CanDeleteApproval = False
                    End If
                Catch ex As Exception
                End Try

            End If

        End If

    End Sub

    Private Sub RadGridApprovalJobList_ItemInserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridInsertedEventArgs) Handles RadGridApprovalJobList.ItemInserted

    End Sub

    Private Sub RadGridApprovalJobList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridApprovalJobList.NeedDataSource
        Try

            Dim DvData As DataView

            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsApproval As New DataSet
            Dim dtApprovalHeader As New DataTable

            dsApproval = b.GetApprovalDetails(Me.ApprovalID)

            Me.DtApprovals = dsApproval.Tables(1)
            Me.BuildJobCompString(dsApproval.Tables(1))

            If Not Me.DtApprovals Is Nothing Then
                If Me.CanDeleteApproval = True Then
                    DvData = Me.DtApprovals.DefaultView
                Else
                    Dim dv As DataView
                    dv = Me.DtApprovals.DefaultView
                    dv.RowFilter = "BILL_APPR_ENTRY_EDIT_GROUPING = 'Approved'"
                    DvData = dv
                End If

                ''search
                If Me.TxtFilterJobs.Text <> "" Then

                    Dim dv As DataView

                    dv = DvData

                    Dim s As String = Me.TxtFilterJobs.Text.Trim()
                    s = s.Replace(" ", "")

                    If IsNumeric(s) = True Then 'straight filter
                        dv.RowFilter = "(BILL_APPR_ENTRY_EDIT_GROUPING = 'Approved') OR (JOB_NUMBER = " & s & ")"
                    ElseIf s.IndexOf(">") > -1 Then 'greater than
                        Dim g As String = s.Replace(">", "")
                        If IsNumeric(g) = True Then
                            dv.RowFilter = "(BILL_APPR_ENTRY_EDIT_GROUPING = 'Approved') OR (JOB_NUMBER >= " & g & ")"
                        End If
                    ElseIf s.IndexOf("<") > -1 Then 'less than
                        Dim g As String = s.Replace("<", "")
                        If IsNumeric(g) = True Then
                            dv.RowFilter = "(BILL_APPR_ENTRY_EDIT_GROUPING = 'Approved') OR (JOB_NUMBER <= " & g & ")"
                        End If
                    ElseIf s.IndexOf("-") > -1 Then 'between
                        Dim ar() As String
                        ar = s.Split("-")
                        If ar.Length = 2 Then
                            If IsNumeric(ar(0)) = True And IsNumeric(ar(1)) = True Then
                                Dim smaller As Integer = 0
                                Dim larger As Integer = 0
                                If CType(ar(0), Integer) < CType(ar(1), Integer) Then
                                    smaller = CType(ar(0), Integer)
                                    larger = CType(ar(1), Integer)
                                Else
                                    smaller = CType(ar(1), Integer)
                                    larger = CType(ar(0), Integer)
                                End If
                                dv.RowFilter = "(BILL_APPR_ENTRY_EDIT_GROUPING = 'Approved') OR ((JOB_NUMBER >=" & smaller & ") AND (JOB_NUMBER <= " & larger & "))"
                            End If
                        End If

                    End If
                    DvData = dv
                    Me.BuildJobCompString(dv.ToTable())
                End If
            End If

            If Not DvData Is Nothing Then
                Me.RadGridApprovalJobList.DataSource = DvData
            End If

            'group:
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("BILL_APPR_ENTRY_EDIT_GROUPING Status Group By BILL_APPR_ENTRY_EDIT_GROUPING")
            With Me.RadGridApprovalJobList
                .MasterTableView.GroupByExpressions.Clear()
                .MasterTableView.GroupByExpressions.Add(GrpExpr)
                .MasterTableView.GroupsDefaultExpanded = True
            End With

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImgBtnFilterJobs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnFilterJobs.Click
        Me.RadGridApprovalJobList.Rebind()
    End Sub

    Private Sub BuildJobCompString(ByVal dt As DataTable)
        Try
            Dim SbJobList As New System.Text.StringBuilder
            If dt.Rows.Count > 0 Then
                For x As Integer = 0 To dt.Rows.Count - 1
                    With SbJobList
                        .Append(dt.Rows(x)("JOB_NUMBER").ToString())
                        .Append(",")
                        .Append(dt.Rows(x)("JOB_COMPONENT_NBR").ToString())
                        .Append("|")
                    End With
                Next
            End If
            Session("BA_APPROVAL_DETAIL_JOB_LIST") = MiscFN.RemoveTrailingDelimiter(SbJobList.ToString(), "|")
        Catch ex As Exception
            Session("BA_APPROVAL_DETAIL_JOB_LIST") = ""
        End Try
    End Sub

    Private Sub BillingApproval_Approval_Detail_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Try
                ApprovalID = CType(Request.QueryString("AID"), Integer)
            Catch ex As Exception
                ApprovalID = 0
            End Try
            If ApprovalID = -1 Or ApprovalID = 0 Then
                CType(Me.RadToolbarBillingApproval.FindItemByValue("Delete"), Telerik.Web.UI.RadToolBarButton).Enabled = False
                CType(Me.RadToolbarBillingApproval.FindItemByValue("Print"), Telerik.Web.UI.RadToolBarButton).Enabled = False

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadToolbarBillingApproval_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApproval.ButtonClick
        Select Case e.Item.Value
            Case "Delete"

                If Me.ApprovalID > 0 And Me.BatchID > 0 Then

                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim str As String = ba.ApprovalDelete(Me.BatchID, Me.ApprovalID)

                    If str <> "" Then

                        Session("BA_APPROVAL_GO_BACK") = "0"
                        Me.LblMSG.Text = str

                    Else

                        Session("BA_APPROVAL_GO_BACK") = "1"
                        Me.CloseThisWindowAndRefreshCaller("BillingApproval_Approval.aspx?BAID=" & Me.BatchID.ToString(), True)

                    End If
                End If

            Case "Save"
                'some basic validation here:
                If Me.TxtClientCode.Text = "" Then
                    Me.LblMSG.Text = "Client code is required"
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDate) = False Then
                    Me.ShowMessage("Date invalid")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDateSent, True) = False Then
                    Me.ShowMessage("Date Sent invalid")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDateApproved, True) = False Then
                    Me.ShowMessage("Date Approved invalid")
                    Exit Sub
                End If
                'db validation:
                'need for client code
                If Me.TxtClientCode.ReadOnly = False Then
                    If Me.ValidateBatchClient(Me.TxtClientCode.Text) = False Then
                        Me.LblMSG.Text = "Invalid client."
                        Exit Sub
                    End If
                End If

                'validate contact code
                If String.IsNullOrWhiteSpace(Me.TxtClientContactCode.Text.Trim()) = False Then 'user typed in a code
                    Dim z As Integer = Me.ValidateClientContact(Me.TxtClientCode.Text, Me.TxtClientContactCode.Text)
                    If z = 0 Then
                        Me.LblMSG.Text = "Invalid contact code."
                        Exit Sub
                    Else
                        Me.HfContactCodeID.Value = z.ToString()
                    End If
                Else
                    Me.HfContactCodeID.Value = "0"
                End If

                Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                Dim DateApproval As String = ""
                Dim DateSent As String = ""
                Dim DateApproved As String
                Try
                    DateApproval = Me.RadDatePickerDate.SelectedDate
                Catch ex As Exception
                    DateApproval = ""
                End Try
                Try
                    DateSent = Me.RadDatePickerDateSent.SelectedDate
                Catch ex As Exception
                    DateSent = ""
                End Try
                Try
                    DateApproved = Me.RadDatePickerDateApproved.SelectedDate
                Catch ex As Exception
                    DateApproved = ""
                End Try
                If Me.IsNew = True Then
                    Dim i As Integer = 0
                    i = ba.ApprovalAddNew(Me.BatchID, Session("UserCode"), Me.TxtClientCode.Text, Me.TxtBA_CL_DESC.Text, DateApproval, DateSent, DateApproved, Me.TxtClientPO.Text, CType(Me.HfContactCodeID.Value, Integer))
                    If i > 0 Then
                        Session("BillinbApproval_Approval_Detail_New_Approval_Id") = i
                        'redirect with both batchid and approvalid:
                        MiscFN.ResponseRedirect("BillingApproval_Approval_Detail.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" & i.ToString(), True)
                        Exit Sub
                    End If
                Else
                    Session("BillinbApproval_Approval_Detail_New_Approval_Id") = Nothing
                    Dim str As String = ba.ApprovalUpdate(Me.ApprovalID, Me.TxtBA_CL_DESC.Text, DateApproval, DateSent, DateApproved, Me.TxtClientPO.Text, CType(Me.HfContactCodeID.Value, Integer))
                    If str <> "" Then
                        Me.LblMSG.Text = str
                    Else
                        Me.RadGridApprovalJobList.Rebind()
                    End If
                End If

                Me.LoadApproval(Me.ApprovalID)

            Case "Finish"

            Case "Alert"
                If IsNumeric(Me.LblBatchID.Text) = True Then
                    Dim strURL As String = "BillingApproval_Alert.aspx?P=2&BAID=" & CType(Me.LblBatchID.Text, Integer).ToString()
                    Me.OpenWindow("Alert", strURL)
                End If
            Case "Print"
                Me.OpenWindow("Print", "BillingApproval_Print.aspx?AID=" & Me.ApprovalID & "&BAID=" & Me.HfBatchID.Value.ToString())

        End Select

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridApprovalJobList.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridApprovalJobList.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub
End Class
