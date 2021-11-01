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

Namespace AdvantageMobile.DataService.JobJacket.JobComponent

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

        Public Function GetJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Global.AdvantageMobile.JobComponent

            GetJobComponent = (From JC In Me._DataEntities.JobComponents.Include("JobLog")
                               Where JC.JobNumber = JobNumber _
                                    AndAlso JC.JobComponentNumber = JobComponentNumber).FirstOrDefault()

        End Function

        'Type: 0 = timesheet, 1 = expense report
        Public Function GetJobComponents(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                         ByVal Job_Number As Integer, ByVal SearchValue As String, ByVal Type As Short) As IQueryable(Of Global.AdvantageMobile.JobComponent)

            'Dim ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12} <== Standard
            Dim ExcludedJobProcessControlNumbers = New Integer() {2, 3, 5, 6, 9, 10, 12, 13} ' <== Timesheet
            Dim query As IQueryable(Of Global.AdvantageMobile.JobComponent)
            Dim HasRestrictions As Boolean = (From SC In Me._DataEntities.SecurityClients
                                              Where SC.UserCode = Me._UserCode).Count > 0

            Select Case Type
                Case 1

                    ExcludedJobProcessControlNumbers = New Integer() {2, 5, 6, 7, 10, 11, 12}

                Case Else

                    ExcludedJobProcessControlNumbers = New Integer() {2, 3, 5, 6, 9, 10, 12, 13}

            End Select

            If HasRestrictions = True Then

                Dim list As New List(Of Integer)

                list = (From JL In Me._DataEntities.JobLogs
                        Join JC In Me._DataEntities.JobComponents
                        On JL.JobNumber Equals JC.JobNumber
                        Join SC In Me._DataEntities.SecurityClients
                        On JL.ClientCode Equals SC.ClientCode _
                        And JL.DivisionCode Equals SC.DivisionCode _
                        And JL.ProductCode Equals SC.ProductCode
                        Where ExcludedJobProcessControlNumbers.Contains(CType(JC.ProcessControl, Integer)) = False
                        Order By JL.JobNumber Descending
                        Select JL.[JobNumber]).Distinct().ToList()

                query = (From JC In Me._DataEntities.JobComponents
                         Where list.Contains(CType(JC.JobNumber, Integer)) = False
                         Order By JC.JobNumber Descending, JC.JobComponentNumber Ascending)

            Else

                query = (From JC In Me._DataEntities.JobComponents
                         Where ExcludedJobProcessControlNumbers.Contains(CType(JC.ProcessControl, Integer)) = False
                         Order By JC.JobNumber Descending, JC.JobComponentNumber Ascending)

            End If


            If Job_Number > 0 Then

                query = query.Where(Function(JobComponent) JobComponent.JobNumber = Job_Number)

            Else

                If ClientCode IsNot Nothing AndAlso ClientCode.Trim() <> "" Then

                    query = query.Where(Function(JobComponent) JobComponent.JobLog.ClientCode = ClientCode)

                End If
                If DivisionCode IsNot Nothing AndAlso DivisionCode.Trim() <> "" Then

                    query = query.Where(Function(JobComponent) JobComponent.JobLog.DivisionCode = DivisionCode)

                End If
                If ProductCode IsNot Nothing AndAlso ProductCode.Trim() <> "" Then

                    query = query.Where(Function(JobComponent) JobComponent.JobLog.ProductCode = ProductCode)

                End If

            End If

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                Dim SearchFor As AdvantageMobile.DataService.Application.SearchFor = Application.SearchFor.Standard
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0

                SearchFor = AdvantageMobile.DataService.Application.GetSearchType(SearchValue, JobNumber, JobComponentNumber)

                Select Case SearchFor
                    Case Application.SearchFor.Standard

                        query = query.Where(Function(JobComponent) JobComponent.JobLog.Description.ToUpper().Contains(SearchValue.ToUpper()) OrElse JobComponent.Description.ToUpper().Contains(SearchValue.ToUpper()))

                    Case Application.SearchFor.JobNumber

                        query = query.Where(Function(JobComponent) JobComponent.JobNumber = JobNumber)

                    Case Application.SearchFor.JobNumberAndJobComponentNumber

                        query = query.Where(Function(JobComponent) JobComponent.JobNumber = JobNumber AndAlso JobComponent.JobComponentNumber = JobComponentNumber)

                End Select

            End If

            Return query

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
