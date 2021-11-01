Namespace Security.Presentation

    Public Class EmployeeOfficeLimitsSetupForm

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
        Private Sub LoadGrid()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_Employees.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                    DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.ClearControl()

            EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.Enabled = DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow

            If EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.Enabled Then

                EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.Enabled = EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.LoadControl(DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.Enabled = (DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            If EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.Enabled Then

                ButtonItemActions_Copy.Enabled = True
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemCopy_CopyToEmployee.Enabled = EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.HasLimitedOffices

            Else

                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemCopy_CopyToEmployee.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = True

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeOfficeLimitsSetupForm As AdvantageFramework.Security.Presentation.EmployeeOfficeLimitsSetupForm = Nothing

            EmployeeOfficeLimitsSetupForm = New AdvantageFramework.Security.Presentation.EmployeeOfficeLimitsSetupForm()

            EmployeeOfficeLimitsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeOfficeLimitsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemCopy_CopyToEmployee.Icon = AdvantageFramework.My.Resources.CopyIcon

            DataGridViewLeftSection_Employees.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeOfficeLimitsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeOfficeLimitsSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeOfficeLimitsSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Employees.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Employees_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Employees.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Employees.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an employee to save.")

            End If

        End Sub
        Private Sub ButtonItemCopy_CopyToEmployee_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCopy_CopyToEmployee.Click

            EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.CopyOfficeLimits(True)

            EnableOrDisableActions()

            'Dim SelectedEmployeeCode As String = Nothing
            'Dim Employees As IEnumerable = Nothing
            'Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            'Dim DuplicateEmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice = Nothing

            'If EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.HasLimitedOffices Then

            '    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Employee, True, True, Employees, True, "Copy To Employees") = Windows.Forms.DialogResult.OK Then

            '        Me.ShowWaitForm("Processing...") 

            '        If Employees IsNot Nothing Then

            '            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '                EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue).ToList

            '                For Each SelectedEmployeeCode In (From Entity In Employees _
            '                                                  Select Entity.Code).ToList

            '                    If SelectedEmployeeCode IsNot Nothing Then

            '                        For Each EmployeeOffice In EmployeeOffices

            '                            DuplicateEmployeeOffice = New AdvantageFramework.Database.Entities.EmployeeOffice

            '                            DuplicateEmployeeOffice.DbContext = DbContext
            '                            DuplicateEmployeeOffice.EmployeeCode = SelectedEmployeeCode
            '                            DuplicateEmployeeOffice.OfficeCode = EmployeeOffice.OfficeCode
            '                            DuplicateEmployeeOffice.UserGroupCode = EmployeeOffice.UserGroupCode

            '                            AdvantageFramework.Database.Procedures.EmployeeOffice.Insert(DbContext, DuplicateEmployeeOffice)

            '                        Next

            '                    End If

            '                Next

            '            End Using

            '            LoadSelectedItemDetails()

            '        End If

            '    End If

            '    Me.CloseWaitForm()

            'End If

        End Sub
        Private Sub ButtonItemCopy_CopyFrom_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCopy_CopyFrom.Click

            EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.CopyOfficeLimits(False)

            EnableOrDisableActions()

            'Dim SelectedEmployeeCode As String = Nothing
            'Dim Employees As IEnumerable = Nothing
            'Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            'Dim DuplicateEmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice = Nothing

            'If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.OfficeLimitGroup, True, True, Employees, False) = Windows.Forms.DialogResult.OK Then

            '    Me.ShowWaitForm("Processing...") 

            '    Try

            '        SelectedEmployeeCode = (From Entity In Employees _
            '                                Select Entity.Code).FirstOrDefault

            '    Catch ex As Exception
            '        SelectedEmployeeCode = Nothing
            '    End Try

            '    If SelectedEmployeeCode IsNot Nothing Then

            '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '            EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).ToList

            '            For Each EmployeeOffice In EmployeeOffices

            '                DuplicateEmployeeOffice = New AdvantageFramework.Database.Entities.EmployeeOffice

            '                DuplicateEmployeeOffice.DbContext = DbContext
            '                DuplicateEmployeeOffice.EmployeeCode = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue
            '                DuplicateEmployeeOffice.OfficeCode = EmployeeOffice.OfficeCode
            '                DuplicateEmployeeOffice.UserGroupCode = SelectedEmployeeCode

            '                AdvantageFramework.Database.Procedures.EmployeeOffice.Insert(DbContext, DuplicateEmployeeOffice)

            '            Next

            '        End Using

            '        LoadSelectedItemDetails()

            '    End If

            '    Me.CloseWaitForm()

            'End If

        End Sub
        Private Sub EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits_OfficesChangedEvent() Handles EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits.OfficesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_EmployeeOfficeExport.DataSource = (From EmployeeOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.Load(DbContext).Include("Employee").Include("Office").ToList
                                                                           Select [Employee] = EmployeeOffice.Employee.ToString,
                                                                                  [Office] = EmployeeOffice.Office.ToString,
                                                                                  [IsInactive] = CBool(EmployeeOffice.Office.IsInactive.GetValueOrDefault(0))).ToList

                DataGridViewLeftSection_EmployeeOfficeExport.OptionsView.ShowViewCaption = False

                If DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee") IsNot Nothing Then

                    DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee").Visible = True
                    DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee").Group()

                End If

                DataGridViewLeftSection_EmployeeOfficeExport.CurrentView.BestFitColumns()

                DataGridViewLeftSection_EmployeeOfficeExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            'objects
            Dim EmployeeCode As String = Nothing

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                EmployeeCode = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_EmployeeOfficeExport.DataSource = (From EmployeeOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.Load(DbContext).Include("Employee").Include("Office").ToList
                                                                               Where EmployeeOffice.EmployeeCode = EmployeeCode
                                                                               Select [Employee] = EmployeeOffice.Employee.ToString,
                                                                                      [Office] = EmployeeOffice.Office.ToString,
                                                                                      [IsInactive] = CBool(EmployeeOffice.Office.IsInactive.GetValueOrDefault(0))).ToList

                    DataGridViewLeftSection_EmployeeOfficeExport.OptionsView.ShowViewCaption = False

                    If DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee") IsNot Nothing Then

                        DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee").Visible = True
                        DataGridViewLeftSection_EmployeeOfficeExport.Columns("Employee").Group()

                    End If

                    DataGridViewLeftSection_EmployeeOfficeExport.CurrentView.BestFitColumns()

                    DataGridViewLeftSection_EmployeeOfficeExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace