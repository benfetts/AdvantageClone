Namespace Maintenance.ProjectManagement.Presentation

    Public Class AdNumberSetupForm

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
        Private Sub SetupViewModel()

            AdNumberControl_AdNumbers.LoadControl()

            If AdNumberControl_AdNumbers.ViewModel.IsAgencyASP = False AndAlso ButtonItemDocuments_Upload.SplitButton = True Then

                ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                ButtonItemDocuments_Upload.SplitButton = False

            End If

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = AdNumberControl_AdNumbers.ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = AdNumberControl_AdNumbers.ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = AdNumberControl_AdNumbers.ViewModel.DeleteEnabled

            ButtonItemDocuments_Upload.Enabled = AdNumberControl_AdNumbers.ViewModel.UserCanUploadDocument AndAlso AdNumberControl_AdNumbers.ViewModel.HasOnlyOneSelectedAdNumber

            ButtonItemUpload_EmailLink.Visible = AdNumberControl_AdNumbers.ViewModel.IsAgencyASP

            ButtonItemDocuments_Delete.Enabled = AdNumberControl_AdNumbers.ViewModel.HasOnlyOneSelectedAdNumber AndAlso AdNumberControl_AdNumbers.ViewModel.SelectedAdNumbers.First.DocumentID.HasValue

            ButtonItemDocuments_Download.Enabled = AdNumberControl_AdNumbers.ViewModel.HasOnlyOneSelectedAdNumber AndAlso AdNumberControl_AdNumbers.ViewModel.SelectedAdNumbers.First.DocumentID.HasValue AndAlso
                    AdNumberControl_AdNumbers.ViewModel.SelectedAdNumbers.First.DocumentIsURL = False

            ButtonItemDocuments_OpenURL.Enabled = AdNumberControl_AdNumbers.ViewModel.HasOnlyOneSelectedAdNumber AndAlso AdNumberControl_AdNumbers.ViewModel.SelectedAdNumbers.First.DocumentID.HasValue AndAlso
                    AdNumberControl_AdNumbers.ViewModel.SelectedAdNumbers.First.DocumentIsURL = True

            AdNumberControl_AdNumbers.Refresh()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdSetupForm As Presentation.AdNumberSetupForm = Nothing

            AdSetupForm = New Presentation.AdNumberSetupForm()

            AdSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdNumberSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

        End Sub
        Private Sub AdNumberSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            SetupViewModel()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            AdNumberControl_AdNumbers.Export()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            AdNumberControl_AdNumbers.Save()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            AdNumberControl_AdNumbers.Delete()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            AdNumberControl_AdNumbers.CancelNewItemRow()

        End Sub
        Private Sub AdNumberControl_AdNumbers_AdNumber_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AdNumberControl_AdNumbers.AdNumber_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub AdNumberControl_AdNumbers_AdNumber_SelectionChangedEvent(sender As Object, e As EventArgs) Handles AdNumberControl_AdNumbers.AdNumber_SelectionChangedEvent

            RefreshViewModel()

        End Sub
        Private Sub AdNumberControl_AdNumbers_AdNumber_Changed() Handles AdNumberControl_AdNumbers.AdNumber_Changed

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            AdNumberControl_AdNumbers.UploadDocument()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            AdNumberControl_AdNumbers.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            AdNumberControl_AdNumbers.DownloadDocument()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            AdNumberControl_AdNumbers.DownloadDocument()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            AdNumberControl_AdNumbers.DeleteDocument()

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace