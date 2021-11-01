Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog))
            Me.LabelForm_MarketGroup = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_MarketGroup = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'LabelForm_MarketGroup
            '
            Me.LabelForm_MarketGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MarketGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MarketGroup.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_MarketGroup.Name = "LabelForm_MarketGroup"
            Me.LabelForm_MarketGroup.Size = New System.Drawing.Size(88, 20)
            Me.LabelForm_MarketGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MarketGroup.TabIndex = 0
            Me.LabelForm_MarketGroup.Text = "Market Group:"
            '
            'ComboBoxForm_MarketGroup
            '
            Me.ComboBoxForm_MarketGroup.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MarketGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_MarketGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_MarketGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MarketGroup.AutoFindItemInDataSource = False
            Me.ComboBoxForm_MarketGroup.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MarketGroup.BookmarkingEnabled = False
            Me.ComboBoxForm_MarketGroup.DisableMouseWheel = False
            Me.ComboBoxForm_MarketGroup.DisplayMember = "Text"
            Me.ComboBoxForm_MarketGroup.DisplayName = ""
            Me.ComboBoxForm_MarketGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MarketGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MarketGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_MarketGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MarketGroup.FocusHighlightEnabled = True
            Me.ComboBoxForm_MarketGroup.FormattingEnabled = True
            Me.ComboBoxForm_MarketGroup.ItemHeight = 14
            Me.ComboBoxForm_MarketGroup.Location = New System.Drawing.Point(106, 12)
            Me.ComboBoxForm_MarketGroup.Name = "ComboBoxForm_MarketGroup"
            Me.ComboBoxForm_MarketGroup.ReadOnly = False
            Me.ComboBoxForm_MarketGroup.SecurityEnabled = True
            Me.ComboBoxForm_MarketGroup.Size = New System.Drawing.Size(277, 20)
            Me.ComboBoxForm_MarketGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MarketGroup.TabIndex = 1
            Me.ComboBoxForm_MarketGroup.TabOnEnter = True
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(227, 38)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(308, 38)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(395, 70)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ComboBoxForm_MarketGroup)
            Me.Controls.Add(Me.LabelForm_MarketGroup)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog"
            Me.Text = "Select Market Group"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents LabelForm_MarketGroup As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_MarketGroup As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ButtonForm_OK As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace

