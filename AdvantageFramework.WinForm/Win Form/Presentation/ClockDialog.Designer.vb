Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClockDialog
        Inherits DevComponents.DotNetBar.Balloon

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then

                    _LockTimerCounter = True

                    If Timer IsNot Nothing Then

                        Timer.Stop()
                        Timer.Dispose()
                        Timer = Nothing

                    End If

                    components.Dispose()

                End If

            Finally
                MyBase.Dispose(disposing)
            End Try

        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.GaugeControl = New DevExpress.XtraGauges.Win.GaugeControl()
            Me.DigitalGauge = New DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge()
            Me.DigitalBackgroundLayerComponent = New DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent()
            Me.Timer = New System.Windows.Forms.Timer(Me.components)
            CType(Me.DigitalGauge, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DigitalBackgroundLayerComponent, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GaugeControl
            '
            Me.GaugeControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GaugeControl.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.DigitalGauge})
            Me.GaugeControl.Location = New System.Drawing.Point(12, 26)
            Me.GaugeControl.Name = "GaugeControl"
            Me.GaugeControl.Size = New System.Drawing.Size(284, 90)
            Me.GaugeControl.TabIndex = 0
            '
            'DigitalGauge
            '
            Me.DigitalGauge.AppearanceOff.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#EAECF1")
            Me.DigitalGauge.AppearanceOn.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#7184BA")
            Me.DigitalGauge.BackgroundLayers.AddRange(New DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent() {Me.DigitalBackgroundLayerComponent})
            Me.DigitalGauge.Bounds = New System.Drawing.Rectangle(6, 6, 272, 78)
            Me.DigitalGauge.DigitCount = 5
            Me.DigitalGauge.Name = "DigitalGauge"
            Me.DigitalGauge.Padding = New DevExpress.XtraGauges.Core.Base.TextSpacing(26, 20, 26, 20)
            Me.DigitalGauge.Text = "00,000"
            '
            'DigitalBackgroundLayerComponent
            '
            Me.DigitalBackgroundLayerComponent.BottomRight = New DevExpress.XtraGauges.Core.Base.PointF2D(265.8125!, 99.9625!)
            Me.DigitalBackgroundLayerComponent.Name = "digitalBackgroundLayerComponent1"
            Me.DigitalBackgroundLayerComponent.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style16
            Me.DigitalBackgroundLayerComponent.TopLeft = New DevExpress.XtraGauges.Core.Base.PointF2D(26.0!, 0.0!)
            Me.DigitalBackgroundLayerComponent.ZOrder = 1000
            '
            'Timer
            '
            Me.Timer.Interval = 500
            '
            'ClockDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.BackColor2 = System.Drawing.Color.White
            Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(122, Byte), Integer))
            Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ClientSize = New System.Drawing.Size(308, 128)
            Me.Controls.Add(Me.GaugeControl)
            Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "ClockDialog"
            Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
            CType(Me.DigitalGauge, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DigitalBackgroundLayerComponent, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GaugeControl As DevExpress.XtraGauges.Win.GaugeControl
        Friend WithEvents DigitalGauge As DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge
        Private WithEvents DigitalBackgroundLayerComponent As DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent
        Friend WithEvents Timer As System.Windows.Forms.Timer
    End Class

End Namespace
