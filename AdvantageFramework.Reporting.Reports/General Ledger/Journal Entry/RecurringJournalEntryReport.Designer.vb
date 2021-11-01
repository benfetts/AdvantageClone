Namespace GeneralLedger.JournalEntry

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class RecurringJournalEntryReport
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
            Me.XrLabelGroupHeader_LastPostedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_LastPostedByLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TotalNumberOfPosted = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_StartingPostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_LastPostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleDescription = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabelGroupHeader_NumberOfPostingsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_LastPostingPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CreatedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CreatedByLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_LastPostingDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_LastPostingDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_StartingPostPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_NumberOfPostings = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CycleCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_ControlNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 10.00001!)
            Me.XrLabelPageHeader_Title.Name = "XrLabelPageHeader_Title"
            Me.XrLabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelPageHeader_Title.SizeF = New System.Drawing.SizeF(389.9999!, 39.99999!)
            Me.XrLabelPageHeader_Title.StylePriority.UseFont = False
            Me.XrLabelPageHeader_Title.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_Title.Text = "Recurring Journal Entry"
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
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupHeader_LastPostedBy, Me.XrLabelGroupHeader_LastPostedByLabel, Me.XrLabelGroupHeader_TotalNumberOfPosted, Me.XrLabelGroupHeader_TotalNumberOfPostedLabel, Me.XrLabelGroupHeader_StartingPostPeriod, Me.XrLabelGroupHeader_LastPostingPeriodLabel, Me.XrLabelGroupHeader_CycleDescription, Me.XrLabelGroupHeader_Description, Me.XrLabelGroupHeader_RemarksLabel, Me.XrLabelGroupHeader_ProductLabel, Me.XrLabelGroupHeader_DivisionLabel, Me.XrLabelGroupHeader_DebitLabel, Me.XrLabelGroupHeader_CreditLabel, Me.XrLabelGroupHeader_ClientLabel, Me.XrLabelGroupHeader_GLAccountLabel, Me.XrLineGroupHeader_TopLine, Me.XrLineGroupHeader_BottomLine, Me.XrLabelGroupHeader_Reversing, Me.XrLabelGroupHeader_ReversingLabel, Me.XrLabelGroupHeader_NumberOfPostingsLabel, Me.XrLabelGroupHeader_LastPostingPeriod, Me.XrLabelGroupHeader_ControlAmount, Me.XrLabelGroupHeader_ControlAmountLabel, Me.XrLabelGroupHeader_CreatedBy, Me.XrLabelGroupHeader_CreatedByLabel, Me.XrLabelGroupHeader_LastPostingDate, Me.XrLabelGroupHeader_LastPostingDateLabel, Me.XrLabelGroupHeader_StartingPostPeriodLabel, Me.XrLabelGroupHeader_NumberOfPostings, Me.XrLabelGroupHeader_CycleLabel, Me.XrLabelGroupHeader_CycleCode, Me.XrLabelGroupHeader_ControlNumber, Me.XrLabelGroupHeader_ControlNumberLabel})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ControlNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 110.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelGroupHeader_LastPostedBy
            '
            Me.XrLabelGroupHeader_LastPostedBy.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LastPostingUserCode")})
            Me.XrLabelGroupHeader_LastPostedBy.LocationFloat = New DevExpress.Utils.PointFloat(851.4581!, 50.00003!)
            Me.XrLabelGroupHeader_LastPostedBy.Multiline = True
            Me.XrLabelGroupHeader_LastPostedBy.Name = "XrLabelGroupHeader_LastPostedBy"
            Me.XrLabelGroupHeader_LastPostedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostedBy.SizeF = New System.Drawing.SizeF(148.5419!, 19.99995!)
            Me.XrLabelGroupHeader_LastPostedBy.Text = "XrLabelGroupHeader_LastPostedBy"
            '
            'XrLabelGroupHeader_LastPostedByLabel
            '
            Me.XrLabelGroupHeader_LastPostedByLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_LastPostedByLabel.LocationFloat = New DevExpress.Utils.PointFloat(671.2498!, 49.99997!)
            Me.XrLabelGroupHeader_LastPostedByLabel.Name = "XrLabelGroupHeader_LastPostedByLabel"
            Me.XrLabelGroupHeader_LastPostedByLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostedByLabel.SizeF = New System.Drawing.SizeF(180.2084!, 20.0!)
            Me.XrLabelGroupHeader_LastPostedByLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_LastPostedByLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_LastPostedByLabel.Text = "Last Posted By:"
            Me.XrLabelGroupHeader_LastPostedByLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_TotalNumberOfPosted
            '
            Me.XrLabelGroupHeader_TotalNumberOfPosted.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalNumberOfPostings")})
            Me.XrLabelGroupHeader_TotalNumberOfPosted.LocationFloat = New DevExpress.Utils.PointFloat(554.1667!, 49.99997!)
            Me.XrLabelGroupHeader_TotalNumberOfPosted.Multiline = True
            Me.XrLabelGroupHeader_TotalNumberOfPosted.Name = "XrLabelGroupHeader_TotalNumberOfPosted"
            Me.XrLabelGroupHeader_TotalNumberOfPosted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TotalNumberOfPosted.SizeF = New System.Drawing.SizeF(117.0831!, 20.00002!)
            Me.XrLabelGroupHeader_TotalNumberOfPosted.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_TotalNumberOfPosted.Text = "XrLabelGroupHeader_TotalNumberOfPosted"
            Me.XrLabelGroupHeader_TotalNumberOfPosted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_TotalNumberOfPostedLabel
            '
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.LocationFloat = New DevExpress.Utils.PointFloat(423.5418!, 50.0!)
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.Name = "XrLabelGroupHeader_TotalNumberOfPostedLabel"
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.SizeF = New System.Drawing.SizeF(130.6249!, 20.0!)
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.Text = "Total Number Posted:"
            Me.XrLabelGroupHeader_TotalNumberOfPostedLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_StartingPostPeriod
            '
            Me.XrLabelGroupHeader_StartingPostPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartingPostPeriodCode")})
            Me.XrLabelGroupHeader_StartingPostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 49.99997!)
            Me.XrLabelGroupHeader_StartingPostPeriod.Multiline = True
            Me.XrLabelGroupHeader_StartingPostPeriod.Name = "XrLabelGroupHeader_StartingPostPeriod"
            Me.XrLabelGroupHeader_StartingPostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_StartingPostPeriod.SizeF = New System.Drawing.SizeF(100.0!, 20.00002!)
            Me.XrLabelGroupHeader_StartingPostPeriod.Text = "XrLabelGroupHeader_StartingPostPeriod"
            '
            'XrLabelGroupHeader_LastPostingPeriodLabel
            '
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(423.5418!, 30.00002!)
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.Name = "XrLabelGroupHeader_LastPostingPeriodLabel"
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.SizeF = New System.Drawing.SizeF(130.6246!, 20.0!)
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.Text = "Last Posting Period:"
            Me.XrLabelGroupHeader_LastPostingPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_CycleDescription
            '
            Me.XrLabelGroupHeader_CycleDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CycleDescription")})
            Me.XrLabelGroupHeader_CycleDescription.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 30.00002!)
            Me.XrLabelGroupHeader_CycleDescription.Name = "XrLabelGroupHeader_CycleDescription"
            Me.XrLabelGroupHeader_CycleDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleDescription.SizeF = New System.Drawing.SizeF(213.5417!, 20.0!)
            '
            'XrLabelGroupHeader_Description
            '
            Me.XrLabelGroupHeader_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.XrLabelGroupHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 10.00001!)
            Me.XrLabelGroupHeader_Description.Multiline = True
            Me.XrLabelGroupHeader_Description.Name = "XrLabelGroupHeader_Description"
            Me.XrLabelGroupHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Description.SizeF = New System.Drawing.SizeF(213.5417!, 20.00001!)
            Me.XrLabelGroupHeader_Description.Text = "XrLabelGroupHeader_Description"
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
            Me.XrLabelGroupHeader_Reversing.LocationFloat = New DevExpress.Utils.PointFloat(735.8331!, 10.00001!)
            Me.XrLabelGroupHeader_Reversing.Name = "XrLabelGroupHeader_Reversing"
            Me.XrLabelGroupHeader_Reversing.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Reversing.SizeF = New System.Drawing.SizeF(40.625!, 20.0!)
            '
            'XrLabelGroupHeader_ReversingLabel
            '
            Me.XrLabelGroupHeader_ReversingLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ReversingLabel.LocationFloat = New DevExpress.Utils.PointFloat(671.2496!, 10.00001!)
            Me.XrLabelGroupHeader_ReversingLabel.Name = "XrLabelGroupHeader_ReversingLabel"
            Me.XrLabelGroupHeader_ReversingLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ReversingLabel.SizeF = New System.Drawing.SizeF(64.5835!, 20.0!)
            Me.XrLabelGroupHeader_ReversingLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ReversingLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ReversingLabel.Text = "Reversing:"
            Me.XrLabelGroupHeader_ReversingLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_NumberOfPostingsLabel
            '
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.LocationFloat = New DevExpress.Utils.PointFloat(235.0!, 50.0!)
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.Name = "XrLabelGroupHeader_NumberOfPostingsLabel"
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.SizeF = New System.Drawing.SizeF(105.625!, 20.0!)
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.Text = "Postings:"
            Me.XrLabelGroupHeader_NumberOfPostingsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_LastPostingPeriod
            '
            Me.XrLabelGroupHeader_LastPostingPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LastPostPeriodCode")})
            Me.XrLabelGroupHeader_LastPostingPeriod.LocationFloat = New DevExpress.Utils.PointFloat(554.1664!, 30.00002!)
            Me.XrLabelGroupHeader_LastPostingPeriod.Name = "XrLabelGroupHeader_LastPostingPeriod"
            Me.XrLabelGroupHeader_LastPostingPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostingPeriod.SizeF = New System.Drawing.SizeF(117.0831!, 20.0!)
            '
            'XrLabelGroupHeader_ControlAmount
            '
            Me.XrLabelGroupHeader_ControlAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ControlAmount")})
            Me.XrLabelGroupHeader_ControlAmount.LocationFloat = New DevExpress.Utils.PointFloat(554.1664!, 10.00001!)
            Me.XrLabelGroupHeader_ControlAmount.Name = "XrLabelGroupHeader_ControlAmount"
            Me.XrLabelGroupHeader_ControlAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmount.SizeF = New System.Drawing.SizeF(117.0831!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmount.TextFormatString = "{0:c2}"
            '
            'XrLabelGroupHeader_ControlAmountLabel
            '
            Me.XrLabelGroupHeader_ControlAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ControlAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(423.5417!, 10.00001!)
            Me.XrLabelGroupHeader_ControlAmountLabel.Name = "XrLabelGroupHeader_ControlAmountLabel"
            Me.XrLabelGroupHeader_ControlAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.SizeF = New System.Drawing.SizeF(130.625!, 20.0!)
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ControlAmountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_ControlAmountLabel.Text = "Control Amount:"
            Me.XrLabelGroupHeader_ControlAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_CreatedBy
            '
            Me.XrLabelGroupHeader_CreatedBy.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreatedByUserCode")})
            Me.XrLabelGroupHeader_CreatedBy.LocationFloat = New DevExpress.Utils.PointFloat(851.4581!, 10.00001!)
            Me.XrLabelGroupHeader_CreatedBy.Name = "XrLabelGroupHeader_CreatedBy"
            Me.XrLabelGroupHeader_CreatedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CreatedBy.SizeF = New System.Drawing.SizeF(148.5419!, 20.0!)
            '
            'XrLabelGroupHeader_CreatedByLabel
            '
            Me.XrLabelGroupHeader_CreatedByLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_CreatedByLabel.LocationFloat = New DevExpress.Utils.PointFloat(776.4581!, 10.00001!)
            Me.XrLabelGroupHeader_CreatedByLabel.Name = "XrLabelGroupHeader_CreatedByLabel"
            Me.XrLabelGroupHeader_CreatedByLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CreatedByLabel.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
            Me.XrLabelGroupHeader_CreatedByLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CreatedByLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CreatedByLabel.Text = "Created By:"
            Me.XrLabelGroupHeader_CreatedByLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_LastPostingDate
            '
            Me.XrLabelGroupHeader_LastPostingDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LastPostingDate")})
            Me.XrLabelGroupHeader_LastPostingDate.LocationFloat = New DevExpress.Utils.PointFloat(851.4583!, 30.00002!)
            Me.XrLabelGroupHeader_LastPostingDate.Name = "XrLabelGroupHeader_LastPostingDate"
            Me.XrLabelGroupHeader_LastPostingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostingDate.SizeF = New System.Drawing.SizeF(148.5417!, 20.0!)
            Me.XrLabelGroupHeader_LastPostingDate.TextFormatString = "{0:d}"
            '
            'XrLabelGroupHeader_LastPostingDateLabel
            '
            Me.XrLabelGroupHeader_LastPostingDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_LastPostingDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(671.2498!, 30.00002!)
            Me.XrLabelGroupHeader_LastPostingDateLabel.Name = "XrLabelGroupHeader_LastPostingDateLabel"
            Me.XrLabelGroupHeader_LastPostingDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_LastPostingDateLabel.SizeF = New System.Drawing.SizeF(180.2085!, 20.0!)
            Me.XrLabelGroupHeader_LastPostingDateLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_LastPostingDateLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_LastPostingDateLabel.Text = "Last Posting Date:"
            Me.XrLabelGroupHeader_LastPostingDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_StartingPostPeriodLabel
            '
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00004!, 50.00003!)
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.Name = "XrLabelGroupHeader_StartingPostPeriodLabel"
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_StartingPostPeriodLabel.Text = "Starting Post Period:"
            '
            'XrLabelGroupHeader_NumberOfPostings
            '
            Me.XrLabelGroupHeader_NumberOfPostings.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NumberOfPostings")})
            Me.XrLabelGroupHeader_NumberOfPostings.LocationFloat = New DevExpress.Utils.PointFloat(340.625!, 50.0!)
            Me.XrLabelGroupHeader_NumberOfPostings.Name = "XrLabelGroupHeader_NumberOfPostings"
            Me.XrLabelGroupHeader_NumberOfPostings.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_NumberOfPostings.SizeF = New System.Drawing.SizeF(82.91678!, 20.0!)
            '
            'XrLabelGroupHeader_CycleLabel
            '
            Me.XrLabelGroupHeader_CycleLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_CycleLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 30.00002!)
            Me.XrLabelGroupHeader_CycleLabel.Name = "XrLabelGroupHeader_CycleLabel"
            Me.XrLabelGroupHeader_CycleLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleLabel.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_CycleLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CycleLabel.Text = "Cycle:"
            '
            'XrLabelGroupHeader_CycleCode
            '
            Me.XrLabelGroupHeader_CycleCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CycleCode")})
            Me.XrLabelGroupHeader_CycleCode.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 30.00002!)
            Me.XrLabelGroupHeader_CycleCode.Name = "XrLabelGroupHeader_CycleCode"
            Me.XrLabelGroupHeader_CycleCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CycleCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            '
            'XrLabelGroupHeader_ControlNumber
            '
            Me.XrLabelGroupHeader_ControlNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ControlNumber")})
            Me.XrLabelGroupHeader_ControlNumber.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 10.00001!)
            Me.XrLabelGroupHeader_ControlNumber.Name = "XrLabelGroupHeader_ControlNumber"
            Me.XrLabelGroupHeader_ControlNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlNumber.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            '
            'XrLabelGroupHeader_ControlNumberLabel
            '
            Me.XrLabelGroupHeader_ControlNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_ControlNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 10.00001!)
            Me.XrLabelGroupHeader_ControlNumberLabel.Name = "XrLabelGroupHeader_ControlNumberLabel"
            Me.XrLabelGroupHeader_ControlNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_ControlNumberLabel.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.XrLabelGroupHeader_ControlNumberLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_ControlNumberLabel.Text = "Control Number:"
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
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryReport)
            '
            'RecurringJournalEntryReport
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
        Friend WithEvents XrLabelGroupHeader_NumberOfPostingsLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_LastPostingPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_ControlAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CreatedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CreatedByLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_LastPostingDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_LastPostingDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_StartingPostPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_NumberOfPostings As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents XrLabelGroupHeader_LastPostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_CycleDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_StartingPostPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TotalNumberOfPostedLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_LastPostedByLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_TotalNumberOfPosted As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupHeader_LastPostedBy As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
