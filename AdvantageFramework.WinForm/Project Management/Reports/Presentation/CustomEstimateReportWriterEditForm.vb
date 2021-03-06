Namespace ProjectManagement.Reports.Presentation

    Public Class CustomEstimateReportWriterEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _IsAgencyASP As Boolean = False
        Private _AgencyLogoPath As String = ""
        Private _CustomEstimateID As Integer = 0
        Private _ReportCommandHandler As AdvantageFramework.ProjectManagement.Reports.Presentation.Classes.ReportCommandHandler = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal CustomEstimateID As Integer)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _CustomEstimateID = CustomEstimateID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, Optional ByVal CustomEstimateID As Integer = 0) As Windows.Forms.DialogResult

            'objects
            Dim CustomEstimateReportWriterEditForm As CustomEstimateReportWriterEditForm = Nothing

            CustomEstimateReportWriterEditForm = New CustomEstimateReportWriterEditForm(Session, CustomEstimateID)

            ShowFormDialog = CustomEstimateReportWriterEditForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvancedReportWriterEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            BarButtonItemUserDefinedReports.Glyph = AdvantageFramework.My.Resources.InvoicePrintImage
            BarButtonItemUserDefinedReports.LargeGlyph = AdvantageFramework.My.Resources.InvoicePrintImage

            _ReportCommandHandler = New AdvantageFramework.ProjectManagement.Reports.Presentation.Classes.ReportCommandHandler(ReportDesigner1, _Session)

            ReportDesigner1.AddCommandHandler(_ReportCommandHandler)

            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.SaveAll, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            AddHandler DevExpress.XtraReports.UI.XtraReport.FilterComponentProperties, AddressOf FilterComponentProperties

            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.ShowUserFriendlyNames = True

            BarButtonItemPrint.Enabled = False
            BarButtonItemSaveAs.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyLogoPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                End If

            End Using

            'BarButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            'RibbonPageGroupPrint.Visible = False

            BarButtonItemUserDefinedReports.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        End Sub
        Private Sub AdvancedReportWriterEditForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

            If _CustomEstimateID > 0 Then

                Using DbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(DbContext, _CustomEstimateID)

                    If EstimateReport IsNot Nothing Then

                        XtraReport = AdvantageFramework.Reporting.Reports.CreateCustomEstimateReport(EstimateReport)

                        If XtraReport IsNot Nothing Then

                            AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                            ReportDesigner1.OpenReport(XtraReport)

                        End If

                    End If

                End Using

            Else

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Estimate, 0, _ReportCommandHandler.Type, _ReportCommandHandler.Description, 0, True) = Windows.Forms.DialogResult.OK Then

                    Try

                        If _ReportCommandHandler.Type <> Nothing Then

                            XtraReport = AdvantageFramework.Reporting.Reports.CreateCustomEstimateReport(_ReportCommandHandler.Type)

                            If XtraReport IsNot Nothing Then

                                AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                                ReportDesigner1.OpenReport(XtraReport)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    Me.Close()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)

            Dim ComponentChangeService As System.ComponentModel.Design.IComponentChangeService = Nothing

            ComponentChangeService = TryCast(e.DesignerHost.GetService(GetType(System.ComponentModel.Design.IComponentChangeService)), System.ComponentModel.Design.IComponentChangeService)

            AddHandler ComponentChangeService.ComponentAdded, AddressOf ComponentChangeService_ComponentAdded

        End Sub
        Private Sub ComponentChangeService_ComponentAdded(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentEventArgs)

            'objects
            Dim File As String = ""
            Dim Files() As String = Nothing
            Dim XRPictureBox As DevExpress.XtraReports.UI.XRPictureBox = Nothing

            If _IsAgencyASP Then

                If TypeOf e.Component Is DevExpress.XtraReports.UI.XRPictureBox Then

                    XRPictureBox = e.Component

                    If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyLogoPath, Nothing, False, Files) = Windows.Forms.DialogResult.OK Then

                        If Files IsNot Nothing AndAlso Files.Count > 0 Then

                            Try

                                File = Files(0)

                            Catch ex As Exception
                                File = ""
                            End Try

                            If String.IsNullOrWhiteSpace(File) = False AndAlso My.Computer.FileSystem.FileExists(File) Then

                                XRPictureBox.ImageUrl = File

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ReportDesigner1_DesignPanelLoaded(sender As Object, e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs) Handles ReportDesigner1.DesignPanelLoaded

            Dim IToolboxService As System.Drawing.Design.IToolboxService = Nothing

            Try

                IToolboxService = CType(e.DesignerHost.GetService(GetType(System.Drawing.Design.IToolboxService)), System.Drawing.Design.IToolboxService)

                For Each ToolBoxItem In IToolboxService.GetToolboxItems.OfType(Of System.Drawing.Design.ToolboxItem)()

                    If ToolBoxItem.DisplayName = "Subreport" Then

                        IToolboxService.RemoveToolboxItem(ToolBoxItem)
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        Protected Sub FilterComponentProperties(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.FilterComponentPropertiesEventArgs)

            If TypeOf e.Component Is DevExpress.XtraReports.UI.XtraReport Then

                e.Properties.Remove("DataAdapter")
                e.Properties.Remove("DataMember")
                e.Properties.Remove("DataSource")
                e.Properties.Remove("DataSourceSchema")

            ElseIf TypeOf e.Component Is DevExpress.XtraReports.UI.XRPictureBox Then

                If _IsAgencyASP Then

                    e.Properties.Remove("Image")
                    e.Properties.Remove("ImageUrl")

                End If


            End If

        End Sub
        Private Sub BarButtonItemPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemPrint.ItemClick

            If ReportDesigner1.ActiveDesignPanel IsNot Nothing Then

                ReportDesigner1.ActiveDesignPanel.ExecCommand(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab)

            End If

        End Sub
        Private Sub ReportDesigner1_AnyDocumentActivated(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs) Handles ReportDesigner1.AnyDocumentActivated

            If e.Document Is Nothing Then

                BarButtonItemPrint.Enabled = False
                BarButtonItemSaveAs.Enabled = False
                BarButtonItemSaveToFile.Enabled = False

            Else

                BarButtonItemPrint.Enabled = True
                BarButtonItemSaveAs.Enabled = True
                BarButtonItemSaveToFile.Enabled = Not _IsAgencyASP

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).BeginSort()

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).SortOrder = Windows.Forms.SortOrder.Ascending
                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).ShowComplexProperties = DevExpress.XtraReports.Design.ShowComplexProperties.Last

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).EndSort()

            End If

        End Sub
        Private Sub BarButtonItemUserDefinedReports_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemUserDefinedReports.ItemClick

            'AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.CustomInvoice, False, False)

        End Sub
        Private Sub BarButtonItemSaveToFile_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSaveToFile.ItemClick

            If ReportDesigner1.ActiveDesignPanel IsNot Nothing Then

                ReportDesigner1.ActiveDesignPanel.SaveReport()

            End If

        End Sub
        Private Sub BarButtonItemSaveAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSaveAs.ItemClick

            If ReportDesigner1.ActiveDesignPanel IsNot Nothing Then

                ReportDesigner1.ActiveDesignPanel.ExecCommand(DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
