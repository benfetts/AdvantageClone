Public Class TrafficScheduleByDay_Render
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
                    Dim ds As DataSet

                    'startdate days

                    Dim TaskDesc(31) As String
                    Dim TempDesc(31) As String
                    Dim strTaskDesc As String
                    Dim I As Integer

                    strTaskDesc = Request.QueryString("taskdesc")

                    TempDesc = strTaskDesc.Split(",")

                    For I = 0 To TempDesc.GetUpperBound(0)
                        TaskDesc(I + 1) = TempDesc(I)
                    Next I

                    If IsClientPortal = True Then
                        ds = oReport.TrafficScheduleByDayCP(Request.QueryString("clients"), CDate(Request.QueryString("startdate")), CInt(Request.QueryString("days")), Request.QueryString("closed"), Request.QueryString("colsort"), CBool(Request.QueryString("weekends")), CBool(Request.QueryString("empoption")), CInt(Request.QueryString("taskoption")), Request.QueryString("Offices"), Session("UserCode"), Request.QueryString("ddManager"), Request.QueryString("chkCompleted"), Request.QueryString("AECodes"), Session("UserID"))
                    Else
                        ds = oReport.TrafficScheduleByDay(Request.QueryString("clients"), CDate(Request.QueryString("startdate")), CInt(Request.QueryString("days")), Request.QueryString("closed"), Request.QueryString("colsort"), CBool(Request.QueryString("weekends")), CBool(Request.QueryString("empoption")), CInt(Request.QueryString("taskoption")), Request.QueryString("Offices"), Session("UserCode"), Request.QueryString("ddManager"), Request.QueryString("chkCompleted"), Request.QueryString("AECodes"), Session("UserID"))
                    End If


                    Dim sort1 As String = Request.QueryString("sort1").Trim
                    Dim sort2 As String = Request.QueryString("sort2").Trim
                    Dim dsSort As String
                    'Sort Dataset
                    Select Case sort1
                        Case "Client Code ASC", "Client Code DESC"
                            Select Case sort2
                                Case "Division Code ASC", "Division Code DESC"
                                    dsSort = sort1 & ", " & sort2 & ", Product Code, Job Number, Job Comp Number"
                                Case "Product Code ASC", "Product Code DESC"
                                    dsSort = sort1 & ",Division Code," & sort2 & ", Job Number, Job Comp Number"
                                Case "Job Number ASC", "Job Number DESC"
                                    dsSort = sort1 & ",Division Code,Product Code," & sort2 & ", Job Comp Number"
                                Case "Job Description ASC", "Job Description DESC"
                                    dsSort = sort1 & ",Division Code,Product Code," & sort2 & ",Job Number, Job Comp Number"
                                Case Else
                                    dsSort = sort1 & ",Division Code,Product Code, Job Number, Job Comp Number"
                            End Select
                        Case "Division Code ASC", "Division Code DESC"
                            Select Case sort2
                                Case "Product Code ASC", "Product Code DESC"
                                    dsSort = sort1 & ", " & sort2 & ", Job Number, Job Comp Number"
                                Case "Job Number ASC", "Job Number DESC"
                                    dsSort = sort1 & ",Product Code," & sort2 & ", Job Comp Number"
                                Case "Job Description ASC", "Job Description DESC"
                                    dsSort = sort1 & ",Product Code," & sort2 & ",Job Number, Job Comp Number"
                                Case Else
                                    dsSort = sort1 & ",Product Code, Job Number, Job Comp Number"
                            End Select
                        Case "Product Code ASC", "Product Code DESC"
                            Select Case sort2
                                Case "Job Number ASC", "Job Number DESC"
                                    dsSort = sort1 & ", " & sort2 & ", Job Comp Number"
                                Case "Job Description ASC", "Job Description DESC"
                                    dsSort = sort1 & ", " & sort2 & ",Job Number, Job Comp Number"
                                Case Else
                                    dsSort = sort1 & ", Job Number, Job Comp Number"
                            End Select
                        Case "Job Number ASC", "Job Number DESC"
                            Select Case sort2
                                Case "Job Description ASC", "Job Description DESC"
                                    dsSort = sort1 & ", Job Comp Number," & sort2
                                Case Else
                                    dsSort = sort1 & ", Job Comp Number"
                            End Select
                        Case "Job Description ASC", "Job Description DESC"
                            dsSort = sort1 & ", Job Number, Job Comp Number"
                        Case "Client Division Product ASC", "Client Division Product DESC"
                            Select Case sort2
                                Case "Job Description ASC", "Job Description DESC"
                                    dsSort = sort1 & ",Division Code,Product Code," & sort2 & ",Job Number, Job Comp Number"
                                Case Else
                                    dsSort = "Client Code,Division Code,Product Code, Job Number, Job Comp Number"
                            End Select
                    End Select

                    Dim dt As DataTable = ds.Tables(0)
                    dt.DefaultView.Sort = dsSort
                    dt = dt.DefaultView.ToTable
                    'ds.Tables(0).DefaultView.Sort = Request.QueryString("sort1").Trim & ", " & Request.QueryString("sort2").Trim & ",Client Code,Division Code,Product Code"
                    If CBool(Request.QueryString("chkManager")) = False Then
                        ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Manager"))
                    End If
                    If CBool(Request.QueryString("chkProjectDate")) = False Then
                        dt.Columns.Remove(dt.Columns("Job Start Date"))
                    End If
                    If CBool(Request.QueryString("chkClientCode")) = False Then
                        dt.Columns.Remove(dt.Columns("Client Code"))
                    End If
                    If CBool(Request.QueryString("chkClientDesc")) = False Then
                        dt.Columns.Remove(dt.Columns("Client Description"))
                    End If
                    If CBool(Request.QueryString("chkDivisionCode")) = False Then
                        dt.Columns.Remove(dt.Columns("Division Code"))
                    End If
                    If CBool(Request.QueryString("chkDivisionDesc")) = False Then
                        dt.Columns.Remove(dt.Columns("Division Description"))
                    End If
                    If CBool(Request.QueryString("chkProductCode")) = False Then
                        dt.Columns.Remove(dt.Columns("Product Code"))
                    End If
                    If CBool(Request.QueryString("chkProductDesc")) = False Then
                        dt.Columns.Remove(dt.Columns("Product Description"))
                    End If
                    If CBool(Request.QueryString("chkJobCompNum")) = False Then
                        dt.Columns.Remove(dt.Columns("Job Comp Number"))
                    End If
                    If CBool(Request.QueryString("chkJobCompDesc")) = False Then
                        dt.Columns.Remove(dt.Columns("Job Comp Description"))
                    End If
                    If CBool(Request.Params("chkClientReference")) = False Then
                        dt.Columns.Remove(dt.Columns("Client Reference"))
                    End If
                    If CBool(Request.Params("chkAccountExecutive")) = False Then
                        dt.Columns.Remove(dt.Columns("Account Executive"))
                    End If
                    If CBool(Request.Params("chkJobType")) = False Then
                        dt.Columns.Remove(dt.Columns("Job Type"))
                    End If
                    If CBool(Request.Params("chkJobTypeDesc")) = False Then
                        dt.Columns.Remove(dt.Columns("Job Type Description"))
                    End If
                    If CBool(Request.QueryString("chkTrafficStatus")) = False Then
                        dt.Columns.Remove(dt.Columns("Traffic Status"))
                    End If
                    If CBool(Request.QueryString("chkComments")) = False Then
                        dt.Columns.Remove(dt.Columns("Traffic Comments"))
                    End If
                    If CBool(Request.QueryString("CheckBoxPhase")) = False Then
                        dt.Columns.Remove(dt.Columns("Phase"))
                    End If
                    '---------------------------------------------------------------------------
                    'CTB: 05/26/2006 - QA ID: 3607
                    ' This is a sorting column only, it should never appear in the final report.
                    '---------------------------------------------------------------------------
                    dt.Columns.Remove(dt.Columns("Client Division Product"))

                    Me.DeliverGrid(dt, "Traffic_Schedule_By_Days")

                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

End Class