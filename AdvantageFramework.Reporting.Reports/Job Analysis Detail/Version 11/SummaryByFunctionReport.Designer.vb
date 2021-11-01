Namespace JobAnalysisDetail.Version11

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
        Private Text132 As DevExpress.XtraReports.UI.XRLabel
        Private Label150 As DevExpress.XtraReports.UI.XRLabel
        Private Label164 As DevExpress.XtraReports.UI.XRLabel
        Private Label165 As DevExpress.XtraReports.UI.XRLabel
        Private Label166 As DevExpress.XtraReports.UI.XRLabel
        Private Label167 As DevExpress.XtraReports.UI.XRLabel
        Private Line168 As DevExpress.XtraReports.UI.XRLine
        Private Label169 As DevExpress.XtraReports.UI.XRLabel
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
        Private Text131 As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Text134 As DevExpress.XtraReports.UI.XRLabel
        Private FTTotal As DevExpress.XtraReports.UI.XRLabel
        Private FTNBillable As DevExpress.XtraReports.UI.XRLabel
        Private FTBilled As DevExpress.XtraReports.UI.XRLabel
        Private Text142 As DevExpress.XtraReports.UI.XRLabel
        Private Text144 As DevExpress.XtraReports.UI.XRLabel
        Private Type As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter0 As DevExpress.XtraReports.UI.GroupFooterBand
        Private Text77 As DevExpress.XtraReports.UI.XRLabel
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_SortBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LineBottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
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
            Me.Label156 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AE = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label153 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label154 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text120 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
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
            Me.Text132 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label150 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label164 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label165 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label166 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label167 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line168 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label169 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
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
            Me.Line57 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label129 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrSubreport3 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrSubreport2 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.Text131 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Text134 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTNBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.FTBilled = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text142 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text144 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Type = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text77 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.BilledField = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Unbilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TodaysDate = New DevExpress.XtraReports.UI.CalculatedField()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.GroupFooter4 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.ActualHours = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ActualAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Variance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField2 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField3 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField4 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField5 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField6 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField7 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AdvancedBillingHistorySubReport1 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvancedBillingHistorySubReport()
            Me.BillingHistorySubReport1 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.BillingHistorySubReport()
            Me.AdvanceReconciliationHistorySubReport1 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvanceReconciliationHistorySubReport()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AdvancedBillingHistorySubReport1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BillingHistorySubReport1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AdvanceReconciliationHistorySubReport1, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.LabelPageHeader_Title.Text = "Job Analysis (V11) - Summary by Function"
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
            Me.PageFooter.HeightF = 30.99997!
            Me.PageFooter.Name = "PageFooter"
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
            Me.FUNC.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
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
            Me.LabelCDP_ClientData.LocationFloat = New DevExpress.Utils.PointFloat(78.95851!, 3.999964!)
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
            Me.Text31.LocationFloat = New DevExpress.Utils.PointFloat(78.9585!, 22.99999!)
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
            Me.LabelPageHeader_ProductData.LocationFloat = New DevExpress.Utils.PointFloat(617.5414!, 3.999996!)
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
            Me.LabelPageHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(487.5414!, 3.999996!)
            Me.LabelPageHeader_Product.Name = "LabelPageHeader_Product"
            Me.LabelPageHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Product.SizeF = New System.Drawing.SizeF(54.0!, 19.0!)
            Me.LabelPageHeader_Product.StylePriority.UseFont = False
            Me.LabelPageHeader_Product.Text = "Product:"
            Me.LabelPageHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label156.LocationFloat = New DevExpress.Utils.PointFloat(487.5414!, 23.00002!)
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
            Me.AE.LocationFloat = New DevExpress.Utils.PointFloat(617.5414!, 22.99999!)
            Me.AE.Name = "AE"
            Me.AE.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.AE.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.AE.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0}"
            Me.AE.Summary = XrSummary4
            Me.AE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label153.LocationFloat = New DevExpress.Utils.PointFloat(0.000166893!, 0!)
            Me.Label153.Name = "Label153"
            Me.Label153.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label153.SizeF = New System.Drawing.SizeF(78.95833!, 19.0!)
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
            Me.Job.LocationFloat = New DevExpress.Utils.PointFloat(78.95851!, 0!)
            Me.Job.Name = "Job"
            Me.Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Job.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.Job.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0}"
            Me.Job.Summary = XrSummary5
            Me.Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label154.LocationFloat = New DevExpress.Utils.PointFloat(487.5414!, 0!)
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
            Me.Text120.LocationFloat = New DevExpress.Utils.PointFloat(617.5414!, 0!)
            Me.Text120.Name = "Text120"
            Me.Text120.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text120.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.Text120.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0}"
            Me.Text120.Summary = XrSummary6
            Me.Text120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooter1
            '
            Me.GroupFooter1.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel26, Me.XrLabel27, Me.XrLabel25, Me.XrLabel23, Me.XrLabel24, Me.XrLabel21, Me.XrLabel22, Me.XrLabel20, Me.XrLabel18, Me.XrLabel19, Me.Label52, Me.Text90, Me.CTotal, Me.CNBillable, Me.CBilled, Me.Text99, Me.Text132, Me.Label150, Me.Label164, Me.Label165, Me.Label166, Me.Label167, Me.Line168, Me.Label169})
            Me.GroupFooter1.Dpi = 100.0!
            Me.GroupFooter1.HeightF = 80.0!
            Me.GroupFooter1.KeepTogether = True
            Me.GroupFooter1.Level = 4
            Me.GroupFooter1.Name = "GroupFooter1"
            Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
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
            Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 9.999974!)
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
            Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 9.999974!)
            Me.XrLabel27.Name = "XrLabel27"
            Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel27.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel27.StylePriority.UseFont = False
            Me.XrLabel27.Text = "Estimated Cost"
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
            Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 0!)
            Me.XrLabel25.Name = "XrLabel25"
            Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel25.SizeF = New System.Drawing.SizeF(62.99994!, 47.99995!)
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
            Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 9.999974!)
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
            Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 9.999974!)
            Me.XrLabel24.Name = "XrLabel24"
            Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel24.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.XrLabel24.StylePriority.UseFont = False
            Me.XrLabel24.Text = "Actual Costs"
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
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 58.99995!)
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel21.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel21.Summary = XrSummary7
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
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 58.99995!)
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel22.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel22.Summary = XrSummary8
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
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 58.99995!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel20.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel20.Summary = XrSummary9
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
            Me.XrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours")})
            Me.XrLabel18.Dpi = 100.0!
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 58.99995!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel18.Summary = XrSummary10
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
            Me.XrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField6")})
            Me.XrLabel19.Dpi = 100.0!
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 58.99995!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel19.Summary = XrSummary11
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
            Me.Text90.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 58.99995!)
            Me.Text90.Name = "Text90"
            Me.Text90.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text90.SizeF = New System.Drawing.SizeF(52.58337!, 19.0!)
            Me.Text90.StylePriority.UseFont = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text90.Summary = XrSummary12
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
            Me.CTotal.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 58.99995!)
            Me.CTotal.Name = "CTotal"
            Me.CTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CTotal.StylePriority.UseFont = False
            XrSummary13.FormatString = "{0:n2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CTotal.Summary = XrSummary13
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
            Me.CNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.CNBillable.Dpi = 100.0!
            Me.CNBillable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CNBillable.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 58.99995!)
            Me.CNBillable.Name = "CNBillable"
            Me.CNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.CNBillable.StylePriority.UseFont = False
            XrSummary14.FormatString = "{0:n2}"
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CNBillable.Summary = XrSummary14
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
            Me.CBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField7")})
            Me.CBilled.Dpi = 100.0!
            Me.CBilled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CBilled.LocationFloat = New DevExpress.Utils.PointFloat(699.1248!, 58.99995!)
            Me.CBilled.Name = "CBilled"
            Me.CBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CBilled.SizeF = New System.Drawing.SizeF(73.45837!, 19.0!)
            Me.CBilled.StylePriority.UseFont = False
            XrSummary15.FormatString = "{0:n2}"
            XrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CBilled.Summary = XrSummary15
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
            Me.Text99.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.Text99.Dpi = 100.0!
            Me.Text99.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text99.LocationFloat = New DevExpress.Utils.PointFloat(772.5831!, 58.99995!)
            Me.Text99.Name = "Text99"
            Me.Text99.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text99.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text99.StylePriority.UseFont = False
            XrSummary16.FormatString = "{0:n2}"
            XrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text99.Summary = XrSummary16
            Me.Text99.Text = "Text99"
            Me.Text99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text132
            '
            Me.Text132.BackColor = System.Drawing.Color.Transparent
            Me.Text132.BorderColor = System.Drawing.Color.Black
            Me.Text132.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text132.BorderWidth = 1.0!
            Me.Text132.CanGrow = False
            Me.Text132.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField2")})
            Me.Text132.Dpi = 100.0!
            Me.Text132.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text132.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 58.99995!)
            Me.Text132.Name = "Text132"
            Me.Text132.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text132.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text132.StylePriority.UseFont = False
            XrSummary17.FormatString = "{0:n2}"
            XrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text132.Summary = XrSummary17
            Me.Text132.Text = "Text132"
            Me.Text132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.Label150.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 9.999974!)
            Me.Label150.Name = "Label150"
            Me.Label150.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label150.SizeF = New System.Drawing.SizeF(52.58337!, 38.0!)
            Me.Label150.StylePriority.UseFont = False
            Me.Label150.Text = "Estimate Hrs/Qty"
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
            Me.Label164.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 9.999974!)
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
            Me.Label165.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 0!)
            Me.Label165.Name = "Label165"
            Me.Label165.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label165.SizeF = New System.Drawing.SizeF(63.0!, 47.99995!)
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
            Me.Label166.LocationFloat = New DevExpress.Utils.PointFloat(698.1249!, 9.999974!)
            Me.Label166.Name = "Label166"
            Me.Label166.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label166.SizeF = New System.Drawing.SizeF(137.4582!, 37.99998!)
            Me.Label166.StylePriority.UseFont = False
            Me.Label166.Text = "Reconciled/Recognized Cost/OOP              GP"
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
            Me.Label167.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 9.999974!)
            Me.Label167.Name = "Label167"
            Me.Label167.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label167.SizeF = New System.Drawing.SizeF(63.0!, 37.99998!)
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
            Me.Line168.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 47.99995!)
            Me.Line168.Name = "Line168"
            Me.Line168.SizeF = New System.Drawing.SizeF(740.4585!, 4.000027!)
            '
            'Label169
            '
            Me.Label169.BackColor = System.Drawing.Color.Transparent
            Me.Label169.BorderColor = System.Drawing.Color.Black
            Me.Label169.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label169.BorderWidth = 1.0!
            Me.Label169.CanGrow = False
            Me.Label169.Dpi = 100.0!
            Me.Label169.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label169.ForeColor = System.Drawing.Color.Black
            Me.Label169.LocationFloat = New DevExpress.Utils.PointFloat(963.9999!, 26.99998!)
            Me.Label169.Name = "Label169"
            Me.Label169.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label169.SizeF = New System.Drawing.SizeF(44.0!, 21.0!)
            Me.Label169.StylePriority.UseFont = False
            Me.Label169.Text = "Vendor"
            Me.Label169.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupHeader3
            '
            Me.GroupHeader3.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label153, Me.Job, Me.Label154, Me.Text120})
            Me.GroupHeader3.Dpi = 100.0!
            Me.GroupHeader3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponent", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader3.HeightF = 19.0!
            Me.GroupHeader3.Level = 3
            Me.GroupHeader3.Name = "GroupHeader3"
            Me.GroupHeader3.RepeatEveryPage = True
            '
            'GroupHeader1
            '
            Me.GroupHeader1.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label177, Me.Label60, Me.Label58, Me.Label66, Me.Label62, Me.Label64, Me.label3, Me.label4, Me.Label68, Me.Label70, Me.Label72, Me.Line57, Me.Label129})
            Me.GroupHeader1.Dpi = 100.0!
            Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader1.HeightF = 58.0!
            Me.GroupHeader1.Level = 2
            Me.GroupHeader1.Name = "GroupHeader1"
            Me.GroupHeader1.RepeatEveryPage = True
            '
            'Label177
            '
            Me.Label177.BackColor = System.Drawing.Color.Transparent
            Me.Label177.BorderColor = System.Drawing.Color.Black
            Me.Label177.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label177.BorderWidth = 1.0!
            Me.Label177.CanGrow = False
            Me.Label177.Dpi = 100.0!
            Me.Label177.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.Label177.ForeColor = System.Drawing.Color.Black
            Me.Label177.LocationFloat = New DevExpress.Utils.PointFloat(963.9999!, 28.99996!)
            Me.Label177.Name = "Label177"
            Me.Label177.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label177.SizeF = New System.Drawing.SizeF(44.0!, 19.00002!)
            Me.Label177.StylePriority.UseFont = False
            Me.Label177.Text = "Vendor"
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
            Me.Label60.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 10.00004!)
            Me.Label60.Name = "Label60"
            Me.Label60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label60.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label60.StylePriority.UseFont = False
            Me.Label60.Text = "Estimated Cost"
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
            Me.Label58.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 10.00013!)
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
            Me.Label66.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 10.0001!)
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
            Me.Label62.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 10.00004!)
            Me.Label62.Name = "Label62"
            Me.Label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label62.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label62.StylePriority.UseFont = False
            Me.Label62.Text = "Actual Costs"
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
            Me.Label64.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 0!)
            Me.Label64.Name = "Label64"
            Me.Label64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label64.SizeF = New System.Drawing.SizeF(63.0!, 48.00018!)
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
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 10.0001!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(52.58334!, 38.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Estimate Hrs/Qty"
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
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 28.99996!)
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
            Me.Label68.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 10.0001!)
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
            Me.Label70.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 9.999974!)
            Me.Label70.Name = "Label70"
            Me.Label70.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label70.SizeF = New System.Drawing.SizeF(63.0!, 38.0!)
            Me.Label70.StylePriority.UseFont = False
            Me.Label70.Text = "Open PO's"
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
            Me.Label72.LocationFloat = New DevExpress.Utils.PointFloat(698.1248!, 10.0001!)
            Me.Label72.Name = "Label72"
            Me.Label72.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label72.SizeF = New System.Drawing.SizeF(137.4583!, 37.99985!)
            Me.Label72.StylePriority.UseFont = False
            Me.Label72.Text = "Reconciled/Recognized Cost/OOP              GP"
            Me.Label72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'Line57
            '
            Me.Line57.BorderColor = System.Drawing.Color.Silver
            Me.Line57.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line57.BorderWidth = 4.0!
            Me.Line57.Dpi = 100.0!
            Me.Line57.ForeColor = System.Drawing.Color.Silver
            Me.Line57.LineWidth = 4
            Me.Line57.LocationFloat = New DevExpress.Utils.PointFloat(0!, 48.00018!)
            Me.Line57.Name = "Line57"
            Me.Line57.SizeF = New System.Drawing.SizeF(1008.0!, 9.999817!)
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
            Me.Label129.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 0!)
            Me.Label129.Name = "Label129"
            Me.Label129.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label129.SizeF = New System.Drawing.SizeF(63.0!, 47.99998!)
            Me.Label129.StylePriority.UseFont = False
            Me.Label129.Text = "Actual Balance To Reconcile"
            Me.Label129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooter2
            '
            Me.GroupFooter2.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreport3, Me.XrSubreport2, Me.XrLabel31, Me.XrLabel30, Me.XrLabel29, Me.XrLabel28, Me.XrLabel16, Me.XrLabel17, Me.XrLabel15, Me.XrLabel13, Me.XrLabel14, Me.Label100, Me.Text101, Me.JTotal, Me.JNBillable, Me.JBilled, Me.Text110, Me.Line130, Me.Text131, Me.XrSubreport1})
            Me.GroupFooter2.Dpi = 100.0!
            Me.GroupFooter2.HeightF = 128.5417!
            Me.GroupFooter2.Level = 3
            Me.GroupFooter2.Name = "GroupFooter2"
            Me.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'XrSubreport3
            '
            Me.XrSubreport3.Dpi = 100.0!
            Me.XrSubreport3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 81.12501!)
            Me.XrSubreport3.Name = "XrSubreport3"
            Me.XrSubreport3.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvancedBillingHistorySubReport()
            Me.XrSubreport3.SizeF = New System.Drawing.SizeF(519.5414!, 23.0!)
            '
            'XrSubreport2
            '
            Me.XrSubreport2.Dpi = 100.0!
            Me.XrSubreport2.LocationFloat = New DevExpress.Utils.PointFloat(582.5416!, 81.12501!)
            Me.XrSubreport2.Name = "XrSubreport2"
            Me.XrSubreport2.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.BillingHistorySubReport()
            Me.XrSubreport2.SizeF = New System.Drawing.SizeF(412.9998!, 23.0!)
            '
            'XrLabel31
            '
            Me.XrLabel31.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel31.BorderColor = System.Drawing.Color.Black
            Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel31.BorderWidth = 1.0!
            Me.XrLabel31.CanGrow = False
            Me.XrLabel31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField3")})
            Me.XrLabel31.Dpi = 100.0!
            Me.XrLabel31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 58.33333!)
            Me.XrLabel31.Name = "XrLabel31"
            Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel31.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel31.StylePriority.UseFont = False
            XrSummary18.FormatString = "{0:n2}"
            XrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel31.Summary = XrSummary18
            Me.XrLabel31.Text = "XrLabel31"
            Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel30
            '
            Me.XrLabel30.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel30.BorderColor = System.Drawing.Color.Black
            Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel30.BorderWidth = 1.0!
            Me.XrLabel30.CanGrow = False
            Me.XrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.XrLabel30.Dpi = 100.0!
            Me.XrLabel30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 39.33334!)
            Me.XrLabel30.Name = "XrLabel30"
            Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel30.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel30.StylePriority.UseFont = False
            XrSummary19.FormatString = "{0:n2}"
            XrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel30.Summary = XrSummary19
            Me.XrLabel30.Text = "XrLabel30"
            Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel29
            '
            Me.XrLabel29.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel29.BorderColor = System.Drawing.Color.Black
            Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel29.BorderWidth = 1.0!
            Me.XrLabel29.CanGrow = False
            Me.XrLabel29.Dpi = 100.0!
            Me.XrLabel29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel29.ForeColor = System.Drawing.Color.Black
            Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 58.33333!)
            Me.XrLabel29.Name = "XrLabel29"
            Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel29.SizeF = New System.Drawing.SizeF(254.3748!, 18.99999!)
            Me.XrLabel29.StylePriority.UseFont = False
            Me.XrLabel29.Text = "Remaining to be invoiced to Client:"
            Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 39.33334!)
            Me.XrLabel28.Name = "XrLabel28"
            Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel28.SizeF = New System.Drawing.SizeF(254.3748!, 18.99999!)
            Me.XrLabel28.StylePriority.UseFont = False
            Me.XrLabel28.Text = "Invoiced to Client:"
            Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 9.999974!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel16.StylePriority.UseFont = False
            XrSummary20.FormatString = "{0:n2}"
            XrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel16.Summary = XrSummary20
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
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 9.999974!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel17.StylePriority.UseFont = False
            XrSummary21.FormatString = "{0:n2}"
            XrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel17.Summary = XrSummary21
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
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 9.999974!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel15.StylePriority.UseFont = False
            XrSummary22.FormatString = "{0:n2}"
            XrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel15.Summary = XrSummary22
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
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 9.999974!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel13.StylePriority.UseFont = False
            XrSummary23.FormatString = "{0:n2}"
            XrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel13.Summary = XrSummary23
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
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField6")})
            Me.XrLabel14.Dpi = 100.0!
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 9.999974!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel14.StylePriority.UseFont = False
            XrSummary24.FormatString = "{0:n2}"
            XrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel14.Summary = XrSummary24
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
            Me.Label100.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 10.00004!)
            Me.Label100.Name = "Label100"
            Me.Label100.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label100.SizeF = New System.Drawing.SizeF(254.3748!, 18.99999!)
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
            Me.Text101.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 9.999974!)
            Me.Text101.Name = "Text101"
            Me.Text101.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text101.SizeF = New System.Drawing.SizeF(52.58337!, 19.0!)
            Me.Text101.StylePriority.UseFont = False
            XrSummary25.FormatString = "{0:n2}"
            XrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text101.Summary = XrSummary25
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
            Me.JTotal.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 9.999974!)
            Me.JTotal.Name = "JTotal"
            Me.JTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JTotal.StylePriority.UseFont = False
            XrSummary26.FormatString = "{0:n2}"
            XrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JTotal.Summary = XrSummary26
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
            Me.JNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.JNBillable.Dpi = 100.0!
            Me.JNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JNBillable.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 9.999974!)
            Me.JNBillable.Name = "JNBillable"
            Me.JNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.JNBillable.StylePriority.UseFont = False
            XrSummary27.FormatString = "{0:n2}"
            XrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JNBillable.Summary = XrSummary27
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
            Me.JBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField7")})
            Me.JBilled.Dpi = 100.0!
            Me.JBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.JBilled.LocationFloat = New DevExpress.Utils.PointFloat(698.1248!, 9.999974!)
            Me.JBilled.Name = "JBilled"
            Me.JBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.JBilled.SizeF = New System.Drawing.SizeF(74.45837!, 19.0!)
            Me.JBilled.StylePriority.UseFont = False
            XrSummary28.FormatString = "{0:n2}"
            XrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.JBilled.Summary = XrSummary28
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
            Me.Text110.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.Text110.Dpi = 100.0!
            Me.Text110.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text110.LocationFloat = New DevExpress.Utils.PointFloat(772.5831!, 9.999974!)
            Me.Text110.Name = "Text110"
            Me.Text110.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text110.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text110.StylePriority.UseFont = False
            XrSummary29.FormatString = "{0:n2}"
            XrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text110.Summary = XrSummary29
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
            Me.Line130.SizeF = New System.Drawing.SizeF(1008.0!, 2.083333!)
            '
            'Text131
            '
            Me.Text131.BackColor = System.Drawing.Color.Transparent
            Me.Text131.BorderColor = System.Drawing.Color.Black
            Me.Text131.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text131.BorderWidth = 1.0!
            Me.Text131.CanGrow = False
            Me.Text131.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField2")})
            Me.Text131.Dpi = 100.0!
            Me.Text131.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text131.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 9.999974!)
            Me.Text131.Name = "Text131"
            Me.Text131.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text131.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text131.StylePriority.UseFont = False
            XrSummary30.FormatString = "{0:n2}"
            XrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text131.Summary = XrSummary30
            Me.Text131.Text = "Text131"
            Me.Text131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrSubreport1
            '
            Me.XrSubreport1.Dpi = 100.0!
            Me.XrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(0.000166893!, 104.125!)
            Me.XrSubreport1.Name = "XrSubreport1"
            Me.XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvanceReconciliationHistorySubReport()
            Me.XrSubreport1.SizeF = New System.Drawing.SizeF(519.5412!, 23.0!)
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
            Me.Text134.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimateHours")})
            Me.Text134.Dpi = 100.0!
            Me.Text134.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text134.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 11.0!)
            Me.Text134.Name = "Text134"
            Me.Text134.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text134.SizeF = New System.Drawing.SizeF(52.58337!, 19.0!)
            Me.Text134.StylePriority.UseFont = False
            XrSummary31.FormatString = "{0:n2}"
            XrSummary31.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text134.Summary = XrSummary31
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
            Me.FTTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledField")})
            Me.FTTotal.Dpi = 100.0!
            Me.FTTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTTotal.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 9.999974!)
            Me.FTTotal.Name = "FTTotal"
            Me.FTTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTTotal.StylePriority.UseFont = False
            XrSummary32.FormatString = "{0:n2}"
            XrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTTotal.Summary = XrSummary32
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
            Me.FTNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.FTNBillable.Dpi = 100.0!
            Me.FTNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTNBillable.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 9.999974!)
            Me.FTNBillable.Name = "FTNBillable"
            Me.FTNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTNBillable.StylePriority.UseFont = False
            XrSummary33.FormatString = "{0:n2}"
            XrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTNBillable.Summary = XrSummary33
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
            Me.FTBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField7")})
            Me.FTBilled.Dpi = 100.0!
            Me.FTBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTBilled.LocationFloat = New DevExpress.Utils.PointFloat(698.1248!, 9.999974!)
            Me.FTBilled.Name = "FTBilled"
            Me.FTBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTBilled.SizeF = New System.Drawing.SizeF(73.4588!, 19.0!)
            Me.FTBilled.StylePriority.UseFont = False
            XrSummary34.FormatString = "{0:n2}"
            XrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTBilled.Summary = XrSummary34
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
            Me.Text142.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.Text142.Dpi = 100.0!
            Me.Text142.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text142.LocationFloat = New DevExpress.Utils.PointFloat(772.5831!, 9.999974!)
            Me.Text142.Name = "Text142"
            Me.Text142.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text142.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text142.StylePriority.UseFont = False
            XrSummary35.FormatString = "{0:n2}"
            XrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text142.Summary = XrSummary35
            Me.Text142.Text = "Text142"
            Me.Text142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text144
            '
            Me.Text144.BackColor = System.Drawing.Color.Transparent
            Me.Text144.BorderColor = System.Drawing.Color.Black
            Me.Text144.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text144.BorderWidth = 1.0!
            Me.Text144.CanGrow = False
            Me.Text144.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField2")})
            Me.Text144.Dpi = 100.0!
            Me.Text144.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text144.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 9.999974!)
            Me.Text144.Name = "Text144"
            Me.Text144.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text144.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text144.StylePriority.UseFont = False
            XrSummary36.FormatString = "{0:n2}"
            XrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text144.Summary = XrSummary36
            Me.Text144.Text = "Text144"
            Me.Text144.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Type
            '
            Me.Type.BackColor = System.Drawing.Color.Transparent
            Me.Type.BorderColor = System.Drawing.Color.Black
            Me.Type.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Type.BorderWidth = 1.0!
            Me.Type.CanGrow = False
            Me.Type.Dpi = 100.0!
            Me.Type.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Type.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00004!)
            Me.Type.Name = "Type"
            Me.Type.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Type.SizeF = New System.Drawing.SizeF(254.3749!, 19.0!)
            Me.Type.StylePriority.UseFont = False
            XrSummary37.FormatString = "{0}"
            Me.Type.Summary = XrSummary37
            Me.Type.Text = "Total:"
            Me.Type.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6, Me.XrLabel7, Me.XrLabel5, Me.XrLabel3, Me.XrLabel4, Me.Text77, Me.Text79, Me.FTotal, Me.FNBillable, Me.FBilled, Me.Text88, Me.FUNC})
            Me.GroupFooter0.Dpi = 100.0!
            Me.GroupFooter0.HeightF = 21.0!
            Me.GroupFooter0.Name = "GroupFooter0"
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
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            XrSummary38.FormatString = "{0:n2}"
            XrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel6.Summary = XrSummary38
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
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            XrSummary39.FormatString = "{0:n2}"
            XrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel7.Summary = XrSummary39
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
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 0!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            XrSummary40.FormatString = "{0:n2}"
            XrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel5.Summary = XrSummary40
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
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            XrSummary41.FormatString = "{0:n2}"
            XrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel3.Summary = XrSummary41
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
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField6")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            XrSummary42.FormatString = "{0:n2}"
            XrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel4.Summary = XrSummary42
            Me.XrLabel4.Text = "XrLabel4"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text77
            '
            Me.Text77.BackColor = System.Drawing.Color.Transparent
            Me.Text77.BorderColor = System.Drawing.Color.Black
            Me.Text77.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text77.BorderWidth = 1.0!
            Me.Text77.CanGrow = False
            Me.Text77.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField2")})
            Me.Text77.Dpi = 100.0!
            Me.Text77.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text77.LocationFloat = New DevExpress.Utils.PointFloat(898.5831!, 0!)
            Me.Text77.Name = "Text77"
            Me.Text77.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text77.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text77.StylePriority.UseFont = False
            XrSummary43.FormatString = "{0:n2}"
            XrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text77.Summary = XrSummary43
            Me.Text77.Text = "Text77"
            Me.Text77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.Text79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text79.LocationFloat = New DevExpress.Utils.PointFloat(267.5414!, 0!)
            Me.Text79.Name = "Text79"
            Me.Text79.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text79.SizeF = New System.Drawing.SizeF(52.58334!, 19.0!)
            Me.Text79.StylePriority.UseFont = False
            XrSummary44.FormatString = "{0:n2}"
            XrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text79.Summary = XrSummary44
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
            Me.FTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTotal.LocationFloat = New DevExpress.Utils.PointFloat(635.1248!, 0!)
            Me.FTotal.Name = "FTotal"
            Me.FTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTotal.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FTotal.StylePriority.UseFont = False
            XrSummary45.FormatString = "{0:n2}"
            XrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTotal.Summary = XrSummary45
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
            Me.FNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfOpenPOAmount")})
            Me.FNBillable.Dpi = 100.0!
            Me.FNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FNBillable.LocationFloat = New DevExpress.Utils.PointFloat(835.5831!, 0!)
            Me.FNBillable.Name = "FNBillable"
            Me.FNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FNBillable.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.FNBillable.StylePriority.UseFont = False
            XrSummary46.FormatString = "{0:n2}"
            XrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FNBillable.Summary = XrSummary46
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
            Me.FBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField7")})
            Me.FBilled.Dpi = 100.0!
            Me.FBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FBilled.LocationFloat = New DevExpress.Utils.PointFloat(698.1248!, 0!)
            Me.FBilled.Name = "FBilled"
            Me.FBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FBilled.SizeF = New System.Drawing.SizeF(73.45856!, 19.0!)
            Me.FBilled.StylePriority.UseFont = False
            XrSummary47.FormatString = "{0:n2}"
            XrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FBilled.Summary = XrSummary47
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
            Me.Text88.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField4")})
            Me.Text88.Dpi = 100.0!
            Me.Text88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text88.LocationFloat = New DevExpress.Utils.PointFloat(772.5831!, 0!)
            Me.Text88.Name = "Text88"
            Me.Text88.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text88.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.Text88.StylePriority.UseFont = False
            XrSummary48.FormatString = "{0:n2}"
            XrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text88.Summary = XrSummary48
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
            'GroupFooter4
            '
            Me.GroupFooter4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.XrLabel12, Me.XrLabel10, Me.XrLabel8, Me.XrLabel9, Me.Type, Me.Text144, Me.Text142, Me.FTBilled, Me.FTNBillable, Me.FTTotal, Me.Text134})
            Me.GroupFooter4.Dpi = 100.0!
            Me.GroupFooter4.HeightF = 40.0!
            Me.GroupFooter4.Level = 1
            Me.GroupFooter4.Name = "GroupFooter4"
            '
            'XrLabel11
            '
            Me.XrLabel11.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel11.BorderColor = System.Drawing.Color.Black
            Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel11.BorderWidth = 1.0!
            Me.XrLabel11.CanGrow = False
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Variance")})
            Me.XrLabel11.Dpi = 100.0!
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(509.1248!, 9.999974!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel11.StylePriority.UseFont = False
            XrSummary49.FormatString = "{0:n2}"
            XrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel11.Summary = XrSummary49
            Me.XrLabel11.Text = "XrLabel11"
            Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel12
            '
            Me.XrLabel12.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel12.BorderColor = System.Drawing.Color.Black
            Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel12.BorderWidth = 1.0!
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfResaleTax")})
            Me.XrLabel12.Dpi = 100.0!
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(572.1248!, 9.999974!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            XrSummary50.FormatString = "{0:n2}"
            XrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel12.Summary = XrSummary50
            Me.XrLabel12.Text = "FTAX"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1.0!
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualAmount")})
            Me.XrLabel10.Dpi = 100.0!
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(446.1248!, 9.999974!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            XrSummary51.FormatString = "{0:n2}"
            XrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel10.Summary = XrSummary51
            Me.XrLabel10.Text = "XrLabel10"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel8.BorderColor = System.Drawing.Color.Black
            Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel8.BorderWidth = 1.0!
            Me.XrLabel8.CanGrow = False
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualHours")})
            Me.XrLabel8.Dpi = 100.0!
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(320.1248!, 9.999974!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel8.StylePriority.UseFont = False
            XrSummary52.FormatString = "{0:n2}"
            XrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel8.Summary = XrSummary52
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
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedField6")})
            Me.XrLabel9.Dpi = 100.0!
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(383.1248!, 9.999974!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(63.0!, 19.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            XrSummary53.FormatString = "{0:n2}"
            XrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel9.Summary = XrSummary53
            Me.XrLabel9.Text = "XrLabel9"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Dpi = 100.0!
            Me.GroupHeader2.HeightF = 0!
            Me.GroupHeader2.Level = 1
            Me.GroupHeader2.Name = "GroupHeader2"
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
            'CalculatedField1
            '
            Me.CalculatedField1.DisplayName = "BillingToDate"
            Me.CalculatedField1.Name = "CalculatedField1"
            '
            'CalculatedField2
            '
            Me.CalculatedField2.DisplayName = "ActualBalance"
            Me.CalculatedField2.Expression = "([SumOfLineTotal] - [SumOfResaleTax]) - ([SumOfBilledAmount] - [SumOfResaleBilled" &
    "] + [SumOfAdvanceResaleBilled])"
            Me.CalculatedField2.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField2.Name = "CalculatedField2"
            '
            'CalculatedField3
            '
            Me.CalculatedField3.DisplayName = "Remaining"
            Me.CalculatedField3.Expression = "([SumOfEstimate] - [SumOfEstimateCont]) - ([SumOfBilledAmount] + [SumOfAdvanceBil" &
    "led] + [SumOfAdvanceResaleBilled])"
            Me.CalculatedField3.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField3.Name = "CalculatedField3"
            '
            'CalculatedField4
            '
            Me.CalculatedField4.DisplayName = "Recognized"
            Me.CalculatedField4.Expression = "Iif([AdvanceBillFlag] in (2,4,6),(([SumOfBilledAmount])  - [SumOfBilledCost]),(([" &
    "SumOfBilledAmount] + [SumOfAdvanceBilled] + [SumOfAdvanceResaleBilled]) - [SumOf" &
    "ResaleBilled]  - [SumOfBilledCost]) )"
            Me.CalculatedField4.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField4.Name = "CalculatedField4"
            '
            'CalculatedField5
            '
            Me.CalculatedField5.DisplayName = "EstimateHours"
            Me.CalculatedField5.Expression = "[SumOfEstimateHours]"
            Me.CalculatedField5.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField5.Name = "CalculatedField5"
            '
            'CalculatedField6
            '
            Me.CalculatedField6.DisplayName = "EstimatedCost"
            Me.CalculatedField6.Expression = "[SumOfEstimate] - [SumOfEstimateCont] - [SumOfEstimateResaleTax]"
            Me.CalculatedField6.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField6.Name = "CalculatedField6"
            '
            'CalculatedField7
            '
            Me.CalculatedField7.DisplayName = "NetCOST"
            Me.CalculatedField7.Expression = "[SumOfAPNetCost] + [SumOfVenTax]"
            Me.CalculatedField7.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CalculatedField7.Name = "CalculatedField7"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.JobDetailAnalysis)
            '
            'AdvancedBillingHistorySubReport1
            '
            Me.AdvancedBillingHistorySubReport1.Dpi = 100.0!
            Me.AdvancedBillingHistorySubReport1.FilterString = "[JobNumber] = ?JobNumb And [JobComponentNumber] = ?JobComponentNumb"
            Me.AdvancedBillingHistorySubReport1.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.AdvancedBillingHistorySubReport1.Name = "AdvancedBillingHistorySubReport1"
            Me.AdvancedBillingHistorySubReport1.PageHeight = 1190
            Me.AdvancedBillingHistorySubReport1.PageWidth = 850
            Me.AdvancedBillingHistorySubReport1.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.AdvancedBillingHistorySubReport1.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.AdvancedBillingHistorySubReport1.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.AdvancedBillingHistorySubReport1.Version = "16.1"
            '
            'BillingHistorySubReport1
            '
            Me.BillingHistorySubReport1.Dpi = 100.0!
            Me.BillingHistorySubReport1.FilterString = "[JobNumber] = ?JobNumb And [JobComponentNumber] = ?JobComponentNumb"
            Me.BillingHistorySubReport1.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.BillingHistorySubReport1.Name = "BillingHistorySubReport1"
            Me.BillingHistorySubReport1.PageHeight = 1190
            Me.BillingHistorySubReport1.PageWidth = 850
            Me.BillingHistorySubReport1.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.BillingHistorySubReport1.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.BillingHistorySubReport1.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.BillingHistorySubReport1.Version = "16.1"
            '
            'AdvanceReconciliationHistorySubReport1
            '
            Me.AdvanceReconciliationHistorySubReport1.Dpi = 100.0!
            Me.AdvanceReconciliationHistorySubReport1.FilterString = "[JobNumber] = ?JobNumb And [JobComponentNumber] = ?JobComponentNumb"
            Me.AdvanceReconciliationHistorySubReport1.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.AdvanceReconciliationHistorySubReport1.Name = "AdvanceReconciliationHistorySubReport1"
            Me.AdvanceReconciliationHistorySubReport1.PageHeight = 1190
            Me.AdvanceReconciliationHistorySubReport1.PageWidth = 850
            Me.AdvanceReconciliationHistorySubReport1.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.AdvanceReconciliationHistorySubReport1.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.AdvanceReconciliationHistorySubReport1.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.AdvanceReconciliationHistorySubReport1.Version = "16.1"
            '
            'pageInfo2
            '
            Me.pageInfo2.Dpi = 100.0!
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pageInfo2.Format = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0.000166893!, 4.000028!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(353.125!, 20.99995!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SummaryByFunctionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.GroupHeaderForm_CDP, Me.GroupFooter1, Me.GroupHeader3, Me.GroupHeader1, Me.GroupFooter2, Me.GroupHeaderFunction, Me.GroupFooter3, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupFooter4, Me.GroupHeader2})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientFull, Me.DivisionFull, Me.ProductFull, Me.JobFull, Me.JobComponentFull, Me.AdvanceFlag, Me.BillableStatus, Me.HoldStatus, Me.ProcessDescription, Me.AccountExecutiveFull, Me.FunctionFull, Me.FunctionTypeTotal, Me.BilledField, Me.Unbilled, Me.TodaysDate, Me.ActualHours, Me.ActualAmount, Me.Variance, Me.CalculatedField1, Me.CalculatedField2, Me.CalculatedField3, Me.CalculatedField4, Me.CalculatedField5, Me.CalculatedField6, Me.CalculatedField7})
            Me.DataSource = Me.BindingSource
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 42, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.SnapGridSize = 1.0!
            Me.Version = "16.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AdvancedBillingHistorySubReport1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BillingHistorySubReport1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AdvanceReconciliationHistorySubReport1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Public WithEvents XrSubreport2 As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ActualHours As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ActualAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Variance As DevExpress.XtraReports.UI.CalculatedField
        Public WithEvents XrSubreport3 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents AdvancedBillingHistorySubReport1 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvancedBillingHistorySubReport
        Friend WithEvents BillingHistorySubReport1 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.BillingHistorySubReport
        Friend WithEvents AdvanceReconciliationHistorySubReport1 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.AdvanceReconciliationHistorySubReport
        Friend WithEvents CalculatedField1 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField2 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField3 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField4 As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedField5 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField6 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField7 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    End Class

End Namespace






