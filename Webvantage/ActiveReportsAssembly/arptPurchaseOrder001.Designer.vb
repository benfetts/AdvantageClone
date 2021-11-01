<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptPurchaseOrder001 
    Inherits DataDynamics.ActiveReports.ActiveReport

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'Required by the ActiveReports Designer
    Private components As System.ComponentModel.IContainer
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(arptPurchaseOrder001))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.RichTextBox1 = New DataDynamics.ActiveReports.RichTextBox
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.RichTextBox1})
        Me.PageHeader1.Height = 2.28125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 2.0!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoReplaceFields = True
        Me.RichTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.RichTextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RichTextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RichTextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RichTextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.RichTextBox1.CanShrink = True
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox1.Location = CType(resources.GetObject("RichTextBox1.Location"), System.Drawing.PointF)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.RTF = resources.GetString("RichTextBox1.RTF")
        Me.RichTextBox1.SelectedText = ""
        Me.RichTextBox1.SelectionBackColor = System.Drawing.Color.Empty
        Me.RichTextBox1.SelectionBullet = False
        Me.RichTextBox1.SelectionCharOffset = 0.0!
        Me.RichTextBox1.SelectionColor = System.Drawing.Color.Empty
        Me.RichTextBox1.SelectionFont = New System.Drawing.Font("Arial", 10.0!)
        Me.RichTextBox1.SelectionHangingIndent = 0.0!
        Me.RichTextBox1.SelectionIndent = 0.0!
        Me.RichTextBox1.SelectionLength = 0
        Me.RichTextBox1.SelectionRightIndent = 0.0!
        Me.RichTextBox1.SelectionStart = 0
        Me.RichTextBox1.Size = New System.Drawing.SizeF(7.375!, 1.5!)
        '
        'arptPurchaseOrder001
        '
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)

    End Sub
    Friend WithEvents RichTextBox1 As DataDynamics.ActiveReports.RichTextBox
End Class 
