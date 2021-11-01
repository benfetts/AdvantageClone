Public Class Reporting_JobDetailAnalysis
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportID As Integer = 0
    Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadUserDefinedReportInformation()

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

        Try

            If Request.QueryString("AdvancedReportWriterReport") IsNot Nothing Then

                _AdvancedReportWriterReport = CType(Request.QueryString("AdvancedReportWriterReport"), Integer)

            End If

        Catch ex As Exception
            _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Alerts
        End Try

    End Sub
    Private Sub LoadJobs()

        'objects
        Dim ClientCodesList As Generic.List(Of String) = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                If RadButtonAllJobs.Checked = False Then

                    If RadioButtonListInclude.Items(0).Selected Then

                        If RadButtonAllClients.Checked OrElse RadListBoxClients.SelectedItems.Count = 0 Then

                            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                                RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                             Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                             Select [Number] = Entity.Number,
                                                                [Description] = Entity.ToString(True)
                                                             Order By Number Descending).ToList

                            Else

                                RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                             Select [Number] = Entity.Number,
                                                                [Description] = Entity.ToString(True)
                                                             Order By Number Descending).ToList

                            End If


                        Else

                            ClientCodesList = RadListBoxClients.SelectedItems.Select(Function(Item) Item.Value).ToList

                            If ClientCodesList IsNot Nothing Then

                                If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                                    If RadButtonChooseClients.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivision.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivisionProduct.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode & "/" & Entity.ProductCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    End If

                                Else

                                    If RadButtonChooseClients.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivision.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivisionProduct.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode & "/" & Entity.ProductCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    End If

                                End If

                            End If

                        End If

                    Else

                        If RadButtonAllClients.Checked OrElse RadListBoxClients.SelectedItems.Count = 0 Then

                            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                                RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                             Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                             Select [Number] = Entity.Number,
                                                                [Description] = Entity.ToString(True)
                                                             Order By Number Descending).ToList

                            Else

                                RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                             Select [Number] = Entity.Number,
                                                                [Description] = Entity.ToString(True)
                                                             Order By Number Descending).ToList

                            End If

                        Else

                            ClientCodesList = RadListBoxClients.SelectedItems.Select(Function(Item) Item.Value).ToList

                            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                                If ClientCodesList IsNot Nothing Then

                                    If RadButtonChooseClients.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivision.Checked Then


                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivisionProduct.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode & "/" & Entity.ProductCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    End If

                                End If

                            Else

                                If ClientCodesList IsNot Nothing Then

                                    If RadButtonChooseClients.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivision.Checked Then


                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    ElseIf RadButtonChooseClientDivisionProduct.Checked Then

                                        RadListBoxJobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                                     Where ClientCodesList.Contains(Entity.ClientCode & "/" & Entity.DivisionCode & "/" & Entity.ProductCode) = True
                                                                     Select [Number] = Entity.Number,
                                                                        [Description] = Entity.ToString(True)
                                                                     Order By Number Descending).ToList

                                    End If

                                End If

                            End If

                        End If

                    End If

                Else
                    If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                        RadListBoxJobs.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Job)
                                                     Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                     Select [Number] = Entity.Number,
                                                        [Description] = Entity.Description
                                                     Order By Number Descending).ToList

                    Else

                        RadListBoxJobs.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Job)
                                                     Select [Number] = Entity.Number,
                                                        [Description] = Entity.Description
                                                     Order By Number Descending).ToList

                    End If

                End If

                RadListBoxJobs.DataBind()

            End Using

        End Using

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                RadListBoxOffices.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                               Where UserEmployeeOfficeList.Any(Function(UsrOfficeAccess) UsrOfficeAccess.OfficeCode = Entity.Code) = True
                                               Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

            Else

                RadListBoxOffices.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                               Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

            End If

            RadListBoxOffices.DataBind()

        End Using

    End Sub
    Private Sub LoadClients()

        Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                    Product = AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False).ToList

                    RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                    Join d In Division On Item.Code Equals d.ClientCode
                                                    Join p In Product On d.ClientCode Equals p.ClientCode And d.Code Equals p.DivisionCode
                                                    Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On p.OfficeCode Equals EmpOffice.OfficeCode
                                                    Select [Code] = Item.Code,
                                                       [Name] = Item.ToString Distinct)

                Else

                    RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                    Select [Code] = Item.Code,
                                                       [Name] = Item.ToString)

                End If

                RadListBoxClients.DataBind()

            End Using

        End Using

    End Sub
    Private Sub LoadClientDivisions()

        Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                    Product = AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False).ToList

                    RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.DivisionView.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                    Join p In Product On Item.ClientCode Equals p.ClientCode And Item.DivisionCode Equals p.DivisionCode
                                                    Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On p.OfficeCode Equals EmpOffice.OfficeCode
                                                    Where Item.ClientActiveFlag = 1
                                                    Select Item.ClientCode,
                                                       Item.ClientName,
                                                       Item.DivisionCode,
                                                       Item.DivisionName Distinct).ToList.Select(Function(Div) New With {.Code = Div.ClientCode & "/" & Div.DivisionCode,
                                                                                                                .Name = Div.ClientName & "/" & Div.DivisionName}).ToList

                Else

                    RadListBoxClients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                    Where Entity.ClientActiveFlag = 1
                                                    Select Entity.ClientCode,
                                                   Entity.ClientName,
                                                   Entity.DivisionCode,
                                                   Entity.DivisionName).ToList.Select(Function(Div) New With {.Code = Div.ClientCode & "/" & Div.DivisionCode,
                                                                                                              .Name = Div.ClientName & "/" & Div.DivisionName}).ToList

                End If


                RadListBoxClients.DataBind()

            End Using
        End Using

    End Sub
    Private Sub LoadClientDivisionProducts()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                    RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.ProductView.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                    Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On Item.OfficeCode Equals EmpOffice.OfficeCode
                                                    Where Item.ClientActiveFlag = 1 AndAlso
                                                          Item.DivisionActiveFlag = 1
                                                    Select Item.ClientCode,
                                                           Item.ClientName,
                                                           Item.DivisionCode,
                                                           Item.DivisionName,
                                                           Item.ProductCode,
                                                           Item.ProductDescription).ToList.Select(Function(Prod) New With {.Code = Prod.ClientCode & "/" & Prod.DivisionCode & "/" & Prod.ProductCode,
                                                                                                                       .Name = Prod.ClientName & "/" & Prod.DivisionName & "/" & Prod.ProductDescription}).ToList

                Else

                    RadListBoxClients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                    Where Entity.ClientActiveFlag = 1 AndAlso
                                                      Entity.DivisionActiveFlag = 1
                                                    Select Entity.ClientCode,
                                                       Entity.ClientName,
                                                       Entity.DivisionCode,
                                                       Entity.DivisionName,
                                                       Entity.ProductCode,
                                                       Entity.ProductDescription).ToList.Select(Function(Prod) New With {.Code = Prod.ClientCode & "/" & Prod.DivisionCode & "/" & Prod.ProductCode,
                                                                                                                     .Name = Prod.ClientName & "/" & Prod.DivisionName & "/" & Prod.ProductDescription}).ToList

                End If

                RadListBoxClients.DataBind()

            End Using

        End Using

    End Sub
    Private Sub LoadAccountExecutives()

        Dim DataTable As System.Data.DataTable = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                Using SqlCommand = DbContext.CreateCommand()

                    DataTable = New System.Data.DataTable

                    SqlCommand.CommandType = CommandType.StoredProcedure
                    SqlCommand.CommandText = "usp_wv_dd_account_executive"

                    SqlCommand.Parameters.AddWithValue("Client", "")
                    SqlCommand.Parameters.AddWithValue("Division", "")
                    SqlCommand.Parameters.AddWithValue("Product", "")
                    SqlCommand.Parameters.AddWithValue("USER_CODE", _Session.User.UserCode)

                    SqlCommand.Connection.Open()

                    Try

                        DataTable.Load(SqlCommand.ExecuteReader)

                    Catch ex As Exception
                        DataTable = Nothing
                    Finally
                        SqlCommand.Connection.Close()
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Using

        'objects
        'Dim AccountExecutives As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
        'Dim AccessibleEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        'Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing
        'Dim UserCDPAccessList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '        ' AccessibleEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode).ToList

        '        UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList
        '        UserCDPAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, _Session.UserCode).ToList
        '        AccountExecutives = AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").Include("Product").ToList.Where(Function(Entity) Entity.Employee.TerminationDate Is Nothing).ToList

        '        If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

        '            AccountExecutives = (From Entity In AccountExecutives
        '                                 Where UserOfficeAccessList.Contains(Entity.Product.OfficeCode) = True
        '                                 Select Entity).ToList

        '        End If

        '        If UserCDPAccessList IsNot Nothing AndAlso UserCDPAccessList.Count > 0 Then

        '            AccountExecutives = (From Entity In AccountExecutives
        '                                 Join CDP In UserCDPAccessList On CDP.ClientCode Equals Entity.ClientCode And CDP.DivisionCode Equals Entity.DivisionCode And CDP.ProductCode Equals Entity.ProductCode
        '                                 Select Entity).ToList

        '        End If

        '        RadListBoxAccountExecutives.DataSource = (From Entity In AccountExecutives
        '                                                  Select [Code] = Entity.Employee.Code,
        '                                                         [Name] = Entity.Employee.ToString
        '                                                  Distinct).ToList
        RadListBoxAccountExecutives.DataSource = DataTable
        RadListBoxAccountExecutives.DataBind()

        '    End Using

        'End Using

    End Sub
    Private Sub LoadSalesClasses()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadListBoxSalesClasses.DataSource = From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList
                                                Select [Code] = Entity.Code,
                                                       [Description] = Entity.ToString

            RadListBoxSalesClasses.DataBind()

        End Using

    End Sub
    Private Sub SaveReportOptions()

        Try

            Response.Cookies("Reporting_JobDetailAnalysis").Expires = Now.AddYears(1)

            If RadioButtonSortBy.SelectedValue = "1" Then

                Response.Cookies("Reporting_JobDetailAnalysis")("SortBy") = "ClientDivisionProduct"

            Else

                Response.Cookies("Reporting_JobDetailAnalysis")("SortBy") = "AccountExecutive"

            End If

            If RadioButtonListInclude.SelectedValue = "1" Then

                Response.Cookies("Reporting_JobDetailAnalysis")("Include") = "OpenJobsOnly"

            Else

                Response.Cookies("Reporting_JobDetailAnalysis")("Include") = "OpenAndClosedJobs"

            End If

            If RadioButtonListSummary.SelectedValue = "1" Then

                Response.Cookies("Reporting_JobDetailAnalysis")("Summary") = "SummaryByFunction"

            ElseIf RadioButtonListSummary.SelectedValue = "2" Then

                Response.Cookies("Reporting_JobDetailAnalysis")("Summary") = "DetailByFunction"

            ElseIf RadioButtonListSummary.SelectedValue = "3" Then

                Response.Cookies("Reporting_JobDetailAnalysis")("Summary") = "SummaryByJobComp"

            Else

                Response.Cookies("Reporting_JobDetailAnalysis")("Summary") = "SummaryByFunction"

            End If

            Response.Cookies("Reporting_JobDetailAnalysis")("ExcludeNonBillableHours") = CheckBoxOtherOptionsExcludeNonBillableHours.Checked

            Response.Cookies("Reporting_JobDetailAnalysis")("SuppressZero") = CheckBoxSuppressZeroMUDown.Checked

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadReportOptions()

        Try

            If Request.Cookies("Reporting_JobDetailAnalysis")("SortBy") = "ClientDivisionProduct" Then

                RadioButtonSortBy.SelectedValue = "1"

            Else

                RadioButtonSortBy.SelectedValue = "2"

            End If

            If Request.Cookies("Reporting_JobDetailAnalysis")("Include") = "OpenJobsOnly" Then

                RadioButtonListInclude.SelectedValue = "1"

            Else

                RadioButtonListInclude.SelectedValue = "2"

            End If

            If Request.Cookies("Reporting_JobDetailAnalysis")("Summary") = "SummaryByFunction" Then

                RadioButtonListSummary.SelectedValue = "1"

            ElseIf Request.Cookies("Reporting_JobDetailAnalysis")("Summary") = "DetailByFunction" Then

                RadioButtonListSummary.SelectedValue = "2"

            ElseIf Request.Cookies("Reporting_JobDetailAnalysis")("Summary") = "SummaryByJobComp" Then

                RadioButtonListSummary.SelectedValue = "3"

            End If

            If Request.Cookies("Reporting_JobDetailAnalysis")("ExcludeNonBillableHours") = "True" Then

                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = True

            Else

                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False

            End If

            If Request.Cookies("Reporting_JobDetailAnalysis")("SuppressZero") = "True" Then

                CheckBoxSuppressZeroMUDown.Checked = True

            Else

                CheckBoxSuppressZeroMUDown.Checked = False

            End If

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_JobDetailAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadUserDefinedReportInformation()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then
            'RadButtonSummarybyJobComp.Enabled = False
            RadioButtonListSummary.Items.FindByValue("3").Enabled = False
            ' RadButtonOpenJobs.Visible = False
            ' RadButtonOpenClosedJobs.Visible = False

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobDetailAnalysisRTP)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxDateCutoff.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxDateCutoff.DataBind()

                Try
                    RadComboBoxDateCutoff.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                    'RadComboBoxDateCutoff.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Now.Month, Now.Year).ToString
                Catch ex As Exception

                End Try


            End Using

            Me.RadListBoxVersion.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.JobDetailAnalysisReportTypes))
                                               Select [Code] = EnumObject.Code,
                                                      [Description] = EnumObject.ToString).ToList
            Me.RadListBoxVersion.DataTextField = "Description"
            Me.RadListBoxVersion.DataValueField = "Code"
            Me.RadListBoxVersion.DataBind()

            If _UserDefinedReportID > 0 Then

                If _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary Then

                    RadListBoxVersion.SelectedValue = "v001"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail Then

                    RadListBoxVersion.SelectedValue = "v001"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary Then

                    RadListBoxVersion.SelectedValue = "v010"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail Then

                    RadListBoxVersion.SelectedValue = "v010"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary Then

                    RadListBoxVersion.SelectedValue = "v011"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail Then

                    RadListBoxVersion.SelectedValue = "v011"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = True
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp Then

                    RadListBoxVersion.SelectedValue = "v011"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = True
                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail Then

                    RadListBoxVersion.SelectedValue = "v002"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary Then

                    RadListBoxVersion.SelectedValue = "v002"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp Then

                    RadListBoxVersion.SelectedValue = "v003"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary Then

                    RadListBoxVersion.SelectedValue = "v003"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail Then

                    RadListBoxVersion.SelectedValue = "v004"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary Then

                    RadListBoxVersion.SelectedValue = "v004"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd Then

                    RadListBoxVersion.SelectedValue = "v005"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary Then

                    RadListBoxVersion.SelectedValue = "v005"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 Then

                    RadListBoxVersion.SelectedValue = "v006"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 Then

                    RadListBoxVersion.SelectedValue = "v007"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 Then

                    RadListBoxVersion.SelectedValue = "v008"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary Then

                    RadListBoxVersion.SelectedValue = "v009"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail Then

                    RadListBoxVersion.SelectedValue = "v009"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = True
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                    RadListBoxVersion.SelectedValue = "v009"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected =
                    RadioButtonListSummary.Items.FindByValue("3").Selected = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 Then

                    RadListBoxVersion.SelectedValue = "v029"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = True
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail Then

                    RadListBoxVersion.SelectedValue = "v030"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = True
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary Then

                    RadListBoxVersion.SelectedValue = "v030"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp Then

                    RadListBoxVersion.SelectedValue = "v030"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = False
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 Then

                    RadListBoxVersion.SelectedValue = "v031"
                    RadioButtonListSummary.Items.FindByValue("1").Selected = True
                    RadioButtonListSummary.Items.FindByValue("2").Selected = False
                    RadioButtonListSummary.Items.FindByValue("3").Selected = False


                End If

                RadListBoxVersion.Enabled = False
                RadioButtonListSummary.Items.FindByValue("1").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False

            End If

            LoadOffices()

            LoadClientDivisions()

            LoadClientDivisionProducts()

            LoadClients()

            LoadJobs()

            LoadAccountExecutives()

            LoadSalesClasses()

            If Request.Cookies("Reporting_JobDetailAnalysis") IsNot Nothing Then

                LoadReportOptions()

            Else

                Me.RadioButtonListInclude.SelectedValue = "1"
                Me.RadioButtonSortBy.SelectedValue = "1"

            End If

            RadioButtonListSummary.Items.FindByValue("1").Selected = True

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarJobDetailAnalysis_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobDetailAnalysis.ButtonClick

        'objects
        Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
        Dim CDPString As String

        Dim clients As New System.Collections.Generic.List(Of String)
        Dim divisions As New System.Collections.Generic.List(Of String)
        Dim products As New System.Collections.Generic.List(Of String)

        Select Case e.Item.Value

            Case "View"

                If CheckBoxOtherOptionsSaveReportOptions.Checked Then

                    SaveReportOptions()

                End If

                Session("JobDetailAnalysis_SelectedOffices") = Nothing
                Session("JobDetailAnalysis_SelectedClients") = Nothing
                Session("JobDetailAnalysis_SelectedDivisions") = Nothing
                Session("JobDetailAnalysis_SelectedProducts") = Nothing
                Session("JobDetailAnalysis_SelectedJobs") = Nothing
                Session("JobDetailAnalysis_SelectedAccountExecutives") = Nothing
                Session("JobDetailAnalysis_SelectedSalesClasses") = Nothing
                Session("JobDetailAnalysis_Include") = Nothing
                Session("JobDetailAnalysis_ExcludeNonBillableHours") = Nothing
                Session("JobDetailAnalysis_SortBy") = Nothing
                Session("JobDetailAnalysis_SuppressZeroMUDown") = Nothing

                If RadListBoxVersion.SelectedItems.Count = 0 Then

                    Me.ShowMessage("Please select a report version.")
                    Exit Sub

                End If

                If RadListBoxVersion.SelectedValue = "v001" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v010" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v011" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary

                    ElseIf RadioButtonListSummary.Items.FindByValue("2").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail

                    ElseIf RadioButtonListSummary.Items.FindByValue("3").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v002" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v003" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v004" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail

                    End If
                ElseIf RadListBoxVersion.SelectedValue = "v005" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary

                    Else

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v006" Then

                    Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6

                ElseIf RadListBoxVersion.SelectedValue = "v007" Then

                    Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7

                ElseIf RadListBoxVersion.SelectedValue = "v008" Then

                    Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8


                ElseIf RadListBoxVersion.SelectedValue = "v029" Then

                    Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29

                ElseIf RadListBoxVersion.SelectedValue = "v030" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary

                    ElseIf RadioButtonListSummary.Items.FindByValue("2").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail

                    ElseIf RadioButtonListSummary.Items.FindByValue("3").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp

                    End If

                ElseIf RadListBoxVersion.SelectedValue = "v031" Then

                    Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31

                ElseIf RadListBoxVersion.SelectedValue = "v009" Then

                    If RadioButtonListSummary.Items.FindByValue("1").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary

                    ElseIf RadioButtonListSummary.Items.FindByValue("2").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail

                    ElseIf RadioButtonListSummary.Items.FindByValue("3").Selected Then

                        Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp

                    End If


                End If

                If _UserDefinedReportID > 0 Then

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Report = AdvantageFramework.Reporting.ReportTypes.UserDefined

                End If

                If RadButtonAllOffices.Checked Then

                    Session("JobDetailAnalysis_SelectedOffices") = Nothing

                Else

                    If RadListBoxOffices.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Office.")
                        Exit Sub
                    Else
                        Session("JobDetailAnalysis_SelectedOffices") = (From RadListBoxItem In RadListBoxOffices.SelectedItems
                                                                        Select RadListBoxItem.Value).ToList
                    End If

                End If

                If RadButtonAllClients.Checked Then

                    Session("JobDetailAnalysis_SelectedClients") = Nothing

                Else

                    If RadButtonChooseClients.Checked = True Then

                        If RadListBoxClients.SelectedItems.Count = 0 Then
                            Me.ShowMessage("Please select an Client.")
                            Exit Sub
                        Else
                            Session("JobDetailAnalysis_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                            Select RadListBoxItem.Value).ToList
                        End If

                    End If
                    If RadButtonChooseClientDivision.Checked = True Then

                        If RadListBoxClients.SelectedItems.Count = 0 Then
                            Me.ShowMessage("Please select an Client/Division.")
                            Exit Sub
                        Else
                            Session("JobDetailAnalysis_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                            Select RadListBoxItem.Value).ToList

                            CDPString = Join(Session("JobDetailAnalysis_SelectedClients").ToArray, ",")

                            Dim CD() As String = CDPString.Split(",")
                            If CD.Count > 0 Then
                                For i As Integer = 0 To CD.Count - 1
                                    If CD(i) <> "" Then
                                        Dim division() As String = CD(i).Split("/")
                                        clients.Add(division(0))
                                        divisions.Add(division(0) & "|" & division(1))
                                    End If
                                Next
                            End If

                            Session("JobDetailAnalysis_SelectedClients") = Nothing 'clients
                            Session("JobDetailAnalysis_SelectedDivisions") = divisions
                        End If

                    End If
                    If RadButtonChooseClientDivisionProduct.Checked = True Then

                        If RadListBoxClients.SelectedItems.Count = 0 Then
                            Me.ShowMessage("Please select an Client/Division/Product.")
                            Exit Sub
                        Else
                            Session("JobDetailAnalysis_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                            Select RadListBoxItem.Value).ToList

                            CDPString = Join(Session("JobDetailAnalysis_SelectedClients").ToArray, ",")

                            Dim CDP() As String = CDPString.Split(",")
                            If CDP.Count > 0 Then
                                For i As Integer = 0 To CDP.Count - 1
                                    If CDP(i) <> "" Then
                                        Dim product() As String = CDP(i).Split("/")
                                        clients.Add(product(0))
                                        divisions.Add(product(1))
                                        products.Add(product(0) & "|" & product(1) & "|" & product(2))
                                    End If
                                Next
                            End If

                            Session("JobDetailAnalysis_SelectedClients") = Nothing 'clients
                            Session("JobDetailAnalysis_SelectedDivisions") = Nothing 'divisions
                            Session("JobDetailAnalysis_SelectedProducts") = products
                        End If

                    End If

                End If

                If RadButtonAllJobs.Checked Then

                    Session("JobDetailAnalysis_SelectedJobs") = Nothing

                Else

                    If RadListBoxJobs.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Job.")
                        Exit Sub
                    Else
                        Session("JobDetailAnalysis_SelectedJobs") = (From RadListBoxItem In RadListBoxJobs.SelectedItems
                                                                     Select RadListBoxItem.Value).ToList
                    End If

                End If

                If RadButtonAllAccountExecutives.Checked Then

                    Session("JobDetailAnalysis_SelectedAccountExecutives") = Nothing

                Else

                    If RadListBoxAccountExecutives.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Account Executive.")
                        Exit Sub
                    Else
                        Session("JobDetailAnalysis_SelectedAccountExecutives") = (From RadListBoxItem In RadListBoxAccountExecutives.SelectedItems
                                                                                  Select RadListBoxItem.Value).ToList
                    End If

                End If

                If RadButtonAllSalesClasses.Checked Then

                    Session("JobDetailAnalysis_SelectedSalesClasses") = Nothing

                Else

                    If RadListBoxSalesClasses.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Sales Class.")
                        Exit Sub
                    Else
                        Session("JobDetailAnalysis_SelectedSalesClasses") = (From RadListBoxItem In RadListBoxSalesClasses.SelectedItems
                                                                             Select RadListBoxItem.Value).ToList
                    End If

                End If

                If RadioButtonSortBy.SelectedValue = "1" Then

                    Session("JobDetailAnalysis_SortBy") = "ClientDivisionProduct"

                Else

                    Session("JobDetailAnalysis_SortBy") = "AccountExecutive"

                End If

                If RadioButtonListInclude.SelectedValue = "1" Then

                    Session("JobDetailAnalysis_Include") = "OpenJobsOnly"

                Else

                    Session("JobDetailAnalysis_Include") = "OpenAndClosedJobs"

                End If

                Session("JobDetailAnalysis_ExcludeNonBillableHours") = CheckBoxOtherOptionsExcludeNonBillableHours.Checked
                Session("JobDetailAnalysis_DateCutOff") = RadComboBoxDateCutoff.SelectedValue
                Session("JobDetailAnalysis_SuppressZeroMUDown") = CheckBoxSuppressZeroMUDown.Checked

                MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & "")

        End Select

    End Sub
    'Private Sub RadButtonOpenClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonOpenClosedJobs.CheckedChanged

    '    LoadJobs()

    'End Sub
    'Private Sub RadButtonOpenJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonOpenJobs.CheckedChanged

    '    LoadJobs()

    'End Sub
    Private Sub RadButtonAllOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllOffices.CheckedChanged

        RadListBoxOffices.Enabled = Not RadButtonAllOffices.Checked

    End Sub
    Private Sub RadButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseOffices.CheckedChanged

        RadListBoxOffices.Enabled = RadButtonChooseOffices.Checked

        If RadButtonChooseOffices.Checked Then

            RadListBoxOffices.Items(0).Selected = True

        End If

    End Sub
    Private Sub RadButtonAllClients_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllClients.CheckedChanged

        If RadButtonAllClients.Checked Then

            RadListBoxClients.Enabled = False

            LoadJobs()

        End If

    End Sub
    Private Sub RadButtonChooseClients_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClients.CheckedChanged

        If RadButtonChooseClients.Checked Then

            RadListBoxClients.Enabled = True

            LoadClients()

            RadListBoxClients.Items(0).Selected = True

            LoadJobs()

        End If

    End Sub
    Private Sub RadButtonChooseClientDivisions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClientDivision.CheckedChanged

        If RadButtonChooseClientDivision.Checked Then

            RadListBoxClients.Enabled = True

            LoadClientDivisions()

            RadListBoxClients.Items(0).Selected = True

            LoadJobs()

        End If

    End Sub
    Private Sub RadButtonChooseClientDivsionProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClientDivisionProduct.CheckedChanged

        If RadButtonChooseClientDivisionProduct.Checked Then

            RadListBoxClients.Enabled = True

            LoadClientDivisionProducts()

            RadListBoxClients.Items(0).Selected = True

            LoadJobs()

        End If

    End Sub
    Private Sub RadButtonAllJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllJobs.CheckedChanged

        RadListBoxJobs.Enabled = Not RadButtonAllJobs.Checked
        'RadButtonOpenJobs.Enabled = Not RadButtonAllJobs.Checked
        'RadButtonOpenClosedJobs.Enabled = Not RadButtonAllJobs.Checked

        LoadJobs()

    End Sub
    Private Sub RadButtonChooseJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseJobs.CheckedChanged

        RadListBoxJobs.Enabled = RadButtonChooseJobs.Checked
        'RadButtonOpenJobs.Enabled = RadButtonChooseJobs.Checked
        'RadButtonOpenClosedJobs.Enabled = RadButtonChooseJobs.Checked

        LoadJobs()

        If RadButtonChooseJobs.Checked Then
            RadListBoxJobs.Items(0).Selected = True
        End If

    End Sub
    Private Sub RadButtonAllAccountExecutives_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllAccountExecutives.CheckedChanged

        RadListBoxAccountExecutives.Enabled = Not RadButtonAllAccountExecutives.Checked

    End Sub
    Private Sub RadButtonChooseAccountExecutives_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseAccountExecutives.CheckedChanged

        RadListBoxAccountExecutives.Enabled = RadButtonChooseAccountExecutives.Checked

        If RadButtonChooseAccountExecutives.Checked Then

            RadListBoxAccountExecutives.Items(0).Selected = True

        End If


    End Sub
    Private Sub RadButtonAllSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllSalesClasses.CheckedChanged

        RadListBoxSalesClasses.Enabled = Not RadButtonAllSalesClasses.Checked

    End Sub
    Private Sub RadButtonChooseSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseSalesClasses.CheckedChanged

        RadListBoxSalesClasses.Enabled = RadButtonChooseSalesClasses.Checked

        If RadButtonChooseSalesClasses.Checked Then

            RadListBoxSalesClasses.Items(0).Selected = True

        End If

    End Sub
    Private Sub RadListBoxClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListBoxClients.SelectedIndexChanged

        LoadJobs()

    End Sub
    Private Sub RadListBoxVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxVersion.SelectedIndexChanged
        Try
            If RadListBoxVersion.SelectedValue = "v011" Then
                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = False
                CheckBoxSuppressZeroMUDown.Enabled = False
                CheckBoxSuppressZeroMUDown.Checked = False
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v029" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = False
                RadioButtonListSummary.Items.FindByValue("1").Selected = False
                RadioButtonListSummary.Items.FindByValue("2").Enabled = True
                RadioButtonListSummary.Items.FindByValue("2").Selected = True
                RadioButtonListSummary.Items.FindByValue("3").Enabled = False
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxSuppressZeroMUDown.Enabled = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v030" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = True
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxSuppressZeroMUDown.Enabled = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v031" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = False
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxSuppressZeroMUDown.Enabled = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v003" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxSuppressZeroMUDown.Enabled = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v005" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Cli/Div/Prd"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Enabled = True
                CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v006" Or RadListBoxVersion.SelectedValue = "v007" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = False
                RadioButtonListSummary.Items.FindByValue("1").Selected = False
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = False
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Enabled = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = False
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            ElseIf RadListBoxVersion.SelectedValue = "v008" Then
                RadioButtonListSummary.Items.FindByValue("1").Enabled = False
                RadioButtonListSummary.Items.FindByValue("1").Selected = False
                RadioButtonListSummary.Items.FindByValue("2").Enabled = False
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = False
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Enabled = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = False
                CheckBoxSuppressZeroMUDown.Checked = False
                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = False
                RadioButtonSortBy.Items.FindByValue("2").Selected = False
            ElseIf RadListBoxVersion.SelectedValue = "v009" Then
                CheckBoxOtherOptionsExcludeNonBillableHours.Checked = False
                Me.CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = False
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = True
                RadioButtonListSummary.Items.FindByValue("2").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Enabled = False
                CheckBoxSuppressZeroMUDown.Checked = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            Else
                Me.CheckBoxOtherOptionsExcludeNonBillableHours.Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Enabled = True
                RadioButtonListSummary.Items.FindByValue("1").Selected = True
                RadioButtonListSummary.Items.FindByValue("2").Enabled = True
                RadioButtonListSummary.Items.FindByValue("3").Enabled = False
                RadioButtonListSummary.Items.FindByValue("3").Selected = False
                RadioButtonListSummary.Items.FindByValue("3").Text = "Summary by Job Comp"
                RadComboBoxDateCutoff.Enabled = True
                CheckBoxSuppressZeroMUDown.Enabled = False
                CheckBoxSuppressZeroMUDown.Checked = False
                RadioButtonSortBy.Items.FindByValue("2").Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonListInclude_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListInclude.SelectedIndexChanged

        LoadJobs()

    End Sub

#End Region

#End Region
End Class

