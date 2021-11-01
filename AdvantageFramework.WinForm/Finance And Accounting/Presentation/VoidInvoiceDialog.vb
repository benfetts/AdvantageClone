Namespace FinanceAndAccounting.Presentation

    Public Class VoidInvoiceDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PostPeriodCode As String = Nothing
        Private _VoidComment As String = Nothing
        Private _InvoiceNumber As Integer = 0
        Private _ClientName As String = Nothing
        Private _InvoicePostPeriodCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PostPeriodCode As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
        End Property
        Private ReadOnly Property VoidComment As String
            Get
                VoidComment = _VoidComment
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal InvoiceNumber As Integer, ByVal ClientName As String, InvoicePostPeriodCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _InvoiceNumber = InvoiceNumber
            _ClientName = ClientName
            _InvoicePostPeriodCode = InvoicePostPeriodCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef PostPeriodCode As String, ByRef VoidComment As String, ByVal InvoiceNumber As Integer, ByVal ClientName As String, ByVal InvoicePostPeriodCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim VoidInvoicesDialog As AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoiceDialog = Nothing

            VoidInvoicesDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoiceDialog(InvoiceNumber, ClientName, InvoicePostPeriodCode)

            ShowFormDialog = VoidInvoicesDialog.ShowDialog()

            PostPeriodCode = VoidInvoicesDialog.PostPeriodCode
            VoidComment = VoidInvoicesDialog.VoidComment

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VoidInvoicesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxForm_PostingPeriod.SetRequired(True)
            ComboBoxForm_PostingPeriod.ByPassUserEntryChanged = True

            TextBoxForm_Comment.ByPassUserEntryChanged = True

            Me.ByPassUserEntryChanged = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_PostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadActiveARPostPeriodsFromPostPeriodAndAfter(DbContext, _InvoicePostPeriodCode).OrderByDescending(Function(Entity) Entity.Code).ToList

                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

                If PostPeriod IsNot Nothing Then

                    ComboBoxForm_PostingPeriod.SelectedValue = PostPeriod.Code

                End If

            End Using

            TextBoxForm_InvoiceNumber.Text = _InvoiceNumber
            TextBoxForm_Client.Text = _ClientName
            TextBoxForm_InvoicePostPeriod.Text = _InvoicePostPeriodCode

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_PostingPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_PostingPeriod.SelectedIndexChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ComboBoxForm_PostingPeriod.HasASelectedValue AndAlso ComboBoxForm_PostingPeriod.GetSelectedValue > _InvoicePostPeriodCode Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have selected period " & ComboBoxForm_PostingPeriod.GetSelectedValue & " and the invoice was posted in period " & _InvoicePostPeriodCode & ".  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        ComboBoxForm_PostingPeriod.SelectedValue = _InvoicePostPeriodCode

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _PostPeriodCode = ComboBoxForm_PostingPeriod.GetSelectedValue
                _VoidComment = TextBoxForm_Comment.Text

                If AdvantageFramework.WinForm.MessageBox.Show("Is this the correct invoice number and posting period?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        End Sub

#End Region

#End Region

    End Class

End Namespace
