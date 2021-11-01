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

Namespace AdvantageMobile.DataService.ProjectSchedule

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

        Public Function GetProjects(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of ProjectViewpoint)

            SearchValue = SearchValue.Trim().ToUpper()

            Dim SearchFor As AdvantageMobile.DataService.Application.SearchFor = Application.SearchFor.Standard
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0

            SearchFor = AdvantageMobile.DataService.Application.GetSearchType(SearchValue, JobNumber, JobComponentNumber)
            Select Case SearchFor
                Case Application.SearchFor.Standard
                    GetProjects = (From Projects In Me._DataEntities.GetProjects("N", "0", "", "", "N", Me._UserCode, EmployeeCode, "Y", True, 0, 5000, 0)
                                   Where Projects.JobDescription.ToUpper().Contains(SearchValue) _
                                   OrElse Projects.JobComponentDescription.ToUpper().Contains(SearchValue)
                                   Order By Projects.JobNumber Descending, Projects.JobComponentNumber Ascending
                                   Select Projects).Skip(Skip).Take(Take)
                Case Application.SearchFor.JobNumber
                    GetProjects = (From Projects In Me._DataEntities.GetProjects("N", "0", "", "", "N", Me._UserCode, EmployeeCode, "Y", True, 0, 5000, 0)
                                   Where Projects.JobNumber = JobNumber
                                   Order By Projects.JobNumber Descending, Projects.JobComponentNumber Ascending
                                   Select Projects).Skip(Skip).Take(Take)
                Case Application.SearchFor.JobNumberAndJobComponentNumber
                    GetProjects = (From Projects In Me._DataEntities.GetProjects("N", "0", "", "", "N", Me._UserCode, EmployeeCode, "Y", True, 0, 5000, 0)
                                   Where Projects.JobNumber = JobNumber _
                                   AndAlso Projects.JobComponentNumber = JobComponentNumber
                                   Order By Projects.JobNumber Descending, Projects.JobComponentNumber Ascending
                                   Select Projects).Skip(Skip).Take(Take)
                Case Else
                    GetProjects = (From Projects In Me._DataEntities.GetProjects("N", "0", "", "", "N", Me._UserCode, EmployeeCode, "Y", True, 0, 5000, 0)
                                   Order By Projects.JobNumber Descending, Projects.JobComponentNumber Ascending
                                   Select Projects).Skip(Skip).Take(Take)
            End Select


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
