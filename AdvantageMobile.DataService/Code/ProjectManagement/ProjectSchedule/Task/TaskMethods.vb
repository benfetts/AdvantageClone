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

Namespace AdvantageMobile.DataService.ProjectSchedule.Task

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

        Public Function MarkTaskTempComplete(ByVal EmployeeCode As String,
                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer,
                                             ByVal CompleteDate As Date) As Boolean

            Dim Completed As Boolean = False
            Dim MarkedComplete As Boolean = False

            Using oc = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                Using sc = New AdvantageFramework.Security.Database.DbContext(Me._ConnectionString, Me._UserCode)

                    If AdvantageFramework.ProjectSchedule.MarkTempComplete(oc, sc, JobNumber, JobComponentNumber, SequenceNumber, EmployeeCode, CompleteDate) = True Then

                        Completed = True

                    End If

                End Using

            End Using

            Return Completed

        End Function
        Public Function GetTask(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As JobTrafficDetail

            GetTask = (From Task In Me._DataEntities.JobTrafficDetails
                       Where Task.JobNumber = JobNumber _
                       AndAlso Task.JobComponentNumber = JobComponentNumber _
                       AndAlso Task.SequenceNumber = SequenceNumber).FirstOrDefault()

        End Function
        Public Function GetTasks(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of MyTask)

            '@UserID Varchar(100),
            '@EmpCode Varchar(6),
            '@StartDate Datetime, --> Only used when showing "Today"
            '@TaskStatus Varchar(10) = '', -->  P, A, H, or L
            '@TaskShow as Varchar(10), --> Blank or "Today"
            '@Search as Varchar(500),
            '@CP as int,
            '@CPID as int
            GetTasks = (From MyTasks In Me._DataEntities.GetMyTasks(Me._UserCode, EmployeeCode, Now(), "", "", SearchValue, 0, 0)
                        Select MyTasks).Skip(Skip).Take(Take)

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

