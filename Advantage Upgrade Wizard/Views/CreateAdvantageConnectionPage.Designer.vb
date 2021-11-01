Partial Public Class CreateAdvantageConnectionPage
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
        Me.ButtonEditForm_Folder = New DevExpress.XtraEditors.ButtonEdit()
        Me.SimpleButtonForm_Create = New DevExpress.XtraEditors.SimpleButton()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem3 = New DevExpress.XtraLayout.SimpleLabelItem()
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.ButtonEditForm_Folder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.ButtonEditForm_Folder)
        Me.layoutControl1.Controls.Add(Me.SimpleButtonForm_Create)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1469, 300, 450, 350)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'ButtonEditForm_Folder
        '
        Me.ButtonEditForm_Folder.Location = New System.Drawing.Point(60, 145)
        Me.ButtonEditForm_Folder.Name = "ButtonEditForm_Folder"
        Me.ButtonEditForm_Folder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ButtonEditForm_Folder.Size = New System.Drawing.Size(1001, 20)
        Me.ButtonEditForm_Folder.StyleController = Me.layoutControl1
        Me.ButtonEditForm_Folder.TabIndex = 9
        '
        'SimpleButtonForm_Create
        '
        Me.SimpleButtonForm_Create.Location = New System.Drawing.Point(42, 326)
        Me.SimpleButtonForm_Create.Name = "SimpleButtonForm_Create"
        Me.SimpleButtonForm_Create.Size = New System.Drawing.Size(1037, 22)
        Me.SimpleButtonForm_Create.StyleController = Me.layoutControl1
        Me.SimpleButtonForm_Create.TabIndex = 8
        Me.SimpleButtonForm_Create.Text = "Create"
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.simpleLabelItem1, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.EmptySpaceItem2, Me.SimpleLabelItem2, Me.LayoutControlItem1, Me.SimpleLabelItem3})
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 20)
        Me.layoutControlGroup1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControlGroup1.TextVisible = False
        '
        'simpleLabelItem1
        '
        Me.simpleLabelItem1.AllowHotTrack = False
        Me.simpleLabelItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold)
        Me.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = True
        Me.simpleLabelItem1.CustomizationFormText = "Create Advantage Connection"
        Me.simpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.simpleLabelItem1.Name = "simpleLabelItem1"
        Me.simpleLabelItem1.Size = New System.Drawing.Size(1041, 34)
        Me.simpleLabelItem1.Text = "Create Advantage Connection"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(372, 30)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 185)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1041, 139)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButtonForm_Create
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1041, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 51)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1041, 41)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(0, 34)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(1041, 17)
        Me.SimpleLabelItem2.Text = "Skip This By Clicking Next"
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(372, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ButtonEditForm_Folder
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 109)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1041, 76)
        Me.LayoutControlItem1.Text = "Folder:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(372, 13)
        '
        'SimpleLabelItem3
        '
        Me.SimpleLabelItem3.AllowHotTrack = False
        Me.SimpleLabelItem3.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleLabelItem3.AppearanceItemCaption.Options.UseFont = True
        Me.SimpleLabelItem3.AppearanceItemCaption.Options.UseTextOptions = True
        Me.SimpleLabelItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleLabelItem3.Location = New System.Drawing.Point(0, 92)
        Me.SimpleLabelItem3.Name = "SimpleLabelItem3"
        Me.SimpleLabelItem3.Size = New System.Drawing.Size(1041, 17)
        Me.SimpleLabelItem3.Text = "Please select the msbin folder of the Advantage installation below"
        Me.SimpleLabelItem3.TextSize = New System.Drawing.Size(372, 13)
        '
        'CreateAdvantageConnectionPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "CreateAdvantageConnectionPage"
        Me.Size = New System.Drawing.Size(1121, 370)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.ButtonEditForm_Folder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButtonForm_Create As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents ButtonEditForm_Folder As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem3 As DevExpress.XtraLayout.SimpleLabelItem
End Class
