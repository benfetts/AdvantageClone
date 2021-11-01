Public Class EmployeeTimeForecast_EmployeeTimeAnalysis
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Private Enum StaticColumn
        ParentOfficeCode
        OfficeCode
        OfficeName
        ParentDepartmentCode
        DepartmentCode
        DepartmentName
        EmployeeCode
        EmployeeName
    End Enum

#End Region

#Region " Variables "

    Private _JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing
    Private _PostPeriodsList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
    Private _JobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
    Private _ClientsList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function LoadPostPeriodYear() As Integer

        'objects
        Dim RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis As Telerik.Web.UI.RadTreeList = Nothing
        Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        Dim TreeListTemplateColumn As Telerik.Web.UI.TreeListTemplateColumn = Nothing
        Dim PostPeriodYear As Integer = 0

        Try

            If Request.QueryString("PostPeriodYear") IsNot Nothing Then

                PostPeriodYear = CType(Request.QueryString("PostPeriodYear"), Integer)

            End If

        Catch ex As Exception
            PostPeriodYear = 0
        Finally
            LoadPostPeriodYear = PostPeriodYear
        End Try

    End Function
    Private Function LoadEmployeeTimeForecastEmployeeTimeAnalysis() As System.Data.DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim OfficeHeaderDataRow As System.Data.DataRow = Nothing
        Dim DepartmentHeaderDataRow As System.Data.DataRow = Nothing
        Dim EmployeeDataRow As System.Data.DataRow = Nothing
        Dim RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis As Telerik.Web.UI.RadTreeList = Nothing
        Dim PostPeriodYear As Integer = 0
        Dim OfficesList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
        Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ClientHours As Decimal = 0

        PostPeriodYear = LoadPostPeriodYear()

        If PostPeriodYear <> 0 Then

            Try

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis = PlaceHolderEmployeeTimeForecastEmployeeTimeAnalysis.FindControl("RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis")

            Catch ex As Exception
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis = Nothing
            End Try

            If RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadEmployeeTimeForecastEmployeeTimeAnalysisLists(DbContext, PostPeriodYear)

                    DataTable = New System.Data.DataTable

                    For Each TreeListBoundColumn In RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.OfType(Of Telerik.Web.UI.TreeListBoundColumn)()

                        DataTable.Columns.Add(TreeListBoundColumn.DataField)

                    Next

                    OfficesList = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
                    EmployeesList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                    For Each EmployeeCode In _JobAmountsList.Select(Function(JobAmount) JobAmount.JobAmountCode).Distinct

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            EmployeesList.Add(Employee)

                            If Employee.Office IsNot Nothing Then

                                If OfficesList.Contains(Employee.Office) = False Then

                                    OfficesList.Add(Employee.Office)

                                End If

                            End If

                        End If

                    Next

                    For Each Office In OfficesList.OrderBy(Function(Entity) Entity.Name)

                        OfficeHeaderDataRow = DataTable.Rows.Add

                        OfficeHeaderDataRow(StaticColumn.ParentOfficeCode.ToString()) = ""
                        OfficeHeaderDataRow(StaticColumn.OfficeCode.ToString()) = Office.Code
                        OfficeHeaderDataRow(StaticColumn.OfficeName.ToString()) = Office.Name
                        OfficeHeaderDataRow(StaticColumn.ParentDepartmentCode.ToString()) = ""
                        OfficeHeaderDataRow(StaticColumn.DepartmentCode.ToString()) = ""
                        OfficeHeaderDataRow(StaticColumn.DepartmentName.ToString()) = ""
                        OfficeHeaderDataRow(StaticColumn.EmployeeCode.ToString()) = ""
                        OfficeHeaderDataRow(StaticColumn.EmployeeName.ToString()) = ""

                        For Each Client In _ClientsList

                            OfficeHeaderDataRow(Client.Code & "Hours") = ""
                            OfficeHeaderDataRow(Client.Code & "Percent") = ""

                        Next

                        For Each DepartmentTeam In EmployeesList.Where(Function(View) View.OfficeCode = Office.Code).Select(Function(View) View.DepartmentTeam).Distinct.OrderBy(Function(Entity) Entity.Description)

                            DepartmentHeaderDataRow = DataTable.Rows.Add

                            DepartmentHeaderDataRow(StaticColumn.ParentOfficeCode.ToString()) = Office.Code
                            DepartmentHeaderDataRow(StaticColumn.OfficeCode.ToString()) = ""
                            DepartmentHeaderDataRow(StaticColumn.OfficeName.ToString()) = ""
                            DepartmentHeaderDataRow(StaticColumn.ParentDepartmentCode.ToString()) = ""
                            DepartmentHeaderDataRow(StaticColumn.DepartmentCode.ToString()) = DepartmentTeam.Code
                            DepartmentHeaderDataRow(StaticColumn.DepartmentName.ToString()) = DepartmentTeam.Description
                            DepartmentHeaderDataRow(StaticColumn.EmployeeCode.ToString()) = ""
                            DepartmentHeaderDataRow(StaticColumn.EmployeeName.ToString()) = ""

                            For Each Client In _ClientsList

                                DepartmentHeaderDataRow(Client.Code & "Hours") = ""
                                DepartmentHeaderDataRow(Client.Code & "Percent") = ""

                            Next

                            For Each Employee In EmployeesList.Where(Function(View) View.OfficeCode = Office.Code AndAlso View.DepartmentTeamCode = DepartmentTeam.Code).
                                                                    OrderBy(Function(View) View.FirstName).
                                                                    ThenBy(Function(View) View.MiddleInitial).
                                                                    ThenBy(Function(View) View.LastName)

                                EmployeeDataRow = DataTable.Rows.Add

                                EmployeeDataRow(StaticColumn.ParentOfficeCode.ToString()) = Office.Code
                                EmployeeDataRow(StaticColumn.OfficeCode.ToString()) = ""
                                EmployeeDataRow(StaticColumn.OfficeName.ToString()) = ""
                                EmployeeDataRow(StaticColumn.ParentDepartmentCode.ToString()) = DepartmentTeam.Code
                                EmployeeDataRow(StaticColumn.DepartmentCode.ToString()) = ""
                                EmployeeDataRow(StaticColumn.DepartmentName.ToString()) = ""
                                EmployeeDataRow(StaticColumn.EmployeeCode.ToString()) = Employee.Code
                                EmployeeDataRow(StaticColumn.EmployeeName.ToString()) = Employee.ToString

                                For Each Client In _ClientsList

                                    ClientHours = 0

                                    For Each JobComponent In _JobComponentsList.Where(Function(Entity) Entity.Job.ClientCode = Client.Code)

                                        ClientHours += _JobAmountsList.Where(Function(JobAmount) JobAmount.JobAmountCode = Employee.Code AndAlso
                                                                                                 JobAmount.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                 JobAmount.JobComponentNumber = JobComponent.Number).
                                                                            Select(Function(JobAmount) JobAmount.Hours).Sum

                                    Next

                                    EmployeeDataRow(Client.Code & "Hours") = ClientHours

                                Next

                            Next

                        Next

                    Next

                End Using

            End If

        End If

        LoadEmployeeTimeForecastEmployeeTimeAnalysis = DataTable

    End Function
    Private Sub LoadEmployeeTimeForecastEmployeeTimeAnalysisLists(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodYear As Integer)

        'objects
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        If DbContext IsNot Nothing Then

            If _PostPeriodsList Is Nothing Then

                _PostPeriodsList = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriodsByPostPeriodYear(DbContext, PostPeriodYear).ToList

            End If

            If _JobAmountsList Is Nothing AndAlso _PostPeriodsList IsNot Nothing Then

                _JobAmountsList = AdvantageFramework.Database.Procedures.JobAmountComplexType.Load(DbContext, False, True, False, False, False, False, False, Nothing, Nothing, True).
                                                                                                    Where(Function(JobAmount) _PostPeriodsList.Any(Function(PostPeriod) PostPeriod.Code = JobAmount.AccountsRecievablePostPeriodCode)).ToList

            End If

            If _JobComponentsList Is Nothing AndAlso _ClientsList Is Nothing AndAlso _JobAmountsList IsNot Nothing Then

                _JobComponentsList = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)
                _ClientsList = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                For Each JobAmount In _JobAmountsList

                    If _JobComponentsList.Any(Function(Entity) Entity.JobNumber = JobAmount.JobNumber AndAlso Entity.Number = JobAmount.JobComponentNumber) = False Then

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobAmount.JobNumber, JobAmount.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            _JobComponentsList.Add(JobComponent)

                            If _ClientsList.Contains(JobComponent.Job.Client) = False Then

                                _ClientsList.Add(JobComponent.Job.Client)

                            End If

                        End If

                    End If

                Next

            End If

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_EmployeeTimeAnalysis_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'objects
        Dim RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis As Telerik.Web.UI.RadTreeList = Nothing
        Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        Dim TreeListTemplateColumn As Telerik.Web.UI.TreeListTemplateColumn = Nothing
        Dim PostPeriodYear As Integer = 0

        PostPeriodYear = LoadPostPeriodYear()

        If PostPeriodYear <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis = New Telerik.Web.UI.RadTreeList

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ID = "RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis"
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.AutoGenerateColumns = False
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.AllowMultiItemSelection = False
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.EnableViewState = True
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.AllowPaging = False
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.AllowSorting = False
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ParentDataKeyNames = New String() {StaticColumn.ParentOfficeCode.ToString}
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.DataKeyNames = New String() {StaticColumn.OfficeCode.ToString}
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Width = System.Web.UI.WebControls.Unit.Percentage(99)
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ShowTreeLines = False
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ShowOuterBorders = True
                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.GridLines = GridLines.Horizontal

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.OfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.OfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Office Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Parent Office Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.OfficeName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.OfficeName.ToString
                TreeListBoundColumn.HeaderText = "Office"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.DepartmentCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.DepartmentCode.ToString
                TreeListBoundColumn.HeaderText = "Department Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.ParentDepartmentCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.ParentDepartmentCode.ToString
                TreeListBoundColumn.HeaderText = "Parent Department Code"
                TreeListBoundColumn.Visible = False

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.DepartmentName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.DepartmentName.ToString
                TreeListBoundColumn.HeaderText = "Department"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.EmployeeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.EmployeeCode.ToString
                TreeListBoundColumn.HeaderText = "Employee Code"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                TreeListBoundColumn.DataField = StaticColumn.EmployeeName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & StaticColumn.EmployeeName.ToString
                TreeListBoundColumn.HeaderText = "Employee"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                LoadEmployeeTimeForecastEmployeeTimeAnalysisLists(DbContext, PostPeriodYear)

                For Each Client In _ClientsList

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    TreeListBoundColumn.DataField = Client.Code & "Hours"
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & Client.Code & "Hours"
                    TreeListBoundColumn.HeaderText = Client.Name & " Hours"
                    TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                    RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    TreeListBoundColumn.DataField = Client.Code & "Percent"
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & Client.Code & "Percent"
                    TreeListBoundColumn.HeaderText = Client.Name & " Percent"
                    TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle

                    RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.Columns.Add(TreeListBoundColumn)

                Next

                AddHandler RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ItemCommand, AddressOf RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis_ItemCommand

                PlaceHolderEmployeeTimeForecastEmployeeTimeAnalysis.Controls.Add(RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis)

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.DataSource = LoadEmployeeTimeForecastEmployeeTimeAnalysis()
                    RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.DataBind()

                    RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis.ExpandAllItems()

                End If

            End Using

        End If

    End Sub
    Private Sub EmployeeTimeForecast_EmployeeTimeAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Employee Time Forecast - Employee Time Analysis"


        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DropDownListYear.DataSource = (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                                               Select New With {.[Year] = PostPeriod.Year}).ToList
                DropDownListYear.DataBind()
                DropDownListYear.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                DropDownListYear.SelectedValue = LoadPostPeriodYear()

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListPostPeriodYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListYear.SelectedIndexChanged

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If DropDownListYear.SelectedValue IsNot Nothing AndAlso DropDownListYear.SelectedValue <> "" Then

                Response.Redirect(String.Format("EmployeeTimeForecast_EmployeeTimeAnalysis.aspx?PostPeriodYear={0}", DropDownListYear.SelectedValue))

            Else

                Response.Redirect(String.Format("EmployeeTimeForecast_EmployeeTimeAnalysis.aspx?PostPeriodYear={0}", 0))

            End If

        End Using

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastEmployeeTimeAnalysis_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListCommandEventArgs)

        If e.CommandName = Telerik.Web.UI.RadTreeList.ExpandCollapseCommandName Then

            DirectCast(sender, Telerik.Web.UI.RadTreeList).DataSource = LoadEmployeeTimeForecastEmployeeTimeAnalysis()
            DirectCast(sender, Telerik.Web.UI.RadTreeList).DataBind()

        End If

    End Sub
    Private Sub RadToolbarEmployeeTimeForecastEmployeeTimeAnalysis_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEmployeeTimeForecastEmployeeTimeAnalysis.ButtonClick

    End Sub

#End Region

#End Region

End Class
