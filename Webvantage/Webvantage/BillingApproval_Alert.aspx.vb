Imports Webvantage.cGlobals
Imports System.IO

Partial Public Class BillingApproval_Alert
    Inherits Webvantage.BaseChildPage

    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    Private BatchID As Integer = 0
    Private FromPage As Integer = 0

    'From Batch Variables:
    Dim Batch_BatchID As String = ""
    Dim Batch_BatchDesc As String = ""
    Dim Batch_Date As String = ""
    Dim Batch_AssignedEmp As String = ""
    Dim Batch_DateCutoff As String = ""
    Dim Batch_PeriodCutoff As String = ""
    Dim Batch_AEList As String = ""
    Dim Batch_SelectionList As String = ""
    Dim Batch_IncludesNonBillableRecs As String = ""
    Dim Batch_IncludesFeeTime As String = ""

    Dim Batch_Subject As String = ""
    Dim Approval_Subject As String = ""

    Private Property EmailBody() As String
        Get
            If ViewState("EmailBody") Is Nothing Then
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            ViewState("EmailBody") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        Me.SetQSVars()

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
            'Set dropdownlist:
            'Me.BindEmailGroups()
            If FromPage = 1 Then 'From Batch
                Me.LoadBatch(True, Me.BatchID, Batch_BatchID, Batch_BatchDesc, Batch_Date, Batch_AssignedEmp, Batch_DateCutoff, Batch_PeriodCutoff, Batch_AEList, Batch_SelectionList, Batch_IncludesNonBillableRecs, Batch_IncludesFeeTime, Batch_Subject)
                Me.TxtSubject.Text = Me.Batch_Subject
                'default to emp:
                Me.RadioNotifyEmployee.Checked = True
                Me.AutoCompleteRecipients.Clear()
                ' Me.DropEmailGroups.SelectedIndex = 0
                Me.AddRecipientsButton.Enabled = False
                Me.AutoCompleteRecipients.AddEntries(Me.HfEmpCode.Value)

            ElseIf FromPage = 2 Then 'From Approval
                Me.LoadApproval(True, Me.BatchID, Batch_BatchID, Batch_BatchDesc, Batch_Date, Batch_AssignedEmp, Me.Approval_Subject)
                Me.TxtSubject.Text = Me.Approval_Subject
                'default to create user:
                Me.RadioNotifyBatchCreator.Checked = True
                Me.AutoCompleteRecipients.Clear()
                'Me.DropEmailGroups.SelectedIndex = 0
                Me.AddRecipientsButton.Enabled = False
                Me.AutoCompleteRecipients.AddEntries(Me.HfCreateUserEmpCode.Value)
            End If

        End If

    End Sub

    Private Sub SetQSVars()
        Try
            If Not Request.QueryString("BAID") = Nothing Then
                BatchID = CType(Request.QueryString("BAID"), Integer)
            Else
                BatchID = 0
            End If
        Catch ex As Exception
            BatchID = 0
        End Try

        'From Batch = 1
        'From Approval = 2
        Try
            If Not Request.QueryString("P") = Nothing Then
                FromPage = CType(Request.QueryString("P"), Integer)
            Else
                FromPage = 0
            End If
        Catch ex As Exception
            FromPage = 0
        End Try
    End Sub

    Private Sub AddRecipientsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddRecipientsButton.Click

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.Page = "LookUp_Recipients.aspx"
        qs.Add("uac", "1")

        Me.OpenLookUpRecipients(qs.ToString(True))

    End Sub

    Public Function GeneralInfoTable() As String
        Dim a As New Alert()
        Return a.GeneralInfoNoAlert(Session("UserCode"), Me.RblPriority.SelectedValue)
    End Function

    Private Function LoadBatch(ByVal ForLoad As Boolean, ByVal iBatchID As Integer, ByRef RBatchID As String, ByRef RBatchDesc As String, ByRef RBatchDate As String, ByRef RBatchAssignedEmp As String, _
                            ByRef RDateCutoff As String, ByRef RPeriodCutoff As String, ByRef RAEList As String, ByRef RSelectionList As String, ByRef RIncludesNonBillableRecs As String, _
                            ByRef RIncludesFeeTime As String, ByRef StrSubject As String) As String
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dsBatchDetails As New DataSet
        Dim dtBatchHeader As New DataTable
        Dim dtBatchAEs As New DataTable
        Dim dtBatchPMs As New DataTable
        Dim dtBatchCDPC As New DataTable
        Dim LoadLevel As String = "CDPC"
        Dim EmpFMLName As String = ""
        Me.GeneralInfoTable()

        dsBatchDetails = b.GetBatchDetails(iBatchID)
        dtBatchHeader = dsBatchDetails.Tables(0)
        dtBatchAEs = dsBatchDetails.Tables(1)
        dtBatchPMs = dsBatchDetails.Tables(2)
        dtBatchCDPC = dsBatchDetails.Tables(3)

        If dtBatchHeader.Rows.Count > 0 Then
            If IsDBNull(dtBatchHeader.Rows(0)("LOAD_LEVEL")) = False Then
                LoadLevel = dtBatchHeader.Rows(0)("LOAD_LEVEL")
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_ID")) = False Then
                RBatchID = dtBatchHeader.Rows(0)("BA_BATCH_ID").ToString().PadLeft(6, "0")
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                RBatchDesc = dtBatchHeader.Rows(0)("BA_BATCH_DESC").ToString()
            Else
                RBatchDesc = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("BATCH_DATE")) = False Then
                RBatchDate = cGlobals.wvCDate(dtBatchHeader.Rows(0)("BATCH_DATE")).ToShortDateString()
            Else
                RBatchDate = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_CODE")) = False Then
                RBatchAssignedEmp = dtBatchHeader.Rows(0)("EMP_CODE").ToString()
            Else
                RBatchAssignedEmp = ""
            End If
            Me.HfEmpCode.Value = RBatchAssignedEmp
            If IsDBNull(dtBatchHeader.Rows(0)("DATE_CUTOFF")) = False Then
                RDateCutoff = cGlobals.wvCDate(dtBatchHeader.Rows(0)("DATE_CUTOFF")).ToShortDateString()
            Else
                RDateCutoff = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("PERIOD_CUTOFF")) = False Then
                RPeriodCutoff = dtBatchHeader.Rows(0)("PERIOD_CUTOFF").ToString()
            Else
                RPeriodCutoff = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_FML_NAME")) = False Then
                RBatchAssignedEmp &= " - " & dtBatchHeader.Rows(0)("EMP_FML_NAME").ToString()
                EmpFMLName = dtBatchHeader.Rows(0)("EMP_FML_NAME").ToString()
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_NB")) = False Then
                If CType(dtBatchHeader.Rows(0)("INCL_NB"), Boolean) = True Then
                    RIncludesNonBillableRecs = "Yes"
                Else
                    RIncludesNonBillableRecs = "No"
                End If
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_FEE")) = False Then
                If CType(dtBatchHeader.Rows(0)("INCL_FEE"), Boolean) = True Then
                    RIncludesFeeTime = "Yes"
                Else
                    RIncludesFeeTime = "No"
                End If
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("CREATE_USER_EMP_CODE")) = False Then
                Me.HfCreateUserEmpCode.Value = dtBatchHeader.Rows(0)("CREATE_USER_EMP_CODE").ToString()
            Else
                Me.HfCreateUserEmpCode.Value = ""
            End If
        End If

        StrSubject = "Billing Approval Batch " & RBatchID & " - " & RBatchDesc & " - " & RBatchDate & " has been created"
        If ForLoad = True Then
            Return ""
            Exit Function
        End If


        'AE List
        If dtBatchAEs.Rows.Count > 0 Then
            Dim sbAEs As New System.Text.StringBuilder
            For i As Integer = 0 To dtBatchAEs.Rows.Count - 1
                With sbAEs
                    .Append(dtBatchAEs.Rows(i)("SELECTED_VALUES").ToString())
                    .Append(", ")
                End With
            Next
            RAEList = sbAEs.ToString()
            RAEList = RAEList.TrimEnd()
            RAEList = MiscFN.RemoveTrailingDelimiter(RAEList, ",")
        Else
            RAEList = "[None]"
        End If

        'Selection List
        Dim str As String = ""
        If dtBatchCDPC.Rows.Count > 0 Then
            For j As Integer = 0 To dtBatchCDPC.Rows.Count - 1
                If IsDBNull(dtBatchCDPC.Rows(j)("ALERT_DISPLAY")) = False Then
                    str &= "&nbsp;&nbsp;&nbsp;" & dtBatchCDPC.Rows(j)("ALERT_DISPLAY").ToString() & "<br />"
                End If
            Next
            str = str.Replace("CDPC", "[All]")
            RSelectionList = str.Replace(":", "/")
        Else
            RSelectionList = "[None]"
        End If

        Dim MyEmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
        With MyEmailBody
            If Me.RadEditorBody.Html <> "" Then
                .AddBlankRow()
                .AddCustomRow(Me.RadEditorBody.Html)
            End If

            .AddCustomRow(Me.GeneralInfoTable)

            .AddHeaderRow("Billing Approval Batch Created")
            .AddKeyValueRow("Batch ID", RBatchID)
            .AddKeyValueRow("Description", RBatchDesc)
            .AddKeyValueRow("Date", RBatchDate)
            .AddKeyValueRow("Assigned Employee", RBatchAssignedEmp)
            .AddKeyValueRow("Date Cutoff", RDateCutoff)
            .AddKeyValueRow("Period Cutoff", RPeriodCutoff)
            .AddKeyValueRow("Account Executives", RAEList)
            .AddKeyValueRow("Client/Division/Products/Campaigns", RSelectionList)
            .AddKeyValueRow("Includes Non Billable Records", RIncludesNonBillableRecs)
            .AddKeyValueRow("Includes Fee Time", RIncludesFeeTime)

            .Finish()
        End With

        Return MyEmailBody.ToString()
    End Function

    Private Function LoadApproval(ByVal ForLoad As Boolean, ByVal iBatchID As Integer, ByRef RBatchID As String, ByRef RBatchDesc As String, ByRef RBatchDate As String, _
                            ByRef RBatchAssignedEmp As String, ByRef StrSubject As String) As String
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dsBatchDetails As New DataSet
        Dim dtBatchHeader As New DataTable
        Dim dtApprovals As New DataTable
        Dim BoolAlternate As Boolean = False
        Dim AltColor As String = ""
        Dim EmpFMLName As String = ""

        dsBatchDetails = b.GetBatchApprovalsList(iBatchID)
        dtBatchHeader = dsBatchDetails.Tables(0)
        dtApprovals = dsBatchDetails.Tables(1)

        If dtBatchHeader.Rows.Count > 0 Then
            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_ID")) = False Then
                RBatchID = dtBatchHeader.Rows(0)("BA_BATCH_ID").ToString().PadLeft(6, "0")
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                RBatchDesc = dtBatchHeader.Rows(0)("BA_BATCH_DESC").ToString()
            Else
                RBatchDesc = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("BATCH_DATE")) = False Then
                RBatchDate = cGlobals.wvCDate(dtBatchHeader.Rows(0)("BATCH_DATE")).ToShortDateString()
            Else
                RBatchDate = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_CODE")) = False Then
                RBatchAssignedEmp = dtBatchHeader.Rows(0)("EMP_CODE").ToString()
            Else
                RBatchAssignedEmp = ""
            End If
            Me.HfEmpCode.Value = RBatchAssignedEmp
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_FML_NAME")) = False Then
                RBatchAssignedEmp &= " - " & dtBatchHeader.Rows(0)("EMP_FML_NAME").ToString()
                EmpFMLName = dtBatchHeader.Rows(0)("EMP_FML_NAME").ToString()
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("CREATE_USER_EMP_CODE")) = False Then
                Me.HfCreateUserEmpCode.Value = dtBatchHeader.Rows(0)("CREATE_USER_EMP_CODE").ToString()
            Else
                Me.HfCreateUserEmpCode.Value = ""
            End If
        End If

        StrSubject = "Billing Approval Batch " & RBatchID & " - " & RBatchDesc & " - " & RBatchDate & " has been approved"

        If ForLoad = True Then 'don't need the rest
            Return ""
            Exit Function
        End If

        Dim MyEmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
        With MyEmailBody
            If Me.RadEditorBody.Html <> "" Then
                .AddBlankRow()
                .AddCustomRow(Me.RadEditorBody.Html)
            End If

            .AddCustomRow(Me.GeneralInfoTable)
            .AddHeaderRow("Billing Approval Batch Approved")
            .AddKeyValueRow("Batch ID", RBatchID)
            .AddKeyValueRow("Description", RBatchDesc)
            .AddKeyValueRow("Date", RBatchDate)
            .AddKeyValueRow("Assigned Employee", RBatchAssignedEmp)

            .AddHeaderRow("Billing Approval Records Included")

            Dim sb As New System.Text.StringBuilder
            With sb
                If dtApprovals.Rows.Count > 0 Then
                    .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""" & AdvantageFramework.Email.BodyBackgroundColor & """>")
                    .Append("  <tr>")
                    .Append("    <td align=""left"" valign=""middle"" width=""123""><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Approval ID</font></td>")
                    .Append("    <td align=""left"" valign=""middle"" width=""281""><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Client></font></td>")
                    .Append("    <td align=""left"" valign=""middle"" ><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Description</font></td>")
                    .Append("  </tr>")
                    For i As Integer = 0 To dtApprovals.Rows.Count - 1
                        If BoolAlternate = True Then
                            AltColor = " bgcolor=""#FFFFFF"""
                        Else
                            AltColor = " bgcolor=""#DADADA"""
                        End If
                        .Append("  <tr>")
                        If IsDBNull(dtApprovals.Rows(i)("BA_ID")) = False Then
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>" & dtApprovals.Rows(i)("BA_ID").ToString().PadLeft(6, "0") & "</font></td>")
                        Else
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>&nbsp;</font></td>")
                        End If
                        If IsDBNull(dtApprovals.Rows(i)("CLIENT_CODE_NAME")) = False Then
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>" & dtApprovals.Rows(i)("CLIENT_CODE_NAME").ToString() & "</font></td>")
                        Else
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>&nbsp;</font></td>")
                        End If
                        If IsDBNull(dtApprovals.Rows(i)("BA_CL_DESC")) = False Then
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>" & dtApprovals.Rows(i)("BA_CL_DESC").ToString() & "</font></td>")
                        Else
                            .Append("    <td align=""left"" valign=""middle"" " & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """>&nbsp;</font></td>")
                        End If
                        .Append("  </tr>")
                        BoolAlternate = Not BoolAlternate
                    Next
                    .Append("</table>")
                End If
            End With
            .AddCustomRow(sb.ToString())
            .Finish()
        End With

        Return MyEmailBody.ToString()
    End Function

    Private Sub RadioSendToGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioSendToGroup.CheckedChanged
        If Me.RadioSendToGroup.Checked = True Then
            Me.AddRecipientsButton.Enabled = True
            Me.AutoCompleteRecipients.Clear()
        End If
    End Sub

    Private Sub RadioNotifyEmployee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyEmployee.CheckedChanged
        If Me.RadioNotifyEmployee.Checked = True Then
            Me.AutoCompleteRecipients.Clear()
            Me.AddRecipientsButton.Enabled = False
            Me.AutoCompleteRecipients.AddEntries(Me.HfEmpCode.Value)
        End If
    End Sub

    Private Sub RadioNotifyBatchCreator_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyBatchCreator.CheckedChanged
        If Me.RadioNotifyBatchCreator.Checked = True Then
            Me.AutoCompleteRecipients.Clear()
            Me.AddRecipientsButton.Enabled = False
            Me.AutoCompleteRecipients.AddEntries(Me.HfCreateUserEmpCode.Value)
        End If
    End Sub

    Private Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click

        Me.SetQSVars()
        Dim ThisAlertID As Integer = 0
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim WebvantageURL As String = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
        End Using

        Try

            If Me.TxtSubject.Text.Trim() = "" Then

                Me.ShowMessage("Please enter a subject")
                Exit Sub

            End If
        Catch ex As Exception
            Me.ShowMessage("Please enter a subject")
            Exit Sub
        End Try


        'get correct data for body:
        Dim TheBody As String = ""
        If Me.FromPage = 1 Then 'Batch

            TheBody = Me.LoadBatch(False, Me.BatchID, Batch_BatchID, Batch_BatchDesc, Batch_Date, Batch_AssignedEmp, Batch_DateCutoff, Batch_PeriodCutoff, Batch_AEList, Batch_SelectionList, Batch_IncludesNonBillableRecs, Batch_IncludesFeeTime, Batch_Subject)

        ElseIf Me.FromPage = 2 Then 'Approval

            TheBody = Me.LoadApproval(False, Me.BatchID, Batch_BatchID, Batch_BatchDesc, Batch_Date, Batch_AssignedEmp, Me.Approval_Subject)

            If Agency IsNot Nothing Then

                WebvantageURL = Agency.WebvantageURL

                If Not [String].IsNullOrWhiteSpace(Agency.WebvantageURL) Then

                    WebvantageURL = New UriBuilder(Agency.WebvantageURL).ToString

                Else

                    WebvantageURL = ""

                End If

                TheBody &= "<br/><a href='" & WebvantageURL & "/BillingApproval.aspx'> Click here to navigate to Billing Approval. </a>"

            End If

        End If

        'send email(s):
        Dim StrEmps As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes()

        StrEmps = StrEmps.Replace(("EmpCode").ToString(), "")
        StrEmps = MiscFN.CleanStringForSplit(StrEmps, ",")

        ThisAlertID = SaveAlert(Me.TxtSubject.Text, Me.RadEditorBody.Text & Environment.NewLine, TheBody & "<br/><br/>", CType(Me.RblPriority.SelectedValue, Short), StrEmps)

        If ThisAlertID > 0 Then

            Dim eso As New EmailSessionObject(Me._Session.ConnectionString,
                                              Me._Session.UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = ThisAlertID
                .Subject = Me.TxtSubject.Text
                .EmployeeCodesToSendEmailTo = StrEmps
                .ClientPortalEmailAddressessToSendTo = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfClientContacts
                .IsClientPortal = Me.IsClientPortal
                .IncludeOriginator = True
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

        End If

        Me.CloseAndRefresh()

    End Sub

    Private Function SaveAlert(ByVal TheSubject As String, ByVal TheBodyText As String, ByVal TheBodyHTML As String, ByVal ThePriority As Short, _
                                        ByVal AlertRecipients As String) As Integer
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                Dim ThisCatID As Integer = 0

                If Me.FromPage = 1 Then

                    ThisCatID = 40

                ElseIf Me.FromPage = 2 Then

                    ThisCatID = 41

                End If
                With FxAlert

                    .AlertTypeID = 4
                    .AlertCategoryID = ThisCatID
                    .Subject = TheSubject
                    .Body = TheBodyText
                    .EmailBody = TheBodyHTML
                    .GeneratedDate = Now
                    .LastUpdated = .GeneratedDate
                    .PriorityLevel = ThePriority
                    .EmployeeCode = Session("EmpCode")
                    .UserCode = Session("UserCode")
                    .BillingApprovalBatchID = Me.BatchID

                End With

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim ThisAlert As New Alert(Session("ConnString"))

                    ThisAlert.LoadByPrimaryKey(FxAlert.ID)

                    If AlertRecipients.Length > 0 Then

                        Dim RecipientArray() As String

                        AlertRecipients = MiscFN.RemoveDuplicatesFromString(AlertRecipients, ",")
                        AlertRecipients = MiscFN.RemoveTrailingDelimiter(AlertRecipients, ",")
                        RecipientArray = AlertRecipients.Split(",")

                        If Not RecipientArray Is Nothing Then

                            For i As Integer = 0 To RecipientArray.Length - 1

                                If RecipientArray(i) <> "" Then
                                    ThisAlert.AddAlertRecipient(RecipientArray(i))

                                End If

                            Next

                        End If

                    End If

                    Return FxAlert.ID

                Else

                    Me.ShowMessage("Alert failed to save")
                    Return -1

                End If

            End Using

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Private Sub CloseAndRefresh()
        Me.CloseThisWindow()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        CloseAndRefresh()
    End Sub


End Class