Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlertNotifcationDialog
        Inherits DevComponents.DotNetBar.Balloon

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
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
            Me.BarForm_BottomMenu = New DevComponents.DotNetBar.Bar()
            Me.ButtonItemBottomMenu_Options = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_Read = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_Hide = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_GoTo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGoTo_GroupSetup = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGoTo_ModuleAccess = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemGoTo_UserSetup = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_Message = New DevComponents.DotNetBar.PanelEx()
            Me.LabelForm_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.BarForm_BottomMenu, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BarForm_BottomMenu
            '
            Me.BarForm_BottomMenu.BackColor = System.Drawing.Color.Transparent
            Me.BarForm_BottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.BarForm_BottomMenu.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.BarForm_BottomMenu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBottomMenu_Options})
            Me.BarForm_BottomMenu.Location = New System.Drawing.Point(0, 213)
            Me.BarForm_BottomMenu.Name = "BarForm_BottomMenu"
            Me.BarForm_BottomMenu.Size = New System.Drawing.Size(375, 25)
            Me.BarForm_BottomMenu.Stretch = True
            Me.BarForm_BottomMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
            Me.BarForm_BottomMenu.TabIndex = 10
            Me.BarForm_BottomMenu.TabStop = False
            '
            'ButtonItemBottomMenu_Options
            '
            Me.ButtonItemBottomMenu_Options.AutoExpandOnClick = True
            Me.ButtonItemBottomMenu_Options.ForeColor = System.Drawing.Color.Black
            Me.ButtonItemBottomMenu_Options.Name = "ButtonItemBottomMenu_Options"
            Me.ButtonItemBottomMenu_Options.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Read, Me.ButtonItemOptions_Hide, Me.ButtonItemOptions_GoTo})
            Me.ButtonItemBottomMenu_Options.Text = "Options..."
            '
            'ButtonItemOptions_Read
            '
            Me.ButtonItemOptions_Read.Name = "ButtonItemOptions_Read"
            Me.ButtonItemOptions_Read.Text = "Read"
            '
            'ButtonItemOptions_Hide
            '
            Me.ButtonItemOptions_Hide.BeginGroup = True
            Me.ButtonItemOptions_Hide.Name = "ButtonItemOptions_Hide"
            Me.ButtonItemOptions_Hide.Text = "Hide"
            '
            'ButtonItemOptions_GoTo
            '
            Me.ButtonItemOptions_GoTo.AutoExpandOnClick = True
            Me.ButtonItemOptions_GoTo.BeginGroup = True
            Me.ButtonItemOptions_GoTo.Name = "ButtonItemOptions_GoTo"
            Me.ButtonItemOptions_GoTo.SplitButton = True
            Me.ButtonItemOptions_GoTo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGoTo_GroupSetup, Me.ButtonItemGoTo_ModuleAccess, Me.ButtonItemGoTo_UserSetup})
            Me.ButtonItemOptions_GoTo.Text = "Go To..."
            '
            'ButtonItemGoTo_GroupSetup
            '
            Me.ButtonItemGoTo_GroupSetup.Name = "ButtonItemGoTo_GroupSetup"
            Me.ButtonItemGoTo_GroupSetup.Text = "Group Setup"
            '
            'ButtonItemGoTo_ModuleAccess
            '
            Me.ButtonItemGoTo_ModuleAccess.BeginGroup = True
            Me.ButtonItemGoTo_ModuleAccess.Name = "ButtonItemGoTo_ModuleAccess"
            Me.ButtonItemGoTo_ModuleAccess.Text = "Module Access"
            '
            'ButtonItemGoTo_UserSetup
            '
            Me.ButtonItemGoTo_UserSetup.BeginGroup = True
            Me.ButtonItemGoTo_UserSetup.Name = "ButtonItemGoTo_UserSetup"
            Me.ButtonItemGoTo_UserSetup.Text = "User Setup"
            '
            'PanelForm_Message
            '
            Me.PanelForm_Message.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Message.AutoScroll = True
            Me.PanelForm_Message.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelForm_Message.Location = New System.Drawing.Point(12, 38)
            Me.PanelForm_Message.Name = "PanelForm_Message"
            Me.PanelForm_Message.Size = New System.Drawing.Size(351, 169)
            Me.PanelForm_Message.Style.BackColor1.Color = System.Drawing.Color.White
            Me.PanelForm_Message.Style.BackColor2.Color = System.Drawing.Color.White
            Me.PanelForm_Message.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile
            Me.PanelForm_Message.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelForm_Message.Style.GradientAngle = 90
            Me.PanelForm_Message.Style.LineAlignment = System.Drawing.StringAlignment.Near
            Me.PanelForm_Message.Style.WordWrap = True
            Me.PanelForm_Message.StyleMouseDown.LineAlignment = System.Drawing.StringAlignment.Near
            Me.PanelForm_Message.StyleMouseOver.LineAlignment = System.Drawing.StringAlignment.Near
            Me.PanelForm_Message.TabIndex = 7
            '
            'LabelForm_Title
            '
            Me.LabelForm_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Title.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Title.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Title.Name = "LabelForm_Title"
            Me.LabelForm_Title.Size = New System.Drawing.Size(351, 20)
            Me.LabelForm_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Title.TabIndex = 12
            Me.LabelForm_Title.Text = "<h1>New Applications Available</h1>"
            '
            'AlertNotifcationDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(239, Byte), Integer))
            Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ClientSize = New System.Drawing.Size(375, 238)
            Me.Controls.Add(Me.PanelForm_Message)
            Me.Controls.Add(Me.LabelForm_Title)
            Me.Controls.Add(Me.BarForm_BottomMenu)
            Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "AlertNotifcationDialog"
            Me.ShowCloseButton = False
            Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
            CType(Me.BarForm_BottomMenu, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BarForm_BottomMenu As DevComponents.DotNetBar.Bar
        Friend WithEvents ButtonItemBottomMenu_Options As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_Message As DevComponents.DotNetBar.PanelEx
        Friend WithEvents ButtonItemOptions_Read As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptions_Hide As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOptions_GoTo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGoTo_GroupSetup As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGoTo_ModuleAccess As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemGoTo_UserSetup As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
