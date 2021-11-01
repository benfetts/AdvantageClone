Namespace Reporting.Presentation

    Public Class EmployeeInOutInitialLoadingDialog

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

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim EmployeeInOutInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EmployeeInOutInitialLoadingDialog = Nothing

            EmployeeInOutInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EmployeeInOutInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = EmployeeInOutInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EmployeeInOutInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeInOutInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_StartingDate.Value = Now
            'DateTimePicker_EndingDate.Value = Now

            'ComboBoxForm_StartingPostPeriod.SetRequired(True)
            'ComboBoxForm_EndingPostPeriod.SetRequired(True)

            'Me.CheckBoxForm_LimitEntries.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            End Using

            If _ParameterDictionary IsNot Nothing Then

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                'If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeInOutParameters.LimitEntries.ToString) = CheckBoxForm_LimitEntries.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeInOutParameters.UserCode.ToString) = Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeInOutParameters.StartingDate.ToString) = DateTimePickerForm_StartingDate.Value.ToShortDateString


                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

                'Else

                '    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

                'End If

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
        'Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    DateTimePicker_StartingDate.Value = New Date(Now.Year, 1, 1)
        '    DateTimePicker_EndingDate.Value = Now

        'End Sub
        'Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    DateTimePicker_StartingDate.Value = New Date(Now.Year, Now.Month, 1)
        '    DateTimePicker_EndingDate.Value = Now

        'End Sub
        'Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    DateTimePicker_StartingDate.Value = Now.AddYears(-1)
        '    DateTimePicker_EndingDate.Value = Now

        'End Sub
        'Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    DateTimePicker_StartingDate.Value = Now.AddYears(-2)
        '    DateTimePicker_EndingDate.Value = Now

        'End Sub
#End Region

#End Region

    End Class

End Namespace