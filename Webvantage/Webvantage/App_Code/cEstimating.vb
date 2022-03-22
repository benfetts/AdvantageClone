Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

<Serializable()> Public Class cEstimating
    Private mConnString As String
    Private mUserID As String
    Private oSQL As SqlHelper


#Region " Estimate Quote Details (functions grid)"

    Private mDtQuoteFunctions As New DataTable

    Public Function GetEstimateQuoteDetails(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer, ByVal phase As String) As DataTable
        Me.CreateEstimateQuoteDetailsDatatable()

        'Get the real data
        Dim arParams(5) As SqlParameter
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber
        Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.VarChar)
        parameterPhase.Value = phase
        arParams(4) = parameterPhase

        Dim DtRealData As New DataTable
        DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Details", "DtQuoteFunctions", arParams)

        If DtRealData.Rows.Count > 0 Then
            Dim CurrEstNum As Integer = 0
            Dim CurrEstCompNum As Integer = 0
            Dim CurrQuoteNum As Integer = 0
            Dim CurrEstQuoteDesc As String = ""
            Dim CurrEstRevNum As Integer = 0
            Dim CurrSeqNbr As Integer = 0
            Dim CurrFncCode As String = ""
            Dim CurrFncDesc As String = ""
            Dim CurrEstFncComment As String = ""
            Dim CurrEstRevSupByCode As String = ""
            Dim CurrEstRevSupByNote As String = ""
            Dim CurrEstRevQty As Decimal = CType(0.0, Decimal)
            Dim CurrEstRevRate As Decimal = CType(0.0, Decimal)
            Dim CurrEstRevExtAmt As Decimal = CType(0.0, Decimal)
            Dim CurrTaxCode As String = ""
            Dim CurrEstRevCommPct As Decimal = CType(0.0, Decimal)
            Dim CurrExtMarkupAmt As Decimal = CType(0.0, Decimal)
            Dim CurrLineTotal As Decimal = CType(0.0, Decimal)
            Dim CurrEstRevContPct As Decimal = CType(0.0, Decimal)
            Dim CurrExtContingency As Decimal = CType(0.0, Decimal)
            Dim CurrInclCPU As Integer = 0
            Dim CurrTaxStatePct As Decimal = CType(0.0, Decimal)
            Dim CurrTaxCountyPct As Decimal = CType(0.0, Decimal)
            Dim CurrTaxCityPct As Decimal = CType(0.0, Decimal)
            Dim CurrTaxComm As Integer = 0
            Dim CurrTaxCommOnly As Integer = 0
            Dim CurrTaxResale As Integer = 0
            Dim CurrExtNonResaleTax As Decimal = CType(0.0, Decimal)
            Dim CurrExtStateResale As Decimal = CType(0.0, Decimal)
            Dim CurrExtCountyResale As Decimal = CType(0.0, Decimal)
            Dim CurrExtCityResale As Decimal = CType(0.0, Decimal)
            Dim CurrExtMuCont As Decimal = CType(0.0, Decimal)
            Dim CurrExtStateCont As Decimal = CType(0.0, Decimal)
            Dim CurrExtCountyCont As Decimal = CType(0.0, Decimal)
            Dim CurrExtCityCont As Decimal = CType(0.0, Decimal)
            Dim CurrExtNrCont As Decimal = CType(0.0, Decimal)
            Dim CurrLineTotalCont As Decimal = CType(0.0, Decimal)
            Dim CurrEstCPMFlag As Integer = 0
            Dim CurrEstFncType As String = ""
            Dim CurrEstCommFlag As Integer = 0
            Dim CurrEstTaxFlag As Integer = 0
            Dim CurrEstNonbillFlag As Integer = 0
            Dim CurrFeeTime As Integer = 0
            Dim CurrEmployeeTitleId As Integer = 0
            Dim CurrFncType As String = ""
            Dim CurrEstPhaseId As Integer = 0
            Dim CurrEstPhaseDesc As String = ""
            Dim CurrFncHeadingId As Integer = 0
            Dim CurrFncHeadingDesc As String = ""
            Dim CurrFncHeadingSeq As Integer = 0
            Dim CurrFncConsolidation As String = ""
            Dim CurrFncConsolidationDesc As String = ""
            Dim CurrDfltTaxStatePct As Decimal = CType(0.0, Decimal)
            Dim CurrDfltTaxCountyPct As Decimal = CType(0.0, Decimal)
            Dim CurrDfltTaxCityPct As Decimal = CType(0.0, Decimal)
            Dim CurrIsUserRow As Boolean = False
            Dim CurrEmpTitle As String = ""
            Dim CurrQuotewithCont As Decimal = CType(0.0, Decimal)
            Dim CurrTax As Decimal = CType(0.0, Decimal)
            Dim CurrEstRevExtmarkupAmt As Decimal = CType(0.0, Decimal)

            For i As Integer = 0 To DtRealData.Rows.Count - 1

                Try
                    If IsDBNull(DtRealData.Rows(i)("ESTIMATE_NUMBER")) = False Then
                        CurrEstNum = CInt(DtRealData.Rows(i)("ESTIMATE_NUMBER"))
                    Else
                        CurrEstNum = -1
                    End If
                Catch ex As Exception
                    CurrEstNum = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_COMPONENT_NBR")) = False Then
                        CurrEstCompNum = CInt(DtRealData.Rows(i)("EST_COMPONENT_NBR"))
                    Else
                        CurrEstCompNum = -1
                    End If
                Catch ex As Exception
                    CurrEstCompNum = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_QUOTE_NBR")) = False Then
                        CurrQuoteNum = CInt(DtRealData.Rows(i)("EST_QUOTE_NBR"))
                    Else
                        CurrQuoteNum = -1
                    End If
                Catch ex As Exception
                    CurrQuoteNum = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_QUOTE_DESC")) = False Then
                        CurrEstQuoteDesc = CStr(DtRealData.Rows(i)("EST_QUOTE_DESC"))
                    Else
                        CurrEstQuoteDesc = ""
                    End If
                Catch ex As Exception
                    CurrEstQuoteDesc = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_NBR")) = False Then
                        CurrEstRevNum = CInt(DtRealData.Rows(i)("EST_REV_NBR"))
                    Else
                        CurrEstRevNum = -1
                    End If
                Catch ex As Exception
                    CurrEstRevNum = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("SEQ_NBR")) = False Then
                        CurrSeqNbr = CInt(DtRealData.Rows(i)("SEQ_NBR"))
                    Else
                        CurrSeqNbr = -1
                    End If
                Catch ex As Exception
                    CurrSeqNbr = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_CODE")) = False Then
                        CurrFncCode = CStr(DtRealData.Rows(i)("FNC_CODE"))
                    Else
                        CurrFncCode = ""
                    End If
                Catch ex As Exception
                    CurrFncCode = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_DESCRIPTION")) = False Then
                        CurrFncDesc = CStr(DtRealData.Rows(i)("FNC_DESCRIPTION"))
                    Else
                        CurrFncDesc = ""
                    End If
                Catch ex As Exception
                    CurrFncDesc = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_FNC_COMMENT")) = False Then
                        CurrEstFncComment = CStr(DtRealData.Rows(i)("EST_FNC_COMMENT"))
                    Else
                        CurrEstFncComment = ""
                    End If
                Catch ex As Exception
                    CurrEstFncComment = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_SUP_BY_CDE")) = False Then
                        CurrEstRevSupByCode = CStr(DtRealData.Rows(i)("EST_REV_SUP_BY_CDE"))
                    Else
                        CurrEstRevSupByCode = ""
                    End If
                Catch ex As Exception
                    CurrEstRevSupByCode = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_SUP_BY_NTE")) = False Then
                        CurrEstRevSupByNote = CStr(DtRealData.Rows(i)("EST_REV_SUP_BY_NTE"))
                    Else
                        CurrEstRevSupByNote = ""
                    End If
                Catch ex As Exception
                    CurrEstRevSupByNote = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_QUANTITY")) = False Then
                        CurrEstRevQty = CDec(DtRealData.Rows(i)("EST_REV_QUANTITY"))
                    Else
                        CurrEstRevQty = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevQty = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_RATE")) = False Then
                        CurrEstRevRate = CDec(DtRealData.Rows(i)("EST_REV_RATE"))
                    Else
                        CurrEstRevRate = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevRate = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_EXT_AMT")) = False Then
                        CurrEstRevExtAmt = CDec(DtRealData.Rows(i)("EST_REV_EXT_AMT"))
                    Else
                        CurrEstRevExtAmt = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevExtAmt = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_CODE")) = False Then
                        CurrTaxCode = CStr(DtRealData.Rows(i)("TAX_CODE"))
                    Else
                        CurrTaxCode = ""
                    End If
                Catch ex As Exception
                    CurrTaxCode = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_COMM_PCT")) = False Then
                        CurrEstRevCommPct = CDec(DtRealData.Rows(i)("EST_REV_COMM_PCT"))
                    Else
                        CurrEstRevCommPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevCommPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_MARKUP_AMT")) = False Then
                        CurrExtMarkupAmt = CDec(DtRealData.Rows(i)("EXT_MARKUP_AMT"))
                    Else
                        CurrExtMarkupAmt = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtMarkupAmt = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("LINE_TOTAL")) = False Then
                        CurrLineTotal = CDec(DtRealData.Rows(i)("LINE_TOTAL"))
                    Else
                        CurrLineTotal = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrLineTotal = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_CONT_PCT")) = False Then
                        CurrEstRevContPct = CDec(DtRealData.Rows(i)("EST_REV_CONT_PCT"))
                    Else
                        CurrEstRevContPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevContPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_CONTINGENCY")) = False Then
                        CurrExtContingency = CDec(DtRealData.Rows(i)("EXT_CONTINGENCY"))
                    Else
                        CurrExtContingency = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtContingency = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("INCL_CPU")) = False Then
                        CurrInclCPU = CInt(DtRealData.Rows(i)("INCL_CPU"))
                    Else
                        CurrInclCPU = -1
                    End If
                Catch ex As Exception
                    CurrInclCPU = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_STATE_PCT")) = False Then
                        CurrTaxStatePct = CDec(DtRealData.Rows(i)("TAX_STATE_PCT"))
                    Else
                        CurrTaxStatePct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrTaxStatePct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_COUNTY_PCT")) = False Then
                        CurrTaxCountyPct = CDec(DtRealData.Rows(i)("TAX_COUNTY_PCT"))
                    Else
                        CurrTaxCountyPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrTaxCountyPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_CITY_PCT")) = False Then
                        CurrTaxCityPct = CDec(DtRealData.Rows(i)("TAX_CITY_PCT"))
                    Else
                        CurrTaxCityPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrTaxCityPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_COMM")) = False Then
                        CurrTaxComm = CInt(DtRealData.Rows(i)("TAX_COMM"))
                    Else
                        CurrTaxComm = -1
                    End If
                Catch ex As Exception
                    CurrTaxComm = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_COMM_ONLY")) = False Then
                        CurrTaxCommOnly = CInt(DtRealData.Rows(i)("TAX_COMM_ONLY"))
                    Else
                        CurrTaxCommOnly = -1
                    End If
                Catch ex As Exception
                    CurrTaxCommOnly = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_RESALE")) = False Then
                        CurrTaxResale = CInt(DtRealData.Rows(i)("TAX_RESALE"))
                    Else
                        CurrTaxResale = -1
                    End If
                Catch ex As Exception
                    CurrTaxResale = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_NONRESALE_TAX")) = False Then
                        CurrExtNonResaleTax = CDec(DtRealData.Rows(i)("EXT_NONRESALE_TAX"))
                    Else
                        CurrExtNonResaleTax = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtNonResaleTax = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_STATE_RESALE")) = False Then
                        CurrExtStateResale = CDec(DtRealData.Rows(i)("EXT_STATE_RESALE"))
                    Else
                        CurrExtStateResale = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtStateResale = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_COUNTY_RESALE")) = False Then
                        CurrExtCountyResale = CDec(DtRealData.Rows(i)("EXT_COUNTY_RESALE"))
                    Else
                        CurrExtCountyResale = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtCountyResale = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_CITY_RESALE")) = False Then
                        CurrExtCityResale = CDec(DtRealData.Rows(i)("EXT_CITY_RESALE"))
                    Else
                        CurrExtCityResale = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtCityResale = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_MU_CONT")) = False Then
                        CurrExtMuCont = CDec(DtRealData.Rows(i)("EXT_MU_CONT"))
                    Else
                        CurrExtMuCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtMuCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_STATE_CONT")) = False Then
                        CurrExtStateCont = CDec(DtRealData.Rows(i)("EXT_STATE_CONT"))
                    Else
                        CurrExtStateCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtStateCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_COUNTY_CONT")) = False Then
                        CurrExtCountyCont = CDec(DtRealData.Rows(i)("EXT_COUNTY_CONT"))
                    Else
                        CurrExtCountyCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtCountyCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_CITY_CONT")) = False Then
                        CurrExtCityCont = CDec(DtRealData.Rows(i)("EXT_CITY_CONT"))
                    Else
                        CurrExtCityCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtCityCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EXT_NR_CONT")) = False Then
                        CurrExtNrCont = CDec(DtRealData.Rows(i)("EXT_NR_CONT"))
                    Else
                        CurrExtNrCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrExtNrCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("LINE_TOTAL_CONT")) = False Then
                        CurrLineTotalCont = CDec(DtRealData.Rows(i)("LINE_TOTAL_CONT"))
                    Else
                        CurrLineTotalCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrLineTotalCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_CPM_FLAG")) = False Then
                        CurrEstCPMFlag = CInt(DtRealData.Rows(i)("EST_CPM_FLAG"))
                    Else
                        CurrEstCPMFlag = -1
                    End If
                Catch ex As Exception
                    CurrEstCPMFlag = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_FNC_TYPE")) = False Then
                        CurrEstFncType = CStr(DtRealData.Rows(i)("EST_FNC_TYPE"))
                    Else
                        CurrEstFncType = ""
                    End If
                Catch ex As Exception
                    CurrEstFncType = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_COMM_FLAG")) = False Then
                        CurrEstCommFlag = CInt(DtRealData.Rows(i)("EST_COMM_FLAG"))
                    Else
                        CurrEstCommFlag = -1
                    End If
                Catch ex As Exception
                    CurrEstCommFlag = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_TAX_FLAG")) = False Then
                        CurrEstTaxFlag = CInt(DtRealData.Rows(i)("EST_TAX_FLAG"))
                    Else
                        CurrEstTaxFlag = -1
                    End If
                Catch ex As Exception
                    CurrEstTaxFlag = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_NONBILL_FLAG")) = False Then
                        CurrEstNonbillFlag = CInt(DtRealData.Rows(i)("EST_NONBILL_FLAG"))
                    Else
                        CurrEstNonbillFlag = -1
                    End If
                Catch ex As Exception
                    CurrEstNonbillFlag = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FEE_TIME")) = False Then
                        CurrFeeTime = CInt(DtRealData.Rows(i)("FEE_TIME"))
                    Else
                        CurrFeeTime = -1
                    End If
                Catch ex As Exception
                    CurrFeeTime = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EMPLOYEE_TITLE_ID")) = False Then
                        CurrEmployeeTitleId = CInt(DtRealData.Rows(i)("EMPLOYEE_TITLE_ID"))
                    Else
                        CurrEmployeeTitleId = -1
                    End If
                Catch ex As Exception
                    CurrEmployeeTitleId = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_TYPE")) = False Then
                        CurrFncType = CStr(DtRealData.Rows(i)("FNC_TYPE"))
                    Else
                        CurrFncType = ""
                    End If
                Catch ex As Exception
                    CurrFncType = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_PHASE_ID")) = False Then
                        CurrEstPhaseId = CInt(DtRealData.Rows(i)("EST_PHASE_ID"))
                    Else
                        CurrEstPhaseId = -1
                    End If
                Catch ex As Exception
                    CurrEstPhaseId = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_PHASE_DESC")) = False Then
                        CurrEstPhaseDesc = CStr(DtRealData.Rows(i)("EST_PHASE_DESC"))
                    Else
                        CurrEstPhaseDesc = ""
                    End If
                Catch ex As Exception
                    CurrEstPhaseDesc = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_ID")) = False Then
                        CurrFncHeadingId = CInt(DtRealData.Rows(i)("FNC_HEADING_ID"))
                    Else
                        CurrFncHeadingId = -1
                    End If
                Catch ex As Exception
                    CurrFncHeadingId = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_DESC")) = False Then
                        CurrFncHeadingDesc = CStr(DtRealData.Rows(i)("FNC_HEADING_DESC"))
                    Else
                        CurrFncHeadingDesc = ""
                    End If
                Catch ex As Exception
                    CurrFncHeadingDesc = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_SEQ")) = False Then
                        CurrFncHeadingSeq = CInt(DtRealData.Rows(i)("FNC_HEADING_SEQ"))
                    Else
                        CurrFncHeadingSeq = -1
                    End If
                Catch ex As Exception
                    CurrFncHeadingSeq = -1
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_CONSOLIDATION")) = False Then
                        CurrFncConsolidation = CStr(DtRealData.Rows(i)("FNC_CONSOLIDATION"))
                    Else
                        CurrFncConsolidation = ""
                    End If
                Catch ex As Exception
                    CurrFncConsolidation = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("FNC_CONSOL_DESC")) = False Then
                        CurrFncConsolidationDesc = CStr(DtRealData.Rows(i)("FNC_CONSOL_DESC"))
                    Else
                        CurrFncConsolidationDesc = ""
                    End If
                Catch ex As Exception
                    CurrFncConsolidationDesc = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_STATE_PERCENT")) = False Then
                        CurrDfltTaxStatePct = CDec(DtRealData.Rows(i)("TAX_STATE_PERCENT"))
                    Else
                        CurrDfltTaxStatePct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrDfltTaxStatePct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_COUNTY_PERCENT")) = False Then
                        CurrDfltTaxCountyPct = CDec(DtRealData.Rows(i)("TAX_COUNTY_PERCENT"))
                    Else
                        CurrDfltTaxCountyPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrDfltTaxCountyPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX_CITY_PERCENT")) = False Then
                        CurrDfltTaxCityPct = CDec(DtRealData.Rows(i)("TAX_CITY_PERCENT"))
                    Else
                        CurrDfltTaxCityPct = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrDfltTaxCityPct = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EMP_TITLE")) = False Then
                        CurrEmpTitle = CStr(DtRealData.Rows(i)("EMP_TITLE"))
                    Else
                        CurrEmpTitle = ""
                    End If
                Catch ex As Exception
                    CurrEmpTitle = ""
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("QUOTE_W_CONTINGENCY")) = False Then
                        CurrQuotewithCont = CDec(DtRealData.Rows(i)("QUOTE_W_CONTINGENCY"))
                    Else
                        CurrQuotewithCont = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrQuotewithCont = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("TAX")) = False Then
                        CurrTax = CDec(DtRealData.Rows(i)("TAX"))
                    Else
                        CurrTax = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrTax = CType(0.0, Decimal)
                End Try

                Try
                    If IsDBNull(DtRealData.Rows(i)("EST_REV_EXT_MU_AMT")) = False Then
                        CurrEstRevExtmarkupAmt = CDec(DtRealData.Rows(i)("EST_REV_EXT_MU_AMT"))
                    Else
                        CurrEstRevExtmarkupAmt = CType(0.0, Decimal)
                    End If
                Catch ex As Exception
                    CurrEstRevExtmarkupAmt = CType(0.0, Decimal)
                End Try

                EstimateQuoteDetailsDatatable_AddRow(mDtQuoteFunctions,
                                                        CurrEstNum, CurrEstCompNum,
                                                        CurrQuoteNum, CurrEstQuoteDesc, CurrEstRevNum, CurrSeqNbr,
                                                        CurrFncCode, CurrFncDesc, CurrEstFncComment,
                                                        CurrEstRevSupByCode, CurrEstRevSupByNote, CurrEstRevQty, CurrEstRevRate,
                                                        CurrEstRevExtAmt, CurrTaxCode, CurrEstRevCommPct, CurrExtMarkupAmt,
                                                        CurrLineTotal, CurrEstRevContPct, CurrExtContingency,
                                                        CurrInclCPU, CurrTaxStatePct, CurrTaxCountyPct, CurrTaxCityPct,
                                                        CurrTaxComm, CurrTaxCommOnly, CurrTaxResale,
                                                        CurrExtNonResaleTax, CurrExtStateResale, CurrExtCountyResale, CurrExtCityResale,
                                                        CurrExtMuCont, CurrExtStateCont, CurrExtCountyCont, CurrExtCityCont,
                                                        CurrExtNrCont, CurrLineTotalCont, CurrEstCPMFlag, CurrEstFncType,
                                                        CurrEstCommFlag, CurrEstTaxFlag, CurrEstNonbillFlag,
                                                        CurrFeeTime, CurrEmployeeTitleId, CurrFncType,
                                                        CurrEstPhaseId, CurrEstPhaseDesc,
                                                        CurrFncHeadingId, CurrFncHeadingDesc, CurrFncHeadingSeq,
                                                        CurrFncConsolidation, CurrFncConsolidationDesc, CurrDfltTaxStatePct, CurrDfltTaxCountyPct, CurrDfltTaxCityPct,
                                                        CurrEmpTitle, False, CurrQuotewithCont, CurrTax, CurrEstRevExtmarkupAmt)
            Next
        Else
            'Might need one blank row here for an insert...
        End If


        Return mDtQuoteFunctions
    End Function


    Public Function EstimateQuoteDetailsDatatable_AddUserRow(ByRef TheDT As DataTable,
                                                                ByVal EstNum As Integer, ByVal EstCompNum As Integer, ByVal QuoteNum As Integer, ByVal EstRevNum As Integer,
                                                                ByVal FncCode As String) As String
        Me.EstimateQuoteDetailsDatatable_AddRow(TheDT, EstNum, EstCompNum, QuoteNum, "", EstRevNum, -1, FncCode, "", "", "", "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, "", 0, "", 0, "", -1, "", "", 0, 0, 0, "", True, 0, 0, 0)
    End Function

    Private Function EstimateQuoteDetailsDatatable_AddRow(ByRef TheDT As DataTable,
                                                            ByVal EstNum As Integer, ByVal EstCompNum As Integer,
                                                            ByVal QuoteNum As Integer, ByVal EstQuoteDesc As String, ByVal EstRevNum As Integer, ByVal SeqNbr As Integer,
                                                            ByVal FncCode As String, ByVal FncDesc As String, ByVal EstFncComment As String,
                                                            ByVal EstRevSupByCode As String, ByVal EstRevSupByNote As String, ByVal EstRevQty As Decimal, ByVal EstRevRate As Decimal,
                                                            ByVal EstRevExtAmt As Decimal, ByVal TaxCode As String, ByVal EstRevCommPct As Decimal, ByVal ExtMarkupAmt As Decimal,
                                                            ByVal LineTotal As Decimal, ByVal EstRevContPct As Decimal, ByVal ExtContingency As Decimal,
                                                            ByVal InclCPU As Integer, ByVal TaxStatePct As Decimal, ByVal TaxCountyPct As Decimal, ByVal TaxCityPct As Decimal,
                                                            ByVal TaxComm As Integer, ByVal TaxCommOnly As Integer, ByVal TaxResale As Integer,
                                                            ByVal ExtNonResaleTax As Decimal, ByVal ExtStateResale As Decimal, ByVal ExtCountyResale As Decimal, ByVal ExtCityResale As Decimal,
                                                            ByVal ExtMuCont As Decimal, ByVal ExtStateCont As Decimal, ByVal ExtCountyCont As Decimal, ByVal ExtCityCont As Decimal,
                                                            ByVal ExtNrCont As Decimal, ByVal LineTotalCont As Decimal, ByVal EstCPMFlag As Integer, ByVal EstFncType As String,
                                                            ByVal EstCommFlag As Integer, ByVal EstTaxFlag As Integer, ByVal EstNonbillFlag As Integer,
                                                            ByVal FeeTime As Integer, ByVal EmployeeTitleId As Integer, ByVal FncType As String,
                                                            ByVal EstPhaseId As Integer, ByVal EstPhaseDesc As String,
                                                            ByVal FncHeadingId As Integer, ByVal FncHeadingDesc As String, ByVal FncHeadingSeq As Integer,
                                                            ByVal FncConsolidation As String, ByVal FncConsolidationDesc As String, ByVal DfltTaxStatePct As Decimal, ByVal DfltTaxCountyPct As Decimal, ByVal DfltTaxCityPct As Decimal,
                                                            ByVal EmpTitle As String, ByVal IsUserRow As Boolean, ByVal CurrQuotewithCont As Decimal, ByVal CurrTax As Decimal, ByVal CurrEstRevExtmarkupAmt As Decimal) As String
        Try
            Dim r As DataRow
            r = TheDT.NewRow()

            r("ESTIMATE_NUMBER") = EstNum
            r("EST_COMPONENT_NBR") = EstCompNum
            r("EST_QUOTE_NBR") = QuoteNum
            r("EST_QUOTE_DESC") = EstQuoteDesc
            r("EST_REV_NBR") = EstRevNum
            r("SEQ_NBR") = SeqNbr
            r("FNC_CODE") = FncCode
            r("FNC_DESCRIPTION") = FncDesc
            r("EST_FNC_COMMENT") = EstFncComment
            r("EST_REV_SUP_BY_CDE") = EstRevSupByCode
            r("EST_REV_SUP_BY_NTE") = EstRevSupByNote
            r("EST_REV_QUANTITY") = EstRevQty
            r("EST_REV_RATE") = EstRevRate
            r("EST_REV_EXT_AMT") = EstRevExtAmt
            r("TAX_CODE") = TaxCode
            r("EST_REV_COMM_PCT") = EstRevCommPct
            r("EXT_MARKUP_AMT") = ExtMarkupAmt
            r("LINE_TOTAL") = LineTotal
            r("EST_REV_CONT_PCT") = EstRevContPct
            r("EXT_CONTINGENCY") = ExtContingency
            r("INCL_CPU") = InclCPU
            'These 3 tax fields are part of the ESTIMATE_REV_DET table
            r("TAX_STATE_PCT") = TaxStatePct
            r("TAX_COUNTY_PCT") = TaxCountyPct
            r("TAX_CITY_PCT") = TaxCityPct
            r("TAX_COMM") = TaxComm
            r("TAX_COMM_ONLY") = TaxCommOnly
            r("TAX_RESALE") = TaxResale
            r("EXT_NONRESALE_TAX") = ExtNonResaleTax
            r("EXT_STATE_RESALE") = ExtStateResale
            r("EXT_COUNTY_RESALE") = ExtCountyResale
            r("EXT_CITY_RESALE") = ExtCityResale
            r("EXT_MU_CONT") = ExtMuCont
            r("EXT_STATE_CONT") = ExtStateCont
            r("EXT_COUNTY_CONT") = ExtCountyCont
            r("EXT_CITY_CONT") = ExtCityCont
            r("EXT_NR_CONT") = ExtNrCont
            r("LINE_TOTAL_CONT") = LineTotalCont
            r("EST_CPM_FLAG") = EstCPMFlag
            r("EST_FNC_TYPE") = EstFncType
            r("EST_COMM_FLAG") = EstCommFlag
            r("EST_TAX_FLAG") = EstTaxFlag
            r("EST_NONBILL_FLAG") = EstNonbillFlag
            r("FEE_TIME") = FeeTime
            r("EMPLOYEE_TITLE_ID") = EmployeeTitleId
            r("FNC_TYPE") = FncType
            r("EST_PHASE_ID") = EstPhaseId
            r("EST_PHASE_DESC") = EstPhaseDesc
            r("FNC_HEADING_ID") = FncHeadingId
            r("FNC_HEADING_DESC") = FncHeadingDesc
            r("FNC_HEADING_SEQ") = FncHeadingSeq
            r("FNC_CONSOLIDATION") = FncConsolidation
            r("FNC_CONSOL_DESC") = FncConsolidationDesc
            'These 3 tax fields are part of the SALES_TAX table
            r("DFLT_TAX_STATE_PERCENT") = DfltTaxStatePct
            r("DFLT_TAX_COUNTY_PERCENT") = DfltTaxCountyPct
            r("DFLT_TAX_CITY_PERCENT") = DfltTaxCityPct
            r("EMP_TITLE") = EmpTitle
            r("QUOTE_W_CONTINGENCY") = CurrQuotewithCont
            r("TAX") = CurrTax
            r("EST_REV_EXT_MU_AMT") = CurrEstRevExtmarkupAmt
            If IsUserRow = True Then
                r("IS_USER_ROW") = 1
            Else
                r("IS_USER_ROW") = 0
            End If

            TheDT.Rows.Add(r)


        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function EstimateQuoteDetailsDatatable_UpdateRow_User(ByRef TheDT As DataTable, ByVal PrimaryKey As Integer, ByVal FncCode As String, ByVal FncDescription As String,
                                                                ByVal SuppliedBy As String) As String
        Try
            'TheDT.DefaultView(RowIndex)("") = ""
            Dim r As DataRow
            r = TheDT.Rows.Find(PrimaryKey)
            r("FNC_CODE") = FncCode
            r("FNC_DESCRIPTION") = FncDescription
            r("EST_REV_SUP_BY_CDE") = SuppliedBy


            'ApprovalDetailDatatable_AddRow(TheDT, -1, FncType, FncTypeDesc, FncCode, FncDescription, FncDescription, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Quantity, Rate, ApprovedAmount, ApprovalComments, ClientComments, True)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Private Sub CreateEstimateQuoteDetailsDatatable()
        'Initial mod of this base table
        'once it comes in and out of the class, mods should be there for use in other fn's
        Dim Pk(0) As DataColumn

        Dim COL_INDEX As DataColumn = New DataColumn("INDEX")
        With COL_INDEX
            .DataType = GetType(Int32)
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Pk(0) = COL_INDEX

        Dim COL_ESTIMATE_NUMBER As DataColumn = New DataColumn("ESTIMATE_NUMBER")
        COL_ESTIMATE_NUMBER.DataType = GetType(Int32)

        Dim COL_EST_COMPONENT_NBR As DataColumn = New DataColumn("EST_COMPONENT_NBR")
        COL_EST_COMPONENT_NBR.DataType = GetType(Int32)

        Dim COL_EST_QUOTE_NBR As DataColumn = New DataColumn("EST_QUOTE_NBR")
        COL_EST_QUOTE_NBR.DataType = GetType(Int32)

        Dim COL_EST_QUOTE_DESC As DataColumn = New DataColumn("EST_QUOTE_DESC")
        COL_EST_QUOTE_DESC.DataType = GetType(String)

        Dim COL_EST_REV_NBR As DataColumn = New DataColumn("EST_REV_NBR")
        COL_EST_REV_NBR.DataType = GetType(Int32)

        Dim COL_SEQ_NBR As DataColumn = New DataColumn("SEQ_NBR")
        COL_SEQ_NBR.DataType = GetType(Int32)

        Dim COL_FNC_CODE As DataColumn = New DataColumn("FNC_CODE")
        COL_FNC_CODE.DataType = GetType(String)

        Dim COL_FNC_DESCRIPTION As DataColumn = New DataColumn("FNC_DESCRIPTION")
        COL_FNC_DESCRIPTION.DataType = GetType(String)

        Dim COL_EST_FNC_COMMENT As DataColumn = New DataColumn("EST_FNC_COMMENT")
        COL_EST_FNC_COMMENT.DataType = GetType(String)

        Dim COL_EST_REV_SUP_BY_CDE As DataColumn = New DataColumn("EST_REV_SUP_BY_CDE")
        COL_EST_REV_SUP_BY_CDE.DataType = GetType(String)

        Dim COL_EST_REV_SUP_BY_NTE As DataColumn = New DataColumn("EST_REV_SUP_BY_NTE")
        COL_EST_REV_SUP_BY_NTE.DataType = GetType(String)

        Dim COL_EST_REV_QUANTITY As DataColumn = New DataColumn("EST_REV_QUANTITY")
        COL_EST_REV_QUANTITY.DataType = GetType(Decimal)

        Dim COL_EST_REV_RATE As DataColumn = New DataColumn("EST_REV_RATE")
        COL_EST_REV_RATE.DataType = GetType(Decimal)

        Dim COL_EST_REV_EXT_AMT As DataColumn = New DataColumn("EST_REV_EXT_AMT")
        COL_EST_REV_EXT_AMT.DataType = GetType(Decimal)

        Dim COL_TAX_CODE As DataColumn = New DataColumn("TAX_CODE")
        COL_TAX_CODE.DataType = GetType(String)

        Dim COL_EST_REV_COMM_PCT As DataColumn = New DataColumn("EST_REV_COMM_PCT")
        COL_EST_REV_COMM_PCT.DataType = GetType(Decimal)

        Dim COL_EXT_MARKUP_AMT As DataColumn = New DataColumn("EXT_MARKUP_AMT")
        COL_EXT_MARKUP_AMT.DataType = GetType(Decimal)

        Dim COL_LINE_TOTAL As DataColumn = New DataColumn("LINE_TOTAL")
        COL_LINE_TOTAL.DataType = GetType(Decimal)

        Dim COL_EST_REV_CONT_PCT As DataColumn = New DataColumn("EST_REV_CONT_PCT")
        COL_EST_REV_CONT_PCT.DataType = GetType(Decimal)

        Dim COL_EXT_CONTINGENCY As DataColumn = New DataColumn("EXT_CONTINGENCY")
        COL_EXT_CONTINGENCY.DataType = GetType(Decimal)

        Dim COL_INCL_CPU As DataColumn = New DataColumn("INCL_CPU")
        COL_INCL_CPU.DataType = GetType(Int32)

        Dim COL_TAX_STATE_PCT As DataColumn = New DataColumn("TAX_STATE_PCT")
        COL_TAX_STATE_PCT.DataType = GetType(Decimal)

        Dim COL_TAX_COUNTY_PCT As DataColumn = New DataColumn("TAX_COUNTY_PCT")
        COL_TAX_COUNTY_PCT.DataType = GetType(Decimal)

        Dim COL_TAX_CITY_PCT As DataColumn = New DataColumn("TAX_CITY_PCT")
        COL_TAX_CITY_PCT.DataType = GetType(Decimal)

        Dim COL_TAX_COMM As DataColumn = New DataColumn("TAX_COMM")
        COL_TAX_COMM.DataType = GetType(Int32)

        Dim COL_TAX_COMM_ONLY As DataColumn = New DataColumn("TAX_COMM_ONLY")
        COL_TAX_COMM_ONLY.DataType = GetType(Int32)

        Dim COL_TAX_RESALE As DataColumn = New DataColumn("TAX_RESALE")
        COL_TAX_RESALE.DataType = GetType(Int32)

        Dim COL_EXT_NONRESALE_TAX As DataColumn = New DataColumn("EXT_NONRESALE_TAX")
        COL_EXT_NONRESALE_TAX.DataType = GetType(Decimal)

        Dim COL_EXT_STATE_RESALE As DataColumn = New DataColumn("EXT_STATE_RESALE")
        COL_EXT_STATE_RESALE.DataType = GetType(Decimal)

        Dim COL_EXT_COUNTY_RESALE As DataColumn = New DataColumn("EXT_COUNTY_RESALE")
        COL_EXT_COUNTY_RESALE.DataType = GetType(Decimal)

        Dim COL_EXT_CITY_RESALE As DataColumn = New DataColumn("EXT_CITY_RESALE")
        COL_EXT_CITY_RESALE.DataType = GetType(Decimal)

        Dim COL_EXT_MU_CONT As DataColumn = New DataColumn("EXT_MU_CONT")
        COL_EXT_MU_CONT.DataType = GetType(Decimal)

        Dim COL_EXT_STATE_CONT As DataColumn = New DataColumn("EXT_STATE_CONT")
        COL_EXT_STATE_CONT.DataType = GetType(Decimal)

        Dim COL_EXT_COUNTY_CONT As DataColumn = New DataColumn("EXT_COUNTY_CONT")
        COL_EXT_COUNTY_CONT.DataType = GetType(Decimal)

        Dim COL_EXT_CITY_CONT As DataColumn = New DataColumn("EXT_CITY_CONT")
        COL_EXT_CITY_CONT.DataType = GetType(Decimal)

        Dim COL_EXT_NR_CONT As DataColumn = New DataColumn("EXT_NR_CONT")
        COL_EXT_NR_CONT.DataType = GetType(Decimal)

        Dim COL_LINE_TOTAL_CONT As DataColumn = New DataColumn("LINE_TOTAL_CONT")
        COL_LINE_TOTAL_CONT.DataType = GetType(Decimal)

        Dim COL_EST_CPM_FLAG As DataColumn = New DataColumn("EST_CPM_FLAG")
        COL_EST_CPM_FLAG.DataType = GetType(Int32)

        Dim COL_EST_FNC_TYPE As DataColumn = New DataColumn("EST_FNC_TYPE")
        COL_EST_FNC_TYPE.DataType = GetType(String)

        Dim COL_EST_COMM_FLAG As DataColumn = New DataColumn("EST_COMM_FLAG")
        COL_EST_COMM_FLAG.DataType = GetType(Int32)

        Dim COL_EST_TAX_FLAG As DataColumn = New DataColumn("EST_TAX_FLAG")
        COL_EST_TAX_FLAG.DataType = GetType(Int32)

        Dim COL_EST_NONBILL_FLAG As DataColumn = New DataColumn("EST_NONBILL_FLAG")
        COL_EST_NONBILL_FLAG.DataType = GetType(Int32)

        Dim COL_FEE_TIME As DataColumn = New DataColumn("FEE_TIME")
        COL_FEE_TIME.DataType = GetType(Int32)

        Dim COL_EMPLOYEE_TITLE_ID As DataColumn = New DataColumn("EMPLOYEE_TITLE_ID")
        COL_EMPLOYEE_TITLE_ID.DataType = GetType(Int32)

        Dim COL_FNC_TYPE As DataColumn = New DataColumn("FNC_TYPE")
        COL_FNC_TYPE.DataType = GetType(String)

        Dim COL_EST_PHASE_ID As DataColumn = New DataColumn("EST_PHASE_ID")
        COL_EST_PHASE_ID.DataType = GetType(Int32)

        Dim COL_EST_PHASE_DESC As DataColumn = New DataColumn("EST_PHASE_DESC")
        COL_EST_PHASE_DESC.DataType = GetType(String)

        Dim COL_FNC_HEADING_ID As DataColumn = New DataColumn("FNC_HEADING_ID")
        COL_FNC_HEADING_ID.DataType = GetType(Int32)

        Dim COL_FNC_HEADING_DESC As DataColumn = New DataColumn("FNC_HEADING_DESC")
        COL_FNC_HEADING_DESC.DataType = GetType(String)

        Dim COL_FNC_HEADING_SEQ As DataColumn = New DataColumn("FNC_HEADING_SEQ")
        COL_FNC_HEADING_SEQ.DataType = GetType(Int32)

        Dim COL_FNC_CONSOLIDATION As DataColumn = New DataColumn("FNC_CONSOLIDATION")
        COL_FNC_CONSOLIDATION.DataType = GetType(String)

        Dim COL_FNC_CONSOL_DESC As DataColumn = New DataColumn("FNC_CONSOL_DESC")
        COL_FNC_CONSOL_DESC.DataType = GetType(String)

        Dim COL_DFLT_TAX_STATE_PERCENT As DataColumn = New DataColumn("DFLT_TAX_STATE_PERCENT")
        COL_DFLT_TAX_STATE_PERCENT.DataType = GetType(Decimal)

        Dim COL_DFLT_TAX_COUNTY_PERCENT As DataColumn = New DataColumn("DFLT_TAX_COUNTY_PERCENT")
        COL_DFLT_TAX_COUNTY_PERCENT.DataType = GetType(Decimal)

        Dim COL_DFLT_TAX_CITY_PERCENT As DataColumn = New DataColumn("DFLT_TAX_CITY_PERCENT")
        COL_DFLT_TAX_CITY_PERCENT.DataType = GetType(Decimal)

        Dim COL_EMP_TITLE As DataColumn = New DataColumn("EMP_TITLE")
        COL_EMP_TITLE.DataType = GetType(String)

        Dim QUOTE_W_CONTINGENCY As DataColumn = New DataColumn("QUOTE_W_CONTINGENCY")
        QUOTE_W_CONTINGENCY.DataType = GetType(Decimal)

        Dim TAX As DataColumn = New DataColumn("TAX")
        TAX.DataType = GetType(Decimal)

        Dim EST_REV_EXT_MU_AMT As DataColumn = New DataColumn("EST_REV_EXT_MU_AMT")
        EST_REV_EXT_MU_AMT.DataType = GetType(Decimal)

        'Custom Columns
        Dim COL_IS_USER_ROW As DataColumn = New DataColumn("IS_USER_ROW")
        COL_IS_USER_ROW.DataType = GetType(Int32)

        'Add columns to dt
        With Me.mDtQuoteFunctions.Columns
            .Add(COL_INDEX)

            .Add(COL_ESTIMATE_NUMBER)
            .Add(COL_EST_COMPONENT_NBR)
            .Add(COL_EST_QUOTE_NBR)
            .Add(COL_EST_QUOTE_DESC)
            .Add(COL_EST_REV_NBR)
            .Add(COL_SEQ_NBR)
            .Add(COL_FNC_CODE)
            .Add(COL_FNC_DESCRIPTION)
            .Add(COL_EST_FNC_COMMENT)
            .Add(COL_EST_REV_SUP_BY_CDE)
            .Add(COL_EST_REV_SUP_BY_NTE)
            .Add(COL_EST_REV_QUANTITY)
            .Add(COL_EST_REV_RATE)
            .Add(COL_EST_REV_EXT_AMT)
            .Add(COL_TAX_CODE)
            .Add(COL_EST_REV_COMM_PCT)
            .Add(COL_EXT_MARKUP_AMT)
            .Add(COL_LINE_TOTAL)
            .Add(COL_EST_REV_CONT_PCT)
            .Add(COL_EXT_CONTINGENCY)
            .Add(COL_INCL_CPU)
            .Add(COL_TAX_STATE_PCT)
            .Add(COL_TAX_COUNTY_PCT)
            .Add(COL_TAX_CITY_PCT)
            .Add(COL_TAX_COMM)
            .Add(COL_TAX_COMM_ONLY)
            .Add(COL_TAX_RESALE)
            .Add(COL_EXT_NONRESALE_TAX)
            .Add(COL_EXT_STATE_RESALE)
            .Add(COL_EXT_COUNTY_RESALE)
            .Add(COL_EXT_CITY_RESALE)
            .Add(COL_EXT_MU_CONT)
            .Add(COL_EXT_STATE_CONT)
            .Add(COL_EXT_COUNTY_CONT)
            .Add(COL_EXT_CITY_CONT)
            .Add(COL_EXT_NR_CONT)
            .Add(COL_LINE_TOTAL_CONT)
            .Add(COL_EST_CPM_FLAG)
            .Add(COL_EST_FNC_TYPE)
            .Add(COL_EST_COMM_FLAG)
            .Add(COL_EST_TAX_FLAG)
            .Add(COL_EST_NONBILL_FLAG)
            .Add(COL_FEE_TIME)
            .Add(COL_EMPLOYEE_TITLE_ID)
            .Add(COL_FNC_TYPE)
            .Add(COL_EST_PHASE_ID)
            .Add(COL_EST_PHASE_DESC)
            .Add(COL_FNC_HEADING_ID)
            .Add(COL_FNC_HEADING_DESC)
            .Add(COL_FNC_HEADING_SEQ)
            .Add(COL_FNC_CONSOLIDATION)
            .Add(COL_FNC_CONSOL_DESC)
            .Add(COL_DFLT_TAX_STATE_PERCENT)
            .Add(COL_DFLT_TAX_COUNTY_PERCENT)
            .Add(COL_DFLT_TAX_CITY_PERCENT)
            .Add(COL_EMP_TITLE)
            .Add(QUOTE_W_CONTINGENCY)
            .Add(TAX)
            .Add(EST_REV_EXT_MU_AMT)
            .Add(COL_IS_USER_ROW)
        End With

        Me.mDtQuoteFunctions.PrimaryKey = Pk

    End Sub

    Public Function InsertNewFunction(ByVal EstNum As Integer, ByVal EstCompNum As Integer,
                                   ByVal QuoteNum As Integer, ByVal EstRevNum As Integer,
                                   ByVal FncCode As String, ByVal UserID As String, ByVal EmpCode As String, ByVal FncComment As String,
                                   ByVal SupComment As String, Optional ByVal QtyHrs As Decimal = 0, Optional ByVal EventGenId As Integer = 0, Optional ByVal NumOccurences As Integer = 0,
                                   Optional ByVal blendedrate As String = "") As String

        If EstNum > 0 And EstCompNum > 0 Then

            Dim arParams(14) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = EstNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = EstCompNum
            arParams(1) = paramTask_JobCompNum

            Dim pQuoteNum As SqlParameter = New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pQuoteNum.Value = QuoteNum
            arParams(2) = pQuoteNum

            Dim pEstRevNum As SqlParameter = New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            pEstRevNum.Value = EstRevNum
            arParams(3) = pEstRevNum

            Dim pFncCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            pFncCode.Value = FncCode
            arParams(4) = pFncCode

            Dim pFROM_FORM As SqlParameter = New SqlParameter("@FROM_FORM", SqlDbType.Int)
            pFROM_FORM.Value = 0
            arParams(5) = pFROM_FORM

            Dim pUSER_ID As SqlParameter = New SqlParameter("@USER_ID", SqlDbType.VarChar)
            pUSER_ID.Value = UserID
            arParams(6) = pUSER_ID

            Dim pEVENT_GEN_ID As SqlParameter = New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(7) = pEVENT_GEN_ID

            Dim pEMP_CODE As SqlParameter = New SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            If EmpCode = "" Then
                pEMP_CODE.Value = DBNull.Value
            Else
                pEMP_CODE.Value = EmpCode
            End If
            arParams(8) = pEMP_CODE

            Dim pEST_REV_QUANTITY As SqlParameter = New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
            If QtyHrs = 0.0 Then
                pEST_REV_QUANTITY.Value = System.DBNull.Value
            Else
                pEST_REV_QUANTITY.Value = QtyHrs
            End If
            arParams(9) = pEST_REV_QUANTITY

            Dim pNUM_OCCURENCES As SqlParameter = New SqlParameter("@NUM_OCCURENCES", SqlDbType.Int)
            If NumOccurences = 0 Then
                pNUM_OCCURENCES.Value = System.DBNull.Value
            Else
                pNUM_OCCURENCES.Value = NumOccurences
            End If
            arParams(10) = pNUM_OCCURENCES

            Dim pEST_FUNC_COMMENT As SqlParameter = New SqlParameter("@EST_FUNC_COMMENT", SqlDbType.Text)
            pEST_FUNC_COMMENT.Value = FncComment
            arParams(11) = pEST_FUNC_COMMENT

            Dim pEST_REV_SUP_BY_NTE As SqlParameter = New SqlParameter("@EST_REV_SUP_BY_NTE", SqlDbType.Text)
            pEST_REV_SUP_BY_NTE.Value = SupComment
            arParams(12) = pEST_REV_SUP_BY_NTE

            Dim pBLENDED_TIME_RATE As SqlParameter = New SqlParameter("@BLENDED_TIME_RATE", SqlDbType.Decimal)
            If blendedrate = "" Then
                pBLENDED_TIME_RATE.Value = DBNull.Value
            Else
                pBLENDED_TIME_RATE.Value = CDec(blendedrate)
            End If
            arParams(13) = pBLENDED_TIME_RATE

            Dim i As String
            Try
                i = CStr(oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_ESTIMATE_REV_DET_INSERT_DFLT", arParams))
                Return i.ToString()
            Catch ex As Exception
                Return ex.Message.ToString
            End Try

        End If
    End Function

#End Region

#Region " Estimate Quotes "

    Public Function GetEstimateQuotes(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetQuotes", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuotes", Err.Description)
        Finally

        End Try

        Return ds
    End Function

    Public Function GetEstimateQuotesDT(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetQuotes", "dt", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuotes", Err.Description)
        Finally

        End Try

        Return dt
    End Function

    Public Function GetEstimateQuoteInfo(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Info", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteInfo", Err.Description)
        Finally

        End Try

        Return dr
    End Function


    Public Function GetEstimateQuoteDetailsCopy(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer) As Boolean
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Details_Copy", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteDetailsCopy", Err.Description)
        Finally

        End Try


    End Function

    Public Function GetEstimateQuoteFunctionCopy(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer, ByVal seqnum As Integer) As Boolean
        Dim ds As DataSet
        Dim arParams(5) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber
        Dim parameterSeqNumber As New SqlParameter("@SeqNo", SqlDbType.Int, 0)
        parameterSeqNumber.Value = seqnum
        arParams(4) = parameterSeqNumber

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Copy_Function", arParams)
            Return True
        Catch ex As Exception
            Return False
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteFunctionCopy", Err.Description)
        Finally

        End Try


    End Function

    Public Function GetEstimateQuoteDetailsDS(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_DetailsDS", arParams)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteDetailsDS", Err.Description)
        Finally

        End Try


    End Function

    Public Function GetEstimateQuoteSummary(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer, ByVal phase As String, ByVal display As String) As DataSet
        Dim ds As DataSet

        'Get the real data
        Dim arParams(6) As SqlParameter

        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber
        Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.VarChar)
        parameterPhase.Value = phase
        arParams(4) = parameterPhase
        Dim parameterDisplay As New SqlParameter("@Display", SqlDbType.VarChar)
        parameterDisplay.Value = display
        arParams(5) = parameterDisplay

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Summary", arParams)
            Return ds
        Catch ex As Exception

        End Try

    End Function

    Public Function GetEstimateQuoteDetailsAlert(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        parameterRevNumber.Value = revnum
        arParams(3) = parameterRevNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_DetailsAlert", arParams)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteDetailsAlert", Err.Description)
        Finally

        End Try


    End Function

    Public Function GetEstimateQuoteDetailsAll(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Details_All", arParams)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteDetailsAll", Err.Description)
        Finally

        End Try


    End Function

    Public Function GetEstimateQuoteDetailBySeq(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer, ByVal revnum As Integer, ByVal seqnum As Integer) As DataTable
        Try
            Me.CreateEstimateQuoteDetailsDatatable()

            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int)
            parameterQuoteNumber.Value = quotenum
            arParams(2) = parameterQuoteNumber
            Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            parameterRevNumber.Value = revnum
            arParams(3) = parameterRevNumber
            Dim parameterSeqNo As New SqlParameter("@SeqNo", SqlDbType.Int)
            parameterSeqNo.Value = seqnum
            arParams(4) = parameterSeqNo

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_DetailsBySeq", "DtQuoteFunc", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try

    End Function

    Public Function GetEstimateQuoteRevisions(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_Revisions", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteRevisions", Err.Description)
        Finally

        End Try

        Return dr
    End Function

    Public Function GetEstimateQuoteMax(ByVal estnum As Integer, ByVal estcompnum As Integer) As Integer
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter
        Dim max As Integer = 0

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            max = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_GetMaxQuote", arParams))
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteMax", Err.Description)
        Finally

        End Try

        Return max
    End Function

    Public Function GetEstimateQuoteMaxRevision(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer) As Integer
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter
        Dim max As Integer = 0

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@QuoteNo", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber

        Try
            max = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Quote_GetMaxRevision", arParams))
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateQuoteRevision", Err.Description)
        Finally

        End Try

        Return max
    End Function

    Public Function AddNewQuote(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer) As Boolean
        Try
            Dim arParams(4) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_AddQuote", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateQuote(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal QuoteDescription As String,
                                   ByVal EstRevNbr As Integer,
                                   ByVal QuoteComment As String,
                                   ByVal RevisionComment As String,
                                   ByVal SpecVer As String,
                                   ByVal SpecRev As String,
                                   ByVal SpecQtySeqNbr As Integer,
                                   ByVal JobQty As String,
                                   ByVal SpecRTF As String,
                                   ByVal UserID As String,
                                   ByVal BlendedRate As String,
                                   ByVal QuoteCommentHtml As String,
                                   ByVal RevisionCommentHtml As String) As Boolean
        Try
            Dim arParams(17) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_QUOTE_DESC As New SqlParameter("@EST_QUOTE_DESC", SqlDbType.VarChar)
            paramEST_QUOTE_DESC.Value = QuoteDescription
            arParams(3) = paramEST_QUOTE_DESC

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(4) = paramEST_REV_NBR

            Dim paramEST_QTE_COMMENT As New SqlParameter("@EST_QTE_COMMENT", SqlDbType.Text)
            paramEST_QTE_COMMENT.Value = QuoteComment.Replace(vbLf, vbCrLf)
            arParams(5) = paramEST_QTE_COMMENT

            Dim paramEST_QTE_COMMENT_HTML As New SqlParameter("@EST_QTE_COMMENT_HTML", SqlDbType.Text)
            paramEST_QTE_COMMENT_HTML.Value = QuoteCommentHtml
            arParams(6) = paramEST_QTE_COMMENT_HTML

            Dim paramEST_REV_COMMENT As New SqlParameter("@EST_REV_COMMENT", SqlDbType.Text)
            paramEST_REV_COMMENT.Value = RevisionComment.Replace(vbLf, vbCrLf)
            arParams(7) = paramEST_REV_COMMENT

            Dim paramEST_REV_COMMENT_HTML As New SqlParameter("@EST_REV_COMMENT_HTML", SqlDbType.Text)
            paramEST_REV_COMMENT_HTML.Value = RevisionCommentHtml
            arParams(8) = paramEST_REV_COMMENT_HTML

            Dim paramSPEC_VER As New SqlParameter("@SPEC_VER", SqlDbType.Int)
            If SpecVer = "" Or SpecVer = "0" Then
                paramSPEC_VER.Value = DBNull.Value
            Else
                paramSPEC_VER.Value = CInt(SpecVer)
            End If
            arParams(9) = paramSPEC_VER

            Dim paramSPEC_REV As New SqlParameter("@SPEC_REV", SqlDbType.Int)
            If SpecRev = "" Or SpecRev = "-1" Or SpecVer = "" Or SpecVer = "0" Then
                paramSPEC_REV.Value = DBNull.Value
            Else
                paramSPEC_REV.Value = CInt(SpecRev)
            End If
            arParams(10) = paramSPEC_REV

            Dim paramSPEC_QTY_SEQ_NBR As New SqlParameter("@SPEC_QTY_SEQ_NBR", SqlDbType.Int)
            If SpecQtySeqNbr = 0 Then
                paramSPEC_QTY_SEQ_NBR.Value = DBNull.Value
            Else
                paramSPEC_QTY_SEQ_NBR.Value = SpecQtySeqNbr
            End If
            arParams(11) = paramSPEC_QTY_SEQ_NBR

            Dim paramJOB_QTY As New SqlParameter("@JOB_QTY", SqlDbType.Int)
            If JobQty = "" Then
                paramJOB_QTY.Value = DBNull.Value
            Else
                paramJOB_QTY.Value = CInt(JobQty)
            End If
            arParams(12) = paramJOB_QTY

            Dim paramSPEC_RTF As New SqlParameter("@SPEC_RTF", SqlDbType.Text)
            If SpecRTF = "" Then
                paramSPEC_RTF.Value = DBNull.Value
            Else
                paramSPEC_RTF.Value = SpecRTF
            End If
            arParams(13) = paramSPEC_RTF

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(14) = paramUSER_ID

            Dim QTE As New SqlParameter("@QTE_NUM", SqlDbType.Int, 4)
            QTE.Direction = ParameterDirection.Output
            arParams(15) = QTE

            Dim paramBLENDED_TIME_RATE As New SqlParameter("@BLENDED_TIME_RATE", SqlDbType.Decimal)
            If BlendedRate = "" Then
                paramBLENDED_TIME_RATE.Value = DBNull.Value
            Else
                paramBLENDED_TIME_RATE.Value = CDec(BlendedRate)
            End If
            arParams(16) = paramBLENDED_TIME_RATE

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_Quote", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateQuoteComments(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal SeqNbr As Integer,
                                   ByVal DetailComment As String,
                                   ByVal SuppliedByComment As String,
                                   ByVal DetailCommentHtml As String,
                                   ByVal SuppliedByCommentHtml As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.Int)
            paramSEQ_NBR.Value = SeqNbr
            arParams(4) = paramSEQ_NBR

            Dim paramEST_FNC_COMMENT As New SqlParameter("@EST_FNC_COMMENT", SqlDbType.Text)
            paramEST_FNC_COMMENT.Value = DetailComment.Trim().Replace(vbLf, vbCrLf)
            arParams(5) = paramEST_FNC_COMMENT

            Dim paramEST_REV_SUP_BY_NTE As New SqlParameter("@EST_REV_SUP_BY_NTE", SqlDbType.Text)
            paramEST_REV_SUP_BY_NTE.Value = SuppliedByComment.Trim().Replace(vbLf, vbCrLf)
            arParams(6) = paramEST_REV_SUP_BY_NTE

            Dim paramEST_FNC_COMMENT_HTML As New SqlParameter("@EST_FNC_COMMENT_HTML", SqlDbType.Text)
            paramEST_FNC_COMMENT_HTML.Value = DetailCommentHtml
            arParams(7) = paramEST_FNC_COMMENT_HTML

            Dim paramEST_REV_SUP_BY_HTML As New SqlParameter("@EST_REV_SUP_BY_HTML", SqlDbType.Text)
            paramEST_REV_SUP_BY_HTML.Value = SuppliedByCommentHtml
            arParams(8) = paramEST_REV_SUP_BY_HTML

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_QuoteComments", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddQuoteApproval(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal JobNum As Integer,
                                   ByVal JobCompNum As Integer,
                                   ByVal EstApprBy As String,
                                   ByVal EstApprDate As DateTime,
                                   ByVal EstApprClPo As String,
                                   ByVal CreateUser As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal ApprNotes As String) As Boolean
        Try
            Dim arParams(13) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNum
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobCompNum
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(2) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(3) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(4) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(5) = paramEST_REV_NBR

            Dim paramEST_APPR_B As New SqlParameter("@EST_APPR_BY", SqlDbType.VarChar)
            paramEST_APPR_B.Value = EstApprBy
            arParams(7) = paramEST_APPR_B

            Dim paramEST_APPR_DATE As New SqlParameter("@EST_APPR_DATE", SqlDbType.SmallDateTime)
            paramEST_APPR_DATE.Value = EstApprDate
            arParams(8) = paramEST_APPR_DATE

            Dim paramEST_APPR_CL_PO_NBR As New SqlParameter("@EST_APPR_CL_PO_NBR", SqlDbType.VarChar)
            paramEST_APPR_CL_PO_NBR.Value = EstApprClPo
            arParams(9) = paramEST_APPR_CL_PO_NBR

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar)
            paramCREATE_USER.Value = CreateUser
            arParams(10) = paramCREATE_USER

            Dim paramCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCREATE_DATE.Value = CreateDate
            arParams(11) = paramCREATE_DATE

            Dim paramAPPR_NOTES As New SqlParameter("@APPR_NOTES", SqlDbType.Text)
            paramAPPR_NOTES.Value = ApprNotes
            arParams(12) = paramAPPR_NOTES


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddApproval", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddQuoteApprovalInternal(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal JobNum As Integer,
                                   ByVal JobCompNum As Integer,
                                   ByVal EstApprBy As String,
                                   ByVal EstApprDate As DateTime,
                                   ByVal CreateUser As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal ApprNotes As String) As Boolean
        Try
            Dim arParams(12) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNum
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobCompNum
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(2) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(3) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(4) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(5) = paramEST_REV_NBR

            Dim paramEST_APPR_B As New SqlParameter("@EST_APPR_BY", SqlDbType.VarChar)
            paramEST_APPR_B.Value = EstApprBy
            arParams(7) = paramEST_APPR_B

            Dim paramEST_APPR_DATE As New SqlParameter("@EST_APPR_DATE", SqlDbType.SmallDateTime)
            paramEST_APPR_DATE.Value = EstApprDate
            arParams(8) = paramEST_APPR_DATE

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar)
            paramCREATE_USER.Value = CreateUser
            arParams(9) = paramCREATE_USER

            Dim paramCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCREATE_DATE.Value = CreateDate
            arParams(10) = paramCREATE_DATE

            Dim paramAPPR_NOTES As New SqlParameter("@APPR_NOTES", SqlDbType.Text)
            paramAPPR_NOTES.Value = ApprNotes
            arParams(11) = paramAPPR_NOTES


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddInternalApproval", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddCampaignQuoteApproval(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal CampaignID As Integer,
                                   ByVal EstApprBy As String,
                                   ByVal EstApprDate As DateTime,
                                   ByVal CreateUser As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal ApprNotes As String,
                                   ByVal ApprType As String) As Boolean
        Try
            Dim arParams(11) As SqlParameter

            Dim paramCMP_IDENTIFIER As New SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            paramCMP_IDENTIFIER.Value = CampaignID
            arParams(0) = paramCMP_IDENTIFIER

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(1) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(2) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(3) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(4) = paramEST_REV_NBR

            Dim paramEST_APPR_B As New SqlParameter("@EST_APPR_BY", SqlDbType.VarChar)
            paramEST_APPR_B.Value = EstApprBy
            arParams(5) = paramEST_APPR_B

            Dim paramEST_APPR_DATE As New SqlParameter("@EST_APPR_DATE", SqlDbType.SmallDateTime)
            paramEST_APPR_DATE.Value = EstApprDate
            arParams(6) = paramEST_APPR_DATE

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar)
            paramCREATE_USER.Value = CreateUser
            arParams(7) = paramCREATE_USER

            Dim paramCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCREATE_DATE.Value = CreateDate
            arParams(8) = paramCREATE_DATE

            Dim paramAPPR_NOTES As New SqlParameter("@APPR_NOTES", SqlDbType.Text)
            paramAPPR_NOTES.Value = ApprNotes
            arParams(9) = paramAPPR_NOTES

            Dim paramAPPR_TYPE As New SqlParameter("@APPR_TYPE", SqlDbType.VarChar)
            paramAPPR_TYPE.Value = ApprType
            arParams(10) = paramAPPR_TYPE


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddCampaignApproval", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteQuoteApproval(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer) As Boolean
        Try
            Dim arParams(2) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_DeleteApprovalData", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteQuoteApprovalInternal(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer) As Boolean
        Try
            Dim arParams(2) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_DeleteInternalApprovalData", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetQuoteApproval(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(4) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetApprovalData", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetQuoteApprovalInternal(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(4) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetInternalApprovalData", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetQuoteApproval(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REVISION_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(4) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetApprovalData", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetApprovals(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(3) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(2) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetApprovals", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetApprovalByQuote(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal EstQuoteNbr As Integer) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(3) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = EstQuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetApprovalByQuote", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetApprovalByQuoteMax(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal EstQuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = EstQuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(4) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetApprovalByQuoteMax", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetInternalApprovals(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(3) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(2) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetInternalApprovals", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetInternalApprovalByQuote(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal EstQuoteNbr As Integer) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(3) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = EstQuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetInternalApprovalByQuote", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetInternalApprovalByQuoteMax(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal EstQuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal ApprovalType As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = EstQuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramAPPROVAL_TYPE As New SqlParameter("@APPROVAL_TYPE", SqlDbType.VarChar)
            paramAPPROVAL_TYPE.Value = ApprovalType
            arParams(4) = paramAPPROVAL_TYPE

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetInternalApprovalByQuoteMax", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function AddNewRevision(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal SpecVer As Integer,
                                   ByVal SpecRev As Integer,
                                   ByVal SpecQtySeqNbr As Integer,
                                   ByVal JobQty As Integer) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramSPEC_VER As New SqlParameter("@SPEC_VER", SqlDbType.Int)
            paramSPEC_VER.Value = SpecVer
            arParams(4) = paramSPEC_VER

            Dim paramSPEC_REV As New SqlParameter("@SPEC_REV", SqlDbType.Int)
            paramSPEC_REV.Value = SpecRev
            arParams(5) = paramSPEC_REV

            Dim paramSPEC_QTY_SEQ_NBR As New SqlParameter("@SPEC_QTY_SEQ_NBR", SqlDbType.Int)
            paramSPEC_QTY_SEQ_NBR.Value = SpecQtySeqNbr
            arParams(6) = paramSPEC_QTY_SEQ_NBR

            Dim paramJOB_QTY As New SqlParameter("@JOB_QTY", SqlDbType.Int)
            paramJOB_QTY.Value = JobQty
            arParams(7) = paramJOB_QTY


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNewRevision", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetQuickAddDT(ByVal ShowAsPreset As Boolean, ByVal JobNumber As Integer, ByVal ClientCode As String) As DataTable
        Try

            Dim arP(3) As SqlParameter

            Dim pSHOW_PRESET As New SqlParameter("@SHOW_PRESET", SqlDbType.Bit)
            pSHOW_PRESET.Value = ShowAsPreset
            arP(0) = pSHOW_PRESET

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            arP(1) = pJobNumber

            Dim pClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            pClientCode.Value = ClientCode
            arP(3) = pClientCode

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetQuickAdd", "dtQuickAdd", arP)

        Catch ex As Exception
        End Try
    End Function

    Public Function GetEstimateJobSpecs(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal jobnum As Integer, ByVal jobcompnum As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstComp", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterJobNumber As New SqlParameter("@JobNo", SqlDbType.Int, 0)
        parameterJobNumber.Value = jobnum
        arParams(2) = parameterJobNumber
        Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.Int, 0)
        parameterJobCompNumber.Value = jobcompnum
        arParams(3) = parameterJobCompNumber

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_JobSpecs", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimateJobSpecs", Err.Description)
        Finally

        End Try

        Return dr
    End Function

    Public Function GetEstimatePhases(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetPhases", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimatePhases", Err.Description)
        Finally

        End Try

        Return ds
    End Function

    Public Function GetEstimatePhaseDesc(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataSet
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetPhaseDesc", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetEstimatePhases", Err.Description)
        Finally

        End Try

        Return ds
    End Function

    Public Function UpdateQuotePhase(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal SeqNbr As String,
                                   ByVal EstPhaseID As Integer,
                                   ByVal EstPhaseDesc As String) As Boolean
        Try
            Dim arParams(7) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.VarChar)
            paramSEQ_NBR.Value = SeqNbr
            arParams(4) = paramSEQ_NBR

            Dim paramEST_PHASE_ID As New SqlParameter("@EST_PHASE_ID", SqlDbType.Int)
            paramEST_PHASE_ID.Value = EstPhaseID
            arParams(5) = paramEST_PHASE_ID

            Dim paramEST_PHASE_DESC As New SqlParameter("@EST_PHASE_DESC", SqlDbType.VarChar)
            paramEST_PHASE_DESC.Value = EstPhaseDesc
            arParams(6) = paramEST_PHASE_DESC

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_Quote_Phase", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetEstimateQuoteSpecs(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal quotenum As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(4) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber
        Dim parameterQuoteNumber As New SqlParameter("@EstQuote", SqlDbType.Int, 0)
        parameterQuoteNumber.Value = quotenum
        arParams(2) = parameterQuoteNumber
        'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int, 0)
        'parameterRevNumber.Value = revnum
        'arParams(3) = parameterRevNumber

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetQuotesForImport", "dtSpecs", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetQuotesForImport", Err.Description)
        Finally

        End Try

        Return dt
    End Function

    Public Function GetEstimateImportSpecs(ByVal estnum As Integer, ByVal estcompnum As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@EstNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = estnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@EstCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = estcompnum
        arParams(1) = parameterEstCompNumber

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetSpecsForImport", "dtSpecs", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetSpecsForImport", Err.Description)
        Finally

        End Try

        Return dt
    End Function

    Public Function GetEstimateImportSpecsJC(ByVal jobnum As Integer, ByVal jobcompnum As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(2) As SqlParameter

        'Create Stored Procedure Parameters           
        Dim parameterEstNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
        parameterEstNumber.Value = jobnum
        arParams(0) = parameterEstNumber
        Dim parameterEstCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int, 0)
        parameterEstCompNumber.Value = jobcompnum
        arParams(1) = parameterEstCompNumber

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetSpecsForImport_ByJobComp", "dtSpecs", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cEstimating Routine:GetSpecsForImportJC", Err.Description)
        Finally

        End Try

        Return dt
    End Function

    Public Function GetEstimateTasks(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Sort As String, ByVal UserCode As String,
                                                            Optional ByVal EmpCode As String = "", Optional ByVal TaskCode As String = "", Optional ByVal RoleCode As String = "", Optional ByVal IncludeCompletedTasks As Boolean = True,
                                                            Optional ByVal IncludeOnlyPendingTasks As Boolean = False, Optional ByVal ExcludeProjectedTasks As Boolean = False, Optional ByVal CutOffDate As String = "", Optional ByVal PhaseFilter As String = "",
                                                            Optional ByVal IncludeEstimate As Boolean = False) As DataTable
        Try
            Dim arParams(13) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim paramSort As New SqlParameter("@Sort", SqlDbType.VarChar, 10)
            paramSort.Value = Sort
            arParams(2) = paramSort

            Dim paramUserCode As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(3) = paramUserCode

            Dim paramEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEmpCode.Value = EmpCode
            arParams(4) = paramEmpCode

            Dim paramTaskCode As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            paramTaskCode.Value = TaskCode
            arParams(5) = paramTaskCode

            Dim paramRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            paramRoleCode.Value = RoleCode
            arParams(6) = paramRoleCode

            Dim paramIncludeCompletedTasks As New SqlParameter("@IncludeCompletedTasks", SqlDbType.Char)
            If IncludeCompletedTasks = True Then
                paramIncludeCompletedTasks.Value = "Y"
            Else
                paramIncludeCompletedTasks.Value = "N"
            End If
            arParams(7) = paramIncludeCompletedTasks

            Dim paramIncludeOnlyPendingTasks As New SqlParameter("@IncludeOnlyPendingTasks", SqlDbType.Char)
            If IncludeOnlyPendingTasks = True Then
                paramIncludeOnlyPendingTasks.Value = "Y"
            Else
                paramIncludeOnlyPendingTasks.Value = "N"
            End If
            arParams(8) = paramIncludeOnlyPendingTasks

            Dim paramExcludeProjectedTasks As New SqlParameter("@ExcludeProjectedTasks", SqlDbType.Char)
            If ExcludeProjectedTasks = True Then
                paramExcludeProjectedTasks.Value = "Y"
            Else
                paramExcludeProjectedTasks.Value = "N"
            End If
            arParams(9) = paramExcludeProjectedTasks

            Dim paramCutOffDate As New SqlParameter("@CUT_OFF_DATE", SqlDbType.VarChar, 15)
            If cGlobals.wvIsDate(CutOffDate) = True Then
                paramCutOffDate.Value = cGlobals.wvCDate(CutOffDate).ToShortDateString
            Else
                paramCutOffDate.Value = DBNull.Value
            End If
            arParams(10) = paramCutOffDate

            Dim paramPhaseFilter As New SqlParameter("@PHASE_FILTER", SqlDbType.VarChar, 10)
            paramPhaseFilter.Value = PhaseFilter
            arParams(11) = paramPhaseFilter

            Dim paramIncludeEstimate As New SqlParameter("@IncludeEstimate", SqlDbType.Char)
            If IncludeEstimate = True Then
                paramIncludeEstimate.Value = "Y"
            Else
                paramIncludeEstimate.Value = "N"
            End If
            arParams(12) = paramIncludeEstimate



            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetTasks", "dtTasks", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetEstimatingTasks!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetEstBillRateFlag(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Integer
        Dim arParams(3) As SqlParameter
        Dim i As Integer = 0

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode
        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode
        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Try
            i = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetEstBillRateFlag", arParams))
            Return i
        Catch
            Return 0
        End Try

    End Function

    Public Function UpdateCopyQuoteComments(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal RevisionNumber As Integer,
                                   ByVal CopyFromEstNbr As Integer,
                                   ByVal CopyFromEstCompNbr As Integer,
                                   ByVal CopyFromQuoteNbr As Integer,
                                   ByVal CopyFromRevisionNumber As Integer) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = RevisionNumber
            arParams(3) = paramEST_REV_NBR

            Dim paramCOPY_FROM_ESTIMATE_NUMBER As New SqlParameter("@COPY_FROM_ESTIMATE_NUMBER", SqlDbType.Int)
            paramCOPY_FROM_ESTIMATE_NUMBER.Value = CopyFromEstNbr
            arParams(4) = paramCOPY_FROM_ESTIMATE_NUMBER

            Dim paramCOPY_FROM_EST_COMPONENT_NBR As New SqlParameter("@COPY_FROM_EST_COMPONENT_NBR", SqlDbType.Int)
            paramCOPY_FROM_EST_COMPONENT_NBR.Value = CopyFromEstCompNbr
            arParams(5) = paramCOPY_FROM_EST_COMPONENT_NBR

            Dim paramCOPY_FROM_EST_QUOTE_NBR As New SqlParameter("@COPY_FROM_EST_QUOTE_NBR", SqlDbType.Int)
            paramCOPY_FROM_EST_QUOTE_NBR.Value = CopyFromQuoteNbr
            arParams(6) = paramCOPY_FROM_EST_QUOTE_NBR

            Dim paramCOPY_FROM_EST_REV_NBR As New SqlParameter("@COPY_FROM_EST_REV_NBR", SqlDbType.Int)
            paramCOPY_FROM_EST_REV_NBR.Value = CopyFromRevisionNumber
            arParams(7) = paramCOPY_FROM_EST_REV_NBR

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_Quote_Comments", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region

#Region " Estimate Data "

    Public Overloads Function GetInfoForEstimate(ByVal EstNo As Integer) As DataTable
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Info", "dtestinfo", parameterEstNo)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Overloads Function GetInfoForEstimateComp(ByVal EstNo As Integer, ByVal EstComp As Integer) As DataTable
        Dim ar(2) As SqlParameter

        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Info_Comp", "dtestqinfo", ar)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Overloads Function GetInfoForEstimateQuote(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal Quote As Integer) As DataSet
        Dim ds As DataSet
        Dim ar(3) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterQuote As New SqlParameter("@Quote", SqlDbType.Int)
        parameterQuote.Value = Quote
        ar(2) = parameterQuote

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Info_Quote", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetInfoForEstimateQuote", Err.Description)
        End Try

        Return ds
    End Function

    Public Function CountHeaderComponentsOneComp(ByVal EstNum As Integer) As Integer
        Try
            Dim arParams(1) As SqlParameter

            Dim paramEstNum As New SqlParameter("@EST_NUMBER", SqlDbType.Int)
            paramEstNum.Value = EstNum
            arParams(0) = paramEstNum

            Dim i As Integer = 0

            i = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CountHeaderComponents", arParams))

            Return i

        Catch ex As Exception
            Return -999
        End Try
    End Function

    Public Function CountCompQuotesOneComp(ByVal EstNum As Integer, ByVal EstComp As Integer) As Integer
        Try
            Dim arParams(2) As SqlParameter

            Dim paramEstNum As New SqlParameter("@EST_NUMBER", SqlDbType.Int)
            paramEstNum.Value = EstNum
            arParams(0) = paramEstNum

            Dim paramEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEstComp.Value = EstComp
            arParams(1) = paramEstComp

            Dim i As Integer = 0

            i = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CountCompQuotes", arParams))

            Return i

        Catch ex As Exception
            Return -999
        End Try
    End Function

    Public Overloads Function GetEstimateData(ByVal EstNo As Integer, ByVal EstCompNo As Integer, ByVal JobNo As Integer, ByVal JobCompNo As Integer, ByVal UserID As String) As DataTable
        Dim dt As DataTable
        Dim ar(5) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstCompNo
        ar(1) = parameterEstComp

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int)
        parameterJobNo.Value = JobNo
        ar(2) = parameterJobNo

        Dim parameterJobComp As New SqlParameter("@JobCompNo", SqlDbType.Int)
        parameterJobComp.Value = JobCompNo
        ar(3) = parameterJobComp

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = UserID
        ar(4) = parameterUserID

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Data", "estimate", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateData", Err.Description)
        End Try

        Return dt
    End Function

    Public Function AddNewEstimate(ByVal Client As String,
                                   ByVal Division As String,
                                   ByVal Product As String,
                                   ByVal SalesClass As String,
                                   ByVal MarkupPct As Decimal,
                                   ByVal UserID As String,
                                   ByVal EstDesc As String,
                                   ByVal EstCompDesc As String,
                                   ByVal JobNum As Integer,
                                   ByVal JobCompNum As Integer,
                                   ByVal CDPContact As String,
                                   ByVal CampaignID As Integer) As String
        Try
            Dim arParams(14) As SqlParameter

            Dim paramCLIENT As New SqlParameter("@CLIENT", SqlDbType.VarChar)
            paramCLIENT.Value = Client
            arParams(0) = paramCLIENT

            Dim paramDIVISION As New SqlParameter("@DIVISION", SqlDbType.VarChar)
            paramDIVISION.Value = Division
            arParams(1) = paramDIVISION

            Dim paramPRODUCT As New SqlParameter("@PRODUCT", SqlDbType.VarChar)
            paramPRODUCT.Value = Product
            arParams(2) = paramPRODUCT

            Dim paramSALES_CLASS As New SqlParameter("@SALES_CLASS", SqlDbType.VarChar)
            paramSALES_CLASS.Value = SalesClass
            arParams(3) = paramSALES_CLASS

            Dim paramMARKUP_PCT As New SqlParameter("@MARKUP_PCT", SqlDbType.Decimal)
            If MarkupPct < 0.0 Then
                paramMARKUP_PCT.Value = DBNull.Value
            Else
                paramMARKUP_PCT.Value = MarkupPct
            End If
            arParams(4) = paramMARKUP_PCT

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(5) = paramUSER_ID

            Dim paramEST_CREATE_DATE As New SqlParameter("@EST_CREATE_DATE", SqlDbType.SmallDateTime)
            paramEST_CREATE_DATE.Value = cEmployee.TimeZoneToday
            arParams(6) = paramEST_CREATE_DATE

            Dim paramEST_DESC As New SqlParameter("@EST_DESC", SqlDbType.VarChar)
            paramEST_DESC.Value = EstDesc
            arParams(7) = paramEST_DESC

            Dim paramEST_COMP_DESC As New SqlParameter("@EST_COMP_DESC", SqlDbType.VarChar)
            paramEST_COMP_DESC.Value = EstCompDesc
            arParams(8) = paramEST_COMP_DESC

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNum
            arParams(9) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJOB_COMPONENT_NBR.Value = JobCompNum
            arParams(10) = paramJOB_COMPONENT_NBR

            Dim paramCDP_CONTACT_ID As New SqlParameter("@CDP_CONTACT_ID", SqlDbType.Int)
            If CDPContact = "" Or CDPContact = "0" Then
                paramCDP_CONTACT_ID.Value = DBNull.Value
            Else
                paramCDP_CONTACT_ID.Value = CDPContact
            End If
            arParams(11) = paramCDP_CONTACT_ID

            Dim paramCMP_IDENTIFIER As New SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            If CampaignID = 0 Then
                paramCMP_IDENTIFIER.Value = DBNull.Value
            Else
                paramCMP_IDENTIFIER.Value = CampaignID
            End If
            arParams(12) = paramCMP_IDENTIFIER

            Dim EST As New SqlParameter("@EST_NUM", SqlDbType.Int, 4)
            EST.Direction = ParameterDirection.Output
            arParams(13) = EST

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_AddEstimate", arParams)
                Return CStr(EST.Value)
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function AddNewEstimateComponent(ByVal EstNbr As Integer,
                                            ByVal CDPContact As String,
                                            ByVal EstCompDesc As String) As String
        Try
            Dim arParams(4) As SqlParameter

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramEST_NBR.Value = EstNbr
            arParams(0) = paramEST_NBR

            Dim paramEST_COMP_DESC As New SqlParameter("@EST_COMP_DESC", SqlDbType.VarChar)
            paramEST_COMP_DESC.Value = EstCompDesc
            arParams(1) = paramEST_COMP_DESC

            Dim paramCDP_CONTACT_ID As New SqlParameter("@CDP_CONTACT_ID", SqlDbType.Int)
            If CDPContact = "" Or CDPContact = "0" Then
                paramCDP_CONTACT_ID.Value = DBNull.Value
            Else
                paramCDP_CONTACT_ID.Value = CDPContact
            End If
            arParams(2) = paramCDP_CONTACT_ID

            Dim EST As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int, 4)
            EST.Direction = ParameterDirection.Output
            arParams(3) = EST

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_AddEstimateComponent", arParams)
                Return CStr(EST.Value)
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function UpdateJobEstimate(ByVal JobNum As Integer,
                                      ByVal JobCompNum As Integer,
                                      ByVal EstNum As Integer,
                                      ByVal EstCompNum As Integer) As String
        Try
            Dim arParams(4) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            If JobNum = 0 Then
                paramJOB_NUMBER.Value = DBNull.Value
            Else
                paramJOB_NUMBER.Value = JobNum
            End If
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            If JobCompNum = 0 Then
                paramJOB_COMPONENT_NBR.Value = DBNull.Value
            Else
                paramJOB_COMPONENT_NBR.Value = JobCompNum
            End If
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            If EstNum = 0 Then
                paramEST_NBR.Value = DBNull.Value
            Else
                paramEST_NBR.Value = EstNum
            End If
            arParams(2) = paramEST_NBR

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            If EstCompNum = 0 Then
                paramEST_COMPONENT_NBR.Value = DBNull.Value
            Else
                paramEST_COMPONENT_NBR.Value = EstCompNum
            End If
            arParams(3) = paramEST_COMPONENT_NBR

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_JobEstimate", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function GetAddNewFunctionData(ByVal FunctionCode As String) As DataTable
        Dim arP(1) As SqlParameter

        Dim pFunctionCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
        pFunctionCode.Value = FunctionCode
        arP(0) = pFunctionCode

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_GetFunctionData", "dtEstimateFunctionData", arP)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetDefaultFunctionData(ByVal FunctionCode As String, ByVal JobNum As Integer, ByVal JobCompNum As Integer,
                                           ByVal Client As String, ByVal Division As String, ByVal Product As String, ByVal SalesClass As String,
                                           ByVal EmpCode As String, Optional ByVal EmpTitleID As Integer = 0) As DataTable
        Dim arP(9) As SqlParameter

        Dim pFunctionCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
        pFunctionCode.Value = FunctionCode
        arP(0) = pFunctionCode

        Dim pJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        If JobNum = 0 Then
            pJobNum.Value = DBNull.Value
        Else
            pJobNum.Value = JobNum
        End If
        arP(1) = pJobNum

        Dim pJobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        If JobCompNum = 0 Then
            pJobCompNum.Value = DBNull.Value
        Else
            pJobCompNum.Value = JobCompNum
        End If
        arP(2) = pJobCompNum

        Dim pClient As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        pClient.Value = Client
        arP(3) = pClient

        Dim pDivision As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        pDivision.Value = Division
        arP(4) = pDivision

        Dim pProduct As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        pProduct.Value = Product
        arP(5) = pProduct

        Dim pSalesClass As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
        pSalesClass.Value = SalesClass
        arP(6) = pSalesClass

        Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        If EmpCode = "" Then
            pEmpCode.Value = DBNull.Value
        Else
            pEmpCode.Value = EmpCode
        End If
        arP(7) = pEmpCode

        Dim pEmpTitleID As New SqlParameter("@EMP_TITLE_ID", SqlDbType.Int)
        If EmpTitleID = 0 Then
            pEmpTitleID.Value = DBNull.Value
        Else
            pEmpTitleID.Value = EmpTitleID
        End If
        arP(8) = pEmpTitleID

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetUserFunctionDefault", "dtDefaultFunctionData", arP)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetAddNewTaxData(ByVal TaxCode As String) As DataTable
        Dim arP(1) As SqlParameter

        Dim pTaxCode As New SqlParameter("@TAX_CODE", SqlDbType.VarChar, 4)
        pTaxCode.Value = TaxCode
        arP(0) = pTaxCode

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_GetTaxData", "dtEstimateTaxData", arP)
        Catch ex As Exception

        End Try
    End Function

    Public Function AddNewFunction(ByVal EstNum As Integer, ByVal EstCompNum As Integer,
                                   ByVal QuoteNum As Integer, ByVal EstRevNum As Integer, ByVal SeqNbr As Integer,
                                   ByVal FncCode As String, ByVal MarkupPct As Decimal, ByVal ContingencyPct As Decimal, ByVal EstQtyHrs As Decimal,
                                   ByVal EstRate As Decimal, ByVal SuppliedBy As String, ByVal SuppliedNotes As String, ByVal ExtAmount As Decimal,
                                   ByVal TaxCode As String, ByVal FncComment As String, ByVal MarkupAmt As Decimal, ByVal ContingencyAmt As Decimal,
                                   ByVal LineTotal As Decimal, ByVal InclCPU As String, ByVal UserID As String, ByVal FncType As String,
                                   ByVal CPMFlag As Integer, ByVal TaxStatePct As Decimal, ByVal TaxCountyPct As Decimal, ByVal TaxCityPct As Decimal,
                                   ByVal TaxComm As Integer, ByVal TaxCommOnly As Integer, ByVal TaxResale As Integer, ByVal EstCommFlag As Integer,
                                   ByVal EstTaxFlag As Integer, ByVal EstNonbillFlag As Integer, ByVal ExtNonresaleTax As Decimal,
                                   ByVal ExtStateResale As Decimal, ByVal ExtCountyResale As Decimal, ByVal ExtCityResale As Decimal,
                                   ByVal ExtMuCont As Decimal, ByVal ExtStateCont As Decimal, ByVal ExtCountyCont As Decimal, ByVal ExtCityCont As Decimal,
                                   ByVal ExtNrCont As Decimal, ByVal LineTotalCont As Decimal, ByVal feetime As Integer, ByVal EmployeeTitleID As Integer) As String

        If EstNum > 0 And EstCompNum > 0 Then

            Dim arParams(45) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = EstNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = EstCompNum
            arParams(1) = paramTask_JobCompNum

            Dim pQuoteNum As SqlParameter = New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pQuoteNum.Value = QuoteNum
            arParams(2) = pQuoteNum

            Dim pEstRevNum As SqlParameter = New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            pEstRevNum.Value = EstRevNum
            arParams(3) = pEstRevNum

            Dim pFncCode As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            pFncCode.Value = FncCode
            arParams(4) = pFncCode

            Dim pSeqNbr As SqlParameter = New SqlParameter("@SEQ_NBR", SqlDbType.Int)
            pSeqNbr.Value = SeqNbr
            arParams(5) = pSeqNbr

            Dim pMarkupPct As SqlParameter = New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
            If MarkupPct = 0.0 Then
                pMarkupPct.Value = 0.0
            Else
                pMarkupPct.Value = MarkupPct
            End If
            arParams(6) = pMarkupPct

            Dim pContingencyPct As SqlParameter = New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
            If ContingencyPct = 0.0 Then
                pContingencyPct.Value = 0.0
            Else
                pContingencyPct.Value = ContingencyPct
            End If
            arParams(7) = pContingencyPct

            Dim pEstQtyHrs As SqlParameter = New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
            If EstQtyHrs = 0.0 Then
                pEstQtyHrs.Value = 0 'DBNull.Value
            Else
                pEstQtyHrs.Value = EstQtyHrs
            End If
            arParams(8) = pEstQtyHrs

            Dim pEstRate As SqlParameter = New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
            If EstRate = 0.0 Then
                pEstRate.Value = 0 'DBNull.Value
            Else
                pEstRate.Value = EstRate
            End If
            arParams(9) = pEstRate

            Dim pSuppliedBy As SqlParameter = New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
            If SuppliedBy = "" Then
                pSuppliedBy.Value = DBNull.Value
            Else
                pSuppliedBy.Value = SuppliedBy
            End If
            arParams(10) = pSuppliedBy

            Dim pSuppliedNotes As SqlParameter = New SqlParameter("@EST_REV_SUP_BY_NTE", SqlDbType.VarChar)
            If SuppliedNotes = "" Then
                pSuppliedNotes.Value = DBNull.Value
            Else
                pSuppliedNotes.Value = SuppliedNotes
            End If
            arParams(11) = pSuppliedNotes

            Dim pExtAmount As SqlParameter = New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
            If ExtAmount = 0.0 Then
                pExtAmount.Value = 0.0
            Else
                pExtAmount.Value = ExtAmount
            End If
            arParams(12) = pExtAmount

            Dim pTaxCode As SqlParameter = New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
            If TaxCode = "" Then
                pTaxCode.Value = DBNull.Value
            Else
                pTaxCode.Value = TaxCode
            End If
            arParams(13) = pTaxCode

            Dim pFncComment As SqlParameter = New SqlParameter("@EST_FNC_COMMENT", SqlDbType.Text)
            If FncComment = "" Then
                pFncComment.Value = DBNull.Value
            Else
                pFncComment.Value = FncComment
            End If
            arParams(14) = pFncComment


            Dim pMarkupAmt As SqlParameter = New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
            If MarkupAmt = 0.0 Then
                pMarkupAmt.Value = 0.0
            Else
                pMarkupAmt.Value = MarkupAmt
            End If
            arParams(15) = pMarkupAmt

            Dim pContingencyAmt As SqlParameter = New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
            If ContingencyAmt = 0.0 Then
                pContingencyAmt.Value = 0.0
            Else
                pContingencyAmt.Value = ContingencyAmt
            End If
            arParams(16) = pContingencyAmt

            Dim pLineTotal As SqlParameter = New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
            If LineTotal = 0.0 Then
                pLineTotal.Value = 0.0
            Else
                pLineTotal.Value = LineTotal
            End If
            arParams(17) = pLineTotal

            Dim pInclCPU As SqlParameter = New SqlParameter("@INCL_CPU", SqlDbType.SmallInt)
            pInclCPU.Value = InclCPU
            arParams(18) = pInclCPU

            Dim pUSER_ID As SqlParameter = New SqlParameter("@USER_ID", SqlDbType.VarChar)
            pUSER_ID.Value = UserID
            arParams(19) = pUSER_ID

            Dim pFNC_TYPE As SqlParameter = New SqlParameter("@EST_FNC_TYPE", SqlDbType.VarChar)
            pFNC_TYPE.Value = FncType
            arParams(20) = pFNC_TYPE

            Dim pEST_CPM_FLAG As SqlParameter = New SqlParameter("@EST_CPM_FLAG", SqlDbType.SmallInt)
            pEST_CPM_FLAG.Value = CPMFlag
            arParams(21) = pEST_CPM_FLAG

            Dim pTAX_STATE_PCT As SqlParameter = New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
            pTAX_STATE_PCT.Value = TaxStatePct
            arParams(22) = pTAX_STATE_PCT

            Dim pTAX_COUNTY_PCT As SqlParameter = New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
            pTAX_COUNTY_PCT.Value = TaxCountyPct
            arParams(23) = pTAX_COUNTY_PCT

            Dim pTAX_CITY_PCT As SqlParameter = New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
            pTAX_CITY_PCT.Value = TaxCityPct
            arParams(24) = pTAX_CITY_PCT

            Dim pTAX_COMM As SqlParameter = New SqlParameter("@TAX_COMM", SqlDbType.SmallInt)
            pTAX_COMM.Value = TaxComm
            arParams(25) = pTAX_COMM

            Dim pTAX_COMM_ONLY As SqlParameter = New SqlParameter("@TAX_COMM_ONLY", SqlDbType.SmallInt)
            pTAX_COMM_ONLY.Value = TaxCommOnly
            arParams(26) = pTAX_COMM_ONLY

            Dim pTAX_RESALE As SqlParameter = New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
            pTAX_RESALE.Value = TaxResale
            arParams(27) = pTAX_RESALE

            Dim pEST_COMM_FLAG As SqlParameter = New SqlParameter("@EST_COMM_FLAG", SqlDbType.SmallInt)
            pEST_COMM_FLAG.Value = EstCommFlag
            arParams(28) = pEST_COMM_FLAG

            Dim pEST_TAX_FLAG As SqlParameter = New SqlParameter("@EST_TAX_FLAG", SqlDbType.SmallInt)
            pEST_TAX_FLAG.Value = EstTaxFlag
            arParams(29) = pEST_TAX_FLAG

            Dim pEST_NONBILL_FLAG As SqlParameter = New SqlParameter("@EST_NONBILL_FLAG", SqlDbType.SmallInt)
            pEST_NONBILL_FLAG.Value = EstNonbillFlag
            arParams(30) = pEST_NONBILL_FLAG

            Dim pEXT_NONRESALE_TAX As SqlParameter = New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
            pEXT_NONRESALE_TAX.Value = ExtNonresaleTax
            arParams(31) = pEXT_NONRESALE_TAX

            Dim pEXT_STATE_RESALE As SqlParameter = New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
            pEXT_STATE_RESALE.Value = ExtStateResale
            arParams(32) = pEXT_STATE_RESALE

            Dim pEXT_COUNTY_RESALE As SqlParameter = New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
            pEXT_COUNTY_RESALE.Value = ExtCountyResale
            arParams(33) = pEXT_COUNTY_RESALE

            Dim pEXT_CITY_RESALE As SqlParameter = New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
            pEXT_CITY_RESALE.Value = ExtCityResale
            arParams(34) = pEXT_CITY_RESALE

            Dim pEXT_MU_CONT As SqlParameter = New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
            pEXT_MU_CONT.Value = ExtMuCont
            arParams(36) = pEXT_MU_CONT

            Dim pEXT_STATE_CONT As SqlParameter = New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
            pEXT_STATE_CONT.Value = ExtStateCont
            arParams(37) = pEXT_STATE_CONT

            Dim pEXT_COUNTY_CONT As SqlParameter = New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
            pEXT_COUNTY_CONT.Value = ExtCountyCont
            arParams(38) = pEXT_COUNTY_CONT

            Dim pEXT_CITY_CONT As SqlParameter = New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
            pEXT_CITY_CONT.Value = ExtCityCont
            arParams(39) = pEXT_CITY_CONT

            Dim pEXT_NR_CONT As SqlParameter = New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
            pEXT_NR_CONT.Value = ExtNrCont
            arParams(40) = pEXT_NR_CONT

            Dim pLINE_TOTAL_CONT As SqlParameter = New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
            pLINE_TOTAL_CONT.Value = LineTotalCont
            arParams(41) = pLINE_TOTAL_CONT

            Dim pEST_FEE_FLAG As SqlParameter = New SqlParameter("@FEE_TIME", SqlDbType.SmallInt)
            pEST_FEE_FLAG.Value = feetime
            arParams(42) = pEST_FEE_FLAG

            Dim pEmployeeTitleID As SqlParameter = New SqlParameter("@EMPLOYEE_TITLE_ID", SqlDbType.Int)
            If EmployeeTitleID = 0 Then
                pEmployeeTitleID.Value = DBNull.Value
            Else
                pEmployeeTitleID.Value = EmployeeTitleID
            End If
            arParams(44) = pEmployeeTitleID

            Dim i As String
            Try
                i = CStr(oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_AddFunction", arParams))
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try

        End If
    End Function

    Public Function UpdateEstimateInfo(ByVal EstNum As Integer,
                                      ByVal EstCompNum As Integer,
                                      ByVal EstCompComment As String,
                                      ByVal EstLogComment As String,
                                      ByVal CampaignID As Integer,
                                      ByVal SalesClass As String,
                                      ByVal MarkupPct As String,
                                      ByVal CDPContactID As Integer,
                                      ByVal EstLogDesc As String,
                                      ByVal EstCompDesc As String,
                                      ByVal EstFtrComment As String,
                                      ByVal EstLogCommentHtml As String,
                                      ByVal EstFtrCommentHtml As String,
                                      ByVal EstCompCommentHtml As String) As String
        Try
            Dim arParams(14) As SqlParameter

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramEST_NBR.Value = EstNum
            arParams(0) = paramEST_NBR

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNum
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_COMP_COMMENT As New SqlParameter("@EST_COMP_COMMENT", SqlDbType.Text)
            paramEST_COMP_COMMENT.Value = EstCompComment.Trim().Replace(vbLf, vbCrLf)
            arParams(2) = paramEST_COMP_COMMENT

            Dim paramEST_LOG_COMMENT As New SqlParameter("EST_LOG_COMMENT", SqlDbType.Text)
            paramEST_LOG_COMMENT.Value = EstLogComment.Trim().Replace(vbLf, vbCrLf)
            arParams(3) = paramEST_LOG_COMMENT

            Dim paramCMP_IDENIFIER As New SqlParameter("CMP_IDENTIFIER", SqlDbType.Int)
            If CampaignID = 0 Then
                paramCMP_IDENIFIER.Value = DBNull.Value
            Else
                paramCMP_IDENIFIER.Value = CampaignID
            End If
            arParams(4) = paramCMP_IDENIFIER

            Dim paramSALES_CLASS As New SqlParameter("@SC_CODE", SqlDbType.VarChar)
            paramSALES_CLASS.Value = SalesClass
            arParams(5) = paramSALES_CLASS

            Dim paramMARKUP_PCT As New SqlParameter("@MARKUP_PCT", SqlDbType.Decimal)
            If MarkupPct = "" Then
                paramMARKUP_PCT.Value = DBNull.Value
            Else
                paramMARKUP_PCT.Value = CDec(MarkupPct)
            End If
            arParams(6) = paramMARKUP_PCT

            Dim paramCDP_CONTACT_ID As New SqlParameter("CDP_CONTACT_ID", SqlDbType.Int)
            If CDPContactID = 0 Then
                paramCDP_CONTACT_ID.Value = DBNull.Value
            Else
                paramCDP_CONTACT_ID.Value = CDPContactID
            End If

            arParams(7) = paramCDP_CONTACT_ID

            Dim paramEST_LOG_DESC As New SqlParameter("@EST_LOG_DESC", SqlDbType.VarChar)
            paramEST_LOG_DESC.Value = EstLogDesc
            arParams(8) = paramEST_LOG_DESC

            Dim paramEST_COMP_DESC As New SqlParameter("@EST_COMP_DESC", SqlDbType.VarChar)
            paramEST_COMP_DESC.Value = EstCompDesc
            arParams(9) = paramEST_COMP_DESC

            Dim paramEST_FTR_COMMENT As New SqlParameter("EST_FTR_COMMENT", SqlDbType.Text)
            If EstFtrComment = "" Then
                paramEST_FTR_COMMENT.Value = DBNull.Value
            Else
                paramEST_FTR_COMMENT.Value = EstFtrComment
            End If
            arParams(10) = paramEST_FTR_COMMENT

            Dim paramEST_LOG_COMMENT_HTML As New SqlParameter("EST_LOG_COMMENT_HTML", SqlDbType.Text)
            If EstLogCommentHtml = "" Then
                paramEST_LOG_COMMENT_HTML.Value = DBNull.Value
            Else
                paramEST_LOG_COMMENT_HTML.Value = EstLogCommentHtml
            End If
            arParams(11) = paramEST_LOG_COMMENT_HTML

            Dim paramEST_FTR_COMMENT_HTML As New SqlParameter("EST_FTR_COMMENT_HTML", SqlDbType.Text)
            If EstFtrCommentHtml = "" Then
                paramEST_FTR_COMMENT_HTML.Value = DBNull.Value
            Else
                paramEST_FTR_COMMENT_HTML.Value = EstFtrCommentHtml
            End If
            arParams(12) = paramEST_FTR_COMMENT_HTML

            Dim paramEST_COMP_COMMENT_HTML As New SqlParameter("@EST_COMP_COMMENT_HTML", SqlDbType.Text)
            If EstCompCommentHtml = "" Then
                paramEST_COMP_COMMENT_HTML.Value = DBNull.Value
            Else
                paramEST_COMP_COMMENT_HTML.Value = EstCompCommentHtml
            End If
            arParams(13) = paramEST_COMP_COMMENT_HTML

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_EstimateInfo", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function CheckJobEstimateNumber(ByVal strEstNum As String) As Boolean

        Dim ireturn As Integer = 0
        Dim arparams(2) As SqlParameter

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = strEstNum
        arparams(0) = parameterEstNum

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CheckJobEstimateNum", arparams))
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:EstimatingCheckJobEstimateNumber", Err.Description)
        End Try

        If ireturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function JobComponentCount(ByVal EstNum As String) As Integer
        Dim SessionKey As String = "JobComponentCount" & EstNum.PadLeft(6, CChar("0"))
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arparams(1) As SqlParameter
            Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
            parameterEstNum.Value = EstNum
            arparams(0) = parameterEstNum
            Try
                ReturnInteger = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CheckJobNumEstimate", "DtData", arparams).Rows.Count
            Catch ex As Exception
                ReturnInteger = 0
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If

        Return ReturnInteger
    End Function

    Public Function CheckJobNumberEstimate1(ByVal strEstNum As String) As DataTable
        Dim arparams(1) As SqlParameter
        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = strEstNum
        arparams(0) = parameterEstNum
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CheckJobNumEstimate", "dtest", arparams)
        Catch
            Return Nothing
        End Try
    End Function

    Public Function CheckJobNumberEstimateDR(ByVal strEstNum As String) As SqlDataReader

        Dim dr As SqlDataReader
        Dim arparams(2) As SqlParameter

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = strEstNum
        arparams(0) = parameterEstNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CheckJobNumEstimate", arparams)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:EstimatingCheckJobNumberEstimate", Err.Description)
        End Try

        Return dr

    End Function

    Public Function GetEstimateNumJob(ByVal strJobNum As String) As SqlDataReader

        Dim dr As SqlDataReader
        Dim arparams(2) As SqlParameter

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = strJobNum
        arparams(0) = parameterJobNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetEstimateNumJob", arparams)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:EstimatingCheckEstimateNumJob", Err.Description)
        End Try

        Return dr

    End Function

    Public Function CheckJobEstimateCompNumber(ByVal strEstNum As String, ByVal strEstComp As String) As Boolean

        Dim ireturn As Integer = 0
        Dim arparams(2) As SqlParameter

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = strEstNum
        arparams(0) = parameterEstNum

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = strEstComp
        arparams(1) = parameterEstComp

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_CheckJobEstimateCompNum", arparams))
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:EstimatingCheckJobEstimateCompNumber", Err.Description)
        End Try

        If ireturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetEstJob(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As SqlDataReader
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim dr As SqlDataReader

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetEstJob", arParams)

            Return dr

        Catch ex As Exception
            'Return -999
        End Try
    End Function

    Public Function GetContactCodeID(ByVal ContactCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Integer
        Dim arParams(4) As SqlParameter
        Dim i As Integer = 0

        Dim parameterContactCode As New SqlParameter("@ContactCode", SqlDbType.VarChar, 6)
        parameterContactCode.Value = ContactCode.Trim
        arParams(0) = parameterContactCode
        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode
        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode
        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Try
            i = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_getContactCodeID", arParams))
            Return i
        Catch
            Return 0
        End Try

    End Function

    Public Function GetBaseJobAndCompInfoDT(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        If JobNum > 0 And JobCompNum > 0 Then
            Dim arParams(2) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = JobNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = JobCompNum
            arParams(1) = paramTask_JobCompNum

            Try
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_AddNew_GetBaseJobAndCompInfo", "DtJobDetails", arParams)
            Catch ex As Exception

            End Try

        End If
    End Function

    Public Function GetEstimatesForSearch(ByVal user As String,
                                           ByVal client As String,
                                           ByVal division As String,
                                           ByVal product As String,
                                           ByVal est As Integer,
                                           ByVal estcomp As Integer,
                                           ByVal job As Integer,
                                           ByVal jobcomp As Integer,
                                           ByVal campaign As String,
                                           ByVal ShowAll As Boolean) As DataSet
        Try
            Dim arParams(12) As SqlParameter
            Dim dr As DataSet

            Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUser.Value = user
            arParams(0) = paramUser
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(1) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = division
            arParams(2) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = product
            arParams(3) = paramProduct
            Dim paramEst As New SqlParameter("@EstNum", SqlDbType.Int)
            paramEst.Value = est
            arParams(4) = paramEst
            Dim paramEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
            paramEstComp.Value = estcomp
            arParams(5) = paramEstComp
            Dim paramJob As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJob.Value = job
            arParams(6) = paramJob
            Dim paramJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
            paramJobComp.Value = jobcomp
            arParams(7) = paramJobComp

            Dim paramShowAll As New SqlParameter("@ShowAll", SqlDbType.Bit)
            paramShowAll.Value = ShowAll
            arParams(8) = paramShowAll
            Dim paramCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar)
            paramCampaign.Value = campaign
            arParams(9) = paramCampaign

            Dim paramOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
            paramOfficeCode.Value = ""
            arParams(10) = paramOfficeCode

            Dim paramSalesClassCode As New SqlParameter("@SalesClassCode", SqlDbType.VarChar)
            paramSalesClassCode.Value = ""
            arParams(11) = paramSalesClassCode

            'If withclosed = True Then
            '    dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetAllJobswithClosed", arParams)
            'Else
            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetAllEstimates", arParams)
            'END If
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error Getestimates!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function UpdateEstimateComments(ByVal EstNum As Integer,
                                      ByVal EstCompNum As Integer,
                                      ByVal EstCompComment As String,
                                      ByVal EstLogComment As String) As String
        Try
            Dim arParams(4) As SqlParameter

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramEST_NBR.Value = EstNum
            arParams(0) = paramEST_NBR

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNum
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_COMP_COMMENT As New SqlParameter("@EST_COMP_COMMENT", SqlDbType.Text)
            paramEST_COMP_COMMENT.Value = EstCompComment
            arParams(2) = paramEST_COMP_COMMENT

            Dim paramEST_LOG_COMMENT As New SqlParameter("@EST_LOG_COMMENT", SqlDbType.Text)
            paramEST_LOG_COMMENT.Value = EstLogComment
            arParams(3) = paramEST_LOG_COMMENT

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_EstimateComments", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function UpdateEstimateCommentsQuote(ByVal EstNum As Integer,
                                      ByVal EstCompNum As Integer,
                                      ByVal QuoteNbr As Integer,
                                      ByVal EstQuoteComment As String,
                                      ByVal EstRevNbr As Integer,
                                      ByVal EstRevComment As String) As String
        Try
            Dim arParams(6) As SqlParameter

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramEST_NBR.Value = EstNum
            arParams(0) = paramEST_NBR

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNum
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramEST_QTE_COMMENT As New SqlParameter("@EST_QTE_COMMENT", SqlDbType.Text)
            paramEST_QTE_COMMENT.Value = EstQuoteComment
            arParams(4) = paramEST_QTE_COMMENT

            Dim paramEST_REV_COMMENT As New SqlParameter("@EST_REV_COMMENT", SqlDbType.Text)
            paramEST_REV_COMMENT.Value = EstRevComment
            arParams(5) = paramEST_REV_COMMENT

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_EstimateCommentsQuote", arParams)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

#End Region

#Region " Estimate Print "

    Public Function SavePrintDef(ByVal UserID As String,
                                   ByVal SelectBy As String,
                                   ByVal DateToPrint As Integer,
                                   ByVal TaxSeparate As Integer,
                                   ByVal TaxIndicator As Integer,
                                   ByVal CommMuSeparate As Integer,
                                   ByVal CommMuIndicator As Integer,
                                   ByVal FunctionOption As String,
                                   ByVal GroupOption As String,
                                   ByVal SortOption As String,
                                   ByVal InsideChgDesc As String,
                                   ByVal OutsideChgDesc As String,
                                   ByVal EstComment As Integer,
                                   ByVal EstCompComment As Integer,
                                   ByVal QteComment As Integer,
                                   ByVal RevComment As Integer,
                                   ByVal FuncComment As Integer,
                                   ByVal DefFooterComment As Integer,
                                   ByVal CliRef As Integer,
                                   ByVal AEName As Integer,
                                   ByVal PrtSalesClass As Integer,
                                   ByVal Specs As Integer,
                                   ByVal JobQty As Integer,
                                   ByVal Contingency As Integer,
                                   ByVal SuppressZero As Integer,
                                   ByVal LocationID As String,
                                   ByVal LogoPath As String,
                                   ByVal ReportFormat As String,
                                   ByVal PrtNonbill As Integer,
                                   ByVal PrtDivName As Integer,
                                   ByVal PrtPrdName As Integer,
                                   ByVal QtyHrs As Integer,
                                   ByVal ConsolOverride As Integer,
                                   ByVal SubtotOnly As Integer,
                                   ByVal PrtCPU As Integer,
                                   ByVal PrtCPM As Integer,
                                   ByVal RptTitle As String,
                                   ByVal SupByNotes As Integer,
                                   ByVal ContSeparate As Integer,
                                   ByVal Signature As Integer,
                                   ByVal HideCompDesc As Integer,
                                   ByVal HideRevision As Integer,
                                   ByVal JobDueDate As Integer,
                                   ByVal UseEmpSig As Integer,
                                   ByVal ExclEmpTime As Integer,
                                   ByVal ExclVendor As Integer,
                                   ByVal ExclIO As Integer,
                                   ByVal ExclSignature As Integer,
                                   ByVal CmpSummary As Integer,
                                   ByVal VendorDesc As Integer,
                                   ByVal ExclNonbillable As Integer,
                                   Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim arParams(50) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(0) = paramUserID

            Dim paramSELECT_BY As New SqlParameter("@SELECT_BY", SqlDbType.VarChar)
            paramSELECT_BY.Value = SelectBy
            arParams(1) = paramSELECT_BY

            Dim paramDATE_TO_PRINT As New SqlParameter("@DATE_TO_PRINT", SqlDbType.SmallInt)
            paramDATE_TO_PRINT.Value = DateToPrint
            arParams(2) = paramDATE_TO_PRINT

            Dim paramTAX_SEPARATE As New SqlParameter("@TAX_SEPARATE", SqlDbType.SmallInt)
            paramTAX_SEPARATE.Value = TaxSeparate
            arParams(3) = paramTAX_SEPARATE

            Dim paramTAX_INDICATOR As New SqlParameter("@TAX_INDICATOR", SqlDbType.SmallInt)
            paramTAX_INDICATOR.Value = TaxIndicator
            arParams(4) = paramTAX_INDICATOR

            Dim paramCOMM_MU_SEPARATE As New SqlParameter("@COMM_MU_SEPARATE", SqlDbType.SmallInt)
            paramCOMM_MU_SEPARATE.Value = CommMuSeparate
            arParams(5) = paramCOMM_MU_SEPARATE

            Dim paramCOMM_MU_INDICATOR As New SqlParameter("@COMM_MU_INDICATOR", SqlDbType.SmallInt)
            paramCOMM_MU_INDICATOR.Value = CommMuIndicator
            arParams(6) = paramCOMM_MU_INDICATOR

            Dim paramFUNCTION_OPTION As New SqlParameter("@FUNCTION_OPTION", SqlDbType.VarChar)
            paramFUNCTION_OPTION.Value = FunctionOption
            arParams(7) = paramFUNCTION_OPTION

            Dim paramGROUP_OPTION As New SqlParameter("@GROUP_OPTION", SqlDbType.VarChar)
            paramGROUP_OPTION.Value = GroupOption
            arParams(8) = paramGROUP_OPTION

            Dim paramSORT_OPTION As New SqlParameter("@SORT_OPTION", SqlDbType.VarChar)
            paramSORT_OPTION.Value = SortOption
            arParams(9) = paramSORT_OPTION

            Dim paramINSIDE_CHG_DESC As New SqlParameter("@INSIDE_CHG_DESC", SqlDbType.VarChar)
            paramINSIDE_CHG_DESC.Value = InsideChgDesc
            arParams(10) = paramINSIDE_CHG_DESC

            Dim paramOUTSIDE_CHG_DESC As New SqlParameter("@OUTSIDE_CHG_DESC", SqlDbType.VarChar)
            paramOUTSIDE_CHG_DESC.Value = OutsideChgDesc
            arParams(11) = paramOUTSIDE_CHG_DESC

            Dim paramEST_COMMENT As New SqlParameter("@EST_COMMENT", SqlDbType.SmallInt)
            paramEST_COMMENT.Value = EstComment
            arParams(12) = paramEST_COMMENT

            Dim paramEST_COMP_COMMENT As New SqlParameter("@EST_COMP_COMMENT", SqlDbType.SmallInt)
            paramEST_COMP_COMMENT.Value = EstCompComment
            arParams(13) = paramEST_COMP_COMMENT

            Dim paramQTE_COMMENT As New SqlParameter("@QTE_COMMENT", SqlDbType.SmallInt)
            paramQTE_COMMENT.Value = QteComment
            arParams(14) = paramQTE_COMMENT

            Dim paramREV_COMMENT As New SqlParameter("@REV_COMMENT", SqlDbType.SmallInt)
            paramREV_COMMENT.Value = RevComment
            arParams(15) = paramREV_COMMENT

            Dim paramFUNC_COMMENT As New SqlParameter("@FUNC_COMMENT", SqlDbType.SmallInt)
            paramFUNC_COMMENT.Value = FuncComment
            arParams(16) = paramFUNC_COMMENT

            Dim paramDEF_FOOTER_COMMENT As New SqlParameter("@DEF_FOOTER_COMMENT", SqlDbType.SmallInt)
            paramDEF_FOOTER_COMMENT.Value = DefFooterComment
            arParams(17) = paramDEF_FOOTER_COMMENT

            Dim paramCLI_REF As New SqlParameter("@CLI_REF", SqlDbType.SmallInt)
            paramCLI_REF.Value = CliRef
            arParams(18) = paramCLI_REF

            Dim paramAE_NAME As New SqlParameter("@AE_NAME", SqlDbType.SmallInt)
            paramAE_NAME.Value = AEName
            arParams(19) = paramAE_NAME

            Dim paramPRT_SALES_CLASS As New SqlParameter("@PRT_SALES_CLASS", SqlDbType.SmallInt)
            paramPRT_SALES_CLASS.Value = PrtSalesClass
            arParams(20) = paramPRT_SALES_CLASS

            Dim paramSPECS As New SqlParameter("@SPECS", SqlDbType.SmallInt)
            paramSPECS.Value = Specs
            arParams(21) = paramSPECS

            Dim paramJOB_QTY As New SqlParameter("@JOB_QTY", SqlDbType.SmallInt)
            paramJOB_QTY.Value = JobQty
            arParams(22) = paramJOB_QTY

            Dim paramCONTINGENCY As New SqlParameter("@CONTINGENCY", SqlDbType.SmallInt)
            paramCONTINGENCY.Value = Contingency
            arParams(23) = paramCONTINGENCY

            Dim paramSUPPRESS_ZERO As New SqlParameter("@SUPPRESS_ZERO", SqlDbType.SmallInt)
            paramSUPPRESS_ZERO.Value = SuppressZero
            arParams(24) = paramSUPPRESS_ZERO

            Dim paramLOCATION_ID As New SqlParameter("@LOCATION_ID", SqlDbType.VarChar)
            paramLOCATION_ID.Value = LocationID
            arParams(25) = paramLOCATION_ID

            Dim paramLOGO_PATH As New SqlParameter("@LOGO_PATH", SqlDbType.VarChar)
            paramLOGO_PATH.Value = LogoPath
            arParams(26) = paramLOGO_PATH

            Dim paramREPORT_FORMAT As New SqlParameter("@REPORT_FORMAT", SqlDbType.VarChar)
            paramREPORT_FORMAT.Value = ReportFormat
            arParams(27) = paramREPORT_FORMAT

            Dim paramPRT_NONBILL As New SqlParameter("@PRT_NONBILL", SqlDbType.SmallInt)
            paramPRT_NONBILL.Value = PrtNonbill
            arParams(28) = paramPRT_NONBILL

            Dim paramPRT_DIV_NAME As New SqlParameter("@PRT_DIV_NAME", SqlDbType.SmallInt)
            paramPRT_DIV_NAME.Value = PrtDivName
            arParams(29) = paramPRT_DIV_NAME

            Dim paramPRT_PRD_NAME As New SqlParameter("@PRT_PRD_NAME", SqlDbType.SmallInt)
            paramPRT_PRD_NAME.Value = PrtPrdName
            arParams(30) = paramPRT_PRD_NAME

            Dim paramQTY_HRS As New SqlParameter("@QTY_HRS", SqlDbType.SmallInt)
            paramQTY_HRS.Value = QtyHrs
            arParams(31) = paramQTY_HRS

            Dim paramCONSOL_OVERRIDE As New SqlParameter("@CONSOL_OVERRIDE", SqlDbType.SmallInt)
            paramCONSOL_OVERRIDE.Value = ConsolOverride
            arParams(32) = paramCONSOL_OVERRIDE

            Dim paramSUBTOT_ONLY As New SqlParameter("@SUBTOT_ONLY", SqlDbType.SmallInt)
            paramSUBTOT_ONLY.Value = SubtotOnly
            arParams(33) = paramSUBTOT_ONLY

            Dim paramPRT_CPU As New SqlParameter("@PRT_CPU", SqlDbType.SmallInt)
            paramPRT_CPU.Value = PrtCPU
            arParams(34) = paramPRT_CPU

            Dim paramPRT_CPM As New SqlParameter("@PRT_CPM", SqlDbType.SmallInt)
            paramPRT_CPM.Value = PrtCPM
            arParams(35) = paramPRT_CPM

            Dim paramRPT_TITLE As New SqlParameter("@RPT_TITLE", SqlDbType.VarChar)
            paramRPT_TITLE.Value = RptTitle
            arParams(36) = paramRPT_TITLE

            Dim paramSUP_BY_NOTES As New SqlParameter("@SUP_BY_NOTES", SqlDbType.SmallInt)
            paramSUP_BY_NOTES.Value = SupByNotes
            arParams(37) = paramSUP_BY_NOTES

            Dim paramCONT_SEPARATE As New SqlParameter("@CONT_SEPARATE", SqlDbType.SmallInt)
            paramCONT_SEPARATE.Value = ContSeparate
            arParams(38) = paramCONT_SEPARATE

            Dim paramSIGNATURE As New SqlParameter("@SIGNATURE", SqlDbType.SmallInt)
            paramSIGNATURE.Value = Signature
            arParams(39) = paramSIGNATURE

            Dim paramHIDE_COMP_DESC As New SqlParameter("@HIDE_COMP_DESC", SqlDbType.SmallInt)
            paramHIDE_COMP_DESC.Value = HideCompDesc
            arParams(40) = paramHIDE_COMP_DESC

            Dim paramHIDE_REVISION As New SqlParameter("@HIDE_REVISION", SqlDbType.SmallInt)
            paramHIDE_REVISION.Value = HideRevision
            arParams(41) = paramHIDE_REVISION

            Dim paramJOB_DUE_DATE As New SqlParameter("@JOB_DUE_DATE", SqlDbType.SmallInt)
            paramJOB_DUE_DATE.Value = JobDueDate
            arParams(42) = paramJOB_DUE_DATE

            Dim paramUSE_EMP_SIG As New SqlParameter("@USE_EMP_SIG", SqlDbType.SmallInt)
            paramUSE_EMP_SIG.Value = UseEmpSig
            arParams(43) = paramUSE_EMP_SIG

            Dim paramEXCL_EMP_TIME As New SqlParameter("@EXCL_EMP_TIME", SqlDbType.SmallInt)
            paramEXCL_EMP_TIME.Value = ExclEmpTime
            arParams(44) = paramEXCL_EMP_TIME

            Dim paramEXCL_VENDOR As New SqlParameter("@EXCL_VENDOR", SqlDbType.SmallInt)
            paramEXCL_VENDOR.Value = ExclVendor
            arParams(45) = paramEXCL_VENDOR

            Dim paramEXCL_IO As New SqlParameter("@EXCL_IO", SqlDbType.SmallInt)
            paramEXCL_IO.Value = ExclIO
            arParams(46) = paramEXCL_IO

            Dim paramEXCL_SIGNATURE As New SqlParameter("@EXCL_SIGNATURE", SqlDbType.SmallInt)
            paramEXCL_SIGNATURE.Value = ExclSignature
            arParams(47) = paramEXCL_SIGNATURE

            Dim paramCMP_SUMMARY As New SqlParameter("@CMP_SUMMARY", SqlDbType.SmallInt)
            paramCMP_SUMMARY.Value = CmpSummary
            arParams(48) = paramCMP_SUMMARY

            Dim paramVENDOR_DESC As New SqlParameter("@VENDOR_DESC", SqlDbType.SmallInt)
            paramVENDOR_DESC.Value = VendorDesc
            arParams(49) = paramVENDOR_DESC

            Dim paramEXCL_NB As New SqlParameter("@EXCL_NONBILL", SqlDbType.SmallInt)
            paramEXCL_NB.Value = ExclNonbillable
            arParams(50) = paramEXCL_NB

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Save_PrintDef", arParams)
                Return True
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdatePrintDef(ByVal UserID As String,
                                   ByVal SelectBy As String,
                                   ByVal DateToPrint As Integer,
                                   ByVal TaxSeparate As Integer,
                                   ByVal TaxIndicator As Integer,
                                   ByVal CommMuSeparate As Integer,
                                   ByVal CommMuIndicator As Integer,
                                   ByVal FunctionOption As String,
                                   ByVal GroupOption As String,
                                   ByVal SortOption As String,
                                   ByVal InsideChgDesc As String,
                                   ByVal OutsideChgDesc As String,
                                   ByVal EstComment As Integer,
                                   ByVal EstCompComment As Integer,
                                   ByVal QteComment As Integer,
                                   ByVal RevComment As Integer,
                                   ByVal FuncComment As Integer,
                                   ByVal DefFooterComment As Integer,
                                   ByVal CliRef As Integer,
                                   ByVal AEName As Integer,
                                   ByVal PrtSalesClass As Integer,
                                   ByVal Specs As Integer,
                                   ByVal JobQty As Integer,
                                   ByVal Contingency As Integer,
                                   ByVal SuppressZero As Integer,
                                   ByVal LocationID As String,
                                   ByVal LogoPath As String,
                                   ByVal ReportFormat As String,
                                   ByVal PrtNonbill As Integer,
                                   ByVal PrtDivName As Integer,
                                   ByVal PrtPrdName As Integer,
                                   ByVal QtyHrs As Integer,
                                   ByVal ConsolOverride As Integer,
                                   ByVal SubtotOnly As Integer,
                                   ByVal PrtCPU As Integer,
                                   ByVal PrtCPM As Integer,
                                   ByVal RptTitle As String,
                                   ByVal SupByNotes As Integer,
                                   ByVal ContSeparate As Integer,
                                   ByVal Signature As Integer,
                                   ByVal HideCompDesc As Integer,
                                   ByVal HideRevision As Integer,
                                   ByVal JobDueDate As Integer,
                                   ByVal UseEmpSig As Integer,
                                   ByVal ExclEmpTime As Integer,
                                   ByVal ExclVendor As Integer,
                                   ByVal ExclIO As Integer,
                                   ByVal ExclSignature As Integer,
                                   ByVal CmpSummary As Integer,
                                   ByVal VendorDesc As Integer,
                                   ByVal ExclNonbillable As Integer,
                                   Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim arParams(50) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(0) = paramUserID

            Dim paramSELECT_BY As New SqlParameter("@SELECT_BY", SqlDbType.VarChar)
            paramSELECT_BY.Value = SelectBy
            arParams(1) = paramSELECT_BY

            Dim paramDATE_TO_PRINT As New SqlParameter("@DATE_TO_PRINT", SqlDbType.SmallInt)
            paramDATE_TO_PRINT.Value = DateToPrint
            arParams(2) = paramDATE_TO_PRINT

            Dim paramTAX_SEPARATE As New SqlParameter("@TAX_SEPARATE", SqlDbType.SmallInt)
            paramTAX_SEPARATE.Value = TaxSeparate
            arParams(3) = paramTAX_SEPARATE

            Dim paramTAX_INDICATOR As New SqlParameter("@TAX_INDICATOR", SqlDbType.SmallInt)
            paramTAX_INDICATOR.Value = TaxIndicator
            arParams(4) = paramTAX_INDICATOR

            Dim paramCOMM_MU_SEPARATE As New SqlParameter("@COMM_MU_SEPARATE", SqlDbType.SmallInt)
            paramCOMM_MU_SEPARATE.Value = CommMuSeparate
            arParams(5) = paramCOMM_MU_SEPARATE

            Dim paramCOMM_MU_INDICATOR As New SqlParameter("@COMM_MU_INDICATOR", SqlDbType.SmallInt)
            paramCOMM_MU_INDICATOR.Value = CommMuIndicator
            arParams(6) = paramCOMM_MU_INDICATOR

            Dim paramFUNCTION_OPTION As New SqlParameter("@FUNCTION_OPTION", SqlDbType.VarChar)
            paramFUNCTION_OPTION.Value = FunctionOption
            arParams(7) = paramFUNCTION_OPTION

            Dim paramGROUP_OPTION As New SqlParameter("@GROUP_OPTION", SqlDbType.VarChar)
            paramGROUP_OPTION.Value = GroupOption
            arParams(8) = paramGROUP_OPTION

            Dim paramSORT_OPTION As New SqlParameter("@SORT_OPTION", SqlDbType.VarChar)
            paramSORT_OPTION.Value = SortOption
            arParams(9) = paramSORT_OPTION

            Dim paramINSIDE_CHG_DESC As New SqlParameter("@INSIDE_CHG_DESC", SqlDbType.VarChar)
            paramINSIDE_CHG_DESC.Value = InsideChgDesc
            arParams(10) = paramINSIDE_CHG_DESC

            Dim paramOUTSIDE_CHG_DESC As New SqlParameter("@OUTSIDE_CHG_DESC", SqlDbType.VarChar)
            paramOUTSIDE_CHG_DESC.Value = OutsideChgDesc
            arParams(11) = paramOUTSIDE_CHG_DESC

            Dim paramEST_COMMENT As New SqlParameter("@EST_COMMENT", SqlDbType.SmallInt)
            paramEST_COMMENT.Value = EstComment
            arParams(12) = paramEST_COMMENT

            Dim paramEST_COMP_COMMENT As New SqlParameter("@EST_COMP_COMMENT", SqlDbType.SmallInt)
            paramEST_COMP_COMMENT.Value = EstCompComment
            arParams(13) = paramEST_COMP_COMMENT

            Dim paramQTE_COMMENT As New SqlParameter("@QTE_COMMENT", SqlDbType.SmallInt)
            paramQTE_COMMENT.Value = QteComment
            arParams(14) = paramQTE_COMMENT

            Dim paramREV_COMMENT As New SqlParameter("@REV_COMMENT", SqlDbType.SmallInt)
            paramREV_COMMENT.Value = RevComment
            arParams(15) = paramREV_COMMENT

            Dim paramFUNC_COMMENT As New SqlParameter("@FUNC_COMMENT", SqlDbType.SmallInt)
            paramFUNC_COMMENT.Value = FuncComment
            arParams(16) = paramFUNC_COMMENT

            Dim paramDEF_FOOTER_COMMENT As New SqlParameter("@DEF_FOOTER_COMMENT", SqlDbType.SmallInt)
            paramDEF_FOOTER_COMMENT.Value = DefFooterComment
            arParams(17) = paramDEF_FOOTER_COMMENT

            Dim paramCLI_REF As New SqlParameter("@CLI_REF", SqlDbType.SmallInt)
            paramCLI_REF.Value = CliRef
            arParams(18) = paramCLI_REF

            Dim paramAE_NAME As New SqlParameter("@AE_NAME", SqlDbType.SmallInt)
            paramAE_NAME.Value = AEName
            arParams(19) = paramAE_NAME

            Dim paramPRT_SALES_CLASS As New SqlParameter("@PRT_SALES_CLASS", SqlDbType.SmallInt)
            paramPRT_SALES_CLASS.Value = PrtSalesClass
            arParams(20) = paramPRT_SALES_CLASS

            Dim paramSPECS As New SqlParameter("@SPECS", SqlDbType.SmallInt)
            paramSPECS.Value = Specs
            arParams(21) = paramSPECS

            Dim paramJOB_QTY As New SqlParameter("@JOB_QTY", SqlDbType.SmallInt)
            paramJOB_QTY.Value = JobQty
            arParams(22) = paramJOB_QTY

            Dim paramCONTINGENCY As New SqlParameter("@CONTINGENCY", SqlDbType.SmallInt)
            paramCONTINGENCY.Value = Contingency
            arParams(23) = paramCONTINGENCY

            Dim paramSUPPRESS_ZERO As New SqlParameter("@SUPPRESS_ZERO", SqlDbType.SmallInt)
            paramSUPPRESS_ZERO.Value = SuppressZero
            arParams(24) = paramSUPPRESS_ZERO

            Dim paramLOCATION_ID As New SqlParameter("@LOCATION_ID", SqlDbType.VarChar)
            paramLOCATION_ID.Value = LocationID
            arParams(25) = paramLOCATION_ID

            Dim paramLOGO_PATH As New SqlParameter("@LOGO_PATH", SqlDbType.VarChar)
            paramLOGO_PATH.Value = LogoPath
            arParams(26) = paramLOGO_PATH

            Dim paramREPORT_FORMAT As New SqlParameter("@REPORT_FORMAT", SqlDbType.VarChar)
            paramREPORT_FORMAT.Value = ReportFormat
            arParams(27) = paramREPORT_FORMAT

            Dim paramPRT_NONBILL As New SqlParameter("@PRT_NONBILL", SqlDbType.SmallInt)
            paramPRT_NONBILL.Value = PrtNonbill
            arParams(28) = paramPRT_NONBILL

            Dim paramPRT_DIV_NAME As New SqlParameter("@PRT_DIV_NAME", SqlDbType.SmallInt)
            paramPRT_DIV_NAME.Value = PrtDivName
            arParams(29) = paramPRT_DIV_NAME

            Dim paramPRT_PRD_NAME As New SqlParameter("@PRT_PRD_NAME", SqlDbType.SmallInt)
            paramPRT_PRD_NAME.Value = PrtPrdName
            arParams(30) = paramPRT_PRD_NAME

            Dim paramQTY_HRS As New SqlParameter("@QTY_HRS", SqlDbType.SmallInt)
            paramQTY_HRS.Value = QtyHrs
            arParams(31) = paramQTY_HRS

            Dim paramCONSOL_OVERRIDE As New SqlParameter("@CONSOL_OVERRIDE", SqlDbType.SmallInt)
            paramCONSOL_OVERRIDE.Value = ConsolOverride
            arParams(32) = paramCONSOL_OVERRIDE

            Dim paramSUBTOT_ONLY As New SqlParameter("@SUBTOT_ONLY", SqlDbType.SmallInt)
            paramSUBTOT_ONLY.Value = SubtotOnly
            arParams(33) = paramSUBTOT_ONLY

            Dim paramPRT_CPU As New SqlParameter("@PRT_CPU", SqlDbType.SmallInt)
            paramPRT_CPU.Value = PrtCPU
            arParams(34) = paramPRT_CPU

            Dim paramPRT_CPM As New SqlParameter("@PRT_CPM", SqlDbType.SmallInt)
            paramPRT_CPM.Value = PrtCPM
            arParams(35) = paramPRT_CPM

            Dim paramRPT_TITLE As New SqlParameter("@RPT_TITLE", SqlDbType.VarChar)
            paramRPT_TITLE.Value = RptTitle
            arParams(36) = paramRPT_TITLE

            Dim paramSUP_BY_NOTES As New SqlParameter("@SUP_BY_NOTES", SqlDbType.SmallInt)
            paramSUP_BY_NOTES.Value = SupByNotes
            arParams(37) = paramSUP_BY_NOTES

            Dim paramCONT_SEPARATE As New SqlParameter("@CONT_SEPARATE", SqlDbType.SmallInt)
            paramCONT_SEPARATE.Value = ContSeparate
            arParams(38) = paramCONT_SEPARATE

            Dim paramSIGNATURE As New SqlParameter("@SIGNATURE", SqlDbType.SmallInt)
            paramSIGNATURE.Value = Signature
            arParams(39) = paramSIGNATURE

            Dim paramHIDE_COMP_DESC As New SqlParameter("@HIDE_COMP_DESC", SqlDbType.SmallInt)
            paramHIDE_COMP_DESC.Value = HideCompDesc
            arParams(40) = paramHIDE_COMP_DESC

            Dim paramHIDE_REVISION As New SqlParameter("@HIDE_REVISION", SqlDbType.SmallInt)
            paramHIDE_REVISION.Value = HideRevision
            arParams(41) = paramHIDE_REVISION

            Dim paramJOB_DUE_DATE As New SqlParameter("@JOB_DUE_DATE", SqlDbType.SmallInt)
            paramJOB_DUE_DATE.Value = JobDueDate
            arParams(42) = paramJOB_DUE_DATE

            Dim paramUSE_EMP_SIG As New SqlParameter("@USE_EMP_SIG", SqlDbType.SmallInt)
            paramUSE_EMP_SIG.Value = UseEmpSig
            arParams(43) = paramUSE_EMP_SIG

            Dim paramEXCL_EMP_TIME As New SqlParameter("@EXCL_EMP_TIME", SqlDbType.SmallInt)
            paramEXCL_EMP_TIME.Value = ExclEmpTime
            arParams(44) = paramEXCL_EMP_TIME

            Dim paramEXCL_VENDOR As New SqlParameter("@EXCL_VENDOR", SqlDbType.SmallInt)
            paramEXCL_VENDOR.Value = ExclVendor
            arParams(45) = paramEXCL_VENDOR

            Dim paramEXCL_IO As New SqlParameter("@EXCL_IO", SqlDbType.SmallInt)
            paramEXCL_IO.Value = ExclIO
            arParams(46) = paramEXCL_IO

            Dim paramEXCL_SIGNATURE As New SqlParameter("@EXCL_SIGNATURE", SqlDbType.SmallInt)
            paramEXCL_SIGNATURE.Value = ExclSignature
            arParams(47) = paramEXCL_SIGNATURE

            Dim paramCMP_SUMMARY As New SqlParameter("@CMP_SUMMARY", SqlDbType.SmallInt)
            paramCMP_SUMMARY.Value = CmpSummary
            arParams(48) = paramCMP_SUMMARY

            Dim paramVENDOR_DESC As New SqlParameter("@VENDOR_DESC", SqlDbType.SmallInt)
            paramVENDOR_DESC.Value = VendorDesc
            arParams(49) = paramVENDOR_DESC

            Dim paramEXCL_NB As New SqlParameter("@EXCL_NONBILL", SqlDbType.SmallInt)
            paramEXCL_NB.Value = ExclNonbillable
            arParams(50) = paramEXCL_NB


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Update_PrintDef", arParams)
                Return True
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetPrintDef(ByVal UserID As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(1) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(0) = paramUserID

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_PrintDef", arParams)
                Return dr
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetPrintDefDT(ByVal UserID As String) As DataTable
        Try
            Dim dt As DataTable
            Dim arParams(1) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(0) = paramUserID

            Try
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_PrintDef", "dtPrint", arParams)
                Return dt
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function getPrintDetails(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String) As DataTable
        Try
            'Get the real data
            Dim arParams(3) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(3) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsDS(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String) As DataSet
        Try
            'Get the real data
            Dim arParams(3) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(3) = paramUserID

            Dim DtRealData As New DataSet
            DtRealData = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsCombined(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal groupby As String) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            Dim parameterGroupBy As New SqlParameter("@Groupby", SqlDbType.VarChar)
            parameterGroupBy.Value = groupby
            arParams(4) = parameterGroupBy
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(5) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Combined", "DtQuoteFunctionsCombined", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function



    Public Function getPrintDetailsFH(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String) As DataTable
        Try
            'Get the real data
            Dim arParams(3) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(3) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_FH", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetails002(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal reporttype As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            Dim parameterReportType As New SqlParameter("@ReportType", SqlDbType.Int)
            parameterReportType.Value = reporttype
            arParams(3) = parameterReportType
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Report2", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetails002Combined(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal reporttype As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(6) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            Dim parameterReportType As New SqlParameter("@ReportType", SqlDbType.Int)
            parameterReportType.Value = reporttype
            arParams(4) = parameterReportType
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(5) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Report2_Combined", "DtQuoteFunctionsCombined", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetails003(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal reporttype As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            Dim parameterReportType As New SqlParameter("@ReportType", SqlDbType.Int)
            parameterReportType.Value = reporttype
            arParams(3) = parameterReportType
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Report3", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetails003Combined(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal reporttype As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(6) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            Dim parameterReportType As New SqlParameter("@ReportType", SqlDbType.Int)
            parameterReportType.Value = reporttype
            arParams(4) = parameterReportType
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(5) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Report3_Combined", "DtQuoteFunctionsCombined", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getComments(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal FncCode As String,
                                   ByVal EstRate As Decimal,
                                   ByVal UserID As String) As DataTable
        Try
            Dim dt As DataTable
            Dim arParams(8) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
            paramFNC_CODE.Value = FncCode
            arParams(4) = paramFNC_CODE

            Dim paramEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
            paramEST_REV_RATE.Value = EstRate
            arParams(5) = paramEST_REV_RATE

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(6) = paramUserID

            Try
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetComments", "dt", arParams)
                Return dt
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function getPrintDetails003DS(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal reporttype As Integer) As DataSet
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            Dim parameterReportType As New SqlParameter("@ReportType", SqlDbType.Int)
            parameterReportType.Value = reporttype
            arParams(3) = parameterReportType
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataSet
            DtRealData = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Report3", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getCommentsCombined(ByVal EstNbr As Integer,
                                        ByVal QteNbr As Integer,
                                        ByVal FncCode As String,
                                        ByVal UserID As String) As DataTable
        Try
            Dim dt As DataTable
            Dim arParams(4) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QteNbr
            arParams(1) = paramEST_QUOTE_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
            paramFNC_CODE.Value = FncCode
            arParams(2) = paramFNC_CODE

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(3) = paramUserID

            Try
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetComments_Combined", "dt", arParams)
                Return dt
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function getCommentsFH(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal FncHeadingId As Integer) As DataTable
        Try
            Dim dt As DataTable
            Dim arParams(6) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramFNC_HEADING_ID As New SqlParameter("@FNC_HEADING_ID", SqlDbType.Int)
            paramFNC_HEADING_ID.Value = FncHeadingId
            arParams(4) = paramFNC_HEADING_ID

            Try
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetComments_FH", "dt", arParams)
                Return dt
            Catch ex As Exception
                'Return False
            End Try
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function getPrintDetailsSS1(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String) As DataTable
        Try
            'Get the real data
            Dim arParams(4) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Custom1", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsSS2(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String) As DataTable
        Try
            'Get the real data
            Dim arParams(3) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(3) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Custom2", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsQuarry(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String) As DataTable
        Try
            'Get the real data
            Dim arParams(4) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_Custom3", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsTap(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal rptType As String) As DataSet
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID
            Dim parameterrptType As New SqlParameter("@rptType", SqlDbType.VarChar)
            parameterrptType.Value = rptType
            arParams(5) = parameterrptType

            Dim DtRealData As New DataSet
            DtRealData = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_CustomTap", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsTotals(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String) As DataTable
        Try
            'Get the real data
            Dim arParams(4) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_CustomTotals", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsTotalsQuarry(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal rptType As String) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            'Dim parameterRevNumber As New SqlParameter("@RevNo", SqlDbType.Int)
            'parameterRevNumber.Value = revnum
            'arParams(3) = parameterRevNumber
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(4) = paramUserID
            Dim parameterrptType As New SqlParameter("@rptType", SqlDbType.VarChar)
            parameterrptType.Value = rptType
            arParams(5) = parameterrptType

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_CustomTotalQuarry", "DtQuoteFunctions", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsJVS(ByVal jobnum As Integer, ByVal jobcompnum As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(2) As SqlParameter
            Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
            parameterJobNum.Value = jobnum
            arParams(0) = parameterJobNum
            Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
            parameterJobCompNum.Value = jobcompnum
            arParams(1) = parameterJobCompNum

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_JVS", "Dt", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsBWD(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal combine As Integer) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            Dim parameterCombine As New SqlParameter("@Combine", SqlDbType.Int)
            parameterCombine.Value = combine
            arParams(4) = parameterCombine
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(5) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_BWD", "DtQuoteFunctionsBWD", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

    Public Function getPrintDetailsCombinedBWD(ByVal estnum As Integer, ByVal estcompnum As Integer, ByVal UserID As String, ByVal quotes As String, ByVal comps As String, ByVal groupby As String) As DataTable
        Try
            'Get the real data
            Dim arParams(5) As SqlParameter
            Dim parameterEstNumber As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNumber.Value = estnum
            arParams(0) = parameterEstNumber
            Dim parameterEstCompNumber As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstCompNumber.Value = estcompnum
            arParams(1) = parameterEstCompNumber
            Dim parameterQuotes As New SqlParameter("@Quotes", SqlDbType.VarChar)
            parameterQuotes.Value = quotes
            arParams(2) = parameterQuotes
            Dim parameterComps As New SqlParameter("@Comps", SqlDbType.VarChar)
            parameterComps.Value = comps
            arParams(3) = parameterComps
            Dim parameterGroupBy As New SqlParameter("@Groupby", SqlDbType.VarChar)
            parameterGroupBy.Value = groupby
            arParams(4) = parameterGroupBy
            'Dim parameterPhase As New SqlParameter("@Phase", SqlDbType.Int)
            'parameterPhase.Value = phase
            'arParams(4) = parameterPhase
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(5) = paramUserID

            Dim DtRealData As New DataTable
            DtRealData = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Print_Details_CombinedBWD", "DtQuoteFunctionsCombinedBWD", arParams)

            Return DtRealData
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Estimate Alert "

#End Region

#Region " Estimate Copy "

    Public Overloads Function GetInfoForEstimateCopy(ByVal EstNo As Integer) As DataTable
        Dim dt As DataTable

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Copy_Info", "dtCopy", parameterEstNo)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetInfoForEstimateCopy", Err.Description)
        End Try

        Return dt
    End Function

    Public Function AddNewEstimateCopy(ByVal EstNo As Integer,
                                       ByVal CLIENT As String,
                                       ByVal DIVISION As String,
                                       ByVal PRODUCT As String,
                                       ByVal SalesClass As String,
                                       ByVal MarkupPct As Decimal,
                                       ByVal EstDesc As String,
                                       ByVal UserID As String,
                                       ByVal CampaignID As Integer) As String
        Try
            Dim arParams(11) As SqlParameter

            Dim paramEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
            paramEstNo.Value = EstNo
            arParams(0) = paramEstNo

            Dim paramEST_LOG_DESC As New SqlParameter("@EST_LOG_DESC", SqlDbType.VarChar)
            paramEST_LOG_DESC.Value = EstDesc
            arParams(1) = paramEST_LOG_DESC

            Dim paramCLIENT As New SqlParameter("@CLIENT", SqlDbType.VarChar)
            paramCLIENT.Value = CLIENT
            arParams(2) = paramCLIENT

            Dim paramDIVISION As New SqlParameter("@DIVISION", SqlDbType.VarChar)
            paramDIVISION.Value = DIVISION
            arParams(3) = paramDIVISION

            Dim paramPRODUCT As New SqlParameter("@PRODUCT", SqlDbType.VarChar)
            paramPRODUCT.Value = PRODUCT
            arParams(4) = paramPRODUCT

            Dim paramSALES_CLASS As New SqlParameter("@SALES_CLASS", SqlDbType.VarChar)
            paramSALES_CLASS.Value = SalesClass
            arParams(5) = paramSALES_CLASS

            Dim paramMARKUP_PCT As New SqlParameter("@MARKUP_PCT", SqlDbType.Decimal)
            'If MarkupPct = 0.0 Then
            '    paramMARKUP_PCT.Value = DBNull.Value
            'Else
            paramMARKUP_PCT.Value = MarkupPct
            'END If
            arParams(6) = paramMARKUP_PCT

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(7) = paramUSER_ID

            Dim paramCMP_IDENTIFIER As New SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            If CampaignID = 0 Then
                paramCMP_IDENTIFIER.Value = DBNull.Value
            Else
                paramCMP_IDENTIFIER.Value = CampaignID
            End If
            arParams(8) = paramCMP_IDENTIFIER

            Dim EST As New SqlParameter("@EST_NUM", SqlDbType.Int, 4)
            EST.Direction = ParameterDirection.Output
            arParams(9) = EST

            Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            pCreateDate.Value = cEmployee.TimeZoneToday
            arParams(10) = pCreateDate

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Copy_AddEstimate", arParams)
                Return CStr(EST.Value)
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function AddNewEstimateComponentCopy(ByVal EstNbr As Integer,
                                                ByVal EstNo As Integer,
                                                ByVal EstComp As Integer,
                                                ByVal EstCompDesc As String,
                                                ByVal JobNum As Integer,
                                                ByVal JobCompNum As Integer,
                                                ByVal CDPContactID As String) As String
        Try
            Dim arParams(8) As SqlParameter

            Dim paramEST_NBR As New SqlParameter("@EST_NBR", SqlDbType.Int)
            paramEST_NBR.Value = EstNbr
            arParams(0) = paramEST_NBR

            Dim paramEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
            paramEstNo.Value = EstNo
            arParams(1) = paramEstNo

            Dim paramEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
            paramEstComp.Value = EstComp
            arParams(2) = paramEstComp

            Dim paramEstCompDesc As New SqlParameter("@EstCompDesc", SqlDbType.VarChar)
            paramEstCompDesc.Value = EstCompDesc
            arParams(3) = paramEstCompDesc

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNum
            arParams(4) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramJOB_COMPONENT_NBR.Value = JobCompNum
            arParams(5) = paramJOB_COMPONENT_NBR

            Dim paramCDP_CONTACT_ID As New SqlParameter("CDP_CONTACT_ID", SqlDbType.Int)
            If CDPContactID = "" Or CDPContactID = "0" Then
                paramCDP_CONTACT_ID.Value = DBNull.Value
            Else
                paramCDP_CONTACT_ID.Value = CDPContactID
            End If
            arParams(6) = paramCDP_CONTACT_ID

            Dim EST As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int, 4)
            EST.Direction = ParameterDirection.Output
            arParams(7) = EST

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Copy_AddEstimateComponent", arParams)
                Return CStr(EST.Value)
            Catch ex As Exception
                Return ex.Message.ToString
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function AddNewQuoteCopy(ByVal EstNbr As Integer,
                                   ByVal EstCompNbr As Integer,
                                   ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal QuoteNbr As Integer,
                                   ByVal EstRevNbr As Integer,
                                   ByVal Recalculate As Integer) As Boolean
        Try
            Dim arParams(7) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
            paramEstNo.Value = EstNo
            arParams(2) = paramEstNo

            Dim paramEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
            paramEstComp.Value = EstComp
            arParams(3) = paramEstComp

            Dim paramEstQuoteNo As New SqlParameter("@EstQuoteNo", SqlDbType.Int)
            paramEstQuoteNo.Value = QuoteNbr
            arParams(4) = paramEstQuoteNo

            Dim paramEstRevNo As New SqlParameter("@EstRevNo", SqlDbType.Int)
            paramEstRevNo.Value = EstRevNbr
            arParams(5) = paramEstRevNo

            Dim paramRecalculate As New SqlParameter("@Recalculate", SqlDbType.Int)
            paramRecalculate.Value = Recalculate
            arParams(6) = paramRecalculate


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Copy_AddQuote", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region " Estimate Job History "

    Public Function GetJobsForHistory(ByVal client As String, ByVal division As String, ByVal product As String, ByVal jobtype As String, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal closed As Boolean, ByVal UserID As String) As DataSet
        Try
            Dim arParams(8) As SqlParameter

            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(0) = paramClient

            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = division
            arParams(1) = paramDivision

            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = product
            arParams(2) = paramProduct

            Dim paramJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
            paramJobType.Value = jobtype
            arParams(3) = paramJobType

            Dim paramFromDate As New SqlParameter("@FromDate", SqlDbType.SmallDateTime)
            paramFromDate.Value = fromdate
            arParams(4) = paramFromDate

            Dim paramToDate As New SqlParameter("@ToDate", SqlDbType.SmallDateTime)
            paramToDate.Value = todate
            arParams(5) = paramToDate

            Dim paramClosed As New SqlParameter("@Closed", SqlDbType.Int)
            If closed = True Then
                paramClosed.Value = 1
            Else
                paramClosed.Value = 0
            End If
            arParams(6) = paramClosed

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(7) = paramUserID

            Dim ds As DataSet

            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetJobs_JobHistory", arParams)

            Return ds
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Estimate Campaign "

    Public Function UpdateQuoteFromCampaign(ByVal EstNbr As Integer,
                                           ByVal EstCompNbr As Integer,
                                           ByVal QuoteNbr As Integer,
                                           ByVal EstRevNbr As Integer,
                                           ByVal JobNbr As Integer,
                                           ByVal JobCompNbr As Integer) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EstimateNumber", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EstimateComponentNunber", SqlDbType.Int)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EstimateQuote", SqlDbType.Int)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EstimateRevision", SqlDbType.Int)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNbr
            arParams(4) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JobComponentNumber", SqlDbType.Int)
            paramJOB_COMPONENT_NBR.Value = JobCompNbr
            arParams(5) = paramJOB_COMPONENT_NBR

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_update_estimate_from_campaign", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region " Master Estimate "

    Public Function UpdateMasterEstimateFromQuotes(ByVal EstNbr As Integer,
                                           ByVal EstCompNbr As Integer,
                                           ByVal QuoteNbr As Integer,
                                           ByVal EstRevNbr As Integer,
                                           ByVal JobNbr As Integer,
                                           ByVal JobCompNbr As Integer,
                                           ByVal Action As String) As Boolean
        Try
            Dim arParams(7) As SqlParameter

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EstimateNumber", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EstimateComponentNumber", SqlDbType.SmallInt)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EstimateQuoteNumber", SqlDbType.SmallInt)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EstimateRevisionNumber", SqlDbType.SmallInt)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNbr
            arParams(4) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@CompNumber", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobCompNbr
            arParams(5) = paramJOB_COMPONENT_NBR

            Dim paramAction As New SqlParameter("@Action", SqlDbType.VarChar)
            paramAction.Value = Action
            arParams(6) = paramAction

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_estimate_update_master", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CheckQuotesApprovals(ByVal EstNbr As Integer,
                                           ByVal EstCompNbr As Integer,
                                           ByVal QuoteNbr As Integer,
                                           ByVal EstRevNbr As Integer,
                                           ByVal JobNbr As Integer,
                                           ByVal JobCompNbr As Integer,
                                           ByVal Action As String) As Integer
        Try
            Dim arParams(7) As SqlParameter
            Dim Check As Integer

            Dim paramESTIMATE_NUMBER As New SqlParameter("@EstimateNumber", SqlDbType.Int)
            paramESTIMATE_NUMBER.Value = EstNbr
            arParams(0) = paramESTIMATE_NUMBER

            Dim paramEST_COMPONENT_NBR As New SqlParameter("@EstimateComponentNumber", SqlDbType.SmallInt)
            paramEST_COMPONENT_NBR.Value = EstCompNbr
            arParams(1) = paramEST_COMPONENT_NBR

            Dim paramEST_QUOTE_NBR As New SqlParameter("@EstimateQuoteNumber", SqlDbType.SmallInt)
            paramEST_QUOTE_NBR.Value = QuoteNbr
            arParams(2) = paramEST_QUOTE_NBR

            Dim paramEST_REV_NBR As New SqlParameter("@EstimateRevisionNumber", SqlDbType.SmallInt)
            paramEST_REV_NBR.Value = EstRevNbr
            arParams(3) = paramEST_REV_NBR

            Dim paramJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNbr
            arParams(4) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@CompNumber", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobCompNbr
            arParams(5) = paramJOB_COMPONENT_NBR

            Dim paramAction As New SqlParameter("@Action", SqlDbType.VarChar)
            paramAction.Value = Action
            arParams(6) = paramAction

            Try
                Check = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "advsp_estimate_approval_check", arParams))
                Return Check
            Catch ex As Exception
                Return 0
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

#End Region

#Region " Setup "

    Public Function GetEstimateColumns(ByVal HdrCode As String, ByVal ShowAll As Boolean, ByVal IsSetup As Boolean, ByVal IsAddNew As Boolean) As DataTable
        Try
            Dim arParams(4) As SqlParameter

            Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
            paramHdrCode.Value = HdrCode
            arParams(0) = paramHdrCode

            Dim paramShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.Int)
            If ShowAll = True Then
                paramShowAll.Value = -1
            Else
                paramShowAll.Value = 0
            End If
            arParams(1) = paramShowAll

            Dim paramIsSetup As New SqlParameter("@IS_SETUP", SqlDbType.Int)
            If IsSetup = True Then
                paramIsSetup.Value = 1
            Else
                paramIsSetup.Value = 0
            End If
            arParams(2) = paramIsSetup

            'Dim paramIsAddNew As New SqlParameter("@IS_ADDNEW", SqlDbType.Int)
            'If IsAddNew = True Then
            '    paramIsAddNew.Value = 1
            'Else
            '    paramIsAddNew.Value = 0
            'END If
            'arParams(3) = paramIsAddNew

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetEstimateUserColumns", "tbColumns", arParams)
            Return dt
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetEstimateColumns!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function UpdateUserColumn(ByVal HdrCode As String, ByVal ColumnID As Integer, ByVal ShowOnGrid As Boolean, ByVal ShowOnAddNew As Boolean) As String
        Dim arParams(4) As SqlParameter

        Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
        paramHdrCode.Value = HdrCode
        arParams(0) = paramHdrCode

        Dim paramColumnID As New SqlParameter("@COLUMN_ID", SqlDbType.Int)
        paramColumnID.Value = ColumnID
        arParams(1) = paramColumnID

        Dim paramShowOnGrid As New SqlParameter("@SHOW_ON_GRID", SqlDbType.SmallInt)
        If ShowOnGrid = True Then
            paramShowOnGrid.Value = 1
        Else
            paramShowOnGrid.Value = 0
        End If
        arParams(2) = paramShowOnGrid

        'Dim paramShowOnAddNew As New SqlParameter("@SHOW_ON_ADDNEW", SqlDbType.SmallInt)
        'If ShowOnAddNew = True Then
        '    paramShowOnAddNew.Value = 1
        'Else
        '    paramShowOnAddNew.Value = 0
        'END If
        'arParams(3) = paramShowOnAddNew


        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_Save_UserColumns", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function UpdateUserColumnShowLong(ByVal HdrCode As String, ByVal ColumnID As Integer) As String
        Dim arParams(2) As SqlParameter
        Dim paramHdrCode As New SqlParameter("@HDR_CODE", SqlDbType.VarChar, 6)
        paramHdrCode.Value = HdrCode
        arParams(0) = paramHdrCode

        Dim paramColumnID As New SqlParameter("@COLUMN_ID", SqlDbType.Int)
        paramColumnID.Value = ColumnID
        arParams(1) = paramColumnID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_Save_UserColumns_ShowFullColumnText", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

#End Region

#Region " Vendor Estimate Quotes "

    Public Overloads Function GetVendorQuotes(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(3) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(2) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequests", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetVendorQuotes", Err.Description)
        End Try

        Return ds
    End Function

    Public Overloads Function GetRequestData(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(4) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(3) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestData", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestData", Err.Description)
        End Try

        Return ds
    End Function

    Public Overloads Function GetRequestQuotes(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal QuoteNo As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(5) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim parameterQuoteNo As New SqlParameter("@QuoteNo", SqlDbType.Int)
        parameterQuoteNo.Value = QuoteNo
        ar(3) = parameterQuoteNo

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(4) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestQuotes", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestQuotes", Err.Description)
        End Try

        Return ds
    End Function

    Public Overloads Function GetRequestVendors(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(4) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(3) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestVendors", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestVendors", Err.Description)
        End Try

        Return ds
    End Function

    Public Overloads Function GetRequestVendorReplies(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(4) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(3) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestVendorReplies", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestVendorReplies", Err.Description)
        End Try

        Return ds
    End Function

    Public Overloads Function GetRequestNumber(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal user As String) As Integer
        Dim num As Integer
        Dim ar(3) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(2) = paramUser

        Try
            num = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestNum", ar))
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestNum", Err.Description)
        End Try

        Return num
    End Function

    Public Overloads Function GetRequestPrint(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal user As String, ByVal vendor As String, ByVal vendors As String) As DataTable
        Dim ds As DataTable
        Dim ar(6) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(3) = paramUser

        Dim parameterVendor As New SqlParameter("@VendorCode", SqlDbType.VarChar)
        parameterVendor.Value = vendor
        ar(4) = parameterVendor

        Dim parameterVendors As New SqlParameter("@Vendors", SqlDbType.VarChar)
        parameterVendors.Value = vendors
        ar(5) = parameterVendors

        Try
            ds = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestPrint", "dt", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestPrint", Err.Description)
        End Try

        Return ds
    End Function

    Public Function AddNewRequest(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VendorQteDesc As String,
                                   ByVal VendorMemo As String,
                                   ByVal CreatedBy As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal UserID As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVendorQteDesc As New SqlParameter("@VENDOR_QTE_DESC", SqlDbType.VarChar)
            paramVendorQteDesc.Value = VendorQteDesc
            arParams(3) = paramVendorQteDesc

            Dim paramVendorMemo As New SqlParameter("@VN_QTE_MEMO", SqlDbType.Text)
            paramVendorMemo.Value = VendorMemo
            arParams(4) = paramVendorMemo

            Dim paramCreatedBy As New SqlParameter("@CREATED_BY", SqlDbType.VarChar)
            paramCreatedBy.Value = CreatedBy
            arParams(5) = paramCreatedBy

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = CreateDate
            arParams(6) = paramCreateDate

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(7) = paramUSER_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_AddNewRequest", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequest(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VendorQteDesc As String,
                                   ByVal VendorMemo As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal UserID As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVendorQteDesc As New SqlParameter("@VENDOR_QTE_DESC", SqlDbType.VarChar)
            paramVendorQteDesc.Value = VendorQteDesc
            arParams(3) = paramVendorQteDesc

            Dim paramVendorMemo As New SqlParameter("@VN_QTE_MEMO", SqlDbType.Text)
            paramVendorMemo.Value = VendorMemo
            arParams(4) = paramVendorMemo

            'Dim paramCreatedBy As New SqlParameter("@CREATED_BY", SqlDbType.VarChar)
            'paramCreatedBy.Value = CreatedBy
            'arParams(5) = paramCreatedBy

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = CreateDate
            arParams(6) = paramCreateDate

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(7) = paramUSER_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequest", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestMemo(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VendorMemo As String,
                                   ByVal UserID As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            'Dim paramVendorQteDesc As New SqlParameter("@VENDOR_QTE_DESC", SqlDbType.VarChar)
            'paramVendorQteDesc.Value = VendorQteDesc
            'arParams(3) = paramVendorQteDesc

            Dim paramVendorMemo As New SqlParameter("@VN_QTE_MEMO", SqlDbType.Text)
            paramVendorMemo.Value = VendorMemo
            arParams(3) = paramVendorMemo

            'Dim paramCreatedBy As New SqlParameter("@CREATED_BY", SqlDbType.VarChar)
            'paramCreatedBy.Value = CreatedBy
            'arParams(5) = paramCreatedBy

            'Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            'paramCreateDate.Value = CreateDate.ToShortDateString
            'arParams(6) = paramCreateDate

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(4) = paramUSER_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestMemo", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddNewRequestQuote(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal EstQuote As Integer,
                                   ByVal EstRev As Integer,
                                   ByVal QteSpecs As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramEstQuote As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEstQuote.Value = EstQuote
            arParams(3) = paramEstQuote

            Dim paramEstRev As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEstRev.Value = EstRev
            arParams(4) = paramEstRev

            Dim paramQteSpecs As New SqlParameter("@VN_QTE_SPECS", SqlDbType.Text)
            paramQteSpecs.Value = QteSpecs
            arParams(5) = paramQteSpecs


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_AddNewQuote", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestQuote(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal QuoteNo As Integer,
                                   ByVal RevNo As Integer,
                                   ByVal QteSpecs As String) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramQuoteNo As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramQuoteNo.Value = QuoteNo
            arParams(3) = paramQuoteNo

            Dim paramRevNo As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramRevNo.Value = RevNo
            arParams(4) = paramRevNo

            Dim paramQteSpecs As New SqlParameter("@VN_QTE_SPECS", SqlDbType.Text)
            paramQteSpecs.Value = QteSpecs
            arParams(5) = paramQteSpecs

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestQuote", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddNewRequestFunction(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal FncCode As String,
                                   ByVal FncNotes As String) As Boolean
        Try
            Dim arParams(8) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramEstQuote As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramEstQuote.Value = FncCode
            arParams(3) = paramEstQuote

            Dim paramQteSpecs As New SqlParameter("@FNC_NOTES", SqlDbType.Text)
            If FncNotes = "" Then
                paramQteSpecs.Value = DBNull.Value
            Else
                paramQteSpecs.Value = FncNotes
            End If
            arParams(4) = paramQteSpecs


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_AddNewFunction", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestFunction(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal FncCode As String,
                                   ByVal FncNotes As String) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramFncCode As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramFncCode.Value = FncCode
            arParams(3) = paramFncCode

            Dim paramFncNotes As New SqlParameter("@FNC_NOTES", SqlDbType.Text)
            paramFncNotes.Value = FncNotes
            arParams(4) = paramFncNotes

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestFunction", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddNewRequestVendor(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VnCode As String,
                                   ByVal VnContCode As String,
                                   ByVal VnNotes As String,
                                   ByVal Dispatch As String,
                                   ByVal DueDate As String,
                                   ByVal ReplyDate As String,
                                   ByVal submitted As String) As Boolean
        Try
            Dim arParams(10) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(3) = paramVnCode

            Dim paramVnContCode As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar)
            If VnContCode.Trim = "" Then
                paramVnContCode.Value = DBNull.Value
            Else
                paramVnContCode.Value = VnContCode
            End If
            arParams(4) = paramVnContCode

            Dim paramVnNotes As New SqlParameter("@VN_NOTES", SqlDbType.Text)
            If VnNotes.Trim = "" Then
                paramVnNotes.Value = DBNull.Value
            Else
                paramVnNotes.Value = VnNotes
            End If
            arParams(5) = paramVnNotes

            Dim paramDispatch As New SqlParameter("@DISPATCH_DATE", SqlDbType.SmallDateTime)
            If Dispatch = "" Then
                paramDispatch.Value = DBNull.Value
            Else
                paramDispatch.Value = Dispatch
            End If
            arParams(6) = paramDispatch

            Dim paramDueDate As New SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
            If DueDate = "" Then
                paramDueDate.Value = DBNull.Value
            Else
                paramDueDate.Value = DueDate
            End If
            arParams(7) = paramDueDate

            Dim paramReplyDate As New SqlParameter("@REPLY_DATE", SqlDbType.SmallDateTime)
            If ReplyDate = "" Then
                paramReplyDate.Value = DBNull.Value
            Else
                paramReplyDate.Value = ReplyDate
            End If
            arParams(8) = paramReplyDate

            Dim paramsubmitted As New SqlParameter("@SUBMITTED_BY", SqlDbType.VarChar)
            paramsubmitted.Value = submitted
            arParams(9) = paramsubmitted


            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_AddNewVendor", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestVendor(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VnCode As String,
                                   ByVal VnContCode As String,
                                   ByVal VnNotes As String,
                                   ByVal Dispatch As String,
                                   ByVal Reply As String,
                                   ByVal DueDate As String) As Boolean
        Try
            Dim arParams(9) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(3) = paramVnCode

            Dim paramVnContCode As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar)
            paramVnContCode.Value = VnContCode
            arParams(4) = paramVnContCode

            Dim paramVnNotes As New SqlParameter("@VN_NOTES", SqlDbType.Text)
            paramVnNotes.Value = VnNotes
            arParams(5) = paramVnNotes

            Dim paramDispatch As New SqlParameter("@DISPATCH_DATE", SqlDbType.SmallDateTime)
            If Dispatch = "" Then
                paramDispatch.Value = DBNull.Value
            Else
                paramDispatch.Value = CDate(Dispatch).ToShortDateString
            End If
            arParams(6) = paramDispatch

            Dim paramReply As New SqlParameter("@REPLY_DATE", SqlDbType.SmallDateTime)
            If Reply = "" Then
                paramReply.Value = DBNull.Value
            Else
                paramReply.Value = Reply
            End If
            arParams(7) = paramReply

            Dim paramDueDate As New SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
            If DueDate = "" Then
                paramDueDate.Value = DBNull.Value
            Else
                paramDueDate.Value = DueDate
            End If
            arParams(8) = paramDueDate

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestVendor", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestVendorComment(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VnCode As String,
                                   ByVal VnNotes As String) As Boolean
        Try
            Dim arParams(5) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(3) = paramVnCode

            'Dim paramVnContCode As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar)
            'paramVnContCode.Value = VnContCode
            'arParams(4) = paramVnContCode

            Dim paramVnNotes As New SqlParameter("@VN_NOTES", SqlDbType.Text)
            paramVnNotes.Value = VnNotes
            arParams(4) = paramVnNotes

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestVendorComment", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestVendorContact(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VnCode As String,
                                   ByVal VnContCode As String) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(3) = paramVnCode

            Dim paramVnContCode As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar)
            If VnContCode = "" Then
                paramVnContCode.Value = DBNull.Value
            Else
                paramVnContCode.Value = VnContCode
            End If
            arParams(4) = paramVnContCode

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestVendorContact", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestVendorSubmit(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VnCode As String,
                                   ByVal Dispatch As DateTime,
                                   ByVal SubmittedBy As String) As Boolean
        Try
            Dim arParams(6) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(3) = paramVnCode

            Dim paramDispatch As New SqlParameter("@DISPATCH_DATE", SqlDbType.SmallDateTime)
            paramDispatch.Value = Dispatch
            arParams(4) = paramDispatch

            Dim paramSubmittedBy As New SqlParameter("@SUBMITTED_BY", SqlDbType.VarChar)
            paramSubmittedBy.Value = SubmittedBy
            arParams(5) = paramSubmittedBy

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateRequestVendorSubmit", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetFunctionsVendor(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNo As Integer, ByVal def As Boolean, ByVal UserID As String) As SqlDataReader

        Dim dr As SqlDataReader
        Try
            Dim arParams(4) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VendorQteNo", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramdef As New SqlParameter("@Default", SqlDbType.Int)
            If def = True Then
                paramdef.Value = 1
            Else
                paramdef.Value = 0
            End If
            arParams(3) = paramdef
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetVendorFunctions", arParams)

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_Vendor_Quote_GetVendorFunctions", Err.Description)
        End Try

        Return dr

    End Function

    Public Function AddNewRequestDetail(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal EstQuote As Integer,
                                   ByVal EstRev As Integer,
                                   ByVal FncCode As String,
                                   ByVal VnCode As String,
                                   ByVal CreatedBy As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal ReplyRate As Decimal,
                                   ByVal ReplyAmt As Decimal,
                                   ByVal ReplyNotes As String,
                                   ByVal Approved As Integer,
                                   ByVal ApprovalNotes As String,
                                   ByVal ApprovedBy As String,
                                   ByVal ApprovalDate As String,
                                   ByVal Qty As Integer) As Boolean
        Try
            Dim arParams(17) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramEstQuote As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramEstQuote.Value = EstQuote
            arParams(3) = paramEstQuote

            Dim paramEstRev As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramEstRev.Value = EstRev
            arParams(4) = paramEstRev

            Dim paramFncCode As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramFncCode.Value = FncCode
            arParams(5) = paramFncCode

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(6) = paramVnCode

            Dim paramCreatedBy As New SqlParameter("@CREATED_BY", SqlDbType.VarChar)
            paramCreatedBy.Value = CreatedBy
            arParams(7) = paramCreatedBy

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = CreateDate
            arParams(8) = paramCreateDate

            Dim paramReplyRate As New SqlParameter("@REPLY_RATE", SqlDbType.Decimal)
            paramReplyRate.Value = ReplyRate
            arParams(9) = paramReplyRate

            Dim paramReplyAmt As New SqlParameter("@REPLY_AMT", SqlDbType.Decimal)
            paramReplyAmt.Value = ReplyAmt
            arParams(10) = paramReplyAmt

            Dim paramReplyNotes As New SqlParameter("@REPLY_NOTES", SqlDbType.Text)
            If ReplyNotes = "" Then
                paramReplyNotes.Value = DBNull.Value
            Else
                paramReplyNotes.Value = ReplyNotes
            End If
            arParams(11) = paramReplyNotes

            Dim paramApproved As New SqlParameter("@APPROVED_FLAG", SqlDbType.SmallInt)
            paramApproved.Value = Approved
            arParams(12) = paramApproved

            Dim paramApprovalNotes As New SqlParameter("@APPROVAL_NOTES", SqlDbType.Text)
            If ApprovalNotes = "" Then
                paramApprovalNotes.Value = DBNull.Value
            Else
                paramApprovalNotes.Value = ApprovalNotes
            End If
            arParams(13) = paramApprovalNotes

            Dim paramApprovedBy As New SqlParameter("@APPROVED_BY", SqlDbType.VarChar)
            If ApprovedBy = "" Then
                paramApprovedBy.Value = DBNull.Value
            Else
                paramApprovedBy.Value = ApprovedBy
            End If
            arParams(14) = paramApprovedBy

            Dim paramApprovalDate As New SqlParameter("@APPROVED_DATE", SqlDbType.SmallDateTime)
            If ApprovalDate = "" Then
                paramApprovalDate.Value = DBNull.Value
            Else
                paramApprovalDate.Value = CDate(ApprovalDate).ToShortDateString
            End If
            arParams(15) = paramApprovalDate

            Dim paramQty As New SqlParameter("@QTY", SqlDbType.Int)
            paramQty.Value = Qty
            arParams(16) = paramQty

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_AddDetail", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestDetailQty(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal QuoteNo As Integer,
                                   ByVal RevNo As Integer,
                                   ByVal FncCode As String,
                                   ByVal Qty As Integer) As Boolean
        Try
            Dim arParams(7) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramQuoteNo As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramQuoteNo.Value = QuoteNo
            arParams(3) = paramQuoteNo

            Dim paramRevNo As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramRevNo.Value = RevNo
            arParams(4) = paramRevNo

            Dim paramFncCode As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramFncCode.Value = FncCode
            arParams(5) = paramFncCode

            Dim paramQty As New SqlParameter("@QTY", SqlDbType.Int)
            paramQty.Value = Qty
            arParams(6) = paramQty

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateDetailQty", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestDetailComments(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal QuoteNo As Integer,
                                   ByVal RevNo As Integer,
                                   ByVal FncCode As String,
                                   ByVal VnCode As String,
                                   ByVal ReplyNotes As String,
                                   ByVal ApprovalNotes As String) As Boolean
        Try
            Dim arParams(9) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramQuoteNo As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramQuoteNo.Value = QuoteNo
            arParams(3) = paramQuoteNo

            Dim paramRevNo As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramRevNo.Value = RevNo
            arParams(4) = paramRevNo

            Dim paramFncCode As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramFncCode.Value = FncCode
            arParams(5) = paramFncCode

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(6) = paramVnCode

            Dim paramReplyNotes As New SqlParameter("@REPLY_NOTES", SqlDbType.Text)
            paramReplyNotes.Value = ReplyNotes
            arParams(7) = paramReplyNotes

            Dim paramApprovalNotes As New SqlParameter("@APPROVAL_NOTES", SqlDbType.Text)
            paramApprovalNotes.Value = ApprovalNotes
            arParams(8) = paramApprovalNotes

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateDetailComments", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRequestDetail(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal QuoteNo As Integer,
                                   ByVal RevNo As Integer,
                                   ByVal FncCode As String,
                                   ByVal VnCode As String,
                                   ByVal ReplyRate As Decimal,
                                   ByVal ReplyAmt As Decimal,
                                   ByVal ReplyNotes As String,
                                   ByVal Approved As Boolean,
                                   ByVal ApprovalNotes As String,
                                   ByVal ApprovedBy As String,
                                   ByVal ApprovedDate As String,
                                   ByVal Qty As Integer,
                                   ByVal CreateDate As DateTime) As Boolean
        Try
            Dim arParams(16) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramQuoteNo As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            paramQuoteNo.Value = QuoteNo
            arParams(3) = paramQuoteNo

            Dim paramRevNo As New SqlParameter("@EST_REV_NBR", SqlDbType.Int)
            paramRevNo.Value = RevNo
            arParams(4) = paramRevNo

            Dim paramFncCode As New SqlParameter("@EST_FNC_CODE", SqlDbType.VarChar)
            paramFncCode.Value = FncCode
            arParams(5) = paramFncCode

            Dim paramVnCode As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            paramVnCode.Value = VnCode
            arParams(6) = paramVnCode

            Dim paramReplyRate As New SqlParameter("@REPLY_RATE", SqlDbType.Decimal)
            paramReplyRate.Value = ReplyRate
            arParams(7) = paramReplyRate

            Dim paramReplyAmt As New SqlParameter("@REPLY_AMT", SqlDbType.Decimal)
            paramReplyAmt.Value = ReplyAmt
            arParams(8) = paramReplyAmt

            Dim paramReplyNotes As New SqlParameter("@REPLY_NOTES", SqlDbType.Text)
            paramReplyNotes.Value = ReplyNotes
            arParams(9) = paramReplyNotes

            Dim paramApproved As New SqlParameter("@APPROVED_FLAG", SqlDbType.SmallInt)
            paramApproved.Value = Approved
            arParams(10) = paramApproved

            Dim paramApprovalNotes As New SqlParameter("@APPROVAL_NOTES", SqlDbType.Text)
            paramApprovalNotes.Value = ApprovalNotes
            arParams(11) = paramApprovalNotes

            Dim paramApprovedBy As New SqlParameter("@APPROVED_BY", SqlDbType.VarChar)
            paramApprovedBy.Value = ApprovedBy
            arParams(12) = paramApprovedBy

            Dim paramApprovedDate As New SqlParameter("@APPROVED_DATE", SqlDbType.SmallDateTime)
            If ApprovedDate = "" Then
                paramApprovedDate.Value = DBNull.Value
            Else
                paramApprovedDate.Value = ApprovedDate
            End If
            arParams(13) = paramApprovedDate

            Dim paramQty As New SqlParameter("@QTY", SqlDbType.Int)
            paramQty.Value = Qty
            arParams(14) = paramQty

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = CreateDate
            arParams(15) = paramCreateDate

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_UpdateDetail", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function POVendorContacts(ByVal funct_id As Integer, ByVal vn_code As String, ByVal string1 As String) As DataTable
        Dim dr As DataTable

        Dim arParams(3) As SqlParameter

        Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
        P0.Value = funct_id
        arParams(0) = P0

        Dim P1 As New SqlParameter("@code", SqlDbType.VarChar, 15)
        P1.Value = vn_code
        arParams(1) = P1

        Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 15)
        P2.Value = string1
        arParams(2) = P2

        Try
            dr = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "proc_WV_PO_Vend_Contact_LoadAll", "dt", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Vendor_Contact", Err.Description)
        End Try

        Return dr

    End Function

    Public Function CopyNewRequest(ByVal EstNo As Integer,
                                   ByVal EstComp As Integer,
                                   ByVal VendorQteNo As Integer,
                                   ByVal VenQteNum As Integer,
                                   ByVal CreatedBy As String,
                                   ByVal CreateDate As DateTime,
                                   ByVal UserID As String) As Boolean
        Try
            Dim arParams(7) As SqlParameter

            Dim parameterEstNo As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            parameterEstNo.Value = EstNo
            arParams(0) = parameterEstNo

            Dim parameterEstComp As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterEstComp.Value = EstComp
            arParams(1) = parameterEstComp

            Dim paramVendorQteNo As New SqlParameter("@VENDOR_QTE_NBR", SqlDbType.Int)
            paramVendorQteNo.Value = VendorQteNo
            arParams(2) = paramVendorQteNo

            Dim paramVendorQteNum As New SqlParameter("@VendorQteNum", SqlDbType.Int)
            paramVendorQteNum.Value = VenQteNum
            arParams(3) = paramVendorQteNum

            Dim paramCreatedBy As New SqlParameter("@CREATED_BY", SqlDbType.VarChar)
            paramCreatedBy.Value = CreatedBy
            arParams(4) = paramCreatedBy

            Dim paramCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            paramCreateDate.Value = CreateDate
            arParams(5) = paramCreateDate

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar)
            paramUSER_ID.Value = UserID
            arParams(6) = paramUSER_ID

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_Copy_AddRequest", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overloads Function GetRequestsByQuote(ByVal EstNo As Integer, ByVal EstComp As Integer, ByVal VendorQteNbr As Integer, ByVal QuoteNo As Integer, ByVal user As String) As DataSet
        Dim ds As DataSet
        Dim ar(5) As SqlParameter

        '*** Create Parameters
        Dim parameterEstNo As New SqlParameter("@EstNo", SqlDbType.Int)
        parameterEstNo.Value = EstNo
        ar(0) = parameterEstNo

        Dim parameterEstComp As New SqlParameter("@EstCompNo", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        ar(1) = parameterEstComp

        Dim parameterVendorQte As New SqlParameter("@VendorQteNo", SqlDbType.Int)
        parameterVendorQte.Value = VendorQteNbr
        ar(2) = parameterVendorQte

        Dim parameterQuoteNo As New SqlParameter("@QuoteNo", SqlDbType.Int)
        parameterQuoteNo.Value = QuoteNo
        ar(3) = parameterQuoteNo

        Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
        paramUser.Value = user
        ar(4) = paramUser

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_Quote_GetRequestsByQuote", ar)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRequestsByQuote", Err.Description)
        End Try

        Return ds
    End Function

    Public Function GetContact(ByVal Vendor As String, ByVal Contact As String, ByVal UserID As String) As SqlDataReader

        Dim dr As SqlDataReader
        Try
            Dim arParams(3) As SqlParameter

            Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar)
            parameterVendor.Value = Vendor
            arParams(0) = parameterVendor

            Dim parameterContact As New SqlParameter("@Contact", SqlDbType.VarChar)
            parameterContact.Value = Contact
            arParams(1) = parameterContact

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = UserID
            arParams(2) = paramUserID

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_GetContact", arParams)

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_Vendor_GetContact", Err.Description)
        End Try

        Return dr

    End Function

    Public Function AddNewContact(ByVal Vendor As String,
                                   ByVal Contact As String,
                                   ByVal First As String,
                                   ByVal Last As String,
                                   ByVal MI As String,
                                   ByVal Title As String,
                                   ByVal Address1 As String,
                                   ByVal Address2 As String,
                                   ByVal City As String,
                                   ByVal County As String,
                                   ByVal State As String,
                                   ByVal Country As String,
                                   ByVal Zip As String,
                                   ByVal Telephone As String,
                                   ByVal TelephoneExt As String,
                                   ByVal Fax As String,
                                   ByVal FaxExt As String,
                                   ByVal Email As String,
                                   ByVal Cell As String) As Boolean
        Try
            Dim arParams(19) As SqlParameter

            Dim parameterVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            parameterVendor.Value = Vendor
            arParams(0) = parameterVendor

            Dim parameterContact As New SqlParameter("@VC_CODE", SqlDbType.VarChar)
            parameterContact.Value = Contact
            arParams(1) = parameterContact

            Dim paramVC_FNAME As New SqlParameter("@VC_FNAME", SqlDbType.VarChar)
            paramVC_FNAME.Value = First
            arParams(2) = paramVC_FNAME

            Dim paramVC_LNAME As New SqlParameter("@VC_LNAME", SqlDbType.VarChar)
            paramVC_LNAME.Value = Last
            arParams(3) = paramVC_LNAME

            Dim paramVC_MI As New SqlParameter("@VC_MI", SqlDbType.VarChar)
            paramVC_MI.Value = MI
            arParams(4) = paramVC_MI

            Dim paramVC_TITLE As New SqlParameter("@VC_TITLE", SqlDbType.VarChar)
            paramVC_TITLE.Value = Title
            arParams(5) = paramVC_TITLE

            Dim paramVC_ADDRESS1 As New SqlParameter("@VC_ADDRESS1", SqlDbType.VarChar)
            paramVC_ADDRESS1.Value = Address1
            arParams(6) = paramVC_ADDRESS1

            Dim paramVC_ADDRESS2 As New SqlParameter("@VC_ADDRESS2", SqlDbType.VarChar)
            paramVC_ADDRESS2.Value = Address2
            arParams(7) = paramVC_ADDRESS2

            Dim paramVC_CITY As New SqlParameter("@VC_CITY", SqlDbType.VarChar)
            paramVC_CITY.Value = City
            arParams(8) = paramVC_CITY

            Dim paramVC_COUNTY As New SqlParameter("@VC_COUNTY", SqlDbType.VarChar)
            paramVC_COUNTY.Value = County
            arParams(9) = paramVC_COUNTY

            Dim paramVC_STATE As New SqlParameter("@VC_STATE", SqlDbType.VarChar)
            paramVC_STATE.Value = State
            arParams(10) = paramVC_STATE

            Dim paramVC_COUNTRY As New SqlParameter("@VC_COUNTRY", SqlDbType.VarChar)
            paramVC_COUNTRY.Value = Country
            arParams(11) = paramVC_COUNTRY

            Dim paramVC_ZIP As New SqlParameter("@VC_ZIP", SqlDbType.VarChar)
            paramVC_ZIP.Value = Zip
            arParams(12) = paramVC_ZIP

            Dim paramVC_TELEPHONE As New SqlParameter("@VC_TELEPHONE", SqlDbType.VarChar)
            paramVC_TELEPHONE.Value = Telephone
            arParams(13) = paramVC_TELEPHONE

            Dim paramVC_EXTENTION As New SqlParameter("@VC_EXTENTION", SqlDbType.VarChar)
            paramVC_EXTENTION.Value = TelephoneExt
            arParams(14) = paramVC_EXTENTION

            Dim paramVC_FAX As New SqlParameter("@VC_FAX", SqlDbType.VarChar)
            paramVC_FAX.Value = Fax
            arParams(15) = paramVC_FAX

            Dim paramVC_FAX_EXTENTION As New SqlParameter("@VC_FAX_EXTENTION", SqlDbType.VarChar)
            paramVC_FAX_EXTENTION.Value = FaxExt
            arParams(16) = paramVC_FAX_EXTENTION

            Dim paramEMAIL_ADDRESS As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar)
            paramEMAIL_ADDRESS.Value = Email
            arParams(17) = paramEMAIL_ADDRESS

            Dim paramVC_PHONE_CELL As New SqlParameter("@VC_PHONE_CELL", SqlDbType.VarChar)
            paramVC_PHONE_CELL.Value = Cell
            arParams(18) = paramVC_PHONE_CELL

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_AddContact", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateContact(ByVal Vendor As String,
                                   ByVal Contact As String,
                                   ByVal First As String,
                                   ByVal Last As String,
                                   ByVal MI As String,
                                   ByVal Title As String,
                                   ByVal Address1 As String,
                                   ByVal Address2 As String,
                                   ByVal City As String,
                                   ByVal County As String,
                                   ByVal State As String,
                                   ByVal Country As String,
                                   ByVal Zip As String,
                                   ByVal Telephone As String,
                                   ByVal TelephoneExt As String,
                                   ByVal Fax As String,
                                   ByVal FaxExt As String,
                                   ByVal Email As String,
                                   ByVal Cell As String) As Boolean
        Try
            Dim arParams(19) As SqlParameter

            Dim parameterVendor As New SqlParameter("@VN_CODE", SqlDbType.VarChar)
            parameterVendor.Value = Vendor
            arParams(0) = parameterVendor

            Dim parameterContact As New SqlParameter("@VC_CODE", SqlDbType.VarChar)
            parameterContact.Value = Contact
            arParams(1) = parameterContact

            Dim paramVC_FNAME As New SqlParameter("@VC_FNAME", SqlDbType.VarChar)
            paramVC_FNAME.Value = First
            arParams(2) = paramVC_FNAME

            Dim paramVC_LNAME As New SqlParameter("@VC_LNAME", SqlDbType.VarChar)
            paramVC_LNAME.Value = Last
            arParams(3) = paramVC_LNAME

            Dim paramVC_MI As New SqlParameter("@VC_MI", SqlDbType.VarChar)
            paramVC_MI.Value = MI
            arParams(4) = paramVC_MI

            Dim paramVC_TITLE As New SqlParameter("@VC_TITLE", SqlDbType.VarChar)
            paramVC_TITLE.Value = Title
            arParams(5) = paramVC_TITLE

            Dim paramVC_ADDRESS1 As New SqlParameter("@VC_ADDRESS1", SqlDbType.VarChar)
            paramVC_ADDRESS1.Value = Address1
            arParams(6) = paramVC_ADDRESS1

            Dim paramVC_ADDRESS2 As New SqlParameter("@VC_ADDRESS2", SqlDbType.VarChar)
            paramVC_ADDRESS2.Value = Address2
            arParams(7) = paramVC_ADDRESS2

            Dim paramVC_CITY As New SqlParameter("@VC_CITY", SqlDbType.VarChar)
            paramVC_CITY.Value = City
            arParams(8) = paramVC_CITY

            Dim paramVC_COUNTY As New SqlParameter("@VC_COUNTY", SqlDbType.VarChar)
            paramVC_COUNTY.Value = County
            arParams(9) = paramVC_COUNTY

            Dim paramVC_STATE As New SqlParameter("@VC_STATE", SqlDbType.VarChar)
            paramVC_STATE.Value = State
            arParams(10) = paramVC_STATE

            Dim paramVC_COUNTRY As New SqlParameter("@VC_COUNTRY", SqlDbType.VarChar)
            paramVC_COUNTRY.Value = Country
            arParams(11) = paramVC_COUNTRY

            Dim paramVC_ZIP As New SqlParameter("@VC_ZIP", SqlDbType.VarChar)
            paramVC_ZIP.Value = Zip
            arParams(12) = paramVC_ZIP

            Dim paramVC_TELEPHONE As New SqlParameter("@VC_TELEPHONE", SqlDbType.VarChar)
            paramVC_TELEPHONE.Value = Telephone
            arParams(13) = paramVC_TELEPHONE

            Dim paramVC_EXTENTION As New SqlParameter("@VC_EXTENTION", SqlDbType.VarChar)
            paramVC_EXTENTION.Value = TelephoneExt
            arParams(14) = paramVC_EXTENTION

            Dim paramVC_FAX As New SqlParameter("@VC_FAX", SqlDbType.VarChar)
            paramVC_FAX.Value = Fax
            arParams(15) = paramVC_FAX

            Dim paramVC_FAX_EXTENTION As New SqlParameter("@VC_FAX_EXTENTION", SqlDbType.VarChar)
            paramVC_FAX_EXTENTION.Value = FaxExt
            arParams(16) = paramVC_FAX_EXTENTION

            Dim paramEMAIL_ADDRESS As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar)
            paramEMAIL_ADDRESS.Value = Email
            arParams(17) = paramEMAIL_ADDRESS

            Dim paramVC_PHONE_CELL As New SqlParameter("@VC_PHONE_CELL", SqlDbType.VarChar)
            paramVC_PHONE_CELL.Value = Cell
            arParams(18) = paramVC_PHONE_CELL

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Vendor_UpdateContact", arParams)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

    Public Sub New(Optional ByVal ConnectionString As String = "", Optional ByVal UserID As String = "")
        'mConnString = ConnectionString
        'mUserID = UserID
        mConnString = CStr(HttpContext.Current.Session("ConnString"))
        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = CStr(HttpContext.Current.Session("UserCode"))
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
    End Sub

End Class
