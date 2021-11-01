Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptBillingApprovalReport
    Public logopath As String
    Public LogoID As String
    Public imgPath As String
    Public clname As String
    Public printDivName As String
    Public printPrdDesc As String
    Public title As String
    Public clfooter As String
    Public addressOption As String
    Public estComment As String
    Public addressInfo As DataTable
    Public dt As DataTable
    Public dtLocation As DataTable


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            Dim strCSZ As String = ""
            If dtLocation.Rows.Count > 0 Then
                If IsDBNull(dtLocation.Rows(0)("PRT_NAME")) = False Then
                    If dtLocation.Rows(0)("PRT_NAME") <> "1" Then
                        Me.txtName.Text = ""
                    Else
                        Me.txtName.Text = dtLocation.Rows(0)("NAME")
                    End If
                End If
                'Agency Information
                If IsDBNull(dtLocation.Rows(0)("PRT_ADDR1")) = False Then
                    If dtLocation.Rows(0)("PRT_ADDR1") = "1" And IsDBNull(dtLocation.Rows(0)("ADDRESS1")) = False Then
                        Me.txtAddress1.Text = dtLocation.Rows(0)("ADDRESS1")
                    Else
                        Me.txtAddress1.Text = ""
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_ADDR2")) = False Then
                    If dtLocation.Rows(0)("PRT_ADDR2") = "1" And IsDBNull(dtLocation.Rows(0)("ADDRESS2")) = False Then
                        Me.txtAddress2.Text = dtLocation.Rows(0)("ADDRESS2")
                    Else
                        Me.txtAddress2.Text = ""
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_CITY")) = False Then
                    If dtLocation.Rows(0)("PRT_CITY") = "1" And IsDBNull(dtLocation.Rows(0)("CITY")) = False Then
                        strCSZ = strCSZ & dtLocation.Rows(0)("CITY")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_STATE")) = False Then
                    If dtLocation.Rows(0)("PRT_STATE") = "1" And IsDBNull(dtLocation.Rows(0)("STATE")) = False Then
                        If strCSZ <> "" Then
                            strCSZ = strCSZ & " "
                        End If
                        strCSZ = strCSZ & dtLocation.Rows(0)("STATE")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_ZIP")) = False Then
                    If dtLocation.Rows(0)("PRT_ZIP") = "1" And IsDBNull(dtLocation.Rows(0)("ZIP")) = False Then
                        If strCSZ <> "" Then
                            strCSZ = strCSZ & " "
                        End If
                        strCSZ = strCSZ & dtLocation.Rows(0)("ZIP")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_PHONE")) = False Then
                    If dtLocation.Rows(0)("PRT_PHONE") = "1" And IsDBNull(dtLocation.Rows(0)("PHONE")) = False Then
                        Me.txtPhone.Text = dtLocation.Rows(0)("PHONE")
                    Else
                        Me.txtPhone.Text = ""
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_FAX")) = False Then
                    If dtLocation.Rows(0)("PRT_FAX") = "1" And IsDBNull(dtLocation.Rows(0)("FAX")) = False Then
                        Me.txtFax.Text = dtLocation.Rows(0)("FAX")
                    Else
                        Me.txtFax.Text = ""
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_EMAIL")) = False Then
                    If dtLocation.Rows(0)("PRT_EMAIL") = "1" And IsDBNull(dtLocation.Rows(0)("EMAIL")) = False Then
                        Me.txtEmail.Text = dtLocation.Rows(0)("EMAIL")
                    Else
                        Me.txtEmail.Text = ""
                    End If
                End If

                If strCSZ <> "" Then
                    Me.txtCityStateZip.Text = strCSZ
                Else
                    Me.txtCityStateZip.Text = ""
                End If

                If Me.txtAddress1.Text <> "" Then
                    Me.txtAddress1.Text = Me.txtAddress1.Text
                End If
                If Me.txtAddress2.Text <> "" Then
                    If Me.txtAddress1.Text <> "" Then
                        Me.txtAddress1.Text &= " • "
                    End If
                    Me.txtAddress1.Text &= Me.txtAddress2.Text
                End If

                If Me.txtCityStateZip.Text <> "" Then
                    If Me.txtAddress1.Text <> "" Then
                        Me.txtAddress1.Text &= " • "
                    End If
                    Me.txtAddress1.Text &= Me.txtCityStateZip.Text
                End If

                If Me.txtPhone.Text <> "" Then
                    If Me.txtAddress1.Text <> "" Then
                        Me.txtAddress1.Text &= " • "
                    End If
                    Me.txtAddress1.Text &= Me.txtPhone.Text
                End If
                If Me.txtFax.Text <> "" Then
                    If Me.txtAddress1.Text <> "" Then
                        Me.txtAddress1.Text &= " • "
                    End If
                    Me.txtAddress1.Text &= Me.txtFax.Text & " Fax"
                End If
                If Me.txtEmail.Text <> "" Then
                    If Me.txtAddress1.Text <> "" Then
                        Me.txtAddress1.Text &= " • "
                    End If
                    Me.txtAddress1.Text &= Me.txtEmail.Text
                End If
                Me.txtFedID.Text = ""
                If IsDBNull(dtLocation.Rows(0)("PRT_HEADER")) = False Then
                    If dtLocation.Rows(0)("PRT_HEADER") <> "1" Then
                        Me.txtAddress1.Text = ""
                        Me.txtName.Text = ""
                    End If
                Else
                    Me.txtAddress1.Text = ""
                    Me.txtName.Text = ""
                End If
            Else
                Me.txtName.Text = ""
                Me.txtAddress1.Text = ""
                Me.txtAddress2.Text = ""
                Me.txtCityStateZip.Text = ""
                Me.txtPhone.Text = ""
                Me.txtFax.Text = ""
                Me.txtEmail.Text = ""
                Me.txtFedID.Text = ""
            End If


            If addressOption = "Client" Then
                If addressInfo.Rows.Count > 0 Then
                    Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
                    Me.txtDivision.Text = "" 'addressInfo.Rows(0)("DIV_NAME")
                    Me.txtProduct.Text = "" 'addressInfo.Rows(0)("PRD_DESCRIPTION")
                    Me.txtContact.Text = addressInfo.Rows(0)("CL_ATTENTION")
                    Me.TextBox9.Text = ""
                    Me.txtAddressInfo.Text = addressInfo.Rows(0)("CL_BADDRESS1")
                    Me.txtCSZ.Text = addressInfo.Rows(0)("CL_BCITY") & ", " & addressInfo.Rows(0)("CL_BSTATE") & " " & addressInfo.Rows(0)("CL_BZIP")
                End If
            End If
            If addressOption = "Division" Then
                If addressInfo.Rows.Count > 0 Then
                    Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
                    Me.txtDivision.Text = addressInfo.Rows(0)("DIV_NAME")
                    Me.txtProduct.Text = "" 'addressInfo.Rows(0)("PRD_DESCRIPTION")
                    Me.txtContact.Text = addressInfo.Rows(0)("DIV_ATTENTION")
                    Me.TextBox9.Text = ""
                    Me.txtAddressInfo.Text = addressInfo.Rows(0)("DIV_BADDRESS1")
                    Me.txtCSZ.Text = addressInfo.Rows(0)("DIV_BCITY") & ", " & addressInfo.Rows(0)("DIV_BSTATE") & " " & addressInfo.Rows(0)("DIV_BZIP")
                End If
            End If
            If addressOption = "Product" Then
                If addressInfo.Rows.Count > 0 Then
                    Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
                    Me.txtDivision.Text = addressInfo.Rows(0)("DIV_NAME")
                    Me.txtProduct.Text = addressInfo.Rows(0)("PRD_DESCRIPTION")
                    Me.txtContact.Text = addressInfo.Rows(0)("PRD_ATTENTION")
                    Me.TextBox9.Text = ""
                    Me.txtAddressInfo.Text = addressInfo.Rows(0)("PRD_BILL_ADDRESS1")
                    Me.txtCSZ.Text = addressInfo.Rows(0)("PRD_BILL_CITY") & ", " & addressInfo.Rows(0)("PRD_BILL_STATE") & " " & addressInfo.Rows(0)("PRD_BILL_ZIP")
                End If
            End If
            If addressOption = "Contact" Then
                'If addressInfo.Rows.Count > 0 Then
                Me.txtClient.Text = clname
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtContact.Text = Me.txtCDPContact.Text
                Me.txtAddressInfo.Text = Me.txtCCAddress.Text
                If Me.TextBox8.Text <> "" Then
                    Me.txtAddressInfo.Text = Me.txtAddressInfo.Text & vbCrLf & Me.TextBox8.Text
                End If
                Me.txtAddressInfo.Text = Me.txtAddressInfo.Text & vbCrLf & Me.txtCCCity.Text & ", " & Me.txtCCState.Text & " " & Me.txtCCZip.Text
                'End If
            End If
            'If Me.txtCDPContact.Text <> "" Then
            '    Me.txtContact.Text = Me.txtCDPContact.Text
            'End If
            If title <> "" Then
                Me.txtTitle.Text = title
            End If
            If Me.printDivName = "False" Then
                Me.txtDivision.Text = ""
            Else
                ' Me.txtDivision.Visible = True
            End If
            If Me.printPrdDesc = "False" Then
                Me.txtProduct.Text = ""
            Else
                ' Me.txtProduct.Visible = True
            End If

            If Me.logopath <> "" Then
                Dim f As New IO.FileInfo(Me.logopath)
                If f.Exists Then
                    Me.Picture1.Image = Drawing.Image.FromFile(Me.logopath)
                Else
                    Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If
            Else
                Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptBillingApproval_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            Me.DataSource = dt
            If Me.LogoID = "None" Then
                Me.PageHeader1.Controls.Remove(Me.Picture1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            Me.txtPORNumber.Text = Me.txtPORNumber.Text.PadLeft(6, "0")
            If Me.txtDate.Text <> "" Then
                Me.txtDate.Text = CDate(Me.txtDate.Text).ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Me.txtFunctionAmt.Text = String.Format("{0:#,##0.00}", CDbl(Me.txtFunctionAmt.Text))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            Me.txtJobNumber.Text = Me.txtJobNumber.Text.PadLeft(6, "0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Try
            Dim footer As String = ""
            Dim CSZ As String = ""
            Me.txtTerms.Text = ""
            If dtLocation.Rows.Count > 0 Then
                If IsDBNull(dtLocation.Rows(0)("PRT_NAME_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_NAME_FTR") = "1" Then
                        footer = dtLocation.Rows(0)("NAME")
                    End If
                End If
                'Agency Information
                If IsDBNull(dtLocation.Rows(0)("PRT_ADDR1_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_ADDR1_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("ADDRESS1")) = False Then
                        If footer <> "" Then
                            footer &= " • "
                        End If
                        footer &= dtLocation.Rows(0)("ADDRESS1")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_ADDR2_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_ADDR2_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("ADDRESS2")) = False Then
                        If footer <> "" Then
                            footer &= " • "
                        End If
                        footer &= dtLocation.Rows(0)("ADDRESS2")
                    End If
                End If

                'Gather city/state/zip separately
                If IsDBNull(dtLocation.Rows(0)("PRT_CITY_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_CITY_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("CITY")) = False Then
                        CSZ = dtLocation.Rows(0)("CITY")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_STATE_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_STATE_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("STATE")) = False Then
                        If CSZ <> "" Then
                            CSZ &= " "
                        End If
                        CSZ &= dtLocation.Rows(0)("STATE")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_ZIP_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_ZIP_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("ZIP")) = False Then
                        If CSZ <> "" Then
                            CSZ &= " "
                        End If
                        CSZ &= dtLocation.Rows(0)("ZIP")
                    End If
                End If

                'add CSZ to footer here
                If CSZ <> "" Then
                    If footer <> "" Then
                        footer &= " • "
                    End If
                    footer &= CSZ
                End If

                If IsDBNull(dtLocation.Rows(0)("PRT_PHONE_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_PHONE_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("PHONE")) = False Then
                        If footer <> "" Then
                            footer &= " • "
                        End If

                        footer &= dtLocation.Rows(0)("PHONE")
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_FAX_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_FAX_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("FAX")) = False Then
                        If footer <> "" Then
                            footer &= " • "
                        End If

                        footer &= dtLocation.Rows(0)("FAX") & " Fax"
                    End If
                End If
                If IsDBNull(dtLocation.Rows(0)("PRT_EMAIL_FTR")) = False Then
                    If dtLocation.Rows(0)("PRT_EMAIL_FTR") = "1" And IsDBNull(dtLocation.Rows(0)("EMAIL")) = False Then
                        If footer <> "" Then
                            footer &= " • "
                        End If

                        footer &= dtLocation.Rows(0)("EMAIL")
                    End If
                End If

                If IsDBNull(dtLocation.Rows(0)("PRT_FOOTER")) = False Then
                    If dtLocation.Rows(0)("PRT_FOOTER") <> "1" Then
                        Me.txtTerms.Text = ""
                    Else
                        Me.txtTerms.Text = footer
                    End If
                Else
                    Me.txtTerms.Text = ""
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter4.Format

    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        Try
            Me.txtSalesTaxAmt.Text = String.Format("{0:#,##0.00}", CDbl(Me.txtSalesTaxAmt.Text))
            Me.txtTotal.Text = String.Format("{0:#,##0.00}", (CDbl(Me.txtTotal.Text) + CDbl(Me.txtSalesTaxAmt.Text)))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If Me.txtClientPO.Text = "" Then
                Me.TextBox4.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader4_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.BeforePrint
        Try
            Me.txtApprovedAmount.Text = String.Format("{0:#,##0.00}", CDbl(Me.txtApprovedAmount.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.Format
        Try

            Me.txtJobCompNum.Text = Me.txtJobCompNum.Text.PadLeft(2, "0")
            ReportFunctions.SetBillingApprovalBillingRateLabel(Me.txtQtyHours.Text, Me.txtBillingRate.Text)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Try
            Me.txtEstComment.Text = Me.estComment
        Catch ex As Exception

        End Try
    End Sub
End Class
