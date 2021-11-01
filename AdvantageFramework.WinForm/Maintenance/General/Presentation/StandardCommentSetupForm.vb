Namespace Maintenance.General.Presentation

    Public Class StandardCommentSetupForm

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

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim StandardCommentsList As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                StandardCommentsList = AdvantageFramework.Database.Procedures.StandardComment.Load(DbContext).Include("Office").Include("Client").Include("Division").Include("Product").Include("Vendor").ToList

                DataGridViewLeftSection_Comments.DataSource = StandardCommentsList
                DataGridViewLeftSection_ExportStandardComments.DataSource = StandardCommentsList

                DataGridViewLeftSection_Comments.CurrentView.BestFitColumns()
                DataGridViewLeftSection_ExportStandardComments.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            StandardCommentControlRightSection_StandardComment.ClearControl()

            StandardCommentControlRightSection_StandardComment.Enabled = DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow

            If StandardCommentControlRightSection_StandardComment.Enabled Then

                StandardCommentControlRightSection_StandardComment.Enabled = StandardCommentControlRightSection_StandardComment.LoadControl(DataGridViewLeftSection_Comments.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            StandardCommentControlRightSection_StandardComment.Enabled = (DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow AndAlso StandardCommentControlRightSection_StandardComment.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            StandardCommentControlRightSection_StandardComment.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim StandardCommentSetupForm As AdvantageFramework.Maintenance.General.Presentation.StandardCommentSetupForm = Nothing

            StandardCommentSetupForm = New AdvantageFramework.Maintenance.General.Presentation.StandardCommentSetupForm()

            StandardCommentSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub StandardCommentSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_Comments.MultiSelect = False

            DataGridViewLeftSection_Comments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.Default
            DataGridViewLeftSection_ExportStandardComments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.StandardComment_ExportInfo

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub StandardCommentSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub StandardCommentSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub StandardCommentSetupForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Comments.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        StandardCommentControlRightSection_StandardComment.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Comments.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a standard comment to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Comments.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        StandardCommentControlRightSection_StandardComment.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a standard comment to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim CommentID As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.General.Presentation.StandardCommentEditDialog.ShowFormDialog(CommentID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Comments.SelectRow(CommentID)

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Comments_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Comments.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Comments_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Comments.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            DataGridViewLeftSection_ExportStandardComments.CurrentView.AFActiveFilterString = DataGridViewLeftSection_Comments.CurrentView.AFActiveFilterString
            DataGridViewLeftSection_ExportStandardComments.CurrentView.ApplyFindFilter(DataGridViewLeftSection_Comments.CurrentView.FindFilterText)

            DataGridViewLeftSection_ExportStandardComments.CurrentView.BestFitColumns()

            DataGridViewLeftSection_ExportStandardComments.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            Dim CommentID As Integer = Nothing

            If DataGridViewLeftSection_Comments.HasOnlyOneSelectedRow Then

                CommentID = DataGridViewLeftSection_Comments.GetFirstSelectedRowBookmarkValue

                DataGridViewLeftSection_ExportStandardComments.CurrentView.AFActiveFilterString = "[ID] = " & CommentID

                DataGridViewLeftSection_ExportStandardComments.CurrentView.BestFitColumns()

                DataGridViewLeftSection_ExportStandardComments.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Private Sub StandardCommentControlRightSection_StandardComment_CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles StandardCommentControlRightSection_StandardComment.CommentGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub StandardCommentControlRightSection_StandardComment_CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles StandardCommentControlRightSection_StandardComment.CommentLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf StandardCommentControlRightSection_StandardComment.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(StandardCommentControlRightSection_StandardComment.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    StandardCommentControlRightSection_StandardComment.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Comments.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
