Namespace Media.Presentation

    Public Class MediaTrafficProcessGenerateDialog

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum ViewMode
            GenerateTraffic
            EmailVendorReps
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Protected _Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate) = Nothing
        Private _ViewMode As ViewMode = ViewMode.GenerateTraffic
        Private _AlertID As Integer = 0
        Private _ContactTypeIDs As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate), ContactTypeIDs As Generic.List(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            _Generates = Generates
            _ContactTypeIDs = ContactTypeIDs

        End Sub
        Private Sub New(AlertID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _AlertID = AlertID

            _ViewMode = ViewMode.EmailVendorReps

        End Sub
        Private Sub LoadViewModel()

            If _ViewMode = ViewMode.GenerateTraffic Then

                _ViewModel = _Controller.LoadMediaTrafficProcessGenerateViewModel(_Generates, _ContactTypeIDs)

            ElseIf _ViewMode = ViewMode.EmailVendorReps Then

                _ViewModel = _Controller.Email_Load(_AlertID)

            End If

        End Sub
        Private Sub RefreshViewModel(GridOnly As Boolean)

            If _ViewMode = ViewMode.GenerateTraffic Then

                If Not GridOnly Then

                    Me.TextBoxForm_Subject.Text = _ViewModel.EmailSubject
                    Me.TextBoxForm_Body.Text = _ViewModel.EmailBody
                    Me.CheckBoxForm_CCToSender.Checked = _ViewModel.CCSender

                End If

                Me.DataGridViewForm_VendorReps.DataSource = _ViewModel.GenerateVendorReps

                ButtonItemActions_Process.Enabled = DataGridViewForm_VendorReps.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep).Where(Function(VR) VR.Process = True).Any

            ElseIf _ViewMode = ViewMode.EmailVendorReps Then

                Me.DataGridViewForm_VendorReps.DataSource = _ViewModel.EmailVendorRepContacts

                ButtonItemActions_Process.Enabled = DataGridViewForm_VendorReps.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact).Where(Function(VR) VR.Include = True).Any

            End If

            Me.DataGridViewForm_VendorReps.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.CCSender = CheckBoxForm_CCToSender.Checked
            _ViewModel.EmailSubject = TextBoxForm_Subject.Text
            _ViewModel.EmailBody = TextBoxForm_Body.Text

        End Sub
        Private Sub Save()

            SaveViewModel()

            _Controller.SaveEmailSettings(_ViewModel)

            ButtonItemDefaultEmailSettings_Save.Enabled = False

        End Sub
        Private Sub GenerateInstructions()

            'objects
            Dim GenerateVendorReps As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep) = Nothing
            Dim AtLeastOneEmailFailed As Boolean = False

            DataGridViewForm_VendorReps.CurrentView.CloseEditorForUpdating()

            SaveViewModel()

            If ButtonItemDefaultEmailSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Save()

                End If

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Printing
            Me.ShowWaitForm("Processing...")

            GenerateVendorReps = DataGridViewForm_VendorReps.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep).Where(Function(VR) VR.Process = True).ToList

            If AdvantageFramework.Reporting.Reports.ProcessGenerateMediaTrafficInstructions(Me.Session, GenerateVendorReps, TextBoxForm_Subject.GetText, TextBoxForm_Body.GetText, CheckBoxForm_CCToSender.Checked, AtLeastOneEmailFailed) Then

                If AtLeastOneEmailFailed Then

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Successful - however one or more emails failed to send.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Successful.")

                End If

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub SendEmails()

            'objects
            Dim ErrorMessage As String = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Printing
            Me.ShowWaitForm("Emailing...")

            _ViewModel.Email_Comment = Me.TextBoxNewComment.Text

            If Not _Controller.Email_SendEmails(_ViewModel, ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show("Error: " & ErrorMessage)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Emails sent successfully.")

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate), ContactTypeIDs As Generic.List(Of String)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficProcessGenerateDialog As MediaTrafficProcessGenerateDialog = Nothing

            MediaTrafficProcessGenerateDialog = New MediaTrafficProcessGenerateDialog(Generates, ContactTypeIDs)

            ShowFormDialog = MediaTrafficProcessGenerateDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(AlertID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficProcessGenerateDialog As MediaTrafficProcessGenerateDialog = Nothing

            MediaTrafficProcessGenerateDialog = New MediaTrafficProcessGenerateDialog(AlertID)

            ShowFormDialog = MediaTrafficProcessGenerateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficProcessGenerateDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.LabelForm_Comment.Visible = False
            Me.TextBoxNewComment.Visible = False

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_VendorReps.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewForm_VendorReps.CurrentView.GridControl.ShowOnlyPredefinedDetails = True

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

            Me.TextBoxForm_Subject.SetPropertySettings(AdvantageFramework.Security.Database.Entities.UserSetting.Properties.StringValue, "Subject")
            Me.TextBoxForm_Body.SetPropertySettings(AdvantageFramework.Security.Database.Entities.UserSetting.Properties.StringValue, "Body")

            Me.ShowUnsavedChangesOnFormClosing = False

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

            If _ViewMode = ViewMode.EmailVendorReps Then

                Me.Text = "Add New Comment"

                RibbonBarOptions_DefaultEmailSettings.Visible = False

                ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.EmailSendImage
                ButtonItemActions_Process.Text = "Send"

                Me.LabelForm_Subject.Visible = False
                Me.LabelForm_Body.Visible = False
                Me.DataGridViewForm_VendorReps.Visible = False

                Me.LabelForm_Comment.Visible = True
                Me.TextBoxNewComment.Visible = True

            End If

        End Sub
        Private Sub MediaTrafficProcessGenerateDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            RefreshViewModel(False)

            TextBoxNewComment.Focus()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            If _ViewMode = ViewMode.GenerateTraffic Then

                GenerateInstructions()

            ElseIf _ViewMode = ViewMode.EmailVendorReps Then

                If String.IsNullOrWhiteSpace(Me.TextBoxNewComment.Text) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a comment.")

                Else

                    SendEmails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            Save()

        End Sub
        Private Sub CheckBoxForm_CCToSender_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_CCToSender.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub DataGridViewForm_VendorReps_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_VendorReps.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep.Properties.DefaultCorrespondenceMethod.ToString Then

                If e.CellValue = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email.ToString

                ElseIf e.CellValue = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print.ToString

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_VendorReps_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_VendorReps.ShowingEditorEvent

            If DataGridViewForm_VendorReps.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep.Properties.Process.ToString AndAlso
                    DataGridViewForm_VendorReps.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact.Properties.Include.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TextBoxForm_Body_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Body.TextChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub TextBoxForm_Subject_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Subject.TextChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub DataGridViewForm_VendorReps_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_VendorReps.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact.Properties.Include.ToString OrElse e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep.Properties.Process.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemBookend_EditValueChanging

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub
        Private Sub RepositoryItemBookend_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim GenerateVendorRep As AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep = Nothing
            Dim EmailVendorRepContact As AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact = Nothing

            If _ViewMode = ViewMode.GenerateTraffic Then

                GenerateVendorRep = DataGridViewForm_VendorReps.CurrentView.GetRow(DataGridViewForm_VendorReps.CurrentView.FocusedRowHandle)

                _Controller.Generate_CheckUncheck(_ViewModel, GenerateVendorRep, e.NewValue)

            ElseIf _ViewMode = ViewMode.EmailVendorReps Then

                EmailVendorRepContact = DataGridViewForm_VendorReps.CurrentView.GetRow(DataGridViewForm_VendorReps.CurrentView.FocusedRowHandle)

                _Controller.Email_CheckUncheck(_ViewModel, EmailVendorRepContact, e.NewValue)

            End If

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_VendorReps_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_VendorReps.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep.Properties.ContactType.ToString Then

                Datasource = _ViewModel.ContactTypeList

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
