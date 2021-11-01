<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptTest 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptTest))
        Dim SqlDBDataSource1 As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitle = New DataDynamics.ActiveReports.Label
        Me.Picture1 = New DataDynamics.ActiveReports.Picture
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtEMP_LNAME1 = New DataDynamics.ActiveReports.TextBox
        Me.txtEMP_FNAME1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEMP_LNAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEMP_FNAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitle, Me.Picture1, Me.Line1})
        Me.PageHeader1.Height = 0.78125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblTitle
        '
        Me.lblTitle.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitle.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitle.Border.RightColor = System.Drawing.Color.Black
        Me.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitle.Border.TopColor = System.Drawing.Color.Black
        Me.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitle.Height = 0.25!
        Me.lblTitle.HyperLink = Nothing
        Me.lblTitle.Left = 0.6875!
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Style = "font-weight: bold; font-size: 14pt; "
        Me.lblTitle.Text = "Employee List"
        Me.lblTitle.Top = 0.3125!
        Me.lblTitle.Width = 4.4375!
        '
        'Picture1
        '
        Me.Picture1.Border.BottomColor = System.Drawing.Color.Black
        Me.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.LeftColor = System.Drawing.Color.Black
        Me.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.RightColor = System.Drawing.Color.Black
        Me.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.TopColor = System.Drawing.Color.Black
        Me.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Height = 0.5625!
        Me.Picture1.Image = Nothing
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0!
        Me.Picture1.LineWeight = 0.0!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 0.5625!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.75!
        Me.Line1.Width = 6.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 6.4375!
        Me.Line1.Y1 = 0.75!
        Me.Line1.Y2 = 0.75!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEMP_LNAME1, Me.txtEMP_FNAME1})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'txtEMP_LNAME1
        '
        Me.txtEMP_LNAME1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEMP_LNAME1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_LNAME1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEMP_LNAME1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_LNAME1.Border.RightColor = System.Drawing.Color.Black
        Me.txtEMP_LNAME1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_LNAME1.Border.TopColor = System.Drawing.Color.Black
        Me.txtEMP_LNAME1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_LNAME1.DataField = "EMP_LNAME"
        Me.txtEMP_LNAME1.Height = 0.1875!
        Me.txtEMP_LNAME1.Left = 0.25!
        Me.txtEMP_LNAME1.Name = "txtEMP_LNAME1"
        Me.txtEMP_LNAME1.Style = ""
        Me.txtEMP_LNAME1.Text = "txtEMP_LNAME1"
        Me.txtEMP_LNAME1.Top = 0.0!
        Me.txtEMP_LNAME1.Width = 1.5!
        '
        'txtEMP_FNAME1
        '
        Me.txtEMP_FNAME1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEMP_FNAME1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_FNAME1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEMP_FNAME1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_FNAME1.Border.RightColor = System.Drawing.Color.Black
        Me.txtEMP_FNAME1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_FNAME1.Border.TopColor = System.Drawing.Color.Black
        Me.txtEMP_FNAME1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEMP_FNAME1.DataField = "EMP_FNAME"
        Me.txtEMP_FNAME1.Height = 0.1875!
        Me.txtEMP_FNAME1.Left = 2.3125!
        Me.txtEMP_FNAME1.Name = "txtEMP_FNAME1"
        Me.txtEMP_FNAME1.Style = ""
        Me.txtEMP_FNAME1.Text = "txtEMP_FNAME1"
        Me.txtEMP_FNAME1.Top = 0.0!
        Me.txtEMP_FNAME1.Width = 2.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'arptTest
        '
        Me.MasterReport = False
        SqlDBDataSource1.ConnectionString = "data source=JIMSERVER;initial catalog=WVDEV2006V1B;password=advan;persist securit" & _
            "y info=True;user id=sa"
        SqlDBDataSource1.SQL = "Select * from EMPLOYEE"
        Me.DataSource = SqlDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEMP_LNAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEMP_FNAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtEMP_LNAME1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEMP_FNAME1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class 
