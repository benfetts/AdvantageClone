Namespace MediaManager

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class RequestForProposalReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequestForProposalReport))
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrRichTextDetail_AdditionalGuidelines = New DevExpress.XtraReports.UI.XRRichText()
            Me.LabelDetail_GRPGoal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CPPGoal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FlightDates = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AdditionalGuidelinesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GRPGoalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CPPGoalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FlightDatesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Daypart = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SecondaryTargetAudiences = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TargetAudience = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_RatingsSource = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_MarketDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DaypartLengthLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TargetAudienceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_RatingsSourceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateAvailsDue = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateRequested = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateRequestedLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateAvailsDueLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_MarketLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SecondaryTargetAudiencesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_LocationHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.XrRichTextDetail_AdditionalGuidelines, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichTextDetail_AdditionalGuidelines, Me.LabelDetail_GRPGoal, Me.LabelDetail_CPPGoal, Me.LabelDetail_FlightDates, Me.LabelDetail_AdditionalGuidelinesLabel, Me.LabelDetail_GRPGoalLabel, Me.LabelDetail_CPPGoalLabel, Me.LabelDetail_FlightDatesLabel, Me.LabelDetail_Daypart, Me.LabelDetail_SecondaryTargetAudiences, Me.LabelDetail_TargetAudience, Me.LabelDetail_RatingsSource, Me.LabelDetail_MarketDescription, Me.LabelDetail_DaypartLengthLabel, Me.LabelDetail_TargetAudienceLabel, Me.LabelDetail_RatingsSourceLabel, Me.LabelDetail_DateAvailsDue, Me.LabelDetail_DateRequested, Me.LabelDetail_DateRequestedLabel, Me.LabelDetail_DateAvailsDueLabel, Me.LabelDetail_MarketLabel, Me.LabelDetail_SecondaryTargetAudiencesLabel})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 247.5416!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrRichTextDetail_AdditionalGuidelines
            '
            Me.XrRichTextDetail_AdditionalGuidelines.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Html", "[AdditionalGuidelines]")})
            Me.XrRichTextDetail_AdditionalGuidelines.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichTextDetail_AdditionalGuidelines.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 228.5416!)
            Me.XrRichTextDetail_AdditionalGuidelines.Name = "XrRichTextDetail_AdditionalGuidelines"
            Me.XrRichTextDetail_AdditionalGuidelines.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrRichTextDetail_AdditionalGuidelines.SerializableRtfString = resources.GetString("XrRichTextDetail_AdditionalGuidelines.SerializableRtfString")
            Me.XrRichTextDetail_AdditionalGuidelines.SizeF = New System.Drawing.SizeF(558.3333!, 18.99998!)
            '
            'LabelDetail_GRPGoal
            '
            Me.LabelDetail_GRPGoal.CanShrink = True
            Me.LabelDetail_GRPGoal.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GRPGoal]")})
            Me.LabelDetail_GRPGoal.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 209.5416!)
            Me.LabelDetail_GRPGoal.Multiline = True
            Me.LabelDetail_GRPGoal.Name = "LabelDetail_GRPGoal"
            Me.LabelDetail_GRPGoal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GRPGoal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_GRPGoal.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_GRPGoal.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_CPPGoal
            '
            Me.LabelDetail_CPPGoal.CanShrink = True
            Me.LabelDetail_CPPGoal.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CPPGoal]")})
            Me.LabelDetail_CPPGoal.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 190.5417!)
            Me.LabelDetail_CPPGoal.Multiline = True
            Me.LabelDetail_CPPGoal.Name = "LabelDetail_CPPGoal"
            Me.LabelDetail_CPPGoal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CPPGoal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CPPGoal.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_CPPGoal.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_FlightDates
            '
            Me.LabelDetail_FlightDates.CanShrink = True
            Me.LabelDetail_FlightDates.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FlightDates]")})
            Me.LabelDetail_FlightDates.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 171.5417!)
            Me.LabelDetail_FlightDates.Multiline = True
            Me.LabelDetail_FlightDates.Name = "LabelDetail_FlightDates"
            Me.LabelDetail_FlightDates.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_FlightDates.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_FlightDates.SizeF = New System.Drawing.SizeF(558.3333!, 19.0!)
            Me.LabelDetail_FlightDates.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_AdditionalGuidelinesLabel
            '
            Me.LabelDetail_AdditionalGuidelinesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AdditionalGuidelinesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AdditionalGuidelinesLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AdditionalGuidelinesLabel.BorderWidth = 1.0!
            Me.LabelDetail_AdditionalGuidelinesLabel.CanGrow = False
            Me.LabelDetail_AdditionalGuidelinesLabel.CanShrink = True
            Me.LabelDetail_AdditionalGuidelinesLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_AdditionalGuidelinesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AdditionalGuidelinesLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 228.5416!)
            Me.LabelDetail_AdditionalGuidelinesLabel.Name = "LabelDetail_AdditionalGuidelinesLabel"
            Me.LabelDetail_AdditionalGuidelinesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AdditionalGuidelinesLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_AdditionalGuidelinesLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_AdditionalGuidelinesLabel.StylePriority.UseFont = False
            Me.LabelDetail_AdditionalGuidelinesLabel.StylePriority.UsePadding = False
            Me.LabelDetail_AdditionalGuidelinesLabel.Text = "Additional Guidelines:"
            Me.LabelDetail_AdditionalGuidelinesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GRPGoalLabel
            '
            Me.LabelDetail_GRPGoalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GRPGoalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GRPGoalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GRPGoalLabel.BorderWidth = 1.0!
            Me.LabelDetail_GRPGoalLabel.CanGrow = False
            Me.LabelDetail_GRPGoalLabel.CanShrink = True
            Me.LabelDetail_GRPGoalLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_GRPGoalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GRPGoalLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 209.5416!)
            Me.LabelDetail_GRPGoalLabel.Name = "LabelDetail_GRPGoalLabel"
            Me.LabelDetail_GRPGoalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GRPGoalLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_GRPGoalLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_GRPGoalLabel.StylePriority.UseFont = False
            Me.LabelDetail_GRPGoalLabel.StylePriority.UsePadding = False
            Me.LabelDetail_GRPGoalLabel.Text = "GRP Goal:"
            Me.LabelDetail_GRPGoalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CPPGoalLabel
            '
            Me.LabelDetail_CPPGoalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CPPGoalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CPPGoalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CPPGoalLabel.BorderWidth = 1.0!
            Me.LabelDetail_CPPGoalLabel.CanGrow = False
            Me.LabelDetail_CPPGoalLabel.CanShrink = True
            Me.LabelDetail_CPPGoalLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_CPPGoalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CPPGoalLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 190.5417!)
            Me.LabelDetail_CPPGoalLabel.Name = "LabelDetail_CPPGoalLabel"
            Me.LabelDetail_CPPGoalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CPPGoalLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_CPPGoalLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_CPPGoalLabel.StylePriority.UseFont = False
            Me.LabelDetail_CPPGoalLabel.StylePriority.UsePadding = False
            Me.LabelDetail_CPPGoalLabel.Text = "CPP Goal:"
            Me.LabelDetail_CPPGoalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_FlightDatesLabel
            '
            Me.LabelDetail_FlightDatesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_FlightDatesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_FlightDatesLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_FlightDatesLabel.BorderWidth = 1.0!
            Me.LabelDetail_FlightDatesLabel.CanGrow = False
            Me.LabelDetail_FlightDatesLabel.CanShrink = True
            Me.LabelDetail_FlightDatesLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_FlightDatesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_FlightDatesLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 171.5417!)
            Me.LabelDetail_FlightDatesLabel.Name = "LabelDetail_FlightDatesLabel"
            Me.LabelDetail_FlightDatesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_FlightDatesLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_FlightDatesLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_FlightDatesLabel.StylePriority.UseFont = False
            Me.LabelDetail_FlightDatesLabel.StylePriority.UsePadding = False
            Me.LabelDetail_FlightDatesLabel.Text = "Flight Dates:"
            Me.LabelDetail_FlightDatesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Daypart
            '
            Me.LabelDetail_Daypart.CanShrink = True
            Me.LabelDetail_Daypart.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Daypart]")})
            Me.LabelDetail_Daypart.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 152.5417!)
            Me.LabelDetail_Daypart.Multiline = True
            Me.LabelDetail_Daypart.Name = "LabelDetail_Daypart"
            Me.LabelDetail_Daypart.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Daypart.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Daypart.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_Daypart.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_SecondaryTargetAudiences
            '
            Me.LabelDetail_SecondaryTargetAudiences.CanShrink = True
            Me.LabelDetail_SecondaryTargetAudiences.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SecondaryTargetAudiences]")})
            Me.LabelDetail_SecondaryTargetAudiences.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 121.0833!)
            Me.LabelDetail_SecondaryTargetAudiences.Multiline = True
            Me.LabelDetail_SecondaryTargetAudiences.Name = "LabelDetail_SecondaryTargetAudiences"
            Me.LabelDetail_SecondaryTargetAudiences.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_SecondaryTargetAudiences.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_SecondaryTargetAudiences.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_SecondaryTargetAudiences.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_TargetAudience
            '
            Me.LabelDetail_TargetAudience.CanShrink = True
            Me.LabelDetail_TargetAudience.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TargetAudience]")})
            Me.LabelDetail_TargetAudience.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 102.0833!)
            Me.LabelDetail_TargetAudience.Multiline = True
            Me.LabelDetail_TargetAudience.Name = "LabelDetail_TargetAudience"
            Me.LabelDetail_TargetAudience.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TargetAudience.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_TargetAudience.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_TargetAudience.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_RatingsSource
            '
            Me.LabelDetail_RatingsSource.CanShrink = True
            Me.LabelDetail_RatingsSource.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RatingsSource]")})
            Me.LabelDetail_RatingsSource.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 70.66666!)
            Me.LabelDetail_RatingsSource.Multiline = True
            Me.LabelDetail_RatingsSource.Name = "LabelDetail_RatingsSource"
            Me.LabelDetail_RatingsSource.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_RatingsSource.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_RatingsSource.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_RatingsSource.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_MarketDescription
            '
            Me.LabelDetail_MarketDescription.CanShrink = True
            Me.LabelDetail_MarketDescription.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MarketDescription]")})
            Me.LabelDetail_MarketDescription.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 51.66667!)
            Me.LabelDetail_MarketDescription.Multiline = True
            Me.LabelDetail_MarketDescription.Name = "LabelDetail_MarketDescription"
            Me.LabelDetail_MarketDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_MarketDescription.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_MarketDescription.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_MarketDescription.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_DaypartLengthLabel
            '
            Me.LabelDetail_DaypartLengthLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DaypartLengthLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DaypartLengthLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DaypartLengthLabel.BorderWidth = 1.0!
            Me.LabelDetail_DaypartLengthLabel.CanGrow = False
            Me.LabelDetail_DaypartLengthLabel.CanShrink = True
            Me.LabelDetail_DaypartLengthLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_DaypartLengthLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DaypartLengthLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 152.5417!)
            Me.LabelDetail_DaypartLengthLabel.Name = "LabelDetail_DaypartLengthLabel"
            Me.LabelDetail_DaypartLengthLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DaypartLengthLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_DaypartLengthLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_DaypartLengthLabel.StylePriority.UseFont = False
            Me.LabelDetail_DaypartLengthLabel.StylePriority.UsePadding = False
            Me.LabelDetail_DaypartLengthLabel.Text = "Daypart/Length:"
            Me.LabelDetail_DaypartLengthLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TargetAudienceLabel
            '
            Me.LabelDetail_TargetAudienceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TargetAudienceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TargetAudienceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TargetAudienceLabel.BorderWidth = 1.0!
            Me.LabelDetail_TargetAudienceLabel.CanGrow = False
            Me.LabelDetail_TargetAudienceLabel.CanShrink = True
            Me.LabelDetail_TargetAudienceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_TargetAudienceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TargetAudienceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.0833!)
            Me.LabelDetail_TargetAudienceLabel.Name = "LabelDetail_TargetAudienceLabel"
            Me.LabelDetail_TargetAudienceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TargetAudienceLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_TargetAudienceLabel.SizeF = New System.Drawing.SizeF(191.6667!, 18.99999!)
            Me.LabelDetail_TargetAudienceLabel.StylePriority.UseFont = False
            Me.LabelDetail_TargetAudienceLabel.StylePriority.UsePadding = False
            Me.LabelDetail_TargetAudienceLabel.Text = "Target Audience:"
            Me.LabelDetail_TargetAudienceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_RatingsSourceLabel
            '
            Me.LabelDetail_RatingsSourceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_RatingsSourceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_RatingsSourceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_RatingsSourceLabel.BorderWidth = 1.0!
            Me.LabelDetail_RatingsSourceLabel.CanGrow = False
            Me.LabelDetail_RatingsSourceLabel.CanShrink = True
            Me.LabelDetail_RatingsSourceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_RatingsSourceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_RatingsSourceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 70.66666!)
            Me.LabelDetail_RatingsSourceLabel.Name = "LabelDetail_RatingsSourceLabel"
            Me.LabelDetail_RatingsSourceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_RatingsSourceLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_RatingsSourceLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_RatingsSourceLabel.StylePriority.UseFont = False
            Me.LabelDetail_RatingsSourceLabel.StylePriority.UsePadding = False
            Me.LabelDetail_RatingsSourceLabel.Text = "Rating Source:"
            Me.LabelDetail_RatingsSourceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateAvailsDue
            '
            Me.LabelDetail_DateAvailsDue.CanShrink = True
            Me.LabelDetail_DateAvailsDue.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateAvailsDue]")})
            Me.LabelDetail_DateAvailsDue.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 18.99999!)
            Me.LabelDetail_DateAvailsDue.Multiline = True
            Me.LabelDetail_DateAvailsDue.Name = "LabelDetail_DateAvailsDue"
            Me.LabelDetail_DateAvailsDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DateAvailsDue.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_DateAvailsDue.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_DateAvailsDue.Text = "LabelDetail_DateAvailsDue"
            '
            'LabelDetail_DateRequested
            '
            Me.LabelDetail_DateRequested.CanShrink = True
            Me.LabelDetail_DateRequested.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateRequested]")})
            Me.LabelDetail_DateRequested.LocationFloat = New DevExpress.Utils.PointFloat(191.6667!, 0!)
            Me.LabelDetail_DateRequested.Multiline = True
            Me.LabelDetail_DateRequested.Name = "LabelDetail_DateRequested"
            Me.LabelDetail_DateRequested.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DateRequested.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_DateRequested.SizeF = New System.Drawing.SizeF(188.5416!, 18.99999!)
            Me.LabelDetail_DateRequested.Text = "LabelDetail_DateRequested"
            Me.LabelDetail_DateRequested.TextFormatString = "{0:MM/dd/yyyy}"
            '
            'LabelDetail_DateRequestedLabel
            '
            Me.LabelDetail_DateRequestedLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateRequestedLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateRequestedLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateRequestedLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateRequestedLabel.CanGrow = False
            Me.LabelDetail_DateRequestedLabel.CanShrink = True
            Me.LabelDetail_DateRequestedLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_DateRequestedLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateRequestedLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_DateRequestedLabel.Name = "LabelDetail_DateRequestedLabel"
            Me.LabelDetail_DateRequestedLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateRequestedLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_DateRequestedLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_DateRequestedLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateRequestedLabel.StylePriority.UsePadding = False
            Me.LabelDetail_DateRequestedLabel.Text = "Date Requested:"
            Me.LabelDetail_DateRequestedLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateAvailsDueLabel
            '
            Me.LabelDetail_DateAvailsDueLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateAvailsDueLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateAvailsDueLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateAvailsDueLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateAvailsDueLabel.CanGrow = False
            Me.LabelDetail_DateAvailsDueLabel.CanShrink = True
            Me.LabelDetail_DateAvailsDueLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_DateAvailsDueLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateAvailsDueLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.99999!)
            Me.LabelDetail_DateAvailsDueLabel.Name = "LabelDetail_DateAvailsDueLabel"
            Me.LabelDetail_DateAvailsDueLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateAvailsDueLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_DateAvailsDueLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_DateAvailsDueLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateAvailsDueLabel.StylePriority.UsePadding = False
            Me.LabelDetail_DateAvailsDueLabel.Text = "Date Avails Due:"
            Me.LabelDetail_DateAvailsDueLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_MarketLabel
            '
            Me.LabelDetail_MarketLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_MarketLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_MarketLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_MarketLabel.BorderWidth = 1.0!
            Me.LabelDetail_MarketLabel.CanGrow = False
            Me.LabelDetail_MarketLabel.CanShrink = True
            Me.LabelDetail_MarketLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_MarketLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_MarketLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 51.66667!)
            Me.LabelDetail_MarketLabel.Name = "LabelDetail_MarketLabel"
            Me.LabelDetail_MarketLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_MarketLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_MarketLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_MarketLabel.StylePriority.UseFont = False
            Me.LabelDetail_MarketLabel.StylePriority.UsePadding = False
            Me.LabelDetail_MarketLabel.Text = "Market:"
            Me.LabelDetail_MarketLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_SecondaryTargetAudiencesLabel
            '
            Me.LabelDetail_SecondaryTargetAudiencesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_SecondaryTargetAudiencesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_SecondaryTargetAudiencesLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_SecondaryTargetAudiencesLabel.BorderWidth = 1.0!
            Me.LabelDetail_SecondaryTargetAudiencesLabel.CanGrow = False
            Me.LabelDetail_SecondaryTargetAudiencesLabel.CanShrink = True
            Me.LabelDetail_SecondaryTargetAudiencesLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_SecondaryTargetAudiencesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_SecondaryTargetAudiencesLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 121.0833!)
            Me.LabelDetail_SecondaryTargetAudiencesLabel.Name = "LabelDetail_SecondaryTargetAudiencesLabel"
            Me.LabelDetail_SecondaryTargetAudiencesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_SecondaryTargetAudiencesLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_SecondaryTargetAudiencesLabel.SizeF = New System.Drawing.SizeF(191.6667!, 19.0!)
            Me.LabelDetail_SecondaryTargetAudiencesLabel.StylePriority.UseFont = False
            Me.LabelDetail_SecondaryTargetAudiencesLabel.StylePriority.UsePadding = False
            Me.LabelDetail_SecondaryTargetAudiencesLabel.Text = "Secondary Target Audience(s):"
            Me.LabelDetail_SecondaryTargetAudiencesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.LinePageFooter})
            Me.PageFooter.HeightF = 25.08335!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrPageInfo1
            '
            Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(614.5417!, 4.083379!)
            Me.XrPageInfo1.Name = "XrPageInfo1"
            Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.XrPageInfo1.StylePriority.UseFont = False
            Me.XrPageInfo1.StylePriority.UseTextAlignment = False
            Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrPageInfo1.TextFormatString = "Page {0} of {1}"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4.0!
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelPageHeader_LocationHeader
            '
            Me.LabelPageHeader_LocationHeader.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_LocationHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_LocationHeader.BorderWidth = 1.0!
            Me.LabelPageHeader_LocationHeader.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.LabelPageHeader_LocationHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 150.0!)
            Me.LabelPageHeader_LocationHeader.Name = "LabelPageHeader_LocationHeader"
            Me.LabelPageHeader_LocationHeader.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.LabelPageHeader_LocationHeader.StylePriority.UseBackColor = False
            Me.LabelPageHeader_LocationHeader.StylePriority.UsePadding = False
            Me.LabelPageHeader_LocationHeader.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.LabelPageHeader_LocationHeader.Summary = XrSummary1
            Me.LabelPageHeader_LocationHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxHeaderLogo, Me.LabelPageHeader_LocationHeader})
            Me.ReportHeader.HeightF = 190.9583!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.DTO.Media.RFP.RFPReport)
            '
            'RequestForProposalReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.ReportHeader})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.XrRichTextDetail_AdditionalGuidelines, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents LabelPageHeader_LocationHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents LabelDetail_DateRequested As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateRequestedLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TargetAudienceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_RatingsSourceLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DateAvailsDue As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateAvailsDueLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_MarketLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_SecondaryTargetAudiencesLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DaypartLengthLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Daypart As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_SecondaryTargetAudiences As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TargetAudience As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_RatingsSource As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_MarketDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GRPGoal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CPPGoal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_FlightDates As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AdditionalGuidelinesLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GRPGoalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CPPGoalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_FlightDatesLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrRichTextDetail_AdditionalGuidelines As DevExpress.XtraReports.UI.XRRichText
    End Class

End Namespace
