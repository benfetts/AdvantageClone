Namespace Media.Presentation

    Public Class MediaPlanDetailUserDefinedColumnEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _MediaPlanDetailID As Integer = 0
        Private _MediaPlanDetailUserDefinedColumnID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanDetailUserDefinedColumnID As Integer
            Get
                MediaPlanDetailUserDefinedColumnID = _MediaPlanDetailUserDefinedColumnID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByVal MediaPlanDetailUserDefinedColumnID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanDetailID = MediaPlanDetailID
            _MediaPlanID = MediaPlanID
            _MediaPlanDetailUserDefinedColumnID = MediaPlanDetailUserDefinedColumnID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByRef MediaPlanDetailUserDefinedColumnID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailUserDefinedColumnEditDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailUserDefinedColumnEditDialog = Nothing

            MediaPlanDetailUserDefinedColumnEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailUserDefinedColumnEditDialog(MediaPlanID, MediaPlanDetailID, MediaPlanDetailUserDefinedColumnID)

            ShowFormDialog = MediaPlanDetailUserDefinedColumnEditDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                MediaPlanDetailUserDefinedColumnID = MediaPlanDetailUserDefinedColumnEditDialog.MediaPlanDetailUserDefinedColumnID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailUserDefinedColumnEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, _MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, _MediaPlanDetailID)

                    If MediaPlanDetail IsNot Nothing Then

                        If _MediaPlanDetailUserDefinedColumnID = 0 Then

                            ButtonForm_Add.Visible = True
                            ButtonForm_Update.Visible = False

                        Else

                            'MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, _MediaPlanDetailID)

                            'If MediaPlanDetail IsNot Nothing Then

                            '    ButtonForm_Add.Visible = False
                            '    ButtonForm_Update.Visible = True


                            'Else

                            '    AdvantageFramework.WinForm.MessageBox.Show("The user defined column you are trying to edit does not exist anymore.")
                            '    Me.Close()

                            'End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The media plan detail you are trying to edit does not exist anymore.")
                        Me.Close()

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

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

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)


                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

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
