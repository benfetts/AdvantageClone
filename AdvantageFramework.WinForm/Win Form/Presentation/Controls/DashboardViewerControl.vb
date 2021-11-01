Namespace WinForm.Presentation.Controls

    Public Class DashboardViewerControl
        Inherits DevExpress.DashboardWin.DashboardViewer
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Private _DashboardExporter As AdvantageFramework.WinForm.Presentation.Controls.Classes.DashboardExporter = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True

            _DashboardExporter = New AdvantageFramework.WinForm.Presentation.Controls.Classes.DashboardExporter(Me, Me.LookAndFeel)

            Me.DataSourceOptions.ObjectDataSourceLoadingBehavior = DevExpress.DataAccess.DocumentLoadingBehavior.LoadAsIs

        End Sub
        Public Sub LoadFormSettings(Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            'If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            '	Me.AllowPrintDashboard = False
                            '	Me.AllowPrintDashboardItems = False

                            'Else

                            Me.AllowPrintDashboard = True
                            Me.AllowPrintDashboardItems = True

                            'End If

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub PrintPreview()

            '_DashboardExporter.Session = _Session

            '_DashboardExporter.ShowPrintPreview()

            Me.ShowRibbonPrintPreview()

        End Sub

#Region "  Control Event Handlers "

        Private Sub DashboardViewerControl_PopupMenuShowing(sender As Object, e As DevExpress.DashboardWin.DashboardPopupMenuShowingEventArgs) Handles Me.PopupMenuShowing

            'objects
            Dim BarButtonItem As DevExpress.XtraBars.BarButtonItem = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    If e.ButtonType = DevExpress.DashboardWin.DashboardButtonType.Export OrElse
                            e.ButtonType = DevExpress.DashboardWin.DashboardButtonType.None Then

                        For Each MenuItem In e.Menu.ItemLinks.OfType(Of DevExpress.XtraBars.BarItemLink).ToList

                            If MenuItem.Caption = "Export To PDF" OrElse
                                MenuItem.Caption = "Export To Image" OrElse
                                MenuItem.Caption = "Export To Excel" OrElse
                                MenuItem.Caption = "Export Dashboard" Then

                                e.Menu.RemoveLink(MenuItem)

                            End If

                        Next

                        'For Each ItemLink In e.Menu.ItemLinks.OfType(Of DevExpress.XtraBars.BarButtonItem)

                        '    ' AddHandler ItemLink.

                        'Next

                        'BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                        'BarButtonItem.Caption = "Preview..."

                        'AddHandler BarButtonItem.ItemClick, AddressOf PrintPreview

                        'e.Menu.AddItem(BarButtonItem)

                    End If

                End If

            End Using

        End Sub
        Private Sub DashboardViewerControl_PrintPreviewShowing(sender As Object, e As DevExpress.DashboardWin.PrintPreviewShowingEventArgs) Handles Me.PrintPreviewShowing

            'objects
            Dim AgencyImportPath As String = String.Empty

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        e.RibbonPreview.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "Dashboard" & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                        e.RibbonPreview.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                        e.RibbonPreview.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        e.RibbonPreview.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        e.RibbonPreview.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), "Dashboard"))

                        'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                        e.RibbonPreview.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)
                        'e.RibbonPreview.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.RibbonPreview.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.RibbonPreview.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendXls, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.RibbonPreview.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx, DevExpress.XtraPrinting.CommandVisibility.All)

                    End If

                End Using

            End If

        End Sub
        Private Sub DashboardViewerControl_BeforeExport(sender As Object, e As DevExpress.DashboardWin.DashboardExportFormShowingEventArgs) Handles Me.ExportFormShowing

            ''objects
            'Dim PrintableComponent As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            'Dim AgencyImportPath As String = String.Empty

            'If _Session IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

            '            e.ShowExportForm = False

            '            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

            '            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

            '                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

            '                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

            '                End If

            '            End If

            '            For Each DashboardItem In Me.Dashboard.Items

            '                PrintableComponent = Me.GetPrintableComponent(DashboardItem.ComponentName)

            '                PrintableComponent.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "Dashboard" & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
            '                PrintableComponent.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
            '                PrintableComponent.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
            '                PrintableComponent.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

            '                PrintableComponent.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), "Dashboard"))

            '                'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            '                PrintableComponent.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

            '            Next

            '        End If

            '    End Using

            'End If

        End Sub
        Private Sub DashboardViewerControl_CustomExport(sender As Object, e As DevExpress.DashboardCommon.CustomExportEventArgs) Handles Me.CustomExport

            'objects
            Dim AgencyImportPath As String = String.Empty

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        e.Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "Dashboard" & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                        e.Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                        e.Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        e.Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        e.Report.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), "Dashboard"))

                        'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                        e.Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)
                        'e.Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendXls, DevExpress.XtraPrinting.CommandVisibility.All)
                        'e.Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx, DevExpress.XtraPrinting.CommandVisibility.All)

                    End If

                End Using

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace


