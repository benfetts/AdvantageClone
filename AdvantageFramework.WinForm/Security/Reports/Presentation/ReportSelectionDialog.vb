Namespace Security.Reports.Presentation

    Public Class ReportSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = AdvantageFramework.Reporting.ReportTypes.SecurityPermission
        Private _UsePassedInReportTypeOnly As Boolean = False
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property
        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal UsePassedInReportTypeOnly As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ReportType = ReportType
            _UsePassedInReportTypeOnly = UsePassedInReportTypeOnly

        End Sub
        Private Sub SetupFormForSelectedReport()

            'objects
            Dim SecurityReportType As AdvantageFramework.Reporting.SecurityReportTypes = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission

            DataGridViewForm_Selection.DataSource = Nothing

            DataGridViewForm_Selection.ClearColumns()

            If ComboBoxForm_Report.HasASelectedValue Then

                RadioButtonForm_All.Enabled = True
                RadioButtonForm_Select.Enabled = True
                DataGridViewForm_Selection.Enabled = False
                CheckBoxForm_ShowOnlyAccessibleModules.Enabled = True
                ButtonForm_View.Enabled = True

                SecurityReportType = ComboBoxForm_Report.GetSelectedValue

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
                ButtonForm_View.Enabled = False

            End If
            
        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal UsePassedInReportTypeOnly As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ReportSelectionDialog As AdvantageFramework.Security.Reports.Presentation.ReportSelectionDialog = Nothing

            ReportSelectionDialog = New AdvantageFramework.Security.Reports.Presentation.ReportSelectionDialog(ReportType, UsePassedInReportTypeOnly)

            ShowFormDialog = ReportSelectionDialog.ShowDialog()

            ReportType = ReportSelectionDialog.ReportType
            ParameterDictionary = ReportSelectionDialog.ParameterDictionary

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                ComboBoxForm_Report.DisplayName = "Security Report"

                ComboBoxForm_Report.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.SecurityReportTypes), False)

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            If _UsePassedInReportTypeOnly Then

                ComboBoxForm_Report.SelectedValue = _ReportType
                ComboBoxForm_Report.Enabled = False

            End If

            SetupFormForSelectedReport()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Report_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Report.SelectionChangeCommitted

            SetupFormForSelectedReport()

        End Sub
        Private Sub ButtonForm_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_View.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim GroupIDsList As Generic.List(Of Integer) = Nothing
            Dim UserIDsList As Generic.List(Of Integer) = Nothing
            Dim EmployeeCodesList As Generic.List(Of String) = Nothing
            Dim GroupNamesList As Generic.List(Of String) = Nothing

            If Me.Validator Then

                If ComboBoxForm_Report.HasASelectedValue Then

                    If RadioButtonForm_All.Checked OrElse (RadioButtonForm_Select.Checked AndAlso DataGridViewForm_Selection.HasASelectedRow) Then

                        Using SecurityObjectContext = New AdvantageFramework.Security.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                            _ReportType = ComboBoxForm_Report.GetSelectedValue

                            If RadioButtonForm_Select.Checked AndAlso DataGridViewForm_Selection.HasASelectedRow Then

                                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                If _ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    UserIDsList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityObjectContext) _
                                                                         Where UserIDsList.Contains(Entity.UserID) = True AndAlso _
                                                                               Entity.ApplicationIsBlocked = False _
                                                                         Select Entity).ToList

                                ElseIf _ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    GroupIDsList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityObjectContext) _
                                                                         Where GroupIDsList.Contains(Entity.GroupID) = True AndAlso _
                                                                               Entity.ApplicationIsBlocked = False _
                                                                         Select Entity).ToList

                                ElseIf _ReportType = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary Then

                                    EmployeeCodesList = DataGridViewForm_Selection.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityObjectContext) _
                                                                         Where EmployeeCodesList.Contains(Entity.EmployeeCode) = True
                                                                         Select Entity).ToList

                                ElseIf _ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                                    GroupNamesList = DataGridViewForm_Selection.GetAllSelectedRowsCellValues(1).OfType(Of String).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityObjectContext) _
                                                                         Where GroupNamesList.Contains(Entity.GroupName) = True
                                                                         Select Entity).ToList

                                End If

                            End If

                            If CheckBoxForm_ShowOnlyAccessibleModules.Checked Then

                                If ParameterDictionary Is Nothing Then

                                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                End If

                                If _ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)) _
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityObjectContext) _
                                                                             Where Entity.IsBlocked = False AndAlso _
                                                                                   Entity.ApplicationIsBlocked = False _
                                                                             Select Entity).ToList

                                    End If

                                ElseIf _ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)) _
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityObjectContext) _
                                                                             Where Entity.IsBlocked = False AndAlso _
                                                                                   Entity.ApplicationIsBlocked = False _
                                                                             Select Entity).ToList

                                    End If

                                End If

                            End If

                            _ParameterDictionary = ParameterDictionary

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End Using

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a row from the grid.")

                    End If
                    
                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a report.")

                End If
                
            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

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

                If ComboBoxForm_Report.HasASelectedValue Then

                    SecurityReportType = ComboBoxForm_Report.GetSelectedValue

                    Using ObjectContext = New AdvantageFramework.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                        Using SecurityObjectContext = New AdvantageFramework.Security.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                            If SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityObjectContext).Include("Employee").Include("Employee.Department").OrderBy(Function(User) User.UserCode)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.EmployeeSummary Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.EmployeeView.Load(SecurityObjectContext).Include("Users").Where(Function(Entity) Entity.Users.Any)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSecurityPermission Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityObjectContext)

                            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSummary Then

                                DataGridViewForm_Selection.DataSource = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityObjectContext)

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