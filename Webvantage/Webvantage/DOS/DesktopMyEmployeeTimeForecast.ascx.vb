Imports Telerik.Web.UI

Public Class DesktopMyEmployeeTimeForecast
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private filter As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub EnableandDisablecontrols()
        Try
            If RadComboBoxView.SelectedValue = 0 Then
                trAlternateEmployee.Visible = True
                trIncludeJobDetail.Visible = True
                trIncludeSupervisorEmployees.Visible = True
                trForecastOnly.Visible = True
                trSummary.Visible = True
                trClientGroup.Visible = False
                trOfficeGroup.Visible = True
                Me.CheckboxAlternateEmployee.Checked = False
                Me.CheckboxAlternateEmployee.Visible = True
                Me.CheckboxIncludeJobDetail.Checked = False
                Me.CheckboxIncludeJobDetail.Visible = True
                'Me.CheckboxIncludeSupervisorEmployees.Checked = False
                'Me.CheckboxIncludeSupervisorEmployees.Enabled = True
                Me.CheckboxForecastOnly.Checked = False
                Me.CheckboxForecastOnly.Visible = True
                Me.RadComboBoxDisplay.Visible = False
                Me.Label4.Visible = False
                Me.CheckBoxClientGroup.Checked = False
                Me.CheckBoxClientGroup.Enabled = False
                Me.CheckBoxOfficeGroup.Enabled = True
                Me.CheckBoxOfficeGroup.Checked = False
                Me.Label5.Visible = False
                'Me.CheckBoxDepartmentGroup.Enabled = True
                'Me.CheckBoxDepartmentGroup.Checked = False
                'Me.CheckBoxEmployeeGroup.Enabled = True
                'Me.CheckBoxEmployeeGroup.Checked = False

                'Me.RadComboBoxDepartment.Enabled = True
                If Me.CheckboxSummary.Checked Then
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
                Else
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
                End If

            End If
            If RadComboBoxView.SelectedValue = 1 Then
                trAlternateEmployee.Visible = False
                trIncludeJobDetail.Visible = False
                trForecastOnly.Visible = False
                trSummary.Visible = False
                trClientGroup.Visible = False
                trOfficeGroup.Visible = True
                Me.CheckboxSummary.Checked = False
                Me.CheckboxAlternateEmployee.Checked = False
                Me.CheckboxAlternateEmployee.Visible = False
                Me.CheckboxIncludeJobDetail.Checked = False
                Me.CheckboxIncludeJobDetail.Visible = False
                'Me.CheckboxIncludeSupervisorEmployees.Checked = False
                'Me.CheckboxIncludeSupervisorEmployees.Enabled = False
                Me.CheckboxForecastOnly.Checked = False
                Me.CheckboxForecastOnly.Visible = False
                Me.RadComboBoxDisplay.Visible = False
                Me.Label4.Visible = False
                Me.CheckBoxClientGroup.Checked = False
                Me.CheckBoxClientGroup.Enabled = False
                Me.CheckBoxOfficeGroup.Enabled = True
                Me.CheckBoxOfficeGroup.Checked = False
                Me.Label5.Visible = False
                'Me.CheckBoxDepartmentGroup.Enabled = False
                'Me.CheckBoxDepartmentGroup.Checked = False
                'Me.CheckBoxEmployeeGroup.Enabled = False
                'Me.CheckBoxEmployeeGroup.Checked = False

                'Me.RadComboBoxDepartment.Enabled = False
                Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()


            End If
            If RadComboBoxView.SelectedValue = 2 Then
                trAlternateEmployee.Visible = False
                trIncludeJobDetail.Visible = False
                trForecastOnly.Visible = False
                trSummary.Visible = False
                trClientGroup.Visible = False
                trOfficeGroup.Visible = True
                Me.Label5.Visible = False
                Me.CheckboxSummary.Checked = False
                Me.CheckboxAlternateEmployee.Checked = False
                Me.CheckboxAlternateEmployee.Visible = False
                Me.CheckboxIncludeJobDetail.Checked = False
                Me.CheckboxIncludeJobDetail.Visible = False
                'Me.CheckboxIncludeSupervisorEmployees.Checked = False
                'Me.CheckboxIncludeSupervisorEmployees.Enabled = False
                Me.CheckboxForecastOnly.Checked = False
                Me.CheckboxForecastOnly.Visible = False
                Me.RadComboBoxDisplay.Visible = True
                Me.Label4.Visible = True
                Me.CheckBoxClientGroup.Checked = False
                Me.CheckBoxClientGroup.Enabled = False
                Me.CheckBoxOfficeGroup.Enabled = True
                Me.CheckBoxOfficeGroup.Checked = False
                'Me.CheckBoxDepartmentGroup.Enabled = False
                'Me.CheckBoxDepartmentGroup.Checked = False
                'Me.CheckBoxEmployeeGroup.Enabled = False
                'Me.CheckBoxEmployeeGroup.Checked = False

                'Me.RadComboBoxDepartment.Enabled = False
                Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
            End If
            If RadComboBoxView.SelectedValue = 3 Then
                trAlternateEmployee.Visible = True
                trIncludeJobDetail.Visible = False
                trIncludeSupervisorEmployees.Visible = True
                trForecastOnly.Visible = True
                trSummary.Visible = True
                trClientGroup.Visible = True
                trOfficeGroup.Visible = False
                Me.CheckboxAlternateEmployee.Checked = False
                Me.CheckboxAlternateEmployee.Visible = True
                Me.CheckboxIncludeJobDetail.Checked = False
                Me.CheckboxIncludeJobDetail.Visible = True
                'Me.CheckboxIncludeSupervisorEmployees.Checked = False
                'Me.CheckboxIncludeSupervisorEmployees.Enabled = True
                Me.CheckboxForecastOnly.Checked = False
                Me.CheckboxForecastOnly.Visible = True
                Me.RadComboBoxDisplay.Visible = False
                Me.Label4.Visible = False
                Me.CheckBoxOfficeGroup.Enabled = False
                Me.CheckBoxOfficeGroup.Checked = False
                Me.CheckBoxClientGroup.Checked = False
                Me.CheckBoxClientGroup.Enabled = True
                Me.Label5.Visible = True
                'Me.CheckBoxDepartmentGroup.Enabled = True
                'Me.CheckBoxDepartmentGroup.Checked = False
                'Me.CheckBoxEmployeeGroup.Enabled = True
                'Me.CheckBoxEmployeeGroup.Checked = False

                'Me.RadComboBoxDepartment.Enabled = True
                Me.RadGridEmployeeTimeForecastByClient.Rebind()
            End If
            If RadComboBoxView.SelectedValue = 4 Then
                trAlternateEmployee.Visible = False
                trIncludeJobDetail.Visible = False
                trIncludeSupervisorEmployees.Visible = True
                trForecastOnly.Visible = False
                trSummary.Visible = True
                trClientGroup.Visible = True
                trOfficeGroup.Visible = False
                Me.CheckboxAlternateEmployee.Checked = False
                Me.CheckboxAlternateEmployee.Visible = True
                Me.CheckboxIncludeJobDetail.Checked = False
                Me.CheckboxIncludeJobDetail.Visible = True
                'Me.CheckboxIncludeSupervisorEmployees.Checked = False
                'Me.CheckboxIncludeSupervisorEmployees.Enabled = True
                Me.CheckboxForecastOnly.Checked = False
                Me.CheckboxForecastOnly.Visible = True
                Me.RadComboBoxDisplay.Visible = True
                Me.Label4.Visible = True
                Me.CheckBoxOfficeGroup.Enabled = False
                Me.CheckBoxOfficeGroup.Checked = False
                Me.CheckBoxClientGroup.Checked = False
                Me.CheckBoxClientGroup.Enabled = True
                Me.Label5.Visible = True
                'Me.CheckBoxDepartmentGroup.Enabled = True
                'Me.CheckBoxDepartmentGroup.Checked = False
                'Me.CheckBoxEmployeeGroup.Enabled = True
                'Me.CheckBoxEmployeeGroup.Checked = False

                'Me.RadComboBoxDepartment.Enabled = True
                'Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadMyEmployeeTimeForecast()
        Try

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim SupervisedEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing
            Dim EmployeeTimeForecastSummary As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastSummary) = Nothing
            Dim EmpCode As String = ""
            Dim s As String = ""
            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim FromYear As Integer
            Dim FromMonth As Integer
            Dim ToYear As Integer
            Dim ToMonth As Integer
            Dim FromStartDate As DateTime
            Dim ToStartDate As DateTime
            Dim FromPostPeriodInt As Integer
            Dim ToPostPeriodInt As Integer

            If DropDownListMonth.SelectedValue <> "" AndAlso IsNumeric(DropDownListMonth.SelectedValue) AndAlso
                    DropDownListPostPeriodYear.SelectedValue <> "" AndAlso IsNumeric(DropDownListPostPeriodYear.SelectedValue) AndAlso
                    RadComboBoxMonthTo.SelectedValue <> "" AndAlso IsNumeric(RadComboBoxMonthTo.SelectedValue) AndAlso
                    RadComboBoxYearTo.SelectedValue <> "" AndAlso IsNumeric(RadComboBoxYearTo.SelectedValue) Then

                EmpCode = Session("empcode").ToString
                FromYear = DropDownListPostPeriodYear.SelectedValue
                FromMonth = DropDownListMonth.SelectedValue
                ToYear = RadComboBoxYearTo.SelectedValue
                ToMonth = RadComboBoxMonthTo.SelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    'EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.BuildMyEmployeeTimeForecastDesktopObjectDataTable(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue, EmpCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "")

                    'Try

                    '    If RadComboBoxDepartment.SelectedValue <> "" Then

                    '        EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(Entity) Entity.DepartmentCode = RadComboBoxDepartment.SelectedValue).ToList

                    '    End If

                    'Catch ex As Exception

                    'End Try

                    If Me.RadComboBoxView.SelectedValue = 0 Then
                        If Me.CheckboxSummary.Checked Then
                            Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = True
                            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                            RadGridEmployeeTimeForcastEmployeeSummary.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                             EmpCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked,
                                                                                                                                                             Me.RadComboBoxView.SelectedValue, Me.CheckboxForecastOnly.Checked, _Session.UserCode, Me.CheckboxSummary.Checked)

                            Try
                                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim gbf As Telerik.Web.UI.GridGroupByField

                                'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then
                                RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.GroupByExpressions.Clear()
                                'End If

                                If Me.CheckBoxOfficeGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "OfficeName"
                                    gbf.FieldAlias = "Office"
                                    gbf.HeaderText = ""
                                    GrpExpr2.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "OfficeCode"
                                    gbf.HeaderText = ""
                                    GrpExpr2.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForcastEmployeeSummary
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                    End With
                                End If
                                If Me.CheckBoxDepartmentGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "DepartmentName"
                                    gbf.FieldAlias = "Department"
                                    gbf.HeaderText = ""
                                    GrpExpr.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "DepartmentCode"
                                    gbf.FieldAlias = "DepartmentCode"
                                    gbf.HeaderText = ""
                                    GrpExpr.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForcastEmployeeSummary
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                    End With
                                End If
                                If Me.CheckBoxEmployeeGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "Employee"
                                    gbf.FieldAlias = "Employee"
                                    gbf.HeaderText = ""
                                    GrpExpr3.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "Employee"
                                    gbf.FieldAlias = "EmployeeCode"
                                    gbf.HeaderText = ""
                                    GrpExpr3.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForcastEmployeeSummary
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                    End With
                                End If

                            Catch ex As Exception

                            End Try
                        Else
                            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = True
                            Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False
                            RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                             EmpCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked,
                                                                                                                                                             Me.RadComboBoxView.SelectedValue, Me.CheckboxForecastOnly.Checked, _Session.UserCode, Me.CheckboxSummary.Checked)

                            Try
                                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                                Dim gbf As Telerik.Web.UI.GridGroupByField

                                'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then
                                RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.GroupByExpressions.Clear()
                                'End If

                                If Me.CheckBoxOfficeGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "OfficeName"
                                    gbf.FieldAlias = "Office"
                                    gbf.HeaderText = ""
                                    GrpExpr2.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "OfficeCode"
                                    gbf.HeaderText = ""
                                    GrpExpr2.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                    End With
                                End If
                                If Me.CheckBoxDepartmentGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "DepartmentName"
                                    gbf.FieldAlias = "Department"
                                    gbf.HeaderText = ""
                                    GrpExpr.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "DepartmentCode"
                                    gbf.FieldAlias = "DepartmentCode"
                                    gbf.HeaderText = ""
                                    GrpExpr.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                    End With
                                End If
                                If Me.CheckBoxEmployeeGroup.Checked Then
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "Employee"
                                    gbf.FieldAlias = "Employee"
                                    gbf.HeaderText = ""
                                    GrpExpr3.SelectFields.Add(gbf)
                                    gbf = New Telerik.Web.UI.GridGroupByField
                                    gbf.FieldName = "Employee"
                                    gbf.FieldAlias = "EmployeeCode"
                                    gbf.HeaderText = ""
                                    GrpExpr3.GroupByFields.Add(gbf)
                                    With Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents
                                        .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                    End With
                                End If

                            Catch ex As Exception

                            End Try
                        End If
                        Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                        Me.RadGridEmployeeTimeForecastByClient.Visible = False
                        Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False



                    ElseIf Me.RadComboBoxView.SelectedValue = 1 Then
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = True
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                        Me.RadGridEmployeeTimeForecastByClient.Visible = False
                        Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                        RadGridEmployeeTimeForecastEmployeeutilization.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         EmpCode, 0, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked, Me.RadComboBoxView.SelectedValue, 0, _Session.UserCode, False)


                        Try
                            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim gbf As Telerik.Web.UI.GridGroupByField

                            'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then
                            RadGridEmployeeTimeForecastEmployeeutilization.MasterTableView.GroupByExpressions.Clear()
                            'End If

                            If Me.CheckBoxOfficeGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "OfficeName"
                                gbf.FieldAlias = "Office"
                                gbf.HeaderText = ""
                                GrpExpr2.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "OfficeCode"
                                gbf.HeaderText = ""
                                GrpExpr2.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilization
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                End With
                            End If
                            If Me.CheckBoxDepartmentGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentName"
                                gbf.FieldAlias = "Department"
                                gbf.HeaderText = ""
                                GrpExpr.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentCode"
                                gbf.FieldAlias = "DepartmentCode"
                                gbf.HeaderText = ""
                                GrpExpr.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilization
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                End With
                            End If
                            If Me.CheckBoxEmployeeGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "Employee"
                                gbf.HeaderText = ""
                                GrpExpr3.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "EmployeeCode"
                                gbf.HeaderText = ""
                                GrpExpr3.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilization
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                End With
                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf Me.RadComboBoxView.SelectedValue = 2 Then
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = True
                        Me.RadGridEmployeeTimeForecastByClient.Visible = False
                        Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                        EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                       EmpCode, 0, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked, Me.RadComboBoxView.SelectedValue, 0, _Session.UserCode, False)


                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.Columns.Clear()
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.DataSource = Nothing

                        Dim DatatableByMonth As DataTable
                        DatatableByMonth = New DataTable("ByMonth")

                        Dim dOffice As DataColumn = New DataColumn("Office")
                        Dim dDepartment As DataColumn = New DataColumn("Department")
                        Dim dEmployee As DataColumn = New DataColumn("Employee")
                        Dim dEmployeeCode As DataColumn = New DataColumn("EmployeeCode")
                        DatatableByMonth.Columns.Add(dOffice)
                        DatatableByMonth.Columns.Add(dDepartment)
                        DatatableByMonth.Columns.Add(dEmployee)
                        DatatableByMonth.Columns.Add(dEmployeeCode)


                        Dim dc As DataColumn
                        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
                        Dim StartDate As DateTime = Nothing

                        If FromYear <> 0 AndAlso FromMonth <> 0 AndAlso ToYear <> 0 AndAlso ToMonth <> 0 Then

                            If FromMonth >= 1 And FromMonth <= 9 Then
                                FromPostPeriodInt = FromYear.ToString & "0" & FromMonth.ToString
                            Else
                                FromPostPeriodInt = FromYear.ToString & FromMonth.ToString
                            End If

                            If ToMonth >= 1 And ToMonth <= 9 Then
                                ToPostPeriodInt = ToYear.ToString & "0" & ToMonth.ToString
                            Else
                                ToPostPeriodInt = ToYear.ToString & ToMonth.ToString
                            End If

                        End If

                        FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, FromPostPeriodInt.ToString)
                        ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, ToPostPeriodInt.ToString)

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
                        If EmployeeTimeForecastDetail.Count > 0 Then
                            For Each ETFD In EmployeeTimeForecastDetail
                                If Emp = "" Or Emp <> ETFD.Employee Then
                                    If Emp <> "" And Emp <> ETFD.Employee Then
                                        DatatableByMonth.Rows.Add(newrow)
                                    End If
                                    newrow = DatatableByMonth.NewRow
                                    newrow.Item("Office") = ETFD.OfficeName
                                    newrow.Item("Department") = ETFD.DepartmentName
                                    newrow.Item("Employee") = ETFD.Employee
                                    newrow.Item("EmployeeCode") = ETFD.EmployeeCode
                                End If

                                For x As Integer = 1 To DatatableByMonth.Columns.Count - 1
                                    If DatatableByMonth.Columns(x).ColumnName = ETFD.Month Then
                                        If RadComboBoxDisplay.SelectedValue = 0 Then
                                            newrow.Item(x) = ETFD.ActualHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 1 Then
                                            newrow.Item(x) = ETFD.DirectPercent
                                        ElseIf RadComboBoxDisplay.SelectedValue = 2 Then
                                            newrow.Item(x) = ETFD.ClientHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 3 Then
                                            newrow.Item(x) = ETFD.ClientPercent
                                        Else
                                            newrow.Item(x) = ETFD.ActualHours
                                        End If
                                    End If
                                Next

                                Emp = ETFD.Employee
                            Next
                            DatatableByMonth.Rows.Add(newrow)
                        End If

                        RadGridEmployeeTimeForecastEmployeeutilizationByMonth.DataSource = DatatableByMonth
                        RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.DataKeyNames = New String() {"EmployeeCode"}

                        Try
                            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim gbf As Telerik.Web.UI.GridGroupByField

                            'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then
                            RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.GroupByExpressions.Clear()
                            'End If

                            If Me.CheckBoxOfficeGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Office"
                                gbf.FieldAlias = "Office"
                                gbf.HeaderText = ""
                                GrpExpr2.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Office"
                                gbf.HeaderText = ""
                                GrpExpr2.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                End With
                            End If
                            If Me.CheckBoxDepartmentGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Department"
                                gbf.FieldAlias = "Department"
                                gbf.HeaderText = ""
                                GrpExpr.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Department"
                                gbf.FieldAlias = "Department"
                                gbf.HeaderText = ""
                                GrpExpr.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                End With
                            End If
                            If Me.CheckBoxEmployeeGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "Employee"
                                gbf.HeaderText = ""
                                GrpExpr3.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "Employee"
                                gbf.HeaderText = ""
                                GrpExpr3.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                End With
                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf Me.RadComboBoxView.SelectedValue = 3 Then
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                        Me.RadGridEmployeeTimeForecastByClient.Visible = True
                        Me.RadGridEmployeeTimeForecastByClientFTE.Visible = False
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                        RadGridEmployeeTimeForecastByClient.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                             EmpCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked,
                                                                                                                                                             Me.RadComboBoxView.SelectedValue, Me.CheckboxForecastOnly.Checked, _Session.UserCode, Me.CheckboxSummary.Checked)

                        Try
                            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim gbf As Telerik.Web.UI.GridGroupByField

                            'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then
                            RadGridEmployeeTimeForecastByClient.MasterTableView.GroupByExpressions.Clear()
                            'End If

                            If Me.CheckBoxDepartmentGroup.Checked And Me.CheckboxSummary.Checked = False Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentName"
                                gbf.FieldAlias = "Department"
                                gbf.HeaderText = ""
                                GrpExpr2.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentCode"
                                gbf.FieldAlias = "DepartmentCode"
                                gbf.HeaderText = ""
                                GrpExpr2.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClient
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                End With
                            End If
                            If Me.CheckBoxEmployeeGroup.Checked And Me.CheckboxSummary.Checked = False Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "Employee"
                                gbf.HeaderText = ""
                                GrpExpr3.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "EmployeeCode"
                                gbf.HeaderText = ""
                                GrpExpr3.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClient
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                End With
                            End If
                            If Me.CheckBoxClientGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "ClientName"
                                gbf.FieldAlias = "ClientName"
                                gbf.HeaderText = ""
                                GrpExpr.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "ClientName"
                                gbf.FieldAlias = "ClientCode"
                                gbf.HeaderText = ""
                                GrpExpr.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClient
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                End With
                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf Me.RadComboBoxView.SelectedValue = 4 Then
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilization.Visible = False
                        Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Visible = False
                        Me.RadGridEmployeeTimeForecastByClient.Visible = False
                        Me.RadGridEmployeeTimeForecastByClientFTE.Visible = True
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.Visible = False

                        EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                             EmpCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, False, CheckboxIncludeSupervisorEmployees.Checked,
                                                                                                                                                           Me.RadComboBoxView.SelectedValue, Me.CheckboxForecastOnly.Checked, _Session.UserCode, Me.CheckboxSummary.Checked)

                        Me.RadGridEmployeeTimeForecastByClientFTE.MasterTableView.Columns.Clear()
                        Me.RadGridEmployeeTimeForecastByClientFTE.MasterTableView.DataSource = Nothing
                        RadGridEmployeeTimeForecastByClientFTE.MasterTableView.GroupByExpressions.Clear()

                        Dim DatatableByMonth As DataTable
                        DatatableByMonth = New DataTable("ByClient")

                        Dim dc As DataColumn
                        Dim newrow As DataRow

                        ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, RadComboBoxMonthTo.SelectedValue, RadComboBoxYearTo.SelectedValue)

                        If Me.CheckboxSummary.Checked = False Then
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

                                If RadComboBoxDisplay.SelectedValue = 0 Or RadComboBoxDisplay.SelectedValue = 1 Then
                                    'EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0)
                                ElseIf RadComboBoxDisplay.SelectedValue = 2 Or RadComboBoxDisplay.SelectedValue = 3 Then
                                    EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0).ToList
                                End If
                                If EmployeeTimeForecastDetail.Count > 0 Then
                                    For Each ETFD In EmployeeTimeForecastDetail
                                        newrow = DatatableByMonth.NewRow
                                        newrow.Item("ClientName") = ETFD.ClientName
                                        newrow.Item("DepartmentName") = ETFD.DepartmentName
                                        newrow.Item("Employee") = ETFD.Employee
                                        newrow.Item("EmployeeCode") = ETFD.EmployeeCode
                                        If RadComboBoxDisplay.SelectedValue = 0 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.ActualHoursCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.ActualHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 1 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.DirectPercentCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.DirectPercent
                                        ElseIf RadComboBoxDisplay.SelectedValue = 2 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.ClientHoursCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.ClientHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 3 Then
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

                                If RadComboBoxDisplay.SelectedValue = 0 Or RadComboBoxDisplay.SelectedValue = 1 Then
                                    'EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0)
                                ElseIf RadComboBoxDisplay.SelectedValue = 2 Or RadComboBoxDisplay.SelectedValue = 3 Then
                                    EmployeeTimeForecastDetail = EmployeeTimeForecastDetail.Where(Function(ETF) ETF.ClientHours > 0).ToList
                                End If
                                If EmployeeTimeForecastDetail.Count > 0 Then
                                    For Each ETFD In EmployeeTimeForecastDetail
                                        newrow = DatatableByMonth.NewRow
                                        newrow.Item("ClientName") = ETFD.ClientName
                                        If RadComboBoxDisplay.SelectedValue = 0 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.ActualHoursCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.ActualHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 1 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.DirectPercentCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.DirectPercent
                                        ElseIf RadComboBoxDisplay.SelectedValue = 2 Then
                                            newrow.Item("UtilizationCurrent") = ETFD.ClientHoursCurrent
                                            newrow.Item("UtilizationTotal") = ETFD.ClientHours
                                        ElseIf RadComboBoxDisplay.SelectedValue = 3 Then
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

                        Try
                            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
                            Dim gbf As Telerik.Web.UI.GridGroupByField

                            'If Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then

                            'End If


                            If Me.CheckBoxDepartmentGroup.Checked And Me.CheckboxSummary.Checked = False Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentName"
                                gbf.FieldAlias = "DepartmentName"
                                gbf.HeaderText = ""
                                GrpExpr2.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "DepartmentName"
                                gbf.FieldAlias = "DepartmentName"
                                gbf.HeaderText = ""
                                GrpExpr2.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClientFTE
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                                End With
                            End If
                            If Me.CheckBoxEmployeeGroup.Checked And Me.CheckboxSummary.Checked = False Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "Employee"
                                gbf.HeaderText = ""
                                GrpExpr3.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "Employee"
                                gbf.FieldAlias = "EmployeeCode"
                                gbf.HeaderText = ""
                                GrpExpr3.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClientFTE
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr3)
                                End With
                            End If
                            If Me.CheckBoxClientGroup.Checked Then
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "ClientName"
                                gbf.FieldAlias = "ClientName"
                                gbf.HeaderText = ""
                                GrpExpr.SelectFields.Add(gbf)
                                gbf = New Telerik.Web.UI.GridGroupByField
                                gbf.FieldName = "ClientName"
                                gbf.FieldAlias = "ClientCode"
                                gbf.HeaderText = ""
                                GrpExpr.GroupByFields.Add(gbf)
                                With Me.RadGridEmployeeTimeForecastByClientFTE
                                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                                End With
                            End If

                        Catch ex As Exception

                        End Try

                    End If

                    Session("MyETF_Month") = DropDownListMonth.SelectedValue
                    Session("MyETF_Year") = DropDownListPostPeriodYear.SelectedValue

                    Session("MyETF_MonthTo") = RadComboBoxMonthTo.SelectedValue
                    Session("MyETF_YearTo") = RadComboBoxYearTo.SelectedValue

                    Session("MyETF_AlternateEmployees") = Me.CheckboxAlternateEmployee.Checked
                    Session("MyETF_Department") = Me.RadComboBoxDepartment.SelectedValue
                    Session("MyETF_SupervisorEmployees") = CheckboxIncludeSupervisorEmployees.Checked
                    Session("MyETF_ForecastOnly") = CheckboxForecastOnly.Checked
                    Session("MyETF_JobDetail") = CheckboxIncludeJobDetail.Checked
                    Session("MyETF_View") = RadComboBoxView.SelectedValue
                    Session("MyETF_Display") = RadComboBoxDisplay.SelectedValue
                    Session("MyETF_Summary") = CheckboxSummary.Checked
                    Session("MyETF_DO") = "My"

                End Using

            End If

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub

    Private Sub LoadUserSettings()

        Try

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee") <> "" Then
                    Me.CheckboxAlternateEmployee.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees") <> "" Then
                    Me.CheckboxIncludeSupervisorEmployees.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly") <> "" Then
                    Me.CheckboxForecastOnly.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "OfficeGroup") <> "" Then
                    Me.CheckBoxOfficeGroup.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "OfficeGroup"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "DepartmentGroup") <> "" Then
                    Me.CheckBoxDepartmentGroup.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "DepartmentGroup"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "EmployeeGroup") <> "" Then
                    Me.CheckBoxEmployeeGroup.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "EmployeeGroup"), Boolean)
                End If
            Catch ex As Exception

            End Try

            Try
                If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ClientGroup") <> "" Then
                    Me.CheckBoxClientGroup.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ClientGroup"), Boolean)
                End If
            Catch ex As Exception

            End Try

            taskVar = otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "Department")
            If taskVar <> "" Then
                Me.RadComboBoxDepartment.SelectedValue = taskVar
            Else
                Me.RadComboBoxDepartment.SelectedValue = ""
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ETFDisplay")
            If taskVar <> "" Then
                Me.RadComboBoxDisplay.SelectedValue = taskVar
            Else
                Me.RadComboBoxDisplay.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub DesktopObject_MyEmployeeTimeForecast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'objects
            Dim EmployeeCode As String = ""

            If Not Me.IsPostBack Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    'DropDownListPostPeriodYear.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                    '                                         Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList

                    DropDownListPostPeriodYear.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                             Select New With {.[Year] = CInt(Entity.Year)}).Distinct.ToList.OrderByDescending(Function(Entity) Entity.Year).ToList
                    DropDownListPostPeriodYear.DataBind()

                    DropDownListMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                    DropDownListMonth.DataBind()

                    DropDownListPostPeriodYear.SelectedValue = Now.Year
                    DropDownListMonth.SelectedValue = Now.Month

                    'RadComboBoxYearTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                    '                                Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList

                    RadComboBoxYearTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                    Select New With {.[Year] = CInt(Entity.Year)}).Distinct.ToList.OrderByDescending(Function(Entity) Entity.Year).ToList
                    RadComboBoxYearTo.DataBind()

                    RadComboBoxMonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                    RadComboBoxMonthTo.DataBind()

                    RadComboBoxYearTo.SelectedValue = Now.Year
                    RadComboBoxMonthTo.SelectedValue = Now.Month

                    RadComboBoxDepartment.DataSource = (From DepartmentTeam In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).OrderBy(Function(Department) Department.Description)
                                                        Select DepartmentTeam.Code,
                                                               DepartmentTeam.Description).ToList
                    RadComboBoxDepartment.DataBind()

                    RadComboBoxDepartment.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                    EmployeeCode = Session("empcode").ToString

                    'If AdvantageFramework.Database.Procedures.EmployeeView.LoadBySupervisorEmployeeCodewithOfficeLimits(DbContext, EmployeeCode, _Session).Where(Function(Employee) Employee.Code <> EmployeeCode).Count > 0 Then

                    '    ImageButtonShowSupervisorEmployees.Visible = True
                    '    LabelShowSupervisorEmployees.Visible = True

                    'Else

                    '    ImageButtonShowSupervisorEmployees.Visible = False
                    '    LabelShowSupervisorEmployees.Visible = False

                    'End If

                End Using

                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String

                taskVar = otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "View")
                If taskVar <> "" Then
                    Me.RadComboBoxView.SelectedValue = taskVar
                Else
                    Me.RadComboBoxView.SelectedValue = ""
                End If

                EnableandDisablecontrols()
                LoadUserSettings()

                'LoadMyEmployeeTimeForecast()


            End If

            'LoadMyEmployeeTimeForecast()

            If CheckboxIncludeJobDetail.Checked Then
                If CheckboxSummary.Checked Then
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = True
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = True
                    Me.RadGridEmployeeTimeForcastEmployeeSummary.RetainExpandStateOnRebind = True
                Else
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = True
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = True
                    Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.RetainExpandStateOnRebind = True
                End If
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = False
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = False
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.RetainExpandStateOnRebind = False
                Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = False
                Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = False
                Me.RadGridEmployeeTimeForcastEmployeeSummary.RetainExpandStateOnRebind = False
            End If


            'Me.ImageButtonExport.Attributes.Add("onclick", "window.open('dtp_MyEmployeeTimeForecast.aspx?From=myetf&export=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")

            'This has to be called on every load
            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastOfficeDetailJobComponents)
            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastEmployeeutilization)
            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridEmployeeTimeForecastByClient)

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListMonth.SelectedIndexChanged

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub
    Private Sub DropDownListPostPeriodYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPostPeriodYear.SelectedIndexChanged

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub
    Private Sub RadComboBoxYearTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxYearTo.SelectedIndexChanged

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub
    Private Sub RadComboBoxMonthTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMonthTo.SelectedIndexChanged

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub
    Private Sub ImageButtonRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonRefresh.Click

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

        'If RadComboBoxView.SelectedValue = 0 Then
        '    If Me.CheckboxSummary.Checked Then
        '        Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
        '    Else
        '        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
        '    End If
        'End If
        'If RadComboBoxView.SelectedValue = 1 Then
        '    Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        'End If
        'If RadComboBoxView.SelectedValue = 2 Then
        '    Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        'End If
        'If RadComboBoxView.SelectedValue = 3 Then
        '    Me.RadGridEmployeeTimeForecastByClient.Rebind()
        'End If
        'If RadComboBoxView.SelectedValue = 4 Then
        '    Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        'End If

    End Sub

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

            If DropDownListMonth.SelectedValue <> "" AndAlso IsNumeric(DropDownListMonth.SelectedValue) AndAlso
                    DropDownListPostPeriodYear.SelectedValue <> "" AndAlso IsNumeric(DropDownListPostPeriodYear.SelectedValue) Then

                GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing Then

                    If IsPostBack = True Then
                        For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                            If DetailGridColumn.DataField = "SalesClass" And filter = "NoFilterSalesClass" Then

                                DetailGridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter
                                DetailGridColumn.CurrentFilterValue = ""
                                e.DetailTableView.FilterExpression = ""

                            End If

                            If DetailGridColumn.DataField = "JobAndJobComponent" And filter = "NoFilterJobComp" Then

                                DetailGridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter
                                DetailGridColumn.CurrentFilterValue = ""
                                e.DetailTableView.FilterExpression = ""

                            End If

                        Next

                        filter = ""

                    End If

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

                            e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         EmployeeCode, Me.CheckboxAlternateEmployee.Checked, IsAlternateEmployee, 0, AlternateEmployee, RadComboBoxDepartment.SelectedValue, Me.CheckboxIncludeJobDetail.Checked, False, 0, Me.CheckboxForecastOnly.Checked, _Session.UserCode, False)

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

                                e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         EmployeeCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, Me.CheckboxIncludeJobDetail.Checked, False, 0, Me.CheckboxForecastOnly.Checked, _Session.UserCode, False)

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

    Private Sub CheckboxAlternateEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxAlternateEmployee.CheckedChanged

        ' LoadMyEmployeeTimeForecast()

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee", "", Me.CheckboxAlternateEmployee.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub

    Private Sub RadComboBoxDepartment_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDepartment.SelectedIndexChanged

        'LoadMyEmployeeTimeForecast()

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "Department", "", Me.RadComboBoxDepartment.SelectedValue)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub

    Private Sub CheckboxIncludeJobDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxIncludeJobDetail.CheckedChanged

        'LoadMyEmployeeTimeForecast()

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

        If CheckboxIncludeJobDetail.Checked Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = True
                Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = True
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = True
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = True
            End If
        Else
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = False
        End If


    End Sub

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.NeedDataSource
        If RadComboBoxView.SelectedValue = 0 And Me.CheckboxSummary.Checked = False Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilization_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilization.NeedDataSource
        If RadComboBoxView.SelectedValue = 1 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.NeedDataSource
        If RadComboBoxView.SelectedValue = 2 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClient_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastByClient.NeedDataSource
        If RadComboBoxView.SelectedValue = 3 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub
    Private Sub RadGridEmployeeTimeForecastByClientFTE_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastByClientFTE.NeedDataSource
        If RadComboBoxView.SelectedValue = 4 Then
            LoadMyEmployeeTimeForecast()
        End If
    End Sub

    Private Sub RadGridEmployeeTimeForcastEmployeeSummary_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForcastEmployeeSummary.NeedDataSource
        If RadComboBoxView.SelectedValue = 0 And Me.CheckboxSummary.Checked = True Then
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

            If DropDownListMonth.SelectedValue <> "" AndAlso IsNumeric(DropDownListMonth.SelectedValue) AndAlso
                    DropDownListPostPeriodYear.SelectedValue <> "" AndAlso IsNumeric(DropDownListPostPeriodYear.SelectedValue) Then

                GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing Then

                    If IsPostBack = True Then
                        For Each DetailGridColumn In e.DetailTableView.Columns.OfType(Of Telerik.Web.UI.GridBoundColumn).ToList

                            If DetailGridColumn.DataField = "SalesClass" And filter = "NoFilterSalesClass" Then

                                DetailGridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter
                                DetailGridColumn.CurrentFilterValue = ""
                                e.DetailTableView.FilterExpression = ""

                            End If

                            If DetailGridColumn.DataField = "JobAndJobComponent" And filter = "NoFilterJobComp" Then

                                DetailGridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter
                                DetailGridColumn.CurrentFilterValue = ""
                                e.DetailTableView.FilterExpression = ""

                            End If

                        Next

                        filter = ""

                    End If

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

                            e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         EmployeeCode, Me.CheckboxAlternateEmployee.Checked, IsAlternateEmployee, 0, AlternateEmployee, RadComboBoxDepartment.SelectedValue, Me.CheckboxIncludeJobDetail.Checked, False, 0, Me.CheckboxForecastOnly.Checked, _Session.UserCode, True)

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

                                e.DetailTableView.DataSource = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDO(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         EmployeeCode, Me.CheckboxAlternateEmployee.Checked, False, 0, "", RadComboBoxDepartment.SelectedValue, Me.CheckboxIncludeJobDetail.Checked, False, 0, Me.CheckboxForecastOnly.Checked, _Session.UserCode, True)

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

    Private _ZeroHoursColorCSS As String = "standard-white"
    Private _LessThanHoursColorCSS As String = "standard-green-100"
    Private _LessThanAndGreaterThanHoursColorCSS As String = "standard-yellow-100"
    Private _GreaterThanHoursColorCSS As String = "standard-red-100"
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.ItemDataBound
        Try
            Dim griddataitem As GridDataItem
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                griddataitem = e.Item

                Dim DirectPercent As Decimal = 0
                Dim emp As String '= griddataitem("EmployeeCode").Text
                emp = griddataitem.GetDataKeyValue("EmployeeCode")
                Dim employee As AdvantageFramework.Database.Views.Employee = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, emp)
                End Using

                If employee IsNot Nothing Then
                    DirectPercent = If(employee.DirectHours Is Nothing, 0, employee.DirectHours)
                End If

                For x As Integer = 3 To e.Item.Cells.Count - 1
                    If e.Item.Cells(x).Text = "" Or e.Item.Cells(x).Text = "&nbsp;" Then
                        e.Item.Cells(x).Text = "0.00"
                    Else
                        If Me.RadComboBoxDisplay.SelectedValue = 1 Or Me.RadComboBoxDisplay.SelectedValue = 3 Then
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
                        'ElseIf IsNumeric(e.Item.Cells(x).Text) Then
                        '    If CDec(e.Item.Cells(x).Text) > 0 Then
                        '        If RadComboBoxDisplay.SelectedValue = 1 Or RadComboBoxDisplay.SelectedValue = 3 Then
                        '            e.Item.Cells(x).Text = e.Item.Cells(x).Text & "%"
                        '        End If
                        '    End If
                    End If

                Next

            ElseIf e.Item.ItemType = GridItemType.GroupFooter Or e.Item.ItemType = GridItemType.Footer Then

                For x As Integer = 3 To e.Item.Cells.Count - 1

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
                'column.HeaderStyle.Font.Bold = True

                If column.UniqueName = "EmployeeCode" Then
                    column.Visible = False
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastEmployeeutilizationByMonth_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridEmployeeTimeForecastEmployeeutilizationByMonth.ColumnCreated
        Try
            Dim col As GridBoundColumn = e.Column

            If e.Column.UniqueName <> "Office" AndAlso e.Column.UniqueName <> "Department" AndAlso e.Column.UniqueName <> "Employee" AndAlso e.Column.UniqueName <> "EmployeeCode" Then
                col.AllowFiltering = False
                col.Aggregate = GridAggregateFunction.Sum
                If RadComboBoxDisplay.SelectedValue = 0 Or RadComboBoxDisplay.SelectedValue = 2 Then
                    col.DataFormatString = "{0:#,##0.00}"
                End If
                If RadComboBoxDisplay.SelectedValue = 1 Or RadComboBoxDisplay.SelectedValue = 3 Then
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
                If RadComboBoxDisplay.SelectedValue = 0 Or RadComboBoxDisplay.SelectedValue = 2 Then
                    col.DataFormatString = "{0:#,##0.00}"
                End If
                If RadComboBoxDisplay.SelectedValue = 1 Or RadComboBoxDisplay.SelectedValue = 3 Then
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
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                griddataitem = e.Item

                Dim DirectPercent As Decimal = 0
                Dim emp As String '= griddataitem("EmployeeCode").Text
                If Me.CheckboxSummary.Checked = False Then
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
                    End If

                    If e.Item.Cells(x).Text = "0.00%" Then
                        e.Item.Cells(x).Text = "0.00"
                    End If

                    If (Me.RadComboBoxDisplay.SelectedValue = 1 Or Me.RadComboBoxDisplay.SelectedValue = 3) And e.Item.Cells(x).Text.Contains("%") Then
                        If DirectPercent > 0 And IsNumeric(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                            If CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) = 0 Then
                                'e.Item.Cells(x).CssClass = _ZeroHoursColorCSS
                            ElseIf DirectPercent < CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                e.Item.Cells(x).CssClass = _GreaterThanHoursColorCSS
                            ElseIf DirectPercent >= CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                e.Item.Cells(x).CssClass = _LessThanHoursColorCSS
                            ElseIf DirectPercent = CDec(e.Item.Cells(x).Text.Substring(0, e.Item.Cells(x).Text.Length - 1)) Then
                                e.Item.Cells(x).CssClass = _ZeroHoursColorCSS
                            End If
                        End If
                    End If

                Next


            ElseIf e.Item.ItemType = GridItemType.footer Then

                Dim footeritem As GridFooterItem = e.Item
                If Me.CheckboxSummary.Checked = False Then
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
                If Me.CheckboxSummary.Checked = False Then
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
                'column.HeaderStyle.Font.Bold = True

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
            For Each column In RadGridEmployeeTimeForecastByClient.MasterTableView.Columns

                If Me.RadComboBoxView.SelectedValue = 3 And Me.CheckboxSummary.Checked = True Then
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

    Private Sub ImageButtonExport_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExport.Click
        Try
            Dim str As String = ""
            str = "ETF_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
            If RadComboBoxView.SelectedValue = 0 Then
                If Me.CheckboxSummary.Checked Then
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForcastEmployeeSummary, str)
                    If Me.CheckboxIncludeJobDetail.Checked Then
                        Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.HierarchyDefaultExpanded = True
                    End If
                    RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.Columns.FindByUniqueName("TemplateColumn").Visible = False
                    RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExportToExcel()
                Else
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents, str)
                    If Me.CheckboxIncludeJobDetail.Checked Then
                        Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.HierarchyDefaultExpanded = True
                    End If
                    RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.Columns.FindByUniqueName("TemplateColumn").Visible = False
                    RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExportToExcel()
                End If

            End If
            If RadComboBoxView.SelectedValue = 1 Then
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastEmployeeutilization, str)
                RadGridEmployeeTimeForecastEmployeeutilization.MasterTableView.Columns.FindByUniqueName("TemplateColumn").Visible = False
                RadGridEmployeeTimeForecastEmployeeutilization.MasterTableView.ExportToExcel()
            End If
            If RadComboBoxView.SelectedValue = 2 Then
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth, str)
                RadGridEmployeeTimeForecastEmployeeutilizationByMonth.MasterTableView.ExportToExcel()
            End If
            If RadComboBoxView.SelectedValue = 3 Then
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastByClient, str)
                RadGridEmployeeTimeForecastByClient.MasterTableView.Columns.FindByUniqueName("TemplateColumn").Visible = False
                RadGridEmployeeTimeForecastByClient.MasterTableView.ExportToExcel()
            End If
            If RadComboBoxView.SelectedValue = 4 Then
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridEmployeeTimeForecastByClientFTE, str)
                RadGridEmployeeTimeForecastByClientFTE.MasterTableView.ExportToExcel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonDashboard_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonDashboard.Click
        Try

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "DashboardETF.aspx"
            qs.Add("DO", "My")
            qs.Add("FromMonth", Me.DropDownListMonth.SelectedValue)
            qs.Add("FromYear", Me.DropDownListPostPeriodYear.SelectedValue)
            qs.Add("ToMonth", Me.RadComboBoxMonthTo.SelectedValue)
            qs.Add("ToYear", Me.RadComboBoxYearTo.SelectedValue)
            qs.Add("Dept", Me.RadComboBoxDepartment.SelectedValue)
            qs.Add("View", Me.RadComboBoxView.SelectedValue)

            Me.OpenWindow("Employee Time Dashboard", qs.ToString(True))

            'Me.OpenWindow("", "DashboardETF.aspx?DO=My&FromMonth=" & Me.DropDownListMonth.SelectedValue & "&FromYear=" & Me.DropDownListPostPeriodYear.SelectedValue & "&ToMonth=" & Me.RadComboBoxMonthTo.SelectedValue & "&ToYear=" & Me.RadComboBoxYearTo.SelectedValue & "&Dept=" & Me.RadComboBoxDepartment.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckboxIncludeSupervisorEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxIncludeSupervisorEmployees.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees", "", Me.CheckboxIncludeSupervisorEmployees.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Footer Then

                Dim footeritem As GridFooterItem = e.Item
                footeritem("GridBoundColumnForecastedHours").Text = footeritem("GridBoundColumnForecastedHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnActualHours").Text = footeritem("GridBoundColumnActualHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnForecastedAmount").Text = footeritem("GridBoundColumnForecastedAmount").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnActualAmount").Text = footeritem("GridBoundColumnActualAmount").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnVarianceHours").Text = footeritem("GridBoundColumnVarianceHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnVarianceAmount").Text = footeritem("GridBoundColumnVarianceAmount").Text.Replace("Sum :", "")

                footeritem("GridBoundColumnEmployee").Text = "Total:"

            ElseIf e.Item.ItemType = GridItemType.GroupFooter Then

                Dim footeritem As GridGroupFooterItem = e.Item
                footeritem("GridBoundColumnForecastedHours").Text = footeritem("GridBoundColumnForecastedHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnActualHours").Text = footeritem("GridBoundColumnActualHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnForecastedAmount").Text = footeritem("GridBoundColumnForecastedAmount").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnActualAmount").Text = footeritem("GridBoundColumnActualAmount").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnVarianceHours").Text = footeritem("GridBoundColumnVarianceHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnVarianceAmount").Text = footeritem("GridBoundColumnVarianceAmount").Text.Replace("Sum :", "")

                If Not footeritem Is Nothing Then
                    If Me.CheckBoxOfficeGroup.Checked And Me.CheckBoxDepartmentGroup.Checked And Me.CheckBoxEmployeeGroup.Checked Then
                        If footeritem.GroupIndex.Length >= 5 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Employee:"
                        End If
                        If footeritem.GroupIndex.Length >= 3 And footeritem.GroupIndex.Length <= 4 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Department:"
                        End If
                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Office:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked And Me.CheckBoxDepartmentGroup.Checked And Me.CheckBoxEmployeeGroup.Checked = False Then

                        If footeritem.GroupIndex.Length >= 3 And footeritem.GroupIndex.Length <= 4 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Department:"
                        End If
                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Office:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked Then

                        If footeritem.GroupIndex.Length >= 3 And footeritem.GroupIndex.Length <= 4 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Employee:"
                        End If
                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Office:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked And Me.CheckBoxEmployeeGroup.Checked Then

                        If footeritem.GroupIndex.Length >= 3 And footeritem.GroupIndex.Length <= 4 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Employee:"
                        End If
                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Department:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked Then

                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Employee:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked And Me.CheckBoxEmployeeGroup.Checked = False Then

                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Department:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then

                        If footeritem.GroupIndex.Length >= 1 And footeritem.GroupIndex.Length <= 2 Then
                            footeritem("GridBoundColumnEmployee").Text = "Total for Office:"
                        End If
                    ElseIf Me.CheckBoxOfficeGroup.Checked = False And Me.CheckBoxDepartmentGroup.Checked = False And Me.CheckBoxEmployeeGroup.Checked = False Then

                    End If

                End If

            ElseIf e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then



            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_PreRender(sender As Object, e As EventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.PreRender
        Try
            For Each column In RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.Columns

                If Me.RadComboBoxView.SelectedValue = 0 And Me.CheckboxSummary.Checked = True Then
                    If column.UniqueName = "GridBoundColumnClient" Then
                        column.Display = False
                    End If
                Else
                    If column.UniqueName = "GridBoundColumnClient" Then
                        column.Display = True
                    End If
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxOfficeGroup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOfficeGroup.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "OfficeGroup", "", Me.CheckBoxOfficeGroup.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub CheckBoxDepartmentGroup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDepartmentGroup.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "DepartmentGroup", "", Me.CheckBoxDepartmentGroup.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub CheckBoxEmployeeGroup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEmployeeGroup.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "EmployeeGroup", "", Me.CheckBoxEmployeeGroup.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub CheckBoxClientGroup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxClientGroup.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ClientGroup", "", Me.CheckBoxClientGroup.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub CheckboxForecastOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxForecastOnly.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly", "", Me.CheckboxForecastOnly.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.ItemCommand
        Try
            Dim str As String = e.CommandName
            Dim str2 As String = e.CommandArgument.ToString

            If e.CommandName = "Filter" Then

                Dim s As System.Web.UI.Pair = e.CommandArgument

                If s.First.ToString = "NoFilter" Then
                    If s.Second.ToString = "GridBoundColumnSalesClass" Then
                        filter = "NoFilterSalesClass"
                    End If
                End If
                If s.First.ToString = "NoFilter" Then
                    If s.Second.ToString = "GridBoundColumnJobAndJobComponent" Then
                        filter = "NoFilterJobComp"
                    End If
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadComboBoxView_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxView.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "View", "", Me.RadComboBoxView.SelectedValue)

            'DropDownListPostPeriodYear.SelectedValue = Now.Year
            'DropDownListMonth.SelectedValue = Now.Month

            'RadComboBoxYearTo.SelectedValue = Now.Year
            'RadComboBoxMonthTo.SelectedValue = Now.Month

            EnableandDisablecontrols()
            LoadUserSettings()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadComboBoxDisplay_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDisplay.SelectedIndexChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ETFDisplay", "", Me.RadComboBoxDisplay.SelectedValue)

        If Me.RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If Me.RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

    End Sub

    Private Sub CheckboxSummary_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxSummary.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "Summary", "", Me.CheckboxSummary.Checked)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If
    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee", "", Me.CheckboxAlternateEmployee.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "Department", "", Me.RadComboBoxDepartment.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees", "", Me.CheckboxIncludeSupervisorEmployees.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "OfficeGroup", "", Me.CheckBoxOfficeGroup.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "DepartmentGroup", "", Me.CheckBoxDepartmentGroup.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "EmployeeGroup", "", Me.CheckBoxEmployeeGroup.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ClientGroup", "", Me.CheckBoxClientGroup.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly", "", Me.CheckboxForecastOnly.Checked)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "View", "", Me.RadComboBoxView.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ETFDisplay", "", Me.RadComboBoxDisplay.SelectedValue)

        If RadComboBoxView.SelectedValue = 0 Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.Rebind()
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()
            End If
        End If
        If RadComboBoxView.SelectedValue = 1 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilization.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 2 Then
            Me.RadGridEmployeeTimeForecastEmployeeutilizationByMonth.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 3 Then
            Me.RadGridEmployeeTimeForecastByClient.Rebind()
        End If
        If RadComboBoxView.SelectedValue = 4 Then
            Me.RadGridEmployeeTimeForecastByClientFTE.Rebind()
        End If

        If CheckboxIncludeJobDetail.Checked Then
            If Me.CheckboxSummary.Checked Then
                Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = True
                Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = True
            Else
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = True
                Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = True
            End If
        Else
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.MasterTableView.ExpandCollapseColumn.Visible = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.EnableHierarchyExpandAll = False
            Me.RadGridEmployeeTimeForcastEmployeeSummary.MasterTableView.ExpandCollapseColumn.Visible = False
        End If

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_MyTime
                .UserCode = Session("UserCode")
                .Name = "Employee Time (My)"
                .Description = "Employee Time (My)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub




#End Region

#End Region

End Class
