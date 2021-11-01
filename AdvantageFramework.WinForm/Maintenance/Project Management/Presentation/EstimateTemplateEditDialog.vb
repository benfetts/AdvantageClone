Namespace Maintenance.ProjectManagement.Presentation

    Public Class EstimateTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EstimateTemplateCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EstimateTemplateCode As String
            Get
                EstimateTemplateCode = _EstimateTemplateCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef EstimateTemplateCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EstimateTemplateCode = EstimateTemplateCode

        End Sub
        Private Sub EnableOrDisableActions()

            If EstimateTemplateControlForm_EstimateTemplate.Enabled Then

                ButtonItemActions_Add.Enabled = True
                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged

                If EstimateTemplateControlForm_EstimateTemplate.DetailsTabSelected Then

                    RibbonBarOptions_Details.Visible = True
                    ButtonItemDetails_Copy.Enabled = True
                    ButtonItemDetails_Cancel.Enabled = EstimateTemplateControlForm_EstimateTemplate.EstimateTemplateDetailIsNewItemRow(EstimateTemplateControlForm_EstimateTemplate.EstimateTemplateDetailFocusedRowHandle)
                    ButtonItemDetails_Delete.Enabled = EstimateTemplateControlForm_EstimateTemplate.EstimateTemplateDetailHasRows
                    RibbonBarOptions_Text.Visible = False

                ElseIf EstimateTemplateControlForm_EstimateTemplate.DefaultCommentsTabSelected Then

                    RibbonBarOptions_Details.Visible = False
                    ButtonItemDetails_Copy.Enabled = False
                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = False
                    RibbonBarOptions_Text.Visible = True

                End If

            Else

                ButtonItemActions_Add.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                RibbonBarOptions_Details.Visible = False
                ButtonItemDetails_Copy.Enabled = False
                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                RibbonBarOptions_Text.Visible = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef EstimateTemplateCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimateTemplateEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplateEditDialog = Nothing

            EstimateTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplateEditDialog(EstimateTemplateCode)

            ShowFormDialog = EstimateTemplateEditDialog.ShowDialog()

            EstimateTemplateCode = EstimateTemplateEditDialog.EstimateTemplateCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.CloseButtonVisible = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            If _EstimateTemplateCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If EstimateTemplateControlForm_EstimateTemplate.LoadControl(EstimateTemplateCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The estimate template you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub EstimateTemplateEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EstimateTemplateEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EstimateTemplateCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If EstimateTemplateControlForm_EstimateTemplate.Insert(EstimateTemplateCode) Then

                        _EstimateTemplateCode = EstimateTemplateCode

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If EstimateTemplateControlForm_EstimateTemplate.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            EstimateTemplateControlForm_EstimateTemplate.DeleteEstimateTemplateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Copy.Click

            EstimateTemplateControlForm_EstimateTemplate.CopyDetails()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            EstimateTemplateControlForm_EstimateTemplate.CancelNewItemRowEstimateTemplateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(sender As Object, e As EventArgs) Handles ButtonItemText_CheckSpelling.Click

            EstimateTemplateControlForm_EstimateTemplate.CheckSpelling()

        End Sub
        Private Sub EstimateTemplateControlForm_EstimateTemplate_SelectedTabChangedEvent() Handles EstimateTemplateControlForm_EstimateTemplate.SelectedTabChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EstimateTemplateControlForm_EstimateTemplate_EstimateTemplateDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EstimateTemplateControlForm_EstimateTemplate.EstimateTemplateDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EstimateTemplateControlForm_EstimateTemplate_EstimateTemplateDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles EstimateTemplateControlForm_EstimateTemplate.EstimateTemplateDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region
        
    End Class

End Namespace