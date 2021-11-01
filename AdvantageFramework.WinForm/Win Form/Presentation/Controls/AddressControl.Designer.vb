Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.GroupBoxControl_Address = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelAddress_Country = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_Country = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_Zip = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_Zip = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_State = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_State = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_County = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_County = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxAddress_City = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_Address2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_Address2 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_Address = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_Address = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAddress_City = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAddress_Address3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAddress_Address3 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.GroupBoxControl_Address, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Address.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBoxControl_Address
            '
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_Country)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_Country)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_Zip)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_Zip)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_State)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_State)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_County)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_County)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_City)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_Address2)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_Address2)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_Address)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_Address)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_City)
            Me.GroupBoxControl_Address.Controls.Add(Me.LabelAddress_Address3)
            Me.GroupBoxControl_Address.Controls.Add(Me.TextBoxAddress_Address3)
            Me.GroupBoxControl_Address.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBoxControl_Address.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxControl_Address.Name = "GroupBoxControl_Address"
            Me.GroupBoxControl_Address.Size = New System.Drawing.Size(354, 181)
            Me.GroupBoxControl_Address.TabIndex = 0
            Me.GroupBoxControl_Address.Text = "Address"
            '
            'LabelAddress_Country
            '
            Me.LabelAddress_Country.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_Country.BackgroundStyle.Class = ""
            Me.LabelAddress_Country.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_Country.Location = New System.Drawing.Point(6, 156)
            Me.LabelAddress_Country.Name = "LabelAddress_Country"
            Me.LabelAddress_Country.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_Country.TabIndex = 14
            Me.LabelAddress_Country.Text = "Country:"
            '
            'TextBoxAddress_Country
            '
            Me.TextBoxAddress_Country.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_Country.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_Country.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_Country.CheckSpellingOnValidate = False
            Me.TextBoxAddress_Country.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_Country.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_Country.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_Country.FocusHighlightEnabled = True
            Me.TextBoxAddress_Country.Location = New System.Drawing.Point(70, 156)
            Me.TextBoxAddress_Country.Name = "TextBoxAddress_Country"
            Me.TextBoxAddress_Country.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_Country.TabIndex = 15
            Me.TextBoxAddress_Country.TabOnEnter = True
            '
            'LabelAddress_Zip
            '
            Me.LabelAddress_Zip.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_Zip.BackgroundStyle.Class = ""
            Me.LabelAddress_Zip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_Zip.Location = New System.Drawing.Point(140, 130)
            Me.LabelAddress_Zip.Name = "LabelAddress_Zip"
            Me.LabelAddress_Zip.Size = New System.Drawing.Size(25, 20)
            Me.LabelAddress_Zip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_Zip.TabIndex = 12
            Me.LabelAddress_Zip.Text = "Zip:"
            '
            'TextBoxAddress_Zip
            '
            Me.TextBoxAddress_Zip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_Zip.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_Zip.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_Zip.CheckSpellingOnValidate = False
            Me.TextBoxAddress_Zip.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_Zip.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_Zip.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_Zip.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_Zip.FocusHighlightEnabled = True
            Me.TextBoxAddress_Zip.Location = New System.Drawing.Point(171, 130)
            Me.TextBoxAddress_Zip.Name = "TextBoxAddress_Zip"
            Me.TextBoxAddress_Zip.Size = New System.Drawing.Size(178, 20)
            Me.TextBoxAddress_Zip.TabIndex = 13
            Me.TextBoxAddress_Zip.TabOnEnter = True
            '
            'LabelAddress_State
            '
            Me.LabelAddress_State.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_State.BackgroundStyle.Class = ""
            Me.LabelAddress_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_State.Location = New System.Drawing.Point(6, 130)
            Me.LabelAddress_State.Name = "LabelAddress_State"
            Me.LabelAddress_State.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_State.TabIndex = 10
            Me.LabelAddress_State.Text = "State:"
            '
            'TextBoxAddress_State
            '
            '
            '
            '
            Me.TextBoxAddress_State.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_State.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_State.CheckSpellingOnValidate = False
            Me.TextBoxAddress_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_State.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_State.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_State.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_State.FocusHighlightEnabled = True
            Me.TextBoxAddress_State.Location = New System.Drawing.Point(70, 130)
            Me.TextBoxAddress_State.Name = "TextBoxAddress_State"
            Me.TextBoxAddress_State.Size = New System.Drawing.Size(64, 20)
            Me.TextBoxAddress_State.TabIndex = 11
            Me.TextBoxAddress_State.TabOnEnter = True
            '
            'LabelAddress_County
            '
            Me.LabelAddress_County.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_County.BackgroundStyle.Class = ""
            Me.LabelAddress_County.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_County.Location = New System.Drawing.Point(6, 104)
            Me.LabelAddress_County.Name = "LabelAddress_County"
            Me.LabelAddress_County.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_County.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_County.TabIndex = 8
            Me.LabelAddress_County.Text = "County: "
            '
            'TextBoxAddress_County
            '
            Me.TextBoxAddress_County.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_County.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_County.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_County.CheckSpellingOnValidate = False
            Me.TextBoxAddress_County.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_County.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_County.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_County.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_County.FocusHighlightEnabled = True
            Me.TextBoxAddress_County.Location = New System.Drawing.Point(70, 105)
            Me.TextBoxAddress_County.Name = "TextBoxAddress_County"
            Me.TextBoxAddress_County.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_County.TabIndex = 9
            Me.TextBoxAddress_County.TabOnEnter = True
            '
            'TextBoxAddress_City
            '
            Me.TextBoxAddress_City.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_City.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_City.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_City.CheckSpellingOnValidate = False
            Me.TextBoxAddress_City.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_City.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_City.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_City.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_City.FocusHighlightEnabled = True
            Me.TextBoxAddress_City.Location = New System.Drawing.Point(70, 78)
            Me.TextBoxAddress_City.Name = "TextBoxAddress_City"
            Me.TextBoxAddress_City.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_City.TabIndex = 7
            Me.TextBoxAddress_City.TabOnEnter = True
            '
            'LabelAddress_Address2
            '
            Me.LabelAddress_Address2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_Address2.BackgroundStyle.Class = ""
            Me.LabelAddress_Address2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_Address2.Location = New System.Drawing.Point(6, 52)
            Me.LabelAddress_Address2.Name = "LabelAddress_Address2"
            Me.LabelAddress_Address2.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_Address2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_Address2.TabIndex = 2
            Me.LabelAddress_Address2.Text = "Address 2:"
            '
            'TextBoxAddress_Address2
            '
            Me.TextBoxAddress_Address2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_Address2.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_Address2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_Address2.CheckSpellingOnValidate = False
            Me.TextBoxAddress_Address2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_Address2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_Address2.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_Address2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_Address2.FocusHighlightEnabled = True
            Me.TextBoxAddress_Address2.Location = New System.Drawing.Point(70, 51)
            Me.TextBoxAddress_Address2.Name = "TextBoxAddress_Address2"
            Me.TextBoxAddress_Address2.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_Address2.TabIndex = 3
            Me.TextBoxAddress_Address2.TabOnEnter = True
            '
            'LabelAddress_Address
            '
            Me.LabelAddress_Address.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_Address.BackgroundStyle.Class = ""
            Me.LabelAddress_Address.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_Address.Location = New System.Drawing.Point(6, 26)
            Me.LabelAddress_Address.Name = "LabelAddress_Address"
            Me.LabelAddress_Address.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_Address.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_Address.TabIndex = 0
            Me.LabelAddress_Address.Text = "Address 1:"
            '
            'TextBoxAddress_Address
            '
            Me.TextBoxAddress_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_Address.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_Address.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_Address.CheckSpellingOnValidate = False
            Me.TextBoxAddress_Address.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_Address.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_Address.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_Address.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_Address.FocusHighlightEnabled = True
            Me.TextBoxAddress_Address.Location = New System.Drawing.Point(70, 25)
            Me.TextBoxAddress_Address.Name = "TextBoxAddress_Address"
            Me.TextBoxAddress_Address.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_Address.TabIndex = 1
            Me.TextBoxAddress_Address.TabOnEnter = True
            '
            'LabelAddress_City
            '
            Me.LabelAddress_City.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_City.BackgroundStyle.Class = ""
            Me.LabelAddress_City.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_City.Location = New System.Drawing.Point(6, 78)
            Me.LabelAddress_City.Name = "LabelAddress_City"
            Me.LabelAddress_City.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_City.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_City.TabIndex = 6
            Me.LabelAddress_City.Text = "City:"
            '
            'LabelAddress_Address3
            '
            Me.LabelAddress_Address3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddress_Address3.BackgroundStyle.Class = ""
            Me.LabelAddress_Address3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddress_Address3.Location = New System.Drawing.Point(6, 78)
            Me.LabelAddress_Address3.Name = "LabelAddress_Address3"
            Me.LabelAddress_Address3.Size = New System.Drawing.Size(58, 20)
            Me.LabelAddress_Address3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddress_Address3.TabIndex = 4
            Me.LabelAddress_Address3.Text = "Address 3:"
            Me.LabelAddress_Address3.Visible = False
            '
            'TextBoxAddress_Address3
            '
            Me.TextBoxAddress_Address3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAddress_Address3.Border.Class = "TextBoxBorder"
            Me.TextBoxAddress_Address3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAddress_Address3.CheckSpellingOnValidate = False
            Me.TextBoxAddress_Address3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAddress_Address3.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAddress_Address3.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAddress_Address3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAddress_Address3.FocusHighlightEnabled = True
            Me.TextBoxAddress_Address3.Location = New System.Drawing.Point(70, 78)
            Me.TextBoxAddress_Address3.Name = "TextBoxAddress_Address3"
            Me.TextBoxAddress_Address3.Size = New System.Drawing.Size(279, 20)
            Me.TextBoxAddress_Address3.TabIndex = 5
            Me.TextBoxAddress_Address3.TabOnEnter = True
            Me.TextBoxAddress_Address3.Visible = False
            '
            'AddressControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GroupBoxControl_Address)
            Me.Name = "AddressControl"
            Me.Size = New System.Drawing.Size(354, 181)
            CType(Me.GroupBoxControl_Address, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Address.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBoxControl_Address As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelAddress_Country As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_Country As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_Zip As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_Zip As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_State As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_State As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_County As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_County As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_City As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_City As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_Address2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_Address2 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_Address As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAddress_Address As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAddress_Address3 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAddress_Address3 As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace