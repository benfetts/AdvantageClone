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

Namespace AdvantageMobile.DataService.Client

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

        Public Function GetClients(ByVal SearchValue As String, ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of Global.AdvantageMobile.Client)

            Dim query As IQueryable(Of Global.AdvantageMobile.Client)
            Dim HasRestrictions As Boolean = (From SC In Me._DataEntities.SecurityClients
                                              Where SC.UserCode = Me._UserCode).Count > 0

            If HasRestrictions = True Then

                Dim UniqueKeyValues As String() = Nothing

                UniqueKeyValues = (From Entity In Me._DataEntities.Clients
                                   Join SC In Me._DataEntities.SecurityClients
                                   On Entity.Code Equals SC.ClientCode
                                   Where SC.UserCode = Me._UserCode _
                                   AndAlso Entity.IsActive = 1
                                   Select Entity.Code).ToArray

                query = (From Entity In Me._DataEntities.Clients
                         Where Entity.IsActive = 1 AndAlso UniqueKeyValues.Contains(Entity.Code)
                         Order By Entity.Name
                         Select Entity)

            Else

                query = (From Entity In Me._DataEntities.Clients
                         Where Entity.IsActive = 1
                         Order By Entity.Name
                         Select Entity)


            End If

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                query = query.Where(Function(Client) Client.Name.ToUpper().Contains(SearchValue.ToUpper()))

            End If

            Return query.Skip(Skip).Take(Take)

        End Function

        Public Function GetClientsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Client
            Dim query As Global.AdvantageMobile.Client
            query = (From Entity In Me._DataEntities.Clients
                     Join JobLog In Me._DataEntities.JobLogs
                        On Entity.Code Equals JobLog.ClientCode
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
