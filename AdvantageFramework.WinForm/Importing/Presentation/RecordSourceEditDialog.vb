Namespace Importing.Presentation

    Public Class RecordSourceEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RecordSourceID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property RecordSourceID As Integer
            Get
                RecordSourceID = _RecordSourceID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal RecordSourceID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RecordSourceID = RecordSourceID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef RecordSourceID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RecordSourceEditDialog As AdvantageFramework.Importing.Presentation.RecordSourceEditDialog = Nothing

            RecordSourceEditDialog = New AdvantageFramework.Importing.Presentation.RecordSourceEditDialog(RecordSourceID)

            ShowFormDialog = RecordSourceEditDialog.ShowDialog()

            RecordSourceID = RecordSourceEditDialog.RecordSourceID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RecordSourceEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.RecordSource.Properties.Name)
                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.RecordSource.Properties.Description)

                If _RecordSourceID = 0 Then

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                    Me.Text = "Add Record Source"

                Else

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                    Me.Text = "Update Record Source"

                    RecordSource = AdvantageFramework.Database.Procedures.RecordSource.LoadByRecordSourceID(DbContext, _RecordSourceID)

                    If RecordSource IsNot Nothing Then

                        TextBoxForm_Name.Text = RecordSource.Name
                        TextBoxForm_Description.Text = RecordSource.Description

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The record source you are trying to edit does not exist anymore.")
                        Me.Close()

                    End If

                End If

            End Using

        End Sub
        Private Sub RecordSourceEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                TextBoxForm_Name.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        RecordSource = New AdvantageFramework.Database.Entities.RecordSource

                        RecordSource.DbContext = DbContext
                        RecordSource.Name = TextBoxForm_Name.Text
                        RecordSource.Description = TextBoxForm_Description.Text
                        RecordSource.IsSystemSource = False

                        If AdvantageFramework.Database.Procedures.RecordSource.Insert(DbContext, RecordSource) Then

                            _RecordSourceID = RecordSource.ID

                            Me.ClearChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End Using

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Updating...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        RecordSource = AdvantageFramework.Database.Procedures.RecordSource.LoadByRecordSourceID(DbContext, _RecordSourceID)

                        If RecordSource IsNot Nothing Then

                            RecordSource.DbContext = DbContext
                            RecordSource.Name = TextBoxForm_Name.Text
                            RecordSource.Description = TextBoxForm_Description.Text
                            RecordSource.IsSystemSource = False

                            If AdvantageFramework.Database.Procedures.RecordSource.Update(DbContext, RecordSource) Then

                                _RecordSourceID = RecordSource.ID

                                Me.ClearChanged()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The record source you are trying to edit does not exist anymore.")

                        End If

                    End Using

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try
                
                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

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