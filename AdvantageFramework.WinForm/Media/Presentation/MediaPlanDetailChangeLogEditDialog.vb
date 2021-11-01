Namespace Media.Presentation

    Public Class MediaPlanDetailChangeLogEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        Private _MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan
            _MediaPlanEstimate = MediaPlanEstimate
            _MediaPlanDetailChangeLog = MediaPlanDetailChangeLog

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailChangeLogEditDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogEditDialog = Nothing

            MediaPlanDetailChangeLogEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailChangeLogEditDialog(MediaPlan, MediaPlanEstimate, MediaPlanDetailChangeLog)

            ShowFormDialog = MediaPlanDetailChangeLogEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailChangeLogEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _MediaPlan IsNot Nothing Then

                ComboBoxForm_Estimate.SetPropertySettings("Estimate", GetType(Integer), True)
                DateTimePickerForm_Date.SetRequired(True)
                TextBoxComment_Comment.SetDefaultPropertySettings(0, "Comment", BaseClasses.PropertyTypes.Default, True)

                ComboBoxForm_Estimate.DataSource = (From MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(MPE) MPE.OrderNumber).ToList _
                                                    Select [Name] = MediaPlanEstimate.Name, _
                                                           [ID] = MediaPlanEstimate.ID).ToList

                If _MediaPlanEstimate IsNot Nothing Then

                    ComboBoxForm_Estimate.SelectedValue = _MediaPlanEstimate.ID
                    ComboBoxForm_Estimate.ReadOnly = True

                Else

                    ComboBoxForm_Estimate.SelectedIndex = 0
                    ComboBoxForm_Estimate.ReadOnly = False

                End If

                If _MediaPlanDetailChangeLog IsNot Nothing Then

                    TextBoxComment_Comment.Text = _MediaPlanDetailChangeLog.Comment
                    DateTimePickerForm_Date.Value = _MediaPlanDetailChangeLog.CreatedDate

                Else

                    TextBoxComment_Comment.Text = ""
                    DateTimePickerForm_Date.Value = Now

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog = Nothing
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim ChangeLogNumber As Integer = 1
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                TextBoxComment_Comment.CheckSpelling()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            If AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.LoadByMediaPlanDetailID(DbContext, ComboBoxForm_Estimate.GetSelectedValue).Any Then

                                ChangeLogNumber = AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.LoadByMediaPlanDetailID(DbContext, ComboBoxForm_Estimate.GetSelectedValue).Select(Function(Entity) Entity.ChangeLogNumber).Max + 1

                            End If

                        Catch ex As Exception
                            ChangeLogNumber = 1
                        End Try

                        MediaPlanDetailChangeLog = New AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog

                        MediaPlanDetailChangeLog.MediaPlanID = _MediaPlan.ID
                        MediaPlanDetailChangeLog.MediaPlanDetailID = ComboBoxForm_Estimate.GetSelectedValue
                        MediaPlanDetailChangeLog.CreatedDate = DateTimePickerForm_Date.Value
                        MediaPlanDetailChangeLog.Comment = TextBoxComment_Comment.Text
                        MediaPlanDetailChangeLog.ChangeLogNumber = ChangeLogNumber
                        MediaPlanDetailChangeLog.CreatedByUserCode = Me.Session.UserCode

                        If AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.Insert(DbContext, MediaPlanDetailChangeLog) Then

                            If _MediaPlanEstimate IsNot Nothing Then

                                DbContext.Detach(MediaPlanDetailChangeLog)

                                _MediaPlan.DbContext.TryAttach(MediaPlanDetailChangeLog)

                                _MediaPlanEstimate.MediaPlanDetailChangeLogs.Add(MediaPlanDetailChangeLog)

                            Else

                                MediaPlanEstimate = _MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(ComboBoxForm_Estimate.GetSelectedValue)

                                If MediaPlanEstimate IsNot Nothing Then

                                    DbContext.Detach(MediaPlanDetailChangeLog)

                                    _MediaPlan.DbContext.TryAttach(MediaPlanDetailChangeLog)

                                    MediaPlanEstimate.MediaPlanDetailChangeLogs.Add(MediaPlanDetailChangeLog)

                                End If

                            End If

                            Me.ClearChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

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
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                TextBoxComment_Comment.CheckSpelling()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _MediaPlanDetailChangeLog IsNot Nothing Then

                            _MediaPlanDetailChangeLog.CreatedDate = DateTimePickerForm_Date.Value
                            _MediaPlanDetailChangeLog.Comment = TextBoxComment_Comment.Text

                            If AdvantageFramework.Database.Procedures.MediaPlanDetailChangeLog.Insert(DbContext, _MediaPlanDetailChangeLog) Then

                                Me.ClearChanged()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

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

#End Region

#End Region

    End Class

End Namespace
