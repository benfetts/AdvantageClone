Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EstimateTemplateControl
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimateTemplateControl))
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_TemplateFunction = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlEstimateTemplate_EstimateTemplate = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDetailsTab_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemEstimateTemplate_DetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDefaultCommentTab_DefaultComment = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxDefaultComment_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemEstimateTemplate_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.TabControlEstimateTemplate_EstimateTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlEstimateTemplate_EstimateTemplate.SuspendLayout()
            Me.TabControlPanelDetailsTab_Details.SuspendLayout()
            Me.TabControlPanelDefaultCommentTab_DefaultComment.SuspendLayout()
            Me.SuspendLayout()
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(71, 25)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(460, 20)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 3
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(71, 0)
            Me.TextBoxForm_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.SecurityEnabled = True
            Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(77, 20)
            Me.TextBoxForm_Code.StartingFolderName = Nothing
            Me.TextBoxForm_Code.TabIndex = 1
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(0, 25)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(65, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(65, 20)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'DataGridViewForm_TemplateFunction
            '
            Me.DataGridViewForm_TemplateFunction.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_TemplateFunction.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_TemplateFunction.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_TemplateFunction.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_TemplateFunction.AutoFilterLookupColumns = False
            Me.DataGridViewForm_TemplateFunction.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_TemplateFunction.AutoUpdateViewCaption = True
            Me.DataGridViewForm_TemplateFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_TemplateFunction.DataSource = Nothing
            Me.DataGridViewForm_TemplateFunction.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_TemplateFunction.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_TemplateFunction.ItemDescription = ""
            Me.DataGridViewForm_TemplateFunction.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewForm_TemplateFunction.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_TemplateFunction.MultiSelect = True
            Me.DataGridViewForm_TemplateFunction.Name = "DataGridViewForm_TemplateFunction"
            Me.DataGridViewForm_TemplateFunction.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_TemplateFunction.RunStandardValidation = True
            Me.DataGridViewForm_TemplateFunction.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_TemplateFunction.Size = New System.Drawing.Size(521, 344)
            Me.DataGridViewForm_TemplateFunction.TabIndex = 1
            Me.DataGridViewForm_TemplateFunction.UseEmbeddedNavigator = False
            Me.DataGridViewForm_TemplateFunction.ViewCaptionHeight = -1
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(154, 0)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(377, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 7
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.TabControlEstimateTemplate_EstimateTemplate)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Code)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(531, 432)
            Me.PanelControl_Control.TabIndex = 45
            '
            'TabControlEstimateTemplate_EstimateTemplate
            '
            Me.TabControlEstimateTemplate_EstimateTemplate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlEstimateTemplate_EstimateTemplate.CanReorderTabs = True
            Me.TabControlEstimateTemplate_EstimateTemplate.Controls.Add(Me.TabControlPanelDefaultCommentTab_DefaultComment)
            Me.TabControlEstimateTemplate_EstimateTemplate.Controls.Add(Me.TabControlPanelDetailsTab_Details)
            Me.TabControlEstimateTemplate_EstimateTemplate.Location = New System.Drawing.Point(0, 51)
            Me.TabControlEstimateTemplate_EstimateTemplate.Name = "TabControlEstimateTemplate_EstimateTemplate"
            Me.TabControlEstimateTemplate_EstimateTemplate.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlEstimateTemplate_EstimateTemplate.SelectedTabIndex = 0
            Me.TabControlEstimateTemplate_EstimateTemplate.Size = New System.Drawing.Size(531, 381)
            Me.TabControlEstimateTemplate_EstimateTemplate.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlEstimateTemplate_EstimateTemplate.TabIndex = 4
            Me.TabControlEstimateTemplate_EstimateTemplate.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlEstimateTemplate_EstimateTemplate.Tabs.Add(Me.TabItemEstimateTemplate_DetailsTab)
            Me.TabControlEstimateTemplate_EstimateTemplate.Tabs.Add(Me.TabItemEstimateTemplate_CommentsTab)
            Me.TabControlEstimateTemplate_EstimateTemplate.Text = "TabControl1"
            '
            'TabControlPanelDetailsTab_Details
            '
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.DataGridViewForm_TemplateFunction)
            Me.TabControlPanelDetailsTab_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_Details.Name = "TabControlPanelDetailsTab_Details"
            Me.TabControlPanelDetailsTab_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_Details.Size = New System.Drawing.Size(531, 354)
            Me.TabControlPanelDetailsTab_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_Details.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_Details.TabIndex = 1
            Me.TabControlPanelDetailsTab_Details.TabItem = Me.TabItemEstimateTemplate_DetailsTab
            '
            'TabItemEstimateTemplate_DetailsTab
            '
            Me.TabItemEstimateTemplate_DetailsTab.AttachedControl = Me.TabControlPanelDetailsTab_Details
            Me.TabItemEstimateTemplate_DetailsTab.Name = "TabItemEstimateTemplate_DetailsTab"
            Me.TabItemEstimateTemplate_DetailsTab.Text = "Details"
            '
            'TabControlPanelDefaultCommentTab_DefaultComment
            '
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Controls.Add(Me.TextBoxDefaultComment_Comment)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Name = "TabControlPanelDefaultCommentTab_DefaultComment"
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Size = New System.Drawing.Size(531, 354)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.Style.GradientAngle = 90
            Me.TabControlPanelDefaultCommentTab_DefaultComment.TabIndex = 2
            Me.TabControlPanelDefaultCommentTab_DefaultComment.TabItem = Me.TabItemEstimateTemplate_CommentsTab
            '
            'TextBoxDefaultComment_Comment
            '
            Me.TextBoxDefaultComment_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxDefaultComment_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComment_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComment_Comment.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComment_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComment_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComment_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComment_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComment_Comment.FocusHighlightEnabled = True
            Me.TextBoxDefaultComment_Comment.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxDefaultComment_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComment_Comment.Multiline = True
            Me.TextBoxDefaultComment_Comment.Name = "TextBoxDefaultComment_Comment"
            Me.TextBoxDefaultComment_Comment.SecurityEnabled = True
            Me.TextBoxDefaultComment_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComment_Comment.Size = New System.Drawing.Size(523, 346)
            Me.TextBoxDefaultComment_Comment.StartingFolderName = Nothing
            Me.TextBoxDefaultComment_Comment.TabIndex = 1
            Me.TextBoxDefaultComment_Comment.TabOnEnter = False
            '
            'TabItemEstimateTemplate_CommentsTab
            '
            Me.TabItemEstimateTemplate_CommentsTab.AttachedControl = Me.TabControlPanelDefaultCommentTab_DefaultComment
            Me.TabItemEstimateTemplate_CommentsTab.Name = "TabItemEstimateTemplate_CommentsTab"
            Me.TabItemEstimateTemplate_CommentsTab.Text = "Default Estimate Comment"
            '
            'EstimateTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "EstimateTemplateControl"
            Me.Size = New System.Drawing.Size(531, 432)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.TabControlEstimateTemplate_EstimateTemplate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlEstimateTemplate_EstimateTemplate.ResumeLayout(False)
            Me.TabControlPanelDetailsTab_Details.ResumeLayout(False)
            Me.TabControlPanelDefaultCommentTab_DefaultComment.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents DataGridViewForm_TemplateFunction As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlEstimateTemplate_EstimateTemplate As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDetailsTab_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEstimateTemplate_DetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDefaultCommentTab_DefaultComment As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TextBoxDefaultComment_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemEstimateTemplate_CommentsTab As DevComponents.DotNetBar.TabItem

    End Class

End Namespace
