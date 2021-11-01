Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TaskTemplateDetailsSubReport
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
            Me.Checkbox_Milestone = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.Label_EstimateFunction = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Employee = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushHoursAllowed = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushDaysAllowed = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_HoursAllowed = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DaysToComplete = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProcessOrderNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Task = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Phase = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Label_PhaseLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.Label_FunctionLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_EmployeeLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_MilestoneLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushToComplete = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Hours = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushDaysLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_HoursAllowedLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DaysToCompleteLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProcOrderLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TaskLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Checkbox_Milestone, Me.Label_EstimateFunction, Me.Label_Employee, Me.Label_RushHoursAllowed, Me.Label_RushDaysAllowed, Me.Label_HoursAllowed, Me.Label_DaysToComplete, Me.Label_ProcessOrderNumber, Me.Label_Task, Me.Label_Phase})
            Me.Detail.HeightF = 23.00002!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Checkbox_Milestone
            '
            Me.Checkbox_Milestone.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "IsMilestone")})
            Me.Checkbox_Milestone.LocationFloat = New DevExpress.Utils.PointFloat(511.3332!, 0.0!)
            Me.Checkbox_Milestone.Name = "Checkbox_Milestone"
            Me.Checkbox_Milestone.SizeF = New System.Drawing.SizeF(30.25009!, 18.0!)
            '
            'Label_EstimateFunction
            '
            Me.Label_EstimateFunction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DefaultFunctionCode")})
            Me.Label_EstimateFunction.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_EstimateFunction.LocationFloat = New DevExpress.Utils.PointFloat(612.4583!, 0.0!)
            Me.Label_EstimateFunction.Name = "Label_EstimateFunction"
            Me.Label_EstimateFunction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_EstimateFunction.SizeF = New System.Drawing.SizeF(62.54163!, 18.0!)
            Me.Label_EstimateFunction.StylePriority.UseFont = False
            Me.Label_EstimateFunction.Text = "Label_EstimateFunction"
            '
            'Label_Employee
            '
            Me.Label_Employee.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DefaultEmployeeCode")})
            Me.Label_Employee.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Employee.LocationFloat = New DevExpress.Utils.PointFloat(541.5833!, 0.0!)
            Me.Label_Employee.Name = "Label_Employee"
            Me.Label_Employee.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Employee.SizeF = New System.Drawing.SizeF(70.87506!, 18.0!)
            Me.Label_Employee.StylePriority.UseFont = False
            Me.Label_Employee.Text = "Label_Employee"
            '
            'Label_RushHoursAllowed
            '
            Me.Label_RushHoursAllowed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RushHoursToComplete")})
            Me.Label_RushHoursAllowed.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_RushHoursAllowed.LocationFloat = New DevExpress.Utils.PointFloat(471.7084!, 0.0!)
            Me.Label_RushHoursAllowed.Name = "Label_RushHoursAllowed"
            Me.Label_RushHoursAllowed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_RushHoursAllowed.SizeF = New System.Drawing.SizeF(39.62488!, 18.0!)
            Me.Label_RushHoursAllowed.StylePriority.UseFont = False
            Me.Label_RushHoursAllowed.Text = "Label_RushHoursAllowed"
            '
            'Label_RushDaysAllowed
            '
            Me.Label_RushDaysAllowed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RushDaysToComplete")})
            Me.Label_RushDaysAllowed.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_RushDaysAllowed.LocationFloat = New DevExpress.Utils.PointFloat(432.0834!, 0.0!)
            Me.Label_RushDaysAllowed.Name = "Label_RushDaysAllowed"
            Me.Label_RushDaysAllowed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_RushDaysAllowed.SizeF = New System.Drawing.SizeF(39.62488!, 18.0!)
            Me.Label_RushDaysAllowed.StylePriority.UseFont = False
            Me.Label_RushDaysAllowed.Text = "Label_RushDaysAllowed"
            '
            'Label_HoursAllowed
            '
            Me.Label_HoursAllowed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAllowed")})
            Me.Label_HoursAllowed.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_HoursAllowed.LocationFloat = New DevExpress.Utils.PointFloat(369.5417!, 0.0!)
            Me.Label_HoursAllowed.Name = "Label_HoursAllowed"
            Me.Label_HoursAllowed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_HoursAllowed.SizeF = New System.Drawing.SizeF(61.49991!, 18.0!)
            Me.Label_HoursAllowed.StylePriority.UseFont = False
            Me.Label_HoursAllowed.Text = "Label_HoursAllowed"
            '
            'Label_DaysToComplete
            '
            Me.Label_DaysToComplete.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DaysToComplete")})
            Me.Label_DaysToComplete.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_DaysToComplete.LocationFloat = New DevExpress.Utils.PointFloat(328.8752!, 0.0!)
            Me.Label_DaysToComplete.Name = "Label_DaysToComplete"
            Me.Label_DaysToComplete.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DaysToComplete.SizeF = New System.Drawing.SizeF(40.66656!, 18.0!)
            Me.Label_DaysToComplete.StylePriority.UseFont = False
            Me.Label_DaysToComplete.Text = "Label_DaysToComplete"
            '
            'Label_ProcessOrderNumber
            '
            Me.Label_ProcessOrderNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProcessOrderNumber")})
            Me.Label_ProcessOrderNumber.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ProcessOrderNumber.LocationFloat = New DevExpress.Utils.PointFloat(286.1669!, 0.0!)
            Me.Label_ProcessOrderNumber.Name = "Label_ProcessOrderNumber"
            Me.Label_ProcessOrderNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ProcessOrderNumber.SizeF = New System.Drawing.SizeF(41.70827!, 18.0!)
            Me.Label_ProcessOrderNumber.StylePriority.UseFont = False
            Me.Label_ProcessOrderNumber.Text = "Label_ProcessOrderNumber"
            '
            'Label_Task
            '
            Me.Label_Task.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Task.LocationFloat = New DevExpress.Utils.PointFloat(94.83337!, 0.0!)
            Me.Label_Task.Name = "Label_Task"
            Me.Label_Task.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Task.SizeF = New System.Drawing.SizeF(191.3335!, 18.0!)
            Me.Label_Task.StylePriority.UseFont = False
            '
            'Label_Phase
            '
            Me.Label_Phase.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PhaseDescription")})
            Me.Label_Phase.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Phase.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Label_Phase.Name = "Label_Phase"
            Me.Label_Phase.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Phase.SizeF = New System.Drawing.SizeF(94.83334!, 18.0!)
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
            Me.Label_PhaseLbl.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.20835!)
            Me.Label_PhaseLbl.Name = "Label_PhaseLbl"
            Me.Label_PhaseLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_PhaseLbl.SizeF = New System.Drawing.SizeF(94.83334!, 27.99999!)
            Me.Label_PhaseLbl.StylePriority.UseBorders = False
            Me.Label_PhaseLbl.StylePriority.UseFont = False
            Me.Label_PhaseLbl.StylePriority.UseForeColor = False
            Me.Label_PhaseLbl.StylePriority.UseTextAlignment = False
            Me.Label_PhaseLbl.Text = "Phase ID"
            Me.Label_PhaseLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_FunctionLbl, Me.Label_EmployeeLbl, Me.Label_MilestoneLbl, Me.Label_RushToComplete, Me.Label_Hours, Me.Label_RushDaysLbl, Me.Label_HoursAllowedLbl, Me.Label_DaysToCompleteLbl, Me.Label_ProcOrderLbl, Me.Label_TaskLbl, Me.Label_PhaseLbl})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 56.62498!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'Label_FunctionLbl
            '
            Me.Label_FunctionLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_FunctionLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_FunctionLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_FunctionLbl.LocationFloat = New DevExpress.Utils.PointFloat(612.4583!, 0.00001589457!)
            Me.Label_FunctionLbl.Name = "Label_FunctionLbl"
            Me.Label_FunctionLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FunctionLbl.SizeF = New System.Drawing.SizeF(62.54163!, 53.20834!)
            Me.Label_FunctionLbl.StylePriority.UseBorders = False
            Me.Label_FunctionLbl.StylePriority.UseFont = False
            Me.Label_FunctionLbl.StylePriority.UseForeColor = False
            Me.Label_FunctionLbl.StylePriority.UseTextAlignment = False
            Me.Label_FunctionLbl.Text = "Estimate Function"
            Me.Label_FunctionLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_EmployeeLbl
            '
            Me.Label_EmployeeLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_EmployeeLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_EmployeeLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_EmployeeLbl.LocationFloat = New DevExpress.Utils.PointFloat(541.5833!, 25.20835!)
            Me.Label_EmployeeLbl.Name = "Label_EmployeeLbl"
            Me.Label_EmployeeLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_EmployeeLbl.SizeF = New System.Drawing.SizeF(70.87506!, 27.99999!)
            Me.Label_EmployeeLbl.StylePriority.UseBorders = False
            Me.Label_EmployeeLbl.StylePriority.UseFont = False
            Me.Label_EmployeeLbl.StylePriority.UseForeColor = False
            Me.Label_EmployeeLbl.StylePriority.UseTextAlignment = False
            Me.Label_EmployeeLbl.Text = "Employee"
            Me.Label_EmployeeLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_MilestoneLbl
            '
            Me.Label_MilestoneLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_MilestoneLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_MilestoneLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_MilestoneLbl.LocationFloat = New DevExpress.Utils.PointFloat(511.3332!, 25.20835!)
            Me.Label_MilestoneLbl.Name = "Label_MilestoneLbl"
            Me.Label_MilestoneLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_MilestoneLbl.SizeF = New System.Drawing.SizeF(30.24994!, 27.99999!)
            Me.Label_MilestoneLbl.StylePriority.UseBorders = False
            Me.Label_MilestoneLbl.StylePriority.UseFont = False
            Me.Label_MilestoneLbl.StylePriority.UseForeColor = False
            Me.Label_MilestoneLbl.StylePriority.UseTextAlignment = False
            Me.Label_MilestoneLbl.Text = "M/S"
            Me.Label_MilestoneLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_RushToComplete
            '
            Me.Label_RushToComplete.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_RushToComplete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_RushToComplete.ForeColor = System.Drawing.Color.Black
            Me.Label_RushToComplete.LocationFloat = New DevExpress.Utils.PointFloat(432.0834!, 0.0!)
            Me.Label_RushToComplete.Name = "Label_RushToComplete"
            Me.Label_RushToComplete.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_RushToComplete.SizeF = New System.Drawing.SizeF(79.24991!, 35.66667!)
            Me.Label_RushToComplete.StylePriority.UseBorders = False
            Me.Label_RushToComplete.StylePriority.UseFont = False
            Me.Label_RushToComplete.StylePriority.UseForeColor = False
            Me.Label_RushToComplete.StylePriority.UseTextAlignment = False
            Me.Label_RushToComplete.Text = "Rush To Complete"
            Me.Label_RushToComplete.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
            '
            'Label_Hours
            '
            Me.Label_Hours.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_Hours.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Hours.ForeColor = System.Drawing.Color.Black
            Me.Label_Hours.LocationFloat = New DevExpress.Utils.PointFloat(471.7084!, 36.66668!)
            Me.Label_Hours.Name = "Label_Hours"
            Me.Label_Hours.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Hours.SizeF = New System.Drawing.SizeF(39.62491!, 16.54166!)
            Me.Label_Hours.StylePriority.UseBorders = False
            Me.Label_Hours.StylePriority.UseFont = False
            Me.Label_Hours.StylePriority.UseForeColor = False
            Me.Label_Hours.StylePriority.UseTextAlignment = False
            Me.Label_Hours.Text = "Hours"
            Me.Label_Hours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_RushDaysLbl
            '
            Me.Label_RushDaysLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_RushDaysLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_RushDaysLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_RushDaysLbl.LocationFloat = New DevExpress.Utils.PointFloat(432.0834!, 36.66668!)
            Me.Label_RushDaysLbl.Name = "Label_RushDaysLbl"
            Me.Label_RushDaysLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_RushDaysLbl.SizeF = New System.Drawing.SizeF(39.62491!, 16.54166!)
            Me.Label_RushDaysLbl.StylePriority.UseBorders = False
            Me.Label_RushDaysLbl.StylePriority.UseFont = False
            Me.Label_RushDaysLbl.StylePriority.UseForeColor = False
            Me.Label_RushDaysLbl.StylePriority.UseTextAlignment = False
            Me.Label_RushDaysLbl.Text = "Days"
            Me.Label_RushDaysLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_HoursAllowedLbl
            '
            Me.Label_HoursAllowedLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_HoursAllowedLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_HoursAllowedLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_HoursAllowedLbl.LocationFloat = New DevExpress.Utils.PointFloat(369.5417!, 0.0!)
            Me.Label_HoursAllowedLbl.Name = "Label_HoursAllowedLbl"
            Me.Label_HoursAllowedLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_HoursAllowedLbl.SizeF = New System.Drawing.SizeF(62.5416!, 53.25!)
            Me.Label_HoursAllowedLbl.StylePriority.UseBorders = False
            Me.Label_HoursAllowedLbl.StylePriority.UseFont = False
            Me.Label_HoursAllowedLbl.StylePriority.UseForeColor = False
            Me.Label_HoursAllowedLbl.StylePriority.UseTextAlignment = False
            Me.Label_HoursAllowedLbl.Text = "Hours Allowed"
            Me.Label_HoursAllowedLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_DaysToCompleteLbl
            '
            Me.Label_DaysToCompleteLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_DaysToCompleteLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DaysToCompleteLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_DaysToCompleteLbl.LocationFloat = New DevExpress.Utils.PointFloat(328.8752!, 0.00001589457!)
            Me.Label_DaysToCompleteLbl.Name = "Label_DaysToCompleteLbl"
            Me.Label_DaysToCompleteLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DaysToCompleteLbl.SizeF = New System.Drawing.SizeF(40.66656!, 53.20834!)
            Me.Label_DaysToCompleteLbl.StylePriority.UseBorders = False
            Me.Label_DaysToCompleteLbl.StylePriority.UseFont = False
            Me.Label_DaysToCompleteLbl.StylePriority.UseForeColor = False
            Me.Label_DaysToCompleteLbl.StylePriority.UseTextAlignment = False
            Me.Label_DaysToCompleteLbl.Text = "Days To Comp"
            Me.Label_DaysToCompleteLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_ProcOrderLbl
            '
            Me.Label_ProcOrderLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_ProcOrderLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ProcOrderLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_ProcOrderLbl.LocationFloat = New DevExpress.Utils.PointFloat(286.1669!, 0.00003178914!)
            Me.Label_ProcOrderLbl.Name = "Label_ProcOrderLbl"
            Me.Label_ProcOrderLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ProcOrderLbl.SizeF = New System.Drawing.SizeF(42.70828!, 53.29167!)
            Me.Label_ProcOrderLbl.StylePriority.UseBorders = False
            Me.Label_ProcOrderLbl.StylePriority.UseFont = False
            Me.Label_ProcOrderLbl.StylePriority.UseForeColor = False
            Me.Label_ProcOrderLbl.StylePriority.UseTextAlignment = False
            Me.Label_ProcOrderLbl.Text = "Proc Order"
            Me.Label_ProcOrderLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Label_TaskLbl
            '
            Me.Label_TaskLbl.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_TaskLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TaskLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_TaskLbl.LocationFloat = New DevExpress.Utils.PointFloat(94.83337!, 25.20835!)
            Me.Label_TaskLbl.Name = "Label_TaskLbl"
            Me.Label_TaskLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_TaskLbl.SizeF = New System.Drawing.SizeF(191.3335!, 27.99999!)
            Me.Label_TaskLbl.StylePriority.UseBorders = False
            Me.Label_TaskLbl.StylePriority.UseFont = False
            Me.Label_TaskLbl.StylePriority.UseForeColor = False
            Me.Label_TaskLbl.StylePriority.UseTextAlignment = False
            Me.Label_TaskLbl.Text = "Task"
            Me.Label_TaskLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Views.TaskTemplateDetail)
            '
            'TaskTemplateDetailsSubReport
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
        Friend WithEvents Label_FunctionLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_EmployeeLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_MilestoneLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_RushToComplete As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Hours As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_RushDaysLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_HoursAllowedLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DaysToCompleteLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ProcOrderLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_TaskLbl As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DaysToComplete As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ProcessOrderNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Task As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Checkbox_Milestone As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents Label_EstimateFunction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Employee As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_RushHoursAllowed As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_RushDaysAllowed As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_HoursAllowed As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace