Namespace Utilities

    <HideModuleName()> _
    Public Module Methods

        Public Function RemoveAllNonNumeric(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonNumeric = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^0-9]", "")

                Else

                    RemoveAllNonNumeric = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonNumeric = DefaultReturn
            End Try

        End Function
        Public Function LoadTotalHoursWorked(ByVal Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee, ByVal StartDate As Date, ByVal EndDate As Date) As Decimal

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

    End Module

End Namespace

