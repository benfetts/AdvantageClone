Public Class EmployeeTimeForecast_AddAlternateEmployees
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

#End Region

#Region " Properties "



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

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailAlternateEmployees.EmployeeTitle")
                                                         Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee.Properties.Description)

        If PropertyDescriptor IsNot Nothing Then

            TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_AddAlternateEmployees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    DropDownListEmployeeTitle.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext).ToList
                    DropDownListEmployeeTitle.DataBind()
                    DropDownListEmployeeTitle.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    DropDownListOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, _Session).OrderBy(Function(Office) Office.Name).ToList
                    DropDownListOffice.DataBind()
                    DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    RadListBoxCurrentAlternateEmployees.DataSource = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList.Select(Function(EmployeeTimeForecastOfficeDetailAlternateEmployee) New With {.[ID] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID,
                                                                                                                                                                                                                                              .[Description] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString})
                    RadListBoxCurrentAlternateEmployees.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecastAlternateEmployee_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastAlternateEmployee.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadListBoxCurrentAlternateEmployees_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentAlternateEmployees.Deleted

        'objects
        Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        EmployeeTimeForecastOfficeDetailAlternateEmployee = (From Entity In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees
                                                                             Where Entity.ID = RadListBoxItem.Value
                                                                             Select Entity).Single

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                    Finally

                        If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                            AdvantageFramework.EmployeeTimeForecast.DeleteAlternateEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee)

                        End If

                    End Try

                Next

                _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

            End If

        End Using

    End Sub
    Private Sub RadButtonAddNewAlternateEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAddNewAlternateEmployee.Click

        'objects
        Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing
        Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
        Dim AddAlternateEmployee As Boolean = True

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                If DropDownListEmployeeTitle.SelectedValue Is Nothing OrElse DropDownListEmployeeTitle.SelectedValue = "" Then

                    Me.ShowMessage("Please select an employee title.")
                    AddAlternateEmployee = False

                Else

                    EmployeeTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, DropDownListEmployeeTitle.SelectedValue)

                    If EmployeeTitle Is Nothing Then

                        Me.ShowMessage("Please select a valid employee title.")
                        AddAlternateEmployee = False

                    End If

                End If

                If AddAlternateEmployee Then

                    If TextBoxDescription.Text.Trim = "" Then

                        Me.ShowMessage("Please enter a description.")
                        AddAlternateEmployee = False

                    Else

                        If _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Any(Function(EmployeeTimeForecastOfficeDetailAlternateEmployee) EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = TextBoxDescription.Text) Then

                            Me.ShowMessage("Please enter a unique description.")
                            AddAlternateEmployee = False

                        End If

                    End If

                End If

                If AddAlternateEmployee Then

                    If DropDownListOffice.SelectedValue Is Nothing AndAlso DropDownListOffice.SelectedValue = "" Then

                        Me.ShowMessage("Please select an office.")
                        AddAlternateEmployee = False

                    Else

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, DropDownListOffice.SelectedValue)

                        If Office Is Nothing Then

                            Me.ShowMessage("Please select a valid office.")
                            AddAlternateEmployee = False

                        End If

                    End If

                End If

                If AddAlternateEmployee Then

                    If AdvantageFramework.EmployeeTimeForecast.InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTitle, TextBoxDescription.Text, Office, True, RadNumericTextBoxBillRate.Value, True, RadNumericTextBoxCostRate.Value) Then

                        _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                        _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

                        _EmployeeTimeForecastOfficeDetail = Nothing

                        LoadEmployeeTimeForecastOfficeDetail(DbContext)

                        RadListBoxCurrentAlternateEmployees.DataSource = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList.Select(Function(EmployeeTimeForecastOfficeDetailAlternateEmployee) New With {.[ID] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID,
                                                                                                                                                                                                                                                  .[Description] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString})
                        RadListBoxCurrentAlternateEmployees.DataBind()

                    End If

                End If

            End If

        End Using

    End Sub

#End Region

#End Region

End Class