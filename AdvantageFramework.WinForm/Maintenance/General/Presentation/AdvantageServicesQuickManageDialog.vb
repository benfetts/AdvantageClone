Namespace Maintenance.General.Presentation

    Public Class AdvantageServicesQuickManageDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DatabaseProfile = DatabaseProfile

        End Sub
        Private Sub LoadGrid()

            Using DataContext = New AdvantageFramework.Database.DataContext(_DatabaseProfile.ConnectionString, _DatabaseProfile.DatabaseUserName)

                DataGridViewForm_Services.DataSource = AdvantageFramework.Database.Procedures.AdvantageService.Load(DataContext).ToList

                DataGridViewForm_Services.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As System.Windows.Forms.DialogResult

            'objects
            Dim AdvantageServicesQuickManageDialog As AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesQuickManageDialog = Nothing

            AdvantageServicesQuickManageDialog = New AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesQuickManageDialog(DatabaseProfile)

            ShowFormDialog = AdvantageServicesQuickManageDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvantageServicesQuickManageDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemService_EnableAll.Image = AdvantageFramework.My.Resources.PowerOnImage
            ButtonItemService_DisableAll.Image = AdvantageFramework.My.Resources.PowerCancelImage

            LoadGrid()

        End Sub
        Private Sub AdvantageServicesQuickManageDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub AdvantageServicesQuickManageDialog_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(_DatabaseProfile.ConnectionString, _DatabaseProfile.DatabaseUserName)

                        For Each AdvantageService In DataGridViewForm_Services.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Entities.AdvantageService).ToList

                            DataContext.AdvantageServices.Attach(AdvantageService, True)

                            AdvantageFramework.Database.Procedures.AdvantageService.Update(DataContext, AdvantageService)

                        Next

                        Saved = True

                    End Using

                Catch ex As Exception
                    ErrorMessage = "Failed saving settings."
                End Try

                Me.CloseWaitForm()

                If Saved Then

                    Me.ClearChanged()

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemService_EnableAll_Click(sender As Object, e As EventArgs) Handles ButtonItemService_EnableAll.Click

            DataGridViewForm_Services.CurrentView.BeginDataUpdate()

            For RowHandle = 0 To DataGridViewForm_Services.CurrentView.RowCount - 1

                If DataGridViewForm_Services.CurrentView.IsDataRow(RowHandle) Then

                    DataGridViewForm_Services.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AdvantageService.Properties.Enabled.ToString, True)

                End If

            Next

            DataGridViewForm_Services.CurrentView.EndDataUpdate()

        End Sub
        Private Sub ButtonItemService_DisableAll_Click(sender As Object, e As EventArgs) Handles ButtonItemService_DisableAll.Click

            DataGridViewForm_Services.CurrentView.BeginDataUpdate()

            For RowHandle = 0 To DataGridViewForm_Services.CurrentView.RowCount - 1

                If DataGridViewForm_Services.CurrentView.IsDataRow(RowHandle) Then

                    DataGridViewForm_Services.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AdvantageService.Properties.Enabled.ToString, False)

                End If

            Next

            DataGridViewForm_Services.CurrentView.EndDataUpdate()

        End Sub

#End Region

#End Region

    End Class

End Namespace