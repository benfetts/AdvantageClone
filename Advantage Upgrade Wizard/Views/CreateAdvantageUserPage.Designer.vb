Partial Public Class CreateAdvantageUserPage
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
        Me.SimpleButtonForm_Select = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditForm_Password = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButtonForm_Create = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditForm_User = New DevExpress.XtraEditors.TextEdit()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.TextEditForm_Password.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditForm_User.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.Controls.Add(Me.SimpleButtonForm_Select)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_Password)
        Me.layoutControl1.Controls.Add(Me.SimpleButtonForm_Create)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_User)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(3305, 352, 750, 600)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(1121, 370)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'SimpleButtonForm_Select
        '
        Me.SimpleButtonForm_Select.Location = New System.Drawing.Point(42, 326)
        Me.SimpleButtonForm_Select.Name = "SimpleButtonForm_Select"
        Me.SimpleButtonForm_Select.Size = New System.Drawing.Size(516, 22)
        Me.SimpleButtonForm_Select.StyleController = Me.layoutControl1
        Me.SimpleButtonForm_Select.TabIndex = 10
        Me.SimpleButtonForm_Select.Text = "Select"
        '
        'TextEditForm_Password
        '
        Me.TextEditForm_Password.Location = New System.Drawing.Point(70, 203)
        Me.TextEditForm_Password.Name = "TextEditForm_Password"
        Me.TextEditForm_Password.Properties.UseSystemPasswordChar = True
        Me.TextEditForm_Password.Size = New System.Drawing.Size(981, 20)
        Me.TextEditForm_Password.StyleController = Me.layoutControl1
        Me.TextEditForm_Password.TabIndex = 9
        '
        'SimpleButtonForm_Create
        '
        Me.SimpleButtonForm_Create.Location = New System.Drawing.Point(562, 326)
        Me.SimpleButtonForm_Create.Name = "SimpleButtonForm_Create"
        Me.SimpleButtonForm_Create.Size = New System.Drawing.Size(517, 22)
        Me.SimpleButtonForm_Create.StyleController = Me.layoutControl1
        Me.SimpleButtonForm_Create.TabIndex = 8
        Me.SimpleButtonForm_Create.Text = "Create"
        '
        'TextEditForm_User
        '
        Me.TextEditForm_User.EditValue = ""
        Me.TextEditForm_User.Location = New System.Drawing.Point(70, 107)
        Me.TextEditForm_User.Name = "TextEditForm_User"
        Me.TextEditForm_User.Size = New System.Drawing.Size(981, 20)
        Me.TextEditForm_User.StyleController = Me.layoutControl1
        Me.TextEditForm_User.TabIndex = 4
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.simpleLabelItem1, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.EmptySpaceItem2, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleLabelItem2})
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
        Me.simpleLabelItem1.Text = "Select / Create Advantage Connection User/Login"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(481, 30)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 253)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1041, 71)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextEditForm_User
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 61)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 30, 30, 30)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1041, 96)
        Me.LayoutControlItem1.Text = "Login/User:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(481, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButtonForm_Create
        Me.LayoutControlItem5.Location = New System.Drawing.Point(520, 324)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(521, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 51)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1041, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextEditForm_Password
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 157)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 30, 30, 30)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1041, 96)
        Me.LayoutControlItem2.Text = "Password:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(481, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButtonForm_Select
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(520, 26)
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
        Me.SimpleLabelItem2.Text = "Need to provide existing or new SQL login that will be used to connect Advantage " &
    "to your database."
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(481, 13)
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'CreateAdvantageUserPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "CreateAdvantageUserPage"
        Me.Size = New System.Drawing.Size(1121, 370)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.TextEditForm_Password.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditForm_User.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents TextEditForm_User As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButtonForm_Create As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextEditForm_Password As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents SimpleButtonForm_Select As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
End Class
