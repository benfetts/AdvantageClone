Public Class EmployeeTimeForecast_New
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)

        If PropertyDescriptor IsNot Nothing Then

            TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)
            TextBoxDescription.CssClass = "RequiredInput"

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_New_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadControlSettings(DbContext)

                    DropDownListOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session).ToList _
                                                                                                                                .Select(Function(Office) New With {.Code = Office.Code,
                                                                                                                                                                   .Name = Office.ToString})
                    DropDownListEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, _Session.UserCode, _Session.User.EmployeeCode).ToList _
                                                                                                                                                .Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                     .Name = Employee.ToString})

                    DropDownListOffice.DataBind()
                    DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).ToList

                    If CurrentPostPeriod Is Nothing Then

                        PostPeriods = PostPeriods.Where(Function(Entity) Entity.GLStatus Is Nothing OrElse ((Entity.Month >= Now.Month AndAlso Entity.Year = Now.Year) OrElse Entity.Year > Now.Year)).ToList

                    Else

                        PostPeriods = PostPeriods.Where(Function(Entity) Entity.GLStatus Is Nothing OrElse ((Entity.Month >= CurrentPostPeriod.Month AndAlso Entity.Year = CurrentPostPeriod.Year) OrElse Entity.Year > CurrentPostPeriod.Year)).ToList

                    End If

                    PostPeriods = PostPeriods.OrderByDescending(Function(Entity) Entity.Code).ToList

                    DropDownListPostPeriod.DataSource = From PostPeriod In PostPeriods
                                                        Select [MonthAndYear] = PostPeriod.ToString(),
                                                               [Code] = PostPeriod.Code
                    DropDownListPostPeriod.DataBind()
                    DropDownListPostPeriod.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    DropDownListEmployee.DataBind()
                    DropDownListEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    DropDownListEmployeeTimeForecasts.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    DropDownListPostPeriod.SelectedValue = Nothing
                    DropDownListOffice.SelectedValue = Nothing
                    DropDownListEmployee.SelectedValue = Nothing
                    DropDownListEmployeeTimeForecasts.SelectedValue = Nothing
                    TextBoxDescription.Text = ""

                    TextBoxDescription.Focus()

                End Using

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecast.ButtonClick

        'objects
        Dim Save As Boolean = True
        Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing
        Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Select Case e.Item.Value

            Case "Save"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If DropDownListOffice.SelectedValue Is Nothing OrElse DropDownListOffice.SelectedValue.ToString() = "" Then

                        Me.ShowMessage("Please select a office.")
                        Save = False

                    End If

                    If Save Then

                        If DropDownListPostPeriod.SelectedValue Is Nothing OrElse DropDownListPostPeriod.SelectedValue.ToString() = "" Then

                            Me.ShowMessage("Please select a post period.")
                            Save = False

                        End If

                    End If

                    If Save Then

                        If DropDownListEmployee.SelectedValue Is Nothing AndAlso DropDownListEmployee.SelectedValue = "" Then

                            Me.ShowMessage("Please select an employee.")
                            Save = False

                        Else

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, DropDownListEmployee.SelectedValue)

                            If Employee Is Nothing Then

                                Me.ShowMessage("The selected employee is not valid.  Please select another employee.")
                                Save = False

                            End If

                        End If

                    End If

                    If Save Then

                        If AdvantageFramework.EmployeeTimeForecast.InsertOfficeDetail(DbContext, TextBoxDescription.Text, DropDownListPostPeriod.SelectedValue, DropDownListOffice.SelectedValue, Employee.Code, EmployeeTimeForecast, EmployeeTimeForecastOfficeDetail) Then

                            If CheckBoxCopyFrom.Checked AndAlso DropDownListEmployeeTimeForecasts.SelectedValue IsNot Nothing AndAlso DropDownListEmployeeTimeForecasts.SelectedValue <> "" Then

                                AdvantageFramework.EmployeeTimeForecast.CopyEmployeeTimeForecastValues(DbContext, Session("ConnString").ToString,
                                                                                                           EmployeeTimeForecastOfficeDetail.ID, DropDownListEmployeeTimeForecasts.SelectedValue,
                                                                                                           CheckBoxUpdateEmployeeRates.Checked, CheckBoxUpdateRevenueAmounts.Checked, CheckBoxExcludeHoursEnteredInCopy.Checked)

                            End If

                            Me.CloseThisWindowAndOpenNewWindow([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", EmployeeTimeForecastOfficeDetail.ID))
                        End If

                    End If

                End Using

            Case "Cancel"

                Me.CloseThisWindow()
        End Select

    End Sub
    Private Sub DropDownListOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListOffice.SelectedIndexChanged

        If DropDownListOffice.SelectedValue IsNot Nothing AndAlso DropDownListOffice.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DropDownListEmployeeTimeForecasts.Items.Clear()

                    DropDownListEmployeeTimeForecasts.DataSource = From EmployeeTimeForecastOfficeDetail In AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByOfficeCode(DbContext, DropDownListOffice.SelectedValue).ToList
                                                                   Select [Description] = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description & " - Revision: " &
                                                                                          AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True),
                                                                          [ID] = EmployeeTimeForecastOfficeDetail.ID
                    DropDownListEmployeeTimeForecasts.DataBind()
                    DropDownListEmployeeTimeForecasts.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    DropDownListEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, _Session.UserCode, _Session.User.EmployeeCode).ToList.Where(Function(Entity) Entity.OfficeCode = DropDownListOffice.SelectedValue).ToList _
                                                                                                                                                .Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                     .Name = Employee.ToString})
                    DropDownListEmployee.DataBind()
                    DropDownListEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                End Using

            End Using

        End If

    End Sub
    Private Sub CheckBoxCopyFrom_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxCopyFrom.CheckedChanged

        DropDownListEmployeeTimeForecasts.Enabled = CheckBoxCopyFrom.Checked
        CheckBoxUpdateEmployeeRates.Enabled = CheckBoxCopyFrom.Checked
        CheckBoxUpdateRevenueAmounts.Enabled = CheckBoxCopyFrom.Checked
        CheckBoxExcludeHoursEnteredInCopy.Enabled = CheckBoxCopyFrom.Checked

    End Sub

#End Region

#End Region

End Class
