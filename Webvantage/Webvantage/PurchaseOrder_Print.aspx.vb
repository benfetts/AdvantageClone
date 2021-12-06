Imports Telerik.Web.UI

Partial Public Class PurchaseOrder_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _PONumber As Integer = Nothing
    Private _CallingPageMode As String = ""
    Private _FromJJ As String = ""
    Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadPrintOptions()

        'objects
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim IsNew As Boolean = False
        Dim DateToPrint As Boolean = False

        PurchaseOrderPrintDefault = GetPurchaseOrderPrintDefault()

        If PurchaseOrderPrintDefault IsNot Nothing Then

            RadComboBoxLocation.SelectedValue = PurchaseOrderPrintDefault.LocationID

            If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.ReportFormat) Then

                RadComboBoxReportFormat.SelectedValue = PurchaseOrderPrintDefault.ReportFormat

            End If

            LoadLocationInformation()

            CheckBoxDateToPrint.Checked = CBool(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0))
            RadDatePickerPODateToPrint.Enabled = CheckBoxDateToPrint.Checked
            CheckboxPOInstructions.Checked = CBool(PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0))
            CheckboxDeliveryInstructions.Checked = CBool(PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0))
            CheckboxDetailDescription.Checked = CBool(PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0))
            CheckboxDetailInstruction.Checked = CBool(PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0))
            CheckboxFooterComment.Checked = CBool(PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0))

            CheckboxVendorCode.Checked = CBool(PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0))
            CheckboxVendorContact.Checked = CBool(PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0))
            CheckboxClientName.Checked = CBool(PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0))
            CheckboxProductName.Checked = CBool(PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0))
            CheckboxJobComponent.Checked = CBool(PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0))
            CheckboxJobDescription.Checked = CBool(PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0))
            CheckboxJobComponentDescription.Checked = CBool(PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0))
            CheckboxFunctionDescription.Checked = CBool(PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0))
            CheckboxExcludeEmployeeSignature.Checked = CBool(PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0))
            CheckBoxUseUserSignature.Checked = CBool(PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0))
            CheckBoxUseLocationName.Checked = CBool(PurchaseOrderPrintDefault.UseLocationName.GetValueOrDefault(0))
            CheckBoxUseClientName.Checked = CBool(PurchaseOrderPrintDefault.UseClientName.GetValueOrDefault(0))

        End If

        'CheckBoxPrintOptions_SaveSelections.Checked = True

    End Sub
    Private Sub CreateParameterDictionaryAndUpdatePOsForPrinting()

        'objects
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim IsNewPrintDefault As Boolean = False
        Dim PONumbers As Integer() = Nothing

        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

        Select Case RadComboBoxReportFormat.SelectedValue

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                _ParameterDictionary("FooterAboveSignature") = False

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code

                _ParameterDictionary("FooterAboveSignature") = True

        End Select

        Try

            PONumbers = {_PONumber}

            _ParameterDictionary("PONumbers") = PONumbers

        Catch ex As Exception

        End Try

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim POs As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing

            POs = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, _PONumber).ToList

            For Each po In POs
                If po.Job IsNot Nothing Then
                    If po.Job.Client.Name <> "" Then
                        _ParameterDictionary("ClientName") = po.Job.Client.Name
                        Exit For
                    End If
                End If
            Next


        End Using

        PurchaseOrderPrintDefault = GetPurchaseOrderPrintDefault()

        If PurchaseOrderPrintDefault Is Nothing Then

            PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
            IsNewPrintDefault = True

        End If

        FillPurchaseOrderPrintDefault(PurchaseOrderPrintDefault)

        _ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

        If Not [String].IsNullOrWhiteSpace(RadComboBoxLocation.SelectedValue) AndAlso Session("LocationOverride") IsNot Nothing Then

            Location = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Database.Entities.Location)(Session("LocationOverride"))

        End If

        _ParameterDictionary("DefaultLocation") = Location

        If CheckBoxDateToPrint.Checked Then

            _ParameterDictionary("UsePrintedDate") = RadDatePickerPODateToPrint.SelectedDate

        End If

        SavePurchaseOrderPrintDetaults(PurchaseOrderPrintDefault, IsNewPrintDefault)

        SetPOPrinted(PONumbers)

    End Sub
    Private Sub SetPOPrinted(ByVal PONumbers As Integer())

        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[PURCHASE_ORDER] SET [PO_PRINTED] = 1 WHERE [PO_NUMBER] IN ({0})", String.Join(",", PONumbers)))

    End Sub
    Private Sub FillPurchaseOrderPrintDefault(ByVal PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)

        If PurchaseOrderPrintDefault IsNot Nothing Then

            If Not [String].IsNullOrWhiteSpace(RadComboBoxLocation.SelectedValue) Then

                PurchaseOrderPrintDefault.LocationID = RadComboBoxLocation.SelectedValue

            Else

                PurchaseOrderPrintDefault.LocationID = Nothing

            End If

            PurchaseOrderPrintDefault.DateToPrint = Convert.ToInt16(CheckBoxDateToPrint.Checked)
            PurchaseOrderPrintDefault.PurchaseOrderInstructions = Convert.ToInt16(CheckboxPOInstructions.Checked)
            PurchaseOrderPrintDefault.ShippingInstructions = Convert.ToInt16(CheckboxDeliveryInstructions.Checked)
            PurchaseOrderPrintDefault.DetailDescription = Convert.ToInt16(CheckboxDetailDescription.Checked)
            PurchaseOrderPrintDefault.DetailInstruction = Convert.ToInt16(CheckboxDetailInstruction.Checked)
            PurchaseOrderPrintDefault.FooterComment = Convert.ToInt16(CheckboxFooterComment.Checked)
            PurchaseOrderPrintDefault.VendorCode = Convert.ToInt16(CheckboxVendorCode.Checked)
            PurchaseOrderPrintDefault.VendorContact = Convert.ToInt16(CheckboxVendorContact.Checked)
            PurchaseOrderPrintDefault.ClientName = Convert.ToInt16(CheckboxClientName.Checked)
            PurchaseOrderPrintDefault.ProductName = Convert.ToInt16(CheckboxProductName.Checked)
            PurchaseOrderPrintDefault.JobComponentNumber = Convert.ToInt16(CheckboxJobComponent.Checked)
            PurchaseOrderPrintDefault.JobDescription = Convert.ToInt16(CheckboxJobDescription.Checked)
            PurchaseOrderPrintDefault.JobComponentDescription = Convert.ToInt16(CheckboxJobComponentDescription.Checked)
            PurchaseOrderPrintDefault.FunctionDescription = Convert.ToInt16(CheckboxFunctionDescription.Checked)
            PurchaseOrderPrintDefault.UseEmployeeSignature = Convert.ToInt16(CheckboxExcludeEmployeeSignature.Checked)
            PurchaseOrderPrintDefault.UseUserSignature = Convert.ToInt16(CheckBoxUseUserSignature.Checked)
            PurchaseOrderPrintDefault.ReportFormat = RadComboBoxReportFormat.SelectedValue
            PurchaseOrderPrintDefault.UseLocationName = Convert.ToInt16(CheckBoxUseLocationName.Checked)
            PurchaseOrderPrintDefault.UseClientName = Convert.ToInt16(CheckBoxUseClientName.Checked)

        End If

    End Sub
    Private Function GetPurchaseOrderPrintDefault() As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault

        'objects
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

        Try

            PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(_DbContext, _Session.UserCode)

        Catch ex As Exception
            PurchaseOrderPrintDefault = Nothing
        Finally
            GetPurchaseOrderPrintDefault = PurchaseOrderPrintDefault
        End Try

    End Function
    Private Function SavePurchaseOrderPrintDetaults() As Boolean

        'objects
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim IsNew As Boolean = False

        PurchaseOrderPrintDefault = GetPurchaseOrderPrintDefault()

        If PurchaseOrderPrintDefault Is Nothing Then

            PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
            IsNew = True

        End If

        FillPurchaseOrderPrintDefault(PurchaseOrderPrintDefault)

        SavePurchaseOrderPrintDetaults = SavePurchaseOrderPrintDetaults(PurchaseOrderPrintDefault, IsNew)

    End Function
    Private Function SavePurchaseOrderPrintDetaults(ByVal PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault, ByVal IsNew As Boolean) As Boolean

        'objects
        Dim Saved As Boolean = False

        Try

            If PurchaseOrderPrintDefault IsNot Nothing Then

                If IsNew Then

                    Saved = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Insert(_DbContext, PurchaseOrderPrintDefault)

                Else

                    Saved = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Update(_DbContext, PurchaseOrderPrintDefault)

                End If

            End If

        Catch ex As Exception
            Saved = False
        Finally
            SavePurchaseOrderPrintDetaults = Saved
        End Try

    End Function
    Private Sub Print()

        SavePurchaseOrderPrintDetaults()

        PrintReport()

    End Sub
    Private Sub PrintReport()

        'objects
        Dim SelectedValue As String = Nothing

        SelectedValue = RadComboBoxReportFormat.SelectedValue

        If (From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports))
            Where Item.Code = SelectedValue
            Select Item).Any Then

            OutputXtraReport()

        Else

            OutputActiveReport()

        End If

    End Sub
    Private Sub OutputXtraReport()

        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim PdfExportOptions As DevExpress.XtraPrinting.PdfExportOptions = Nothing
        Dim ReportBytes As Byte() = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim FileName As String = Nothing

        Try

            CreateParameterDictionaryAndUpdatePOsForPrinting()

            FileName = "PURCHASE_ORDER_" & AdvantageFramework.StringUtilities.PadWithCharacter(_PONumber.ToString, 8, "0", True, False)

            XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, _ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

            MemoryStream = New System.IO.MemoryStream

            XtraReport.CreateDocument()

            XtraReport.ExportToPdf(MemoryStream)

            System.Web.HttpContext.Current.Response.Clear()

            System.Web.HttpContext.Current.Response.Buffer = True
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/pdf")
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".pdf")
            System.Web.HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray)

            HttpContext.Current.ApplicationInstance.CompleteRequest()

            Try

                System.Web.HttpContext.Current.Response.End()

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        'objects
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        SavePurchaseOrderPrintDetaults()

        Try

            If Me.RadComboBoxLocation.SelectedItem.Text = "[None]" Then

                Session("POPrintLocationPath") = ""
                Session("POPrintLocationID") = "None"
                Session("POPrintLocationName") = ""

            Else

                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(_DataContext, RadComboBoxLocation.SelectedValue)

                Session("POPrintLocationID") = Location.ID
                Session("POPrintLocationPath") = Location.LogoPath
                Session("POPrintLocationName") = Location.Name

            End If

        Catch ex As Exception
            Session("POPrintLocationPath") = ""
        End Try

        If Me.RadDatePickerPODateToPrint.Enabled = True Then

            Session("POPrintDate") = Me.RadDatePickerPODateToPrint.SelectedDate

        Else

            Session("POPrintDate") = ""

        End If

        Dim EmailSwitch As String = ""

        If AsEmail = True Then

            EmailSwitch = "eml=1&"

        Else

            EmailSwitch = "eml=0&"

        End If

        Dim strURL As String = String.Empty

        If IsAssignment = True Then 'assignment switch overrides email switch

            Session("POPrint") = _PONumber
            Session("POPrintOptions") = Me.ReturnPrintOptionString.Trim
            Session("POPrintReport") = Me.RadComboBoxReportFormat.SelectedValue.Trim

            EmailSwitch = "eml=0&assn=1&"
            strURL = "Desktop_NewAssignment?" & EmailSwitch & "send=1&caller=PurchaseOrderPrint&calledfrom=custom&alert_funct=email_po&ref_id=" &
                     _PONumber.ToString & "&auto=no&pagetype=po&options=" & Me.ReturnPrintOptionString.Trim & "&Report=" &
                     Me.RadComboBoxReportFormat.SelectedValue.Trim & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.PurchaseOrder)

            Me.OpenWindow("New Alert", strURL)

        Else

            strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=poprintoptions&calledfrom=custom&alert_funct=email_po&ref_id=" &
                _PONumber.ToString & "&auto=no&pagetype=po&options=" & Me.ReturnPrintOptionString.Trim & "&Report=" &
                Me.RadComboBoxReportFormat.SelectedValue.Trim & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.PurchaseOrder)
            Me.OpenWindow("New Alert", strURL)

        End If


    End Sub
    Private Function ReturnPrintOptionString() As String

        'objects
        Dim PrintOptionString As String() = {}
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

        PurchaseOrderPrintDefault = GetPurchaseOrderPrintDefault()

        If PurchaseOrderPrintDefault Is Nothing Then

            PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault

        End If

        If PurchaseOrderPrintDefault IsNot Nothing Then

            FillPurchaseOrderPrintDefault(PurchaseOrderPrintDefault)

            PrintOptionString = {PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.UseLocationName.GetValueOrDefault(0),
                                 PurchaseOrderPrintDefault.UseClientName.GetValueOrDefault(0)}

        End If

        Return [String].Join(";", PrintOptionString)

    End Function
    Private Sub LoadLocationInformation()

        'objects
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        If Not [String].IsNullOrWhiteSpace(RadComboBoxLocation.SelectedValue) Then

            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(_DataContext, RadComboBoxLocation.SelectedValue)

        End If

        Session("LocationOverride") = Newtonsoft.Json.JsonConvert.SerializeObject(Location)

        If Location IsNot Nothing Then

            RadButtonOverrideLocation.Visible = True

        Else

            RadButtonOverrideLocation.Visible = False

        End If

    End Sub
    Private Sub OutputActiveReport()

        'objects
        Dim Report As Webvantage.cReports = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim ScriptStringBuilder As System.Text.StringBuilder = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        Report = New Webvantage.cReports(_Session.ConnectionString)

        StringBuilder = New Text.StringBuilder

        With StringBuilder

            .Append("popReportViewer.aspx?UserID=")
            .Append(_Session.UserCode)
            .Append("&ponumber=")
            .Append(_PONumber)
            .Append("&Type=")
            .Append("1")
            .Append("&Report=")
            .Append(RadComboBoxReportFormat.SelectedValue.Trim)
            .Append("&options=")
            .Append(Me.ReturnPrintOptionString.Trim)

        End With


        If Not [String].IsNullOrWhiteSpace(RadComboBoxLocation.SelectedValue) AndAlso RadComboBoxLocation.SelectedValue <> "[None]" Then

            StringBuilder.Append("&loc=" & RadComboBoxLocation.SelectedValue)

            If Session("LocationOverride") IsNot Nothing Then

                Location = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Database.Entities.Location)(Session("LocationOverride"))

            End If

            If Location IsNot Nothing Then

                Session("POPrintLocationPath") = Location.LogoPath
                Session("POPrintLocationID") = Location.ID
                Session("POPrintLocationName") = Location.Name

            End If

        Else

            Session("POPrintLocationPath") = ""
            Session("POPrintLocationID") = "None"
            Session("POPrintLocationName") = ""

        End If

        Session("POPrintDate") = ""

        If CheckBoxDateToPrint.Checked Then

            If RadDatePickerPODateToPrint.SelectedDate.HasValue Then

                Session("POPrintDate") = RadDatePickerPODateToPrint.SelectedDate

            Else

                Session("POPrintDate") = System.DateTime.Now

            End If

        End If

        ScriptStringBuilder = New Text.StringBuilder

        With ScriptStringBuilder

            .Append("<script type='text/javascript'>")
            .Append("window.open('" & StringBuilder.ToString() & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no');")
            .Append("</script>")

        End With

        SetPOPrinted({_PONumber})

        Page.RegisterStartupScript("POPRINT", ScriptStringBuilder.ToString())

    End Sub
    Private Sub EnableOrDisableActions()

        CheckBoxUseUserSignature.Enabled = Not CheckboxExcludeEmployeeSignature.Checked

        If Not CheckBoxUseUserSignature.Enabled Then

            CheckBoxUseUserSignature.Checked = False

        End If

    End Sub

#Region " Page Events "

    Private Sub PurchaseOrder_Print_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        _DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        QueryString = New AdvantageFramework.Web.QueryString

        Try

            If Not [String].IsNullOrWhiteSpace(QueryString.GetValue("po_number")) Then

                _PONumber = CInt(AdvantageFramework.Security.Encryption.DecryptPO(QueryString.GetValue("po_number")))

            End If

        Catch ex As Exception
            _PONumber = 0
        End Try

        _CallingPageMode = QueryString.GetValue("callingpagemode")
        _FromJJ = QueryString.GetValue("FromJJ")

    End Sub
    Protected Sub PurchaseOrder_Print_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

        If Not Page.IsPostBack Then

            If _PONumber > 0 Then

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(_DbContext, _PONumber)

                If PurchaseOrder IsNot Nothing Then

                    TextBoxPODisplayNumber.Text = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDisplayNumber(_DbContext, _PONumber)
                    TextBoxDescription.Text = PurchaseOrder.Description
                    TextBoxEmployeeCode.Text = PurchaseOrder.EmployeeCode
                    TextBoxEmployeeName.Text = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(_DbContext, PurchaseOrder.EmployeeCode).ToString
                    TextBoxVendorCode.Text = PurchaseOrder.VendorCode
                    TextBoxVendorName.Text = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, PurchaseOrder.VendorCode).Name

                    If PurchaseOrder.Date.HasValue Then

                        LabelDateIssued.Text = PurchaseOrder.Date.Value.ToShortDateString

                    End If

                    If PurchaseOrder.DueDate.HasValue Then

                        LabelDueDate.Text = PurchaseOrder.DueDate.Value.ToShortDateString

                    End If

                    LabelPOTotal.Text = (From Item In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(_DbContext, PurchaseOrder.Number)
                                         Where Item.LineNumber > 0
                                         Select Item.ExtendedAmount).ToList.Sum(Function(Amt) Amt.GetValueOrDefault(0)).ToString("c2")

                    RadComboBoxLocation.DataSource = (From Item In AdvantageFramework.Database.Procedures.Location.Load(_DataContext)
                                                      Select [ID] = Item.ID,
                                                             [Name] = Item.ID & " - " & Item.Name).ToList
                    RadComboBoxLocation.DataBind()
                    RadComboBoxLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", "[None]"))

                End If

            End If

            LabelCallingPageMode.Text = _CallingPageMode

            Try

                RadComboBoxReportFormat.DataSource = (From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports))
                                                      Select [Code] = Item.Code,
                                                             [Description] = Item.Description
                                                      Order By Description).ToList
                RadComboBoxReportFormat.DataBind()

                RadComboBoxReportFormat.Items(0).Selected = True

                RadComboBoxReportFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem("300 – Purchase Order with Client Name", "purchaseorderRR"))
                RadComboBoxReportFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem("301 – Purchase Order with Client Name v2", "purchaseorder3"))

            Catch ex As Exception

            End Try

            Try

                LoadPrintOptions()

            Catch ex As Exception

            End Try

            RadDatePickerPODateToPrint.SelectedDate = cEmployee.TimeZoneToday

            'PopulatePickLists()
            'RetrieveSettings()

            EnableOrDisableActions()

        End If

        If Me.IsClientPortal = True Then

            Me.RadToolBarPOPrintOptions.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode

            Case PageMode.Print

                Me.Print()
                Me.CloseThisWindow()

            Case PageMode.SendAlert

                Me.SendAlert()

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendAssignment

                Me.SendAlert(False, True)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendEmail

                Me.SendAlert(True, False)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case Else

        End Select
    End Sub
    Private Sub PurchaseOrder_Print_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            _DataContext.Dispose()

            _DataContext = Nothing

        Catch ex As Exception

        End Try

        Try

            _DbContext.Dispose()

            _DbContext = Nothing

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadToolBarPOPrintOptions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPOPrintOptions.ButtonClick

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        Select Case e.Item.Value

            Case "Print"

                Me.Print()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Save"

                If SavePurchaseOrderPrintDetaults() = True Then

                    LoadPrintOptions()

                End If

            Case "Back"

                If Request.QueryString("from") = "search" Then

                    Server.Transfer("purchaseorderlist.aspx")

                Else

                    StringBuilder = New Text.StringBuilder

                    With StringBuilder

                        .Append("purchaseorder.aspx?po_number=")
                        .Append(AdvantageFramework.Security.Encryption.EncryptPO(_PONumber))
                        .Append("&pagemode=")
                        .Append(LabelCallingPageMode.Text.Trim)

                        If Request.QueryString("Fromjj") = "jjpo" Then

                            .Append("&Fromjj=jjpo")

                        End If

                    End With

                    Server.Transfer(StringBuilder.ToString())

                    StringBuilder = Nothing

                End If

        End Select

    End Sub
    Private Sub RadComboBoxLocation_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLocation.SelectedIndexChanged

        LoadLocationInformation()

    End Sub
    Private Sub CheckboxExcludeEmployeeSignature_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxExcludeEmployeeSignature.CheckedChanged

        EnableOrDisableActions()

    End Sub

    Private Sub RadComboBoxReportFormat_ItemChecked(sender As Object, e As RadComboBoxItemEventArgs) Handles RadComboBoxReportFormat.ItemChecked

    End Sub

    Private Sub RadComboBoxReportFormat_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReportFormat.SelectedIndexChanged
        If RadComboBoxReportFormat.SelectedValue = "purchaseorderRR" Or RadComboBoxReportFormat.SelectedValue = "purchaseorder3" Then

            'Me.CheckBoxUseLocationName.Checked = False
            'Me.CheckBoxUseLocationName.Enabled = False
            'Me.CheckBoxUseClientName.Checked = False
            'Me.CheckBoxUseClientName.Enabled = False

        Else

            Me.CheckBoxUseLocationName.Enabled = True
            Me.CheckBoxUseClientName.Enabled = True

            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

            PurchaseOrderPrintDefault = GetPurchaseOrderPrintDefault()

            If PurchaseOrderPrintDefault IsNot Nothing Then

                CheckBoxUseLocationName.Checked = CBool(PurchaseOrderPrintDefault.UseLocationName.GetValueOrDefault(0))
                CheckBoxUseClientName.Checked = CBool(PurchaseOrderPrintDefault.UseClientName.GetValueOrDefault(0))

            End If


        End If
    End Sub

    Private Sub CheckBoxUseClientName_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUseClientName.CheckedChanged
        If CheckBoxUseClientName.Checked Then
            CheckBoxUseLocationName.Checked = False
        End If
    End Sub

    Private Sub CheckBoxUseLocationName_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUseLocationName.CheckedChanged
        If CheckBoxUseLocationName.Checked Then
            CheckBoxUseClientName.Checked = False
        End If
    End Sub

    'Private Sub RadButtonOverrideLocation_Click(sender As Object, e As EventArgs) Handles RadButtonOverrideLocation.Click
    '    Try

    '        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

    '        QueryString = New AdvantageFramework.Web.QueryString()

    '        QueryString.Page = "LocationOverride.aspx"

    '        Me.OpenWindow(QueryString, "", 0, 0, False, True)

    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#End Region

End Class
