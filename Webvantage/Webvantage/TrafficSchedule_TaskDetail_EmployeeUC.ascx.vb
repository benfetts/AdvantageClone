Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports eWorld
Imports System.Drawing

Partial Public Class TrafficSchedule_TaskDetail_EmployeeUC
    Inherits Webvantage.BaseChildPageUserControl

    Private _RowCount As Integer = 0
    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public dHoursAllowedTotal As Double = 0
    Public dHoursPostedTotal As Double = 0
    Public dQuotedHoursTotal As Double = 0

    Public Property Employee_Assigned() As String
        Get
            Return Me.TxtEmployeesList.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtEmployeesList.Text = value.Trim
        End Set
    End Property

    Public ReadOnly Property EmployeeGrid() As Telerik.Web.UI.RadGrid
        Get
            Return RadGridEmployees2
        End Get
    End Property


    Public ReadOnly Property RowCount() As Integer
        Get
            Return _RowCount
        End Get
    End Property

    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                Dim oNewDT As DataTable
                Dim dc As New DataColumn("iSortItem", System.Type.GetType("System.Int32"))
                dc.DefaultValue = 1
                dc.AllowDBNull = False
                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                oNewDT = s.GetTaskEmpList(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))
                oNewDT.Columns.Add(dc)
                'perform sort
                For Each d As DataRow In oNewDT.Rows
                    If d.Item("EMP_CODE").ToString() = CStr(Session("EmpCode")) Then
                        d.Item("iSortItem") = 0
                    End If
                Next
                oNewDT.DefaultView.Sort = "iSortItem ASC,EMP_CODE ASC"
                _RowCount = oNewDT.Rows.Count
                If _RowCount > 0 Then
                    Me.RadCalendarShared.Visible = True
                Else
                    Me.RadCalendarShared.Visible = False
                End If
                Return oNewDT
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property

    Public Sub RefreshEmployeeGrid()
        LoadEmployee()
        Me.RadGridEmployees2.DataSource = Me.DataSource
        Me.RadGridEmployees2.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.imgBtnEmployees.ToolTip = "Add Employees"
            Session("ShowQuotedHours") = False
            Me.JobNumber = Request.QueryString("JobNum")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNum")

            Dim CurrentQueryString As New AdvantageFramework.Web.QueryString
            CurrentQueryString = CurrentQueryString.FromCurrent

            If CurrentQueryString.JobNumber > 0 Then Me.JobNumber = CurrentQueryString.JobNumber
            If CurrentQueryString.JobComponentNumber > 0 Then Me.JobCompNumber = CurrentQueryString.JobComponentNumber
            If CurrentQueryString.TaskSequenceNumber > 0 Then Me.SeqNum = CurrentQueryString.TaskSequenceNumber

            Session("JobNumber") = JobNumber
            Session("JobCompNumber") = JobCompNumber
            Session("SeqNum") = SeqNum
            LoadEmployee()
        End If
        Dim access As Integer = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
        If access = 1 Then
            imgBtnEmployees.Visible = True
        Else
            Me.imgBtnEmployees.Visible = False
        End If
    End Sub
    Public Sub LoadEmployee()
        Try
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Me.TxtEmployeesList.Text = s.GetTaskEmpListString(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub RadGridEmployees2_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEmployees2.ItemCommand
        ' Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEmployees.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
        Dim lblID As System.Web.UI.WebControls.Label = e.Item.FindControl("lblID")

        Dim CurrentRowID As Integer
        Try
            CurrentRowID = CType(lblID.Text, Integer)
        Catch ex As Exception
            CurrentRowID = -1
        End Try

        If CurrentRowID > -1 Then
            Select Case e.CommandName
                Case "ShowComments"
                    Dim StrCommentsURL As String = "TrafficSchedule_CompletedCmt.aspx?ID=" & CurrentRowID
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(RadWindowEmployee, "SetCommentsWindow", "Set Completed Comments", StrCommentsURL, 400, 500, True)
                    'Me.OpenWindow("Search and Replace", StrCommentsURL, 300, 645, False, True)
                    Me.OpenWindow("", StrCommentsURL, 400, 500, False)
            End Select
        End If
    End Sub

    Private Sub RadGridEmployees2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEmployees2.ItemDataBound

        If Not IsNothing(Session("ShowQuotedHours")) Then
            Dim ColHoursQuoted As Telerik.Web.UI.GridColumn
            ColHoursQuoted = Me.RadGridEmployees2.MasterTableView.Columns.FindByUniqueName("QuotedHours")
            If Session("ShowQuotedHours") = True Then
                ColHoursQuoted.Visible = True
            Else
                ColHoursQuoted.Visible = False
            End If
        End If

        Dim rdp As Telerik.Web.UI.RadDatePicker
        Dim hf As System.Web.UI.WebControls.HiddenField

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            Dim olblEmpCode As System.Web.UI.WebControls.Label = e.Item.Cells(0).Controls(0).FindControl("lblEmpCode")
            If olblEmpCode.Text = CStr(Session("EmpCode")) Then
                e.Item.BackColor = Drawing.ColorTranslator.FromHtml("#B2C9E0")
                Dim otxtPercentComplete As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtPercentComplete")
                Dim otxtCompltedComment As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtCompletedComment")

                otxtPercentComplete.Attributes.Add("onmouseover", "this.originalstyle=style.backgroundColor;this.style.backgroundColor='Silver'")
                otxtPercentComplete.Attributes.Add("onmouseout", "style.backgroundColor=this.originalstyle;")
                otxtPercentComplete.Attributes.Add("onkeydown", "return isNumberKey(event)") 'javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;
                otxtPercentComplete.Attributes.Add("onKeyDown", "if(event.keyCode==13) event.keyCode=9;")
                otxtCompltedComment.Attributes.Add("onmouseover", "this.originalstyle=style.backgroundColor;this.style.backgroundColor='Silver'")
                otxtCompltedComment.Attributes.Add("onmouseout", "style.backgroundColor=this.originalstyle;")
                otxtCompltedComment.Attributes.Add("onKeyDown", "if(event.keyCode==13) event.keyCode=9;")

                'set date textbox
                Try
                    rdp = CType(e.Item.FindControl("RadDatePickerCompleted"), Telerik.Web.UI.RadDatePicker)
                    hf = CType(e.Item.FindControl("HftxtCompleted"), HiddenField)
                    If Not rdp Is Nothing Then
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rdp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                        otxtPercentComplete.Attributes.Add("onblur", "SetIf100Perc(" + otxtPercentComplete.ClientID + "," + rdp.DateInput.ClientID + ")")
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try
                If otxtPercentComplete.Text = "" Or otxtPercentComplete.Text = "&nbsp;" Then
                    otxtPercentComplete.Text = "0"
                End If
                If IsClientPortal() = True Then
                    rdp.Enabled = False
                End If
            Else

                Dim otxtPercentComplete As System.Web.UI.WebControls.TextBox = e.Item.FindControl("txtPercentComplete")
                Dim otxtCompletedDate As Telerik.Web.UI.RadDatePicker = e.Item.FindControl("RadDatePickerCompleted")
                Dim otxtCompltedComment As System.Web.UI.WebControls.TextBox = e.Item.FindControl("txtCompletedComment")
                'imgbtnShowComments
                Dim oimgbtnShowComments As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonShowComments")
                Dim divcomments As System.Web.UI.HtmlControls.HtmlGenericControl
                divcomments = e.Item.FindControl("DivShowComments")
                'otxtCompletedDate.Wrap = True
                otxtCompletedDate.SharedCalendar = Me.RadCalendarShared
                'otxtCompletedDate.BorderStyle = BorderStyle.None
                'otxtCompletedDate.Attributes.Clear()
                'otxtCompletedDate.BorderWidth = 0
                otxtCompletedDate.DateInput.ReadOnly = True
                otxtCompletedDate.TabIndex = -1
                otxtCompletedDate.Enabled = False
                'set date textbox
                Try
                    rdp = CType(e.Item.FindControl("RadDatePickerCompleted"), Telerik.Web.UI.RadDatePicker)
                    hf = CType(e.Item.FindControl("HftxtCompleted"), HiddenField)
                    If Not rdp Is Nothing Then
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rdp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                        otxtPercentComplete.Attributes.Add("onblur", "SetIf100Perc(" + otxtPercentComplete.ClientID + "," + rdp.DateInput.ClientID + ")")
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try

                otxtCompltedComment.Wrap = True
                otxtCompltedComment.Rows = 2
                otxtCompltedComment.TextMode = TextBoxMode.MultiLine
                otxtCompltedComment.BorderStyle = BorderStyle.None
                otxtCompltedComment.BorderWidth = 0
                otxtCompltedComment.ReadOnly = True
                otxtCompltedComment.TabIndex = -1

                otxtPercentComplete.Wrap = True
                otxtPercentComplete.ReadOnly = True
                otxtPercentComplete.BorderStyle = BorderStyle.None
                otxtPercentComplete.BorderWidth = 0
                otxtPercentComplete.TabIndex = -1

                oimgbtnShowComments.Visible = False
                divcomments.Visible = False


                'Wrap = true; (obviously)
                'rows = {some number greater than 0} (I use the rows property rather than the height property as it tends to be earier to get the formatting right)
                'ReadOnly = true (makes sense, right)
                'TextMode = multiline (or there no real reason to wrap the text...)
                'BorderStyle = None 
                'BorderWidth = 0
                If IsClientPortal() = True Then
                    otxtCompletedDate.Enabled = False
                End If
            End If
            'Get quoted hours for each.

            'Dim oCompletedDate As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtCompleted")
            'oCompletedDate.Text = IIf(IsDBNull(e.Item.DataItem("TEMP_COMP_DATE")), "", e.Item.DataItem("TEMP_COMP_DATE"))



            'calculate quote hours total
            Dim olblQuotedHours As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtQuotedHours")
            If Not IsNothing(olblQuotedHours) Then
                olblQuotedHours.Text = String.Format("{0:0.00}", CDbl(GetQuotedHours(Session("JobNumber"), Session("JobCompNumber"), GetFNCCode, olblEmpCode.Text).ToString()))
                If IsNumeric(olblQuotedHours.Text) Then
                    dQuotedHoursTotal += CDbl(olblQuotedHours.Text)
                End If
            End If


            Dim olblHoursAllowed As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtHoursAllowed")
            If Not IsNothing(olblHoursAllowed) Then
                If IsNumeric(olblHoursAllowed.Text) Then
                    dHoursAllowedTotal += CDbl(olblHoursAllowed.Text)
                End If
            End If
            'GetHoursPosted
            Dim olblHoursPosted As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtHoursPosted")
            If Not IsNothing(olblHoursPosted) Then
                olblHoursPosted.Text = String.Format("{0:0.00}", CDbl(GetHoursPosted(Session("JobNumber"), Session("JobCompNumber"), GetFNCCode, olblEmpCode.Text).ToString()))
                If IsNumeric(olblHoursPosted.Text) Then
                    dHoursPostedTotal += CDbl(olblHoursPosted.Text)
                End If
            End If

            Dim otxtActualPercentComplete As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtActualPercentComplete")
            If IsNumeric(olblHoursAllowed.Text) = True Then
                If CDec(olblHoursAllowed.Text) > 0 Then
                    otxtActualPercentComplete.Text = String.Format("{0:N}", (CDec(olblHoursPosted.Text) / CDec(olblHoursAllowed.Text)) * 100)
                Else
                    otxtActualPercentComplete.Text = "0.00"
                End If
            End If

            'To get around style sheet issue (temporary till I have time to investigate.



        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
            e.Item.BackColor = Drawing.ColorTranslator.FromHtml("#F6E3BC")
        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Footer Then
            Dim olblHoursAllowedTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblHoursAllowedTotal")
            Dim olblHoursPostedTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblHoursPostedTotal")
            Dim olblQuotedHoursTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblQuotedHoursTotal")
            olblHoursAllowedTotal.Text = String.Format("{0:0.00}", CDbl(dHoursAllowedTotal.ToString()))
            olblHoursPostedTotal.Text = String.Format("{0:0.00}", CDbl(dHoursPostedTotal.ToString()))
            olblQuotedHoursTotal.Text = String.Format("{0:0.00}", CDbl(dQuotedHoursTotal.ToString()))

            ' e.Item.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub
    Public Function GetHoursPosted(ByVal iJob As Integer, ByVal iJobComp As Integer, ByVal sFNCCode As String, ByVal sEmpCode As String) As Double
        'lblHoursPosted
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim oHours As DataTable
        Dim dblReturn As Double = 0
        Try
            oHours = s.GetScheduleHoursPosted(iJob, iJobComp, sFNCCode, sEmpCode)
            If Not IsNothing(oHours) Then
                If oHours.Rows.Count > 0 Then
                    dblReturn = oHours.Rows(0).Item("SumOfEMP_HOURS")
                End If
            End If

        Catch x As Exception

        End Try
        Return dblReturn
    End Function
    Public Function GetQuotedHours(ByVal iJob As Integer, ByVal iJobComp As Integer, ByVal sFNCCode As String, ByVal sEmpCode As String) As Double
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim oHours As DataTable
        Dim dblReturn As Double = 0
        Try
            oHours = s.GetScheduleQuotedHours(iJob, iJobComp, sFNCCode, sEmpCode)
            If Not IsNothing(oHours) Then
                If oHours.Rows.Count > 0 Then
                    dblReturn = oHours.Rows(0).Item("SumOfEst_Ref_Quantity")
                End If
            End If

        Catch x As Exception

        End Try
        Return dblReturn
    End Function
    Private Function GetFNCCode() As String

        Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
        oTask.Where.JOB_NUMBER.Value = Session("JobNumber")
        oTask.Where.JOB_COMPONENT_NBR.Value = Session("JobCompNumber")
        oTask.Where.SEQ_NBR.Value = Session("SeqNum")
        If oTask.Query.Load Then
            Return oTask.FNC_EST
        End If
        Return ""
    End Function
    Protected Sub RadGridEmployees2_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEmployees2.NeedDataSource
        Try
            Me.RadGridEmployees2.DataSource = Me.DataSource 'dataview
        Catch ex As Exception
        End Try
    End Sub
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function
    Protected Sub chkQuoteHours_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkQuoteHours.CheckedChanged
        If chkQuoteHours.Checked = True Then
            Session("ShowQuotedHours") = True
        Else
            Session("ShowQuotedHours") = False
        End If
        RefreshEmployeeGrid()
    End Sub

End Class