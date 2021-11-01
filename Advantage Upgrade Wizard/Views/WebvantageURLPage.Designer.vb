Partial Public Class WebvantageURLPage
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
        Me.components = New System.ComponentModel.Container()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButtonForm_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditForm_WVURL = New DevExpress.XtraEditors.TextEdit()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.TextEditForm_WVURL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.SimpleButtonForm_Save)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_WVURL)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(3305, 352, 750, 600)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'SimpleButtonForm_Save
        '
        Me.SimpleButtonForm_Save.Location = New System.Drawing.Point(42, 326)
        Me.SimpleButtonForm_Save.Name = "SimpleButtonForm_Save"
        Me.SimpleButtonForm_Save.Size = New System.Drawing.Size(1037, 22)
        Me.SimpleButtonForm_Save.StyleController = Me.layoutControl1
        Me.SimpleButtonForm_Save.TabIndex = 10
        Me.SimpleButtonForm_Save.Text = "Save"
        '
        'TextEditForm_WVURL
        '
        Me.TextEditForm_WVURL.EditValue = ""
        Me.TextEditForm_WVURL.Location = New System.Drawing.Point(70, 171)
        Me.TextEditForm_WVURL.Name = "TextEditForm_WVURL"
        Me.TextEditForm_WVURL.Size = New System.Drawing.Size(981, 20)
        Me.TextEditForm_WVURL.StyleController = Me.layoutControl1
        Me.TextEditForm_WVURL.TabIndex = 4
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.simpleLabelItem1, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.SimpleLabelItem2})
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
        Me.simpleLabelItem1.CustomizationFormText = "Select \ Create Advantage User"
        Me.simpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.simpleLabelItem1.Name = "simpleLabelItem1"
        Me.simpleLabelItem1.Size = New System.Drawing.Size(1041, 34)
        Me.simpleLabelItem1.Text = "Webvantage URL"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(201, 30)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 221)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1041, 103)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextEditForm_WVURL
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 125)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 30, 30, 30)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1041, 96)
        Me.LayoutControlItem1.Text = "Webvantage URL:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(201, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 51)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1041, 74)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButtonForm_Save
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1041, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(0, 34)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(50, 2, 2, 2)
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(1041, 17)
        Me.SimpleLabelItem2.Text = "Need to provide a valid Webvantage URL "
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(201, 13)
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'WebvantageURLPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "WebvantageURLPage"
        Me.Size = New System.Drawing.Size(1121, 370)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.TextEditForm_WVURL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents TextEditForm_WVURL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents SimpleButtonForm_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
End Class
