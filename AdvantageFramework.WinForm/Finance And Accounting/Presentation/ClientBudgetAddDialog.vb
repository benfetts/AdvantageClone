Namespace FinanceAndAccounting.Presentation

    Public Class ClientBudgetAddDialog

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

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As Windows.Forms.DialogResult

            'objects
            Dim ClientBudgetAddDialog As FinanceAndAccounting.Presentation.ClientBudgetAddDialog = Nothing

            ClientBudgetAddDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientBudgetAddDialog()

            ShowFormDialog = ClientBudgetAddDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientBudgetAddDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Budget.Properties.Code)
                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Budget.Properties.Description)

            End Using

            SearchableComboBoxForm_Employee.SetRequired(True)
            SearchableComboBoxBudgetPeriod_FromPostPeriod.SetRequired(True)
            SearchableComboBoxBudgetPeriod_ToPostPeriod.SetRequired(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim Budget As AdvantageFramework.Database.Entities.Budget = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Budget = New AdvantageFramework.Database.Entities.Budget
                    Budget.DbContext = DbContext

                    'Inserted = AdvantageFramework.Database.Procedures.Budget.Insert(DbContext, Budget)

                End Using

                If Inserted Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

                Me.CloseWaitForm()

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