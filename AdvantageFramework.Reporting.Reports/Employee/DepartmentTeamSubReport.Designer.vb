Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class DepartmentTeamSubReport
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
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelIsBlockedData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelModuleData = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrLabelDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelDefault = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DefaultDepartment = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabelIsBlockedData, Me.XrLabelModuleData})
            Me.Detail.HeightF = 19.87502!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DefaultDepartment")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(305.4166!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(45.58322!, 18.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.Text = "XrLabel1"
            '
            'XrLabelIsBlockedData
            '
            Me.XrLabelIsBlockedData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeamCode")})
            Me.XrLabelIsBlockedData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelIsBlockedData.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabelIsBlockedData.Name = "XrLabelIsBlockedData"
            Me.XrLabelIsBlockedData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelIsBlockedData.SizeF = New System.Drawing.SizeF(59.41667!, 18.0!)
            Me.XrLabelIsBlockedData.StylePriority.UseFont = False
            Me.XrLabelIsBlockedData.Text = "XrLabelIsBlockedData"
            '
            'XrLabelModuleData
            '
            Me.XrLabelModuleData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentName")})
            Me.XrLabelModuleData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelModuleData.LocationFloat = New DevExpress.Utils.PointFloat(59.41671!, 0.0!)
            Me.XrLabelModuleData.Name = "XrLabelModuleData"
            Me.XrLabelModuleData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelModuleData.SizeF = New System.Drawing.SizeF(245.9999!, 18.0!)
            Me.XrLabelModuleData.StylePriority.UseFont = False
            Me.XrLabelModuleData.Text = "XrLabelModuleData"
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
            Me.BottomMargin.HeightF = 2.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelDescription
            '
            Me.XrLabelDescription.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelDescription.ForeColor = System.Drawing.Color.Black
            Me.XrLabelDescription.LocationFloat = New DevExpress.Utils.PointFloat(59.41671!, 0.0!)
            Me.XrLabelDescription.Name = "XrLabelDescription"
            Me.XrLabelDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDescription.SizeF = New System.Drawing.SizeF(245.9999!, 17.58332!)
            Me.XrLabelDescription.StylePriority.UseBorders = False
            Me.XrLabelDescription.StylePriority.UseFont = False
            Me.XrLabelDescription.StylePriority.UseForeColor = False
            Me.XrLabelDescription.StylePriority.UseTextAlignment = False
            Me.XrLabelDescription.Text = "Description"
            Me.XrLabelDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCode
            '
            Me.XrLabelCode.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCode.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabelCode.Name = "XrLabelCode"
            Me.XrLabelCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCode.SizeF = New System.Drawing.SizeF(59.41667!, 17.58332!)
            Me.XrLabelCode.StylePriority.UseBorders = False
            Me.XrLabelCode.StylePriority.UseFont = False
            Me.XrLabelCode.StylePriority.UseForeColor = False
            Me.XrLabelCode.StylePriority.UseTextAlignment = False
            Me.XrLabelCode.Text = "Code"
            Me.XrLabelCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelDefault, Me.XrLabelCode, Me.XrLabelDescription})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 17.58332!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelDefault
            '
            Me.XrLabelDefault.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelDefault.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelDefault.ForeColor = System.Drawing.Color.Black
            Me.XrLabelDefault.LocationFloat = New DevExpress.Utils.PointFloat(305.4166!, 0.0!)
            Me.XrLabelDefault.Name = "XrLabelDefault"
            Me.XrLabelDefault.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDefault.SizeF = New System.Drawing.SizeF(45.58331!, 17.58332!)
            Me.XrLabelDefault.StylePriority.UseBorders = False
            Me.XrLabelDefault.StylePriority.UseFont = False
            Me.XrLabelDefault.StylePriority.UseForeColor = False
            Me.XrLabelDefault.StylePriority.UseTextAlignment = False
            Me.XrLabelDefault.Text = "Default"
            Me.XrLabelDefault.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.EmployeeDepartment)
            '
            'DefaultDepartment
            '
            Me.DefaultDepartment.Expression = "Iif([DepartmentTeamCode] = [Employee.DepartmentTeamCode], 'Y' , '')"
            Me.DefaultDepartment.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DefaultDepartment.Name = "DefaultDepartment"
            '
            'DepartmentTeamSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.DefaultDepartment})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 499, 0, 2)
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
        Friend WithEvents XrLabelIsBlockedData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelModuleData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelDefault As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DefaultDepartment As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace