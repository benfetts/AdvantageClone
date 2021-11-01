Imports Webvantage.cGlobals
Partial Public Class purchaseorder_search
    Inherits System.Web.UI.UserControl
    Public Event Search_Clicked()
    Public Event Clear_Search_Clicked()

#Region "Variables"

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPanelControls()
        SetPickListItems()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
            Me.hlIssuedBy.Enabled = False
            Me.hlIssuedBy.Attributes.Add("onclick", "")
            Me.txtIssuedBy.ReadOnly = True
        End If
        If Not Page.IsPostBack Then
            'handle immediate redirect to PO if enter key pressed within PO Field.
            'Me.txt_PO.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Me.btn_Search.UniqueID + "').click();return false;}} else {return true}; ")

            'Me.hl_job.NavigateUrl = "http://"
            'Me.hl_client.NavigateUrl = "http://"
            'Me.hl_division.NavigateUrl = "http://"
            'Me.hl_product.NavigateUrl = "http://"
            'Me.hl_vend.NavigateUrl = "http://"
            'Me.hl_emp_code.NavigateUrl = "http://"
            
        End If

    End Sub
    Public Sub SetPanelControls()
        Try

            Me.hlPONumber.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=poApproval&type=polist&void=' + document.forms[0]." & Me.cbOmitVoid.ClientID & ".checked + '&closed=' + document.forms[0]." & Me.cbOmitClosed.ClientID & ".checked);return false;")
            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=posearch&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=posearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=posearch&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=popanel&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value, 'PopLookup5','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=popanel&type=jobcomppo&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value, 'PopLookup5','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            Me.hlApprover.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=po&control=" & Me.txtApprover.ClientID & "&type=approver');return false;")

            If Not Session("CurrPOSearchddoptions") Is Nothing Then
                Me.dl_options.SelectedValue = Session("CurrPOSearchddoptions")
            End If
            If Not Session("CurrPOSearchDesc") Is Nothing Then
                Me.txtDescription.Text = Session("CurrPOSearchDesc")
            End If
            If Not Session("CurrPOSearchJob") Is Nothing Then
                Me.txtJob.Text = Session("CurrPOSearchJob")
            End If
            If Not Session("CurrPOSearchComp") Is Nothing Then
                Me.txtComponent.Text = Session("CurrPOSearchComp")
            End If
            If Not Session("CurrPOSearchClient") Is Nothing Then
                Me.txtClient.Text = Session("CurrPOSearchClient")
            End If
            If Not Session("CurrPOSearchDivision") Is Nothing Then
                Me.txtDivision.Text = Session("CurrPOSearchDivision")
            End If
            If Not Session("CurrPOSearchProduct") Is Nothing Then
                Me.txtProduct.Text = Session("CurrPOSearchProduct")
            End If
            If Not Session("CurrPOSearchFromDate") Is Nothing Then
                Me.RadDatePickerIssueFromDate.SelectedDate = Session("CurrPOSearchFromDate")
            End If
            If Not Session("CurrPOSearchToDate") Is Nothing Then
                Me.RadDatePickerIssueToDate.SelectedDate = Session("CurrPOSearchToDate")
            End If
            If Not Session("CurrPOSearchDueDate") Is Nothing Then
                Me.RadDatePickerDueDate.SelectedDate = Session("CurrPOSearchDueDate")
            End If
            If Not Session("CurrPOSearchVendor") Is Nothing Then
                Me.txtVendor.Text = Session("CurrPOSearchVendor")
            End If
            If Not Session("CurrPOSearchIssuedBy") Is Nothing Then
                Me.txtIssuedBy.Text = Session("CurrPOSearchIssuedBy")
            End If
            If Not Session("CurrPOSearchApprover") Is Nothing Then
                Me.txtApprover.Text = Session("CurrPOSearchApprover")
            End If
            If Not Session("CurrPOSearchPOStatus") Is Nothing Then
                Me.ddPOStatus.SelectedValue = Session("CurrPOSearchPOStatus")
            End If
            If Not Session("CurrPOSearchPrinted") Is Nothing Then
                Me.cbPrinted.Checked = Session("CurrPOSearchPrinted")
            End If
            If Not Session("CurrPOSearchOmitVoided") Is Nothing Then
                Me.cbOmitVoid.Checked = Session("CurrPOSearchOmitVoided")
            End If
            If Not Session("CurrPOSearchOmitClosed") Is Nothing Then
                Me.cbOmitClosed.Checked = Session("CurrPOSearchOmitClosed")
            End If
            Session("CurrPOSearchddoptions") = Nothing
            Session("CurrPOSearchDesc") = Nothing
            Session("CurrPOSearchJob") = Nothing
            Session("CurrPOSearchComp") = Nothing
            Session("CurrPOSearchClient") = Nothing
            Session("CurrPOSearchDivision") = Nothing
            Session("CurrPOSearchProduct") = Nothing
            Session("CurrPOSearchFromDate") = Nothing
            Session("CurrPOSearchToDate") = Nothing
            Session("CurrPOSearchDueDate") = Nothing
            Session("CurrPOSearchVendor") = Nothing
            Session("CurrPOSearchIssuedBy") = Nothing
            Session("CurrPOSearchApprover") = Nothing
            Session("CurrPOSearchPOStatus") = Nothing
            Session("CurrPOSearchPrinted") = Nothing
            Session("CurrPOSearchOmitVoided") = Nothing
            Session("CurrPOSearchOmitClosed") = Nothing
        Catch ex As Exception
            'Me.ShowMessage(ex.Message.ToString())
            'Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
    Public WriteOnly Property TabIndex_Start() As Integer
        Set(ByVal value As Integer)
            If value >= 0 Then
                Me.txtPONumber.TabIndex = value
                Me.txtPONumber.Focus()
                Me.txtDescription.TabIndex = value + 1
                Me.txtJob.TabIndex = value + 2
                Me.txtComponent.TabIndex = value + 3
                Me.txtClient.TabIndex = value + 4
                Me.txtDivision.TabIndex = value + 5
                Me.txtProduct.TabIndex = value + 6
                Me.RadDatePickerIssueFromDate.TabIndex = value + 7
                Me.RadDatePickerIssueToDate.TabIndex = value + 8
                Me.RadDatePickerDueDate.TabIndex = value + 9
                Me.txtVendor.TabIndex = value + 10
                Me.txtIssuedBy.TabIndex = value + 11
                Me.txtApprover.TabIndex = value + 12
                Me.ddPOStatus.TabIndex = value + 13
                Me.cbPrinted.TabIndex = value + 14
                Me.cbOmitVoid.TabIndex = value + 15
                Me.cbOmitClosed.TabIndex = value + 16
                'Me.txt_PO.TabIndex = value
                'Me.txt_Descrip.TabIndex = value + 1
                'Me.txt_Issued.TabIndex = value + 2
                'Me.txt_Issued_End.TabIndex = value + 3
                'Me.txt_due.TabIndex = value + 4
                'Me.txtJob.TabIndex = value + 5
                'Me.txtJobComp.TabIndex = value + 6
                'Me.txtClient.TabIndex = value + 7
                'Me.txtDivision.TabIndex = value + 8
                'Me.txtProduct.TabIndex = value + 9
                'Me.txt_ven_code.TabIndex = value + 10
                'Me.txt_emp_code.TabIndex = value + 11
                'Me.btn_Search.TabIndex = 15
                'Me.btn_Clear.TabIndex = 16
            End If

        End Set
    End Property
    Public Sub Focus_PO_Field()
        'Me.txt_PO.Focus()
        Me.txtPONumber.Focus()
    End Sub
    Public Sub SetPickListItems()

        Dim str As String = Me.txtClient.ClientID
        Dim str3 As String = Me.txtDivision.ClientID
        Dim str4 As String = Me.txtProduct.ClientID
        Dim str5 As String = Me.txtJob.ClientID
        Dim str2 As String = Me.txtComponent.ClientID
        'Me.ibtn_sel_issue_dt.Attributes.Add("onclick", "window.open('popCalendar.aspx?textbox=" & Me.txtIssueFromDate.ClientID & "&seldate=' + document.forms[0]." & Me.txtIssueFromDate.ClientID & ".value,'cal','width=175,height=175,left=270,top=180');return false;")
        'Me.ibtn_sel_due_dt.Attributes.Add("onclick", "window.open('popCalendar.aspx?textbox=" & Me.txtDueDate.ClientID & "&seldate=' + document.forms[0]." & Me.txtDueDate.ClientID & ".value,'cal2','width=175,height=175,left=270,top=180');return false;")
        'Me.ibtn_sel_issue_end_dt.Attributes.Add("onclick", "window.open('popCalendar.aspx?textbox=" & Me.txtIssueToDate.ClientID & "&seldate=' + document.forms[0]." & Me.txtIssueToDate.ClientID & ".value,'cal3','width=175,height=175,left=270,top=180');return false;")

        Me.hlIssuedBy.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.txtIssuedBy.ClientID & "');return false;")
        Me.hlVendor.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=purchaseorder_search&type=vendor_and_contact&control=" & Me.txtVendor.ClientID & "');return false;")

    End Sub
    Public Property Filter_Options() As String
        Get
            Return dl_options.SelectedValue.Trim
        End Get
        Set(ByVal value As String)
            dl_options.FindItemByValue(value.Trim).Selected = True
        End Set
    End Property

    Public Property PO_Number() As String
        Get
            Return txtPONumber.Text.Trim
        End Get
        Set(ByVal value As String)
            txtPONumber.Text = value.Trim
        End Set
    End Property
    Public Property PO_NumberHf() As String
        Get
            Return Me.hfPONumber.Value
        End Get
        Set(ByVal value As String)
            Me.hfPONumber.Value = value.Trim
        End Set
    End Property
    Public Property PO_Description() As String
        Get
            Return txtDescription.Text.Trim
        End Get
        Set(ByVal value As String)
            txtDescription.Text = value.Trim
        End Set
    End Property
    Public Property PO_Issue_Date() As String
        Get
            If Not Me.RadDatePickerIssueFromDate.SelectedDate Is Nothing Then
                Return LoGlo.FormatDate(RadDatePickerIssueFromDate.SelectedDate)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            RadDatePickerIssueFromDate.SelectedDate = LoGlo.FormatDate(value.Trim)
        End Set
    End Property
    Public Property PO_Issue_End_Date() As String
        Get
            If Not Me.RadDatePickerIssueToDate.SelectedDate Is Nothing Then
                Return RadDatePickerIssueToDate.SelectedDate
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            RadDatePickerIssueToDate.SelectedDate = value.Trim
        End Set
    End Property
    Public Property PO_Due_Date() As String
        Get
            If Not RadDatePickerDueDate.SelectedDate Is Nothing Then
                Return RadDatePickerDueDate.SelectedDate
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            RadDatePickerDueDate.SelectedDate = value.Trim
        End Set
    End Property
    Public Property PO_Vendor_Code() As String
        Get
            Return txtVendor.Text
        End Get
        Set(ByVal value As String)
            txtVendor.Text = value.Trim
        End Set
    End Property
    Public Property PO_Emp_Code() As String
        Get
            Return txtIssuedBy.Text.Trim
        End Get
        Set(ByVal value As String)
            txtIssuedBy.Text = value.Trim
        End Set
    End Property
    Public Property PO_Job_Number() As String
        Get
            Return txtJob.Text.Trim
        End Get
        Set(ByVal value As String)
            txtJob.Text = value.Trim
        End Set
    End Property
    Public Property PO_Job_Comp_Nbr() As String
        Get
            Return Me.txtComponent.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtComponent.Text = value.Trim
        End Set
    End Property
    Public Property PO_Cient_Code() As String
        Get
            Return txtClient.Text.Trim
        End Get
        Set(ByVal value As String)
            txtClient.Text = value.Trim
        End Set
    End Property
    Public Property PO_Division_Code() As String
        Get
            Return txtDivision.Text.Trim
        End Get
        Set(ByVal value As String)
            txtDivision.Text = value.Trim
        End Set
    End Property
    Public Property PO_Product_Code() As String
        Get
            Return txtProduct.Text.Trim
        End Get
        Set(ByVal value As String)
            txtProduct.Text = value.Trim
        End Set
    End Property
    Public Property PO_Request_Status() As String
        Get
            Return Me.ddPOStatus.SelectedValue.Trim
        End Get
        Set(ByVal value As String)
            ddPOStatus.Items.FindItemByValue(value.Trim).Selected = True
        End Set
    End Property
    Public Property PO_Printed() As Boolean
        Get
            Return Me.cbPrinted.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.cbPrinted.Checked = value
        End Set
    End Property
    Public Property PO_Approver_Code() As String
        Get
            Return txtApprover.Text.Trim
        End Get
        Set(ByVal value As String)
            txtApprover.Text = value.Trim
        End Set
    End Property
    Public Property PO_Voided() As Boolean
        Get
            Return Me.cbOmitVoid.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.cbOmitVoid.Checked = value
        End Set
    End Property
    Public Property PO_Closed() As Boolean
        Get
            Return Me.cbOmitClosed.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.cbOmitClosed.Checked = value
        End Set
    End Property

    Public Sub ClearSearchCriteria()
        txtPONumber.Text = ""
        txtDescription.Text = ""
        RadDatePickerIssueFromDate.SelectedDate = Nothing
        RadDatePickerIssueToDate.SelectedDate = Nothing
        RadDatePickerDueDate.SelectedDate = Nothing
        txtVendor.Text = ""
        txtIssuedBy.Text = ""
        txtJob.Text = ""
        txtComponent.Text = ""
        txtClient.Text = ""
        txtDivision.Text = ""
        txtProduct.Text = ""
        txtApprover.Text = ""
        Me.ddPOStatus.SelectedValue = 0
        Me.cbPrinted.Checked = False
        Me.cbOmitVoid.Checked = False
        Me.cbOmitClosed.Checked = False
        'txt_PO.Text = ""
        'txt_Descrip.Text = ""
        'txt_Issued.Text = ""
        'txt_Issued_End.Text = ""
        'txt_due.Text = ""
        'txt_ven_code.Text = ""
        'txt_emp_code.Text = ""
        'txtJob.Text = ""
        'txtJobComp.Text = ""
        'txtClient.Text = ""
        'txtDivision.Text = ""
        'txtProduct.Text = ""

    End Sub

End Class