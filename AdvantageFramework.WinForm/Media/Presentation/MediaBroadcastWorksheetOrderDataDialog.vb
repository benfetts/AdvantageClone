Namespace Media.Presentation

	Public Class MediaBroadcastWorksheetOrderDataDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketOrderDataViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
		Protected _MediaBroadcastWorksheetID As Integer = 0
		Protected _MediaBroadcastWorksheetMarketID As Integer = 0
		Protected _RevisionNumber As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer, RevisionNumber As Integer)

			' This call is required by the Windows Form Designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
			_MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
			_RevisionNumber = RevisionNumber

		End Sub
		Private Sub LoadViewModel()

			_ViewModel = _Controller.MarketOrderData_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID, _RevisionNumber)

		End Sub
		Private Sub LoadRevisionNumbers()

			'objects
			Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

			BindingSource = New System.Windows.Forms.BindingSource

			BindingSource.DataSource = (From RevisionNumber In _ViewModel.SelectedWorksheetMarketRevisionNumbers
										Select RevisionNumberText = Format(RevisionNumber, "000"),
											   RevisionNumber = RevisionNumber).ToList

			ComboBoxItemRevisions_Revisions.ComboBoxEx.DataSource = BindingSource

			ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarketRevisionNumber

		End Sub
		Private Sub LoadGrid_WorksheetDetail()

			DataGridViewLeftSection_MarketDetails.DataSource = _ViewModel.RevisionWorksheetMarketDetails

		End Sub
		Private Sub LoadGrid_WorksheetDetailDate()

			DataGridViewRightSection_MarketDetailData.DataSource = _ViewModel.SelectedWorksheetMarketDetailDates.ToList

		End Sub
		Private Sub FormatGrid_WorksheetDetail()

			For Each GridColumn In DataGridViewLeftSection_MarketDetails.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

				GridColumn.Visible = False

			Next

			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.DefaultRate.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.ValueAdded.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Bookend.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Comments.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.EndTime.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.StartTime.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Saturday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Friday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Thursday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Wednesday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Tuesday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Monday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Sunday.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Days.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Length.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Piggyback.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Product.ToString).Visible = True

			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.DaypartCode.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.DaypartCode.ToString).Caption = "Daypart"

			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.Program.ToString).Visible = True

			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.CableNetworkStationDescription.ToString).Visible = True
			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.CableNetworkStationDescription.ToString).Caption = "Cable Network"

			DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.VendorName.ToString).Visible = True
			DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.VendorName.ToString).Caption = "Vendor"

			'DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.RevisionNumber.ToString).Visible = True
			DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.LineNumber.ToString).Visible = True
			DataGridViewLeftSection_MarketDetails.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.OnHold.ToString).Visible = True

		End Sub
		Private Sub FormatGrid_WorksheetDetailDate()

			For Each GridColumn In DataGridViewRightSection_MarketDetailData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

				GridColumn.Visible = False

			Next

			DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.OrderLineNumber.ToString).Visible = True
			DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.OrderNumber.ToString).Visible = True
            'DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.LinkLineID.ToString).Visible = True
            'DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.LinkID.ToString).Visible = True
            DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.Spots.ToString).Visible = True
			DataGridViewRightSection_MarketDetailData.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate.Properties.Date.ToString).Visible = True

		End Sub
		Private Sub RefreshViewModel()



		End Sub
		Private Sub SetControlPropertySettings()

			DataGridViewLeftSection_MarketDetails.OptionsBehavior.Editable = False
			DataGridViewLeftSection_MarketDetails.MultiSelect = False

			DataGridViewRightSection_MarketDetailData.OptionsBehavior.Editable = False
			DataGridViewRightSection_MarketDetailData.MultiSelect = False
			DataGridViewRightSection_MarketDetailData.ModifyColumnSettingsOnEachDataSource = False

			ComboBoxItemRevisions_Revisions.ComboBoxEx.DisplayMember = "RevisionNumberText"
			ComboBoxItemRevisions_Revisions.ComboBoxEx.ValueMember = "RevisionNumber"

			Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer, RevisionNumber As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaBroadcastWorksheetOrderDataDialog As Media.Presentation.MediaBroadcastWorksheetOrderDataDialog = Nothing

			MediaBroadcastWorksheetOrderDataDialog = New Media.Presentation.MediaBroadcastWorksheetOrderDataDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID, RevisionNumber)

			ShowFormDialog = MediaBroadcastWorksheetOrderDataDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaBroadcastWorksheetOrderDataDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			_Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub MediaBroadcastWorksheetOrderDataDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

			LoadViewModel()

			LoadRevisionNumbers()

			DataGridViewLeftSection_MarketDetails.CurrentView.BeginUpdate()

			LoadGrid_WorksheetDetail()

			FormatGrid_WorksheetDetail()

			RefreshViewModel()

			DataGridViewLeftSection_MarketDetails.CurrentView.EndUpdate()

			DataGridViewLeftSection_MarketDetails.CurrentView.BestFitColumns()
			'====================================================
			_Controller.MarketOrderData_SelectedWorksheetMarketDetailChanged(_ViewModel, DataGridViewLeftSection_MarketDetails.CurrentView.GetFocusedRow)

			DataGridViewRightSection_MarketDetailData.CurrentView.BeginUpdate()

			LoadGrid_WorksheetDetailDate()

			FormatGrid_WorksheetDetailDate()

			DataGridViewRightSection_MarketDetailData.CurrentView.EndUpdate()

			DataGridViewRightSection_MarketDetailData.CurrentView.BestFitColumns()

			RefreshViewModel()

			Me.ClearChanged()

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ComboBoxItemRevisions_Revisions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemRevisions_Revisions.SelectedIndexChanged

			If _ViewModel IsNot Nothing AndAlso
					Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

				_Controller.MarketOrderData_ChangeSelectedWorksheetMarketRevisionNumber(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

				DataGridViewLeftSection_MarketDetails.CurrentView.BeginUpdate()

				LoadGrid_WorksheetDetail()

				FormatGrid_WorksheetDetail()

				DataGridViewLeftSection_MarketDetails.CurrentView.EndUpdate()

				DataGridViewLeftSection_MarketDetails.CurrentView.BestFitColumns()
				'====================================================
				_Controller.MarketOrderData_SelectedWorksheetMarketDetailChanged(_ViewModel, DataGridViewLeftSection_MarketDetails.CurrentView.GetFocusedRow)

				DataGridViewRightSection_MarketDetailData.CurrentView.BeginUpdate()

				LoadGrid_WorksheetDetailDate()

				FormatGrid_WorksheetDetailDate()

				DataGridViewRightSection_MarketDetailData.CurrentView.EndUpdate()

				DataGridViewRightSection_MarketDetailData.CurrentView.BestFitColumns()

				RefreshViewModel()

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			End If

		End Sub
		Private Sub DataGridViewLeftSection_MarketDetails_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_MarketDetails.FocusedRowChangedEvent

			If _ViewModel IsNot Nothing AndAlso Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

				_Controller.MarketOrderData_SelectedWorksheetMarketDetailChanged(_ViewModel, DataGridViewLeftSection_MarketDetails.CurrentView.GetFocusedRow)

				DataGridViewRightSection_MarketDetailData.CurrentView.BeginUpdate()

				LoadGrid_WorksheetDetailDate()

				DataGridViewRightSection_MarketDetailData.CurrentView.EndUpdate()

			End If

		End Sub
		Private Sub DataGridViewLeftSection_MarketDetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewLeftSection_MarketDetails.CustomColumnDisplayTextEvent

			'objects
			Dim WorksheetMarketDetail As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail = Nothing

			If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail.Properties.LineNumber.ToString Then

				If DataGridViewLeftSection_MarketDetails.CurrentView.IsValidRowHandle(e.ListSourceRowIndex) Then

					WorksheetMarketDetail = DataGridViewLeftSection_MarketDetails.CurrentView.GetRow(DataGridViewLeftSection_MarketDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex))

					If WorksheetMarketDetail IsNot Nothing Then

						If WorksheetMarketDetail.MakegoodNumber > 0 Then

							e.DisplayText = Format(WorksheetMarketDetail.LineNumber, "0000") & "-" & Format(WorksheetMarketDetail.MakegoodNumber, "00")

						Else

							e.DisplayText = Format(e.Value, "0000")

						End If

					Else

						e.DisplayText = Format(e.Value, "0000")

					End If

				End If

			End If

		End Sub
        Private Sub DataGridViewLeftSection_MarketDetails_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_MarketDetails.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_MarketDetails.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
