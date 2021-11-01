Namespace Media.Presentation

    Public Class DigitalCampaignManagerForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.DigitalCampaignManagerController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            Dim LayoutLoaded As Boolean = False

            Me.ShowWaitForm("Loading...")

            _ViewModel = _Controller.Load()

            CheckBoxItemInclude_Internet.Checked = _ViewModel.IncludeInternet
            CheckBoxItemInclude_Magazine.Checked = _ViewModel.IncludeMagazine
            CheckBoxItemInclude_Newspaper.Checked = _ViewModel.IncludeNewspaper
            CheckBoxItemInclude_OutOfHome.Checked = _ViewModel.IncludeOutOfHome

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(DataGridViewForm_OpenPlanEstimates, _ViewModel.OpenPlanEstimateGridLayout, RemoveOldColumns:=True)

            DataGridViewForm_OpenPlanEstimates.DataSource = _ViewModel.OpenPlanEstimates

            If LayoutLoaded = False Then

                SetColumnDefaultVisibility()

            End If

            DataGridViewForm_OpenPlanEstimates.CurrentView.BestFitColumns()

            ButtonItemActions_Review.Enabled = DataGridViewForm_OpenPlanEstimates.HasASelectedRow

            Me.CloseWaitForm()

        End Sub
        Private Sub RefreshViewModel()

            SaveViewModel()

            Me.ShowWaitForm("Refreshing...")

            _Controller.RefreshOpenPlanEstimates(_ViewModel)

            DataGridViewForm_OpenPlanEstimates.DataSource = _ViewModel.OpenPlanEstimates

            Me.CloseWaitForm()

        End Sub
        Private Sub ReviewEstimate()

            Dim OpenPlanEstimate As AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate = Nothing
            Dim Message As String = String.Empty
            Dim OpenPlanEstimateList As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate) = Nothing

            If DataGridViewForm_OpenPlanEstimates.HasOnlyOneSelectedRow Then

                OpenPlanEstimateList = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)

                OpenPlanEstimate = DirectCast(DataGridViewForm_OpenPlanEstimates.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)

                OpenPlanEstimateList.Add(OpenPlanEstimate)

                If CheckForOpenMediaPlan(Me.MdiParent, OpenPlanEstimate.MediaPlanID, OpenPlanEstimate.MediaPlanDetailID) = False Then

                    If AdvantageFramework.MediaPlanning.IsEstimateLocked(Session, OpenPlanEstimate.MediaPlanDetailID, Message) Then

                        AdvantageFramework.WinForm.MessageBox.Show(Message)

                    Else

                        AdvantageFramework.Media.Presentation.DigitalCampaignDetailDialog.ShowFormDialog(OpenPlanEstimateList)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("You currently have this estimate open, please close before accessing via Digital Campaign Manager.")

                End If

            Else

                OpenPlanEstimateList = DataGridViewForm_OpenPlanEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate).ToList

                AdvantageFramework.Media.Presentation.DigitalCampaignDetailDialog.ShowFormDialog(OpenPlanEstimateList)

            End If

        End Sub
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = String.Empty

            AFActiveFilterString = DataGridViewForm_OpenPlanEstimates.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Me.Session, DataGridViewForm_OpenPlanEstimates, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerOpenPlanEstimates)

            DataGridViewForm_OpenPlanEstimates.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.IncludeInternet = CheckBoxItemInclude_Internet.Checked
            _ViewModel.IncludeMagazine = CheckBoxItemInclude_Magazine.Checked
            _ViewModel.IncludeNewspaper = CheckBoxItemInclude_Newspaper.Checked
            _ViewModel.IncludeOutOfHome = CheckBoxItemInclude_OutOfHome.Checked

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_OpenPlanEstimates.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.MediaPlanID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.ProductName.ToString Then

                    GridColumn.OptionsColumn.AllowShowHide = True

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.ClientCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate.Properties.ProductCode.ToString Then

                    GridColumn.OptionsColumn.AllowShowHide = False

                    GridColumn.Visible = False

                Else

                    GridColumn.OptionsColumn.AllowShowHide = False

                    GridColumn.Visible = True

                End If

            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DigitalCampaignManagerForm As Media.Presentation.DigitalCampaignManagerForm = Nothing

            DigitalCampaignManagerForm = New Media.Presentation.DigitalCampaignManagerForm

            DigitalCampaignManagerForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DigitalCampaignManagerForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()
                SaveViewModel()
                _Controller.SaveUserSettings(_ViewModel)

            End If

        End Sub
        Private Sub DigitalCampaignManagerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_Review.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemGrid_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGrid_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            DataGridViewForm_OpenPlanEstimates.OptionsBehavior.Editable = False
            DataGridViewForm_OpenPlanEstimates.MultiSelect = True

            DataGridViewForm_OpenPlanEstimates.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)

            _Controller = New AdvantageFramework.Controller.Media.DigitalCampaignManagerController(Me.Session)

        End Sub
        Private Sub DigitalCampaignManagerForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_Review_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Review.Click

            ReviewEstimate()

        End Sub
        Private Sub ButtonItemGrid_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGrid_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGrid_ChooseColumns.Checked Then

                    If DataGridViewForm_OpenPlanEstimates.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_OpenPlanEstimates.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_OpenPlanEstimates.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_OpenPlanEstimates.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGrid_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGrid_RestoreDefaults.Click

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerOpenPlanEstimates, Session.UserCode)

            End Using

            DataGridViewForm_OpenPlanEstimates.SetBookmarkColumnIndex(-1)
            DataGridViewForm_OpenPlanEstimates.ClearGridCustomization()
            DataGridViewForm_OpenPlanEstimates.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate))

            LoadViewModel()

        End Sub
        Private Sub DataGridViewForm_OpenPlanEstimates_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_OpenPlanEstimates.HideCustomizationFormEvent

            If ButtonItemGrid_ChooseColumns.Checked Then

                ButtonItemGrid_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_OpenPlanEstimates_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_OpenPlanEstimates.RowDoubleClickEvent

            ReviewEstimate()

        End Sub
        Private Sub CheckBoxItemInclude_Internet_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemInclude_Internet.CheckedChanged,
                CheckBoxItemInclude_Magazine.CheckedChanged, CheckBoxItemInclude_Newspaper.CheckedChanged, CheckBoxItemInclude_OutOfHome.CheckedChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
