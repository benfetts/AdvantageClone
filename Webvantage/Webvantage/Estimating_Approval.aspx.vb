Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient

Public Class Estimating_Approval
    Inherits Webvantage.BaseChildPage

    Private ConnectionString As String
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private EstNum As Integer
    Private EstCompNum As Integer
    Private QuoteNum As Integer
    Private RevNum As Integer
    Private Approve As Integer '1 = Client Approval, 2 = Internal Approval
    Private CampaignID As Integer = 0
    Private ApprovalType As String = ""

    Private Sub Estimating_Approval_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.ConnectionString = Session("ConnString")
        If IsNumeric(Me.CurrentQuerystring.GetValue("JobNum")) = True Then
            Me.JobNum = Me.CurrentQuerystring.GetValue("JobNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("JobCompNum")) = True Then
            Me.JobCompNum = Me.CurrentQuerystring.GetValue("JobCompNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("EstNum")) = True Then
            Me.EstNum = Me.CurrentQuerystring.GetValue("EstNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("EstCompNum")) = True Then
            Me.EstCompNum = Me.CurrentQuerystring.GetValue("EstCompNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("QuoteNum")) = True Then
            Me.QuoteNum = Me.CurrentQuerystring.GetValue("QuoteNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("RevNum")) = True Then
            Me.RevNum = Me.CurrentQuerystring.GetValue("RevNum")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("appr")) = True Then
            Me.Approve = Me.CurrentQuerystring.GetValue("appr")
        End If
        If IsNumeric(Me.CurrentQuerystring.GetValue("CampaignID")) = True Then
            Me.CampaignID = Me.CurrentQuerystring.GetValue("CampaignID")
        End If

    End Sub

    Protected Sub Estimating_Approval_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.CampaignID > 0 Then
            ApprovalType = "CMP"
        End If
        If Not Me.IsPostBack Then
            If Me.Approve = 1 Then
                Me.pnlApproved.Visible = True
                Me.pnlApprovedInternal.Visible = False
                Me.txtApprovedBy.Focus()
            End If
            If Me.Approve = 2 Then
                Me.pnlApproved.Visible = False
                Me.pnlApprovedInternal.Visible = True
                Me.txtApprovedByInternal.Focus()
            End If
            Me.btnUpdate.Visible = False
            If Me.CurrentQuerystring.GetValue("edit") = "1" Then
                Me.LoadApprovalData()
            Else
                Me.RadDatePickerApprovalDate.SelectedDate = cEmployee.TimeZoneToday
                Me.RadDatePickerApprovalDateInternal.SelectedDate = cEmployee.TimeZoneToday
            End If
            Me.SetRadDatePicker(Me.RadDatePickerApprovalDate)
            Me.SetRadDatePicker(Me.RadDatePickerApprovalDateInternal)
        End If
        CheckUserRights()
    End Sub

#Region " SubRoutines "

    Private Sub LoadApprovalData()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            If Me.Approve = 1 Then
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, ApprovalType)
                If dr.HasRows = True Then
                    Do While dr.Read
                        Me.txtApprovedBy.Text = dr.GetString(0)
                        Me.RadDatePickerApprovalDate.SelectedDate = dr.GetDateTime(1)
                        If ApprovalType = "" Then
                            Me.txtClientPO.Text = dr.GetString(2)
                        End If
                        If ApprovalType = "CMP" Then
                            Me.txtNotes.Text = dr.GetString(4)
                        Else
                            Me.txtNotes.Text = dr.GetString(5)
                        End If
                    Loop
                End If
            End If
            If Me.Approve = 2 Then
                dr = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, ApprovalType)
                If dr.HasRows = True Then
                    Do While dr.Read
                        Me.txtApprovedByInternal.Text = dr.GetString(0)
                        Me.RadDatePickerApprovalDateInternal.SelectedDate = dr.GetDateTime(1)
                        Me.txtNotesInternal.Text = dr.GetString(4)
                    Loop
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            'Quote Approval
            'secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval), "Y", "N")
            'secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval), "Y", "N")
            'secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval), "Y", "N")

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                secView = IIf(AdvantageFramework.Security.CanUserPrintInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")
                secEdit = IIf(AdvantageFramework.Security.CanUserUpdateInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")
                secInsert = IIf(AdvantageFramework.Security.CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")

                If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode) = True Then
                    If secView = "N" And secEdit = "N" And secInsert = "N" Then
                    ElseIf secView = "N" And secEdit = "Y" And secInsert = "N" Then
                    ElseIf secView = "N" And secEdit = "N" And secInsert = "Y" And Me.CurrentQuerystring.GetValue("edit") = "1" Then
                        If Me.pnlApproved.Visible = True Then
                            Me.txtApprovedBy.ReadOnly = True
                            Me.RadDatePickerApprovalDate.Enabled = True
                            Me.RadDatePickerApprovalDate.Enabled = True
                            Me.txtClientPO.ReadOnly = True
                            Me.txtNotes.ReadOnly = True
                        End If
                        If Me.pnlApprovedInternal.Visible = True Then
                            Me.txtApprovedByInternal.ReadOnly = True
                            Me.RadDatePickerApprovalDateInternal.Enabled = True
                            Me.txtNotesInternal.ReadOnly = True
                        End If
                        Me.SaveButton.Enabled = False
                        Me.btnUpdate.Enabled = False
                    ElseIf secView = "N" And secEdit = "Y" And secInsert = "Y" Then
                    ElseIf secView = "Y" And secEdit = "N" And secInsert = "N" Then
                        If Me.pnlApproved.Visible = True Then
                            Me.txtApprovedBy.ReadOnly = True
                            Me.RadDatePickerApprovalDate.Enabled = True
                            Me.txtClientPO.ReadOnly = True
                            Me.txtNotes.ReadOnly = True
                        End If
                        If Me.pnlApprovedInternal.Visible = True Then
                            Me.txtApprovedByInternal.ReadOnly = True
                            Me.RadDatePickerApprovalDateInternal.Enabled = True
                            Me.txtNotesInternal.ReadOnly = True
                        End If
                        Me.SaveButton.Enabled = False
                        Me.btnUpdate.Enabled = False
                    ElseIf secView = "Y" And secEdit = "Y" And secInsert = "N" Then
                    ElseIf secView = "Y" And secEdit = "N" And secInsert = "Y" And Me.CurrentQuerystring.GetValue("edit") = "1" Then
                        If Me.pnlApproved.Visible = True Then
                            Me.txtApprovedBy.ReadOnly = True
                            Me.RadDatePickerApprovalDate.Enabled = True
                            Me.txtClientPO.ReadOnly = True
                            Me.txtNotes.ReadOnly = True
                        End If
                        If Me.pnlApprovedInternal.Visible = True Then
                            Me.txtApprovedByInternal.ReadOnly = True
                            Me.RadDatePickerApprovalDateInternal.Enabled = True
                            Me.txtNotesInternal.ReadOnly = True
                        End If
                        Me.SaveButton.Enabled = False
                        Me.btnUpdate.Enabled = False
                    End If

                Else

                    Me.SaveButton.Enabled = False
                    Me.btnUpdate.Enabled = False

                End If

            End Using

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Controls "

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim dt As DataTable
            Dim dr As SqlDataReader
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim cv As New cValidations(Session("ConnString"))
            Dim save As Boolean
            Dim delete As Boolean
            Dim max As Integer
            Dim maxRev As Integer
            Dim invalidStr As String = ""
            Dim str As String

            If Me.Approve = 1 Then
                If Me.txtApprovedBy.Text = "" Then
                    Me.lblMSG.Text = "Approved By is required."
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerApprovalDate) = False Then
                    invalidStr = invalidStr & "Invalid Approval Date<br />"
                End If
            End If
            If Me.Approve = 2 Then
                If Me.txtApprovedByInternal.Text = "" Then
                    Me.lblMSG.Text = "Approved By is required."
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerApprovalDateInternal) = False Then
                    invalidStr = invalidStr & "Invalid Approval Date<br />"
                End If
            End If

            If invalidStr <> "" Then
                Me.lblMSG.Text = invalidStr
                invalidStr = ""
                Exit Sub
            End If

            If Me.Approve = 1 Then
                delete = est.DeleteQuoteApproval(Me.EstNum, Me.EstCompNum)
                dr = est.GetInternalApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, ApprovalType)
                If dr.HasRows = False Then
                    delete = est.DeleteQuoteApprovalInternal(Me.EstNum, Me.EstCompNum)
                End If
                If Me.JobNum = 0 And Me.JobCompNum = 0 And Me.CampaignID > 0 Then
                    save = est.AddCampaignQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.CampaignID, Me.txtApprovedBy.Text, Me.RadDatePickerApprovalDate.SelectedDate, Session("UserCode"), Now, Me.txtNotes.Text, "C")
                Else
                    save = est.AddQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.JobNum, Me.JobCompNum, Me.txtApprovedBy.Text, Me.RadDatePickerApprovalDate.SelectedDate, Me.txtClientPO.Text, Session("UserCode"), Now, Me.txtNotes.Text)
                End If

            End If

            If Me.Approve = 2 Then
                delete = est.DeleteQuoteApprovalInternal(Me.EstNum, Me.EstCompNum)
                dr = est.GetApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, ApprovalType)
                If dr.HasRows = False Then
                    delete = est.DeleteQuoteApproval(Me.EstNum, Me.EstCompNum)
                End If
                If Me.JobNum = 0 And Me.JobCompNum = 0 And Me.CampaignID > 0 Then
                    save = est.AddCampaignQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.CampaignID, Me.txtApprovedByInternal.Text, Me.RadDatePickerApprovalDateInternal.SelectedDate, Session("UserCode"), Now, Me.txtNotesInternal.Text, "I")
                Else
                    save = est.AddQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.JobNum, Me.JobCompNum, Me.txtApprovedByInternal.Text, CDate(Me.RadDatePickerApprovalDateInternal.SelectedDate), Session("UserCode"), Now, Me.txtNotesInternal.Text)
                End If

            End If

            If save = True And Me.CampaignID = 0 Then

                Dim s As String = ""
                Dim UpdatedAlertIDs As New Generic.List(Of Integer)

                Try

                    Select Case Me.Approve
                        Case 1

                            AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(_Session, HttpContext.Current.Session("UserCode"),
                                                                                                   AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.Estimate_ClientApproval,
                                                                                                   False, Me.JobNum, Me.JobCompNum,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,, UpdatedAlertIDs)
                        Case 2

                            AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(_Session, HttpContext.Current.Session("UserCode"),
                                                                                                   AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.Estimate_InternalApproval,
                                                                                                   False, Me.JobNum, Me.JobCompNum,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,, UpdatedAlertIDs)
                    End Select

                Catch ex As Exception
                End Try

                'If s = "" Then

                Try

                    If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                        For Each AlertId In UpdatedAlertIDs

                            Try

                                SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                            Catch ex As Exception
                            End Try

                        Next

                    End If

                Catch ex As Exception
                End Try

                Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")

                'Else

                '    Me.ShowMessage("Error applying workflow to assignments.\n" & AdvantageFramework.StringUtilities.JavascriptSafe(s))

                'End If

            ElseIf save = True And Me.CampaignID > 0 Then

                Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")

            Else

                Me.ShowMessage("Approval save Failed!")

            End If

        Catch ex As Exception

            Me.ShowMessage("Error estimateapproval!<BR />" & ex.Message.ToString())

        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim dt As DataTable
        Dim cv As New cValidations(Session("ConnString"))
        Dim update As Boolean
        Dim delete As Boolean
        Dim max As Integer
        Dim maxRev As Integer
        Dim invalidStr As String = ""
        Dim str As String

    End Sub

    Private Sub CancelButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        Me.CloseThisWindow()
    End Sub

#End Region


End Class
