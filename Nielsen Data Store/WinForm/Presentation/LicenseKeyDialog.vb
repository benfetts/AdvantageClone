Namespace WinForm.Presentation

    Public Class LicenseKeyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As NielsenFramework.ViewModels.LicenseKeyViewModel = Nothing
        Protected _Controller As NielsenFramework.Controller.LicenseKeyController = Nothing
        Protected _ConnectionString As String = Nothing
        Protected _ClientCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ConnectionString As String, ClientCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString
            _ClientCode = ClientCode

        End Sub
        Private Sub RefreshViewModel()

            Me.ShowWaitForm("Refreshing...")

            _ViewModel = _Controller.Load(_ClientCode)

            DataGridViewForm_LicenseKey.DataSource = _ViewModel.LicenseKeys
            DataGridViewForm_LicenseKey.CurrentView.BestFitColumns()

            ButtonItemEdit_Copy.Enabled = (_ViewModel.LicenseKeys.Count > 0)

            Me.CloseWaitForm()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ConnectionString As String, ClientCode As String) As Windows.Forms.DialogResult

            'objects
            Dim LicenseKeyDialog As WinForm.Presentation.LicenseKeyDialog = Nothing

            LicenseKeyDialog = New WinForm.Presentation.LicenseKeyDialog(ConnectionString, ClientCode)

            ShowFormDialog = LicenseKeyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LicenseKeyDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemEdit_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            DataGridViewForm_LicenseKey.OptionsBehavior.ReadOnly = True
            DataGridViewForm_LicenseKey.MultiSelect = False

            _Controller = New NielsenFramework.Controller.LicenseKeyController(_ConnectionString)

        End Sub
        Private Sub LicenseKeyDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemEdit_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemEdit_Copy.Click

            If DataGridViewForm_LicenseKey.HasASelectedRow Then

                Clipboard.SetText(DirectCast(DataGridViewForm_LicenseKey.GetFirstSelectedRowDataBoundItem, NielsenFramework.DTO.LicenseKey).EncrpytedLicenseKey)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace