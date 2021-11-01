Imports System.Drawing
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class arptEstimating314
    Public logopath As String
    Public LogoID As String
    Public imgPath As String
    Public title As String
    Public printDivName As String
    Public printPrdDesc As String
    Public grouping As String
    Public Inside As String
    Public Outside As String
    Public CPU As Decimal
    Public printedDate As DateTime
    Public defFooter As String
    Public addressOption As String
    Public addressInfo As DataTable
    Public dt As DataTable
    Public dtLocation As DataTable
    Public dtPrintDef As DataTable
    Public taxed As Boolean = False
    Public commissioned As Boolean = False
    Public combined As Boolean = False
    Public quotes As String = ""
    Public comps As String = ""
    Public quotedescs As String = ""
    Public SigImage As System.Drawing.Image
    Public UseEmpSig As Boolean
    Public agencyname As String
    Public ESTReport As arptEstHeader
    Public DefaultFooterFontSize As Double = 0
    Public PrintClientName As String
    Public QuoteComment1 As String
    Public QuoteComment2 As String
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Public CultureCode As String '= "en-US"
    Private Sub arptEstimating002_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("GROUP_OPTION") = "T" Then
                    Me.GroupHeader2.DataField = "EST_FNC_TYPE"
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
                    'Me.GroupHeader2.DataField = "FNC_CODE"
                    Me.GroupFooter2.Visible = False
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "H" Then
                    Me.GroupHeader2.DataField = "FNC_HEADING_ID"
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "I" Then
                    Me.GroupHeader2.DataField = "INOUT"
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "P" Then
                    Me.GroupHeader2.DataField = "EST_PHASE_DESC"
                Else
                    Me.GroupHeader2.DataField = ""
                End If
            End If
            Me.DataSource = dt
            If Me.LogoID = "None" Then
                Me.PageHeader1.Controls.Remove(Me.Picture1)
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 2 Then
                Me.GroupFooter3.NewPage = NewPage.None
                'Me.GroupFooter4.NewPage = NewPage.After
                Me.GroupFooter4.Visible = True
                Me.TextBox7.Text = ""
                Me.TextBox11.Text = ""
                Me.TextBox12.Text = ""
                Me.TextBox13.Text = ""
                Me.TextBox14.Text = ""
                Me.TextBox15.Text = ""
                Me.TextBox16.Text = ""
                Me.TextBox17.Text = ""
                Me.TextBox18.Text = ""
                Me.Line15.Visible = False
                Me.Line16.Visible = False
                Me.Line17.Visible = False
                Me.Line26.Visible = False
                Me.Line27.Visible = False
                Me.Line28.Visible = False
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 4 Then
                Me.GroupFooter3.NewPage = NewPage.None
                'Me.GroupFooter4.NewPage = NewPage.After
                Me.GroupFooter4.Visible = True
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 5 Then
                Me.GroupFooter9.Visible = True
                Me.GroupFooter3.NewPage = NewPage.None
                'Me.GroupFooter9.NewPage = NewPage.After
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 0 Then
                Me.GroupFooter3.Visible = False
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 7 Then
                Me.GroupFooter3.Visible = False
                Me.GroupFooter3.NewPage = NewPage.None
                'Me.GroupFooter10.NewPage = NewPage.After
                Me.GroupFooter10.Visible = True
            End If

            Dim strquotes() As String
            Dim strquotesdesc() As String
            Dim i As Integer
            Dim len As Integer
            If quotes <> "" And combined = False Then
                strquotes = quotes.Split(",")
                strquotesdesc = quotedescs.Split(",")
                len = strquotes.Length - 1
                If len <> 0 Then
                    If len = 2 Then
                        If strquotes(0) <> "" Then
                            'Me.txtQuote3Text.Text = "Quote 0" & strquotes(0) & " - " & strquotesdesc(0).Replace("_", ",")
                            Me.txtQuote3.DataField = "QUOTE_1"
                        End If
                        If strquotes(1) <> "" Then
                            'Me.txtQuote4Text.Text = "Quote 0" & strquotes(1) & " - " & strquotesdesc(1).Replace("_", ",")
                            Me.txtQuote4.DataField = "QUOTE_2"
                        Else
                            Me.txtQuote4Text.Text = ""
                            Me.txtQuote4.DataField = ""
                        End If
                    End If
                    If len = 1 Then
                        If strquotes(0) <> "" Then
                            Me.txtQuote4Text.Text = "Minimum"
                            Me.txtQuote4.DataField = "QUOTE_1"
                        End If
                        Me.txtQuote3Text.Text = ""
                        Me.txtQuote3.DataField = ""
                    End If
                End If
            Else
                Dim qte As String = "0"
                Dim strqtes() As String
                Dim strcomps() As String
                Dim qtes As String
                Dim descs As ArrayList = New ArrayList()
                Dim count As Integer = 0
                Dim strqt() As String
                Dim strqtdesc() As String
                Dim strdesc() As String
                Dim comp As String = "0"
                Dim qtestr As String = ""
                Dim number As Integer
                Dim qute As String
                If comps <> "" And quotes <> "" Then
                    comps = comps.Substring(0, comps.Length - 1)
                    quotes = quotes.Substring(0, quotes.Length - 1)
                    quotedescs = quotedescs.Substring(0, quotedescs.Length - 1)
                    strcomps = comps.Split(",")
                    strqtes = quotes.Split(",")
                    strqtdesc = quotedescs.Split(",")
                    For j As Integer = 0 To strcomps.Length - 1
                        If comp = strcomps(j) Then
                            'count += 1
                            If qtes.Contains(strqtes(j)) = False Then
                                qtes &= strqtes(j) & ","
                                qute &= strqtes(j)
                                descs.Add(strqtdesc(j) & vbCrLf)
                            Else
                                number = qute.IndexOf(strqtes(j))
                                descs(number) = descs(number) & strqtdesc(j) & vbCrLf
                            End If
                            comp = strcomps(j)
                        ElseIf comp = 0 Then
                            'If strqtes.Length = 1 Then
                            'count += 1
                            'End If
                            qtes &= strqtes(j) & ","
                            qute &= strqtes(j)
                            descs.Add(strqtdesc(j) & vbCrLf)
                            comp = strcomps(j)
                        ElseIf comp <> strcomps(j) Then
                            'count += 1
                            If qtes.Contains(strqtes(j)) = False Then
                                qtes &= strqtes(j) & ","
                                qute &= strqtes(j)
                                descs.Add(strqtdesc(j) & vbCrLf)
                            Else
                                number = qute.IndexOf(strqtes(j))
                                descs(number) = descs(number) & strqtdesc(j) & vbCrLf
                            End If
                            comp = strcomps(j)
                        End If
                    Next
                    Dim q As String = "0"
                    Dim qs As String = ""
                    For k As Integer = 0 To strqtes.Length - 1
                        If q = 0 Then
                            count += 1
                            q = strqtes(k)
                            qs &= strqtes(k) & ","
                        ElseIf qs.Contains(strqtes(k)) = True Then
                            q = strqtes(k)
                        Else
                            qs &= strqtes(k) & ","
                            q = strqtes(k)
                            count += 1
                        End If
                    Next
                    strqt = qtes.Split(",")
                    'strdesc = descs.Split(",")
                    If count <> 0 Then
                        If count = 2 Then
                            If strqt(0) <> "" Then
                                'If descs.Count >= 1 Then
                                '    Me.txtQuote3Text.Text = "Quote 0" & strqt(0) & " - " & descs(0).Replace("_", ",")
                                'Else
                                '    Me.txtQuote3Text.Text = "Quote 0" & strqt(0)
                                'End If
                                Me.txtQuote3.DataField = "QUOTE_1"
                            End If
                            If strqt(1) <> "" Then
                                'If descs.Count >= 2 Then
                                '    Me.txtQuote4Text.Text = "Quote 0" & strqt(1) & " - " & descs(1).Replace("_", ",")
                                'Else
                                '    Me.txtQuote4Text.Text = "Quote 0" & strqt(1)
                                'End If
                                Me.txtQuote4.DataField = "QUOTE_2"
                            Else
                                Me.txtQuote4Text.Text = ""
                                Me.txtQuote4.DataField = ""
                            End If
                        End If
                        If count = 1 Then
                            If strqt(0) <> "" Then
                                'If descs.Count >= 1 Then
                                '    Me.txtQuote4Text.Text = "Quote 0" & strqt(0) & " - " & descs(0).Replace("_", ",")
                                'Else
                                Me.txtQuote4Text.Text = "Minimum"
                                'End If
                                Me.txtQuote4.DataField = "QUOTE_1"
                            End If
                            Me.txtQuote3Text.Text = ""
                            Me.txtQuote3.DataField = ""
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
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

            If title <> "" Then
                Me.txtTitle.Text = title
            End If
            'If Me.printDivName = "False" Then
            '    Me.txtDivision.Text = ""
            'Else
            '    'Me.txtDivision.Visible = True
            'End If
            'If Me.printPrdDesc = "False" Then
            '    Me.txtProduct.Text = ""
            'Else
            '    'Me.txtProduct.Visible = True
            'End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("RPT_TITLE") <> "" Then
                    Me.txtTitle.Text = dtPrintDef.Rows(0)("RPT_TITLE")
                End If
            End If

            If _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                    Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                        Dim bm As Bitmap

                        bm = New Bitmap(img)

                        Me.Picture1.Image = bm

                    End Using

                End Using

            Else

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

            End If

            Me.txtDates.Text = printedDate.ToShortDateString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("GROUP_OPTION") = "T" Then
                    'Me.txtFunctionType.Visible = True
                    Me.txtFunctionHeading.Text = ""
                    Me.txtInsideDesc.Text = ""
                    Me.txtPhaseDesc.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
                    Me.txtFunctionType.Text = ""
                    Me.txtFunctionHeading.Text = ""
                    Me.txtInsideDesc.Text = ""
                    Me.txtPhaseDesc.Text = ""
                    Me.GroupHeader2.Visible = False
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "H" Then
                    Me.txtFunctionHeading.Visible = True
                    Me.txtFunctionType.Text = ""
                    Me.txtInsideDesc.Text = ""
                    Me.txtPhaseDesc.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "I" Then
                    Me.txtInsideDesc.Visible = True
                    Me.txtFunctionType.Text = ""
                    Me.txtFunctionHeading.Text = ""
                    Me.txtPhaseDesc.Text = ""
                    If Me.txtIO.Text = "I" Then
                        Me.txtInsideDesc.Text = dtPrintDef.Rows(0)("INSIDE_CHG_DESC")
                    End If
                    If Me.txtIO.Text = "O" Then
                        Me.txtInsideDesc.Text = dtPrintDef.Rows(0)("OUTSIDE_CHG_DESC")
                    End If
                    If Me.txtIO.Text = "C" Then
                        Me.txtInsideDesc.Text = "Client Out of Pocket"
                    End If
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "P" Then
                    Me.txtInsideDesc.Text = ""
                    Me.txtFunctionType.Text = ""
                    Me.txtFunctionHeading.Text = ""
                Else
                    Me.txtFunctionType.Text = ""
                    Me.txtFunctionHeading.Text = ""
                    Me.txtInsideDesc.Text = ""
                    Me.txtPhaseDesc.Text = ""
                    Me.GroupHeader2.Visible = False
                End If
            End If
            If Me.txtFunctionType.Text = "E" Then
                Me.txtFunctionType.Text = "Employee Time Charges"
            End If
            If Me.txtFunctionType.Text = "V" Then
                Me.txtFunctionType.Text = "Vendor Charges"
            End If
            If Me.txtFunctionType.Text = "I" Then
                Me.txtFunctionType.Text = "Miscellaneous Charges"
            End If
            If Me.txtFunctionType.Text = "C" Then
                Me.txtFunctionType.Text = "Client Out of Pocket"
            End If
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

            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("TAX_INDICATOR") = 1 And taxed = True Then
                    Me.txtTaxableText.Text = "*Taxable"
                End If
                If dtPrintDef.Rows(0)("COMM_MU_INDICATOR") = 1 And commissioned = True And Me.txtTaxableText.Text = "" Then
                    Me.txtTaxableText.Text = "^Commissionable"
                ElseIf dtPrintDef.Rows(0)("COMM_MU_INDICATOR") = 1 And commissioned = True Then
                    Me.txtTaxableText.Text &= ", ^Commissionable"
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Try

            If dtPrintDef.Rows.Count > 0 Then

                'If dtPrintDef.Rows(0)("SELECT_BY") = "E" Then
                '    Me.rbEstimate.Checked = True
                'End If
                'If dtPrintDef.Rows(0)("SELECT_BY") = "J" Then
                '    Me.rbJob.Checked = True
                'End If
                'If dtPrintDef.Rows(0)("DATE_TO_PRINT") = 2 Then
                '    Me.txtDates.Text = printedDate.ToShortDateString
                'End If
                If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then

                Else
                    'Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtTax.Text)
                End If
                If dtPrintDef.Rows(0)("SORT_OPTION") = "C" Then
                    'Me.rbFunctionCodeSort.Checked = True
                End If
                If dtPrintDef.Rows(0)("SORT_OPTION") = "O" Then
                    'Me.rbFunctionOrderSort.Checked = True
                End If


                If dtPrintDef.Rows(0)("SPECS") = 1 Then
                    'Me.cbSpecs.Checked = True
                End If

                If dtPrintDef.Rows(0)("SUPPRESS_ZERO") = 1 Then
                    'Me.cbSuppresZero.Checked = True
                End If
                If dtPrintDef.Rows(0)("PRT_NONBILL") = 1 Then
                    'Me.cbIncludeNonBillable.Checked = True
                End If
                'If dtPrintDef.Rows(0)("PRT_DIV_NAME") = 1 Then
                '    Me.txtDivision.Visible = True
                'Else
                '    Me.txtDivision.Text = ""
                'End If
                'If dtPrintDef.Rows(0)("PRT_PRD_NAME") = 1 Then
                '    Me.txtProduct.Visible = True
                'Else
                '    Me.txtProduct.Text = ""
                'End If
                'If dtPrintDef.Rows(0)("QTY_HRS") = 1 Then
                '    Me.txtQty.Visible = True
                '    Me.txtQtyHrs.Visible = True
                'Else
                '    Me.txtQty.Visible = False
                '    Me.txtQtyHrs.Visible = False
                'End If
                If dtPrintDef.Rows(0)("SUBTOT_ONLY") = 1 Then
                    Me.txtQuote3.Visible = False
                    Me.txtQuote4.Visible = False
                    If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
                        Me.GroupFooter2.Visible = False
                    End If
                Else
                    Me.txtQuote3.Visible = True
                    Me.txtQuote4.Visible = True
                End If
                If dtPrintDef.Rows(0)("CONSOL_OVERRIDE") = 1 Then
                    'Me.cbOverride.Checked = True
                End If
            End If
            'If Me.txtOneRev.Text = "1" Then
            '    Me.txtOriginalLabel.Text = ""
            '    Me.txtRevisedLabel.Text = "Original Estimate"
            'Else
            '    Me.txtOriginalLabel.Text = "Original Estimate"
            '    Me.txtRevisedLabel.Text = "Revised Estimate"
            'End If
            'Me.txtFinalActual.Text = String.Format("{0:n}", CDec(Me.txtFinalActual.Text))

            ReportFunctions.SetCulture(Me, CultureCode)
            
            If Me.txtQuote3.Text <> "" Then
                Me.txtQuote3.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3.Text)))
            End If
            If Me.txtQuote4.Text <> "" Then
                Me.txtQuote4.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4.Text)))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
                    If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then

                    Else
                        If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                            'If Me.txtOrigContingency.Text <> "" Then
                            '    'Me.txtOriginalAmt.Text = CDec(Me.txtOriginalAmt.Text) + CDec(Me.txtOrigContingency.Text)
                            'End If
                        Else
                            'If Me.txtOrigContingency.Text <> "" Then
                            '    Me.txtOriginalAmt.Text = CDec(Me.txtOriginalAmt.Text) '+ CDec(Me.txtOrigMUCont.Text)
                            'End If
                        End If
                    End If
                End If
                If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then

                Else
                    'Me.txtOriginalAmt.Text = CDec(Me.txtOriginalAmt.Text) '+ CDec(Me.txtOrigTaxAmount.Text)
                    'Me.txtRevisedAmt.Text = CDec(Me.txtRevisedAmt.Text) '+ CDec(Me.txtRevisedTax.Text)
                End If
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then

                Else
                    'Me.txtOriginalAmt.Text = CDec(Me.txtOriginalAmt.Text) '+ CDec(Me.txtOrigMarkupAmt.Text)
                    'Me.txtRevisedAmt.Text = CDec(Me.txtRevisedAmt.Text) '+ CDec(Me.txtRevisedMarkupAmt.Text)
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "F" Then
                    'Me.rbFunctionCode.Checked = True
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "C" Then
                    'Me.rbConsolidationCode.Checked = True
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                    Me.txtDescription.Text = ""
                    'Me.txtQtyHrs.Text = ""
                    'Me.txtRateLabel.Text = ""
                    'Me.txtAmountText.Text = ""
                    Me.GroupHeader2.Visible = False
                    Me.txtTotalLabel.Text = ""
                    If dtPrintDef.Rows(0)("SUBTOT_ONLY") <> 1 Then
                        Me.txtSubTotalLabel.Text = ""
                    End If
                    'Me.txtTotalGrouping.Text = ""
                    Me.txtQuote1Subtotal.Text = ""
                    Me.txtQuote2SubTotal.Text = ""
                    Me.txtQuote3SubTotal.Text = ""
                    Me.txtQuote4SubTotal.Text = ""
                    Me.Detail1.Visible = False
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
                    'Me.txtRateLabel.Visible = True
                    'Me.txtRevisedAmt.Visible = True
                Else
                    'Me.txtRateLabel.Visible = False
                    'Me.txtRevisedAmt.Visible = False
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                    'Me.txtRateLabel.Visible = False
                    'Me.txtRevisedAmt.Visible = False
                End If
                If dtPrintDef.Rows(0)("FUNC_COMMENT") = 1 Then
                    Me.txtFunctionComments.Visible = True
                Else
                    Me.txtFunctionComments.Text = ""
                End If
                If dtPrintDef.Rows(0)("SUP_BY_NOTES") = 1 Then
                    'Me.txtSuppliedByNotes.Visible = True
                Else
                    'Me.txtSuppliedByNotes.Text = ""
                End If

            End If

            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("GROUP_OPTION") = "T" Then
                    Me.txtDescriptionText.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
                    Me.TextBoxFunctionDescription.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "H" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
                    Me.txtDescriptionText.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "I" Then
                    Me.txtDescriptionText.Text = ""
                ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "P" Then
                    Me.txtDescriptionText.Text = ""
                Else
                    Me.TextBoxFunctionDescription.Text = ""
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
           If Me.txtQuote3.Text <> "" Then
                Me.txtQuote3SubTotal.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3SubTotal.Text)))
                Me.txtQuote4SubTotal.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)))
            ElseIf Me.txtQuote4.Text <> "" Then
                Me.txtQuote4SubTotal.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)))
            End If

            If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                Me.txtQuote3Commission.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3Commission.Text)))
                Me.txtQuote4Commission.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4Commission.Text)))
            End If
            If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                Me.txtQuote3TaxAmt.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3TaxAmt.Text)))
                Me.txtQuote4TaxAmt.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TaxAmt.Text)))
            End If
            
            'Me.txtTotalForEst.Text = String.Format("{0:n}", CDec(Me.txtTotalForEst.Text))
            'If Me.txtOneRevTotal.Text = "1" Then
            '    Me.txtQuote1Subtotal.Text = ""
            '    Me.txtQuote1TaxAmt.Text = ""
            '    Me.txtQuote1Commission.Text = ""
            '    Me.txtQuote1TotalForEst.Text = ""
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If combined = True Then
                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote4Commission.Text = Me.txtQuote2Commission.Text
                            Me.txtQuote1Commission.Text = "0.00"
                            Me.txtQuote2Commission.Text = "0.00"
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote1Commission.Text = "0.00"
                            Me.txtQuote2Commission.Text = "0.00"
                            Me.txtQuote3Commission.Text = "0.00"
                        End If
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote4TaxAmt.Text = Me.txtQuote2TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = "0.00"
                            Me.txtQuote2TaxAmt.Text = "0.00"
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = "0.00"
                            Me.txtQuote2TaxAmt.Text = "0.00"
                            Me.txtQuote3TaxAmt.Text = "0.00"
                        End If
                    End If
                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3Cont2Total.Text = CDec(Me.txtQuote1Cont2Total.Text) + CDec(Me.txtQuote1MUContTotal.Text)
                            Me.txtQuote4Cont2Total.Text = CDec(Me.txtQuote2Cont2Total.Text) + CDec(Me.txtQuote2MUContTotal.Text)
                            Me.txtQuote1Cont2Total.Text = ""
                            Me.txtQuote2Cont2Total.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4Cont2Total.Text = CDec(Me.txtQuote1Cont2Total.Text) + CDec(Me.txtQuote1MUContTotal.Text)
                            Me.txtQuote1Cont2Total.Text = ""
                            Me.txtQuote2Cont2Total.Text = ""
                            Me.txtQuote3Cont2Total.Text = ""
                        End If
                    End If
                End If
                'Me.txtTotalForEst.Text = CDec(Me.txtSubTotal.Text)
               If Me.txtQuote3Text.Text <> "" Then
                    Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote1Subtotal.Text)
                    Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote2SubTotal.Text)
                    Me.txtQuote1TotalForEst.Text = "0.00"
                    Me.txtQuote2TotalForEst.Text = "0.00"
                ElseIf Me.txtQuote4Text.Text <> "" Then
                    Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote1Subtotal.Text)
                    Me.txtQuote1TotalForEst.Text = "0.00"
                    Me.txtQuote2TotalForEst.Text = "0.00"
                    Me.txtQuote3TotalForEst.Text = "0.00"
                End If

                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtCommission.Text)
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3Commission.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Commission.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Commission.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtTax.Text)
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3TaxAmt.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4TaxAmt.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4TaxAmt.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text)
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3Cont2Total.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Cont2Total.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Cont2Total.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                End If
                ReportFunctions.SetCulture(Me, CultureCode)
                'Me.txtTotalForEst.Text = String.Format("{0:c}", CDec(Me.txtTotalForEst.Text))
                If Me.txtQuote3Text.Text <> "" Then
                    Me.txtQuote3TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3TotalForEst.Text)))
                    Me.txtQuote4TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalForEst.Text)))
                    Me.txtQuote1TotalForEst.Text = ""
                    Me.txtQuote2TotalForEst.Text = ""
                ElseIf Me.txtQuote4Text.Text <> "" Then
                    Me.txtQuote4TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalForEst.Text)))
                    Me.txtQuote1TotalForEst.Text = ""
                    Me.txtQuote2TotalForEst.Text = ""
                    Me.txtQuote3TotalForEst.Text = ""
                End If
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote3Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3Cont2Total.Text)))
                    Me.txtQuote4Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4Cont2Total.Text)))
                    'Me.txtQuote1Cont2Total.Text = ""
                    'Me.txtQuote2Cont2Total.Text = ""
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4Cont2Total.Text)))
                    'Me.txtQuote1Cont2Total.Text = ""
                    'Me.txtQuote2Cont2Total.Text = ""
                    'Me.txtQuote3Cont2Total.Text = ""
                End If
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote3SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote1Subtotal.Text))
                    Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote2SubTotal.Text))
                    Me.txtQuote1Subtotal.Text = ""
                    Me.txtQuote2SubTotal.Text = ""
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote1Subtotal.Text))
                    Me.txtQuote1Subtotal.Text = ""
                    Me.txtQuote2SubTotal.Text = ""
                    Me.txtQuote3SubTotal.Text = ""
                End If
                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        Me.txtTaxLabel.Text = "Tax:"
                        Me.txtTaxLabel.Visible = True
                        'Me.txtTax.Visible = True
                        If Me.txtQuote3Text.Text <> "" Then
                            'Me.txtQuote3TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            'Me.txtQuote4TaxAmt.Text = Me.txtQuote2TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = ""
                            Me.txtQuote2TaxAmt.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            'Me.txtQuote4TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = ""
                            Me.txtQuote2TaxAmt.Text = ""
                            Me.txtQuote3TaxAmt.Text = ""
                        End If
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    Else
                        'Me.txtTax.Text = ""
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote3SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote1TaxAmt.Text))
                            Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote2TaxAmt.Text))
                            Me.txtQuote1Subtotal.Text = ""
                            Me.txtQuote2SubTotal.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote1TaxAmt.Text))
                            Me.txtQuote1Subtotal.Text = ""
                            Me.txtQuote2SubTotal.Text = ""
                            Me.txtQuote3SubTotal.Text = ""
                        End If

                        Me.txtTaxLabel.Text = ""
                        Me.txtSubTotalLabel.Text = ""

                        Me.txtQuote1TaxAmt.Text = ""
                        Me.txtQuote2TaxAmt.Text = ""
                        Me.txtQuote3TaxAmt.Text = ""
                        Me.txtQuote4TaxAmt.Text = ""

                    End If
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        Me.txtCommissionLabel.Text = "Commission:"
                        Me.txtCommissionLabel.Visible = True
                        'Me.txtCommission.Visible = True
                        If Me.txtQuote3.Text <> "" Then
                            ''Me.txtQuote3Commission.Text = Me.txtQuote1Commission.Text
                            ''Me.txtQuote4Commission.Text = Me.txtQuote2Commission.Text
                            Me.txtQuote1Commission.Text = ""
                            Me.txtQuote2Commission.Text = ""
                        ElseIf Me.txtQuote4.Text <> "" Then
                            'Me.txtQuote4Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote1Commission.Text = ""
                            Me.txtQuote2Commission.Text = ""
                            Me.txtQuote3Commission.Text = ""
                        End If
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    Else
                        Me.txtCommissionLabel.Text = ""
                        'Me.txtCommission.Text = ""
                        Me.txtSubTotalLabel.Text = ""
                        'If Me.txtQuote1.Text <> "" Then
                        Me.txtQuote1Commission.Text = ""
                        Me.txtQuote2Commission.Text = ""
                        Me.txtQuote3Commission.Text = ""
                        Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote2.Text <> "" Then
                        '    Me.txtQuote2Commission.Text = ""
                        '    Me.txtQuote3Commission.Text = ""
                        '    Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote3.Text <> "" Then
                        '    Me.txtQuote3Commission.Text = ""
                        '    Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote4.Text <> "" Then
                        '    Me.txtQuote4Commission.Text = ""
                        'End If
                        'Me.txtSubTotal.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
                        If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                            Me.txtContLabel.Text = "Contingency:"
                            Me.txtContLabel.Visible = True
                            'Me.txtContTotal2.Visible = True
                            If Me.txtQuote3Text.Text <> "" Then
                                'Me.txtQuote4Cont2Total.Text = Me.txtQuote2Cont2Total.Text
                                'Me.txtQuote3Cont2Total.Text = Me.txtQuote1Cont2Total.Text
                                Me.txtQuote4Cont2Total.Visible = True
                                Me.txtQuote3Cont2Total.Visible = True
                            ElseIf Me.txtQuote4Text.Text <> "" Then
                                ' Me.txtQuote4Cont2Total.Text = Me.txtQuote1Cont2Total.Text
                                Me.txtQuote4Cont2Total.Visible = True
                                Me.txtQuote3Cont2Total.Visible = False
                            End If
                            If Me.txtQuote4TotalForEst.Text <> "" Then
                                Me.Line22.Visible = True
                            End If
                            If Me.txtQuote3TotalForEst.Text <> "" Then
                                Me.Line23.Visible = True
                            End If
                        Else
                            Me.txtContLabel.Text = ""
                            'Me.txtContTotal2.Text = ""
                            Me.txtSubTotalLabel.Text = ""
                            'Me.txtSubTotal.Text = ""
                        End If
                    Else
                        Me.txtContLabel.Text = ""
                        'Me.txtContTotal2.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
                        'Me.txtSubTotal.Text = ""
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3SubTotal.Text = ""
                            Me.txtQuote4SubTotal.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4SubTotal.Text = ""
                        End If

                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                        If dtPrintDef.Rows(0)("SUBTOT_ONLY") <> 1 Then
                            Me.txtSubTotalLabel.Text = ""
                        End If
                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
                        'Me.txtSubTotalLabel.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                        'Me.txtSubTotalLabel.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("DEF_FOOTER_COMMENT") = 1 Then
                        Me.txtEstDefaultComment.Visible = True
                    Else
                        Me.txtEstDefaultComment.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
                        Me.txtQuote1Subtotal.Text = ""
                        Me.txtQuote2SubTotal.Text = ""
                        Me.txtQuote3SubTotal.Text = ""
                        Me.txtQuote4SubTotal.Text = ""
                        Me.txtSubTotalLabel.Text = ""
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    End If
                   
                End If
                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("PRT_CPU") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote4CPU.Text = "CPU: " & Me.txtQuote2CPU.Text
                            Me.txtQuote3CPU.Text = "CPU: " & Me.txtQuote1CPU.Text
                            Me.txtQuote2CPU.Text = ""
                            Me.txtQuote1CPU.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4CPU.Text = "CPU: " & Me.txtQuote1CPU.Text
                            Me.txtQuote3CPU.Text = ""
                            Me.txtQuote2CPU.Text = ""
                            Me.txtQuote1CPU.Text = ""
                        End If
                    Else
                        Me.txtQuote1CPU.Text = ""
                        Me.txtQuote2CPU.Text = ""
                        Me.txtQuote3CPU.Text = ""
                        Me.txtQuote4CPU.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("PRT_CPM") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote4CPM.Text = "CPM: " & Me.txtQuote2CPM.Text
                            Me.txtQuote3CPM.Text = "CPM: " & Me.txtQuote1CPM.Text
                            Me.txtQuote2CPM.Text = ""
                            Me.txtQuote1CPM.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4CPM.Text = "CPM: " & Me.txtQuote1CPM.Text
                            Me.txtQuote3CPM.Text = ""
                            Me.txtQuote2CPM.Text = ""
                            Me.txtQuote1CPM.Text = ""
                        End If
                    Else
                        Me.txtQuote1CPM.Text = ""
                        Me.txtQuote2CPM.Text = ""
                        Me.txtQuote3CPM.Text = ""
                        Me.txtQuote4CPM.Text = ""
                    End If
                End If
            Else
                If dtPrintDef.Rows.Count > 0 Then
                    'If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
                    '    Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text)
                    '    Me.txtOriginalSubtotal.Text = CDec(Me.txtOriginalSubtotal.Text) + CDec(Me.txtOrigCommission.Text) '+ CDec(Me.txtOrigContTotal.Text) + CDec(Me.txtOrigMUContTotal.Text)
                    '    Me.txtRevisedSubTotal.Text = CDec(Me.txtRevisedSubTotal.Text) + CDec(Me.txtRevisedCommission.Text) '+ CDec(Me.txtRevisedContTotal.Text) + CDec(Me.txtRevisedMUContTotal.Text)
                    'ElseIf dtPrintDef.Rows(0)("CONTINGENCY") = 0 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
                    '    Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text)
                    '    Me.txtOriginalSubtotal.Text = CDec(Me.txtOriginalSubtotal.Text) + CDec(Me.txtOrigCommission.Text)
                    '    Me.txtRevisedSubTotal.Text = CDec(Me.txtRevisedSubTotal.Text) + CDec(Me.txtRevisedCommission.Text)
                    'ElseIf dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
                    '    Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text)
                    '    Me.txtOriginalSubtotal.Text = CDec(Me.txtOriginalSubtotal.Text) '+ CDec(Me.txtOrigContTotal.Text)
                    '    Me.txtRevisedSubTotal.Text = CDec(Me.txtRevisedSubTotal.Text) '+ CDec(Me.txtRevisedContTotal.Text)
                    'End If
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote4Commission.Text = Me.txtQuote2Commission.Text
                            Me.txtQuote1Commission.Text = "0.00"
                            Me.txtQuote2Commission.Text = "0.00"
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote1Commission.Text = "0.00"
                            Me.txtQuote2Commission.Text = "0.00"
                            Me.txtQuote3Commission.Text = "0.00"
                        End If
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote4TaxAmt.Text = Me.txtQuote2TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = "0.00"
                            Me.txtQuote2TaxAmt.Text = "0.00"
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = "0.00"
                            Me.txtQuote2TaxAmt.Text = "0.00"
                            Me.txtQuote3TaxAmt.Text = "0.00"
                        End If
                    End If


                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3Cont2Total.Text = CDec(Me.txtQuote1Cont2Total.Text) + CDec(Me.txtQuote1MUContTotal.Text)
                            Me.txtQuote4Cont2Total.Text = CDec(Me.txtQuote2Cont2Total.Text) + CDec(Me.txtQuote2MUContTotal.Text)
                            Me.txtQuote1Cont2Total.Text = ""
                            Me.txtQuote2Cont2Total.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4Cont2Total.Text = CDec(Me.txtQuote1Cont2Total.Text) + CDec(Me.txtQuote1MUContTotal.Text)
                            Me.txtQuote1Cont2Total.Text = ""
                            Me.txtQuote2Cont2Total.Text = ""
                            Me.txtQuote3Cont2Total.Text = ""
                        End If
                    End If
                End If
                'Me.txtTotalForEst.Text = CDec(Me.txtSubTotal.Text)
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote1Subtotal.Text)
                    Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote2SubTotal.Text)
                    Me.txtQuote1TotalForEst.Text = "0.00"
                    Me.txtQuote2TotalForEst.Text = "0.00"
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote1Subtotal.Text)
                    Me.txtQuote1TotalForEst.Text = "0.00"
                    Me.txtQuote2TotalForEst.Text = "0.00"
                    Me.txtQuote3TotalForEst.Text = "0.00"
                End If

                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtCommission.Text)
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3Commission.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Commission.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Commission.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtTax.Text)
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3TaxAmt.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4TaxAmt.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4TaxAmt.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                        'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text)
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3TotalForEst.Text = CDec(Me.txtQuote3TotalForEst.Text) + CDec(Me.txtQuote3Cont2Total.Text)
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Cont2Total.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4TotalForEst.Text = CDec(Me.txtQuote4TotalForEst.Text) + CDec(Me.txtQuote4Cont2Total.Text)
                            Me.txtQuote1TotalForEst.Text = "0.00"
                            Me.txtQuote2TotalForEst.Text = "0.00"
                            Me.txtQuote3TotalForEst.Text = "0.00"
                        End If

                    End If
                End If
                ReportFunctions.SetCulture(Me, CultureCode)
                'Me.txtTotalForEst.Text = String.Format("{0:c}", CDec(Me.txtTotalForEst.Text))
                If Me.txtQuote3Text.Text <> "" Then
                    Me.txtQuote3TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3TotalForEst.Text)))
                    Me.txtQuote4TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalForEst.Text)))
                    Me.txtQuote1TotalForEst.Text = ""
                    Me.txtQuote2TotalForEst.Text = ""
                ElseIf Me.txtQuote4Text.Text <> "" Then
                    Me.txtQuote4TotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalForEst.Text)))
                    Me.txtQuote1TotalForEst.Text = ""
                    Me.txtQuote2TotalForEst.Text = ""
                    Me.txtQuote3TotalForEst.Text = ""
                End If
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote3Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3Cont2Total.Text)))
                    Me.txtQuote4Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4Cont2Total.Text)))
                    'Me.txtQuote1Cont2Total.Text = ""
                    'Me.txtQuote2Cont2Total.Text = ""
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4Cont2Total.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4Cont2Total.Text)))
                    'Me.txtQuote1Cont2Total.Text = ""
                    'Me.txtQuote2Cont2Total.Text = ""
                    'Me.txtQuote3Cont2Total.Text = ""
                End If
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote3SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote1Subtotal.Text))
                    Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote2SubTotal.Text))
                    Me.txtQuote1Subtotal.Text = ""
                    Me.txtQuote2SubTotal.Text = ""
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote1Subtotal.Text))
                    Me.txtQuote1Subtotal.Text = ""
                    Me.txtQuote2SubTotal.Text = ""
                    Me.txtQuote3SubTotal.Text = ""
                End If
                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                        Me.txtTaxLabel.Text = "Tax:"
                        Me.txtTaxLabel.Visible = True
                        'Me.txtTax.Visible = True
                        If Me.txtQuote3Text.Text <> "" Then
                            'Me.txtQuote3TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            'Me.txtQuote4TaxAmt.Text = Me.txtQuote2TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = ""
                            Me.txtQuote2TaxAmt.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            'Me.txtQuote4TaxAmt.Text = Me.txtQuote1TaxAmt.Text
                            Me.txtQuote1TaxAmt.Text = ""
                            Me.txtQuote2TaxAmt.Text = ""
                            Me.txtQuote3TaxAmt.Text = ""
                        End If
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    Else
                        'Me.txtTax.Text = ""
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote3SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote3SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote1TaxAmt.Text))
                            Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote2TaxAmt.Text))
                            Me.txtQuote1Subtotal.Text = ""
                            Me.txtQuote2SubTotal.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4SubTotal.Text = CDec(ReportFunctions.FormatDecimal(Me.txtQuote4SubTotal.Text)) + CDec(ReportFunctions.FormatDecimal(Me.txtQuote1TaxAmt.Text))
                            Me.txtQuote1Subtotal.Text = ""
                            Me.txtQuote2SubTotal.Text = ""
                            Me.txtQuote3SubTotal.Text = ""
                        End If
                        Me.txtTaxLabel.Text = ""
                        Me.txtSubTotalLabel.Text = ""

                        Me.txtQuote1TaxAmt.Text = ""
                        Me.txtQuote2TaxAmt.Text = ""
                        Me.txtQuote3TaxAmt.Text = ""
                        Me.txtQuote4TaxAmt.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                        Me.txtCommissionLabel.Text = "Commission:"
                        Me.txtCommissionLabel.Visible = True
                        'Me.txtCommission.Visible = True
                        If Me.txtQuote3.Text <> "" Then
                            ''Me.txtQuote3Commission.Text = Me.txtQuote1Commission.Text
                            ''Me.txtQuote4Commission.Text = Me.txtQuote2Commission.Text
                            Me.txtQuote1Commission.Text = ""
                            Me.txtQuote2Commission.Text = ""
                        ElseIf Me.txtQuote4.Text <> "" Then
                            'Me.txtQuote4Commission.Text = Me.txtQuote1Commission.Text
                            Me.txtQuote1Commission.Text = ""
                            Me.txtQuote2Commission.Text = ""
                            Me.txtQuote3Commission.Text = ""
                        End If
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    Else
                        Me.txtCommissionLabel.Text = ""
                        'Me.txtCommission.Text = ""
                        Me.txtSubTotalLabel.Text = ""
                        'If Me.txtQuote1.Text <> "" Then
                        Me.txtQuote1Commission.Text = ""
                        Me.txtQuote2Commission.Text = ""
                        Me.txtQuote3Commission.Text = ""
                        Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote2.Text <> "" Then
                        '    Me.txtQuote2Commission.Text = ""
                        '    Me.txtQuote3Commission.Text = ""
                        '    Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote3.Text <> "" Then
                        '    Me.txtQuote3Commission.Text = ""
                        '    Me.txtQuote4Commission.Text = ""
                        '    ElseIf Me.txtQuote4.Text <> "" Then
                        '    Me.txtQuote4Commission.Text = ""
                        'End If
                        'Me.txtSubTotal.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
                        If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                            Me.txtContLabel.Text = "Contingency:"
                            Me.txtContLabel.Visible = True
                            'Me.txtContTotal2.Visible = True
                            If Me.txtQuote3.Text <> "" Then
                                'Me.txtQuote4Cont2Total.Text = Me.txtQuote2Cont2Total.Text
                                'Me.txtQuote3Cont2Total.Text = Me.txtQuote1Cont2Total.Text
                                Me.txtQuote4Cont2Total.Visible = True
                                Me.txtQuote3Cont2Total.Visible = True
                            ElseIf Me.txtQuote4.Text <> "" Then
                                'Me.txtQuote4Cont2Total.Text = Me.txtQuote1Cont2Total.Text
                                Me.txtQuote4Cont2Total.Visible = True
                            End If
                            If Me.txtQuote4TotalForEst.Text <> "" Then
                                Me.Line22.Visible = True
                            End If
                            If Me.txtQuote3TotalForEst.Text <> "" Then
                                Me.Line23.Visible = True
                            End If
                        Else
                            Me.txtContLabel.Text = ""
                            'Me.txtContTotal2.Text = ""
                            Me.txtSubTotalLabel.Text = ""
                            'Me.txtSubTotal.Text = ""
                        End If
                    Else
                        Me.txtContLabel.Text = ""
                        'Me.txtContTotal2.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
                        'Me.txtSubTotal.Text = ""
                        If Me.txtQuote3.Text <> "" Then
                            Me.txtQuote3SubTotal.Text = ""
                            Me.txtQuote4SubTotal.Text = ""
                        ElseIf Me.txtQuote4.Text <> "" Then
                            Me.txtQuote4SubTotal.Text = ""
                        End If

                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                        Me.txtSubTotalLabel.Text = ""
                        'Me.txtSubTotal.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
                        'Me.txtSubTotalLabel.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                        'Me.txtSubTotalLabel.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
                        Me.txtQuote1Subtotal.Text = ""
                        Me.txtQuote2SubTotal.Text = ""
                        Me.txtQuote3SubTotal.Text = ""
                        Me.txtQuote4SubTotal.Text = ""
                        Me.txtSubTotalLabel.Text = ""
                        'Me.Line14.Visible = False
                        'Me.Line15.Visible = False
                        'Me.Line16.Visible = False
                        'Me.Line17.Visible = False
                        If Me.txtQuote4TotalForEst.Text <> "" Then
                            Me.Line22.Visible = True
                        End If
                        If Me.txtQuote3TotalForEst.Text <> "" Then
                            Me.Line23.Visible = True
                        End If
                    End If
                    
                End If
                If dtPrintDef.Rows.Count > 0 Then
                    If dtPrintDef.Rows(0)("PRT_CPU") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote4CPU.Text = "CPU: " & Me.txtQuote2CPU.Text
                            Me.txtQuote3CPU.Text = "CPU: " & Me.txtQuote1CPU.Text
                            Me.txtQuote2CPU.Text = ""
                            Me.txtQuote1CPU.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4CPU.Text = "CPU: " & Me.txtQuote1CPU.Text
                            Me.txtQuote3CPU.Text = ""
                            Me.txtQuote2CPU.Text = ""
                            Me.txtQuote1CPU.Text = ""
                        End If
                    Else
                        Me.txtQuote1CPU.Text = ""
                        Me.txtQuote2CPU.Text = ""
                        Me.txtQuote3CPU.Text = ""
                        Me.txtQuote4CPU.Text = ""
                    End If
                    If dtPrintDef.Rows(0)("PRT_CPM") = 1 Then
                        If Me.txtQuote3Text.Text <> "" Then
                            Me.txtQuote4CPM.Text = "CPM: " & Me.txtQuote2CPM.Text
                            Me.txtQuote3CPM.Text = "CPM: " & Me.txtQuote1CPM.Text
                            Me.txtQuote2CPM.Text = ""
                            Me.txtQuote1CPM.Text = ""
                        ElseIf Me.txtQuote4Text.Text <> "" Then
                            Me.txtQuote4CPM.Text = "CPM: " & Me.txtQuote1CPM.Text
                            Me.txtQuote3CPM.Text = ""
                            Me.txtQuote2CPM.Text = ""
                            Me.txtQuote1CPM.Text = ""
                        End If
                    Else
                        Me.txtQuote1CPM.Text = ""
                        Me.txtQuote2CPM.Text = ""
                        Me.txtQuote3CPM.Text = ""
                        Me.txtQuote4CPM.Text = ""
                    End If
                End If
            End If

            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("EST_COMP_COMMENT") = 1 Then
                    Me.txtComponentComments.Visible = True
                    Me.TextBox19.Visible = True
                Else
                    Me.txtComponentComments.Text = ""
                    Me.TextBox19.Text = ""
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            If Me.txtQuote3.Text <> "" Then
                Me.txtQuote3TotalGrouping.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote3TotalGrouping.Text)))
                Me.txtQuote4TotalGrouping.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalGrouping.Text)))
            ElseIf Me.txtQuote4.Text <> "" Then
                Me.txtQuote4TotalGrouping.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtQuote4TotalGrouping.Text)))
            End If
            'Me.txtTotalGrouping.Text = String.Format("{0:n}", CDec(Me.txtTotalGrouping.Text))

            'Me.txtTotalForEst.Text = String.Format("{0:n}", CDec(Me.txtTotalForEst.Text))            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            If Me.txtFunctionType.Text <> "" Then
                Me.txtTotalLabel.Text = "Total " & Me.txtFunctionType.Text & ":"
            ElseIf Me.txtFunctionHeading.Text <> "" Then
                Me.txtTotalLabel.Text = "Total " & Me.txtFunctionHeading.Text & ":"
            ElseIf Me.txtInsideDesc.Text <> "" Then
                Me.txtTotalLabel.Text = "Total " & Me.txtInsideDesc.Text & ":"
            ElseIf Me.txtPhaseDesc.Text <> "" Then
                Me.txtTotalLabel.Text = "Total " & Me.txtPhaseDesc.Text & ":"
            End If
            'Me.txtOrigTotalGrouping.Text = CDec(Me.txtOrigTotalGrouping.Text) + CDec(Me.txtOrigContGrouping.Text)
            'Me.txtRevisedTotalGrouping.Text = CDec(Me.txtRevisedTotalGrouping.Text) + CDec(Me.txtRevisedContGrouping.Text)
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 Then
                    'Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtActualTaxGrouping.Text)
                    'Me.txtOrigTotalGrouping.Text = CDec(Me.txtOrigTotalGrouping.Text) + CDec(Me.txtOrigTaxGrouping.Text)
                    'Me.txtRevisedTotalGrouping.Text = CDec(Me.txtRevisedTotalGrouping.Text) + CDec(Me.txtRevisedTaxGrouping.Text)
                End If
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
                    'Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtActualMarkupGrouping.Text)
                    'Me.txtOrigTotalGrouping.Text = CDec(Me.txtOrigTotalGrouping.Text) + CDec(Me.txtOrigMarkupAmtGrouping.Text)
                    'Me.txtRevisedTotalGrouping.Text = CDec(Me.txtRevisedTotalGrouping.Text) + CDec(Me.txtRevisedMarkupAmtGrouping.Text)
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                    Me.GroupFooter2.Visible = False
                    Me.txtTotalLabel.Text = ""
                End If
                If dtPrintDef.Rows(0)("SUBTOT_ONLY") = 1 Then
                    Me.Line9.Visible = False
                    Me.Line10.Visible = False
                End If
            End If
            If combined = True Then
                If Me.txtQuote3Text.Text <> "" Then
                    Me.txtQuote4TotalGrouping.Text = Me.txtQuote2TotalGrouping.Text
                    Me.txtQuote3TotalGrouping.Text = Me.txtQuote1Grouping.Text
                    Me.txtQuote1Grouping.Text = ""
                    Me.txtQuote2TotalGrouping.Text = ""
                ElseIf Me.txtQuote4Text.Text <> "" Then
                    Me.txtQuote4TotalGrouping.Text = Me.txtQuote1Grouping.Text
                    Me.txtQuote1Grouping.Text = ""
                    Me.txtQuote2TotalGrouping.Text = ""
                    Me.txtQuote3TotalGrouping.Text = ""
                End If
            Else
                If Me.txtQuote3.Text <> "" Then
                    Me.txtQuote4TotalGrouping.Text = Me.txtQuote2TotalGrouping.Text
                    Me.txtQuote3TotalGrouping.Text = Me.txtQuote1Grouping.Text
                    Me.txtQuote1Grouping.Text = ""
                    Me.txtQuote2TotalGrouping.Text = ""
                ElseIf Me.txtQuote4.Text <> "" Then
                    Me.txtQuote4TotalGrouping.Text = Me.txtQuote1Grouping.Text
                    Me.txtQuote1Grouping.Text = ""
                    Me.txtQuote2TotalGrouping.Text = ""
                    Me.txtQuote3TotalGrouping.Text = ""
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.BeforePrint
        Try
            If combined = False Then
                Me.txtEstNumber.Text = Me.txtEstNumber.Text.PadLeft(6, "0")
                If Me.txtJobNumber.Text <> "" Then
                    Me.txtJobNumber.Text = Me.txtJobNumber.Text.PadLeft(6, "0")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            'If dtPrintDef.Rows.Count > 0 Then

            '    If dtPrintDef.Rows(0)("JOB_DUE_DATE") = 1 Then
            '        Me.TextBox10.Visible = True
            '    Else
            '        Me.TextBox10.Text = ""
            '    End If
            'End If
            If combined = True Then
                
                'Me.TextBox1.Text = ""
                'Me.TextBox5.Text = ""
                'Dim estcomp() As String = Me.txtestcomp.Text.Split("/")
                'Dim comp As String = estcomp(1)

            End If
            If Me.txtJobNumber.Text = "0" Then
                Me.txtJobNumber.Text = ""
            End If
            If dtPrintDef.Rows(0)("EST_COMMENT") = 1 Then
                Me.txtEstimateComments.Visible = True
                Me.TextBox10.Visible = True
            Else
                Me.txtEstimateComments.Text = ""
                Me.TextBox10.Text = ""
            End If
            'Me.TextBox2.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Try
            If UseEmpSig Then
                Me.EmpSigPic.Image = SigImage
                Me.AuthDate.Text = ReportFunctions.FormatDate(printedDate.ToShortDateString)
            Else
                Me.AuthDate.Text = ""
            End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("SIGNATURE") = 3 Then
                    Me.txtPreparedBy.Text = Me.agencyname & " Authorization:"
                End If
                If dtPrintDef.Rows(0)("EXCL_SIGNATURES") = 1 Then
                    Me.EmpSigPic.Image = Nothing
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub GroupFooter5_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter5.Format
        Try
            Me.txtEstDefaultComment.Text = Me.defFooter
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("DEF_FOOTER_COMMENT") = 1 Then

                    If DefaultFooterFontSize <> 0 Then

                        Me.txtEstDefaultComment.Font = New System.Drawing.Font(Me.txtEstDefaultComment.Font.FontFamily.Name, DefaultFooterFontSize)

                    End If

                    Me.txtEstDefaultComment.Visible = True
                Else
                    Me.txtEstDefaultComment.Text = ""
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader6_BeforePrint(sender As Object, e As EventArgs) Handles GroupHeader6.BeforePrint

    End Sub

    Private Sub GroupHeader6_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader6.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                'If dtPrintDef.Rows(0)("QTE_COMMENT") = 1 Then
                '    Me.txtQuoteComments.Visible = True
                'Else
                '    Me.txtQuoteComments.Text = ""
                'End If
                If dtPrintDef.Rows(0)("REV_COMMENT") = 1 Then
                    Me.txtRevisionComments.Visible = True
                Else
                    Me.txtRevisionComments.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader7_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader7.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "F" Then
                    'Me.rbFunctionCode.Checked = True
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "C" Then
                    'Me.rbConsolidationCode.Checked = True
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                    Me.txtDescription.Text = ""
                    'Me.txtQtyHrs.Text = ""
                    'Me.txtRateLabel.Text = ""
                    'Me.txtAmountText.Text = ""
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
                    'Me.txtRateLabel.Visible = True
                    'Me.txtRevisedAmt.Visible = True
                Else
                    'Me.txtRateLabel.Visible = False
                    'Me.txtRevisedAmt.Visible = False
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                    'Me.txtRateLabel.Visible = False
                    'Me.txtRevisedAmt.Visible = False
                End If
            End If
            If Me.txtQuote3.Text = "" Then
                Me.Line20.Visible = False
            End If
            If Me.txtQuote4.Text = "" Then
                Me.Line21.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Try

            Me.ESTReport = New arptEstHeader
            Me.ESTReport.dt = dt
            Me.ESTReport.dtPrintDef = dtPrintDef
            Me.ESTReport.addressInfo = addressInfo
            Me.ESTReport.addressOption = addressOption
            Me.ESTReport.PrintClientName = PrintClientName
            Me.ESTReport.rpttype = "arptEstimating314"
            Me.SubReport1.Report = ESTReport
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupHeader4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.Format

    End Sub

    Private Sub GroupFooter10_Format(sender As Object, e As System.EventArgs) Handles GroupFooter10.Format
        Try
            If UseEmpSig Then
                Me.Picture2.Image = SigImage
                Me.TextBoxAuthDate.Text = ReportFunctions.FormatDate(printedDate.ToShortDateString)
            Else
                Me.TextBoxAuthDate.Text = ""
            End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("EXCL_SIGNATURES") = 1 Then
                    Me.Picture2.Image = Nothing
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
