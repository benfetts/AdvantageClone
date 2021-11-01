<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptPurchaseOrder 
    Inherits DataDynamics.ActiveReports.ActiveReport

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'Required by the ActiveReports Designer
    Private components As System.ComponentModel.IContainer
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(arptPurchaseOrder))
        Me.txtLineNumber = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txt_qty = New DataDynamics.ActiveReports.TextBox()
        Me.txt_rate = New DataDynamics.ActiveReports.TextBox()
        Me.txt_line_total = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txt_PO_total = New DataDynamics.ActiveReports.TextBox()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtPONumber = New DataDynamics.ActiveReports.TextBox()
        Me.txt_VendorInfo = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.txt_Issue_Date = New DataDynamics.ActiveReports.TextBox()
        Me.txt_due_date = New DataDynamics.ActiveReports.TextBox()
        Me.lbl_deliver = New DataDynamics.ActiveReports.Label()
        Me.lbl_main_instruct = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtFncDesc = New DataDynamics.ActiveReports.TextBox()
        Me.lblRevised = New DataDynamics.ActiveReports.Label()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.txt_IssueBy = New DataDynamics.ActiveReports.TextBox()
        Me.txt_Vendor_Attn = New DataDynamics.ActiveReports.TextBox()
        Me.txt_maininstruct = New DataDynamics.ActiveReports.TextBox()
        Me.txt_hdr_agency_name = New DataDynamics.ActiveReports.TextBox()
        Me.txt_agency_full_header = New DataDynamics.ActiveReports.TextBox()
        Me.txt_line_descrip = New DataDynamics.ActiveReports.TextBox()
        Me.txt_client = New DataDynamics.ActiveReports.TextBox()
        Me.txt_agency_full_footer = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.txt_det_desc = New DataDynamics.ActiveReports.TextBox()
        Me.txt_instructions = New DataDynamics.ActiveReports.TextBox()
        Me.txt_footer = New DataDynamics.ActiveReports.TextBox()
        Me.txtDelivery = New DataDynamics.ActiveReports.TextBox()
        Me.txtVoid = New DataDynamics.ActiveReports.TextBox()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.AuthDate = New DataDynamics.ActiveReports.TextBox()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.grp_detail_line = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        Me.group_detail_line2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.group_detail_line3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.grp_po = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.grp_po2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.grp_po3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtLineNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_rate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_line_total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PO_total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_VendorInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Issue_Date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_due_date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_deliver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_main_instruct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFncDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRevised, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IssueBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Vendor_Attn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_maininstruct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_hdr_agency_name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_agency_full_header, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_line_descrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_client, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_agency_full_footer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_det_desc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_instructions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_footer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVoid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'txtLineNumber
        '
        Me.txtLineNumber.DataField = "LINE_NUMBER"
        resources.ApplyResources(Me.txtLineNumber, "txtLineNumber")
        Me.txtLineNumber.Name = "txtLineNumber"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txt_qty
        '
        Me.txt_qty.DataField = "PO_QTY"
        resources.ApplyResources(Me.txt_qty, "txt_qty")
        Me.txt_qty.Name = "txt_qty"
        '
        'txt_rate
        '
        Me.txt_rate.DataField = "PO_RATE"
        resources.ApplyResources(Me.txt_rate, "txt_rate")
        Me.txt_rate.Name = "txt_rate"
        '
        'txt_line_total
        '
        Me.txt_line_total.DataField = "PO_EXT_AMOUNT"
        resources.ApplyResources(Me.txt_line_total, "txt_line_total")
        Me.txt_line_total.Name = "txt_line_total"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txt_PO_total
        '
        Me.txt_PO_total.DataField = "PO_EXT_AMOUNT"
        resources.ApplyResources(Me.txt_PO_total, "txt_PO_total")
        Me.txt_PO_total.Name = "txt_PO_total"
        Me.txt_PO_total.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'txtPONumber
        '
        Me.txtPONumber.CountNullValues = True
        Me.txtPONumber.DataField = "PO_NUMBER"
        resources.ApplyResources(Me.txtPONumber, "txtPONumber")
        Me.txtPONumber.Name = "txtPONumber"
        '
        'txt_VendorInfo
        '
        Me.txt_VendorInfo.CountNullValues = True
        Me.txt_VendorInfo.DataField = "VENDOR_INFO"
        resources.ApplyResources(Me.txt_VendorInfo, "txt_VendorInfo")
        Me.txt_VendorInfo.Name = "txt_VendorInfo"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'TextBox2
        '
        Me.TextBox2.CountNullValues = True
        Me.TextBox2.DataField = "PO_DESCRIPTION"
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'txt_Issue_Date
        '
        Me.txt_Issue_Date.CountNullValues = True
        Me.txt_Issue_Date.DataField = "PO_DATE"
        resources.ApplyResources(Me.txt_Issue_Date, "txt_Issue_Date")
        Me.txt_Issue_Date.Name = "txt_Issue_Date"
        '
        'txt_due_date
        '
        Me.txt_due_date.CountNullValues = True
        Me.txt_due_date.DataField = "PO_DUE_DATE"
        resources.ApplyResources(Me.txt_due_date, "txt_due_date")
        Me.txt_due_date.Name = "txt_due_date"
        '
        'lbl_deliver
        '
        resources.ApplyResources(Me.lbl_deliver, "lbl_deliver")
        Me.lbl_deliver.Name = "lbl_deliver"
        '
        'lbl_main_instruct
        '
        resources.ApplyResources(Me.lbl_main_instruct, "lbl_main_instruct")
        Me.lbl_main_instruct.Name = "lbl_main_instruct"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'txtProduct
        '
        Me.txtProduct.DataField = "PRD_NAME"
        resources.ApplyResources(Me.txtProduct, "txtProduct")
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Visible = False
        '
        'txtJobDesc
        '
        Me.txtJobDesc.DataField = "JOB_DESC"
        resources.ApplyResources(Me.txtJobDesc, "txtJobDesc")
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Visible = False
        '
        'txtFncDesc
        '
        Me.txtFncDesc.DataField = "FNC_DESCRIPTION"
        resources.ApplyResources(Me.txtFncDesc, "txtFncDesc")
        Me.txtFncDesc.Name = "txtFncDesc"
        Me.txtFncDesc.Visible = False
        '
        'lblRevised
        '
        Me.lblRevised.DataField = "PO_REVISION"
        resources.ApplyResources(Me.lblRevised, "lblRevised")
        Me.lblRevised.Name = "lblRevised"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        resources.ApplyResources(Me.ReportInfo1, "ReportInfo1")
        Me.ReportInfo1.Name = "ReportInfo1"
        '
        'txt_IssueBy
        '
        Me.txt_IssueBy.CountNullValues = True
        Me.txt_IssueBy.DataField = "ISSUE_BY"
        resources.ApplyResources(Me.txt_IssueBy, "txt_IssueBy")
        Me.txt_IssueBy.Name = "txt_IssueBy"
        '
        'txt_Vendor_Attn
        '
        Me.txt_Vendor_Attn.CountNullValues = True
        Me.txt_Vendor_Attn.DataField = "VENDOR_ATTN"
        resources.ApplyResources(Me.txt_Vendor_Attn, "txt_Vendor_Attn")
        Me.txt_Vendor_Attn.Name = "txt_Vendor_Attn"
        '
        'txt_maininstruct
        '
        Me.txt_maininstruct.CanShrink = True
        Me.txt_maininstruct.DataField = "PO_MAIN_INSTRUCT"
        resources.ApplyResources(Me.txt_maininstruct, "txt_maininstruct")
        Me.txt_maininstruct.Name = "txt_maininstruct"
        '
        'txt_hdr_agency_name
        '
        Me.txt_hdr_agency_name.CanShrink = True
        Me.txt_hdr_agency_name.CountNullValues = True
        Me.txt_hdr_agency_name.DataField = "HDR_AGENCY_NAME"
        resources.ApplyResources(Me.txt_hdr_agency_name, "txt_hdr_agency_name")
        Me.txt_hdr_agency_name.Name = "txt_hdr_agency_name"
        '
        'txt_agency_full_header
        '
        Me.txt_agency_full_header.CanShrink = True
        Me.txt_agency_full_header.CountNullValues = True
        Me.txt_agency_full_header.DataField = "AGENCY_FULL_HEADER"
        resources.ApplyResources(Me.txt_agency_full_header, "txt_agency_full_header")
        Me.txt_agency_full_header.Name = "txt_agency_full_header"
        '
        'txt_line_descrip
        '
        Me.txt_line_descrip.DataField = "LINE_DESC"
        resources.ApplyResources(Me.txt_line_descrip, "txt_line_descrip")
        Me.txt_line_descrip.Name = "txt_line_descrip"
        '
        'txt_client
        '
        Me.txt_client.DataField = "CL_NAME"
        resources.ApplyResources(Me.txt_client, "txt_client")
        Me.txt_client.Name = "txt_client"
        '
        'txt_agency_full_footer
        '
        Me.txt_agency_full_footer.CanShrink = True
        Me.txt_agency_full_footer.CountNullValues = True
        Me.txt_agency_full_footer.DataField = "AGENCY_FULL_FOOTER"
        resources.ApplyResources(Me.txt_agency_full_footer, "txt_agency_full_footer")
        Me.txt_agency_full_footer.Name = "txt_agency_full_footer"
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "JOBANDCOMP"
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'txt_det_desc
        '
        Me.txt_det_desc.CanShrink = True
        Me.txt_det_desc.DataField = "DET_DESC"
        resources.ApplyResources(Me.txt_det_desc, "txt_det_desc")
        Me.txt_det_desc.Name = "txt_det_desc"
        '
        'txt_instructions
        '
        Me.txt_instructions.CanShrink = True
        Me.txt_instructions.DataField = "DET_INSTRUCT"
        resources.ApplyResources(Me.txt_instructions, "txt_instructions")
        Me.txt_instructions.Name = "txt_instructions"
        '
        'txt_footer
        '
        Me.txt_footer.CanShrink = True
        resources.ApplyResources(Me.txt_footer, "txt_footer")
        Me.txt_footer.Name = "txt_footer"
        '
        'txtDelivery
        '
        Me.txtDelivery.CanShrink = True
        Me.txtDelivery.DataField = "DEL_INSTRUCT"
        resources.ApplyResources(Me.txtDelivery, "txtDelivery")
        Me.txtDelivery.Name = "txtDelivery"
        '
        'txtVoid
        '
        resources.ApplyResources(Me.txtVoid, "txtVoid")
        Me.txtVoid.Name = "txtVoid"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'AuthDate
        '
        Me.AuthDate.DataField = "PO_DATE"
        resources.ApplyResources(Me.AuthDate, "AuthDate")
        Me.AuthDate.Name = "AuthDate"
        '
        'Picture1
        '
        resources.ApplyResources(Me.Picture1, "Picture1")
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft
        '
        'Line6
        '
        resources.ApplyResources(Me.Line6, "Line6")
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 7.4375!
        Me.Line6.Y1 = 2.125!
        Me.Line6.Y2 = 2.125!
        '
        'Line5
        '
        resources.ApplyResources(Me.Line5, "Line5")
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 7.4375!
        Me.Line5.Y1 = 2.375!
        Me.Line5.Y2 = 2.375!
        '
        'Line1
        '
        resources.ApplyResources(Me.Line1, "Line1")
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.8125!
        Me.Line1.Y2 = 0.8125!
        '
        'Line2
        '
        resources.ApplyResources(Me.Line2, "Line2")
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.5!
        Me.Line2.Y2 = 0.5!
        '
        'Line9
        '
        resources.ApplyResources(Me.Line9, "Line9")
        Me.Line9.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line9.LineWeight = 2.0!
        Me.Line9.Name = "Line9"
        Me.Line9.X1 = 0.0!
        Me.Line9.X2 = 7.5!
        Me.Line9.Y1 = 0.0625!
        Me.Line9.Y2 = 0.0625!
        '
        'Line3
        '
        resources.ApplyResources(Me.Line3, "Line3")
        Me.Line3.LineWeight = 4.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 0.3125!
        Me.Line3.Y2 = 0.3125!
        '
        'Line7
        '
        resources.ApplyResources(Me.Line7, "Line7")
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.X1 = 1.0!
        Me.Line7.X2 = 3.75!
        Me.Line7.Y1 = 1.4375!
        Me.Line7.Y2 = 1.4375!
        '
        'Line8
        '
        resources.ApplyResources(Me.Line8, "Line8")
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.X1 = 4.5!
        Me.Line8.X2 = 7.4375!
        Me.Line8.Y1 = 1.4375!
        Me.Line8.Y2 = 1.4375!
        '
        'EmpSigPic
        '
        resources.ApplyResources(Me.EmpSigPic, "EmpSigPic")
        Me.EmpSigPic.ImageData = Nothing
        Me.EmpSigPic.Name = "EmpSigPic"
        '
        'Line10
        '
        resources.ApplyResources(Me.Line10, "Line10")
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.X1 = 4.5!
        Me.Line10.X2 = 7.4375!
        Me.Line10.Y1 = 1.75!
        Me.Line10.Y2 = 1.75!
        '
        'Line11
        '
        resources.ApplyResources(Me.Line11, "Line11")
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.X1 = 1.0!
        Me.Line11.X2 = 3.8125!
        Me.Line11.Y1 = 1.75!
        Me.Line11.Y2 = 1.75!
        '
        'Line4
        '
        resources.ApplyResources(Me.Line4, "Line4")
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 8.4375!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.0!
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.ReportInfo1, Me.txt_IssueBy, Me.Label14, Me.txt_due_date, Me.Label13, Me.txt_Issue_Date, Me.Label12, Me.Label10, Me.txtPONumber, Me.Label15, Me.txt_VendorInfo, Me.Label17, Me.txt_Vendor_Attn, Me.lblRevised, Me.Picture1, Me.txt_hdr_agency_name, Me.txt_agency_full_header, Me.Line6, Me.Label2, Me.Line5, Me.txtVoid})
        Me.PageHeader1.Height = 3.716667!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 0.02083333!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txt_agency_full_footer})
        Me.PageFooter1.Height = 0.4375!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'grp_detail_line
        '
        Me.grp_detail_line.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtLineNumber, Me.txt_line_descrip, Me.txt_client, Me.TextBox1, Me.txt_qty, Me.txt_rate, Me.txt_line_total, Me.txtFncDesc, Me.txtJobDesc, Me.txtProduct})
        Me.grp_detail_line.DataField = "LINE_NUMBER"
        Me.grp_detail_line.Height = 0.21875!
        Me.grp_detail_line.Name = "grp_detail_line"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line9})
        Me.GroupFooter1.Height = 0.07291666!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.CanShrink = True
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        Me.ReportHeader1.Visible = False
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.PrintAtBottom = True
        '
        'group_detail_line2
        '
        Me.group_detail_line2.CanShrink = True
        Me.group_detail_line2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txt_det_desc})
        Me.group_detail_line2.DataField = "LINE_NUMBER"
        Me.group_detail_line2.Height = 0.21875!
        Me.group_detail_line2.Name = "group_detail_line2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.02083333!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'group_detail_line3
        '
        Me.group_detail_line3.CanShrink = True
        Me.group_detail_line3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txt_instructions})
        Me.group_detail_line3.DataField = "LINE_NUMBER"
        Me.group_detail_line3.Height = 0.2708333!
        Me.group_detail_line3.Name = "group_detail_line3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'grp_po
        '
        Me.grp_po.CanShrink = True
        Me.grp_po.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txt_maininstruct, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Line1, Me.Line2, Me.lbl_main_instruct, Me.Label1, Me.TextBox2, Me.Label16})
        Me.grp_po.DataField = "PO_NUMBER"
        Me.grp_po.Height = 0.85!
        Me.grp_po.Name = "grp_po"
        '
        'GroupFooter4
        '
        Me.GroupFooter4.CanShrink = True
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.EmpSigPic, Me.Line3, Me.Label9, Me.txt_PO_total, Me.Line7, Me.Label18, Me.Line8, Me.Label19, Me.txt_footer, Me.Label20, Me.Label21, Me.AuthDate, Me.Line10, Me.Line11})
        Me.GroupFooter4.Height = 2.291666!
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'grp_po2
        '
        Me.grp_po2.DataField = "PO_NUMBER"
        Me.grp_po2.Height = 0.01041667!
        Me.grp_po2.Name = "grp_po2"
        '
        'GroupFooter5
        '
        Me.GroupFooter5.CanShrink = True
        Me.GroupFooter5.Height = 0.05208333!
        Me.GroupFooter5.Name = "GroupFooter5"
        Me.GroupFooter5.Visible = False
        '
        'grp_po3
        '
        Me.grp_po3.Height = 0.01041667!
        Me.grp_po3.Name = "grp_po3"
        '
        'GroupFooter6
        '
        Me.GroupFooter6.CanShrink = True
        Me.GroupFooter6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lbl_deliver, Me.Line4, Me.txtDelivery})
        Me.GroupFooter6.Height = 0.5416667!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'arptPurchaseOrder
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.grp_po)
        Me.Sections.Add(Me.grp_po2)
        Me.Sections.Add(Me.grp_po3)
        Me.Sections.Add(Me.grp_detail_line)
        Me.Sections.Add(Me.group_detail_line2)
        Me.Sections.Add(Me.group_detail_line3)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter6)
        Me.Sections.Add(Me.GroupFooter5)
        Me.Sections.Add(Me.GroupFooter4)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtLineNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_rate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_line_total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PO_total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_VendorInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Issue_Date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_due_date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_deliver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_main_instruct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFncDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRevised, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IssueBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Vendor_Attn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_maininstruct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_hdr_agency_name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_agency_full_header, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_line_descrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_client, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_agency_full_footer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_det_desc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_instructions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_footer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVoid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Friend WithEvents txtLineNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents txt_line_descrip As DataDynamics.ActiveReports.TextBox
    Friend WithEvents grp_detail_line As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txt_client As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_qty As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_rate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_line_total As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents group_detail_line2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents group_detail_line3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txt_PO_total As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPONumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_VendorInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents txt_Vendor_Attn As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_Issue_Date As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_due_date As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_IssueBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents grp_po As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents grp_po2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents grp_po3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lbl_deliver As DataDynamics.ActiveReports.Label
    Friend WithEvents lbl_main_instruct As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txt_footer As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_det_desc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_instructions As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDelivery As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_maininstruct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_hdr_agency_name As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_agency_full_header As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txt_agency_full_footer As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFncDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblRevised As DataDynamics.ActiveReports.Label
    Friend WithEvents txtVoid As DataDynamics.ActiveReports.TextBox
    Friend WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents AuthDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
End Class
