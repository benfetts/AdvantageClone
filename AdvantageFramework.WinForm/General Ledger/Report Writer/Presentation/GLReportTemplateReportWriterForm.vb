Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateReportWriterForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _GLReportUserDefReportID As Integer = 0
        Private _IsAgencyASP As Boolean = False
        Private _AgencyLogoPath As String = ""
        Private _ReportCommandHandler As GeneralLedger.ReportWriter.Presentation.Classes.ReportCommandHandler = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal GLReportUserDefReportID As Integer)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _GLReportUserDefReportID = GLReportUserDefReportID

        End Sub
        Private Function LoadReportDefinition() As String

            'objects
            Dim ReportDefinition As String = ""
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            ReportDesigner1.ActiveDesignPanel.Report.SaveLayout(MemoryStream)

            MemoryStream.Position = 0

            Using StreamReader = New System.IO.StreamReader(MemoryStream)

                ReportDefinition = StreamReader.ReadToEnd

            End Using

            If MemoryStream IsNot Nothing Then

                MemoryStream.Close()
                MemoryStream.Dispose()

                MemoryStream = Nothing

            End If

            LoadReportDefinition = ReportDefinition

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal GLReportUserDefReportID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateReportWriterForm As GLReportTemplateReportWriterForm = Nothing

            GLReportTemplateReportWriterForm = New GLReportTemplateReportWriterForm(Session, GLReportUserDefReportID)

            ShowFormDialog = GLReportTemplateReportWriterForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateReportWriterForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

            _ReportCommandHandler = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.Classes.ReportCommandHandler(ReportDesigner1, _Session)

            ReportDesigner1.AddCommandHandler(_ReportCommandHandler)

            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            ReportDesigner1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            AddHandler DevExpress.XtraReports.UI.XtraReport.FilterComponentProperties, AddressOf FilterComponentProperties

            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.ShowUserFriendlyNames = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyLogoPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                End If

                GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, _GLReportUserDefReportID)

                If GLReportUserDefReport IsNot Nothing Then

                    XtraReport = CreateUserDefinedReport(GLReportUserDefReport)

                Else

                    XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.ReportWriter.BaseGLReportTemplateReport()

                End If

                If XtraReport IsNot Nothing Then

                    AddHandler XtraReport.DesignerLoaded, AddressOf OnDesignerLoaded

                    ReportDesigner1.OpenReport(XtraReport)

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)

            Dim ComponentChangeService As System.ComponentModel.Design.IComponentChangeService = Nothing

            ComponentChangeService = TryCast(e.DesignerHost.GetService(GetType(System.ComponentModel.Design.IComponentChangeService)), System.ComponentModel.Design.IComponentChangeService)

            AddHandler ComponentChangeService.ComponentAdded, AddressOf ComponentChangeService_ComponentAdded
            AddHandler ComponentChangeService.ComponentRemoving, AddressOf ComponentChangeService_ComponentRemoving
            AddHandler ComponentChangeService.ComponentChanging, AddressOf ComponentChangeService_ComponentChanging

        End Sub
        Private Sub ComponentChangeService_ComponentChanging(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentChangingEventArgs)



        End Sub
        Private Sub ComponentChangeService_ComponentRemoving(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentEventArgs)



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
        Protected Sub FilterComponentProperties(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.FilterComponentPropertiesEventArgs)

            If TypeOf e.Component Is DevExpress.XtraReports.UI.XtraReport Then

                e.Properties.Remove("DataAdapter")
                e.Properties.Remove("DataMember")
                e.Properties.Remove("DataSource")
                e.Properties.Remove("DataSourceSchema")

            ElseIf TypeOf e.Component Is DevExpress.XtraReports.UI.PageHeaderBand Then

                e.Properties.Remove("PrintOn")
                e.Properties.Remove("Visible")

            End If

        End Sub
        Private Sub ReportDesigner1_AnyDocumentActivated(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs) Handles ReportDesigner1.AnyDocumentActivated

            If e.Document IsNot Nothing Then

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).BeginSort()

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).SortOrder = Windows.Forms.SortOrder.Ascending
                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).ShowComplexProperties = DevExpress.XtraReports.Design.ShowComplexProperties.Last

                DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).EndSort()

            End If

        End Sub
        Private Sub BarButtonItemSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSave.ItemClick

            'objects
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim Description As String = ""

            If ReportDesigner1.ActiveDesignPanel IsNot Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _GLReportUserDefReportID <> 0 Then

                            GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, _GLReportUserDefReportID)

                            If GLReportUserDefReport IsNot Nothing Then

                                GLReportUserDefReport.ReportDefinition = LoadReportDefinition()
                                GLReportUserDefReport.Description = ReportDesigner1.ActiveDesignPanel.Report.DisplayName

                                If AdvantageFramework.Database.Procedures.GLReportUserDefReport.Update(DbContext, GLReportUserDefReport) Then

                                    ReportDesigner1.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved
                                    _GLReportUserDefReportID = GLReportUserDefReport.ID

                                End If

                            Else

                                If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Save As...", "Enter Description:", Description, Description, AdvantageFramework.Database.Entities.GLReportUserDefReport.Properties.Description) = Windows.Forms.DialogResult.OK Then

                                    GLReportUserDefReport = New AdvantageFramework.Database.Entities.GLReportUserDefReport

                                    GLReportUserDefReport.Description = Description
                                    GLReportUserDefReport.ReportDefinition = LoadReportDefinition()

                                    If AdvantageFramework.Database.Procedures.GLReportUserDefReport.Insert(DbContext, GLReportUserDefReport) Then

                                        ReportDesigner1.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved
                                        _GLReportUserDefReportID = GLReportUserDefReport.ID

                                    End If

                                End If

                            End If

                        Else

                            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Save As...", "Enter Description:", Description, Description, AdvantageFramework.Database.Entities.GLReportUserDefReport.Properties.Description) = Windows.Forms.DialogResult.OK Then

                                GLReportUserDefReport = New AdvantageFramework.Database.Entities.GLReportUserDefReport

                                GLReportUserDefReport.Description = Description
                                GLReportUserDefReport.ReportDefinition = LoadReportDefinition()

                                If AdvantageFramework.Database.Procedures.GLReportUserDefReport.Insert(DbContext, GLReportUserDefReport) Then

                                    ReportDesigner1.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved
                                    _GLReportUserDefReportID = GLReportUserDefReport.ID

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception

                End Try

                If ReportDesigner1.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
