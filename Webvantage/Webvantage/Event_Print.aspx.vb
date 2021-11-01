Partial Public Class Event_Print
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Event Schedule"
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_EventScheduleRTP)
            Try
                Me.LoadFilters()
            Catch ex As Exception

            End Try
        Else
            Try

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private ErrMsg As String = ""

    Private Sub LoadFilters()
        Try
            ErrMsg = ""
            Dim evt As New cEvents()
            Dim ds As New DataSet
            ds = evt.GetFilterLists()

            If Not ds Is Nothing Then
                Try
                    With Me.LbOfficesList
                        .Items.Clear()
                        If Not ds.Tables(0) Is Nothing Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                '''.Items.Insert(0, MiscFN.NewListItem("[All]", "all"))
                                '''.Items.Insert(1, MiscFN.NewListItem("[None]", "none"))
                                .DataSource = ds.Tables(0)
                                .DataValueField = "CODE"
                                .DataTextField = "DESCRIPTION"
                            Else
                                '.Items.Insert(0, MiscFN.NewListItem("[None]", "none"))
                                .Enabled = False
                                Me.RblOffice.Enabled = False
                            End If
                        End If
                        .DataBind()
                        .SelectedIndex = -1
                    End With
                Catch ex As Exception
                    ErrMsg += "Error binding Office List:  " & ex.Message.ToString() & "<br />"
                End Try
                Try
                    With Me.LbCDPList
                        .Items.Clear()
                        If Not ds.Tables(1) Is Nothing Then
                            If ds.Tables(1).Rows.Count > 0 Then
                                '''.Items.Insert(0, MiscFN.NewListItem("[All]", "all"))
                                .DataSource = ds.Tables(1)
                                .DataValueField = "CODE"
                                .DataTextField = "DESCRIPTION"
                            Else
                                '.Items.Insert(0, MiscFN.NewListItem("[None]", "none"))
                                .Enabled = False
                                Me.RblCDP.Enabled = False
                            End If
                        End If
                        .DataBind()
                        .SelectedIndex = -1
                    End With
                Catch ex As Exception
                    ErrMsg += "Error binding CDP List:  " & ex.Message.ToString() & "<br />"
                End Try
                Try
                    With Me.LbResourcesList
                        .Items.Clear()
                        If Not ds.Tables(2) Is Nothing Then
                            If ds.Tables(2).Rows.Count > 0 Then
                                '''.Items.Insert(0, MiscFN.NewListItem("[All]", "all"))
                                '''.Items.Insert(1, MiscFN.NewListItem("[None]", "none"))
                                .DataSource = ds.Tables(2)
                                .DataValueField = "CODE"
                                .DataTextField = "DESCRIPTION"
                            Else
                                '.Items.Insert(0, MiscFN.NewListItem("[None]", "none"))
                                .Enabled = False
                                Me.RblResource.Enabled = False
                            End If
                        End If
                        .DataBind()
                        .SelectedIndex = -1
                    End With
                Catch ex As Exception
                    ErrMsg += "Error binding Resources List:  " & ex.Message.ToString() & "<br />"
                End Try
                Try
                    Dim TableIndex As Integer = 3
                    If Me.DropReportType.SelectedValue = "rsc_usage" Then
                        TableIndex = 4
                    End If
                    With Me.LbTasksList
                        .Items.Clear()
                        If Not ds.Tables(TableIndex) Is Nothing Then
                            If ds.Tables(TableIndex).Rows.Count > 0 Then
                                '''.Items.Insert(0, MiscFN.NewListItem("[All]", "all"))
                                '''.Items.Insert(1, MiscFN.NewListItem("[None]", "none"))
                                .DataSource = ds.Tables(TableIndex)
                                .DataValueField = "CODE"
                                .DataTextField = "DESCRIPTION"
                            Else
                                '.Items.Insert(0, MiscFN.NewListItem("[None]", "none"))
                                .Enabled = False
                                Me.RblTask.Enabled = False
                            End If
                        End If
                        .DataBind()
                        .SelectedIndex = -1
                    End With
                Catch ex As Exception
                    ErrMsg += "Error binding Task List:  " & ex.Message.ToString() & "<br />"
                End Try
                Try
                    With Me.LbEmployeesList
                        .Items.Clear()
                        If Not ds.Tables(5) Is Nothing Then
                            If ds.Tables(5).Rows.Count > 0 Then
                                '''.Items.Insert(0, MiscFN.NewListItem("[All]", "all"))
                                '''.Items.Insert(1, MiscFN.NewListItem("[None]", "none"))
                                .DataSource = ds.Tables(5)
                                .DataValueField = "CODE"
                                .DataTextField = "DESCRIPTION"
                            Else
                                '.Items.Insert(0, MiscFN.NewListItem("[None]", "none"))
                                .Enabled = False
                                Me.RblEmployee.Enabled = False
                            End If
                        End If
                        .DataBind()
                        .SelectedIndex = -1
                    End With
                Catch ex As Exception
                    ErrMsg += "Error binding Employee List:  " & ex.Message.ToString() & "<br />"
                End Try
            End If
            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth
            Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
        Catch ex As Exception
            ErrMsg += "Error in LoadFilters: " & ex.Message.ToString()
        End Try
    End Sub

    Private Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Me.LblMSG.Text = ""
        'build sql string to session?
        Try
            ErrMsg = ""
            Dim StartDate As String = ""
            Dim EndDate As String = ""

            'validate:
            If Me.RadDatePickerStartDate.SelectedDate = Nothing Then
                ErrMsg = "Start Date required"
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            End If
            If Me.RadDatePickerEndDate.SelectedDate = Nothing Then
                ErrMsg = "End Date required"
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            End If
            If Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then
                ErrMsg = "Start Date invalid"
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            Else
                StartDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString()
            End If
            If Me.RadDatePickerEndDate.SelectedDate.HasValue = False Then
                ErrMsg = "End Date invalid"
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            Else
                EndDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString()
            End If

            If MiscFN.StartIsBeforeEnd(StartDate, EndDate) = False Then
                ErrMsg = "End Date is before Start Date"
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            End If


            'build strings
            'Dim SbOfficeList As New System.Text.StringBuilder
            'Dim SbCDPList As New System.Text.StringBuilder
            'Dim SbResourceList As New System.Text.StringBuilder
            'Dim SbTrfFncList As New System.Text.StringBuilder
            'Dim SbEmployeeList As New System.Text.StringBuilder

            Dim StrOfficeList As String = ""
            Dim StrCDPList As String = ""
            Dim StrResourceList As String = ""
            Dim StrTrfFncList As String = ""
            Dim StrEmployeeList As String = ""

            Dim i As Integer = 0

            'office
            Try
                Select Case Me.RblOffice.SelectedValue
                    Case "all"
                        StrOfficeList = ""
                    Case "none"
                        StrOfficeList = "[NONE]"
                    Case "select"
                        For i = 0 To Me.LbOfficesList.Items.Count - 1
                            If Me.LbOfficesList.Items(i).Selected = True Then
                                StrOfficeList += "'" & Me.LbOfficesList.Items(i).Value.ToString() & "',"
                            End If
                        Next
                        StrOfficeList = MiscFN.RemoveTrailingDelimiter(StrOfficeList, ",")
                    Case Else
                        StrOfficeList = ""
                End Select
            Catch ex As Exception
                StrOfficeList = ""
            End Try
            i = 0

            'cdp
            Try
                Select Case Me.RblCDP.SelectedValue
                    Case "all"
                        StrCDPList = ""
                    Case "select"
                        For i = 0 To Me.LbCDPList.Items.Count - 1
                            If Me.LbCDPList.Items(i).Selected = True Then
                                StrCDPList += "'" & Me.LbCDPList.Items(i).Value.ToString() & "',"
                            End If
                        Next
                        StrCDPList = MiscFN.RemoveTrailingDelimiter(StrCDPList, ",")
                    Case Else
                        StrCDPList = ""
                End Select
            Catch ex As Exception
                StrCDPList = ""
            End Try
            i = 0

            'resources
            Try
                Select Case Me.RblResource.SelectedValue
                    Case "all"
                        StrResourceList = ""
                    Case "none"
                        StrResourceList = "[NONE]"
                    Case "select"
                        For i = 0 To Me.LbResourcesList.Items.Count - 1
                            If Me.LbResourcesList.Items(i).Selected = True Then
                                StrResourceList += "'" & Me.LbResourcesList.Items(i).Value.ToString() & "',"
                            End If
                        Next
                        StrResourceList = MiscFN.RemoveTrailingDelimiter(StrResourceList, ",")
                    Case Else
                        StrResourceList = ""
                End Select
            Catch ex As Exception
                StrResourceList = ""
            End Try
            i = 0


            'trf fnc
            Try
                Select Case Me.RblTask.SelectedValue
                    Case "all"
                        StrTrfFncList = ""
                    Case "none"
                        StrTrfFncList = "[NONE]"
                    Case "select"
                        For i = 0 To Me.LbTasksList.Items.Count - 1
                            If Me.LbTasksList.Items(i).Selected = True Then
                                StrTrfFncList += "'" & Me.LbTasksList.Items(i).Value.ToString() & "',"
                            End If
                        Next
                        StrTrfFncList = MiscFN.RemoveTrailingDelimiter(StrTrfFncList, ",")
                    Case Else
                        StrTrfFncList = ""
                End Select
            Catch ex As Exception
                StrTrfFncList = ""
            End Try
            i = 0

            'emp
            Try
                Select Case Me.RblEmployee.SelectedValue
                    Case "all"
                        StrEmployeeList = ""
                    Case "none"
                        StrEmployeeList = "[NONE]"
                    Case "select"
                        For i = 0 To Me.LbEmployeesList.Items.Count - 1
                            If Me.LbEmployeesList.Items(i).Selected = True Then
                                StrEmployeeList += "'" & Me.LbEmployeesList.Items(i).Value.ToString() & "',"
                            End If
                        Next
                        StrEmployeeList = MiscFN.RemoveTrailingDelimiter(StrEmployeeList, ",")
                    Case Else
                        StrEmployeeList = ""
                End Select
            Catch ex As Exception
                StrEmployeeList = ""
            End Try
            i = 0





            If ErrMsg <> "" Then
                Me.LblMSG.Text = ErrMsg
                Exit Sub
            End If

            Session("EVTRPT_ReportType") = Me.DropReportType.SelectedValue
            Session("EVTRPT_ShowImages") = Me.ChkShowImages.Checked
            Session("EVTRPT_EnableEmail") = Me.ChkEnableEmail.Checked
            Session("EVTRPT_StartDate") = StartDate
            Session("EVTRPT_EndDate") = EndDate
            Session("EVTRPT_OfficeList") = StrOfficeList
            Session("EVTRPT_CDPList") = StrCDPList
            Session("EVTRPT_ResourceList") = StrResourceList
            Session("EVTRPT_TrfFncList") = StrTrfFncList
            Session("EVTRPT_EmployeeList") = StrEmployeeList
            Session("EVTRPT_PageBreak") = Me.CheckBoxPageBreak.Checked
            Session("EVTRPT_InclTermintatedEmployees") = Me.CheckboxIncludeTerminatedEmployees.Checked
            Session("EVTRPT_InclInactiveResources") = Me.CheckboxIncludeInactiveResources.Checked

            'Me.LitScript.Text = "<script type=""text/javascript"">open_JSWindow('Event_Print_HTML_Report','Event_Print_HTML_Report.aspx',550,900,'yes','yes','yes','no');</script>"
            If Me.DropReportType.SelectedValue = "rsc_usage" Then
                MiscFN.ResponseRedirect("Resources_RptExcel.aspx?s=" & StartDate & "&e=" & EndDate, False)
            Else
                If Me.CheckBoxPageBreak.Checked = True Then
                    Me.AddJavascriptToPage("window.open('Event_Print_HTML_PB.aspx', 'Event_Print_HTML_Report','screenX=150,left=150,screenY=150,top=150,width=940,height=650,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes');return false;")
                Else
                    Me.AddJavascriptToPage("window.open('Event_Print_HTML.aspx', 'Event_Print_HTML_Report','screenX=150,left=150,screenY=150,top=150,width=940,height=650,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes');return false;")
                End If
            End If
        Catch ex As Exception
            ErrMsg += "Error in BtnView_Click: " & ex.Message.ToString()
        End Try
    End Sub

    Private Sub RblOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblOffice.SelectedIndexChanged
        Try
            Select Case Me.RblOffice.SelectedValue
                Case "all"
                    Me.LbOfficesList.Enabled = False
                    Me.LbOfficesList.SelectedIndex = -1
                Case "none"
                    Me.LbOfficesList.Enabled = False
                    Me.LbOfficesList.SelectedIndex = -1
                Case "select"
                    Me.LbOfficesList.Enabled = True
                    Me.LbOfficesList.SelectedIndex = 0
                Case Else
            End Select
        Catch ex As Exception
            Me.LbOfficesList.Enabled = True
        End Try
    End Sub

    Private Sub RblCDP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblCDP.SelectedIndexChanged
        Try
            Select Case Me.RblCDP.SelectedValue
                Case "all"
                    Me.LbCDPList.Enabled = False
                    Me.LbCDPList.SelectedIndex = -1
                Case "select"
                    Me.LbCDPList.Enabled = True
                    Me.LbCDPList.SelectedIndex = 0
                Case Else
            End Select
        Catch ex As Exception
            Me.LbCDPList.Enabled = True
        End Try

    End Sub

    Private Sub RblResource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblResource.SelectedIndexChanged
        Try
            Select Case Me.RblResource.SelectedValue
                Case "all"
                    Me.LbResourcesList.Enabled = False
                    Me.LbResourcesList.SelectedIndex = -1
                Case "none"
                    Me.LbResourcesList.Enabled = False
                    Me.LbResourcesList.SelectedIndex = -1
                Case "select"
                    Me.LbResourcesList.Enabled = True
                    Me.LbResourcesList.SelectedIndex = 0
                Case Else
            End Select
        Catch ex As Exception
            Me.LbResourcesList.Enabled = True
        End Try

    End Sub

    Private Sub RblTask_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblTask.SelectedIndexChanged
        Try
            Select Case Me.RblTask.SelectedValue
                Case "all"
                    Me.LbTasksList.Enabled = False
                    Me.LbTasksList.SelectedIndex = -1
                Case "none"
                    Me.LbTasksList.Enabled = False
                    Me.LbTasksList.SelectedIndex = -1
                Case "select"
                    Me.LbTasksList.Enabled = True
                    Me.LbTasksList.SelectedIndex = 0
                Case Else
            End Select
        Catch ex As Exception
            Me.LbTasksList.Enabled = True
        End Try

    End Sub

    Private Sub RblEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblEmployee.SelectedIndexChanged
        Try
            Select Case Me.RblEmployee.SelectedValue
                Case "all"
                    Me.LbEmployeesList.Enabled = False
                    Me.LbEmployeesList.SelectedIndex = -1
                Case "none"
                    Me.LbEmployeesList.Enabled = False
                    Me.LbEmployeesList.SelectedIndex = -1
                Case "select"
                    Me.LbEmployeesList.Enabled = True
                    Me.LbEmployeesList.SelectedIndex = 0
                Case Else
            End Select
        Catch ex As Exception
            Me.LbEmployeesList.Enabled = True
        End Try

    End Sub

    Private Sub DropReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropReportType.SelectedIndexChanged
        Select Case Me.DropReportType.SelectedValue
            Case "evt_employee"
                Me.ChkEnableEmail.Enabled = True
            Case "evt_resource"
                Me.ChkEnableEmail.Enabled = False
                Me.ChkEnableEmail.Checked = False
        End Select
        Me.LoadFilters()
    End Sub

    Private Sub ChkShowImages_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkShowImages.CheckedChanged
        If Me.DropReportType.SelectedValue = "evt_employee" And Me.ChkShowImages.Checked = True Then
            Me.ChkEnableEmail.Checked = False
        End If
    End Sub

    Private Sub ChkEnableEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkEnableEmail.CheckedChanged
        If Me.DropReportType.SelectedValue = "evt_employee" And Me.ChkEnableEmail.Checked = True Then
            Me.ChkShowImages.Checked = False
        End If
    End Sub

    Private Sub Event_Print_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.RblOffice.SelectedIndex = 0
            Me.LbOfficesList.Enabled = False
            Me.LbOfficesList.SelectedIndex = -1

            Me.RblCDP.SelectedIndex = 0
            Me.LbCDPList.Enabled = False
            Me.LbCDPList.SelectedIndex = -1

            Me.RblResource.SelectedIndex = 0
            Me.LbResourcesList.Enabled = False
            Me.LbResourcesList.SelectedIndex = -1

            Me.RblTask.SelectedIndex = 0
            Me.LbTasksList.Enabled = False
            Me.LbTasksList.SelectedIndex = -1

            Me.RblEmployee.SelectedIndex = 0
            Me.LbEmployeesList.Enabled = False
            Me.LbEmployeesList.SelectedIndex = -1

        End If
    End Sub
End Class
