Namespace Proofing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class FeedbackSummaryReport
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
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Label_TimeDue = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TimeDueLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_Priority = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PriorityLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_AssetsHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ClientNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ClientName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DivisionNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DivisionName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProductName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProductNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_JobLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CurrentStateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_CurrentState = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TemplateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Template = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_StartDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_StartDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProofTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProofTitleLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubReport_Assets = New DevExpress.XtraReports.UI.XRSubreport()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.Line_HeaderTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line_HeaderBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.ObjectDataSource1 = New DevExpress.DataAccess.ObjectBinding.ObjectDataSource(Me.components)
            CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 70.0!
            Me.TopMargin.Name = "TopMargin"
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 70.0!
            Me.BottomMargin.Name = "BottomMargin"
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_TimeDue, Me.Label_TimeDueLabel, Me.XrLine1, Me.Label_Priority, Me.Label_PriorityLabel, Me.Label_AssetsHeader, Me.Label_ClientNameLabel, Me.Label_ClientName, Me.Label_DivisionNameLabel, Me.Label_DivisionName, Me.Label_ProductName, Me.Label_ProductNameLabel, Me.Label_Job, Me.Label_JobLabel, Me.Label_CurrentStateLabel, Me.Label_CurrentState, Me.Label_TemplateLabel, Me.Label_Template, Me.Label_StartDateLabel, Me.Label_DueDateLabel, Me.Label_StartDate, Me.Label_DueDate, Me.Label_Description, Me.Label_DescriptionLabel, Me.Label_ProofTitle, Me.Label_ProofTitleLabel, Me.SubReport_Assets})
            Me.Detail.HeightF = 275.0!
            Me.Detail.Name = "Detail"
            '
            'Label_TimeDue
            '
            Me.Label_TimeDue.BackColor = System.Drawing.Color.Transparent
            Me.Label_TimeDue.BorderColor = System.Drawing.Color.Black
            Me.Label_TimeDue.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_TimeDue.BorderWidth = 1.0!
            Me.Label_TimeDue.CanGrow = False
            Me.Label_TimeDue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TimeDue.LocationFloat = New DevExpress.Utils.PointFloat(534.4116!, 67.41662!)
            Me.Label_TimeDue.Name = "Label_TimeDue"
            Me.Label_TimeDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_TimeDue.SizeF = New System.Drawing.SizeF(125.8383!, 19.00001!)
            Me.Label_TimeDue.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.Label_TimeDue.Summary = XrSummary1
            Me.Label_TimeDue.Text = "Label_TimeDue"
            Me.Label_TimeDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_TimeDueLabel
            '
            Me.Label_TimeDueLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_TimeDueLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_TimeDueLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_TimeDueLabel.BorderWidth = 1.0!
            Me.Label_TimeDueLabel.CanGrow = False
            Me.Label_TimeDueLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TimeDueLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_TimeDueLabel.LocationFloat = New DevExpress.Utils.PointFloat(468.7503!, 67.41662!)
            Me.Label_TimeDueLabel.Name = "Label_TimeDueLabel"
            Me.Label_TimeDueLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_TimeDueLabel.SizeF = New System.Drawing.SizeF(65.66101!, 19.0!)
            Me.Label_TimeDueLabel.StylePriority.UseFont = False
            Me.Label_TimeDueLabel.Text = "Time Due:"
            Me.Label_TimeDueLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4.0!
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(50.00006!, 200.1331!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(610.2499!, 4.000015!)
            '
            'Label_Priority
            '
            Me.Label_Priority.BackColor = System.Drawing.Color.Transparent
            Me.Label_Priority.BorderColor = System.Drawing.Color.Black
            Me.Label_Priority.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Priority.BorderWidth = 1.0!
            Me.Label_Priority.CanGrow = False
            Me.Label_Priority.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Priority.LocationFloat = New DevExpress.Utils.PointFloat(534.4113!, 10.41666!)
            Me.Label_Priority.Name = "Label_Priority"
            Me.Label_Priority.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Priority.SizeF = New System.Drawing.SizeF(125.8383!, 19.0!)
            Me.Label_Priority.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.Label_Priority.Summary = XrSummary2
            Me.Label_Priority.Text = "Label_Priority"
            Me.Label_Priority.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PriorityLabel
            '
            Me.Label_PriorityLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_PriorityLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_PriorityLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_PriorityLabel.BorderWidth = 1.0!
            Me.Label_PriorityLabel.CanGrow = False
            Me.Label_PriorityLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PriorityLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_PriorityLabel.LocationFloat = New DevExpress.Utils.PointFloat(468.75!, 10.41667!)
            Me.Label_PriorityLabel.Name = "Label_PriorityLabel"
            Me.Label_PriorityLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_PriorityLabel.SizeF = New System.Drawing.SizeF(65.66101!, 19.0!)
            Me.Label_PriorityLabel.StylePriority.UseFont = False
            Me.Label_PriorityLabel.Text = "Priority:"
            Me.Label_PriorityLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_AssetsHeader
            '
            Me.Label_AssetsHeader.BackColor = System.Drawing.Color.Transparent
            Me.Label_AssetsHeader.BorderColor = System.Drawing.Color.Black
            Me.Label_AssetsHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_AssetsHeader.BorderWidth = 1.0!
            Me.Label_AssetsHeader.CanGrow = False
            Me.Label_AssetsHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_AssetsHeader.ForeColor = System.Drawing.Color.Black
            Me.Label_AssetsHeader.LocationFloat = New DevExpress.Utils.PointFloat(49.99998!, 181.1331!)
            Me.Label_AssetsHeader.Name = "Label_AssetsHeader"
            Me.Label_AssetsHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_AssetsHeader.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.Label_AssetsHeader.StylePriority.UseFont = False
            Me.Label_AssetsHeader.Text = "Assets"
            Me.Label_AssetsHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ClientNameLabel
            '
            Me.Label_ClientNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_ClientNameLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_ClientNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ClientNameLabel.BorderWidth = 1.0!
            Me.Label_ClientNameLabel.CanGrow = False
            Me.Label_ClientNameLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ClientNameLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_ClientNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 94.79164!)
            Me.Label_ClientNameLabel.Name = "Label_ClientNameLabel"
            Me.Label_ClientNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ClientNameLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.00001!)
            Me.Label_ClientNameLabel.StylePriority.UseFont = False
            Me.Label_ClientNameLabel.Text = "Client:"
            Me.Label_ClientNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ClientName
            '
            Me.Label_ClientName.BackColor = System.Drawing.Color.Transparent
            Me.Label_ClientName.BorderColor = System.Drawing.Color.Black
            Me.Label_ClientName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ClientName.BorderWidth = 1.0!
            Me.Label_ClientName.CanGrow = False
            Me.Label_ClientName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ClientName.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 94.79164!)
            Me.Label_ClientName.Name = "Label_ClientName"
            Me.Label_ClientName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ClientName.SizeF = New System.Drawing.SizeF(359.2888!, 19.00001!)
            Me.Label_ClientName.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.Label_ClientName.Summary = XrSummary3
            Me.Label_ClientName.Text = "Label_ClientName"
            Me.Label_ClientName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DivisionNameLabel
            '
            Me.Label_DivisionNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_DivisionNameLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_DivisionNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DivisionNameLabel.BorderWidth = 1.0!
            Me.Label_DivisionNameLabel.CanGrow = False
            Me.Label_DivisionNameLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DivisionNameLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_DivisionNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 113.7917!)
            Me.Label_DivisionNameLabel.Name = "Label_DivisionNameLabel"
            Me.Label_DivisionNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DivisionNameLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.00001!)
            Me.Label_DivisionNameLabel.StylePriority.UseFont = False
            Me.Label_DivisionNameLabel.Text = "Division:"
            Me.Label_DivisionNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DivisionName
            '
            Me.Label_DivisionName.BackColor = System.Drawing.Color.Transparent
            Me.Label_DivisionName.BorderColor = System.Drawing.Color.Black
            Me.Label_DivisionName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DivisionName.BorderWidth = 1.0!
            Me.Label_DivisionName.CanGrow = False
            Me.Label_DivisionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DivisionName.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 113.7917!)
            Me.Label_DivisionName.Name = "Label_DivisionName"
            Me.Label_DivisionName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DivisionName.SizeF = New System.Drawing.SizeF(359.2888!, 19.00001!)
            Me.Label_DivisionName.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0}"
            Me.Label_DivisionName.Summary = XrSummary4
            Me.Label_DivisionName.Text = "Label_DivisionName"
            Me.Label_DivisionName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ProductName
            '
            Me.Label_ProductName.BackColor = System.Drawing.Color.Transparent
            Me.Label_ProductName.BorderColor = System.Drawing.Color.Black
            Me.Label_ProductName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ProductName.BorderWidth = 1.0!
            Me.Label_ProductName.CanGrow = False
            Me.Label_ProductName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ProductName.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 132.7916!)
            Me.Label_ProductName.Name = "Label_ProductName"
            Me.Label_ProductName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ProductName.SizeF = New System.Drawing.SizeF(359.2888!, 19.0!)
            Me.Label_ProductName.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0}"
            Me.Label_ProductName.Summary = XrSummary5
            Me.Label_ProductName.Text = "Label_ProductName"
            Me.Label_ProductName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ProductNameLabel
            '
            Me.Label_ProductNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_ProductNameLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_ProductNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ProductNameLabel.BorderWidth = 1.0!
            Me.Label_ProductNameLabel.CanGrow = False
            Me.Label_ProductNameLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ProductNameLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_ProductNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 132.7916!)
            Me.Label_ProductNameLabel.Name = "Label_ProductNameLabel"
            Me.Label_ProductNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ProductNameLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.0!)
            Me.Label_ProductNameLabel.StylePriority.UseFont = False
            Me.Label_ProductNameLabel.Text = "Product"
            Me.Label_ProductNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Job
            '
            Me.Label_Job.BackColor = System.Drawing.Color.Transparent
            Me.Label_Job.BorderColor = System.Drawing.Color.Black
            Me.Label_Job.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Job.BorderWidth = 1.0!
            Me.Label_Job.CanGrow = False
            Me.Label_Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Job.LocationFloat = New DevExpress.Utils.PointFloat(99.27795!, 151.7916!)
            Me.Label_Job.Name = "Label_Job"
            Me.Label_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Job.SizeF = New System.Drawing.SizeF(560.972!, 19.00002!)
            Me.Label_Job.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0}"
            Me.Label_Job.Summary = XrSummary6
            Me.Label_Job.Text = "Label_Job"
            Me.Label_Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_JobLabel
            '
            Me.Label_JobLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_JobLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_JobLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_JobLabel.BorderWidth = 1.0!
            Me.Label_JobLabel.CanGrow = False
            Me.Label_JobLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_JobLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_JobLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 151.7916!)
            Me.Label_JobLabel.Name = "Label_JobLabel"
            Me.Label_JobLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_JobLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.00002!)
            Me.Label_JobLabel.StylePriority.UseFont = False
            Me.Label_JobLabel.Text = "Job:"
            Me.Label_JobLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CurrentStateLabel
            '
            Me.Label_CurrentStateLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_CurrentStateLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_CurrentStateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CurrentStateLabel.BorderWidth = 1.0!
            Me.Label_CurrentStateLabel.CanGrow = False
            Me.Label_CurrentStateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_CurrentStateLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_CurrentStateLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 67.41663!)
            Me.Label_CurrentStateLabel.Name = "Label_CurrentStateLabel"
            Me.Label_CurrentStateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CurrentStateLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.00001!)
            Me.Label_CurrentStateLabel.StylePriority.UseFont = False
            Me.Label_CurrentStateLabel.Text = "Current State:"
            Me.Label_CurrentStateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_CurrentState
            '
            Me.Label_CurrentState.BackColor = System.Drawing.Color.Transparent
            Me.Label_CurrentState.BorderColor = System.Drawing.Color.Black
            Me.Label_CurrentState.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_CurrentState.BorderWidth = 1.0!
            Me.Label_CurrentState.CanGrow = False
            Me.Label_CurrentState.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_CurrentState.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 67.41663!)
            Me.Label_CurrentState.Name = "Label_CurrentState"
            Me.Label_CurrentState.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_CurrentState.SizeF = New System.Drawing.SizeF(359.2888!, 19.00001!)
            Me.Label_CurrentState.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0}"
            Me.Label_CurrentState.Summary = XrSummary7
            Me.Label_CurrentState.Text = "Label_CurrentState"
            Me.Label_CurrentState.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_TemplateLabel
            '
            Me.Label_TemplateLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_TemplateLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_TemplateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_TemplateLabel.BorderWidth = 1.0!
            Me.Label_TemplateLabel.CanGrow = False
            Me.Label_TemplateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TemplateLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_TemplateLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 48.41666!)
            Me.Label_TemplateLabel.Name = "Label_TemplateLabel"
            Me.Label_TemplateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_TemplateLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.0!)
            Me.Label_TemplateLabel.StylePriority.UseFont = False
            Me.Label_TemplateLabel.Text = "Template:"
            Me.Label_TemplateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Template
            '
            Me.Label_Template.BackColor = System.Drawing.Color.Transparent
            Me.Label_Template.BorderColor = System.Drawing.Color.Black
            Me.Label_Template.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Template.BorderWidth = 1.0!
            Me.Label_Template.CanGrow = False
            Me.Label_Template.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Template.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 48.41666!)
            Me.Label_Template.Name = "Label_Template"
            Me.Label_Template.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Template.SizeF = New System.Drawing.SizeF(359.2888!, 19.0!)
            Me.Label_Template.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0}"
            Me.Label_Template.Summary = XrSummary8
            Me.Label_Template.Text = "Label_Template"
            Me.Label_Template.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_StartDateLabel
            '
            Me.Label_StartDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_StartDateLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_StartDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_StartDateLabel.BorderWidth = 1.0!
            Me.Label_StartDateLabel.CanGrow = False
            Me.Label_StartDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_StartDateLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_StartDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(468.75!, 29.41666!)
            Me.Label_StartDateLabel.Name = "Label_StartDateLabel"
            Me.Label_StartDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_StartDateLabel.SizeF = New System.Drawing.SizeF(65.66125!, 19.0!)
            Me.Label_StartDateLabel.StylePriority.UseFont = False
            Me.Label_StartDateLabel.Text = "Start Date:"
            Me.Label_StartDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DueDateLabel
            '
            Me.Label_DueDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_DueDateLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_DueDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DueDateLabel.BorderWidth = 1.0!
            Me.Label_DueDateLabel.CanGrow = False
            Me.Label_DueDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DueDateLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_DueDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(468.75!, 48.41666!)
            Me.Label_DueDateLabel.Name = "Label_DueDateLabel"
            Me.Label_DueDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DueDateLabel.SizeF = New System.Drawing.SizeF(65.66101!, 19.0!)
            Me.Label_DueDateLabel.StylePriority.UseFont = False
            Me.Label_DueDateLabel.Text = "Due Date:"
            Me.Label_DueDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_StartDate
            '
            Me.Label_StartDate.BackColor = System.Drawing.Color.Transparent
            Me.Label_StartDate.BorderColor = System.Drawing.Color.Black
            Me.Label_StartDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_StartDate.BorderWidth = 1.0!
            Me.Label_StartDate.CanGrow = False
            Me.Label_StartDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_StartDate.LocationFloat = New DevExpress.Utils.PointFloat(534.4113!, 29.41665!)
            Me.Label_StartDate.Name = "Label_StartDate"
            Me.Label_StartDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_StartDate.SizeF = New System.Drawing.SizeF(125.8383!, 18.99999!)
            Me.Label_StartDate.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0}"
            Me.Label_StartDate.Summary = XrSummary9
            Me.Label_StartDate.Text = "Label_StartDate"
            Me.Label_StartDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DueDate
            '
            Me.Label_DueDate.BackColor = System.Drawing.Color.Transparent
            Me.Label_DueDate.BorderColor = System.Drawing.Color.Black
            Me.Label_DueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DueDate.BorderWidth = 1.0!
            Me.Label_DueDate.CanGrow = False
            Me.Label_DueDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DueDate.LocationFloat = New DevExpress.Utils.PointFloat(534.4113!, 48.41668!)
            Me.Label_DueDate.Name = "Label_DueDate"
            Me.Label_DueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DueDate.SizeF = New System.Drawing.SizeF(125.8383!, 19.00001!)
            Me.Label_DueDate.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0}"
            Me.Label_DueDate.Summary = XrSummary10
            Me.Label_DueDate.Text = "Label_DueDate"
            Me.Label_DueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Description
            '
            Me.Label_Description.BackColor = System.Drawing.Color.Transparent
            Me.Label_Description.BorderColor = System.Drawing.Color.Black
            Me.Label_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Description.BorderWidth = 1.0!
            Me.Label_Description.CanGrow = False
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 29.41666!)
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(359.2888!, 19.0!)
            Me.Label_Description.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0}"
            Me.Label_Description.Summary = XrSummary11
            Me.Label_Description.Text = "Label_Description"
            Me.Label_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DescriptionLabel
            '
            Me.Label_DescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_DescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_DescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DescriptionLabel.BorderWidth = 1.0!
            Me.Label_DescriptionLabel.CanGrow = False
            Me.Label_DescriptionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_DescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 29.41666!)
            Me.Label_DescriptionLabel.Name = "Label_DescriptionLabel"
            Me.Label_DescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DescriptionLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.0!)
            Me.Label_DescriptionLabel.StylePriority.UseFont = False
            Me.Label_DescriptionLabel.Text = "Description:"
            Me.Label_DescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ProofTitle
            '
            Me.Label_ProofTitle.BackColor = System.Drawing.Color.Transparent
            Me.Label_ProofTitle.BorderColor = System.Drawing.Color.Black
            Me.Label_ProofTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ProofTitle.BorderWidth = 1.0!
            Me.Label_ProofTitle.CanGrow = False
            Me.Label_ProofTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ProofTitle.LocationFloat = New DevExpress.Utils.PointFloat(99.27796!, 10.41667!)
            Me.Label_ProofTitle.Name = "Label_ProofTitle"
            Me.Label_ProofTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ProofTitle.SizeF = New System.Drawing.SizeF(359.2888!, 19.0!)
            Me.Label_ProofTitle.StylePriority.UseFont = False
            XrSummary12.FormatString = "{0}"
            Me.Label_ProofTitle.Summary = XrSummary12
            Me.Label_ProofTitle.Text = "Label_ProofTitle"
            Me.Label_ProofTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ProofTitleLabel
            '
            Me.Label_ProofTitleLabel.BackColor = System.Drawing.Color.Transparent
            Me.Label_ProofTitleLabel.BorderColor = System.Drawing.Color.Black
            Me.Label_ProofTitleLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ProofTitleLabel.BorderWidth = 1.0!
            Me.Label_ProofTitleLabel.CanGrow = False
            Me.Label_ProofTitleLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ProofTitleLabel.ForeColor = System.Drawing.Color.Black
            Me.Label_ProofTitleLabel.LocationFloat = New DevExpress.Utils.PointFloat(18.74997!, 10.41667!)
            Me.Label_ProofTitleLabel.Name = "Label_ProofTitleLabel"
            Me.Label_ProofTitleLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ProofTitleLabel.SizeF = New System.Drawing.SizeF(80.52799!, 19.0!)
            Me.Label_ProofTitleLabel.StylePriority.UseFont = False
            Me.Label_ProofTitleLabel.Text = "Title:"
            Me.Label_ProofTitleLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubReport_Assets
            '
            Me.SubReport_Assets.LocationFloat = New DevExpress.Utils.PointFloat(50.00025!, 204.1331!)
            Me.SubReport_Assets.Name = "SubReport_Assets"
            Me.SubReport_Assets.ReportSource = New AdvantageFramework.Reporting.Reports.Proofing.FeedbackSummaryAssetsSubReport()
            Me.SubReport_Assets.SizeF = New System.Drawing.SizeF(610.2497!, 23.0!)
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line_HeaderTop, Me.LabelPageHeader_Title, Me.Line_HeaderBottom})
            Me.PageHeader.HeightF = 70.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'Line_HeaderTop
            '
            Me.Line_HeaderTop.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderTop.BorderWidth = 4.0!
            Me.Line_HeaderTop.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.LineWidth = 4.0!
            Me.Line_HeaderTop.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.999977!)
            Me.Line_HeaderTop.Name = "Line_HeaderTop"
            Me.Line_HeaderTop.SizeF = New System.Drawing.SizeF(682.0001!, 4.00002!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(0!, 20.50001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(321.1667!, 25.79161!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Feedback Summary"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Line_HeaderBottom
            '
            Me.Line_HeaderBottom.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderBottom.BorderWidth = 4.0!
            Me.Line_HeaderBottom.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.LineWidth = 4.0!
            Me.Line_HeaderBottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.0!)
            Me.Line_HeaderBottom.Name = "Line_HeaderBottom"
            Me.Line_HeaderBottom.SizeF = New System.Drawing.SizeF(682.0002!, 4.000004!)
            '
            'ObjectDataSource1
            '
            Me.ObjectDataSource1.DataSourceType = Nothing
            Me.ObjectDataSource1.Name = "ObjectDataSource1"
            '
            'FeedbackSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageHeader})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.ObjectDataSource1})
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(75, 93, 70, 70)
            Me.Version = "20.1"
            CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents Line_HeaderTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line_HeaderBottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents SubReport_Assets As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ProofTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ProofTitleLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_StartDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DueDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_StartDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DueDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CurrentStateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_CurrentState As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_TemplateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Template As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ClientNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ClientName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DivisionNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DivisionName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ProductName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ProductNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Job As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_JobLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ObjectDataSource1 As DevExpress.DataAccess.ObjectBinding.ObjectDataSource
        Private WithEvents Label_AssetsHeader As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Priority As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_PriorityLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_TimeDue As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_TimeDueLabel As DevExpress.XtraReports.UI.XRLabel
    End Class
End Namespace
