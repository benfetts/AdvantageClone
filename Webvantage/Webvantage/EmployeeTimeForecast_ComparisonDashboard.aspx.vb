Public Class EmployeeTimeForecast_ComparisonDashboard
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadYearAndMonth(ByRef Year As Integer, ByRef Month As Integer)

        Try

            If Request.QueryString("Year") IsNot Nothing Then

                Year = CType(Request.QueryString("Year"), Integer)

            End If

            If Request.QueryString("Month") IsNot Nothing Then

                Month = CType(Request.QueryString("Month"), Integer)

            End If

        Catch ex As Exception
            Year = 0
        End Try

    End Sub
    Private Function BuildEmployeeTimeForecastComparisonDashboardDataTable() As System.Data.DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Year As Integer = 0
        Dim Month As Integer = 0

        LoadYearAndMonth(Year, Month)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DataTable = AdvantageFramework.EmployeeTimeForecast.BuildEmployeeTimeForecastComparisonDashbaordDataTable(_Session, DbContext, Year, Month, CheckBoxShowForecastedUtilization.Checked, CheckBoxShowResultsForForecastedProjectsOnly.Checked)

        End Using

        BuildEmployeeTimeForecastComparisonDashboardDataTable = DataTable

    End Function
    Private Sub ReloadDashbaord()

        'objects
        Dim Year As Integer = 0
        Dim Month As Integer = 0

        Try

            Year = DropDownListYear.SelectedValue

        Catch ex As Exception
            Year = 0
        End Try

        Try

            Month = DropDownListMonth.SelectedValue

        Catch ex As Exception
            Month = 0
        End Try

        Response.Redirect(String.Format("EmployeeTimeForecast_ComparisonDashboard.aspx?Year={0}&Month={1}", Year, Month))

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_ComparisonDashboard_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'objects
        Dim RadTreeListEmployeeTimeForecastComparisonDashbaord As Telerik.Web.UI.RadTreeList = Nothing
        Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        Dim Year As Integer = 0
        Dim Month As Integer = 0

        LoadYearAndMonth(Year, Month)

        If Year <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadTreeListEmployeeTimeForecastComparisonDashbaord = New Telerik.Web.UI.RadTreeList

                RadTreeListEmployeeTimeForecastComparisonDashbaord.ID = "RadTreeListEmployeeTimeForecastComparisonDashbaord"
                RadTreeListEmployeeTimeForecastComparisonDashbaord.AutoGenerateColumns = False
                RadTreeListEmployeeTimeForecastComparisonDashbaord.AllowMultiItemSelection = False
                RadTreeListEmployeeTimeForecastComparisonDashbaord.EnableViewState = True
                RadTreeListEmployeeTimeForecastComparisonDashbaord.AllowPaging = False
                RadTreeListEmployeeTimeForecastComparisonDashbaord.AllowSorting = False
                RadTreeListEmployeeTimeForecastComparisonDashbaord.ParentDataKeyNames = New String() {AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentOfficeCode.ToString}
                RadTreeListEmployeeTimeForecastComparisonDashbaord.DataKeyNames = New String() {AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeCode.ToString}
                RadTreeListEmployeeTimeForecastComparisonDashbaord.Width = System.Web.UI.WebControls.Unit.Percentage(99)
                RadTreeListEmployeeTimeForecastComparisonDashbaord.ShowTreeLines = False
                RadTreeListEmployeeTimeForecastComparisonDashbaord.ShowOuterBorders = True
                RadTreeListEmployeeTimeForecastComparisonDashbaord.GridLines = GridLines.Horizontal
                RadTreeListEmployeeTimeForecastComparisonDashbaord.AlternatingItemStyle.BackColor = Drawing.Color.White

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeName.ToString
                TreeListBoundColumn.HeaderText = "Office"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.HeaderStyle.Width = 100

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientName.ToString
                TreeListBoundColumn.HeaderText = "Client"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.HeaderStyle.Width = 100

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.UtilizationOrForecast.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.UtilizationOrForecast.ToString
                TreeListBoundColumn.HeaderText = "Utilization\" & vbNewLine & "Forecast"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.HeaderStyle.Width = 150
                TreeListBoundColumn.ItemStyle.Width = 150

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                For Each PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriodsByPostPeriodYear(DbContext, Year)

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    TreeListBoundColumn.DataField = PostPeriod.Code
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & PostPeriod.Code
                    TreeListBoundColumn.HeaderText = PostPeriod.Description
                    TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.HeaderStyle.Width = 125

                    If CInt(PostPeriod.Month) < Month Then

                        TreeListBoundColumn.ItemStyle.BackColor = Drawing.Color.White
                        'TreeListBoundColumn.HeaderStyle.BackColor = Drawing.Color.White

                    Else

                        TreeListBoundColumn.ItemStyle.CssClass = "RequiredInput"
                        'TreeListBoundColumn.HeaderStyle.CssClass = "RequiredInput"

                    End If

                    RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                Next

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.LineTotals.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.LineTotals.ToString
                TreeListBoundColumn.HeaderText = "Line Totals"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ItemStyle.BackColor = Drawing.Color.DarkGray
                'TreeListBoundColumn.HeaderStyle.BackColor = Drawing.Color.DarkGray
                TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.HeaderStyle.Width = 125

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Office Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Parent Office Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientCode.ToString
                TreeListBoundColumn.HeaderText = "Client Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentClientCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentClientCode.ToString
                TreeListBoundColumn.HeaderText = "Parent Client Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastComparisonDashbaord.Columns.Add(TreeListBoundColumn)

                AddHandler RadTreeListEmployeeTimeForecastComparisonDashbaord.ItemCommand, AddressOf RadTreeListEmployeeTimeForecastComparisonDashbaord_ItemCommand
                AddHandler RadTreeListEmployeeTimeForecastComparisonDashbaord.ItemDataBound, AddressOf RadTreeListEmployeeTimeForecastComparisonDashbaord_ItemDataBound

                PlaceHolderEmployeeTimeForecastOffice.Controls.Add(RadTreeListEmployeeTimeForecastComparisonDashbaord)

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    RadTreeListEmployeeTimeForecastComparisonDashbaord.DataSource = BuildEmployeeTimeForecastComparisonDashboardDataTable()
                    RadTreeListEmployeeTimeForecastComparisonDashbaord.DataBind()

                    RadTreeListEmployeeTimeForecastComparisonDashbaord.ExpandAllItems()

                End If

            End Using

        End If

    End Sub
    Private Sub EmployeeTimeForecast_ComparisonDashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Year As Integer = 0
        Dim Month As Integer = 0

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard)

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DropDownListYear.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                                               Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList
                DropDownListYear.DataBind()
                DropDownListYear.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                DropDownListMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                DropDownListMonth.DataBind()
                DropDownListMonth.Items.Insert(12, New Telerik.Web.UI.RadComboBoxItem("[All]", "13"))
                DropDownListMonth.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                LoadYearAndMonth(Year, Month)

                DropDownListYear.SelectedValue = Year
                DropDownListMonth.SelectedValue = Month

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecastComparisonDashboard_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastComparisonDashboard.ButtonClick

        Select Case e.Item.Value

            Case "Back"

                Me.CloseThisWindowAndRefreshCaller("EmployeeTimeForecast_Main.aspx", False, True)

                'MiscFN.ResponseRedirect("EmployeeTimeForecast_Main.aspx")
                Exit Sub

        End Select

    End Sub
    Private Sub DropDownListPostPeriodYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListYear.SelectedIndexChanged

        ReloadDashbaord()

    End Sub
    Private Sub DropDownListMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListMonth.SelectedIndexChanged

        ReloadDashbaord()

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastComparisonDashbaord_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListCommandEventArgs)

        If e.CommandName = Telerik.Web.UI.RadTreeList.ExpandCollapseCommandName Then

            DirectCast(sender, Telerik.Web.UI.RadTreeList).DataSource = BuildEmployeeTimeForecastComparisonDashboardDataTable()
            DirectCast(sender, Telerik.Web.UI.RadTreeList).DataBind()

        End If

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastComparisonDashbaord_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListItemDataBoundEventArgs)

        'objects
        Dim TreeListDataItem As Telerik.Web.UI.TreeListDataItem = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.TreeListDataItem Then

            TreeListDataItem = e.Item

            If TreeListDataItem.DataItem IsNot Nothing AndAlso TypeOf TreeListDataItem.DataItem Is System.Data.DataRowView Then

                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = "" Then

                    For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                        TableCell.BackColor = Drawing.Color.DarkGray
                        TableCell.Font.Bold = True

                    Next

                ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentClientCode.ToString) = "" Then

                    For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                        TableCell.BackColor = Drawing.Color.LightGray
                        TableCell.Font.Bold = True

                    Next

                End If

            End If

        End If

    End Sub
    Private Sub CheckBoxShowForecastedUtilization_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowForecastedUtilization.CheckedChanged

        'objects
        Dim RadTreeListEmployeeTimeForecastComparisonDashbaord As Telerik.Web.UI.RadTreeList = Nothing

        Try

            RadTreeListEmployeeTimeForecastComparisonDashbaord = PlaceHolderEmployeeTimeForecastOffice.FindControl("RadTreeListEmployeeTimeForecastComparisonDashbaord")

        Catch ex As Exception
            RadTreeListEmployeeTimeForecastComparisonDashbaord = Nothing
        End Try

        If RadTreeListEmployeeTimeForecastComparisonDashbaord IsNot Nothing Then

            RadTreeListEmployeeTimeForecastComparisonDashbaord.DataSource = BuildEmployeeTimeForecastComparisonDashboardDataTable()
            RadTreeListEmployeeTimeForecastComparisonDashbaord.DataBind()

            RadTreeListEmployeeTimeForecastComparisonDashbaord.ExpandAllItems()

        End If

    End Sub
    Private Sub CheckBoxShowResultsForForecastedProjectsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowResultsForForecastedProjectsOnly.CheckedChanged

        'objects
        Dim RadTreeListEmployeeTimeForecastComparisonDashbaord As Telerik.Web.UI.RadTreeList = Nothing

        Try

            RadTreeListEmployeeTimeForecastComparisonDashbaord = PlaceHolderEmployeeTimeForecastOffice.FindControl("RadTreeListEmployeeTimeForecastComparisonDashbaord")

        Catch ex As Exception
            RadTreeListEmployeeTimeForecastComparisonDashbaord = Nothing
        End Try

        If RadTreeListEmployeeTimeForecastComparisonDashbaord IsNot Nothing Then

            RadTreeListEmployeeTimeForecastComparisonDashbaord.DataSource = BuildEmployeeTimeForecastComparisonDashboardDataTable()
            RadTreeListEmployeeTimeForecastComparisonDashbaord.DataBind()

            RadTreeListEmployeeTimeForecastComparisonDashbaord.ExpandAllItems()

        End If

    End Sub

#End Region

#End Region

End Class
