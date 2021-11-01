Namespace WinForm.Presentation.Controls

    Public Class JobDetailFeesOOPControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property
        Public ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = GetParameterDictionary()
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub LoadControl(ParameterDictionary As Generic.Dictionary(Of String, Object))

            Me.SuspendLayout()

            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailItemInitialCriteria), False)

            DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = Now.ToShortDateString
            DateTimePickerProductionCutoffs_EmployeeTimeDate.SetRequired(True)
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = Now.ToShortDateString
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.SetRequired(True)

            DateTimePickerForm_From.Value = Now.ToShortDateString
            DateTimePickerForm_To.Value = Now.ToShortDateString

            ComboBoxProductionCutoffs_APPostingPeriod.SetRequired(True)

            'Me.RadioButtonControl_Cutoff.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ComboBoxProductionCutoffs_APPostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = Nothing
                End Try

            End Using

            If ParameterDictionary IsNot Nothing Then

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString)) = False Then

                    Try

                        Me.ComboBoxForm_Criteria.SelectedValue = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString)

                    Catch ex As Exception
                        Me.ComboBoxForm_Criteria.SelectedValue = Nothing
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)) = False Then

                    Try

                        Me.DateTimePickerForm_From.ValueObject = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)

                    Catch ex As Exception
                        Me.DateTimePickerForm_From.ValueObject = Nothing
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)) = False Then

                    Try

                        Me.DateTimePickerForm_To.ValueObject = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)

                    Catch ex As Exception
                        Me.DateTimePickerForm_To.ValueObject = Nothing
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.ShowJobsWithNoDetails.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.ShowJobsWithNoDetails.ToString)) = False Then

                    Try

                        Me.CheckBoxForm_ShowJobsWithNoDetails.Checked = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.ShowJobsWithNoDetails.ToString)

                    Catch ex As Exception
                        Me.CheckBoxForm_ShowJobsWithNoDetails.Checked = False
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncludeClosed.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncludeClosed.ToString)) = False Then

                    Try

                        Me.CheckBoxForm_IncludeClosedJobs.Checked = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncludeClosed.ToString)

                    Catch ex As Exception
                        Me.CheckBoxForm_IncludeClosedJobs.Checked = False
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)) = False Then

                    Try

                        Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)

                    Catch ex As Exception
                        Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = Nothing
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)) = False Then

                    Try

                        Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)

                    Catch ex As Exception
                        Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = Nothing
                    End Try

                End If

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString)) = False Then

                    Try

                        Me.ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString)

                    Catch ex As Exception
                        Me.ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = Nothing
                    End Try

                End If

            End If

            Me.ResumeLayout()

        End Sub
        Private Function GetParameterDictionary() As Generic.Dictionary(Of String, Object)

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) = ComboBoxForm_Criteria.GetSelectedValue
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) = DateTimePickerForm_From.Value
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) = DateTimePickerForm_To.Value
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.ShowJobsWithNoDetails.ToString) = CheckBoxForm_ShowJobsWithNoDetails.Checked
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncludeClosed.ToString) = CheckBoxForm_IncludeClosedJobs.Checked

            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) = DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) = DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) = ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue

            'If RadioButtonControl_Cutoff.Checked Then
            '    ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.DateOption.ToString) = "Cutoff"
            'End If

            'If RadioButtonControl_Current.Checked Then
            '    ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.DateOption.ToString) = "Current"
            'End If

            GetParameterDictionary = ParameterDictionary

        End Function

#Region "  Control Event Handlers "

        Private Sub JobDetailControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ComboBoxForm_Criteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Criteria.SelectedIndexChanged
            Try
                If ComboBoxForm_Criteria.SelectedValue = 0 Then
                    Me.CheckBoxForm_IncludeClosedJobs.Checked = False
                    Me.CheckBoxForm_IncludeClosedJobs.Enabled = False
                Else
                    Me.CheckBoxForm_IncludeClosedJobs.Checked = False
                    Me.CheckBoxForm_IncludeClosedJobs.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End Sub

        'Private Sub RadioButtonControl_Cutoff_CheckedChanged(sender As Object, e As EventArgs)

        '    If RadioButtonControl_Cutoff.Checked = True Then

        '        Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Enabled = True
        '        Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Enabled = True
        '        Me.ComboBoxProductionCutoffs_APPostingPeriod.Enabled = True

        '        Me.DateTimePickerProductionCurrent_StartDate.Enabled = False
        '        Me.DateTimePickerProductionCurrent_EndDate.Enabled = False
        '        Me.ComboBoxProductionCurrent_CurrentPeriod.Enabled = False

        '    End If

        'End Sub
        'Private Sub RadioButtonControl_Current_CheckedChanged(sender As Object, e As EventArgs)

        '    If RadioButtonControl_Current.Checked = True Then

        '        Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Enabled = False
        '        Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Enabled = False
        '        Me.ComboBoxProductionCutoffs_APPostingPeriod.Enabled = False

        '        Me.DateTimePickerProductionCurrent_StartDate.Enabled = True
        '        Me.DateTimePickerProductionCurrent_EndDate.Enabled = True
        '        Me.ComboBoxProductionCurrent_CurrentPeriod.Enabled = True

        '    End If

        'End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
