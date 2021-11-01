Namespace Reporting.Presentation

    Public Class ResourceAllocationByWeekInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub

        Private Sub Loadweeks()
            Try
                Dim dt As DataTable
                dt = New DataTable
                dt.Columns.Add("Week")
                dt.Columns.Add("Value")

                Dim newrow As DataRow

                newrow = dt.NewRow
                newrow.Item("Week") = 1
                newrow.Item("Value") = 1
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 2
                newrow.Item("Value") = 2
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 3
                newrow.Item("Value") = 3
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 4
                newrow.Item("Value") = 4
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 5
                newrow.Item("Value") = 5
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 6
                newrow.Item("Value") = 6
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 7
                newrow.Item("Value") = 7
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 8
                newrow.Item("Value") = 8
                dt.Rows.Add(newrow)

                Me.ComboBox_Week.DataSource = dt

            Catch ex As Exception

            End Try
        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim ResourceAllocationByWeekInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.ResourceAllocationByWeekInitialLoadingDialog = Nothing

            ResourceAllocationByWeekInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.ResourceAllocationByWeekInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = ResourceAllocationByWeekInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = ResourceAllocationByWeekInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerStartingWeek.Value = Now

            Loadweeks()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.StartingWeek.ToString) = DateTimePickerStartingWeek.Value.Date
                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.NumberOfWeeks.ToString) = ComboBox_Week.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.View.ToString) = If(RadioButtonForm_Summary.Checked, 1, 2)


                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()


            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DateTimePickerStartingWeek_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartingWeek.ValueChanged
            Try
                Dim FirstDayOfWeekDate As Date

                For i As Integer = 0 To 6 Step 1

                    FirstDayOfWeekDate = CDate(DateTimePickerStartingWeek.Value).AddDays(-i)

                    If FirstDayOfWeekDate.DayOfWeek = DayOfWeek.Sunday Then

                        Exit For

                    End If

                Next

                Me.DateTimePickerStartingWeek.Value = FirstDayOfWeekDate

                DateTimePickerStartingWeek.MinDate = FirstDayOfWeekDate

            Catch ex As Exception

            End Try
        End Sub

#End Region

#End Region

    End Class

End Namespace