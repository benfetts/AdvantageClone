Namespace Employee.DirectIndirectTime

    Partial Public Class HoursWorkedSummaryByEmployee
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.EmployeeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.EmployeeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DateHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EmployeeName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DateCriteria = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DateType = New DevExpress.XtraReports.Parameters.Parameter()
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label31, Me.label30, Me.label29, Me.label27, Me.label23, Me.label18, Me.label17, Me.line2, Me.line1, Me.label10, Me.label9})
            Me.PageHeader.HeightF = 94.79163!
            Me.PageHeader.Name = "PageHeader"
            '
            'label31
            '
            Me.label31.CanGrow = False
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.EndDate, "Text", "")})
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(684.9999!, 29.87499!)
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(65.0!, 21.95833!)
            Me.label31.StylePriority.UseTextAlignment = False
            Me.label31.Text = "label31"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:M/d/yyyy}"
            Me.label31.WordWrap = False
            '
            'EndDate
            '
            Me.EndDate.Description = "End Date"
            Me.EndDate.Name = "EndDate"
            Me.EndDate.Type = GetType(Date)
            Me.EndDate.Visible = False
            '
            'label30
            '
            Me.label30.CanGrow = False
            Me.label30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.StartDate, "Text", "")})
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(684.9999!, 6.874975!)
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(65.0!, 21.95834!)
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "label30"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label30.TextFormatString = "{0:M/d/yyyy}"
            Me.label30.WordWrap = False
            '
            'StartDate
            '
            Me.StartDate.Description = "Start Date"
            Me.StartDate.Name = "StartDate"
            Me.StartDate.Type = GetType(Date)
            Me.StartDate.Visible = False
            '
            'label29
            '
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 29.87499!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(136.0414!, 21.95833!)
            Me.label29.StylePriority.UseTextAlignment = False
            Me.label29.Text = "To: "
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateCriteria")})
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(548.9584!, 6.875006!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(136.0413!, 23.0!)
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "label27"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(674.9999!, 63.20836!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(74.99994!, 22.99999!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "Hours"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(253.125!, 63.20836!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.Text = "Date"
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(0!, 63.20836!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.Text = "Employee"
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 86.20834!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label10
            '
            Me.label10.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(0!, 28.83333!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(315.625!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Hours Worked - Summary by Employee"
            '
            'label9
            '
            Me.label9.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.83334!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(315.625!, 23.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "Employee Time Report"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label26, Me.line3, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.HeightF = 32.99997!
            Me.PageFooter.Name = "PageFooter"
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UserID")})
            Me.label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(253.125!, 9.999974!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(247.9165!, 23.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "label26"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(501.0416!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(248.9583!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(253.125!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'EmployeeHeader
            '
            Me.EmployeeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Employee", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.EmployeeHeader.HeightF = 0!
            Me.EmployeeHeader.Level = 1
            Me.EmployeeHeader.Name = "EmployeeHeader"
            '
            'EmployeeFooter
            '
            Me.EmployeeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label13, Me.label12, Me.label11})
            Me.EmployeeFooter.HeightF = 50.0!
            Me.EmployeeFooter.Level = 1
            Me.EmployeeFooter.Name = "EmployeeFooter"
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours")})
            Me.label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 9.999974!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary1
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:n2}"
            Me.label13.WordWrap = False
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeName")})
            Me.label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(413.5414!, 9.999974!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(261.4584!, 23.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.TextFormatString = "{0:M/d/yyyy}"
            Me.label12.WordWrap = False
            '
            'label11
            '
            Me.label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(349.9583!, 9.999974!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(63.58322!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.Text = "Total For "
            '
            'DateHeader
            '
            Me.DateHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label8, Me.label2, Me.label1})
            Me.DateHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Date", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.DateHeader.HeightF = 23.0!
            Me.DateHeader.Name = "DateHeader"
            '
            'label8
            '
            Me.label8.CanGrow = False
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Hours")})
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(674.9999!, 0!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label8.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label8.Summary = XrSummary2
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label8.TextFormatString = "{0:n2}"
            Me.label8.WordWrap = False
            '
            'label2
            '
            Me.label2.CanGrow = False
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Date")})
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(253.125!, 0!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label2.Text = "label2"
            Me.label2.TextFormatString = "{0:M/d/yyyy}"
            Me.label2.WordWrap = False
            '
            'label1
            '
            Me.label1.CanGrow = False
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeName")})
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Suppress
            Me.label1.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label1.Text = "label1"
            Me.label1.WordWrap = False
            '
            'EmployeeName
            '
            Me.EmployeeName.Expression = "Concat([EmployeeFirstName],' ',[EmployeeLastName])"
            Me.EmployeeName.Name = "EmployeeName"
            '
            'DateCriteria
            '
            Me.DateCriteria.Expression = "IIf([Parameters].[DateType]=1,'Date From:',IIf([Parameters].[DateType]=2,'Date En" &
    "tered From:',IIf([Parameters].[DateType]=3,'Approval Date From:','')))"
            Me.DateCriteria.Name = "DateCriteria"
            '
            'DateType
            '
            Me.DateType.Description = "Date Type"
            Me.DateType.Name = "DateType"
            Me.DateType.Type = GetType(Short)
            Me.DateType.ValueInfo = "1"
            Me.DateType.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.DirectIndirectTimeReport)
            '
            'HoursWorkedSummaryByEmployee
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.EmployeeHeader, Me.EmployeeFooter, Me.DateHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.EmployeeName, Me.DateCriteria})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Hours Worked - Summary by Employee"
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.DateType, Me.StartDate, Me.EndDate})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents EmployeeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents EmployeeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DateHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EmployeeName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents DateCriteria As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents DateType As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






