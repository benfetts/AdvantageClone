Imports System.Drawing
Public Class TrafficSchedule_Workload2
    Inherits Webvantage.BaseChildPage

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private StartDate As DateTime = Nothing
    Private EndDate As DateTime = Nothing
    Private JobCompList As String = ""
    Private IsMultiOrWorksheet As Boolean = False

    Private StrEmpList As String = ""
    Private StrWhereClause As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Try
        '    Me.JobNumber = CType(Session("WorkloadJobNumber"), Integer)
        'Catch ex As Exception
        '    Me.JobNumber = 0
        'End Try
        'Try
        '    Me.JobComponentNbr = CType(Session("WorkloadJobComponentNbr"), Integer)
        'Catch ex As Exception
        '    Me.JobComponentNbr = 0
        'End Try
        Try
            'StartDate = CType(Request.QueryString("s"), DateTime)
            StartDate = CType(Session("WorkloadStart"), DateTime)
        Catch ex As Exception
            StartDate = Nothing
        End Try
        Try
            'EndDate = CType(Request.QueryString("e"), DateTime)
            EndDate = CType(Session("WorkloadEnd"), DateTime)
        Catch ex As Exception
            EndDate = Nothing
        End Try
        Try
            Me.JobCompList = Session("WorkloadJobCompList")
        Catch ex As Exception
            Me.JobCompList = ""
        End Try
        Try
            If Session("WorkloadIsMulti") = Nothing Then
                Me.IsMultiOrWorksheet = False
            Else
                Me.IsMultiOrWorksheet = CType(Session("WorkloadIsMulti"), Boolean)
            End If
        Catch ex As Exception
            Me.IsMultiOrWorksheet = False
        End Try
        If Me.JobCompList <> "" And Me.IsMultiOrWorksheet = False Then
            Dim ar() As String
            ar = Me.JobCompList.Split("|")
            Dim ar2() As String
            ar2 = ar(0).Split(",")
            Me.JobNumber = CType(ar2(0), Integer)
            Me.JobComponentNbr = CType(ar2(1), Integer)

        ElseIf Me.JobCompList <> "" And Me.IsMultiOrWorksheet = True Then
            Try
                'get list of emps to pass to sql
                Dim EmpList As New System.Text.StringBuilder

                Dim DtEmpList As New DataTable
                Dim sched As New cSchedule(Session("ConnString"), Session("UserCode"))
                DtEmpList = sched.GetWorkloadEmps(Me.JobCompList)
                If DtEmpList.Rows.Count > 0 Then
                    For q As Integer = 0 To DtEmpList.Rows.Count - 1
                        If IsDBNull(DtEmpList.Rows(q)("EMP_CODE")) = False Then
                            EmpList.Append("'")
                            EmpList.Append(DtEmpList.Rows(q)("EMP_CODE").ToString())
                            EmpList.Append("',")
                        End If
                    Next
                End If
                StrEmpList = EmpList.ToString()
                StrEmpList = MiscFN.RemoveTrailingDelimiter(StrEmpList, ",")
            Catch ex As Exception
                StrEmpList = ""
            End Try
            Try
                'Get string of jobs and build sql
                Me.JobCompList = MiscFN.RemoveTrailingDelimiter(Me.JobCompList, "|")
                Dim WhereClause As New System.Text.StringBuilder
                With WhereClause
                    .Append(" AND CAST(JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AS VARCHAR(100))+'|'+CAST(JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AS VARCHAR(100)) IN (")
                    Dim ar() As String
                    ar = Me.JobCompList.Split("|")
                    For i As Integer = 0 To ar.Length - 1
                        Dim ar2() As String
                        ar2 = ar(i).Split(",")
                        .Append("'")
                        .Append(ar2(0))
                        .Append("|")
                        .Append(ar2(1))
                        .Append("',")
                    Next
                End With
                StrWhereClause = WhereClause.ToString()
                StrWhereClause = MiscFN.RemoveTrailingDelimiter(StrWhereClause, ",")
                StrWhereClause &= ") "
            Catch ex As Exception
                StrWhereClause = ""
            End Try
        End If
    End Sub

    Private Sub RadGridWorkload_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridWorkload.ItemDataBound
        '9
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Try
                If IsNumeric(e.Item.Cells(9).Text) = True Then
                    If CType(e.Item.Cells(9).Text, Decimal) < 0 Then
                        e.Item.Cells(9).BackColor = Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadGridWorkload_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridWorkload.NeedDataSource
        Dim t As New cTasks(Session("ConnString"))
        Dim r As New cResources
        Dim ThisLevel As cResources.SummaryLevel
        ThisLevel = cResources.SummaryLevel.Day
        Dim dt As New DataTable
        Dim QueryType As String = ""

        If Me.IsMultiOrWorksheet = False Then
            QueryType = "PSWL"
        Else
            QueryType = "PSWL2"
        End If
        Try
            dt = r.GetAvailabilityDataSet("", StartDate, EndDate, ThisLevel, "", "", True, Me.StrEmpList, "", "", "", "", "", "", "", False, "", QueryType, Me.JobNumber, Me.JobComponentNbr, Me.StrWhereClause, True).Tables(6)
            'dt = t.GetWorkloadEmployee(Session("UserCode"), "", StartDate, EndDate, "", "", "", "", "", "", "", "", False, "", QueryType, Me.JobNumber, Me.JobComponentNbr, Me.StrEmpList, Me.StrWhereClause, True).Tables(0)
        Catch ex As Exception
            dt = Nothing
        End Try
        If Not dt Is Nothing Then
            If Me.ChkOnlyOverbooked.Checked = False Then
                Me.RadGridWorkload.DataSource = dt
            Else
                Dim dv As DataView = New DataView(dt)
                dv.RowFilter = "VARIANCE < 0"
                Me.RadGridWorkload.DataSource = dv
            End If
        End If
    End Sub

    Private Sub ChkOnlyOverbooked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOnlyOverbooked.CheckedChanged
        Me.RadGridWorkload.Rebind()
    End Sub

    Private Sub TrafficSchedule_Workload2_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'Me.RadGridWorkload.MasterTableView.Caption = "For " & Me.StartDate.ToShortDateString() & " to " & Me.EndDate.ToShortDateString()
    End Sub

End Class