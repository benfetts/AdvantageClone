Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports AdvantageFramework.Security.Classes
Imports System.Data.Entity.Core.Objects
Imports System.Collections

Namespace AdvantageMobile.DataService.Employee

    <System.Serializable()> Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function GetEmployeeSummary(ByVal EmployeeCode As String) As EmployeeSummary

            Dim es As New EmployeeSummary
            Dim emp As New Global.AdvantageMobile.Employee

            Try

                emp = (From Employee In Me._DataEntities.Employees
                       Where Employee.Code = EmployeeCode).FirstOrDefault()

                If emp IsNot Nothing Then

                    es.EmployeeCode = emp.Code
                    es.FirstName = emp.FirstName
                    es.MiddleInitial = emp.MiddleInitial
                    es.LastName = emp.LastName

                    es.FullName = emp.FirstName & If(emp.MiddleInitial IsNot Nothing OrElse emp.MiddleInitial <> "", " " & emp.MiddleInitial & ". ", " ") & emp.LastName

                    es.DepartmentTeamCode = emp.DepartmentTeamCode
                    es.DefaultFunctionCode = emp.DefaultFunctionCode

                    Select Case Today.Date.DayOfWeek
                        Case DayOfWeek.Sunday
                            If emp.SundayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.SundayHours

                            End If
                        Case DayOfWeek.Monday
                            If emp.MondayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.MondayHours

                            End If
                        Case DayOfWeek.Tuesday
                            If emp.TuesdayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.TuesdayHours

                            End If
                        Case DayOfWeek.Wednesday
                            If emp.WednesdayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.WednesdayHours

                            End If
                        Case DayOfWeek.Thursday
                            If emp.ThursdayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.ThursdayHours

                            End If
                        Case DayOfWeek.Friday
                            If emp.FridayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.FridayHours

                            End If
                        Case DayOfWeek.Saturday
                            If emp.SaturdayHours IsNot Nothing Then

                                es.StandardHoursForToday = emp.SaturdayHours

                            End If
                    End Select


                    Dim empp As New EmployeePicture

                    empp = (From EmployeePicture In Me._DataEntities.EmployeePictures
                            Where EmployeePicture.EmployeeCode = es.EmployeeCode).FirstOrDefault()

                    If empp IsNot Nothing Then

                        If empp.EmployeeImage IsNot Nothing Then

                            es.Image = empp.EmployeeImage

                        End If

                    End If

                    Dim alrt As New AdvantageMobile.DataService.Alert.Methods(Me._DataEntities, Me._DataServiceUser)

                    Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Me._DataServiceUser.ConnectionString,
                                                                     Me._DataServiceUser.UserCode, 0, Me._DataServiceUser.ConnectionString)

                    If s IsNot Nothing Then

                        s.User.EmployeeCode = EmployeeCode

                        Dim d As New AdvantageFramework.Controller.Dashboard.DashboardController(s)
                        Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
                        Dim ts As New AdvantageMobile.DataService.Timesheet.Methods(Me._DataEntities, Me._DataServiceUser)

                        CardGroups = d.GetDashboardCardGroups(AdvantageFramework.Controller.Dashboard.DashboardController.DashboardType.Assignments,
                                                              "", "", False, 0, 0, es.AssignmentCount, es.AlertCount)

                        es.TimesheetHoursForToday = ts.GetHoursForDay(es.EmployeeCode, Date.Now.ToShortDateString())

                        If es.TimesheetHoursForToday Is Nothing Then

                            es.TimesheetHoursForToday = 0

                        End If
                        Try

                            Dim exps As New AdvantageMobile.DataService.Expense.Methods(Me._DataEntities, Me._DataServiceUser)
                            Dim ExpList As IEnumerable(Of Object) = Nothing

                            ExpList = exps.GetExpenses(es.EmployeeCode)
                            es.ExpenseCount = ExpList.Count()

                            If es.ExpenseCount Is Nothing Then es.ExpenseCount = 0

                        Catch ex As Exception
                            If es.ExpenseCount Is Nothing Then es.ExpenseCount = 0
                        End Try

                    End If

                End If

            Catch ex As Exception
                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            End Try

            Return es

        End Function

        Sub New(ByVal DataSource As DataEntities, ByRef CurrentDataServiceUser As DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = CurrentDataServiceUser.UserCode

        End Sub

#End Region

    End Class

End Namespace
