Namespace FinanceAndAccounting.Presentation

    Public Class IRS1099ProcessingTransmitDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PaymentYear As String = Nothing
        'Private _IsPriorYear As Boolean = False
        Private _IsLastFiling As Boolean = False
        Private _IsTestFile As Boolean = False
        Private _EmployeeContact As String = Nothing
        Private _FederalTaxID As String = Nothing
        Private _IRSTransmitterControlCode As String = Nothing
        Private _CombinedFederalStateFiler As Boolean = False
        Private _IsCorrectionFile As Boolean = False
        Private _OutputPath As String = Nothing
        Private _Form1099Type As AdvantageFramework.Exporting.Form1099 = Exporting.Methods.Form1099.MISC

#End Region

#Region " Properties "

        Public ReadOnly Property PaymentYear As String
            Get
                PaymentYear = _PaymentYear
            End Get
        End Property
        'Public ReadOnly Property IsPriorYear As Boolean
        '    Get
        '        IsPriorYear = _IsPriorYear
        '    End Get
        'End Property
        Public ReadOnly Property IsLastFiling As Boolean
            Get
                IsLastFiling = _IsLastFiling
            End Get
        End Property
        Public ReadOnly Property IsTestFile As Boolean
            Get
                IsTestFile = _IsTestFile
            End Get
        End Property
        Public ReadOnly Property EmployeeContact As String
            Get
                EmployeeContact = _EmployeeContact
            End Get
        End Property
        Public ReadOnly Property FederalTaxID As String
            Get
                FederalTaxID = _FederalTaxID
            End Get
        End Property
        Public ReadOnly Property IRSTransmitterControlCode As String
            Get
                IRSTransmitterControlCode = _IRSTransmitterControlCode
            End Get
        End Property
        Public ReadOnly Property CombinedFederalStateFiler As Boolean
            Get
                CombinedFederalStateFiler = _CombinedFederalStateFiler
            End Get
        End Property
        Public ReadOnly Property IsCorrectionFile As Boolean
            Get
                IsCorrectionFile = _IsCorrectionFile
            End Get
        End Property
        Public ReadOnly Property OutputPath As String
            Get
                OutputPath = _OutputPath
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal PaymentYear As String, ByVal IsLastFiling As Boolean, ByVal IsTestFile As Boolean, ByVal EmployeeContact As String,
                        ByVal FederalTaxID As String, ByVal IRSTransmitterControlCode As String, ByVal CombinedFederalStateFiler As Boolean, ByVal IsCorrectionFile As Boolean, ByVal OutputPath As String,
                        ByVal Form1099Type As AdvantageFramework.Exporting.Form1099)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _PaymentYear = PaymentYear
            '_IsPriorYear = IsPriorYear
            _IsLastFiling = IsLastFiling
            _IsTestFile = IsTestFile
            _EmployeeContact = EmployeeContact
            _FederalTaxID = FederalTaxID
            _IRSTransmitterControlCode = IRSTransmitterControlCode
            _CombinedFederalStateFiler = CombinedFederalStateFiler
            _IsCorrectionFile = IsCorrectionFile
            _OutputPath = OutputPath
            _Form1099Type = Form1099Type

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef PaymentYear As String, 'ByRef IsPriorYear As Boolean, 
                                              ByRef IsLastFiling As Boolean,
                                              ByRef IsTestFile As Boolean, ByRef EmployeeContact As String, ByRef FederalTaxID As String,
                                              ByRef IRSTransmitterControlCode As String, ByRef CombinedFederalStateFiler As Boolean,
                                              ByRef IsCorrectionFile As Boolean, ByRef OutputPath As String,
                                              ByVal Form1099Type As AdvantageFramework.Exporting.Form1099) As Windows.Forms.DialogResult

            'objects
            Dim IRS1099ProcessingTransmitDialog As AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingTransmitDialog = Nothing

            IRS1099ProcessingTransmitDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingTransmitDialog(PaymentYear, IsLastFiling, IsTestFile,
                                                                                                                                       EmployeeContact, FederalTaxID, IRSTransmitterControlCode,
                                                                                                                                       CombinedFederalStateFiler, IsCorrectionFile, OutputPath, Form1099Type)

            ShowFormDialog = IRS1099ProcessingTransmitDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                PaymentYear = IRS1099ProcessingTransmitDialog.PaymentYear
                'IsPriorYear = IRS1099ProcessingTransmitDialog.IsPriorYear
                IsLastFiling = IRS1099ProcessingTransmitDialog.IsLastFiling
                IsTestFile = IRS1099ProcessingTransmitDialog.IsTestFile
                EmployeeContact = IRS1099ProcessingTransmitDialog.EmployeeContact
                FederalTaxID = IRS1099ProcessingTransmitDialog.FederalTaxID
                IRSTransmitterControlCode = IRS1099ProcessingTransmitDialog.IRSTransmitterControlCode
                CombinedFederalStateFiler = IRS1099ProcessingTransmitDialog.CombinedFederalStateFiler
                IsCorrectionFile = IRS1099ProcessingTransmitDialog.IsCorrectionFile
                OutputPath = IRS1099ProcessingTransmitDialog.OutputPath

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub IRS1099ProcessingTransmitDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Me.ByPassUserEntryChanged = True

            NumericInputForm_PaymentYear.ByPassUserEntryChanged = True
            NumericInputForm_PaymentYear.Properties.MinValue = 2020
            NumericInputForm_PaymentYear.SetRequired(True)
            NumericInputForm_PaymentYear.Properties.MaxLength = 4

            TextBoxForm_FederalTaxID.ByPassUserEntryChanged = True
            TextBoxForm_FederalTaxID.SetDefaultPropertySettings(9, "Federal Tax ID")
            TextBoxForm_FederalTaxID.SetRequired(True)

            TextBoxForm_IRSTCC.ByPassUserEntryChanged = True
            TextBoxForm_IRSTCC.SetDefaultPropertySettings(5, "IRS Transmitter Control Code")
            TextBoxForm_IRSTCC.SetRequired(True)

            SearchableComboBoxForm_Employee.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Employee.SetPropertySettings(AdvantageFramework.Database.Views.Employee.Properties.Code)
            SearchableComboBoxForm_Employee.SetRequired(True)

            TextBoxForm_OutputPath.ByPassUserEntryChanged = True
            TextBoxForm_OutputPath.SetDefaultPropertySettings(DisplayName:="Output Directory")
            TextBoxForm_OutputPath.SetRequired(True)

            'CheckBoxForm_PriorYear.ByPassUserEntryChanged = True
            If _Form1099Type = Exporting.Methods.Form1099.MISC Then

                CheckBoxForm_CombinedFederalStateFiling.Enabled = True

            ElseIf _Form1099Type = Exporting.Methods.Form1099.NEC Then

                CheckBoxForm_CombinedFederalStateFiling.Enabled = False

            End If

            CheckBoxForm_CombinedFederalStateFiling.ByPassUserEntryChanged = True
            CheckBoxForm_LastFiling.ByPassUserEntryChanged = True
            CheckBoxForm_TestFile.ByPassUserEntryChanged = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxForm_Employee.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                              Where Entity.WorkPhoneNumber IsNot Nothing
                                                              Select Entity).ToList


                Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.FEDERAL_TAX_ID.ToString)

                    If Setting IsNot Nothing Then

                        TextBoxForm_FederalTaxID.Text = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Setting.Value)

                    End If

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.IRS_TCC.ToString)

                    If Setting IsNot Nothing Then

                        TextBoxForm_IRSTCC.Text = Setting.Value

                    End If

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_CONTACT.ToString)

                    If Setting IsNot Nothing Then

                        SearchableComboBoxForm_Employee.SelectedValue = Setting.Value

                    End If

                    If CheckBoxForm_CombinedFederalStateFiling.Enabled Then

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_CFSF.ToString)

                        If Setting IsNot Nothing Then

                            CheckBoxForm_CombinedFederalStateFiling.Checked = Setting.Value

                        End If

                    End If

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        TextBoxForm_OutputPath.Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "1099"
                        TextBoxForm_OutputPath.Enabled = False

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(TextBoxForm_FederalTaxID.Text).Length <> 9 Then

                    AdvantageFramework.WinForm.MessageBox.Show("Federal Tax ID must be nine digits in length.")

                ElseIf AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(TextBoxForm_IRSTCC.Text).Length <> 5 Then

                    AdvantageFramework.WinForm.MessageBox.Show("IRS Transmitter Control Code must be five in length.")

                Else

                    _PaymentYear = NumericInputForm_PaymentYear.GetValue
                    '_IsPriorYear = CheckBoxForm_PriorYear.Checked
                    _IsLastFiling = CheckBoxForm_LastFiling.Checked
                    _IsTestFile = CheckBoxForm_TestFile.Checked
                    _EmployeeContact = SearchableComboBoxForm_Employee.SelectedValue
                    _FederalTaxID = TextBoxForm_FederalTaxID.Text
                    _IRSTransmitterControlCode = TextBoxForm_IRSTCC.Text
                    _CombinedFederalStateFiler = CheckBoxForm_CombinedFederalStateFiling.Checked
                    _IsCorrectionFile = CheckBoxForm_IsCorrectionFile.Checked
                    _OutputPath = TextBoxForm_OutputPath.Text

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

#End Region

#End Region

    End Class

End Namespace