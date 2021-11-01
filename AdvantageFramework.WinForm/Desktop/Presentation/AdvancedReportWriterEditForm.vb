Namespace Desktop.Presentation

    Public Class AdvancedReportWriterEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _IsAgencyASP As Boolean = False
        Private _AgencyLogoPath As String = ""
        Private _UserDefinedReportID As Integer = 0
        Private _ReportType As Reporting.UDRTypes = Reporting.UDRTypes.Advanced
        Private _ReportCommandHandler As AdvantageFramework.Reporting.Presentation.Classes.ReportCommandHandler = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal ReportType As Reporting.UDRTypes, ByVal UserDefinedReportID As Integer)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _UserDefinedReportID = UserDefinedReportID
            _ReportType = ReportType

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal ReportType As Reporting.UDRTypes, Optional ByVal UserDefinedReportID As Integer = 0) As Windows.Forms.DialogResult

            'objects
            Dim AdvancedReportWriterEditForm As AdvancedReportWriterEditForm = Nothing

            AdvancedReportWriterEditForm = New AdvancedReportWriterEditForm(Session, ReportType, UserDefinedReportID)

            ShowFormDialog = AdvancedReportWriterEditForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvancedReportWriterEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            BarButtonItemUserDefinedReports.Glyph = AdvantageFramework.My.Resources.ReportImage
            BarButtonItemUserDefinedReports.LargeGlyph = AdvantageFramework.My.Resources.ReportImage

            _ReportCommandHandler = New AdvantageFramework.Reporting.Presentation.Classes.ReportCommandHandler(ReportDesigner1, _Session, _ReportType)

            ReportDesigner1.AddCommandHandler(_ReportCommandHandler)

            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.SaveAll, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            AddHandler DevExpress.XtraReports.UI.XtraReport.FilterComponentProperties, AddressOf FilterComponentProperties

            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.ShowUserFriendlyNames = True

            BarButtonItemPrint.Enabled = False
            BarButtonItemSaveToFile.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyLogoPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                End If

            End Using

        End Sub
        Private Sub AdvancedReportWriterEditForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

            If _UserDefinedReportID > 0 Then

                Using DbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(DbContext, _UserDefinedReportID)

                    If UserDefinedReport IsNot Nothing Then

                        XtraReport = AdvantageFramework.Reporting.Reports.CreateUserDefinedReport(UserDefinedReport)

                        If XtraReport IsNot Nothing Then

                            If UserDefinedReport.AdvancedReportWriterType = 95 Then
                                XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecifications(_Session)
                            End If
                            If UserDefinedReport.AdvancedReportWriterType = 113 Then
                                XtraReport.DataSource = AdvantageFramework.Reporting.LoadEmployeeUtilizationReport(_Session)
                            End If
                            If UserDefinedReport.AdvancedReportWriterType = 120 Then
                                XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecificationsByDestination(_Session)
                            End If

                            AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                            ReportDesigner1.OpenReport(XtraReport)

                        End If

                    End If

                End Using

            Else

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(_ReportType, 0, _ReportCommandHandler.Type, _ReportCommandHandler.Description, _ReportCommandHandler.UserDefinedReportCategoryID, True) = Windows.Forms.DialogResult.OK Then

                    If _ReportType = Reporting.UDRTypes.Advanced Then

                        Try

                            If _ReportCommandHandler.Type <> Nothing Then

                                XtraReport = AdvantageFramework.Reporting.Reports.CreateAdvancedReportWriterReport(_ReportCommandHandler.Type)

                                If XtraReport IsNot Nothing Then

                                    If _ReportCommandHandler.Type = 95 Then
                                        XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecifications(_Session)
                                    End If
                                    If _ReportCommandHandler.Type = 113 Then
                                        XtraReport.DataSource = AdvantageFramework.Reporting.LoadEmployeeUtilizationReport(_Session)
                                    End If
                                    If _ReportCommandHandler.Type = 120 Then
                                        XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecificationsByDestination(_Session)
                                    End If

                                    AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                                    ReportDesigner1.OpenReport(XtraReport)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf _ReportType = Reporting.UDRTypes.Estimate Then

                        Try

                            If _ReportCommandHandler.Type <> Nothing Then

                                XtraReport = AdvantageFramework.Reporting.Reports.CreateAdvancedReportWriterReportEstimate(_ReportCommandHandler.Type)

                                If XtraReport IsNot Nothing Then

                                    AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                                    ReportDesigner1.OpenReport(XtraReport)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf _ReportType = Reporting.UDRTypes.Invoice Then

                        Try

                            If _ReportCommandHandler.Type <> Nothing Then

                                XtraReport = AdvantageFramework.Reporting.Reports.CreateAdvancedReportWriterReportEstimate(_ReportCommandHandler.Type)

                                If XtraReport IsNot Nothing Then

                                    AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                                    ReportDesigner1.OpenReport(XtraReport)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If
                    
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

                                XRPictureBox.Image = System.Drawing.Image.FromFile(File)

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
                BarButtonItemSaveToFile.Enabled = False

            Else

                BarButtonItemPrint.Enabled = True
                BarButtonItemSaveToFile.Enabled = Not _IsAgencyASP

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).BeginSort()

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).SortOrder = Windows.Forms.SortOrder.Ascending
                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).ShowComplexProperties = DevExpress.XtraReports.Design.ShowComplexProperties.Last

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).EndSort()

            End If

        End Sub
        Private Sub BarButtonItemUserDefinedReports_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemUserDefinedReports.ItemClick

            AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.UserDefinedReport, False, False)

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
