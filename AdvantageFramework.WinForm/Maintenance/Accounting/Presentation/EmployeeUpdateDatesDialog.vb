Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeUpdateDatesDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeesList() As Generic.List(Of AdvantageFramework.Database.Views.Employee)
            Get
                EmployeesList = _EmployeesList
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee))

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeesList = EmployeesList

        End Sub
        Private Sub EnableOrDisableActions()

            DateTimePickerForm_DateFrom.Value = System.DateTime.Today
            DateTimePickerForm_DateTo.Value = System.DateTime.Today
            NumericInputForm_Year.EditValue = System.DateTime.Today.Year

            If CheckBoxForm_UpdateByStartDate.Checked Then

                LabelForm_EnterToAndFromDates.Text = "Please Enter a Year"
                LabelForm_FromDate.Text = "Year:"
                NumericInputForm_Year.Visible = True
                DateTimePickerForm_DateFrom.Visible = False
                LabelForm_ToDate.Visible = False
                DateTimePickerForm_DateTo.Visible = False
                DateTimePickerForm_DateFrom.SetRequired(False)
                NumericInputForm_Year.SetRequired(True)

            Else

                LabelForm_EnterToAndFromDates.Text = "Please Enter To and From Dates"
                LabelForm_FromDate.Text = "From Date:"
                NumericInputForm_Year.Visible = False
                DateTimePickerForm_DateFrom.Visible = True
                LabelForm_ToDate.Visible = True
                DateTimePickerForm_DateTo.Visible = True
                DateTimePickerForm_DateFrom.SetRequired(True)
                NumericInputForm_Year.SetRequired(False)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee)) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeUpdateDatesDialog As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateDatesDialog = Nothing

            EmployeeUpdateDatesDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateDatesDialog(EmployeesList)

            ShowFormDialog = EmployeeUpdateDatesDialog.ShowDialog()

            EmployeesList = EmployeeUpdateDatesDialog.EmployeesList

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeUpdateDatesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            NumericInputForm_Year.SetPropertySettings("Year")
            NumericInputForm_Year.Properties.MaxValue = 9999
            NumericInputForm_Year.Properties.MinValue = 0

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim DateFrom As Date = Nothing
            Dim DateTo As Date = Nothing
            Dim Vacation As Boolean = Nothing
            Dim Sick As Boolean = Nothing
            Dim Personal As Boolean = Nothing
            Dim AlertMessage As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ContinueUpdate As Boolean = False
            Dim Year As Integer = Nothing
            Dim CancelUpdateEmployee As Boolean = False

            If Me.Validator Then

                DateFrom = DateTimePickerForm_DateFrom.Value
                DateTo = DateTimePickerForm_DateTo.Value
                Vacation = CheckBoxForm_Vacation.Checked
                Sick = CheckBoxForm_Sick.Checked
                Personal = CheckBoxForm_Personal.Checked
                Year = NumericInputForm_Year.Value

                If Personal OrElse Sick OrElse Vacation Then

                    If CheckBoxForm_UpdateByStartDate.Checked Then

                        ContinueUpdate = (Year <> Nothing AndAlso Year > 0)

                    Else

                        ContinueUpdate = (DateFrom <> Nothing)

                    End If

                End If

                If ContinueUpdate Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AlertMessage = "This will change All Employees "

                        If Vacation Then

                            AlertMessage = AlertMessage & "Vacation"

                            If Sick And Personal Then

                                AlertMessage = AlertMessage & ", Sick, and Personal"

                            ElseIf Sick Then

                                AlertMessage = AlertMessage & " and Sick"

                            ElseIf Personal Then

                                AlertMessage = AlertMessage & " and Personal"

                            End If

                        ElseIf Sick Then

                            AlertMessage = AlertMessage & "Sick"

                            If Personal Then

                                AlertMessage = AlertMessage & " and Personal"

                            End If

                        ElseIf Personal Then

                            AlertMessage = AlertMessage & "Personal"

                        End If

                        AlertMessage = AlertMessage & " From and To Dates. Are you sure you want to do this?"

                        If AdvantageFramework.WinForm.MessageBox.Show(AlertMessage, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            For Each Employee In _EmployeesList

                                CancelUpdateEmployee = False

                                Try

                                    If CheckBoxForm_UpdateByStartDate.Checked Then

                                        If Employee.StartDate.HasValue Then

                                            DateFrom = New System.DateTime(Year, Employee.StartDate.Value.Month, Employee.StartDate.Value.Day)
                                            DateTo = DateFrom.AddYears(1).AddDays(-1)

                                        Else

                                            CancelUpdateEmployee = True

                                        End If

                                    End If

                                    If CancelUpdateEmployee = False Then

                                        If Sick Then

                                            Employee.SickDateTo = DateTo
                                            Employee.SickDateFrom = DateFrom

                                        End If

                                        If Vacation Then

                                            Employee.VacationDateTo = DateTo
                                            Employee.VacationDateFrom = DateFrom

                                        End If

                                        If Personal Then

                                            Employee.PersonalHoursDateTo = DateTo
                                            Employee.PersonalHoursDateFrom = DateFrom

                                        End If

                                    End If

                                Catch ex As Exception

                                End Try

                            Next

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End Using

                Else

                    If Personal = False AndAlso Sick = False AndAlso Vacation = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a date type.")

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DateTimePickerForm_DateFrom_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerForm_DateFrom.ValueChanged

            DateTimePickerForm_DateTo.MinDate = DateTimePickerForm_DateFrom.Value

        End Sub
        Private Sub CheckBoxForm_UpdateByStartDate_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_UpdateByStartDate.CheckedChangedEx

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
