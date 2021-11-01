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

Namespace AdvantageMobile.DataService.DepartmentTeam

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

        Public Function GetDepartmentsByEmployeeCode(ByVal EmployeeCode As String) As IQueryable(Of Global.AdvantageMobile.EmployeeDepartmentTeam)

            GetDepartmentsByEmployeeCode = (From edt In Me._DataEntities.EmployeeDepartmentTeams
                                            Join DepartmentTeams In Me._DataEntities.DepartmentTeams On DepartmentTeams.Code Equals edt.DepartmentTeamCode
                                            Where edt.EmployeeCode = EmployeeCode _
                                            AndAlso (DepartmentTeams.IsInactive Is Nothing OrElse DepartmentTeams.IsInactive = 0)
                                            Order By edt.Description
                                            Select edt)

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
