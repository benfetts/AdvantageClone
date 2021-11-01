Namespace Maintenance.Accounting.Presentation

    Public Class ClientDiscountEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountController = Nothing
        Protected _ClientDiscountCode As String = String.Empty

#End Region

#Region " Properties "

        Private ReadOnly Property ClientDiscountCode As String
            Get
                ClientDiscountCode = _ClientDiscountCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ClientDiscountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientDiscountCode = ClientDiscountCode

        End Sub
        Private Sub SetupViewModel()

            ClientDiscountControlForm_ClientDiscount.LoadControl(_ClientDiscountCode)

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Visible = ClientDiscountControlForm_ClientDiscount.ViewModel.AddEnabled
            ButtonItemActions_Update.Visible = ClientDiscountControlForm_ClientDiscount.ViewModel.UpdateEnabled

            ButtonItemDetails_Cancel.Enabled = ClientDiscountControlForm_ClientDiscount.ViewModel.ClientDiscountExclusions_CancelEnabled
            ButtonItemDetails_Delete.Enabled = ClientDiscountControlForm_ClientDiscount.ViewModel.ClientDiscountExclusions_DeleteEnabled

        End Sub
        Private Sub SetControlPropertySettings()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientDiscountCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim DiscountEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.ClientDiscountEditDialog = Nothing

            DiscountEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.ClientDiscountEditDialog(ClientDiscountCode)

            ShowFormDialog = DiscountEditDialog.ShowDialog()

            ClientDiscountCode = DiscountEditDialog.ClientDiscountCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DiscountEditDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountController(Me.Session)

        End Sub
        Private Sub DiscountEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            SetupViewModel()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    If ClientDiscountControlForm_ClientDiscount.Add() Then

                        _ClientDiscountCode = ClientDiscountControlForm_ClientDiscount.ViewModel.ClientDiscount.Code

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    ClientDiscountControlForm_ClientDiscount.Save()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            ClientDiscountControlForm_ClientDiscount.DiscountExclusions_CancelNewItemRow()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            ClientDiscountControlForm_ClientDiscount.DiscountExclusions_Delete()

            RefreshViewModel()

        End Sub
        Private Sub ClientDiscountControlForm_ClientDiscount_Exclusions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientDiscountControlForm_ClientDiscount.Exclusions_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub ClientDiscountControlForm_ClientDiscount_Exclusions_FocusedRowChangedEvent(sender As Object, e As EventArgs) Handles ClientDiscountControlForm_ClientDiscount.Exclusions_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace