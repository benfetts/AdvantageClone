Namespace WinForm.Presentation.Controls.Classes

    Friend Class DashboardExporter
        Implements DevExpress.XtraPrinting.IPrintable

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


        Private _PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
        Private _PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
        Private _DashboardViewer As DevExpress.DashboardWin.DashboardViewer = Nothing
        Private _Paged As Boolean = False
        Private _UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property CreatesIntersectedBricks() As Boolean Implements DevExpress.XtraPrinting.IPrintable.CreatesIntersectedBricks
            Get
                CreatesIntersectedBricks = False
            End Get
        End Property
        Private ReadOnly Property PropertyEditorControl() As System.Windows.Forms.UserControl Implements DevExpress.XtraPrinting.IPrintable.PropertyEditorControl
            Get
                PropertyEditorControl = Nothing
            End Get
        End Property
        Public Property Session As AdvantageFramework.Security.Session

#End Region

#Region " Methods "

        Public Sub New(ByVal DashboardViewer As DevExpress.DashboardWin.DashboardViewer, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel)

            _PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            _PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink

            _DashboardViewer = DashboardViewer
            _UserLookAndFeel = UserLookAndFeel

            _PrintingSystem.Links.AddRange(New Object() {_PrintableComponentLink})

            AddHandler _PrintingSystem.AfterChange, AddressOf _PrintingSystem_AfterChange

            _PrintableComponentLink.Component = Me

        End Sub
        Friend Sub ShowPrintPreview()

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            _PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "Dashboard"

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

							_PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "Dashboard" & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
							_PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            _PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            _PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            _PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), "Dashboard"))

                            'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            _PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

            End If

            If KeepLoading Then

                _PrintableComponentLink.PaperKind = System.Drawing.Printing.PaperKind.Custom
                _PrintableComponentLink.CustomPaperSize = New System.Drawing.Size(Convert.ToInt32(Math.Ceiling(_DashboardViewer.Width / 0.96F)) + 45, Convert.ToInt32(Math.Ceiling(_DashboardViewer.Height / 0.96F)) + 45)
                _PrintingSystem.PreviewFormEx.Size = New System.Drawing.Size(_DashboardViewer.Width + 100, _DashboardViewer.Height + 100)

                _PrintingSystem.PreviewFormEx.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

                _PrintableComponentLink.CreateDocument()
                _PrintableComponentLink.ShowRibbonPreview(_UserLookAndFeel)

            End If

        End Sub
        Private Sub _PrintingSystem_AfterChange(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.ChangeEventArgs)

            Select Case e.EventName

                Case DevExpress.XtraPrinting.SR.PageSettingsChanged,
                        DevExpress.XtraPrinting.SR.AfterMarginsChange

                    _PrintableComponentLink.CreateDocument()

            End Select

        End Sub
        Private Function ToDocument(ByVal value As Integer) As Integer

            ToDocument = Convert.ToInt32(DevExpress.XtraPrinting.GraphicsUnitConverter.PixelToDoc(value))

        End Function
        Private Sub AcceptChanges() Implements DevExpress.XtraPrinting.IPrintable.AcceptChanges



        End Sub
        Private Function HasPropertyEditor() As Boolean Implements DevExpress.XtraPrinting.IPrintable.HasPropertyEditor

            HasPropertyEditor = False

        End Function
        Private Sub RejectChanges() Implements DevExpress.XtraPrinting.IPrintable.RejectChanges



        End Sub
        Private Sub ShowHelp() Implements DevExpress.XtraPrinting.IPrintable.ShowHelp



        End Sub
        Private Function SupportsHelp() As Boolean Implements DevExpress.XtraPrinting.IPrintable.SupportsHelp

            SupportsHelp = False

        End Function
        Private Sub CreateArea(ByVal areaName As String, ByVal graph As DevExpress.XtraPrinting.IBrickGraphics) Implements DevExpress.XtraPrinting.IBasePrintable.CreateArea

            Dim Width As Integer = 0
            Dim Height As Integer = 0
            Dim Image As System.Drawing.Image = Nothing

            If areaName = "Detail" Then

                Width = _DashboardViewer.Width
                Height = _DashboardViewer.Height

                Image = DevExpress.XtraReports.Native.XRControlPaint.GetControlImage(_DashboardViewer, DevExpress.XtraReports.UI.WinControlDrawMethod_Utils.UseWMPrintRecursive, DevExpress.XtraReports.UI.WinControlImageType_Utils.Bitmap)

                graph.DrawBrick(New DevExpress.XtraPrinting.ImageBrick() With {.Image = Image, .SizeMode = DevExpress.XtraPrinting.ImageSizeMode.CenterImage}, New System.Drawing.Rectangle(0, 0, Width, Height))

            End If

        End Sub
        Private Shadows Sub Finalize(ByVal _PrintingSystem As DevExpress.XtraPrinting.IPrintingSystem, ByVal link As DevExpress.XtraPrinting.ILink) Implements DevExpress.XtraPrinting.IBasePrintable.Finalize



        End Sub
        Private Sub Initialize(ByVal _PrintingSystem As DevExpress.XtraPrinting.IPrintingSystem, ByVal link As DevExpress.XtraPrinting.ILink) Implements DevExpress.XtraPrinting.IBasePrintable.Initialize



        End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

