Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace Repositories

    Public Class LookupRepository

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub

        Public Function SearchLookup(ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As ViewModels.LookupDisplayObject

            'objects
            Dim ResultQuery As System.Collections.IEnumerable = Nothing
            Dim LookupDisplayObject As ViewModels.LookupDisplayObject = Nothing
            Dim SecurityModule As AdvantageFramework.Security.Modules = Nothing

            LookupDisplayObject = New ViewModels.LookupDisplayObject

            SecurityModule = GetSecurityModule(LookupSearchCriteria.SecurityModule)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case LookupSearchCriteria.GetLookupType()

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Client

                            LookupDisplayObject = CreateLookupDisplayObject_Clients(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Division

                            LookupDisplayObject = CreateLookupDisplayObject_Divisions(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Product

                            LookupDisplayObject = CreateLookupDisplayObject_Products(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Job

                            LookupDisplayObject = CreateLookupDisplayObject_Jobs(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.JobComponent

                            LookupDisplayObject = CreateLookupDisplayObject_JobComponents(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Function

                            LookupDisplayObject = CreateLookupDisplayObject_Functions(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.FunctionCategory

                            LookupDisplayObject = CreateLookupDisplayObject_FunctionCategories(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.GeneralLedgerAccount

                            LookupDisplayObject = CreateLookupDisplayObject_GeneralLedgerAccounts(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Employee

                            If SecurityModule = AdvantageFramework.Security.Methods.Modules.ProjectManagement_Estimating Then

                                If LookupSearchCriteria.Function.FunctionType = "E" Or LookupSearchCriteria.Function.FunctionType = "" Then

                                    LookupDisplayObject = CreateLookupDisplayObject_Employees(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                                ElseIf LookupSearchCriteria.Function.FunctionType = "V" Then

                                    LookupDisplayObject = CreateLookupDisplayObject_Vendors(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                                Else

                                    LookupDisplayObject = CreateLookupDisplayObject_Employees(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                                End If

                            Else

                                LookupDisplayObject = CreateLookupDisplayObject_Employees(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                            End If

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Vendor

                            LookupDisplayObject = CreateLookupDisplayObject_Vendors(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.VendorContact

                            LookupDisplayObject = CreateLookupDisplayObject_VendorContacts(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.TaxCode

                            LookupDisplayObject = CreateLookupDisplayObject_Tax(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.ProductCategory

                            LookupDisplayObject = CreateLookupDisplayObject_ProductCategory(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.EmployeeTitle

                            LookupDisplayObject = CreateLookupDisplayObject_EmployeeTitles(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                        Case ViewModels.LookupSearchCriteria.LookupTypes.Assignment

                            LookupDisplayObject = CreateLookupDisplayObject_Assignment(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

                    End Select

                End Using

            End Using

            SearchLookup = LookupDisplayObject

        End Function
        Private Function GetSecurityModule(ByVal SecurityModuleID As String) As AdvantageFramework.Security.Modules

            'objects
            Dim SecurityModule As AdvantageFramework.Security.Modules = Nothing

            If IsNumeric(SecurityModuleID) Then

                If [Enum].IsDefined(GetType(AdvantageFramework.Security.Modules), CInt(SecurityModuleID)) Then

                    SecurityModule = CType(CInt(SecurityModuleID), AdvantageFramework.Security.Modules)

                End If

            End If

            GetSecurityModule = SecurityModule

        End Function

#Region " Lookup Types "

#Region " -- Client -- "

        Public Function CreateLookupDisplayObject_Clients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                          ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                          ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientName.ToString, "Name")

            LookupDisplayObject.Results = SearchClients(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Clients"

            CreateLookupDisplayObject_Clients = LookupDisplayObject

        End Function
        Public Function SearchClients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                      ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                ResultQuery = ResultQuery.Where(Function(Cl) Cl.Code = LookupSearchCriteria.JobComponent.ClientCode)

            End If

            If LookupSearchCriteria.JobComponent.IncludeInactive = False Then

                ResultQuery = ResultQuery.Where(Function(Cl) Cl.IsActive = 1)

            End If

            SearchClients = (From Item In ResultQuery
                             Select Item.Code,
                                        Item.Name).Select(Function(Cl) New ViewModels.LookupObjects.JobComponent With {.ClientCode = Cl.Code,
                                                                                                                       .ClientName = Cl.Name}).ToList

        End Function

#End Region

#Region " -- Division -- "

        Public Function CreateLookupDisplayObject_Divisions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientCode.ToString, "Client")

            End If

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.DivisionCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.DivisionName.ToString, "Name")

            LookupDisplayObject.Results = SearchDivisions(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Divisions"

            CreateLookupDisplayObject_Divisions = LookupDisplayObject

        End Function
        Public Function SearchDivisions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                ResultQuery = ResultQuery.Where(Function(Div) Div.ClientCode = LookupSearchCriteria.JobComponent.ClientCode)

            End If

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) Then

                ResultQuery = ResultQuery.Where(Function(Div) Div.DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode)

            End If

            If LookupSearchCriteria.JobComponent.IncludeInactive = False Then

                ResultQuery = ResultQuery.Where(Function(Div) Div.IsActive = 1)

            End If

            SearchDivisions = (From Item In ResultQuery
                               Select Item.DivisionCode,
                                      Item.DivisionName,
                                      Item.ClientCode,
                                      Item.ClientName).Select(Function(Div) New ViewModels.LookupObjects.JobComponent With {.ClientCode = Div.ClientCode,
                                                                                                                            .ClientName = Div.ClientName,
                                                                                                                            .DivisionCode = Div.DivisionCode,
                                                                                                                            .DivisionName = Div.DivisionName}).ToList

        End Function

#End Region

#Region " -- Employee -- "

        Public Function CreateLookupDisplayObject_Employees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Employee.Properties.EmployeeCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Employee.Properties.FullName.ToString, "Name")

            LookupDisplayObject.Results = SearchEmployees(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Employees"

            CreateLookupDisplayObject_Employees = LookupDisplayObject

        End Function
        Public Function SearchEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Select Case SecurityModule

                Case AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders

                    SearchEmployees = SearchEmployees_PurchaseOrders(DbContext, SecurityDbContext, LookupSearchCriteria)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Estimating

                    SearchEmployees = SearchEmployees_Estimates(DbContext, SecurityDbContext, LookupSearchCriteria)

                Case Else

                    If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then


                        ResultQuery = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(_Session, DbContext, SecurityDbContext)

                    Else

                        ResultQuery = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, _Session.UserCode)

                    End If

                    If LookupSearchCriteria.Employee IsNot Nothing Then

                        If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Employee.EmployeeCode) Then

                            ResultQuery = ResultQuery.Where(Function(Emp) Emp.Code = LookupSearchCriteria.Employee.EmployeeCode)

                        End If

                    End If

                    SearchEmployees = (From Item In ResultQuery
                                       Select Item.Code,
                                          Item.FirstName,
                                          Item.LastName,
                                          Item.MiddleInitial).Select(Function(Emp) New ViewModels.LookupObjects.Employee With {.EmployeeCode = Emp.Code,
                                                                                                                               .FirstName = Emp.FirstName,
                                                                                                                               .LastName = Emp.LastName,
                                                                                                                               .MiddleInitial = Emp.MiddleInitial}).ToList

            End Select

        End Function
        Private Function SearchEmployees_PurchaseOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Employees As Generic.IEnumerable(Of ViewModels.LookupObjects.Employee) = Nothing

            ResultQuery = AdvantageFramework.PurchaseOrders.LoadEmployees(_Session, DbContext, SecurityDbContext)

            If LookupSearchCriteria.Employee IsNot Nothing Then

                If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Employee.EmployeeCode) Then

                    ResultQuery = ResultQuery.Where(Function(Emp) Emp.Code = LookupSearchCriteria.Employee.EmployeeCode)

                End If

            End If

            Employees = (From Item In ResultQuery
                         Select Item.Code,
                                Item.FirstName,
                                Item.MiddleInitial,
                                Item.LastName,
                                Item.PurchaseOrderLimit).ToList.Select(Function(Emp) New ViewModels.LookupObjects.Employee With {.EmployeeCode = Emp.Code,
                                                                                                                                 .FirstName = Emp.FirstName,
                                                                                                                                 .MiddleInitial = Emp.MiddleInitial,
                                                                                                                                 .LastName = Emp.LastName,
                                                                                                                                 .ExtraData = New Generic.Dictionary(Of String, Object) From {{"PurchaseOrderLimit", Emp.PurchaseOrderLimit}}}).ToList

            SearchEmployees_PurchaseOrders = Employees

        End Function

        Private Function SearchEmployees_Estimates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ResultQueryVendors As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim UserEmployeeAccesses As String() = Nothing
            Dim Employees As Generic.IEnumerable(Of ViewModels.LookupObjects.Employee) = Nothing
            Dim Vendors As Generic.IEnumerable(Of ViewModels.LookupObjects.Vendor) = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing
            Dim Salesclass As String = Nothing
            Dim est As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As New DataTable
            Dim taxcode As String = ""
            Dim taxState As Decimal = 0
            Dim taxCounty As Decimal = 0
            Dim taxCity As Decimal = 0
            Dim taxResale As Integer = 0
            Dim taxResaleNbr As String = ""
            Dim functionNonBill As Integer = 0
            Dim functionTaxComm As Integer = 0
            Dim functionTaxCommOnly As Integer = 0
            Dim functiontaxflag As Integer
            Dim functionType As String = ""
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim feetime As Integer = 0
            Dim rate As Decimal = 0.0
            Dim markuppct As Decimal = 0.0
            Dim emptitleid As Integer = 0

            Dim qty As Decimal = 0.0
            Dim extamt As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim markupamt As Decimal = 0.0
            Dim linetotal As Decimal = 0.0
            Dim mucontamt As Decimal = 0.0
            Dim extnonresaletax As Decimal = 0.0
            Dim extstateresale As Decimal = 0.0
            Dim extcountyresale As Decimal = 0.0
            Dim extcityresale As Decimal = 0.0
            Dim extstatenonresale As Decimal = 0.0
            Dim extcountynonresale As Decimal = 0.0
            Dim extcitynonresale As Decimal = 0.0
            Dim extstatemarkup As Decimal = 0.0
            Dim extcountymarkup As Decimal = 0.0
            Dim extcitymarkup As Decimal = 0.0
            Dim extmucont As Decimal = 0.0
            Dim extstatecont As Decimal = 0.0
            Dim extcountycont As Decimal = 0.0
            Dim extcitycont As Decimal = 0.0
            Dim extnrcont As Decimal = 0.0
            Dim linetotalcont As Decimal = 0.0

            Dim SQL As New System.Text.StringBuilder
            Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
            Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
            Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
            Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
            Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
            Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
            Dim parameterTAX_COMM As New SqlParameter("@TAX_COMM", SqlDbType.SmallInt)
            Dim parameterTAX_COMM_ONLY As New SqlParameter("@TAX_COMM_ONLY", SqlDbType.SmallInt)
            Dim parameterEST_NONBILL_FLAG As New SqlParameter("@EST_NONBILL_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_COMM_FLAG As New SqlParameter("@EST_COMM_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_TAX_FLAG As New SqlParameter("@EST_TAX_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_FEE_FLAG As New SqlParameter("@FEE_TIME", SqlDbType.SmallInt)

            If LookupSearchCriteria.Function.FunctionType = "E" Or LookupSearchCriteria.Function.FunctionType = "" Then

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then


                    ResultQuery = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode)

                Else

                    ResultQuery = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                End If


                Try

                    UserEmployeeAccesses = (From Item In AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, DbContext.UserCode)
                                            Select Item.EmployeeCode).ToArray

                Catch ex As Exception
                    UserEmployeeAccesses = Nothing
                End Try

                If UserEmployeeAccesses IsNot Nothing AndAlso UserEmployeeAccesses.Count > 0 Then

                    ResultQuery = ResultQuery.Where(Function(Emp) UserEmployeeAccesses.Contains(Emp.Code))

                End If

                If LookupSearchCriteria.Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Employee.EmployeeCode) = False Then

                    If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Employee.EmployeeCode) Then

                        ResultQuery = ResultQuery.Where(Function(Emp) Emp.Code = LookupSearchCriteria.Employee.EmployeeCode)

                    End If

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    If LookupSearchCriteria.Employee.EmployeeCode <> "" Then
                        If LookupSearchCriteria.EmployeeTitle.EmployeeTitle = "" Then
                            LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                            emptitleid = If(AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID Is Nothing, 0, AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID)
                        Else
                            emptitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, LookupSearchCriteria.EmployeeTitle.EmployeeTitle).ID
                        End If
                        ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, Now.Date, emptitleid)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If


                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        ElseIf LookupSearchCriteria.Tax.TaxCode IsNot Nothing AndAlso LookupSearchCriteria.Tax.TaxCode <> "" Then
                            taxcode = BillingRate.TAX_CODE
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", 0)
                                fnccommflag = 1
                            End If
                        ElseIf LookupSearchCriteria.Estimate.EstimateCommissionPercent > 0 Then
                            markuppct = LookupSearchCriteria.Estimate.EstimateCommissionPercent
                        End If

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                        parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Employee.EmployeeCode
                        parameterEST_REV_RATE.Value = rate
                        parameterEST_REV_EXT_AMT.Value = 0
                        parameterEXT_MARKUP_AMT.Value = 0
                        parameterEXT_CONTINGENCY.Value = 0
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale
                        parameterTAX_COMM.Value = functionTaxComm
                        parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                        parameterEST_NONBILL_FLAG.Value = functionNonBill
                        parameterEST_COMM_FLAG.Value = fnccommflag
                        parameterEST_TAX_FLAG.Value = fnctaxflag
                        parameterEST_FEE_FLAG.Value = feetime

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                        SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                        SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                        'SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE,")
                        SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                        SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                        SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                        SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                        SQL.Append(" TAX_COMM = @TAX_COMM,")
                        SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                        SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                        SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                        SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                        SQL.Append(" FEE_TIME = @FEE_TIME")


                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                        If qty <> 0 Then
                            extamt = qty * rate
                            parameterEST_REV_EXT_AMT.Value = extamt
                        End If
                        If extamt <> 0 And markuppct <> 0 Then
                            markupamt = extamt * (markuppct / 100)
                            parameterEXT_MARKUP_AMT.Value = markupamt
                        End If
                        If extamt <> 0 Then
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markuppct <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        parameterEST_REV_COMM_PCT.Value = markuppct
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        ExtraData.Add("ExtendedAmount", extamt)
                        ExtraData.Add("Commission", markupamt)
                        ExtraData.Add("TaxAmount", Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero))
                        ExtraData.Add("LineTotal", linetotal)
                        ExtraData.Add("ContingencyAmount", linetotalcont)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        ' MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        MyCmd.Parameters.Add(parameterTAX_COMM)
                        MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                        MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                        MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                        MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                        MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using

                    End If

                ElseIf LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    If LookupSearchCriteria.Employee.EmployeeCode <> "" Then
                        If LookupSearchCriteria.EmployeeTitle.EmployeeTitle = "" Then
                            LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                            emptitleid = If(AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID Is Nothing, 0, AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID)
                        Else
                            emptitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, LookupSearchCriteria.EmployeeTitle.EmployeeTitle).ID
                        End If
                        ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, Now.Date, emptitleid)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If


                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        ElseIf LookupSearchCriteria.Tax.TaxCode IsNot Nothing AndAlso LookupSearchCriteria.Tax.TaxCode <> "" Then
                            taxcode = BillingRate.TAX_CODE
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", 0)
                                fnccommflag = 1
                            End If
                        ElseIf LookupSearchCriteria.Estimate.EstimateCommissionPercent > 0 Then
                            markuppct = LookupSearchCriteria.Estimate.EstimateCommissionPercent
                        End If

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                        parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Employee.EmployeeCode
                        parameterEST_REV_RATE.Value = rate
                        parameterEST_REV_EXT_AMT.Value = 0
                        parameterEXT_MARKUP_AMT.Value = 0
                        parameterEXT_CONTINGENCY.Value = 0
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale
                        parameterTAX_COMM.Value = functionTaxComm
                        parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                        parameterEST_NONBILL_FLAG.Value = functionNonBill
                        parameterEST_COMM_FLAG.Value = fnccommflag
                        parameterEST_TAX_FLAG.Value = fnctaxflag
                        parameterEST_FEE_FLAG.Value = feetime

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                        SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                        SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                        'SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE,")
                        SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                        SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                        SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                        SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                        SQL.Append(" TAX_COMM = @TAX_COMM,")
                        SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                        SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                        SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                        SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                        SQL.Append(" FEE_TIME = @FEE_TIME")


                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                        If qty <> 0 Then
                            extamt = qty * rate
                            parameterEST_REV_EXT_AMT.Value = extamt
                        End If
                        If extamt <> 0 And markuppct <> 0 Then
                            markupamt = extamt * (markuppct / 100)
                            parameterEXT_MARKUP_AMT.Value = markupamt
                        End If
                        If extamt <> 0 Then
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markuppct <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        parameterEST_REV_COMM_PCT.Value = markuppct
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        ExtraData.Add("ExtendedAmount", extamt)
                        ExtraData.Add("Commission", markupamt)
                        ExtraData.Add("TaxAmount", Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero))
                        ExtraData.Add("LineTotal", linetotal)
                        ExtraData.Add("ContingencyAmount", linetotalcont)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        ' MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        MyCmd.Parameters.Add(parameterTAX_COMM)
                        MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                        MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                        MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                        MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                        MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using

                    End If


                End If

                Employees = (From Item In ResultQuery
                             Select Item.Code,
                                    Item.FirstName,
                                    Item.MiddleInitial,
                                    Item.LastName,
                                    Item.Title).ToList.Select(Function(Emp) New ViewModels.LookupObjects.Employee With {.EmployeeCode = Emp.Code,
                                                                                                                                     .FirstName = Emp.FirstName,
                                                                                                                                     .MiddleInitial = Emp.MiddleInitial,
                                                                                                                                     .LastName = Emp.LastName,
                                                                                                                                     .EmployeeTitle = Emp.title,
                                                                                                                                     .ExtraData = ExtraData}).ToList

                SearchEmployees_Estimates = Employees

            ElseIf LookupSearchCriteria.Function.FunctionType = "V" Then

                If LookupSearchCriteria.Vendor.LimitbyDefaultFunction Then

                    ResultQueryVendors = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorByFunctionCode(DbContext, LookupSearchCriteria.Function.FunctionCode)

                Else

                    ResultQueryVendors = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)

                End If

                If Not LookupSearchCriteria.Vendor.IncludeMediaVendors Then

                    ResultQueryVendors = ResultQueryVendors.Where(Function(Ven) Ven.VendorCategory = "P")

                End If

                If LookupSearchCriteria.Vendor IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) = False Then

                    If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) Then

                        ResultQueryVendors = ResultQueryVendors.Where(Function(Ven) Ven.Code = LookupSearchCriteria.Vendor.VendorCode)

                    End If

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Vendor.VendorCode, Nothing)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If


                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", 0)
                                fnccommflag = 1
                            End If

                        End If

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                        parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Employee.EmployeeCode
                        parameterEST_REV_RATE.Value = rate
                        parameterEST_REV_EXT_AMT.Value = 0
                        parameterEXT_MARKUP_AMT.Value = 0
                        parameterEXT_CONTINGENCY.Value = 0
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale
                        parameterTAX_COMM.Value = functionTaxComm
                        parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                        parameterEST_NONBILL_FLAG.Value = functionNonBill
                        parameterEST_COMM_FLAG.Value = fnccommflag
                        parameterEST_TAX_FLAG.Value = fnctaxflag
                        parameterEST_FEE_FLAG.Value = feetime

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                        SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                        SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE,")
                        SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                        SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                        SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                        SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                        SQL.Append(" TAX_COMM = @TAX_COMM,")
                        SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                        SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                        SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                        SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                        SQL.Append(" FEE_TIME = @FEE_TIME")


                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                        If qty <> 0 Then
                            extamt = qty * rate
                            parameterEST_REV_EXT_AMT.Value = extamt
                        End If
                        If extamt <> 0 And markuppct <> 0 Then
                            markupamt = extamt * (markuppct / 100)
                            parameterEXT_MARKUP_AMT.Value = markupamt
                        End If
                        If extamt <> 0 Then
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markuppct <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        parameterEST_REV_COMM_PCT.Value = markuppct
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        'MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        MyCmd.Parameters.Add(parameterTAX_COMM)
                        MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                        MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                        MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                        MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                        MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using

                    End If

                End If

                Vendors = (From Item In ResultQueryVendors
                           Select Item.Code,
                                  Item.Name).ToList.Select(Function(Ven) New ViewModels.LookupObjects.Vendor With {.VendorCode = Ven.Code,
                                                                                                                         .VendorName = Ven.Name,
                                                                                                                         .ExtraData = ExtraData}).ToList

                SearchEmployees_Estimates = Vendors

            End If







        End Function
#End Region

#Region " -- EmployeeTitle -- "

        Public Function CreateLookupDisplayObject_EmployeeTitles(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.EmployeeTitle.Properties.EmployeeTitleID.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.EmployeeTitle.Properties.EmployeeTitle.ToString, "Name")

            LookupDisplayObject.Results = SearchEmployeeTitles(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "EmployeeTitles"

            CreateLookupDisplayObject_EmployeeTitles = LookupDisplayObject

        End Function
        Public Function SearchEmployeeTitles(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Select Case SecurityModule

                Case AdvantageFramework.Security.Modules.ProjectManagement_Estimating

                    SearchEmployeeTitles = SearchEmployeeTitles_Estimates(DbContext, SecurityDbContext, LookupSearchCriteria)


            End Select

        End Function

        Private Function SearchEmployeeTitles_Estimates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTitle) = Nothing
            Dim ResultQueryVendors As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim UserEmployeeAccesses As String() = Nothing
            Dim EmployeeTitles As Generic.IEnumerable(Of ViewModels.LookupObjects.EmployeeTitle) = Nothing
            Dim Vendors As Generic.IEnumerable(Of ViewModels.LookupObjects.Vendor) = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing
            Dim Salesclass As String = Nothing
            Dim est As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As New DataTable
            Dim taxcode As String = ""
            Dim taxState As Decimal = 0
            Dim taxCounty As Decimal = 0
            Dim taxCity As Decimal = 0
            Dim taxResale As Integer = 0
            Dim taxResaleNbr As String = ""
            Dim functionNonBill As Integer = 0
            Dim functionTaxComm As Integer = 0
            Dim functionTaxCommOnly As Integer = 0
            Dim functiontaxflag As Integer
            Dim functionType As String = ""
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim feetime As Integer = 0
            Dim rate As Decimal = 0.0
            Dim markuppct As Decimal = 0.0
            Dim emptitleid As Integer = 0

            Dim qty As Decimal = 0.0
            Dim extamt As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim markupamt As Decimal = 0.0
            Dim linetotal As Decimal = 0.0
            Dim mucontamt As Decimal = 0.0
            Dim extnonresaletax As Decimal = 0.0
            Dim extstateresale As Decimal = 0.0
            Dim extcountyresale As Decimal = 0.0
            Dim extcityresale As Decimal = 0.0
            Dim extstatenonresale As Decimal = 0.0
            Dim extcountynonresale As Decimal = 0.0
            Dim extcitynonresale As Decimal = 0.0
            Dim extstatemarkup As Decimal = 0.0
            Dim extcountymarkup As Decimal = 0.0
            Dim extcitymarkup As Decimal = 0.0
            Dim extmucont As Decimal = 0.0
            Dim extstatecont As Decimal = 0.0
            Dim extcountycont As Decimal = 0.0
            Dim extcitycont As Decimal = 0.0
            Dim extnrcont As Decimal = 0.0
            Dim linetotalcont As Decimal = 0.0

            Dim SQL As New System.Text.StringBuilder
            Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
            Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
            Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
            Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
            Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
            Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
            Dim parameterTAX_COMM As New SqlParameter("@TAX_COMM", SqlDbType.SmallInt)
            Dim parameterTAX_COMM_ONLY As New SqlParameter("@TAX_COMM_ONLY", SqlDbType.SmallInt)
            Dim parameterEST_NONBILL_FLAG As New SqlParameter("@EST_NONBILL_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_COMM_FLAG As New SqlParameter("@EST_COMM_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_TAX_FLAG As New SqlParameter("@EST_TAX_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_FEE_FLAG As New SqlParameter("@FEE_TIME", SqlDbType.SmallInt)
            Dim parameterEMP_TITLE_ID As New SqlParameter("@EMPLOYEE_TITLE_ID", SqlDbType.Int)


            If LookupSearchCriteria.Function.FunctionType = "E" Or LookupSearchCriteria.Function.FunctionType = "" Then

                ResultQuery = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext)

            'Try

            '    UserEmployeeAccesses = (From Item In AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, DbContext.UserCode)
            '                            Select Item.EmployeeCode).ToArray

            'Catch ex As Exception
            '    UserEmployeeAccesses = Nothing
            'End Try

            'If UserEmployeeAccesses IsNot Nothing AndAlso UserEmployeeAccesses.Count > 0 Then

            '    ResultQuery = ResultQuery.Where(Function(Emp) UserEmployeeAccesses.Contains(Emp.Code))

            'End If

            If LookupSearchCriteria.EmployeeTitle IsNot Nothing AndAlso LookupSearchCriteria.EmployeeTitle.EmployeeTitleID = 0 AndAlso LookupSearchCriteria.EmployeeTitle.EmployeeTitle <> "" Then
                Try
                    emptitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, LookupSearchCriteria.EmployeeTitle.EmployeeTitle).ID
                        If emptitleid <> 0 Then
                            LookupSearchCriteria.EmployeeTitle.EmployeeTitleID = emptitleid
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    emptitleid = LookupSearchCriteria.EmployeeTitle.EmployeeTitleID
                End If

                If LookupSearchCriteria.EmployeeTitle IsNot Nothing AndAlso LookupSearchCriteria.EmployeeTitle.EmployeeTitleID <> 0 Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.EmployeeTitle.EmployeeTitleID <> 0 Then

                        ResultQuery = ResultQuery.Where(Function(Emp) Emp.ID = LookupSearchCriteria.EmployeeTitle.EmployeeTitleID)

                        ExtraData.Add("EmployeeTitleID", LookupSearchCriteria.EmployeeTitle.EmployeeTitleID)

                    End If

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    'If LookupSearchCriteria.Employee.EmployeeCode <> "" Then
                    '    LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                    '    ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    'End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, Now.Date, LookupSearchCriteria.EmployeeTitle.EmployeeTitleID)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If


                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        ElseIf LookupSearchCriteria.Tax.TaxCode IsNot Nothing AndAlso LookupSearchCriteria.Tax.TaxCode <> "" Then
                            taxcode = BillingRate.TAX_CODE
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", 0)
                                fnccommflag = 1
                            End If
                        ElseIf LookupSearchCriteria.Estimate.EstimateCommissionPercent > 0 Then
                            markuppct = LookupSearchCriteria.Estimate.EstimateCommissionPercent
                        End If

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                        parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Employee.EmployeeCode
                        parameterEST_REV_RATE.Value = rate
                        parameterEST_REV_EXT_AMT.Value = 0
                        parameterEXT_MARKUP_AMT.Value = 0
                        parameterEXT_CONTINGENCY.Value = 0
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale
                        parameterTAX_COMM.Value = functionTaxComm
                        parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                        parameterEST_NONBILL_FLAG.Value = functionNonBill
                        parameterEST_COMM_FLAG.Value = fnccommflag
                        parameterEST_TAX_FLAG.Value = fnctaxflag
                        parameterEST_FEE_FLAG.Value = feetime
                        parameterEMP_TITLE_ID.Value = emptitleid

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                        SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                        SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                        'SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE,")
                        SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                        SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                        SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                        SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                        SQL.Append(" TAX_COMM = @TAX_COMM,")
                        SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                        SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                        SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                        SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                        SQL.Append(" FEE_TIME = @FEE_TIME,")
                        SQL.Append(" EMPLOYEE_TITLE_ID = @EMPLOYEE_TITLE_ID")


                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                        If qty <> 0 Then
                            extamt = qty * rate
                            parameterEST_REV_EXT_AMT.Value = extamt
                        End If
                        If extamt <> 0 And markuppct <> 0 Then
                            markupamt = extamt * (markuppct / 100)
                            parameterEXT_MARKUP_AMT.Value = markupamt
                        End If
                        If extamt <> 0 Then
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markuppct <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        parameterEST_REV_COMM_PCT.Value = markuppct
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        ExtraData.Add("ExtendedAmount", extamt)
                        ExtraData.Add("Commission", markupamt)
                        ExtraData.Add("TaxAmount", Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero))
                        ExtraData.Add("LineTotal", linetotal)
                        ExtraData.Add("ContingencyAmount", linetotalcont)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        ' MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        MyCmd.Parameters.Add(parameterTAX_COMM)
                        MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                        MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                        MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                        MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                        MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                        MyCmd.Parameters.Add(parameterEMP_TITLE_ID)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using

                    End If

                ElseIf LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    'If LookupSearchCriteria.Employee.EmployeeCode <> "" Then
                    '    LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                    '    ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    'End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, Now.Date, LookupSearchCriteria.EmployeeTitle.EmployeeTitleID)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If


                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        ElseIf LookupSearchCriteria.Tax.TaxCode IsNot Nothing AndAlso LookupSearchCriteria.Tax.TaxCode <> "" Then
                            taxcode = BillingRate.TAX_CODE
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", 0)
                                fnccommflag = 1
                            End If
                        ElseIf LookupSearchCriteria.Estimate.EstimateCommissionPercent > 0 Then
                            markuppct = LookupSearchCriteria.Estimate.EstimateCommissionPercent
                        End If

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                        parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Employee.EmployeeCode
                        parameterEST_REV_RATE.Value = rate
                        parameterEST_REV_EXT_AMT.Value = 0
                        parameterEXT_MARKUP_AMT.Value = 0
                        parameterEXT_CONTINGENCY.Value = 0
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale
                        parameterTAX_COMM.Value = functionTaxComm
                        parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                        parameterEST_NONBILL_FLAG.Value = functionNonBill
                        parameterEST_COMM_FLAG.Value = fnccommflag
                        parameterEST_TAX_FLAG.Value = fnctaxflag
                        parameterEST_FEE_FLAG.Value = feetime
                        parameterEMP_TITLE_ID.Value = emptitleid

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                        SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                        SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                        'SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE,")
                        SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                        SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                        SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                        SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                        SQL.Append(" TAX_COMM = @TAX_COMM,")
                        SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                        SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                        SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                        SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                        SQL.Append(" FEE_TIME = @FEE_TIME,")
                        SQL.Append(" EMPLOYEE_TITLE_ID = @EMPLOYEE_TITLE_ID")


                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                        If qty <> 0 Then
                            extamt = qty * rate
                            parameterEST_REV_EXT_AMT.Value = extamt
                        End If
                        If extamt <> 0 And markuppct <> 0 Then
                            markupamt = extamt * (markuppct / 100)
                            parameterEXT_MARKUP_AMT.Value = markupamt
                        End If
                        If extamt <> 0 Then
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markuppct <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        parameterEST_REV_COMM_PCT.Value = markuppct
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        ExtraData.Add("ExtendedAmount", extamt)
                        ExtraData.Add("Commission", markupamt)
                        ExtraData.Add("TaxAmount", Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero))
                        ExtraData.Add("LineTotal", linetotal)
                        ExtraData.Add("ContingencyAmount", linetotalcont)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        ' MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        MyCmd.Parameters.Add(parameterTAX_COMM)
                        MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                        MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                        MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                        MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                        MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                        MyCmd.Parameters.Add(parameterEMP_TITLE_ID)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using


                    End If

                End If


                EmployeeTitles = (From Item In ResultQuery
                                  Select Item.ID,
                                Item.Description).ToList.Select(Function(Emp) New ViewModels.LookupObjects.EmployeeTitle With {.EmployeeTitleID = Emp.ID,
                                                                                                                                 .EmployeeTitle = Emp.Description,
                                                                                                                                 .ExtraData = ExtraData}).ToList

                SearchEmployeeTitles_Estimates = EmployeeTitles

            End If


        End Function


#End Region

#Region "  -- Function -- "

        Public Function CreateLookupDisplayObject_Functions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.FunctionCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.FunctionDescription.ToString, "Description")

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.CPMFlag.ToString, "CPM")

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_Estimating Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.FunctionType.ToString, "Type")

            End If

            LookupDisplayObject.Results = SearchFunctions(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Function"

            CreateLookupDisplayObject_Functions = LookupDisplayObject

        End Function
        Public Function CreateLookupDisplayObject_FunctionCategories(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                    ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                    ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.FunctionCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Function.Properties.FunctionDescription.ToString, "Description")

            LookupDisplayObject.Results = SearchFunctionCategories(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Function Category"

            CreateLookupDisplayObject_FunctionCategories = LookupDisplayObject

        End Function
        Public Function SearchFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function) = Nothing

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                SearchFunctions = SearchFunctions_PurchaseOrder(DbContext, LookupSearchCriteria)

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.Employee_ExpenseReports Then

                SearchFunctions = SearchFunctions_ExpenseReport(DbContext, LookupSearchCriteria)

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_Estimating Then

                SearchFunctions = SearchFunctions_Estimate(DbContext, LookupSearchCriteria)

            Else

                ResultQuery = AdvantageFramework.Database.Procedures.Function.Load(DbContext)

                If LookupSearchCriteria.Function.IncludeInactive = False Then

                    ResultQuery = ResultQuery.Where(Function(Fnc) Fnc.IsInactive Is Nothing OrElse Fnc.IsInactive = 0)

                End If

                SearchFunctions = (From Item In ResultQuery
                                   Select Item.Code,
                                          Item.Description,
                                          Item.CPMFlag).ToList.Select(Function(Fnc) New ViewModels.LookupObjects.Function With {.FunctionCode = Fnc.Code,
                                                                                                                                .FunctionDescription = Fnc.Description,
                                                                                                                                .CPMFlag = CBool(Fnc.CPMFlag.GetValueOrDefault(0))}).ToList


            End If

        End Function
        Public Function SearchFunctionCategories(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                       ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                       ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            Dim Results As New List(Of ViewModels.LookupObjects.FunctionCategory)
            Dim ParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim ParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim ParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim BillingRestrictedFunctionCodes As Generic.List(Of String)
            Dim JobNumber As Integer = 0

            Using SQLConnection As New SqlConnection(_Session.ConnectionString)

                If (String.IsNullOrEmpty(LookupSearchCriteria.FunctionCategory.JobCode) = False) Then

                    Dim ClientCode As String = String.Empty
                    Dim LimitFunctionsByBillingRate As Boolean = False

                    If LookupSearchCriteria.JobComponent IsNot Nothing AndAlso LookupSearchCriteria.JobComponent.JobNumber IsNot Nothing Then
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber
                    End If
                    If LookupSearchCriteria.Employee.EmployeeCode = "" Then
                        ParameterEmployeeCode = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 100) With {.Value = LookupSearchCriteria.FunctionCategory.EmployeeCode}
                    Else
                        ParameterEmployeeCode = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 100) With {.Value = LookupSearchCriteria.Employee.EmployeeCode}
                    End If
                    If JobNumber = 0 Then
                        ParameterJobNumber = New SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = 0}
                    Else
                        ParameterJobNumber = New SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber}
                    End If

                    ParameterClientCode = New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6) With {.Value = System.DBNull.Value}

                    Using SQLCommand As New SqlCommand

                        With SQLCommand

                            .Connection = SQLConnection
                            .Connection.Open()
                            .CommandText = "usp_wv_dd_GetFunctions_ByEmpCode"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(ParameterEmployeeCode)
                            .Parameters.Add(ParameterJobNumber)
                            .Parameters.Add(ParameterClientCode)

                        End With

                        Using Reader As SqlDataReader = SQLCommand.ExecuteReader()

                            While Reader.Read()

                                Results.Add(New ViewModels.LookupObjects.FunctionCategory() With {.FunctionCode = Reader("Code"), .FunctionDescription = Reader("DescriptionOnly")})

                            End While

                        End Using

                    End Using

                Else

                    Using SQLCommand As New SqlCommand

                        With SQLCommand

                            .Connection = SQLConnection
                            .Connection.Open()
                            .CommandText = "usp_wv_dd_GetCategories"
                            .CommandType = CommandType.StoredProcedure

                        End With

                        Using Reader As SqlDataReader = SQLCommand.ExecuteReader()

                            While Reader.Read()

                                Results.Add(New ViewModels.LookupObjects.FunctionCategory() With {.FunctionCode = Reader("Code"), .FunctionDescription = Reader("DescriptionOnly")})

                            End While

                        End Using

                    End Using

                End If

            End Using

            If (String.IsNullOrEmpty(LookupSearchCriteria.FunctionCategory.SearchText) = False) Then

                Results = (From r In Results
                           Where r.FunctionCode.ToLower().Contains(LookupSearchCriteria.FunctionCategory.SearchText.ToLower()) _
                           Or r.FunctionDescription.ToLower().Contains(LookupSearchCriteria.FunctionCategory.SearchText.ToLower())
                           Select r).ToList()

            End If

            SearchFunctionCategories = Results

        End Function
        Private Function SearchFunctions_PurchaseOrder(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim GeneralLedgerAccountCode As String = ""
            Dim GeneralLedgerAccountDescription As String = ""

            ResultQuery = AdvantageFramework.PurchaseOrders.LoadFunctions(DbContext)

            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                ResultQuery = ResultQuery.Where(Function(Fnc) Fnc.Code = LookupSearchCriteria.Function.FunctionCode)

            End If

            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, LookupSearchCriteria.Function.FunctionCode)

                If [Function] IsNot Nothing Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.Employee IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.AllowPOGLSelection.GetValueOrDefault(0) = 1 Then

                                If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) AndAlso
                                   String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ProductCode) AndAlso LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) <= 0 AndAlso
                                   LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) <= 0 Then

                                    If String.IsNullOrWhiteSpace([Function].OverheadGLACode) = False Then

                                        If (From Item In AdvantageFramework.PurchaseOrders.LoadGeneralLedgerAccounts(DbContext, _Session, Employee)
                                            Where Item.Code = [Function].OverheadGLACode
                                            Select Item).Any Then

                                            GeneralLedgerAccountCode = [Function].OverheadGLACode

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        BillingRate = AdvantageFramework.PurchaseOrders.LoadBillingRate(DbContext, [Function].Code, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode,
                                                                                                LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0), LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0))

                        If BillingRate IsNot Nothing Then

                            If BillingRate.BILLING_RATE.HasValue Then

                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)

                            End If

                        End If

                    End If

                    If Not [String].IsNullOrWhiteSpace(GeneralLedgerAccountCode) Then

                        GeneralLedgerAccountDescription = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerAccountCode).Description

                    End If

                    ExtraData.Add("GeneralLedgerAccountCode", GeneralLedgerAccountCode)
                    ExtraData.Add("GeneralLedgerAccountDescription", GeneralLedgerAccountDescription)

                End If

            End If

            SearchFunctions_PurchaseOrder = (From Item In ResultQuery
                                             Select Item.Code,
                                                    Item.Description,
                                                    Item.CPMFlag).ToList.Select(Function(Fnc) New ViewModels.LookupObjects.Function With {.FunctionCode = Fnc.Code,
                                                                                                                                          .FunctionDescription = Fnc.Description,
                                                                                                                                          .CPMFlag = CBool(Fnc.CPMFlag.GetValueOrDefault(0)),
                                                                                                                                                  .ExtraData = ExtraData}).ToList

        End Function
        Private Function SearchFunctions_ExpenseReport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim GeneralLedgerAccountCode As String = ""
            Dim GeneralLedgerAccountDescription As String = ""
            Dim EffectiveDate As Date? = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing

            ResultQuery = From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                          Where Item.EmployeeExpenseFlag = 1
                          Select Item

            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                ResultQuery = ResultQuery.Where(Function(Fnc) Fnc.Code = LookupSearchCriteria.Function.FunctionCode)

            End If

            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, LookupSearchCriteria.Function.FunctionCode)

                If [Function] IsNot Nothing Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    Try

                        If LookupSearchCriteria.Function.ExtraData.ContainsKey("EffectiveDate") Then

                            EffectiveDate = CDate(LookupSearchCriteria.Function.ExtraData("EffectiveDate"))

                        End If

                    Catch ex As Exception
                        EffectiveDate = Nothing
                    End Try

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, [Function].Code, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Nothing, Nothing, EffectiveDate)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then

                            ExtraData.Add("Rate", BillingRate.BILLING_RATE)

                        End If

                        If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            ExtraData.Add("NonBillable", CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0)))

                        Else

                            ExtraData.Add("NonBillable", False)

                        End If

                    End If

                End If

            End If

            SearchFunctions_ExpenseReport = (From Item In ResultQuery
                                             Select Item.Code,
                                                    Item.Description).ToList.Select(Function(Fnc) New ViewModels.LookupObjects.Function With {.FunctionCode = Fnc.Code,
                                                                                                                                          .FunctionDescription = Fnc.Description,
                                                                                                                                          .ExtraData = ExtraData}).ToList

        End Function

        Private Function SearchFunctions_Estimate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim GeneralLedgerAccountCode As String = ""
            Dim GeneralLedgerAccountDescription As String = ""
            Dim EffectiveDate As Date? = Date.Now
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing
            Dim Salesclass As String = Nothing
            Dim est As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As New DataTable
            Dim taxcode As String = ""
            Dim taxState As Decimal = 0
            Dim taxCounty As Decimal = 0
            Dim taxCity As Decimal = 0
            Dim taxResale As Integer = 0
            Dim taxResaleNbr As String = ""
            Dim functionNonBill As Integer = 0
            Dim functionTaxComm As Integer = 0
            Dim functionTaxCommOnly As Integer = 0
            Dim functiontaxflag As Integer
            Dim functionType As String = ""
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim feetime As Integer = 0
            Dim rate As Decimal = 0.0
            Dim markuppct As Decimal = 0.0
            Dim fnccpmflag As Integer
            Dim estmarkuppct As Decimal = 0
            Dim jobmarkuppct As Decimal = 0
            Dim emptitleid As Integer = 0
            Dim BillingRestrictedFunctionCodes As Generic.List(Of String)
            Dim LimitFunctionsByBillingRate As Boolean = False

            ResultQuery = AdvantageFramework.Estimate.LoadFunctions(DbContext)



            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                ResultQuery = ResultQuery.Where(Function(Fnc) Fnc.Code = LookupSearchCriteria.Function.FunctionCode)

            End If

            If LookupSearchCriteria.Function IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Function.FunctionCode) = False Then

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, LookupSearchCriteria.Function.FunctionCode)

                If [Function] IsNot Nothing Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    Dim dr As SqlClient.SqlDataReader
                    Dim max As Integer
                    Dim sort As Integer
                    dr = est.GetEstimateQuoteInfo(LookupSearchCriteria.Estimate.EstimateNumber, LookupSearchCriteria.Estimate.EstimateComponentNumber, LookupSearchCriteria.Estimate.EstimateQuoteNumber, LookupSearchCriteria.Estimate.EstimateRevisionNumber)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            LookupSearchCriteria.Estimate.EstimateContingencyPct = dr("PRD_CONT_PCT")
                            ExtraData.Add("ContingencyPercent", dr("PRD_CONT_PCT"))
                            estmarkuppct = dr("EST_MARKUP_PCT")
                            jobmarkuppct = dr("JOB_MARKUP_PCT")
                            'If IsDBNull(dr("BLENDED_TIME_RATE")) = False Then
                            '    blendedrate = dr("BLENDED_TIME_RATE")
                            'Else
                            '    blendedrate = -1.0
                            'End If
                        Loop
                    End If
                    dr.Close()

                    If LookupSearchCriteria.Employee.EmployeeCode <> "" And LookupSearchCriteria.EmployeeTitle.EmployeeTitle IsNot Nothing And [Function].Type <> "V" Then
                        If LookupSearchCriteria.EmployeeTitle.EmployeeTitle = "" Then
                            LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                            emptitleid = If(AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID Is Nothing, 0, AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID)
                        Else
                            emptitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, LookupSearchCriteria.EmployeeTitle.EmployeeTitle).ID
                        End If
                        ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    Else

                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, [Function].Code, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, EffectiveDate, emptitleid)

                    If BillingRate IsNot Nothing Then

                        If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                            If BillingRate.BILLING_RATE IsNot Nothing Then
                                ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                                rate = BillingRate.BILLING_RATE
                            Else
                                ExtraData.Add("Rate", 0)
                            End If

                        End If
                        If BillingRate.NOBILL_FLAG IsNot Nothing Then
                            ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                            functionNonBill = BillingRate.NOBILL_FLAG
                        Else
                            ExtraData.Add("NoBillFlag", 0)
                        End If


                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If

                        ExtraData.Add("SuppliedBy", "")
                        ExtraData.Add("EmployeeTitle", "")

                        If BillingRate.TAX_CODE IsNot Nothing Then
                            ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                            taxcode = BillingRate.TAX_CODE
                            fnctaxflag = 1
                            dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                            If dt.Rows.Count > 0 Then
                                ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                                ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                                ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                                End If
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                        Else
                            ExtraData.Add("TaxCode", "")
                            ExtraData.Add("TaxState", 0)
                            ExtraData.Add("TaxCounty", 0)
                            ExtraData.Add("TaxCity", 0)
                            ExtraData.Add("TaxResale", 0)
                            taxcode = ""
                            fnctaxflag = 0
                        End If

                        If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                            If BillingRate.COMM IsNot Nothing Then
                                ExtraData.Add("CommissionPercent", BillingRate.COMM)
                                markuppct = BillingRate.COMM
                                If BillingRate.COMM = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                ExtraData.Add("CommissionPercent", estmarkuppct)
                                fnccommflag = 1
                            End If

                        End If

                        functionType = [Function].Type
                        ExtraData.Add("CPM", [Function].CPMFlag)

                        If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                            feetime = BillingRate.FEE_TIME_FLAG
                        End If

                        If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then
                            Dim qty As Decimal = 0.0
                            Dim extamt As Decimal = 0.0
                            Dim contamt As Decimal = 0.0
                            Dim contpct As Decimal = 0.0
                            Dim markupamt As Decimal = 0.0
                            Dim linetotal As Decimal = 0.0
                            Dim mucontamt As Decimal = 0.0
                            Dim extnonresaletax As Decimal = 0.0
                            Dim extstateresale As Decimal = 0.0
                            Dim extcountyresale As Decimal = 0.0
                            Dim extcityresale As Decimal = 0.0
                            Dim extstatenonresale As Decimal = 0.0
                            Dim extcountynonresale As Decimal = 0.0
                            Dim extcitynonresale As Decimal = 0.0
                            Dim extstatemarkup As Decimal = 0.0
                            Dim extcountymarkup As Decimal = 0.0
                            Dim extcitymarkup As Decimal = 0.0
                            Dim extmucont As Decimal = 0.0
                            Dim extstatecont As Decimal = 0.0
                            Dim extcountycont As Decimal = 0.0
                            Dim extcitycont As Decimal = 0.0
                            Dim extnrcont As Decimal = 0.0
                            Dim linetotalcont As Decimal = 0.0

                            Dim SQL As New System.Text.StringBuilder
                            Dim parameterFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
                            Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                            Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                            Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                            Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                            Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                            Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                            Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                            Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                            Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                            Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                            Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                            Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                            Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                            Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                            Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
                            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
                            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
                            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
                            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
                            Dim parameterTAX_COMM As New SqlParameter("@TAX_COMM", SqlDbType.SmallInt)
                            Dim parameterTAX_COMM_ONLY As New SqlParameter("@TAX_COMM_ONLY", SqlDbType.SmallInt)
                            Dim parameterEST_NONBILL_FLAG As New SqlParameter("@EST_NONBILL_FLAG", SqlDbType.SmallInt)
                            Dim parameterFNC_TYPE As New SqlParameter("@EST_FNC_TYPE", SqlDbType.VarChar)
                            Dim parameterEST_CPM_FLAG As New SqlParameter("@EST_CPM_FLAG", SqlDbType.SmallInt)
                            Dim parameterEST_COMM_FLAG As New SqlParameter("@EST_COMM_FLAG", SqlDbType.SmallInt)
                            Dim parameterEST_TAX_FLAG As New SqlParameter("@EST_TAX_FLAG", SqlDbType.SmallInt)
                            Dim parameterEST_FEE_FLAG As New SqlParameter("@FEE_TIME", SqlDbType.SmallInt)
                            Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar, 6)

                            parameterFNC_CODE.Value = LookupSearchCriteria.Function.FunctionCode
                            parameterEST_REV_RATE.Value = rate
                            parameterEST_REV_EXT_AMT.Value = 0
                            parameterEXT_MARKUP_AMT.Value = 0
                            parameterEXT_CONTINGENCY.Value = 0
                            parameterEXT_MU_CONT.Value = 0
                            parameterLINE_TOTAL.Value = 0
                            parameterLINE_TOTAL_CONT.Value = 0
                            parameterEXT_STATE_RESALE.Value = 0
                            parameterEXT_COUNTY_RESALE.Value = 0
                            parameterEXT_CITY_RESALE.Value = 0
                            parameterEXT_STATE_CONT.Value = 0
                            parameterEXT_COUNTY_CONT.Value = 0
                            parameterEXT_CITY_CONT.Value = 0
                            parameterEXT_NONRESALE_TAX.Value = 0
                            parameterEXT_NR_CONT.Value = 0
                            parameterTAX_STATE_PCT.Value = taxState
                            parameterTAX_COUNTY_PCT.Value = taxCounty
                            parameterTAX_CITY_PCT.Value = taxCity
                            parameterTAX_RESALE.Value = taxResale
                            parameterTAX_COMM.Value = functionTaxComm
                            parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                            parameterEST_NONBILL_FLAG.Value = functionNonBill
                            parameterFNC_TYPE.Value = functionType
                            parameterEST_CPM_FLAG.Value = [Function].CPMFlag
                            parameterEST_COMM_FLAG.Value = fnccommflag
                            parameterEST_TAX_FLAG.Value = fnctaxflag
                            parameterEST_FEE_FLAG.Value = feetime
                            parameterEST_REV_SUP_BY_CDE.Value = ""

                            SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                            SQL.Append(" FNC_CODE = @FNC_CODE,")
                            SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                            SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                            SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                            SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                            SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                            SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                            SQL.Append(" TAX_CODE = @TAX_CODE,")
                            SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                            SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                            SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                            SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                            SQL.Append(" TAX_COMM = @TAX_COMM,")
                            SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                            SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                            SQL.Append(" EST_FNC_TYPE = @EST_FNC_TYPE,")
                            SQL.Append(" EST_CPM_FLAG = @EST_CPM_FLAG,")
                            SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                            SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                            SQL.Append(" FEE_TIME = @FEE_TIME,")
                            SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE")


                            qty = LookupSearchCriteria.Estimate.EstimateQuantity
                            contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                            If qty <> 0 Then
                                'If [Function].CPMFlag = 1 Then
                                '    extamt = (qty / 1000) * rate
                                '    parameterEST_REV_EXT_AMT.Value = extamt
                                'Else
                                extamt = qty * rate
                                parameterEST_REV_EXT_AMT.Value = extamt
                                'End If
                            End If
                            If extamt <> 0 And markuppct <> 0 Then
                                markupamt = extamt * (markuppct / 100)
                                parameterEXT_MARKUP_AMT.Value = markupamt
                            End If
                            If extamt <> 0 Then
                                If contpct <> 0 Then
                                    contamt = extamt * (contpct / 100)
                                    extmucont = markupamt * (contpct / 100)
                                End If
                                If markuppct <> 0 Then
                                    linetotalcont += (markupamt * (contpct / 100))
                                End If
                                parameterEXT_CONTINGENCY.Value = contamt
                                parameterEXT_MU_CONT.Value = extmucont
                            End If

                            parameterEST_REV_COMM_PCT.Value = markuppct
                            parameterTAX_CODE.Value = taxcode

                            If taxcode <> "" Then
                                If taxResale = 1 Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If functionTaxComm = 1 Then
                                        If markupamt > 0 Then
                                            extstatemarkup = markupamt * (taxState / 100)
                                            extcountymarkup = markupamt * (taxCounty / 100)
                                            extcitymarkup = markupamt * (taxCity / 100)
                                        End If
                                    End If
                                    extstateresale += extstatemarkup
                                    extcountyresale += extcountymarkup
                                    extcityresale += extcitymarkup
                                    parameterEXT_STATE_RESALE.Value = extstateresale
                                    parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                    parameterEXT_CITY_RESALE.Value = extcityresale
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        Else
                                            extstatecont = contamt * (taxState / 100)
                                            extcountycont = contamt * (taxCounty / 100)
                                            extcitycont = contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                    End If
                                    SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                End If
                                If taxResale <> 1 Then
                                    If functionType = "V" Then
                                        If functionTaxCommOnly <> 1 Then
                                            extstatenonresale = extamt * (taxState / 100)
                                            extcountynonresale = extamt * (taxCounty / 100)
                                            extcitynonresale = extamt * (taxCity / 100)
                                            extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                            Dim trstate As Decimal = extamt * (taxState / 100)
                                            Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                            Dim trcity As Decimal = extamt * (taxCity / 100)
                                            linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                            parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                            SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                        End If
                                        If contamt > 0 Then
                                            If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                                extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                            ElseIf functionTaxComm = 1 Then
                                                extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                            End If
                                            parameterEXT_NR_CONT.Value = extnrcont
                                            SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                        End If
                                    ElseIf functionType = "E" Or functionType = "I" Then
                                        If functionTaxCommOnly <> 1 Then
                                            extstateresale = extamt * (taxState / 100)
                                            extcountyresale = extamt * (taxCounty / 100)
                                            extcityresale = extamt * (taxCity / 100)
                                        End If
                                        If contamt > 0 Then
                                            If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                                extstatecont = extmucont * (taxState / 100)
                                                extcountycont = extmucont * (taxCounty / 100)
                                                extcitycont = extmucont * (taxCity / 100)
                                            ElseIf functionTaxComm = "1" Then
                                                extstatecont = (contamt + extmucont) * (taxState / 100)
                                                extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                                extcitycont = (contamt + extmucont) * (taxCity / 100)
                                            End If
                                            parameterEXT_STATE_CONT.Value = extstatecont
                                            parameterEXT_COUNTY_CONT.Value = extcountycont
                                            parameterEXT_CITY_CONT.Value = extcitycont
                                            SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                        End If
                                    End If
                                    If functionTaxComm = 1 Then
                                        If markupamt > 0 Then
                                            extstatemarkup = markupamt * (taxState / 100)
                                            extcountymarkup = markupamt * (taxCounty / 100)
                                            extcitymarkup = markupamt * (taxCity / 100)
                                        End If
                                    End If
                                    extstateresale += extstatemarkup
                                    extcountyresale += extcountymarkup
                                    extcityresale += extcitymarkup
                                    parameterEXT_STATE_RESALE.Value = extstateresale
                                    parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                    parameterEXT_CITY_RESALE.Value = extcityresale
                                    SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                                End If
                            End If

                            linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                            linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                            SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                            parameterLINE_TOTAL.Value = linetotal
                            SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                            parameterLINE_TOTAL_CONT.Value = linetotalcont
                            With SQL
                                .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                            End With

                            Dim EstNumber As Integer = 0
                            Dim EstCompNbr As Integer = 0
                            Dim EstQuoteNbr As Integer = 0
                            Dim EstRevNbr As Integer = 0
                            Dim SeqNbr As Integer = -1
                            Try
                                EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                            Catch ex As Exception
                                EstNumber = 0
                            End Try
                            Try
                                EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                            Catch ex As Exception
                                EstCompNbr = 0
                            End Try
                            Try
                                EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                            Catch ex As Exception
                                EstQuoteNbr = 0
                            End Try
                            Try
                                EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                            Catch ex As Exception
                                EstRevNbr = 0
                            End Try
                            Try
                                SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                            Catch ex As Exception
                                SeqNbr = -1
                            End Try

                            Dim MyCmd As New SqlCommand()
                            MyCmd.Parameters.Add(parameterFNC_CODE)
                            MyCmd.Parameters.Add(parameterEST_REV_RATE)
                            MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                            MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                            'MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                            MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                            MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                            MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                            MyCmd.Parameters.Add(parameterLINE_TOTAL)
                            MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                            MyCmd.Parameters.Add(parameterTAX_CODE)
                            MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                            MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                            MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                            MyCmd.Parameters.Add(parameterTAX_RESALE)
                            MyCmd.Parameters.Add(parameterTAX_COMM)
                            MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                            MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                            MyCmd.Parameters.Add(parameterFNC_TYPE)
                            MyCmd.Parameters.Add(parameterEST_CPM_FLAG)
                            MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                            MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                            MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                            MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                            If taxcode <> "" Then
                                MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                                MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                                MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                                MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                                MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                                MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                                MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                                MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                            End If

                            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                            pESTIMATE_NUMBER.Value = EstNumber
                            MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                            pEST_COMPONENT_NBR.Value = EstCompNbr
                            MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                            pEST_QUOTE_NBR.Value = EstQuoteNbr
                            MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                            Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                            pEST_REV_NBR.Value = EstRevNbr
                            MyCmd.Parameters.Add(pEST_REV_NBR)

                            Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                            pSEQ_NBR.Value = SeqNbr
                            MyCmd.Parameters.Add(pSEQ_NBR)

                            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                                Dim MyTrans As SqlTransaction
                                MyConn.Open()
                                MyTrans = MyConn.BeginTransaction
                                Try
                                    With MyCmd
                                        .CommandText = SQL.ToString()
                                        .CommandType = CommandType.Text
                                        .Connection = MyConn
                                        .Transaction = MyTrans
                                        .ExecuteNonQuery()
                                        'ReturnMessage = "OK|" & qty
                                    End With
                                    MyTrans.Commit()
                                Catch ex As Exception
                                    MyTrans.Rollback()
                                Finally
                                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                End Try
                            End Using

                        End If

                    End If

                End If

            End If
            If String.IsNullOrWhiteSpace(ClientCode) = True Then

                If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 Then

                    Try

                        ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = {0};", LookupSearchCriteria.JobComponent.JobNumber)).SingleOrDefault

                    Catch ex As Exception
                        ClientCode = String.Empty
                    End Try

                End If

            End If
            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    LimitFunctionsByBillingRate = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault

                Catch ex As Exception
                    LimitFunctionsByBillingRate = False
                End Try

            End If
            If LimitFunctionsByBillingRate = True Then

                Try

                    BillingRestrictedFunctionCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_CODE FROM BILLING_RATE WHERE CL_CODE = '{0}' AND NOT FNC_CODE IS NULL;", ClientCode)).ToList

                Catch ex As Exception
                    BillingRestrictedFunctionCodes = Nothing
                End Try

                If BillingRestrictedFunctionCodes Is Nothing Then BillingRestrictedFunctionCodes = New List(Of String)

            End If
            If LimitFunctionsByBillingRate = False Then

                SearchFunctions_Estimate = (From Item In ResultQuery
                                            Select Item.Code,
                                               Item.Description,
                                               Item.Type).ToList.Select(Function(Fnc) New ViewModels.LookupObjects.Function With {.FunctionCode = Fnc.Code,
                                                                                                                                          .FunctionDescription = Fnc.Description,
                                                                                                                                          .FunctionType = Fnc.Type,
                                                                                                                                          .ExtraData = ExtraData}).ToList

            Else

                SearchFunctions_Estimate = (From Item In ResultQuery
                                            Where Item.Type.ToUpper <> "E" Or (Item.Type.ToUpper = "E" And BillingRestrictedFunctionCodes.Contains(Item.Code))
                                            Select Item.Code,
                                                   Item.Description,
                                                   Item.Type).ToList.Select(Function(Fnc) New ViewModels.LookupObjects.Function With {.FunctionCode = Fnc.Code,
                                                                                                                                      .FunctionDescription = Fnc.Description,
                                                                                                                                      .FunctionType = Fnc.Type,
                                                                                                                                      .ExtraData = ExtraData}).ToList

            End If

        End Function
#End Region

#Region " -- General Ledger Account -- "

        Public Function CreateLookupDisplayObject_GeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.GeneralLedgerAccount.Properties.GeneralLedgerCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.GeneralLedgerAccount.Properties.GeneralLedgerDescription.ToString, "Description")

            LookupDisplayObject.Results = SearchGeneralLedgerAccounts(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "General Ledger Account"

            CreateLookupDisplayObject_GeneralLedgerAccounts = LookupDisplayObject

        End Function
        Public Function SearchGeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                    ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                    ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                ResultQuery = AdvantageFramework.PurchaseOrders.LoadGeneralLedgerAccounts(DbContext, _Session)

            Else

                If LookupSearchCriteria.GeneralLedgerAccount.IncludeInactive Then

                    ResultQuery = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)

                Else

                    ResultQuery = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)

                End If

            End If

            If LookupSearchCriteria.GeneralLedgerAccount IsNot Nothing Then

                If Not [String].IsNullOrWhiteSpace(LookupSearchCriteria.GeneralLedgerAccount.GeneralLedgerCode) Then

                    ResultQuery = ResultQuery.Where(Function(GLA) GLA.Code = LookupSearchCriteria.GeneralLedgerAccount.GeneralLedgerCode)

                End If

            End If

            SearchGeneralLedgerAccounts = (From Item In ResultQuery
                                           Select Item.Code,
                                                  Item.Description).Select(Function(Gla) New ViewModels.LookupObjects.GeneralLedgerAccount With {.GeneralLedgerCode = Gla.Code,
                                                                                                                          .GeneralLedgerDescription = Gla.Description}).ToList

        End Function

#End Region

#Region " -- Job -- "

        Public Function JobOrComponentClosed(SearchCriteria As ViewModels.LookupObjects.JobComponent) As Boolean
            Dim LegacyValidationObject As cValidations = Nothing

            LegacyValidationObject = New cValidations(Me._Session.ConnectionString)
            Return Not LegacyValidationObject.ValidateJobIsOpen(SearchCriteria.JobNumber, SearchCriteria.JobComponentNumber)

        End Function
        Public Function CreateLookupDisplayObject_Jobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                       ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                       ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobNumber.ToString, "Number")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobDescription.ToString, "Description")

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientCode.ToString, "Client")

            End If

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.DivisionCode.ToString, "Division")

            End If

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ProductCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ProductCode.ToString, "Product")

            End If

            LookupDisplayObject.Results = SearchJobs(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Job"

            CreateLookupDisplayObject_Jobs = LookupDisplayObject

        End Function
        Public Function SearchJobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                   ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                   ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim FilteredOpenResults As List(Of ViewModels.LookupObjects.JobComponent) = Nothing
            Dim LookupSearchCriteriaJobNumber As Integer = Nothing

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                FilteredOpenResults = (From Item In SearchJobComponents_PurchaseOrders(DbContext, SecurityDbContext, LookupSearchCriteria)
                                       Group By JobNumber = Item.JobNumber Into Job = Group
                                       Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Job.First.ClientCode,
                                                                                               .ClientName = Job.First.ClientName,
                                                                                               .DivisionCode = Job.First.DivisionCode,
                                                                                               .DivisionName = Job.First.DivisionName,
                                                                                               .ProductCode = Job.First.ProductCode,
                                                                                               .ProductName = Job.First.ProductName,
                                                                                               .JobNumber = Job.First.JobNumber,
                                                                                               .JobDescription = Job.First.JobDescription}).ToList


            ElseIf SecurityModule = AdvantageFramework.Security.Modules.Employee_Timesheet Then

                FilteredOpenResults = (From Item In SearchJobs_Timesheet(DbContext, SecurityDbContext, LookupSearchCriteria)
                                       Group By JobNumber = Item.JobNumber Into Job = Group
                                       Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Job.First.ClientCode,
                                                                                              .ClientName = Job.First.ClientName,
                                                                                              .DivisionCode = Job.First.DivisionCode,
                                                                                              .DivisionName = Job.First.DivisionName,
                                                                                              .ProductCode = Job.First.ProductCode,
                                                                                              .ProductName = Job.First.ProductName,
                                                                                              .JobNumber = Job.First.JobNumber,
                                                                                              .JobDescription = Job.First.JobDescription}).ToList

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.Employee_ExpenseReports Then

                FilteredOpenResults = (From Item In AdvantageFramework.ExpenseReports.LoadAvailableJobComponents(DbContext, SecurityDbContext, LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0), LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode)
                                       Group By JobNum = Item.JobNumber Into Job = Group
                                       Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Job.First.ClientCode,
                                                                                               .ClientName = Job.First.ClientName,
                                                                                               .DivisionCode = Job.First.DivisionCode,
                                                                                               .DivisionName = Job.First.DivisionName,
                                                                                               .ProductCode = Job.First.ProductCode,
                                                                                               .ProductName = Job.First.ProductDescription,
                                                                                               .JobNumber = Job.First.JobNumber,
                                                                                               .JobDescription = Job.First.JobDescription}).OrderByDescending(Function(item) item.JobNumber).ToList

            Else

                FilteredOpenResults = New List(Of ViewModels.LookupObjects.JobComponent)

                If IsNumeric(LookupSearchCriteria.JobComponent.JobNumber) Then

                    LookupSearchCriteriaJobNumber = CInt(LookupSearchCriteria.JobComponent.JobNumber)

                End If

                FilteredOpenResults = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, DbContext.UserCode, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode, LookupSearchCriteriaJobNumber, True)
                                       Group By JobNum = Item.JobNumber Into Job = Group
                                       Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Job.First.ClientCode,
                                                                                              .ClientName = Job.First.ClientName,
                                                                                              .DivisionCode = Job.First.DivisionCode,
                                                                                              .DivisionName = Job.First.DivisionName,
                                                                                              .ProductCode = Job.First.ProductCode,
                                                                                              .ProductName = Job.First.ProductDescription,
                                                                                              .JobNumber = Job.First.JobNumber,
                                                                                              .JobDescription = Job.First.JobDescription}).OrderByDescending(Function(item) item.JobNumber).ToList

            End If

            SearchJobs = FilteredOpenResults

        End Function
        Private Function SearchJobs_Timesheet(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As IEnumerable(Of ViewModels.LookupObjects.JobComponent)

            Dim FilteredResults As Generic.IEnumerable(Of ViewModels.LookupObjects.JobComponent) = Nothing

            Try


                FilteredResults = (From Item In AdvantageFramework.EmployeeTimesheet.Methods.LoadAvailableJobs(DbContext, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode)
                                   Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Item.ClientCode,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .JobNumber = Item.Number,
                                                                                          .JobDescription = Item.Description}).OrderByDescending(Function(Job) Job.JobNumber).ToList

            Catch ex As Exception
                FilteredResults = Nothing
            End Try

            Return FilteredResults

        End Function

#End Region

#Region " -- Job Component -- "

        Public Function CreateLookupDisplayObject_JobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                                ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing
            Dim LookupSearchCriteriaJobNumber As Integer = Nothing

            If IsNumeric(LookupSearchCriteria.JobComponent.JobNumber) Then

                LookupSearchCriteriaJobNumber = CInt(LookupSearchCriteria.JobComponent.JobNumber)

            End If

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            If LookupSearchCriteriaJobNumber <= 0 Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobNumber.ToString, "Job")
                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobComponentNumber.ToString, "Comp")
                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobComponentDescription.ToString, "Description")

                If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                    LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientCode.ToString, "Client")

                End If

                If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) Then

                    LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.DivisionCode.ToString, "Division")

                End If

                If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ProductCode) Then

                    LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ProductCode.ToString, "Product")

                End If

            Else

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobComponentNumber.ToString, "Number")
                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.JobComponentDescription.ToString, "Description")

            End If

            LookupDisplayObject.Results = SearchJobComponents(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Job Component"

            CreateLookupDisplayObject_JobComponents = LookupDisplayObject

        End Function
        Public Function SearchJobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim LookupSearchCriteriaJobNumber As Integer = Nothing
            Dim FilteredResults As Generic.IEnumerable(Of ViewModels.LookupObjects.JobComponent) = Nothing
            Dim ClCode As String = Nothing
            Dim DivCode As String = Nothing
            Dim PrdCode As String = Nothing

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                FilteredResults = SearchJobComponents_PurchaseOrders(DbContext, SecurityDbContext, LookupSearchCriteria)

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.Employee_Timesheet Then

                FilteredResults = (From Item In SearchJobComponents_Timesheet(DbContext, SecurityDbContext, LookupSearchCriteria)
                                   Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Item.ClientCode,
                                                                                          .ClientName = Item.ClientName,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .DivisionName = Item.DivisionName,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .ProductName = Item.ProductName,
                                                                                          .JobNumber = Item.JobNumber,
                                                                                          .JobComponentNumber = Item.JobComponentNumber,
                                                                                          .JobComponentDescription = Item.JobComponentDescription,
                                                                                          .JobDescription = Item.JobDescription}).ToList

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.Employee_ExpenseReports Then

                If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 Then

                    ClCode = LookupSearchCriteria.JobComponent.ClientCode
                    DivCode = LookupSearchCriteria.JobComponent.DivisionCode
                    PrdCode = LookupSearchCriteria.JobComponent.ProductCode

                    LookupSearchCriteria.JobComponent.ClientCode = Nothing
                    LookupSearchCriteria.JobComponent.DivisionCode = Nothing
                    LookupSearchCriteria.JobComponent.ProductCode = Nothing

                End If

                FilteredResults = (From Item In AdvantageFramework.ExpenseReports.LoadAvailableJobComponents(DbContext, SecurityDbContext, LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0), LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode)
                                   Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Item.ClientCode,
                                                                                          .ClientName = Item.ClientName,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .DivisionName = Item.DivisionName,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .ProductName = Item.ProductDescription,
                                                                                          .JobNumber = Item.JobNumber,
                                                                                          .JobComponentNumber = Item.JobComponentNumber,
                                                                                          .JobComponentDescription = Item.JobComponentDescription,
                                                                                          .JobDescription = Item.JobDescription}).OrderByDescending(Function(item) item.JobNumber).ThenBy(Function(item) item.JobComponentNumber).ToList

                If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 Then

                    If FilteredResults.Count > 0 Then

                        With FilteredResults.First

                            ClCode = .ClientCode
                            DivCode = .DivisionCode
                            PrdCode = .ProductCode

                        End With

                    Else

                        LookupSearchCriteria.JobComponent.JobNumber = Nothing
                        LookupSearchCriteria.JobComponent.JobComponentNumber = Nothing

                    End If

                    LookupSearchCriteria.JobComponent.ClientCode = ClCode
                    LookupSearchCriteria.JobComponent.DivisionCode = DivCode
                    LookupSearchCriteria.JobComponent.ProductCode = PrdCode

                End If

                If LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    FilteredResults = FilteredResults.Where(Function(item) item.JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber).ToList

                End If

            Else

                If IsNumeric(LookupSearchCriteria.JobComponent.JobNumber) Then

                    LookupSearchCriteriaJobNumber = CInt(LookupSearchCriteria.JobComponent.JobNumber)

                End If

                FilteredResults = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, DbContext.UserCode, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode, LookupSearchCriteriaJobNumber, True)
                                   Select Item.DivisionCode,
                                          Item.DivisionName,
                                          Item.ClientCode,
                                          Item.ClientName,
                                          Item.ProductCode,
                                          Item.ProductDescription,
                                          Item.JobNumber,
                                          Item.JobDescription,
                                          Item.JobComponentNumber,
                                          Item.JobComponentDescription) _
                                .Select(Function(Comp) New ViewModels.LookupObjects.JobComponent With {.ClientCode = Comp.ClientCode,
                                                                                                       .ClientName = Comp.ClientName,
                                                                                                       .DivisionCode = Comp.DivisionCode,
                                                                                                       .DivisionName = Comp.DivisionName,
                                                                                                       .ProductCode = Comp.ProductCode,
                                                                                                       .ProductName = Comp.ProductDescription,
                                                                                                       .JobNumber = Comp.JobNumber,
                                                                                                       .JobDescription = Comp.JobDescription,
                                                                                                       .JobComponentNumber = Comp.JobComponentNumber,
                                                                                                       .JobComponentDescription = Comp.JobComponentDescription}).OrderByDescending(Function(Job) Job.JobNumber).ToList

            End If

            SearchJobComponents = FilteredResults

        End Function
        Private Function SearchJobComponents_PurchaseOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As IEnumerable(Of ViewModels.LookupObjects.JobComponent)

            Dim FilteredResults As Generic.IEnumerable(Of ViewModels.LookupObjects.JobComponent) = Nothing

            Try

                FilteredResults = (From Item In AdvantageFramework.PurchaseOrders.LoadJobComponents(DbContext, _Session.UserCode, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode, LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0)).ToList
                                   Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Item.ClientCode,
                                                                                          .ClientName = Item.ClientName,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .DivisionName = Item.DivisionName,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .ProductName = Item.ProductDescription,
                                                                                          .JobNumber = Item.JobNumber,
                                                                                          .JobDescription = Item.JobDescription,
                                                                                          .JobComponentNumber = Item.JobComponentNumber,
                                                                                          .JobComponentDescription = Item.JobComponentDescription}).OrderByDescending(Function(Job) Job.JobNumber).ToList

                If LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    FilteredResults = FilteredResults.Where(Function(jc) jc.JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber).ToList

                End If

            Catch ex As Exception
                FilteredResults = Nothing
            End Try

            Return FilteredResults

        End Function
        Private Function SearchJobComponents_Timesheet(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                    ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As IEnumerable(Of ViewModels.LookupObjects.JobComponent)

            Dim FilteredResults As Generic.IEnumerable(Of ViewModels.LookupObjects.JobComponent) = Nothing

            Try


                FilteredResults = (From Item In AdvantageFramework.EmployeeTimesheet.LoadAvailableJobComponents(DbContext, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode, LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0))
                                   Where Item.JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber Or LookupSearchCriteria.JobComponent.JobComponentNumber.HasValue = False
                                   Select New ViewModels.LookupObjects.JobComponent With {.ClientCode = Item.ClientCode,
                                                                                          .ClientName = Item.ClientName,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .DivisionName = Item.DivisionName,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .ProductName = Item.ProductDescription,
                                                                                          .JobNumber = Item.JobNumber,
                                                                                          .JobDescription = Item.JobDescription,
                                                                                          .JobComponentNumber = Item.JobComponentNumber,
                                                                                          .JobComponentDescription = Item.JobComponentDescription}).OrderByDescending(Function(Job) Job.JobNumber).ToList

            Catch ex As Exception
                FilteredResults = Nothing
            End Try

            Return FilteredResults

        End Function

#End Region

#Region " -- Product -- "

        Public Function CreateLookupDisplayObject_Products(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                           ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                           ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ClientCode.ToString, "Client")

            End If

            If String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) Then

                LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.DivisionCode.ToString, "Division")

            End If

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ProductCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.JobComponent.Properties.ProductName.ToString, "Name")

            LookupDisplayObject.Results = SearchProducts(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Product"

            CreateLookupDisplayObject_Products = LookupDisplayObject

        End Function
        Public Function SearchProducts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                       ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                       ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, Not LookupSearchCriteria.JobComponent.IncludeInactive)

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ClientCode) Then

                ResultQuery = ResultQuery.Where(Function(Prod) Prod.ClientCode = LookupSearchCriteria.JobComponent.ClientCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.DivisionCode) Then

                ResultQuery = ResultQuery.Where(Function(Prod) Prod.DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.JobComponent.ProductCode) Then

                ResultQuery = ResultQuery.Where(Function(Prod) Prod.ProductCode = LookupSearchCriteria.JobComponent.ProductCode).ToList

            End If

            SearchProducts = (From Item In ResultQuery
                              Select Item.DivisionCode,
                                     Item.DivisionName,
                                     Item.ClientCode,
                                     Item.ClientName,
                                     Item.ProductCode,
                                     Item.ProductDescription).Select(Function(Prd) New ViewModels.LookupObjects.JobComponent With {.ClientCode = Prd.ClientCode,
                                                                                                                                   .ClientName = Prd.ClientName,
                                                                                                                                   .DivisionCode = Prd.DivisionCode,
                                                                                                                                   .DivisionName = Prd.DivisionName,
                                                                                                                                   .ProductCode = Prd.ProductCode,
                                                                                                                                   .ProductName = Prd.ProductDescription}).ToList

        End Function

#End Region

#Region " -- Vendor -- "

        Public Function CreateLookupDisplayObject_Vendors(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                          ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                          ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Vendor.Properties.VendorCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Vendor.Properties.VendorName.ToString, "Name")

            LookupDisplayObject.Results = SearchVendors(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Vendor"

            CreateLookupDisplayObject_Vendors = LookupDisplayObject

        End Function
        Public Function SearchVendors(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                      ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders Then

                SearchVendors = SearchVendors_PurchaseOrders(DbContext, SecurityDbContext, LookupSearchCriteria)

            ElseIf SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_Estimating Then

                SearchVendors = SearchVendors_Estimates(DbContext, SecurityDbContext, LookupSearchCriteria)

            Else

                SearchVendors = (From Item In ResultQuery
                                 Select Item.Code,
                                        Item.Name).Select(Function(Ven) New ViewModels.LookupObjects.Vendor With {.VendorCode = Ven.Code,
                                                                                                                  .VendorName = Ven.Name}).ToList

            End If

        End Function
        Private Function SearchVendors_PurchaseOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                      ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim StandardCommentList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim VendorList As Generic.List(Of ViewModels.LookupObjects.Vendor) = Nothing
            Dim PayToName As String = Nothing
            Dim PayToAddressLine1 As String = Nothing
            Dim PayToAddressLine2 As String = Nothing
            Dim PayToAddressCity As String = Nothing
            Dim PayToState As String = Nothing
            Dim PayToZipCode As String = Nothing
            Dim PayToCounty As String = Nothing
            Dim PayToCountry As String = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session)

            If LookupSearchCriteria.Vendor IsNot Nothing Then

                If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) Then

                    ResultQuery = ResultQuery.Where(Function(Ven) Ven.Code = LookupSearchCriteria.Vendor.VendorCode)

                End If

                If Not LookupSearchCriteria.Vendor.IncludeMediaVendors Then

                    ResultQuery = ResultQuery.Where(Function(Ven) Ven.VendorCategory = "P" OrElse Ven.VendorCategory = "Z")

                End If

            End If

            VendorList = (From Item In ResultQuery
                          Select Item.Code,
                                 Item.Name,
                                 Item.DefaultVendorContactCode).ToList.Select(Function(Ven) New ViewModels.LookupObjects.Vendor With {.VendorCode = Ven.Code,
                                                                                                                                      .VendorName = Ven.Name,
                                                                                                                                      .ExtraData = New Generic.Dictionary(Of String, Object) From {{"DefaultVendorContactCode", Ven.DefaultVendorContactCode}}}).ToList

            If VendorList IsNot Nothing AndAlso VendorList.Count = 1 Then

                AdvantageFramework.PurchaseOrders.LoadVendorPayToInformation(DbContext, VendorList.First.VendorCode, "", "", PayToName, PayToAddressLine1, PayToAddressLine2, "",
                                                                             PayToAddressCity, PayToCounty, PayToState, PayToZipCode, PayToCountry, "", "", "", "")

                VendorList.First.ExtraData.Add("PayToName", PayToName)
                VendorList.First.ExtraData.Add("PayToAddressLine1", PayToAddressLine1)
                VendorList.First.ExtraData.Add("PayToAddressLine2", PayToAddressLine2)
                VendorList.First.ExtraData.Add("PayToCity", PayToAddressCity)
                VendorList.First.ExtraData.Add("PayToCounty", PayToCounty)
                VendorList.First.ExtraData.Add("PayToState", PayToState)
                VendorList.First.ExtraData.Add("PayToZipCode", PayToZipCode)
                VendorList.First.ExtraData.Add("PayToCountry", PayToCountry)

                StandardCommentList = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Purchase Order").ToList

                Try

                    StandardComment = StandardCommentList.Where(Function(StdCmt) StdCmt.VendorCode = VendorList.First.VendorCode).FirstOrDefault

                Catch ex As Exception

                End Try

                If StandardComment Is Nothing Then

                    Try

                        StandardComment = StandardCommentList.Where(Function(StdCmt) StdCmt.VendorCode = Nothing).FirstOrDefault

                    Catch ex As Exception

                    End Try

                End If

                If StandardComment IsNot Nothing Then

                    VendorList.First.ExtraData.Add("StandardComment", StandardComment.Comment)

                End If

            End If

            Return VendorList

        End Function

        Private Function SearchVendors_Estimates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ResultQueryVendors As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim UserEmployeeAccesses As String() = Nothing
            Dim Employees As Generic.IEnumerable(Of ViewModels.LookupObjects.Employee) = Nothing
            Dim Vendors As Generic.IEnumerable(Of ViewModels.LookupObjects.Vendor) = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing
            Dim Salesclass As String = Nothing
            Dim est As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As New DataTable
            Dim taxcode As String = ""
            Dim taxState As Decimal = 0
            Dim taxCounty As Decimal = 0
            Dim taxCity As Decimal = 0
            Dim taxResale As Integer = 0
            Dim taxResaleNbr As String = ""
            Dim functionNonBill As Integer = 0
            Dim functionTaxComm As Integer = 0
            Dim functionTaxCommOnly As Integer = 0
            Dim functiontaxflag As Integer
            Dim functionType As String = ""
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim feetime As Integer = 0
            Dim rate As Decimal = 0.0
            Dim markuppct As Decimal = 0.0

            Dim qty As Decimal = 0.0
            Dim extamt As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim markupamt As Decimal = 0.0
            Dim linetotal As Decimal = 0.0
            Dim mucontamt As Decimal = 0.0
            Dim extnonresaletax As Decimal = 0.0
            Dim extstateresale As Decimal = 0.0
            Dim extcountyresale As Decimal = 0.0
            Dim extcityresale As Decimal = 0.0
            Dim extstatenonresale As Decimal = 0.0
            Dim extcountynonresale As Decimal = 0.0
            Dim extcitynonresale As Decimal = 0.0
            Dim extstatemarkup As Decimal = 0.0
            Dim extcountymarkup As Decimal = 0.0
            Dim extcitymarkup As Decimal = 0.0
            Dim extmucont As Decimal = 0.0
            Dim extstatecont As Decimal = 0.0
            Dim extcountycont As Decimal = 0.0
            Dim extcitycont As Decimal = 0.0
            Dim extnrcont As Decimal = 0.0
            Dim linetotalcont As Decimal = 0.0

            Dim SQL As New System.Text.StringBuilder
            Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
            Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
            Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
            Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
            Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
            Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
            Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
            Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
            Dim parameterTAX_COMM As New SqlParameter("@TAX_COMM", SqlDbType.SmallInt)
            Dim parameterTAX_COMM_ONLY As New SqlParameter("@TAX_COMM_ONLY", SqlDbType.SmallInt)
            Dim parameterEST_NONBILL_FLAG As New SqlParameter("@EST_NONBILL_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_COMM_FLAG As New SqlParameter("@EST_COMM_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_TAX_FLAG As New SqlParameter("@EST_TAX_FLAG", SqlDbType.SmallInt)
            Dim parameterEST_FEE_FLAG As New SqlParameter("@FEE_TIME", SqlDbType.SmallInt)


            If LookupSearchCriteria.Vendor.LimitbyDefaultFunction Then

                ResultQueryVendors = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorByFunctionCode(DbContext, LookupSearchCriteria.Function.FunctionCode)

            Else

                ResultQueryVendors = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)

            End If

            If Not LookupSearchCriteria.Vendor.IncludeMediaVendors Then

                ResultQueryVendors = ResultQueryVendors.Where(Function(Ven) Ven.VendorCategory = "P")

                LookupSearchCriteria.Vendor.IncludeMediaVendors = False

            Else

                LookupSearchCriteria.Vendor.IncludeMediaVendors = True

            End If

            If LookupSearchCriteria.Vendor IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) = False Then

                If Not String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) Then

                    ResultQueryVendors = ResultQueryVendors.Where(Function(Ven) Ven.Code = LookupSearchCriteria.Vendor.VendorCode)

                End If

                ExtraData = New Generic.Dictionary(Of String, Object)

                If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                    DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                    ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                    Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                    JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                    JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                End If

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Vendor.VendorCode, Nothing)

                If BillingRate IsNot Nothing Then

                    If BillingRate.BILLING_RATE.GetValueOrDefault(0) > 0 Then
                        If BillingRate.BILLING_RATE IsNot Nothing Then
                            ExtraData.Add("Rate", BillingRate.BILLING_RATE)
                            rate = BillingRate.BILLING_RATE
                        Else
                            ExtraData.Add("Rate", 0)
                        End If

                    End If
                    If BillingRate.NOBILL_FLAG IsNot Nothing Then
                        ExtraData.Add("NoBillFlag", BillingRate.NOBILL_FLAG)
                        functionNonBill = BillingRate.NOBILL_FLAG
                    Else
                        ExtraData.Add("NoBillFlag", 0)
                    End If


                    If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                        ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                        functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                    Else
                        ExtraData.Add("TaxCommOnly", 0)
                    End If


                    If BillingRate.TAX_COMM IsNot Nothing Then
                        ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                        functionTaxComm = BillingRate.TAX_COMM
                    Else
                        ExtraData.Add("TaxComm", 0)
                    End If


                    If BillingRate.TAX_CODE IsNot Nothing Then
                        ExtraData.Add("TaxCode", BillingRate.TAX_CODE)
                        taxcode = BillingRate.TAX_CODE
                        fnctaxflag = 1
                        dt = est.GetAddNewTaxData(BillingRate.TAX_CODE)
                        If dt.Rows.Count > 0 Then
                            ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                            ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                            ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                            If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                            End If
                            taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                            taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                            taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                            If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                taxResale = dt.Rows(0)("TAX_RESALE")
                            End If
                        End If
                    Else
                        ExtraData.Add("TaxCode", "")
                        ExtraData.Add("TaxState", 0)
                        ExtraData.Add("TaxCounty", 0)
                        ExtraData.Add("TaxCity", 0)
                        ExtraData.Add("TaxResale", 0)
                        taxcode = ""
                        fnctaxflag = 0
                    End If

                    If BillingRate.COMM.GetValueOrDefault(0) > 0 Then
                        If BillingRate.COMM IsNot Nothing Then
                            ExtraData.Add("CommissionPercent", BillingRate.COMM)
                            markuppct = BillingRate.COMM
                            If BillingRate.COMM = 0 Then
                                fnccommflag = 0
                            Else
                                fnccommflag = 1
                            End If
                        Else
                            ExtraData.Add("CommissionPercent", 0)
                            fnccommflag = 1
                        End If

                    End If

                    If BillingRate.FEE_TIME_FLAG IsNot Nothing Then
                        feetime = BillingRate.FEE_TIME_FLAG
                    End If

                End If

                If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then

                    parameterEST_REV_SUP_BY_CDE.Value = LookupSearchCriteria.Vendor.VendorCode
                    parameterEST_REV_RATE.Value = rate
                    parameterEST_REV_EXT_AMT.Value = 0
                    parameterEXT_MARKUP_AMT.Value = 0
                    parameterEXT_CONTINGENCY.Value = 0
                    parameterEXT_MU_CONT.Value = 0
                    parameterLINE_TOTAL.Value = 0
                    parameterLINE_TOTAL_CONT.Value = 0
                    parameterEXT_STATE_RESALE.Value = 0
                    parameterEXT_COUNTY_RESALE.Value = 0
                    parameterEXT_CITY_RESALE.Value = 0
                    parameterEXT_STATE_CONT.Value = 0
                    parameterEXT_COUNTY_CONT.Value = 0
                    parameterEXT_CITY_CONT.Value = 0
                    parameterEXT_NONRESALE_TAX.Value = 0
                    parameterEXT_NR_CONT.Value = 0
                    parameterTAX_STATE_PCT.Value = taxState
                    parameterTAX_COUNTY_PCT.Value = taxCounty
                    parameterTAX_CITY_PCT.Value = taxCity
                    parameterTAX_RESALE.Value = taxResale
                    parameterTAX_COMM.Value = functionTaxComm
                    parameterTAX_COMM_ONLY.Value = functionTaxCommOnly
                    parameterEST_NONBILL_FLAG.Value = functionNonBill
                    parameterEST_COMM_FLAG.Value = fnccommflag
                    parameterEST_TAX_FLAG.Value = fnctaxflag
                    parameterEST_FEE_FLAG.Value = feetime

                    SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                    SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                    SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                    SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                    SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                    SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                    SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                    SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                    SQL.Append(" TAX_CODE = @TAX_CODE,")
                    SQL.Append(" TAX_STATE_PCT = @TAX_STATE_PCT,")
                    SQL.Append(" TAX_COUNTY_PCT = @TAX_COUNTY_PCT,")
                    SQL.Append(" TAX_CITY_PCT = @TAX_CITY_PCT,")
                    SQL.Append(" TAX_RESALE = @TAX_RESALE,")
                    SQL.Append(" TAX_COMM = @TAX_COMM,")
                    SQL.Append(" TAX_COMM_ONLY = @TAX_COMM_ONLY,")
                    SQL.Append(" EST_NONBILL_FLAG = @EST_NONBILL_FLAG,")
                    SQL.Append(" EST_COMM_FLAG = @EST_COMM_FLAG,")
                    SQL.Append(" EST_TAX_FLAG = @EST_TAX_FLAG,")
                    SQL.Append(" FEE_TIME = @FEE_TIME")


                    qty = LookupSearchCriteria.Estimate.EstimateQuantity
                    contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct

                    If qty <> 0 Then
                        extamt = qty * rate
                        parameterEST_REV_EXT_AMT.Value = extamt
                    End If
                    If extamt <> 0 And markuppct <> 0 Then
                        markupamt = extamt * (markuppct / 100)
                        parameterEXT_MARKUP_AMT.Value = markupamt
                    End If
                    If extamt <> 0 Then
                        If contpct <> 0 Then
                            contamt = extamt * (contpct / 100)
                            extmucont = markupamt * (contpct / 100)
                        End If
                        If markuppct <> 0 Then
                            linetotalcont += (markupamt * (contpct / 100))
                        End If
                        parameterEXT_CONTINGENCY.Value = contamt
                        parameterEXT_MU_CONT.Value = extmucont
                    End If

                    parameterEST_REV_COMM_PCT.Value = markuppct
                    parameterTAX_CODE.Value = taxcode

                    If taxcode <> "" Then
                        If taxResale = 1 Then
                            If functionTaxCommOnly <> 1 Then
                                extstateresale = extamt * (taxState / 100)
                                extcountyresale = extamt * (taxCounty / 100)
                                extcityresale = extamt * (taxCity / 100)
                            End If
                            If functionTaxComm = 1 Then
                                If markupamt > 0 Then
                                    extstatemarkup = markupamt * (taxState / 100)
                                    extcountymarkup = markupamt * (taxCounty / 100)
                                    extcitymarkup = markupamt * (taxCity / 100)
                                End If
                            End If
                            extstateresale += extstatemarkup
                            extcountyresale += extcountymarkup
                            extcityresale += extcitymarkup
                            parameterEXT_STATE_RESALE.Value = extstateresale
                            parameterEXT_COUNTY_RESALE.Value = extcountyresale
                            parameterEXT_CITY_RESALE.Value = extcityresale
                            If contamt > 0 Then
                                If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                    extstatecont = extmucont * (taxState / 100)
                                    extcountycont = extmucont * (taxCounty / 100)
                                    extcitycont = extmucont * (taxCity / 100)
                                ElseIf functionTaxComm = 1 Then
                                    extstatecont = (contamt + extmucont) * (taxState / 100)
                                    extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                    extcitycont = (contamt + extmucont) * (taxCity / 100)
                                Else
                                    extstatecont = contamt * (taxState / 100)
                                    extcountycont = contamt * (taxCounty / 100)
                                    extcitycont = contamt * (taxCity / 100)
                                End If
                                parameterEXT_STATE_CONT.Value = extstatecont
                                parameterEXT_COUNTY_CONT.Value = extcountycont
                                parameterEXT_CITY_CONT.Value = extcitycont
                                'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                            End If
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                        End If
                        If taxResale <> 1 Then
                            If functionType = "V" Then
                                If functionTaxCommOnly <> 1 Then
                                    extstatenonresale = extamt * (taxState / 100)
                                    extcountynonresale = extamt * (taxCounty / 100)
                                    extcitynonresale = extamt * (taxCity / 100)
                                    extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                    Dim trstate As Decimal = extamt * (taxState / 100)
                                    Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                    Dim trcity As Decimal = extamt * (taxCity / 100)
                                    linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                    parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                End If
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_NR_CONT.Value = extnrcont
                                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                End If
                            ElseIf functionType = "E" Or functionType = "I" Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If contamt > 0 Then
                                    If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = "1" Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                End If
                            End If
                            If functionTaxComm = 1 Then
                                If markupamt > 0 Then
                                    extstatemarkup = markupamt * (taxState / 100)
                                    extcountymarkup = markupamt * (taxCounty / 100)
                                    extcitymarkup = markupamt * (taxCity / 100)
                                End If
                            End If
                            extstateresale += extstatemarkup
                            extcountyresale += extcountymarkup
                            extcityresale += extcitymarkup
                            parameterEXT_STATE_RESALE.Value = extstateresale
                            parameterEXT_COUNTY_RESALE.Value = extcountyresale
                            parameterEXT_CITY_RESALE.Value = extcityresale
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                        End If
                    End If

                    linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                    linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                    SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                    parameterLINE_TOTAL.Value = linetotal
                    SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                    parameterLINE_TOTAL_CONT.Value = linetotalcont
                    With SQL
                        .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                    End With

                    Dim EstNumber As Integer = 0
                    Dim EstCompNbr As Integer = 0
                    Dim EstQuoteNbr As Integer = 0
                    Dim EstRevNbr As Integer = 0
                    Dim SeqNbr As Integer = -1
                    Try
                        EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                    Catch ex As Exception
                        EstNumber = 0
                    End Try
                    Try
                        EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                    Catch ex As Exception
                        EstCompNbr = 0
                    End Try
                    Try
                        EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                    Catch ex As Exception
                        EstQuoteNbr = 0
                    End Try
                    Try
                        EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                    Catch ex As Exception
                        EstRevNbr = 0
                    End Try
                    Try
                        SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                    Catch ex As Exception
                        SeqNbr = -1
                    End Try

                    Dim MyCmd As New SqlCommand()
                    MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                    MyCmd.Parameters.Add(parameterEST_REV_RATE)
                    MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                    MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                    'MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                    MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                    MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                    MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                    MyCmd.Parameters.Add(parameterLINE_TOTAL)
                    MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                    MyCmd.Parameters.Add(parameterTAX_CODE)
                    MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                    MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                    MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                    MyCmd.Parameters.Add(parameterTAX_RESALE)
                    MyCmd.Parameters.Add(parameterTAX_COMM)
                    MyCmd.Parameters.Add(parameterTAX_COMM_ONLY)
                    MyCmd.Parameters.Add(parameterEST_NONBILL_FLAG)
                    MyCmd.Parameters.Add(parameterEST_COMM_FLAG)
                    MyCmd.Parameters.Add(parameterEST_TAX_FLAG)
                    MyCmd.Parameters.Add(parameterEST_FEE_FLAG)
                    If taxcode <> "" Then
                        MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                        MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                        MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                        MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                        MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                    End If

                    Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                    pESTIMATE_NUMBER.Value = EstNumber
                    MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                    Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                    pEST_COMPONENT_NBR.Value = EstCompNbr
                    MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                    Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                    pEST_QUOTE_NBR.Value = EstQuoteNbr
                    MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                    Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                    pEST_REV_NBR.Value = EstRevNbr
                    MyCmd.Parameters.Add(pEST_REV_NBR)

                    Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                    pSEQ_NBR.Value = SeqNbr
                    MyCmd.Parameters.Add(pSEQ_NBR)

                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Try
                            With MyCmd
                                .CommandText = SQL.ToString()
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                                'ReturnMessage = "OK|" & qty
                            End With
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using

                End If

            End If

            Vendors = (From Item In ResultQueryVendors
                       Select Item.Code,
                                  Item.Name).ToList.Select(Function(Ven) New ViewModels.LookupObjects.Vendor With {.VendorCode = Ven.Code,
                                                                                                                         .VendorName = Ven.Name,
                                                                                                                         .ExtraData = ExtraData}).ToList

            SearchVendors_Estimates = Vendors


        End Function

#End Region

#Region " -- Vendor Contact -- "

        Public Function CreateLookupDisplayObject_VendorContacts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                 ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                                 ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.VendorContact.Properties.VendorContactCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.VendorContact.Properties.FullName.ToString, "Name")

            LookupDisplayObject.Results = SearchVendorContacts(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Vendor Contacts"

            CreateLookupDisplayObject_VendorContacts = LookupDisplayObject

        End Function
        Public Function SearchVendorContacts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                             ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContact) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.VendorContact.LoadAllActive(DbContext)

            If LookupSearchCriteria.Vendor IsNot Nothing Then

                If String.IsNullOrWhiteSpace(LookupSearchCriteria.Vendor.VendorCode) = False Then

                    ResultQuery = ResultQuery.Where(Function(VenCon) VenCon.VendorCode = LookupSearchCriteria.Vendor.VendorCode)

                End If

            End If

            If LookupSearchCriteria.VendorContact IsNot Nothing Then

                If String.IsNullOrWhiteSpace(LookupSearchCriteria.VendorContact.VendorContactCode) = False Then

                    ResultQuery = ResultQuery.Where(Function(VenCon) VenCon.Code = LookupSearchCriteria.VendorContact.VendorContactCode)

                End If

            End If

            SearchVendorContacts = (From Item In ResultQuery
                                    Select Item.Code,
                                           Item.FirstName,
                                           Item.LastName,
                                           Item.MiddleInitial,
                                           Item.Email).Select(Function(VenCon) New ViewModels.LookupObjects.VendorContact With {.VendorContactCode = VenCon.Code,
                                                                                                                                .FirstName = VenCon.FirstName,
                                                                                                                                .MiddleInitial = VenCon.MiddleInitial,
                                                                                                                                .LastName = VenCon.LastName,
                                                                                                                                .EmailAddress = VenCon.Email}).ToList

        End Function

#End Region

#Region " -- Tax -- "

        Public Function CreateLookupDisplayObject_Tax(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                          ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                          ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Tax.Properties.TaxCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Tax.Properties.TaxDescription.ToString, "Description")

            LookupDisplayObject.Results = SearchTax(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Tax"

            CreateLookupDisplayObject_Tax = LookupDisplayObject

        End Function

        Public Function SearchTax(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                        ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                        ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SalesTax) = Nothing

            If SecurityModule = AdvantageFramework.Security.Modules.ProjectManagement_Estimating Then

                SearchTax = SearchTax_Estimate(DbContext, LookupSearchCriteria)

            Else

                ResultQuery = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext)

                SearchTax = (From Item In ResultQuery
                             Select Item.TaxCode,
                                    Item.Description).ToList.Select(Function(Tax) New ViewModels.LookupObjects.Tax With {.TaxCode = Tax.TaxCode,
                                                                                                                         .TaxDescription = Tax.Description}).ToList


            End If

        End Function

        Private Function SearchTax_Estimate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SalesTax) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExtraData As Generic.Dictionary(Of String, Object) = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim GeneralLedgerAccountCode As String = ""
            Dim GeneralLedgerAccountDescription As String = ""
            Dim EffectiveDate As Date? = Date.Now
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentNumber As String = Nothing
            Dim Salesclass As String = Nothing
            Dim est As New cEstimating(_Session.ConnectionString, _Session.UserCode)
            Dim dt As New DataTable
            Dim taxState As Decimal = 0
            Dim taxCounty As Decimal = 0
            Dim taxCity As Decimal = 0
            Dim taxResale As Integer = 0
            Dim taxResaleNbr As String = ""
            Dim functionNonBill As Integer = 0
            Dim functionTaxComm As Integer = 0
            Dim functionTaxCommOnly As Integer = 0
            Dim functiontaxflag As Integer
            Dim functionType As String = ""
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim feetime As Integer = 0
            Dim rate As Decimal = 0.0
            Dim markuppct As Decimal = 0.0
            Dim emptitleid As Integer = 0

            ResultQuery = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext)

            If LookupSearchCriteria.Tax IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Tax.TaxCode) = False Then

                ResultQuery = ResultQuery.Where(Function(T) T.TaxCode = LookupSearchCriteria.Tax.TaxCode)

            End If

            If LookupSearchCriteria.Tax IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LookupSearchCriteria.Tax.TaxCode) = False Then

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, LookupSearchCriteria.Tax.TaxCode)

                If SalesTax IsNot Nothing Then

                    ExtraData = New Generic.Dictionary(Of String, Object)

                    dt = est.GetAddNewTaxData(LookupSearchCriteria.Tax.TaxCode)
                    If dt.Rows.Count > 0 Then
                        ExtraData.Add("TaxState", dt.Rows(0)("TAX_STATE_PERCENT"))
                        ExtraData.Add("TaxCounty", dt.Rows(0)("TAX_COUNTY_PERCENT"))
                        ExtraData.Add("TaxCity", dt.Rows(0)("TAX_CITY_PERCENT"))
                        taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                        taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                        taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                        If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                            ExtraData.Add("TaxResale", dt.Rows(0)("TAX_RESALE"))
                            taxResale = dt.Rows(0)("TAX_RESALE")
                        End If
                    End If

                    If LookupSearchCriteria.JobComponent.JobNumber.GetValueOrDefault(0) > 0 AndAlso LookupSearchCriteria.JobComponent.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass
                        JobNumber = LookupSearchCriteria.JobComponent.JobNumber.Value.ToString
                        JobComponentNumber = LookupSearchCriteria.JobComponent.JobComponentNumber.Value.ToString

                    Else

                        ClientCode = LookupSearchCriteria.JobComponent.ClientCode
                        DivisionCode = LookupSearchCriteria.JobComponent.DivisionCode
                        ProductCode = LookupSearchCriteria.JobComponent.ProductCode
                        Salesclass = LookupSearchCriteria.JobComponent.SalesClass

                    End If

                    If LookupSearchCriteria.Employee.EmployeeCode <> "" And LookupSearchCriteria.Function.FunctionType = "E" Then
                        If LookupSearchCriteria.EmployeeTitle.EmployeeTitle = "" Then
                            LookupSearchCriteria.Employee.EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title
                            emptitleid = If(AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID Is Nothing, 0, AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).EmployeeTitleID)
                        Else
                            emptitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, LookupSearchCriteria.EmployeeTitle.EmployeeTitle).ID
                        End If
                        ExtraData.Add("EmployeeTitle", AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LookupSearchCriteria.Employee.EmployeeCode).Title)
                    End If

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, LookupSearchCriteria.Function.FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Salesclass, LookupSearchCriteria.Employee.EmployeeCode, EffectiveDate, emptitleid)

                    If BillingRate IsNot Nothing Then
                        If BillingRate.TAX_COMM_ONLY IsNot Nothing Then
                            ExtraData.Add("TaxCommOnly", BillingRate.TAX_COMM_ONLY)
                            functionTaxCommOnly = BillingRate.TAX_COMM_ONLY
                        Else
                            ExtraData.Add("TaxCommOnly", 0)
                        End If


                        If BillingRate.TAX_COMM IsNot Nothing Then
                            ExtraData.Add("TaxComm", BillingRate.TAX_COMM)
                            functionTaxComm = BillingRate.TAX_COMM
                        Else
                            ExtraData.Add("TaxComm", 0)
                        End If
                    End If

                    If LookupSearchCriteria.Estimate.EstimateSequenceNumber > 0 Then
                        Dim qty As Decimal = 0.0
                        Dim extamt As Decimal = 0.0
                        Dim contamt As Decimal = 0.0
                        Dim contpct As Decimal = 0.0
                        Dim markupamt As Decimal = 0.0
                        Dim linetotal As Decimal = 0.0
                        Dim mucontamt As Decimal = 0.0
                        Dim extnonresaletax As Decimal = 0.0
                        Dim extstateresale As Decimal = 0.0
                        Dim extcountyresale As Decimal = 0.0
                        Dim extcityresale As Decimal = 0.0
                        Dim extstatenonresale As Decimal = 0.0
                        Dim extcountynonresale As Decimal = 0.0
                        Dim extcitynonresale As Decimal = 0.0
                        Dim extstatemarkup As Decimal = 0.0
                        Dim extcountymarkup As Decimal = 0.0
                        Dim extcitymarkup As Decimal = 0.0
                        Dim extmucont As Decimal = 0.0
                        Dim extstatecont As Decimal = 0.0
                        Dim extcountycont As Decimal = 0.0
                        Dim extcitycont As Decimal = 0.0
                        Dim extnrcont As Decimal = 0.0
                        Dim linetotalcont As Decimal = 0.0

                        Dim SQL As New System.Text.StringBuilder
                        Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                        Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                        Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                        Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                        Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                        Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                        Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                        Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                        Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                        Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                        Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                        Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                        Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
                        Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
                        Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
                        Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
                        Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)

                        parameterTAX_CODE.Value = LookupSearchCriteria.Tax.TaxCode
                        parameterEXT_MU_CONT.Value = 0
                        parameterLINE_TOTAL.Value = 0
                        parameterLINE_TOTAL_CONT.Value = 0
                        parameterEXT_STATE_RESALE.Value = 0
                        parameterEXT_COUNTY_RESALE.Value = 0
                        parameterEXT_CITY_RESALE.Value = 0
                        parameterEXT_STATE_CONT.Value = 0
                        parameterEXT_COUNTY_CONT.Value = 0
                        parameterEXT_CITY_CONT.Value = 0
                        parameterEXT_NONRESALE_TAX.Value = 0
                        parameterEXT_NR_CONT.Value = 0
                        parameterTAX_STATE_PCT.Value = taxState
                        parameterTAX_COUNTY_PCT.Value = taxCounty
                        parameterTAX_CITY_PCT.Value = taxCity
                        parameterTAX_RESALE.Value = taxResale

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                        SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                        SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                        SQL.Append(" TAX_CODE = @TAX_CODE")
                        SQL.Append(", TAX_STATE_PCT = @TAX_STATE_PCT, TAX_COUNTY_PCT = @TAX_COUNTY_PCT, TAX_CITY_PCT = @TAX_CITY_PCT, TAX_RESALE = @TAX_RESALE")

                        functionType = LookupSearchCriteria.Function.FunctionType

                        qty = LookupSearchCriteria.Estimate.EstimateQuantity
                        contpct = LookupSearchCriteria.Estimate.EstimateContingencyPct
                        extamt = LookupSearchCriteria.Estimate.EstimateAmount
                        markuppct = LookupSearchCriteria.Estimate.EstimateCommissionPercent
                        markupamt = LookupSearchCriteria.Estimate.EstimateCommissionAmount

                        If extamt <> 0 Then
                            If markuppct <> 0 And markupamt = 0 Then
                                markupamt = Math.Round((extamt * (markuppct / 100)), 2, MidpointRounding.AwayFromZero)
                            End If
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                extmucont = markupamt * (contpct / 100)
                            End If
                            If markupamt <> 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                            parameterEXT_CONTINGENCY.Value = contamt
                            parameterEXT_MU_CONT.Value = extmucont
                        End If

                        Dim taxamount As Decimal = 0.0
                        Dim taxmuamount As Decimal = 0.0
                        Dim taxcontamt As Decimal = 0.0
                        'If taxresale = 1 Then
                        If functionTaxCommOnly <> 1 Then
                            taxamount = Math.Round((extamt * (taxState / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((extamt * (taxCounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((extamt * (taxCity / 100)), 2, MidpointRounding.AwayFromZero)
                        End If
                        If functionTaxComm = 1 Then
                            taxmuamount = Math.Round((markupamt * (taxState / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((markupamt * (taxCounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((markupamt * (taxCity / 100)), 2, MidpointRounding.AwayFromZero)
                        End If
                        If contamt > 0 Then
                            If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                taxcontamt = Math.Round((mucontamt * (taxState / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((mucontamt * (taxCounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((mucontamt * (taxCity / 100)), 2, MidpointRounding.AwayFromZero)
                            ElseIf functionTaxComm = 1 Then
                                taxcontamt = Math.Round(((contamt + mucontamt) * (taxState / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round(((contamt + mucontamt) * (taxCounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round(((contamt + mucontamt) * (taxCity / 100)), 2, MidpointRounding.AwayFromZero)
                            Else
                                taxcontamt = Math.Round((contamt * (taxState / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((contamt * (taxCounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((contamt * (taxCity / 100)), 2, MidpointRounding.AwayFromZero)
                            End If
                        End If

                        ExtraData.Add("TaxAmount", taxamount + taxmuamount)
                        ExtraData.Add("LineTotal", extamt + taxmuamount + taxamount + markupamt)
                        ExtraData.Add("ContingencyAmount", contamt + taxcontamt + extmucont)

                        If LookupSearchCriteria.Tax.TaxCode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If

                        linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                        linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                        SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                        parameterLINE_TOTAL.Value = linetotal
                        SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                        parameterLINE_TOTAL_CONT.Value = linetotalcont
                        With SQL
                            .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                        End With

                        Dim EstNumber As Integer = 0
                        Dim EstCompNbr As Integer = 0
                        Dim EstQuoteNbr As Integer = 0
                        Dim EstRevNbr As Integer = 0
                        Dim SeqNbr As Integer = -1
                        Try
                            EstNumber = LookupSearchCriteria.Estimate.EstimateNumber
                        Catch ex As Exception
                            EstNumber = 0
                        End Try
                        Try
                            EstCompNbr = LookupSearchCriteria.Estimate.EstimateComponentNumber
                        Catch ex As Exception
                            EstCompNbr = 0
                        End Try
                        Try
                            EstQuoteNbr = LookupSearchCriteria.Estimate.EstimateQuoteNumber
                        Catch ex As Exception
                            EstQuoteNbr = 0
                        End Try
                        Try
                            EstRevNbr = LookupSearchCriteria.Estimate.EstimateRevisionNumber
                        Catch ex As Exception
                            EstRevNbr = 0
                        End Try
                        Try
                            SeqNbr = LookupSearchCriteria.Estimate.EstimateSequenceNumber
                        Catch ex As Exception
                            SeqNbr = -1
                        End Try

                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                        MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                        MyCmd.Parameters.Add(parameterTAX_RESALE)
                        If LookupSearchCriteria.Tax.TaxCode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    'ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using

                    End If




                End If

            End If

            SearchTax_Estimate = (From Item In ResultQuery
                                  Select Item.TaxCode,
                                         Item.Description,
                                         Item.StatePercent,
                                         Item.CountyPercent,
                                         Item.CityPercent,
                                         Item.Resale).ToList.Select(Function(Tax) New ViewModels.LookupObjects.Tax With {.TaxCode = Tax.TaxCode,
                                                                                                                              .TaxDescription = Tax.Description,
                                                                                                                              .TaxStatePct = Tax.StatePercent,
                                                                                                                              .TaxCountyPct = Tax.CountyPercent,
                                                                                                                              .TaxCityPct = Tax.CityPercent,
                                                                                                                              .taxResale = Tax.Resale,
                                                                                                                              .ExtraData = ExtraData}).ToList

        End Function

#End Region

#Region " -- Product Category -- "

        Public Function CreateLookupDisplayObject_ProductCategory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                 ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                                 ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.ProductCategory.Properties.ProductCategoryCode.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.ProductCategory.Properties.ProductCategoryName.ToString, "Name")

            LookupDisplayObject.Results = SearchProductCategory(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Product Category"

            CreateLookupDisplayObject_ProductCategory = LookupDisplayObject

        End Function
        Public Function SearchProductCategory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                             ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing

            ResultQuery = AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductCode(DbContext, LookupSearchCriteria.JobComponent.ClientCode, LookupSearchCriteria.JobComponent.DivisionCode, LookupSearchCriteria.JobComponent.ProductCode)

            SearchProductCategory = (From Item In ResultQuery
                                     Select Item.Code,
                                           Item.Description).Select(Function(VenCon) New ViewModels.LookupObjects.ProductCategory With {.ProductCategoryCode = VenCon.Code,
                                                                                                                                .ProductCategoryName = VenCon.Description}).ToList

        End Function

#End Region

#Region " -- Assignment -- "

        Public Function CreateLookupDisplayObject_Assignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                             ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                                             ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Webvantage.ViewModels.LookupDisplayObject

            'objects
            Dim LookupDisplayObject As Webvantage.ViewModels.LookupDisplayObject = Nothing

            LookupDisplayObject = New Webvantage.ViewModels.LookupDisplayObject

            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Assignment.Properties.AlertID.ToString, "Code")
            LookupDisplayObject.AddColumn(ViewModels.LookupObjects.Assignment.Properties.Description.ToString, "Subject")

            LookupDisplayObject.Results = SearchAssignments(DbContext, SecurityDbContext, SecurityModule, LookupSearchCriteria)

            LookupDisplayObject.DisplayName = "Assignments"

            CreateLookupDisplayObject_Assignment = LookupDisplayObject

        End Function
        Public Function SearchAssignments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                          ByVal SecurityModule As AdvantageFramework.Security.Modules,
                                          ByVal LookupSearchCriteria As ViewModels.LookupSearchCriteria) As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)

            'objects
            Dim ResultQuery As Generic.List(Of ViewModels.LookupDisplayObject.WorkItemDisplayObject)

            Select Case SecurityModule

                Case AdvantageFramework.Security.Modules.Employee_Timesheet

                    Dim JobNumber As Integer = 0
                    Dim JobComponentNumber As Short = 0

                    If LookupSearchCriteria.Assignment.JobNumber IsNot Nothing Then

                        JobNumber = LookupSearchCriteria.Assignment.JobNumber

                    End If
                    If LookupSearchCriteria.Assignment.JobComponentNumber IsNot Nothing Then

                        JobComponentNumber = LookupSearchCriteria.Assignment.JobComponentNumber

                    End If

                    ResultQuery = DbContext.Database.SqlQuery(Of ViewModels.LookupDisplayObject.WorkItemDisplayObject)(String.Format("EXEC [dbo].[advsp_agile_get_emp_work_items] NULL, {1}, {2}, 0;",
                                                                                                                             _Session.User.EmployeeCode,
                                                                                                                             JobNumber,
                                                                                                                             JobComponentNumber)).ToList

            End Select

            SearchAssignments = (From Item In ResultQuery
                                 Select Item.AlertID,
                                     Item.Description).Select(Function(Assn) New ViewModels.LookupObjects.Assignment With {.AlertID = Assn.AlertID,
                                     .Description = Assn.Description}).ToList

        End Function



#End Region

#End Region

#Region " Validation "

        Public Function ValidateLookUp(ByVal Values As ViewModels.StandardValidationRequest) As ViewModels.StandardValidationResult

            Dim myVal As cValidations = New cValidations(_Session.ConnectionString)
            Dim Result As New ViewModels.StandardValidationResult
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0

            Result.IsValid = False

            If String.IsNullOrWhiteSpace(Values.JobNumber) = False Then

                If IsNumeric(Values.JobNumber) = False Then

                    Result.ValidationMessage = "Invalid job number"
                    Return Result

                Else

                    JobNumber = CType(Values.JobNumber, Integer)

                End If

            End If
            If String.IsNullOrWhiteSpace(Values.JobComponentNumber) = False Then

                If IsNumeric(Values.JobNumber) = False Then

                    Result.ValidationMessage = "Invalid job component number"
                    Return Result

                Else

                    JobComponentNumber = CType(Values.JobComponentNumber, Short)

                End If

            End If
            If (JobNumber = 0) AndAlso (JobComponentNumber > 0) Then

                Result.ValidationMessage = "Please enter a job number"
                Return Result

            End If
            If JobNumber < 0 OrElse JobComponentNumber < 0 Then

                Result.ValidationMessage = "Job and component must be valid numbers"
                Return Result

            End If
            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                If myVal.ValidateJobCompNumber(JobNumber, JobComponentNumber) = False Then

                    Result.ValidationMessage = "This is not a valid job/component"
                    Return Result

                End If
                If myVal.ValidateJobCompIsViewable(_Session.UserCode, JobNumber, JobComponentNumber) = False Then

                    Result.ValidationMessage = "Access to this job/comp is denied"
                    Return Result

                End If

            End If
            If String.IsNullOrWhiteSpace(Values.ClientCode) = False Then

                If myVal.ValidateCDP(Values.ClientCode, "", "") = False Then

                    Result.ValidationMessage = "Invalid Client"
                    Return Result

                End If
                If myVal.ValidateCDPIsViewable("CL", _Session.UserCode, Values.ClientCode, "", "") = False Then

                    Result.ValidationMessage = "Access to this client is denied"
                    Return Result

                End If

            End If
            If String.IsNullOrWhiteSpace(Values.DivisionCode) = False Then
                If String.IsNullOrWhiteSpace(Values.ClientCode) = True Then

                    Result.ValidationMessage = "Cannot have a division without a client"
                    Return Result

                End If
                If myVal.ValidateCDP(Values.ClientCode, Values.DivisionCode, "") = False Then

                    Result.ValidationMessage = "Invalid Division"
                    Return Result

                End If
                If myVal.ValidateCDPIsViewable("DI", _Session.UserCode, Values.ClientCode, Values.DivisionCode, "") = False Then

                    Result.ValidationMessage = "Access to this division is denied"
                    Return Result

                End If
            End If
            If String.IsNullOrWhiteSpace(Values.ProductCode) = False Then
                If String.IsNullOrWhiteSpace(Values.ClientCode) = True OrElse String.IsNullOrWhiteSpace(Values.DivisionCode) = True Then

                    Result.ValidationMessage = "Cannot have a product without a client and division"
                    Return Result

                End If
                If myVal.ValidateCDP(Values.ClientCode, Values.DivisionCode, Values.ProductCode) = False Then

                    Result.ValidationMessage = "Invalid product"
                    Return Result

                End If
                If myVal.ValidateCDPIsViewable("CL", _Session.UserCode, Values.ClientCode, Values.DivisionCode, Values.ProductCode) = False Then

                    Result.ValidationMessage = "Access to this product is denied"
                    Return Result

                End If

            End If
            If String.IsNullOrWhiteSpace(Values.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(Values.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(Values.ProductCode) AndAlso
               (Values.JobNumber IsNot Nothing AndAlso Values.JobNumber > 0) AndAlso (Values.JobComponentNumber IsNot Nothing AndAlso Values.JobComponentNumber > 0) Then

                If myVal.ValidateCDPJCIsViewable(Values.ClientCode, Values.DivisionCode, Values.ProductCode, Values.JobNumber, Values.JobComponentNumber) = False Then

                    Result.ValidationMessage = "This Job/Comp does not exist for selected Client/Division/Product"
                    Return Result

                End If

            End If

            Result.ValidationMessage = String.Empty
            Result.IsValid = True
            Return Result

        End Function

#End Region

#End Region

    End Class

End Namespace

