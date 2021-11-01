Namespace WinForm.Presentation.Maintenance

    Public Class ClientOrderDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderViewModel = Nothing
        Protected _Controller As NielsenFramework.Controller.Maintenance.ClientOrderSetupController = Nothing
        Protected _ConnectionString As String = Nothing
        Protected _ClientID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ConnectionString As String, ClientID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString
            _ClientID = ClientID

        End Sub
        Private Sub LoadSelectedClientOrder()

            ClientOrderControlRightSection_Order.ClearControl()

            If DataGridViewLeftSection_ClientOrders.HasASelectedRow Then

                _Controller.ClientOrderSelectionChanged(_ViewModel, DataGridViewLeftSection_ClientOrders.GetRowDataBoundItem(DataGridViewLeftSection_ClientOrders.CurrentView.FocusedRowHandle))

                If ClientOrderControlRightSection_Order.LoadControl(_ConnectionString, _ViewModel.SelectedClientOrder.ClientID,
                                                                    _ViewModel.SelectedClientOrder.OrderType, _ViewModel.SelectedClientOrder.ID) = False Then

                    ClientOrderControlRightSection_Order.ClearControl()
                    ClientOrderControlRightSection_Order.Enabled = False

                Else

                    ClearChanged()
                    ClearValidations()
                    ClientOrderControlRightSection_Order.Enabled = True

                End If

            Else

                _Controller.ClientOrderSelectionChanged(_ViewModel, Nothing)

                ClearChanged()
                ClearValidations()
                ClientOrderControlRightSection_Order.Enabled = False

            End If

            RefreshViewModel(False)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            CheckForUnsavedChanges = ClientOrderControlRightSection_Order.CheckForUnsavedChanges(_ViewModel)

        End Function
        Private Function Save() As Boolean

            'objects
            Dim ClientOrderID As Integer = 0
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_ClientOrders.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    If Not ClientOrderControlRightSection_Order.Save(ErrorMessage, ClientOrderID) Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    Else

                        Saved = True

                        RefreshViewModel(True)

                        DataGridViewLeftSection_ClientOrders.SelectRow(0, ClientOrderID)

                        Me.ClearChanged()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an order to save.")

            End If

            Save = Saved

        End Function
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            Dim OrderType As String = String.Empty

            If ButtonItemView_SpotTV.Checked Then

                OrderType = "T"

            ElseIf ButtonItemView_Radio.Checked Then

                OrderType = "R"

            ElseIf ButtonItemView_RadioCounty.Checked Then

                OrderType = "C"

            End If

            If LoadGrid Then

                _ViewModel = _Controller.Load(_ClientID, OrderType)

                DataGridViewLeftSection_ClientOrders.DataSource = Nothing
                DataGridViewLeftSection_ClientOrders.DataSource = _ViewModel.ClientOrders
                DataGridViewLeftSection_ClientOrders.CurrentView.BestFitColumns()

                LoadSelectedClientOrder()

            Else

                DataGridViewLeftSection_ClientOrders.CurrentView.RefreshData()

            End If

            RibbonBarOptions_States.Visible = (OrderType = "C")
            RibbonBarOptions_Markets.Visible = Not (OrderType = "C")

            'ButtonItemActions_Save.Enabled = ClientOrderControlRightSection_Order.Enabled AndAlso AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me.ClientOrderControlRightSection_Order)

            ButtonItemActions_Delete.Enabled = ClientOrderControlRightSection_Order.Enabled AndAlso DataGridViewLeftSection_ClientOrders.HasOnlyOneSelectedRow
            ButtonItemActions_Copy.Enabled = ClientOrderControlRightSection_Order.Enabled AndAlso DataGridViewLeftSection_ClientOrders.HasOnlyOneSelectedRow

            ButtonItemMarket_Cancel.Enabled = ClientOrderControlRightSection_Order.MarketCancelEnabled
            ButtonItemMarket_Delete.Enabled = ClientOrderControlRightSection_Order.MarketDeleteEnabled

            ButtonItemState_Cancel.Enabled = ClientOrderControlRightSection_Order.StateCancelEnabled
            ButtonItemState_Delete.Enabled = ClientOrderControlRightSection_Order.StateDeleteEnabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ConnectionString As String, ClientID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim ClientOrderDialog As WinForm.Presentation.Maintenance.ClientOrderDialog = Nothing

            ClientOrderDialog = New WinForm.Presentation.Maintenance.ClientOrderDialog(ConnectionString, ClientID)

            ShowFormDialog = ClientOrderDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientOrderDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemView_SpotTV.Image = AdvantageFramework.My.Resources.BroadcastOrdersTVImage
            ButtonItemView_Radio.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage
            ButtonItemView_RadioCounty.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage

            ButtonItemMarket_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemMarket_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemState_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemState_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemView_SpotTV.Checked = True

            DataGridViewLeftSection_ClientOrders.OptionsBehavior.Editable = False

            _Controller = New NielsenFramework.Controller.Maintenance.ClientOrderSetupController(_ConnectionString)

            _ViewModel = _Controller.Load(_ClientID, "T")

            Me.Text = "Order(s) for Client: " & _ViewModel.ClientName

        End Sub
        Private Sub ClientOrderDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientOrderDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientOrderDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ClientOrders.DataSource = _ViewModel.ClientOrders

            DataGridViewLeftSection_ClientOrders.CurrentView.BestFitColumns()

            DataGridViewLeftSection_ClientOrders.FocusToFindPanel(True)

            ClientOrderControlRightSection_Order.Enabled = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            RefreshViewModel(False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ContinueAdd As Boolean = True
            Dim ClientOrderID As Integer = 0
            Dim OrderType As String = Nothing

            If DataGridViewLeftSection_ClientOrders.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If ButtonItemView_SpotTV.Checked Then

                    OrderType = "T"

                ElseIf ButtonItemView_Radio.Checked Then

                    OrderType = "R"

                ElseIf ButtonItemView_RadioCounty.Checked Then

                    OrderType = "C"

                End If

                If WinForm.Presentation.Maintenance.ClientOrderEditDialog.ShowFormDialog(_ConnectionString, _ClientID, _ViewModel.ClientName, OrderType, ClientOrderID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    RefreshViewModel(True)

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_ClientOrders.SelectRow(ClientOrderID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ClientOrder As NielsenFramework.DTO.ClientOrder = Nothing
            Dim ClientOrderID As Integer = 0

            ClientOrder = DataGridViewLeftSection_ClientOrders.GetFirstSelectedRowDataBoundItem

            If WinForm.Presentation.Maintenance.ClientOrderEditDialog.ShowFormDialog(_ConnectionString, ClientOrder.ClientID, _ViewModel.ClientName, ClientOrder.OrderType, ClientOrder.ID, ClientOrderID) = System.Windows.Forms.DialogResult.OK Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                RefreshViewModel(True)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewLeftSection_ClientOrders.SelectRow(ClientOrderID)

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewLeftSection_ClientOrders.Print(DefaultLookAndFeel.LookAndFeel, "Client Orders", Nothing, Me.Session)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_ClientOrders.HasASelectedRow Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Deleting

                If ClientOrderControlRightSection_Order.Delete() Then

                    ClientOrderControlRightSection_Order.ClearControl()

                    RefreshViewModel(True)

                    Me.ClearChanged()

                    LoadSelectedClientOrder()

                End If

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemMarket_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemMarket_Cancel.Click

            ClientOrderControlRightSection_Order.CancelAddNewMarket()
            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemMarket_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemMarket_Delete.Click

            ClientOrderControlRightSection_Order.DeleteSelectedMarkets()
            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemState_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemState_Cancel.Click

            ClientOrderControlRightSection_Order.CancelAddNewState()
            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemState_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemState_Delete.Click

            ClientOrderControlRightSection_Order.DeleteSelectedStates()
            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemView_Radio_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Radio.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_Radio.Checked Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                RefreshViewModel(True)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_Radio_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_Radio.OptionGroupChanging

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemView_RadioCounty_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_RadioCounty.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_RadioCounty.Checked Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                RefreshViewModel(True)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_RadioCounty_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_RadioCounty.OptionGroupChanging

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemView_SpotTV_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_SpotTV.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_SpotTV.Checked Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                RefreshViewModel(True)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_SpotTV_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_SpotTV.OptionGroupChanging

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ClientOrderControlRightSection_Order_MarketInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientOrderControlRightSection_Order.MarketInitNewRowEvent

            RefreshViewModel(False)

        End Sub
        Private Sub ClientOrderControlRightSection_Order_MarketSelectionChangedEvent(sender As Object, e As EventArgs) Handles ClientOrderControlRightSection_Order.MarketSelectionChangedEvent

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewLeftSection_ClientOrders_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_ClientOrders.BeforeLeaveRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientOrders_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_ClientOrders.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadSelectedClientOrder()

                _Controller.ClientOrderSelectionChanged(_ViewModel, DataGridViewLeftSection_ClientOrders.GetFirstSelectedRowDataBoundItem)

                RefreshViewModel(False)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ClientOrderControlRightSection_Order_StateInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientOrderControlRightSection_Order.StateInitNewRowEvent

            RefreshViewModel(False)

        End Sub
        Private Sub ClientOrderControlRightSection_Order_StateSelectionChangedEvent(sender As Object, e As EventArgs) Handles ClientOrderControlRightSection_Order.StateSelectionChangedEvent

            RefreshViewModel(False)

        End Sub

#End Region

#End Region

    End Class

End Namespace