Namespace Billing.Presentation

    Public Class BillingCommandCenterMediaBillingDialog

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

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            DateTimePickerForm_InvoiceDate.ByPassUserEntryChanged = True
            ComboBoxForm_PostingPeriod.ByPassUserEntryChanged = True
            Me.ByPassUserEntryChanged = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef InvoiceDate As Date, ByRef PostPeriodCode As String) As Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterMediaBillingDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingDialog = Nothing

            BillingCommandCenterMediaBillingDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingDialog()

            ShowFormDialog = BillingCommandCenterMediaBillingDialog.ShowDialog()

            InvoiceDate = BillingCommandCenterMediaBillingDialog.DateTimePickerForm_InvoiceDate.GetValue
            PostPeriodCode = BillingCommandCenterMediaBillingDialog.ComboBoxForm_PostingPeriod.GetSelectedValue

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterMediaBillingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            DateTimePickerForm_InvoiceDate.SetRequired(True)
            ComboBoxForm_PostingPeriod.SetRequired(True)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_PostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).ToList

            End Using

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, Session.UserCode)

                If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                    DateTimePickerForm_InvoiceDate.Value = BillingCommandCenterInvoiceDatePostPeriod.InvoiceDate
                    ComboBoxForm_PostingPeriod.SelectedValue = BillingCommandCenterInvoiceDatePostPeriod.PostPeriodCode

                End If

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

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