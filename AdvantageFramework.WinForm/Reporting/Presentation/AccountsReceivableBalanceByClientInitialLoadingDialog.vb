Namespace Reporting.Presentation

    Public Class AccountsReceivableBalanceByClientInitialLoadingDialog

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
            Dim AccountsReceivableBalanceByClientInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.AccountsReceivableBalanceByClientInitialLoadingDialog = Nothing

            AccountsReceivableBalanceByClientInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.AccountsReceivableBalanceByClientInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = AccountsReceivableBalanceByClientInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = AccountsReceivableBalanceByClientInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsReceivableBalanceByClientInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_EndingPostPeriod.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)

                Try

                    ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.EndingPostPeriodCode.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.EndingPostPeriodCode.ToString)) = False Then

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.EndingPostPeriodCode.ToString)

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.RecordSourceID.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.RecordSourceID.ToString)) = False Then

                    Try

                        ComboBoxForm_RecordSource.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString)

                    Catch ex As Exception
                        ComboBoxForm_RecordSource.SelectedValue = Nothing
                    End Try

                End If

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

                _ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.GetSelectedValue

                If ComboBoxForm_RecordSource.HasASelectedValue Then

                    _ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.RecordSourceID.ToString) = ComboBoxForm_RecordSource.GetSelectedValue

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.RecordSourceID.ToString) = 0

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
