Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Collections.Generic

<Serializable()> Public Class cBillingApproval
    Private mConnString As String
    Private mUserCode As String
    Private oSQL As SqlHelper

    Public Function AllowAccess(ByVal EmpCode As String, ByVal Password As String, ByVal UserCode As String) As Boolean
        Try
            Dim arParams(3) As SqlParameter

            Dim paramUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            paramUSER_ID.Value = UserCode
            arParams(0) = paramUSER_ID

            Dim paramAE_EMP_CODE As New SqlParameter("@AE_EMP_CODE", SqlDbType.VarChar, 6)
            paramAE_EMP_CODE.Value = EmpCode
            arParams(1) = paramAE_EMP_CODE

            Dim paramPASSWORD As New SqlParameter("@PASSWORD", SqlDbType.VarChar, 20)
            paramPASSWORD.Value = Password
            arParams(2) = paramPASSWORD

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_LOGIN", arParams)

            If i > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

#Region " Billing Approval Pages Settings "
    Public Enum BA_Page
        Batch_Approval_Entry_Edit = 0
        Billing_Approval_Entry_Edit = 1
        Billing_Approval_Job_Component = 2
        Unbilled_Function_Detail = 3
    End Enum

    Public Function GetPageSetting(ByVal PageName As BA_Page) As DataTable
        Try
            Dim PageVal As Integer = -1
            Select Case PageName
                Case BA_Page.Batch_Approval_Entry_Edit
                    PageVal = 0
                Case BA_Page.Billing_Approval_Entry_Edit
                    PageVal = 1
                Case BA_Page.Billing_Approval_Job_Component
                    PageVal = 2
                Case BA_Page.Unbilled_Function_Detail
                    PageVal = 3
            End Select

            Dim arParams(1) As SqlParameter

            Dim pPAGE As New SqlParameter("@PAGE", SqlDbType.SmallInt)
            pPAGE.Value = PageVal
            arParams(0) = pPAGE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_PAGES_SETTINGS", "DtSettings", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region " Billing Approval Batch "

    Public Function BatchExists(ByVal BatchID As Integer) As Boolean
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID
            Dim i As Integer = 0

            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_EXISTS", arParams)
            If i = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function BatchApplyCriteria(ByVal BatchID As Integer) As String
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_APPLY_CRITERIA", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Enum ManagerType
        AccountExecutive = 0
        ProjectManager = 1
    End Enum
    'Create a batch header record and update the BA_BATCH_ID in the JOB_COMPONENT table
    Public Function BatchAddNew(ByVal BA_BATCH_DESC As String, _
                                ByVal BATCH_DATE As String, _
                                ByVal CREATE_USER As String, _
                                ByVal CREATE_DATE As String, _
                                ByVal MODIFY_USER As String, _
                                ByVal MODIFY_DATE As String, _
                                ByVal DATE_CUTOFF As String, _
                                ByVal PERIOD_CUTOFF As String, _
                                ByVal EMP_CODE As String, _
                                ByVal INCL_NB As Boolean, _
                                ByVal INCL_FEE As Boolean, _
                                ByVal INCL_INT As Boolean, _
                                ByVal INCL_NP As Boolean, _
                                ByVal INCL_MAG As Boolean, _
                                ByVal INCL_OD As Boolean, _
                                ByVal INCL_RA As Boolean, _
                                ByVal INCL_TV As Boolean, _
                                ByVal BA_EXISTS As Boolean, _
                                ByVal APPROVED As Boolean, _
                                ByVal FINISHED As Boolean, _
                                ByVal BILLED_ANY As Boolean, _
                                ByVal BILLED_ALL As Boolean, _
                                ByVal APPR_METHOD As String, _
                                ByVal SEL_OPTION As Integer, _
                                ByVal [ManagerType] As ManagerType) As String

        Try
            Dim arParams(25) As SqlParameter

            Dim paramBA_BATCH_DESC As New SqlParameter("@BA_BATCH_DESC", SqlDbType.VarChar, 50)
            paramBA_BATCH_DESC.Value = BA_BATCH_DESC
            arParams(0) = paramBA_BATCH_DESC

            Dim paramBATCH_DATE As New SqlParameter("@BATCH_DATE", SqlDbType.SmallDateTime)
            'must have batch date, validated on page, but just to make sure:
            If BATCH_DATE.Trim() = "" Then
                paramBATCH_DATE.Value = Now.Date
            Else
                paramBATCH_DATE.Value = cGlobals.wvCDate(BATCH_DATE)
            End If
            arParams(1) = paramBATCH_DATE

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar, 100)
            paramCREATE_USER.Value = CREATE_USER
            arParams(2) = paramCREATE_USER

            Dim paramCREATE_DATE As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
            If CREATE_DATE.Trim() = "" Then
                paramCREATE_DATE.Value = System.DBNull.Value
            Else
                paramCREATE_DATE.Value = cGlobals.wvCDate(CREATE_DATE)
            End If
            arParams(3) = paramCREATE_DATE

            Dim paramMODIFY_USER As New SqlParameter("@MODIFY_USER", SqlDbType.VarChar, 100)
            paramMODIFY_USER.Value = MODIFY_USER
            arParams(4) = paramMODIFY_USER

            Dim paramMODIFY_DATE As New SqlParameter("@MODIFY_DATE", SqlDbType.SmallDateTime)
            If MODIFY_DATE.Trim() = "" Then
                paramMODIFY_DATE.Value = Now.Date
            Else
                paramMODIFY_DATE.Value = cGlobals.wvCDate(MODIFY_DATE)
            End If
            arParams(5) = paramMODIFY_DATE

            Dim paramDATE_CUTOFF As New SqlParameter("@DATE_CUTOFF", SqlDbType.SmallDateTime)
            If DATE_CUTOFF.Trim() = "" Then
                paramDATE_CUTOFF.Value = System.DBNull.Value
            Else
                paramDATE_CUTOFF.Value = DATE_CUTOFF
            End If
            arParams(6) = paramDATE_CUTOFF

            Dim paramPERIOD_CUTOFF As New SqlParameter("@PERIOD_CUTOFF", SqlDbType.VarChar, 6)
            If PERIOD_CUTOFF.Trim() = "All" Then
                paramPERIOD_CUTOFF.Value = System.DBNull.Value
            Else
                paramPERIOD_CUTOFF.Value = PERIOD_CUTOFF.ToString()
            End If
            arParams(7) = paramPERIOD_CUTOFF

            Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEMP_CODE.Value = EMP_CODE
            arParams(8) = paramEMP_CODE

            Dim paramINCL_NB As New SqlParameter("@INCL_NB", SqlDbType.Bit)
            If INCL_NB = True Then
                paramINCL_NB.Value = 1
            Else
                paramINCL_NB.Value = 0
            End If
            arParams(9) = paramINCL_NB

            Dim paramINCL_FEE As New SqlParameter("@INCL_FEE", SqlDbType.Bit)
            If INCL_FEE = True Then
                paramINCL_FEE.Value = 1
            Else
                paramINCL_FEE.Value = 0
            End If
            arParams(10) = paramINCL_FEE

            Dim paramINCL_INT As New SqlParameter("@INCL_INT", SqlDbType.Bit)
            If INCL_INT = True Then
                paramINCL_INT.Value = 1
            Else
                paramINCL_INT.Value = 0
            End If
            arParams(11) = paramINCL_INT

            Dim paramINCL_NP As New SqlParameter("@INCL_NP", SqlDbType.Bit)
            If INCL_NP = True Then
                paramINCL_NP.Value = 1
            Else
                paramINCL_NP.Value = 0
            End If
            arParams(12) = paramINCL_NP

            Dim paramINCL_MAG As New SqlParameter("@INCL_MAG", SqlDbType.Bit)
            If INCL_MAG = True Then
                paramINCL_MAG.Value = 1
            Else
                paramINCL_MAG.Value = 0
            End If
            arParams(13) = paramINCL_MAG

            Dim paramINCL_OD As New SqlParameter("@INCL_OD", SqlDbType.Bit)
            If INCL_OD = True Then
                paramINCL_OD.Value = 1
            Else
                paramINCL_OD.Value = 0
            End If
            arParams(14) = paramINCL_OD

            Dim paramINCL_RA As New SqlParameter("@INCL_RA", SqlDbType.Bit)
            If INCL_RA = True Then
                paramINCL_RA.Value = 1
            Else
                paramINCL_RA.Value = 0
            End If
            arParams(15) = paramINCL_RA

            Dim paramINCL_TV As New SqlParameter("@INCL_TV", SqlDbType.Bit)
            If INCL_TV = True Then
                paramINCL_TV.Value = 1
            Else
                paramINCL_TV.Value = 0
            End If
            arParams(16) = paramINCL_TV

            'obsolete and not used in procedure:
            Dim paramBA_EXISTS As New SqlParameter("@BA_EXISTS", SqlDbType.Bit)
            If BA_EXISTS = True Then
                paramBA_EXISTS.Value = 1
            Else
                paramBA_EXISTS.Value = 0
            End If
            arParams(17) = paramBA_EXISTS

            Dim paramAPPROVED As New SqlParameter("@APPROVED", SqlDbType.Bit)
            If APPROVED = True Then
                paramAPPROVED.Value = 1
            Else
                paramAPPROVED.Value = 0
            End If
            arParams(18) = paramAPPROVED

            Dim paramFINISHED As New SqlParameter("@FINISHED", SqlDbType.Bit)
            If FINISHED = True Then
                paramFINISHED.Value = 1
            Else
                paramFINISHED.Value = 0
            End If
            arParams(19) = paramFINISHED

            'obsolete and not used in procedure:
            Dim paramBILLED_ANY As New SqlParameter("@BILLED_ANY", SqlDbType.Bit)
            If BILLED_ANY = True Then
                paramBILLED_ANY.Value = 1
            Else
                paramBILLED_ANY.Value = 0
            End If
            arParams(20) = paramBILLED_ANY

            'obsolete and not used in procedure:
            Dim paramBILLED_ALL As New SqlParameter("@BILLED_ALL", SqlDbType.Bit)
            If BILLED_ALL = True Then
                paramBILLED_ALL.Value = 1
            Else
                paramBILLED_ALL.Value = 0
            End If
            arParams(21) = paramBILLED_ALL

            Dim paramAPPR_METHOD As New SqlParameter("@APPR_METHOD", SqlDbType.SmallInt)
            paramAPPR_METHOD.Value = APPR_METHOD
            arParams(22) = paramAPPR_METHOD

            Dim paramSEL_OPTION As New SqlParameter("@SEL_OPTION", SqlDbType.SmallInt)
            paramSEL_OPTION.Value = SEL_OPTION
            arParams(23) = paramSEL_OPTION

            Dim paramManagerType As New SqlParameter("@MANAGER_TYPE", SqlDbType.SmallInt)
            paramManagerType.Value = CType([ManagerType], Integer)
            arParams(24) = paramManagerType

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_INSERT", arParams)
            Return i.ToString

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function BatchUpdate(ByVal BA_BATCH_ID As Integer, _
                                ByVal BA_BATCH_DESC As String, _
                                ByVal BATCH_DATE As String, _
                                ByVal MODIFY_USER As String, _
                                ByVal MODIFY_DATE As String, _
                                ByVal DATE_CUTOFF As String, _
                                ByVal PERIOD_CUTOFF As String, _
                                ByVal EMP_CODE As String, _
                                ByVal INCL_NB As Boolean, _
                                ByVal INCL_FEE As Boolean, _
                                ByVal INCL_INT As Boolean, _
                                ByVal INCL_NP As Boolean, _
                                ByVal INCL_MAG As Boolean, _
                                ByVal INCL_OD As Boolean, _
                                ByVal INCL_RA As Boolean, _
                                ByVal INCL_TV As Boolean, _
                                ByVal APPR_METHOD As String, _
                                ByVal APPLY_CRITERIA As Boolean, _
                                ByVal SEL_OPTION As Integer, _
                                ByVal [ManagerType] As ManagerType) As String

        Try
            Dim arParams(20) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim paramBA_BATCH_DESC As New SqlParameter("@BA_BATCH_DESC", SqlDbType.VarChar, 50)
            paramBA_BATCH_DESC.Value = BA_BATCH_DESC
            arParams(1) = paramBA_BATCH_DESC

            Dim paramBATCH_DATE As New SqlParameter("@BATCH_DATE", SqlDbType.SmallDateTime)
            'must have batch date, validated on page, but just to make sure:
            If BATCH_DATE.Trim() = "" Then
                paramBATCH_DATE.Value = Now.Date
            Else
                paramBATCH_DATE.Value = cGlobals.wvCDate(BATCH_DATE)
            End If
            arParams(2) = paramBATCH_DATE

            Dim paramMODIFY_USER As New SqlParameter("@MODIFY_USER", SqlDbType.VarChar, 100)
            paramMODIFY_USER.Value = MODIFY_USER
            arParams(3) = paramMODIFY_USER

            Dim paramMODIFY_DATE As New SqlParameter("@MODIFY_DATE", SqlDbType.SmallDateTime)
            If MODIFY_DATE.Trim() = "" Then
                paramMODIFY_DATE.Value = Now.Date
            Else
                paramMODIFY_DATE.Value = cGlobals.wvCDate(MODIFY_DATE)
            End If
            arParams(4) = paramMODIFY_DATE

            Dim paramDATE_CUTOFF As New SqlParameter("@DATE_CUTOFF", SqlDbType.SmallDateTime)
            If DATE_CUTOFF.Trim() = "" Then
                paramDATE_CUTOFF.Value = System.DBNull.Value
            Else
                paramDATE_CUTOFF.Value = DATE_CUTOFF
            End If
            arParams(5) = paramDATE_CUTOFF

            Dim paramPERIOD_CUTOFF As New SqlParameter("@PERIOD_CUTOFF", SqlDbType.VarChar, 6)
            If PERIOD_CUTOFF.Trim() = "All" Then
                paramPERIOD_CUTOFF.Value = System.DBNull.Value
            Else
                paramPERIOD_CUTOFF.Value = PERIOD_CUTOFF.ToString()
            End If
            arParams(6) = paramPERIOD_CUTOFF

            Dim paramEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            paramEMP_CODE.Value = EMP_CODE
            arParams(7) = paramEMP_CODE

            Dim paramINCL_NB As New SqlParameter("@INCL_NB", SqlDbType.Bit)
            If INCL_NB = True Then
                paramINCL_NB.Value = 1
            Else
                paramINCL_NB.Value = 0
            End If
            arParams(8) = paramINCL_NB

            Dim paramINCL_FEE As New SqlParameter("@INCL_FEE", SqlDbType.Bit)
            If INCL_FEE = True Then
                paramINCL_FEE.Value = 1
            Else
                paramINCL_FEE.Value = 0
            End If
            arParams(9) = paramINCL_FEE

            Dim paramINCL_INT As New SqlParameter("@INCL_INT", SqlDbType.Bit)
            If INCL_INT = True Then
                paramINCL_INT.Value = 1
            Else
                paramINCL_INT.Value = 0
            End If
            arParams(10) = paramINCL_INT

            Dim paramINCL_NP As New SqlParameter("@INCL_NP", SqlDbType.Bit)
            If INCL_NP = True Then
                paramINCL_NP.Value = 1
            Else
                paramINCL_NP.Value = 0
            End If
            arParams(11) = paramINCL_NP

            Dim paramINCL_MAG As New SqlParameter("@INCL_MAG", SqlDbType.Bit)
            If INCL_MAG = True Then
                paramINCL_MAG.Value = 1
            Else
                paramINCL_MAG.Value = 0
            End If
            arParams(12) = paramINCL_MAG

            Dim paramINCL_OD As New SqlParameter("@INCL_OD", SqlDbType.Bit)
            If INCL_OD = True Then
                paramINCL_OD.Value = 1
            Else
                paramINCL_OD.Value = 0
            End If
            arParams(13) = paramINCL_OD

            Dim paramINCL_RA As New SqlParameter("@INCL_RA", SqlDbType.Bit)
            If INCL_RA = True Then
                paramINCL_RA.Value = 1
            Else
                paramINCL_RA.Value = 0
            End If
            arParams(14) = paramINCL_RA

            Dim paramINCL_TV As New SqlParameter("@INCL_TV", SqlDbType.Bit)
            If INCL_TV = True Then
                paramINCL_TV.Value = 1
            Else
                paramINCL_TV.Value = 0
            End If
            arParams(15) = paramINCL_TV

            Dim paramAPPR_METHOD As New SqlParameter("@APPR_METHOD", SqlDbType.SmallInt)
            paramAPPR_METHOD.Value = APPR_METHOD
            arParams(16) = paramAPPR_METHOD

            Dim paramAPPLY_CRITERIA As New SqlParameter("@APPLY_CRITERIA", SqlDbType.SmallInt)
            If APPLY_CRITERIA = True Then
                paramAPPLY_CRITERIA.Value = 1
            Else
                paramAPPLY_CRITERIA.Value = 0
            End If
            arParams(17) = paramAPPLY_CRITERIA

            Dim paramSEL_OPTION As New SqlParameter("@SEL_OPTION", SqlDbType.SmallInt)
            paramSEL_OPTION.Value = SEL_OPTION
            arParams(18) = paramSEL_OPTION

            Dim paramManagerType As New SqlParameter("@MANAGER_TYPE", SqlDbType.SmallInt)
            paramManagerType.Value = CType([ManagerType], Integer)
            arParams(19) = paramManagerType


            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_UPDATE", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function BatchApprove(ByVal BA_BATCH_ID As Integer) As String

        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim i As Integer = 0
            i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_APPROVE", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function BatchFinish(ByVal BA_BATCH_ID As Integer) As String

        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim i As Integer = 0
            i = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_FINISH", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function GetPostingPeriods() As SqlDataReader
        Try
            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_BA_POSTING_PERIODS")
        Catch ex As Exception

        End Try
    End Function

    'Clear the BA_BATCH_ID from the JOB_COMPONENT table
    Public Function ClearBatchSelections(ByVal BatchID As Integer, ByVal FinishBatch As Boolean) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            Dim paramFINISH_BATCH As New SqlParameter("@FINISH_BATCH", SqlDbType.SmallInt)
            If FinishBatch = True Then
                paramFINISH_BATCH.Value = 1
            Else
                paramFINISH_BATCH.Value = 0
            End If
            arParams(2) = paramFINISH_BATCH

            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_CLEAR_SEL", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Clear the BA_BATCH_ID from the JOB_COMPONENT table and delete the batch header
    Public Function DeleteEntireBatch(ByVal BatchID As Integer) As String
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            Dim str As String = ""
            str = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_DEL_ALL", arParams)
            Return str

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Get view for Batch List View
    Public Function GetBatchListView(ByVal TheMonth As Integer, ByVal TheYear As Integer, ByVal UserCode As String, ByVal Unfinished As Boolean) As DataTable

        Dim arParams(4) As SqlParameter

        Dim pMonth As New SqlParameter("@MONTH", SqlDbType.SmallInt)
        pMonth.Value = TheMonth
        arParams(0) = pMonth

        Dim pYear As New SqlParameter("@YEAR", SqlDbType.SmallInt)
        pYear.Value = TheYear
        arParams(1) = pYear

        Dim pEmpCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        pEmpCode.Value = UserCode
        arParams(2) = pEmpCode

        Dim pUnfinished As New SqlParameter("@UNFINISHED", SqlDbType.Bit)
        pUnfinished.Value = Unfinished
        arParams(3) = pUnfinished

        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_VIEW_LIST", "DtData", arParams)

    End Function

    'Get view for Batch List View for other users
    Public Function GetBatchListViewOtherUsers(ByVal TheMonth As Integer, ByVal TheYear As Integer, ByVal UserCode As String) As DataTable
        Dim arParams(3) As SqlParameter

        Dim pMonth As New SqlParameter("@MONTH", SqlDbType.SmallInt)
        pMonth.Value = TheMonth
        arParams(0) = pMonth

        Dim pYear As New SqlParameter("@YEAR", SqlDbType.SmallInt)
        pYear.Value = TheYear
        arParams(1) = pYear

        Dim pEmpCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        pEmpCode.Value = UserCode
        arParams(2) = pEmpCode

        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_VIEW_LIST_OTHER_USERS", "dtBatchListOtherUsersView", arParams)

    End Function


    'Get batch details to populate BillingApproval_Batch.aspx
    'Returns a dataset with 3 tables.
    'first gets the details
    'second gets the ae's
    'third gets the selections for cdpc listbox
    Public Function GetBatchDetails(ByVal BatchID As Integer) As DataSet
        Try
            Dim arParams(2) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            Dim paramUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            paramUSER_CODE.Value = mUserCode
            arParams(1) = paramUSER_CODE

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_DETAILS", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetBatchCriteriaJobs(ByVal BatchID As Integer) As DataTable
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            Dim paramUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            paramUSER_CODE.Value = HttpContext.Current.Session("UserCode")
            arParams(1) = paramUSER_CODE


            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_CRITERIA_JOBS", "dtBatchJobList", arParams)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function GetBatchJobList(ByVal BA_BATCH_ID As Integer, Optional ByVal BA_ID As Integer = 0, Optional ByVal CL_CODE As String = "") As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim pBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            pBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = pBA_BATCH_ID

            Dim pBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            pBA_ID.Value = BA_ID
            arParams(1) = pBA_ID

            Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            pCL_CODE.Value = CL_CODE
            arParams(2) = pCL_CODE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_JOBS", "dtBatchJobList", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetBatchJobListSimple(ByVal BA_BATCH_ID As Integer, ByVal IncludeApprovalJobs As Boolean) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim pBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            pBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = pBA_BATCH_ID

            Dim pINCLUDE_APPROVAL_JOBS As New SqlParameter("@INCLUDE_APPROVAL_JOBS", SqlDbType.Bit)
            pINCLUDE_APPROVAL_JOBS.Value = IncludeApprovalJobs
            arParams(1) = pINCLUDE_APPROVAL_JOBS

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_JOB_LIST", "dtBatchJobList", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function HasUnApprovedJobs(ByVal BA_BATCH_ID As Integer) As Boolean

        Dim ReturnValue As Boolean = False

        Try

            Dim arParams(2) As SqlParameter

            Dim pBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            pBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = pBA_BATCH_ID

            Dim pINCLUDE_APPROVAL_JOBS As New SqlParameter("@INCLUDE_APPROVAL_JOBS", SqlDbType.Bit)
            pINCLUDE_APPROVAL_JOBS.Value = True
            arParams(1) = pINCLUDE_APPROVAL_JOBS

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_JOB_LIST", "dtBatchJobList", arParams)

            If dt.Rows.Count > 0 Then

                Dim dv As New DataView
                dv = dt.DefaultView
                dv.RowFilter = "UNAPPROVED = 1"

                If dv.ToTable.Rows.Count > 0 Then

                    ReturnValue = True

                End If

            End If

        Catch ex As Exception

        End Try

        Return ReturnValue

    End Function

    'this actually returns a few columns and is used for the tooltip in job jacket?
    Public Function GetBatchID(ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(1) = paramJOB_COMPONENT_NBR

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BATCH_GET_ID", "DtData", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region " Billing Approval (Not Batch) "

    Public Function AutoSaveAllClients(ByVal BatchId As Integer, ByVal ExcludeClientsThatHaveApprovalsForThisBatch As Boolean) As String
        Try
            Dim TotalClients As Integer = 0
            Dim SuccessfulSaves As Integer = 0
            Dim d As New cDropDowns(Me.mConnString)
            Dim dt As New DataTable
            dt = d.GetClientsByBatchID(BatchId, ExcludeClientsThatHaveApprovalsForThisBatch)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                TotalClients = dt.Rows.Count
                Dim ba As New cBillingApproval()
                For i As Integer = 0 To TotalClients - 1
                    If ba.ApprovalAddNew(BatchId, HttpContext.Current.Session("UserCode"), dt.Rows(i)("CL_CODE"), dt.Rows(i)("CL_NAME"), "", "", "", "", 0) <> -1 Then
                        SuccessfulSaves += 1
                    End If
                Next
                Return SuccessfulSaves.ToString() & " out of " & TotalClients & " saved"
            Else
                Return "No Client(s) need Approvals"
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
            Return False
        End Try
    End Function

    Public Function AutoSaveSingleClient(ByVal BatchId As Integer) As Integer
        Try
            Dim arP(2) As SqlParameter

            Dim pBatchId As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            pBatchId.Value = BatchId
            arP(0) = pBatchId

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = Me.mUserCode
            arP(1) = pUserCode

            Return SqlHelper.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_AUTOSAVE_SINGLE_CL", arP)

        Catch ex As Exception
            Return -999
        End Try
    End Function

    Public Function AutoSave(ByVal BatchId As Integer, ByVal ApprovalId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As Boolean
        Try
            Dim arP(5) As SqlParameter

            Dim pBatchId As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            pBatchId.Value = BatchId
            arP(0) = pBatchId

            Dim pApprovalId As New SqlParameter("@BA_ID", SqlDbType.Int)
            pApprovalId.Value = ApprovalId
            arP(1) = pApprovalId

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            arP(2) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = JobComponentNbr
            arP(3) = pJobComponentNbr

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = Me.mUserCode
            arP(4) = pUserCode

            Dim i As Integer = SqlHelper.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_AUTOSAVE", arP)
            If i = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Get view for Approval List View
    'BillingApproval_View_Approvals.aspx
    Public Function GetApprovalListView(ByVal TheMonth As Integer, ByVal TheYear As Integer, ByVal EmpCode As String) As DataTable
        Dim arParams(3) As SqlParameter

        Dim pMonth As New SqlParameter("@MONTH", SqlDbType.SmallInt)
        pMonth.Value = TheMonth
        arParams(0) = pMonth

        Dim pYear As New SqlParameter("@YEAR", SqlDbType.SmallInt)
        pYear.Value = TheYear
        arParams(1) = pYear

        Dim pEmpCode As New SqlParameter("@BA_EMP_CODE", SqlDbType.VarChar, 6)
        pEmpCode.Value = EmpCode
        arParams(2) = pEmpCode

        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_VIEW_LIST", "dtBatchListView", arParams)

    End Function

    'Get view for Approval Batch Selection View
    'BillingApproval_Approval.aspx
    Public Function GetBatchApprovalsList(ByVal BatchID As Integer) As DataSet
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(0) = paramBA_BATCH_ID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_SELECT_BATCH", arParams)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function GetApprovalDetails(ByVal ApprovalID As Integer) As DataSet
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = ApprovalID
            arParams(0) = paramBA_ID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_GET_DETAILS", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ApprovalAddNew(ByVal BA_BATCH_ID As Integer, _
                                    ByVal CREATE_USER As String, _
                                    ByVal CL_CODE As String, _
                                    ByVal BA_CL_DESC As String, _
                                    ByVal BA_CL_DATE As String, _
                                    ByVal SENT_DATE As String, _
                                    ByVal APPR_DATE As String, _
                                    ByVal CLIENT_PO As String, _
                                    ByVal CDP_CONTACT_ID As Integer) As Integer
        Try
            Dim arParams(9) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar, 100)
            paramCREATE_USER.Value = CREATE_USER
            arParams(1) = paramCREATE_USER


            Dim paramCL_CODEC As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            paramCL_CODEC.Value = CL_CODE
            arParams(2) = paramCL_CODEC

            Dim paramBA_CL_DESC As New SqlParameter("@BA_CL_DESC", SqlDbType.VarChar, 50)
            If BA_CL_DESC.Trim() = "" Then
                paramBA_CL_DESC.Value = System.DBNull.Value
            Else
                paramBA_CL_DESC.Value = BA_CL_DESC
            End If
            arParams(3) = paramBA_CL_DESC


            Dim paramBA_CL_DATE As New SqlParameter("@BA_CL_DATE", SqlDbType.SmallDateTime)
            If BA_CL_DATE.Trim() = "" Then
                paramBA_CL_DATE.Value = Now()
            Else
                paramBA_CL_DATE.Value = cGlobals.wvCDate(BA_CL_DATE)
            End If
            arParams(4) = paramBA_CL_DATE

            Dim paramSENT_DATE As New SqlParameter("@SENT_DATE", SqlDbType.SmallDateTime)
            If SENT_DATE.Trim() = "" Then
                paramSENT_DATE.Value = System.DBNull.Value
            Else
                paramSENT_DATE.Value = cGlobals.wvCDate(SENT_DATE)
            End If
            arParams(5) = paramSENT_DATE

            Dim paramAPPR_DATE As New SqlParameter("@APPR_DATE", SqlDbType.SmallDateTime)
            If APPR_DATE.Trim() = "" Then
                paramAPPR_DATE.Value = System.DBNull.Value
            Else
                paramAPPR_DATE.Value = cGlobals.wvCDate(APPR_DATE)
            End If
            arParams(6) = paramAPPR_DATE

            Dim paramCLIENT_PO As New SqlParameter("@CLIENT_PO", SqlDbType.VarChar, 40)
            If CLIENT_PO.Trim() = "" Then
                paramCLIENT_PO.Value = System.DBNull.Value
            Else
                paramCLIENT_PO.Value = CLIENT_PO
            End If
            arParams(7) = paramCLIENT_PO

            Dim paramCDP_CONTACT_ID As New SqlParameter("@CDP_CONTACT_ID", SqlDbType.Int)
            If CDP_CONTACT_ID > 0 Then
                paramCDP_CONTACT_ID.Value = CDP_CONTACT_ID
            Else
                paramCDP_CONTACT_ID.Value = System.DBNull.Value
            End If
            arParams(8) = paramCDP_CONTACT_ID

            Return CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_INSERT", arParams), Integer)

        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function ApprovalUpdate(ByVal BA_ID As Integer, _
                                    ByVal BA_CL_DESC As String, _
                                    ByVal BA_CL_DATE As String, _
                                    ByVal SENT_DATE As String, _
                                    ByVal APPR_DATE As String, _
                                    ByVal CLIENT_PO As String, _
                                    ByVal CDP_CONTACT_ID As Integer) As String
        Try
            Dim arParams(7) As SqlParameter

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(0) = paramBA_ID

            Dim paramBA_CL_DESC As New SqlParameter("@BA_CL_DESC", SqlDbType.VarChar, 50)
            paramBA_CL_DESC.Value = BA_CL_DESC
            arParams(1) = paramBA_CL_DESC


            Dim paramBA_CL_DATE As New SqlParameter("@BA_CL_DATE", SqlDbType.SmallDateTime)
            If BA_CL_DATE.Trim() = "" Then
                paramBA_CL_DATE.Value = Now() 'Because it's required
            Else
                paramBA_CL_DATE.Value = cGlobals.wvCDate(BA_CL_DATE)
            End If
            arParams(2) = paramBA_CL_DATE

            Dim paramSENT_DATE As New SqlParameter("@SENT_DATE", SqlDbType.SmallDateTime)
            If SENT_DATE.Trim() = "" Then
                paramSENT_DATE.Value = System.DBNull.Value
            Else
                paramSENT_DATE.Value = cGlobals.wvCDate(SENT_DATE)
            End If
            arParams(3) = paramSENT_DATE

            Dim paramAPPR_DATE As New SqlParameter("@APPR_DATE", SqlDbType.SmallDateTime)
            If APPR_DATE.Trim() = "" Then
                paramAPPR_DATE.Value = System.DBNull.Value
            Else
                paramAPPR_DATE.Value = cGlobals.wvCDate(APPR_DATE)
            End If
            arParams(4) = paramAPPR_DATE

            Dim paramCLIENT_PO As New SqlParameter("@CLIENT_PO", SqlDbType.VarChar, 40)
            If CLIENT_PO.Trim() = "" Then
                paramCLIENT_PO.Value = System.DBNull.Value
            Else
                paramCLIENT_PO.Value = CLIENT_PO
            End If
            arParams(5) = paramCLIENT_PO

            Dim paramCDP_CONTACT_ID As New SqlParameter("@CDP_CONTACT_ID", SqlDbType.Int)
            If CDP_CONTACT_ID > 0 Then
                paramCDP_CONTACT_ID.Value = CDP_CONTACT_ID
            Else
                paramCDP_CONTACT_ID.Value = System.DBNull.Value
            End If
            arParams(7) = paramCDP_CONTACT_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_UPDATE", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function ApprovalDelete(ByVal BA_BATCH_ID As Integer, ByVal BA_ID As Integer) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(1) = paramBA_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_DELETE", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function CanDeleteApproval(ByVal ApprovalId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean

        Dim Rtn As Boolean = False
        Dim CanDel As Boolean = True

        Dim dsApproval As New DataSet
        Dim dtApprovalHeader As New DataTable

        dsApproval = Me.GetApprovalDetails(ApprovalId)
        dtApprovalHeader = dsApproval.Tables(0)

        If dtApprovalHeader.Rows.Count > 0 Then

            Try
                If IsDBNull(dtApprovalHeader.Rows(0)("APPROVED")) = False Then
                    CanDel = Not CType(dtApprovalHeader.Rows(0)("APPROVED"), Boolean)
                End If
            Catch ex As Exception
            End Try

            Dim HasApprovals As Boolean = False
            Try
                Dim i As Integer = 0
                Try
                    If IsDBNull(dtApprovalHeader.Rows(0)("HAS_APPROVED")) = False Then
                        i = CType(dtApprovalHeader.Rows(0)("HAS_APPROVED"), Integer)
                    End If
                    If i > 0 Then
                        HasApprovals = True
                    End If
                Catch ex As Exception
                    i = 0
                End Try
            Catch ex As Exception
            End Try

            If CanDel = False Or HasApprovals = True Then

                Return False

            Else

                Return True

            End If

        Else

            Return True

        End If

    End Function



#End Region

#Region " Billing Approval (Component) "

    'Clear detail level totals when details is off:
    Public Function ComponentClearApprovalAmounts(ByVal BA_ID As Integer, ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer) As String
        Try
            Dim arParams(3) As SqlParameter

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(0) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(1) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(2) = paramJOB_COMPONENT_NBR

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_CLEAR_APPROVAL_AMTS", arParams)

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Get basic header info on BillingApproval_Approval_JobComponent.aspx
    Public Function GetComponentHeader(ByVal BA_BATCH_ID As Integer, ByVal BA_ID As Integer, ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer) As DataSet
        Try
            Dim arParams(4) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(1) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(2) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(3) = paramJOB_COMPONENT_NBR

            Try
                Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_GET_HEADER", arParams)
            Catch ex As Exception
                Return Nothing
            End Try
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'Delete the header record and all related record in the details and item level
    Public Function DeleteAllFromComponent(ByVal BA_HDR_ID As Integer) As String
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_HDR_ID As New SqlParameter("@BA_HDR_ID", SqlDbType.Int)
            paramBA_HDR_ID.Value = BA_HDR_ID
            arParams(0) = paramBA_HDR_ID
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_DELETE_ALL", arParams)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

#End Region

#Region " Billing Approval (Header) "

    Public Function ApprovalHeaderAddNew(ByVal BA_ID As Integer, ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, _
                                        ByVal ACCT_EXEC As String, ByVal APPROVED_AMT As String, ByVal APPR_COMMENTS As String, _
                                        ByVal CLIENT_COMMENTS As String, ByVal CREATE_USER As String, ByVal AR_INV_NBR As Integer, _
                                        ByVal INVOICE_DATE As String, ByVal BILL_TYPE As Integer, ByVal APPR_STATUS As Integer) As String
        Try
            Dim arParams(12) As SqlParameter

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(0) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(1) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(2) = paramJOB_COMPONENT_NBR

            Dim paramACCT_EXEC As New SqlParameter("@ACCT_EXEC", SqlDbType.VarChar, 6)
            paramACCT_EXEC.Value = ACCT_EXEC
            arParams(3) = paramACCT_EXEC

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            If APPROVED_AMT = "" Or IsNumeric(APPROVED_AMT) = False Then
                paramAPPROVED_AMT.Value = System.DBNull.Value
            Else
                paramAPPROVED_AMT.Value = CType(APPROVED_AMT, Decimal)
            End If
            arParams(4) = paramAPPROVED_AMT

            Dim paramAPPR_COMMENTS As New SqlParameter("@APPR_COMMENTS", SqlDbType.Text)
            If APPR_COMMENTS.Trim() = "" Then
                paramAPPR_COMMENTS.Value = System.DBNull.Value
            Else
                paramAPPR_COMMENTS.Value = APPR_COMMENTS
            End If
            arParams(5) = paramAPPR_COMMENTS

            Dim paramCLIENT_COMMENTS As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If CLIENT_COMMENTS.Trim() = "" Then
                paramCLIENT_COMMENTS.Value = System.DBNull.Value
            Else
                paramCLIENT_COMMENTS.Value = CLIENT_COMMENTS
            End If
            arParams(6) = paramCLIENT_COMMENTS

            Dim paramCREATE_USER As New SqlParameter("@CREATE_USER", SqlDbType.VarChar, 100)
            If CREATE_USER.Trim() = "" Then
                paramCREATE_USER.Value = System.DBNull.Value
            Else
                paramCREATE_USER.Value = CREATE_USER
            End If
            paramCREATE_USER.Value = CREATE_USER
            arParams(7) = paramCREATE_USER

            Dim paramAR_INV_NBR As New SqlParameter("@AR_INV_NBR", SqlDbType.Int)
            If AR_INV_NBR < 1 Then
                paramAR_INV_NBR.Value = System.DBNull.Value
            Else
                paramAR_INV_NBR.Value = AR_INV_NBR
            End If
            arParams(8) = paramAR_INV_NBR

            Dim paramINVOICE_DATE As New SqlParameter("@INVOICE_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(INVOICE_DATE) = False Then
                paramINVOICE_DATE.Value = System.DBNull.Value
            Else
                paramINVOICE_DATE.Value = cGlobals.wvCDate(INVOICE_DATE)
            End If
            arParams(9) = paramINVOICE_DATE

            'what is this? be sure to straighten out the "if" when found out
            Dim paramBILL_TYPE As New SqlParameter("@BILL_TYPE", SqlDbType.TinyInt)
            If BILL_TYPE < -1 Then
                paramBILL_TYPE.Value = System.DBNull.Value
            Else
                paramBILL_TYPE.Value = BILL_TYPE
            End If
            arParams(10) = paramBILL_TYPE

            Dim paramAPPR_STATUS As New SqlParameter("@APPR_STATUS", SqlDbType.SmallInt)
            If APPR_STATUS = 0 Then
                paramAPPR_STATUS.Value = System.DBNull.Value
            Else
                paramAPPR_STATUS.Value = APPR_STATUS
            End If
            arParams(11) = paramAPPR_STATUS



            Return oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_HDR_INSERT", arParams)

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function ApprovalHeaderUpdate(ByVal BA_HDR_ID As Integer, ByVal APPROVED_AMT As String, ByVal APPR_COMMENTS As String, _
                                         ByVal CLIENT_COMMENTS As String, ByVal BILL_TYPE As Integer, ByVal APPR_STATUS As Integer) As String
        Try
            Dim arParams(6) As SqlParameter

            Dim paramBA_HDR_ID As New SqlParameter("@BA_HDR_ID", SqlDbType.Int)
            paramBA_HDR_ID.Value = BA_HDR_ID
            arParams(0) = paramBA_HDR_ID

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            If APPROVED_AMT = "" Or IsNumeric(APPROVED_AMT) = False Then
                paramAPPROVED_AMT.Value = System.DBNull.Value
            Else
                paramAPPROVED_AMT.Value = CType(APPROVED_AMT, Decimal)
            End If
            arParams(1) = paramAPPROVED_AMT

            Dim paramAPPR_COMMENTS As New SqlParameter("@APPR_COMMENTS", SqlDbType.Text)
            paramAPPR_COMMENTS.Value = APPR_COMMENTS
            arParams(2) = paramAPPR_COMMENTS

            Dim paramCLIENT_COMMENTS As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            paramCLIENT_COMMENTS.Value = CLIENT_COMMENTS
            arParams(3) = paramCLIENT_COMMENTS

            Dim paramBILL_TYPE As New SqlParameter("@BILL_TYPE", SqlDbType.TinyInt)
            paramBILL_TYPE.Value = BILL_TYPE
            arParams(4) = paramBILL_TYPE

            Dim paramAPPR_STATUS As New SqlParameter("@APPR_STATUS", SqlDbType.SmallInt)
            If APPR_STATUS = 0 Then
                paramAPPR_STATUS.Value = System.DBNull.Value
            Else
                paramAPPR_STATUS.Value = APPR_STATUS
            End If
            arParams(5) = paramAPPR_STATUS

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_HDR_UPDATE", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

#End Region

#Region " Billing Approval (Details Grid) "

    Public Function ApprovalDetail_CalculateAmounts(ByVal BA_DTL_ID As Integer) As Boolean

        Try
            Dim arParams(1) As SqlParameter
            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_billing_approval_detail_calculate_amounts", arParams)

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Get a record's comment
    Public Function ApprovalDetail_GetComment(ByVal BA_DTL_ID As Integer, ByRef ApprovalComment As String, ByRef ClientComment As String) As String
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_FUNC_CMT_GET", "DtComments", arParams)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("FNC_COMMENTS")) = False Then
                    ApprovalComment = dt.Rows(0)("FNC_COMMENTS").ToString()
                Else
                    ApprovalComment = ""
                End If
                If IsDBNull(dt.Rows(0)("CLIENT_COMMENTS")) = False Then
                    ClientComment = dt.Rows(0)("CLIENT_COMMENTS").ToString()
                Else
                    ClientComment = ""
                End If
            Else
                ApprovalComment = ""
                ClientComment = ""
            End If

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Save a record's comment
    Public Function ApprovalDetail_UpdateComment(ByVal BA_DTL_ID As Integer, ByVal ApprovalComment As String, ByVal ClientComment As String) As String
        Try
            Dim arParams(3) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim paramFNC_COMMENTS As New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
            If ApprovalComment.Trim() = "" Then
                paramFNC_COMMENTS.Value = System.DBNull.Value
            Else
                paramFNC_COMMENTS.Value = ApprovalComment
            End If
            arParams(1) = paramFNC_COMMENTS

            Dim paramCLIENT_COMMENTS As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If ClientComment.Trim() = "" Then
                paramCLIENT_COMMENTS.Value = System.DBNull.Value
            Else
                paramCLIENT_COMMENTS.Value = ClientComment
            End If
            arParams(2) = paramCLIENT_COMMENTS

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_FUNC_CMT_UPDATE", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function ApprovalDetailGetBillingRate(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal FncCode As String) As Decimal
        Try
            Dim arParams(3) As SqlParameter
            Dim paramJOB_NUMBER As New SqlParameter("@THIS_JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNumber
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@THIS_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramFNC_CODE As New SqlParameter("@THIS_FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FncCode
            arParams(2) = paramFNC_CODE

            Return oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_GET_BILLING_RATE", arParams)

        Catch ex As Exception
            Return -1.0
        End Try
    End Function

    Public Function ApprovalDetail_UpdateRow(ByVal BaDtlId As Integer, ByVal QtyHrs As Decimal, ByVal FncDescription As String, _
                                                ByVal ApprovedAmt As Decimal, ByVal ApprovalComments As String, ByVal ClientComments As String, _
                                                ByVal RowType As Integer, ByVal BillingRate As Decimal, ByVal ApprovedNet As Decimal, _
                                                ByVal ApprMarkupPct As Decimal, ByVal ApprMarkupAmt As Decimal, ByVal ApprTaxCode As String, _
                                                ByVal ApprTaxComm As Integer, ByVal ApprTaxCommOnly As Integer, ByVal ApprTaxResale As Integer, _
                                                ByVal ApprResaleTax As Decimal, ByVal ApprVendorTax As Decimal, ByVal ApprTaxStatePct As Decimal, _
                                                ByVal ApprTaxCountyPct As Decimal, ByVal ApprTaxCityPct As Decimal) As String
        Try
            Dim arParams(20) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BaDtlId
            arParams(0) = paramBA_DTL_ID

            Dim paramQTY_HRS As New SqlParameter("@QTY_HRS", SqlDbType.Decimal)
            paramQTY_HRS.Value = QtyHrs
            arParams(1) = paramQTY_HRS

            Dim paramBILLING_RATE As New SqlParameter("@BILLING_RATE", SqlDbType.Decimal)
            paramBILLING_RATE.Value = BillingRate
            arParams(2) = paramBILLING_RATE

            Dim paramFNC_DESC As New SqlParameter("@FNC_DESC", SqlDbType.VarChar, 30)
            paramFNC_DESC.Value = FncDescription
            arParams(3) = paramFNC_DESC

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            paramAPPROVED_AMT.Value = ApprovedAmt
            arParams(4) = paramAPPROVED_AMT

            Dim paramFNC_COMMENTS As New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
            If ApprovalComments.Trim() = "" Then
                paramFNC_COMMENTS.Value = System.DBNull.Value
            Else
                paramFNC_COMMENTS.Value = ApprovalComments
            End If
            arParams(5) = paramFNC_COMMENTS

            Dim paramCLIENT_COMMENTS As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If ClientComments.Trim() = "" Then
                paramCLIENT_COMMENTS.Value = System.DBNull.Value
            Else
                paramCLIENT_COMMENTS.Value = ClientComments
            End If
            arParams(6) = paramCLIENT_COMMENTS

            Dim paramROW_TYPE As New SqlParameter("@ROW_TYPE", SqlDbType.TinyInt)
            If RowType <= 0 Then
                paramROW_TYPE.Value = System.DBNull.Value
            Else
                paramROW_TYPE.Value = RowType
            End If
            arParams(7) = paramROW_TYPE

            Dim paramAPPR_NET As New SqlParameter("@APPR_NET", SqlDbType.Decimal)
            paramAPPR_NET.Value = ApprovedNet
            arParams(8) = paramAPPR_NET

            Dim paramAPPR_MARKUP_PCT As New SqlParameter("@APPR_MARKUP_PCT", SqlDbType.Decimal)
            paramAPPR_MARKUP_PCT.Value = ApprMarkupPct
            arParams(9) = paramAPPR_MARKUP_PCT

            Dim paramAPPR_MARKUP_AMT As New SqlParameter("@APPR_MARKUP_AMT", SqlDbType.Decimal)
            paramAPPR_MARKUP_AMT.Value = ApprMarkupAmt
            arParams(10) = paramAPPR_MARKUP_AMT

            Dim paramAPPR_TAX_CODE As New SqlParameter("@APPR_TAX_CODE", SqlDbType.VarChar, 4)
            If ApprTaxCode.Trim() = "" Then
                paramAPPR_TAX_CODE.Value = System.DBNull.Value
            Else
                paramAPPR_TAX_CODE.Value = ApprTaxCode.Trim()
            End If
            arParams(11) = paramAPPR_TAX_CODE

            Dim paramAPPR_TAX_COMM As New SqlParameter("@APPR_TAX_COMM", SqlDbType.SmallInt)
            paramAPPR_TAX_COMM.Value = ApprTaxComm
            arParams(12) = paramAPPR_TAX_COMM

            Dim paramAPPR_TAX_COMM_ONLY As New SqlParameter("@APPR_TAX_COMM_ONLY", SqlDbType.SmallInt)
            paramAPPR_TAX_COMM_ONLY.Value = ApprTaxCommOnly
            arParams(13) = paramAPPR_TAX_COMM_ONLY

            Dim paramAPPR_TAX_RESALE As New SqlParameter("@APPR_TAX_RESALE", SqlDbType.SmallInt)
            paramAPPR_TAX_RESALE.Value = ApprTaxResale
            arParams(14) = paramAPPR_TAX_RESALE

            Dim paramAPPR_RESALE_TAX As New SqlParameter("@APPR_RESALE_TAX", SqlDbType.Decimal)
            paramAPPR_RESALE_TAX.Value = ApprResaleTax
            arParams(15) = paramAPPR_RESALE_TAX

            Dim paramAPPR_VENDOR_TAX As New SqlParameter("@APPR_VENDOR_TAX", SqlDbType.Decimal)
            paramAPPR_VENDOR_TAX.Value = ApprVendorTax
            arParams(16) = paramAPPR_VENDOR_TAX

            Dim paramAPPR_TAX_STATE_PCT As New SqlParameter("@APPR_TAX_STATE_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_STATE_PCT.Value = ApprTaxStatePct
            arParams(17) = paramAPPR_TAX_STATE_PCT

            Dim paramAPPR_TAX_COUNTY_PCT As New SqlParameter("@APPR_TAX_COUNTY_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_COUNTY_PCT.Value = ApprTaxCountyPct
            arParams(18) = paramAPPR_TAX_COUNTY_PCT

            Dim paramAPPR_TAX_CITY_PCT As New SqlParameter("@APPR_TAX_CITY_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_CITY_PCT.Value = ApprTaxCityPct
            arParams(19) = paramAPPR_TAX_CITY_PCT

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_UPDATE", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function ApprovalDetail_AddRow(ByVal BaId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, _
                                            ByVal FncCode As String, ByVal QtyHrs As Decimal, ByVal FncDescription As String, _
                                            ByVal ApprovedAmt As Decimal, ByVal ApprovalComments As String, ByVal ClientComments As String, _
                                            ByVal RowType As Integer, ByVal BillingRate As Decimal, ByVal ApprovedNet As Decimal, _
                                            ByVal ApprMarkupPct As Decimal, ByVal ApprMarkupAmt As Decimal, ByVal ApprTaxCode As String, _
                                            ByVal ApprTaxComm As Integer, ByVal ApprTaxCommOnly As Integer, ByVal ApprTaxResale As Integer, _
                                            ByVal ApprResaleTax As Decimal, ByVal ApprVendorTax As Decimal, ByVal ApprTaxStatePct As Decimal, _
                                            ByVal ApprTaxCountyPct As Decimal, ByVal ApprTaxCityPct As Decimal, ByVal IsUserRow As Boolean, ByRef ErrorMessage As String) As Integer
        Try

            Dim arParams(24) As SqlParameter

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BaId
            arParams(0) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNumber
            arParams(1) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(2) = paramJOB_COMPONENT_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FncCode
            arParams(3) = paramFNC_CODE

            Dim paramQTY_HRS As New SqlParameter("@QTY_HRS", SqlDbType.Decimal)
            paramQTY_HRS.Value = QtyHrs
            arParams(4) = paramQTY_HRS

            Dim paramFNC_DESC As New SqlParameter("@FNC_DESC", SqlDbType.VarChar, 30)
            paramFNC_DESC.Value = FncDescription
            arParams(5) = paramFNC_DESC

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            paramAPPROVED_AMT.Value = ApprovedAmt
            arParams(6) = paramAPPROVED_AMT

            Dim paramFNC_COMMENTS As New SqlParameter("@FNC_COMMENTS", SqlDbType.Text)
            If ApprovalComments.Trim() = "" Then

                paramFNC_COMMENTS.Value = System.DBNull.Value

            Else

                paramFNC_COMMENTS.Value = ApprovalComments

            End If
            arParams(7) = paramFNC_COMMENTS

            Dim paramCLIENT_COMMENTS As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If ClientComments.Trim() = "" Then

                paramCLIENT_COMMENTS.Value = System.DBNull.Value

            Else

                paramCLIENT_COMMENTS.Value = ClientComments

            End If
            arParams(8) = paramCLIENT_COMMENTS

            Dim paramROW_TYPE As New SqlParameter("@ROW_TYPE", SqlDbType.TinyInt)
            paramROW_TYPE.Value = RowType
            arParams(9) = paramROW_TYPE

            Dim paramBILLING_RATE As New SqlParameter("@BILLING_RATE", SqlDbType.Decimal)
            paramBILLING_RATE.Value = BillingRate
            arParams(10) = paramBILLING_RATE

            Dim paramAPPR_NET As New SqlParameter("@APPR_NET", SqlDbType.Decimal)
            paramAPPR_NET.Value = ApprovedNet
            arParams(11) = paramAPPR_NET

            Dim paramAPPR_MARKUP_PCT As New SqlParameter("@APPR_MARKUP_PCT", SqlDbType.Decimal)
            paramAPPR_MARKUP_PCT.Value = ApprMarkupPct
            arParams(12) = paramAPPR_MARKUP_PCT

            Dim paramAPPR_MARKUP_AMT As New SqlParameter("@APPR_MARKUP_AMT", SqlDbType.Decimal)
            paramAPPR_MARKUP_AMT.Value = ApprMarkupAmt
            arParams(13) = paramAPPR_MARKUP_AMT

            Dim paramAPPR_TAX_CODE As New SqlParameter("@APPR_TAX_CODE", SqlDbType.VarChar, 4)
            If ApprTaxCode.Trim() = "" Then

                paramAPPR_TAX_CODE.Value = System.DBNull.Value

            Else

                paramAPPR_TAX_CODE.Value = ApprTaxCode.Trim()

            End If
            arParams(14) = paramAPPR_TAX_CODE

            Dim paramAPPR_TAX_COMM As New SqlParameter("@APPR_TAX_COMM", SqlDbType.SmallInt)
            paramAPPR_TAX_COMM.Value = ApprTaxComm
            arParams(15) = paramAPPR_TAX_COMM

            Dim paramAPPR_TAX_COMM_ONLY As New SqlParameter("@APPR_TAX_COMM_ONLY", SqlDbType.SmallInt)
            paramAPPR_TAX_COMM_ONLY.Value = ApprTaxCommOnly
            arParams(16) = paramAPPR_TAX_COMM_ONLY

            Dim paramAPPR_TAX_RESALE As New SqlParameter("@APPR_TAX_RESALE", SqlDbType.SmallInt)
            paramAPPR_TAX_RESALE.Value = ApprTaxResale
            arParams(17) = paramAPPR_TAX_RESALE

            Dim paramAPPR_RESALE_TAX As New SqlParameter("@APPR_RESALE_TAX", SqlDbType.Decimal)
            paramAPPR_RESALE_TAX.Value = ApprResaleTax
            arParams(18) = paramAPPR_RESALE_TAX

            Dim paramAPPR_VENDOR_TAX As New SqlParameter("@APPR_VENDOR_TAX", SqlDbType.Decimal)
            paramAPPR_VENDOR_TAX.Value = ApprVendorTax
            arParams(19) = paramAPPR_VENDOR_TAX

            Dim paramAPPR_TAX_STATE_PCT As New SqlParameter("@APPR_TAX_STATE_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_STATE_PCT.Value = ApprTaxStatePct
            arParams(20) = paramAPPR_TAX_STATE_PCT

            Dim paramAPPR_TAX_COUNTY_PCT As New SqlParameter("@APPR_TAX_COUNTY_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_COUNTY_PCT.Value = ApprTaxCountyPct
            arParams(21) = paramAPPR_TAX_COUNTY_PCT

            Dim paramAPPR_TAX_CITY_PCT As New SqlParameter("@APPR_TAX_CITY_PCT", SqlDbType.Decimal)
            paramAPPR_TAX_CITY_PCT.Value = ApprTaxCityPct
            arParams(22) = paramAPPR_TAX_CITY_PCT

            Dim paramIS_USER_ROW As New SqlParameter("@IS_USER_ROW", SqlDbType.Bit)

            If IsUserRow = True Then

                paramIS_USER_ROW.Value = 1

            Else

                paramIS_USER_ROW.Value = 0

            End If
            arParams(23) = paramIS_USER_ROW


            Dim i As Integer = 0
            i = CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_INSERT", arParams), Integer)

            Return i

        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return 0

        End Try

    End Function

    Public Function ApprovalDetail_DeleteRow(ByVal BaDtlId As Integer) As String
        Try
            Dim arParams(1) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BaDtlId
            arParams(0) = paramBA_DTL_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_DELETE_ROW", arParams)

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'Public Function ApprovalDetail_GetBillingRateData(ByVal FunctionCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal BatchID As Integer, _
    '                ByRef BillingRate As Decimal, ByRef RowType As Integer, ByRef MarkupPct As Decimal, ByRef TaxCode As String, ByRef TaxComm As Integer, ByRef TaxResale As Integer, ByRef ResaleTax As Decimal, _
    '                ByRef VendorTax As Decimal, ByRef StatePct As Decimal, ByRef CountyPct As Decimal, ByRef CityPct As Decimal) As String
    Public Function ApprovalDetail_GetBillingRateData(ByVal FunctionCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal BatchID As Integer, _
                 ByRef BillingRate As Decimal, ByRef RowType As Integer, ByRef MarkupPct As Decimal, ByRef TaxCode As String, ByRef TaxComm As Integer, ByRef TaxResale As Integer, _
                 ByRef StatePct As Decimal, ByRef CountyPct As Decimal, ByRef CityPct As Decimal, ByRef TaxComOnly As Integer) As String
        'row type is no bill flag
        'comm is markup pct
        Try
            Dim arParams(4) As SqlParameter

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FunctionCode
            arParams(0) = paramFNC_CODE

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JobNumber
            arParams(1) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JobComponentNbr
            arParams(2) = paramJOB_COMPONENT_NBR

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BatchID
            arParams(3) = paramBA_BATCH_ID

            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_GET_USER_FUNCTION_DEFAULT", arParams)
            dt = ds.Tables(0)
            If CType(ds.Tables(1).Rows(0)(0), Integer) = 0 Then
                Return "INVALID_FNC_CODE"
            End If
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
                        BillingRate = CType(dt.Rows(0)("BILLING_RATE"), Decimal)
                    Else
                        BillingRate = 0.0
                    End If
                    If IsDBNull(dt.Rows(0)("NOBILL_FLAG")) = False Then
                        RowType = CType(dt.Rows(0)("NOBILL_FLAG"), Integer)
                    Else
                        RowType = 0
                    End If
                    If IsDBNull(dt.Rows(0)("COMM")) = False Then
                        MarkupPct = CType(dt.Rows(0)("COMM"), Decimal)
                    Else
                        MarkupPct = 0.0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_CODE")) = False Then
                        TaxCode = dt.Rows(0)("TAX_CODE").ToString().Trim()
                    Else
                        TaxCode = ""
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_COMM")) = False Then
                        TaxComm = CType(dt.Rows(0)("TAX_COMM"), Integer)
                    Else
                        TaxComm = 0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_COMM_ONLY")) = False Then
                        TaxComOnly = CType(dt.Rows(0)("TAX_COMM_ONLY"), Integer)
                    Else
                        TaxComOnly = 0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                        TaxResale = CType(dt.Rows(0)("TAX_RESALE"), Integer)
                    Else
                        TaxResale = 0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_STATE_PERCENT")) = False Then
                        StatePct = CType(dt.Rows(0)("TAX_STATE_PERCENT"), Decimal)
                    Else
                        StatePct = 0.0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_COUNTY_PERCENT")) = False Then
                        CountyPct = CType(dt.Rows(0)("TAX_COUNTY_PERCENT"), Decimal)
                    Else
                        CountyPct = 0.0
                    End If
                    If IsDBNull(dt.Rows(0)("TAX_CITY_PERCENT")) = False Then
                        CityPct = CType(dt.Rows(0)("TAX_CITY_PERCENT"), Decimal)
                    Else
                        CityPct = 0.0
                    End If
                End If
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

#Region " Datatable stuff "
    Private MainDT As New DataTable

    Public Function ApprovalDetailDatatable(ByVal CURR_JOB_NUMBER As Integer, ByVal CURR_JOB_COMPONENT_NBR As Integer, _
                                            ByVal BA_ID As Integer, ByVal BA_BATCH_ID As Integer, ByVal SortValue As Integer, _
                                            ByVal TempCutOffDate As String, ByVal ApproveThroughTypes As List(Of BillingApprovalFunctionType)) As DataTable
        CreateApprovalDetailTable()

        'add real data
        If CURR_JOB_NUMBER > 0 And CURR_JOB_COMPONENT_NBR > 0 Then

            Dim CurrBaDtlId As Integer = -1
            Dim CurrFncType As String = ""
            Dim CurrFncTypeDesc As String = ""
            Dim CurrFncCode As String = ""
            Dim CurrFncDescription As String = ""
            Dim CurrDfltDescription As String = ""
            Dim CurrQuoteAmt As Decimal = 0.0
            Dim CurrActuals As Decimal = 0.0
            Dim CurrBilledRec As Decimal = 0.0
            Dim CurrBillHold As Decimal = 0.0
            Dim CurrNonBillFee As Decimal = 0.0
            Dim CurrUnBilled As Decimal = 0.0
            Dim CurrOpenPO As Decimal = 0.0
            Dim CurrQuantity As Decimal = 0.0
            Dim CurrRate As Decimal = 0.0
            Dim CurrApprovedAmt As Decimal = 0.0
            Dim CurrApprovalComments As String = ""
            Dim CurrClientComments As String = ""
            Dim CurrItemExists As Boolean = False
            Dim CurrFncHeadingId As Integer = -1
            Dim CurrFncHeadingSeq As Integer = -1
            Dim CurrFncHeadingDesc As String = ""
            Dim CurrQuoteNet As Decimal = 0.0
            Dim CurrUnbilledNet As Decimal = 0.0
            Dim CurrApprovedNet As Decimal = 0.0

            Dim CurrApprMarkupPct As Decimal = 0.0
            Dim CurrApprMarkupAmt As Decimal = 0.0
            Dim CurrApprTaxCode As String = ""
            Dim CurrApprTaxComm As Integer = 0
            Dim CurrApprTaxCommOnly As Integer = 0
            Dim CurrApprTaxResale As Integer = 0
            Dim CurrApprResaleTax As Decimal = 0.0
            Dim CurrApprVendorTax As Decimal = 0.0
            Dim CurrApprTaxStatePct As Decimal = 0.0
            Dim CurrApprTaxCountyPct As Decimal = 0.0
            Dim CurrApprTaxCityPct As Decimal = 0.0
            Dim CurrRowType As Integer = 0

            Dim CurrQuoteMarkup As Decimal = 0.0
            Dim CurrQuoteResaleTax As Decimal = 0.0
            Dim CurrQuoteVendorTax As Decimal = 0.0
            Dim CurrUnbilledMarkup As Decimal = 0.0
            Dim CurrUnbilledResaleTax As Decimal = 0.0
            Dim CurrUnbilledVendorTax As Decimal = 0.0

            Dim CurrIsUserRow As Boolean = False

            Dim CurrIsUsingTempApproveAmt As Boolean = False
            Dim CurrTempCutoffApprovedAmt As Decimal = 0.0
            Dim CurrTempApprovedNet As Decimal = 0.0
            Dim CurrTempUnbilledNet As Decimal = 0.0

            Dim CurrQuoteQtyHrs As Decimal = 0.0
            Dim CurrActualQtyHrs As Decimal = 0.0

            Dim CurrTempMarkup As Decimal = 0.0
            Dim CurrTempResaleTax As Decimal = 0.0
            Dim CurrTempTotal As Decimal = 0.0
            Dim CurrTempUnbilledMU As Decimal = 0.0
            Dim CurrTempUnbilledTax As Decimal = 0.0
            Dim CurrTempUnbilleNR As Decimal = 0.0
            Dim CurrTempUnbilledTotal As Decimal = 0.0
            Dim CurrTempPO As Decimal = 0.0


            Dim DtRealData As New DataTable
            DtRealData = ApprovalDetailGetRealData(CURR_JOB_NUMBER, CURR_JOB_COMPONENT_NBR, BA_ID, BA_BATCH_ID, SortValue, TempCutOffDate, ApproveThroughTypes)

            If DtRealData.Rows.Count > 0 Then

                For i As Integer = 0 To DtRealData.Rows.Count - 1

                    If IsDBNull(DtRealData.Rows(i)("BA_DTL_ID")) = False Then
                        CurrBaDtlId = DtRealData.Rows(i)("BA_DTL_ID").ToString()
                    Else
                        CurrBaDtlId = -1
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_TYPE")) = False Then
                        CurrFncType = DtRealData.Rows(i)("FNC_TYPE").ToString()
                    Else
                        CurrFncType = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_TYPE_DESC")) = False Then
                        CurrFncTypeDesc = DtRealData.Rows(i)("FNC_TYPE_DESC").ToString()
                    Else
                        CurrFncTypeDesc = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_CODE")) = False Then
                        CurrFncCode = DtRealData.Rows(i)("FNC_CODE").ToString()
                    Else
                        CurrFncCode = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_DESC")) = False Then
                        CurrFncDescription = DtRealData.Rows(i)("FNC_DESC").ToString()
                    Else
                        CurrFncDescription = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("DEFAULT_DESC")) = False Then
                        CurrDfltDescription = DtRealData.Rows(i)("DEFAULT_DESC").ToString()
                    Else
                        CurrDfltDescription = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("QUOTE_AMT")) = False Then
                        CurrQuoteAmt = CType(DtRealData.Rows(i)("QUOTE_AMT"), Decimal)
                    Else
                        CurrQuoteAmt = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("ACTUALS")) = False Then
                        CurrActuals = CType(DtRealData.Rows(i)("ACTUALS"), Decimal)
                    Else
                        CurrActuals = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("BILLED_REC")) = False Then
                        CurrBilledRec = CType(DtRealData.Rows(i)("BILLED_REC"), Decimal)
                    Else
                        CurrBilledRec = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("BILL_HOLD")) = False Then
                        CurrBillHold = CType(DtRealData.Rows(i)("BILL_HOLD"), Decimal)
                    Else
                        CurrBillHold = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("NON_BILL_FEE")) = False Then
                        CurrNonBillFee = CType(DtRealData.Rows(i)("NON_BILL_FEE"), Decimal)
                    Else
                        CurrNonBillFee = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("UNBILLED")) = False Then
                        CurrUnBilled = CType(DtRealData.Rows(i)("UNBILLED"), Decimal)
                    Else
                        CurrUnBilled = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("OPEN_PO")) = False Then
                        CurrOpenPO = CType(DtRealData.Rows(i)("OPEN_PO"), Decimal)
                    Else
                        CurrOpenPO = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("QTY_HRS")) = False Then
                        CurrQuantity = CType(DtRealData.Rows(i)("QTY_HRS"), Decimal)
                    Else
                        CurrQuantity = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("RATE")) = False Then
                        CurrRate = CType(DtRealData.Rows(i)("RATE"), Decimal)
                    Else
                        CurrRate = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("APPROVED_AMT")) = False Then
                        CurrApprovedAmt = CType(DtRealData.Rows(i)("APPROVED_AMT"), Decimal)
                    Else
                        CurrApprovedAmt = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_CUTOFF_APPROVED_AMT")) = False Then
                        CurrTempCutoffApprovedAmt = CType(DtRealData.Rows(i)("TEMP_CUTOFF_APPROVED_AMT"), Decimal)
                    Else
                        CurrTempCutoffApprovedAmt = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("FNC_COMMENTS")) = False Then
                        CurrApprovalComments = DtRealData.Rows(i)("FNC_COMMENTS").ToString()
                    Else
                        CurrApprovalComments = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("CLIENT_COMMENTS")) = False Then
                        CurrClientComments = DtRealData.Rows(i)("CLIENT_COMMENTS").ToString()
                    Else
                        CurrClientComments = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("ITEM_EXISTS")) = False Then
                        CurrItemExists = DtRealData.Rows(i)("ITEM_EXISTS").ToString()
                    Else
                        CurrItemExists = False
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_ID")) = False Then
                        CurrFncHeadingId = DtRealData.Rows(i)("FNC_HEADING_ID").ToString()
                    Else
                        CurrFncHeadingId = -1
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_SEQ")) = False Then
                        CurrFncHeadingSeq = DtRealData.Rows(i)("FNC_HEADING_SEQ").ToString()
                    Else
                        CurrFncHeadingSeq = -1
                    End If
                    If IsDBNull(DtRealData.Rows(i)("FNC_HEADING_DESC")) = False Then
                        CurrFncHeadingDesc = DtRealData.Rows(i)("FNC_HEADING_DESC").ToString()
                    Else
                        CurrFncHeadingDesc = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("QUOTE_NET")) = False Then
                        CurrQuoteNet = CType(DtRealData.Rows(i)("QUOTE_NET"), Decimal)
                    Else
                        CurrQuoteNet = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("UNBILLED_NET")) = False Then
                        CurrUnbilledNet = CType(DtRealData.Rows(i)("UNBILLED_NET"), Decimal)
                    Else
                        CurrUnbilledNet = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_UNBILLED_NET")) = False Then
                        CurrTempUnbilledNet = CType(DtRealData.Rows(i)("TEMP_UNBILLED_NET"), Decimal)
                    Else
                        CurrTempUnbilledNet = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("APPR_NET")) = False Then
                        CurrApprovedNet = CType(DtRealData.Rows(i)("APPR_NET"), Decimal)
                    Else
                        CurrApprovedNet = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("TEMP_APPR_NET")) = False Then
                        CurrTempApprovedNet = CType(DtRealData.Rows(i)("TEMP_APPR_NET"), Decimal)
                    Else
                        CurrTempApprovedNet = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("APPR_MARKUP_PCT")) = False Then
                        CurrApprMarkupPct = CType(DtRealData.Rows(i)("APPR_MARKUP_PCT"), Decimal)
                    Else
                        CurrApprMarkupPct = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_MARKUP_AMT")) = False Then
                        CurrApprMarkupAmt = CType(DtRealData.Rows(i)("APPR_MARKUP_AMT"), Decimal)
                    Else
                        CurrApprMarkupAmt = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_CODE")) = False Then
                        CurrApprTaxCode = CType(DtRealData.Rows(i)("APPR_TAX_CODE"), String)
                    Else
                        CurrApprTaxCode = ""
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_COMM")) = False Then
                        CurrApprTaxComm = CType(DtRealData.Rows(i)("APPR_TAX_COMM"), Integer)
                    Else
                        CurrApprTaxComm = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_COMM_ONLY")) = False Then
                        CurrApprTaxCommOnly = CType(DtRealData.Rows(i)("APPR_TAX_COMM_ONLY"), Integer)
                    Else
                        CurrApprTaxCommOnly = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_RESALE")) = False Then
                        CurrApprTaxResale = CType(DtRealData.Rows(i)("APPR_TAX_RESALE"), Integer)
                    Else
                        CurrApprTaxResale = 0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_RESALE_TAX")) = False Then
                        CurrApprResaleTax = CType(DtRealData.Rows(i)("APPR_RESALE_TAX"), Decimal)
                    Else
                        CurrApprResaleTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_VENDOR_TAX")) = False Then
                        CurrApprVendorTax = CType(DtRealData.Rows(i)("APPR_VENDOR_TAX"), Decimal)
                    Else
                        CurrApprVendorTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_STATE_PCT")) = False Then
                        CurrApprTaxStatePct = CType(DtRealData.Rows(i)("APPR_TAX_STATE_PCT"), Decimal)
                    Else
                        CurrApprTaxStatePct = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_COUNTY_PCT")) = False Then
                        CurrApprTaxCountyPct = CType(DtRealData.Rows(i)("APPR_TAX_COUNTY_PCT"), Decimal)
                    Else
                        CurrApprTaxCountyPct = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("APPR_TAX_CITY_PCT")) = False Then
                        CurrApprTaxCityPct = CType(DtRealData.Rows(i)("APPR_TAX_CITY_PCT"), Decimal)
                    Else
                        CurrApprTaxCityPct = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("ROW_TYPE")) = False Then
                        CurrRowType = CType(DtRealData.Rows(i)("ROW_TYPE"), Integer)
                    Else
                        CurrRowType = 0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("QUOTE_MARKUP")) = False Then
                        CurrQuoteMarkup = CType(DtRealData.Rows(i)("QUOTE_MARKUP"), Decimal)
                    Else
                        CurrQuoteMarkup = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("QUOTE_RESALE_TAX")) = False Then
                        CurrQuoteResaleTax = CType(DtRealData.Rows(i)("QUOTE_RESALE_TAX"), Decimal)
                    Else
                        CurrQuoteResaleTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("QUOTE_VENDOR_TAX")) = False Then
                        CurrQuoteVendorTax = CType(DtRealData.Rows(i)("QUOTE_VENDOR_TAX"), Decimal)
                    Else
                        CurrQuoteVendorTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("UNBILLED_MARKUP")) = False Then
                        CurrUnbilledMarkup = CType(DtRealData.Rows(i)("UNBILLED_MARKUP"), Decimal)
                    Else
                        CurrUnbilledMarkup = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("UNBILLED_RESALE_TAX")) = False Then
                        CurrUnbilledResaleTax = CType(DtRealData.Rows(i)("UNBILLED_RESALE_TAX"), Decimal)
                    Else
                        CurrUnbilledResaleTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("UNBILLED_VENDOR_TAX")) = False Then
                        CurrUnbilledVendorTax = CType(DtRealData.Rows(i)("UNBILLED_VENDOR_TAX"), Decimal)
                    Else
                        CurrUnbilledVendorTax = 0.0
                    End If

                    If IsDBNull(DtRealData.Rows(i)("IS_USER_ROW")) = False Then
                        CurrIsUserRow = DtRealData.Rows(i)("IS_USER_ROW")
                    Else
                        CurrIsUserRow = False
                    End If

                    If IsDBNull(DtRealData.Rows(i)("IS_USING_TEMP_APPROVED_AMT")) = False Then
                        CurrIsUsingTempApproveAmt = DtRealData.Rows(i)("IS_USING_TEMP_APPROVED_AMT")
                        'CurrIsUsingTempApproveAmt = DtRealData.Rows(i)("IS_USING_TEMP_APPROVED_AMT") = 1
                    Else
                        CurrIsUsingTempApproveAmt = False
                    End If

                    If IsDBNull(DtRealData.Rows(i)("QUOTE_QTY_HRS")) = False Then
                        CurrQuoteQtyHrs = CType(DtRealData.Rows(i)("QUOTE_QTY_HRS"), Decimal)
                    Else
                        CurrQuoteQtyHrs = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("ACTUAL_QTY_HRS")) = False Then
                        CurrActualQtyHrs = CType(DtRealData.Rows(i)("ACTUAL_QTY_HRS"), Decimal)
                    Else
                        CurrActualQtyHrs = 0.0
                    End If


                    If IsDBNull(DtRealData.Rows(i)("TEMP_MARKUP")) = False Then
                        CurrTempMarkup = CType(DtRealData.Rows(i)("TEMP_MARKUP"), Decimal)
                    Else
                        CurrTempMarkup = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_RESALE_TAX")) = False Then
                        CurrTempResaleTax = CType(DtRealData.Rows(i)("TEMP_RESALE_TAX"), Decimal)
                    Else
                        CurrTempResaleTax = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_TOTAL")) = False Then
                        CurrTempTotal = CType(DtRealData.Rows(i)("TEMP_TOTAL"), Decimal)
                    Else
                        CurrTempTotal = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_UNBILLED_MU")) = False Then
                        CurrTempUnbilledMU = CType(DtRealData.Rows(i)("TEMP_UNBILLED_MU"), Decimal)
                    Else
                        CurrTempUnbilledMU = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_UNBILLED_TAX")) = False Then
                        CurrTempUnbilledTax = CType(DtRealData.Rows(i)("TEMP_UNBILLED_TAX"), Decimal)
                    Else
                        CurrTempUnbilledTotal = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_UNBILLED_NR")) = False Then
                        CurrTempUnbilleNR = CType(DtRealData.Rows(i)("TEMP_UNBILLED_NR"), Decimal)
                    Else
                        CurrTempUnbilleNR = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_UNBILLED_TOT")) = False Then
                        CurrTempUnbilledTotal = CType(DtRealData.Rows(i)("TEMP_UNBILLED_TOT"), Decimal)
                    Else
                        CurrTempUnbilledTotal = 0.0
                    End If
                    If IsDBNull(DtRealData.Rows(i)("TEMP_PO")) = False Then
                        CurrTempPO = CType(DtRealData.Rows(i)("TEMP_PO"), Decimal)
                    Else
                        CurrTempPO = 0.0
                    End If


                    ApprovalDetailDatatable_AddRow(MainDT, CurrBaDtlId, CurrFncType, CurrFncTypeDesc, CurrFncCode, CurrFncDescription, CurrDfltDescription, _
                                                   CurrQuoteAmt, CurrActuals, CurrBilledRec, CurrBillHold, CurrNonBillFee, _
                                                   CurrUnBilled, CurrOpenPO, CurrQuantity, CurrRate, CurrApprovedAmt, CurrApprovalComments, _
                                                   CurrClientComments, False, CurrItemExists, CurrFncHeadingId, CurrFncHeadingSeq, _
                                                   CurrFncHeadingDesc, CurrQuoteNet, CurrUnbilledNet, CurrApprovedNet, _
                                                   CurrApprMarkupPct, CurrApprMarkupAmt, CurrApprTaxCode, CurrApprTaxComm, _
                                                   CurrApprTaxCommOnly, CurrApprTaxResale, CurrApprResaleTax, CurrApprVendorTax, CurrApprTaxStatePct, _
                                                   CurrApprTaxCountyPct, CurrApprTaxCityPct, CurrRowType, CurrQuoteMarkup, CurrQuoteResaleTax, _
                                                   CurrQuoteVendorTax, CurrUnbilledMarkup, CurrUnbilledResaleTax, CurrUnbilledVendorTax, CurrIsUserRow, _
                                                   CurrIsUsingTempApproveAmt, CurrTempCutoffApprovedAmt, CurrTempUnbilledNet, CurrTempApprovedNet, CurrQuoteQtyHrs, CurrActualQtyHrs, _
                                                   CurrTempMarkup, CurrTempResaleTax, CurrTempTotal, CurrTempUnbilledMU, CurrTempUnbilledTax, CurrTempUnbilleNR, CurrTempUnbilledTotal, CurrTempPO)

                Next
            End If
        Else 'add one "fake" row?
            ApprovalDetailDatatable_AddRow_User(MainDT, "", "", "", "", 0.0, 0.0, 0.0, "", "", 0.0, 0)
        End If

        Return MainDT
    End Function
    'update the datatable, mainly just to maintain the user added rows when adding more rows:
    Public Function ApprovalDetailDatatable_UpdateRow_User(ByRef TheDT As DataTable, ByVal PrimaryKey As Integer, ByVal FncCode As String, ByVal FncDescription As String, _
                                            ByVal Quantity As Decimal, ByVal Rate As Decimal, ByVal ApprovedAmount As Decimal, _
                                            ByVal ApprovalComments As String, ByVal ClientComments As String, ByVal ApprovedNet As Decimal) As String
        Try
            'TheDT.DefaultView(RowIndex)("") = ""
            Dim r As DataRow
            r = TheDT.Rows.Find(PrimaryKey)
            r("FNC_CODE") = FncCode
            r("FNC_DESCRIPTION") = FncDescription
            r("QUANTITY") = Quantity
            r("RATE") = Rate
            r("APPROVED_AMT") = ApprovedAmount
            r("APPR_COMMENTS") = ApprovalComments
            r("CLIENT_COMMENTS") = ClientComments


            'ApprovalDetailDatatable_AddRow(TheDT, -1, FncType, FncTypeDesc, FncCode, FncDescription, FncDescription, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Quantity, Rate, ApprovedAmount, ApprovalComments, ClientComments, True)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function ApprovalDetailDatatable_UpdateRow_NonUser(ByRef TheDT As DataTable, ByVal PrimaryKey As Integer, ByVal FncDescription As String, _
                                            ByVal Quantity As Decimal, ByVal Rate As Decimal, ByVal ApprovedAmount As Decimal, _
                                            ByVal ApprovalComments As String, ByVal ClientComments As String, ByVal ApprovedNet As Decimal) As String
        Try
            'TheDT.DefaultView(RowIndex)("") = ""
            Dim r As DataRow
            r = TheDT.Rows.Find(PrimaryKey)
            r("FNC_DESCRIPTION") = FncDescription
            r("QUANTITY") = Quantity
            r("RATE") = Rate
            r("APPROVED_AMT") = ApprovedAmount
            r("APPR_COMMENTS") = ApprovalComments
            r("CLIENT_COMMENTS") = ClientComments
            r("APPR_NET") = ApprovedNet


            'ApprovalDetailDatatable_AddRow(TheDT, -1, FncType, FncTypeDesc, FncCode, FncDescription, FncDescription, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Quantity, Rate, ApprovedAmount, ApprovalComments, ClientComments, True)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'add a user row to the DATATABLE (NOT DATABASE)
    Public Function ApprovalDetailDatatable_AddRow_User(ByRef TheDT As DataTable, ByVal FncType As String, ByVal FncTypeDesc As String, ByVal FncCode As String, ByVal FncDescription As String, _
                                                ByVal Quantity As Decimal, ByVal Rate As Decimal, ByVal ApprovedAmount As Decimal, _
                                                ByVal ApprovalComments As String, ByVal ClientComments As String, ByVal ApprovedNet As Decimal, ByVal Rowtype As Integer) As String
        Try
            'TODO_SAM: add new rate/tax stuff
            ApprovalDetailDatatable_AddRow(TheDT, -1, FncType, FncTypeDesc, FncCode, FncDescription, FncDescription, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Quantity, Rate, ApprovedAmount, ApprovalComments, ClientComments, True, False, -1, -1, "", 0.0, 0.0, ApprovedNet, _
                                            0.0, 0.0, "", 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, Rowtype, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, True, False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    'add rows to the datatable
    Private Sub ApprovalDetailDatatable_AddRow(ByRef TheDT As DataTable, ByVal BaDtlId As Integer, ByVal FncType As String, ByVal FncTypeDesc As String, ByVal FncCode As String, ByVal FncDescription As String, ByVal DfltDescription As String, _
                                                ByVal QuoteAmt As Decimal, ByVal Actuals As Decimal, ByVal BilledRec As Decimal, ByVal BillHold As Decimal, _
                                                ByVal NonBillFee As Decimal, ByVal UnBilled As Decimal, ByVal OpenPO As Decimal, _
                                                ByVal QtyHrs As Decimal, ByVal Rate As Decimal, _
                                                ByVal ApprovedAmt As Decimal, ByVal ApprovalComments As String, ByVal ClientComments As String, _
                                                ByVal IsUserAdded As Boolean, ByVal ItemExists As Boolean, _
                                                ByVal FncHeadingId As Integer, ByVal FncHeadingSeq As Integer, ByVal FncHeadingDesc As String, _
                                                ByVal QuoteNet As Decimal, ByVal UnbilledNet As Decimal, ByVal ApprovedNet As Decimal, _
                                                ByVal ApprMarkupPct As Decimal, ByVal ApprMarkupAmt As Decimal, ByVal ApprTaxCode As String, _
                                                ByVal ApprTaxComm As Integer, ByVal ApprTaxCommOnly As Integer, ByVal ApprTaxResale As Integer, _
                                                ByVal ApprResaleTax As Decimal, ByVal ApprVendorTax As Decimal, ByVal ApprTaxStatePct As Decimal, _
                                                ByVal ApprTaxCountyPct As Decimal, ByVal ApprTaxCityPct As Decimal, ByVal RowType As Integer, _
                                                ByVal QuoteMarkup As Decimal, ByVal QuoteResaleTax As Decimal, ByVal QuoteVendorTax As Decimal, _
                                                ByVal UnbilledMarkup As Decimal, ByVal UnbilledResaleTax As Decimal, ByVal UnbilledVendorTax As Decimal, ByVal IsUserRow As Boolean, _
                                                ByVal IsUsingTempCutoffApprovedAmt As Boolean, _
                                                ByVal TempCutoffApprovalAmt As Decimal, ByVal TempCutoffUnbilledNet As Decimal, ByVal TempCutoffApprNet As Decimal, _
                                                ByVal QuoteQtyHrs As Decimal, ByVal ActualQtyHrs As Decimal, _
                                                ByVal TempCutoffMarkup As Decimal, ByVal TempCutoffResaleTax As Decimal, ByVal TempCutoffTotal As Decimal, _
                                                ByVal TempCutoffUnbilledMU As Decimal, ByVal TempCutoffUnbilledTax As Decimal, ByVal TempCutoffUnbilledNR As Decimal, _
                                                ByVal TempCutoffUnbilledTotal As Decimal, ByVal TempCutoffPO As Decimal)


        Dim r As DataRow
        r = TheDT.NewRow()
        r("BA_DTL_ID") = BaDtlId
        r("FNC_TYPE") = FncType
        r("FNC_TYPE_DESC") = FncTypeDesc
        r("FNC_CODE") = FncCode
        r("FNC_DESCRIPTION") = FncDescription
        r("DEFAULT_DESCRIPTION") = DfltDescription
        r("QUOTE_AMT") = QuoteAmt
        r("ACTUALS") = Actuals
        r("BILLED_REC") = BilledRec
        r("BILL_HOLD") = BillHold
        r("NON_BILL_FEE") = NonBillFee
        r("UNBILLED") = UnBilled
        r("OPEN_PO") = OpenPO
        r("QUANTITY") = QtyHrs
        r("RATE") = Rate
        r("APPROVED_AMT") = ApprovedAmt
        r("APPR_COMMENTS") = ApprovalComments
        r("CLIENT_COMMENTS") = ClientComments
        r("IS_USER_ADDED") = IsUserAdded
        r("ITEM_EXISTS") = ItemExists

        r("FNC_HEADING_ID") = FncHeadingId
        r("FNC_HEADING_SEQ") = FncHeadingSeq
        r("FNC_HEADING_DESC") = FncHeadingDesc

        r("QUOTE_NET") = QuoteNet
        r("UNBILLED_NET") = UnbilledNet
        r("APPR_NET") = ApprovedNet

        r("APPR_MARKUP_PCT") = ApprMarkupPct
        r("APPR_MARKUP_AMT") = ApprMarkupAmt
        r("APPR_TAX_CODE") = ApprTaxCode
        r("APPR_TAX_COMM") = ApprTaxComm
        r("APPR_TAX_COMM_ONLY") = ApprTaxCommOnly
        r("APPR_TAX_RESALE") = ApprTaxResale
        r("APPR_RESALE_TAX") = ApprResaleTax
        r("APPR_VENDOR_TAX") = ApprVendorTax
        r("APPR_TAX_STATE_PCT") = ApprTaxStatePct
        r("APPR_TAX_COUNTY_PCT") = ApprTaxCountyPct
        r("APPR_TAX_CITY_PCT") = ApprTaxCityPct

        r("ROW_TYPE") = RowType

        r("QUOTE_MARKUP") = QuoteMarkup
        r("QUOTE_RESALE_TAX") = QuoteResaleTax
        r("QUOTE_VENDOR_TAX") = QuoteVendorTax
        r("UNBILLED_MARKUP") = UnbilledMarkup
        r("UNBILLED_RESALE_TAX") = UnbilledResaleTax
        r("UNBILLED_VENDOR_TAX") = UnbilledVendorTax

        r("IS_USER_ROW") = IsUserRow

        r("IS_USING_TEMP_APPROVED_AMT") = IsUsingTempCutoffApprovedAmt
        r("TEMP_CUTOFF_APPROVED_AMT") = TempCutoffApprovalAmt
        r("TEMP_CUTOFF_UNBILLED_NET") = TempCutoffUnbilledNet
        r("TEMP_CUTOFF_APPR_NET") = TempCutoffApprNet

        r("QUOTE_QTY_HRS") = QuoteQtyHrs
        r("ACTUAL_QTY_HRS") = ActualQtyHrs

        r("TEMP_CUTOFF_MARKUP") = TempCutoffMarkup
        r("TEMP_CUTOFF_RESALE_TAX") = TempCutoffResaleTax
        r("TEMP_CUTOFF_TOTAL") = TempCutoffTotal
        r("TEMP_CUTOFF_UNBILLED_MU") = TempCutoffUnbilledMU
        r("TEMP_CUTOFF_UNBILLED_TAX") = TempCutoffUnbilledTax
        r("TEMP_CUTOFF_UNBILLED_NR") = TempCutoffUnbilledNR
        r("TEMP_CUTOFF_UNBILLED_TOT") = TempCutoffUnbilledTotal
        r("TEMP_CUTOFF_PO") = TempCutoffPO

        TheDT.Rows.Add(r)

    End Sub
    'create the datatable
    Private Sub CreateApprovalDetailTable()
        Dim Pk(0) As DataColumn

        Dim COL_INDEX As DataColumn = New DataColumn("INDEX")
        With COL_INDEX
            .DataType = GetType(Int32)
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Pk(0) = COL_INDEX

        Dim COL_BA_DTL_ID As DataColumn = New DataColumn("BA_DTL_ID")
        COL_BA_DTL_ID.DataType = GetType(Int32)

        Dim COL_FNC_TYPE As DataColumn = New DataColumn("FNC_TYPE")
        COL_FNC_TYPE.DataType = GetType(String)

        Dim COL_FNC_TYPE_DESC As DataColumn = New DataColumn("FNC_TYPE_DESC")
        COL_FNC_TYPE_DESC.DataType = GetType(String)

        Dim COL_FNC_CODE As DataColumn = New DataColumn("FNC_CODE")
        COL_FNC_CODE.DataType = GetType(String)

        Dim COL_FNC_DESCRIPTION As DataColumn = New DataColumn("FNC_DESCRIPTION")
        COL_FNC_DESCRIPTION.DataType = GetType(String)

        Dim COL_DEFAULT_DESCRIPTION As DataColumn = New DataColumn("DEFAULT_DESCRIPTION")
        COL_DEFAULT_DESCRIPTION.DataType = GetType(String)

        Dim COL_QUOTE_AMT As DataColumn = New DataColumn("QUOTE_AMT")
        COL_QUOTE_AMT.DataType = GetType(Decimal)

        Dim COL_ACTUALS As DataColumn = New DataColumn("ACTUALS")
        COL_ACTUALS.DataType = GetType(Decimal)

        Dim COL_BILLED_REC As DataColumn = New DataColumn("BILLED_REC")
        COL_BILLED_REC.DataType = GetType(Decimal)

        Dim COL_BILL_HOLD As DataColumn = New DataColumn("BILL_HOLD")
        COL_BILL_HOLD.DataType = GetType(Decimal)

        Dim COL_NON_BILL_FEE As DataColumn = New DataColumn("NON_BILL_FEE")
        COL_NON_BILL_FEE.DataType = GetType(Decimal)

        Dim COL_UNBILLED As DataColumn = New DataColumn("UNBILLED")
        COL_UNBILLED.DataType = GetType(Decimal)

        Dim COL_OPEN_PO As DataColumn = New DataColumn("OPEN_PO")
        COL_OPEN_PO.DataType = GetType(Decimal)

        Dim COL_QUANTITY As DataColumn = New DataColumn("QUANTITY")
        COL_QUANTITY.DataType = GetType(Decimal)

        Dim COL_RATE As DataColumn = New DataColumn("RATE")
        COL_RATE.DataType = GetType(Decimal)

        Dim COL_APPROVED_AMT As DataColumn = New DataColumn("APPROVED_AMT")
        COL_APPROVED_AMT.DataType = GetType(Decimal)

        Dim COL_APPROVAL_COMMENTS As DataColumn = New DataColumn("APPR_COMMENTS")
        COL_APPROVAL_COMMENTS.DataType = GetType(String)

        Dim COL_CLIENT_COMMENTS As DataColumn = New DataColumn("CLIENT_COMMENTS")
        COL_CLIENT_COMMENTS.DataType = GetType(String)

        Dim COL_IS_USER_ADDED As DataColumn = New DataColumn("IS_USER_ADDED")
        COL_IS_USER_ADDED.DataType = GetType(Boolean)

        Dim COL_ITEM_EXISTS As DataColumn = New DataColumn("ITEM_EXISTS")
        COL_ITEM_EXISTS.DataType = GetType(Boolean)

        Dim COL_FNC_HEADING_ID As DataColumn = New DataColumn("FNC_HEADING_ID")
        COL_FNC_HEADING_ID.DataType = GetType(Int32)

        Dim COL_FNC_HEADING_SEQ As DataColumn = New DataColumn("FNC_HEADING_SEQ")
        COL_FNC_HEADING_SEQ.DataType = GetType(Int32)

        Dim COL_FNC_HEADING_DESC As DataColumn = New DataColumn("FNC_HEADING_DESC")
        COL_FNC_HEADING_DESC.DataType = GetType(String)

        Dim COL_QUOTE_NET As DataColumn = New DataColumn("QUOTE_NET")
        COL_QUOTE_NET.DataType = GetType(Decimal)

        Dim COL_UNBILLED_NET As DataColumn = New DataColumn("UNBILLED_NET")
        COL_UNBILLED_NET.DataType = GetType(Decimal)

        Dim COL_APPR_NET As DataColumn = New DataColumn("APPR_NET")
        COL_APPR_NET.DataType = GetType(Decimal)

        Dim COL_APPR_MARKUP_PCT As DataColumn = New DataColumn("APPR_MARKUP_PCT")
        COL_APPR_MARKUP_PCT.DataType = GetType(Decimal)

        Dim COL_APPR_MARKUP_AMT As DataColumn = New DataColumn("APPR_MARKUP_AMT")
        COL_APPR_MARKUP_AMT.DataType = GetType(Decimal)

        Dim COL_APPR_TAX_CODE As DataColumn = New DataColumn("APPR_TAX_CODE")
        COL_APPR_TAX_CODE.DataType = GetType(String)

        Dim COL_APPR_TAX_COMM As DataColumn = New DataColumn("APPR_TAX_COMM")
        COL_APPR_TAX_COMM.DataType = GetType(Int32)

        Dim COL_APPR_TAX_COMM_ONLY As DataColumn = New DataColumn("APPR_TAX_COMM_ONLY")
        COL_APPR_TAX_COMM_ONLY.DataType = GetType(Int32)

        Dim COL_APPR_TAX_RESALE As DataColumn = New DataColumn("APPR_TAX_RESALE")
        COL_APPR_TAX_RESALE.DataType = GetType(Int32)

        Dim COL_APPR_RESALE_TAX As DataColumn = New DataColumn("APPR_RESALE_TAX")
        COL_APPR_RESALE_TAX.DataType = GetType(Decimal)

        Dim COL_APPR_VENDOR_TAX As DataColumn = New DataColumn("APPR_VENDOR_TAX")
        COL_APPR_VENDOR_TAX.DataType = GetType(Decimal)

        Dim COL_APPR_TAX_STATE_PCT As DataColumn = New DataColumn("APPR_TAX_STATE_PCT")
        COL_APPR_TAX_STATE_PCT.DataType = GetType(Decimal)

        Dim COL_APPR_TAX_COUNTY_PCT As DataColumn = New DataColumn("APPR_TAX_COUNTY_PCT")
        COL_APPR_TAX_COUNTY_PCT.DataType = GetType(Decimal)

        Dim COL_APPR_TAX_CITY_PCT As DataColumn = New DataColumn("APPR_TAX_CITY_PCT")
        COL_APPR_TAX_CITY_PCT.DataType = GetType(Decimal)

        Dim COL_ROW_TYPE As DataColumn = New DataColumn("ROW_TYPE")
        COL_ROW_TYPE.DataType = GetType(Int32)

        Dim COL_QUOTE_MARKUP As DataColumn = New DataColumn("QUOTE_MARKUP")
        COL_QUOTE_MARKUP.DataType = GetType(Decimal)

        Dim COL_QUOTE_RESALE_TAX As DataColumn = New DataColumn("QUOTE_RESALE_TAX")
        COL_QUOTE_RESALE_TAX.DataType = GetType(Decimal)

        Dim COL_QUOTE_VENDOR_TAX As DataColumn = New DataColumn("QUOTE_VENDOR_TAX")
        COL_QUOTE_VENDOR_TAX.DataType = GetType(Decimal)

        Dim COL_UNBILLED_MARKUP As DataColumn = New DataColumn("UNBILLED_MARKUP")
        COL_UNBILLED_MARKUP.DataType = GetType(Decimal)

        Dim COL_UNBILLED_RESALE_TAX As DataColumn = New DataColumn("UNBILLED_RESALE_TAX")
        COL_UNBILLED_RESALE_TAX.DataType = GetType(Decimal)

        Dim COL_UNBILLED_VENDOR_TAX As DataColumn = New DataColumn("UNBILLED_VENDOR_TAX")
        COL_UNBILLED_VENDOR_TAX.DataType = GetType(Decimal)

        Dim COL_IS_USER_ROW As DataColumn = New DataColumn("IS_USER_ROW")
        COL_IS_USER_ROW.DataType = GetType(Boolean)

        Dim COL_IS_USING_TEMP_APPROVED_AMT As DataColumn = New DataColumn("IS_USING_TEMP_APPROVED_AMT")
        COL_IS_USING_TEMP_APPROVED_AMT.DataType = GetType(Boolean)

        Dim COL_TEMP_CUTOFF_APPROVED_AMT As DataColumn = New DataColumn("TEMP_CUTOFF_APPROVED_AMT")
        COL_TEMP_CUTOFF_APPROVED_AMT.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_UNBILLED_NET As DataColumn = New DataColumn("TEMP_CUTOFF_UNBILLED_NET")
        COL_TEMP_CUTOFF_UNBILLED_NET.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_APPR_NET As DataColumn = New DataColumn("TEMP_CUTOFF_APPR_NET")
        COL_TEMP_CUTOFF_APPR_NET.DataType = GetType(Decimal)

        Dim COL_QUOTE_QTY_HRS As DataColumn = New DataColumn("QUOTE_QTY_HRS")
        COL_QUOTE_QTY_HRS.DataType = GetType(Decimal)
        Dim COL_ACTUAL_QTY_HRS As DataColumn = New DataColumn("ACTUAL_QTY_HRS")
        COL_ACTUAL_QTY_HRS.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_MARKUP As DataColumn = New DataColumn("TEMP_CUTOFF_MARKUP")
        COL_TEMP_CUTOFF_MARKUP.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_RESALE_TAX As DataColumn = New DataColumn("TEMP_CUTOFF_RESALE_TAX")
        COL_TEMP_CUTOFF_RESALE_TAX.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_TOTAL As DataColumn = New DataColumn("TEMP_CUTOFF_TOTAL")
        COL_TEMP_CUTOFF_TOTAL.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_UNBILLED_MU As DataColumn = New DataColumn("TEMP_CUTOFF_UNBILLED_MU")
        COL_TEMP_CUTOFF_UNBILLED_MU.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_UNBILLED_TAX As DataColumn = New DataColumn("TEMP_CUTOFF_UNBILLED_TAX")
        COL_TEMP_CUTOFF_UNBILLED_TAX.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_UNBILLED_NR As DataColumn = New DataColumn("TEMP_CUTOFF_UNBILLED_NR")
        COL_TEMP_CUTOFF_UNBILLED_NR.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_UNBILLED_TOT As DataColumn = New DataColumn("TEMP_CUTOFF_UNBILLED_TOT")
        COL_TEMP_CUTOFF_UNBILLED_TOT.DataType = GetType(Decimal)

        Dim COL_TEMP_CUTOFF_PO As DataColumn = New DataColumn("TEMP_CUTOFF_PO")
        COL_TEMP_CUTOFF_PO.DataType = GetType(Decimal)


        With Me.MainDT.Columns
            .Add(COL_INDEX)
            .Add(COL_BA_DTL_ID)
            .Add(COL_FNC_TYPE)
            .Add(COL_FNC_TYPE_DESC)
            .Add(COL_FNC_CODE)
            .Add(COL_FNC_DESCRIPTION)
            .Add(COL_DEFAULT_DESCRIPTION)
            .Add(COL_QUOTE_AMT)
            .Add(COL_ACTUALS)
            .Add(COL_BILLED_REC)
            .Add(COL_BILL_HOLD)
            .Add(COL_NON_BILL_FEE)
            .Add(COL_UNBILLED)
            .Add(COL_OPEN_PO)
            .Add(COL_QUANTITY)
            .Add(COL_RATE)
            .Add(COL_APPROVED_AMT)
            .Add(COL_APPROVAL_COMMENTS)
            .Add(COL_CLIENT_COMMENTS)
            .Add(COL_IS_USER_ADDED)
            .Add(COL_ITEM_EXISTS)
            .Add(COL_FNC_HEADING_ID)
            .Add(COL_FNC_HEADING_SEQ)
            .Add(COL_FNC_HEADING_DESC)
            .Add(COL_QUOTE_NET)
            .Add(COL_UNBILLED_NET)
            .Add(COL_APPR_NET)

            .Add(COL_APPR_MARKUP_PCT)
            .Add(COL_APPR_MARKUP_AMT)
            .Add(COL_APPR_TAX_CODE)
            .Add(COL_APPR_TAX_COMM)
            .Add(COL_APPR_TAX_COMM_ONLY)
            .Add(COL_APPR_TAX_RESALE)
            .Add(COL_APPR_RESALE_TAX)
            .Add(COL_APPR_VENDOR_TAX)
            .Add(COL_APPR_TAX_STATE_PCT)
            .Add(COL_APPR_TAX_COUNTY_PCT)
            .Add(COL_APPR_TAX_CITY_PCT)

            .Add(COL_ROW_TYPE)

            .Add(COL_QUOTE_MARKUP)
            .Add(COL_QUOTE_RESALE_TAX)
            .Add(COL_QUOTE_VENDOR_TAX)
            .Add(COL_UNBILLED_MARKUP)
            .Add(COL_UNBILLED_RESALE_TAX)
            .Add(COL_UNBILLED_VENDOR_TAX)

            .Add(COL_IS_USER_ROW)

            .Add(COL_IS_USING_TEMP_APPROVED_AMT)
            .Add(COL_TEMP_CUTOFF_APPROVED_AMT)
            .Add(COL_TEMP_CUTOFF_UNBILLED_NET)
            .Add(COL_TEMP_CUTOFF_APPR_NET)

            .Add(COL_QUOTE_QTY_HRS)
            .Add(COL_ACTUAL_QTY_HRS)

            .Add(COL_TEMP_CUTOFF_MARKUP)
            .Add(COL_TEMP_CUTOFF_RESALE_TAX)
            .Add(COL_TEMP_CUTOFF_TOTAL)
            .Add(COL_TEMP_CUTOFF_UNBILLED_MU)
            .Add(COL_TEMP_CUTOFF_UNBILLED_TAX)
            .Add(COL_TEMP_CUTOFF_UNBILLED_NR)
            .Add(COL_TEMP_CUTOFF_UNBILLED_TOT)
            .Add(COL_TEMP_CUTOFF_PO)


        End With

        Me.MainDT.PrimaryKey = Pk

    End Sub

#End Region

    Public Enum BillingApprovalFunctionType
        None = 0
        Employee = 1
        IncomeOnly = 2
        Vendor = 3
    End Enum

    'this pulls back data that is merged dynamic data (from Ben's query)
    'merged with real data in table: BA_APPR_DTL
    Private Function ApprovalDetailGetRealData(ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, ByVal BA_ID As Integer, _
                                                ByVal BA_BATCH_ID As Integer, ByVal SortValue As Integer, _
                                                ByVal TempCutOffDate As String, ByVal ApproveThroughTypes As List(Of BillingApprovalFunctionType)) As DataTable
        Try
            Dim arParams(7) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(1) = paramJOB_COMPONENT_NBR

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(2) = paramBA_ID

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(3) = paramBA_BATCH_ID

            Dim paramSORT As New SqlParameter("@SORT", SqlDbType.Int)
            paramSORT.Value = SortValue
            arParams(4) = paramSORT

            Dim FilterByTempCutOffDate As Boolean = False

            Dim pTempCutOffType As New SqlParameter("@TEMP_CUTOFF_FNC_TYPE", SqlDbType.VarChar, 20)
            'Select Case TempCutOffType
            '    Case BillingApprovalFunctionType.None
            '        pTempCutOffType.Value = System.DBNull.Value
            '    Case Else
            '        pTempCutOffType.Value = TempCutOffType.ToString().Substring(0, 1).ToUpper()
            '        FilterByTempCutOffDate = True
            'End Select
            If ApproveThroughTypes.Count = 0 Then

                pTempCutOffType.Value = System.DBNull.Value

            Else

                Dim s As String = ""
                For Each item As BillingApprovalFunctionType In ApproveThroughTypes
                    s &= item.ToString().Substring(0, 1).ToUpper()
                Next

                pTempCutOffType.Value = s
                FilterByTempCutOffDate = True

            End If
            arParams(5) = pTempCutOffType

            Dim pTempCutOffDate As New SqlParameter("@TEMP_CUTOFF", SqlDbType.SmallDateTime)
            If FilterByTempCutOffDate = True AndAlso IsDate(TempCutOffDate) Then
                pTempCutOffDate.Value = CType(TempCutOffDate, Date)
            Else
                pTempCutOffDate.Value = System.DBNull.Value
            End If

            arParams(6) = pTempCutOffDate

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_GET_DETAILS", "DtRealData", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region " Billing Approval (Item Level stuff) "

    Public Function SetApprStatus(ByVal ApprovalId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal ApprStatus As Integer) As String
        Try
            Dim StrApprStatus As String
            Select Case ApprStatus
                Case -1
                    StrApprStatus = "NULL"
                Case Else
                    StrApprStatus = ApprStatus.ToString()
            End Select
            Dim SbSQL As New System.Text.StringBuilder
            With SbSQL
                .Append("UPDATE BILL_APPR_HDR WITH(ROWLOCK) SET APPR_STATUS = ")
                .Append(StrApprStatus)
                .Append(" WHERE BA_ID = ")
                .Append(ApprovalId.ToString())
                .Append(" AND JOB_NUMBER = ")
                .Append(JobNumber.ToString())
                .Append(" AND JOB_COMPONENT_NBR = ")
                .Append(JobComponentNbr.ToString())
                .Append(";")
            End With
            oSQL.ExecuteNonQuery(Me.mConnString, CommandType.Text, SbSQL.ToString())
        Catch ex As Exception
        End Try
    End Function

    Public Function ApprovalItemsUpdateDetailApprovalTaxesAndMarkup(ByVal BA_DTL_ID As Integer, ByVal APPR_RESALE_TAX As Decimal, ByVal APPR_VENDOR_TAX As Decimal, ByVal APPR_MARKUP_AMT As Decimal) As String
        Try
            Dim arParams(4) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim paramAPPR_RESALE_TAX As New SqlParameter("@APPR_RESALE_TAX", SqlDbType.Decimal)
            paramAPPR_RESALE_TAX.Value = APPR_RESALE_TAX
            arParams(1) = paramAPPR_RESALE_TAX

            Dim paramAPPR_VENDOR_TAX As New SqlParameter("@APPR_VENDOR_TAX", SqlDbType.Decimal)
            paramAPPR_VENDOR_TAX.Value = APPR_VENDOR_TAX
            arParams(2) = paramAPPR_VENDOR_TAX

            Dim paramAPPR_MARKUP_AMT As New SqlParameter("@APPR_MARKUP_AMT", SqlDbType.Decimal)
            paramAPPR_MARKUP_AMT.Value = APPR_MARKUP_AMT
            arParams(3) = paramAPPR_MARKUP_AMT

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_UPDATE_TAX_AND_MARKUP", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function ApprovalItemsUpdateDetailApprovalNetTotal(ByVal BA_DTL_ID As Integer, ByVal APPR_NET As Decimal) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim paramAPPR_NET As New SqlParameter("@APPR_NET", SqlDbType.Decimal)
            paramAPPR_NET.Value = APPR_NET
            arParams(1) = paramAPPR_NET

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_UPDATE_APPR_NET", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function ApprovalItemsUpdateDetailTotal(ByVal BA_DTL_ID As Integer, ByVal APPROVED_AMT As Decimal) As String
        Try
            Dim arParams(2) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            paramAPPROVED_AMT.Value = APPROVED_AMT
            arParams(1) = paramAPPROVED_AMT

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_DTL_UPDATE_APPR_AMT", arParams)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function ApprovalItemsInsert(ByVal BA_DTL_ID As Integer, ByVal REC_TYPE As String, ByVal REC_ID As Integer, _
                                        ByVal APPROVED_AMT As Decimal, ByVal APPROVAL_COMMENTS As String, ByVal INSTR As Integer, _
                                        ByVal CLIENT_COMMENT As String, ByVal BA_ID As Integer, _
                                        ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, ByVal FNC_CODE As String, _
                                        ByVal IsPO As Boolean, ByVal PONumber As Integer, ByVal POLineNumber As Integer, ByVal REC_DTL_ID As Integer) As String
        Try

            Dim arParams(15) As SqlParameter

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(0) = paramBA_DTL_ID

            Dim paramREC_TYPE As New SqlParameter("@REC_TYPE", SqlDbType.VarChar, 1)
            paramREC_TYPE.Value = REC_TYPE
            arParams(1) = paramREC_TYPE

            Dim paramREC_ID As New SqlParameter("@REC_ID", SqlDbType.Int)
            paramREC_ID.Value = REC_ID
            arParams(2) = paramREC_ID

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            paramAPPROVED_AMT.Value = APPROVED_AMT
            arParams(3) = paramAPPROVED_AMT

            Dim paramAPPROVAL_COMMENTS As New SqlParameter("@APPROVAL_COMMENTS", SqlDbType.Text)
            If APPROVAL_COMMENTS.Trim() = "" Then
                paramAPPROVAL_COMMENTS.Value = DBNull.Value
            Else
                paramAPPROVAL_COMMENTS.Value = APPROVAL_COMMENTS
            End If
            arParams(4) = paramAPPROVAL_COMMENTS

            Dim paramINSTR As New SqlParameter("@INSTR", SqlDbType.TinyInt)
            paramINSTR.Value = INSTR
            arParams(5) = paramINSTR

            Dim paramCLIENT_COMMENT As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If CLIENT_COMMENT.Trim() = "" Then
                paramCLIENT_COMMENT.Value = DBNull.Value
            Else
                paramCLIENT_COMMENT.Value = CLIENT_COMMENT
            End If
            arParams(6) = paramCLIENT_COMMENT

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(7) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(8) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(9) = paramJOB_COMPONENT_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FNC_CODE
            arParams(10) = paramFNC_CODE

            Dim paramIS_PO As New SqlParameter("@IS_PO", SqlDbType.SmallInt)
            If IsPO = True Then
                paramIS_PO.Value = 1
            Else
                paramIS_PO.Value = 0
            End If
            arParams(11) = paramIS_PO

            Dim paramPO_NUMBER As New SqlParameter("@PO_NUMBER", SqlDbType.Int)
            paramPO_NUMBER.Value = PONumber
            arParams(12) = paramPO_NUMBER

            Dim paramPO_LINE_NUMBER As New SqlParameter("@PO_LINE_NUMBER", SqlDbType.Int)
            paramPO_LINE_NUMBER.Value = POLineNumber
            arParams(13) = paramPO_LINE_NUMBER

            Dim paramREC_DTL_ID As New SqlParameter("@REC_DTL_ID", SqlDbType.Int)
            'If REC_DTL_ID = 0 Then
            '    paramREC_DTL_ID.Value = System.DBNull.Value
            'Else
            paramREC_DTL_ID.Value = REC_DTL_ID
            'End If
            arParams(14) = paramREC_DTL_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_ITEM_INSERT", arParams)
            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try
    End Function

    Public Function ApprovalItemsUpdate(ByVal BA_ITEM_ID As Integer, ByVal APPROVED_AMT As Decimal, ByVal APPROVAL_COMMENTS As String, ByVal INSTR As Integer, _
                                        ByVal CLIENT_COMMENT As String, ByVal BA_ID As Integer, ByVal REC_TYPE As String, ByVal REC_ID As Integer, _
                                        ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, ByVal FNC_CODE As String, _
                                        ByVal IsPO As Boolean, ByVal PONumber As Integer, ByVal POLineNumber As Integer, ByVal REC_DTL_ID As Integer) As String
        Try

            Dim arParams(15) As SqlParameter

            Dim paramBA_ITEM_ID As New SqlParameter("@BA_ITEM_ID", SqlDbType.Int)
            paramBA_ITEM_ID.Value = BA_ITEM_ID
            arParams(0) = paramBA_ITEM_ID

            Dim paramAPPROVED_AMT As New SqlParameter("@APPROVED_AMT", SqlDbType.Decimal)
            paramAPPROVED_AMT.Value = APPROVED_AMT
            arParams(1) = paramAPPROVED_AMT

            Dim paramAPPROVAL_COMMENTS As New SqlParameter("@APPROVAL_COMMENTS", SqlDbType.Text)
            If APPROVAL_COMMENTS.Trim() = "" Then
                paramAPPROVAL_COMMENTS.Value = DBNull.Value
            Else
                paramAPPROVAL_COMMENTS.Value = APPROVAL_COMMENTS
            End If
            arParams(2) = paramAPPROVAL_COMMENTS

            Dim paramINSTR As New SqlParameter("@INSTR", SqlDbType.TinyInt)
            paramINSTR.Value = INSTR
            arParams(3) = paramINSTR

            Dim paramCLIENT_COMMENT As New SqlParameter("@CLIENT_COMMENTS", SqlDbType.Text)
            If CLIENT_COMMENT.Trim() = "" Then
                paramCLIENT_COMMENT.Value = DBNull.Value
            Else
                paramCLIENT_COMMENT.Value = CLIENT_COMMENT
            End If
            arParams(4) = paramCLIENT_COMMENT

            Dim paramREC_TYPE As New SqlParameter("@REC_TYPE", SqlDbType.VarChar, 1)
            paramREC_TYPE.Value = REC_TYPE
            arParams(5) = paramREC_TYPE

            Dim paramREC_ID As New SqlParameter("@REC_ID", SqlDbType.Int)
            paramREC_ID.Value = REC_ID
            arParams(6) = paramREC_ID

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(7) = paramBA_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(8) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(9) = paramJOB_COMPONENT_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FNC_CODE
            arParams(10) = paramFNC_CODE

            Dim paramIS_PO As New SqlParameter("@IS_PO", SqlDbType.SmallInt)
            If IsPO = True Then
                paramIS_PO.Value = 1
            Else
                paramIS_PO.Value = 0
            End If
            arParams(11) = paramIS_PO

            Dim paramPO_NUMBER As New SqlParameter("@PO_NUMBER", SqlDbType.Int)
            paramPO_NUMBER.Value = PONumber
            arParams(12) = paramPO_NUMBER

            Dim paramPO_LINE_NUMBER As New SqlParameter("@PO_LINE_NUMBER", SqlDbType.Int)
            paramPO_LINE_NUMBER.Value = POLineNumber
            arParams(13) = paramPO_LINE_NUMBER

            Dim paramREC_DTL_ID As New SqlParameter("@REC_DTL_ID", SqlDbType.Int)
            'If REC_DTL_ID = 0 Then
            '    paramREC_DTL_ID.Value = System.DBNull.Value
            'Else
            paramREC_DTL_ID.Value = REC_DTL_ID
            'End If
            arParams(14) = paramREC_DTL_ID

            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_BA_BILL_APPR_ITEM_UPDATE", arParams)
            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try
    End Function

    Public Function ApprovalItemsGetTable(ByVal BA_BATCH_ID As Integer, ByVal BA_ID As Integer, ByVal BA_DTL_ID As Integer, ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, ByVal FNC_CODE As String) As DataTable
        Try
            Dim arParams(6) As SqlParameter

            Dim paramBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            paramBA_BATCH_ID.Value = BA_BATCH_ID
            arParams(0) = paramBA_BATCH_ID

            Dim paramBA_ID As New SqlParameter("@BA_ID", SqlDbType.Int)
            paramBA_ID.Value = BA_ID
            arParams(1) = paramBA_ID

            Dim paramBA_DTL_ID As New SqlParameter("@BA_DTL_ID", SqlDbType.Int)
            paramBA_DTL_ID.Value = BA_DTL_ID
            arParams(2) = paramBA_DTL_ID

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = JOB_NUMBER
            arParams(3) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = JOB_COMPONENT_NBR
            arParams(4) = paramJOB_COMPONENT_NBR

            Dim paramFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
            paramFNC_CODE.Value = FNC_CODE
            arParams(5) = paramFNC_CODE

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_ITEM_GET_DETAILS", "dtItems", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region " Billing Approval Print "

    Public Function GetBAData(ByVal baid As Integer, ByVal report As Integer, ByVal printZero As String) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim pBAID As New SqlParameter("@BA_ID", SqlDbType.Int)
            pBAID.Value = baid
            arParams(0) = pBAID

            Dim pReport As New SqlParameter("@REPORT", SqlDbType.Int)
            pReport.Value = report
            arParams(1) = pReport

            Dim pIncludeZero As New SqlParameter("@INCL_ZERO", SqlDbType.Bit)
            If printZero = "True" Then
                pIncludeZero.Value = 1
            Else
                pIncludeZero.Value = 0
            End If
            arParams(2) = pIncludeZero

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_PRINT_DATA", "dtPrint", arParams)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetBADataDefault(ByVal baid As Integer, ByVal report As Integer, ByVal printZero As String) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim pBAID As New SqlParameter("@BA_ID", SqlDbType.Int)
            pBAID.Value = baid
            arParams(0) = pBAID

            Dim pReport As New SqlParameter("@REPORT", SqlDbType.Int)
            pReport.Value = report
            arParams(1) = pReport

            Dim pIncludeZero As New SqlParameter("@IncludeZero", SqlDbType.Bit)
            If printZero = "True" Then
                pIncludeZero.Value = 1
            Else
                pIncludeZero.Value = 0
            End If
            arParams(2) = pIncludeZero

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_PRINT_DATA_DEFAULT", "dtPrint", arParams)
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Billing Approval Alert "
    Public Function GetAlertList(ByVal BA_BATCH_ID As Integer) As DataTable

        Dim Offset As Decimal = 0.0

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, HttpContext.Current.Session("EmpCode"))

        End Using

        Dim arParams(2) As SqlParameter

        Dim pBA_BATCH_ID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
        pBA_BATCH_ID.Value = BA_BATCH_ID
        arParams(0) = pBA_BATCH_ID

        Dim pOFFSET As New SqlParameter("@OFFSET", SqlDbType.Decimal)
        pOFFSET.Value = Offset
        arParams(1) = pOFFSET

        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_ALERTS_VIEW_LIST", "DtList", arParams)

    End Function

#End Region

    Public Shared Sub SetStatusColumn(ByRef BackgroundDiv As HtmlControls.HtmlControl, ByRef StatusImage As WebControls.Image,
                                      ByVal Approved As Boolean, ByVal Finished As Boolean)

        If Approved = False AndAlso Finished = False Then

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(BackgroundDiv, "standard-green")

            With StatusImage

                .AlternateText = "In Progress"
                .ToolTip = "Pending/In Progress"

            End With

        Else

            Dim ColorSet As Boolean = False

            If Finished = True Then

                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(BackgroundDiv, "standard-red")

                With StatusImage

                    .AlternateText = "Finished"
                    .ToolTip = "Finished"

                End With

                ColorSet = True

            End If

            If ColorSet = False AndAlso Approved = True Then

                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(BackgroundDiv, "standard-yellow")

                With StatusImage

                    .AlternateText = "Approved"
                    .ToolTip = "Approved"

                End With

            End If


        End If

    End Sub
    Public Shared Sub SetAlertColumn(ByRef BackgroundDiv As HtmlControls.HtmlControl, ByRef AlertImageButton As WebControls.ImageButton,
                                     ByVal AlertStatus As String)

        If AlertStatus = "None" Then

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(BackgroundDiv, "standard-red")

        Else

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(BackgroundDiv, "standard-green")

        End If

        Dim StatusText As String = "Alert Status: " & AlertStatus
        With AlertImageButton

            .AlternateText = StatusText
            .ToolTip = StatusText

        End With

    End Sub

    Public Sub New(Optional ByVal ConnectionString As String = "", Optional ByVal UserCode As String = "")
        Try
            If ConnectionString <> "" Then
                mConnString = ConnectionString
            Else
                mConnString = HttpContext.Current.Session("ConnString")
            End If
        Catch ex As Exception
            mConnString = ""
        End Try
        Try
            If UserCode <> "" Then
                mUserCode = UserCode
            Else
                mUserCode = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserCode = ""
        End Try
    End Sub

End Class
