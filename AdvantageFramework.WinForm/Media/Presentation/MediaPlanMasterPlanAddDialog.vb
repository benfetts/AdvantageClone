Namespace Media.Presentation

    Public Class MediaPlanMasterPlanAddDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanMasterPlanID As Integer = 0
        Private _MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanMasterPlanID As Integer
            Get
                MediaPlanMasterPlanID = _MediaPlanMasterPlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlanMasterPlanID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanMasterPlanID = MediaPlanMasterPlanID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaPlanMasterPlanID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanMasterPlanAddDialog As AdvantageFramework.Media.Presentation.MediaPlanMasterPlanAddDialog = Nothing

            MediaPlanMasterPlanAddDialog = New AdvantageFramework.Media.Presentation.MediaPlanMasterPlanAddDialog(MediaPlanMasterPlanID)

            ShowFormDialog = MediaPlanMasterPlanAddDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                MediaPlanMasterPlanID = MediaPlanMasterPlanAddDialog.MediaPlanMasterPlanID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanMasterPlanAddDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail) = Nothing
            Dim MediaPlanIDs() As Integer = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxTopSection_Description.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanMasterPlan.Properties.Description)
                    TextBoxTopSection_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanMasterPlan.Properties.Comment)

                    If _MediaPlanMasterPlanID = 0 Then

                        Me.Text = "Add " & Me.Text

                        ButtonBottomSection_Add.Visible = True
                        ButtonBottomSection_Update.Visible = False

                    Else

                        Me.Text = "Edit " & Me.Text

                        ButtonBottomSection_Add.Visible = False
                        ButtonBottomSection_Update.Visible = True

                        _MediaPlanMasterPlan = AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.LoadByMediaPlanMasterPlanID(DbContext, _MediaPlanMasterPlanID)

                        If _MediaPlanMasterPlan IsNot Nothing Then

                            TextBoxTopSection_Description.Text = _MediaPlanMasterPlan.Description
                            TextBoxTopSection_Comment.Text = _MediaPlanMasterPlan.Comment

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The master plan you are trying to view does not exist anymore.")
                            Me.Close()

                        End If

                    End If

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonBottomSection_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBottomSection_Add.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing

            If Me.Validator Then

                TextBoxTopSection_Comment.CheckSpelling()

                Me.FormAction = WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        _MediaPlanMasterPlan = New AdvantageFramework.Database.Entities.MediaPlanMasterPlan

                        _MediaPlanMasterPlan.DbContext = DbContext

                        _MediaPlanMasterPlan.Description = TextBoxTopSection_Description.Text
                        _MediaPlanMasterPlan.Comment = TextBoxTopSection_Comment.Text

                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Insert(DbContext, _MediaPlanMasterPlan) Then

                            _MediaPlanMasterPlanID = _MediaPlanMasterPlan.ID

                            Added = True

                        End If

                        If Added Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                        DbContext.Database.Connection.Close()

                    End Using

                Catch ex As Exception
                    Added = False
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If Added Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Failed to save master plan.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonBottomSection_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBottomSection_Update.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing

            If Me.Validator Then

                TextBoxTopSection_Comment.CheckSpelling()

                Me.FormAction = WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        _MediaPlanMasterPlan.DbContext = DbContext

                        _MediaPlanMasterPlan.Description = TextBoxTopSection_Description.Text
                        _MediaPlanMasterPlan.Comment = TextBoxTopSection_Comment.Text

                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Update(DbContext, _MediaPlanMasterPlan) Then

                            _MediaPlanMasterPlanID = _MediaPlanMasterPlan.ID

                            Updated = True

                        End If

                        If Updated Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                        DbContext.Database.Connection.Close()

                    End Using

                Catch ex As Exception
                    Updated = False
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If Updated Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Failed to save master plan.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonBottomSection_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBottomSection_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
