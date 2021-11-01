Imports System.Data.SqlClient
Imports System.Web
Imports AdvantageFramework.Timesheet.Methods
Imports System.Threading

Namespace Controller.Employee

    <Serializable>
    Public Class ExpenseReportController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadExpenseReportOptionsByInvoiceNumber(ByVal InvoiceNumber As Integer,
                                                                ByVal IncludeApproverList As Boolean) As AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

            Dim Options As AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel = Nothing
            If InvoiceNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        If Employee IsNot Nothing Then

                            Options = LoadExpenseReportOptions(DbContext, Employee, IncludeApproverList)

                            If Options IsNot Nothing Then

                                Options.EmployeeCode = Employee.Code
                                Options.EmployeeFullName = Employee.ToString
                                Options.InvoiceNumber = InvoiceNumber

                            End If

                        End If

                    End If

                End Using

            End If

            If Options Is Nothing Then Options = New ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel
            Return Options

        End Function
        Public Function LoadExpenseReportOptionsByEmployee(ByVal EmployeeCode As String,
                                                           ByVal IncludeApproverList As Boolean) As AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

            Dim Options As New AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    LoadExpenseReportOptions(DbContext, Employee, IncludeApproverList)

                End If

            End Using

            If Options Is Nothing Then Options = New ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel
            Return Options

        End Function
        Private Function LoadExpenseReportOptions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                  ByVal IncludeApproverList As Boolean) As AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

            Dim Options As New AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Employee IsNot Nothing Then

                        Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
                        Dim AltApprover As AdvantageFramework.Database.Views.Employee = Nothing

                        Options.EmployeeSupervisorApprovalRequired = Employee.SupervisorApprovalRequired.GetValueOrDefault(0) = 1

                        'Supervisor
                        Try

                            If String.IsNullOrWhiteSpace(Employee.SupervisorEmployeeCode) = False Then

                                Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                                If Supervisor IsNot Nothing Then

                                    If Supervisor.TerminationDate.HasValue = False Then

                                        Options.SupervisorEmployeeCode = Employee.SupervisorEmployeeCode
                                        Options.SupervisorEmployeeFullName = Supervisor.ToString

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try
                        'Alternate
                        Try

                            If String.IsNullOrWhiteSpace(Employee.AlternateApproverCode) = False Then

                                AltApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.AlternateApproverCode)

                                If AltApprover IsNot Nothing Then

                                    If AltApprover.TerminationDate.HasValue = False Then

                                        Options.AlternateApproverEmployeeCode = Employee.AlternateApproverCode
                                        Options.AlternateApproverEmployeeFullName = AltApprover.ToString

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try
                        'Available
                        If IncludeApproverList = True Then

                            Try

                                Dim AvailAppr As AdvantageFramework.ViewModels.Employee.ExpenseReport.AvailableApprover = Nothing
                                For Each Emp As AdvantageFramework.Database.Views.Employee In AdvantageFramework.ExpenseReports.LoadAvailableApprovers(Me.Session, DbContext, SecurityDbContext, Employee.Code)

                                    AvailAppr = New ViewModels.Employee.ExpenseReport.AvailableApprover
                                    AvailAppr.EmployeeCode = Emp.Code
                                    AvailAppr.EmployeeFullName = Emp.ToString

                                    Options.AvailableApprovers.Add(AvailAppr)

                                    AvailAppr = Nothing

                                Next

                            Catch ex As Exception
                            End Try

                        End If

                    End If

                End Using

            Catch ex As Exception
                Options = Nothing
            End Try

            Return Options

        End Function


        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

#End Region

    End Class

End Namespace
