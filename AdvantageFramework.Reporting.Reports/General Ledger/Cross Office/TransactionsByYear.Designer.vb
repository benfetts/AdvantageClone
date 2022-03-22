Namespace GeneralLedger.CrossOffice

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class TransactionsByYear
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
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.start_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.GLYearHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLYearFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLOfficeCodeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label9, Me.label8, Me.label7, Me.label6, Me.line2, Me.label5, Me.label4, Me.label2, Me.label1, Me.line1})
            Me.PageHeader.Name = "PageHeader"
            '
            'label9
            '
            Me.label9.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 21.99999!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(40.0!, 17.99998!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "To"
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 3.999964!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(40.0!, 18.00002!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "From"
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label7.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(585.0!, 21.99999!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.Text = "label7"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'end_period
            '
            Me.end_period.Description = "End Period"
            Me.end_period.Name = "end_period"
            Me.end_period.Visible = False
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.start_period, "Text", "")})
            Me.label6.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(585.0!, 3.999996!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.Text = "label6"
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'start_period
            '
            Me.start_period.Description = "Start Period"
            Me.start_period.Name = "start_period"
            Me.start_period.Visible = False
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 89.99999!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(650.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseBorders = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 71.99999!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.StylePriority.UseTextAlignment = False
            Me.label5.Text = "Amount"
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label4
            '
            Me.label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(195.0!, 71.99999!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "Office"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Year"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 3.999996!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(413.5417!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Cross Office Amount By Year"
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(650.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorders = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.line3, Me.pageInfo1})
            Me.PageFooter.HeightF = 27.99997!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(650.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseBorders = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(250.0!, 18.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'GLYearHeader
            '
            Me.GLYearHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label10})
            Me.GLYearHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLYear", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLYearHeader.HeightF = 18.0!
            Me.GLYearHeader.Level = 1
            Me.GLYearHeader.Name = "GLYearHeader"
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLYear")})
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "label10"
            '
            'GLYearFooter
            '
            Me.GLYearFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label16, Me.label15, Me.label14})
            Me.GLYearFooter.HeightF = 50.0!
            Me.GLYearFooter.Level = 1
            Me.GLYearFooter.Name = "GLYearFooter"
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLYear")})
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(85.00001!, 16.0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "label10"
            '
            'label15
            '
            Me.label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 16.0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(84.5725!, 16.04817!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.Text = "Total for Year"
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAmount")})
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(546.875!, 16.0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary1
            Me.label14.Text = "label13"
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:N2}"
            '
            'GLOfficeCodeHeader
            '
            Me.GLOfficeCodeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label13, Me.label12})
            Me.GLOfficeCodeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLOfficeCodeHeader.HeightF = 18.0!
            Me.GLOfficeCodeHeader.Name = "GLOfficeCodeHeader"
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAmount")})
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary2
            Me.label13.Text = "label13"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:N2}"
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeName")})
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(195.0!, 0!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.GLCrossOffice)
            '
            'TransactionsByYear
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GLYearHeader, Me.GLYearFooter, Me.GLOfficeCodeHeader})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "02 - Transactions by Year"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(100, 100, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.start_period, Me.end_period})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents start_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents GLYearHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLYearFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLOfficeCodeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace
