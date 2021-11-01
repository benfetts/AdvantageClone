Namespace WinForm.Presentation.Controls

    Public Class APInvoiceControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event SelectedTabChanged()
        Public Event SelectedDocumentChanged()
        Public Event SpotDetailInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event SpotDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ReadOnly As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Protected _MediaFrom As String = Nothing
        Protected _OrderNumber As Integer = Nothing
        Protected _LineNumbers As IEnumerable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property IsDocumentsTabSelected As Boolean
            Get
                IsDocumentsTabSelected = Me.SelectedTab IsNot Nothing AndAlso Me.SelectedTab.Equals(TabItemAPInvoicesPosted_DocumentsTab)
            End Get
        End Property
        Public ReadOnly Property HasASelectedRow As Boolean
            Get
                HasASelectedRow = DataGridViewAPInvoices_APInvoices.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property CanUpload
            Get
                CanUpload = DocumentManagerControlDocuments_APInvoiceDocuments.CanUpload
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedDocument As Boolean
            Get
                HasOnlyOneSelectedDocument = DocumentManagerControlDocuments_APInvoiceDocuments.HasOnlyOneSelectedDocument
            End Get
        End Property
        Public ReadOnly Property IsSelectedDocumentAURL As Boolean
            Get
                IsSelectedDocumentAURL = DocumentManagerControlDocuments_APInvoiceDocuments.IsSelectedDocumentAURL
            End Get
        End Property
        Public ReadOnly Property HasASelectedDocument As Boolean
            Get
                HasASelectedDocument = DocumentManagerControlDocuments_APInvoiceDocuments.HasASelectedDocument
            End Get
        End Property
        Public Sub DownloadSelectedDocument()
            DocumentManagerControlDocuments_APInvoiceDocuments.DownloadSelectedDocument()
        End Sub
        Public ReadOnly Property SelectedVendorCode As String
            Get
                If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then
                    SelectedVendorCode = DirectCast(DataGridViewAPInvoices_APInvoices.GetFirstSelectedRowDataBoundItem, AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).VendorCode
                Else
                    SelectedVendorCode = Nothing
                End If
            End Get
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property
        Public ReadOnly Property IsSpotDetailsTabSelected As Boolean
            Get
                IsSpotDetailsTabSelected = Me.SelectedTab IsNot Nothing AndAlso Me.SelectedTab.Equals(TabItemAPInvoicesPosted_SpotDetailsTab)
            End Get
        End Property
        Public ReadOnly Property SpotDetailsIsNewItemRow As Boolean
            Get
                SpotDetailsIsNewItemRow = DataGridViewSpotDetails_SpotDetails.IsNewItemRow
            End Get
        End Property
        Public ReadOnly Property SpotDetailsHasASelectedRow As Boolean
            Get
                SpotDetailsHasASelectedRow = DataGridViewSpotDetails_SpotDetails.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property SpotDetailIsDirty As Boolean
            Get
                SpotDetailIsDirty = DataGridViewSpotDetails_SpotDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView).Any
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub ClearControl()

            DataGridViewAPInvoices_APInvoices.ClearGridCustomization()
            DataGridViewChecksWritten_ChecksWritten.ClearGridCustomization()
            DataGridViewTransactions_GLTransactions.ClearGridCustomization()

            DocumentManagerControlDocuments_APInvoiceDocuments.ClearControl()

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub LoadControl(OrderNumber As Integer, LineNumbers As IEnumerable(Of Integer), MediaFrom As String, ShowSpotDetail As Boolean)

            _OrderNumber = OrderNumber
            _LineNumbers = LineNumbers
            _MediaFrom = MediaFrom

            LoadAPInvoicesPostedTab()

            TabControlAPInvoicesPosted_ApInvoicesPosted.SelectedTab = TabItemAPInvoicesPosted_APInvoicesTab

            TabItemAPInvoicesPosted_SpotDetailsTab.Visible = ShowSpotDetail

        End Sub
        Public Sub UploadNewDocument()

            DocumentManagerControlDocuments_APInvoiceDocuments.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice)

        End Sub
        Public Sub SendASPUploadEmail()

            DocumentManagerControlDocuments_APInvoiceDocuments.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice)

        End Sub
        Public Sub CancelAddNewSpotDetail()

            DataGridViewSpotDetails_SpotDetails.CancelNewItemRow()

        End Sub
        Public Function DeleteSpotDetail() As Boolean

            'objects
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim Deleted As Boolean = False

            If DataGridViewSpotDetails_SpotDetails.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _MediaFrom.ToUpper = "RADIO" Then

                            For Each BroadcastOrderDetailView In DataGridViewSpotDetails_SpotDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView).ToList

                                If BroadcastOrderDetailView.IsEntityBeingAdded = False Then

                                    AccountPayableRadioBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.LoadByID(DbContext, BroadcastOrderDetailView.DetailID)

                                    If AccountPayableRadioBroadcastDetail IsNot Nothing Then

                                        DbContext.DeleteEntityObject(AccountPayableRadioBroadcastDetail)

                                    End If

                                End If

                                DataGridViewSpotDetails_SpotDetails.CurrentView.DeleteFromDataSource(BroadcastOrderDetailView)

                            Next

                        ElseIf _MediaFrom.ToUpper = "TV" Then

                            For Each BroadcastOrderDetailView In DataGridViewSpotDetails_SpotDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView).ToList

                                If BroadcastOrderDetailView.IsEntityBeingAdded = False Then

                                    AccountPayableTVBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.LoadByID(DbContext, BroadcastOrderDetailView.DetailID)

                                    If AccountPayableTVBroadcastDetail IsNot Nothing Then

                                        DbContext.DeleteEntityObject(AccountPayableTVBroadcastDetail)

                                    End If

                                End If

                                DataGridViewSpotDetails_SpotDetails.CurrentView.DeleteFromDataSource(BroadcastOrderDetailView)

                            Next

                        End If

                        DbContext.SaveChanges()

                    End Using

                    Deleted = True

                End If

            End If

            DeleteSpotDetail = Deleted

        End Function
        Private Sub LoadAPInvoicesPostedTab()

            Dim MediaManagerAPInvoiceList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice) = Nothing

            MediaManagerAPInvoiceList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice)

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaManagerAPInvoiceList.AddRange(AdvantageFramework.MediaManager.LoadMediaManagerAPInvoices(DbContext, _OrderNumber, _LineNumbers, _MediaFrom))

            End Using

            DataGridViewAPInvoices_APInvoices.DataSource = MediaManagerAPInvoiceList

            DataGridViewAPInvoices_APInvoices.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadAPInvoicesPostedTransactionsTab()

            Dim TransactionList As IEnumerable(Of Object) = Nothing
            Dim AccountPayableID As Integer = Nothing

            DataGridViewTransactions_GLTransactions.DataSource = Nothing

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                AccountPayableID = DirectCast(DataGridViewAPInvoices_APInvoices.CurrentView.GetRow(DataGridViewAPInvoices_APInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).AccountPayableID

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TransactionList = (From APProduction In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext).Include("GeneralLedger")
                                       Where APProduction.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APProduction.GLTransaction,
                                                     .PostPeriod = APProduction.GeneralLedger.PostPeriodCode,
                                                     .CreatedBy = APProduction.GeneralLedger.UserCode})).Union(
                                       From AP In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext).Include("GeneralLedger")
                                       Where AP.ID = AccountPayableID
                                       Select (New With {.Transaction = AP.GLTransaction,
                                                         .PostPeriod = AP.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = AP.GeneralLedger.UserCode})).Union(
                                       From APNonClient In AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Load(DbContext).Include("GeneralLedger")
                                       Where APNonClient.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APNonClient.GLTransaction,
                                                         .PostPeriod = APNonClient.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APNonClient.GeneralLedger.UserCode})).Union(
                                       From APInternet In AdvantageFramework.Database.Procedures.AccountPayableInternet.Load(DbContext).Include("GeneralLedger")
                                       Where APInternet.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APInternet.GLTransaction,
                                                         .PostPeriod = APInternet.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APInternet.GeneralLedger.UserCode})).Union(
                                       From APMagazine In AdvantageFramework.Database.Procedures.AccountPayableMagazine.Load(DbContext).Include("GeneralLedger")
                                       Where APMagazine.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APMagazine.GLTransaction,
                                                         .PostPeriod = APMagazine.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APMagazine.GeneralLedger.UserCode})).Union(
                                       From APNewspaper In AdvantageFramework.Database.Procedures.AccountPayableNewspaper.Load(DbContext).Include("GeneralLedger")
                                       Where APNewspaper.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APNewspaper.GLTransaction,
                                                         .PostPeriod = APNewspaper.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APNewspaper.GeneralLedger.UserCode})).Union(
                                       From APOutdoor In AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.Load(DbContext).Include("GeneralLedger")
                                       Where APOutdoor.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APOutdoor.GLTransaction,
                                                         .PostPeriod = APOutdoor.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APOutdoor.GeneralLedger.UserCode})).Union(
                                       From APRadio In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext).Include("GeneralLedger")
                                       Where APRadio.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APRadio.GLTransaction,
                                                         .PostPeriod = APRadio.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APRadio.GeneralLedger.UserCode})).Union(
                                       From APTV In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext).Include("GeneralLedger")
                                       Where APTV.AccountPayableID = AccountPayableID
                                       Select (New With {.Transaction = APTV.GLTransaction,
                                                         .PostPeriod = APTV.GeneralLedger.PostPeriodCode,
                                                         .CreatedBy = APTV.GeneralLedger.UserCode})).
                                       Select(Function(ALL) New With {ALL.Transaction, ALL.PostPeriod, ALL.CreatedBy}).Where(Function(ALL) ALL.Transaction IsNot Nothing).ToList

                End Using

            End If

            DataGridViewTransactions_GLTransactions.DataSource = TransactionList

            DataGridViewTransactions_GLTransactions.CurrentView.BestFitColumns()

            TabItemAPInvoicesPosted_TransactionsTab.Tag = True

        End Sub
        Private Sub LoadAPInvoicesPostedChecksWrittenTab()

            'objects
            Dim AccountPayableID As Integer = Nothing

            DataGridViewChecksWritten_ChecksWritten.ClearDatasource()

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                AccountPayableID = DirectCast(DataGridViewAPInvoices_APInvoices.CurrentView.GetRow(DataGridViewAPInvoices_APInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).AccountPayableID

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewChecksWritten_ChecksWritten.DataSource = AdvantageFramework.AccountPayable.LoadChecksWritten(DbContext, AccountPayableID)

                End Using

                DataGridViewChecksWritten_ChecksWritten.Columns(3).Visible = False
                DataGridViewChecksWritten_ChecksWritten.Columns(4).Visible = False

                DataGridViewChecksWritten_ChecksWritten.CurrentView.BestFitColumns()

            End If

            TabItemAPInvoicesPosted_APInvoicesTab.Tag = True

        End Sub
        Private Sub LoadAPInvoicesPostedDocumentsTab()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim AccountPayableID As Integer = Nothing

            DocumentManagerControlDocuments_APInvoiceDocuments.ClearControl()

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                AccountPayableID = DirectCast(DataGridViewAPInvoices_APInvoices.CurrentView.GetRow(DataGridViewAPInvoices_APInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).AccountPayableID

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With {.AccountPayableID = AccountPayableID}

                DocumentManagerControlDocuments_APInvoiceDocuments.Enabled = DocumentManagerControlDocuments_APInvoiceDocuments.LoadControl(Database.Entities.DocumentLevel.AccountPayableInvoice, DocumentLevelSetting, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            End If

            TabItemAPInvoicesPosted_APInvoicesTab.Tag = True

        End Sub
        Private Sub LoadAPInvoicesPostedSpotDetailsTab()

            'objects
            Dim AccountPayableID As Integer = Nothing
            Dim BroadcastOrderDetailViews As Generic.List(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView) = Nothing

            BroadcastOrderDetailViews = New List(Of Database.Views.BroadcastOrderDetailView)

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                AccountPayableID = DirectCast(DataGridViewAPInvoices_APInvoices.CurrentView.GetRow(DataGridViewAPInvoices_APInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).AccountPayableID

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _MediaFrom.ToUpper = "RADIO" Then

                        BroadcastOrderDetailViews.AddRange(AdvantageFramework.Database.Procedures.BroadcastOrderDetailView.LoadRadioByAccountPayableID(DbContext, AccountPayableID).ToList)

                    ElseIf _MediaFrom.ToUpper = "TV" Then

                        BroadcastOrderDetailViews.AddRange(AdvantageFramework.Database.Procedures.BroadcastOrderDetailView.LoadTVByAccountPayableID(DbContext, AccountPayableID).ToList)

                    End If

                    DataGridViewSpotDetails_SpotDetails.DataSource = BroadcastOrderDetailViews

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString) IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString).OptionsColumn.ReadOnly = True

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderLineNumber.ToString) IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderLineNumber.ToString).Visible = False

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Approved.ToString) IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Approved.ToString).OptionsColumn.AllowEdit = False

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Comment.ToString) IsNot Nothing AndAlso
                            DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Comment.ToString).RealColumnEdit IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Comment.ToString).RealColumnEdit.ReadOnly = True

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString) IsNot Nothing Then

                        If _MediaFrom.ToUpper = "RADIO" Then

                            DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString).Visible = False

                        ElseIf _MediaFrom.ToUpper = "TV" Then

                            DirectCast(DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString).RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).View.Columns("Code").Visible = True
                            DirectCast(DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString).RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).ValueMember = "Code"
                            DirectCast(DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString).RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).DisplayMember = "Code"

                        End If

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString) IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.OptionsView.ShowFooter = True
                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString).SummaryItem.DisplayFormat = "{0:c2}"

                    End If

                    If DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.ForeignGrossRate.ToString) IsNot Nothing Then

                        DataGridViewSpotDetails_SpotDetails.Columns(AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.ForeignGrossRate.ToString).Visible = False

                    End If

                    DataGridViewSpotDetails_SpotDetails.CurrentView.BestFitColumns()

                End Using

            End If

            TabItemAPInvoicesPosted_SpotDetailsTab.Tag = True

        End Sub
        Public Sub SaveSpotDetail()

            'objects
            Dim AccountPayableID As Integer = 0
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing

            DataGridViewSpotDetails_SpotDetails.CurrentView.CloseEditorForUpdating()

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                AccountPayableID = DirectCast(DataGridViewAPInvoices_APInvoices.CurrentView.GetRow(DataGridViewAPInvoices_APInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice).AccountPayableID

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayable = (From Entity In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableID)
                                      Where Entity.Deleted Is Nothing AndAlso
                                            Entity.Modified Is Nothing
                                      Select Entity).SingleOrDefault

                    If AccountPayable IsNot Nothing Then

                        If _MediaFrom.ToUpper = "RADIO" Then

                            For Each BroadcastOrderDetailView In DataGridViewSpotDetails_SpotDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView).ToList

                                AccountPayableRadioBroadcastDetail = BroadcastOrderDetailView.GetAccountPayableRadioBroadcastDetail(DbContext)

                                If AccountPayableRadioBroadcastDetail IsNot Nothing Then

                                    AccountPayableRadioBroadcastDetail.AccountPayableID = AccountPayableID
                                    AccountPayableRadioBroadcastDetail.AccountPayableSequenceNumber = AccountPayable.SequenceNumber

                                    If AccountPayableRadioBroadcastDetail.IsEntityBeingAdded() Then

                                        AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Insert(DbContext, AccountPayableRadioBroadcastDetail)

                                    Else

                                        AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Update(DbContext, AccountPayableRadioBroadcastDetail)

                                    End If

                                End If

                            Next

                        ElseIf _MediaFrom.ToUpper = "TV" Then

                            For Each BroadcastOrderDetailView In DataGridViewSpotDetails_SpotDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView).ToList

                                AccountPayableTVBroadcastDetail = BroadcastOrderDetailView.GetAccountPayableTVBroadcastDetail(DbContext)

                                If AccountPayableTVBroadcastDetail IsNot Nothing Then

                                    AccountPayableTVBroadcastDetail.AccountPayableID = AccountPayableID
                                    AccountPayableTVBroadcastDetail.AccountPayableSequenceNumber = AccountPayable.SequenceNumber

                                    If AccountPayableTVBroadcastDetail.IsEntityBeingAdded() Then

                                        AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Insert(DbContext, AccountPayableTVBroadcastDetail)

                                    Else

                                        AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Update(DbContext, AccountPayableTVBroadcastDetail)

                                    End If

                                End If

                            Next

                        End If

                        LoadAPInvoicesPostedSpotDetailsTab()

                    End If

                End Using

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub APInvoiceControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewAPInvoices_APInvoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewAPInvoices_APInvoices.SelectionChangedEvent

            For Each TabItem In TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                If Not TabItem.Equals(TabItemAPInvoicesPosted_APInvoicesTab) Then

                    TabItem.Tag = False

                End If

            Next

        End Sub
        Private Sub DocumentManagerControlDocuments_APInvoiceDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_APInvoiceDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub TabControlAPInvoicesPosted_ApInvoicesPosted_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlAPInvoicesPosted_ApInvoicesPosted.SelectedTabChanged

            If e.NewTab.Equals(TabItemAPInvoicesPosted_TransactionsTab) AndAlso e.NewTab.Tag = False Then

                LoadAPInvoicesPostedTransactionsTab()

                _SelectedTab = TabItemAPInvoicesPosted_TransactionsTab

            ElseIf e.NewTab.Equals(TabItemAPInvoicesPosted_DocumentsTab) AndAlso e.NewTab.Tag = False Then

                LoadAPInvoicesPostedDocumentsTab()

                _SelectedTab = TabItemAPInvoicesPosted_DocumentsTab

            ElseIf e.NewTab.Equals(TabItemAPInvoicesPosted_ChecksWrittenTab) AndAlso e.NewTab.Tag = False Then

                LoadAPInvoicesPostedChecksWrittenTab()

                _SelectedTab = TabItemAPInvoicesPosted_ChecksWrittenTab

            ElseIf e.NewTab.Equals(TabItemAPInvoicesPosted_SpotDetailsTab) AndAlso e.NewTab.Tag = False Then

                LoadAPInvoicesPostedSpotDetailsTab()

                _SelectedTab = TabItemAPInvoicesPosted_SpotDetailsTab

            Else

                _SelectedTab = TabItemAPInvoicesPosted_APInvoicesTab

            End If

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub TabControlAPInvoicesPosted_ApInvoicesPosted_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlAPInvoicesPosted_ApInvoicesPosted.SelectedTabChanging

            'If e.OldTab IsNot Nothing AndAlso e.OldTab.Equals(TabItemAPInvoicesPosted_SpotDetailsTab) AndAlso Me.SpotDetailIsDirty Then



            'End If

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_AddNewRowEvent(RowObject As Object) Handles DataGridViewSpotDetails_SpotDetails.AddNewRowEvent

            DataGridViewSpotDetails_SpotDetails.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotDetails_SpotDetails.CellValueChangedEvent

            'objects
            Dim BroadcastOrderDetailView As AdvantageFramework.Database.Views.BroadcastOrderDetailView = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim OrderLineNumber As Short? = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim IsGross As Boolean = True
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing

            BroadcastOrderDetailView = DirectCast(DataGridViewSpotDetails_SpotDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.BroadcastOrderDetailView)

            If e.Column.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString Then

                BroadcastOrderDetailView.GrossRate = If(e.Value Is Nothing, 0, e.Value)

            End If

            If e.Column.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.RunDate.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.NetworkID.ToString Then

                If BroadcastOrderDetailView.OrderNumber > 0 AndAlso BroadcastOrderDetailView.RunDate.HasValue AndAlso BroadcastOrderDetailView.GrossRate > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _MediaFrom.ToUpper = "RADIO" Then

                            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, BroadcastOrderDetailView.OrderNumber)

                            If RadioOrder IsNot Nothing AndAlso RadioOrder.NetGross.GetValueOrDefault(1) = 0 Then

                                IsGross = False

                            End If

                            RadioOrderDetails = (From Item In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, BroadcastOrderDetailView.OrderNumber)
                                                 Where Item.StartDate <= BroadcastOrderDetailView.RunDate AndAlso
                                                   Item.EndDate >= BroadcastOrderDetailView.RunDate AndAlso
                                                   ((IsGross AndAlso Item.GrossRate = BroadcastOrderDetailView.GrossRate) OrElse
                                                    (IsGross = False AndAlso Item.NetRate = BroadcastOrderDetailView.GrossRate))
                                                 Select Item).ToList

                            If RadioOrderDetails.Count = 1 Then

                                OrderLineNumber = RadioOrderDetails.First.LineNumber

                            End If

                        ElseIf _MediaFrom.ToUpper = "TV" Then

                            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, BroadcastOrderDetailView.OrderNumber)

                            If TVOrder IsNot Nothing AndAlso TVOrder.NetGross.GetValueOrDefault(1) = 0 Then

                                IsGross = False

                            End If

                            TVOrderDetails = (From Item In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, BroadcastOrderDetailView.OrderNumber)
                                              Where Item.StartDate <= BroadcastOrderDetailView.RunDate AndAlso
                                                    Item.EndDate >= BroadcastOrderDetailView.RunDate AndAlso
                                                    ((IsGross AndAlso Item.GrossRate = BroadcastOrderDetailView.GrossRate) OrElse
                                                     (IsGross = False AndAlso Item.NetRate = BroadcastOrderDetailView.GrossRate))
                                              Select Item).ToList

                            If TVOrderDetails.Count = 1 Then

                                OrderLineNumber = TVOrderDetails.First.LineNumber

                            End If

                        End If

                    End Using

                End If

                DataGridViewSpotDetails_SpotDetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderLineNumber.ToString, OrderLineNumber)

            End If

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotDetails_SpotDetails.InitNewRowEvent

            If DataGridViewAPInvoices_APInvoices.HasASelectedRow Then

                DataGridViewSpotDetails_SpotDetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString, _OrderNumber)

            End If

            RaiseEvent SpotDetailInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotDetails_SpotDetails.SelectionChangedEvent

            RaiseEvent SpotDetailSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSpotDetails_SpotDetails.ShowingEditorEvent

            If DataGridViewSpotDetails_SpotDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Approved.ToString OrElse
                    DataGridViewSpotDetails_SpotDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Comment.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSpotDetails_SpotDetails_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotDetails_SpotDetails.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If DataGridViewSpotDetails_SpotDetails.CurrentView.IsNewItemRow(DataGridViewSpotDetails_SpotDetails.CurrentView.FocusedRowHandle) AndAlso DataGridViewSpotDetails_SpotDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString Then

                GridLookUpEdit = DataGridViewSpotDetails_SpotDetails.CurrentView.ActiveEditor
                GridLookUpEdit.EditValue = _OrderNumber

                GridLookUpEdit.ClosePopup()

                DataGridViewSpotDetails_SpotDetails.CurrentView.SetRowCellValue(DataGridViewSpotDetails_SpotDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.OrderNumber.ToString, _OrderNumber)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
