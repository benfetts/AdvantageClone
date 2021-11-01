Imports Microsoft.VisualBasic
Imports System
Partial Public Class StartPage
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl_LeftPanel = New System.Windows.Forms.Panel()
        Me.LabelControl_Headline = New DevExpress.XtraEditors.LabelControl()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.emptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleLabelItem3 = New DevExpress.XtraLayout.SimpleLabelItem()
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.labelControl3)
        Me.layoutControl1.Controls.Add(Me.labelControl2)
        Me.layoutControl1.Controls.Add(Me.PanelControl_LeftPanel)
        Me.layoutControl1.Controls.Add(Me.LabelControl_Headline)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1594, 189, 650, 400)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(840, 500)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'labelControl3
        '
        Me.labelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl3.Appearance.Options.UseFont = True
        Me.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControl3.Location = New System.Drawing.Point(269, 455)
        Me.labelControl3.Name = "labelControl3"
        Me.labelControl3.Padding = New System.Windows.Forms.Padding(30, 10, 10, 10)
        Me.labelControl3.Size = New System.Drawing.Size(559, 33)
        Me.labelControl3.StyleController = Me.layoutControl1
        Me.labelControl3.TabIndex = 7
        Me.labelControl3.Text = "Click Next to continue"
        '
        'labelControl2
        '
        Me.labelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl2.Appearance.Options.UseFont = True
        Me.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControl2.Location = New System.Drawing.Point(269, 66)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Padding = New System.Windows.Forms.Padding(30, 10, 10, 10)
        Me.labelControl2.Size = New System.Drawing.Size(559, 35)
        Me.labelControl2.StyleController = Me.layoutControl1
        Me.labelControl2.TabIndex = 6
        Me.labelControl2.Text = "Follow the simple steps in the setup Wizard to complete the installation."
        '
        'PanelControl_LeftPanel
        '
        Me.PanelControl_LeftPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.PanelControl_LeftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelControl_LeftPanel.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl_LeftPanel.Name = "PanelControl_LeftPanel"
        Me.PanelControl_LeftPanel.Size = New System.Drawing.Size(253, 476)
        Me.PanelControl_LeftPanel.TabIndex = 5
        '
        'LabelControl_Headline
        '
        Me.LabelControl_Headline.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl_Headline.Appearance.Options.UseFont = True
        Me.LabelControl_Headline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl_Headline.Location = New System.Drawing.Point(269, 12)
        Me.LabelControl_Headline.Name = "LabelControl_Headline"
        Me.LabelControl_Headline.Padding = New System.Windows.Forms.Padding(30, 10, 10, 10)
        Me.LabelControl_Headline.Size = New System.Drawing.Size(559, 50)
        Me.LabelControl_Headline.StyleController = Me.layoutControl1
        Me.LabelControl_Headline.TabIndex = 4
        Me.LabelControl_Headline.Text = "Welcome to the Advantage Upgrade Wizard"
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.emptySpaceItem2, Me.layoutControlItem3, Me.layoutControlItem4, Me.SimpleLabelItem1, Me.SimpleLabelItem2, Me.SimpleLabelItem3})
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(840, 500)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.LabelControl_Headline
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(257, 0)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Size = New System.Drawing.Size(563, 54)
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.PanelControl_LeftPanel
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem2.MaxSize = New System.Drawing.Size(257, 0)
        Me.layoutControlItem2.MinSize = New System.Drawing.Size(257, 24)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(257, 480)
        Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.Location = New System.Drawing.Point(257, 156)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(563, 287)
        Me.emptySpaceItem2.StartNewLine = True
        Me.emptySpaceItem2.Text = "Advantage Administrator Login"
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.labelControl2
        Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem3.Location = New System.Drawing.Point(257, 54)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Size = New System.Drawing.Size(563, 39)
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem3.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.labelControl3
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(257, 443)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(563, 37)
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleLabelItem1.AppearanceItemCaption.Options.UseFont = True
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(257, 93)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(50, 2, 2, 2)
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(563, 29)
        Me.SimpleLabelItem1.Text = "Prerequisites"
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(291, 25)
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(257, 122)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(563, 17)
        Me.SimpleLabelItem2.StartNewLine = True
        Me.SimpleLabelItem2.Text = "Functional Webvantage Deployment"
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(291, 13)
        '
        'emptySpaceItem3
        '
        Me.emptySpaceItem3.AllowHotTrack = False
        Me.emptySpaceItem3.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem3.Location = New System.Drawing.Point(206, 0)
        Me.emptySpaceItem3.Name = "emptySpaceItem2"
        Me.emptySpaceItem3.Size = New System.Drawing.Size(882, 406)
        Me.emptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleLabelItem3
        '
        Me.SimpleLabelItem3.AllowHotTrack = False
        Me.SimpleLabelItem3.Location = New System.Drawing.Point(257, 139)
        Me.SimpleLabelItem3.Name = "SimpleLabelItem3"
        Me.SimpleLabelItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.SimpleLabelItem3.Size = New System.Drawing.Size(563, 17)
        Me.SimpleLabelItem3.Text = "SQL Server Login with Server Admin rights to the SQL Server"
        Me.SimpleLabelItem3.TextSize = New System.Drawing.Size(291, 13)
        '
        'StartPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "StartPage"
        Me.Size = New System.Drawing.Size(840, 500)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private LabelControl_Headline As DevExpress.XtraEditors.LabelControl
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Private labelControl3 As DevExpress.XtraEditors.LabelControl
    Private labelControl2 As DevExpress.XtraEditors.LabelControl
    Private PanelControl_LeftPanel As System.Windows.Forms.Panel
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem3 As DevExpress.XtraLayout.SimpleLabelItem
End Class
