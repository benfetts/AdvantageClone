Namespace Billing

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class BillingApprovalBatchReport
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
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.BillingApprovalBatchID_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.table1 = New DevExpress.XtraReports.UI.XRTable()
            Me.tableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.tableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.tableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BillingApprovalFlag = New DevExpress.XtraReports.UI.CalculatedField()
            Me.io_date_cutoff = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line6 = New DevExpress.XtraReports.UI.XRLine()
            Me.ap_pp_cutoff = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComponent_FooterJob = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComponent_HeaderComments = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line7 = New DevExpress.XtraReports.UI.XRLine()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivisionProduct_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label67 = New DevExpress.XtraReports.UI.XRLabel()
            Me.et_date_cutoff = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label102 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label103 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label104 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label105 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label106 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComponent_HeaderJob = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComponent_HeaderLabels = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComponent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BillingApprovalBatchID_Footer = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.table1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label35
            '
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionAmount", "{0:n2}")})
            Me.label35.Dpi = 100.0!
            Me.label35.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(333.3333!, 9.999974!)
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label35.Summary = XrSummary1
            Me.label35.Text = "label21"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.BorderWidth = 1.0!
            Me.line3.Dpi = 100.0!
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LineWidth = 4
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 35.83336!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseBorderWidth = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.BorderWidth = 1.0!
            Me.line1.Dpi = 100.0!
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LineWidth = 4
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorderWidth = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label29
            '
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalHeaderClientComment")})
            Me.label29.Dpi = 100.0!
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(122.9167!, 22.99999!)
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(627.0833!, 23.0!)
            Me.label29.Text = "label29"
            '
            'line5
            '
            Me.line5.BackColor = System.Drawing.Color.LightGray
            Me.line5.BorderColor = System.Drawing.Color.LightGray
            Me.line5.BorderWidth = 1.0!
            Me.line5.Dpi = 100.0!
            Me.line5.ForeColor = System.Drawing.Color.LightGray
            Me.line5.LineWidth = 4
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 5.999947!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line5.StylePriority.UseBackColor = False
            Me.line5.StylePriority.UseBorderColor = False
            Me.line5.StylePriority.UseBorderWidth = False
            Me.line5.StylePriority.UseForeColor = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Dpi = 100.0!
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.Format = "Page {0} of {1}"
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(622.9167!, 12.41665!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.RunningBand = Me.BillingApprovalBatchID_Header
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(127.0833!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BillingApprovalBatchID_Header
            '
            Me.BillingApprovalBatchID_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line3, Me.label3, Me.table1})
            Me.BillingApprovalBatchID_Header.Dpi = 100.0!
            Me.BillingApprovalBatchID_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("BillingApprovalBatchID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.BillingApprovalBatchID_Header.HeightF = 45.83333!
            Me.BillingApprovalBatchID_Header.Level = 4
            Me.BillingApprovalBatchID_Header.Name = "BillingApprovalBatchID_Header"
            Me.BillingApprovalBatchID_Header.RepeatEveryPage = True
            '
            'label3
            '
            Me.label3.Dpi = 100.0!
            Me.label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(146.875!, 25.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Billing Approval Batch: "
            '
            'table1
            '
            Me.table1.Dpi = 100.0!
            Me.table1.LocationFloat = New DevExpress.Utils.PointFloat(146.875!, 0!)
            Me.table1.Name = "table1"
            Me.table1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.tableRow1})
            Me.table1.SizeF = New System.Drawing.SizeF(408.3333!, 25.0!)
            '
            'tableRow1
            '
            Me.tableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell1, Me.tableCell2})
            Me.tableRow1.Dpi = 100.0!
            Me.tableRow1.Name = "tableRow1"
            Me.tableRow1.Weight = 11.5R
            '
            'tableCell1
            '
            Me.tableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalBatchID")})
            Me.tableCell1.Dpi = 100.0!
            Me.tableCell1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.tableCell1.Name = "tableCell1"
            Me.tableCell1.StylePriority.UseFont = False
            Me.tableCell1.Text = "tableCell1"
            Me.tableCell1.Weight = 0.028787878787878807R
            '
            'tableCell2
            '
            Me.tableCell2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalBatchDescription")})
            Me.tableCell2.Dpi = 100.0!
            Me.tableCell2.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.tableCell2.Name = "tableCell2"
            Me.tableCell2.StylePriority.UseFont = False
            Me.tableCell2.Text = "tableCell2"
            Me.tableCell2.Weight = 0.16919190932765155R
            Me.tableCell2.WordWrap = False
            '
            'label32
            '
            Me.label32.Dpi = 100.0!
            Me.label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(333.3334!, 0!)
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(116.6666!, 23.0!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.StylePriority.UseTextAlignment = False
            Me.label32.Text = "Approval Amount"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label27
            '
            Me.label27.Dpi = 100.0!
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 22.99999!)
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(122.9167!, 23.00001!)
            Me.label27.Text = "Client Comment:"
            '
            'BillingApprovalFlag
            '
            Me.BillingApprovalFlag.DisplayName = "BillingApprovalFlag"
            Me.BillingApprovalFlag.Expression = "IIf(([BillingApprovalBatchID]=0 Or [BillingApprovalBatchID] Is Null),0,1)"
            Me.BillingApprovalFlag.FieldType = DevExpress.XtraReports.UI.FieldType.[Byte]
            Me.BillingApprovalFlag.Name = "BillingApprovalFlag"
            '
            'io_date_cutoff
            '
            Me.io_date_cutoff.Description = "Income Only Date"
            Me.io_date_cutoff.Name = "io_date_cutoff"
            Me.io_date_cutoff.Visible = False
            '
            'line6
            '
            Me.line6.BackColor = System.Drawing.Color.Transparent
            Me.line6.BorderColor = System.Drawing.Color.Transparent
            Me.line6.BorderWidth = 1.0!
            Me.line6.Dpi = 100.0!
            Me.line6.ForeColor = System.Drawing.Color.LightGray
            Me.line6.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line6.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 36.0!)
            Me.line6.Name = "line6"
            Me.line6.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line6.StylePriority.UseBackColor = False
            Me.line6.StylePriority.UseBorderColor = False
            Me.line6.StylePriority.UseBorderWidth = False
            Me.line6.StylePriority.UseForeColor = False
            '
            'ap_pp_cutoff
            '
            Me.ap_pp_cutoff.Description = "A/P Posting Period"
            Me.ap_pp_cutoff.Name = "ap_pp_cutoff"
            Me.ap_pp_cutoff.Visible = False
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionName")})
            Me.label5.Dpi = 100.0!
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(83.3334!, 22.99999!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(366.6667!, 23.0!)
            Me.label5.Text = "label5"
            Me.label5.WordWrap = False
            '
            'label36
            '
            Me.label36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountToBill", "{0:n2}")})
            Me.label36.Dpi = 100.0!
            Me.label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(233.3334!, 9.999974!)
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label36.Summary = XrSummary2
            Me.label36.Text = "label20"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'pageInfo1
            '
            Me.pageInfo1.Dpi = 100.0!
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.Format = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 12.41665!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(271.875!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientName")})
            Me.label4.Dpi = 100.0!
            Me.label4.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(83.3334!, 0!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(366.6667!, 23.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "label4"
            Me.label4.WordWrap = False
            '
            'label34
            '
            Me.label34.Dpi = 100.0!
            Me.label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0!)
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.Text = "Client Comment"
            '
            'label9
            '
            Me.label9.Dpi = 100.0!
            Me.label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 0!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(83.33334!, 23.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "Client:"
            '
            'label25
            '
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentDescription")})
            Me.label25.Dpi = 100.0!
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(133.3333!, 23.00002!)
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(504.1667!, 23.00001!)
            Me.label25.Text = "label25"
            Me.label25.WordWrap = False
            '
            'label8
            '
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AECode")})
            Me.label8.Dpi = 100.0!
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(698.9585!, 22.99995!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(50.0!, 23.0!)
            Me.label8.WordWrap = False
            '
            'JobComponent_FooterJob
            '
            Me.JobComponent_FooterJob.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line6, Me.label39, Me.label35, Me.label36})
            Me.JobComponent_FooterJob.Dpi = 100.0!
            Me.JobComponent_FooterJob.HeightF = 50.0!
            Me.JobComponent_FooterJob.Level = 2
            Me.JobComponent_FooterJob.Name = "JobComponent_FooterJob"
            '
            'label39
            '
            Me.label39.Dpi = 100.0!
            Me.label39.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(146.875!, 23.0!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.Text = "Job Component Total:"
            '
            'label18
            '
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionType")})
            Me.label18.Dpi = 100.0!
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(30.0!, 23.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.Text = "label18"
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.BorderWidth = 1.0!
            Me.line2.Dpi = 100.0!
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LineWidth = 4
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 79.00003!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseBorderWidth = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label1
            '
            Me.label1.Dpi = 100.0!
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(302.0833!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Billing Approval Batch Report"
            '
            'JobComponent_HeaderComments
            '
            Me.JobComponent_HeaderComments.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label29, Me.label28, Me.label27, Me.label26})
            Me.JobComponent_HeaderComments.Dpi = 100.0!
            Me.JobComponent_HeaderComments.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobComponent_HeaderComments.HeightF = 54.33337!
            Me.JobComponent_HeaderComments.Level = 1
            Me.JobComponent_HeaderComments.Name = "JobComponent_HeaderComments"
            '
            'label28
            '
            Me.label28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalHeaderComment")})
            Me.label28.Dpi = 100.0!
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(122.9167!, 0!)
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(627.0833!, 23.0!)
            Me.label28.Text = "label28"
            '
            'label26
            '
            Me.label26.Dpi = 100.0!
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 0!)
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(122.9167!, 23.0!)
            Me.label26.Text = "Approval Comment:"
            '
            'label11
            '
            Me.label11.Dpi = 100.0!
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 45.99997!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(83.33334!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.Text = "Product:"
            '
            'label41
            '
            Me.label41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFlag")})
            Me.label41.Dpi = 100.0!
            Me.label41.ForeColor = System.Drawing.Color.SteelBlue
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(637.5!, 0!)
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(10.41681!, 23.0!)
            Me.label41.StylePriority.UseForeColor = False
            Me.label41.Visible = False
            '
            'line7
            '
            Me.line7.BackColor = System.Drawing.Color.Transparent
            Me.line7.BorderColor = System.Drawing.Color.Transparent
            Me.line7.BorderWidth = 1.0!
            Me.line7.Dpi = 100.0!
            Me.line7.ForeColor = System.Drawing.Color.LightGray
            Me.line7.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 70.2083!)
            Me.line7.Name = "line7"
            Me.line7.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line7.StylePriority.UseBackColor = False
            Me.line7.StylePriority.UseBorderColor = False
            Me.line7.StylePriority.UseBorderWidth = False
            Me.line7.StylePriority.UseForeColor = False
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeCode")})
            Me.label7.Dpi = 100.0!
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(698.9585!, 0!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(50.0!, 23.0!)
            Me.label7.WordWrap = False
            '
            'ClientDivisionProduct_Header
            '
            Me.ClientDivisionProduct_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line7, Me.label11, Me.label9, Me.label6, Me.label5, Me.label4, Me.label10})
            Me.ClientDivisionProduct_Header.Dpi = 100.0!
            Me.ClientDivisionProduct_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivisionProduct_Header.HeightF = 82.54163!
            Me.ClientDivisionProduct_Header.Level = 3
            Me.ClientDivisionProduct_Header.Name = "ClientDivisionProduct_Header"
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.label6.Dpi = 100.0!
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(83.3334!, 45.99997!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(366.6667!, 23.0!)
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'label10
            '
            Me.label10.Dpi = 100.0!
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 22.99999!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(83.33334!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Division:"
            '
            'label37
            '
            Me.label37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionAmount", "{0:n2}")})
            Me.label37.Dpi = 100.0!
            Me.label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(333.3333!, 0!)
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label37.Summary = XrSummary3
            Me.label37.Text = "label21"
            Me.label37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label40
            '
            Me.label40.Dpi = 100.0!
            Me.label40.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(146.875!, 23.0!)
            Me.label40.StylePriority.UseFont = False
            Me.label40.Text = "Batch Total:"
            '
            'label14
            '
            Me.label14.Dpi = 100.0!
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(83.33334!, 23.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.Text = "Job:"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label67, Me.label102, Me.label103, Me.label104, Me.label105, Me.label106, Me.line2, Me.label2, Me.label1, Me.line1})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 90.625!
            Me.PageHeader.Name = "PageHeader"
            '
            'label67
            '
            Me.label67.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.et_date_cutoff, "Text", "{0:M/d/yyyy}")})
            Me.label67.Dpi = 100.0!
            Me.label67.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label67.LocationFloat = New DevExpress.Utils.PointFloat(673.9586!, 10.00001!)
            Me.label67.Name = "label67"
            Me.label67.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label67.SizeF = New System.Drawing.SizeF(74.99994!, 23.0!)
            Me.label67.StylePriority.UseFont = False
            Me.label67.StylePriority.UseTextAlignment = False
            Me.label67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'et_date_cutoff
            '
            Me.et_date_cutoff.Description = "Employee Time Date"
            Me.et_date_cutoff.Name = "et_date_cutoff"
            Me.et_date_cutoff.Visible = False
            '
            'label102
            '
            Me.label102.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.io_date_cutoff, "Text", "{0:M/d/yyyy}")})
            Me.label102.Dpi = 100.0!
            Me.label102.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label102.LocationFloat = New DevExpress.Utils.PointFloat(673.9586!, 32.99999!)
            Me.label102.Name = "label102"
            Me.label102.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label102.SizeF = New System.Drawing.SizeF(74.99994!, 23.0!)
            Me.label102.StylePriority.UseFont = False
            Me.label102.StylePriority.UseTextAlignment = False
            Me.label102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label103
            '
            Me.label103.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.ap_pp_cutoff, "Text", "")})
            Me.label103.Dpi = 100.0!
            Me.label103.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label103.LocationFloat = New DevExpress.Utils.PointFloat(673.9586!, 56.00001!)
            Me.label103.Name = "label103"
            Me.label103.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label103.SizeF = New System.Drawing.SizeF(74.99994!, 23.0!)
            Me.label103.StylePriority.UseFont = False
            Me.label103.StylePriority.UseTextAlignment = False
            Me.label103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label104
            '
            Me.label104.Dpi = 100.0!
            Me.label104.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label104.LocationFloat = New DevExpress.Utils.PointFloat(552.0833!, 10.00001!)
            Me.label104.Name = "label104"
            Me.label104.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label104.SizeF = New System.Drawing.SizeF(121.8753!, 23.0!)
            Me.label104.StylePriority.UseFont = False
            Me.label104.Text = "Employee Time Date:"
            '
            'label105
            '
            Me.label105.Dpi = 100.0!
            Me.label105.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label105.LocationFloat = New DevExpress.Utils.PointFloat(552.0833!, 32.99999!)
            Me.label105.Name = "label105"
            Me.label105.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label105.SizeF = New System.Drawing.SizeF(121.8753!, 23.0!)
            Me.label105.StylePriority.UseFont = False
            Me.label105.Text = "Income Only Date:"
            '
            'label106
            '
            Me.label106.Dpi = 100.0!
            Me.label106.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label106.LocationFloat = New DevExpress.Utils.PointFloat(552.0833!, 56.00001!)
            Me.label106.Name = "label106"
            Me.label106.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label106.SizeF = New System.Drawing.SizeF(121.8753!, 23.0!)
            Me.label106.StylePriority.UseFont = False
            Me.label106.Text = "A/P Posting Period:"
            '
            'label2
            '
            Me.label2.Dpi = 100.0!
            Me.label2.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(302.0833!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "By Billing Approval Batch ID"
            '
            'JobComponent_HeaderJob
            '
            Me.JobComponent_HeaderJob.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label41, Me.label13, Me.label12, Me.label8, Me.label7, Me.label25, Me.label24, Me.label17, Me.label16, Me.label15, Me.label14})
            Me.JobComponent_HeaderJob.Dpi = 100.0!
            Me.JobComponent_HeaderJob.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobComponent_HeaderJob.HeightF = 54.33337!
            Me.JobComponent_HeaderJob.Level = 2
            Me.JobComponent_HeaderJob.Name = "JobComponent_HeaderJob"
            Me.JobComponent_HeaderJob.RepeatEveryPage = True
            '
            'label13
            '
            Me.label13.Dpi = 100.0!
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(647.9168!, 22.99995!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(51.04166!, 23.0!)
            Me.label13.Text = "A/E:"
            '
            'label12
            '
            Me.label12.Dpi = 100.0!
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(647.9168!, 0!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(51.04166!, 23.0!)
            Me.label12.Text = "Office:"
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentNumber", "{0:0000}")})
            Me.label24.Dpi = 100.0!
            Me.label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(83.33334!, 23.00002!)
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(50.0!, 23.0!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.Text = "label24"
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.label17.Dpi = 100.0!
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(133.3333!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(504.1667!, 23.0!)
            Me.label17.Text = "label17"
            Me.label17.WordWrap = False
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber", "{0:000000}")})
            Me.label16.Dpi = 100.0!
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(83.33334!, 0!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(50.0!, 23.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "label16"
            '
            'label15
            '
            Me.label15.Dpi = 100.0!
            Me.label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(83.33334!, 23.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.Text = "Component:"
            '
            'JobComponent_HeaderLabels
            '
            Me.JobComponent_HeaderLabels.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line4, Me.label34, Me.label33, Me.label32, Me.label31, Me.label30})
            Me.JobComponent_HeaderLabels.Dpi = 100.0!
            Me.JobComponent_HeaderLabels.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobComponent_HeaderLabels.HeightF = 31.25!
            Me.JobComponent_HeaderLabels.Name = "JobComponent_HeaderLabels"
            Me.JobComponent_HeaderLabels.RepeatEveryPage = True
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.Transparent
            Me.line4.BorderColor = System.Drawing.Color.Transparent
            Me.line4.BorderWidth = 1.0!
            Me.line4.Dpi = 100.0!
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 24.54166!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseBorderWidth = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label33
            '
            Me.label33.Dpi = 100.0!
            Me.label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0!)
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.Text = "Approval Comment"
            '
            'label31
            '
            Me.label31.Dpi = 100.0!
            Me.label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(233.3334!, 0!)
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.StylePriority.UseTextAlignment = False
            Me.label31.Text = "Amount to Bill"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label30
            '
            Me.label30.Dpi = 100.0!
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(233.3334!, 23.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.Text = "Function"
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.label19.Dpi = 100.0!
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(29.99999!, 0!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(203.3334!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "label19"
            Me.label19.WordWrap = False
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label38
            '
            Me.label38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountToBill", "{0:n2}")})
            Me.label38.Dpi = 100.0!
            Me.label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(233.3334!, 0!)
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label38.Summary = XrSummary4
            Me.label38.Text = "label20"
            Me.label38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'JobComponent
            '
            Me.JobComponent.Expression = "PadLeft([JobNumber],6,0)+'-'+PadLeft([ComponentNumber],4,0)"
            Me.JobComponent.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobComponent.Name = "JobComponent"
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label23, Me.label22, Me.label21, Me.label20, Me.label19, Me.label18})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 23.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionClientComment")})
            Me.label23.Dpi = 100.0!
            Me.label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0!)
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.Text = "label23"
            '
            'label22
            '
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionComment")})
            Me.label22.Dpi = 100.0!
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0!)
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.Text = "label22"
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionAmount", "{0:n2}")})
            Me.label21.Dpi = 100.0!
            Me.label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(333.3333!, 0!)
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.StylePriority.UseTextAlignment = False
            Me.label21.Text = "label21"
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountToBill", "{0:n2}")})
            Me.label20.Dpi = 100.0!
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(233.3334!, 0!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.StylePriority.UseTextAlignment = False
            Me.label20.Text = "label20"
            Me.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.line5, Me.pageInfo1})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 35.41667!
            Me.PageFooter.Name = "PageFooter"
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BillingApprovalBatchID_Footer
            '
            Me.BillingApprovalBatchID_Footer.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label40, Me.label37, Me.label38})
            Me.BillingApprovalBatchID_Footer.Dpi = 100.0!
            Me.BillingApprovalBatchID_Footer.HeightF = 23.0!
            Me.BillingApprovalBatchID_Footer.Level = 4
            Me.BillingApprovalBatchID_Footer.Name = "BillingApprovalBatchID_Footer"
            Me.BillingApprovalBatchID_Footer.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.BillingWorksheetProductionReport)
            '
            'BillingApprovalBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.BillingApprovalBatchID_Header, Me.JobComponent_HeaderJob, Me.JobComponent_HeaderComments, Me.JobComponent_FooterJob, Me.JobComponent_HeaderLabels, Me.BillingApprovalBatchID_Footer, Me.ClientDivisionProduct_Header})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobComponent, Me.BillingApprovalFlag})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "03 - Billing Approval Batch Report"
            Me.FilterString = "[BillingApprovalFlag] = 1b"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.ap_pp_cutoff, Me.et_date_cutoff, Me.io_date_cutoff})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.table1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents BillingApprovalBatchID_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents table1 As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents tableRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents tableCell1 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents tableCell2 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BillingApprovalFlag As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents io_date_cutoff As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line6 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ap_pp_cutoff As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponent_FooterJob As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponent_HeaderComments As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line7 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivisionProduct_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label67 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents et_date_cutoff As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label102 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label103 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label104 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label105 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label106 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponent_HeaderJob As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponent_HeaderLabels As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BillingApprovalBatchID_Footer As DevExpress.XtraReports.UI.GroupFooterBand
    End Class

End Namespace
