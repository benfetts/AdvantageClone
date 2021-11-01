Namespace ProjectManagement.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimatePrintingEmailRecipientDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimatePrintingEmailRecipientDialog))
            Me.DataGridViewForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_AvailableRecipients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_RecipientSource = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Source = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_CC = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_BCC = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_AddTo = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddCC = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddBCC = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'DataGridViewForm_To
            '
            Me.DataGridViewForm_To.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_To.AllowDragAndDrop = False
            Me.DataGridViewForm_To.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_To.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_To.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_To.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_To.AutoFilterLookupColumns = False
            Me.DataGridViewForm_To.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_To.AutoUpdateViewCaption = True
            Me.DataGridViewForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_To.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_To.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_To.ItemDescription = "To Recipient(s)"
            Me.DataGridViewForm_To.Location = New System.Drawing.Point(625, 12)
            Me.DataGridViewForm_To.MultiSelect = True
            Me.DataGridViewForm_To.Name = "DataGridViewForm_To"
            Me.DataGridViewForm_To.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_To.RunStandardValidation = True
            Me.DataGridViewForm_To.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_To.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_To.Size = New System.Drawing.Size(390, 144)
            Me.DataGridViewForm_To.TabIndex = 4
            Me.DataGridViewForm_To.TabStop = False
            Me.DataGridViewForm_To.UseEmbeddedNavigator = False
            Me.DataGridViewForm_To.ViewCaptionHeight = -1
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(859, 761)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(940, 761)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_AvailableRecipients
            '
            Me.DataGridViewForm_AvailableRecipients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_AvailableRecipients.AllowDragAndDrop = False
            Me.DataGridViewForm_AvailableRecipients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_AvailableRecipients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableRecipients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AvailableRecipients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableRecipients.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AvailableRecipients.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AvailableRecipients.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableRecipients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AvailableRecipients.DataSource = Nothing
            Me.DataGridViewForm_AvailableRecipients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AvailableRecipients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableRecipients.ItemDescription = "Contact(s)"
            Me.DataGridViewForm_AvailableRecipients.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_AvailableRecipients.MultiSelect = True
            Me.DataGridViewForm_AvailableRecipients.Name = "DataGridViewForm_AvailableRecipients"
            Me.DataGridViewForm_AvailableRecipients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableRecipients.RunStandardValidation = True
            Me.DataGridViewForm_AvailableRecipients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_AvailableRecipients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableRecipients.Size = New System.Drawing.Size(526, 418)
            Me.DataGridViewForm_AvailableRecipients.TabIndex = 2
            Me.DataGridViewForm_AvailableRecipients.TabStop = False
            Me.DataGridViewForm_AvailableRecipients.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableRecipients.ViewCaptionHeight = -1
            '
            'LabelForm_RecipientSource
            '
            Me.LabelForm_RecipientSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RecipientSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RecipientSource.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_RecipientSource.Name = "LabelForm_RecipientSource"
            Me.LabelForm_RecipientSource.Size = New System.Drawing.Size(56, 20)
            Me.LabelForm_RecipientSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RecipientSource.TabIndex = 0
            Me.LabelForm_RecipientSource.Text = "Source:"
            '
            'ComboBoxForm_Source
            '
            Me.ComboBoxForm_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Source.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Source.BookmarkingEnabled = False
            Me.ComboBoxForm_Source.ClientCode = ""
            Me.ComboBoxForm_Source.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_Source.DisableMouseWheel = False
            Me.ComboBoxForm_Source.DisplayName = ""
            Me.ComboBoxForm_Source.DivisionCode = ""
            Me.ComboBoxForm_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Source.FocusHighlightEnabled = True
            Me.ComboBoxForm_Source.FormattingEnabled = True
            Me.ComboBoxForm_Source.ItemHeight = 14
            Me.ComboBoxForm_Source.Location = New System.Drawing.Point(74, 12)
            Me.ComboBoxForm_Source.Name = "ComboBoxForm_Source"
            Me.ComboBoxForm_Source.ReadOnly = False
            Me.ComboBoxForm_Source.SecurityEnabled = True
            Me.ComboBoxForm_Source.Size = New System.Drawing.Size(464, 20)
            Me.ComboBoxForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Source.TabIndex = 1
            Me.ComboBoxForm_Source.TabOnEnter = True
            '
            'DataGridViewForm_CC
            '
            Me.DataGridViewForm_CC.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CC.AllowDragAndDrop = False
            Me.DataGridViewForm_CC.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CC.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CC.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CC.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CC.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CC.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CC.DataSource = Nothing
            Me.DataGridViewForm_CC.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CC.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CC.ItemDescription = "CC Recipient(s)"
            Me.DataGridViewForm_CC.Location = New System.Drawing.Point(625, 162)
            Me.DataGridViewForm_CC.MultiSelect = True
            Me.DataGridViewForm_CC.Name = "DataGridViewForm_CC"
            Me.DataGridViewForm_CC.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CC.RunStandardValidation = True
            Me.DataGridViewForm_CC.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CC.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CC.Size = New System.Drawing.Size(390, 144)
            Me.DataGridViewForm_CC.TabIndex = 6
            Me.DataGridViewForm_CC.TabStop = False
            Me.DataGridViewForm_CC.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CC.ViewCaptionHeight = -1
            '
            'DataGridViewForm_BCC
            '
            Me.DataGridViewForm_BCC.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_BCC.AllowDragAndDrop = False
            Me.DataGridViewForm_BCC.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_BCC.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_BCC.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_BCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_BCC.AutoFilterLookupColumns = False
            Me.DataGridViewForm_BCC.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_BCC.AutoUpdateViewCaption = True
            Me.DataGridViewForm_BCC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_BCC.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_BCC.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_BCC.ItemDescription = "BCC Recipient(s)"
            Me.DataGridViewForm_BCC.Location = New System.Drawing.Point(625, 312)
            Me.DataGridViewForm_BCC.MultiSelect = True
            Me.DataGridViewForm_BCC.Name = "DataGridViewForm_BCC"
            Me.DataGridViewForm_BCC.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_BCC.RunStandardValidation = True
            Me.DataGridViewForm_BCC.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_BCC.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_BCC.Size = New System.Drawing.Size(390, 144)
            Me.DataGridViewForm_BCC.TabIndex = 8
            Me.DataGridViewForm_BCC.TabStop = False
            Me.DataGridViewForm_BCC.UseEmbeddedNavigator = False
            Me.DataGridViewForm_BCC.ViewCaptionHeight = -1
            '
            'ButtonForm_AddTo
            '
            Me.ButtonForm_AddTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddTo.Location = New System.Drawing.Point(544, 12)
            Me.ButtonForm_AddTo.Name = "ButtonForm_AddTo"
            Me.ButtonForm_AddTo.SecurityEnabled = True
            Me.ButtonForm_AddTo.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddTo.TabIndex = 3
            Me.ButtonForm_AddTo.Text = "To: ->"
            '
            'ButtonForm_AddCC
            '
            Me.ButtonForm_AddCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddCC.Location = New System.Drawing.Point(544, 162)
            Me.ButtonForm_AddCC.Name = "ButtonForm_AddCC"
            Me.ButtonForm_AddCC.SecurityEnabled = True
            Me.ButtonForm_AddCC.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddCC.TabIndex = 5
            Me.ButtonForm_AddCC.Text = "Cc: ->"
            '
            'ButtonForm_AddBCC
            '
            Me.ButtonForm_AddBCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddBCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddBCC.Location = New System.Drawing.Point(544, 312)
            Me.ButtonForm_AddBCC.Name = "ButtonForm_AddBCC"
            Me.ButtonForm_AddBCC.SecurityEnabled = True
            Me.ButtonForm_AddBCC.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddBCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddBCC.TabIndex = 7
            Me.ButtonForm_AddBCC.Text = "Bcc: ->"
            '
            'TextBoxForm_Body
            '
            Me.TextBoxForm_Body.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Body.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Body.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Body.CheckSpellingOnValidate = False
            Me.TextBoxForm_Body.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Body.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Body.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Body.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Body.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Body.FocusHighlightEnabled = True
            Me.TextBoxForm_Body.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Body.Location = New System.Drawing.Point(104, 489)
            Me.TextBoxForm_Body.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Body.Multiline = True
            Me.TextBoxForm_Body.Name = "TextBoxForm_Body"
            Me.TextBoxForm_Body.SecurityEnabled = True
            Me.TextBoxForm_Body.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(911, 258)
            Me.TextBoxForm_Body.StartingFolderName = Nothing
            Me.TextBoxForm_Body.TabIndex = 29
            Me.TextBoxForm_Body.TabOnEnter = True
            '
            'TextBoxForm_Subject
            '
            Me.TextBoxForm_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Subject.CheckSpellingOnValidate = False
            Me.TextBoxForm_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Subject.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Subject.FocusHighlightEnabled = True
            Me.TextBoxForm_Subject.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(104, 462)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.SecurityEnabled = True
            Me.TextBoxForm_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(911, 20)
            Me.TextBoxForm_Subject.StartingFolderName = Nothing
            Me.TextBoxForm_Subject.TabIndex = 27
            Me.TextBoxForm_Subject.TabOnEnter = True
            '
            'LabelForm_Body
            '
            Me.LabelForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Body.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Body.Location = New System.Drawing.Point(12, 489)
            Me.LabelForm_Body.Name = "LabelForm_Body"
            Me.LabelForm_Body.Size = New System.Drawing.Size(86, 20)
            Me.LabelForm_Body.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Body.TabIndex = 28
            Me.LabelForm_Body.Text = "Body:"
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(12, 462)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(86, 20)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 26
            Me.LabelForm_Subject.Text = "Subject:"
            '
            'EstimatePrintingEmailRecipientDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1027, 788)
            Me.Controls.Add(Me.TextBoxForm_Body)
            Me.Controls.Add(Me.TextBoxForm_Subject)
            Me.Controls.Add(Me.LabelForm_Body)
            Me.Controls.Add(Me.LabelForm_Subject)
            Me.Controls.Add(Me.ButtonForm_AddBCC)
            Me.Controls.Add(Me.ButtonForm_AddCC)
            Me.Controls.Add(Me.ButtonForm_AddTo)
            Me.Controls.Add(Me.DataGridViewForm_BCC)
            Me.Controls.Add(Me.DataGridViewForm_CC)
            Me.Controls.Add(Me.ComboBoxForm_Source)
            Me.Controls.Add(Me.LabelForm_RecipientSource)
            Me.Controls.Add(Me.DataGridViewForm_AvailableRecipients)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.DataGridViewForm_To)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EstimatePrintingEmailRecipientDialog"
            Me.Text = "Select Email Recipients"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_To As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_AvailableRecipients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_RecipientSource As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Source As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_CC As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_BCC As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_AddTo As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddCC As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddBCC As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_Body As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Body As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace