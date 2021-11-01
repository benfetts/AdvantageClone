Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderAPDetailDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderAPDetailDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_APDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_POQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PORate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_POAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ActualVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Rate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Quantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ActVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(556, 348)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 4
            Me.ButtonForm_Close.Text = "Close"
            '
            'DataGridViewForm_APDetails
            '
            Me.DataGridViewForm_APDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_APDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_APDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_APDetails.AutoFilterLookupColumns = False
            Me.DataGridViewForm_APDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_APDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_APDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_APDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_APDetails.ItemDescription = "Item(s)"
            Me.DataGridViewForm_APDetails.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_APDetails.MultiSelect = True
            Me.DataGridViewForm_APDetails.Name = "DataGridViewForm_APDetails"
            Me.DataGridViewForm_APDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_APDetails.RunStandardValidation = True
            Me.DataGridViewForm_APDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_APDetails.Size = New System.Drawing.Size(619, 254)
            Me.DataGridViewForm_APDetails.TabIndex = 5
            Me.DataGridViewForm_APDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_APDetails.ViewCaptionHeight = -1
            '
            'LabelForm_POQuantity
            '
            Me.LabelForm_POQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_POQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_POQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_POQuantity.Location = New System.Drawing.Point(13, 272)
            Me.LabelForm_POQuantity.Name = "LabelForm_POQuantity"
            Me.LabelForm_POQuantity.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_POQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_POQuantity.TabIndex = 6
            Me.LabelForm_POQuantity.Text = "PO Quantity:"
            '
            'LabelForm_PORate
            '
            Me.LabelForm_PORate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PORate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PORate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PORate.Location = New System.Drawing.Point(13, 298)
            Me.LabelForm_PORate.Name = "LabelForm_PORate"
            Me.LabelForm_PORate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_PORate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PORate.TabIndex = 7
            Me.LabelForm_PORate.Text = "PO Rate:"
            '
            'LabelForm_POAmount
            '
            Me.LabelForm_POAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_POAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_POAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_POAmount.Location = New System.Drawing.Point(13, 324)
            Me.LabelForm_POAmount.Name = "LabelForm_POAmount"
            Me.LabelForm_POAmount.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_POAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_POAmount.TabIndex = 8
            Me.LabelForm_POAmount.Text = "PO Amount:"
            '
            'LabelForm_EstimateAmount
            '
            Me.LabelForm_EstimateAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateAmount.Location = New System.Drawing.Point(221, 324)
            Me.LabelForm_EstimateAmount.Name = "LabelForm_EstimateAmount"
            Me.LabelForm_EstimateAmount.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstimateAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateAmount.TabIndex = 11
            Me.LabelForm_EstimateAmount.Text = "Estimate Amount:"
            '
            'LabelForm_EstimateRate
            '
            Me.LabelForm_EstimateRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateRate.Location = New System.Drawing.Point(221, 298)
            Me.LabelForm_EstimateRate.Name = "LabelForm_EstimateRate"
            Me.LabelForm_EstimateRate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstimateRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateRate.TabIndex = 10
            Me.LabelForm_EstimateRate.Text = "Estimate Rate:"
            '
            'LabelForm_EstimateQuantity
            '
            Me.LabelForm_EstimateQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateQuantity.Location = New System.Drawing.Point(221, 272)
            Me.LabelForm_EstimateQuantity.Name = "LabelForm_EstimateQuantity"
            Me.LabelForm_EstimateQuantity.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstimateQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateQuantity.TabIndex = 9
            Me.LabelForm_EstimateQuantity.Text = "Estimate Quantity:"
            '
            'LabelForm_EstimateVariance
            '
            Me.LabelForm_EstimateVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateVariance.Location = New System.Drawing.Point(429, 298)
            Me.LabelForm_EstimateVariance.Name = "LabelForm_EstimateVariance"
            Me.LabelForm_EstimateVariance.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstimateVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateVariance.TabIndex = 13
            Me.LabelForm_EstimateVariance.Text = "Estimate Variance:"
            '
            'LabelForm_ActualVariance
            '
            Me.LabelForm_ActualVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ActualVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ActualVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ActualVariance.Location = New System.Drawing.Point(429, 272)
            Me.LabelForm_ActualVariance.Name = "LabelForm_ActualVariance"
            Me.LabelForm_ActualVariance.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_ActualVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ActualVariance.TabIndex = 12
            Me.LabelForm_ActualVariance.Text = "Actual Variance:"
            '
            'LabelForm_Amount
            '
            Me.LabelForm_Amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Amount.Location = New System.Drawing.Point(117, 324)
            Me.LabelForm_Amount.Name = "LabelForm_Amount"
            Me.LabelForm_Amount.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Amount.TabIndex = 16
            Me.LabelForm_Amount.Text = "{0}"
            '
            'LabelForm_Rate
            '
            Me.LabelForm_Rate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Rate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Rate.Location = New System.Drawing.Point(117, 298)
            Me.LabelForm_Rate.Name = "LabelForm_Rate"
            Me.LabelForm_Rate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_Rate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Rate.TabIndex = 15
            Me.LabelForm_Rate.Text = "{0}"
            '
            'LabelForm_Quantity
            '
            Me.LabelForm_Quantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Quantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Quantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Quantity.Location = New System.Drawing.Point(117, 272)
            Me.LabelForm_Quantity.Name = "LabelForm_Quantity"
            Me.LabelForm_Quantity.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_Quantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Quantity.TabIndex = 14
            Me.LabelForm_Quantity.Text = "{0}"
            '
            'LabelForm_EstVariance
            '
            Me.LabelForm_EstVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstVariance.Location = New System.Drawing.Point(533, 298)
            Me.LabelForm_EstVariance.Name = "LabelForm_EstVariance"
            Me.LabelForm_EstVariance.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstVariance.TabIndex = 18
            Me.LabelForm_EstVariance.Text = "{0}"
            '
            'LabelForm_ActVariance
            '
            Me.LabelForm_ActVariance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ActVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ActVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ActVariance.Location = New System.Drawing.Point(533, 272)
            Me.LabelForm_ActVariance.Name = "LabelForm_ActVariance"
            Me.LabelForm_ActVariance.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_ActVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ActVariance.TabIndex = 17
            Me.LabelForm_ActVariance.Text = "{0}"
            '
            'LabelForm_EstAmount
            '
            Me.LabelForm_EstAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstAmount.Location = New System.Drawing.Point(325, 324)
            Me.LabelForm_EstAmount.Name = "LabelForm_EstAmount"
            Me.LabelForm_EstAmount.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstAmount.TabIndex = 21
            Me.LabelForm_EstAmount.Text = "{0}"
            '
            'LabelForm_EstRate
            '
            Me.LabelForm_EstRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstRate.Location = New System.Drawing.Point(325, 298)
            Me.LabelForm_EstRate.Name = "LabelForm_EstRate"
            Me.LabelForm_EstRate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstRate.TabIndex = 20
            Me.LabelForm_EstRate.Text = "{0}"
            '
            'LabelForm_EstQuantity
            '
            Me.LabelForm_EstQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstQuantity.Location = New System.Drawing.Point(325, 272)
            Me.LabelForm_EstQuantity.Name = "LabelForm_EstQuantity"
            Me.LabelForm_EstQuantity.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EstQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstQuantity.TabIndex = 19
            Me.LabelForm_EstQuantity.Text = "{0}"
            '
            'PurchaseOrderAPDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(643, 380)
            Me.Controls.Add(Me.LabelForm_EstAmount)
            Me.Controls.Add(Me.LabelForm_EstRate)
            Me.Controls.Add(Me.LabelForm_EstQuantity)
            Me.Controls.Add(Me.LabelForm_EstVariance)
            Me.Controls.Add(Me.LabelForm_ActVariance)
            Me.Controls.Add(Me.LabelForm_Amount)
            Me.Controls.Add(Me.LabelForm_Rate)
            Me.Controls.Add(Me.LabelForm_Quantity)
            Me.Controls.Add(Me.LabelForm_EstimateVariance)
            Me.Controls.Add(Me.LabelForm_ActualVariance)
            Me.Controls.Add(Me.LabelForm_EstimateAmount)
            Me.Controls.Add(Me.LabelForm_EstimateRate)
            Me.Controls.Add(Me.LabelForm_EstimateQuantity)
            Me.Controls.Add(Me.LabelForm_POAmount)
            Me.Controls.Add(Me.LabelForm_PORate)
            Me.Controls.Add(Me.LabelForm_POQuantity)
            Me.Controls.Add(Me.DataGridViewForm_APDetails)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PurchaseOrderAPDetailDialog"
            Me.Text = "Purchase Order AP Details"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_APDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_POQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PORate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_POAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstimateAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstimateRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstimateQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstimateVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ActualVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Rate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Quantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ActVariance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EstQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace