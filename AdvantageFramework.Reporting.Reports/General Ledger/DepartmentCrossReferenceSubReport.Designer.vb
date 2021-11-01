Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class DepartmentCrossReferenceSubReport
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
            Me.Table_Department = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.Table_DepartmentHeader = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCell_GLDepartment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCell_DepartmentCode = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCell_DepartmentName = New DevExpress.XtraReports.UI.XRTableCell()
            Me.Label_Department = New DevExpress.XtraReports.UI.XRLabel()
            Me.DefaultDepartment = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            CType(Me.Table_Department, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Table_DepartmentHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Table_Department})
            Me.Detail.HeightF = 29.16667!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Table_Department
            '
            Me.Table_Department.EvenStyleName = "XrControlStyle1"
            Me.Table_Department.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Table_Department.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Table_Department.Name = "Table_Department"
            Me.Table_Department.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
            Me.Table_Department.SizeF = New System.Drawing.SizeF(489.0!, 25.0!)
            Me.Table_Department.StylePriority.UseFont = False
            Me.Table_Department.StylePriority.UseTextAlignment = False
            Me.Table_Department.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrTableRow2
            '
            Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
            Me.XrTableRow2.Name = "XrTableRow2"
            Me.XrTableRow2.Weight = 1.0R
            '
            'XrTableCell4
            '
            Me.XrTableCell4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.XrTableCell4.Name = "XrTableCell4"
            Me.XrTableCell4.Text = "XrTableCell4"
            Me.XrTableCell4.Weight = 0.66198973860477373R
            '
            'XrTableCell5
            '
            Me.XrTableCell5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeamCode")})
            Me.XrTableCell5.Name = "XrTableCell5"
            Me.XrTableCell5.Text = "XrTableCell5"
            Me.XrTableCell5.Weight = 0.77040811550397814R
            '
            'XrTableCell6
            '
            Me.XrTableCell6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeam.Description")})
            Me.XrTableCell6.Name = "XrTableCell6"
            Me.XrTableCell6.Text = "XrTableCell6"
            Me.XrTableCell6.Weight = 1.5676021458912481R
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
            Me.BottomMargin.HeightF = 0.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Table_DepartmentHeader, Me.Label_Department})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 49.5!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'Table_DepartmentHeader
            '
            Me.Table_DepartmentHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 24.5!)
            Me.Table_DepartmentHeader.Name = "Table_DepartmentHeader"
            Me.Table_DepartmentHeader.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
            Me.Table_DepartmentHeader.SizeF = New System.Drawing.SizeF(489.0!, 25.0!)
            '
            'XrTableRow4
            '
            Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCell_GLDepartment, Me.TableCell_DepartmentCode, Me.TableCell_DepartmentName})
            Me.XrTableRow4.Name = "XrTableRow4"
            Me.XrTableRow4.Weight = 1.0R
            '
            'TableCell_GLDepartment
            '
            Me.TableCell_GLDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCell_GLDepartment.Name = "TableCell_GLDepartment"
            Me.TableCell_GLDepartment.StylePriority.UseFont = False
            Me.TableCell_GLDepartment.StylePriority.UseTextAlignment = False
            Me.TableCell_GLDepartment.Text = "GL"
            Me.TableCell_GLDepartment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_GLDepartment.Weight = 0.66198975468913457R
            '
            'TableCell_DepartmentCode
            '
            Me.TableCell_DepartmentCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCell_DepartmentCode.Name = "TableCell_DepartmentCode"
            Me.TableCell_DepartmentCode.StylePriority.UseFont = False
            Me.TableCell_DepartmentCode.StylePriority.UseTextAlignment = False
            Me.TableCell_DepartmentCode.Text = "Code"
            Me.TableCell_DepartmentCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_DepartmentCode.Weight = 0.77040813085388626R
            '
            'TableCell_DepartmentName
            '
            Me.TableCell_DepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCell_DepartmentName.Name = "TableCell_DepartmentName"
            Me.TableCell_DepartmentName.StylePriority.UseFont = False
            Me.TableCell_DepartmentName.StylePriority.UseTextAlignment = False
            Me.TableCell_DepartmentName.Text = "Name"
            Me.TableCell_DepartmentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_DepartmentName.Weight = 1.5676021144569794R
            '
            'Label_Department
            '
            Me.Label_Department.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.Label_Department.BorderWidth = 0
            Me.Label_Department.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Department.ForeColor = System.Drawing.Color.Black
            Me.Label_Department.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Label_Department.Name = "Label_Department"
            Me.Label_Department.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Department.SizeF = New System.Drawing.SizeF(489.0!, 24.0!)
            Me.Label_Department.StylePriority.UseBorders = False
            Me.Label_Department.StylePriority.UseBorderWidth = False
            Me.Label_Department.StylePriority.UseFont = False
            Me.Label_Department.StylePriority.UseForeColor = False
            Me.Label_Department.StylePriority.UseTextAlignment = False
            Me.Label_Department.Text = "Department"
            Me.Label_Department.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'DefaultDepartment
            '
            Me.DefaultDepartment.Expression = "Iif([DepartmentTeamCode] = [Employee.DepartmentTeamCode], 'Y' , '')"
            Me.DefaultDepartment.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DefaultDepartment.Name = "DefaultDepartment"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.BackColor = System.Drawing.Color.Gainsboro
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'DepartmentCrossReferenceSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.DefaultDepartment})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 361, 0, 0)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.Table_Department, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Table_DepartmentHeader, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DefaultDepartment As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Label_Department As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Table_DepartmentHeader As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCell_GLDepartment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCell_DepartmentCode As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCell_DepartmentName As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents Table_Department As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    End Class

End Namespace