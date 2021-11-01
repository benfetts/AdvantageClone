Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeHRHistoryDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeRateHistoryID As Integer = 0
        Private _EmployeeCode As String = ""
        Private _OldEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Private _EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing
        Private _CanUserCustom1 As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeRateHistoryID As Integer
            Get
                EmployeeRateHistoryID = _EmployeeRateHistoryID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeRateHistoryID As Integer, ByVal EmployeeCode As String, ByVal OldEmployee As AdvantageFramework.Database.Views.Employee)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeRateHistoryID = EmployeeRateHistoryID
            _EmployeeCode = EmployeeCode
            _OldEmployee = OldEmployee

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmployeeRateHistoryID As Integer, ByVal EmployeeCode As String, Optional ByVal OldEmployee As AdvantageFramework.Database.Views.Employee = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeHRHistoryDialog As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog = Nothing

            EmployeeHRHistoryDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog(EmployeeRateHistoryID, EmployeeCode, OldEmployee)

            ShowFormDialog = EmployeeHRHistoryDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                EmployeeRateHistoryID = EmployeeHRHistoryDialog.EmployeeRateHistoryID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeHRHistoryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim LastEndDate As Date = Nothing

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DateTimePickerForm_StartDate.SetRequired(True)
            DateTimePickerForm_EndDate.SetRequired(True)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)

                    Try

                        _Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    Catch ex As Exception
                        _Employee = Nothing
                    End Try

                    If _Employee IsNot Nothing Then

                        Me.Text &= " - " & _Employee.ToString

                        SearchableComboBoxForm_DepartmentTeam.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                        ComboBoxForm_EmployeeTitle.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext)

                        DateTimePickerForm_StartDate.Value = CDate(Now.AddDays(-1).ToShortDateString)
                        DateTimePickerForm_EndDate.Value = CDate(Now.ToShortDateString)

                        If _EmployeeRateHistoryID = 0 Then

                            ButtonItemActions_Add.Visible = True
                            ButtonItemActions_Save.Visible = False

                            If _OldEmployee Is Nothing Then

                                _OldEmployee = _Employee

                            End If

                            If _OldEmployee IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeCode(DbContext, _EmployeeCode).Any Then

                                    Try

                                        LastEndDate = DbContext.Database.SqlQuery(Of Date)("SELECT TOP 1 END_DATE FROM dbo.EMP_RATE_HISTORY WHERE EMP_CODE = '" & _EmployeeCode & "' ORDER BY END_DATE DESC").FirstOrDefault

                                        LastEndDate = LastEndDate.AddDays(1)

                                    Catch ex As Exception
                                        LastEndDate = Nothing
                                    End Try

                                    DateTimePickerForm_StartDate.Value = If(LastEndDate <> Nothing, CDate(LastEndDate.ToShortDateString), DateTimePickerForm_StartDate.Value)

                                Else

                                    DateTimePickerForm_StartDate.Value = If(_Employee.StartDate IsNot Nothing, CDate(_Employee.StartDate.Value.ToShortDateString), DateTimePickerForm_StartDate.Value)

                                End If

                                SearchableComboBoxForm_DepartmentTeam.EditValue = _OldEmployee.DepartmentTeamCode
                                ComboBoxForm_EmployeeTitle.SelectedValue = _OldEmployee.EmployeeTitleID
                                NumericInputForm_AnnualSalary.EditValue = _OldEmployee.AnnualSalary
                                NumericInputForm_MonthlySalary.EditValue = _OldEmployee.MonthlySalary
                                NumericInputForm_CostRate.EditValue = _OldEmployee.CostRate

                                If _CanUserCustom1 = False Then

                                    NumericInputForm_AnnualSalary.EditValue = _OldEmployee.AnnualSalary
                                    NumericInputForm_MonthlySalary.EditValue = _OldEmployee.MonthlySalary
                                    NumericInputForm_CostRate.EditValue = _OldEmployee.CostRate

                                Else

                                    NumericInputForm_AnnualSalary.EditValue = 0
                                    NumericInputForm_MonthlySalary.EditValue = 0
                                    NumericInputForm_CostRate.EditValue = 0

                                    NumericInputForm_AnnualSalary.SecurityEnabled = False
                                    NumericInputForm_MonthlySalary.SecurityEnabled = False
                                    NumericInputForm_CostRate.SecurityEnabled = False

                                End If

                            End If

                        Else

                            ButtonItemActions_Add.Visible = False
                            ButtonItemActions_Save.Visible = True

                            _EmployeeRateHistory = AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeRateHistoryID(DbContext, _EmployeeRateHistoryID)

                            If _EmployeeRateHistory IsNot Nothing Then

                                DateTimePickerForm_StartDate.Value = _EmployeeRateHistory.StartDate
                                DateTimePickerForm_EndDate.Value = _EmployeeRateHistory.EndDate
                                SearchableComboBoxForm_DepartmentTeam.EditValue = _EmployeeRateHistory.DepartmentTeamCode
                                ComboBoxForm_EmployeeTitle.SelectedValue = _EmployeeRateHistory.EmployeeTitleID

                                If _CanUserCustom1 = False Then

                                    NumericInputForm_AnnualSalary.EditValue = _EmployeeRateHistory.AnnualSalary
                                    NumericInputForm_MonthlySalary.EditValue = _EmployeeRateHistory.MonthlySalary
                                    NumericInputForm_CostRate.EditValue = _EmployeeRateHistory.CostRate

                                Else

                                    NumericInputForm_AnnualSalary.EditValue = 0
                                    NumericInputForm_MonthlySalary.EditValue = 0
                                    NumericInputForm_CostRate.EditValue = 0

                                    NumericInputForm_AnnualSalary.SecurityEnabled = False
                                    NumericInputForm_MonthlySalary.SecurityEnabled = False
                                    NumericInputForm_CostRate.SecurityEnabled = False

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The rate history you are trying to edit does not exist anymore.")
                                Me.Close()

                            End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The employee you are trying to edit does not exist anymore.")
                        Me.Close()

                    End If

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EmployeeHRHistoryDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                If _EmployeeRateHistoryID = 0 Then

                    DateTimePickerForm_StartDate.Focus()

                Else

                    SearchableComboBoxForm_DepartmentTeam.Focus()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing

            If Me.Validator Then

                If DateTimePickerForm_StartDate.Value < DateTimePickerForm_EndDate.Value Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.EMP_RATE_HISTORY " &
                                                                       "WHERE ('" & DateTimePickerForm_StartDate.Value.ToShortDateString & "' BETWEEN [START_DATE] AND END_DATE OR " &
                                                                       "'" & DateTimePickerForm_EndDate.Value.ToShortDateString & "' BETWEEN [START_DATE] AND END_DATE) AND " &
                                                                       "EMP_CODE = '" & _EmployeeCode & "'").FirstOrDefault = 0 Then

                            Me.ShowWaitForm("Adding...")
                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                            Try

                                EmployeeRateHistory = New AdvantageFramework.Database.Entities.EmployeeRateHistory

                                EmployeeRateHistory.EmployeeCode = _EmployeeCode
                                EmployeeRateHistory.StartDate = DateTimePickerForm_StartDate.Value
                                EmployeeRateHistory.EndDate = DateTimePickerForm_EndDate.Value
                                EmployeeRateHistory.DepartmentTeamCode = SearchableComboBoxForm_DepartmentTeam.GetSelectedValue
                                EmployeeRateHistory.EmployeeTitleID = ComboBoxForm_EmployeeTitle.GetSelectedValue
                                EmployeeRateHistory.AnnualSalary = NumericInputForm_AnnualSalary.GetValue
                                EmployeeRateHistory.MonthlySalary = NumericInputForm_MonthlySalary.GetValue
                                EmployeeRateHistory.CostRate = NumericInputForm_CostRate.GetValue

                                If _CanUserCustom1 = False Then

                                    EmployeeRateHistory.AnnualSalary = NumericInputForm_AnnualSalary.GetValue
                                    EmployeeRateHistory.MonthlySalary = NumericInputForm_MonthlySalary.GetValue
                                    EmployeeRateHistory.CostRate = NumericInputForm_CostRate.GetValue

                                Else

                                    EmployeeRateHistory.AnnualSalary = _OldEmployee.AnnualSalary
                                    EmployeeRateHistory.MonthlySalary = _OldEmployee.MonthlySalary
                                    EmployeeRateHistory.CostRate = _OldEmployee.CostRate

                                End If

                                If AdvantageFramework.Database.Procedures.EmployeeRateHistory.Insert(DbContext, EmployeeRateHistory) Then

                                    _EmployeeRateHistoryID = EmployeeRateHistory.ID

                                    Me.ClearChanged()

                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                    Me.Close()

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Failed inserting new rate history.  Please contact software support.")

                                End If

                            Catch ex As Exception
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                            Me.CloseWaitForm()
                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a start date and end date that do not overlap previous rate histories.")

                        End If

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date before the end date.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing

            If Me.Validator Then

                If DateTimePickerForm_StartDate.Value < DateTimePickerForm_EndDate.Value Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.EMP_RATE_HISTORY " &
                                                                       "WHERE ('" & DateTimePickerForm_StartDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "' BETWEEN [START_DATE] AND END_DATE OR " &
                                                                       "'" & DateTimePickerForm_EndDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "' BETWEEN [START_DATE] AND END_DATE) AND " &
                                                                       "EMP_CODE = '" & _EmployeeCode & "' AND " &
                                                                       "EMP_RATE_HISTORY_ID <> " & _EmployeeRateHistoryID).FirstOrDefault = 0 Then

                            Me.ShowWaitForm("Saving...")
                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                            Try

                                EmployeeRateHistory = AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeRateHistoryID(DbContext, _EmployeeRateHistoryID)

                                If EmployeeRateHistory IsNot Nothing Then

                                    EmployeeRateHistory.StartDate = DateTimePickerForm_StartDate.Value
                                    EmployeeRateHistory.EndDate = DateTimePickerForm_EndDate.Value
                                    EmployeeRateHistory.DepartmentTeamCode = SearchableComboBoxForm_DepartmentTeam.GetSelectedValue
                                    EmployeeRateHistory.EmployeeTitleID = ComboBoxForm_EmployeeTitle.GetSelectedValue
                                    EmployeeRateHistory.AnnualSalary = NumericInputForm_AnnualSalary.GetValue
                                    EmployeeRateHistory.MonthlySalary = NumericInputForm_MonthlySalary.GetValue
                                    EmployeeRateHistory.CostRate = NumericInputForm_CostRate.GetValue

                                    If _CanUserCustom1 = False Then

                                        EmployeeRateHistory.AnnualSalary = NumericInputForm_AnnualSalary.GetValue
                                        EmployeeRateHistory.MonthlySalary = NumericInputForm_MonthlySalary.GetValue
                                        EmployeeRateHistory.CostRate = NumericInputForm_CostRate.GetValue

                                    Else

                                        EmployeeRateHistory.AnnualSalary = _EmployeeRateHistory.AnnualSalary
                                        EmployeeRateHistory.MonthlySalary = _EmployeeRateHistory.MonthlySalary
                                        EmployeeRateHistory.CostRate = _EmployeeRateHistory.CostRate

                                    End If

                                    If AdvantageFramework.Database.Procedures.EmployeeRateHistory.Update(DbContext, EmployeeRateHistory) Then

                                        Me.ClearChanged()

                                        Me.DialogResult = Windows.Forms.DialogResult.OK
                                        Me.Close()

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving rate history.  Please contact software support.")

                                    End If

                                End If

                            Catch ex As Exception
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                            Me.CloseWaitForm()
                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a start date and end date that do not overlap previous rate histories.")

                        End If

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date before the end date.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub NumericInputForm_AnnualSalary_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_AnnualSalary.ValueChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Try

                    NumericInputForm_MonthlySalary.EditValue = Math.Round(NumericInputForm_AnnualSalary.EditValue / 12, 2)

                Catch ex As Exception
                    NumericInputForm_MonthlySalary.EditValue = Nothing
                End Try

                Try

                    NumericInputForm_CostRate.EditValue = Math.Round(NumericInputForm_AnnualSalary.EditValue / _Employee.AnnualHours.GetValueOrDefault(0), 2)

                Catch ex As Exception
                    NumericInputForm_CostRate.EditValue = Nothing
                End Try

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
