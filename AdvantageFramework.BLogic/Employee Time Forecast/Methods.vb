Namespace EmployeeTimeForecast

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum StaticEmployeeTimeForecastColumn
            EmployeeTimeForecastOfficeDetailJobComponentID
            EmployeeTimeForecastOfficeDetailIndirectCategoryID
            ParentOfficeCode
            OfficeCode
            OfficeName
            ClientName
            DivisionName
            ProductDescription
            JobAndJobComponentDescription
            RevenueAmount
            RevenueShareAmount
            WithRevenueShareAmount
            UtilizationAmount
            TotalHours
        End Enum

        Public Enum StaticEmployeeTimeForecastHeaderItem
            GrandTotals
            IndirectCategories
        End Enum

        Public Enum StaticEmployeeTimeForecastSubItem
            TotalAmountsAndDirectHours = -1
            DirectHoursGoal = -2
            TotalHours = -3
            HoursAvailable = -4
            'TotalCost = -5
            TotalRevenue = -6
            BillableRate = -7
            'CostRate = -8
        End Enum

        Public Enum StaticComparisonDashboardColumn
            ParentOfficeCode
            OfficeCode
            OfficeName
            ParentClientCode
            ClientCode
            ClientName
            UtilizationOrForecast
            LineTotals
        End Enum

        Public Enum StaticComparisonDashboardSubItem
            Total = -1
            RevenueShare = -2
            ForecastedRevenue = -3
            Variance = -4
        End Enum

        Public Enum StaticDesktopObjectColumn
            EmployeeCode
            ClientCode
            DivisionCode
            ProductCode
            Employee
            Office
            Client
            JobAndJobComponent
            SalesClass
            AccountExecutive
            ActualHours
            ForecastedHours
            VarianceHours
            ActualAmount
            ForecastedAmount
            VarianceAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  My Employee Time Forecast Desktop Object "

        Private Sub AddColumnsToEmployeeTimeForecastDesktopObjectDatatable(ByRef ETFDatatable As DataTable)

            With ETFDatatable.Columns

                .Add(StaticDesktopObjectColumn.EmployeeCode.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ClientCode.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.DivisionCode.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ProductCode.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.Employee.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.Office.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.Client.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.JobAndJobComponent.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.SalesClass.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.AccountExecutive.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ActualHours.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ForecastedHours.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.VarianceHours.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ActualAmount.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.ForecastedAmount.ToString(), GetType(String))
                .Add(StaticDesktopObjectColumn.VarianceAmount.ToString(), GetType(String))

            End With

        End Sub

        Public Function LoadEmployeeTimeForecastDO(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromYear As Integer, ByVal FromMonth As Integer, ByVal ToYear As Integer, ByVal ToMonth As Integer, ByVal EmployeeCode As String,
                                                   ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean, ByVal AlternateEmployeeID As Integer, ByVal AlternateEmployeeDescription As String, ByVal Department As String,
                                                   ByVal IncludeJobDetail As Boolean, ByVal IncludeSupervised As Boolean, ByVal ViewType As Integer, ByVal ForecastOnly As Boolean, ByVal UserID As String, ByVal Summary As Boolean)

            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing
            Dim FromPostPeriod As Integer
            Dim ToPostPeriod As Integer

            Try

                Dim SqlParameterStartPeriod As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEndPeriod As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterDept As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterIncludeAlternate As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterIncludeJobDetail As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlternate As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterSupervised As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterViewType As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterForecastOnly As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterSummary As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterStartPeriod = New System.Data.SqlClient.SqlParameter("@start_period", SqlDbType.Int)
                SqlParameterEndPeriod = New System.Data.SqlClient.SqlParameter("@end_period", SqlDbType.Int)
                SqlParameterDept = New System.Data.SqlClient.SqlParameter("@dept", SqlDbType.VarChar)
                SqlParameterIncludeAlternate = New System.Data.SqlClient.SqlParameter("@IncludeAlternate", SqlDbType.Bit)
                SqlParameterIncludeJobDetail = New System.Data.SqlClient.SqlParameter("@includeJobDetail", SqlDbType.Bit)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmployeeCode", SqlDbType.VarChar)
                SqlParameterAlternate = New System.Data.SqlClient.SqlParameter("@Alternate", SqlDbType.VarChar)
                SqlParameterSupervised = New System.Data.SqlClient.SqlParameter("@IncludeSupervised", SqlDbType.Bit)
                SqlParameterViewType = New System.Data.SqlClient.SqlParameter("@ViewType", SqlDbType.SmallInt)
                SqlParameterForecastOnly = New System.Data.SqlClient.SqlParameter("@ForecastOnly", SqlDbType.Bit)
                SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
                SqlParameterSummary = New System.Data.SqlClient.SqlParameter("@Summary", SqlDbType.Bit)

                If FromYear <> 0 AndAlso FromMonth <> 0 AndAlso ToYear <> 0 AndAlso ToMonth <> 0 Then

                    If FromMonth >= 1 And FromMonth <= 9 Then
                        FromPostPeriod = FromYear.ToString & "0" & FromMonth.ToString
                    Else
                        FromPostPeriod = FromYear.ToString & FromMonth.ToString
                    End If

                    If ToMonth >= 1 And ToMonth <= 9 Then
                        ToPostPeriod = ToYear.ToString & "0" & ToMonth.ToString
                    Else
                        ToPostPeriod = ToYear.ToString & ToMonth.ToString
                    End If

                End If

                SqlParameterStartPeriod.Value = FromPostPeriod
                SqlParameterEndPeriod.Value = ToPostPeriod
                SqlParameterDept.Value = Department
                SqlParameterIncludeAlternate.Value = IncludeAlternateEmployees
                SqlParameterIncludeJobDetail.Value = IncludeJobDetail
                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterAlternate.Value = AlternateEmployeeDescription
                SqlParameterSupervised.Value = IncludeSupervised
                SqlParameterViewType.Value = ViewType
                SqlParameterForecastOnly.Value = ForecastOnly
                SqlParameterUserID.Value = UserID
                SqlParameterSummary.Value = Summary


                EmployeeTimeForecastDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) _
                                                                                       ("EXEC [dbo].[advsp_employee_time_forecast_do] @start_period, @end_period, @dept, @IncludeAlternate, @IncludeJobDetail, @EmployeeCode, @Alternate, @IncludeSupervised, @ViewType, @ForecastOnly, @UserID, @Summary",
                                                                                        SqlParameterStartPeriod, SqlParameterEndPeriod, SqlParameterDept, SqlParameterIncludeAlternate,
                                                                                        SqlParameterIncludeJobDetail, SqlParameterEmployeeCode, SqlParameterAlternate, SqlParameterSupervised,
                                                                                        SqlParameterViewType, SqlParameterForecastOnly, SqlParameterUserID, SqlParameterSummary).ToList

            Catch ex As Exception

            End Try

            LoadEmployeeTimeForecastDO = EmployeeTimeForecastDetail

        End Function
        Public Function LoadEmployeeTimeForecastDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromYear As Integer, ByVal FromMonth As Integer, ByVal ToYear As Integer, ByVal ToMonth As Integer, ByVal EmployeeCode As String,
                                                   ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean, ByVal AlternateEmployeeID As Integer, ByVal AlternateEmployeeDescription As String, ByVal Department As String,
                                                   ByVal IncludeJobDetail As Boolean, ByVal IncludeSupervised As Boolean, ByVal ByMonth As Boolean, ByVal ViewType As Integer, ByVal UserID As String, ByVal ByClient As Boolean, ByVal ByType As Boolean, ByVal ForecastOnly As Boolean)

            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim FromPostPeriod As Integer
            Dim ToPostPeriod As Integer
            Dim FromStartDate As DateTime
            Dim ToStartDate As DateTime
            Dim StartDate As DateTime = Nothing

            Dim SqlParameterStartPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDept As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeAlternate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeJobDetail As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlternate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSupervised As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterByMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterViewType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterByClient As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterByType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterForecastOnly As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterStartPeriod = New System.Data.SqlClient.SqlParameter("@start_period", SqlDbType.Int)
                SqlParameterEndPeriod = New System.Data.SqlClient.SqlParameter("@end_period", SqlDbType.Int)
                SqlParameterDept = New System.Data.SqlClient.SqlParameter("@dept", SqlDbType.VarChar)
                SqlParameterIncludeAlternate = New System.Data.SqlClient.SqlParameter("@IncludeAlternate", SqlDbType.Bit)
                SqlParameterIncludeJobDetail = New System.Data.SqlClient.SqlParameter("@includeJobDetail", SqlDbType.Bit)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmployeeCode", SqlDbType.VarChar)
                SqlParameterAlternate = New System.Data.SqlClient.SqlParameter("@Alternate", SqlDbType.VarChar)
                SqlParameterSupervised = New System.Data.SqlClient.SqlParameter("@IncludeSupervised", SqlDbType.Bit)
                SqlParameterByMonth = New System.Data.SqlClient.SqlParameter("@ByMonth", SqlDbType.Bit)
                SqlParameterViewType = New System.Data.SqlClient.SqlParameter("@ViewType", SqlDbType.Int)
                SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
                SqlParameterByClient = New System.Data.SqlClient.SqlParameter("@ByClient", SqlDbType.Bit)
                SqlParameterByType = New System.Data.SqlClient.SqlParameter("@ByType", SqlDbType.Bit)
                SqlParameterForecastOnly = New System.Data.SqlClient.SqlParameter("@ForecastOnly", SqlDbType.Bit)

                If FromYear <> 0 AndAlso FromMonth <> 0 AndAlso ToYear <> 0 AndAlso ToMonth <> 0 Then

                    If FromMonth >= 1 And FromMonth <= 9 Then
                        FromPostPeriod = FromYear.ToString & "0" & FromMonth.ToString
                    Else
                        FromPostPeriod = FromYear.ToString & FromMonth.ToString
                    End If

                    If ToMonth >= 1 And ToMonth <= 9 Then
                        ToPostPeriod = ToYear.ToString & "0" & ToMonth.ToString
                    Else
                        ToPostPeriod = ToYear.ToString & ToMonth.ToString
                    End If

                    FromStartDate = CDate(FromMonth.ToString & "/1/" & FromYear.ToString)
                    ToStartDate = CDate(ToMonth.ToString & "/1/" & ToYear.ToString)

                    If ByMonth = True And DateDiff(DateInterval.Month, FromStartDate, ToStartDate) > 2 Then
                        StartDate = ToStartDate.AddMonths(-2)
                        If StartDate.Month >= 1 And StartDate.Month <= 9 Then
                            FromPostPeriod = StartDate.Year.ToString & "0" & StartDate.Month.ToString
                        Else
                            FromPostPeriod = StartDate.Year.ToString & StartDate.Month.ToString
                        End If
                    End If
                End If

                SqlParameterStartPeriod.Value = FromPostPeriod
                SqlParameterEndPeriod.Value = ToPostPeriod
                SqlParameterDept.Value = Department
                SqlParameterIncludeAlternate.Value = IncludeAlternateEmployees
                SqlParameterIncludeJobDetail.Value = IncludeJobDetail
                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterAlternate.Value = AlternateEmployeeDescription
                SqlParameterSupervised.Value = IncludeSupervised
                SqlParameterByMonth.Value = ByMonth
                SqlParameterViewType.Value = ViewType
                SqlParameterUserID.Value = UserID
                SqlParameterByClient.Value = ByClient
                SqlParameterByType.Value = ByType
                SqlParameterForecastOnly.Value = ForecastOnly


                EmployeeTimeForecastDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) _
                                                                                       ("EXEC [dbo].[advsp_employee_time_forecast_dashboard] @start_period, @end_period, @dept, @IncludeAlternate, @IncludeJobDetail, @EmployeeCode, @Alternate, @IncludeSupervised, @ByMonth, @ViewType, @UserID, @ByClient, @ByType, @ForecastOnly",
                                                                                        SqlParameterStartPeriod, SqlParameterEndPeriod, SqlParameterDept, SqlParameterIncludeAlternate,
                                                                                        SqlParameterIncludeJobDetail, SqlParameterEmployeeCode, SqlParameterAlternate, SqlParameterSupervised, SqlParameterByMonth, SqlParameterViewType, SqlParameterUserID, SqlParameterByClient, SqlParameterByType, SqlParameterForecastOnly).ToList

            Catch ex As Exception
                EmployeeTimeForecastDetail = Nothing
            End Try

            LoadEmployeeTimeForecastDashboard = EmployeeTimeForecastDetail

        End Function

        Public Function BuildAllEmployeeTimeForecastDesktopObjectDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromYear As Integer, ByVal FromMonth As Integer, ByVal ToYear As Integer, ByVal ToMonth As Integer, ByVal EmployeeCode As String, ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean, ByVal AlternateEmployeeID As Integer, ByVal AlternateEmployeeDescription As String) As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing
            Dim JobAmountsFilteredListAll As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing

            If FromYear <> 0 AndAlso FromMonth <> 0 AndAlso ToYear <> 0 AndAlso ToMonth <> 0 Then

                If DbContext IsNot Nothing Then

                    FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, FromMonth, FromYear)
                    ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, ToMonth, ToYear)

                    If IsAlternateEmployee = True AndAlso AlternateEmployeeDescription <> "" Then
                        AlternateEmployee = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeDescription(DbContext, AlternateEmployeeDescription)
                    ElseIf EmployeeCode <> "" Then
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)
                    End If

                    If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing Then

                        EmployeeTimeForecastOfficeDetailsList = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCodeRange(DbContext, FromPostPeriod.Code, ToPostPeriod.Code).Where(Function(OfficeDetail) OfficeDetail.IsApproved).ToList

                        If EmployeeTimeForecastOfficeDetailsList IsNot Nothing Then

                            'DataTable = New System.Data.DataTable

                            EmployeeTimeForecastDetail = New Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail)

                            'AddColumnsToEmployeeTimeForecastDesktopObjectDatatable(DataTable)

                            JobAmountsList = AdvantageFramework.Database.Procedures.JobAmountComplexType.Load(DbContext, False, True, False, False, False, False, False, FromPostPeriod.StartDate, ToPostPeriod.EndDate, True).ToList

                            For Each JobComp In (From EmployeeTimeForecastOfficeDetailJobComponent In EmployeeTimeForecastOfficeDetailsList.SelectMany(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponents)
                                                 Select [JobCompt] = EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.ToString(True, False)
                                                 Distinct)

                                Try

                                    JobNumber = CInt(Split(JobComp, "-")(0))

                                Catch ex As Exception
                                    JobNumber = 0
                                End Try

                                Try

                                    JobComponentNumber = CShort(Split(JobComp, "-")(1))

                                Catch ex As Exception
                                    JobComponentNumber = 0
                                End Try

                                Try

                                    JobComponent = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Include("Job").Include("Job.Client").Include("Job.Office")
                                                    Where Entity.JobNumber = JobNumber AndAlso
                                                          Entity.Number = JobComponentNumber
                                                    Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    JobComponent = Nothing
                                End Try

                                If JobComponent IsNot Nothing Then

                                    JobAmountsFilteredListAll = Nothing

                                    If IsAlternateEmployee = True Then

                                        'JobAmountsFilteredList = JobAmountsList.Where(Function(JobAmount) JobAmount.JobAmountCode = Employee.Code AndAlso
                                        '                                                             JobAmount.JobNumber = JobNumber AndAlso
                                        '                                                             JobAmount.JobComponentNumber = JobComponentNumber AndAlso
                                        '                                                             CType(JobAmount.JobAmountDate, Date).Month = FromMonth AndAlso
                                        '                                                             CType(JobAmount.JobAmountDate, Date).Year = ToYear AndAlso
                                        '                                                             ((JobAmount.IsNonBillable = 1 AndAlso JobAmount.FeeTime = 1) OrElse
                                        '                                                               JobAmount.IsNonBillable <> 1)).ToList()

                                        BuildAllAlternateEmployeeTimeForecastDesktopObjectDataTableRow(DbContext, FromPostPeriod, ToPostPeriod, AlternateEmployee, JobComponent.Job, JobComponent,
                                                                                             JobComponent.Job.Client, JobComponent.Job.Office, EmployeeTimeForecastOfficeDetailsList,
                                                                                             JobAmountsFilteredListAll, IncludeAlternateEmployees, IsAlternateEmployee, DataTable, EmployeeTimeForecastDetail)

                                    Else

                                        JobAmountsFilteredListAll = JobAmountsList.Where(Function(JobAmount) JobAmount.JobNumber = JobNumber AndAlso
                                                                                                     JobAmount.JobComponentNumber = JobComponentNumber AndAlso
                                                                                                     ((JobAmount.IsNonBillable = 1 AndAlso JobAmount.FeeTime = 1) OrElse
                                                                                                       JobAmount.IsNonBillable <> 1)).ToList()

                                        BuildAllEmployeeTimeForecastDesktopObjectDataTableRow(DbContext, FromPostPeriod, ToPostPeriod, Employee, JobComponent.Job, JobComponent,
                                                                                             JobComponent.Job.Client, JobComponent.Job.Office, EmployeeTimeForecastOfficeDetailsList,
                                                                                             JobAmountsFilteredListAll, IncludeAlternateEmployees, IsAlternateEmployee, AlternateEmployee, DataTable, EmployeeTimeForecastDetail)

                                    End If



                                End If

                            Next

                        End If

                    End If

                End If

            End If

            'BuildMyEmployeeTimeForecastDesktopObjectDataTable = MyEmployeeTimeForecastDesktopObjectDataTableWithManagmentLevelRestrictions(DbContext, DataTable, EmployeeCode)
            'BuildMyEmployeeTimeForecastDesktopObjectDataTable = DataTable
            BuildAllEmployeeTimeForecastDesktopObjectDataTable = EmployeeTimeForecastDetail

        End Function

        Public Function BuildMyEmployeeTimeForecastDesktopObjectDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromYear As Integer, ByVal FromMonth As Integer, ByVal ToYear As Integer, ByVal ToMonth As Integer, ByVal EmployeeCode As String, ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean, ByVal AlternateEmployeeID As Integer, ByVal AlternateEmployeeDescription As String) As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing
            Dim JobAmountsFilteredList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail) = Nothing

            If FromYear <> 0 AndAlso FromMonth <> 0 AndAlso ToYear <> 0 AndAlso ToMonth <> 0 Then

                If DbContext IsNot Nothing Then

                    FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, FromMonth, FromYear)
                    ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, ToMonth, ToYear)

                    If IsAlternateEmployee = True Then
                        AlternateEmployee = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeDescription(DbContext, AlternateEmployeeDescription)
                    Else
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)
                    End If

                    If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing AndAlso (Employee IsNot Nothing Or AlternateEmployee IsNot Nothing) Then

                        EmployeeTimeForecastOfficeDetailsList = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCodeRange(DbContext, FromPostPeriod.Code, ToPostPeriod.Code).Where(Function(OfficeDetail) OfficeDetail.IsApproved).ToList

                        If EmployeeTimeForecastOfficeDetailsList IsNot Nothing Then

                            DataTable = New System.Data.DataTable

                            EmployeeTimeForecastDetail = New Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail)

                            AddColumnsToEmployeeTimeForecastDesktopObjectDatatable(DataTable)

                            JobAmountsList = AdvantageFramework.Database.Procedures.JobAmountComplexType.Load(DbContext, False, True, False, False, False, False, False, FromPostPeriod.StartDate, ToPostPeriod.EndDate, True).ToList

                            For Each JobComp In (From EmployeeTimeForecastOfficeDetailJobComponent In EmployeeTimeForecastOfficeDetailsList.SelectMany(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponents)
                                                 Select [JobCompt] = EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.ToString(True, False)
                                                 Distinct)

                                Try

                                    JobNumber = CInt(Split(JobComp, "-")(0))

                                Catch ex As Exception
                                    JobNumber = 0
                                End Try

                                Try

                                    JobComponentNumber = CShort(Split(JobComp, "-")(1))

                                Catch ex As Exception
                                    JobComponentNumber = 0
                                End Try

                                Try

                                    JobComponent = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Include("Job").Include("Job.Client").Include("Job.Office")
                                                    Where Entity.JobNumber = JobNumber AndAlso
                                                          Entity.Number = JobComponentNumber
                                                    Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    JobComponent = Nothing
                                End Try

                                If JobComponent IsNot Nothing Then

                                    JobAmountsFilteredList = Nothing

                                    If IsAlternateEmployee = True Then

                                        'JobAmountsFilteredList = JobAmountsList.Where(Function(JobAmount) JobAmount.JobAmountCode = Employee.Code AndAlso
                                        '                                                             JobAmount.JobNumber = JobNumber AndAlso
                                        '                                                             JobAmount.JobComponentNumber = JobComponentNumber AndAlso
                                        '                                                             CType(JobAmount.JobAmountDate, Date).Month = FromMonth AndAlso
                                        '                                                             CType(JobAmount.JobAmountDate, Date).Year = ToYear AndAlso
                                        '                                                             ((JobAmount.IsNonBillable = 1 AndAlso JobAmount.FeeTime = 1) OrElse
                                        '                                                               JobAmount.IsNonBillable <> 1)).ToList()

                                        BuildMyAlternateEmployeeTimeForecastDesktopObjectDataTableRow(DbContext, FromPostPeriod, ToPostPeriod, AlternateEmployee, JobComponent.Job, JobComponent,
                                                                                             JobComponent.Job.Client, JobComponent.Job.Office, EmployeeTimeForecastOfficeDetailsList,
                                                                                             JobAmountsFilteredList, IncludeAlternateEmployees, IsAlternateEmployee, DataTable, EmployeeTimeForecastDetail)

                                    Else

                                        JobAmountsFilteredList = JobAmountsList.Where(Function(JobAmount) JobAmount.JobAmountCode = Employee.Code AndAlso
                                                                                                     JobAmount.JobNumber = JobNumber AndAlso
                                                                                                     JobAmount.JobComponentNumber = JobComponentNumber AndAlso
                                                                                                     ((JobAmount.IsNonBillable = 1 AndAlso JobAmount.FeeTime = 1) OrElse
                                                                                                       JobAmount.IsNonBillable <> 1)).ToList()

                                        BuildMyEmployeeTimeForecastDesktopObjectDataTableRow(DbContext, FromPostPeriod, ToPostPeriod, Employee, JobComponent.Job, JobComponent,
                                                                                             JobComponent.Job.Client, JobComponent.Job.Office, EmployeeTimeForecastOfficeDetailsList,
                                                                                             JobAmountsFilteredList, IncludeAlternateEmployees, IsAlternateEmployee, AlternateEmployee, DataTable, EmployeeTimeForecastDetail)

                                    End If



                                End If

                            Next

                        End If

                    End If

                End If

            End If

            'BuildMyEmployeeTimeForecastDesktopObjectDataTable = MyEmployeeTimeForecastDesktopObjectDataTableWithManagmentLevelRestrictions(DbContext, DataTable, EmployeeCode)
            'BuildMyEmployeeTimeForecastDesktopObjectDataTable = DataTable
            BuildMyEmployeeTimeForecastDesktopObjectDataTable = EmployeeTimeForecastDetail

        End Function

        Public Sub BuildMyEmployeeTimeForecastDesktopObjectDataTableRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                               ByVal FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                                               ByVal Job As AdvantageFramework.Database.Entities.Job,
                                                                               ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                               ByVal Client As AdvantageFramework.Database.Entities.Client,
                                                                               ByVal Office As AdvantageFramework.Database.Entities.Office,
                                                                               ByVal EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail),
                                                                               ByVal JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount), ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean,
                                                                               ByVal AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee,
                                                                               ByRef DataTable As System.Data.DataTable, ByRef EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim EmployeeTimeForecast As AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail = Nothing
            Dim ForcastedHours As Decimal = 0
            Dim ForecastedAmount As Decimal = 0
            Dim AccountExecutiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If DbContext IsNot Nothing Then

                If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing AndAlso Employee IsNot Nothing AndAlso Job IsNot Nothing AndAlso
                        JobComponent IsNot Nothing AndAlso Client IsNot Nothing AndAlso
                        Office IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetailsList IsNot Nothing AndAlso
                        JobAmountsList IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailsList.Count > 0 OrElse JobAmountsList.Count > 0 Then

                        For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                            ForcastedHours = 0
                            ForecastedAmount = 0

                            Try

                                EmployeeTimeForecastOfficeDetailEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode = Employee.Code)

                            Catch ex As Exception
                                EmployeeTimeForecastOfficeDetailEmployee = Nothing
                            End Try

                            If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

                                Try

                                    EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                            OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                    For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                    OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID)
                                        ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                        ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                                    Next

                                    If ForcastedHours > 0 Then

                                        EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                        EmployeeTimeForecast.EmployeeCode = Employee.Code
                                        EmployeeTimeForecast.Employee = Employee.ToString

                                        EmployeeTimeForecast.ClientCode = Job.ClientCode
                                        EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                        EmployeeTimeForecast.ProductCode = Job.ProductCode

                                        EmployeeTimeForecast.OfficeName = Office.Name
                                        EmployeeTimeForecast.DepartmentName = Employee.DepartmentTeam.Description
                                        EmployeeTimeForecast.DepartmentCode = Employee.DepartmentTeam.Code
                                        EmployeeTimeForecast.ClientName = Client.Name
                                        EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                        EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                        AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                        If AccountExecutiveEmployee IsNot Nothing Then

                                            EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                        End If

                                        EmployeeTimeForecast.ActualHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                        EmployeeTimeForecast.ActualAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                        EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                        EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                        EmployeeTimeForecast.VarianceHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours) - ForcastedHours, 2)
                                        EmployeeTimeForecast.VarianceAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)) - ForecastedAmount, 2)
                                        EmployeeTimeForecast.IsAlternateEmployee = 0
                                        EmployeeTimeForecast.AlternateEmployeeID = 0


                                        EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                        'DataRow = DataTable.Rows.Add

                                        'DataRow(StaticDesktopObjectColumn.EmployeeCode.ToString) = Employee.Code

                                        'DataRow(StaticDesktopObjectColumn.ClientCode.ToString()) = Job.ClientCode
                                        'DataRow(StaticDesktopObjectColumn.DivisionCode.ToString()) = Job.DivisionCode
                                        'DataRow(StaticDesktopObjectColumn.ProductCode.ToString()) = Job.ProductCode

                                        'DataRow(StaticDesktopObjectColumn.Employee.ToString) = Employee.ToString
                                        'DataRow(StaticDesktopObjectColumn.Office.ToString) = Office.Name
                                        'DataRow(StaticDesktopObjectColumn.Client.ToString) = Client.Name
                                        'DataRow(StaticDesktopObjectColumn.JobAndJobComponent.ToString) = JobComponent.ToString(True, True)
                                        'DataRow(StaticDesktopObjectColumn.SalesClass.ToString) = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                        'AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                        'If AccountExecutiveEmployee IsNot Nothing Then

                                        '    DataRow(StaticDesktopObjectColumn.AccountExecutive.ToString) = AccountExecutiveEmployee.ToString

                                        'End If

                                        'DataRow(StaticDesktopObjectColumn.ActualHours.ToString) = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                        'DataRow(StaticDesktopObjectColumn.ActualAmount.ToString) = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                        'DataRow(StaticDesktopObjectColumn.ForecastedHours.ToString) = FormatNumber(ForcastedHours, 2)
                                        'DataRow(StaticDesktopObjectColumn.ForecastedAmount.ToString) = FormatCurrency(ForecastedAmount, 2)

                                        'DataRow(StaticDesktopObjectColumn.VarianceHours.ToString) = FormatNumber(CDec(DataRow(StaticDesktopObjectColumn.ActualHours.ToString)) - ForcastedHours, 2)
                                        'DataRow(StaticDesktopObjectColumn.VarianceAmount.ToString) = FormatCurrency(CDec(DataRow(StaticDesktopObjectColumn.ActualAmount.ToString)) - ForecastedAmount, 2)

                                    End If

                                End If

                            End If

                        Next

                        If IncludeAlternateEmployees Then

                            For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                                ForcastedHours = 0
                                ForecastedAmount = 0

                                For Each AlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                    Try

                                        EmployeeTimeForecastOfficeDetailAlternateEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.Description = AlternateEmployee.Description)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                                        Try

                                            EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                    OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                        Catch ex As Exception
                                            EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                        End Try

                                        If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                            For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                            OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)
                                                ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                                ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                            Next

                                            If ForcastedHours > 0 Then

                                                EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                                'EmployeeTimeForecast.EmployeeCode = Employee.Code
                                                EmployeeTimeForecast.Employee = AlternateEmployee.Description

                                                EmployeeTimeForecast.ClientCode = Job.ClientCode
                                                EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                                EmployeeTimeForecast.ProductCode = Job.ProductCode

                                                EmployeeTimeForecast.OfficeName = Office.Name

                                                EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, AlternateEmployee.EmployeeTitleID)

                                                If EmployeeTitle IsNot Nothing Then
                                                    DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, EmployeeTitle.DepartmentTeamCode)
                                                End If
                                                If DepartmentTeam IsNot Nothing Then
                                                    EmployeeTimeForecast.DepartmentName = DepartmentTeam.Description
                                                    EmployeeTimeForecast.DepartmentCode = DepartmentTeam.Code
                                                Else
                                                    EmployeeTimeForecast.DepartmentName = ""
                                                End If

                                                EmployeeTimeForecast.ClientName = Client.Name
                                                EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                                EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                                AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                                If AccountExecutiveEmployee IsNot Nothing Then

                                                    EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                                End If

                                                EmployeeTimeForecast.ActualHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                                EmployeeTimeForecast.ActualAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                                EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                                EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                                EmployeeTimeForecast.VarianceHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours) - ForcastedHours, 2)
                                                EmployeeTimeForecast.VarianceAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)) - ForecastedAmount, 2)
                                                EmployeeTimeForecast.IsAlternateEmployee = 1
                                                EmployeeTimeForecast.AlternateEmployeeID = AlternateEmployee.ID


                                                EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                                'DataRow = DataTable.Rows.Add

                                                'DataRow(StaticDesktopObjectColumn.EmployeeCode.ToString) = Employee.Code

                                                'DataRow(StaticDesktopObjectColumn.ClientCode.ToString()) = Job.ClientCode
                                                'DataRow(StaticDesktopObjectColumn.DivisionCode.ToString()) = Job.DivisionCode
                                                'DataRow(StaticDesktopObjectColumn.ProductCode.ToString()) = Job.ProductCode

                                                'DataRow(StaticDesktopObjectColumn.Employee.ToString) = Employee.ToString
                                                'DataRow(StaticDesktopObjectColumn.Office.ToString) = Office.Name
                                                'DataRow(StaticDesktopObjectColumn.Client.ToString) = Client.Name
                                                'DataRow(StaticDesktopObjectColumn.JobAndJobComponent.ToString) = JobComponent.ToString(True, True)
                                                'DataRow(StaticDesktopObjectColumn.SalesClass.ToString) = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                                'AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                                'If AccountExecutiveEmployee IsNot Nothing Then

                                                '    DataRow(StaticDesktopObjectColumn.AccountExecutive.ToString) = AccountExecutiveEmployee.ToString

                                                'End If

                                                'DataRow(StaticDesktopObjectColumn.ActualHours.ToString) = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                                'DataRow(StaticDesktopObjectColumn.ActualAmount.ToString) = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                                'DataRow(StaticDesktopObjectColumn.ForecastedHours.ToString) = FormatNumber(ForcastedHours, 2)
                                                'DataRow(StaticDesktopObjectColumn.ForecastedAmount.ToString) = FormatCurrency(ForecastedAmount, 2)

                                                'DataRow(StaticDesktopObjectColumn.VarianceHours.ToString) = FormatNumber(CDec(DataRow(StaticDesktopObjectColumn.ActualHours.ToString)) - ForcastedHours, 2)
                                                'DataRow(StaticDesktopObjectColumn.VarianceAmount.ToString) = FormatCurrency(CDec(DataRow(StaticDesktopObjectColumn.ActualAmount.ToString)) - ForecastedAmount, 2)

                                            End If

                                        End If

                                    End If

                                Next

                            Next

                        End If

                    End If

                End If

            End If

        End Sub

        Public Sub BuildMyAlternateEmployeeTimeForecastDesktopObjectDataTableRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                               ByVal FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee,
                                                                               ByVal Job As AdvantageFramework.Database.Entities.Job,
                                                                               ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                               ByVal Client As AdvantageFramework.Database.Entities.Client,
                                                                               ByVal Office As AdvantageFramework.Database.Entities.Office,
                                                                               ByVal EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail),
                                                                               ByVal JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount), ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean,
                                                                               ByRef DataTable As System.Data.DataTable, ByRef EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim EmployeeTimeForecast As AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail = Nothing
            Dim ForcastedHours As Decimal = 0
            Dim ForecastedAmount As Decimal = 0
            Dim AccountExecutiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If DbContext IsNot Nothing Then

                If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing AndAlso Job IsNot Nothing AndAlso
                        JobComponent IsNot Nothing AndAlso Client IsNot Nothing AndAlso
                        Office IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetailsList IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailsList.Count > 0 OrElse JobAmountsList.Count > 0 Then

                        For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                            ForcastedHours = 0
                            ForecastedAmount = 0

                            For Each AlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                Try

                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.Description = AlternateEmployee.Description)

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                                    Try

                                        EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                        For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                        OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)
                                            ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                            ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                        Next

                                        If ForcastedHours > 0 Then

                                            EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                            EmployeeTimeForecast.EmployeeCode = ""
                                            EmployeeTimeForecast.Employee = AlternateEmployee.Description

                                            EmployeeTimeForecast.ClientCode = Job.ClientCode
                                            EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                            EmployeeTimeForecast.ProductCode = Job.ProductCode

                                            EmployeeTimeForecast.OfficeName = Office.Name

                                            EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, AlternateEmployee.EmployeeTitleID)

                                            If EmployeeTitle IsNot Nothing Then
                                                DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, EmployeeTitle.DepartmentTeamCode)
                                            End If
                                            If DepartmentTeam IsNot Nothing Then
                                                EmployeeTimeForecast.DepartmentName = DepartmentTeam.Description
                                                EmployeeTimeForecast.DepartmentCode = DepartmentTeam.Code
                                            Else
                                                EmployeeTimeForecast.DepartmentName = ""
                                            End If
                                            EmployeeTimeForecast.ClientName = Client.Name
                                            EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                            EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                            AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                            If AccountExecutiveEmployee IsNot Nothing Then

                                                EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                            End If

                                            EmployeeTimeForecast.ActualHours = 0 'FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                            EmployeeTimeForecast.ActualAmount = 0 'FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                            EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                            EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                            EmployeeTimeForecast.VarianceHours = FormatNumber(0 - ForcastedHours, 2)
                                            EmployeeTimeForecast.VarianceAmount = FormatCurrency(0 - ForecastedAmount, 2)
                                            EmployeeTimeForecast.IsAlternateEmployee = 1
                                            EmployeeTimeForecast.AlternateEmployeeID = AlternateEmployee.ID

                                            EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                        End If

                                    End If

                                End If

                            Next

                        Next

                    End If

                End If

            End If

        End Sub

        Public Sub BuildAllEmployeeTimeForecastDesktopObjectDataTableRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                               ByVal FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                                               ByVal Job As AdvantageFramework.Database.Entities.Job,
                                                                               ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                               ByVal Client As AdvantageFramework.Database.Entities.Client,
                                                                               ByVal Office As AdvantageFramework.Database.Entities.Office,
                                                                               ByVal EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail),
                                                                               ByVal JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount), ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean,
                                                                               ByVal AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee,
                                                                               ByRef DataTable As System.Data.DataTable, ByRef EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim EmployeeTimeForecast As AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail = Nothing
            Dim ForcastedHours As Decimal = 0
            Dim ForecastedAmount As Decimal = 0
            Dim AccountExecutiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If DbContext IsNot Nothing Then

                If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing AndAlso Job IsNot Nothing AndAlso
                        JobComponent IsNot Nothing AndAlso Client IsNot Nothing AndAlso
                        Office IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetailsList IsNot Nothing AndAlso
                        JobAmountsList IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailsList.Count > 0 OrElse JobAmountsList.Count > 0 Then

                        For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                            ForcastedHours = 0
                            ForecastedAmount = 0

                            If Employee IsNot Nothing Then

                                Try

                                    EmployeeTimeForecastOfficeDetailEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode = Employee.Code)

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailEmployee = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

                                    Try

                                        EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                    OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                        For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                    OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID)

                                            ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                            ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                                        Next

                                        If ForcastedHours > 0 Then

                                            EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                            EmployeeTimeForecast.EmployeeCode = Employee.Code
                                            EmployeeTimeForecast.Employee = Employee.ToString

                                            EmployeeTimeForecast.ClientCode = Job.ClientCode
                                            EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                            EmployeeTimeForecast.ProductCode = Job.ProductCode

                                            EmployeeTimeForecast.OfficeName = Office.Name
                                            EmployeeTimeForecast.DepartmentName = Employee.DepartmentTeam.Description
                                            EmployeeTimeForecast.DepartmentCode = Employee.DepartmentTeam.Code
                                            EmployeeTimeForecast.ClientName = Client.Name
                                            EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                            EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                            AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                            If AccountExecutiveEmployee IsNot Nothing Then

                                                EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                            End If

                                            EmployeeTimeForecast.ActualHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                            EmployeeTimeForecast.ActualAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                            EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                            EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                            EmployeeTimeForecast.VarianceHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours) - ForcastedHours, 2)
                                            EmployeeTimeForecast.VarianceAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)) - ForecastedAmount, 2)
                                            EmployeeTimeForecast.IsAlternateEmployee = 0
                                            EmployeeTimeForecast.AlternateEmployeeID = 0


                                            EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                        End If

                                    End If

                                End If


                            Else

                                For Each Emp In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                                    Try

                                        EmployeeTimeForecastOfficeDetailEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode = Emp.EmployeeCode)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailEmployee = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

                                        Try

                                            EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                        OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                        Catch ex As Exception
                                            EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                        End Try

                                        If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                            For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                        OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID)

                                                ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                                ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                                            Next

                                            If ForcastedHours > 0 Then

                                                EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                                EmployeeTimeForecast.EmployeeCode = Emp.EmployeeCode
                                                EmployeeTimeForecast.Employee = Emp.Employee.ToString

                                                EmployeeTimeForecast.ClientCode = Job.ClientCode
                                                EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                                EmployeeTimeForecast.ProductCode = Job.ProductCode

                                                EmployeeTimeForecast.OfficeName = Office.Name
                                                EmployeeTimeForecast.DepartmentName = Emp.Employee.DepartmentTeam.Description
                                                EmployeeTimeForecast.DepartmentCode = Emp.Employee.DepartmentTeam.Code
                                                EmployeeTimeForecast.ClientName = Client.Name
                                                EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                                EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                                AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                                If AccountExecutiveEmployee IsNot Nothing Then

                                                    EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                                End If

                                                EmployeeTimeForecast.ActualHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                                EmployeeTimeForecast.ActualAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                                EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                                EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                                EmployeeTimeForecast.VarianceHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours) - ForcastedHours, 2)
                                                EmployeeTimeForecast.VarianceAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)) - ForecastedAmount, 2)
                                                EmployeeTimeForecast.IsAlternateEmployee = 0
                                                EmployeeTimeForecast.AlternateEmployeeID = 0


                                                EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                            End If

                                        End If

                                    End If

                                Next

                            End If

                        Next

                        If IncludeAlternateEmployees Then

                            For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                                ForcastedHours = 0
                                ForecastedAmount = 0

                                For Each AlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                    Try

                                        EmployeeTimeForecastOfficeDetailAlternateEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.Description = AlternateEmployee.Description)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                                        Try

                                            EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                    OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                        Catch ex As Exception
                                            EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                        End Try

                                        If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                            For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                            OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)
                                                ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                                ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                            Next

                                            If ForcastedHours > 0 Then

                                                EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                                'EmployeeTimeForecast.EmployeeCode = Employee.Code
                                                EmployeeTimeForecast.Employee = AlternateEmployee.Description

                                                EmployeeTimeForecast.ClientCode = Job.ClientCode
                                                EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                                EmployeeTimeForecast.ProductCode = Job.ProductCode

                                                EmployeeTimeForecast.OfficeName = Office.Name

                                                EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, AlternateEmployee.EmployeeTitleID)

                                                If EmployeeTitle IsNot Nothing Then
                                                    DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, EmployeeTitle.DepartmentTeamCode)
                                                End If
                                                If DepartmentTeam IsNot Nothing Then
                                                    EmployeeTimeForecast.DepartmentName = DepartmentTeam.Description
                                                    EmployeeTimeForecast.DepartmentCode = DepartmentTeam.Code
                                                Else
                                                    EmployeeTimeForecast.DepartmentName = ""
                                                End If

                                                EmployeeTimeForecast.ClientName = Client.Name
                                                EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                                EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                                AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                                If AccountExecutiveEmployee IsNot Nothing Then

                                                    EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                                End If

                                                EmployeeTimeForecast.ActualHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                                EmployeeTimeForecast.ActualAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                                EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                                EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                                EmployeeTimeForecast.VarianceHours = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours) - ForcastedHours, 2)
                                                EmployeeTimeForecast.VarianceAmount = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)) - ForecastedAmount, 2)
                                                EmployeeTimeForecast.IsAlternateEmployee = 1
                                                EmployeeTimeForecast.AlternateEmployeeID = AlternateEmployee.ID


                                                EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                                'DataRow = DataTable.Rows.Add

                                                'DataRow(StaticDesktopObjectColumn.EmployeeCode.ToString) = Employee.Code

                                                'DataRow(StaticDesktopObjectColumn.ClientCode.ToString()) = Job.ClientCode
                                                'DataRow(StaticDesktopObjectColumn.DivisionCode.ToString()) = Job.DivisionCode
                                                'DataRow(StaticDesktopObjectColumn.ProductCode.ToString()) = Job.ProductCode

                                                'DataRow(StaticDesktopObjectColumn.Employee.ToString) = Employee.ToString
                                                'DataRow(StaticDesktopObjectColumn.Office.ToString) = Office.Name
                                                'DataRow(StaticDesktopObjectColumn.Client.ToString) = Client.Name
                                                'DataRow(StaticDesktopObjectColumn.JobAndJobComponent.ToString) = JobComponent.ToString(True, True)
                                                'DataRow(StaticDesktopObjectColumn.SalesClass.ToString) = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                                'AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                                'If AccountExecutiveEmployee IsNot Nothing Then

                                                '    DataRow(StaticDesktopObjectColumn.AccountExecutive.ToString) = AccountExecutiveEmployee.ToString

                                                'End If

                                                'DataRow(StaticDesktopObjectColumn.ActualHours.ToString) = FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                                'DataRow(StaticDesktopObjectColumn.ActualAmount.ToString) = FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                                'DataRow(StaticDesktopObjectColumn.ForecastedHours.ToString) = FormatNumber(ForcastedHours, 2)
                                                'DataRow(StaticDesktopObjectColumn.ForecastedAmount.ToString) = FormatCurrency(ForecastedAmount, 2)

                                                'DataRow(StaticDesktopObjectColumn.VarianceHours.ToString) = FormatNumber(CDec(DataRow(StaticDesktopObjectColumn.ActualHours.ToString)) - ForcastedHours, 2)
                                                'DataRow(StaticDesktopObjectColumn.VarianceAmount.ToString) = FormatCurrency(CDec(DataRow(StaticDesktopObjectColumn.ActualAmount.ToString)) - ForecastedAmount, 2)

                                            End If

                                        End If

                                    End If

                                Next

                            Next

                        End If

                    End If

                End If

            End If

        End Sub

        Public Sub BuildAllAlternateEmployeeTimeForecastDesktopObjectDataTableRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                               ByVal FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                                                               ByVal AlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee,
                                                                               ByVal Job As AdvantageFramework.Database.Entities.Job,
                                                                               ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                               ByVal Client As AdvantageFramework.Database.Entities.Client,
                                                                               ByVal Office As AdvantageFramework.Database.Entities.Office,
                                                                               ByVal EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail),
                                                                               ByVal JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount), ByVal IncludeAlternateEmployees As Boolean, ByVal IsAlternateEmployee As Boolean,
                                                                               ByRef DataTable As System.Data.DataTable, ByRef EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim EmployeeTimeForecast As AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeForecastDetail = Nothing
            Dim ForcastedHours As Decimal = 0
            Dim ForecastedAmount As Decimal = 0
            Dim AccountExecutiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If DbContext IsNot Nothing Then

                If FromPostPeriod IsNot Nothing AndAlso ToPostPeriod IsNot Nothing AndAlso AlternateEmployee IsNot Nothing AndAlso Job IsNot Nothing AndAlso
                        JobComponent IsNot Nothing AndAlso Client IsNot Nothing AndAlso
                        Office IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetailsList IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailsList.Count > 0 OrElse JobAmountsList.Count > 0 Then

                        For Each EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetailsList

                            ForcastedHours = 0
                            ForecastedAmount = 0

                            For Each AlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                Try

                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.SingleOrDefault(Function(OfficeDetailEmployee) OfficeDetailEmployee.Description = AlternateEmployee.Description)

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                                    Try

                                        EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.JobNumber = JobComponent.JobNumber AndAlso
                                                                                                                                                                                                                OfficeDetailJobComponent.JobComponentNumber = JobComponent.Number)

                                    Catch ex As Exception
                                        EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                    End Try

                                    If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                        For Each OfficeDetailJobComponentEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.Where(Function(OfficeDetailJobComponentEmp) OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                        OfficeDetailJobComponentEmp.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)
                                            ForcastedHours += OfficeDetailJobComponentEmployee.Hours
                                            ForecastedAmount += (OfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                        Next

                                        If ForcastedHours > 0 Then

                                            EmployeeTimeForecast = New Classes.EmployeeTimeForecastDetail

                                            'EmployeeTimeForecast.EmployeeCode = Employee.Code
                                            EmployeeTimeForecast.Employee = AlternateEmployee.Description

                                            EmployeeTimeForecast.ClientCode = Job.ClientCode
                                            EmployeeTimeForecast.DivisionCode = Job.DivisionCode
                                            EmployeeTimeForecast.ProductCode = Job.ProductCode

                                            EmployeeTimeForecast.OfficeName = Office.Name

                                            EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, AlternateEmployee.EmployeeTitleID)

                                            If EmployeeTitle IsNot Nothing Then
                                                DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, EmployeeTitle.DepartmentTeamCode)
                                            End If
                                            If DepartmentTeam IsNot Nothing Then
                                                EmployeeTimeForecast.DepartmentName = DepartmentTeam.Description
                                                EmployeeTimeForecast.DepartmentCode = DepartmentTeam.Code
                                            Else
                                                EmployeeTimeForecast.DepartmentName = ""
                                            End If
                                            EmployeeTimeForecast.ClientName = Client.Name
                                            EmployeeTimeForecast.JobAndJobComponent = JobComponent.ToString(True, True)
                                            EmployeeTimeForecast.SalesClass = IIf(Job.SalesClass IsNot Nothing, Job.SalesClass.Description, "")

                                            AccountExecutiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, JobComponent.AccountExecutiveEmployeeCode)

                                            If AccountExecutiveEmployee IsNot Nothing Then

                                                EmployeeTimeForecast.AccountExecutive = AccountExecutiveEmployee.ToString

                                            End If

                                            EmployeeTimeForecast.ActualHours = 0 'FormatNumber(JobAmountsList.Sum(Function(JobAmount) JobAmount.Hours), 2)
                                            EmployeeTimeForecast.ActualAmount = 0 'FormatCurrency(JobAmountsList.Sum(Function(JobAmount) JobAmount.BillAmount.GetValueOrDefault(0)), 2)

                                            EmployeeTimeForecast.ForecastedHours = FormatNumber(ForcastedHours, 2)
                                            EmployeeTimeForecast.ForecastedAmount = FormatCurrency(ForecastedAmount, 2)

                                            EmployeeTimeForecast.VarianceHours = FormatNumber(0 - ForcastedHours, 2)
                                            EmployeeTimeForecast.VarianceAmount = FormatCurrency(0 - ForecastedAmount, 2)
                                            EmployeeTimeForecast.IsAlternateEmployee = 1
                                            EmployeeTimeForecast.AlternateEmployeeID = AlternateEmployee.ID

                                            EmployeeTimeForecastDetail.Add(EmployeeTimeForecast)

                                        End If

                                    End If

                                End If

                            Next

                        Next

                    End If

                End If

            End If

        End Sub

        Private Function MyEmployeeTimeForecastDesktopObjectDataTableWithManagmentLevelRestrictions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal ETFDatatable As DataTable, ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As DataTable
            Try

                Dim m As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(DbContext.Database.Connection.ConnectionString, DbContext.UserCode)

                Dim RestrictionsDatatable As New DataTable

                RestrictionsDatatable = m.LoadEmployeeDynamicRestrictionDatatable(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyEmployeeTimeForecast, EmpCode, ErrorMessage)

                If Not RestrictionsDatatable Is Nothing AndAlso RestrictionsDatatable.Rows.Count > 0 Then

                    Dim Query =
                                From ETF In ETFDatatable.AsEnumerable()
                                Join Restrictions In RestrictionsDatatable.AsEnumerable()
                                On
                                ETF.Field(Of String)("ClientCode") Equals Restrictions.Field(Of String)("CL_CODE") And
                                ETF.Field(Of String)("DivisionCode") Equals Restrictions.Field(Of String)("DIV_CODE") And
                                ETF.Field(Of String)("ProductCode") Equals Restrictions.Field(Of String)("PRD_CODE")
                                Select ETF

                    Dim dt As New DataTable

                    AdvantageFramework.EmployeeTimeForecast.AddColumnsToEmployeeTimeForecastDesktopObjectDatatable(dt)

                    For Each ETF In Query

                        Dim dr As DataRow

                        dr = dt.NewRow

                        With dr

                            .Item("EmployeeCode") = ETF.Item("EmployeeCode")
                            .Item("ClientCode") = ETF.Item("ClientCode")
                            .Item("DivisionCode") = ETF.Item("DivisionCode")
                            .Item("ProductCode") = ETF.Item("ProductCode")
                            .Item("Employee") = ETF.Item("Employee")
                            .Item("Office") = ETF.Item("Office")
                            .Item("Client") = ETF.Item("Client")
                            .Item("JobAndJobComponent") = ETF.Item("JobAndJobComponent")
                            .Item("SalesClass") = ETF.Item("SalesClass")
                            .Item("AccountExecutive") = ETF.Item("AccountExecutive")

                            .Item("ActualHours") = ETF.Item("ActualHours")
                            .Item("ForecastedHours") = ETF.Item("ForecastedHours")
                            .Item("VarianceHours") = ETF.Item("VarianceHours")
                            .Item("ActualAmount") = ETF.Item("ActualAmount")
                            .Item("ForecastedAmount") = ETF.Item("ForecastedAmount")
                            .Item("VarianceAmount") = ETF.Item("VarianceAmount")

                        End With

                        dt.Rows.Add(dr)

                    Next

                    ErrorMessage = ""
                    Return dt

                Else

                    ErrorMessage = ""
                    Return ETFDatatable

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return ETFDatatable

            End Try
        End Function

#End Region

#Region "  Comparison Dashboard "

        Public Function BuildEmployeeTimeForecastComparisonDashbaordDataTable(Session As AdvantageFramework.Security.Session,
                                                                              DbContext As AdvantageFramework.Database.DbContext,
                                                                              Year As Integer, Month As Integer,
                                                                              ShowUtilizationAmount As Boolean,
                                                                              ShowResultsForForecastedProjectsOnly As Boolean) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim UtilizationAmountDataRow As System.Data.DataRow = Nothing
            Dim ForecastAmountDataRow As System.Data.DataRow = Nothing
            Dim OfficeHeaderDataRow As System.Data.DataRow = Nothing
            Dim ClientHeaderDataRow As System.Data.DataRow = Nothing
            Dim GrandTotalsDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim PostPeriodsList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) = Nothing
            Dim SubEmployeeTimeForecastOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) = Nothing
            Dim SubSubEmployeeTimeForecastOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) = Nothing
            Dim EmployeeTimeTotalsByOfficeClientList As Generic.List(Of AdvantageFramework.Database.Views.EmployeeTimeTotalsByOfficeClient) = Nothing
            Dim SubEmployeeTimeTotalsByOfficeClientList As Generic.List(Of AdvantageFramework.Database.Views.EmployeeTimeTotalsByOfficeClient) = Nothing
            Dim SubSubEmployeeTimeTotalsByOfficeClientList As Generic.List(Of AdvantageFramework.Database.Views.EmployeeTimeTotalsByOfficeClient) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim AddOffice As Boolean = False
            Dim AddClient As Boolean = False
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim ClientsAddedToDataTable As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim AccessibleClients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing

            If Year <> 0 Then

                If DbContext IsNot Nothing Then

                    DataTable = New System.Data.DataTable
                    PostPeriodsList = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriodsByPostPeriodYear(DbContext, Year).ToList

                    DataTable.Columns.Add(StaticComparisonDashboardColumn.ParentOfficeCode.ToString)
                    DataTable.Columns.Add(StaticComparisonDashboardColumn.OfficeCode.ToString)

                    DataColumn = DataTable.Columns.Add(StaticComparisonDashboardColumn.OfficeName.ToString)

                    DataColumn.Caption = "Office"

                    DataTable.Columns.Add(StaticComparisonDashboardColumn.ParentClientCode.ToString)
                    DataTable.Columns.Add(StaticComparisonDashboardColumn.ClientCode.ToString)

                    DataColumn = DataTable.Columns.Add(StaticComparisonDashboardColumn.ClientName.ToString)

                    DataColumn.Caption = "Client"

                    DataColumn = DataTable.Columns.Add(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString)

                    DataColumn.Caption = "Utilization\Forecast"

                    For Each PostPeriod In PostPeriodsList

                        DataColumn = DataTable.Columns.Add(PostPeriod.Code)

                        DataColumn.Caption = PostPeriod.Description

                    Next

                    DataTable.Columns.Add(StaticComparisonDashboardColumn.LineTotals.ToString)

                    EmployeeTimeForecastOfficeDetailJobComponentsList = (From OfficeDetailJobComponent In DbContext.EmployeeTimeForecastOfficeDetailJobComponents
                                                                         Where OfficeDetailJobComponent.EmployeeTimeForecast.PostPeriod.Year = Year AndAlso
                                                                               OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetail.IsApproved
                                                                         Select OfficeDetailJobComponent).ToList

                    If Month <> 0 Then

                        StartDate = New Date(Year, 1, 1)

                        If Month = 13 Then

                            EndDate = New Date(Year, 12, 31) ' CDate("12/31/" & Year)

                        Else

                            'EndDate = CDate(Month & "/" & Date.DaysInMonth(Year, Month) & "/" & Year)
                            EndDate = New Date(Year, Month, Date.DaysInMonth(Year, Month))

                        End If

                        EmployeeTimeTotalsByOfficeClientList = (From EmployeeTimeTotalsByOfficeClient In AdvantageFramework.Database.Procedures.EmployeeTimeTotalsByOfficeClientView.Load(DbContext)
                                                                Where EmployeeTimeTotalsByOfficeClient.EmployeeTimeDate >= StartDate AndAlso
                                                                      EmployeeTimeTotalsByOfficeClient.EmployeeTimeDate <= EndDate
                                                                Select EmployeeTimeTotalsByOfficeClient
                                                                Order By EmployeeTimeTotalsByOfficeClient.OfficeCode,
                                                                         EmployeeTimeTotalsByOfficeClient.ClientCode).ToList

                    End If

                    ClientsAddedToDataTable = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AccessibleClients = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

                    End Using

                    For Each Office In AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Session).ToList

                        If ShowResultsForForecastedProjectsOnly Then

                            AddOffice = EmployeeTimeForecastOfficeDetailJobComponentsList.Any(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.Job.OfficeCode = Office.Code AndAlso
                                                                                                                                     OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetail.OfficeCode = Office.Code)

                        Else

                            AddOffice = EmployeeTimeForecastOfficeDetailJobComponentsList.Any(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.Job.OfficeCode = Office.Code AndAlso
                                                                                                                                     OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetail.OfficeCode = Office.Code) OrElse
                                                (EmployeeTimeTotalsByOfficeClientList IsNot Nothing AndAlso
                                                 EmployeeTimeTotalsByOfficeClientList.Any(Function(EmployeeTimeTotalsByOfficeClient) EmployeeTimeTotalsByOfficeClient.OfficeCode = Office.Code))

                        End If

                        If AddOffice Then

                            OfficeHeaderDataRow = DataTable.Rows.Add

                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = ""
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = Office.Code
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = Office.Name
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = ""
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                            For Each PostPeriod In PostPeriodsList

                                OfficeHeaderDataRow(PostPeriod.Code) = "0"

                            Next

                            For Each Client In AdvantageFramework.Database.Procedures.Job.LoadByOfficeCode(DbContext, Office.Code).Select(Function(Entity) Entity.Client).OrderBy(Function(JobClient) JobClient.Name).ToList

                                If AccessibleClients.Any(Function(Entity) Entity.Code = Client.Code) Then

                                    SubEmployeeTimeForecastOfficeDetailJobComponentsList = (From OfficeDetailJobComponent In EmployeeTimeForecastOfficeDetailJobComponentsList
                                                                                            Where OfficeDetailJobComponent.Job.OfficeCode = Office.Code AndAlso
                                                                                                  OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetail.OfficeCode = Office.Code AndAlso
                                                                                                  OfficeDetailJobComponent.Job.ClientCode = Client.Code
                                                                                            Select OfficeDetailJobComponent).ToList

                                    If Month <> 0 Then

                                        SubEmployeeTimeTotalsByOfficeClientList = (From EmployeeTimeTotalsByOfficeClient In EmployeeTimeTotalsByOfficeClientList
                                                                                   Where EmployeeTimeTotalsByOfficeClient.OfficeCode = Office.Code AndAlso
                                                                                         EmployeeTimeTotalsByOfficeClient.ClientCode = Client.Code
                                                                                   Select EmployeeTimeTotalsByOfficeClient).ToList

                                    End If

                                    If ShowResultsForForecastedProjectsOnly Then

                                        AddClient = (SubEmployeeTimeForecastOfficeDetailJobComponentsList.Count > 0)

                                    Else

                                        AddClient = (SubEmployeeTimeForecastOfficeDetailJobComponentsList.Count > 0) OrElse
                                                        (SubEmployeeTimeTotalsByOfficeClientList IsNot Nothing AndAlso
                                                         SubEmployeeTimeTotalsByOfficeClientList.Count > 0)

                                    End If

                                    If AddClient AndAlso ClientsAddedToDataTable.Any(Function(Entity) Entity.Code = Client.Code) = False Then

                                        ClientsAddedToDataTable.Add(Client)

                                        ClientHeaderDataRow = DataTable.Rows.Add

                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = Office.Code
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = Office.Code & Client.Code
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = ""
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = ""
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = Client.Code
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.ClientName.ToString) = Client.Name
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                                        UtilizationAmountDataRow = DataTable.Rows.Add

                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = Office.Code & Client.Code
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "Utilization" & Client.Code
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = ""
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = Client.Code
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = "Utilization"
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                                        ForecastAmountDataRow = DataTable.Rows.Add

                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = Office.Code & Client.Code
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "Forecast" & Client.Code
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = ""
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = Client.Code
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = "Forecast"
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                                        For Each PostPeriod In PostPeriodsList

                                            ClientHeaderDataRow(PostPeriod.Code) = "0"
                                            UtilizationAmountDataRow(PostPeriod.Code) = "0"
                                            ForecastAmountDataRow(PostPeriod.Code) = "0"

                                        Next

                                        For Each PostPeriod In PostPeriodsList

                                            SubSubEmployeeTimeForecastOfficeDetailJobComponentsList = (From OfficeDetailJobComponent In SubEmployeeTimeForecastOfficeDetailJobComponentsList
                                                                                                       Where OfficeDetailJobComponent.EmployeeTimeForecast.PostPeriodCode = PostPeriod.Code
                                                                                                       Select OfficeDetailJobComponent).ToList

                                            If Month <> 0 Then

                                                SubSubEmployeeTimeTotalsByOfficeClientList = (From EmployeeTimeTotalsByOfficeClient In SubEmployeeTimeTotalsByOfficeClientList
                                                                                              Where EmployeeTimeTotalsByOfficeClient.EmployeeTimeDate >= PostPeriod.StartDate AndAlso
                                                                                                    EmployeeTimeTotalsByOfficeClient.EmployeeTimeDate <= PostPeriod.EndDate
                                                                                              Select EmployeeTimeTotalsByOfficeClient).ToList

                                            End If

                                            If CInt(PostPeriod.Month) < Month Then

                                                UtilizationAmountDataRow(PostPeriod.Code) = CDec(UtilizationAmountDataRow(PostPeriod.Code)) + CDec(SubSubEmployeeTimeTotalsByOfficeClientList.Sum(Function(EmployeeTimeTotalsByOfficeClient) EmployeeTimeTotalsByOfficeClient.TotalAmount))

                                            Else

                                                For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In SubSubEmployeeTimeForecastOfficeDetailJobComponentsList.SelectMany(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentEmployees)

                                                    UtilizationAmountDataRow(PostPeriod.Code) = CDec(UtilizationAmountDataRow(PostPeriod.Code)) + CDec(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                                                Next

                                                For Each EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In SubSubEmployeeTimeForecastOfficeDetailJobComponentsList.SelectMany(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees)

                                                    UtilizationAmountDataRow(PostPeriod.Code) = CDec(UtilizationAmountDataRow(PostPeriod.Code)) + CDec(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours * EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                                Next

                                            End If

                                            If ShowUtilizationAmount AndAlso (Month = 0 OrElse CInt(PostPeriod.Month) < Month) Then

                                                For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In SubSubEmployeeTimeForecastOfficeDetailJobComponentsList.SelectMany(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentEmployees)

                                                    ForecastAmountDataRow(PostPeriod.Code) = CDec(ForecastAmountDataRow(PostPeriod.Code)) + CDec(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                                                Next

                                                For Each EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In SubSubEmployeeTimeForecastOfficeDetailJobComponentsList.SelectMany(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees)

                                                    ForecastAmountDataRow(PostPeriod.Code) = CDec(ForecastAmountDataRow(PostPeriod.Code)) + CDec(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours * EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                                                Next

                                            Else

                                                ForecastAmountDataRow(PostPeriod.Code) = CDec(ForecastAmountDataRow(PostPeriod.Code)) + SubSubEmployeeTimeForecastOfficeDetailJobComponentsList.Select(Function(OfficeDetailJobComponent) OfficeDetailJobComponent.RevenueAmount).Sum

                                            End If

                                            UtilizationAmountDataRow(PostPeriod.Code) = FormatCurrency(UtilizationAmountDataRow(PostPeriod.Code))
                                            ForecastAmountDataRow(PostPeriod.Code) = FormatCurrency(ForecastAmountDataRow(PostPeriod.Code))

                                            ClientHeaderDataRow(PostPeriod.Code) = FormatCurrency(CDec(UtilizationAmountDataRow(PostPeriod.Code)) - CDec(ForecastAmountDataRow(PostPeriod.Code)))
                                            OfficeHeaderDataRow(PostPeriod.Code) = FormatCurrency(CDec(OfficeHeaderDataRow(PostPeriod.Code)) + CDec(ClientHeaderDataRow(PostPeriod.Code)))

                                        Next

                                        OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                                        For Each PostPeriod In PostPeriodsList

                                            OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = CDec(OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(OfficeHeaderDataRow(PostPeriod.Code))
                                            ClientHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = CDec(ClientHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(ClientHeaderDataRow(PostPeriod.Code))
                                            UtilizationAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = CDec(UtilizationAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(UtilizationAmountDataRow(PostPeriod.Code))
                                            ForecastAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = CDec(ForecastAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(ForecastAmountDataRow(PostPeriod.Code))

                                        Next

                                        OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(OfficeHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString))
                                        ClientHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(ClientHeaderDataRow(StaticComparisonDashboardColumn.LineTotals.ToString))
                                        UtilizationAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(UtilizationAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString))
                                        ForecastAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(ForecastAmountDataRow(StaticComparisonDashboardColumn.LineTotals.ToString))

                                    End If

                                End If

                            Next

                        End If

                    Next

                    If DataTable.Rows.Count > 0 Then

                        GrandTotalsDataRow = DataTable.Rows.Add

                        GrandTotalsDataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "ETFCDGrandTotals"
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                        GrandTotalsDataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = ""

                        For Each PostPeriod In PostPeriodsList

                            GrandTotalsDataRow(PostPeriod.Code) = ""

                        Next

                        DataRow = DataTable.Rows.Add

                        DataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = "ETFCDGrandTotals"
                        DataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "ETFCDGrandTotals" & StaticComparisonDashboardSubItem.Total.ToString
                        DataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = StaticComparisonDashboardSubItem.Total.ToString
                        DataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = StaticComparisonDashboardSubItem.Total.ToString
                        DataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                        For Each PostPeriod In PostPeriodsList

                            DataRow(PostPeriod.Code) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(Row) Row(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = "Utilization")
                                                                       Select CDec(Row(PostPeriod.Code))).Sum)

                        Next

                        For Each PostPeriod In PostPeriodsList

                            DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(CDec(DataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(DataRow(PostPeriod.Code)))

                        Next

                        DataRow = DataTable.Rows.Add

                        DataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = "ETFCDGrandTotals"
                        DataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "ETFCDGrandTotals" & StaticComparisonDashboardSubItem.ForecastedRevenue.ToString
                        DataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticComparisonDashboardSubItem.ForecastedRevenue.ToString)
                        DataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = StaticComparisonDashboardSubItem.ForecastedRevenue.ToString
                        DataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                        For Each PostPeriod In PostPeriodsList

                            DataRow(PostPeriod.Code) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(Row) Row(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = "Forecast")
                                                                       Select CDec(Row(PostPeriod.Code))).Sum)

                        Next

                        For Each PostPeriod In PostPeriodsList

                            DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(CDec(DataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(DataRow(PostPeriod.Code)))

                        Next

                        DataRow = DataTable.Rows.Add

                        DataRow(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = "ETFCDGrandTotals"
                        DataRow(StaticComparisonDashboardColumn.OfficeCode.ToString) = "ETFCDGrandTotals" & StaticComparisonDashboardSubItem.Variance.ToString
                        DataRow(StaticComparisonDashboardColumn.OfficeName.ToString) = StaticComparisonDashboardSubItem.Variance.ToString
                        DataRow(StaticComparisonDashboardColumn.ParentClientCode.ToString) = StaticComparisonDashboardSubItem.Variance.ToString
                        DataRow(StaticComparisonDashboardColumn.ClientCode.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.ClientName.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.UtilizationOrForecast.ToString) = ""
                        DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = "0"

                        For Each PostPeriod In PostPeriodsList

                            DataRow(PostPeriod.Code) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(Row) Row(StaticComparisonDashboardColumn.ParentOfficeCode.ToString) = "" AndAlso
                                                                                                                                                   Row(StaticComparisonDashboardColumn.OfficeCode.ToString) <> "ETFCDGrandTotals")
                                                                       Select CDec(Row(PostPeriod.Code))).Sum)

                        Next

                        For Each PostPeriod In PostPeriodsList

                            DataRow(StaticComparisonDashboardColumn.LineTotals.ToString) = FormatCurrency(CDec(DataRow(StaticComparisonDashboardColumn.LineTotals.ToString)) + CDec(DataRow(PostPeriod.Code)))

                        Next

                    End If

                End If

            End If

            BuildEmployeeTimeForecastComparisonDashbaordDataTable = DataTable

        End Function

#End Region

#Region "  Settings "

        Public Function LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of AdvantageFramework.Database.Entities.Setting)

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing

            Try

                SettingsList = AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, 4, 0).ToList

            Catch ex As Exception
                SettingsList = Nothing
            Finally
                LoadSettings = SettingsList
            End Try

        End Function
        Public Function LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim UseJobComponentBudgetAmountForDefaultRevenue As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                UseJobComponentBudgetAmountForDefaultRevenue = LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(DataContext, SettingsList)

            Catch ex As Exception
                UseJobComponentBudgetAmountForDefaultRevenue = False
            Finally
                LoadUseJobComponentBudgetAmountForDefaultRevenueSetting = UseJobComponentBudgetAmountForDefaultRevenue
            End Try

        End Function
        Public Function LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim UseJobComponentBudgetAmountForDefaultRevenue As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_REVAMT_CALC.ToString AndAlso Setting.Value = 1).Any Then

                    UseJobComponentBudgetAmountForDefaultRevenue = True

                End If

            Catch ex As Exception
                UseJobComponentBudgetAmountForDefaultRevenue = False
            Finally
                LoadUseJobComponentBudgetAmountForDefaultRevenueSetting = UseJobComponentBudgetAmountForDefaultRevenue
            End Try

        End Function
        'Public Function LoadShowCostInformationSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

        '    'objects
        '    Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        '    Dim ShowCostInformation As Boolean = False

        '    Try

        '        SettingsList = LoadSettings(DataContext)

        '        ShowCostInformation = LoadShowCostInformationSetting(DataContext, SettingsList)

        '    Catch ex As Exception
        '        ShowCostInformation = False
        '    Finally
        '        LoadShowCostInformationSetting = ShowCostInformation
        '    End Try

        'End Function
        'Public Function LoadShowCostInformationSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

        '    'objects
        '    Dim ShowCostInformation As Boolean = False

        '    Try

        '        If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.EmployeeTimeForecast.SettingCodes.ETF_SHOW_COSTINFO.ToString AndAlso Setting.Value = 1).Any Then

        '            ShowCostInformation = True

        '        End If

        '    Catch ex As Exception
        '        ShowCostInformation = False
        '    Finally
        '        LoadShowCostInformationSetting = ShowCostInformation
        '    End Try

        'End Function
        Public Function LoadShowClientDivisionProductCodesOnlySetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim ShowClientDivisionProductCodesOnly As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                ShowClientDivisionProductCodesOnly = LoadShowClientDivisionProductCodesOnlySetting(DataContext, SettingsList)

            Catch ex As Exception
                ShowClientDivisionProductCodesOnly = False
            Finally
                LoadShowClientDivisionProductCodesOnlySetting = ShowClientDivisionProductCodesOnly
            End Try

        End Function
        Public Function LoadShowClientDivisionProductCodesOnlySetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim ShowClientDivisionProductCodesOnly As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_SHOW_CODEONLY.ToString AndAlso Setting.Value = 1).Any Then

                    ShowClientDivisionProductCodesOnly = True

                End If

            Catch ex As Exception
                ShowClientDivisionProductCodesOnly = False
            Finally
                LoadShowClientDivisionProductCodesOnlySetting = ShowClientDivisionProductCodesOnly
            End Try

        End Function
        'Public Function LoadTotalCostIncludesAllHoursSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

        '    'objects
        '    Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        '    Dim TotalCostIncludesAllHours As Boolean = True

        '    Try

        '        SettingsList = LoadSettings(DataContext)

        '        TotalCostIncludesAllHours = LoadTotalCostIncludesAllHoursSetting(DataContext, SettingsList)

        '    Catch ex As Exception
        '        TotalCostIncludesAllHours = True
        '    Finally
        '        LoadTotalCostIncludesAllHoursSetting = TotalCostIncludesAllHours
        '    End Try

        'End Function
        'Public Function LoadTotalCostIncludesAllHoursSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

        '    'objects
        '    Dim TotalCostIncludesAllHours As Boolean = True

        '    Try

        '        If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.EmployeeTimeForecast.SettingCodes.ETF_SHOW_TTLCOSTHRS.ToString AndAlso Setting.Value = 0).Any Then

        '            TotalCostIncludesAllHours = False

        '        End If

        '    Catch ex As Exception
        '        TotalCostIncludesAllHours = True
        '    Finally
        '        LoadTotalCostIncludesAllHoursSetting = TotalCostIncludesAllHours
        '    End Try

        'End Function
        Public Function LoadShowJobAndJobComponentDescriptionSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim ShowJobAndJobComponentDescription As Boolean = True

            Try

                SettingsList = LoadSettings(DataContext)

                ShowJobAndJobComponentDescription = LoadShowJobAndJobComponentDescriptionSetting(DataContext, SettingsList)

            Catch ex As Exception
                ShowJobAndJobComponentDescription = True
            Finally
                LoadShowJobAndJobComponentDescriptionSetting = ShowJobAndJobComponentDescription
            End Try

        End Function
        Public Function LoadShowJobAndJobComponentDescriptionSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim ShowJobAndJobComponentDescription As Boolean = True

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_SHOW_JOB_DTL.ToString AndAlso Setting.Value = 0).Any Then

                    ShowJobAndJobComponentDescription = False

                End If

            Catch ex As Exception
                ShowJobAndJobComponentDescription = True
            Finally
                LoadShowJobAndJobComponentDescriptionSetting = ShowJobAndJobComponentDescription
            End Try

        End Function
        Public Function LoadUseEmployeeTitleBillingRateSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim UseEmployeeTitleBillingRate As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                UseEmployeeTitleBillingRate = LoadUseEmployeeTitleBillingRateSetting(DataContext, SettingsList)

            Catch ex As Exception
                UseEmployeeTitleBillingRate = False
            Finally
                LoadUseEmployeeTitleBillingRateSetting = UseEmployeeTitleBillingRate
            End Try

        End Function
        Public Function LoadUseEmployeeTitleBillingRateSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim UseEmployeeTitleBillingRate As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_USE_EMPTTLE_RATE.ToString AndAlso Setting.Value = 1).Any Then

                    UseEmployeeTitleBillingRate = True

                End If

            Catch ex As Exception
                UseEmployeeTitleBillingRate = False
            Finally
                LoadUseEmployeeTitleBillingRateSetting = UseEmployeeTitleBillingRate
            End Try

        End Function
        Public Function LoadAutoAlertHoursChangedForSupervisedEmployeeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim AutoAlertHoursChangedForSupervisedEmployee As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                AutoAlertHoursChangedForSupervisedEmployee = LoadAutoAlertHoursChangedForSupervisedEmployeeSetting(DataContext, SettingsList)

            Catch ex As Exception
                AutoAlertHoursChangedForSupervisedEmployee = False
            Finally
                LoadAutoAlertHoursChangedForSupervisedEmployeeSetting = AutoAlertHoursChangedForSupervisedEmployee
            End Try

        End Function
        Public Function LoadAutoAlertHoursChangedForSupervisedEmployeeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim AutoAlertHoursChangedForSupervisedEmployee As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_AALT_HRSCHANGED.ToString AndAlso Setting.Value = 1).Any Then

                    AutoAlertHoursChangedForSupervisedEmployee = True

                End If

            Catch ex As Exception
                AutoAlertHoursChangedForSupervisedEmployee = False
            Finally
                LoadAutoAlertHoursChangedForSupervisedEmployeeSetting = AutoAlertHoursChangedForSupervisedEmployee
            End Try

        End Function
        Public Function LoadAutoAlertHoursOverbookedForEmployeeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim AutoAlertHoursOverbookedForEmployee As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                AutoAlertHoursOverbookedForEmployee = LoadAutoAlertHoursOverbookedForEmployeeSetting(DataContext, SettingsList)

            Catch ex As Exception
                AutoAlertHoursOverbookedForEmployee = False
            Finally
                LoadAutoAlertHoursOverbookedForEmployeeSetting = AutoAlertHoursOverbookedForEmployee
            End Try

        End Function
        Public Function LoadAutoAlertHoursOverbookedForEmployeeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim AutoAlertHoursOverbookedForEmployee As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_AALT_HRSEXCEED.ToString AndAlso Setting.Value = 1).Any Then

                    AutoAlertHoursOverbookedForEmployee = True

                End If

            Catch ex As Exception
                AutoAlertHoursOverbookedForEmployee = False
            Finally
                LoadAutoAlertHoursOverbookedForEmployeeSetting = AutoAlertHoursOverbookedForEmployee
            End Try

        End Function
        Public Function LoadHideDivisionColumnSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim HideDivisionColumn As Boolean = True

            Try

                SettingsList = LoadSettings(DataContext)

                HideDivisionColumn = LoadHideDivisionColumnSetting(DataContext, SettingsList)

            Catch ex As Exception
                HideDivisionColumn = True
            Finally
                LoadHideDivisionColumnSetting = HideDivisionColumn
            End Try

        End Function
        Public Function LoadHideDivisionColumnSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim HideDivisionColumn As Boolean = True

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_HIDE_DIV_COL.ToString AndAlso Setting.Value = 0).Any Then

                    HideDivisionColumn = False

                End If

            Catch ex As Exception
                HideDivisionColumn = True
            Finally
                LoadHideDivisionColumnSetting = HideDivisionColumn
            End Try

        End Function
        Public Function LoadHideProductColumnSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim HideProductColumn As Boolean = True

            Try

                SettingsList = LoadSettings(DataContext)

                HideProductColumn = LoadHideProductColumnSetting(DataContext, SettingsList)

            Catch ex As Exception
                HideProductColumn = True
            Finally
                LoadHideProductColumnSetting = HideProductColumn
            End Try

        End Function
        Public Function LoadHideProductColumnSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim HideProductColumn As Boolean = True

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_HIDE_PRD_COL.ToString AndAlso Setting.Value = 0).Any Then

                    HideProductColumn = False

                End If

            Catch ex As Exception
                HideProductColumn = True
            Finally
                LoadHideProductColumnSetting = HideProductColumn
            End Try

        End Function
        Public Function LoadHideRevenueShareInformationSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim HideRevenueShareInformation As Boolean = False

            Try

                SettingsList = LoadSettings(DataContext)

                HideRevenueShareInformation = LoadShowClientDivisionProductCodesOnlySetting(DataContext, SettingsList)

            Catch ex As Exception
                HideRevenueShareInformation = False
            Finally
                LoadHideRevenueShareInformationSetting = HideRevenueShareInformation
            End Try

        End Function
        Public Function LoadHideRevenueShareInformationSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting)) As Boolean

            'objects
            Dim HideRevenueShareInformation As Boolean = False

            Try

                If SettingsList.Where(Function(Setting) Setting.Code = AdvantageFramework.Agency.Settings.ETF_HIDE_REVSHAREAMT.ToString AndAlso Setting.Value = 1).Any Then

                    HideRevenueShareInformation = True

                End If

            Catch ex As Exception
                HideRevenueShareInformation = False
            Finally
                LoadHideRevenueShareInformationSetting = HideRevenueShareInformation
            End Try

        End Function

#End Region

#Region "  Office Detail "

        Public Function LoadEmployeeTimeForecastOfficeDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal PostPeriodCode As String, ByVal OfficeCode As String,
                                                              ByVal AssignedEmployeeCode As String, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                              ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim EmployeeTimeForecastOfficeDetails As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing
            Dim Month As Short = 0
            Dim Year As String = ""

            If DbContext IsNot Nothing Then

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, PostPeriodCode)

                If PostPeriod IsNot Nothing Then

                    Month = PostPeriod.Month
                    Year = PostPeriod.Year

                End If

                EmployeeTimeForecastOfficeDetails = LoadEmployeeTimeForecastOfficeDetails(DbContext, Month, Year, OfficeCode, AssignedEmployeeCode, SecurityDbContext, Session)

            End If

            LoadEmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails

        End Function
        Public Function LoadEmployeeTimeForecastOfficeDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal Month As Short, ByVal Year As String, ByVal OfficeCodee As String,
                                                              ByVal AssignedToEmployeeCode As String, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                              ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AssignedToEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeTimeForecastOfficeDetails As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing
            Dim Employeeoffice As String() = Nothing

            Employeeoffice = (From Item In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)
                              Select Item.OfficeCode).ToArray

            If DbContext IsNot Nothing Then

                If OfficeCodee IsNot Nothing AndAlso OfficeCodee <> "" Then

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OfficeCodee)

                End If

                If AssignedToEmployeeCode IsNot Nothing AndAlso AssignedToEmployeeCode <> "" Then

                    AssignedToEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AssignedToEmployeeCode)

                End If

                EmployeeTimeForecastOfficeDetails = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Load(DbContext)

                If Employeeoffice IsNot Nothing AndAlso Employeeoffice.Count > 0 Then

                    EmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails.Where(Function(EmployeeTimeForecastOfficeDetail) Employeeoffice.Contains(EmployeeTimeForecastOfficeDetail.OfficeCode))

                End If

                If Month <> 0 Then

                    EmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails.Where(Function(EmployeeTimeForecastOfficeDetail) EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Month = Month)

                End If

                If Year IsNot Nothing AndAlso Year <> "" Then

                    EmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails.Where(Function(EmployeeTimeForecastOfficeDetail) EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Year = Year)

                End If

                If Office IsNot Nothing Then

                    EmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails.Where(Function(EmployeeTimeForecastOfficeDetail) EmployeeTimeForecastOfficeDetail.OfficeCode = Office.Code)

                End If

                If AssignedToEmployee IsNot Nothing Then

                    EmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails.Where(Function(EmployeeTimeForecastOfficeDetail) EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode = AssignedToEmployee.Code)

                End If

            End If

            LoadEmployeeTimeForecastOfficeDetails = EmployeeTimeForecastOfficeDetails

        End Function
        Public Function InsertOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Description As String,
                                           ByVal PostPeriodCode As String, ByVal OfficeCode As String, ByVal AssignedToEmployeeCode As String,
                                           ByRef EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast,
                                           ByRef EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim OfficeDetailInserted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, PostPeriodCode)
                        Where Entity.OfficeCode = OfficeCode
                        Select Entity).Any = False Then

                        If AdvantageFramework.Database.Procedures.EmployeeTimeForecast.Insert(DbContext, Description, PostPeriodCode, EmployeeTimeForecast) Then

                            OfficeDetailInserted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Insert(DbContext, EmployeeTimeForecast.ID, 0, DbContext.UserCode, Now, OfficeCode, False, "", AssignedToEmployeeCode, EmployeeTimeForecastOfficeDetail)

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("An employee time forecast already exists for this post period and office.")

                    End If

                End If

            Catch ex As Exception
                InsertOfficeDetail = False
            Finally
                InsertOfficeDetail = OfficeDetailInserted
            End Try

        End Function

        Public Function CreateRevisionForEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                          ByVal ConnectionString As String, ByVal EmployeeTimeForecastOfficeDetailID As Integer,
                                                                          ByRef NewEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                          ByVal UpdateEmployeeRates As Boolean, ByVal UpdateRevenueAmounts As Boolean, ByVal ExcludeHoursEntered As Boolean) As Boolean

            'objects
            Dim RevisionCreated As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    RevisionCreated = CreateRevisionForEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID), NewEmployeeTimeForecastOfficeDetail, UpdateEmployeeRates, UpdateRevenueAmounts, ExcludeHoursEntered)

                End If

            Catch ex As Exception
                RevisionCreated = False
            Finally
                CreateRevisionForEmployeeTimeForecastOfficeDetail = RevisionCreated
            End Try

        End Function
        Public Function CreateRevisionForEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                          ByVal ConnectionString As String,
                                                                          ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                          ByRef NewEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                          ByVal UpdateEmployeeRates As Boolean, ByVal UpdateRevenueAmounts As Boolean, ByVal ExcludeHoursEntered As Boolean) As Boolean

            'objects
            Dim RevisionCreated As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing
            Dim RevisionNumber As Integer = 0
            Dim JobComponentEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
            Dim JobComponentAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
            Dim IndirectCategoryEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
            Dim IndirectCategoryAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
            Dim OldJobComponentEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
            Dim OldJobComponentAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
            Dim OldIndirectCategoryEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
            Dim OldIndirectCategoryAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID)

                        If EmployeeTimeForecast IsNot Nothing Then

                            RevisionNumber = EmployeeTimeForecast.EmployeeTimeForecastOfficeDetails.Where(Function(OfficeDetail) OfficeDetail.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).
                                                                                                    Select(Function(OfficeDetail) OfficeDetail.RevisionNumber).Max

                            RevisionNumber += 1

                            If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Insert(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID,
                                                                                                              RevisionNumber, DbContext.UserCode, Now, EmployeeTimeForecastOfficeDetail.OfficeCode,
                                                                                                              False, EmployeeTimeForecastOfficeDetail.Comment, EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode,
                                                                                                              NewEmployeeTimeForecastOfficeDetail) Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_etf_create_revision] {0}, {1}, {2}, {3}, {4}, {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                NewEmployeeTimeForecastOfficeDetail.ID, If(UpdateEmployeeRates, 1, 0),
                                                                                If(UpdateRevenueAmounts, 1, 0), If(ExcludeHoursEntered, 1, 0)))

                                'For Each JobComponentDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents

                                '    InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, NewEmployeeTimeForecastOfficeDetail, _
                                '                                                         JobComponentDetail.JobComponent, UpdateRevenueAmounts, _
                                '                                                         JobComponentDetail.RevenueAmount)

                                'Next

                                'For Each IndirectCategoryDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories

                                '    InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, NewEmployeeTimeForecastOfficeDetail, _
                                '                                                             IndirectCategoryDetail.IndirectCategory)

                                'Next

                                'For Each EmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                                '    InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, NewEmployeeTimeForecastOfficeDetail, _
                                '                                                     EmployeeDetail.Employee, UpdateEmployeeRates, _
                                '                                                     EmployeeDetail.BillRate, UpdateEmployeeRates, EmployeeDetail.CostRate)

                                'Next

                                'For Each AlternateEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                '    InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, NewEmployeeTimeForecastOfficeDetail, _
                                '                                                              AlternateEmployeeDetail.EmployeeTitle, _
                                '                                                              AlternateEmployeeDetail.Description, AlternateEmployeeDetail.Office, _
                                '                                                              UpdateEmployeeRates, AlternateEmployeeDetail.BillRate, UpdateEmployeeRates, _
                                '                                                              AlternateEmployeeDetail.CostRate)

                                'Next

                                'If ExcludeHoursEntered = False Then

                                '    For Each OldJobComponentEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees

                                '        Try

                                '            JobComponentEmployeeDetail = (From Entity In NewEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees _
                                '                                          Where Entity.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode AndAlso _
                                '                                                Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber AndAlso _
                                '                                                Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber _
                                '                                          Select Entity).SingleOrDefault

                                '        Catch ex As Exception
                                '            JobComponentEmployeeDetail = Nothing
                                '        End Try

                                '        If JobComponentEmployeeDetail IsNot Nothing Then

                                '            JobComponentEmployeeDetail.Hours = OldJobComponentEmployeeDetail.Hours

                                '            DbContext.UpdateObject(JobComponentEmployeeDetail)

                                '        End If

                                '    Next

                                '    For Each OldJobComponentAlternateEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees

                                '        Try

                                '            JobComponentAlternateEmployeeDetail = (From Entity In NewEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees _
                                '                                                   Where Entity.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description AndAlso _
                                '                                                         Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber AndAlso _
                                '                                                         Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber _
                                '                                                   Select Entity).SingleOrDefault

                                '        Catch ex As Exception
                                '            JobComponentAlternateEmployeeDetail = Nothing
                                '        End Try

                                '        If JobComponentAlternateEmployeeDetail IsNot Nothing Then

                                '            JobComponentAlternateEmployeeDetail.Hours = OldJobComponentAlternateEmployeeDetail.Hours

                                '            DbContext.UpdateObject(JobComponentAlternateEmployeeDetail)

                                '        End If

                                '    Next

                                '    For Each OldIndirectCategoryEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees

                                '        Try

                                '            IndirectCategoryEmployeeDetail = (From Entity In NewEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees _
                                '                                              Where Entity.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = OldIndirectCategoryEmployeeDetail.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode AndAlso _
                                '                                                    Entity.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode = OldIndirectCategoryEmployeeDetail.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode _
                                '                                              Select Entity).SingleOrDefault

                                '        Catch ex As Exception
                                '            IndirectCategoryEmployeeDetail = Nothing
                                '        End Try

                                '        If IndirectCategoryEmployeeDetail IsNot Nothing Then

                                '            IndirectCategoryEmployeeDetail.Hours = OldIndirectCategoryEmployeeDetail.Hours

                                '            DbContext.UpdateObject(IndirectCategoryEmployeeDetail)

                                '        End If

                                '    Next

                                '    For Each OldIndirectCategoryAlternateEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees

                                '        Try

                                '            IndirectCategoryAlternateEmployeeDetail = (From Entity In NewEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees _
                                '                                                       Where Entity.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = OldIndirectCategoryAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description AndAlso _
                                '                                                             Entity.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode = OldIndirectCategoryAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode _
                                '                                                       Select Entity).SingleOrDefault

                                '        Catch ex As Exception
                                '            IndirectCategoryAlternateEmployeeDetail = Nothing
                                '        End Try

                                '        If IndirectCategoryAlternateEmployeeDetail IsNot Nothing Then

                                '            IndirectCategoryAlternateEmployeeDetail.Hours = OldIndirectCategoryAlternateEmployeeDetail.Hours

                                '            DbContext.UpdateObject(IndirectCategoryAlternateEmployeeDetail)

                                '        End If

                                '    Next

                                '    Try

                                '        DbContext.SaveChanges()

                                '    Catch ex As Exception

                                '    End Try

                                'End If

                                RevisionCreated = True

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                RevisionCreated = False
            Finally
                CreateRevisionForEmployeeTimeForecastOfficeDetail = RevisionCreated
            End Try

        End Function

        Public Function DeleteRevisionForEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As Boolean

            'objects
            Dim RevisionDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    RevisionDeleted = DeleteRevisionForEmployeeTimeForecastOfficeDetail(DbContext, AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID))

                End If

            Catch ex As Exception
                RevisionDeleted = False
            Finally
                DeleteRevisionForEmployeeTimeForecastOfficeDetail = RevisionDeleted
            End Try

        End Function
        Public Function DeleteRevisionForEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim RevisionDeleted As Boolean = False
            Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        For Each JobComponentDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.ToList

                            DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, JobComponentDetail)

                        Next

                        For Each IndirectCategoryDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.ToList

                            DeleteIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, IndirectCategoryDetail)

                        Next

                        For Each EmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.ToList

                            DeleteEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeDetail)

                        Next

                        For Each AlternateEmployeeDetail In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList

                            DeleteAlternateEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, AlternateEmployeeDetail)

                        Next

                        RevisionDeleted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Delete(DbContext, EmployeeTimeForecastOfficeDetail.ID)

                        If RevisionDeleted AndAlso AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID).Any = False Then

                            EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID)

                            If EmployeeTimeForecast IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.EmployeeTimeForecast.Delete(DbContext, EmployeeTimeForecast)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                RevisionDeleted = False
            Finally
                DeleteRevisionForEmployeeTimeForecastOfficeDetail = RevisionDeleted
            End Try

        End Function

        Public Function CheckToSendAlert(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee,
                                         ByVal UpdatedHours As Decimal) As Boolean

            'objects
            Dim SendAlert As Boolean = False
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailJobComponentEmployee IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours <> UpdatedHours Then

                            User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                            If User IsNot Nothing Then

                                If EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.Employee IsNot Nothing Then

                                    If EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.Employee.SupervisorEmployeeCode <> User.EmployeeCode Then

                                        SendAlert = True

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                SendAlert = False
            Finally
                CheckToSendAlert = SendAlert
            End Try

        End Function
        Public Function SendAlert(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                  ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                  ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                  ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal)) As Boolean

            'objects
            Dim AlertSent As Boolean = False
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponentEmployeeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) = Nothing

            Try

                If DbContext IsNot Nothing Then

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                    If User IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary IsNot Nothing Then

                            For Each SupervisorEmployeeCode In EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary.Select(Function(KeyValuePair) KeyValuePair.Key.EmployeeTimeForecastOfficeDetailEmployee.Employee.SupervisorEmployeeCode).Distinct.ToList

                                AdvantageFramework.AlertSystem.CreateAlertForEmployeeTimeForcast(DbContext, SecurityDbContext, User, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary, SupervisorEmployeeCode)

                            Next

                            AlertSent = True

                        End If

                    End If

                End If

            Catch ex As Exception
                AlertSent = False
            Finally
                SendAlert = AlertSent
            End Try

        End Function
        Public Function SendAlert(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                  ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                  ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim AlertSent As Boolean = False
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim HoursWorked As Decimal = 0
            Dim HoursAvailable As Decimal = 0
            Dim EmployeeTimeForecastOfficeDetailEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee, Decimal) = Nothing
            Dim SupervisorEmployeeCode As String = ""

            Try

                If DbContext IsNot Nothing Then

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, DbContext.UserCode)

                    If User IsNot Nothing Then

                        AdvantageFramework.EmployeeUtilities.CreateEmployeeStandardHours(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.StartDate.Value, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.EndDate.Value)

                        For Each SupervisorEmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee.SupervisorEmployeeCode).Distinct.ToList

                            EmployeeTimeForecastOfficeDetailEmployeeDictionary = New Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee, Decimal)

                            For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.SupervisorEmployeeCode = SupervisorEmployeeCode)

                                HoursWorked = EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Sum(Function(OfficeDetailJobComponentEmployee) OfficeDetailJobComponentEmployee.Hours)
                                HoursAvailable = AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(DbContext, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                                If HoursWorked > HoursAvailable Then

                                    EmployeeTimeForecastOfficeDetailEmployeeDictionary(EmployeeTimeForecastOfficeDetailEmployee) = HoursAvailable

                                End If

                            Next

                            If EmployeeTimeForecastOfficeDetailEmployeeDictionary.Count > 0 Then

                                AdvantageFramework.AlertSystem.CreateAlertForEmployeeTimeForcast(DbContext, SecurityDbContext, User, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployeeDictionary, SupervisorEmployeeCode)

                            End If

                        Next

                        AlertSent = True

                    End If

                End If

            Catch ex As Exception
                AlertSent = False
            Finally
                SendAlert = AlertSent
            End Try

        End Function

        Public Function LoadTotalIndirectHours(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Decimal

            'objects
            Dim TotalIndirectHours As Decimal = 0

            Try

                TotalIndirectHours = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.
                                                                      Where(Function(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.ID).
                                                                      Sum(Function(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours)

            Catch ex As Exception
                TotalIndirectHours = 0
            Finally
                LoadTotalIndirectHours = TotalIndirectHours
            End Try

        End Function
        Public Function LoadTotalHours(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Decimal

            'objects
            Dim TotalHours As Decimal = 0

            Try

                TotalHours = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.
                                                              Where(Function(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID).
                                                              Sum(Function(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours) +
                             EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.
                                                              Where(Function(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID).
                                                              Sum(Function(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours)

            Catch ex As Exception
                TotalHours = 0
            Finally
                LoadTotalHours = TotalHours
            End Try

        End Function
        Public Function LoadTotalDirectHours(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Decimal

            'objects
            Dim TotalDirectHours As Decimal = 0

            Try

                TotalDirectHours = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.
                                                                    Where(Function(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID).
                                                                    Sum(Function(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours)

            Catch ex As Exception
                TotalDirectHours = 0
            Finally
                LoadTotalDirectHours = TotalDirectHours
            End Try

        End Function

        Public Function LoadTotalHours(ByVal DataTable As System.Data.DataTable, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeCode As String) As Decimal

            'objects
            Dim TotalHours As Decimal = 0

            Try

                TotalHours = (From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                              Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                              Select CDec(Row(EmployeeCode))).Sum

            Catch ex As Exception
                TotalHours = 0
            Finally
                LoadTotalHours = TotalHours
            End Try

        End Function
        Public Function LoadTotalDirectHours(ByVal DataTable As System.Data.DataTable, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeCode As String) As Decimal

            'objects
            Dim TotalDirectHours As Decimal = 0

            Try

                TotalDirectHours = (From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                                    Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "" AndAlso
                                          Row(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) <> StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString
                                    Select CDec(Row(EmployeeCode))).Sum

            Catch ex As Exception
                TotalDirectHours = 0
            Finally
                LoadTotalDirectHours = TotalDirectHours
            End Try

        End Function

        Public Function LoadTotalCost(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee, ByVal TotalCostIncludesAllHours As Boolean) As Decimal

            'objects
            Dim TotalCost As Decimal = 0

            Try

                If TotalCostIncludesAllHours Then

                    TotalCost = (EmployeeTimeForecastOfficeDetailAlternateEmployee.CostRate * LoadTotalHours(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee))

                Else

                    TotalCost = (EmployeeTimeForecastOfficeDetailAlternateEmployee.CostRate * LoadTotalDirectHours(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee))

                End If

            Catch ex As Exception
                TotalCost = 0
            Finally
                LoadTotalCost = TotalCost
            End Try

        End Function
        Public Function LoadTotalCost(ByVal DataTable As System.Data.DataTable, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee, ByVal TotalCostIncludesAllHours As Boolean) As Decimal

            'objects
            Dim TotalCost As Decimal = 0

            Try

                If TotalCostIncludesAllHours Then

                    TotalCost = (EmployeeTimeForecastOfficeDetailEmployee.CostRate * LoadTotalHours(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

                Else

                    TotalCost = (EmployeeTimeForecastOfficeDetailEmployee.CostRate * LoadTotalDirectHours(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

                End If

            Catch ex As Exception
                TotalCost = 0
            Finally
                LoadTotalCost = TotalCost
            End Try

        End Function
        Public Function LoadTotalRevenue(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Decimal

            'objects
            Dim TotalRevenue As Decimal = 0

            Try

                TotalRevenue = (EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate * LoadTotalDirectHours(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee))

            Catch ex As Exception
                TotalRevenue = 0
            Finally
                LoadTotalRevenue = TotalRevenue
            End Try

        End Function
        Public Function LoadTotalRevenue(ByVal DataTable As System.Data.DataTable, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Decimal

            'objects
            Dim TotalRevenue As Decimal = 0

            Try

                TotalRevenue = (EmployeeTimeForecastOfficeDetailEmployee.BillRate * LoadTotalDirectHours(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

            Catch ex As Exception
                TotalRevenue = 0
            Finally
                LoadTotalRevenue = TotalRevenue
            End Try

        End Function

        Public Function BuildCostRateRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                         ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim CostRateRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    'DataRow = DataTable.Rows.Add

                    'DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.CostRate)
                    'DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.CostRate)
                    'DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    'DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.CostRate.ToString
                    'DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.CostRate.ToString)
                    'DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    'DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = ""

                    'For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                    '    DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = EmployeeTimeForecastOfficeDetailEmployee.CostRate

                    'Next

                    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                    '    DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = EmployeeTimeForecastOfficeDetailAlternateEmployee.CostRate

                    'Next

                    'CostRateRowBuilt = True

                End If

            Catch ex As Exception
                CostRateRowBuilt = False
            Finally
                BuildCostRateRow = CostRateRowBuilt
            End Try

        End Function
        Public Function BuildBillableRateRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                             ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim BillableRateRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.BillableRate)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.BillableRate)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.BillableRate.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.BillableRate.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = ""

                    For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatCurrency(EmployeeTimeForecastOfficeDetailEmployee.BillRate)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = FormatCurrency(EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate)

                    Next

                    BillableRateRowBuilt = True

                End If

            Catch ex As Exception
                BillableRateRowBuilt = False
            Finally
                BuildBillableRateRow = BillableRateRowBuilt
            End Try

        End Function
        Public Function BuildTotalRevenueRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                             ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim TotalRevenueRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalRevenue)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalRevenue)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = ""

                    For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatCurrency(LoadTotalRevenue(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee))

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = FormatCurrency(LoadTotalRevenue(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee))

                    Next

                    TotalRevenueRowBuilt = True

                End If

            Catch ex As Exception
                TotalRevenueRowBuilt = False
            Finally
                BuildTotalRevenueRow = TotalRevenueRowBuilt
            End Try

        End Function
        Public Function BuildTotalCostRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                          ByRef DataTable As System.Data.DataTable, ByVal TotalCostIncludesAllHours As Boolean) As Boolean

            'objects
            Dim TotalCostRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    'DataRow = DataTable.Rows.Add

                    'DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalCost)
                    'DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalCost)
                    'DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    'DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.TotalCost.ToString
                    'DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.TotalCost.ToString)
                    'DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    'DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    'DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = ""

                    'For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                    '    DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = LoadTotalCost(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee, TotalCostIncludesAllHours)

                    'Next

                    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                    '    DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = LoadTotalCost(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee, TotalCostIncludesAllHours)

                    'Next

                    'TotalCostRowBuilt = True

                End If

            Catch ex As Exception
                TotalCostRowBuilt = False
            Finally
                BuildTotalCostRow = TotalCostRowBuilt
            End Try

        End Function
        Public Function BuildHoursAvailableRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                               ByVal EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail),
                                               ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim HoursAvailableRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing AndAlso EmployeeStandardHoursDetailList IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.HoursAvailable)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.HoursAvailable)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.HoursAvailable.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.HoursAvailable.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(0, 2)

                    For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                        DataRow(EmployeeCode) = AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(EmployeeStandardHoursDetailList, EmployeeCode)

                        DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(CDec(DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString)) + CDec(DataRow(EmployeeCode)), 2)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 168

                        DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(CDec(DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString)) + CDec(DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)), 2)

                    Next

                    HoursAvailableRowBuilt = True

                End If

            Catch ex As Exception
                HoursAvailableRowBuilt = False
            Finally
                BuildHoursAvailableRow = HoursAvailableRowBuilt
            End Try

        End Function
        Public Function BuildTotalHoursRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                  ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim TotalHoursRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalHours)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalHours)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.TotalHours.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.TotalHours.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(0, 2)

                    For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatNumber(LoadTotalHours(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), 2)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = FormatNumber(LoadTotalHours(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee), 2)

                    Next

                    TotalHoursRowBuilt = True

                End If

            Catch ex As Exception
                TotalHoursRowBuilt = False
            Finally
                BuildTotalHoursRow = TotalHoursRowBuilt
            End Try

        End Function
        Public Function BuildDirectHoursGoalRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                ByVal EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail),
                                                ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DirectHoursGoalRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DirectHoursGoal As Decimal = 0

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing AndAlso EmployeeStandardHoursDetailList IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.DirectHoursGoal)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.DirectHoursGoal)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.DirectHoursGoal.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.DirectHoursGoal.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(0, 2)

                    For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        DirectHoursGoal = 0

                        Try

                            DirectHoursGoal = AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(EmployeeStandardHoursDetailList, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) * (EmployeeTimeForecastOfficeDetailEmployee.Employee.DirectHours.GetValueOrDefault(0) / 100)

                        Catch ex As Exception
                            DirectHoursGoal = EmployeeTimeForecastOfficeDetailEmployee.Employee.MonthHoursGoal.GetValueOrDefault(0)
                        End Try

                        DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatNumber(DirectHoursGoal, 2)

                        DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(CDec(DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString)) + CDec(DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)), 2)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = 0

                    Next

                    DirectHoursGoalRowBuilt = True

                End If

            Catch ex As Exception
                DirectHoursGoalRowBuilt = False
            Finally
                BuildDirectHoursGoalRow = DirectHoursGoalRowBuilt
            End Try

        End Function
        Public Function BuildTotalAmountsAndDirectHoursRow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                           ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim TotalAmountsAndDirectHoursRowBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    DataRow = DataTable.Rows.Add

                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalAmountsAndDirectHours)
                    DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = CInt(StaticEmployeeTimeForecastSubItem.TotalAmountsAndDirectHours)
                    DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastSubItem.TotalAmountsAndDirectHours.ToString
                    DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastSubItem.TotalAmountsAndDirectHours.ToString)
                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = (From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                                                                                        Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "" AndAlso
                                                                                              Row(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = EmployeeTimeForecastOfficeDetail.OfficeCode
                                                                                        Select CDec(Row(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))).Sum

                    DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                                                                                                            Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                                                                                                            Select CDec(Row(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString))).Sum)

                    DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                                                                                                                Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                                                                                                                Select CDec(Row(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString))).Sum)

                    DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency((From Row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                                                                                                           Where Row(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                                                                                                           Select CDec(Row(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString))).Sum)

                    DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(0, 2)

                    For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = LoadTotalDirectHours(DataTable, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(CDec(DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString)) + CDec(DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)), 2)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) = LoadTotalDirectHours(EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee)

                        DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(CDec(DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString)) + CDec(DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString)), 2)

                    Next

                    TotalAmountsAndDirectHoursRowBuilt = True

                End If

            Catch ex As Exception
                TotalAmountsAndDirectHoursRowBuilt = False
            Finally
                BuildTotalAmountsAndDirectHoursRow = TotalAmountsAndDirectHoursRowBuilt
            End Try

        End Function
        Public Function BuildGrandTotalForecastRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                    ByRef DataTable As System.Data.DataTable, ByVal TotalCostIncludesAllHours As Boolean) As Boolean

            'objects
            Dim GrandTotalForecastRowsBuilt As Boolean = False
            Dim HeaderDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail) = Nothing

            Try

                HeaderDataRow = DataTable.Rows.Add

                HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                HeaderDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString
                HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(0)
                HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(0)
                HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(0)
                HeaderDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(0, 2)

                For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                    HeaderDataRow(EmployeeCode) = 0

                Next

                For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                    HeaderDataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                Next

                AdvantageFramework.EmployeeUtilities.CreateEmployeeStandardHours(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.StartDate.Value, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.EndDate.Value)

                EmployeeStandardHoursDetailList = AdvantageFramework.Database.Procedures.EmployeeStandardHoursDetail.LoadByUserCode(DbContext, DbContext.UserCode).ToList

                BuildTotalAmountsAndDirectHoursRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable)
                BuildDirectHoursGoalRow(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeStandardHoursDetailList, DataTable)
                BuildTotalHoursRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable)
                BuildHoursAvailableRow(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeStandardHoursDetailList, DataTable)
                'BuildTotalCostRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, TotalCostIncludesAllHours)
                BuildTotalRevenueRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable)
                BuildBillableRateRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable)
                'BuildCostRateRow(DbContext, EmployeeTimeForecastOfficeDetail, DataTable)

                GrandTotalForecastRowsBuilt = True

            Catch ex As Exception
                GrandTotalForecastRowsBuilt = False
            Finally
                BuildGrandTotalForecastRows = GrandTotalForecastRowsBuilt
            End Try

        End Function
        Public Function BuildIndirectCategoriesForecastRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                            ByRef DataTable As System.Data.DataTable,
                                                            ByVal ETFOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent),
                                                            ByVal ETFOfficeDetailIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory),
                                                            ByVal ETFOfficeDetailIndirectCategoryAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee),
                                                            ByVal ETFOfficeDetailIndirectCategoryEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryEmployee),
                                                            ByVal ETFOfficeDetailJobComponentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentAlternateEmployee),
                                                            ByVal ETFOfficeDetailJobComponentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentEmployee)) As Boolean

            'objects
            Dim IndirectCategoriesForecastRowsBuilt As Boolean = False
            Dim HeaderDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim TotalHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim TotalHoursForDetail As Decimal = 0
            Dim TotalHoursForHeader As Decimal = 0
            Dim ETFOfficeDetailIndirectCategory As AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.Any Then

                        TotalHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        HeaderDataRow = DataTable.Rows.Add

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = AdvantageFramework.StringUtilities.GetNameAsWords(StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString)
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = 0

                        For Each ETFOfficeDetailIndirectCategory In ETFOfficeDetailIndirectCategoriesList

                            DataRow = DataTable.Rows.Add

                            DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                            DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = ETFOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailIndirectCategoryID
                            DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString
                            DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = ETFOfficeDetailIndirectCategory.IndirectCategory
                            DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""
                            DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailIndirectCategory.IndirectCategory
                            DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                            DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                            DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                            DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                            DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(0)
                            DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(0)
                            DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(0)

                            TotalHoursForDetail = 0

                            For Each EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee In ETFOfficeDetailIndirectCategoryEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailIndirectCategoryID = ETFOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailIndirectCategoryID).ToList

                                If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeCode) Then

                                    DataRow(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeCode) = EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours

                                    TotalHoursForDetail += EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours

                                    If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeCode) Then

                                        TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours

                                    End If

                                End If

                            Next

                            For Each EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee In ETFOfficeDetailIndirectCategoryAlternateEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailIndirectCategoryID = ETFOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailIndirectCategoryID).ToList

                                If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                    DataRow(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours

                                    TotalHoursForDetail += EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours

                                    If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                        TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) += EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours

                                    End If

                                End If

                            Next

                            DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForDetail, 2)

                        Next

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(0)
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(0)
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(0)

                        TotalHoursForHeader = 0

                        For Each TotalEmployeeHours In TotalHoursForEmployeeDictionary

                            HeaderDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)
                            TotalHoursForHeader += TotalEmployeeHours.Value

                        Next

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForHeader, 2)

                    End If

                    IndirectCategoriesForecastRowsBuilt = True

                End If

            Catch ex As Exception
                IndirectCategoriesForecastRowsBuilt = False
            Finally
                BuildIndirectCategoriesForecastRows = IndirectCategoriesForecastRowsBuilt
            End Try

        End Function
        Public Function BuildOtherOfficeForecastRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                     ByRef DataTable As System.Data.DataTable, ByVal ShowJobAndJobComponentDescription As Boolean, ByVal ShowClientDivisionProductCodesOnly As Boolean,
                                                     ByVal ETFOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent),
                                                     ByVal ETFOfficeDetailIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory),
                                                     ByVal ETFOfficeDetailIndirectCategoryAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee),
                                                     ByVal ETFOfficeDetailIndirectCategoryEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryEmployee),
                                                     ByVal ETFOfficeDetailJobComponentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentAlternateEmployee),
                                                     ByVal ETFOfficeDetailJobComponentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentEmployee)) As Boolean

            'objects
            Dim OtherOfficeForecastRowsBuilt As Boolean = False
            Dim HeaderDataRow As System.Data.DataRow = Nothing
            Dim ClientDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim UtilizationAmount As Decimal = 0
            Dim BillRate As Decimal = 0
            Dim TotalUtilizationAmount As Decimal = 0
            Dim TotalHoursForDetail As Decimal = 0
            Dim TotalHoursForHeader As Decimal = 0
            Dim TotalHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim PreviousClientCode As String = ""
            Dim TotalClientUtilizationAmount As Decimal = 0
            Dim TotalHoursForClient As Decimal = 0
            Dim TotalClientHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim OtherOffice As Object = Nothing
            Dim ETFOfficeDetailJobComponent As AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    For Each OtherOffice In (From Entity In ETFOfficeDetailJobComponentsList
                                             Where Entity.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode
                                             Select Entity.OfficeCode,
                                                    Entity.OfficeDescription).OrderBy(Function(Entity) Entity.OfficeCode).Distinct.ToList

                        TotalUtilizationAmount = 0
                        TotalHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        If OtherOffice IsNot Nothing Then

                            HeaderDataRow = DataTable.Rows.Add

                            HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = OtherOffice.OfficeCode
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = OtherOffice.OfficeDescription
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = 0

                            For Each ETFOfficeDetailJobComponent In (From OfficeDetailJobComponent In ETFOfficeDetailJobComponentsList
                                                                     Where OfficeDetailJobComponent.OfficeCode = OtherOffice.OfficeCode
                                                                     Select OfficeDetailJobComponent).OrderBy(Function(Entity) Entity.ClientDescription).ThenBy(Function(Entity) Entity.JobDescription).ToList

                                If PreviousClientCode <> ETFOfficeDetailJobComponent.ClientCode Then

                                    If ClientDataRow IsNot Nothing Then

                                        For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                            ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                                        Next

                                    End If

                                    PreviousClientCode = ETFOfficeDetailJobComponent.ClientCode

                                    TotalClientUtilizationAmount = 0
                                    TotalHoursForClient = 0

                                    ClientDataRow = DataTable.Rows.Add

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = OtherOffice.OfficeCode
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = OtherOffice.OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                                    If ShowClientDivisionProductCodesOnly Then

                                        ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode

                                    Else

                                        ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription

                                    End If

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(0)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(0)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(0)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                                    TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                                    For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                                        TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                                    Next

                                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                                        TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                                    Next

                                End If

                                DataRow = DataTable.Rows.Add

                                DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID
                                DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                                DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = OtherOffice.OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                                DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = ETFOfficeDetailJobComponent.JobComponent
                                DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                                If ShowClientDivisionProductCodesOnly Then

                                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode
                                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionCode
                                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductCode

                                Else

                                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription
                                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionDescription
                                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductDescription

                                End If

                                If ShowJobAndJobComponentDescription Then

                                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponentDescription

                                Else

                                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponent

                                End If

                                DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0

                                UtilizationAmount = 0
                                TotalHoursForDetail = 0

                                For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In ETFOfficeDetailJobComponentEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                    If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                        DataRow(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                        TotalHoursForDetail += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours
                                        TotalHoursForClient += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                        BillRate = EmployeeTimeForecastOfficeDetailJobComponentEmployee.BillRate

                                        If EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeOfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                            UtilizationAmount += (EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * BillRate)

                                        End If

                                        If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                        End If

                                        If TotalClientHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                            TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                        End If

                                    End If

                                Next

                                For Each EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In ETFOfficeDetailJobComponentAlternateEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                    If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                        DataRow(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                        TotalHoursForDetail += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours
                                        TotalHoursForClient += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                        BillRate = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.BillRate

                                        If EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.AlternateEmployeeOfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                            UtilizationAmount += (EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours * BillRate)

                                        End If

                                        If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                        End If

                                        If TotalClientHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                            TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                        End If

                                    End If

                                Next

                                DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(UtilizationAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(UtilizationAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(UtilizationAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForDetail, 2)

                                TotalClientUtilizationAmount += UtilizationAmount

                                TotalUtilizationAmount += UtilizationAmount

                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(0)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(0)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(0)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                            Next

                            If ClientDataRow IsNot Nothing Then

                                For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                    ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                                Next

                            End If

                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(TotalUtilizationAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalUtilizationAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalUtilizationAmount)

                            TotalHoursForHeader = 0

                            For Each TotalEmployeeHours In TotalHoursForEmployeeDictionary

                                HeaderDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)
                                TotalHoursForHeader += TotalEmployeeHours.Value

                            Next

                            HeaderDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForHeader, 2)

                            'BuildSecondaryOfficeForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, ShowJobAndJobComponentDescription, ShowClientDivisionProductCodesOnly, OtherOffice.OfficeCode, OtherOffice.OfficeDescription,
                            '                                 ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList,
                            '                                 ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                        End If

                    Next

                    OtherOfficeForecastRowsBuilt = True

                End If

            Catch ex As Exception
                OtherOfficeForecastRowsBuilt = False
            Finally
                BuildOtherOfficeForecastRows = OtherOfficeForecastRowsBuilt
            End Try

        End Function
        Public Function BuildPrimaryOfficeForecastRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                       ByRef DataTable As System.Data.DataTable, ByVal ShowJobAndJobComponentDescription As Boolean, ByVal ShowClientDivisionProductCodesOnly As Boolean,
                                                       ByVal ETFOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent),
                                                       ByVal ETFOfficeDetailIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory),
                                                       ByVal ETFOfficeDetailIndirectCategoryAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee),
                                                       ByVal ETFOfficeDetailIndirectCategoryEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryEmployee),
                                                       ByVal ETFOfficeDetailJobComponentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentAlternateEmployee),
                                                       ByVal ETFOfficeDetailJobComponentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentEmployee)) As Boolean

            'objects
            Dim PrimaryOfficeForecastRowsBuilt As Boolean = False
            Dim HeaderDataRow As System.Data.DataRow = Nothing
            Dim ClientDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim UtilizationAmount As Decimal = 0
            Dim RevenueShareAmount As Decimal = 0
            Dim BillRate As Decimal = 0
            Dim TotalRevenueAmount As Decimal = 0
            Dim TotalRevenueShareAmount As Decimal = 0
            Dim TotalWithRevenueShareAmount As Decimal = 0
            Dim TotalUtilizationAmount As Decimal = 0
            Dim TotalHoursForDetail As Decimal = 0
            Dim TotalHoursForHeader As Decimal = 0
            Dim TotalHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim PreviousClientCode As String = ""
            Dim TotalClientRevenueAmount As Decimal = 0
            Dim TotalClientRevenueShareAmount As Decimal = 0
            Dim TotalClientWithRevenueShareAmount As Decimal = 0
            Dim TotalClientUtilizationAmount As Decimal = 0
            Dim TotalHoursForClient As Decimal = 0
            Dim TotalClientHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim ETFOfficeDetailJobComponent As AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    If ETFOfficeDetailJobComponentsList.Where(Function(Entity) Entity.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Any Then

                        TotalHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        HeaderDataRow = DataTable.Rows.Add

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = EmployeeTimeForecastOfficeDetail.OfficeCode
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = EmployeeTimeForecastOfficeDetail.Office.Name
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = 0

                        For Each ETFOfficeDetailJobComponent In ETFOfficeDetailJobComponentsList.Where(Function(Entity) Entity.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).OrderBy(Function(Entity) Entity.ClientDescription).ThenBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.JobDescription)

                            If PreviousClientCode <> ETFOfficeDetailJobComponent.ClientCode Then

                                If ClientDataRow IsNot Nothing Then

                                    For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                        ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                                    Next

                                End If

                                PreviousClientCode = ETFOfficeDetailJobComponent.ClientCode

                                TotalClientRevenueAmount = 0
                                TotalClientRevenueShareAmount = 0
                                TotalClientWithRevenueShareAmount = 0
                                TotalClientUtilizationAmount = 0
                                TotalHoursForClient = 0

                                ClientDataRow = DataTable.Rows.Add

                                ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                                ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                                ClientDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = EmployeeTimeForecastOfficeDetail.OfficeCode
                                ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = EmployeeTimeForecastOfficeDetail.OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                                ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                                If ShowClientDivisionProductCodesOnly Then

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode

                                Else

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription

                                End If

                                ClientDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                                ClientDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                                ClientDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(TotalClientRevenueAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalClientRevenueShareAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientWithRevenueShareAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                                TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                                For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                                    TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                                Next

                                For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                                    TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                                Next

                            End If

                            DataRow = DataTable.Rows.Add

                            DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID
                            DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                            DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = EmployeeTimeForecastOfficeDetail.OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                            DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = ETFOfficeDetailJobComponent.JobComponent
                            DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                            If ShowClientDivisionProductCodesOnly Then

                                DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode
                                DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionCode
                                DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductCode

                            Else

                                DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription
                                DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionDescription
                                DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductDescription

                            End If

                            If ShowJobAndJobComponentDescription Then

                                DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponentDescription

                            Else

                                DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponent

                            End If

                            DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ETFOfficeDetailJobComponent.RevenueAmount

                            UtilizationAmount = 0
                            RevenueShareAmount = 0
                            TotalHoursForDetail = 0

                            For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In ETFOfficeDetailJobComponentEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                    DataRow(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    TotalHoursForDetail += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours
                                    TotalHoursForClient += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    BillRate = EmployeeTimeForecastOfficeDetailJobComponentEmployee.BillRate

                                    UtilizationAmount += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * BillRate

                                    If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                        TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    End If

                                    If TotalClientHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                        TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    End If

                                    If EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeOfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                        If ETFOfficeDetailJobComponent.IsNonBillable = False AndAlso DbContext.Database.SqlQuery(Of Boolean)("EXEC dbo.advsp_billing_rate_is_non_billable '" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode & "', " &
                                                                                                                                                              "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " &
                                                                                                                                                              ETFOfficeDetailJobComponent.JobNumber & ", " &
                                                                                                                                                              ETFOfficeDetailJobComponent.ComponentNumber).FirstOrDefault = False Then

                                            'Try

                                            '    BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)("SELECT * FROM dbo.advtf_get_billing_rate('" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode & "', " & _
                                            '                                                                                                                  "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.JobNumber & ", " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.ComponentNumber & ", NULL)").FirstOrDefault

                                            'Catch ex As Exception
                                            '    BillingRate = Nothing
                                            'End Try

                                            'If BillingRate IsNot Nothing AndAlso BillingRate.NOBILL_FLAG.GetValueOrDefault(0) = 0 Then

                                            RevenueShareAmount += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * BillRate

                                            'End If

                                        End If

                                    End If

                                End If

                            Next

                            For Each EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In ETFOfficeDetailJobComponentAlternateEmployeesList.Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                    DataRow(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                    TotalHoursForDetail += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours
                                    TotalHoursForClient += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                    BillRate = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.BillRate

                                    UtilizationAmount += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours * BillRate

                                    If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                        TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                    End If

                                    If TotalClientHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                                        TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours

                                    End If

                                    If EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.AlternateEmployeeOfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                        If ETFOfficeDetailJobComponent.IsNonBillable = False AndAlso DbContext.Database.SqlQuery(Of Boolean)("EXEC dbo.advsp_billing_rate_is_non_billable NULL, " &
                                                                                                                                                              "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " &
                                                                                                                                                              ETFOfficeDetailJobComponent.JobNumber & ", " &
                                                                                                                                                              ETFOfficeDetailJobComponent.ComponentNumber).FirstOrDefault = False Then

                                            'Try

                                            '    BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)("SELECT * FROM dbo.advtf_get_billing_rate(NULL, " & _
                                            '                                                                                                                  "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.JobNumber & ", " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.ComponentNumber & ", NULL)").FirstOrDefault

                                            'Catch ex As Exception
                                            '    BillingRate = Nothing
                                            'End Try

                                            'If BillingRate IsNot Nothing AndAlso BillingRate.NOBILL_FLAG.GetValueOrDefault(0) = 0 Then

                                            RevenueShareAmount += EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours * BillRate

                                            'End If

                                        End If

                                    End If

                                End If

                            Next

                            DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-RevenueShareAmount)
                            DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency((ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount))
                            DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(UtilizationAmount)
                            DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForDetail, 2)

                            TotalClientRevenueAmount += ETFOfficeDetailJobComponent.RevenueAmount
                            TotalClientRevenueShareAmount += RevenueShareAmount
                            TotalClientWithRevenueShareAmount += (ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount)
                            TotalClientUtilizationAmount += UtilizationAmount

                            TotalRevenueAmount += ETFOfficeDetailJobComponent.RevenueAmount
                            TotalRevenueShareAmount += RevenueShareAmount
                            TotalWithRevenueShareAmount += (ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount)
                            TotalUtilizationAmount += UtilizationAmount

                            ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(TotalClientRevenueAmount)
                            ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalClientRevenueShareAmount)
                            ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientWithRevenueShareAmount)
                            ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                            ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                        Next

                        If ClientDataRow IsNot Nothing Then

                            For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                            Next

                        End If

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = TotalRevenueAmount
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalRevenueShareAmount)
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalWithRevenueShareAmount)
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalUtilizationAmount)

                        TotalHoursForHeader = 0

                        For Each TotalEmployeeHours In TotalHoursForEmployeeDictionary

                            HeaderDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)
                            TotalHoursForHeader += TotalEmployeeHours.Value

                        Next

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForHeader, 2)

                        PrimaryOfficeForecastRowsBuilt = True

                    End If

                End If

            Catch ex As Exception
                PrimaryOfficeForecastRowsBuilt = False
            Finally
                BuildPrimaryOfficeForecastRows = PrimaryOfficeForecastRowsBuilt
            End Try

        End Function
        Public Function BuildSecondaryOfficeForecastRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                         ByRef DataTable As System.Data.DataTable, ByVal ShowJobAndJobComponentDescription As Boolean, ByVal ShowClientDivisionProductCodesOnly As Boolean,
                                                         ByVal OfficeCode As String, ByVal OfficeDescription As String,
                                                         ByVal ETFOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent),
                                                         ByVal ETFOfficeDetailIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory),
                                                         ByVal ETFOfficeDetailIndirectCategoryAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee),
                                                         ByVal ETFOfficeDetailIndirectCategoryEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryEmployee),
                                                         ByVal ETFOfficeDetailJobComponentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentAlternateEmployee),
                                                         ByVal ETFOfficeDetailJobComponentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentEmployee)) As Boolean

            'objects
            Dim SecondaryOfficeForecastRowsBuilt As Boolean = False
            Dim HeaderDataRow As System.Data.DataRow = Nothing
            Dim ClientDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim UtilizationAmount As Decimal = 0
            Dim RevenueShareAmount As Decimal = 0
            Dim BillRate As Decimal = 0
            Dim TotalRevenueAmount As Decimal = 0
            Dim TotalRevenueShareAmount As Decimal = 0
            Dim TotalWithRevenueShareAmount As Decimal = 0
            Dim TotalUtilizationAmount As Decimal = 0
            Dim TotalHoursForDetail As Decimal = 0
            Dim TotalHoursForHeader As Decimal = 0
            Dim TotalHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim PreviousClientCode As String = ""
            Dim TotalClientRevenueAmount As Decimal = 0
            Dim TotalClientRevenueShareAmount As Decimal = 0
            Dim TotalClientWithRevenueShareAmount As Decimal = 0
            Dim TotalClientUtilizationAmount As Decimal = 0
            Dim TotalHoursForClient As Decimal = 0
            Dim TotalClientHoursForEmployeeDictionary As Generic.Dictionary(Of String, Decimal) = Nothing
            Dim OtherEmployeeTimeForecastOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent) = Nothing
            Dim PreviousJobAndJobComponentDescription As String = ""
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim ETFOfficeDetailJobComponent As AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent = Nothing
            Dim JobAndJobComponentDescription As String = ""
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim OtherEmployeeTimeForecastOfficeDetailEmployees As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) = Nothing

            Try

                If DbContext IsNot Nothing AndAlso EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso DataTable IsNot Nothing Then

                    EmployeeCodes = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(Entity) Entity.Employee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.EmployeeCode).ToList

                    OtherEmployeeTimeForecastOfficeDetailJobComponentsList = New Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent)

                    For Each OtherEmployeeTimeForecastOfficeDetail In (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode)
                                                                       Where Entity.EmployeeTimeForecastID <> EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID
                                                                       Group By Key = New With {Entity.EmployeeTimeForecastID, Entity.OfficeCode, Entity.AssignedToEmployeeCode} Into Group).ToList.Select(Function(GroupEntity) _
                                                                       New With {.[EmployeeTimeForecastID] = GroupEntity.Key.EmployeeTimeForecastID,
                                                                                 .[OfficeCode] = GroupEntity.Key.OfficeCode,
                                                                                 .[AssignedToEmployeeCode] = GroupEntity.Key.AssignedToEmployeeCode,
                                                                                 .[RevisionNumber] = GroupEntity.Group.Max(Function(OfficeDetail) OfficeDetail.RevisionNumber)}).Select(Function(ETFDtlRev) AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastIDAndOfficeCodeAndAssignedToEmployeeCodeAndRevisionNumber(DbContext, ETFDtlRev.EmployeeTimeForecastID, ETFDtlRev.OfficeCode, ETFDtlRev.AssignedToEmployeeCode, ETFDtlRev.RevisionNumber)).ToList

                        For Each ETFOfficeDetailJobComponent In AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, OtherEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, OtherEmployeeTimeForecastOfficeDetail.ID).Where(Function(Entity) Entity.OfficeCode = OfficeCode).ToList

                            For Each OtherETFEmployee In AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentEmployeeView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, OtherEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, OtherEmployeeTimeForecastOfficeDetail.ID).Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                If EmployeeCodes.Contains(OtherETFEmployee.EmployeeCode) AndAlso OtherETFEmployee.Hours > 0 Then

                                    OtherEmployeeTimeForecastOfficeDetailJobComponentsList.Add(ETFOfficeDetailJobComponent)
                                    Exit For

                                End If

                            Next

                        Next

                    Next

                    If OtherEmployeeTimeForecastOfficeDetailJobComponentsList.Count > 0 Then

                        TotalHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                        For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                            TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                        Next

                        HeaderDataRow = DataTable.Rows.Add

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = "&other" & OfficeCode
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = "Other - " & OfficeDescription
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = 0
                        HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = 0

                        For Each ETFOfficeDetailJobComponent In OtherEmployeeTimeForecastOfficeDetailJobComponentsList.OrderBy(Function(Entity) Entity.ClientDescription).ThenBy(Function(Entity) Entity.JobDescription)

                            If PreviousClientCode <> ETFOfficeDetailJobComponent.ClientCode Then

                                If ClientDataRow IsNot Nothing Then

                                    For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                        ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                                    Next

                                End If

                                PreviousClientCode = ETFOfficeDetailJobComponent.ClientCode

                                TotalClientRevenueAmount = 0
                                TotalClientRevenueShareAmount = 0
                                TotalClientWithRevenueShareAmount = 0
                                TotalClientUtilizationAmount = 0
                                TotalHoursForClient = 0

                                ClientDataRow = DataTable.Rows.Add

                                ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = 0
                                ClientDataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                                ClientDataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "&other" & OfficeCode
                                ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = "&other" & OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                                ClientDataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                                If ShowClientDivisionProductCodesOnly Then

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode

                                Else

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription

                                End If

                                ClientDataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ""
                                ClientDataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ""
                                ClientDataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ""

                                If OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(TotalClientRevenueAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalClientRevenueShareAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientWithRevenueShareAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)

                                Else

                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(0)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                    ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)

                                End If

                                ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                                TotalClientHoursForEmployeeDictionary = New Generic.Dictionary(Of String, Decimal)

                                For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(Entity) Entity.EmployeeCode).ToList

                                    TotalClientHoursForEmployeeDictionary(EmployeeCode) = 0

                                Next

                                For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(Entity) Entity.ID).ToList

                                    TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = 0

                                Next

                            End If

                            If ShowJobAndJobComponentDescription Then

                                JobAndJobComponentDescription = ETFOfficeDetailJobComponent.JobComponentDescription

                            Else

                                JobAndJobComponentDescription = ETFOfficeDetailJobComponent.JobComponent

                            End If

                            If PreviousJobAndJobComponentDescription <> JobAndJobComponentDescription Then

                                DataRow = DataTable.Rows.Add

                                DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID
                                DataRow(StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = 0
                                DataRow(StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "&other" & OfficeCode & ETFOfficeDetailJobComponent.ClientCode
                                DataRow(StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = ETFOfficeDetailJobComponent.JobComponent
                                DataRow(StaticEmployeeTimeForecastColumn.OfficeName.ToString) = ""

                                If ShowClientDivisionProductCodesOnly Then

                                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientCode
                                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionCode
                                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductCode

                                Else

                                    DataRow(StaticEmployeeTimeForecastColumn.ClientName.ToString) = ETFOfficeDetailJobComponent.ClientDescription
                                    DataRow(StaticEmployeeTimeForecastColumn.DivisionName.ToString) = ETFOfficeDetailJobComponent.DivisionDescription
                                    DataRow(StaticEmployeeTimeForecastColumn.ProductDescription.ToString) = ETFOfficeDetailJobComponent.ProductDescription

                                End If

                                If ShowJobAndJobComponentDescription Then

                                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponentDescription

                                Else

                                    DataRow(StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString) = ETFOfficeDetailJobComponent.JobComponent

                                End If

                                If OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = ETFOfficeDetailJobComponent.RevenueAmount

                                Else

                                    DataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0

                                End If

                                UtilizationAmount = 0
                                RevenueShareAmount = 0
                                TotalHoursForDetail = 0

                                If ShowJobAndJobComponentDescription Then

                                    PreviousJobAndJobComponentDescription = ETFOfficeDetailJobComponent.JobComponentDescription

                                Else

                                    PreviousJobAndJobComponentDescription = ETFOfficeDetailJobComponent.JobComponent

                                End If

                            End If

                            For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentEmployeeView.Load(DbContext).Where(Function(Entity) Entity.EmployeeTimeForecastOfficeDetailJobComponentID = ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                                If DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                    DataRow(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    TotalHoursForDetail += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours
                                    TotalHoursForClient += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    BillRate = EmployeeTimeForecastOfficeDetailJobComponentEmployee.BillRate

                                    If EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeOfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                        UtilizationAmount += (EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * BillRate)

                                    End If

                                    If TotalHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                        TotalHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    End If

                                    If TotalClientHoursForEmployeeDictionary.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) Then

                                        TotalClientHoursForEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode) += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                    End If

                                    If OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeOfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                        If ETFOfficeDetailJobComponent.IsNonBillable = False AndAlso DbContext.Database.SqlQuery(Of Boolean)("EXEC dbo.advsp_billing_rate_is_non_billable '" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode & "', " &
                                                                                                                                                              "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " &
                                                                                                                                                              "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " &
                                                                                                                                                              ETFOfficeDetailJobComponent.JobNumber & ", " &
                                                                                                                                                              ETFOfficeDetailJobComponent.ComponentNumber).FirstOrDefault = False Then

                                            'Try

                                            '    BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)("SELECT * FROM dbo.advtf_get_billing_rate('" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeCode & "', " & _
                                            '                                                                                                                  "NULL, NULL, '" & ETFOfficeDetailJobComponent.ClientCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.DivisionCode & "', " & _
                                            '                                                                                                                  "'" & ETFOfficeDetailJobComponent.ProductCode & "', NULL, NULL , " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.JobNumber & ", " & _
                                            '                                                                                                                  ETFOfficeDetailJobComponent.ComponentNumber & ", NULL)").FirstOrDefault

                                            'Catch ex As Exception
                                            '    BillingRate = Nothing
                                            'End Try

                                            'If BillingRate IsNot Nothing AndAlso BillingRate.NOBILL_FLAG.GetValueOrDefault(0) = 0 Then

                                            RevenueShareAmount += EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours * BillRate

                                            'End If

                                        End If

                                    End If

                                End If

                            Next

                            If OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-RevenueShareAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency((ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount))
                                DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(UtilizationAmount)

                                TotalClientRevenueAmount += ETFOfficeDetailJobComponent.RevenueAmount
                                TotalClientRevenueShareAmount += RevenueShareAmount
                                TotalClientWithRevenueShareAmount += (ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount)

                                TotalRevenueAmount += ETFOfficeDetailJobComponent.RevenueAmount
                                TotalRevenueShareAmount += RevenueShareAmount
                                TotalWithRevenueShareAmount += (ETFOfficeDetailJobComponent.RevenueAmount - RevenueShareAmount)

                            Else

                                DataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(UtilizationAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(UtilizationAmount)
                                DataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(UtilizationAmount)

                            End If

                            DataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForDetail, 2)

                            TotalClientUtilizationAmount += UtilizationAmount

                            TotalUtilizationAmount += UtilizationAmount

                            If OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(TotalClientRevenueAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalClientRevenueShareAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientWithRevenueShareAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)

                            Else

                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(0)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)
                                ClientDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalClientUtilizationAmount)

                            End If

                            ClientDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForClient, 2)

                        Next

                        If ClientDataRow IsNot Nothing Then

                            For Each TotalEmployeeHours In TotalClientHoursForEmployeeDictionary

                                ClientDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)

                            Next

                        End If

                        If OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode Then

                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = TotalRevenueAmount
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(-TotalRevenueShareAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalWithRevenueShareAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalUtilizationAmount)

                        Else

                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = 0
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString) = FormatCurrency(TotalUtilizationAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString) = FormatCurrency(TotalUtilizationAmount)
                            HeaderDataRow(StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString) = FormatCurrency(TotalUtilizationAmount)

                        End If

                        TotalHoursForHeader = 0

                        For Each TotalEmployeeHours In TotalHoursForEmployeeDictionary

                            HeaderDataRow(TotalEmployeeHours.Key) = FormatNumber(TotalEmployeeHours.Value, 2)
                            TotalHoursForHeader += TotalEmployeeHours.Value

                        Next

                        HeaderDataRow(StaticEmployeeTimeForecastColumn.TotalHours.ToString) = FormatNumber(TotalHoursForHeader, 2)

                        SecondaryOfficeForecastRowsBuilt = True

                    End If

                End If

            Catch ex As Exception
                SecondaryOfficeForecastRowsBuilt = False
            Finally
                BuildSecondaryOfficeForecastRows = SecondaryOfficeForecastRowsBuilt
            End Try

        End Function
        Public Function BuildDataTableStructure(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim StructureBuilt As Boolean = False

            Try

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    DataTable = New System.Data.DataTable

                    For Each StaticColumnName In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StaticEmployeeTimeForecastColumn), False)

                        DataTable.Columns.Add(StaticColumnName)

                    Next

                    For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(Entity) Entity.Employee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.EmployeeCode).ToList

                        DataTable.Columns.Add(EmployeeCode)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(Entity) Entity.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.ID).ToList

                        DataTable.Columns.Add(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                    Next

                    For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(Entity) Entity.Employee.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.EmployeeCode).ToList

                        DataTable.Columns.Add(EmployeeCode)

                    Next

                    For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(Entity) Entity.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.ID).ToList

                        DataTable.Columns.Add(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                    Next

                    StructureBuilt = True

                End If

            Catch ex As Exception
                StructureBuilt = False
            Finally
                BuildDataTableStructure = StructureBuilt
            End Try

        End Function
        Public Function BuildEmployeeTimeForecastOfficeDetailsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim ShowJobAndJobComponentDescription As Boolean = True
            Dim ShowClientDivisionProductCodesOnly As Boolean = False
            Dim TotalCostIncludesAllHours As Boolean = True
            Dim ETFOfficeDetailJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponent) = Nothing
            Dim ETFOfficeDetailIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategory) = Nothing
            Dim ETFOfficeDetailIndirectCategoryAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee) = Nothing
            Dim ETFOfficeDetailIndirectCategoryEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailIndirectCategoryEmployee) = Nothing
            Dim ETFOfficeDetailJobComponentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentAlternateEmployee) = Nothing
            Dim ETFOfficeDetailJobComponentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.ETFOfficeDetailJobComponentEmployee) = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    SettingsList = LoadSettings(DataContext)

                    ETFOfficeDetailJobComponentsList = AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList
                    ETFOfficeDetailJobComponentAlternateEmployeesList = AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentAlternateEmployeeView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList
                    ETFOfficeDetailJobComponentEmployeesList = AdvantageFramework.Database.Procedures.ETFOfficeDetailJobComponentEmployeeView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList

                    ETFOfficeDetailIndirectCategoriesList = AdvantageFramework.Database.Procedures.ETFOfficeDetailIndirectCategoryView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList
                    ETFOfficeDetailIndirectCategoryAlternateEmployeesList = AdvantageFramework.Database.Procedures.ETFOfficeDetailIndirectCategoryAlternateEmployeeView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList
                    ETFOfficeDetailIndirectCategoryEmployeesList = AdvantageFramework.Database.Procedures.ETFOfficeDetailIndirectCategoryEmployeeView.LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID).ToList

                    ShowJobAndJobComponentDescription = LoadShowJobAndJobComponentDescriptionSetting(DataContext, SettingsList)
                    ShowClientDivisionProductCodesOnly = LoadShowClientDivisionProductCodesOnlySetting(DataContext, SettingsList)
                    'TotalCostIncludesAllHours = LoadTotalCostIncludesAllHoursSetting(DataContext, SettingsList)

                    BuildDataTableStructure(EmployeeTimeForecastOfficeDetail, DataTable)

                    BuildPrimaryOfficeForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, ShowJobAndJobComponentDescription, ShowClientDivisionProductCodesOnly,
                                                   ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList,
                                                   ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                    'If EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Any Then

                    '    BuildSecondaryOfficeForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, ShowJobAndJobComponentDescription, _
                    '                                     ShowClientDivisionProductCodesOnly, EmployeeTimeForecastOfficeDetail.Office.Code, EmployeeTimeForecastOfficeDetail.Office.Name, _
                    '                                     ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList, _
                    '                                     ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                    'End If

                    BuildOtherOfficeForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, ShowJobAndJobComponentDescription, ShowClientDivisionProductCodesOnly,
                                                 ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList,
                                                 ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                    'If EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Any Then

                    '    For Each Office In (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                    '                        Where Entity.Code <> EmployeeTimeForecastOfficeDetail.OfficeCode
                    '                        Select Entity.Code,
                    '                               Entity.Name).ToList

                    '        BuildSecondaryOfficeForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, ShowJobAndJobComponentDescription, ShowClientDivisionProductCodesOnly, Office.Code, Office.Name,
                    '                                         ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList,
                    '                                         ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                    '    Next

                    'End If

                    BuildIndirectCategoriesForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable,
                                                        ETFOfficeDetailJobComponentsList, ETFOfficeDetailIndirectCategoriesList, ETFOfficeDetailIndirectCategoryAlternateEmployeesList,
                                                        ETFOfficeDetailIndirectCategoryEmployeesList, ETFOfficeDetailJobComponentAlternateEmployeesList, ETFOfficeDetailJobComponentEmployeesList)

                    If DataTable.Rows.Count > 0 Then

                        BuildGrandTotalForecastRows(DbContext, EmployeeTimeForecastOfficeDetail, DataTable, TotalCostIncludesAllHours)

                    End If

                End If

            End If

            BuildEmployeeTimeForecastOfficeDetailsDataTable = DataTable

        End Function
        Public Function BuildEmployeeTimeForecastOfficeDetailsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = BuildEmployeeTimeForecastOfficeDetailsDataTable(DbContext, DataContext, LoadEmployeeTimeForecastOfficeDetailWithOptions(DbContext, EmployeeTimeForecastOfficeDetailID))

            BuildEmployeeTimeForecastOfficeDetailsDataTable = DataTable

        End Function
        Public Function LoadEmployeeTimeForecastOfficeDetailWithOptions(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Try

                EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                                                                Include("EmployeeTimeForecastOfficeDetailEmployees.Employee").
                                                                                                                                                                Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                                                                Include("EmployeeTimeForecast").
                                                                                                                                                                Include("Office")
                                                    Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                    Select Entity).SingleOrDefault

            Catch ex As Exception
                EmployeeTimeForecastOfficeDetail = Nothing
            End Try

            LoadEmployeeTimeForecastOfficeDetailWithOptions = EmployeeTimeForecastOfficeDetail

        End Function

        Public Function CopyEmployeeTimeForecastValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConnectionString As String, ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal CopyFromEmployeeTimeForecastOfficeDetailID As Integer,
                                                       ByVal UpdateEmployeeRates As Boolean, ByVal UpdateRevenueAmounts As Boolean, ByVal ExcludeHoursEntered As Boolean) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim CopyFromEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Try

                If DbContext IsNot Nothing Then

                    EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID)
                    CopyFromEmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, CopyFromEmployeeTimeForecastOfficeDetailID)

                    Copied = CopyEmployeeTimeForecastValues(DbContext, ConnectionString, EmployeeTimeForecastOfficeDetail, CopyFromEmployeeTimeForecastOfficeDetail,
                                                            UpdateEmployeeRates, UpdateRevenueAmounts, ExcludeHoursEntered)

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyEmployeeTimeForecastValues = Copied
            End Try

        End Function
        Public Function CopyEmployeeTimeForecastValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConnectionString As String,
                                                       ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                       ByVal CopyFromEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                       ByVal UpdateEmployeeRates As Boolean, ByVal UpdateRevenueAmounts As Boolean, ByVal ExcludeHoursEntered As Boolean) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobComponentEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
            Dim JobComponentAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
            Dim IndirectCategoryEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
            Dim IndirectCategoryAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
            Dim OldJobComponentEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
            Dim OldJobComponentAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
            Dim OldIndirectCategoryEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
            Dim OldIndirectCategoryAlternateEmployeeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso CopyFromEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        For Each JobComponentDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents

                            InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, EmployeeTimeForecastOfficeDetail,
                                                                                 JobComponentDetail.JobComponent, UpdateRevenueAmounts, JobComponentDetail.RevenueAmount)

                        Next

                        For Each IndirectCategoryDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories

                            InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail,
                                                                                     IndirectCategoryDetail.IndirectCategory)

                        Next

                        For Each EmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                            InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, EmployeeTimeForecastOfficeDetail,
                                                                             EmployeeDetail.Employee, UpdateEmployeeRates, EmployeeDetail.BillRate,
                                                                             UpdateEmployeeRates, EmployeeDetail.CostRate)

                        Next

                        For Each AlternateEmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                            InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail,
                                                                                      AlternateEmployeeDetail.EmployeeTitle, AlternateEmployeeDetail.Description,
                                                                                      AlternateEmployeeDetail.Office, UpdateEmployeeRates, AlternateEmployeeDetail.BillRate,
                                                                                      UpdateEmployeeRates, AlternateEmployeeDetail.CostRate)

                        Next

                        If ExcludeHoursEntered = False Then

                            For Each OldJobComponentEmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees

                                Try

                                    JobComponentEmployeeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.ID)
                                                                  Where Entity.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode AndAlso
                                                                        Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber AndAlso
                                                                        Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber = OldJobComponentEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber
                                                                  Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    JobComponentEmployeeDetail = Nothing
                                End Try

                                If JobComponentEmployeeDetail IsNot Nothing Then

                                    JobComponentEmployeeDetail.Hours = OldJobComponentEmployeeDetail.Hours

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee.Update(DbContext, JobComponentEmployeeDetail)

                                End If

                            Next

                            For Each OldJobComponentAlternateEmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees

                                Try

                                    JobComponentAlternateEmployeeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.ID)
                                                                           Where Entity.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description AndAlso
                                                                                 Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobNumber AndAlso
                                                                                 Entity.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber = OldJobComponentAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber
                                                                           Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    JobComponentAlternateEmployeeDetail = Nothing
                                End Try

                                If JobComponentAlternateEmployeeDetail IsNot Nothing Then

                                    JobComponentAlternateEmployeeDetail.Hours = OldJobComponentAlternateEmployeeDetail.Hours

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Update(DbContext, JobComponentAlternateEmployeeDetail)

                                End If

                            Next

                            For Each OldIndirectCategoryEmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees

                                Try

                                    IndirectCategoryEmployeeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.ID)
                                                                      Where Entity.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = OldIndirectCategoryEmployeeDetail.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode AndAlso
                                                                            Entity.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode = OldIndirectCategoryEmployeeDetail.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode
                                                                      Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    IndirectCategoryEmployeeDetail = Nothing
                                End Try

                                If IndirectCategoryEmployeeDetail IsNot Nothing Then

                                    IndirectCategoryEmployeeDetail.Hours = OldIndirectCategoryEmployeeDetail.Hours

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Update(DbContext, IndirectCategoryEmployeeDetail)

                                End If

                            Next

                            For Each OldIndirectCategoryAlternateEmployeeDetail In CopyFromEmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees

                                Try

                                    IndirectCategoryAlternateEmployeeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.ID)
                                                                               Where Entity.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = OldIndirectCategoryAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployee.Description AndAlso
                                                                                     Entity.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode = OldIndirectCategoryAlternateEmployeeDetail.EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode
                                                                               Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    IndirectCategoryAlternateEmployeeDetail = Nothing
                                End Try

                                If IndirectCategoryAlternateEmployeeDetail IsNot Nothing Then

                                    IndirectCategoryAlternateEmployeeDetail.Hours = OldIndirectCategoryAlternateEmployeeDetail.Hours

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Update(DbContext, IndirectCategoryAlternateEmployeeDetail)

                                End If

                            Next

                        End If

                        Copied = True

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyEmployeeTimeForecastValues = Copied
            End Try

        End Function

#End Region

#Region "  Office Detail --> Employee "

        Public Function LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim AvailableEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim CurrentEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If DbContext IsNot Nothing Then

                CurrentEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList

                AvailableEmployeesList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                          Select Entity).ToList

            End If

            If AvailableEmployeesList IsNot Nothing Then

                If CurrentEmployeesList IsNot Nothing Then

                    For Each CurrentEmployee In CurrentEmployeesList

                        Try

                            Employee = AvailableEmployeesList.SingleOrDefault(Function(Entity) Entity.Code = CurrentEmployee.Code)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        If Employee IsNot Nothing Then

                            AvailableEmployeesList.Remove(Employee)

                        End If

                    Next

                End If

            End If

            LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetail = AvailableEmployeesList

        End Function
        Public Function LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetailByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal OfficeCode As String) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim AvailableEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim CurrentEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If DbContext IsNot Nothing Then

                CurrentEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList

                AvailableEmployeesList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).Include("Office").Include("DepartmentTeam")
                                          Where Entity.OfficeCode = OfficeCode
                                          Select Entity).ToList

            End If

            If AvailableEmployeesList IsNot Nothing Then

                If CurrentEmployeesList IsNot Nothing Then

                    For Each CurrentEmployee In CurrentEmployeesList

                        Try

                            Employee = AvailableEmployeesList.SingleOrDefault(Function(Entity) Entity.Code = CurrentEmployee.Code)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        If Employee IsNot Nothing Then

                            AvailableEmployeesList.Remove(Employee)

                        End If

                    Next

                End If

            End If

            LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetailByOfficeCode = AvailableEmployeesList

        End Function

        Public Function InsertEmployeeInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                         ByVal ConnectionString As String, ByVal EmployeeTimeForecastOfficeDetailID As Integer,
                                                                         ByVal EmployeeCode As String, ByVal LoadBillingRate As Boolean,
                                                                         ByVal BillingRate As Decimal, ByVal LoadCostRate As Boolean,
                                                                         ByVal CostRate As Decimal) As Boolean

            'objects
            Dim EmployeeInserted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    EmployeeInserted = InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext,
                                                                                        ConnectionString,
                                                                                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID),
                                                                                        AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode),
                                                                                        LoadBillingRate, BillingRate,
                                                                                        LoadCostRate, CostRate)

                End If

            Catch ex As Exception
                EmployeeInserted = False
            Finally
                InsertEmployeeInEmployeeTimeForecastOfficeDetail = EmployeeInserted
            End Try

        End Function
        Public Function InsertEmployeeInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                         ByVal ConnectionString As String,
                                                                         ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                         ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal LoadBillingRate As Boolean,
                                                                         ByVal BillingRate As Decimal, ByVal LoadCostRate As Boolean,
                                                                         ByVal CostRate As Decimal, ByVal UseEmployeeTitleBillingRate As Boolean) As Boolean

            'objects
            Dim EmployeeInserted As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim FoundEmployeeTitleBillingRate As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If Employee IsNot Nothing Then

                            If LoadBillingRate Then

                                If UseEmployeeTitleBillingRate Then

                                    BillingRate = AdvantageFramework.BillingSystem.LoadBillingRate(DbContext, FoundEmployeeTitleBillingRate,
                                                                                                   AdvantageFramework.Database.Procedures.BillingRateLevel.LoadEmployeeTitleOnlyBillingRateLevel(DbContext),
                                                                                                   Nothing, Nothing, Nothing,
                                                                                                   Nothing, Nothing, Nothing, Nothing,
                                                                                                   Nothing, Nothing, Nothing, Nothing,
                                                                                                   Nothing, Nothing, Employee.EmployeeTitleID)

                                    If FoundEmployeeTitleBillingRate = False Then

                                        BillingRate = Employee.BillRate.GetValueOrDefault(0)

                                    End If

                                Else

                                    BillingRate = Employee.BillRate.GetValueOrDefault(0)

                                End If

                            End If

                            If LoadCostRate Then

                                CostRate = Employee.CostRate.GetValueOrDefault(0)

                            End If

                            If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.Insert(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID,
                                                                                                                      EmployeeTimeForecastOfficeDetail.ID, Employee.Code,
                                                                                                                      BillingRate, CostRate, EmployeeTimeForecastOfficeDetailEmployee) Then

                                EmployeeInserted = SyncEmployeeOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                EmployeeInserted = False
            Finally
                InsertEmployeeInEmployeeTimeForecastOfficeDetail = EmployeeInserted
            End Try

        End Function
        Public Function InsertEmployeeInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                         ByVal ConnectionString As String,
                                                                         ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                         ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal LoadBillingRate As Boolean,
                                                                         ByVal BillingRate As Decimal, ByVal LoadCostRate As Boolean,
                                                                         ByVal CostRate As Decimal) As Boolean

            'objects
            Dim EmployeeInserted As Boolean = False
            Dim UseEmployeeTitleBillingRate As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If Employee IsNot Nothing Then

                            If LoadBillingRate Then

                                Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, DbContext.UserCode)

                                    UseEmployeeTitleBillingRate = LoadUseEmployeeTitleBillingRateSetting(DataContext)

                                End Using

                            End If

                            EmployeeInserted = InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, EmployeeTimeForecastOfficeDetail, Employee, LoadBillingRate, BillingRate, LoadCostRate, CostRate, UseEmployeeTitleBillingRate)

                        End If

                    End If

                End If

            Catch ex As Exception
                EmployeeInserted = False
            Finally
                InsertEmployeeInEmployeeTimeForecastOfficeDetail = EmployeeInserted
            End Try

        End Function

        Public Function SyncEmployeeOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                       ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim EmployeeSyncd As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailJobComponentID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLJC_EMP([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLJC_ID], [ETF_OFFDTLEMP_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, ETF_OFFDTLJC_ID, {2}, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLJC " &
                                                                            "WHERE ETF_OFFDTLJC_ID NOT IN (SELECT ETF_OFFDTLJC_ID FROM dbo.ETF_OFFDTLJC_EMP WHERE ETF_OFFDTLEMP_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailEmployee.ID, EmployeeTimeForecastOfficeDetailEmployee.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLCAT_EMP([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLCAT_ID], [ETF_OFFDTLEMP_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, ETF_OFFDTLCAT_ID, {2}, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLCAT " &
                                                                            "WHERE ETF_OFFDTLCAT_ID NOT IN (SELECT ETF_OFFDTLCAT_ID FROM dbo.ETF_OFFDTLCAT_EMP WHERE ETF_OFFDTLEMP_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailEmployee.ID, EmployeeTimeForecastOfficeDetailEmployee.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        EmployeeSyncd = True

                    End If

                End If

            Catch ex As Exception
                EmployeeSyncd = False
            Finally
                SyncEmployeeOnEmployeeTimeForecastOfficeDetail = EmployeeSyncd
            End Try

        End Function

        Public Function DeleteEmployeeFromEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim EmployeeDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee.DeleteFromEmployeeTimeForecastByEmployee(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.ID)

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.DeleteFromEmployeeTimeForecastByEmployee(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.ID)

                            EmployeeDeleted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.DeleteByEmployeeTimeForecastOfficeDetailEmployeeID(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee.ID)

                        End If

                    End If

                End If

            Catch ex As Exception
                EmployeeDeleted = False
            Finally
                DeleteEmployeeFromEmployeeTimeForecastOfficeDetail = EmployeeDeleted
            End Try

        End Function

#End Region

#Region "  Office Detail --> Alternate Employee "

        Public Function InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                  ByVal EmployeeTimeForecastOfficeDetailID As Integer,
                                                                                  ByVal EmployeeTitleID As Integer, ByVal Description As String,
                                                                                  ByVal OfficeCode As String, ByVal LoadBillingRate As Boolean,
                                                                                  ByVal BillingRate As Decimal, ByVal LoadCostRate As Boolean,
                                                                                  ByVal CostRate As Decimal) As Boolean

            'objects
            Dim AlternateEmployeeInserted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    AlternateEmployeeInserted = InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(DbContext,
                                                                                                          AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID),
                                                                                                          AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, EmployeeTitleID),
                                                                                                          Description,
                                                                                                          AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OfficeCode),
                                                                                                          LoadBillingRate, BillingRate,
                                                                                                          LoadCostRate, CostRate)

                End If

            Catch ex As Exception
                AlternateEmployeeInserted = False
            Finally
                InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail = AlternateEmployeeInserted
            End Try

        End Function
        Public Function InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                  ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                                  ByVal EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle,
                                                                                  ByVal Description As String,
                                                                                  ByVal Office As AdvantageFramework.Database.Entities.Office,
                                                                                  ByVal LoadBillingRate As Boolean, ByVal BillingRate As Decimal,
                                                                                  ByVal LoadCostRate As Boolean, ByVal CostRate As Decimal) As Boolean

            'objects
            Dim AlternateEmployeeInserted As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If EmployeeTitle IsNot Nothing Then

                            If Office IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.Insert(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID,
                                                                                                                                       EmployeeTimeForecastOfficeDetail.ID, EmployeeTitle.ID,
                                                                                                                                       Description, Office.Code, BillingRate, CostRate,
                                                                                                                                       EmployeeTimeForecastOfficeDetailAlternateEmployee) Then

                                    AlternateEmployeeInserted = SyncAlternateEmployeeOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee)

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                AlternateEmployeeInserted = False
            Finally
                InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail = AlternateEmployeeInserted
            End Try

        End Function

        Public Function SyncAlternateEmployeeOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                                ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim AlternateEmployeeSyncd As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailJobComponentID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLJC_AE([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLJC_ID], [ETF_OFFDTLAE_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, ETF_OFFDTLJC_ID, {2}, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLJC " &
                                                                            "WHERE ETF_OFFDTLJC_ID NOT IN (SELECT ETF_OFFDTLJC_ID FROM dbo.ETF_OFFDTLJC_AE WHERE ETF_OFFDTLAE_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailAlternateEmployee.ID, EmployeeTimeForecastOfficeDetailAlternateEmployee.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLCAT_AE([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLCAT_ID], [ETF_OFFDTLAE_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, ETF_OFFDTLCAT_ID, {2}, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLCAT " &
                                                                            "WHERE ETF_OFFDTLCAT_ID NOT IN (SELECT ETF_OFFDTLCAT_ID FROM dbo.ETF_OFFDTLCAT_AE WHERE ETF_OFFDTLAE_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailAlternateEmployee.ID, EmployeeTimeForecastOfficeDetailAlternateEmployee.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        AlternateEmployeeSyncd = True

                    End If

                End If

            Catch ex As Exception
                AlternateEmployeeSyncd = False
            Finally
                SyncAlternateEmployeeOnEmployeeTimeForecastOfficeDetail = AlternateEmployeeSyncd
            End Try

        End Function

        Public Function DeleteAlternateEmployeeFromEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                    ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                                    ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim AlternateEmployeeDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.DeleteFromEmployeeTimeForecastByAlternateEmployee(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.DeleteFromEmployeeTimeForecastByAlternateEmployee(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)

                            AlternateEmployeeDeleted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.DeleteByEmployeeTimeForecastOfficeDetailAlternateEmployeeID(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)

                        End If

                    End If

                End If

            Catch ex As Exception
                AlternateEmployeeDeleted = False
            Finally
                DeleteAlternateEmployeeFromEmployeeTimeForecastOfficeDetail = AlternateEmployeeDeleted
            End Try

        End Function

#End Region

#Region "  Office Detail --> Job Component "

        Public Function LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                                     ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ShowJobsForAllOffices As Boolean, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                                     ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            'objects
            Dim AvailableJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim CurrentJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim CurrentJobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If DbContext IsNot Nothing Then

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    CurrentJobComponentsList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.Select(Function(EmployeeTimeForecastOfficeDetailJobComponent) EmployeeTimeForecastOfficeDetailJobComponent.JobComponent).ToList

                    If ShowJobsForAllOffices Then

                        AvailableJobComponentsList = AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode, True).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").ToList

                    Else

                        AvailableJobComponentsList = AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode, True).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").Where(Function(Entity) Entity.Job.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).ToList

                    End If

                    If ClientCode IsNot Nothing AndAlso ClientCode <> "" Then

                        AvailableJobComponentsList = (From Entity In AvailableJobComponentsList
                                                      Where Entity.Job.ClientCode = ClientCode
                                                      Select Entity).ToList

                    End If

                    If DivisionCode IsNot Nothing AndAlso DivisionCode <> "" Then

                        AvailableJobComponentsList = (From Entity In AvailableJobComponentsList
                                                      Where Entity.Job.DivisionCode = DivisionCode
                                                      Select Entity).ToList

                    End If

                    If ProductCode IsNot Nothing AndAlso ProductCode <> "" Then

                        AvailableJobComponentsList = (From Entity In AvailableJobComponentsList
                                                      Where Entity.Job.ProductCode = ProductCode
                                                      Select Entity).ToList

                    End If

                    If AvailableJobComponentsList IsNot Nothing Then

                        If CurrentJobComponentsList IsNot Nothing Then

                            For Each CurrentJobComponent In CurrentJobComponentsList

                                Try

                                    JobComponent = AvailableJobComponentsList.SingleOrDefault(Function(Entity) Entity.ToString(True, False) = CurrentJobComponent.ToString(True, False))

                                Catch ex As Exception
                                    JobComponent = Nothing
                                End Try

                                If JobComponent IsNot Nothing Then

                                    AvailableJobComponentsList.Remove(JobComponent)

                                End If

                            Next

                        End If

                    End If

                End If

            End If

            LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail = AvailableJobComponentsList

        End Function
        Public Function LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer,
                                                                                     ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ShowJobsForAllOffices As Boolean,
                                                                                     ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            'objects
            Dim AvailableJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            If DbContext IsNot Nothing Then

                AvailableJobComponentsList = LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail(DbContext, AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID),
                                                                                                          ClientCode, DivisionCode, ProductCode, ShowJobsForAllOffices, SecurityDbContext, Session)

            End If

            LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail = AvailableJobComponentsList

        End Function

        Public Function InsertJobComponentInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                             ByVal ConnectionString As String,
                                                                             ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal JobComponentID As Integer,
                                                                             ByVal LoadRevenueAmount As Boolean, ByVal EstimateRevenueAmount As Decimal) As Boolean

            'objects
            Dim JobComponentInserted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    JobComponentInserted = InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString,
                                                                                                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID),
                                                                                                AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, JobComponentID),
                                                                                                LoadRevenueAmount, EstimateRevenueAmount)

                End If

            Catch ex As Exception
                JobComponentInserted = False
            Finally
                InsertJobComponentInEmployeeTimeForecastOfficeDetail = JobComponentInserted
            End Try

        End Function
        Public Function InsertJobComponentInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                             ByVal ConnectionString As String,
                                                                             ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                             ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                             ByVal LoadRevenueAmount As Boolean, ByVal EstimateRevenueAmount As Decimal,
                                                                             ByVal UseJobComponentBudgetAmountForDefaultRevenue As Boolean) As Boolean

            'objects
            Dim JobComponentInserted As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If JobComponent IsNot Nothing Then

                            If LoadRevenueAmount Then

                                If UseJobComponentBudgetAmountForDefaultRevenue Then

                                    EstimateRevenueAmount = JobComponent.BudgetAmount.GetValueOrDefault(0)

                                Else

                                    If JobComponent.EstimateApproval IsNot Nothing Then

                                        EstimateRevenueAmount = AdvantageFramework.Estimate.CalculateGrossIncomeByEstimateRevision(DbContext, JobComponent.EstimateApproval.EstimateRevision)

                                    End If

                                End If

                            End If

                            If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponent.Insert(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                                                              JobComponent.JobNumber, EstimateRevenueAmount, JobComponent.Number,
                                                                                                                              JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode,
                                                                                                                              JobComponent.Job.ProductCode, JobComponent.Job.OfficeCode, EmployeeTimeForecastOfficeDetailJobComponent) Then

                                JobComponentInserted = SyncJobComponentOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                JobComponentInserted = False
            Finally
                InsertJobComponentInEmployeeTimeForecastOfficeDetail = JobComponentInserted
            End Try

        End Function
        Public Function InsertJobComponentInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                             ByVal ConnectionString As String,
                                                                             ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                             ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent,
                                                                             ByVal LoadRevenueAmount As Boolean, ByVal EstimateRevenueAmount As Decimal) As Boolean

            'objects
            Dim JobComponentInserted As Boolean = False
            Dim UseJobComponentBudgetAmountForDefaultRevenue As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If JobComponent IsNot Nothing Then

                            If LoadRevenueAmount Then

                                Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, DbContext.UserCode)

                                    UseJobComponentBudgetAmountForDefaultRevenue = LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(DataContext)

                                End Using

                            End If

                            JobComponentInserted = InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, ConnectionString, EmployeeTimeForecastOfficeDetail, JobComponent, LoadRevenueAmount, EstimateRevenueAmount, UseJobComponentBudgetAmountForDefaultRevenue)

                        End If

                    End If

                End If

            Catch ex As Exception
                JobComponentInserted = False
            Finally
                InsertJobComponentInEmployeeTimeForecastOfficeDetail = JobComponentInserted
            End Try

        End Function

        Public Function SyncJobComponentOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                           ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                           ByVal EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim JobComponentSyncd As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailEmployeeID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLJC_EMP([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLJC_ID], [ETF_OFFDTLEMP_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, {2}, ETF_OFFDTLEMP_ID, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLEMP " &
                                                                            "WHERE ETF_OFFDTLEMP_ID NOT IN (SELECT ETF_OFFDTLEMP_ID FROM dbo.ETF_OFFDTLJC_EMP WHERE ETF_OFFDTLJC_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailJobComponent.ID, EmployeeTimeForecastOfficeDetailJobComponent.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLJC_AE([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLJC_ID], [ETF_OFFDTLAE_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, {2}, ETF_OFFDTLAE_ID, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLAE " &
                                                                            "WHERE ETF_OFFDTLAE_ID NOT IN (SELECT ETF_OFFDTLAE_ID FROM dbo.ETF_OFFDTLJC_AE WHERE ETF_OFFDTLJC_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailJobComponent.ID, EmployeeTimeForecastOfficeDetailJobComponent.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        JobComponentSyncd = True

                    End If

                End If

            Catch ex As Exception
                JobComponentSyncd = False
            Finally
                SyncJobComponentOnEmployeeTimeForecastOfficeDetail = JobComponentSyncd
            End Try

        End Function

        Public Function DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim JobComponentDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee.DeleteFromEmployeeTimeForecastByJobComponent(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent.ID)

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.DeleteFromEmployeeTimeForecastByJobComponent(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent.ID)

                            JobComponentDeleted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponent.DeleteByEmployeeTimeForecastOfficeDetailJobComponentID(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent.ID)

                        End If

                    End If

                End If

            Catch ex As Exception
                JobComponentDeleted = False
            Finally
                DeleteJobComponentFromEmployeeTimeForecastOfficeDetail = JobComponentDeleted
            End Try

        End Function
        Public Function DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As Boolean

            'objects
            Dim JobComponentDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    JobComponentDeleted = DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(DbContext,
                                                                                                 AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID),
                                                                                                 AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponent.LoadByEmployeeTimeForecastOfficeDetailJobComponentID(DbContext, EmployeeTimeForecastOfficeDetailJobComponentID))

                End If

            Catch ex As Exception
                JobComponentDeleted = False
            Finally
                DeleteJobComponentFromEmployeeTimeForecastOfficeDetail = JobComponentDeleted
            End Try

        End Function

#End Region

#Region "  Office Detail --> Indirect Category "

        Public Function LoadAvailableIndirectCategoriesOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory)

            'objects
            Dim AvailableIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
            Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
            Dim IndirectCategoryCode As String = ""

            If DbContext IsNot Nothing Then

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    CurrentIndirectCategoriesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.Select(Function(EmployeeTimeForecastOfficeDetailIndirectCategory) EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategory).ToList

                    AvailableIndirectCategoriesList = New Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory)

                    For Each IndirectCategory In AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext).ToList

                        IndirectCategoryCode = IndirectCategory.Code

                        If (From Entity In CurrentIndirectCategoriesList
                            Where Entity.Code = IndirectCategoryCode
                            Select Entity).Any = False Then

                            AvailableIndirectCategoriesList.Add(IndirectCategory)

                        End If

                    Next

                End If

            End If

            LoadAvailableIndirectCategoriesOnEmployeeTimeForecastOfficeDetail = AvailableIndirectCategoriesList

        End Function

        Public Function InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal IndirectCategoryCode As String) As Boolean

            'objects
            Dim IndirectCategoryInserted As Boolean = False
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Try

                If DbContext IsNot Nothing Then

                    EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID)

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        IndirectCategoryInserted = InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext,
                                                                                                            EmployeeTimeForecastOfficeDetail,
                                                                                                            AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, IndirectCategoryCode))

                    End If

                End If

            Catch ex As Exception
                IndirectCategoryInserted = False
            Finally
                InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail = IndirectCategoryInserted
            End Try

        End Function
        Public Function InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory) As Boolean

            'objects
            Dim IndirectCategoryInserted As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If IndirectCategory IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategory.Insert(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                                                                  IndirectCategory.Code, EmployeeTimeForecastOfficeDetailIndirectCategory) Then

                                IndirectCategoryInserted = SyncIndirectCategoryOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                IndirectCategoryInserted = False
            Finally
                InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail = IndirectCategoryInserted
            End Try

        End Function

        Public Function SyncIndirectCategoryOnEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                       ByVal EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim IndirectCategorySyncd As Boolean = False
            Dim EmployeeTimeForecastOfficeDetailEmployeeID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLCAT_EMP([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLCAT_ID], [ETF_OFFDTLEMP_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, {2}, ETF_OFFDTLEMP_ID, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLEMP " &
                                                                            "WHERE ETF_OFFDTLEMP_ID NOT IN (SELECT ETF_OFFDTLEMP_ID FROM dbo.ETF_OFFDTLCAT_EMP WHERE ETF_OFFDTLCAT_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailIndirectCategory.ID, EmployeeTimeForecastOfficeDetailIndirectCategory.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ETF_OFFDTLCAT_AE([ETF_ID], [ETF_OFFDTL_ID], [ETF_OFFDTLCAT_ID], [ETF_OFFDTLAE_ID], [HOURS]) " &
                                                                            "SELECT {0}, {1}, {2}, ETF_OFFDTLAE_ID, 0  " &
                                                                            "FROM dbo.ETF_OFFDTLAE " &
                                                                            "WHERE ETF_OFFDTLAE_ID NOT IN (SELECT ETF_OFFDTLAE_ID FROM dbo.ETF_OFFDTLCAT_AE WHERE ETF_OFFDTLCAT_ID = {3}) AND ETF_ID = {4} AND ETF_OFFDTL_ID = {5}",
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID,
                                                                                EmployeeTimeForecastOfficeDetailIndirectCategory.ID, EmployeeTimeForecastOfficeDetailIndirectCategory.ID,
                                                                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetail.ID))

                        Catch ex As Exception

                        End Try

                        IndirectCategorySyncd = True

                    End If

                End If

            Catch ex As Exception
                IndirectCategorySyncd = False
            Finally
                SyncIndirectCategoryOnEmployeeTimeForecastOfficeDetail = IndirectCategorySyncd
            End Try

        End Function

        Public Function DeleteIndirectCategoryInEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim IndirectCategoryDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If EmployeeTimeForecastOfficeDetailIndirectCategory IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.DeleteFromEmployeeTimeForecastByIndirectCategory(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory.ID)

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.DeleteFromEmployeeTimeForecastByIndirectCategory(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory.ID)

                            IndirectCategoryDeleted = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategory.DeleteByEmployeeTimeForecastOfficeDetailIndirectCategoryID(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory.ID)

                        End If

                    End If

                End If

            Catch ex As Exception
                IndirectCategoryDeleted = False
            Finally
                DeleteIndirectCategoryInEmployeeTimeForecastOfficeDetail = IndirectCategoryDeleted
            End Try

        End Function

#End Region

#End Region

    End Module

End Namespace
