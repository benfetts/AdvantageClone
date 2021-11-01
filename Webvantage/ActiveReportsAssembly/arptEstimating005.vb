Imports System.Drawing
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class arptEstimating005
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
    Public SigImage As System.Drawing.Image
    Public UseEmpSig As Boolean
    Public agencyname As String
    Public ESTReport As arptEstHeader
    Public DefaultFooterFontSize As Double = 0
    Public rptFormat As String
    Public PrintClientName As String
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Public CultureCode As String = "en-US"
    Private Sub arptEstimating005_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
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
                Me.GroupFooter4.NewPage = NewPage.After
                Me.GroupFooter4.Visible = True
                Me.TextBox3.Text = ""
                Me.TextBox7.Text = ""
                Me.TextBox11.Text = ""
                Me.TextBox13.Text = ""
                Me.TextBox14.Text = ""
                Me.TextBox15.Text = ""
                Me.TextBox16.Text = ""
                Me.TextBox17.Text = ""
                Me.TextBox12.Text = ""
                Me.Line12.Visible = False
                Me.Line13.Visible = False
                Me.Line14.Visible = False
                Me.Line18.Visible = False
                Me.Line19.Visible = False
                Me.Line20.Visible = False
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 4 Then
                Me.GroupFooter3.NewPage = NewPage.None
                Me.GroupFooter4.NewPage = NewPage.After
                Me.GroupFooter4.Visible = True
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 5 Then
                Me.GroupFooter8.Visible = True
                Me.GroupFooter3.NewPage = NewPage.None
                Me.GroupFooter8.NewPage = NewPage.After
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 0 Then
                Me.GroupFooter3.Visible = False
                Me.ReportInfo1.SummaryGroup = "GroupFooter5"
            End If
            If dtPrintDef.Rows(0)("SIGNATURE") = 7 Then
                Me.GroupFooter3.Visible = False
                Me.ReportInfo1.SummaryGroup = "GroupFooter5"
                Me.GroupFooter3.NewPage = NewPage.None
                Me.GroupFooter9.NewPage = NewPage.After
                Me.GroupFooter9.Visible = True
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
            ReportFunctions.SetCulture(Me, CultureCode)
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
                    Me.txtVariance.Visible = False
                    Me.txtRevisedAmt.Visible = False
                    Me.txtOriginalAmt.Visible = False
                    If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
                        Me.GroupFooter2.Visible = False
                    End If
                Else
                    Me.txtVariance.Visible = True
                    Me.txtRevisedAmt.Visible = True
                    Me.txtOriginalAmt.Visible = True
                End If
                If dtPrintDef.Rows(0)("CONSOL_OVERRIDE") = 1 Then
                    'Me.cbOverride.Checked = True
                End If
            End If
            If Me.txtOneRev.Text = "1" Then
                Me.txtOriginalLabel.Text = ""
                Me.txtRevisedLabel.Text = "Original Estimate"
            Else
                Me.txtOriginalLabel.Text = "Original Estimate"
                If rptFormat = "304" Then
                    Me.txtRevisedLabel.Text = "Final Estimate"
                Else
                    Me.txtRevisedLabel.Text = "Revised Estimate"
                End If
            End If

            If Me.txtOriginalAmt.Text <> "" Then
                Me.txtOriginalAmt.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtOriginalAmt.Text)))
            End If
            If Me.txtVariance.Text <> "" Then
                Me.txtVariance.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtVariance.Text)))
            End If
            If Me.txtRevisedAmt.Text <> "" Then
                Me.txtRevisedAmt.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedAmt.Text)))
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
                            If Me.txtOrigContingency.Text <> "" Then
                                'Me.txtOriginalAmt.Text = CDec(Me.txtOriginalAmt.Text) + CDec(Me.txtOrigContingency.Text)
                            End If
                        Else
                            If Me.txtOrigContingency.Text <> "" Then
                                Me.txtOriginalAmt.Text = CDec(ReportFunctions.FormatDecimal(Me.txtOriginalAmt.Text)) '+ CDec(Me.txtOrigMUCont.Text)
                            End If
                        End If
                    End If
                End If
                If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then

                Else
                    Me.txtOriginalAmt.Text = CDec(ReportFunctions.FormatDecimal(Me.txtOriginalAmt.Text)) '+ CDec(Me.txtOrigTaxAmount.Text)
                    Me.txtRevisedAmt.Text = CDec(ReportFunctions.FormatDecimal(Me.txtRevisedAmt.Text)) '+ CDec(Me.txtRevisedTax.Text)
                End If
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then

                Else
                    Me.txtOriginalAmt.Text = CDec(ReportFunctions.FormatDecimal(Me.txtOriginalAmt.Text)) '+ CDec(Me.txtOrigMarkupAmt.Text)
                    Me.txtRevisedAmt.Text = CDec(ReportFunctions.FormatDecimal(Me.txtRevisedAmt.Text)) '+ CDec(Me.txtRevisedMarkupAmt.Text)
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
                    'Me.txtSubTotal.Text = ""
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
                    Me.txtSuppliedByNotes.Visible = True
                Else
                    Me.txtSuppliedByNotes.Text = ""
                End If

            End If

            If Me.txtOneRev.Text = "1" Then
                'If combined = True Then
                '    Me.txtRevisedAmt.Text = Me.txtOriginalAmt.Text
                'End If
                Me.txtOriginalAmt.Text = ""
                Me.txtOriginalLabel.Text = ""
                Me.txtRevisedLabel.Text = "Original Estimate"
                Me.txtVariance.Text = "0.00"
            Else
                Me.txtOriginalLabel.Text = "Original Estimate"
                If rptFormat = "304" Then
                    Me.txtRevisedLabel.Text = "Final Estimate"
                Else
                    Me.txtRevisedLabel.Text = "Revised Estimate"
                End If
                Me.txtVariance.Text = CDec(ReportFunctions.FormatDecimal(Me.txtRevisedAmt.Text)) - CDec(ReportFunctions.FormatDecimal(Me.txtOriginalAmt.Text))
            End If

            'If Me.txtLineTotal.Text <> "" Then
            '    CPU = CPU + CDec(Me.txtLineTotal.Text)
            'End If
            'If Me.txtContingency.Text <> "" Then
            '    Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtContingency.Text)
            'End If
            'Me.txtOriginalAmt.Text = String.Format("{0:#,##0.00}", CDec(Me.txtOriginalAmt.Text))
            'Me.txtRevisedAmt.Text = String.Format("{0:#,##0.00}", CDec(Me.txtRevisedAmt.Text))
            'Me.txtVariance.Text = String.Format("{0:#,##0.00}", CDec(Me.txtVariance.Text))

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
            'If Me.txtOrigCont2Total.Text <> "" Then
            '    Me.txtOrigCont2Total.Text = String.Format("{0:#,##0.00}", CDec(Me.txtOrigCont2Total.Text))
            'End If
            'If Me.txtRevisedCont2Total.Text <> "" Then
            '    Me.txtRevisedCont2Total.Text = String.Format("{0:#,##0.00}", CDec(Me.txtRevisedCont2Total.Text))
            'End If
            If Me.txtOrigCommission.Text <> "" Then
                Me.txtOrigCommission.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtOrigCommission.Text)))
            End If
            If Me.txtRevisedCommission.Text <> "" Then
                Me.txtRevisedCommission.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedCommission.Text)))
            End If
            If Me.txtOriginalSubtotal.Text <> "" Then
                Me.txtOriginalSubtotal.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtOriginalSubtotal.Text)))
            End If
            If Me.txtRevisedSubTotal.Text <> "" Then
                Me.txtRevisedSubTotal.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedSubTotal.Text)))
            End If
            If Me.txtOriginalTax.Text <> "" Then
                Me.txtOriginalTax.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtOriginalTax.Text)))
            End If
            If Me.txtRevisedTaxAmt.Text <> "" Then
                Me.txtRevisedTaxAmt.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedTaxAmt.Text)))
            End If
            If Me.txtVarianceSubTotal.Text <> "" Then
                Me.txtVarianceSubTotal.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceSubTotal.Text)))
            End If
            If Me.txtVarianceCont2Total.Text <> "" Then
                Me.txtVarianceCont2Total.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceCont2Total.Text)))
            End If
            If Me.txtVarianceCommission.Text <> "" Then
                Me.txtVarianceCommission.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceCommission.Text)))
            End If
            If Me.txtVarianceTax.Text <> "" Then
                Me.txtVarianceTax.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceTax.Text)))
            End If
            'Me.txtTotalForEst.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalForEst.Text))
            If Me.txtOneRevTotal.Text = "1" Then
                'If combined = True Then
                '    Me.txtRevisedSubTotal.Text = Me.txtOriginalSubtotal.Text
                '    Me.txtRevisedTax.Text = Me.txtOriginalTax.Text
                '    Me.txtRevisedCommission.Text = Me.txtOrigCommission.Text
                '    Me.txtRevisedTotalForEst.Text = Me.txtOrigTotalForEst.Text
                '    Me.txtRevisedCont2Total.Text = Me.txtOrigCont2Total.Text
                'End If
                Me.txtOriginalSubtotal.Text = ""
                Me.txtOriginalTax.Text = ""
                Me.txtOrigCommission.Text = ""
                Me.txtOrigTotalForEst.Text = ""
                Me.txtOrigCont2Total.Text = ""
                Me.txtVarianceSubTotal.Text = "0.00"
                Me.txtVarianceTotalEst.Text = "0.00"
                Me.Line17.Visible = False
                Me.txtOriginalCPU.Text = ""
                Me.txtOriginalCPM.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try

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
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 And dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
                    'Me.txtCommission.Text = CDec(Me.txtCommission.Text) + CDec(Me.txtMUContTotal.Text)
                    Me.txtOrigCommission.Text = CDec(Me.txtOrigCommission.Text) '+ CDec(Me.txtOrigMUContTotal.Text)
                    Me.txtRevisedCommission.Text = CDec(Me.txtRevisedCommission.Text) '+ CDec(Me.txtRevisedMUContTotal.Text)
                End If
                If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                    Me.txtOrigCont2Total.Text = CDec(Me.txtOrigCont2Total.Text) + CDec(Me.txtOrigMUContTotal.Text)
                    Me.txtRevisedCont2Total.Text = CDec(Me.txtRevisedCont2Total.Text) + CDec(Me.txtRevisedMUContTotal.Text)
                    'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtContTotal2.Text)
                End If
            End If
            'Me.txtTotalForEst.Text = CDec(Me.txtSubTotal.Text)
            Me.txtOrigTotalForEst.Text = CDec(Me.txtOriginalSubtotal.Text)
            Me.txtRevisedTotalForEst.Text = CDec(Me.txtRevisedSubTotal.Text)
            If Me.txtOriginalSubtotal.Text <> "0.00" And Me.txtRevisedSubTotal.Text <> "0.00" Then
                Me.txtVarianceSubTotal.Text = CDec(Me.txtRevisedSubTotal.Text) - CDec(Me.txtOriginalSubtotal.Text)
            End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                    'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtCommission.Text)
                    Me.txtOrigTotalForEst.Text = CDec(Me.txtOrigTotalForEst.Text) + CDec(Me.txtOrigCommission.Text)
                    Me.txtRevisedTotalForEst.Text = CDec(Me.txtRevisedTotalForEst.Text) + CDec(Me.txtRevisedCommission.Text)
                End If
                If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                    'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtTax.Text)
                    Me.txtOrigTotalForEst.Text = CDec(Me.txtOrigTotalForEst.Text) + CDec(Me.txtOriginalTax.Text)
                    Me.txtRevisedTotalForEst.Text = CDec(Me.txtRevisedTotalForEst.Text) + CDec(Me.txtRevisedTaxAmt.Text)
                End If
                If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                    'Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text)
                    Me.txtOrigTotalForEst.Text = CDec(Me.txtOrigTotalForEst.Text) + CDec(Me.txtOrigCont2Total.Text)
                    Me.txtRevisedTotalForEst.Text = CDec(Me.txtRevisedTotalForEst.Text) + CDec(Me.txtRevisedCont2Total.Text)
                End If
            End If

            Me.txtVarianceCommission.Text = CDec(Me.txtRevisedCommission.Text) - CDec(Me.txtOrigCommission.Text)
            Me.txtVarianceTax.Text = CDec(Me.txtRevisedTaxAmt.Text) - CDec(Me.txtOriginalTax.Text)
            If Me.txtOrigTotalForEst.Text <> "0.00" And Me.txtRevisedTotalForEst.Text <> "0.00" Then
                Me.txtVarianceTotalEst.Text = CDec(Me.txtRevisedTotalForEst.Text) - CDec(Me.txtOrigTotalForEst.Text)
            End If

            'Me.txtTotalForEst.Text = String.Format("{0:c}", CDec(Me.txtTotalForEst.Text))
            ReportFunctions.SetCulture(Me, CultureCode)
            Me.txtVarianceCommission.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceCommission.Text)))
            Me.txtVarianceTax.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceTax.Text)))

            Me.txtOrigCont2Total.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtOrigCont2Total.Text)))
            Me.txtRevisedCont2Total.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedCont2Total.Text)))
            Me.txtOrigTotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtOrigTotalForEst.Text)))
            Me.txtRevisedTotalForEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedTotalForEst.Text)))
            Me.txtVarianceTotalEst.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceTotalEst.Text)))
            Me.txtVarianceCont2Total.Text = CDec(ReportFunctions.FormatDecimal(Me.txtRevisedCont2Total.Text)) - CDec(ReportFunctions.FormatDecimal(Me.txtOrigCont2Total.Text))
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
                    Me.txtTaxLabel.Text = "Tax:"
                    Me.txtTaxLabel.Visible = True
                    If Me.txtOneRevTotal.Text = "1" Then
                        Me.txtVarianceTax.Text = "0.00"
                    End If
                    'Me.txtTax.Visible = True
                    Me.Line15.Visible = True
                    Me.Line16.Visible = True
                    If Me.txtOrigTotalForEst.Text <> "" And Me.txtOrigTotalForEst.Text <> "$0.00" Then
                        Me.Line17.Visible = True
                    End If
                Else
                    'Me.txtTax.Text = ""
                    Me.txtTaxLabel.Text = ""
                    'Me.txtSubTotalLabel.Text = ""
                    Me.txtOriginalTax.Text = ""
                    Me.txtRevisedTaxAmt.Text = ""
                    Me.txtVarianceTax.Text = ""
                    'Me.txtSubTotal.Text = ""
                End If
                If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
                    Me.txtCommissionLabel.Text = "Commission:"
                    Me.txtCommissionLabel.Visible = True
                    If Me.txtOneRevTotal.Text = "1" Then
                        Me.txtVarianceCommission.Text = "0.00"
                    End If
                    'Me.txtCommission.Visible = True
                    Me.Line15.Visible = True
                    Me.Line16.Visible = True
                    If Me.txtOrigTotalForEst.Text <> "" And Me.txtOrigTotalForEst.Text <> "$0.00" Then
                        Me.Line17.Visible = True
                    End If
                Else
                    Me.txtCommissionLabel.Text = ""
                    'Me.txtCommission.Text = ""
                    'Me.txtSubTotalLabel.Text = ""
                    Me.txtOrigCommission.Text = ""
                    Me.txtRevisedCommission.Text = ""
                    Me.txtVarianceCommission.Text = ""
                    'Me.txtSubTotal.Text = ""
                End If
                If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
                    If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
                        Me.txtContLabel.Text = "Contingency:"
                        Me.txtContLabel.Visible = True
                        'Me.txtContTotal2.Visible = True
                        Me.txtRevisedCont2Total.Visible = True
                        Me.txtOrigCont2Total.Visible = True
                        If Me.txtOneRevTotal.Text = "1" Then
                            Me.txtVarianceCont2Total.Text = "0.00"
                            'Me.txtVarianceGroupingTotal.Text = "0.00"
                            'Me.txtVarianceTotalEst.Text = "0.00"
                        End If
                        Me.Line15.Visible = True
                        Me.Line16.Visible = True
                        If Me.txtOrigTotalForEst.Text <> "" And Me.txtOrigTotalForEst.Text <> "$0.00" Then
                            Me.Line17.Visible = True
                        End If
                    Else
                        Me.txtContLabel.Text = ""
                        'Me.txtContTotal2.Text = ""
                        'Me.txtSubTotalLabel.Text = ""
                        Me.txtVarianceCont2Total.Text = ""
                        'Me.txtSubTotal.Text = ""
                    End If
                Else
                    Me.txtContLabel.Text = ""
                    Me.txtVarianceCont2Total.Text = ""
                    'Me.txtContTotal2.Text = ""
                End If
                If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
                    ' Me.txtSubTotal.Text = ""
                    Me.txtOriginalSubtotal.Text = ""
                    Me.txtRevisedSubTotal.Text = ""
                    Me.txtVarianceSubTotal.Text = ""
                    Me.txtSubTotalLabel.Text = ""
                    'Me.Line12.Visible = False
                    'Me.Line13.Visible = False
                    'Me.Line14.Visible = False
                    Me.Line15.Visible = True
                    Me.Line16.Visible = True
                    If Me.txtOrigTotalForEst.Text <> "" And Me.txtOrigTotalForEst.Text <> "$0.00" Then
                        Me.Line17.Visible = True
                    End If
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
                    If dtPrintDef.Rows(0)("SUBTOT_ONLY") <> 1 Then
                        Me.txtSubTotalLabel.Text = ""
                    End If
                    'Me.txtSubTotal.Text = ""
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
                    'Me.txtSubTotalLabel.Text = ""
                End If
                If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                    'Me.txtSubTotalLabel.Text = ""
                End If
            End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("PRT_CPU") = 1 Then
                    If Me.txtOriginalCPU.Text <> "" Then
                        Me.txtOriginalCPU.Text = "CPU: " & Me.txtOriginalCPU.Text
                    End If
                    If Me.txtRevisedCPU.Text <> "" Then
                        Me.txtRevisedCPU.Text = "CPU: " & Me.txtRevisedCPU.Text
                    End If
                Else
                    Me.txtOriginalCPU.Text = ""
                    Me.txtRevisedCPU.Text = ""
                End If
                If dtPrintDef.Rows(0)("PRT_CPM") = 1 Then
                    If Me.txtOriginalCPM.Text <> "" Then
                        Me.txtOriginalCPM.Text = "CPM: " & Me.txtOriginalCPM.Text
                    End If
                    If Me.txtRevisedCPM.Text <> "" Then
                        Me.txtRevisedCPM.Text = "CPM: " & Me.txtRevisedCPM.Text
                    End If
                Else
                    Me.txtOriginalCPM.Text = ""
                    Me.txtRevisedCPM.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            'Me.txtTotalGrouping.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalGrouping.Text))
            Me.txtOrigTotalGrouping.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtOrigTotalGrouping.Text)))
            Me.txtRevisedTotalGrouping.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtRevisedTotalGrouping.Text)))
            Me.txtVarianceGroupingTotal.Text = String.Format("{0:#,##0.00}", CDec(ReportFunctions.FormatDecimal(Me.txtVarianceGroupingTotal.Text)))
            If Me.txtOneRevTotal.Text = "1" Then
                'If combined = True Then
                '    Me.txtRevisedTotalGrouping.Text = Me.txtOrigTotalGrouping.Text
                'End If
                Me.Line11.Visible = False
                Me.txtOrigTotalGrouping.Text = ""
                Me.txtVarianceGroupingTotal.Text = "0.00"
            End If
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
                    'Me.txtTotalGrouping.Text = ""
                    Me.txtTotalLabel.Text = ""
                End If
                If dtPrintDef.Rows(0)("SUBTOT_ONLY") = 1 Then
                    Me.Line9.Visible = False
                    Me.Line10.Visible = False
                    Me.Line11.Visible = False
                End If
                'If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
                '    Me.txtTotalGrouping.Text = ""
                '    Me.txtTotalLabel.Text = ""
                '    'Me.GroupFooter2.Visible = False
                'End If
                'If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "F" Then
                '    Me.txtTotalGrouping.Text = ""
                '    Me.txtTotalLabel.Text = ""
                '    'Me.GroupFooter2.Visible = False
                'End If
            End If
            Me.txtVarianceGroupingTotal.Text = CDec(Me.txtRevisedTotalGrouping.Text) - CDec(Me.txtOrigTotalGrouping.Text)
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
                Me.txtEstCompNumber.Text = Me.txtEstCompNumber.Text.PadLeft(2, "0")
                If Me.txtJobCompNumber.Text <> "" Then
                    Me.txtJobCompNumber.Text = Me.txtJobCompNumber.Text.PadLeft(2, "0")
                End If
                Me.txtQuoteNumber.Text = Me.txtQuoteNumber.Text.PadLeft(2, "0")
            End If
            If TextBoxCampaignId.Text <> "" Then
                Me.TextBoxCampaign.Visible = True
                Me.TextBoxCampaignName.Visible = True
                Me.txtJobNumber.Visible = False = False
                Me.txtJobCompNumber.Visible = False
                Me.txtJobDesc.Visible = False
                Me.txtJobCompDesc.Visible = False
                Me.TextBox5.Visible = False
                Me.TextBox6.Visible = False
            Else
                Me.TextBoxCampaign.Visible = False
                Me.TextBoxCampaignName.Visible = False
                If Me.txtJobNumber.Text = "" Then
                    Me.txtJobNumber.Visible = False = False
                    Me.txtJobCompNumber.Visible = False
                    Me.txtJobDesc.Visible = False
                    Me.txtJobCompDesc.Visible = False
                    Me.TextBox5.Visible = False
                    Me.TextBox6.Visible = False
                End If
            End If
            'Me.txtRevisionNumber.Text = Me.txtRevisionNumber.Text.PadLeft(2, "0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                'If dtPrintDef.Rows(0)("PRT_CPU") = 1 Then
                '    Me.txtCPULabel.Text = "Cost Per Unit:"
                '    Me.txtCPU.Text = (Math.Truncate(CDec(Me.txtCPU.Text) * 1000) / 1000).ToString
                'Else
                '    Me.txtCPU.Text = ""
                '    Me.txtCPULabel.Text = ""
                'End If
            End If
            If dtPrintDef.Rows.Count > 0 Then
                'If dtPrintDef.Rows(0)("PRT_CPM") = 1 Then
                '    Me.TxtCPMLabel.Text = "Cost Per Thousand:"
                '    Me.txtCPM.Text = CDec(Me.txtCPU.Text) * 1000
                'Else
                '    Me.txtCPM.Text = ""
                '    Me.TxtCPMLabel.Text = ""
                'End If
                If dtPrintDef.Rows(0)("CLI_REF") = 1 Then
                    Me.txtClientRefLabel.Visible = True
                    Me.txtClientRef.Visible = True
                Else
                    Me.txtClientRefLabel.Text = ""
                    Me.txtClientRef.Text = ""
                End If
                If dtPrintDef.Rows(0)("AE_NAME") = 1 Then
                    Me.txtAccExeLabel.Visible = True
                    Me.txtAccountExective.Visible = True
                Else
                    Me.txtAccExeLabel.Text = ""
                    Me.txtAccountExective.Text = ""
                End If
                If dtPrintDef.Rows(0)("PRT_SALES_CLASS") = 1 Then
                    Me.txtSalesClassLabel.Visible = True
                    Me.txtSalesClass.Visible = True
                Else
                    Me.txtSalesClassLabel.Text = ""
                    Me.txtSalesClass.Text = ""
                End If
                If dtPrintDef.Rows(0)("JOB_QTY") = 1 Then
                    Me.txtEstQuantityLabel.Visible = True
                    Me.txtEstQuantity.Visible = True
                Else
                    Me.txtEstQuantityLabel.Text = ""
                    Me.txtEstQuantity.Text = ""
                End If
                If dtPrintDef.Rows(0)("HIDE_COMP_DESC") = 1 Then
                    Me.txtJobCompDesc.Text = ""
                    Me.txtEstCompDesc.Text = ""
                Else
                    Me.txtJobCompDesc.Visible = True
                    Me.txtEstCompDesc.Visible = True
                End If
                If dtPrintDef.Rows(0)("JOB_DUE_DATE") = 1 Then
                    Me.TextBox10.Visible = True
                    Me.txtJobDueDate.Visible = True
                Else
                    Me.TextBox10.Text = ""
                    Me.txtJobDueDate.Text = ""
                End If
            End If
            If combined = True Then
                Me.txtEstCompNumber.Text = ""
                Me.txtEstCompDesc.Text = ""
                Me.TextBox1.Text = ""
                'Me.txtEstQuantityLabel.Text = ""
                'Me.txtEstQuantity.Text = ""
                'Me.txtCPU.Text = ""
                'Me.txtCPULabel.Text = ""
                'Me.txtCPM.Text = ""
                'Me.TxtCPMLabel.Text = ""
                'Me.txtQuoteNumber.Text = ""
                'Me.txtQuoteDesc.Text = ""
                'Me.txtRevisionNumber.Text = ""
                'Me.TextBox2.Text = ""
                'Me.TextBox3.Text = ""
                'Me.txtAccountExective.Text = ""
                'Me.txtAccExeLabel.Text = ""
                'Me.txtJobNumber.Text = ""
                'Me.txtJobDesc.Text = ""
                Me.txtJobCompNumber.Text = ""
                Me.txtJobCompDesc.Text = ""
                Me.TextBox5.Text = ""
                'Me.TextBox6.Text = ""
            End If
            If Me.txtJobNumber.Text = "0" Then
                Me.txtJobNumber.Text = ""
            End If
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

    Private Sub GroupHeader3_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Try
            Me.ESTReport = New arptEstHeader
            Me.ESTReport.dt = dt
            Me.ESTReport.dtPrintDef = dtPrintDef
            Me.ESTReport.addressInfo = addressInfo
            Me.ESTReport.addressOption = addressOption
            Me.ESTReport.PrintClientName = PrintClientName
            Me.SubReport1.Report = ESTReport
            If combined = True Then
                Me.txtEstimateHdr.Text = Me.est.Text & " - " & Me.quote.Text
            Else
                Me.txtEstimateHdr.Text = Me.est.Text & " - " & Me.estcomp.Text & " - " & Me.quote.Text
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

    Private Sub GroupHeader6_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader6.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("EST_COMMENT") = 1 Then
                    Me.txtEstimateComments.Visible = True
                Else
                    Me.txtEstimateComments.Text = ""
                End If
                If dtPrintDef.Rows(0)("EST_COMP_COMMENT") = 1 Then
                    Me.txtComponentComments.Visible = True
                Else
                    Me.txtComponentComments.Text = ""
                End If
                If dtPrintDef.Rows(0)("QTE_COMMENT") = 1 Then
                    Me.txtQuoteComments.Visible = True
                Else
                    Me.txtQuoteComments.Text = ""
                End If
                If dtPrintDef.Rows(0)("REV_COMMENT") = 1 Then
                    Me.txtRevisionComments.Visible = True
                Else
                    Me.txtRevisionComments.Text = ""
                End If
            End If
            If Me.txtOneRev.Text = "1" Then
                Me.txtOriginalLabel.Text = ""
                Me.txtRevisedLabel.Text = "Original Estimate"
            Else
                Me.txtOriginalLabel.Text = "Original Estimate"
                If rptFormat = "304" Then
                    Me.txtRevisedLabel.Text = "Final Estimate"
                Else
                    Me.txtRevisedLabel.Text = "Revised Estimate"
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.Format

    End Sub

    Private Sub GroupFooter9_Format(sender As Object, e As System.EventArgs) Handles GroupFooter9.Format
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
