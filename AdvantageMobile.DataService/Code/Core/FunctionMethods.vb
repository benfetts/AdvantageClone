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

Namespace AdvantageMobile.DataService.Function

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

        Public Function GetFunctionsByEmployeeCode(ByVal EmployeeCode As String, ByVal SearchValue As String) As IQueryable(Of Global.AdvantageMobile.Function)

            Dim IsLimited As Boolean = False
            Dim UserID As Nullable(Of Integer) = 0
            Dim query As IQueryable(Of Global.AdvantageMobile.Function)

            UserID = (From su In Me._DataEntities.SecurityUsers
                      Where su.EmployeeCode.ToUpper() = EmployeeCode.ToUpper()
                      Select su.ID).FirstOrDefault()

            If UserID IsNot Nothing AndAlso UserID > 0 Then


                IsLimited = (From sus In Me._DataEntities.SecurityUserSettings
                             Where sus.SecurityUserID = UserID _
                             AndAlso sus.SettingCode.Trim() = "EMP_TS_FNC" _
                             AndAlso sus.StringValue.Trim() = "Y").Count() > 0

            End If

            If IsLimited = True Then

                query = (From etsfn In Me._DataEntities.EmployeeTimesheetFunctions
                         Where etsfn.Function.FunctionType = "E" _
                                AndAlso etsfn.EmployeeCode = EmployeeCode _
                                AndAlso (etsfn.Function.IsInactive = 0 OrElse etsfn.Function.IsInactive Is Nothing)
                         Order By etsfn.Function.Name
                         Select etsfn.Function)

            Else

                query = (From fn In Me._DataEntities.Functions
                         Where fn.FunctionType = "E" _
                                AndAlso (fn.IsInactive = 0 OrElse fn.IsInactive Is Nothing)
                         Order By fn.Name
                         Select fn)

            End If

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                query = query.Where(Function(Functions) Functions.Name.ToUpper().Contains(SearchValue.ToUpper()))

            End If

            Return query

        End Function
        Public Function LoadAllEmployeeExpenseFunctions(ByVal SearchValue As String) As IQueryable(Of Global.AdvantageMobile.Function)

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then
                LoadAllEmployeeExpenseFunctions = From [Function] In Me._DataEntities.Functions
                                                  Where [Function].EX_FLAG = CShort(1) And
                                                      [Function].Name.ToLower().Contains(SearchValue.ToLower()) And
                                                      ([Function].IsInactive = 0 Or [Function].IsInactive Is Nothing)
                                                  Select [Function]
            Else
                LoadAllEmployeeExpenseFunctions = From [Function] In Me._DataEntities.Functions
                                                  Where [Function].EX_FLAG = CShort(1) And
                                                      ([Function].IsInactive = 0 Or [Function].IsInactive Is Nothing)
                                                  Select [Function]
            End If

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
