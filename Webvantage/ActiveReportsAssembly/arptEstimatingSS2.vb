﻿Imports System.Drawing
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class arptEstimatingSS2
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
    Public addressInfoProd As DataTable
    Public dt As DataTable
    Public dtLocation As DataTable
    Public dtPrintDef As DataTable
    Public dtJobVersion As DataTable
    Public taxed As Boolean = False
    Public commissioned As Boolean = False
    Public combined As Boolean = False
    Public signature As Integer
    Public UseEmpSig As Boolean
    Public agencyname As String
    Public SigImage As System.Drawing.Image
    Public ESTReport As arptEstHeaderSS1
    Public connstring As String
    Public DefaultFooterFontSize As Double = 0
    Public CultureCode As String = "en-US"
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Private Sub arptEstimating_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("GROUP_OPTION") = "T" Then
            '        Me.GroupHeader2.DataField = "EST_FNC_TYPE"
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
            '        'Me.GroupHeader2.DataField = "FNC_CODE"
            '        Me.GroupFooter2.Visible = False
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "H" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '        Me.GroupHeader2.DataField = "FNC_HEADING_ID"
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "I" Then
            '        Me.GroupHeader2.DataField = "INOUT"
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "P" Then
            '        Me.GroupHeader2.DataField = "EST_PHASE_DESC"
            '    Else
            '        Me.GroupHeader2.DataField = ""
            '    End If
            'End If
            Me.DataSource = dt
            If Me.LogoID = "None" Then
                Me.PageHeader1.Controls.Remove(Me.Picture1)
            End If


            'Me.SubReport1.Report = ESTReport
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("RPT_TITLE") <> "" Then
                    Me.txtTitle.Text = dtPrintDef.Rows(0)("RPT_TITLE")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("GROUP_OPTION") = "T" Then
            '        'Me.txtFunctionType.Visible = True
            '        Me.txtFunctionHeading.Text = ""
            '        Me.txtInsideDesc.Text = ""
            '        Me.txtPhaseDesc.Text = ""
            '        Me.TextBox4.Visible = False
            '        Me.TextBox7.Visible = False
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
            '        Me.txtFunctionType.Text = ""
            '        Me.txtFunctionHeading.Text = ""
            '        Me.txtInsideDesc.Text = ""
            '        Me.txtPhaseDesc.Text = ""
            '        Me.GroupHeader2.Visible = False
            '        Me.TextBox4.Visible = False
            '        Me.TextBox7.Visible = False
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "H" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '        If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '            Me.txtFunctionHeading.Text = ""
            '            Me.txtQty.Text = ""
            '        Else
            '            Me.txtFunctionHeading.Visible = True
            '            Me.TextBox4.Visible = False
            '            Me.TextBox7.Visible = False
            '        End If
            '        Me.txtFunctionType.Text = ""
            '        Me.txtInsideDesc.Text = ""
            '        Me.txtPhaseDesc.Text = ""
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "I" Then
            '        Me.txtInsideDesc.Visible = True
            '        Me.txtFunctionType.Text = ""
            '        Me.txtFunctionHeading.Text = ""
            '        Me.txtPhaseDesc.Text = ""
            '        Me.TextBox4.Visible = False
            '        Me.TextBox7.Visible = False
            '        If Me.txtIO.Text = "I" Then
            '            Me.txtInsideDesc.Text = dtPrintDef.Rows(0)("INSIDE_CHG_DESC")
            '        End If
            '        If Me.txtIO.Text = "O" Then
            '            Me.txtInsideDesc.Text = dtPrintDef.Rows(0)("OUTSIDE_CHG_DESC")
            '        End If
            '        If Me.txtIO.Text = "C" Then
            '            Me.txtInsideDesc.Text = "Client Out of Pocket"
            '        End If
            '    ElseIf dtPrintDef.Rows(0)("GROUP_OPTION") = "P" Then
            '        Me.txtInsideDesc.Text = ""
            '        Me.txtFunctionType.Text = ""
            '        Me.txtFunctionHeading.Text = ""
            '        Me.TextBox4.Visible = False
            '        Me.TextBox7.Visible = False
            '    Else
            '        Me.txtFunctionType.Text = ""
            '        Me.txtFunctionHeading.Text = ""
            '        Me.txtInsideDesc.Text = ""
            '        Me.txtPhaseDesc.Text = ""
            '        Me.GroupHeader2.Visible = False
            '        Me.TextBox4.Visible = False
            '        Me.TextBox7.Visible = False
            '    End If
            'End If
            'If Me.txtFunctionType.Text = "E" Then
            '    Me.txtFunctionType.Text = "Employee Time Charges"
            'End If
            'If Me.txtFunctionType.Text = "V" Then
            '    Me.txtFunctionType.Text = "Vendor Charges"
            'End If
            'If Me.txtFunctionType.Text = "I" Then
            '    Me.txtFunctionType.Text = "Miscellaneous Charges"
            'End If
            'If Me.txtFunctionType.Text = "C" Then
            '    Me.txtFunctionType.Text = "Client Out of Pocket"
            'End If
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
                        'Me.txtTerms.Text = footer
                    End If
                Else
                    Me.txtTerms.Text = ""
                End If

            End If
            Me.txtTaxableText.Text = ""
            If dtPrintDef.Rows.Count > 0 Then
                'If dtPrintDef.Rows(0)("TAX_INDICATOR") = 1 And taxed = True Then
                '    Me.txtTaxableText.Text = "*Taxable"
                'End If
                'If dtPrintDef.Rows(0)("COMM_MU_INDICATOR") = 1 And commissioned = True And taxed = False Then
                '    Me.txtTaxableText.Text = "^Commissionable"
                'ElseIf dtPrintDef.Rows(0)("COMM_MU_INDICATOR") = 1 And commissioned = True Then
                '    Me.txtTaxableText.Text &= ", ^Commissionable"
                'End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Try
            'If dtPrintDef.Rows.Count > 0 Then

            '    'If dtPrintDef.Rows(0)("SELECT_BY") = "E" Then
            '    '    Me.rbEstimate.Checked = True
            '    'End If
            '    'If dtPrintDef.Rows(0)("SELECT_BY") = "J" Then
            '    '    Me.rbJob.Checked = True
            '    'End If
            '    'If dtPrintDef.Rows(0)("DATE_TO_PRINT") = 2 Then
            '    '    Me.txtDates.Text = printedDate.ToShortDateString
            '    'End If
            '    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then

            '    Else
            '        'Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtTax.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("TAX_INDICATOR") = 1 And Me.txtTaxAmount.Text <> "0.00" Then
            '        'Me.txtTaxable.Visible = True
            '        'Me.taxed = True
            '    Else
            '        'Me.txtTaxable.Visible = False
            '    End If
            '    If combined = True And Me.txtTaxGrouping.Text <> "0.00" Then
            '        'Me.txtTaxable.Visible = True
            '        'Me.taxed = True
            '    Else
            '        'Me.txtTaxable.Visible = False
            '    End If

            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then

            '    Else
            '        ' Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtMarkupAmt.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("COMM_MU_INDICATOR") = 1 And Me.txtMarkupAmt.Text <> "0.00" Then
            '        'Me.txtCommissionable.Visible = True
            '        'Me.commissioned = True
            '    Else
            '        'Me.txtCommissionable.Visible = False
            '    End If


            '    If dtPrintDef.Rows(0)("SORT_OPTION") = "C" Then
            '        'Me.rbFunctionCodeSort.Checked = True
            '    End If
            '    If dtPrintDef.Rows(0)("SORT_OPTION") = "O" Then
            '        'Me.rbFunctionOrderSort.Checked = True
            '    End If


            '    If dtPrintDef.Rows(0)("SPECS") = 1 Then
            '        'Me.cbSpecs.Checked = True
            '    End If

            '    If dtPrintDef.Rows(0)("SUPPRESS_ZERO") = 1 Then
            '        'Me.cbSuppresZero.Checked = True
            '    End If
            '    If dtPrintDef.Rows(0)("PRT_NONBILL") = 1 Then
            '        'Me.cbIncludeNonBillable.Checked = True
            '    End If
            '    'If dtPrintDef.Rows(0)("PRT_DIV_NAME") = 1 Then
            '    '    Me.txtDivision.Visible = True
            '    'Else
            '    '    Me.txtDivision.Text = ""
            '    'End If
            '    'If dtPrintDef.Rows(0)("PRT_PRD_NAME") = 1 Then
            '    '    Me.txtProduct.Visible = True
            '    'Else
            '    '    Me.txtProduct.Text = ""
            '    'End If
            '    If dtPrintDef.Rows(0)("QTY_HRS") = 1 Then
            '        'Me.txtQty.Visible = True
            '        'Me.txtQtyHrs.Visible = True
            '    Else
            '        'Me.txtQty.Visible = False
            '        'Me.txtQtyHrs.Visible = False
            '    End If

            '    If dtPrintDef.Rows(0)("SUBTOT_ONLY") = 1 Then
            '        'Me.txtAmount.Visible = False
            '        'If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Or dtPrintDef.Rows(0)("GROUP_OPTION") = "N" Then
            '        'Me.GroupFooter2.Visible = False
            '        'End If
            '    Else
            '        'Me.txtAmount.Visible = True
            '    End If
            '    If dtPrintDef.Rows(0)("CONSOL_OVERRIDE") = 1 Then
            '        'Me.cbOverride.Checked = True
            '    End If
            'End If
            Me.txtDescriptionText.Text = Me.txtDescriptionText.Text & " Subtotal:"
            'Me.txtAmount.Text = String.Format("{0:#,##0.00}", CDec(Me.txtAmount.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
            '        If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then

            '        Else
            '            If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
            '                If Me.txtContingency.Text <> "" Then
            '                    Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtContingency.Text)
            '                End If
            '            Else
            '                If Me.txtContingency.Text <> "" Then
            '                    Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtContingency.Text) + CDec(Me.txtMUCont.Text)
            '                End If
            '            End If
            '        End If
            '    End If
            '    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then

            '    Else
            '        Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtTaxAmount.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then

            '    Else
            '        Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtMarkupAmt.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "F" Then
            '        'Me.rbFunctionCode.Checked = True
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "C" Then
            '        'Me.rbConsolidationCode.Checked = True
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
            '        'Me.txtDescription.Text = ""
            '        'Me.txtQtyHrs.Text = ""
            '        'Me.txtRateLabel.Text = ""
            '        'Me.txtAmountText.Text = ""
            '        Me.GroupHeader2.Visible = False
            '        Me.txtTotalLabel.Text = ""
            '        ' Me.txtSubTotalLabel.Text = ""
            '        Me.txtTotalGrouping.Text = ""
            '        Me.txtSubTotal.Text = ""
            '        'Me.Line10.Visible = False
            '        Me.Detail1.Visible = False
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
            '        'Me.txtRateLabel.Visible = True
            '        Me.txtRate.Visible = True
            '    Else
            '        'Me.txtRateLabel.Visible = False
            '        Me.txtRate.Visible = False
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
            '        'Me.txtRateLabel.Visible = False
            '        Me.txtRate.Visible = False
            '    End If
            '    If dtPrintDef.Rows(0)("FUNC_COMMENT") = 1 Then
            '        Me.txtFunctionComments.Visible = True
            '    Else
            '        Me.txtFunctionComments.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("SUP_BY_NOTES") = 1 Then
            '        Me.txtSuppliedByNotes.Visible = True
            '    Else
            '        Me.txtSuppliedByNotes.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '        Me.txtDescriptionText.Text = ""
            '        Me.txtQty.Text = ""
            '        Me.txtRate.Text = ""
            '        Me.txtAmount.Text = ""
            '        Me.txtFunctionComments.Text = ""
            '        Me.txtSuppliedByNotes.Text = ""
            '        Me.txtCommissionable.Text = ""
            '        Me.txtTaxable.Text = ""
            '    End If
            'End If
            'If Me.txtLineTotal.Text <> "" Then
            '    CPU = CPU + CDec(Me.txtLineTotal.Text)
            'End If
            'If Me.txtContingency.Text <> "" Then
            '    Me.txtAmount.Text = CDec(Me.txtAmount.Text) + CDec(Me.txtContingency.Text)
            'End If
            'Me.txtAmount.Text = String.Format("{0:#,##0.00}", CDec(Me.txtAmount.Text))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        Try
            'Me.txtSubTotal.Text = String.Format("{0:#,##0.00}", CDec(Me.txtSubTotal.Text))
            'Me.txtCommission.Text = String.Format("{0:#,##0.00}", CDec(Me.txtCommission.Text))
            'Me.txtTax.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTax.Text))
            'Me.txtTotalForEst.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalForEst.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try

            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
            '        Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text) + CDec(Me.txtContTotal.Text) + CDec(Me.txtMUContTotal.Text)
            '    ElseIf dtPrintDef.Rows(0)("CONTINGENCY") = 0 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
            '        Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text)
            '    ElseIf dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
            '        Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtContTotal.Text)
            '    ElseIf dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
            '        Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 And dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
            '        Me.txtCommission.Text = CDec(Me.txtCommission.Text) '+ CDec(Me.txtMUContTotal.Text)
            '    End If
            'End If
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
            '        Me.txtTotalForEst.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtCommission.Text) + CDec(Me.txtTax.Text)
            '    Else
            '        Me.txtTotalForEst.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtTax.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
            '        Me.txtContTotal2.Text = CDec(Me.txtContTotal2.Text) + CDec(Me.txtMUContTotal.Text)
            '        Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtContTotal2.Text)
            '    End If
            'End If
            'Me.txtContTotal2.Text = String.Format("{0:#,##0.00}", CDec(Me.txtContTotal2.Text))
            'Me.txtJAmount.Text = Me.txtTotalForEst.Text
            Me.txtTotalForEst.Text = String.Format("{0:c}", CDec(Me.txtTotalForEst.Text))
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("TAX_SEPARATE") = 1 Then
            '        'Me.txtTaxLabel.Text = "Tax:"
            '        'Me.txtTaxLabel.Visible = True
            '        Me.txtTax.Visible = True
            '        'Me.Line11.Visible = True
            '    Else
            '        Me.txtSubTotal.Text = CDec(Me.txtSubTotal.Text) + CDec(Me.txtTax.Text)
            '        Me.txtTax.Text = ""
            '        'Me.txtTaxLabel.Text = ""
            '        ' Me.txtSubTotalLabel.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
            '        'Me.txtCommissionLabel.Text = "Commission:"
            '        'Me.txtCommissionLabel.Visible = True
            '        Me.txtCommission.Visible = True
            '        'Me.Line11.Visible = True
            '    Else
            '        'Me.txtCommissionLabel.Text = ""
            '        Me.txtCommission.Text = ""
            '        'Me.txtSubTotalLabel.Text = ""
            '        'Me.txtSubTotal.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
            '        If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then
            '            'Me.txtContLabel.Text = "Contingency:"
            '            'Me.txtContLabel.Visible = True
            '            Me.txtContTotal2.Visible = True
            '            'Me.Line11.Visible = True
            '        Else
            '            'Me.txtContLabel.Text = ""
            '            Me.txtContTotal2.Text = ""
            '            'Me.txtSubTotalLabel.Text = ""
            '            'Me.txtSubTotal.Text = ""
            '        End If
            '    Else
            '        'Me.txtContLabel.Text = ""
            '        Me.txtContTotal2.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
            '        'Me.txtSubTotalLabel.Text = ""
            '        Me.txtSubTotal.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "R" Then
            '        'Me.txtSubTotalLabel.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "N" Then
            '        'Me.txtSubTotalLabel.Text = ""
            '    End If

            '    If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '        'Me.txtSubTotalLabel.Text = ""
            '        'Me.txtSubTotal.Text = ""
            '        'Me.Line10.Visible = False
            '    End If
            '    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 And dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 And dtPrintDef.Rows(0)("CONT_SEPARATE") <> 1 Then
            '        Me.txtSubTotal.Text = ""
            '        'Me.txtSubTotalLabel.Text = ""
            '        'Me.Line10.Visible = False
            '        'Me.Line11.Visible = True
            '    End If
            'End If

            'Me.ESTReport = New arptEstHeaderSS1
            'Me.ESTReport.dt = dt
            'Me.ESTReport.dtPrintDef = dtPrintDef
            'Me.ESTReport.estnum = Me.est.Text
            'Me.ESTReport.estcompnum = Me.estcomp.Text
            'Me.ESTReport.quotenum = Me.quote.Text
            'Me.ESTReport.revnum = Me.rev.Text
            'Me.ESTReport.connstring = Me.connstring
            'Me.SubReport1.Report = Me.ESTReport

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        Try
            'Me.txtTotalGrouping.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalGrouping.Text))
            'Me.txtTotalForEst.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalForEst.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            'If Me.txtFunctionType.Text <> "" Then
            '    Me.txtTotalLabel.Text = "Total " & Me.txtFunctionType.Text & ":"
            'ElseIf Me.txtFunctionHeading.Text <> "" Then
            '    Me.txtTotalLabel.Text = "Total " & Me.txtFunctionHeading.Text & ":"
            'ElseIf Me.txtInsideDesc.Text <> "" Then
            '    Me.txtTotalLabel.Text = "Total " & Me.txtInsideDesc.Text & ":"
            'ElseIf Me.txtPhaseDesc.Text <> "" Then
            '    Me.txtTotalLabel.Text = "Total " & Me.txtPhaseDesc.Text & ":"
            'End If
            Me.txtTotalLabel.Text = ""
            Me.txtTotalGrouping.Text = ""
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("TAX_SEPARATE") <> 1 Then
            '        Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtTaxGrouping.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") <> 1 Then
            '        Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtMarkupAmtGrouping.Text)
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "T" Then
            '        Me.txtTotalGrouping.Text = ""
            '        Me.txtTotalLabel.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("CONTINGENCY") = 1 Then
            '        If dtPrintDef.Rows(0)("CONT_SEPARATE") = 1 Then

            '        Else
            '            If dtPrintDef.Rows(0)("COMM_MU_SEPARATE") = 1 Then
            '                If Me.txtContingency.Text <> "" Then
            '                    Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtContGrouping.Text)
            '                End If
            '            Else
            '                If Me.txtContingency.Text <> "" Then
            '                    Me.txtTotalGrouping.Text = CDec(Me.txtTotalGrouping.Text) + CDec(Me.txtContGrouping.Text) + CDec(Me.txtMUContGrouping.Text)
            '                End If
            '            End If
            '        End If
            '    End If
            '    If dtPrintDef.Rows(0)("GROUP_OPTION") = "HT" Then
            '        'Me.txtFunctionHeadingTotal.Text = Me.txtTotalGrouping.Text
            '        Me.txtTotalLabel.Text = ""
            '        Me.txtFunctionHeading.Visible = True
            '        Me.Line9.Visible = False
            '        If dtPrintDef.Rows(0)("QTY_HRS") = 1 Then
            '            Me.TextBox7.Visible = True
            '        Else
            '            Me.TextBox7.Visible = False
            '        End If
            '    End If

            '    If dtPrintDef.Rows(0)("SUBTOT_ONLY") = 1 Then
            '        Me.Line9.Visible = False
            '    End If
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
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.BeforePrint
        Try
            'If combined = False Then
            '    Me.txtEstNumber.Text = Me.txtEstNumber.Text.PadLeft(6, "0")
            '    If Me.txtJobNumber.Text <> "" Then
            '        Me.txtJobNumber.Text = Me.txtJobNumber.Text.PadLeft(6, "0")
            '    End If
            '    Me.txtEstCompNumber.Text = Me.txtEstCompNumber.Text.PadLeft(2, "0")
            '    If Me.txtJobCompNumber.Text <> "" Then
            '        Me.txtJobCompNumber.Text = Me.txtJobCompNumber.Text.PadLeft(2, "0")
            '    End If
            '    Me.txtQuoteNumber.Text = Me.txtQuoteNumber.Text.PadLeft(2, "0")
            '    Me.txtRevisionNumber.Text = Me.txtRevisionNumber.Text.PadLeft(2, "0")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "F" Then
            '        'Me.rbFunctionCode.Checked = True
            '    End If
            '    If dtPrintDef.Rows(0)("FUNCTION_OPTION") = "C" Then
            '        'Me.rbConsolidationCode.Checked = True
            '    End If
            'End If
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("PRT_CPU") = 1 Then
            '        ' Me.txtCPULabel.Text = "Cost Per Unit:"
            '    Else
            '        'Me.txtCPU.Text = ""
            '        'Me.txtCPULabel.Text = ""
            '    End If
            'End If
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("PRT_CPM") = 1 Then
            '        'Me.TxtCPMLabel.Text = "Cost Per Thousand:"
            '    Else
            '        'Me.txtCPM.Text = ""
            '        'Me.TxtCPMLabel.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("CLI_REF") = 1 Then
            '        ' Me.txtClientRefLabel.Visible = True
            '        ' Me.txtClientRef.Visible = True
            '    Else
            '        'Me.txtClientRefLabel.Text = ""
            '        'Me.txtClientRef.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("AE_NAME") = 1 Then
            '        'Me.txtAccExeLabel.Visible = True
            '        'Me.txtAccountExective.Visible = True
            '    Else
            '        ' Me.txtAccExeLabel.Text = ""
            '        ' Me.txtAccountExective.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("PRT_SALES_CLASS") = 1 Then
            '        'Me.txtSalesClassLabel.Visible = True
            '        'Me.txtSalesClass.Visible = True
            '    Else
            '        'Me.txtSalesClassLabel.Text = ""
            '        'Me.txtSalesClass.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("JOB_QTY") = 1 Then
            '        'Me.txtEstQuantityLabel.Visible = True
            '        'Me.txtEstQuantity.Visible = True
            '    Else
            '        'Me.txtEstQuantityLabel.Text = ""
            '        'Me.txtEstQuantity.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("HIDE_COMP_DESC") = 1 Then
            '        Me.txtJobCompDesc.Text = ""
            '        Me.txtPO.Text = ""
            '    Else
            '        Me.txtJobCompDesc.Visible = True
            '        Me.txtPO.Visible = True
            '    End If
            '    If dtPrintDef.Rows(0)("HIDE_REVISION") = 1 Then
            '        Me.TextBox3.Text = ""
            '        Me.txtRevisionNumber.Text = ""
            '    Else
            '        Me.TextBox3.Visible = True
            '        Me.txtRevisionNumber.Visible = True
            '    End If
            '    If dtPrintDef.Rows(0)("JOB_DUE_DATE") = 1 Then
            '        'Me.TextBox10.Visible = True
            '        'Me.txtJobDueDate.Visible = True
            '    Else
            '        'Me.TextBox10.Text = ""
            '        'Me.txtJobDueDate.Text = ""
            '    End If
            'End If
            'If combined = True Then
            '    Me.txtEstCompNumber.Text = ""
            '    Me.txtPO.Text = ""
            '    Me.TextBox1.Text = ""
            '    'Me.txtEstQuantityLabel.Text = ""
            '    'Me.txtEstQuantity.Text = ""
            '    'Me.txtCPU.Text = ""
            '    'Me.txtCPULabel.Text = ""
            '    'Me.txtCPM.Text = ""
            '    'Me.TxtCPMLabel.Text = ""
            '    'Me.txtQuoteNumber.Text = ""
            '    'Me.txtQuoteDesc.Text = ""
            '    Me.txtRevisionNumber.Text = ""
            '    'Me.TextBox2.Text = ""
            '    Me.TextBox3.Text = ""
            '    'Me.txtAccountExective.Text = ""
            '    'Me.txtAccExeLabel.Text = ""
            '    'Me.txtJobNumber.Text = ""
            '    'Me.txtJobDesc.Text = ""
            '    Me.txtJobCompNumber.Text = ""
            '    Me.txtJobCompDesc.Text = ""
            '    Me.TextBox5.Text = ""
            '    'Me.TextBox6.Text = ""
            'End If
            'If Me.txtJobNumber.Text = "0" Then
            '    Me.txtJobNumber.Text = ""
            'End If
            'If combined = True Then
            '    Me.txtEstimateHdr.Text = Me.est.Text & " - " & Me.quote.Text
            'Else
            '    Me.txtEstimateHdr.Text = "E" & Me.est.Text & ".C" & Me.estcomp.Text & ".Q" & Me.quote.Text & ".R" & Me.rev.Text & " J:" & Me.txtJobNumber.Text & "." & Me.txtJobCompNumber.Text
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Try
            If UseEmpSig Then
                Me.EmpSigPic.Image = SigImage
                Me.AuthDate.Text = printedDate.ToShortDateString
            Else
                Me.AuthDate.Text = ""
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
            'If dtPrintDef.Rows.Count > 0 Then
            '    If dtPrintDef.Rows(0)("EST_COMMENT") = 1 Then
            '        Me.txtEstimateComments.Visible = True
            '    Else
            '        Me.txtEstimateComments.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("EST_COMP_COMMENT") = 1 Then
            '        Me.txtComponentComments.Visible = True
            '    Else
            '        Me.txtComponentComments.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("QTE_COMMENT") = 1 Then
            '        Me.txtQuoteComments.Visible = True
            '    Else
            '        Me.txtQuoteComments.Text = ""
            '    End If
            '    If dtPrintDef.Rows(0)("REV_COMMENT") = 1 Then
            '        Me.txtRevisionComments.Visible = True
            '    Else
            '        Me.txtRevisionComments.Text = ""
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    

    Private Sub GroupHeader4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.Format

    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
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
            Me.txtAddressInfo.Text = ""
            'If addressOption = "Client" Then
            If addressInfo.Rows.Count > 0 Then
                Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
                'Me.txtDivision.Text = ""
                'Me.txtProduct.Text = ""
                'Me.txtAttnClient.Text = addressInfo.Rows(0)("CL_ATTENTION")
                If addressInfo.Rows(0)("CL_BADDRESS1").ToString <> "" Then
                    Me.txtAddressInfo.Text &= addressInfo.Rows(0)("CL_BADDRESS1")
                End If
                If addressInfo.Rows(0)("CL_BADDRESS2").ToString <> "" Then
                    Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("CL_BADDRESS2")
                End If
                If addressInfo.Rows(0)("CL_BCITY") <> "" Then
                    Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("CL_BCITY")
                End If
                If addressInfo.Rows(0)("CL_BSTATE") <> "" Then
                    Me.txtAddressInfo.Text &= ", " & addressInfo.Rows(0)("CL_BSTATE")
                End If
                If addressInfo.Rows(0)("CL_BZIP") <> "" Then
                    Me.txtAddressInfo.Text &= " " & addressInfo.Rows(0)("CL_BZIP")
                End If
            End If
            'End If
            'If addressOption = "Division" Then
            '    If addressInfo.Rows.Count > 0 Then
            '        Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
            '        'Me.txtDivision.Text = addressInfo.Rows(0)("DIV_NAME")
            '        'Me.txtProduct.Text = ""
            '        'Me.txtContact.Text = addressInfo.Rows(0)("DIV_ATTENTION")
            '        If addressInfo.Rows(0)("DIV_BADDRESS1").ToString <> "" Then
            '            Me.txtAddressInfo.Text &= addressInfo.Rows(0)("DIV_BADDRESS1")
            '        End If
            '        If addressInfo.Rows(0)("DIV_BADDRESS2").ToString <> "" Then
            '            Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("DIV_BADDRESS2")
            '        End If
            '        If addressInfo.Rows(0)("DIV_BCITY") <> "" Then
            '            Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("DIV_BCITY")
            '        End If
            '        If addressInfo.Rows(0)("DIV_BSTATE") <> "" Then
            '            Me.txtAddressInfo.Text &= ", " & addressInfo.Rows(0)("DIV_BSTATE")
            '        End If
            '        If addressInfo.Rows(0)("DIV_BZIP") <> "" Then
            '            Me.txtAddressInfo.Text &= " " & addressInfo.Rows(0)("DIV_BZIP")
            '        End If
            '    End If
            'End If
            'If addressOption = "Product" Then
            If addressInfoProd.Rows.Count > 0 Then
                'Me.txtClient.Text = addressInfo.Rows(0)("CL_NAME")
                'Me.txtDivision.Text = addressInfo.Rows(0)("DIV_NAME")
                Me.txtProduct.Text = addressInfoProd.Rows(0)("PRD_DESCRIPTION")
                Me.txtAttnProduct.Text = addressInfoProd.Rows(0)("PRD_ATTENTION")
                Me.txtAccountContact.Text = addressInfoProd.Rows(0)("USER_DEFINED1")
                Me.txtPhoneNumber.Text = addressInfoProd.Rows(0)("USER_DEFINED2")
                'If addressInfo.Rows(0)("PRD_BILL_ADDRESS1").ToString <> "" Then
                '    Me.txtAddressInfo.Text &= addressInfo.Rows(0)("PRD_BILL_ADDRESS1")
                'End If
                'If addressInfo.Rows(0)("PRD_BILL_ADDRESS2").ToString <> "" Then
                '    Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("PRD_BILL_ADDRESS2")
                'End If
                'If addressInfo.Rows(0)("PRD_BILL_CITY") <> "" Then
                '    Me.txtAddressInfo.Text &= vbCrLf & addressInfo.Rows(0)("PRD_BILL_CITY")
                'End If
                'If addressInfo.Rows(0)("PRD_BILL_STATE") <> "" Then
                '    Me.txtAddressInfo.Text &= ", " & addressInfo.Rows(0)("PRD_BILL_STATE")
                'End If
                'If addressInfo.Rows(0)("PRD_BILL_ZIP") <> "" Then
                '    Me.txtAddressInfo.Text &= " " & addressInfo.Rows(0)("PRD_BILL_ZIP")
                'End If
            End If
            'End If
            'If addressOption = "Contact" Then
            '    If Me.txtCDPContact.Text <> "" Then
            '        Me.txtClient.Text = ""
            '        'Me.txtDivision.Text = ""
            '        Me.txtProduct.Text = ""
            '        'Me.txtContact.Text = Me.txtCDPContact.Text
            '        If Me.txtCCAddress2.Text <> "" Then
            '            Me.txtAddressInfo.Text = Me.txtCCAddress.Text & vbCrLf & Me.txtCCAddress2.Text & vbCrLf & Me.txtCCCity.Text & ", " & Me.txtCCState.Text & " " & Me.txtCCZip.Text
            '        Else
            '            Me.txtAddressInfo.Text = Me.txtCCAddress.Text & vbCrLf & Me.txtCCCity.Text & ", " & Me.txtCCState.Text & " " & Me.txtCCZip.Text
            '        End If
            '    End If
            'End If

            If Me.txtCDPContact.Text <> "" Then
                'Me.txtContact.Text = Me.txtCDPContact.Text
            End If
            If dtPrintDef.Rows.Count > 0 Then
                If dtPrintDef.Rows(0)("PRT_DIV_NAME") = 1 Then
                    'Me.txtDivision.Visible = True
                Else
                    'Me.txtDivision.Text = ""
                End If
                If dtPrintDef.Rows(0)("PRT_PRD_NAME") = 1 Then
                    'Me.txtProduct.Visible = True
                Else
                    'Me.txtProduct.Text = ""
                End If
            End If

            If title <> "" Then
                'Me.txtTitle.Text = title
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
                'If dtPrintDef.Rows(0)("RPT_TITLE") <> "" Then
                '    Me.txtTitle.Text = dtPrintDef.Rows(0)("RPT_TITLE")
                'End If
            End If
            If combined = True Then

            Else
                'Me.txtEstimateHdr.Text = Me.txtEstNumber.Text & " - " & Me.txtEstCompNumber.Text & " - " & Me.txtQuoteNumber.Text & " - " & Me.txtRevisionNumber.Text
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

            Me.txtEstNumText.Text = Me.txtEstNumText.Text & "." & Me.rev.Text
            Me.txtDates.Text = printedDate.ToShortDateString
            Me.txtJB.Text = Me.txtclcode.Text & " " & Me.txtdivcode.Text & " " & Me.txtprdcode.Text & " " & Me.txtJobNumber.Text & " " & Me.txtJobCompNumber.Text
            

            If Me.dtJobVersion.Rows.Count > 0 Then
                For i As Integer = 0 To dtJobVersion.Rows.Count - 1
                    If dtJobVersion.Rows(i)("JV_TMPLT_LABEL") = "PIF" Then
                        If IsDBNull(dtJobVersion.Rows(i)("JOB_VER_VALUE")) = False Then
                            Me.txtPIF.Text = dtJobVersion.Rows(i)("JOB_VER_VALUE")
                        End If
                    End If
                    If dtJobVersion.Rows(i)("JV_TMPLT_LABEL") = "Fiscal Period" Then
                        If IsDBNull(dtJobVersion.Rows(i)("JOB_VER_VALUE")) = False Then
                            Me.txtfiscal.Text = dtJobVersion.Rows(i)("JOB_VER_VALUE")
                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader7_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader7.Format
        Try
            If Me.txtestqtecomments.Text <> "" Then
                Me.txtProjectDesc.Text = Me.txtestqtecomments.Text & vbCrLf & Me.txtRevisionComments.Text
            Else
                Me.txtProjectDesc.Text = Me.txtRevisionComments.Text
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
