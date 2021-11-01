Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class ARStatements
    Inherits Webvantage.BaseChildPage

    Private StrSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;"
    Private StrOfficeList As String = ""
    Private StrAEList As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_Reports_ARStatementsRTP)
        Try
            If Not Me.IsPostBack Then
                LoadLookupsAndDefaults()
                'Me.RadGridARClient.PageSize = 250
                SetARType()
                ClearTempFolder()
                LoadSettings()
                btnSubmit.Attributes("onclick") = "return confirm('Warning! All selected statements on the current page will be processed.  Are you sure you would like to proceed?')"
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

#Region " Controls"

    Private Sub ddARType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddARType.SelectedIndexChanged
        'Clear message label:
        Me.lblSummary.Text = ""
        SetARType()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Try
                If Me.LbOffices.SelectedIndex = -1 Then
                    Me.LbOffices.SelectedIndex = 0
                End If
            Catch ex As Exception
            End Try
            'Clear message label:
            Me.lblSummary.Text = ""
            'Instantiate some controls for setting to Grid controls:
            Dim ChkEmail As CheckBox
            Dim ChkPrint As CheckBox
            Dim ChkOnAccount As CheckBox
            Dim DropUseAddress As Telerik.Web.UI.RadComboBox
            Dim StrAgingDate As String = String.Empty

            'Validate and set date:
            If MiscFN.ValidDate(Me.RadDatePickerAgingDate) = False Then
                Me.ShowMessage("Please enter a valid aging date.")
                Exit Sub
            Else
                StrAgingDate = CType(Me.RadDatePickerAgingDate.SelectedDate, Date).ToShortDateString()
            End If

            SaveSettings()

            'Variables:
            Dim str As String
            Dim ThisARType As cReports.ARStatementsType
            Dim StrARType As String = String.Empty
            Dim StrDataKey As String = String.Empty
            Dim StrClientCode As String = String.Empty
            Dim StrDivisionCode As String = String.Empty
            Dim StrProductCode As String = String.Empty
            Dim StrContactCode As String = String.Empty
            Dim StrUseAddress As String = String.Empty
            Dim BoolEmail As Boolean = False
            Dim BoolPrint As Boolean = False
            Dim BoolOnAccount As Boolean = False
            Dim BoolForMessageEmail As Boolean = False
            Dim BoolForMessagePrint As Boolean = False
            Dim BoolForNoDataEmail As Boolean = False
            Dim BoolValidRecord As Boolean = False
            Dim StrPostPeriodCheck As String = String.Empty
            Dim StrPrintIDs As String = String.Empty
            Dim BoolCCReport As Boolean = Me.cbAddcc.Checked
            Dim agingtype As Integer = 1
            Dim strExclude As String = "0"

            Dim OverthirtySixty As Boolean = False
            Dim OverSixty As Boolean = False

            If Me.RadButtonInvoiceDate.Checked = True Then
                agingtype = 1
            End If
            If Me.RadButtonDueDate.Checked = True Then
                agingtype = 2
            End If

            If CheckboxExcludeDescription.Checked Then
                strExclude = "1"
            End If

            'Set AR Type
            If Me.ddARType.SelectedValue = "client" Then
                ThisARType = cReports.ARStatementsType.Client
            ElseIf Me.ddARType.SelectedValue = "product" Then
                ThisARType = cReports.ARStatementsType.Product
            End If
            StrARType = Me.ddARType.SelectedValue.ToString

            'Objects:
            Dim oWebServices As cWebServices = New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

            'File name variables and setup:
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim Filename As String = ""
            Dim StrFileType As String = ""

            'Email variables and setup:
            Dim StrSubject As String = ""
            Dim StrBody As String = ""
            Dim StrCCMessage As String = ""
            Dim StrReport As String = StrARType & "arstatement00" & Me.ddCReportTemplate.SelectedItem.Value
            Dim StrImagePath As String = Request.PhysicalApplicationPath & "\Images\logo_print.gif"
            Dim StrEmailAddress As String = ""
            Dim StrPrimaryContact As String = ""
            'Dim StrPrimaryContactName As String = String.Empty


            'Report type setup:
            Dim DropReportType As Telerik.Web.UI.RadComboBox
            Try
                DropReportType = CType(Me.reporttype.FindControl("RadComboBoxReportType"), Telerik.Web.UI.RadComboBox)
                Select Case DropReportType.SelectedValue
                    Case "1"
                        StrFileType = ".pdf"
                    Case "2"
                        StrFileType = ".xls"
                    Case "4"
                        StrFileType = ".txt"
                    Case "5"
                        StrFileType = ".rtf"
                    Case "6"
                        StrFileType = ".tiff"
                    Case Else
                        StrFileType = ".pdf"
                End Select
            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try


            StrOfficeList = MiscFN.ListBoxToString(Me.LbOffices)

            Try
                'Main loop through the rows:
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridARClient.MasterTableView.Items
                    'Get datakey:
                    StrDataKey = gridDataItem.GetDataKeyValue("GridDataKey").ToString
                    'Set variables:
                    StrClientCode = GetClientCodeFromDataKey(StrDataKey, ThisARType)
                    StrContactCode = GetContactCodeFromDataKey(StrDataKey, ThisARType)
                    StrEmailAddress = GetEmailAddressFromDataKey(StrDataKey, ThisARType)
                    'StrPrimaryContactName = GetPrimaryContactNameFromDataKey(StrDataKey, ThisARType)

                    If ThisARType = cReports.ARStatementsType.Product Then
                        StrDivisionCode = GetDivisionCodeFromDataKey(StrDataKey, cReports.ARStatementsType.Product)
                        StrProductCode = GetProductCodeFromDataKey(StrDataKey, cReports.ARStatementsType.Product)
                    End If

                    BoolOnAccount = CType(gridDataItem("colChkOnAcctClient").Controls(1), CheckBox).Checked
                    'BoolCCReport = CType(gridDataItem("colChkCC").Controls(1), CheckBox).Checked
                    StrUseAddress = CType(gridDataItem("colDropAddressClient").Controls(1), Telerik.Web.UI.RadComboBox).SelectedValue
                    StrPrimaryContact = gridDataItem("colContactClient").Text

                    If ThisARType = cReports.ARStatementsType.Client Then

                        StrPostPeriodCheck = StrClientCode & "," & StrContactCode & "," & MiscFN.BoolToInt(BoolOnAccount).ToString() & "," & StrUseAddress & ",1"
                        BoolValidRecord = oReports.CheckForRecordPostPeriod(StrPostPeriodCheck, Me.ddPostingPeriod.SelectedValue, Me.ddLocation.SelectedValue, StrAgingDate, "C")
                        Filename = StrFilePrefix & "AR_STATEMENT_" & StrClientCode.ToUpper() & StrFileType

                    ElseIf ThisARType = cReports.ARStatementsType.Product Then

                        StrPostPeriodCheck = StrClientCode & "," & StrDivisionCode & "," & StrProductCode & "," & StrContactCode & "," & MiscFN.BoolToInt(BoolOnAccount).ToString() & "," & StrUseAddress & ",1"
                        BoolValidRecord = oReports.CheckForRecordPostPeriod(StrPostPeriodCheck, Me.ddPostingPeriod.SelectedValue, Me.ddLocation.SelectedValue, StrAgingDate, "P")
                        Filename = StrFilePrefix & "AR_STATEMENT_" & StrProductCode.ToUpper() & StrFileType

                    End If

                    StrSubject = Me.txtCSubject.Text
                    StrBody = Me.txtCBody.Text
                    StrCCMessage = Me.txtCCopyEmail.Text

                    ChkEmail = CType(gridDataItem("colChkEmailClient").Controls(1), CheckBox)
                    If ChkEmail.Checked = True And BoolValidRecord = True Then


                        'Build report:
                        Dim rpt As New Webvantage.popReportViewer
                        Dim StrEmailID As String = String.Empty
                        If ThisARType = cReports.ARStatementsType.Client Then
                            StrEmailID = StrClientCode & "," & StrContactCode & "," & MiscFN.BoolToInt(BoolOnAccount).ToString() & "," & StrUseAddress & ",1"
                        ElseIf ThisARType = cReports.ARStatementsType.Product Then
                            StrEmailID = StrClientCode & "," & StrDivisionCode & "," & StrProductCode & "," & StrContactCode & "," & MiscFN.BoolToInt(BoolOnAccount).ToString() & "," & StrUseAddress & ",1"
                        End If
                        Try
                            Dim err As String = ""

                            If rpt.renderDoc(Filename, StrReport, StrEmailID, Me.ddPostingPeriod.SelectedValue.ToString(),
                                          Me.ddLocation.SelectedValue.ToString(), StrAgingDate, oReports.GetAgencyFooter(Me.ddLocation.SelectedValue.ToString()),
                                          DropReportType.SelectedValue, StrImagePath, Me.RblPrintHeaderFooter.SelectedValue, Me.StrOfficeList, err, agingtype, strExclude) = False Then

                                If err.Trim() <> "" Then

                                    Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(err))
                                    Exit Sub

                                End If
                            End If

                        Catch ex As Exception

                            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
                            Exit Sub

                        End Try

                        'Get list of contacts for CC:
                        Dim StrCCDisplayList As String = String.Empty
                        Dim StrCCEmailAddressList As String = String.Empty


                        'Add CC message to body if CC's exist:
                        Dim StrCCTestList As String = String.Empty

                        If BoolCCReport = True Then
                            StrCCDisplayList = GetCCListFromGrid(ThisARType, StrClientCode, StrDivisionCode, StrProductCode)
                        End If
                        Dim emp As New cEmployee(Session("ConnString"))
                        StrCCEmailAddressList = emp.GetEmail(Session("EmpCode"))
                        'Remove trailing comma:
                        StrCCDisplayList = MiscFN.RemoveTrailingDelimiter(StrCCDisplayList, ",")
                        StrCCEmailAddressList = MiscFN.RemoveTrailingDelimiter(StrCCEmailAddressList, ",")

                        If BoolCCReport = True And StrCCDisplayList.Length > 0 Then
                            StrBody &= vbCrLf & vbCrLf & vbCrLf & StrCCMessage & vbCrLf
                            Dim arDisplay() As String = StrCCDisplayList.Split(CType(",", Char))
                            For j As Integer = 0 To arDisplay.Length - 1
                                StrBody &= arDisplay(j).ToString() & vbCrLf
                            Next
                        Else
                            StrCCEmailAddressList = ""
                        End If
                        'Check for no data
                        Dim dt As DataTable
                        If ThisARType = cReports.ARStatementsType.Client Then
                            dt = oReports.GetARClientStatement(StrEmailID, Me.ddPostingPeriod.SelectedValue.ToString(), Me.ddLocation.SelectedValue.ToString(), StrAgingDate, oReports.GetAgencyFooter(Me.ddLocation.SelectedValue.ToString()), If(ddCReportTemplate.SelectedValue = "5", "1", ddCReportTemplate.SelectedValue), Me.StrOfficeList, agingtype)
                        ElseIf ThisARType = cReports.ARStatementsType.Product Then
                            dt = oReports.GetARProductStatement(StrEmailID, Me.ddPostingPeriod.SelectedValue.ToString(), Me.ddLocation.SelectedValue.ToString(), StrAgingDate, oReports.GetAgencyFooter(Me.ddLocation.SelectedValue.ToString()), ddCReportTemplate.SelectedValue, Me.StrOfficeList, agingtype)
                        End If
                        'Send report to primary contact:
                        If AdvantageFramework.Email.IsValidEmailAddress(StrEmailAddress) = True And dt.Rows.Count <> 0 Then
                            Dim bool As Boolean = False
                            If Me.RadButtonThirtyPlus.Checked Then
                                If CDec(dt.Rows(0)("OverThirtyAR")) > 0 Or CDec(dt.Rows(0)("OverSixtyAR")) > 0 Then
                                    bool = oWebServices.SendEmail(Filename, StrEmailAddress, StrSubject, StrBody, StrCCEmailAddressList)
                                    OverthirtySixty = True
                                End If
                            ElseIf Me.RadButtonSixtyPlus.Checked = True Then
                                If CDec(dt.Rows(0)("OverSixtyAR")) > 0 Then
                                    bool = oWebServices.SendEmail(Filename, StrEmailAddress, StrSubject, StrBody, StrCCEmailAddressList)
                                    OverSixty = True
                                End If
                            Else
                                bool = oWebServices.SendEmail(Filename, StrEmailAddress, StrSubject, StrBody, StrCCEmailAddressList)
                            End If
                            'If bool = False Then
                            '    Me.ShowMessage(oWebServices.getErrMsg)
                            'End If
                            If bool = True Then
                                If ThisARType = cReports.ARStatementsType.Client Then
                                    oReports.UpdateClientEmail(StrClientCode, StrContactCode)
                                Else
                                    oReports.UpdateProductEmail(StrClientCode, StrDivisionCode, StrProductCode, StrContactCode)
                                End If
                            End If

                            lblSummary.Text &= "File:  " & Filename & "<br />" & StrPrimaryContact '& "<br />" & StrCCTestList
                            BoolForMessageEmail = True
                        Else
                            BoolForNoDataEmail = True
                        End If

                        'Summary Label for testing:
                        lblSummary.Text &= "<hr />"

                        'Clear variables:
                        StrCCDisplayList = ""
                        StrCCEmailAddressList = ""
                        StrSubject = ""
                        StrBody = ""
                        StrCCMessage = ""
                        Filename = ""

                    End If 'Ending If for if the email checkbox is checked and valid record

                    'BEGIN PRINT CHECKED CODE ===============================
                    ChkPrint = CType(gridDataItem("colChkPrintClient").Controls(1), CheckBox)
                    If ChkPrint.Checked = True And BoolValidRecord = True Then
                        'Concatenate string to use for the merged report:
                        'Check for no data
                        Dim dt As DataTable
                        If ThisARType = cReports.ARStatementsType.Client Then
                            dt = oReports.GetARClientStatement(StrPostPeriodCheck, Me.ddPostingPeriod.SelectedValue.ToString(), Me.ddLocation.SelectedValue.ToString(), StrAgingDate, oReports.GetAgencyFooter(Me.ddLocation.SelectedValue.ToString()), If(ddCReportTemplate.SelectedValue = "5", "1", ddCReportTemplate.SelectedValue), Me.StrOfficeList, agingtype)
                        ElseIf ThisARType = cReports.ARStatementsType.Product Then
                            dt = oReports.GetARProductStatement(StrPostPeriodCheck, Me.ddPostingPeriod.SelectedValue.ToString(), Me.ddLocation.SelectedValue.ToString(), StrAgingDate, oReports.GetAgencyFooter(Me.ddLocation.SelectedValue.ToString()), ddCReportTemplate.SelectedValue, Me.StrOfficeList, agingtype)
                        End If
                        If dt.Rows.Count <> 0 Then
                            If Me.RadButtonThirtyPlus.Checked Then
                                If CDec(dt.Rows(0)("OverThirtyAR")) > 0 Or CDec(dt.Rows(0)("OverSixtyAR")) > 0 Then
                                    StrPrintIDs &= StrPostPeriodCheck & ";"
                                    BoolPrint = True
                                End If
                            ElseIf Me.RadButtonSixtyPlus.Checked = True Then
                                If CDec(dt.Rows(0)("OverSixtyAR")) > 0 Then
                                    StrPrintIDs &= StrPostPeriodCheck & ";"
                                    BoolPrint = True
                                End If
                            Else
                                StrPrintIDs &= StrPostPeriodCheck & ";"
                                BoolPrint = True
                            End If

                            'Update the database record:
                            If BoolPrint = True Then
                                If ThisARType = cReports.ARStatementsType.Client Then
                                    oReports.UpdateClientPrint(StrClientCode, StrContactCode)
                                ElseIf ThisARType = cReports.ARStatementsType.Product Then
                                    oReports.UpdateProductPrint(StrClientCode, StrDivisionCode, StrProductCode, StrContactCode)
                                End If
                            End If
                            BoolPrint = False
                            'Set message label:
                            BoolForMessagePrint = True
                        End If

                    End If 'Ending If for if the Print checkbox is checked and valid record

                Next 'Main loop through the rows of the grid

                'Generate the merged report:
                If BoolForMessagePrint = True Then
                    StrPrintIDs = MiscFN.RemoveTrailingDelimiter(StrPrintIDs, ";")
                    Session("ARPrintIDs") = StrPrintIDs
                    Session("ARPrintOfficeCodes") = Me.StrOfficeList
                    ViewReport("ARPrint", Me.ddPostingPeriod.SelectedValue, Me.ddLocation.SelectedValue, StrAgingDate, True, StrReport, ThisARType)
                End If

                'If records were emailed or printed, rebind the grid:
                If BoolForMessageEmail = True Or BoolForMessagePrint = True Then
                    Me.RadGridARClient.Rebind()
                End If

                'Show message to user:
                ShowARMessage(BoolForMessageEmail, BoolForMessagePrint, BoolForNoDataEmail)

                Me.CheckForAsyncMessage()

                Me.SetARType()

            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub cbAddcc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAddcc.CheckedChanged
        'Try
        '    Dim cb As CheckBox
        '    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridARClient.MasterTableView.Items
        '        cb = CType(gridDataItem("colChkCC").Controls(1), CheckBox)
        '        cb.Checked = Me.cbAddcc.Checked
        '    Next
        'Catch ex As Exception
        '    Me.ShowMessage(ex.Message.ToString(), "Error setting CC checkbox:")
        'End Try
    End Sub

#End Region

#Region " Functions"

    Private Sub LoadLookupsAndDefaults()
        Try
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
            Dim oAccounting As cAccounting = New cAccounting(CStr(Session("ConnString")))
            Dim pp As String = oAccounting.GetCurrentPostingPeriod

            If pp = "" Then
                Me.ShowMessage("The current posting period is not set.")
            End If

            Me.ddPostingPeriod.DataSource = oAccounting.GetPostingPeriods
            Me.ddPostingPeriod.DataTextField = "PPPERIOD"
            Me.ddPostingPeriod.DataValueField = "PPPERIOD"
            If pp <> "" Then
                Me.ddPostingPeriod.SelectedValue = oAccounting.GetCurrentPostingPeriod
            Else
                'Me.ddPostingPeriod.SelectedValue = oAccounting.GetPostingPeriodMax
            End If
            Me.ddPostingPeriod.DataBind()

            Me.ddLocation.DataSource = oReports.GetLocation
            Me.ddLocation.DataTextField = "DESCRIPTION"
            Me.ddLocation.DataValueField = "ID"
            Me.ddLocation.DataBind()
            Me.ddLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))

            'Set Aging Date to current date.
            Me.RadDatePickerAgingDate.SelectedDate = cEmployee.TimeZoneToday

            'Initialize email objects.
            Dim strAgencyName As String = oReports.GetAgencyName
            Me.txtCBody.Text = "Your current A/R Statement is attached in PDF format."
            Me.txtCCopyEmail.Text = "The following contacts received this statement."
            Me.txtCSubject.Text = strAgencyName & " : A/R Statement"

            Me.LoadOfficeListBox()
            Me.LoadAccountExecutives()

            Try
                If Not Me.IsPostBack And Not Me.IsCallback Then
                    Me.LbOffices.SelectedIndex = 0
                    Me.RadListBoxAccountExecutive.SelectedIndex = 0
                End If
            Catch ex As Exception
            End Try


        Catch ex As Exception
            Me.ShowMessage("No Records Found")
        End Try
    End Sub

    Private Sub LoadOfficeListBox()
        Dim dd As New cDropDowns(Session("ConnString"))
        With Me.LbOffices
            .DataSource = dd.GetOfficesEmp(Session("UserCode"))
            .DataTextField = "Description"
            .DataValueField = "Code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Offices", "%"))
        End With
    End Sub

    Private Sub LoadAccountExecutives()

        'objects
        Dim AccountExecutives As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
        Dim AccessibleEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing
        Dim UserCDPAccessList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ' AccessibleEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode).ToList

                UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList
                UserCDPAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, _Session.UserCode).ToList
                AccountExecutives = AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").Include("Product").ToList.Where(Function(Entity) Entity.Employee.TerminationDate Is Nothing).ToList

                If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

                    AccountExecutives = (From Entity In AccountExecutives
                                         Where UserOfficeAccessList.Contains(Entity.Product.OfficeCode) = True
                                         Select Entity).ToList

                End If

                If UserCDPAccessList IsNot Nothing AndAlso UserCDPAccessList.Count > 0 Then

                    AccountExecutives = (From Entity In AccountExecutives
                                         Join CDP In UserCDPAccessList On CDP.ClientCode Equals Entity.ClientCode And CDP.DivisionCode Equals Entity.DivisionCode And CDP.ProductCode Equals Entity.ProductCode
                                         Select Entity).ToList

                End If

                RadListBoxAccountExecutive.DataSource = (From Entity In AccountExecutives
                                                         Select [Code] = Entity.Employee.Code,
                                                                 [Name] = Entity.Employee.ToString
                                                         Distinct).ToList.OrderBy(Function(AE) AE.Name).ToList
                RadListBoxAccountExecutive.DataTextField = "Name"
                RadListBoxAccountExecutive.DataValueField = "Code"
                RadListBoxAccountExecutive.DataBind()

                RadListBoxAccountExecutive.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Account Executives", "%"))
            End Using

        End Using

    End Sub

    Private Sub SetARType()
        Try
            Me.cbAddcc.Checked = False
            Me.lblSummary.Text = ""
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
            StrOfficeList = MiscFN.ListBoxToString(Me.LbOffices)

            If Me.ddARType.SelectedValue = "client" Then
                'Me.lblEmailHeader.Text = "Client Email Options"
                'Me.CollapsablePanelEmailOptions.TitleText = StrSpacer & "Client&nbsp;Email&nbsp;Options"
                'Me.CollapsablePanelGrid.TitleText = StrSpacer & "Client&nbsp;Recipients"
                Me.PageTitle = "Client&nbsp;AR&nbsp;Statements"

                Dim ColDescript As Telerik.Web.UI.GridBoundColumn
                ColDescript = Me.RadGridARClient.MasterTableView.Columns.FindByUniqueName("colClient")
                ColDescript.HeaderText = "Client Name (code)"

                With Me.RadGridARClient
                    '.Skin = MiscFN.SetRadGridSkin
                    .Visible = True
                    .DataSource = oReports.GetARStatements(cReports.ARStatementsType.Client, Session("UserCode"), StrOfficeList)
                    .DataBind()
                End With

                If Me.ddCReportTemplate.Items.Count = 4 Then
                    Me.ddCReportTemplate.Items.Add(New Telerik.Web.UI.RadComboBoxItem("005 Reference Product", "5"))
                End If

            ElseIf Me.ddARType.SelectedValue = "product" Then
                'Me.lblEmailHeader.Text = "Client Email Options"
                'Me.CollapsablePanelEmailOptions.TitleText = StrSpacer & "Product&nbsp;Email&nbsp;Options"
                'Me.CollapsablePanelGrid.TitleText = StrSpacer & "Product Recipients"
                Me.PageTitle = "Product&nbsp;AR&nbsp;Statements"

                Dim ColDescript As Telerik.Web.UI.GridBoundColumn
                ColDescript = Me.RadGridARClient.MasterTableView.Columns.FindByUniqueName("colClient")
                ColDescript.HeaderText = "Product Description (c/d/p)"

                With Me.RadGridARClient
                    '.Skin = MiscFN.SetRadGridSkin
                    .Visible = True
                    .DataSource = oReports.GetARStatements(cReports.ARStatementsType.Product, Session("UserCode"), StrOfficeList)
                    .DataBind()
                End With
                Try
                    Me.ddCReportTemplate.Items.Remove(4)
                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub ViewReport(ByVal ID As String,
                    ByVal PostPeriod As String,
                    ByVal Location As String,
                    ByVal AgedDate As String,
                    ByVal PDF As Boolean,
                    ByVal Report As String, ByVal ARType As cReports.ARStatementsType)
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

        Me.StrOfficeList = MiscFN.ListBoxToString(Me.LbOffices)
        Session("ARPrintOfficeCodes") = Me.StrOfficeList

        Dim ddl As Telerik.Web.UI.RadComboBox
        ddl = reporttype.FindControl("RadComboBoxReportType")
        Dim strURL As String
        Dim agingtype As Integer = 1
        Dim printamount As Integer = 0
        Dim exclude As Integer = 0

        If Me.RadButtonInvoiceDate.Checked = True Then
            agingtype = 1
        End If
        If Me.RadButtonDueDate.Checked = True Then
            agingtype = 2
        End If

        If RadButtonThirtyPlus.Checked Then
            printamount = 30
        End If
        If RadButtonSixtyPlus.Checked Then
            printamount = 60
        End If
        If CheckboxExcludeDescription.Checked Then
            exclude = 1
        End If

        If ARType = cReports.ARStatementsType.Client Then
            strURL = "popReportViewer.aspx?ID=" & ID & "&PP=" & PostPeriod & "&Loc=" & Location & "&AD=" & AgedDate & "&Type=" & ddl.SelectedValue & "&Report=clientarstatement00" & Me.ddCReportTemplate.SelectedItem.Value & "&c=" & Me.RblPrintHeaderFooter.SelectedValue & "&aging=" & agingtype & "&exclude=" & exclude
        ElseIf ARType = cReports.ARStatementsType.Product Then
            strURL = "popReportViewer.aspx?ID=" & ID & "&PP=" & PostPeriod & "&Loc=" & Location & "&AD=" & AgedDate & "&Type=" & ddl.SelectedValue & "&Report=productarstatement00" & Me.ddCReportTemplate.SelectedItem.Value & "&c=" & Me.RblPrintHeaderFooter.SelectedValue & "&aging=" & agingtype & "&exclude=" & exclude
        End If

        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        With strBuilder
            .Append("<script language='javascript'>")
            .Append("window.open('" & strURL & "', '', 'scrollbars=yes,resizable=yes,menubar=yes,maximazable=yes,width=100,height=100')")
            .Append("</")
            .Append("script>")
        End With

        'Dim dt As DataTable

        'If ddARType.SelectedValue = "product" And ID <> "ARPrint" Then

        '    If Me.ddCReportTemplate.SelectedValue = 1 Then
        '        dt = oReports.GetARProductStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "1", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 2 Then
        '        dt = oReports.GetARProductStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "2", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 3 Then
        '        dt = oReports.GetARProductStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "3", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 4 Then
        '        dt = oReports.GetARProductStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "4", StrOfficeList, agingtype)
        '    End If

        'ElseIf ddARType.SelectedValue = "client" And ID <> "ARPrint" Then

        '    If Me.ddCReportTemplate.SelectedValue = 1 Then
        '        dt = oReports.GetARClientStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "1", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 2 Then
        '        dt = oReports.GetARClientStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "2", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 3 Then
        '        dt = oReports.GetARClientStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "3", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 4 Then
        '        dt = oReports.GetARClientStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "4", StrOfficeList, agingtype)
        '    ElseIf Me.ddCReportTemplate.SelectedValue = 5 Then
        '        dt = oReports.GetARClientStatement(ID, PostPeriod, Location, AgedDate, oReports.GetAgencyFooter(Request.QueryString("Loc")), "1", StrOfficeList, agingtype)
        '    End If

        'End If

        'If dt IsNot Nothing AndAlso dt.Rows.Count = 0 Then
        '    Me.ShowMessage("No Data for Selected Inputs.")
        '    Exit Sub
        'Else
        '    Response.Redirect(strURL)
        'End If
        ScriptManager.RegisterStartupScript(Page, Me.GetType, "ReportPage", strBuilder.ToString(), False)
        'Me.Page.ClientScript.RegisterStartupScript(Me.GetType, "ReportPage", strBuilder.ToString())

    End Sub

    Private Sub ShowARMessage(ByVal HadEmailsSent As Boolean, ByVal HadPrintedReports As Boolean, ByVal HadNoData As Boolean)
        Dim str As String = "All selected statements on the current page have been "
        If HadEmailsSent = True And HadPrintedReports = True Then
            str &= "emailed and printed!"
        ElseIf HadEmailsSent = True And HadPrintedReports = False Then
            str &= "emailed!"
        ElseIf HadEmailsSent = False And HadPrintedReports = True Then
            If HadNoData = True Then
                str &= "printed!  No Data for Selected Email Statements."
            Else
                str &= "printed!"
            End If
        ElseIf HadEmailsSent = False And HadPrintedReports = False Then
            If HadNoData = True Then
                str = "No Data for Selected Inputs."
            Else
                str = "No statements have been selected on the current page for emailing or printing!"
            End If
        End If
        Me.ShowMessage(str)
    End Sub

    Private Sub ClearTempFolder()
        Try
            Dim s As String
            Dim p As String = Request.PhysicalApplicationPath & "TEMP"
            For Each s In System.IO.Directory.GetFiles(p)
                If InStr(s, "PPeriod") > 0 Then
                    System.IO.File.Delete(s)
                End If
            Next
        Catch ex As Exception
            'Me.ShowMessage(ex.Message.ToString(), "Error clearing temp directory.\nThis will not affect any functionality of the page.")
        End Try
    End Sub

    Private Sub SaveSettings()
        Try
            Dim AppVars As New cAppVars(cAppVars.Application.AR_STATEMENTS)
            AppVars.getAllAppVars()
            AppVars.setAppVar("LOCATION", Me.ddLocation.SelectedValue)
            AppVars.SaveAllAppVars()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadSettings()
        Try
            Dim AppVars As New cAppVars(cAppVars.Application.AR_STATEMENTS)
            AppVars.getAllAppVars()

            If AppVars.HasAppVar("LOCATION") = True Then

                Me.ddLocation.SelectedValue = AppVars.getAppVar("LOCATION").ToString

            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " Datakey Functions"

    'Client AR Datakey:  Client Code, Contact Code, Email Address, Primary Contact Name
    'Product AR Datakey: Client Code, Division Code, Product Code, Contact Code, Email Address, Primary Contact Name

    Private Function GetClientCodeFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
        Try
            Dim str() As String = TheKey.Split(CType("|", Char))

            If ARType = cReports.ARStatementsType.Client Then
                Return str(0).ToString
            ElseIf ARType = cReports.ARStatementsType.Product Then
                Return str(0).ToString
            End If
        Catch ex As Exception
            Me.ShowMessage("Error getting client code from datakey.")
        End Try
    End Function

    Private Function GetDivisionCodeFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
        Try
            Dim str() As String = TheKey.Split(CType("|", Char))

            If ARType = cReports.ARStatementsType.Client Then
                Return "N/A"
            ElseIf ARType = cReports.ARStatementsType.Product Then
                Return str(1).ToString
            End If
        Catch ex As Exception
            Me.ShowMessage("Error getting division code from datakey.")
        End Try
    End Function

    Private Function GetProductCodeFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
        Try
            Dim str() As String = TheKey.Split(CType("|", Char))

            If ARType = cReports.ARStatementsType.Client Then
                Return "N/A"
            ElseIf ARType = cReports.ARStatementsType.Product Then
                Return str(2).ToString
            End If
        Catch ex As Exception
            Me.ShowMessage("Error getting product code from datakey.")
        End Try
    End Function

    Private Function GetContactCodeFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
        Try
            Dim str() As String = TheKey.Split(CType("|", Char))

            If ARType = cReports.ARStatementsType.Client Then
                Return str(1).ToString
            ElseIf ARType = cReports.ARStatementsType.Product Then
                Return str(3).ToString
            End If
        Catch ex As Exception
            Me.ShowMessage("Error getting contact code from datakey.")
        End Try
    End Function

    Private Function GetEmailAddressFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
        Try
            Dim str() As String = TheKey.Split(CType("|", Char))

            If ARType = cReports.ARStatementsType.Client Then
                Return str(2).ToString
            ElseIf ARType = cReports.ARStatementsType.Product Then
                Return str(4).ToString
            End If
        Catch ex As Exception
            Me.ShowMessage("Error getting email address from datakey.")
        End Try
    End Function

    'Private Function GetPrimaryContactNameFromDataKey(ByVal TheKey As String, ByVal ARType As Webvantage.cReports.ARStatementsType) As String
    '    Try
    '        Dim str() As String = TheKey.Split(CType("|", Char))

    '        If ARType = cReports.ARStatementsType.Client Then
    '            Return str(3).ToString
    '        ElseIf ARType = cReports.ARStatementsType.Product Then
    '            Return str(5).ToString
    '        End If
    '    Catch ex As Exception
    '        Me.ShowMessage("Error getting email address from datakey.")
    '    End Try
    'End Function


#End Region

#Region " RadGrid"
    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridARClient_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridARClient.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim strAgingDate As String
            Dim ThisARType As cReports.ARStatementsType

            If MiscFN.ValidDate(Me.RadDatePickerAgingDate) = False Then
                Me.ShowMessage("Please enter a valid aging date.")
                Exit Sub
            Else
                strAgingDate = CType(Me.RadDatePickerAgingDate.SelectedDate, Date).ToShortDateString()
            End If

            If Me.ddARType.SelectedValue = "client" Then
                ThisARType = cReports.ARStatementsType.Client
            ElseIf Me.ddARType.SelectedValue = "product" Then
                ThisARType = cReports.ARStatementsType.Product
            End If

            If e.CommandName = "ViewReport" Then
                Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

                Dim strDataKey As String = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("GridDataKey")
                Dim ClientCode As String = GetClientCodeFromDataKey(strDataKey, ThisARType)
                Dim ContactCode As String = GetContactCodeFromDataKey(strDataKey, ThisARType)

                Dim DivisionCode As String = String.Empty
                Dim ProductCode As String = String.Empty

                If ThisARType = cReports.ARStatementsType.Product Then
                    DivisionCode = GetDivisionCodeFromDataKey(strDataKey, cReports.ARStatementsType.Product)
                    ProductCode = GetProductCodeFromDataKey(strDataKey, cReports.ARStatementsType.Product)
                End If

                Dim IncludeOnAccount As String
                If CType(e.Item.FindControl("chkOnAcctClient"), CheckBox).Checked = True Then
                    IncludeOnAccount = "1"
                Else
                    IncludeOnAccount = "0"
                End If

                Dim UseAddress As String = CType(e.Item.FindControl("ddCUseAddressClient"), Telerik.Web.UI.RadComboBox).SelectedValue.ToString

                Dim Template As String = "1"

                Dim ckid As String = String.Empty
                Dim PostPeriodType As String = String.Empty

                If ThisARType = cReports.ARStatementsType.Client Then
                    ckid = ClientCode & "," & ContactCode & "," & IncludeOnAccount & "," & UseAddress & "," & Template
                    PostPeriodType = "C"
                ElseIf ThisARType = cReports.ARStatementsType.Product Then
                    ckid = ClientCode & "," & DivisionCode & "," & ProductCode & "," & ContactCode & "," & IncludeOnAccount & "," & UseAddress & "," & Template
                    PostPeriodType = "P"
                End If

                SaveSettings()

                Dim strReport As String
                If oReports.CheckForRecordPostPeriod(ckid, Me.ddPostingPeriod.SelectedValue, Me.ddLocation.SelectedValue, strAgingDate, PostPeriodType) Then
                    strReport = "?/Reports/" & Me.ddARType.SelectedValue.ToString() & "arstatement00" & Me.ddCReportTemplate.SelectedItem.Value
                    ViewReport(ckid, Me.ddPostingPeriod.SelectedValue, Me.ddLocation.SelectedValue, strAgingDate, False, strReport, ThisARType)
                    'Else
                    '    'Me.ShowMessage(Me.ddPostingPeriod.SelectedValue, "No Record for this Posting Period:")
                    '    Me.ShowMessage("", "No Records Found")
                End If

            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub RadGridARClient_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridARClient.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                If e.Item.Cells(9).Text <> "" Or e.Item.Cells(9).Text <> "&nbsp;" Then
                    e.Item.Cells(9).Text = LoGlo.FormatDateTime(e.Item.Cells(9).Text)
                End If
                If e.Item.Cells(10).Text <> "" Or e.Item.Cells(10).Text <> "&nbsp;" Then
                    e.Item.Cells(10).Text = LoGlo.FormatDateTime(e.Item.Cells(10).Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridARClient_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridARClient.NeedDataSource
        Try
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
            Dim ThisARType As cReports.ARStatementsType

            If Me.ddARType.SelectedValue = "client" Then
                ThisARType = cReports.ARStatementsType.Client
            ElseIf Me.ddARType.SelectedValue = "product" Then
                ThisARType = cReports.ARStatementsType.Product
            End If
            StrOfficeList = MiscFN.ListBoxToString(Me.LbOffices)
            StrAEList = MiscFN.ListBoxToString(Me.RadListBoxAccountExecutive)
            RadGridARClient.DataSource = oReports.GetARStatements(ThisARType, Session("UserCode"), StrOfficeList, StrAEList)

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region " RadGrid Misc Functions"

    Public Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Public Function SetEmailCheckBox(ByVal Value As Integer, ByVal Value1 As String) As Boolean
        Try
            If Value = 1 Then
                If Value1 = "" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Public Function UseAddress(ByVal Value As Integer) As Integer
        Try
            Select Case Value
                Case 1
                    Return 0
                Case 2
                    Return 1
            End Select
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Private Function GetCCListFromGrid(ByVal TheARType As cReports.ARStatementsType, ByVal CurrentClientCode As String, Optional ByVal CurrentDivisionCode As String = "", Optional ByVal CurrentProductCode As String = "") As String
        Try
            Dim str As String = String.Empty
            Dim ChkEmail As CheckBox

            Dim StrDataKey As String = String.Empty
            Dim StrClientCode As String = String.Empty
            Dim StrDivisionCode As String = String.Empty
            Dim StrProductCode As String = String.Empty

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridARClient.MasterTableView.Items
                StrDataKey = gridDataItem.GetDataKeyValue("GridDataKey").ToString
                ChkEmail = CType(gridDataItem("colChkEmailClient").Controls(1), CheckBox)
                StrClientCode = GetClientCodeFromDataKey(StrDataKey, TheARType)

                If TheARType = cReports.ARStatementsType.Client Then
                    If ChkEmail.Checked And StrClientCode = CurrentClientCode Then
                        str &= gridDataItem("colContactClient").Text & ","
                    End If
                ElseIf TheARType = cReports.ARStatementsType.Product Then
                    StrDivisionCode = GetDivisionCodeFromDataKey(StrDataKey, cReports.ARStatementsType.Product)
                    StrProductCode = GetProductCodeFromDataKey(StrDataKey, cReports.ARStatementsType.Product)
                    If ChkEmail.Checked And StrClientCode = CurrentClientCode And StrDivisionCode = CurrentDivisionCode And StrProductCode = CurrentProductCode Then
                        str &= gridDataItem("colContactClient").Text & ","
                    End If
                End If
            Next
            Return str
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

#End Region

    Private Sub LbOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbOffices.SelectedIndexChanged
        Me.RadGridARClient.Rebind()
        'Me.SetARType()
    End Sub

    Private Sub ImgBtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRefresh.Click
        Me.SetARType()
    End Sub

    Private Sub RadListBoxAccountExecutive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxAccountExecutive.SelectedIndexChanged
        Me.RadGridARClient.Rebind()
    End Sub

    Private Sub RadGridARClient_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridARClient.PageSizeChanged
        Me.SetARType()

        'If _LoadingDatasource = False Then

        'MiscFN.SavePageSize(Me.RadGridARClient.ID, e.NewPageSize)

        'End If
    End Sub

    Private Sub RadGridARClient_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridARClient.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.SetARType()
    End Sub
End Class
