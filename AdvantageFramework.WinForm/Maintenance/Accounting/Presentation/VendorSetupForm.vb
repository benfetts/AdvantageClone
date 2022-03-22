Namespace Maintenance.Accounting.Presentation

    Public Class VendorSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CanUserCustom1 As Boolean = False

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

            'objects
            Dim NielsenTVStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing
            Dim NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing
            Dim VendorCategories As IEnumerable(Of String) = Nothing

            VendorCategories = {"I", "M", "N", "O", "R", "T"}

            If Me.Session.IsNielsenSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    NielsenTVStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                            Where Entity.SourceType = "B"
                                            Select Entity).ToList

                    NielsenRadioStationList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen).ToList

                End Using

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Vendors.DataSource = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).Include("Office").Include("Market")
                                                              Where Not _CanUserCustom1 OrElse
                                                                    (_CanUserCustom1 AndAlso
                                                                     (VendorCategories.Contains(Vendor.VendorCategory) OrElse
                                                                      Vendor.InternetCategory = 1 OrElse Vendor.MagazineCategory = 1 OrElse Vendor.NewspaperCategory = 1 OrElse
                                                                      Vendor.OutOfHomeCategory = 1 OrElse Vendor.RadioCategory = 1 OrElse Vendor.TVCategory = 1))
                                                              Select Vendor.Code,
                                                                     Vendor.Name,
                                                                     [VendorType] = Vendor.VendorCategory,
                                                                     [Office] = If(Vendor.Office Is Nothing, "", Vendor.Office.Code + " - " + Vendor.Office.Name),
                                                                     Vendor.DefaultAPAccount,
                                                                     [Market] = If(Vendor.Market Is Nothing, "", Vendor.Market.Code + " - " + Vendor.Market.Description),
                                                                     [VendorCity] = Vendor.City,
                                                                     [VendorState] = Vendor.State,
                                                                     [ActiveFlag] = Vendor.ActiveFlag,
                                                                     [IsCableSystem] = Vendor.IsCableSystem,
                                                                     [NielsenRadioStationComboID] = Vendor.NielsenRadioStationComboID,
                                                                     [NielsenTVStationCode] = Vendor.NielsenTVStationCode).ToList _
                                                             .Select(Function(Vendor) New AdvantageFramework.Database.Classes.Vendor With {.Code = Vendor.Code,
                                                                                                                                           .Name = Vendor.Name,
                                                                                                                                           .VendorType = Vendor.VendorType,
                                                                                                                                           .Office = Vendor.Office,
                                                                                                                                           .DefaultAPAccount = Vendor.DefaultAPAccount,
                                                                                                                                           .Market = Vendor.Market,
                                                                                                                                           .VendorCity = Vendor.VendorCity,
                                                                                                                                           .VendorState = Vendor.VendorState,
                                                                                                                                           .IsCableSystem = Vendor.IsCableSystem,
                                                                                                                                           .CallLetters = If(Vendor.NielsenTVStationCode IsNot Nothing AndAlso
                                                                                                                                                             NielsenTVStationList IsNot Nothing AndAlso
                                                                                                                                                             NielsenTVStationList.Count > 0 AndAlso
                                                                                                                                                             NielsenTVStationList.Where(Function(E) E.StationCode = Vendor.NielsenTVStationCode).Any, NielsenTVStationList.Where(Function(E) E.StationCode = Vendor.NielsenTVStationCode).FirstOrDefault.CallLetters,
                                                                                                                                                          If(Vendor.NielsenRadioStationComboID IsNot Nothing AndAlso
                                                                                                                                                             NielsenRadioStationList IsNot Nothing AndAlso
                                                                                                                                                             NielsenRadioStationList.Count > 0 AndAlso
                                                                                                                                                             NielsenRadioStationList.Where(Function(E) E.ComboID = Vendor.NielsenRadioStationComboID).Any, NielsenRadioStationList.Where(Function(E) E.ComboID = Vendor.NielsenRadioStationComboID).FirstOrDefault.Name, "")),
                                                                                                                                           .IsInactive = Not CBool(Vendor.ActiveFlag.GetValueOrDefault(0))}).ToList

            End Using

            DataGridViewLeftSection_Vendors.CurrentView.BestFitColumns()

            PanelForm_LeftSection.Width = DataGridViewLeftSection_Vendors.CurrentView.Columns(0).Width + DataGridViewLeftSection_Vendors.CurrentView.Columns(1).Width + (PanelForm_LeftSection.Width - DataGridViewLeftSection_Vendors.Width) + 35
            ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(PanelForm_LeftSection.Location.X, 0)

        End Sub
        Private Sub LoadSelectedItemDetails()

            Try

                VendorControlRightSection_Vendor.ClearControl()

                VendorControlRightSection_Vendor.Enabled = DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow

                If VendorControlRightSection_Vendor.Enabled Then

                    VendorControlRightSection_Vendor.Enabled = VendorControlRightSection_Vendor.LoadControl(DataGridViewLeftSection_Vendors.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions()

            VendorControlRightSection_Vendor.Enabled = (DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow AndAlso VendorControlRightSection_Vendor.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If VendorControlRightSection_Vendor.Enabled Then

                RibbonBarOptions_Contacts.Visible = VendorControlRightSection_Vendor.IsContactsTabSelected
                RibbonBarOptions_Pricings.Visible = VendorControlRightSection_Vendor.IsPricingsTabSelected
                ButtonItemContacts_Delete.Enabled = VendorControlRightSection_Vendor.VendorContactsGrid.HasOnlyOneSelectedRow
                ButtonItemContacts_Edit.Enabled = VendorControlRightSection_Vendor.VendorContactsGrid.HasOnlyOneSelectedRow
                RibbonBarOptions_Representatives.Visible = VendorControlRightSection_Vendor.IsRepresentativesTabSelected
                ButtonItemRepresentatives_Delete.Enabled = VendorControlRightSection_Vendor.VendorRepresentativesGrid.HasOnlyOneSelectedRow
                ButtonItemRepresentatives_Edit.Enabled = VendorControlRightSection_Vendor.VendorRepresentativesGrid.HasOnlyOneSelectedRow
                RibbonBarOptions_MediaSpecs.Visible = VendorControlRightSection_Vendor.IsMediaSpecsTabSelected
                ButtonItemMediaSpecs_Add.Enabled = VendorControlRightSection_Vendor.CanAddNewMediaSpec
                ButtonItemMediaSpecs_Delete.Enabled = If(VendorControlRightSection_Vendor.TreeListControlMediaSpecs_MediaSpecs.Selection.Count = 1, True, False)
                ButtonItemPricings_Cancel.Enabled = VendorControlRightSection_Vendor.VendorPricingControlPricings_VendorPricings.IsNewItemRow
                ButtonItemPricings_Delete.Enabled = VendorControlRightSection_Vendor.VendorPricingControlPricings_VendorPricings.HasASelectedPricing
                RibbonBarOptions_Contracts.Visible = VendorControlRightSection_Vendor.IsContractsTabSelected

                RibbonBarOptions_Documents.Visible = VendorControlRightSection_Vendor.IsDocumentsTabSelected

                If RibbonBarOptions_Documents.Visible Then

                    ButtonItemDocuments_Delete.Enabled = VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument
                    ButtonItemDocuments_Download.Enabled = If(VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument, Not VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.IsSelectedDocumentAURL, VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument, VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.IsSelectedDocumentAURL, False)
                    ButtonItemDocuments_Upload.Enabled = VendorControlRightSection_Vendor.DocumentManagerControlDocuments_VendorDocuments.CanUpload

                Else

                    ButtonItemDocuments_Upload.Enabled = False
                    ButtonItemDocuments_Delete.Enabled = False
                    ButtonItemDocuments_Download.Enabled = False
                    ButtonItemDocuments_OpenURL.Enabled = False

                End If

                If VendorControlRightSection_Vendor.IsDefaultsNotesTabSelected OrElse
                   VendorControlRightSection_Vendor.IsMediaInfoTabSelected OrElse
                   VendorControlRightSection_Vendor.IsMediaDeliveryTabSelected OrElse
                   VendorControlRightSection_Vendor.IsDefaultCommentsTabSelected Then

                    RibbonBarOptions_CheckSpelling.Visible = True

                Else

                    RibbonBarOptions_CheckSpelling.Visible = False

                End If

                If RibbonBarOptions_Contracts.Visible Then

                    ButtonItemContracts_Copy.Enabled = VendorControlRightSection_Vendor.VendorContractManager.HasOnlyOneSelectedContract
                    ButtonItemContracts_Edit.Enabled = VendorControlRightSection_Vendor.VendorContractManager.HasOnlyOneSelectedContract
                    ButtonItemContracts_Delete.Enabled = VendorControlRightSection_Vendor.VendorContractManager.HasOnlyOneSelectedContract

                End If

                RibbonBarOptions_Markets.Visible = VendorControlRightSection_Vendor.ShowManageMarkets

                RibbonBarOptions_QuickBooks.Visible = VendorControlRightSection_Vendor.IsQuickbooksEnabled

                RibbonBarOptions_ComboStations.Visible = VendorControlRightSection_Vendor.ShowManageComboRadioStations

            Else

                RibbonBarOptions_Documents.Visible = False
                RibbonBarOptions_Contacts.Visible = False
                RibbonBarOptions_Pricings.Visible = False
                ButtonItemContacts_Delete.Enabled = False
                ButtonItemContacts_Edit.Enabled = False
                RibbonBarOptions_Representatives.Visible = False
                ButtonItemRepresentatives_Delete.Enabled = False
                ButtonItemRepresentatives_Edit.Enabled = False
                RibbonBarOptions_MediaSpecs.Visible = False
                ButtonItemMediaSpecs_Add.Enabled = False
                ButtonItemMediaSpecs_Delete.Enabled = False
                RibbonBarOptions_CheckSpelling.Visible = False
                ButtonItemPricings_Cancel.Enabled = False
                ButtonItemPricings_Delete.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False
                RibbonBarOptions_Contracts.Visible = False
                RibbonBarOptions_Markets.Visible = False
                RibbonBarOptions_QuickBooks.Visible = False
                RibbonBarOptions_ComboStations.Visible = False

            End If

        End Sub
        Private Function MustSaveUnsavedChanges() As Boolean

            ''objects
            Dim IsOkay As Boolean = False

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    VendorControlRightSection_Vendor.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = VendorControlRightSection_Vendor.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            Else

                IsOkay = True

            End If

            MustSaveUnsavedChanges = IsOkay

        End Function
        Private Function CheckForUnsavedChanges() As Boolean

            ''objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    VendorControlRightSection_Vendor.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = VendorControlRightSection_Vendor.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
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

            If DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow Then

                VendorControlRightSection_Vendor.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If VendorControlRightSection_Vendor.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Vendors.FocusToFindPanel(False)

                        DataGridViewLeftSection_Vendors.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor to save.")

            End If

            Save = Saved

        End Function
        Private Sub RefreshForm()

            If CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    VendorControlRightSection_Vendor.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Vendors.GridViewSelectionChanged()

                EnableOrDisableActions()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.VendorSetupForm = Nothing

            VendorSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorSetupForm()

            VendorSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemContacts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContacts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemRepresentatives_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemRepresentatives_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemRepresentatives_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemMediaSpecs_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemMediaSpecs_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemPricings_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemPricings_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemImport_Wizard.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemImport_PendingRecords.Image = AdvantageFramework.My.Resources.DatabaseStagingImage

            ButtonItemContracts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContracts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemNielsen_UpdateStations.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemMarkets_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage

            ButtonItemQuickBooks_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemComboStations_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage

            DataGridViewLeftSection_Vendors.MultiSelect = False
            DataGridViewLeftSection_Vendors.ItemDescription = "Vendor(s)"

            _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ButtonItemActions_Add.SecurityEnabled = (VendorControlRightSection_Vendor.CanUserAdd AndAlso VendorControlRightSection_Vendor.CanUserCustom1 = False)

                    ButtonItemActions_Save.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemActions_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemSpelling_CheckSpelling.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemContacts_Add.SecurityEnabled = VendorControlRightSection_Vendor.CanUserAddInVendorContact
                    ButtonItemContacts_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdateInVendorContact
                    ButtonItemRepresentatives_Add.SecurityEnabled = VendorControlRightSection_Vendor.CanUserAddInVendorRep
                    ButtonItemRepresentatives_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdateInVendorRep
                    ButtonItemMediaSpecs_Add.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemMediaSpecs_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemPricings_Cancel.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemPricings_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemDocuments_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemDocuments_Download.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemDocuments_OpenURL.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemDocuments_Upload.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate

                    ButtonItemActions_Print.SecurityEnabled = VendorControlRightSection_Vendor.CanUserPrint
                    ButtonItemActions_PrintFiltered.SecurityEnabled = VendorControlRightSection_Vendor.CanUserPrint

                    ButtonItemImport_Wizard.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorImport.ToString, Me.Session.User.ID)
                    ButtonItemImport_PendingRecords.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorImport.ToString, Me.Session.User.ID)

                    ButtonItemContacts_Add.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemContracts_Copy.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemContacts_Delete.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate
                    ButtonItemContacts_Edit.SecurityEnabled = VendorControlRightSection_Vendor.CanUserUpdate

                End Using

            Catch ex As Exception

            End Try

            If ButtonItemImport_PendingRecords.SecurityEnabled = False AndAlso ButtonItemImport_Wizard.SecurityEnabled = False Then

                RibbonBarMergeContainerForm_Import.AllowMerge = False

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Vendors.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            RibbonBarOptions_Nielsen.Visible = Me.Session.IsNielsenSetup

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub VendorSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Vendors.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Vendors_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Vendors.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Vendors_Selectionchangedevent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Vendors.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim VendorCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog.ShowFormDialog(VendorCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Vendors.SelectRow(VendorCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Vendors.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If VendorControlRightSection_Vendor.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedVendorCodes() As String = Nothing

            If VendorControlRightSection_Vendor.Enabled Then

                SelectedVendorCodes = {DataGridViewLeftSection_Vendors.GetFirstSelectedRowBookmarkValue}

            End If

            AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog.ShowFormDialog(Nothing, SelectedVendorCodes)

        End Sub
        Private Sub ButtonItemActions_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableVendorCodes() As String = Nothing

            Try

                SelectedAndAvailableVendorCodes = (From Entity In DataGridViewLeftSection_Vendors.GetAllRowsBookmarkValues.OfType(Of String)()
                                                   Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableVendorCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog.ShowFormDialog(SelectedAndAvailableVendorCodes, SelectedAndAvailableVendorCodes)

        End Sub
        Private Sub ButtonItemContacts_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Add.Click

            VendorControlRightSection_Vendor.AddVendorContact()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Edit.Click

            VendorControlRightSection_Vendor.EditVendorContact()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Delete.Click

            VendorControlRightSection_Vendor.DeleteVendorContact()

        End Sub
        Private Sub ButtonItemRepresentatives_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Add.Click

            VendorControlRightSection_Vendor.AddVendorRepresentative()

        End Sub
        Private Sub ButtonItemRepresentatives_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Edit.Click

            VendorControlRightSection_Vendor.EditVendorRepresentative()

        End Sub
        Private Sub ButtonItemRepresentatives_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Delete.Click

            VendorControlRightSection_Vendor.DeleteVendorRepresentative()

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            VendorControlRightSection_Vendor.SpellCheckSelectedTab()

        End Sub
        Private Sub ButtonItemMediaSpecs_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemMediaSpecs_Delete.Click

            VendorControlRightSection_Vendor.DeleteSelectedMediaSpec()

        End Sub
        Private Sub ButtonItemMediaSpecs_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemMediaSpecs_Add.Click

            VendorControlRightSection_Vendor.AddMediaSpec()

        End Sub
        Private Sub VendorControlRightSection_Vendor_MediaSpecsChangedEvent() Handles VendorControlRightSection_Vendor.MediaSpecsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean) Handles VendorControlRightSection_Vendor.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub VendorControlRightSection_Vendor_SelectedDocumentChanged() Handles VendorControlRightSection_Vendor.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_SelectedTabChanged() Handles VendorControlRightSection_Vendor.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_VendorPricingsSelectionChangedEvent() Handles VendorControlRightSection_Vendor.VendorPricingsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPricings_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPricings_Cancel.Click

            VendorControlRightSection_Vendor.CancelAddVendorPricing()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPricings_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPricings_Delete.Click

            VendorControlRightSection_Vendor.DeleteVendorPricing()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            VendorControlRightSection_Vendor.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            VendorControlRightSection_Vendor.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            VendorControlRightSection_Vendor.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            VendorControlRightSection_Vendor.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            VendorControlRightSection_Vendor.DeletedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemImport_Wizard_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_Wizard.Click

            If AdvantageFramework.Maintenance.Accounting.Presentation.VendorImportWizardDialog.ShowWizardDialog() = Windows.Forms.DialogResult.OK Then

                Try

                    If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorImportStagingForm)) = False Then

                        AdvantageFramework.Maintenance.Accounting.Presentation.VendorImportStagingForm.ShowForm()

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemImport_PendingRecords_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_PendingRecords.Click

            Try

                If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorImportStagingForm)) = False Then

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorImportStagingForm.ShowForm()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            RefreshForm()

        End Sub
        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            VendorControlRightSection_Vendor.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            VendorControlRightSection_Vendor.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            VendorControlRightSection_Vendor.DeleteContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Edit.Click

            VendorControlRightSection_Vendor.EditContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemNielsenStations_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemNielsen_UpdateStations.Click

            If Me.Session.IsNielsenSetup Then

                If AdvantageFramework.WinForm.MessageBox.Show("Advantage will attempt to find a match to the Nielsen Station Code using the Advantage Vendor Code and/or Name.  However, please check the codes after completion and update as needed.  Continue Yes/No?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm", MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If AdvantageFramework.Maintenance.Accounting.Presentation.VendorStationsDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                        RefreshForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Manage.Click

            If MustSaveUnsavedChanges() Then

                Me.ClearChanged()

                AdvantageFramework.Maintenance.Accounting.Presentation.VendorMarketsEditDialog.ShowFormDialog(VendorControlRightSection_Vendor.VendorCode, VendorControlRightSection_Vendor.SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue)

            End If

        End Sub
        Private Sub VendorControlRightSection_Vendor_VendorContractManagerRowCountChanged() Handles VendorControlRightSection_Vendor.VendorContractManagerRowCountChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_VendorContractManagerSelectionChanged() Handles VendorControlRightSection_Vendor.VendorContractManagerSelectionChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_MarketChangedEvent() Handles VendorControlRightSection_Vendor.MarketChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlRightSection_Vendor_ComboStationChangedEvent() Handles VendorControlRightSection_Vendor.ComboStationChangedEvent

            RibbonBarOptions_ComboStations.Visible = VendorControlRightSection_Vendor.ShowManageComboRadioStations

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemQuickBooks_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickBooks_Refresh.Click

            VendorControlRightSection_Vendor.RefreshQuickBooksVendor()

        End Sub
        Private Sub ButtonItemComboStations_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemComboStations_Manage.Click

            VendorControlRightSection_Vendor.ManageComboRadioStations()

        End Sub

#End Region

#End Region

    End Class

End Namespace
