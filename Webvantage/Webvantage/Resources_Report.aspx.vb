Public Class Resources_Report
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Resource Report Options"
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_ResourcesRTP)
        Me.LblMSG.Text = ""
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Dim r As New cResources()

            'load resource types
            Try
                With Me.LbResourceTypes
                    .DataSource = r.GetResourceTypes()
                    .DataTextField = "RESOURCE_TYPE_DESC"
                    .DataValueField = "RESOURCE_TYPE_CODE"
                    .DataBind()
                    .Enabled = False
                End With
                Me.RblResourceTypes.SelectedIndex = 0
            Catch ex As Exception
            End Try

            'load resources
            Try
                With Me.LbResourcesList
                    .DataSource = r.GetResourcesByType("")
                    .DataTextField = "RESOURCE_DESC"
                    .DataValueField = "RESOURCE_CODE"
                    .DataBind()
                    .Enabled = False
                End With
                Me.RblResources.SelectedIndex = 0
            Catch ex As Exception
            End Try

            Me.RadDatePickerStartDate.SelectedDate = DayPilot.Utils.Week.FirstDayOfWeek()
            Me.RadDatePickerEndDate.SelectedDate = Today

            Dim rsc As New cResources()
            rsc.EventTypeColors(False, Me.RadColorPickerNoEventType, Me.RadColorPickerFixed, Me.RadColorPickerFlex, Me.RadColorPickerPreEmptable, Me.RadColorPickerHold)

        End If
    End Sub

    Private Sub RblResourceTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblResourceTypes.SelectedIndexChanged
        If Me.RblResourceTypes.SelectedIndex = 0 Then
            Me.LbResourceTypes.Enabled = False
            For i As Integer = 0 To Me.LbResourceTypes.Items.Count - 1
                Me.LbResourceTypes.Items(i).Selected = False
            Next
            Try
                Dim r As New cResources()
                With Me.LbResourcesList
                    .Items.Clear()
                    .DataSource = r.GetResourcesByType("")
                    .DataTextField = "RESOURCE_DESC"
                    .DataValueField = "RESOURCE_CODE"
                    .DataBind()
                    .Enabled = False
                End With
                Me.RblResources.SelectedIndex = 0
            Catch ex As Exception
            End Try
        Else
            Me.LbResourceTypes.Enabled = True
        End If
    End Sub

    Private Sub RblResources_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblResources.SelectedIndexChanged
        If Me.RblResources.SelectedIndex = 0 Then
            Me.LbResourcesList.Enabled = False
            For i As Integer = 0 To Me.LbResourcesList.Items.Count - 1
                Me.LbResourcesList.Items(i).Selected = False
            Next
        Else
            Me.LbResourcesList.Enabled = True
        End If
    End Sub

    Private Sub LbResourceTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbResourceTypes.SelectedIndexChanged

        Dim sb As New System.Text.StringBuilder
        For i As Integer = 0 To Me.LbResourceTypes.Items.Count - 1
            If Me.LbResourceTypes.Items(i).Selected = True Then
                With sb
                    .Append("'")
                    .Append(Me.LbResourceTypes.Items(i).Value)
                    .Append("',")
                End With
            End If
        Next
        Dim str As String = sb.ToString()
        str = MiscFN.RemoveTrailingDelimiter(str, ",")
        Try
            Dim r As New cResources()
            With Me.LbResourcesList
                .Items.Clear()
                .DataSource = r.GetResourcesByType(str)
                .DataTextField = "RESOURCE_DESC"
                .DataValueField = "RESOURCE_CODE"
                .DataBind()
                .Enabled = False
            End With
            Me.RblResources.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnViewReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewReport.Click
        Me.LblMSG.Text = ""
        If Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then
            Me.LblMSG.Text = "Invalid Start Date"
            Exit Sub
        Else
            Me.RadDatePickerStartDate.SelectedDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        End If
        If Me.RadDatePickerEndDate.SelectedDate.HasValue = False Then
            Me.LblMSG.Text = "Invalid End Date"
            Exit Sub
        Else
            Me.RadDatePickerEndDate.SelectedDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
        End If

        If MiscFN.StartIsBeforeEnd(Me.RadDatePickerStartDate.SelectedDate, Me.RadDatePickerEndDate.SelectedDate) = False Then
            Me.LblMSG.Text = "End Date is before Start Date"
            Exit Sub
        End If

        Dim sd As String = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()
        Dim ed As String = CType(Me.RadDatePickerEndDate.SelectedDate, Date).ToShortDateString() 'DateAdd(DateInterval.Day, 1, CType(Me.RadDatePickerEndDate.SelectedDate, Date)).ToShortDateString()

        Dim str As String = ""
        Dim i As Integer = 0

        Dim r As New cResources()
        If r.IsOverRowLimit(CType(Me.RadDatePickerStartDate.SelectedDate, Date), CType(Me.RadDatePickerEndDate.SelectedDate, Date), TimeIncrement.HalfHour) = True Then
            Me.LblMSG.Text = "Date range will exceed Excel limits!  Please choose a smaller date range."
            Exit Sub
        End If

        Dim NumResources As Integer = 0
        If Me.RblResources.SelectedIndex = 0 Then
            NumResources = Me.LbResourcesList.Items.Count
        Else
            i = 0
            For i = 0 To Me.LbResourcesList.Items.Count - 1
                If Me.LbResourcesList.Items(i).Selected = True Then
                    NumResources += 1
                End If
            Next
        End If

        If NumResources > 245 Then
            Me.LblMSG.Text = "Number of resources selected will exceed Excel limits!  Please choose less resources."
            Exit Sub
        End If


        If Me.RblResourceTypes.SelectedIndex = 0 Then
            Session("EVTRPT_ResourceTypes") = ""
        Else
            Dim sb As New System.Text.StringBuilder
            For i = 0 To Me.LbResourceTypes.Items.Count - 1
                If Me.LbResourceTypes.Items(i).Selected = True Then
                    With sb
                        .Append("'")
                        .Append(Me.LbResourceTypes.Items(i).Value)
                        .Append("',")
                    End With
                End If
            Next
            str = sb.ToString()
            str = MiscFN.RemoveTrailingDelimiter(str, ",")
            Session("EVTRPT_ResourceTypes") = str
        End If
        If Me.RblResources.SelectedIndex = 0 Then
            Session("EVTRPT_ResourceList") = ""
        Else
            i = 0
            str = ""
            Dim sb As New System.Text.StringBuilder
            For i = 0 To Me.LbResourcesList.Items.Count - 1
                If Me.LbResourcesList.Items(i).Selected = True Then
                    With sb
                        .Append("'")
                        .Append(Me.LbResourcesList.Items(i).Value)
                        .Append("',")
                    End With
                End If
            Next
            str = sb.ToString()
            str = MiscFN.RemoveTrailingDelimiter(str, ",")
            Session("EVTRPT_ResourceList") = str
        End If

        Session("EVTRPT_StartDate") = sd
        Session("EVTRPT_EndDate") = ed
        Session("EVTRPT_OfficeList") = ""
        Session("EVTRPT_CDPList") = ""
        Session("EVTRPT_TrfFncList") = ""
        Session("EVTRPT_EmployeeList") = ""

        Dim rsc As New cResources()
        rsc.EventTypeColors(True, Me.RadColorPickerNoEventType, Me.RadColorPickerFixed, Me.RadColorPickerFlex, Me.RadColorPickerPreEmptable, Me.RadColorPickerHold)

        MiscFN.ResponseRedirect("Resources_RptExcel.aspx?s=" & sd & "&e=" & ed)

    End Sub

End Class