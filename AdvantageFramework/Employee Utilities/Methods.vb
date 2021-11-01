Namespace EmployeeUtilities

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ImportEmployeeFromImportEmployeeStaging(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                                                                ByVal ImportEmployeeStagingID As Integer, ByVal CreatedByUserCode As String, ByVal IsUpdating As Boolean) As Boolean

            ImportEmployeeFromImportEmployeeStaging = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_import_employee_from_staging] {0}, {1}, {2}", ImportEmployeeStagingID, CreatedByUserCode, IIf(IsUpdating, 1, 0))

        End Function
        Public Function LoadEmailWithEmployeeName(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EmployeeCode As String) As String
            'objects
            Dim EmailWithEmployeeName As String = ""

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    EmailWithEmployeeName = DbContext.Database.SqlQuery(Of String)("EXEC [dbo].[usp_wv_Employee_GetFromAddress] {0}", EmployeeCode).FirstOrDefault.ToString()

                End If

            Catch ex As Exception
                EmailWithEmployeeName = ""
            Finally
                LoadEmailWithEmployeeName = EmailWithEmployeeName
            End Try

        End Function
        Public Function LoadEmailWithEmployeeName(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal Email As String) As String

            'objects
            Dim EmailWithEmployeeName As String = ""

            Try

                If Employee IsNot Nothing Then

                    EmailWithEmployeeName = AdvantageFramework.Email.LoadEmailWithName(Employee.ToString, Email)

                End If

            Catch ex As Exception
                EmailWithEmployeeName = ""
            Finally
                LoadEmailWithEmployeeName = EmailWithEmployeeName
            End Try

        End Function
        Public Function LoadEmailWithEmployeeName(ByVal Employee As AdvantageFramework.Database.Views.Employee) As String

            'objects
            Dim EmailWithEmployeeName As String = ""

            Try

                If Employee IsNot Nothing Then

                    EmailWithEmployeeName = LoadEmailWithEmployeeName(Employee, Employee.Email)

                End If

            Catch ex As Exception
                EmailWithEmployeeName = ""
            Finally
                LoadEmailWithEmployeeName = EmailWithEmployeeName
            End Try

        End Function
        Public Function LoadTotalRequiredHours(ByVal EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail), ByVal EmployeeCode As String) As Decimal

            'objects
            Dim TotalRequiredHours As Decimal = 0

            Try

                If EmployeeStandardHoursDetailList IsNot Nothing Then

                    TotalRequiredHours = EmployeeStandardHoursDetailList.Where(Function(Entity) Entity.EmployeeCode = EmployeeCode).Sum(Function(EmployeeStandardHoursDetail) EmployeeStandardHoursDetail.StandardHours)

                End If

            Catch ex As Exception
                TotalRequiredHours = 0
            Finally
                LoadTotalRequiredHours = TotalRequiredHours
            End Try

        End Function
        Public Function LoadTotalRequiredHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Decimal

            'objects
            Dim TotalRequiredHours As Decimal = 0

            Try

                If DbContext IsNot Nothing Then

                    TotalRequiredHours = LoadTotalRequiredHours(AdvantageFramework.Database.Procedures.EmployeeStandardHoursDetail.LoadByUserCodeAndEmployeeCode(DbContext, DbContext.UserCode, EmployeeCode).ToList, EmployeeCode)

                End If

            Catch ex As Exception
                TotalRequiredHours = 0
            Finally
                LoadTotalRequiredHours = TotalRequiredHours
            End Try

        End Function
        Public Function CreateEmployeeStandardHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StartDate As Date, ByVal EndDate As Date) As Boolean

            'objects
            Dim EmployeeStandardHoursCreated As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.EmployeeStandardHours.DeleteByUserCode(DbContext, DbContext.UserCode) Then

                        EmployeeStandardHoursCreated = AdvantageFramework.Database.Procedures.EmployeeStandardHours.Insert(DbContext, DbContext.UserCode, Now, StartDate, EndDate, Nothing)

                    End If

                End If

            Catch ex As Exception
                EmployeeStandardHoursCreated = False
            Finally
                CreateEmployeeStandardHours = EmployeeStandardHoursCreated
            End Try

        End Function
        Public Function LoadTotalWeeklyHours(Employee As AdvantageFramework.Database.Views.Employee) As Integer

            'objects
            Dim TotalWeeklyHours As Decimal = 0
            Dim WorkDays As String() = Nothing


            Try

                If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.WorkDays) = False AndAlso
                        Employee.WorkDays.Contains(",") Then

                    WorkDays = Employee.WorkDays.Split(",")

                End If

            Catch ex As Exception
                WorkDays = New String() {}
            End Try

            Try

                If Employee IsNot Nothing Then

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Monday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.MondayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Tuesday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.TuesdayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Wednesday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.WednesdayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Thursday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.ThursdayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Friday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.FridayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Saturday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.SaturdayHours.GetValueOrDefault(0)

                    End If

                    If WorkDays.Where(Function(WorkDay) WorkDay = AdvantageFramework.DateUtilities.Days.Sunday.ToString.Substring(0, 3)).Any Then

                        TotalWeeklyHours += Employee.SundayHours.GetValueOrDefault(0)

                    End If

                End If

            Catch ex As Exception
                TotalWeeklyHours = 0
            Finally
                LoadTotalWeeklyHours = TotalWeeklyHours
            End Try

        End Function
        Public Function LoadTotalHoursWorked(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal StartDate As Date, ByVal EndDate As Date) As Decimal

            'objects
            Dim TotalHoursWorked As Decimal = 0
            Dim [Date] As Date = Nothing
            Dim Monday As Integer = 0
            Dim Tuesday As Integer = 0
            Dim Wednesday As Integer = 0
            Dim Thursday As Integer = 0
            Dim Friday As Integer = 0
            Dim Saturday As Integer = 0
            Dim Sunday As Integer = 0

            Try

                [Date] = StartDate

                For Days = 0 To EndDate.Subtract(StartDate).Days

                    If [Date] <= EndDate Then

                        If [Date].DayOfWeek = DayOfWeek.Monday Then

                            Monday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Tuesday Then

                            Tuesday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Wednesday Then

                            Wednesday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Thursday Then

                            Thursday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Friday Then

                            Friday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Saturday Then

                            Saturday += 1
                            [Date] = [Date].AddDays(1)

                        ElseIf [Date].DayOfWeek = DayOfWeek.Sunday Then

                            Sunday += 1
                            [Date] = [Date].AddDays(1)

                        End If

                    Else

                        Exit For

                    End If

                Next

                If Employee.MondayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.MondayHours * Monday

                End If

                If Employee.TuesdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.TuesdayHours * Tuesday

                End If

                If Employee.WednesdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.WednesdayHours * Wednesday

                End If

                If Employee.ThursdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.ThursdayHours * Thursday

                End If

                If Employee.FridayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.FridayHours * Friday

                End If

                If Employee.SaturdayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.SaturdayHours * Saturday

                End If

                If Employee.SundayHours.GetValueOrDefault(0) <> 0 Then

                    TotalHoursWorked += Employee.SundayHours * Sunday

                End If

            Catch ex As Exception
                TotalHoursWorked = 0
            Finally
                LoadTotalHoursWorked = TotalHoursWorked
            End Try

        End Function

#End Region

    End Module

End Namespace
