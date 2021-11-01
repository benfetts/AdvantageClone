Namespace Maintenance.Accounting.Presentation

    Public Class CostRateForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode

        End Sub
        Private Function LoadGrid() As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim SelectionStartDate As Date = Nothing
            Dim SelectionEndDate As Date = Nothing
            Dim SelectedEmployeeCodes() As String = Nothing
            Dim AllCostRateETDs As Generic.List(Of Classes.CostRateETD) = Nothing
            Dim AllCostRateETIs As Generic.List(Of Classes.CostRateETI) = Nothing
            Dim VacationSickAndPersonalTimeCategoryList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
            Dim EmployeeCodes() As String = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim CalculateEmployee As Boolean = True
            Dim EmployeeCostRateETDs As Generic.List(Of Classes.CostRateETD) = Nothing
            Dim EmployeeCostRateETIs As Generic.List(Of Classes.CostRateETI) = Nothing
            Dim EmployeeCostRateUpdates As Generic.List(Of Classes.EmployeeCostRateUpdate) = Nothing
            Dim EmployeeCostRateUpdate As Classes.EmployeeCostRateUpdate = Nothing
            Dim EmployeeRateHistories As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory) = Nothing
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing
            Dim EmployeeStartDate As Date = Nothing
            Dim EmployeeEndDate As Date = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim AlternateCostRate As Nullable(Of Decimal) = 0
            Dim [Date] As Date = Nothing
            Dim EmployeeCode As String = Nothing

            Try

                SelectionStartDate = New Date(NumericInputLeftSection_StartYear.EditValue, ComboBoxLeftSection_StartMonth.GetSelectedValue, 1)

            Catch ex As Exception
                SelectionStartDate = Nothing
            End Try

            Try

                SelectionEndDate = New Date(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue, System.DateTime.DaysInMonth(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue))

            Catch ex As Exception
                SelectionEndDate = Nothing
            End Try

            Try

                If DataGridViewLeftSection_Employees.HasASelectedRow Then

                    SelectedEmployeeCodes = DataGridViewLeftSection_Employees.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToArray

                End If

            Catch ex As Exception
                SelectedEmployeeCodes = Nothing
            End Try

            If SelectedEmployeeCodes IsNot Nothing AndAlso SelectedEmployeeCodes.Count > 0 Then

                If IsNothing(SelectionStartDate) = False AndAlso IsNothing(SelectionEndDate) = False AndAlso SelectionStartDate < SelectionEndDate Then

                    If String.IsNullOrEmpty(_EmployeeCode) Then

                        EmployeeCode = ""

                    Else

                        EmployeeCode = _EmployeeCode

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            AllCostRateETDs = DbContext.Database.SqlQuery(Of Classes.CostRateETD)(String.Format("EXEC [dbo].[advsp_cost_rate_update_load_direct_time] '{0}', '{1}', '{2}'", SelectionStartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionEndDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EmployeeCode)).ToList

                        Catch ex As Exception
                            AllCostRateETDs = Nothing
                        End Try

                        Try

                            AllCostRateETIs = DbContext.Database.SqlQuery(Of Classes.CostRateETI)(String.Format("EXEC [dbo].[advsp_cost_rate_update_load_indirect_time] '{0}', '{1}', '{2}'", SelectionStartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionEndDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EmployeeCode)).ToList

                        Catch ex As Exception
                            AllCostRateETIs = Nothing
                        End Try

                        EmployeeCostRateUpdates = New Generic.List(Of Classes.EmployeeCostRateUpdate)

                        If AllCostRateETDs IsNot Nothing AndAlso AllCostRateETIs IsNot Nothing Then

                            Try

                                EmployeeCodes = AllCostRateETDs.Select(Function(Entity) Entity.EmployeeCode).Union(AllCostRateETIs.Select(Function(Entity) Entity.EmployeeCode)).Distinct.ToArray

                            Catch ex As Exception
                                EmployeeCodes = Nothing
                            End Try

                            Try

                                VacationSickAndPersonalTimeCategoryList = (From Entity In AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext)
                                                                           Where Entity.Type = 1 OrElse
                                                                                 Entity.Type = 2 OrElse
                                                                                 Entity.Type = 3
                                                                           Select Entity).ToList

                            Catch ex As Exception
                                VacationSickAndPersonalTimeCategoryList = Nothing
                            End Try

                            If EmployeeCodes IsNot Nothing Then

                                If String.IsNullOrEmpty(_EmployeeCode) = False Then

                                    Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("EmployeeRateHistories").Include("DepartmentTeam").Where(Function(Entity) Entity.Code = _EmployeeCode).ToList

                                Else

                                    Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("EmployeeRateHistories").Include("DepartmentTeam").Where(Function(Entity) SelectedEmployeeCodes.Contains(Entity.Code)).ToList

                                End If

                                For Each Employee In Employees

                                    CalculateEmployee = True
                                    EmployeeStartDate = Nothing
                                    EmployeeEndDate = Nothing
                                    EmployeeRateHistories = Nothing
                                    EmployeeCostRateETDs = Nothing
                                    EmployeeCostRateETIs = Nothing
                                    [Date] = Nothing

                                    If EmployeeCodes.Contains(Employee.Code) = False Then

                                        If Employee.StartDate.HasValue Then

                                            If Employee.StartDate.Value.Year > SelectionEndDate.Year OrElse
                                                   (Employee.StartDate.Value.Month > SelectionEndDate.Month AndAlso
                                                    Employee.StartDate.Value.Year >= SelectionEndDate.Year) Then

                                                CalculateEmployee = False

                                            End If

                                        End If

                                        If Employee.TerminationDate.HasValue Then

                                            If Employee.TerminationDate.Value.Year < SelectionEndDate.Year OrElse
                                                   (Employee.TerminationDate.Value.Year <= SelectionEndDate.Year AndAlso
                                                    Employee.TerminationDate.Value.Month < SelectionEndDate.Month) Then

                                                CalculateEmployee = False

                                            End If

                                        End If

                                    End If

                                    If CalculateEmployee Then

                                        EmployeeStartDate = SelectionStartDate
                                        EmployeeEndDate = SelectionEndDate

                                        If Employee.StartDate.HasValue Then

                                            If Employee.StartDate > EmployeeStartDate Then

                                                EmployeeStartDate = Employee.StartDate.Value

                                            End If

                                        End If

                                        If Employee.TerminationDate.HasValue Then

                                            If Employee.TerminationDate < EmployeeEndDate Then

                                                EmployeeEndDate = Employee.TerminationDate.Value

                                            End If

                                        End If

                                        EmployeeRateHistories = Employee.EmployeeRateHistories.Where(Function(Entity) Entity.StartDate >= SelectionStartDate OrElse (Entity.StartDate <= SelectionEndDate AndAlso Entity.EndDate >= SelectionStartDate)).ToList
                                        EmployeeCostRateETDs = AllCostRateETDs.Where(Function(Entity) Entity.EmployeeCode = Employee.Code).ToList
                                        EmployeeCostRateETIs = AllCostRateETIs.Where(Function(Entity) Entity.EmployeeCode = Employee.Code).ToList

                                        If EmployeeRateHistories.Count > 0 Then

                                            [Date] = EmployeeStartDate

                                            For Each EmployeeRateHistory In EmployeeRateHistories.OrderBy(Function(Entity) Entity.StartDate).ToList

                                                StartDate = Nothing
                                                EndDate = Nothing

                                                StartDate = EmployeeRateHistory.StartDate
                                                EndDate = EmployeeRateHistory.EndDate

                                                If EmployeeStartDate > StartDate Then

                                                    StartDate = EmployeeStartDate

                                                End If

                                                If EmployeeEndDate < EndDate Then

                                                    EndDate = EmployeeEndDate

                                                End If

                                                If StartDate > [Date] Then

                                                    For Each EmployeeCostRateUpdate In CalculateAlternateCostRateByMonth(Employee, Nothing, [Date], StartDate.AddDays(-1), EmployeeCostRateETDs, EmployeeCostRateETIs, VacationSickAndPersonalTimeCategoryList)

                                                        EmployeeCostRateUpdates.Add(EmployeeCostRateUpdate)

                                                    Next

                                                End If

                                                For Each EmployeeCostRateUpdate In CalculateAlternateCostRateByMonth(Employee, EmployeeRateHistory, StartDate, EndDate, EmployeeCostRateETDs, EmployeeCostRateETIs, VacationSickAndPersonalTimeCategoryList)

                                                    EmployeeCostRateUpdates.Add(EmployeeCostRateUpdate)

                                                Next

                                                [Date] = EndDate.AddDays(1)

                                            Next

                                            If [Date] < EmployeeEndDate Then

                                                For Each EmployeeCostRateUpdate In CalculateAlternateCostRateByMonth(Employee, Nothing, [Date], EmployeeEndDate, EmployeeCostRateETDs, EmployeeCostRateETIs, VacationSickAndPersonalTimeCategoryList)

                                                    EmployeeCostRateUpdates.Add(EmployeeCostRateUpdate)

                                                Next

                                            End If

                                        Else

                                            For Each EmployeeCostRateUpdate In CalculateAlternateCostRateByMonth(Employee, Nothing, EmployeeStartDate, EmployeeEndDate, EmployeeCostRateETDs, EmployeeCostRateETIs, VacationSickAndPersonalTimeCategoryList)

                                                EmployeeCostRateUpdates.Add(EmployeeCostRateUpdate)

                                            Next

                                        End If

                                    End If

                                Next

                            End If

                        End If

                        DataGridViewRightSection_Employees.DataSource = EmployeeCostRateUpdates

                        DataGridViewRightSection_Employees.CurrentView.ViewCaption = "Calculate Alternate Cost Rate from " & SelectionStartDate.ToShortDateString & " to " & SelectionEndDate.ToShortDateString

                        DataGridViewRightSection_Employees.CurrentView.BestFitColumns()

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid date range.")
                    Loaded = False

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one employee.")
                Loaded = False

            End If

            LoadGrid = Loaded

        End Function
        Private Function CalculateAlternateCostRateByMonth(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory,
                                                           ByVal SelectionStartDate As Date, ByVal SelectionEndDate As Date, ByVal AllCostRateETDs As Generic.List(Of Classes.CostRateETD),
                                                           ByVal AllCostRateETIs As Generic.List(Of Classes.CostRateETI),
                                                           ByVal VacationSickAndPersonalTimeCategoryList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory)) As Generic.List(Of Classes.EmployeeCostRateUpdate)

            'objects
            Dim EmployeeCostRateUpdates As Generic.List(Of Classes.EmployeeCostRateUpdate) = Nothing
            Dim AlternateCostRate As Decimal = 0
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim CostRateETDs As Generic.List(Of Classes.CostRateETD) = Nothing
            Dim CostRateETIs As Generic.List(Of Classes.CostRateETI) = Nothing
            Dim DirectTime As Decimal = 0
            Dim NonProductiveTime As Decimal = 0
            Dim HoursUsedForCalculation As Decimal = 0
            Dim DailySalary As Decimal = 0
            Dim MonthlySalary As Decimal = 0
            Dim ProRatedMonthlySalary As Decimal = 0
            Dim DaysEmployeedInMonth As Integer = 0

            EmployeeCostRateUpdates = New Generic.List(Of Classes.EmployeeCostRateUpdate)

            If SelectionStartDate <> Nothing AndAlso SelectionEndDate <> Nothing AndAlso Employee IsNot Nothing Then

                If EmployeeRateHistory IsNot Nothing Then

                    If EmployeeRateHistory.MonthlySalary.HasValue Then

                        MonthlySalary = EmployeeRateHistory.MonthlySalary

                    ElseIf EmployeeRateHistory.AnnualSalary.HasValue Then

                        Try

                            MonthlySalary = EmployeeRateHistory.AnnualSalary / 12

                        Catch ex As Exception
                            MonthlySalary = 0
                        End Try

                    Else

                        MonthlySalary = 0

                    End If

                Else

                    If Employee.MonthlySalary.HasValue Then

                        MonthlySalary = Employee.MonthlySalary

                    ElseIf Employee.AnnualSalary.HasValue Then

                        Try

                            MonthlySalary = Employee.AnnualSalary / 12

                        Catch ex As Exception
                            MonthlySalary = 0
                        End Try

                    Else

                        MonthlySalary = 0

                    End If

                End If

                For Month As Integer = 0 To Math.Abs(DateDiff(DateInterval.Month, SelectionStartDate, SelectionEndDate))

                    StartDate = Nothing
                    EndDate = Nothing
                    CostRateETDs = Nothing
                    CostRateETIs = Nothing
                    DirectTime = 0
                    NonProductiveTime = 0
                    HoursUsedForCalculation = 0
                    DailySalary = 0
                    ProRatedMonthlySalary = 0
                    DaysEmployeedInMonth = 0
                    AlternateCostRate = 0

                    StartDate = New Date(SelectionStartDate.AddMonths(Month).Year, SelectionStartDate.AddMonths(Month).Month, 1)
                    EndDate = New Date(SelectionStartDate.AddMonths(Month).Year, SelectionStartDate.AddMonths(Month).Month, System.DateTime.DaysInMonth(SelectionStartDate.AddMonths(Month).Year, SelectionStartDate.AddMonths(Month).Month))

                    If StartDate <> Nothing AndAlso EndDate <> Nothing Then

                        If EndDate > SelectionEndDate Then

                            EndDate = SelectionEndDate

                        End If

                        If StartDate < SelectionStartDate Then

                            StartDate = SelectionStartDate

                        End If

                        Try

                            CostRateETDs = (From Entity In AllCostRateETDs
                                            Where Entity.EmployeeCode = Employee.Code AndAlso
                                                  Entity.Date >= StartDate AndAlso
                                                  Entity.Date <= EndDate
                                            Select Entity).ToList

                        Catch ex As Exception
                            CostRateETDs = Nothing
                        End Try

                        Try

                            CostRateETIs = (From Entity In AllCostRateETIs
                                            Where Entity.EmployeeCode = Employee.Code AndAlso
                                                  Entity.Date >= StartDate AndAlso
                                                  Entity.Date <= EndDate
                                            Select Entity).ToList

                        Catch ex As Exception
                            CostRateETIs = Nothing
                        End Try

                        If CheckBoxLeftSection_DirectTime.Checked Then

                            If CostRateETDs IsNot Nothing Then

                                Try

                                    DirectTime = CostRateETDs.Select(Function(Entity) Entity.Hours).Sum

                                Catch ex As Exception
                                    DirectTime = 0
                                End Try

                            End If

                        End If

                        If CheckBoxLeftSection_AllNonProductiveTime.Checked Then

                            If CostRateETIs IsNot Nothing Then

                                Try

                                    NonProductiveTime = CostRateETIs.Select(Function(Entity) Entity.Hours).Sum

                                Catch ex As Exception
                                    NonProductiveTime = 0
                                End Try

                            End If

                        ElseIf CheckBoxLeftSection_NonProductiveTime.Checked Then

                            If CostRateETIs IsNot Nothing Then

                                Try

                                    NonProductiveTime = (From Entity In CostRateETIs
                                                         Where VacationSickAndPersonalTimeCategoryList.Where(Function(TimeCategory) TimeCategory.Code.ToUpper = Entity.Category.ToUpper).Any = False
                                                         Select Entity.Hours).Sum

                                Catch ex As Exception
                                    NonProductiveTime = 0
                                End Try

                            End If

                        End If

                        HoursUsedForCalculation = DirectTime + NonProductiveTime

                        Try

                            If StartDate.Day <> 1 Then

                                DaysEmployeedInMonth = (System.DateTime.DaysInMonth(StartDate.Year, StartDate.Month) - StartDate.Day) + 1 ' add 1 day for day employeed

                                DailySalary = MonthlySalary / System.DateTime.DaysInMonth(StartDate.Year, StartDate.Month)

                                ProRatedMonthlySalary = DailySalary * DaysEmployeedInMonth

                            ElseIf EndDate.Day <> System.DateTime.DaysInMonth(StartDate.Year, StartDate.Month) Then

                                DaysEmployeedInMonth = EndDate.Day

                                DailySalary = MonthlySalary / System.DateTime.DaysInMonth(StartDate.Year, StartDate.Month)

                                ProRatedMonthlySalary = DailySalary * DaysEmployeedInMonth

                            Else

                                ProRatedMonthlySalary = MonthlySalary

                            End If

                        Catch ex As Exception
                            ProRatedMonthlySalary = 0
                        End Try

                        Try

                            If HoursUsedForCalculation > 0 Then

                                AlternateCostRate = Math.Round(ProRatedMonthlySalary / Convert.ToDecimal(HoursUsedForCalculation), 2)

                            End If

                        Catch ex As Exception
                            AlternateCostRate = 0
                        End Try

                        If EmployeeRateHistory IsNot Nothing Then

                            EmployeeCostRateUpdates.Add(New Classes.EmployeeCostRateUpdate(Employee, EmployeeRateHistory, StartDate, EndDate, HoursUsedForCalculation, AlternateCostRate))

                        Else

                            EmployeeCostRateUpdates.Add(New Classes.EmployeeCostRateUpdate(Employee, StartDate, EndDate, HoursUsedForCalculation, AlternateCostRate))

                        End If

                    End If

                Next

            End If

            CalculateAlternateCostRateByMonth = EmployeeCostRateUpdates

        End Function
        Private Function UpdateAlternateCostRate(ByVal SelectionStartDate As Date, ByVal SelectionEndDate As Date) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim AllCostRateETDs As Generic.List(Of Classes.CostRateETD) = Nothing
            Dim AllCostRateETIs As Generic.List(Of Classes.CostRateETI) = Nothing
            Dim CostRateETDs As Generic.List(Of Classes.CostRateETD) = Nothing
            Dim CostRateETIs As Generic.List(Of Classes.CostRateETI) = Nothing
            Dim CostRateETD As Classes.CostRateETD = Nothing
            Dim CostRateETI As Classes.CostRateETI = Nothing
            Dim EmployeeCostRateUpdate As Classes.EmployeeCostRateUpdate = Nothing
            Dim EmployeeCostRateUpdates As Generic.List(Of Classes.EmployeeCostRateUpdate) = Nothing
            Dim EmployeeCodes() As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If IsNothing(SelectionStartDate) = False AndAlso IsNothing(SelectionEndDate) = False AndAlso SelectionStartDate < SelectionEndDate Then

                If String.IsNullOrEmpty(_EmployeeCode) Then

                    EmployeeCode = ""

                Else

                    EmployeeCode = _EmployeeCode

                End If

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            AllCostRateETDs = DbContext.Database.SqlQuery(Of Classes.CostRateETD)(String.Format("EXEC [dbo].[advsp_cost_rate_update_load_direct_time] '{0}', '{1}', '{2}'", SelectionStartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionEndDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EmployeeCode)).ToList

                        Catch ex As Exception
                            AllCostRateETDs = Nothing
                        End Try

                        Try

                            AllCostRateETIs = DbContext.Database.SqlQuery(Of Classes.CostRateETI)(String.Format("EXEC [dbo].[advsp_cost_rate_update_load_indirect_time] '{0}', '{1}', '{2}'", SelectionStartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionEndDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EmployeeCode)).ToList

                        Catch ex As Exception
                            AllCostRateETIs = Nothing
                        End Try

                        If AllCostRateETDs IsNot Nothing AndAlso AllCostRateETIs IsNot Nothing Then

                            DbTransaction = DbContext.Database.BeginTransaction

                            Updated = True

                            EmployeeCostRateUpdates = DataGridViewRightSection_Employees.GetAllRowsDataBoundItems.OfType(Of Classes.EmployeeCostRateUpdate)().ToList

                            For Each EmployeeCostRateUpdate In EmployeeCostRateUpdates

                                Try

                                    CostRateETDs = (From Entity In AllCostRateETDs
                                                    Where Entity.EmployeeCode = EmployeeCostRateUpdate.Code AndAlso
                                                          Entity.Date >= EmployeeCostRateUpdate.From AndAlso
                                                          Entity.Date <= EmployeeCostRateUpdate.To
                                                    Select Entity).ToList

                                Catch ex As Exception
                                    CostRateETDs = Nothing
                                End Try

                                Try

                                    CostRateETIs = (From Entity In AllCostRateETIs
                                                    Where Entity.EmployeeCode = EmployeeCostRateUpdate.Code AndAlso
                                                          Entity.Date >= EmployeeCostRateUpdate.From AndAlso
                                                          Entity.Date <= EmployeeCostRateUpdate.To
                                                    Select Entity).ToList

                                Catch ex As Exception
                                    CostRateETIs = Nothing
                                End Try

                                If CostRateETDs IsNot Nothing AndAlso CostRateETDs.Count > 0 Then

                                    If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Update(DbContext, CostRateETDs.Select(Function(Entity) Entity.EmployeeTimeID).Distinct.ToList, CheckBoxLeftSection_StandardAmount.Checked, EmployeeCostRateUpdate.CostRate.GetValueOrDefault(0), CheckBoxLeftSection_AlternateAmount.Checked, EmployeeCostRateUpdate.AlternateCostRate.GetValueOrDefault(0), CheckBoxLeftSection_DepartmentTeam.Checked, EmployeeCostRateUpdate.DepartmentTeamCode) = False Then

                                        Updated = False
                                        Exit For

                                    End If

                                End If

                                If CostRateETIs IsNot Nothing AndAlso CostRateETIs.Count > 0 Then

                                    If AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Update(DbContext, CostRateETIs.Select(Function(Entity) Entity.EmployeeTimeID).Distinct.ToList, CheckBoxLeftSection_StandardAmount.Checked, EmployeeCostRateUpdate.CostRate.GetValueOrDefault(0), CheckBoxLeftSection_AlternateAmount.Checked, EmployeeCostRateUpdate.AlternateCostRate.GetValueOrDefault(0), CheckBoxLeftSection_DepartmentTeam.Checked, EmployeeCostRateUpdate.DepartmentTeamCode) = False Then

                                        Updated = False
                                        Exit For

                                    End If

                                End If

                            Next

                            If Updated Then

                                EmployeeCodes = EmployeeCostRateUpdates.Select(Function(Entity) Entity.Code).Distinct.ToArray

                                If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                                    For Each EmpCode In EmployeeCodes

                                        Try

                                            EmployeeCostRateUpdate = EmployeeCostRateUpdates.Where(Function(Entity) Entity.Code = EmpCode).OrderByDescending(Function(Entity) Entity.From).FirstOrDefault

                                        Catch ex As Exception
                                            EmployeeCostRateUpdate = Nothing
                                        End Try

                                        If EmployeeCostRateUpdate IsNot Nothing Then

                                            Try

                                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET ALT_COST_RATE = {0}, ALT_DATE_FRM = '{1}', ALT_DATE_TO = '{2}' WHERE EMP_CODE = '{3}'", EmployeeCostRateUpdate.AlternateCostRate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionStartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), SelectionEndDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EmpCode))

                                            Catch ex As Exception
                                                Updated = False
                                            End Try

                                            If Updated = False Then

                                                Exit For

                                            End If

                                        End If

                                    Next

                                End If

                            End If

                            If Updated Then

                                DbTransaction.Commit()

                            Else

                                DbTransaction.Rollback()

                            End If

                        End If

                        DbContext.Database.Connection.Close()

                    End Using

                Catch ex As Exception
                    Updated = False
                End Try

            End If

            UpdateAlternateCostRate = Updated

        End Function
        Private Sub SetupGrid()

            'objects
            Dim SelectionStartDate As Date = Nothing
            Dim SelectionEndDate As Date = Nothing

            Try

                SelectionStartDate = New Date(NumericInputLeftSection_StartYear.EditValue, ComboBoxLeftSection_StartMonth.GetSelectedValue, 1)

            Catch ex As Exception
                SelectionStartDate = Nothing
            End Try

            Try

                SelectionEndDate = New Date(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue, System.DateTime.DaysInMonth(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue))

            Catch ex As Exception
                SelectionEndDate = Nothing
            End Try

            DataGridViewRightSection_Employees.DataSource = New Generic.List(Of Classes.EmployeeCostRateUpdate)
            DataGridViewRightSection_Employees.CurrentView.OptionsView.AllowCellMerge = True
            DataGridViewRightSection_Employees.AutoUpdateViewCaption = False

            For Each GridColumn In DataGridViewRightSection_Employees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                Select Case GridColumn.FieldName

                    Case Classes.EmployeeCostRateUpdate.Properties.Code.ToString, Classes.EmployeeCostRateUpdate.Properties.Name.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.StartDate.ToString, Classes.EmployeeCostRateUpdate.Properties.TerminationDate.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.CurrentDepartmentTeamName.ToString, Classes.EmployeeCostRateUpdate.Properties.CurrentDepartmentTeamCode.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.CurrentCostRate.ToString, Classes.EmployeeCostRateUpdate.Properties.CurrentAnnualSalary.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.CurrentMonthlySalary.ToString, Classes.EmployeeCostRateUpdate.Properties.LastDateFrom.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.LastDateTo.ToString, Classes.EmployeeCostRateUpdate.Properties.LastAlternateCostRate.ToString

                        GridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True

                    Case Else

                        GridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False

                End Select

            Next

            If IsNothing(SelectionStartDate) = False AndAlso IsNothing(SelectionEndDate) = False Then

                DataGridViewRightSection_Employees.CurrentView.ViewCaption = "Calculate Alternate Cost Rate from " & SelectionStartDate.ToShortDateString & " to " & SelectionEndDate.ToShortDateString

            Else

                DataGridViewRightSection_Employees.CurrentView.ViewCaption = "Calculate Alternate Cost Rate from " & New Date(Now.Year, Now.Month, 1) & " to " & New Date(Now.Year, Now.Month, System.DateTime.DaysInMonth(Now.Year, Now.Month))

            End If

            DataGridViewRightSection_Employees.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions(ByVal Enable As Boolean)

            ButtonItemActions_UpdateTimeRecords.Enabled = Enable

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal EmployeeCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim CostRateForm As AdvantageFramework.Maintenance.Accounting.Presentation.CostRateForm = Nothing

            CostRateForm = New AdvantageFramework.Maintenance.Accounting.Presentation.CostRateForm(EmployeeCode)

            ShowFormDialog = CostRateForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CostRateForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            CheckBoxLeftSection_DepartmentTeam.ByPassUserEntryChanged = True
            CheckBoxLeftSection_StandardAmount.ByPassUserEntryChanged = True
            CheckBoxLeftSection_AlternateAmount.ByPassUserEntryChanged = True
            CheckBoxLeftSection_DirectTime.ByPassUserEntryChanged = True
            CheckBoxLeftSection_NonProductiveTime.ByPassUserEntryChanged = True
            CheckBoxLeftSection_AllNonProductiveTime.ByPassUserEntryChanged = True
            ComboBoxLeftSection_StartMonth.ByPassUserEntryChanged = True
            ComboBoxLeftSection_EndMonth.ByPassUserEntryChanged = True
            NumericInputLeftSection_StartYear.ByPassUserEntryChanged = True
            NumericInputLeftSection_EndYear.ByPassUserEntryChanged = True
            DataGridViewRightSection_Employees.ByPassUserEntryChanged = True
            DataGridViewLeftSection_Employees.ByPassUserEntryChanged = True

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_UpdateTimeRecords.Image = AdvantageFramework.My.Resources.CalendarMonthRefresh
            ButtonItemActions_Calculate.Image = AdvantageFramework.My.Resources.CalculatorImage

            DataGridViewRightSection_Employees.OptionsPrint.AutoWidth = False
            DataGridViewLeftSection_Employees.MultiSelect = True
            DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = True

            ComboBoxLeftSection_StartMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxLeftSection_EndMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If String.IsNullOrEmpty(_EmployeeCode) = False Then

                        Try

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        If Employee IsNot Nothing Then

                            Me.Text &= " for " & Employee.ToString

                            Employees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                            Employees.Add(Employee)

                            DataGridViewLeftSection_Employees.DataSource = Employees

                        End If

                    Else

                        Try

                            Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                        Catch ex As Exception
                            Employees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                        End Try

                        Try

                            Employee = (From Entity In Employees
                                        Where Entity.AlternateDateFrom IsNot Nothing
                                        Select Entity).FirstOrDefault

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        DataGridViewLeftSection_Employees.DataSource = Employees

                    End If

                    DataGridViewLeftSection_Employees.SelectAll()

                    DataGridViewLeftSection_Employees.Enabled = String.IsNullOrEmpty(_EmployeeCode)

                    If Employee IsNot Nothing AndAlso Employee.AlternateDateTo.HasValue Then

                        ComboBoxLeftSection_StartMonth.SelectedValue = Convert.ToInt64(Employee.AlternateDateTo.Value.Month)
                        NumericInputLeftSection_StartYear.EditValue = Employee.AlternateDateTo.Value.Year

                        ComboBoxLeftSection_EndMonth.SelectedValue = Convert.ToInt64(System.DateTime.Today.Month)
                        NumericInputLeftSection_EndYear.Value = System.DateTime.Today.Year

                    Else

                        ComboBoxLeftSection_StartMonth.SelectedValue = Convert.ToInt64(System.DateTime.Today.Month)
                        NumericInputLeftSection_StartYear.Value = System.DateTime.Today.Year

                        ComboBoxLeftSection_EndMonth.SelectedValue = Convert.ToInt64(System.DateTime.Today.Month)
                        NumericInputLeftSection_EndYear.Value = System.DateTime.Today.Year

                    End If

                End Using

            End Using

            CheckBoxLeftSection_AlternateAmount.Checked = True
            CheckBoxLeftSection_DirectTime.Checked = True
            CheckBoxLeftSection_NonProductiveTime.Checked = True

            SetupGrid()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Calculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Calculate.Click

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                EnableOrDisableActions(LoadGrid())

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_UpdateTimeRecords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateTimeRecords.Click

            'objects
            Dim Updated As Boolean = False
            Dim SelectionStartDate As Date = Nothing
            Dim SelectionEndDate As Date = Nothing
            Dim SelectedEmployeeCodes() As String = Nothing

            Try

                SelectionStartDate = New Date(NumericInputLeftSection_StartYear.EditValue, ComboBoxLeftSection_StartMonth.GetSelectedValue, 1)

            Catch ex As Exception
                SelectionStartDate = Nothing
            End Try

            Try

                SelectionEndDate = New Date(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue, System.DateTime.DaysInMonth(NumericInputLeftSection_EndYear.EditValue, ComboBoxLeftSection_EndMonth.GetSelectedValue))

            Catch ex As Exception
                SelectionEndDate = Nothing
            End Try

            Try

                If DataGridViewLeftSection_Employees.HasASelectedRow Then

                    SelectedEmployeeCodes = DataGridViewLeftSection_Employees.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToArray

                End If

            Catch ex As Exception
                SelectedEmployeeCodes = Nothing
            End Try

            If SelectedEmployeeCodes IsNot Nothing AndAlso SelectedEmployeeCodes.Count > 0 Then

                If IsNothing(SelectionStartDate) = False AndAlso IsNothing(SelectionEndDate) = False AndAlso SelectionStartDate < SelectionEndDate Then

                    If AdvantageFramework.WinForm.MessageBox.Show("This update uses current settings and history records to update cost and department team data.  Are you sure you want to continue and update all rows in the database from " & SelectionStartDate.ToShortDateString & " to " & SelectionEndDate.ToShortDateString & "?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm("Saving...")

                        Try

                            Updated = UpdateAlternateCostRate(SelectionStartDate, SelectionEndDate)

                        Catch ex As Exception
                            Updated = False
                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Updated Then

                            AdvantageFramework.WinForm.MessageBox.Show("The Employee Detail/NP time records have been successfully modified.")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("There was a problem updating the Employee Detail/NP time records.")

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid dates.")
                    EnableOrDisableActions(False)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one employee.")
                EnableOrDisableActions(False)

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewRightSection_Employees.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Dialog", ""))

        End Sub
        Private Sub CheckBoxLeftSection_AllNonProductiveTime_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxLeftSection_AllNonProductiveTime.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions(False)

                If CheckBoxLeftSection_AllNonProductiveTime.Checked Then

                    CheckBoxLeftSection_NonProductiveTime.Checked = False

                End If

            End If

        End Sub
        Private Sub CheckBoxLeftSection_NonProductiveTime_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxLeftSection_NonProductiveTime.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions(False)

                If CheckBoxLeftSection_NonProductiveTime.Checked Then

                    CheckBoxLeftSection_AllNonProductiveTime.Checked = False

                End If

            End If

        End Sub
        Private Sub CheckBoxLeftSection_DirectTime_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxLeftSection_DirectTime.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions(False)

            End If

        End Sub
        Private Sub DataGridViewRightSection_Employees_CellMergeEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles DataGridViewRightSection_Employees.CellMergeEvent

            If e.Column IsNot Nothing Then

                Select Case e.Column.FieldName

                    Case Classes.EmployeeCostRateUpdate.Properties.Code.ToString, Classes.EmployeeCostRateUpdate.Properties.Name.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.StartDate.ToString, Classes.EmployeeCostRateUpdate.Properties.TerminationDate.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.CurrentDepartmentTeamCode.ToString, Classes.EmployeeCostRateUpdate.Properties.CurrentDepartmentTeamName.ToString,
                            Classes.EmployeeCostRateUpdate.Properties.CurrentCostRate.ToString

                        e.Handled = True

                        If DataGridViewRightSection_Employees.CurrentView.GetRowCellValue(e.RowHandle1, Classes.EmployeeCostRateUpdate.Properties.Code.ToString) = DataGridViewRightSection_Employees.CurrentView.GetRowCellValue(e.RowHandle2, Classes.EmployeeCostRateUpdate.Properties.Code.ToString) Then

                            e.Merge = True

                        Else

                            e.Merge = False

                        End If

                    Case Else

                        e.Handled = False

                End Select

            End If

        End Sub
        Private Sub ComboBoxLeftSection_StartMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxLeftSection_StartMonth.SelectedValueChanged

            EnableOrDisableActions(False)

        End Sub
        Private Sub ComboBoxLeftSection_EndMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxLeftSection_EndMonth.SelectedValueChanged

            EnableOrDisableActions(False)

        End Sub
        Private Sub NumericInputLeftSection_StartYear_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputLeftSection_StartYear.EditValueChanged

            EnableOrDisableActions(False)

        End Sub
        Private Sub NumericInputLeftSection_EndYear_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputLeftSection_EndYear.EditValueChanged

            EnableOrDisableActions(False)

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            EnableOrDisableActions(False)

        End Sub

#End Region

#End Region

    End Class

End Namespace