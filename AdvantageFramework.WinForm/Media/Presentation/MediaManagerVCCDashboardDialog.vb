Namespace Media.Presentation

    Public Class MediaManagerVCCDashboardDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
        Private _VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail))

            ' This call is required by the designer.
            InitializeComponent()

            _MediaManagerReviewDetails = MediaManagerReviewDetails

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

            VCCOrders = _VCCOrders.ToList

            If ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_TransactionsDeclined.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_TransactionsOutOfBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_TransactionsInBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_SettledOutOfBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_SettledInBalance.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            ElseIf ButtonItemSummaryResults_InvalidDataOrExpirationDate.Checked Then

                VCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).ToList

            End If

            DataGridViewForm_VCCOrders.DataSource = VCCOrders

            DataGridViewForm_VCCOrders.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadVCCOrders() As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            'objects
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim VCCCard As AdvantageFramework.EF6CFDatabase.Entities.VCCCard = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.EF6CFDatabase.Entities.VCCCard) = Nothing

            VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            Try

                Using DbContext = New AdvantageFramework.EF6CFDatabase.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    VCCCards = DbContext.VCCCards.ToList

                End Using

            Catch ex As Exception
                VCCCards = Nothing
            End Try

            If VCCCards IsNot Nothing Then

                For Each MMRD In _MediaManagerReviewDetails

                    VCCCard = Nothing

                    Try

                        VCCCard = VCCCards.SingleOrDefault(Function(Entity) Entity.OrderNumber = MMRD.OrderNumber AndAlso Entity.LineNumber = MMRD.LineNumber)

                    Catch ex As Exception
                        VCCCard = Nothing
                    End Try

                    If VCCCard IsNot Nothing Then

                        VCCOrders.Add(New AdvantageFramework.MediaManager.Classes.VCCOrder(MMRD, VCCCard))

                    End If

                Next

            End If

            LoadVCCOrders = VCCOrders

        End Function
        Private Sub SetVCCOrderStats()

            If _VCCOrders IsNot Nothing Then

                ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkText = _VCCOrders.Count
                ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkText = _VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.ModifiedByUserCode) = True).Count
                ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.HasADeclinedTransaction = True).Count

                ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.HasTransactionOutOfBalance = True).Count
                ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.HasTransactionInBalance = True).Count
                ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.HasSettledOutOfBalance = True).Count
                ButtonItemSummaryResults_SettledInBalance.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.HasSettledInBalance = True).Count

                ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkText = _VCCOrders.Where(Function(Entity) Entity.CardExpired = True).Count

            End If

        End Sub
        Private Sub LoadVCCOrderDetails()

            'objects
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing

            Try

                VendorControlVendorInfo_Vendor.ClearControl()

                If DataGridViewForm_VCCOrders.HasOnlyOneSelectedRow Then

                    VCCOrder = DataGridViewForm_VCCOrders.GetFirstSelectedRowDataBoundItem

                    If VCCOrder IsNot Nothing Then

                        VendorControlVendorInfo_Vendor.Enabled = True

                    End If

                End If

                If VendorControlVendorInfo_Vendor.Enabled AndAlso VCCOrder IsNot Nothing Then

                    VendorControlVendorInfo_Vendor.Enabled = VendorControlVendorInfo_Vendor.LoadControl(VCCOrder.VendorCode)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ClearFilters()

            ButtonItemSummaryResults_InvalidDataOrExpirationDate.Checked = False
            ButtonItemSummaryResults_SettledInBalance.Checked = False
            ButtonItemSummaryResults_SettledOutOfBalance.Checked = False
            ButtonItemSummaryResults_TransactionsDeclined.Checked = False
            ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Checked = False
            ButtonItemSummaryResults_TransactionsInBalance.Checked = False
            ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = False
            ButtonItemSummaryResults_VCCCreditCardsIssued.Checked = False
            ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = False

        End Sub
        Private Sub FilterLoadGrid()

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

                LoadVCCOrderDetails()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            TabControlForm_VCCDetails.Enabled = (DataGridViewForm_VCCOrders.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            VendorControlVendorInfo_Vendor.Enabled = (TabControlForm_VCCDetails.Enabled AndAlso Me.FormShown)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerVCCDashboardDialog As AdvantageFramework.Media.Presentation.MediaManagerVCCDashboardDialog = Nothing

            MediaManagerVCCDashboardDialog = New AdvantageFramework.Media.Presentation.MediaManagerVCCDashboardDialog(MediaManagerReviewDetails)

            ShowFormDialog = MediaManagerVCCDashboardDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerVCCDashboardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_SendNotifications.Image = AdvantageFramework.My.Resources.EmailNewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewForm_VCCOrders.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            Try

                _VCCOrders = LoadVCCOrders()

            Catch ex As Exception

            End Try

            If _VCCOrders Is Nothing Then

                _VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub MediaManagerVCCDashboardDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                SetVCCOrderStats()

                LoadGrid()

                LoadVCCOrderDetails()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click



        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim Refreshed As Boolean = False

            Me.FormAction = WinForm.Presentation.FormActions.Refreshing
            Me.ShowWaitForm("Refreshing...")

            Try

                Refreshed = AdvantageFramework.VCC.RefreshVCCData(Me.Session, _VCCOrders)

            Catch ex As Exception
                Refreshed = False
            End Try

            If Refreshed Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    Try

                        _VCCOrders = LoadVCCOrders()

                    Catch ex As Exception

                    End Try

                    If _VCCOrders Is Nothing Then

                        _VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

                    End If

                    LoadGrid()

                    LoadVCCOrderDetails()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            Else

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

                AdvantageFramework.WinForm.MessageBox.Show("Failed trying to connect to service.")

            End If

        End Sub
        Private Sub DataGridViewForm_VCCOrders_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_VCCOrders.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadVCCOrderDetails()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_InvalidDataOrExpirationDate_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_InvalidDataOrExpirationDate.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_InvalidDataOrExpirationDate.Checked Then

                    ButtonItemSummaryResults_InvalidDataOrExpirationDate.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_InvalidDataOrExpirationDate.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_SettledInBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_SettledInBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_SettledInBalance.Checked Then

                    ButtonItemSummaryResults_SettledInBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_SettledInBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_SettledOutOfBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_SettledOutOfBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_SettledOutOfBalance.Checked Then

                    ButtonItemSummaryResults_SettledOutOfBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_SettledOutOfBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsDeclined_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsDeclined.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsDeclined.Checked Then

                    ButtonItemSummaryResults_TransactionsDeclined.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsDeclined.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsDeclinedAfterApporval_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Checked Then

                    ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsInBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsInBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsInBalance.Checked Then

                    ButtonItemSummaryResults_TransactionsInBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsInBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_TransactionsOutOfBalance_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_TransactionsOutOfBalance.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_TransactionsOutOfBalance.Checked Then

                    ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_TransactionsOutOfBalance.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_VCCCreditCardsIssued_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_VCCCreditCardsIssued.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_VCCCreditCardsIssued.Checked Then

                    ButtonItemSummaryResults_VCCCreditCardsIssued.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_VCCCreditCardsIssued.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub
        Private Sub ButtonItemSummaryResults_VCCIssuedAndUpdated_Click(sender As Object, e As EventArgs) Handles ButtonItemSummaryResults_VCCIssuedAndUpdated.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked Then

                    ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = False

                Else

                    ClearFilters()
                    ButtonItemSummaryResults_VCCIssuedAndUpdated.Checked = True

                End If

                FilterLoadGrid()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace