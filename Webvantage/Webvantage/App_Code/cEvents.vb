Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

<Serializable()> Public Class cEvents
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper


#Region " Generator "

    Public Function EventGenDelete(ByVal EventGenId As Integer) As Integer
        Try
            Dim arParams(1) As SqlParameter
            Dim pEVENT_GEN_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(0) = pEVENT_GEN_ID

            Return CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_DELETE", arParams), Integer)

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function EventGenAddNew(ByVal EventGenLabel As String, ByVal EventgenDescLong As String, ByVal EventType As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
                                   ByVal StartTime As String, ByVal EndTime As String,
                                   ByVal Occur As Integer, ByVal DayIncrement As Integer, ByVal Days As String, ByVal QuantyHours As Decimal, ByVal AllDay As Boolean, ByVal JobNumber As Integer,
                                   ByVal JobComponentNbr As Integer, ByVal EstNumber As Integer, ByVal EstComponentNbr As Integer, ByVal EstQuoteNumber As Integer, ByVal FncCode As String, ByVal AdNumber As String,
                                   ByVal CreateDate As DateTime, ByVal CreateUser As String, ByVal GenerateDate As String, ByVal GenerateUser As String,
                                   ByVal AddAdditional As Integer, ByVal EstRevNbr As Integer, ByVal EventGenId As Integer, ByVal QtyType As Integer,
                                   ByVal EventTypeId As Integer) As String
        Try
            Dim arParams(27) As SqlParameter

            Dim pEVENT_GEN_LABEL As New SqlParameter("@EVENT_GEN_LABEL", SqlDbType.VarChar, 50)
            pEVENT_GEN_LABEL.Value = EventGenLabel
            arParams(0) = pEVENT_GEN_LABEL

            Dim pEVENT_GEN_DESC_LONG As New SqlParameter("@EVENT_GEN_DESC_LONG", SqlDbType.Text)
            pEVENT_GEN_DESC_LONG.Value = EventgenDescLong
            arParams(1) = pEVENT_GEN_DESC_LONG

            Dim pTYPE As New SqlParameter("@TYPE", SqlDbType.VarChar, 6)
            pTYPE.Value = EventType
            arParams(2) = pTYPE

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime, 26)
            pSTART_DATE.Value = Convert.ToDateTime(StartDate)
            arParams(3) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime, 26)
            If EndDate = Nothing Then
                pEND_DATE.Value = System.DBNull.Value
            Else
                pEND_DATE.Value = Convert.ToDateTime(EndDate)
            End If
            arParams(4) = pEND_DATE

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime, 26)
            If StartTime = "" Then
                pSTART_TIME.Value = System.DBNull.Value
            Else
                pSTART_TIME.Value = Convert.ToDateTime(StartTime)
            End If
            arParams(5) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime, 26)
            pEND_TIME.Value = Convert.ToDateTime(EndTime)
            arParams(6) = pEND_TIME

            Dim pOCCUR As New SqlParameter("@OCCUR", SqlDbType.Int)
            If Occur <= 0 Then
                pOCCUR.Value = System.DBNull.Value
            Else
                pOCCUR.Value = Occur
            End If
            arParams(7) = pOCCUR

            Dim pDAY_INCREMENT As New SqlParameter("@DAY_INCREMENT", SqlDbType.Int)
            If DayIncrement <= 0 Then
                pDAY_INCREMENT.Value = System.DBNull.Value
            Else
                pDAY_INCREMENT.Value = DayIncrement
            End If
            arParams(8) = pDAY_INCREMENT

            Dim pDAYS As New SqlParameter("@DAYS", SqlDbType.VarChar, 50)
            If Days.Trim() = "" Then
                pDAYS.Value = System.DBNull.Value
            Else
                pDAYS.Value = Days
            End If
            arParams(9) = pDAYS

            Dim pQTY_HOURS As New SqlParameter("@QTY_HOURS", SqlDbType.Decimal)
            If QuantyHours <= 0 Then
                pQTY_HOURS.Value = System.DBNull.Value
            Else
                pQTY_HOURS.Value = QuantyHours
            End If
            arParams(10) = pQTY_HOURS

            Dim pALL_DAY As New SqlParameter("@ALL_DAY", SqlDbType.Bit)
            If AllDay = True Then
                pALL_DAY.Value = 1
            Else
                pALL_DAY.Value = 0
            End If
            arParams(11) = pALL_DAY

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            If JobNumber > 0 Then
                pJOB_NUMBER.Value = JobNumber
            Else
                pJOB_NUMBER.Value = System.DBNull.Value
            End If
            arParams(12) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If JobComponentNbr > 0 Then
                pJOB_COMPONENT_NBR.Value = JobComponentNbr
            Else
                pJOB_COMPONENT_NBR.Value = System.DBNull.Value
            End If
            arParams(13) = pJOB_COMPONENT_NBR

            Dim pEST_NUMBER As New SqlParameter("@EST_NUMBER", SqlDbType.Int)
            If EstNumber > 0 Then
                pEST_NUMBER.Value = EstNumber
            Else
                pEST_NUMBER.Value = System.DBNull.Value
            End If
            arParams(14) = pEST_NUMBER

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            If EstComponentNbr > 0 Then
                pEST_COMPONENT_NBR.Value = EstComponentNbr
            Else
                pEST_COMPONENT_NBR.Value = System.DBNull.Value
            End If
            arParams(15) = pEST_COMPONENT_NBR

            Dim pEST_QUOTE_NUMBER As New SqlParameter("@EST_QUOTE_NUMBER", SqlDbType.SmallInt)
            If EstQuoteNumber > 0 Then
                pEST_QUOTE_NUMBER.Value = EstQuoteNumber
            Else
                pEST_QUOTE_NUMBER.Value = System.DBNull.Value
            End If
            arParams(16) = pEST_QUOTE_NUMBER

            'NEXT TWO PROBABLY NEED SOME KIND OF VALIDATION?
            Dim pFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            pFNC_CODE.Value = FncCode
            arParams(17) = pFNC_CODE

            Dim pAD_NUMBER As New SqlParameter("@AD_NUMBER", SqlDbType.VarChar, 30)
            If AdNumber = "" Then
                pAD_NUMBER.Value = System.DBNull.Value
            Else
                pAD_NUMBER.Value = AdNumber
            End If
            arParams(18) = pAD_NUMBER

            Dim pCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime, 26)
            pCREATE_DATE.Value = Convert.ToDateTime(CreateDate)
            arParams(19) = pCREATE_DATE

            Dim pCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar, 100)
            pCREATE_USER.Value = CreateUser
            arParams(20) = pCREATE_USER

            Dim pGENERATE_DATE As New SqlParameter("@GENERATE_DATE", SqlDbType.SmallDateTime, 26)
            pGENERATE_DATE.Value = Convert.ToDateTime(GenerateDate)
            arParams(21) = pGENERATE_DATE

            Dim pGENERATE_USER As New SqlParameter("@GENERATE_USER", SqlDbType.VarChar, 100)
            pGENERATE_USER.Value = GenerateUser
            arParams(22) = pGENERATE_USER

            'Pass in 0 to trigger only update to event gen table
            'Pass in 1 to also insert to ESTIMATE_REV_DET
            '   Be sure param below is greater than zero
            Dim pADD_ADDITIONAL As New SqlParameter("@ADD_ADDITIONAL", SqlDbType.Int)
            pADD_ADDITIONAL.Value = AddAdditional
            arParams(23) = pADD_ADDITIONAL

            'Pass in zero to bypass adding to ESTIMATE_REV_DET...this will short out the param above
            Dim pEST_REV_NUMBER As New SqlParameter("@EST_REV_NUMBER", SqlDbType.Int)
            pEST_REV_NUMBER.Value = EstRevNbr
            arParams(24) = pEST_REV_NUMBER

            'insert or update based on passed in event gen id:
            Dim pEVENT_GEN_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(25) = pEVENT_GEN_ID

            Dim pQTY_TYPE As New SqlParameter("@QTY_TYPE", SqlDbType.SmallInt)
            pQTY_TYPE.Value = QtyType
            arParams(26) = pQTY_TYPE

            Dim pEVENT_TYPE_ID As New SqlParameter("@EVENT_TYPE_ID", SqlDbType.SmallInt)
            If EventTypeId <= 0 Then
                pEVENT_TYPE_ID.Value = System.DBNull.Value
            Else
                pEVENT_TYPE_ID.Value = EventTypeId
            End If
            arParams(27) = pEVENT_TYPE_ID


            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_INSERT", arParams)
            Return i.ToString()

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function EventGenUpdate(ByVal EventGenId As Integer, ByVal EventGenLabel As String, ByVal EventgenDescLong As String, ByVal EventType As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
                                 ByVal StartTime As String, ByVal EndTime As String,
                                 ByVal Occur As Integer, ByVal DayIncrement As Integer, ByVal Days As String, ByVal QuantyHours As Decimal,
                                 ByVal FncCode As String, ByVal AdNumber As String, ByVal QtyType As Integer,
                                 ByVal EventTypeId As Integer) As String
        Try
            Dim arParams(16) As SqlParameter

            Dim pEVENT_GEN_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(0) = pEVENT_GEN_ID

            Dim pEVENT_GEN_LABEL As New SqlParameter("@EVENT_GEN_LABEL", SqlDbType.VarChar, 50)
            pEVENT_GEN_LABEL.Value = EventGenLabel
            arParams(1) = pEVENT_GEN_LABEL

            Dim pEVENT_GEN_DESC_LONG As New SqlParameter("@EVENT_GEN_DESC_LONG", SqlDbType.Text)
            pEVENT_GEN_DESC_LONG.Value = EventgenDescLong
            arParams(2) = pEVENT_GEN_DESC_LONG

            Dim pTYPE As New SqlParameter("@TYPE", SqlDbType.VarChar, 6)
            pTYPE.Value = EventType
            arParams(3) = pTYPE

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime, 26)
            pSTART_DATE.Value = Convert.ToDateTime(StartDate)
            arParams(4) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime, 26)
            If EndDate = Nothing Then
                pEND_DATE.Value = System.DBNull.Value
            Else
                pEND_DATE.Value = Convert.ToDateTime(EndDate)
            End If
            arParams(5) = pEND_DATE

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime, 26)
            If StartTime = "" Then
                pSTART_TIME.Value = System.DBNull.Value
            Else
                pSTART_TIME.Value = Convert.ToDateTime(StartTime)
            End If
            arParams(6) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime, 26)
            pEND_TIME.Value = Convert.ToDateTime(EndTime)
            arParams(7) = pEND_TIME

            Dim pOCCUR As New SqlParameter("@OCCUR", SqlDbType.Int)
            pOCCUR.Value = Occur
            arParams(8) = pOCCUR

            Dim pDAY_INCREMENT As New SqlParameter("@DAY_INCREMENT", SqlDbType.Int)
            pDAY_INCREMENT.Value = DayIncrement
            arParams(9) = pDAY_INCREMENT

            Dim pDAYS As New SqlParameter("@DAYS", SqlDbType.VarChar, 50)
            pDAYS.Value = Days
            arParams(10) = pDAYS

            Dim pQTY_HOURS As New SqlParameter("@QTY_HOURS", SqlDbType.Decimal)
            If QuantyHours < 0 Then
                pQTY_HOURS.Value = System.DBNull.Value
            Else
                pQTY_HOURS.Value = QuantyHours
            End If
            arParams(11) = pQTY_HOURS

            'NEXT TWO PROBABLY NEED SOME KIND OF VALIDATION?
            Dim pFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            pFNC_CODE.Value = FncCode
            arParams(12) = pFNC_CODE

            Dim pAD_NUMBER As New SqlParameter("@AD_NUMBER", SqlDbType.VarChar, 30)
            If AdNumber = "" Then
                pAD_NUMBER.Value = System.DBNull.Value
            Else
                pAD_NUMBER.Value = AdNumber
            End If
            arParams(13) = pAD_NUMBER

            Dim pQTY_TYPE As New SqlParameter("@QTY_TYPE", SqlDbType.SmallInt)
            pQTY_TYPE.Value = QtyType
            arParams(14) = pQTY_TYPE

            Dim pEVENT_TYPE_ID As New SqlParameter("@EVENT_TYPE_ID", SqlDbType.SmallInt)
            If EventTypeId <= 0 Then
                pEVENT_TYPE_ID.Value = System.DBNull.Value
            Else
                pEVENT_TYPE_ID.Value = EventTypeId
            End If
            arParams(15) = pEVENT_TYPE_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_UPDATE", arParams)

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function EventGenGetListByDate(ByVal StartDate As Date, ByVal EndDate As Date) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartDate
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndDate
            arParams(1) = pEND_DATE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_GET_LIST_BY_DATE", "DtJobCompEvents", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function EventGenGetList(ByVal EstNumber As Integer, ByVal EstComponentNbr As Integer, ByVal EstQuoteNbr As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arParams(5) As SqlParameter
            Dim pEST_NUMBER As New SqlParameter("@EST_NUMBER", SqlDbType.Int)
            pEST_NUMBER.Value = EstNumber
            arParams(0) = pEST_NUMBER

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            pEST_COMPONENT_NBR.Value = EstComponentNbr
            arParams(1) = pEST_COMPONENT_NBR

            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NUMBER", SqlDbType.SmallInt)
            pEST_QUOTE_NBR.Value = EstQuoteNbr
            arParams(2) = pEST_QUOTE_NBR

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(3) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(4) = pJOB_COMPONENT_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_EST_GET_LIST", "DtJobCompEvents", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function EventGenGetList(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_JC_GET_LIST", "DtJobCompEvents", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EventGenGetDetails(ByVal EventGenId As Integer) As DataTable
        Try
            Dim arParams(1) As SqlParameter
            Dim pEVENT_GEN_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(0) = pEVENT_GEN_ID

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GEN_GET_DETAILS", "DtEventGenDetails", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#End Region

#Region " Events "

    Public Function EventAddNew(ByVal EventGenLabel As String, ByVal EventgenDescLong As String, ByVal EventType As String, ByVal EventDate As DateTime,
                                   ByVal AllDay As Boolean, ByVal QuantyHours As Decimal, ByVal StartTime As String, ByVal EndTime As String,
                                   ByVal ResourceCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                                   ByVal FncCode As String, ByVal AdNumber As String, ByVal EventComment As String, ByVal IncomeOnlyId As Integer,
                                   ByVal EventGenId As Integer, ByVal CreateDate As DateTime, ByVal CreateUser As String, ByVal QtyType As Integer,
                                   ByVal EventTypeId As Integer) As String
        Try
            Dim arParams(20) As SqlParameter

            Dim pEVENT_GEN_LABEL As New SqlParameter("@EVENT_LABEL", SqlDbType.VarChar, 50)
            pEVENT_GEN_LABEL.Value = EventGenLabel
            arParams(0) = pEVENT_GEN_LABEL

            Dim pEVENT_GEN_DESC_LONG As New SqlParameter("@EVENT_DESC_LONG", SqlDbType.Text)
            pEVENT_GEN_DESC_LONG.Value = EventgenDescLong
            arParams(1) = pEVENT_GEN_DESC_LONG

            Dim pTYPE As New SqlParameter("@TYPE", SqlDbType.VarChar, 6)
            pTYPE.Value = EventType
            arParams(2) = pTYPE

            Dim pSTART_DATE As New SqlParameter("@EVENT_DATE", SqlDbType.SmallDateTime, 26)
            pSTART_DATE.Value = Convert.ToDateTime(EventDate)
            arParams(3) = pSTART_DATE

            Dim pALL_DAY As New SqlParameter("@ALL_DAY", SqlDbType.Bit)
            If AllDay = True Then
                pALL_DAY.Value = 1
            Else
                pALL_DAY.Value = 0
            End If
            arParams(4) = pALL_DAY

            Dim pQTY_HOURS As New SqlParameter("@QTY_HRS", SqlDbType.Decimal)
            pQTY_HOURS.Value = QuantyHours
            arParams(5) = pQTY_HOURS

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime, 26)
            If StartTime = "" Then
                pSTART_TIME.Value = System.DBNull.Value
            Else
                pSTART_TIME.Value = Convert.ToDateTime(StartTime)
            End If
            arParams(6) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime, 26)
            If EndTime = "" Then
                pEND_TIME.Value = System.DBNull.Value
            Else
                pEND_TIME.Value = Convert.ToDateTime(EndTime)

            End If
            arParams(7) = pEND_TIME

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            If ResourceCode.Trim() = "" Then
                pRESOURCE_CODE.Value = System.DBNull.Value
            Else
                pRESOURCE_CODE.Value = ResourceCode
            End If
            arParams(8) = pRESOURCE_CODE

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            If JobNumber > 0 Then
                pJOB_NUMBER.Value = JobNumber
            Else
                pJOB_NUMBER.Value = System.DBNull.Value
            End If
            arParams(9) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If JobComponentNbr > 0 Then
                pJOB_COMPONENT_NBR.Value = JobComponentNbr
            Else
                pJOB_COMPONENT_NBR.Value = System.DBNull.Value
            End If
            arParams(10) = pJOB_COMPONENT_NBR

            'NEXT TWO PROBABLY NEED SOME KIND OF VALIDATION?
            Dim pFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            pFNC_CODE.Value = FncCode
            arParams(11) = pFNC_CODE

            Dim pAD_NUMBER As New SqlParameter("@AD_NUMBER", SqlDbType.VarChar, 30)
            If AdNumber = "" Then
                pAD_NUMBER.Value = System.DBNull.Value
            Else
                pAD_NUMBER.Value = AdNumber
            End If
            arParams(12) = pAD_NUMBER

            Dim pEVENT_COMMENT As New SqlParameter("@EVENT_COMMENT", SqlDbType.Text)
            pEVENT_COMMENT.Value = EventgenDescLong
            arParams(13) = pEVENT_COMMENT

            Dim pINCOME_ONLY_ID As New SqlParameter("@INCOME_ONLY_ID", SqlDbType.Int)
            If IncomeOnlyId > 0 Then
                pINCOME_ONLY_ID.Value = IncomeOnlyId
            Else
                pINCOME_ONLY_ID.Value = System.DBNull.Value
            End If
            arParams(14) = pINCOME_ONLY_ID

            Dim pEVENT_GEN_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pEVENT_GEN_ID.Value = EventGenId
            arParams(15) = pEVENT_GEN_ID

            Dim pCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime, 26)
            pCREATE_DATE.Value = Convert.ToDateTime(Now)
            arParams(16) = pCREATE_DATE

            Dim pCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar, 100)
            pCREATE_USER.Value = Me.mUserID
            arParams(17) = pCREATE_USER

            Dim pQTY_TYPE As New SqlParameter("@QTY_TYPE", SqlDbType.SmallInt)
            pQTY_TYPE.Value = QtyType
            arParams(18) = pQTY_TYPE

            Dim pEVENT_TYPE_ID As New SqlParameter("@EVENT_TYPE_ID", SqlDbType.SmallInt)
            If EventTypeId <= 0 Then
                pEVENT_TYPE_ID.Value = System.DBNull.Value
            Else
                pEVENT_TYPE_ID.Value = EventTypeId
            End If
            arParams(19) = pEVENT_TYPE_ID

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_INSERT", arParams)
            Return i.ToString()




            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function EventUpdate(ByVal EventId As Integer, ByVal EventGenLabel As String, ByVal EventGenDescLong As String, ByVal EventDate As DateTime,
                                ByVal QuantyHours As Decimal, ByVal StartTime As String, ByVal EndTime As String,
                                ByVal ResourceCode As String, ByVal AdNumber As String, ByVal EventComment As String, ByVal IncomeOnlyId As Integer, ByVal QtyType As Integer,
                                ByVal EventTypeId As Integer) As String
        Try
            Dim arParams(15) As SqlParameter

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(0) = pEVENT_ID

            Dim pEVENT_GEN_LABEL As New SqlParameter("@EVENT_LABEL", SqlDbType.VarChar, 50)
            pEVENT_GEN_LABEL.Value = EventGenLabel
            arParams(1) = pEVENT_GEN_LABEL

            Dim pEVENT_GEN_DESC_LONG As New SqlParameter("@EVENT_DESC_LONG", SqlDbType.Text)
            If EventGenDescLong.Trim() = "" Then
                pEVENT_GEN_DESC_LONG.Value = System.DBNull.Value
            Else
                pEVENT_GEN_DESC_LONG.Value = EventGenDescLong
            End If
            arParams(2) = pEVENT_GEN_DESC_LONG

            Dim pSTART_DATE As New SqlParameter("@EVENT_DATE", SqlDbType.SmallDateTime, 26)
            pSTART_DATE.Value = Convert.ToDateTime(EventDate)
            arParams(3) = pSTART_DATE

            Dim pQTY_HOURS As New SqlParameter("@QTY_HRS", SqlDbType.Decimal)
            pQTY_HOURS.Value = QuantyHours
            arParams(4) = pQTY_HOURS

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime, 26)
            If StartTime = "" Then
                pSTART_TIME.Value = System.DBNull.Value
            Else
                pSTART_TIME.Value = Convert.ToDateTime(StartTime)
            End If
            arParams(5) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime, 26)
            If EndTime = "" Then
                pEND_TIME.Value = System.DBNull.Value
            Else
                pEND_TIME.Value = Convert.ToDateTime(EndTime)

            End If
            arParams(6) = pEND_TIME

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            If ResourceCode.Trim() = "" Then
                pRESOURCE_CODE.Value = System.DBNull.Value
            Else
                pRESOURCE_CODE.Value = ResourceCode
            End If
            arParams(7) = pRESOURCE_CODE


            Dim pAD_NUMBER As New SqlParameter("@AD_NUMBER", SqlDbType.VarChar, 30)
            If AdNumber = "" Then
                pAD_NUMBER.Value = System.DBNull.Value
            Else
                pAD_NUMBER.Value = AdNumber
            End If
            arParams(8) = pAD_NUMBER

            Dim pEVENT_COMMENT As New SqlParameter("@EVENT_COMMENT", SqlDbType.Text)
            If EventComment.Trim() = "" Then
                pEVENT_COMMENT.Value = System.DBNull.Value
            Else
                pEVENT_COMMENT.Value = EventComment
            End If
            arParams(9) = pEVENT_COMMENT

            Dim pINCOME_ONLY_ID As New SqlParameter("@INCOME_ONLY_ID", SqlDbType.Int)
            If IncomeOnlyId > 0 Then
                pINCOME_ONLY_ID.Value = IncomeOnlyId
            Else
                pINCOME_ONLY_ID.Value = System.DBNull.Value
            End If
            arParams(10) = pINCOME_ONLY_ID

            Dim pMODIFY_DATE As New SqlParameter("@MODIFY_DATE", SqlDbType.SmallDateTime, 26)
            pMODIFY_DATE.Value = Convert.ToDateTime(Now)
            arParams(11) = pMODIFY_DATE

            Dim pMODIFY_USER As New SqlParameter("@MODIFY_USER", SqlDbType.VarChar, 100)
            pMODIFY_USER.Value = Me.mUserID
            arParams(12) = pMODIFY_USER

            Dim pQTY_TYPE As New SqlParameter("@QTY_TYPE", SqlDbType.SmallInt)
            pQTY_TYPE.Value = QtyType
            arParams(13) = pQTY_TYPE

            Dim pEVENT_TYPE_ID As New SqlParameter("@EVENT_TYPE_ID", SqlDbType.SmallInt)
            If EventTypeId <= 0 Then
                pEVENT_TYPE_ID.Value = System.DBNull.Value
            Else
                pEVENT_TYPE_ID.Value = EventTypeId
            End If
            arParams(14) = pEVENT_TYPE_ID

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_UPDATE", arParams)
            Return i.ToString()




            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Overloads Function EventGetDetails(ByVal StartDate As Date, ByVal EndDate As Date, ByVal ReturnListType As String, ByVal OnlyEventsWithoutResource As Boolean,
                                              Optional ByVal GeneratorId As Integer = 0, Optional ByVal AdNbr As String = "", Optional ByRef NavigationString As String = "") As DataTable
        Try
            AdNbr = AdNbr.Trim()

            Dim arParams(7) As SqlParameter

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.VarChar, 10)
            pSTART_DATE.Value = StartDate.ToShortDateString()
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.VarChar, 10)
            pEND_DATE.Value = EndDate.ToShortDateString()
            arParams(1) = pEND_DATE

            Dim pGENERATOR_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pGENERATOR_ID.Value = GeneratorId
            arParams(2) = pGENERATOR_ID

            Dim pAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
            If AdNbr <> "" Then
                pAD_NBR.Value = AdNbr
            Else
                pAD_NBR.Value = System.DBNull.Value
            End If
            arParams(3) = pAD_NBR

            Dim pRETURN_LIST_TYPE As New SqlParameter("@RETURN_LIST_TYPE", SqlDbType.VarChar, 10)
            pRETURN_LIST_TYPE.Value = ReturnListType 'for now: jc or date
            arParams(4) = pRETURN_LIST_TYPE

            Dim pONLY_EVENTS_WITH_NO_RESOURCES As New SqlParameter("@ONLY_EVENTS_WITH_NO_RESOURCES", SqlDbType.TinyInt)
            pONLY_EVENTS_WITH_NO_RESOURCES.Value = MiscFN.BoolToInt(OnlyEventsWithoutResource)
            arParams(5) = pONLY_EVENTS_WITH_NO_RESOURCES

            Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
            paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
            arParams(6) = paramTask_UserCode

            Dim ds As New DataSet
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GET_BY_DATE", arParams)

            If ds.Tables(1).Rows.Count > 0 Then
                If ds.Tables(1).Rows.Count = 1 Then
                    NavigationString = ds.Tables(1).Rows(0)("NAV_LIST").ToString()
                Else
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        NavigationString &= ds.Tables(1).Rows(i)("NAV_LIST") & ","
                    Next
                    NavigationString = MiscFN.CleanStringForSplit(NavigationString, ",")
                End If
            Else
                NavigationString = ""
            End If

            Return ds.Tables(0)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function EventGetDetails(ByVal EventId As Integer) As DataSet
        Try
            Dim arParams(1) As SqlParameter
            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(0) = pEVENT_ID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_GET_DETAILS", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function EventGetDetails(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal CutoffDate As DateTime, ByVal GeneratorId As Integer, ByVal AdNbr As String) As DataTable
        Try
            AdNbr = AdNbr.Trim()

            Dim arParams(5) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Dim pCUT_OFF_DATE As New SqlParameter("@CUT_OFF_DATE", SqlDbType.VarChar, 10)
            Dim s As String = CutoffDate.ToString()
            If CutoffDate = Nothing Then
                pCUT_OFF_DATE.Value = System.DBNull.Value
            Else
                pCUT_OFF_DATE.Value = CutoffDate.ToShortDateString()
            End If
            arParams(2) = pCUT_OFF_DATE

            Dim pGENERATOR_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pGENERATOR_ID.Value = GeneratorId
            arParams(3) = pGENERATOR_ID

            Dim pAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
            If AdNbr <> "" Then
                pAD_NBR.Value = AdNbr
            Else
                pAD_NBR.Value = System.DBNull.Value
            End If
            arParams(4) = pAD_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_JC_GET_DETAILS", "DtJobCompEvents", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EventGetEventsThatNeedResources(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal CutoffDate As DateTime, ByVal GeneratorId As Integer) As DataSet
        Try
            Dim arParams(4) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Dim pCUT_OFF_DATE As New SqlParameter("@CUT_OFF_DATE", SqlDbType.VarChar, 10)
            If CutoffDate = Nothing Then
                pCUT_OFF_DATE.Value = System.DBNull.Value
            Else
                pCUT_OFF_DATE.Value = CutoffDate.ToShortDateString()
            End If
            arParams(2) = pCUT_OFF_DATE

            Dim pGENERATOR_ID As New SqlParameter("@EVENT_GEN_ID", SqlDbType.Int)
            pGENERATOR_ID.Value = GeneratorId
            arParams(3) = pGENERATOR_ID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_JC_NEED_RSC", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EventUpdateResource(ByVal EventId As Integer, ByVal ResourceCode As String, ByVal UpdateEventResource As Boolean, ByVal DeleteAllExistingTasks As Boolean, ByVal DeleteGeneratedTasks As Boolean) As String
        Try
            Dim arParams(5) As SqlParameter

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(0) = pEVENT_ID

            Dim pRESOURCE_CODE As New SqlParameter("@RESOURCE_CODE", SqlDbType.VarChar, 6)
            If ResourceCode.Trim() = "" Or ResourceCode.Trim() = "none" Then
                pRESOURCE_CODE.Value = System.DBNull.Value
            Else
                pRESOURCE_CODE.Value = ResourceCode
            End If
            arParams(1) = pRESOURCE_CODE

            Dim pUPDATE_EVENT_RESOURCE As New SqlParameter("@UPDATE_EVENT_RESOURCE", SqlDbType.Bit)
            If UpdateEventResource = True Then
                pUPDATE_EVENT_RESOURCE.Value = 1
            Else
                pUPDATE_EVENT_RESOURCE.Value = 0
            End If
            arParams(2) = pUPDATE_EVENT_RESOURCE

            Dim pDELETE_ALL_EXISTING_TASKS As New SqlParameter("@DELETE_ALL_EXISTING_TASKS", SqlDbType.Bit)
            If DeleteAllExistingTasks = True Then
                pDELETE_ALL_EXISTING_TASKS.Value = 1
            Else
                pDELETE_ALL_EXISTING_TASKS.Value = 0
            End If
            arParams(3) = pDELETE_ALL_EXISTING_TASKS

            Dim pDELETE_GENERATED_TASKS As New SqlParameter("@DELETE_GENERATED_TASKS", SqlDbType.Bit)
            If DeleteGeneratedTasks = True Then
                pDELETE_GENERATED_TASKS.Value = 1
            Else
                pDELETE_GENERATED_TASKS.Value = 0
            End If
            'Override: if deleting all tasks, this param doesn't need to fire in the script...
            If DeleteAllExistingTasks = True Then
                pDELETE_GENERATED_TASKS.Value = 0
            End If
            arParams(4) = pDELETE_GENERATED_TASKS


            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_UPDATE_RESOURCE", arParams)

        Catch ex As Exception

        End Try
    End Function

    Public Function GetDistinctAdNumbersByJobComp(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT DISTINCT AD_NUMBER.AD_NBR, AD_NBR + ' - ' + AD_NUMBER.AD_NBR_DESC AS AD_NBR_DESC FROM [EVENT] WITH(NOLOCK) INNER JOIN  AD_NUMBER WITH(NOLOCK) ON [EVENT].AD_NUMBER = AD_NUMBER.AD_NBR WHERE ([EVENT].JOB_NUMBER = ")
            .Append(JobNumber.ToString())
            .Append(") AND ([EVENT].JOB_COMPONENT_NBR = ")
            .Append(JobComponentNbr.ToString())
            .Append(") ORDER BY AD_NUMBER.AD_NBR;")
        End With
        Try
            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL.ToString(), "DtAdNumbers")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetAdNumbers() As DataTable
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT AD_NBR, AD_NBR_DESC FROM AD_NUMBER WHERE [ACTIVE] IS NULL OR [ACTIVE] = 1 ORDER BY AD_NBR, AD_NBR_DESC;")
        End With
        Try
            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL.ToString(), "DtAdNumbers")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetAdNumbers(ByVal StartDate As Date, ByVal EndDate As Date, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arParams(4) As SqlParameter

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            If StartDate = Nothing Then
                pSTART_DATE.Value = System.DBNull.Value
            Else
                pSTART_DATE.Value = StartDate
            End If
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            If EndDate = Nothing Then
                pEND_DATE.Value = System.DBNull.Value
            Else
                pEND_DATE.Value = EndDate
            End If
            arParams(1) = pEND_DATE

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(2) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(3) = pJOB_COMPONENT_NBR

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_AD_NUMBER_GET_BY_DATE_OR_JC", "DtAdNumbers", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#End Region

#Region " Tasks "

    'Get tasks by date for Scheduler_EventTasks
    Public Function GetEventTasks(ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Try
            Dim arParams(3) As SqlParameter
            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartDate
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndDate
            arParams(1) = pEND_DATE

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = HttpContext.Current.Session("UserCode")
            arParams(2) = parameterUserID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_TASKS_GET_BY_DATE_RANGE", arParams)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    'Get a single task
    Public Function TaskGetDetails(ByVal EventTaskId As Integer) As DataTable
        Try
            Dim arParams(1) As SqlParameter
            Dim pEVENT_TASK_ID As New SqlParameter("@EVENT_TASK_ID", SqlDbType.Int)
            pEVENT_TASK_ID.Value = EventTaskId
            arParams(0) = pEVENT_TASK_ID

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_TASK_GET_DETAILS", "DtEventTasks", arParams)


        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    'Add task to EVENT_TASK table
    Public Function TaskAddNew(ByVal EventId As Integer, ByVal TaskCode As String, ByVal EmpCode As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
                               ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal TempCompDate As DateTime, ByVal HoursAllowed As Decimal,
                               ByVal Comments As String, ByVal CompletedComments As String) As String
        Try
            'Make sure end date has full datetime:
            Try
                Dim temp As String = StartDate.ToShortDateString() & " " & StartTime.ToShortTimeString()
                StartDate = Convert.ToDateTime(temp)
            Catch ex As Exception
            End Try

            'Fix the end time and end date
            Dim TheHours As Decimal = 0.0
            Try
                Dim ts As TimeSpan
                ts = EndTime.Subtract(StartTime)
                TheHours = CType(ts.TotalHours, Decimal)
            Catch ex As Exception
                TheHours = CType(0.0, Decimal)
            End Try
            If TheHours <= 0.0 Then 'end time needs to go to next day:
                TheHours = TheHours + 24
                EndTime = DateAdd(DateInterval.Day, 1, EndTime)
            End If

            EndDate = EndTime

            'set the hours allowed on save...but only if the user did not input one?:
            If HoursAllowed = 0 Then
                HoursAllowed = TheHours
            End If


            Dim arParams(11) As SqlParameter

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(0) = pEVENT_ID

            Dim pTASK_CODE As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            pTASK_CODE.Value = TaskCode
            arParams(1) = pTASK_CODE

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            If EmpCode.Trim() = "" Or EmpCode = Nothing Or EmpCode = String.Empty Then
                pEMP_CODE.Value = System.DBNull.Value
            Else
                pEMP_CODE.Value = EmpCode
            End If
            arParams(2) = pEMP_CODE

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartDate
            arParams(3) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndDate
            arParams(4) = pEND_DATE

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime)
            pSTART_TIME.Value = StartTime
            arParams(5) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime)
            pEND_TIME.Value = EndTime
            arParams(6) = pEND_TIME

            Dim pTEMP_COMP_DATE As New SqlParameter("@TEMP_COMP_DATE", SqlDbType.SmallDateTime)
            If TempCompDate = Nothing Then
                pTEMP_COMP_DATE.Value = System.DBNull.Value
            Else
                pTEMP_COMP_DATE.Value = TempCompDate
            End If
            arParams(7) = pTEMP_COMP_DATE

            Dim pHOURS_ALLOWED As New SqlParameter("@HOURS_ALLOWED", SqlDbType.Decimal)
            pHOURS_ALLOWED.Value = HoursAllowed
            arParams(8) = pHOURS_ALLOWED

            Dim pCOMMENTS As New SqlParameter("@COMMENTS", SqlDbType.Text)
            pCOMMENTS.Value = Comments
            arParams(9) = pCOMMENTS

            Dim pCOMPLETED_COMMENTS As New SqlParameter("@COMPLETED_COMMENTS", SqlDbType.Text)
            pCOMPLETED_COMMENTS.Value = CompletedComments
            arParams(10) = pCOMPLETED_COMMENTS

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_TASK_INSERT", arParams)
            Return i.ToString()


        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    'Update task in EVENT_TASK table
    Public Function TaskUpdate(ByVal EventTaskId As Integer, ByVal EventId As Integer, ByVal TaskCode As String, ByVal EmpCode As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
                               ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal TempCompDate As DateTime, ByVal HoursAllowed As Decimal,
                               ByVal Comments As String, ByVal CompletedComments As String) As String
        Try
            'Make sure end date has full datetime:
            Try
                Dim temp As String = StartDate.ToShortDateString() & " " & StartTime.ToShortTimeString()
                StartDate = Convert.ToDateTime(temp)
            Catch ex As Exception
            End Try


            'Fix the end time and end date
            Dim TheHours As Decimal = 0.0
            Try
                Dim ts As TimeSpan
                ts = EndTime.Subtract(StartTime)
                TheHours = CType(ts.TotalHours, Decimal)
            Catch ex As Exception
                TheHours = CType(0.0, Decimal)
            End Try
            If TheHours <= 0.0 Then 'end time needs to go to next day:
                TheHours = TheHours + 24
                EndTime = DateAdd(DateInterval.Day, 1, EndTime)
            End If

            EndDate = EndTime



            Dim arParams(12) As SqlParameter

            Dim pEVENT_TASK_ID As New SqlParameter("@EVENT_TASK_ID", SqlDbType.Int)
            pEVENT_TASK_ID.Value = EventTaskId
            arParams(0) = pEVENT_TASK_ID

            Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
            pEVENT_ID.Value = EventId
            arParams(1) = pEVENT_ID

            Dim pTASK_CODE As New SqlParameter("@TASK_CODE", SqlDbType.VarChar, 10)
            pTASK_CODE.Value = TaskCode
            arParams(2) = pTASK_CODE

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            If EmpCode.Trim() = "" Then
                pEMP_CODE.Value = System.DBNull.Value
            Else
                pEMP_CODE.Value = EmpCode
            End If
            arParams(3) = pEMP_CODE

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartTime 'StartDate
            arParams(4) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndTime 'EndDate
            arParams(5) = pEND_DATE

            Dim pSTART_TIME As New SqlParameter("@START_TIME", SqlDbType.SmallDateTime)
            pSTART_TIME.Value = StartTime
            arParams(6) = pSTART_TIME

            Dim pEND_TIME As New SqlParameter("@END_TIME", SqlDbType.SmallDateTime)
            pEND_TIME.Value = EndTime
            arParams(7) = pEND_TIME

            Dim pTEMP_COMP_DATE As New SqlParameter("@TEMP_COMP_DATE", SqlDbType.SmallDateTime)
            If TempCompDate = Nothing Then
                pTEMP_COMP_DATE.Value = System.DBNull.Value
            Else
                pTEMP_COMP_DATE.Value = TempCompDate
            End If
            arParams(8) = pTEMP_COMP_DATE

            Dim pHOURS_ALLOWED As New SqlParameter("@HOURS_ALLOWED", SqlDbType.Decimal)
            pHOURS_ALLOWED.Value = HoursAllowed
            arParams(9) = pHOURS_ALLOWED

            Dim pCOMMENTS As New SqlParameter("@COMMENTS", SqlDbType.Text)
            If Comments.Trim() = "" Then
                pCOMMENTS.Value = System.DBNull.Value
            Else
                pCOMMENTS.Value = Comments
            End If
            arParams(10) = pCOMMENTS

            Dim pCOMPLETED_COMMENTS As New SqlParameter("@COMPLETED_COMMENTS", SqlDbType.Text)
            If CompletedComments.Trim() = "" Then
                pCOMPLETED_COMMENTS.Value = System.DBNull.Value
            Else
                pCOMPLETED_COMMENTS.Value = CompletedComments
            End If
            arParams(11) = pCOMPLETED_COMMENTS

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_TASK_UPDATE", arParams)
            Return i.ToString()


        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Private mDtEventTasks As New DataTable

    Public Overloads Function EventTasksDatatable(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_TASKS_GET_DETAILS", "DtEventTasks", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'for quick report
    Public Overloads Function ProjectScheduleTasksDatatable(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arParams(0) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = pJOB_COMPONENT_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetQuickTaskReport", "DtEventTasks", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Overloads Function EventTasksDatatable(ByVal EventId As Integer) As DataTable
        Me.CreateEventTasksDatatable()
        'add real data
        If EventId > 0 Then
            Dim CurrEventTaskId As Integer = 0
            Dim CurrEventId As Integer = 0
            Dim CurrTaskCode As String = ""
            Dim CurrEmpCode As String = ""
            Dim CurrStartDate As DateTime = Nothing
            Dim CurrEndDate As DateTime = Nothing
            Dim CurrStartTime As DateTime = Nothing
            Dim CurrEndTime As DateTime = Nothing
            Dim CurrTempCompDate As DateTime = Nothing
            Dim CurrHoursAllowed As Decimal = 0
            Dim CurrComments As String = ""
            Dim CurrCompletedComments As String = ""

            Dim DtRealData As New DataTable
            DtRealData = EventGetDetails(EventId).Tables(2)
            If DtRealData.Rows.Count > 0 Then
                For i As Integer = 0 To DtRealData.Rows.Count - 1
                    If IsDBNull(DtRealData.Rows(i)("EVENT_TASK_ID")) = False Then
                        CurrEventTaskId = CType(DtRealData.Rows(i)("EVENT_TASK_ID"), Integer)
                    Else
                        CurrEventTaskId = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("EVENT_ID")) = False Then
                        CurrEventId = CType(DtRealData.Rows(i)("EVENT_ID"), Integer)
                    Else
                        CurrEventId = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TASK_CODE")) = False Then
                        CurrTaskCode = DtRealData.Rows(i)("TASK_CODE").ToString()
                    Else
                        CurrTaskCode = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("EMP_CODE")) = False Then
                        CurrEmpCode = DtRealData.Rows(i)("EMP_CODE").ToString()
                    Else
                        CurrEmpCode = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("START_DATE")) = False Then
                        CurrStartDate = Convert.ToDateTime(DtRealData.Rows(i)("START_DATE"))
                    Else
                        CurrStartDate = Nothing
                    End If
                    If IsDBNull(DtRealData.Rows(i)("END_DATE")) = False Then
                        CurrEndDate = Convert.ToDateTime(DtRealData.Rows(i)("END_DATE"))
                    Else
                        CurrEndDate = Nothing
                    End If
                    If IsDBNull(DtRealData.Rows(i)("START_TIME")) = False Then
                        CurrStartTime = Convert.ToDateTime(DtRealData.Rows(i)("START_TIME"))
                    Else
                        CurrStartTime = Nothing
                    End If
                    If IsDBNull(DtRealData.Rows(i)("END_TIME")) = False Then
                        CurrEndTime = Convert.ToDateTime(DtRealData.Rows(i)("END_TIME"))
                    Else
                        CurrEndTime = Nothing
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_COMP_DATE")) = False Then
                        CurrTempCompDate = Convert.ToDateTime(DtRealData.Rows(i)("TEMP_COMP_DATE"))
                    Else
                        CurrTempCompDate = Nothing
                    End If
                    If IsDBNull(DtRealData.Rows(i)("HOURS_ALLOWED")) = False Then
                        CurrHoursAllowed = CType(DtRealData.Rows(i)("HOURS_ALLOWED"), Decimal)
                    Else
                        CurrHoursAllowed = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("COMMENTS")) = False Then
                        CurrComments = DtRealData.Rows(i)("COMMENTS").ToString()
                    Else
                        CurrComments = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("COMPLETED_COMMENTS")) = False Then
                        CurrCompletedComments = DtRealData.Rows(i)("COMPLETED_COMMENTS").ToString()
                    Else
                        CurrCompletedComments = ""
                    End If

                    If CurrEventTaskId > 0 And CurrEventTaskId > 0 Then
                        'add row to datatable
                        EventTasksDatatable_AddRow(mDtEventTasks, CurrEventTaskId, CurrEventId, CurrTaskCode, CurrEmpCode, CurrStartDate, CurrStartTime, CurrEndTime, CurrTempCompDate, CurrHoursAllowed, CurrComments, CurrCompletedComments, False)
                    End If

                Next
            Else
                'add a blank row?
            End If
        End If
        Return mDtEventTasks
    End Function

    Public Function EventTasksDatatable_AddRow(ByRef TheDT As DataTable,
                        ByVal EventTaskId As Integer, ByVal EventId As Integer, ByVal TaskCode As String, ByVal EmpCode As String, ByVal TaskDate As DateTime,
                        ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal TempCompDate As DateTime, ByVal HoursAllowed As Decimal,
                        ByVal Comments As String, ByVal CompletedComments As String, ByVal IsUserRow As Boolean) As String
        Try
            Dim r As DataRow
            r = TheDT.NewRow()

            r("EVENT_TASK_ID") = EventTaskId
            r("EVENT_ID") = EventId
            r("TASK_CODE") = TaskCode
            r("EMP_CODE") = EmpCode
            If Not TaskDate = Nothing Then
                r("EVENT_TASK_DATE") = TaskDate
            End If
            If Not StartTime = Nothing Then
                r("START_TIME") = StartTime
            End If
            If Not EndTime = Nothing Then
                r("END_TIME") = EndTime
            End If
            If Not TempCompDate = Nothing Then
                r("TEMP_COMP_DATE") = TempCompDate
            End If
            r("HOURS_ALLOWED") = HoursAllowed
            r("COMMENTS") = Comments
            r("COMPLETED_COMMENTS") = CompletedComments
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

    Public Function EventTaskDatatable_UpdateRow(ByRef TheDT As DataTable, ByVal PrimaryKey As Integer, ByVal TaskCode As String, ByVal EmpCode As String, ByVal TaskDate As DateTime,
                        ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal TempCompDate As DateTime, ByVal HoursAllowed As Decimal,
                        ByVal Comments As String, ByVal CompletedComments As String) As String
        Try
            Dim r As DataRow
            r = TheDT.Rows.Find(PrimaryKey)
            r("TASK_CODE") = TaskCode
            r("EMP_CODE") = EmpCode
            r("EVENT_TASK_DATE") = TaskDate
            r("START_TIME") = StartTime
            r("END_TIME") = EndTime
            r("TEMP_COMP_DATE") = TempCompDate
            r("HOURS_ALLOWED") = HoursAllowed
            r("COMMENTS") = Comments
            r("COMPLETED_COMMENTS") = CompletedComments
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Private Sub CreateEventTasksDatatable()

        Dim Pk(0) As DataColumn

        Dim COL_INDEX As DataColumn = New DataColumn("INDEX")
        With COL_INDEX
            .DataType = GetType(Int32)
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Pk(0) = COL_INDEX

        Dim COL_EVENT_TASK_ID As DataColumn = New DataColumn("EVENT_TASK_ID")
        COL_EVENT_TASK_ID.DataType = GetType(Int32)

        Dim COL_EVENT_ID As DataColumn = New DataColumn("EVENT_ID")
        COL_EVENT_ID.DataType = GetType(Int32)

        Dim COL_TASK_CODE As DataColumn = New DataColumn("TASK_CODE")
        COL_TASK_CODE.DataType = GetType(String)

        Dim COL_EMP_CODE As DataColumn = New DataColumn("EMP_CODE")
        COL_EMP_CODE.DataType = GetType(String)

        Dim COL_EVENT_TASK_DATE As DataColumn = New DataColumn("EVENT_TASK_DATE")
        COL_EVENT_TASK_DATE.DataType = GetType(DateTime)

        Dim COL_START_TIME As DataColumn = New DataColumn("START_TIME")
        COL_START_TIME.DataType = GetType(DateTime)

        Dim COL_END_TIME As DataColumn = New DataColumn("END_TIME")
        COL_END_TIME.DataType = GetType(DateTime)

        Dim COL_TEMP_COMP_DATE As DataColumn = New DataColumn("TEMP_COMP_DATE")
        COL_TEMP_COMP_DATE.DataType = GetType(DateTime)

        Dim COL_HOURS_ALLOWED As DataColumn = New DataColumn("HOURS_ALLOWED")
        COL_HOURS_ALLOWED.DataType = GetType(Decimal)

        Dim COL_COMMENTS As DataColumn = New DataColumn("COMMENTS")
        COL_COMMENTS.DataType = GetType(String)

        Dim COL_COMPLETED_COMMENTS As DataColumn = New DataColumn("COMPLETED_COMMENTS")
        COL_COMPLETED_COMMENTS.DataType = GetType(String)

        Dim COL_IS_USER_ROW As DataColumn = New DataColumn("IS_USER_ROW")
        COL_IS_USER_ROW.DataType = GetType(Int32)

        With Me.mDtEventTasks.Columns
            .Add(COL_INDEX)
            .Add(COL_EVENT_TASK_ID)
            .Add(COL_EVENT_ID)
            .Add(COL_TASK_CODE)
            .Add(COL_EMP_CODE)
            .Add(COL_EVENT_TASK_DATE)
            .Add(COL_START_TIME)
            .Add(COL_END_TIME)
            .Add(COL_TEMP_COMP_DATE)
            .Add(COL_HOURS_ALLOWED)
            .Add(COL_COMMENTS)
            .Add(COL_COMPLETED_COMMENTS)
            .Add(COL_IS_USER_ROW)
        End With

        Me.mDtEventTasks.PrimaryKey = Pk

    End Sub

#End Region

#Region " Reports "

    Public Function GetFilterLists() As DataSet
        Try
            Dim arParams(1) As SqlParameter

            Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUSER_CODE.Value = mUserID
            arParams(0) = pUSER_CODE

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_REPORT_FILTER_LISTS", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function Event_Report_HTML_DS(ByVal ReportType As String, ByVal StartDate As String, ByVal EndDate As String, Optional ByVal OfficeList As String = "", Optional ByVal CDPList As String = "",
                                                    Optional ByVal ResourceList As String = "", Optional ByVal TrfFncList As String = "", Optional ByVal EmployeeList As String = "",
                                                    Optional ByVal IncludeInactiveEmployees As Boolean = False, Optional ByVal IncludeInactiveResources As Boolean = False) As DataSet
        'ReportType: evt_employee = Group by Employee, evt_resource = Group by Resource

        Dim dStartDate As Date = Convert.ToDateTime(StartDate)
        Dim dEndDate As Date = Convert.ToDateTime(EndDate)

        StartDate = dStartDate.Year.ToString() & "-" & dStartDate.Month.ToString() & "-" & dStartDate.Day.ToString()
        EndDate = dEndDate.Year.ToString() & "-" & dEndDate.Month.ToString() & "-" & dEndDate.Day.ToString()

        Dim SQL_STRING As String
        Dim restrictions As Integer = 0
        Dim restrictionsOffice As Integer = 0
        Dim restrictionsEmployee As Integer = 0
        SQL_STRING = "SELECT Count(*) FROM SEC_CLIENT WHERE USER_ID = '" & mUserID & "'"

        Try
            restrictions = oSQL.ExecuteScalar(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cEvents", Err.Description)
        Finally

        End Try

        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, mUserID)
                restrictionsOffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, mEmpCode).ToList.Count
                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(mConnString, mUserID)
                    restrictionsEmployee = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, mUserID).Select(Function(Entity) Entity.EmployeeCode).ToList.Count
                End Using
            End Using
        Catch ex As Exception

        End Try

        Dim SbWhere As New System.Text.StringBuilder
        With SbWhere
            .Append("WHERE ")
            .Append("	(EVENT.EVENT_DATE BETWEEN CONVERT(DATETIME, '" & StartDate & " 00:00:00', 102) AND CONVERT(DATETIME, '" & EndDate & " 11:59:00', 102)) ")
            If OfficeList.Trim() <> "" And OfficeList.Trim() <> "[NONE]" Then
                .Append("	AND (JOB_LOG.OFFICE_CODE IN (" & OfficeList & ") OR PRODUCT.OFFICE_CODE IN (" & OfficeList & ")) ")
            ElseIf OfficeList.Trim() <> "" And OfficeList.Trim() = "[NONE]" Then
                .Append("	AND ((JOB_LOG.OFFICE_CODE IS NULL) OR (PRODUCT.OFFICE_CODE IS NULL)) ")
            End If
            If ResourceList.Trim() <> "" And ResourceList.Trim() <> "[NONE]" Then
                .Append("	AND (EVENT.RESOURCE_CODE IN (" & ResourceList & ")) ")
            ElseIf ResourceList.Trim() <> "" And ResourceList.Trim() = "[NONE]" Then
                .Append("	AND (EVENT.RESOURCE_CODE IS NULL) ")
            End If
            If TrfFncList.Trim() <> "" And TrfFncList.Trim() <> "[NONE]" Then
                .Append("	AND (EVENT_TASK.TASK_CODE IN (" & TrfFncList & ")) ")
            ElseIf TrfFncList.Trim() <> "" And TrfFncList.Trim() = "[NONE]" Then
                .Append("	AND (EVENT_TASK.TASK_CODE IS NULL) ")
            End If
            If EmployeeList.Trim() <> "" And EmployeeList.Trim() <> "[NONE]" Then
                .Append("	AND (EVENT_TASK.EMP_CODE IN (" & EmployeeList & ")) ")
            ElseIf EmployeeList.Trim() <> "" And EmployeeList.Trim() = "[NONE]" Then
                .Append("	AND (EVENT_TASK.EMP_CODE IS NULL) ")
            End If
            If restrictions > 0 Then
                .Append(" AND (UPPER(SEC_CLIENT.USER_ID) = UPPER('" & mUserID & "')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ")
            End If
            If restrictionsEmployee > 0 Then
                .Append(" AND (UPPER(SEC_EMP.USER_ID) = UPPER('" & mUserID & "')) ")
            End If
            Dim StrCDPs As String = ""
            'This is going to take some more work!
            If CDPList.Trim() <> "" And CDPList.Trim() <> "[NONE]" Then
                Try
                    Dim SbCDP As New System.Text.StringBuilder
                    Dim arCDPList() As String
                    arCDPList = CDPList.Split(",")
                    If arCDPList.Length > 0 Then
                        With SbCDP
                            .Append("	AND (")
                            If arCDPList.Length = 1 Then
                                Dim arCDP() As String
                                arCDP = arCDPList(0).ToString().Split("|")
                                .Append("(")
                                Try
                                    .Append("CLIENT.CL_CODE = '")
                                    .Append(arCDP(0))
                                    .Append("' AND ")
                                Catch ex As Exception
                                End Try
                                Try
                                    .Append("DIVISION.DIV_CODE = '")
                                    .Append(arCDP(1))
                                    .Append("' AND ")
                                Catch ex As Exception
                                End Try
                                Try
                                    .Append("PRODUCT.PRD_CODE = '")
                                    .Append(arCDP(2))
                                    .Append("' ")
                                Catch ex As Exception
                                End Try
                                .Append(")")
                            ElseIf arCDPList.Length > 1 Then
                                For z As Integer = 0 To arCDPList.Length - 1
                                    If z = 0 Then
                                        Dim arCDP() As String
                                        arCDP = arCDPList(0).ToString().Split("|")
                                        .Append("(")
                                        Try
                                            .Append("CLIENT.CL_CODE = '")
                                            .Append(arCDP(0))
                                            .Append("' AND ")
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            .Append("DIVISION.DIV_CODE = '")
                                            .Append(arCDP(1))
                                            .Append("' AND ")
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            .Append("PRODUCT.PRD_CODE = '")
                                            .Append(arCDP(2))
                                            .Append("' ")
                                        Catch ex As Exception
                                        End Try
                                        .Append(")")
                                    Else
                                        Dim arCDP() As String
                                        arCDP = arCDPList(z).ToString().Split("|")
                                        .Append(" OR (")
                                        Try
                                            .Append("CLIENT.CL_CODE = '")
                                            .Append(arCDP(0))
                                            .Append("' AND ")
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            .Append("DIVISION.DIV_CODE = '")
                                            .Append(arCDP(1))
                                            .Append("' AND ")
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            .Append("PRODUCT.PRD_CODE = '")
                                            .Append(arCDP(2))
                                            .Append("' ")
                                        Catch ex As Exception
                                        End Try
                                        .Append(")")
                                    End If
                                Next
                            End If



                            .Append("		) ")

                        End With
                    End If
                    StrCDPs = SbCDP.ToString()
                    StrCDPs = StrCDPs.Replace("''", "'")
                Catch ex As Exception
                End Try
            ElseIf CDPList.Trim() <> "" And CDPList.Trim() = "[NONE]" Then
                StrCDPs = "	AND ((CLIENT.CL_CODE IS NULL) OR (DIVISION.DIV_CODE IS NULL) OR (PRODUCT.PRD_CODE IS NULL))"
            End If
            If StrCDPs.Trim() <> "" Then
                .Append(StrCDPs)
            End If
        End With

        Dim SbMain As New System.Text.StringBuilder
        With SbMain
            'Main outer grouping repeater
            If ReportType = "evt_employee" Then
                .Append("SELECT DISTINCT EMPLOYEE.EMP_CODE, ISNULL(EMP_FNAME+' ','')+ISNULL(EMP_MI+'. ','')+ISNULL(EMP_LNAME,'') AS GRP_HEADER, ISNULL(EMPLOYEE.EMP_EMAIL,'') AS EMP_EMAIL ")
                .Append("FROM EMPLOYEE WITH (NOLOCK) INNER JOIN EVENT_TASK WITH (NOLOCK) ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE ")
                If restrictionsOffice > 0 Then
                    .Append(" INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = EMPLOYEE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & mEmpCode & "'")
                End If
                If restrictionsEmployee > 0 Then
                    .Append(" INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE ")
                End If
                .Append("WHERE 1 = 1 ")
                If IncludeInactiveEmployees = False Then 'Show only active
                    .Append("AND (EMPLOYEE.EMP_TERM_DATE IS NULL OR EMPLOYEE.EMP_TERM_DATE > GETDATE()) ")
                End If
                If EmployeeList.Trim() <> "" And EmployeeList.Trim() <> "[NONE]" Then
                    .Append(" AND EMPLOYEE.EMP_CODE IN (" & EmployeeList & ") ")
                ElseIf EmployeeList.Trim() <> "" And EmployeeList.Trim() = "[NONE]" Then
                    .Append(" AND (EMPLOYEE.EMP_CODE IS NULL) ")
                End If
                If restrictionsEmployee > 0 Then
                    .Append(" AND (UPPER(SEC_EMP.USER_ID) = UPPER('" & mUserID & "')) ")
                End If
                .Append("ORDER BY ISNULL(EMP_FNAME+' ','')+ISNULL(EMP_MI+'. ','')+ISNULL(EMP_LNAME,''),EMPLOYEE.EMP_CODE")
            ElseIf ReportType = "evt_resource" Then
                .Append("SELECT RESOURCE_TYPE.RESOURCE_TYPE_CODE, RESOURCE_TYPE.RESOURCE_TYPE_DESC, RESOURCE.RESOURCE_CODE, RESOURCE.RESOURCE_DESC, RESOURCE.RESOURCE_CODE+' - '+ISNULL(RESOURCE.RESOURCE_DESC,'') AS GRP_HEADER, '' AS EMP_EMAIL ")
                .Append("FROM RESOURCE WITH(NOLOCK) INNER JOIN RESOURCE_TYPE WITH(NOLOCK) ON RESOURCE.RESOURCE_TYPE_CODE = RESOURCE_TYPE.RESOURCE_TYPE_CODE WHERE 1 = 1 ")
                If IncludeInactiveResources = False Then 'Show only active
                    .Append("AND ((RESOURCE.INACTIVE_FLAG IS NULL) OR (RESOURCE.INACTIVE_FLAG = 0)) ")
                End If
                If ResourceList.Trim() <> "" And ResourceList.Trim() <> "[NONE]" Then
                    .Append("AND (RESOURCE.RESOURCE_CODE IN (" & ResourceList & ")) ")
                ElseIf ResourceList.Trim() <> "" And ResourceList.Trim() = "[NONE]" Then
                    .Append("AND (RESOURCE.RESOURCE_CODE IS NULL) ")
                End If
                .Append("ORDER BY RESOURCE.RESOURCE_CODE ")
            End If
            .Append(";")
            'Event repeater
            .Append("SELECT DISTINCT ")
            .Append("	EVENT.EVENT_ID, EVENT_TASK.EMP_CODE, OFFICE.OFFICE_CODE AS JOB_OFFICE_CODE, OFFICE.OFFICE_NAME AS JOB_OFFICE_NAME, ")
            .Append("	OFFICE_1.OFFICE_CODE AS PRD_OFFICE_CODE, OFFICE_1.OFFICE_NAME AS PRD_OFFICE_NAME, CLIENT.CL_CODE, CLIENT.CL_NAME, ")
            .Append("	DIVISION.DIV_CODE, DIVISION.DIV_NAME, PRODUCT.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, ")
            .Append("	JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, EVENT.EVENT_LABEL, EVENT.EVENT_DATE, ")
            .Append("	EVENT.QTY_HRS AS EVENT_QTY_HRS, EVENT.QTY_TYPE AS EVENT_QTY_TYPE, EVENT.START_TIME AS EVENT_START_TIME, ")
            .Append("	EVENT.END_TIME AS EVENT_END_TIME, EVENT.FNC_CODE AS EVENT_FNC_CODE, AD_NUMBER.AD_NBR, AD_NUMBER.AD_NBR_DESC, ")
            .Append("	AD_NUMBER.DOCUMENT_ID, AD_NUMBER.COLOR, AD_NUMBER.CL_CODE AS AD_NUMBER_CL_CODE, ")
            .Append("	RESOURCE_TYPE.RESOURCE_TYPE_CODE, RESOURCE_TYPE.RESOURCE_TYPE_DESC, RESOURCE.RESOURCE_CODE, ")
            .Append("	RESOURCE.RESOURCE_DESC, CAST(ISNULL(EVENT.EVENT_COMMENT,EVENT.EVENT_DESC_LONG) AS VARCHAR(MAX)) AS EVENT_COMMENT, ")
            .Append("	CAST(EVENT.EVENT_DESC_LONG AS VARCHAR(MAX)) AS EVENT_DESC_LONG, EVENT.AD_NUMBER, ")
            .Append("   (SELECT MIN(START_TIME) FROM EVENT_TASK WITH(NOLOCK) WHERE EVENT_TASK.EVENT_ID = EVENT.EVENT_ID) AS EARLIEST_TASK ")
            .Append("FROM ")
            .Append("	TRAFFIC_FNC WITH (NOLOCK) RIGHT OUTER JOIN ")
            .Append("	EVENT_TASK WITH (NOLOCK) INNER JOIN ")
            .Append("	EVENT WITH (NOLOCK) INNER JOIN ")
            .Append("	JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND ")
            .Append("	EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN ")
            .Append("	JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN ")
            .Append("	CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN ")
            .Append("	PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND ")
            .Append("	JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN ")
            .Append("	DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE ON ")
            .Append("	EVENT_TASK.EVENT_ID = EVENT.EVENT_ID ON TRAFFIC_FNC.TRF_CODE = EVENT_TASK.TASK_CODE LEFT OUTER JOIN ")
            .Append("	AD_NUMBER WITH (NOLOCK) ON EVENT.AD_NUMBER = AD_NUMBER.AD_NBR LEFT OUTER JOIN ")
            .Append("	OFFICE AS OFFICE_1 WITH (NOLOCK) ON PRODUCT.OFFICE_CODE = OFFICE_1.OFFICE_CODE LEFT OUTER JOIN ")
            .Append("	OFFICE WITH (NOLOCK) ON JOB_LOG.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN ")
            .Append("	RESOURCE_TYPE INNER JOIN ")
            .Append("	RESOURCE WITH (NOLOCK) ON RESOURCE_TYPE.RESOURCE_TYPE_CODE = RESOURCE.RESOURCE_TYPE_CODE ON ")
            .Append("	EVENT.RESOURCE_CODE = RESOURCE.RESOURCE_CODE ")
            If restrictions > 0 Then
                .Append(" INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE ")
            End If
            If restrictionsOffice > 0 Then
                .Append(" INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & mEmpCode & "'")
            End If
            'If restrictionsEmployee > 0 Then
            '    .Append(" INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE ")
            'End If
            .Append(SbWhere.ToString().Replace("AND (UPPER(SEC_EMP.USER_ID) = UPPER('" & mUserID & "'))", " "))
            .Append("ORDER BY  EARLIEST_TASK,EVENT.START_TIME,EVENT.END_TIME, EVENT.AD_NUMBER")
            .Append("; ")
            'Event Tasks gridview
            .Append("SELECT ")
            .Append("	EVENT_TASK.EVENT_TASK_ID, EVENT_TASK.EVENT_ID, EMPLOYEE.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, ")
            .Append("	EMPLOYEE.EMP_LNAME, TRAFFIC_FNC.TRF_CODE, TRAFFIC_FNC.TRF_DESC, EVENT_TASK.START_DATE, EVENT_TASK.END_DATE, ")
            .Append("	EVENT_TASK.START_TIME, EVENT_TASK.END_TIME, EVENT_TASK.TEMP_COMP_DATE, EVENT_TASK.HOURS_ALLOWED, EVENT_TASK.COMMENTS, ")
            .Append("	EVENT_TASK.COMPLETED_COMMENTS, EVENT.RESOURCE_CODE,EVENT_TASK.COMPLETED_COMMENTS,EVENT.RESOURCE_CODE, ISNULL(ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,''),'') AS EMP_FULL ")
            .Append("FROM ")
            .Append("	EMPLOYEE WITH (NOLOCK) RIGHT OUTER JOIN ")
            .Append("	EVENT_TASK WITH (NOLOCK) INNER JOIN ")
            .Append("	EVENT WITH (NOLOCK) INNER JOIN ")
            .Append("	JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND ")
            .Append("	EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN ")
            .Append("	JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN ")
            .Append("	CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN ")
            .Append("	PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND ")
            .Append("	JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN ")
            .Append("	DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE ON ")
            .Append("	EVENT_TASK.EVENT_ID = EVENT.EVENT_ID ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE LEFT OUTER JOIN ")
            .Append("	TRAFFIC_FNC WITH (NOLOCK) ON EVENT_TASK.TASK_CODE = TRAFFIC_FNC.TRF_CODE LEFT OUTER JOIN ")
            .Append("	OFFICE AS OFFICE_1 WITH (NOLOCK) ON PRODUCT.OFFICE_CODE = OFFICE_1.OFFICE_CODE LEFT OUTER JOIN ")
            .Append("	OFFICE WITH (NOLOCK) ON JOB_LOG.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN ")
            .Append("	RESOURCE_TYPE INNER JOIN ")
            .Append("	RESOURCE WITH (NOLOCK) ON RESOURCE_TYPE.RESOURCE_TYPE_CODE = RESOURCE.RESOURCE_TYPE_CODE ON ")
            .Append("	EVENT.RESOURCE_CODE = RESOURCE.RESOURCE_CODE ")
            If restrictions > 0 Then
                .Append(" INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE ")
            End If
            If restrictionsOffice > 0 Then
                .Append(" INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & mEmpCode & "'")
            End If
            If restrictionsEmployee > 0 Then
                .Append(" INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE ")
            End If
            .Append(SbWhere.ToString())
            .Append("ORDER BY EVENT_TASK.START_TIME,EVENT_TASK.END_TIME, EVENT.AD_NUMBER")
            .Append("; ")


        End With

        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.Text, SbMain.ToString())
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Helpers "

    'Make sure event start and end time have the same date value
    Public Function FixDate(ByVal TheDate As String, ByVal TheTime As String) As DateTime
        Try
            Dim d As DateTime
            Dim t As DateTime
            Dim IsValid As Boolean = True
            Try
                d = Convert.ToDateTime(TheDate)
            Catch ex As Exception
                IsValid = False
            End Try
            Try
                t = Convert.ToDateTime(Now.ToShortDateString() & " " & TheTime)
            Catch ex As Exception
                IsValid = False
            End Try
            If IsValid = True Then
                Return Convert.ToDateTime(d.ToShortDateString() & " " & t.ToShortTimeString())
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
    End Sub

End Class
