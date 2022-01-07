Namespace FinanceAndAccounting.Presentation

    Public Class PaymentManagerDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.PaymentManagerController = Nothing
        Protected _Printed As Boolean = False
        Protected _Processed As Boolean = False
        Protected _PaymentManagerType As String
        Protected _BankCode As String = String.Empty
        Protected _Bank As AdvantageFramework.Database.Entities.Bank = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadCheckRunIDs()

            'Dim BankCode As String = String.Empty

            SearchableComboBoxForm_CheckRunID.SelectedValue = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If SearchableComboBoxForm_Bank.HasASelectedValue Then

                    _BankCode = SearchableComboBoxForm_Bank.GetSelectedValue

                    If CheckBoxForm_IncludeExported.Checked Then

                        SearchableComboBoxForm_CheckRunID.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext)
                                                                        Where Entity.BankCode = BankCode AndAlso
                                                                        Entity.CheckRunID IsNot Nothing AndAlso
                                                                        (Entity.IsVoid = 0 OrElse Entity.IsVoid Is Nothing)
                                                                        Select Entity.CheckRunID, Entity.ExportDate).Distinct.OrderByDescending(Function(Entity) Entity.CheckRunID).ToList

                    Else

                        SearchableComboBoxForm_CheckRunID.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext)
                                                                        Where Entity.BankCode = BankCode AndAlso
                                                                        Entity.CheckRunID IsNot Nothing AndAlso
                                                                        (Entity.IsVoid = 0 OrElse Entity.IsVoid Is Nothing) AndAlso
                                                                        Entity.ExportDate Is Nothing
                                                                        Select Entity.CheckRunID, Entity.ExportDate).Distinct.OrderByDescending(Function(Entity) Entity.CheckRunID).ToList

                    End If

                Else

                    SearchableComboBoxForm_CheckRunID.DataSource = New List(Of AdvantageFramework.Database.Entities.CheckRegister)

                End If

                _Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

            End Using

        End Sub
        Private Sub ResetExportProcess()

            StepProgressBarItemProgress_Step1.State = DevExpress.XtraEditors.StepProgressBarItemState.Inactive
            StepProgressBarItemProgress_Step2.State = DevExpress.XtraEditors.StepProgressBarItemState.Inactive
            StepProgressBarItemProgress_Step3.State = DevExpress.XtraEditors.StepProgressBarItemState.Inactive
            StepProgressBarItemProgress_Step4.State = DevExpress.XtraEditors.StepProgressBarItemState.Inactive
            StepProgressBarForm_Progress.Visible = False
            _Printed = False
            _Processed = False

        End Sub
        Private Sub EnableDisableAutoFTP()

            'Dim BankCode As String = String.Empty
            'Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            If SearchableComboBoxForm_Bank.HasASelectedValue Then

                'BankCode = SearchableComboBoxForm_Bank.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    _Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                    If _Bank IsNot Nothing Then

                        If _BankCode = "FAST" Then

                            If String.IsNullOrWhiteSpace(_Bank.PaymentManagerFTPUsername) = False AndAlso String.IsNullOrWhiteSpace(_Bank.PaymentManagerFTPFolder) = False AndAlso
                                String.IsNullOrWhiteSpace(_Bank.PaymentManagerFTPAddress) = False AndAlso _Bank.PaymentManagerFTPPort.GetValueOrDefault(0) <> 0 AndAlso
                                String.IsNullOrWhiteSpace(_Bank.PaymentManagerFTPExportFolder) = False AndAlso _Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                CheckBoxForm_AutoFTP.Checked = True
                                CheckBoxForm_AutoFTP.Visible = True

                            Else

                                CheckBoxForm_AutoFTP.Checked = False
                                CheckBoxForm_AutoFTP.Visible = False

                            End If

                        Else

                            CheckBoxForm_AutoFTP.Checked = False
                            CheckBoxForm_AutoFTP.Visible = False

                        End If

                    Else

                        CheckBoxForm_AutoFTP.Checked = False
                        CheckBoxForm_AutoFTP.Visible = False

                    End If

                End Using

            Else

                CheckBoxForm_AutoFTP.Checked = False
                CheckBoxForm_AutoFTP.Visible = False

            End If

            _BankCode = SearchableComboBoxForm_Bank.GetSelectedValue

        End Sub
        Private Sub EnableDisableActions()

            'Dim BankCode As String = String.Empty

            _BankCode = SearchableComboBoxForm_Bank.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

            End Using

            ButtonItemActions_Search.Enabled = (StepProgressBarForm_Progress.Visible = False AndAlso
                SearchableComboBoxForm_Bank.HasASelectedValue AndAlso SearchableComboBoxForm_CheckRunID.HasASelectedValue)
            ButtonItemActions_Print.Enabled = (StepProgressBarForm_Progress.Visible AndAlso
                StepProgressBarItemProgress_Step1.State = DevExpress.XtraEditors.StepProgressBarItemState.Active) And Not _Printed

            'Process
            ButtonItemActions_Process.Enabled = (StepProgressBarForm_Progress.Visible AndAlso
                StepProgressBarForm_Progress.SelectedItem Is StepProgressBarItemProgress_Step2 AndAlso _Printed)
            'StepProgressBarItemProgress_Step2.State = DevExpress.XtraEditors.StepProgressBarItemState.Active AndAlso

            'Transmit
            ButtonItemActions_Transmit.Enabled = (StepProgressBarForm_Progress.Visible AndAlso _Processed AndAlso _Bank.PaymentManagerType = "FAST")
            'StepProgressBarForm_Progress.SelectedItem Is StepProgressBarItemProgress_Step3 AndAlso _Processed)
            'StepProgressBarItemProgress_Step3.State = DevExpress.XtraEditors.StepProgressBarItemState.Active AndAlso
            ButtonItemActions_Cancel.Enabled = StepProgressBarForm_Progress.Visible

            SearchableComboBoxForm_Bank.Enabled = (StepProgressBarForm_Progress.Visible = False)
            SearchableComboBoxForm_CheckRunID.Enabled = (StepProgressBarForm_Progress.Visible = False)
            CheckBoxForm_IncludeExported.Enabled = (StepProgressBarForm_Progress.Visible = False)
            CheckBoxForm_AutoFTP.Enabled = (StepProgressBarForm_Progress.Visible = False)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim PaymentManagerDialog As AdvantageFramework.FinanceAndAccounting.Presentation.PaymentManagerDialog = Nothing

            PaymentManagerDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.PaymentManagerDialog()

            ShowFormDialog = PaymentManagerDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PaymentManagerDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Search.Image = AdvantageFramework.My.Resources.InvoiceFindImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Transmit.Image = AdvantageFramework.My.Resources.InvoiceTransmitImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            SearchableComboBoxForm_Bank.SetRequired(True)
            SearchableComboBoxForm_CheckRunID.SetRequired(True)

            CheckBoxForm_AutoFTP.Checked = False
            CheckBoxForm_AutoFTP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                SearchableComboBoxForm_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList.Where(Function(Entity) Entity.PaymentManager IsNot Nothing AndAlso Entity.PaymentManager = 1).ToList
                SearchableComboBoxForm_CheckRunID.DataSource = New List(Of AdvantageFramework.Database.Entities.CheckRegister)

            End Using

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.PaymentManagerController(Me.Session)

        End Sub
        Private Sub PaymentManagerDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            If SearchableComboBoxForm_Bank.HasASelectedValue Then

                SearchableComboBoxForm_CheckRunID.Focus()

            Else

                SearchableComboBoxForm_Bank.Focus()

            End If

            EnableDisableActions()

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Search.Click

            'objects
            Dim Save As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True

            If Me.Validator Then

                Me.ShowWaitForm("Searching...")

                Try

                    _ViewModel = _Controller.Load(SearchableComboBoxForm_Bank.GetSelectedValue, SearchableComboBoxForm_CheckRunID.GetSelectedValue)

                    _PaymentManagerType = _ViewModel.Bank.PaymentManagerType

                    Select Case _PaymentManagerType

                        Case "ANCH", "FAST", "HSB1"

                        Case Else

                            ErrorMessage = "The Export Type selected in Bank Maintenance is not supported in Payment Manager (Enhanced)."

                    End Select

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        StepProgressBarForm_Progress.Visible = True

                        StepProgressBarForm_Progress.SelectNext()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    EnableDisableActions()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            Me.ShowWaitForm("Printing...")

            Try

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary("BankCode") = SearchableComboBoxForm_Bank.GetSelectedValue
                ParameterDictionary("CheckRunID") = SearchableComboBoxForm_CheckRunID.GetSelectedValue

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowForm(Me.Session, AdvantageFramework.Reporting.ReportTypes.PaymentManagerReport, ParameterDictionary, 0, String.Empty, Date.MinValue, Date.MinValue)

                If Not _Printed Then

                    StepProgressBarForm_Progress.SelectNext()

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            End Try

            Me.CloseWaitForm()

            _Printed = True

            EnableDisableActions()

        End Sub
        Private Sub ButtonItemActions_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Process.Click

            Dim ErrorMessage As String = String.Empty

            Me.ShowWaitForm("Processing...")

            Try

                If _Controller.ProcessExportFile(_ViewModel, ErrorMessage) Then

                    StepProgressBarForm_Progress.SelectNext()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            End Try

            Me.CloseWaitForm()

            _Processed = True

            EnableDisableActions()

            If _Printed AndAlso _Processed AndAlso CheckBoxForm_AutoFTP.Checked Then

                ButtonItemActions_Transmit.RaiseClick()

            End If

            If _Printed AndAlso _Processed AndAlso _Bank.PaymentManagerType = "HSB1" Then

                ResetExportProcess()

                SearchableComboBoxForm_CheckRunID.SelectedValue = Nothing

                LoadCheckRunIDs()

                EnableDisableActions()

                AdvantageFramework.WinForm.MessageBox.Show("Export complete. Your file is located in your Payment Manager File Output Directory.")

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            ResetExportProcess()

            EnableDisableActions()

        End Sub
        Private Sub SearchableComboBoxForm_Bank_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Bank.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadCheckRunIDs()

            End If

            EnableDisableAutoFTP()

            EnableDisableActions()

        End Sub
        Private Sub SearchableComboBoxForm_CheckRunID_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_CheckRunID.EditValueChanged

            EnableDisableActions()

        End Sub
        Private Sub CheckBoxForm_IncludeExported_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_IncludeExported.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadCheckRunIDs()

            End If

            EnableDisableActions()

        End Sub

        Private Sub ButtonItemActions_Transmit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Transmit.Click

            Dim TransmittedFile As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Updated As Boolean

            _Processed = _Processed

            If _Processed Then

                Me.ShowWaitForm("Transmiting...")

                Try

                    If _Controller.TransmitExportFile(_ViewModel, ErrorMessage) Then

                        TransmittedFile = True

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                If TransmittedFile Then

                    StepProgressBarForm_Progress.SelectNext()

                    AdvantageFramework.WinForm.MessageBox.Show("Transmit complete.")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()
                        DbContext.Configuration.AutoDetectChangesEnabled = False

                        Updated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CHECK_REGISTER SET EXPORT_DATE = '{0}' WHERE CHECK_RUN_ID = '{1}'", DateTime.Now, SearchableComboBoxForm_CheckRunID.SelectedValue))

                    End Using

                    If Updated Then

                        ResetExportProcess()

                        SearchableComboBoxForm_CheckRunID.SelectedValue = Nothing

                        LoadCheckRunIDs()

                        EnableDisableActions()
                    Else

                        ResetExportProcess()

                        EnableDisableActions()

                        AdvantageFramework.WinForm.MessageBox.Show("Unable to update the EFILE_DATE in CHECK_REGISTER.")

                    End If

                Else

                    EnableDisableActions()

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Transmit failed. Please Process the file before transmitting.")

            End If

            Me.CloseWaitForm()

        End Sub

#End Region

#End Region

    End Class

End Namespace
