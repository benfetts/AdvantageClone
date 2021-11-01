Imports System.Data
Imports System.Data.SqlClient

Public Enum JobListType
    General = 1
    Traffic = 2
    TimeSheet = 3
    JobJacket = 4
    ExpenseEdit = 5
    Schedule = 6
    ScheduleRequired = 7
    TrafficOpen = 8
    ScheduleNew = 9
    JobEstimate = 10
    JobEstimateSave = 11
    PurchaseOrder = 12
    CreativeBrief = 13
    JobVersion = 14
    JobSpecs = 15
    Calendar = 16
End Enum

<Serializable()> Public Class cDropDowns
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Enum LookUpTable

        StandardFunction
        TrafficFunction
        Office
        Client
        Division
        Product
        Job
        JobComponent
        TrafficStatus

    End Enum

    Public Function GetAdNumbers(ByVal ClCode As String, ByVal IncludeInactive As Boolean) As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(2) As SqlParameter

        Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        pCL_CODE.Value = ClCode
        arParams(0) = pCL_CODE

        Dim pINCL_INACTIVE As New SqlParameter("@INCL_INACTIVE", SqlDbType.Bit)
        If IncludeInactive = True Then
            pINCL_INACTIVE.Value = 1
        Else
            pINCL_INACTIVE.Value = 0
        End If
        arParams(1) = pINCL_INACTIVE

        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_AD_NUMBER_GET", "dtAdNumbers", arParams)

    End Function

    Public Function GetResourcesList() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetResources")
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetResourcesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Function GetResourceTypesList() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetResourceTypes")
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetResourceTypesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Function GetDistinctAdNumbers(ByVal EventIdList As String) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(1) As SqlParameter

            Dim pEVENT_ID_LIST As New SqlParameter("@EVENT_ID_LIST", SqlDbType.VarChar, 8000)
            pEVENT_ID_LIST.Value = EventIdList
            arParams(0) = pEVENT_ID_LIST

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_DISTINCT_AD_NUMS", arParams)
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetResourceTypesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Overloads Function GetDistinctAdNumbers(ByVal StartDate As Date, ByVal EndDate As Date) As SqlDataReader
        Try
            Dim dr As SqlDataReader
            Dim arParams(2) As SqlParameter
            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            pSTART_DATE.Value = StartDate
            arParams(0) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            pEND_DATE.Value = EndDate
            arParams(1) = pEND_DATE

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_EVENT_DISTINCT_AD_NUMS_BY_DATE", arParams)
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetResourceTypesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Function GetApprovalAvailableFunctions(ByVal JOB_NUMBER As Integer, ByVal JOB_COMPONENT_NBR As Integer, ByVal BA_ID As Integer, ByVal BA_BATCH_ID As Integer) As DataTable
        Try
            Dim arParams(4) As SqlParameter

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

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_BA_APPROVAL_JC_GET_AVAIL_FNC", "DtApprovalFnc", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetApprovalAvailableFunctions!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetClientsByBatchID(ByVal BatchID As Integer, Optional ByVal ExcludeClientsWithExistingApprovals As Boolean = False) As DataTable
        Try
            Dim arParams(2) As SqlParameter

            Dim parameterBatchID As New SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            parameterBatchID.Value = BatchID
            arParams(0) = parameterBatchID

            Dim parameterExcludeExisting As New SqlParameter("@EXCLUDE_EXISTING", SqlDbType.Bit)
            parameterExcludeExisting.Value = ExcludeClientsWithExistingApprovals
            arParams(1) = parameterExcludeExisting

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Batch_GetClientsByBatchID", "DtBatchClients", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetClientsByBatchID!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetTrafficPresets() As DataTable
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetPresetsList", "dtTrafficPresets")
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficPresets!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function
    Public Function GetEstimatingPresets() As DataTable
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimating_GetPresetsList", "dtEstimatePresets")
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetEstimatingPresets!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetFilterProducts(ByVal UserID As String, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal Direction As String, ByVal OnlyActive As Boolean, Optional ByVal CP As Boolean = False, Optional ByVal CDPID As Integer = 0) As SqlDataReader

        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        If CP = True Then
            Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterCDPID.Value = CDPID
            arParams(0) = parameterCDPID
        Else
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID
        End If

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(2) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(3) = parameterDivisionCode

        Dim parameterDirection As New SqlParameter("@Direction", SqlDbType.VarChar, 10)
        parameterDirection.Value = Direction
        arParams(4) = parameterDirection


        Try
            If CP = True Then
                If OnlyActive = True Then
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_Filter_Products_Active", arParams)
                Else
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_Filter_Products", arParams)
                End If
            Else
                If OnlyActive = True Then
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Filter_Products_Active", arParams)
                Else
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Filter_Products", arParams)
                End If
            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_Filter_Products", Err.Description)
        End Try

        Return dr

    End Function

    Public Function GetJobTemplatesList() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplates")
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplatesList!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Function GetJobTemplatesListAll() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplatesAll")
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetJobTemplatesListAll!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Function GetTrafficPhasesAll() As DataTable
        Dim DT As DataTable
        Try
            DT = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_traffic_GetPhase_All", "dtTrafficPhases")
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTrafficPhasesAll", Err.Description)
        End Try
        Return DT
    End Function

    Public Function GetTrafficScheduleCodes() As DataTable
        Dim DT As DataTable
        Try
            DT = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTaskCodes", "dtTrafficScheduleTaskCodes")
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTrafficScheduleCodes", Err.Description)
        End Try
        Return DT
    End Function


    Public Function GetTrafficPhases(ByVal intPhaseID As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        '*** Create Parameters
        Dim paramPhaseID As New SqlParameter("@PhaseID", SqlDbType.Int)
        paramPhaseID.Value = intPhaseID
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_traffic_GetPhase", paramPhaseID)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTrafficPhases", Err.Description)
        End Try
        Return dr
    End Function
    Public Function GetTrafficPhaseDesc(ByVal intPhaseID As Integer)
        Dim desc As String
        '*** Create Parameters
        Dim paramPhaseID As New SqlParameter("@PhaseID", SqlDbType.Int)
        paramPhaseID.Value = intPhaseID
        Try
            desc = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetTrafficPhaseDesc", paramPhaseID)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cTraffic Routine:GetTrafficPhaseDesc", Err.Description)
        End Try
        Return desc
    End Function
    'show all versions
    Public Overloads Function GetFilterClientList(ByVal UserID As String, ByVal OfficeCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Filter_Clients_All", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetFilterClientList(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClients_All", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dr

    End Function
    'show only active versions
    Public Overloads Function GetClientList(ByVal UserID As String, ByVal OfficeCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Filter_Clients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetClientList(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter
        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = ""
        arParams(1) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetClientListTS(ByVal UserID As String, Optional ByVal app As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter
        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = app
        arParams(1) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dr

    End Function

    Public Overloads Function GetClientName(ByVal UserID As String) As DataTable
        Dim dt As DataTable

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClients_Name", "dt", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetClientNames(ByVal UserID As String) As DataTable
        Dim dt As DataTable

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClients_Names", "dt", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientList", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetClientListAE(ByVal UserID As String, ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterObjectId As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterObjectId.Value = CType(DesktopObject, Integer)
        arParams(1) = parameterObjectId

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetClientsAE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetClientListAE", Err.Description)
        End Try

        Return dr

    End Function


    Public Function GetFilterDivisionList(ByVal UserID As String, ByVal ClientCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDivisions_All", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionList", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetDivisionList(ByVal UserID As String, ByVal ClientCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = ""
        arParams(2) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDivisions", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetDivisionListCP(ByVal CPID As Integer, ByVal ClientCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterCPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        'Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        'parameterFromApp.Value = ""
        'arParams(2) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetDivisions", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetDivisionListTS(ByVal UserID As String, ByVal ClientCode As String, Optional ByVal app As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = app
        arParams(2) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDivisions", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetDivisionsAll(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllDivisions_withclient", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionsAll", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetDivisionsAllCP(ByVal CPID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetAllDivisions_withclient", parameterCPID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionsAll", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetDivisionListAE(ByVal UserID As String, ByVal ClientCode As String,
                                      ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterObjectId As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterObjectId.Value = CType(DesktopObject, Integer)
        arParams(2) = parameterObjectId

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDivisionsAE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDivisionListAE", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetProductList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = ""
        arParams(3) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetProducts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetProductListCP(ByVal CPID As Integer, ByVal ClientCode As String, ByVal DivisionCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        '*** Create Parameters
        Dim parameterCPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        'Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        'parameterFromApp.Value = ""
        'arParams(3) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetProducts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetProductListTS(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, Optional ByVal app As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = app
        arParams(3) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetProducts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetProductsAll(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllProducts_withCnD", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductsAll", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetProductsAllCP(ByVal CPID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetAllProducts_withCnD", parameterCPID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductsAll", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetProductListAE(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String,
                                     ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterObjectId As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterObjectId.Value = CType(DesktopObject, Integer)
        arParams(3) = parameterObjectId


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetProductsAE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductListAE", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetAllCampaignsAE(ByVal UserID As String,
                                      ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterObjectId As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterObjectId.Value = CType(DesktopObject, Integer)
        arParams(1) = parameterObjectId

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllCampaignsAE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetAllCampaignsAE", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAllCampaignsWithCDP(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllCampaignsWithCDP", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetProductsAll", Err.Description)
        End Try

        Return dr
    End Function
    'Added by ATC - 11/9/2006 for getting media types for media filter.
    Public Function GetMediaTypeList(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetMediaTypes", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetMediaTypes", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetVendors(ByVal UserID As String, Optional ByVal Magazine As Boolean = False,
                                        Optional ByVal NewsPaper As Boolean = False,
                                        Optional ByVal Internet As Boolean = False,
                                        Optional ByVal OutOfHome As Boolean = False,
                                        Optional ByVal Television As Boolean = False,
                                        Optional ByVal Radio As Boolean = False) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterMagazine As New SqlParameter("@MagazineInc", SqlDbType.Char, 1)
        If Magazine = True Then
            parameterMagazine.Value = "Y"
        Else
            parameterMagazine.Value = "N"
        End If
        arParams(1) = parameterMagazine

        Dim parameterNewspaper As New SqlParameter("@NewspaperInc", SqlDbType.Char, 1)
        If NewsPaper = True Then
            parameterNewspaper.Value = "Y"
        Else
            parameterNewspaper.Value = "N"
        End If
        arParams(2) = parameterNewspaper

        Dim parameterInternet As New SqlParameter("@InternetInc", SqlDbType.Char, 1)
        If Internet = True Then
            parameterInternet.Value = "Y"
        Else
            parameterInternet.Value = "N"
        End If
        arParams(3) = parameterInternet

        Dim parameterOutOfHome As New SqlParameter("@OutOfHomeInc", SqlDbType.Char, 1)
        If OutOfHome = True Then
            parameterOutOfHome.Value = "Y"
        Else
            parameterOutOfHome.Value = "N"
        End If
        arParams(4) = parameterOutOfHome

        Dim parameterTelevision As New SqlParameter("@TelevisionInc", SqlDbType.Char, 1)
        If Television = True Then
            parameterTelevision.Value = "Y"
        Else
            parameterTelevision.Value = "N"
        End If
        arParams(5) = parameterTelevision

        Dim parameterRadio As New SqlParameter("@RadioInc", SqlDbType.Char, 1)
        If Radio = True Then
            parameterRadio.Value = "Y"
        Else
            parameterRadio.Value = "N"
        End If
        arParams(6) = parameterRadio

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetVendors", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetVendors", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetBuyers(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetBuyers", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetMediaTypes", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetTimeCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontasks_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetCategories", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetDOs()
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_nontasks_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetDOs", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetInvoiceCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetInvoiceCategories")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetInvoiceCategories", Err.Description)
        End Try

        Return dr

    End Function


    'Modified by Sam Tran on 2006/05/04
    '	Duplicated the next 2 fn's (for a total of 4 "GetJobList" fn's)
    '   Added param for filtering closed jobs
    '   other path would have been to add an optional param to original 2 fn's
    '   afraid of disrupting app elsewhere
    Public Overloads Function GetJobList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String,
                                         ByVal ProductCode As String, ByVal ListType As JobListType, Optional ByVal OfficeCode As String = "",
                                         Optional ByVal SalesClassCode As String = "", Optional ByVal app As String = "",
                                         Optional ByVal IncludeClosedJobs As Boolean = False, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable

        Dim arParams(9) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        If OfficeCode.Trim.Length = 0 Then OfficeCode = "%"
        parameterOfficeCode.Value = OfficeCode
        If ListType = JobListType.JobJacket Then
            arParams(4) = parameterOfficeCode
        End If

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        If SalesClassCode.Trim.Length = 0 Then SalesClassCode = "%"
        parameterSalesClass.Value = SalesClassCode
        If ListType = JobListType.JobJacket Then
            arParams(5) = parameterSalesClass
        End If

        If app = "taskfilter" Or app = "newalert" Or app = "alertinbox" Or app = "ts" Or app = "tscv" Or app = "docmgr" Or ListType = JobListType.TimeSheet Then
            Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar)
            parameterFrom.Value = app
            arParams(6) = parameterFrom
        End If

        If ListType = JobListType.JobJacket Then
            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(6) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(7) = parameterCPID

        End If


        Try
            Select Case ListType
                Case JobListType.General
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob", "DtData", arParams)
                Case JobListType.Traffic
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForTraffic", "DtData", arParams)
                Case JobListType.TrafficOpen
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForTraffic", "DtData", arParams)
                Case JobListType.TimeSheet
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_timesheet", "DtData", arParams)
                Case JobListType.JobJacket
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobJacket", "DtData", arParams)
                Case JobListType.ExpenseEdit
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ExpenseEdit", "DtData", arParams)
                Case JobListType.JobEstimate

                    If IncludeClosedJobs Then

                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimate_withClosed", "DtData", arParams)

                    Else

                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimate", "DtData", arParams)

                    End If

                Case JobListType.JobEstimateSave

                    If IncludeClosedJobs Then

                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobs_ForEstimateSave_withClosed", "DtData", arParams)

                    Else
                        arParams(5) = parameterSalesClass
                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobs_ForEstimateSave", "DtData", arParams)

                    End If

                Case JobListType.PurchaseOrder
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ExpenseEdit", "DtData", arParams)
                Case JobListType.CreativeBrief
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_CreativeBrief", "DtData", arParams)
                Case JobListType.JobVersion
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobVersion", "DtData", arParams)
                Case JobListType.JobSpecs
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobSpecs", "DtData", arParams)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

    End Function
    Public Overloads Function GetJobList(ByVal UserID As String, ByVal ListType As JobListType, Optional ByVal app As String = "") As DataTable
        Dim arParams(2) As SqlParameter
        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar)
        parameterFrom.Value = app
        arParams(1) = parameterFrom

        Try
            Select Case ListType
                Case JobListType.General
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs", "DtData", parameterUserID)
                Case JobListType.Traffic
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Traffic", "DtData", parameterUserID)
                Case JobListType.TimeSheet
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsTimesheet", "DtData", arParams)
                Case JobListType.JobJacket
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket", "DtData", parameterUserID)
                Case JobListType.ExpenseEdit
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsExpenseEdit", "DtData", parameterUserID)
                Case JobListType.ScheduleRequired
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoSheduleRequired", "DtData", parameterUserID) ' no scheds
                Case JobListType.PurchaseOrder
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsExpenseEdit", "DtData", parameterUserID)
                Case JobListType.CreativeBrief
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_CreativeBrief", "DtData", parameterUserID)
                Case JobListType.JobVersion
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobVersion", "DtData", parameterUserID)
                Case JobListType.JobSpecs
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobSpecs", "DtData", parameterUserID)
                Case JobListType.Calendar
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsCalendar", "DtData", parameterUserID)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

    End Function

    Public Overloads Function GetJobList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                         ByVal ListType As JobListType, ByVal ShowAll As Boolean, Optional ByVal OfficeCode As String = "",
                                         Optional ByVal SalesClass As String = "", Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable
        Dim arParams(8) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        If OfficeCode.Trim.Length = 0 Then OfficeCode = "%"
        parameterOfficeCode.Value = OfficeCode
        If ListType = JobListType.JobJacket Then
            arParams(4) = parameterOfficeCode
        End If

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        If SalesClass.Trim.Length = 0 Then SalesClass = "%"
        parameterSalesClass.Value = SalesClass
        If ListType = JobListType.JobJacket Then
            arParams(5) = parameterSalesClass
        End If

        If ListType = JobListType.JobJacket Then
            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(6) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(7) = parameterCPID

        End If

        Try
            Select Case ListType
                Case JobListType.General
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_withClosed", "DtData", arParams)
                Case JobListType.Traffic
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForTraffic_withClosed", "DtData", arParams)
                Case JobListType.TimeSheet
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_timesheet_withClosed", "DtData", arParams)
                Case JobListType.JobJacket
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobJacket_withClosed", "DtData", arParams)
                Case JobListType.ScheduleNew
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoShedules", "DtData", arParams) ' no scheds
                Case JobListType.PurchaseOrder
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_PO_withClosed", "DtData", arParams)
                Case JobListType.CreativeBrief
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_CreativeBrief_withClosed", "DtData", arParams)
                Case JobListType.JobVersion
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobVersion_withClosed", "DtData", arParams)
                Case JobListType.JobSpecs
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_JobSpecs_withClosed", "DtData", arParams)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

    End Function
    Public Overloads Function GetJobList(ByVal UserID As String, ByVal ListType As JobListType, ByVal ShowAll As Boolean) As DataTable

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            Select Case ListType
                Case JobListType.General
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_withClosed", "DtData", parameterUserID)
                Case JobListType.Traffic
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Traffic_withClosed", "DtData", parameterUserID) 'has schedules
                Case JobListType.TrafficOpen
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Traffic", "DtData", parameterUserID) 'has schedules
                Case JobListType.TimeSheet
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsTimesheet_withClosed", "DtData", parameterUserID)
                Case JobListType.JobJacket
                    If ShowAll = True Then
                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket_withClosed", "DtData", parameterUserID)
                    Else
                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket", "DtData", parameterUserID)
                    End If
                Case JobListType.Schedule
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoShedules", "DtData", parameterUserID) ' no scheds
                Case JobListType.ScheduleRequired
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoSheduleRequired", "DtData", parameterUserID) ' no scheds
                Case JobListType.JobEstimate

                    If ShowAll Then

                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Estimate_withClosed", "DtData", parameterUserID)

                    Else

                        Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Estimate", "DtData", parameterUserID)

                    End If

                Case JobListType.PurchaseOrder
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsPO_withClosed", "DtData", parameterUserID)
                Case JobListType.CreativeBrief
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_CreativeBrief_withClosed", "DtData", parameterUserID)
                Case JobListType.JobVersion
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobVersion_withClosed", "DtData", parameterUserID)
                Case JobListType.JobSpecs
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobSpecs_withClosed", "DtData", parameterUserID)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

    End Function

    Public Overloads Function GetJobList(ByVal UserID As String, ByVal ListType As JobListType, ByVal ShowAll As Boolean, Optional ByVal app As String = "") As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            Select Case ListType
                Case JobListType.General
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_withClosed", parameterUserID)
                Case JobListType.Traffic
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Traffic_withClosed", parameterUserID) 'has schedules
                Case JobListType.TrafficOpen
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Traffic", parameterUserID) 'has schedules
                Case JobListType.TimeSheet
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsTimesheet_withClosed", parameterUserID)
                Case JobListType.JobJacket
                    If ShowAll = True Then
                        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket_withClosed", parameterUserID)
                    Else
                        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket", parameterUserID)
                    End If
                Case JobListType.Schedule
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoShedules", parameterUserID) ' no scheds
                Case JobListType.ScheduleRequired
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_NoSheduleRequired", parameterUserID) ' no scheds
                Case JobListType.JobEstimate

                    If ShowAll Then

                        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Estimate_withClosed", parameterUserID)

                    Else

                        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Estimate", parameterUserID)

                    End If

                Case JobListType.PurchaseOrder
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsPO_withClosed", parameterUserID)
                Case JobListType.CreativeBrief
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_CreativeBrief_withClosed", parameterUserID)
                Case JobListType.JobVersion
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobVersion_withClosed", parameterUserID)
                Case JobListType.JobSpecs
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_JobSpecs_withClosed", parameterUserID)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobList(ByVal UserID As String, ByVal EstNum As Integer, ByVal IncludeClosedJobs As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Try

            If IncludeClosedJobs Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimateNumber_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimateNumber", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobList(ByVal UserID As String, ByVal EstNum As Integer, ByVal EstComp As Integer, ByVal IncludeClosedJobs As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        arParams(2) = parameterEstComp

        Try

            If IncludeClosedJobs Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimateCompNumber_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimateCompNumber", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobListEst(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal ListType As JobListType, ByVal SalesClass As String, ByVal str As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        If SalesClass.Trim.Length = 0 Then SalesClass = "%"
        parameterSalesClass.Value = SalesClass
        arParams(4) = parameterSalesClass

        Try
            Select Case ListType
                Case JobListType.JobEstimate
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForEstimate", arParams)
                Case JobListType.JobEstimateSave
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobs_ForEstimateSave", arParams)
            End Select
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetJobListAE(ByVal UserID As String, ByVal IncludeClosedJobs As Boolean, ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader

        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterIncludeClosedJobs As New SqlParameter("@INCLUDE_CLOSED_JOBS", SqlDbType.Bit)
        parameterIncludeClosedJobs.Value = IncludeClosedJobs
        arParams(1) = parameterIncludeClosedJobs

        Dim parameterDesktopObject As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterDesktopObject.Value = CType(DesktopObject, Integer)
        arParams(2) = parameterDesktopObject

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsAE", arParams)

        Return dr

    End Function
    Public Function GetJobComponentListAE(ByVal UserID As String, ByVal IncludeClosedJobComponents As Boolean, ByVal DesktopObject As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As SqlDataReader

        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterIncludeClosedJobs As New SqlParameter("@INCLUDE_CLOSED_JOBS", SqlDbType.Bit)
        parameterIncludeClosedJobs.Value = IncludeClosedJobComponents
        arParams(1) = parameterIncludeClosedJobs

        Dim parameterDesktopObject As New SqlParameter("@OBJECT_ID", SqlDbType.Int)
        parameterDesktopObject.Value = CType(DesktopObject, Integer)
        arParams(2) = parameterDesktopObject

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsAE", arParams)

        Return dr

    End Function

    Public Overloads Function GetJobListJobType(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobType As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        If JobType.Trim.Length = 0 Then JobType = "%"
        parameterJobType.Value = JobType
        arParams(4) = parameterJobType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForTraffic_withJobType", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobListJobType", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobListJobType(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobType As String, ByVal showall As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        If JobType.Trim.Length = 0 Then JobType = "%"
        parameterJobType.Value = JobType
        arParams(4) = parameterJobType

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_ForTraffic_withJobType_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobListJobTypeWithClosed", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetJobListFilteredByOffice(ByVal UserID As String, ByVal OfficeCode As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Dim parameterShowClosed As New SqlParameter("@Closed", SqlDbType.Bit)
        If ShowAll = True Then
            parameterShowClosed.Value = 1
        Else
            parameterShowClosed.Value = 0
        End If

        arParams(2) = parameterShowClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobs_Filtered_Closed", arParams)

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobListFilteredByOffice", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobCompListEE(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsExpenseEdit", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListEE(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleAll", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String, ByVal showAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleAll_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListwithClosed", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasScheduleJT(ByVal UserID As String, ByVal jobtype As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parmeterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        parmeterJobType.Value = jobtype
        arParams(1) = parmeterJobType


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleJT", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListJT", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasScheduleJT(ByVal UserID As String, ByVal jobtype As String, ByVal showAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parmeterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        parmeterJobType.Value = jobtype
        arParams(1) = parmeterJobType


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleJT_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListJTwithClosed", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

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
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleCDP", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal showAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

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
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompScheduleCDP_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int)
        parameterJob.Value = JobNumber
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompSchedule", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasSchedule(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer, ByVal showAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int)
        parameterJob.Value = JobNumber
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompSchedule_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListwithClosed", Err.Description)
        End Try

        Return dr
    End Function
    'For new schedules, getting list of comps where there are not schedules
    Public Function GetJobCompListSchedule(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNum As Integer, ByVal OnlyNeeded As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arParams(4) = parameterJobNum

        If OnlyNeeded = False Then
            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsNoSchedules", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListSchedule", Err.Description)
            End Try
        Else
            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsNoSchedulesOnlyNeeded", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListSchedule", Err.Description)
            End Try
        End If

        Return dr

    End Function
    Public Function GetJobCompListScheduleExists(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsSchedulesExist", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompListSchedule", Err.Description)
        End Try

    End Function
    'generic job comp
    Public Overloads Function GetJobCompList(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsTimesheet", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListTimeline(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        '*** Create Parameters
        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(3) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompTimeLine", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function



    'get all jobcomp with closed on timesheet
    Public Overloads Function GetJobCompList(ByVal UserID As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsTimesheet_withClosed", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    'Get jobcomp with closed
    Public Overloads Function GetJobCompList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    '
    Public Overloads Function GetJobCompListJJ(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJJ(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "", Optional ByVal IsNewAlert As Boolean = False, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(9) As SqlParameter

        '*** Create Parameters

        If CP = True And IsNewAlert = False Then
            Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterCDPID.Value = CPID
            arParams(0) = parameterCDPID
        ElseIf CP = True And IsNewAlert = True Then
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID

            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(7) = parameterCP

            Dim parameterCDPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCDPID.Value = CPID
            arParams(8) = parameterCDPID
        ElseIf CP = False And IsNewAlert = True Then
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID

            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(7) = parameterCP

            Dim parameterCDPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCDPID.Value = CPID
            arParams(8) = parameterCDPID
        Else
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID
        End If

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        If (CP = True And IsNewAlert = True) Or CP = False Then
            Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            If OfficeCode Is Nothing Then
                parameterOfficeCode.Value = ""
            Else
                parameterOfficeCode.Value = OfficeCode
            End If
            arParams(5) = parameterOfficeCode

            Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
            If SalesClass Is Nothing Then
                parameterSalesClass.Value = ""
            Else
                parameterSalesClass.Value = SalesClass
            End If
            arParams(6) = parameterSalesClass
        End If

        Try
            If CP = True Then
                If IsNewAlert = False Then
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetJobCompJJ", arParams)
                Else
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompNewAlert", arParams)
                End If
            Else
                If IsNewAlert = False Then
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompJJ", arParams)
                Else
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompNewAlert", arParams)
                End If
            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    'THESE 2 SHOW JOBS WHEN "SHOW CLOSED" CHECKED
    Public Overloads Function GetJobCompListJJ(ByVal UserID As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ_withClosed", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJJ(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, ByVal ShowAll As Boolean, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "", Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        If CP = True Then
            Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterCDPID.Value = CPID
            arParams(0) = parameterCDPID
        Else
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID
            arParams(0) = parameterUserID
        End If

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        If CP = False Then
            Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOfficeCode.Value = OfficeCode
            arParams(5) = parameterOfficeCode

            Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
            parameterSalesClass.Value = SalesClass
            arParams(6) = parameterSalesClass
        End If

        Try
            If CP = True Then
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetJobCompJJ_withClosed", arParams)
            Else
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompJJ_withClosed", arParams)
            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobCompListJJPO(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ_PO", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJJPO(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        If OfficeCode Is Nothing Then
            parameterOfficeCode.Value = ""
        Else
            parameterOfficeCode.Value = OfficeCode
        End If
        arParams(5) = parameterOfficeCode

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        If SalesClass Is Nothing Then
            parameterSalesClass.Value = ""
        Else
            parameterSalesClass.Value = SalesClass
        End If
        arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompJJ_PO", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobCompListCB(ByVal UserID As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_CreativeBrief_withClosed", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListCB(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_CreativeBrief", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListCB(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, ByVal ShowAll As Boolean, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'parameterOfficeCode.Value = OfficeCode
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'parameterSalesClass.Value = SalesClass
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_CreativeBrief_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListCB(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'If OfficeCode Is Nothing Then
        '    parameterOfficeCode.Value = ""
        'Else
        '    parameterOfficeCode.Value = OfficeCode
        'End If
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'If SalesClass Is Nothing Then
        '    parameterSalesClass.Value = ""
        'Else
        '    parameterSalesClass.Value = SalesClass
        'End If
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_CreativeBrief", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobCompListJV(ByVal UserID As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_JobVersion_withClosed", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJV(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_JobVersion", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJV(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, ByVal ShowAll As Boolean, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'parameterOfficeCode.Value = OfficeCode
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'parameterSalesClass.Value = SalesClass
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_JobVersion_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJV(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'If OfficeCode Is Nothing Then
        '    parameterOfficeCode.Value = ""
        'Else
        '    parameterOfficeCode.Value = OfficeCode
        'End If
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'If SalesClass Is Nothing Then
        '    parameterSalesClass.Value = ""
        'Else
        '    parameterSalesClass.Value = SalesClass
        'End If
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_JobVersion", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobCompListJS(ByVal UserID As String, ByVal ShowAll As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_JobSpecs_withClosed", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJS(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAllJobComps_JobSpecs", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJS(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, ByVal ShowAll As Boolean, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'parameterOfficeCode.Value = OfficeCode
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'parameterSalesClass.Value = SalesClass
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_JobSpecs_withClosed", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobCompListJS(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Job As Integer, Optional ByVal OfficeCode As String = "", Optional ByVal SalesClass As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 4)
        parameterJob.Value = Job
        arParams(4) = parameterJob

        'Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        'If OfficeCode Is Nothing Then
        '    parameterOfficeCode.Value = ""
        'Else
        '    parameterOfficeCode.Value = OfficeCode
        'End If
        'arParams(5) = parameterOfficeCode

        'Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        'If SalesClass Is Nothing Then
        '    parameterSalesClass.Value = ""
        'Else
        '    parameterSalesClass.Value = SalesClass
        'End If
        'arParams(6) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_JobSpecs", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetDesktopObjects(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDesktopObjects", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetDesktopObjectsCP(ByVal UserID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetDesktopObjects", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetUsers() As SqlDataReader
        '-----------------------------------------------
        ' Returns UserCode and USERNames
        '---------------------------------------------

        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetUsers")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetUsers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetEmployees(ByVal UserID As String, Optional ByVal ShowAll As Boolean = False, Optional ByVal OverrideSecEmp As Boolean = False, Optional ByVal FromTS As Boolean = False) As SqlDataReader
        '---------------------------------------------------
        ' Return EmpCodes and Employee Names
        '---------------------------------------------------
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim arP(4) As SqlParameter

        Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arP(0) = parameterUserID

        Dim parameterShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.TinyInt)
        If ShowAll = True Then
            parameterShowAll.Value = 1
        ElseIf ShowAll = False Then
            parameterShowAll.Value = 0
        End If
        arP(1) = parameterShowAll

        Dim parameterOverrideSecEmp As New SqlParameter("@OVERRIDE_SEC_EMP", SqlDbType.TinyInt)
        If OverrideSecEmp = True Then
            parameterOverrideSecEmp.Value = 1
        ElseIf ShowAll = False Then
            parameterOverrideSecEmp.Value = 0
        End If
        arP(2) = parameterOverrideSecEmp

        Dim parameterFromTS As New SqlParameter("@FROM_TS", SqlDbType.Bit)
        If FromTS = True Then
            parameterFromTS.Value = 1
        ElseIf FromTS = False Then
            parameterFromTS.Value = 0
        End If
        arP(3) = parameterFromTS

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmpCodes", arP)
        Catch
            Dim nbr As Integer = Err.Number
            Dim str As String = Err.Description
            str = str
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployees", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAccountExecs(ByVal UserID As String, Optional ByVal ShowAll As Boolean = False) As SqlDataReader
        '---------------------------------------------------
        ' Return EmpCodes and Employee Names
        '---------------------------------------------------
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim arP(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arP(0) = parameterUserID

        Dim parameterShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.SmallInt)
        If ShowAll = True Then
            parameterShowAll.Value = 1
        ElseIf ShowAll = False Then
            parameterShowAll.Value = 0
        End If
        arP(1) = parameterShowAll

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAccExecCodes", arP)
        Catch
            Dim nbr As Integer = Err.Number
            Dim str As String = Err.Description
            str = str
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployees", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAccountExecsDT(ByVal UserID As String, Optional ByVal ShowAll As Boolean = False) As DataTable
        '---------------------------------------------------
        ' Return EmpCodes and Employee Names
        '---------------------------------------------------
        Dim dt As DataTable

        '*** Create Parameters
        Dim arP(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arP(0) = parameterUserID

        Dim parameterShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.SmallInt)
        If ShowAll = True Then
            parameterShowAll.Value = 1
        ElseIf ShowAll = False Then
            parameterShowAll.Value = 0
        End If
        arP(1) = parameterShowAll

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAccExecCodes", "dt", arP)
        Catch
            Dim nbr As Integer = Err.Number
            Dim str As String = Err.Description
            str = str
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployees", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetAccountExecsBillingApprovalBatch() As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = HttpContext.Current.Session("UserCode")

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAccExecCodes_BillingApprovalBatch", parameterUserID)
            Return dr
        Catch
            Return Nothing
        End Try

    End Function

    Public Function GetEmployeesFML(ByVal UserID As String) As DataTable
        '---------------------------------------------------
        ' Return EmpCodes and Employee Names
        '---------------------------------------------------

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmpsByFML", "Dt", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployeesFML", Err.Description)
        End Try

    End Function


    Public Function GetEmployeesBySupervisor(ByVal UserID As String, ByVal SuperCode As String, Optional ByVal fromapp As String = "") As SqlDataReader
        '-------------------------------------------------------------------------
        ' Return EmpCodes and Employee Names Supervised by SuperCode Employee
        '-------------------------------------------------------------------------
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterSuperCode As New SqlParameter("@SuperCode", SqlDbType.VarChar, 6)
        parameterSuperCode.Value = SuperCode
        arParams(1) = parameterSuperCode

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 10)
        parameterFromApp.Value = fromapp
        arParams(2) = parameterFromApp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmpCodesBySup", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployeesBySupervisor", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetManagers(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim parameterUserID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetManagers", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetManagers", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetSupervisors(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim parameterUserID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetSupervisors", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetSupervisors", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetPOList(ByVal OmitVoided As String, ByVal OmitClosed As String, ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parmeterOmitVoided As New SqlParameter("@OmitVoided", SqlDbType.VarChar, 6)
        parmeterOmitVoided.Value = OmitVoided
        arParams(0) = parmeterOmitVoided

        Dim parameterOmitClosed As New SqlParameter("@OmitClosed", SqlDbType.VarChar, 6)
        parameterOmitClosed.Value = OmitClosed
        arParams(1) = parameterOmitClosed

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(2) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_po", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetPOList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetGLAccountList(ByVal empcode As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "proc_WV_PO_GetPOGLAccounts", parameterEmpCode)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetGLAccountList", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetEmployeesByRole(ByVal UserID As String, ByVal eRole As String) As SqlDataReader
        '---------------------------------------------------
        ' Return EmpCodes and Employee Names
        '---------------------------------------------------
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim arParams(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterRole As New SqlParameter("@Role", SqlDbType.VarChar, 6)
        parameterRole.Value = eRole
        arParams(1) = parameterRole

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmpCodesByRole", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmployeesByRole", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetEmailAlertGroups() As SqlDataReader
        Dim StrSQL As String = "SELECT DISTINCT EMAIL_GR_CODE AS Code, EMAIL_GR_CODE AS [Description] FROM EMAIL_GROUP WITH(NOLOCK) WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0;"
        Try
            Return oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetTasks(Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNbr As Integer = 0) As SqlDataReader

        Dim dr As SqlDataReader

        Dim arP(2) As SqlParameter

        Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        pJobNumber.Value = JobNumber
        arP(0) = pJobNumber

        Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        pJobComponentNbr.Value = JobComponentNbr
        arP(1) = pJobComponentNbr

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetTasks", arP)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetTasks", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetGroups() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetGroups")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetGroups", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetTrafficCodes() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetTrafficCodes")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetTrafficCodes", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetTrafficStatusCodes() As DataTable
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetTrafficCodes", "dtTrafficStatusCodes")
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTrafficNames() As DataTable
        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetTrafficCodes_Name", "dtTrafficStatusCodes")
        Catch ex As Exception

        End Try
    End Function
    Public Function GetFunctionsByUserID(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetFunctionsByEmpCodeDT(ByVal EmpCode As String) As DataTable
        Dim dt As DataTable

        Dim parameterUserID As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode

        Dim parameterJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJobNumber.Value = 0

        Dim parameterClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClientCode.Value = System.DBNull.Value

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_ByEmpCode", "dtFunctions", {parameterUserID, parameterJobNumber, parameterClientCode})
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetFunctionsByEmpCode(ByVal EmpCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode

        Dim parameterJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJobNumber.Value = 0

        Dim parameterClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClientCode.Value = System.DBNull.Value

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_ByEmpCode", {parameterUserID, parameterJobNumber, parameterClientCode})
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetFunctionsByEmpCodeDatatable(ByVal EmpCode As String, ByVal JobNumber As Integer) As DataTable

        Dim parameterUserID As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode
        Dim parameterJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJobNumber.Value = JobNumber
        Dim parameterClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClientCode.Value = System.DBNull.Value

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_ByEmpCode", "DtEmpFunctions", {parameterUserID, parameterJobNumber, parameterClientCode})
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

    End Function
    Public Function GetFunctionsByEmpCodeDatatable(ByVal EmpCode As String) As DataTable

        Dim parameterUserID As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode
        Dim parameterJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJobNumber.Value = 0
        Dim parameterClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterClientCode.Value = System.DBNull.Value

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_ByEmpCode", "DtEmpFunctions", {parameterUserID, parameterJobNumber, parameterClientCode})
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

    End Function
    Public Function GetEstimateFunctionsPS() As DataTable


        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Traffic_Schedule_GetEstimateFunctions", "dtFunctions")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateFunctionsPS", Err.Description)
        End Try

    End Function

    Public Function GetFunctionsAllDT() As DataTable


        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_All", "dtFunctions")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetFunctions_AllDT", Err.Description)
        End Try

    End Function

    Public Function GetFunctionsAll() As SqlDataReader
        Dim dr As SqlDataReader


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_All")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetFunctions_All", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetFunctionsAllEst() As SqlDataReader
        Dim dr As SqlDataReader


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_All_Estimating")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetFunctions_All_Estimating", Err.Description)
        End Try

        Return dr
    End Function

    'returns only "Income Only"
    Public Function GetFunctionsAllEvt() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_All_Events")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetFunctions_All_Estimating", Err.Description)
        End Try
        Return dr
    End Function

    Public Function GetFunctionsVendor(ByVal UserID As String) As SqlDataReader

        Dim dr As SqlDataReader



        '*** Create Parameters

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)

        parameterUserID.Value = UserID.ToLower



        Try

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions_Vendor", parameterUserID)

        Catch

            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsVendor", Err.Description)

        End Try



        Return dr

    End Function


    Public Function GetJobsWithCDP(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFunctions", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFunctionsByUserID", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCategories", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetCategoriesDT() As DataTable

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetCategories", "DtCategories")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCategories", Err.Description)
        End Try

    End Function
    Public Function GetRoles() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetRoles")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRoles", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetRolesByDesc() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetRolesByDesc")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRolesByDesc", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetTaskDescriptions() As DataSet
        Dim ds As New DataSet

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetTaskDescriptions")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetTaskDescriptions", Err.Description)
        End Try

        Return ds
    End Function
    Public Function GetDept(ByVal EmpCode As String, Optional ByVal ShowAll As Boolean = True) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(2) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Dim parameterShowAll As New SqlParameter("@ShowAll", SqlDbType.Int)
        If ShowAll = True Then
            parameterShowAll.Value = 1
        Else
            parameterShowAll.Value = 0
        End If
        arParams(1) = parameterShowAll

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDepts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDept", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetDeptDatatable(ByVal EmpCode As String, Optional ByVal ShowAll As Boolean = True) As DataTable
        Dim arParams(2) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Dim parameterShowAll As New SqlParameter("@ShowAll", SqlDbType.Int)
        If ShowAll = True Then
            parameterShowAll.Value = 1
        Else
            parameterShowAll.Value = 0
        End If
        arParams(1) = parameterShowAll

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDepts", "DtDepts", arParams)
        Catch
            Return Nothing
        End Try

    End Function

    Public Function GetDeptsByEmpCodeWithDefault(ByVal EmpCode As String) As DataTable
        Dim arParams(1) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Try
            Return SqlHelper.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDeptsByEmpCodeWithDefault", "DtDepts", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function ddCampaignFilter(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal inclCLosed As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then
            Err.Raise(9999, "cDropDowns:ddCampaign", "Client Code is Required")
        End If
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        'If DivisionCode.Trim.Length = 0 Then
        '    Err.Raise(9999, "cJobs:ddCampaign", "Division Code is Required")
        'End If
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        'If ProductCode.Trim.Length = 0 Then
        '    Err.Raise(9999, "cJobs:ddCampaign", "Product Code is Required")
        'End If
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(3) = parameterUserID

        Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
        parameterInclClosed.Value = inclCLosed
        arParams(4) = parameterInclClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_filter_campaign", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddCampaign", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddFilterCampaignFilter(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal inclCLosed As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        'If ClientCode.Trim.Length = 0 Then
        '    Err.Raise(9999, "cDropDowns:ddCampaign", "Client Code is Required")
        'End If
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        'If DivisionCode.Trim.Length = 0 Then
        '    Err.Raise(9999, "cJobs:ddCampaign", "Division Code is Required")
        'End If
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        'If ProductCode.Trim.Length = 0 Then
        '    Err.Raise(9999, "cJobs:ddCampaign", "Product Code is Required")
        'End If
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(3) = parameterUserID

        Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
        parameterInclClosed.Value = inclCLosed
        arParams(4) = parameterInclClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_filter_campaign_filter", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddCampaign", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddAlertGroups() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_AlertGroups")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddCampaign", Err.Description)
        End Try

        Return dr
    End Function


    Public Function ddCampaign(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As SqlDataReader
        '
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter


        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then
            Err.Raise(9999, "cDropDowns:ddCampaign", "Client Code is Required")
        End If
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then
            Err.Raise(9999, "cJobs:ddCampaign", "Division Code is Required")
        End If
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then
            Err.Raise(9999, "cJobs:ddCampaign", "Product Code is Required")
        End If
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_campaign", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddCampaign", Err.Description)
        End Try

        Return dr
    End Function

    Public Function CampaignSearch(ByVal UserID As String, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal InclClosed As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(2) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(3) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(4) = parameterProductCode

        Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
        parameterInclClosed.Value = InclClosed
        arParams(5) = parameterInclClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_campaign_search_popup", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:CampaignSearch", Err.Description)
        End Try

        Return dr
    End Function

    Public Function CampaignSearchJobNew(ByVal UserID As String, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal InclClosed As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(2) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(3) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(4) = parameterProductCode

        Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
        parameterInclClosed.Value = InclClosed
        arParams(5) = parameterInclClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_campaign_search_jobnew", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:CampaignSearch", Err.Description)
        End Try

        Return dr
    End Function

    Public Function CampaignSearchEstimate(ByVal UserID As String, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal InclClosed As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
        parameterOfficeCode.Value = OfficeCode
        arParams(1) = parameterOfficeCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(2) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(3) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(4) = parameterProductCode

        Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
        parameterInclClosed.Value = InclClosed
        arParams(5) = parameterInclClosed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_campaign_search_estimate", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:CampaignSearch", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddCoopBilling() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_coop_billing")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddCoopBilling", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddSalesClassFormat(Optional ByVal SalesClassCode As String = "") As SqlDataReader
        Dim dr As SqlDataReader

        If SalesClassCode.Trim.Length = 0 Then
            Err.Raise(9999, "cDropDowns:ddCampaign", "Sales Class Code is Required")
        End If
        Dim Tparameter As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        Tparameter.Value = SalesClassCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_sales_class_format", Tparameter)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddSalesClassFormat", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddComplexity() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_complexity")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddComplexity", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddPromotion() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_promotion")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddPromotion", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddJobType(Optional ByVal SC_CODE As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parameterSC_CODE As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
        parameterSC_CODE.Value = SC_CODE
        arParams(0) = parameterSC_CODE

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_comp_job_type", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddJobName(Optional ByVal SC_CODE As String = "") As DataTable
        Dim dt As DataTable
        Dim arParams(1) As SqlParameter

        Dim parameterSC_CODE As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
        parameterSC_CODE.Value = SC_CODE
        arParams(0) = parameterSC_CODE

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_comp_job_type_name", "dt", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dt
    End Function
    Public Function ddJobTypejh(Optional ByVal SC_CODE As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parameterSC_CODE As New SqlParameter("@SC_CODE", SqlDbType.VarChar, 6)
        parameterSC_CODE.Value = SC_CODE
        arParams(0) = parameterSC_CODE

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_comp_job_type_jh", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobTypejh", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddDeptTeam() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_dept_team")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddDepts() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Depts")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddAdNumber() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_ad_number")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddExpInv(ByVal emp_code As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(0) As SqlParameter

        Dim parameterEMP_CODE As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
        parameterEMP_CODE.Value = emp_code
        arParams(0) = parameterEMP_CODE

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_expense_inv", arParams)
        Catch
            Dim e As String
            e = Err.Description
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddExpInv", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddAdNumberwithClient(ByVal CL_CODE As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parameterCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterCL_CODE.Value = CL_CODE
        arParams(0) = parameterCL_CODE

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_ad_number_with_Client", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddAdNumber", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddMarket() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_market")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddJobType", Err.Description)
        End Try

        Return dr
    End Function
    'Modified by Sam Tran on 2006/05/11
    '	added for tax code lookup
    Public Function ddTaxCodes() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_Tax_Codes")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:ddTaxCodes", Err.Description)
        End Try

        Return dr
    End Function

    Public Function ddProductCategory(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

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
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_product_category", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function ddProductCategoryDS(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As DataSet
        Dim ds As DataSet
        Dim arParams(3) As SqlParameter

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
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dd_product_category", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return ds
    End Function
    Public Function GetOffices() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetOffices")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetOffices", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetOfficesEmp(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(0) As SqlParameter

        Dim parameterUserID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetOfficesEmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetOffices", Err.Description)
        End Try

        Return dr

    End Function

    Public Function GetPostperiods() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetPostPeriods")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetPostperiods", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetCampaigns(ByVal strProductCode As String, ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = strProductCode
        arParams(1) = parameterProductCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetCampaigns", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCampaigns", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetCampaignsMediaCal(ByVal userid As String, Optional ByVal strClientCode As String = "", Optional ByVal strDivisionCode As String = "", Optional ByVal strProductCode As String = "") As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = strClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = strDivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = strProductCode
        arParams(2) = parameterProductCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 6)
        parameterUserID.Value = userid
        arParams(3) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetCampaignsMediaCal", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCampaignsMC", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetEmailGroups(ByVal strEmpCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterProductCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = strEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmailGroups", parameterProductCode)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEmailGroups", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAccountExecutive(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal userid As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_account_executive", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAccountExecutiveDT(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As DataTable
        Dim dt As DataTable
        Dim arParams(3) As SqlParameter

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
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_account_executive", "dtAE", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetCDP_ClientContact(ByVal ClientCode As String) As DataTable
        Dim arParams(1) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_cdp_client_contact", "dtClientContacts", arParams)
        Catch
            Return Nothing
        End Try

    End Function


    Public Function GetCDP_ProductContact(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal FromForm As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterFromForm As New SqlParameter("@FromForm", SqlDbType.VarChar, 15)
        parameterFromForm.Value = FromForm
        arParams(3) = parameterFromForm

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_cdp_product_contact", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetCDP_ProductContactOnly(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal FromForm As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterFromForm As New SqlParameter("@FromForm", SqlDbType.VarChar, 15)
        parameterFromForm.Value = FromForm
        arParams(3) = parameterFromForm

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_cdp_contact_productonly", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:cdp_contact_productonly", Err.Description)
        End Try

        Return dr
    End Function


    Public Function GetProductContact(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

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
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_product_contact", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetSalesClass(Optional ByVal fromapp As String = "") As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = fromapp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_salesclass", parameterFromApp)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetSalesClass", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetSalesClassDT(Optional ByVal fromapp As String = "") As DataTable
        Dim dt As DataTable

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = fromapp

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_salesclass", "dtSC", parameterFromApp)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetSalesClass", Err.Description)
        End Try

        Return dt
    End Function


    Public Function GetJobUDF1() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_udf1")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobUDF1", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobUDF2() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_udf2")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobUDF2", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobUDF3() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_udf3")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobUDF3", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobUDF4() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_udf4")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobUDF4", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobUDF5() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_job_udf5")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobUDF5", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJCUDF1() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_udf1")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJCUDF1", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJCUDF2() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_udf2")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJCUDF2", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJCUDF3() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_udf3")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJCUDF3", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJCUDF4() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_udf4")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJCUDF4", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJCUDF5() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_udf5")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJCUDF5", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAccountNumber() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jc_AccountNumber")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetAccountNumber", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetFiscalPeriod() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetFiscalPeriod")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetFiscalPeriod", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetBlackplate() As DataTable

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetBlackPLT", "dtBP")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetBlackPLT", Err.Description)
        End Try

    End Function
    Public Function GetBlackPLT() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetBlackPLT")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetBlackPLT", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetRegions() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetRegions")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetRegions", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetStatus() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetStatus")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetStatus", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobSpecTypes() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobSpecTypes")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobSpecTypes", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAPInvoices(ByVal vendor As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
        parameterVendor.Value = vendor

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetAPInvoices", parameterVendor)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetAPInvoices", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetARInvoices(ByVal client As String) As SqlDataReader
        Dim dataReaderARInvoices As SqlDataReader
        Dim sqlQuery As String = "Select Distinct CAST(AR_INV_NBR AS VARCHAR(MAX)) as 'Code'," + vbCrLf _
                                + "ISNULL(CL_CODE, '') + ' | ' + CAST(AR_INV_NBR AS VARCHAR(MAX)) + ' | ' + CASE WHEN [AR_DESCRIPTION] IS NULL THEN ISNULL(CONVERT(CHAR(10), START_DATE, 101), '') ELSE AR_DESCRIPTION + ' | ' + ISNULL(CONVERT(CHAR(10), START_DATE, 101), '') END as Description," + vbCrLf _
                                + "START_DATE," + vbCrLf _
                                + "CL_CODE" + vbCrLf _
                                + "from AR_SUMMARY" + vbCrLf _
                                + "WHERE (CL_CODE = @Client OR @Client = '') AND AR_INV_NBR NOT IN (SELECT DISTINCT AR_INV_NBR FROM dbo.AR_SUMMARY WHERE AR_TYPE = 'VO')" + vbCrLf _
                                + "ORDER BY START_DATE DESC, CAST(AR_INV_NBR AS VARCHAR(MAX))" + vbCrLf

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = client.Trim()

        Try
            dataReaderARInvoices = oSQL.ExecuteReader(mConnString, CommandType.Text, sqlQuery, parameterClient)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetARInvoices", Err.Description)
        End Try

        Return dataReaderARInvoices
    End Function

    Public Function GetADSizes(ByVal vendor As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
        parameterVendor.Value = vendor

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetADSizes", parameterVendor)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetADSizes", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetEstimateList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNum As Integer, ByVal JobComp As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(6) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arParams(4) = parameterJobNum

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = JobComp
        arParams(5) = parameterJobComp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEstimates", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetEstimateListCopy(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobType As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 10)
        parameterJobType.Value = JobType
        arParams(4) = parameterJobType


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEstimatesCopy", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateListCopy", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetEstimateCompList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Estimate As Integer, ByVal JobNum As Integer, ByVal JobComp As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterEstimate As New SqlParameter("@Estimate", SqlDbType.Int)
        parameterEstimate.Value = Estimate
        arParams(4) = parameterEstimate

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arParams(5) = parameterJobNum

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = JobComp
        arParams(6) = parameterJobComp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEstimateComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetEstimateQuoteList(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal Estimate As Integer, ByVal EstimateComp As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(6) As SqlParameter

        '*** Create Parameters
        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterEstimate As New SqlParameter("@Estimate", SqlDbType.Int)
        parameterEstimate.Value = Estimate
        arParams(4) = parameterEstimate

        Dim parameterEstimateComp As New SqlParameter("@EstimateComp", SqlDbType.Int)
        parameterEstimateComp.Value = EstimateComp
        arParams(5) = parameterEstimateComp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEstimateQuote", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetEstimateQuoteList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasEstimate(ByVal UserID As String, ByVal IncludeClosedJobComponents As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID


        Try

            If IncludeClosedJobComponents Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateAll_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateAll", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasEstimate(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer, ByVal IncludeClosedJobComponents As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int)
        parameterJob.Value = JobNumber
        arParams(4) = parameterJob

        Try

            If IncludeClosedJobComponents Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimate_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimate", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasEstimate(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal IncludeClosedJobComponents As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

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

            If IncludeClosedJobComponents Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateCDP_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateCDP", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasEstimate(ByVal UserID As String, ByVal EstNum As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateNumber", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasEstimate(ByVal UserID As String, ByVal EstNum As Integer, ByVal EstComp As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        arParams(2) = parameterEstComp

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateCompNumber", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function

    Public Overloads Function GetJobcompListHasEstimateSearch(ByVal UserID As String, ByVal EstNum As Integer, ByVal IncludeClosedJobComponents As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Try

            If IncludeClosedJobComponents Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_EstimateNumber_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_EstimateNumber", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function
    Public Overloads Function GetJobcompListHasEstimateSearch(ByVal UserID As String, ByVal EstNum As Integer, ByVal EstComp As Integer, ByVal IncludeClosedJobComponents As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
        parameterEstNum.Value = EstNum
        arParams(1) = parameterEstNum

        Dim parameterEstComp As New SqlParameter("@EstComp", SqlDbType.Int)
        parameterEstComp.Value = EstComp
        arParams(2) = parameterEstComp

        Try

            If IncludeClosedJobComponents Then

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_EstimateCompNumber_withClosed", arParams)

            Else

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobComp_EstimateCompNumber", arParams)

            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr

    End Function

    Public Overloads Function GetJobcompListHasEstimateSave(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int)
        parameterJob.Value = JobNumber
        arParams(4) = parameterJob

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateSave", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Overloads Function GetJobcompListHasEstimateSave(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SalesClass As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(5) As SqlParameter

        Dim parmeterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parmeterUserID.Value = UserID
        arParams(0) = parmeterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        parameterSalesClass.Value = SalesClass
        arParams(4) = parameterSalesClass

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJobCompEstimateSaveCDP", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetVendorsAll(Optional ByVal includemedia As Boolean = False) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterIncludemedia As New SqlParameter("@IncludeMedia", SqlDbType.SmallInt)
        If includemedia = True Then
            parameterIncludemedia.Value = 1
        Else
            parameterIncludemedia.Value = 0
        End If
        arParams(0) = parameterIncludemedia

        Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
        paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(1) = paramTask_UserCode


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetVendorsAll", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetVendorsAll", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetVendorsByFunctionCode(ByVal functioncode As String, ByVal includemedia As Boolean) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterFunctionCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar)
        parameterFunctionCode.Value = functioncode
        arParams(0) = parameterFunctionCode

        Dim parameterIncludemedia As New SqlParameter("@IncludeMedia", SqlDbType.SmallInt)
        If includemedia = True Then
            parameterIncludemedia.Value = 1
        Else
            parameterIncludemedia.Value = 0
        End If
        arParams(1) = parameterIncludemedia

        Dim paramTask_UserCode As New SqlParameter("@UserCode", SqlDbType.VarChar)
        paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(2) = paramTask_UserCode


        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetVendorsByDefaultFunc", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetVendorsByDefaultFunc", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetVendorsByFunctions(ByVal functions As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterFunctions As New SqlParameter("@Functions", SqlDbType.VarChar)
        parameterFunctions.Value = functions

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetVendorsByDefaultFunctions", parameterFunctions)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:usp_wv_dd_GetVendorsByFunctions", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetDocumentTypeList(ByVal UserID As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        'Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        'parameterUserID.Value = UserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetDocumentTypes")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetDocumentTypes", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetPOApprovers() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "proc_WV_PO_Approvers_LoadAll")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetPOApprovers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobProcessControls() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_jobprocessctrls")
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobProcessControls", Err.Description)
        End Try

        Return dr
    End Function

    Public Overloads Function GetJobListWithJobType(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobType As String) As DataTable

        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        If JobType.Trim.Length = 0 Then JobType = "%"
        parameterJobType.Value = JobType
        arParams(4) = parameterJobType

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_withJobType", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobListJobType", Err.Description)
        End Try

    End Function
    Public Overloads Function GetJobListWithJobType(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String,
                                                    ByVal ProductCode As String, ByVal JobType As String, ByVal showall As Boolean) As DataTable
        Dim arParams(5) As SqlParameter

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then ClientCode = "%"
        parameterClientCode.Value = ClientCode
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then DivisionCode = "%"
        parameterDivisionCode.Value = DivisionCode
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then ProductCode = "%"
        parameterProductCode.Value = ProductCode
        arParams(3) = parameterProductCode

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 6)
        If JobType.Trim.Length = 0 Then JobType = "%"
        parameterJobType.Value = JobType
        arParams(4) = parameterJobType

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetJob_withJobType_withClosed", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobListJobTypeWithClosed", Err.Description)
        End Try

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
