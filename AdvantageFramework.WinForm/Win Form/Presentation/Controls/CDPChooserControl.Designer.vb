Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CDPChooserControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewControl_Clients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_ChooseClientDivisionProducts = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseClientDivisions = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_AllClients = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseClients = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_Clients
            '
            Me.DataGridViewControl_Clients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_Clients.AllowDragAndDrop = False
            Me.DataGridViewControl_Clients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Clients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_Clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_Clients.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Clients.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_Clients.DataSource = Nothing
            Me.DataGridViewControl_Clients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Clients.ItemDescription = "Client(s)"
            Me.DataGridViewControl_Clients.Location = New System.Drawing.Point(0, 23)
            Me.DataGridViewControl_Clients.MultiSelect = True
            Me.DataGridViewControl_Clients.Name = "DataGridViewControl_Clients"
            Me.DataGridViewControl_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_Clients.RunStandardValidation = True
            Me.DataGridViewControl_Clients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_Clients.ShowSelectDeselectAllButtons = True
            Me.DataGridViewControl_Clients.Size = New System.Drawing.Size(571, 359)
            Me.DataGridViewControl_Clients.TabIndex = 15
            Me.DataGridViewControl_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Clients.ViewCaptionHeight = -1
            '
            'RadioButtonControl_ChooseClientDivisionProducts
            '
            Me.RadioButtonControl_ChooseClientDivisionProducts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseClientDivisionProducts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseClientDivisionProducts.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseClientDivisionProducts.Location = New System.Drawing.Point(347, 0)
            Me.RadioButtonControl_ChooseClientDivisionProducts.Name = "RadioButtonControl_ChooseClientDivisionProducts"
            Me.RadioButtonControl_ChooseClientDivisionProducts.SecurityEnabled = True
            Me.RadioButtonControl_ChooseClientDivisionProducts.Size = New System.Drawing.Size(197, 20)
            Me.RadioButtonControl_ChooseClientDivisionProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseClientDivisionProducts.TabIndex = 14
            Me.RadioButtonControl_ChooseClientDivisionProducts.TabOnEnter = True
            Me.RadioButtonControl_ChooseClientDivisionProducts.TabStop = False
            Me.RadioButtonControl_ChooseClientDivisionProducts.Text = "Choose Client/Division/Products"
            '
            'RadioButtonControl_ChooseClientDivisions
            '
            Me.RadioButtonControl_ChooseClientDivisions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseClientDivisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseClientDivisions.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseClientDivisions.Location = New System.Drawing.Point(194, 0)
            Me.RadioButtonControl_ChooseClientDivisions.Name = "RadioButtonControl_ChooseClientDivisions"
            Me.RadioButtonControl_ChooseClientDivisions.SecurityEnabled = True
            Me.RadioButtonControl_ChooseClientDivisions.Size = New System.Drawing.Size(147, 20)
            Me.RadioButtonControl_ChooseClientDivisions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseClientDivisions.TabIndex = 13
            Me.RadioButtonControl_ChooseClientDivisions.TabOnEnter = True
            Me.RadioButtonControl_ChooseClientDivisions.TabStop = False
            Me.RadioButtonControl_ChooseClientDivisions.Text = "Choose Client/Divisions"
            '
            'RadioButtonControl_AllClients
            '
            Me.RadioButtonControl_AllClients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllClients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllClients.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllClients.Checked = True
            Me.RadioButtonControl_AllClients.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllClients.CheckValue = "Y"
            Me.RadioButtonControl_AllClients.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllClients.Name = "RadioButtonControl_AllClients"
            Me.RadioButtonControl_AllClients.SecurityEnabled = True
            Me.RadioButtonControl_AllClients.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonControl_AllClients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllClients.TabIndex = 11
            Me.RadioButtonControl_AllClients.TabOnEnter = True
            Me.RadioButtonControl_AllClients.Text = "All Clients"
            '
            'RadioButtonControl_ChooseClients
            '
            Me.RadioButtonControl_ChooseClients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseClients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseClients.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseClients.Location = New System.Drawing.Point(83, 0)
            Me.RadioButtonControl_ChooseClients.Name = "RadioButtonControl_ChooseClients"
            Me.RadioButtonControl_ChooseClients.SecurityEnabled = True
            Me.RadioButtonControl_ChooseClients.Size = New System.Drawing.Size(105, 20)
            Me.RadioButtonControl_ChooseClients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseClients.TabIndex = 12
            Me.RadioButtonControl_ChooseClients.TabOnEnter = True
            Me.RadioButtonControl_ChooseClients.TabStop = False
            Me.RadioButtonControl_ChooseClients.Text = "Choose Clients"
            '
            'CDPChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewControl_Clients)
            Me.Controls.Add(Me.RadioButtonControl_ChooseClientDivisionProducts)
            Me.Controls.Add(Me.RadioButtonControl_ChooseClientDivisions)
            Me.Controls.Add(Me.RadioButtonControl_AllClients)
            Me.Controls.Add(Me.RadioButtonControl_ChooseClients)
            Me.Name = "CDPChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents RadioButtonControl_ChooseClientDivisionProducts As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseClientDivisions As RadioButtonControl
        Friend WithEvents RadioButtonControl_AllClients As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseClients As RadioButtonControl
        Friend WithEvents DataGridViewControl_Clients As DataGridView
    End Class

End Namespace