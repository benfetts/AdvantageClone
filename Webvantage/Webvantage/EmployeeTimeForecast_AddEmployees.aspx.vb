Public Class EmployeeTimeForecast_AddEmployees
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

#End Region

#Region " Methods "

    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0

        If _EmployeeTimeForecastOfficeDetail Is Nothing Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetailID = 0
                End Try

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailEmployees.Employee").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailEmployees.Employee.DepartmentTeam")
                                                         Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub
    Private Sub LoadAvailableEmployees()

        'objects
        Dim AvailableEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

        If DropDownListOffice.SelectedValue IsNot Nothing AndAlso DropDownListOffice.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    AvailableEmployeesList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetailByOfficeCode(DbContext, _EmployeeTimeForecastOfficeDetail, DropDownListOffice.SelectedValue)

                End If

            End Using

        End If

        If AvailableEmployeesList IsNot Nothing Then

            RadListBoxAvailableEmployees.DataSource = From Employee In AvailableEmployeesList
                                                      Select New With {.Code = Employee.Code,
                                                                       .Name = Employee.ToString,
                                                                       .DepartmentTeamCode = Employee.DepartmentTeamCode,
                                                                       .DepartmentTeamName = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)}
            RadListBoxAvailableEmployees.DataBind()

        Else

            RadListBoxAvailableEmployees.Items.Clear()
            RadListBoxAvailableEmployees.DataSource = Nothing
            RadListBoxAvailableEmployees.DataBind()

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_AddEmployees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                OfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session("empcode").ToString()).Include("Office").Select(Function(EmployeeOffice) EmployeeOffice.Office).ToList

                If OfficeList.Count > 0 Then

                    DropDownListOffice.DataSource = OfficeList.OrderBy(Function(Office) Office.Name).ToList

                Else

                    DropDownListOffice.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext).OrderBy(Function(Office) Office.Name).ToList

                End If

                DropDownListOffice.DataBind()
                DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    DropDownListOffice.SelectedValue = _EmployeeTimeForecastOfficeDetail.OfficeCode

                    RadListBoxCurrentEmployees.DataSource = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList.
                                                                                                                                        Select(Function(CurrentEmployee) New With {.Code = CurrentEmployee.Code,
                                                                                                                                                                                   .Name = CurrentEmployee.ToString,
                                                                                                                                                                                   .DepartmentTeamCode = CurrentEmployee.DepartmentTeamCode,
                                                                                                                                                                                   .DepartmentTeamName = If(CurrentEmployee.DepartmentTeam IsNot Nothing, CurrentEmployee.DepartmentTeam.Description, String.Empty)})
                Else

                    RadListBoxCurrentEmployees.DataSource = Nothing

                End If

                RadListBoxCurrentEmployees.DataBind()

                LoadAvailableEmployees()

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListOffice.SelectedIndexChanged

        LoadAvailableEmployees()

    End Sub
    Private Sub RadToolBarEmployeeTimeForecastEmployee_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastEmployee.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadListBoxCurrentEmployees_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentEmployees.Deleted

        'objects
        Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) = Nothing
        Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                CurrentEmployeesList = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.ToList

                For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        EmployeeTimeForecastOfficeDetailEmployee = (From Entity In CurrentEmployeesList
                                                                    Where Entity.EmployeeCode = RadListBoxItem.Value
                                                                    Select Entity).Single

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailEmployee = Nothing
                    Finally

                        If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

                            AdvantageFramework.EmployeeTimeForecast.DeleteEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee)

                        End If

                    End Try

                Next

                _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

            End If

        End Using

        LoadAvailableEmployees()

    End Sub
    Private Sub RadListBoxCurrentEmployees_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentEmployees.Inserted

        'objects
        Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim UseEmployeeTitleBillingRate As Boolean = False

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    UseEmployeeTitleBillingRate = AdvantageFramework.EmployeeTimeForecast.LoadUseEmployeeTitleBillingRateSetting(DataContext)

                End Using

                CurrentEmployeesList = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList

                EmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        Employee = (From Entity In CurrentEmployeesList
                                    Where Entity.Code = RadListBoxItem.Value
                                    Select Entity).Single

                    Catch ex As Exception
                        Employee = Nothing
                    Finally

                        If Employee Is Nothing Then

                            Try

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, RadListBoxItem.Value)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                        End If

                        AdvantageFramework.EmployeeTimeForecast.InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, Session("ConnString").ToString(), _EmployeeTimeForecastOfficeDetail, Employee, True, 0, True, 0, UseEmployeeTitleBillingRate)

                    End Try

                Next

                _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

            End If

        End Using

    End Sub

#End Region

#End Region

End Class
