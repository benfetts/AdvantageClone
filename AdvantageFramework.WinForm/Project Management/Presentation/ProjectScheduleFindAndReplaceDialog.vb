Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleFindAndReplaceDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobTrafficIDs As Integer() = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ProjectScheduleIDs As Integer())

            ' This call is required by the designer.
            InitializeComponent()

            _JobTrafficIDs = ProjectScheduleIDs

        End Sub
        Private Sub ResetFields()

            LabelForm_To.Visible = False
            DateTimePickerForm_ReplaceWithDate.Visible = False
            DateTimePickerForm_SearchForDateFrom.Visible = False
            DateTimePickerForm_SearchForDateTo.Visible = False
            SearchableComboBoxForm_ReplaceWith.Visible = False
            SearchableComboBoxForm_SearchFor.Visible = False
            PanelForm_TopSection.Visible = False
            TextBoxForm_ReplaceWith.Visible = False
            TextBoxForm_SearchFor.Visible = False

            SearchableComboBoxForm_SearchFor.HideValueMemberColumn = True
            SearchableComboBoxForm_ReplaceWith.HideValueMemberColumn = True

            SearchableComboBoxForm_SearchFor.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            SearchableComboBoxForm_ReplaceWith.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None

            DateTimePickerForm_ReplaceWithDate.ValueObject = Nothing
            DateTimePickerForm_SearchForDateFrom.ValueObject = Nothing
            DateTimePickerForm_SearchForDateTo.ValueObject = Nothing
            SearchableComboBoxForm_ReplaceWith.SelectedValue = Nothing
            SearchableComboBoxForm_SearchFor.SelectedValue = Nothing
            SearchableComboBoxForm_Task.SelectedValue = Nothing
            TextBoxForm_ReplaceWith.Text = ""
            TextBoxForm_SearchFor.Text = ""

        End Sub
        Private Sub SetupFindAndReplaceInputFields()

            'objects
            Dim FindAndReplaceField As AdvantageFramework.ProjectSchedule.FindAndReplaceFields = Nothing

            ResetFields()

            If ComboBoxForm_FieldName.HasASelectedValue Then

                Select Case GetSelectedFindAndReplaceField()

                    Case ProjectSchedule.FindAndReplaceFields.StartDate

                        SetupStandardDateFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.DueDate

                        SetupStandardDateFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.TimeDue

                        SetupTimeDueFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.CompletedDate

                        SetupStandardDateFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.EmployeeAssignment

                        SetupEmployeeFindAndReplace(True)

                    Case ProjectSchedule.FindAndReplaceFields.ClientContactAssignment

                        SetupClientContactAssignmentFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.TaskStatus

                        SetupTaskStatusFindAndReplace()

                    Case ProjectSchedule.FindAndReplaceFields.Manager

                        SetupEmployeeFindAndReplace(False)

                End Select

            End If

        End Sub
        Private Sub SetupStandardDateFindAndReplace()

            DateTimePickerForm_ReplaceWithDate.Visible = True
            DateTimePickerForm_SearchForDateFrom.Visible = True
            DateTimePickerForm_SearchForDateTo.Visible = True
            LabelForm_To.Visible = True

            DateTimePickerForm_ReplaceWithDate.ValueObject = Nothing
            DateTimePickerForm_SearchForDateFrom.ValueObject = Nothing
            DateTimePickerForm_SearchForDateTo.ValueObject = Nothing

        End Sub
        Private Sub SetupEmployeeFindAndReplace(ByVal TaskVisible As Boolean)

            SearchableComboBoxForm_ReplaceWith.Visible = True
            SearchableComboBoxForm_SearchFor.Visible = True
            PanelForm_TopSection.Visible = TaskVisible

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxForm_SearchFor.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
                SearchableComboBoxForm_ReplaceWith.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Employee

                SearchableComboBoxForm_SearchFor.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                SearchableComboBoxForm_ReplaceWith.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                If TaskVisible Then

                    SearchableComboBoxForm_Task.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Task
                    SearchableComboBoxForm_Task.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)

                End If

            End Using

        End Sub
        Private Sub SetupClientContactAssignmentFindAndReplace()

            SearchableComboBoxForm_ReplaceWith.Visible = True
            SearchableComboBoxForm_SearchFor.Visible = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxForm_ReplaceWith.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.ClientContact
                SearchableComboBoxForm_SearchFor.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.ClientContact

                SearchableComboBoxForm_SearchFor.HideValueMemberColumn = True
                SearchableComboBoxForm_ReplaceWith.HideValueMemberColumn = True

                SearchableComboBoxForm_SearchFor.DataSource = AdvantageFramework.ProjectSchedule.LoadClientContacts(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                SearchableComboBoxForm_ReplaceWith.DataSource = AdvantageFramework.ProjectSchedule.LoadClientContacts(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            End Using

        End Sub
        Private Sub SetupTimeDueFindAndReplace()

            TextBoxForm_ReplaceWith.Visible = True
            TextBoxForm_SearchFor.Visible = True

            TextBoxForm_ReplaceWith.SetDefaultPropertySettings(10, "Time Due Replace With")
            TextBoxForm_SearchFor.SetDefaultPropertySettings(10, "Time Due Search For")

        End Sub
        Private Sub SetupTaskStatusFindAndReplace()

            SearchableComboBoxForm_ReplaceWith.Visible = True
            SearchableComboBoxForm_SearchFor.Visible = True

            SearchableComboBoxForm_ReplaceWith.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Status
            SearchableComboBoxForm_SearchFor.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Status

            SearchableComboBoxForm_ReplaceWith.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                                            Select Entity.Code,
                                                                   [Description] = Entity.Description

            SearchableComboBoxForm_SearchFor.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                                          Select Entity.Code,
                                                                 [Description] = Entity.Description

        End Sub
        Private Function GetSelectedFindAndReplaceField() As AdvantageFramework.ProjectSchedule.FindAndReplaceFields

            'objects
            Dim FindAndReplaceField As AdvantageFramework.ProjectSchedule.FindAndReplaceFields = Nothing

            If ComboBoxForm_FieldName.HasASelectedValue Then

                Try

                    FindAndReplaceField = DirectCast(CInt(ComboBoxForm_FieldName.SelectedValue), AdvantageFramework.ProjectSchedule.FindAndReplaceFields)

                Catch ex As Exception
                    FindAndReplaceField = Nothing
                End Try

            End If

            GetSelectedFindAndReplaceField = FindAndReplaceField

        End Function
        Private Sub EnableOrDisableActions()

            ButtonForm_ReplaceAll.Enabled = ComboBoxForm_FieldName.HasASelectedValue

        End Sub
        Private Function GetSearchForValue(ByRef AdditionalCriteria As Object) As Object

            'objects
            Dim SearchForValue As Object = Nothing

            Try

                If ComboBoxForm_FieldName.HasASelectedValue Then

                    Select Case GetSelectedFindAndReplaceField()

                        Case ProjectSchedule.FindAndReplaceFields.StartDate

                            SearchForValue = DateTimePickerForm_SearchForDateFrom.ValueObject
                            AdditionalCriteria = DateTimePickerForm_SearchForDateTo.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.DueDate

                            SearchForValue = DateTimePickerForm_SearchForDateFrom.ValueObject
                            AdditionalCriteria = DateTimePickerForm_SearchForDateTo.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.TimeDue

                            SearchForValue = TextBoxForm_SearchFor.Text

                        Case ProjectSchedule.FindAndReplaceFields.CompletedDate

                            SearchForValue = DateTimePickerForm_SearchForDateFrom.ValueObject
                            AdditionalCriteria = DateTimePickerForm_SearchForDateTo.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.EmployeeAssignment

                            SearchForValue = SearchableComboBoxForm_SearchFor.GetSelectedValue
                            AdditionalCriteria = SearchableComboBoxForm_Task.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.ClientContactAssignment

                            SearchForValue = SearchableComboBoxForm_SearchFor.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.TaskStatus

                            SearchForValue = SearchableComboBoxForm_SearchFor.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.Manager

                            SearchForValue = SearchableComboBoxForm_SearchFor.GetSelectedValue

                    End Select

                End If

            Catch ex As Exception
                SearchForValue = Nothing
            Finally
                GetSearchForValue = SearchForValue
            End Try

        End Function
        Private Function GetReplaceWithValue() As Object

            'objects
            Dim ReplaceWithValue As Object = Nothing

            Try

                If ComboBoxForm_FieldName.HasASelectedValue Then

                    Select Case GetSelectedFindAndReplaceField()

                        Case ProjectSchedule.FindAndReplaceFields.StartDate

                            ReplaceWithValue = DateTimePickerForm_ReplaceWithDate.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.DueDate

                            ReplaceWithValue = DateTimePickerForm_ReplaceWithDate.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.TimeDue

                            ReplaceWithValue = TextBoxForm_ReplaceWith.Text

                        Case ProjectSchedule.FindAndReplaceFields.CompletedDate

                            ReplaceWithValue = DateTimePickerForm_ReplaceWithDate.ValueObject

                        Case ProjectSchedule.FindAndReplaceFields.EmployeeAssignment

                            ReplaceWithValue = SearchableComboBoxForm_ReplaceWith.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.ClientContactAssignment

                            ReplaceWithValue = SearchableComboBoxForm_ReplaceWith.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.TaskStatus

                            ReplaceWithValue = SearchableComboBoxForm_ReplaceWith.GetSelectedValue

                        Case ProjectSchedule.FindAndReplaceFields.Manager

                            ReplaceWithValue = SearchableComboBoxForm_ReplaceWith.GetSelectedValue

                    End Select

                End If

            Catch ex As Exception
                ReplaceWithValue = Nothing
            Finally
                GetReplaceWithValue = ReplaceWithValue
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ProjectScheduleIDs As Integer()) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleFindAndReplaceDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleFindAndReplaceDialog = Nothing

            ProjectScheduleFindAndReplaceDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleFindAndReplaceDialog(ProjectScheduleIDs)

            ShowFormDialog = ProjectScheduleFindAndReplaceDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleFindAndReplaceDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Loaded As Boolean = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Me.ShowUnsavedChangesOnFormClosing = False

                ComboBoxForm_FieldName.SetRequired(True)

                If _JobTrafficIDs IsNot Nothing AndAlso _JobTrafficIDs.Count > 0 Then

                    ComboBoxForm_FieldName.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.ProjectSchedule.FindAndReplaceFields), False)

                    SetupFindAndReplaceInputFields()

                Else

                    Loaded = False

                End If

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading job information.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_ReplaceAll_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_ReplaceAll.Click

            'objects
            Dim Message As String = ""
            Dim Completed As Boolean = False
            Dim SearchForValue As Object = Nothing
            Dim AdditionalCriteria As Object = Nothing
            Dim ReplaceWithValue As Object = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    SearchForValue = GetSearchForValue(AdditionalCriteria)
                    ReplaceWithValue = GetReplaceWithValue()

                    If AdvantageFramework.ProjectSchedule.SearchAndReplaceTasks(Me.Session, _JobTrafficIDs, GetSelectedFindAndReplaceField(), SearchForValue, ReplaceWithValue, AdditionalCriteria, Message) Then

                        Completed = True

                    End If

                Catch ex As Exception
                    Message = "There was an error processing tasks."
                End Try

                If Completed Then

                    If String.IsNullOrEmpty(TextBoxForm_Log.Text) = False Then

                        TextBoxForm_Log.Text &= vbNewLine

                    End If

                    TextBoxForm_Log.Text &= Message

                Else

                    If String.IsNullOrEmpty(Message) = False Then

                        AdvantageFramework.Navigation.ShowMessageBox(Message)

                    End If

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_FieldName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxForm_FieldName.SelectionChangeCommitted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                SetupFindAndReplaceInputFields()
                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace