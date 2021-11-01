Namespace WinForm.MVC.Presentation.Controls

    Public Class ShareHPUTBookControl

        Public Event ShareHPUTBookInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event ShareHPUTBookSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ShareHPUTBookChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _MediaSpotTVResearchID As Nullable(Of Integer) = Nothing
        Private _MarketCode As String = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
        Private _ShowCustomButtons As Boolean = False
        Private _RatingsServiceID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel
            Get
                ViewModel = _ViewModel
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.Media.ShareHPUTBookController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                    DataGridViewControl_ShareHPUTBook.CurrentView.OptionsMenu.EnableColumnMenu = False

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            DataGridViewControl_ShareHPUTBook.DataSource = _ViewModel.ShareHPUTBooks

            For Each GridColumn In DataGridViewControl_ShareHPUTBook.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        If GridColumn.FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.ShareBookID.ToString OrElse GridColumn.FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString Then

                            SubItemGridLookUpEditControl.DataSource = _ViewModel.RepositoryNielsenTVBooks.OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort)

                            If SubItemGridLookUpEditControl.View.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.ID) IsNot Nothing Then

                                SubItemGridLookUpEditControl.View.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.ID).Visible = False

                            End If

                        End If

                    End If

                End If

            Next

        End Sub
        Private Sub RefreshViewModel(Load As Boolean)

            If Load Then

                LoadGrid()

            Else

                DataGridViewControl_ShareHPUTBook.CurrentView.RefreshData()

            End If

            For Each RadioButtonControl In GroupBoxControl_Latest.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)

                RadioButtonControl.Enabled = False

            Next

            For Each RadioButtonControl In GroupBoxControl_Latest.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Tag = "LO" AndAlso _ViewModel.LatestLOEnabled Then

                    RadioButtonControl.Enabled = True
                    RadioButtonControl.Checked = _ViewModel.UseLatest AndAlso RadioButtonControl.Tag = _ViewModel.LatestStream

                ElseIf RadioButtonControl.Tag = "LS" AndAlso _ViewModel.LatestLSEnabled Then

                    RadioButtonControl.Enabled = True
                    RadioButtonControl.Checked = _ViewModel.UseLatest AndAlso RadioButtonControl.Tag = _ViewModel.LatestStream

                ElseIf RadioButtonControl.Tag = "L1" AndAlso _ViewModel.LatestL1Enabled Then

                    RadioButtonControl.Enabled = True
                    RadioButtonControl.Checked = _ViewModel.UseLatest AndAlso RadioButtonControl.Tag = _ViewModel.LatestStream

                ElseIf RadioButtonControl.Tag = "L3" AndAlso _ViewModel.LatestL3Enabled Then

                    RadioButtonControl.Enabled = True
                    RadioButtonControl.Checked = _ViewModel.UseLatest AndAlso RadioButtonControl.Tag = _ViewModel.LatestStream

                ElseIf RadioButtonControl.Tag = "L7" AndAlso _ViewModel.LatestL7Enabled Then

                    RadioButtonControl.Enabled = True
                    RadioButtonControl.Checked = _ViewModel.UseLatest AndAlso RadioButtonControl.Tag = _ViewModel.LatestStream

                End If

            Next

            CheckBoxControl_UseLatest.Checked = _ViewModel.UseLatest
            GroupBoxControl_Latest.Enabled = _ViewModel.UseLatest

            DataGridViewControl_ShareHPUTBook.Enabled = Not _ViewModel.UseLatest

            If DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.CustomButtons.Count > 2 Then

                DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = _ShowCustomButtons
                DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.CustomButtons.Item(3).Visible = _ShowCustomButtons

                DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Enabled = DataGridViewControl_ShareHPUTBook.HasOnlyOneSelectedRow AndAlso
                    DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle > 0

                DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.CustomButtons.Item(3).Enabled = DataGridViewControl_ShareHPUTBook.HasOnlyOneSelectedRow AndAlso
                    DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle <> DataGridViewControl_ShareHPUTBook.CurrentView.RowCount - 1

            End If

        End Sub
        Private Sub AddNavigatorCustomButtons(ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, ImageCollection As DevExpress.Utils.ImageCollection)

            'objects
            Dim Button As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            Button = DataGridView.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = True
            Button.Visible = True
            Button.Hint = "Move Up"
            Button.ImageIndex = ImageCollection.Images.Count - 2

            Button = DataGridView.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = True
            Button.Visible = True
            Button.Hint = "Move Down"
            Button.ImageIndex = ImageCollection.Images.Count - 1

        End Sub

#Region "  Public "

        Public Sub CancelAddNewShareHPUTBook()

            DataGridViewControl_ShareHPUTBook.CancelNewItemRow()

        End Sub
        Public Sub ClearControl()

            CheckBoxControl_UseLatest.Checked = False
            GroupBoxControl_Latest.Enabled = False
            DataGridViewControl_ShareHPUTBook.ClearDatasource()

        End Sub
        Public Sub DeleteSelectedBooks()

            _Controller.DeleteSelectedBooks(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Public Function LoadControl(MediaSpotTVResearchID As Integer?, MarketCode As String, ShowCustomButtons As Boolean, RatingsServiceID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _MediaSpotTVResearchID = MediaSpotTVResearchID
            _MarketCode = MarketCode
            _ShowCustomButtons = ShowCustomButtons
            _RatingsServiceID = RatingsServiceID

            _ViewModel = _Controller.Load(_MediaSpotTVResearchID, _MarketCode, _RatingsServiceID)

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            RefreshViewModel(True)

            DataGridViewControl_ShareHPUTBook.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub ShareHPUTBookControl_Load(sender As Object, e As EventArgs) Handles Me.Load

            'objects
            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing

            ImageCollection = DataGridViewControl_ShareHPUTBook.EmbeddedNavigator.Buttons.DefaultImageList
            ImageCollection.AddImage(AdvantageFramework.My.Resources.UpImage)
            ImageCollection.AddImage(AdvantageFramework.My.Resources.DownImage)

            DataGridViewControl_ShareHPUTBook.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewControl_ShareHPUTBook.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewControl_ShareHPUTBook.CurrentView.OptionsCustomization.AllowSort = False

            AddNavigatorCustomButtons(DataGridViewControl_ShareHPUTBook, ImageCollection)

            If _Controller IsNot Nothing Then

                _Controller.SetSelectedShareHPUTBooks(_ViewModel, DataGridViewControl_ShareHPUTBook.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.ShareHPUTBook))

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_UseLatest_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_UseLatest.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If e.NewChecked.Checked Then

                    If Not _Controller.GetLatestStreamsAvailable(_ViewModel) Then

                        e.NewChecked.Checked = False
                        AdvantageFramework.WinForm.MessageBox.Show("No streams exist for this market.")

                    Else

                        RefreshViewModel(False)

                        RaiseEvent ShareHPUTBookChanged()

                    End If

                Else

                    _Controller.UseLatest(_ViewModel, False, Nothing)

                    RefreshViewModel(False)

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_ShareHPUTBook.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.ShareBookID.ToString AndAlso e.Value Is Nothing Then

                DirectCast(DataGridViewControl_ShareHPUTBook.CurrentView.GetRow(DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ShareHPUTBook).HPUTBookID = Nothing

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_ShareHPUTBook.EmbeddedNavigatorButtonClick

            'objects
            Dim SelectedID As Guid = Nothing

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewControl_ShareHPUTBook.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteSelectedBooks()

                        _Controller.SetSelectedShareHPUTBooks(_ViewModel, DataGridViewControl_ShareHPUTBook.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.ShareHPUTBook))

                        _Controller.ValidateShareHPUTBooks(_ViewModel)

                        RefreshViewModel(False)

                        RaiseEvent ShareHPUTBookChanged()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Custom

                        _Controller.SetSelectedShareHPUTBooks(_ViewModel, DataGridViewControl_ShareHPUTBook.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.ShareHPUTBook))

                        SelectedID = DirectCast(DataGridViewControl_ShareHPUTBook.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.ShareHPUTBook).ID

                        If e.Button.Hint = "Move Up" Then

                            _Controller.MoveBook(_ViewModel, DataGridViewControl_ShareHPUTBook.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.ShareHPUTBookController.MoveItemDirection.Up)

                        ElseIf e.Button.Hint = "Move Down" Then

                            _Controller.MoveBook(_ViewModel, DataGridViewControl_ShareHPUTBook.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.ShareHPUTBookController.MoveItemDirection.Down)

                        End If

                        DataGridViewControl_ShareHPUTBook.SelectRow(0, SelectedID)

                        RefreshViewModel(False)

                        RaiseEvent ShareHPUTBookChanged()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_ShareHPUTBook.InitNewRowEvent

            RaiseEvent ShareHPUTBookInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_ShareHPUTBook.QueryPopupNeedDatasourceEvent

            Dim ShareBookID As Nullable(Of Integer) = Nothing

            If FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.ShareBookID.ToString OrElse FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString Then

                If FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString Then

                    ShareBookID = DirectCast(DataGridViewControl_ShareHPUTBook.CurrentView.GetRow(DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ShareHPUTBook).ShareBookID

                End If

                Datasource = _Controller.GetRepositoryNielsenTVBooks(_ViewModel, ShareBookID).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort)
                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_ShareHPUTBook.SelectionChangedEvent

            _Controller.SetSelectedShareHPUTBooks(_ViewModel, DataGridViewControl_ShareHPUTBook.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.ShareHPUTBook))

            RefreshViewModel(False)

            RaiseEvent ShareHPUTBookSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_ShareHPUTBook.ShowingEditorEvent

            If DataGridViewControl_ShareHPUTBook.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString Then

                If DirectCast(DataGridViewControl_ShareHPUTBook.CurrentView.GetRow(DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ShareHPUTBook) Is Nothing OrElse
                        DirectCast(DataGridViewControl_ShareHPUTBook.CurrentView.GetRow(DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ShareHPUTBook).ShareBookID.HasValue = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_ShareHPUTBook.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(_ViewModel, e.Row, e.Valid)

                If DataGridViewControl_ShareHPUTBook.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    _Controller.ValidateShareHPUTBooks(_ViewModel)

                    e.Valid = True

                    RefreshViewModel(False)

                Else

                    DataGridViewControl_ShareHPUTBook.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        RefreshViewModel(False)

                        DataGridViewControl_ShareHPUTBook.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                        DataGridViewControl_ShareHPUTBook.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    End If

                End If

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub
        Private Sub DataGridViewControl_ShareHPUTBook_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_ShareHPUTBook.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.ShareHPUTBook = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewControl_ShareHPUTBook.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(_ViewModel, FocusedRow, DataGridViewControl_ShareHPUTBook.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewControl_ShareHPUTBook.CurrentView.SetColumnError(DataGridViewControl_ShareHPUTBook.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub RadioButtonLatest_L1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLatest_L1.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _Controller.SetLatestStream(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag)

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub
        Private Sub RadioButtonLatest_L3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLatest_L3.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _Controller.SetLatestStream(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag)

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub
        Private Sub RadioButtonLatest_L7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLatest_L7.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _Controller.SetLatestStream(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag)

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub
        Private Sub RadioButtonLatest_LS_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLatest_LS.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _Controller.SetLatestStream(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag)

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub
        Private Sub RadioButtonLatest_LV_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLatest_LV.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _Controller.SetLatestStream(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag)

                RaiseEvent ShareHPUTBookChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
