Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountAllocationDetailsSubReport
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
            Me.Table_GLATrailers = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCell_GLAccount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCell_Percent = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCell_SquareFeet = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCell_NumberOfEmployees = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.Table_GLATrailersHeader = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TabelCellHeader_GLAccountAndDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_Percent = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_SquareFeet = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_NumberOfEmployees = New DevExpress.XtraReports.UI.XRTableCell()
            Me.DefaultDepartment = New DevExpress.XtraReports.UI.CalculatedField()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.Table_GLATrailers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Table_GLATrailersHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Table_GLATrailers})
            Me.Detail.HeightF = 29.16667!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Table_GLATrailers
            '
            Me.Table_GLATrailers.EvenStyleName = "XrControlStyle1"
            Me.Table_GLATrailers.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Table_GLATrailers.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Table_GLATrailers.Name = "Table_GLATrailers"
            Me.Table_GLATrailers.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
            Me.Table_GLATrailers.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
            Me.Table_GLATrailers.SizeF = New System.Drawing.SizeF(750.0!, 25.0!)
            Me.Table_GLATrailers.StylePriority.UseFont = False
            Me.Table_GLATrailers.StylePriority.UsePadding = False
            '
            'XrTableRow2
            '
            Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCell_GLAccount, Me.TableCell_Percent, Me.TableCell_SquareFeet, Me.TableCell_NumberOfEmployees})
            Me.XrTableRow2.Name = "XrTableRow2"
            Me.XrTableRow2.Weight = 1.0R
            '
            'TableCell_GLAccount
            '
            Me.TableCell_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableCell_GLAccount.Name = "TableCell_GLAccount"
            Me.TableCell_GLAccount.StylePriority.UseFont = False
            Me.TableCell_GLAccount.StylePriority.UseTextAlignment = False
            Me.TableCell_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_GLAccount.Weight = 1.4255674843476198R
            '
            'TableCell_Percent
            '
            Me.TableCell_Percent.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAltValue", "{0:0.00000}%")})
            Me.TableCell_Percent.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableCell_Percent.Name = "TableCell_Percent"
            Me.TableCell_Percent.StylePriority.UseFont = False
            Me.TableCell_Percent.StylePriority.UseTextAlignment = False
            Me.TableCell_Percent.Text = "TableCell_Percent"
            Me.TableCell_Percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_Percent.Weight = 0.57443251565238018R
            '
            'TableCell_SquareFeet
            '
            Me.TableCell_SquareFeet.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAltAllocation")})
            Me.TableCell_SquareFeet.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableCell_SquareFeet.Name = "TableCell_SquareFeet"
            Me.TableCell_SquareFeet.StylePriority.UseFont = False
            Me.TableCell_SquareFeet.StylePriority.UseTextAlignment = False
            Me.TableCell_SquareFeet.Text = "TableCell_SquareFeet"
            Me.TableCell_SquareFeet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_SquareFeet.Weight = 0.57443252583848781R
            '
            'TableCell_NumberOfEmployees
            '
            Me.TableCell_NumberOfEmployees.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAltAllocation")})
            Me.TableCell_NumberOfEmployees.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableCell_NumberOfEmployees.Name = "TableCell_NumberOfEmployees"
            Me.TableCell_NumberOfEmployees.StylePriority.UseFont = False
            Me.TableCell_NumberOfEmployees.StylePriority.UseTextAlignment = False
            Me.TableCell_NumberOfEmployees.Text = "TableCell_NumberOfEmployees"
            Me.TableCell_NumberOfEmployees.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCell_NumberOfEmployees.Weight = 0.57443258695513288R
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Table_GLATrailersHeader})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 25.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'Table_GLATrailersHeader
            '
            Me.Table_GLATrailersHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.Table_GLATrailersHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Table_GLATrailersHeader.Name = "Table_GLATrailersHeader"
            Me.Table_GLATrailersHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
            Me.Table_GLATrailersHeader.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
            Me.Table_GLATrailersHeader.SizeF = New System.Drawing.SizeF(750.0!, 25.0!)
            Me.Table_GLATrailersHeader.StylePriority.UseFont = False
            Me.Table_GLATrailersHeader.StylePriority.UsePadding = False
            '
            'XrTableRow1
            '
            Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TabelCellHeader_GLAccountAndDescription, Me.TableCellHeader_Percent, Me.TableCellHeader_SquareFeet, Me.TableCellHeader_NumberOfEmployees})
            Me.XrTableRow1.Name = "XrTableRow1"
            Me.XrTableRow1.Weight = 1.0R
            '
            'TabelCellHeader_GLAccountAndDescription
            '
            Me.TabelCellHeader_GLAccountAndDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabelCellHeader_GLAccountAndDescription.Name = "TabelCellHeader_GLAccountAndDescription"
            Me.TabelCellHeader_GLAccountAndDescription.StylePriority.UseFont = False
            Me.TabelCellHeader_GLAccountAndDescription.StylePriority.UseTextAlignment = False
            Me.TabelCellHeader_GLAccountAndDescription.Text = "GL Account and Description"
            Me.TabelCellHeader_GLAccountAndDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TabelCellHeader_GLAccountAndDescription.Weight = 1.4255674843476198R
            '
            'TableCellHeader_Percent
            '
            Me.TableCellHeader_Percent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_Percent.Name = "TableCellHeader_Percent"
            Me.TableCellHeader_Percent.StylePriority.UseFont = False
            Me.TableCellHeader_Percent.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_Percent.Text = "Percent"
            Me.TableCellHeader_Percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellHeader_Percent.Weight = 0.57443251565238018R
            '
            'TableCellHeader_SquareFeet
            '
            Me.TableCellHeader_SquareFeet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_SquareFeet.Name = "TableCellHeader_SquareFeet"
            Me.TableCellHeader_SquareFeet.StylePriority.UseFont = False
            Me.TableCellHeader_SquareFeet.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_SquareFeet.Text = "Square Feet"
            Me.TableCellHeader_SquareFeet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellHeader_SquareFeet.Weight = 0.57443252583848781R
            '
            'TableCellHeader_NumberOfEmployees
            '
            Me.TableCellHeader_NumberOfEmployees.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_NumberOfEmployees.Name = "TableCellHeader_NumberOfEmployees"
            Me.TableCellHeader_NumberOfEmployees.StylePriority.UseFont = False
            Me.TableCellHeader_NumberOfEmployees.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_NumberOfEmployees.Text = "Number of Employees"
            Me.TableCellHeader_NumberOfEmployees.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellHeader_NumberOfEmployees.Weight = 0.57443258695513288R
            '
            'DefaultDepartment
            '
            Me.DefaultDepartment.Expression = "Iif([DepartmentTeamCode] = [Employee.DepartmentTeamCode], 'Y' , '')"
            Me.DefaultDepartment.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.DefaultDepartment.Name = "DefaultDepartment"
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.BackColor = System.Drawing.Color.Gainsboro
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.GLATrailer)
            '
            'AccountAllocationDetailsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.DefaultDepartment})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 100, 0, 0)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.Version = "14.2"
            CType(Me.Table_GLATrailers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Table_GLATrailersHeader, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DefaultDepartment As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents Table_GLATrailersHeader As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TabelCellHeader_GLAccountAndDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_Percent As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_SquareFeet As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_NumberOfEmployees As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents Table_GLATrailers As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCell_GLAccount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCell_Percent As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCell_SquareFeet As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCell_NumberOfEmployees As DevExpress.XtraReports.UI.XRTableCell
    End Class

End Namespace