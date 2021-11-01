Namespace Templates

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class AdvantageAPIRestCalls
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageAPIRestCalls))
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrRichText1 = New DevExpress.XtraReports.UI.XRRichText()
            Me.Page2 = New DevExpress.XtraReports.UI.SubBand()
            Me.LabelPage2_Instances = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPage2_RESTAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPage2_SOAPAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPage2_SOAP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPage2_REST = New DevExpress.XtraReports.UI.XRLabel()
            Me.Page3 = New DevExpress.XtraReports.UI.SubBand()
            Me.LabelPage3_ServiceClassLayout = New DevExpress.XtraReports.UI.XRLabel()
            Me.TablePage3_Methods = New DevExpress.XtraReports.UI.XRTable()
            Me.TableRowMethodsTable_HeaderRow = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellHeaderRow_Methods = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeaderRow_Parameters = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeaderRow_Return = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableRowMethodsTable_TempRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellTempRow1_MethodsCell = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellTempRow1_ParametersCell = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellTempRow1_Return = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableRowMethodsTable_TempRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellTempRow2_Methods = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellTempRow2_Parameters = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellTempRow2_Return = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TablePage4_Method = New DevExpress.XtraReports.UI.XRTable()
            Me.TableRowMethod_HeaderRow = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableRowMethod_TempRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellTempRow1_Method = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableRowMethod_TempRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellTempRow2_Method = New DevExpress.XtraReports.UI.XRTableCell()
            Me.LabelPage4_AdditionalRestInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.LabelReportHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.OddStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.EvenStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TablePage3_Methods, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TablePage4_Method, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichText1})
            Me.Detail.HeightF = 66.45832!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.Page2, Me.Page3})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrRichText1
            '
            Me.XrRichText1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrRichText1.LocationFloat = New DevExpress.Utils.PointFloat(9.99999!, 4.999987!)
            Me.XrRichText1.Name = "XrRichText1"
            Me.XrRichText1.SerializableRtfString = resources.GetString("XrRichText1.SerializableRtfString")
            Me.XrRichText1.SizeF = New System.Drawing.SizeF(690.0!, 61.45833!)
            Me.XrRichText1.StylePriority.UseFont = False
            '
            'Page2
            '
            Me.Page2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.TablePage3_Methods, Me.LabelPage3_ServiceClassLayout, Me.LabelPage2_Instances, Me.LabelPage2_RESTAddress, Me.LabelPage2_SOAPAddress, Me.LabelPage2_SOAP, Me.LabelPage2_REST})
            Me.Page2.HeightF = 290.0!
            Me.Page2.Name = "Page2"
            Me.Page2.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand
            '
            'LabelPage2_Instances
            '
            Me.LabelPage2_Instances.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage2_Instances.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(145, Byte), Integer))
            Me.LabelPage2_Instances.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 0!)
            Me.LabelPage2_Instances.Name = "LabelPage2_Instances"
            Me.LabelPage2_Instances.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage2_Instances.SizeF = New System.Drawing.SizeF(699.9999!, 42.0!)
            Me.LabelPage2_Instances.StylePriority.UseFont = False
            Me.LabelPage2_Instances.StylePriority.UseForeColor = False
            Me.LabelPage2_Instances.StylePriority.UseTextAlignment = False
            Me.LabelPage2_Instances.Text = "1. INSTANCES"
            Me.LabelPage2_Instances.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelPage2_RESTAddress
            '
            Me.LabelPage2_RESTAddress.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage2_RESTAddress.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 135.0!)
            Me.LabelPage2_RESTAddress.Name = "LabelPage2_RESTAddress"
            Me.LabelPage2_RESTAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage2_RESTAddress.SizeF = New System.Drawing.SizeF(699.9999!, 22.99998!)
            Me.LabelPage2_RESTAddress.StylePriority.UseFont = False
            Me.LabelPage2_RESTAddress.StylePriority.UseTextAlignment = False
            Me.LabelPage2_RESTAddress.Text = "{base address}/APIService.svc/REST"
            Me.LabelPage2_RESTAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelPage2_SOAPAddress
            '
            Me.LabelPage2_SOAPAddress.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage2_SOAPAddress.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 76.99998!)
            Me.LabelPage2_SOAPAddress.Name = "LabelPage2_SOAPAddress"
            Me.LabelPage2_SOAPAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage2_SOAPAddress.SizeF = New System.Drawing.SizeF(699.9999!, 23.0!)
            Me.LabelPage2_SOAPAddress.StylePriority.UseFont = False
            Me.LabelPage2_SOAPAddress.StylePriority.UseTextAlignment = False
            Me.LabelPage2_SOAPAddress.Text = "{base address}/APIService.svc/SOAP"
            Me.LabelPage2_SOAPAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelPage2_SOAP
            '
            Me.LabelPage2_SOAP.Font = New System.Drawing.Font("Cambria", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage2_SOAP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
            Me.LabelPage2_SOAP.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 42.00001!)
            Me.LabelPage2_SOAP.Name = "LabelPage2_SOAP"
            Me.LabelPage2_SOAP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage2_SOAP.SizeF = New System.Drawing.SizeF(699.9999!, 35.00001!)
            Me.LabelPage2_SOAP.StylePriority.UseFont = False
            Me.LabelPage2_SOAP.StylePriority.UseForeColor = False
            Me.LabelPage2_SOAP.StylePriority.UseTextAlignment = False
            Me.LabelPage2_SOAP.Text = "SOAP"
            Me.LabelPage2_SOAP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelPage2_REST
            '
            Me.LabelPage2_REST.Font = New System.Drawing.Font("Cambria", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage2_REST.ForeColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
            Me.LabelPage2_REST.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 100.0!)
            Me.LabelPage2_REST.Name = "LabelPage2_REST"
            Me.LabelPage2_REST.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage2_REST.SizeF = New System.Drawing.SizeF(699.9999!, 35.0!)
            Me.LabelPage2_REST.StylePriority.UseFont = False
            Me.LabelPage2_REST.StylePriority.UseForeColor = False
            Me.LabelPage2_REST.StylePriority.UseTextAlignment = False
            Me.LabelPage2_REST.Text = "REST"
            Me.LabelPage2_REST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'Page3
            '
            Me.Page3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.TablePage4_Method, Me.LabelPage4_AdditionalRestInfo})
            Me.Page3.HeightF = 155.9583!
            Me.Page3.Name = "Page3"
            Me.Page3.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand
            '
            'LabelPage3_ServiceClassLayout
            '
            Me.LabelPage3_ServiceClassLayout.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage3_ServiceClassLayout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(145, Byte), Integer))
            Me.LabelPage3_ServiceClassLayout.LocationFloat = New DevExpress.Utils.PointFloat(0!, 158.0!)
            Me.LabelPage3_ServiceClassLayout.Name = "LabelPage3_ServiceClassLayout"
            Me.LabelPage3_ServiceClassLayout.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage3_ServiceClassLayout.SizeF = New System.Drawing.SizeF(700.0!, 42.0!)
            Me.LabelPage3_ServiceClassLayout.StylePriority.UseFont = False
            Me.LabelPage3_ServiceClassLayout.StylePriority.UseForeColor = False
            Me.LabelPage3_ServiceClassLayout.StylePriority.UseTextAlignment = False
            Me.LabelPage3_ServiceClassLayout.Text = "2. SERVICE CLASS LAYOUT"
            Me.LabelPage3_ServiceClassLayout.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'TablePage3_Methods
            '
            Me.TablePage3_Methods.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
            Me.TablePage3_Methods.BorderColor = System.Drawing.Color.White
            Me.TablePage3_Methods.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.TablePage3_Methods.BorderWidth = 2.0!
            Me.TablePage3_Methods.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TablePage3_Methods.ForeColor = System.Drawing.Color.White
            Me.TablePage3_Methods.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 200.0!)
            Me.TablePage3_Methods.Name = "TablePage3_Methods"
            Me.TablePage3_Methods.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowMethodsTable_HeaderRow, Me.TableRowMethodsTable_TempRow1, Me.TableRowMethodsTable_TempRow2})
            Me.TablePage3_Methods.SizeF = New System.Drawing.SizeF(700.0!, 90.0!)
            Me.TablePage3_Methods.StylePriority.UseBackColor = False
            Me.TablePage3_Methods.StylePriority.UseBorderColor = False
            Me.TablePage3_Methods.StylePriority.UseBorders = False
            Me.TablePage3_Methods.StylePriority.UseBorderWidth = False
            Me.TablePage3_Methods.StylePriority.UseFont = False
            Me.TablePage3_Methods.StylePriority.UseForeColor = False
            Me.TablePage3_Methods.StylePriority.UseTextAlignment = False
            Me.TablePage3_Methods.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'TableRowMethodsTable_HeaderRow
            '
            Me.TableRowMethodsTable_HeaderRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellHeaderRow_Methods, Me.TableCellHeaderRow_Parameters, Me.TableCellHeaderRow_Return})
            Me.TableRowMethodsTable_HeaderRow.Name = "TableRowMethodsTable_HeaderRow"
            Me.TableRowMethodsTable_HeaderRow.Weight = 1.5999996948242188R
            '
            'TableCellHeaderRow_Methods
            '
            Me.TableCellHeaderRow_Methods.Name = "TableCellHeaderRow_Methods"
            Me.TableCellHeaderRow_Methods.Text = "Method"
            Me.TableCellHeaderRow_Methods.Weight = 0.93269226074218747R
            '
            'TableCellHeaderRow_Parameters
            '
            Me.TableCellHeaderRow_Parameters.Name = "TableCellHeaderRow_Parameters"
            Me.TableCellHeaderRow_Parameters.Text = "Parameters"
            Me.TableCellHeaderRow_Parameters.Weight = 1.1875R
            '
            'TableCellHeaderRow_Return
            '
            Me.TableCellHeaderRow_Return.Name = "TableCellHeaderRow_Return"
            Me.TableCellHeaderRow_Return.Text = "Return"
            Me.TableCellHeaderRow_Return.Weight = 0.87980773925781253R
            '
            'TableRowMethodsTable_TempRow1
            '
            Me.TableRowMethodsTable_TempRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellTempRow1_MethodsCell, Me.TableCellTempRow1_ParametersCell, Me.TableCellTempRow1_Return})
            Me.TableRowMethodsTable_TempRow1.Name = "TableRowMethodsTable_TempRow1"
            Me.TableRowMethodsTable_TempRow1.StyleName = "OddStyle"
            Me.TableRowMethodsTable_TempRow1.Weight = 1.0R
            '
            'TableCellTempRow1_MethodsCell
            '
            Me.TableCellTempRow1_MethodsCell.Name = "TableCellTempRow1_MethodsCell"
            Me.TableCellTempRow1_MethodsCell.Text = "Method" & Global.Microsoft.VisualBasic.ChrW(9)
            Me.TableCellTempRow1_MethodsCell.Weight = 0.93269226074218747R
            '
            'TableCellTempRow1_ParametersCell
            '
            Me.TableCellTempRow1_ParametersCell.Name = "TableCellTempRow1_ParametersCell"
            Me.TableCellTempRow1_ParametersCell.Text = "Parameters"
            Me.TableCellTempRow1_ParametersCell.Weight = 1.1875R
            '
            'TableCellTempRow1_Return
            '
            Me.TableCellTempRow1_Return.Name = "TableCellTempRow1_Return"
            Me.TableCellTempRow1_Return.Text = "Return"
            Me.TableCellTempRow1_Return.Weight = 0.87980773925781253R
            '
            'TableRowMethodsTable_TempRow2
            '
            Me.TableRowMethodsTable_TempRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellTempRow2_Methods, Me.TableCellTempRow2_Parameters, Me.TableCellTempRow2_Return})
            Me.TableRowMethodsTable_TempRow2.Name = "TableRowMethodsTable_TempRow2"
            Me.TableRowMethodsTable_TempRow2.StyleName = "EvenStyle"
            Me.TableRowMethodsTable_TempRow2.Weight = 1.0R
            '
            'TableCellTempRow2_Methods
            '
            Me.TableCellTempRow2_Methods.Name = "TableCellTempRow2_Methods"
            Me.TableCellTempRow2_Methods.Text = "Method"
            Me.TableCellTempRow2_Methods.Weight = 0.93269226074218747R
            '
            'TableCellTempRow2_Parameters
            '
            Me.TableCellTempRow2_Parameters.Name = "TableCellTempRow2_Parameters"
            Me.TableCellTempRow2_Parameters.Text = "Parameters"
            Me.TableCellTempRow2_Parameters.Weight = 1.1875R
            '
            'TableCellTempRow2_Return
            '
            Me.TableCellTempRow2_Return.Name = "TableCellTempRow2_Return"
            Me.TableCellTempRow2_Return.Text = "Return"
            Me.TableCellTempRow2_Return.Weight = 0.87980773925781253R
            '
            'TablePage4_Method
            '
            Me.TablePage4_Method.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
            Me.TablePage4_Method.BorderColor = System.Drawing.Color.White
            Me.TablePage4_Method.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.TablePage4_Method.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TablePage4_Method.ForeColor = System.Drawing.Color.White
            Me.TablePage4_Method.LocationFloat = New DevExpress.Utils.PointFloat(0!, 65.25002!)
            Me.TablePage4_Method.Name = "TablePage4_Method"
            Me.TablePage4_Method.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowMethod_HeaderRow, Me.TableRowMethod_TempRow1, Me.TableRowMethod_TempRow2})
            Me.TablePage4_Method.SizeF = New System.Drawing.SizeF(700.0!, 90.0!)
            Me.TablePage4_Method.StylePriority.UseBackColor = False
            Me.TablePage4_Method.StylePriority.UseBorderColor = False
            Me.TablePage4_Method.StylePriority.UseBorders = False
            Me.TablePage4_Method.StylePriority.UseFont = False
            Me.TablePage4_Method.StylePriority.UseForeColor = False
            Me.TablePage4_Method.StylePriority.UseTextAlignment = False
            Me.TablePage4_Method.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'TableRowMethod_HeaderRow
            '
            Me.TableRowMethod_HeaderRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
            Me.TableRowMethod_HeaderRow.Name = "TableRowMethod_HeaderRow"
            Me.TableRowMethod_HeaderRow.Weight = 1.6R
            '
            'XrTableCell1
            '
            Me.XrTableCell1.Name = "XrTableCell1"
            Me.XrTableCell1.Text = "Method"
            Me.XrTableCell1.Weight = 3.0R
            '
            'TableRowMethod_TempRow1
            '
            Me.TableRowMethod_TempRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellTempRow1_Method})
            Me.TableRowMethod_TempRow1.Name = "TableRowMethod_TempRow1"
            Me.TableRowMethod_TempRow1.StyleName = "OddStyle"
            Me.TableRowMethod_TempRow1.Weight = 1.0R
            '
            'TableCellTempRow1_Method
            '
            Me.TableCellTempRow1_Method.Name = "TableCellTempRow1_Method"
            Me.TableCellTempRow1_Method.Text = "Method" & Global.Microsoft.VisualBasic.ChrW(9)
            Me.TableCellTempRow1_Method.Weight = 3.0R
            '
            'TableRowMethod_TempRow2
            '
            Me.TableRowMethod_TempRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellTempRow2_Method})
            Me.TableRowMethod_TempRow2.Name = "TableRowMethod_TempRow2"
            Me.TableRowMethod_TempRow2.StyleName = "EvenStyle"
            Me.TableRowMethod_TempRow2.Weight = 1.0R
            '
            'TableCellTempRow2_Method
            '
            Me.TableCellTempRow2_Method.Name = "TableCellTempRow2_Method"
            Me.TableCellTempRow2_Method.Text = "Method"
            Me.TableCellTempRow2_Method.Weight = 3.0R
            '
            'LabelPage4_AdditionalRestInfo
            '
            Me.LabelPage4_AdditionalRestInfo.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPage4_AdditionalRestInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(145, Byte), Integer))
            Me.LabelPage4_AdditionalRestInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelPage4_AdditionalRestInfo.Name = "LabelPage4_AdditionalRestInfo"
            Me.LabelPage4_AdditionalRestInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelPage4_AdditionalRestInfo.SizeF = New System.Drawing.SizeF(700.0!, 42.0!)
            Me.LabelPage4_AdditionalRestInfo.StylePriority.UseFont = False
            Me.LabelPage4_AdditionalRestInfo.StylePriority.UseForeColor = False
            Me.LabelPage4_AdditionalRestInfo.StylePriority.UseTextAlignment = False
            Me.LabelPage4_AdditionalRestInfo.Text = "3. ADDITIONAL REST INFORMATION"
            Me.LabelPage4_AdditionalRestInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 75.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 75.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportHeader_Title})
            Me.ReportHeader.HeightF = 50.08335!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'LabelReportHeader_Title
            '
            Me.LabelReportHeader_Title.BorderColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
            Me.LabelReportHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelReportHeader_Title.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportHeader_Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(93, Byte), Integer))
            Me.LabelReportHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 0!)
            Me.LabelReportHeader_Title.Name = "LabelReportHeader_Title"
            Me.LabelReportHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportHeader_Title.SizeF = New System.Drawing.SizeF(700.0!, 50.08335!)
            Me.LabelReportHeader_Title.StylePriority.UseBorderColor = False
            Me.LabelReportHeader_Title.StylePriority.UseBorders = False
            Me.LabelReportHeader_Title.StylePriority.UseFont = False
            Me.LabelReportHeader_Title.StylePriority.UseForeColor = False
            Me.LabelReportHeader_Title.Text = "Advantage API"
            '
            'OddStyle
            '
            Me.OddStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.OddStyle.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.OddStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.OddStyle.Name = "OddStyle"
            Me.OddStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 4, 4, 100.0!)
            Me.OddStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'EvenStyle
            '
            Me.EvenStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
            Me.EvenStyle.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.EvenStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.EvenStyle.Name = "EvenStyle"
            Me.EvenStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 4, 4, 100.0!)
            Me.EvenStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.Font = New System.Drawing.Font("Calibri", 11.0!)
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 42.00001!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(700.0!, 23.25001!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseForeColor = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "SAMPLE CALL: http://localhost/AdvantageAPI2/APIService.svc/REST/{MethodName}?"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'AdvantageAPIRestCalls
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
            Me.BorderWidth = 2.0!
            Me.Margins = New System.Drawing.Printing.Margins(75, 75, 75, 75)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.OddStyle, Me.EvenStyle})
            Me.Version = "18.1"
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TablePage3_Methods, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TablePage4_Method, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents LabelReportHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrRichText1 As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents LabelPage2_Instances As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPage2_SOAP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPage2_SOAPAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPage2_RESTAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPage2_REST As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TablePage3_Methods As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowMethodsTable_HeaderRow As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellHeaderRow_Methods As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeaderRow_Parameters As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeaderRow_Return As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents LabelPage3_ServiceClassLayout As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Page3 As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents Page2 As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents OddStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents EvenStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents TableRowMethodsTable_TempRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellTempRow1_MethodsCell As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellTempRow1_ParametersCell As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellTempRow1_Return As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableRowMethodsTable_TempRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellTempRow2_Methods As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellTempRow2_Parameters As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellTempRow2_Return As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TablePage4_Method As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowMethod_HeaderRow As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableRowMethod_TempRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellTempRow1_Method As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableRowMethod_TempRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellTempRow2_Method As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents LabelPage4_AdditionalRestInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace


