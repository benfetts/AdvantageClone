Namespace JobAnalysisDetail.Version2

    Partial Public Class SummaryByFunctionReport

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
        Private Text121 As DevExpress.XtraReports.UI.XRLabel
        Private Text123 As DevExpress.XtraReports.UI.XRLabel
        Private Text146 As DevExpress.XtraReports.UI.XRLabel
        Private AE As DevExpress.XtraReports.UI.XRLabel
        Private Text145 As DevExpress.XtraReports.UI.XRLabel
        Private Label153 As DevExpress.XtraReports.UI.XRLabel
        Private Label154 As DevExpress.XtraReports.UI.XRLabel
        Private Label155 As DevExpress.XtraReports.UI.XRLabel
        Private Label156 As DevExpress.XtraReports.UI.XRLabel
        Private Text147 As DevExpress.XtraReports.UI.XRLabel
        Private Text148 As DevExpress.XtraReports.UI.XRLabel
        Private ESTIMATE_NUMBER As DevExpress.XtraReports.UI.XRLabel
        Private Label179 As DevExpress.XtraReports.UI.XRLabel
        Private EST_COMPONENT_NBR As DevExpress.XtraReports.UI.XRLabel
        Private Label180 As DevExpress.XtraReports.UI.XRLabel
        Private GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private label3 As DevExpress.XtraReports.UI.XRLabel
        Private label4 As DevExpress.XtraReports.UI.XRLabel
        Private Label68 As DevExpress.XtraReports.UI.XRLabel
        Private Label70 As DevExpress.XtraReports.UI.XRLabel
        Private Label72 As DevExpress.XtraReports.UI.XRLabel
        Private Label74 As DevExpress.XtraReports.UI.XRLabel
        Private Line57 As DevExpress.XtraReports.UI.XRLine
        Private GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Label100 As DevExpress.XtraReports.UI.XRLabel
        Private Text101 As DevExpress.XtraReports.UI.XRLabel
        Private JTotal As DevExpress.XtraReports.UI.XRLabel
        Private JNBillable As DevExpress.XtraReports.UI.XRLabel
        Private JBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text110 As DevExpress.XtraReports.UI.XRLabel
        Private Line130 As DevExpress.XtraReports.UI.XRLine
        Private GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Text134 As DevExpress.XtraReports.UI.XRLabel
        Private FTTotal As DevExpress.XtraReports.UI.XRLabel
        Private FTNBillable As DevExpress.XtraReports.UI.XRLabel
        Private FTBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text142 As DevExpress.XtraReports.UI.XRLabel
        Private Type As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter0 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Text79 As DevExpress.XtraReports.UI.XRLabel
        Private FTotal As DevExpress.XtraReports.UI.XRLabel
        Private FNBillable As DevExpress.XtraReports.UI.XRLabel
        Private FBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text88 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents GroupFooter4 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents Label60 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label58 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label66 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label62 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label64 As DevExpress.XtraReports.UI.XRLabel
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
        Private WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label177 As DevExpress.XtraReports.UI.XRLabel
        Public WithEvents XrSubreport1 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
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
            Dim XrSummary18 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary19 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
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
            Dim XrSummary56 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary57 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary58 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary59 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary60 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary61 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary62 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary63 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary64 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary65 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary66 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary67 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary68 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary69 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary70 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary71 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary72 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary73 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
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
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabel54 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel55 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel56 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel57 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel53 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text120 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text121 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text123 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text146 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AE = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text145 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label153 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label154 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label155 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label156 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text147 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text148 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ESTIMATE_NUMBER = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label179 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EST_COMPONENT_NBR = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label180 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label177 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrSubreport2 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Text134 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTNBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTBilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text142 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Type = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.GroupFooter4 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.HoursAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AdvanceBill = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupHeader4 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter5 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel50 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel58 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel59 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel60 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel61 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel63 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel64 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.BackColor = System.Drawing.Color.Transparent
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Order", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
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
            Me.LabelPageHeader_Title.Text = "Job Analysis (V2) - Summary by Function"
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
            Me.GroupHeaderFunction.Dpi = 100.0!
            Me.GroupHeaderFunction.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderFunction.HeightF = 0!
            Me.GroupHeaderFunction.Name = "GroupHeaderFunction"
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
            Me.FUNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FUNC.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.FUNC.Name = "FUNC"
            Me.FUNC.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FUNC.SizeF = New System.Drawing.SizeF(267.0!, 19.0!)
            Me.FUNC.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.FUNC.Summary = XrSummary1
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
            Me.GroupHeaderForm_CDP.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelCDP_ClientData, Me.Text31, Me.LabelPageHeader_ProductData, Me.LabelCDP_Client, Me.Label158, Me.LabelPageHeader_Product})
            Me.GroupHeaderForm_CDP.Dpi = 100.0!
            Me.GroupHeaderForm_CDP.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderForm_CDP.HeightF = 50.0!
            Me.GroupHeaderForm_CDP.Level = 4
            Me.GroupHeaderForm_CDP.Name = "GroupHeaderForm_CDP"
            Me.GroupHeaderForm_CDP.RepeatEveryPage = True
            '
            'LabelCDP_ClientData
            '
            Me.LabelCDP_ClientData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientFull")})
            Me.LabelCDP_ClientData.Dpi = 100.0!
            Me.LabelCDP_ClientData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCDP_ClientData.LocationFloat = New DevExpress.Utils.PointFloat(57.99993!, 3.999996!)
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
            Me.Text31.LocationFloat = New DevExpress.Utils.PointFloat(57.99993!, 23.00002!)
            Me.Text31.Name = "Text31"
            Me.Text31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text31.SizeF = New System.Drawing.SizeF(301.0002!, 19.0!)
            Me.Text31.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.Text31.Summary = XrSummary2
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
            Me.LabelPageHeader_ProductData.LocationFloat = New DevExpress.Utils.PointFloat(413.0!, 3.999996!)
            Me.LabelPageHeader_ProductData.Name = "LabelPageHeader_ProductData"
            Me.LabelPageHeader_ProductData.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ProductData.SizeF = New System.Drawing.SizeF(254.0!, 19.0!)
            Me.LabelPageHeader_ProductData.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.LabelPageHeader_ProductData.Summary = XrSummary3
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
            Me.LabelPageHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(359.0002!, 3.999996!)
            Me.LabelPageHeader_Product.Name = "LabelPageHeader_Product"
            Me.LabelPageHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Product.SizeF = New System.Drawing.SizeF(54.0!, 19.0!)
            Me.LabelPageHeader_Product.StylePriority.UseFont = False
            Me.LabelPageHeader_Product.Text = "Product:"
            Me.LabelPageHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooter1
            '
            Me.GroupFooter1.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel33, Me.XrLabel32, Me.XrLabel26, Me.XrLabel27, Me.XrLabel25, Me.XrLabel23, Me.XrLabel24, Me.XrLabel21, Me.XrLabel22, Me.XrLabel20, Me.XrLabel18, Me.XrLabel19, Me.Label52, Me.Text90, Me.CTotal, Me.CNBillable, Me.CBilled, Me.Text99, Me.Label150, Me.Label164, Me.Label165, Me.Label166, Me.Label167, Me.Line168})
            Me.GroupFooter1.Dpi = 100.0!
            Me.GroupFooter1.HeightF = 80.0!
            Me.GroupFooter1.Level = 4
            Me.GroupFooter1.Name = "GroupFooter1"
            Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
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
            Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 10.0001!)
            Me.XrLabel33.Name = "XrLabel33"
            Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel33.SizeF = New System.Drawing.SizeF(63.0!, 37.99988!)
            Me.XrLabel33.StylePriority.UseFont = False
            Me.XrLabel33.Text = "Estimate Net Cost"
            Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel32
            '
            Me.XrLabel32.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel32.BorderColor = System.Drawing.Color.Black
            Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel32.BorderWidth = 1.0!
            Me.XrLabel32.CanGrow = False
            Me.XrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateNetAmount")})
            Me.XrLabel32.Dpi = 100.0!
            Me.XrLabel32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 58.99995!)
            Me.XrLabel32.Name = "XrLabel32"
            Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel32.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel32.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel32.Summary = XrSummary4
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
            Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(468.0002!, 9.999974!)
            Me.XrLabel26.Name = "XrLabel26"
            Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel26.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel26.StylePriority.UseFont = False
            Me.XrLabel26.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Billable"
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
            Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(531.0002!, 9.999911!)
            Me.XrLabel27.Name = "XrLabel27"
            Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel27.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel27.StylePriority.UseFont = False
            Me.XrLabel27.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
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
            Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 26.99998!)
            Me.XrLabel25.Name = "XrLabel25"
            Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel25.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel25.StylePriority.UseFont = False
            Me.XrLabel25.Text = "Mark Up"
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
            Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 26.99992!)
            Me.XrLabel23.Name = "XrLabel23"
            Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel23.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel23.StylePriority.UseFont = False
            Me.XrLabel23.Text = "Resale Tax"
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
            Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(657.0003!, 26.99992!)
            Me.XrLabel24.Name = "XrLabel24"
            Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel24.SizeF = New System.Drawing.SizeF(63.0!, 20.99999!)
            Me.XrLabel24.StylePriority.UseFont = False
            Me.XrLabel24.Text = "Net " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cost"
            Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel21
            '
            Me.XrLabel21.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel21.BorderColor = System.Drawing.Color.Black
            Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel21.BorderWidth = 1.0!
            Me.XrLabel21.CanGrow = False
            Me.XrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfExtMarkupAmount")})
            Me.XrLabel21.Dpi = 100.0!
            Me.XrLabel21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 58.99995!)
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel21.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel21.Summary = XrSummary5
            Me.XrLabel21.Text = "FMU"
            Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel22
            '
            Me.XrLabel22.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel22.BorderColor = System.Drawing.Color.Black
            Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel22.BorderWidth = 1.0!
            Me.XrLabel22.CanGrow = False
            Me.XrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.XrLabel22.Dpi = 100.0!
            Me.XrLabel22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 58.99995!)
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel22.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel22.Summary = XrSummary6
            Me.XrLabel22.Text = "XrLabel22"
            Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.XrLabel20.Dpi = 100.0!
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(657.0001!, 58.99995!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel20.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel20.Summary = XrSummary7
            Me.XrLabel20.Text = "FCOST"
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
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(468.0002!, 58.99995!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel18.Summary = XrSummary8
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
            Me.XrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAmount")})
            Me.XrLabel19.Dpi = 100.0!
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(531.0002!, 58.99995!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel19.Summary = XrSummary9
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
            Me.Label52.LocationFloat = New DevExpress.Utils.PointFloat(0!, 58.99995!)
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
            Me.Text90.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.Text90.Dpi = 100.0!
            Me.Text90.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text90.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 58.99995!)
            Me.Text90.Name = "Text90"
            Me.Text90.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text90.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text90.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text90.Summary = XrSummary10
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
            Me.CTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfLineTotal")})
            Me.CTotal.Dpi = 100.0!
            Me.CTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CTotal.LocationFloat = New DevExpress.Utils.PointFloat(783.0!, 58.99995!)
            Me.CTotal.Name = "CTotal"
            Me.CTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CTotal.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CTotal.Summary = XrSummary11
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
            Me.CNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfNonBillableAmount")})
            Me.CNBillable.Dpi = 100.0!
            Me.CNBillable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CNBillable.LocationFloat = New DevExpress.Utils.PointFloat(908.9997!, 58.99995!)
            Me.CNBillable.Name = "CNBillable"
            Me.CNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CNBillable.StylePriority.UseFont = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CNBillable.Summary = XrSummary12
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
            Me.CBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.CBilled.Dpi = 100.0!
            Me.CBilled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CBilled.LocationFloat = New DevExpress.Utils.PointFloat(845.9996!, 58.99995!)
            Me.CBilled.Name = "CBilled"
            Me.CBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CBilled.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CBilled.StylePriority.UseFont = False
            XrSummary13.FormatString = "{0:n2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CBilled.Summary = XrSummary13
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
            Me.Text99.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 58.99995!)
            Me.Text99.Name = "Text99"
            Me.Text99.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text99.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text99.StylePriority.UseFont = False
            XrSummary14.FormatString = "{0:n2}"
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text99.Summary = XrSummary14
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
            Me.Label150.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 9.999974!)
            Me.Label150.Name = "Label150"
            Me.Label150.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label150.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label150.StylePriority.UseFont = False
            Me.Label150.Text = "Estimate w/Cont."
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
            Me.Label164.LocationFloat = New DevExpress.Utils.PointFloat(782.9996!, 26.99992!)
            Me.Label164.Name = "Label164"
            Me.Label164.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label164.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label164.StylePriority.UseFont = False
            Me.Label164.Text = "Total"
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
            Me.Label165.LocationFloat = New DevExpress.Utils.PointFloat(908.9998!, 9.999974!)
            Me.Label165.Name = "Label165"
            Me.Label165.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label165.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label165.StylePriority.UseFont = False
            Me.Label165.Text = "Non Billable"
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
            Me.Label166.LocationFloat = New DevExpress.Utils.PointFloat(845.9996!, 26.99998!)
            Me.Label166.Name = "Label166"
            Me.Label166.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label166.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label166.StylePriority.UseFont = False
            Me.Label166.Text = "Billed"
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
            Me.Label167.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 26.99992!)
            Me.Label167.Name = "Label167"
            Me.Label167.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label167.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label167.StylePriority.UseFont = False
            Me.Label167.Text = "Open PO"
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
            Me.Line168.LocationFloat = New DevExpress.Utils.PointFloat(279.9998!, 47.99995!)
            Me.Line168.Name = "Line168"
            Me.Line168.SizeF = New System.Drawing.SizeF(692.0!, 4.0!)
            '
            'GroupHeader3
            '
            Me.GroupHeader3.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line57, Me.Label177, Me.Label60, Me.Label58, Me.Label66, Me.Label62, Me.Label64, Me.label3, Me.label4, Me.Label68, Me.Label70, Me.Label72, Me.Label74, Me.XrLabel28, Me.XrLabel54, Me.XrLabel55, Me.XrLabel56, Me.XrLabel57, Me.XrLabel34, Me.XrLabel53, Me.XrLabel1, Me.Job, Me.Text120, Me.Text121, Me.Text123, Me.Text146, Me.AE, Me.Text145, Me.Label153, Me.Label154, Me.Label155, Me.Label156, Me.Text147, Me.Text148, Me.ESTIMATE_NUMBER, Me.Label179, Me.EST_COMPONENT_NBR, Me.Label180})
            Me.GroupHeader3.Dpi = 100.0!
            Me.GroupHeader3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader3.HeightF = 178.2917!
            Me.GroupHeader3.Level = 3
            Me.GroupHeader3.Name = "GroupHeader3"
            Me.GroupHeader3.RepeatEveryPage = True
            '
            'XrLabel54
            '
            Me.XrLabel54.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel54.BorderColor = System.Drawing.Color.Black
            Me.XrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel54.BorderWidth = 1.0!
            Me.XrLabel54.CanGrow = False
            Me.XrLabel54.Dpi = 100.0!
            Me.XrLabel54.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel54.ForeColor = System.Drawing.Color.Black
            Me.XrLabel54.LocationFloat = New DevExpress.Utils.PointFloat(491.0!, 3.000069!)
            Me.XrLabel54.Name = "XrLabel54"
            Me.XrLabel54.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel54.SizeF = New System.Drawing.SizeF(115.4166!, 19.0!)
            Me.XrLabel54.StylePriority.UseFont = False
            Me.XrLabel54.Text = "Billable Status:"
            Me.XrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel55
            '
            Me.XrLabel55.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel55.BorderColor = System.Drawing.Color.Black
            Me.XrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel55.BorderWidth = 1.0!
            Me.XrLabel55.CanGrow = False
            Me.XrLabel55.Dpi = 100.0!
            Me.XrLabel55.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel55.ForeColor = System.Drawing.Color.Black
            Me.XrLabel55.LocationFloat = New DevExpress.Utils.PointFloat(491.0!, 22.00006!)
            Me.XrLabel55.Name = "XrLabel55"
            Me.XrLabel55.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel55.SizeF = New System.Drawing.SizeF(115.4166!, 19.0!)
            Me.XrLabel55.StylePriority.UseFont = False
            Me.XrLabel55.Text = "Advance Flag:"
            Me.XrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel56
            '
            Me.XrLabel56.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel56.BorderColor = System.Drawing.Color.Black
            Me.XrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel56.BorderWidth = 1.0!
            Me.XrLabel56.CanGrow = False
            Me.XrLabel56.Dpi = 100.0!
            Me.XrLabel56.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel56.ForeColor = System.Drawing.Color.Black
            Me.XrLabel56.LocationFloat = New DevExpress.Utils.PointFloat(491.0!, 41.00005!)
            Me.XrLabel56.Name = "XrLabel56"
            Me.XrLabel56.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel56.SizeF = New System.Drawing.SizeF(115.4166!, 19.0!)
            Me.XrLabel56.StylePriority.UseFont = False
            Me.XrLabel56.Text = "Job Bill Hold Status:"
            Me.XrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel57
            '
            Me.XrLabel57.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel57.BorderColor = System.Drawing.Color.Black
            Me.XrLabel57.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel57.BorderWidth = 1.0!
            Me.XrLabel57.CanGrow = False
            Me.XrLabel57.Dpi = 100.0!
            Me.XrLabel57.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel57.ForeColor = System.Drawing.Color.Black
            Me.XrLabel57.LocationFloat = New DevExpress.Utils.PointFloat(491.0!, 60.00004!)
            Me.XrLabel57.Name = "XrLabel57"
            Me.XrLabel57.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel57.SizeF = New System.Drawing.SizeF(115.4166!, 19.0!)
            Me.XrLabel57.StylePriority.UseFont = False
            Me.XrLabel57.Text = "Proc. Control:"
            Me.XrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(490.9999!, 79.00006!)
            Me.XrLabel34.Name = "XrLabel34"
            Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel34.SizeF = New System.Drawing.SizeF(115.4167!, 19.0!)
            Me.XrLabel34.StylePriority.UseFont = False
            Me.XrLabel34.Text = "Markup %:"
            Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel53
            '
            Me.XrLabel53.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel53.BorderColor = System.Drawing.Color.Black
            Me.XrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel53.BorderWidth = 1.0!
            Me.XrLabel53.CanGrow = False
            Me.XrLabel53.Dpi = 100.0!
            Me.XrLabel53.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel53.ForeColor = System.Drawing.Color.Black
            Me.XrLabel53.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 79.00003!)
            Me.XrLabel53.Name = "XrLabel53"
            Me.XrLabel53.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel53.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.XrLabel53.StylePriority.UseFont = False
            Me.XrLabel53.Text = "Client PO:"
            Me.XrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientPO")})
            Me.XrLabel1.Dpi = 100.0!
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 79.00003!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(330.2916!, 19.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            XrSummary15.FormatString = "{0}"
            Me.XrLabel1.Summary = XrSummary15
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Job.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 3.000069!)
            Me.Job.Name = "Job"
            Me.Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Job.SizeF = New System.Drawing.SizeF(330.2916!, 19.0!)
            Me.Job.StylePriority.UseFont = False
            XrSummary16.FormatString = "{0}"
            Me.Job.Summary = XrSummary16
            Me.Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Text120.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 22.00006!)
            Me.Text120.Name = "Text120"
            Me.Text120.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text120.SizeF = New System.Drawing.SizeF(330.2916!, 19.0!)
            Me.Text120.StylePriority.UseFont = False
            XrSummary17.FormatString = "{0}"
            Me.Text120.Summary = XrSummary17
            Me.Text120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text121
            '
            Me.Text121.BackColor = System.Drawing.Color.Transparent
            Me.Text121.BorderColor = System.Drawing.Color.Black
            Me.Text121.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text121.BorderWidth = 1.0!
            Me.Text121.CanGrow = False
            Me.Text121.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillableStatus")})
            Me.Text121.Dpi = 100.0!
            Me.Text121.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text121.LocationFloat = New DevExpress.Utils.PointFloat(606.4166!, 3.000069!)
            Me.Text121.Name = "Text121"
            Me.Text121.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text121.SizeF = New System.Drawing.SizeF(274.0001!, 19.0!)
            Me.Text121.StylePriority.UseFont = False
            XrSummary18.FormatString = "{0}"
            Me.Text121.Summary = XrSummary18
            Me.Text121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text123
            '
            Me.Text123.BackColor = System.Drawing.Color.Transparent
            Me.Text123.BorderColor = System.Drawing.Color.Black
            Me.Text123.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text123.BorderWidth = 1.0!
            Me.Text123.CanGrow = False
            Me.Text123.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdvanceFlag")})
            Me.Text123.Dpi = 100.0!
            Me.Text123.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text123.LocationFloat = New DevExpress.Utils.PointFloat(606.4166!, 22.00006!)
            Me.Text123.Name = "Text123"
            Me.Text123.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text123.SizeF = New System.Drawing.SizeF(274.0001!, 19.0!)
            Me.Text123.StylePriority.UseFont = False
            XrSummary19.FormatString = "{0}"
            Me.Text123.Summary = XrSummary19
            Me.Text123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text146
            '
            Me.Text146.BackColor = System.Drawing.Color.Transparent
            Me.Text146.BorderColor = System.Drawing.Color.Black
            Me.Text146.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text146.BorderWidth = 1.0!
            Me.Text146.CanGrow = False
            Me.Text146.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientReference")})
            Me.Text146.Dpi = 100.0!
            Me.Text146.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text146.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 41.00005!)
            Me.Text146.Name = "Text146"
            Me.Text146.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text146.SizeF = New System.Drawing.SizeF(330.2916!, 19.0!)
            Me.Text146.StylePriority.UseFont = False
            XrSummary20.FormatString = "{0}"
            Me.Text146.Summary = XrSummary20
            Me.Text146.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.AE.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 98.00002!)
            Me.AE.Name = "AE"
            Me.AE.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.AE.SizeF = New System.Drawing.SizeF(330.2916!, 19.0!)
            Me.AE.StylePriority.UseFont = False
            XrSummary21.FormatString = "{0}"
            Me.AE.Summary = XrSummary21
            Me.AE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text145
            '
            Me.Text145.BackColor = System.Drawing.Color.Transparent
            Me.Text145.BorderColor = System.Drawing.Color.Black
            Me.Text145.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text145.BorderWidth = 1.0!
            Me.Text145.CanGrow = False
            Me.Text145.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoldStatus")})
            Me.Text145.Dpi = 100.0!
            Me.Text145.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text145.LocationFloat = New DevExpress.Utils.PointFloat(606.4166!, 41.00005!)
            Me.Text145.Name = "Text145"
            Me.Text145.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text145.SizeF = New System.Drawing.SizeF(274.0001!, 19.0!)
            Me.Text145.StylePriority.UseFont = False
            XrSummary22.FormatString = "{0}"
            Me.Text145.Summary = XrSummary22
            Me.Text145.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label153.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 3.000069!)
            Me.Label153.Name = "Label153"
            Me.Label153.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label153.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label153.StylePriority.UseFont = False
            Me.Label153.Text = "Job Number:"
            Me.Label153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label154.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.00006!)
            Me.Label154.Name = "Label154"
            Me.Label154.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label154.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label154.StylePriority.UseFont = False
            Me.Label154.Text = "Job Component:"
            Me.Label154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label155
            '
            Me.Label155.BackColor = System.Drawing.Color.Transparent
            Me.Label155.BorderColor = System.Drawing.Color.Black
            Me.Label155.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label155.BorderWidth = 1.0!
            Me.Label155.CanGrow = False
            Me.Label155.Dpi = 100.0!
            Me.Label155.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label155.ForeColor = System.Drawing.Color.Black
            Me.Label155.LocationFloat = New DevExpress.Utils.PointFloat(0!, 41.00005!)
            Me.Label155.Name = "Label155"
            Me.Label155.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label155.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label155.StylePriority.UseFont = False
            Me.Label155.Text = "Client Reference:"
            Me.Label155.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label156.LocationFloat = New DevExpress.Utils.PointFloat(0!, 98.00002!)
            Me.Label156.Name = "Label156"
            Me.Label156.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label156.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label156.StylePriority.UseFont = False
            Me.Label156.Text = "Account Executive:"
            Me.Label156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text147
            '
            Me.Text147.BackColor = System.Drawing.Color.Transparent
            Me.Text147.BorderColor = System.Drawing.Color.Black
            Me.Text147.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text147.BorderWidth = 1.0!
            Me.Text147.CanGrow = False
            Me.Text147.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProcessDescription")})
            Me.Text147.Dpi = 100.0!
            Me.Text147.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text147.LocationFloat = New DevExpress.Utils.PointFloat(606.4166!, 60.00004!)
            Me.Text147.Name = "Text147"
            Me.Text147.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text147.SizeF = New System.Drawing.SizeF(276.0002!, 19.00001!)
            Me.Text147.StylePriority.UseFont = False
            XrSummary23.FormatString = "{0}"
            Me.Text147.Summary = XrSummary23
            Me.Text147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text148
            '
            Me.Text148.BackColor = System.Drawing.Color.Transparent
            Me.Text148.BorderColor = System.Drawing.Color.Black
            Me.Text148.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text148.BorderWidth = 1.0!
            Me.Text148.CanGrow = False
            Me.Text148.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupPercent")})
            Me.Text148.Dpi = 100.0!
            Me.Text148.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text148.LocationFloat = New DevExpress.Utils.PointFloat(606.4166!, 79.00003!)
            Me.Text148.Name = "Text148"
            Me.Text148.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text148.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text148.StylePriority.UseFont = False
            XrSummary24.FormatString = "{0:Fixed}"
            Me.Text148.Summary = XrSummary24
            Me.Text148.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ESTIMATE_NUMBER
            '
            Me.ESTIMATE_NUMBER.BackColor = System.Drawing.Color.Transparent
            Me.ESTIMATE_NUMBER.BorderColor = System.Drawing.Color.Black
            Me.ESTIMATE_NUMBER.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.ESTIMATE_NUMBER.BorderWidth = 1.0!
            Me.ESTIMATE_NUMBER.CanGrow = False
            Me.ESTIMATE_NUMBER.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateNumber")})
            Me.ESTIMATE_NUMBER.Dpi = 100.0!
            Me.ESTIMATE_NUMBER.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ESTIMATE_NUMBER.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 60.00004!)
            Me.ESTIMATE_NUMBER.Name = "ESTIMATE_NUMBER"
            Me.ESTIMATE_NUMBER.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.ESTIMATE_NUMBER.SizeF = New System.Drawing.SizeF(71.29187!, 19.0!)
            Me.ESTIMATE_NUMBER.StylePriority.UseFont = False
            XrSummary25.FormatString = "{0}"
            Me.ESTIMATE_NUMBER.Summary = XrSummary25
            Me.ESTIMATE_NUMBER.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label179
            '
            Me.Label179.BackColor = System.Drawing.Color.Transparent
            Me.Label179.BorderColor = System.Drawing.Color.Black
            Me.Label179.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label179.BorderWidth = 1.0!
            Me.Label179.CanGrow = False
            Me.Label179.Dpi = 100.0!
            Me.Label179.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label179.ForeColor = System.Drawing.Color.Black
            Me.Label179.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.00004!)
            Me.Label179.Name = "Label179"
            Me.Label179.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label179.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label179.StylePriority.UseFont = False
            Me.Label179.Text = "Estimate Number:"
            Me.Label179.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'EST_COMPONENT_NBR
            '
            Me.EST_COMPONENT_NBR.BackColor = System.Drawing.Color.Transparent
            Me.EST_COMPONENT_NBR.BorderColor = System.Drawing.Color.Black
            Me.EST_COMPONENT_NBR.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.EST_COMPONENT_NBR.BorderWidth = 1.0!
            Me.EST_COMPONENT_NBR.CanGrow = False
            Me.EST_COMPONENT_NBR.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateComponentNumber")})
            Me.EST_COMPONENT_NBR.Dpi = 100.0!
            Me.EST_COMPONENT_NBR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.EST_COMPONENT_NBR.LocationFloat = New DevExpress.Utils.PointFloat(346.7918!, 60.00004!)
            Me.EST_COMPONENT_NBR.Name = "EST_COMPONENT_NBR"
            Me.EST_COMPONENT_NBR.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.EST_COMPONENT_NBR.SizeF = New System.Drawing.SizeF(65.99982!, 19.0!)
            Me.EST_COMPONENT_NBR.StylePriority.UseFont = False
            XrSummary26.FormatString = "{0}"
            Me.EST_COMPONENT_NBR.Summary = XrSummary26
            Me.EST_COMPONENT_NBR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label180
            '
            Me.Label180.BackColor = System.Drawing.Color.Transparent
            Me.Label180.BorderColor = System.Drawing.Color.Black
            Me.Label180.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label180.BorderWidth = 1.0!
            Me.Label180.CanGrow = False
            Me.Label180.Dpi = 100.0!
            Me.Label180.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label180.ForeColor = System.Drawing.Color.Black
            Me.Label180.LocationFloat = New DevExpress.Utils.PointFloat(201.2919!, 60.00004!)
            Me.Label180.Name = "Label180"
            Me.Label180.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label180.SizeF = New System.Drawing.SizeF(145.4999!, 19.0!)
            Me.Label180.StylePriority.UseFont = False
            Me.Label180.Text = "Estimate Component:"
            Me.Label180.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            'XrLabel28
            '
            Me.XrLabel28.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel28.BorderColor = System.Drawing.Color.Black
            Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel28.BorderWidth = 1.0!
            Me.XrLabel28.CanGrow = False
            Me.XrLabel28.Dpi = 100.0!
            Me.XrLabel28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel28.ForeColor = System.Drawing.Color.Black
            Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 128.7502!)
            Me.XrLabel28.Name = "XrLabel28"
            Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel28.SizeF = New System.Drawing.SizeF(63.0!, 37.99988!)
            Me.XrLabel28.StylePriority.UseFont = False
            Me.XrLabel28.Text = "Estimate Net Cost"
            Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Label177
            '
            Me.Label177.BackColor = System.Drawing.Color.Transparent
            Me.Label177.BorderColor = System.Drawing.Color.Black
            Me.Label177.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label177.BorderWidth = 1.0!
            Me.Label177.CanGrow = False
            Me.Label177.Dpi = 100.0!
            Me.Label177.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Label177.ForeColor = System.Drawing.Color.Black
            Me.Label177.LocationFloat = New DevExpress.Utils.PointFloat(971.9999!, 145.7499!)
            Me.Label177.Name = "Label177"
            Me.Label177.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label177.SizeF = New System.Drawing.SizeF(28.0!, 21.00007!)
            Me.Label177.StylePriority.UseFont = False
            Me.Label177.Text = "AB?"
            Me.Label177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.Label60.LocationFloat = New DevExpress.Utils.PointFloat(531.0!, 128.75!)
            Me.Label60.Name = "Label60"
            Me.Label60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label60.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label60.StylePriority.UseFont = False
            Me.Label60.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
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
            Me.Label58.LocationFloat = New DevExpress.Utils.PointFloat(467.9998!, 128.7501!)
            Me.Label58.Name = "Label58"
            Me.Label58.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label58.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label58.StylePriority.UseFont = False
            Me.Label58.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Billable"
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
            Me.Label66.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 128.7501!)
            Me.Label66.Name = "Label66"
            Me.Label66.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label66.SizeF = New System.Drawing.SizeF(63.0!, 37.99988!)
            Me.Label66.StylePriority.UseFont = False
            Me.Label66.Text = "Estimate Hours"
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
            Me.Label62.LocationFloat = New DevExpress.Utils.PointFloat(657.0!, 128.7502!)
            Me.Label62.Name = "Label62"
            Me.Label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label62.SizeF = New System.Drawing.SizeF(63.0!, 37.99981!)
            Me.Label62.StylePriority.UseFont = False
            Me.Label62.Text = "Vendor Net " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cost"
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
            Me.Label64.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 145.7499!)
            Me.Label64.Name = "Label64"
            Me.Label64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label64.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label64.StylePriority.UseFont = False
            Me.Label64.Text = "Mark Up"
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
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 128.7501!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Estimate w/Cont."
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
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 145.7499!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(267.0!, 19.0!)
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
            Me.Label68.LocationFloat = New DevExpress.Utils.PointFloat(783.0!, 128.7502!)
            Me.Label68.Name = "Label68"
            Me.Label68.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label68.SizeF = New System.Drawing.SizeF(63.0!, 37.9997!)
            Me.Label68.StylePriority.UseFont = False
            Me.Label68.Text = "Total w/Resale"
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
            Me.Label70.LocationFloat = New DevExpress.Utils.PointFloat(908.9999!, 128.7502!)
            Me.Label70.Name = "Label70"
            Me.Label70.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label70.SizeF = New System.Drawing.SizeF(63.0!, 37.99974!)
            Me.Label70.StylePriority.UseFont = False
            Me.Label70.Text = "Non Billable"
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
            Me.Label72.LocationFloat = New DevExpress.Utils.PointFloat(845.9998!, 145.75!)
            Me.Label72.Name = "Label72"
            Me.Label72.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label72.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label72.StylePriority.UseFont = False
            Me.Label72.Text = "Billed"
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
            Me.Label74.LocationFloat = New DevExpress.Utils.PointFloat(594.0!, 145.7499!)
            Me.Label74.Name = "Label74"
            Me.Label74.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label74.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.Label74.StylePriority.UseFont = False
            Me.Label74.Text = "Open PO"
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
            Me.Line57.LocationFloat = New DevExpress.Utils.PointFloat(0!, 172.75!)
            Me.Line57.Name = "Line57"
            Me.Line57.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            '
            'GroupFooter2
            '
            Me.GroupFooter2.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreport2, Me.XrLabel31, Me.XrLabel16, Me.XrLabel17, Me.XrLabel15, Me.XrLabel13, Me.XrLabel14, Me.Label100, Me.Text101, Me.JTotal, Me.JNBillable, Me.JBilled, Me.Text110, Me.Line130, Me.XrSubreport1})
            Me.GroupFooter2.Dpi = 100.0!
            Me.GroupFooter2.HeightF = 65.00002!
            Me.GroupFooter2.KeepTogether = True
            Me.GroupFooter2.Level = 3
            Me.GroupFooter2.Name = "GroupFooter2"
            Me.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrSubreport2
            '
            Me.XrSubreport2.Dpi = 100.0!
            Me.XrSubreport2.LocationFloat = New DevExpress.Utils.PointFloat(559.0!, 40.25002!)
            Me.XrSubreport2.Name = "XrSubreport2"
            Me.XrSubreport2.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.BillingHistorySubReport()
            Me.XrSubreport2.SizeF = New System.Drawing.SizeF(412.9998!, 23.00001!)
            '
            'XrLabel31
            '
            Me.XrLabel31.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel31.BorderColor = System.Drawing.Color.Black
            Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel31.BorderWidth = 1.0!
            Me.XrLabel31.CanGrow = False
            Me.XrLabel31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateNetAmount")})
            Me.XrLabel31.Dpi = 100.0!
            Me.XrLabel31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 9.999974!)
            Me.XrLabel31.Name = "XrLabel31"
            Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel31.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel31.StylePriority.UseFont = False
            XrSummary27.FormatString = "{0:n2}"
            XrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel31.Summary = XrSummary27
            Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1.0!
            Me.XrLabel16.CanGrow = False
            Me.XrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfExtMarkupAmount")})
            Me.XrLabel16.Dpi = 100.0!
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 10.00004!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel16.StylePriority.UseFont = False
            XrSummary28.FormatString = "{0:n2}"
            XrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel16.Summary = XrSummary28
            Me.XrLabel16.Text = "FMU"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel17
            '
            Me.XrLabel17.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel17.BorderColor = System.Drawing.Color.Black
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel17.BorderWidth = 1.0!
            Me.XrLabel17.CanGrow = False
            Me.XrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.XrLabel17.Dpi = 100.0!
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 9.999974!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel17.StylePriority.UseFont = False
            XrSummary29.FormatString = "{0:n2}"
            XrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel17.Summary = XrSummary29
            Me.XrLabel17.Text = "XrLabel17"
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.XrLabel15.Dpi = 100.0!
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(657.0002!, 10.00004!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            XrSummary30.FormatString = "{0:n2}"
            XrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel15.Summary = XrSummary30
            Me.XrLabel15.Text = "FCOST"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1.0!
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfBillEmpHours")})
            Me.XrLabel13.Dpi = 100.0!
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(468.0002!, 9.999974!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            XrSummary31.FormatString = "{0:n2}"
            XrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel13.Summary = XrSummary31
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
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAmount")})
            Me.XrLabel14.Dpi = 100.0!
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(531.0002!, 9.999974!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            XrSummary32.FormatString = "{0:n2}"
            XrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel14.Summary = XrSummary32
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
            Me.Label100.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 10.00004!)
            Me.Label100.Name = "Label100"
            Me.Label100.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label100.SizeF = New System.Drawing.SizeF(266.9998!, 18.99999!)
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
            Me.Text101.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.Text101.Dpi = 100.0!
            Me.Text101.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text101.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 9.999974!)
            Me.Text101.Name = "Text101"
            Me.Text101.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text101.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text101.StylePriority.UseFont = False
            XrSummary33.FormatString = "{0:n2}"
            XrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text101.Summary = XrSummary33
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
            Me.JTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfLineTotal")})
            Me.JTotal.Dpi = 100.0!
            Me.JTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JTotal.LocationFloat = New DevExpress.Utils.PointFloat(782.9997!, 9.999974!)
            Me.JTotal.Name = "JTotal"
            Me.JTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JTotal.StylePriority.UseFont = False
            XrSummary34.FormatString = "{0:n2}"
            XrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JTotal.Summary = XrSummary34
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
            Me.JNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfNonBillableAmount")})
            Me.JNBillable.Dpi = 100.0!
            Me.JNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JNBillable.LocationFloat = New DevExpress.Utils.PointFloat(908.9998!, 9.999974!)
            Me.JNBillable.Name = "JNBillable"
            Me.JNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JNBillable.StylePriority.UseFont = False
            XrSummary35.FormatString = "{0:n2}"
            XrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JNBillable.Summary = XrSummary35
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
            Me.JBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.JBilled.Dpi = 100.0!
            Me.JBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JBilled.LocationFloat = New DevExpress.Utils.PointFloat(845.9997!, 10.00004!)
            Me.JBilled.Name = "JBilled"
            Me.JBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JBilled.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JBilled.StylePriority.UseFont = False
            XrSummary36.FormatString = "{0:n2}"
            XrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JBilled.Summary = XrSummary36
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
            Me.Text110.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 9.999974!)
            Me.Text110.Name = "Text110"
            Me.Text110.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text110.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text110.StylePriority.UseFont = False
            XrSummary37.FormatString = "{0:n2}"
            XrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text110.Summary = XrSummary37
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
            'XrSubreport1
            '
            Me.XrSubreport1.Dpi = 100.0!
            Me.XrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 40.25002!)
            Me.XrSubreport1.Name = "XrSubreport1"
            Me.XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.AdvancedBillingHistorySubReport()
            Me.XrSubreport1.SizeF = New System.Drawing.SizeF(508.0!, 23.0!)
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
            'Text134
            '
            Me.Text134.BackColor = System.Drawing.Color.Transparent
            Me.Text134.BorderColor = System.Drawing.Color.Black
            Me.Text134.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text134.BorderWidth = 1.0!
            Me.Text134.CanGrow = False
            Me.Text134.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.Text134.Dpi = 100.0!
            Me.Text134.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text134.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 9.999974!)
            Me.Text134.Name = "Text134"
            Me.Text134.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text134.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text134.StylePriority.UseFont = False
            XrSummary38.FormatString = "{0:n2}"
            XrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text134.Summary = XrSummary38
            Me.Text134.Text = "Text134"
            Me.Text134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTTotal
            '
            Me.FTTotal.BackColor = System.Drawing.Color.Transparent
            Me.FTTotal.BorderColor = System.Drawing.Color.Black
            Me.FTTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTTotal.BorderWidth = 1.0!
            Me.FTTotal.CanGrow = False
            Me.FTTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfLineTotal")})
            Me.FTTotal.Dpi = 100.0!
            Me.FTTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTTotal.LocationFloat = New DevExpress.Utils.PointFloat(783.0!, 9.999974!)
            Me.FTTotal.Name = "FTTotal"
            Me.FTTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTTotal.StylePriority.UseFont = False
            XrSummary39.FormatString = "{0:n2}"
            XrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTTotal.Summary = XrSummary39
            Me.FTTotal.Text = "FTTotal"
            Me.FTTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTNBillable
            '
            Me.FTNBillable.BackColor = System.Drawing.Color.Transparent
            Me.FTNBillable.BorderColor = System.Drawing.Color.Black
            Me.FTNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTNBillable.BorderWidth = 1.0!
            Me.FTNBillable.CanGrow = False
            Me.FTNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfNonBillableAmount")})
            Me.FTNBillable.Dpi = 100.0!
            Me.FTNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTNBillable.LocationFloat = New DevExpress.Utils.PointFloat(908.9998!, 9.999974!)
            Me.FTNBillable.Name = "FTNBillable"
            Me.FTNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTNBillable.StylePriority.UseFont = False
            XrSummary40.FormatString = "{0:n2}"
            XrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTNBillable.Summary = XrSummary40
            Me.FTNBillable.Text = "FTNBillable"
            Me.FTNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTBilled
            '
            Me.FTBilled.BackColor = System.Drawing.Color.Transparent
            Me.FTBilled.BorderColor = System.Drawing.Color.Black
            Me.FTBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTBilled.BorderWidth = 1.0!
            Me.FTBilled.CanGrow = False
            Me.FTBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.FTBilled.Dpi = 100.0!
            Me.FTBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTBilled.LocationFloat = New DevExpress.Utils.PointFloat(845.9999!, 9.999974!)
            Me.FTBilled.Name = "FTBilled"
            Me.FTBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTBilled.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTBilled.StylePriority.UseFont = False
            XrSummary41.FormatString = "{0:n2}"
            XrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTBilled.Summary = XrSummary41
            Me.FTBilled.Text = "FTBilled"
            Me.FTBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text142
            '
            Me.Text142.BackColor = System.Drawing.Color.Transparent
            Me.Text142.BorderColor = System.Drawing.Color.Black
            Me.Text142.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text142.BorderWidth = 1.0!
            Me.Text142.CanGrow = False
            Me.Text142.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.Text142.Dpi = 100.0!
            Me.Text142.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text142.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 9.999974!)
            Me.Text142.Name = "Text142"
            Me.Text142.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text142.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text142.StylePriority.UseFont = False
            XrSummary42.FormatString = "{0:n2}"
            XrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text142.Summary = XrSummary42
            Me.Text142.Text = "Text142"
            Me.Text142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Type
            '
            Me.Type.BackColor = System.Drawing.Color.Transparent
            Me.Type.BorderColor = System.Drawing.Color.Black
            Me.Type.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Type.BorderWidth = 1.0!
            Me.Type.CanGrow = False
            Me.Type.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionTypeTotal")})
            Me.Type.Dpi = 100.0!
            Me.Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Type.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00004!)
            Me.Type.Name = "Type"
            Me.Type.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Type.SizeF = New System.Drawing.SizeF(267.0!, 19.0!)
            Me.Type.StylePriority.UseFont = False
            XrSummary43.FormatString = "{0}"
            Me.Type.Summary = XrSummary43
            Me.Type.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel29, Me.XrLabel2, Me.XrLabel6, Me.XrLabel7, Me.XrLabel5, Me.XrLabel3, Me.XrLabel4, Me.Text79, Me.FTotal, Me.FNBillable, Me.FBilled, Me.Text88, Me.FUNC})
            Me.GroupFooter0.Dpi = 100.0!
            Me.GroupFooter0.HeightF = 21.00001!
            Me.GroupFooter0.Name = "GroupFooter0"
            '
            'XrLabel29
            '
            Me.XrLabel29.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel29.BorderColor = System.Drawing.Color.Black
            Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel29.BorderWidth = 1.0!
            Me.XrLabel29.CanGrow = False
            Me.XrLabel29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateNetAmount")})
            Me.XrLabel29.Dpi = 100.0!
            Me.XrLabel29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 0!)
            Me.XrLabel29.Name = "XrLabel29"
            Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel29.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel29.StylePriority.UseFont = False
            XrSummary44.FormatString = "{0:n2}"
            XrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel29.Summary = XrSummary44
            Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel2
            '
            Me.XrLabel2.CanGrow = False
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfAdvanceTotal")})
            Me.XrLabel2.Dpi = 100.0!
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(971.9999!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(28.00012!, 19.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            XrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel2.Summary = XrSummary45
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.XrLabel2.WordWrap = False
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.BorderWidth = 1.0!
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfExtMarkupAmount")})
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            XrSummary46.FormatString = "{0:n2}"
            XrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel6.Summary = XrSummary46
            Me.XrLabel6.Text = "FMU"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1.0!
            Me.XrLabel7.CanGrow = False
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            XrSummary47.FormatString = "{0:n2}"
            XrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel7.Summary = XrSummary47
            Me.XrLabel7.Text = "XrLabel7"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(657.0002!, 0!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            XrSummary48.FormatString = "{0:n2}"
            XrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel5.Summary = XrSummary48
            Me.XrLabel5.Text = "FCOST"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfBillEmpHours")})
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(467.9997!, 0!)
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
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAmount")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(531.0!, 0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            XrSummary50.FormatString = "{0:n2}"
            XrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel4.Summary = XrSummary50
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text79
            '
            Me.Text79.BackColor = System.Drawing.Color.Transparent
            Me.Text79.BorderColor = System.Drawing.Color.Black
            Me.Text79.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text79.BorderWidth = 1.0!
            Me.Text79.CanGrow = False
            Me.Text79.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.Text79.Dpi = 100.0!
            Me.Text79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text79.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 0!)
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
            Me.FTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfLineTotal")})
            Me.FTotal.Dpi = 100.0!
            Me.FTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTotal.LocationFloat = New DevExpress.Utils.PointFloat(782.9997!, 0!)
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
            Me.FNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfNonBillableAmount")})
            Me.FNBillable.Dpi = 100.0!
            Me.FNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FNBillable.LocationFloat = New DevExpress.Utils.PointFloat(908.9998!, 0!)
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
            Me.FBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.FBilled.Dpi = 100.0!
            Me.FBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FBilled.LocationFloat = New DevExpress.Utils.PointFloat(845.9997!, 0!)
            Me.FBilled.Name = "FBilled"
            Me.FBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FBilled.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
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
            Me.Text88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text88.LocationFloat = New DevExpress.Utils.PointFloat(594.0001!, 0!)
            Me.Text88.Name = "Text88"
            Me.Text88.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text88.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
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
            Me.AdvanceFlag.Expression = "Iif([AdvanceBillFlag] In (1,2,3,4,5),[AdvanceBillFlag]  , 'None')"
            Me.AdvanceFlag.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AdvanceFlag.Name = "AdvanceFlag"
            '
            'BillableStatus
            '
            Me.BillableStatus.Expression = "[IsNonBillable]"
            Me.BillableStatus.Name = "BillableStatus"
            '
            'HoldStatus
            '
            Me.HoldStatus.Expression = "[Hold]"
            Me.HoldStatus.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.HoldStatus.Name = "HoldStatus"
            '
            'ProcessDescription
            '
            Me.ProcessDescription.Expression = "[ProcessDesc]"
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
            Me.BilledField.Expression = "Iif([IsNonBillable] = 'Non-Billable', 0 ,[SumOfBilledAmount] + [SumOfAdvanceBille" &
    "d] )"
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
            'GroupFooter4
            '
            Me.GroupFooter4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel30, Me.XrLabel11, Me.XrLabel12, Me.XrLabel10, Me.XrLabel8, Me.XrLabel9, Me.Type, Me.Text142, Me.FTBilled, Me.FTNBillable, Me.FTTotal, Me.Text134})
            Me.GroupFooter4.Dpi = 100.0!
            Me.GroupFooter4.HeightF = 40.0!
            Me.GroupFooter4.Level = 1
            Me.GroupFooter4.Name = "GroupFooter4"
            '
            'XrLabel30
            '
            Me.XrLabel30.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel30.BorderColor = System.Drawing.Color.Black
            Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel30.BorderWidth = 1.0!
            Me.XrLabel30.CanGrow = False
            Me.XrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateNetAmount")})
            Me.XrLabel30.Dpi = 100.0!
            Me.XrLabel30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 9.999974!)
            Me.XrLabel30.Name = "XrLabel30"
            Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel30.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel30.StylePriority.UseFont = False
            XrSummary56.FormatString = "{0:n2}"
            XrSummary56.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel30.Summary = XrSummary56
            Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel11
            '
            Me.XrLabel11.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel11.BorderColor = System.Drawing.Color.Black
            Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel11.BorderWidth = 1.0!
            Me.XrLabel11.CanGrow = False
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfExtMarkupAmount")})
            Me.XrLabel11.Dpi = 100.0!
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 9.999974!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel11.StylePriority.UseFont = False
            XrSummary57.FormatString = "{0:n2}"
            XrSummary57.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel11.Summary = XrSummary57
            Me.XrLabel11.Text = "FMU"
            Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel12
            '
            Me.XrLabel12.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel12.BorderColor = System.Drawing.Color.Black
            Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel12.BorderWidth = 1.0!
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.XrLabel12.Dpi = 100.0!
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(404.9998!, 9.999974!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            XrSummary58.FormatString = "{0:n2}"
            XrSummary58.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel12.Summary = XrSummary58
            Me.XrLabel12.Text = "XrLabel12"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1.0!
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.XrLabel10.Dpi = 100.0!
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(657.0002!, 9.999974!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            XrSummary59.FormatString = "{0:n2}"
            XrSummary59.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel10.Summary = XrSummary59
            Me.XrLabel10.Text = "FCOST"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel8.BorderColor = System.Drawing.Color.Black
            Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel8.BorderWidth = 1.0!
            Me.XrLabel8.CanGrow = False
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfBillEmpHours")})
            Me.XrLabel8.Dpi = 100.0!
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(467.9997!, 9.999974!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel8.StylePriority.UseFont = False
            XrSummary60.FormatString = "{0:n2}"
            XrSummary60.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel8.Summary = XrSummary60
            Me.XrLabel8.Text = "XrLabel8"
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel9
            '
            Me.XrLabel9.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel9.BorderColor = System.Drawing.Color.Black
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel9.BorderWidth = 1.0!
            Me.XrLabel9.CanGrow = False
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAmount")})
            Me.XrLabel9.Dpi = 100.0!
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(531.0002!, 9.999974!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            XrSummary61.FormatString = "{0:n2}"
            XrSummary61.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel9.Summary = XrSummary61
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Dpi = 100.0!
            Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader2.HeightF = 0!
            Me.GroupHeader2.Level = 1
            Me.GroupHeader2.Name = "GroupHeader2"
            Me.GroupHeader2.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.JobDetailAnalysis)
            '
            'HoursAmount
            '
            Me.HoursAmount.Expression = "[SumOfTotalBill] - [SumOfExtMarkupAmount]"
            Me.HoursAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.HoursAmount.Name = "HoursAmount"
            '
            'AdvanceBill
            '
            Me.AdvanceBill.Expression = "Iif([SumOfAdvanceTotal] <> 0,'Y'  ,'N' )"
            Me.AdvanceBill.Name = "AdvanceBill"
            '
            'GroupHeader4
            '
            Me.GroupHeader4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel35, Me.XrLabel36})
            Me.GroupHeader4.Dpi = 100.0!
            Me.GroupHeader4.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountExecutiveCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader4.HeightF = 19.79167!
            Me.GroupHeader4.Level = 5
            Me.GroupHeader4.Name = "GroupHeader4"
            Me.GroupHeader4.RepeatEveryPage = True
            '
            'XrLabel35
            '
            Me.XrLabel35.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel35.BorderColor = System.Drawing.Color.Black
            Me.XrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel35.BorderWidth = 1.0!
            Me.XrLabel35.CanGrow = False
            Me.XrLabel35.Dpi = 100.0!
            Me.XrLabel35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel35.ForeColor = System.Drawing.Color.Black
            Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
            Me.XrLabel35.Name = "XrLabel35"
            Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel35.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.XrLabel35.StylePriority.UseFont = False
            Me.XrLabel35.Text = "Account Executive:"
            Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel36
            '
            Me.XrLabel36.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel36.BorderColor = System.Drawing.Color.Black
            Me.XrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel36.BorderWidth = 1.0!
            Me.XrLabel36.CanGrow = False
            Me.XrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountExecutiveFull")})
            Me.XrLabel36.Dpi = 100.0!
            Me.XrLabel36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(130.0001!, 0!)
            Me.XrLabel36.Name = "XrLabel36"
            Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel36.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.XrLabel36.StylePriority.UseFont = False
            XrSummary62.FormatString = "{0}"
            Me.XrLabel36.Summary = XrSummary62
            Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooter5
            '
            Me.GroupFooter5.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrLabel37, Me.XrLabel38, Me.XrLabel39, Me.XrLabel40, Me.XrLabel41, Me.XrLabel42, Me.XrLabel43, Me.XrLabel44, Me.XrLabel45, Me.XrLabel46, Me.XrLabel47, Me.XrLabel48, Me.XrLabel49, Me.XrLabel50, Me.XrLabel51, Me.XrLabel52, Me.XrLabel58, Me.XrLabel59, Me.XrLabel60, Me.XrLabel61, Me.XrLabel62, Me.XrLabel63, Me.XrLabel64})
            Me.GroupFooter5.Dpi = 100.0!
            Me.GroupFooter5.HeightF = 79.16666!
            Me.GroupFooter5.Level = 5
            Me.GroupFooter5.Name = "GroupFooter5"
            Me.GroupFooter5.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(278.9998!, 48.00002!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(692.0!, 4.0!)
            '
            'XrLabel37
            '
            Me.XrLabel37.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel37.BorderColor = System.Drawing.Color.Black
            Me.XrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel37.BorderWidth = 1.0!
            Me.XrLabel37.CanGrow = False
            Me.XrLabel37.Dpi = 100.0!
            Me.XrLabel37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel37.ForeColor = System.Drawing.Color.Black
            Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 26.99998!)
            Me.XrLabel37.Name = "XrLabel37"
            Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel37.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel37.StylePriority.UseFont = False
            Me.XrLabel37.Text = "Open PO"
            Me.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel38
            '
            Me.XrLabel38.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel38.BorderColor = System.Drawing.Color.Black
            Me.XrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel38.BorderWidth = 1.0!
            Me.XrLabel38.CanGrow = False
            Me.XrLabel38.Dpi = 100.0!
            Me.XrLabel38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel38.ForeColor = System.Drawing.Color.Black
            Me.XrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(845.9996!, 27.00005!)
            Me.XrLabel38.Name = "XrLabel38"
            Me.XrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel38.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel38.StylePriority.UseFont = False
            Me.XrLabel38.Text = "Billed"
            Me.XrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel39
            '
            Me.XrLabel39.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel39.BorderColor = System.Drawing.Color.Black
            Me.XrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel39.BorderWidth = 1.0!
            Me.XrLabel39.CanGrow = False
            Me.XrLabel39.Dpi = 100.0!
            Me.XrLabel39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel39.ForeColor = System.Drawing.Color.Black
            Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(908.9999!, 10.00004!)
            Me.XrLabel39.Name = "XrLabel39"
            Me.XrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel39.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel39.StylePriority.UseFont = False
            Me.XrLabel39.Text = "Non Billable"
            Me.XrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel40
            '
            Me.XrLabel40.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel40.BorderColor = System.Drawing.Color.Black
            Me.XrLabel40.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel40.BorderWidth = 1.0!
            Me.XrLabel40.CanGrow = False
            Me.XrLabel40.Dpi = 100.0!
            Me.XrLabel40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel40.ForeColor = System.Drawing.Color.Black
            Me.XrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(782.9996!, 26.99998!)
            Me.XrLabel40.Name = "XrLabel40"
            Me.XrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel40.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel40.StylePriority.UseFont = False
            Me.XrLabel40.Text = "Total"
            Me.XrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel41
            '
            Me.XrLabel41.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel41.BorderColor = System.Drawing.Color.Black
            Me.XrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel41.BorderWidth = 1.0!
            Me.XrLabel41.CanGrow = False
            Me.XrLabel41.Dpi = 100.0!
            Me.XrLabel41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel41.ForeColor = System.Drawing.Color.Black
            Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(278.9999!, 10.0!)
            Me.XrLabel41.Name = "XrLabel41"
            Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel41.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel41.StylePriority.UseFont = False
            Me.XrLabel41.Text = "Estimate w/Cont."
            Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel42
            '
            Me.XrLabel42.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel42.BorderColor = System.Drawing.Color.Black
            Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel42.BorderWidth = 1.0!
            Me.XrLabel42.CanGrow = False
            Me.XrLabel42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.XrLabel42.Dpi = 100.0!
            Me.XrLabel42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(594.0002!, 59.00002!)
            Me.XrLabel42.Name = "XrLabel42"
            Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel42.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel42.StylePriority.UseFont = False
            XrSummary63.FormatString = "{0:n2}"
            XrSummary63.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel42.Summary = XrSummary63
            Me.XrLabel42.Text = "Text99"
            Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel43
            '
            Me.XrLabel43.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel43.BorderColor = System.Drawing.Color.Black
            Me.XrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel43.BorderWidth = 1.0!
            Me.XrLabel43.CanGrow = False
            Me.XrLabel43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.XrLabel43.Dpi = 100.0!
            Me.XrLabel43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(845.9996!, 59.00002!)
            Me.XrLabel43.Name = "XrLabel43"
            Me.XrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel43.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel43.StylePriority.UseFont = False
            XrSummary64.FormatString = "{0:n2}"
            XrSummary64.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel43.Summary = XrSummary64
            Me.XrLabel43.Text = "CBilled"
            Me.XrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel44
            '
            Me.XrLabel44.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel44.BorderColor = System.Drawing.Color.Black
            Me.XrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel44.BorderWidth = 1.0!
            Me.XrLabel44.CanGrow = False
            Me.XrLabel44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfNonBillableAmount")})
            Me.XrLabel44.Dpi = 100.0!
            Me.XrLabel44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(908.9998!, 59.00002!)
            Me.XrLabel44.Name = "XrLabel44"
            Me.XrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel44.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel44.StylePriority.UseFont = False
            XrSummary65.FormatString = "{0:n2}"
            XrSummary65.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel44.Summary = XrSummary65
            Me.XrLabel44.Text = "CNBillable"
            Me.XrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel45
            '
            Me.XrLabel45.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel45.BorderColor = System.Drawing.Color.Black
            Me.XrLabel45.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel45.BorderWidth = 1.0!
            Me.XrLabel45.CanGrow = False
            Me.XrLabel45.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfLineTotal")})
            Me.XrLabel45.Dpi = 100.0!
            Me.XrLabel45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(783.0!, 59.00002!)
            Me.XrLabel45.Name = "XrLabel45"
            Me.XrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel45.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel45.StylePriority.UseFont = False
            XrSummary66.FormatString = "{0:n2}"
            XrSummary66.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel45.Summary = XrSummary66
            Me.XrLabel45.Text = "CTotal"
            Me.XrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel46
            '
            Me.XrLabel46.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel46.BorderColor = System.Drawing.Color.Black
            Me.XrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel46.BorderWidth = 1.0!
            Me.XrLabel46.CanGrow = False
            Me.XrLabel46.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.XrLabel46.Dpi = 100.0!
            Me.XrLabel46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(278.9999!, 59.0!)
            Me.XrLabel46.Name = "XrLabel46"
            Me.XrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel46.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel46.StylePriority.UseFont = False
            XrSummary67.FormatString = "{0:n2}"
            XrSummary67.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel46.Summary = XrSummary67
            Me.XrLabel46.Text = "Text90"
            Me.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel47
            '
            Me.XrLabel47.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel47.BorderColor = System.Drawing.Color.Black
            Me.XrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel47.BorderWidth = 1.0!
            Me.XrLabel47.CanGrow = False
            Me.XrLabel47.Dpi = 100.0!
            Me.XrLabel47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel47.ForeColor = System.Drawing.Color.Black
            Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 59.00002!)
            Me.XrLabel47.Name = "XrLabel47"
            Me.XrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel47.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
            Me.XrLabel47.StylePriority.UseFont = False
            Me.XrLabel47.Text = "Total for Account Executive:"
            Me.XrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel48
            '
            Me.XrLabel48.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel48.BorderColor = System.Drawing.Color.Black
            Me.XrLabel48.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel48.BorderWidth = 1.0!
            Me.XrLabel48.CanGrow = False
            Me.XrLabel48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAmount")})
            Me.XrLabel48.Dpi = 100.0!
            Me.XrLabel48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel48.LocationFloat = New DevExpress.Utils.PointFloat(531.0001!, 59.00002!)
            Me.XrLabel48.Name = "XrLabel48"
            Me.XrLabel48.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel48.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel48.StylePriority.UseFont = False
            XrSummary68.FormatString = "{0:n2}"
            XrSummary68.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel48.Summary = XrSummary68
            Me.XrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel49
            '
            Me.XrLabel49.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel49.BorderColor = System.Drawing.Color.Black
            Me.XrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel49.BorderWidth = 1.0!
            Me.XrLabel49.CanGrow = False
            Me.XrLabel49.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfBillEmpHours")})
            Me.XrLabel49.Dpi = 100.0!
            Me.XrLabel49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel49.LocationFloat = New DevExpress.Utils.PointFloat(468.0002!, 59.00002!)
            Me.XrLabel49.Name = "XrLabel49"
            Me.XrLabel49.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel49.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel49.StylePriority.UseFont = False
            XrSummary69.FormatString = "{0:n2}"
            XrSummary69.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel49.Summary = XrSummary69
            Me.XrLabel49.Text = "XrLabel18"
            Me.XrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel50
            '
            Me.XrLabel50.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel50.BorderColor = System.Drawing.Color.Black
            Me.XrLabel50.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel50.BorderWidth = 1.0!
            Me.XrLabel50.CanGrow = False
            Me.XrLabel50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetCost")})
            Me.XrLabel50.Dpi = 100.0!
            Me.XrLabel50.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel50.LocationFloat = New DevExpress.Utils.PointFloat(657.0001!, 59.00002!)
            Me.XrLabel50.Name = "XrLabel50"
            Me.XrLabel50.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel50.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel50.StylePriority.UseFont = False
            XrSummary70.FormatString = "{0:n2}"
            XrSummary70.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel50.Summary = XrSummary70
            Me.XrLabel50.Text = "FCOST"
            Me.XrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel51
            '
            Me.XrLabel51.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel51.BorderColor = System.Drawing.Color.Black
            Me.XrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel51.BorderWidth = 1.0!
            Me.XrLabel51.CanGrow = False
            Me.XrLabel51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.XrLabel51.Dpi = 100.0!
            Me.XrLabel51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(404.9997!, 59.00002!)
            Me.XrLabel51.Name = "XrLabel51"
            Me.XrLabel51.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel51.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel51.StylePriority.UseFont = False
            XrSummary71.FormatString = "{0:n2}"
            XrSummary71.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel51.Summary = XrSummary71
            Me.XrLabel51.Text = "XrLabel22"
            Me.XrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel52
            '
            Me.XrLabel52.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel52.BorderColor = System.Drawing.Color.Black
            Me.XrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel52.BorderWidth = 1.0!
            Me.XrLabel52.CanGrow = False
            Me.XrLabel52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfExtMarkupAmount")})
            Me.XrLabel52.Dpi = 100.0!
            Me.XrLabel52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 59.00002!)
            Me.XrLabel52.Name = "XrLabel52"
            Me.XrLabel52.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel52.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel52.StylePriority.UseFont = False
            XrSummary72.FormatString = "{0:n2}"
            XrSummary72.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel52.Summary = XrSummary72
            Me.XrLabel52.Text = "FMU"
            Me.XrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel58
            '
            Me.XrLabel58.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel58.BorderColor = System.Drawing.Color.Black
            Me.XrLabel58.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel58.BorderWidth = 1.0!
            Me.XrLabel58.CanGrow = False
            Me.XrLabel58.Dpi = 100.0!
            Me.XrLabel58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel58.ForeColor = System.Drawing.Color.Black
            Me.XrLabel58.LocationFloat = New DevExpress.Utils.PointFloat(657.0003!, 26.99998!)
            Me.XrLabel58.Name = "XrLabel58"
            Me.XrLabel58.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel58.SizeF = New System.Drawing.SizeF(63.0!, 20.99999!)
            Me.XrLabel58.StylePriority.UseFont = False
            Me.XrLabel58.Text = "Net " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cost"
            Me.XrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel59
            '
            Me.XrLabel59.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel59.BorderColor = System.Drawing.Color.Black
            Me.XrLabel59.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel59.BorderWidth = 1.0!
            Me.XrLabel59.CanGrow = False
            Me.XrLabel59.Dpi = 100.0!
            Me.XrLabel59.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel59.ForeColor = System.Drawing.Color.Black
            Me.XrLabel59.LocationFloat = New DevExpress.Utils.PointFloat(404.9997!, 26.99998!)
            Me.XrLabel59.Name = "XrLabel59"
            Me.XrLabel59.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel59.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel59.StylePriority.UseFont = False
            Me.XrLabel59.Text = "Resale Tax"
            Me.XrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel60
            '
            Me.XrLabel60.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel60.BorderColor = System.Drawing.Color.Black
            Me.XrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel60.BorderWidth = 1.0!
            Me.XrLabel60.CanGrow = False
            Me.XrLabel60.Dpi = 100.0!
            Me.XrLabel60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel60.ForeColor = System.Drawing.Color.Black
            Me.XrLabel60.LocationFloat = New DevExpress.Utils.PointFloat(720.0001!, 27.00005!)
            Me.XrLabel60.Name = "XrLabel60"
            Me.XrLabel60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel60.SizeF = New System.Drawing.SizeF(63.0!, 21.0!)
            Me.XrLabel60.StylePriority.UseFont = False
            Me.XrLabel60.Text = "Mark Up"
            Me.XrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel61
            '
            Me.XrLabel61.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel61.BorderColor = System.Drawing.Color.Black
            Me.XrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel61.BorderWidth = 1.0!
            Me.XrLabel61.CanGrow = False
            Me.XrLabel61.Dpi = 100.0!
            Me.XrLabel61.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel61.ForeColor = System.Drawing.Color.Black
            Me.XrLabel61.LocationFloat = New DevExpress.Utils.PointFloat(531.0001!, 9.999974!)
            Me.XrLabel61.Name = "XrLabel61"
            Me.XrLabel61.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel61.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel61.StylePriority.UseFont = False
            Me.XrLabel61.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.XrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel62
            '
            Me.XrLabel62.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel62.BorderColor = System.Drawing.Color.Black
            Me.XrLabel62.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel62.BorderWidth = 1.0!
            Me.XrLabel62.CanGrow = False
            Me.XrLabel62.Dpi = 100.0!
            Me.XrLabel62.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel62.ForeColor = System.Drawing.Color.Black
            Me.XrLabel62.LocationFloat = New DevExpress.Utils.PointFloat(468.0002!, 10.00004!)
            Me.XrLabel62.Name = "XrLabel62"
            Me.XrLabel62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel62.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel62.StylePriority.UseFont = False
            Me.XrLabel62.Text = "Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Billable"
            Me.XrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel63
            '
            Me.XrLabel63.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel63.BorderColor = System.Drawing.Color.Black
            Me.XrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel63.BorderWidth = 1.0!
            Me.XrLabel63.CanGrow = False
            Me.XrLabel63.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateNetAmount")})
            Me.XrLabel63.Dpi = 100.0!
            Me.XrLabel63.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel63.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 59.00002!)
            Me.XrLabel63.Name = "XrLabel63"
            Me.XrLabel63.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel63.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel63.StylePriority.UseFont = False
            XrSummary73.FormatString = "{0:n2}"
            XrSummary73.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel63.Summary = XrSummary73
            Me.XrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel64
            '
            Me.XrLabel64.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel64.BorderColor = System.Drawing.Color.Black
            Me.XrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel64.BorderWidth = 1.0!
            Me.XrLabel64.CanGrow = False
            Me.XrLabel64.Dpi = 100.0!
            Me.XrLabel64.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel64.ForeColor = System.Drawing.Color.Black
            Me.XrLabel64.LocationFloat = New DevExpress.Utils.PointFloat(341.9998!, 10.00016!)
            Me.XrLabel64.Name = "XrLabel64"
            Me.XrLabel64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel64.SizeF = New System.Drawing.SizeF(63.0!, 37.99988!)
            Me.XrLabel64.StylePriority.UseFont = False
            Me.XrLabel64.Text = "Estimate Net Cost"
            Me.XrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'SummaryByFunctionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.GroupHeaderForm_CDP, Me.GroupFooter1, Me.GroupHeader3, Me.GroupHeader1, Me.GroupFooter2, Me.GroupHeaderFunction, Me.GroupFooter3, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupFooter4, Me.GroupHeader2, Me.GroupHeader4, Me.GroupFooter5})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientFull, Me.DivisionFull, Me.ProductFull, Me.JobFull, Me.JobComponentFull, Me.AdvanceFlag, Me.BillableStatus, Me.HoldStatus, Me.ProcessDescription, Me.AccountExecutiveFull, Me.FunctionFull, Me.FunctionTypeTotal, Me.NetCost, Me.BilledField, Me.Unbilled, Me.TodaysDate, Me.HoursAmount, Me.AdvanceBill})
            Me.DataSource = Me.BindingSource
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.SnapGridSize = 1.0!
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
        Public WithEvents XrSubreport2 As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents HoursAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AdvanceBill As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents XrLabel53 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel54 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel55 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel56 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel57 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader4 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooter5 As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel43 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel44 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel45 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel48 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel49 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel50 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel51 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel52 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel63 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel38 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel40 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel58 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel59 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel60 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel61 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel62 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel64 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace






