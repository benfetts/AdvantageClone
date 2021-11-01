Imports Telerik.Web.UI
Imports Webvantage.wvTimeSheet

Public Class Maintenance_CalendarTime
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub DeauthorizeGoogleServices()

        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

        'Me.ShowWaitForm("Processing...")

        Try

            Service = AdvantageFramework.GoogleServices.Service.Initialize(AdvantageFramework.GoogleServices.Service.ServiceTypes.Calendar, _Session, _Session.User.EmployeeCode, False)

            If Service IsNot Nothing Then

                Service.Deauthorize()

            End If

        Catch ex As Exception

        End Try

        'Me.CloseWaitForm()

    End Sub
    Private Sub AuthorizeGoogleServices()

        Me.OpenWindow("", "Google_Authentication.aspx?ServiceType=Calendar", 300, 500, False, True)

    End Sub
    Private Sub LoadSettings()
        Try
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    RadComboBoxCalendarType.SelectedValue = Employee.CalendarTimeType.ToString
                    TextBoxEmailAddress.Text = Employee.CalendarTimeEmailAddress
                    TextBoxEmailUserName.Text = Employee.CalendarTimeUserName
                    If Employee.CalendarTimePassword <> "" Then
                        TextBoxEmailPassword.Attributes.Add("value", "passwordpwpwpw")
                    End If
                    TextBoxHost.Text = Employee.CalendarTimeHost
                    If Employee.CalendarTimePort Is Nothing Then
                        TextBoxPort.Text = ""
                    Else
                        TextBoxPort.Text = Employee.CalendarTimePort
                    End If

                    If Employee.CalendarTimeSSL = True Then
                        CheckboxSSL.Checked = True
                    Else
                        CheckboxSSL.Checked = False
                    End If
                Else

                    TextBoxEmailAddress.Text = ""
                    TextBoxEmailUserName.Text = ""
                    TextBoxEmailPassword.Text = ""
                    TextBoxHost.Text = ""
                    TextBoxPort.Text = ""

                End If

                If Employee.CalendarTimeType.ToString = 1 Or Employee.CalendarTimeType.ToString = 2 Then
                    If Employee.CalendarTimeType.ToString = 1 Then
                        DivEmailUserName.Visible = False
                        DivEmailPassword.Visible = False
                    End If
                    DivHost.Visible = False
                    DivPort.Visible = False
                    DivSSL.Visible = False
                Else
                    DivHost.Visible = True
                    DivPort.Visible = True
                    DivSSL.Visible = True
                    DivEmailUserName.Visible = True
                    DivEmailPassword.Visible = True
                End If

                If Employee.CalendarTimeType = 2 Or Employee.CalendarTimeType = 3 Then
                    DivGoogleServices.Visible = False
                Else
                    DivGoogleServices.Visible = True
                End If

            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveSettings(ByVal CloseandRefresh As Boolean)
        Try
            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        Employee.CalendarTimeType = CInt(RadComboBoxCalendarType.SelectedValue)
                        Employee.CalendarTimeEmailAddress = TextBoxEmailAddress.Text
                        Employee.CalendarTimeUserName = TextBoxEmailUserName.Text
                        If TextBoxEmailPassword.Text = "passwordpwpwpw" Then

                        Else
                            Employee.CalendarTimePassword = TextBoxEmailPassword.Text
                        End If
                        Employee.CalendarTimeHost = TextBoxHost.Text
                        If Me.TextBoxPort.Text = "" Then
                            Employee.CalendarTimePort = Nothing
                        Else
                            Employee.CalendarTimePort = CInt(TextBoxPort.Text)
                        End If
                        If CheckboxSSL.Checked Then
                            Employee.CalendarTimeSSL = True
                        Else
                            Employee.CalendarTimeSSL = False
                        End If

                        If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) And CloseandRefresh = True Then
                            Me.CloseThisWindowAndRefreshCaller("Timesheet_CopyFrom.aspx")
                        End If

                    End If

                End Using

            End Using
        Catch ex As Exception

        End Try
    End Sub

#Region " Controls "

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        If Me.TextBoxEmailAddress.Text <> "" And AdvantageFramework.StringUtilities.IsValidEmailAddress(Me.TextBoxEmailAddress.Text) = False Then

            Me.ShowMessage("Please enter a valid email address.")
            Me.TextBoxEmailAddress.Focus()
            Exit Sub

        End If

        If Me.TextBoxPort.Text <> "" Then
            If IsNumeric(Me.TextBoxPort.Text) = False Then
                Me.ShowMessage("Please enter a valid port number.")
                Me.TextBoxPort.Focus()
                Exit Sub
            End If
        End If

        SaveSettings(True)

    End Sub

#End Region
#Region " Page "

    Private Sub Maintenance_Timesheet_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Maintenance_Timesheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.PageTitle = "Calendar Time Settings"

            Dim s As String = ""

            _EmployeeCode = _Session.User.EmployeeCode

            RadComboBoxCalendarType.DataTextField = "Description"
            RadComboBoxCalendarType.DataValueField = "Code"
            RadComboBoxCalendarType.DataSource = (From CalendarType In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.CalendarTypes))
                                                  Select CalendarType.Code,
                                                   CalendarType.Description).ToList
            RadComboBoxCalendarType.DataBind()

            RadComboBoxCalendarType.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

            LoadSettings()
            LoadGoogleServicesData()

        End If

    End Sub
    Private Sub LoadGoogleServicesData(ByVal Employee As AdvantageFramework.Database.Views.Employee)

        'objects
        Dim CalendarSyncMain As String = Nothing

        CalendarSyncMain = "Google Services are currently "

        If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

            RadButtonDisableCalendarSync.Visible = True
            RadButtonEnableCalendarSync.Visible = False
            CalendarSyncMain &= "enabled. "

        Else

            RadButtonDisableCalendarSync.Visible = False
            RadButtonEnableCalendarSync.Visible = True
            CalendarSyncMain &= "disabled. "

        End If

        LabelCalendarSync.Text = CalendarSyncMain

    End Sub
    Private Sub LoadGoogleServicesData()

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

        End Using

        If Employee IsNot Nothing Then

            LoadGoogleServicesData(Employee)

        End If

    End Sub
    Private Sub RadButtonDisableCalendarSync_Click(sender As Object, e As EventArgs) Handles RadButtonDisableCalendarSync.Click

        SaveSettings(False)

        DeauthorizeGoogleServices()

        LoadGoogleServicesData()

    End Sub
    Private Sub RadButtonEnableCalendarSync_Click(sender As Object, e As EventArgs) Handles RadButtonEnableCalendarSync.Click

        SaveSettings(False)

        AuthorizeGoogleServices()

        LoadGoogleServicesData()

    End Sub

    Private Sub RadComboBoxCalendarType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCalendarType.SelectedIndexChanged
        If RadComboBoxCalendarType.SelectedValue = 1 Or RadComboBoxCalendarType.SelectedValue = 2 Then
            If RadComboBoxCalendarType.SelectedValue = 1 Then
                DivEmailUserName.Visible = False
                DivEmailPassword.Visible = False
            Else
                DivEmailUserName.Visible = True
                DivEmailPassword.Visible = True
            End If
            DivHost.Visible = False
            DivPort.Visible = False
            DivSSL.Visible = False
        Else
            DivHost.Visible = True
            DivPort.Visible = True
            DivSSL.Visible = True
            DivEmailUserName.Visible = True
            DivEmailPassword.Visible = True
        End If

        If RadComboBoxCalendarType.SelectedValue = 2 Or RadComboBoxCalendarType.SelectedValue = 3 Then
            DivGoogleServices.Visible = False
        Else
            DivGoogleServices.Visible = True
        End If
    End Sub

#End Region



#End Region

End Class