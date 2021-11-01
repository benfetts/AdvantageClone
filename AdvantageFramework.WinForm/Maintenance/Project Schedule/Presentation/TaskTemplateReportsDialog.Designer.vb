Namespace Maintenance.ProjectSchedule.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TaskTemplateReportsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskTemplateReportsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Ok = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_TaskTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_SelectedTaskTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ListBoxForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.ListBox()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelMain_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TableLayoutPanelRightSection_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.ExpandableSplitterControlMain_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelMain_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Main.SuspendLayout()
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_RightSection.SuspendLayout()
            Me.TableLayoutPanelRightSection_TableLayout.SuspendLayout()
            Me.PanelTableLayout_RightColumn.SuspendLayout()
            Me.PanelTableLayout_LeftColumn.SuspendLayout()
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(628, 347)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ok.Location = New System.Drawing.Point(547, 347)
            Me.ButtonForm_Ok.Name = "ButtonForm_Ok"
            Me.ButtonForm_Ok.SecurityEnabled = True
            Me.ButtonForm_Ok.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ok.TabIndex = 1
            Me.ButtonForm_Ok.Text = "Ok"
            '
            'DataGridViewForm_TaskTemplates
            '
            Me.DataGridViewForm_TaskTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_TaskTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_TaskTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_TaskTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_TaskTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_TaskTemplates.ItemDescription = ""
            Me.DataGridViewForm_TaskTemplates.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_TaskTemplates.MultiSelect = True
            Me.DataGridViewForm_TaskTemplates.Name = "DataGridViewForm_TaskTemplates"
            Me.DataGridViewForm_TaskTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_TaskTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_TaskTemplates.Size = New System.Drawing.Size(212, 329)
            Me.DataGridViewForm_TaskTemplates.TabIndex = 0
            Me.DataGridViewForm_TaskTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_TaskTemplates.ViewCaptionHeight = -1
            '
            'DataGridViewForm_SelectedTaskTemplates
            '
            Me.DataGridViewForm_SelectedTaskTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_SelectedTaskTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_SelectedTaskTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_SelectedTaskTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_SelectedTaskTemplates.DataSource = Nothing
            Me.DataGridViewForm_SelectedTaskTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_SelectedTaskTemplates.ItemDescription = ""
            Me.DataGridViewForm_SelectedTaskTemplates.Location = New System.Drawing.Point(3, 0)
            Me.DataGridViewForm_SelectedTaskTemplates.MultiSelect = True
            Me.DataGridViewForm_SelectedTaskTemplates.Name = "DataGridViewForm_SelectedTaskTemplates"
            Me.DataGridViewForm_SelectedTaskTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_SelectedTaskTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_SelectedTaskTemplates.Size = New System.Drawing.Size(219, 329)
            Me.DataGridViewForm_SelectedTaskTemplates.TabIndex = 0
            Me.DataGridViewForm_SelectedTaskTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_SelectedTaskTemplates.ViewCaptionHeight = -1
            '
            'ListBoxForm_Reports
            '
            Me.ListBoxForm_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ListBoxForm_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ListBox.Type.Report
            Me.ListBoxForm_Reports.DisplayMember = "Description"
            Me.ListBoxForm_Reports.ExtraListBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ListBox.ExtraListBoxItems.[Nothing]
            Me.ListBoxForm_Reports.ExtraListBoxItemDisplayText = Nothing
            Me.ListBoxForm_Reports.ExtraListBoxItemValueObject = Nothing
            Me.ListBoxForm_Reports.Location = New System.Drawing.Point(0, 0)
            Me.ListBoxForm_Reports.Name = "ListBoxForm_Reports"
            Me.ListBoxForm_Reports.Size = New System.Drawing.Size(155, 329)
            Me.ListBoxForm_Reports.TabIndex = 0
            Me.ListBoxForm_Reports.ValueMember = "Code"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(218, 0)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 1
            Me.ButtonForm_Add.Text = ">"
            '
            'ButtonForm_Remove
            '
            Me.ButtonForm_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Remove.Location = New System.Drawing.Point(218, 26)
            Me.ButtonForm_Remove.Name = "ButtonForm_Remove"
            Me.ButtonForm_Remove.SecurityEnabled = True
            Me.ButtonForm_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Remove.TabIndex = 2
            Me.ButtonForm_Remove.Text = "<"
            '
            'ButtonForm_AddAll
            '
            Me.ButtonForm_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddAll.Location = New System.Drawing.Point(218, 52)
            Me.ButtonForm_AddAll.Name = "ButtonForm_AddAll"
            Me.ButtonForm_AddAll.SecurityEnabled = True
            Me.ButtonForm_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddAll.TabIndex = 3
            Me.ButtonForm_AddAll.Text = ">>"
            '
            'ButtonForm_RemoveAll
            '
            Me.ButtonForm_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveAll.Location = New System.Drawing.Point(218, 78)
            Me.ButtonForm_RemoveAll.Name = "ButtonForm_RemoveAll"
            Me.ButtonForm_RemoveAll.SecurityEnabled = True
            Me.ButtonForm_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveAll.TabIndex = 4
            Me.ButtonForm_RemoveAll.Text = "<<"
            '
            'PanelForm_Main
            '
            Me.PanelForm_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_RightSection)
            Me.PanelForm_Main.Controls.Add(Me.ExpandableSplitterControlMain_LeftRight)
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_LeftSection)
            Me.PanelForm_Main.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_Main.Name = "PanelForm_Main"
            Me.PanelForm_Main.Size = New System.Drawing.Size(691, 329)
            Me.PanelForm_Main.TabIndex = 0
            '
            'PanelMain_RightSection
            '
            Me.PanelMain_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelMain_RightSection.Controls.Add(Me.TableLayoutPanelRightSection_TableLayout)
            Me.PanelMain_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMain_RightSection.Location = New System.Drawing.Point(167, 0)
            Me.PanelMain_RightSection.Name = "PanelMain_RightSection"
            Me.PanelMain_RightSection.Size = New System.Drawing.Size(524, 329)
            Me.PanelMain_RightSection.TabIndex = 2
            '
            'TableLayoutPanelRightSection_TableLayout
            '
            Me.TableLayoutPanelRightSection_TableLayout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelRightSection_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelRightSection_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.14286!))
            Me.TableLayoutPanelRightSection_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714!))
            Me.TableLayoutPanelRightSection_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelRightSection_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelRightSection_TableLayout.Location = New System.Drawing.Point(6, 0)
            Me.TableLayoutPanelRightSection_TableLayout.Name = "TableLayoutPanelRightSection_TableLayout"
            Me.TableLayoutPanelRightSection_TableLayout.RowCount = 1
            Me.TableLayoutPanelRightSection_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelRightSection_TableLayout.Size = New System.Drawing.Size(518, 329)
            Me.TableLayoutPanelRightSection_TableLayout.TabIndex = 0
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.DataGridViewForm_SelectedTaskTemplates)
            Me.PanelTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(296, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(222, 329)
            Me.PanelTableLayout_RightColumn.TabIndex = 1
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ButtonForm_Add)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.DataGridViewForm_TaskTemplates)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ButtonForm_RemoveAll)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ButtonForm_Remove)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ButtonForm_AddAll)
            Me.PanelTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(296, 329)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
            '
            'ExpandableSplitterControlMain_LeftRight
            '
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlMain_LeftRight.ExpandableControl = Me.PanelMain_LeftSection
            Me.ExpandableSplitterControlMain_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlMain_LeftRight.Location = New System.Drawing.Point(161, 0)
            Me.ExpandableSplitterControlMain_LeftRight.Name = "ExpandableSplitterControlMain_LeftRight"
            Me.ExpandableSplitterControlMain_LeftRight.Size = New System.Drawing.Size(6, 329)
            Me.ExpandableSplitterControlMain_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlMain_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlMain_LeftRight.TabStop = False
            '
            'PanelMain_LeftSection
            '
            Me.PanelMain_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelMain_LeftSection.Controls.Add(Me.ListBoxForm_Reports)
            Me.PanelMain_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelMain_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelMain_LeftSection.Name = "PanelMain_LeftSection"
            Me.PanelMain_LeftSection.Size = New System.Drawing.Size(161, 329)
            Me.PanelMain_LeftSection.TabIndex = 0
            '
            'TaskTemplateReportsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(715, 379)
            Me.Controls.Add(Me.PanelForm_Main)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Ok)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TaskTemplateReportsDialog"
            Me.Text = "Task Template Reports"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Main.ResumeLayout(False)
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_RightSection.ResumeLayout(False)
            Me.TableLayoutPanelRightSection_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Ok As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_TaskTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_SelectedTaskTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ListBoxForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.ListBox
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_Main As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelMain_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TableLayoutPanelRightSection_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents ExpandableSplitterControlMain_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelMain_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace