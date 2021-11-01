Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _MarketGroupID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property MarketGroupID As Integer
            Get
                MarketGroupID = _MarketGroupID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()



        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_OK.Enabled = _ViewModel.OKEnabled
            ButtonForm_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxForm_MarketGroup.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.ID)

            ComboBoxForm_MarketGroup.DisplayMember = "Name"
            ComboBoxForm_MarketGroup.ValueMember = "ID"

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_MarketGroup.DataSource = _ViewModel.MarketGroups.ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketID As Integer, ByRef MarketGroupID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog As Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog = Nothing

            MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog = New Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog(MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                MarketGroupID = MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog.MarketGroupID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            _ViewModel = _Controller.MarketSubmarketsAddMarketGroup_Load(_MediaBroadcastWorksheetMarketID)

            SetControlDataSources()

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ComboBoxForm_MarketGroup.HasASelectedValue Then

                    _MarketGroupID = ComboBoxForm_MarketGroup.GetSelectedValue

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(Me, "Please select a valid market group.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace