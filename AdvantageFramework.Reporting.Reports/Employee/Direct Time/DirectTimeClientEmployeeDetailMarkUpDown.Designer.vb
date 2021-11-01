Namespace Employee.DirectTime

    Partial Public Class DirectTimeClientEmployeeDetailMarkUpDown
        Private components As System.ComponentModel.IContainer
        Private _resources As System.Resources.ResourceManager
        Public Sub New()
            Me.InitializeComponent()
        End Sub
        Private ReadOnly Property resources() As System.Resources.ResourceManager
            Get
                If _resources Is Nothing Then
                    Dim resourceString As String = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" + "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" + "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAAAAAAAAAAAFBBRFBBRFC0AAAA"
                    Me._resources = New DevExpress.XtraReports.Serialization.XRResourceManager(resourceString)
                End If
                Return Me._resources
            End Get
        End Property
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BillStatus = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.END_DATE = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.START_DATE = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.ClientDivisionProduct_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AdjustmentCommentsHide = New DevExpress.XtraReports.UI.FormattingRule()
            Me.Employee_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DateAdjusted = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.JobOffice_Footer = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DateString = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line7 = New DevExpress.XtraReports.UI.XRLine()
            Me.Employee_Footer = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivisionProduct_Footer = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobOffice_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label50 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.DetailSummaryGroup = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.DetailSummaryGroup_Header = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.controlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Client - Employee Detail"
            '
            'BillStatus
            '
            Me.BillStatus.Expression = "IIf([Billed] = 'Yes','B',IIf([IsFeeTime]='Yes','F',IIf([NonBillable]='Yes','N',''" &
    ")))"
            Me.BillStatus.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.BillStatus.Name = "BillStatus"
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 32.99999!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.Text = "Include Markup/Down:  Yes"
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.END_DATE, "Text", "{0:MM/dd/yyyy}")})
            Me.label19.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(680.0!, 10.00001!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(70.0!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "label19"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'END_DATE
            '
            Me.END_DATE.Description = "End Date"
            Me.END_DATE.Name = "END_DATE"
            Me.END_DATE.Type = GetType(Date)
            Me.END_DATE.Visible = False
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillStatus")})
            Me.label16.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(523.9582!, 0!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(25.0!, 23.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = "label16"
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            Me.label16.WordWrap = False
            '
            'label36
            '
            Me.label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.StylePriority.UseTextAlignment = False
            Me.label36.Text = "Total Employee:"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeLastFirst")})
            Me.label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0!)
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(176.0417!, 23.0!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label27.WordWrap = False
            '
            'label24
            '
            Me.label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(54.16667!, 23.0!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "Office: "
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label18
            '
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.START_DATE, "Text", "{0:MM/dd/yyyy}")})
            Me.label18.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(587.0833!, 10.00001!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(70.0!, 23.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'START_DATE
            '
            Me.START_DATE.Description = "Start Date"
            Me.START_DATE.Name = "START_DATE"
            Me.START_DATE.Type = GetType(Date)
            Me.START_DATE.Visible = False
            '
            'label48
            '
            Me.label48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.label48.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(649.5833!, 0!)
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label48.StylePriority.UseFont = False
            Me.label48.StylePriority.UseTextAlignment = False
            Me.label48.Text = "label48"
            Me.label48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ClientDivisionProduct_Header
            '
            Me.ClientDivisionProduct_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label48, Me.label47, Me.label46, Me.label45, Me.label37, Me.label3})
            Me.ClientDivisionProduct_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivisionProduct_Header.HeightF = 23.0!
            Me.ClientDivisionProduct_Header.Level = 1
            Me.ClientDivisionProduct_Header.Name = "ClientDivisionProduct_Header"
            Me.ClientDivisionProduct_Header.RepeatEveryPage = True
            '
            'label47
            '
            Me.label47.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.label47.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(472.4998!, 0!)
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label47.StylePriority.UseFont = False
            Me.label47.StylePriority.UseTextAlignment = False
            Me.label47.Text = "label47"
            Me.label47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label46
            '
            Me.label46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(587.0833!, 0!)
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(62.5!, 23.0!)
            Me.label46.StylePriority.UseFont = False
            Me.label46.StylePriority.UseTextAlignment = False
            Me.label46.Text = "Product:"
            Me.label46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label45
            '
            Me.label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(409.9998!, 0!)
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(62.5!, 23.0!)
            Me.label45.StylePriority.UseFont = False
            Me.label45.StylePriority.UseTextAlignment = False
            Me.label45.Text = "Division:"
            Me.label45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label37
            '
            Me.label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(54.16667!, 23.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.StylePriority.UseTextAlignment = False
            Me.label37.Text = "Client:"
            Me.label37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(54.16667!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(336.4583!, 23.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.StylePriority.UseTextAlignment = False
            Me.label3.Text = "label3"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label51
            '
            Me.label51.CanShrink = True
            Me.label51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdjustmentComments")})
            Me.label51.FormattingRules.Add(Me.AdjustmentCommentsHide)
            Me.label51.LocationFloat = New DevExpress.Utils.PointFloat(329.9999!, 0!)
            Me.label51.Name = "label51"
            Me.label51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label51.SizeF = New System.Drawing.SizeF(220.0!, 13.0!)
            '
            'AdjustmentCommentsHide
            '
            Me.AdjustmentCommentsHide.Condition = "IsNullOrEmpty([AdjustmentComments])"
            Me.AdjustmentCommentsHide.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.AdjustmentCommentsHide.Name = "AdjustmentCommentsHide"
            '
            'Employee_Header
            '
            Me.Employee_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label49, Me.label27})
            Me.Employee_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Employee_Header.HeightF = 23.0!
            Me.Employee_Header.Level = 2
            Me.Employee_Header.Name = "Employee_Header"
            Me.Employee_Header.RepeatEveryPage = True
            '
            'label49
            '
            Me.label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label49.Name = "label49"
            Me.label49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label49.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label49.StylePriority.UseFont = False
            Me.label49.StylePriority.UseTextAlignment = False
            Me.label49.Text = "Employee:"
            Me.label49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'DateAdjusted
            '
            Me.DateAdjusted.Expression = "Concat([DateString],' Adjusted ' )"
            Me.DateAdjusted.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DateAdjusted.Name = "DateAdjusted"
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours", "{0:n2}")})
            Me.label11.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 0!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary1
            Me.label11.Text = "label11"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.label11.WordWrap = False
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LineWidth = 4.0!
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 9.999974!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'JobOffice_Footer
            '
            Me.JobOffice_Footer.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label42, Me.label43, Me.label44})
            Me.JobOffice_Footer.HeightF = 37.5!
            Me.JobOffice_Footer.Level = 3
            Me.JobOffice_Footer.Name = "JobOffice_Footer"
            Me.JobOffice_Footer.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'label42
            '
            Me.label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label42.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label42.Name = "label42"
            Me.label42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label42.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label42.StylePriority.UseFont = False
            Me.label42.StylePriority.UseTextAlignment = False
            Me.label42.Text = "Total Office:"
            Me.label42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label43
            '
            Me.label43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
            Me.label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label43.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label43.Name = "label43"
            Me.label43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label43.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label43.StylePriority.UseFont = False
            Me.label43.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label43.Summary = XrSummary2
            Me.label43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label44
            '
            Me.label44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours", "{0:n2}")})
            Me.label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label44.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label44.Name = "label44"
            Me.label44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label44.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label44.StylePriority.UseFont = False
            Me.label44.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label44.Summary = XrSummary3
            Me.label44.Text = "label4"
            Me.label44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'DateString
            '
            Me.DateString.Expression = "ToStr(GetMonth([Date])+'/'+GetDay([Date])+'/'+GetYear([Date]))"
            Me.DateString.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DateString.Name = "DateString"
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "Total Report:"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label9
            '
            Me.label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 34.45832!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "Hours"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label22
            '
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UserID")})
            Me.label22.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 17.00001!)
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(349.9999!, 23.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "label22"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            Me.label22.Visible = False
            '
            'label29
            '
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeamCode")})
            Me.label29.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(409.9998!, 0!)
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(48.95834!, 23.0!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.StylePriority.UseTextAlignment = False
            Me.label29.Text = "label29"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label29.WordWrap = False
            '
            'label39
            '
            Me.label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(288.0!, 34.46!)
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(118.9582!, 22.9983!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.StylePriority.UseTextAlignment = False
            Me.label39.Text = "Function"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label35
            '
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
            Me.label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label35.Summary = XrSummary4
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'line7
            '
            Me.line7.BackColor = System.Drawing.Color.Transparent
            Me.line7.BorderColor = System.Drawing.Color.LightGray
            Me.line7.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            Me.line7.ForeColor = System.Drawing.Color.LightGray
            Me.line7.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
            Me.line7.Name = "line7"
            Me.line7.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line7.StylePriority.UseBackColor = False
            Me.line7.StylePriority.UseBorderColor = False
            Me.line7.StylePriority.UseBorderDashStyle = False
            Me.line7.StylePriority.UseForeColor = False
            '
            'Employee_Footer
            '
            Me.Employee_Footer.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line7, Me.label34, Me.label35, Me.label36})
            Me.Employee_Footer.HeightF = 37.5!
            Me.Employee_Footer.Level = 2
            Me.Employee_Footer.Name = "Employee_Footer"
            '
            'label34
            '
            Me.label34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours", "{0:n2}")})
            Me.label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label34.Summary = XrSummary5
            Me.label34.Text = "label4"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'ClientDivisionProduct_Footer
            '
            Me.ClientDivisionProduct_Footer.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label7, Me.label4, Me.label5})
            Me.ClientDivisionProduct_Footer.HeightF = 39.58333!
            Me.ClientDivisionProduct_Footer.Level = 1
            Me.ClientDivisionProduct_Footer.Name = "ClientDivisionProduct_Footer"
            '
            'label7
            '
            Me.label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 0!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            Me.label7.Text = "Total Client/Division/Product:"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours", "{0:n2}")})
            Me.label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label4.Summary = XrSummary6
            Me.label4.Text = "label4"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
            Me.label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label5.Summary = XrSummary7
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.label26.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0!)
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(205.0001!, 23.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "label26"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label26.WordWrap = False
            '
            'label40
            '
            Me.label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(409.9998!, 34.45832!)
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(48.95834!, 23.0!)
            Me.label40.StylePriority.UseFont = False
            Me.label40.StylePriority.UseTextAlignment = False
            Me.label40.Text = "Dept."
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label25
            '
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponent")})
            Me.label25.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "label25"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label25.WordWrap = False
            '
            'label28
            '
            Me.label28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.label28.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(288.0!, 0!)
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(118.9582!, 23.0!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseTextAlignment = False
            Me.label28.Text = "label28"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label28.WordWrap = False
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
            Me.label12.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(649.9999!, 0!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary8
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.label12.WordWrap = False
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label22, Me.pageInfo2, Me.pageInfo1, Me.line3})
            Me.PageFooter.HeightF = 42.70833!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 17.00001!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00001!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.StylePriority.UseTextAlignment = False
            Me.pageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.pageInfo1.TextFormatString = "{0:dddd, MMMM dd, yyyy}"
            '
            'label30
            '
            Me.label30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountExecutiveCode")})
            Me.label30.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(458.9582!, 0!)
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "label30"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label30.WordWrap = False
            '
            'JobOffice_Header
            '
            Me.JobOffice_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label41, Me.label40, Me.label39, Me.label15, Me.label10, Me.label9, Me.label8, Me.line4, Me.label24, Me.label23})
            Me.JobOffice_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobOfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobOffice_Header.HeightF = 65.625!
            Me.JobOffice_Header.Level = 3
            Me.JobOffice_Header.Name = "JobOffice_Header"
            Me.JobOffice_Header.RepeatEveryPage = True
            '
            'label41
            '
            Me.label41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(458.9582!, 34.45832!)
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label41.StylePriority.UseFont = False
            Me.label41.StylePriority.UseTextAlignment = False
            Me.label41.Text = "AE"
            Me.label41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'label15
            '
            Me.label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(523.9582!, 34.45832!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(25.0!, 23.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.StylePriority.UseTextAlignment = False
            Me.label15.Text = "Bill"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'label10
            '
            Me.label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(649.9999!, 34.45832!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "Total Amount"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.45832!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(280.0001!, 23.0!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.StylePriority.UseTextAlignment = False
            Me.label8.Text = "Job"
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LineWidth = 4.0!
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 57.45831!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobOfficeCode")})
            Me.label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(54.16667!, 0!)
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "label23"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label51, Me.label50})
            Me.Detail.FormattingRules.Add(Me.AdjustmentCommentsHide)
            Me.Detail.HeightF = 15.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label50
            '
            Me.label50.CanShrink = True
            Me.label50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateAdjusted")})
            Me.label50.FormattingRules.Add(Me.AdjustmentCommentsHide)
            Me.label50.LocationFloat = New DevExpress.Utils.PointFloat(205.0!, 0!)
            Me.label50.Name = "label50"
            Me.label50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label50.SizeF = New System.Drawing.SizeF(125.0!, 13.0!)
            Me.label50.Text = "label50"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17, Me.label13, Me.label14})
            Me.ReportFooter.HeightF = 23.95833!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours", "{0:n2}")})
            Me.label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0.00006357829!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label13.Summary = XrSummary9
            Me.label13.Text = "label4"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
            Me.label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.00006357829!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label14.Summary = XrSummary10
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'DetailSummaryGroup
            '
            Me.DetailSummaryGroup.Expression = "[JobComponent] +' '+ PadLeft([FunctionCode],6,0) +' '+PadLeft([DepartmentTeamCode" &
    "],6,0)+' '+[BillStatus]"
            Me.DetailSummaryGroup.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DetailSummaryGroup.Name = "DetailSummaryGroup"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(657.0833!, 10.00001!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(22.91669!, 23.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.StylePriority.UseTextAlignment = False
            Me.label20.Text = "To"
            Me.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LineWidth = 4.0!
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Direct Time Activity Report"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label6, Me.label21, Me.label20, Me.label19, Me.label18, Me.label2, Me.label1, Me.line2, Me.line1})
            Me.PageHeader.HeightF = 67.70837!
            Me.PageHeader.Name = "PageHeader"
            '
            'label21
            '
            Me.label21.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(550.4166!, 10.00001!)
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(36.66675!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.StylePriority.UseTextAlignment = False
            Me.label21.Text = "From"
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LineWidth = 4.0!
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'DetailSummaryGroup_Header
            '
            Me.DetailSummaryGroup_Header.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label30, Me.label29, Me.label28, Me.label26, Me.label12, Me.label11, Me.label16, Me.label25})
            Me.DetailSummaryGroup_Header.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("DetailSummaryGroup", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.DetailSummaryGroup_Header.HeightF = 23.0!
            Me.DetailSummaryGroup_Header.Name = "DetailSummaryGroup_Header"
            '
            'controlStyle1
            '
            Me.controlStyle1.Name = "controlStyle1"
            Me.controlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.DirectTimeReport)
            '
            'DirectTimeClientEmployeeDetailMarkUpDown
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.ClientDivisionProduct_Header, Me.ClientDivisionProduct_Footer, Me.JobOffice_Header, Me.JobOffice_Footer, Me.DetailSummaryGroup_Header, Me.Employee_Header, Me.Employee_Footer})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BillStatus, Me.DetailSummaryGroup, Me.DateString, Me.DateAdjusted})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "03-Direct Time by Client-Employee Detail wMrkUpDn"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.AdjustmentCommentsHide})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.START_DATE, Me.END_DATE})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.controlStyle1})
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BillStatus As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents END_DATE As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents START_DATE As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label48 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents ClientDivisionProduct_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label47 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label46 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label45 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label51 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents AdjustmentCommentsHide As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents Employee_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label49 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DateAdjusted As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents JobOffice_Footer As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label42 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label43 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label44 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DateString As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line7 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents Employee_Footer As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivisionProduct_Footer As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobOffice_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label50 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents DetailSummaryGroup As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents DetailSummaryGroup_Header As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents controlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






