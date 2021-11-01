Namespace Security.Presentation

    Public Class EmployeeTimesheetFunctionLimitsSetupForm

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

            EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.ClearControl()

            EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.Enabled = DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow

            If EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.Enabled Then

                EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.Enabled = EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.LoadControl(DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.Enabled = (DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            If EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.Enabled Then

                ButtonItemActions_Copy.Enabled = True
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemCopy_CopyToEmployee.Enabled = EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.HasLimitedFunctions

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
            Dim EmployeeTimesheetFunctionLimitsSetupForm As AdvantageFramework.Security.Presentation.EmployeeTimesheetFunctionLimitsSetupForm = Nothing

            EmployeeTimesheetFunctionLimitsSetupForm = New AdvantageFramework.Security.Presentation.EmployeeTimesheetFunctionLimitsSetupForm()

            EmployeeTimesheetFunctionLimitsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimesheetFunctionLimitsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        Private Sub EmployeeTimesheetFunctionLimitsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeTimesheetFunctionLimitsSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeTimesheetFunctionLimitsSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

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

            EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.CopyFunctionLimits(True)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemCopy_CopyFrom_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCopy_CopyFrom.Click

            EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.CopyFunctionLimits(False)

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeOfficeLimitControlRightSection_EmployeeOfficeLimits_OfficesChangedEvent()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_EmployeeTimesheetFunctionExport.DataSource = (From EmployeeTimesheetFunction In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Load(DbContext).Include("Function").ToList
                                                                                      Join Emp In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext) On Emp.Code Equals EmployeeTimesheetFunction.EmployeeCode
                                                                                      Select [Employee] = Emp.FirstName & " " & If(Emp.MiddleInitial <> "", Emp.MiddleInitial & ". ", "") & Emp.LastName,
                                                                                             [GroupCode] = EmployeeTimesheetFunction.GroupCode,
                                                                                             [Function] = EmployeeTimesheetFunction.Function.ToString,
                                                                                             [IsInactive] = CBool(EmployeeTimesheetFunction.Function.IsInactive.GetValueOrDefault(0))
                                                                                      Order By GroupCode, Employee).ToList

                DataGridViewLeftSection_EmployeeTimesheetFunctionExport.OptionsView.ShowViewCaption = False

                If DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee") IsNot Nothing Then

                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee").Visible = True
                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee").Group()

                End If

                DataGridViewLeftSection_EmployeeTimesheetFunctionExport.CurrentView.BestFitColumns()

                DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            'objects
            Dim EmployeeCode As String = Nothing

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                EmployeeCode = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.DataSource = (From EmployeeTimesheetFunction In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Load(DbContext).Include("Function").ToList
                                                                                          Join Emp In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext) On Emp.Code Equals EmployeeTimesheetFunction.EmployeeCode
                                                                                          Where EmployeeTimesheetFunction.EmployeeCode = EmployeeCode
                                                                                          Select [Employee] = Emp.FirstName & " " & If(Emp.MiddleInitial <> "", Emp.MiddleInitial & ". ", "") & Emp.LastName,
                                                                                                 [GroupCode] = EmployeeTimesheetFunction.GroupCode,
                                                                                                 [Function] = EmployeeTimesheetFunction.Function.ToString,
                                                                                                 [IsInactive] = CBool(EmployeeTimesheetFunction.Function.IsInactive.GetValueOrDefault(0))
                                                                                          Order By GroupCode, Employee).ToList

                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.OptionsView.ShowViewCaption = False

                    If DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee") IsNot Nothing Then

                        DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee").Visible = True
                        DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Columns("Employee").Group()

                    End If

                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.CurrentView.BestFitColumns()

                    DataGridViewLeftSection_EmployeeTimesheetFunctionExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End Using

            End If

        End Sub
        Private Sub EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits_FunctionsChangedEvent() Handles EmployeeTimesheetFunctionLimitsControlRightSection_FunctionLimits.FunctionsChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace