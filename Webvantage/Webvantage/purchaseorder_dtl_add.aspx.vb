Public Class purchaseorder_dtl_add
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _PONumber As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub ModifyGridSettings()

        'If DirectCast(RadToolBar_Options.FindItemByValue("Campaign"), Telerik.Web.UI.RadToolBarButton).Checked Then

        '    RadGrid_JobsOrCampaigns.MasterTableView.DataKeyNames = {"CampaignID"}
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_ClientCode").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_DivisionCode").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_ProductCode").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobNumber").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobDescription").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobComponentNumber").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobComponentDescription").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignID").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignCode").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignDescription").Visible = True

        'ElseIf DirectCast(RadToolBar_Options.FindItemByValue("Job"), Telerik.Web.UI.RadToolBarButton).Checked Then

        '    RadGrid_JobsOrCampaigns.MasterTableView.DataKeyNames = {"ClientCode", "DivisionCode", "ProductCode", "JobNumber", "JobComponentNumber"}
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_ClientCode").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_DivisionCode").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_ProductCode").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobNumber").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobDescription").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobComponentNumber").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_JobComponentDescription").Visible = True
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignID").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignCode").Visible = False
        '    RadGrid_JobsOrCampaigns.MasterTableView.GetColumn("GridBoundColumn_CampaignDescription").Visible = False

        'End If

    End Sub
    Private Sub AddSelectedItems()

        'objects
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
        Dim URLString As String = Nothing

        If RadGrid_Items.SelectedItems.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each GridDataItem In RadGrid_Items.MasterTableView.GetSelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                    Try

                        PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_JobNumber").Text) = False And GridDataItem("GridBoundColumn_JobNumber").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.JobNumber = CInt(GridDataItem("GridBoundColumn_JobNumber").Text)

                        End If

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_JobComponentNumber").Text) = False And GridDataItem("GridBoundColumn_JobComponentNumber").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.JobComponentNumber = CShort(GridDataItem("GridBoundColumn_JobComponentNumber").Text)

                        End If

                        PurchaseOrderDetail.FunctionCode = GridDataItem("GridBoundColumn_FunctionCode").Text

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_Quantity").Text) = False And GridDataItem("GridBoundColumn_Quantity").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.Quantity = CDec(GridDataItem("GridBoundColumn_Quantity").Text)

                        End If

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_Rate").Text) = False And GridDataItem("GridBoundColumn_Rate").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.Rate = CDec(GridDataItem("GridBoundColumn_Rate").Text)

                        End If

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_ExtendedAmount").Text) = False And GridDataItem("GridBoundColumn_ExtendedAmount").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.ExtendedAmount = CDec(GridDataItem("GridBoundColumn_ExtendedAmount").Text)

                        End If

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_MarkupPercent").Text) = False And GridDataItem("GridBoundColumn_MarkupPercent").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.CommissionPercent = CDec(GridDataItem("GridBoundColumn_MarkupPercent").Text)

                        End If

                        If String.IsNullOrEmpty(GridDataItem("GridBoundColumn_ExtendedMarkupAmount").Text) = False And GridDataItem("GridBoundColumn_ExtendedMarkupAmount").Text <> "&nbsp;" Then

                            PurchaseOrderDetail.ExtendedMarkupAmount = CDec(GridDataItem("GridBoundColumn_ExtendedMarkupAmount").Text)

                        End If

                        PurchaseOrderDetail.PurchaseOrderNumber = _PONumber

                        AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

                    Catch ex As Exception

                    End Try

                Next

            End Using

            If Request.QueryString("Fromjj") = "jjpo" Then

                URLString = "purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit&Fromjj=jjpo"

            Else

                URLString = "purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(_PONumber.ToString) & "&pagemode=edit"

            End If

            Me.CloseThisWindowAndRefreshCaller(URLString, True)

        End If

    End Sub
    Private Sub SetupSearchControls()

        Me.HyperLink_Client.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=poestsearch&control=" & Me.TextBox_Client.ClientID & "&type=client&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&job=' + document.forms[0]." & Me.TextBox_Job.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TextBox_Component.ClientID & ".value);return false;")
        Me.HyperLink_Division.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=poestsearch&control=" & Me.TextBox_Division.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&job=' + document.forms[0]." & Me.TextBox_Job.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TextBox_Component.ClientID & ".value);return false;")
        Me.HyperLink_Product.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=poestsearch&control=" & Me.TextBox_Product.ClientID & "&type=product&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&job=' + document.forms[0]." & Me.TextBox_Job.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TextBox_Component.ClientID & ".value);return false;")
        Me.HyperLink_Job.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=poestsearch&type=job&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&job=' + document.forms[0]." & Me.TextBox_Job.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TextBox_Component.ClientID & ".value + '&povendoronly=' + IsPOVendorOnly() + '&VendorCode=' + document.forms[0]." & Me.PO_VenderCode.ClientID & ".value, 'PopLookup5','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
        Me.HyperLink_Component.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=poestsearch&type=jobcomppo&control=" & Me.TextBox_Component.ClientID & "&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&job=' + document.forms[0]." & Me.TextBox_Job.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TextBox_Component.ClientID & ".value + '&povendoronly=' + IsPOVendorOnly() + '&VendorCode=' + document.forms[0]." & Me.PO_VenderCode.ClientID & ".value, 'PopLookup5','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
        Me.HyperLink_Campaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=poestsearch&type=campaign&control=" & Me.TextBox_Campaign.ClientID & "&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&cmpID=' + document.forms[0]." & Me.HiddenField_Campaign.ClientID & ".value + '&povendoronly=' + IsPOVendorOnly() + '&VendorCode=' + document.forms[0]." & Me.PO_VenderCode.ClientID & ".value);return false;")

    End Sub
    Private Function ValidateSearch() As Boolean

        'objects
        Dim Validator As cValidations = Nothing

        Try

            Validator = New cValidations(CStr(Session("ConnString")))

            'If Me.IsClientPortal = True Then

            '    Session("CurrClient") = Session("CL_CODE")
            '    Me.Client = Session("CL_CODE")
            '    Me.TextBox_Client.Text = Session("CL_CODE")

            'End If

            If Me.TextBox_Job.Text <> "" Then

                If Validator.ValidateJobNumber(TextBox_Job.Text) = False Then

                    Me.ShowMessage("This job does not exist")
                    Return False

                End If

            End If

            If TextBox_Job.Text = "" And TextBox_Component.Text <> "" Then

                Me.ShowMessage("Please enter a Job Number")
                Return False

            End If
            If TextBox_Job.Text <> "" And TextBox_Component.Text <> "" Then

                If IsNumeric(TextBox_Job.Text) = False Or IsNumeric(TextBox_Component.Text) = False Then

                    Me.ShowMessage("Job Number and Component must be valid numbers")
                    Return False

                End If

                If Validator.ValidateJobCompNumber(TextBox_Job.Text, TextBox_Component.Text) = False Then

                    Me.ShowMessage("This is not a valid job/component")
                    Return False

                End If

                If Validator.ValidateJobCompIsViewable(Session("UserCode"), TextBox_Job.Text, TextBox_Component.Text) = False Then

                    Me.ShowMessage("Access to this job/comp is denied")
                    Return False

                End If

            End If

            If TextBox_Client.Text <> "" Then

                If Validator.ValidateCDPIsViewable("CL", Session("UserCode"), TextBox_Client.Text, "", "") = False Then

                    Me.ShowMessage("Access to this client is denied")
                    Return False

                End If

            End If

            If TextBox_Division.Text <> "" Then

                If Validator.ValidateCDPIsViewable("DI", Session("UserCode"), TextBox_Client.Text, TextBox_Division.Text, "") = False Then

                    Me.ShowMessage("Access to this division is denied")
                    Return False

                End If

            End If

            If TextBox_Product.Text <> "" Then

                If Validator.ValidateCDPIsViewable("CL", Session("UserCode"), TextBox_Client.Text, TextBox_Division.Text, TextBox_Product.Text) = False Then

                    Me.ShowMessage("Access to this product is denied")
                    Return False

                End If

            End If

            If TextBox_Client.Text <> "" And TextBox_Division.Text <> "" And TextBox_Product.Text <> "" And TextBox_Job.Text <> "" And TextBox_Component.Text <> "" Then

                If Validator.ValidateCDPJCIsViewable(TextBox_Client.Text, TextBox_Division.Text, TextBox_Product.Text, TextBox_Job.Text, TextBox_Component.Text) = False Then

                    Me.ShowMessage("This Job/Comp does not exist for selected Client/Division/Product")
                    Return False

                End If

            End If

            If Me.TextBox_Campaign.Text <> "" Then

                If Validator.ValidateCampaignFilter(Me.TextBox_Client.Text.Trim, Me.TextBox_Division.Text.Trim, Me.TextBox_Product.Text.Trim, Me.TextBox_Campaign.Text.Trim) = False Then

                    Me.ShowMessage("Campaign invalid")
                    Return False

                End If

                If Validator.ValidateCampaignIsViewable(Session("UserCode"), Me.TextBox_Client.Text.Trim, Me.TextBox_Division.Text.Trim, Me.TextBox_Product.Text.Trim, Me.TextBox_Campaign.Text.Trim) = False Then

                    Me.ShowMessage("Access to this campaign is denied")
                    Return False

                End If

            End If

            Return True

        Catch ex As Exception

            Me.ShowMessage("err in search")

        End Try

    End Function

#Region "  Form Event Handlers "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        SetupSearchControls()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim QueryString As New AdvantageFramework.Web.QueryString()
        Dim ModuleCode As String = AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders.ToString

        Me.Title = "Select"

        QueryString = QueryString.FromCurrent()

        Try

            _PONumber = CInt(AdvantageFramework.Security.Encryption.DecryptPO(QueryString("po_number")))

        Catch ex As Exception
            _PONumber = Nothing
        End Try

        If _PONumber > 0 Then

            If Me.IsPostBack = False AndAlso Me.IsCallback = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        PO_VenderCode.Value = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber).VendorCode

                    Catch ex As Exception
                        PO_VenderCode.Value = ""
                    End Try

                End Using

            End If

        Else

            Me.ShowMessage("Error loading PO information!")
            Me.CloseThisWindow()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGrid_Items_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_Items.NeedDataSource

        'objects
        Dim Components As IEnumerable = Nothing
        Dim VendorCode As String = ""
        Dim CampaignID As Integer = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing
        Dim EstimateRevisionDetails As Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail) = Nothing
        Dim AllowedProcessControls As Integer() = {1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 13}

        If String.IsNullOrEmpty(Me.TextBox_Client.Text) = False OrElse String.IsNullOrEmpty(Me.TextBox_Division.Text) = False OrElse String.IsNullOrEmpty(Me.TextBox_Product.Text) = False OrElse
           String.IsNullOrEmpty(Me.TextBox_Job.Text) = False OrElse String.IsNullOrEmpty(Me.TextBox_Component.Text) = False OrElse String.IsNullOrEmpty(Me.TextBox_Campaign.Text) = False Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    EstimateRevisionDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)("exec [advsp_po_load_approved_est] @INCLUDE_CLOSED_COMPS = 0").ToList()

                    If String.IsNullOrEmpty(PO_VenderCode.Value) = False Then

                        VendorCode = CStr(PO_VenderCode.Value)

                    End If

                    If CheckBox_Vendor.Checked Then

                        EstimateRevisionDetails = EstimateRevisionDetails.Where(Function(est) est.VendorCode = VendorCode).ToList

                    End If

                    If String.IsNullOrEmpty(Me.TextBox_Campaign.Text) = False Then

                        If Not String.IsNullOrWhiteSpace(HiddenField_Campaign.Value) Then

                            CampaignID = CInt(Me.HiddenField_Campaign.Value)

                        End If

                        If CampaignID > 0 Then

                            EstimateRevisionDetails = EstimateRevisionDetails.Where(Function(est) est.CampaignID.GetValueOrDefault(0) = CampaignID).ToList

                        Else

                            EstimateRevisionDetails = EstimateRevisionDetails.Where(Function(est) est.CampaignCode = TextBox_Campaign.Text.Trim).ToList

                        End If

                    End If

                    If Not String.IsNullOrWhiteSpace(TextBox_Job.Text) AndAlso IsNumeric(TextBox_Job.Text) Then

                        JobNumber = CInt(TextBox_Job.Text)

                        If Not String.IsNullOrEmpty(Me.TextBox_Component.Text) AndAlso IsNumeric(TextBox_Component.Text) Then

                            JobComponentNumber = CShort(TextBox_Component.Text)

                        End If

                    End If

                    Components = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, TextBox_Client.Text, TextBox_Division.Text, TextBox_Product.Text, JobNumber, False, AllowedProcessControls)
                                  Where Item.JobComponentNumber = If(JobComponentNumber > 0, JobComponentNumber, Item.JobComponentNumber)
                                  Select New With {.JobNumber = Item.JobNumber, .JobComponentNumber = Item.JobComponentNumber}).Distinct.ToArray

                    EstimateRevisionDetails = (From EstRevDetail In EstimateRevisionDetails
                                               Join Component In Components On EstRevDetail.JobNumber Equals Component.JobNumber And EstRevDetail.JobComponentNumber Equals Component.JobComponentNumber
                                               Select EstRevDetail).ToList

                    RadGrid_Items.DataSource = EstimateRevisionDetails.OrderByDescending(Function(est) est.JobNumber).ToList

                Catch ex As Exception
                    RadGrid_Items.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)
                End Try

            End Using

        Else

            RadGrid_Items.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)

        End If

    End Sub
    Private Sub RadToolBar_Options_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar_Options.ButtonClick

        Select Case e.Item.Value

            Case "Search"

                Me.ValidateSearch()
                RadGrid_Items.Rebind()

            Case "Clear"

                Me.TextBox_Client.Text = ""
                Me.TextBox_Division.Text = ""
                Me.TextBox_Product.Text = ""
                Me.TextBox_Job.Text = ""
                Me.TextBox_Component.Text = ""
                Me.TextBox_Campaign.Text = ""
                Me.HiddenField_Campaign.Value = ""
                Me.CheckBox_Vendor.Checked = False

                RadGrid_Items.MasterTableView.CurrentPageIndex = 0
                RadGrid_Items.Rebind()

            Case "Add"

                AddSelectedItems()

        End Select

    End Sub
    Private Sub TextBox_Campaign_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Campaign.TextChanged

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignCode(DbContext, TextBox_Campaign.Text)

            If Campaign IsNot Nothing Then

                TextBox_Client.Text = Campaign.ClientCode
                TextBox_Division.Text = Campaign.DivisionCode
                TextBox_Product.Text = Campaign.ProductCode

                HiddenField_Campaign.Value = Campaign.ID

            Else

                HiddenField_Campaign.Value = Nothing

            End If

        End Using

    End Sub

#End Region

#End Region

End Class
