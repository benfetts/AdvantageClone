Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
<Serializable()> Public Class cRequired

    Dim mConnString As String = String.Empty
    Dim mUserCode As String = String.Empty
    Dim oSQL As SqlHelper

    Public Function GetDescription(ByVal TheLevel As String, ByVal TheKeys As String) As String
        Try

            MiscFN.CleanStringForSplit(TheKeys, ",", True, False, True, True, True)

            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim arKeys() As String

            Dim arParams(13) As SqlParameter

            Dim paramLevel As New SqlParameter("@Level", SqlDbType.VarChar, 6)
            Dim paramOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            Dim paramClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            Dim paramDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            Dim paramProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            Dim paramCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            Dim paramJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
            Dim paramJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int)
            Dim paramVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
            Dim paramAPInvoice As New SqlParameter("@APInvoice", SqlDbType.VarChar, 20)
            Dim paramAdNumber As New SqlParameter("@AdNumber", SqlDbType.VarChar, 30)
            Dim paramExpInv As New SqlParameter("@ExpInv", SqlDbType.Int)
            Dim paramEmployeeCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            paramLevel.Value = TheLevel

            paramOfficeCode.Value = System.DBNull.Value
            paramClientCode.Value = System.DBNull.Value
            paramDivisionCode.Value = System.DBNull.Value
            paramProductCode.Value = System.DBNull.Value
            paramCampaignCode.Value = System.DBNull.Value
            paramJobNumber.Value = System.DBNull.Value
            paramJobCompNumber.Value = System.DBNull.Value
            paramVendor.Value = System.DBNull.Value
            paramAPInvoice.Value = System.DBNull.Value
            paramAdNumber.Value = System.DBNull.Value
            paramExpInv.Value = System.DBNull.Value
            paramEmployeeCode.Value = System.DBNull.Value

            Select Case TheLevel
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                    Return TheKeys

                Case "AR"

                    Return TheKeys

                Case "EM"

                    paramEmployeeCode.Value = TheKeys

                Case "OF"

                    paramOfficeCode.Value = TheKeys

                Case "CL"

                    paramClientCode.Value = TheKeys

                Case "DI"

                    arKeys = TheKeys.Split(",")
                    paramClientCode.Value = arKeys(0)
                    paramDivisionCode.Value = arKeys(1)

                Case "PR"

                    arKeys = TheKeys.Split(",")
                    paramClientCode.Value = arKeys(0)
                    paramDivisionCode.Value = arKeys(1)
                    paramProductCode.Value = arKeys(2)

                Case "CM"

                    arKeys = TheKeys.Split(",")
                    paramClientCode.Value = arKeys(0)
                    paramDivisionCode.Value = arKeys(1)
                    paramProductCode.Value = arKeys(2)
                    paramCampaignCode.Value = arKeys(3)

                Case "JO"

                    paramJobNumber.Value = CType(TheKeys, Integer)

                Case "JC"

                    arKeys = TheKeys.Split(",")
                    paramJobNumber.Value = CType(arKeys(0), Integer)
                    paramJobCompNumber.Value = CType(arKeys(1), Integer)

                Case "VN"

                    arKeys = TheKeys.Split(",")
                    paramVendor.Value = arKeys(0)
                    paramAPInvoice.Value = arKeys(1)

                Case "VN2"

                    paramVendor.Value = TheKeys

                Case "AN"

                    paramAdNumber.Value = TheKeys

                Case "EX"

                    paramExpInv.Value = CInt(TheKeys)

            End Select

            arParams(0) = paramLevel
            arParams(1) = paramOfficeCode
            arParams(2) = paramClientCode
            arParams(3) = paramDivisionCode
            arParams(4) = paramProductCode
            arParams(5) = paramCampaignCode
            arParams(6) = paramJobNumber
            arParams(7) = paramJobCompNumber
            arParams(8) = paramVendor
            arParams(9) = paramAPInvoice
            arParams(10) = paramAdNumber
            arParams(11) = paramExpInv
            arParams(12) = paramEmployeeCode

            strReturn = oSQL.ExecuteScalar(CStr(mConnString), CommandType.StoredProcedure, "usp_wv_GetLookupDescription", arParams)

            If strReturn <> "" And strReturn.Length > 0 Then

                Return strReturn

            Else

                Return String.Empty

            End If

        Catch ex As Exception

        Finally

        End Try
    End Function

    Public Function GetAPID(ByVal APInvoice As String, ByVal Vendor As String)
        Try
            Dim dr As SqlDataReader

            Dim arParams(2) As SqlParameter

            Dim parameterAPInvoice As New SqlParameter("@APInvoice", SqlDbType.VarChar)
            parameterAPInvoice.Value = APInvoice
            arParams(0) = parameterAPInvoice

            Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar)
            parameterVendor.Value = Vendor
            arParams(1) = parameterVendor

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetAPID", arParams)

            Return dr
        Catch ex As Exception
            'Return 0
        End Try
    End Function

    Public Function GetCampaignIdentifier(ByVal strCampaignCode As String) As String
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty

            Dim arParams(4) As SqlParameter

            Dim paramCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            paramCampaignCode.Value = strCampaignCode
            arParams(0) = paramCampaignCode

            'Dim paramCL_CODE As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            'paramCL_CODE.Value = strCliCode
            'arParams(1) = paramCL_CODE

            'Dim paramDIV_CODE As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            'paramDIV_CODE.Value = strDivCode
            'arParams(2) = paramDIV_CODE

            'Dim paramPRD_CODE As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            'paramPRD_CODE.Value = strProdCode
            'arParams(3) = paramPRD_CODE

            strReturn = oSQL.ExecuteScalar(CStr(mConnString), CommandType.StoredProcedure, "usp_wv_GetCampaignIdentifier", arParams)

            If strReturn <> "" And strReturn.Length > 0 Then
                Return strReturn
            Else
                Return String.Empty
            End If
        Catch ex As Exception

        Finally
        End Try
    End Function

    Public Function GetRestrictedOffices(ByVal TheUserID As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        paramUserID.Value = TheUserID

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Restricted_GetOffices", paramUserID)
        Return dr
    End Function
    Public Function GetRestrictedClients(ByVal TheUserID As String, ByVal TheOfficeCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        paramUserID.Value = TheUserID
        arParams(0) = paramUserID

        Dim paramOfficeCode As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 6)
        paramOfficeCode.Value = TheOfficeCode
        arParams(1) = paramOfficeCode

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Restricted_GetClients", arParams)

        Return dr
    End Function
    Public Function GetRestrictedDivisions(ByVal TheUserID As String, ByVal TheClientCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        paramUserID.Value = TheUserID
        arParams(0) = paramUserID

        Dim paramClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        paramClientCode.Value = TheClientCode
        arParams(1) = paramClientCode

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Restricted_GetDivisions", arParams)

        Return dr
    End Function
    Public Function GetRestrictedProducts(ByVal TheUserID As String, ByVal TheClientCode As String, ByVal TheDivisionCode As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        paramUserID.Value = TheUserID
        arParams(0) = paramUserID

        Dim paramClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        paramClientCode.Value = TheClientCode
        arParams(1) = paramClientCode

        Dim paramDivisionCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        paramDivisionCode.Value = TheDivisionCode
        arParams(2) = paramDivisionCode

        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Restricted_GetProducts", arParams)

        Return dr
    End Function


    '-----------------------------------------------------------------
    'CTB-2006/06/28: Added validation that requires the Account Number
    '  if it is required by the Agency table (ACCT_NBR_R)
    '-----------------------------------------------------------------

    Public Function RequiredEmailGroupCode(Optional ByVal CLIENT_CODE As String = "") As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredEmailGroupCode" & CLIENT_CODE

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                Dim arParams(1) As SqlParameter
                Dim paramCliCode As New SqlParameter("@CLI_CODE", SqlDbType.VarChar, 6)

                paramCliCode.Value = CLIENT_CODE
                arParams(0) = paramCliCode
                iReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_comp_email_gr_code", arParams)
            Catch ex As Exception
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCAccountNumber() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCAccountNumber"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim tmp As String = String.Empty
                tmp = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_jc_accountnumber")
                If tmp = "1" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function JobCompIsTaxableVisible() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobCompIsTaxableVisible"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim iReturn As Integer = 0
                iReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_comp_taxable_visible")
                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function JobCompIsTaxable(ByVal strCliCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobCompIsTaxable" & strCliCode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim iReturn As Integer = 0
                Dim arParams(1) As SqlParameter
                Dim paramCliCode As New SqlParameter("@CLI_CODE", SqlDbType.VarChar, 6)

                paramCliCode.Value = strCliCode
                arParams(0) = paramCliCode
                iReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_comp_taxable", arParams)
                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredBlackplate(ByVal strCliCode As String, ByVal strCode As String, ByVal strItemCode As String, ByVal strVersion As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredBlackplate" & strCliCode & strCode & strItemCode & strVersion

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim iReturn As Integer = 0
                Dim arParams(4) As SqlParameter
                Dim paramCliCode As New SqlParameter("@CLI_CODE", SqlDbType.VarChar, 6)
                paramCliCode.Value = strCliCode
                arParams(0) = paramCliCode

                Dim paramCode As New SqlParameter("@CODE", SqlDbType.VarChar, 6)
                paramCode.Value = strCode
                arParams(1) = paramCode

                Dim paramItemCode As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 32)
                paramItemCode.Value = strItemCode
                arParams(2) = paramItemCode

                Dim paramVersion As New SqlParameter("@VERSION", SqlDbType.Int)
                paramVersion.Value = strVersion
                arParams(3) = paramVersion

                iReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_comp_blackplate", arParams)
                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function IsUniqueClient(ByVal strJobClientRef As String, ByVal strJobNum As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "IsUniqueClient" & strJobClientRef & strJobNum.PadLeft(6, "0")

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

        Try
            Dim iReturn As Integer = 0
            Dim arParams(2) As SqlParameter
            Dim parameterJobClientRef As New SqlParameter("@JobClientRef", SqlDbType.VarChar, 30)
            parameterJobClientRef.Value = strJobClientRef
            arParams(0) = parameterJobClientRef

            Dim parameterJobNum As New SqlParameter("@JobNumber", SqlDbType.VarChar, 6)
            parameterJobNum.Value = strJobNum
            arParams(1) = parameterJobNum

            iReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_isUniqueJobClient", arParams)

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cRequired Routine:IsUniqueClient", Err.Description)
            Return False   'something goes wrong, assume it isn't unique
        Finally

        End Try
    End Function

    Public Function HideNonBillable() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "HideNonBillable"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_HideNonBillable"))
            Catch
                iReturn = 0
            End Try
            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function AgencyRequiredEmail() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "AgencyRequiredEmail"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_AgencyRequiredEmail"))
            Catch
                iReturn = 0
            End Try
            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function AgencyAutoEmailPrompt(ByVal strJobNewUpdate As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "AgencyAutoEmailPrompt" & strJobNewUpdate

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                Select Case strJobNewUpdate
                    Case "new"
                        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_AutoEmailPromptOnNew"))
                        If iReturn > 0 Then
                            IsValid = True
                        Else
                            IsValid = False
                        End If
                    Case "update"
                        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_AutoEmailPromptOnUpdate"))
                        If iReturn > 0 Then
                            IsValid = True
                        Else
                            IsValid = False
                        End If
                    Case Else
                        IsValid = False
                End Select
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ClientGetsEmail(ByVal strEmailGroup As String, ByVal strJobNewUpdate As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ClientGetsEmail" & strEmailGroup & strJobNewUpdate

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                Dim Tparameter As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 200)
                Tparameter.Value = strEmailGroup

                Select Case strJobNewUpdate
                    Case "new"
                        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_ClientGetsEmailOnNew", Tparameter))
                        If iReturn > 0 Then
                            IsValid = True
                        Else
                            IsValid = False
                        End If
                    Case "update"
                        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_ClientGetsEmailOnUpdate", Tparameter))
                        If iReturn > 0 Then
                            IsValid = True
                        Else
                            IsValid = False
                        End If
                    Case Else
                        IsValid = False
                End Select
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredApprovedEstimate(ByVal strCliCode As String, ByVal strDivCode As String, ByVal strProdCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredApprovedEstimate" & strCliCode & strDivCode & strProdCode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Dim arParams(3) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            If strCliCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Client Code is Required")
            End If
            parameterClientCode.Value = strCliCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            If strDivCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Division Code is Required")
            End If
            parameterDivisionCode.Value = strDivCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            If strProdCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Product Code is Required")
            End If
            parameterProductCode.Value = strProdCode
            arParams(2) = parameterProductCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_ApprovedEstimate", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function OverrideApprovedEstimate() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "OverrideApprovedEstimate"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_OverrideApprovedEstimate"))
            Catch
                iReturn = 0
            End Try
            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobCompDateOpened() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobCompDateOpened"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_JobCompDateOpened"))
            Catch
                iReturn = 0
            End Try
            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobCompDueDate() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobCompDueDate"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_JobCompDueDate"))
            Catch
                iReturn = 0
            End Try
            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ProductCategoryRequired(ByVal ClientCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ProductCategoryRequired" & ClientCode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            Tparameter.Value = ClientCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_product_category", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredClientRef() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredClientRef"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_client_ref"))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredUniqueClientRef() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredUniqueClientRef"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_job_unique_client_ref"))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredCampaign(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredCampaign" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

        Dim iReturn As Integer = 0

        Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If Client.Trim.Length = 0 Then
            Err.Raise(9999, "Job:RequiredCampaign", "Client Code is Required")
        End If
        Tparameter.Value = Client

        Try
            iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_campaign", Tparameter))
        Catch
            iReturn = 0
        End Try

        If iReturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If
    End Function

    Public Function RequiredCoopBilling(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredCoopBilling" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "Job:RequiredCoopBilling", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_coop_billing", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredSalesClassFormat(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredSalesClassFormat" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "Job:RequiredCampaign", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_sales_class_format", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid


    End Function

    Public Function RequiredComplexity(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredComplexity" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "Class:Job Routine:RequiredComplexity", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_complexity", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid


    End Function

    Public Function RequiredPromotion(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredPromotion" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "Class:Job Routine:RequiredPromotion", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_promotion", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredProdContact(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredProdContact" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "Class:Job Routine:RequiredProdContact", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_prduct_contact", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobType(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobType" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredJobType", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_job_type", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredDeptTeam(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredDeptTeam" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

        Dim iReturn As Integer = 0

        Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If Client.Trim.Length = 0 Then
            Err.Raise(9999, "JobComponent:RequiredDeptTeam", "Client Code is Required")
        End If
        Tparameter.Value = Client

        Try
            iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_dept_team", Tparameter))
        Catch
            iReturn = 0
        End Try

        If iReturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If
    End Function

    Public Function RequiredAdNumber(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredAdNumber" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_ad_number", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredMarket(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredMarket" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_market", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobUDF1(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobUDF1" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_udf1", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobUDF2(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobUDF2" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_udf2", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobUDF3(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobUDF3" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_udf3", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobUDF4(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobUDF4" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_udf4", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJobUDF5(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJobUDF5" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_required_udf5", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCUDF1(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCUDF1" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jc_required_udf1", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCUDF2(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCUDF2" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jc_required_udf2", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCUDF3(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCUDF3" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jc_required_udf3", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCUDF4(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCUDF4" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jc_required_udf4", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequiredJCUDF5(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredJCUDF5" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If Client.Trim.Length = 0 Then
                Err.Raise(9999, "JobComponent:RequiredAdNumber", "Client Code is Required")
            End If
            Tparameter.Value = Client

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_jc_required_udf5", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function RequireTimeEntryAssignment() As Boolean

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequireTimeEntryAssignment"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, mUserCode)

                IsValid = AdvantageFramework.EmployeeTimesheet.CheckIfAssignmentIsRequired(DbContext)
                HttpContext.Current.Session(SessionKey) = IsValid

            End Using

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function
    Public Function JobHasWorkItems(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

        Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, mUserCode)

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)(String.Format("IF EXISTS (SELECT 1 FROM ALERT A WHERE A.JOB_NUMBER = {0} AND A.JOB_COMPONENT_NBR = {1} AND IS_WORK_ITEM = 1 AND ASSIGN_COMPLETED IS NULL) SELECT CAST(1 AS BIT) ELSE SELECT CAST(0 AS BIT);", JobNumber, JobComponentNumber)).FirstOrDefault

            Catch ex As Exception
                Return False
            End Try

        End Using

    End Function
    Public Function RequiredTimesheetComments() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "RequiredTimesheetComments"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_required_timesheet_comments"))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
    Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

        mConnString = ConnectionString
        mUserCode = UserCode

    End Sub

End Class
