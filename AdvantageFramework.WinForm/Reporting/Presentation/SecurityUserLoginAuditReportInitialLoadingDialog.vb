Namespace Reporting.Presentation

    Public Class SecurityUserLoginAuditReportInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim SecurityUserLoginAuditReportInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.SecurityUserLoginAuditReportInitialLoadingDialog = Nothing

            SecurityUserLoginAuditReportInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.SecurityUserLoginAuditReportInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = SecurityUserLoginAuditReportInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = SecurityUserLoginAuditReportInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SecurityUserLoginAuditReportInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            CheckBoxForm_ShowOnlyFailures.Visible = True

            DateTimePickerForm_Start.SetRequired(True)
            DateTimePickerForm_End.SetRequired(True)

            DateTimePickerForm_Start.Value = Now
            DateTimePickerForm_End.Value = Now

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.SecurityUserLoginAuditParameters.StartDate.ToString) = New Date(DateTimePickerForm_Start.Value.Year, DateTimePickerForm_Start.Value.Month, DateTimePickerForm_Start.Value.Day, 0, 0, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.SecurityUserLoginAuditParameters.EndDate.ToString) = New Date(DateTimePickerForm_End.Value.Year, DateTimePickerForm_End.Value.Month, DateTimePickerForm_End.Value.Day, 23, 59, 59)
                _ParameterDictionary(AdvantageFramework.Reporting.SecurityUserLoginAuditParameters.OnlyFailures.ToString) = CheckBoxForm_ShowOnlyFailures.Checked

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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            DateTimePickerForm_Start.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_End.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            DateTimePickerForm_Start.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_End.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_Start.Value = Now.AddYears(-1)
            DateTimePickerForm_End.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_Start.Value = Now.AddYears(-2)
            DateTimePickerForm_End.Value = Now

        End Sub
        Private Sub DateTimePickerForm_End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_End.ValueChanged

            DateTimePickerForm_Start.MaxDate = DateTimePickerForm_End.Value

        End Sub
        Private Sub DateTimePickerForm_Start_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_Start.ValueChanged

            DateTimePickerForm_End.MinDate = DateTimePickerForm_Start.Value

        End Sub

#End Region

#End Region

    End Class

End Namespace