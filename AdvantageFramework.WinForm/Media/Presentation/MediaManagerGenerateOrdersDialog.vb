Namespace Media.Presentation

    Public Class MediaManagerGenerateOrdersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
        Private _ShowWorksheetLineNumber As Boolean = False
        Private _GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Private _IsASP As Boolean = False
        Private _AgencyImportPath As String = ""
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail), ShowWorksheetLineNumber As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaManagerReviewDetails = MediaManagerReviewDetails
            _ShowWorksheetLineNumber = ShowWorksheetLineNumber

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim ContactTypes As Generic.List(Of Integer) = Nothing

            GenerateOrders = _GenerateOrders.ToList

            If ButtonItemFilter_Quote.Checked = False Then

                GenerateOrders = GenerateOrders.Where(Function(Entity) Entity.Quote <> True).ToList

            End If

            If ButtonItemFilter_Revision.Checked = False Then

                GenerateOrders = GenerateOrders.Where(Function(Entity) Entity.RevisionNumber.GetValueOrDefault(0) = 0).ToList

            End If

            If ButtonItemFilter_Cancellation.Checked = False Then

                GenerateOrders = GenerateOrders.Where(Function(Entity) Entity.Cancelled <> True).ToList

            End If

            If ButtonItemFilter_Order.Checked = False Then

                GenerateOrders = GenerateOrders.Where(Function(Entity) Entity.Quote = True OrElse Entity.Cancelled = True OrElse Entity.RevisionNumber.GetValueOrDefault(0) > 0).ToList

            End If

            ContactTypes = New Generic.List(Of Integer)

            For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                If ButtonItem.Checked Then

                    ContactTypes.Add(ButtonItem.Tag)

                End If

            Next

            AdvantageFramework.MediaManager.CheckForVaildOrders(Me.Session, GenerateOrders, ButtonItemContactsDocumentSettings_OrderReps.Checked, ContactTypes.ToArray)

            DataGridViewDetails_Details.DataSource = GenerateOrders

            DataGridViewDetails_Details.CurrentView.ClearSorting()
            DataGridViewDetails_Details.CurrentView.BeginSort()
            DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewDetails_Details.CurrentView.EndSort()

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

        End Sub
        Private Sub AddSubItemCheckBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            RepositoryItemCheckEdit.DisplayValueChecked = "Success"
            RepositoryItemCheckEdit.DisplayValueUnchecked = "Faliure"
            RepositoryItemCheckEdit.DisplayValueGrayed = "Pending"

            RepositoryItemCheckEdit.ValueChecked = True
            RepositoryItemCheckEdit.ValueUnchecked = False
            RepositoryItemCheckEdit.ValueGrayed = Nothing

            RepositoryItemCheckEdit.NullText = "Pending"
            RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive

            RepositoryItemCheckEdit.AllowGrayed = True
            RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatRedCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatYellowCircleImage)

            RepositoryItemCheckEdit.Images = ImagesCollection

            RepositoryItemCheckEdit.ImageIndexChecked = 0
            RepositoryItemCheckEdit.ImageIndexUnchecked = 1
            RepositoryItemCheckEdit.ImageIndexGrayed = 2

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            GridColumn.ColumnEdit = RepositoryItemCheckEdit

        End Sub
        Private Sub LoadData()

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

                If _ShowWorksheetLineNumber Then

                    DataGridViewDetails_Details.MakeColumnVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.WorksheetLineNumber.ToString)

                Else

                    DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.WorksheetLineNumber.ToString)

                End If

                'DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString)
                'DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderMessage.ToString)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            EnableOrDisableActions()

        End Sub
        Private Sub LoadGenerateOrders()

            'objects
            Dim VendorCodes() As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    VendorCodes = _MediaManagerReviewDetails.Select(Function(Entity) Entity.VendorCode).Distinct.ToArray

                    Vendors = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).Where(Function(Entity) VendorCodes.Contains(Entity.Code) = True).ToList
                    VCCCards = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCard).ToList

                    _GenerateOrders = (From MediaManagerReviewDetail In _MediaManagerReviewDetails
                                       From Vendor In Vendors.Where(Function(Entity) Entity.Code = MediaManagerReviewDetail.VendorCode).DefaultIfEmpty
                                       From VCCCard In VCCCards.Where(Function(Entity) Entity.OrderNumber = MediaManagerReviewDetail.OrderNumber AndAlso Entity.LineNumber = MediaManagerReviewDetail.LineNumber).DefaultIfEmpty
                                       Select New With {.MediaManagerReviewDetail = MediaManagerReviewDetail, .Vendor = Vendor, .VCCCard = VCCCard}).
                                        Select(Function(OrderGroup) New AdvantageFramework.MediaManager.Classes.GenerateOrder(DbContext, OrderGroup.MediaManagerReviewDetail, OrderGroup.Vendor, OrderGroup.VCCCard)).ToList

                End Using

            Catch ex As Exception
                _GenerateOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)
            End Try

            _GenerateOrders = _GenerateOrders.OrderBy(Function(GO) GO.Vendor).ThenBy(Function(GO) GO.JobNumber).ThenByDescending(Function(GO) GO.JobComponentNumber).ThenByDescending(Function(GO) GO.OrderNumber).ThenByDescending(Function(GO) GO.LineNumber).ToList

        End Sub
        Private Sub SaveContactAndDocumentSettings()

            'objects
            Dim ContactTypes As String = Nothing
            Dim DocumentTypes As String = Nothing

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ButtonItemContactsDocumentSettings_OrderReps.Checked Then

                        AdvantageFramework.MediaManager.SaveDefaultRepType(SecurityDbContext, Session.User.ID, 0)

                    ElseIf ButtonItemContactsDocumentSettings_VendorReps.Checked Then

                        AdvantageFramework.MediaManager.SaveDefaultRepType(SecurityDbContext, Session.User.ID, 1)

                    End If

                    For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                        If ButtonItem.Checked Then

                            ContactTypes = If(String.IsNullOrWhiteSpace(ContactTypes), ButtonItem.Tag, ContactTypes & "," & ButtonItem.Tag)

                        End If

                    Next

                    AdvantageFramework.MediaManager.SaveContactTypes(SecurityDbContext, Session.User.ID, ContactTypes)

                    For Each ButtonItem In ButtonItemContactsDocumentSettings_DocumentTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                        If ButtonItem.Checked Then

                            DocumentTypes = If(String.IsNullOrWhiteSpace(DocumentTypes), ButtonItem.Tag, DocumentTypes & "," & ButtonItem.Tag)

                        End If

                    Next

                    AdvantageFramework.MediaManager.SaveDocumentTypes(SecurityDbContext, Session.User.ID, DocumentTypes)

                End Using

                ButtonItemContactsDocumentSettings_Save.Enabled = False

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing

            ButtonItemActions_Generate.Enabled = DataGridViewDetails_Details.HasASelectedRow
            ButtonItemActions_Recipients.Enabled = DataGridViewDetails_Details.HasASelectedRow

            ButtonItemOrder_Preview.Enabled = DataGridViewDetails_Details.HasASelectedRow

            GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

            If GenerateOrders IsNot Nothing Then

                If GenerateOrders.Count > 1 Then

                    GenerateOrder = GenerateOrders.FirstOrDefault

                    ButtonItemOrder_Settings.Enabled = GenerateOrders.All(Function(Entity) Entity.MediaFrom = GenerateOrder.MediaFrom)

                ElseIf GenerateOrders.Count = 1 Then

                    ButtonItemOrder_Settings.Enabled = True

                Else

                    ButtonItemOrder_Settings.Enabled = False

                End If

            Else

                ButtonItemOrder_Settings.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail), ShowWorksheetLineNumber As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGenerateOrdersDialog As AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersDialog = Nothing

            MediaManagerGenerateOrdersDialog = New AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersDialog(MediaManagerReviewDetails, ShowWorksheetLineNumber)

            ShowFormDialog = MediaManagerGenerateOrdersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerGenerateOrdersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim ContactTypes As String = Nothing
            Dim ContactTypeIDs As Generic.List(Of String) = Nothing
            Dim DocumentTypes As String = Nothing
            Dim DocumentTypeIDs As Generic.List(Of String) = Nothing
            Dim VendorCodes() As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim OrderNumbers As Generic.List(Of Integer) = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemActions_Recipients.Image = AdvantageFramework.My.Resources.EmailSendImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemOrder_Preview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItemOrder_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage

            ButtonItemContactsDocumentSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemContactsDocumentSettings_ContactTypes.Image = AdvantageFramework.My.Resources.ContactImage
            ButtonItemContactsDocumentSettings_DocumentTypes.Image = AdvantageFramework.My.Resources.DocumentCheckImage
            ButtonItemContactsDocumentSettings_AlertRecipients.Image = AdvantageFramework.My.Resources.EmailSendImage

            DataGridViewDetails_Details.ShowSelectDeselectAllButtons = True
            DataGridViewDetails_Details.CurrentView.OptionsBehavior.Editable = True
            DataGridViewDetails_Details.ItemDescription = "Order(s)"
            DataGridViewDetails_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder))
            DataGridViewDetails_Details.CurrentView.GridControl.ShowOnlyPredefinedDetails = True

            AddSubItemCheckBox(DataGridViewDetails_Details, DataGridViewDetails_Details.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString))

            DataGridViewDetails_Details.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            ButtonItemContactsDocumentSettings_Save.Enabled = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                GridColumn = DataGridViewDetails_Details.Columns.ColumnByFieldName(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.DefaultCorrespondenceMethod.ToString)

                If GridColumn IsNot Nothing Then

                    SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                            GridColumn.FieldName, Nothing, Nothing,
                                                                                                                            GetType(AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods), True)

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                        SubItemGridLookUpEditControl.ValueType = GetType(Short)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                            End Using

                        End Using

                        DataGridViewDetails_Details.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                        GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                    End If

                End If

            Catch ex As Exception

            End Try

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.MediaManager.LoadDefaultRepType(SecurityDbContext, Session.User.ID) = 0 Then

                        ButtonItemContactsDocumentSettings_OrderReps.Checked = True

                    Else

                        ButtonItemContactsDocumentSettings_VendorReps.Checked = True

                    End If

                End Using

            Catch ex As Exception

            End Try

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            DocumentTypes = AdvantageFramework.MediaManager.LoadDocumentTypes(SecurityDbContext, Session.User.ID)

                            If String.IsNullOrWhiteSpace(DocumentTypes) = False Then

                                DocumentTypeIDs = Split(DocumentTypes, ",").ToList

                            End If

                        Catch ex As Exception

                        Finally

                            If DocumentTypeIDs Is Nothing Then

                                DocumentTypeIDs = New Generic.List(Of String)

                            End If

                        End Try

                    End Using

                    For Each DocumentType In AdvantageFramework.Database.Procedures.DocumentType.LoadActive(DataContext).ToList

                        ButtonItem = New DevComponents.DotNetBar.ButtonItem(DocumentType.ID, DocumentType.Name)

                        ButtonItem.Name = "ButtonItemDocumentType" & DocumentType.ID
                        ButtonItem.AutoCheckOnClick = True
                        ButtonItem.Tag = DocumentType.ID

                        If DocumentTypeIDs.Contains(DocumentType.ID.ToString) Then

                            ButtonItem.Checked = True

                        End If

                        AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemDocumentTypes_CheckedChanged

                        ButtonItemContactsDocumentSettings_DocumentTypes.SubItems.Add(ButtonItem)

                    Next

                End Using

            Catch ex As Exception

            End Try

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)
                    _AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ContactTypes = AdvantageFramework.MediaManager.LoadContactTypes(SecurityDbContext, Session.User.ID)

                            If String.IsNullOrWhiteSpace(ContactTypes) = False Then

                                ContactTypeIDs = Split(ContactTypes, ",").ToList

                            End If

                        End Using

                    Catch ex As Exception

                    Finally

                        If ContactTypeIDs Is Nothing Then

                            ContactTypeIDs = New Generic.List(Of String)

                        End If

                    End Try

                    For Each ContactType In AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).ToList

                        ButtonItem = New DevComponents.DotNetBar.ButtonItem(ContactType.ID, ContactType.Description)

                        ButtonItem.Name = "ButtonItemContactType" & ContactType.ID
                        ButtonItem.AutoCheckOnClick = True
                        ButtonItem.Tag = ContactType.ID

                        If ContactTypeIDs.Contains(ContactType.ID.ToString) Then

                            ButtonItem.Checked = True

                        End If

                        AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemContactTypes_CheckedChanged

                        ButtonItemContactsDocumentSettings_ContactTypes.SubItems.Add(ButtonItem)

                    Next

                End Using

            Catch ex As Exception

            End Try

            Try

                LoadGenerateOrders()

            Catch ex As Exception

            End Try

            _ToolTipController = New DevExpress.Utils.ToolTipController()
            DataGridViewDetails_Details.GridControl.ToolTipController = _ToolTipController

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaManagerGenerateOrdersDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadData()

            EnableOrDisableActions()

            DataGridViewDetails_Details.SelectAll()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing

            GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

            Try

                DataGridViewForm_Export.DataSource = GenerateOrders

            Catch ex As Exception

            End Try

            'AddFixedLeftColumns(DataGridViewForm_Export)

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_Export.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_Export.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_Export.CurrentView.BestFitColumns()
            DataGridViewForm_Export.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Media Manager Generate Orders", UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Generate.Click

            'objects
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim SuccessfulGenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim ReportGeneratedOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim ContactTypes As Generic.List(Of Integer) = Nothing
            Dim DocumentTypes As Generic.List(Of Long) = Nothing
            Dim OrderNumbers As Generic.List(Of Integer) = Nothing
            Dim LineNumbers As Generic.List(Of Integer) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim OrderStatus As Boolean = False
            Dim OrderStatusMessage As String = ""
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim AllowPrivateAccess As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DocumentFileName As String = ""
            Dim WebvantageURL As String = ""
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim PrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim HasPrintedFirstReport As Boolean = False
            Dim ContinueGenerateOrders As Boolean = False

            If ButtonItemContactsDocumentSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your sent to and document settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving
                    Me.ShowWaitForm("Saving...")

                    Try

                        SaveContactAndDocumentSettings()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

            Try

                If DataGridViewDetails_Details.HasASelectedRow Then

                    GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().Where(Function(Entity) Entity.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0).ToList

                    If GenerateOrders IsNot Nothing AndAlso GenerateOrders.Count > 0 Then

                        ContactTypes = New Generic.List(Of Integer)

                        For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                            If ButtonItem.Checked Then

                                ContactTypes.Add(ButtonItem.Tag)

                            End If

                        Next

                        DocumentTypes = New Generic.List(Of Long)

                        For Each ButtonItem In ButtonItemContactsDocumentSettings_DocumentTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                            If ButtonItem.Checked Then

                                DocumentTypes.Add(ButtonItem.Tag)

                            End If

                        Next

                        'If AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersReviewDialog.ShowFormDialog(GenerateOrders, ButtonItemContactsDocumentSettings_OrderReps.Checked, ContactTypes, DocumentTypes) = Windows.Forms.DialogResult.OK Then

                        AdvantageFramework.MediaManager.CheckForVaildOrders(Me.Session, GenerateOrders, ButtonItemContactsDocumentSettings_OrderReps.Checked, ContactTypes.ToArray)

                        DataGridViewDetails_Details.CurrentView.RefreshData()

                        SuccessfulGenerateOrders = GenerateOrders.Where(Function(Entity) Entity.Status.GetValueOrDefault(False) = True AndAlso Entity.GetGenerateOrderVendorReps.Any(Function(GOVR) GOVR.Process = True)).ToList

                        If SuccessfulGenerateOrders.Count > 0 Then

                            AdvantageFramework.Media.Presentation.MediaManagerProcessGenerateOrdersDialog.ShowFormDialog(SuccessfulGenerateOrders, ButtonItemContactsDocumentSettings_OrderReps.Checked, ContactTypes, DocumentTypes)

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("One or more orders cannot be generated due to an invalid status, please check and try again.")

                        End If

                        'End If

                    End If

                End If

            Catch ex As Exception

            End Try

            LoadGenerateOrders()
            LoadData()

        End Sub
        Private Sub ButtonItemOrder_Preview_Click(sender As Object, e As EventArgs) Handles ButtonItemOrder_Preview.Click

            'objects
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim MediaTypes As IEnumerable(Of String) = Nothing
            Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim OrderNumbers As Generic.List(Of Integer) = Nothing
            Dim LineNumbers As Generic.List(Of Integer) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim VendorName As String = Nothing
            Dim ClientName As String = Nothing
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim StartDate As Nullable(Of Date) = Nothing
            Dim EndDate As Nullable(Of Date) = Nothing
            Dim IsDaily As Boolean = False

            GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

            MediaTypes = (From GO In GenerateOrders
                          Select GO.MediaFrom.Substring(0, 1)).Distinct.ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each MediaType In MediaTypes

                    MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, MediaType)

                    If MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaType)

                        MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting
                        MediaOrderPrintSetting.UserCode = Session.UserCode.ToUpper
                        MediaOrderPrintSetting.MediaType = MediaType

                        OrderPrintSetting.Save(MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, MediaOrderPrintSetting, Nothing)

                    End If

                Next

                OrderNumbers = (From GO In GenerateOrders
                                Select GO.OrderNumber).Distinct.ToList

                For Each OrderNumber In OrderNumbers

                    LineNumbers = (From GO In GenerateOrders
                                   Where GO.OrderNumber = OrderNumber
                                   Select GO.LineNumber).ToList

                    GenerateOrder = GenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).First

                    MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, GenerateOrder.MediaFrom.Substring(0, 1).ToUpper)

                    VendorName = GenerateOrder.Vendor
                    ClientName = GenerateOrder.ClientName

                    'Override for Report format based on weekly / daily
                    StartDate = GenerateOrder.StartDate
                    EndDate = GenerateOrder.EndDate

                    If StartDate.HasValue AndAlso EndDate.HasValue AndAlso (StartDate.Value = EndDate.Value) Then

                        IsDaily = True

                    End If

                    OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaOrderPrintSetting, IsDaily)

                    'If ((Not IsDaily) AndAlso (MediaOrderPrintSetting.ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.DailyBroadcastBySpot)) Then

                    '    MediaOrderPrintSetting.ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.Landscape

                    'End If

                    Report = AdvantageFramework.Reporting.Reports.CreateOrder(Me.Session, OrderNumber, LineNumbers, GenerateOrder.MediaFrom, OrderPrintSetting.ReportFormat)

                    If Report IsNot Nothing Then

                        Report.CreateDocument()

                        If _IsASP Then

                            If My.Computer.FileSystem.DirectoryExists(_AgencyImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Media.Presentation.CreateFileName(ClientName, VendorName, Session.UserCode, OrderNumber)
                            Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(_AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\")
                            Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintingSystemCommandHandler = New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(_AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.Media.Presentation.CreateFileName(ClientName, VendorName, Session.UserCode, OrderNumber), False)

                            Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        Else

                            Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Media.Presentation.CreateFileName(ClientName, VendorName, Session.UserCode, OrderNumber)

                        End If

                        AdvantageFramework.Media.Presentation.MediaManagerOrderViewingForm.ShowFormDialog(Report, PrintingSystemCommandHandler)

                    End If

                Next

            End Using

        End Sub
        Private Sub ButtonItemOrder_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemOrder_Settings.Click

            'objects
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim MediaType As String = ""
            Dim OpenSettingForm As Boolean = False
            Dim IsDaily As Boolean = False

            GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

            If GenerateOrders IsNot Nothing Then

                If GenerateOrders.Count > 1 Then

                    GenerateOrder = GenerateOrders.FirstOrDefault

                    OpenSettingForm = GenerateOrders.All(Function(Entity) Entity.MediaFrom = GenerateOrder.MediaFrom)

                ElseIf GenerateOrders.Count = 1 Then

                    OpenSettingForm = True

                End If

            End If

            If OpenSettingForm Then

                Try

                    GenerateOrder = DataGridViewDetails_Details.GetFirstSelectedRowDataBoundItem()

                Catch ex As Exception
                    GenerateOrder = Nothing
                End Try

                If GenerateOrder IsNot Nothing AndAlso String.IsNullOrWhiteSpace(GenerateOrder.MediaFrom) = False Then

                    MediaType = GenerateOrder.MediaFrom.Substring(0, 1).ToUpper

                    If (GenerateOrder.StartDate.HasValue And GenerateOrder.EndDate.HasValue) Then

                        If (GenerateOrder.StartDate.Value = GenerateOrder.EndDate.Value) Then

                            IsDaily = True

                        End If

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Me.Session.UserCode, MediaType)

                        If MediaOrderPrintSetting Is Nothing Then

                            OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaType)

                            MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                            MediaOrderPrintSetting.UserCode = Me.Session.UserCode.ToUpper
                            MediaOrderPrintSetting.MediaType = MediaType

                            OrderPrintSetting.Save(MediaOrderPrintSetting)

                            AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, MediaOrderPrintSetting, Nothing)

                        End If

                    End Using

                    OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaOrderPrintSetting, IsDaily)

                    AdvantageFramework.Media.Presentation.MediaOrderPrintingOptionsDialog.ShowFormDialog(OrderPrintSetting)

                    End If

                End If

        End Sub
        Private Sub DataGridViewDetails_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_Details.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemFilter_Cancellation_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_Cancellation.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadData()

            End If

        End Sub
        Private Sub ButtonItemFilter_Order_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_Order.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadData()

            End If

        End Sub
        Private Sub ButtonItemFilter_Quote_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_Quote.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadData()

            End If

        End Sub
        Private Sub ButtonItemFilter_Revision_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_Revision.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadData()

            End If

        End Sub
        Private Sub ButtonItemDocumentTypes_CheckedChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    ButtonItemContactsDocumentSettings_Save.Enabled = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemContactTypes_CheckedChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Try

                    ButtonItemContactsDocumentSettings_Save.Enabled = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemContactsDocumentSettings_OrderReps_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemContactsDocumentSettings_OrderReps.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ButtonItemContactsDocumentSettings_OrderReps.Checked Then

                Try

                    ButtonItemContactsDocumentSettings_Save.Enabled = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemContactsDocumentSettings_VendorReps_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemContactsDocumentSettings_VendorReps.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso ButtonItemContactsDocumentSettings_VendorReps.Checked Then

                Try

                    ButtonItemContactsDocumentSettings_Save.Enabled = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemContactsDocumentSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemContactsDocumentSettings_Save.Click

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving
            Me.ShowWaitForm("Saving...")

            Try

                SaveContactAndDocumentSettings()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewDetails_Details_RowDoubleClickEvent() Handles DataGridViewDetails_Details.RowDoubleClickEvent

            'objects
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing

            If DataGridViewDetails_Details.HasASelectedRow Then

                GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

                AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersSentInfoDialog.ShowFormDialog(GenerateOrders)

            End If

        End Sub
        Private Sub ButtonItemActions_Recipients_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Recipients.Click

            'objects
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing

            If DataGridViewDetails_Details.HasASelectedRow Then

                GenerateOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)().ToList

                AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersSentInfoDialog.ShowFormDialog(GenerateOrders)

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm("Refreshing...")

            Try

                LoadGenerateOrders()

                LoadData()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemContactsDocumentSettings_AlertRecipients_Click(sender As Object, e As EventArgs) Handles ButtonItemContactsDocumentSettings_AlertRecipients.Click

            Dim OrderNumberDictionary As Dictionary(Of Integer, String) = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee) = Nothing

            OrderNumberDictionary = (From Entity In DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)
                                     Select Entity.OrderNumber, Entity.MediaFrom).Distinct.ToDictionary(Function(GO) GO.OrderNumber, Function(GO) GO.MediaFrom)

            EmployeeCodes = New Generic.List(Of String)

            For Each GenerateOrder In DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder).ToList

                If GenerateOrder.AlertRecipientEmployeeCodes IsNot Nothing AndAlso GenerateOrder.AlertRecipientEmployeeCodes.Count > 0 Then

                    EmployeeCodes.AddRange(GenerateOrder.AlertRecipientEmployeeCodes)

                End If

            Next

            If AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog.ShowFormDialog(OrderNumberDictionary, EmployeeCodes, Employees) = Windows.Forms.DialogResult.OK Then

                For Each GenerateOrder In DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)

                    GenerateOrder.AlertRecipients = String.Join(", ", Employees.Select(Function(Emp) Emp.ToString).ToArray)
                    GenerateOrder.AlertRecipientEmployeeCodes = Employees.Select(Function(Emp) Emp.Code).ToList

                Next

                DataGridViewDetails_Details.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim ToolTipText As String = Nothing
            Dim RowValue As Nullable(Of Boolean) = Nothing

            If e.SelectedControl Is DataGridViewDetails_Details.GridControl Then

                Try

                    GridView = CType(DataGridViewDetails_Details.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString Then

                            Try

                                RowValue = DataGridViewDetails_Details.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString)

                            Catch ex As Exception

                            End Try

                            If RowValue = False Then

                                ToolTipText = "No valid rep."

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
