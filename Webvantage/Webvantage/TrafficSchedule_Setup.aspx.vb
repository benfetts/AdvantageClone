Public Partial Class TrafficSchedule_Setup
    Inherits Webvantage.BaseChildPage

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Project Schedule - Setup"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim appVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            appVars.getAllAppVars()
            Me.CheckBoxDisablePaging.Checked = appVars.getAppVar("DisablePaging", "Boolean", "False") = "True"
            Me.RadioButtonListDefaultCalculation.SelectedValue = appVars.getAppVar("SCHEDULE_CALC", "Integer", "1")

        End If

    End Sub

    Private Sub RadGridScheduleItems_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridScheduleItems.ItemDataBound
        Try
            Dim ChkShowOnGrid As System.Web.UI.WebControls.CheckBox = Nothing
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                ChkShowOnGrid = DirectCast(e.Item.FindControl("ChkShowOnGrid"), CheckBox)
                ChkShowOnGrid.Checked = CType(e.Item.DataItem("ShowOnGrid"), Boolean)
                If DirectCast(e.Item.FindControl("HfACTIVE"), HiddenField).Value.Trim = "3" Then
                    Dim chk As CheckBox = DirectCast(e.Item.FindControl("ChkShowOnAddNew"), CheckBox)
                    chk.Checked = False
                    chk.Enabled = False
                Else
                    DirectCast(e.Item.FindControl("ChkShowOnAddNew"), CheckBox).Checked = CType(e.Item.DataItem("ShowOnAddNew"), Boolean)
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridScheduleItems_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridScheduleItems.NeedDataSource
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Me.RadGridScheduleItems.DataSource = s.GetScheduleColumns(Session("EmpCode"), True, True, False)
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Dim strJT As String = ""
        Dim q As New AdvantageFramework.Web.QueryString()
        q = q.FromCurrent()
        With q
            Me.JobNumber = q.JobNumber
            Me.JobComponentNbr = q.JobComponentNumber
            strJT = q.GetValue("JT")
        End With
        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
            If strJT = "" Then
                strJT = 0
            End If
            Dim t As New AdvantageFramework.Web.QueryString()
            With t
                .Page = "TrafficSchedule.aspx"
                '.JobNumber = Me.JobNumber
                '.JobComponentNbr = Me.JobComponentNbr
                .Add("JobNum", Me.JobNumber)  'Temp fix until can change all links going into TrafficSchedule.aspx.
                .Add("JobComp", Me.JobComponentNbr)
                .Add("R", "1")
                .Add("JT", strJT)
                .Go()
            End With
        Else
            MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx")
            Exit Sub
        End If
    End Sub

    Private Sub RadGridScheduleItems_PreRender(sender As Object, e As System.EventArgs) Handles RadGridScheduleItems.PreRender

    End Sub

    Private Sub RadGridScheduleItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridScheduleItems.SelectedIndexChanged
    End Sub

    Public Sub ChkShowOnGrid_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)
        'Me.ShowMessage("Row datakey " & CurrentGridRow.GetDataKeyValue("ID"))
        Dim ColumnID As Integer = 0
        Try
            ColumnID = CurrentGridRow.GetDataKeyValue("ID")
        Catch ex As Exception
            ColumnID = 0
        End Try
        Dim bShowOnGrid As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnGrid"), CheckBox).Checked
        Dim bShowOnAddNew As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnAddNew"), CheckBox).Checked

        If ColumnID > 0 Then
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            's.UpdateUserColumn(Session("EmpCode"), ColumnID, bShowOnGrid, bShowOnAddNew)
            'If ColumnID = 8 And bShowOnGrid = True Then
            '    s.UpdateUserColumn(Session("EmpCode"), 6, False, False)
            '    s.UpdateUserColumn(Session("EmpCode"), 7, True, False)
            'End If
            'If ColumnID = 6 And bShowOnGrid = True Then
            '    s.UpdateUserColumn(Session("EmpCode"), 8, False, False)
            'End If
            'If ColumnID = 22 And bShowOnGrid = True Then
            '    s.UpdateUserColumn(Session("EmpCode"), 38, False, False)
            '    s.UpdateUserColumn(Session("EmpCode"), 22, True, False)
            'End If
            'If ColumnID = 38 And bShowOnGrid = True Then
            '    s.UpdateUserColumn(Session("EmpCode"), 22, False, False)
            '    s.UpdateUserColumn(Session("EmpCode"), 38, True, False)
            'End If
        End If

        Me.RadGridScheduleItems.Rebind()
    End Sub

    Public Sub ChkShowOnAddNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)
        'Me.ShowMessage("Row datakey " & CurrentGridRow.GetDataKeyValue("ID"))
        Dim ColumnID As Integer = 0
        Try
            ColumnID = CurrentGridRow.GetDataKeyValue("ID")
        Catch ex As Exception
            ColumnID = 0
        End Try
        Dim bShowOnGrid As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnGrid"), CheckBox).Checked
        Dim bShowOnAddNew As Boolean = CType(CurrentGridRow.FindControl("ChkShowOnAddNew"), CheckBox).Checked

        If ColumnID > 0 Then
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            's.UpdateUserColumn(Session("EmpCode"), ColumnID, bShowOnGrid, bShowOnAddNew)
        End If

        Me.RadGridScheduleItems.Rebind()
    End Sub

    'Not in use "Show full" no longer an option and the "full" column is now a description field
    Public Sub ChkShowFull_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)
        Dim ColumnID As Integer = 0
        Try
            ColumnID = CurrentGridRow.GetDataKeyValue("ID")
        Catch ex As Exception
            ColumnID = 0
        End Try
        If ColumnID > 0 Then
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            s.UpdateUserColumnShowLong(Session("EmpCode"), ColumnID)
        End If
        Me.RadGridScheduleItems.Rebind()
    End Sub

    Private Sub CheckBoxDisablePaging_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDisablePaging.CheckedChanged

        Dim appVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
        appVars.getAllAppVars()
        appVars.setAppVar("DisablePaging", Me.CheckBoxDisablePaging.Checked, "Boolean")
        appVars.SaveAllAppVars()

    End Sub

    Private Sub RadioButtonListDefaultCalculation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListDefaultCalculation.SelectedIndexChanged

        Dim appVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
        appVars.getAllAppVars()
        appVars.setAppVar("SCHEDULE_CALC", Me.RadioButtonListDefaultCalculation.SelectedValue, "Integer")
        appVars.SaveAllAppVars()

    End Sub

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        'objects
        Dim CheckBox As System.Web.UI.WebControls.CheckBox = Nothing
        Dim CheckBoxEmp As System.Web.UI.WebControls.CheckBox = Nothing
        Dim CheckBoxEmpAuto As System.Web.UI.WebControls.CheckBox = Nothing


        For Each GridDataItem In RadGridScheduleItems.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            CheckBox = DirectCast(GridDataItem.FindControl("ChkShowOnGrid"), System.Web.UI.WebControls.CheckBox)

            If GridDataItem.GetDataKeyValue("ColumnName") <> "colEMP_CODE_TEXT" And GridDataItem.GetDataKeyValue("ColumnName") <> "colEMP_CODE_TEXT_AUTO" Then

            ElseIf GridDataItem.GetDataKeyValue("ColumnName") = "colEMP_CODE_TEXT" Then
                CheckBoxEmp = DirectCast(GridDataItem.FindControl("ChkShowOnGrid"), System.Web.UI.WebControls.CheckBox)
            End If
        Next

        For Each GridDataItem In RadGridScheduleItems.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If GridDataItem.GetDataKeyValue("ColumnName") = "colEMP_CODE_TEXT_AUTO" Then
                CheckBoxEmpAuto = DirectCast(GridDataItem.FindControl("ChkShowOnGrid"), System.Web.UI.WebControls.CheckBox)
            End If

        Next

    End Sub

End Class
