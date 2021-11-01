Imports Webvantage.cGlobals
Imports System.Data.Sql
Imports System.Data.SqlClient

Partial Public Class VendorQuote_Contacts
    Inherits Webvantage.BaseChildPage

    Private EstimateNum As Integer = 0
    Private EstimateComp As Integer = 0
    Private VendorQuoteNbr As Integer = 0
    Private EstimateQuote As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Private VnCode As String
    Private VnContact As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            EstimateNum = CType(Request.QueryString("EstNum"), Integer)
        Catch ex As Exception
            EstimateNum = 0
        End Try
        Try
            EstimateComp = CType(Request.QueryString("EstComp"), Integer)
        Catch ex As Exception
            EstimateComp = 0
        End Try
        Try
            VendorQuoteNbr = CType(Request.QueryString("reqNum"), Integer)
        Catch ex As Exception
            VendorQuoteNbr = 0
        End Try
        Try
            EstimateQuote = CType(Request.QueryString("EstQuote"), Integer)
        Catch ex As Exception
            EstimateQuote = 0
        End Try
        Try
            RevNum = CType(Request.QueryString("RevNum"), Integer)
        Catch ex As Exception
            RevNum = 0
        End Try
        Try
            VnCode = Request.QueryString("VnCode")
        Catch ex As Exception
            VnCode = ""
        End Try
        Try
            VnContact = Request.QueryString("Contact")
        Catch ex As Exception
            VnContact = ""
        End Try

        If Not Me.IsPostBack Then
            If Request.QueryString("type") = "New" Then

            ElseIf Request.QueryString("type") = "Edit" Then
                Me.LoadContact()
                Me.BtnSave.Visible = False
                Me.BtnUpdate.Visible = True
                Me.txtVendorContactCode.ReadOnly = True
            End If
            Me.txtVendor.Text = VnCode
        End If
        Me.LoadLookups()
    End Sub

    Private Sub LoadLookups()
    End Sub

    Private Sub LoadContact()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            dr = est.GetContact(VnCode, VnContact, Session("UserCode"))
            If dr.HasRows = True Then
                Do While dr.Read
                    Me.txtVendor.Text = dr("VN_NAME")
                    Me.txtVendorContactCode.Text = dr("VC_CODE")
                    Me.txtFirstName.Text = dr("VC_FNAME")
                    Me.txtLastName.Text = dr("VC_LNAME")
                    Me.txtMI.Text = dr("VC_MI")
                    Me.txtTitle.Text = dr("VC_TITLE")
                    Me.txtAddress1.Text = dr("VC_ADDRESS1")
                    Me.txtAddress2.Text = dr("VC_ADDRESS2")
                    Me.txtCity.Text = dr("VC_CITY")
                    Me.txtCounty.Text = dr("VC_COUNTY")
                    Me.txtState.Text = dr("VC_STATE")
                    Me.txtCountry.Text = dr("VC_COUNTRY")
                    Me.txtZip.Text = dr("VC_ZIP")
                    Me.txtPhone.Text = dr("VC_TELEPHONE")
                    Me.txtPhoneExt.Text = dr("VC_EXTENTION")
                    Me.txtFax.Text = dr("VC_FAX")
                    Me.txtFaxExt.Text = dr("VC_FAX_EXTENTION")
                    Me.txtEmailAddress.Text = dr("EMAIL_ADDRESS")
                    Me.txtCell.Text = dr("VC_PHONE_CELL")
                Loop
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        '.Text = TheMSG
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String = "RefreshFileGrid"
        If Request.QueryString("from") = "popvc" Then
            If Not String.IsNullOrEmpty(Request.QueryString("fromNewLookup")) Then
                Me.RefreshCaller("ModalFilterDialog.aspx", False, False, False)
                Me.SimpleClose()

            Else
                Me.RefreshCaller("LookUp_Vendor.aspx", False, False, False)
                Me.SimpleClose()
            End If
        Else
            Me.SimpleClose()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            If Me.txtVendorContactCode.Text = "" Then
                Me.lblMSG.Text = "Vendor Contact Code is required."
                Exit Sub
            End If
            Dim save As Boolean
            save = est.AddNewContact(VnCode, Me.txtVendorContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                     Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                     Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text)
            CloseAndRefresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            If Me.txtVendorContactCode.Text = "" Then
                Me.lblMSG.Text = "Vendor Contact Code is required."
                Exit Sub
            End If
            Dim update As Boolean
            update = est.UpdateContact(VnCode, Me.txtVendorContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                     Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                     Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text)
            CloseAndRefresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.SimpleClose()
    End Sub

End Class
