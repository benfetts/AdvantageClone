Imports System.Data.SqlClient

Public Class Schedule_AddFromEst
    Inherits Webvantage.BaseChildPage

    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Try
                JobNum = CType(Request.QueryString("j"), Integer)
            Catch ex As Exception
                JobNum = 0
            End Try
            Try
                JobComp = CType(Request.QueryString("jc"), Integer)
            Catch ex As Exception
                JobComp = 0
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCopyFromQuotes_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCopyFromQuotes.ItemDataBound
        Try
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCopyFromQuotes_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCopyFromQuotes.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dt As DataTable
            Dim dr As SqlDataReader
            Dim dr2 As SqlDataReader
            dt = est.GetEstimateData(0, 0, JobNum, JobComp, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    EstNum = dt.Rows(0)("ESTIMATE_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                    EstComp = dt.Rows(0)("EST_COMPONENT_NBR")
                End If
            End If
            dr = est.GetApprovals(Me.EstNum, Me.EstComp, "")
            dr2 = est.GetInternalApprovals(Me.EstNum, Me.EstComp, "")
            If dr.HasRows = False And dr2.HasRows = False Then
                'Me.ShowMessage("Estimate must have an approved Quote.")
                Exit Sub
            End If
            If dr.HasRows Then
                dr.Read()
                QuoteNum = dr("EST_QUOTE_NBR")
                RevNum = dr("EST_REVISION_NBR")
                dr.Close()
            ElseIf dr2.HasRows Then
                dr2.Read()
                QuoteNum = dr2("EST_QUOTE_NBR")
                RevNum = dr2("EST_REVISION_NBR")
                dr2.Close()
            End If
            Dim sch As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Me.RadGridCopyFromQuotes.DataSource = sch.GetEstimateTasks(EstNum, EstComp, QuoteNum, RevNum)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub cbIncludeEmployees_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncludeEmployees.CheckedChanged
        Try
            If Me.cbIncludeEmployees.Checked = True Then
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEMP_CODE").Display = True
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEmpName").Display = True
            Else
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEMP_CODE").Display = False
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEmpName").Display = False
            End If
            Me.RadGridCopyFromQuotes.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbIncludeHours_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbIncludeHours.CheckedChanged
        Try
            If Me.cbIncludeHours.Checked = True Then
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEST_REV_QUANTITY").Display = True
            Else
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEST_REV_QUANTITY").Display = False
            End If
            Me.RadGridCopyFromQuotes.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
         Dim NewTaskStatus As String = ""
        Dim NewPhaseDesc As String = ""
        Dim NewPhaseID As Integer = 0
        Dim NewJobOrder As Integer = 0
        Dim NewPredessorString As String = ""
        Dim NewTaskCode As String = ""
        Dim NewTaskDescription As String = ""
        Dim NewMilestone As Boolean = False
        Dim NewJobDays As Integer = 0
        Dim NewJobHours As Decimal = 0.0
        Dim NewStartDate As String = ""
        Dim NewRevisedDate As String = ""
        Dim NewDueTime As String = ""
        Dim NewJobDueDate As String = ""
        Dim NewJobCompletedDate As String = ""
        Dim NewEmpCodeString As String = ""
        Dim NewClientCodeString As String = ""
        Dim NewEstimateFunction As String = ""
        Dim NewFunctionComment As String = ""
        Dim NewDueDateComment As String = ""
        Dim NewRevisedDateComment As String = ""
        Dim NewDefRoleCode As String = ""
        Dim JobComponentTaskSequenceNumber As String = ""
        Dim NumberOfRowsToAdd As Integer = 1
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))


        If Me.RadGridCopyFromQuotes.Visible = True Then
            Dim chk As CheckBox
            ' Dim SyncWithOutlook As Boolean = False
            'Try
            '    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())
            '        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)
            '    End Using
            'Catch ex As Exception
            '    SyncWithOutlook = False
            'End Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCopyFromQuotes.MasterTableView.Items
                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked = True Then
                    Dim HasFunctionData As Boolean = False
                    'Set variables:
                    Try
                        NewJobOrder = gridDataItem.GetDataKeyValue("TRF_ORDER") 'CType(CType(gridDataItem("ColTRF_ORDER").FindControl("TxtTRF_ORDER"), TextBox).Text, Integer)
                    Catch ex As Exception
                        NewJobOrder = 0
                    End Try
                    'Try
                    '    NewPhaseID = CType(CType(gridDataItem("ColTRF_PRESET_ORDER").FindControl("HFPhaseID"), HiddenField).Value, Integer)
                    'Catch ex As Exception
                    '    NewPhaseID = 0
                    'End Try

                    NewTaskCode = gridDataItem("ColTRF_CODE").Text.Trim().Replace("&nbsp;", "")
                    NewTaskDescription = gridDataItem("ColTRF_DESC").Text.Trim().Replace("&nbsp;", "")
                    HasFunctionData = True

                    'If NewTaskDescription = "[Enter Task Description]" Or NewTaskDescription = "" Then
                    '    NewTaskCode = ""
                    '    NewTaskDescription = "[Blank]"
                    'End If

                    Try
                        NewMilestone = gridDataItem.GetDataKeyValue("MILESTONE") 'CType(gridDataItem("ColMILESTONE").FindControl("ChkMILESTONE"), CheckBox).Checked
                    Catch ex As Exception
                        NewMilestone = False
                    End Try

                    NewEstimateFunction = gridDataItem.GetDataKeyValue("EST_FNC_CODE")

                    'IsRush = Me.RblStandardRush.Items(1).Selected
                    'If IsRush = True Then
                    '    Try
                    '        NewJobDays = CType(CType(gridDataItem("ColRUSH_DAYS").FindControl("TxtRUSH_DAYS"), TextBox).Text, Integer)
                    '    Catch ex As Exception
                    '        NewJobDays = 0
                    '    End Try
                    '    Try
                    '        NewJobHours = CType(CType(gridDataItem("ColRUSH_HOURS").FindControl("TxtRUSH_HOURS"), TextBox).Text, Decimal)
                    '    Catch ex As Exception
                    '        NewJobHours = 0
                    '    End Try
                    'Else
                    Try
                        NewJobDays = gridDataItem.GetDataKeyValue("TRF_DAYS") 'CType(CType(gridDataItem("ColTRF_PRESET_DAYS").FindControl("TxtTRF_PRESET_DAYS"), TextBox).Text, Integer)
                    Catch ex As Exception
                        NewJobDays = 0
                    End Try
                    
                    'End If

                    Try
                        NewDefRoleCode = gridDataItem.GetDataKeyValue("DEF_TRF_ROLE") 'CType(gridDataItem("ColTRF_PRESET_ORDER").FindControl("HFRoleCode"), HiddenField).Value
                    Catch ex As Exception
                        NewDefRoleCode = ""
                    End Try
                   
                    If Me.cbIncludeEmployees.Checked = True Then
                        Try
                            NewEmpCodeString = gridDataItem.GetDataKeyValue("EMP_CODE")
                        Catch ex As Exception
                            NewEmpCodeString = ""
                        End Try
                    End If

                    If Me.cbIncludeHours.Checked = True Then
                        Try
                            NewJobHours = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("TxtEST_REV_QUANTITY"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            NewJobHours = 0
                        End Try
                    End If
                    'Save:
                    Try
                        'straighten out the phaseID and description! (also on quick add)
                        If HasFunctionData = True Then

                            JobComponentTaskSequenceNumber = oTrafficSchedule.AddNewTask(JobNum, JobComp, NewJobOrder, NewPhaseID, NewPredessorString, NewTaskCode, NewTaskDescription, NewMilestone, NewJobDays, _
                                                                    NewJobHours, NewStartDate, NewRevisedDate, NewDueTime, NewJobDueDate, False, NewJobCompletedDate, _
                                                                    NewEmpCodeString, NewEstimateFunction, NewFunctionComment, NewDueDateComment, NewRevisedDateComment, NewDefRoleCode, NewClientCodeString, "")

                            'If SyncWithOutlook AndAlso IsNumeric(JobComponentTaskSequenceNumber) Then

                            '    'AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(Session("ConnString").ToString(), Session("UserCode").ToString, JobNum, JobComp, CInt(JobComponentTaskSequenceNumber), False)

                            'End If

                        End If

                    Catch ex As Exception

                    End Try

                End If
            Next
        End If

        CloseAndRefresh()
    End Sub

    Private Sub CloseAndRefresh()
        If Me.CurrentQuerystring.IsJobDashboard = True Then
            'Me.CloseThisWindowAndRefreshCaller("Content.aspx")
        Else
            'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        End If
        Me.CloseThisWindow()
    End Sub

    
End Class