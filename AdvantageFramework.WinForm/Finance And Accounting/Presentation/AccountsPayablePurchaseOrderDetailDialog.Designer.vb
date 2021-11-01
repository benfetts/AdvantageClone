Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayablePurchaseOrderDetailDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayablePurchaseOrderDetailDialog))
            Me.LabelForm_Revision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_IssuedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_IssuedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputForm_TotalPOAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_TotalPOAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_WorkComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_PORevision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_POIssuedDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_POIssuedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_PurchaseOrderDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.NumericInputForm_TotalPOAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelForm_Revision
            '
            Me.LabelForm_Revision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Revision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Revision.Location = New System.Drawing.Point(114, 64)
            Me.LabelForm_Revision.Name = "LabelForm_Revision"
            Me.LabelForm_Revision.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_Revision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Revision.TabIndex = 16
            '
            'LabelForm_IssuedDate
            '
            Me.LabelForm_IssuedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_IssuedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_IssuedDate.Location = New System.Drawing.Point(114, 38)
            Me.LabelForm_IssuedDate.Name = "LabelForm_IssuedDate"
            Me.LabelForm_IssuedDate.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_IssuedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_IssuedDate.TabIndex = 14
            '
            'LabelForm_IssuedBy
            '
            Me.LabelForm_IssuedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_IssuedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_IssuedBy.Location = New System.Drawing.Point(114, 12)
            Me.LabelForm_IssuedBy.Name = "LabelForm_IssuedBy"
            Me.LabelForm_IssuedBy.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_IssuedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_IssuedBy.TabIndex = 12
            '
            'NumericInputForm_TotalPOAmount
            '
            Me.NumericInputForm_TotalPOAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_TotalPOAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_TotalPOAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_TotalPOAmount.Location = New System.Drawing.Point(505, 12)
            Me.NumericInputForm_TotalPOAmount.Name = "NumericInputForm_TotalPOAmount"
            Me.NumericInputForm_TotalPOAmount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputForm_TotalPOAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalPOAmount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputForm_TotalPOAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalPOAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_TotalPOAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_TotalPOAmount.Properties.ReadOnly = True
            Me.NumericInputForm_TotalPOAmount.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputForm_TotalPOAmount.TabIndex = 18
            Me.NumericInputForm_TotalPOAmount.TabStop = False
            '
            'LabelForm_TotalPOAmount
            '
            Me.LabelForm_TotalPOAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalPOAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalPOAmount.Location = New System.Drawing.Point(403, 12)
            Me.LabelForm_TotalPOAmount.Name = "LabelForm_TotalPOAmount"
            Me.LabelForm_TotalPOAmount.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_TotalPOAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalPOAmount.TabIndex = 17
            Me.LabelForm_TotalPOAmount.Text = "Total PO Amount:"
            '
            'CheckBoxForm_WorkComplete
            '
            Me.CheckBoxForm_WorkComplete.AutoCheck = False
            '
            '
            '
            Me.CheckBoxForm_WorkComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_WorkComplete.CheckValue = 0
            Me.CheckBoxForm_WorkComplete.CheckValueChecked = 1
            Me.CheckBoxForm_WorkComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_WorkComplete.CheckValueUnchecked = 0
            Me.CheckBoxForm_WorkComplete.ChildControls = Nothing
            Me.CheckBoxForm_WorkComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_WorkComplete.Enabled = False
            Me.CheckBoxForm_WorkComplete.Location = New System.Drawing.Point(505, 38)
            Me.CheckBoxForm_WorkComplete.Name = "CheckBoxForm_WorkComplete"
            Me.CheckBoxForm_WorkComplete.OldestSibling = Nothing
            Me.CheckBoxForm_WorkComplete.SecurityEnabled = True
            Me.CheckBoxForm_WorkComplete.SiblingControls = Nothing
            Me.CheckBoxForm_WorkComplete.Size = New System.Drawing.Size(119, 20)
            Me.CheckBoxForm_WorkComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_WorkComplete.TabIndex = 19
            Me.CheckBoxForm_WorkComplete.Text = "Work Complete"
            '
            'LabelForm_PORevision
            '
            Me.LabelForm_PORevision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PORevision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PORevision.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_PORevision.Name = "LabelForm_PORevision"
            Me.LabelForm_PORevision.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_PORevision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PORevision.TabIndex = 15
            Me.LabelForm_PORevision.Text = "Revision:"
            '
            'LabelForm_POIssuedDate
            '
            Me.LabelForm_POIssuedDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_POIssuedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_POIssuedDate.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_POIssuedDate.Name = "LabelForm_POIssuedDate"
            Me.LabelForm_POIssuedDate.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_POIssuedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_POIssuedDate.TabIndex = 13
            Me.LabelForm_POIssuedDate.Text = "Issued Date:"
            '
            'LabelForm_POIssuedBy
            '
            Me.LabelForm_POIssuedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_POIssuedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_POIssuedBy.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_POIssuedBy.Name = "LabelForm_POIssuedBy"
            Me.LabelForm_POIssuedBy.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_POIssuedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_POIssuedBy.TabIndex = 11
            Me.LabelForm_POIssuedBy.Text = "Issued By:"
            '
            'DataGridViewForm_PurchaseOrderDetails
            '
            Me.DataGridViewForm_PurchaseOrderDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_PurchaseOrderDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_PurchaseOrderDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_PurchaseOrderDetails.AutoFilterLookupColumns = False
            Me.DataGridViewForm_PurchaseOrderDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_PurchaseOrderDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_PurchaseOrderDetails.DataSource = Nothing
            Me.DataGridViewForm_PurchaseOrderDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_PurchaseOrderDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_PurchaseOrderDetails.ItemDescription = "Purchase Order Detail"
            Me.DataGridViewForm_PurchaseOrderDetails.Location = New System.Drawing.Point(12, 90)
            Me.DataGridViewForm_PurchaseOrderDetails.MultiSelect = False
            Me.DataGridViewForm_PurchaseOrderDetails.Name = "DataGridViewForm_PurchaseOrderDetails"
            Me.DataGridViewForm_PurchaseOrderDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_PurchaseOrderDetails.RunStandardValidation = True
            Me.DataGridViewForm_PurchaseOrderDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_PurchaseOrderDetails.Size = New System.Drawing.Size(977, 129)
            Me.DataGridViewForm_PurchaseOrderDetails.TabIndex = 20
            Me.DataGridViewForm_PurchaseOrderDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_PurchaseOrderDetails.ViewCaptionHeight = -1
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(914, 225)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 21
            Me.ButtonForm_Close.Text = "Close"
            '
            'AccountsPayablePurchaseOrderDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1001, 257)
            Me.Controls.Add(Me.LabelForm_Revision)
            Me.Controls.Add(Me.LabelForm_IssuedDate)
            Me.Controls.Add(Me.LabelForm_IssuedBy)
            Me.Controls.Add(Me.NumericInputForm_TotalPOAmount)
            Me.Controls.Add(Me.LabelForm_TotalPOAmount)
            Me.Controls.Add(Me.CheckBoxForm_WorkComplete)
            Me.Controls.Add(Me.LabelForm_PORevision)
            Me.Controls.Add(Me.LabelForm_POIssuedDate)
            Me.Controls.Add(Me.LabelForm_POIssuedBy)
            Me.Controls.Add(Me.DataGridViewForm_PurchaseOrderDetails)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AccountsPayablePurchaseOrderDetailDialog"
            Me.Text = "Purchase Order Detail"
            CType(Me.NumericInputForm_TotalPOAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Revision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_IssuedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_IssuedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_TotalPOAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_TotalPOAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_WorkComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_PORevision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_POIssuedDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_POIssuedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_PurchaseOrderDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace

