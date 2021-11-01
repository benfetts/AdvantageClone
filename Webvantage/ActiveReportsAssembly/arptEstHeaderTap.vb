Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class arptEstHeaderTap
    Public estnum As Integer
    Public estcompnum As Integer
    Public quotenum As Integer
    Public revnum As Integer
    Public estdate As String
    Public page As String
    Public dt As DataTable
    Public dtInfo As DataTable
    Public addressOption As String
    Public addressInfo As DataTable
    Public dtPrintDef As DataTable
    Public mConnString As String
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public jobcontact As String = ""
    Public rpttype As String
    Public job As Integer
    Public comp As Integer

    Public CultureCode As String = "en-US"
    Private Sub arptEstHeader_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'Me.DataSource = dt
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Dim strCSZ As String = ""
            Me.txtAddressInfo.Text = ""

            Dim dv As DataView = New DataView(addressInfo)
            If addressOption = "Client" Then
                dv.RowFilter = "CL_CODE = '" & client & "'"
                dtInfo = dv.ToTable()
                If dtInfo.Rows.Count > 0 Then
                    If IsDBNull(dtInfo.Rows(0)("CL_NAME")) = False Then
                        Me.txtClient.Text = dtInfo.Rows(0)("CL_NAME")
                    End If
                    'If IsDBNull(dtInfo.Rows(0)("DIV_NAME")) = False Then
                    '    Me.txtDivision.Text = dtInfo.Rows(0)("DIV_NAME")
                    'End If
                    'If IsDBNull(dtInfo.Rows(0)("PRD_DESCRIPTION")) = False Then
                    '    Me.txtProduct.Text = dtInfo.Rows(0)("PRD_DESCRIPTION")
                    'End If
                    If IsDBNull(dtInfo.Rows(0)("CL_ATTENTION")) = False Then
                        Me.txtContact.Text = dtInfo.Rows(0)("CL_ATTENTION")
                    End If
                    If dtInfo.Rows(0)("CL_BADDRESS1").ToString <> "" Then
                        Me.txtAddressInfo.Text &= dtInfo.Rows(0)("CL_BADDRESS1")
                    End If
                    If dtInfo.Rows(0)("CL_BADDRESS2").ToString <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("CL_BADDRESS2")
                    End If
                    If dtInfo.Rows(0)("CL_BCITY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("CL_BCITY")
                    End If
                    If dtInfo.Rows(0)("CL_BSTATE") <> "" Then
                        Me.txtAddressInfo.Text &= ", " & dtInfo.Rows(0)("CL_BSTATE")
                    End If
                    If dtInfo.Rows(0)("CL_BZIP") <> "" Then
                        Me.txtAddressInfo.Text &= " " & dtInfo.Rows(0)("CL_BZIP")
                    End If
                    If dtInfo.Rows(0)("CL_BCOUNTRY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("CL_BCOUNTRY")
                    End If
                End If
            End If
            If addressOption = "Division" Then
                dv.RowFilter = "CL_CODE = '" & client & "' AND DIV_CODE = '" & division & "'"
                dtInfo = dv.ToTable()
                If dtInfo.Rows.Count > 0 Then
                    If IsDBNull(dtInfo.Rows(0)("CL_NAME")) = False Then
                        Me.txtClient.Text = dtInfo.Rows(0)("CL_NAME")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("DIV_NAME")) = False Then
                        Me.txtDivision.Text = dtInfo.Rows(0)("DIV_NAME")
                    End If
                    'If IsDBNull(dtInfo.Rows(0)("PRD_DESCRIPTION")) = False Then
                    '    Me.txtProduct.Text = dtInfo.Rows(0)("PRD_DESCRIPTION")
                    'End If
                    If IsDBNull(dtInfo.Rows(0)("DIV_ATTENTION")) = False Then
                        Me.txtContact.Text = dtInfo.Rows(0)("DIV_ATTENTION")
                    End If
                    If dtInfo.Rows(0)("DIV_BADDRESS1").ToString <> "" Then
                        Me.txtAddressInfo.Text &= dtInfo.Rows(0)("DIV_BADDRESS1")
                    End If
                    If dtInfo.Rows(0)("DIV_BADDRESS2").ToString <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("DIV_BADDRESS2")
                    End If
                    If dtInfo.Rows(0)("DIV_BCITY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("DIV_BCITY")
                    End If
                    If dtInfo.Rows(0)("DIV_BSTATE") <> "" Then
                        Me.txtAddressInfo.Text &= ", " & dtInfo.Rows(0)("DIV_BSTATE")
                    End If
                    If dtInfo.Rows(0)("DIV_BZIP") <> "" Then
                        Me.txtAddressInfo.Text &= " " & dtInfo.Rows(0)("DIV_BZIP")
                    End If
                    If dtInfo.Rows(0)("DIV_BCOUNTRY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("DIV_BCOUNTRY")
                    End If
                End If
            End If
            If addressOption = "Product" Then
                dv.RowFilter = "CL_CODE = '" & client & "' AND DIV_CODE = '" & division & "' AND PRD_CODE = '" & product & "'"
                dtInfo = dv.ToTable()
                If dtInfo.Rows.Count > 0 Then
                    If IsDBNull(dtInfo.Rows(0)("CL_NAME")) = False Then
                        Me.txtClient.Text = dtInfo.Rows(0)("CL_NAME")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("DIV_NAME")) = False Then
                        Me.txtDivision.Text = dtInfo.Rows(0)("DIV_NAME")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("PRD_DESCRIPTION")) = False Then
                        Me.txtProduct.Text = dtInfo.Rows(0)("PRD_DESCRIPTION")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("PRD_ATTENTION")) = False Then
                        Me.txtContact.Text = dtInfo.Rows(0)("PRD_ATTENTION")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_ADDRESS1").ToString <> "" Then
                        Me.txtAddressInfo.Text &= dtInfo.Rows(0)("PRD_BILL_ADDRESS1")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_ADDRESS2").ToString <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("PRD_BILL_ADDRESS2")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_CITY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("PRD_BILL_CITY")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_STATE") <> "" Then
                        Me.txtAddressInfo.Text &= ", " & dtInfo.Rows(0)("PRD_BILL_STATE")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_ZIP") <> "" Then
                        Me.txtAddressInfo.Text &= " " & dtInfo.Rows(0)("PRD_BILL_ZIP")
                    End If
                    If dtInfo.Rows(0)("PRD_BILL_COUNTRY") <> "" Then
                        Me.txtAddressInfo.Text &= vbCrLf & dtInfo.Rows(0)("PRD_BILL_COUNTRY")
                    End If
                End If
            End If
            If addressOption = "Contact" Then
                dv = New DataView(dt)
                dv.RowFilter = "ESTIMATE_NUMBER = '" & estnum & "' AND EST_COMPONENT_NBR = '" & estcompnum & "'"
                dt = dv.ToTable()
                If dt.Rows.Count > 0 Then
                    ' Me.txtClient.Text = ""
                    Me.txtDivision.Text = ""
                    Me.txtProduct.Text = ""
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        Me.txtClient.Text = dt.Rows(0)("CL_NAME")
                    End If
                    'If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                    '    Me.txtDivision.Text = dt.Rows(0)("DIV_NAME")
                    'End If
                    'If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                    '    Me.txtProduct.Text = dt.Rows(0)("PRD_DESCRIPTION")
                    'End If
                    If IsDBNull(dt.Rows(0)("CONT_FML")) = False Then
                        Me.txtContact.Text = dt.Rows(0)("CONT_FML")
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_ADDRESS1")) = False Then
                        If dt.Rows(0)("CONT_ADDRESS1").ToString <> "" Then
                            Me.txtAddressInfo.Text &= dt.Rows(0)("CONT_ADDRESS1")
                        End If
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_ADDRESS2")) = False Then
                        If dt.Rows(0)("CONT_ADDRESS2").ToString <> "" Then
                            Me.txtAddressInfo.Text &= vbCrLf & dt.Rows(0)("CONT_ADDRESS2")
                        End If
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_CITY")) = False Then
                        If dt.Rows(0)("CONT_CITY") <> "" Then
                            Me.txtAddressInfo.Text &= vbCrLf & dt.Rows(0)("CONT_CITY")
                        End If
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_STATE")) = False Then
                        If dt.Rows(0)("CONT_STATE") <> "" Then
                            Me.txtAddressInfo.Text &= ", " & dt.Rows(0)("CONT_STATE")
                        End If
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_ZIP")) = False Then
                        If dt.Rows(0)("CONT_ZIP") <> "" Then
                            Me.txtAddressInfo.Text &= " " & dt.Rows(0)("CONT_ZIP")
                        End If
                    End If
                    If IsDBNull(dt.Rows(0)("CONT_COUNTRY")) = False Then
                        If dt.Rows(0)("CONT_COUNTRY") <> "" Then
                            Me.txtAddressInfo.Text &= vbCrLf & dt.Rows(0)("CONT_COUNTRY")
                        End If
                    End If
                    'If Me.txtCCAddress2.Text <> "" Then
                    '    Me.txtAddressInfo.Text = Me.txtCCAddress.Text & vbCrLf & Me.txtCCAddress2.Text & vbCrLf & Me.txtCCCity.Text & ", " & Me.txtCCState.Text & " " & Me.txtCCZip.Text
                    'Else
                    '    Me.txtAddressInfo.Text = Me.txtCCAddress.Text & vbCrLf & Me.txtCCCity.Text & ", " & Me.txtCCState.Text & " " & Me.txtCCZip.Text
                    'End If
                End If
                'If Me.txtCDPContact.Text <> "" Then

                'End If
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class
