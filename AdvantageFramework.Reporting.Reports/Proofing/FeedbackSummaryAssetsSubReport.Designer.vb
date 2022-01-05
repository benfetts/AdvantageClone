Namespace Proofing

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class FeedbackSummaryAssetsSubReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCell_Left = New DevExpress.XtraReports.UI.XRTableCell()
            Me.Label_FilenameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Filename = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Filesize = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_FilesizeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelVersionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelVersion = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxAssetThumbnail = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.Label_FileType = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubReportComments = New DevExpress.XtraReports.UI.XRSubreport()
            CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 15.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Visible = False
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 15.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Visible = False
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrLabel1, Me.XrTable1, Me.SubReportComments})
            Me.Detail.HeightF = 223.4194!
            Me.Detail.Name = "Detail"
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4.0!
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 209.4194!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(600.894!, 4.000015!)
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(214.5772!, 7.400831!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.35045!, 19.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.Text = "Comments"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrTable1
            '
            Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(2.344767!, 7.400799!)
            Me.XrTable1.Name = "XrTable1"
            Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
            Me.XrTable1.SizeF = New System.Drawing.SizeF(201.302!, 195.3336!)
            '
            'XrTableRow1
            '
            Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCell_Left})
            Me.XrTableRow1.Name = "XrTableRow1"
            Me.XrTableRow1.Weight = 1.0564770490158848R
            '
            'TableCell_Left
            '
            Me.TableCell_Left.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_FileType, Me.Label_FilenameLabel, Me.Label_Filename, Me.Label_Filesize, Me.Label_FilesizeLabel, Me.LabelVersionLabel, Me.LabelVersion, Me.PictureBoxAssetThumbnail})
            Me.TableCell_Left.Multiline = True
            Me.TableCell_Left.Name = "TableCell_Left"
            Me.TableCell_Left.Weight = 0.96153841458834133R
            '
            'Label_FilenameLabel
            '
            Me.Label_FilenameLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_FilenameLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_FilenameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_FilenameLabel.BorderWidth = 1.0!
            Me.Label_FilenameLabel.CanGrow = False
            Me.Label_FilenameLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_FilenameLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_FilenameLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001316071!, 125.3725!)
            Me.Label_FilenameLabel.Name = "Label_FilenameLabel"
            Me.Label_FilenameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_FilenameLabel.SizeF = New System.Drawing.SizeF(60.35045!, 19.0!)
            Me.Label_FilenameLabel.StylePriority.UseFont = False
            Me.Label_FilenameLabel.Text = "Filename:"
            Me.Label_FilenameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Filename
            '
            Me.Label_Filename.BackColor = System.Drawing.Color.Transparent
            Me.Label_Filename.BorderColor = System.Drawing.Color.Black
            Me.Label_Filename.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Filename.BorderWidth = 1.0!
            Me.Label_Filename.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Filename.LocationFloat = New DevExpress.Utils.PointFloat(60.35062!, 125.3725!)
            Me.Label_Filename.Name = "Label_Filename"
            Me.Label_Filename.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Filename.SizeF = New System.Drawing.SizeF(135.6036!, 19.0!)
            Me.Label_Filename.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.Label_Filename.Summary = XrSummary1
            Me.Label_Filename.Text = "Label_Filename"
            Me.Label_Filename.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Filesize
            '
            Me.Label_Filesize.BackColor = System.Drawing.Color.Transparent
            Me.Label_Filesize.BorderColor = System.Drawing.Color.Black
            Me.Label_Filesize.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Filesize.BorderWidth = 1.0!
            Me.Label_Filesize.CanGrow = False
            Me.Label_Filesize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Filesize.LocationFloat = New DevExpress.Utils.PointFloat(60.35023!, 144.3725!)
            Me.Label_Filesize.Name = "Label_Filesize"
            Me.Label_Filesize.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Filesize.SizeF = New System.Drawing.SizeF(135.6036!, 19.0!)
            Me.Label_Filesize.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.Label_Filesize.Summary = XrSummary2
            Me.Label_Filesize.Text = "Label_Filesize"
            Me.Label_Filesize.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_FilesizeLabel
            '
            Me.Label_FilesizeLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_FilesizeLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_FilesizeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_FilesizeLabel.BorderWidth = 1.0!
            Me.Label_FilesizeLabel.CanGrow = False
            Me.Label_FilesizeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_FilesizeLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_FilesizeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 144.3725!)
            Me.Label_FilesizeLabel.Name = "Label_FilesizeLabel"
            Me.Label_FilesizeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_FilesizeLabel.SizeF = New System.Drawing.SizeF(60.35016!, 19.0!)
            Me.Label_FilesizeLabel.StylePriority.UseFont = False
            Me.Label_FilesizeLabel.Text = "File size:"
            Me.Label_FilesizeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelVersionLabel
            '
            Me.LabelVersionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelVersionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelVersionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelVersionLabel.BorderWidth = 1.0!
            Me.LabelVersionLabel.CanGrow = False
            Me.LabelVersionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelVersionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelVersionLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001316071!, 163.3725!)
            Me.LabelVersionLabel.Name = "LabelVersionLabel"
            Me.LabelVersionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelVersionLabel.SizeF = New System.Drawing.SizeF(60.35016!, 19.0!)
            Me.LabelVersionLabel.StylePriority.UseFont = False
            Me.LabelVersionLabel.Text = "Version:"
            Me.LabelVersionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelVersion
            '
            Me.LabelVersion.BackColor = System.Drawing.Color.Transparent
            Me.LabelVersion.BorderColor = System.Drawing.Color.Black
            Me.LabelVersion.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelVersion.BorderWidth = 1.0!
            Me.LabelVersion.CanGrow = False
            Me.LabelVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelVersion.LocationFloat = New DevExpress.Utils.PointFloat(60.35023!, 163.3725!)
            Me.LabelVersion.Name = "LabelVersion"
            Me.LabelVersion.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelVersion.SizeF = New System.Drawing.SizeF(135.6036!, 19.0!)
            Me.LabelVersion.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.LabelVersion.Summary = XrSummary3
            Me.LabelVersion.Text = "Label_Version"
            Me.LabelVersion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PictureBoxAssetThumbnail
            '
            Me.PictureBoxAssetThumbnail.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft
            Me.PictureBoxAssetThumbnail.LocationFloat = New DevExpress.Utils.PointFloat(0!, 6.3707!)
            Me.PictureBoxAssetThumbnail.Name = "PictureBoxAssetThumbnail"
            Me.PictureBoxAssetThumbnail.SizeF = New System.Drawing.SizeF(100.0!, 100.0!)
            Me.PictureBoxAssetThumbnail.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize
            '
            'Label_FileType
            '
            Me.Label_FileType.BackColor = System.Drawing.Color.Transparent
            Me.Label_FileType.BorderColor = System.Drawing.Color.Black
            Me.Label_FileType.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_FileType.BorderWidth = 1.0!
            Me.Label_FileType.CanGrow = False
            Me.Label_FileType.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_FileType.ForeColor = System.Drawing.Color.Gray
            Me.Label_FileType.LocationFloat = New DevExpress.Utils.PointFloat(0.0000002384186!, 6.370704!)
            Me.Label_FileType.Name = "Label_FileType"
            Me.Label_FileType.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_FileType.SizeF = New System.Drawing.SizeF(191.3021!, 100.0!)
            Me.Label_FileType.StylePriority.UseFont = False
            Me.Label_FileType.StylePriority.UseForeColor = False
            Me.Label_FileType.Text = "FileType"
            Me.Label_FileType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.Label_FileType.Visible = False
            '
            'SubReportComments
            '
            Me.SubReportComments.CanShrink = True
            Me.SubReportComments.LocationFloat = New DevExpress.Utils.PointFloat(214.5768!, 26.40085!)
            Me.SubReportComments.Name = "SubReportComments"
            Me.SubReportComments.ReportSource = New AdvantageFramework.Reporting.Reports.Proofing.FeedbackSummaryAssetCommentsSubReport()
            Me.SubReportComments.SizeF = New System.Drawing.SizeF(386.3172!, 176.3336!)
            '
            'FeedbackSummaryAssetsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(2, 8, 15, 15)
            Me.Version = "20.1"
            CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCell_Left As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents PictureBoxAssetThumbnail As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents SubReportComments As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents Label_FilenameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Filename As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Filesize As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_FilesizeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelVersionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelVersion As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_FileType As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
