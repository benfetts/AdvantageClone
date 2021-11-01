Namespace Reporting.Presentation

    Public Class AlertInitialLoadingDialog

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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim AlertInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.AlertInitialLoadingDialog = Nothing

            AlertInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.AlertInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = AlertInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = AlertInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            If _DynamicReport = DynamicReports.AlertsWithRecipients Or _DynamicReport = DynamicReports.AlertsWithComments Then
                Me.CheckBoxForm_IncludeDismissed.Enabled = True
            Else
                Me.CheckBoxForm_IncludeDismissed.Enabled = False
                Me.CheckBoxForm_IncludeDismissed.Checked = False
            End If

            If _ParameterDictionary IsNot Nothing Then

                Try

                    DateTimePickerForm_From.Value = _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.StartDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    DateTimePickerForm_To.Value = _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.EndDate.ToString)

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateTimePickerForm_From.Value <= DateTimePickerForm_To.Value Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    If _DynamicReport = DynamicReports.AlertsWithRecipients Or _DynamicReport = DynamicReports.AlertsWithComments Then
                        _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.IncludeDismissed.ToString) = Me.CheckBoxForm_IncludeDismissed.Checked
                    End If
                    _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.EndDate.ToString) = DateTimePickerForm_To.Value


                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that is before the end date.")

                End If
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
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub

#End Region

#End Region

    End Class

End Namespace