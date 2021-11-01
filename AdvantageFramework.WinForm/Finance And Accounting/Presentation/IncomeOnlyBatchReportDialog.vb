Namespace FinanceAndAccounting.Presentation

    Public Class IncomeOnlyBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _From As Date = Nothing
        Private _To As Date = Nothing
        Private _UserCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property [From] As Date
            Get
                [From] = _From
            End Get
        End Property
        Private ReadOnly Property [To] As Date
            Get
                [To] = _To
            End Get
        End Property
        Private ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef [From] As Date, ByRef [To] As Date, ByRef UserCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _From = [From]
            _To = [To]
            _UserCode = UserCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef [From] As Date, ByRef [To] As Date, ByRef UserCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim IncomeOnlyBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyBatchReportDialog = Nothing

            IncomeOnlyBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyBatchReportDialog([From], [To], UserCode)

            ShowFormDialog = IncomeOnlyBatchReportDialog.ShowDialog()

            [From] = IncomeOnlyBatchReportDialog.From
            [To] = IncomeOnlyBatchReportDialog.To
            UserCode = IncomeOnlyBatchReportDialog.UserCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub IncomeOnlyBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.ValueObject = Nothing
            DateTimePickerForm_To.ValueObject = Nothing

            ComboBoxForm_User.SetRequired(True)
            DateTimePickerForm_From.SetRequired(True)
            DateTimePickerForm_To.SetRequired(True)

            DateTimePickerForm_From.Value = System.DateTime.Today
            DateTimePickerForm_To.Value = System.DateTime.Today

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).OrderBy(Function(U) U.UserCode)

            End Using

            ComboBoxForm_User.SelectedValue = Me.Session.UserCode

            Try

                If ComboBoxForm_User.HasASelectedValue = False Then

                    For I = 0 To (ComboBoxForm_User.Items.Count - 1)

                        If ComboBoxForm_User.Items(I).Name.ToString.ToUpper = Me.Session.UserCode.ToUpper Then

                            ComboBoxForm_User.SelectedValue = ComboBoxForm_User.Items(I).Name
                            Exit For

                        End If

                    Next

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Ok.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _UserCode = ComboBoxForm_User.GetSelectedValue
                _From = DateTimePickerForm_From.Value.Date
                _To = DateTimePickerForm_To.Value.Date

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
