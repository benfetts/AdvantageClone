Namespace Employee.Presentation

    Public Class TimesheetSettingsDialog

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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim TimesheetSettingsDialog As AdvantageFramework.Employee.Presentation.TimesheetSettingsDialog = Nothing

            TimesheetSettingsDialog = New AdvantageFramework.Employee.Presentation.TimesheetSettingsDialog()

            ShowFormDialog = TimesheetSettingsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TimesheetSettingsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDaysToDisplay As Short = Nothing
            Dim UserStartWeekOn As String = Nothing
            Dim UserShowCommentsUsing As String = Nothing
            Dim UserMainTimesheetNoPaging As Boolean = Nothing
            Dim UserDivision As String = Nothing
            Dim UserProduct As String = Nothing
            Dim UserProductCategory As String = Nothing
            Dim UserJob As String = Nothing
            Dim UserJobComp As String = Nothing
            Dim UserFunctionCategory As String = Nothing
            Dim DayList As System.DayOfWeek() = Nothing
            Dim CommentsRequired As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DayList = {System.DayOfWeek.Sunday, System.DayOfWeek.Monday, System.DayOfWeek.Saturday}

                ComboBoxForm_StartWeekOn.DataSource = (From Entity In DayList
                                                       Select [Code] = [Enum].GetName(GetType(System.DayOfWeek), Entity).ToLower.Substring(0, 3),
                                                              [Description] = [Enum].GetName(GetType(System.DayOfWeek), Entity)).ToList

                TextBoxForm_Component.SetDefaultPropertySettings(30, "Component Label", BaseClasses.PropertyTypes.Default, True)
                TextBoxForm_Division.SetDefaultPropertySettings(30, "Division Label", BaseClasses.PropertyTypes.Default, True)
                TextBoxForm_FunctionCategory.SetDefaultPropertySettings(30, "Function / Category Label", BaseClasses.PropertyTypes.Default, True)
                TextBoxForm_Job.SetDefaultPropertySettings(30, "Job Label", BaseClasses.PropertyTypes.Default, True)
                TextBoxForm_Product.SetDefaultPropertySettings(30, "Component Label", BaseClasses.PropertyTypes.Default, True)
                TextBoxForm_ProductCategory.SetDefaultPropertySettings(30, "Product Category Label", BaseClasses.PropertyTypes.Default, True)

                TextBoxForm_Component.Tag = AdvantageFramework.EmployeeTimesheet.Settings.JOB_COMP
                TextBoxForm_Division.Tag = AdvantageFramework.EmployeeTimesheet.Settings.DIVISION
                TextBoxForm_FunctionCategory.Tag = AdvantageFramework.EmployeeTimesheet.Settings.FUNC_CAT
                TextBoxForm_Job.Tag = AdvantageFramework.EmployeeTimesheet.Settings.JOB
                TextBoxForm_Product.Tag = AdvantageFramework.EmployeeTimesheet.Settings.PRODUCT
                TextBoxForm_ProductCategory.Tag = AdvantageFramework.EmployeeTimesheet.Settings.PROD_CAT
                TextBoxForm_ProductCategory.Tag = AdvantageFramework.EmployeeTimesheet.Settings.PROD_CAT
                RadioButtonControlForm_Icon.Tag = AdvantageFramework.EmployeeTimesheet.Settings.SHOW_CMNT_USING
                RadioButtonControlForm_Textbox.Tag = AdvantageFramework.EmployeeTimesheet.Settings.SHOW_CMNT_USING
                ComboBoxForm_StartWeekOn.Tag = AdvantageFramework.EmployeeTimesheet.Settings.START_WEEK_ON

                AdvantageFramework.EmployeeTimesheet.LoadTimesheetSettings(Session, Session.UserCode, UserDaysToDisplay, UserStartWeekOn,
                                                                           UserShowCommentsUsing, UserMainTimesheetNoPaging, UserDivision, UserProduct,
                                                                           UserProductCategory, UserJob, UserJobComp, UserFunctionCategory, CommentsRequired)

                TextBoxForm_Component.Text = UserJobComp
                TextBoxForm_Division.Text = UserDivision
                TextBoxForm_FunctionCategory.Text = UserFunctionCategory
                TextBoxForm_Job.Text = UserJob
                TextBoxForm_Product.Text = UserProduct
                TextBoxForm_ProductCategory.Text = UserProductCategory

                Try
                    If UserStartWeekOn = "0" Then
                        ComboBoxForm_StartWeekOn.SelectedValue = "sun"
                    ElseIf UserStartWeekOn = "1" Then
                        ComboBoxForm_StartWeekOn.SelectedValue = "mon"
                    ElseIf UserStartWeekOn = "6" Then
                        ComboBoxForm_StartWeekOn.SelectedValue = "sat"
                    End If

                Catch ex As Exception
                    ComboBoxForm_StartWeekOn.SelectedValue = "sun"
                End Try

                If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).EnableProductCategory.GetValueOrDefault(0) = 0 Then

                    LabelForm_ProductCategory.Visible = False
                    TextBoxForm_ProductCategory.Visible = False

                    LabelForm_Job.Location = New System.Drawing.Point(LabelForm_Job.Location.X, LabelForm_Job.Location.Y - 26)
                    TextBoxForm_Job.Location = New System.Drawing.Point(TextBoxForm_Job.Location.X, TextBoxForm_Job.Location.Y - 26)

                    LabelForm_Component.Location = New System.Drawing.Point(LabelForm_Component.Location.X, LabelForm_Component.Location.Y - 26)
                    TextBoxForm_Component.Location = New System.Drawing.Point(TextBoxForm_Component.Location.X, TextBoxForm_Component.Location.Y - 26)

                    LabelForm_FunctionCategory.Location = New System.Drawing.Point(LabelForm_FunctionCategory.Location.X, LabelForm_FunctionCategory.Location.Y - 26)
                    TextBoxForm_FunctionCategory.Location = New System.Drawing.Point(TextBoxForm_FunctionCategory.Location.X, TextBoxForm_FunctionCategory.Location.Y - 26)

                    Me.Size = New System.Drawing.Size(Me.Size.Width, Me.Size.Height - 26)

                End If

                If UserShowCommentsUsing = "textbox" Or CommentsRequired = True Then

                    RadioButtonControlForm_Textbox.Checked = True

                    If CommentsRequired = True Then

                        RadioButtonControlForm_Icon.Enabled = False

                    Else

                        RadioButtonControlForm_Icon.Enabled = True

                    End If

                Else

                    RadioButtonControlForm_Icon.Enabled = True
                    RadioButtonControlForm_Icon.Checked = True

                End If

            End Using

        End Sub
        Private Function SaveAppVar(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AppVarName As String, ByVal AppVarValue As String) As Boolean

            'objects
            Dim AppVars As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Saved As Boolean = False

            Try

                AppVars = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Session.UserCode, "TIMESHEET")
                           Where Entity.Name = AppVarName
                           Select Entity).SingleOrDefault

            Catch ex As Exception
                AppVars = Nothing
            End Try

            If AppVars IsNot Nothing Then

                AppVars.Value = AppVarValue

                Saved = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVars)

            Else

                AppVars = New AdvantageFramework.Database.Entities.AppVars

                AppVars.UserCode = Session.UserCode
                AppVars.Application = "TIMESHEET"
                AppVars.Group = 0
                AppVars.Type = "STRING"
                AppVars.Name = AppVarName
                AppVars.Value = AppVarValue

                Saved = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVars)

            End If

            SaveAppVar = Saved

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim FailedControl As Object = Nothing
            Dim AppVars As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim SettingName As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each TextBox In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.TextBox)()

                            If TextBox.Tag IsNot Nothing AndAlso [Enum].IsDefined(GetType(AdvantageFramework.EmployeeTimesheet.Settings), TextBox.Tag) Then

                                SaveAppVar(DbContext, TextBox.Tag.ToString, TextBox.Text)

                            End If

                        Next

                        'SaveAppVar(DbContext, ComboBoxForm_DaysToDisplay.Tag.ToString, ComboBoxForm_DaysToDisplay.GetSelectedValue.ToString)

                        If RadioButtonControlForm_Textbox.Checked Then

                            SaveAppVar(DbContext, RadioButtonControlForm_Textbox.Tag.ToString, "textbox")

                        Else

                            SaveAppVar(DbContext, RadioButtonControlForm_Icon.Tag.ToString, "icon")

                        End If

                        If ComboBoxForm_StartWeekOn.SelectedValue = "sun" Then
                            SaveAppVar(DbContext, ComboBoxForm_StartWeekOn.Tag.ToString, 0)
                        ElseIf ComboBoxForm_StartWeekOn.SelectedValue = "mon" Then
                            SaveAppVar(DbContext, ComboBoxForm_StartWeekOn.Tag.ToString, 1)
                        ElseIf ComboBoxForm_StartWeekOn.SelectedValue = "sat" Then
                            SaveAppVar(DbContext, ComboBoxForm_StartWeekOn.Tag.ToString, 6)
                        End If

                        'SaveAppVar(DbContext, ComboBoxForm_StartWeekOn.Tag.ToString, ComboBoxForm_StartWeekOn.GetSelectedValue)

                        'AdvantageFramework.Security.SaveUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInTimesheet, If(CheckBoxForm_ShowDescription.Checked, "Y", "N"))

                    End Using

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If ErrorMessage <> "" Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

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