Namespace GeneralLedger.CrossOffice

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class TransactionsByPeriod
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.start_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.GLPeriodHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLPeriodFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLXactHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label2, Me.label9, Me.label8, Me.label7, Me.label6, Me.line2, Me.label3, Me.label1, Me.line1})
            Me.PageHeader.Name = "PageHeader"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 71.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(85.41667!, 18.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Trans #"
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
            'label3
            '
            Me.label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.99999!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Posting Period"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 3.999996!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(446.875!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Cross Office Transactions By Posting Period"
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
            'GLPeriodHeader
            '
            Me.GLPeriodHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label11})
            Me.GLPeriodHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLPeriod", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLPeriodHeader.HeightF = 18.0!
            Me.GLPeriodHeader.Level = 1
            Me.GLPeriodHeader.Name = "GLPeriodHeader"
            Me.GLPeriodHeader.RepeatEveryPage = True
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLPeriod")})
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.Text = "label11"
            '
            'GLPeriodFooter
            '
            Me.GLPeriodFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17})
            Me.GLPeriodFooter.HeightF = 18.0!
            Me.GLPeriodFooter.Level = 1
            Me.GLPeriodFooter.Name = "GLPeriodFooter"
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 7.0!)
            Me.label17.ForeColor = System.Drawing.Color.Transparent
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseForeColor = False
            Me.label17.Text = "Space Holder"
            '
            'GLXactHeader
            '
            Me.GLXactHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label14})
            Me.GLXactHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLXact", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLXactHeader.HeightF = 18.0!
            Me.GLXactHeader.Name = "GLXactHeader"
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLXact")})
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label14.Text = "label14"
            Me.label14.WordWrap = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.GLCrossOffice)
            '
            'TransactionsByPeriod
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GLPeriodHeader, Me.GLPeriodFooter, Me.GLXactHeader})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "04 - Transactions By Period"
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
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents start_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents GLPeriodHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLPeriodFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLXactHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace
