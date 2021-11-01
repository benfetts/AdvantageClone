Namespace Media.Presentation

    Public Class MediaPlanDetailChangeLogDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan
            _MediaPlanEstimate = MediaPlanEstimate

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim MediaPlanEstimateChangeLogs As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog) = Nothing

            MediaPlanEstimateChangeLogs = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog)

            If _MediaPlanEstimate IsNot Nothing Then

                For Each MPDCL In _MediaPlanEstimate.MediaPlanDetailChangeLogs.ToList

                    MediaPlanEstimateChangeLogs.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog(_MediaPlan, _MediaPlanEstimate, MPDCL))

                Next

            Else

                For Each MPE In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                    For Each MPDCL In MPE.MediaPlanDetailChangeLogs.ToList

                        MediaPlanEstimateChangeLogs.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog(_MediaPlan, MPE, MPDCL))

                    Next

                Next

            End If

            DataGridViewForm_ChangeLogs.DataSource = MediaPlanEstimateChangeLogs

            If _MediaPlanEstimate IsNot Nothing Then

                DataGridViewForm_ChangeLogs.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog.Properties.Estimate.ToString)

            End If

            DataGridViewForm_ChangeLogs.CurrentView.BestFitColumns()

        End Sub
        Private Sub Save()

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim MediaPlanEstimateChangeLogs As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog) = Nothing
            Dim MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanEstimateChangeLogs = DataGridViewForm_ChangeLogs.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateChangeLog).ToList

                If _MediaPlanEstimate IsNot Nothing Then

                    For Each MPECL In MediaPlanEstimateChangeLogs

                        Try

                            MediaPlanDetailChangeLog = _MediaPlanEstimate.MediaPlanDetailChangeLogs.SingleOrDefault(Function(Entity) Entity.ID = MPECL.MediaPlanDetailChangeLogID)

                        Catch ex As Exception
                            MediaPlanDetailChangeLog = Nothing
                        End Try

                        If MediaPlanDetailChangeLog IsNot Nothing Then

                            MediaPlanDetailChangeLog.CreatedDate = MPECL.Date
                            MediaPlanDetailChangeLog.Comment = MPECL.Comment

                            AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.Update(DbContext, MediaPlanDetailChangeLog)

                        End If

                    Next

                Else

                    For Each MPECL In MediaPlanEstimateChangeLogs

                        Try

                            MediaPlanEstimate = _MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(MPECL.MediaPlanDetailID)

                        Catch ex As Exception
                            MediaPlanEstimate = Nothing
                        End Try

                        If MediaPlanEstimate IsNot Nothing Then

                            Try

                                MediaPlanDetailChangeLog = MediaPlanEstimate.MediaPlanDetailChangeLogs.SingleOrDefault(Function(Entity) Entity.ID = MPECL.MediaPlanDetailChangeLogID)

                            Catch ex As Exception
                                MediaPlanDetailChangeLog = Nothing
                            End Try

                            If MediaPlanDetailChangeLog IsNot Nothing Then

                                MediaPlanDetailChangeLog.CreatedDate = MPECL.Date
                                MediaPlanDetailChangeLog.Comment = MPECL.Comment

                                AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.Update(DbContext, MediaPlanDetailChangeLog)

                            End If

                        End If

                    Next

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailChangeLogDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogDialog = Nothing

            MediaPlanDetailChangeLogDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogDialog(MediaPlan, MediaPlanEstimate)

            ShowFormDialog = MediaPlanDetailChangeLogDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailChangeLogDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            If _MediaPlan IsNot Nothing Then

                LoadGrid()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub MediaPlanDetailChangeLogDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaPlanDetailChangeLogDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ContinueAdd As Boolean = True
            Dim ErrorMessage As String = ""

            DataGridViewForm_ChangeLogs.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_ChangeLogs.GetAllModifiedRows.Count > 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ContinueAdd = Me.Validator

                    If ContinueAdd Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Saving...")

                        Try

                            Save()

                            Me.ClearChanged()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            ContinueAdd = False
                        End Try

                        If ContinueAdd = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                ContinueAdd = True

                            End If

                        End If

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    End If

                End If

            End If

            If ContinueAdd Then

                If AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogEditDialog.ShowFormDialog(_MediaPlan, _MediaPlanEstimate, Nothing) = Windows.Forms.DialogResult.OK Then

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            DataGridViewForm_ChangeLogs.CurrentView.CloseEditorForUpdating()

            If Me.Validator Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
