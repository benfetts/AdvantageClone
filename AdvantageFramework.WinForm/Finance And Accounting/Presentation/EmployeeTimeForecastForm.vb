Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Public Sub RefreshETFs()

            LoadEmployeeTimeForecasts()

        End Sub
        Private Sub LoadEmployeeTimeForecasts()

            'objects
            Dim Month As Short = 0
            Dim Year As String = ""
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If String.IsNullOrWhiteSpace(ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue) = False Then

                        PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue)

                    End If

                    If PostPeriod IsNot Nothing Then

                        Year = PostPeriod.Year

                        Try

                            Month = PostPeriod.Month

                        Catch ex As Exception
                            Month = 0
                        End Try

                    Else

                        Year = ""
                        Month = 0

                    End If

                    DataGridViewForm_EmployeeTimeForecasts.DataSource = (From EmployeeTimeForecastOfficeDetail In AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, Month, Year, ComboBoxItemTopSection_Office.ComboBoxEx.SelectedValue, ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedValue, SecurityDbContext, Session)
                                                                         Group By Key = New With {EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast, EmployeeTimeForecastOfficeDetail.Office, EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode} Into Group).ToList.Select(Function(GroupEntity) _
                                                                         New With {.[EmployeeTimeForecastID] = GroupEntity.Key.EmployeeTimeForecast.ID,
                                                                                   .[Description] = GroupEntity.Key.EmployeeTimeForecast.Description,
                                                                                   .[OfficeCode] = GroupEntity.Key.Office.Code,
                                                                                   .[OfficeName] = GroupEntity.Key.Office.Name,
                                                                                   .[RevisionNumber] = AdvantageFramework.StringUtilities.PadWithCharacter(GroupEntity.Group.Max(Function(OfficeDetail) OfficeDetail.RevisionNumber), 3, "0", True),
                                                                                   .[AssignedToEmployeeCode] = GroupEntity.Key.AssignedToEmployeeCode,
                                                                                   .[AssignedToEmployeeName] = GroupEntity.Group.Max(Function(OfficeDetail) OfficeDetail.AssignedToEmployee.ToString()),
                                                                                   .[IsApproved] = GroupEntity.Group.SingleOrDefault(Function(OfficeDetail) OfficeDetail.RevisionNumber = GroupEntity.Group.Max(Function(ETFOfficeDetail) ETFOfficeDetail.RevisionNumber)).IsApproved}).ToList

                    If DataGridViewForm_EmployeeTimeForecasts.Columns("EmployeeTimeForecastID") IsNot Nothing Then

                        If DataGridViewForm_EmployeeTimeForecasts.Columns("EmployeeTimeForecastID").Visible Then

                            DataGridViewForm_EmployeeTimeForecasts.Columns("EmployeeTimeForecastID").Visible = False

                        End If

                    End If

                    If DataGridViewForm_EmployeeTimeForecasts.Columns("OfficeCode") IsNot Nothing Then

                        If DataGridViewForm_EmployeeTimeForecasts.Columns("OfficeCode").Visible Then

                            DataGridViewForm_EmployeeTimeForecasts.Columns("OfficeCode").Visible = False

                        End If

                    End If

                    If DataGridViewForm_EmployeeTimeForecasts.Columns("AssignedToEmployeeCode") IsNot Nothing Then

                        If DataGridViewForm_EmployeeTimeForecasts.Columns("AssignedToEmployeeCode").Visible Then

                            DataGridViewForm_EmployeeTimeForecasts.Columns("AssignedToEmployeeCode").Visible = False

                        End If

                    End If

                    DataGridViewForm_EmployeeTimeForecasts.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub SaveETFUserSettings()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedPostPeriod.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                Else

                    UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                    UserSetting.DbContext = SecurityDbContext
                    UserSetting.UserID = Me.Session.User.ID
                    UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.ETFSelectedPostPeriod.ToString

                    UserSetting.StringValue = ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedEmployee.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                Else

                    UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                    UserSetting.DbContext = SecurityDbContext
                    UserSetting.UserID = Me.Session.User.ID
                    UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.ETFSelectedEmployee.ToString

                    UserSetting.StringValue = ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedOffice.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ComboBoxItemTopSection_Office.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                Else

                    UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                    UserSetting.DbContext = SecurityDbContext
                    UserSetting.UserID = Me.Session.User.ID
                    UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.ETFSelectedOffice.ToString

                    UserSetting.StringValue = ComboBoxItemTopSection_Office.ComboBoxEx.SelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeTimeForecastForm As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm = Nothing

            EmployeeTimeForecastForm = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm()

            EmployeeTimeForecastForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PostPeriodBindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim OfficeBindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim EmployeeBindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LoadDefaultSettings As Boolean = True
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_View.Image = My.Resources.ViewImage
            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_ComparisonDashboard.Image = My.Resources.ReportImage
            ButtonItemActions_Settings.Image = My.Resources.PreferencesImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            ButtonItemActions_ComparisonDashboard.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard)
            ButtonItemActions_Settings.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastSettings)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    ComboBoxItemTopSection_PostPeriod.ComboBoxEx.DisplayMember = "Description"
                    ComboBoxItemTopSection_PostPeriod.ComboBoxEx.ValueMember = "Code"

                    PostPeriodBindingSource = New System.Windows.Forms.BindingSource

                    PostPeriodBindingSource.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                                                                                                                                                  .Description = Entity.Code & " - " & Entity.Description}).ToList

                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(PostPeriodBindingSource, ComboBoxItemTopSection_PostPeriod.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemTopSection_PostPeriod.ComboBoxEx.ValueMember,
                                                                                                      "[" & AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                                                                                                      "", True, True)

                    ComboBoxItemTopSection_PostPeriod.ComboBoxEx.DataSource = PostPeriodBindingSource

                    '-------------------------------------------------------------

                    ComboBoxItemTopSection_Office.ComboBoxEx.DisplayMember = "Name"
                    ComboBoxItemTopSection_Office.ComboBoxEx.ValueMember = "Code"

                    OfficeBindingSource = New System.Windows.Forms.BindingSource

                    OfficeBindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session).OrderBy(Function(Entity) Entity.Name).ToList
                                                      Select [Code] = Entity.Code,
                                                             [Name] = Entity.ToString).ToList
                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(OfficeBindingSource, ComboBoxItemTopSection_Office.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemTopSection_Office.ComboBoxEx.ValueMember,
                                                                                                      "[" & AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                                                                                                      "", True, True)

                    ComboBoxItemTopSection_Office.ComboBoxEx.DataSource = OfficeBindingSource

                    '-------------------------------------------------------------

                    ComboBoxItemBottomSection_Employee.ComboBoxEx.DisplayMember = "Name"
                    ComboBoxItemBottomSection_Employee.ComboBoxEx.ValueMember = "Code"

                    EmployeeBindingSource = New System.Windows.Forms.BindingSource

                    EmployeeBindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, Me.Session.UserCode, Me.Session.User.EmployeeCode).ToList
                                                        Select [Code] = Entity.Code,
                                                               [Name] = Entity.ToString).ToList
                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(EmployeeBindingSource, ComboBoxItemBottomSection_Employee.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemBottomSection_Employee.ComboBoxEx.ValueMember,
                                                                                                      "[" & AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                                                                                                      "", True, True)

                    ComboBoxItemBottomSection_Employee.ComboBoxEx.DataSource = EmployeeBindingSource

                    '-------------------------------------------------------------

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedPostPeriod.ToString)

                    If UserSetting IsNot Nothing Then

                        LoadDefaultSettings = False

                        ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue = UserSetting.StringValue

                    End If

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedEmployee.ToString)

                    If UserSetting IsNot Nothing Then

                        LoadDefaultSettings = False

                        ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedValue = UserSetting.StringValue

                    End If

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.ETFSelectedOffice.ToString)

                    If UserSetting IsNot Nothing Then

                        LoadDefaultSettings = False

                        ComboBoxItemTopSection_Office.ComboBoxEx.SelectedValue = UserSetting.StringValue

                    End If

                    If LoadDefaultSettings Then

                        If PostPeriod IsNot Nothing Then

                            ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue = PostPeriod.Code

                        Else

                            ComboBoxItemTopSection_PostPeriod.ComboBoxEx.SelectedValue = String.Empty

                        End If

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.OfficeCode IsNot Nothing AndAlso Employee.OfficeCode <> "" Then

                                ComboBoxItemTopSection_Office.ComboBoxEx.SelectedValue = Employee.OfficeCode

                            End If

                            ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedValue = Employee.Code

                        End If

                    End If

                End Using

            End Using

            LoadEmployeeTimeForecasts()

            ButtonItemActions_View.Enabled = DataGridViewForm_EmployeeTimeForecasts.HasOnlyOneSelectedRow

            'If Debugger.IsAttached Then

            '    ComboBoxItemTopSection_Month.ComboBoxEx.SelectedIndex = 0
            '    ComboBoxItemBottomSection_Year.ComboBoxEx.SelectedIndex = 0

            '    ComboBoxItemTopSection_Office.ComboBoxEx.SelectedIndex = 0
            '    ComboBoxItemBottomSection_Employee.ComboBoxEx.SelectedIndex = 0

            '    LoadEmployeeTimeForecasts()

            'End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_EmployeeTimeForecasts_RowDoubleClickEvent() Handles DataGridViewForm_EmployeeTimeForecasts.RowDoubleClickEvent

            ButtonItemActions_View.RaiseClick()

        End Sub
        Private Sub DataGridViewForm_EmployeeTimeForecasts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_EmployeeTimeForecasts.SelectionChangedEvent

            ButtonItemActions_View.Enabled = DataGridViewForm_EmployeeTimeForecasts.HasOnlyOneSelectedRow

        End Sub
        Private Sub ButtonItemActions_Settings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Settings.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastSettings)

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
            Dim EmployeeTimeForecastID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailOfficeCode As String = ""
            Dim EmployeeTimeForecastOfficeDetailRevisionNumber As Integer = 0
            Dim AssignedToEmployeeCode As String = ""
            Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing

            If DataGridViewForm_EmployeeTimeForecasts.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        EmployeeTimeForecastID = DataGridViewForm_EmployeeTimeForecasts.GetFirstSelectedRowBookmarkValue(0)
                        EmployeeTimeForecastOfficeDetailOfficeCode = DataGridViewForm_EmployeeTimeForecasts.GetFirstSelectedRowBookmarkValue(2)
                        EmployeeTimeForecastOfficeDetailRevisionNumber = DataGridViewForm_EmployeeTimeForecasts.GetFirstSelectedRowBookmarkValue(4)
                        AssignedToEmployeeCode = DataGridViewForm_EmployeeTimeForecasts.GetFirstSelectedRowBookmarkValue(5)

                        Try

                            EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastID)

                            If EmployeeTimeForecast IsNot Nothing Then

                                EmployeeTimeForecastOfficeDetailID = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, EmployeeTimeForecast.PostPeriodCode, EmployeeTimeForecastOfficeDetailOfficeCode, AssignedToEmployeeCode, SecurityDbContext, Session).
                                                                                                                                                   Where(Function(OfficeDetail) OfficeDetail.RevisionNumber = EmployeeTimeForecastOfficeDetailRevisionNumber).SingleOrDefault.ID

                            End If

                        Catch ex As Exception
                            EmployeeTimeForecastOfficeDetailID = 0
                        End Try

                    End Using

                End Using

                If EmployeeTimeForecastOfficeDetailID <> 0 Then

                    AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEditForm.ShowForm(EmployeeTimeForecastOfficeDetailID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ComparisonDashboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_ComparisonDashboard.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard)

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
            Dim EmployeeTimeForecastID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetailOfficeCode As String = ""
            Dim AssignedToEmployeeCode As String = ""
            Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastNewDialog.ShowFormDialog(EmployeeTimeForecastID, EmployeeTimeForecastOfficeDetailOfficeCode, AssignedToEmployeeCode) = System.Windows.Forms.DialogResult.OK Then

                LoadEmployeeTimeForecasts()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            EmployeeTimeForecast = AdvantageFramework.Database.Procedures.EmployeeTimeForecast.LoadByEmployeeTimeForecastID(DbContext, EmployeeTimeForecastID)

                            If EmployeeTimeForecast IsNot Nothing Then

                                EmployeeTimeForecastOfficeDetailID = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetails(DbContext, EmployeeTimeForecast.PostPeriodCode, EmployeeTimeForecastOfficeDetailOfficeCode, AssignedToEmployeeCode, SecurityDbContext, Session).
                                                                                                                                                   Where(Function(OfficeDetail) OfficeDetail.RevisionNumber = 0).SingleOrDefault.ID

                            End If

                        Catch ex As Exception
                            EmployeeTimeForecastOfficeDetailID = 0
                        End Try

                    End Using

                End Using

                If EmployeeTimeForecastOfficeDetailID <> 0 Then

                    AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEditForm.ShowForm(EmployeeTimeForecastOfficeDetailID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            LoadEmployeeTimeForecasts()

        End Sub
        Private Sub ComboBoxItemBottomSection_Employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemBottomSection_Employee.SelectedIndexChanged

            If Me.FormShown Then

                LoadEmployeeTimeForecasts()

                SaveETFUserSettings()

            End If

        End Sub
        Private Sub ComboBoxItemBottomSection_Year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If Me.FormShown Then

                LoadEmployeeTimeForecasts()

                SaveETFUserSettings()

            End If

        End Sub
        Private Sub ComboBoxItemTopSection_Month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemTopSection_PostPeriod.SelectedIndexChanged

            If Me.FormShown Then

                LoadEmployeeTimeForecasts()

                SaveETFUserSettings()

            End If

        End Sub
        Private Sub ComboBoxItemTopSection_Office_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemTopSection_Office.SelectedIndexChanged

            If Me.FormShown Then

                LoadEmployeeTimeForecasts()

                SaveETFUserSettings()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
