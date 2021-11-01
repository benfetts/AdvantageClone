Imports Telerik.Web.UI

Public Class PurchaseOrder_Search1
    Inherits System.Web.UI.Page
#Region "Variables"

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
End Class