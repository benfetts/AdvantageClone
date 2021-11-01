Namespace JobAnalysisDetail.Version6

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
        Private GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private label3 As DevExpress.XtraReports.UI.XRLabel
        Private Label68 As DevExpress.XtraReports.UI.XRLabel
        Private Label72 As DevExpress.XtraReports.UI.XRLabel
        Private Label74 As DevExpress.XtraReports.UI.XRLabel
        Private Line57 As DevExpress.XtraReports.UI.XRLine
        Private Label129 As DevExpress.XtraReports.UI.XRLabel
        Private GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
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
        Friend WithEvents NetCost As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledField As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Unbilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TodaysDate As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents Label60 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label58 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label62 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label64 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel53 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel54 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel55 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel56 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel57 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel58 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel59 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel60 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel61 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel63 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel64 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_SortBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LineBottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.Line26 = New DevExpress.XtraReports.UI.XRLine()
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
            Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label60 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label58 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label64 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label68 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label72 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label74 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line57 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label129 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupFooter0 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.FUNC = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.EstimateEmployeeTime = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EmployeeTimePriorMonthsActuals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeTimeCurrentMonthActuals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeTimePriorMonthsBilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeTimeCurrentMonthBilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EstimateEmployeIncomeOnly = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeIncomeOnlyPriorMonthsActuals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeIncomeOnlyCurrentMonthActuals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeIncomeOnlyPriorMonthsBilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeIncomeOnlyCurrentMonthBilled = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EstimateTotals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ActualTotals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledTotals = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel65 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel66 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel67 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel68 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel69 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel70 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel71 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel72 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel73 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel74 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel75 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel76 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel77 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel78 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel79 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel80 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel81 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel51, Me.XrLabel52, Me.XrLabel53, Me.XrLabel54, Me.XrLabel55, Me.XrLabel56, Me.XrLabel57, Me.XrLabel58, Me.XrLabel59, Me.XrLabel60, Me.XrLabel61, Me.XrLabel62, Me.XrLabel63, Me.XrLabel64, Me.XrLabel30, Me.XrLine1, Me.XrLabel31, Me.XrLabel32, Me.XrLabel33, Me.XrLabel34, Me.XrLabel35, Me.XrLabel36, Me.XrLabel37, Me.XrLabel38, Me.XrLabel39, Me.XrLabel40, Me.XrLabel41, Me.XrLabel42, Me.XrLabel43, Me.XrLabel44, Me.XrLabel45, Me.XrLabel46, Me.XrLabel47, Me.XrLabel48, Me.XrLabel49, Me.XrLabel50, Me.XrLabel29})
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 136.4583!
            Me.ReportFooter.KeepTogether = True
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabel51
            '
            Me.XrLabel51.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel51.BorderColor = System.Drawing.Color.Black
            Me.XrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel51.BorderWidth = 1.0!
            Me.XrLabel51.CanGrow = False
            Me.XrLabel51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Unbilled")})
            Me.XrLabel51.Dpi = 100.0!
            Me.XrLabel51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(975.6799!, 112.0!)
            Me.XrLabel51.Name = "XrLabel51"
            Me.XrLabel51.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel51.SizeF = New System.Drawing.SizeF(75.0!, 19.0!)
            Me.XrLabel51.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel51.Summary = XrSummary1
            Me.XrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel52
            '
            Me.XrLabel52.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel52.BorderColor = System.Drawing.Color.Black
            Me.XrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel52.BorderWidth = 1.0!
            Me.XrLabel52.CanGrow = False
            Me.XrLabel52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualTotals")})
            Me.XrLabel52.Dpi = 100.0!
            Me.XrLabel52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(825.417!, 112.0!)
            Me.XrLabel52.Name = "XrLabel52"
            Me.XrLabel52.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel52.SizeF = New System.Drawing.SizeF(75.26337!, 19.0!)
            Me.XrLabel52.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel52.Summary = XrSummary2
            Me.XrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel53
            '
            Me.XrLabel53.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel53.BorderColor = System.Drawing.Color.Black
            Me.XrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel53.BorderWidth = 1.0!
            Me.XrLabel53.CanGrow = False
            Me.XrLabel53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotals")})
            Me.XrLabel53.Dpi = 100.0!
            Me.XrLabel53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel53.LocationFloat = New DevExpress.Utils.PointFloat(900.6801!, 112.0!)
            Me.XrLabel53.Name = "XrLabel53"
            Me.XrLabel53.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel53.SizeF = New System.Drawing.SizeF(75.0!, 19.0!)
            Me.XrLabel53.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel53.Summary = XrSummary3
            Me.XrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel54
            '
            Me.XrLabel54.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel54.BorderColor = System.Drawing.Color.Black
            Me.XrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel54.BorderWidth = 1.0!
            Me.XrLabel54.CanGrow = False
            Me.XrLabel54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.XrLabel54.Dpi = 100.0!
            Me.XrLabel54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel54.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 112.0!)
            Me.XrLabel54.Name = "XrLabel54"
            Me.XrLabel54.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel54.SizeF = New System.Drawing.SizeF(73.41669!, 19.0!)
            Me.XrLabel54.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel54.Summary = XrSummary4
            Me.XrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel55
            '
            Me.XrLabel55.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel55.BorderColor = System.Drawing.Color.Black
            Me.XrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel55.BorderWidth = 1.0!
            Me.XrLabel55.CanGrow = False
            Me.XrLabel55.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthBilled")})
            Me.XrLabel55.Dpi = 100.0!
            Me.XrLabel55.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel55.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 112.0!)
            Me.XrLabel55.Name = "XrLabel55"
            Me.XrLabel55.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel55.SizeF = New System.Drawing.SizeF(74.00024!, 19.00001!)
            Me.XrLabel55.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel55.Summary = XrSummary5
            Me.XrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel56
            '
            Me.XrLabel56.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel56.BorderColor = System.Drawing.Color.Black
            Me.XrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel56.BorderWidth = 1.0!
            Me.XrLabel56.CanGrow = False
            Me.XrLabel56.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeeTime")})
            Me.XrLabel56.Dpi = 100.0!
            Me.XrLabel56.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel56.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 112.0!)
            Me.XrLabel56.Name = "XrLabel56"
            Me.XrLabel56.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel56.SizeF = New System.Drawing.SizeF(74.45834!, 19.0!)
            Me.XrLabel56.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel56.Summary = XrSummary6
            Me.XrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel57
            '
            Me.XrLabel57.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel57.BorderColor = System.Drawing.Color.Black
            Me.XrLabel57.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel57.BorderWidth = 1.0!
            Me.XrLabel57.CanGrow = False
            Me.XrLabel57.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeIncomeOnly")})
            Me.XrLabel57.Dpi = 100.0!
            Me.XrLabel57.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel57.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 112.0!)
            Me.XrLabel57.Name = "XrLabel57"
            Me.XrLabel57.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel57.SizeF = New System.Drawing.SizeF(74.0!, 19.00001!)
            Me.XrLabel57.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel57.Summary = XrSummary7
            Me.XrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel58
            '
            Me.XrLabel58.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel58.BorderColor = System.Drawing.Color.Black
            Me.XrLabel58.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel58.BorderWidth = 1.0!
            Me.XrLabel58.CanGrow = False
            Me.XrLabel58.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthBilled")})
            Me.XrLabel58.Dpi = 100.0!
            Me.XrLabel58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel58.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 112.0!)
            Me.XrLabel58.Name = "XrLabel58"
            Me.XrLabel58.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel58.SizeF = New System.Drawing.SizeF(74.00003!, 19.00001!)
            Me.XrLabel58.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel58.Summary = XrSummary8
            Me.XrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel59
            '
            Me.XrLabel59.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel59.BorderColor = System.Drawing.Color.Black
            Me.XrLabel59.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel59.BorderWidth = 1.0!
            Me.XrLabel59.CanGrow = False
            Me.XrLabel59.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsActuals")})
            Me.XrLabel59.Dpi = 100.0!
            Me.XrLabel59.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel59.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 112.0!)
            Me.XrLabel59.Name = "XrLabel59"
            Me.XrLabel59.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel59.SizeF = New System.Drawing.SizeF(73.99997!, 19.00001!)
            Me.XrLabel59.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel59.Summary = XrSummary9
            Me.XrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel60
            '
            Me.XrLabel60.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel60.BorderColor = System.Drawing.Color.Black
            Me.XrLabel60.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel60.BorderWidth = 1.0!
            Me.XrLabel60.CanGrow = False
            Me.XrLabel60.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsBilled")})
            Me.XrLabel60.Dpi = 100.0!
            Me.XrLabel60.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel60.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 112.0!)
            Me.XrLabel60.Name = "XrLabel60"
            Me.XrLabel60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel60.SizeF = New System.Drawing.SizeF(73.99994!, 19.00001!)
            Me.XrLabel60.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel60.Summary = XrSummary10
            Me.XrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel61
            '
            Me.XrLabel61.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel61.BorderColor = System.Drawing.Color.Black
            Me.XrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel61.BorderWidth = 1.0!
            Me.XrLabel61.CanGrow = False
            Me.XrLabel61.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthActuals")})
            Me.XrLabel61.Dpi = 100.0!
            Me.XrLabel61.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel61.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 112.0!)
            Me.XrLabel61.Name = "XrLabel61"
            Me.XrLabel61.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel61.SizeF = New System.Drawing.SizeF(75.54187!, 19.00001!)
            Me.XrLabel61.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel61.Summary = XrSummary11
            Me.XrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel62
            '
            Me.XrLabel62.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel62.BorderColor = System.Drawing.Color.Black
            Me.XrLabel62.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel62.BorderWidth = 1.0!
            Me.XrLabel62.CanGrow = False
            Me.XrLabel62.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsActuals")})
            Me.XrLabel62.Dpi = 100.0!
            Me.XrLabel62.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel62.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 112.0!)
            Me.XrLabel62.Name = "XrLabel62"
            Me.XrLabel62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel62.SizeF = New System.Drawing.SizeF(74.00003!, 19.00001!)
            Me.XrLabel62.StylePriority.UseFont = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel62.Summary = XrSummary12
            Me.XrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel63
            '
            Me.XrLabel63.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel63.BorderColor = System.Drawing.Color.Black
            Me.XrLabel63.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel63.BorderWidth = 1.0!
            Me.XrLabel63.CanGrow = False
            Me.XrLabel63.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthActuals")})
            Me.XrLabel63.Dpi = 100.0!
            Me.XrLabel63.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel63.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 112.0!)
            Me.XrLabel63.Name = "XrLabel63"
            Me.XrLabel63.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel63.SizeF = New System.Drawing.SizeF(73.99998!, 19.00001!)
            Me.XrLabel63.StylePriority.UseFont = False
            XrSummary13.FormatString = "{0:n2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel63.Summary = XrSummary13
            Me.XrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel64
            '
            Me.XrLabel64.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel64.BorderColor = System.Drawing.Color.Black
            Me.XrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel64.BorderWidth = 1.0!
            Me.XrLabel64.CanGrow = False
            Me.XrLabel64.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsBilled")})
            Me.XrLabel64.Dpi = 100.0!
            Me.XrLabel64.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel64.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 112.0!)
            Me.XrLabel64.Name = "XrLabel64"
            Me.XrLabel64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel64.SizeF = New System.Drawing.SizeF(74.0!, 19.00001!)
            Me.XrLabel64.StylePriority.UseFont = False
            XrSummary14.FormatString = "{0:n2}"
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel64.Summary = XrSummary14
            Me.XrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel30
            '
            Me.XrLabel30.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel30.BorderColor = System.Drawing.Color.Black
            Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel30.BorderWidth = 1.0!
            Me.XrLabel30.CanGrow = False
            Me.XrLabel30.Dpi = 100.0!
            Me.XrLabel30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel30.ForeColor = System.Drawing.Color.Black
            Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(975.6799!, 83.58339!)
            Me.XrLabel30.Name = "XrLabel30"
            Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel30.SizeF = New System.Drawing.SizeF(75.0!, 21.00001!)
            Me.XrLabel30.StylePriority.UseFont = False
            Me.XrLabel30.Text = "Unbilled" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 104.5834!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(1050.68!, 4.0!)
            '
            'XrLabel31
            '
            Me.XrLabel31.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel31.BorderColor = System.Drawing.Color.Black
            Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel31.BorderWidth = 1.0!
            Me.XrLabel31.CanGrow = False
            Me.XrLabel31.Dpi = 100.0!
            Me.XrLabel31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel31.ForeColor = System.Drawing.Color.Black
            Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(825.4169!, 83.58339!)
            Me.XrLabel31.Name = "XrLabel31"
            Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel31.SizeF = New System.Drawing.SizeF(75.26349!, 21.00001!)
            Me.XrLabel31.StylePriority.UseFont = False
            Me.XrLabel31.Text = "Actual"
            Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel32
            '
            Me.XrLabel32.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel32.BorderColor = System.Drawing.Color.Black
            Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel32.BorderWidth = 1.0!
            Me.XrLabel32.CanGrow = False
            Me.XrLabel32.Dpi = 100.0!
            Me.XrLabel32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel32.ForeColor = System.Drawing.Color.Black
            Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(900.6804!, 83.58339!)
            Me.XrLabel32.Name = "XrLabel32"
            Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel32.SizeF = New System.Drawing.SizeF(75.0!, 21.0!)
            Me.XrLabel32.StylePriority.UseFont = False
            Me.XrLabel32.Text = "Billed"
            Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 83.58339!)
            Me.XrLabel33.Name = "XrLabel33"
            Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel33.SizeF = New System.Drawing.SizeF(73.41669!, 21.00001!)
            Me.XrLabel33.StylePriority.UseFont = False
            Me.XrLabel33.Text = "Estimate"
            Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(9.999919!, 66.58338!)
            Me.XrLabel34.Name = "XrLabel34"
            Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel34.SizeF = New System.Drawing.SizeF(74.45834!, 38.0!)
            Me.XrLabel34.StylePriority.UseFont = False
            Me.XrLabel34.Text = "Estimate w/Cont."
            Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 66.58338!)
            Me.XrLabel35.Name = "XrLabel35"
            Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel35.SizeF = New System.Drawing.SizeF(74.00003!, 38.00001!)
            Me.XrLabel35.StylePriority.UseFont = False
            Me.XrLabel35.Text = "Current Month"
            Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel36
            '
            Me.XrLabel36.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel36.BorderColor = System.Drawing.Color.Black
            Me.XrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel36.BorderWidth = 1.0!
            Me.XrLabel36.CanGrow = False
            Me.XrLabel36.Dpi = 100.0!
            Me.XrLabel36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel36.ForeColor = System.Drawing.Color.Black
            Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 66.58344!)
            Me.XrLabel36.Name = "XrLabel36"
            Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel36.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.XrLabel36.StylePriority.UseFont = False
            Me.XrLabel36.Text = "Prior Months"
            Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 66.58338!)
            Me.XrLabel37.Name = "XrLabel37"
            Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel37.SizeF = New System.Drawing.SizeF(73.99998!, 37.99999!)
            Me.XrLabel37.StylePriority.UseFont = False
            Me.XrLabel37.Text = "Prior Months"
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
            Me.XrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 66.58338!)
            Me.XrLabel38.Name = "XrLabel38"
            Me.XrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel38.SizeF = New System.Drawing.SizeF(73.99997!, 37.99999!)
            Me.XrLabel38.StylePriority.UseFont = False
            Me.XrLabel38.Text = "Current Month"
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
            Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(9.999871!, 26.00002!)
            Me.XrLabel39.Name = "XrLabel39"
            Me.XrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel39.SizeF = New System.Drawing.SizeF(370.4585!, 20.29167!)
            Me.XrLabel39.StylePriority.UseFont = False
            Me.XrLabel39.Text = "------------------------------ Employee Time ------------------------------"
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
            Me.XrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 66.58338!)
            Me.XrLabel40.Name = "XrLabel40"
            Me.XrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel40.SizeF = New System.Drawing.SizeF(75.54181!, 37.99999!)
            Me.XrLabel40.StylePriority.UseFont = False
            Me.XrLabel40.Text = "Current Month"
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
            Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 66.58338!)
            Me.XrLabel41.Name = "XrLabel41"
            Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel41.SizeF = New System.Drawing.SizeF(73.99991!, 37.99999!)
            Me.XrLabel41.StylePriority.UseFont = False
            Me.XrLabel41.Text = "Prior Months"
            Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel42
            '
            Me.XrLabel42.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel42.BorderColor = System.Drawing.Color.Black
            Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel42.BorderWidth = 1.0!
            Me.XrLabel42.CanGrow = False
            Me.XrLabel42.Dpi = 100.0!
            Me.XrLabel42.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel42.ForeColor = System.Drawing.Color.Black
            Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 66.58338!)
            Me.XrLabel42.Name = "XrLabel42"
            Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel42.SizeF = New System.Drawing.SizeF(74.0!, 37.99999!)
            Me.XrLabel42.StylePriority.UseFont = False
            Me.XrLabel42.Text = "Prior Months"
            Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel43
            '
            Me.XrLabel43.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel43.BorderColor = System.Drawing.Color.Black
            Me.XrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel43.BorderWidth = 1.0!
            Me.XrLabel43.CanGrow = False
            Me.XrLabel43.Dpi = 100.0!
            Me.XrLabel43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel43.ForeColor = System.Drawing.Color.Black
            Me.XrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 66.58338!)
            Me.XrLabel43.Name = "XrLabel43"
            Me.XrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel43.SizeF = New System.Drawing.SizeF(74.00006!, 38.00001!)
            Me.XrLabel43.StylePriority.UseFont = False
            Me.XrLabel43.Text = "Current Month"
            Me.XrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel44
            '
            Me.XrLabel44.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel44.BorderColor = System.Drawing.Color.Black
            Me.XrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel44.BorderWidth = 1.0!
            Me.XrLabel44.CanGrow = False
            Me.XrLabel44.Dpi = 100.0!
            Me.XrLabel44.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel44.ForeColor = System.Drawing.Color.Black
            Me.XrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 66.58338!)
            Me.XrLabel44.Name = "XrLabel44"
            Me.XrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel44.SizeF = New System.Drawing.SizeF(73.99997!, 37.99999!)
            Me.XrLabel44.StylePriority.UseFont = False
            Me.XrLabel44.Text = "Estimate w/Cont."
            Me.XrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel45
            '
            Me.XrLabel45.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel45.BorderColor = System.Drawing.Color.Black
            Me.XrLabel45.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel45.BorderWidth = 1.0!
            Me.XrLabel45.CanGrow = False
            Me.XrLabel45.Dpi = 100.0!
            Me.XrLabel45.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel45.ForeColor = System.Drawing.Color.Black
            Me.XrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 26.00002!)
            Me.XrLabel45.Name = "XrLabel45"
            Me.XrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel45.SizeF = New System.Drawing.SizeF(371.542!, 20.29167!)
            Me.XrLabel45.StylePriority.UseFont = False
            Me.XrLabel45.Text = "-------------------- Expenses and Income Only --------------------"
            Me.XrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel46
            '
            Me.XrLabel46.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel46.BorderColor = System.Drawing.Color.Black
            Me.XrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel46.BorderWidth = 1.0!
            Me.XrLabel46.CanGrow = False
            Me.XrLabel46.Dpi = 100.0!
            Me.XrLabel46.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel46.ForeColor = System.Drawing.Color.Black
            Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 46.29173!)
            Me.XrLabel46.Name = "XrLabel46"
            Me.XrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel46.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel46.StylePriority.UseFont = False
            Me.XrLabel46.Text = "Actuals"
            Me.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel47
            '
            Me.XrLabel47.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel47.BorderColor = System.Drawing.Color.Black
            Me.XrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel47.BorderWidth = 1.0!
            Me.XrLabel47.CanGrow = False
            Me.XrLabel47.Dpi = 100.0!
            Me.XrLabel47.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel47.ForeColor = System.Drawing.Color.Black
            Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 46.29173!)
            Me.XrLabel47.Name = "XrLabel47"
            Me.XrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel47.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel47.StylePriority.UseFont = False
            Me.XrLabel47.Text = "Billed"
            Me.XrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel48
            '
            Me.XrLabel48.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel48.BorderColor = System.Drawing.Color.Black
            Me.XrLabel48.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel48.BorderWidth = 1.0!
            Me.XrLabel48.CanGrow = False
            Me.XrLabel48.Dpi = 100.0!
            Me.XrLabel48.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel48.ForeColor = System.Drawing.Color.Black
            Me.XrLabel48.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 46.29173!)
            Me.XrLabel48.Name = "XrLabel48"
            Me.XrLabel48.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel48.SizeF = New System.Drawing.SizeF(147.9999!, 20.29167!)
            Me.XrLabel48.StylePriority.UseFont = False
            Me.XrLabel48.Text = "Billed"
            Me.XrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel49
            '
            Me.XrLabel49.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel49.BorderColor = System.Drawing.Color.Black
            Me.XrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel49.BorderWidth = 1.0!
            Me.XrLabel49.CanGrow = False
            Me.XrLabel49.Dpi = 100.0!
            Me.XrLabel49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel49.ForeColor = System.Drawing.Color.Black
            Me.XrLabel49.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 46.29167!)
            Me.XrLabel49.Name = "XrLabel49"
            Me.XrLabel49.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel49.SizeF = New System.Drawing.SizeF(149.5418!, 20.29167!)
            Me.XrLabel49.StylePriority.UseFont = False
            Me.XrLabel49.Text = "Actuals"
            Me.XrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel50
            '
            Me.XrLabel50.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel50.BorderColor = System.Drawing.Color.Black
            Me.XrLabel50.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel50.BorderWidth = 1.0!
            Me.XrLabel50.CanGrow = False
            Me.XrLabel50.Dpi = 100.0!
            Me.XrLabel50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel50.ForeColor = System.Drawing.Color.Black
            Me.XrLabel50.LocationFloat = New DevExpress.Utils.PointFloat(752.0001!, 46.29173!)
            Me.XrLabel50.Name = "XrLabel50"
            Me.XrLabel50.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel50.SizeF = New System.Drawing.SizeF(298.6799!, 20.29167!)
            Me.XrLabel50.StylePriority.UseFont = False
            Me.XrLabel50.Text = "------------------------- Totals -------------------------"
            Me.XrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel29
            '
            Me.XrLabel29.BackColor = System.Drawing.Color.White
            Me.XrLabel29.BorderColor = System.Drawing.Color.Black
            Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel29.BorderWidth = 1.0!
            Me.XrLabel29.CanGrow = False
            Me.XrLabel29.Dpi = 100.0!
            Me.XrLabel29.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel29.ForeColor = System.Drawing.Color.Black
            Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 0!)
            Me.XrLabel29.Name = "XrLabel29"
            Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel29.SizeF = New System.Drawing.SizeF(136.7917!, 26.0!)
            Me.XrLabel29.StylePriority.UseFont = False
            Me.XrLabel29.StylePriority.UseForeColor = False
            Me.XrLabel29.Text = "Report Totals"
            Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelPageHeader_Title.Text = "Job Analysis (V6) - Current Month/ Prior Totals"
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
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 4.000028!)
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
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(729.68!, 4.000028!)
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
            Me.Line26.SizeF = New System.Drawing.SizeF(1050.68!, 4.0!)
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
            Me.GroupHeaderForm_CDP.Level = 2
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
            XrSummary15.FormatString = "{0}"
            Me.Text31.Summary = XrSummary15
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
            XrSummary16.FormatString = "{0}"
            Me.LabelPageHeader_ProductData.Summary = XrSummary16
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
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel28, Me.XrLabel27, Me.XrLabel26, Me.XrLabel21, Me.XrLabel22, Me.XrLabel20, Me.XrLabel18, Me.XrLabel19, Me.Label52, Me.Text90, Me.CTotal, Me.CNBillable, Me.CBilled, Me.Text99, Me.Text132})
            Me.GroupFooter1.Dpi = 100.0!
            Me.GroupFooter1.HeightF = 69.58332!
            Me.GroupFooter1.Level = 2
            Me.GroupFooter1.Name = "GroupFooter1"
            Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'XrLabel28
            '
            Me.XrLabel28.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel28.BorderColor = System.Drawing.Color.Black
            Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel28.BorderWidth = 1.0!
            Me.XrLabel28.CanGrow = False
            Me.XrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsBilled")})
            Me.XrLabel28.Dpi = 100.0!
            Me.XrLabel28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 39.54163!)
            Me.XrLabel28.Name = "XrLabel28"
            Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel28.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel28.StylePriority.UseFont = False
            XrSummary17.FormatString = "{0:n2}"
            XrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel28.Summary = XrSummary17
            Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel27
            '
            Me.XrLabel27.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel27.BorderColor = System.Drawing.Color.Black
            Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel27.BorderWidth = 1.0!
            Me.XrLabel27.CanGrow = False
            Me.XrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthActuals")})
            Me.XrLabel27.Dpi = 100.0!
            Me.XrLabel27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 39.54163!)
            Me.XrLabel27.Name = "XrLabel27"
            Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel27.SizeF = New System.Drawing.SizeF(73.99998!, 19.0!)
            Me.XrLabel27.StylePriority.UseFont = False
            XrSummary18.FormatString = "{0:n2}"
            XrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel27.Summary = XrSummary18
            Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel26
            '
            Me.XrLabel26.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel26.BorderColor = System.Drawing.Color.Black
            Me.XrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel26.BorderWidth = 1.0!
            Me.XrLabel26.CanGrow = False
            Me.XrLabel26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsActuals")})
            Me.XrLabel26.Dpi = 100.0!
            Me.XrLabel26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 39.54163!)
            Me.XrLabel26.Name = "XrLabel26"
            Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel26.SizeF = New System.Drawing.SizeF(74.00002!, 19.0!)
            Me.XrLabel26.StylePriority.UseFont = False
            XrSummary19.FormatString = "{0:n2}"
            XrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel26.Summary = XrSummary19
            Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel21
            '
            Me.XrLabel21.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel21.BorderColor = System.Drawing.Color.Black
            Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel21.BorderWidth = 1.0!
            Me.XrLabel21.CanGrow = False
            Me.XrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthActuals")})
            Me.XrLabel21.Dpi = 100.0!
            Me.XrLabel21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 39.54163!)
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(75.54187!, 19.0!)
            Me.XrLabel21.StylePriority.UseFont = False
            XrSummary20.FormatString = "{0:n2}"
            XrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel21.Summary = XrSummary20
            Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel22
            '
            Me.XrLabel22.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel22.BorderColor = System.Drawing.Color.Black
            Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel22.BorderWidth = 1.0!
            Me.XrLabel22.CanGrow = False
            Me.XrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsBilled")})
            Me.XrLabel22.Dpi = 100.0!
            Me.XrLabel22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 39.54163!)
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel22.StylePriority.UseFont = False
            XrSummary21.FormatString = "{0:n2}"
            XrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel22.Summary = XrSummary21
            Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsActuals")})
            Me.XrLabel20.Dpi = 100.0!
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 39.54163!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(73.99991!, 19.0!)
            Me.XrLabel20.StylePriority.UseFont = False
            XrSummary22.FormatString = "{0:n2}"
            XrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel20.Summary = XrSummary22
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel18
            '
            Me.XrLabel18.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel18.BorderColor = System.Drawing.Color.Black
            Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel18.BorderWidth = 1.0!
            Me.XrLabel18.CanGrow = False
            Me.XrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthBilled")})
            Me.XrLabel18.Dpi = 100.0!
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 39.54163!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(74.00003!, 19.0!)
            Me.XrLabel18.StylePriority.UseFont = False
            XrSummary23.FormatString = "{0:n2}"
            XrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel18.Summary = XrSummary23
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel19
            '
            Me.XrLabel19.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel19.BorderColor = System.Drawing.Color.Black
            Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel19.BorderWidth = 1.0!
            Me.XrLabel19.CanGrow = False
            Me.XrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeIncomeOnly")})
            Me.XrLabel19.Dpi = 100.0!
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 39.54163!)
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel19.StylePriority.UseFont = False
            XrSummary24.FormatString = "{0:n2}"
            XrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel19.Summary = XrSummary24
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
            Me.Label52.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.Label52.Name = "Label52"
            Me.Label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label52.SizeF = New System.Drawing.SizeF(208.5415!, 19.0!)
            Me.Label52.StylePriority.UseFont = False
            Me.Label52.StylePriority.UseTextAlignment = False
            Me.Label52.Text = "Client/Division/Product Totals:"
            Me.Label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text90
            '
            Me.Text90.BackColor = System.Drawing.Color.Transparent
            Me.Text90.BorderColor = System.Drawing.Color.Black
            Me.Text90.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text90.BorderWidth = 1.0!
            Me.Text90.CanGrow = False
            Me.Text90.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeeTime")})
            Me.Text90.Dpi = 100.0!
            Me.Text90.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text90.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 39.54163!)
            Me.Text90.Name = "Text90"
            Me.Text90.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text90.SizeF = New System.Drawing.SizeF(74.45834!, 19.0!)
            Me.Text90.StylePriority.UseFont = False
            XrSummary25.FormatString = "{0:n2}"
            XrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text90.Summary = XrSummary25
            Me.Text90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CTotal
            '
            Me.CTotal.BackColor = System.Drawing.Color.Transparent
            Me.CTotal.BorderColor = System.Drawing.Color.Black
            Me.CTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CTotal.BorderWidth = 1.0!
            Me.CTotal.CanGrow = False
            Me.CTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthBilled")})
            Me.CTotal.Dpi = 100.0!
            Me.CTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CTotal.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 39.54163!)
            Me.CTotal.Name = "CTotal"
            Me.CTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CTotal.SizeF = New System.Drawing.SizeF(74.00018!, 19.0!)
            Me.CTotal.StylePriority.UseFont = False
            XrSummary26.FormatString = "{0:n2}"
            XrSummary26.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CTotal.Summary = XrSummary26
            Me.CTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CNBillable
            '
            Me.CNBillable.BackColor = System.Drawing.Color.Transparent
            Me.CNBillable.BorderColor = System.Drawing.Color.Black
            Me.CNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CNBillable.BorderWidth = 1.0!
            Me.CNBillable.CanGrow = False
            Me.CNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.CNBillable.Dpi = 100.0!
            Me.CNBillable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CNBillable.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 39.54163!)
            Me.CNBillable.Name = "CNBillable"
            Me.CNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CNBillable.SizeF = New System.Drawing.SizeF(73.41669!, 19.0!)
            Me.CNBillable.StylePriority.UseFont = False
            XrSummary27.FormatString = "{0:n2}"
            XrSummary27.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CNBillable.Summary = XrSummary27
            Me.CNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CBilled
            '
            Me.CBilled.BackColor = System.Drawing.Color.Transparent
            Me.CBilled.BorderColor = System.Drawing.Color.Black
            Me.CBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.CBilled.BorderWidth = 1.0!
            Me.CBilled.CanGrow = False
            Me.CBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotals")})
            Me.CBilled.Dpi = 100.0!
            Me.CBilled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.CBilled.LocationFloat = New DevExpress.Utils.PointFloat(900.6803!, 39.54163!)
            Me.CBilled.Name = "CBilled"
            Me.CBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.CBilled.SizeF = New System.Drawing.SizeF(75.00006!, 19.0!)
            Me.CBilled.StylePriority.UseFont = False
            XrSummary28.FormatString = "{0:n2}"
            XrSummary28.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.CBilled.Summary = XrSummary28
            Me.CBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text99
            '
            Me.Text99.BackColor = System.Drawing.Color.Transparent
            Me.Text99.BorderColor = System.Drawing.Color.Black
            Me.Text99.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text99.BorderWidth = 1.0!
            Me.Text99.CanGrow = False
            Me.Text99.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualTotals")})
            Me.Text99.Dpi = 100.0!
            Me.Text99.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text99.LocationFloat = New DevExpress.Utils.PointFloat(825.4169!, 39.54163!)
            Me.Text99.Name = "Text99"
            Me.Text99.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text99.SizeF = New System.Drawing.SizeF(75.26337!, 19.0!)
            Me.Text99.StylePriority.UseFont = False
            XrSummary29.FormatString = "{0:n2}"
            XrSummary29.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text99.Summary = XrSummary29
            Me.Text99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text132
            '
            Me.Text132.BackColor = System.Drawing.Color.Transparent
            Me.Text132.BorderColor = System.Drawing.Color.Black
            Me.Text132.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text132.BorderWidth = 1.0!
            Me.Text132.CanGrow = False
            Me.Text132.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Unbilled")})
            Me.Text132.Dpi = 100.0!
            Me.Text132.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.Text132.LocationFloat = New DevExpress.Utils.PointFloat(975.6802!, 39.54163!)
            Me.Text132.Name = "Text132"
            Me.Text132.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text132.SizeF = New System.Drawing.SizeF(74.99976!, 19.0!)
            Me.Text132.StylePriority.UseFont = False
            XrSummary30.FormatString = "{0:n2}"
            XrSummary30.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text132.Summary = XrSummary30
            Me.Text132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader1
            '
            Me.GroupHeader1.BackColor = System.Drawing.Color.Transparent
            Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel17, Me.XrLabel15, Me.XrLabel16, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel2, Me.XrLabel8, Me.XrLabel9, Me.XrLabel10, Me.XrLabel11, Me.XrLabel1, Me.Label60, Me.Label58, Me.Label62, Me.Label64, Me.label3, Me.Label68, Me.Label72, Me.Label74, Me.Line57, Me.Label129})
            Me.GroupHeader1.Dpi = 100.0!
            Me.GroupHeader1.HeightF = 99.66666!
            Me.GroupHeader1.Level = 1
            Me.GroupHeader1.Name = "GroupHeader1"
            Me.GroupHeader1.RepeatEveryPage = True
            '
            'XrLabel17
            '
            Me.XrLabel17.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel17.BorderColor = System.Drawing.Color.Black
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel17.BorderWidth = 1.0!
            Me.XrLabel17.CanGrow = False
            Me.XrLabel17.Dpi = 100.0!
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel17.ForeColor = System.Drawing.Color.Black
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 28.00001!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(298.6799!, 20.29167!)
            Me.XrLabel17.StylePriority.UseFont = False
            Me.XrLabel17.Text = "------------------------- Totals -------------------------"
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Dpi = 100.0!
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 28.00001!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.Text = "Actuals"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1.0!
            Me.XrLabel16.CanGrow = False
            Me.XrLabel16.Dpi = 100.0!
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel16.ForeColor = System.Drawing.Color.Black
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 28.00001!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel16.StylePriority.UseFont = False
            Me.XrLabel16.Text = "Billed"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel14
            '
            Me.XrLabel14.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel14.BorderColor = System.Drawing.Color.Black
            Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel14.BorderWidth = 1.0!
            Me.XrLabel14.CanGrow = False
            Me.XrLabel14.Dpi = 100.0!
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel14.ForeColor = System.Drawing.Color.Black
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 28.00001!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel14.StylePriority.UseFont = False
            Me.XrLabel14.Text = "Billed"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1.0!
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.Dpi = 100.0!
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel13.ForeColor = System.Drawing.Color.Black
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(84.45833!, 28.00001!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(148.0!, 20.29167!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.Text = "Actuals"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel12
            '
            Me.XrLabel12.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel12.BorderColor = System.Drawing.Color.Black
            Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel12.BorderWidth = 1.0!
            Me.XrLabel12.CanGrow = False
            Me.XrLabel12.Dpi = 100.0!
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.ForeColor = System.Drawing.Color.Black
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 7.708327!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(371.5418!, 20.29167!)
            Me.XrLabel12.StylePriority.UseFont = False
            Me.XrLabel12.Text = "-------------------- Expenses and Income Only --------------------"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 48.29168!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.Text = "Estimate w/Cont."
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel8
            '
            Me.XrLabel8.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel8.BorderColor = System.Drawing.Color.Black
            Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel8.BorderWidth = 1.0!
            Me.XrLabel8.CanGrow = False
            Me.XrLabel8.Dpi = 100.0!
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel8.ForeColor = System.Drawing.Color.Black
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 48.29165!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(74.0!, 38.00001!)
            Me.XrLabel8.StylePriority.UseFont = False
            Me.XrLabel8.Text = "Current Month"
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel9
            '
            Me.XrLabel9.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel9.BorderColor = System.Drawing.Color.Black
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel9.BorderWidth = 1.0!
            Me.XrLabel9.CanGrow = False
            Me.XrLabel9.Dpi = 100.0!
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.ForeColor = System.Drawing.Color.Black
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(602.4583!, 48.29168!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(75.54181!, 38.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            Me.XrLabel9.Text = "Prior   Months"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1.0!
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.Dpi = 100.0!
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.ForeColor = System.Drawing.Color.Black
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 48.29168!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.Text = "Prior   Months"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel11
            '
            Me.XrLabel11.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel11.BorderColor = System.Drawing.Color.Black
            Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel11.BorderWidth = 1.0!
            Me.XrLabel11.CanGrow = False
            Me.XrLabel11.Dpi = 100.0!
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.ForeColor = System.Drawing.Color.Black
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 48.29168!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.XrLabel11.StylePriority.UseFont = False
            Me.XrLabel11.Text = "Current Month"
            Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1.0!
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.Dpi = 100.0!
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(9.99995!, 7.708327!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(370.4584!, 20.29167!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.Text = "------------------------------ Employee Time ------------------------------"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.Label60.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 48.29168!)
            Me.Label60.Name = "Label60"
            Me.Label60.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label60.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.Label60.StylePriority.UseFont = False
            Me.Label60.Text = "Current Month"
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
            Me.Label58.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 48.29165!)
            Me.Label58.Name = "Label58"
            Me.Label58.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label58.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.Label58.StylePriority.UseFont = False
            Me.Label58.Text = "Prior   Months"
            Me.Label58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.Label62.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 48.29165!)
            Me.Label62.Name = "Label62"
            Me.Label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label62.SizeF = New System.Drawing.SizeF(74.0!, 38.0!)
            Me.Label62.StylePriority.UseFont = False
            Me.Label62.Text = "Prior   Months"
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
            Me.Label64.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 48.29168!)
            Me.Label64.Name = "Label64"
            Me.Label64.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label64.SizeF = New System.Drawing.SizeF(74.0!, 38.00001!)
            Me.Label64.StylePriority.UseFont = False
            Me.Label64.Text = "Current Month"
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
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 48.29168!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(74.45834!, 38.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Estimate w/Cont."
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.Label68.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 65.29169!)
            Me.Label68.Name = "Label68"
            Me.Label68.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label68.SizeF = New System.Drawing.SizeF(73.41669!, 21.00001!)
            Me.Label68.StylePriority.UseFont = False
            Me.Label68.Text = "Estimate"
            Me.Label68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.Label72.LocationFloat = New DevExpress.Utils.PointFloat(900.6803!, 65.29169!)
            Me.Label72.Name = "Label72"
            Me.Label72.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label72.SizeF = New System.Drawing.SizeF(75.00006!, 21.00001!)
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
            Me.Label74.LocationFloat = New DevExpress.Utils.PointFloat(825.4168!, 65.29169!)
            Me.Label74.Name = "Label74"
            Me.Label74.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label74.SizeF = New System.Drawing.SizeF(75.26349!, 21.00001!)
            Me.Label74.StylePriority.UseFont = False
            Me.Label74.Text = "Actual"
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
            Me.Line57.LocationFloat = New DevExpress.Utils.PointFloat(0!, 86.29169!)
            Me.Line57.Name = "Line57"
            Me.Line57.SizeF = New System.Drawing.SizeF(1050.68!, 4.000008!)
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
            Me.Label129.LocationFloat = New DevExpress.Utils.PointFloat(975.6803!, 65.29169!)
            Me.Label129.Name = "Label129"
            Me.Label129.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label129.SizeF = New System.Drawing.SizeF(74.99976!, 21.00001!)
            Me.Label129.StylePriority.UseFont = False
            Me.Label129.Text = "Unbilled" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.Label129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooter3
            '
            Me.GroupFooter3.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter3.Dpi = 100.0!
            Me.GroupFooter3.HeightF = 0!
            Me.GroupFooter3.Level = 1
            Me.GroupFooter3.Name = "GroupFooter3"
            Me.GroupFooter3.Visible = False
            '
            'GroupFooter0
            '
            Me.GroupFooter0.BackColor = System.Drawing.Color.Transparent
            Me.GroupFooter0.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.FUNC, Me.XrLabel24, Me.XrLabel23, Me.XrLabel6, Me.XrLabel7, Me.XrLabel5, Me.XrLabel3, Me.XrLabel4, Me.Text77, Me.Text79, Me.FTotal, Me.FNBillable, Me.FBilled, Me.Text88, Me.XrLabel25})
            Me.GroupFooter0.Dpi = 100.0!
            Me.GroupFooter0.HeightF = 48.95834!
            Me.GroupFooter0.Name = "GroupFooter0"
            '
            'FUNC
            '
            Me.FUNC.BackColor = System.Drawing.Color.Transparent
            Me.FUNC.BorderColor = System.Drawing.Color.Black
            Me.FUNC.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FUNC.BorderWidth = 1.0!
            Me.FUNC.CanGrow = False
            Me.FUNC.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobFull")})
            Me.FUNC.Dpi = 100.0!
            Me.FUNC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FUNC.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.250018!)
            Me.FUNC.Name = "FUNC"
            Me.FUNC.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FUNC.SizeF = New System.Drawing.SizeF(678.0001!, 19.0!)
            Me.FUNC.StylePriority.UseFont = False
            XrSummary31.FormatString = "{0}"
            Me.FUNC.Summary = XrSummary31
            Me.FUNC.Text = "FUNC"
            Me.FUNC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel24
            '
            Me.XrLabel24.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel24.BorderColor = System.Drawing.Color.Black
            Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel24.BorderWidth = 1.0!
            Me.XrLabel24.CanGrow = False
            Me.XrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthActuals")})
            Me.XrLabel24.Dpi = 100.0!
            Me.XrLabel24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 23.25001!)
            Me.XrLabel24.Name = "XrLabel24"
            Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel24.SizeF = New System.Drawing.SizeF(73.99997!, 19.0!)
            Me.XrLabel24.StylePriority.UseFont = False
            XrSummary32.FormatString = "{0:n2}"
            XrSummary32.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel24.Summary = XrSummary32
            Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel23
            '
            Me.XrLabel23.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel23.BorderColor = System.Drawing.Color.Black
            Me.XrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel23.BorderWidth = 1.0!
            Me.XrLabel23.CanGrow = False
            Me.XrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsActuals")})
            Me.XrLabel23.Dpi = 100.0!
            Me.XrLabel23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 23.25001!)
            Me.XrLabel23.Name = "XrLabel23"
            Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel23.SizeF = New System.Drawing.SizeF(73.99998!, 19.0!)
            Me.XrLabel23.StylePriority.UseFont = False
            XrSummary33.FormatString = "{0:n2}"
            XrSummary33.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel23.Summary = XrSummary33
            Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.BorderWidth = 1.0!
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthActuals")})
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 23.25001!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(75.54187!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            XrSummary34.FormatString = "{0:n2}"
            XrSummary34.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel6.Summary = XrSummary34
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1.0!
            Me.XrLabel7.CanGrow = False
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsBilled")})
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 23.25001!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(73.99994!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            XrSummary35.FormatString = "{0:n2}"
            XrSummary35.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel7.Summary = XrSummary35
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsActuals")})
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 23.25001!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(73.99991!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            XrSummary36.FormatString = "{0:n2}"
            XrSummary36.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel5.Summary = XrSummary36
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthBilled")})
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 23.25001!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(74.00003!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            XrSummary37.FormatString = "{0:n2}"
            XrSummary37.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel3.Summary = XrSummary37
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel4
            '
            Me.XrLabel4.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel4.BorderColor = System.Drawing.Color.Black
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel4.BorderWidth = 1.0!
            Me.XrLabel4.CanGrow = False
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeIncomeOnly")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 23.25001!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(73.99997!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            XrSummary38.FormatString = "{0:n2}"
            XrSummary38.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel4.Summary = XrSummary38
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text77
            '
            Me.Text77.BackColor = System.Drawing.Color.Transparent
            Me.Text77.BorderColor = System.Drawing.Color.Black
            Me.Text77.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text77.BorderWidth = 1.0!
            Me.Text77.CanGrow = False
            Me.Text77.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Unbilled")})
            Me.Text77.Dpi = 100.0!
            Me.Text77.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text77.LocationFloat = New DevExpress.Utils.PointFloat(975.6803!, 23.25001!)
            Me.Text77.Name = "Text77"
            Me.Text77.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text77.SizeF = New System.Drawing.SizeF(74.99988!, 19.0!)
            Me.Text77.StylePriority.UseFont = False
            XrSummary39.FormatString = "{0:n2}"
            XrSummary39.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text77.Summary = XrSummary39
            Me.Text77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text79
            '
            Me.Text79.BackColor = System.Drawing.Color.Transparent
            Me.Text79.BorderColor = System.Drawing.Color.Black
            Me.Text79.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text79.BorderWidth = 1.0!
            Me.Text79.CanGrow = False
            Me.Text79.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeeTime")})
            Me.Text79.Dpi = 100.0!
            Me.Text79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text79.LocationFloat = New DevExpress.Utils.PointFloat(9.99995!, 23.25001!)
            Me.Text79.Name = "Text79"
            Me.Text79.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text79.SizeF = New System.Drawing.SizeF(74.45834!, 19.0!)
            Me.Text79.StylePriority.UseFont = False
            XrSummary40.FormatString = "{0:n2}"
            XrSummary40.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text79.Summary = XrSummary40
            Me.Text79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FTotal
            '
            Me.FTotal.BackColor = System.Drawing.Color.Transparent
            Me.FTotal.BorderColor = System.Drawing.Color.Black
            Me.FTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FTotal.BorderWidth = 1.0!
            Me.FTotal.CanGrow = False
            Me.FTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthBilled")})
            Me.FTotal.Dpi = 100.0!
            Me.FTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FTotal.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 23.25001!)
            Me.FTotal.Name = "FTotal"
            Me.FTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FTotal.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.FTotal.StylePriority.UseFont = False
            XrSummary41.FormatString = "{0:n2}"
            XrSummary41.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FTotal.Summary = XrSummary41
            Me.FTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FNBillable
            '
            Me.FNBillable.BackColor = System.Drawing.Color.Transparent
            Me.FNBillable.BorderColor = System.Drawing.Color.Black
            Me.FNBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FNBillable.BorderWidth = 1.0!
            Me.FNBillable.CanGrow = False
            Me.FNBillable.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.FNBillable.Dpi = 100.0!
            Me.FNBillable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FNBillable.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 23.25001!)
            Me.FNBillable.Name = "FNBillable"
            Me.FNBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FNBillable.SizeF = New System.Drawing.SizeF(73.41675!, 19.0!)
            Me.FNBillable.StylePriority.UseFont = False
            XrSummary42.FormatString = "{0:n2}"
            XrSummary42.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FNBillable.Summary = XrSummary42
            Me.FNBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FBilled
            '
            Me.FBilled.BackColor = System.Drawing.Color.Transparent
            Me.FBilled.BorderColor = System.Drawing.Color.Black
            Me.FBilled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FBilled.BorderWidth = 1.0!
            Me.FBilled.CanGrow = False
            Me.FBilled.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotals")})
            Me.FBilled.Dpi = 100.0!
            Me.FBilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FBilled.LocationFloat = New DevExpress.Utils.PointFloat(900.6801!, 23.25001!)
            Me.FBilled.Name = "FBilled"
            Me.FBilled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.FBilled.SizeF = New System.Drawing.SizeF(75.0!, 19.0!)
            Me.FBilled.StylePriority.UseFont = False
            XrSummary43.FormatString = "{0:n2}"
            XrSummary43.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.FBilled.Summary = XrSummary43
            Me.FBilled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Text88
            '
            Me.Text88.BackColor = System.Drawing.Color.Transparent
            Me.Text88.BorderColor = System.Drawing.Color.Black
            Me.Text88.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text88.BorderWidth = 1.0!
            Me.Text88.CanGrow = False
            Me.Text88.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualTotals")})
            Me.Text88.Dpi = 100.0!
            Me.Text88.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text88.LocationFloat = New DevExpress.Utils.PointFloat(825.4168!, 23.25001!)
            Me.Text88.Name = "Text88"
            Me.Text88.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text88.SizeF = New System.Drawing.SizeF(75.26331!, 19.0!)
            Me.Text88.StylePriority.UseFont = False
            XrSummary44.FormatString = "{0:n2}"
            XrSummary44.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.Text88.Summary = XrSummary44
            Me.Text88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel25
            '
            Me.XrLabel25.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel25.BorderColor = System.Drawing.Color.Black
            Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel25.BorderWidth = 1.0!
            Me.XrLabel25.CanGrow = False
            Me.XrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsBilled")})
            Me.XrLabel25.Dpi = 100.0!
            Me.XrLabel25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 23.25001!)
            Me.XrLabel25.Name = "XrLabel25"
            Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel25.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel25.StylePriority.UseFont = False
            XrSummary45.FormatString = "{0:n2}"
            XrSummary45.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel25.Summary = XrSummary45
            Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.JobFull.Expression = "'Job: ' + [JobNumber] + ' - ' + [JobDescription] + '   Component: ' + [JobCompone" &
    "ntNumber]"
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
            Me.BilledField.Expression = "[SumOfBilledAmount] + [SumOfAdvanceBilled]"
            Me.BilledField.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.BilledField.Name = "BilledField"
            '
            'Unbilled
            '
            Me.Unbilled.Expression = "([CurrentMonthSumOfUnbilled] + [PriorMonthsSumOfUnbilled])"
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
            Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader2.HeightF = 0!
            Me.GroupHeader2.Name = "GroupHeader2"
            Me.GroupHeader2.Visible = False
            '
            'EstimateEmployeeTime
            '
            Me.EstimateEmployeeTime.Expression = "Iif([FunctionType]='E',[SumOfEstimate]  , 0)"
            Me.EstimateEmployeeTime.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EstimateEmployeeTime.Name = "EstimateEmployeeTime"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailAnalysisCurrentPrior)
            '
            'EmployeeTimePriorMonthsActuals
            '
            Me.EmployeeTimePriorMonthsActuals.Expression = "Iif([FunctionType]='E', [PriorMonthsSumOfLineTotal], 0)"
            Me.EmployeeTimePriorMonthsActuals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeTimePriorMonthsActuals.Name = "EmployeeTimePriorMonthsActuals"
            '
            'EmployeeTimeCurrentMonthActuals
            '
            Me.EmployeeTimeCurrentMonthActuals.Expression = "Iif([FunctionType]='E', [CurrentMonthSumOfTotalBill] , 0)"
            Me.EmployeeTimeCurrentMonthActuals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeTimeCurrentMonthActuals.Name = "EmployeeTimeCurrentMonthActuals"
            '
            'EmployeeTimePriorMonthsBilled
            '
            Me.EmployeeTimePriorMonthsBilled.Expression = "Iif([FunctionType]='E', [PriorMonthsSumOfBilledAmount], 0)"
            Me.EmployeeTimePriorMonthsBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeTimePriorMonthsBilled.Name = "EmployeeTimePriorMonthsBilled"
            '
            'EmployeeTimeCurrentMonthBilled
            '
            Me.EmployeeTimeCurrentMonthBilled.Expression = "Iif([FunctionType]='E', [CurrentMonthSumOfBilledAmount], 0)"
            Me.EmployeeTimeCurrentMonthBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeTimeCurrentMonthBilled.Name = "EmployeeTimeCurrentMonthBilled"
            '
            'EstimateEmployeIncomeOnly
            '
            Me.EstimateEmployeIncomeOnly.Expression = "Iif([FunctionType]='I' OR [FunctionType]='V',[SumOfEstimate]  , 0)"
            Me.EstimateEmployeIncomeOnly.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EstimateEmployeIncomeOnly.Name = "EstimateEmployeIncomeOnly"
            '
            'EmployeeIncomeOnlyPriorMonthsActuals
            '
            Me.EmployeeIncomeOnlyPriorMonthsActuals.Expression = "Iif([FunctionType]='I' OR [FunctionType]='V', [PriorMonthsSumOfLineTotal],0)"
            Me.EmployeeIncomeOnlyPriorMonthsActuals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeIncomeOnlyPriorMonthsActuals.Name = "EmployeeIncomeOnlyPriorMonthsActuals"
            '
            'EmployeeIncomeOnlyCurrentMonthActuals
            '
            Me.EmployeeIncomeOnlyCurrentMonthActuals.Expression = "Iif([FunctionType]='I', [CurrentMonthSumOfIncomeOnly], Iif([FunctionType]='V',[Cu" &
    "rrentMonthSumOfTotalBill]  ,0 ))"
            Me.EmployeeIncomeOnlyCurrentMonthActuals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeIncomeOnlyCurrentMonthActuals.Name = "EmployeeIncomeOnlyCurrentMonthActuals"
            '
            'EmployeeIncomeOnlyPriorMonthsBilled
            '
            Me.EmployeeIncomeOnlyPriorMonthsBilled.Expression = "Iif([FunctionType]='I' OR [FunctionType]='V', [PriorMonthsSumOfBilledAmount], 0)"
            Me.EmployeeIncomeOnlyPriorMonthsBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeIncomeOnlyPriorMonthsBilled.Name = "EmployeeIncomeOnlyPriorMonthsBilled"
            '
            'EmployeeIncomeOnlyCurrentMonthBilled
            '
            Me.EmployeeIncomeOnlyCurrentMonthBilled.Expression = "Iif([FunctionType]='I' OR [FunctionType]='V', [CurrentMonthSumOfBilledAmount], 0)" &
    ""
            Me.EmployeeIncomeOnlyCurrentMonthBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EmployeeIncomeOnlyCurrentMonthBilled.Name = "EmployeeIncomeOnlyCurrentMonthBilled"
            '
            'EstimateTotals
            '
            Me.EstimateTotals.Expression = "[CurrentMonthSumOfEstimate] + [PriorMonthsSumOfEstimate]"
            Me.EstimateTotals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.EstimateTotals.Name = "EstimateTotals"
            '
            'ActualTotals
            '
            Me.ActualTotals.Expression = "[CurrentMonthSumOfLineTotal]+ [PriorMonthsSumOfLineTotal]"
            Me.ActualTotals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ActualTotals.Name = "ActualTotals"
            '
            'BilledTotals
            '
            Me.BilledTotals.Expression = "[CurrentMonthSumOfBilledAmount] + [PriorMonthsSumOfBilledAmount]"
            Me.BilledTotals.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.BilledTotals.Name = "BilledTotals"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel65, Me.XrLabel66, Me.XrLabel67, Me.XrLabel68, Me.XrLabel69, Me.XrLabel70, Me.XrLabel71, Me.XrLabel72, Me.XrLabel73, Me.XrLabel74, Me.XrLabel75, Me.XrLabel76, Me.XrLabel77, Me.XrLabel78, Me.XrLabel79})
            Me.GroupFooter2.Dpi = 100.0!
            Me.GroupFooter2.HeightF = 70.83334!
            Me.GroupFooter2.Level = 3
            Me.GroupFooter2.Name = "GroupFooter2"
            Me.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrLabel65
            '
            Me.XrLabel65.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel65.BorderColor = System.Drawing.Color.Black
            Me.XrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel65.BorderWidth = 1.0!
            Me.XrLabel65.CanGrow = False
            Me.XrLabel65.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Unbilled")})
            Me.XrLabel65.Dpi = 100.0!
            Me.XrLabel65.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel65.LocationFloat = New DevExpress.Utils.PointFloat(975.6802!, 39.54163!)
            Me.XrLabel65.Name = "XrLabel65"
            Me.XrLabel65.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel65.SizeF = New System.Drawing.SizeF(74.99976!, 19.0!)
            Me.XrLabel65.StylePriority.UseFont = False
            XrSummary46.FormatString = "{0:n2}"
            XrSummary46.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel65.Summary = XrSummary46
            Me.XrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel66
            '
            Me.XrLabel66.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel66.BorderColor = System.Drawing.Color.Black
            Me.XrLabel66.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel66.BorderWidth = 1.0!
            Me.XrLabel66.CanGrow = False
            Me.XrLabel66.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ActualTotals")})
            Me.XrLabel66.Dpi = 100.0!
            Me.XrLabel66.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel66.LocationFloat = New DevExpress.Utils.PointFloat(825.4169!, 39.54163!)
            Me.XrLabel66.Name = "XrLabel66"
            Me.XrLabel66.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel66.SizeF = New System.Drawing.SizeF(75.26337!, 19.0!)
            Me.XrLabel66.StylePriority.UseFont = False
            XrSummary47.FormatString = "{0:n2}"
            XrSummary47.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel66.Summary = XrSummary47
            Me.XrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel67
            '
            Me.XrLabel67.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel67.BorderColor = System.Drawing.Color.Black
            Me.XrLabel67.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel67.BorderWidth = 1.0!
            Me.XrLabel67.CanGrow = False
            Me.XrLabel67.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotals")})
            Me.XrLabel67.Dpi = 100.0!
            Me.XrLabel67.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel67.LocationFloat = New DevExpress.Utils.PointFloat(900.6803!, 39.54163!)
            Me.XrLabel67.Name = "XrLabel67"
            Me.XrLabel67.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel67.SizeF = New System.Drawing.SizeF(75.00006!, 19.0!)
            Me.XrLabel67.StylePriority.UseFont = False
            XrSummary48.FormatString = "{0:n2}"
            XrSummary48.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel67.Summary = XrSummary48
            Me.XrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel68
            '
            Me.XrLabel68.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel68.BorderColor = System.Drawing.Color.Black
            Me.XrLabel68.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel68.BorderWidth = 1.0!
            Me.XrLabel68.CanGrow = False
            Me.XrLabel68.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumOfEstimate")})
            Me.XrLabel68.Dpi = 100.0!
            Me.XrLabel68.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel68.LocationFloat = New DevExpress.Utils.PointFloat(752.0002!, 39.54163!)
            Me.XrLabel68.Name = "XrLabel68"
            Me.XrLabel68.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel68.SizeF = New System.Drawing.SizeF(73.41669!, 19.0!)
            Me.XrLabel68.StylePriority.UseFont = False
            XrSummary49.FormatString = "{0:n2}"
            XrSummary49.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel68.Summary = XrSummary49
            Me.XrLabel68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel69
            '
            Me.XrLabel69.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel69.BorderColor = System.Drawing.Color.Black
            Me.XrLabel69.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel69.BorderWidth = 1.0!
            Me.XrLabel69.CanGrow = False
            Me.XrLabel69.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthBilled")})
            Me.XrLabel69.Dpi = 100.0!
            Me.XrLabel69.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel69.LocationFloat = New DevExpress.Utils.PointFloat(678.0001!, 39.54163!)
            Me.XrLabel69.Name = "XrLabel69"
            Me.XrLabel69.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel69.SizeF = New System.Drawing.SizeF(74.00018!, 19.0!)
            Me.XrLabel69.StylePriority.UseFont = False
            XrSummary50.FormatString = "{0:n2}"
            XrSummary50.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel69.Summary = XrSummary50
            Me.XrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel70
            '
            Me.XrLabel70.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel70.BorderColor = System.Drawing.Color.Black
            Me.XrLabel70.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel70.BorderWidth = 1.0!
            Me.XrLabel70.CanGrow = False
            Me.XrLabel70.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeeTime")})
            Me.XrLabel70.Dpi = 100.0!
            Me.XrLabel70.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel70.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 39.54163!)
            Me.XrLabel70.Name = "XrLabel70"
            Me.XrLabel70.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel70.SizeF = New System.Drawing.SizeF(74.45834!, 19.0!)
            Me.XrLabel70.StylePriority.UseFont = False
            XrSummary51.FormatString = "{0:n2}"
            XrSummary51.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel70.Summary = XrSummary51
            Me.XrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel71
            '
            Me.XrLabel71.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel71.BorderColor = System.Drawing.Color.Black
            Me.XrLabel71.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel71.BorderWidth = 1.0!
            Me.XrLabel71.CanGrow = False
            Me.XrLabel71.Dpi = 100.0!
            Me.XrLabel71.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel71.ForeColor = System.Drawing.Color.Black
            Me.XrLabel71.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.XrLabel71.Name = "XrLabel71"
            Me.XrLabel71.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel71.SizeF = New System.Drawing.SizeF(208.5415!, 19.0!)
            Me.XrLabel71.StylePriority.UseFont = False
            Me.XrLabel71.StylePriority.UseTextAlignment = False
            Me.XrLabel71.Text = "Account Executive Totals:"
            Me.XrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel72
            '
            Me.XrLabel72.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel72.BorderColor = System.Drawing.Color.Black
            Me.XrLabel72.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel72.BorderWidth = 1.0!
            Me.XrLabel72.CanGrow = False
            Me.XrLabel72.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateEmployeIncomeOnly")})
            Me.XrLabel72.Dpi = 100.0!
            Me.XrLabel72.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel72.LocationFloat = New DevExpress.Utils.PointFloat(380.4583!, 39.54163!)
            Me.XrLabel72.Name = "XrLabel72"
            Me.XrLabel72.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel72.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel72.StylePriority.UseFont = False
            XrSummary52.FormatString = "{0:n2}"
            XrSummary52.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel72.Summary = XrSummary52
            Me.XrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel73
            '
            Me.XrLabel73.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel73.BorderColor = System.Drawing.Color.Black
            Me.XrLabel73.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel73.BorderWidth = 1.0!
            Me.XrLabel73.CanGrow = False
            Me.XrLabel73.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthBilled")})
            Me.XrLabel73.Dpi = 100.0!
            Me.XrLabel73.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel73.LocationFloat = New DevExpress.Utils.PointFloat(306.4583!, 39.54163!)
            Me.XrLabel73.Name = "XrLabel73"
            Me.XrLabel73.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel73.SizeF = New System.Drawing.SizeF(74.00003!, 19.0!)
            Me.XrLabel73.StylePriority.UseFont = False
            XrSummary53.FormatString = "{0:n2}"
            XrSummary53.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel73.Summary = XrSummary53
            Me.XrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel74
            '
            Me.XrLabel74.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel74.BorderColor = System.Drawing.Color.Black
            Me.XrLabel74.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel74.BorderWidth = 1.0!
            Me.XrLabel74.CanGrow = False
            Me.XrLabel74.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsActuals")})
            Me.XrLabel74.Dpi = 100.0!
            Me.XrLabel74.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel74.LocationFloat = New DevExpress.Utils.PointFloat(454.4583!, 39.54163!)
            Me.XrLabel74.Name = "XrLabel74"
            Me.XrLabel74.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel74.SizeF = New System.Drawing.SizeF(73.99991!, 19.0!)
            Me.XrLabel74.StylePriority.UseFont = False
            XrSummary54.FormatString = "{0:n2}"
            XrSummary54.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel74.Summary = XrSummary54
            Me.XrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel75
            '
            Me.XrLabel75.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel75.BorderColor = System.Drawing.Color.Black
            Me.XrLabel75.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel75.BorderWidth = 1.0!
            Me.XrLabel75.CanGrow = False
            Me.XrLabel75.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyPriorMonthsBilled")})
            Me.XrLabel75.Dpi = 100.0!
            Me.XrLabel75.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel75.LocationFloat = New DevExpress.Utils.PointFloat(604.0002!, 39.54163!)
            Me.XrLabel75.Name = "XrLabel75"
            Me.XrLabel75.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel75.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel75.StylePriority.UseFont = False
            XrSummary55.FormatString = "{0:n2}"
            XrSummary55.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel75.Summary = XrSummary55
            Me.XrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel76
            '
            Me.XrLabel76.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel76.BorderColor = System.Drawing.Color.Black
            Me.XrLabel76.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel76.BorderWidth = 1.0!
            Me.XrLabel76.CanGrow = False
            Me.XrLabel76.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeIncomeOnlyCurrentMonthActuals")})
            Me.XrLabel76.Dpi = 100.0!
            Me.XrLabel76.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel76.LocationFloat = New DevExpress.Utils.PointFloat(528.4583!, 39.54163!)
            Me.XrLabel76.Name = "XrLabel76"
            Me.XrLabel76.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel76.SizeF = New System.Drawing.SizeF(75.54187!, 19.0!)
            Me.XrLabel76.StylePriority.UseFont = False
            XrSummary56.FormatString = "{0:n2}"
            XrSummary56.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel76.Summary = XrSummary56
            Me.XrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel77
            '
            Me.XrLabel77.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel77.BorderColor = System.Drawing.Color.Black
            Me.XrLabel77.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel77.BorderWidth = 1.0!
            Me.XrLabel77.CanGrow = False
            Me.XrLabel77.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsActuals")})
            Me.XrLabel77.Dpi = 100.0!
            Me.XrLabel77.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel77.LocationFloat = New DevExpress.Utils.PointFloat(84.45836!, 39.54163!)
            Me.XrLabel77.Name = "XrLabel77"
            Me.XrLabel77.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel77.SizeF = New System.Drawing.SizeF(74.00002!, 19.0!)
            Me.XrLabel77.StylePriority.UseFont = False
            XrSummary57.FormatString = "{0:n2}"
            XrSummary57.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel77.Summary = XrSummary57
            Me.XrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel78
            '
            Me.XrLabel78.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel78.BorderColor = System.Drawing.Color.Black
            Me.XrLabel78.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel78.BorderWidth = 1.0!
            Me.XrLabel78.CanGrow = False
            Me.XrLabel78.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimeCurrentMonthActuals")})
            Me.XrLabel78.Dpi = 100.0!
            Me.XrLabel78.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel78.LocationFloat = New DevExpress.Utils.PointFloat(158.4584!, 39.54163!)
            Me.XrLabel78.Name = "XrLabel78"
            Me.XrLabel78.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel78.SizeF = New System.Drawing.SizeF(73.99998!, 19.0!)
            Me.XrLabel78.StylePriority.UseFont = False
            XrSummary58.FormatString = "{0:n2}"
            XrSummary58.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel78.Summary = XrSummary58
            Me.XrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel79
            '
            Me.XrLabel79.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel79.BorderColor = System.Drawing.Color.Black
            Me.XrLabel79.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel79.BorderWidth = 1.0!
            Me.XrLabel79.CanGrow = False
            Me.XrLabel79.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeTimePriorMonthsBilled")})
            Me.XrLabel79.Dpi = 100.0!
            Me.XrLabel79.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel79.LocationFloat = New DevExpress.Utils.PointFloat(232.4583!, 39.54163!)
            Me.XrLabel79.Name = "XrLabel79"
            Me.XrLabel79.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel79.SizeF = New System.Drawing.SizeF(74.0!, 19.0!)
            Me.XrLabel79.StylePriority.UseFont = False
            XrSummary59.FormatString = "{0:n2}"
            XrSummary59.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel79.Summary = XrSummary59
            Me.XrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader3
            '
            Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel80, Me.XrLabel81})
            Me.GroupHeader3.Dpi = 100.0!
            Me.GroupHeader3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountExecutiveFull", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader3.HeightF = 19.79167!
            Me.GroupHeader3.Level = 3
            Me.GroupHeader3.Name = "GroupHeader3"
            Me.GroupHeader3.RepeatEveryPage = True
            '
            'XrLabel80
            '
            Me.XrLabel80.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel80.BorderColor = System.Drawing.Color.Black
            Me.XrLabel80.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel80.BorderWidth = 1.0!
            Me.XrLabel80.CanGrow = False
            Me.XrLabel80.Dpi = 100.0!
            Me.XrLabel80.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel80.ForeColor = System.Drawing.Color.Black
            Me.XrLabel80.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel80.Name = "XrLabel80"
            Me.XrLabel80.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel80.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.XrLabel80.StylePriority.UseFont = False
            Me.XrLabel80.Text = "Account Executive:"
            Me.XrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel81
            '
            Me.XrLabel81.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel81.BorderColor = System.Drawing.Color.Black
            Me.XrLabel81.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel81.BorderWidth = 1.0!
            Me.XrLabel81.CanGrow = False
            Me.XrLabel81.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountExecutiveFull")})
            Me.XrLabel81.Dpi = 100.0!
            Me.XrLabel81.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel81.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 0!)
            Me.XrLabel81.Name = "XrLabel81"
            Me.XrLabel81.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel81.SizeF = New System.Drawing.SizeF(378.0!, 19.0!)
            Me.XrLabel81.StylePriority.UseFont = False
            XrSummary60.FormatString = "{0}"
            Me.XrLabel81.Summary = XrSummary60
            Me.XrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SummaryByFunctionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.GroupHeaderForm_CDP, Me.GroupFooter1, Me.GroupHeader1, Me.GroupFooter3, Me.GroupFooter0, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupHeader2, Me.GroupFooter2, Me.GroupHeader3})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientFull, Me.DivisionFull, Me.ProductFull, Me.JobFull, Me.JobComponentFull, Me.AdvanceFlag, Me.BillableStatus, Me.HoldStatus, Me.ProcessDescription, Me.AccountExecutiveFull, Me.FunctionFull, Me.FunctionTypeTotal, Me.NetCost, Me.BilledField, Me.Unbilled, Me.TodaysDate, Me.EstimateEmployeeTime, Me.EmployeeTimePriorMonthsActuals, Me.EmployeeTimeCurrentMonthActuals, Me.EmployeeTimePriorMonthsBilled, Me.EmployeeTimeCurrentMonthBilled, Me.EstimateEmployeIncomeOnly, Me.EmployeeIncomeOnlyPriorMonthsActuals, Me.EmployeeIncomeOnlyCurrentMonthActuals, Me.EmployeeIncomeOnlyPriorMonthsBilled, Me.EmployeeIncomeOnlyCurrentMonthBilled, Me.EstimateTotals, Me.ActualTotals, Me.BilledTotals})
            Me.DataSource = Me.BindingSource
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(10, 30, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.SnapGridSize = 1.0!
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Private WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents FUNC As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents EstimateEmployeeTime As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeTimePriorMonthsActuals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeTimeCurrentMonthActuals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeTimePriorMonthsBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeTimeCurrentMonthBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EstimateEmployeIncomeOnly As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeIncomeOnlyPriorMonthsActuals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeIncomeOnlyCurrentMonthActuals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeIncomeOnlyPriorMonthsBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EmployeeIncomeOnlyCurrentMonthBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EstimateTotals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ActualTotals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledTotals As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupHeader3 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents XrLabel51 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel52 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel53 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel54 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel55 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel56 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel57 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel58 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel59 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel60 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel61 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel62 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel63 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel64 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel38 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel40 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel43 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel44 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel45 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel48 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel49 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel50 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Private WithEvents XrLabel65 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel66 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel67 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel68 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel69 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel70 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel71 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel72 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel73 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel74 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel75 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel76 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel77 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel78 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel79 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel80 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel81 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace






