Namespace GeneralLedger.JournalEntry

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class JournalEntryReport
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
            Me.XrLabelGroupHeader_Reversal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ReversalLabel = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabelGroupHeader_PostedToSummaryLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostedToSummary = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CreatedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CreatedByLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TransactionDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TransactionDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_SourceCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_SourceCodeCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_SourceCodeDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_Transaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TransactionNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TransactionDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostingPeriodDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostingPeriodCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_PostingPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLineGroupFooter_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelGroupFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_Credit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_Debit = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrControlStyleEvenRows = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
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
            Me.XrLabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.00004!, 10.00001!)
            Me.XrLabelPageHeader_Title.Name = "XrLabelPageHeader_Title"
            Me.XrLabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelPageHeader_Title.SizeF = New System.Drawing.SizeF(200.0!, 39.99999!)
            Me.XrLabelPageHeader_Title.StylePriority.UseFont = False
            Me.XrLabelPageHeader_Title.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_Title.Text = "Journal Entry"
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
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupHeader_Reversal, Me.XrLabelGroupHeader_ReversalLabel, Me.XrLabelGroupHeader_RemarksLabel, Me.XrLabelGroupHeader_ProductLabel, Me.XrLabelGroupHeader_DivisionLabel, Me.XrLabelGroupHeader_DebitLabel, Me.XrLabelGroupHeader_CreditLabel, Me.XrLabelGroupHeader_ClientLabel, Me.XrLabelGroupHeader_GLAccountLabel, Me.XrLineGroupHeader_TopLine, Me.XrLineGroupHeader_BottomLine, Me.XrLabelGroupHeader_Reversing, Me.XrLabelGroupHeader_ReversingLabel, Me.XrLabelGroupHeader_PostedToSummaryLabel, Me.XrLabelGroupHeader_PostedToSummary, Me.XrLabelGroupHeader_ControlAmount, Me.XrLabelGroupHeader_ControlAmountLabel, Me.XrLabelGroupHeader_CreatedBy, Me.XrLabelGroupHeader_CreatedByLabel, Me.XrLabelGroupHeader_TransactionDate, Me.XrLabelGroupHeader_TransactionDateLabel, Me.XrLabelGroupHeader_SourceCode, Me.XrLabelGroupHeader_SourceCodeCode, Me.XrLabelGroupHeader_SourceCodeDescription, Me.XrLabelGroupHeader_Transaction, Me.XrLabelGroupHeader_TransactionNumber, Me.XrLabelGroupHeader_TransactionDescription, Me.XrLabelGroupHeader_PostingPeriodDescription, Me.XrLabelGroupHeader_PostingPeriodCode, Me.XrLabelGroupHeader_PostingPeriod})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 110.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelGroupHeader_Reversal
            '
            Me.XrLabelGroupHeader_Reversal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Reversed")})
            Me.XrLabelGroupHeader_Reversal.LocationFloat = New DevExpress.Utils.PointFloat(942.7083!, 50.00003!)
            Me.XrLabelGroupHeader_Reversal.Name = "XrLabelGroupHeader_Reversal"
            Me.XrLabelGroupHeader_Reversal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Reversal.SizeF = New System.Drawing.SizeF(57.29169!, 20.0!)
            '
            'XrLabelGroupHeader_ReversalLabel
            '
            Me.XrLabelGroupHeader_ReversalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ReversalLabel.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 50.00003!)
            Me.XrLabelGroupHeader_ReversalLabel.Name = "XrLabelGroupHeader_ReversalLabel"
            Me.XrLabelGroupHeader_ReversalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ReversalLabel.SizeF = New System.Drawing.SizeF(67.70831!, 20.0!)
            Me.XrLabelGroupHeader_ReversalLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ReversalLabel.Text = "Reversal:"
            '
            'XrLabelGroupHeader_RemarksLabel
            '
            Me.XrLabelGroupHeader_RemarksLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_RemarksLabel.LocationFloat = New DevExpress.Utils.PointFloat(750.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_ProductLabel.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_DivisionLabel.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_DebitLabel.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_CreditLabel.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 82.79165!)
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
            Me.XrLabelGroupHeader_GLAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 82.79165!)
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
            Me.XrLineGroupHeader_TopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 79.79164!)
            Me.XrLineGroupHeader_TopLine.Name = "XrLineGroupHeader_TopLine"
            Me.XrLineGroupHeader_TopLine.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLineGroupHeader_BottomLine
            '
            Me.XrLineGroupHeader_BottomLine.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_BottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeader_BottomLine.BorderWidth = 1.0!
            Me.XrLineGroupHeader_BottomLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_BottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.7917!)
            Me.XrLineGroupHeader_BottomLine.Name = "XrLineGroupHeader_BottomLine"
            Me.XrLineGroupHeader_BottomLine.SizeF = New System.Drawing.SizeF(1000.0!, 3.0!)
            '
            'XrLabelGroupHeader_Reversing
            '
            Me.XrLabelGroupHeader_Reversing.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Reversing")})
            Me.XrLabelGroupHeader_Reversing.LocationFloat = New DevExpress.Utils.PointFloat(942.7083!, 30.00002!)
            Me.XrLabelGroupHeader_Reversing.Name = "XrLabelGroupHeader_Reversing"
            Me.XrLabelGroupHeader_Reversing.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Reversing.SizeF = New System.Drawing.SizeF(57.29169!, 20.0!)
            '
            'XrLabelGroupHeader_ReversingLabel
            '
            Me.XrLabelGroupHeader_ReversingLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ReversingLabel.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 30.00002!)
            Me.XrLabelGroupHeader_ReversingLabel.Name = "XrLabelGroupHeader_ReversingLabel"
            Me.XrLabelGroupHeader_ReversingLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ReversingLabel.SizeF = New System.Drawing.SizeF(67.70831!, 20.0!)
            Me.XrLabelGroupHeader_ReversingLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ReversingLabel.Text = "Reversing:"
            '
            'XrLabelGroupHeader_PostedToSummaryLabel
            '
            Me.XrLabelGroupHeader_PostedToSummaryLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_PostedToSummaryLabel.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 50.00003!)
            Me.XrLabelGroupHeader_PostedToSummaryLabel.Name = "XrLabelGroupHeader_PostedToSummaryLabel"
            Me.XrLabelGroupHeader_PostedToSummaryLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostedToSummaryLabel.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
            Me.XrLabelGroupHeader_PostedToSummaryLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_PostedToSummaryLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_PostedToSummaryLabel.Text = "Posted To Summary:"
            Me.XrLabelGroupHeader_PostedToSummaryLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_PostedToSummary
            '
            Me.XrLabelGroupHeader_PostedToSummary.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostedToSummary")})
            Me.XrLabelGroupHeader_PostedToSummary.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 50.00003!)
            Me.XrLabelGroupHeader_PostedToSummary.Name = "XrLabelGroupHeader_PostedToSummary"
            Me.XrLabelGroupHeader_PostedToSummary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostedToSummary.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_PostedToSummary.TextFormatString = "{0:d}"
            '
            'XrLabelGroupHeader_ControlAmount
            '
            Me.XrLabelGroupHeader_ControlAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ControlAmount")})
            Me.XrLabelGroupHeader_ControlAmount.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 30.00002!)
            Me.XrLabelGroupHeader_ControlAmount.Name = "XrLabelGroupHeader_ControlAmount"
            Me.XrLabelGroupHeader_ControlAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmount.SizeF = New System.Drawing.SizeF(175.0!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmount.TextFormatString = "{0:c2}"
            '
            'XrLabelGroupHeader_ControlAmountLabel
            '
            Me.XrLabelGroupHeader_ControlAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ControlAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 30.00002!)
            Me.XrLabelGroupHeader_ControlAmountLabel.Name = "XrLabelGroupHeader_ControlAmountLabel"
            Me.XrLabelGroupHeader_ControlAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ControlAmountLabel.Text = "Control Amount:"
            Me.XrLabelGroupHeader_ControlAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_CreatedBy
            '
            Me.XrLabelGroupHeader_CreatedBy.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreatedByUserCode")})
            Me.XrLabelGroupHeader_CreatedBy.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 10.00001!)
            Me.XrLabelGroupHeader_CreatedBy.Name = "XrLabelGroupHeader_CreatedBy"
            Me.XrLabelGroupHeader_CreatedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CreatedBy.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
            '
            'XrLabelGroupHeader_CreatedByLabel
            '
            Me.XrLabelGroupHeader_CreatedByLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_CreatedByLabel.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 10.00001!)
            Me.XrLabelGroupHeader_CreatedByLabel.Name = "XrLabelGroupHeader_CreatedByLabel"
            Me.XrLabelGroupHeader_CreatedByLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CreatedByLabel.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
            Me.XrLabelGroupHeader_CreatedByLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CreatedByLabel.Text = "Created By:"
            '
            'XrLabelGroupHeader_TransactionDate
            '
            Me.XrLabelGroupHeader_TransactionDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TransactionDate")})
            Me.XrLabelGroupHeader_TransactionDate.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 10.00001!)
            Me.XrLabelGroupHeader_TransactionDate.Name = "XrLabelGroupHeader_TransactionDate"
            Me.XrLabelGroupHeader_TransactionDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionDate.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_TransactionDate.TextFormatString = "{0:d}"
            '
            'XrLabelGroupHeader_TransactionDateLabel
            '
            Me.XrLabelGroupHeader_TransactionDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_TransactionDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 10.00001!)
            Me.XrLabelGroupHeader_TransactionDateLabel.Name = "XrLabelGroupHeader_TransactionDateLabel"
            Me.XrLabelGroupHeader_TransactionDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionDateLabel.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
            Me.XrLabelGroupHeader_TransactionDateLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_TransactionDateLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_TransactionDateLabel.Text = "Transaction Date:"
            Me.XrLabelGroupHeader_TransactionDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_SourceCode
            '
            Me.XrLabelGroupHeader_SourceCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_SourceCode.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 50.00003!)
            Me.XrLabelGroupHeader_SourceCode.Name = "XrLabelGroupHeader_SourceCode"
            Me.XrLabelGroupHeader_SourceCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_SourceCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_SourceCode.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_SourceCode.Text = "Source Code:"
            '
            'XrLabelGroupHeader_SourceCodeCode
            '
            Me.XrLabelGroupHeader_SourceCodeCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLSourceCode")})
            Me.XrLabelGroupHeader_SourceCodeCode.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 50.00003!)
            Me.XrLabelGroupHeader_SourceCodeCode.Name = "XrLabelGroupHeader_SourceCodeCode"
            Me.XrLabelGroupHeader_SourceCodeCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_SourceCodeCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            '
            'XrLabelGroupHeader_SourceCodeDescription
            '
            Me.XrLabelGroupHeader_SourceCodeDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLSourceDescription")})
            Me.XrLabelGroupHeader_SourceCodeDescription.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 50.00003!)
            Me.XrLabelGroupHeader_SourceCodeDescription.Name = "XrLabelGroupHeader_SourceCodeDescription"
            Me.XrLabelGroupHeader_SourceCodeDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_SourceCodeDescription.SizeF = New System.Drawing.SizeF(350.0!, 20.0!)
            '
            'XrLabelGroupHeader_Transaction
            '
            Me.XrLabelGroupHeader_Transaction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_Transaction.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 30.00002!)
            Me.XrLabelGroupHeader_Transaction.Name = "XrLabelGroupHeader_Transaction"
            Me.XrLabelGroupHeader_Transaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Transaction.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_Transaction.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_Transaction.Text = "Transaction #:"
            '
            'XrLabelGroupHeader_TransactionNumber
            '
            Me.XrLabelGroupHeader_TransactionNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.XrLabelGroupHeader_TransactionNumber.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 30.00002!)
            Me.XrLabelGroupHeader_TransactionNumber.Name = "XrLabelGroupHeader_TransactionNumber"
            Me.XrLabelGroupHeader_TransactionNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionNumber.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            '
            'XrLabelGroupHeader_TransactionDescription
            '
            Me.XrLabelGroupHeader_TransactionDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransactionDescription")})
            Me.XrLabelGroupHeader_TransactionDescription.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 30.00002!)
            Me.XrLabelGroupHeader_TransactionDescription.Name = "XrLabelGroupHeader_TransactionDescription"
            Me.XrLabelGroupHeader_TransactionDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TransactionDescription.SizeF = New System.Drawing.SizeF(350.0!, 20.0!)
            '
            'XrLabelGroupHeader_PostingPeriodDescription
            '
            Me.XrLabelGroupHeader_PostingPeriodDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodDescription")})
            Me.XrLabelGroupHeader_PostingPeriodDescription.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 10.00001!)
            Me.XrLabelGroupHeader_PostingPeriodDescription.Name = "XrLabelGroupHeader_PostingPeriodDescription"
            Me.XrLabelGroupHeader_PostingPeriodDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostingPeriodDescription.SizeF = New System.Drawing.SizeF(350.0!, 20.0!)
            '
            'XrLabelGroupHeader_PostingPeriodCode
            '
            Me.XrLabelGroupHeader_PostingPeriodCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.XrLabelGroupHeader_PostingPeriodCode.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 10.00001!)
            Me.XrLabelGroupHeader_PostingPeriodCode.Name = "XrLabelGroupHeader_PostingPeriodCode"
            Me.XrLabelGroupHeader_PostingPeriodCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostingPeriodCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            '
            'XrLabelGroupHeader_PostingPeriod
            '
            Me.XrLabelGroupHeader_PostingPeriod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_PostingPeriod.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 10.00001!)
            Me.XrLabelGroupHeader_PostingPeriod.Name = "XrLabelGroupHeader_PostingPeriod"
            Me.XrLabelGroupHeader_PostingPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_PostingPeriod.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_PostingPeriod.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_PostingPeriod.Text = "Posting Period:"
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineGroupFooter_Line, Me.XrLabelGroupFooter_Total, Me.XrLabelGroupFooter_Credit, Me.XrLabelGroupFooter_Debit})
            Me.GroupFooter.HeightF = 42.83333!
            Me.GroupFooter.Name = "GroupFooter"
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
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Classes.GeneralLedger.JournalEntry.JournalEntryReport)
            '
            'JournalEntryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader, Me.GroupFooter, Me.PageFooter})
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
        Friend WithEvents XrLabelGroupHeader_PostedToSummaryLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostedToSummary As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CreatedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CreatedByLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TransactionDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TransactionDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_SourceCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_SourceCodeCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_SourceCodeDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_Transaction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TransactionNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TransactionDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostingPeriodDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostingPeriodCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_PostingPeriod As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents XrLabelGroupHeader_Reversal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ReversalLabel As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
