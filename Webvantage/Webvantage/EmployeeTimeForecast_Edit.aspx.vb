Public Class EmployeeTimeForecast_Edit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Private Enum ToolBarCommand
        Back
        Save
        Approve
        JobComponents
        Employees
        CreateRevision
        IndirectCategories
        Unapprove
        DeleteRevision
        AlternateEmployees
        ExpandAll
        ExpandOffice
        ExpandClient
        CollapseAll
        CollapseOffice
        CollapseClient
        Bookmark
    End Enum

#End Region

#Region " Variables "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
    Private _EmployeeTimeForecastOfficeDetailID As Integer = 0
    Private _SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
    Private _EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail) = Nothing
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
    Private _DataContext As AdvantageFramework.Database.DataContext = Nothing

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Function BuildEmployeeTimeForecastOfficeDetailsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext) As System.Data.DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing

        DataTable = AdvantageFramework.EmployeeTimeForecast.BuildEmployeeTimeForecastOfficeDetailsDataTable(DbContext, DataContext, _EmployeeTimeForecastOfficeDetailID)

        BuildEmployeeTimeForecastOfficeDetailsDataTable = DataTable

    End Function
    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

        If _EmployeeTimeForecastOfficeDetail Is Nothing Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        _EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetailID = 0
                End Try

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast")
                                                         Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub
    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ForceRefresh As Boolean)

        If _EmployeeTimeForecastOfficeDetail Is Nothing OrElse ForceRefresh Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        _EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetailID = 0
                End Try

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast").
                                                                                                                                                                     Include("Office").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailIndirectCategories").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailJobComponents").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailJobComponentEmployees")
                                                         Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub
    Private Function IsEmployeeTimeForecastOfficeDetailApproved(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

        'objects
        Dim ETFIsApproved As Boolean = False

        If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

            ETFIsApproved = _EmployeeTimeForecastOfficeDetail.IsApproved

        Else

            Try

                If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                    _EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                End If

                ETFIsApproved = (From Entity In DbContext.EmployeeTimeForecastOfficeDetails
                                 Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                 Select Entity.IsApproved).Single

            Catch ex As Exception
                ETFIsApproved = False
            End Try

        End If

        IsEmployeeTimeForecastOfficeDetailApproved = ETFIsApproved

    End Function
    Private Function LoadExpandOptions() As Integer

        'objects
        Dim ExpandOption As Integer = 0

        Try

            If Request.QueryString("ExpandOption") IsNot Nothing Then

                ExpandOption = CType(Request.QueryString("ExpandOption"), Integer)

            End If

        Catch ex As Exception
            ExpandOption = 0
        End Try

        LoadExpandOptions = ExpandOption

    End Function
    Private Sub SaveEmployeeTimeForecastOfficeDetails(ByRef DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
        Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
        Dim EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
        Dim EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
        Dim EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
        Dim EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
        Dim EmployeeTimeForecastOfficeDetailJobComponentID As Integer = 0
        Dim EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer = 0
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        'Dim RadTreeListEmployeeTimeForecastOfficeDetails As Telerik.Web.UI.RadTreeList = Nothing
        Dim EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal) = Nothing
        Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        Dim AutoAlertHoursChangedForSupervisedEmployee As Boolean = False
        Dim AutoAlertHoursOverbookedForEmployee As Boolean = False

        'Try

        '    RadTreeListEmployeeTimeForecastOfficeDetails = PlaceHolderEmployeeTimeForecastOffice.FindControl("RadTreeListEmployeeTimeForecastOfficeDetails")

        'Catch ex As Exception
        '    RadTreeListEmployeeTimeForecastOfficeDetails = Nothing
        'End Try

        If RadTreeListEmployeeTimeForecastOfficeDetails IsNot Nothing Then

            SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(_DataContext)

            AutoAlertHoursChangedForSupervisedEmployee = AdvantageFramework.EmployeeTimeForecast.LoadAutoAlertHoursChangedForSupervisedEmployeeSetting(_DataContext, SettingsList)

            AutoAlertHoursOverbookedForEmployee = AdvantageFramework.EmployeeTimeForecast.LoadAutoAlertHoursOverbookedForEmployeeSetting(_DataContext, SettingsList)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                'Try

                '    Session("ETF_Datasource") = Nothing

                'Catch ex As Exception

                'End Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary = New Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal)

                    For Each TreeListDataItem In RadTreeListEmployeeTimeForecastOfficeDetails.Items.OfType(Of Telerik.Web.UI.TreeListDataItem)()

                        Integer.TryParse(TreeListDataItem.Cells(TreeListDataItem.Cells.Count - 4).Text, EmployeeTimeForecastOfficeDetailJobComponentID)

                        'Try

                        '    EmployeeTimeForecastOfficeDetailJobComponent = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.Single(Function(Entity) Entity.ID = EmployeeTimeForecastOfficeDetailJobComponentID)

                        'Catch ex As Exception
                        '    EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                        'End Try

                        'If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                        '    Try

                        '        RadNumericTextBox = TreeListDataItem.FindControl("RadNumericTextBox" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString())

                        '    Catch ex As Exception
                        '        RadNumericTextBox = Nothing
                        '    Finally

                        '        If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '            EmployeeTimeForecastOfficeDetailJobComponent.RevenueAmount = RadNumericTextBox.Value

                        '            DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponent)

                        '        End If

                        '    End Try

                        '    RadNumericTextBox = Nothing

                        '    For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        '        Try

                        '            RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        '        Catch ex As Exception
                        '            RadNumericTextBox = Nothing
                        '        Finally

                        '            If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                Try

                        '                    EmployeeTimeForecastOfficeDetailJobComponentEmployee = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees.
                        '                                                                                                                Where(Function(OfficeDetailJobComponentEmployee) OfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                        '                                                                                                                                                                    OfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID).Single

                        '                Catch ex As Exception
                        '                    EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
                        '                Finally

                        '                    If EmployeeTimeForecastOfficeDetailJobComponentEmployee IsNot Nothing Then

                        '                        If AutoAlertHoursChangedForSupervisedEmployee Then

                        '                            If AdvantageFramework.EmployeeTimeForecast.CheckToSendAlert(DbContext, SecurityDbContext, EmployeeTimeForecastOfficeDetailJobComponentEmployee, RadNumericTextBox.Value) Then

                        '                                EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee) = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                        '                            End If

                        '                        End If

                        '                        EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours = RadNumericTextBox.Value

                        '                        DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

                        '                    End If

                        '                End Try

                        '            End If

                        '        End Try

                        '    Next

                        '    For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        '        Try

                        '            RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())

                        '        Catch ex As Exception
                        '            RadNumericTextBox = Nothing
                        '        Finally

                        '            If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                Try

                        '                    EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.
                        '                                                                                                                            Where(Function(OfficeDetailJobComponentAlternateEmployee) OfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                        '                                                                                                                                                                                        OfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID).Single

                        '                Catch ex As Exception
                        '                    EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
                        '                Finally

                        '                    If EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee IsNot Nothing Then

                        '                        EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours = RadNumericTextBox.Value

                        '                        DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

                        '                    End If

                        '                End Try

                        '            End If

                        '        End Try

                        '    Next

                        'Else

                        '    Integer.TryParse(TreeListDataItem.Cells(TreeListDataItem.Cells.Count - 3).Text, EmployeeTimeForecastOfficeDetailIndirectCategoryID)

                        '    Try

                        '        EmployeeTimeForecastOfficeDetailIndirectCategory = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.Single(Function(Entity) Entity.ID = EmployeeTimeForecastOfficeDetailIndirectCategoryID)

                        '    Catch ex As Exception
                        '        EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
                        '    End Try

                        '    If EmployeeTimeForecastOfficeDetailIndirectCategory IsNot Nothing Then

                        '        RadNumericTextBox = Nothing

                        '        For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        '            Try

                        '                RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        '            Catch ex As Exception
                        '                RadNumericTextBox = Nothing
                        '            Finally

                        '                If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                    Try

                        '                        EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees.
                        '                                                                                                                        Where(Function(OfficeDetailIndirectCategoryEmployee) OfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategory.ID AndAlso
                        '                                                                                                                                                                                OfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID).Single

                        '                    Catch ex As Exception
                        '                        EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
                        '                    Finally

                        '                        If EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee IsNot Nothing Then

                        '                            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours = RadNumericTextBox.Value

                        '                            DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

                        '                        End If

                        '                    End Try

                        '                End If

                        '            End Try

                        '        Next

                        '        For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        '            Try

                        '                RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())

                        '            Catch ex As Exception
                        '                RadNumericTextBox = Nothing
                        '            Finally

                        '                If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                    Try

                        '                        EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.
                        '                                                                                                                                    Where(Function(OfficeDetailIndirectCategoryAlternateEmployee) OfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategory.ID AndAlso
                        '                                                                                                                                                                                                    OfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID).Single

                        '                    Catch ex As Exception
                        '                        EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
                        '                    Finally

                        '                        If EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee IsNot Nothing Then

                        '                            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours = RadNumericTextBox.Value

                        '                            DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

                        '                        End If

                        '                    End Try

                        '                End If

                        '            End Try

                        '        Next

                        '    Else

                        '        If EmployeeTimeForecastOfficeDetailJobComponentID = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate AndAlso
                        '                EmployeeTimeForecastOfficeDetailIndirectCategoryID = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate Then

                        '            For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                        '                Try

                        '                    RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        '                Catch ex As Exception
                        '                    RadNumericTextBox = Nothing
                        '                Finally

                        '                    If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                        EmployeeTimeForecastOfficeDetailEmployee.BillRate = RadNumericTextBox.Value

                        '                        DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailEmployee)

                        '                    End If

                        '                End Try

                        '            Next

                        '            For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                        '                Try

                        '                    RadNumericTextBox = TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())

                        '                Catch ex As Exception
                        '                    RadNumericTextBox = Nothing
                        '                Finally

                        '                    If RadNumericTextBox IsNot Nothing AndAlso RadNumericTextBox.Value IsNot Nothing Then

                        '                        EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate = RadNumericTextBox.Value

                        '                        DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailAlternateEmployee)

                        '                    End If

                        '                End Try

                        '            Next

                        '        End If

                        '    End If

                        'End If

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception
                        _EmployeeTimeForecastOfficeDetail = Nothing
                    End Try

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now

                        _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode
                        _EmployeeTimeForecastOfficeDetail.Comment = TextBoxComment.Text

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

                        If _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast IsNot Nothing Then

                            _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description = TextBoxDescription.Text

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecast.Update(DbContext, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast)

                        End If

                        If AutoAlertHoursChangedForSupervisedEmployee Then

                            AdvantageFramework.EmployeeTimeForecast.SendAlert(DbContext, SecurityDbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary)

                        End If

                        If AutoAlertHoursOverbookedForEmployee Then

                            AdvantageFramework.EmployeeTimeForecast.SendAlert(DbContext, SecurityDbContext, _EmployeeTimeForecastOfficeDetail)

                        End If

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub FormatHeaderRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        'objects
        'Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Try

            DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

        Catch ex As Exception

        End Try

        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

            TreeListDataItem.Expanded = True

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.DarkGray
                TableCell.Font.Bold = True
                TableCell.Text = ""

            Next

        Else

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.DarkGray
                TableCell.Font.Bold = True

            Next

            Try

                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

            Catch ex As Exception

            End Try

        End If

        'Try

        '    RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()).FindControl("RadNumericTextBox" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '    If RadNumericTextBox IsNot Nothing Then

        '        RadNumericTextBox.Visible = False

        '        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

        '            If RadNumericTextBox.Value IsNot Nothing Then

        '                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '            Else

        '                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()).Text = FormatNumber(0, 2)

        '            End If

        '        End If

        '    End If

        'Catch ex As Exception
        '    RadNumericTextBox = Nothing
        'End Try

        'Try

        '    RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).FindControl("RadNumericTextBox" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '    If RadNumericTextBox IsNot Nothing Then

        '        RadNumericTextBox.Visible = False

        '        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

        '            If RadNumericTextBox.Value IsNot Nothing Then

        '                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).Text = FormatCurrency(RadNumericTextBox.Value)

        '            Else

        '                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).Text = FormatCurrency(0)

        '            End If

        '        End If

        '    End If

        'Catch ex As Exception
        '    RadNumericTextBox = Nothing
        'End Try

        'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

        '    Try

        '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

        '        If RadNumericTextBox IsNot Nothing Then

        '            RadNumericTextBox.Visible = False

        '            If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

        '                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString() AndAlso _
        '                        EmployeeTimeForecastOfficeDetailEmployee.Employee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode Then

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = ""

        '                Else

        '                    If RadNumericTextBox.Value IsNot Nothing Then

        '                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '                    Else

        '                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(0, 2)

        '                    End If

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception
        '        RadNumericTextBox = Nothing
        '    End Try

        'Next

        'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

        '    Try

        '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '        If RadNumericTextBox IsNot Nothing Then

        '            RadNumericTextBox.Visible = False

        '            If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

        '                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString() AndAlso _
        '                        EmployeeTimeForecastOfficeDetailAlternateEmployee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode Then

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = ""

        '                Else

        '                    If RadNumericTextBox.Value IsNot Nothing Then

        '                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '                    Else

        '                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(0, 2)

        '                    End If

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception
        '        RadNumericTextBox = Nothing
        '    End Try

        'Next

    End Sub
    Private Sub FormatNonOfficeDetailRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        'objects
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim IsClientHeaderRow As Boolean = False
        Dim ID As Integer = 0

        Try

            Integer.TryParse(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString()).Text, ID)

            If ID = 0 Then

                Integer.TryParse(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString()).Text, ID)

                If ID = 0 Then

                    IsClientHeaderRow = True

                End If

            End If

        Catch ex As Exception
            IsClientHeaderRow = False
        End Try

        If IsClientHeaderRow Then

            Try

                DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

            Catch ex As Exception

            End Try

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.LightGray
                TableCell.Font.Bold = True
                TableCell.Wrap = False

            Next

            Try

                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

            Catch ex As Exception
                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(0)
            End Try

            'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.Visible = False
            '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), 2)

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

            'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.Visible = False
            '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Text = FormatNumber(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString), 2)

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

        Else

            'Try

            '    RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).FindControl("RadNumericTextBox" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()), Telerik.Web.UI.RadNumericTextBox)

            '    If RadNumericTextBox IsNot Nothing Then

            '        RadNumericTextBox.Visible = False

            '        If RadNumericTextBox.Value IsNot Nothing Then

            '            TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).Text = FormatCurrency(RadNumericTextBox.Value)

            '        Else

            '            TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).Text = FormatCurrency(0)

            '        End If

            '    End If

            'Catch ex As Exception
            '    RadNumericTextBox = Nothing
            'End Try

            If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString() Then

                FormatIndirectCategoryRow(TreeListDataItem)

            ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

                FormatGrandTotalsRow(TreeListDataItem)

            ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()).ToString.StartsWith("&other") Then

                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) = "&other" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString Then

                    'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                    '    Try

                    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

                    '        If RadNumericTextBox IsNot Nothing Then

                    '            RadNumericTextBox.Visible = False

                    '            If RadNumericTextBox.Value IsNot Nothing Then

                    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(RadNumericTextBox.Value)

                    '            Else

                    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(0)

                    '            End If

                    '        End If

                    '    Catch ex As Exception
                    '        RadNumericTextBox = Nothing
                    '    End Try

                    'Next

                    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                    '    Try

                    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

                    '        If RadNumericTextBox IsNot Nothing Then

                    '            RadNumericTextBox.Visible = False

                    '            If RadNumericTextBox.Value IsNot Nothing Then

                    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Text = FormatNumber(RadNumericTextBox.Value)

                    '            Else

                    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Text = FormatNumber(0)

                    '            End If

                    '        End If

                    '    Catch ex As Exception
                    '        RadNumericTextBox = Nothing
                    '    End Try

                    'Next

                Else

                    'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                    '    Try

                    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

                    '        If RadNumericTextBox IsNot Nothing Then

                    '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(RadNumericTextBox.Value)

                    '        Else

                    '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(0)

                    '        End If

                    '    Catch ex As Exception
                    '        RadNumericTextBox = Nothing
                    '    End Try

                    'Next

                    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                    '    Try

                    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

                    '        If RadNumericTextBox IsNot Nothing Then

                    '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(RadNumericTextBox.Value)

                    '        Else

                    '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(0)

                    '        End If

                    '    Catch ex As Exception
                    '        RadNumericTextBox = Nothing
                    '    End Try

                    'Next

                End If

            Else

                'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                '    Try

                '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

                '        If RadNumericTextBox IsNot Nothing Then

                '            RadNumericTextBox.MaxValue = 999.99

                '        End If

                '    Catch ex As Exception
                '        RadNumericTextBox = Nothing
                '    End Try

                'Next

                'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                '    Try

                '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

                '        If RadNumericTextBox IsNot Nothing Then

                '            RadNumericTextBox.MaxValue = 999.99

                '        End If

                '    Catch ex As Exception
                '        RadNumericTextBox = Nothing
                '    End Try

                'Next

            End If

        End If

    End Sub
    Private Sub FormatIndirectCategoryRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        ''objects
        'Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

        '    Try

        '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

        '        If RadNumericTextBox IsNot Nothing Then

        '            If EmployeeTimeForecastOfficeDetailEmployee.Employee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode Then

        '                RadNumericTextBox.MaxValue = 999.99

        '            Else

        '                RadNumericTextBox.Visible = False

        '                If RadNumericTextBox.Value IsNot Nothing Then

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '                Else

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(0, 2)

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception
        '        RadNumericTextBox = Nothing
        '    End Try

        'Next

        'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

        '    Try

        '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '        If RadNumericTextBox IsNot Nothing Then

        '            If EmployeeTimeForecastOfficeDetailAlternateEmployee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode Then

        '                RadNumericTextBox.MaxValue = 999.99

        '            Else

        '                RadNumericTextBox.Visible = False

        '                If RadNumericTextBox.Value IsNot Nothing Then

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '                Else

        '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(0, 2)

        '                End If

        '            End If

        '        End If

        '    Catch ex As Exception
        '        RadNumericTextBox = Nothing
        '    End Try

        'Next

    End Sub
    Private Sub FormatGrandTotalsRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        'objects
        'Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        'Dim ShowCostInformation As Boolean = False

        'If _SettingsList IsNot Nothing Then

        '    ShowCostInformation = AdvantageFramework.EmployeeTimeForecast.LoadShowCostInformationSetting(Nothing, _SettingsList)

        'End If

        'If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalCost.ToString() OrElse _
        '        DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.CostRate.ToString() Then

        '    TreeListDataItem.Visible = ShowCostInformation

        'End If
        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString() Then

            DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

        Else

            If AdvantageFramework.EmployeeTimeForecast.LoadUseEmployeeTitleBillingRateSetting(_DataContext) Then

                DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

            End If

        End If

        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalAmountsAndDirectHours.ToString() Then

            Try

                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).Text = ""

            Catch ex As Exception
                'RadNumericTextBox = Nothing
            End Try

        Else

            TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

        End If

        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalHours.ToString() Then

            For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                Try

                    If CDec(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text) > AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(_EmployeeStandardHoursDetailList, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) Then

                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Attributes.Add("style", "color:red !important;")

                        TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).ForeColor = Drawing.Color.Red

                    End If

                Catch ex As Exception

                End Try

            Next

        End If

        'If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString() Then 'AndAlso _
        '    'DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.CostRate.ToString() Then

        '    'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

        '    '    Try

        '    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

        '    '        If RadNumericTextBox IsNot Nothing Then

        '    '            RadNumericTextBox.Visible = False

        '    '            Try

        '    '                If CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)) <> CDbl(RadNumericTextBox.Value) Then

        '    '                    RadNumericTextBox.Value = CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

        '    '                End If

        '    '            Catch ex As Exception
        '    '                RadNumericTextBox.Value = RadNumericTextBox.Value
        '    '            End Try

        '    '            If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString() Then 'OrElse _
        '    '                'DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalCost.ToString() Then 


        '    '                If RadNumericTextBox.Value IsNot Nothing Then

        '    '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatCurrency(RadNumericTextBox.Value)

        '    '                Else

        '    '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatCurrency(0)

        '    '                End If

        '    '            Else

        '    '                If RadNumericTextBox.Value IsNot Nothing Then

        '    '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '    '                    If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalHours.ToString() Then

        '    '                        Try

        '    '                            If RadNumericTextBox.Value > AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(_EmployeeStandardHoursDetailList, EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) Then

        '    '                                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Attributes.Add("style", "color:red !important;")

        '    '                                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).ForeColor = Drawing.Color.Red

        '    '                            End If

        '    '                        Catch ex As Exception

        '    '                        End Try

        '    '                    End If

        '    '                Else

        '    '                    TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(0, 2)

        '    '                End If

        '    '            End If

        '    '        End If

        '    '    Catch ex As Exception
        '    '        RadNumericTextBox = Nothing
        '    '    End Try

        '    'Next

        '    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

        '    '    Try

        '    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '    '        If RadNumericTextBox IsNot Nothing Then

        '    '            RadNumericTextBox.Visible = False

        '    '            Try

        '    '                If CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())) <> CDbl(RadNumericTextBox.Value) Then

        '    '                    RadNumericTextBox.Value = CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()))

        '    '                End If

        '    '            Catch ex As Exception
        '    '                RadNumericTextBox.Value = RadNumericTextBox.Value
        '    '            End Try

        '    '            If RadNumericTextBox.Value IsNot Nothing Then

        '    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(RadNumericTextBox.Value, 2)

        '    '            Else

        '    '                TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).Text = FormatNumber(0, 2)

        '    '            End If

        '    '        End If

        '    '    Catch ex As Exception
        '    '        RadNumericTextBox = Nothing
        '    '    End Try

        '    'Next

        'ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString() Then 'OrElse _
        '    'DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.CostRate.ToString() Then

        '    'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

        '    '    Try

        '    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

        '    '        If RadNumericTextBox IsNot Nothing Then

        '    '            Try

        '    '                If CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)) <> CDbl(RadNumericTextBox.Value) Then

        '    '                    RadNumericTextBox.Value = CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

        '    '                End If

        '    '            Catch ex As Exception
        '    '                RadNumericTextBox.Value = RadNumericTextBox.Value
        '    '            End Try

        '    '            RadNumericTextBox.MaxValue = Double.MaxValue

        '    '            AdvantageFramework.Web.Presentation.Controls.TemplateColumn.FormatRadNumbericTextBox(AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Currency, RadNumericTextBox)

        '    '        End If

        '    '    Catch ex As Exception
        '    '        RadNumericTextBox = Nothing
        '    '    End Try

        '    'Next

        '    'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

        '    '    Try

        '    '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

        '    '        If RadNumericTextBox IsNot Nothing Then

        '    '            Try

        '    '                If CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())) <> CDbl(RadNumericTextBox.Value) Then

        '    '                    RadNumericTextBox.Value = CDbl(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()))

        '    '                End If

        '    '            Catch ex As Exception
        '    '                RadNumericTextBox.Value = RadNumericTextBox.Value
        '    '            End Try

        '    '            RadNumericTextBox.MaxValue = Double.MaxValue

        '    '            AdvantageFramework.Web.Presentation.Controls.TemplateColumn.FormatRadNumbericTextBox(AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Currency, RadNumericTextBox)

        '    '        End If

        '    '    Catch ex As Exception
        '    '        RadNumericTextBox = Nothing
        '    '    End Try

        '    'Next

        'End If

    End Sub
    Private Sub FormatOfficeDetailRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        'objects
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RevenueAmount As Decimal = 0
        Dim UtilizationAmount As Decimal = 0
        Dim IsClientHeaderRow As Boolean = False
        Dim ID As Integer = 0

        Try

            Integer.TryParse(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString()).Text, ID)

            If ID = 0 Then

                Integer.TryParse(TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString()).Text, ID)

                If ID = 0 Then

                    IsClientHeaderRow = True

                End If

            End If

        Catch ex As Exception
            IsClientHeaderRow = False
        End Try

        If IsClientHeaderRow Then

            Try

                DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

            Catch ex As Exception

            End Try

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.LightGray
                TableCell.Font.Bold = True
                TableCell.Wrap = False

            Next

            TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

            'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.Visible = False
            '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Text = FormatNumber(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), 2)

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

            'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.Visible = False
            '            TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Text = FormatNumber(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString), 2)

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

        Else

            'For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.MaxValue = 999.99

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

            'For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

            '    Try

            '        RadNumericTextBox = DirectCast(TreeListDataItem.Item("TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).FindControl("RadNumericTextBox" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), Telerik.Web.UI.RadNumericTextBox)

            '        If RadNumericTextBox IsNot Nothing Then

            '            RadNumericTextBox.MaxValue = 999.99

            '        End If

            '    Catch ex As Exception
            '        RadNumericTextBox = Nothing
            '    End Try

            'Next

            TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

            Try

                RevenueAmount = DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString())

            Catch ex As Exception
                RevenueAmount = 0
            End Try

            Try

                UtilizationAmount = DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString())

            Catch ex As Exception
                UtilizationAmount = 0
            End Try

            If UtilizationAmount > RevenueAmount Then

                Try

                    TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString()).ForeColor = Drawing.Color.Red

                    TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString()).Attributes.Add("style", "color:red !important;")

                Catch ex As Exception

                End Try

            End If

        End If

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)

        If PropertyDescriptor IsNot Nothing Then

            TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

        End If

    End Sub
    Private Sub CheckToCollapseNode(ByVal TreeListDataItem As Telerik.Web.UI.TreeListDataItem, ByVal NestedLevel As Integer)

        If TreeListDataItem.HierarchyIndex.NestedLevel = NestedLevel Then

            If TreeListDataItem.DataItem IsNot Nothing AndAlso TypeOf TreeListDataItem.DataItem Is System.Data.DataRowView Then

                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) <> "" OrElse
                        DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                    TreeListDataItem.Expanded = False

                End If

            Else

                TreeListDataItem.Expanded = False

            End If

        End If

        If TreeListDataItem.ChildItems.Any Then

            For Each ChildTreeListDataItem In TreeListDataItem.ChildItems.ToList

                CheckToCollapseNode(ChildTreeListDataItem, NestedLevel)

            Next

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_Edit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Session("ETF_Datasource") = Nothing

        End If

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
        _SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
        _DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        Try

            If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                _EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

            End If

        Catch ex As Exception
            _EmployeeTimeForecastOfficeDetailID = 0
        End Try

    End Sub
    Private Sub EmployeeTimeForecast_Edit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        'Dim RadTreeListEmployeeTimeForecastOfficeDetails As Telerik.Web.UI.RadTreeList = Nothing
        Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        'Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        Dim TreeListEditCommandColumn As Telerik.Web.UI.TreeListEditCommandColumn = Nothing
        Dim CommandName As String = ""
        Dim LoadGrid As Boolean = True
        Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        Dim TotalColumnWidth As Long = 0
        Dim OfficeRevisionsList As Generic.IEnumerable(Of Object) = Nothing
        Dim ExpandOption As Integer = 0
        Dim IsBookmark As Boolean = False
        Dim DataField As String = ""

        If Request.QueryString("bm") Is Nothing Then
            Me.PageTitle = "Employee Time Forecast Details"
        End If

        LoadControlSettings(_DbContext)

        If Me.IsPostBack Then

            Try

                CommandName = [Page].Request.Params.Get("__EVENTARGUMENT")

            Catch ex As Exception
                CommandName = ""
            Finally

                If CommandName IsNot Nothing AndAlso CommandName <> String.Empty Then

                    'LoadEmployeeTimeForecastOfficeDetail(DbContext, True)

                    If IsEmployeeTimeForecastOfficeDetailApproved(_DbContext) Then

                        If CommandName = "1" OrElse CommandName = "3" OrElse CommandName = "5" Then

                            LoadGrid = False

                        End If

                    ElseIf RadToolBarButtonEmployees.Index.ToString() = CommandName OrElse RadToolBarButtonJobComponents.Index.ToString() = CommandName OrElse
                                RadToolBarButtonIndirectCategories.Index.ToString() = CommandName OrElse CommandName = "17" OrElse
                                RadToolBarButtonAlternateEmployees.Index.ToString() = CommandName OrElse RadToolBarButtonCreateRevision.Index.ToString() = CommandName OrElse
                                RadToolBarButtonDeleteRevision.Index.ToString() = CommandName OrElse RadToolBarButtonApprove.Index.ToString() = CommandName Then

                        LoadGrid = False

                    End If


                Else

                    Try

                        CommandName = [Page].Request.Params.Get("__EVENTTARGET")

                    Catch ex As Exception
                        CommandName = ""
                    Finally

                        If CommandName IsNot Nothing AndAlso CommandName <> String.Empty Then

                            If CommandName.Contains(DropDownListEmployeeTimeForecastOfficeDetailRevision.ID) Then

                                LoadGrid = False

                            End If

                        End If

                    End Try

                End If

            End Try

        End If

        If Me.IsPostBack Then

            LoadGrid = False

        End If

        If Me.IsPostBack Then
            If Me.EventArgument = "Refresh" Then

            End If
        End If

        If LoadGrid Then

            SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(_DataContext)

            If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                LoadEmployeeTimeForecastOfficeDetail(_DbContext, True)

            Else

                LoadEmployeeTimeForecastOfficeDetail(_DbContext)

            End If

            'LoadEmployeeTimeForecastOfficeDetail(_DbContext, Not Me.IsPostBack)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                'RadTreeListEmployeeTimeForecastOfficeDetails = New Telerik.Web.UI.RadTreeList

                'RadTreeListEmployeeTimeForecastOfficeDetails.ID = "RadTreeListEmployeeTimeForecastOfficeDetails"
                RadTreeListEmployeeTimeForecastOfficeDetails.AutoGenerateColumns = False
                RadTreeListEmployeeTimeForecastOfficeDetails.EditFormSettings.PopUpSettings.Modal = False
                'RadTreeListEmployeeTimeForecastOfficeDetails.AllowMultiItemSelection = False
                'RadTreeListEmployeeTimeForecastOfficeDetails.EnableViewState = True
                'RadTreeListEmployeeTimeForecastOfficeDetails.AllowPaging = False
                'RadTreeListEmployeeTimeForecastOfficeDetails.AllowSorting = False
                RadTreeListEmployeeTimeForecastOfficeDetails.ParentDataKeyNames = New String() {AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString}
                RadTreeListEmployeeTimeForecastOfficeDetails.DataKeyNames = New String() {AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString}
                'RadTreeListEmployeeTimeForecastOfficeDetails.ShowTreeLines = False
                'RadTreeListEmployeeTimeForecastOfficeDetails.ShowOuterBorders = True
                'RadTreeListEmployeeTimeForecastOfficeDetails.GridLines = GridLines.Horizontal

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString
                TreeListBoundColumn.HeaderText = "Office"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                ''''TreeListBoundColumn.HeaderStyle.Width = 100
                TreeListBoundColumn.ReadOnly = True

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ClientName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ClientName.ToString
                TreeListBoundColumn.HeaderText = "Client"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ReadOnly = True

                ''''If AdvantageFramework.EmployeeTimeForecast.LoadShowClientDivisionProductCodesOnlySetting(_DataContext, SettingsList) Then

                ''''    TreeListBoundColumn.HeaderStyle.Width = 40

                ''''Else

                ''''    TreeListBoundColumn.HeaderStyle.Width = 100

                ''''End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.DivisionName.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.DivisionName.ToString
                TreeListBoundColumn.HeaderText = "Division"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ReadOnly = True

                ''''If AdvantageFramework.EmployeeTimeForecast.LoadShowClientDivisionProductCodesOnlySetting(_DataContext, SettingsList) Then

                ''''    TreeListBoundColumn.HeaderStyle.Width = 40

                ''''Else

                ''''    TreeListBoundColumn.HeaderStyle.Width = 100

                ''''End If

                If AdvantageFramework.EmployeeTimeForecast.LoadHideDivisionColumnSetting(_DataContext, SettingsList) Then

                    TreeListBoundColumn.Visible = False

                End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ProductDescription.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ProductDescription.ToString
                TreeListBoundColumn.HeaderText = "Product"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ReadOnly = True

                ''''If AdvantageFramework.EmployeeTimeForecast.LoadShowClientDivisionProductCodesOnlySetting(_DataContext, SettingsList) Then

                ''''    TreeListBoundColumn.HeaderStyle.Width = 40

                ''''Else

                ''''    TreeListBoundColumn.HeaderStyle.Width = 100

                ''''End If

                If AdvantageFramework.EmployeeTimeForecast.LoadHideProductColumnSetting(_DataContext, SettingsList) Then

                    TreeListBoundColumn.Visible = False

                End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString
                TreeListBoundColumn.HeaderText = "Job/Component"
                TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ReadOnly = True

                ''''If AdvantageFramework.EmployeeTimeForecast.LoadShowJobAndJobComponentDescriptionSetting(_DataContext, SettingsList) Then

                ''''    TreeListBoundColumn.HeaderStyle.Width = 200

                ''''Else

                ''''    TreeListBoundColumn.HeaderStyle.Width = 100

                ''''End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString
                TreeListBoundColumn.HeaderText = "Revenue"
                'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListBoundColumn.ItemTemplate = New AdvantageFramework.Web.Presentation.Controls.TemplateColumn(TreeListBoundColumn.DataField, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Currency, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.ParentControl.RadTreeList, _EmployeeTimeForecastOfficeDetail.IsApproved, 0, 0)
                'TreeListBoundColumn.DataFormatString = "c2"
                ''''TreeListBoundColumn.HeaderStyle.Width = 90
                TreeListBoundColumn.DataType = GetType(Double)

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString
                TreeListBoundColumn.HeaderText = "Revenue Share"
                'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                ''''TreeListBoundColumn.HeaderStyle.Width = 90
                'TreeListBoundColumn.DataFormatString = "c2"
                TreeListBoundColumn.ReadOnly = True

                If AdvantageFramework.EmployeeTimeForecast.LoadHideRevenueShareInformationSetting(_DataContext, SettingsList) Then

                    TreeListBoundColumn.Visible = False

                Else

                    TreeListBoundColumn.Visible = True

                End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString
                TreeListBoundColumn.HeaderText = "w/Revenue Share"
                'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                ''''TreeListBoundColumn.HeaderStyle.Width = 75
                ' TreeListBoundColumn.DataFormatString = "c2"
                TreeListBoundColumn.ReadOnly = True

                If AdvantageFramework.EmployeeTimeForecast.LoadHideRevenueShareInformationSetting(_DataContext, SettingsList) Then

                    TreeListBoundColumn.Visible = False

                Else

                    TreeListBoundColumn.Visible = True

                End If

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString
                TreeListBoundColumn.HeaderText = "Utilization"
                'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                ''''TreeListBoundColumn.HeaderStyle.Width = 75
                'TreeListBoundColumn.DataFormatString = "c2"
                TreeListBoundColumn.ReadOnly = True

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString
                TreeListBoundColumn.HeaderText = "Total Hours"
                'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                TreeListBoundColumn.ItemStyle.BackColor = Drawing.Color.DarkGray
                ' TreeListBoundColumn.HeaderStyle.BackColor = Drawing.Color.DarkGray
                'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                ''''TreeListBoundColumn.HeaderStyle.Width = 75
                'TreeListBoundColumn.DataFormatString = "f2"
                TreeListBoundColumn.ReadOnly = True

                TreeListEditCommandColumn = New Telerik.Web.UI.TreeListEditCommandColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListEditCommandColumn)

                TreeListEditCommandColumn.UniqueName = "TreeListEditCommandColumn"
                TreeListEditCommandColumn.HeaderText = ""
                'TreeListEditCommandColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                TreeListEditCommandColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'TreeListEditCommandColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                TreeListEditCommandColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                TreeListEditCommandColumn.HeaderStyle.Width = 25
                TreeListEditCommandColumn.ButtonType = Telerik.Web.UI.TreeListButtonColumnType.ImageButton
                TreeListEditCommandColumn.ShowAddButton = False

                For Each EmployeeTimeForecastOfficeDetailEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Include("Employee").Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode).
                                                                                                                                                        OrderBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.FirstName).
                                                                                                                                                        ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.MiddleInitial).
                                                                                                                                                        ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.LastName).ToList

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                    TreeListBoundColumn.DataField = EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode
                    TreeListBoundColumn.HeaderText = EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString
                    TreeListBoundColumn.Visible = True
                    'TreeListBoundColumn.ItemTemplate = New AdvantageFramework.Web.Presentation.Controls.TemplateColumn(TreeListBoundColumn.DataField, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Number, _
                    '                                                                                                        AdvantageFramework.Web.Presentation.Controls.TemplateColumn.ParentControl.RadTreeList, _
                    '                                                                                                        _EmployeeTimeForecastOfficeDetail.IsApproved, 0, 0)
                    'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.ItemStyle.CssClass = "RequiredInput"
                    'TreeListBoundColumn.HeaderStyle.CssClass = "RequiredInput"
                    'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    ''''TreeListBoundColumn.HeaderStyle.Width = 75
                    'TreeListBoundColumn.DataFormatString = "f2"
                    TreeListBoundColumn.DataType = GetType(Double)

                Next

                For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode).ToList

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                    TreeListBoundColumn.DataField = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString
                    TreeListBoundColumn.HeaderText = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString
                    TreeListBoundColumn.Visible = True
                    'TreeListBoundColumn.EditItemTemplate = New AdvantageFramework.Web.Presentation.Controls.TemplateColumn(TreeListBoundColumn.DataField, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Number, _
                    '                                                                                                        AdvantageFramework.Web.Presentation.Controls.TemplateColumn.ParentControl.RadTreeList, _
                    '                                                                                                        _EmployeeTimeForecastOfficeDetail.IsApproved, 0, 0)
                    'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.ItemStyle.CssClass = "RequiredInput"
                    'TreeListBoundColumn.HeaderStyle.CssClass = "RequiredInput"
                    'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    ''''TreeListBoundColumn.HeaderStyle.Width = 100
                    'TreeListBoundColumn.DataFormatString = "f2"
                    TreeListBoundColumn.DataType = GetType(Double)

                Next

                For Each EmployeeTimeForecastOfficeDetailEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Include("Employee").Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode).
                                                                                                                                                        OrderBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.FirstName).
                                                                                                                                                        ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.MiddleInitial).
                                                                                                                                                        ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.LastName).ToList

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                    TreeListBoundColumn.DataField = EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode
                    TreeListBoundColumn.HeaderText = EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString
                    TreeListBoundColumn.Visible = True
                    'TreeListBoundColumn.ItemTemplate = New AdvantageFramework.Web.Presentation.Controls.TemplateColumn(TreeListBoundColumn.DataField, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Number, _
                    '                                                                                                        AdvantageFramework.Web.Presentation.Controls.TemplateColumn.ParentControl.RadTreeList, _
                    '                                                                                                        _EmployeeTimeForecastOfficeDetail.IsApproved, 0, 0)
                    'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.ItemStyle.BackColor = Drawing.Color.LightBlue
                    'TreeListBoundColumn.HeaderStyle.BackColor = Drawing.Color.LightBlue
                    'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    ''''TreeListBoundColumn.HeaderStyle.Width = 50
                    'TreeListBoundColumn.DataFormatString = "f2"
                    TreeListBoundColumn.DataType = GetType(Double)

                Next

                For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode).ToList

                    TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                    RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                    TreeListBoundColumn.DataField = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString
                    TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString
                    TreeListBoundColumn.HeaderText = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString
                    TreeListBoundColumn.Visible = True
                    'TreeListBoundColumn.ItemTemplate = New AdvantageFramework.Web.Presentation.Controls.TemplateColumn(TreeListBoundColumn.DataField, AdvantageFramework.Web.Presentation.Controls.TemplateColumn.Type.Number, _
                    '                                                                                                        AdvantageFramework.Web.Presentation.Controls.TemplateColumn.ParentControl.RadTreeList, _
                    '                                                                                                        _EmployeeTimeForecastOfficeDetail.IsApproved, 0, 0)
                    'TreeListBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle
                    TreeListBoundColumn.ItemStyle.BackColor = Drawing.Color.LightBlue
                    'TreeListBoundColumn.HeaderStyle.BackColor = Drawing.Color.LightBlue
                    'TreeListBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    TreeListBoundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    ''''TreeListBoundColumn.HeaderStyle.Width = 50
                    'TreeListBoundColumn.DataFormatString = "f2"
                    TreeListBoundColumn.DataType = GetType(Double)

                Next

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString
                TreeListBoundColumn.HeaderText = "Employee Time Forecast Job Component ID"
                TreeListBoundColumn.Visible = False
                ''''TreeListBoundColumn.HeaderStyle.Width = 10
                TreeListBoundColumn.ReadOnly = True
                TreeListBoundColumn.ForceExtractValue = Telerik.Web.UI.TreeListForceExtractValues.Always

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString
                TreeListBoundColumn.HeaderText = "Employee Time Forecast Indirect Component ID"
                TreeListBoundColumn.Visible = False
                ''''TreeListBoundColumn.HeaderStyle.Width = 10
                TreeListBoundColumn.ReadOnly = True
                TreeListBoundColumn.ForceExtractValue = Telerik.Web.UI.TreeListForceExtractValues.Always

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Office Code"
                TreeListBoundColumn.Visible = False
                ''''TreeListBoundColumn.HeaderStyle.Width = 10
                TreeListBoundColumn.ReadOnly = True

                TreeListBoundColumn = New Telerik.Web.UI.TreeListBoundColumn

                RadTreeListEmployeeTimeForecastOfficeDetails.Columns.Add(TreeListBoundColumn)

                TreeListBoundColumn.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.UniqueName = "TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString
                TreeListBoundColumn.HeaderText = "Parent Office Code"
                TreeListBoundColumn.Visible = False
                ''''TreeListBoundColumn.HeaderStyle.Width = 10
                TreeListBoundColumn.ReadOnly = True

                'AddHandler RadTreeListEmployeeTimeForecastOfficeDetails.ItemDataBound, AddressOf RadTreeListEmployeeTimeForecastOfficeDetails_ItemDataBound
                'AddHandler RadTreeListEmployeeTimeForecastOfficeDetails.ItemCommand, AddressOf RadTreeListEmployeeTimeForecastOfficeDetails_ItemCommand
                'AddHandler RadTreeListEmployeeTimeForecastOfficeDetails.NeedDataSource, AddressOf RadTreeListEmployeeTimeForecastOfficeDetails_NeedDataSource
                'AddHandler RadTreeListEmployeeTimeForecastOfficeDetails.DataBound, AddressOf RadTreeListEmployeeTimeForecastOfficeDetails_DataBound

                ''''For Each TreeListColumn In RadTreeListEmployeeTimeForecastOfficeDetails.Columns.OfType(Of Telerik.Web.UI.TreeListColumn)().Where(Function(TLC) TLC.Visible = True).ToList

                ''''    TotalColumnWidth += TreeListColumn.HeaderStyle.Width.Value

                ''''Next

                'For Each TreeListBoundColumn In RadTreeListEmployeeTimeForecastOfficeDetails.Columns.OfType(Of Telerik.Web.UI.TreeListBoundColumn)()

                '    If TreeListBoundColumn.Visible Then

                '        TotalColumnWidth += TreeListBoundColumn.HeaderStyle.Width.Value

                '    End If

                'Next

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    'ExpandOption = LoadExpandOptions()

                    'If ExpandOption = 1 OrElse ExpandOption = 6 Then

                    '    RadTreeListEmployeeTimeForecastOfficeDetails.ExpandAllItems()

                    'ElseIf ExpandOption = 2 Then

                    '    RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(1)

                    'ElseIf ExpandOption = 3 Then

                    '    RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(2)

                    'ElseIf ExpandOption = 4 Then

                    '    RadTreeListEmployeeTimeForecastOfficeDetails.CollapseAllItems()

                    'ElseIf (ExpandOption <> 5 AndAlso ExpandOption <> 6) Then

                    If Session("ETF_ExpandedIndexes") Is Nothing Then

                        RadTreeListEmployeeTimeForecastOfficeDetails.ExpandAllItems()

                    Else

                        Try

                            RadTreeListEmployeeTimeForecastOfficeDetails.ExpandedIndexes.AddRange(Session("ETF_ExpandedIndexes"))

                        Catch ex As Exception

                        End Try

                        Try

                            Session("ETF_ExpandedIndexes") = Nothing

                        Catch ex As Exception

                        End Try

                    End If

                    'End If

                    RadToolBarButtonFirstSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonSave.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonSecondSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonJobComponents.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonThirdSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonEmployees.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonFourthSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonAlternateEmployees.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonFifthSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonIndirectCategories.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonApprove.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonUnapprove.Visible = _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonEightSeparator.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved
                    RadToolBarButtonDeleteRevision.Visible = Not _EmployeeTimeForecastOfficeDetail.IsApproved

                    OfficeRevisionsList = (From EmployeeTimeForecastOfficeDetail In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(_DbContext, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).ToList.Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = _EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode).ToList
                                           Select [Number] = AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True),
                                                   [ID] = EmployeeTimeForecastOfficeDetail.ID).ToList

                    DropDownListEmployeeTimeForecastOfficeDetailRevision.DataSource = OfficeRevisionsList
                    DropDownListEmployeeTimeForecastOfficeDetailRevision.DataBind()
                    DropDownListEmployeeTimeForecastOfficeDetailRevision.SelectedValue = _EmployeeTimeForecastOfficeDetail.ID

                    If DirectCast(OfficeRevisionsList, Generic.IEnumerable(Of Object)).Count = 1 Then

                        RadToolBarButtonDeleteRevision.Text = "Delete"
                        RadToolBarButtonDeleteRevision.ToolTip = "Delete forecast"

                    Else

                        RadToolBarButtonDeleteRevision.Text = "Delete Revision"
                        RadToolBarButtonDeleteRevision.ToolTip = "Delete revision"

                    End If

                    TextBoxDescription.ReadOnly = _EmployeeTimeForecastOfficeDetail.IsApproved
                    TextBoxComment.ReadOnly = _EmployeeTimeForecastOfficeDetail.IsApproved

                    LabelPostPeriod.Text = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Code & " - " & _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Description
                    LabelAssignedEmployee.Text = _EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString
                    LabelOffice.Text = _EmployeeTimeForecastOfficeDetail.Office.Name
                    TextBoxDescription.Text = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description
                    TextBoxComment.Text = _EmployeeTimeForecastOfficeDetail.Comment

                    LabelCreatedBy.Text = ""

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _EmployeeTimeForecastOfficeDetail.CreatedByUserCode <> "" Then

                            LabelCreatedBy.Text = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _EmployeeTimeForecastOfficeDetail.CreatedByUserCode).Employee.ToString & " on " & _EmployeeTimeForecastOfficeDetail.CreatedDate

                        End If

                        LabelModifiedBy.Text = ""

                        If _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode IsNot Nothing Then

                            LabelModifiedBy.Text = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode).Employee.ToString & " on " & _EmployeeTimeForecastOfficeDetail.ModifiedDate

                        End If

                    End Using

                    LabelApprovedBy.Text = ""

                    If _EmployeeTimeForecastOfficeDetail.ApprovedByEmployee IsNot Nothing Then

                        LabelApprovedBy.Text = _EmployeeTimeForecastOfficeDetail.ApprovedByEmployee.ToString() & " on " & _EmployeeTimeForecastOfficeDetail.ApprovedDate

                    End If

                End If

            Else

                If Not Request.QueryString("bm") Is Nothing Then

                    If Request.QueryString("bm") = "1" Then

                        IsBookmark = True

                    End If

                End If

                If IsBookmark = True Then

                    Me.ShowMessage("Forecast is no longer available. Please delete your bookmark.")
                    Me.CloseThisWindow()

                Else

                    LabelAssignedEmployee.Text = ""
                    LabelPostPeriod.Text = ""
                    LabelOffice.Text = ""
                    TextBoxDescription.Text = ""
                    LabelCreatedBy.Text = ""
                    LabelModifiedBy.Text = ""
                    LabelApprovedBy.Text = ""

                End If

            End If

        Else

            LoadEmployeeTimeForecastOfficeDetail(_DbContext)

            For Each Column In RadTreeListEmployeeTimeForecastOfficeDetails.Columns.ToList

                Try

                    DataField = DirectCast(Column, Telerik.Web.UI.TreeListBoundColumn).DataField

                Catch ex As Exception
                    DataField = ""
                End Try

                If DataField = "" OrElse DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString Then

                    Column.ItemStyle.BackColor = Drawing.Color.DarkGray

                Else

                    If IsNumeric(DataField) Then

                        If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.ID = DataField AndAlso OfficeDetailAlternateEmployee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode).Any Then

                            Column.ItemStyle.CssClass = "RequiredInput"

                        ElseIf AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.ID = DataField AndAlso OfficeDetailAlternateEmployee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode).Any Then

                            Column.ItemStyle.BackColor = Drawing.Color.LightBlue

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Include("Employee").Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode = DataField AndAlso OfficeDetailEmployee.Employee.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode).Any Then

                            Column.ItemStyle.CssClass = "RequiredInput"

                        ElseIf AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Include("Employee").Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode = DataField AndAlso OfficeDetailEmployee.Employee.OfficeCode <> _EmployeeTimeForecastOfficeDetail.OfficeCode).Any Then

                            Column.ItemStyle.BackColor = Drawing.Color.LightBlue

                        End If

                    End If

                End If

            Next

        End If

        'Me.PageTitle = "Employee Time Forecast"

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.RadToolBarEmployeeTimeForecastOffice.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        End If

    End Sub
    Private Sub EmployeeTimeForecast_Edit_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            _DbContext.Dispose()

            _DbContext = Nothing

        Catch ex As Exception

        End Try

        Try

            _DataContext.Dispose()

            _DataContext = Nothing

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_CreateColumnEditor(sender As Object, e As Telerik.Web.UI.TreeListCreateColumnEditorEventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.CreateColumnEditor

        'objects
        Dim ColumnEditor As AdvantageFramework.Web.Presentation.Controls.TreeListRadNumericTextBox = Nothing

        If e.Column.DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString Then

            ColumnEditor = New AdvantageFramework.Web.Presentation.Controls.TreeListRadNumericTextBox(e.Column)

            ColumnEditor.RadNumericTextBox.EnabledStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            ColumnEditor.RadNumericTextBox.Width = System.Web.UI.WebControls.Unit.Percentage(100)
            ColumnEditor.RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
            ColumnEditor.RadNumericTextBox.AutoPostBack = False
            ColumnEditor.RadNumericTextBox.ReadOnly = False

            ColumnEditor.RadNumericTextBox.NumberFormat.DecimalDigits = 2
            ColumnEditor.RadNumericTextBox.Type = Telerik.Web.UI.NumericType.Currency
            ColumnEditor.RadNumericTextBox.NumberFormat.GroupSizes = 3
            ColumnEditor.RadNumericTextBox.IncrementSettings.InterceptArrowKeys = False
            ColumnEditor.RadNumericTextBox.IncrementSettings.InterceptMouseWheel = False

            If RadTreeListEmployeeTimeForecastOfficeDetails.EditItems.Count > 0 Then

                If RadTreeListEmployeeTimeForecastOfficeDetails.EditItems(0).DataItem IsNot Nothing Then

                    If DirectCast(RadTreeListEmployeeTimeForecastOfficeDetails.EditItems(0).DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString OrElse
                            (IsNumeric(DirectCast(RadTreeListEmployeeTimeForecastOfficeDetails.EditItems(0).DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString())) AndAlso
                             CInt(DirectCast(RadTreeListEmployeeTimeForecastOfficeDetails.EditItems(0).DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString())) > 0) Then

                        ColumnEditor.RadNumericTextBox.ReadOnly = True

                    End If

                End If

            End If

        Else

            ColumnEditor = New AdvantageFramework.Web.Presentation.Controls.TreeListRadNumericTextBox(e.Column)

            ColumnEditor.RadNumericTextBox.EnabledStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            ColumnEditor.RadNumericTextBox.Width = System.Web.UI.WebControls.Unit.Percentage(100)
            ColumnEditor.RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
            ColumnEditor.RadNumericTextBox.AutoPostBack = False
            ColumnEditor.RadNumericTextBox.ReadOnly = False

            ColumnEditor.RadNumericTextBox.NumberFormat.DecimalDigits = 2
            ColumnEditor.RadNumericTextBox.Type = Telerik.Web.UI.NumericType.Number
            ColumnEditor.RadNumericTextBox.MaxValue = 999.99
            ColumnEditor.RadNumericTextBox.IncrementSettings.InterceptArrowKeys = False
            ColumnEditor.RadNumericTextBox.IncrementSettings.InterceptMouseWheel = False

        End If

        If ColumnEditor IsNot Nothing Then

            e.CustomEditorInitializer = New Telerik.Web.UI.TreeListCreateCustomEditorDelegate(Function() ColumnEditor)

        End If

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_UpdateCommand(sender As Object, e As Telerik.Web.UI.TreeListCommandEventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.UpdateCommand

        'objects
        Dim OldHashtable As Hashtable = Nothing
        Dim Hashtable As Hashtable = Nothing
        Dim EmployeeTimeForecastOfficeDetailJobComponentID As Integer = 0
        Dim EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer = 0
        Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
        Dim BillRate As Decimal = 0
        Dim Hours As Decimal = 0
        Dim RevenueAmount As Decimal = 0
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataRow As System.Data.DataRow = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.TreeListEditableItem Then

            Hashtable = New Hashtable

            DirectCast(e.Item, Telerik.Web.UI.TreeListEditableItem).ExtractValues(Hashtable)
            OldHashtable = DirectCast(e.Item, Telerik.Web.UI.TreeListEditableItem).SavedOldValues

            Try

                DataTable = Session("ETF_Datasource")

            Catch ex As Exception

            End Try

            If Hashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) AndAlso
                    IsNumeric(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString)) AndAlso
                    CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString)) > 0 Then

                EmployeeTimeForecastOfficeDetailJobComponentID = CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString))

                Try

                    DataRow = DataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = EmployeeTimeForecastOfficeDetailJobComponentID)

                Catch ex As Exception

                End Try

                For Each EmployeeTimeForecastOfficeDetailJobComponentEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee.LoadByEmployeeTimeForecastOfficeDetailJobComponentID(_DbContext, EmployeeTimeForecastOfficeDetailJobComponentID).Include("EmployeeTimeForecastOfficeDetailEmployee").ToList

                    If Hashtable.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) AndAlso
                            OldHashtable.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) AndAlso
                            (Hashtable(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) <> OldHashtable(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)) Then

                        'EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours = Hashtable(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        Hours = Hashtable(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLJC_EMP SET [HOURS] = {0} WHERE ETF_OFFDTLJC_EMP_ID = {1}", Hours, EmployeeTimeForecastOfficeDetailJobComponentEmployee.ID))

                        '_DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) Then

                            DataRow(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatNumber(Hours, 2)

                        End If

                    End If

                Next

                For Each EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailJobComponentID(_DbContext, EmployeeTimeForecastOfficeDetailJobComponentID).ToList

                    If Hashtable.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                            OldHashtable.ContainsKey(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                            (Hashtable(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) <> OldHashtable(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)) Then

                        'EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours = Hashtable(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                        Hours = Hashtable(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLJC_AE SET [HOURS] = {0} WHERE ETF_OFFDTLJC_AE_ID = {1}", Hours, EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.ID))

                        '_DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                            DataRow(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = FormatNumber(Hashtable(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString), 2)

                        End If

                    End If

                Next

                If Hashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) AndAlso
                        OldHashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) AndAlso
                        (Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) <> OldHashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString)) Then

                    RevenueAmount = Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString)

                    _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLJC SET REV_AMT = {0} WHERE ETF_OFFDTLJC_ID = {1}", RevenueAmount, EmployeeTimeForecastOfficeDetailJobComponentID))

                    If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) Then

                        DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = FormatCurrency(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

                    End If

                End If

                'Try

                '    _DbContext.SaveChanges()

                'Catch ex As Exception

                'End Try

            ElseIf Hashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) AndAlso
                     IsNumeric(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString)) AndAlso
                     CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString)) > 0 Then

                EmployeeTimeForecastOfficeDetailIndirectCategoryID = CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString))

                Try

                    DataRow = DataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = EmployeeTimeForecastOfficeDetailIndirectCategoryID)

                Catch ex As Exception

                End Try

                For Each EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID(_DbContext, EmployeeTimeForecastOfficeDetailIndirectCategoryID).Include("EmployeeTimeForecastOfficeDetailEmployee").ToList

                    If Hashtable.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) AndAlso
                            OldHashtable.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) AndAlso
                            (Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) <> OldHashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)) Then

                        'EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours = Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        Hours = Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLCAT_EMP SET [HOURS] = {0} WHERE ETF_OFFDTLCAT_EMP_ID = {1}", Hours, EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.ID))

                        '_DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) Then

                            DataRow(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatNumber(Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), 2)

                        End If

                    End If

                Next

                For Each EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID(_DbContext, EmployeeTimeForecastOfficeDetailIndirectCategoryID).ToList

                    If Hashtable.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                                OldHashtable.ContainsKey(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                                (Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) <> OldHashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)) Then

                        'EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours = Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                        Hours = Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLCAT_AE SET [HOURS] = {0} WHERE ETF_OFFDTLCAT_AE_ID = {1}", Hours, EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.ID))

                        '_DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                            DataRow(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = FormatNumber(Hashtable(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString), 2)

                        End If

                    End If

                Next

                'Try

                '    _DbContext.SaveChanges()

                'Catch ex As Exception

                'End Try

            ElseIf (Hashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) AndAlso
                    IsNumeric(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString)) AndAlso
                    CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString)) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate) AndAlso
                    (Hashtable.ContainsKey(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) AndAlso
                    IsNumeric(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString)) AndAlso
                    CInt(Hashtable(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString)) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate) Then

                Try

                    DataRow = DataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate AndAlso DR(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate)

                Catch ex As Exception

                End Try

                For Each EmployeeCode In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Select(Function(Entity) Entity.EmployeeCode).ToList

                    If Hashtable.ContainsKey(EmployeeCode) AndAlso
                                OldHashtable.ContainsKey(EmployeeCode) AndAlso
                                (Hashtable(EmployeeCode) <> OldHashtable(EmployeeCode)) Then

                        BillRate = Hashtable(EmployeeCode)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLEMP SET BILL_RATE = {0} WHERE ETF_OFFDTL_ID = {1} AND EMP_CODE = '{2}'", BillRate, _EmployeeTimeForecastOfficeDetailID, EmployeeCode))

                        '_DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailEmployee)

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeCode) Then

                            DataRow(EmployeeCode) = FormatCurrency(BillRate)

                        End If

                    End If

                Next

                For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee.LoadByEmployeeTimeForecastOfficeDetailID(_DbContext, _EmployeeTimeForecastOfficeDetailID).Select(Function(Entity) Entity.ID).ToList

                    If Hashtable.ContainsKey(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                        OldHashtable.ContainsKey(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) AndAlso
                        (Hashtable(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) <> OldHashtable(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)) Then

                        BillRate = Hashtable(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString)

                        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ETF_OFFDTLAE SET BILL_RATE = {0} WHERE ETF_OFFDTLAE_ID = {1}", BillRate, EmployeeTimeForecastOfficeDetailAlternateEmployeeID))

                        If DataRow IsNot Nothing AndAlso DataTable.Columns.Contains(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) Then

                            DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = FormatCurrency(BillRate)

                        End If

                        ' _DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailAlternateEmployee)

                    End If

                Next

                'Try

                '    _DbContext.SaveChanges()

                'Catch ex As Exception

                'End Try

            End If

        End If

        Try

            'Session("ETF_Datasource") = Nothing

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.DataBound

        'objects
        'Dim ExpandOption As Integer = 0

        'Try

        '    If Not Me.IsPostBack AndAlso Not Me.IsCallback AndAlso Session("ETF_ExpandedIndexes") Is Nothing Then

        '        ExpandOption = LoadExpandOptions()

        '        If ExpandOption = 5 Then

        '            For Each TreeListDataItem In DirectCast(sender, Telerik.Web.UI.RadTreeList).Items.ToList

        '                CheckToCollapseNode(TreeListDataItem, 0)

        '            Next

        '        ElseIf ExpandOption = 6 Then

        '            For Each TreeListDataItem In DirectCast(sender, Telerik.Web.UI.RadTreeList).Items.ToList

        '                CheckToCollapseNode(TreeListDataItem, 1)

        '            Next

        '        End If

        '    End If

        'Catch ex As Exception

        'End Try

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListNeedDataSourceEventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.NeedDataSource

        If Session("ETF_Datasource") Is Nothing Then

            Session("ETF_Datasource") = BuildEmployeeTimeForecastOfficeDetailsDataTable(_DbContext, _DataContext)

        End If

        RadTreeListEmployeeTimeForecastOfficeDetails.DataSource = Session("ETF_Datasource")

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListItemDataBoundEventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.ItemDataBound

        'objects
        ' Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TreeListDataItem As Telerik.Web.UI.TreeListDataItem = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.TreeListDataItem Then

            TreeListDataItem = e.Item

            If TreeListDataItem.DataItem IsNot Nothing AndAlso TypeOf TreeListDataItem.DataItem Is System.Data.DataRowView Then

                LoadEmployeeTimeForecastOfficeDetail(_DbContext, False)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    If _SettingsList Is Nothing Then

                        _SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(_DataContext)

                    End If

                    If _EmployeeStandardHoursDetailList Is Nothing Then

                        _EmployeeStandardHoursDetailList = AdvantageFramework.Database.Procedures.EmployeeStandardHoursDetail.LoadByUserCode(_DbContext, _DbContext.UserCode).ToList

                    End If

                    For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                        TableCell.Attributes.Add("style", "color:black !important;")

                    Next

                    If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) = "" Then

                        FormatHeaderRow(TreeListDataItem)

                    ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()).ToString.StartsWith(_EmployeeTimeForecastOfficeDetail.OfficeCode) OrElse
                            DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()).ToString.StartsWith(_EmployeeTimeForecastOfficeDetail.OfficeCode) Then

                        FormatOfficeDetailRow(TreeListDataItem)

                    ElseIf DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) <> _EmployeeTimeForecastOfficeDetail.OfficeCode Then

                        FormatNonOfficeDetailRow(TreeListDataItem)

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub RadTreeListEmployeeTimeForecastOfficeDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.TreeListCommandEventArgs) Handles RadTreeListEmployeeTimeForecastOfficeDetails.ItemCommand

        If e.CommandName = Telerik.Web.UI.RadTreeList.ExpandCollapseCommandName Then

            Session("ETF_ExpandedIndexes") = DirectCast(sender, Telerik.Web.UI.RadTreeList).ExpandedIndexes.ToList

        End If

    End Sub
    Private Sub RadToolBarEmployeeTimeForecastOffice_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastOffice.ButtonClick

        'objects
        Dim ApprovedEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
        Dim RevisionCreated As Boolean = False
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
        'Dim RadTreeListEmployeeTimeForecastOfficeDetails As Telerik.Web.UI.RadTreeList = Nothing



        LoadEmployeeTimeForecastOfficeDetail(_DbContext, True)

        'Try

        '    RadTreeListEmployeeTimeForecastOfficeDetails = PlaceHolderEmployeeTimeForecastOffice.FindControl("RadTreeListEmployeeTimeForecastOfficeDetails")

        'Catch ex As Exception
        '    RadTreeListEmployeeTimeForecastOfficeDetails = Nothing
        'End Try

        If RadTreeListEmployeeTimeForecastOfficeDetails IsNot Nothing Then

            Try

                Session("ETF_ExpandedIndexes") = RadTreeListEmployeeTimeForecastOfficeDetails.ExpandedIndexes.ToList

            Catch ex As Exception

            End Try

        End If

        Select Case e.Item.Value

            Case ToolBarCommand.Save.ToString

                SaveEmployeeTimeForecastOfficeDetails(_DbContext)

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID))

            Case ToolBarCommand.JobComponents.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    Me.OpenWindow("Job Components", [String].Format("EmployeeTimeForecast_AddJobComponents.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 650, 1000, False, True, "RefreshPage")

                End If

            Case ToolBarCommand.Employees.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    Me.OpenWindow("Employees", [String].Format("EmployeeTimeForecast_AddEmployees.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 600, 600, False, True, "RefreshPage")

                End If

            Case ToolBarCommand.CreateRevision.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    Me.OpenWindow("Create Revision", [String].Format("EmployeeTimeForecast_CreateRevision.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 250, 500, False, True, "RefreshPage")

                End If

            Case ToolBarCommand.IndirectCategories.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    Me.OpenWindow("Indirect Categories", [String].Format("EmployeeTimeForecast_AddIndirectCategories.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 600, 600, False, True, "RefreshPage")

                End If

            Case ToolBarCommand.Approve.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            ApprovedEmployeeTimeForecastOfficeDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(_DbContext, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode,
                                                                                                                                                     _EmployeeTimeForecastOfficeDetail.OfficeCode, _EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode,
                                                                                                                                                     _SecurityDbContext, _Session).Where(Function(OfficeDetail) OfficeDetail.IsApproved).Single

                        Catch ex As Exception
                            ApprovedEmployeeTimeForecastOfficeDetail = Nothing
                        Finally

                            If ApprovedEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                                Me.OpenWindow("", [String].Format("EmployeeTimeForecast_Approve.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 200, 500, False, True, "RefreshPage")

                            Else

                                _EmployeeTimeForecastOfficeDetail.IsApproved = True
                                _EmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Session("empcode").ToString
                                _EmployeeTimeForecastOfficeDetail.ApprovedDate = Now

                                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(_DbContext, _EmployeeTimeForecastOfficeDetail)

                                Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID))

                            End If

                        End Try

                    End If

                End If

            Case ToolBarCommand.Unapprove.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        _EmployeeTimeForecastOfficeDetail.IsApproved = False
                        _EmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Nothing
                        _EmployeeTimeForecastOfficeDetail.ApprovedDate = Nothing

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(_DbContext, _EmployeeTimeForecastOfficeDetail)

                    End If

                End If

                Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID))

            Case ToolBarCommand.DeleteRevision.ToString

                If AdvantageFramework.EmployeeTimeForecast.DeleteRevisionForEmployeeTimeForecastOfficeDetail(_DbContext, _EmployeeTimeForecastOfficeDetail) Then

                    Try

                        EmployeeTimeForecastOfficeDetailID = (From Item In DropDownListEmployeeTimeForecastOfficeDetailRevision.Items.OfType(Of Telerik.Web.UI.RadComboBoxItem)()
                                                              Where CInt(Item.Value) <> _EmployeeTimeForecastOfficeDetailID
                                                              Select [ID] = CInt(Item.Value)
                                                              Order By ID Descending).First

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailID = 0
                    Finally

                        If EmployeeTimeForecastOfficeDetailID <> 0 Then

                            Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", EmployeeTimeForecastOfficeDetailID))

                        Else

                            Me.CloseThisWindowAndRefreshCaller("EmployeeTimeForecast_Main.aspx")

                        End If

                    End Try

                Else

                    Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetail.ID))

                End If

            Case ToolBarCommand.AlternateEmployees.ToString

                If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                    Me.OpenWindow("Alternate Employees", [String].Format("EmployeeTimeForecast_AddAlternateEmployees.aspx?EmployeeTimeForecastOfficeDetailID={0}", _EmployeeTimeForecastOfficeDetailID), 600, 600, False, True, "RefreshPage")

                End If

            Case ToolBarCommand.ExpandAll.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.ExpandAllItems()

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 1))

            Case ToolBarCommand.ExpandOffice.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(1)

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 2))

            Case ToolBarCommand.ExpandClient.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(2)

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 3))

            Case ToolBarCommand.CollapseAll.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.CollapseAllItems()

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 4))

            Case ToolBarCommand.CollapseOffice.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.CollapseAllItems()

                RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(0)

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 5))

            Case ToolBarCommand.CollapseClient.ToString

                RadTreeListEmployeeTimeForecastOfficeDetails.CollapseAllItems()

                RadTreeListEmployeeTimeForecastOfficeDetails.ExpandToLevel(1)

                'Try

                '    Session("ETF_ExpandedIndexes") = Nothing

                'Catch ex As Exception

                'End Try

                'Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}&ExpandOption={1}", _EmployeeTimeForecastOfficeDetailID, 6))

            Case ToolBarCommand.Bookmark.ToString()

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_EmployeeTimeForecast
                    .UserCode = Session("UserCode")
                    .Name = "ETF: " & Me.TextBoxDescription.Text
                    .PageURL = "EmployeeTimeForecast_Edit.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If



        End Select

    End Sub
    Private Sub DropDownListEmployeeTimeForecastOfficeDetailRevision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListEmployeeTimeForecastOfficeDetailRevision.SelectedIndexChanged

        If DropDownListEmployeeTimeForecastOfficeDetailRevision.SelectedValue IsNot Nothing AndAlso DropDownListEmployeeTimeForecastOfficeDetailRevision.SelectedValue <> "" Then

            Response.Redirect([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", DropDownListEmployeeTimeForecastOfficeDetailRevision.SelectedValue))

        End If

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        'Dim RadTreeListEmployeeTimeForecastOfficeDetails As Telerik.Web.UI.RadTreeList = Nothing
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim ExportDataTable As DataTable = Nothing

        'Try

        '    RadTreeListEmployeeTimeForecastOfficeDetails = PlaceHolderEmployeeTimeForecastOffice.FindControl("RadTreeListEmployeeTimeForecastOfficeDetails")

        'Catch ex As Exception
        '    RadTreeListEmployeeTimeForecastOfficeDetails = Nothing
        'End Try

        If RadTreeListEmployeeTimeForecastOfficeDetails IsNot Nothing AndAlso (RadTreeListEmployeeTimeForecastOfficeDetails.EditItems Is Nothing OrElse (RadTreeListEmployeeTimeForecastOfficeDetails.EditItems IsNot Nothing AndAlso RadTreeListEmployeeTimeForecastOfficeDetails.EditItems.Count = 0)) Then

            LoadEmployeeTimeForecastOfficeDetail(_DbContext, True)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                DataTable = BuildEmployeeTimeForecastOfficeDetailsDataTable(_DbContext, _DataContext)

                ExportDataTable = DataTable.Copy

                For Each EmployeeTimeForecastOfficeDetailEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                    For Each DataRow In ExportDataTable.Rows.OfType(Of System.Data.DataRow)()

                        If DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).ToString() <> "" Then

                            If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString()) OrElse
                                    DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString()) Then 'OrElse _
                                'DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalCost.ToString()) OrElse _
                                'DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.CostRate.ToString()) Then

                                DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatCurrency(DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode))

                            Else

                                DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) = FormatNumber(DataRow(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode), 2)

                            End If

                        End If

                    Next

                Next

                For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                    For Each DataRow In ExportDataTable.Rows.OfType(Of System.Data.DataRow)()

                        If DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()).ToString() <> "" Then

                            If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString()) OrElse
                                    DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString()) Then 'OrElse _
                                'DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalCost.ToString()) OrElse _
                                'DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString()) = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.CostRate.ToString()) Then

                                DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()) = FormatCurrency(DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()))

                            Else

                                DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()) = FormatNumber(DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString()), 2)

                            End If

                        End If

                    Next

                Next

                For Each TreeListColumn In RadTreeListEmployeeTimeForecastOfficeDetails.Columns.OfType(Of Telerik.Web.UI.TreeListColumn)()

                    If TypeOf TreeListColumn Is Telerik.Web.UI.TreeListBoundColumn Then

                        If DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).Visible = False Then

                            ExportDataTable.Columns.Remove(DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField)

                        Else

                            If DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString() Then

                                For Each DataRow In ExportDataTable.Rows.OfType(Of System.Data.DataRow)()

                                    If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()).ToString() <> "" Then

                                        DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()) = FormatNumber(DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString()), 2)

                                    End If

                                Next

                            End If

                            ExportDataTable.Columns(DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField).ColumnName = DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).HeaderText

                        End If

                    ElseIf TypeOf TreeListColumn Is Telerik.Web.UI.TreeListBoundColumn Then

                        If DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).Visible = False Then

                            ExportDataTable.Columns.Remove(DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField)

                        Else

                            If DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString() Then

                                For Each DataRow In ExportDataTable.Rows.OfType(Of System.Data.DataRow)()

                                    If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()).ToString() <> "" Then

                                        DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()) = FormatCurrency(DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString()))

                                    End If

                                Next

                            End If

                            ExportDataTable.Columns(DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).DataField).ColumnName = DirectCast(TreeListColumn, Telerik.Web.UI.TreeListBoundColumn).HeaderText

                        End If

                    End If

                Next

                'DataView = New DataView(ExportDataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel(_EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description & ".xls", GridView)<--- This doesn' work
                Me.DeliverGrid(ExportDataTable, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description) '<--- This does, please don't change unless you test!!!!

            End If

        End If

    End Sub

#End Region

#End Region

End Class
