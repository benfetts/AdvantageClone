Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Partial Public Class jobspecs_AddNew
    Inherits Webvantage.BaseChildPage
    Private ConnectionString As String
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private Version As Integer
    Private quantity As Integer
    Private Revision As Integer
    Private addtype As Integer
    Private vendor As Integer
    Private specid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ConnectionString = Session("ConnString")
        Me.CancelButton.Attributes.Add("onclick", "CloseThisWindow();")

        If Request.QueryString("JobNum") IsNot Nothing Then Me.JobNum = Request.QueryString("JobNum")
        If Request.QueryString("JobCompNum") IsNot Nothing Then Me.JobCompNum = Request.QueryString("JobCompNum")
        If Request.QueryString("Version") IsNot Nothing Then Me.Version = Request.QueryString("Version")
        If Request.QueryString("Revision") IsNot Nothing Then Me.Revision = Request.QueryString("Revision")
        If Request.QueryString("AddType") IsNot Nothing Then Me.addtype = Request.QueryString("AddType")
        If Request.QueryString("Quantity") IsNot Nothing Then Me.quantity = Request.QueryString("Quantity")
        If Request.QueryString("SpecID") IsNot Nothing Then Me.specid = Request.QueryString("SpecID")

        'Clean up old querystring names by letting clean qs class override
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobCompNum = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.VersionID > 0 Then Me.Version = Me.CurrentQuerystring.VersionID
        If Me.CurrentQuerystring.RevisionID > 0 Then Me.Revision = Me.CurrentQuerystring.RevisionID
        If Me.CurrentQuerystring.Quantity > 0 Then Me.quantity = Me.CurrentQuerystring.Quantity
        If Me.CurrentQuerystring.SpecificationID > 0 Then Me.specid = Me.CurrentQuerystring.SpecificationID
        If Me.CurrentQuerystring.GetValue("AddType") <> "" AndAlso IsNumeric(Me.CurrentQuerystring.GetValue("AddType")) Then Me.addtype = CType(Me.CurrentQuerystring.GetValue("AddType"), Integer)

        If Me.IsClientPortal = True Then
            Me.hlADSize.Enabled = False
            Me.hlADSize2.Enabled = False
            Me.hlVendor.Attributes.Remove("onClick")
            Me.hlVendor.Attributes.Remove("href")
            Me.hlVendor2.Attributes.Remove("onClick")
            Me.hlVendor2.Attributes.Remove("href")
            Me.hlADSize.Attributes.Remove("onClick")
            Me.hlADSize.Attributes.Remove("href")
            Me.hlADSize2.Attributes.Remove("onClick")
            Me.hlADSize2.Attributes.Remove("href")
            Me.hlStatus.Attributes.Remove("onClick")
            Me.hlStatus.Attributes.Remove("href")
            Me.hlRegion.Attributes.Remove("onClick")
            Me.hlRegion.Attributes.Remove("href")
        Else
            Me.hlVendor.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=vendor_search&cat=1&type=vendor_and_category1&control=" & Me.txtVendor.ClientID.ToString() & "');return false;")
            Me.hlVendor2.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=vendor_search&cat=2&type=vendor_and_category2&control=" & Me.txtVendor2.ClientID.ToString() & "');return false;")
            Me.hlStatus.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtStatus.ClientID.ToString() & "&type=status');return false;")
            Me.hlRegion.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtRegion.ClientID.ToString() & "&type=region');return false;")
            Me.hlADSize.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&control=" & Me.txtADSize.ClientID & "&type=adsize&form=vendordetail&vendor=' + document.forms[0]." & Me.txtVendor.ClientID & ".value);return false;")
            Me.hlADSize2.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&control=" & Me.txtADSize2.ClientID & "&type=adsize&form=vendordetail&vendor=' + document.forms[0]." & Me.txtVendor2.ClientID & ".value);return false;")
        End If

        Dim js As New Job_Specs(Session("ConnString"))
        Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
        Dim dr As SqlDataReader = js.GetJobSpecQtyVendorTabs(type)
        Dim dr3 As SqlDataReader
        LoadLookups()
        If Not Me.IsPostBack Then
            'Me.LitSpellScript.Text = Me.WriteSpellScript()
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)
            If addtype = 1 Then
                Me.Title = "Create New Spec Revision"
                Me.pnlNewRevision.Visible = True
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.pnlApproved.Visible = False
                Me.pnlQtyVendor.Visible = False
                Me.pnlTextEdit.Visible = False
                Me.pnlJSNew.Visible = False
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnCopy.Visible = False
                Me.btnNew.Visible = False
                Me.CancelButton2.Visible = False
                Me.SaveButton.Visible = True
            ElseIf addtype = 2 Then
                Me.Title = "Add New Row"
                Me.pnlNewRevision.Visible = False
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.pnlApproved.Visible = False
                Me.pnlTextEdit.Visible = False
                Me.pnlJSNew.Visible = False
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnCopy.Visible = False
                Me.btnNew.Visible = False
                Me.SaveButton.Visible = False
                Do While dr.Read
                    If Request.QueryString("Row") = "Qty" Then
                        Session("JSaddQty") = 1
                        Session("JSaddVen") = 0
                        Me.pnlNewRowQuantity.Visible = True
                        Me.RadToolBarVendor.Visible = True
                        Me.RadToolBarVendor.Items.FindItemByValue("MediaInformation").Visible = False
                        Me.RadToolBarVendor.Items.FindItemByValue("MediaDeliveryInformation").Visible = False
                        Me.RadToolBarVendor.Items.FindItemByValue("MediaSpecifications").Visible = False
                        Me.RadToolBarVendor.Items.FindItemByValue("Sep3").Visible = False
                        Me.RadToolBarVendor.Items.FindItemByValue("Sep4").Visible = False
                        Me.pnlQtyVendor.Visible = False
                        Me.pnlNewRowVendor1.Visible = False
                        Me.pnlNewRowVendor2.Visible = False
                    ElseIf Request.QueryString("Row") = "Ven" Then
                        Me.pnlNewRowQuantity.Visible = False
                        Me.pnlQtyVendor.Visible = False
                        If dr.GetInt16(2) = 1 Then
                            Session("JSaddVen") = 1
                            Session("JSaddQty") = 0
                            Me.pnlNewRowVendor1.Visible = True
                            Me.RadToolBarVendor.Visible = True
                            If Request.QueryString("Detail") = "yes" Then
                                dr3 = js.GetJobSpecsVendorDataBySpec(Me.JobNum, Me.JobCompNum, 1, Me.specid)
                                If dr3.HasRows = True Then
                                    Do While dr3.Read
                                        Me.txtVendor.Text = dr3.GetString(0)
                                        If IsDBNull(dr3("Close_Date")) = False AndAlso dr3("Close_Date") <> "1/1/1900 12:00:00 AM" Then
                                            Me.RadDatePickerCloseDate.SelectedDate = dr3("Close_Date")
                                        End If
                                        If IsDBNull(dr3("Run_Date")) = False AndAlso dr3("Run_Date") <> "1/1/1900 12:00:00 AM" Then
                                            Me.RadDatePickerRunDate.SelectedDate = dr3("Run_Date")
                                        End If
                                        If IsDBNull(dr3("Ext_Date")) = False AndAlso dr3("Ext_Date") <> "1/1/1900 12:00:00 AM" Then
                                            Me.RadDatePickerExtDate.SelectedDate = dr3("Ext_Date")
                                        End If
                                        Me.txtBleedSize.Text = dr3.GetString(5)
                                        Me.txtTrimSize.Text = dr3.GetString(6)
                                        Me.txtLiveArea.Text = dr3.GetString(7)
                                        Me.txtScreen.Text = dr3.GetString(8)
                                        Me.txtColor.Text = dr3.GetString(9)
                                        Me.txtStatus.Text = dr3.GetString(10)
                                        Me.txtRegion.Text = dr3.GetString(11)
                                        Me.txtDensity.Text = dr3.GetString(12)
                                        Me.txtFilm.Text = dr3.GetString(13)
                                        Me.txtShippingComments.Text = dr3.GetString(14)
                                        Me.txtSpecialInstructions.Text = dr3.GetString(15)
                                        Me.txtADSize.Text = dr3.GetString(16)
                                        Me.SaveButton.Visible = False
                                        Me.RadToolBarVendor.Items.FindItemByValue("Save").Value = "Update"
                                        Me.btnUpdate.Visible = False
                                        'Me.imgbtnMediaSpecs.Visible = True
                                        Me.txtVendor.Enabled = False
                                        Me.hlVendor.Enabled = False
                                    Loop
                                End If
                            End If
                        Else
                            Session("JSaddQty") = 0
                            Me.pnlNewRowVendor1.Visible = False
                        End If
                        If dr.GetInt16(2) = 2 Then
                            Session("JSaddVen") = 2
                            Session("JSaddQty") = 0
                            Me.pnlNewRowVendor2.Visible = True
                            Me.RadToolBarVendor.Visible = True
                            If Request.QueryString("Detail") = "yes" Then
                                dr3 = js.GetJobSpecsVendorDataBySpec(Me.JobNum, Me.JobCompNum, 2, Me.specid)
                                If dr3.HasRows = True Then
                                    Do While dr3.Read
                                        Me.txtVendor2.Text = dr3.GetString(0)
                                        Me.txtLocationSign.Text = dr3.GetString(2)
                                        Me.txtOverallSize.Text = dr3.GetString(3)
                                        Me.txtCopyArea.Text = dr3.GetString(4)
                                        Me.txtADSize2.Text = dr3.GetString(5)
                                        Me.SaveButton.Visible = False
                                        Me.RadToolBarVendor.Items.FindItemByValue("Save").Value = "Update"
                                        Me.btnUpdate.Visible = False
                                        'Me.imgbtnMediaSpecs.Visible = True
                                        Me.txtVendor2.Enabled = False
                                        Me.hlVendor2.Enabled = False
                                    Loop
                                End If
                            End If
                        Else
                            Session("JSaddQty") = 0
                            Me.pnlNewRowVendor2.Visible = False
                        End If
                    Else
                        Me.pnlQtyVendor.Visible = True
                    End If
                Loop
                dr.Close()
                Me.CancelButton2.Visible = False
                If Me.IsClientPortal = True Then
                    btnUpdate.Visible = False
                    Me.txtBleedSize.ReadOnly = True
                    Me.txtTrimSize.ReadOnly = True
                    Me.txtLiveArea.ReadOnly = True
                    Me.txtScreen.ReadOnly = True
                    Me.txtColor.ReadOnly = True
                    Me.txtStatus.ReadOnly = True
                    Me.txtRegion.ReadOnly = True
                    Me.txtDensity.ReadOnly = True
                    Me.txtFilm.ReadOnly = True
                    Me.txtShippingComments.ReadOnly = True
                    Me.txtSpecialInstructions.ReadOnly = True
                    Me.txtADSize.ReadOnly = True
                    Me.RadDatePickerCloseDate.DateInput.ReadOnly = True
                    Me.RadDatePickerRunDate.DateInput.ReadOnly = True
                    Me.RadDatePickerExtDate.DateInput.ReadOnly = True
                    Me.RadDatePickerCloseDate.Enabled = False
                    Me.RadDatePickerRunDate.Enabled = False
                    Me.RadDatePickerExtDate.Enabled = False
                    Me.txtVendor2.ReadOnly = True
                    Me.txtLocationSign.ReadOnly = True
                    Me.txtOverallSize.ReadOnly = True
                    Me.txtCopyArea.ReadOnly = True
                    Me.txtADSize2.ReadOnly = True
                End If
            ElseIf addtype = 3 Then
                Me.lblField.Text = Request.QueryString("HText") & ":"
                Dim dt As DataTable = js.GetJobSpecsTextField(Me.JobNum, Me.JobCompNum, Me.Version, Me.Revision, Request.QueryString("Item"))
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)(0).ToString() <> "" Then
                        Me.txtField.Text = dt.Rows(0)(0).ToString
                    End If
                End If
                Me.pnlNewRevision.Visible = False
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.pnlApproved.Visible = False
                Me.pnlQtyVendor.Visible = False
                Me.pnlTextEdit.Visible = True
                Me.pnlJSNew.Visible = False
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnCopy.Visible = False
                Me.btnNew.Visible = False
                Me.CancelButton.Attributes.Add("onclick", "CloseThisWindow();")
                Me.CancelButton2.Visible = False
                Me.Title = "Edit Text"
                If Me.IsClientPortal = True Then
                    Me.SaveButton.Visible = False
                    Me.txtField.ReadOnly = True
                    'Me.spell1.Visible = False
                End If
            ElseIf addtype = 4 Then
                Me.pnlNewRevision.Visible = False
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.pnlApproved.Visible = False
                Me.pnlQtyVendor.Visible = False
                Me.pnlTextEdit.Visible = False
                Me.pnlJSNew.Visible = True
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnNew.Visible = False
                Me.CancelButton2.Visible = False
                loadJSTypes()
                Me.CancelButton.Attributes.Remove("onClick")
                Me.CancelButton.Attributes.Add("onclick", "CloseThisWindow();")
                'End If
                Me.Title = "New Specification"
            ElseIf addtype = 5 Then
                Me.pnlNewRevision.Visible = False
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = True
                Me.RadToolBarVendor.Items.FindItemByValue("MediaInformation").Visible = False
                Me.RadToolBarVendor.Items.FindItemByValue("MediaDeliveryInformation").Visible = False
                Me.RadToolBarVendor.Items.FindItemByValue("MediaSpecifications").Visible = False
                Me.RadToolBarVendor.Items.FindItemByValue("Sep3").Visible = False
                Me.RadToolBarVendor.Items.FindItemByValue("Sep4").Visible = False
                Me.pnlApproved.Visible = True
                Me.pnlQtyVendor.Visible = False
                Me.pnlTextEdit.Visible = False
                Me.pnlJSNew.Visible = False
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnCopy.Visible = False
                Me.btnNew.Visible = False
                Me.CancelButton2.Visible = False
                Me.RadDatePickerApprovalDate.SelectedDate = cEmployee.TimeZoneToday
                Me.SaveButton.Visible = False
                txtApprovedBy.Focus()
                Me.Title = "Approve Specification"
            ElseIf addtype = 6 Then
                Me.pnlNewRevision.Visible = False
                Me.pnlNewRowVendor1.Visible = False
                Me.pnlNewRowQuantity.Visible = False
                Me.pnlNewRowVendor2.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.pnlApproved.Visible = True
                Me.pnlQtyVendor.Visible = False
                Me.pnlTextEdit.Visible = False
                Me.pnlJSNew.Visible = False
                Me.SaveButton.Visible = False
                Me.btnUpdate.Visible = False
                Me.pnlJSCopy.Visible = False
                Me.btnCopyJS.Visible = False
                Me.btnCopy.Visible = False
                Me.btnNew.Visible = False
                Me.CancelButton.Visible = True
                Me.CancelButton2.Visible = False
                Dim dr2 As SqlDataReader
                dr2 = js.GetJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
                If dr2.HasRows = True Then
                    Do While dr2.Read
                        Me.txtApprovedBy.Text = dr2.GetString(1)
                        Me.RadDatePickerApprovalDate.SelectedDate = dr2.GetDateTime(4).ToShortDateString
                        Me.txtComments.Text = dr2.GetString(2)
                    Loop
                    dr2.Close()
                    Me.txtApprovedBy.ReadOnly = True
                    Me.RadDatePickerApprovalDate.Enabled = True
                    Me.txtComments.ReadOnly = True
                    Me.CancelButton.Value = "Close"
                End If
                Me.Title = "Approve Specification"
            End If
        Else

        End If
    End Sub

#Region " SubRoutines: "

    Private Sub CheckChanged()
        Dim js As New Job_Specs(Session("ConnString"))
        If Me.rbQty.Checked = True Then
            Session("JSaddQty") = 1
            Session("JSaddVen") = 0
            Me.pnlNewRowQuantity.Visible = True
            Me.pnlNewRowVendor1.Visible = False
            Me.pnlNewRowVendor2.Visible = False
            Me.RadToolBarVendor.Visible = True
            Me.RadToolBarVendor.Items.FindItemByValue("MediaInformation").Visible = False
            Me.RadToolBarVendor.Items.FindItemByValue("MediaDeliveryInformation").Visible = False
            Me.RadToolBarVendor.Items.FindItemByValue("MediaSpecifications").Visible = False
            Me.RadToolBarVendor.Items.FindItemByValue("Sep3").Visible = False
            Me.RadToolBarVendor.Items.FindItemByValue("Sep4").Visible = False
        Else
            Session("JSaddQty") = 0
            Me.pnlNewRowQuantity.Visible = False
        End If
        If Me.rbVen.Checked = True Then
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            Dim dr As SqlDataReader = js.GetJobSpecQtyVendorTabs(type)
            Do While dr.Read
                If dr.GetInt16(2) = 1 Then
                    Session("JSaddVen") = 1
                    Session("JSaddQty") = 0
                    Me.pnlNewRowVendor1.Visible = True
                    Me.pnlNewRowVendor2.Visible = False
                    Me.RadToolBarVendor.Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaInformation").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaDeliveryInformation").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaSpecifications").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("Sep3").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("Sep4").Visible = True
                ElseIf dr.GetInt16(2) = 2 Then
                    Session("JSaddVen") = 2
                    Session("JSaddQty") = 0
                    Me.pnlNewRowVendor2.Visible = True
                    Me.pnlNewRowVendor1.Visible = False
                    Me.RadToolBarVendor.Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaInformation").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaDeliveryInformation").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("MediaSpecifications").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("Sep3").Visible = True
                    Me.RadToolBarVendor.Items.FindItemByValue("Sep4").Visible = True
                Else
                    Session("JSaddVen") = 0
                End If
            Loop
            dr.Close()
        End If

    End Sub

    Private Sub loadJSTypes()
        Try
            Dim oD As New cDropDowns(Session("ConnString"))
            With Me.ddJSTemplates
                .DataSource = oD.GetJobSpecTypes
                .DataTextField = "Description"
                .DataValueField = "Code"
                .DataBind()
            End With
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub loadMediaSpecs()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim vendor As String
            Dim adsize As String
            If Session("JSaddVen") = 1 Then
                vendor = Me.txtVendor.Text
                adsize = Me.txtADSize.Text
            End If
            If Session("JSaddVen") = 2 Then
                vendor = Me.txtVendor2.Text
                adsize = Me.txtADSize2.Text
            End If
            Dim strURL As String = "mediavendorinfo.aspx?mid=3&page=jobspecs&VnCode=" & vendor & "&Type=" & js.GetMediaType(vendor) & "&AdSize=" & adsize
            Me.OpenWindow("", strURL, 0, 0, False, True)
            'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'strBuilder.Append("<script language='javascript'>")
            'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            'strBuilder.Append("</")
            'strBuilder.Append("script>")
            'Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'With Me.RadWindowManagerSpecs.Windows(0)
            '    .NavigateUrl = "mediavendorinfo.aspx?mid=3&VnCode=" & vendor & "&page=jobspecs"
            '    .Title = "Media Specifications"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(400, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .Skin = MiscFN.SetRadWindowSkin '"WebBlue"
            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            '    .OnClientClose = "OnClientClose()"
            'End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadMediaInfo()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim vendor As String
            If Session("JSaddVen") = 1 Then
                vendor = Me.txtVendor.Text
            End If
            If Session("JSaddVen") = 2 Then
                vendor = Me.txtVendor2.Text
            End If
            Dim strURL As String = "mediavendorinfo.aspx?mid=1&page=jobspecs&VnCode=" & vendor & "&Type=" & js.GetMediaType(vendor)
            Me.OpenWindow("", strURL, 0, 0, False, True)
            'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'strBuilder.Append("<script language='javascript'>")
            'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            'strBuilder.Append("</")
            'strBuilder.Append("script>")
            'Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'With Me.RadWindowManagerSpecs.Windows(0)
            '    .NavigateUrl = "mediavendorinfo.aspx?mid=1&VnCode=" & vendor & "&page=jobspecs"
            '    .Title = "Media Specifications"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(400, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .Skin = MiscFN.SetRadWindowSkin '"WebBlue"
            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            '    .OnClientClose = "OnClientClose()"
            'End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadMediaDelivery()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim vendor As String
            If Session("JSaddVen") = 1 Then
                vendor = Me.txtVendor.Text
            End If
            If Session("JSaddVen") = 2 Then
                vendor = Me.txtVendor2.Text
            End If
            Dim strURL As String = "mediavendorinfo.aspx?mid=2&page=jobspecs&VnCode=" & vendor & "&Type=" & js.GetMediaType(vendor)
            Me.OpenWindow("", strURL, 0, 0, False, True)
            'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            'strBuilder.Append("<script language='javascript'>")
            'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            'strBuilder.Append("</")
            'strBuilder.Append("script>")
            'Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'With Me.RadWindowManagerSpecs.Windows(0)
            '    .NavigateUrl = "mediavendorinfo.aspx?mid=2&VnCode=" & vendor & "&page=jobspecs"
            '    .Title = "Media Specifications"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(400, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.Close
            '    .Skin = MiscFN.SetRadWindowSkin '"WebBlue"
            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            '    .OnClientClose = "OnClientClose()"
            'End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadLookups()
        Try
            'Me.HlClientSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
            'Me.HlDivisionSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
            'Me.HlProductSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

            'Me.HlJob.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobspecs&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
            'Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobspecsjj&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

            'Me.TxtClientSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtClientSourceDesc.ClientID & "');ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            'Me.TxtDivisionSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            'Me.TxtProductSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            'Me.TxtJobNum.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")

            'REMOVE ClearTB
            Me.HlClientSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
            Me.HlDivisionSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
            Me.HlProductSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

            Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobspecs&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
            Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobspecsjj&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region " Controls: "

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim dt As DataTable
            Dim js As New Job_Specs(Session("ConnString"))
            Dim cv As New cValidations(Session("ConnString"))
            Dim save As Boolean
            Dim delete As Boolean
            Dim max As Integer
            Dim maxRev As Integer
            Dim invalidStr As String = ""
            Dim str As String
            If addtype = 1 Then
                If Me.txtReason.Text = "" Then
                    Me.ShowMessage("Reason is required.")
                    Exit Sub
                End If
                If Me.txtAuthorizedBy.Text = "" Then
                    Me.ShowMessage("Authorized By is required.")
                    Exit Sub
                End If
                max = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.Version)
                save = js.AddJobSpecCopy(Me.JobNum, Me.JobCompNum, Me.Version, max, 1, max + 1, 0, 0, 0, Me.txtReason.Text, Me.txtAuthorizedBy.Text, Session("UserCode"))
                Dim saveqty As Boolean = True
                If quantity = 1 Then
                    dt = js.GetJobSpecsQtyDataRows(Me.JobNum, Me.JobCompNum, Me.Version, max)
                    Dim i As Integer
                    For i = 0 To dt.Rows.Count - 1
                        saveqty = js.AddJobSpecCopyQty(CInt(dt.Rows(i).Item(0).ToString()), CInt(dt.Rows(i).Item(1).ToString()), CInt(dt.Rows(i).Item(2).ToString()), CInt(dt.Rows(i).Item(3).ToString()), CInt(dt.Rows(i).Item(4).ToString()), CInt(dt.Rows(i).Item(5).ToString()), 1, max + 1, 0, 0, 0)
                    Next
                    If saveqty = False Then
                        Me.ShowMessage("Creation of New Spec Revision Failed!")
                    End If
                End If
                If save = True Then
                    Session("JSNewRevision") = "1"
                    Session("JSNewVersion") = ""
                    Session("JobSpecsRevision") = max + 1
                    'Dim FunctionName As String = "RefreshFileGrid"
                    'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Creation of New Spec Revision Failed!")
                End If
            End If
            If addtype = 2 Then
                If Session("JSaddQty") = 1 Then
                    If Me.txtJobQty.Text = "" Then
                        Me.ShowMessage("Quantity is required.")
                        Exit Sub
                    End If
                    If IsNumeric(Me.txtJobQty.Text) = False Then
                        Me.ShowMessage("Invalid Job Quantity")
                        Me.pnlNewRowQuantity.Visible = True
                        Exit Sub
                    End If
                    If Me.txtJobQty.Text > 2147483647 Then
                        Me.ShowMessage("Invalid Job Quantity")
                        Me.pnlNewRowQuantity.Visible = True
                        Exit Sub
                    End If
                    maxRev = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.Version)
                    max = js.GetJobSpecMaxSeqNum(Me.JobNum, Me.JobCompNum, Me.Version, maxRev)
                    save = js.AddJobSpecNewRowQty(Me.JobNum, Me.JobCompNum, Me.Version, maxRev, max + 1, CInt(Me.txtJobQty.Text))
                    If save = True Then
                        Session("JSAddJobQtyRow") = "1"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If
                If Session("JSaddVen") = 1 Then
                    If Me.txtVendor.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Sub
                    End If
                    If cv.ValidateVendor(Me.txtVendor.Text) = False Then
                        invalidStr = invalidStr & "Invalid Vendor<br />"
                    End If
                    If Me.txtADSize.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize.Text, js.GetMediaType(Me.txtVendor.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size<br />"
                        End If
                    End If
                    If Me.txtStatus.Text <> "" Then
                        If cv.ValidateStatus(Me.txtStatus.Text) = False Then
                            invalidStr = invalidStr & "Invalid Status<br />"
                        End If
                    End If
                    If Me.txtRegion.Text <> "" Then
                        If cv.ValidateRegion(Me.txtRegion.Text) = False Then
                            invalidStr = invalidStr & "Invalid Region<br />"
                        End If
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerCloseDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Close Date<br />"
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerRunDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Run Date<br />"
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerExtDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Ext Date"
                    End If

                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor1.Visible = True
                        Exit Sub
                    End If
                    Dim cd As String = ""
                    Dim ed As String = ""
                    Dim rd As String = ""
                    If Not Me.RadDatePickerCloseDate.SelectedDate Is Nothing Then
                        cd = wvCDate(Me.RadDatePickerCloseDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerExtDate.SelectedDate Is Nothing Then
                        ed = wvCDate(Me.RadDatePickerExtDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerRunDate.SelectedDate Is Nothing Then
                        rd = wvCDate(Me.RadDatePickerRunDate.SelectedDate).ToShortDateString
                    End If
                    max = js.GetJobSpecMaxSpecID(Me.JobNum, Me.JobCompNum, 1)
                    save = js.AddJobSpecNewRowVendorPub(Me.JobNum,
                                              Me.JobCompNum,
                                              max + 1,
                                              Me.txtVendor.Text,
                                              Me.txtBleedSize.Text,
                                              cd,
                                              Me.txtColor.Text,
                                              ed,
                                              Me.txtLiveArea.Text,
                                              rd,
                                              Me.txtScreen.Text,
                                              Me.txtTrimSize.Text,
                                              Me.txtDensity.Text,
                                              Me.txtFilm.Text,
                                              Me.txtShippingComments.Text,
                                              Me.txtSpecialInstructions.Text,
                                              Me.txtStatus.Text,
                                              Me.txtRegion.Text,
                                              Me.txtADSize.Text)
                    If save = True Then
                        Session("JSAddJobVenRow") = "1"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        'Me.CloseThisWindow()
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If
                If Session("JSaddVen") = 2 Then
                    If Me.txtVendor2.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Sub
                    End If
                    If cv.ValidateVendor(Me.txtVendor2.Text) = False Then
                        invalidStr = invalidStr & "Invalid Vendor "
                    End If
                    If Me.txtADSize2.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize2.Text, js.GetMediaType(Me.txtVendor2.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size "
                        End If
                    End If
                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor2.Visible = True
                        Exit Sub
                    End If

                    max = js.GetJobSpecMaxSpecID(Me.JobNum, Me.JobCompNum, 2)
                    save = js.AddJobSpecNewRowVendorOut(Me.JobNum,
                                              Me.JobCompNum,
                                              max + 1,
                                              Me.txtVendor2.Text,
                                              Me.txtLocationSign.Text,
                                              Me.txtOverallSize.Text,
                                              Me.txtCopyArea.Text,
                                              Me.txtADSize2.Text)
                    If save = True Then
                        Session("JSAddJobVenRow") = "2"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If

            End If
            If addtype = 3 Then

                Dim oJob As New Job_Specs(Session("ConnString"))
                Dim arP(1) As SqlParameter
                Dim sbJobUpdate As System.Text.StringBuilder = New System.Text.StringBuilder
                sbJobUpdate.Append("UPDATE JOB_SPECS SET ")
                sbJobUpdate.Append(Request.QueryString("Item") & "='" & js.EncodeSQL(Me.txtField.Text))
                sbJobUpdate.Append("' WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.Version & " AND SPEC_REV = " & Me.Revision)
                Try
                    Dim str2 As String = sbJobUpdate.ToString.Replace(",  WHERE", " WHERE")
                    'str2 = str2.Replace("$", "")
                    'str2 = str2.Replace("%", "")
                    If str2 <> "" Then
                        str = oJob.UpdateJob(str2, arP, save).ToString
                    End If
                    If save = True Then
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Save Failed!")
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Job NOT Updated! " & ex.Message.ToString)
                    Exit Sub
                End Try
            End If
            If addtype = 4 Then
                'Session("JSTemplateNew") = Me.ddJSTemplates.SelectedValue
                Try
                    save = js.AddJobSpecNew(Me.JobNum, Me.JobCompNum, 1, 0, Session("UserCode"), Me.ddJSTemplates.SelectedValue)
                    If save = True Then
                        'Me.ShowMessage("New Version Created")
                        Session("JSNewVersion") = "1"
                        Session("JSNewRevision") = "0"
                        Dim SessionKey As String = "GetJobSpecType" & JobNum.ToString() & JobCompNum.ToString()
                        HttpContext.Current.Session(SessionKey) = Nothing
                    Else
                        Me.ShowMessage("Creation Failed")
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error AddNewjobspecs!<BR />" & ex.Message.ToString())
                End Try
                If Me.CurrentQuerystring.IsJobDashboard = True Then
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=1&spectype=" & Me.ddJSTemplates.SelectedValue, True)
                Else
                    Me.CloseThisWindowAndOpenNewWindow("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=1&spectype=" & Me.ddJSTemplates.SelectedValue)
                End If
            End If
            If addtype = 5 Then
                If Me.txtApprovedBy.Text = "" Then
                    Me.ShowMessage("Approved By is required.")
                    Exit Sub
                End If
                If Me.RadDatePickerApprovalDate.SelectedDate = Nothing Then
                    Me.ShowMessage("Approval Date is required.")
                    Exit Sub
                End If
                If ValidDate(Me.RadDatePickerApprovalDate) = False Then
                    invalidStr = invalidStr & "Invalid Approval Date"
                Else
                    Me.RadDatePickerApprovalDate.SelectedDate = wvCDate(Me.RadDatePickerApprovalDate.SelectedDate)
                End If
                If invalidStr <> "" Then
                    Me.ShowMessage(invalidStr)
                    invalidStr = ""
                    Exit Sub
                End If
                delete = js.DeleteJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
                If IsClientPortal = True Then
                    save = js.AddJobSpecApproval(Me.JobNum, Me.JobCompNum, Me.Version, Me.txtApprovedBy.Text, Me.txtComments.Text, "", CDate(Me.RadDatePickerApprovalDate.SelectedDate & " " & Now.ToLongTimeString), Session("UserID"))
                Else
                    save = js.AddJobSpecApproval(Me.JobNum, Me.JobCompNum, Me.Version, Me.txtApprovedBy.Text, Me.txtComments.Text, Session("UserCode"), CDate(Me.RadDatePickerApprovalDate.SelectedDate & " " & Now.ToLongTimeString))
                End If
                If save = True Then
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Approval save Failed!")
                End If
            End If

        Catch ex As Exception
            Me.ShowMessage("Error Jobspecnewrow!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub rbQty_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbQty.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub rbVen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbVen.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim dt As DataTable
        Dim js As New Job_Specs(Session("ConnString"))
        Dim cv As New cValidations(Session("ConnString"))
        Dim update As Boolean
        Dim delete As Boolean
        Dim max As Integer
        Dim maxRev As Integer
        Dim invalidStr As String = ""
        Dim str As String
        If addtype = 2 Then
            If Session("JSaddVen") = 1 Then
                If Me.txtVendor.Text = "" Then
                    Me.ShowMessage("Vendor is required.")
                    Exit Sub
                End If
                If Me.txtADSize.Text <> "" Then
                    If cv.ValidateAdSize(Me.txtADSize.Text, js.GetMediaType(Me.txtVendor.Text)) = False Then
                        invalidStr = invalidStr & "Invalid Ad Size "
                    End If
                End If
                If Me.txtStatus.Text <> "" Then
                    If cv.ValidateStatus(Me.txtStatus.Text) = False Then
                        invalidStr = invalidStr & "Invalid Status "
                    End If
                End If
                If Me.txtRegion.Text <> "" Then
                    If cv.ValidateRegion(Me.txtRegion.Text) = False Then
                        invalidStr = invalidStr & "Invalid Region "
                    End If
                End If

                If MiscFN.ValidDate(Me.RadDatePickerCloseDate, True) = False Then
                    invalidStr = invalidStr & "Invalid Close Date "
                End If
                If MiscFN.ValidDate(Me.RadDatePickerRunDate, True) = False Then
                    invalidStr = invalidStr & "Invalid Run Date "
                End If
                If MiscFN.ValidDate(Me.RadDatePickerExtDate, True) = False Then
                    invalidStr = invalidStr & "Invalid Ext Date"
                End If

                If invalidStr <> "" Then
                    Me.ShowMessage(invalidStr)
                    invalidStr = ""
                    Me.pnlNewRowVendor1.Visible = True
                    Exit Sub
                End If
                Dim cd As String = ""
                Dim ed As String = ""
                Dim rd As String = ""
                If Not Me.RadDatePickerCloseDate.SelectedDate Is Nothing Then
                    cd = wvCDate(Me.RadDatePickerCloseDate.SelectedDate).ToShortDateString
                End If
                If Not Me.RadDatePickerExtDate.SelectedDate Is Nothing Then
                    ed = wvCDate(Me.RadDatePickerExtDate.SelectedDate).ToShortDateString
                End If
                If Not Me.RadDatePickerRunDate.SelectedDate Is Nothing Then
                    rd = wvCDate(Me.RadDatePickerRunDate.SelectedDate).ToShortDateString
                End If
                update = js.UpdateJobSpecNewRowVendorPub(Me.JobNum,
                                          Me.JobCompNum,
                                          Me.specid,
                                          Me.txtVendor.Text,
                                          Me.txtBleedSize.Text,
                                          cd,
                                          Me.txtColor.Text,
                                          ed,
                                          Me.txtLiveArea.Text,
                                          rd,
                                          Me.txtScreen.Text,
                                          Me.txtTrimSize.Text,
                                          Me.txtDensity.Text,
                                          Me.txtFilm.Text,
                                          Me.txtShippingComments.Text,
                                          Me.txtSpecialInstructions.Text,
                                          Me.txtStatus.Text,
                                          Me.txtRegion.Text,
                                          Me.txtADSize.Text)
                If update = True Then
                    Session("JSAddJobVenRow") = "1"
                    'Dim FunctionName As String = "HidePopUpWindows"
                    'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Creation of New Row Failed!")
                End If
            End If
            If Session("JSaddVen") = 2 Then
                If Me.txtVendor2.Text = "" Then
                    Me.ShowMessage("Vendor is required.")
                    Exit Sub
                End If
                If Me.txtADSize2.Text <> "" Then
                    If cv.ValidateAdSize(Me.txtADSize2.Text, js.GetMediaType(Me.txtVendor2.Text)) = False Then
                        invalidStr = invalidStr & "Invalid Ad Size "
                    End If
                End If
                If invalidStr <> "" Then
                    Me.ShowMessage(invalidStr)
                    invalidStr = ""
                    Me.pnlNewRowVendor2.Visible = True
                    Exit Sub
                End If
                update = js.UpdateJobSpecNewRowVendorOut(Me.JobNum,
                                          Me.JobCompNum,
                                          Me.specid,
                                          Me.txtVendor2.Text,
                                          Me.txtLocationSign.Text,
                                          Me.txtOverallSize.Text,
                                          Me.txtCopyArea.Text,
                                          Me.txtADSize2.Text)
                If update = True Then
                    Session("JSAddJobVenRow") = "2"
                    'Dim FunctionName As String = "HidePopUpWindows"
                    'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Creation of New Row Failed!")
                End If
            End If

        End If
    End Sub

    Private Sub txtADSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtADSize.TextChanged
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim js As New Job_Specs(Session("ConnString"))
        Dim dt As DataTable
        Dim i As Integer
        dt = oTasks.GetMediaSpecsByAdSize(Me.txtVendor.Text, js.GetMediaType(Me.txtVendor.Text), Me.txtADSize.Text)
        If dt.Rows.Count <> 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Bleed Size" Then
                    Me.txtBleedSize.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Trim Size" Then
                    Me.txtTrimSize.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Live Area" Then
                    Me.txtLiveArea.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Screen" Then
                    Me.txtScreen.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Color" Then
                    Me.txtColor.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Density" Then
                    Me.txtDensity.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Film" Then
                    Me.txtFilm.Text = dt.Rows(i)("DATA").ToString
                End If
            Next
        End If
    End Sub

    Private Sub txtADSize2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtADSize2.TextChanged
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim js As New Job_Specs(Session("ConnString"))
        Dim dt As DataTable
        Dim i As Integer
        dt = oTasks.GetMediaSpecsByAdSize(Me.txtVendor2.Text, js.GetMediaType(Me.txtVendor2.Text), Me.txtADSize2.Text)
        If dt.Rows.Count <> 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Location of Sign" Then
                    Me.txtLocationSign.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Overall Size" Then
                    Me.txtOverallSize.Text = dt.Rows(i)("DATA").ToString
                End If
                If dt.Rows(i)("LABEL_DESC").ToString.Trim = "Copy Area" Then
                    Me.txtCopyArea.Text = dt.Rows(i)("DATA").ToString
                End If
            Next
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Try
            Me.pnlJSNew.Visible = False
            Me.pnlJSCopy.Visible = True
            Me.btnCopyJS.Visible = True
            Me.btnUpdate.Visible = False
            Me.SaveButton.Visible = False
            Me.btnCopy.Visible = False
            Me.CancelButton.Visible = False
            Me.CancelButton2.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCopyJS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyJS.Click
        Try
            Dim save As Boolean
            Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If Me.TxtJobNum.Text <> "" Then
                If myVal.ValidateJobNumber(Me.TxtJobNum.Text) = False Then
                    Me.ShowMessage("This job does not exist!")
                    Exit Sub
                End If
            End If
            If Me.TxtJobNum.Text = "" Then
                Me.ShowMessage("Please enter a Job Number!")
                Exit Sub
            End If
            If Me.TxtJobCompNum.Text = "" Then
                Me.ShowMessage("Please enter a Component Number!")
                Exit Sub
            End If
            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                If IsNumeric(Me.TxtJobNum.Text) = False Or IsNumeric(Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("Job Number and Component must be valid numbers!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompNumber(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("This is not a valid job/component!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub
                End If

                Dim oSQL As SqlHelper
                Dim SQL_STRING As String
                Dim dr2 As SqlDataReader

                Session("SaveOK") = 0

                SQL_STRING = "SELECT * "
                SQL_STRING &= " FROM JOB_SPECS "
                SQL_STRING &= " WHERE JOB_NUMBER = " & Me.TxtJobNum.Text & " AND JOB_COMPONENT_NBR = " & Me.TxtJobCompNum.Text

                Try
                    dr2 = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                Catch

                    Err.Raise(Err.Number, "Class:JS.ascx Routine:SaveTemplate", Err.Description)
                Finally
                End Try

                If dr2.HasRows = False Then
                    Me.ShowMessage("This Job/Component does not have an existing Job Specification.")
                    Exit Sub
                End If
            End If

            save = oJob.CopyJobSpecs(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, Me.JobNum, Me.JobCompNum)
            If save = False Then
                Me.ShowMessage("Error saving job specs.")
                Exit Sub
            End If
            Session("JSTemplateNew") = Me.ddJSTemplates.SelectedValue
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&spec=1", True)
            Else
                Me.CloseThisWindowAndOpenNewWindow("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&spec=1")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            Me.pnlJSNew.Visible = True
            Me.btnUpdate.Visible = False
            Me.pnlJSCopy.Visible = False
            Me.btnCopyJS.Visible = False
            Me.btnNew.Visible = False
            Me.btnCopy.Visible = True
            Me.SaveButton.Visible = True
            Me.CancelButton.Attributes.Remove("onClick")
            Me.CancelButton.Attributes.Add("onclick", "CloseThisWindow();")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CancelButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        Try
            Me.pnlJSNew.Visible = True
            Me.btnUpdate.Visible = False
            Me.pnlJSCopy.Visible = False
            Me.btnCopyJS.Visible = False
            'Me.btnNew.Visible = False
            Me.btnCopy.Visible = True
            Me.SaveButton.Visible = True
            Me.CancelButton.Visible = True
            Me.CancelButton2.Visible = False
            Me.CancelButton.Attributes.Remove("onClick")
            Me.CancelButton.Attributes.Add("onclick", "CloseThisWindow();")
        Catch ex As Exception
        End Try
    End Sub

    Private Function SaveData()
        Try

            Dim dt As DataTable
            Dim js As New Job_Specs(Session("ConnString"))
            Dim cv As New cValidations(Session("ConnString"))
            Dim save As Boolean
            Dim delete As Boolean
            Dim max As Integer
            Dim maxRev As Integer
            Dim invalidStr As String = ""
            Dim str As String
            If addtype = 1 Then
                If Me.txtReason.Text = "" Then
                    Me.ShowMessage("Reason is required.")
                    Exit Function
                End If
                If Me.txtAuthorizedBy.Text = "" Then
                    Me.ShowMessage("Authorized By is required.")
                    Exit Function
                End If
                max = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.Version)
                save = js.AddJobSpecCopy(Me.JobNum, Me.JobCompNum, Me.Version, max, 1, max + 1, 0, 0, 0, Me.txtReason.Text, Me.txtAuthorizedBy.Text, Session("UserCode"))
                Dim saveqty As Boolean = True
                If quantity = 1 Then
                    dt = js.GetJobSpecsQtyDataRows(Me.JobNum, Me.JobCompNum, Me.Version, max)
                    Dim i As Integer
                    For i = 0 To dt.Rows.Count - 1
                        saveqty = js.AddJobSpecCopyQty(CInt(dt.Rows(i).Item(0).ToString()), CInt(dt.Rows(i).Item(1).ToString()), CInt(dt.Rows(i).Item(2).ToString()), CInt(dt.Rows(i).Item(3).ToString()), CInt(dt.Rows(i).Item(4).ToString()), CInt(dt.Rows(i).Item(5).ToString()), 1, max + 1, 0, 0, 0)
                    Next
                    If saveqty = False Then
                        Me.ShowMessage("Creation of New Spec Revision Failed!")
                    End If
                End If
                If save = True Then
                    Session("JSNewRevision") = "1"
                    Session("JSNewVersion") = ""
                    Session("JobSpecsRevision") = max + 1
                    'Dim FunctionName As String = "RefreshFileGrid"
                    'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Creation of New Spec Revision Failed!")
                End If
            End If
            If addtype = 2 Then
                If Session("JSaddQty") = 1 Then
                    If Me.txtJobQty.Text = "" Then
                        Me.ShowMessage("Quantity is required.")
                        Exit Function
                    End If
                    If IsNumeric(Me.txtJobQty.Text) = False Then
                        Me.ShowMessage("Invalid Job Quantity")
                        Me.pnlNewRowQuantity.Visible = True
                        Exit Function
                    End If
                    If Me.txtJobQty.Text > 2147483647 Then
                        Me.ShowMessage("Invalid Job Quantity")
                        Me.pnlNewRowQuantity.Visible = True
                        Exit Function
                    End If
                    maxRev = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.Version)
                    max = js.GetJobSpecMaxSeqNum(Me.JobNum, Me.JobCompNum, Me.Version, maxRev)
                    save = js.AddJobSpecNewRowQty(Me.JobNum, Me.JobCompNum, Me.Version, maxRev, max + 1, CInt(Me.txtJobQty.Text))
                    If save = True Then
                        Session("JSAddJobQtyRow") = "1"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If
                If Session("JSaddVen") = 1 Then
                    If Me.txtVendor.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Function
                    End If
                    If cv.ValidateVendor(Me.txtVendor.Text) = False Then
                        invalidStr = invalidStr & "Invalid Vendor<br />"
                    End If
                    If Me.txtADSize.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize.Text, js.GetMediaType(Me.txtVendor.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size<br />"
                        End If
                    End If
                    If Me.txtStatus.Text <> "" Then
                        If cv.ValidateStatus(Me.txtStatus.Text) = False Then
                            invalidStr = invalidStr & "Invalid Status<br />"
                        End If
                    End If
                    If Me.txtRegion.Text <> "" Then
                        If cv.ValidateRegion(Me.txtRegion.Text) = False Then
                            invalidStr = invalidStr & "Invalid Region<br />"
                        End If
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerCloseDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Close Date<br />"
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerRunDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Run Date<br />"
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerExtDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Ext Date"
                    End If

                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor1.Visible = True
                        Exit Function
                    End If
                    Dim cd As String = ""
                    Dim ed As String = ""
                    Dim rd As String = ""
                    If Not Me.RadDatePickerCloseDate.SelectedDate Is Nothing Then
                        cd = wvCDate(Me.RadDatePickerCloseDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerExtDate.SelectedDate Is Nothing Then
                        ed = wvCDate(Me.RadDatePickerExtDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerRunDate.SelectedDate Is Nothing Then
                        rd = wvCDate(Me.RadDatePickerRunDate.SelectedDate).ToShortDateString
                    End If
                    max = js.GetJobSpecMaxSpecID(Me.JobNum, Me.JobCompNum, 1)
                    save = js.AddJobSpecNewRowVendorPub(Me.JobNum,
                                              Me.JobCompNum,
                                              max + 1,
                                              Me.txtVendor.Text,
                                              Me.txtBleedSize.Text,
                                              cd,
                                              Me.txtColor.Text,
                                              ed,
                                              Me.txtLiveArea.Text,
                                              rd,
                                              Me.txtScreen.Text,
                                              Me.txtTrimSize.Text,
                                              Me.txtDensity.Text,
                                              Me.txtFilm.Text,
                                              Me.txtShippingComments.Text,
                                              Me.txtSpecialInstructions.Text,
                                              Me.txtStatus.Text,
                                              Me.txtRegion.Text,
                                              Me.txtADSize.Text)
                    If save = True Then
                        Session("JSAddJobVenRow") = "1"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        'Me.CloseThisWindow()
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If
                If Session("JSaddVen") = 2 Then
                    If Me.txtVendor2.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Function
                    End If
                    If cv.ValidateVendor(Me.txtVendor2.Text) = False Then
                        invalidStr = invalidStr & "Invalid Vendor "
                    End If
                    If Me.txtADSize2.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize2.Text, js.GetMediaType(Me.txtVendor2.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size "
                        End If
                    End If
                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor2.Visible = True
                        Exit Function
                    End If

                    max = js.GetJobSpecMaxSpecID(Me.JobNum, Me.JobCompNum, 2)
                    save = js.AddJobSpecNewRowVendorOut(Me.JobNum,
                                              Me.JobCompNum,
                                              max + 1,
                                              Me.txtVendor2.Text,
                                              Me.txtLocationSign.Text,
                                              Me.txtOverallSize.Text,
                                              Me.txtCopyArea.Text,
                                              Me.txtADSize2.Text)
                    If save = True Then
                        Session("JSAddJobVenRow") = "2"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If

            End If
            If addtype = 3 Then

                Dim oJob As New Job_Specs(Session("ConnString"))
                Dim arP(1) As SqlParameter
                Dim sbJobUpdate As System.Text.StringBuilder = New System.Text.StringBuilder
                sbJobUpdate.Append("UPDATE JOB_SPECS SET ")
                sbJobUpdate.Append(Request.QueryString("Item") & "='" & js.EncodeSQL(Me.txtField.Text))
                sbJobUpdate.Append("' WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.Version & " AND SPEC_REV = " & Me.Revision)
                Try
                    Dim str2 As String = sbJobUpdate.ToString.Replace(",  WHERE", " WHERE")
                    'str2 = str2.Replace("$", "")
                    'str2 = str2.Replace("%", "")
                    If str2 <> "" Then
                        str = oJob.UpdateJob(str2, arP, save).ToString
                    End If
                    If save = True Then
                        Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                    Else
                        Me.ShowMessage("Save Failed!")
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Job NOT Updated! " & ex.Message.ToString)
                    Exit Function
                End Try
            End If
            If addtype = 4 Then
                'Session("JSTemplateNew") = Me.ddJSTemplates.SelectedValue
                Try
                    save = js.AddJobSpecNew(Me.JobNum, Me.JobCompNum, 1, 0, Session("UserCode"), Me.ddJSTemplates.SelectedValue)
                    If save = True Then
                        'Me.ShowMessage("New Version Created")
                        Session("JSNewVersion") = "1"
                        Session("JSNewRevision") = "0"
                        Dim SessionKey As String = "GetJobSpecType" & JobNum.ToString() & JobCompNum.ToString()
                        HttpContext.Current.Session(SessionKey) = Nothing
                    Else
                        Me.ShowMessage("Creation Failed")
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error AddNewjobspecs!<BR />" & ex.Message.ToString())
                End Try
                'Me.CallFunctionOnParentPage("JobTemplate.aspx", "JobSpecs();", True)
                If Me.CurrentQuerystring.IsJobDashboard = True Then
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=1&spectype=" & Me.ddJSTemplates.SelectedValue, True)
                Else
                    Me.CloseThisWindowAndOpenNewWindow("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=1&spectype=" & Me.ddJSTemplates.SelectedValue)
                End If
            End If
            If addtype = 5 Then
                If Me.txtApprovedBy.Text = "" Then
                    Me.ShowMessage("Approved By is required.")
                    Exit Function
                End If
                If Me.RadDatePickerApprovalDate.SelectedDate = Nothing Then
                    Me.ShowMessage("Approval Date is required.")
                    Exit Function
                End If
                If ValidDate(Me.RadDatePickerApprovalDate) = False Then
                    invalidStr = invalidStr & "Invalid Approval Date"
                Else
                    Me.RadDatePickerApprovalDate.SelectedDate = wvCDate(Me.RadDatePickerApprovalDate.SelectedDate)
                End If
                If invalidStr <> "" Then
                    Me.ShowMessage(invalidStr)
                    invalidStr = ""
                    Exit Function
                End If
                delete = js.DeleteJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
                If IsClientPortal = True Then
                    save = js.AddJobSpecApproval(Me.JobNum, Me.JobCompNum, Me.Version, Me.txtApprovedBy.Text, Me.txtComments.Text, "", CDate(Me.RadDatePickerApprovalDate.SelectedDate & " " & Now.ToLongTimeString), Session("UserID"))
                Else
                    save = js.AddJobSpecApproval(Me.JobNum, Me.JobCompNum, Me.Version, Me.txtApprovedBy.Text, Me.txtComments.Text, Session("UserCode"), CDate(Me.RadDatePickerApprovalDate.SelectedDate & " " & Now.ToLongTimeString))
                End If
                If save = True Then
                    Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                Else
                    Me.ShowMessage("Approval save Failed!")
                End If
            End If

        Catch ex As Exception
            Me.ShowMessage("Error Jobspecnewrow!<BR />" & ex.Message.ToString())
        End Try
    End Function

    Private Function UpdateData()
        Try
            Dim dt As DataTable
            Dim js As New Job_Specs(Session("ConnString"))
            Dim cv As New cValidations(Session("ConnString"))
            Dim update As Boolean
            Dim delete As Boolean
            Dim max As Integer
            Dim maxRev As Integer
            Dim invalidStr As String = ""
            Dim str As String
            If addtype = 2 Then
                If Session("JSaddVen") = 1 Then
                    If Me.txtVendor.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Function
                    End If
                    If Me.txtADSize.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize.Text, js.GetMediaType(Me.txtVendor.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size "
                        End If
                    End If
                    If Me.txtStatus.Text <> "" Then
                        If cv.ValidateStatus(Me.txtStatus.Text) = False Then
                            invalidStr = invalidStr & "Invalid Status "
                        End If
                    End If
                    If Me.txtRegion.Text <> "" Then
                        If cv.ValidateRegion(Me.txtRegion.Text) = False Then
                            invalidStr = invalidStr & "Invalid Region "
                        End If
                    End If

                    If MiscFN.ValidDate(Me.RadDatePickerCloseDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Close Date "
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerRunDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Run Date "
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerExtDate, True) = False Then
                        invalidStr = invalidStr & "Invalid Ext Date"
                    End If

                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor1.Visible = True
                        Exit Function
                    End If
                    Dim cd As String = ""
                    Dim ed As String = ""
                    Dim rd As String = ""
                    If Not Me.RadDatePickerCloseDate.SelectedDate Is Nothing Then
                        cd = wvCDate(Me.RadDatePickerCloseDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerExtDate.SelectedDate Is Nothing Then
                        ed = wvCDate(Me.RadDatePickerExtDate.SelectedDate).ToShortDateString
                    End If
                    If Not Me.RadDatePickerRunDate.SelectedDate Is Nothing Then
                        rd = wvCDate(Me.RadDatePickerRunDate.SelectedDate).ToShortDateString
                    End If
                    update = js.UpdateJobSpecNewRowVendorPub(Me.JobNum,
                                              Me.JobCompNum,
                                              Me.specid,
                                              Me.txtVendor.Text,
                                              Me.txtBleedSize.Text,
                                              cd,
                                              Me.txtColor.Text,
                                              ed,
                                              Me.txtLiveArea.Text,
                                              rd,
                                              Me.txtScreen.Text,
                                              Me.txtTrimSize.Text,
                                              Me.txtDensity.Text,
                                              Me.txtFilm.Text,
                                              Me.txtShippingComments.Text,
                                              Me.txtSpecialInstructions.Text,
                                              Me.txtStatus.Text,
                                              Me.txtRegion.Text,
                                              Me.txtADSize.Text)
                    If update = True Then
                        Session("JSAddJobVenRow") = "1"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        If Request.QueryString("jd") = "1" Then
                            Me.CloseThisWindowAndRefreshCaller("Content.aspx?contaid=10&j" & JobNum & "&jc=" & JobCompNum)
                        Else
                            Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                        End If
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If
                If Session("JSaddVen") = 2 Then
                    If Me.txtVendor2.Text = "" Then
                        Me.ShowMessage("Vendor is required.")
                        Exit Function
                    End If
                    If Me.txtADSize2.Text <> "" Then
                        If cv.ValidateAdSize(Me.txtADSize2.Text, js.GetMediaType(Me.txtVendor2.Text)) = False Then
                            invalidStr = invalidStr & "Invalid Ad Size "
                        End If
                    End If
                    If invalidStr <> "" Then
                        Me.ShowMessage(invalidStr)
                        invalidStr = ""
                        Me.pnlNewRowVendor2.Visible = True
                        Exit Function
                    End If
                    update = js.UpdateJobSpecNewRowVendorOut(Me.JobNum,
                                              Me.JobCompNum,
                                              Me.specid,
                                              Me.txtVendor2.Text,
                                              Me.txtLocationSign.Text,
                                              Me.txtOverallSize.Text,
                                              Me.txtCopyArea.Text,
                                              Me.txtADSize2.Text)
                    If update = True Then
                        Session("JSAddJobVenRow") = "2"
                        'Dim FunctionName As String = "HidePopUpWindows"
                        'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                        If Request.QueryString("jd") = "1" Then
                            Me.CloseThisWindowAndRefreshCaller("Content.aspx?contaid=10&j" & JobNum & "&jc=" & JobCompNum)
                        Else
                            Me.CloseThisWindowAndRefreshCaller("jobspecs.aspx")
                        End If
                    Else
                        Me.ShowMessage("Creation of New Row Failed!")
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub RadToolBarVendor_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarVendor.ButtonClick
        Try
            Select Case e.Item.Value
                Case "MediaInformation"

                    loadMediaInfo()

                Case "MediaDeliveryInformation"

                    loadMediaDelivery()

                Case "MediaSpecifications"

                    loadMediaSpecs()

                Case "Save"

                    SaveData()

                Case "Update"

                    UpdateData()

                Case "Cancel"

                    Me.CloseThisWindow()

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

    'TODO: FIX!!!!!!!!!!!!!
    Private Function WriteSpellScript() As String
        Dim sb As New System.Text.StringBuilder
        'With sb
        '    .Append("<script type=""text/javascript"">" & Environment.NewLine)
        '    .Append("/*<![CDATA[*/" & Environment.NewLine)
        '    .Append("function MultipleTextSource(sources)" & Environment.NewLine)
        '    .Append("{" & Environment.NewLine)
        '    .Append("this.sources = sources;" & Environment.NewLine)
        '    .Append("" & Environment.NewLine)
        '    .Append("this.GetText = function()" & Environment.NewLine)
        '    .Append("{" & Environment.NewLine)
        '    .Append("var texts = [];" & Environment.NewLine)
        '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
        '    .Append("{" & Environment.NewLine)
        '    .Append("texts[texts.length] = this.sources[i].getText();" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append("return texts.join(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append(Environment.NewLine)
        '    .Append("this.SetText = function(text)" & Environment.NewLine)
        '    .Append("{" & Environment.NewLine)
        '    .Append("var texts = text.split(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
        '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
        '    .Append("{" & Environment.NewLine)
        '    .Append("this.sources[i].setText(texts[i]);" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append(Environment.NewLine)
        '    .Append("function startSpell()" & Environment.NewLine)
        '    .Append("{    " & Environment.NewLine)
        '    .Append("var sources = " & Environment.NewLine)
        '    .Append("[" & Environment.NewLine)
        '    .Append("new HtmlElementTextSource(document.getElementById('" & Me.txtField.ClientID & "'))," & Environment.NewLine)
        '    .Append("];" & Environment.NewLine)
        '    .Append(Environment.NewLine)
        '    .Append("var spell = GetRadSpell('" & spell1.ClientID & "');" & Environment.NewLine)
        '    .Append("spell.SetTextSource(new MultipleTextSource(sources));" & Environment.NewLine)
        '    .Append("spell.StartSpellCheck();" & Environment.NewLine)
        '    .Append("}" & Environment.NewLine)
        '    .Append("/*]]>*/" & Environment.NewLine)
        '    .Append("</script>" & Environment.NewLine)
        'End With
        Return sb.ToString
    End Function







End Class
