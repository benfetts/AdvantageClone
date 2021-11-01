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

Namespace AdvantageMobile.DataService.Division

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

        Public Function GetDivisions(ByVal ClientCode As String, ByVal SearchValue As String) As IQueryable(Of Global.AdvantageMobile.Division)

            Dim HasRestrictions As Boolean = (From SC In Me._DataEntities.SecurityClients
                                              Where SC.UserCode = Me._UserCode).Count > 0

            Dim query As IQueryable(Of Global.AdvantageMobile.Division)

            'If ClientCode <> "undefined" And ClientCode <> "null" Then

            If HasRestrictions = True Then

                query = (From Entity In Me._DataEntities.Divisions
                         Join SC In Me._DataEntities.SecurityClients
                        On Entity.Code Equals SC.DivisionCode _
                        And Entity.ClientCode Equals SC.ClientCode
                         Where SC.UserCode = Me._UserCode _
                        AndAlso Entity.IsActive = 1 _
                        AndAlso Entity.Client.IsActive = 1
                         Order By Entity.Name
                         Select Entity)

            Else

                query = (From Entity In Me._DataEntities.Divisions
                         Where Entity.IsActive = 1 _
                        AndAlso Entity.Client.IsActive = 1
                         Order By Entity.Name
                         Select Entity)

            End If

            If ClientCode.Trim() <> "" Then

                query = query.Where(Function(Division) Division.ClientCode = ClientCode)

            End If

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                query = query.Where(Function(Division) Division.Name.ToUpper().Contains(SearchValue.ToUpper()))

            End If

            'End If

            Return query

        End Function
        Public Function GetDivisionsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Division
            Dim query As Global.AdvantageMobile.Division
            query = (From Entity In Me._DataEntities.Divisions
                     Join JobLog In Me._DataEntities.JobLogs
                        On Entity.Code Equals JobLog.DivisionCode _
                        And Entity.ClientCode Equals JobLog.ClientCode
                     Where JobLog.JobNumber = JobNumber
                     Order By Entity.Name
                     Select Entity).FirstOrDefault()
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
