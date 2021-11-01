Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptVendorQuoteRequest 
    Public dt As DataTable
    Public dtLocation As DataTable
    Public logopath As String
    Public LogoID As String
    Public imgPath As String
    Public printDate As String
    Public CultureCode As String = "en-US"
    Private Sub arptVendorQuoteRequest_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            Dim count As Integer = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.DataSource = dt
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If Me.txtContactFName.Text <> "" Then
                Me.txtContact.Text = Me.txtContactFName.Text
            Else
                Me.txtContact.Text = ""
            End If
            If Me.txtContactMI.Text <> "" Then
                Me.txtContact.Text = Me.txtContact.Text & " " & Me.txtContactMI.Text & "."
            End If
            If Me.txtContactLName.Text <> "" Then
                Me.txtContact.Text = Me.txtContact.Text & " " & Me.txtContactLName.Text
            Else
                Me.txtContact.Text = ""
            End If
            If Me.txtContactAddress2.Text <> "" Then
                Me.txtAddress.Text = Me.txtAddress.Text & vbCrLf & Me.txtContactAddress2.Text
            End If
            If Me.txtContactCity.Text <> "" Then
                Me.txtCityStateZip.Text = Me.txtContactCity.Text
            Else
                'Me.txtCityStateZip.Text = ""
            End If
            If Me.txtContactState.Text <> "" Then
                Me.txtCityStateZip.Text = Me.txtCityStateZip.Text & ", " & Me.txtContactState.Text
            Else
                'Me.txtCityStateZip.Text = ""
            End If
            If Me.txtContactZip.Text <> "" Then
                Me.txtCityStateZip.Text = Me.txtCityStateZip.Text & " " & Me.txtContactZip.Text
            Else
                'Me.txtCityStateZip.Text = ""
            End If
            Me.txtRFQ.Text = Me.txtEstimateNumber.Text.PadLeft(6, "0") & "-" & Me.TxtEstimateCompNumber.Text.PadLeft(2, "0") & "-" & Me.txtVendorQteNumber.Text.PadLeft(3, "0")

            If txtRequestDate.Text <> "" Then
                Me.txtRequestDate.Text = CDate(Me.txtRequestDate.Text).ToShortDateString
            End If
            If txtDueDate.Text <> "" Then
                Me.txtDueDate.Text = CDate(Me.txtDueDate.Text).ToShortDateString
            End If
            If txtContact.Text = "" Then
                Me.txtContact.Text = Me.txtVendor.Text
                Me.txtVendor.Text = Me.TextBox8.Text
                If Me.TextBox4.Text <> "" Then
                    Me.txtVendor.Text = Me.txtVendor.Text & vbCrLf & Me.TextBox4.Text
                End If
                If Me.TextBox5.Text <> "" Then
                    Me.txtAddress.Text = Me.TextBox5.Text
                Else
                    'Me.txtAddress.Text = ""
                End If
                If Me.TextBox6.Text <> "" Then
                    Me.txtAddress.Text = Me.txtAddress.Text & ", " & Me.TextBox6.Text
                Else
                    'Me.txtAddress.Text = ""
                End If
                If Me.TextBox7.Text <> "" Then
                    Me.txtAddress.Text = Me.txtAddress.Text & " " & Me.TextBox7.Text
                Else
                    'Me.txtAddress.Text = ""
                End If
                Me.txtCityStateZip.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
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

            Dim str3 As String
            If Me.dtLocation.Rows.Count > 0 And Me.LogoID <> "None" And Me.dtLocation.Rows(0)("PRT_HEADER").ToString = "1" Then

                If Me.dtLocation.Rows(0)("PRT_NAME").ToString = "1" Then
                    If Me.dtLocation.Rows(0)("NAME").ToString <> "" Then
                        Me.txtAgencyName.Text = Me.dtLocation.Rows(0)("NAME")
                    Else
                        Me.txtAgencyName.Text = ""
                    End If
                Else
                    Me.txtAgencyName.Text = ""
                End If

                If Me.dtLocation.Rows(0)("PRT_ADDR1").ToString = "1" And Me.dtLocation.Rows(0)("ADDRESS1").ToString <> "" Then
                    str3 = Me.dtLocation.Rows(0)("ADDRESS1").ToString & " • "
                End If
                If Me.dtLocation.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtLocation.Rows(0)("ADDRESS2").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("ADDRESS2").ToString & " • "
                End If
                If Me.dtLocation.Rows(0)("PRT_CITY").ToString = "1" And Me.dtLocation.Rows(0)("CITY").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("CITY").ToString & "  "
                End If
                If Me.dtLocation.Rows(0)("PRT_STATE").ToString = "1" And Me.dtLocation.Rows(0)("STATE").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("STATE").ToString & "  "
                End If
                If Me.dtLocation.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtLocation.Rows(0)("ZIP").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("ZIP").ToString & " • "
                End If
                If Me.dtLocation.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtLocation.Rows(0)("PHONE").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("PHONE").ToString & " • "
                End If
                If Me.dtLocation.Rows(0)("PRT_FAX").ToString = "1" And Me.dtLocation.Rows(0)("FAX").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("FAX").ToString & " Fax • "
                End If
                If Me.dtLocation.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtLocation.Rows(0)("EMAIL").ToString <> "" Then
                    str3 = str3 & Me.dtLocation.Rows(0)("EMAIL").ToString
                End If
                Me.txtAgencyInfo.Text = str3
            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
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
End Class
