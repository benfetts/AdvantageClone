<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalendarSyncDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalendarSyncDialog))
        Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonForm_Sync = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.CheckBoxForm_Appointments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxForm_Tasks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.GroupBoxForm_ItemsToSync = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        CType(Me.GroupBoxForm_ItemsToSync, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxForm_ItemsToSync.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelForm_Employee
        '
        Me.LabelForm_Employee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelForm_Employee.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.LabelForm_Employee.TextAlignment = Drawing.StringAlignment.Near
        Me.LabelForm_Employee.TextLineAlignment = Drawing.StringAlignment.Center
        Me.LabelForm_Employee.AutoSize = False
        Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 13)
        Me.LabelForm_Employee.Name = "LabelForm_Employee"
        Me.LabelForm_Employee.Size = New System.Drawing.Size(308, 20)
        Me.LabelForm_Employee.TabIndex = 0
        Me.LabelForm_Employee.Text = "Employee:"
        '
        'ButtonForm_Sync
        '
        Me.ButtonForm_Sync.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Sync.Location = New System.Drawing.Point(164, 121)
        Me.ButtonForm_Sync.Name = "ButtonForm_Sync"
        Me.ButtonForm_Sync.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Sync.TabIndex = 6
        Me.ButtonForm_Sync.Text = "Sync"
        '
        'ButtonForm_Close
        '
        Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Close.Location = New System.Drawing.Point(245, 121)
        Me.ButtonForm_Close.Name = "ButtonForm_Close"
        Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Close.TabIndex = 7
        Me.ButtonForm_Close.Text = "Close"
        '
        'CheckBoxForm_Appointments
        '
        Me.CheckBoxForm_Appointments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxForm_Appointments.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxForm_Appointments.Name = "CheckBoxForm_Appointments"
        Me.CheckBoxForm_Appointments.AutoSize = False
        Me.CheckBoxForm_Appointments.Text = "Appointments"
        Me.CheckBoxForm_Appointments.Size = New System.Drawing.Size(298, 20)
        Me.CheckBoxForm_Appointments.TabIndex = 0
        '
        'CheckBoxForm_Tasks
        '
        Me.CheckBoxForm_Tasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxForm_Tasks.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxForm_Tasks.Name = "CheckBoxForm_Tasks"
        Me.CheckBoxForm_Tasks.AutoSize = False
        Me.CheckBoxForm_Tasks.Text = "Tasks"
        Me.CheckBoxForm_Tasks.Size = New System.Drawing.Size(298, 20)
        Me.CheckBoxForm_Tasks.TabIndex = 2
        '
        'GroupBoxForm_ItemsToSync
        '
        Me.GroupBoxForm_ItemsToSync.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxForm_ItemsToSync.Controls.Add(Me.CheckBoxForm_Appointments)
        Me.GroupBoxForm_ItemsToSync.Controls.Add(Me.CheckBoxForm_Tasks)
        Me.GroupBoxForm_ItemsToSync.Location = New System.Drawing.Point(12, 39)
        Me.GroupBoxForm_ItemsToSync.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupBoxForm_ItemsToSync.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupBoxForm_ItemsToSync.Name = "GroupBoxForm_ItemsToSync"
        Me.GroupBoxForm_ItemsToSync.Size = New System.Drawing.Size(308, 76)
        Me.GroupBoxForm_ItemsToSync.TabIndex = 1
        Me.GroupBoxForm_ItemsToSync.Text = "Items To Sync"
        '
        'CalendarSyncDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 153)
        Me.Controls.Add(Me.GroupBoxForm_ItemsToSync)
        Me.Controls.Add(Me.ButtonForm_Close)
        Me.Controls.Add(Me.ButtonForm_Sync)
        Me.Controls.Add(Me.LabelForm_Employee)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CalendarSyncDialog"
        Me.Text = "Calendar Sync"
        CType(Me.GroupBoxForm_ItemsToSync, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxForm_ItemsToSync.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonForm_Sync As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents CheckBoxForm_Appointments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxForm_Tasks As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents GroupBoxForm_ItemsToSync As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
End Class
