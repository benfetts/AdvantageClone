Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TimesheetDetailsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimesheetDetailsDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxQuoteVsActual_EmployeeOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelQuoteVsActual_ActualHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Revision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Quote = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursQuoted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursPosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursRemaining = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountQuoted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountPosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountRemaining = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountRemainingLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountPostedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_AmountQuotedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursRemainingLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursPostedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_HoursQuotedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewQuoteVsActual_ActualHours = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelQuoteVsActual_FunctionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_RevisionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_QuoteLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_EstimateLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_ComponentLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_JobLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelQuoteVsActual_ClientLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewTrafficHours_TrafficHours = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelTrafficHours_TrafficHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_ActualHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursAllowed = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursPosted = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursRemaining = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursRemainingLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursPostedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_HoursAllowedLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewTrafficHours_ActualHours = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelTrafficHours_FunctionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_ComponentLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_JobLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrafficHours_ClientLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlForm_Details = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTrafficHoursTab_TrafficHours = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelTrafficHours_NoTrafficHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemDetails_TrafficHoursTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemDetails_QuoteVsActualTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TableLayoutPanelTrafficHours_TrafficHours = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTopRow_TrafficHours = New System.Windows.Forms.Panel()
            Me.PanelBottomRow_TrafficHours = New System.Windows.Forms.Panel()
            CType(Me.TabControlForm_Details, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Details.SuspendLayout()
            Me.TabControlPanelTrafficHoursTab_TrafficHours.SuspendLayout()
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.SuspendLayout()
            Me.TableLayoutPanelTrafficHours_TrafficHours.SuspendLayout()
            Me.PanelTopRow_TrafficHours.SuspendLayout()
            Me.PanelBottomRow_TrafficHours.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(500, 472)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 2
            Me.ButtonForm_Close.Text = "Close"
            '
            'CheckBoxQuoteVsActual_EmployeeOnly
            '
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxQuoteVsActual_EmployeeOnly.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxQuoteVsActual_EmployeeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxQuoteVsActual_EmployeeOnly.CheckValue = 0
            Me.CheckBoxQuoteVsActual_EmployeeOnly.CheckValueChecked = 1
            Me.CheckBoxQuoteVsActual_EmployeeOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxQuoteVsActual_EmployeeOnly.CheckValueUnchecked = 0
            Me.CheckBoxQuoteVsActual_EmployeeOnly.ChildControls = CType(resources.GetObject("CheckBoxQuoteVsActual_EmployeeOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxQuoteVsActual_EmployeeOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Name = "CheckBoxQuoteVsActual_EmployeeOnly"
            Me.CheckBoxQuoteVsActual_EmployeeOnly.OldestSibling = Nothing
            Me.CheckBoxQuoteVsActual_EmployeeOnly.SecurityEnabled = True
            Me.CheckBoxQuoteVsActual_EmployeeOnly.SiblingControls = CType(resources.GetObject("CheckBoxQuoteVsActual_EmployeeOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Size = New System.Drawing.Size(555, 20)
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxQuoteVsActual_EmployeeOnly.TabIndex = 0
            Me.CheckBoxQuoteVsActual_EmployeeOnly.Text = "Employee Only (Displays quoted and actual hours by employee)"
            '
            'LabelQuoteVsActual_ActualHours
            '
            Me.LabelQuoteVsActual_ActualHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_ActualHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_ActualHours.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelQuoteVsActual_ActualHours.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelQuoteVsActual_ActualHours.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelQuoteVsActual_ActualHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_ActualHours.Location = New System.Drawing.Point(4, 212)
            Me.LabelQuoteVsActual_ActualHours.Name = "LabelQuoteVsActual_ActualHours"
            Me.LabelQuoteVsActual_ActualHours.Size = New System.Drawing.Size(555, 20)
            Me.LabelQuoteVsActual_ActualHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_ActualHours.TabIndex = 27
            Me.LabelQuoteVsActual_ActualHours.Text = "Actual Hours"
            '
            'LabelQuoteVsActual_Function
            '
            Me.LabelQuoteVsActual_Function.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Function.Location = New System.Drawing.Point(85, 186)
            Me.LabelQuoteVsActual_Function.Name = "LabelQuoteVsActual_Function"
            Me.LabelQuoteVsActual_Function.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Function.TabIndex = 14
            Me.LabelQuoteVsActual_Function.Text = "{0}"
            '
            'LabelQuoteVsActual_Revision
            '
            Me.LabelQuoteVsActual_Revision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Revision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Revision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Revision.Location = New System.Drawing.Point(85, 160)
            Me.LabelQuoteVsActual_Revision.Name = "LabelQuoteVsActual_Revision"
            Me.LabelQuoteVsActual_Revision.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Revision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Revision.TabIndex = 12
            Me.LabelQuoteVsActual_Revision.Text = "{0}"
            '
            'LabelQuoteVsActual_Quote
            '
            Me.LabelQuoteVsActual_Quote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Quote.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Quote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Quote.Location = New System.Drawing.Point(85, 134)
            Me.LabelQuoteVsActual_Quote.Name = "LabelQuoteVsActual_Quote"
            Me.LabelQuoteVsActual_Quote.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Quote.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Quote.TabIndex = 10
            Me.LabelQuoteVsActual_Quote.Text = "{0}"
            '
            'LabelQuoteVsActual_Estimate
            '
            Me.LabelQuoteVsActual_Estimate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Estimate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Estimate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Estimate.Location = New System.Drawing.Point(85, 108)
            Me.LabelQuoteVsActual_Estimate.Name = "LabelQuoteVsActual_Estimate"
            Me.LabelQuoteVsActual_Estimate.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Estimate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Estimate.TabIndex = 8
            Me.LabelQuoteVsActual_Estimate.Text = "{0}"
            '
            'LabelQuoteVsActual_Component
            '
            Me.LabelQuoteVsActual_Component.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Component.Location = New System.Drawing.Point(85, 82)
            Me.LabelQuoteVsActual_Component.Name = "LabelQuoteVsActual_Component"
            Me.LabelQuoteVsActual_Component.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Component.TabIndex = 6
            Me.LabelQuoteVsActual_Component.Text = "{0}"
            '
            'LabelQuoteVsActual_Job
            '
            Me.LabelQuoteVsActual_Job.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Job.Location = New System.Drawing.Point(85, 56)
            Me.LabelQuoteVsActual_Job.Name = "LabelQuoteVsActual_Job"
            Me.LabelQuoteVsActual_Job.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Job.TabIndex = 4
            Me.LabelQuoteVsActual_Job.Text = "{0}"
            '
            'LabelQuoteVsActual_Client
            '
            Me.LabelQuoteVsActual_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_Client.Location = New System.Drawing.Point(85, 30)
            Me.LabelQuoteVsActual_Client.Name = "LabelQuoteVsActual_Client"
            Me.LabelQuoteVsActual_Client.Size = New System.Drawing.Size(287, 20)
            Me.LabelQuoteVsActual_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_Client.TabIndex = 2
            Me.LabelQuoteVsActual_Client.Text = "{0}"
            '
            'LabelQuoteVsActual_HoursQuoted
            '
            Me.LabelQuoteVsActual_HoursQuoted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursQuoted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursQuoted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursQuoted.Location = New System.Drawing.Point(488, 30)
            Me.LabelQuoteVsActual_HoursQuoted.Name = "LabelQuoteVsActual_HoursQuoted"
            Me.LabelQuoteVsActual_HoursQuoted.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_HoursQuoted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursQuoted.TabIndex = 16
            Me.LabelQuoteVsActual_HoursQuoted.Text = "{0}"
            '
            'LabelQuoteVsActual_HoursPosted
            '
            Me.LabelQuoteVsActual_HoursPosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursPosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursPosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursPosted.Location = New System.Drawing.Point(488, 56)
            Me.LabelQuoteVsActual_HoursPosted.Name = "LabelQuoteVsActual_HoursPosted"
            Me.LabelQuoteVsActual_HoursPosted.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_HoursPosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursPosted.TabIndex = 18
            Me.LabelQuoteVsActual_HoursPosted.Text = "{0}"
            '
            'LabelQuoteVsActual_HoursRemaining
            '
            Me.LabelQuoteVsActual_HoursRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursRemaining.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursRemaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursRemaining.Location = New System.Drawing.Point(488, 82)
            Me.LabelQuoteVsActual_HoursRemaining.Name = "LabelQuoteVsActual_HoursRemaining"
            Me.LabelQuoteVsActual_HoursRemaining.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_HoursRemaining.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursRemaining.TabIndex = 20
            Me.LabelQuoteVsActual_HoursRemaining.Text = "{0}"
            '
            'LabelQuoteVsActual_AmountQuoted
            '
            Me.LabelQuoteVsActual_AmountQuoted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountQuoted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountQuoted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountQuoted.Location = New System.Drawing.Point(488, 134)
            Me.LabelQuoteVsActual_AmountQuoted.Name = "LabelQuoteVsActual_AmountQuoted"
            Me.LabelQuoteVsActual_AmountQuoted.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_AmountQuoted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountQuoted.TabIndex = 22
            Me.LabelQuoteVsActual_AmountQuoted.Text = "{0}"
            '
            'LabelQuoteVsActual_AmountPosted
            '
            Me.LabelQuoteVsActual_AmountPosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountPosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountPosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountPosted.Location = New System.Drawing.Point(488, 160)
            Me.LabelQuoteVsActual_AmountPosted.Name = "LabelQuoteVsActual_AmountPosted"
            Me.LabelQuoteVsActual_AmountPosted.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_AmountPosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountPosted.TabIndex = 24
            Me.LabelQuoteVsActual_AmountPosted.Text = "{0}"
            '
            'LabelQuoteVsActual_AmountRemaining
            '
            Me.LabelQuoteVsActual_AmountRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountRemaining.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountRemaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountRemaining.Location = New System.Drawing.Point(488, 186)
            Me.LabelQuoteVsActual_AmountRemaining.Name = "LabelQuoteVsActual_AmountRemaining"
            Me.LabelQuoteVsActual_AmountRemaining.Size = New System.Drawing.Size(71, 20)
            Me.LabelQuoteVsActual_AmountRemaining.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountRemaining.TabIndex = 26
            Me.LabelQuoteVsActual_AmountRemaining.Text = "{0}"
            '
            'LabelQuoteVsActual_AmountRemainingLbl
            '
            Me.LabelQuoteVsActual_AmountRemainingLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountRemainingLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountRemainingLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountRemainingLbl.Location = New System.Drawing.Point(378, 186)
            Me.LabelQuoteVsActual_AmountRemainingLbl.Name = "LabelQuoteVsActual_AmountRemainingLbl"
            Me.LabelQuoteVsActual_AmountRemainingLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_AmountRemainingLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountRemainingLbl.TabIndex = 25
            Me.LabelQuoteVsActual_AmountRemainingLbl.Text = "Amount Remaining:"
            '
            'LabelQuoteVsActual_AmountPostedLbl
            '
            Me.LabelQuoteVsActual_AmountPostedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountPostedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountPostedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountPostedLbl.Location = New System.Drawing.Point(378, 160)
            Me.LabelQuoteVsActual_AmountPostedLbl.Name = "LabelQuoteVsActual_AmountPostedLbl"
            Me.LabelQuoteVsActual_AmountPostedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_AmountPostedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountPostedLbl.TabIndex = 23
            Me.LabelQuoteVsActual_AmountPostedLbl.Text = "Amount Posted:"
            '
            'LabelQuoteVsActual_AmountQuotedLbl
            '
            Me.LabelQuoteVsActual_AmountQuotedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_AmountQuotedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_AmountQuotedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_AmountQuotedLbl.Location = New System.Drawing.Point(378, 134)
            Me.LabelQuoteVsActual_AmountQuotedLbl.Name = "LabelQuoteVsActual_AmountQuotedLbl"
            Me.LabelQuoteVsActual_AmountQuotedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_AmountQuotedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_AmountQuotedLbl.TabIndex = 21
            Me.LabelQuoteVsActual_AmountQuotedLbl.Text = "Amount Quoted:"
            '
            'LabelQuoteVsActual_HoursRemainingLbl
            '
            Me.LabelQuoteVsActual_HoursRemainingLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursRemainingLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursRemainingLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursRemainingLbl.Location = New System.Drawing.Point(378, 82)
            Me.LabelQuoteVsActual_HoursRemainingLbl.Name = "LabelQuoteVsActual_HoursRemainingLbl"
            Me.LabelQuoteVsActual_HoursRemainingLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_HoursRemainingLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursRemainingLbl.TabIndex = 19
            Me.LabelQuoteVsActual_HoursRemainingLbl.Text = "Hours Remaining:"
            '
            'LabelQuoteVsActual_HoursPostedLbl
            '
            Me.LabelQuoteVsActual_HoursPostedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursPostedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursPostedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursPostedLbl.Location = New System.Drawing.Point(378, 56)
            Me.LabelQuoteVsActual_HoursPostedLbl.Name = "LabelQuoteVsActual_HoursPostedLbl"
            Me.LabelQuoteVsActual_HoursPostedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_HoursPostedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursPostedLbl.TabIndex = 17
            Me.LabelQuoteVsActual_HoursPostedLbl.Text = "Hours Posted:"
            '
            'LabelQuoteVsActual_HoursQuotedLbl
            '
            Me.LabelQuoteVsActual_HoursQuotedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelQuoteVsActual_HoursQuotedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_HoursQuotedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_HoursQuotedLbl.Location = New System.Drawing.Point(378, 30)
            Me.LabelQuoteVsActual_HoursQuotedLbl.Name = "LabelQuoteVsActual_HoursQuotedLbl"
            Me.LabelQuoteVsActual_HoursQuotedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelQuoteVsActual_HoursQuotedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_HoursQuotedLbl.TabIndex = 15
            Me.LabelQuoteVsActual_HoursQuotedLbl.Text = "Hours Quoted:"
            '
            'DataGridViewQuoteVsActual_ActualHours
            '
            Me.DataGridViewQuoteVsActual_ActualHours.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewQuoteVsActual_ActualHours.AllowSelectGroupHeaderRow = True
            Me.DataGridViewQuoteVsActual_ActualHours.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewQuoteVsActual_ActualHours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewQuoteVsActual_ActualHours.AutoFilterLookupColumns = False
            Me.DataGridViewQuoteVsActual_ActualHours.AutoloadRepositoryDatasource = True
            Me.DataGridViewQuoteVsActual_ActualHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewQuoteVsActual_ActualHours.DataSource = Nothing
            Me.DataGridViewQuoteVsActual_ActualHours.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewQuoteVsActual_ActualHours.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewQuoteVsActual_ActualHours.ItemDescription = "Item(s)"
            Me.DataGridViewQuoteVsActual_ActualHours.Location = New System.Drawing.Point(4, 238)
            Me.DataGridViewQuoteVsActual_ActualHours.MultiSelect = True
            Me.DataGridViewQuoteVsActual_ActualHours.Name = "DataGridViewQuoteVsActual_ActualHours"
            Me.DataGridViewQuoteVsActual_ActualHours.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewQuoteVsActual_ActualHours.RunStandardValidation = True
            Me.DataGridViewQuoteVsActual_ActualHours.ShowSelectDeselectAllButtons = False
            Me.DataGridViewQuoteVsActual_ActualHours.Size = New System.Drawing.Size(555, 185)
            Me.DataGridViewQuoteVsActual_ActualHours.TabIndex = 28
            Me.DataGridViewQuoteVsActual_ActualHours.UseEmbeddedNavigator = False
            Me.DataGridViewQuoteVsActual_ActualHours.ViewCaptionHeight = -1
            '
            'LabelQuoteVsActual_FunctionLbl
            '
            Me.LabelQuoteVsActual_FunctionLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_FunctionLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_FunctionLbl.Location = New System.Drawing.Point(4, 186)
            Me.LabelQuoteVsActual_FunctionLbl.Name = "LabelQuoteVsActual_FunctionLbl"
            Me.LabelQuoteVsActual_FunctionLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_FunctionLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_FunctionLbl.TabIndex = 13
            Me.LabelQuoteVsActual_FunctionLbl.Text = "Function:"
            '
            'LabelQuoteVsActual_RevisionLbl
            '
            Me.LabelQuoteVsActual_RevisionLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_RevisionLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_RevisionLbl.Location = New System.Drawing.Point(4, 160)
            Me.LabelQuoteVsActual_RevisionLbl.Name = "LabelQuoteVsActual_RevisionLbl"
            Me.LabelQuoteVsActual_RevisionLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_RevisionLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_RevisionLbl.TabIndex = 11
            Me.LabelQuoteVsActual_RevisionLbl.Text = "Revision:"
            '
            'LabelQuoteVsActual_QuoteLbl
            '
            Me.LabelQuoteVsActual_QuoteLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_QuoteLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_QuoteLbl.Location = New System.Drawing.Point(4, 134)
            Me.LabelQuoteVsActual_QuoteLbl.Name = "LabelQuoteVsActual_QuoteLbl"
            Me.LabelQuoteVsActual_QuoteLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_QuoteLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_QuoteLbl.TabIndex = 9
            Me.LabelQuoteVsActual_QuoteLbl.Text = "Quote:"
            '
            'LabelQuoteVsActual_EstimateLbl
            '
            Me.LabelQuoteVsActual_EstimateLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_EstimateLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_EstimateLbl.Location = New System.Drawing.Point(4, 108)
            Me.LabelQuoteVsActual_EstimateLbl.Name = "LabelQuoteVsActual_EstimateLbl"
            Me.LabelQuoteVsActual_EstimateLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_EstimateLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_EstimateLbl.TabIndex = 7
            Me.LabelQuoteVsActual_EstimateLbl.Text = "Estimate:"
            '
            'LabelQuoteVsActual_ComponentLbl
            '
            Me.LabelQuoteVsActual_ComponentLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_ComponentLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_ComponentLbl.Location = New System.Drawing.Point(4, 82)
            Me.LabelQuoteVsActual_ComponentLbl.Name = "LabelQuoteVsActual_ComponentLbl"
            Me.LabelQuoteVsActual_ComponentLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_ComponentLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_ComponentLbl.TabIndex = 5
            Me.LabelQuoteVsActual_ComponentLbl.Text = "Component:"
            '
            'LabelQuoteVsActual_JobLbl
            '
            Me.LabelQuoteVsActual_JobLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_JobLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_JobLbl.Location = New System.Drawing.Point(4, 56)
            Me.LabelQuoteVsActual_JobLbl.Name = "LabelQuoteVsActual_JobLbl"
            Me.LabelQuoteVsActual_JobLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_JobLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_JobLbl.TabIndex = 3
            Me.LabelQuoteVsActual_JobLbl.Text = "Job:"
            '
            'LabelQuoteVsActual_ClientLbl
            '
            Me.LabelQuoteVsActual_ClientLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelQuoteVsActual_ClientLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelQuoteVsActual_ClientLbl.Location = New System.Drawing.Point(4, 30)
            Me.LabelQuoteVsActual_ClientLbl.Name = "LabelQuoteVsActual_ClientLbl"
            Me.LabelQuoteVsActual_ClientLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelQuoteVsActual_ClientLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelQuoteVsActual_ClientLbl.TabIndex = 1
            Me.LabelQuoteVsActual_ClientLbl.Text = "Client:"
            '
            'DataGridViewTrafficHours_TrafficHours
            '
            Me.DataGridViewTrafficHours_TrafficHours.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTrafficHours_TrafficHours.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTrafficHours_TrafficHours.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTrafficHours_TrafficHours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTrafficHours_TrafficHours.AutoFilterLookupColumns = False
            Me.DataGridViewTrafficHours_TrafficHours.AutoloadRepositoryDatasource = True
            Me.DataGridViewTrafficHours_TrafficHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewTrafficHours_TrafficHours.DataSource = Nothing
            Me.DataGridViewTrafficHours_TrafficHours.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTrafficHours_TrafficHours.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTrafficHours_TrafficHours.ItemDescription = "Item(s)"
            Me.DataGridViewTrafficHours_TrafficHours.Location = New System.Drawing.Point(0, 30)
            Me.DataGridViewTrafficHours_TrafficHours.MultiSelect = True
            Me.DataGridViewTrafficHours_TrafficHours.Name = "DataGridViewTrafficHours_TrafficHours"
            Me.DataGridViewTrafficHours_TrafficHours.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTrafficHours_TrafficHours.RunStandardValidation = True
            Me.DataGridViewTrafficHours_TrafficHours.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTrafficHours_TrafficHours.Size = New System.Drawing.Size(555, 128)
            Me.DataGridViewTrafficHours_TrafficHours.TabIndex = 1
            Me.DataGridViewTrafficHours_TrafficHours.UseEmbeddedNavigator = False
            Me.DataGridViewTrafficHours_TrafficHours.ViewCaptionHeight = -1
            '
            'LabelTrafficHours_TrafficHours
            '
            Me.LabelTrafficHours_TrafficHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_TrafficHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_TrafficHours.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrafficHours_TrafficHours.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrafficHours_TrafficHours.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrafficHours_TrafficHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_TrafficHours.Location = New System.Drawing.Point(0, 4)
            Me.LabelTrafficHours_TrafficHours.Name = "LabelTrafficHours_TrafficHours"
            Me.LabelTrafficHours_TrafficHours.Size = New System.Drawing.Size(555, 20)
            Me.LabelTrafficHours_TrafficHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_TrafficHours.TabIndex = 0
            Me.LabelTrafficHours_TrafficHours.Text = "Traffic Hours"
            '
            'LabelTrafficHours_ActualHours
            '
            Me.LabelTrafficHours_ActualHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_ActualHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_ActualHours.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrafficHours_ActualHours.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrafficHours_ActualHours.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrafficHours_ActualHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_ActualHours.Location = New System.Drawing.Point(0, 0)
            Me.LabelTrafficHours_ActualHours.Name = "LabelTrafficHours_ActualHours"
            Me.LabelTrafficHours_ActualHours.Size = New System.Drawing.Size(555, 20)
            Me.LabelTrafficHours_ActualHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_ActualHours.TabIndex = 0
            Me.LabelTrafficHours_ActualHours.Text = "Actual Hours"
            '
            'LabelTrafficHours_Function
            '
            Me.LabelTrafficHours_Function.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_Function.Location = New System.Drawing.Point(85, 82)
            Me.LabelTrafficHours_Function.Name = "LabelTrafficHours_Function"
            Me.LabelTrafficHours_Function.Size = New System.Drawing.Size(287, 20)
            Me.LabelTrafficHours_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_Function.TabIndex = 7
            Me.LabelTrafficHours_Function.Text = "{0}"
            '
            'LabelTrafficHours_Component
            '
            Me.LabelTrafficHours_Component.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_Component.Location = New System.Drawing.Point(85, 56)
            Me.LabelTrafficHours_Component.Name = "LabelTrafficHours_Component"
            Me.LabelTrafficHours_Component.Size = New System.Drawing.Size(287, 20)
            Me.LabelTrafficHours_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_Component.TabIndex = 5
            Me.LabelTrafficHours_Component.Text = "{0}"
            '
            'LabelTrafficHours_Job
            '
            Me.LabelTrafficHours_Job.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_Job.Location = New System.Drawing.Point(85, 30)
            Me.LabelTrafficHours_Job.Name = "LabelTrafficHours_Job"
            Me.LabelTrafficHours_Job.Size = New System.Drawing.Size(287, 20)
            Me.LabelTrafficHours_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_Job.TabIndex = 3
            Me.LabelTrafficHours_Job.Text = "{0}"
            '
            'LabelTrafficHours_Client
            '
            Me.LabelTrafficHours_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_Client.Location = New System.Drawing.Point(85, 4)
            Me.LabelTrafficHours_Client.Name = "LabelTrafficHours_Client"
            Me.LabelTrafficHours_Client.Size = New System.Drawing.Size(287, 20)
            Me.LabelTrafficHours_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_Client.TabIndex = 1
            Me.LabelTrafficHours_Client.Text = "{0}"
            '
            'LabelTrafficHours_HoursAllowed
            '
            Me.LabelTrafficHours_HoursAllowed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursAllowed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursAllowed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursAllowed.Location = New System.Drawing.Point(488, 4)
            Me.LabelTrafficHours_HoursAllowed.Name = "LabelTrafficHours_HoursAllowed"
            Me.LabelTrafficHours_HoursAllowed.Size = New System.Drawing.Size(71, 20)
            Me.LabelTrafficHours_HoursAllowed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursAllowed.TabIndex = 9
            Me.LabelTrafficHours_HoursAllowed.Text = "{0}"
            '
            'LabelTrafficHours_HoursPosted
            '
            Me.LabelTrafficHours_HoursPosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursPosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursPosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursPosted.Location = New System.Drawing.Point(488, 30)
            Me.LabelTrafficHours_HoursPosted.Name = "LabelTrafficHours_HoursPosted"
            Me.LabelTrafficHours_HoursPosted.Size = New System.Drawing.Size(71, 20)
            Me.LabelTrafficHours_HoursPosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursPosted.TabIndex = 11
            Me.LabelTrafficHours_HoursPosted.Text = "{0}"
            '
            'LabelTrafficHours_HoursRemaining
            '
            Me.LabelTrafficHours_HoursRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursRemaining.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursRemaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursRemaining.Location = New System.Drawing.Point(488, 56)
            Me.LabelTrafficHours_HoursRemaining.Name = "LabelTrafficHours_HoursRemaining"
            Me.LabelTrafficHours_HoursRemaining.Size = New System.Drawing.Size(71, 20)
            Me.LabelTrafficHours_HoursRemaining.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursRemaining.TabIndex = 13
            Me.LabelTrafficHours_HoursRemaining.Text = "{0}"
            '
            'LabelTrafficHours_HoursRemainingLbl
            '
            Me.LabelTrafficHours_HoursRemainingLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursRemainingLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursRemainingLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursRemainingLbl.Location = New System.Drawing.Point(378, 56)
            Me.LabelTrafficHours_HoursRemainingLbl.Name = "LabelTrafficHours_HoursRemainingLbl"
            Me.LabelTrafficHours_HoursRemainingLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelTrafficHours_HoursRemainingLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursRemainingLbl.TabIndex = 12
            Me.LabelTrafficHours_HoursRemainingLbl.Text = "Hours Remaining:"
            '
            'LabelTrafficHours_HoursPostedLbl
            '
            Me.LabelTrafficHours_HoursPostedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursPostedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursPostedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursPostedLbl.Location = New System.Drawing.Point(378, 30)
            Me.LabelTrafficHours_HoursPostedLbl.Name = "LabelTrafficHours_HoursPostedLbl"
            Me.LabelTrafficHours_HoursPostedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelTrafficHours_HoursPostedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursPostedLbl.TabIndex = 10
            Me.LabelTrafficHours_HoursPostedLbl.Text = "Hours Posted:"
            '
            'LabelTrafficHours_HoursAllowedLbl
            '
            Me.LabelTrafficHours_HoursAllowedLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_HoursAllowedLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_HoursAllowedLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_HoursAllowedLbl.Location = New System.Drawing.Point(378, 4)
            Me.LabelTrafficHours_HoursAllowedLbl.Name = "LabelTrafficHours_HoursAllowedLbl"
            Me.LabelTrafficHours_HoursAllowedLbl.Size = New System.Drawing.Size(104, 20)
            Me.LabelTrafficHours_HoursAllowedLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_HoursAllowedLbl.TabIndex = 8
            Me.LabelTrafficHours_HoursAllowedLbl.Text = "Hours Allowed:"
            '
            'DataGridViewTrafficHours_ActualHours
            '
            Me.DataGridViewTrafficHours_ActualHours.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTrafficHours_ActualHours.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTrafficHours_ActualHours.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTrafficHours_ActualHours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTrafficHours_ActualHours.AutoFilterLookupColumns = False
            Me.DataGridViewTrafficHours_ActualHours.AutoloadRepositoryDatasource = True
            Me.DataGridViewTrafficHours_ActualHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewTrafficHours_ActualHours.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTrafficHours_ActualHours.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTrafficHours_ActualHours.ItemDescription = "Item(s)"
            Me.DataGridViewTrafficHours_ActualHours.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewTrafficHours_ActualHours.MultiSelect = True
            Me.DataGridViewTrafficHours_ActualHours.Name = "DataGridViewTrafficHours_ActualHours"
            Me.DataGridViewTrafficHours_ActualHours.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTrafficHours_ActualHours.RunStandardValidation = True
            Me.DataGridViewTrafficHours_ActualHours.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTrafficHours_ActualHours.Size = New System.Drawing.Size(555, 129)
            Me.DataGridViewTrafficHours_ActualHours.TabIndex = 1
            Me.DataGridViewTrafficHours_ActualHours.UseEmbeddedNavigator = False
            Me.DataGridViewTrafficHours_ActualHours.ViewCaptionHeight = -1
            '
            'LabelTrafficHours_FunctionLbl
            '
            Me.LabelTrafficHours_FunctionLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_FunctionLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_FunctionLbl.Location = New System.Drawing.Point(4, 82)
            Me.LabelTrafficHours_FunctionLbl.Name = "LabelTrafficHours_FunctionLbl"
            Me.LabelTrafficHours_FunctionLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelTrafficHours_FunctionLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_FunctionLbl.TabIndex = 6
            Me.LabelTrafficHours_FunctionLbl.Text = "Function:"
            '
            'LabelTrafficHours_ComponentLbl
            '
            Me.LabelTrafficHours_ComponentLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_ComponentLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_ComponentLbl.Location = New System.Drawing.Point(4, 56)
            Me.LabelTrafficHours_ComponentLbl.Name = "LabelTrafficHours_ComponentLbl"
            Me.LabelTrafficHours_ComponentLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelTrafficHours_ComponentLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_ComponentLbl.TabIndex = 4
            Me.LabelTrafficHours_ComponentLbl.Text = "Component:"
            '
            'LabelTrafficHours_JobLbl
            '
            Me.LabelTrafficHours_JobLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_JobLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_JobLbl.Location = New System.Drawing.Point(4, 30)
            Me.LabelTrafficHours_JobLbl.Name = "LabelTrafficHours_JobLbl"
            Me.LabelTrafficHours_JobLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelTrafficHours_JobLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_JobLbl.TabIndex = 2
            Me.LabelTrafficHours_JobLbl.Text = "Job:"
            '
            'LabelTrafficHours_ClientLbl
            '
            Me.LabelTrafficHours_ClientLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_ClientLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_ClientLbl.Location = New System.Drawing.Point(4, 4)
            Me.LabelTrafficHours_ClientLbl.Name = "LabelTrafficHours_ClientLbl"
            Me.LabelTrafficHours_ClientLbl.Size = New System.Drawing.Size(75, 20)
            Me.LabelTrafficHours_ClientLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_ClientLbl.TabIndex = 0
            Me.LabelTrafficHours_ClientLbl.Text = "Client:"
            '
            'TabControlForm_Details
            '
            Me.TabControlForm_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Details.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Details.CanReorderTabs = True
            Me.TabControlForm_Details.Controls.Add(Me.TabControlPanelTrafficHoursTab_TrafficHours)
            Me.TabControlForm_Details.Controls.Add(Me.TabControlPanelQuoteVsActualTab_QuoteVsActual)
            Me.TabControlForm_Details.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Details.Name = "TabControlForm_Details"
            Me.TabControlForm_Details.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Details.SelectedTabIndex = 0
            Me.TabControlForm_Details.Size = New System.Drawing.Size(563, 454)
            Me.TabControlForm_Details.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Details.TabIndex = 0
            Me.TabControlForm_Details.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Details.Tabs.Add(Me.TabItemDetails_QuoteVsActualTab)
            Me.TabControlForm_Details.Tabs.Add(Me.TabItemDetails_TrafficHoursTab)
            Me.TabControlForm_Details.Text = "TabControl"
            '
            'TabControlPanelTrafficHoursTab_TrafficHours
            '
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.TableLayoutPanelTrafficHours_TrafficHours)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_ClientLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_JobLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_ComponentLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_Function)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_FunctionLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_Component)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_Job)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursAllowedLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_Client)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursPostedLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursAllowed)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursRemainingLbl)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursPosted)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Controls.Add(Me.LabelTrafficHours_HoursRemaining)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Name = "TabControlPanelTrafficHoursTab_TrafficHours"
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Size = New System.Drawing.Size(563, 427)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.Style.GradientAngle = 90
            Me.TabControlPanelTrafficHoursTab_TrafficHours.TabIndex = 2
            Me.TabControlPanelTrafficHoursTab_TrafficHours.TabItem = Me.TabItemDetails_TrafficHoursTab
            '
            'LabelTrafficHours_NoTrafficHours
            '
            Me.LabelTrafficHours_NoTrafficHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTrafficHours_NoTrafficHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrafficHours_NoTrafficHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrafficHours_NoTrafficHours.Location = New System.Drawing.Point(0, 30)
            Me.LabelTrafficHours_NoTrafficHours.Name = "LabelTrafficHours_NoTrafficHours"
            Me.LabelTrafficHours_NoTrafficHours.Size = New System.Drawing.Size(555, 20)
            Me.LabelTrafficHours_NoTrafficHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrafficHours_NoTrafficHours.TabIndex = 17
            Me.LabelTrafficHours_NoTrafficHours.Text = "No Traffic Hours Assigned!"
            '
            'TabItemDetails_TrafficHoursTab
            '
            Me.TabItemDetails_TrafficHoursTab.AttachedControl = Me.TabControlPanelTrafficHoursTab_TrafficHours
            Me.TabItemDetails_TrafficHoursTab.Name = "TabItemDetails_TrafficHoursTab"
            Me.TabItemDetails_TrafficHoursTab.Text = "Traffic Hours"
            '
            'TabControlPanelQuoteVsActualTab_QuoteVsActual
            '
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_ActualHours)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.CheckBoxQuoteVsActual_EmployeeOnly)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Function)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_ClientLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Revision)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_JobLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Quote)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_ComponentLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Estimate)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_EstimateLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Component)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_QuoteLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Job)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_RevisionLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_Client)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_FunctionLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursQuoted)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.DataGridViewQuoteVsActual_ActualHours)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursPosted)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursQuotedLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursRemaining)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursPostedLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountQuoted)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_HoursRemainingLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountPosted)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountQuotedLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountRemaining)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountPostedLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Controls.Add(Me.LabelQuoteVsActual_AmountRemainingLbl)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Name = "TabControlPanelQuoteVsActualTab_QuoteVsActual"
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Size = New System.Drawing.Size(563, 427)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.Style.GradientAngle = 90
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.TabIndex = 1
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.TabItem = Me.TabItemDetails_QuoteVsActualTab
            '
            'TabItemDetails_QuoteVsActualTab
            '
            Me.TabItemDetails_QuoteVsActualTab.AttachedControl = Me.TabControlPanelQuoteVsActualTab_QuoteVsActual
            Me.TabItemDetails_QuoteVsActualTab.Name = "TabItemDetails_QuoteVsActualTab"
            Me.TabItemDetails_QuoteVsActualTab.Text = "Quote Vs. Actual"
            '
            'TableLayoutPanelTrafficHours_TrafficHours
            '
            Me.TableLayoutPanelTrafficHours_TrafficHours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelTrafficHours_TrafficHours.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanelTrafficHours_TrafficHours.ColumnCount = 1
            Me.TableLayoutPanelTrafficHours_TrafficHours.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelTrafficHours_TrafficHours.Controls.Add(Me.PanelBottomRow_TrafficHours, 0, 1)
            Me.TableLayoutPanelTrafficHours_TrafficHours.Controls.Add(Me.PanelTopRow_TrafficHours, 0, 0)
            Me.TableLayoutPanelTrafficHours_TrafficHours.Location = New System.Drawing.Point(4, 108)
            Me.TableLayoutPanelTrafficHours_TrafficHours.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanelTrafficHours_TrafficHours.Name = "TableLayoutPanelTrafficHours_TrafficHours"
            Me.TableLayoutPanelTrafficHours_TrafficHours.RowCount = 2
            Me.TableLayoutPanelTrafficHours_TrafficHours.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelTrafficHours_TrafficHours.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelTrafficHours_TrafficHours.Size = New System.Drawing.Size(555, 315)
            Me.TableLayoutPanelTrafficHours_TrafficHours.TabIndex = 14
            '
            'PanelTopRow_TrafficHours
            '
            Me.PanelTopRow_TrafficHours.Controls.Add(Me.LabelTrafficHours_ActualHours)
            Me.PanelTopRow_TrafficHours.Controls.Add(Me.DataGridViewTrafficHours_ActualHours)
            Me.PanelTopRow_TrafficHours.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTopRow_TrafficHours.Location = New System.Drawing.Point(0, 0)
            Me.PanelTopRow_TrafficHours.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTopRow_TrafficHours.Name = "PanelTopRow_TrafficHours"
            Me.PanelTopRow_TrafficHours.Size = New System.Drawing.Size(555, 157)
            Me.PanelTopRow_TrafficHours.TabIndex = 0
            '
            'PanelBottomRow_TrafficHours
            '
            Me.PanelBottomRow_TrafficHours.Controls.Add(Me.LabelTrafficHours_TrafficHours)
            Me.PanelBottomRow_TrafficHours.Controls.Add(Me.DataGridViewTrafficHours_TrafficHours)
            Me.PanelBottomRow_TrafficHours.Controls.Add(Me.LabelTrafficHours_NoTrafficHours)
            Me.PanelBottomRow_TrafficHours.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomRow_TrafficHours.Location = New System.Drawing.Point(0, 157)
            Me.PanelBottomRow_TrafficHours.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelBottomRow_TrafficHours.Name = "PanelBottomRow_TrafficHours"
            Me.PanelBottomRow_TrafficHours.Size = New System.Drawing.Size(555, 158)
            Me.PanelBottomRow_TrafficHours.TabIndex = 1
            '
            'TimesheetDetailsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(587, 504)
            Me.Controls.Add(Me.TabControlForm_Details)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TimesheetDetailsDialog"
            Me.Text = "Timesheet Details"
            CType(Me.TabControlForm_Details, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Details.ResumeLayout(False)
            Me.TabControlPanelTrafficHoursTab_TrafficHours.ResumeLayout(False)
            Me.TabControlPanelQuoteVsActualTab_QuoteVsActual.ResumeLayout(False)
            Me.TableLayoutPanelTrafficHours_TrafficHours.ResumeLayout(False)
            Me.PanelTopRow_TrafficHours.ResumeLayout(False)
            Me.PanelBottomRow_TrafficHours.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CheckBoxQuoteVsActual_EmployeeOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewQuoteVsActual_ActualHours As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewTrafficHours_TrafficHours As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewTrafficHours_ActualHours As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents LabelQuoteVsActual_ActualHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Revision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Quote As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Estimate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursQuoted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursPosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursRemaining As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountQuoted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountPosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountRemaining As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountRemainingLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountPostedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_AmountQuotedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursRemainingLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursPostedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_HoursQuotedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_FunctionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_RevisionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_QuoteLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_EstimateLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_ComponentLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_JobLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelQuoteVsActual_ClientLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursAllowed As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_TrafficHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_ActualHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursPosted As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursRemaining As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursRemainingLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursPostedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_HoursAllowedLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_FunctionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_ComponentLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_JobLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelTrafficHours_ClientLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TabControlForm_Details As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Private WithEvents TabControlPanelQuoteVsActualTab_QuoteVsActual As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemDetails_QuoteVsActualTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelTrafficHoursTab_TrafficHours As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemDetails_TrafficHoursTab As DevComponents.DotNetBar.TabItem
        Private WithEvents LabelTrafficHours_NoTrafficHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelTrafficHours_TrafficHours As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelBottomRow_TrafficHours As System.Windows.Forms.Panel
        Friend WithEvents PanelTopRow_TrafficHours As System.Windows.Forms.Panel
    End Class

End Namespace