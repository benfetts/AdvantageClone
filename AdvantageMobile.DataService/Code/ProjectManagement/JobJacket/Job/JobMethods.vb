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

Namespace AdvantageMobile.DataService.JobJacket.Job

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

        Public Function GetJobLog(ByVal JobNumber As Integer) As JobLog

            GetJobLog = (From JL In Me._DataEntities.JobLogs
                         Where JL.JobNumber = JobNumber).FirstOrDefault()

        End Function

        'Type: 0 = timesheet, 1 = expense report
        Public Function GetJobLogs(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                   ByVal SearchValue As String, ByVal Type As Short, ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of JobLog)

            'Dim ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12} <== Standard
            Dim ExcludedJobProcessControlNumbers = New Integer() {2, 3, 5, 6, 9, 10, 12, 13} ' <== Timesheet
            Dim HasRestrictions As Boolean = (From SC In Me._DataEntities.SecurityClients
                                              Where SC.UserCode = Me._UserCode).Count > 0

            Dim query As IQueryable(Of JobLog)
            Dim list As New List(Of Integer)

            Select Case Type
                Case 1

                    ExcludedJobProcessControlNumbers = New Integer() {2, 5, 6, 7, 10, 11, 12}

                Case Else

                    ExcludedJobProcessControlNumbers = New Integer() {2, 3, 5, 6, 9, 10, 12, 13}

            End Select


            If HasRestrictions = True Then

                list = (From JL In Me._DataEntities.JobLogs
                        Join JC In Me._DataEntities.JobComponents
                        On JL.JobNumber Equals JC.JobNumber
                        Join SC In Me._DataEntities.SecurityClients
                        On JL.ClientCode Equals SC.ClientCode _
                        And JL.DivisionCode Equals SC.DivisionCode _
                        And JL.ProductCode Equals SC.ProductCode
                        Where ExcludedJobProcessControlNumbers.Contains(CType(JC.ProcessControl, Integer)) = False
                        Select JL.JobNumber).Distinct().ToList()

            Else

                list = (From JL In Me._DataEntities.JobLogs
                        Join JC In Me._DataEntities.JobComponents
                        On JL.JobNumber Equals JC.JobNumber
                        Where ExcludedJobProcessControlNumbers.Contains(CType(JC.ProcessControl, Integer)) = False
                        Select JL.JobNumber).Distinct().ToList()

            End If

            query = (From JL In Me._DataEntities.JobLogs
                     Where list.Contains(JL.JobNumber)
                     Order By JL.JobNumber Descending
                     Select JL)

            If ClientCode.Trim() <> "" Then

                query = query.Where(Function(JobLog) JobLog.ClientCode = ClientCode)

            End If
            If DivisionCode.Trim() <> "" Then

                query = query.Where(Function(JobLog) JobLog.DivisionCode = DivisionCode)

            End If
            If ProductCode.Trim() <> "" Then

                query = query.Where(Function(JobLog) JobLog.ProductCode = ProductCode)

            End If

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                Dim SearchFor As AdvantageMobile.DataService.Application.SearchFor = Application.SearchFor.Standard
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0

                SearchFor = AdvantageMobile.DataService.Application.GetSearchType(SearchValue, JobNumber, JobComponentNumber)

                Select Case SearchFor
                    Case Application.SearchFor.JobNumber

                        query = query.Where(Function(JobLog) JobLog.JobNumber = JobNumber)

                    Case Else

                        query = query.Where(Function(JobLog) JobLog.Description.ToUpper().Contains(SearchValue.ToUpper()))

                End Select

            End If

            Return query.Skip(Skip).Take(Take)

        End Function

        Public Function SearchForTimesheetJobs(ByVal SearchValue As String) As IEnumerable(Of SimpleJob)

            SearchForTimesheetJobs = (From SJ In Me._DataEntities.SearchTimesheetJobs(SearchValue, Me._UserCode))

        End Function

        Sub New(ByVal DataSource As DataEntities, ByVal CurrentDataServiceUser As DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode

        End Sub

#End Region

    End Class

End Namespace
