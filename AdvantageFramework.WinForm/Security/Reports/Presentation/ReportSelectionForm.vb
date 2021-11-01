Namespace Security.Reports.Presentation

    Public Class ReportSelectionForm

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

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub SetupFormForSelectedReport()

            'objects
            Dim SecurityReportType As AdvantageFramework.Reporting.SecurityReportTypes = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission

            DataGridViewForm_Selection.DataSource = Nothing

            DataGridViewForm_Selection.ClearColumns()

            If ComboBoxItemReportType_Report.SelectedIndex >= 0 Then

                RadioButtonForm_All.Enabled = True
                RadioButtonForm_Select.Enabled = True
                DataGridViewForm_Selection.Enabled = False
                CheckBoxForm_ShowOnlyAccessibleModules.Enabled = True
                ButtonItemActions_ViewReport.Enabled = True

                SecurityReportType = ComboBoxItemReportType_Report.ComboBoxEx.SelectedValue

                RadioButtonForm_All.Checked = True

                CheckBoxForm_ShowOnlyAccessibleModules.Checked = False

                If SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission Then

                    DataGridViewForm_Selection.ItemDescription = "User(s)"

                    CheckBoxForm_ShowOnlyAccessibleModules.Visible = True

                    DataGridViewForm_Selection.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.EmployeeSummary Then

                    DataGridViewForm_Selection.ItemDescription = "Employee(s)"

                    CheckBoxForm_ShowOnlyAccessibleModules.Visible = False

                    DataGridViewForm_Selection.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSecurityPermission Then

                    DataGridViewForm_Selection.ItemDescription = "Group(s)"

                    CheckBoxForm_ShowOnlyAccessibleModules.Visible = True

                    DataGridViewForm_Selection.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSummary Then

                    DataGridViewForm_Selection.ItemDescription = "Group(s)"

                    CheckBoxForm_ShowOnlyAccessibleModules.Visible = False

                    DataGridViewForm_Selection.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                End If

            Else

                RadioButtonForm_All.Enabled = False
                RadioButtonForm_Select.Enabled = False
                DataGridViewForm_Selection.Enabled = False
                CheckBoxForm_ShowOnlyAccessibleModules.Enabled = False
                ButtonItemActions_ViewReport.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ReportSelectionForm As AdvantageFramework.Security.Reports.Presentation.ReportSelectionForm = Nothing

            ReportSelectionForm = New AdvantageFramework.Security.Reports.Presentation.ReportSelectionForm()

            ReportSelectionForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportSelectionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedReportCategoryBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_ViewReport.Image = My.Resources.ReportImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                ComboBoxItemReportType_Report.ComboBoxEx.DisplayMember = "Name"
                ComboBoxItemReportType_Report.ComboBoxEx.ValueMember = "Value"

                UserDefinedReportCategoryBindingSource = New System.Windows.Forms.BindingSource

                UserDefinedReportCategoryBindingSource.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.SecurityReportTypes), False)

                ComboBoxItemReportType_Report.ComboBoxEx.DataSource = UserDefinedReportCategoryBindingSource

                ComboBoxItemReportType_Report.SelectedIndex = 0

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            SetupFormForSelectedReport()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemReportType_Report_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportType_Report.SelectedIndexChanged

            SetupFormForSelectedReport()

        End Sub
        Private Sub ButtonItemActions_ViewReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_ViewReport.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim GroupIDsList As Generic.List(Of Integer) = Nothing
            Dim UserIDsList As Generic.List(Of Integer) = Nothing
            Dim EmployeeCodesList As Generic.List(Of String) = Nothing
            Dim GroupNamesList As Generic.List(Of String) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary

            If Me.Validator Then

                If ComboBoxItemReportType_Report.SelectedIndex >= 0 Then

                    If RadioButtonForm_All.Checked OrElse (RadioButtonForm_Select.Checked AndAlso DataGridViewForm_Selection.HasASelectedRow) Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ReportType = ComboBoxItemReportType_Report.ComboBoxEx.SelectedValue

                            If RadioButtonForm_Select.Checked AndAlso DataGridViewForm_Selection.HasASelectedRow Then

                                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                If ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    UserIDsList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityDbContext)
                                                                         Where UserIDsList.Contains(Entity.UserID) = True AndAlso
                                                                               Entity.ApplicationIsBlocked = False
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    GroupIDsList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityDbContext)
                                                                         Where GroupIDsList.Contains(Entity.GroupID) = True AndAlso
                                                                               Entity.ApplicationIsBlocked = False
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary Then

                                    EmployeeCodesList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                                                         Where EmployeeCodesList.Contains(Entity.EmployeeCode) = True
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                                    GroupNamesList = DataGridViewForm_Selection.GetAllSelectedRowsCellValues(1).OfType(Of String).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                                                         Where GroupNamesList.Contains(Entity.GroupName) = True
                                                                         Select Entity).ToList

                                End If

                            End If

                            If CheckBoxForm_ShowOnlyAccessibleModules.Checked Then

                                If ParameterDictionary Is Nothing Then

                                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                End If

                                If ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport))
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        UserIDsList = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, Me.Session).Include("Users").SelectMany(Function(Employee) Employee.Users).Distinct.ToList.Select(Function(Entity) Entity.ID).Distinct.ToList

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityDbContext)
                                                                             Where UserIDsList.Contains(Entity.UserID) = True AndAlso
                                                                                   Entity.IsBlocked = False AndAlso
                                                                                   Entity.ApplicationIsBlocked = False
                                                                             Select Entity).ToList

                                    End If

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport))
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityDbContext)
                                                                             Where Entity.IsBlocked = False AndAlso
                                                                                   Entity.ApplicationIsBlocked = False
                                                                             Select Entity).ToList

                                    End If

                                End If

                            End If

                        End Using

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a row from the grid.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a report.")

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_All_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonForm_All.CheckedChanged

            If sender.Checked Then

                DataGridViewForm_Selection.Enabled = Not RadioButtonForm_All.Checked

            End If

        End Sub
        Private Sub RadioButtonForm_Select_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonForm_Select.CheckedChanged

            'objects
            Dim SecurityReportType As AdvantageFramework.Reporting.SecurityReportTypes = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission

            If sender.Checked Then

                If ComboBoxItemReportType_Report.SelectedIndex >= 0 Then

                    SecurityReportType = ComboBoxItemReportType_Report.ComboBoxEx.SelectedValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, Me.Session).Include("Users").Include("Department").SelectMany(Function(Employee) Employee.Users).Distinct.OrderBy(Function(User) User.UserCode)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.EmployeeSummary Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, Me.Session).Include("Users").Where(Function(Entity) Entity.Users.Any)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSecurityPermission Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSummary Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext)

                            End If

                            DataGridViewForm_Selection.CurrentView.BestFitColumns()

                            DataGridViewForm_Selection.Enabled = RadioButtonForm_Select.Checked

                        End Using

                    End Using

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace