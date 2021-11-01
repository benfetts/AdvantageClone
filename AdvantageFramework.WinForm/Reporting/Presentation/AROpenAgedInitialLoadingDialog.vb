Namespace Reporting.Presentation

    Public Class AROpenAgedInitialLoadingDialog

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

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim AROpenAgedInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.AROpenAgedInitialLoadingDialog = Nothing

            AROpenAgedInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.AROpenAgedInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = AROpenAgedInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = AROpenAgedInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AROpenAgedInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_PeriodCutoff.SetRequired(True)

            DateTimePickerAgingDate.Value = Now

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_PeriodCutoff.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)

                Try

                    ComboBoxForm_PeriodCutoff.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_PeriodCutoff.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    ComboBoxForm_PeriodCutoff.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.PeriodCutoff.ToString)
                    DateTimePickerAgingDate.Value = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingDate.ToString)

                Catch ex As Exception

                End Try

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString)) = False Then

                    Try

                        ComboBoxForm_RecordSource.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString)

                    Catch ex As Exception
                        ComboBoxForm_RecordSource.SelectedValue = Nothing
                    End Try

                End If

                RadioButtonForm_Invoice.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString) = 1, True, False)
                RadioButtonForm_InvoiceDueDate.Checked = Not RadioButtonForm_Invoice.Checked
                CheckBoxForm_IncludeDetails.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString)), True, _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString))

            Else

                RadioButtonForm_Invoice.Checked = True
                RadioButtonForm_InvoiceDueDate.Checked = False
                CheckBoxForm_IncludeDetails.Checked = False

            End If

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

                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.UsedID.ToString) = Me.Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.PeriodCutoff.ToString) = ComboBoxForm_PeriodCutoff.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingDate.ToString) = DateTimePickerAgingDate.Value
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString) = If(RadioButtonForm_Invoice.Checked, 1, 2)
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString) = CheckBoxForm_IncludeDetails.Checked

                If ComboBoxForm_RecordSource.HasASelectedValue Then

                    _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) = ComboBoxForm_RecordSource.GetSelectedValue

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) = 0

                End If

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

#End Region

#End Region

    End Class

End Namespace
