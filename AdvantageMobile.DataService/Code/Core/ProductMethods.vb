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

Namespace AdvantageMobile.DataService.Product

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

        Public Function GetProducts(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal SearchValue As String) As IQueryable(Of Global.AdvantageMobile.Product)

            Dim HasRestrictions As Boolean = (From SC In Me._DataEntities.SecurityClients
                                              Where SC.UserCode = Me._UserCode).Count > 0
            Dim query As IQueryable(Of Global.AdvantageMobile.Product)

            If HasRestrictions = True Then

                query = (From Entity In Me._DataEntities.Products
                         Join SC In Me._DataEntities.SecurityClients
                         On Entity.Code Equals SC.ProductCode _
                         And Entity.ClientCode Equals SC.ClientCode _
                         And Entity.DivisionCode Equals SC.DivisionCode
                         Where SC.UserCode = Me._UserCode _
                         AndAlso (Entity.IsActive = 1) _
                         AndAlso Entity.Division.IsActive = 1 _
                         AndAlso Entity.Division.Client.IsActive = 1 _
                         AndAlso Entity.ClientCode = ClientCode _
                         AndAlso Entity.DivisionCode = DivisionCode
                         Order By Entity.Description
                         Select Entity)

            Else

                query = (From Entity In Me._DataEntities.Products
                         Where (Entity.IsActive = 1) _
                         AndAlso Entity.Division.IsActive = 1 _
                         AndAlso Entity.Division.Client.IsActive = 1 _
                         AndAlso Entity.ClientCode = ClientCode _
                         AndAlso Entity.DivisionCode = DivisionCode
                         Order By Entity.Description
                         Select Entity)

            End If

            If ClientCode.Trim() <> "" Then

                query = query.Where(Function(Product) Product.ClientCode = ClientCode)

            End If
            If DivisionCode.Trim() <> "" Then

                query = query.Where(Function(Product) Product.DivisionCode = DivisionCode)

            End If
            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                query = query.Where(Function(Product) Product.Description.ToUpper().Contains(SearchValue.ToUpper()))

            End If

            Return query

        End Function
        Public Function GetProductsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Product
            Dim query As Global.AdvantageMobile.Product
            query = (From Entity In Me._DataEntities.Products
                     Join JobLog In Me._DataEntities.JobLogs
                     On Entity.Code Equals JobLog.ProductCode _
                     And Entity.ClientCode Equals JobLog.ClientCode _
                     And Entity.DivisionCode Equals JobLog.DivisionCode
                     Where JobLog.JobNumber = JobNumber
                     Order By Entity.Description
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
