Imports AdvantageFramework.StringUtilities

Namespace Importing.Presentation

    Public Class ImportForm

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum MatchBy
            BroadcastMonth
            CalendarMonth
        End Enum

#End Region

#Region " Variables "

        Private _ImportType As AdvantageFramework.Importing.ImportType = Nothing
        Private _AllowSave As Boolean = True
        Private _LastLoadedBatchName As String = ""
        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
        Private _DeleteBatchOnExit As Boolean = False
        Private _APLockGLAccountCode As Boolean = False
        Private _OrderNumberSearchResultList As Generic.List(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ImportType As AdvantageFramework.Importing.ImportType
            Get
                ImportType = _ImportType
            End Get
        End Property
        Public WriteOnly Property DeleteBatchOnExit As Boolean
            Set(value As Boolean)
                _DeleteBatchOnExit = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region " Public "

        Public Sub DisableNavigationDropDowns(BatchName As String)

            ComboBoxSettings_ImportType.SelectedValue = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic.ToString

            LoadAvailableBatches()

            ComboBoxSettings_Batch.SelectedValue = BatchName

            ComboBoxSettings_ImportType.Enabled = False
            ComboBoxSettings_Batch.Enabled = False

            ButtonItemActions_Export.Visible = False
            ButtonItemActions_Add.Visible = False
            ButtonItemActions_Delete.Visible = False

            'ButtonItemAccountPayable_ShowAll.Visible = False

            ButtonItemAccountPayable_WriteOff.Visible = False

            RibbonBarOptions_Actions.ResetCachedContentSize()
            RibbonBarOptions_Actions.Refresh()
            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth
            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_AccountPayable.ResetCachedContentSize()
            RibbonBarOptions_AccountPayable.Refresh()
            RibbonBarOptions_AccountPayable.Width = RibbonBarOptions_AccountPayable.GetAutoSizeWidth
            RibbonBarOptions_AccountPayable.Refresh()

            RibbonBarOptions_Import.Visible = False
            RibbonBarOptions_Templates.Visible = False
            RibbonBarOptions_Orders.Visible = False
            RibbonBarOptions_GridOptions.Visible = False

        End Sub

#End Region

        Private Sub New(ByRef ImportType As AdvantageFramework.Importing.ImportType)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ImportType = ImportType

            If _ImportType = Methods.ImportType.ClearedChecks Then

                _AllowSave = False

            End If

        End Sub
        Private Function HasAnyInvalidRowsNotOnHold() As Boolean

            'objects
            Dim HasInvalidRows As Boolean = False
            Dim ValidatingClass As AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase = Nothing
            Dim IsOnHold As Boolean = False

            Try

                For RowHandle = 0 To Me.DataGridViewForm_ImportedItems.CurrentView.RowCount - 1

                    If Me.DataGridViewForm_ImportedItems.CurrentView.IsDataRow(RowHandle) Then

                        Select Case _ImportType

                            Case Methods.ImportType.AccountsPayable

                                IsOnHold = DirectCast(DirectCast(DataGridViewForm_ImportedItems.DataSource, System.Windows.Forms.BindingSource).Item(Me.DataGridViewForm_ImportedItems.CurrentView.GetDataSourceRowIndex(RowHandle)), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).IsOnHold

                            Case Methods.ImportType.PTO

                                IsOnHold = DirectCast(DirectCast(DataGridViewForm_ImportedItems.DataSource, System.Windows.Forms.BindingSource).Item(Me.DataGridViewForm_ImportedItems.CurrentView.GetDataSourceRowIndex(RowHandle)), AdvantageFramework.Importing.Classes.ImportPTOItem).IsOnHold

                            Case Methods.ImportType.JournalEntry

                                IsOnHold = DirectCast(DirectCast(DataGridViewForm_ImportedItems.DataSource, System.Windows.Forms.BindingSource).Item(Me.DataGridViewForm_ImportedItems.CurrentView.GetDataSourceRowIndex(RowHandle)), AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).IsOnHold

                        End Select

                        If Not IsOnHold Then

                            Try

                                ValidatingClass = DirectCast(DataGridViewForm_ImportedItems.DataSource, System.Windows.Forms.BindingSource).Item(Me.DataGridViewForm_ImportedItems.CurrentView.GetDataSourceRowIndex(RowHandle))

                            Catch ex As Exception
                                ValidatingClass = Nothing
                            End Try

                            If ValidatingClass IsNot Nothing Then

                                If ValidatingClass.HasError Then

                                    HasInvalidRows = True
                                    DataGridViewForm_ImportedItems.CurrentView.MakeRowVisible(RowHandle)
                                    Exit For

                                End If

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                HasInvalidRows = False
            End Try

            HasAnyInvalidRowsNotOnHold = HasInvalidRows

        End Function
        Private Sub LoadImportDefaults()

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ExpenseReport

                    Me.Text = "Expense Report Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Expense Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = False
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_Validate.Visible = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.ClearedChecks

                    Me.Text = "Cleared Checks Import Staging"
                    DataGridViewForm_ImportedItems.ItemDescription = "Cleared Checks(s)"
                    RibbonBarOptions_ClearedChecks.Visible = True
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    RibbonBarOptions_OnHold.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_Print.Visible = False
                    ButtonItemActions_Validate.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = True
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    Me.Text = "Accounts Payable Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = False
                    DataGridViewForm_ImportedItems.ItemDescription = "Accounts Payable Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = True
                    RibbonBarOptions_Orders.Visible = True
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_Validate.Visible = True
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    DataGridViewForm_ImportedItems.RunStandardValidation = False
                    DataGridViewForm_ImportedItems.OptionsMenu.EnableColumnMenu = True
                    DataGridViewForm_ImportedItems.AddFixedColumnCheckItemsToGridMenu = True
                    RibbonBarOptions_GridOptions.Visible = True
                    DataGridViewForm_ImportedItems.OptionsCustomization.AllowColumnMoving = True
                    DataGridViewForm_ImportedItems.CurrentView.OptionsLayout.StoreDataSettings = True
                    DataGridViewForm_ImportedItems.CurrentView.OptionsLayout.StoreAppearance = True
                    DataGridViewForm_ImportedItems.CurrentView.OptionsLayout.StoreVisualOptions = True

                    DataGridViewForm_ImportedItems.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
                    DataGridViewForm_ImportedItems.CurrentView.OptionsLayout.Columns.StoreAppearance = True

                Case AdvantageFramework.Importing.ImportType.Client

                    Me.Text = "Client Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Client Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.Division

                    Me.Text = "Division Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Division Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.Product

                    Me.Text = "Product Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Product Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.Function

                    Me.Text = "Function Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Function Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.ChartOfAccounts

                    Me.Text = "Chart Of Accounts Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Chart Of Account Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                    Me.Text = "Accounts Receivable Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Accounts Receivable Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.DigitalResults

                    Me.Text = "Media Results Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Media Results Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = False
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    'ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.AvalaraTaxCode

                    Me.Text = "Avalara Tax Code Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Avalara Tax Code Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = False
                    ButtonItemActions_AutoFill.Visible = False
                    ButtonItemActions_Validate.Visible = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.CashReceipt

                    Me.Text = "Cash Receipts Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = False
                    DataGridViewForm_ImportedItems.ItemDescription = "Cash Receipts Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    DataGridViewForm_ImportedItems.RunStandardValidation = False
                    DataGridViewForm_ImportedItems.AutoloadRepositoryDatasource = True
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_Validate.Visible = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.ClientContact

                    Me.Text = "Client Contact Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Client Contact Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_AutoFill.Enabled = False
                    ButtonItemActions_Validate.Enabled = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.PTO

                    Me.Text = "PTO Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "PTO Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = False
                    ButtonItemActions_AutoFill.Visible = True
                    ButtonItemActions_Validate.Visible = False
                    ButtonItemActions_Print.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.JournalEntry

                    Me.Text = "Journal Entry Import Staging"
                    DataGridViewForm_ImportedItems.AutoFilterLookupColumns = True
                    DataGridViewForm_ImportedItems.ItemDescription = "Journal Entry Import Item(s)"
                    DataGridViewForm_ImportedItems.AllowSelectGroupHeaderRow = False
                    DataGridViewForm_ImportedItems.RunStandardValidation = False
                    DataGridViewForm_ImportedItems.AutoloadRepositoryDatasource = True
                    RibbonBarOptions_OnHold.Visible = True
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    ButtonItemActions_Export.Visible = False
                    ButtonItemActions_AutoFill.Visible = True
                    ButtonItemActions_Validate.Visible = False
                    ButtonItemActions_Print.Visible = True
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

                Case AdvantageFramework.Importing.ImportType.Employee

                    Me.Text = "Employee Import Staging"
                    DataGridViewForm_ImportedItems.ItemDescription = "Employee(s)"
                    RibbonBarOptions_ClearedChecks.Visible = False
                    RibbonBarOptions_AccountPayable.Visible = False
                    RibbonBarOptions_Orders.Visible = False
                    RibbonBarOptions_OnHold.Visible = False
                    ButtonItemActions_Export.Visible = True
                    ButtonItemActions_Print.Visible = False
                    ButtonItemActions_Validate.Visible = False
                    DataGridViewForm_ImportedItems.ShowSelectDeselectAllButtons = True
                    RibbonBarOptions_CSIPreferredPartner.Visible = False
                    RibbonBarOptions_GridOptions.Visible = False

            End Select

            ComboBoxSettings_ImportType.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Importing.ImportTemplateTypes))
                                                      Where EnumObject.Code.StartsWith(_ImportType.ToString)
                                                      Select EnumObject.Code, EnumObject.Description).ToList

            If _ImportType = Methods.ImportType.AccountsPayable Then

                SetLastSelectedAPImportType()

            End If

        End Sub
        Private Sub LoadAvailableBatches()

            'objects
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim TemplateIDs As IEnumerable(Of Short) = Nothing

            If Me.Session IsNot Nothing Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                DataGridViewForm_ImportedItems.CurrentView.AFActiveFilterString = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue)

                        Select Case ImportTemplateType

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                    AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_MediaVCC

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportClearedCheckMediaVCCStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                                 AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                                 AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast,
                                 AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                                 AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom,
                                 AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast

                                TemplateIDs = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, ImportTemplateType).Select(Of Short)(Function(T) T.ID)

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportAccountPayable.Load(DbContext)
                                                                     Where TemplateIDs.Contains(Entity.ImportTemplateID)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                                _APLockGLAccountCode = (AdvantageFramework.Database.Procedures.Agency.APLockGLAccountCode(DbContext) = 1)

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportClientStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportDivisionStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportProductStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportFunctionStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                                TemplateIDs = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, ImportTemplateType).Select(Of Short)(Function(T) T.ID)

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Load(DbContext)
                                                                     Where Entity.PostFlag Is Nothing AndAlso
                                                                           (Entity.ImportTemplateID Is Nothing OrElse
                                                                            TemplateIDs.Contains(Entity.ImportTemplateID))
                                                                     Select [Value] = If(Entity.BatchName Is Nothing, "<blank>", Entity.BatchName),
                                                                            [Key] = If(Entity.BatchName Is Nothing, "<blank>", Entity.BatchName)).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom

                                TemplateIDs = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, ImportTemplateType).Select(Of Short)(Function(T) T.ID)

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Load(DbContext)
                                                                     Where Entity.PostFlag Is Nothing AndAlso
                                                                           TemplateIDs.Contains(Entity.ImportTemplateID)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportAvalaraTaxStaging.Load(DataContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic,
                                    AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Custom

                                TemplateIDs = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, ImportTemplateType).Select(Of Short)(Function(T) T.ID).ToList

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportCashReceipt.Load(DataContext)
                                                                     Where TemplateIDs.Contains(Entity.ImportTemplateID)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportClientContactStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportPTOStaging.Load(DataContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default,
                                    AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE

                                TemplateIDs = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, ImportTemplateType).Select(Of Short)(Function(T) T.ID)

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportJournalEntry.Load(DbContext)
                                                                     Where TemplateIDs.Contains(Entity.ImportTemplateID)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                                ComboBoxSettings_Batch.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ImportEmployeeHoursStaging.Load(DbContext)
                                                                     Select [Value] = Entity.BatchName,
                                                                            [Key] = Entity.BatchName).Distinct.ToList

                        End Select

                    End Using

                End Using

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub LoadSelectedBatch()

            'objects
            Dim BatchName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim ImportedClearedChecksList As Generic.List(Of AdvantageFramework.Database.Classes.ImportedClearedCheck) = Nothing
            Dim IsAPLimitByOfficeEnabled As Boolean = False
            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim ImportAccountReceivableStagingList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging) = Nothing
            Dim ImportClientCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim ImportClearedCheckMediaVCCList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC) = Nothing
            Dim AFActiveFilterString As String = Nothing
            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim DeleteBatch As Boolean = False

            If Me.Session IsNot Nothing Then

                AFActiveFilterString = DataGridViewForm_ImportedItems.CurrentView.AFActiveFilterString

                DataGridViewForm_ImportedItems.CurrentView.BeginUpdate()

                DataGridViewForm_ImportedItems.ClearGridCustomization()

                ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue)

                If ComboBoxSettings_Batch.HasASelectedValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            BatchName = ComboBoxSettings_Batch.SelectedValue

                            _LastLoadedBatchName = BatchName

                            Select Case ImportTemplateType

                                Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                        AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportCreditCardStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ExpenseReportDate).ThenBy(Function(Entity) Entity.ItemDate).ToList

                                    DataGridViewForm_ImportedItems.HideOrShowColumn(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentNumber.ToString, False)

                                Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                    ImportedClearedChecksList = (From ImportClearedChecksStaging In AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.LoadByBatchName(DbContext, BatchName).ToList
                                                                 Select New AdvantageFramework.Database.Classes.ImportedClearedCheck(DbContext, ImportClearedChecksStaging)).ToList

                                    If ButtonItemClearedChecks_Invalid.Checked Then

                                        ImportedClearedChecksList = ImportedClearedChecksList.Where(Function(Entity) Entity.IsValid = False).ToList

                                    ElseIf ButtonItemClearedChecks_Valid.Checked Then

                                        ImportedClearedChecksList = ImportedClearedChecksList.Where(Function(Entity) Entity.IsValid = True).ToList

                                    End If

                                    DataGridViewForm_ImportedItems.DataSource = ImportedClearedChecksList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_MediaVCC

                                    SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@BatchName", SqlDbType.VarChar)
                                    SqlParameterBatchName.Value = BatchName

                                    ImportClearedCheckMediaVCCList = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC) _
                                            ("exec advsp_cleared_check_media_vcc_load_batch @BatchName", SqlParameterBatchName).ToList

                                    If ButtonItemClearedChecks_Invalid.Checked Then

                                        ImportClearedCheckMediaVCCList = ImportClearedCheckMediaVCCList.Where(Function(Entity) Entity.IsValid = False).ToList

                                    ElseIf ButtonItemClearedChecks_Valid.Checked Then

                                        ImportClearedCheckMediaVCCList = ImportClearedCheckMediaVCCList.Where(Function(Entity) Entity.IsValid = True).ToList

                                    End If

                                    DataGridViewForm_ImportedItems.DataSource = ImportClearedCheckMediaVCCList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast

                                    IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)
                                    IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

                                    ImportAccountPayableList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                                    DataGridViewForm_ImportedItems.ClearDatasource(ImportAccountPayableList)

                                    For Each ImportAccountPayable In AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, BatchName).Include("ImportAccountPayableGLs").Include("ImportAccountPayableJobs").Include("ImportAccountPayableMedias").Include("ImportAccountPayableErrors").Include("ImportAccountPayableMedias.ImportAccountPayableBroadcastDetails").ToList

                                        AccountsPayableAddEntityToList(DbContext, ImportAccountPayable, ImportAccountPayableList, IsAPLimitByOfficeEnabled, IsInterCompanyTransactionsEnabled, Session)

                                    Next

                                    If ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                                        OrderNumbers = ImportAccountPayableList.Where(Function(APL) APL.OrderNumber.HasValue).Select(Function(APL) APL.OrderNumber.Value).ToArray

                                        If OrderNumbers IsNot Nothing AndAlso OrderNumbers.Count > 0 Then

                                            _OrderNumberSearchResultList = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult)(String.Format("EXEC [dbo].[advsp_media_broadcast_worksheet_search_by_order_number] '{0}'", String.Join(",", OrderNumbers.ToArray))).ToList

                                        Else

                                            _OrderNumberSearchResultList = Nothing

                                        End If

                                    End If

                                    If ImportAccountPayableList.Count > 0 Then

                                        AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ImportedItems, Database.Entities.GridAdvantageType.AccountsPayableImport, ImportAccountPayableList.FirstOrDefault.GetImportAccountPayableHeader.ImportTemplateID)

                                        DataGridViewForm_ImportedItems.DataSource = ImportAccountPayableList
                                        'AccountsPayableSetVisibleColumns(IsAPLimitByOfficeEnabled, IsInterCompanyTransactionsEnabled)

                                        AccountsPayableLoadGridLayout()

                                        CalculateBottomLineAmounts()

                                        For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                                            If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString AndAlso
                                                TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                                Try

                                                    SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                                                Catch ex As Exception
                                                    SubItemGridLookUpEditControl = Nothing
                                                End Try

                                                If SubItemGridLookUpEditControl IsNot Nothing Then

                                                    SubItemGridLookUpEditControl.ValueMember = "OrderNumber"

                                                End If

                                            End If

                                        Next

                                        'If ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                                        '    If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString) IsNot Nothing Then

                                        '        DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString).Visible = False

                                        '    End If

                                        'End If

                                        If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxGLAccount.ToString) IsNot Nothing Then

                                            DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxGLAccount.ToString).OptionsColumn.AllowEdit = (ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast)

                                        End If

                                        If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxAmount.ToString) IsNot Nothing Then

                                            DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxAmount.ToString).OptionsColumn.AllowEdit = (ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast)

                                        End If

                                        If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxGLAccount.ToString) IsNot Nothing Then

                                            DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxGLAccount.ToString).OptionsColumn.AllowEdit = (ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast)

                                        End If

                                        If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxAmount.ToString) IsNot Nothing Then

                                            DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxAmount.ToString).OptionsColumn.AllowEdit = (ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast)

                                        End If

                                    Else

                                        If AdvantageFramework.WinForm.MessageBox.Show("No details found for this batch.  Delete batch?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                            DeleteBatch = True

                                        End If

                                    End If

                                Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportClientContactStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportClientStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                    For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                                        If GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportClientStaging.Properties.FiscalStart.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.DateUtilities.Months))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AssignProductionInvoicesBy.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.AssignProductionInvoicesBy))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportClientStaging.Properties.AssignMediaInvoicesBy.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.AssignMediaInvoicesBy))

                                        End If

                                    Next

                                Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportDivisionStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportProductStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                    For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                                        If GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetBillSetting.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.InternetDaysToBillTimeframe))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazineBillSetting.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperBillSetting.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.PrintDaysToBillTimeframe))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomeBillSetting.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.OutofHomeDaysToBillTimeframe))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioBillSetting.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionBillSetting.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.BroadcastDaysToBillTimeframe))

                                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.InternetPrePostBill.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.MagazinePrePostBill.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.NewspaperPrePostBill.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.OutOfHomePrePostBill.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.RadioPrePostBill.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.TelevisionPrePostBill.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.MediaPrebillPostbill))

                                        End If

                                    Next

                                Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportFunctionStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                    For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                                        If GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.Type.ToString Then

                                            AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, GridColumn, GetType(Short), GetType(AdvantageFramework.Database.Entities.InternetDaysToBillTimeframe))

                                        End If

                                    Next

                                Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.LoadByBatchName(DbContext, BatchName).OrderBy(Function(Entity) Entity.ID).ToList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default,
                                     AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom

                                    ImportAccountReceivableStagingList = New Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)

                                    If BatchName = "<blank>" Then

                                        ImportAccountReceivableStagingList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.LoadLegacyUnprocessedEntries(DbContext).ToList
                                                                                    Select New AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging(Entity))

                                    Else

                                        ImportAccountReceivableStagingList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.LoadByBatchName(DbContext, BatchName).ToList
                                                                                    Select New AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging(Entity))

                                    End If

                                    DataGridViewForm_ImportedItems.DataSource = ImportAccountReceivableStagingList.OrderBy(Function(F) F.RecordNumber)

                                    If ImportTemplateType = ImportTemplateTypes.AccountsReceivable_Custom AndAlso
                                            DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.SalesClassCode.ToString) IsNot Nothing Then

                                        DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.SalesClassCode.ToString).OptionsColumn.ReadOnly = True

                                    End If

                                Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.DigitalResults.LoadImportStagingsByBatchName(DbContext, BatchName, True).ToList

                                    DataGridViewForm_ImportedItems.CurrentView.ViewCaption = DataGridViewForm_ImportedItems.CurrentView.RowCount & " Media Result(s)"

                                Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportAvalaraTaxStaging.LoadByBatchName(DataContext, BatchName).ToList

                                Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic,
                                         AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Custom

                                    ImportClientCashReceiptList = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)

                                    For Each ImportCashReceipt In AdvantageFramework.Database.Procedures.ImportCashReceipt.LoadByBatchName(DataContext, BatchName).ToList

                                        CashReceiptAddEntityToList(DbContext, ImportCashReceipt, ImportClientCashReceiptList)

                                    Next

                                    DataGridViewForm_ImportedItems.DataSource = ImportClientCashReceiptList

                                    For Each GridColumn In DataGridViewForm_ImportedItems.Columns

                                        If GridColumn.FieldName <> AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.IsCleared.ToString AndAlso
                                                GridColumn.FieldName <> AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.IsOnHold.ToString AndAlso
                                                GridColumn.FieldName <> AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceSequence.ToString AndAlso
                                                GridColumn.FieldName <> AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.PaymentTypeDescription.ToString Then

                                            GridColumn.OptionsColumn.AllowFocus = False

                                        End If

                                    Next

                                    LoadCashReceiptRepositoryItems(DbContext)

                                Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                    SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)

                                    SqlParameterBatchName.Value = BatchName

                                    DataGridViewForm_ImportedItems.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Importing.Classes.ImportPTOItem)("exec advsp_pto_import_load_batch @batch_name", SqlParameterBatchName).ToList

                                    If DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Status.ToString) IsNot Nothing Then

                                        AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_ImportedItems, DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Status.ToString), GetType(Short), GetType(AdvantageFramework.Database.Entities.PTOImportStatus))

                                    End If

                                Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default,
                                        AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE

                                    ImportJournalEntryList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)

                                    For Each ImportJournalEntry In AdvantageFramework.Database.Procedures.ImportJournalEntry.LoadByBatchName(DbContext, BatchName).ToList

                                        AdvantageFramework.GeneralLedger.JournalEntryAddEntityToList(DbContext, ImportJournalEntry, ImportJournalEntryList, ImportTemplateType)

                                    Next

                                    DataGridViewForm_ImportedItems.DataSource = ImportJournalEntryList

                                    For Each GridColumn In DataGridViewForm_ImportedItems.Columns

                                        If GridColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.TransactionID.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.IDSeq.ToString OrElse
                                                GridColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLDescription.ToString Then

                                            GridColumn.OptionsColumn.AllowFocus = False

                                        End If

                                    Next

                                Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                                    DataGridViewForm_ImportedItems.DataSource = AdvantageFramework.Database.Procedures.ImportEmployeeHoursStaging.LoadByBatchName(DbContext, BatchName).ToList

                            End Select

                        End Using

                    End Using

                    ApplyGrouping()

                Else

                    _LastLoadedBatchName = Nothing

                    Select Case ImportTemplateType

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.ImportedClearedCheck))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                             AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportClientStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportClientContactStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportDivisionStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportProductStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportFunctionStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging))

                            DataGridViewForm_ImportedItems.CurrentView.ViewCaption = "Media Result(s)"

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic,
                                AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Custom

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Importing.Classes.ImportPTOItem))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry))

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging))

                    End Select

                End If

                If DeleteBatch Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                        SqlParameterBatchName.Value = ComboBoxSettings_Batch.GetSelectedValue()

                        DbContext.Database.ExecuteSqlCommand("exec advsp_ap_import_delete_batch @batch_name", SqlParameterBatchName)

                    End Using

                    LoadAvailableBatches()

                Else

                    DataGridViewForm_ImportedItems.CurrentView.AFActiveFilterString = AFActiveFilterString

                    DataGridViewForm_ImportedItems.CurrentView.BestFitColumns()

                    Try

                        If ImportType <> Methods.ImportType.AccountsPayable Then

                            ValidateAllRows(True)

                            Me.ClearChanged()

                        End If

                    Catch ex As Exception

                    End Try

                    If ImportTemplateType = ImportTemplateTypes.DigitalResults_Default AndAlso
                        DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.Note.ToString) IsNot Nothing Then

                        DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.Note.ToString).Width = 200

                    End If

                End If

                DataGridViewForm_ImportedItems.CurrentView.EndUpdate()

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim ExportButtonEnabled As Boolean = False
            Dim ImportButtonEnabled As Boolean = False
            Dim SaveButtonEnabled As Boolean = False
            Dim DeleteButtonEnabled As Boolean = False
            Dim RefreshButtonEnabled As Boolean = False
            Dim AutoFillButtonEnabled As Boolean = False
            Dim ClearedChecksAllButtonEnabled As Boolean = False
            Dim ClearedChecksValidButtonEnabled As Boolean = False
            Dim ClearedChecksInvalidButtonEnabled As Boolean = False
            Dim CSIPreferredPartnerImportButtonEnabled As Boolean = False
            Dim ImportAccountPayables As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim SelectedRowsHaveNoOrderVariance As Boolean = False
            Dim AddButtonEnabled As Boolean = False
            Dim NewBatchEnabled As Boolean = True
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ExpenseReport

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                Case AdvantageFramework.Importing.ImportType.ClearedChecks

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    SaveButtonEnabled = False
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ClearedChecksValidButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ClearedChecksInvalidButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                    If AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue) = AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default Then

                        CSIPreferredPartnerImportButtonEnabled = True

                    Else

                        DataGridViewForm_ImportedItems.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

                        RibbonBarOptions_CSIPreferredPartner.Visible = False
                        ButtonItemTemplates_Edit.Enabled = False

                    End If

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridViewForm_ImportedItems.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    AddButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                    ImportAccountPayables = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().ToList

                    SelectedRowsHaveNoOrderVariance = (From ImportAccountPayable In ImportAccountPayables
                                                       Where ImportAccountPayable.OrderNetVariance.GetValueOrDefault(0) = 0 OrElse
                                                             ImportAccountPayable.OrderNumber.GetValueOrDefault(0) = 0 OrElse
                                                             ImportAccountPayable.OrderLineNumber.GetValueOrDefault(0) = 0
                                                       Select ImportAccountPayable).Any

                    ButtonItemAccountPayable_ShowAll.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ButtonItemAccountPayable_UpdateDescription.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ButtonItemAccountPayable_WriteOff.Enabled = ComboBoxSettings_Batch.HasASelectedValue AndAlso SelectedRowsHaveNoOrderVariance = False
                    ButtonItemAccountPayable_ClearOrderLine.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ButtonItemAccountPayable_Update.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False) AndAlso
                        AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue) = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast

                    If _OrderNumberSearchResultList IsNot Nothing AndAlso _OrderNumberSearchResultList.Count > 0 Then

                        ButtonItemMediaOrder_Create.Enabled = False

                        OrderNumbers = _OrderNumberSearchResultList.Select(Function(Entity) Entity.OrderNumber).Distinct.ToArray

                        If OrderNumbers IsNot Nothing AndAlso OrderNumbers.Count > 0 AndAlso DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Count > 0 Then

                            If (From Entity In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)
                                Where Entity.OrderNumber.HasValue AndAlso
                                      OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                      Entity.ErrorHashtable.Count = 1 AndAlso
                                      String.IsNullOrWhiteSpace(Entity.ErrorHashtable(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString)) = False AndAlso
                                      Entity.MediaGrossRate.GetValueOrDefault(0) = 0
                                Select Entity).Any Then

                                ButtonItemMediaOrder_AddToWorksheet.Enabled = True

                            Else

                                ButtonItemMediaOrder_AddToWorksheet.Enabled = False

                            End If

                        Else

                            ButtonItemMediaOrder_AddToWorksheet.Enabled = False

                        End If

                    Else

                        ButtonItemMediaOrder_Create.Enabled = _OrderNumberSearchResultList Is Nothing AndAlso DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ToList.Any(Function(iap) iap.ImportAccountPayableMediaID <> 0)
                        ButtonItemMediaOrder_AddToWorksheet.Enabled = False

                    End If

                    ButtonItemGridOptions_ChooseColumns.Enabled = ComboBoxSettings_Batch.HasASelectedValue
                    ButtonItemGridOptions_RestoreDefaults.Enabled = ComboBoxSettings_Batch.HasASelectedValue

                Case Methods.ImportType.Client

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.Division

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.Product

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.Function

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.ChartOfAccounts

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.AccountsReceivable

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.DigitalResults

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                Case Methods.ImportType.AvalaraTaxCode

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                Case Methods.ImportType.CashReceipt

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    'AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                Case Methods.ImportType.ClientContact

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                Case Methods.ImportType.PTO

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

                Case Methods.ImportType.JournalEntry

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    RibbonBarOptions_OnHold.Enabled = DataGridViewForm_ImportedItems.HasRows

                    If ComboBoxSettings_ImportType.GetSelectedValue = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE.ToString Then

                        NewBatchEnabled = False

                    End If

                Case Methods.ImportType.Employee

                    ExportButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    ImportButtonEnabled = DataGridViewForm_ImportedItems.HasRows
                    SaveButtonEnabled = Me.UserEntryChanged AndAlso DataGridViewForm_ImportedItems.HasRows
                    DeleteButtonEnabled = DataGridViewForm_ImportedItems.HasASelectedRow
                    RefreshButtonEnabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)
                    AutoFillButtonEnabled = False
                    ClearedChecksAllButtonEnabled = False
                    ClearedChecksValidButtonEnabled = False
                    ClearedChecksInvalidButtonEnabled = False
                    CSIPreferredPartnerImportButtonEnabled = False

                    ButtonItemActions_Validate.Enabled = If(ComboBoxSettings_Batch.HasASelectedValue, True, False)

            End Select

            ButtonItemActions_Export.Enabled = ExportButtonEnabled
            ButtonItemActions_Add.Enabled = AddButtonEnabled
            ButtonItemActions_Save.Enabled = _AllowSave AndAlso SaveButtonEnabled
            ButtonItemActions_Delete.Enabled = DeleteButtonEnabled
            ButtonItemActions_Refresh.Enabled = RefreshButtonEnabled
            ButtonItemActions_AutoFill.Enabled = AutoFillButtonEnabled
            ButtonItemClearedChecks_All.Enabled = ClearedChecksAllButtonEnabled
            ButtonItemClearedChecks_Invalid.Enabled = ClearedChecksInvalidButtonEnabled
            ButtonItemClearedChecks_Valid.Enabled = ClearedChecksValidButtonEnabled
            ButtonItemActions_Import.Enabled = ImportButtonEnabled
            ButtonItemActions_Mapping.Enabled = False
            ButtonItemCSIPreferredPartner_Import.Enabled = CSIPreferredPartnerImportButtonEnabled
            ButtonItemOnHold_Check.Enabled = DataGridViewForm_ImportedItems.HasASelectedRow
            ButtonItemOnHold_Uncheck.Enabled = DataGridViewForm_ImportedItems.HasASelectedRow
            ButtonItemImport_NewBatch.Enabled = NewBatchEnabled

        End Sub
        Function IsRelationEmpty(ByVal RowHandle As Integer) As Boolean

            Dim RelationIsEmpty As Boolean = False

            'If RowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

            '    RelationIsEmpty = True

            'End If

            If ImportType <> Methods.ImportType.AccountsPayable Then

                RelationIsEmpty = True

            End If

            IsRelationEmpty = RelationIsEmpty

        End Function
        Private Function Save(ByVal ValidateRows As Boolean, Optional ByVal BypassSavingErrors As Boolean = False)

            'objects
            Dim Saved As Boolean = True
            Dim ImportAccountPayableError As AdvantageFramework.Database.Entities.ImportAccountPayableError = Nothing
            Dim ImportAccountPayableErrors As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableError) = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim PropertyName As String = ""
            Dim ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging = Nothing
            Dim ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt = Nothing
            Dim ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail = Nothing
            Dim ImportPTOStaging As AdvantageFramework.Database.Entities.ImportPTOStaging = Nothing
            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing
            Dim ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
            Dim ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging = Nothing

            If DataGridViewForm_ImportedItems.HasRows Then

                DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Select Case _ImportType

                                Case ImportType.ExpenseReport

                                    For Each ImportCreditCardStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging)().ToList

                                        DbContext.UpdateObject(ImportCreditCardStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.ClearedChecks

                                    For Each ImportClearedChecksStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClearedChecksStaging)().ToList

                                        DbContext.UpdateObject(ImportClearedChecksStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.AccountsPayable

                                    ImportAccountPayableList = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Where(Function(IJE) IJE.Modified = True).ToList

                                    DbContext.Configuration.AutoDetectChangesEnabled = False

                                    AccountsPayableSaveDataGridViewLayout()

                                    If BypassSavingErrors Then

                                        For Each Header In (From Entity In ImportAccountPayableList
                                                            Select Entity.GetImportAccountPayableHeader).Distinct

                                            ImportAccountPayable = DbContext.ImportAccountPayables.Find(Header.ID)

                                            If ImportAccountPayable IsNot Nothing Then

                                                DbContext.Entry(ImportAccountPayable).CurrentValues.SetValues(Header.GetEntity)

                                            End If

                                        Next

                                        For Each IAP In ImportAccountPayableList

                                            If TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableGL Then

                                                ImportAccountPayableGL = DbContext.ImportAccountPayableGLs.Find(IAP.ImportAccountPayableGLID)
                                                DbContext.Entry(ImportAccountPayableGL).CurrentValues.SetValues(IAP.GetDetail)

                                            ElseIf TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableJob Then

                                                ImportAccountPayableJob = DbContext.ImportAccountPayableJobs.Find(IAP.ImportAccountPayableJobID)
                                                DbContext.Entry(ImportAccountPayableJob).CurrentValues.SetValues(IAP.GetDetail)

                                            ElseIf TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableMedia Then

                                                ImportAccountPayableMedia = DbContext.ImportAccountPayableMedias.Find(IAP.ImportAccountPayableMediaID)
                                                DbContext.Entry(ImportAccountPayableMedia).CurrentValues.SetValues(IAP.GetDetail)

                                            End If

                                        Next

                                    Else

                                        For Each IAP In ImportAccountPayableList

                                            ImportAccountPayableErrors = IAP.GetHeader.ImportAccountPayableErrors.ToList

                                            'clear header errors
                                            For Each ImportAccountPayableError In ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableGLID Is Nothing AndAlso
                                                                                                                           E.ImportAccountPayableJobID Is Nothing AndAlso
                                                                                                                           E.ImportAccountPayableMediaID Is Nothing AndAlso
                                                                                                                           E.ImportAccountPayableID = IAP.ID AndAlso
                                                                                                                           IAP.GetImportAccountPayableHeader.ErrorHashtable.Item(E.PropertyName) = "")

                                                If ImportAccountPayableError IsNot Nothing Then

                                                    Try

                                                        DbContext.DeleteEntityObject(ImportAccountPayableError)

                                                    Catch ex As Exception

                                                    End Try

                                                End If

                                            Next

                                            'clear media errors
                                            For Each ImportAccountPayableError In ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableMediaID IsNot Nothing AndAlso
                                                                                                                           E.ImportAccountPayableMediaID = IAP.ImportAccountPayableMediaID AndAlso
                                                                                                                           IAP.GetImportAccountPayableMedia.ErrorHashtable.Item(E.PropertyName) = "")

                                                If ImportAccountPayableError IsNot Nothing Then

                                                    DbContext.DeleteEntityObject(ImportAccountPayableError)

                                                End If

                                            Next

                                            'clear job errors
                                            For Each ImportAccountPayableError In ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableJobID IsNot Nothing AndAlso
                                                                                                                           E.ImportAccountPayableJobID = IAP.ImportAccountPayableJobID AndAlso
                                                                                                                           IAP.GetImportAccountPayableJob.ErrorHashtable.Item(E.PropertyName) = "")

                                                If ImportAccountPayableError IsNot Nothing Then

                                                    DbContext.DeleteEntityObject(ImportAccountPayableError)

                                                End If

                                            Next

                                            'clear gl errors
                                            For Each ImportAccountPayableError In ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableGLID IsNot Nothing AndAlso
                                                                                                                           E.ImportAccountPayableGLID = IAP.ImportAccountPayableGLID AndAlso
                                                                                                                           IAP.GetImportAccountPayableGL.ErrorHashtable.Item(E.PropertyName) = "")

                                                If ImportAccountPayableError IsNot Nothing Then

                                                    DbContext.DeleteEntityObject(ImportAccountPayableError)

                                                End If

                                            Next

                                            'add header errors
                                            For Each PropertyName In IAP.GetImportAccountPayableHeader.ErrorHashtable.Keys.OfType(Of String)()

                                                If IAP.GetImportAccountPayableHeader.ErrorHashtable.Item(PropertyName) <> "" Then

                                                    Try

                                                        ImportAccountPayableError = ImportAccountPayableErrors.Where(Function(E) E.PropertyName = PropertyName).SingleOrDefault

                                                    Catch ex As Exception
                                                        ImportAccountPayableError = Nothing
                                                    End Try

                                                    If ImportAccountPayableError Is Nothing Then

                                                        ImportAccountPayableError = New AdvantageFramework.Database.Entities.ImportAccountPayableError
                                                        ImportAccountPayableError.DbContext = DbContext

                                                        ImportAccountPayableError.ImportAccountPayableID = IAP.ID
                                                        ImportAccountPayableError.PropertyName = PropertyName
                                                        ImportAccountPayableError.ErrorDescription = IAP.ErrorHashtable.Item(PropertyName)

                                                        DbContext.ImportAccountPayableErrors.Add(ImportAccountPayableError)

                                                    Else

                                                        'DbContext.Entry(ImportAccountPayableError).State = Entity.EntityState.Modified
                                                        DbContext.UpdateObject(ImportAccountPayableError)

                                                    End If

                                                End If

                                            Next

                                            'add media errors
                                            For Each PropertyName In IAP.GetImportAccountPayableMedia.ErrorHashtable.Keys.OfType(Of String)()

                                                If IAP.GetImportAccountPayableMedia.ErrorHashtable.Item(PropertyName) <> "" Then

                                                    Try

                                                        ImportAccountPayableError = ImportAccountPayableErrors.Where(Function(E) E.PropertyName = PropertyName AndAlso
                                                                                                                             E.ImportAccountPayableMediaID IsNot Nothing AndAlso
                                                                                                                             E.ImportAccountPayableMediaID = IAP.ImportAccountPayableMediaID).SingleOrDefault

                                                    Catch ex As Exception
                                                        ImportAccountPayableError = Nothing
                                                    End Try

                                                    If ImportAccountPayableError Is Nothing Then

                                                        ImportAccountPayableError = New AdvantageFramework.Database.Entities.ImportAccountPayableError
                                                        ImportAccountPayableError.DbContext = DbContext

                                                        ImportAccountPayableError.ImportAccountPayableID = IAP.ID
                                                        ImportAccountPayableError.PropertyName = PropertyName
                                                        ImportAccountPayableError.ErrorDescription = IAP.ErrorHashtable.Item(PropertyName)

                                                        ImportAccountPayableError.ImportAccountPayableMediaID = IAP.ImportAccountPayableMediaID

                                                        DbContext.ImportAccountPayableErrors.Add(ImportAccountPayableError)

                                                    Else

                                                        'DbContext.Entry(ImportAccountPayableError).State = Entity.EntityState.Modified
                                                        DbContext.UpdateObject(ImportAccountPayableError)

                                                    End If

                                                End If

                                            Next

                                            'add job errors
                                            For Each PropertyName In IAP.GetImportAccountPayableJob.ErrorHashtable.Keys.OfType(Of String)()

                                                If IAP.GetImportAccountPayableJob.ErrorHashtable.Item(PropertyName) <> "" Then

                                                    Try

                                                        ImportAccountPayableError = ImportAccountPayableErrors.Where(Function(E) E.PropertyName = PropertyName AndAlso
                                                                                                                             E.ImportAccountPayableJobID IsNot Nothing AndAlso
                                                                                                                             E.ImportAccountPayableJobID = IAP.ImportAccountPayableJobID).SingleOrDefault

                                                    Catch ex As Exception
                                                        ImportAccountPayableError = Nothing
                                                    End Try

                                                    If ImportAccountPayableError Is Nothing Then

                                                        ImportAccountPayableError = New AdvantageFramework.Database.Entities.ImportAccountPayableError
                                                        ImportAccountPayableError.DbContext = DbContext

                                                        ImportAccountPayableError.ImportAccountPayableID = IAP.ID
                                                        ImportAccountPayableError.PropertyName = PropertyName
                                                        ImportAccountPayableError.ErrorDescription = IAP.ErrorHashtable.Item(PropertyName)

                                                        ImportAccountPayableError.ImportAccountPayableJobID = IAP.ImportAccountPayableJobID

                                                        DbContext.ImportAccountPayableErrors.Add(ImportAccountPayableError)

                                                    Else

                                                        'DbContext.Entry(ImportAccountPayableError).State = Entity.EntityState.Modified
                                                        DbContext.UpdateObject(ImportAccountPayableError)

                                                    End If

                                                End If

                                            Next

                                            'add gl errors
                                            For Each PropertyName In IAP.GetImportAccountPayableGL.ErrorHashtable.Keys.OfType(Of String)()

                                                If IAP.GetImportAccountPayableGL.ErrorHashtable.Item(PropertyName) <> "" Then

                                                    Try

                                                        ImportAccountPayableError = ImportAccountPayableErrors.Where(Function(E) E.PropertyName = PropertyName AndAlso
                                                                                                                             E.ImportAccountPayableGLID IsNot Nothing AndAlso
                                                                                                                             E.ImportAccountPayableGLID = IAP.ImportAccountPayableGLID).SingleOrDefault

                                                    Catch ex As Exception
                                                        ImportAccountPayableError = Nothing
                                                    End Try

                                                    If ImportAccountPayableError Is Nothing Then

                                                        ImportAccountPayableError = New AdvantageFramework.Database.Entities.ImportAccountPayableError
                                                        ImportAccountPayableError.DbContext = DbContext

                                                        ImportAccountPayableError.ImportAccountPayableID = IAP.ID
                                                        ImportAccountPayableError.PropertyName = PropertyName
                                                        ImportAccountPayableError.ErrorDescription = IAP.ErrorHashtable.Item(PropertyName)

                                                        ImportAccountPayableError.ImportAccountPayableGLID = IAP.ImportAccountPayableGLID

                                                        DbContext.ImportAccountPayableErrors.Add(ImportAccountPayableError)

                                                    Else

                                                        'DbContext.Entry(ImportAccountPayableError).State = Entity.EntityState.Modified
                                                        DbContext.UpdateObject(ImportAccountPayableError)

                                                    End If

                                                End If

                                            Next

                                            ImportAccountPayable = DbContext.ImportAccountPayables.Find(IAP.GetHeader.ID)

                                            If ImportAccountPayable IsNot Nothing Then

                                                DbContext.Entry(ImportAccountPayable).CurrentValues.SetValues(IAP.GetHeader)

                                            End If
                                            'DbContext.UpdateObject(IAP.GetHeader)

                                            If TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableGL Then

                                                ImportAccountPayableGL = DbContext.ImportAccountPayableGLs.Find(IAP.ImportAccountPayableGLID)
                                                DbContext.Entry(ImportAccountPayableGL).CurrentValues.SetValues(IAP.GetDetail)

                                            ElseIf TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableJob Then

                                                ImportAccountPayableJob = DbContext.ImportAccountPayableJobs.Find(IAP.ImportAccountPayableJobID)
                                                DbContext.Entry(ImportAccountPayableJob).CurrentValues.SetValues(IAP.GetDetail)

                                            ElseIf TypeOf IAP.GetDetail Is AdvantageFramework.Database.Entities.ImportAccountPayableMedia Then

                                                ImportAccountPayableMedia = DbContext.ImportAccountPayableMedias.Find(IAP.ImportAccountPayableMediaID)
                                                DbContext.Entry(ImportAccountPayableMedia).CurrentValues.SetValues(IAP.GetDetail)

                                            End If
                                            'DbContext.UpdateObject(IAP.GetDetail)

                                        Next

                                    End If

                                    DbContext.SaveChanges()

                                    DbContext.Configuration.AutoDetectChangesEnabled = True

                                    ClearModifiedFlag()

                                Case ImportType.Client

                                    For Each ImportClientStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientStaging)().ToList

                                        DbContext.UpdateObject(ImportClientStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.Division

                                    For Each ImportDivisionStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDivisionStaging)().ToList

                                        DbContext.UpdateObject(ImportDivisionStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.Product

                                    For Each ImportProductStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportProductStaging)().ToList

                                        DbContext.UpdateObject(ImportProductStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.Function

                                    For Each ImportFunctionStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportFunctionStaging)().ToList

                                        DbContext.UpdateObject(ImportFunctionStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.ChartOfAccounts

                                    For Each ImportGeneralLedgerAccountStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging)().ToList

                                        DbContext.UpdateObject(ImportGeneralLedgerAccountStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.AccountsReceivable

                                    Try

                                        DbContext.Configuration.AutoDetectChangesEnabled = False

                                        For Each ImportAccountReceivableStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)().Where(Function(IARS) IARS.Modified = True).ToList

                                            AccountReceivableImportStaging = DbContext.AccountReceivableImportStagings.Find(ImportAccountReceivableStaging.RecordNumber)

                                            If AccountReceivableImportStaging IsNot Nothing Then

                                                DbContext.Entry(AccountReceivableImportStaging).CurrentValues.SetValues(ImportAccountReceivableStaging.AccountReceivableImportStaging)

                                            End If

                                        Next

                                        DbContext.SaveChanges()

                                        ClearModifiedFlag()

                                    Catch ex As Exception
                                        Saved = False
                                    Finally
                                        DbContext.Configuration.AutoDetectChangesEnabled = True
                                    End Try

                                Case ImportType.DigitalResults

                                    For Each ImportDigitalResultsStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)().ToList

                                        DbContext.UpdateObject(ImportDigitalResultsStaging)

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.AvalaraTaxCode

                                    For Each IATS In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)().ToList

                                        ImportAvalaraTaxStaging = AdvantageFramework.Database.Procedures.ImportAvalaraTaxStaging.LoadByImportID(DataContext, IATS.ImportID)

                                        If ImportAvalaraTaxStaging IsNot Nothing Then

                                            ImportAvalaraTaxStaging.IsOnHold = IATS.IsOnHold
                                            ImportAvalaraTaxStaging.Code = IATS.Code
                                            ImportAvalaraTaxStaging.Description = IATS.Description
                                            ImportAvalaraTaxStaging.LongDescription = IATS.LongDescription
                                            ImportAvalaraTaxStaging.IsInactive = IATS.IsInactive

                                            If AdvantageFramework.Database.Procedures.ImportAvalaraTaxStaging.Update(DataContext, ImportAvalaraTaxStaging) = False Then

                                                Saved = False

                                            End If

                                        End If

                                    Next

                                Case ImportType.CashReceipt

                                    For Each ICCR In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)().ToList

                                        ImportCashReceipt = AdvantageFramework.Database.Procedures.ImportCashReceipt.LoadByID(DataContext, ICCR.ID)

                                        If ImportCashReceipt IsNot Nothing Then

                                            ImportCashReceipt.IsOnHold = ICCR.IsOnHold
                                            ImportCashReceipt.IsCleared = ICCR.IsCleared
                                            ImportCashReceipt.PaymentTypeDescription = ICCR.PaymentTypeDescription

                                            If AdvantageFramework.Database.Procedures.ImportCashReceipt.Update(DataContext, ImportCashReceipt) = False Then

                                                Saved = False

                                            End If

                                        End If

                                        ImportCashReceiptDetail = AdvantageFramework.Database.Procedures.ImportCashReceiptDetail.LoadByID(DataContext, ICCR.ImportClientCashReceiptDetail.DetailID)

                                        If ImportCashReceiptDetail IsNot Nothing Then

                                            ImportCashReceiptDetail.ARInvoiceNumber = ICCR.ARInvoiceNumber
                                            ImportCashReceiptDetail.ARInvoiceSequence = ICCR.ARInvoiceSequence

                                            If AdvantageFramework.Database.Procedures.ImportCashReceiptDetail.Update(DataContext, ImportCashReceiptDetail) = False Then

                                                Saved = False

                                            End If

                                        End If

                                    Next

                                Case ImportType.ClientContact

                                    For Each ImportClientContactStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientContactStaging)().ToList

                                        DbContext.Entry(ImportClientContactStaging).State = Entity.EntityState.Modified

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                Case ImportType.PTO

                                    For Each IPTOS In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Importing.Classes.ImportPTOItem)().ToList

                                        ImportPTOStaging = AdvantageFramework.Database.Procedures.ImportPTOStaging.LoadByImportID(DataContext, IPTOS.ImportID)

                                        If ImportPTOStaging IsNot Nothing Then

                                            ImportPTOStaging.IsOnHold = IPTOS.IsOnHold
                                            ImportPTOStaging.EmployeeCode = IPTOS.EmployeeCode
                                            ImportPTOStaging.Category = IPTOS.Category
                                            ImportPTOStaging.Description = IPTOS.Description
                                            ImportPTOStaging.ActivityStart = IPTOS.ActivityStart
                                            ImportPTOStaging.Duration = IPTOS.Duration

                                            If IPTOS.Status = 1 Then

                                                ImportPTOStaging.Status = "A"

                                            ElseIf IPTOS.Status = 2 Then

                                                ImportPTOStaging.Status = "C"

                                            Else

                                                ImportPTOStaging.Status = Nothing

                                            End If

                                            If AdvantageFramework.Database.Procedures.ImportPTOStaging.Update(DataContext, ImportPTOStaging, True) = False Then

                                                Saved = False

                                            End If

                                        End If

                                    Next

                                Case ImportType.JournalEntry

                                    ImportJournalEntryList = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).Where(Function(IJE) IJE.Modified = True).ToList

                                    DbContext.Configuration.AutoDetectChangesEnabled = False

                                    For Each Header In (From I In ImportJournalEntryList
                                                        Select I.ImportJournalEntryHeader).Distinct

                                        ImportJournalEntry = DbContext.ImportJournalEntrys.Find(Header.ID)

                                        If ImportJournalEntry IsNot Nothing Then

                                            DbContext.Entry(ImportJournalEntry).CurrentValues.SetValues(Header.GetEntity)

                                        End If

                                    Next

                                    For Each IJE In ImportJournalEntryList

                                        ImportJournalEntryDetail = DbContext.ImportJournalEntryDetails.Find(IJE.DetailID)

                                        If ImportJournalEntryDetail IsNot Nothing Then

                                            DbContext.Entry(ImportJournalEntryDetail).CurrentValues.SetValues(IJE.ImportJournalEntryDetail.GetEntity)

                                        End If

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                                    DbContext.Configuration.AutoDetectChangesEnabled = True

                                    If Saved Then

                                        LoadSelectedBatch()

                                    End If

                                Case ImportType.Employee

                                    For Each ImportEmployeeHoursStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging)().ToList

                                        DbContext.Entry(ImportEmployeeHoursStaging).State = Entity.EntityState.Modified

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception
                                        Saved = False
                                    End Try

                            End Select

                        End Using

                    End Using

                Catch ex As Exception
                    Saved = False
                End Try

                Me.ShowWaitForm("Loading...")

                If ValidateRows Then

                    Try

                        ValidateAllRows(True)

                    Catch ex As Exception

                    End Try

                End If

                If Saved Then

                    Me.ClearChanged()

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

            Save = Saved

        End Function
        Private Sub ValidateAllRows(ByVal ClearChanged As Boolean)

            'objects
            Dim SetStandardValidation As Boolean = False

            SetStandardValidation = DataGridViewForm_ImportedItems.RunStandardValidation

            DataGridViewForm_ImportedItems.RunStandardValidation = False

            Try

                _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If _ImportType = Methods.ImportType.AccountsReceivable Then

                        AdvantageFramework.AccountReceivable.ValidateAllEntities(_DbContext, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)().ToList)

                    ElseIf _ImportType = Methods.ImportType.DigitalResults Then

                        For Each ImportDigitalResultsStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)()

                            ImportDigitalResultsStaging.ValidateUsingErrorObject()

                        Next

                    ElseIf _ImportType = Methods.ImportType.JournalEntry Then

                        AdvantageFramework.GeneralLedger.ValidateAllEntities(_DbContext, Session, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)().ToList)
                        DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                    Else

                        If ClearChanged Then

                            DataGridViewForm_ImportedItems.ValidateAllRowsAndClearChanged()

                        Else

                            DataGridViewForm_ImportedItems.ValidateAllRows()

                        End If

                    End If

                Catch ex As Exception

                End Try

                Try

                    If _DbContext IsNot Nothing Then

                        _DbContext.Dispose()

                        _DbContext = Nothing

                    End If

                Catch ex As Exception

                End Try

                Try

                    If _DataContext IsNot Nothing Then

                        _DataContext.Dispose()

                        _DataContext = Nothing

                    End If

                Catch ex As Exception

                End Try

            Catch ex As Exception

            Finally

                If SetStandardValidation = True Then

                    DataGridViewForm_ImportedItems.RunStandardValidation = True

                End If

            End Try

        End Sub
        Private Sub ApplyGrouping()

            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            Try

                Select Case _ImportType

                    Case Methods.ImportType.ExpenseReport

                        DataGridViewForm_ImportedItems.OptionsView.ShowGroupedColumns = True
                        DataGridViewForm_ImportedItems.Columns("EmployeeCode").GroupIndex = 0
                        DataGridViewForm_ImportedItems.Columns("ExpenseReportDate").GroupIndex = 1
                        DataGridViewForm_ImportedItems.CurrentView.ExpandAllGroups()

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        IsOkay = Save(True)

                    Catch ex As Exception
                        IsOkay = False
                    End Try

                    If IsOkay = False AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        IsOkay = True

                    End If

                    If IsOkay Then

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub AddSubItemGridLookupEdit(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                             ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal ValueType As System.Type, ByVal EnumType As System.Type)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ValueType = ValueType
                SubItemGridLookUpEditControl.EnumType = EnumType

                SubItemGridLookUpEditControl.Session = Session
                SubItemGridLookUpEditControl.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            End Try

            If SubItemGridLookUpEditControl IsNot Nothing Then

                SubItemGridLookUpEditControl.LoadDefaultDataSourceView()

                DataGridView.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                GridColumn.ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub
        Private Sub SetOnHold(ByVal Checked As Boolean)

            For Each Row In DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems

                Select Case _ImportType

                    Case Methods.ImportType.AccountsPayable

                        DirectCast(Row, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).IsOnHold = Checked
                        DirectCast(Row, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Modified = True

                    Case Methods.ImportType.Client

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportClientStaging).IsOnHold = Checked

                    Case Methods.ImportType.Division

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportDivisionStaging).IsOnHold = Checked

                    Case Methods.ImportType.Product

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportProductStaging).IsOnHold = Checked

                    Case Methods.ImportType.Function

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportFunctionStaging).IsOnHold = Checked

                    Case Methods.ImportType.ChartOfAccounts

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging).IsOnHold = Checked

                    Case Methods.ImportType.AccountsReceivable

                        DirectCast(Row, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging).IsOnHold = Checked
                        DirectCast(Row, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging).Modified = True

                    Case Methods.ImportType.AvalaraTaxCode

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging).IsOnHold = Checked

                    Case Methods.ImportType.CashReceipt

                        DirectCast(Row, AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt).IsOnHold = If(Checked, 1, 0)

                    Case Methods.ImportType.ClientContact

                        DirectCast(Row, AdvantageFramework.Database.Entities.ImportClientContactStaging).IsOnHold = Checked

                    Case Methods.ImportType.PTO

                        DirectCast(Row, AdvantageFramework.Importing.Classes.ImportPTOItem).IsOnHold = Checked

                    Case Methods.ImportType.JournalEntry

                        DirectCast(Row, AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).IsOnHold = Checked
                        DirectCast(Row, AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).Modified = True

                End Select

            Next

            DataGridViewForm_ImportedItems.SetUserEntryChanged()

            DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        End Sub
        Private Sub SetExistingOrderDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Nullable(Of Integer), ByVal LineNumber As Nullable(Of Short),
                                            ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim Magazine As AdvantageFramework.Database.Views.Magazine = Nothing
            Dim MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail = Nothing
            Dim NewspaperHeader As AdvantageFramework.Database.Views.NewspaperHeader = Nothing
            Dim NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As Database.Entities.RadioOrder = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim TVOrder As Database.Entities.TVOrder = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing

            Select Case ImportOrder.MediaType

                Case "I"

                    InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If InternetOrder IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = InternetOrder.Description
                        ImportOrder.StartDate = InternetOrder.InternetOrderDetails.ToList.Where(Function(D) D.LineNumber = LineNumber And D.IsActiveRevision.GetValueOrDefault(0) = 1).FirstOrDefault.StartDate
                        ImportOrder.EndDate = InternetOrder.InternetOrderDetails.ToList.Where(Function(D) D.LineNumber = LineNumber And D.IsActiveRevision.GetValueOrDefault(0) = 1).FirstOrDefault.EndDate
                        ImportOrder.CampaignCode = InternetOrder.CampaignCode
                        ImportOrder.ClientPO = InternetOrder.ClientPO

                    End If

                Case "M"

                    Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, OrderNumber)

                    If Magazine IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = Magazine.Description
                        ImportOrder.CampaignCode = Magazine.CampaignCode
                        ImportOrder.ClientPO = Magazine.ClientPO

                        MagazineDetail = AdvantageFramework.Database.Procedures.MagazineDetailView.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, LineNumber)

                        If MagazineDetail IsNot Nothing Then

                            ImportOrder.StartDate = MagazineDetail.InsertDate
                            ImportOrder.EndDate = MagazineDetail.CloseDate

                        End If

                    End If

                Case "N"

                    NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, OrderNumber)

                    If NewspaperHeader IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = NewspaperHeader.Description
                        ImportOrder.CampaignCode = NewspaperHeader.CampaignCode
                        ImportOrder.ClientPO = NewspaperHeader.ClientPO

                        NewspaperDetail = AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, LineNumber)

                        If NewspaperDetail IsNot Nothing Then

                            ImportOrder.StartDate = NewspaperDetail.InsertDate
                            ImportOrder.EndDate = NewspaperDetail.CloseDate

                        End If

                    End If

                Case "O"

                    OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If OutOfHomeOrder IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = OutOfHomeOrder.Description
                        ImportOrder.StartDate = OutOfHomeOrder.OutOfHomeOrderDetails.ToList.Where(Function(D) D.LineNumber = LineNumber And D.IsActiveRevision.GetValueOrDefault(0) = 1).FirstOrDefault.PostDate
                        ImportOrder.EndDate = OutOfHomeOrder.OutOfHomeOrderDetails.ToList.Where(Function(D) D.LineNumber = LineNumber And D.IsActiveRevision.GetValueOrDefault(0) = 1).FirstOrDefault.EndDate
                        ImportOrder.CampaignCode = OutOfHomeOrder.CampaignCode
                        ImportOrder.ClientPO = OutOfHomeOrder.ClientPO

                    End If

                Case "R"

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If RadioOrder IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = RadioOrder.Description
                        ImportOrder.CampaignCode = RadioOrder.CampaignCode
                        ImportOrder.ClientPO = RadioOrder.ClientPO
                        ImportOrder.CalendarType = RadioOrder.Units

                        RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, LineNumber)

                        If RadioOrderDetail IsNot Nothing Then

                            ImportOrder.StartDate = RadioOrderDetail.StartDate
                            ImportOrder.EndDate = RadioOrderDetail.EndDate

                        End If

                    End If

                Case "T"

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing Then

                        ImportOrder.MediaPlanOrderDescription = TVOrder.Description
                        ImportOrder.CampaignCode = TVOrder.CampaignCode
                        ImportOrder.ClientPO = TVOrder.ClientPO
                        ImportOrder.CalendarType = TVOrder.Units

                        TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, OrderNumber, LineNumber)

                        If TVOrderDetail IsNot Nothing Then

                            ImportOrder.StartDate = TVOrderDetail.StartDate
                            ImportOrder.EndDate = TVOrderDetail.EndDate

                        End If

                    End If

            End Select

        End Sub
        Private Sub SaveLastSelectedAPImportType()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastAPImportType.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso ComboBoxSettings_ImportType.HasASelectedValue Then

                    UserSetting.StringValue = ComboBoxSettings_ImportType.GetSelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing AndAlso ComboBoxSettings_ImportType.HasASelectedValue Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastAPImportType.ToString, ComboBoxSettings_ImportType.GetSelectedValue, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SetLastSelectedAPImportType()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastAPImportType.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    ComboBoxSettings_ImportType.SelectedValue = UserSetting.StringValue

                End If

            End Using

        End Sub
        Private Sub ChooseColumns()

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    Try

                        If ButtonItemGridOptions_ChooseColumns.Checked Then

                            If DataGridViewForm_ImportedItems.CurrentView.CustomizationForm Is Nothing Then

                                DataGridViewForm_ImportedItems.CurrentView.ShowCustomization()

                            End If

                        Else

                            If DataGridViewForm_ImportedItems.CurrentView.CustomizationForm IsNot Nothing Then

                                DataGridViewForm_ImportedItems.CurrentView.DestroyCustomization()

                            End If

                        End If

                    Catch ex As Exception

                    End Try

            End Select

        End Sub
        Private Sub RestoreDefaults()

            'objects
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

                    If ImportAccountPayable IsNot Nothing Then

                        Me.ShowWaitForm("Loading...")

                        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.AccountsPayableImport, Session.UserCode, ImportAccountPayable.GetImportAccountPayableHeader.ImportTemplateID)

                        End Using

                        LoadSelectedBatch()

                        Me.CloseWaitForm()

                    End If

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_DataSourceChangedEvent_ClearedChecks_MediaVCC()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_ImportedItems.CurrentView.OptionsView.ShowFooter = True

                For Each GridColumn In DataGridViewForm_ImportedItems.Columns

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC.Properties.BankAmount.ToString Then

                        If GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                            GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                            GridColumn.SummaryItem.DisplayFormat = "{0:n2}"

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub ClearModifiedFlag()

            Select Case _ImportType

                Case ImportType.AccountsReceivable

                    For Each ImportAccountReceivableStaging In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)().Where(Function(IARS) IARS.Modified = True).ToList

                        ImportAccountReceivableStaging.Modified = False

                    Next

                Case ImportType.AccountsPayable

                    For Each ImportAccountPayable In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().Where(Function(IARS) IARS.Modified = True).ToList

                        ImportAccountPayable.Modified = False

                    Next

            End Select
        End Sub
        Private Function DeleteBatch(DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim BatchDeleted As Boolean = False

            If DataGridViewForm_ImportedItems.CurrentView.SelectedRowsCount = DataGridViewForm_ImportedItems.CurrentView.RowCount Then

                Select Case _ImportType

                    Case ImportType.JournalEntry

                        Try

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand("DELETE dbo.IMP_JE_DETAIL WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_JE_HEADER WHERE BATCH_NAME = @BatchName)", New SqlClient.SqlParameter("@BatchName", ComboBoxSettings_Batch.GetSelectedValue))

                            DbContext.Database.ExecuteSqlCommand("DELETE dbo.IMP_JE_HEADER WHERE BATCH_NAME = @BatchName", New SqlClient.SqlParameter("@BatchName", ComboBoxSettings_Batch.GetSelectedValue))

                            DbTransaction.Commit()

                            DataGridViewForm_ImportedItems.ClearDatasource(New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry))

                            BatchDeleted = True

                        Catch ex As Exception
                            DbTransaction.Rollback()
                        End Try

                End Select

            End If

            DeleteBatch = BatchDeleted

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowForm(ByVal ImportType As AdvantageFramework.Importing.ImportType) As AdvantageFramework.Importing.Presentation.ImportForm

            'objects
            Dim ImportForm As AdvantageFramework.Importing.Presentation.ImportForm = Nothing

            ImportForm = New AdvantageFramework.Importing.Presentation.ImportForm(ImportType)

            ImportForm.Show()

            ImportType = ImportForm.ImportType

            ShowForm = ImportForm

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            Dim SqlParameterBatchName As SqlClient.SqlParameter = Nothing

            If _ImportType = Methods.ImportType.AccountsPayable AndAlso _DeleteBatchOnExit Then

                If ComboBoxSettings_Batch.HasASelectedValue Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                        SqlParameterBatchName.Value = ComboBoxSettings_Batch.GetSelectedValue()

                        DbContext.Database.ExecuteSqlCommand("exec advsp_ap_import_delete_batch @batch_name", SqlParameterBatchName)

                    End Using

                End If

            End If

            AccountsPayableSaveDataGridViewLayout()

        End Sub
        Private Sub ImportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            If _ImportType = Methods.ImportType.ClearedChecks Then

                _AllowSave = False

            End If

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemActions_Validate.Image = AdvantageFramework.My.Resources.ValidateImage
            ButtonItemActions_Mapping.Image = AdvantageFramework.My.Resources.MappingAddImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemTemplates_Edit.Image = AdvantageFramework.My.Resources.TemplateImage

            ButtonItemClearedChecks_All.Image = AdvantageFramework.My.Resources.CheckWritingImage
            ButtonItemClearedChecks_Valid.Image = AdvantageFramework.My.Resources.ReviewAllImage
            ButtonItemClearedChecks_Invalid.Image = AdvantageFramework.My.Resources.DeselectAllImage

            ButtonItemImport_NewBatch.Image = AdvantageFramework.My.Resources.DatabaseStagingImage

            ButtonItemAccountPayable_ShowAll.Image = AdvantageFramework.My.Resources.ShowAllColumnsImage
            ButtonItemAccountPayable_UpdateDescription.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemAccountPayable_WriteOff.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemAccountPayable_ClearOrderLine.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemAccountPayable_Update.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemMediaOrder_Match.Image = AdvantageFramework.My.Resources.MediaFindImage
            ButtonItemMediaOrder_Create.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemMediaOrder_AddToWorksheet.Image = AdvantageFramework.My.Resources.DetailAddImage

            ButtonItemCSIPreferredPartner_Import.Image = AdvantageFramework.My.Resources.CSIPreferredPartnerImportImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ComboBoxSettings_ImportType.DisplayMember = "Description"
            ComboBoxSettings_ImportType.ValueMember = "Code"

            ComboBoxSettings_Batch.DisplayMember = "Value"
            ComboBoxSettings_Batch.ValueMember = "Key"

            ButtonItemCSIPreferredPartner_Import.SecurityEnabled = AdvantageFramework.CSIPreferredPartner.HasAgreementBeenSigned(Me.Session)

            Try

                LoadImportDefaults()

            Catch ex As Exception

            End Try

            Try

                LoadAvailableBatches()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ImportForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
            Me.ShowWaitForm()

            If ComboBoxSettings_Batch.Items.Count = 2 Then

                ComboBoxSettings_Batch.SelectedIndex = 1

            End If

            Try

                LoadSelectedBatch()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ImportForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _AllowSave Then

                ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            End If

        End Sub
        Private Sub ImportForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _AllowSave Then

                ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemTemplates_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemTemplates_Edit.Click

            'objects
            Dim SelectedValue As AdvantageFramework.Importing.ImportTemplateTypes = Nothing

            Try

                SelectedValue = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue)

            Catch ex As Exception
                SelectedValue = Nothing
            End Try

            If SelectedValue <> Nothing Then

                Select Case SelectedValue

                    Case ImportTemplateTypes.ExpenseReport_CreditCard

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportCreditCardTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.ExpenseReport_NonCreditCard

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportNonCreditCardTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.ClearedChecks_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportClearedChecksTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_Generic

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayableGenericTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_StrataFixedInternet

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayableStrataFixedInternet, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.Client_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportClientTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.ClientContact_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportClientContactTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.Division_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportDivisionTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.Product_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportProductTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayableStrataFixedBroadcast, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_StrataFixedPrint

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayableStrataFixedPrint, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsReceivable_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsReceivableTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.Function_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportFunctionTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.ChartOfAccounts_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportChartOfAccountTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.DigitalResults_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportDigitalResultsTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AvalaraTaxCode_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.AvalaraTaxTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.CashReceipt_Generic

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.CashReceiptTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.CashReceipt_Custom

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.CashReceiptCustomTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsReceivable_Custom

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsReceivableCustomTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_Custom

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayableCustomTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.PTO_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportPTOTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.JournalEntry_Default

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportJournalEntryTemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.JournalEntry_MOGLIFACE

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportJournalEntryMOGLIFACETemplate, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.AccountsPayable_4AsBroadcast

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportAccountsPayable4AsBroadcast, False, False, AllowMultiSelect:=False)

                    Case ImportTemplateTypes.Employee_Hours

                        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.EmployeeHours, False, False, AllowMultiSelect:=False)

                End Select

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Import.Click

            'objects
            Dim Imported As Boolean = False
            Dim DisplayMessage As String = ""
            Dim PassedMessage As String = ""
            Dim FailedMessage As String = ""
            Dim ImportedClearedChecks As Generic.List(Of AdvantageFramework.Database.Classes.ImportedClearedCheck) = Nothing
            Dim ImportAccountPayables As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim PostPeriodCode As String = Nothing
            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim ImportClientStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportClientStaging) = Nothing
            Dim ImportDivisionStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportDivisionStaging) = Nothing
            Dim ImportProductStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportProductStaging) = Nothing
            Dim Canceled As Boolean = False
            Dim ImportFunctionStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportFunctionStaging) = Nothing
            Dim ImportGeneralLedgerAccountStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging) = Nothing
            Dim ImportAccountReceivableStagings As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging) = Nothing
            Dim ImportDigitalResultsStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) = Nothing
            Dim IsOkay As Boolean = True
            Dim HasRowsOnHold As Boolean = False
            Dim ImportAvalaraTaxStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging) = Nothing
            Dim ImportClientCashReceipts As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) = Nothing
            Dim ImportClientCashReceiptPostPeriodBank As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ImportTemplateTypeName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim ImportClearedCheckMediaVCCs As Generic.List(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC) = Nothing
            Dim ImportClientContactStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportClientContactStaging) = Nothing
            Dim ImportPTOItems As Generic.List(Of AdvantageFramework.Importing.Classes.ImportPTOItem) = Nothing
            Dim ImportJournalEntrys As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing
            Dim ImportEmployeeHoursStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging) = Nothing

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ExpenseReport, AdvantageFramework.Importing.ImportType.ClearedChecks

                    DataGridViewForm_ImportedItems.ValidateAllRows()

                    If DataGridViewForm_ImportedItems.HasAnyInvalidRows Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.", WinForm.MessageBox.MessageBoxButtons.OK)
                        IsOkay = False

                    Else

                        IsOkay = Save(False)

                    End If

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    AccountsPayableSaveAndValidate()

                    If HasAnyInvalidRowsNotOnHold() Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.", WinForm.MessageBox.MessageBoxButtons.OK)
                        IsOkay = False

                    End If

                Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.AccountReceivable.ValidateAllEntities(DbContext, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)().ToList)

                    End Using

                    IsOkay = Save(False)

                Case AdvantageFramework.Importing.ImportType.DigitalResults

                    DigitalResultsSaveAndValidate()
                    IsOkay = True

                Case AdvantageFramework.Importing.ImportType.CashReceipt, AdvantageFramework.Importing.ImportType.PTO

                    If HasAnyInvalidRowsNotOnHold() Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.", WinForm.MessageBox.MessageBoxButtons.OK)
                        IsOkay = False

                    End If

                Case AdvantageFramework.Importing.ImportType.JournalEntry

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.GeneralLedger.ValidateAllEntities(DbContext, Session, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)().ToList)
                        DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                        If HasAnyInvalidRowsNotOnHold() Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.", WinForm.MessageBox.MessageBoxButtons.OK)
                            IsOkay = False

                        Else

                            IsOkay = Save(False)

                        End If

                    End Using

                Case Else

                    ValidateAllRows(False)

                    IsOkay = Save(False)

            End Select

            If IsOkay Then

                Select Case _ImportType

                    Case AdvantageFramework.Importing.ImportType.ExpenseReport

                        DisplayMessage = "Expense reports will be created for each individual employee and each unique date. Are you sure you want to continue?"
                        PassedMessage = "All items were successfully imported."
                        FailedMessage = "One or more items failed to import."

                    Case AdvantageFramework.Importing.ImportType.ClearedChecks, Methods.ImportType.DigitalResults

                        DisplayMessage = "Are you sure you want to continue?"
                        PassedMessage = "All items were successfully imported."
                        FailedMessage = "One or more items failed to import."

                    Case AdvantageFramework.Importing.ImportType.AccountsPayable, AdvantageFramework.Importing.ImportType.Client,
                            AdvantageFramework.Importing.ImportType.Division, AdvantageFramework.Importing.ImportType.Product, AdvantageFramework.Importing.ImportType.Function,
                            AdvantageFramework.Importing.ImportType.ChartOfAccounts, AdvantageFramework.Importing.ImportType.AccountsReceivable,
                            AdvantageFramework.Importing.ImportType.AvalaraTaxCode, AdvantageFramework.Importing.ImportType.CashReceipt,
                            AdvantageFramework.Importing.ImportType.ClientContact, AdvantageFramework.Importing.ImportType.PTO, AdvantageFramework.Importing.ImportType.JournalEntry,
                            AdvantageFramework.Importing.ImportType.Employee

                        DisplayMessage = "Are you sure you want to continue?"
                        PassedMessage = "All items not on hold were successfully imported."
                        FailedMessage = "One or more items failed to import."

                End Select

                If AdvantageFramework.WinForm.MessageBox.Show(DisplayMessage, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.FormAction = WinForm.Presentation.FormActions.Adding

                        If _ImportType <> Methods.ImportType.AccountsPayable AndAlso _ImportType <> Methods.ImportType.AccountsReceivable AndAlso _ImportType <> Methods.ImportType.JournalEntry Then

                            Me.ShowWaitForm()
                            Me.ShowWaitForm("Importing...")

                        End If

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Select Case _ImportType

                                    Case AdvantageFramework.Importing.ImportType.ExpenseReport

                                        Imported = AdvantageFramework.ExpenseReports.CreateExpenseReportsFromImport(DbContext, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging).ToList)

                                    Case AdvantageFramework.Importing.ImportType.ClearedChecks

                                        ImportTemplateTypeName = ComboBoxSettings_ImportType.GetSelectedValue

                                        ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ImportTemplateTypeName)

                                        If ImportTemplateType = ImportTemplateTypes.ClearedChecks_Default Then

                                            ImportedClearedChecks = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportedClearedCheck).Where(Function(Entity) Entity.IsValid = True).ToList

                                            If ImportedClearedChecks IsNot Nothing AndAlso ImportedClearedChecks.Any Then

                                                Imported = AdvantageFramework.Importing.ImportClearedChecks(DbContext, DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportedClearedCheck).Where(Function(Entity) Entity.IsValid = True).ToList)

                                            Else

                                                FailedMessage = "There are no valid checks to import."

                                            End If

                                        ElseIf ImportTemplateType = ImportTemplateTypes.ClearedChecks_MediaVCC Then

                                            ImportClearedCheckMediaVCCs = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC).Where(Function(Entity) Entity.IsValid = True).ToList

                                            If ImportClearedCheckMediaVCCs IsNot Nothing AndAlso ImportClearedCheckMediaVCCs.Any Then

                                                Imported = AdvantageFramework.Importing.ImportClearedChecks(DbContext, ImportClearedCheckMediaVCCs, DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC).ToList)

                                            Else

                                                FailedMessage = "There are no valid checks to import."

                                            End If

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.AccountsPayable

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportAccountPayables = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Where(Function(Entity) Entity.IsOnHold = False).ToList

                                        If ImportAccountPayables IsNot Nothing AndAlso ImportAccountPayables.Any Then

                                            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.PostPeriodActiveAP, True, True, SelectedPostPeriods) = System.Windows.Forms.DialogResult.OK Then

                                                If SelectedPostPeriods IsNot Nothing Then

                                                    Try

                                                        PostPeriodCode = (From Entity In SelectedPostPeriods
                                                                          Select Entity.Code).FirstOrDefault

                                                    Catch ex As Exception
                                                        PostPeriodCode = Nothing
                                                    End Try

                                                End If

                                                If Not String.IsNullOrEmpty(PostPeriodCode) Then

                                                    Me.ShowWaitForm()
                                                    Me.ShowWaitForm("Importing...")

                                                    Imported = AdvantageFramework.AccountPayable.CreateInvoicesFromImport(DbContext, DataContext, ImportAccountPayables, PostPeriodCode, Session)

                                                End If

                                            Else

                                                Canceled = True

                                            End If

                                        Else

                                            FailedMessage = "Nothing to import.  All invoices are marked 'On Hold'."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.Client

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportClientStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientStaging).ToList

                                        If ImportClientStagings IsNot Nothing AndAlso ImportClientStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateClientsFromImport(DbContext, ImportClientStagings, False)

                                        Else

                                            FailedMessage = "There are no valid clients to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.Division

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDivisionStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportDivisionStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDivisionStaging).ToList

                                        If ImportDivisionStagings IsNot Nothing AndAlso ImportDivisionStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateDivisionsFromImport(DbContext, ImportDivisionStagings, False)

                                        Else

                                            FailedMessage = "There are no valid divisions to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.Product

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportProductStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportProductStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportProductStaging).ToList

                                        If ImportProductStagings IsNot Nothing AndAlso ImportProductStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateProductsFromImport(DbContext, ImportProductStagings, False)

                                        Else

                                            FailedMessage = "There are no valid products to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.Function

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportFunctionStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportFunctionStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportFunctionStaging).ToList

                                        If ImportFunctionStagings IsNot Nothing AndAlso ImportFunctionStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateFunctionsFromImport(DbContext, ImportFunctionStagings, False)

                                        Else

                                            FailedMessage = "There are no valid functions to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.ChartOfAccounts

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportGeneralLedgerAccountStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging).ToList

                                        If ImportGeneralLedgerAccountStagings IsNot Nothing AndAlso ImportGeneralLedgerAccountStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateChartsOfAccountFromImport(DbContext, ImportGeneralLedgerAccountStagings, False)

                                        Else

                                            FailedMessage = "There are no valid chart of accounts to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportAccountReceivableStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging).ToList

                                        If ImportAccountReceivableStagings IsNot Nothing AndAlso ImportAccountReceivableStagings.Any Then

                                            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.PostPeriodActiveAR, True, True, SelectedPostPeriods) = System.Windows.Forms.DialogResult.OK Then

                                                If SelectedPostPeriods IsNot Nothing Then

                                                    Try

                                                        PostPeriodCode = (From Entity In SelectedPostPeriods
                                                                          Select Entity.Code).FirstOrDefault

                                                    Catch ex As Exception
                                                        PostPeriodCode = Nothing
                                                    End Try

                                                End If

                                                If Not String.IsNullOrEmpty(PostPeriodCode) Then

                                                    Me.ShowWaitForm()
                                                    Me.ShowWaitForm("Importing...")

                                                    Imported = AdvantageFramework.AccountReceivable.CreateAccountsReceivableFromImport(DbContext, ImportAccountReceivableStagings, PostPeriodCode, Now())

                                                End If

                                            Else

                                                Canceled = True

                                            End If

                                        Else

                                            FailedMessage = "There are no valid accounts receivable to import."

                                        End If

                                    Case AdvantageFramework.Importing.Methods.ImportType.DigitalResults

                                        ImportDigitalResultsStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging).ToList

                                        If ImportDigitalResultsStagings IsNot Nothing AndAlso ImportDigitalResultsStagings.Count > 0 Then

                                            DbContext.Database.Connection.Open()

                                            Me.ShowWaitForm()
                                            Me.ShowWaitForm("Importing...")

                                            Imported = AdvantageFramework.Importing.CreateDigitalResultsFromImport(DbContext, ImportDigitalResultsStagings, False)

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.AvalaraTaxCode

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportAvalaraTaxStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging).ToList

                                        If ImportAvalaraTaxStagings IsNot Nothing AndAlso ImportAvalaraTaxStagings.Any Then

                                            Imported = AdvantageFramework.Importing.CreateAvalaraTaxFromImport(DataContext, ImportAvalaraTaxStagings)

                                        Else

                                            FailedMessage = "There are no valid avalara taxes to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.CashReceipt

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)().Where(Function(Entity) Entity.IsOnHold = 1).Any

                                        ImportClientCashReceipts = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt).Where(Function(Entity) Entity.IsOnHold = 0).ToList

                                        If ImportClientCashReceipts IsNot Nothing AndAlso ImportClientCashReceipts.Any Then

                                            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

                                            If PostPeriod IsNot Nothing Then

                                                ImportClientCashReceiptPostPeriodBank = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank(PostPeriod.Code)

                                            Else

                                                ImportClientCashReceiptPostPeriodBank = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank()

                                            End If

                                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                                            If AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Select Bank and Post Period", ImportClientCashReceiptPostPeriodBank, False) = Windows.Forms.DialogResult.OK Then

                                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                                Imported = AdvantageFramework.CashReceipts.CreateCashReceiptsFromImport(DbContext, ImportClientCashReceiptPostPeriodBank, ImportClientCashReceipts)

                                            Else

                                                Canceled = True

                                            End If

                                        Else

                                            FailedMessage = "There are no valid cash receipts to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.ClientContact

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientContactStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportClientContactStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportClientContactStaging).ToList

                                        If ImportClientContactStagings IsNot Nothing AndAlso ImportClientContactStagings.Any Then

                                            DbContext.Database.Connection.Open()

                                            Imported = AdvantageFramework.Importing.CreateClientContactsFromImport(DbContext, ImportClientContactStagings, False)

                                        Else

                                            FailedMessage = "There are no valid client contacts to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.PTO

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Importing.Classes.ImportPTOItem)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportPTOItems = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Importing.Classes.ImportPTOItem).ToList

                                        If ImportPTOItems IsNot Nothing AndAlso ImportPTOItems.Any Then

                                            Imported = AdvantageFramework.Importing.CreatePTORecordsFromImport(DataContext, DbContext, ImportPTOItems)

                                        Else

                                            FailedMessage = "There are no valid PTO records to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.JournalEntry

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportJournalEntrys = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).ToList

                                        If ImportJournalEntrys IsNot Nothing AndAlso ImportJournalEntrys.Any Then

                                            Me.ShowWaitForm()
                                            Me.ShowWaitForm("Importing...")

                                            Imported = AdvantageFramework.Importing.CreateJERecordsFromImport(DbContext, ImportJournalEntrys, False)

                                        Else

                                            FailedMessage = "There are no valid journal entry records to import."

                                        End If

                                    Case AdvantageFramework.Importing.ImportType.Employee

                                        HasRowsOnHold = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging)().Where(Function(Entity) Entity.IsOnHold = True).Any

                                        ImportEmployeeHoursStagings = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging).ToList

                                        If ImportEmployeeHoursStagings IsNot Nothing AndAlso ImportEmployeeHoursStagings.Any Then

                                            Imported = AdvantageFramework.Importing.UpdateEmployeeRecordsFromImport(DataContext, DbContext, ImportEmployeeHoursStagings)

                                        Else

                                            FailedMessage = "There are no valid employee hours to import."

                                        End If

                                End Select

                                If DbContext.Database.Connection.State = ConnectionState.Open Then

                                    DbContext.Database.Connection.Close()

                                End If

                            End Using

                        End Using

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        If Not Canceled Then

                            If Imported Then

                                AdvantageFramework.WinForm.MessageBox.Show(PassedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show(FailedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

                            End If

                            DataGridViewForm_ImportedItems.ClearDatasource()

                            Me.CloseWaitForm()
                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm()
                            Me.ShowWaitForm("Loading...")

                            If Imported AndAlso Not HasRowsOnHold Then

                                Try

                                    LoadAvailableBatches()

                                Catch ex As Exception

                                End Try

                            End If

                            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                            Try

                                LoadSelectedBatch()

                            Catch ex As Exception

                            End Try

                        End If

                        EnableOrDisableActions()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ComboBoxSettings_ImportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxSettings_ImportType.SelectionChangeCommitted

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAvailableBatches()

                EnableOrDisableActions()

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ComboBoxSettings_Batch_DropDown(sender As Object, e As EventArgs) Handles ComboBoxSettings_Batch.DropDown

            AccountsPayableSaveDataGridViewLayout()

        End Sub
        Private Sub ComboBoxSettings_Batch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSettings_Batch.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    EnableOrDisableActions()

                    Me.ClearChanged()

                Else

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                    Me.ShowWaitForm()

                    Try

                        ComboBoxSettings_Batch.SelectedValue = _LastLoadedBatchName

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Deleted As Boolean = False
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim ImportedClearedCheck As AdvantageFramework.Database.Classes.ImportedClearedCheck = Nothing
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim ImportAccountPayableEntity As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportID As Integer = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim ImportClientStaging As AdvantageFramework.Database.Entities.ImportClientStaging = Nothing
            Dim ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging = Nothing
            Dim ImportProductStaging As AdvantageFramework.Database.Entities.ImportProductStaging = Nothing
            Dim ImportFunctionStaging As AdvantageFramework.Database.Entities.ImportFunctionStaging = Nothing
            Dim ImportGeneralLedgerAccountStaging As AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging = Nothing
            Dim AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging = Nothing
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging = Nothing
            Dim ImportClientCashReceipt As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt = Nothing
            Dim ImportClearedCheckMediaVCC As AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC = Nothing
            Dim ImportClearedCheckMediaVCCStaging As AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging = Nothing
            Dim ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging = Nothing
            Dim ImportPTOItem As AdvantageFramework.Importing.Classes.ImportPTOItem = Nothing
            Dim ImportJournalEntry As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry = Nothing
            Dim BindingSource As Windows.Forms.BindingSource = Nothing
            Dim ImportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ImportDocument) = Nothing
            Dim DocumentIDs As Long() = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim ImportEmployeeHourStaging As AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging = Nothing

            If DataGridViewForm_ImportedItems.HasASelectedRow Then

                DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Deleting
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ImportedItems.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If Not DeleteBatch(DbContext) Then

                                    For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                        Select Case _ImportType

                                            Case AdvantageFramework.Importing.ImportType.ExpenseReport

                                                Try

                                                    ImportCreditCardStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportCreditCardStaging = Nothing
                                                End Try

                                                If ImportCreditCardStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Delete(DbContext, ImportCreditCardStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.ClearedChecks

                                                If DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem.GetType Is GetType(AdvantageFramework.Database.Classes.ImportedClearedCheck) Then

                                                    Try

                                                        ImportedClearedCheck = RowHandleAndDataBoundItem.Value

                                                    Catch ex As Exception
                                                        ImportedClearedCheck = Nothing
                                                    End Try

                                                    If ImportedClearedCheck IsNot Nothing Then

                                                        ImportClearedChecksStaging = AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.LoadByImportClearedChecksStagingID(DbContext, ImportedClearedCheck.ID)

                                                        Deleted = AdvantageFramework.Database.Procedures.ImportClearedChecksStaging.Delete(DbContext, ImportClearedChecksStaging)

                                                    End If

                                                ElseIf DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem.GetType Is GetType(AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC) Then

                                                    Try

                                                        ImportClearedCheckMediaVCC = RowHandleAndDataBoundItem.Value

                                                    Catch ex As Exception
                                                        ImportClearedCheckMediaVCC = Nothing
                                                    End Try

                                                    If ImportClearedCheckMediaVCC IsNot Nothing Then

                                                        ImportClearedCheckMediaVCCStaging = AdvantageFramework.Database.Procedures.ImportClearedCheckMediaVCCStaging.LoadByImportClearedCheckMediaVCCStagingID(DbContext, ImportClearedCheckMediaVCC.ID)

                                                        Deleted = AdvantageFramework.Database.Procedures.ImportClearedCheckMediaVCCStaging.Delete(DbContext, ImportClearedCheckMediaVCCStaging, Nothing)

                                                    End If

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.AccountsPayable

                                                Try

                                                    ImportAccountPayable = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportAccountPayable = Nothing
                                                End Try

                                                If ImportAccountPayable IsNot Nothing Then

                                                    If ImportAccountPayable.ImportAccountPayableGLID <> 0 Then

                                                        ImportAccountPayableGL = (From Entity In ImportAccountPayable.GetHeader.ImportAccountPayableGLs
                                                                                  Where Entity.ImportAccountPayableID = ImportAccountPayable.ID AndAlso
                                                                                    Entity.ID = ImportAccountPayable.ImportAccountPayableGLID
                                                                                  Select Entity).SingleOrDefault

                                                        ImportAccountPayable.GetHeader.ImportAccountPayableGLs.Remove(ImportAccountPayableGL)

                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_ERROR WHERE IMPORT_ID = {0} AND IMPORT_GL_ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableGLID))
                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_GL WHERE IMPORT_ID = {0} AND ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableGLID))

                                                    ElseIf ImportAccountPayable.ImportAccountPayableJobID <> 0 Then

                                                        ImportAccountPayableJob = (From Entity In ImportAccountPayable.GetHeader.ImportAccountPayableJobs
                                                                                   Where Entity.ImportAccountPayableID = ImportAccountPayable.ID AndAlso
                                                                                     Entity.ID = ImportAccountPayable.ImportAccountPayableJobID
                                                                                   Select Entity).SingleOrDefault

                                                        ImportAccountPayable.GetHeader.ImportAccountPayableJobs.Remove(ImportAccountPayableJob)

                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_ERROR WHERE IMPORT_ID = {0} AND IMPORT_JOB_ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableJobID))
                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_JOB WHERE IMPORT_ID = {0} AND ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableJobID))

                                                    ElseIf ImportAccountPayable.ImportAccountPayableMediaID <> 0 Then

                                                        ImportAccountPayableMedia = (From Entity In ImportAccountPayable.GetHeader.ImportAccountPayableMedias
                                                                                     Where Entity.ImportAccountPayableID = ImportAccountPayable.ID AndAlso
                                                                                       Entity.ID = ImportAccountPayable.ImportAccountPayableMediaID
                                                                                     Select Entity).SingleOrDefault

                                                        ImportAccountPayable.GetHeader.ImportAccountPayableMedias.Remove(ImportAccountPayableMedia)

                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_ERROR WHERE IMPORT_ID = {0} AND IMPORT_MEDIA_ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableMediaID))
                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_BROADCAST_DTL WHERE IMP_AP_MEDIA_ID={0}", ImportAccountPayable.ImportAccountPayableMediaID))
                                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_MEDIA WHERE IMPORT_ID = {0} AND ID={1}", ImportAccountPayable.ID, ImportAccountPayable.ImportAccountPayableMediaID))

                                                    End If

                                                    ImportAccountPayableEntity = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByID(DbContext, ImportAccountPayable.ID)

                                                    If ImportAccountPayableEntity IsNot Nothing Then

                                                        If ImportAccountPayableEntity.ImportAccountPayableGLs.Any = False AndAlso ImportAccountPayableEntity.ImportAccountPayableJobs.Any = False AndAlso ImportAccountPayableEntity.ImportAccountPayableMedias.Any = False Then

                                                            ImportDocuments = AdvantageFramework.Database.Procedures.ImportDocument.LoadByImportIDAndTemplateID(DataContext, ImportAccountPayableEntity.ID, ImportAccountPayableEntity.ImportTemplateID).ToList

                                                            If ImportDocuments IsNot Nothing AndAlso ImportDocuments.Count > 0 Then

                                                                DocumentIDs = ImportDocuments.Select(Function(iDoc) iDoc.DocumentID).ToArray

                                                                Documents = AdvantageFramework.Database.Procedures.Document.Load(DbContext).Where(Function(d) DocumentIDs.Contains(CLng(d.ID))).ToList

                                                            End If

                                                            Deleted = AdvantageFramework.Database.Procedures.ImportAccountPayable.Delete(DbContext, ImportAccountPayableEntity)

                                                            If Deleted Then

                                                                If Documents IsNot Nothing AndAlso Documents.Count > 0 Then

                                                                    AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Documents)

                                                                End If

                                                            End If

                                                        Else

                                                            Deleted = True

                                                        End If

                                                    Else

                                                        Deleted = True

                                                    End If

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.Client

                                                Try

                                                    ImportClientStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportClientStaging = Nothing
                                                End Try

                                                If ImportClientStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportClientStaging.Delete(DbContext, ImportClientStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.Division

                                                Try

                                                    ImportDivisionStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportDivisionStaging = Nothing
                                                End Try

                                                If ImportDivisionStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportDivisionStaging.Delete(DbContext, ImportDivisionStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.Product

                                                Try

                                                    ImportProductStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportProductStaging = Nothing
                                                End Try

                                                If ImportProductStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportProductStaging.Delete(DbContext, ImportProductStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.Function

                                                Try

                                                    ImportFunctionStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportFunctionStaging = Nothing
                                                End Try

                                                If ImportFunctionStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportFunctionStaging.Delete(DbContext, ImportFunctionStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.ChartOfAccounts

                                                Try

                                                    ImportGeneralLedgerAccountStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportGeneralLedgerAccountStaging = Nothing
                                                End Try

                                                If ImportGeneralLedgerAccountStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportGeneralLedgerAccountStaging.Delete(DbContext, ImportGeneralLedgerAccountStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                                                Try

                                                    AccountReceivableImportStaging = DirectCast(RowHandleAndDataBoundItem.Value, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging).AccountReceivableImportStaging

                                                Catch ex As Exception
                                                    AccountReceivableImportStaging = Nothing
                                                End Try

                                                If AccountReceivableImportStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Delete(DbContext, AccountReceivableImportStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.DigitalResults

                                                Try

                                                    ImportDigitalResultsStaging = DirectCast(RowHandleAndDataBoundItem.Value, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

                                                Catch ex As Exception
                                                    ImportDigitalResultsStaging = Nothing
                                                End Try

                                                If ImportDigitalResultsStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.Delete(DbContext, ImportDigitalResultsStaging)

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.AvalaraTaxCode

                                                Try

                                                    ImportAvalaraTaxStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportAvalaraTaxStaging = Nothing
                                                End Try

                                                If ImportAvalaraTaxStaging IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_AVALARA_TAX_STAGING WHERE IMPORT_ID={0}", ImportAvalaraTaxStaging.ImportID)) > 0 Then

                                                            Deleted = True

                                                        Else

                                                            Deleted = False

                                                        End If

                                                    Catch ex As Exception
                                                        Deleted = False
                                                    End Try

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.CashReceipt

                                                Try

                                                    ImportClientCashReceipt = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportClientCashReceipt = Nothing
                                                End Try

                                                If ImportClientCashReceipt IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_CR_DETAIL WHERE ID={0}", ImportClientCashReceipt.DetailID)) > 0 Then

                                                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_CR_HEADER WHERE IMPORT_ID = {0} AND (SELECT COUNT(1) FROM dbo.IMP_CR_DETAIL WHERE IMPORT_ID = {0}) = 0", ImportClientCashReceipt.ID))

                                                            Deleted = True

                                                        Else

                                                            Deleted = False

                                                        End If

                                                    Catch ex As Exception
                                                        Deleted = False
                                                    End Try

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.ClientContact

                                                Try

                                                    ImportClientContactStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportClientContactStaging = Nothing
                                                End Try

                                                If ImportClientContactStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportClientContactStaging.Delete(DbContext, ImportClientContactStaging, "")

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.PTO

                                                Try

                                                    ImportPTOItem = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportPTOItem = Nothing
                                                End Try

                                                If ImportPTOItem IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.IMP_PTO_STAGING WHERE IMPORT_ID={0}", ImportPTOItem.ImportID)) > 0 Then

                                                            Deleted = True

                                                        Else

                                                            Deleted = False

                                                        End If

                                                    Catch ex As Exception
                                                        Deleted = False
                                                    End Try

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.JournalEntry

                                                Try

                                                    ImportJournalEntry = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportJournalEntry = Nothing
                                                End Try

                                                If ImportJournalEntry IsNot Nothing Then

                                                    Try

                                                        If DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_JE_DETAIL WHERE ID={0}", ImportJournalEntry.DetailID)) > 0 Then

                                                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_JE_HEADER WHERE IMPORT_ID = {0} AND (SELECT COUNT(1) FROM dbo.IMP_JE_DETAIL WHERE IMPORT_ID = {0}) = 0", ImportJournalEntry.ID))

                                                            Deleted = True

                                                        Else

                                                            Deleted = False

                                                        End If

                                                    Catch ex As Exception
                                                        Deleted = False
                                                    End Try

                                                End If

                                            Case AdvantageFramework.Importing.ImportType.Employee

                                                Try

                                                    ImportEmployeeHourStaging = RowHandleAndDataBoundItem.Value

                                                Catch ex As Exception
                                                    ImportEmployeeHourStaging = Nothing
                                                End Try

                                                If ImportEmployeeHourStaging IsNot Nothing Then

                                                    Deleted = AdvantageFramework.Database.Procedures.ImportEmployeeHoursStaging.Delete(DbContext, ImportEmployeeHourStaging)

                                                End If

                                        End Select

                                        If Deleted Then

                                            DataGridViewForm_ImportedItems.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    Next

                                End If

                            End Using

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If DataGridViewForm_ImportedItems.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                    If DataGridViewForm_ImportedItems.HasRows = False Then

                        BindingSource = DataGridViewForm_ImportedItems.DataSource

                        If BindingSource.Count = 0 Then

                            Me.ShowWaitForm()
                            Me.FormAction = WinForm.Presentation.FormActions.Loading

                            Try

                                LoadAvailableBatches()

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                            Try

                                LoadSelectedBatch()

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                            EnableOrDisableActions()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save(True)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim ImportTemplateTypeName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim SelectedItems As IEnumerable = Nothing

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            ImportTemplateTypeName = ComboBoxSettings_ImportType.GetSelectedValue

            ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ImportTemplateTypeName)

            SelectedItems = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems

            If AdvantageFramework.Importing.Presentation.ImportDefaultsDialog.ShowFormDialog(ImportTemplateType, SelectedItems) = Windows.Forms.DialogResult.OK Then

                DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                Select Case _ImportType

                    Case Methods.ImportType.ExpenseReport

                        Me.ShowWaitForm("Validating ...")

                        Try

                            SetExpenseReportGroupValues((From Entity In SelectedItems.OfType(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging)()
                                                         Select Entity).ToList)

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    Case Methods.ImportType.AccountsPayable

                        Me.ShowWaitForm("Validating ...")

                        SetAccountsPayableAutoFillDependentProperties(SelectedItems)

                        Me.CloseWaitForm()

                    Case Methods.ImportType.DigitalResults

                        SetDigitalResultsAutoFillDependentProperties(SelectedItems)

                        DigitalResultsRefreshValidation(SelectedItems)

                    Case Methods.ImportType.JournalEntry

                        Me.ShowWaitForm("Validating ...")

                        SetJournalEntryAutoFillDependentPropertiesAndValidate(SelectedItems)

                        Me.CloseWaitForm()

                End Select

                If _ImportType <> Methods.ImportType.AccountsPayable AndAlso _ImportType <> Methods.ImportType.ExpenseReport AndAlso _ImportType <> ImportType.JournalEntry Then

                    Me.ShowWaitForm("Validating ...")

                    ValidateAllRows(True)

                    Me.CloseWaitForm()

                End If

                DataGridViewForm_ImportedItems.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Validate_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Validate.Click

            If _ImportType = Methods.ImportType.AccountsPayable Then

                If AdvantageFramework.WinForm.MessageBox.Show("Save and Validate?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                    AccountsPayableSaveAndValidate()

                End If

            ElseIf _ImportType = Methods.ImportType.DigitalResults Then

                If AdvantageFramework.WinForm.MessageBox.Show("Save and Validate?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                    DigitalResultsSaveAndValidate()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedItems_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ImportedItems.CellValueChangedEvent

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ExpenseReport

                    DataGridView_CellValueChanged_ExpenseReport(e)

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridView_CellValueChanged_AccountsPayable(e)

                Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                    DataGridView_CellValueChanged_AccountsReceivable(e)

                Case AdvantageFramework.Importing.ImportType.DigitalResults

                    DataGridView_CellValueChanged_DigitalResults(e)

                Case AdvantageFramework.Importing.ImportType.PTO

                    DataGridView_CellValueChanged_PTO(e)

                Case AdvantageFramework.Importing.ImportType.JournalEntry

                    DataGridView_CellValueChanged_JournalEntry(e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ImportedItems.CellValueChangingEvent

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridView_CellValueChanging_AccountsPayable(Saved, e)

                Case AdvantageFramework.Importing.ImportType.CashReceipt

                    DataGridView_CellValueChanging_CashReceipts(Saved, e)

                Case AdvantageFramework.Importing.ImportType.JournalEntry

                    DataGridView_CellValueChanging_JournalEntry(Saved, e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_ImportedItems.ColumnValueChangedEvent

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridView_ColumnValueChanged_AccountsPayable(e, ViaCellValueChangedEvent)

                    'Case AdvantageFramework.Importing.ImportType.CashReceipt

                    '    DataGridView_ColumnValueChanged_CashReceipts(e, ViaCellValueChangedEvent)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewForm_ImportedItems.CustomDrawGroupRowEvent

            Select Case _ImportType

                Case Methods.ImportType.ExpenseReport

                    DataGridViewForm_ImportedItems_CustomDrawGroupRowEvent_ExpenseReport(e)

                Case Else


            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ImportedItems.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedItems_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_ImportedItems.PopupMenuShowingEvent

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    DataGridViewForm_ImportedItems_PopupMenuShowingEvent_AccountsPayable(sender, e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ImportedItems.QueryPopupNeedDatasourceEvent

            Select Case _ImportType

                Case Methods.ImportType.ExpenseReport

                    DataGridView_QueryPopupNeedDatasourceEvent_ExpenseReport(FieldName, OverrideDefaultDatasource, Datasource)

                Case Methods.ImportType.AccountsReceivable

                    DataGridView_QueryPopupNeedDatasourceEvent_AccountsReceivable(FieldName, OverrideDefaultDatasource, Datasource)

                Case Methods.ImportType.DigitalResults

                    DataGridView_QueryPopupNeedDatasourceEvent_DigitalResults(FieldName, OverrideDefaultDatasource, Datasource)

                Case Methods.ImportType.JournalEntry

                    DataGridView_QueryPopupNeedDatasourceEvent_JournalEntry(FieldName, OverrideDefaultDatasource, Datasource)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_RowCellClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles DataGridViewForm_ImportedItems.RowCellClickEvent

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    DataGridView_RowCellClickEvent_AccountsPayable(e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_ImportedItems.RowCellStyleEvent

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    DataGridView_RowCellStyle_AccountsPayable(e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ImportedItems.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ImportedItems.ShowingEditorEvent

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridView_ShowingEditor_AccountsPayable(e)

                Case AdvantageFramework.Importing.ImportType.Function

                    DataGridView_ShowingEditor_Function(e)

                Case AdvantageFramework.Importing.ImportType.DigitalResults

                    DataGridView_ShowingEditor_DigitalResults(e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ImportedItems.ShownEditorEvent

            If DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle >= 0 Then

                Select Case _ImportType

                    Case AdvantageFramework.Importing.ImportType.ClearedChecks

                        DataGridView_ShownEditor_ClearedChecks()

                    Case AdvantageFramework.Importing.ImportType.AccountsPayable

                        DataGridView_ShownEditor_AccountsPayable()

                    Case Methods.ImportType.DigitalResults

                        DataGridView_ShownEditor_DigitalResults()

                    Case AdvantageFramework.Importing.ImportType.CashReceipt

                        DataGridView_ShownEditor_CashReceipts()

                    Case AdvantageFramework.Importing.ImportType.PTO

                        DataGridView_ShownEditor_PTO()

                End Select

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_ImportedItems.ValidateRowEvent

            If _ImportType <> AdvantageFramework.Importing.ImportType.AccountsPayable AndAlso DataGridViewForm_ImportedItems.RunStandardValidation = False Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = _DataContext
                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If DataGridViewForm_ImportedItems.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Mapping_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Mapping.Click

            If _ImportType = Methods.ImportType.AccountsPayable Then

                PerformAccountsPayableMapping()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
            Me.ShowWaitForm()

            Try

                LoadSelectedBatch()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ImportTemplateTypeName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim BatchName As String = Nothing

            If CheckForUnsavedChanges() Then

                ImportTemplateTypeName = ComboBoxSettings_ImportType.GetSelectedValue

                ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ImportTemplateTypeName)

                BatchName = ComboBoxSettings_Batch.SelectedValue

                If AdvantageFramework.Importing.Presentation.ImportWizardDialog.ShowWizardDialog(_ImportType, ImportTemplateType, BatchName) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadAvailableBatches()

                    Catch ex As Exception

                    End Try

                    ComboBoxSettings_Batch.SelectedValue = BatchName
                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemImport_NewBatch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemImport_NewBatch.Click

            'objects
            Dim ImportTemplateTypeName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim BatchName As String = Nothing
            Dim VCCProvider As Short = Nothing
            Dim AllowContinue As Boolean = True

            If CheckForUnsavedChanges() Then

                ImportTemplateTypeName = ComboBoxSettings_ImportType.GetSelectedValue

                ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ImportTemplateTypeName)

                If ImportTemplateType = ImportTemplateTypes.ClearedChecks_MediaVCC Then

                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        VCCProvider = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

                    End Using

                    If VCCProvider = 0 Then

                        AllowContinue = False

                        AdvantageFramework.Navigation.ShowMessageBox("VCC settings are not setup properly.  Please check all your VCC settings.")

                    ElseIf VCCProvider = AdvantageFramework.VCC.VCCProviders.EFS AndAlso AdvantageFramework.VCC.IsVCCServiceSetup(Session) = False Then

                        AllowContinue = False

                        AdvantageFramework.Navigation.ShowMessageBox("Failed trying to connect to VCC service.  Please check all your VCC settings.")

                    End If

                End If

                If AllowContinue AndAlso AdvantageFramework.Importing.Presentation.ImportWizardDialog.ShowWizardDialog(_ImportType, ImportTemplateType, BatchName) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    If _ImportType = Methods.ImportType.AccountsPayable Then

                        SaveLastSelectedAPImportType()

                    End If

                    Try

                        LoadAvailableBatches()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    ComboBoxSettings_Batch.SelectedValue = BatchName

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            DataGridViewForm_ImportedItems.Print(Me.DefaultLookAndFeel.LookAndFeel, AdvantageFramework.StringUtilities.GetNameAsWords(_ImportType.ToString))

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim UserCode As String = Nothing
            Dim BatchName As String = Nothing
            Dim DetailPageBreak As Boolean = False
            Dim AccountPayableBatchReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport) = Nothing
            Dim AccountReceivableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivable) = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim ClientCashReceiptBatchReportList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport) = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportRange As String = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGLSourceCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim GeneralLedgerImportBatchList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.GeneralLedgerImportBatch) = Nothing
            Dim BatchDate As Date = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim GLSourceCodes As IEnumerable(Of String) = Nothing

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    UserCode = Me.Session.UserCode

                    If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog.ShowFormDialog(ReportType, UserCode, BatchName, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                        SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                        SqlParameterUserCode.Value = UserCode

                        SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                        SqlParameterBatchName.Value = BatchName

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AccountPayableBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)("exec advsp_ap_import_batch_report @user_code, @batch_name", SqlParameterUserCode, SqlParameterBatchName).ToList

                        End Using

                        ReportRange = "Import Batch: " & BatchName

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", AccountPayableBatchReportList)
                        ParameterDictionary.Add("ForUser", UserCode)
                        ParameterDictionary.Add("ReportRange", ReportRange)
                        ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                        If ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummary Then

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchSummary, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder Then

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        Else

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchDetail, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End If

                Case Methods.ImportType.AccountsReceivable

                    UserCode = Me.Session.UserCode

                    If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsReceivableBatchReportDialog.ShowFormDialog(UserCode, BatchName) = System.Windows.Forms.DialogResult.OK Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AccountReceivableList = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByUserCodeAndBatchName(DbContext, UserCode, BatchName).ToList

                        End Using

                        ReportRange = "Import Batch: " & BatchName

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", AccountReceivableList)
                        ParameterDictionary.Add("ForUser", UserCode)
                        ParameterDictionary.Add("ReportRange", ReportRange)

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountReceivableImportBatch, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                Case Methods.ImportType.Client

                    If AdvantageFramework.Importing.Presentation.ImportBatchReportDialog.ShowFormDialog(AdvantageFramework.Importing.Methods.ImportType.Client, BatchName) = System.Windows.Forms.DialogResult.OK Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ClientList = AdvantageFramework.Database.Procedures.Client.LoadByBatchName(DbContext, BatchName).Include("ClientDiscount").ToList

                        End Using

                        If ClientList IsNot Nothing Then

                            ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            ParameterDictionary.Add("DataSource", ClientList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ClientDetail, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End If

                Case Methods.ImportType.Division

                    If AdvantageFramework.Importing.Presentation.ImportBatchReportDialog.ShowFormDialog(AdvantageFramework.Importing.Methods.ImportType.Division, BatchName) = System.Windows.Forms.DialogResult.OK Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DivisionList = AdvantageFramework.Database.Procedures.Division.LoadByBatchName(DbContext, BatchName).Include("Client").ToList

                        End Using

                        If DivisionList IsNot Nothing Then

                            ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            ParameterDictionary.Add("DataSource", DivisionList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.DivisionDetail, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End If

                Case Methods.ImportType.Product

                    If AdvantageFramework.Importing.Presentation.ImportBatchReportDialog.ShowFormDialog(AdvantageFramework.Importing.Methods.ImportType.Product, BatchName) = System.Windows.Forms.DialogResult.OK Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ProductList = AdvantageFramework.Database.Procedures.Product.LoadByBatchName(DbContext, BatchName).Include("Office").Include("Client").Include("Division").Include("AccountExecutives").ToList

                        End Using

                        If ProductList IsNot Nothing Then

                            ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            ParameterDictionary.Add("DataSource", ProductList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ProductDetail, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End If

                Case Methods.ImportType.CashReceipt

                    If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog.ShowFormDialog(ReportType, BatchName, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                        SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                        SqlParameterBatchName.Value = BatchName

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ClientCashReceiptBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport)("exec dbo.advsp_clientcashreceipt_import_batch_report @batch_name", SqlParameterBatchName).ToList()

                        End Using

                        ReportRange = "Import Batch: " & BatchName

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", ClientCashReceiptBatchReportList)
                        ParameterDictionary.Add("ForUser", "N/A")
                        ParameterDictionary.Add("ReportRange", ReportRange)
                        ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                        If ReportType = AdvantageFramework.Reporting.ReportTypes.ClientCashReceiptBatchReport Then

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.ClientCashReceiptBatchReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        Else

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.ClientCashReceiptBatchSummaryReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End If

                Case Methods.ImportType.JournalEntry

                    ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue)

                    If AdvantageFramework.Importing.Presentation.GeneralLedgerBatchReportDialog.ShowFormDialog(ImportTemplateType, UserCode, BatchDate, GLSourceCodes) = System.Windows.Forms.DialogResult.OK Then

                        SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_date", SqlDbType.SmallDateTime)
                        SqlParameterBatchName.Value = BatchDate

                        SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                        SqlParameterUserCode.Value = UserCode

                        SqlParameterGLSourceCodes = New System.Data.SqlClient.SqlParameter("@glsource_codes", SqlDbType.VarChar)
                        SqlParameterGLSourceCodes.Value = String.Join("|", GLSourceCodes.ToArray)

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            GeneralLedgerImportBatchList = DbContext.Database.SqlQuery(Of AdvantageFramework.GeneralLedger.Classes.GeneralLedgerImportBatch)("exec dbo.advsp_gl_import_batch_report @batch_date, @user_code, @glsource_codes", SqlParameterBatchName, SqlParameterUserCode, SqlParameterGLSourceCodes).ToList()

                        End Using

                        If GeneralLedgerImportBatchList IsNot Nothing Then

                            DataGridView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView

                            DataGridView.OptionsView.ShowViewCaption = False
                            DataGridView.OptionsView.ColumnAutoWidth = True
                            DataGridView.OptionsPrint.AutoWidth = True
                            DataGridView.DataSource = GeneralLedgerImportBatchList
                            DataGridView.CurrentView.BestFitColumns()

                            DataGridView.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, "General Ledger Import Report", UseLandscape:=True)

                        End If

                    End If

            End Select

        End Sub
        Private Sub MappingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MappingToolStripMenuItem.Click

            Select Case _ImportType

                Case Methods.ImportType.AccountsPayable

                    MappingToolStripMenuItem_ClickEvent_AccountsPayable(e)

            End Select

        End Sub
        Private Sub ButtonItemOnHold_Check_Click(sender As Object, e As EventArgs) Handles ButtonItemOnHold_Check.Click

            SetOnHold(True)

        End Sub
        Private Sub ButtonItemOnHold_Uncheck_Click(sender As Object, e As EventArgs) Handles ButtonItemOnHold_Uncheck.Click

            SetOnHold(False)

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            ChooseColumns()

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            RestoreDefaults()

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ColumnPositionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ImportedItems.ColumnPositionChangedEvent

            'objets
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = DirectCast(sender, DevExpress.XtraGrid.Columns.GridColumn)

            Select Case _ImportType

                Case ImportType.AccountsPayable

                    If GridColumn.Tag IsNot Nothing Then

                        Try

                            If Not GridColumn.Visible Then

                                GridColumn.Caption = GridColumn.Tag.NoBreaks

                            Else

                                GridColumn.Caption = GridColumn.Tag.Caption
                                GridColumn.AppearanceHeader.Options.UseBackColor = False

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                    DataGridViewForm_ImportedItems.CurrentView.AutoSizeColumnHeaderPanel()

            End Select

        End Sub
        Private Sub DataGridViewForm_ImportedItems_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ImportedItems.DataSourceChangedEvent

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ClearedChecks

                    If AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue) = AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_MediaVCC Then

                        DataGridViewForm_ImportedItems_DataSourceChangedEvent_ClearedChecks_MediaVCC()

                    End If

                Case AdvantageFramework.Importing.ImportType.AccountsPayable

                    DataGridViewForm_ImportedItems.CurrentView.AutoSizeColumnHeaderPanel()

            End Select

        End Sub

#End Region

#Region "   Expense Report "

        Private Sub DataGridViewForm_ImportedItems_CustomDrawGroupRowEvent_ExpenseReport(e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)

            'objects
            Dim GroupLevel As Integer = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing

            Try

                GridGroupRowInfo = DirectCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            Catch ex As Exception
                GridGroupRowInfo = Nothing
            End Try

            If GridGroupRowInfo IsNot Nothing Then

                GroupLevel = DataGridViewForm_ImportedItems.CurrentView.GetRowLevel(e.RowHandle)

                Select Case GroupLevel

                    Case 0

                        GridGroupRowInfo.GroupText = "Employee: " & GridGroupRowInfo.GroupValueText

                    Case 1

                        GridGroupRowInfo.GroupText = "Expense Report for: " & GridGroupRowInfo.GroupValueText

                End Select

            End If

        End Sub
        Private Sub DataGridView_CellValueChanged_ExpenseReport(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim EmployeeCode As String = Nothing
            Dim ExpenseReportDate As Date = Nothing

            Try

                ImportCreditCardStaging = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportCreditCardStaging = Nothing
            End Try

            If ImportCreditCardStaging IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.Amount.ToString Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(ImportCreditCardStaging.Quantity, ImportCreditCardStaging.Rate, e.Value, BillingSystem.QtyRateAmount.Amount)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.Quantity.ToString Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(e.Value, ImportCreditCardStaging.Rate, ImportCreditCardStaging.Amount, BillingSystem.QtyRateAmount.Quantity)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.Rate.ToString Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(ImportCreditCardStaging.Quantity, e.Value, ImportCreditCardStaging.Amount, BillingSystem.QtyRateAmount.Rate)

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDescription.ToString OrElse
                       e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDetail.ToString Then

                    If e.Value IsNot Nothing Then

                        SetExpenseReportValues(e.Column.FieldName)

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString OrElse
                       e.Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDate.ToString Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString

                            EmployeeCode = e.Value
                            ExpenseReportDate = ImportCreditCardStaging.ExpenseReportDate

                        Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDate.ToString

                            EmployeeCode = ImportCreditCardStaging.EmployeeCode
                            ExpenseReportDate = e.Value

                    End Select

                    If String.IsNullOrEmpty(EmployeeCode) = False AndAlso ExpenseReportDate <> Nothing Then

                        SetExpenseReportGroupValues(e.RowHandle, EmployeeCode, ExpenseReportDate)

                    End If

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub DataGridView_QueryPopupNeedDatasourceEvent_ExpenseReport(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ExcludedJobProcessControlNumbers As Integer() = Nothing
            Dim JobComponentJobNumbers As Integer() = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponentID As String = Nothing

            ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Select Case FieldName

                    Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentID.ToString

                        OverrideDefaultDatasource = True

                        JobNumber = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobNumber.ToString)
                        ClientCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ProductCode.ToString)

                        If JobNumber IsNot Nothing Then

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext).ToList
                                         Where Entity.JobNumber = JobNumber AndAlso
                                               ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False
                                         Select Entity

                        Else

                            JobComponentJobNumbers = (From JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext).ToList
                                                      Where ExcludedJobProcessControlNumbers.Contains(JobComp.JobProcessNumber) = False
                                                      Select [JobNum] = JobComp.JobNumber).Distinct.ToArray

                            JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).ToList
                                          Where Job.IsOpen = 1 AndAlso
                                                JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                                Job.ClientCode = If(String.IsNullOrEmpty(ClientCode), Job.ClientCode, ClientCode) AndAlso
                                                Job.DivisionCode = If(String.IsNullOrEmpty(DivisionCode), Job.DivisionCode, DivisionCode) AndAlso
                                                Job.ProductCode = If(String.IsNullOrEmpty(ProductCode), Job.ProductCode, ProductCode)
                                          Select Job.Number).ToArray

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext).ToList
                                         Where JobNumbers.Contains(Entity.JobNumber) AndAlso
                                               ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False
                                         Select Entity

                        End If

                    Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobNumber.ToString

                        OverrideDefaultDatasource = True

                        JobComponentID = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentID.ToString)
                        ClientCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ProductCode.ToString)

                        If String.IsNullOrEmpty(JobComponentID) = False Then

                            Try

                                JobComponent = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                Where Entity.ID = JobComponentID AndAlso
                                                      ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False
                                                Select Entity).SingleOrDefault

                            Catch ex As Exception
                                JobComponent = Nothing
                            End Try

                        End If

                        If JobComponent IsNot Nothing Then

                            Datasource = (From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext)
                                          Where Job.Number = JobComponent.JobNumber AndAlso
                                                Job.IsOpen = 1
                                          Select Job).ToList

                        Else

                            JobComponentJobNumbers = (From JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)
                                                      Where ExcludedJobProcessControlNumbers.Contains(JobComp.JobProcessNumber) = False
                                                      Select [JobNum] = JobComp.JobNumber).Distinct.ToArray

                            Datasource = From Job In AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).ToList
                                         Where Job.IsOpen = 1 AndAlso
                                               JobComponentJobNumbers.Contains(Job.Number) AndAlso
                                               Job.ClientCode = If(String.IsNullOrEmpty(ClientCode), Job.ClientCode, ClientCode) AndAlso
                                               Job.DivisionCode = If(String.IsNullOrEmpty(DivisionCode), Job.DivisionCode, DivisionCode) AndAlso
                                               Job.ProductCode = If(String.IsNullOrEmpty(ProductCode), Job.ProductCode, ProductCode)
                                         Select Job

                        End If

                End Select

            End Using

        End Sub
        Private Sub SetExpenseReportValues(ByVal FieldName As String)

            'objects
            Dim SelectedRowHandle As Integer = Nothing
            Dim FieldValue As Object = Nothing
            Dim EmployeeCode As String = Nothing
            Dim ExpenseReportDate As Date = Nothing
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing

            Try

                SelectedRowHandle = DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle

                EmployeeCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString)
                ExpenseReportDate = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDate.ToString)

                FieldValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(SelectedRowHandle, FieldName)

                For RowHandle = 0 To DataGridViewForm_ImportedItems.CurrentView.RowCount - 1

                    If RowHandle <> SelectedRowHandle Then

                        If DataGridViewForm_ImportedItems.CurrentView.IsGroupRow(RowHandle) = False Then

                            ImportCreditCardStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle)

                            If ImportCreditCardStaging IsNot Nothing Then

                                If ImportCreditCardStaging.EmployeeCode = EmployeeCode AndAlso ImportCreditCardStaging.ExpenseReportDate = ExpenseReportDate Then

                                    Select Case FieldName

                                        Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDescription.ToString

                                            ImportCreditCardStaging.ExpenseReportDescription = FieldValue

                                        Case AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDetail.ToString

                                            ImportCreditCardStaging.ExpenseReportDetail = FieldValue

                                    End Select

                                    DataGridViewForm_ImportedItems.CurrentView.RefreshRow(RowHandle)

                                End If

                            End If

                        End If

                    End If

                Next

                DataGridViewForm_ImportedItems.ValidateAllRows()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SetExpenseReportGroupValues(ByVal ImportCreditCardStagings As IEnumerable(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging))

            'objects
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim GroupTemplateImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim UniqueEmployeeCodes() As String = Nothing
            Dim UniqueEmployeeCode As String = Nothing

            Try

                UniqueEmployeeCodes = (From Entity In ImportCreditCardStagings
                                       Select Entity.EmployeeCode).Distinct.ToArray

            Catch ex As Exception
                UniqueEmployeeCodes = Nothing
            End Try

            For Each UniqueEmployeeCode In UniqueEmployeeCodes

                Try

                    For Each ExpenseReportDate In (From Entity In ImportCreditCardStagings
                                                   Where Entity.EmployeeCode = UniqueEmployeeCode
                                                   Select [ExpRptDate] = Entity.ExpenseReportDate).Distinct.ToList

                        Try

                            GroupTemplateImportCreditCardStaging = (From Entity In ImportCreditCardStagings
                                                                    Where Entity.EmployeeCode = UniqueEmployeeCode
                                                                    Select Entity).FirstOrDefault

                        Catch ex As Exception
                            GroupTemplateImportCreditCardStaging = Nothing
                        End Try

                        If GroupTemplateImportCreditCardStaging IsNot Nothing Then

                            For RowHandle = 0 To DataGridViewForm_ImportedItems.CurrentView.RowCount - 1

                                If DataGridViewForm_ImportedItems.CurrentView.IsGroupRow(RowHandle) = False AndAlso
                                   DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString) = UniqueEmployeeCode AndAlso
                                   DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDate.ToString) = ExpenseReportDate Then

                                    ImportCreditCardStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle)

                                    If ImportCreditCardStaging IsNot Nothing Then

                                        ImportCreditCardStaging.ExpenseReportDescription = GroupTemplateImportCreditCardStaging.ExpenseReportDescription
                                        ImportCreditCardStaging.ExpenseReportDetail = GroupTemplateImportCreditCardStaging.ExpenseReportDetail

                                    End If

                                End If

                            Next

                        End If

                    Next

                Catch ex As Exception

                End Try

            Next

            DataGridViewForm_ImportedItems.SetUserEntryChanged()
            DataGridViewForm_ImportedItems.CurrentView.RefreshData()
            DataGridViewForm_ImportedItems.ValidateAllRows()

        End Sub
        Private Sub SetExpenseReportGroupValues(ByVal SelectedRowHandle As Integer, ByVal EmployeeCode As String, ByVal ExpenseReportDate As System.DateTime)

            'objects
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim SelectedImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing

            SelectedImportCreditCardStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(SelectedRowHandle)

            If SelectedImportCreditCardStaging IsNot Nothing Then

                For RowHandle = 0 To DataGridViewForm_ImportedItems.CurrentView.RowCount - 1

                    If RowHandle <> SelectedRowHandle Then

                        Try

                            ImportCreditCardStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle)

                        Catch ex As Exception
                            ImportCreditCardStaging = Nothing
                        End Try

                        If ImportCreditCardStaging IsNot Nothing Then

                            If ImportCreditCardStaging.EmployeeCode = EmployeeCode AndAlso ImportCreditCardStaging.ExpenseReportDate = ExpenseReportDate Then

                                SelectedImportCreditCardStaging.ExpenseReportDescription = ImportCreditCardStaging.ExpenseReportDescription
                                SelectedImportCreditCardStaging.ExpenseReportDetail = ImportCreditCardStaging.ExpenseReportDetail

                            End If

                        End If

                    End If

                Next

                DataGridViewForm_ImportedItems.ValidateAllRows()

            End If

        End Sub

#End Region

#Region "   Cleared Checks "

        Private Sub DataGridView_ShownEditor_ClearedChecks()

            'objects
            Dim ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim FocusedRowHandle As Integer = Nothing

            If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties.BankCode.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    FocusedRowHandle = DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle

                    Try

                        ImportClearedChecksStaging = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ImportClearedChecksStaging = Nothing
                    End Try

                    If ImportClearedChecksStaging Is Nothing Then

                        Try

                            ImportClearedChecksStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(FocusedRowHandle)

                        Catch ex As Exception
                            ImportClearedChecksStaging = Nothing
                        End Try

                    End If

                    If ImportClearedChecksStaging IsNot Nothing Then

                        Try

                            GridLookUpEdit = DirectCast(DataGridViewForm_ImportedItems.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                        Catch ex As Exception
                            GridLookUpEdit = Nothing
                        End Try

                        If GridLookUpEdit IsNot Nothing Then

                            GridLookUpEdit.Properties.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).ToList
                                                                    Select Entity.Code,
                                                                           [Description] = Entity.ToString).ToList

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemClearedChecks_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClearedChecks_All.CheckedChanged

            If Me.FormShown Then

                If ButtonItemClearedChecks_All.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    Me.ShowWaitForm()

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemClearedChecks_Invalid_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClearedChecks_Invalid.CheckedChanged

            If Me.FormShown Then

                If ButtonItemClearedChecks_Invalid.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    Me.ShowWaitForm()

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemClearedChecks_Valid_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClearedChecks_Valid.CheckedChanged

            If Me.FormShown Then

                If ButtonItemClearedChecks_Valid.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    Me.ShowWaitForm()

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemCSIPreferredPartner_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemCSIPreferredPartner_Import.Click

            'objects
            Dim ImportTemplateTypeName As String = Nothing
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim BatchName As String = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ImportTemplateTypeName = ComboBoxSettings_ImportType.GetSelectedValue

                ImportTemplateType = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ImportTemplateTypeName)

                If ImportTemplateType = ImportTemplateTypes.ClearedChecks_Default Then

                    If CheckForUnsavedChanges() Then

                        If AdvantageFramework.Importing.Presentation.ImportWizardDialog.ShowWizardDialog(_ImportType, ImportTemplateType, BatchName, True) = Windows.Forms.DialogResult.OK Then

                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm()

                            Try

                                LoadAvailableBatches()

                            Catch ex As Exception

                            End Try

                            ComboBoxSettings_Batch.SelectedValue = BatchName
                            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                            Try

                                LoadSelectedBatch()

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                            EnableOrDisableActions()

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Accounts Payable "

        Private Sub AccountsPayableAddEntityToList(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable,
                                                   ByRef ImportAccountPayablesList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable),
                                                   ByVal IsAPLimitByOfficeEnabled As Boolean,
                                                   ByVal IsInterCompanyTransactionsEnabled As Boolean,
                                                   Session As AdvantageFramework.Security.Session)

            Dim ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader = Nothing

            ImportAccountPayableHeader = New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader(ImportAccountPayable, IsAPLimitByOfficeEnabled, IsInterCompanyTransactionsEnabled, Session)

            If ImportAccountPayableHeader.ImportAccountPayableGLs.Any Then

                For Each DetailEntity In ImportAccountPayableHeader.ImportAccountPayableGLs

                    DetailEntity.Session = Session
                    ImportAccountPayablesList.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayable(DbContext, ImportAccountPayable, ImportAccountPayableHeader, DetailEntity))

                Next

            End If

            If ImportAccountPayableHeader.ImportAccountPayableJobs.Any Then

                For Each DetailEntity In ImportAccountPayableHeader.ImportAccountPayableJobs

                    ImportAccountPayablesList.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayable(DbContext, ImportAccountPayable, ImportAccountPayableHeader, DetailEntity))

                Next

            End If

            If ImportAccountPayableHeader.ImportAccountPayableMedias.Any Then

                For Each DetailEntity In ImportAccountPayableHeader.ImportAccountPayableMedias

                    ImportAccountPayablesList.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayable(DbContext, ImportAccountPayable, ImportAccountPayableHeader, DetailEntity))

                Next

            End If

        End Sub
        Private Function GetAccountsPayableListByBatchAndVendorAndInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                          ByVal VendorCode As String,
                                                                          ByVal InvoiceNumber As String) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim IsAPLimitByOfficeEnabled As Boolean = False
            Dim IsInterCompanyTransactionsEnabled As Boolean = False

            IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)
            IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            ImportAccountPayableList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchNameAndVendorCodeAndInvoiceNumber(DbContext, ComboBoxSettings_Batch.SelectedValue, VendorCode, InvoiceNumber)

            If ImportAccountPayable IsNot Nothing Then

                AccountsPayableAddEntityToList(DbContext, ImportAccountPayable, ImportAccountPayableList, IsAPLimitByOfficeEnabled, IsInterCompanyTransactionsEnabled, Session)

            End If

            GetAccountsPayableListByBatchAndVendorAndInvoice = ImportAccountPayableList

        End Function
        Private Sub SetAccountsPayableAutoFillDependentProperties(ByVal SelectedItems As IEnumerable)

            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim UniqueHeaderIDs() As Integer = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

            UniqueHeaderIDs = (From Entity In SelectedItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)()
                               Select Entity.ID).Distinct.ToArray

            BindingSource = DataGridViewForm_ImportedItems.DataSource

            ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)() _
                                                            .Where(Function(Entity) UniqueHeaderIDs.Contains(Entity.ID)).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                VendorList = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).ToList
                ClientList = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext).ToList
                DivisionList = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext).ToList
                ProductList = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext).ToList

                For Each ImportAccountPayable In ImportAccountPayableList

                    If Not String.IsNullOrEmpty(ImportAccountPayable.VendorCode) Then

                        ImportAccountPayable.VendorName = VendorList.Where(Function(Entity) Entity.Code = ImportAccountPayable.VendorCode).Select(Function(Entity) Entity.Name).FirstOrDefault

                    End If

                    If ImportAccountPayable.JobNumber.GetValueOrDefault(0) <> 0 Then

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ImportAccountPayable.JobNumber)

                        If Job IsNot Nothing Then

                            ImportAccountPayable.JobClientCode = Job.ClientCode
                            ImportAccountPayable.JobClientName = Job.Client.Name
                            ImportAccountPayable.JobDivisionCode = Job.DivisionCode
                            ImportAccountPayable.JobDivisionName = Job.Division.Name
                            ImportAccountPayable.JobProductCode = Job.ProductCode
                            ImportAccountPayable.JobProductName = Job.Product.Name
                            ImportAccountPayable.JobOfficeCode = Job.OfficeCode

                        End If

                    End If

                    If Not String.IsNullOrEmpty(ImportAccountPayable.GLACode) Then

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, ImportAccountPayable.GLACode)

                        If GeneralLedgerAccount IsNot Nothing Then

                            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)

                                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    ImportAccountPayable.GLOfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                                End If

                            End If

                        End If

                    End If

                    If Not String.IsNullOrWhiteSpace(ImportAccountPayable.MediaClientCode) Then

                        ImportAccountPayable.MediaClientName = ClientList.Where(Function(c) c.Code = ImportAccountPayable.MediaClientCode).Select(Function(c) c.Name).FirstOrDefault
                        ImportAccountPayable.Modified = True

                    End If

                    If Not String.IsNullOrWhiteSpace(ImportAccountPayable.MediaDivisionCode) Then

                        ImportAccountPayable.MediaDivisionName = DivisionList.Where(Function(d) d.ClientCode = ImportAccountPayable.MediaClientCode AndAlso d.Code = ImportAccountPayable.MediaDivisionCode).Select(Function(d) d.Name).FirstOrDefault
                        ImportAccountPayable.Modified = True

                    End If

                    If Not String.IsNullOrWhiteSpace(ImportAccountPayable.MediaProductCode) Then

                        ImportAccountPayable.MediaProductName = ProductList.Where(Function(p) p.ClientCode = ImportAccountPayable.MediaClientCode AndAlso p.DivisionCode = ImportAccountPayable.MediaDivisionCode AndAlso p.Code = ImportAccountPayable.MediaProductCode).Select(Function(p) p.Name).FirstOrDefault
                        ImportAccountPayable.Modified = True

                    End If

                Next

            End Using

            'Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    ValidateAccountsPayableMatchingInvoices(DbContext, ImportAccountPayableList)

            'End Using

            Me.DataGridViewForm_ImportedItems.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub SetAccountsPayableJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal RowHandle As Integer)

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponentList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

            If Job IsNot Nothing Then

                ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                ImportAccountPayable.JobClientCode = Job.ClientCode
                ImportAccountPayable.JobDivisionCode = Job.DivisionCode
                ImportAccountPayable.JobProductCode = Job.ProductCode
                ImportAccountPayable.JobOfficeCode = Job.OfficeCode

                JobComponentList = AdvantageFramework.Database.Procedures.JobComponent.LoadAndFilterByClientDivisionProductAndJob(DbContext, Job.ClientCode, Job.DivisionCode, Job.ProductCode, Job.Number).ToList

                If JobComponentList.Count = 1 Then

                    ImportAccountPayable.JobComponentNumber = JobComponentList(0).Number

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableJobDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail,
                                                 ByRef ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            ImportAccountPayable.JobNumber = PurchaseOrderDetail.JobNumber
            ImportAccountPayable.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
            ImportAccountPayable.JobClientCode = PurchaseOrderDetail.Job.ClientCode
            ImportAccountPayable.JobClientName = PurchaseOrderDetail.Job.Client.Name
            ImportAccountPayable.JobDivisionCode = PurchaseOrderDetail.Job.DivisionCode
            ImportAccountPayable.JobDivisionName = PurchaseOrderDetail.Job.Division.Name
            ImportAccountPayable.JobProductCode = PurchaseOrderDetail.Job.ProductCode
            ImportAccountPayable.JobProductName = PurchaseOrderDetail.Job.Product.Name
            ImportAccountPayable.FunctionCode = PurchaseOrderDetail.FunctionCode
            ImportAccountPayable.JobQuantity = PurchaseOrderDetail.Quantity

            If PurchaseOrderDetail.Function.NonBillableFlag.GetValueOrDefault(0) = 1 OrElse PurchaseOrderDetail.JobComponent.IsNonbillable.GetValueOrDefault(0) = 1 Then

                ImportAccountPayable.IsNonBillable = 1

                ImportAccountPayable.JobGLACode = PurchaseOrderDetail.Function.NonBillableClientGLACode

                If PurchaseOrderDetail.Job IsNot Nothing AndAlso PurchaseOrderDetail.Job.OfficeCode IsNot Nothing Then

                    ImportAccountPayable.JobOfficeCode = PurchaseOrderDetail.Job.OfficeCode

                End If

            Else

                ImportAccountPayable.IsNonBillable = 0

                If PurchaseOrderDetail.Job IsNot Nothing AndAlso PurchaseOrderDetail.Job.Office IsNot Nothing Then

                    ImportAccountPayable.JobOfficeCode = PurchaseOrderDetail.Job.Office.Code
                    ImportAccountPayable.JobGLACode = PurchaseOrderDetail.Job.Office.ProductionWorkInProgressGLACode

                End If

            End If

            ImportAccountPayable.JobNetAmount = PurchaseOrderDetail.ExtendedAmount

            BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, PurchaseOrderDetail.FunctionCode, PurchaseOrderDetail.Job.ClientCode, PurchaseOrderDetail.Job.DivisionCode, PurchaseOrderDetail.Job.ProductCode, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber, PurchaseOrderDetail.Job.SalesClassCode, Nothing, Nothing)

            ImportAccountPayable.GetImportAccountPayableJob.SetBillingRateFlags(BillingRate, PurchaseOrderDetail)

            ImportAccountPayable.PONetAmount = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

            ImportAccountPayable.JobComment = PurchaseOrderDetail.LineDescription

        End Sub
        Private Sub SetAccountsPayableJobDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RowHandle As Integer)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.GetImportAccountPayableJob.SetBillingRateFlags(Nothing)

            If ImportAccountPayable.JobNumber.GetValueOrDefault(0) <> 0 AndAlso ImportAccountPayable.JobComponentNumber.GetValueOrDefault(0) <> 0 Then

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ImportAccountPayable.JobNumber, ImportAccountPayable.JobComponentNumber)

            End If

            If JobComponent IsNot Nothing Then

                If String.IsNullOrEmpty(ImportAccountPayable.FunctionCode) Then

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportAccountPayable.VendorCode)

                    ImportAccountPayable.FunctionCode = Vendor.FunctionCode

                End If

                If ImportAccountPayable.FunctionCode IsNot Nothing Then

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, ImportAccountPayable.FunctionCode, ImportAccountPayable.JobClientCode,
                            ImportAccountPayable.JobDivisionCode, ImportAccountPayable.JobProductCode, ImportAccountPayable.JobNumber,
                            ImportAccountPayable.JobComponentNumber, JobComponent.Job.SalesClassCode, Nothing, Nothing)

                    If BillingRate IsNot Nothing Then

                        ImportAccountPayable.GetImportAccountPayableJob.SetBillingRateFlags(BillingRate)

                        If BillingRate.NOBILL_FLAG = 1 Then

                            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, ImportAccountPayable.FunctionCode)

                            If [Function] IsNot Nothing Then

                                If [Function].NonBillableClientGLACode Is Nothing Then

                                    AdvantageFramework.WinForm.MessageBox.Show("This function selected is non-billable, select a GL account.")
                                    ImportAccountPayable.JobGLACode = Nothing

                                Else

                                    ImportAccountPayable.JobGLACode = [Function].NonBillableClientGLACode

                                End If

                            End If

                        End If

                    End If

                ElseIf JobComponent.IsNonbillable.GetValueOrDefault(0) = 1 Then

                    ImportAccountPayable.IsNonBillable = JobComponent.IsNonbillable.GetValueOrDefault(0)

                    AdvantageFramework.WinForm.MessageBox.Show("The job component selected is non-billable, select a GL account.")
                    ImportAccountPayable.JobGLACode = Nothing

                End If

                If ImportAccountPayable.IsNonBillable.GetValueOrDefault(0) = 0 Then

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ImportAccountPayable.JobNumber)

                    If Job IsNot Nothing AndAlso Job.Office IsNot Nothing Then

                        ImportAccountPayable.JobGLACode = Job.Office.ProductionWorkInProgressGLACode

                    End If

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableJobDivisionProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim DivisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductDetails As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            DivisionDetails = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).ToList

            If DivisionDetails.Count > 0 Then

                ImportAccountPayable.JobClientName = DivisionDetails(0).Client.Name

                If DivisionDetails.Count = 1 Then

                    ImportAccountPayable.JobDivisionCode = DivisionDetails(0).Code
                    ImportAccountPayable.JobDivisionName = DivisionDetails(0).Name

                    ProductDetails = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionDetails(0).Code).ToList

                    If ProductDetails.Count = 1 Then

                        ImportAccountPayable.JobProductCode = ProductDetails(0).Code
                        ImportAccountPayable.JobProductName = ProductDetails(0).Name

                    Else

                        ImportAccountPayable.JobProductCode = Nothing
                        ImportAccountPayable.JobProductName = Nothing

                    End If

                    If String.IsNullOrEmpty(ImportAccountPayable.JobProductName) AndAlso Not String.IsNullOrEmpty(ImportAccountPayable.JobProductCode) Then

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, ImportAccountPayable.JobDivisionCode, ImportAccountPayable.JobProductCode)

                        If Product IsNot Nothing Then

                            ImportAccountPayable.JobProductName = Product.Name

                        End If

                    End If

                Else

                    ImportAccountPayable.JobDivisionCode = Nothing
                    ImportAccountPayable.JobDivisionName = Nothing

                    ImportAccountPayable.JobProductCode = Nothing
                    ImportAccountPayable.JobProductName = Nothing

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableJobProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DivisionCode As String, ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim ProductDetails As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            ProductDetails = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ImportAccountPayable.JobClientCode, DivisionCode).ToList

            If ProductDetails.Count > 0 Then

                ImportAccountPayable.JobDivisionName = ProductDetails(0).Division.Name

                If ProductDetails.Count = 1 Then

                    ImportAccountPayable.JobProductCode = ProductDetails(0).Code
                    ImportAccountPayable.JobProductName = ProductDetails(0).Name
                    ImportAccountPayable.JobOfficeCode = ProductDetails(0).OfficeCode

                Else

                    ImportAccountPayable.JobProductCode = Nothing
                    ImportAccountPayable.JobProductName = Nothing

                End If

                If String.IsNullOrEmpty(ImportAccountPayable.JobProductName) AndAlso Not String.IsNullOrEmpty(ImportAccountPayable.JobProductCode) Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportAccountPayable.JobClientCode, ImportAccountPayable.JobDivisionCode, ImportAccountPayable.JobProductCode)

                    If Product IsNot Nothing Then

                        ImportAccountPayable.JobProductName = Product.Name

                    End If

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableMediaDivisionProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim DivisionDetails As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductDetails As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            DivisionDetails = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).ToList

            If DivisionDetails.Count > 0 Then

                ImportAccountPayable.MediaClientName = DivisionDetails(0).Client.Name

                If DivisionDetails.Count = 1 Then

                    ImportAccountPayable.MediaDivisionCode = DivisionDetails(0).Code
                    ImportAccountPayable.MediaDivisionName = DivisionDetails(0).Name

                    ProductDetails = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionDetails(0).Code).ToList

                    If ProductDetails.Count = 1 Then

                        ImportAccountPayable.MediaProductCode = ProductDetails(0).Code
                        SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                    Else

                        ImportAccountPayable.MediaProductCode = Nothing
                        ImportAccountPayable.MediaProductName = Nothing

                    End If

                Else

                    ImportAccountPayable.MediaDivisionCode = Nothing
                    ImportAccountPayable.MediaDivisionName = Nothing

                    ImportAccountPayable.MediaProductCode = Nothing
                    ImportAccountPayable.MediaProductName = Nothing

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableMediaProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DivisionCode As String, ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Dim ProductDetails As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            ProductDetails = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ImportAccountPayable.MediaClientCode, DivisionCode).ToList

            If ProductDetails.Count > 0 Then

                ImportAccountPayable.MediaDivisionName = ProductDetails(0).Division.Name

                If ProductDetails.Count = 1 Then

                    ImportAccountPayable.MediaProductCode = ProductDetails(0).Code
                    ImportAccountPayable.MediaProductName = ProductDetails(0).Name
                    ImportAccountPayable.MediaOfficeCode = ProductDetails(0).OfficeCode

                Else

                    ImportAccountPayable.MediaProductCode = Nothing
                    ImportAccountPayable.MediaProductName = Nothing

                End If

                If String.IsNullOrEmpty(ImportAccountPayable.MediaProductName) AndAlso Not String.IsNullOrEmpty(ImportAccountPayable.MediaProductCode) Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode)

                    If Product IsNot Nothing Then

                        ImportAccountPayable.MediaProductName = Product.Name
                        ImportAccountPayable.MediaOfficeCode = Product.OfficeCode

                    End If

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableMediaDataDependentOnProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode)

            If Product IsNot Nothing Then

                ImportAccountPayable.MediaProductName = Product.Name

                ImportAccountPayable.MediaOfficeCode = Product.OfficeCode

                If Product.Client IsNot Nothing Then

                    ImportAccountPayable.MediaClientCode = Product.ClientCode
                    ImportAccountPayable.MediaClientName = Product.Client.Name

                End If

                If Product.Division IsNot Nothing Then

                    ImportAccountPayable.MediaDivisionCode = Product.DivisionCode
                    ImportAccountPayable.MediaDivisionName = Product.Division.Name

                End If

                If AdvantageFramework.Database.Procedures.Agency.UseAPAccountOnImport(DbContext) AndAlso Product.Office IsNot Nothing Then

                    ImportAccountPayable.GLAccount = Product.Office.AccountsPayableGLACode
                    ImportAccountPayable.OfficeCode = Product.OfficeCode

                End If

            End If

        End Sub
        Private Sub SetAccountsPayableRadioDetailFromLegacyOrder(ByVal OrderNumber As Integer, ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim RadioOrderLegacy As AdvantageFramework.Database.Entities.RadioOrderLegacy = Nothing

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                RadioOrderLegacy = AdvantageFramework.Database.Procedures.RadioOrderLegacy.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrderLegacy IsNot Nothing Then

                    ImportAccountPayable.Month = BroadcastMonth
                    ImportAccountPayable.Year = BroadcastYear

                    ImportAccountPayable.MediaClientCode = RadioOrderLegacy.ClientCode
                    ImportAccountPayable.MediaDivisionCode = RadioOrderLegacy.DivisionCode
                    ImportAccountPayable.MediaProductCode = RadioOrderLegacy.ProductCode
                    ImportAccountPayable.LineDate = RadioOrderLegacy.FlightFrom

                    SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                End If

            End Using

        End Sub
        Private Sub SetAccountsPayableTVDetailFromLegacyOrder(ByVal OrderNumber As Integer, ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim TVOrderLegacy As AdvantageFramework.Database.Entities.TVOrderLegacy = Nothing

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TVOrderLegacy = AdvantageFramework.Database.Procedures.TVOrderLegacy.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrderLegacy IsNot Nothing Then

                    ImportAccountPayable.Month = BroadcastMonth
                    ImportAccountPayable.Year = BroadcastYear

                    ImportAccountPayable.MediaClientCode = TVOrderLegacy.ClientCode
                    ImportAccountPayable.MediaDivisionCode = TVOrderLegacy.DivisionCode
                    ImportAccountPayable.MediaProductCode = TVOrderLegacy.ProductCode
                    ImportAccountPayable.LineDate = TVOrderLegacy.FlightFrom

                    SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                End If

            End Using

        End Sub
        Private Sub SetAccountsPayableMediaOrderIDAndOrderLineID(ByRef ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            'objects
            Dim BroadcastImportCrossReference As AdvantageFramework.Database.Entities.BroadcastImportCrossReference = Nothing
            Dim PrintImportCrossReference As AdvantageFramework.Database.Entities.PrintImportCrossReference = Nothing
            Dim MediaTypeList As Generic.List(Of String) = Nothing
            Dim RadioOrder As Database.Entities.RadioOrder = Nothing
            Dim RadioOrderLegacy As Database.Entities.RadioOrderLegacy = Nothing
            Dim TVOrder As Database.Entities.TVOrder = Nothing
            Dim TVOrderLegacy As Database.Entities.TVOrderLegacy = Nothing
            Dim InternetOrder As Database.Entities.InternetOrder = Nothing
            Dim Magazine As Database.Views.Magazine = Nothing
            Dim NewspaperHeader As Database.Views.NewspaperHeader = Nothing
            Dim OutOfHomeOrder As Database.Entities.OutOfHomeOrder = Nothing

            If (ImportAccountPayable.MediaType = "R" OrElse ImportAccountPayable.MediaType = "T") AndAlso ImportAccountPayable.OrderNumber.HasValue AndAlso ImportAccountPayable.OrderLineNumber.HasValue Then

                MediaTypeList = New Generic.List(Of String)

                If ImportAccountPayable.MediaType = "R" Then

                    MediaTypeList.AddRange({"R", "RA"})

                ElseIf ImportAccountPayable.MediaType = "T" Then

                    MediaTypeList.AddRange({"T", "TV", "CA"})

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom(DbContext,
                        ImportAccountPayable.OrderNumber, ImportAccountPayable.OrderLineNumber, MediaTypeList, ImportAccountPayable.SourceCode)

                    If BroadcastImportCrossReference IsNot Nothing Then

                        ImportAccountPayable.OrderID = BroadcastImportCrossReference.ImportOrderNumber
                        ImportAccountPayable.OrderLineID = BroadcastImportCrossReference.ImportLineNumber

                        If ImportAccountPayable.MediaType = "R" Then

                            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                            If RadioOrder IsNot Nothing Then

                                ImportAccountPayable.SalesClassCode = RadioOrder.MediaTypeCode

                            Else

                                RadioOrderLegacy = AdvantageFramework.Database.Procedures.RadioOrderLegacy.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                If RadioOrderLegacy IsNot Nothing Then

                                    ImportAccountPayable.SalesClassCode = RadioOrderLegacy.MediaType

                                End If

                            End If

                        ElseIf ImportAccountPayable.MediaType = "T" Then

                            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                            If TVOrder IsNot Nothing Then

                                ImportAccountPayable.SalesClassCode = TVOrder.MediaTypeCode

                            Else

                                TVOrderLegacy = AdvantageFramework.Database.Procedures.TVOrderLegacy.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                If TVOrderLegacy IsNot Nothing Then

                                    ImportAccountPayable.SalesClassCode = TVOrderLegacy.MediaType

                                End If

                            End If

                        End If

                    End If

                End Using

            ElseIf ImportAccountPayable.MediaType = "I" OrElse ImportAccountPayable.MediaType = "M" OrElse ImportAccountPayable.MediaType = "N" OrElse ImportAccountPayable.MediaType = "O" Then

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    PrintImportCrossReference = AdvantageFramework.Database.Procedures.PrintImportCrossReference.LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom(DataContext,
                        ImportAccountPayable.OrderNumber, ImportAccountPayable.OrderLineNumber, ImportAccountPayable.MediaType, ImportAccountPayable.SourceCode)

                    If PrintImportCrossReference IsNot Nothing Then

                        ImportAccountPayable.OrderID = PrintImportCrossReference.ImportOrderNumber
                        ImportAccountPayable.OrderLineID = PrintImportCrossReference.ImportLineNumber

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Select Case ImportAccountPayable.MediaType

                                Case "I"

                                    InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                    If InternetOrder IsNot Nothing Then

                                        ImportAccountPayable.SalesClassCode = InternetOrder.MediaTypeCode

                                    End If

                                Case "M"

                                    Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                    If Magazine IsNot Nothing Then

                                        ImportAccountPayable.SalesClassCode = Magazine.MediaTypeCode

                                    End If

                                Case "N"

                                    NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                    If NewspaperHeader IsNot Nothing Then

                                        ImportAccountPayable.SalesClassCode = NewspaperHeader.MediaType

                                    End If

                                Case "O"

                                    OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, ImportAccountPayable.OrderNumber)

                                    If OutOfHomeOrder IsNot Nothing Then

                                        ImportAccountPayable.SalesClassCode = OutOfHomeOrder.MediaTypeCode

                                    End If

                            End Select

                        End Using

                    End If

                End Using

            End If

        End Sub
        Private Sub SetAccountsPayableMediaOrderNumber(ByVal OrderNumber As Integer, ByVal RowHandle As Integer, Optional ByVal LineNumber As Short = -1,
                                                       Optional ByVal MonthName As String = Nothing, Optional ByVal Year As Nullable(Of Short) = Nothing)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim TVOrderDetailList As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim RadioOrderDetailList As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim InternetOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderDetail) = Nothing
            Dim MagazineDetails As Generic.List(Of AdvantageFramework.Database.Views.MagazineDetail) = Nothing
            Dim NewspaperDetails As Generic.List(Of AdvantageFramework.Database.Views.NewspaperDetail) = Nothing
            Dim OutOfHomeOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeOrderDetail) = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim MonthList As Generic.List(Of String) = Nothing
            Dim YearList As Generic.List(Of Short) = Nothing

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            If ImportAccountPayable IsNot Nothing Then

                ImportAccountPayable.OrderNumber = OrderNumber

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Select Case ImportAccountPayable.MediaType

                        Case "R"

                            ImportAccountPayableMedia = DirectCast(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                            RadioOrderDetailList = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, OrderNumber).ToList

                            If RadioOrderDetailList.Count = 0 Then

                                ImportAccountPayableMedia.IsLegacyBroadcastOrder = True

                                If MonthName IsNot Nothing AndAlso Year IsNot Nothing Then

                                    SetAccountsPayableRadioDetailFromLegacyOrder(OrderNumber, MonthName, Year, RowHandle)

                                    ImportAccountPayableMedia.PreviouslyPostedNetAmount =
                                            (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext)
                                             Where Entity.OrderNumber = OrderNumber AndAlso
                                                       Entity.BroadcastMonth = MonthName AndAlso
                                                       Entity.BroadcastYear = Year AndAlso
                                                   (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                             Select Entity).Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                                    ImportAccountPayableMedia.OrderNetAmount =
                                            AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.GetLegacyOrderNetAmount(OrderNumber, ImportAccountPayable.Month, ImportAccountPayable.Year, DbContext)

                                End If

                            ElseIf RadioOrderDetailList.Count = 1 Then

                                ImportAccountPayableMedia.IsLegacyBroadcastOrder = False

                                ImportAccountPayable.OrderLineNumber = RadioOrderDetailList(0).LineNumber

                                SetAccountsPayableRadioOrderLineNumber(ImportAccountPayable.OrderLineNumber, RowHandle)

                            ElseIf LineNumber <> -1 Then

                                ImportAccountPayable.OrderLineNumber = LineNumber

                                SetAccountsPayableRadioOrderLineNumber(ImportAccountPayable.OrderLineNumber, RowHandle)

                            End If

                        Case "T"

                            ImportAccountPayableMedia = DirectCast(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                            TVOrderDetailList = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, OrderNumber).ToList

                            If TVOrderDetailList.Count = 0 Then

                                ImportAccountPayableMedia.IsLegacyBroadcastOrder = True

                                If MonthName IsNot Nothing AndAlso Year IsNot Nothing Then

                                    SetAccountsPayableTVDetailFromLegacyOrder(OrderNumber, MonthName, Year, RowHandle)

                                    ImportAccountPayableMedia.PreviouslyPostedNetAmount =
                                            (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext)
                                             Where Entity.OrderNumber = OrderNumber AndAlso
                                                       Entity.BroadcastMonth = MonthName AndAlso
                                                       Entity.BroadcastYear = Year AndAlso
                                                   (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                             Select Entity).Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                                    ImportAccountPayableMedia.OrderNetAmount =
                                            AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.GetLegacyOrderNetAmount(OrderNumber, ImportAccountPayable.Month, ImportAccountPayable.Year, DbContext)

                                End If

                            ElseIf TVOrderDetailList.Count = 1 Then

                                ImportAccountPayableMedia.IsLegacyBroadcastOrder = False

                                ImportAccountPayable.OrderLineNumber = TVOrderDetailList(0).LineNumber

                                SetAccountsPayableTVOrderLineNumber(ImportAccountPayable.OrderLineNumber, RowHandle)

                            ElseIf LineNumber <> -1 Then

                                ImportAccountPayable.OrderLineNumber = LineNumber

                                SetAccountsPayableTVOrderLineNumber(ImportAccountPayable.OrderLineNumber, RowHandle)

                            End If

                        Case "I"

                            If LineNumber <> -1 Then

                                SetAccountsPayableInternetOrderLineNumber(LineNumber, RowHandle)

                            Else

                                InternetOrderDetails = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber).ToList

                                If InternetOrderDetails.Count = 1 Then

                                    SetAccountsPayableInternetOrderLineNumber(InternetOrderDetails(0).LineNumber, RowHandle)

                                End If

                            End If

                        Case "M"

                            If LineNumber <> -1 Then

                                SetAccountsPayableMagazineOrderLineNumber(LineNumber, RowHandle)

                            Else

                                MagazineDetails = AdvantageFramework.Database.Procedures.MagazineDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber).ToList

                                If MagazineDetails.Count = 1 Then

                                    SetAccountsPayableMagazineOrderLineNumber(MagazineDetails(0).LineNumber, RowHandle)

                                End If

                            End If

                        Case "N"

                            If LineNumber <> -1 Then

                                SetAccountsPayableNewspaperOrderLineNumber(LineNumber, RowHandle)

                            Else

                                NewspaperDetails = AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber).ToList

                                If NewspaperDetails.Count = 1 Then

                                    SetAccountsPayableNewspaperOrderLineNumber(NewspaperDetails(0).LineNumber, RowHandle)

                                End If

                            End If

                        Case "O"

                            If LineNumber <> -1 Then

                                SetAccountsPayableOutOfHomeOrderLineNumber(LineNumber, RowHandle)

                            Else

                                OutOfHomeOrderDetails = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber).ToList

                                If OutOfHomeOrderDetails.Count = 1 Then

                                    SetAccountsPayableOutOfHomeOrderLineNumber(OutOfHomeOrderDetails(0).LineNumber, RowHandle)

                                End If

                            End If

                    End Select

                End Using

                SetAccountsPayableMediaOrderIDAndOrderLineID(ImportAccountPayable)

                ImportAccountPayable.Modified = True

                DataGridViewForm_ImportedItems.CurrentView.RefreshRow(RowHandle)

            End If

        End Sub
        Private Sub SetAccountsPayableMagazineOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail = Nothing
            Dim Magazine As AdvantageFramework.Database.Views.Magazine = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.NetAmount + Entity.BleedNetAmount + Entity.PositionNetAmount + Entity.PremiumNetAmount + Entity.ColorNetAmount + Entity.DiscountLN + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    MagazineDetail = AdvantageFramework.Database.Procedures.MagazineDetailView.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If MagazineDetail IsNot Nothing Then

                        OrderNetAmount = MagazineDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                            MagazineDetail.DiscountAmount.GetValueOrDefault(0) +
                                            MagazineDetail.NetCharge.GetValueOrDefault(0) +
                                            MagazineDetail.VendorTax.GetValueOrDefault(0)

                        ImportAccountPayable.LineDate = MagazineDetail.InsertDate

                        If IsDate(MagazineDetail.InsertDate) Then

                            ImportAccountPayable.Month = MonthName(MagazineDetail.InsertDate.Value.Month, True).ToUpper
                            ImportAccountPayable.Year = MagazineDetail.InsertDate.Value.Year

                        End If

                        Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, MagazineDetail.OrderNumber)

                        If Magazine IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = Magazine.ClientCode
                            ImportAccountPayable.MediaDivisionCode = Magazine.DivisionCode
                            ImportAccountPayable.MediaProductCode = Magazine.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Sub SetAccountsPayableNewspaperOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail = Nothing
            Dim NewspaperHeader As AdvantageFramework.Database.Views.NewspaperHeader = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountLN + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    NewspaperDetail = AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If NewspaperDetail IsNot Nothing Then

                        OrderNetAmount = NewspaperDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                            NewspaperDetail.DiscountAmount.GetValueOrDefault(0) +
                                            NewspaperDetail.NetCharge.GetValueOrDefault(0) +
                                            NewspaperDetail.VendorTax.GetValueOrDefault(0)

                        ImportAccountPayable.LineDate = NewspaperDetail.InsertDate

                        If IsDate(NewspaperDetail.InsertDate) Then

                            ImportAccountPayable.Month = MonthName(NewspaperDetail.InsertDate.Value.Month, True).ToUpper
                            ImportAccountPayable.Year = NewspaperDetail.InsertDate.Value.Year

                        End If

                        NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, NewspaperDetail.OrderNumber)

                        If NewspaperHeader IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = NewspaperHeader.ClientCode
                            ImportAccountPayable.MediaDivisionCode = NewspaperHeader.DivisionCode
                            ImportAccountPayable.MediaProductCode = NewspaperHeader.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Sub SetAccountsPayableOutOfHomeOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If OutOfHomeOrderDetail IsNot Nothing Then

                        OrderNetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                            OutOfHomeOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                            OutOfHomeOrderDetail.NetCharge.GetValueOrDefault(0) +
                                            OutOfHomeOrderDetail.VendorTax.GetValueOrDefault(0)

                        ImportAccountPayable.LineDate = OutOfHomeOrderDetail.PostDate

                        If IsDate(OutOfHomeOrderDetail.PostDate) Then

                            ImportAccountPayable.Month = MonthName(OutOfHomeOrderDetail.PostDate.Value.Month, True).ToUpper
                            ImportAccountPayable.Year = OutOfHomeOrderDetail.PostDate.Value.Year

                        End If

                        OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OutOfHomeOrderDetail.OutofHomeOrderNumber)

                        If OutOfHomeOrder IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = OutOfHomeOrder.ClientCode
                            ImportAccountPayable.MediaDivisionCode = OutOfHomeOrder.DivisionCode
                            ImportAccountPayable.MediaProductCode = OutOfHomeOrder.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Sub SetAccountsPayableRadioOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If RadioOrderDetail IsNot Nothing Then

                        ImportAccountPayable.MediaIsCommissionOnly = (RadioOrderDetail.BillTypeFlag = 1)

                        If ImportAccountPayable.MediaIsCommissionOnly Then

                            OrderNetAmount = 0
                            ImportAccountPayable.MediaGrossRate = 0
                            ImportAccountPayable.MediaNetRate = 0
                            ImportAccountPayable.MediaNetAmount = 0
                            ImportAccountPayable.MediaVendorTax = 0
                            ImportAccountPayable.MediaNetCharge = 0
                            ImportAccountPayable.MediaMarkupPercent = 0
                            ImportAccountPayable.MediaAddAmount = 0

                        Else

                            OrderNetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                             RadioOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                             RadioOrderDetail.NetCharge.GetValueOrDefault(0) +
                                             RadioOrderDetail.NonResaleAmount.GetValueOrDefault(0)

                        End If

                        ImportAccountPayable.LineDate = RadioOrderDetail.StartDate
                        ImportAccountPayable.Month = MonthName(RadioOrderDetail.MonthNumber, True).ToUpper
                        ImportAccountPayable.Year = RadioOrderDetail.YearNumber

                        RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, RadioOrderDetail.RadioOrderNumber)

                        If RadioOrder IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = RadioOrder.ClientCode
                            ImportAccountPayable.MediaDivisionCode = RadioOrder.DivisionCode
                            ImportAccountPayable.MediaProductCode = RadioOrder.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Sub SetAccountsPayableTVOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If TVOrderDetail IsNot Nothing Then

                        ImportAccountPayable.MediaIsCommissionOnly = (TVOrderDetail.BillTypeFlag = 1)

                        If ImportAccountPayable.MediaIsCommissionOnly Then

                            OrderNetAmount = 0
                            ImportAccountPayable.MediaGrossRate = 0
                            ImportAccountPayable.MediaNetRate = 0
                            ImportAccountPayable.MediaNetAmount = 0
                            ImportAccountPayable.MediaVendorTax = 0
                            ImportAccountPayable.MediaNetCharge = 0
                            ImportAccountPayable.MediaMarkupPercent = 0
                            ImportAccountPayable.MediaAddAmount = 0

                        Else

                            OrderNetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                             TVOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                             TVOrderDetail.NetCharges.GetValueOrDefault(0) +
                                             TVOrderDetail.NonResaleAmount.GetValueOrDefault(0)

                        End If

                        ImportAccountPayable.LineDate = TVOrderDetail.StartDate
                        ImportAccountPayable.Month = MonthName(TVOrderDetail.MonthNumber, True).ToUpper
                        ImportAccountPayable.Year = TVOrderDetail.YearNumber

                        TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, TVOrderDetail.TVOrderNumber)

                        If TVOrder IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = TVOrder.ClientCode
                            ImportAccountPayable.MediaDivisionCode = TVOrder.DivisionCode
                            ImportAccountPayable.MediaProductCode = TVOrder.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Sub SetAccountsPayableInternetOrderLineNumber(ByVal OrderLineNumber As Integer, ByVal RowHandle As Integer)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim PreviouslyPosted As Decimal = 0
            Dim OrderNetAmount As Decimal = 0

            ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(RowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            ImportAccountPayable.OrderLineNumber = OrderLineNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ImportAccountPayable.OrderNumber.GetValueOrDefault(0) <> 0 Then

                    PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByOrderNumberAndLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber) _
                            .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                    InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayable.OrderNumber, OrderLineNumber)

                    If InternetOrderDetail IsNot Nothing Then

                        OrderNetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                            InternetOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                            InternetOrderDetail.NetCharge.GetValueOrDefault(0) +
                                            InternetOrderDetail.NonResalesAmount.GetValueOrDefault(0)

                        ImportAccountPayable.LineDate = InternetOrderDetail.StartDate

                        If IsDate(InternetOrderDetail.StartDate) Then

                            ImportAccountPayable.Month = MonthName(InternetOrderDetail.StartDate.Value.Month, True).ToUpper
                            ImportAccountPayable.Year = InternetOrderDetail.StartDate.Value.Year

                        End If

                        InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, InternetOrderDetail.InternetOrderOrderNumber)

                        If InternetOrder IsNot Nothing Then

                            ImportAccountPayable.MediaClientCode = InternetOrder.ClientCode
                            ImportAccountPayable.MediaDivisionCode = InternetOrder.DivisionCode
                            ImportAccountPayable.MediaProductCode = InternetOrder.ProductCode

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    End If

                End If

            End Using

            ImportAccountPayable.MediaPreviouslyPostedNetAmount = PreviouslyPosted
            ImportAccountPayable.OrderNetAmount = OrderNetAmount

        End Sub
        Private Function IsImportOrderReady(ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) As Boolean

            Dim IsReady As Boolean = True

            For Each Key In ImportAccountPayable.ErrorHashtable.Keys

                If Key.ToString <> "OrderLineNumber" AndAlso Key.ToString <> "OrderNumber" AndAlso Key.ToString <> "OrderID" AndAlso Key.ToString <> "OrderLineID" Then

                    IsReady = False

                    Exit For

                End If

            Next

            IsImportOrderReady = IsReady

        End Function
        Private Sub ButtonItemMediaOrder_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaOrder_Create.Click

            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim IncludeNonBlankOrderIDs As Boolean = False
            Dim IsOkay As Boolean = True
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            ImportAccountPayableList = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) _
                                            .OrderBy(Function(IAP) IAP.MediaType).ThenBy(Function(IAP) IAP.SalesClassCode).ThenBy(Function(IAP) IAP.VendorCode) _
                                            .ThenBy(Function(IAP) IAP.MediaClientCode).ThenBy(Function(IAP) IAP.MediaDivisionCode).ThenBy(Function(IAP) IAP.MediaProductCode).ToList

            If ImportAccountPayableList.Where(Function(Entity) Entity.SalesClassCode Is Nothing OrElse Entity.SalesClassCode = "").Any Then

                AdvantageFramework.WinForm.MessageBox.Show("All selected rows must have a Sales Class Code.")

            Else

                If AdvantageFramework.WinForm.MessageBox.Show("Include rows with an Order ID that does not yet exist in Advantage?", WinForm.MessageBox.MessageBoxButtons.YesNo, , Windows.Forms.MessageBoxIcon.Question) = WinForm.MessageBox.DialogResults.Yes Then

                    IncludeNonBlankOrderIDs = True

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ImportAccountPayable In ImportAccountPayableList

                        If ImportAccountPayable.ImportAccountPayableMediaID <> 0 AndAlso
                                ((ImportAccountPayable.OrderID Is Nothing OrElse (IncludeNonBlankOrderIDs AndAlso ImportAccountPayable.OrderID IsNot Nothing)) AndAlso ImportAccountPayable.OrderNumber Is Nothing) OrElse
                                (ImportAccountPayable.OrderID IsNot Nothing AndAlso ImportAccountPayable.OrderLineID IsNot Nothing AndAlso ImportAccountPayable.OrderNumber IsNot Nothing AndAlso ImportAccountPayable.OrderLineNumber IsNot Nothing) Then

                            If IsImportOrderReady(ImportAccountPayable) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Please correct all errors not related to 'Order Number' or 'Order Line Number' in selected rows first.")

                                IsOkay = False

                                Exit For

                            Else

                                ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder(DbContext, ImportAccountPayable)

                                If ImportAccountPayable.OrderID IsNot Nothing AndAlso ImportAccountPayable.OrderNumber IsNot Nothing AndAlso ImportAccountPayable.OrderLineNumber IsNot Nothing Then

                                    SetExistingOrderDetails(DbContext, ImportAccountPayable.OrderNumber.Value, ImportAccountPayable.OrderLineNumber.Value, ImportOrder)

                                End If

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.NetCharge.GetValueOrDefault(0) <> 0 Then

                                    ImportOrderList.Add(ImportOrder)

                                End If

                            End If

                        End If

                    Next

                End Using

                If IsOkay AndAlso ImportOrderList.Count > 0 Then

                    If AdvantageFramework.Importing.Presentation.ImportCreateOrderDialog.ShowFormDialog(ImportOrderList, AdvantageFramework.MediaPlanning.Methods.CreateOrderOptions.Default) = Windows.Forms.DialogResult.OK Then

                        ImportAccountPayableList = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ToList

                        For Each ImportOrder In ImportOrderList

                            ImportAccountPayableList.SingleOrDefault(Function(IAP) IAP.ImportAccountPayableMediaID = ImportOrder.ImportAccountPayableMediaID).OrderID = ImportOrder.OrderID

                            ImportAccountPayableList.SingleOrDefault(Function(IAP) IAP.ImportAccountPayableMediaID = ImportOrder.ImportAccountPayableMediaID).OrderLineID = ImportOrder.LineNumber

                        Next

                        DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                        DataGridViewForm_ImportedItems.SetUserEntryChanged()

                    End If

                ElseIf IsOkay Then

                    AdvantageFramework.WinForm.MessageBox.Show("No Orders to create.")

                End If

            End If

        End Sub
        Private Sub DataGridView_ColumnValueChanged_AccountsPayable(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean)

            'objects
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim PipePosition As Integer = 0
            Dim PipePosition2 As Integer = 0
            Dim OrderNumber As Integer = 0
            Dim OrderLineNumber As Short = 0
            Dim MonthName As String = Nothing
            Dim Year As Nullable(Of Short) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing

            Try

                ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportAccountPayable = Nothing
            End Try

            If ImportAccountPayable IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString AndAlso Not ViaCellValueChangedEvent Then

                        If e.Value IsNot Nothing Then

                            If ViaCellValueChangedEvent AndAlso IsNumeric(e.Value) Then

                                If e.Value <> 0 AndAlso e.Value <> ImportAccountPayable.OrderNumber Then

                                    SetAccountsPayableMediaOrderNumber(e.Value, e.RowHandle)

                                End If

                            Else

                                PipePosition = InStr(1, e.Value, "|")

                                If PipePosition > 0 Then

                                    OrderNumber = Strings.Left(e.Value, PipePosition - 1)

                                    PipePosition2 = InStr(PipePosition + 1, e.Value, "|")

                                    If PipePosition2 > 0 Then

                                        MonthName = Strings.Mid(e.Value, PipePosition + 1, PipePosition2 - PipePosition - 1)
                                        Year = Strings.Mid(e.Value, PipePosition2 + 1)

                                        SetAccountsPayableMediaOrderNumber(OrderNumber, e.RowHandle, , MonthName, Year)
                                        ImportAccountPayable.OrderLineNumber = Nothing

                                    Else

                                        OrderLineNumber = Strings.Mid(e.Value, PipePosition + 1)
                                        SetAccountsPayableMediaOrderNumber(OrderNumber, e.RowHandle, OrderLineNumber)

                                    End If

                                Else

                                    SetAccountsPayableMediaOrderNumber(e.Value, e.RowHandle)

                                End If

                            End If

                        Else

                            ImportAccountPayable.OrderNumber = Nothing
                            ImportAccountPayable.OrderLineNumber = Nothing
                            'ImportAccountPayable.LineDate = Nothing
                            'ImportAccountPayable.Month = Nothing
                            'ImportAccountPayable.Year = Nothing
                            ImportAccountPayable.OrderNetAmount = Nothing

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString AndAlso Not ViaCellValueChangedEvent Then

                        If e.Value IsNot Nothing Then

                            Select Case ImportAccountPayable.MediaType

                                Case "I"

                                    SetAccountsPayableInternetOrderLineNumber(e.Value, e.RowHandle)

                                Case "M"

                                    SetAccountsPayableMagazineOrderLineNumber(e.Value, e.RowHandle)

                                Case "N"

                                    SetAccountsPayableNewspaperOrderLineNumber(e.Value, e.RowHandle)

                                Case "O"

                                    SetAccountsPayableOutOfHomeOrderLineNumber(e.Value, e.RowHandle)

                                Case "R"

                                    SetAccountsPayableRadioOrderLineNumber(e.Value, e.RowHandle)

                                Case "T"

                                    SetAccountsPayableTVOrderLineNumber(e.Value, e.RowHandle)

                            End Select

                            SetAccountsPayableMediaOrderIDAndOrderLineID(ImportAccountPayable)

                        Else

                            ImportAccountPayable.LineDate = Nothing
                            ImportAccountPayable.Month = Nothing
                            ImportAccountPayable.Year = Nothing
                            ImportAccountPayable.OrderNetAmount = Nothing

                        End If

                    End If

                    If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse
                            e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString Then

                        'ImportAccountPayable.HasMultipleMatchingOrders = False
                        'ImportAccountPayable.DbContext = DbContext
                        'ImportAccountPayable.ValidateEntity(True)

                        DataGridViewForm_ImportedItems.CurrentView.RefreshRow(e.RowHandle)

                        CalculateBottomLineAmounts()

                    End If

                End Using

                ImportAccountPayable.Modified = True

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridView_RowCellClickEvent_AccountsPayable(ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs)

            If e.Button = Windows.Forms.MouseButtons.Right Then

                If ShowMapping() Then

                    ButtonItemActions_Mapping.Enabled = True

                    ContextMenuStripForm_MappingMenu.Show(MousePosition)

                Else

                    ButtonItemActions_Mapping.Enabled = False

                End If

            End If

        End Sub
        Private Sub DataGridView_RowCellStyle_AccountsPayable(ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)

            If DataGridViewForm_ImportedItems.CurrentView.IsRowSelected(e.RowHandle) = False Then

                If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLComment.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString Then

                    e.Appearance.BackColor = Drawing.Color.Bisque

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaIsCommissionOnly.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Month.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Year.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaQuantity.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaGrossRate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetRate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaVendorTax.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetCharge.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaMarkupPercent.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaAddAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaPreviouslyPostedNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetVariance.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientName.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionName.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductName.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaBottomLineOrderNet.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaBottomLineVariance.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.NetworkID.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaCampaignID.ToString Then

                    If DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.HasMultipleMatchingOrders.ToString) = True Then

                        e.Appearance.BackColor = Drawing.Color.PaleGoldenrod

                    Else

                        e.Appearance.BackColor = Drawing.Color.Beige

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobQuantity.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobVendorTax.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PreviouslyPostedNetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONetAmount.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONetVariance.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComment.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientName.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionName.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductCode.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductName.ToString Then

                    e.Appearance.BackColor = Drawing.Color.Azure

                End If

            End If

        End Sub
        Private Sub DataGridView_CellValueChanged_AccountsPayable(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim VendorCode As String = Nothing
            Dim ImportID As Integer = 0
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim JobProcessNumberList As Generic.List(Of Short) = Nothing
            Dim IsAPLimitByOfficeEnabled As Boolean = False

            Try

                ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportAccountPayable = Nothing
            End Try

            If ImportAccountPayable IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString Then

                        If Not String.IsNullOrEmpty(e.Value) Then

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, e.Value)

                            If Vendor IsNot Nothing Then

                                ImportAccountPayable.VendorName = Vendor.Name

                                If AdvantageFramework.Database.Procedures.Agency.UseAPAccountOnImport(DbContext) = False Then

                                    ImportAccountPayable.GLAccount = Vendor.DefaultAPAccount

                                    GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultAPAccount)

                                    If GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                        ImportAccountPayable.OfficeCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                    End If

                                End If

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceNumber.ToString Then

                        If Not String.IsNullOrEmpty(e.Value) Then

                            VendorCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString)

                            ImportID = GetAccountsPayableListByBatchAndVendorAndInvoice(DbContext, VendorCode, e.Value) _
                                            .Where(Function(IAP) IAP.VendorCode = ImportAccountPayable.VendorCode AndAlso
                                                                 IAP.InvoiceNumber = DirectCast(e.Value, String) AndAlso
                                                                 IAP.BatchName = ImportAccountPayable.BatchName AndAlso
                                                                 IAP.ID <> ImportAccountPayable.ID).Select(Function(IAP) IAP.ID).FirstOrDefault

                            If ImportID <> 0 Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Invoice number exists for this vendor in this batch, continue to merge selected invoice into existing invoice?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                    Try

                                        DbContext.Database.Connection.Open()

                                        DbTransaction = DbContext.Database.BeginTransaction

                                        If ImportAccountPayable.ImportAccountPayableGLID <> 0 Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IMP_AP_GL SET IMPORT_ID={0} WHERE IMPORT_ID={1}", ImportID, ImportAccountPayable.ID))

                                        ElseIf ImportAccountPayable.ImportAccountPayableJobID <> 0 Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IMP_AP_JOB SET IMPORT_ID={0} WHERE IMPORT_ID={1}", ImportID, ImportAccountPayable.ID))

                                        ElseIf ImportAccountPayable.ImportAccountPayableMediaID <> 0 Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IMP_AP_MEDIA SET IMPORT_ID={0} WHERE IMPORT_ID={1}", ImportID, ImportAccountPayable.ID))

                                        End If

                                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.IMP_AP_ERROR SET IMPORT_ID={0} WHERE IMPORT_ID={1}", ImportID, ImportAccountPayable.ID))
                                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_AP_HEADER WHERE IMPORT_ID={0}", ImportAccountPayable.ID))

                                        DbTransaction.Commit()

                                        LoadSelectedBatch()

                                    Catch ex As Exception
                                        DbTransaction.Rollback()
                                        AdvantageFramework.WinForm.MessageBox.Show("Failed trying to save data to the database. Please contact software support.")
                                    Finally

                                        If DbContext.Database.Connection.State = ConnectionState.Open Then

                                            DbContext.Database.Connection.Close()

                                        End If

                                    End Try

                                Else

                                    LoadSelectedBatch()

                                End If

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString Then

                        If e.Value <> "R" AndAlso e.Value <> "T" Then

                            ImportAccountPayable.DaypartID = Nothing

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.MediaClientName = Nothing
                            ImportAccountPayable.MediaDivisionCode = Nothing
                            ImportAccountPayable.MediaDivisionName = Nothing
                            ImportAccountPayable.MediaProductCode = Nothing
                            ImportAccountPayable.MediaProductName = Nothing
                            ImportAccountPayable.MediaCampaignID = Nothing

                        Else

                            SetAccountsPayableMediaDivisionProduct(DbContext, e.Value, ImportAccountPayable)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.MediaProductCode = Nothing
                            ImportAccountPayable.MediaProductName = Nothing

                        Else

                            SetAccountsPayableMediaProduct(DbContext, e.Value, ImportAccountPayable)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.MediaProductName = Nothing

                        Else

                            SetAccountsPayableMediaDataDependentOnProduct(DbContext, ImportAccountPayable)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString Then

                        If e.Value IsNot Nothing AndAlso ImportAccountPayable.PONumber IsNot Nothing Then

                            JobProcessNumberList = New Generic.List(Of Short)
                            JobProcessNumberList.AddRange({1, 3, 4, 8, 9, 13})

                            PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, ImportAccountPayable.PONumber, e.Value)

                            IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

                            If PurchaseOrderDetail IsNot Nothing Then

                                If ((IsAPLimitByOfficeEnabled AndAlso PurchaseOrderDetail.Job.OfficeCode <> ImportAccountPayable.OfficeCode)) Then

                                    ImportAccountPayable.POLine = Nothing

                                    AdvantageFramework.WinForm.MessageBox.Show("Entry is not allowed due to office mismatch.")

                                ElseIf JobProcessNumberList.Contains(PurchaseOrderDetail.JobComponent.JobProcessNumber.GetValueOrDefault(0)) = False Then

                                    ImportAccountPayable.POLine = Nothing

                                    AdvantageFramework.WinForm.MessageBox.Show("Entry is not allowed due to jobs process control.")

                                Else

                                    SetAccountsPayableJobDetails(DbContext, PurchaseOrderDetail, ImportAccountPayable)

                                End If

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.JobClientName = Nothing
                            ImportAccountPayable.JobDivisionCode = Nothing
                            ImportAccountPayable.JobDivisionName = Nothing
                            ImportAccountPayable.JobProductCode = Nothing
                            ImportAccountPayable.JobProductName = Nothing

                        Else

                            SetAccountsPayableJobDivisionProduct(DbContext, e.Value, ImportAccountPayable)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.JobProductCode = Nothing
                            ImportAccountPayable.JobProductName = Nothing

                        Else

                            SetAccountsPayableJobProduct(DbContext, e.Value, ImportAccountPayable)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductCode.ToString Then

                        If String.IsNullOrEmpty(e.Value) Then

                            ImportAccountPayable.JobProductName = Nothing

                        Else

                            ImportAccountPayable.JobProductName = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportAccountPayable.JobClientCode, ImportAccountPayable.JobDivisionCode, e.Value).Name

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString Then

                        If e.Value Is Nothing Then

                            ImportAccountPayable.JobComponentNumber = Nothing

                        Else

                            SetAccountsPayableJob(DbContext, e.Value, e.RowHandle)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString Then

                        If e.Value IsNot Nothing Then

                            SetAccountsPayableJobDetails(DbContext, e.RowHandle)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString Then

                        If e.Value IsNot Nothing Then

                            SetAccountsPayableJobDetails(DbContext, e.RowHandle)

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString Then

                        If e.Value IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Agency.UseAPAccountOnImport(DbContext) = False Then

                                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportAccountPayable.VendorCode)

                                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, e.Value)

                                If Vendor IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeSegment(DbContext, Vendor.DefaultAPAccount, GeneralLedgerOfficeCrossReference.Code)

                                    If GeneralLedgerAccount IsNot Nothing Then

                                        ImportAccountPayable.GLAccount = GeneralLedgerAccount.Code

                                    End If

                                End If

                            Else

                                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, e.Value)

                                If Office IsNot Nothing Then

                                    ImportAccountPayable.GLAccount = Office.AccountsPayableGLACode

                                End If

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString Then

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                        If GeneralLedgerAccount IsNot Nothing Then

                            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)

                                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    ImportAccountPayable.GLOfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                                End If

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                        If GeneralLedgerAccount IsNot Nothing Then

                            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)

                                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    ImportAccountPayable.JobOfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                                End If

                            End If

                        End If

                    End If

                    'If e.Column.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.IsOnHold.ToString AndAlso
                    '        e.Column.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString AndAlso
                    '        e.Column.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString Then

                    '    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    '    ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)() _
                    '                                                    .Where(Function(Entity) Entity.ID = ImportAccountPayable.ID).ToList

                    '    ValidateAccountsPayableMatchingInvoices(DbContext, ImportAccountPayableList)

                    'End If

                End Using

                ImportAccountPayable.Modified = True

                DataGridViewForm_ImportedItems.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub DataGridView_CellValueChanging_AccountsPayable(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.IsOnHold.ToString Then

                Try

                    ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ImportAccountPayable = Nothing
                End Try

                If ImportAccountPayable IsNot Nothing Then

                    Try

                        ImportAccountPayable.IsOnHold = e.Value

                    Catch ex As Exception

                    End Try

                    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)() _
                                                                    .Where(Function(Entity) Entity.VendorCode = ImportAccountPayable.VendorCode AndAlso
                                                                                            Entity.InvoiceNumber = ImportAccountPayable.InvoiceNumber).ToList

                    For Each IAP In ImportAccountPayableList

                        IAP.IsOnHold = ImportAccountPayable.IsOnHold

                    Next

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub DataGridView_ShowingEditor_AccountsPayable(ByVal e As ComponentModel.CancelEventArgs)

            Dim MappingEnabled As Boolean = False

            If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorName.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientName.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientName.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionName.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionName.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductName.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductName.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString Then

                MappingEnabled = ShowMapping()

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString Then

                If _APLockGLAccountCode Then

                    e.Cancel = True

                Else

                    MappingEnabled = ShowMapping()

                End If

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString Then

                If DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableGLID <> 0 Then

                    MappingEnabled = ShowMapping()

                Else

                    e.Cancel = True

                End If

            ElseIf DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableGLID = 0 AndAlso
                    (DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLComment.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString) Then

                e.Cancel = True

            ElseIf DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableGLID <> 0 AndAlso
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComment.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNetAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobQuantity.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobVendorTax.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                If DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableJobID = 0 OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString Then

                    e.Cancel = True

                ElseIf DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).IsNonBillable.GetValueOrDefault(0) = 0 AndAlso
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaAddAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaMarkupPercent.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetCharge.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaQuantity.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaGrossRate.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetRate.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaVendorTax.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Month.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Year.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaPreviouslyPostedNetAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetAmount.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetVariance.ToString OrElse
                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaCampaignID.ToString Then

                If DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableMediaID = 0 OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Month.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Year.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaPreviouslyPostedNetAmount.ToString OrElse
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetAmount.ToString Then

                    e.Cancel = True

                ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString AndAlso
                        DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).OrderID IsNot Nothing Then

                    e.Cancel = True

                ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString AndAlso
                        (DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaType = "T" OrElse
                        DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaType = "R") AndAlso
                        DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaOrderNumberIsBroadcastLegacy = True Then

                    e.Cancel = True

                ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                    MappingEnabled = ShowMapping()

                ElseIf DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaIsCommissionOnly Then

                    If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaGrossRate.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetRate.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaVendorTax.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetCharge.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaMarkupPercent.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaAddAmount.ToString Then

                        e.Cancel = True

                    End If

                End If

            End If

            ButtonItemActions_Mapping.Enabled = MappingEnabled

        End Sub
        Private Sub DataGridView_ShownEditor_AccountsPayable()

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim OfficeCode As String = Nothing
            Dim AllowContinue As Boolean = True
            Dim AllowVendorNotOnOrder As Boolean = False
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim IsCustomNonClientOnlyImportTemplate As Boolean = False
            Dim IsValid As Boolean = False
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If TypeOf DataGridViewForm_ImportedItems.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_ImportedItems.CurrentView.ActiveEditor

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportAccountPayable = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                    ImportAccountPayable.DbContext = DbContext

                    ImportAccountPayable.ValidateEntityProperty(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString, IsValid, ImportAccountPayable.OfficeCode)

                    If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString Then

                        BindingSource = New System.Windows.Forms.BindingSource

                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Session))

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    End If

                    If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) AndAlso
                            (DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString AndAlso
                             DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString) Then

                        OfficeCode = ImportAccountPayable.OfficeCode

                        If Not IsValid Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select an office.")
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn = DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString)
                            AllowContinue = False

                        End If

                    ElseIf Not IsValid AndAlso DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an office.")
                        DataGridViewForm_ImportedItems.CurrentView.FocusedColumn = DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString)
                        AllowContinue = False

                    End If

                    If AllowContinue Then

                        If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString Then

                            AllowVendorNotOnOrder = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(DbContext)

                            BindingSource = New System.Windows.Forms.BindingSource

                            Select Case ImportAccountPayable.MediaType

                                Case "I"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                            ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                            Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)

                                Case "M"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                            ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                            Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)

                                Case "N"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                             ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                             Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)

                                Case "O"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                             ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                             Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)

                                Case "R"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                         ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                         ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate)

                                Case "T"

                                    BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                      ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                      ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate)

                                Case Else

                                    DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End Select

                            GridLookUpEdit.Properties.ValueMember = "ID"
                            GridLookUpEdit.Properties.DataSource = BindingSource

                            If AllowVendorNotOnOrder Then

                                GridLookUpEdit.Properties.View.ActiveFilterString = "VendorCode = '" & ImportAccountPayable.VendorCode & "'"

                            ElseIf GridLookUpEdit.Properties.View.Columns("VendorCode") IsNot Nothing Then

                                GridLookUpEdit.Properties.View.Columns("VendorCode").Visible = False

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString Then

                            If ImportAccountPayable.OrderNumber IsNot Nothing Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                Select Case ImportAccountPayable.MediaType

                                    Case "I"

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, ImportAccountPayable.OrderNumber))

                                    Case "M"

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.MagazineDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, ImportAccountPayable.OrderNumber))

                                    Case "N"

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, ImportAccountPayable.OrderNumber))

                                    Case "O"

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, ImportAccountPayable.OrderNumber))

                                    Case "R"

                                        RadioOrderDetails = New Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail)

                                        RadioOrderDetails.AddRange(AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayable.OrderNumber, ImportAccountPayable.Month, ImportAccountPayable.Year).ToList)

                                        If ImportAccountPayable.LineDate.HasValue AndAlso MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper <> ImportAccountPayable.Month Then

                                            RadioOrderDetails.AddRange(AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayable.OrderNumber, MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper, ImportAccountPayable.LineDate.Value.Year).ToList)

                                        End If

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(RadioOrderDetails)

                                    Case "T"

                                        TVOrderDetails = New Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail)

                                        TVOrderDetails.AddRange(AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayable.OrderNumber, ImportAccountPayable.Month, ImportAccountPayable.Year).ToList)

                                        If ImportAccountPayable.LineDate.HasValue AndAlso MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper <> ImportAccountPayable.Month Then

                                            TVOrderDetails.AddRange(AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, ImportAccountPayable.OrderNumber, MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper, ImportAccountPayable.LineDate.Value.Year).ToList)

                                        End If

                                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(TVOrderDetails)

                                End Select

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource

                            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                BindingSource.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

                            End Using

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString Then

                            If Not String.IsNullOrEmpty(ImportAccountPayable.MediaClientCode) Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                Where Entity.ClientCode = ImportAccountPayable.MediaClientCode
                                                                Select Entity).ToList

                                End Using

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString Then

                            If Not String.IsNullOrEmpty(ImportAccountPayable.MediaDivisionCode) Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                Where Entity.ClientCode = ImportAccountPayable.MediaClientCode AndAlso
                                                                      Entity.DivisionCode = ImportAccountPayable.MediaDivisionCode
                                                                Select Entity).ToList

                                End Using

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaCampaignID.ToString Then

                            If Not String.IsNullOrEmpty(ImportAccountPayable.MediaClientCode) Then

                                If String.IsNullOrEmpty(ImportAccountPayable.MediaDivisionCode) = False Then

                                    DivisionCode = ImportAccountPayable.MediaDivisionCode

                                End If

                                If String.IsNullOrEmpty(ImportAccountPayable.MediaProductCode) = False Then

                                    ProductCode = ImportAccountPayable.MediaProductCode

                                End If

                                BindingSource = New System.Windows.Forms.BindingSource

                                BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode).ToList
                                                            Select New With {.ID = Entity.ID,
                                                                             .Code = Entity.Code,
                                                                             .Name = Entity.Name,
                                                                             .CodeName = Entity.Code & " - " & Entity.Name}).ToList

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString Then

                            If ImportAccountPayable.MediaType IsNot Nothing Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, ImportAccountPayable.MediaType))

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString Then

                            If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OfficeCode)

                                If Office IsNot Nothing Then

                                    GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Office.Code)

                                    If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                        GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code

                                    End If

                                End If

                            End If

                            BindingSource = New System.Windows.Forms.BindingSource
                            BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAccountPayableGeneralLedgerDatasource(DbContext, GeneralLedgerOfficeCrossReferenceCode, Me.Session)

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString Then

                            If ImportAccountPayable.PONumber IsNot Nothing Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                BindingSource.DataSource = AdvantageFramework.AccountPayable.GetPurchaseOrderLineNumbers(DbContext, ImportAccountPayable.PONumber)

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource

                            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                BindingSource.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

                            End Using

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString Then

                            If Not String.IsNullOrEmpty(ImportAccountPayable.JobClientCode) Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                Where Entity.ClientCode = ImportAccountPayable.JobClientCode
                                                                Select Entity).ToList

                                End Using

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductCode.ToString Then

                            If Not String.IsNullOrEmpty(ImportAccountPayable.JobClientCode) AndAlso Not String.IsNullOrEmpty(ImportAccountPayable.MediaDivisionCode) Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                Where Entity.ClientCode = ImportAccountPayable.JobClientCode AndAlso
                                                                      Entity.DivisionCode = ImportAccountPayable.JobDivisionCode
                                                                Select Entity).ToList

                                End Using

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            Else

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource

                            BindingSource.DataSource = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, OfficeCode, ImportAccountPayable.JobClientCode, ImportAccountPayable.JobDivisionCode, ImportAccountPayable.JobProductCode)

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString Then

                            If ImportAccountPayable.JobNumber Is Nothing Then

                                DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                            Else

                                BindingSource = New System.Windows.Forms.BindingSource

                                BindingSource.DataSource = AdvantageFramework.AccountPayable.GetJobComponentsByJob(DbContext, ImportAccountPayable.JobNumber)

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                            If ImportAccountPayable.IsNonBillable.GetValueOrDefault(0) = 1 Then

                                BindingSource = New System.Windows.Forms.BindingSource

                                BindingSource.DataSource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, Session)

                                GridLookUpEdit.Properties.DataSource = BindingSource

                            End If

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource

                            BindingSource.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "V")

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource

                            ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.GetImportAccountPayableHeader.ImportTemplateID)

                            If ImportTemplate IsNot Nothing AndAlso ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsPayable_Custom Then

                                IsCustomNonClientOnlyImportTemplate = True

                            End If

                            BindingSource.DataSource = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Session, OfficeCode, If(OfficeCode Is Nothing, Nothing, ImportAccountPayable.GLOfficeCode), IsCustomNonClientOnlyImportTemplate, ImportAccountPayable.GLOfficeCode)

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemAccountPayable_ShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemAccountPayable_ShowAll.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    Me.ShowWaitForm()

                    AccountsPayableSaveDataGridViewLayout()

                    Try

                        LoadSelectedBatch()

                    Catch ex As Exception

                    End Try

                    Try

                        AccountsPayableLoadGridLayout(True)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemAccountPayable_UpdateDescription_Click(sender As Object, e As EventArgs) Handles ButtonItemAccountPayable_UpdateDescription.Click

            Dim APImportDefaultInvoiceDescription As String = Nothing

            If AdvantageFramework.Importing.Presentation.InvoiceDescriptionSelectionDialog.ShowFormDialog(APImportDefaultInvoiceDescription) = Windows.Forms.DialogResult.OK Then

                Save(True, True)

                AdvantageFramework.Importing.UpdateAccountsPayableBatchInvoiceDescription(Me.Session, ComboBoxSettings_Batch.SelectedValue, APImportDefaultInvoiceDescription.ToString)

                Try

                    LoadSelectedBatch()

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemAccountPayable_WriteOff_Click(sender As Object, e As EventArgs) Handles ButtonItemAccountPayable_WriteOff.Click

            'objects
            Dim ImportAccountPayables As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim SelectedGLAccounts As IEnumerable = Nothing
            Dim GLACode As String = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GLOfficeCode As String = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            If CheckForUnsavedChanges() Then

                ImportAccountPayables = DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().ToList

                ParameterDictionary = New Dictionary(Of String, Object)

                ParameterDictionary("AccountPayableOfficeCode") = ImportAccountPayables.FirstOrDefault.OfficeCode
                ParameterDictionary("NonClientOfficeCode") = ImportAccountPayables.FirstOrDefault.MediaOfficeCode

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.GeneralLedgerAccount, True, True, SelectedGLAccounts, False, "Select GL Account for Media Order Variance Write Off", ParameterDictionary:=ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                    If SelectedGLAccounts IsNot Nothing Then

                        Try

                            GLACode = (From Entity In SelectedGLAccounts
                                       Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            GLACode = Nothing
                        End Try

                        If GLACode IsNot Nothing Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode)

                                If GeneralLedgerAccount IsNot Nothing Then

                                    If GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                                        GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)

                                        If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                            GLOfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                                        End If

                                    End If

                                End If

                                Try

                                    DbContext.Database.Connection.Open()

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    For Each ImportAccountPayable In ImportAccountPayables

                                        ImportAccountPayableMedia = AdvantageFramework.Database.Procedures.ImportAccountPayableMedia.LoadByID(DbContext, ImportAccountPayable.ImportAccountPayableMediaID)

                                        If ImportAccountPayableMedia IsNot Nothing Then

                                            ImportAccountPayableMedia.MediaNetAmount = ImportAccountPayableMedia.MediaNetAmount + ImportAccountPayable.OrderNetVariance

                                            If AdvantageFramework.Database.Procedures.ImportAccountPayableMedia.Update(DbContext, ImportAccountPayableMedia) = False Then

                                                Throw New Exception("Failed trying to update ImportAccountPayableMedia.")

                                            End If

                                            ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
                                            ImportAccountPayableGL.DbContext = DbContext

                                            ImportAccountPayableGL.ImportAccountPayableID = ImportAccountPayable.ID
                                            ImportAccountPayableGL.GLACode = GLACode
                                            ImportAccountPayableGL.GLNetAmount = -ImportAccountPayable.OrderNetVariance
                                            ImportAccountPayableGL.GLComment = "Order " & ImportAccountPayable.OrderNumber & " Line " & ImportAccountPayable.OrderLineNumber & " adjustment"
                                            ImportAccountPayableGL.OfficeCodeDetail = GLOfficeCode

                                            If AdvantageFramework.Database.Procedures.ImportAccountPayableGL.Insert(DbContext, ImportAccountPayableGL) = False Then

                                                Throw New Exception("Failed trying to save ImportAccountPayableGL.")

                                            End If

                                        End If

                                    Next

                                    DbTransaction.Commit()

                                Catch ex As Exception
                                    DbTransaction.Rollback()
                                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                    ErrorMessage += vbCrLf & ex.Message
                                End Try

                                If ErrorMessage IsNot Nothing Then

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                End If

                            End Using

                            AdvantageFramework.Importing.ValidateAccountsPayableBatch(Me.Session, ComboBoxSettings_Batch.SelectedValue)

                            LoadSelectedBatch()

                        End If

                    End If

                Else

                    LoadSelectedBatch()

                End If

            End If

        End Sub
        Private Sub MappingToolStripMenuItem_ClickEvent_AccountsPayable(e As EventArgs)

            PerformAccountsPayableMapping()

        End Sub
        Private Sub ValidateAccountsPayableMatchingInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable))

            Dim ImportIDList As Generic.List(Of Integer) = Nothing

            ImportIDList = New Generic.List(Of Integer)()
            ImportIDList.AddRange(ImportAccountPayableList.Select(Function(Header) Header.ID).Distinct)

            For Each IAP In ImportAccountPayableList

                If ImportIDList.Contains(IAP.ID) Then

                    IAP.DbContext = DbContext
                    IAP.Modified = True
                    IAP.ValidateEntity(True)

                    ImportIDList.Remove(IAP.ID)

                Else

                    IAP.RefreshErrorHashtable()

                End If

            Next

            Me.DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        End Sub
        Private Sub PerformAccountsPayableMapping()

            Dim RowCellValue As String = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim SelectedVendors As IEnumerable = Nothing
            Dim VendorCode As String = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim VendorName As String = Nothing
            Dim HeaderIDList As Generic.List(Of Integer) = Nothing
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing
            Dim SelectedGLAccounts As IEnumerable = Nothing
            Dim GLACode As String = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim SelectedClients As IEnumerable = Nothing
            Dim ClientCode As String = Nothing

            RowCellValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, DataGridViewForm_ImportedItems.CurrentView.FocusedColumn)

            If RowCellValue IsNot Nothing AndAlso RowCellValue <> "" Then

                ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorName.ToString Then

                        RowCellValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, DataGridViewForm_ImportedItems.CurrentView.FocusedColumn)

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.GetHeader.ImportTemplateID)

                        Try

                            VendorCrossReference = (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID)
                                                    Where Entity.SourceVendorCode = RowCellValue
                                                    Select Entity).SingleOrDefault

                        Catch ex As Exception
                            VendorCrossReference = Nothing
                        End Try

                        If VendorCrossReference Is Nothing Then

                            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Vendor, True, True, SelectedVendors, False) = Windows.Forms.DialogResult.OK Then

                                Try

                                    VendorCode = (From Entity In SelectedVendors
                                                  Select Entity.Code).FirstOrDefault

                                Catch ex As Exception
                                    VendorCode = Nothing
                                End Try

                                If VendorCode IsNot Nothing Then

                                    VendorCrossReference = New AdvantageFramework.Database.Entities.VendorCrossReference
                                    VendorCrossReference.DbContext = DbContext

                                    VendorCrossReference.VendorCode = VendorCode
                                    VendorCrossReference.SourceVendorCode = RowCellValue
                                    VendorCrossReference.RecordSourceID = ImportTemplate.RecordSourceID

                                    If AdvantageFramework.Database.Procedures.VendorCrossReference.Insert(DbContext, VendorCrossReference) Then

                                        Try

                                            Me.ShowWaitForm("Processing...")

                                            BindingSource = DataGridViewForm_ImportedItems.DataSource
                                            ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().ToList()

                                            VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode).Name

                                            HeaderIDList = New Generic.List(Of Integer)

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If (DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString AndAlso
                                                        ImportAccountPayable.VendorCode = RowCellValue) OrElse
                                                        (DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorName.ToString AndAlso
                                                        ImportAccountPayable.VendorName = RowCellValue) Then

                                                    ImportAccountPayable.VendorCode = VendorCode
                                                    ImportAccountPayable.VendorName = VendorName

                                                    If HeaderIDList.Contains(ImportAccountPayable.ID) = False Then

                                                        HeaderIDList.Add(ImportAccountPayable.ID)

                                                    End If

                                                End If

                                            Next

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If HeaderIDList.Contains(ImportAccountPayable.ID) Then

                                                    ImportAccountPayable.DbContext = DbContext
                                                    ImportAccountPayable.ValidateEntity(True)
                                                    HeaderIDList.Remove(ImportAccountPayable.ID)

                                                Else

                                                    ImportAccountPayable.RefreshErrorHashtable()

                                                End If

                                            Next

                                        Catch ex As Exception

                                        Finally

                                            DataGridViewForm_ImportedItems.CurrentView.RefreshData()
                                            DataGridViewForm_ImportedItems.CurrentView.RefreshEditor(True)

                                            DataGridViewForm_ImportedItems.SetUserEntryChanged()

                                            Me.CloseWaitForm()

                                        End Try

                                    End If

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(RowCellValue & " is already mapped to " & VendorCrossReference.VendorCode & ".")

                        End If

                    ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString OrElse
                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.GetHeader.ImportTemplateID)

                        RowCellValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, DataGridViewForm_ImportedItems.CurrentView.FocusedColumn)

                        Try

                            GeneralLedgerCrossReference = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID)
                                                           Where Entity.SourceGLACode = RowCellValue
                                                           Select Entity).SingleOrDefault

                        Catch ex As Exception
                            GeneralLedgerCrossReference = Nothing
                        End Try

                        If GeneralLedgerCrossReference Is Nothing Then

                            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.GeneralLedgerAccount, True, True, SelectedGLAccounts, False) = Windows.Forms.DialogResult.OK Then

                                Try

                                    GLACode = (From Entity In SelectedGLAccounts
                                               Select Entity.Code).FirstOrDefault

                                Catch ex As Exception
                                    GLACode = Nothing
                                End Try

                                If GLACode IsNot Nothing Then

                                    GeneralLedgerCrossReference = New AdvantageFramework.Database.Entities.GeneralLedgerCrossReference
                                    GeneralLedgerCrossReference.DbContext = DbContext

                                    GeneralLedgerCrossReference.GLACode = GLACode
                                    GeneralLedgerCrossReference.SourceGLACode = RowCellValue
                                    GeneralLedgerCrossReference.RecordSourceID = ImportTemplate.RecordSourceID

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.Insert(DbContext, GeneralLedgerCrossReference) Then

                                        Try

                                            Me.ShowWaitForm("Processing...")

                                            BindingSource = DataGridViewForm_ImportedItems.DataSource
                                            ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().ToList()

                                            HeaderIDList = New Generic.List(Of Integer)

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString Then

                                                    If ImportAccountPayable.GLACode = RowCellValue Then

                                                        ImportAccountPayable.GLACode = GLACode
                                                        ImportAccountPayable.GetImportAccountPayableGL.DbContext = DbContext
                                                        ImportAccountPayable.GetImportAccountPayableGL.ValidateEntity(True)

                                                    End If

                                                ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString Then

                                                    If ImportAccountPayable.GLAccount = RowCellValue Then

                                                        ImportAccountPayable.GLAccount = GLACode

                                                        If HeaderIDList.Contains(ImportAccountPayable.ID) = False Then

                                                            HeaderIDList.Add(ImportAccountPayable.ID)

                                                        End If

                                                    End If

                                                End If

                                            Next

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If HeaderIDList.Contains(ImportAccountPayable.ID) Then

                                                    ImportAccountPayable.DbContext = DbContext
                                                    ImportAccountPayable.ValidateEntity(True)
                                                    HeaderIDList.Remove(ImportAccountPayable.ID)

                                                Else

                                                    ImportAccountPayable.RefreshErrorHashtable()

                                                End If

                                            Next

                                        Catch ex As Exception

                                        Finally

                                            DataGridViewForm_ImportedItems.CurrentView.RefreshData()
                                            DataGridViewForm_ImportedItems.CurrentView.RefreshEditor(True)

                                            DataGridViewForm_ImportedItems.SetUserEntryChanged()

                                            Me.CloseWaitForm()

                                        End Try

                                    End If

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(RowCellValue & " is already mapped to " & GeneralLedgerCrossReference.GLACode & ".")

                        End If

                    ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.GetHeader.ImportTemplateID)

                        RowCellValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, DataGridViewForm_ImportedItems.CurrentView.FocusedColumn)

                        Try

                            ClientCrossReference = (From Entity In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID)
                                                    Where Entity.SourceClientCode = RowCellValue
                                                    Select Entity).SingleOrDefault

                        Catch ex As Exception
                            ClientCrossReference = Nothing
                        End Try

                        If ClientCrossReference Is Nothing Then

                            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Client, True, True, SelectedClients, False) = Windows.Forms.DialogResult.OK Then

                                Try

                                    ClientCode = (From Entity In SelectedClients
                                                  Select Entity.Code).FirstOrDefault

                                Catch ex As Exception
                                    ClientCode = Nothing
                                End Try

                                If ClientCode IsNot Nothing Then

                                    ClientCrossReference = New AdvantageFramework.Database.Entities.ClientCrossReference
                                    ClientCrossReference.DbContext = DbContext

                                    ClientCrossReference.ClientCode = ClientCode
                                    ClientCrossReference.SourceClientCode = RowCellValue
                                    ClientCrossReference.RecordSourceID = ImportTemplate.RecordSourceID

                                    If AdvantageFramework.Database.Procedures.ClientCrossReference.Insert(DbContext, ClientCrossReference) Then

                                        Try

                                            Me.ShowWaitForm("Processing...")

                                            BindingSource = DataGridViewForm_ImportedItems.DataSource
                                            ImportAccountPayableList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)().ToList()

                                            HeaderIDList = New Generic.List(Of Integer)

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                                                    If ImportAccountPayable.MediaClientCode = RowCellValue Then

                                                        ImportAccountPayable.MediaClientCode = ClientCode

                                                        If DbContext.Clients.Where(Function(C) C.Code = ClientCode).Count = 1 Then

                                                            ImportAccountPayable.MediaClientName = DbContext.Clients.Where(Function(C) C.Code = ClientCode).FirstOrDefault.Name

                                                        End If

                                                        ImportAccountPayable.GetImportAccountPayableMedia.DbContext = DbContext
                                                        ImportAccountPayable.GetImportAccountPayableMedia.ValidateEntity(True)

                                                    End If

                                                End If

                                            Next

                                            For Each ImportAccountPayable In ImportAccountPayableList

                                                If HeaderIDList.Contains(ImportAccountPayable.ID) Then

                                                    ImportAccountPayable.DbContext = DbContext
                                                    ImportAccountPayable.ValidateEntity(True)
                                                    HeaderIDList.Remove(ImportAccountPayable.ID)

                                                Else

                                                    ImportAccountPayable.RefreshErrorHashtable()

                                                End If

                                            Next

                                        Catch ex As Exception

                                        Finally

                                            DataGridViewForm_ImportedItems.CurrentView.RefreshData()
                                            DataGridViewForm_ImportedItems.CurrentView.RefreshEditor(True)

                                            DataGridViewForm_ImportedItems.SetUserEntryChanged()

                                            Me.CloseWaitForm()

                                        End Try

                                    End If

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(RowCellValue & " is already mapped to " & ClientCrossReference.ClientCode & ".")

                        End If

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("An empty column cannot be mapped.")

            End If

        End Sub
        Private Function ShowMapping() As Boolean

            Dim RowCellValue As String = Nothing
            Dim Show As Boolean = False
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            RowCellValue = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, DataGridViewForm_ImportedItems.CurrentView.FocusedColumn)

            If RowCellValue IsNot Nothing AndAlso RowCellValue <> "" AndAlso ComboBoxSettings_Batch.HasASelectedValue Then

                Select Case _ImportType

                    Case Methods.ImportType.AccountsPayable

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ImportAccountPayable = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, ComboBoxSettings_Batch.GetSelectedValue).FirstOrDefault

                            If ImportAccountPayable IsNot Nothing Then

                                ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.ImportTemplateID)

                                If ImportTemplate IsNot Nothing AndAlso ImportTemplate.RecordSourceID IsNot Nothing Then

                                    If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString OrElse
                                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse
                                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString OrElse
                                            DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString Then

                                        If DataGridViewForm_ImportedItems.CurrentView.GetColumnError(DataGridViewForm_ImportedItems.CurrentView.FocusedColumn).Contains(" required") = True OrElse
                                                DataGridViewForm_ImportedItems.CurrentView.GetColumnError(DataGridViewForm_ImportedItems.CurrentView.FocusedColumn).Contains(" valid") = True Then

                                            Show = True

                                        End If

                                        'ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorName.ToString Then

                                        '    If DataGridViewForm_ImportedItems.CurrentView.GetColumnError(DataGridViewForm_ImportedItems.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString)).Contains(" required") = True OrElse _
                                        '            DataGridViewForm_ImportedItems.CurrentView.GetColumnError(DataGridViewForm_ImportedItems.Columns(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString)).Contains(" valid") = True Then

                                        '        Show = True

                                        '    End If

                                    End If

                                End If

                            End If

                        End Using

                End Select

            End If

            ShowMapping = Show

        End Function
        Private Sub AccountsPayableSaveAndValidate()

            Save(True, True)

            AdvantageFramework.Importing.ValidateAccountsPayableBatch(Me.Session, ComboBoxSettings_Batch.SelectedValue)

            Try

                LoadSelectedBatch()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub DataGridViewForm_ImportedItems_PopupMenuShowingEvent_AccountsPayable(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In e.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox Then

                            DXMenuItem.Enabled = False

                        ElseIf ButtonItemAccountPayable_ShowAll.Checked = False AndAlso
                                (CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn OrElse
                                 CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization) Then

                            DXMenuItem.Enabled = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub AccountsPayableSaveDataGridViewLayout()

            'objects
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim IsNewAppVar As Boolean = False
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim GridAdvantageColumns As Generic.List(Of AdvantageFramework.Database.Entities.GridAdvantageColumn) = Nothing
            Dim GridAdvantageColumn As AdvantageFramework.Database.Entities.GridAdvantageColumn = Nothing

            If _ImportType = Methods.ImportType.AccountsPayable AndAlso ComboBoxSettings_Batch.HasASelectedValue Then

                ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

                If ImportAccountPayable IsNot Nothing Then

                    AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ImportedItems, AdvantageFramework.Database.Entities.GridAdvantageType.AccountsPayableImport, ImportAccountPayable.GetImportAccountPayableHeader.ImportTemplateID)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.AccountsPayableImport, Session.UserCode, ImportAccountPayable.GetImportAccountPayableHeader.ImportTemplateID)

                        If GridAdvantage IsNot Nothing Then

                            GridAdvantageColumns = AdvantageFramework.Database.Procedures.GridAdvantageColumn.LoadByGridID(DataContext, GridAdvantage.ID).ToList

                            For Each GridColumn In DataGridViewForm_ImportedItems.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(gc) gc.OptionsColumn.ShowInCustomizationForm = True).ToList

                                GridAdvantageColumn = GridAdvantageColumns.Where(Function(gac) gac.FieldName = GridColumn.FieldName).SingleOrDefault

                                If GridAdvantageColumn Is Nothing Then

                                    GridAdvantageColumn = New Database.Entities.GridAdvantageColumn

                                    GridAdvantageColumn.GridID = GridAdvantage.ID
                                    GridAdvantageColumn.FieldName = GridColumn.FieldName
                                    GridAdvantageColumn.Visible = GridColumn.Visible

                                    GridAdvantageColumn.DataContext = DataContext

                                    GridAdvantageColumn.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                                    DataContext.GridAdvantageColumns.InsertOnSubmit(GridAdvantageColumn)

                                Else

                                    GridAdvantageColumn.DataContext = DataContext

                                    GridAdvantageColumn.DatabaseAction = Database.Methods.Action.Updating

                                    GridAdvantageColumn.Visible = GridColumn.Visible

                                End If

                            Next

                            Try

                                DataContext.SubmitChanges()

                            Catch ex As Exception

                            End Try

                        End If

                    End Using

                    AppVar = GetAccountPayableShowAllAppVar(IsNewAppVar)

                    If AppVar IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AppVar.Value = ButtonItemAccountPayable_ShowAll.Checked.ToString

                            If IsNewAppVar Then

                                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                            Else

                                AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub AccountsPayableLoadGridLayout(Optional ByVal IsShowAllChanging As Boolean = False)

            'objects
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim HasMediaLines As Boolean = True
            Dim HasJobLines As Boolean = True
            Dim HasGlLines As Boolean = True
            Dim VisibleIndex As Integer = 0
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim CurrentFormAction As WinForm.Presentation.FormActions = Nothing
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim GridAdvantageColumns As Generic.List(Of AdvantageFramework.Database.Entities.GridAdvantageColumn) = Nothing

            ImportAccountPayableList = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ToList

            If ImportAccountPayableList IsNot Nothing AndAlso ImportAccountPayableList.Count > 0 Then

                HasMediaLines = ImportAccountPayableList.Any(Function(iap) iap.ImportAccountPayableMediaID <> 0)
                HasJobLines = ImportAccountPayableList.Any(Function(iap) iap.ImportAccountPayableJobID <> 0)
                HasGlLines = ImportAccountPayableList.Any(Function(iap) iap.ImportAccountPayableGLID <> 0)

                AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ImportedItems, Database.Entities.GridAdvantageType.AccountsPayableImport, ImportAccountPayableList.FirstOrDefault.GetImportAccountPayableHeader.ImportTemplateID)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.AccountsPayableImport, Session.UserCode, ImportAccountPayableList.FirstOrDefault.GetImportAccountPayableHeader.ImportTemplateID)

                    If GridAdvantage IsNot Nothing Then

                        GridAdvantageColumns = AdvantageFramework.Database.Procedures.GridAdvantageColumn.LoadByGridID(DataContext, GridAdvantage.ID).ToList

                    End If

                End Using

            End If

            If GridAdvantageColumns Is Nothing Then

                GridAdvantageColumns = New List(Of Database.Entities.GridAdvantageColumn)

            End If

            If ButtonItemAccountPayable_ShowAll.Tag Is Nothing Then

                AppVar = GetAccountPayableShowAllAppVar(False)

                If AppVar IsNot Nothing Then

                    CurrentFormAction = Me.FormAction

                    If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.Modifying

                    End If

                    ButtonItemAccountPayable_ShowAll.Checked = CBool(AppVar.Value)

                    Me.FormAction = CurrentFormAction

                Else

                    ButtonItemAccountPayable_ShowAll.Checked = False

                End If

                ButtonItemAccountPayable_ShowAll.Tag = False

            End If

            For Each GridColumn In DataGridViewForm_ImportedItems.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.IsOnHold.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.VendorName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceTotalNet.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceTotalTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.TotalInvoice.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDisbursed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDisbursed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLDisbursed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.TotalDisbursed.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SourceCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxGLAccount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.StateTaxAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxGLAccount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.CityTaxAmount.ToString Then

                    GridColumn.OptionsColumn.ShowInCustomizationForm = True

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaIsCommissionOnly.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Month.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.Year.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaQuantity.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaGrossRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaVendorTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetCharge.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaMarkupPercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaAddAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaPreviouslyPostedNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNetVariance.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaBottomLineOrderNet.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaBottomLineVariance.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.NetworkID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaCampaignID.ToString Then

                    If HasMediaLines OrElse ButtonItemAccountPayable_ShowAll.Checked Then

                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    Else

                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.Visible = False

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONumber.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobQuantity.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNetAmount.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobVendorTax.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PreviouslyPostedNetAmount.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONetAmount.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.PONetVariance.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComment.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientName.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobDivisionName.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobProductName.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                    If HasJobLines OrElse ButtonItemAccountPayable_ShowAll.Checked Then

                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    Else

                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.Visible = False

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLComment.ToString Then

                    If HasGlLines OrElse ButtonItemAccountPayable_ShowAll.Checked Then

                        GridColumn.OptionsColumn.ShowInCustomizationForm = True

                    Else

                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.Visible = False

                    End If

                Else

                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.Visible = False

                End If

                If GridColumn.OptionsColumn.ShowInCustomizationForm Then

                    If GridAdvantageColumns.Any(Function(gac) gac.FieldName = GridColumn.FieldName) Then

                        GridColumn.Visible = GridAdvantageColumns.FirstOrDefault(Function(gac) gac.FieldName = GridColumn.FieldName).Visible

                    Else

                        GridColumn.Visible = True

                    End If

                End If

                If GridColumn.Tag Is Nothing Then

                    GridColumn.Tag = New With {
                        .Caption = GridColumn.Caption,
                        .NoBreaks = GridColumn.Caption.Replace(vbCrLf, " ")
                    }

                End If

                'If GridColumn.Visible Then

                '    GridColumn.VisibleIndex = VisibleIndex
                '    VisibleIndex += 1

                'Else

                '    GridColumn.VisibleIndex = -1

                'End If

            Next

            DataGridViewForm_ImportedItems.CurrentView.AutoSizeColumnHeaderPanel()

        End Sub
        Private Function GetAccountPayableShowAllAppVar(ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.AppVars

            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim AppVarApplication As String = "ImportForm"
            Dim AppVarName As String = ""
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing

            ImportAccountPayable = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            If ImportAccountPayable IsNot Nothing Then

                AppVarName = "ShowAll_" & ImportAccountPayable.GetImportAccountPayableHeader.ImportTemplateID

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, AppVarApplication)
                              Where Item.Name = AppVarName
                              Select Item).SingleOrDefault


                End Using

                If AppVar Is Nothing Then

                    IsNew = True

                    AppVar = New AdvantageFramework.Database.Entities.AppVars

                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Application = AppVarApplication
                    AppVar.Name = AppVarName
                    AppVar.Group = 0
                    AppVar.Type = "Boolean"
                    AppVar.Value = False.ToString

                End If

            End If

            GetAccountPayableShowAllAppVar = AppVar

        End Function
        Private Sub CalculateBottomLineAmounts()

            'objects
            Dim BottomLineOrderNet As Decimal = Nothing
            Dim BottomLineVariance As Decimal = Nothing
            Dim PreviouslyPosted As Decimal = Nothing
            Dim MediaNetDisbursed As Decimal = Nothing
            Dim ImportAccountPayableID As Integer = Nothing
            Dim ImportAccountPayableOrderNumber As Integer = Nothing
            Dim ImportAccountPayableMediaType As String = Nothing
            Dim MonthNumber As Integer = Nothing
            Dim YearNumber As Integer = Nothing
            Dim MonthStr As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ImportAccountPayableOrderGroup In (From Item In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)
                                                            Where Item.OrderNumber.HasValue AndAlso
                                                                  Not String.IsNullOrWhiteSpace(Item.Month) AndAlso
                                                                  Item.Year.HasValue AndAlso
                                                                  (Item.MediaType = "R" OrElse Item.MediaType = "T")
                                                            Group Item By Item.OrderNumber, Item.Month, Item.Year, Item.MediaType Into Group
                                                            Select Group).ToList

                    With ImportAccountPayableOrderGroup.First

                        ImportAccountPayableOrderNumber = .OrderNumber
                        ImportAccountPayableID = .ID
                        ImportAccountPayableMediaType = .MediaType
                        MonthStr = .Month

                        If Not String.IsNullOrWhiteSpace(MonthStr) Then

                            Select Case .Month
                                Case "JAN"
                                    MonthNumber = 1
                                Case "FEB"
                                    MonthNumber = 2
                                Case "MAR"
                                    MonthNumber = 3
                                Case "APR"
                                    MonthNumber = 4
                                Case "MAY"
                                    MonthNumber = 5
                                Case "JUN"
                                    MonthNumber = 6
                                Case "JUL"
                                    MonthNumber = 7
                                Case "AUG"
                                    MonthNumber = 8
                                Case "SEP"
                                    MonthNumber = 9
                                Case "OCT"
                                    MonthNumber = 10
                                Case "NOV"
                                    MonthNumber = 11
                                Case "DEC"
                                    MonthNumber = 12
                                Case Else
                                    MonthNumber = Nothing
                            End Select

                        End If

                        YearNumber = .Year

                    End With

                    BottomLineOrderNet = 0
                    PreviouslyPosted = 0
                    MediaNetDisbursed = 0

                    Try

                        Select Case ImportAccountPayableMediaType

                            Case "T"

                                BottomLineOrderNet = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, ImportAccountPayableOrderNumber) _
                                                     .Where(Function(rod) rod.MonthNumber = MonthNumber AndAlso rod.YearNumber = YearNumber).ToList _
                                                     .Sum(Function(rod) rod.ExtendedNetAmount.GetValueOrDefault(0) + rod.DiscountAmount.GetValueOrDefault(0) + rod.NetCharges.GetValueOrDefault(0) + rod.NonResaleAmount.GetValueOrDefault(0))

                                PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByOrderNumber(DbContext, ImportAccountPayableOrderNumber) _
                                                    .Where(Function(apr) apr.BroadcastMonth = MonthStr AndAlso apr.BroadcastYear = YearNumber).ToList _
                                                   .Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                            Case "R"

                                BottomLineOrderNet = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, ImportAccountPayableOrderNumber) _
                                                     .Where(Function(rod) rod.MonthNumber = MonthNumber AndAlso rod.YearNumber = YearNumber).ToList _
                                                     .Sum(Function(item) item.ExtendedNetAmount.GetValueOrDefault(0) + item.DiscountAmount.GetValueOrDefault(0) + item.NetCharge.GetValueOrDefault(0) + item.NonResaleAmount.GetValueOrDefault(0))

                                PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByOrderNumber(DbContext, ImportAccountPayableOrderNumber) _
                                                    .Where(Function(aptv) aptv.BroadcastMonth = MonthStr AndAlso aptv.BroadcastYear = YearNumber).ToList _
                                                   .Sum(Function(item) item.ExtendedNetAmount.GetValueOrDefault(0) + item.DiscountAmount.GetValueOrDefault(0) + item.NetCharges.GetValueOrDefault(0) + item.VendorTax.GetValueOrDefault(0))

                        End Select

                        MediaNetDisbursed = (From Item In AdvantageFramework.Database.Procedures.ImportAccountPayableMedia.Load(DbContext)
                                             Where Item.ImportAccountPayableID = ImportAccountPayableID AndAlso
                                                   Item.OrderNumber = ImportAccountPayableOrderNumber AndAlso
                                                   Item.MediaType = ImportAccountPayableMediaType AndAlso
                                                   Item.Year = YearNumber AndAlso
                                                   Item.Month = MonthStr
                                             Select Item.MediaNetAmount, Item.MediaVendorTax, Item.MediaNetCharge).ToList _
                                            .Sum(Function(iapm) iapm.MediaNetAmount.GetValueOrDefault(0) + iapm.MediaVendorTax.GetValueOrDefault(0) + iapm.MediaNetCharge.GetValueOrDefault(0))

                    Catch ex As Exception

                    End Try

                    For Each ImportAccountPayable In ImportAccountPayableOrderGroup

                        ImportAccountPayable.MediaBottomLineOrderNet = BottomLineOrderNet
                        ImportAccountPayable.MediaBottomLineVariance = BottomLineOrderNet - PreviouslyPosted - MediaNetDisbursed

                    Next

                Next

            End Using

        End Sub
        Private Sub ButtonItemAccountPayable_ClearOrderLine_Click(sender As Object, e As EventArgs) Handles ButtonItemAccountPayable_ClearOrderLine.Click

            For Each ImportAccountPayable In DataGridViewForm_ImportedItems.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ToList

                ImportAccountPayable.OrderNumber = Nothing
                ImportAccountPayable.OrderLineNumber = Nothing
                ImportAccountPayable.MediaOrderNumberIsBroadcastLegacy = False

            Next

            DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        End Sub
        Private Sub Match(By As Matchby)

            'objects
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim MatchingAccountPayableAvailableRadioOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) = Nothing
            Dim MatchingAccountPayableAvailableTVOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) = Nothing
            Dim ImportAccountPayableErrors As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableError) = Nothing
            Dim AllowVendorNotOnOrder As Boolean = False
            Dim IsAPLimitByOfficeEnabled As Boolean = False
            Dim OfficeCode As String = Nothing
            Dim ImportAccountPayableList As Generic.Dictionary(Of Integer, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim Matched As Boolean = False
            Dim HasValidOrderNumber As Boolean = False
            Dim HasValidLineNumber As Boolean = False
            Dim AccountPayableAvailableTVOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders = Nothing
            Dim AccountPayableAvailableRadioOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders = Nothing
            Dim MatchingAccountPayableAvailableInternetOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders) = Nothing
            Dim AccountPayableAvailableInternetOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders = Nothing
            Dim MatchingAccountPayableAvailableMagazineOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders) = Nothing
            Dim AccountPayableAvailableMagazineOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders = Nothing
            Dim MatchingAccountPayableAvailableNewspaperOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders) = Nothing
            Dim AccountPayableAvailableNewspaperOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders = Nothing
            Dim MatchingAccountPayableAvailableOutOfHomeOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders) = Nothing
            Dim AccountPayableAvailableOutOfHomeOrders As AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders = Nothing
            Dim Month As String = Nothing
            Dim Year As Short? = Nothing
            Dim HierarchyMatchedRadioOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) = Nothing
            Dim HierarchyMatchedTVOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) = Nothing

            DataGridViewForm_ImportedItems.CurrentView.CloseEditorForUpdating()

            ImportAccountPayableList = New Generic.Dictionary(Of Integer, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            For Each Item In DataGridViewForm_ImportedItems.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                ImportAccountPayable = DirectCast(Item.Value, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                If {"R", "T"}.Contains(ImportAccountPayable.MediaType) AndAlso ImportAccountPayable.VendorCode <> "" AndAlso ImportAccountPayable.MediaClientCode <> "" AndAlso ImportAccountPayable.MediaGrossRate.HasValue AndAlso ImportAccountPayable.Month <> "" AndAlso ImportAccountPayable.Year.HasValue AndAlso ImportAccountPayable.MediaType <> "" Then

                    If ImportAccountPayable.MediaType = "T" AndAlso Not String.IsNullOrWhiteSpace(ImportAccountPayable.NetworkID) Then

                        ImportAccountPayableList.Add(Item.Key, ImportAccountPayable)

                    Else

                        ImportAccountPayableList.Add(Item.Key, ImportAccountPayable)

                    End If

                ElseIf {"I", "M", "N", "O"}.Contains(ImportAccountPayable.MediaType) AndAlso ImportAccountPayable.VendorCode <> "" AndAlso ImportAccountPayable.MediaClientCode <> "" AndAlso ImportAccountPayable.LineDate.HasValue Then

                    ImportAccountPayableList.Add(Item.Key, ImportAccountPayable)

                End If

            Next

            If ImportAccountPayableList IsNot Nothing AndAlso ImportAccountPayableList.Count > 0 Then

                Me.ShowWaitForm("Please wait...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

                    For Each Item In ImportAccountPayableList

                        ImportAccountPayableErrors = (From Entity In AdvantageFramework.Database.Procedures.ImportAccountPayableError.LoadByImportAccountPayableID(DbContext, Item.Value.ID)
                                                      Where Entity.PropertyName = "OrderNumber" OrElse
                                                            Entity.PropertyName = "OrderLineNumber"
                                                      Select Entity).ToList

                        ImportAccountPayable = Item.Value

                        Matched = False
                        ProductCode = ""
                        DivisionCode = ""
                        OfficeCode = ""
                        HasValidOrderNumber = False
                        HasValidLineNumber = False

                        ImportAccountPayable.DbContext = DbContext

                        If ImportAccountPayable.OrderNumber.HasValue Then

                            HasValidOrderNumber = Not ImportAccountPayableErrors.Any(Function(err) err.ImportAccountPayableMediaID = ImportAccountPayable.ImportAccountPayableMediaID AndAlso err.PropertyName = "OrderNumber")

                        End If

                        If HasValidOrderNumber AndAlso ImportAccountPayable.OrderLineNumber.HasValue Then

                            HasValidLineNumber = Not ImportAccountPayableErrors.Any(Function(err) err.ImportAccountPayableMediaID = ImportAccountPayable.ImportAccountPayableMediaID AndAlso err.PropertyName = "OrderLineNumber")

                        End If

                        If Not HasValidOrderNumber OrElse Not HasValidLineNumber Then

                            If IsAPLimitByOfficeEnabled Then

                                OfficeCode = ImportAccountPayable.OfficeCode

                            End If

                            If Not String.IsNullOrWhiteSpace(ImportAccountPayable.MediaDivisionCode) Then

                                DivisionCode = ImportAccountPayable.MediaDivisionCode

                                If Not AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ImportAccountPayable.MediaClientCode).Where(Function(d) d.Code = DivisionCode).Any Then

                                    DivisionCode = Nothing

                                End If

                            End If

                            If Not String.IsNullOrWhiteSpace(ImportAccountPayable.MediaProductCode) Then

                                ProductCode = ImportAccountPayable.MediaProductCode

                                If Not String.IsNullOrWhiteSpace(DivisionCode) Then

                                    If Not AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ImportAccountPayable.MediaClientCode, DivisionCode).Where(Function(p) p.Code = ProductCode).Any Then

                                        ProductCode = Nothing

                                    End If

                                ElseIf Not AdvantageFramework.Database.Procedures.Product.LoadByClientCode(DbContext, ImportAccountPayable.MediaClientCode).Where(Function(p) p.Code = ProductCode).Any Then

                                    ProductCode = Nothing

                                End If

                            End If

                            If ImportAccountPayable.MediaType = "R" Then

                                If By = MatchBy.BroadcastMonth Then

                                    MatchingAccountPayableAvailableRadioOrders = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                           ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                           ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, Nothing).ToList

                                ElseIf By = MatchBy.CalendarMonth Then

                                    If ImportAccountPayable.LineDate.HasValue Then

                                        Month = MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper
                                        Year = ImportAccountPayable.LineDate.Value.Year

                                    End If

                                    MatchingAccountPayableAvailableRadioOrders = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                           ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                           Month, Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate).ToList

                                End If

                                If MatchingAccountPayableAvailableRadioOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableRadioOrders.Count > 0 Then

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(Ord) Ord.OrderNumber = ImportAccountPayable.OrderNumber.Value).ToList

                                    End If

                                    If MatchingAccountPayableAvailableRadioOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ((ImportAccountPayable.MediaNetRate.GetValueOrDefault(0).Equals(ImportAccountPayable.MediaGrossRate.GetValueOrDefault(0)) AndAlso ord.NetRate = ImportAccountPayable.MediaNetRate.Value) OrElse
                                                                                                                                                     (ImportAccountPayable.MediaNetRate.GetValueOrDefault(0).Equals(ImportAccountPayable.MediaGrossRate.GetValueOrDefault(0)) = False AndAlso ord.GrossRate = ImportAccountPayable.MediaGrossRate.Value))).ToList

                                        'hierarchy matching starts here
                                        If MatchingAccountPayableAvailableRadioOrders.Count > 1 Then

                                            HierarchyMatchedRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ImportAccountPayable.LineStartDate IsNot Nothing AndAlso
                                                                                                                                         ord.StartDate IsNot Nothing AndAlso
                                                                                                                                         ord.StartDate <= ImportAccountPayable.LineStartDate AndAlso
                                                                                                                                         ImportAccountPayable.LineEndDate IsNot Nothing AndAlso
                                                                                                                                         ord.EndDate IsNot Nothing AndAlso
                                                                                                                                         ord.EndDate >= ImportAccountPayable.LineEndDate AndAlso
                                                                                                                                         ord.Quantity > 0).ToList

                                            If HierarchyMatchedRadioOrders.Count = 0 Then

                                                HierarchyMatchedRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ImportAccountPayable.LineStartDate IsNot Nothing AndAlso
                                                                                                                                             ord.StartDate IsNot Nothing AndAlso
                                                                                                                                             ord.StartDate <= ImportAccountPayable.LineStartDate AndAlso
                                                                                                                                             ImportAccountPayable.LineEndDate IsNot Nothing AndAlso
                                                                                                                                             ord.EndDate IsNot Nothing AndAlso
                                                                                                                                             ord.EndDate >= ImportAccountPayable.LineEndDate).ToList

                                            End If

                                            If HierarchyMatchedRadioOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableRadioOrders = HierarchyMatchedRadioOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableRadioOrders.Count > 1 Then

                                            HierarchyMatchedRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ((ord.Monday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Monday AndAlso
                                                                                                                                        ord.Tuesday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Tuesday AndAlso
                                                                                                                                        ord.Wednesday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Wednesday AndAlso
                                                                                                                                        ord.Thursday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Thursday AndAlso
                                                                                                                                        ord.Friday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Friday AndAlso
                                                                                                                                        ord.Saturday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Saturday AndAlso
                                                                                                                                        ord.Sunday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Sunday) OrElse
                                                                                                                                        (String.IsNullOrWhiteSpace(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.DaysOfWeek) = True))).ToList

                                            If HierarchyMatchedRadioOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableRadioOrders = HierarchyMatchedRadioOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableRadioOrders.Count > 1 Then

                                            HierarchyMatchedRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ord.Length = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Length.GetValueOrDefault(0)).ToList

                                            If HierarchyMatchedRadioOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableRadioOrders = HierarchyMatchedRadioOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableRadioOrders.Count > 1 Then

                                            HierarchyMatchedRadioOrders = MatchingAccountPayableAvailableRadioOrders.Where(Function(ord) ((IsDate(ord.StartTime) AndAlso IsDate(ord.EndTime) AndAlso
                                                                                                                                        (ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime IsNot Nothing AndAlso
                                                                                                                                        ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime IsNot Nothing AndAlso
                                                                                                                                        TimeBetween(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime.Value, CDate(ord.StartTime).TimeOfDay, CDate(ord.EndTime).TimeOfDay) AndAlso
                                                                                                                                        TimeBetween(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime.Value, CDate(ord.StartTime).TimeOfDay, CDate(ord.EndTime).TimeOfDay)) OrElse
                                                                                                                                        (ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime Is Nothing OrElse
                                                                                                                                        ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime Is Nothing) OrElse
                                                                                                                                        (IsDate(ord.StartTime) = False OrElse IsDate(ord.EndTime) = False)))).ToList

                                            If HierarchyMatchedRadioOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableRadioOrders = HierarchyMatchedRadioOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableRadioOrders.Count > 0 AndAlso MatchingAccountPayableAvailableRadioOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableRadioOrders = MatchingAccountPayableAvailableRadioOrders.First

                                            MatchingAccountPayableAvailableRadioOrders.Clear()

                                            MatchingAccountPayableAvailableRadioOrders.Add(AccountPayableAvailableRadioOrders)

                                        End If

                                    End If

                                    If MatchingAccountPayableAvailableRadioOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableRadioOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableRadioOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableRadioOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableRadioOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            ElseIf ImportAccountPayable.MediaType = "T" Then

                                If By = MatchBy.BroadcastMonth Then

                                    MatchingAccountPayableAvailableTVOrders = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                     ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                     ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, Nothing).ToList

                                ElseIf By = MatchBy.CalendarMonth Then

                                    If ImportAccountPayable.LineDate.HasValue Then

                                        Month = MonthName(ImportAccountPayable.LineDate.Value.Month, True).ToUpper
                                        Year = ImportAccountPayable.LineDate.Value.Year

                                    End If

                                    MatchingAccountPayableAvailableTVOrders = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                     ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                     Month, Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate).ToList

                                End If

                                If MatchingAccountPayableAvailableTVOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableTVOrders.Count > 0 Then

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ord.OrderNumber = ImportAccountPayable.OrderNumber.Value).ToList

                                    End If

                                    If MatchingAccountPayableAvailableTVOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ((ImportAccountPayable.MediaNetRate.GetValueOrDefault(0).Equals(ImportAccountPayable.MediaGrossRate.GetValueOrDefault(0)) AndAlso ord.NetRate = ImportAccountPayable.MediaNetRate.Value) OrElse
                                                                                                                                               (ImportAccountPayable.MediaNetRate.GetValueOrDefault(0).Equals(ImportAccountPayable.MediaGrossRate.GetValueOrDefault(0)) = False AndAlso ord.GrossRate = ImportAccountPayable.MediaGrossRate.Value)) AndAlso
                                                                                                                                              ord.NetworkID.ToEmptyStringIfNullOrWhiteSpace.ToUpper = ImportAccountPayable.NetworkID.ToEmptyStringIfNullOrWhiteSpace.ToUpper).ToList

                                        'hierarchy matching starts here
                                        If MatchingAccountPayableAvailableTVOrders.Count > 1 Then

                                            HierarchyMatchedTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ImportAccountPayable.LineStartDate IsNot Nothing AndAlso
                                                                                                                                    ord.StartDate IsNot Nothing AndAlso
                                                                                                                                    ord.StartDate <= ImportAccountPayable.LineStartDate AndAlso
                                                                                                                                    ImportAccountPayable.LineEndDate IsNot Nothing AndAlso
                                                                                                                                    ord.EndDate IsNot Nothing AndAlso
                                                                                                                                    ord.EndDate >= ImportAccountPayable.LineEndDate AndAlso
                                                                                                                                    ord.Quantity > 0).ToList

                                            If HierarchyMatchedTVOrders.Count = 0 Then

                                                HierarchyMatchedTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ImportAccountPayable.LineStartDate IsNot Nothing AndAlso
                                                                                                                                    ord.StartDate IsNot Nothing AndAlso
                                                                                                                                    ord.StartDate <= ImportAccountPayable.LineStartDate AndAlso
                                                                                                                                    ImportAccountPayable.LineEndDate IsNot Nothing AndAlso
                                                                                                                                    ord.EndDate IsNot Nothing AndAlso
                                                                                                                                    ord.EndDate >= ImportAccountPayable.LineEndDate).ToList

                                            End If

                                            If HierarchyMatchedTVOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableTVOrders = HierarchyMatchedTVOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableTVOrders.Count > 1 Then

                                            HierarchyMatchedTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ((ord.Monday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Monday AndAlso
                                                                                                                                    ord.Tuesday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Tuesday AndAlso
                                                                                                                                    ord.Wednesday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Wednesday AndAlso
                                                                                                                                    ord.Thursday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Thursday AndAlso
                                                                                                                                    ord.Friday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Friday AndAlso
                                                                                                                                    ord.Saturday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Saturday AndAlso
                                                                                                                                    ord.Sunday = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Sunday) OrElse
                                                                                                                                    (String.IsNullOrWhiteSpace(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.DaysOfWeek) = True))).ToList

                                            If HierarchyMatchedTVOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableTVOrders = HierarchyMatchedTVOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableTVOrders.Count > 1 Then

                                            HierarchyMatchedTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ord.Length = ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.Length.GetValueOrDefault(0)).ToList

                                            If HierarchyMatchedTVOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableTVOrders = HierarchyMatchedTVOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableTVOrders.Count > 1 Then

                                            HierarchyMatchedTVOrders = MatchingAccountPayableAvailableTVOrders.Where(Function(ord) ((IsDate(ord.StartTime) AndAlso IsDate(ord.EndTime) AndAlso
                                                                                                                                                   (ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime IsNot Nothing AndAlso
                                                                                                                                                    ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime IsNot Nothing AndAlso
                                                                                                                                                    TimeBetween(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime.Value, CDate(ord.StartTime).TimeOfDay, CDate(ord.EndTime).TimeOfDay) AndAlso
                                                                                                                                                    TimeBetween(ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime.Value, CDate(ord.StartTime).TimeOfDay, CDate(ord.EndTime).TimeOfDay)) OrElse
                                                                                                                                                    (ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.StartTime Is Nothing OrElse
                                                                                                                                                     ImportAccountPayable.GetImportAccountPayableMedia.GetEntity.EndTime Is Nothing) OrElse
                                                                                                                                                    (IsDate(ord.StartTime) = False OrElse IsDate(ord.EndTime) = False)))).ToList

                                            If HierarchyMatchedTVOrders.Count > 0 Then

                                                MatchingAccountPayableAvailableTVOrders = HierarchyMatchedTVOrders

                                            End If

                                        End If

                                        If MatchingAccountPayableAvailableTVOrders.Count > 0 AndAlso MatchingAccountPayableAvailableTVOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableTVOrders = MatchingAccountPayableAvailableTVOrders.First

                                            MatchingAccountPayableAvailableTVOrders.Clear()

                                            MatchingAccountPayableAvailableTVOrders.Add(AccountPayableAvailableTVOrders)

                                        End If

                                    End If

                                    If MatchingAccountPayableAvailableTVOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableTVOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableTVOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableTVOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableTVOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            ElseIf ImportAccountPayable.MediaType = "I" Then

                                MatchingAccountPayableAvailableInternetOrders = AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                 ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                 Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID).ToList

                                If MatchingAccountPayableAvailableInternetOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableInternetOrders.Count > 0 Then

                                    If MatchingAccountPayableAvailableInternetOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableInternetOrders = MatchingAccountPayableAvailableInternetOrders.Where(Function(ord) ord.InsertDate IsNot Nothing AndAlso
                                                                                                                                                          ImportAccountPayable.LineDate IsNot Nothing AndAlso
                                                                                                                                                          ord.InsertDate.Value = ImportAccountPayable.LineDate.Value).ToList

                                        If MatchingAccountPayableAvailableInternetOrders.Count > 1 AndAlso MatchingAccountPayableAvailableInternetOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableInternetOrders = MatchingAccountPayableAvailableInternetOrders.First

                                            MatchingAccountPayableAvailableInternetOrders.Clear()

                                            MatchingAccountPayableAvailableInternetOrders.Add(AccountPayableAvailableInternetOrders)

                                        ElseIf MatchingAccountPayableAvailableInternetOrders.Count > 1 Then

                                            MatchingAccountPayableAvailableInternetOrders = MatchingAccountPayableAvailableInternetOrders.Where(Function(ord) ImportAccountPayable.LineStartDate IsNot Nothing AndAlso
                                                                                                                                                              ord.InsertDate IsNot Nothing AndAlso
                                                                                                                                                              ord.InsertDate.Value <= ImportAccountPayable.LineStartDate.Value AndAlso
                                                                                                                                                              ImportAccountPayable.LineEndDate IsNot Nothing AndAlso
                                                                                                                                                              ord.EndDate IsNot Nothing AndAlso
                                                                                                                                                              ord.EndDate.Value >= ImportAccountPayable.LineEndDate.Value).ToList

                                            If MatchingAccountPayableAvailableInternetOrders.Count > 0 AndAlso MatchingAccountPayableAvailableInternetOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                                AccountPayableAvailableInternetOrders = MatchingAccountPayableAvailableInternetOrders.First

                                                MatchingAccountPayableAvailableInternetOrders.Clear()

                                                MatchingAccountPayableAvailableInternetOrders.Add(AccountPayableAvailableInternetOrders)

                                            End If

                                        End If

                                    End If

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableInternetOrders = MatchingAccountPayableAvailableInternetOrders.Where(Function(ord) ord.OrderNumber = ImportAccountPayable.OrderNumber).ToList

                                    End If

                                    If MatchingAccountPayableAvailableInternetOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableInternetOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableInternetOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableInternetOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableInternetOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            ElseIf ImportAccountPayable.MediaType = "M" Then

                                MatchingAccountPayableAvailableMagazineOrders = AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                 ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                 Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID).ToList

                                If MatchingAccountPayableAvailableMagazineOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableMagazineOrders.Count > 0 Then

                                    If MatchingAccountPayableAvailableMagazineOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableMagazineOrders = MatchingAccountPayableAvailableMagazineOrders.Where(Function(ord) ord.InsertDate IsNot Nothing AndAlso
                                                                                                                                                          ord.InsertDate.Value.Month = ImportAccountPayable.LineDate.Value.Month AndAlso
                                                                                                                                                          ord.InsertDate.Value.Year = ImportAccountPayable.LineDate.Value.Year).ToList

                                        If MatchingAccountPayableAvailableMagazineOrders.Count > 1 AndAlso MatchingAccountPayableAvailableMagazineOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableMagazineOrders = MatchingAccountPayableAvailableMagazineOrders.First

                                            MatchingAccountPayableAvailableMagazineOrders.Clear()

                                            MatchingAccountPayableAvailableMagazineOrders.Add(AccountPayableAvailableMagazineOrders)

                                        End If

                                    End If

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableMagazineOrders = MatchingAccountPayableAvailableMagazineOrders.Where(Function(ord) ord.OrderNumber = ImportAccountPayable.OrderNumber).ToList

                                    End If

                                    If MatchingAccountPayableAvailableMagazineOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableMagazineOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableMagazineOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableMagazineOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableMagazineOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            ElseIf ImportAccountPayable.MediaType = "N" Then

                                MatchingAccountPayableAvailableNewspaperOrders = AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                 ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                 Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID).ToList

                                If MatchingAccountPayableAvailableNewspaperOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableNewspaperOrders.Count > 0 Then

                                    If MatchingAccountPayableAvailableNewspaperOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableNewspaperOrders = MatchingAccountPayableAvailableNewspaperOrders.Where(Function(ord) ord.InsertDate IsNot Nothing AndAlso
                                                                                                                                                          ord.InsertDate.Value.Month = ImportAccountPayable.LineDate.Value.Month AndAlso
                                                                                                                                                          ord.InsertDate.Value.Year = ImportAccountPayable.LineDate.Value.Year).ToList

                                        If MatchingAccountPayableAvailableNewspaperOrders.Count > 1 AndAlso MatchingAccountPayableAvailableNewspaperOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableNewspaperOrders = MatchingAccountPayableAvailableNewspaperOrders.First

                                            MatchingAccountPayableAvailableNewspaperOrders.Clear()

                                            MatchingAccountPayableAvailableNewspaperOrders.Add(AccountPayableAvailableNewspaperOrders)

                                        End If

                                    End If

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableNewspaperOrders = MatchingAccountPayableAvailableNewspaperOrders.Where(Function(ord) ord.OrderNumber = ImportAccountPayable.OrderNumber).ToList

                                    End If

                                    If MatchingAccountPayableAvailableNewspaperOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableNewspaperOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableNewspaperOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableNewspaperOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableNewspaperOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            ElseIf ImportAccountPayable.MediaType = "O" Then

                                MatchingAccountPayableAvailableOutOfHomeOrders = AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, OfficeCode,
                                                                                                                                 ImportAccountPayable.MediaClientCode, DivisionCode, ProductCode,
                                                                                                                                 Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID).ToList

                                If MatchingAccountPayableAvailableOutOfHomeOrders IsNot Nothing AndAlso MatchingAccountPayableAvailableOutOfHomeOrders.Count > 0 Then

                                    If MatchingAccountPayableAvailableOutOfHomeOrders.Count > 1 Then

                                        MatchingAccountPayableAvailableOutOfHomeOrders = MatchingAccountPayableAvailableOutOfHomeOrders.Where(Function(ord) ord.InsertDate IsNot Nothing AndAlso
                                                                                                                                                          ord.InsertDate.Value.Month = ImportAccountPayable.LineDate.Value.Month AndAlso
                                                                                                                                                          ord.InsertDate.Value.Year = ImportAccountPayable.LineDate.Value.Year).ToList

                                        If MatchingAccountPayableAvailableOutOfHomeOrders.Count > 1 AndAlso MatchingAccountPayableAvailableOutOfHomeOrders.Select(Function(Entity) Entity.OrderNumber).Distinct.Count = 1 Then

                                            AccountPayableAvailableOutOfHomeOrders = MatchingAccountPayableAvailableOutOfHomeOrders.First

                                            MatchingAccountPayableAvailableOutOfHomeOrders.Clear()

                                            MatchingAccountPayableAvailableOutOfHomeOrders.Add(AccountPayableAvailableOutOfHomeOrders)

                                        End If

                                    End If

                                    If HasValidOrderNumber Then

                                        MatchingAccountPayableAvailableOutOfHomeOrders = MatchingAccountPayableAvailableOutOfHomeOrders.Where(Function(ord) ord.OrderNumber = ImportAccountPayable.OrderNumber).ToList

                                    End If

                                    If MatchingAccountPayableAvailableOutOfHomeOrders.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableOutOfHomeOrders.First.OrderNumber, Item.Key, MatchingAccountPayableAvailableOutOfHomeOrders.First.LineNumber)
                                        ImportAccountPayable.HasMultipleMatchingOrders = False

                                    ElseIf MatchingAccountPayableAvailableOutOfHomeOrders.Select(Function(ord) ord.OrderNumber).Distinct.Count = 1 Then

                                        Matched = True
                                        SetAccountsPayableMediaOrderNumber(MatchingAccountPayableAvailableOutOfHomeOrders.First.OrderNumber, Item.Key, -1)
                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    Else

                                        ImportAccountPayable.HasMultipleMatchingOrders = True

                                    End If

                                Else

                                    ImportAccountPayable.HasMultipleMatchingOrders = False

                                End If

                            End If

                            If Matched Then

                                DataGridViewForm_ImportedItems.SetUserEntryChanged()

                                ImportAccountPayable.Modified = True

                            End If

                        End If

                    Next

                    'For Each RowHandle In ImportAccountPayableList.Keys

                    '    ImportAccountPayableList.Item(RowHandle).ValidateEntity(True)

                    '    DataGridViewForm_ImportedItems.CurrentView.RefreshRow(RowHandle)

                    'Next

                End Using

                Me.CloseWaitForm()

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Selected rows must have a Vendor Code, Client Code, Month, Year, Media Type, and Gross Rate (TV/Radio) to match media orders.")

            End If

        End Sub
        Private Function TimeBetween(ByVal ImportTime As TimeSpan, ByVal OrderStart As TimeSpan, ByVal OrderEnd As TimeSpan) As Boolean

            Dim IsBetween As Boolean = False

            If OrderStart < OrderEnd Then

                IsBetween = OrderStart <= ImportTime AndAlso ImportTime <= OrderEnd

            Else

                IsBetween = Not (OrderEnd < ImportTime AndAlso ImportTime < OrderStart)

            End If

            TimeBetween = IsBetween

        End Function

#End Region

#Region "   AccountsReceivable "

        Private Sub DataGridView_CellValueChanged_AccountsReceivable(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim ImportAccountReceivableStaging As AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                ImportAccountReceivableStaging = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportAccountReceivableStaging = Nothing
            End Try

            If ImportAccountReceivableStaging IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ProductCode.ToString Then

                        If Not String.IsNullOrEmpty(e.Value) Then

                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ImportAccountReceivableStaging.ClientCode, ImportAccountReceivableStaging.DivisionCode, e.Value)

                            If Product IsNot Nothing Then

                                ImportAccountReceivableStaging.OfficeCode = Product.OfficeCode

                                DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                            End If

                        End If

                    End If

                End Using

                ImportAccountReceivableStaging.Modified = True

            End If

        End Sub
        Private Sub DataGridView_QueryPopupNeedDatasourceEvent_AccountsReceivable(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim OfficeCode As String = Nothing
            Dim RecordType As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ProductCode.ToString)
                OfficeCode = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.OfficeCode.ToString)

                Select Case FieldName

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeAR.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCity.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCOS.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCounty.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeOffset.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeSales.ToString,
                            AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeState.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session).ToList

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.SalesClassCode.ToString

                        OverrideDefaultDatasource = True

                        RecordType = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.RecordType.ToString)

                        Datasource = AdvantageFramework.AccountReceivable.GetActiveSalesClassesByRecordType(AdvantageFramework.AccountReceivable.GetActiveSalesClasses(DbContext), RecordType).ToList

                End Select

            End Using

        End Sub

#End Region

#Region "   Function "

        Private Sub DataGridView_ShowingEditor_Function(ByVal e As ComponentModel.CancelEventArgs)

            If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.Type.ToString Then

                If DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.ImportFunctionStaging).IsNew = False Then

                    e.Cancel = True

                    DataGridViewForm_ImportedItems.CurrentView.FocusedColumn = DataGridViewForm_ImportedItems.CurrentView.Columns(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.DepartmentTeamCode.ToString)

                End If

            End If

        End Sub

#End Region

#Region "   Digital Results "

        Private Sub DigitalResultsSaveAndValidate()

            Save(True, True)

            Try

                LoadSelectedBatch()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SetDigitalResultsAutoFillDependentProperties(ByVal SelectedItems As IEnumerable)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvantageFramework.DigitalResults.SetDigitalResultsAutoFillDependentProperties(DbContext, SelectedItems)

            End Using

            Me.DataGridViewForm_ImportedItems.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DigitalResultsRefreshValidation(ByVal SelectedItems As IEnumerable)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.DigitalResults.LoadValidationObjects(DbContext, SelectedItems.OfType(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging).ToList)

                End Using

            Catch ex As Exception

            End Try

            DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridView_CellValueChanged_DigitalResults(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim RefreshGrid As Boolean = False

            Try

                ImportDigitalResultsStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                ImportDigitalResultsStaging = Nothing
            End Try

            If ImportDigitalResultsStaging IsNot Nothing Then

                AdvantageFramework.DigitalResults.ProcessCellValueChanged(Me.Session, e.Column.FieldName, e.Value, RefreshGrid, ImportDigitalResultsStaging)

                If RefreshGrid Then

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub DataGridView_QueryPopupNeedDatasourceEvent_DigitalResults(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing

            Try

                ImportDigitalResultsStaging = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportDigitalResultsStaging = Nothing
            End Try

            If ImportDigitalResultsStaging IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.DigitalResults.LoadColumnEditorDatasouce(DbContext, ImportDigitalResultsStaging, FieldName, OverrideDefaultDatasource, Datasource)

                End Using

            End If

        End Sub
        Private Sub DataGridView_ShowingEditor_DigitalResults(ByVal e As ComponentModel.CancelEventArgs)

            'objects
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing

            Try

                ImportDigitalResultsStaging = DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle)

            Catch ex As Exception
                ImportDigitalResultsStaging = Nothing
            End Try

            If ImportDigitalResultsStaging IsNot Nothing Then

                e.Cancel = AdvantageFramework.DigitalResults.ProcessShowingEditor(DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName, ImportDigitalResultsStaging)

            End If

        End Sub
        Private Sub DataGridView_ShownEditor_DigitalResults()

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing

            If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString Then

                If TypeOf DataGridViewForm_ImportedItems.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(DataGridViewForm_ImportedItems.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    If GridLookUpEdit.Properties.View.Columns("ID") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("ID").VisibleIndex = 0
                        GridLookUpEdit.Properties.View.Columns("ID").Visible = True

                    End If

                End If

            ElseIf DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString Then

                ImportDigitalResultsStaging = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

                If ImportDigitalResultsStaging IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ImportDigitalResultsStaging.MediaType) AndAlso TypeOf DataGridViewForm_ImportedItems.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(DataGridViewForm_ImportedItems.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    GridLookUpEdit.Properties.View.ActiveFilterString = "Category = '" & ImportDigitalResultsStaging.MediaType & "'"

                End If

            End If

        End Sub

#End Region

#Region "  Cash Receipts "

        Private Sub CashReceiptAddEntityToList(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt,
                                               ByRef ImportClientCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt))

            Dim ImportClientCashReceiptHeader As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader = Nothing

            ImportClientCashReceiptHeader = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader(DbContext, ImportCashReceipt)

            If ImportClientCashReceiptHeader.ImportClientCashReceiptDetails.Any Then

                For Each ImportClientCashReceiptDetail In ImportClientCashReceiptHeader.ImportClientCashReceiptDetails

                    ImportClientCashReceiptList.Add(New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt(ImportClientCashReceiptHeader, ImportClientCashReceiptDetail))

                Next

            End If

        End Sub
        Private Sub LoadCashReceiptRepositoryItems(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            'Dim InvoiceDate As Date = Nothing

            For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        Select Case GridColumn.FieldName

                            'Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceNumber.ToString

                            '    InvoiceDate = DateAdd(DateInterval.Month, -6, Now)

                            '    SubItemGridLookUpEditControl.DataSource = (From AR In AdvantageFramework.Database.Procedures.AccountReceivable.LoadNonVoidedInvoices(DbContext)
                            '                                               Where AR.InvoiceDate > InvoiceDate
                            '                                               Select AR).ToList.OrderByDescending(Function(AR) AR.InvoiceNumber)

                            Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceSequence.ToString

                                SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivable)

                        End Select

                    End If

                End If

            Next

        End Sub
        Private Sub DataGridView_CellValueChanging_CashReceipts(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ImportClientCashReceipt As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportClientCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) = Nothing

            Try

                ImportClientCashReceipt = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportClientCashReceipt = Nothing
            End Try

            If ImportClientCashReceipt IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.IsOnHold.ToString Then

                    Try

                        ImportClientCashReceipt.IsOnHold = e.Value

                    Catch ex As Exception

                    End Try

                    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    ImportClientCashReceiptList = BindingSource.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)() _
                                                                    .Where(Function(Entity) Entity.CheckNumber = ImportClientCashReceipt.CheckNumber).ToList

                    For Each ICCR In ImportClientCashReceiptList

                        ICCR.IsOnHold = ImportClientCashReceipt.IsOnHold

                    Next

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.IsCleared.ToString Then

                    Try

                        ImportClientCashReceipt.IsCleared = e.Value

                    Catch ex As Exception

                    End Try

                    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    ImportClientCashReceiptList = BindingSource.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)() _
                                                                    .Where(Function(Entity) Entity.CheckNumber = ImportClientCashReceipt.CheckNumber).ToList

                    For Each ICCR In ImportClientCashReceiptList

                        ICCR.IsCleared = ImportClientCashReceipt.IsCleared

                    Next

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                End If

            End If

        End Sub
        'Private Sub DataGridView_ColumnValueChanged_CashReceipts(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean)

        '    'objects
        '    Dim ImportClientCashReceipt As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt = Nothing
        '    Dim PipePosition As Integer = 0
        '    Dim InvoiceNumber As Integer = 0
        '    Dim SequenceNumber As Short = 0
        '    Dim ImportClientCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) = Nothing

        '    If e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceNumber.ToString AndAlso Not ViaCellValueChangedEvent Then

        '        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            Try

        '                ImportClientCashReceipt = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

        '            Catch ex As Exception
        '                ImportClientCashReceipt = Nothing
        '            End Try

        '            If ImportClientCashReceipt IsNot Nothing Then

        '                If e.Value IsNot Nothing Then

        '                    If IsNumeric(e.Value) AndAlso e.Value <> 0 Then

        '                        ImportClientCashReceipt.ARInvoiceNumber = e.Value
        '                        ImportClientCashReceipt.ARInvoiceSequence = 0
        '                        ImportClientCashReceipt.SetClientValues(DbContext)

        '                    Else

        '                        PipePosition = InStr(1, e.Value, "|")

        '                        If PipePosition > 0 Then

        '                            InvoiceNumber = Strings.Left(e.Value, PipePosition - 1)
        '                            SequenceNumber = Strings.Mid(e.Value, PipePosition + 1)

        '                            ImportClientCashReceipt.ARInvoiceNumber = InvoiceNumber
        '                            ImportClientCashReceipt.ARInvoiceSequence = SequenceNumber
        '                            ImportClientCashReceipt.SetClientValues(DbContext)

        '                        End If

        '                    End If

        '                Else

        '                    ImportClientCashReceipt.ARInvoiceNumber = Nothing
        '                    ImportClientCashReceipt.ARInvoiceSequence = Nothing
        '                    ImportClientCashReceipt.ClientCode = Nothing
        '                    ImportClientCashReceipt.ClientName = Nothing

        '                End If

        '                DataGridViewForm_ImportedItems.AddToModifiedRows(e.RowHandle)

        '                ImportClientCashReceiptList = DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt).Where(Function(ICCR) ICCR.CheckNumber = ImportClientCashReceipt.CheckNumber).ToList

        '                For Each ICCR In ImportClientCashReceiptList

        '                    ICCR.DbContext = DbContext

        '                    ICCR.ValidateEntity(True)

        '                Next

        '                DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        '                EnableOrDisableActions()

        '            End If

        '        End Using

        '    End If

        'End Sub
        Private Sub DataGridView_ShownEditor_CashReceipts()

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim ARInvoiceNumber As Nullable(Of Integer) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_ImportedItems.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_ImportedItems.CurrentView.ActiveEditor

                'If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceNumber.ToString Then

                '    GridLookUpEdit.Properties.ValueMember = "InvoiceNumberSequenceNumber"

                '    If GridLookUpEdit.Properties.View.Columns("Type") IsNot Nothing Then

                '        GridLookUpEdit.Properties.View.Columns("Type").Visible = False

                '    End If

                '    If GridLookUpEdit.Properties.View.Columns("ClientName") IsNot Nothing Then

                '        GridLookUpEdit.Properties.View.Columns("ClientName").Visible = True

                '    End If

                '    If GridLookUpEdit.Properties.View.Columns("InvoiceDate") IsNot Nothing Then

                '        GridLookUpEdit.Properties.View.Columns("InvoiceDate").Visible = True

                '    End If

                '    GridLookUpEdit.Properties.View.BestFitColumns()

                'Else
                If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceSequence.ToString Then

                    ARInvoiceNumber = DataGridViewForm_ImportedItems.CurrentView.GetRowCellValue(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle, AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.ARInvoiceNumber.ToString)

                    If ARInvoiceNumber.GetValueOrDefault(0) <> 0 Then

                        BindingSource = New System.Windows.Forms.BindingSource

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            BindingSource.DataSource = (From AR In AdvantageFramework.Database.Procedures.AccountReceivable.LoadNonVoidedInvoices(DbContext)
                                                        Where AR.InvoiceNumber = ARInvoiceNumber
                                                        Select AR).ToList.OrderBy(Function(AR) AR.SequenceNumber)

                        End Using

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    Else

                        DataGridViewForm_ImportedItems.CurrentView.CloseEditor()

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  PTO "

        Private Sub DataGridView_CellValueChanged_PTO(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim ImportPTOItem As AdvantageFramework.Importing.Classes.ImportPTOItem = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                ImportPTOItem = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportPTOItem = Nothing
            End Try

            If ImportPTOItem IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Column.FieldName = AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.EmployeeCode.ToString Then

                        If Not String.IsNullOrEmpty(e.Value) Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, e.Value)

                            If Employee IsNot Nothing Then

                                ImportPTOItem.EmployeeName = Employee.ToString
                                ImportPTOItem.EmployeeOffice = Employee.OfficeCode
                                ImportPTOItem.EmployeeEmail = Employee.Email

                            End If

                        Else

                            ImportPTOItem.EmployeeName = Nothing
                            ImportPTOItem.EmployeeOffice = Nothing
                            ImportPTOItem.EmployeeEmail = Nothing

                        End If

                        DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridView_ShownEditor_PTO()

            'objects
            Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing

            If TypeOf DataGridViewForm_ImportedItems.CurrentView.ActiveEditor Is DevExpress.XtraEditors.MemoExEdit Then

                If DataGridViewForm_ImportedItems.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Description.ToString Then

                    MemoExEdit = DataGridViewForm_ImportedItems.CurrentView.ActiveEditor

                    MemoExEdit.Properties.MaxLength = 60

                End If

            End If

        End Sub

#End Region

#Region "  JournalEntry "

        Private Sub DataGridView_CellValueChanging_JournalEntry(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ImportJournalEntry As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing

            Try

                ImportJournalEntry = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportJournalEntry = Nothing
            End Try

            If ImportJournalEntry IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.IsOnHold.ToString Then

                    Try

                        ImportJournalEntry.IsOnHold = e.Value

                    Catch ex As Exception

                    End Try

                    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    If Not String.IsNullOrWhiteSpace(ImportJournalEntry.TransactionID) Then

                        ImportJournalEntryList = BindingSource.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)() _
                                                                    .Where(Function(Entity) Entity.TransactionID = ImportJournalEntry.TransactionID).ToList

                    Else

                        ImportJournalEntryList = BindingSource.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)() _
                                                                    .Where(Function(Entity) Entity.TransactionID Is Nothing).ToList

                    End If

                    For Each IJE In ImportJournalEntryList

                        IJE.IsOnHold = ImportJournalEntry.IsOnHold

                    Next

                    DataGridViewForm_ImportedItems.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub DataGridView_QueryPopupNeedDatasourceEvent_JournalEntry(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ImportJournalEntry As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ImportJournalEntry = DirectCast(DataGridViewForm_ImportedItems.CurrentView.GetRow(DataGridViewForm_ImportedItems.CurrentView.FocusedRowHandle), AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)

                Select Case FieldName

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.ClientCode.ToString

                        OverrideDefaultDatasource = True

                        Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Datasource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

                        End Using

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.DivisionCode.ToString

                        OverrideDefaultDatasource = True

                        Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                          Where Entity.ClientCode = ImportJournalEntry.ClientCode
                                          Select Entity).ToList

                        End Using

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.ProductCode.ToString

                        OverrideDefaultDatasource = True

                        Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                          Where Entity.ClientCode = ImportJournalEntry.ClientCode AndAlso
                                                Entity.DivisionCode = ImportJournalEntry.DivisionCode
                                          Select Entity).ToList

                        End Using

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLAccount.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session).ToList

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.PostPeriodCode.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.GeneralLedger.GetValidPostPeriods(DbContext).ToList

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLSource.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.GeneralLedger.GetValidGeneralLedgerSources(DbContext, AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.ImportTemplateTypes), ComboBoxSettings_ImportType.GetSelectedValue))

                End Select

            End Using

        End Sub
        Private Sub DataGridView_CellValueChanged_JournalEntry(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ImportJournalEntry As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing

            Try

                ImportJournalEntry = DataGridViewForm_ImportedItems.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ImportJournalEntry = Nothing
            End Try

            If ImportJournalEntry IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.ClientCode.ToString Then

                    If String.IsNullOrWhiteSpace(e.Value) Then

                        ImportJournalEntry.ClientCode = Nothing
                        ImportJournalEntry.DivisionCode = Nothing
                        ImportJournalEntry.ProductCode = Nothing

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.DivisionCode.ToString Then

                    If String.IsNullOrWhiteSpace(e.Value) Then

                        ImportJournalEntry.DivisionCode = Nothing
                        ImportJournalEntry.ProductCode = Nothing

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLAccount.ToString AndAlso String.IsNullOrWhiteSpace(e.Value) Then

                    ImportJournalEntry.GLDescription = Nothing

                End If

                If e.Column.FieldName <> AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.IsOnHold.ToString Then

                    BindingSource = DataGridViewForm_ImportedItems.DataSource

                    ImportJournalEntryList = BindingSource.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)() _
                                                                        .Where(Function(Entity) Entity.ID = ImportJournalEntry.ID).ToList

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ValidateJournalEntryMatchingIDs(DbContext, ImportJournalEntryList)

                    End Using

                End If

                ImportJournalEntry.Modified = True

            End If

        End Sub
        Private Sub SetJournalEntryAutoFillDependentPropertiesAndValidate(ByVal SelectedItems As IEnumerable)

            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim TransactionIDs() As String = Nothing

            TransactionIDs = (From Entity In SelectedItems.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)()
                              Select Entity.TransactionID).Distinct.ToArray

            BindingSource = DataGridViewForm_ImportedItems.DataSource

            ImportJournalEntryList = BindingSource.OfType(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)() _
                                                            .Where(Function(Entity) TransactionIDs.Contains(Entity.TransactionID)).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ValidateJournalEntryMatchingIDs(DbContext, ImportJournalEntryList)

            End Using

            Me.DataGridViewForm_ImportedItems.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ValidateJournalEntryMatchingIDs(DbContext As AdvantageFramework.Database.DbContext,
                                                    ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry))

            Dim ImportIDList As Generic.List(Of Integer) = Nothing

            ImportIDList = New Generic.List(Of Integer)()
            ImportIDList.AddRange(ImportJournalEntryList.Select(Function(Header) Header.ID).Distinct)

            For Each IJE In ImportJournalEntryList

                If ImportIDList.Contains(IJE.ID) Then

                    IJE.DbContext = DbContext
                    IJE.Modified = True
                    IJE.ValidateEntity(True)

                    ImportIDList.Remove(IJE.ID)

                Else

                    IJE.RefreshErrorHashtable()

                End If

            Next

            Me.DataGridViewForm_ImportedItems.CurrentView.RefreshData()

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.EnabledChanged

            If Not ButtonItemGridOptions_ChooseColumns.Enabled Then

                DataGridViewForm_ImportedItems.CurrentView.HideCustomization()

            End If

        End Sub
        Private Sub ButtonItemMediaOrder_MatchBroadcastMonth_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaOrder_MatchBroadcastMonth.Click

            Match(MatchBy.BroadcastMonth)

        End Sub
        Private Sub ButtonItemMediaOrder_MatchCalendarMonth_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaOrder_MatchCalendarMonth.Click

            Match(MatchBy.CalendarMonth)

        End Sub
        Private Sub ButtonItemMediaOrder_AddToWorksheet_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaOrder_AddToWorksheet.Click

            'objects
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim ImportAccountPayableMediaIDs As IEnumerable(Of Integer) = Nothing
            Dim ImportAccountPayableBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableBroadcastDetail) = Nothing
            Dim OrderNumberSearchResult As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult = Nothing
            Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
            Dim MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
            Dim MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
            Dim VendorCode As String = Nothing
            Dim MatchBy As MatchBy = MatchBy.BroadcastMonth
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim CancelledImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim PerformMatch As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim WorksheetLineAdded As Boolean = False
            Dim OrderLines As Generic.List(Of AdvantageFramework.Controller.Media.MakegoodDeliveryController.OrderLine) = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim MediaBroadcastWorsheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            'Dim MinStartDate As Date = Nothing
            'Dim MaxEndDate As Date = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to create rows in the worksheet for all rows where line number is invalid and the rate is 0.00?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing)

                OrderNumbers = _OrderNumberSearchResultList.Select(Function(Entity) Entity.OrderNumber).ToArray

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaBroadcastWorksheetController = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Session)

                    For Each OrderNumber In OrderNumbers

                        ImportAccountPayableList = (From Entity In DataGridViewForm_ImportedItems.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)
                                                    Where Entity.OrderNumber = OrderNumber AndAlso
                                                          Entity.ErrorHashtable.Values.OfType(Of String).Where(Function(S) S <> String.Empty).Count = 1 AndAlso
                                                          String.IsNullOrWhiteSpace(Entity.LoadErrorText(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString)) = False AndAlso
                                                          Entity.MediaGrossRate.GetValueOrDefault(0) = CDec(0)
                                                    Select Entity).ToList

                        MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, _OrderNumberSearchResultList.Where(Function(ONS) ONS.OrderNumber = OrderNumber).First.WorksheetMarketID)

                        If ImportAccountPayableList.Count > 0 AndAlso MediaBroadcastWorksheetMarket IsNot Nothing Then

                            If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaCalendarTypeID = 1 Then

                                MatchBy = MatchBy.CalendarMonth

                            End If

                            If String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.LockedByUserCode) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Worksheet Market ID " & MediaBroadcastWorksheetMarket.ID & " for Order " & OrderNumber & " is locked by " & MediaBroadcastWorksheetMarket.LockedByUserCode & ".")

                            Else

                                'lock worksheet market
                                MediaBroadcastWorksheetMarket.LockedByUserCode = Me.Session.UserCode
                                DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                                DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified
                                DbContext.SaveChanges()

                                Try

                                    OrderNumberSearchResult = _OrderNumberSearchResultList.Where(Function(ONS) ONS.OrderNumber = OrderNumber).SingleOrDefault

                                    VendorCode = ImportAccountPayableList.First.VendorCode

                                    If MediaBroadcastWorksheetMarketDetailsViewModel Is Nothing OrElse OrderNumberSearchResult.WorksheetID <> MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.ID OrElse
                                            OrderNumberSearchResult.WorksheetMarketID <> MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.ID Then

                                        MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetController.MarketDetails_Load(OrderNumberSearchResult.WorksheetID, OrderNumberSearchResult.WorksheetMarketID)

                                    End If

                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                                    WorksheetLineAdded = False

                                    If Vendor IsNot Nothing Then

                                        If Vendor.IsCableSystem Then 'add rows where NetworkID is present

                                            For Each NetworkID In ImportAccountPayableList.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.NetworkID) = False).Select(Function(Entity) Entity.NetworkID).Distinct.ToList

                                                ImportAccountPayableMediaIDs = ImportAccountPayableList.Where(Function(Entity) Entity.NetworkID = NetworkID).Select(Function(Entity) Entity.ImportAccountPayableMediaID).Distinct.ToList

                                                ImportAccountPayableBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.ImportAccountPayableBroadcastDetail.Load(DbContext)
                                                                                        Where ImportAccountPayableMediaIDs.Contains(Entity.ImportAccountPayableMediaID) AndAlso
                                                                                              Entity.GrossRate = 0 AndAlso
                                                                                              Entity.NetworkID = NetworkID
                                                                                        Select Entity).ToList

                                                If ImportAccountPayableBroadcastDetails.Count = 0 Then

                                                    WorksheetLineAdded = False

                                                Else

                                                    For Each Length In ImportAccountPayableBroadcastDetails.Select(Function(Entity) Entity.Length).Distinct.ToList

                                                        If ImportAccountPayableBroadcastDetails.Where(Function(Entity) Entity.Length = Length).Count > 0 Then

                                                            MediaBroadcastWorksheetController.MarketDetails_AddRowFromAPSpotImport(MediaBroadcastWorksheetMarketDetailsViewModel, VendorCode, ImportAccountPayableBroadcastDetails.Where(Function(Entity) Entity.Length = Length).ToList)
                                                            WorksheetLineAdded = True

                                                        End If

                                                    Next

                                                End If

                                            Next

                                        Else 'add rows without a NetworkID

                                            ImportAccountPayableMediaIDs = ImportAccountPayableList.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.NetworkID) = True).Select(Function(Entity) Entity.ImportAccountPayableMediaID).Distinct.ToList

                                            ImportAccountPayableBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.ImportAccountPayableBroadcastDetail.Load(DbContext)
                                                                                    Where ImportAccountPayableMediaIDs.Contains(Entity.ImportAccountPayableMediaID) AndAlso
                                                                                          Entity.GrossRate = 0 AndAlso
                                                                                          (Entity.NetworkID Is Nothing OrElse
                                                                                           Entity.NetworkID = "")
                                                                                    Select Entity).ToList

                                            If ImportAccountPayableBroadcastDetails.Count = 0 Then

                                                WorksheetLineAdded = False

                                            Else

                                                For Each Length In ImportAccountPayableBroadcastDetails.Select(Function(Entity) Entity.Length).Distinct.ToList

                                                    If ImportAccountPayableBroadcastDetails.Where(Function(Entity) Entity.Length = Length).Count > 0 Then

                                                        MediaBroadcastWorksheetController.MarketDetails_AddRowFromAPSpotImport(MediaBroadcastWorksheetMarketDetailsViewModel, VendorCode, ImportAccountPayableBroadcastDetails.Where(Function(Entity) Entity.Length = Length).ToList)
                                                        WorksheetLineAdded = True

                                                    End If

                                                Next

                                            End If

                                        End If

                                    End If

                                    If WorksheetLineAdded Then

                                        MediaBroadcastWorksheetController.MarketDetails_Save(MediaBroadcastWorksheetMarketDetailsViewModel)

                                        MediaBroadcastWorksheetMarketCreateOrdersViewModel = MediaBroadcastWorksheetController.MarketCreateOrders_Load(MediaBroadcastWorksheetMarketDetailsViewModel)

                                        'ContinueToCreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, True, True, ImportAccountPayableList.First.VendorCode)

                                        '===================
                                        RowIndexes = New Generic.List(Of Integer)
                                        MediaBroadcastWorsheetMarketDetailIDs = New Generic.List(Of Integer)

                                        For Each DataRow In MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                            If VendorCode IsNot Nothing AndAlso DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = VendorCode AndAlso
                                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RowSources.APImport Then

                                                RowIndexes.Add(MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow))
                                                MediaBroadcastWorsheetMarketDetailIDs.Add(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))

                                            ElseIf VendorCode Is Nothing AndAlso
                                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RowSources.APImport Then

                                                RowIndexes.Add(MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow))
                                                MediaBroadcastWorsheetMarketDetailIDs.Add(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))

                                            End If

                                        Next

                                        MediaBroadcastWorksheetMarketDetailsViewModel.GenerateApproveMediaBroadcastWorsheetMarketDetailIDs = MediaBroadcastWorsheetMarketDetailIDs

                                        'CreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, RowIndexes, True, False)

                                        ImportOrders = MediaBroadcastWorksheetController.MarketDetails_CreateImportOrderList(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)

                                        If ImportOrders.Count > 0 Then

                                            CancelledImportOrders = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                                            If AdvantageFramework.Importing.SaveOrders(Session, ImportOrders, False, False, False, "", False, False, CancelledImportOrders, Nothing, Nothing, ErrorMessage) Then

                                                MediaBroadcastWorksheetController.MarketDetails_UpdateDetailDatesOrderStatus(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)
                                                MediaBroadcastWorksheetController.MarketDetails_SaveCreateOrderOptionsAfterCreatingOrders(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel.CreateOrdersByWeek)

                                                PerformMatch = True

                                                OrderLines = MediaBroadcastWorksheetController.MarketDetails_GetOrderLineNumbersForAPImport(MediaBroadcastWorksheetMarketDetailsViewModel)

                                                If OrderLines IsNot Nothing AndAlso OrderLines.Count > 0 Then

                                                    MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Me.Session)

                                                    MakegoodDeliveryController.AcceptOrderForVendorRep(OrderLines, Session.User.EmployeeCode)

                                                End If

                                            Else

                                                AdvantageFramework.WinForm.MessageBox.Show("Problem creating orders: " & ErrorMessage)

                                            End If

                                        End If

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("There is no spot detail associated with this row, line cannot be created.")

                                    End If

                                Catch ex As Exception
                                    AdvantageFramework.WinForm.MessageBox.Show("Problem adding lines to worksheet for order: " & OrderNumber.ToString & " - " & ex.Message)
                                Finally
                                    'unlock worksheet market
                                    MediaBroadcastWorksheetMarket.LockedByUserCode = Nothing
                                    DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                                    DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified
                                    DbContext.SaveChanges()

                                End Try

                            End If

                        End If

                    Next

                End Using

                If PerformMatch Then

                    DataGridViewForm_ImportedItems.SelectAll()

                    Match(MatchBy)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedItems_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ImportedItems.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewForm_ImportedItems.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub
        Private Sub ButtonItemAccountPayable_UpdateVendorToPayToVendor_Click(sender As Object, e As EventArgs) Handles ButtonItemAccountPayable_UpdateVendorToPayToVendor.Click

            'objects
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim Result As String = Nothing

            If DataGridViewForm_ImportedItems.CurrentView.HasAnyInvalidRows Then

                AdvantageFramework.WinForm.MessageBox.Show("All errors must be fixed prior to this action.")

            ElseIf AdvantageFramework.WinForm.MessageBox.Show("This will update vendors with the same invoice numbers to their pay to vendor.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Updating...")

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@BATCH_NAME", SqlDbType.VarChar)
                    SqlParameterBatchName.Value = ComboBoxSettings_Batch.GetSelectedValue

                    Result = DbContext.Database.SqlQuery(Of String)("exec [dbo].[advsp_ap_import_update_vendor_to_vendor_pay_to] @BATCH_NAME", SqlParameterBatchName).FirstOrDefault

                    If String.IsNullOrWhiteSpace(Result) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(Result)

                    End If

                    AdvantageFramework.Importing.ValidateAccountsPayableBatch(Me.Session, ComboBoxSettings_Batch.SelectedValue)

                    LoadSelectedBatch()

                End Using

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#Region "  Broadcast 4A "



#End Region

#End Region

    End Class

End Namespace
