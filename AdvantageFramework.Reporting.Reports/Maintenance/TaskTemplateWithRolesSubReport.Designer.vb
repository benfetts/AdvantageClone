Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TaskTemplateWithRolesSubReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Label_Task = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Roles = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TaskCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Phase = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Label_PhaseLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.Label_TaskLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RolesLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TaskCodeLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_Task, Me.Label_Roles, Me.Label_TaskCode, Me.Label_Phase})
            Me.Detail.HeightF = 23.00002!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Task
            '
            Me.Label_Task.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaskDescription")})
            Me.Label_Task.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Task.LocationFloat = New DevExpress.Utils.PointFloat(230.9586!, 2.0!)
            Me.Label_Task.Name = "Label_Task"
            Me.Label_Task.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Task.SizeF = New System.Drawing.SizeF(241.6667!, 18.0!)
            Me.Label_Task.StylePriority.UseFont = False
            Me.Label_Task.Text = "Label_Task"
            '
            'Label_Roles
            '
            Me.Label_Roles.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Roles")})
            Me.Label_Roles.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Roles.LocationFloat = New DevExpress.Utils.PointFloat(472.6252!, 2.0!)
            Me.Label_Roles.Name = "Label_Roles"
            Me.Label_Roles.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Roles.SizeF = New System.Drawing.SizeF(202.3748!, 18.0!)
            Me.Label_Roles.StylePriority.UseFont = False
            Me.Label_Roles.Text = "Label_Roles"
            '
            'Label_TaskCode
            '
            Me.Label_TaskCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaskCode")})
            Me.Label_TaskCode.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_TaskCode.LocationFloat = New DevExpress.Utils.PointFloat(150.0417!, 2.0!)
            Me.Label_TaskCode.Name = "Label_TaskCode"
            Me.Label_TaskCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_TaskCode.SizeF = New System.Drawing.SizeF(80.91681!, 18.0!)
            Me.Label_TaskCode.StylePriority.UseFont = False
            Me.Label_TaskCode.Text = "Label_TaskCode"
            '
            'Label_Phase
            '
            Me.Label_Phase.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PhaseDescription")})
            Me.Label_Phase.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Phase.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
            Me.Label_Phase.Name = "Label_Phase"
            Me.Label_Phase.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Phase.SizeF = New System.Drawing.SizeF(150.0417!, 18.0!)
            Me.Label_Phase.StylePriority.UseFont = False
            Me.Label_Phase.Text = "Label_Phase"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 10.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PhaseLbl
            '
            Me.Label_PhaseLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_PhaseLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PhaseLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_PhaseLbl.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 1.208349!)
            Me.Label_PhaseLbl.Name = "Label_PhaseLbl"
            Me.Label_PhaseLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PhaseLbl.SizeF = New System.Drawing.SizeF(150.0417!, 27.99999!)
            Me.Label_PhaseLbl.StylePriority.UseBorders = False
            Me.Label_PhaseLbl.StylePriority.UseFont = False
            Me.Label_PhaseLbl.StylePriority.UseForeColor = False
            Me.Label_PhaseLbl.StylePriority.UseTextAlignment = False
            Me.Label_PhaseLbl.Text = "Phase"
            Me.Label_PhaseLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_TaskLbl, Me.Label_RolesLbl, Me.Label_TaskCodeLbl, Me.Label_PhaseLbl})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 29.20834!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'Label_TaskLbl
            '
            Me.Label_TaskLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_TaskLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TaskLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_TaskLbl.LocationFloat = New DevExpress.Utils.PointFloat(230.9586!, 1.208345!)
            Me.Label_TaskLbl.Name = "Label_TaskLbl"
            Me.Label_TaskLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_TaskLbl.SizeF = New System.Drawing.SizeF(241.6667!, 27.99999!)
            Me.Label_TaskLbl.StylePriority.UseBorders = False
            Me.Label_TaskLbl.StylePriority.UseFont = False
            Me.Label_TaskLbl.StylePriority.UseForeColor = False
            Me.Label_TaskLbl.StylePriority.UseTextAlignment = False
            Me.Label_TaskLbl.Text = "Task Description"
            Me.Label_TaskLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_RolesLbl
            '
            Me.Label_RolesLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_RolesLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_RolesLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_RolesLbl.LocationFloat = New DevExpress.Utils.PointFloat(472.6252!, 1.208349!)
            Me.Label_RolesLbl.Name = "Label_RolesLbl"
            Me.Label_RolesLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_RolesLbl.SizeF = New System.Drawing.SizeF(202.3748!, 27.99999!)
            Me.Label_RolesLbl.StylePriority.UseBorders = False
            Me.Label_RolesLbl.StylePriority.UseFont = False
            Me.Label_RolesLbl.StylePriority.UseForeColor = False
            Me.Label_RolesLbl.StylePriority.UseTextAlignment = False
            Me.Label_RolesLbl.Text = "Roles"
            Me.Label_RolesLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_TaskCodeLbl
            '
            Me.Label_TaskCodeLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_TaskCodeLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TaskCodeLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_TaskCodeLbl.LocationFloat = New DevExpress.Utils.PointFloat(150.0417!, 1.208345!)
            Me.Label_TaskCodeLbl.Name = "Label_TaskCodeLbl"
            Me.Label_TaskCodeLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_TaskCodeLbl.SizeF = New System.Drawing.SizeF(80.91681!, 27.99999!)
            Me.Label_TaskCodeLbl.StylePriority.UseBorders = False
            Me.Label_TaskCodeLbl.StylePriority.UseFont = False
            Me.Label_TaskCodeLbl.StylePriority.UseForeColor = False
            Me.Label_TaskCodeLbl.StylePriority.UseTextAlignment = False
            Me.Label_TaskCodeLbl.Text = "Task Code"
            Me.Label_TaskCodeLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.TaskTemplateWithRoles)
            '
            'TaskTemplateWithRolesSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 175, 0, 10)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Label_Phase As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_PhaseLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Label_RolesLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_TaskCodeLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_TaskCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Roles As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_TaskLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Task As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace