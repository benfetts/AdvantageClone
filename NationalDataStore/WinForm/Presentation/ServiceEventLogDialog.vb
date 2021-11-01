Namespace WinForm.Presentation

    Public Class ServiceEventLog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As NationalFramework.ViewModels.ServiceEventViewModel = Nothing
        Protected _Controller As NationalFramework.Controller.ServiceEventController = Nothing
        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ConnectionString As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim DownloadFile As NationalFramework.DTO.DownloadFile = Nothing
            Dim RunServiceEnabled As Boolean = False
            Dim ServiceStatus As NationalFramework.DTO.ServiceStatus = Nothing

            If Me.FormShown Then

                RibbonBarOptions_Actions.SuspendLayout()

                ButtonItemActions_RunService.Visible = ButtonItemView_ServiceStatus.Checked

                If ButtonItemView_ServiceStatus.Checked AndAlso DataGridViewForm_View.HasASelectedRow Then

                    ServiceStatus = DataGridViewForm_View.GetRowDataBoundItem(DataGridViewForm_View.CurrentView.FocusedRowHandle)

                    If ServiceStatus IsNot Nothing AndAlso Not ServiceStatus.IsRunning Then

                        RunServiceEnabled = True

                    End If

                End If

                ButtonItemActions_RunService.Enabled = RunServiceEnabled

                RibbonBarOptions_Actions.ResetCachedContentSize()

                RibbonBarOptions_Actions.Refresh()

                RibbonBarOptions_Actions.Width = RibbonBarOptions_View.GetAutoSizeWidth

                RibbonBarOptions_Actions.Refresh()

                RibbonBarOptions_Actions.ResumeLayout()

            End If

        End Sub
        Private Sub RefreshViewModel()

            Me.ShowWaitForm("Refreshing...")

            DataGridViewForm_View.ClearGridCustomization()

            If ButtonItemView_DownloadFiles.Checked Then

                _ViewModel = _Controller.LoadDownloadFiles
                DataGridViewForm_View.ItemDescription = "Download File(s)"
                DataGridViewForm_View.DataSource = _ViewModel.DownloadFiles

                'ElseIf ButtonItemView_RadioPeriods.Checked Then

                '    _ViewModel = _Controller.LoadNielsenRadioPeriods
                '    DataGridViewForm_View.ItemDescription = "Radio Period(s)"
                '    DataGridViewForm_View.DataSource = _ViewModel.NielsenRadioPeriods

            ElseIf ButtonItemView_ServiceEvents.Checked Then

                _ViewModel = _Controller.LoadEventLogs
                DataGridViewForm_View.ItemDescription = "Event Log(s)"
                DataGridViewForm_View.DataSource = _ViewModel.EventLogs

            ElseIf ButtonItemView_ServiceStatus.Checked Then

                _ViewModel = _Controller.LoadNielsenServiceStatus
                DataGridViewForm_View.ItemDescription = "Service Status"
                DataGridViewForm_View.DataSource = _ViewModel.ServiceStatus

            End If

            DataGridViewForm_View.CurrentView.BestFitColumns()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ConnectionString As String) As Windows.Forms.DialogResult

            'objects
            Dim ServiceEventLog As WinForm.Presentation.ServiceEventLog = Nothing

            ServiceEventLog = New WinForm.Presentation.ServiceEventLog(ConnectionString)

            ShowFormDialog = ServiceEventLog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceEventLog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            Me.ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            Me.ButtonItemActions_RunService.Image = AdvantageFramework.My.Resources.ProcessImage

            Me.ButtonItemView_DownloadFiles.Image = AdvantageFramework.My.Resources.DocumentIcon.ToBitmap
            Me.ButtonItemView_ServiceEvents.Image = AdvantageFramework.My.Resources.AdvantageServicesImage
            Me.ButtonItemView_ServiceStatus.Image = AdvantageFramework.My.Resources.AdvantageServicesImage

            DataGridViewForm_View.OptionsBehavior.Editable = False

            _Controller = New NationalFramework.Controller.ServiceEventController(_ConnectionString)

        End Sub
        Private Sub ServiceEventLog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ButtonItemView_ServiceEvents.Checked = True

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_RunService_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_RunService.Click

            If NationalFramework.Service.SetServiceToRun(_ConnectionString) Then

                AdvantageFramework.WinForm.MessageBox.Show("Service has been flagged to run, it may take up to 30 minutes to begin.")

            End If

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemView_DownloadFiles_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_DownloadFiles.CheckedChanged

            If ButtonItemView_DownloadFiles.Checked Then

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemView_ServiceEvents_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ServiceEvents.CheckedChanged

            If ButtonItemView_ServiceEvents.Checked Then

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemView_ServiceStatus_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ServiceStatus.CheckedChanged

            If ButtonItemView_ServiceStatus.Checked Then

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_View_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_View.FocusedRowChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace