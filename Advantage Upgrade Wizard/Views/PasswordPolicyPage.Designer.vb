Partial Public Class PasswordPolicyPage
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButtonSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SpinEditMinPasswordLength = New DevExpress.XtraEditors.SpinEdit()
        Me.SpinEditCheckPreviousPasswordHistoryCount = New DevExpress.XtraEditors.SpinEdit()
        Me.CheckEditPasswordComplexityRequired = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditUppercaseRequired = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditLowercaseRequired = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditSpecialCharacterRequired = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditNumberRequired = New DevExpress.XtraEditors.CheckEdit()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.SpinEditMinPasswordLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinEditCheckPreviousPasswordHistoryCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditPasswordComplexityRequired.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditUppercaseRequired.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditLowercaseRequired.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditSpecialCharacterRequired.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditNumberRequired.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.AutoScroll = False
        Me.layoutControl1.Controls.Add(Me.SimpleButtonSave)
        Me.layoutControl1.Controls.Add(Me.SpinEditMinPasswordLength)
        Me.layoutControl1.Controls.Add(Me.SpinEditCheckPreviousPasswordHistoryCount)
        Me.layoutControl1.Controls.Add(Me.CheckEditPasswordComplexityRequired)
        Me.layoutControl1.Controls.Add(Me.CheckEditUppercaseRequired)
        Me.layoutControl1.Controls.Add(Me.CheckEditLowercaseRequired)
        Me.layoutControl1.Controls.Add(Me.CheckEditSpecialCharacterRequired)
        Me.layoutControl1.Controls.Add(Me.CheckEditNumberRequired)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1469, 300, 450, 350)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(840, 500)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'SimpleButtonSave
        '
        Me.SimpleButtonSave.Location = New System.Drawing.Point(42, 456)
        Me.SimpleButtonSave.Name = "SimpleButtonSave"
        Me.SimpleButtonSave.Size = New System.Drawing.Size(756, 22)
        Me.SimpleButtonSave.StyleController = Me.layoutControl1
        Me.SimpleButtonSave.TabIndex = 7
        Me.SimpleButtonSave.Text = "Save"
        '
        'SpinEditMinPasswordLength
        '
        Me.SpinEditMinPasswordLength.EditValue = New Decimal(New Integer() {6, 0, 0, 0})
        Me.SpinEditMinPasswordLength.Location = New System.Drawing.Point(280, 139)
        Me.SpinEditMinPasswordLength.Name = "SpinEditMinPasswordLength"
        Me.SpinEditMinPasswordLength.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.SpinEditMinPasswordLength.Properties.IsFloatValue = False
        Me.SpinEditMinPasswordLength.Properties.Mask.EditMask = "N00"
        Me.SpinEditMinPasswordLength.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SpinEditMinPasswordLength.Properties.MaxValue = New Decimal(New Integer() {20, 0, 0, 0})
        Me.SpinEditMinPasswordLength.Size = New System.Drawing.Size(518, 20)
        Me.SpinEditMinPasswordLength.StyleController = Me.layoutControl1
        Me.SpinEditMinPasswordLength.TabIndex = 0
        '
        'SpinEditCheckPreviousPasswordHistoryCount
        '
        Me.SpinEditCheckPreviousPasswordHistoryCount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SpinEditCheckPreviousPasswordHistoryCount.Location = New System.Drawing.Point(280, 163)
        Me.SpinEditCheckPreviousPasswordHistoryCount.Name = "SpinEditCheckPreviousPasswordHistoryCount"
        Me.SpinEditCheckPreviousPasswordHistoryCount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.SpinEditCheckPreviousPasswordHistoryCount.Properties.IsFloatValue = False
        Me.SpinEditCheckPreviousPasswordHistoryCount.Properties.Mask.EditMask = "N00"
        Me.SpinEditCheckPreviousPasswordHistoryCount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SpinEditCheckPreviousPasswordHistoryCount.Properties.MaxValue = New Decimal(New Integer() {24, 0, 0, 0})
        Me.SpinEditCheckPreviousPasswordHistoryCount.Size = New System.Drawing.Size(518, 20)
        Me.SpinEditCheckPreviousPasswordHistoryCount.StyleController = Me.layoutControl1
        Me.SpinEditCheckPreviousPasswordHistoryCount.TabIndex = 1
        '
        'CheckEditPasswordComplexityRequired
        '
        Me.CheckEditPasswordComplexityRequired.EditValue = True
        Me.CheckEditPasswordComplexityRequired.Location = New System.Drawing.Point(42, 188)
        Me.CheckEditPasswordComplexityRequired.Name = "CheckEditPasswordComplexityRequired"
        Me.CheckEditPasswordComplexityRequired.Properties.Caption = "Password Complexity Required"
        Me.CheckEditPasswordComplexityRequired.Size = New System.Drawing.Size(756, 19)
        Me.CheckEditPasswordComplexityRequired.StyleController = Me.layoutControl1
        Me.CheckEditPasswordComplexityRequired.TabIndex = 2
        '
        'CheckEditUppercaseRequired
        '
        Me.CheckEditUppercaseRequired.AutoSizeInLayoutControl = True
        Me.CheckEditUppercaseRequired.EditValue = True
        Me.CheckEditUppercaseRequired.Location = New System.Drawing.Point(140, 211)
        Me.CheckEditUppercaseRequired.Name = "CheckEditUppercaseRequired"
        Me.CheckEditUppercaseRequired.Properties.Caption = "Uppercase Required"
        Me.CheckEditUppercaseRequired.Size = New System.Drawing.Size(119, 19)
        Me.CheckEditUppercaseRequired.StyleController = Me.layoutControl1
        Me.CheckEditUppercaseRequired.TabIndex = 3
        '
        'CheckEditLowercaseRequired
        '
        Me.CheckEditLowercaseRequired.AutoSizeInLayoutControl = True
        Me.CheckEditLowercaseRequired.EditValue = True
        Me.CheckEditLowercaseRequired.Location = New System.Drawing.Point(140, 234)
        Me.CheckEditLowercaseRequired.Name = "CheckEditLowercaseRequired"
        Me.CheckEditLowercaseRequired.Properties.Caption = "Lowercase Required"
        Me.CheckEditLowercaseRequired.Size = New System.Drawing.Size(119, 19)
        Me.CheckEditLowercaseRequired.StyleController = Me.layoutControl1
        Me.CheckEditLowercaseRequired.TabIndex = 4
        '
        'CheckEditSpecialCharacterRequired
        '
        Me.CheckEditSpecialCharacterRequired.AutoSizeInLayoutControl = True
        Me.CheckEditSpecialCharacterRequired.Location = New System.Drawing.Point(140, 280)
        Me.CheckEditSpecialCharacterRequired.Name = "CheckEditSpecialCharacterRequired"
        Me.CheckEditSpecialCharacterRequired.Properties.Caption = "Special Character Required"
        Me.CheckEditSpecialCharacterRequired.Size = New System.Drawing.Size(152, 19)
        Me.CheckEditSpecialCharacterRequired.StyleController = Me.layoutControl1
        Me.CheckEditSpecialCharacterRequired.TabIndex = 6
        '
        'CheckEditNumberRequired
        '
        Me.CheckEditNumberRequired.AutoSizeInLayoutControl = True
        Me.CheckEditNumberRequired.EditValue = True
        Me.CheckEditNumberRequired.Location = New System.Drawing.Point(140, 257)
        Me.CheckEditNumberRequired.Name = "CheckEditNumberRequired"
        Me.CheckEditNumberRequired.Properties.Caption = "Number Required"
        Me.CheckEditNumberRequired.Size = New System.Drawing.Size(105, 19)
        Me.CheckEditNumberRequired.StyleController = Me.layoutControl1
        Me.CheckEditNumberRequired.TabIndex = 5
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.simpleLabelItem1, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.SimpleSeparator1, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem7})
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 20)
        Me.layoutControlGroup1.Size = New System.Drawing.Size(840, 500)
        Me.layoutControlGroup1.StartNewLine = True
        Me.layoutControlGroup1.TextVisible = False
        '
        'simpleLabelItem1
        '
        Me.simpleLabelItem1.AllowHotTrack = False
        Me.simpleLabelItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold)
        Me.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = True
        Me.simpleLabelItem1.CustomizationFormText = "Password Policy Options"
        Me.simpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.simpleLabelItem1.Name = "simpleLabelItem1"
        Me.simpleLabelItem1.Size = New System.Drawing.Size(760, 34)
        Me.simpleLabelItem1.Text = "Password Policy Options"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(235, 30)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButtonSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 454)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(760, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CheckEditUppercaseRequired
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 209)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(760, 23)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CheckEditPasswordComplexityRequired
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 186)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(760, 23)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SpinEditMinPasswordLength
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 137)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(760, 24)
        Me.LayoutControlItem1.Text = "Min Password Length"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(235, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SpinEditCheckPreviousPasswordHistoryCount
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 161)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(760, 24)
        Me.LayoutControlItem2.Text = "Check Previous Password History Count"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(235, 13)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 185)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(760, 1)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 301)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(760, 153)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 34)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(760, 103)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.CheckEditLowercaseRequired
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 232)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(760, 23)
        Me.LayoutControlItem6.Text = "LayoutControlItem4"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CheckEditNumberRequired
        Me.LayoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 255)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(760, 23)
        Me.LayoutControlItem8.Text = "LayoutControlItem4"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.CheckEditSpecialCharacterRequired
        Me.LayoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 278)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(100, 2, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(760, 23)
        Me.LayoutControlItem7.Text = "LayoutControlItem4"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'PasswordPolicyPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "PasswordPolicyPage"
        Me.Size = New System.Drawing.Size(840, 500)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.SpinEditMinPasswordLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinEditCheckPreviousPasswordHistoryCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditPasswordComplexityRequired.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditUppercaseRequired.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditLowercaseRequired.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditSpecialCharacterRequired.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditNumberRequired.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButtonSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents SpinEditMinPasswordLength As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents SpinEditCheckPreviousPasswordHistoryCount As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents CheckEditPasswordComplexityRequired As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckEditUppercaseRequired As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CheckEditLowercaseRequired As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEditSpecialCharacterRequired As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEditNumberRequired As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
End Class
