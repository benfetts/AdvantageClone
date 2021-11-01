Imports Telerik.Web.UI

Public Class dtp_MyEmployeeTimeForecast
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

    Private Sub LoadMyEmployeeTimeForecast()

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SupervisedEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim EmployeeCode As String = ""
        Dim Month As Integer = 0
        Dim Year As Integer = 0
        Dim MonthTo As Integer = 0
        Dim YearTo As Integer = 0
        Dim AlternateEmployees As Boolean = False
        Dim SupervisorEmployees As Boolean = False
        Dim Department As String = ""
        Dim ForecastOnly As Boolean = False
        Dim JobDetail As Boolean = False
        Dim View As Integer = 0
        Dim Display As Integer = 0
        Dim Summary As Boolean = False

        If Request.QueryString("DO") = "My" Then
            Try

                JobDetail = Session("MyETF_JobDetail")

            Catch ex As Exception
                JobDetail = False
            End Try

            Try

                Month = Session("MyETF_Month")

            Catch ex As Exception
                Month = 0
            End Try

            Try

                Year = Session("MyETF_Year")

            Catch ex As Exception
                Year = 0
            End Try

            Try

                MonthTo = Session("MyETF_MonthTo")

            Catch ex As Exception
                MonthTo = 0
            End Try

            Try

                YearTo = Session("MyETF_YearTo")

            Catch ex As Exception
                YearTo = 0
            End Try

            Try

                AlternateEmployees = Session("MyETF_AlternateEmployees")

            Catch ex As Exception
                AlternateEmployees = False
            End Try

            Try

                SupervisorEmployees = Session("MyETF_SupervisorEmployees")

            Catch ex As Exception
                SupervisorEmployees = False
            End Try

            Try

                Department = Session("MyETF_Department")

            Catch ex As Exception
                Department = False
            End Try

            Try

                ForecastOnly = Session("MyETF_ForecastOnly")

            Catch ex As Exception
                ForecastOnly = False
            End Try

            Try

                View = Session("MyETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("MyETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If Request.QueryString("DO") = "All" Then
            Try

                JobDetail = Session("AllETF_JobDetail")

            Catch ex As Exception
                JobDetail = False
            End Try

            Try

                Month = Session("AllETF_Month")

            Catch ex As Exception
                Month = 0
            End Try

            Try

                Year = Session("AllETF_Year")

            Catch ex As Exception
                Year = 0
            End Try

            Try

                MonthTo = Session("AllETF_MonthTo")

            Catch ex As Exception
                MonthTo = 0
            End Try

            Try

                YearTo = Session("AllETF_YearTo")

            Catch ex As Exception
                YearTo = 0
            End Try

            Try

                AlternateEmployees = Session("AllETF_AlternateEmployees")

            Catch ex As Exception
                AlternateEmployees = False
            End Try

            Try

                Department = Session("AllETF_Department")

            Catch ex As Exception
                Department = False
            End Try

            Try

                ForecastOnly = Session("AllETF_ForecastOnly")

            Catch ex As Exception
                ForecastOnly = False
            End Try

            Try

                View = Session("AllETF_View")

            Catch ex As Exception
                JobDetail = False
            End Try

            Try

                Display = Session("AllETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If


        If Month > 0 AndAlso Year > 0 Then

            If Request.QueryString("DO") = "My" Then
                EmployeeCode = Session("empcode").ToString
            End If

            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'DataTable = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, Year, Month, YearTo, MonthTo, EmployeeCode)

                'RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                '                                                                                                                                         EmployeeCode, AlternateEmployees, False, 0, "", Department, False, SupervisorEmployees, 0, ForecastOnly, _Session.UserCode)

                If View = 0 Then
                    If Summary = True Then
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = True
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                        RadGridEmployeeTimeForcastEmployeeSummary.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                      EmployeeCode, AlternateEmployees, False, 0, "", Department, False, SupervisorEmployees, 0, ForecastOnly, _Session.UserCode, Summary)
                        Button2.Visible = True
                    Else
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = True
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False
                        RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                           EmployeeCode, AlternateEmployees, False, 0, "", Department, False, SupervisorEmployees, 0, ForecastOnly, _Session.UserCode, Summary)
                        Button1.Visible = True
                    End If
                    Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                    Me.RadGridEmployeeTimeForecastByClient.Visible = False
                    Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False



                ElseIf View = 1 Then
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = True
                    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                    Me.RadGridEmployeeTimeForecastByClient.Visible = False
                    Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                    RadGridEmployeeTimeForecastEmployeeutilization.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                   EmployeeCode, 0, False, 0, "", Department, False, SupervisorEmployees, 1, False, _Session.UserCode, False)
                    Me.Button3.Visible = True
                ElseIf View = 2 Then
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = True
                    Me.RadGridEmployeeTimeForecastByClient.Visible = False
                    Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                            EmployeeCode, 0, False, 0, "", Department, False, SupervisorEmployees, 2, False, _Session.UserCode, False)

                    Me.Button4.Visible = True
                    Dim DatatableByMonth As DataTable
                    DatatableByMonth = New DataTable("ByMonth")

                    Dim dOffice As DataColumn = New DataColumn("Office")
                    Dim dDepartment As DataColumn = New DataColumn("Department")
                    Dim dEmployee As DataColumn = New DataColumn("Employee")
                    DatatableByMonth.Columns.Add(dOffice)
                    DatatableByMonth.Columns.Add(dDepartment)
                    DatatableByMonth.Columns.Add(dEmployee)


                    Dim dc As DataColumn
                    Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
                    Dim StartDate As DateTime = Nothing
                    Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
                    Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

                    FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year)
                    ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, MonthTo, YearTo)

                    If DateDiff(DateInterval.Month, FromPostPeriod.StartDate.Value, ToPostPeriod.StartDate.Value) >= 12 Then
                        StartDate = ToPostPeriod.StartDate.Value.AddMonths(-11)
                        FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, StartDate.Month, StartDate.Year)
                    End If

                    PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllPostPeriodsFromPostPeriodToPostPeriod(DbContext, FromPostPeriod.Code, ToPostPeriod.Code).Distinct.ToList

                    For Each pp In PostPeriods

                        dc = New DataColumn(pp.Description.Substring(0, 3), System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                    Next

                    Dim Emp As String = ""
                    Dim exists As Boolean = False
                    Dim newrow As DataRow
                    Dim total As Decimal = 0
                    For Each ETFD In EmployeeTimeForecastDetail
                        If Emp = "" Or Emp <> ETFD.Employee Then
                            If Emp <> "" And Emp <> ETFD.Employee Then
                                DatatableByMonth.Rows.Add(newrow)
                            End If
                            newrow = DatatableByMonth.NewRow
                            newrow.Item("Office") = ETFD.OfficeName
                            newrow.Item("Department") = ETFD.DepartmentName
                            newrow.Item("Employee") = ETFD.Employee
                        End If

                        For x As Integer = 1 To DatatableByMonth.Columns.Count - 1
                            If DatatableByMonth.Columns(x).ColumnName = ETFD.Month Then
                                If Display = 0 Then
                                    newrow.Item(x) = ETFD.ActualHours
                                ElseIf Display = 1 Then
                                    newrow.Item(x) = ETFD.DirectPercent
                                ElseIf Display = 2 Then
                                    newrow.Item(x) = ETFD.ClientHours
                                ElseIf Display = 3 Then
                                    newrow.Item(x) = ETFD.ClientPercent
                                Else
                                    newrow.Item(x) = ETFD.ActualHours
                                End If
                            End If
                        Next
                        Emp = ETFD.Employee
                    Next
                    DatatableByMonth.Rows.Add(newrow)
                    RadGridEmployeeTimeForecastEmployeeutilizationByMonth.DataSource = DatatableByMonth

                ElseIf View = 3 Then
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                    Me.RadGridEmployeeTimeForecastByClient.Visible = True
                    Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                    RadGridEmployeeTimeForecastByClient.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                                   EmployeeCode, AlternateEmployees, False, 0, "", Department, False, SupervisorEmployees, 3, ForecastOnly, _Session.UserCode, Summary)


                    Me.Button5.Visible = True
                ElseIf View = 4 Then
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                    Me.RadGridEmployeeTimeForecastByClient.Visible = False
                    Me.RadGridEmployeeTimeForecastByClientFTE.Visible = True
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                                   EmployeeCode, AlternateEmployees, False, 0, "", Department, False, SupervisorEmployees, 4, ForecastOnly, _Session.UserCode, Summary)
                    Me.Button6.Visible = True
                    Me.RadGridEmployeeTimeForecastByClientFTE.MasterTableView.Columns.Clear()
                    Me.RadGridEmployeeTimeForecastByClientFTE.MasterTableView.DataSource = Nothing

                    Dim DatatableByMonth As DataTable
                    DatatableByMonth = New DataTable("ByClient")

                    Dim dc As DataColumn
                    Dim newrow As DataRow
                    Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

                    ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, MonthTo, YearTo)

                    If Summary = False Then
                        Dim dClient As DataColumn = New DataColumn("ClientName")
                        Dim dDepartment As DataColumn = New DataColumn("DepartmentName")
                        Dim dEmployee As DataColumn = New DataColumn("Employee")
                        Dim dEmployeeCode As DataColumn = New DataColumn("EmployeeCode")
                        DatatableByMonth.Columns.Add(dClient)
                        DatatableByMonth.Columns.Add(dDepartment)
                        DatatableByMonth.Columns.Add(dEmployee)
                        DatatableByMonth.Columns.Add(dEmployeeCode)

                        dc = New DataColumn("UtilizationCurrent", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("UtilizationTotal", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("FTECurrent", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("FTETotal", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        If EmployeeTimeForecastDetail.Count > 0 Then
                            If Display = 0 Or Display = 1 Then
                                'EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0)
                            ElseIf Display = 2 Or Display = 3 Then
                                EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0).ToList
                            End If
                            If EmployeeTimeForecastDetail.Count > 0 Then
                                For Each ETFD In EmployeeTimeForecastDetail
                                    newrow = DatatableByMonth.NewRow
                                    newrow.Item("ClientName") = ETFD.ClientName
                                    newrow.Item("DepartmentName") = ETFD.DepartmentName
                                    newrow.Item("Employee") = ETFD.Employee
                                    newrow.Item("EmployeeCode") = ETFD.EmployeeCode
                                    If Display = 0 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ActualHoursCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ActualHours
                                    ElseIf Display = 1 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.DirectPercentCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.DirectPercent
                                    ElseIf Display = 2 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ClientHoursCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ClientHours
                                    ElseIf Display = 3 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ClientPercentCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ClientPercent
                                    End If
                                    newrow.Item("FTECurrent") = String.Format("{0:#,##0.00}", ETFD.FTECurrent)
                                    newrow.Item("FTETotal") = String.Format("{0:#,##0.00}", ETFD.FTETotal)
                                    DatatableByMonth.Rows.Add(newrow)
                                Next
                            End If
                        End If
                        RadGridEmployeeTimeForecastByClientFTE.MasterTableView.DataKeyNames = New String() {"EmployeeCode"}

                    Else
                        Dim dClient As DataColumn = New DataColumn("ClientName")
                        DatatableByMonth.Columns.Add(dClient)

                        dc = New DataColumn("UtilizationCurrent", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("UtilizationTotal", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("FTECurrent", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        dc = New DataColumn("FTETotal", System.Type.GetType("System.Decimal"))
                        DatatableByMonth.Columns.Add(dc)

                        If EmployeeTimeForecastDetail.Count > 0 Then
                            If Display = 0 Or Display = 1 Then
                                'EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0)
                            ElseIf Display = 2 Or Display = 3 Then
                                EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0).ToList
                            End If
                            If EmployeeTimeForecastDetail.Count > 0 Then
                                For Each ETFD In EmployeeTimeForecastDetail
                                    newrow = DatatableByMonth.NewRow
                                    newrow.Item("ClientName") = ETFD.ClientName
                                    If Display = 0 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ActualHoursCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ActualHours
                                    ElseIf Display = 1 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.DirectPercentCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.DirectPercent
                                    ElseIf Display = 2 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ClientHoursCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ClientHours
                                    ElseIf Display = 3 Then
                                        newrow.Item("UtilizationCurrent") = ETFD.ClientPercentCurrent
                                        newrow.Item("UtilizationTotal") = ETFD.ClientPercent
                                    End If
                                    newrow.Item("FTECurrent") = String.Format("{0:#,##0.00}", ETFD.FTECurrent)
                                    newrow.Item("FTETotal") = String.Format("{0:#,##0.00}", ETFD.FTETotal)
                                    DatatableByMonth.Rows.Add(newrow)
                                Next
                            End If

                        End If

                        RadGridEmployeeTimeForecastByClientFTE.MasterTableView.DataKeyNames = New String() {"ClientName"}

                    End If

                    RadGridEmployeeTimeForecastByClientFTE.DataSource = DatatableByMonth

                End If


                'RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataSource = DataTable
                ' RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataBind()

            End Using

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub DesktopObjectPrint_MyEmployeeTimeForecast_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        LoGlo.PageCultureSet(Me.Page)

    End Sub
    Private Sub DesktopObject_MyEmployeeTimeForecast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim EmployeeCode As String = ""

        If Not Me.IsPostBack Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                EmployeeCode = Session("empcode").ToString

                'If AdvantageFramework.Database.Procedures.EmployeeView.LoadBySupervisorEmployeeCode(DbContext, EmployeeCode).Where(Function(Employee) Employee.Code <> EmployeeCode).Count > 0 Then

                '    ImageButtonShowSupervisorEmployees.Visible = True
                '    LabelShowSupervisorEmployees.Visible = True

                'Else

                '    ImageButtonShowSupervisorEmployees.Visible = False
                '    LabelShowSupervisorEmployees.Visible = False

                'End If

            End Using

        End If

        Dim JobDetail As Boolean = False
        Dim Summary As Boolean = False
        If Request.QueryString("DO") = "My" Then
            Try

                JobDetail = Session("MyETF_JobDetail")

            Catch ex As Exception
                JobDetail = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try
        End If
        If Request.QueryString("DO") = "All" Then
            Try

                JobDetail = Session("AllETF_JobDetail")

            Catch ex As Exception
                JobDetail = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try
        End If


        If JobDetail Then
            If Summary Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.HierarchyDefaultExpanded = True
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.HierarchyDefaultExpanded = True
            End If
            'Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = True
            'Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = True
            ' Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.RetainExpandStateOnRebind = True

        Else
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = False
            'Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.RetainExpandStateOnRebind = False
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.HierarchyDefaultExpanded = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = False
            'Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.RetainExpandStateOnRebind = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.HierarchyDefaultExpanded = False
        End If

        LoadMyEmployeeTimeForecast()

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastOfficeDetailJobComponents)
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastEmployeeutilization)
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastByClient)


    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_DetailTableDataBind(sender As Object, e As GridDetailTableDataBindEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.DetailTableDataBind
        Try

            'objects
            Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim EmployeeCode As String = ""
            Dim DataTable As System.Data.DataTable = Nothing
            Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing
            Dim IsAlternateEmployee As Boolean = False
            Dim AlternateEmployeeID As Integer = 0
            Dim AlternateEmployee As String = ""
            Dim Month As Integer = 0
            Dim Year As Integer = 0
            Dim MonthTo As Integer = 0
            Dim YearTo As Integer = 0
            Dim AlternateEmployees As Boolean = False
            Dim SupervisorEmployees As Boolean = False
            Dim Department As String = ""
            Dim JobDetail As Boolean = False
            Dim ForecastOnly As Boolean = False

            If Request.QueryString("DO") = "My" Then
                Try

                    JobDetail = Session("MyETF_JobDetail")

                Catch ex As Exception
                    JobDetail = False
                End Try

                Try

                    Month = Session("MyETF_Month")

                Catch ex As Exception
                    Month = 0
                End Try

                Try

                    Year = Session("MyETF_Year")

                Catch ex As Exception
                    Year = 0
                End Try

                Try

                    MonthTo = Session("MyETF_MonthTo")

                Catch ex As Exception
                    MonthTo = 0
                End Try

                Try

                    YearTo = Session("MyETF_YearTo")

                Catch ex As Exception
                    YearTo = 0
                End Try

                Try

                    AlternateEmployees = Session("MyETF_AlternateEmployees")

                Catch ex As Exception
                    AlternateEmployees = False
                End Try

                Try

                    SupervisorEmployees = Session("MyETF_SupervisorEmployees")

                Catch ex As Exception
                    SupervisorEmployees = False
                End Try

                Try

                    Department = Session("MyETF_Department")

                Catch ex As Exception
                    Department = False
                End Try

                Try

                    ForecastOnly = Session("MyETF_ForecastOnly")

                Catch ex As Exception
                    ForecastOnly = False
                End Try
            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    JobDetail = Session("AllETF_JobDetail")

                Catch ex As Exception
                    JobDetail = False
                End Try

                Try

                    Month = Session("AllETF_Month")

                Catch ex As Exception
                    Month = 0
                End Try

                Try

                    Year = Session("AllETF_Year")

                Catch ex As Exception
                    Year = 0
                End Try

                Try

                    MonthTo = Session("AllETF_MonthTo")

                Catch ex As Exception
                    MonthTo = 0
                End Try

                Try

                    YearTo = Session("AllETF_YearTo")

                Catch ex As Exception
                    YearTo = 0
                End Try

                Try

                    AlternateEmployees = Session("AllETF_AlternateEmployees")

                Catch ex As Exception
                    AlternateEmployees = False
                End Try

                Try

                    Department = Session("AllETF_Department")

                Catch ex As Exception
                    Department = False
                End Try

                Try

                    ForecastOnly = Session("AllETF_ForecastOnly")

                Catch ex As Exception
                    ForecastOnly = False
                End Try
            End If

            If Month > 0 AndAlso Year > 0 Then

                GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing Then

                    IsAlternateEmployee = GridDataItem.GetDataKeyValue("IsAlternateEmployee")

                    If IsAlternateEmployee = False Then
                        EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode").ToString()
                    End If

                    If IsAlternateEmployee = True Then

                        Try
                            AlternateEmployee = GridDataItem.GetDataKeyValue("Employee")
                        Catch ex As Exception
                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            'EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue, EmployeeCode, Me.CheckboxAlternateEmployee.Checked, IsAlternateEmployee, AlternateEmployeeID, AlternateEmployee)

                            e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                         EmployeeCode, AlternateEmployees, IsAlternateEmployee, 0, AlternateEmployee, Department, JobDetail, False, 0, ForecastOnly, _Session.UserCode, False)

                            For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                    GridColumn = RadGridEmployeeTimeForecastOfficeDetailJobComponents.Columns.FindByDataField(DetailGridColumn.DataField)

                                    If GridColumn IsNot Nothing Then

                                        DetailGridColumn.Display = GridColumn.Display

                                    End If

                                End If

                            Next

                            For Each DetailTable In RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.DetailTables

                                For Each DetailGridColumn In DetailTable.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                    If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                        GridColumn = RadGridEmployeeTimeForecastOfficeDetailJobComponents.Columns.FindByDataField(DetailGridColumn.DataField)

                                        If GridColumn IsNot Nothing Then

                                            DetailGridColumn.Display = GridColumn.Display

                                        End If

                                    End If

                                Next

                            Next

                        End Using

                    Else

                        If EmployeeCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                'EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue, EmployeeCode, False, IsAlternateEmployee, 0, "")

                                e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                         EmployeeCode, AlternateEmployees, False, 0, "", Department, JobDetail, False, 0, ForecastOnly, _Session.UserCode, False)

                                For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                    If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                        GridColumn = RadGridEmployeeTimeForecastOfficeDetailJobComponents.Columns.FindByDataField(DetailGridColumn.DataField)

                                        If GridColumn IsNot Nothing Then

                                            DetailGridColumn.Display = GridColumn.Display

                                        End If

                                    End If

                                Next

                                For Each DetailTable In RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.DetailTables

                                    For Each DetailGridColumn In DetailTable.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                        If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                            GridColumn = RadGridEmployeeTimeForecastOfficeDetailJobComponents.Columns.FindByDataField(DetailGridColumn.DataField)

                                            If GridColumn IsNot Nothing Then

                                                DetailGridColumn.Display = GridColumn.Display

                                            End If

                                        End If

                                    Next

                                Next

                            End Using

                        End If

                    End If

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region
    Private _ZeroHoursColorCSS As String = "standard-white"
    Private _LessThanHoursColorCSS As String = "standard-green-100"
    Private _LessThanAndGreaterThanHoursColorCSS As String = "standard-yellow-100"
    Private _GreaterThanHoursColorCSS As String = "standard-red-100"

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                If Request.QueryString("From") = "myetf" Then
                    str = "MyEmployeeTimeForecast" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents, str)
                    RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExportToExcel()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.NeedDataSource
        Dim View As Integer = 0
        Dim Display As Integer = 0
        Dim Summary As Boolean = False
        If Request.QueryString("DO") = "My" Then
            Try

                View = Session("MyETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("MyETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If Request.QueryString("DO") = "All" Then
            Try

                View = Session("AllETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("AllETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If

        If View = 0 Then
            LoadMyEmployeeTimeForecast()
        End If

    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilization_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilization.NeedDataSource
        Dim View As Integer = 0
        Dim Display As Integer = 0
        Dim Summary As Boolean = False
        If Request.QueryString("DO") = "My" Then
            Try

                View = Session("MyETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("MyETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If Request.QueryString("DO") = "All" Then
            Try

                View = Session("AllETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("AllETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If

        If Display = 1 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.NeedDataSource
        Dim View As Integer = 0
        Dim Display As Integer = 0
        Dim Summary As Boolean = False
        If Request.QueryString("DO") = "My" Then
            Try

                View = Session("MyETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("MyETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If Request.QueryString("DO") = "All" Then
            Try

                View = Session("AllETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("AllETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If

        If Display = 2 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForcastEmployeeSummary_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForcastEmployeeSummary.NeedDataSource
        Dim View As Integer = 0
        Dim Display As Integer = 0
        Dim Summary As Boolean = False
        If Request.QueryString("DO") = "My" Then
            Try

                View = Session("MyETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("MyETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("MyETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If Request.QueryString("DO") = "All" Then
            Try

                View = Session("AllETF_View")

            Catch ex As Exception
                View = False
            End Try

            Try

                Display = Session("AllETF_Display")

            Catch ex As Exception
                Display = False
            End Try

            Try

                Summary = Session("AllETF_Summary")

            Catch ex As Exception
                Summary = False
            End Try

        End If
        If View = 0 And Summary = True Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub

    Private Sub RadGridEmployeeTimeForcastEmployeeSummary_DetailTableDataBind(sender As Object, e As GridDetailTableDataBindEventArgs) Handles RadGridEmployeeTimeForcastEmployeeSummary.DetailTableDataBind
        Try

            'objects
            Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim EmployeeCode As String = ""
            Dim DataTable As System.Data.DataTable = Nothing
            Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing
            Dim IsAlternateEmployee As Boolean = False
            Dim AlternateEmployeeID As Integer = 0
            Dim AlternateEmployee As String = ""
            Dim Month As Integer = 0
            Dim Year As Integer = 0
            Dim MonthTo As Integer = 0
            Dim YearTo As Integer = 0
            Dim AlternateEmployees As Boolean = False
            Dim SupervisorEmployees As Boolean = False
            Dim Department As String = ""
            Dim JobDetail As Boolean = False
            Dim ForecastOnly As Boolean = False

            If Request.QueryString("DO") = "My" Then
                Try

                    JobDetail = Session("MyETF_JobDetail")

                Catch ex As Exception
                    JobDetail = False
                End Try

                Try

                    Month = Session("MyETF_Month")

                Catch ex As Exception
                    Month = 0
                End Try

                Try

                    Year = Session("MyETF_Year")

                Catch ex As Exception
                    Year = 0
                End Try

                Try

                    MonthTo = Session("MyETF_MonthTo")

                Catch ex As Exception
                    MonthTo = 0
                End Try

                Try

                    YearTo = Session("MyETF_YearTo")

                Catch ex As Exception
                    YearTo = 0
                End Try

                Try

                    AlternateEmployees = Session("MyETF_AlternateEmployees")

                Catch ex As Exception
                    AlternateEmployees = False
                End Try

                Try

                    SupervisorEmployees = Session("MyETF_SupervisorEmployees")

                Catch ex As Exception
                    SupervisorEmployees = False
                End Try

                Try

                    Department = Session("MyETF_Department")

                Catch ex As Exception
                    Department = False
                End Try

                Try

                    ForecastOnly = Session("MyETF_ForecastOnly")

                Catch ex As Exception
                    ForecastOnly = False
                End Try
            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    JobDetail = Session("AllETF_JobDetail")

                Catch ex As Exception
                    JobDetail = False
                End Try

                Try

                    Month = Session("AllETF_Month")

                Catch ex As Exception
                    Month = 0
                End Try

                Try

                    Year = Session("AllETF_Year")

                Catch ex As Exception
                    Year = 0
                End Try

                Try

                    MonthTo = Session("AllETF_MonthTo")

                Catch ex As Exception
                    MonthTo = 0
                End Try

                Try

                    YearTo = Session("AllETF_YearTo")

                Catch ex As Exception
                    YearTo = 0
                End Try

                Try

                    AlternateEmployees = Session("AllETF_AlternateEmployees")

                Catch ex As Exception
                    AlternateEmployees = False
                End Try

                Try

                    Department = Session("AllETF_Department")

                Catch ex As Exception
                    Department = False
                End Try

                Try

                    ForecastOnly = Session("AllETF_ForecastOnly")

                Catch ex As Exception
                    ForecastOnly = False
                End Try
            End If

            If Month > 0 AndAlso Year > 0 Then

                GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing Then

                    IsAlternateEmployee = GridDataItem.GetDataKeyValue("IsAlternateEmployee")

                    If IsAlternateEmployee = False Then
                        EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode").ToString()
                    End If

                    If IsAlternateEmployee = True Then

                        Try
                            AlternateEmployee = GridDataItem.GetDataKeyValue("Employee")
                        Catch ex As Exception
                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            'EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue, EmployeeCode, Me.CheckboxAlternateEmployee.Checked, IsAlternateEmployee, AlternateEmployeeID, AlternateEmployee)

                            e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                         EmployeeCode, AlternateEmployees, IsAlternateEmployee, 0, AlternateEmployee, Department, JobDetail, False, 0, ForecastOnly, _Session.UserCode, True)

                            'e.DetailTableView.DataSource = (From Entity In EmployeeTimeForecastDetail
                            '                                Group Entity By Entity.ClientCode,
                            '                                                Entity.JobAndJobComponent,
                            '                                                Entity.SalesClass,
                            '                                                Entity.AccountExecutive Into ETFD = Group
                            '                                Select ClientCode,
                            '                                       JobAndJobComponent,
                            '                                       SalesClass,
                            '                                       AccountExecutive,
                            '                                       ForecastedHours = ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                            '                                       ActualHours = ETFD.Sum(Function(MPC) MPC.ActualHours),
                            '                                       VarianceHours = ETFD.Sum(Function(MPC) MPC.ActualHours) - ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                            '                                       ForecastedAmount = ETFD.Sum(Function(MPC) MPC.ForecastedAmount),
                            '                                       ActualAmount = ETFD.Sum(Function(MPC) MPC.ActualAmount),
                            '                                       VarianceAmount = ETFD.Sum(Function(MPC) MPC.ActualAmount) - ETFD.Sum(Function(MPC) MPC.ForecastedAmount)
                            '                                Order By JobAndJobComponent)

                            For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                    GridColumn = RadGridEmployeeTimeForcastEmployeeSummary.Columns.FindByDataField(DetailGridColumn.DataField)

                                    If GridColumn IsNot Nothing Then

                                        DetailGridColumn.Display = GridColumn.Display

                                    End If

                                End If

                            Next

                            For Each DetailTable In RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.DetailTables

                                For Each DetailGridColumn In DetailTable.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                    If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                        GridColumn = RadGridEmployeeTimeForcastEmployeeSummary.Columns.FindByDataField(DetailGridColumn.DataField)

                                        If GridColumn IsNot Nothing Then

                                            DetailGridColumn.Display = GridColumn.Display

                                        End If

                                    End If

                                Next

                            Next

                        End Using

                    Else

                        If EmployeeCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                'EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue, EmployeeCode, False, IsAlternateEmployee, 0, "")

                                e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, Year, Month, YearTo, MonthTo,
                                                                                                                                                         EmployeeCode, AlternateEmployees, False, 0, "", Department, JobDetail, False, 0, ForecastOnly, _Session.UserCode, False)

                                'e.DetailTableView.DataSource = (From Entity In EmployeeTimeForecastDetail
                                '                                Group Entity By Entity.ClientCode,
                                '                                            Entity.JobAndJobComponent,
                                '                                            Entity.SalesClass,
                                '                                            Entity.AccountExecutive Into ETFD = Group
                                '                                Select ClientCode,
                                '                                       JobAndJobComponent,
                                '                                       SalesClass,
                                '                                       AccountExecutive,
                                '                                       ForecastedHours = ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                                '                                       ActualHours = ETFD.Sum(Function(MPC) MPC.ActualHours),
                                '                                       VarianceHours = ETFD.Sum(Function(MPC) MPC.ActualHours) - ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                                '                                       ForecastedAmount = ETFD.Sum(Function(MPC) MPC.ForecastedAmount),
                                '                                       ActualAmount = ETFD.Sum(Function(MPC) MPC.ActualAmount),
                                '                                       VarianceAmount = ETFD.Sum(Function(MPC) MPC.ActualAmount) - ETFD.Sum(Function(MPC) MPC.ForecastedAmount)
                                '                                Order By JobAndJobComponent)

                                For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                    If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                        GridColumn = RadGridEmployeeTimeForcastEmployeeSummary.Columns.FindByDataField(DetailGridColumn.DataField)

                                        If GridColumn IsNot Nothing Then

                                            DetailGridColumn.Display = GridColumn.Display

                                        End If

                                    End If

                                Next

                                For Each DetailTable In RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.DetailTables

                                    For Each DetailGridColumn In DetailTable.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                                        If DetailGridColumn.DataField <> "JobAndJobComponent" And DetailGridColumn.DataField <> "SalesClass" And DetailGridColumn.DataField <> "AccountExecutive" Then

                                            GridColumn = RadGridEmployeeTimeForcastEmployeeSummary.Columns.FindByDataField(DetailGridColumn.DataField)

                                            If GridColumn IsNot Nothing Then

                                                DetailGridColumn.Display = GridColumn.Display

                                            End If

                                        End If

                                    Next

                                Next

                            End Using

                        End If

                    End If

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.ItemDataBound
        Try
            Dim griddataitem As GridDataItem
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                For x As Integer = 0 To e.Item.Cells.Count - 1
                    If e.Item.Cells(x).Text = "" Or e.Item.Cells(x).Text = "&nbsp;" Then
                        e.Item.Cells(x).Text = "0.00"
                    End If

                    If e.Item.Cells(x).Text = "0.00%" Then
                        e.Item.Cells(x).Text = "0.00"
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_PreRender(sender As Object, e As EventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.PreRender
        Try
            For Each column In RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.AutoGeneratedColumns
                If column.UniqueName = "Office" Then
                    column.ItemStyle.Width = 75
                ElseIf column.UniqueName = "Department" Then
                    column.ItemStyle.Width = 75
                ElseIf column.UniqueName = "Employee" Then
                    column.ItemStyle.Width = 75
                Else
                    column.ItemStyle.Width = 50
                End If
                column.HeaderStyle.Font.Bold = True
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.ColumnCreated
        Try
            Dim col As GridBoundColumn = e.Column

            Dim View As Integer = 0
            Dim Display As Integer = 0
            Dim Summary As Boolean = False

            If Request.QueryString("DO") = "My" Then
                Try

                    View = Session("MyETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("MyETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("MyETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    View = Session("AllETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("AllETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("AllETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If e.Column.UniqueName <> "Office" AndAlso e.Column.UniqueName <> "Department" AndAlso e.Column.UniqueName <> "Employee" AndAlso e.Column.UniqueName <> "EmployeeCode" Then
                col.AllowFiltering = False
                col.Aggregate = GridAggregateFunction.Sum
                If Display = 0 Or Display = 2 Then
                    col.DataFormatString = "{0:#,##0.00}"
                End If
                If Display = 1 Or Display = 3 Then
                    col.DataFormatString = "{0:#,##0.00}%"
                End If
            Else
                col.CurrentFilterFunction = GridKnownFunction.Contains
                col.FilterDelay = 1250
                If e.Column.UniqueName = "Office" Then
                    col.SortExpression = "Office"
                End If
                If e.Column.UniqueName = "Department" Then
                    col.SortExpression = "Department"
                End If
                If e.Column.UniqueName = "Employee" Then
                    col.SortExpression = "Employee"
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClientFTE_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridEmployeeTimeForecastByClientFTE.ColumnCreated
        Try
            Dim col As GridBoundColumn = e.Column
            Dim View As Integer = 0
            Dim Display As Integer = 0
            Dim Summary As Boolean = False

            If Request.QueryString("DO") = "My" Then
                Try

                    View = Session("MyETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("MyETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("MyETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    View = Session("AllETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("AllETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("AllETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If e.Column.UniqueName <> "ClientName" AndAlso e.Column.UniqueName <> "DepartmentName" AndAlso e.Column.UniqueName <> "Employee" AndAlso e.Column.UniqueName <> "EmployeeCode" Then
                col.AllowFiltering = False
            Else
                col.CurrentFilterFunction = GridKnownFunction.Contains
                col.FilterDelay = 1250
                If e.Column.UniqueName = "ClientName" Then
                    col.SortExpression = "ClientName"
                End If
                If e.Column.UniqueName = "DepartmentName" Then
                    col.SortExpression = "DepartmentName"
                End If
                If e.Column.UniqueName = "Employee" Then
                    col.SortExpression = "Employee"
                End If
            End If

            If e.Column.UniqueName = "UtilizationCurrent" Or e.Column.UniqueName = "UtilizationTotal" Or
                e.Column.UniqueName = "UtilizationCurrent1" Or e.Column.UniqueName = "UtilizationTotal1" Then
                col.Aggregate = GridAggregateFunction.Sum
                If Display = 0 Or Display = 2 Then
                    col.DataFormatString = "{0:#,##0.00}"
                End If
                If Display = 1 Or Display = 3 Then
                    col.DataFormatString = "{0:#,##0.00}%"
                End If
            End If

            If e.Column.UniqueName = "FTECurrent" Or e.Column.UniqueName = "FTETotal" Or
                e.Column.UniqueName = "FTECurrent1" Or e.Column.UniqueName = "FTETotal1" Then
                col.Aggregate = GridAggregateFunction.Sum
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClientFTE_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEmployeeTimeForecastByClientFTE.ItemDataBound
        Try
            Dim griddataitem As GridDataItem
            Dim View As Integer = 0
            Dim Display As Integer = 0
            Dim Summary As Boolean = False

            If Request.QueryString("DO") = "My" Then
                Try

                    View = Session("MyETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("MyETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("MyETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    View = Session("AllETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("AllETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("AllETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                griddataitem = e.Item

                Dim DirectPercent As Decimal = 0
                Dim emp As String '= griddataitem("EmployeeCode").Text
                If Summary = False Then
                    emp = griddataitem.GetDataKeyValue("EmployeeCode")
                    Dim employee As AdvantageFramework.Database.Views.Employee = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, emp)
                    End Using

                    If employee IsNot Nothing Then
                        DirectPercent = If(employee.DirectHours Is Nothing, 0, employee.DirectHours)
                    End If
                End If


                For x As Integer = 3 To e.Item.Cells.Count - 1
                    If e.Item.Cells(x).Text = "" Or e.Item.Cells(x).Text = "&nbsp;" Then
                        e.Item.Cells(x).Text = "0.00"
                    Else
                        If (Display = 1 Or Display = 3) And e.Item.Cells(x).Text.Contains("%") Then
                            If DirectPercent > 0 And IsNumeric(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                If CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) = 0 Then
                                    e.Item.Cells(x).CssClass = _ZeroHoursColorCSS
                                ElseIf DirectPercent < CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                    e.Item.Cells(x).CssClass = _GreaterThanHoursColorCSS
                                ElseIf DirectPercent >= CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                    e.Item.Cells(x).CssClass = _LessThanHoursColorCSS
                                ElseIf DirectPercent = CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                    e.Item.Cells(x).CssClass = _ZeroHoursColorCSS
                                End If
                            End If
                        End If
                    End If

                    If e.Item.Cells(x).Text = "0.00%" Then
                        e.Item.Cells(x).Text = "0.00"
                    End If
                Next

            ElseIf e.Item.ItemType = GridItemType.Footer Then

                Dim footeritem As GridFooterItem = e.Item

                If Summary = False Then
                    footeritem("UtilizationCurrent").Text = footeritem("UtilizationCurrent").Text.Replace("Sum :", "")
                    footeritem("UtilizationTotal").Text = footeritem("UtilizationTotal").Text.Replace("Sum :", "")
                    footeritem("FTECurrent").Text = footeritem("FTECurrent").Text.Replace("Sum :", "")
                    footeritem("FTETotal").Text = footeritem("FTETotal").Text.Replace("Sum :", "")
                Else
                    footeritem("UtilizationCurrent1").Text = footeritem("UtilizationCurrent1").Text.Replace("Sum :", "")
                    footeritem("UtilizationTotal1").Text = footeritem("UtilizationTotal1").Text.Replace("Sum :", "")
                    footeritem("FTECurrent1").Text = footeritem("FTECurrent1").Text.Replace("Sum :", "")
                    footeritem("FTETotal1").Text = footeritem("FTETotal1").Text.Replace("Sum :", "")
                End If

            ElseIf e.Item.ItemType = GridItemType.GroupFooter Then

                Dim footeritem As GridGroupFooterItem = e.Item
                If Summary = False Then
                    footeritem("UtilizationCurrent").Text = footeritem("UtilizationCurrent").Text.Replace("Sum :", "")
                    footeritem("UtilizationTotal").Text = footeritem("UtilizationTotal").Text.Replace("Sum :", "")
                    footeritem("FTECurrent").Text = footeritem("FTECurrent").Text.Replace("Sum :", "")
                    footeritem("FTETotal").Text = footeritem("FTETotal").Text.Replace("Sum :", "")
                Else
                    footeritem("UtilizationCurrent1").Text = footeritem("UtilizationCurrent1").Text.Replace("Sum :", "")
                    footeritem("UtilizationTotal1").Text = footeritem("UtilizationTotal1").Text.Replace("Sum :", "")
                    footeritem("FTECurrent1").Text = footeritem("FTECurrent1").Text.Replace("Sum :", "")
                    footeritem("FTETotal1").Text = footeritem("FTETotal1").Text.Replace("Sum :", "")
                End If

            End If

            'For Each column In RadGridEmployeeTimeForecastByClientFTE.MasterTableView.RenderColumns
            '    If column.UniqueName = "UtilizationCurrent" Then
            '        column = GridAggregateFunction.Sum
            '    End If
            'Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClientFTE_PreRender(sender As Object, e As EventArgs) Handles RadGridEmployeeTimeForecastByClientFTE.PreRender
        Try
            For Each column In RadGridEmployeeTimeForecastByClientFTE.MasterTableView.AutoGeneratedColumns
                If column.UniqueName = "ClientName" Then
                    column.ItemStyle.Width = 75
                ElseIf column.UniqueName = "DepartmentName" Then
                    column.ItemStyle.Width = 75
                ElseIf column.UniqueName = "Employee" Then
                    column.ItemStyle.Width = 75
                Else
                    column.ItemStyle.Width = 50
                End If
                column.HeaderStyle.Font.Bold = True

                If column.UniqueName = "EmployeeCode" Then
                    column.Visible = False
                End If

                If column.UniqueName <> "ClientName" And column.UniqueName = "DepartmentName" And column.UniqueName = "Employee" And column.UniqueName = "EmployeeCode" Then
                    column.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                End If

            Next


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClient_PreRender(sender As Object, e As EventArgs) Handles RadGridEmployeeTimeForecastByClient.PreRender
        Try
            Dim View As Integer = 0
            Dim Display As Integer = 0
            Dim Summary As Boolean = False
            If Request.QueryString("DO") = "My" Then
                Try

                    View = Session("MyETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("MyETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("MyETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            If Request.QueryString("DO") = "All" Then
                Try

                    View = Session("AllETF_View")

                Catch ex As Exception
                    View = False
                End Try

                Try

                    Display = Session("AllETF_Display")

                Catch ex As Exception
                    Display = False
                End Try

                Try

                    Summary = Session("AllETF_Summary")

                Catch ex As Exception
                    Summary = False
                End Try

            End If
            For Each column In RadGridEmployeeTimeForecastByClient.MasterTableView.Columns

                If View = 3 And Summary = True Then
                    If column.UniqueName = "GridBoundColumnDepartment" Then
                        column.Display = False
                    End If
                    If column.UniqueName = "GridBoundColumnEmployee" Then
                        column.Display = False
                    End If
                Else
                    If column.UniqueName = "GridBoundColumnDepartment" Then
                        column.Display = True
                    End If
                    If column.UniqueName = "GridBoundColumnEmployee" Then
                        column.Display = True
                    End If
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
