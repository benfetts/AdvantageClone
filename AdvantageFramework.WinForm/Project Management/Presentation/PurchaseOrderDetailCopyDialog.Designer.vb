Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderDetailCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderDetailCopyDialog))
            Me.DataGridViewSelectPO_PurchaseOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_CopyingPage = New DevExpress.XtraWizard.WizardPage()
            Me.LabelCopyingPage_OverallCopyStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCopyingPage_Copying = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarCopyingPage_Progress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.WizardPageWizard_SelectPO = New DevExpress.XtraWizard.WizardPage()
            Me.WizardPageWizard_SelectDetails = New DevExpress.XtraWizard.WizardPage()
            Me.PanelSelectDetails_SelectDetails = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelSelectDetails_Top = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSelectPODetails_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelSelectDetails_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.WizardPageWizard_UpdateJobInfo = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewUpdateJobInfo_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_CopyingPage.SuspendLayout()
            Me.WizardPageWizard_SelectPO.SuspendLayout()
            Me.WizardPageWizard_SelectDetails.SuspendLayout()
            CType(Me.PanelSelectDetails_SelectDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSelectDetails_SelectDetails.SuspendLayout()
            CType(Me.PanelSelectDetails_Top, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSelectDetails_Top.SuspendLayout()
            CType(Me.PanelSelectDetails_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSelectDetails_Bottom.SuspendLayout()
            Me.WizardPageWizard_UpdateJobInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewSelectPO_PurchaseOrders
            '
            Me.DataGridViewSelectPO_PurchaseOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectPO_PurchaseOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectPO_PurchaseOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectPO_PurchaseOrders.AutoFilterLookupColumns = False
            Me.DataGridViewSelectPO_PurchaseOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectPO_PurchaseOrders.AutoUpdateViewCaption = True
            Me.DataGridViewSelectPO_PurchaseOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectPO_PurchaseOrders.DataSource = Nothing
            Me.DataGridViewSelectPO_PurchaseOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectPO_PurchaseOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectPO_PurchaseOrders.ItemDescription = "Item(s)"
            Me.DataGridViewSelectPO_PurchaseOrders.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectPO_PurchaseOrders.MultiSelect = True
            Me.DataGridViewSelectPO_PurchaseOrders.Name = "DataGridViewSelectPO_PurchaseOrders"
            Me.DataGridViewSelectPO_PurchaseOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectPO_PurchaseOrders.RunStandardValidation = True
            Me.DataGridViewSelectPO_PurchaseOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectPO_PurchaseOrders.Size = New System.Drawing.Size(658, 332)
            Me.DataGridViewSelectPO_PurchaseOrders.TabIndex = 0
            Me.DataGridViewSelectPO_PurchaseOrders.UseEmbeddedNavigator = False
            Me.DataGridViewSelectPO_PurchaseOrders.ViewCaptionHeight = -1
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_CopyingPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectPO)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectDetails)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_UpdateJobInfo)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WizardPageWizard_SelectPO, Me.WizardPageWizard_SelectDetails, Me.WizardPageWizard_UpdateJobInfo, Me.WizardPageWizard_CopyingPage})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(696, 481)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_CopyingPage
            '
            Me.WizardPageWizard_CopyingPage.AllowBack = False
            Me.WizardPageWizard_CopyingPage.AllowCancel = False
            Me.WizardPageWizard_CopyingPage.Controls.Add(Me.LabelCopyingPage_OverallCopyStatus)
            Me.WizardPageWizard_CopyingPage.Controls.Add(Me.LabelCopyingPage_Copying)
            Me.WizardPageWizard_CopyingPage.Controls.Add(Me.ProgressBarCopyingPage_Progress)
            Me.WizardPageWizard_CopyingPage.DescriptionText = ""
            Me.WizardPageWizard_CopyingPage.Name = "WizardPageWizard_CopyingPage"
            Me.WizardPageWizard_CopyingPage.Size = New System.Drawing.Size(664, 338)
            Me.WizardPageWizard_CopyingPage.Text = "Copying Detail(s)...."
            '
            'LabelCopyingPage_OverallCopyStatus
            '
            Me.LabelCopyingPage_OverallCopyStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCopyingPage_OverallCopyStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCopyingPage_OverallCopyStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCopyingPage_OverallCopyStatus.Location = New System.Drawing.Point(3, 88)
            Me.LabelCopyingPage_OverallCopyStatus.Name = "LabelCopyingPage_OverallCopyStatus"
            Me.LabelCopyingPage_OverallCopyStatus.Size = New System.Drawing.Size(658, 20)
            Me.LabelCopyingPage_OverallCopyStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCopyingPage_OverallCopyStatus.TabIndex = 3
            Me.LabelCopyingPage_OverallCopyStatus.Text = "Overall Progress..."
            '
            'LabelCopyingPage_Copying
            '
            Me.LabelCopyingPage_Copying.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCopyingPage_Copying.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCopyingPage_Copying.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCopyingPage_Copying.Location = New System.Drawing.Point(3, 36)
            Me.LabelCopyingPage_Copying.Name = "LabelCopyingPage_Copying"
            Me.LabelCopyingPage_Copying.Size = New System.Drawing.Size(658, 20)
            Me.LabelCopyingPage_Copying.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCopyingPage_Copying.TabIndex = 1
            Me.LabelCopyingPage_Copying.Text = "Copying Detail(s)..."
            '
            'ProgressBarCopyingPage_Progress
            '
            Me.ProgressBarCopyingPage_Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarCopyingPage_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarCopyingPage_Progress.Location = New System.Drawing.Point(3, 62)
            Me.ProgressBarCopyingPage_Progress.Name = "ProgressBarCopyingPage_Progress"
            Me.ProgressBarCopyingPage_Progress.Size = New System.Drawing.Size(658, 20)
            Me.ProgressBarCopyingPage_Progress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarCopyingPage_Progress.TabIndex = 0
            '
            'WizardPageWizard_SelectPO
            '
            Me.WizardPageWizard_SelectPO.Controls.Add(Me.DataGridViewSelectPO_PurchaseOrders)
            Me.WizardPageWizard_SelectPO.DescriptionText = ""
            Me.WizardPageWizard_SelectPO.Name = "WizardPageWizard_SelectPO"
            Me.WizardPageWizard_SelectPO.Size = New System.Drawing.Size(664, 338)
            Me.WizardPageWizard_SelectPO.Text = "Select Purchase Order"
            '
            'WizardPageWizard_SelectDetails
            '
            Me.WizardPageWizard_SelectDetails.Controls.Add(Me.PanelSelectDetails_SelectDetails)
            Me.WizardPageWizard_SelectDetails.DescriptionText = ""
            Me.WizardPageWizard_SelectDetails.Name = "WizardPageWizard_SelectDetails"
            Me.WizardPageWizard_SelectDetails.Size = New System.Drawing.Size(664, 338)
            Me.WizardPageWizard_SelectDetails.Text = "Select Purchase Order Detail(s)"
            '
            'PanelSelectDetails_SelectDetails
            '
            Me.PanelSelectDetails_SelectDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSelectDetails_SelectDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelSelectDetails_SelectDetails.Controls.Add(Me.PanelSelectDetails_Top)
            Me.PanelSelectDetails_SelectDetails.Controls.Add(Me.PanelSelectDetails_Bottom)
            Me.PanelSelectDetails_SelectDetails.Location = New System.Drawing.Point(3, 3)
            Me.PanelSelectDetails_SelectDetails.Name = "PanelSelectDetails_SelectDetails"
            Me.PanelSelectDetails_SelectDetails.Size = New System.Drawing.Size(658, 332)
            Me.PanelSelectDetails_SelectDetails.TabIndex = 0
            '
            'PanelSelectDetails_Top
            '
            Me.PanelSelectDetails_Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelSelectDetails_Top.Controls.Add(Me.DataGridViewSelectPODetails_Details)
            Me.PanelSelectDetails_Top.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSelectDetails_Top.Location = New System.Drawing.Point(0, 0)
            Me.PanelSelectDetails_Top.Name = "PanelSelectDetails_Top"
            Me.PanelSelectDetails_Top.Size = New System.Drawing.Size(658, 306)
            Me.PanelSelectDetails_Top.TabIndex = 0
            '
            'DataGridViewSelectPODetails_Details
            '
            Me.DataGridViewSelectPODetails_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectPODetails_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectPODetails_Details.AutoFilterLookupColumns = False
            Me.DataGridViewSelectPODetails_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectPODetails_Details.AutoUpdateViewCaption = True
            Me.DataGridViewSelectPODetails_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSelectPODetails_Details.DataSource = Nothing
            Me.DataGridViewSelectPODetails_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectPODetails_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewSelectPODetails_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectPODetails_Details.ItemDescription = "Item(s)"
            Me.DataGridViewSelectPODetails_Details.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewSelectPODetails_Details.MultiSelect = True
            Me.DataGridViewSelectPODetails_Details.Name = "DataGridViewSelectPODetails_Details"
            Me.DataGridViewSelectPODetails_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectPODetails_Details.RunStandardValidation = True
            Me.DataGridViewSelectPODetails_Details.ShowSelectDeselectAllButtons = True
            Me.DataGridViewSelectPODetails_Details.Size = New System.Drawing.Size(658, 306)
            Me.DataGridViewSelectPODetails_Details.TabIndex = 0
            Me.DataGridViewSelectPODetails_Details.UseEmbeddedNavigator = False
            Me.DataGridViewSelectPODetails_Details.ViewCaptionHeight = -1
            '
            'PanelSelectDetails_Bottom
            '
            Me.PanelSelectDetails_Bottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelSelectDetails_Bottom.Controls.Add(Me.CheckBoxSelectDetails_ExcludeJobAndComponent)
            Me.PanelSelectDetails_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelSelectDetails_Bottom.Location = New System.Drawing.Point(0, 306)
            Me.PanelSelectDetails_Bottom.Name = "PanelSelectDetails_Bottom"
            Me.PanelSelectDetails_Bottom.Size = New System.Drawing.Size(658, 26)
            Me.PanelSelectDetails_Bottom.TabIndex = 1
            '
            'CheckBoxSelectDetails_ExcludeJobAndComponent
            '
            '
            '
            '
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.CheckValue = 0
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.CheckValueChecked = 1
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.CheckValueUnchecked = 0
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.ChildControls = CType(resources.GetObject("CheckBoxSelectDetails_ExcludeJobAndComponent.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.Location = New System.Drawing.Point(0, 6)
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.Name = "CheckBoxSelectDetails_ExcludeJobAndComponent"
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.OldestSibling = Nothing
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.SecurityEnabled = True
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.SiblingControls = CType(resources.GetObject("CheckBoxSelectDetails_ExcludeJobAndComponent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.Size = New System.Drawing.Size(658, 20)
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.TabIndex = 0
            Me.CheckBoxSelectDetails_ExcludeJobAndComponent.Text = "Exclude Job/Component information from copy"
            '
            'WizardPageWizard_UpdateJobInfo
            '
            Me.WizardPageWizard_UpdateJobInfo.Controls.Add(Me.DataGridViewUpdateJobInfo_Details)
            Me.WizardPageWizard_UpdateJobInfo.DescriptionText = ""
            Me.WizardPageWizard_UpdateJobInfo.Name = "WizardPageWizard_UpdateJobInfo"
            Me.WizardPageWizard_UpdateJobInfo.Size = New System.Drawing.Size(664, 338)
            Me.WizardPageWizard_UpdateJobInfo.Text = "Update Job Information"
            '
            'DataGridViewUpdateJobInfo_Details
            '
            Me.DataGridViewUpdateJobInfo_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewUpdateJobInfo_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewUpdateJobInfo_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewUpdateJobInfo_Details.AutoFilterLookupColumns = False
            Me.DataGridViewUpdateJobInfo_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewUpdateJobInfo_Details.AutoUpdateViewCaption = True
            Me.DataGridViewUpdateJobInfo_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewUpdateJobInfo_Details.DataSource = Nothing
            Me.DataGridViewUpdateJobInfo_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewUpdateJobInfo_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewUpdateJobInfo_Details.ItemDescription = "Item(s)"
            Me.DataGridViewUpdateJobInfo_Details.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewUpdateJobInfo_Details.MultiSelect = True
            Me.DataGridViewUpdateJobInfo_Details.Name = "DataGridViewUpdateJobInfo_Details"
            Me.DataGridViewUpdateJobInfo_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewUpdateJobInfo_Details.RunStandardValidation = True
            Me.DataGridViewUpdateJobInfo_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewUpdateJobInfo_Details.Size = New System.Drawing.Size(658, 332)
            Me.DataGridViewUpdateJobInfo_Details.TabIndex = 8
            Me.DataGridViewUpdateJobInfo_Details.UseEmbeddedNavigator = False
            Me.DataGridViewUpdateJobInfo_Details.ViewCaptionHeight = -1
            '
            'PurchaseOrderDetailCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(696, 481)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PurchaseOrderDetailCopyDialog"
            Me.Text = "Purchase Order"
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_CopyingPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectPO.ResumeLayout(False)
            Me.WizardPageWizard_SelectDetails.ResumeLayout(False)
            CType(Me.PanelSelectDetails_SelectDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSelectDetails_SelectDetails.ResumeLayout(False)
            CType(Me.PanelSelectDetails_Top, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSelectDetails_Top.ResumeLayout(False)
            CType(Me.PanelSelectDetails_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSelectDetails_Bottom.ResumeLayout(False)
            Me.WizardPageWizard_UpdateJobInfo.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewSelectPO_PurchaseOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Protected WithEvents WizardPageWizard_CopyingPage As DevExpress.XtraWizard.WizardPage
        Protected WithEvents LabelCopyingPage_OverallCopyStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents LabelCopyingPage_Copying As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents ProgressBarCopyingPage_Progress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents WizardPageWizard_SelectPO As DevExpress.XtraWizard.WizardPage
        Friend WithEvents WizardPageWizard_SelectDetails As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectPODetails_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WizardPageWizard_UpdateJobInfo As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewUpdateJobInfo_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelSelectDetails_SelectDetails As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSelectDetails_Top As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSelectDetails_Bottom As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxSelectDetails_ExcludeJobAndComponent As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace
