Namespace JobAnalysisDetail.Version11

    Partial Public Class DetailByFunctionReport

        Private Detail As DevExpress.XtraReports.UI.DetailBand
        Private ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Private ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private LabelPageHeader_SortBy As DevExpress.XtraReports.UI.XRLabel
        Private LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private LineBottomLine As DevExpress.XtraReports.UI.XRLine
        Private PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private GroupHeaderFunction As DevExpress.XtraReports.UI.GroupHeaderBand
        Private FUNC As DevExpress.XtraReports.UI.XRLabel
        Private Line26 As DevExpress.XtraReports.UI.XRLine
        Private GroupHeaderForm_CDP As DevExpress.XtraReports.UI.GroupHeaderBand
        Private Text31 As DevExpress.XtraReports.UI.XRLabel
        Private LabelPageHeader_ProductData As DevExpress.XtraReports.UI.XRLabel
        Private LabelCDP_Client As DevExpress.XtraReports.UI.XRLabel
        Private Label158 As DevExpress.XtraReports.UI.XRLabel
        Private LabelPageHeader_Product As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Label52 As DevExpress.XtraReports.UI.XRLabel
        Private Text90 As DevExpress.XtraReports.UI.XRLabel
        Private CTotal As DevExpress.XtraReports.UI.XRLabel
        Private CNBillable As DevExpress.XtraReports.UI.XRLabel
        Private CBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text99 As DevExpress.XtraReports.UI.XRLabel
        Private Label150 As DevExpress.XtraReports.UI.XRLabel
        Private Label164 As DevExpress.XtraReports.UI.XRLabel
        Private Label165 As DevExpress.XtraReports.UI.XRLabel
        Private Label166 As DevExpress.XtraReports.UI.XRLabel
        Private Label167 As DevExpress.XtraReports.UI.XRLabel
        Private Line168 As DevExpress.XtraReports.UI.XRLine
        Private GroupHeader3 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private Job As DevExpress.XtraReports.UI.XRLabel
        Private Text120 As DevExpress.XtraReports.UI.XRLabel
        Private AE As DevExpress.XtraReports.UI.XRLabel
        Private Label153 As DevExpress.XtraReports.UI.XRLabel
        Private Label154 As DevExpress.XtraReports.UI.XRLabel
        Private Label156 As DevExpress.XtraReports.UI.XRLabel
        Private GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private label3 As DevExpress.XtraReports.UI.XRLabel
        Private label4 As DevExpress.XtraReports.UI.XRLabel
        Private Label68 As DevExpress.XtraReports.UI.XRLabel
        Private Label70 As DevExpress.XtraReports.UI.XRLabel
        Private Label72 As DevExpress.XtraReports.UI.XRLabel
        Private Label74 As DevExpress.XtraReports.UI.XRLabel
        Private Line57 As DevExpress.XtraReports.UI.XRLine
        Private Label129 As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Label100 As DevExpress.XtraReports.UI.XRLabel
        Private Text101 As DevExpress.XtraReports.UI.XRLabel
        Private JTotal As DevExpress.XtraReports.UI.XRLabel
        Private JNBillable As DevExpress.XtraReports.UI.XRLabel
        Private JBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text110 As DevExpress.XtraReports.UI.XRLabel
        Private Line130 As DevExpress.XtraReports.UI.XRLine
        Private GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
        Private GroupFooter0 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Text79 As DevExpress.XtraReports.UI.XRLabel
        Private FTotal As DevExpress.XtraReports.UI.XRLabel
        Private FNBillable As DevExpress.XtraReports.UI.XRLabel
        Private FBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text88 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
        Private components As System.ComponentModel.IContainer
        Friend WithEvents LabelCDP_ClientData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents DivisionFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProductFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobComponentFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AdvanceFlag As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BillableStatus As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents HoldStatus As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProcessDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AccountExecutiveFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FunctionFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FunctionTypeTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents NetCost As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledField As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Unbilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TodaysDate As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Public WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelSumOfOpenPOAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelSumOfNBAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Estimate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelUnbilled As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Billed As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelItemDesc As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label60 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label58 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label66 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label62 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label64 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents FHRSAMT As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Text80 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents FMU As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents FCOST As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents FTAX As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
        Public WithEvents XrSubreport1 As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents AdvancedBillingHistorySubReport1 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.AdvancedBillingHistorySubReport
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
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary14 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary15 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary16 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary17 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary19 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary18 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary20 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary21 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary22 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary23 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary24 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary25 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary26 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary27 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary28 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary29 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary30 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary31 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary32 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary33 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary34 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary35 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary36 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary37 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary38 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary39 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary40 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary41 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary42 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary43 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary44 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary45 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary46 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary47 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary48 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary49 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary50 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary51 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary52 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary53 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary54 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary55 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FHRSAMT = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text80 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FMU = New DevExpress.XtraReports.UI.XRLabel()
            Me.FCOST = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTAX = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSumOfOpenPOAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSumOfNBAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.Estimate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelUnbilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Billed = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelItemDesc = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_SortBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LineBottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.Line26 = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupHeaderFunction = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.FUNC = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeaderForm_CDP = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelCDP_ClientData = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ProductData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCDP_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label158 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label153 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label156 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AE = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label154 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text120 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text90 = New DevExpress.XtraReports.UI.XRLabel()
            Me.CTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.CNBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.CBilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text99 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label150 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label164 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label165 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label166 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label167 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line168 = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.Label60 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label58 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label66 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label64 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label68 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label70 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label72 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label74 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line57 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label129 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrSubreport3 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrSubreport2 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label100 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text101 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.JNBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.JBilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text110 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line130 = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text79 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.FNBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.FBilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text88 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DivisionFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProductFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobComponentFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AdvanceFlag = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BillableStatus = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HoldStatus = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ProcessDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AccountExecutiveFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.FunctionFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.FunctionTypeTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.NetCost = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledField = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Unbilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TodaysDate = New DevExpress.XtraReports.UI.CalculatedField()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.ActualHours = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ActualAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Variance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CalculatedField1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField2 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField3 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField4 = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.BackColor = System.Drawing.Color.Transparent
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel28, Me.FHRSAMT, Me.Text80, Me.FMU, Me.FCOST, Me.FTAX, Me.LabelSumOfOpenPOAmount, Me.LabelSumOfNBAmount, Me.Estimate, Me.Total, Me.LabelUnbilled, Me.Billed, Me.LabelDate, Me.LabelItemDesc})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 22.0!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Order", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            '
            'XrLabel28
            '
            Me.XrLabel28.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel28.BorderColor = System.Drawing.Color.Black
            Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel28.BorderWidth = 1.0!
            Me.XrLabel28.CanGrow = False
            Me.XrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField3", "{0:n2}")})
            Me.XrLabel28.Dpi = 100.0!
            Me.XrLabel28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(782.0001!, 0!)
            Me.XrLabel28.Name = "XrLabel28"
            Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel28.SizeF = New System.Drawing.SizeF(61.29175!, 19.0!)
            Me.XrLabel28.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0:n2}"
            Me.XrLabel28.Summary = XrSummary1
            Me.XrLabel28.Text = "XrLabel28"
            Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FHRSAMT
            '
            Me.FHRSAMT.BackColor = System.Drawing.Color.Transparent
            Me.FHRSAMT.BorderColor = System.Drawing.Color.Black
            Me.FHRSAMT.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FHRSAMT.BorderWidth = 1.0!
            Me.FHRSAMT.CanGrow = False
            Me.FHRSAMT.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4", "{0:n2}")})
            Me.FHRSAMT.Dpi = 100.0!
            Me.FHRSAMT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FHRSAMT.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 0!)
            Me.FHRSAMT.Name = "FHRSAMT"
            Me.FHRSAMT.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FHRSAMT.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FHRSAMT.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0:n2}"
            Me.FHRSAMT.Summary = XrSummary2
            Me.FHRSAMT.Text = "FHRSAMT"
            Me.FHRSAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text80
            '
            Me.Text80.BackColor = System.Drawing.Color.Transparent
            Me.Text80.BorderColor = System.Drawing.Color.Black
            Me.Text80.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text80.BorderWidth = 1.0!
            Me.Text80.CanGrow = False
            Me.Text80.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours", "{0:n2}")})
            Me.Text80.Dpi = 100.0!
            Me.Text80.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text80.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 0!)
            Me.Text80.Name = "Text80"
            Me.Text80.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text80.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text80.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0:n2}"
            Me.Text80.Summary = XrSummary3
            Me.Text80.Text = "Text80"
            Me.Text80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FMU
            '
            Me.FMU.BackColor = System.Drawing.Color.Transparent
            Me.FMU.BorderColor = System.Drawing.Color.Black
            Me.FMU.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FMU.BorderWidth = 1.0!
            Me.FMU.CanGrow = False
            Me.FMU.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Variance", "{0:n2}")})
            Me.FMU.Dpi = 100.0!
            Me.FMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FMU.LocationFloat = New DevExpress.Utils.PointFloat(523.292!, 0!)
            Me.FMU.Name = "FMU"
            Me.FMU.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FMU.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FMU.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0:n2}"
            Me.FMU.Summary = XrSummary4
            Me.FMU.Text = "FMU"
            Me.FMU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FCOST
            '
            Me.FCOST.BackColor = System.Drawing.Color.Transparent
            Me.FCOST.BorderColor = System.Drawing.Color.Black
            Me.FCOST.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FCOST.BorderWidth = 1.0!
            Me.FCOST.CanGrow = False
            Me.FCOST.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualAmount", "{0:n2}")})
            Me.FCOST.Dpi = 100.0!
            Me.FCOST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FCOST.LocationFloat = New DevExpress.Utils.PointFloat(460.292!, 0!)
            Me.FCOST.Name = "FCOST"
            Me.FCOST.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FCOST.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FCOST.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0:n2}"
            Me.FCOST.Summary = XrSummary5
            Me.FCOST.Text = "FCOST"
            Me.FCOST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTAX
            '
            Me.FTAX.BackColor = System.Drawing.Color.Transparent
            Me.FTAX.BorderColor = System.Drawing.Color.Black
            Me.FTAX.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTAX.BorderWidth = 1.0!
            Me.FTAX.CanGrow = False
            Me.FTAX.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfResaleTax", "{0:n2}")})
            Me.FTAX.Dpi = 100.0!
            Me.FTAX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTAX.LocationFloat = New DevExpress.Utils.PointFloat(586.292!, 0!)
            Me.FTAX.Name = "FTAX"
            Me.FTAX.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTAX.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTAX.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0:n2}"
            Me.FTAX.Summary = XrSummary6
            Me.FTAX.Text = "FTAX"
            Me.FTAX.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelSumOfOpenPOAmount
            '
            Me.LabelSumOfOpenPOAmount.BackColor = System.Drawing.Color.Transparent
            Me.LabelSumOfOpenPOAmount.BorderColor = System.Drawing.Color.Black
            Me.LabelSumOfOpenPOAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelSumOfOpenPOAmount.BorderWidth = 1.0!
            Me.LabelSumOfOpenPOAmount.CanGrow = False
            Me.LabelSumOfOpenPOAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount", "{0:n2}")})
            Me.LabelSumOfOpenPOAmount.Dpi = 100.0!
            Me.LabelSumOfOpenPOAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSumOfOpenPOAmount.LocationFloat = New DevExpress.Utils.PointFloat(843.2917!, 0!)
            Me.LabelSumOfOpenPOAmount.Name = "LabelSumOfOpenPOAmount"
            Me.LabelSumOfOpenPOAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelSumOfOpenPOAmount.SizeF = New System.Drawing.SizeF(52.58331!, 19.0!)
            Me.LabelSumOfOpenPOAmount.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0:n2}"
            Me.LabelSumOfOpenPOAmount.Summary = XrSummary7
            Me.LabelSumOfOpenPOAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelSumOfNBAmount
            '
            Me.LabelSumOfNBAmount.BackColor = System.Drawing.Color.Transparent
            Me.LabelSumOfNBAmount.BorderColor = System.Drawing.Color.Black
            Me.LabelSumOfNBAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelSumOfNBAmount.BorderWidth = 1.0!
            Me.LabelSumOfNBAmount.CanGrow = False
            Me.LabelSumOfNBAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField1", "{0:n2}")})
            Me.LabelSumOfNBAmount.Dpi = 100.0!
            Me.LabelSumOfNBAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSumOfNBAmount.LocationFloat = New DevExpress.Utils.PointFloat(895.875!, 0!)
            Me.LabelSumOfNBAmount.Name = "LabelSumOfNBAmount"
            Me.LabelSumOfNBAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelSumOfNBAmount.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.LabelSumOfNBAmount.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0:n2}"
            Me.LabelSumOfNBAmount.Summary = XrSummary8
            Me.LabelSumOfNBAmount.Text = "LabelSumOfNBAmount"
            Me.LabelSumOfNBAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Estimate
            '
            Me.Estimate.BackColor = System.Drawing.Color.Transparent
            Me.Estimate.BorderColor = System.Drawing.Color.Black
            Me.Estimate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Estimate.BorderWidth = 1.0!
            Me.Estimate.CanGrow = False
            Me.Estimate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours", "{0:n2}")})
            Me.Estimate.Dpi = 100.0!
            Me.Estimate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Estimate.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 0!)
            Me.Estimate.Name = "Estimate"
            Me.Estimate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Estimate.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Estimate.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0:n2}"
            Me.Estimate.Summary = XrSummary9
            Me.Estimate.Text = "Estimate"
            Me.Estimate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Total
            '
            Me.Total.BackColor = System.Drawing.Color.Transparent
            Me.Total.BorderColor = System.Drawing.Color.Black
            Me.Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Total.BorderWidth = 1.0!
            Me.Total.CanGrow = False
            Me.Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField", "{0:n2}")})
            Me.Total.Dpi = 100.0!
            Me.Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Total.LocationFloat = New DevExpress.Utils.PointFloat(649.292!, 0!)
            Me.Total.Name = "Total"
            Me.Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Total.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Total.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0:n2}"
            Me.Total.Summary = XrSummary10
            Me.Total.Text = "Total"
            Me.Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelUnbilled
            '
            Me.LabelUnbilled.BackColor = System.Drawing.Color.Transparent
            Me.LabelUnbilled.BorderColor = System.Drawing.Color.Black
            Me.LabelUnbilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelUnbilled.BorderWidth = 1.0!
            Me.LabelUnbilled.CanGrow = False
            Me.LabelUnbilled.Dpi = 100.0!
            Me.LabelUnbilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelUnbilled.LocationFloat = New DevExpress.Utils.PointFloat(958.875!, 0!)
            Me.LabelUnbilled.Name = "LabelUnbilled"
            Me.LabelUnbilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelUnbilled.SizeF = New System.Drawing.SizeF(41.125!, 19.0!)
            Me.LabelUnbilled.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0:n2}"
            Me.LabelUnbilled.Summary = XrSummary11
            Me.LabelUnbilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Billed
            '
            Me.Billed.BackColor = System.Drawing.Color.Transparent
            Me.Billed.BorderColor = System.Drawing.Color.Black
            Me.Billed.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Billed.BorderWidth = 1.0!
            Me.Billed.CanGrow = False
            Me.Billed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost", "{0:n2}")})
            Me.Billed.Dpi = 100.0!
            Me.Billed.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Billed.LocationFloat = New DevExpress.Utils.PointFloat(712.2921!, 0!)
            Me.Billed.Name = "Billed"
            Me.Billed.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Billed.SizeF = New System.Drawing.SizeF(69.70789!, 19.0!)
            Me.Billed.StylePriority.UseFont = False
            XrSummary12.FormatString = "{0:n2}"
            Me.Billed.Summary = XrSummary12
            Me.Billed.Text = "Billed"
            Me.Billed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDate
            '
            Me.LabelDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelDate.BorderColor = System.Drawing.Color.Black
            Me.LabelDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDate.BorderWidth = 1.0!
            Me.LabelDate.CanGrow = False
            Me.LabelDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDate", "{0:d}")})
            Me.LabelDate.Dpi = 100.0!
            Me.LabelDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(164.6245!, 0!)
            Me.LabelDate.Name = "LabelDate"
            Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDate.SizeF = New System.Drawing.SizeF(89.75031!, 19.0!)
            Me.LabelDate.StylePriority.UseFont = False
            XrSummary13.FormatString = "{0:d}"
            Me.LabelDate.Summary = XrSummary13
            Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LabelItemDesc
            '
            Me.LabelItemDesc.BackColor = System.Drawing.Color.Transparent
            Me.LabelItemDesc.BorderColor = System.Drawing.Color.Black
            Me.LabelItemDesc.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelItemDesc.BorderWidth = 1.0!
            Me.LabelItemDesc.CanGrow = False
            Me.LabelItemDesc.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDescription", "{0}")})
            Me.LabelItemDesc.Dpi = 100.0!
            Me.LabelItemDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelItemDesc.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelItemDesc.Name = "LabelItemDesc"
            Me.LabelItemDesc.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelItemDesc.SizeF = New System.Drawing.SizeF(164.6245!, 19.0!)
            Me.LabelItemDesc.StylePriority.UseFont = False
            XrSummary14.FormatString = "{0}"
            Me.LabelItemDesc.Summary = XrSummary14
            Me.LabelItemDesc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportHeader
            '
            Me.ReportHeader.BackColor = System.Drawing.Color.Transparent
            Me.ReportHeader.Dpi = 100.0!
            Me.ReportHeader.HeightF = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.BackColor = System.Drawing.Color.Transparent
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.BackColor = System.Drawing.Color.Transparent
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Title, Me.LabelPageHeader_SortBy, Me.LineTopLine, Me.LineBottomLine})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 67.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Dpi = 100.0!
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(0!, 8.0!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(442.0!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Job Analysis (V11) - Detail by Function"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_SortBy
            '
            Me.LabelPageHeader_SortBy.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_SortBy.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_SortBy.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_SortBy.BorderWidth = 1.0!
            Me.LabelPageHeader_SortBy.CanGrow = False
            Me.LabelPageHeader_SortBy.Dpi = 100.0!
            Me.LabelPageHeader_SortBy.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_SortBy.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_SortBy.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.0!)
            Me.LabelPageHeader_SortBy.Name = "LabelPageHeader_SortBy"
            Me.LabelPageHeader_SortBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_SortBy.SizeF = New System.Drawing.SizeF(267.0!, 21.0!)
            Me.LabelPageHeader_SortBy.StylePriority.UseFont = False
            Me.LabelPageHeader_SortBy.StylePriority.UseForeColor = False
            Me.LabelPageHeader_SortBy.Text = "Sorted by Client/Div/Prod "
            Me.LabelPageHeader_SortBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.Dpi = 100.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.0!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            '
            'LineBottomLine
            '
            Me.LineBottomLine.BorderColor = System.Drawing.Color.Silver
            Me.LineBottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineBottomLine.BorderWidth = 4.0!
            Me.LineBottomLine.Dpi = 100.0!
            Me.LineBottomLine.ForeColor = System.Drawing.Color.Silver
            Me.LineBottomLine.LineWidth = 4
            Me.LineBottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 62.0!)
            Me.LineBottomLine.Name = "LineBottomLine"
            Me.LineBottomLine.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            '
            'PageFooter
            '
            Me.PageFooter.BackColor = System.Drawing.Color.Transparent
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.XrPageInfo1, Me.Line26})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 25.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Dpi = 100.0!
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pageInfo2.Format = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.000028!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(353.125!, 20.99995!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrPageInfo1
            '
            Me.XrPageInfo1.Dpi = 100.0!
            Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo1.Format = "Page {0} of {1}"
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 4.000028!)
            Me.XrPageInfo1.Name = "XrPageInfo1"
            Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(321.0001!, 20.99997!)
            Me.XrPageInfo1.StylePriority.UseFont = False
            Me.XrPageInfo1.StylePriority.UseTextAlignment = False
            Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Line26
            '
            Me.Line26.BorderColor = System.Drawing.Color.Silver
            Me.Line26.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line26.BorderWidth = 4.0!
            Me.Line26.Dpi = 100.0!
            Me.Line26.ForeColor = System.Drawing.Color.Silver
            Me.Line26.LineWidth = 4
            Me.Line26.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Line26.Name = "Line26"
            Me.Line26.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            '
            'GroupHeaderFunction
            '
            Me.GroupHeaderFunction.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeaderFunction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.FUNC})
            Me.GroupHeaderFunction.Dpi = 100.0!
            Me.GroupHeaderFunction.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderFunction.HeightF = 20.0!
            Me.GroupHeaderFunction.Name = "GroupHeaderFunction"
            Me.GroupHeaderFunction.RepeatEveryPage = True
            '
            'FUNC
            '
            Me.FUNC.BackColor = System.Drawing.Color.Transparent
            Me.FUNC.BorderColor = System.Drawing.Color.Black
            Me.FUNC.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FUNC.BorderWidth = 1.0!
            Me.FUNC.CanGrow = False
            Me.FUNC.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionFull")})
            Me.FUNC.Dpi = 100.0!
            Me.FUNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FUNC.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.FUNC.Name = "FUNC"
            Me.FUNC.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FUNC.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
            Me.FUNC.StylePriority.UseFont = False
            XrSummary15.FormatString = "{0}"
            Me.FUNC.Summary = XrSummary15
            Me.FUNC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMarginBand1
            '
            Me.TopMarginBand1.Dpi = 100.0!
            Me.TopMarginBand1.HeightF = 50.0!
            Me.TopMarginBand1.Name = "TopMarginBand1"
            '
            'BottomMarginBand1
            '
            Me.BottomMarginBand1.Dpi = 100.0!
            Me.BottomMarginBand1.HeightF = 50.0!
            Me.BottomMarginBand1.Name = "BottomMarginBand1"
            '
            'GroupHeaderForm_CDP
            '
            Me.GroupHeaderForm_CDP.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeaderForm_CDP.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelCDP_ClientData, Me.Text31, Me.LabelPageHeader_ProductData, Me.LabelCDP_Client, Me.Label158, Me.LabelPageHeader_Product, Me.Label156, Me.AE})
            Me.GroupHeaderForm_CDP.Dpi = 100.0!
            Me.GroupHeaderForm_CDP.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderForm_CDP.HeightF = 42.70833!
            Me.GroupHeaderForm_CDP.Level = 4
            Me.GroupHeaderForm_CDP.Name = "GroupHeaderForm_CDP"
            Me.GroupHeaderForm_CDP.RepeatEveryPage = True
            '
            'LabelCDP_ClientData
            '
            Me.LabelCDP_ClientData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientFull")})
            Me.LabelCDP_ClientData.Dpi = 100.0!
            Me.LabelCDP_ClientData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCDP_ClientData.LocationFloat = New DevExpress.Utils.PointFloat(76.875!, 3.999996!)
            Me.LabelCDP_ClientData.Name = "LabelCDP_ClientData"
            Me.LabelCDP_ClientData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelCDP_ClientData.SizeF = New System.Drawing.SizeF(301.0002!, 19.00001!)
            Me.LabelCDP_ClientData.StylePriority.UseFont = False
            '
            'Text31
            '
            Me.Text31.BackColor = System.Drawing.Color.Transparent
            Me.Text31.BorderColor = System.Drawing.Color.Black
            Me.Text31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text31.BorderWidth = 1.0!
            Me.Text31.CanGrow = False
            Me.Text31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionFull")})
            Me.Text31.Dpi = 100.0!
            Me.Text31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text31.LocationFloat = New DevExpress.Utils.PointFloat(76.875!, 23.00002!)
            Me.Text31.Name = "Text31"
            Me.Text31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text31.SizeF = New System.Drawing.SizeF(301.0002!, 19.0!)
            Me.Text31.StylePriority.UseFont = False
            XrSummary16.FormatString = "{0}"
            Me.Text31.Summary = XrSummary16
            Me.Text31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ProductData
            '
            Me.LabelPageHeader_ProductData.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ProductData.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ProductData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ProductData.BorderWidth = 1.0!
            Me.LabelPageHeader_ProductData.CanGrow = False
            Me.LabelPageHeader_ProductData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductFull")})
            Me.LabelPageHeader_ProductData.Dpi = 100.0!
            Me.LabelPageHeader_ProductData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_ProductData.LocationFloat = New DevExpress.Utils.PointFloat(621.0003!, 0!)
            Me.LabelPageHeader_ProductData.Name = "LabelPageHeader_ProductData"
            Me.LabelPageHeader_ProductData.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ProductData.SizeF = New System.Drawing.SizeF(254.0!, 19.0!)
            Me.LabelPageHeader_ProductData.StylePriority.UseFont = False
            XrSummary17.FormatString = "{0}"
            Me.LabelPageHeader_ProductData.Summary = XrSummary17
            Me.LabelPageHeader_ProductData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCDP_Client
            '
            Me.LabelCDP_Client.BackColor = System.Drawing.Color.Transparent
            Me.LabelCDP_Client.BorderColor = System.Drawing.Color.Black
            Me.LabelCDP_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCDP_Client.BorderWidth = 1.0!
            Me.LabelCDP_Client.CanGrow = False
            Me.LabelCDP_Client.Dpi = 100.0!
            Me.LabelCDP_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCDP_Client.ForeColor = System.Drawing.Color.Black
            Me.LabelCDP_Client.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.0!)
            Me.LabelCDP_Client.Name = "LabelCDP_Client"
            Me.LabelCDP_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCDP_Client.SizeF = New System.Drawing.SizeF(58.0!, 19.0!)
            Me.LabelCDP_Client.StylePriority.UseFont = False
            Me.LabelCDP_Client.Text = "Client:"
            Me.LabelCDP_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label158
            '
            Me.Label158.BackColor = System.Drawing.Color.Transparent
            Me.Label158.BorderColor = System.Drawing.Color.Black
            Me.Label158.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label158.BorderWidth = 1.0!
            Me.Label158.CanGrow = False
            Me.Label158.Dpi = 100.0!
            Me.Label158.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label158.ForeColor = System.Drawing.Color.Black
            Me.Label158.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.0!)
            Me.Label158.Name = "Label158"
            Me.Label158.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label158.SizeF = New System.Drawing.SizeF(58.0!, 19.0!)
            Me.Label158.StylePriority.UseFont = False
            Me.Label158.Text = "Division:"
            Me.Label158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Product
            '
            Me.LabelPageHeader_Product.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Product.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Product.BorderWidth = 1.0!
            Me.LabelPageHeader_Product.CanGrow = False
            Me.LabelPageHeader_Product.Dpi = 100.0!
            Me.LabelPageHeader_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(491.0002!, 3.999996!)
            Me.LabelPageHeader_Product.Name = "LabelPageHeader_Product"
            Me.LabelPageHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Product.SizeF = New System.Drawing.SizeF(54.0!, 19.0!)
            Me.LabelPageHeader_Product.StylePriority.UseFont = False
            Me.LabelPageHeader_Product.Text = "Product:"
            Me.LabelPageHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label153
            '
            Me.Label153.BackColor = System.Drawing.Color.Transparent
            Me.Label153.BorderColor = System.Drawing.Color.Black
            Me.Label153.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label153.BorderWidth = 1.0!
            Me.Label153.CanGrow = False
            Me.Label153.Dpi = 100.0!
            Me.Label153.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label153.ForeColor = System.Drawing.Color.Black
            Me.Label153.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Label153.Name = "Label153"
            Me.Label153.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label153.SizeF = New System.Drawing.SizeF(76.875!, 19.0!)
            Me.Label153.StylePriority.UseFont = False
            Me.Label153.Text = "Job Number:"
            Me.Label153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Job
            '
            Me.Job.BackColor = System.Drawing.Color.Transparent
            Me.Job.BorderColor = System.Drawing.Color.Black
            Me.Job.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Job.BorderWidth = 1.0!
            Me.Job.CanGrow = False
            Me.Job.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobFull")})
            Me.Job.Dpi = 100.0!
            Me.Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Job.LocationFloat = New DevExpress.Utils.PointFloat(76.875!, 0!)
            Me.Job.Name = "Job"
            Me.Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Job.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.Job.StylePriority.UseFont = False
            XrSummary19.FormatString = "{0}"
            Me.Job.Summary = XrSummary19
            Me.Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label156
            '
            Me.Label156.BackColor = System.Drawing.Color.Transparent
            Me.Label156.BorderColor = System.Drawing.Color.Black
            Me.Label156.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label156.BorderWidth = 1.0!
            Me.Label156.CanGrow = False
            Me.Label156.Dpi = 100.0!
            Me.Label156.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label156.ForeColor = System.Drawing.Color.Black
            Me.Label156.LocationFloat = New DevExpress.Utils.PointFloat(491.0002!, 23.00002!)
            Me.Label156.Name = "Label156"
            Me.Label156.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label156.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label156.StylePriority.UseFont = False
            Me.Label156.Text = "Account Executive:"
            Me.Label156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'AE
            '
            Me.AE.BackColor = System.Drawing.Color.Transparent
            Me.AE.BorderColor = System.Drawing.Color.Black
            Me.AE.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.AE.BorderWidth = 1.0!
            Me.AE.CanGrow = False
            Me.AE.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountExecutiveFull")})
            Me.AE.Dpi = 100.0!
            Me.AE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AE.LocationFloat = New DevExpress.Utils.PointFloat(621.0002!, 22.99999!)
            Me.AE.Name = "AE"
            Me.AE.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.AE.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.AE.StylePriority.UseFont = False
            XrSummary18.FormatString = "{0}"
            Me.AE.Summary = XrSummary18
            Me.AE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label154
            '
            Me.Label154.BackColor = System.Drawing.Color.Transparent
            Me.Label154.BorderColor = System.Drawing.Color.Black
            Me.Label154.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label154.BorderWidth = 1.0!
            Me.Label154.CanGrow = False
            Me.Label154.Dpi = 100.0!
            Me.Label154.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label154.ForeColor = System.Drawing.Color.Black
            Me.Label154.LocationFloat = New DevExpress.Utils.PointFloat(491.0002!, 0!)
            Me.Label154.Name = "Label154"
            Me.Label154.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label154.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label154.StylePriority.UseFont = False
            Me.Label154.Text = "Job Component:"
            Me.Label154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text120
            '
            Me.Text120.BackColor = System.Drawing.Color.Transparent
            Me.Text120.BorderColor = System.Drawing.Color.Black
            Me.Text120.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text120.BorderWidth = 1.0!
            Me.Text120.CanGrow = False
            Me.Text120.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentFull")})
            Me.Text120.Dpi = 100.0!
            Me.Text120.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text120.LocationFloat = New DevExpress.Utils.PointFloat(621.0002!, 0!)
            Me.Text120.Name = "Text120"
            Me.Text120.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text120.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.Text120.StylePriority.UseFont = False
            XrSummary20.FormatString = "{0}"
            Me.Text120.Summary = XrSummary20
            Me.Text120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooter1
            '
            Me.GroupFooter1.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel32, Me.XrLabel26, Me.XrLabel27, Me.XrLabel25, Me.XrLabel23, Me.XrLabel24, Me.XrLabel21, Me.XrLabel22, Me.XrLabel20, Me.XrLabel18, Me.XrLabel19, Me.Label52, Me.Text90, Me.CTotal, Me.CNBillable, Me.CBilled, Me.Text99, Me.Label150, Me.Label164, Me.Label165, Me.Label166, Me.Label167, Me.Line168})
            Me.GroupFooter1.Dpi = 100.0!
            Me.GroupFooter1.HeightF = 80.0!
            Me.GroupFooter1.Level = 4
            Me.GroupFooter1.Name = "GroupFooter1"
            Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrLabel32
            '
            Me.XrLabel32.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel32.BorderColor = System.Drawing.Color.Black
            Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel32.BorderWidth = 1.0!
            Me.XrLabel32.CanGrow = False
            Me.XrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField", "{0:n2}")})
            Me.XrLabel32.Dpi = 100.0!
            Me.XrLabel32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(782.0001!, 54.04167!)
            Me.XrLabel32.Name = "XrLabel32"
            Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel32.SizeF = New System.Drawing.SizeF(61.29175!, 19.0!)
            Me.XrLabel32.StylePriority.UseFont = False
            XrSummary21.FormatString = "{0:n2}"
            Me.XrLabel32.Summary = XrSummary21
            Me.XrLabel32.Text = "XrLabel32"
            Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel26
            '
            Me.XrLabel26.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel26.BorderColor = System.Drawing.Color.Black
            Me.XrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel26.BorderWidth = 1.0!
            Me.XrLabel26.CanGrow = False
            Me.XrLabel26.Dpi = 100.0!
            Me.XrLabel26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel26.ForeColor = System.Drawing.Color.Black
            Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 5.041695!)
            Me.XrLabel26.Name = "XrLabel26"
            Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel26.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel26.StylePriority.UseFont = False
            Me.XrLabel26.Text = "Actual Hrs/Qty"
            Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel27
            '
            Me.XrLabel27.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel27.BorderColor = System.Drawing.Color.Black
            Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel27.BorderWidth = 1.0!
            Me.XrLabel27.CanGrow = False
            Me.XrLabel27.Dpi = 100.0!
            Me.XrLabel27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel27.ForeColor = System.Drawing.Color.Black
            Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 5.041695!)
            Me.XrLabel27.Name = "XrLabel27"
            Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel27.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel27.StylePriority.UseFont = False
            Me.XrLabel27.Text = "Estimated Costs"
            Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel25
            '
            Me.XrLabel25.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel25.BorderColor = System.Drawing.Color.Black
            Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel25.BorderWidth = 1.0!
            Me.XrLabel25.CanGrow = False
            Me.XrLabel25.Dpi = 100.0!
            Me.XrLabel25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel25.ForeColor = System.Drawing.Color.Black
            Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(523.2919!, 0!)
            Me.XrLabel25.Name = "XrLabel25"
            Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel25.SizeF = New System.Drawing.SizeF(63.0!, 43.04168!)
            Me.XrLabel25.StylePriority.UseFont = False
            Me.XrLabel25.Text = "Costs Variance Est Vs Act"
            Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel23
            '
            Me.XrLabel23.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel23.BorderColor = System.Drawing.Color.Black
            Me.XrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel23.BorderWidth = 1.0!
            Me.XrLabel23.CanGrow = False
            Me.XrLabel23.Dpi = 100.0!
            Me.XrLabel23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel23.ForeColor = System.Drawing.Color.Black
            Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(586.2917!, 5.041695!)
            Me.XrLabel23.Name = "XrLabel23"
            Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel23.SizeF = New System.Drawing.SizeF(63.0!, 37.99998!)
            Me.XrLabel23.StylePriority.UseFont = False
            Me.XrLabel23.Text = "Actual Resale Tax"
            Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel24
            '
            Me.XrLabel24.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel24.BorderColor = System.Drawing.Color.Black
            Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel24.BorderWidth = 1.0!
            Me.XrLabel24.CanGrow = False
            Me.XrLabel24.Dpi = 100.0!
            Me.XrLabel24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel24.ForeColor = System.Drawing.Color.Black
            Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(460.2919!, 5.041695!)
            Me.XrLabel24.Name = "XrLabel24"
            Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel24.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel24.StylePriority.UseFont = False
            Me.XrLabel24.Text = "Actual Cost"
            Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel21
            '
            Me.XrLabel21.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel21.BorderColor = System.Drawing.Color.Black
            Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel21.BorderWidth = 1.0!
            Me.XrLabel21.CanGrow = False
            Me.XrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Variance")})
            Me.XrLabel21.Dpi = 100.0!
            Me.XrLabel21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(523.292!, 54.04167!)
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel21.StylePriority.UseFont = False
            XrSummary22.FormatString = "{0:n2}"
            XrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel21.Summary = XrSummary22
            Me.XrLabel21.Text = "XrLabel21"
            Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel22
            '
            Me.XrLabel22.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel22.BorderColor = System.Drawing.Color.Black
            Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel22.BorderWidth = 1.0!
            Me.XrLabel22.CanGrow = False
            Me.XrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfResaleTax")})
            Me.XrLabel22.Dpi = 100.0!
            Me.XrLabel22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(586.292!, 54.04167!)
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel22.StylePriority.UseFont = False
            XrSummary23.FormatString = "{0:n2}"
            XrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel22.Summary = XrSummary23
            Me.XrLabel22.Text = "FTAX"
            Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualAmount")})
            Me.XrLabel20.Dpi = 100.0!
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(460.2918!, 54.04167!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel20.StylePriority.UseFont = False
            XrSummary24.FormatString = "{0:n2}"
            XrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel20.Summary = XrSummary24
            Me.XrLabel20.Text = "XrLabel20"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel18
            '
            Me.XrLabel18.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel18.BorderColor = System.Drawing.Color.Black
            Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel18.BorderWidth = 1.0!
            Me.XrLabel18.CanGrow = False
            Me.XrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfBillEmpHours")})
            Me.XrLabel18.Dpi = 100.0!
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 54.04167!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            XrSummary25.FormatString = "{0:n2}"
            XrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel18.Summary = XrSummary25
            Me.XrLabel18.Text = "XrLabel18"
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel19
            '
            Me.XrLabel19.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel19.BorderColor = System.Drawing.Color.Black
            Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel19.BorderWidth = 1.0!
            Me.XrLabel19.CanGrow = False
            Me.XrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.XrLabel19.Dpi = 100.0!
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 54.04167!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            XrSummary26.FormatString = "{0:n2}"
            XrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel19.Summary = XrSummary26
            Me.XrLabel19.Text = "XrLabel19"
            Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label52
            '
            Me.Label52.BackColor = System.Drawing.Color.Transparent
            Me.Label52.BorderColor = System.Drawing.Color.Black
            Me.Label52.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label52.BorderWidth = 1.0!
            Me.Label52.CanGrow = False
            Me.Label52.Dpi = 100.0!
            Me.Label52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label52.ForeColor = System.Drawing.Color.Black
            Me.Label52.LocationFloat = New DevExpress.Utils.PointFloat(0!, 54.04167!)
            Me.Label52.Name = "Label52"
            Me.Label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label52.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
            Me.Label52.StylePriority.UseFont = False
            Me.Label52.Text = "Total for Client/Division/Product:"
            Me.Label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text90
            '
            Me.Text90.BackColor = System.Drawing.Color.Transparent
            Me.Text90.BorderColor = System.Drawing.Color.Black
            Me.Text90.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text90.BorderWidth = 1.0!
            Me.Text90.CanGrow = False
            Me.Text90.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.Text90.Dpi = 100.0!
            Me.Text90.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text90.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 54.04167!)
            Me.Text90.Name = "Text90"
            Me.Text90.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text90.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text90.StylePriority.UseFont = False
            XrSummary27.FormatString = "{0:n2}"
            XrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text90.Summary = XrSummary27
            Me.Text90.Text = "Text90"
            Me.Text90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CTotal
            '
            Me.CTotal.BackColor = System.Drawing.Color.Transparent
            Me.CTotal.BorderColor = System.Drawing.Color.Black
            Me.CTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CTotal.BorderWidth = 1.0!
            Me.CTotal.CanGrow = False
            Me.CTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.CTotal.Dpi = 100.0!
            Me.CTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CTotal.LocationFloat = New DevExpress.Utils.PointFloat(649.292!, 54.04167!)
            Me.CTotal.Name = "CTotal"
            Me.CTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CTotal.StylePriority.UseFont = False
            XrSummary28.FormatString = "{0:n2}"
            XrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CTotal.Summary = XrSummary28
            Me.CTotal.Text = "CTotal"
            Me.CTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CNBillable
            '
            Me.CNBillable.BackColor = System.Drawing.Color.Transparent
            Me.CNBillable.BorderColor = System.Drawing.Color.Black
            Me.CNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CNBillable.BorderWidth = 1.0!
            Me.CNBillable.CanGrow = False
            Me.CNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField1")})
            Me.CNBillable.Dpi = 100.0!
            Me.CNBillable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CNBillable.LocationFloat = New DevExpress.Utils.PointFloat(895.875!, 54.04167!)
            Me.CNBillable.Name = "CNBillable"
            Me.CNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CNBillable.StylePriority.UseFont = False
            XrSummary29.FormatString = "{0:n2}"
            XrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CNBillable.Summary = XrSummary29
            Me.CNBillable.Text = "CNBillable"
            Me.CNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CBilled
            '
            Me.CBilled.BackColor = System.Drawing.Color.Transparent
            Me.CBilled.BorderColor = System.Drawing.Color.Black
            Me.CBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CBilled.BorderWidth = 1.0!
            Me.CBilled.CanGrow = False
            Me.CBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.CBilled.Dpi = 100.0!
            Me.CBilled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CBilled.LocationFloat = New DevExpress.Utils.PointFloat(712.2921!, 54.04167!)
            Me.CBilled.Name = "CBilled"
            Me.CBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CBilled.SizeF = New System.Drawing.SizeF(69.70789!, 19.0!)
            Me.CBilled.StylePriority.UseFont = False
            XrSummary30.FormatString = "{0:n2}"
            XrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CBilled.Summary = XrSummary30
            Me.CBilled.Text = "CBilled"
            Me.CBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text99
            '
            Me.Text99.BackColor = System.Drawing.Color.Transparent
            Me.Text99.BorderColor = System.Drawing.Color.Black
            Me.Text99.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text99.BorderWidth = 1.0!
            Me.Text99.CanGrow = False
            Me.Text99.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.Text99.Dpi = 100.0!
            Me.Text99.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text99.LocationFloat = New DevExpress.Utils.PointFloat(843.2917!, 54.04167!)
            Me.Text99.Name = "Text99"
            Me.Text99.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text99.SizeF = New System.Drawing.SizeF(52.58325!, 19.0!)
            Me.Text99.StylePriority.UseFont = False
            XrSummary31.FormatString = "{0:n2}"
            XrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text99.Summary = XrSummary31
            Me.Text99.Text = "Text99"
            Me.Text99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label150
            '
            Me.Label150.BackColor = System.Drawing.Color.Transparent
            Me.Label150.BorderColor = System.Drawing.Color.Black
            Me.Label150.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label150.BorderWidth = 1.0!
            Me.Label150.CanGrow = False
            Me.Label150.Dpi = 100.0!
            Me.Label150.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label150.ForeColor = System.Drawing.Color.Black
            Me.Label150.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 5.041695!)
            Me.Label150.Name = "Label150"
            Me.Label150.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label150.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label150.StylePriority.UseFont = False
            Me.Label150.Text = "Estimated Hrs/Qty"
            Me.Label150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label164
            '
            Me.Label164.BackColor = System.Drawing.Color.Transparent
            Me.Label164.BorderColor = System.Drawing.Color.Black
            Me.Label164.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label164.BorderWidth = 1.0!
            Me.Label164.CanGrow = False
            Me.Label164.Dpi = 100.0!
            Me.Label164.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label164.ForeColor = System.Drawing.Color.Black
            Me.Label164.LocationFloat = New DevExpress.Utils.PointFloat(649.2919!, 5.041695!)
            Me.Label164.Name = "Label164"
            Me.Label164.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label164.SizeF = New System.Drawing.SizeF(63.0!, 37.99998!)
            Me.Label164.StylePriority.UseFont = False
            Me.Label164.Text = "Billings To Date"
            Me.Label164.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label165
            '
            Me.Label165.BackColor = System.Drawing.Color.Transparent
            Me.Label165.BorderColor = System.Drawing.Color.Black
            Me.Label165.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label165.BorderWidth = 1.0!
            Me.Label165.CanGrow = False
            Me.Label165.Dpi = 100.0!
            Me.Label165.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label165.ForeColor = System.Drawing.Color.Black
            Me.Label165.LocationFloat = New DevExpress.Utils.PointFloat(895.875!, 5.041695!)
            Me.Label165.Name = "Label165"
            Me.Label165.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label165.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label165.StylePriority.UseFont = False
            Me.Label165.Text = "Actual Balance To Reconcile"
            Me.Label165.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label166
            '
            Me.Label166.BackColor = System.Drawing.Color.Transparent
            Me.Label166.BorderColor = System.Drawing.Color.Black
            Me.Label166.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label166.BorderWidth = 1.0!
            Me.Label166.CanGrow = False
            Me.Label166.Dpi = 100.0!
            Me.Label166.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label166.ForeColor = System.Drawing.Color.Black
            Me.Label166.LocationFloat = New DevExpress.Utils.PointFloat(712.2921!, 5.041695!)
            Me.Label166.Name = "Label166"
            Me.Label166.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label166.SizeF = New System.Drawing.SizeF(130.9996!, 37.99998!)
            Me.Label166.StylePriority.UseFont = False
            Me.Label166.Text = "Reconciled/Recognized Cost/OOP            GP"
            Me.Label166.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label167
            '
            Me.Label167.BackColor = System.Drawing.Color.Transparent
            Me.Label167.BorderColor = System.Drawing.Color.Black
            Me.Label167.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label167.BorderWidth = 1.0!
            Me.Label167.CanGrow = False
            Me.Label167.Dpi = 100.0!
            Me.Label167.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label167.ForeColor = System.Drawing.Color.Black
            Me.Label167.LocationFloat = New DevExpress.Utils.PointFloat(843.2917!, 5.041695!)
            Me.Label167.Name = "Label167"
            Me.Label167.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label167.SizeF = New System.Drawing.SizeF(52.58331!, 37.99998!)
            Me.Label167.StylePriority.UseFont = False
            Me.Label167.Text = "Open PO's"
            Me.Label167.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Line168
            '
            Me.Line168.BorderColor = System.Drawing.Color.Silver
            Me.Line168.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line168.BorderWidth = 4.0!
            Me.Line168.Dpi = 100.0!
            Me.Line168.ForeColor = System.Drawing.Color.Silver
            Me.Line168.LineWidth = 4
            Me.Line168.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 43.04168!)
            Me.Line168.Name = "Line168"
            Me.Line168.SizeF = New System.Drawing.SizeF(727.7085!, 4.000027!)
            '
            'GroupHeader3
            '
            Me.GroupHeader3.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label129, Me.Label58, Me.Label66, Me.Label62, Me.Label64, Me.label3, Me.label4, Me.Label68, Me.Label70, Me.Label72, Me.Label74, Me.Line57, Me.Label60, Me.Text120, Me.Label154, Me.Job, Me.Label153})
            Me.GroupHeader3.Dpi = 100.0!
            Me.GroupHeader3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader3.HeightF = 86.62504!
            Me.GroupHeader3.Level = 3
            Me.GroupHeader3.Name = "GroupHeader3"
            Me.GroupHeader3.RepeatEveryPage = True
            '
            'GroupHeader1
            '
            Me.GroupHeader1.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader1.Dpi = 100.0!
            Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader1.HeightF = 0!
            Me.GroupHeader1.Level = 2
            Me.GroupHeader1.Name = "GroupHeader1"
            Me.GroupHeader1.RepeatEveryPage = True
            '
            'Label60
            '
            Me.Label60.BackColor = System.Drawing.Color.Transparent
            Me.Label60.BorderColor = System.Drawing.Color.Black
            Me.Label60.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label60.BorderWidth = 1.0!
            Me.Label60.CanGrow = False
            Me.Label60.Dpi = 100.0!
            Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label60.ForeColor = System.Drawing.Color.Black
            Me.Label60.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 37.08331!)
            Me.Label60.Name = "Label60"
            Me.Label60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label60.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label60.StylePriority.UseFont = False
            Me.Label60.Text = "Estimated Costs"
            Me.Label60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label58
            '
            Me.Label58.BackColor = System.Drawing.Color.Transparent
            Me.Label58.BorderColor = System.Drawing.Color.Black
            Me.Label58.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label58.BorderWidth = 1.0!
            Me.Label58.CanGrow = False
            Me.Label58.Dpi = 100.0!
            Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label58.ForeColor = System.Drawing.Color.Black
            Me.Label58.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 37.08344!)
            Me.Label58.Name = "Label58"
            Me.Label58.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label58.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label58.StylePriority.UseFont = False
            Me.Label58.Text = "Actual Hrs/Qty"
            Me.Label58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label66
            '
            Me.Label66.BackColor = System.Drawing.Color.Transparent
            Me.Label66.BorderColor = System.Drawing.Color.Black
            Me.Label66.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label66.BorderWidth = 1.0!
            Me.Label66.CanGrow = False
            Me.Label66.Dpi = 100.0!
            Me.Label66.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label66.ForeColor = System.Drawing.Color.Black
            Me.Label66.LocationFloat = New DevExpress.Utils.PointFloat(586.2916!, 37.08363!)
            Me.Label66.Name = "Label66"
            Me.Label66.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label66.SizeF = New System.Drawing.SizeF(63.0!, 37.99985!)
            Me.Label66.StylePriority.UseFont = False
            Me.Label66.Text = "Actual Resale Tax"
            Me.Label66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label62
            '
            Me.Label62.BackColor = System.Drawing.Color.Transparent
            Me.Label62.BorderColor = System.Drawing.Color.Black
            Me.Label62.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label62.BorderWidth = 1.0!
            Me.Label62.CanGrow = False
            Me.Label62.Dpi = 100.0!
            Me.Label62.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label62.ForeColor = System.Drawing.Color.Black
            Me.Label62.LocationFloat = New DevExpress.Utils.PointFloat(460.2918!, 37.08344!)
            Me.Label62.Name = "Label62"
            Me.Label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label62.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label62.StylePriority.UseFont = False
            Me.Label62.Text = "Actual Cost"
            Me.Label62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label64
            '
            Me.Label64.BackColor = System.Drawing.Color.Transparent
            Me.Label64.BorderColor = System.Drawing.Color.Black
            Me.Label64.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label64.BorderWidth = 1.0!
            Me.Label64.CanGrow = False
            Me.Label64.Dpi = 100.0!
            Me.Label64.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label64.ForeColor = System.Drawing.Color.Black
            Me.Label64.LocationFloat = New DevExpress.Utils.PointFloat(523.2916!, 27.08333!)
            Me.Label64.Name = "Label64"
            Me.Label64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label64.SizeF = New System.Drawing.SizeF(63.0!, 48.00014!)
            Me.Label64.StylePriority.UseFont = False
            Me.Label64.Text = "Costs Variance Est Vs Act"
            Me.Label64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label3
            '
            Me.label3.BackColor = System.Drawing.Color.Transparent
            Me.label3.BorderColor = System.Drawing.Color.Black
            Me.label3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.label3.BorderWidth = 1.0!
            Me.label3.CanGrow = False
            Me.label3.Dpi = 100.0!
            Me.label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label3.ForeColor = System.Drawing.Color.Black
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 37.08344!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Estimated Hrs/Qty"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label4
            '
            Me.label4.BackColor = System.Drawing.Color.Transparent
            Me.label4.BorderColor = System.Drawing.Color.Black
            Me.label4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.label4.BorderWidth = 1.0!
            Me.label4.CanGrow = False
            Me.label4.Dpi = 100.0!
            Me.label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label4.ForeColor = System.Drawing.Color.Black
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.0833!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "Function"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label68
            '
            Me.Label68.BackColor = System.Drawing.Color.Transparent
            Me.Label68.BorderColor = System.Drawing.Color.Black
            Me.Label68.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label68.BorderWidth = 1.0!
            Me.Label68.CanGrow = False
            Me.Label68.Dpi = 100.0!
            Me.Label68.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label68.ForeColor = System.Drawing.Color.Black
            Me.Label68.LocationFloat = New DevExpress.Utils.PointFloat(649.2916!, 37.08344!)
            Me.Label68.Name = "Label68"
            Me.Label68.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label68.SizeF = New System.Drawing.SizeF(63.0!, 37.99985!)
            Me.Label68.StylePriority.UseFont = False
            Me.Label68.Text = "Billings To Date"
            Me.Label68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label70
            '
            Me.Label70.BackColor = System.Drawing.Color.Transparent
            Me.Label70.BorderColor = System.Drawing.Color.Black
            Me.Label70.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label70.BorderWidth = 1.0!
            Me.Label70.CanGrow = False
            Me.Label70.Dpi = 100.0!
            Me.Label70.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label70.ForeColor = System.Drawing.Color.Black
            Me.Label70.LocationFloat = New DevExpress.Utils.PointFloat(895.8749!, 27.08333!)
            Me.Label70.Name = "Label70"
            Me.Label70.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label70.SizeF = New System.Drawing.SizeF(63.0!, 47.99998!)
            Me.Label70.StylePriority.UseFont = False
            Me.Label70.Text = "Actual Balance To Reconcile"
            Me.Label70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label72
            '
            Me.Label72.BackColor = System.Drawing.Color.Transparent
            Me.Label72.BorderColor = System.Drawing.Color.Black
            Me.Label72.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label72.BorderWidth = 1.0!
            Me.Label72.CanGrow = False
            Me.Label72.Dpi = 100.0!
            Me.Label72.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label72.ForeColor = System.Drawing.Color.Black
            Me.Label72.LocationFloat = New DevExpress.Utils.PointFloat(712.2917!, 37.08344!)
            Me.Label72.Name = "Label72"
            Me.Label72.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label72.SizeF = New System.Drawing.SizeF(130.9999!, 37.99985!)
            Me.Label72.StylePriority.UseFont = False
            Me.Label72.Text = "Reconciled/Recognized Cost/OOP              GP"
            Me.Label72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label74
            '
            Me.Label74.BackColor = System.Drawing.Color.Transparent
            Me.Label74.BorderColor = System.Drawing.Color.Black
            Me.Label74.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label74.BorderWidth = 1.0!
            Me.Label74.CanGrow = False
            Me.Label74.Dpi = 100.0!
            Me.Label74.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label74.ForeColor = System.Drawing.Color.Black
            Me.Label74.LocationFloat = New DevExpress.Utils.PointFloat(843.2916!, 37.08344!)
            Me.Label74.Name = "Label74"
            Me.Label74.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label74.SizeF = New System.Drawing.SizeF(52.58331!, 37.99985!)
            Me.Label74.StylePriority.UseFont = False
            Me.Label74.Text = "Open PO's"
            Me.Label74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Line57
            '
            Me.Line57.BorderColor = System.Drawing.Color.Silver
            Me.Line57.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line57.BorderWidth = 4.0!
            Me.Line57.Dpi = 100.0!
            Me.Line57.ForeColor = System.Drawing.Color.Silver
            Me.Line57.LineWidth = 4
            Me.Line57.LocationFloat = New DevExpress.Utils.PointFloat(0!, 81.0833!)
            Me.Line57.Name = "Line57"
            Me.Line57.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            '
            'Label129
            '
            Me.Label129.BackColor = System.Drawing.Color.Transparent
            Me.Label129.BorderColor = System.Drawing.Color.Black
            Me.Label129.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label129.BorderWidth = 1.0!
            Me.Label129.CanGrow = False
            Me.Label129.Dpi = 100.0!
            Me.Label129.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label129.ForeColor = System.Drawing.Color.Black
            Me.Label129.LocationFloat = New DevExpress.Utils.PointFloat(958.875!, 37.08363!)
            Me.Label129.Name = "Label129"
            Me.Label129.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label129.SizeF = New System.Drawing.SizeF(40.12524!, 37.99969!)
            Me.Label129.StylePriority.UseFont = False
            Me.Label129.Text = "Vendor"
            Me.Label129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooter2
            '
            Me.GroupFooter2.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreport3, Me.XrSubreport2, Me.XrLabel33, Me.XrLabel34, Me.XrLabel35, Me.XrLabel36, Me.XrLabel31, Me.XrSubreport1, Me.XrLabel16, Me.XrLabel17, Me.XrLabel15, Me.XrLabel13, Me.XrLabel14, Me.Label100, Me.Text101, Me.JTotal, Me.JNBillable, Me.JBilled, Me.Text110, Me.Line130})
            Me.GroupFooter2.Dpi = 100.0!
            Me.GroupFooter2.HeightF = 153.5417!
            Me.GroupFooter2.Level = 3
            Me.GroupFooter2.Name = "GroupFooter2"
            Me.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrSubreport3
            '
            Me.XrSubreport3.Dpi = 100.0!
            Me.XrSubreport3.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 89.0!)
            Me.XrSubreport3.Name = "XrSubreport3"
            Me.XrSubreport3.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvancedBillingHistorySubReport()
            Me.XrSubreport3.SizeF = New System.Drawing.SizeF(523.292!, 23.0!)
            '
            'XrSubreport2
            '
            Me.XrSubreport2.Dpi = 100.0!
            Me.XrSubreport2.LocationFloat = New DevExpress.Utils.PointFloat(579.9998!, 89.0!)
            Me.XrSubreport2.Name = "XrSubreport2"
            Me.XrSubreport2.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.BillingHistorySubReport()
            Me.XrSubreport2.SizeF = New System.Drawing.SizeF(419.0004!, 23.0!)
            '
            'XrLabel33
            '
            Me.XrLabel33.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel33.BorderColor = System.Drawing.Color.Black
            Me.XrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel33.BorderWidth = 1.0!
            Me.XrLabel33.CanGrow = False
            Me.XrLabel33.Dpi = 100.0!
            Me.XrLabel33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel33.ForeColor = System.Drawing.Color.Black
            Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 40.58335!)
            Me.XrLabel33.Name = "XrLabel33"
            Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel33.SizeF = New System.Drawing.SizeF(250.375!, 18.99999!)
            Me.XrLabel33.StylePriority.UseFont = False
            Me.XrLabel33.Text = "Invoiced to Client:"
            Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel34
            '
            Me.XrLabel34.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel34.BorderColor = System.Drawing.Color.Black
            Me.XrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel34.BorderWidth = 1.0!
            Me.XrLabel34.CanGrow = False
            Me.XrLabel34.Dpi = 100.0!
            Me.XrLabel34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel34.ForeColor = System.Drawing.Color.Black
            Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 59.58335!)
            Me.XrLabel34.Name = "XrLabel34"
            Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel34.SizeF = New System.Drawing.SizeF(250.375!, 18.99999!)
            Me.XrLabel34.StylePriority.UseFont = False
            Me.XrLabel34.Text = "Remaining to be invoiced to Client:"
            Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel35
            '
            Me.XrLabel35.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel35.BorderColor = System.Drawing.Color.Black
            Me.XrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel35.BorderWidth = 1.0!
            Me.XrLabel35.CanGrow = False
            Me.XrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.XrLabel35.Dpi = 100.0!
            Me.XrLabel35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 40.58335!)
            Me.XrLabel35.Name = "XrLabel35"
            Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel35.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel35.StylePriority.UseFont = False
            XrSummary32.FormatString = "{0:n2}"
            XrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel35.Summary = XrSummary32
            Me.XrLabel35.Text = "XrLabel35"
            Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel36
            '
            Me.XrLabel36.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel36.BorderColor = System.Drawing.Color.Black
            Me.XrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel36.BorderWidth = 1.0!
            Me.XrLabel36.CanGrow = False
            Me.XrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField2")})
            Me.XrLabel36.Dpi = 100.0!
            Me.XrLabel36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(271.2919!, 59.58335!)
            Me.XrLabel36.Name = "XrLabel36"
            Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel36.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel36.StylePriority.UseFont = False
            XrSummary33.FormatString = "{0:n2}"
            XrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel36.Summary = XrSummary33
            Me.XrLabel36.Text = "XrLabel36"
            Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel31
            '
            Me.XrLabel31.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel31.BorderColor = System.Drawing.Color.Black
            Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel31.BorderWidth = 1.0!
            Me.XrLabel31.CanGrow = False
            Me.XrLabel31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField3", "{0:n2}")})
            Me.XrLabel31.Dpi = 100.0!
            Me.XrLabel31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(781.9997!, 10.00004!)
            Me.XrLabel31.Name = "XrLabel31"
            Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel31.SizeF = New System.Drawing.SizeF(61.29175!, 19.0!)
            Me.XrLabel31.StylePriority.UseFont = False
            XrSummary34.FormatString = "{0:n2}"
            Me.XrLabel31.Summary = XrSummary34
            Me.XrLabel31.Text = "XrLabel31"
            Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrSubreport1
            '
            Me.XrSubreport1.Dpi = 100.0!
            Me.XrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(0.0002304713!, 122.625!)
            Me.XrSubreport1.Name = "XrSubreport1"
            Me.XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvanceReconciliationHistorySubReport()
            Me.XrSubreport1.SizeF = New System.Drawing.SizeF(523.2919!, 23.0!)
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1.0!
            Me.XrLabel16.CanGrow = False
            Me.XrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Variance")})
            Me.XrLabel16.Dpi = 100.0!
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(523.2919!, 9.999974!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel16.StylePriority.UseFont = False
            XrSummary35.FormatString = "{0:n2}"
            XrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel16.Summary = XrSummary35
            Me.XrLabel16.Text = "XrLabel16"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel17
            '
            Me.XrLabel17.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel17.BorderColor = System.Drawing.Color.Black
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel17.BorderWidth = 1.0!
            Me.XrLabel17.CanGrow = False
            Me.XrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfResaleTax")})
            Me.XrLabel17.Dpi = 100.0!
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(586.2919!, 10.00004!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel17.StylePriority.UseFont = False
            XrSummary36.FormatString = "{0:n2}"
            XrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel17.Summary = XrSummary36
            Me.XrLabel17.Text = "FTAX"
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualAmount")})
            Me.XrLabel15.Dpi = 100.0!
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(460.2919!, 10.00004!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            XrSummary37.FormatString = "{0:n2}"
            XrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel15.Summary = XrSummary37
            Me.XrLabel15.Text = "XrLabel15"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1.0!
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours")})
            Me.XrLabel13.Dpi = 100.0!
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 10.00004!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            XrSummary38.FormatString = "{0:n2}"
            XrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel13.Summary = XrSummary38
            Me.XrLabel13.Text = "XrLabel13"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel14
            '
            Me.XrLabel14.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel14.BorderColor = System.Drawing.Color.Black
            Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel14.BorderWidth = 1.0!
            Me.XrLabel14.CanGrow = False
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.XrLabel14.Dpi = 100.0!
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 10.00004!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            XrSummary39.FormatString = "{0:n2}"
            XrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel14.Summary = XrSummary39
            Me.XrLabel14.Text = "XrLabel14"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label100
            '
            Me.Label100.BackColor = System.Drawing.Color.Transparent
            Me.Label100.BorderColor = System.Drawing.Color.Black
            Me.Label100.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label100.BorderWidth = 1.0!
            Me.Label100.CanGrow = False
            Me.Label100.Dpi = 100.0!
            Me.Label100.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label100.ForeColor = System.Drawing.Color.Black
            Me.Label100.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 10.00001!)
            Me.Label100.Name = "Label100"
            Me.Label100.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label100.SizeF = New System.Drawing.SizeF(250.375!, 18.99999!)
            Me.Label100.StylePriority.UseFont = False
            Me.Label100.Text = "Total for Job/Component:"
            Me.Label100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text101
            '
            Me.Text101.BackColor = System.Drawing.Color.Transparent
            Me.Text101.BorderColor = System.Drawing.Color.Black
            Me.Text101.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text101.BorderWidth = 1.0!
            Me.Text101.CanGrow = False
            Me.Text101.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.Text101.Dpi = 100.0!
            Me.Text101.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text101.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 10.00004!)
            Me.Text101.Name = "Text101"
            Me.Text101.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text101.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text101.StylePriority.UseFont = False
            XrSummary40.FormatString = "{0:n2}"
            XrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text101.Summary = XrSummary40
            Me.Text101.Text = "Text101"
            Me.Text101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'JTotal
            '
            Me.JTotal.BackColor = System.Drawing.Color.Transparent
            Me.JTotal.BorderColor = System.Drawing.Color.Black
            Me.JTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.JTotal.BorderWidth = 1.0!
            Me.JTotal.CanGrow = False
            Me.JTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.JTotal.Dpi = 100.0!
            Me.JTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JTotal.LocationFloat = New DevExpress.Utils.PointFloat(649.2919!, 10.00004!)
            Me.JTotal.Name = "JTotal"
            Me.JTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JTotal.StylePriority.UseFont = False
            XrSummary41.FormatString = "{0:n2}"
            XrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JTotal.Summary = XrSummary41
            Me.JTotal.Text = "JTotal"
            Me.JTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'JNBillable
            '
            Me.JNBillable.BackColor = System.Drawing.Color.Transparent
            Me.JNBillable.BorderColor = System.Drawing.Color.Black
            Me.JNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.JNBillable.BorderWidth = 1.0!
            Me.JNBillable.CanGrow = False
            Me.JNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField1")})
            Me.JNBillable.Dpi = 100.0!
            Me.JNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JNBillable.LocationFloat = New DevExpress.Utils.PointFloat(895.875!, 10.00001!)
            Me.JNBillable.Name = "JNBillable"
            Me.JNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JNBillable.StylePriority.UseFont = False
            XrSummary42.FormatString = "{0:n2}"
            XrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JNBillable.Summary = XrSummary42
            Me.JNBillable.Text = "JNBillable"
            Me.JNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'JBilled
            '
            Me.JBilled.BackColor = System.Drawing.Color.Transparent
            Me.JBilled.BorderColor = System.Drawing.Color.Black
            Me.JBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.JBilled.BorderWidth = 1.0!
            Me.JBilled.CanGrow = False
            Me.JBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.JBilled.Dpi = 100.0!
            Me.JBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JBilled.LocationFloat = New DevExpress.Utils.PointFloat(712.292!, 10.00004!)
            Me.JBilled.Name = "JBilled"
            Me.JBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JBilled.SizeF = New System.Drawing.SizeF(69.70801!, 19.0!)
            Me.JBilled.StylePriority.UseFont = False
            XrSummary43.FormatString = "{0:n2}"
            XrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JBilled.Summary = XrSummary43
            Me.JBilled.Text = "JBilled"
            Me.JBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text110
            '
            Me.Text110.BackColor = System.Drawing.Color.Transparent
            Me.Text110.BorderColor = System.Drawing.Color.Black
            Me.Text110.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text110.BorderWidth = 1.0!
            Me.Text110.CanGrow = False
            Me.Text110.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.Text110.Dpi = 100.0!
            Me.Text110.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text110.LocationFloat = New DevExpress.Utils.PointFloat(843.2917!, 10.00004!)
            Me.Text110.Name = "Text110"
            Me.Text110.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text110.SizeF = New System.Drawing.SizeF(52.58325!, 19.0!)
            Me.Text110.StylePriority.UseFont = False
            XrSummary44.FormatString = "{0:n2}"
            XrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text110.Summary = XrSummary44
            Me.Text110.Text = "Text110"
            Me.Text110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Line130
            '
            Me.Line130.BorderColor = System.Drawing.Color.Silver
            Me.Line130.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line130.BorderWidth = 1.0!
            Me.Line130.Dpi = 100.0!
            Me.Line130.ForeColor = System.Drawing.Color.Silver
            Me.Line130.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.Line130.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Line130.Name = "Line130"
            Me.Line130.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            '
            'GroupFooter3
            '
            Me.GroupFooter3.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter3.Dpi = 100.0!
            Me.GroupFooter3.HeightF = 0!
            Me.GroupFooter3.Level = 2
            Me.GroupFooter3.Name = "GroupFooter3"
            Me.GroupFooter3.Visible = False
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel29, Me.XrLabel6, Me.XrLabel7, Me.XrLabel5, Me.XrLabel3, Me.XrLabel4, Me.XrLabel2, Me.Text79, Me.FTotal, Me.FNBillable, Me.FBilled, Me.Text88})
            Me.GroupFooter0.Dpi = 100.0!
            Me.GroupFooter0.HeightF = 39.99999!
            Me.GroupFooter0.Name = "GroupFooter0"
            '
            'XrLabel29
            '
            Me.XrLabel29.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel29.BorderColor = System.Drawing.Color.Black
            Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel29.BorderWidth = 1.0!
            Me.XrLabel29.CanGrow = False
            Me.XrLabel29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField3", "{0:n2}")})
            Me.XrLabel29.Dpi = 100.0!
            Me.XrLabel29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(781.9998!, 9.999974!)
            Me.XrLabel29.Name = "XrLabel29"
            Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel29.SizeF = New System.Drawing.SizeF(61.29175!, 19.0!)
            Me.XrLabel29.StylePriority.UseFont = False
            XrSummary45.FormatString = "{0:n2}"
            Me.XrLabel29.Summary = XrSummary45
            Me.XrLabel29.Text = "XrLabel29"
            Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.BorderWidth = 1.0!
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Variance")})
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(523.2919!, 9.999974!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            XrSummary46.FormatString = "{0:n2}"
            XrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel6.Summary = XrSummary46
            Me.XrLabel6.Text = "XrLabel6"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1.0!
            Me.XrLabel7.CanGrow = False
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfResaleTax")})
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(586.2919!, 9.999974!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            XrSummary47.FormatString = "{0:n2}"
            XrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel7.Summary = XrSummary47
            Me.XrLabel7.Text = "FTAX"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualAmount")})
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(460.2919!, 9.999974!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            XrSummary48.FormatString = "{0:n2}"
            XrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel5.Summary = XrSummary48
            Me.XrLabel5.Text = "XrLabel5"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours")})
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(334.2918!, 9.999974!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            XrSummary49.FormatString = "{0:n2}"
            XrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel3.Summary = XrSummary49
            Me.XrLabel3.Text = "XrLabel3"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel4
            '
            Me.XrLabel4.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel4.BorderColor = System.Drawing.Color.Black
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel4.BorderWidth = 1.0!
            Me.XrLabel4.CanGrow = False
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(397.2918!, 9.999974!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            XrSummary50.FormatString = "{0:n2}"
            XrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel4.Summary = XrSummary50
            Me.XrLabel4.Text = "XrLabel4"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel2
            '
            Me.XrLabel2.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel2.BorderColor = System.Drawing.Color.Black
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel2.BorderWidth = 1.0!
            Me.XrLabel2.CanGrow = False
            Me.XrLabel2.Dpi = 100.0!
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 10.00001!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(254.3748!, 19.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.Text = "Total for Function:"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text79
            '
            Me.Text79.BackColor = System.Drawing.Color.Transparent
            Me.Text79.BorderColor = System.Drawing.Color.Black
            Me.Text79.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text79.BorderWidth = 1.0!
            Me.Text79.CanGrow = False
            Me.Text79.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.Text79.Dpi = 100.0!
            Me.Text79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text79.LocationFloat = New DevExpress.Utils.PointFloat(271.2918!, 9.999974!)
            Me.Text79.Name = "Text79"
            Me.Text79.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text79.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text79.StylePriority.UseFont = False
            XrSummary51.FormatString = "{0:n2}"
            XrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text79.Summary = XrSummary51
            Me.Text79.Text = "Text79"
            Me.Text79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTotal
            '
            Me.FTotal.BackColor = System.Drawing.Color.Transparent
            Me.FTotal.BorderColor = System.Drawing.Color.Black
            Me.FTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTotal.BorderWidth = 1.0!
            Me.FTotal.CanGrow = False
            Me.FTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.FTotal.Dpi = 100.0!
            Me.FTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTotal.LocationFloat = New DevExpress.Utils.PointFloat(649.2919!, 9.999974!)
            Me.FTotal.Name = "FTotal"
            Me.FTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTotal.StylePriority.UseFont = False
            XrSummary52.FormatString = "{0:n2}"
            XrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTotal.Summary = XrSummary52
            Me.FTotal.Text = "FTotal"
            Me.FTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FNBillable
            '
            Me.FNBillable.BackColor = System.Drawing.Color.Transparent
            Me.FNBillable.BorderColor = System.Drawing.Color.Black
            Me.FNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FNBillable.BorderWidth = 1.0!
            Me.FNBillable.CanGrow = False
            Me.FNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField1")})
            Me.FNBillable.Dpi = 100.0!
            Me.FNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FNBillable.LocationFloat = New DevExpress.Utils.PointFloat(895.875!, 9.999974!)
            Me.FNBillable.Name = "FNBillable"
            Me.FNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FNBillable.StylePriority.UseFont = False
            XrSummary53.FormatString = "{0:n2}"
            XrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FNBillable.Summary = XrSummary53
            Me.FNBillable.Text = "FNBillable"
            Me.FNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FBilled
            '
            Me.FBilled.BackColor = System.Drawing.Color.Transparent
            Me.FBilled.BorderColor = System.Drawing.Color.Black
            Me.FBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FBilled.BorderWidth = 1.0!
            Me.FBilled.CanGrow = False
            Me.FBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.FBilled.Dpi = 100.0!
            Me.FBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FBilled.LocationFloat = New DevExpress.Utils.PointFloat(712.2919!, 9.999974!)
            Me.FBilled.Name = "FBilled"
            Me.FBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FBilled.SizeF = New System.Drawing.SizeF(69.70844!, 19.0!)
            Me.FBilled.StylePriority.UseFont = False
            XrSummary54.FormatString = "{0:n2}"
            XrSummary54.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FBilled.Summary = XrSummary54
            Me.FBilled.Text = "FBilled"
            Me.FBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text88
            '
            Me.Text88.BackColor = System.Drawing.Color.Transparent
            Me.Text88.BorderColor = System.Drawing.Color.Black
            Me.Text88.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text88.BorderWidth = 1.0!
            Me.Text88.CanGrow = False
            Me.Text88.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.Text88.Dpi = 100.0!
            Me.Text88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text88.LocationFloat = New DevExpress.Utils.PointFloat(843.2917!, 9.999974!)
            Me.Text88.Name = "Text88"
            Me.Text88.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text88.SizeF = New System.Drawing.SizeF(52.58331!, 19.0!)
            Me.Text88.StylePriority.UseFont = False
            XrSummary55.FormatString = "{0:n2}"
            XrSummary55.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text88.Summary = XrSummary55
            Me.Text88.Text = "Text88"
            Me.Text88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ClientFull
            '
            Me.ClientFull.Expression = "[ClientCode] + ' - ' + [ClientDescription]"
            Me.ClientFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientFull.Name = "ClientFull"
            '
            'DivisionFull
            '
            Me.DivisionFull.Expression = "[DivisionCode] + ' - ' + [DivisionDescription]"
            Me.DivisionFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DivisionFull.Name = "DivisionFull"
            '
            'ProductFull
            '
            Me.ProductFull.Expression = "[ProductCode] + ' - ' + [ProductDescription]"
            Me.ProductFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProductFull.Name = "ProductFull"
            '
            'JobFull
            '
            Me.JobFull.Expression = "[JobNumber] + ' - ' + [JobDescription]"
            Me.JobFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobFull.Name = "JobFull"
            '
            'JobComponentFull
            '
            Me.JobComponentFull.Expression = "[JobComponentNumber]  + ' - ' +  [ComponentDescription]"
            Me.JobComponentFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobComponentFull.Name = "JobComponentFull"
            '
            'AdvanceFlag
            '
            Me.AdvanceFlag.Expression = "'Advance Flag: ' + Iif([AdvanceBillFlag] In (1,2,3,4,5),[AdvanceBillFlag]  , 'Non" &
    "e')"
            Me.AdvanceFlag.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AdvanceFlag.Name = "AdvanceFlag"
            '
            'BillableStatus
            '
            Me.BillableStatus.Expression = "'Billable Status: ' + [IsNonBillable]"
            Me.BillableStatus.Name = "BillableStatus"
            '
            'HoldStatus
            '
            Me.HoldStatus.Expression = "'Job Bill Hold Status: ' + [Hold]"
            Me.HoldStatus.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.HoldStatus.Name = "HoldStatus"
            '
            'ProcessDescription
            '
            Me.ProcessDescription.Expression = "'Proc Control: ' + [ProcessDesc]"
            Me.ProcessDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ProcessDescription.Name = "ProcessDescription"
            '
            'AccountExecutiveFull
            '
            Me.AccountExecutiveFull.Expression = "[AccountExecutiveCode] + ' - ' + [AccountExecutive] "
            Me.AccountExecutiveFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AccountExecutiveFull.Name = "AccountExecutiveFull"
            '
            'FunctionFull
            '
            Me.FunctionFull.Expression = "[FunctionCode] + ' - ' + [FunctionDescription]"
            Me.FunctionFull.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.FunctionFull.Name = "FunctionFull"
            '
            'FunctionTypeTotal
            '
            Me.FunctionTypeTotal.Expression = "'Total ' + [FunctionTypeDescription] + ':'"
            Me.FunctionTypeTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.FunctionTypeTotal.Name = "FunctionTypeTotal"
            '
            'NetCost
            '
            Me.NetCost.Expression = "[SumOfAPNetCost] + [SumOfVenTax]"
            Me.NetCost.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.NetCost.Name = "NetCost"
            '
            'BilledField
            '
            Me.BilledField.Expression = "[SumOfBilledAmount] + [SumOfAdvanceBilled] + [SumOfAdvanceResaleBilled]"
            Me.BilledField.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.BilledField.Name = "BilledField"
            '
            'Unbilled
            '
            Me.Unbilled.Expression = "[SumOfLineTotal] - ([SumOfBilledAmount] + [SumOfAdvanceBilled])"
            Me.Unbilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.Unbilled.Name = "Unbilled"
            '
            'TodaysDate
            '
            Me.TodaysDate.Expression = "Today()"
            Me.TodaysDate.Name = "TodaysDate"
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Dpi = 100.0!
            Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader2.HeightF = 0!
            Me.GroupHeader2.Level = 1
            Me.GroupHeader2.Name = "GroupHeader2"
            Me.GroupHeader2.RepeatEveryPage = True
            Me.GroupHeader2.Visible = False
            '
            'ActualHours
            '
            Me.ActualHours.Expression = "[SumOfBillEmpHours] + [SumOfNonBillableEmpHours] + [SumOfAPQuantity]"
            Me.ActualHours.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ActualHours.Name = "ActualHours"
            '
            'ActualAmount
            '
            Me.ActualAmount.Expression = "[SumOfLineTotal]- [SumOfResaleTax] + [SumOfNonBillableAmount]"
            Me.ActualAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ActualAmount.Name = "ActualAmount"
            '
            'Variance
            '
            Me.Variance.Expression = "([SumOfEstimate] - [SumOfEstimateCont] - [SumOfEstimateResaleTax]) - ([SumOfLineT" &
    "otal] + [SumOfNonBillableAmount] - [SumOfResaleTax])"
            Me.Variance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.Variance.Name = "Variance"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.JobDetailAnalysis)
            '
            'CalculatedField1
            '
            Me.CalculatedField1.DisplayName = "ActualBalance"
            Me.CalculatedField1.Expression = "([SumOfLineTotal] - [SumOfResaleTax]) - ([SumOfBilledAmount] - [SumOfResaleBilled" &
    "] + [SumOfAdvanceResaleBilled])"
            Me.CalculatedField1.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField1.Name = "CalculatedField1"
            '
            'CalculatedField2
            '
            Me.CalculatedField2.DisplayName = "Remaining"
            Me.CalculatedField2.Expression = "([SumOfEstimate] - [SumOfEstimateCont]) - ([SumOfBilledAmount] + [SumOfAdvanceBil" &
    "led] + [SumOfAdvanceResaleBilled])"
            Me.CalculatedField2.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField2.Name = "CalculatedField2"
            '
            'CalculatedField3
            '
            Me.CalculatedField3.DisplayName = "Recognized"
            Me.CalculatedField3.Expression = "Iif([AdvanceBillFlag] in (2,4,6),(([SumOfBilledAmount])  - [SumOfBilledCost]),(([" &
    "SumOfBilledAmount] + [SumOfAdvanceBilled] + [SumOfAdvanceResaleBilled]) - [SumOf" &
    "ResaleBilled]  - [SumOfBilledCost]) )"
            Me.CalculatedField3.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField3.Name = "CalculatedField3"
            '
            'CalculatedField4
            '
            Me.CalculatedField4.DisplayName = "EstimatedCost"
            Me.CalculatedField4.Expression = "[SumOfEstimate] - [SumOfEstimateCont] - [SumOfEstimateResaleTax]"
            Me.CalculatedField4.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField4.Name = "CalculatedField4"
            '
            'DetailByFunctionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.GroupHeaderForm_CDP, Me.GroupFooter1, Me.GroupHeader3, Me.GroupHeader1, Me.GroupFooter2, Me.GroupHeaderFunction, Me.GroupFooter3, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupHeader2})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientFull, Me.DivisionFull, Me.ProductFull, Me.JobFull, Me.JobComponentFull, Me.AdvanceFlag, Me.BillableStatus, Me.HoldStatus, Me.ProcessDescription, Me.AccountExecutiveFull, Me.FunctionFull, Me.FunctionTypeTotal, Me.NetCost, Me.BilledField, Me.Unbilled, Me.TodaysDate, Me.ActualHours, Me.ActualAmount, Me.Variance, Me.CalculatedField1, Me.CalculatedField2, Me.CalculatedField3, Me.CalculatedField4})
            Me.DataSource = Me.BindingSource
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.SnapGridSize = 5.0!
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
        Public WithEvents XrSubreport2 As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
        Public WithEvents XrSubreport3 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents ActualHours As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ActualAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Variance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField1 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField2 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField3 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField4 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    End Class

End Namespace







