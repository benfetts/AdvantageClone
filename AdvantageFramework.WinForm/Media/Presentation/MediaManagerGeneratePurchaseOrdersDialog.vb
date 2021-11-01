Namespace Media.Presentation

    Public Class MediaManagerGeneratePurchaseOrdersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerGeneratePurchaseOrderViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaManagerGeneratePurchaseOrderController = Nothing
        Protected _MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing
        Protected _Refreshed As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail))

            ' This call is required by the designer.
            InitializeComponent()

            _MediaManagerPODetails = MediaManagerPODetails

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_MediaManagerPODetails)

        End Sub
        Private Sub RefreshViewModel(RefreshData As Boolean)

            If RefreshData Then

                _Refreshed = True
                LoadViewModel()

            End If

            DataGridViewDetails_Details.DataSource = _ViewModel.MediaManagerGeneratePurchaseOrders

            DataGridViewDetails_Details.CurrentView.ClearSorting()
            DataGridViewDetails_Details.CurrentView.BeginSort()
            DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder.Properties.PONumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            DataGridViewDetails_Details.CurrentView.EndSort()

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Generate.Enabled = DataGridViewDetails_Details.HasASelectedRow AndAlso
                DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)().Where(Function(Entity) Entity.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0 AndAlso
                                                                                                                                                                                             Entity.NeedsApproval = False).Any

            ButtonItemOrder_Preview.Enabled = DataGridViewDetails_Details.HasASelectedRow AndAlso
                DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)().Where(Function(Entity) Entity.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0 AndAlso
                                                                                                                                                                                             Entity.NeedsApproval = False).Any

            ButtonItemOrder_Settings.Enabled = DataGridViewDetails_Details.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGeneratePurchaseOrdersDialog As AdvantageFramework.Media.Presentation.MediaManagerGeneratePurchaseOrdersDialog = Nothing

            MediaManagerGeneratePurchaseOrdersDialog = New AdvantageFramework.Media.Presentation.MediaManagerGeneratePurchaseOrdersDialog(MediaManagerPODetails)

            ShowFormDialog = MediaManagerGeneratePurchaseOrdersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerGeneratePurchaseOrdersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemOrder_Preview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItemOrder_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage

            DataGridViewDetails_Details.ShowSelectDeselectAllButtons = True
            DataGridViewDetails_Details.CurrentView.OptionsBehavior.Editable = True
            DataGridViewDetails_Details.ItemDescription = "Purchase Order(s)"
            DataGridViewDetails_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder))
            DataGridViewDetails_Details.OptionsBehavior.Editable = False
            DataGridViewDetails_Details.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            _Controller = New AdvantageFramework.Controller.Media.MediaManagerGeneratePurchaseOrderController(Me.Session)

        End Sub
        Private Sub MediaManagerGeneratePurchaseOrdersDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            RefreshViewModel(False)

            DataGridViewDetails_Details.SelectAll()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            If _Refreshed Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Else

                Me.DialogResult = Windows.Forms.DialogResult.Cancel

            End If

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail) = Nothing

            MediaManagerPODetails = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)().ToList

            Try

                DataGridViewForm_Export.DataSource = MediaManagerPODetails

            Catch ex As Exception

            End Try

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_Export.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_Export.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_Export.CurrentView.BestFitColumns()
            DataGridViewForm_Export.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Media Manager Generate Purchase Orders", _Controller.GetAgency, Session, UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Generate.Click

            'objects
            Dim MediaManagerGeneratePurchaseOrder As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder = Nothing
            Dim MediaManagerGeneratePurchaseOrders As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder) = Nothing
            Dim SuccessfulGenerateOrders As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder) = Nothing

            If DataGridViewDetails_Details.HasASelectedRow Then

                MediaManagerGeneratePurchaseOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)().Where(Function(Entity) Entity.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0 AndAlso
                                                                                                                                                                                                                          Entity.NeedsApproval = False).ToList

                If MediaManagerGeneratePurchaseOrders IsNot Nothing AndAlso MediaManagerGeneratePurchaseOrders.Count > 0 Then

                    SuccessfulGenerateOrders = MediaManagerGeneratePurchaseOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.VendorContactEmail) = False).ToList

                    If SuccessfulGenerateOrders.Count > 0 Then

                        AdvantageFramework.Media.Presentation.MediaManagerProcessGeneratePurchaseOrdersDialog.ShowFormDialog(SuccessfulGenerateOrders)

                        RefreshViewModel(True)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemOrder_Preview_Click(sender As Object, e As EventArgs) Handles ButtonItemOrder_Preview.Click

            'objects
            Dim MediaManagerGeneratePurchaseOrders As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder) = Nothing
            Dim PONumbers As Generic.List(Of Integer) = Nothing
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing

            MediaManagerGeneratePurchaseOrders = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)().ToList

            PONumbers = (From PO In MediaManagerGeneratePurchaseOrders
                         Select PO.PONumber).Distinct.ToList

            For Each PONumber In PONumbers

                ParameterDictionary = AdvantageFramework.Reporting.Reports.GetPurchaseOrderReportParameterDictionary(Me.Session, PONumber)

                AdvantageFramework.MediaManager.SetPrintedPOFlag(Me.Session, PONumber)

                Report = AdvantageFramework.Reporting.Reports.CreateReport(Me.Session, Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                If Report IsNot Nothing Then

                    If _ViewModel.IsASP Then

                        If My.Computer.FileSystem.DirectoryExists(_ViewModel.AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Media.Presentation.CreateFileName(Session.UserCode, PONumber)
                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(_ViewModel.AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\")
                        Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        PrintingSystemCommandHandler = New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(_ViewModel.AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\"), "PO_" & AdvantageFramework.Media.Presentation.CreateFileName(Session.UserCode, PONumber), False)

                        Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    Else

                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Media.Presentation.CreateFileName(Session.UserCode, PONumber)

                    End If

                    Report.CreateDocument()

                    AdvantageFramework.Media.Presentation.MediaManagerOrderViewingForm.ShowFormDialog(Report, PrintingSystemCommandHandler)

                End If

            Next

            RefreshViewModel(True)

        End Sub
        Private Sub ButtonItemOrder_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemOrder_Settings.Click

            AdvantageFramework.Media.Presentation.PurchaseOrderPrintingOptionsDialog.ShowFormDialog()

        End Sub
        Private Sub DataGridViewDetails_Details_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewDetails_Details.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder.Properties.DefaultCorrespondenceMethod.ToString Then

                If e.Value = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email.ToString

                ElseIf e.Value = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print.ToString

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder.Properties.PONumber.ToString AndAlso e.Column.View.GetRowHandle(e.ListSourceRowIndex) >= 0 Then

                If IsNumeric(DirectCast(DataGridViewDetails_Details.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder).DisplayPONumber) = False Then

                    e.DisplayText = DirectCast(DataGridViewDetails_Details.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder).DisplayPONumber

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_Details.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            RefreshViewModel(True)

        End Sub

#End Region

#End Region

    End Class

End Namespace