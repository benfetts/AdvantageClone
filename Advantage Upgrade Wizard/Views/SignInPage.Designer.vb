Partial Public Class SignInPage
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
        Me.SimpleButtonForm_SignIn = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditForm_Password = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditForm_UserName = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditForm_Database = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditForm_Server = New DevExpress.XtraEditors.TextEdit()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.simpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutControl1.SuspendLayout()
        CType(Me.TextEditForm_Password.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditForm_UserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditForm_Database.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditForm_Server.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutControl1
        '
        Me.layoutControl1.AllowCustomization = False
        Me.layoutControl1.AutoScroll = False
        Me.layoutControl1.Controls.Add(Me.SimpleButtonForm_SignIn)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_Password)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_UserName)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_Database)
        Me.layoutControl1.Controls.Add(Me.TextEditForm_Server)
        Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControl1.Name = "layoutControl1"
        Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1469, 300, 450, 350)
        Me.layoutControl1.Root = Me.layoutControlGroup1
        Me.layoutControl1.Size = New System.Drawing.Size(840, 500)
        Me.layoutControl1.TabIndex = 0
        Me.layoutControl1.Text = "layoutControl1"
        '
        'SimpleButtonForm_SignIn
        '
        Me.SimpleButtonForm_SignIn.Location = New System.Drawing.Point(42, 456)
        Me.SimpleButtonForm_SignIn.Name = "SimpleButtonForm_SignIn"
        Me.SimpleButtonForm_SignIn.Size = New System.Drawing.Size(782, 22)
        Me.SimpleButtonForm_SignIn.StyleController = Me.layoutControl1
        Me.SimpleButtonForm_SignIn.TabIndex = 8
        Me.SimpleButtonForm_SignIn.Text = "Sign In"
        '
        'TextEditForm_Password
        '
        Me.TextEditForm_Password.Location = New System.Drawing.Point(55, 280)
        Me.TextEditForm_Password.Name = "TextEditForm_Password"
        Me.TextEditForm_Password.Properties.UseSystemPasswordChar = True
        Me.TextEditForm_Password.Size = New System.Drawing.Size(756, 20)
        Me.TextEditForm_Password.StyleController = Me.layoutControl1
        Me.TextEditForm_Password.TabIndex = 7
        '
        'TextEditForm_UserName
        '
        Me.TextEditForm_UserName.Location = New System.Drawing.Point(55, 214)
        Me.TextEditForm_UserName.Name = "TextEditForm_UserName"
        Me.TextEditForm_UserName.Size = New System.Drawing.Size(756, 20)
        Me.TextEditForm_UserName.StyleController = Me.layoutControl1
        Me.TextEditForm_UserName.TabIndex = 6
        '
        'TextEditForm_Database
        '
        Me.TextEditForm_Database.Location = New System.Drawing.Point(55, 148)
        Me.TextEditForm_Database.Name = "TextEditForm_Database"
        Me.TextEditForm_Database.Size = New System.Drawing.Size(756, 20)
        Me.TextEditForm_Database.StyleController = Me.layoutControl1
        Me.TextEditForm_Database.TabIndex = 5
        '
        'TextEditForm_Server
        '
        Me.TextEditForm_Server.Location = New System.Drawing.Point(55, 82)
        Me.TextEditForm_Server.Name = "TextEditForm_Server"
        Me.TextEditForm_Server.Size = New System.Drawing.Size(756, 20)
        Me.TextEditForm_Server.StyleController = Me.layoutControl1
        Me.TextEditForm_Server.TabIndex = 4
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.simpleLabelItem1, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.SimpleLabelItem2})
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 20)
        Me.layoutControlGroup1.Size = New System.Drawing.Size(866, 500)
        Me.layoutControlGroup1.StartNewLine = True
        Me.layoutControlGroup1.TextVisible = False
        '
        'simpleLabelItem1
        '
        Me.simpleLabelItem1.AllowHotTrack = False
        Me.simpleLabelItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold)
        Me.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = True
        Me.simpleLabelItem1.CustomizationFormText = "Sign in to Database"
        Me.simpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.simpleLabelItem1.Name = "simpleLabelItem1"
        Me.simpleLabelItem1.Size = New System.Drawing.Size(786, 34)
        Me.simpleLabelItem1.Text = "Advantage Administrator Login"
        Me.simpleLabelItem1.TextSize = New System.Drawing.Size(754, 30)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 315)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(786, 139)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextEditForm_Server
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(786, 66)
        Me.LayoutControlItem1.Text = "Server:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(754, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextEditForm_Database
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 117)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(786, 66)
        Me.LayoutControlItem2.Text = "Database:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(754, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextEditForm_UserName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 183)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(786, 66)
        Me.LayoutControlItem3.Text = "SQL Login:"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(754, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TextEditForm_Password
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 249)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(786, 66)
        Me.LayoutControlItem4.Text = "Password:"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(754, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButtonForm_SignIn
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 454)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(786, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(0, 34)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.OptionsPrint.AppearanceItem.Options.UseTextOptions = True
        Me.SimpleLabelItem2.OptionsPrint.AppearanceItem.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.SimpleLabelItem2.OptionsPrint.AppearanceItemControl.Options.UseTextOptions = True
        Me.SimpleLabelItem2.OptionsPrint.AppearanceItemControl.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.SimpleLabelItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(786, 17)
        Me.SimpleLabelItem2.StartNewLine = True
        Me.SimpleLabelItem2.Text = "Need to provide a non Advantage SQL login that is a member of sysadm server role." &
    " This SQL Login will provide the wizard to upgrate your Advantage install."
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(754, 13)
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'SignInPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.layoutControl1)
        Me.Name = "SignInPage"
        Me.Size = New System.Drawing.Size(840, 500)
        CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutControl1.ResumeLayout(False)
        CType(Me.TextEditForm_Password.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditForm_UserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditForm_Database.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditForm_Server.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private simpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents TextEditForm_Password As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditForm_UserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditForm_Database As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditForm_Server As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButtonForm_SignIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
End Class
