Namespace Maintenance.Accounting.Presentation

    Public Class AccruePaidTimeOffDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()


        End Sub
        Private Sub LoadLastAccrueDate()

            Dim TimeRuleLog As AdvantageFramework.Database.Entities.TimeRuleLog = Nothing
            Dim DefaultLastAccrualText As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TimeRuleLog = AdvantageFramework.Database.Procedures.TimeRuleLog.LoadLastTimeLog(DbContext)

                If TimeRuleLog IsNot Nothing Then

                    If TimeRuleLog.ProcessMonth = 12 Then
                        ComboBoxForm_Month.SelectedValue = Convert.ToInt64(1)
                        NumericInputForm_Year.Value = CInt(TimeRuleLog.ProcessYear + 1)
                    Else
                        ComboBoxForm_Month.SelectedValue = Convert.ToInt64(TimeRuleLog.ProcessMonth + 1)
                        NumericInputForm_Year.Value = CInt(TimeRuleLog.ProcessYear)
                    End If

                    LabelForm_AccrualsNeverProcessed.Visible = False
                    LabelForm_LastAccrual.Visible = True

                    DefaultLastAccrualText = "Accruals were last processed for MM/YYYY by 'UNAME' on MM/DD/YYYY"

                    LabelForm_LastAccrual.Text = DefaultLastAccrualText.Replace("MM/YYYY", TimeRuleLog.ProcessMonth & "/" & TimeRuleLog.ProcessYear).Replace("UNAME", TimeRuleLog.ProcessedBy).Replace("MM/DD/YYYY", TimeRuleLog.DatetimeStamp.ToShortDateString)

                Else

                    LabelForm_AccrualsNeverProcessed.Visible = True
                    LabelForm_LastAccrual.Visible = False

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim AccruePaidTimeOffDialog As AdvantageFramework.Maintenance.Accounting.Presentation.AccruePaidTimeOffDialog = Nothing

            AccruePaidTimeOffDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.AccruePaidTimeOffDialog()

            ShowFormDialog = AccruePaidTimeOffDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccruePaidTimeOffDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                NumericInputForm_Year.SetFormat("0000")

                ComboBoxForm_Month.ByPassUserEntryChanged = True
                NumericInputForm_Year.ByPassUserEntryChanged = True

                ComboBoxForm_Month.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

                ComboBoxForm_Month.SelectedValue = Convert.ToInt64(System.DateTime.Today.Month)

                NumericInputForm_Year.Value = System.DateTime.Today.Year

                LoadLastAccrueDate()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Process_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Process.Click

            'objects
            Dim ProcessMonth As Integer = Nothing
            Dim ProcessYear As Integer = Nothing
            Dim ReturnValue As Integer = Nothing
            Dim Process As Boolean = True

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ProcessMonth = CInt(ComboBoxForm_Month.GetSelectedValue)

                    ProcessYear = CInt(NumericInputForm_Year.Value)

                    If (From Entity In AdvantageFramework.Database.Procedures.TimeRuleLog.Load(DbContext).ToList
                        Where Entity.ProcessMonth = ProcessMonth AndAlso
                              Entity.ProcessYear = ProcessYear
                        Select Entity).Any Then

                        If AdvantageFramework.WinForm.MessageBox.Show("You have chosen a month that has already been processed. Repeating this process can lead to unintended results. Are you sure you wish to continue?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.Cancel Then

                            Process = False

                        End If

                    End If

                    If Process Then

                        AdvantageFramework.Database.Procedures.EmployeeView.ProcessPaidTimeOffAccruals(DbContext, ProcessYear, ProcessMonth, ReturnValue)

                        If ReturnValue = 0 Then

                            AdvantageFramework.WinForm.MessageBox.Show("Accruals have been successfully processed for the selected month.")

                            Me.Close()
                            Me.DialogResult = Windows.Forms.DialogResult.OK

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Process Failed!")

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace