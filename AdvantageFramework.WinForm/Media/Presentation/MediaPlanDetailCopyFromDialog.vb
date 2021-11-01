Namespace Media.Presentation

    Public Class MediaPlanDetailCopyFromDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanID As Integer
            Get
                MediaPlanID = _MediaPlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef MediaPlanID As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailCopyFromDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailCopyFromDialog = Nothing

            MediaPlanDetailCopyFromDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailCopyFromDialog

            ShowFormDialog = MediaPlanDetailCopyFromDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                MediaPlanID = MediaPlanDetailCopyFromDialog.MediaPlanID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailCopyFromDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateTimePickerForm_StartDate.Value > DateTimePickerForm_EndDate.Value Then

                    ErrorMessage = "Please select a start date on or before the end date."

                End If

                If ErrorMessage = "" Then

                    If CDate(DateTimePickerForm_EndDate.Value.AddYears(-1).ToShortDateString) > CDate(DateTimePickerForm_StartDate.Value.ToShortDateString) Then

                        ErrorMessage = "Please select a date range of 1 year or less."

                    End If

                End If

                If ErrorMessage = "" Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Adding...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            MediaPlan = New AdvantageFramework.Database.Entities.MediaPlan

                            MediaPlan.DbContext = DbContext

                            MediaPlan.Description = TextBoxForm_Description.Text
                            'MediaPlan.IsApproved = False
                            MediaPlan.ClientCode = ComboBoxForm_Client.GetSelectedValue
                            MediaPlan.DivisionCode = ComboBoxForm_Division.GetSelectedValue
                            MediaPlan.ProductCode = ComboBoxForm_Product.GetSelectedValue
                            MediaPlan.ClientContactID = ComboBoxForm_ClientContact.GetSelectedValue
                            MediaPlan.CampaignID = ComboBoxForm_Campaign.GetSelectedValue
                            MediaPlan.StartDate = DateTimePickerForm_StartDate.GetValue
                            MediaPlan.EndDate = DateTimePickerForm_EndDate.GetValue
                            MediaPlan.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                            MediaPlan.Comment = TextBoxForm_Comment.Text

                            If AdvantageFramework.Database.Procedures.MediaPlan.Insert(DbContext, MediaPlan) Then

                                Me.ClearChanged()

                                _MediaPlanID = MediaPlan.ID

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

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

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
