Namespace GeneralLedger.JournalEntry

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class RecurringJournalEntryPostReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrTable = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellGLACode = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellGLADescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellDebit = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellCredit = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellClientCode = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellDivisionCode = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellProductCode = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellRemarks = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLabelPageHeader_AgencyName = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfoPageFooter_Date = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrLabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfoPageFooter_Page = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrPageInfoGroupHeader_Date = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrLabelGroupHeader_TransactionNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TransactionNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_RemarksLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ProductLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_DivisionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_DebitLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CreditLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_GLAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineGroupHeader_TopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineGroupHeader_BottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelGroupHeader_Reversing = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ReversingLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLineGroupFooter_Line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineGroupFooter_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelGroupFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_Credit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_Debit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrControlStyleEvenRows = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.GroupHeaderBand = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLineGroupHeaderBand_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterBand = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelGroupFooter_BatchTotalCredit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_BatchTotalDebit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_BatchTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.XrTable, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable})
            Me.Detail.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Detail.HeightF = 21.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SequenceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrTable
            '
            Me.XrTable.EvenStyleName = "XrControlStyleEvenRows"
            Me.XrTable.LocationFloat = New DevExpress.Utils.PointFloat(10.00004!, 0!)
            Me.XrTable.Name = "XrTable"
            Me.XrTable.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow})
            Me.XrTable.SizeF = New System.Drawing.SizeF(989.9999!, 20.0!)
            '
            'XrTableRow
            '
            Me.XrTableRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellGLACode, Me.XrTableCellGLADescription, Me.XrTableCellDebit, Me.XrTableCellCredit, Me.XrTableCellClientCode, Me.XrTableCellDivisionCode, Me.XrTableCellProductCode, Me.XrTableCellRemarks})
            Me.XrTableRow.Name = "XrTableRow"
            Me.XrTableRow.Weight = 1.0R
            '
            'XrTableCellGLACode
            '
            Me.XrTableCellGLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.XrTableCellGLACode.Multiline = True
            Me.XrTableCellGLACode.Name = "XrTableCellGLACode"
            Me.XrTableCellGLACode.Weight = 1.0531268980036239R
            '
            'XrTableCellGLADescription
            '
            Me.XrTableCellGLADescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccountDescription")})
            Me.XrTableCellGLADescription.Multiline = True
            Me.XrTableCellGLADescription.Name = "XrTableCellGLADescription"
            Me.XrTableCellGLADescription.Weight = 3.05407053771478R
            '
            'XrTableCellDebit
            '
            Me.XrTableCellDebit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Debit")})
            Me.XrTableCellDebit.Multiline = True
            Me.XrTableCellDebit.Name = "XrTableCellDebit"
            Me.XrTableCellDebit.StylePriority.UseTextAlignment = False
            Me.XrTableCellDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellDebit.TextFormatString = "{0:n2}"
            Me.XrTableCellDebit.Weight = 1.0531274756311619R
            '
            'XrTableCellCredit
            '
            Me.XrTableCellCredit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Credit")})
            Me.XrTableCellCredit.Multiline = True
            Me.XrTableCellCredit.Name = "XrTableCellCredit"
            Me.XrTableCellCredit.StylePriority.UseTextAlignment = False
            Me.XrTableCellCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellCredit.TextFormatString = "{0:n2}"
            Me.XrTableCellCredit.Weight = 1.0531256284477062R
            '
            'XrTableCellClientCode
            '
            Me.XrTableCellClientCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.XrTableCellClientCode.Multiline = True
            Me.XrTableCellClientCode.Name = "XrTableCellClientCode"
            Me.XrTableCellClientCode.Weight = 0.52656504146275029R
            '
            'XrTableCellDivisionCode
            '
            Me.XrTableCellDivisionCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.XrTableCellDivisionCode.Multiline = True
            Me.XrTableCellDivisionCode.Name = "XrTableCellDivisionCode"
            Me.XrTableCellDivisionCode.Weight = 0.52656375630836161R
            '
            'XrTableCellProductCode
            '
            Me.XrTableCellProductCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.XrTableCellProductCode.Multiline = True
            Me.XrTableCellProductCode.Name = "XrTableCellProductCode"
            Me.XrTableCellProductCode.Weight = 0.5265637964819907R
            '
            'XrTableCellRemarks
            '
            Me.XrTableCellRemarks.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Remark")})
            Me.XrTableCellRemarks.Multiline = True
            Me.XrTableCellRemarks.Name = "XrTableCellRemarks"
            Me.XrTableCellRemarks.Weight = 2.6328192590352208R
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 25.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 25.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelPageHeader_AgencyName, Me.XrLabelPageHeader_Title})
            Me.PageHeader.HeightF = 51.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLabelPageHeader_AgencyName
            '
            Me.XrLabelPageHeader_AgencyName.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelPageHeader_AgencyName.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 10.00001!)
            Me.XrLabelPageHeader_AgencyName.Name = "XrLabelPageHeader_AgencyName"
            Me.XrLabelPageHeader_AgencyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelPageHeader_AgencyName.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
            Me.XrLabelPageHeader_AgencyName.StylePriority.UseFont = False
            Me.XrLabelPageHeader_AgencyName.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_AgencyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelPageHeader_Title
            '
            Me.XrLabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 10.00001!)
            Me.XrLabelPageHeader_Title.Name = "XrLabelPageHeader_Title"
            Me.XrLabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelPageHeader_Title.SizeF = New System.Drawing.SizeF(589.9996!, 39.99999!)
            Me.XrLabelPageHeader_Title.StylePriority.UseFont = False
            Me.XrLabelPageHeader_Title.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_Title.Text = "Recurring Journal Entry - Batch Report"
            Me.XrLabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrPageInfoPageFooter_Date
            '
            Me.XrPageInfoPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrPageInfoPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.XrPageInfoPageFooter_Date.Name = "XrPageInfoPageFooter_Date"
            Me.XrPageInfoPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfoPageFooter_Date.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.XrPageInfoPageFooter_Date.SizeF = New System.Drawing.SizeF(300.0!, 20.0!)
            Me.XrPageInfoPageFooter_Date.StylePriority.UseFont = False
            Me.XrPageInfoPageFooter_Date.TextFormatString = "{0:dddd, MMMM dd, yyyy h:mm:ss tt}"
            '
            'XrLabelPageFooter_UserCode
            '
            Me.XrLabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 9.999974!)
            Me.XrLabelPageFooter_UserCode.Name = "XrLabelPageFooter_UserCode"
            Me.XrLabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelPageFooter_UserCode.StylePriority.UseFont = False
            '
            'XrPageInfoPageFooter_Page
            '
            Me.XrPageInfoPageFooter_Page.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrPageInfoPageFooter_Page.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 9.999974!)
            Me.XrPageInfoPageFooter_Page.Name = "XrPageInfoPageFooter_Page"
            Me.XrPageInfoPageFooter_Page.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfoPageFooter_Page.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrPageInfoPageFooter_Page.StylePriority.UseFont = False
            Me.XrPageInfoPageFooter_Page.TextFormatString = "Page {0} of {1}"
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfoGroupHeader_Date, Me.XrLabelGroupHeader_TransactionNumber, Me.XrLabelGroupHeader_TransactionNumberLabel, Me.XrLabelGroupHeader_Description, Me.XrLabelGroupHeader_RemarksLabel, Me.XrLabelGroupHeader_ProductLabel, Me.XrLabelGroupHeader_DivisionLabel, Me.XrLabelGroupHeader_DebitLabel, Me.XrLabelGroupHeader_CreditLabel, Me.XrLabelGroupHeader_ClientLabel, Me.XrLabelGroupHeader_GLAccountLabel, Me.XrLineGroupHeader_TopLine, Me.XrLineGroupHeader_BottomLine, Me.XrLabelGroupHeader_Reversing, Me.XrLabelGroupHeader_ReversingLabel, Me.XrLabelGroupHeader_ControlAmount, Me.XrLabelGroupHeader_ControlAmountLabel, Me.XrLabelGroupHeader_DateLabel, Me.XrLabelGroupHeader_ControlNumber, Me.XrLabelGroupHeader_ControlNumberLabel})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ControlNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 71.20835!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrPageInfoGroupHeader_Date
            '
            Me.XrPageInfoGroupHeader_Date.LocationFloat = New DevExpress.Utils.PointFloat(664.9995!, 0!)
            Me.XrPageInfoGroupHeader_Date.Name = "XrPageInfoGroupHeader_Date"
            Me.XrPageInfoGroupHeader_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfoGroupHeader_Date.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.XrPageInfoGroupHeader_Date.SizeF = New System.Drawing.SizeF(131.25!, 20.0!)
            Me.XrPageInfoGroupHeader_Date.StylePriority.UseFont = False
            Me.XrPageInfoGroupHeader_Date.TextFormatString = "{0:d}"
            '
            'XrLabelGroupHeader_TransactionNumber
            '
            Me.XrLabelGroupHeader_TransactionNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.XrLabelGroupHeader_TransactionNumber.LocationFloat = New DevExpress.Utils.PointFloat(135.0001!, 20.00001!)
            Me.XrLabelGroupHeader_TransactionNumber.Name = "XrLabelGroupHeader_TransactionNumber"
            Me.XrLabelGroupHeader_TransactionNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionNumber.SizeF = New System.Drawing.SizeF(60.00009!, 19.99999!)
            Me.XrLabelGroupHeader_TransactionNumber.TextFormatString = "{0:00000#}"
            '
            'XrLabelGroupHeader_TransactionNumberLabel
            '
            Me.XrLabelGroupHeader_TransactionNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_TransactionNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.XrLabelGroupHeader_TransactionNumberLabel.Name = "XrLabelGroupHeader_TransactionNumberLabel"
            Me.XrLabelGroupHeader_TransactionNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionNumberLabel.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
            Me.XrLabelGroupHeader_TransactionNumberLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_TransactionNumberLabel.Text = "Transaction Number:"
            '
            'XrLabelGroupHeader_Description
            '
            Me.XrLabelGroupHeader_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransactionDescription")})
            Me.XrLabelGroupHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(195.0002!, 0!)
            Me.XrLabelGroupHeader_Description.Multiline = True
            Me.XrLabelGroupHeader_Description.Name = "XrLabelGroupHeader_Description"
            Me.XrLabelGroupHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Description.SizeF = New System.Drawing.SizeF(404.9996!, 20.00001!)
            '
            'XrLabelGroupHeader_RemarksLabel
            '
            Me.XrLabelGroupHeader_RemarksLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_RemarksLabel.LocationFloat = New DevExpress.Utils.PointFloat(750.0!, 48.00002!)
            Me.XrLabelGroupHeader_RemarksLabel.Multiline = True
            Me.XrLabelGroupHeader_RemarksLabel.Name = "XrLabelGroupHeader_RemarksLabel"
            Me.XrLabelGroupHeader_RemarksLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_RemarksLabel.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
            Me.XrLabelGroupHeader_RemarksLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_RemarksLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_RemarksLabel.Text = "Remarks"
            Me.XrLabelGroupHeader_RemarksLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupHeader_ProductLabel
            '
            Me.XrLabelGroupHeader_ProductLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ProductLabel.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 48.00002!)
            Me.XrLabelGroupHeader_ProductLabel.Multiline = True
            Me.XrLabelGroupHeader_ProductLabel.Name = "XrLabelGroupHeader_ProductLabel"
            Me.XrLabelGroupHeader_ProductLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ProductLabel.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
            Me.XrLabelGroupHeader_ProductLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ProductLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ProductLabel.Text = "Product"
            Me.XrLabelGroupHeader_ProductLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupHeader_DivisionLabel
            '
            Me.XrLabelGroupHeader_DivisionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_DivisionLabel.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 48.00002!)
            Me.XrLabelGroupHeader_DivisionLabel.Multiline = True
            Me.XrLabelGroupHeader_DivisionLabel.Name = "XrLabelGroupHeader_DivisionLabel"
            Me.XrLabelGroupHeader_DivisionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_DivisionLabel.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
            Me.XrLabelGroupHeader_DivisionLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_DivisionLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_DivisionLabel.Text = "Division"
            Me.XrLabelGroupHeader_DivisionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupHeader_DebitLabel
            '
            Me.XrLabelGroupHeader_DebitLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_DebitLabel.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 48.00002!)
            Me.XrLabelGroupHeader_DebitLabel.Multiline = True
            Me.XrLabelGroupHeader_DebitLabel.Name = "XrLabelGroupHeader_DebitLabel"
            Me.XrLabelGroupHeader_DebitLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_DebitLabel.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_DebitLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_DebitLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_DebitLabel.Text = "Debit"
            Me.XrLabelGroupHeader_DebitLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'XrLabelGroupHeader_CreditLabel
            '
            Me.XrLabelGroupHeader_CreditLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_CreditLabel.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 48.00002!)
            Me.XrLabelGroupHeader_CreditLabel.Multiline = True
            Me.XrLabelGroupHeader_CreditLabel.Name = "XrLabelGroupHeader_CreditLabel"
            Me.XrLabelGroupHeader_CreditLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CreditLabel.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_CreditLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CreditLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CreditLabel.Text = "Credit"
            Me.XrLabelGroupHeader_CreditLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'XrLabelGroupHeader_ClientLabel
            '
            Me.XrLabelGroupHeader_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 48.00002!)
            Me.XrLabelGroupHeader_ClientLabel.Multiline = True
            Me.XrLabelGroupHeader_ClientLabel.Name = "XrLabelGroupHeader_ClientLabel"
            Me.XrLabelGroupHeader_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ClientLabel.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
            Me.XrLabelGroupHeader_ClientLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ClientLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ClientLabel.Text = "Client"
            Me.XrLabelGroupHeader_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupHeader_GLAccountLabel
            '
            Me.XrLabelGroupHeader_GLAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_GLAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 48.00002!)
            Me.XrLabelGroupHeader_GLAccountLabel.Multiline = True
            Me.XrLabelGroupHeader_GLAccountLabel.Name = "XrLabelGroupHeader_GLAccountLabel"
            Me.XrLabelGroupHeader_GLAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_GLAccountLabel.SizeF = New System.Drawing.SizeF(390.0!, 20.0!)
            Me.XrLabelGroupHeader_GLAccountLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_GLAccountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_GLAccountLabel.Text = "G/L Account"
            Me.XrLabelGroupHeader_GLAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLineGroupHeader_TopLine
            '
            Me.XrLineGroupHeader_TopLine.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_TopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeader_TopLine.BorderWidth = 1.0!
            Me.XrLineGroupHeader_TopLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_TopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 45.00001!)
            Me.XrLineGroupHeader_TopLine.Name = "XrLineGroupHeader_TopLine"
            Me.XrLineGroupHeader_TopLine.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLineGroupHeader_BottomLine
            '
            Me.XrLineGroupHeader_BottomLine.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_BottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeader_BottomLine.BorderWidth = 1.0!
            Me.XrLineGroupHeader_BottomLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_BottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.00008!)
            Me.XrLineGroupHeader_BottomLine.Name = "XrLineGroupHeader_BottomLine"
            Me.XrLineGroupHeader_BottomLine.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLabelGroupHeader_Reversing
            '
            Me.XrLabelGroupHeader_Reversing.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Reversing")})
            Me.XrLabelGroupHeader_Reversing.LocationFloat = New DevExpress.Utils.PointFloat(878.5413!, 20.00001!)
            Me.XrLabelGroupHeader_Reversing.Name = "XrLabelGroupHeader_Reversing"
            Me.XrLabelGroupHeader_Reversing.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Reversing.SizeF = New System.Drawing.SizeF(83.33331!, 19.99999!)
            '
            'XrLabelGroupHeader_ReversingLabel
            '
            Me.XrLabelGroupHeader_ReversingLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ReversingLabel.LocationFloat = New DevExpress.Utils.PointFloat(796.2495!, 20.00001!)
            Me.XrLabelGroupHeader_ReversingLabel.Name = "XrLabelGroupHeader_ReversingLabel"
            Me.XrLabelGroupHeader_ReversingLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ReversingLabel.SizeF = New System.Drawing.SizeF(82.29181!, 20.0!)
            Me.XrLabelGroupHeader_ReversingLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ReversingLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ReversingLabel.Text = "Reversing:"
            Me.XrLabelGroupHeader_ReversingLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_ControlAmount
            '
            Me.XrLabelGroupHeader_ControlAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ControlAmount")})
            Me.XrLabelGroupHeader_ControlAmount.LocationFloat = New DevExpress.Utils.PointFloat(664.9995!, 20.00001!)
            Me.XrLabelGroupHeader_ControlAmount.Name = "XrLabelGroupHeader_ControlAmount"
            Me.XrLabelGroupHeader_ControlAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmount.SizeF = New System.Drawing.SizeF(131.25!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmount.TextFormatString = "{0:c2}"
            '
            'XrLabelGroupHeader_ControlAmountLabel
            '
            Me.XrLabelGroupHeader_ControlAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ControlAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(559.3748!, 20.00001!)
            Me.XrLabelGroupHeader_ControlAmountLabel.Name = "XrLabelGroupHeader_ControlAmountLabel"
            Me.XrLabelGroupHeader_ControlAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.SizeF = New System.Drawing.SizeF(105.6249!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ControlAmountLabel.Text = "Control Amount:"
            Me.XrLabelGroupHeader_ControlAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_DateLabel
            '
            Me.XrLabelGroupHeader_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(599.9998!, 0!)
            Me.XrLabelGroupHeader_DateLabel.Name = "XrLabelGroupHeader_DateLabel"
            Me.XrLabelGroupHeader_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_DateLabel.SizeF = New System.Drawing.SizeF(64.99976!, 20.0!)
            Me.XrLabelGroupHeader_DateLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_DateLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_DateLabel.Text = "Date:"
            Me.XrLabelGroupHeader_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_ControlNumber
            '
            Me.XrLabelGroupHeader_ControlNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ControlNumber")})
            Me.XrLabelGroupHeader_ControlNumber.LocationFloat = New DevExpress.Utils.PointFloat(135.0001!, 0!)
            Me.XrLabelGroupHeader_ControlNumber.Name = "XrLabelGroupHeader_ControlNumber"
            Me.XrLabelGroupHeader_ControlNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlNumber.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
            Me.XrLabelGroupHeader_ControlNumber.TextFormatString = "{0:00000#}"
            '
            'XrLabelGroupHeader_ControlNumberLabel
            '
            Me.XrLabelGroupHeader_ControlNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ControlNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00004!, 0!)
            Me.XrLabelGroupHeader_ControlNumberLabel.Name = "XrLabelGroupHeader_ControlNumberLabel"
            Me.XrLabelGroupHeader_ControlNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlNumberLabel.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
            Me.XrLabelGroupHeader_ControlNumberLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ControlNumberLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ControlNumberLabel.Text = "Control Number:"
            Me.XrLabelGroupHeader_ControlNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_PostPeriod
            '
            Me.XrLabelGroupHeader_PostPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.XrLabelGroupHeader_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(135.0001!, 20.00001!)
            Me.XrLabelGroupHeader_PostPeriod.Multiline = True
            Me.XrLabelGroupHeader_PostPeriod.Name = "XrLabelGroupHeader_PostPeriod"
            Me.XrLabelGroupHeader_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostPeriod.SizeF = New System.Drawing.SizeF(60.00009!, 20.00002!)
            '
            'XrLabelGroupHeader_CycleDescription
            '
            Me.XrLabelGroupHeader_CycleDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CycleDescription")})
            Me.XrLabelGroupHeader_CycleDescription.LocationFloat = New DevExpress.Utils.PointFloat(195.0002!, 0!)
            Me.XrLabelGroupHeader_CycleDescription.Name = "XrLabelGroupHeader_CycleDescription"
            Me.XrLabelGroupHeader_CycleDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleDescription.SizeF = New System.Drawing.SizeF(253.5416!, 20.0!)
            '
            'XrLabelGroupHeader_PostPeriodLabel
            '
            Me.XrLabelGroupHeader_PostPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_PostPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00008!)
            Me.XrLabelGroupHeader_PostPeriodLabel.Name = "XrLabelGroupHeader_PostPeriodLabel"
            Me.XrLabelGroupHeader_PostPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostPeriodLabel.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
            Me.XrLabelGroupHeader_PostPeriodLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_PostPeriodLabel.Text = "Post Period:"
            '
            'XrLabelGroupHeader_CycleLabel
            '
            Me.XrLabelGroupHeader_CycleLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_CycleLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 0!)
            Me.XrLabelGroupHeader_CycleLabel.Name = "XrLabelGroupHeader_CycleLabel"
            Me.XrLabelGroupHeader_CycleLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleLabel.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
            Me.XrLabelGroupHeader_CycleLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CycleLabel.Text = "Cycle:"
            '
            'XrLabelGroupHeader_CycleCode
            '
            Me.XrLabelGroupHeader_CycleCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CycleCode")})
            Me.XrLabelGroupHeader_CycleCode.LocationFloat = New DevExpress.Utils.PointFloat(135.0001!, 0!)
            Me.XrLabelGroupHeader_CycleCode.Name = "XrLabelGroupHeader_CycleCode"
            Me.XrLabelGroupHeader_CycleCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleCode.SizeF = New System.Drawing.SizeF(60.00009!, 20.0!)
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineGroupFooter_Line2, Me.XrLineGroupFooter_Line, Me.XrLabelGroupFooter_Total, Me.XrLabelGroupFooter_Credit, Me.XrLabelGroupFooter_Debit})
            Me.GroupFooter.HeightF = 42.83333!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'XrLineGroupFooter_Line2
            '
            Me.XrLineGroupFooter_Line2.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupFooter_Line2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupFooter_Line2.BorderWidth = 1.0!
            Me.XrLineGroupFooter_Line2.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupFooter_Line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 39.83333!)
            Me.XrLineGroupFooter_Line2.Name = "XrLineGroupFooter_Line2"
            Me.XrLineGroupFooter_Line2.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLineGroupFooter_Line
            '
            Me.XrLineGroupFooter_Line.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupFooter_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupFooter_Line.BorderWidth = 1.0!
            Me.XrLineGroupFooter_Line.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupFooter_Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLineGroupFooter_Line.Name = "XrLineGroupFooter_Line"
            Me.XrLineGroupFooter_Line.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLabelGroupFooter_Total
            '
            Me.XrLabelGroupFooter_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupFooter_Total.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 5.0!)
            Me.XrLabelGroupFooter_Total.Name = "XrLabelGroupFooter_Total"
            Me.XrLabelGroupFooter_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_Total.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupFooter_Total.StylePriority.UseFont = False
            Me.XrLabelGroupFooter_Total.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupFooter_Total.Text = "Total:"
            Me.XrLabelGroupFooter_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupFooter_Credit
            '
            Me.XrLabelGroupFooter_Credit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Credit")})
            Me.XrLabelGroupFooter_Credit.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 4.999987!)
            Me.XrLabelGroupFooter_Credit.Name = "XrLabelGroupFooter_Credit"
            Me.XrLabelGroupFooter_Credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_Credit.SizeF = New System.Drawing.SizeF(100.0!, 20.00001!)
            Me.XrLabelGroupFooter_Credit.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGroupFooter_Credit.Summary = XrSummary1
            Me.XrLabelGroupFooter_Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelGroupFooter_Credit.TextFormatString = "{0:n2}"
            '
            'XrLabelGroupFooter_Debit
            '
            Me.XrLabelGroupFooter_Debit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Debit")})
            Me.XrLabelGroupFooter_Debit.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 4.999987!)
            Me.XrLabelGroupFooter_Debit.Name = "XrLabelGroupFooter_Debit"
            Me.XrLabelGroupFooter_Debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_Debit.SizeF = New System.Drawing.SizeF(100.0!, 20.00001!)
            Me.XrLabelGroupFooter_Debit.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGroupFooter_Debit.Summary = XrSummary2
            Me.XrLabelGroupFooter_Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelGroupFooter_Debit.TextFormatString = "{0:n2}"
            '
            'XrControlStyleEvenRows
            '
            Me.XrControlStyleEvenRows.BackColor = System.Drawing.Color.LightGray
            Me.XrControlStyleEvenRows.Name = "XrControlStyleEvenRows"
            Me.XrControlStyleEvenRows.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelPageFooter_UserCode, Me.XrPageInfoPageFooter_Page, Me.XrPageInfoPageFooter_Date})
            Me.PageFooter.HeightF = 33.33333!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeaderBand
            '
            Me.GroupHeaderBand.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineGroupHeaderBand_Line, Me.XrLabelGroupHeader_PostPeriod, Me.XrLabelGroupHeader_PostPeriodLabel, Me.XrLabelGroupHeader_CycleDescription, Me.XrLabelGroupHeader_CycleCode, Me.XrLabelGroupHeader_CycleLabel})
            Me.GroupHeaderBand.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CycleCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBand.HeightF = 43.0!
            Me.GroupHeaderBand.Level = 1
            Me.GroupHeaderBand.Name = "GroupHeaderBand"
            '
            'XrLineGroupHeaderBand_Line
            '
            Me.XrLineGroupHeaderBand_Line.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderBand_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeaderBand_Line.BorderWidth = 1.0!
            Me.XrLineGroupHeaderBand_Line.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderBand_Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 39.99999!)
            Me.XrLineGroupHeaderBand_Line.Name = "XrLineGroupHeaderBand_Line"
            Me.XrLineGroupHeaderBand_Line.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'GroupFooterBand
            '
            Me.GroupFooterBand.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupFooter_BatchTotalCredit, Me.XrLabelGroupFooter_BatchTotalDebit, Me.XrLabelGroupFooter_BatchTotal})
            Me.GroupFooterBand.HeightF = 31.37499!
            Me.GroupFooterBand.Level = 1
            Me.GroupFooterBand.Name = "GroupFooterBand"
            '
            'XrLabelGroupFooter_BatchTotalCredit
            '
            Me.XrLabelGroupFooter_BatchTotalCredit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Credit")})
            Me.XrLabelGroupFooter_BatchTotalCredit.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 9.999974!)
            Me.XrLabelGroupFooter_BatchTotalCredit.Name = "XrLabelGroupFooter_BatchTotalCredit"
            Me.XrLabelGroupFooter_BatchTotalCredit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_BatchTotalCredit.SizeF = New System.Drawing.SizeF(100.0!, 20.00001!)
            Me.XrLabelGroupFooter_BatchTotalCredit.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGroupFooter_BatchTotalCredit.Summary = XrSummary3
            Me.XrLabelGroupFooter_BatchTotalCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelGroupFooter_BatchTotalCredit.TextFormatString = "{0:n2}"
            '
            'XrLabelGroupFooter_BatchTotalDebit
            '
            Me.XrLabelGroupFooter_BatchTotalDebit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Debit")})
            Me.XrLabelGroupFooter_BatchTotalDebit.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 9.999974!)
            Me.XrLabelGroupFooter_BatchTotalDebit.Name = "XrLabelGroupFooter_BatchTotalDebit"
            Me.XrLabelGroupFooter_BatchTotalDebit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_BatchTotalDebit.SizeF = New System.Drawing.SizeF(100.0!, 20.00001!)
            Me.XrLabelGroupFooter_BatchTotalDebit.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGroupFooter_BatchTotalDebit.Summary = XrSummary4
            Me.XrLabelGroupFooter_BatchTotalDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelGroupFooter_BatchTotalDebit.TextFormatString = "{0:n2}"
            '
            'XrLabelGroupFooter_BatchTotal
            '
            Me.XrLabelGroupFooter_BatchTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupFooter_BatchTotal.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 9.999974!)
            Me.XrLabelGroupFooter_BatchTotal.Name = "XrLabelGroupFooter_BatchTotal"
            Me.XrLabelGroupFooter_BatchTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_BatchTotal.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupFooter_BatchTotal.StylePriority.UseFont = False
            Me.XrLabelGroupFooter_BatchTotal.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupFooter_BatchTotal.Text = "Batch Total:"
            Me.XrLabelGroupFooter_BatchTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryPostReport)
            '
            'RecurringJournalEntryPostReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader, Me.GroupFooter, Me.PageFooter, Me.GroupHeaderBand, Me.GroupFooterBand})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 25, 25)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyleEvenRows})
            Me.Version = "20.1"
            CType(Me.XrTable, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents XrPageInfoPageFooter_Date As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrLabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPageInfoPageFooter_Page As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelGroupHeader_Reversing As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ReversingLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CycleLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CycleCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLineGroupHeader_TopLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGroupHeader_GLAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineGroupHeader_BottomLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGroupHeader_RemarksLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ProductLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_DivisionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CreditLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_DebitLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupFooter_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupFooter_Credit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupFooter_Debit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineGroupFooter_Line As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrControlStyleEvenRows As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents XrLabelPageHeader_AgencyName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrTable As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellGLACode As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellGLADescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellDebit As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellCredit As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellClientCode As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellDivisionCode As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellProductCode As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellRemarks As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrLabelGroupHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CycleDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBand As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterBand As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabelGroupHeader_TransactionNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TransactionNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPageInfoGroupHeader_Date As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrLineGroupFooter_Line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGroupFooter_BatchTotalCredit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupFooter_BatchTotalDebit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupFooter_BatchTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineGroupHeaderBand_Line As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
