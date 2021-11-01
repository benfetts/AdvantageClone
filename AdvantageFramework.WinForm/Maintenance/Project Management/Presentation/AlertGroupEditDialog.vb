Namespace Maintenance.ProjectManagement.Presentation

    Public Class AlertGroupEditDialog

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

        End Sub
        Private Sub LoadEmployees()

            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim AvailableEmployeeList As Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AvailableEmployeeList = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).Include("Role").Include("Function").ToList

                For Each Employee In EmployeeList

                    AvailableEmployeeList.Add(New AdvantageFramework.Database.Classes.AlertGroupEmployee(Employee))

                Next

                DataGridViewRightSection_AlertGroupEmployees.DataSource = AvailableEmployeeList

                DataGridViewRightSection_AlertGroupEmployees.CurrentView.BestFitColumns()

                If DataGridViewRightSection_AlertGroupEmployees.Columns("AlertGroupCode") IsNot Nothing Then

                    DataGridViewRightSection_AlertGroupEmployees.Columns("AlertGroupCode").Visible = False

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef AlertGroupCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim AlertGroupEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupEditDialog = Nothing

            AlertGroupEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupEditDialog()

            ShowFormDialog = AlertGroupEditDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                AlertGroupCode = AlertGroupEditDialog.Tag

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertGroupEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_AlertGroup.SetPropertySettings(AdvantageFramework.Database.Entities.AlertGroup.Properties.Code)

            End Using

            LoadEmployees()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing
            Dim AlertGroupEmployeesList As Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If (From Entity In AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).ToList
                            Where Entity.Code.ToUpper = TextBoxForm_AlertGroup.Text.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            AdvantageFramework.WinForm.MessageBox.Show("Please enter a unique code")

                        End If

                        If IsValid Then

                            AlertGroupEmployeesList = DataGridViewRightSection_AlertGroupEmployees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)().ToList

                            For Each AlertGroupEmployee In AlertGroupEmployeesList

                                AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup

                                AlertGroup.DbContext = DbContext
                                AlertGroup.Code = TextBoxForm_AlertGroup.Text
                                AlertGroup.IsInactive = Convert.ToInt16(CheckBoxForm_Inactive.Checked)
                                AlertGroup.EmployeeCode = AlertGroupEmployee.EmployeeCode
                                AlertGroup.IncludeOnSchedule = Convert.ToInt16(AlertGroupEmployee.IncludeOnSchedule)

                                AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                            Next

                            If AlertGroup.IsInactive.GetValueOrDefault(0) <> 1 Then

                                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                                    SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                    SettingValue.DataContext = DataContext

                                    SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString
                                    SettingValue.DisplayText = TextBoxForm_AlertGroup.Text
                                    SettingValue.Value = TextBoxForm_AlertGroup.Text

                                    AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)
                                End Using

                            End If

                            For Each AlertCategory In AdvantageFramework.Database.Procedures.AlertCategory.Load(DbContext).ToList

                                AlertGroupCategory = New AdvantageFramework.Database.Entities.AlertGroupCategory

                                AlertGroupCategory.DbContext = DbContext

                                AlertGroupCategory.AlertGroupCode = TextBoxForm_AlertGroup.Text
                                AlertGroupCategory.AlertCategoryID = AlertCategory.ID
                                AlertGroupCategory.IsActive = 1

                                DbContext.AlertGroupCategories.Add(AlertGroupCategory)

                            Next

                            Try

                                DbContext.SaveChanges()

                            Catch ex As Exception

                            End Try

                            Me.Tag = TextBoxForm_AlertGroup.Text
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace