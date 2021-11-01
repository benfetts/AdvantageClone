Namespace Maintenance.Billing.Presentation

    Public Class RateFlagStructureSetupForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum CheckBoxType
            Images
            Standard
            Blank
            NoEdit
        End Enum

#End Region

#Region " Variables "

        Private _RepositoryItemCheckEdit_Images As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _RepositoryItemCheckEdit_Standard As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _RepositoryItemCheckEdit_NoEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _DownGridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
        Private _UserHasAccessToStructure As Boolean = Nothing
        Private _UserHasAccessToEntry As Boolean = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Dim AFActiveFilterString As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AFActiveFilterString = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.AFActiveFilterString

                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.AFActiveFilterString = String.Empty

                BandedDataGridViewLeftSection_RateFlagLevels.DataSource = AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).OrderByDescending(Function(Entity) Entity.Number).ToList

                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.BestFitColumns()

                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.AFActiveFilterString = AFActiveFilterString

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            RateFlagEntryControlRightSection_RateFlag.ClearControl()

            RateFlagEntryControlRightSection_RateFlag.Enabled = (BandedDataGridViewLeftSection_RateFlagLevels.HasOnlyOneSelectedRow AndAlso Not BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle))

            If RateFlagEntryControlRightSection_RateFlag.Enabled Then

                RateFlagEntryControlRightSection_RateFlag.Enabled = RateFlagEntryControlRightSection_RateFlag.LoadControl(BillingRateLevelID:=BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowBookmarkValue, ShowDescriptions:=ButtonItemDetails_ShowDescriptions.Checked)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub ModifyColumn(ByVal Cell As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs, ByVal IsNewItemRow As Boolean, ByVal CheckBoxType As CheckBoxType)

            If IsNewItemRow Then

                If Cell.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString OrElse
                   Cell.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString OrElse
                   Cell.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString Then

                    If CBool(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRowCellValue(Cell.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFunctionIncluded.ToString)) Then

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Standard

                    Else

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                Else

                    Cell.RepositoryItem = _RepositoryItemCheckEdit_Standard

                End If

            Else

                Select Case CheckBoxType

                    Case RateFlagStructureSetupForm.CheckBoxType.Blank

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    Case RateFlagStructureSetupForm.CheckBoxType.Images

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Images
                        Cell.RepositoryItem.ReadOnly = True

                    Case RateFlagStructureSetupForm.CheckBoxType.Standard

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Standard

                    Case RateFlagStructureSetupForm.CheckBoxType.NoEdit

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_NoEdit
                        Cell.RepositoryItem.ReadOnly = True

                End Select

            End If

        End Sub
        Private Sub ModifyColumn(ByVal Cell As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs, ByVal IsNewItemRow As Boolean, ByVal IsStandardCheckbox As Boolean, Optional ByVal IsBlank As Boolean = False)

            If IsNewItemRow Then

                Cell.RepositoryItem = _RepositoryItemCheckEdit_Standard

            Else

                If IsStandardCheckbox Then

                    If IsBlank Then

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    Else

                        Cell.RepositoryItem = _RepositoryItemCheckEdit_Standard

                    End If

                Else

                    Cell.RepositoryItem = _RepositoryItemCheckEdit_Images
                    Cell.RepositoryItem.ReadOnly = True

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ' objects 
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If _UserHasAccessToStructure = True Then

                If BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle) Then

                    ButtonItemActions_MoveUp.Enabled = False
                    ButtonItemActions_MoveDown.Enabled = False
                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Delete.Enabled = False

                Else

                    Try

                        BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        BillingRateLevel = Nothing
                    End Try

                    If BillingRateLevel IsNot Nothing Then

                        RibbonBarOptions_Actions.Enabled = True

                        If BandedDataGridViewLeftSection_RateFlagLevels.Enabled Then

                            If CBool(BillingRateLevel.IsRequired.GetValueOrDefault(0)) Then

                                ButtonItemActions_MoveUp.Enabled = False
                                ButtonItemActions_MoveDown.Enabled = False
                                ButtonItemActions_Cancel.Enabled = False
                                ButtonItemActions_Delete.Enabled = False

                            Else

                                ButtonItemActions_MoveUp.Enabled = Not BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsFirstRow

                                If BillingRateLevel.Number = 2 Then

                                    ButtonItemActions_MoveDown.Enabled = False

                                Else

                                    ButtonItemActions_MoveDown.Enabled = True

                                End If

                                ButtonItemActions_Cancel.Enabled = False
                                ButtonItemActions_Delete.Enabled = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsFocusedView

                            End If

                        Else

                            ButtonItemActions_MoveUp.Enabled = False
                            ButtonItemActions_MoveDown.Enabled = False
                            ButtonItemActions_Cancel.Enabled = False
                            ButtonItemActions_Delete.Enabled = False

                        End If

                    Else

                        RibbonBarOptions_Actions.Enabled = False

                    End If

                End If

            Else

                ButtonItemActions_MoveUp.Enabled = False
                ButtonItemActions_MoveDown.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.OptionsBehavior.Editable = False
                BandedDataGridViewLeftSection_RateFlagLevels.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            End If

            If _UserHasAccessToEntry Then

                ButtonItemActions_ViewAll.Enabled = True

                If ButtonItemActions_ViewAll.Checked Then

                    ButtonItemUpdate_FeeFlagUpdate.Enabled = True
                    ButtonItemDetails_Delete.Enabled = False
                    ButtonItemDetails_Copy.Enabled = False
                    ButtonItemDetails_CopyByCDP.Enabled = False
                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Save.Enabled = False
                    ButtonItemDetails_ShowDescriptions.Enabled = False

                Else

                    ButtonItemDetails_Delete.Enabled = If(RateFlagEntryControlRightSection_RateFlag.ViewingAll, False, RateFlagEntryControlRightSection_RateFlag.HasASelectedBillingRateDetail)
                    ButtonItemDetails_Copy.Enabled = If(RateFlagEntryControlRightSection_RateFlag.ViewingAll = False AndAlso RateFlagEntryControlRightSection_RateFlag.AllowBillingRateDetailCopy AndAlso RateFlagEntryControlRightSection_RateFlag.HasASelectedBillingRateDetail, True, False)
                    ButtonItemDetails_CopyByCDP.Enabled = If(RateFlagEntryControlRightSection_RateFlag.ViewingAll = False AndAlso RateFlagEntryControlRightSection_RateFlag.AllowCopyByCDP, True, False)
                    ButtonItemDetails_Cancel.Enabled = RateFlagEntryControlRightSection_RateFlag.IsSelectedDetailNewItemRow
                    ButtonItemDetails_Save.Enabled = Me.UserEntryChanged
                    ButtonItemUpdate_FeeFlagUpdate.Enabled = False
                    ButtonItemDetails_ShowDescriptions.Enabled = True

                End If

            Else

                ButtonItemActions_ViewAll.Enabled = False
                ButtonItemUpdate_FeeFlagUpdate.Enabled = False
                ButtonItemDetails_Export.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                ButtonItemDetails_Copy.Enabled = False
                ButtonItemDetails_CopyByCDP.Enabled = False
                ButtonItemDetails_Save.Enabled = False
                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Calculate.Enabled = False
                ButtonItemDetails_ShowDescriptions.Enabled = False
                RateFlagEntryControlRightSection_RateFlag.DisableEdit()

            End If

        End Sub
        Private Sub LoadGridBands()

            'objects
            Dim StructureGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim LevelsGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim OptionsGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            StructureGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            StructureGridBand.Caption = "Rate Structure"
            StructureGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            StructureGridBand.AppearanceHeader.Options.UseTextOptions = True

            LevelsGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            LevelsGridBand.Caption = "Levels to Include"
            LevelsGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            LevelsGridBand.AppearanceHeader.Options.UseTextOptions = True

            OptionsGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            OptionsGridBand.Caption = "Options to Include"
            OptionsGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            OptionsGridBand.AppearanceHeader.Options.UseTextOptions = True

            BlankGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            BlankGridBand.Caption = " "
            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True

            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Bands.Add(StructureGridBand)
            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Bands.Add(LevelsGridBand)
            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Bands.Add(OptionsGridBand)
            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Bands.Add(BlankGridBand)

            For Each GridColumn In BandedDataGridViewLeftSection_RateFlagLevels.Columns

                If GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Number.ToString OrElse
                   GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Description.ToString Then

                    StructureGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsSalesClassIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFunctionIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeTitleIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEffectiveDateIncluded.ToString Then

                    LevelsGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsBillingRateDetailIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsNonBillableIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFeeTimeIncluded.ToString Then

                    OptionsGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsInactive.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)

                Else

                    BlankGridBand.Columns.Add(GridColumn)

                    GridColumn.Visible = False

                End If

            Next

            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = RateFlagEntryControlRightSection_RateFlag.Save

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If BandedDataGridViewLeftSection_RateFlagLevels.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If RateFlagEntryControlRightSection_RateFlag.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    If ErrorMessage = "" Then

                        Saved = True

                        RateFlagEntryControlRightSection_RateFlag.DisableInactiveFilter = True

                        BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GridViewSelectionChanged()

                        RateFlagEntryControlRightSection_RateFlag.DisableInactiveFilter = False

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a rate/flag to save.")

            End If

            Save = Saved

        End Function
        Private Sub SetNearestCanFocusColumn(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim NextGridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim IsIncluded As Boolean = False

            NextGridColumn = GridColumn

            Try

                While NextGridColumn.Visible = False OrElse (IsIncluded = False AndAlso NextGridColumn.FieldName <> AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsBillingRateDetailIncluded.ToString)

                    NextGridColumn = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Columns(NextGridColumn.AbsoluteIndex + 1)

                    IsIncluded = CBool(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRowCellValue(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle, NextGridColumn))

                End While

            Catch ex As Exception
                NextGridColumn = GridColumn
            Finally
                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn = NextGridColumn
            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RateFlagStructureSetupForm As AdvantageFramework.Maintenance.Billing.Presentation.RateFlagStructureSetupForm = Nothing

            RateFlagStructureSetupForm = New AdvantageFramework.Maintenance.Billing.Presentation.RateFlagStructureSetupForm()

            RateFlagStructureSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RateFlagStructureSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'objects
            BandedDataGridViewLeftSection_RateFlagLevels.MultiSelect = False
            BandedDataGridViewLeftSection_RateFlagLevels.OptionsCustomization.AllowSort = False

            RateFlagEntryControlRightSection_RateFlag.HideStructureLevelSelection = True
            RateFlagEntryControlRightSection_RateFlag.ViewInactiveBillingRateDetails = True

            _RepositoryItemCheckEdit_Images = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            _RepositoryItemCheckEdit_Images.PictureChecked = AdvantageFramework.My.Resources.SmallGreenCircleImage
            _RepositoryItemCheckEdit_Images.PictureGrayed = Nothing
            _RepositoryItemCheckEdit_Images.PictureUnchecked = Nothing
            _RepositoryItemCheckEdit_Images.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
            _RepositoryItemCheckEdit_Images.ValueUnchecked = CShort(0)
            _RepositoryItemCheckEdit_Images.ValueChecked = CShort(1)

            BandedDataGridViewLeftSection_RateFlagLevels.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_Images)

            _RepositoryItemCheckEdit_Standard = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            _RepositoryItemCheckEdit_Standard.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
            _RepositoryItemCheckEdit_Standard.ValueChecked = Convert.ToInt16(1)
            _RepositoryItemCheckEdit_Standard.ValueUnchecked = Convert.ToInt16(0)
            _RepositoryItemCheckEdit_Standard.ValueGrayed = Convert.ToInt16(0)
            _RepositoryItemCheckEdit_Standard.NullText = "No"
            _RepositoryItemCheckEdit_Standard.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

            BandedDataGridViewLeftSection_RateFlagLevels.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_Standard)

            _RepositoryItemCheckEdit_Blank = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            _RepositoryItemCheckEdit_Blank.PictureChecked = Nothing
            _RepositoryItemCheckEdit_Blank.PictureGrayed = Nothing
            _RepositoryItemCheckEdit_Blank.PictureUnchecked = Nothing
            _RepositoryItemCheckEdit_Blank.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
            _RepositoryItemCheckEdit_Blank.ValueUnchecked = CShort(0)
            _RepositoryItemCheckEdit_Blank.ValueChecked = CShort(1)

            BandedDataGridViewLeftSection_RateFlagLevels.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_Blank)

            _RepositoryItemCheckEdit_NoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            _RepositoryItemCheckEdit_NoEdit.PictureChecked = AdvantageFramework.My.Resources.SmallCheckMarkImage
            _RepositoryItemCheckEdit_NoEdit.PictureGrayed = Nothing
            _RepositoryItemCheckEdit_NoEdit.PictureUnchecked = Nothing
            _RepositoryItemCheckEdit_NoEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
            _RepositoryItemCheckEdit_NoEdit.ValueUnchecked = CShort(0)
            _RepositoryItemCheckEdit_NoEdit.ValueChecked = CShort(1)

            BandedDataGridViewLeftSection_RateFlagLevels.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_NoEdit)

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemActions_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemActions_ViewAll.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemUpdate_FeeFlagUpdate.Image = AdvantageFramework.My.Resources.FeeFlagUpdateImage

            ButtonItemDetails_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDetails_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_Calculate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemDetails_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_CopyByCDP.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            _UserHasAccessToStructure = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Modules.Maintenance_Billing_RateFlagStructure)
            _UserHasAccessToEntry = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Modules.Maintenance_Billing_RateFlagEntry)
            ButtonItemDetails_ShowDescriptions.Checked = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInRateFlagEntry)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            LoadGridBands()

        End Sub
        Private Sub RateFlagStructureSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemDetails_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub RateFlagStructureSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemDetails_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub RateFlagStructureSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadSelectedItemDetails()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "   Structure Grid "

        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_AddNewRowEvent(ByVal RowObject As Object) Handles BandedDataGridViewLeftSection_RateFlagLevels.AddNewRowEvent

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.BillingRateLevel Then

                Me.ShowWaitForm("Inserting...")

                BillingRateLevel = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If BillingRateLevel.IsEntityBeingAdded() Then

                        BillingRateLevel.DbContext = DbContext
                        BillingRateLevel.SetDefaultDescription()

                        If AdvantageFramework.Database.Procedures.BillingRateLevel.Insert(DbContext, BillingRateLevel) Then

                            RateFlagEntryControlRightSection_RateFlag.RefreshBillingRateLevels()

                            LoadGrid()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.CellValueChangingEvent

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim UpdateEntity As Boolean = True

            If BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle) = False Then

                Me.ShowWaitForm()

                Try

                    BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    BillingRateLevel = Nothing
                End Try

                If BillingRateLevel IsNot Nothing Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsBillingRateDetailIncluded.ToString

                            BillingRateLevel.IsBillingRateDetailIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsNonBillableIncluded.ToString

                            BillingRateLevel.IsNonBillableIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString

                            BillingRateLevel.IsCommissionIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString

                            BillingRateLevel.IsTaxIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString

                            BillingRateLevel.IsTaxCommissionIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFeeTimeIncluded.ToString

                            BillingRateLevel.IsFeeTimeIncluded = CShort(e.Value)

                        Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsInactive.ToString

                            If CBool(e.Value) Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Marking a rate level as inactive will immediately cause all rate/flag entries associated with this level to be ignored. " &
                                                                              "Are you sure you wish to deactivate the rate level?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    BillingRateLevel.IsInactive = CShort(e.Value)

                                Else

                                    UpdateEntity = False

                                End If

                            Else

                                BillingRateLevel.IsInactive = CShort(e.Value)

                            End If

                        Case Else

                            UpdateEntity = False

                    End Select

                    If UpdateEntity Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.BillingRateLevel.Update(DbContext, BillingRateLevel)

                            If Saved Then

                                RateFlagEntryControlRightSection_RateFlag.RefreshBillingRateLevels()
                                LoadSelectedItemDetails()

                            End If

                        End Using

                    End If

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_CustomRowCellEditEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.CustomRowCellEditEvent

            Dim IsNewItemRow As Boolean = False
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim IsFunctionIncluded As Boolean = False
            Dim IsRequired As Boolean = False

            Try

                BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                BillingRateLevel = Nothing
            End Try

            If BillingRateLevel IsNot Nothing Then

                IsFunctionIncluded = CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))
                IsRequired = CBool(BillingRateLevel.IsRequired.GetValueOrDefault(0))

            Else

                IsFunctionIncluded = False
                IsRequired = False

            End If

            IsNewItemRow = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(e.RowHandle)

            Select Case e.Column.FieldName

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFunctionIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsSalesClassIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEffectiveDateIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsBillingRateDetailIncluded.ToString

                    If IsRequired Then

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsNonBillableIncluded.ToString

                    If IsRequired Then

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString

                    If IsFunctionIncluded Then

                        If IsRequired Then

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                        Else

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                        End If

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Blank)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString

                    If IsFunctionIncluded Then

                        If IsRequired Then

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                        Else

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                        End If

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Blank)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString

                    If IsFunctionIncluded Then

                        If IsRequired Then

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                        Else

                            ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                        End If

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Blank)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFeeTimeIncluded.ToString

                    If IsRequired Then

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Number.ToString

                    Try

                        e.RepositoryItem.ReadOnly = True

                    Catch ex As Exception

                    End Try

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Description.ToString

                    Try

                        e.RepositoryItem.ReadOnly = True

                    Catch ex As Exception

                    End Try

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsInactive.ToString

                    If IsRequired Then

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.NoEdit)

                    Else

                        ModifyColumn(e, IsNewItemRow, CheckBoxType.Standard)

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeTitleIncluded.ToString

                    ModifyColumn(e, IsNewItemRow, CheckBoxType.Images)

            End Select

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_GotFocusEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.GotFocusEvent

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.InitNewRowEvent

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRateLevelOrderNumber As Integer = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    BillingRateLevelOrderNumber = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).ToList
                                                   Select Entity.Number).Max + 1

                Catch ex As Exception
                    BillingRateLevelOrderNumber = Nothing
                End Try

            End Using

            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Number.ToString, BillingRateLevelOrderNumber)

            Try

                BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                BillingRateLevel = Nothing
            End Try

            If BillingRateLevel IsNot Nothing Then

                BillingRateLevel.IsClientIncluded = 0
                BillingRateLevel.IsDivisionIncluded = 0
                BillingRateLevel.IsProductIncluded = 0
                BillingRateLevel.IsSalesClassIncluded = 0
                BillingRateLevel.IsFunctionIncluded = 0
                BillingRateLevel.IsEmployeeIncluded = 0
                BillingRateLevel.IsEmployeeTitleIncluded = 0
                BillingRateLevel.IsEffectiveDateIncluded = 0
                BillingRateLevel.IsBillingRateDetailIncluded = 0
                BillingRateLevel.IsNonBillableIncluded = 0
                BillingRateLevel.IsCommissionIncluded = 0
                BillingRateLevel.IsTaxIncluded = 0
                BillingRateLevel.IsTaxCommissionIncluded = 0
                BillingRateLevel.IsFeeTimeIncluded = 0
                BillingRateLevel.IsInactive = 0
                BillingRateLevel.IsRequired = 0

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_LostFocusEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.LostFocusEvent

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_NewItemRowCellValueChangingEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.NewItemRowCellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFunctionIncluded.ToString Then

                If e.Value Is Nothing OrElse e.Value = 0 Then

                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString, Nothing)
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString, Nothing)
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString, Nothing)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString Then

                If e.Value Is Nothing OrElse e.Value = 0 Then

                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString, 0)
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString, 0)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString Then

                If e.Value Is Nothing OrElse e.Value = 0 Then

                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString, 0)

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                LoadSelectedItemDetails()
                EnableOrDisableActions()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub BandedDataGridViewLeftSection_RateFlagLevels_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles BandedDataGridViewLeftSection_RateFlagLevels.ShownEditorEvent

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim IsNewItemRow As Boolean = Nothing
            Dim FocusedRowHandle As Integer = Nothing
            Dim IsIncluded As Boolean = Nothing

            FocusedRowHandle = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle
            IsNewItemRow = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(FocusedRowHandle)

            Try

                BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle)

            Catch ex As Exception
                BillingRateLevel = Nothing
            End Try

            If BillingRateLevel IsNot Nothing AndAlso CBool(BillingRateLevel.IsRequired.GetValueOrDefault(0)) Then

                BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

            Else

                If BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsCommissionIncluded.ToString OrElse
                   BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxCommissionIncluded.ToString OrElse
                   BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsTaxIncluded.ToString Then

                    If BillingRateLevel IsNot Nothing Then

                        If CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)) = False Then

                            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()
                            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn = BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.Columns(AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFeeTimeIncluded.ToString)

                        End If

                    Else

                        BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                    End If

                ElseIf BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString Then

                    If BillingRateLevel IsNot Nothing Then

                        If CBool(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0)) = False Then

                            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                        End If

                    Else

                        BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                    End If

                ElseIf BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString Then

                    If BillingRateLevel IsNot Nothing Then

                        If CBool(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0)) = False OrElse
                           CBool(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)) = False Then

                            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                        End If

                    Else

                        BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                    End If

                ElseIf BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEffectiveDateIncluded.ToString Then

                    If BillingRateLevel IsNot Nothing Then

                        If CBool(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0)) = False AndAlso
                           CBool(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0)) = False Then

                            BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                        End If

                    Else

                        BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.CloseEditor()

                    End If

                End If

            End If

            If IsNewItemRow = False Then

                If BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsSalesClassIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsFunctionIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeTitleIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEmployeeIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEffectiveDateIncluded.ToString OrElse
                    BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.Visible = False Then

                    If BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn.Visible = False Then

                        IsIncluded = False

                    Else

                        IsIncluded = CBool(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.GetRowCellValue(FocusedRowHandle, BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn))

                    End If

                    If IsIncluded = False Then

                        SetNearestCanFocusColumn(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedColumn)

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Rate/Flag Control "

        Private Sub RateFlagEntryControlRightSection_RateFlag_BillingRateDetailInitNewRow() Handles RateFlagEntryControlRightSection_RateFlag.BillingRateDetailInitNewRow

            EnableOrDisableActions()

        End Sub
        Private Sub RateFlagEntryControlRightSection_RateFlag_SelectedBillingRateDetailChanged() Handles RateFlagEntryControlRightSection_RateFlag.SelectedBillingRateDetailChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RateFlagEntryControlRightSection_RateFlag_SelectedBillingRateLevelChanged() Handles RateFlagEntryControlRightSection_RateFlag.SelectedBillingRateLevelChanged

            EnableOrDisableActions()

        End Sub

#End Region

#Region "   Ribbon Bar Buttons "

        Private Sub ButtonItemUpdate_FeeFlagUpdate_Click(sender As Object, e As EventArgs) Handles ButtonItemUpdate_FeeFlagUpdate.Click

            If AdvantageFramework.Maintenance.Billing.Presentation.FeeFlagUpdateDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then



            End If

        End Sub
        Private Sub ButtonItemActions_ViewAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ViewAll.CheckedChanged

            'objects
            Dim ContinueViewAll As Boolean = False
            Dim Reset As Boolean = False

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                If ButtonItemActions_ViewAll.Checked Then

                    ContinueViewAll = CheckForUnsavedChanges()

                    If ContinueViewAll Then

                        BandedDataGridViewLeftSection_RateFlagLevels.Enabled = False

                        RateFlagEntryControlRightSection_RateFlag.Enabled = RateFlagEntryControlRightSection_RateFlag.LoadControl(ViewAll:=True, ShowDescriptions:=ButtonItemDetails_ShowDescriptions.Checked)

                    Else

                        ButtonItemActions_ViewAll.Checked = False

                    End If

                Else

                    BandedDataGridViewLeftSection_RateFlagLevels.Enabled = True
                    LoadSelectedItemDetails()

                End If

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_MoveDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_MoveDown.Click

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim PreviousBillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If BandedDataGridViewLeftSection_RateFlagLevels.HasOnlyOneSelectedRow AndAlso BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle) = False Then

                Me.ShowWaitForm("Saving...")

                Try

                    BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    BillingRateLevel = Nothing
                End Try

                If BillingRateLevel IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            PreviousBillingRateLevel = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).ToList
                                                        Where Entity.Number < BillingRateLevel.Number
                                                        Select Entity
                                                        Order By Entity.Number Descending).FirstOrDefault

                        Catch ex As Exception
                            PreviousBillingRateLevel = Nothing
                        End Try

                        If PreviousBillingRateLevel IsNot Nothing Then

                            BillingRateLevel.Number = PreviousBillingRateLevel.Number
                            PreviousBillingRateLevel.Number = BillingRateLevel.Number + 1

                            If AdvantageFramework.Database.Procedures.BillingRateLevel.Update(DbContext, BillingRateLevel) Then

                                If AdvantageFramework.Database.Procedures.BillingRateLevel.Update(DbContext, PreviousBillingRateLevel) Then

                                    LoadGrid()

                                End If

                            End If

                        End If

                    End Using

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_MoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_MoveUp.Click

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim NextBillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If BandedDataGridViewLeftSection_RateFlagLevels.HasOnlyOneSelectedRow AndAlso BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.IsNewItemRow(BandedDataGridViewLeftSection_RateFlagLevels.CurrentView.FocusedRowHandle) = False Then

                Me.ShowWaitForm("Saving...")

                Try

                    BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    BillingRateLevel = Nothing
                End Try

                If BillingRateLevel IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            NextBillingRateLevel = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).ToList
                                                    Where Entity.Number > BillingRateLevel.Number
                                                    Select Entity
                                                    Order By Entity.Number Ascending).FirstOrDefault

                        Catch ex As Exception
                            NextBillingRateLevel = Nothing
                        End Try

                        If NextBillingRateLevel IsNot Nothing Then

                            BillingRateLevel.Number = NextBillingRateLevel.Number
                            NextBillingRateLevel.Number = BillingRateLevel.Number - 1

                            If AdvantageFramework.Database.Procedures.BillingRateLevel.Update(DbContext, BillingRateLevel) Then

                                If AdvantageFramework.Database.Procedures.BillingRateLevel.Update(DbContext, NextBillingRateLevel) Then

                                    LoadGrid()

                                End If

                            End If

                        End If

                    End Using

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            BandedDataGridViewLeftSection_RateFlagLevels.CancelNewItemRow()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRateLevels As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateLevel) = Nothing

            If BandedDataGridViewLeftSection_RateFlagLevels.HasOnlyOneSelectedRow(True) Then

                If AdvantageFramework.WinForm.MessageBox.Show("Warning: Deleting a rate level will also permanently remove all rates and flags associated with this level. " &
                                                              "Are you certain you wish to continue? If you answer 'Yes', all pending changes will be saved immediately.",
                                                              WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")

                    Try

                        BillingRateLevel = BandedDataGridViewLeftSection_RateFlagLevels.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        BillingRateLevel = Nothing
                    End Try

                    If BillingRateLevel IsNot Nothing Then

                        BillingRateLevels = BandedDataGridViewLeftSection_RateFlagLevels.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.BillingRateLevel).OrderBy(Function(Entity) Entity.Number).ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If AdvantageFramework.Database.Procedures.BillingRateLevel.Delete(DbContext, BillingRateLevel) Then

                                If BillingRateLevels IsNot Nothing AndAlso BillingRateLevels.Count > 1 Then

                                    BillingRateLevels = BillingRateLevels.OrderBy(Function(Entity) Entity.Number).ToList

                                    If BillingRateLevels.Remove(BillingRateLevel) Then

                                        BillingRateLevel = Nothing

                                        For Each BillingRateLevel In BillingRateLevels.ToList

                                            BillingRateLevel.Number = BillingRateLevels.IndexOf(BillingRateLevel) + 1

                                            DbContext.UpdateObject(BillingRateLevel)

                                        Next

                                        Try

                                            DbContext.SaveChanges()

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End If

                                RateFlagEntryControlRightSection_RateFlag.RefreshBillingRateLevels()

                                LoadGrid()

                            End If

                        End Using

                    End If

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            If RateFlagEntryControlRightSection_RateFlag.HasASelectedBillingRateDetail Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RateFlagEntryControlRightSection_RateFlag.Delete()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a billing rate detail to delete.")

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            RateFlagEntryControlRightSection_RateFlag.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Calculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Calculate.Click

            AdvantageFramework.Maintenance.Billing.Presentation.RateFlagTesterDialog.ShowFormDialog()

        End Sub
        Private Sub ButtonItemDetails_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Copy.Click

            RateFlagEntryControlRightSection_RateFlag.CopySelectedRateFlag()

        End Sub
        Private Sub ButtonItemDetails_CopyByCDP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_CopyByCDP.Click

            RateFlagEntryControlRightSection_RateFlag.CopyByCDP()

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            RateFlagEntryControlRightSection_RateFlag.ExportBillingRateDetails()

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            RateFlagEntryControlRightSection_RateFlag.ExportAllBillingRateDetails()

        End Sub
        Private Sub ButtonItemDetails_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDetails_ShowDescriptions.CheckedChanged

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                RateFlagEntryControlRightSection_RateFlag.ShowDescriptions = ButtonItemDetails_ShowDescriptions.Checked

                AdvantageFramework.Security.SaveUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInRateFlagEntry, ButtonItemDetails_ShowDescriptions.Checked)

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
