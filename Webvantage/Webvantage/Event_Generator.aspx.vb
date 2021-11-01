Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class Event_Generator
    Inherits Webvantage.BaseChildPage

    Private FromForm As Integer = 0 '0 = Estimate, 1 = Job Jacket
    Private EventGeneratorId As Integer = 0
    Private EstNumber As Integer = 0
    Private EstComponentNbr As Integer = 0
    Private EstQuoteNumber As Integer = 0
    Private EstRevNumber As Integer = 0
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private FncCode As String = ""
    Private IsNew As Boolean = False
    Private CliCode As String = ""
    Private StartDate As String = ""
    Private EndDate As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetVars()

        If Not Me.IsPostBack Or Me.IsCallback Then
            Me.LblMSG.Text = ""
            Me.LoadLookups()
            Me.LoadEventGenList()
            Me.ImageButtonDeleteGenerator.Visible = False
            If FromForm = 0 Then
                Me.BtnGenerate.ToolTip = "Generate an estimate function"
            Else
                Me.BtnGenerate.ToolTip = "Generate events"
            End If
            Try
                Me.DropEventGenerators.Focus()
            Catch ex As Exception
            End Try
        Else 'It is a post back

        End If
    End Sub

    Private Sub SetVars()
        'from estimate_quote: f = 0, e=estimate number, ec=estimate component number, eq=estimate quote number

        Try
            If Not Request.QueryString("f") = Nothing Then
                Me.FromForm = CType(Request.QueryString("f"), Integer)
            End If
        Catch ex As Exception
            Me.FromForm = 0
        End Try
        Try
            If Not Request.QueryString("e") = Nothing Then
                Me.EstNumber = CType(Request.QueryString("e"), Integer)
            End If
        Catch ex As Exception
            Me.EstNumber = 0
        End Try
        Try
            If Not Request.QueryString("ec") = Nothing Then
                Me.EstComponentNbr = CType(Request.QueryString("ec"), Integer)
            End If
        Catch ex As Exception
            Me.EstComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("eq") = Nothing Then
                Me.EstQuoteNumber = CType(Request.QueryString("eq"), Integer)
            End If
        Catch ex As Exception
            Me.EstQuoteNumber = 0
        End Try
        Try
            If Not Request.QueryString("er") = Nothing Then
                Me.EstRevNumber = CType(Request.QueryString("er"), Integer)
            End If
        Catch ex As Exception
            Me.EstRevNumber = 0
        End Try
        Try
            If Not Request.QueryString("j") = Nothing Then
                Me.JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") = Nothing Then
                Me.JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("fn") = Nothing Then
                Me.FncCode = Request.QueryString("fn")
            End If
        Catch ex As Exception
            Me.FncCode = ""
        End Try
    End Sub

    Private Sub LoadLookups()
        'Function Code and Ad number
        'need to get client code for ad number lookup
        If FromForm = 0 And Me.EstNumber > 0 Then
            Try
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand("SELECT CL_CODE FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER = " & Me.EstNumber.ToString() & ";", MyConn, MyTrans)
                    Try
                        Me.CliCode = MyCmd.ExecuteScalar()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            Catch ex As Exception
                Me.CliCode = ""
            End Try
        End If
        If FromForm = 1 And Me.JobNumber > 0 Then
            Try
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand("SELECT CL_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER = " & Me.JobNumber.ToString() & ";", MyConn, MyTrans)
                    Try
                        Me.CliCode = MyCmd.ExecuteScalar()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            Catch ex As Exception
                Me.CliCode = ""
            End Try
        End If

        If IsNew = False Then
            Me.HlFunctionCode.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=evt_gen_fnc&control=" & Me.TxtFunctionCode.ClientID & "&type=evt_gen_fnc');return false;")
        End If
        Me.HlAdNumber.Attributes.Add("onclick", "OpenRadWindow('', 'LookUp_AdNumber.aspx?form=evt_gen&cli=" & Me.CliCode & "&opener=" & Me.PageFilename() & "');return false;")

        Me.RbEndDate_Occur.Attributes.Add("onclick", "ClearTB('" & Me.RadDatePickerEndDate.DateInput.ClientID & "');")
        Me.RbEndDate_Date.Attributes.Add("onclick", "ClearTB('" & Me.TxtOccur.ClientID & "');")
        Me.RbEndTime_Time.Attributes.Add("onclick", "ClearTB('" & Me.TxtHours.ClientID & "');")
        'Me.RbEndTime_Hours.Attributes.Add("onclick", "ClearTB('" & Me.RadTimePickerStartTime.ClientID & "');ClearTB('" & Me.RadTimePickerEndTime.ClientID & "');")
        Me.RbEndTime_Hours.Attributes.Add("onclick", "ClearTB('" & Me.RadTimePickerEndTime.DateInput.ClientID & "');")
        Me.ImageButtonDeleteGenerator.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this Generator?');")
    End Sub

    Private Sub LoadEventGenList()
        Dim evt As New cEvents
        Dim dt As New DataTable
        If FromForm = "1" Then ' from job jacket
            dt = evt.EventGenGetList(Me.JobNumber, Me.JobComponentNbr)
            Me.TrGenDdl.Visible = True
            Me.TrLastGen.Visible = True
        Else 'from estimating
            dt = evt.EventGenGetList(Me.EstNumber, Me.EstComponentNbr, Me.EstQuoteNumber, Me.JobNumber, Me.JobComponentNbr)
            Me.TrGenDdl.Visible = True
            Me.TrLastGen.Visible = False
        End If
        With Me.DropEventGenerators
            .Items.Clear()
            Dim itm As New Telerik.Web.UI.RadComboBoxItem
            With itm
                .Text = "[Please select]"
                .Value = "-1"
            End With
            .Items.Insert(0, itm)
            Dim itm2 As New Telerik.Web.UI.RadComboBoxItem
            With itm2
                .Text = "[New]"
                .Value = "0"
            End With
            .Items.Insert(1, itm2)
            If dt.Rows.Count > 0 Then
                .DataValueField = "EVENT_GEN_ID"
                .DataTextField = "EVENT_GEN_LABEL"
                .DataSource = dt
                .DataBind()
            Else
                .SelectedIndex = 1
                .Enabled = False
            End If
        End With
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Me.SaveGenerator(False)
    End Sub

    Private Sub GetDaysToInsert(ByVal NumOccurences As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByRef chk As CheckBoxList)

    End Sub

    Private Function ValidateInput() As Boolean
        Me.LblMSG.Text = ""
        Dim v As New cValidations(Session("ConnString"))

        If Me.TxtShortDesc.Text.Replace(" ", "").Trim() = "" Then
            Me.LblMSG.Text = "Event Description is required"
            Me.TxtShortDesc.Focus()
            Return False
        End If

        If Me.UcEventType.SelectedIndex = 0 Then
            Me.LblMSG.Text = "Please select an Event Type"
            Me.UcEventType.Focus()
            Return False
        End If

        If Me.TxtFunctionCode.Text.Trim() = "" Then
            Me.LblMSG.Text = "Function Code is required"
            Me.TxtFunctionCode.Focus()
            Return False
        Else
            'validate function code
            If v.ValidateFunctionCodeEst(Me.TxtFunctionCode.Text) = False Then
                Me.LblMSG.Text = "Function Code invalid"
                Return False
            End If
        End If

        'validate ad number
        If Me.TxtAdNumber.Text.Trim() <> "" Then
            If v.ValidateAdNumber(Me.TxtAdNumber.Text) = False Then
                Me.LblMSG.Text = "Ad Number invalid"
                Me.TxtAdNumber.Focus()
                Return False
            End If
        End If

        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
            Me.ShowMessage("Start Date invalid")
            Return False
        End If

        If Me.RbEndDate_Occur.Checked = False And Me.RbEndDate_Date.Checked = False Then
            Me.LblMSG.Text = "Please select a Dates option"
            Return False
        End If

        If Me.RbEndDate_Occur.Checked = True Then
            If Me.TxtOccur.Text.Trim() = "" Then
                Me.TxtOccur.Focus()
                Me.LblMSG.Text = "Occurrences is required"
                Return False
            End If
            If IsNumeric(Me.TxtOccur.Text) = False Then
                Me.TxtOccur.Focus()
                Me.LblMSG.Text = "Occurrences is invalid"
                Return False
            End If
            If IsNumeric(Me.TxtOccur.Text) = True Then
                Me.TxtOccur.Text = CType(Me.TxtOccur.Text, Integer)
            End If
        End If

        If Me.RbEndDate_Date.Checked = True Then
            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("End Date invalid")
                Return False
            End If
        End If

        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True And MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid date range")
            End If
        End If

        If Me.RbDaysToInclude_Checkboxes.Checked = False And Me.RbDaysToInclude_Increment.Checked = False Then
            Me.LblMSG.Text = "Please select a Days to Include option"
            Return False
        End If
        If Me.RbDaysToInclude_Checkboxes.Checked = True Then
            Dim HasChecked As Boolean = False
            If Me.ChkAllDay.Checked = True Then 'If "all days" checked, might as well check all the rest
                For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                    Me.ChkListDays.Items(i).Selected = True
                Next
                HasChecked = True
            ElseIf Me.ChkAllDay.Checked = False Then 'make sure at least one day is checked
                For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                    If Me.ChkListDays.Items(i).Selected = True Then
                        HasChecked = True
                    End If
                Next
            End If
            'For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
            '    If Me.ChkListDays.Items(i).Selected = True Then
            '        HasChecked = True
            '    End If
            'Next

            If HasChecked = False Then
                Me.LblMSG.Text = "Please select Days"
                Return False
            End If
        End If

        If Me.RbDaysToInclude_Increment.Checked = True Then
            If Me.TxtDayIncrement.Text = "" Then
                Me.TxtDayIncrement.Focus()
                Me.LblMSG.Text = "Number of Days is required"
                Return False
            End If
            If IsNumeric(Me.TxtDayIncrement.Text) = False Then
                Me.TxtDayIncrement.Focus()
                Me.LblMSG.Text = "Number of Days invalid"
                Return False
            End If
            If IsNumeric(Me.TxtDayIncrement.Text) = True Then
                Me.TxtDayIncrement.Text = CType(Me.TxtDayIncrement.Text, Integer)
            End If
        End If

        If Me.RbEndTime_Hours.Checked = False And RbEndTime_Time.Checked = False Then
            Me.LblMSG.Text = "Please select a Times option"
            Return False
        End If

        If Me.RbEndTime_Hours.Checked = True Then
            If Me.TxtHours.Text.Trim() = "" Then
                Me.TxtHours.Focus()
                Me.LblMSG.Text = "Number of Hours is required"
                Return False
            End If
            If IsNumeric(Me.TxtHours.Text) = False Then
                Me.TxtHours.Focus()
                Me.LblMSG.Text = "Number of Hours invalid"
                Return False
            End If
            If IsNumeric(Me.TxtHours.Text) = True Then
                Dim n As Decimal = CType(Me.TxtHours.Text, Decimal)
                If n > 23.98 Then
                    n = 23.98
                End If
                Me.TxtHours.Text = n
            End If
        End If

        If Me.RbEndTime_Time.Checked = True Then
            If Me.RadTimePickerEndTime.DateInput.Text = "" Or Me.RadTimePickerEndTime.SelectedDate = Nothing Then
                Me.RadTimePickerEndTime.DateInput.Focus()
                Me.LblMSG.Text = "End Time is required"
                Return False
            End If
            'validate time?
        End If

        If Me.TxtLongDesc.Text.ToString().Replace(" ", "").Length > 32000 Then
            Me.TxtLongDesc.Focus()
            Me.LblMSG.Text = "Event Comment exceeds 32,000 characters"
            Return False
        End If

        If Me.UcEventType.EventTypeId = 0 Then
            Me.LblMSG.Text = "Event Type is required"
        End If

        Return True

    End Function

    Private Sub DropEventGenerators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropEventGenerators.SelectedIndexChanged
        Me.ImageButtonDeleteGenerator.Visible = False
        Select Case Me.DropEventGenerators.SelectedValue
            Case "-1" 'The "Please select" option
                Me.ClearForm()
            Case "0" 'The "New" selection
                'clear the form
                Me.ClearForm()
                Me.RblQuantityType.Items(0).Selected = True

                Me.RbEndDate_Occur.Checked = True
                Me.RbEndDate_Date.Checked = False

                Me.RbDaysToInclude_Checkboxes.Checked = False
                Me.RbDaysToInclude_Increment.Checked = True

                Me.RbEndTime_Hours.Checked = True
                Me.RbEndTime_Time.Checked = False

                Me.TxtShortDesc.Focus()
                'add generator record (and event?)

                Me.UcEventType.EventTypeId = 1
            Case Else 'It is an existing gen
                'load record
                If CType(Me.DropEventGenerators.SelectedValue, Integer) > 0 Then
                    Me.LoadGen(CType(Me.DropEventGenerators.SelectedValue, Integer))

                    Me.RbEndDate_Occur.Checked = True
                    Me.RbEndDate_Date.Checked = False

                    Me.RbEndTime_Hours.Checked = True
                    Me.RbEndTime_Time.Checked = False


                    Me.TxtShortDesc.Focus()
                    Me.ImageButtonDeleteGenerator.Visible = True
                End If
        End Select
    End Sub

    Private Sub LoadGen(ByVal EventGenId As Integer)
        Me.ClearForm()
        Dim evt As New cEvents
        Dim dt As New DataTable
        dt = evt.EventGenGetDetails(EventGenId)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("EVENT_GEN_LABEL")) = False Then
                Me.TxtShortDesc.Text = dt.Rows(0)("EVENT_GEN_LABEL")
            End If

            If IsDBNull(dt.Rows(0)("EVENT_GEN_DESC_LONG")) = False Then
                Me.TxtLongDesc.Text = dt.Rows(0)("EVENT_GEN_DESC_LONG")
            End If

            'If IsDBNull(dt.Rows(0)("TYPE")) = False Then
            '    ' dt.Rows(0)("TYPE")
            'Else

            'End If

            If IsDBNull(dt.Rows(0)("START_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("START_DATE")) = True Then

                    Me.RadDatePickerStartDate.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("START_DATE"))

                End If
            End If

            If IsDBNull(dt.Rows(0)("END_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("END_DATE")) = True Then

                    Me.RadDatePickerEndDate.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("END_DATE"))

                End If
            End If

            If IsDBNull(dt.Rows(0)("START_TIME")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("START_TIME")) = True Then
                    Try
                        Me.RadTimePickerStartTime.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("START_TIME"))
                        'End If
                    Catch ex As Exception
                    End Try
                End If
            End If

            If IsDBNull(dt.Rows(0)("END_TIME")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("END_TIME")) = True Then
                    Try
                        Dim strEnd As String = Convert.ToDateTime(dt.Rows(0)("END_TIME")).ToShortTimeString()
                        If strEnd = "11:58:00 PM" Or strEnd = "11:58 PM" Then
                            Me.RadTimePickerEndTime.SelectedDate = Convert.ToDateTime(Convert.ToDateTime(dt.Rows(0)("END_TIME")).ToShortDateString() & " 11:59 PM")
                        Else
                            Me.RadTimePickerEndTime.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("END_TIME"))
                        End If
                    Catch ex As Exception
                        Me.RadTimePickerEndTime.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("END_TIME"))
                    End Try
                End If
            End If

            If IsDBNull(dt.Rows(0)("OCCUR")) = False Then
                If IsNumeric(dt.Rows(0)("OCCUR")) = True Then
                    Me.TxtOccur.Text = dt.Rows(0)("OCCUR")
                End If
            End If

            Me.RbDaysToInclude_Increment.Checked = True
            Me.RbDaysToInclude_Checkboxes.Checked = False
            Me.TxtDayIncrement.Text = ""

            If IsDBNull(dt.Rows(0)("DAY_INCREMENT")) = False Then
                If IsNumeric(dt.Rows(0)("DAY_INCREMENT")) = True Then
                    Dim i As Integer = CType(dt.Rows(0)("DAY_INCREMENT"), Integer)
                    If i > 0 Then
                        Me.TxtDayIncrement.Text = dt.Rows(0)("DAY_INCREMENT").ToString()
                    End If
                End If
            End If

            Dim DayCounter As Integer = 0
            If IsDBNull(dt.Rows(0)("DAYS")) = False Then
                Dim StrDays As String = dt.Rows(0)("DAYS")
                StrDays = MiscFN.RemoveTrailingDelimiter(StrDays, ",")
                If StrDays.IndexOf("SUN") > -1 Then
                    Me.ChkListDays.Items(0).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(0).Selected = False
                End If
                If StrDays.IndexOf("M") > -1 Then
                    Me.ChkListDays.Items(1).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(1).Selected = False
                End If
                If StrDays.IndexOf("TU") > -1 Then
                    Me.ChkListDays.Items(2).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(2).Selected = False
                End If
                If StrDays.IndexOf("W") > -1 Then
                    Me.ChkListDays.Items(3).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(3).Selected = False
                End If
                If StrDays.IndexOf("TH") > -1 Then
                    Me.ChkListDays.Items(4).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(4).Selected = False
                End If
                If StrDays.IndexOf("F") > -1 Then
                    Me.ChkListDays.Items(5).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(5).Selected = False
                End If
                If StrDays.IndexOf("SA") > -1 Then
                    Me.ChkListDays.Items(6).Selected = True
                    DayCounter += 1
                Else
                    Me.ChkListDays.Items(6).Selected = False
                End If
            End If

            If DayCounter > 0 Then
                Me.RbDaysToInclude_Increment.Checked = False
                Me.RbDaysToInclude_Checkboxes.Checked = True
            End If

            If DayCounter = 7 Then
                Me.ChkAllDay.Checked = True
            Else
                Me.ChkAllDay.Checked = False
            End If

            If IsDBNull(dt.Rows(0)("QTY_HOURS")) = False Then
                If IsNumeric(dt.Rows(0)("QTY_HOURS")) = True Then
                    Me.TxtHours.Text = dt.Rows(0)("QTY_HOURS")
                End If
            End If

            'If IsDBNull(dt.Rows(0)("ALL_DAY")) = False Then
            '    Me.ChkAllDay.Checked = dt.Rows(0)("ALL_DAY")
            'End If

            If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                If IsNumeric(dt.Rows(0)("JOB_NUMBER")) = True Then
                    Me.JobNumber = CType(dt.Rows(0)("JOB_NUMBER"), Integer)
                End If
            End If

            If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                If IsNumeric(dt.Rows(0)("JOB_COMPONENT_NBR")) = True Then
                    Me.JobComponentNbr = CType(dt.Rows(0)("JOB_COMPONENT_NBR"), Integer)
                End If
            End If

            If IsDBNull(dt.Rows(0)("EST_NUMBER")) = False Then
                If IsNumeric(dt.Rows(0)("EST_NUMBER")) = True Then
                    Me.EstNumber = CType(dt.Rows(0)("EST_NUMBER"), Integer)
                End If
            End If

            If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                If IsNumeric(dt.Rows(0)("EST_COMPONENT_NBR")) = True Then
                    Me.EstComponentNbr = CType(dt.Rows(0)("EST_COMPONENT_NBR"), Integer)
                End If
            End If

            If IsDBNull(dt.Rows(0)("EST_QUOTE_NUMBER")) = False Then
                If IsNumeric(dt.Rows(0)("EST_QUOTE_NUMBER")) = True Then
                    Me.EstQuoteNumber = CType(dt.Rows(0)("EST_QUOTE_NUMBER"), Integer)
                End If
            End If

            If IsDBNull(dt.Rows(0)("FNC_CODE")) = False Then
                Me.TxtFunctionCode.Text = dt.Rows(0)("FNC_CODE").ToString()
            End If

            If IsDBNull(dt.Rows(0)("FNC_DESCRIPTION")) = False Then
                Me.TxtFunctionCodeDescription.Text = dt.Rows(0)("FNC_DESCRIPTION").ToString()
            End If

            If IsDBNull(dt.Rows(0)("AD_NUMBER")) = False Then
                Me.TxtAdNumber.Text = dt.Rows(0)("AD_NUMBER").ToString()
            End If

            If IsDBNull(dt.Rows(0)("AD_NBR_DESC")) = False Then
                Me.TxtAdNumberDescription.Text = dt.Rows(0)("AD_NBR_DESC").ToString()
            End If

            If IsDBNull(dt.Rows(0)("GENERATE_DATE")) = False Then
                Me.LblLastGen.Text = CType(dt.Rows(0)("GENERATE_DATE"), Date).ToShortDateString()
            End If
            Try
                If IsDBNull(dt.Rows(0)("QTY_TYPE")) = False Then
                    For i As Integer = 0 To Me.RblQuantityType.Items.Count - 1
                        If Me.RblQuantityType.Items(i).Value = dt.Rows(0)("QTY_TYPE") Then
                            Me.RblQuantityType.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                Else
                    Me.RblQuantityType.Items(0).Selected = True
                End If
            Catch ex As Exception
            End Try
            If IsDBNull(dt.Rows(0)("EVENT_TYPE_ID")) = False Then
                If IsNumeric(dt.Rows(0)("EVENT_TYPE_ID")) = True Then
                    Me.UcEventType.EventTypeId = CType(dt.Rows(0)("EVENT_TYPE_ID"), Integer)
                End If
            End If

        End If
    End Sub

    Private Sub ClearForm()
        Me.TxtShortDesc.Text = ""
        Me.TxtLongDesc.Text = ""
        Me.TxtFunctionCode.Text = ""
        Me.TxtAdNumber.Text = ""
        Me.RadDatePickerStartDate.Clear()
        Me.RadDatePickerEndDate.Clear()
        Me.TxtOccur.Text = ""
        Me.TxtDayIncrement.Text = ""
        For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
            Me.ChkListDays.Items(i).Selected = False
        Next
        Me.ChkAllDay.Checked = False
        Try
            Me.RadTimePickerStartTime.SelectedDate = Nothing
            Me.RadTimePickerEndTime.SelectedDate = Nothing
        Catch ex As Exception
        End Try
        Me.TxtHours.Text = ""
        Me.LblLastGen.Text = ""
        Me.TxtAdNumberDescription.Text = ""
        Me.TxtFunctionCodeDescription.Text = ""
        For x As Integer = 0 To Me.RblQuantityType.Items.Count - 1
            Me.RblQuantityType.Items(x).Selected = False
        Next
        'Try
        '    Me.DropEventGenerators.Focus()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub CloseAndRefresh()
        '    Me.CallFunctionOnParentPage("RefreshGrid")
        Me.CloseThisWindowAndRefreshCaller("")
    End Sub

    Private Sub ChkAllDay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAllDay.CheckedChanged
        For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
            Me.ChkListDays.Items(i).Selected = Me.ChkAllDay.Checked
        Next
        Me.TxtDayIncrement.Text = ""
    End Sub

    Private Sub BtnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGenerate.Click
        If Me.ValidateInput = True Then

            Dim evt As New cEvents()

            Dim TheStartDate As DateTime = Nothing
            Dim TheEndDate As DateTime = Nothing
            Dim TheStartTime As DateTime = Nothing
            Dim TheEndTime As DateTime = Nothing
            Dim EventType As String = "" 'default event "type"  
            Dim UseEndDate As Boolean = False
            Dim UseEndTime As Boolean = True
            Dim TheDayIncrement As Integer = 0
            Dim TheHours As Decimal = CType(0.0, Decimal)
            Me.StartDate = ""
            Me.EndDate = ""
            '


            'see if occurences in use
            Dim TheOccurences As Integer = 0
            If IsNumeric(Me.TxtOccur.Text) = True Then
                TheOccurences = CType(Me.TxtOccur.Text, Integer)
            Else
                TheOccurences = 0
            End If

            'validate start date, I think we'll always need this...
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Start Date invalid")
                Exit Sub
            Else
                TheStartDate = Me.RadDatePickerStartDate.SelectedDate
                Me.StartDate = TheStartDate.ToShortDateString()
            End If


            'need to clean up the start and end time here!?
            If Me.RadTimePickerStartTime.SelectedDate = Nothing Or Me.RadTimePickerStartTime.DateInput.Text = "" Then
                TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
            Else
                Try
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerStartTime.SelectedDate, DateTime).ToShortTimeString())
                Catch ex As Exception
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                End Try
            End If
            Me.RadTimePickerStartTime.SelectedDate = TheStartTime

            If Me.RadTimePickerEndTime.SelectedDate = Nothing Or Me.RadTimePickerEndTime.DateInput.Text = "" Then
                TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
            Else
                Try
                    Dim s As String = CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString()
                    If s = "12:00 AM" Then
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                    Else
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString())
                    End If
                Catch ex As Exception
                    TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                End Try
            End If
            Me.RadTimePickerEndTime.SelectedDate = TheEndTime

            'per Ellen: "if using occurences, "auto calc" the end date, if there is an enddate, then ignore occurence
            'changing to use radiobuttons
            If RbEndDate_Occur.Checked = False And RbEndDate_Date.Checked = False Then
                RbEndDate_Date.Checked = True
            End If

            Try
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    EndDate = CType(Me.RadDatePickerEndDate.SelectedDate, Date).ToShortDateString()
                End If
            Catch ex As Exception
                EndDate = ""
            End Try
            If cGlobals.wvIsDate(EndDate) = True And RbEndDate_Date.Checked = True Then
                UseEndDate = True
                TheEndDate = Convert.ToDateTime(cGlobals.wvCDate(EndDate))
            ElseIf EndDate.Trim() = "" And RbEndDate_Date.Checked = True Then
                UseEndDate = False
                EndDate = ""
                Me.LblMSG.Text = "End Date is required"
                Exit Sub
            ElseIf cGlobals.wvIsDate(EndDate) = False And RbEndDate_Date.Checked = True Then
                UseEndDate = False
                EndDate = ""
                Me.LblMSG.Text = "End Date invalid"
                Exit Sub
            End If

            If IsNumeric(Me.TxtOccur.Text) = True And RbEndDate_Occur.Checked = True Then
                UseEndDate = False
                TheEndDate = Nothing
                TheOccurences = CType(Me.TxtOccur.Text, Integer)
            ElseIf Me.TxtOccur.Text.Trim() = "" And RbEndDate_Occur.Checked = True Then
                Me.LblMSG.Text = "Occurrences is required"
                Exit Sub
            ElseIf IsNumeric(Me.TxtOccur.Text) = False And RbEndDate_Occur.Checked = True Then
                Me.LblMSG.Text = "Occurrences invalid"
                Exit Sub
            End If

            'Set the type
            If Me.FromForm = 0 Then 'Estimate
                EventType = "EEST"
                Me.JobNumber = 0
                Me.JobComponentNbr = 0
            ElseIf Me.FromForm = 1 Then 'jobjacket
                EventType = "EJC"
            End If

            Dim StrDays As String = ""
            Dim HasCheckedDays As Boolean = False
            For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                If Me.ChkListDays.Items(i).Selected = True Then
                    StrDays &= Me.ChkListDays.Items(i).Value & ","
                    HasCheckedDays = True
                End If
            Next
            StrDays = MiscFN.RemoveTrailingDelimiter(StrDays, ",")

            If IsNumeric(Me.TxtDayIncrement.Text) = True Then
                TheDayIncrement = CType(Me.TxtDayIncrement.Text, Integer)
            Else
                TheDayIncrement = 0
            End If

            'Set qty hours:
            If Me.RbEndTime_Hours.Checked = False And Me.RbEndTime_Time.Checked = False Then
                Me.RbEndTime_Time.Checked = True
            End If
            If IsNumeric(Me.TxtHours.Text) = True And Me.RbEndTime_Hours.Checked = True Then
                TheHours = CType(Me.TxtHours.Text, Decimal)
                If TheHours <= 0 Then
                    Try
                        Dim ts As TimeSpan
                        ts = TheEndTime.Subtract(TheStartTime)
                        TheHours = CType(ts.TotalHours, Decimal)
                    Catch ex As Exception
                        TheHours = CType(0.0, Decimal)
                    End Try
                Else
                    TheEndTime = DateAdd(DateInterval.Minute, TheHours * 60, TheStartTime)
                    If TheEndTime.ToShortTimeString() = "12:00 AM" Then
                        TheEndTime = DateAdd(DateInterval.Minute, -1, TheEndTime)
                        TheHours = TheHours - 0.02
                    End If
                End If
            ElseIf Me.TxtHours.Text.Trim() = "" And Me.RbEndTime_Hours.Checked = True Then
                Me.LblMSG.Text = "Hours is required"
                Exit Sub
            ElseIf IsNumeric(Me.TxtHours.Text) = False And Me.RbEndTime_Hours.Checked = True Then
                Me.LblMSG.Text = "Hours invalid"
                Exit Sub
            Else 'assume end time is set correctly
                Try
                    Dim ts As TimeSpan
                    ts = TheEndTime.Subtract(TheStartTime)
                    TheHours = CType(ts.TotalHours, Decimal)
                Catch ex As Exception
                    TheHours = CType(0.0, Decimal)
                End Try
            End If

            Me.TxtHours.Text = TheHours

            Dim rtn As String = ""
            Dim TheEvtGenId As Integer = 0 'WILL NEED TO SET THIS CORRECTLY TO BYPASS INSERT OF NEW EVENT_GEN

            'Adding a new record from job jacket
            If FromForm = 1 And CType(Me.DropEventGenerators.SelectedValue, Integer) = 0 Then
                TheEvtGenId = 0
            ElseIf FromForm = 1 And CType(Me.DropEventGenerators.SelectedValue, Integer) > 0 Then
                TheEvtGenId = CType(Me.DropEventGenerators.SelectedValue, Integer)
            ElseIf FromForm = 0 And CType(Me.DropEventGenerators.SelectedValue, Integer) = 0 Then
                TheEvtGenId = 0
            ElseIf FromForm = 0 And CType(Me.DropEventGenerators.SelectedValue, Integer) > 0 Then
                TheEvtGenId = CType(Me.DropEventGenerators.SelectedValue, Integer)
            End If

            Dim QtyType As Integer = 1
            Try
                QtyType = CType(Me.RblQuantityType.SelectedValue, Integer)
            Catch ex As Exception
                QtyType = 1
            End Try

            Dim TotalNumDays As Integer = 0 'datediff of start and end date
            Dim NumDaysChkList As Integer = 0 'just to see if any checkboxes are checked
            Dim NumHours As Decimal = CType(0.0, Decimal)
            Dim IsAllDay As Boolean = Me.ChkAllDay.Checked
            Dim ArLstDays As New ArrayList()

            'setup variables:

            'arraylist for easy searching
            For j As Integer = 0 To Me.ChkListDays.Items.Count - 1
                If Me.ChkListDays.Items(j).Selected = True Then
                    NumDaysChkList += 1
                    ArLstDays.Add(Me.ChkListDays.Items(j).Text)
                End If
            Next
            ArLstDays.Sort()

            'table to hold dates for insert
            Dim dtDates As New DataTable
            Dim Pk(0) As DataColumn

            Dim COL_INDEX As DataColumn = New DataColumn("INDEX")
            With COL_INDEX
                .DataType = GetType(Int32)
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Pk(0) = COL_INDEX
            Dim COL_DATE As DataColumn = New DataColumn("DATE")
            COL_DATE.DataType = GetType(String)
            Dim COL_MSG As DataColumn = New DataColumn("MSG")
            COL_MSG.DataType = GetType(String)
            With dtDates.Columns
                .Add(COL_INDEX)
                .Add(COL_DATE)
                .Add(COL_MSG)
            End With


            'add to datatable
            Dim CurrDate As Date = TheStartDate
            Dim TotalQtyHours As Decimal = 0.0
            Dim NewEndDate As DateTime = Nothing
            If TheOccurences > 0 And RbEndDate_Occur.Checked = True Then 'then the user is going to use data based on the number of occurences
                Dim idx As Integer  'to search arraylist
                'TotalQtyHours = TheHours * TheOccurences
                Dim ctr As Integer = TheOccurences
                Do While ctr > 0
                    idx = ArLstDays.BinarySearch(CurrDate.DayOfWeek.ToString())
                    ''If TheDayIncrement > 0 Then 'using the "every ____ days" thing
                    ''Else 'using the days checkboxlist
                    ''End If
                    Try
                        If TheDayIncrement > 0 And Me.RbDaysToInclude_Increment.Checked = True Then
                            Dim r As DataRow
                            r = dtDates.NewRow()
                            r("DATE") = CurrDate.ToShortDateString()
                            dtDates.Rows.Add(r)
                            ctr -= 1
                            CurrDate = DateAdd(DateInterval.Day, TheDayIncrement, CurrDate)
                        Else
                            If idx > -1 Then
                                Dim r As DataRow
                                r = dtDates.NewRow()
                                r("DATE") = CurrDate.ToShortDateString()
                                dtDates.Rows.Add(r)
                                ctr -= 1
                            End If
                            CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                        End If
                        NewEndDate = CurrDate
                    Catch ex As Exception
                        Exit Do
                    End Try
                Loop
                TheEndDate = NewEndDate
            ElseIf cGlobals.wvIsDate(Me.EndDate) = True Then 'then the user is going to use data based on start and end date
                TheOccurences = 0
                If Not TheStartDate = Nothing And Not TheEndDate = Nothing Then
                    'THIS IS a max number of days
                    TotalNumDays = MiscFN.GetTotalDays(TheStartDate, TheEndDate) 'make sure this works for one day...not sure datediff returns 0 or 1 for same day
                    Dim idx As Integer  'to search arraylist
                    Do While TotalNumDays >= 0 And DateDiff(DateInterval.Day, TheEndDate, CurrDate) <= 0
                        idx = ArLstDays.BinarySearch(CurrDate.DayOfWeek.ToString())
                        Try
                            If TheDayIncrement > 0 And Me.RbDaysToInclude_Increment.Checked = True Then
                                Dim r As DataRow
                                r = dtDates.NewRow()
                                r("DATE") = CurrDate.ToShortDateString()
                                dtDates.Rows.Add(r)
                                TotalNumDays -= 1
                                TheOccurences += 1
                                CurrDate = DateAdd(DateInterval.Day, TheDayIncrement, CurrDate)
                            Else
                                If idx > -1 Then
                                    Dim r As DataRow
                                    r = dtDates.NewRow()
                                    r("DATE") = CurrDate.ToShortDateString()
                                    dtDates.Rows.Add(r)
                                    TotalNumDays -= 1
                                    TheOccurences += 1
                                End If
                                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            End If
                        Catch ex As Exception
                            Exit Do
                        End Try
                    Loop
                End If
            End If

            If TheStartDate = TheEndDate And TheOccurences = 0 Then
                TheOccurences = 1
            End If

            If Me.RblQuantityType.Items(0).Selected = True Then
                TotalQtyHours = TheOccurences
            Else
                TotalQtyHours = TheHours * TheOccurences
            End If

            ''override if user puts in occurences:
            'If IsNumeric(Me.TxtOccur.Text) = True Then
            '    If CType(Me.TxtOccur.Text, Integer) > 0 Then
            '        If Me.RblQuantityType.Items(0).Selected = True Then
            '            TotalQtyHours = CType(Me.TxtOccur.Text, Integer)
            '        Else
            '            TotalQtyHours = TheHours * CType(Me.TxtOccur.Text, Integer)
            '        End If
            '    End If
            'End If

            If Me.TxtHours.Text = "23.98" And Me.RbEndTime_Hours.Checked = True Then
                TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                'make sure hours in range...it should only be 23.98 if event started at midnight..
                Try
                    Dim ts As TimeSpan
                    ts = TheEndTime.Subtract(TheStartTime)
                    TheHours = CType(ts.TotalHours, Decimal)
                Catch ex As Exception
                    TheHours = CType(0.0, Decimal)
                End Try
                Me.TxtHours.Text = TheHours
            End If

            If TheHours <= 0 Then 'end time needs to go to next day:
                'TheHours = TheHours + 24
                'TheEndTime = DateAdd(DateInterval.Day, 1, TheEndTime)
                'new req, don't allow
                Me.LblMSG.Text = "Events cannot cross days"
                Exit Sub
            End If
            Try
                If TheStartTime.ToShortDateString() <> TheEndTime.ToShortDateString() Then
                    Me.LblMSG.Text = "Events cannot cross days"
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Me.TxtHours.Text = Math.Round(TheHours, 2, MidpointRounding.AwayFromZero)

            'if coming from estimate, this will add the generator record and one function record
            'thought I could do the same when coming from job jacket, but i think it will need to be separate...
            '20090428...no longer adding the estimate record...need to do it after the events are generated
            rtn = evt.EventGenAddNew(Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, EventType, TheStartDate, TheEndDate, _
                                     TheStartTime, TheEndTime, _
                                       TheOccurences, TheDayIncrement, StrDays, TheHours, Me.ChkAllDay.Checked, Me.JobNumber, _
                                       Me.JobComponentNbr, Me.EstNumber, Me.EstComponentNbr, Me.EstQuoteNumber, Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, _
                                       Now, Session("UserCode"), Now, Session("UserCode"), 1, Me.EstRevNumber, TheEvtGenId, QtyType, _
                                       Me.UcEventType.EventTypeId)

            If IsNumeric(rtn) = True Then
                TheEvtGenId = CType(rtn, Integer)
            Else
                Me.LblMSG.Text = rtn 'set an error message
            End If

            'this will save actual events
            If FromForm = 1 And TheEvtGenId > 0 Then
                For n As Integer = 0 To dtDates.Rows.Count - 1
                    'Me.LblMSG.Text &= dtDates.Rows(n)("DATE").ToString() & "<br />"
                    'quick stop of crossing over...
                    Dim CrossesOver As Boolean = False
                    Dim CorrectedStartTime As DateTime = Convert.ToDateTime(Convert.ToDateTime(dtDates.Rows(n)("DATE")).ToShortDateString() & " " & TheStartTime.ToShortTimeString())
                    Dim CorrectedEndTime As DateTime = Convert.ToDateTime(Convert.ToDateTime(dtDates.Rows(n)("DATE")).ToShortDateString() & " " & TheEndTime.ToShortTimeString())
                    Dim ThisHours As Decimal = 0
                    Try
                        Dim ts As TimeSpan
                        ts = CorrectedEndTime.Subtract(CorrectedStartTime)
                        ThisHours = CType(ts.TotalHours, Decimal)
                    Catch ex As Exception
                        ThisHours = CType(0.0, Decimal)
                    End Try

                    If ThisHours <= 0 Then 'end time needs to go to next day:
                        ThisHours = ThisHours + 24
                        CorrectedEndTime = DateAdd(DateInterval.Day, 1, CorrectedEndTime)
                        CrossesOver = True
                    End If

                    If CrossesOver = False Then
                        evt.EventAddNew(Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, EventType, Convert.ToDateTime(dtDates.Rows(n)("DATE")), Me.ChkAllDay.Checked, TheHours, _
                                         CorrectedStartTime, CorrectedEndTime, "", Me.JobNumber, Me.JobComponentNbr, Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, _
                                         Me.TxtLongDesc.Text, 0, TheEvtGenId, Convert.ToDateTime(Now()), Session("UserCode"), QtyType, Me.UcEventType.EventTypeId)
                    End If
                Next
                'Update the generator info:
                Try
                    Dim StrSQL As String = "UPDATE EVENT_GEN WITH(ROWLOCK) SET GENERATE_DATE = '" & Now.Date & "', GENERATE_USER = '" & Session("UserCode") & "' WHERE EVENT_GEN_ID = " & TheEvtGenId & ";"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                Catch ex As Exception
                End Try
            End If

            If FromForm = 0 Then 'Only when adding the generator? Only when adding from estimate?
                ''''Try
                ''''    Dim StrSQL As String = ""
                ''''    Using MyConn As New SqlConnection(Session("ConnString"))
                ''''        MyConn.Open()
                ''''        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                ''''        Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                ''''        Try
                ''''            MyCmd.ExecuteNonQuery()
                ''''            MyTrans.Commit()
                ''''        Catch ex As Exception
                ''''            MyTrans.Rollback()
                ''''            Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                ''''        Finally
                ''''            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                ''''        End Try
                ''''    End Using
                ''''Catch ex As Exception
                ''''End Try
            End If
            If FromForm = 0 Then 'add the estimate fn
                Try
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim str As String = est.InsertNewFunction(Me.EstNumber, Me.EstComponentNbr, Me.EstQuoteNumber, Me.EstRevNumber, Me.TxtFunctionCode.Text, Session("UserCode"), "", "", "", TotalQtyHours, TheEvtGenId, TheOccurences)
                    If IsNumeric(str) = False Then
                        Me.LblMSG.Text = str
                    End If
                Catch ex As Exception
                    Me.LblMSG.Text = ex.Message.ToString()
                End Try
            End If
            Me.CloseAndRefresh()


        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.CloseAndRefresh()
    End Sub

    Private Sub Event_Generator_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Me.DropEventGenerators.SelectedIndex = 0 Then
            Me.EnableForm(False)
        Else
            Me.EnableForm(True)

            If Me.DropEventGenerators.SelectedIndex > 1 Then 'a generator is loaded...
                Me.BtnSave.Text = "Update"
            Else
                Me.BtnSave.Text = "Save"
            End If
            If Me.DropEventGenerators.SelectedIndex = 1 Then 'on a "new" generator form
                Me.BtnSaveAsNew.Visible = False
                Me.BtnSave.Text = "Save"
                If Not Page.IsPostBack And Not Page.IsCallback Then
                    Me.RbEndDate_Occur.Checked = True
                    Me.RbEndDate_Date.Checked = False
                    Me.RbDaysToInclude_Checkboxes.Checked = False
                    Me.RbDaysToInclude_Increment.Checked = True
                    Me.RbEndTime_Hours.Checked = True
                    Me.RbEndTime_Time.Checked = False
                End If
            Else
                Me.BtnSaveAsNew.Visible = True
                Me.BtnSave.Text = "Update"
            End If
            Me.BtnSave.ToolTip = Me.BtnSave.Text & " generator details"


            If Me.RbEndDate_Occur.Checked = True Then
                Me.TxtOccur.Enabled = True
                Me.TxtOccur.CssClass = "RequiredInput"
                With Me.RadDatePickerEndDate
                    .Enabled = False
                    .DateInput.CssClass = Nothing
                End With
                'Me.TxtEndDate.Text = ""
            End If
            If Me.RbEndDate_Date.Checked = True Then
                Me.TxtOccur.Enabled = False
                Me.TxtOccur.CssClass = Nothing
                With Me.RadDatePickerEndDate
                    .Enabled = True
                    .DateInput.CssClass = "RequiredInput"
                    .DateInput.Attributes.Add("onclick", "ClearTB('" & Me.TxtOccur.ClientID & "');")
                End With
            End If
            If Me.RbDaysToInclude_Checkboxes.Checked = True Then
                Me.ChkAllDay.Enabled = True
                Me.ChkListDays.Enabled = True
                'Me.TxtDayIncrement.Text = ""
                Me.TxtDayIncrement.CssClass = Nothing
                Me.TxtDayIncrement.Enabled = False
            End If
            If Me.RbDaysToInclude_Increment.Checked = True Then
                Me.ChkAllDay.Checked = False
                Me.ChkAllDay.Enabled = False
                For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                    Me.ChkListDays.Items(i).Selected = False
                Next
                Me.ChkListDays.Enabled = False
                Me.TxtDayIncrement.CssClass = "RequiredInput"
                Me.TxtDayIncrement.Enabled = True
            End If
            If RbEndTime_Hours.Checked = True Then
                Me.TxtHours.Enabled = True
                Me.TxtHours.CssClass = "RequiredInput"
                'Me.RadTimePickerEndTime.Text = ""
                Me.RadTimePickerEndTime.Enabled = False
                Me.RadTimePickerEndTime.DateInput.CssClass = Nothing
            End If
            If RbEndTime_Time.Checked = True Then
                Me.RadTimePickerEndTime.Enabled = True
                Me.RadTimePickerEndTime.DateInput.CssClass = "RequiredInput"
                'Me.TxtHours.Text = ""
                Me.TxtHours.Enabled = False
                Me.TxtHours.CssClass = Nothing
            End If
        End If

    End Sub

    Private Sub RbDaysToInclude_Checkboxes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDaysToInclude_Checkboxes.CheckedChanged
        If Me.RbDaysToInclude_Checkboxes.Checked = True Then
            Me.RbDaysToInclude_Increment.Checked = False
            Me.TxtDayIncrement.Text = ""
        End If
    End Sub

    Private Sub RbDaysToInclude_Increment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDaysToInclude_Increment.CheckedChanged
        If Me.RbDaysToInclude_Increment.Checked = True Then

            Me.RbDaysToInclude_Checkboxes.Checked = False

            Me.ChkAllDay.Checked = False
            For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                Me.ChkListDays.Items(i).Selected = False
            Next


        End If
    End Sub

    Private Sub EnableForm(ByVal EnableIt As Boolean)
        'Me.LblLastGen.Text = ""
        Me.TxtShortDesc.Enabled = EnableIt
        Me.TxtLongDesc.Enabled = EnableIt
        Me.TxtFunctionCode.Enabled = EnableIt
        Me.TxtFunctionCodeDescription.Enabled = EnableIt
        Me.TxtAdNumber.Enabled = EnableIt
        Me.TxtAdNumberDescription.Enabled = EnableIt
        Me.RblQuantityType.Enabled = EnableIt
        Me.RadDatePickerStartDate.Enabled = EnableIt
        Me.RbEndDate_Occur.Enabled = EnableIt
        Me.TxtOccur.Enabled = EnableIt
        Me.RbEndDate_Date.Enabled = EnableIt
        Me.RadDatePickerEndDate.Enabled = EnableIt
        Me.RbDaysToInclude_Checkboxes.Enabled = EnableIt
        Me.ChkAllDay.Enabled = EnableIt
        Me.ChkListDays.Enabled = EnableIt
        Me.RbDaysToInclude_Increment.Enabled = EnableIt
        Me.TxtDayIncrement.Enabled = EnableIt
        Me.RadTimePickerStartTime.Enabled = EnableIt
        Me.RbEndTime_Hours.Enabled = EnableIt
        Me.TxtHours.Enabled = EnableIt
        Me.RbEndTime_Time.Enabled = EnableIt
        With Me.RadTimePickerEndTime
            .Enabled = EnableIt
        End With
        Me.BtnSave.Enabled = EnableIt
        Me.BtnGenerate.Enabled = EnableIt
        Me.BtnSaveAsNew.Enabled = EnableIt
        If EnableIt = True Then
            With Me.RadDatePickerStartDate
                '.DateInput.Text = ""
                '.SelectedDate = Nothing
                .Enabled = True
            End With
            With Me.RadDatePickerEndDate
                '.DateInput.Text = ""
                '.SelectedDate = Nothing
                .Enabled = True
                .DateInput.Attributes.Add("onclick", "ClearTB('" & Me.TxtOccur.ClientID & "')")
            End With
        Else
            'Me.LitStartDate.Text = ""
            'Me.LitEndDate.Text = ""
            With Me.RadDatePickerStartDate
                .DateInput.Text = ""
                .SelectedDate = Nothing
                .Enabled = False
            End With
            With Me.RadDatePickerEndDate
                .DateInput.Text = ""
                .SelectedDate = Nothing
                .Enabled = False
            End With
        End If
    End Sub

    Private Sub ChkListDays_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkListDays.SelectedIndexChanged
        Dim AllChecked As Boolean = True
        For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
            If Me.ChkListDays.Items(i).Selected = False Then
                If AllChecked = True Then
                    AllChecked = False
                End If
            End If
        Next

        Me.ChkAllDay.Checked = AllChecked

    End Sub

    Private Function SaveGenerator(ByVal ForceSaveAsNew As Boolean) As String
        Try
            If Me.ValidateInput() = False Then
                Exit Function
            End If
            Me.EventGeneratorId = CType(Me.DropEventGenerators.SelectedValue, Integer)
            'update the generator record
            Dim evt As New cEvents()
            Dim TheStartDate As DateTime = Nothing
            Dim TheEndDate As DateTime = Nothing
            Dim TheStartTime As DateTime = Nothing
            Dim TheEndTime As DateTime = Nothing
            Dim EventType As String = "" 'default event "type"  
            Dim UseEndDate As Boolean = True
            Dim UseEndTime As Boolean = True
            Dim TheDayIncrement As Integer = 0
            Dim TheHours As Decimal = CType(0.0, Decimal)


            'see if occurences in use
            Dim TheOccurences As Integer = 0
            If IsNumeric(Me.TxtOccur.Text) = True Then
                TheOccurences = CType(Me.TxtOccur.Text, Integer)
            Else
                TheOccurences = 0
            End If

            'validate start date, I think we'll always need this...
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Start Date invalid")
                Exit Function
            Else
                TheStartDate = Me.RadDatePickerStartDate.SelectedDate
                Me.StartDate = TheStartDate.ToShortDateString()
            End If



            'need to clean up the start and end time here!?
            If Me.RadTimePickerStartTime.SelectedDate = Nothing Then
                TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
            Else
                Try
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerStartTime.SelectedDate, DateTime).ToShortTimeString())
                Catch ex As Exception
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                End Try
            End If
            Me.RadTimePickerStartTime.SelectedDate = TheStartTime

            If Me.RadTimePickerEndTime.SelectedDate = Nothing Or Me.RadTimePickerEndTime.DateInput.Text = "" Then
                TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
            Else
                Try
                    Dim s As String = CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString()
                    If s = "12:00 AM" Then
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                    Else
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString())
                    End If
                Catch ex As Exception
                    TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                End Try
            End If
            Me.RadTimePickerEndTime.SelectedDate = TheEndTime

            'per Ellen: "if using occurences, "auto calc" the end date, if there is an enddate, then ignore occurence
            'changing to use radiobuttons
            If RbEndDate_Occur.Checked = False And RbEndDate_Date.Checked = False Then
                RbEndDate_Date.Checked = True
            End If

            Try
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    EndDate = CType(Me.RadDatePickerEndDate.SelectedDate, Date).ToShortDateString()
                End If
            Catch ex As Exception
                EndDate = ""
            End Try
            If cGlobals.wvIsDate(EndDate) = True And RbEndDate_Date.Checked = True Then
                UseEndDate = True
                TheEndDate = Convert.ToDateTime(cGlobals.wvCDate(EndDate))
            ElseIf EndDate.Trim() = "" And RbEndDate_Date.Checked = True Then
                UseEndDate = False
                EndDate = ""
                Me.LblMSG.Text = "End Date is required"
                Exit Function
            ElseIf cGlobals.wvIsDate(EndDate) = False And RbEndDate_Date.Checked = True Then
                UseEndDate = False
                EndDate = ""
                Me.LblMSG.Text = "End Date invalid"
                Exit Function
            End If

            If IsNumeric(Me.TxtOccur.Text) = True And RbEndDate_Occur.Checked = True Then
                UseEndDate = False
                TheEndDate = Nothing
                TheOccurences = CType(Me.TxtOccur.Text, Integer)
            ElseIf Me.TxtOccur.Text.Trim() = "" And RbEndDate_Occur.Checked = True Then
                Me.LblMSG.Text = "Occurrences is required"
                Exit Function
            ElseIf IsNumeric(Me.TxtOccur.Text) = False And RbEndDate_Occur.Checked = True Then
                Me.LblMSG.Text = "Occurrences invalid"
                Exit Function
            End If


            ''exit if not enough info to decide what to do
            'If UseEndDate = False And TheOccurences = 0 Then 'not enough info
            '    Me.LblMSG.Text = "Please select an end date or a number of occurrences."
            '    Exit Sub
            'End If

            'Set the type
            If Me.FromForm = 0 Then 'Estimate
                EventType = "EEST"
                Me.JobNumber = 0
                Me.JobComponentNbr = 0
            ElseIf Me.FromForm = 1 Then 'jobjacket
                EventType = "EJC"
            End If

            Dim StrDays As String = ""
            Dim HasCheckedDays As Boolean = False
            For i As Integer = 0 To Me.ChkListDays.Items.Count - 1
                If Me.ChkListDays.Items(i).Selected = True Then
                    StrDays &= Me.ChkListDays.Items(i).Value & ","
                    HasCheckedDays = True
                End If
            Next
            StrDays = MiscFN.RemoveTrailingDelimiter(StrDays, ",")

            If IsNumeric(Me.TxtDayIncrement.Text) = True Then
                TheDayIncrement = CType(Me.TxtDayIncrement.Text, Integer)
            Else
                TheDayIncrement = 0
            End If

            'Set qty hours:
            If Me.RbEndTime_Hours.Checked = False And Me.RbEndTime_Time.Checked = False Then
                Me.RbEndTime_Time.Checked = True
            End If
            If IsNumeric(Me.TxtHours.Text) = True And Me.RbEndTime_Hours.Checked = True Then
                TheHours = CType(Me.TxtHours.Text, Decimal)
                If TheHours <= 0 Then
                    Try
                        Dim ts As TimeSpan
                        ts = TheEndTime.Subtract(TheStartTime)
                        TheHours = CType(ts.TotalHours, Decimal)
                    Catch ex As Exception
                        TheHours = CType(0.0, Decimal)
                    End Try
                Else
                    TheEndTime = DateAdd(DateInterval.Minute, TheHours * 60, TheStartTime)
                    'TheEndTime = DateAdd(DateInterval.Hour, TheHours, TheStartTime)
                    If TheEndTime.ToShortTimeString() = "12:00 AM" Then
                        TheEndTime = DateAdd(DateInterval.Minute, -1, TheEndTime)
                        TheHours = TheHours - 0.02
                    End If
                End If
            ElseIf Me.TxtHours.Text.Trim() = "" And Me.RbEndTime_Hours.Checked = True Then
                Me.LblMSG.Text = "Hours is required"
                Exit Function
            ElseIf IsNumeric(Me.TxtHours.Text) = False And Me.RbEndTime_Hours.Checked = True Then
                Me.LblMSG.Text = "Hours invalid"
                Exit Function
            Else 'assume end time is set correctly
                Try
                    Dim ts As TimeSpan
                    ts = TheEndTime.Subtract(TheStartTime)
                    TheHours = CType(ts.TotalHours, Decimal)
                Catch ex As Exception
                    TheHours = CType(0.0, Decimal)
                End Try
            End If


            Dim QtyType As Integer = 1
            Try
                QtyType = CType(Me.RblQuantityType.SelectedValue, Integer)
            Catch ex As Exception
                QtyType = 1
            End Try

            'JUST NEED TO GET THE CORRECT OCCURRENCES:
            'arraylist for easy searching
            Dim ArLstDays As New ArrayList()
            Dim NumDaysChkList As Integer = 0 'just to see if any checkboxes are checked
            For j As Integer = 0 To Me.ChkListDays.Items.Count - 1
                If Me.ChkListDays.Items(j).Selected = True Then
                    NumDaysChkList += 1
                    ArLstDays.Add(Me.ChkListDays.Items(j).Text)
                End If
            Next
            ArLstDays.Sort()

            Dim TotalNumDays As Integer = 0 'datediff of start and end date
            Dim CurrDate As Date = TheStartDate
            Dim TotalQtyHours As Decimal = 0.0
            Dim NewEndDate As DateTime = Nothing
            If TheOccurences > 0 And RbEndDate_Occur.Checked = True Then 'then the user is going to use data based on the number of occurences
                Dim idx As Integer  'to search arraylist
                'TotalQtyHours = TheHours * TheOccurences
                Dim ctr As Integer = TheOccurences
                Do While ctr > 0
                    idx = ArLstDays.BinarySearch(CurrDate.DayOfWeek.ToString())
                    Try
                        If TheDayIncrement > 0 And Me.RbDaysToInclude_Increment.Checked = True Then
                            ctr -= 1
                            CurrDate = DateAdd(DateInterval.Day, TheDayIncrement, CurrDate)
                        Else
                            If idx > -1 Then
                                ctr -= 1
                            End If
                            CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                        End If
                        NewEndDate = CurrDate
                    Catch ex As Exception
                        Exit Do
                    End Try
                Loop
                TheEndDate = NewEndDate.AddDays(-1)
            ElseIf cGlobals.wvIsDate(Me.EndDate) = True And RbEndDate_Date.Checked = True Then 'then the user is going to use data based on start and end date
                TheOccurences = 0
                If Not TheStartDate = Nothing And Not TheEndDate = Nothing Then
                    'THIS IS a max number of days
                    TotalNumDays = MiscFN.GetTotalDays(TheStartDate, TheEndDate) 'make sure this works for one day...not sure datediff returns 0 or 1 for same day
                    Dim idx As Integer  'to search arraylist
                    Do While TotalNumDays >= 0 And DateDiff(DateInterval.Day, TheEndDate, CurrDate) <= 0
                        idx = ArLstDays.BinarySearch(CurrDate.DayOfWeek.ToString())
                        Try
                            If TheDayIncrement > 0 And Me.RbDaysToInclude_Increment.Checked = True Then
                                TotalNumDays -= 1
                                TheOccurences += 1
                                CurrDate = DateAdd(DateInterval.Day, TheDayIncrement, CurrDate)
                            Else
                                If idx > -1 Then
                                    TotalNumDays -= 1
                                    TheOccurences += 1
                                End If
                                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            End If
                        Catch ex As Exception
                            Exit Do
                        End Try
                    Loop
                End If
            End If

            If TheStartDate = TheEndDate And TheOccurences = 0 Then
                TheOccurences = 1
            End If

            If Me.TxtHours.Text = "23.98" And Me.RbEndTime_Hours.Checked = True Then
                TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                'make sure hours in range...it should only be 23.98 if event started at midnight..
                Try
                    Dim ts As TimeSpan
                    ts = TheEndTime.Subtract(TheStartTime)
                    TheHours = CType(ts.TotalHours, Decimal)
                Catch ex As Exception
                    TheHours = CType(0.0, Decimal)
                End Try
                Me.TxtHours.Text = TheHours
            End If

            'If (Me.RadTimePickerStartTime.Text = Me.RadTimePickerEndTime.Text) And Me.RbEndTime_Time.Checked = True Then
            '    TheEndTime = DateAdd(DateInterval.Minute, -1, TheEndTime)
            '    Try
            '        Dim ts As TimeSpan
            '        ts = TheEndTime.Subtract(TheStartTime)
            '        TheHours = CType(ts.TotalHours, Decimal)
            '    Catch ex As Exception
            '        TheHours = CType(0.0, Decimal)
            '    End Try
            '    Me.TxtHours.Text = TheHours
            'End If

            If TheHours <= 0 Then 'end time needs to go to next day:
                'TheHours = TheHours + 24
                'TheEndTime = DateAdd(DateInterval.Day, 1, TheEndTime)
                'new req, don't allow
                Me.LblMSG.Text = "Events cannot cross days"
                Exit Function
            End If
            Try
                If TheStartTime.ToShortDateString() <> TheEndTime.ToShortDateString() Then
                    Me.LblMSG.Text = "Events cannot cross days"
                    Exit Function
                End If
            Catch ex As Exception
            End Try

            Me.TxtHours.Text = Math.Round(TheHours, 2, MidpointRounding.AwayFromZero)

            Dim rtn As String = ""
            If ForceSaveAsNew = False Then 'normal save button
                If CType(Me.DropEventGenerators.SelectedValue, Integer) = 0 Then 'new generator record, but no events
                    rtn = evt.EventGenAddNew(Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, EventType, TheStartDate, TheEndDate, _
                                             TheStartTime, TheEndTime, _
                                               TheOccurences, TheDayIncrement, StrDays, TheHours, Me.ChkAllDay.Checked, Me.JobNumber, _
                                               Me.JobComponentNbr, Me.EstNumber, Me.EstComponentNbr, Me.EstQuoteNumber, Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, _
                                               Now, Session("UserCode"), Now, Session("UserCode"), 1, Me.EstRevNumber, 0, QtyType, _
                                               Me.UcEventType.EventTypeId)
                    'REBIND AND SET DDL HERE
                    If IsNumeric(rtn) = True Then
                        Me.LoadEventGenList()
                        MiscFN.RadComboBoxSetIndex(Me.DropEventGenerators, rtn, False, False)
                        Me.LoadGen(CType(rtn, Integer))
                    Else
                        Me.LblMSG.Text = "Error creating generator:  " & rtn
                        Exit Function
                    End If

                ElseIf CType(Me.DropEventGenerators.SelectedValue, Integer) > 0 Then
                    rtn = evt.EventGenUpdate(Me.EventGeneratorId, Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, EventType, TheStartDate, _
                                             TheEndDate, TheStartTime, TheEndTime, TheOccurences, TheDayIncrement, StrDays, TheHours, _
                                             Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, QtyType, Me.UcEventType.EventTypeId)
                    Me.LoadGen(CType(Me.DropEventGenerators.SelectedValue, Integer))
                End If
            ElseIf ForceSaveAsNew = True Then

                rtn = evt.EventGenAddNew(Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, EventType, TheStartDate, TheEndDate, _
                                         TheStartTime, TheEndTime, _
                                           TheOccurences, TheDayIncrement, StrDays, TheHours, Me.ChkAllDay.Checked, Me.JobNumber, _
                                           Me.JobComponentNbr, Me.EstNumber, Me.EstComponentNbr, Me.EstQuoteNumber, Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, _
                                           Now, Session("UserCode"), Now, Session("UserCode"), 1, Me.EstRevNumber, 0, QtyType, _
                                           Me.UcEventType.EventTypeId)
                'REBIND AND SET DDL HERE
                If IsNumeric(rtn) = True Then
                    Me.LoadEventGenList()
                    MiscFN.RadComboBoxSetIndex(Me.DropEventGenerators, rtn, False, False)
                    Me.LoadGen(CType(rtn, Integer))
                Else
                    Me.LblMSG.Text = "Error creating generator:  " & rtn
                    Exit Function
                End If

            End If

            'Me.CloseAndRefresh()

            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Private Sub BtnSaveAsNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveAsNew.Click
        Me.SaveGenerator(True)
    End Sub

    Private Sub ImageButtonDeleteGenerator_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDeleteGenerator.Click
        Me.LblMSG.Text = ""
        Dim evt As New cEvents()
        Dim i As Integer = evt.EventGenDelete(CType(Me.DropEventGenerators.SelectedValue, Integer))
        Select Case i
            Case -1
                Me.LblMSG.Text = "Error deleting Generator"
            Case Is = 1
                Me.LblMSG.Text = "This Generator has been used to generate an event and cannot be deleted"
            Case Is > 1
                Me.LblMSG.Text = "This Generator has been used to generate " & i.ToString() & " events and cannot be deleted"
            Case Is = 0
                Me.LoadEventGenList()
                Me.ClearForm()
        End Select
    End Sub

End Class