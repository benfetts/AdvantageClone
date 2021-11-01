Namespace Billing.Presentation

    Public Class BillingCommandCenterBatchEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _BatchName As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property BillingCommandCenterID As Integer
            Get
                BillingCommandCenterID = _BillingCommandCenterID
            End Get
        End Property
        Private ReadOnly Property BatchName As String
            Get
                BatchName = _BatchName
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, Optional ByVal BatchName As String = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID
            _BatchName = BatchName

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef BillingCommandCenterID As Integer, Optional ByRef BatchName As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterBatchEditDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterBatchEditDialog = Nothing

            BillingCommandCenterBatchEditDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterBatchEditDialog(BillingCommandCenterID, BatchName)

            ShowFormDialog = BillingCommandCenterBatchEditDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                BillingCommandCenterID = BillingCommandCenterBatchEditDialog.BillingCommandCenterID

                BatchName = BillingCommandCenterBatchEditDialog.BatchName

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterBatchNewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxForm_BatchName.ByPassUserEntryChanged = True

            If _BillingCommandCenterID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

                Me.Text = "Edit Batch"

                TextBoxForm_BatchName.Text = _BatchName

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

                Me.Text = "Add Batch"

            End If

            Using BCCDbContext = New AdvantageFramework.BillingCommandCenter.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_BatchName.SetPropertySettings(AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter.Properties.BatchName)

                If _BillingCommandCenterID <> 0 AndAlso AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID) Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("The batch you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            End Using

        End Sub
        Private Sub MediaPlanNewDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            TextBoxForm_BatchName.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim BillingCommandCenterID As Nullable(Of Integer) = Nothing

            If Me.Validator Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding...")

                Try

                    Using BCCDbContext = New AdvantageFramework.BillingCommandCenter.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.BillingCommandCenter.CreateNewBatch(BCCDbContext, TextBoxForm_BatchName.Text.Trim, BillingCommandCenterID, ErrorMessage)

                        If ErrorMessage = "" Then

                            _BillingCommandCenterID = BillingCommandCenterID

                            Me.ClearChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End Using

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
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
        Private Sub ButtonForm_Update_Click(sender As Object, e As EventArgs) Handles ButtonForm_Update.Click

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            If Me.Validator Then

                Using BCCDbContext = New AdvantageFramework.BillingCommandCenter.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        BillingCommandCenter.BatchName = TextBoxForm_BatchName.GetText

                        If AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Update(BCCDbContext, BillingCommandCenter) Then

                            _BatchName = BillingCommandCenter.BatchName

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The batch you are trying to edit does not exist anymore.")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()

                    End If

                End Using

            End If

        End Sub
        Private Sub TextBoxForm_BatchName_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TextBoxForm_BatchName.KeyPress

            If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso e.KeyChar <> Convert.ToChar(Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
