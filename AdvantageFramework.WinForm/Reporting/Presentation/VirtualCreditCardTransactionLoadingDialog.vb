Namespace Reporting.Presentation

    Public Class VirtualCreditCardTransactionLoadingDialog

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
            Dim VirtualCreditCardTransactionLoadingDialog As AdvantageFramework.Reporting.Presentation.VirtualCreditCardTransactionLoadingDialog = Nothing

            VirtualCreditCardTransactionLoadingDialog = New AdvantageFramework.Reporting.Presentation.VirtualCreditCardTransactionLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = VirtualCreditCardTransactionLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = VirtualCreditCardTransactionLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VirtualCreditCardTransactionLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_StartDate.SetRequired(True)
            DateTimePickerForm_EndDate.SetRequired(True)

            DateTimePickerForm_StartDate.ValueObject = DateAdd(DateInterval.Day, -31, Now).ToShortDateString
            DateTimePickerForm_EndDate.ValueObject = Now.ToShortDateString

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim AllowContinue As Boolean = True
            Dim VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail) = Nothing

            If Me.Validator Then

                If DateTimePickerForm_StartDate.ValueObject <= DateTimePickerForm_EndDate.ValueObject Then

                    If RadioButtonDateRangeType_VCCTransaction.Checked AndAlso DateDiff(DateInterval.Day, DateTimePickerForm_StartDate.GetValue, DateTimePickerForm_EndDate.GetValue) > 31 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Maximum range of dates cannot exceed 31.")
                        AllowContinue = False

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that is before the end date.")
                    AllowContinue = False

                End If

                If AllowContinue AndAlso RadioButtonDateRangeType_VCCTransaction.Checked Then

                    Me.ShowWaitForm("Retrieving transactions...")

                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        If VCC.LoadVCCProvider(DataContext) <> AdvantageFramework.VCC.VCCProviders.EFS Then

                            AdvantageFramework.WinForm.MessageBox.Show("VCC Provider must be EFS to use this option.")
                            AllowContinue = False

                        ElseIf Not AdvantageFramework.VCC.IsVCCServiceSetup(Session) Then

                            AdvantageFramework.WinForm.MessageBox.Show("VCC settings are not configured correctly.")
                            AllowContinue = False

                        Else

                            VirtualCreditCardTransactionEFSDetails = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail)

                            If Not AdvantageFramework.VCC.GetTransactionsForDataset(Session, DateTimePickerForm_StartDate.GetValue, DateTimePickerForm_EndDate.GetValue, VirtualCreditCardTransactionEFSDetails, ErrorMessage) Then

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                                AllowContinue = False

                            End If

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

                If AllowContinue Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    If RadioButtonDateRangeType_VCCTransaction.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.DateRangeType.ToString) = 1

                        _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.VirtualCreditCardTransactionEFSDetails.ToString) = VirtualCreditCardTransactionEFSDetails

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.DateRangeType.ToString) = 2

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.StartDate.ToString) = DateTimePickerForm_StartDate.GetValue
                    _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.EndDate.ToString) = DateTimePickerForm_EndDate.GetValue
                    _ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.IncludeTransactionDetail.ToString) = CheckBoxForm_IncludeTransactionDetail.Checked

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub DateTimePickerForm_StartDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerForm_StartDate.Validating

            Dim StartDate As Date? = Nothing

            StartDate = DateTimePickerForm_StartDate.GetValue

            If StartDate.HasValue AndAlso DateDiff(DateInterval.Day, StartDate.Value, Now) > 180 Then

                AdvantageFramework.WinForm.MessageBox.Show("Start date must not be more than 180 days ago.")
                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace